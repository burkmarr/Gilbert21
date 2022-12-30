Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SQLite
Imports System.Text
Imports Microsoft.Win32
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Xml
Imports System.Xml.XPath
Imports System.Math

Public Class frmMain

    'Public dtInput As DataTable = New DataTable()
    Dim strInputFolder As String
    Dim rowActiveRecord As DataGridViewRow
    Dim bLoading As Boolean
    Dim bAllowClose As Boolean = False
    Dim strImportFolder As String
    Dim bWatchFolder As Boolean
    Dim bNotifyBalloonShowing As Boolean = False
    Dim colInputAppSoundFiles As Collection = New Collection

    Dim threadSound As Thread

    Dim intFfplayCheck As Integer = 0
    Private Const SW_HIDE As Integer = 0
    Private Const SW_RESTORE As Integer = 9
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer

    'Public Enum RecStatus
    '    Modified
    '    Created
    '    InDB
    '    Invalid
    'End Enum

    Private Sub LoadFiles(ByVal strFilenames() As String)

        Dim strFilename As String
        Dim fi As clsInputFile = Nothing
        Dim bUpdateStatus As Boolean = False

        colInputAppSoundFiles.Clear()
        CheckForUnsavedRecords()
        dgvRecords.Rows.Clear()
        dgvRecords.EditMode = DataGridViewEditMode.EditOnEnter

        'Dim tNow As DateTime = Now()
        For Each strFilename In strFilenames

            strInputFolder = Path.GetDirectoryName(strFilename)

            Select Case Path.GetExtension(strFilename).ToLower()

                Case ".jpg", ".bmp", ".gif", ".tiff"
                    fi = New clsInputFileImage(strFilename)
                Case ".wav", ".3gp"
                    fi = New clsInputFileG21App(strFilename)
                    colInputAppSoundFiles.Add(strFilename)
                Case ".csv"
                    'Assume visiontac
                    fi = New clsInputFileVisiontac(strFilename)
                    If fi.ErrorMessage <> "" Then
                        'Assume any other CSV
                        fi = New clsInputFileGeneral(strFilename)
                        bUpdateStatus = True 'This is generally for record imports
                    End If
                Case ".enex"
                    'Assume Evernote export file
                    fi = New clsInputFileEvernoteExport(strFilename)
                Case ".evernote"
                    fi = New clsInputFileEvernote(frmOptions.txtEvernoteUser.Text, frmOptions.txtEvernotePassword.Text)
                Case Else
                    'Assume any other CSV
                    fi = New clsInputFileGeneral(strFilename)
                    bUpdateStatus = True 'This is generally for record imports
            End Select

            If fi.ErrorMessage <> "" Then
                MessageBox.Show(fi.ErrorMessage)
            Else
                RecordsFromFile(fi)
            End If
        Next

        'Console.WriteLine("Time to open files: " & Now.Subtract(tNow).TotalSeconds.ToString)

        Dim row As DataGridViewRow
        'Update record status where appropriate
        If bUpdateStatus Then

            For Each row In dgvRecords.Rows
                'UpdateRecStatus(row, RecStatus.Modified)
                row.Cells("Modified").Value = "today"
                UpdateRecRowDisplay(row)
            Next
        End If

        dgvRecords.EditMode = DataGridViewEditMode.EditProgrammatically
        SetRowHeaderWidth()

        'Check that the grid references are catered for by the gazetteer
        Dim strPrefix As String = ""
        Dim lstPrefixes As List(Of String) = New List(Of String)
        For Each row In dgvRecords.Rows
            If Not cfun.HasNoValue(row.Cells("GridRef").Value) Then
                strPrefix = row.Cells("GridRef").Value.Substring(0, 2)
                If Not lstPrefixes.Contains(strPrefix) Then
                    lstPrefixes.Add(strPrefix)
                End If
            End If
        Next
        For Each strPrefix In lstPrefixes
            If Not clsLocations.IsPrefixLoaded(strPrefix) Then
                MessageBox.Show("You haven't populated the gazetter database with locations for the grid reference '" & strPrefix & "'. For better place name matching, you should do that first.")
            End If
        Next
    End Sub

    Private Sub RecordsFromFile(ByVal inFile As clsInputFile)

        Dim intTmpID As Integer
        Dim iDuplicates As Integer = 0
        Dim iInvalidGUIDs As Integer = 0
        Dim bDuplicate As Boolean
        Dim bInvalidGUID As Boolean
        Dim row As DataRow
        Dim strSQL As String
        Dim daRecords As SQLiteDataAdapter
        Dim db As clsDB = New clsDB()
        Dim cmdRecords As SQLiteCommand = db.conMain.CreateCommand()
        Dim i As Integer
        Dim dtRecords As DataTable = New DataTable
        Dim rowRecord As DataRow
        Dim rms As clsRecordMappings = New clsRecordMappings
        Dim rm As clsRecordMapping
        Dim strGR As String
        Dim objLocations As clsLocations
        Dim dtPotential As DataTable
        Dim strGUIDRegex As String

        dtPotential = inFile.GetPotentialRecords
        pbLoad.Maximum = dtPotential.Rows.Count
        pbLoad.Value = 0

        If File.Exists(inFile.FilePath) Then
            lblInputFile.Text = "Importing " & Path.GetFileName(inFile.FilePath)
            Application.DoEvents()
        End If

        For Each row In dtPotential.Rows

            pbLoad.Value += 1

            'If imported record has a GUID, check that it isn't aleady in the database
            If Not cfun.HasNoValue(row("GUID")) Then

                strGUIDRegex = "^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"
                If Not Regex.IsMatch(row("GUID"), strGUIDRegex, RegexOptions.Compiled) Then
                    iInvalidGUIDs += 1
                    bInvalidGUID = True
                Else
                    bInvalidGUID = False
                End If

                If Not bInvalidGUID Then
                    cmdRecords.CommandText = "Select count(*) from Records where GUID = '" & row("GUID") & "'"
                    If cmdRecords.ExecuteScalar() > 0 Then
                        iDuplicates += 1
                        bDuplicate = True
                    Else
                        bDuplicate = False
                    End If
                End If
            End If

            If Not bDuplicate And Not bInvalidGUID Then
                strSQL = "Select * from Records where DateTimeKey = '" & row("DateTimeKey") & "'"
                daRecords = New SQLiteDataAdapter(strSQL, db.conMain)
                dtRecords.Clear()

                If daRecords.Fill(dtRecords) > 0 Then

                    'There are existing records in the database matching this row 
                    'from the input file (by DateTimeKey)
                    For Each rowRecord In dtRecords.Rows
                        i = dgvRecords.Rows.Add()
                        For Each rm In rms

                            If rm.DBType = OleDb.OleDbType.Date Then
                                dgvRecords.Rows.Item(i).Cells(rm.G21FieldName).Value = Format(rowRecord(rm.DBFieldName), "dd/MM/yyyy")
                            Else
                                dgvRecords.Rows.Item(i).Cells(rm.G21FieldName).Value = cfun.NullToEmpty(rowRecord(rm.DBFieldName))
                            End If
                        Next

                        'Set the colour of the row to indicate status
                        'If Not IsValid(dgvRecords.Rows(i), False) Then
                        '    'Set the colour of the row to indicate invalid
                        '    UpdateRecStatus(dgvRecords.Rows(i), RecStatus.Invalid)
                        'Else
                        '    UpdateRecStatus(dgvRecords.Rows(i), RecStatus.InDB)
                        'End If
                        UpdateRecRowDisplay(dgvRecords.Rows(i))
                    Next
                Else
                    'No record in the database matches this row from the input file (by DateTimeKey)
                    'Add a row based on the file fields.
                    i = dgvRecords.Rows.Add()

                    'Insert a blank record into the database to get a record ID
                    intTmpID = GetNewTmpID()
                    dgvRecords.Rows.Item(i).Cells("ID").Value = intTmpID
                    If cfun.HasNoValue(row("GUID")) Then
                        'We would normally expect no GUID with an imported file record
                        dgvRecords.Rows(i).Cells("GUID").Value = System.Guid.NewGuid.ToString
                    Else
                        'If imported with a GUID, check whether it alerady exists in DB.
                        dgvRecords.Rows(i).Cells("GUID").Value = row("GUID")
                    End If

                    'Lat & lon
                    If Not cfun.HasNoValue(row("FileLon")) Then
                        dgvRecords.Rows.Item(i).Cells("FileLon").Value = row("FileLon")
                        dgvRecords.Rows.Item(i).Cells("FileLat").Value = row("FileLat")
                    End If

                    'Filename, FileIndex & DateTimeKey
                    If Not cfun.HasNoValue(row("Filename")) Then
                        dgvRecords.Rows.Item(i).Cells("Filename").Value = row("Filename")
                    End If
                    If Not cfun.HasNoValue(row("FileIndex")) Then
                        dgvRecords.Rows.Item(i).Cells("FileIndex").Value = row("FileIndex")
                    End If
                    If Not cfun.HasNoValue(row("DateTimeKey")) Then
                        dgvRecords.Rows.Item(i).Cells("DateTimeKey").Value = row("DateTimeKey")
                    End If

                    'Taxon
                    If Not cfun.HasNoValue(row("CommonName")) Then
                        dgvRecords.Rows.Item(i).Cells("CommonName").Value = row("CommonName")
                    End If
                    If Not cfun.HasNoValue(row("ScientificName")) Then
                        dgvRecords.Rows.Item(i).Cells("ScientificName").Value = row("ScientificName")
                    End If
                    If Not cfun.HasNoValue(row("TaxonGroup")) Then
                        dgvRecords.Rows.Item(i).Cells("TaxonGroup").Value = row("TaxonGroup")
                    End If

                    'Abundance
                    If Not cfun.HasNoValue(row("Abundance")) Then
                        dgvRecords.Rows.Item(i).Cells("Abundance").Value = row("Abundance")
                    End If
                    If Not cfun.HasNoValue(row("Units")) Then
                        dgvRecords.Rows.Item(i).Cells("Units").Value = row("Units")
                    End If

                    'Abundance
                    If Not cfun.HasNoValue(row("Comment")) Then
                        dgvRecords.Rows.Item(i).Cells("Comment").Value = row("Comment")
                    End If
                    If Not cfun.HasNoValue(row("PersonalNotes")) Then
                        dgvRecords.Rows.Item(i).Cells("PersonalNotes").Value = row("PersonalNotes")
                    End If

                    'Recorder, determiner & confirmer
                    If cfun.HasNoValue(row("Recorder")) Then
                        dgvRecords.Rows.Item(i).Cells("Recorder").Value = frmOptions.txtRecorder.Text
                    Else
                        dgvRecords.Rows.Item(i).Cells("Recorder").Value = row("Recorder")
                    End If
                    If cfun.HasNoValue(row("Determiner")) Then
                        dgvRecords.Rows.Item(i).Cells("Determiner").Value = frmOptions.txtDeterminer.Text
                    Else
                        dgvRecords.Rows.Item(i).Cells("Determiner").Value = row("Determiner")
                    End If
                    If cfun.HasNoValue(row("Confirmer")) Then
                        dgvRecords.Rows.Item(i).Cells("Confirmer").Value = ""
                    Else
                        dgvRecords.Rows.Item(i).Cells("Confirmer").Value = row("Confirmer")
                    End If

                    'Date & time
                    If Not cfun.HasNoValue(row("RecDate")) Then
                        dgvRecords.Rows.Item(i).Cells("Date").Value = row("RecDate")
                    End If
                    If Not cfun.HasNoValue(row("RecTime")) Then
                        dgvRecords.Rows.Item(i).Cells("Time").Value = row("RecTime")
                    End If

                    'Grid Ref & location
                    If Not cfun.HasNoValue(row("GridRef")) Then
                        dgvRecords.Rows.Item(i).Cells("GridRef").Value = row("GridRef")
                    ElseIf Not cfun.HasNoValue(row("FileLon")) Then
                        strGR = cfun.GetGridRef(dgvRecords.Rows.Item(i).Cells("FileLon").Value, dgvRecords.Rows.Item(i).Cells("FileLat").Value, 10)
                        dgvRecords.Rows.Item(i).Cells("GridRef").Value = strGR
                    End If

                    objLocations = Nothing
                    If cfun.HasNoValue(row("Location")) Or cfun.HasNoValue(row("Town")) Then
                        If Not cfun.HasNoValue(dgvRecords.Rows.Item(i).Cells("GridRef").Value) Then
                            objLocations = New clsLocations(dgvRecords.Rows.Item(i).Cells("GridRef").Value, frmOptions.txtDB.Text)
                        End If
                    End If

                    If Not cfun.HasNoValue(row("Location")) Then
                        dgvRecords.Rows.Item(i).Cells("Location").Value = row("Location")
                    ElseIf Not objLocations Is Nothing Then
                        dgvRecords.Rows.Item(i).Cells("Location").Value = objLocations.getNearestLocationName(clsLocations.PlaceType.Location)
                    End If

                    If Not cfun.HasNoValue(row("Town")) Then
                        dgvRecords.Rows.Item(i).Cells("Town").Value = row("Town")
                    ElseIf Not objLocations Is Nothing Then
                        dgvRecords.Rows.Item(i).Cells("Town").Value = objLocations.getNearestLocationName(clsLocations.PlaceType.Town)
                        'dgvRecords.Rows.Item(i).Cells("Town").Value = ""
                    End If

                    'Export set to false by default
                    dgvRecords.Rows.Item(i).Cells("NoExport").Value = False

                    'If a voice file is associated with the record, then process it
                    Dim bVoiceFileNotFound As Boolean = False
                    If Not cfun.HasNoValue(row("VoiceFile")) Then
                        bVoiceFileNotFound = Not (SaveVoiceForRec(row("VoiceFile"), row("Filename"), row("RecDate"), row("RecTime"), row("FileLon"), row("FileLat"), intTmpID))
                    End If

                    'If a voice file was missing, update the comment
                    If bVoiceFileNotFound Then
                        dgvRecords.Rows.Item(i).Cells("Comment").Value = "The voice file '" & row("VoiceFile") & "' could not be found."
                    End If


                    'If a media file associated with the record, then process it
                    If Not cfun.HasNoValue(row("MediaFile")) Then
                        cfun.AddMediaFile(row("MediaFile"), intTmpID, 1)
                    End If

                    'Save reference to the track file
                    If Not cfun.HasNoValue(row("Filename")) Then
                        SaveTrackForRec(row("Filename"), intTmpID)
                    End If
                End If
            End If
        Next

        If iDuplicates > 0 Then
            MessageBox.Show(iDuplicates & " records were found with matching GUIDs in the database. These were not imported.")
        End If

        If iInvalidGUIDs > 0 Then
            MessageBox.Show(iInvalidGUIDs & " records were found with invalid GUIDs. These were not imported.")
        End If

        pbLoad.Value = 0
        lblInputFile.Text = "Importing..."
        Application.DoEvents()

        db.Dispose()
    End Sub

    Public Sub ResetCalculatedLocations(ByVal bAllRecords As Boolean)

        Dim row As DataGridViewRow
        Dim strGR As String
        Dim objLocations As clsLocations
        Dim strCurrentLocation As String
        Dim strCurrentTown As String

        'Update the calculated locations from record grid references - but only if record not yet
        'saved to DB. This is used where the Locations database has been managed.
        For Each row In dgvRecords.Rows

            If cfun.HasNoValue(row.Cells("Entered").Value) Or bAllRecords Then
                If Not cfun.HasNoValue(row.Cells("GridRef").Value) Then

                    strGR = row.Cells("GridRef").Value

                    If strGR <> "" Then
                        objLocations = New clsLocations(strGR, frmOptions.txtDB.Text)

                        If cfun.HasNoValue(row.Cells("Location").Value) Then
                            strCurrentLocation = ""
                        Else
                            strCurrentLocation = row.Cells("Location").Value
                        End If
                        If cfun.HasNoValue(row.Cells("Town").Value) Then
                            strCurrentTown = ""
                        Else
                            strCurrentTown = row.Cells("Town").Value
                        End If
                        row.Cells("Location").Value = objLocations.getNearestLocationName(clsLocations.PlaceType.Location)
                        row.Cells("Town").Value = objLocations.getNearestLocationName(clsLocations.PlaceType.Town)

                        If Not cfun.HasNoValue(row.Cells("Entered").Value) Then
                            If strCurrentLocation <> row.Cells("Location").Value Or strCurrentTown <> row.Cells("Town").Value Then
                                'UpdateRecStatus(row, RecStatus.Modified)
                                row.Cells("Modified").Value = "today"
                                UpdateRecRowDisplay(row)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Function SaveVoiceForRec(ByVal strFile As String, ByVal strTrackFileName As Object, ByVal strDate As String, ByVal strTime As String, ByVal dblLon As Object, ByVal dblLat As Object, ByVal intRecID As Integer) As Boolean

        'The strTrackFileName, dblLat and dblLon arguments were changed to objects because, since adding Evernote,
        'functionality, they can now be passed as DBNULLs (31/03/2012)

        'Store the sound and link to this record
        'Date and time are those before saving corrections because we want to store
        'original info in the sounds table.
        Dim db As clsDB = New clsDB

        Dim strWavFileName As String
        Dim strWavFilePath As String

        If Not File.Exists(strFile) Then
            'This is how we are identifying VOX files for now
            strWavFileName = strFile.Replace(Chr(0), "") & ".wav"
            strWavFilePath = Path.Combine(strInputFolder, strWavFileName)
        Else
            'All other voice files (full path)
            strWavFilePath = strFile
            strWavFileName = Path.GetFileName(strFile)
        End If

        If Not File.Exists(strWavFilePath) Then
            Return False
        End If

        Dim cmdVoice As SQLiteCommand
        cmdVoice = db.conVoice.CreateCommand()

        'First insert a line in the Sounds table
        cmdVoice.CommandText = "insert into Sounds (OriginalFilename,OriginalTrackFilename,Date,Time,FileLon,FileLat,Sound) VALUES(?,?,?,?,?,?,?)"
        cmdVoice.Parameters.AddWithValue("OriginalFilename", strWavFileName)
        cmdVoice.Parameters.AddWithValue("OriginalTrackFilename", strTrackFileName)
        cmdVoice.Parameters.AddWithValue("Date", Date.Parse(strDate))
        cmdVoice.Parameters.AddWithValue("Time", strTime)
        cmdVoice.Parameters.AddWithValue("FileLon", dblLon)
        cmdVoice.Parameters.AddWithValue("FileLat", dblLat)
        cmdVoice.Parameters.AddWithValue("Sound", cfun.GetByteArrayFromWav(strWavFilePath))
        cmdVoice.ExecuteNonQuery()

        'Insert a corresponding record in the RecordSounds table to link the record and the sound
        cmdVoice.CommandText = "Select last_insert_rowid()"
        Dim intSoundID As Integer = cmdVoice.ExecuteScalar()
        cmdVoice.CommandText = "insert into RecordSounds (RecordID,SoundID,[Order]) VALUES(?,?,?)"
        cmdVoice.Parameters.Clear()
        cmdVoice.Parameters.AddWithValue("RecordID", intRecID)
        cmdVoice.Parameters.AddWithValue("SoundID", intSoundID)
        cmdVoice.Parameters.AddWithValue("Order", 1)
        cmdVoice.ExecuteNonQuery()

        cmdVoice.Dispose()
        db.Dispose()

        Return True
    End Function

    Private Sub SaveTrackForRec(ByVal strTrackFileName As String, ByVal intTmpID As Integer)

        Dim db As clsDB = New clsDB

        Dim strTrackFilePath As String = Path.Combine(strInputFolder, strTrackFileName)
        Dim fi As FileInfo
        Dim comTracks As SQLiteCommand
        comTracks = db.conTracks.CreateCommand()

        'First check whether or not this file is already in the Tracks table
        comTracks.CommandText = "select FileID from Tracks where OriginalPath = '" & strTrackFilePath & "';"
        Dim intTrackID As Integer = comTracks.ExecuteScalar()
        If intTrackID = 0 Then
            'Enter record in Track table
            fi = New FileInfo(strTrackFilePath)
            comTracks.CommandText = "Insert into Tracks (Filename, OriginalPath, CurrentPath, DateCreated, FileType, GenericFileType) values(?,?,?,?,?,?);"
            comTracks.Parameters.Clear()
            comTracks.Parameters.AddWithValue("FileName", strTrackFileName)
            comTracks.Parameters.AddWithValue("OriginalPath", strTrackFilePath)
            comTracks.Parameters.AddWithValue("CurrentPath", strTrackFilePath)
            comTracks.Parameters.AddWithValue("DateCreated", fi.CreationTime)
            comTracks.Parameters.AddWithValue("FileType", "Visiontac") 'Generalise
            comTracks.Parameters.AddWithValue("GenericFileType", "CSV") 'Generalise
            comTracks.ExecuteNonQuery()

            comTracks.CommandText = "Select last_insert_rowid()"
            intTrackID = comTracks.ExecuteScalar()
        End If

        'Enter corresponding record in the RecordsTracks table
        comTracks.CommandText = "insert into RecordTracks (RecordID, FileID) values (?,?);"
        comTracks.Parameters.Clear()
        comTracks.Parameters.AddWithValue("RecordID", intTmpID)
        comTracks.Parameters.AddWithValue("FileID", intTrackID)
        comTracks.ExecuteNonQuery()

        comTracks.Dispose()
        db.Dispose()
    End Sub

    Private Function GetNewTmpID() As Integer

        'Create a new empty row in the Records database to generate a new ID to use
        'and mark this as a temporary row.
        Dim db As clsDB = New clsDB
        Dim comMain As SQLiteCommand

        comMain = New SQLiteCommand()
        comMain.Connection = db.conMain
        comMain.CommandText = "INSERT INTO Records (IsTempRow) VALUES(?)"
        comMain.Parameters.AddWithValue("IsTempRow", True)
        comMain.ExecuteNonQuery()
        comMain.Dispose()

        comMain = New SQLiteCommand()
        comMain.Connection = db.conMain
        'comMain.CommandText = "select max(ID) from Records"
        comMain.CommandText = "Select last_insert_rowid()"
        Dim intTmpID As Integer = comMain.ExecuteScalar()
        comMain.Dispose()

        db.Dispose()

        Return intTmpID
    End Function

    Private Sub SetRowHeaderWidth()
        dgvRecords.RowHeadersWidth = 12 + (dgvRecords.Rows.Count.ToString.Length) * 7 + 12
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        OpenFileDialog.Filter = clsInputFile.GetFileOpenFilter

        OpenFileDialog.FilterIndex = frmOptions.importFileTypeIndex

        OpenFileDialog.InitialDirectory = frmOptions.txtImportFolder.Text

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            'Set import folder option if not already set
            If frmOptions.txtImportFolder.Text = "" Then
                frmOptions.txtImportFolder.Text = Path.GetDirectoryName(OpenFileDialog.FileName)
            End If

            frmOptions.importFileTypeIndex = OpenFileDialog.FilterIndex

            Cursor = Cursors.WaitCursor
            Application.DoEvents()

            bLoading = True

            CheckForUnsavedRecords()
            dgvRecords.Rows.Clear()
            DeleteTemporaryRecords()

            LoadFiles(OpenFileDialog.FileNames)
            lblInputFile.Text = ""

            TabControl1.SelectedTab = TabControl1.TabPages("tabRecords")

            bLoading = False

            Cursor = Cursors.Arrow

            cfun.CheckGazDB()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        Dim dgvRow As DataGridViewRow
        Dim strUpdateSQL As String

        Dim rms As clsRecordMappings = New clsRecordMappings()
        Dim rm As clsRecordMapping
        Dim bldrUpdate As StringBuilder = New StringBuilder()

        'Create the parameterised SQL strings for update
        For Each rm In rms
            If Not rm.DBFieldName = "ID" Then
                If bldrUpdate.Length > 0 Then
                    bldrUpdate.Append(",")
                End If
                bldrUpdate.Append(rm.DBFieldName)
                bldrUpdate.Append("=?")
            End If
        Next
        bldrUpdate.Append(",IsTempRow=?")

        Dim db As clsDB = New clsDB

        Dim comMain As SQLiteCommand = New SQLiteCommand()
        comMain.Connection = db.conMain
        strUpdateSQL = "Update Records set " & bldrUpdate.ToString() & " where ID = "

        Dim SQLtransaction As SQLite.SQLiteTransaction
        SQLtransaction = db.conMain.BeginTransaction()

        For Each dgvRow In dgvRecords.Rows
            If dgvRow.Cells("Modified").Value = "today" Then

                If Not cfun.HasNoValue(dgvRow.Cells("Modified").Value) Then
                    dgvRow.Cells("Modified").Value = Format(Date.Today, "dd/MM/yyyy")
                    If cfun.HasNoValue(dgvRow.Cells("Entered").Value) Then
                        dgvRow.Cells("Entered").Value = Format(Date.Today, "dd/MM/yyyy")
                    End If

                    comMain.CommandText = strUpdateSQL & dgvRow.Cells("ID").Value

                    For Each rm In rms
                        If Not rm.DBFieldName = "ID" Then

                            Dim param As New SQLite.SQLiteParameter()
                            comMain.Parameters.Add(param)

                            If cfun.HasNoValue(dgvRow.Cells(rm.G21FieldName).Value) Then
                                'param.Value = vbNull
                            ElseIf rm.DBType = OleDb.OleDbType.Date Then
                                param.Value = Date.Parse(dgvRow.Cells(rm.G21FieldName).Value)
                            Else
                                param.Value = dgvRow.Cells(rm.G21FieldName).Value
                            End If
                        End If
                    Next
                    comMain.Parameters.AddWithValue("IsTempRow", False)

                    'Do the DB update
                    comMain.ExecuteNonQuery()
                    comMain.Parameters.Clear()

                    'Set the colour of the row to indicate status
                    'If Not IsValid(dgvRow, False) Then
                    '    'Set the colour of the row to red to indicate invalid
                    '    UpdateRecStatus(dgvRow, RecStatus.Invalid)
                    'Else
                    '    UpdateRecStatus(dgvRow, RecStatus.InDB)
                    'End If
                    UpdateRecRowDisplay(dgvRow)
                End If
            End If
        Next

        SQLtransaction.Commit()
        comMain.Dispose()
        db.Dispose()
    End Sub

    Private Sub dgvRecords_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellClick

        If e.RowIndex = -1 Then Exit Sub 'Clicked on header
        If e.ColumnIndex = -1 Then Exit Sub 'Selected entire row

        Dim row As DataGridViewRow = dgvRecords.Rows(e.RowIndex)

        If dgvRecords.Columns(e.ColumnIndex).Name = "GridRef" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Location" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Town" Then
            'frmLocation.Init(row, strInputFolder)
            'frmLocation.ShowDialog()
            frmRecordDetails.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhere")
            frmRecordDetails.ShowDialog()

        ElseIf dgvRecords.Columns(e.ColumnIndex).Name = "CommonName" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "ScientificName" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "TaxonGroup" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Abundance" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Units" Then
            'frmTaxon.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text)
            'frmTaxon.ShowDialog()
            frmRecordDetails.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhat")

            frmRecordDetails.ShowDialog()

        ElseIf dgvRecords.Columns(e.ColumnIndex).Name = "Recorder" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Determiner" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Confirmer" Then

            'frmRecorder.Init(row)
            'frmRecorder.ShowDialog()
            frmRecordDetails.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWho")
            frmRecordDetails.ShowDialog()

        ElseIf dgvRecords.Columns(e.ColumnIndex).Name = "Comment" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "PersonalNotes" Then

            'frmComments.Init(row)
            'frmComments.ShowDialog()
            frmRecordDetails.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabComment")
            frmRecordDetails.ShowDialog()

        ElseIf dgvRecords.Columns(e.ColumnIndex).Name = "Date" Or _
            dgvRecords.Columns(e.ColumnIndex).Name = "Time" Then

            'frmDate.Init(row)
            'frmDate.ShowDialog()

            frmRecordDetails.Init(row, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhen")
            frmRecordDetails.ShowDialog()
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click

        If dgvRecords.SelectedRows.Count = 0 Then

            MessageBox.Show("No rows selected for deletion.")
        Else
            If MessageBox.Show("Are you sure that you want to delete these " & dgvRecords.SelectedRows.Count.ToString() & " records?", "Confirm deletion", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Dim row As DataGridViewRow
                Dim db As clsDB = New clsDB

                Dim comJoin As SQLiteCommand = New SQLiteCommand(db.conMain)

                Dim strVoiceDB As String = Path.Combine(frmOptions.txtDBFolder.Text, "g21voice.db3")
                comJoin.CommandText = "attach database '" & strVoiceDB & "' as voice"
                comJoin.ExecuteNonQuery()

                Dim strTracksDB As String = Path.Combine(frmOptions.txtDBFolder.Text, "g21tracks.db3")
                comJoin.CommandText = "attach database '" & strTracksDB & "' as tracks"
                comJoin.ExecuteNonQuery()

                Dim strID As String
                Dim dtRow As DataRow
                Dim dt As DataTable = New DataTable

                For Each row In dgvRecords.SelectedRows

                    strID = row.Cells("ID").Value.ToString()

                    'Delete from Records table
                    comJoin.CommandText = "delete from Records where ID = " & strID & ";"
                    comJoin.ExecuteNonQuery()

                    'Delete records in the Sounds table that are referenced by the deleted ID
                    '(via the RecordSounds table) but only if they are not referenced by any
                    'other records
                    Dim daRecords As SQLiteDataAdapter
                    daRecords = New SQLiteDataAdapter("select SoundID from voice.RecordSounds where RecordID = " & strID, db.conMain)
                    dt.Clear()
                    daRecords.Fill(dt)

                    For Each dtRow In dt.Rows
                        comJoin.CommandText = "select count(*) from voice.RecordSounds where SoundID = " & dtRow("SoundID")
                        If comJoin.ExecuteScalar = 1 Then
                            'Delete the sound if not referenced by any other record
                            comJoin.CommandText = "delete from voice.Sounds where SoundID = " & dtRow("SoundID")
                            comJoin.ExecuteNonQuery()
                        End If
                    Next

                    'Delete from RecordSounds table
                    comJoin.CommandText = "delete from voice.RecordSounds where RecordID = " & strID & ";"
                    comJoin.ExecuteNonQuery()

                    'Delete records in the Tracks table that are referenced by the deleted ID
                    '(via the RecordTracks table) but only if they are not referenced by any
                    'other records
                    Dim daTracks As SQLiteDataAdapter
                    daTracks = New SQLiteDataAdapter("select FileID from tracks.RecordTracks where RecordID = " & strID, db.conMain)
                    dt.Clear()
                    daTracks.Fill(dt)
                    For Each dtRow In dt.Rows
                        comJoin.CommandText = "select count(*) from tracks.RecordTracks where FileID = " & dtRow("FileID")
                        If comJoin.ExecuteScalar = 1 Then
                            'Delete the track if not referenced by any other record
                            comJoin.CommandText = "delete from tracks.Tracks where FileID = " & dtRow("FileID")
                            comJoin.ExecuteNonQuery()
                        End If
                    Next

                    'Delete from RecordTracks table
                    comJoin.CommandText = "delete from tracks.RecordTracks where RecordID = " & strID & ";"
                    comJoin.ExecuteNonQuery()
                Next

                For Each row In dgvRecords.SelectedRows
                    dgvRecords.Rows.Remove(row)
                Next

                comJoin.Dispose()
                db.Dispose()
            End If
        End If
    End Sub

    Private Sub tsbCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbCopy.Click

        If Not dgvRecords.SelectedRows.Count = 1 Then

            MessageBox.Show("You must select a single row to copy.")
        Else
            Dim i As Integer = dgvRecords.SelectedRows.Item(0).Index + 1
            dgvRecords.EditMode = DataGridViewEditMode.EditOnEnter

            'Copy the selected record
            Dim intSelID As Integer = dgvRecords.SelectedRows.Item(0).Cells("ID").Value
            Dim intTmpID As Integer = GetNewTmpID()
            dgvRecords.Rows.Insert(i, dgvRecords.SelectedRows.Item(0).Clone())
            dgvRecords.Rows(i).Cells("ID").Value = intTmpID
            dgvRecords.Rows(i).Cells("GUID").Value = System.Guid.NewGuid.ToString

            Dim rm As clsRecordMapping
            Dim rms As clsRecordMappings = New clsRecordMappings
            For Each rm In rms
                If Not rm.DBFieldName = "ID" And Not rm.DBFieldName = "GUID" _
                    And Not rm.DBFieldName = "Entered" And Not rm.DBFieldName = "Modified" Then
                    dgvRecords.Rows(i).Cells(rm.G21FieldName).Value = dgvRecords.SelectedRows.Item(0).Cells(rm.G21FieldName).Value
                End If
            Next

            Dim strField As String
            'Any fields marked not to be copied in the options, reset their values
            For Each strField In frmOptions.clbClearFieldsOnCopy.CheckedItems
                dgvRecords.Rows(i).Cells(strField).Value = ""
            Next
            'UpdateRecStatus(dgvRecords.Rows(i), RecStatus.Modified)
            'dgvRecords.Rows(i).Cells("Modified").Value = "today"
            'UpdateRecRowDisplay(dgvRecords.Rows(i))

            'Select the new record
            dgvRecords.ClearSelection()
            dgvRecords.Rows(i).Selected = True

            Dim j As Integer
            For j = 0 To dgvRecords.Columns.Count - 1
                If dgvRecords.Columns(j).Visible Then
                    Exit For
                End If
            Next
            dgvRecords.CurrentCell = dgvRecords.Item(j, i)

            dgvRecords.EditMode = DataGridViewEditMode.EditProgrammatically

            'Copy the wav file
            Dim db As clsDB = New clsDB

            Dim comRecordSounds As SQLiteCommand = New SQLiteCommand(db.conVoice)
            Dim paramRecordID As New SQLite.SQLiteParameter()
            comRecordSounds.Parameters.Add(paramRecordID)
            paramRecordID.Value = intTmpID
            Dim paramSoundID As New SQLite.SQLiteParameter()
            comRecordSounds.Parameters.Add(paramSoundID)
            Dim paramOrder As New SQLite.SQLiteParameter()
            comRecordSounds.Parameters.Add(paramOrder)

            Dim daRecordsSounds As SQLiteDataAdapter = New SQLiteDataAdapter("select * from RecordSounds where RecordID = " & intSelID, db.conVoice)
            Dim dtRecordSounds As DataTable = New DataTable
            daRecordsSounds.Fill(dtRecordSounds)
            Dim dtRow As DataRow

            For Each dtRow In dtRecordSounds.Rows
                paramSoundID.Value = dtRow("SoundID")
                paramOrder.Value = dtRow("Order")

                comRecordSounds.CommandText = "insert into RecordSounds (RecordID, SoundID, [Order]) Values(?,?,?)"
                comRecordSounds.ExecuteNonQuery()
            Next

            'Copy the track file
            Dim comRecordTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
            comRecordTracks.Parameters.Add(paramRecordID)
            Dim paramFileID As New SQLite.SQLiteParameter()
            comRecordTracks.Parameters.Add(paramFileID)

            Dim daRecordsTracks As SQLiteDataAdapter = New SQLiteDataAdapter("select * from RecordTracks where RecordID = " & intSelID, db.conTracks)
            Dim dtRecordTracks As DataTable = New DataTable
            daRecordsTracks.Fill(dtRecordTracks)

            For Each dtRow In dtRecordTracks.Rows
                paramFileID.Value = dtRow("FileID")
                comRecordTracks.CommandText = "insert into RecordTracks (RecordID, FileID) Values(?,?)"
                comRecordTracks.ExecuteNonQuery()
            Next

            comRecordSounds.Dispose()
            daRecordsSounds.Dispose()
            daRecordsTracks.Dispose()
            db.Dispose()
        End If
    End Sub

    Public Function IsValid(ByVal row As DataGridViewRow, ByVal bShowMessage As Boolean) As Boolean

        Dim strErr As String = ""

        'If there's no value in the 'Modified' field, it's just a candidate record and
        'is allowed to be invalid.
        If cfun.HasNoValue(row.Cells("Modified").Value) Then
            Return True
        End If

        'This is a biological record - check that all is okay
        If cfun.HasNoValue(row.Cells("Recorder").Value) Then
            strErr = AppendErr(strErr, "You must specify the name of a recorder.")
        End If
        If cfun.HasNoValue(row.Cells("ScientificName").Value) Then
            strErr = AppendErr(strErr, "You must specify a scientific name.")
        End If
        If cfun.HasNoValue(row.Cells("Location").Value) Then
            strErr = AppendErr(strErr, "You must specify a location name.")
        End If
        If cfun.HasNoValue(row.Cells("GridRef").Value) Then
            strErr = AppendErr(strErr, "You must specify a grid reference.")
        Else
            'Ensure that the grid reference is valid
            Dim objGridRef As GridRef = New GridRef
            objGridRef.MakePrefixArrays()
            objGridRef.sErrorMessage = ""
            objGridRef.GridRef = row.Cells("GridRef").Value
            objGridRef.ParseGridRef(True)
            If Not objGridRef.sErrorMessage.Length = 0 Then
                strErr = AppendErr(strErr, objGridRef.sErrorMessage)
            End If
        End If

        If cfun.HasNoValue(row.Cells("Date").Value) Then
            strErr = AppendErr(strErr, "You must specify a date for the record.")
        Else
            If Not Convert.ToDateTime(row.Cells("Date").Value) <= Now() Then
                strErr = AppendErr(strErr, "You must not specify a date in the future.")
            End If
        End If

        If strErr.Length > 0 Then
            If bShowMessage Then
                MessageBox.Show(strErr)
            End If
            Return False
        Else
            If bShowMessage Then
                MessageBox.Show("Valid!")
            End If
            Return True
        End If
    End Function

    Private Function AppendErr(ByVal strErr As String, ByVal strNewErr As String) As String

        If strErr.Length = 0 Then
            Return strNewErr
        Else
            Return strErr & " " & strNewErr
        End If
    End Function

    Private Sub tsbValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbValidate.Click

        If Not dgvRecords.SelectedRows.Count = 1 Then

            MessageBox.Show("You must select a single row to validate.")
        Else
            IsValid(dgvRecords.SelectedRows(0), True)
        End If
    End Sub

    Private Sub tsbMergeWAV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMergeWAV.Click

        If dgvRecords.SelectedRows.Count <= 1 Then
            MessageBox.Show("You must select two or more rows to merge sounds.")
        Else
            If MessageBox.Show("Do you want to merge the sounds for the selected records and assign to first record?", "Merge sounds", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Dim db As clsDB = New clsDB

                Dim intFirstSelID As Integer = dgvRecords.SelectedRows(dgvRecords.SelectedRows.Count - 1).Cells("ID").Value
                Dim intSelID As Integer

                Dim i As Integer
                Dim daRecords As SQLiteDataAdapter
                Dim dt As DataTable = New DataTable
                Dim dtRow As DataRow
                Dim comRecordSounds As SQLiteCommand = New SQLiteCommand(db.conVoice)
                comRecordSounds.CommandText = "select max([Order]) from RecordSounds where RecordID = " & intFirstSelID
                Dim iSoundOrder As Integer = comRecordSounds.ExecuteScalar()

                Dim paramRecordID As New SQLite.SQLiteParameter()
                comRecordSounds.Parameters.Add(paramRecordID)
                paramRecordID.Value = intFirstSelID
                Dim paramSoundID As New SQLite.SQLiteParameter()
                comRecordSounds.Parameters.Add(paramSoundID)
                Dim paramOrder As New SQLite.SQLiteParameter()
                comRecordSounds.Parameters.Add(paramOrder)

                For i = dgvRecords.SelectedRows.Count - 2 To 0 Step -1
                    intSelID = dgvRecords.SelectedRows(i).Cells("ID").Value

                    daRecords = New SQLiteDataAdapter("select * from RecordSounds where RecordID = " & intSelID & " order by [Order]", db.conVoice)
                    daRecords.Fill(dt)
                    For Each dtRow In dt.Rows

                        paramSoundID.Value = dtRow("SoundID")
                        iSoundOrder += 1
                        paramOrder.Value = iSoundOrder

                        comRecordSounds.CommandText = "insert into RecordSounds (RecordID, SoundID, [Order]) Values(?,?,?)"
                        comRecordSounds.ExecuteNonQuery()
                    Next
                    daRecords.Dispose()
                Next

                comRecordSounds.Dispose()
                db.Dispose()
            End If
        End If
    End Sub

    Private Sub tsbDeleteWAV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteWAV.Click

        If dgvRecords.SelectedRows.Count = 0 Then

            MessageBox.Show("You must select a one or more rows to delete sounds.")
        Else
            If MessageBox.Show("Are you sure you want to delete the sounds associated with these " & dgvRecords.SelectedRows.Count & " records?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                For i = 0 To dgvRecords.SelectedRows.Count - 1
                    DeleteSoundsForID(dgvRecords.SelectedRows(i).Cells("ID").Value)
                Next
            End If
        End If
    End Sub

    Sub DeleteSoundsForID(ByVal intRecordID As Integer)

        Dim db As clsDB = New clsDB

        Dim comVoice As SQLiteCommand = New SQLiteCommand(db.conVoice)

        comVoice.CommandText = "delete from RecordSounds where RecordID = " & intRecordID & ";"
        comVoice.ExecuteNonQuery()

        'Delete sound orphans
        comVoice.CommandText = "delete from Sounds where SoundID not in (Select SoundID from RecordSounds);"
        comVoice.ExecuteNonQuery()

        comVoice.Dispose()
        db.Dispose()
    End Sub

    Private Sub tsbPlaySound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlaySound.Click

        If Not dgvRecords.SelectedRows.Count = 1 Then

            MessageBox.Show("You must select a single row to play sound.")
        Else
            Dim objCF As cfun = New cfun
            objCF.PlayWavForIDV2(dgvRecords.SelectedRows(0).Cells("ID").Value)
        End If
    End Sub

    Public Sub UpdateRecRowDisplay(ByVal row As DataGridViewRow)
        
        If cfun.NullToEmpty(row.Cells("Modified").Value) = "" Then
            'New record, so don't colour the record
        ElseIf row.Cells("Modified").Value = "today" Then
            row.DefaultCellStyle.BackColor = frmOptions.butStyleModRec.BackColor
        ElseIf IsValid(row, False) Then
            row.DefaultCellStyle.BackColor = frmOptions.butStyleValidRec.BackColor
        Else
            row.DefaultCellStyle.BackColor = frmOptions.butStyleOtherRec.BackColor
        End If
        If row.Cells("NoExport").Value Then
            row.HeaderCell.Style.BackColor = frmOptions.butStyleNoExportRec.BackColor
        Else
            row.HeaderCell.Style.BackColor = Nothing
        End If
    End Sub

    Private Sub frmMain_AutoSizeChanged(sender As Object, e As System.EventArgs) Handles Me.AutoSizeChanged

        SizeBlind(False)
    End Sub

    'Public Sub UpdateRecStatus(ByVal row As DataGridViewRow, ByVal status As RecStatus)

    '    Select Case status

    '        Case RecStatus.Created
    '            row.DefaultCellStyle.BackColor = frmOptions.butStyleModRec.BackColor
    '            row.Cells("Modified").Value = "today"
    '            row.Cells("Entered").Value = Nothing

    '        Case RecStatus.Modified
    '            row.DefaultCellStyle.BackColor = frmOptions.butStyleModRec.BackColor
    '            row.Cells("Modified").Value = "today"

    '        Case RecStatus.InDB
    '            row.DefaultCellStyle.BackColor = frmOptions.butStyleValidRec.BackColor

    '        Case RecStatus.Invalid
    '            row.DefaultCellStyle.BackColor = frmOptions.butStyleOtherRec.BackColor
    '    End Select

    '    If row.Cells("NoExport").Value Then
    '        row.HeaderCell.Style.BackColor = frmOptions.butStyleNoExportRec.BackColor
    '    Else
    '        row.HeaderCell.Style.BackColor = Nothing
    '    End If

    'End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'cfun.DeleteTmpWavsV2()
        CheckForUnsavedRecords()
        DeleteTemporaryRecords()
        frmOptions.WriteRegistrySettings()

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not bAllowClose And bWatchFolder Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            e.Cancel = True
            Me.G21Notify.Visible = True
        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.Width = 1200

        G21Notify.Visible = False

        Dim rms As clsRecordMappings = New clsRecordMappings
        Dim rm As clsRecordMapping
        Dim i As Integer

        For Each rm In rms
            i = dgvRecords.Columns.Add(rm.G21FieldName, rm.G21FieldName)
            dgvRecords.Columns(i).Visible = rm.InitiallyVisible
            dgvRecords.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        frmOptions.ReadRegistrySettings()
        frmOptions.initCheckBoxes()
        lblDatabase.Text = frmOptions.txtDBFolder.Text
        lblInputFile.Text = ""

        InitShortcutList(False)

        'Charts
        cbYearsPerGraph.SelectedIndex = 0
        splitGraphs.IsSplitterFixed = True
        Chart1.Visible = False
        cbChartType.SelectedIndex = 0
        cbChartColours.SelectedIndex = 0
        nudMaxYear.Value = Year(Today)
        nudMaxYear.Maximum = Year(Today)
        nudMinYear.Maximum = Year(Today)

        'CheckDB()

        'Initialise the tmpRecordSounds dataset
        'dtTmpRecordSounds.Columns.Add(New DataColumn("tmpRecordID", System.Type.GetType("System.Int32")))
        'dtTmpRecordSounds.Columns.Add(New DataColumn("tmpSoundFileName", System.Type.GetType("System.Int32")))
        'dtTmpRecordSounds.Columns.Add(New DataColumn("Order", System.Type.GetType("System.Int32")))

        'Delete temporary WAV files
        'cfun.DeleteTmpWavsV2()
        DeleteTemporaryRecords()

    End Sub

    Private Sub tsbManageLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbManageLocation.Click

        If dgvRecords.SelectedRows.Count = 0 Then

            MessageBox.Show("You must first select a row to manage locations.")
        Else
            frmManageLocations.Init(dgvRecords.SelectedRows(0).Cells("GridRef").Value)
            frmManageLocations.ShowDialog()
        End If
    End Sub

    Private Sub dgvRecords_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRecords.KeyDown

        If e.KeyCode = Keys.Return Then
            'Enter key pressed
            'If currently row is last row in grid view
            If dgvRecords.CurrentRow Is dgvRecords.Rows(dgvRecords.Rows.Count - 1) Then

                'Create a new record when use hits enter key
                tsbNew_Click(Nothing, Nothing)

                'Ensures that pressing return doesn't move cursor to the next row 
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Tab Then
            'TAB key pressed
            Dim iCol As Integer
            Dim strColName As String

            'For iCol = dgvRecords.CurrentCell.ColumnIndex To dgvRecords.Columns.Count - 1
            For iCol = 0 To dgvRecords.Columns.Count - 1

                strColName = dgvRecords.Columns(iCol).Name
                Select Case strColName
                    Case "ScientificName"
                        If HasNoValue(dgvRecords.CurrentRow.Cells(iCol)) Then
                            e.Handled = True
                            'frmTaxon.Init(dgvRecords.CurrentRow, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text)
                            'frmTaxon.ShowDialog()
                            frmRecordDetails.Init(dgvRecords.CurrentRow, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhat")
                            frmRecordDetails.ShowDialog()
                            Exit For
                        End If
                    Case "Location"
                        If HasNoValue(dgvRecords.CurrentRow.Cells(iCol)) Then
                            e.Handled = True
                            'frmLocation.Init(dgvRecords.CurrentRow, strInputFolder)
                            'frmLocation.ShowDialog()
                            frmRecordDetails.Init(dgvRecords.CurrentRow, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhere")
                            frmRecordDetails.ShowDialog()
                            Exit For
                        End If
                    Case "Date"
                        If HasNoValue(dgvRecords.CurrentRow.Cells(iCol)) Then
                            e.Handled = True
                            'frmDate.Init(dgvRecords.CurrentRow)
                            'frmDate.ShowDialog()
                            frmRecordDetails.Init(dgvRecords.CurrentRow, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabWhen")
                            frmRecordDetails.ShowDialog()
                            Exit For
                        End If
                    Case "Comment"
                        If HasNoValue(dgvRecords.CurrentRow.Cells(iCol)) Then
                            e.Handled = True
                            'frmComments.Init(dgvRecords.CurrentRow)
                            'frmComments.ShowDialog()
                            frmRecordDetails.Init(dgvRecords.CurrentRow, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text, "tabComment")
                            frmRecordDetails.ShowDialog()
                            Exit For
                        End If
                    Case Else
                        'Do nothing
                End Select
            Next
        End If
    End Sub

    Private Function HasNoValue(ByVal cell As DataGridViewCell) As Boolean

        If cell.Value Is Nothing Then
            Return True
        ElseIf cell.Value.ToString.Length = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub dgvRecords_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvRecords.RowPostPaint

        Using b As SolidBrush = New SolidBrush(dgvRecords.RowHeadersDefaultCellStyle.ForeColor)

            e.Graphics.DrawString(e.RowIndex + 1.ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                dgvRecords.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvRecords_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRecords.SelectionChanged

        If bLoading Then
            Exit Sub
        End If

        If dgvRecords.SelectedRows.Count = 1 Then

            Dim rowDG As DataGridViewRow = dgvRecords.SelectedRows(0)

            If rowDG.Cells("Modified").Value = Nothing Then

                'frmTaxon.Init(rowDG, strInputFolder, frmOptions.txtTaxonDictionaryFilter.Text)
                'frmTaxon.ShowDialog()
            End If
        End If

    End Sub

    Private Sub tsbManageTaxa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbManageTaxa.Click

        frmManageTaxonDictionary.ShowDialog()

    End Sub

    Private Sub tsbAddHashCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAddHashCode.Click

        frmHashCode.ShowDialog()
    End Sub

    Private Function OpenBySQL(ByVal strSQL As String) As DataTable

        CheckForUnsavedRecords()

        dgvRecords.EditMode = DataGridViewEditMode.EditOnEnter

        Dim dtInput As DataTable = New DataTable()

        Dim db As clsDB = New clsDB

        Dim daRecords As SQLiteDataAdapter
        daRecords = New SQLiteDataAdapter(strSQL, db.conMain)

        Try
            daRecords.Fill(dtInput)
        Catch ex As Exception
            MessageBox.Show("Record selection query failed: " & ex.Message)
            bLoading = False
            Return Nothing
        End Try

        db.Dispose()

        Return dtInput
    End Function

    Private Sub DisplayOpenedRecords(ByVal dtInput As DataTable)

        bLoading = True

        dgvRecords.Rows.Clear()

        If Not dtInput Is Nothing Then

            Dim rms As clsRecordMappings = New clsRecordMappings
            Dim rm As clsRecordMapping

            Dim dtRow As DataRow
            Dim i As Integer

            For Each dtRow In dtInput.Rows
                i = dgvRecords.Rows.Add()
                For Each rm In rms

                    If rm.DBType = OleDb.OleDbType.Date Then
                        If cfun.HasNoValue(dtRow(rm.DBFieldName)) Then
                            dgvRecords.Rows.Item(i).Cells(rm.G21FieldName).Value = Nothing
                        Else
                            dgvRecords.Rows.Item(i).Cells(rm.G21FieldName).Value = Format(dtRow(rm.DBFieldName), "dd/MM/yyyy")
                        End If
                    Else
                        dgvRecords.Rows.Item(i).Cells(rm.G21FieldName).Value = cfun.NullToEmpty(dtRow(rm.DBFieldName))
                    End If
                Next

                'If Not IsValid(dgvRecords.Rows.Item(i), False) Then
                '    'Set the colour of the row to red to indicate invalid
                '    UpdateRecStatus(dgvRecords.Rows(i), RecStatus.Invalid)
                'Else
                '    UpdateRecStatus(dgvRecords.Rows(i), RecStatus.InDB)
                'End If

                UpdateRecRowDisplay(dgvRecords.Rows(i))

                dgvRecords.EditMode = DataGridViewEditMode.EditProgrammatically
                SetRowHeaderWidth()
            Next
        End If

        bLoading = False
    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click

        Dim i As Integer = dgvRecords.Rows.Count
        bLoading = True

        dgvRecords.EditMode = DataGridViewEditMode.EditOnEnter
        dgvRecords.Rows.Insert(i, 1)

        'Init ID
        dgvRecords.Rows(i).Cells("ID").Value = GetNewTmpID()
        dgvRecords.Rows(i).Cells("GUID").Value = System.Guid.NewGuid.ToString

        'Initialise recorder, determiner & confirmer
        dgvRecords.Rows(i).Cells("Recorder").Value = frmOptions.txtRecorder.Text
        dgvRecords.Rows(i).Cells("Determiner").Value = frmOptions.txtDeterminer.Text
        dgvRecords.Rows(i).Cells("Confirmer").Value = ""

        'Initialise voice
        'dgvRecords.Rows(i).Cells("Voice").Value = cfun.GetByteArraySoundResource(My.Resources.ChangeMetadata)

        'Initialise time
        'dgvRecords.Rows(i).Cells("Time").Value = "00:00"

        'After record created and row selected, tnitialise any other fields accoring to selected shortcut
        Dim strHash As String = tscbHash.Text
        If strHash.Length > 0 Then
            InitFromShortCut(dgvRecords.Rows(i), strHash)
        End If

        'Select the new record
        dgvRecords.ClearSelection()
        dgvRecords.Rows(i).Selected = True

        'Select first visible column the current cell
        Dim j As Integer
        For j = 0 To dgvRecords.Columns.Count - 1
            If dgvRecords.Columns(j).Visible Then
                Exit For
            End If
        Next
        dgvRecords.CurrentCell = dgvRecords.Item(j, i)

        'Record status
        'UpdateRecStatus(dgvRecords.Rows(i), RecStatus.Modified)

        'dgvRecords.Rows(i).Cells("Modified").Value = "today"
        'UpdateRecRowDisplay(dgvRecords.Rows(i))

        dgvRecords.EditMode = DataGridViewEditMode.EditProgrammatically

        bLoading = False

        My.Computer.Audio.Play(My.Resources.Windows_Exclamation, AudioPlayMode.Background)
    End Sub

    Private Sub ClearRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearRecordsToolStripMenuItem.Click

        CheckForUnsavedRecords()
        dgvRecords.Rows.Clear()
        DeleteTemporaryRecords()

        MakeGraphs()
    End Sub

    Public Sub CheckForUnsavedRecords()

        For Each row In dgvRecords.Rows
            If row.Cells("Modified").Value = "today" Then

                If MessageBox.Show("You have edits, do you want to save these first?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    SaveToolStripMenuItem_Click(Nothing, Nothing)
                End If
                Exit For
            End If
        Next
    End Sub
    Private Sub ExportRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportRecordsToolStripMenuItem.Click

        frmExport.ShowDialog()
    End Sub

    Private Sub tsbOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOptions.Click

        frmOptions.ShowDialog()
        lblDatabase.Text = frmOptions.txtDBFolder.Text

        strImportFolder = frmOptions.txtImportFolder.Text
        bWatchFolder = frmOptions.chkWatchImport.Checked

        For Each row As DataGridViewRow In dgvRecords.Rows

            'If row.Cells("Modified").Value = "today" Then
            '    UpdateRecStatus(row, RecStatus.Modified)
            'ElseIf cfun.NullToEmpty(row.Cells("Modified").Value) = "" Then
            '    'UpdateRecStatus(row, RecStatus.Created)
            'ElseIf IsValid(row, False) Then
            '    UpdateRecStatus(row, RecStatus.Invalid)
            'Else
            '    UpdateRecStatus(row, RecStatus.InDB)
            'End If

            UpdateRecRowDisplay(row)
        Next

        'Check for valid database
        Dim db As clsDB = New clsDB
        If db.ErrorMessage <> "" Then
            MessageBox.Show(db.ErrorMessage)
        End If
        db.Dispose()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub InitShortcutList(ByVal bInitAddHoc As Boolean)

        'tscbHash.ComboBox.DataSource = Nothing
        'tscbHash.ComboBox.DisplayMember = "Hash"
        tscbHash.Items.Clear()
        tscbHash.Items.Add("")
        tscbHash.Items.Add("#adhoc")

        Dim db As clsDB = New clsDB

        Dim com As SQLiteCommand = New SQLiteCommand()
        com.Connection = db.conMain

        Dim strSQL As String = "Select * from HashCodes order by Hash"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMain)

        Dim dtHash As DataTable = New DataTable()

        'First time in, database connection will fail so catch it

        Try
            If odba.Fill(dtHash) > 0 Then
                'tscbHash.ComboBox.DataSource = dtHash
                Dim dr As DataRow
                For Each dr In dtHash.Rows

                    If Not dr("Hash").ToString() = "#adhoc" Then
                        tscbHash.Items.Add(dr("Hash").ToString())
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

        'If there is a hash code called '#adhoc' then select this one by default
        If bInitAddHoc Then
            tscbHash.SelectedIndex = 1
        End If

        com.Dispose()
        odba.Dispose()
        db.Dispose()
    End Sub

    Public Function InitFromShortCut(ByVal row As DataGridViewRow, ByVal strHash As String) As Boolean

        'A hash code was specified - update the active row according to values stored against the
        'hash code in the database.

        Dim db As clsDB = New clsDB

        Dim com As SQLiteCommand = New SQLiteCommand("Select * from HashCodes where Hash = ?", db.conMain)
        com.Parameters.AddWithValue("Hash", strHash)
        Dim odr As SQLiteDataReader = com.ExecuteReader()


        If Not odr.HasRows Then

            MessageBox.Show("The code you specified was not found in the database")
            com.Dispose()
            odr.Close()
            db.Dispose()
            Return False
        Else
            odr.Read()
            Dim strDate As String
            If cfun.HasNoValue(odr.Item("RecDate")) Then
                strDate = ""
            Else
                strDate = Format(odr.Item("RecDate"), "dd/MM/yyyy")
            End If
            UpdateFromHash(row, "CommonName", odr.Item("CommonName"))
            UpdateFromHash(row, "ScientificName", odr.Item("ScientificName"))
            UpdateFromHash(row, "TaxonGroup", odr.Item("TaxonGroup"))
            UpdateFromHash(row, "Abundance", odr.Item("Abundance"))
            UpdateFromHash(row, "Units", odr.Item("Units"))
            UpdateFromHash(row, "Location", odr.Item("Location"))
            UpdateFromHash(row, "Town", odr.Item("Town"))
            UpdateFromHash(row, "GridRef", odr.Item("GridRef"))
            UpdateFromHash(row, "Date", strDate)
            UpdateFromHash(row, "Comment", odr.Item("Comment"))
            com.Dispose()
            odr.Close()
            db.Dispose()
            Return True
        End If
    End Function

    Private Sub UpdateFromHash(ByVal row As DataGridViewRow, ByVal strCol As String, ByVal val As Object)

        Dim bUpdate As Boolean = False
        If row.Cells(strCol).Value = Nothing Then
            bUpdate = True
        ElseIf row.Cells(strCol).Value.ToString.Length = 0 Then
            bUpdate = True
        End If

        If bUpdate Then
            row.Cells(strCol).Value = val.ToString()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim strVer As String = "{0}.{1}.{2}.{3}"

        If My.Application.IsNetworkDeployed Then
            strVer = System.String.Format(strVer, My.Application.Deployment.CurrentVersion.Major, My.Application.Deployment.CurrentVersion.Minor, My.Application.Deployment.CurrentVersion.Build, My.Application.Deployment.CurrentVersion.Revision)
        End If

        MessageBox.Show("You are using Gilbert 21 version: " & strVer)
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click

        'If MessageBox.Show("Help is available from the Giblert 21 website. Do you want to " & _
        '                   "open it?", "Help", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Try
            System.Diagnostics.Process.Start("https://burkmarr.github.io/Gilbert21/HelpHTML/Gilbert 21.html")
        Catch ex As Exception
            MessageBox.Show("Could not open 'https://burkmarr.github.io/Gilbert21/HelpHTML/Gilbert 21.html' from Gilbert. Try navigating directly to this web page from your browser.")
        End Try
        'End If
    End Sub

    Public Sub CheckDB()

        Dim strSQL As String = "select count(Voice) from records"

        Dim dt As DataTable = New DataTable()
        Dim MyConnection As OleDbConnection
        MyConnection = New OleDbConnection("Provider=Microsoft.jet.oledb.4.0;data source=" & frmOptions.txtDB.Text)

        Try
            MyConnection.Open()
        Catch ex As Exception
            'MessageBox.Show("Failed to connect to Gilbert 21 DB (ensure DB is correctly set in options): " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Dim mySQL As OleDbCommand = New OleDbCommand(strSQL, MyConnection)

        Try
            mySQL.ExecuteScalar().ToString()
            MessageBox.Show("To use this new version of Gilbert, you will first need to run " & _
                            "the DB conversion (see tools menu). This will create a new " & _
                            "folder, in the same folder where your Gilbert21 database is " & _
                            "stored, with the same name as your Gilbert21 database and the " & _
                            "extension '.voice' - e.g. 'Gilbert21.voice'. " & _
                            vbCrLf & vbCrLf & "This folder will be " & _
                            "used to store all WAV files that were previously stored in the " & _
                            "database itself. The purpose of this is to reduce the size of the " & _
                            "Access database and to overcome some problems when storing the " & _
                            "sounds in the DB (weird sounds and crashes). " & _
                            vbCrLf & vbCrLf & "Before you do this, " & _
                            "you should quit Gilbert and makde a backup of your database. If " & _
                            "you don't do the backup and it all goes tits up, don't come crying " & _
                            "to me!")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        SizeBlind(False)

        If Me.WindowState = FormWindowState.Minimized And bWatchFolder Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.G21Notify.Visible = True

            timNotify.Enabled = True
        Else
            timNotify.Enabled = False
        End If
        bNotifyBalloonShowing = False
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'This event will only fire after the splash screen has disappeared and the main form is shown

        Dim strVersion As String = "{0}.{1}.{2}.{3}"
        If My.Application.IsNetworkDeployed Then
            strVersion = System.String.Format(strVersion, My.Application.Deployment.CurrentVersion.Major, My.Application.Deployment.CurrentVersion.Minor, My.Application.Deployment.CurrentVersion.Build, My.Application.Deployment.CurrentVersion.Revision)
        End If

        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")
        Dim strLastVersion As String = newkey.GetValue("Version")

        If strVersion <> "{0}.{1}.{2}.{3}" And strVersion <> strLastVersion Then
            If MessageBox.Show("You are running a new version of Gilbert 21. Do you want to " & _
                               "check out what's new?", "New version", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    System.Diagnostics.Process.Start("https://burkmarr.github.io/Gilbert21/WhatsNew.aspx")
                Catch ex As Exception
                    MessageBox.Show("Could not open 'https://burkmarr.github.io/Gilbert21/WhatsNew.aspx' from Gilbert. Try browsing to this page from your Browser.")
                End Try
            End If

            newkey.SetValue("Version", strVersion)
        End If

        strImportFolder = frmOptions.txtImportFolder.Text
        bWatchFolder = frmOptions.chkWatchImport.Checked
    End Sub

    Private Sub tsbGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGE.Click

        frmExport.GEQuick()
    End Sub

    Private Sub Version1To2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version1To2ToolStripMenuItem.Click

        frmConvertDB.ShowDialog()
    End Sub

    Private Sub DeleteTemporaryRecords()

        'Clear the collection of Android app sound files used to generate temp records
        colInputAppSoundFiles.Clear()

        'Deal with temporary records
        Dim db As clsDB = New clsDB
        If db.ErrorMessage <> "" Then
            MessageBox.Show(db.ErrorMessage)
            Exit Sub
        End If

        Dim comJoin As SQLiteCommand = New SQLiteCommand(db.conMain)

        Dim strVoiceDB As String = Path.Combine(frmOptions.txtDBFolder.Text, "g21voice.db3")
        comJoin.CommandText = "attach database '" & strVoiceDB & "' as voice"
        comJoin.ExecuteNonQuery()

        Dim strTracksDB As String = Path.Combine(frmOptions.txtDBFolder.Text, "g21tracks.db3")
        comJoin.CommandText = "attach database '" & strTracksDB & "' as tracks"
        comJoin.ExecuteNonQuery()

        Dim strMediaDB As String = Path.Combine(frmOptions.txtDBFolder.Text, "g21media.db3")
        comJoin.CommandText = "attach database '" & strMediaDB & "' as media"
        comJoin.ExecuteNonQuery()

        'The following can fail where the database tables have not yet been created
        Try
            'comJoin.CommandText = "delete from voice.Sounds where SoundID in (select v.SoundID from voice.RecordSounds as v, Records as r where r.IsTempRow = 1 and r.ID = v.RecordID);"
            'comJoin.ExecuteNonQuery()
            'The above is not reliable because it is possible that some Sounds may have been appended
            'to a record that is not being deleted as a temporary record. The most reliable thing
            'seems to be to delete any orphan sound records at the end, but there are efficiency
            'concerns with this.

            comJoin.CommandText = "delete from voice.RecordSounds where RecordID in (select ID from Records where IsTempRow = 1);"
            comJoin.ExecuteNonQuery()
            comJoin.CommandText = "delete from tracks.RecordTracks where RecordID in (select ID from Records where IsTempRow = 1);"
            comJoin.ExecuteNonQuery()
            comJoin.CommandText = "delete from media.RecordMedia where RecordID in (select ID from Records where IsTempRow = 1);"
            comJoin.ExecuteNonQuery()
            comJoin.CommandText = "delete from Records where IsTempRow = 1;"
            comJoin.ExecuteNonQuery()

            'Delete sound orphans
            comJoin.CommandText = "delete from voice.Sounds where SoundID not in (Select SoundID from RecordSounds);"
            comJoin.ExecuteNonQuery()

            'Check for orphan RecordSounds records
            Dim intOrphans As Integer
            comJoin.CommandText = "select count(*) from voice.RecordSounds as r where r.RecordID not in (Select ID from Records);"
            intOrphans = comJoin.ExecuteScalar()
            If intOrphans > 0 Then
                If MessageBox.Show("There are " & intOrphans.ToString() & " orphans in table RecordSounds. Do you want to delete them?", "Orphans found", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    comJoin.CommandText = "delete from voice.RecordSounds where RecordID not in (Select ID from Records);"
                    comJoin.ExecuteNonQuery()
                End If
            End If

            'Delete track orphans
            comJoin.CommandText = "delete from tracks.Tracks where FileID not in (Select FileID from RecordTracks);"
            comJoin.ExecuteNonQuery()

            'Check for orphan RecordTracks records
            comJoin.CommandText = "select count(*) from tracks.RecordTracks as r where r.RecordID not in (Select ID from Records);"
            intOrphans = comJoin.ExecuteScalar()
            If intOrphans > 0 Then
                If MessageBox.Show("There are " & intOrphans.ToString() & " orphans in table RecordTracks. Do you want to delete them?", "Orphans found", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    comJoin.CommandText = "delete from tracks.RecordTracks where RecordID not in (Select ID from Records);"
                    comJoin.ExecuteNonQuery()
                End If
            End If

            'Delete media orphans
            comJoin.CommandText = "delete from media.Media where FileID not in (Select FileID from RecordMedia);"
            comJoin.ExecuteNonQuery()

            'Check for orphan RecordMedia records
            comJoin.CommandText = "select count(*) from media.RecordMedia as m where m.RecordID not in (Select ID from Records);"
            intOrphans = comJoin.ExecuteScalar()
            If intOrphans > 0 Then
                If MessageBox.Show("There are " & intOrphans.ToString() & " orphans in table RecordMedia. Do you want to delete them?", "Orphans found", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    comJoin.CommandText = "delete from media.RecordMedia where RecordID not in (Select ID from Records);"
                    comJoin.ExecuteNonQuery()
                End If
            End If

        Catch ex As Exception

        End Try

        comJoin.Dispose()
        db.Dispose()
    End Sub

    Private Sub PopulateTracksTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopulateTracksTableToolStripMenuItem.Click

        frmInitTracks.ShowDialog()
    End Sub

    Private Function FilterByValidity(ByVal dtInput As DataTable) As DataTable

        Dim rms As clsRecordMappings = New clsRecordMappings
        Dim rm As clsRecordMapping
        Dim colDelete As Collection = New Collection
        Dim dgvRow As DataGridViewRow = dgvRecords.Rows(dgvRecords.Rows.Add())

        Dim dtRow As DataRow
        For Each dtRow In dtInput.Rows
            For Each rm In rms

                If rm.DBType = OleDb.OleDbType.Date Then
                    If Not IsDBNull(dtRow(rm.DBFieldName)) Then
                        dgvRow.Cells(rm.G21FieldName).Value = Format(dtRow(rm.DBFieldName), "dd/MM/yyyy")
                    End If
                Else
                    dgvRow.Cells(rm.G21FieldName).Value = cfun.NullToEmpty(dtRow(rm.DBFieldName))
                End If
            Next
            If Not IsValid(dgvRow, False) Then
                colDelete.Add(dtRow)
            End If
        Next

        For Each dtRow In colDelete
            dtInput.Rows.Remove(dtRow)
        Next

        Return dtInput
    End Function

    Private Function FilterByExport(ByVal dtInput As DataTable) As DataTable

        If frmOpenByFilter.clbExports.CheckedItems.Count = 0 Then
            MessageBox.Show("You didn't select any Exports, so this filter will not be used.")
            Return dtInput
        End If

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports
        Dim comDate As SQLiteCommand = New SQLiteCommand()
        comDate.Connection = db.conExports
        Dim dt As DataTable
        Dim dtMerge As DataTable = Nothing
        Dim colDelete As Collection = New Collection
        Dim foundRows() As DataRow

        comDate.CommandText = "Select ExportDate from Exports where ExportID = ?"
        comDate.Parameters.AddWithValue("ExportID", Nothing)

        comExport.CommandText = "Select * from RecordExport where ExportID = ?"
        comExport.Parameters.AddWithValue("ExportID", Nothing)

        Dim dateExport As Date

        For Each row As DataRowView In frmOpenByFilter.clbExports.CheckedItems

            comDate.Parameters("ExportID").Value = row("ExportID")
            dateExport = comDate.ExecuteScalar()

            comExport.Parameters("ExportID").Value = row("ExportID")
            Dim odba As SQLiteDataAdapter
            odba = New SQLiteDataAdapter(comExport)
            dt = New DataTable()
            odba.Fill(dt)

            If dtMerge Is Nothing Then
                dtMerge = dt
            Else
                dtMerge.Merge(dt)
            End If
        Next
        dtMerge = dtMerge.DefaultView.ToTable(True)

        Dim dtRow As DataRow
        For Each dtRow In dtInput.Rows

            foundRows = dtMerge.Select("RecordID = " & dtRow("ID"))

            Select Case frmOpenByFilter.cbExportFilterType.Text

                Case "Records included in"
                    If foundRows.Length = 0 Then
                        colDelete.Add(dtRow)
                    End If
                Case "Records not included in"
                    If foundRows.Length > 0 Then
                        colDelete.Add(dtRow)
                    End If
                Case "Records created since"
                    If Not dtRow("Entered") > dateExport Then
                        colDelete.Add(dtRow)
                    End If
                Case "Records included but since modified"
                    If foundRows.Length = 0 Then
                        colDelete.Add(dtRow)
                    ElseIf Not dtRow("Modified") > dateExport Then
                        colDelete.Add(dtRow)
                    End If
                Case "Records created or modified since"
                    If Not (dtRow("Entered") > dateExport Or dtRow("Modified") > dateExport) Then
                        colDelete.Add(dtRow)
                    End If
                Case Else

            End Select
        Next

        For Each dtRow In colDelete
            dtInput.Rows.Remove(dtRow)
        Next

        Return dtInput

    End Function

    Private Function FilterByRecipient(ByVal dtInput As DataTable) As DataTable

        If frmOpenByFilter.clbRecipient.CheckedItems.Count = 0 Then
            MessageBox.Show("You didn't select any Recipients, so this filter will not be used.")
            Return dtInput
        End If

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports
        Dim dt As DataTable
        Dim dtMerge As DataTable = Nothing
        Dim colDelete As Collection = New Collection
        Dim foundRows() As DataRow
        comExport.CommandText = "Select RecordExport.* from RecordExport inner join ExportRecipient on RecordExport.ExportID = ExportRecipient.ExportID where ExportRecipient.RecipientID = ?"
        comExport.Parameters.AddWithValue("RecipientID", Nothing)

        For Each row As DataRowView In frmOpenByFilter.clbRecipient.CheckedItems

            comExport.Parameters("RecipientID").Value = row("RecipientID")

            Dim odba As SQLiteDataAdapter
            odba = New SQLiteDataAdapter(comExport)
            dt = New DataTable()
            odba.Fill(dt)

            If dtMerge Is Nothing Then
                dtMerge = dt
            Else
                dtMerge.Merge(dt)
            End If
        Next
        dtMerge = dtMerge.DefaultView.ToTable(True)

        Dim bExportedTo As Boolean = (frmOpenByFilter.cbRecipientFilterType.Text = "Records exported to")

        Dim dtRow As DataRow
        For Each dtRow In dtInput.Rows

            foundRows = dtMerge.Select("RecordID = " & dtRow("ID"))
            If foundRows.Length = 0 And bExportedTo Then
                colDelete.Add(dtRow)
            ElseIf foundRows.Length > 0 And Not bExportedTo Then
                colDelete.Add(dtRow)
            End If
        Next

        For Each dtRow In colDelete
            dtInput.Rows.Remove(dtRow)
        Next

        Return dtInput
    End Function

    Private Function FilterByPolygon(ByVal dtInput As DataTable) As DataTable

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()

        Dim poly As clsPolygon
        If frmOpenByFilter.BoundaryFile.ToLower.EndsWith("mif") Then
            poly = ReadPolyFromMIF(frmOpenByFilter.BoundaryFile)
        ElseIf frmOpenByFilter.BoundaryFile.ToLower.EndsWith("kml") Then
            poly = ReadPolyFromKML(frmOpenByFilter.BoundaryFile)
        Else
            poly = ReadPolyFromFile(frmOpenByFilter.BoundaryFile)
        End If

        If poly Is Nothing Then

            MessageBox.Show("Couldn't read the specified boundary file.")
        Else
            Dim bGROkay As Boolean
            Dim bIncludeRec As Boolean
            Dim pnt As PointF
            Dim colRowsRemove As Collection = New Collection
            Dim dtRow As DataRow
            For Each dtRow In dtInput.Rows

                bGROkay = False
                If IsDBNull(dtRow("GridRef")) Then
                    objGridRef.GridRef = ""
                Else
                    objGridRef.GridRef = dtRow("GridRef")
                    objGridRef.sErrorMessage = ""
                    objGridRef.ParseGridRef(True)
                    objGridRef.ParseInput(False)
                    If objGridRef.sErrorMessage = "" Then
                        bGROkay = True
                    End If
                End If

                bIncludeRec = False
                If bGROkay Then
                    pnt = New PointF(Convert.ToSingle(objGridRef.East), Convert.ToSingle(objGridRef.North))
                    If poly.PointInPolygon(pnt) Then
                        bIncludeRec = True
                    End If
                End If

                If frmOpenByFilter.rbWithoutBoundary.Checked Then
                    bIncludeRec = Not bIncludeRec
                End If

                If Not bIncludeRec Then
                    colRowsRemove.Add(dtRow)
                End If
            Next

            For Each dtRow In colRowsRemove
                dtInput.Rows.Remove(dtRow)
            Next
        End If
        Return dtInput
    End Function

    Private Function ReadPolyFromFile(ByVal sFile As String) As clsPolygon

        Dim sr As StreamReader = New StreamReader(sFile)
        Dim sLine As String
        Dim iPoints As Integer
        Dim iVertice As Integer = 0
        Dim Easting As Single
        Dim Northing As Single
        Dim sEastingNorthing() As String
        Dim strPoints As String = ""

        sLine = sr.ReadLine()
        Do While Not sr.EndOfStream
            iPoints += 1
            sLine = sr.ReadLine()
        Loop
        sr.Close()
        Dim poly(iPoints - 1) As PointF

        sr = New StreamReader(sFile)
        sLine = sr.ReadLine()
        Do While Not sr.EndOfStream

            If sLine.Trim <> "" Then
                sEastingNorthing = sLine.Split(" ")
                Easting = Convert.ToSingle(sEastingNorthing(0))
                Northing = Convert.ToSingle(sEastingNorthing(1))
                poly(iVertice) = New PointF(Easting, Northing)
                iVertice += 1
            End If
            sLine = sr.ReadLine()
        Loop

        'For i = 0 To iPoints - 1
        '    strPoints = strPoints & Math.Ceiling(poly(i).X) & "/" & Math.Ceiling(poly(i).Y).ToString & " "
        'Next
        'MessageBox.Show(strPoints)

        If iPoints > 3 Then
            Return New clsPolygon(poly)
        Else
            Return Nothing
        End If
    End Function

    Private Function ReadPolyFromKML(ByVal sFile As String) As clsPolygon

        Dim xmlDoc As New XmlDocument
        Dim ns As XmlNamespaceManager

        Try
            xmlDoc.Load(sFile)
        Catch ex As Exception
            MessageBox.Show("Could not open the KML file: " & ex.Message)
            Return Nothing
        End Try

        ns = New XmlNamespaceManager(xmlDoc.NameTable)
        ns.AddNamespace("gx", "http://www.google.com/kml/ext/2.2")
        ns.AddNamespace("kml", "http://www.opengis.net/kml/2.2")
        ns.AddNamespace("atom", "http://www.w3.org/2005/Atom")
        Dim root As XmlElement = xmlDoc.DocumentElement
        Dim xmlNodesPoly As XmlNodeList = root.SelectNodes("//kml:LinearRing/kml:coordinates", ns)

        If xmlNodesPoly.Count = 0 Then
            MessageBox.Show("No polygons found in the KML file.")
            Return Nothing
        ElseIf xmlNodesPoly.Count > 1 Then
            MessageBox.Show("More than one polygon found in the KML file. Create a KML file with one polygon.")
            Return Nothing
        End If

        Dim xmlNode As XmlNode = xmlNodesPoly(0)
        Dim vertices() As String = XmlNode.InnerText.Split(" ")

        Dim poly(0) As PointF
        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        Dim coords() As String
        Dim dblLon As Double
        Dim dblLat As Double
        Dim Easting As Single
        Dim Northing As Single

        Dim coordString As String

        Dim i As Integer
        Dim iVertices As Integer = 0

        For i = 0 To vertices.Length - 1

            coordString = vertices(i).Trim
            If coordString.Length > 0 Then

                coords = vertices(i).Split(",")
                dblLon = Convert.ToDouble(coords(0))
                dblLat = Convert.ToDouble(coords(1))
                Easting = objGridRef.LongWGS842Easting(dblLat, dblLon, 0)
                Northing = objGridRef.LatWGS842Northing(dblLat, dblLon, 0)
                ReDim Preserve poly(iVertices)
                poly(iVertices) = New PointF(Easting, Northing)
                iVertices += 1
            End If
        Next

        If iVertices > 2 Then
            Return New clsPolygon(poly)
        Else
            Return Nothing
        End If

    End Function

    Private Function ReadPolyFromMIF(ByVal sFile As String) As clsPolygon

        Dim sr As StreamReader = New StreamReader(sFile)
        Dim sLine As String = sr.ReadLine()
        Dim bStarted As Boolean = False
        Dim iPoints As Integer
        Dim iVertice As Integer = 0
        Dim Easting As Single
        Dim Northing As Single
        Dim sEastingNorthing() As String
        Dim poly(0) As PointF

        Do While Not sr.EndOfStream

            If bStarted Then

                If sLine.Trim.StartsWith("Pen") Or _
                    sLine.Trim.StartsWith("Brush") Or _
                    sLine.Trim.StartsWith("Center") Then
                    Exit Do
                Else
                    sEastingNorthing = sLine.Split(" ")
                    Easting = Convert.ToSingle(sEastingNorthing(0))
                    Northing = Convert.ToSingle(sEastingNorthing(1))
                    poly(iVertice) = New PointF(Easting, Northing)
                    iVertice += 1
                End If
            Else
                If sLine.Trim.StartsWith("Region") Then
                    iPoints = Convert.ToInt16(sr.ReadLine.Trim())
                    ReDim poly(iPoints)
                    bStarted = True
                End If
            End If

            sLine = sr.ReadLine()
        Loop

        If iPoints > 3 Then
            Return New clsPolygon(poly)
        Else
            Return Nothing
        End If

        'MessageBox.Show("points: " & iPoints.ToString)
    End Function

    Private Sub LoadGazetteerFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadGazetteerFileToolStripMenuItem.Click

        OpenFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 0

        If OpenFileDialog.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        If OpenFileDialog.FileName.ToLower.EndsWith("os50gaz.csv") Then
            LoadOS50Gaz(OpenFileDialog.FileName)
        Else
            LoadOSDistrictVectorGazFile(OpenFileDialog.FileName)
        End If

    End Sub

    Private Sub LoadOS50Gaz(ByVal strFile As String)

        Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim db As clsDB = New clsDB
        Dim comGaz As SQLiteCommand = New SQLiteCommand(db.conGazetteer)

        'Delete all existing etries in the table
        comGaz.CommandText = "Delete from os50kgaz"
        comGaz.ExecuteNonQuery()

        'Read the gazetteer CSV into a datatable
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            Dim field As String

            'Read the first row and make the columns from it and also
            'populate the fields checked listbox.
            currentRow = MyReader.ReadFields()
            For Each field In currentRow
                dt.Columns.Add(field)
            Next

            'Read the rest of the file and populate the data grid
            'currentRow = MyReader.ReadFields()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    dt.Rows.Add(currentRow)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Bad line: " & ex.Message)
                End Try
            End While
        End Using

        'Insert the records into the gazetteer table
        Using SQLtransaction As SQLite.SQLiteTransaction = db.conGazetteer.BeginTransaction()
            Using comGaz

                comGaz.CommandText = "Insert into os50kgaz (SEQ, DEF_NAM, NORTH, EAST, F_CODE) values (?,?,?,?,?)"

                Dim paramSEQ As New SQLiteParameter("SEQ", DbType.Int32)
                comGaz.Parameters.Add(paramSEQ)
                Dim paramDEF_NAM As New SQLiteParameter("DEF_NAM", DbType.String)
                comGaz.Parameters.Add(paramDEF_NAM)
                Dim paramNORTH As New SQLiteParameter("NORTH", DbType.Double)
                comGaz.Parameters.Add(paramNORTH)
                Dim paramEAST As New SQLiteParameter("EAST", DbType.Double)
                comGaz.Parameters.Add(paramEAST)
                Dim paramF_CODE As New SQLiteParameter("F_CODE", DbType.String)
                comGaz.Parameters.Add(paramF_CODE)

                Dim row As DataRow
                For Each row In dt.Rows

                    paramSEQ.Value = Convert.ToInt32(row("SEQ"))
                    paramDEF_NAM.Value = row("DEF_NAM")
                    paramNORTH.Value = Convert.ToDouble(row("NORTH"))
                    paramEAST.Value = Convert.ToDouble(row("EAST"))
                    paramF_CODE.Value = row("F_CODE")

                    'Do the DB update
                    comGaz.ExecuteNonQuery()
                Next
            End Using

            SQLtransaction.Commit()
        End Using

        comGaz.Dispose()
        db.Dispose()

        Cursor = Cursors.Arrow
    End Sub

    Private Sub LoadOSDistrictVectorGazFile(ByVal strFile As String)

        Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim db As clsDB = New clsDB
        Dim comGaz As SQLiteCommand = New SQLiteCommand(db.conGazetteer)

        'Delete all existing grid references that are within the GR square specified
        'by the filename (so long as type = D or null
        Dim strSquare As String = Path.GetFileName(strFile).Substring(0, 2)
        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        objGridRef.sErrorMessage = ""
        objGridRef.GridRef = strSquare
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage.Length = 0 Then

            Dim llx As Integer = objGridRef.East - objGridRef.fWidth
            Dim urx As Integer = objGridRef.East + objGridRef.fWidth
            Dim lly As Integer = objGridRef.North - objGridRef.fWidth
            Dim ury As Integer = objGridRef.North + objGridRef.fWidth

            comGaz.CommandText = "Delete from osDistrictVectorGaz where (Type = 'D' or Type is NULL) and " & _
                 "X >= " & llx & " and X <= " & urx & " and Y >= " & lly & " and Y <= " & ury
            comGaz.ExecuteNonQuery()
        End If

        'Read the gazetteer CSV into a datatable
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            Dim field As String

            'Read the first row and make the columns from it and also
            'populate the fields checked listbox.
            currentRow = MyReader.ReadFields()
            For Each field In currentRow
                dt.Columns.Add(field)
            Next

            'Read the rest of the file and populate the data grid
            'currentRow = MyReader.ReadFields()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    dt.Rows.Add(currentRow)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Bad line: " & ex.Message)
                End Try
            End While
        End Using

        'Insert the records into the gazetteer table
        Using SQLtransaction As SQLite.SQLiteTransaction = db.conGazetteer.BeginTransaction()
            Using comGaz

                comGaz.CommandText = "Insert into osDistrictVectorGaz (X,Y,Name) values (?,?,?)"

                Dim paramX As New SQLiteParameter("X", DbType.Double)
                comGaz.Parameters.Add(paramX)
                Dim paramY As New SQLiteParameter("Y", DbType.Double)
                comGaz.Parameters.Add(paramY)
                Dim paramName As New SQLiteParameter("Name", DbType.String)
                comGaz.Parameters.Add(paramName)

                Dim row As DataRow
                For Each row In dt.Rows

                    paramX.Value = Convert.ToDouble(row("X"))
                    paramY.Value = Convert.ToDouble(row("Y"))
                    paramName.Value = row("NAME")

                    'Do the DB update
                    comGaz.ExecuteNonQuery()
                Next
            End Using

            SQLtransaction.Commit()
        End Using

        comGaz.Dispose()
        db.Dispose()

        Cursor = Cursors.Arrow
    End Sub

    Private Sub CreateEmptyDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateEmptyDatabaseToolStripMenuItem.Click

        frmConvertDB.InitialiseFormFields()
        frmConvertDB.V2DB(False)
    End Sub

    Private Sub Version10To11ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version10To11ToolStripMenuItem1.Click

        Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable()
        Dim MyConnection As OleDbConnection
        MyConnection = New OleDbConnection("Provider=Microsoft.jet.oledb.4.0;data source=" & frmOptions.txtDB.Text)

        Try
            MyConnection.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 DB (ensure DB is correctly set in options): " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Dim strSQL As String = "select count(Voice) from records"
        Dim mySQL As OleDbCommand = New OleDbCommand(strSQL, MyConnection)

        Try
            mySQL.ExecuteScalar().ToString()
        Catch
            MessageBox.Show("It looks like conversion has already been run on this database.")
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        strSQL = "select ID, Lon, Voice from records"
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter(strSQL, MyConnection)

        Try
            MyCommand.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Record selection query failed: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Dim dtRow As DataRow
        Dim arr() As Byte
        Dim intID As Integer

        For Each dtRow In dt.Rows
            intID = dtRow("ID")

            If Not cfun.HasNoValue(dtRow("Voice")) Then
                arr = dtRow("Voice")
                If arr.Length.ToString <> 6819 Then

                    cfun.SaveRecordWav(arr, intID, 1)
                End If
            End If
        Next

        'Now delete the Voice row from the DB.

        strSQL = "Alter table records drop column Voice"
        mySQL.CommandText = strSQL
        Try
            mySQL.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Failed to drop column 'Voice' from DB: " & ex.Message)
        End Try

        MyConnection.Close()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub OpenByFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenByFilterToolStripMenuItem.Click

        frmOpenByFilter.ShowDialog()

        'Quit if dialog cancelled
        If Not frmOpenByFilter.Okayed Then
            Exit Sub
        End If

        'Quit if filter records is selected, but no filters specified
        If frmOpenByFilter.rbFilteredRecords.Checked And _
            frmOpenByFilter.SQL = "" And frmOpenByFilter.BoundaryFile = "" And _
            frmOpenByFilter.RecipientType = "" And frmOpenByFilter.ExportType = "" Then

            Exit Sub
        End If

        'Delete temporary records 
        DeleteTemporaryRecords()

        'Do initial selection of records from the DB
        Dim strSQL As String
        If frmOpenByFilter.SQL <> "" Then
            strSQL = "select * from records where " & frmOpenByFilter.SQL
        Else
            strSQL = "select * from records"
        End If
        Dim dtInput As DataTable = OpenBySQL(strSQL)

        'Do the filtering
        If Not dtInput Is Nothing Then

            'Filter by Polygon
            If Not frmOpenByFilter.BoundaryFile = "" Then
                dtInput = FilterByPolygon(dtInput)
            End If

            'Filter by export filters
            If Not frmOpenByFilter.ExportType = "" Then
                dtInput = FilterByExport(dtInput)
            End If

            'Filter by recipient filters
            If Not frmOpenByFilter.RecipientType = "" Then
                dtInput = FilterByRecipient(dtInput)
            End If

            'Filter by record validiity
            If Not frmOpenByFilter.cbIncludeInvalid.Checked Then
                dtInput = FilterByValidity(dtInput)
            End If
        End If

        DisplayOpenedRecords(dtInput)

        'If the graph tab is displayed, then generate graphs
        If TabControl1.SelectedIndex = 1 Then
            MakeGraphs()
        End If
    End Sub



    Private Sub ResetLocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLocationsToolStripMenuItem.Click

        If MessageBox.Show("Are you sure that you want to reset the Location field of all currently open records from the gazeteer?", "Confirm action", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            ResetCalculatedLocations(True)
        End If
    End Sub

    Private Sub OpenEvernoteNotebookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenEvernoteNotebookToolStripMenuItem.Click


        MessageBox.Show("Direct connection to Evernote has been disabled. Instead, export notes from Evernote Desktop as ENEX format and then use Gilbert 21 File->Open files to import them.")

        'Cursor = Cursors.WaitCursor

        'bLoading = True

        'CheckForUnsavedRecords()
        'dgvRecords.Rows.Clear()
        'DeleteTemporaryRecords()

        'Dim str() As String = {"file.evernote"}
        'LoadFiles(str)

        'TabControl1.SelectedTab = TabControl1.TabPages("tabRecords")

        'bLoading = False

        'Cursor = Cursors.Arrow
    End Sub

    'Private Sub MICreate(ByVal sFile As String, ByVal sTaxon As String)

    '    Cursor = Cursors.WaitCursor

    '    Dim sThisTaxon As String = ""
    '    Dim sLine As String
    '    Dim iCols As Integer = 0
    '    Dim row As DataGridViewRow
    '    Dim col As DataGridViewColumn
    '    Dim dtRow As DataRow
    '    Dim strAttrValue As String
    '    Dim sField As String
    '    Dim sLabel As String
    '    Dim lvi As ListViewItem
    '    Dim sLLX As String
    '    Dim sLLY As String
    '    Dim sURX As String
    '    Dim sURY As String
    '    Dim iColour As Integer
    '    Dim colour As Color
    '    Dim htMIFieldLengths As Hashtable = New Hashtable
    '    Dim iLength As Integer
    '    Dim objGridRef As GridRef = New GridRef
    '    objGridRef.MakePrefixArrays()

    '    Dim sName As String
    '    If sTaxon = "" Then
    '        sName = sFile
    '    Else
    '        sName = sFile.Substring(0, sFile.Length - 4) & "-" & sTaxon.Replace(" ", "-") & ".mif"
    '    End If
    '    Dim swMIF As StreamWriter = New StreamWriter(sName)
    '    Dim sMidFile As String = sName.Substring(0, sName.Length - 3) & "mid"
    '    Dim swMID As StreamWriter = New StreamWriter(sMidFile)

    '    Dim htStyleColours As Hashtable = New Hashtable

    '    htStyleColours.Add("100km", butStyle100km.BackColor)
    '    htStyleColours.Add("hectad", butStyle10km.BackColor)
    '    htStyleColours.Add("qadrant", butStyle5km.BackColor)
    '    htStyleColours.Add("tetrad", butStyle2km.BackColor)
    '    htStyleColours.Add("monad", butStyle1km.BackColor)
    '    htStyleColours.Add("6fig", butStyle100m.BackColor)
    '    htStyleColours.Add("8fig", butStyle10m.BackColor)
    '    htStyleColours.Add("10fig", butStyle10m.BackColor)

    '    For Each lvi In lvOutputFields.Items
    '        iCols = iCols + 1
    '    Next

    '    'Create the MapInfo MIF header
    '    swMIF.WriteLine("Version 300")
    '    swMIF.WriteLine("Charset ""WindowsLatin1""")
    '    swMIF.WriteLine("Delimiter "",""")
    '    swMIF.WriteLine("CoordSys Earth Projection 8, 79, ""m"", -2, 49, 0.9996012717, 400000, -100000 Bounds (-7845061.1011, -15524202.1641) (8645061.1011, 4470074.53373)")
    '    swMIF.WriteLine("Columns " & iCols.ToString())

    '    'Populate hashtable with name of fields for export

    '    For Each col In dgvRecords.Columns
    '        If col.Visible Then
    '            htMIFieldLengths.Add(col.Name, 0)
    '        End If
    '    Next

    '    Dim row As DataGridViewRow
    '    For Each row In dgvRecords.Rows

    '        For Each lvi In lvOutputFields.Items
    '            sField = lvi.SubItems(1).Text
    '            iLength = dtRow.Item(sField).ToString().Length
    '            If iLength > htMIFieldLengths(sField) Then
    '                htMIFieldLengths(sField) = iLength
    '            End If
    '        Next
    '    Next

    '    For Each lvi In lvOutputFields.Items
    '        sField = lvi.SubItems(1).Text
    '        sLabel = lvi.SubItems(0).Text
    '        'Strip illegal characters from attribute names
    '        sLabel = sLabel.Replace(" ", "")
    '        sLabel = sLabel.Replace(")", "")
    '        sLabel = sLabel.Replace("(", "")
    '        sLabel = sLabel.Replace("-", "")
    '        swMIF.WriteLine(sLabel & " Char(" & htMIFieldLengths(sField).ToString() & ")")
    '    Next

    '    swMIF.WriteLine("Data")

    '    MessageBox.Show("Rows: " & dtProcessed.Rows.Count.ToString())

    '    For Each dtRow In dtProcessed.Rows

    '        If sTaxon <> "" Then
    '            sThisTaxon = dtRow.Item(outCols.ColName(cbTaxonField.Text))
    '        End If

    '        If sTaxon = sThisTaxon Then

    '            objGridRef.sErrorMessage = ""
    '            objGridRef.GridRef = dtRow.Item(outCols.ColName(cbGridRefField.Text))
    '            objGridRef.ParseGridRef(True)
    '            If objGridRef.sErrorMessage = "" Then
    '                objGridRef.ParseInput(False)

    '                sLLX = (Convert.ToInt32(objGridRef.East - objGridRef.fWidth)).ToString()
    '                sURX = (Convert.ToInt32(objGridRef.East + objGridRef.fWidth)).ToString()
    '                sLLY = (Convert.ToInt32(objGridRef.North - objGridRef.fWidth)).ToString()
    '                sURY = (Convert.ToInt32(objGridRef.North + objGridRef.fWidth)).ToString()

    '                colour = htStyleColours(objGridRef.sRefType)
    '                'MI encodes colour according to formula (red*65536) + (green * 256) + blue
    '                iColour = (colour.R * 65536) + (colour.G * 256) + colour.B

    '                If rbSquaresAndPoints.Checked Or rbSquaresOnly.Checked Then
    '                    swMIF.WriteLine("Region 1")
    '                    swMIF.WriteLine("5")
    '                    swMIF.WriteLine(sLLX & " " & sLLY)
    '                    swMIF.WriteLine(sLLX & " " & sURY)
    '                    swMIF.WriteLine(sURX & " " & sURY)
    '                    swMIF.WriteLine(sURX & " " & sLLY)
    '                    swMIF.WriteLine(sLLX & " " & sLLY)
    '                    swMIF.WriteLine("Pen(3, 2," & iColour.ToString() & ")")
    '                    swMIF.WriteLine("Brush(1, 0," & iColour.ToString() & ")")
    '                End If

    '                If rbPointsOnly.Checked Or rbSquaresAndPoints.Checked Then
    '                    swMIF.WriteLine("Point " & objGridRef.East.ToString() & " " & objGridRef.North.ToString())
    '                End If
    '                'Symbol(33, 255, 18)

    '                'Attributes
    '                sLine = ""
    '                For Each lvi In lvOutputFields.Items

    '                    sField = lvi.SubItems(1).Text
    '                    'There are a maximum of 254 characters for MI attributes
    '                    strAttrValue = dtRow.Item(sField).ToString().Replace("""", "")
    '                    strAttrValue = strAttrValue.Replace(vbCrLf, "")
    '                    strAttrValue = strAttrValue.Replace(vbCr, "")
    '                    strAttrValue = strAttrValue.Replace(vbLf, "")

    '                    If strAttrValue.Length > 254 Then
    '                        strAttrValue = strAttrValue.Substring(0, 254)
    '                    End If
    '                    If sLine <> "" Then
    '                        sLine = sLine & ","
    '                    End If
    '                    sLine = sLine & """" & strAttrValue & """"
    '                Next

    '                swMID.WriteLine(sLine)
    '                If rbSquaresAndPoints.Checked Then
    '                    swMID.WriteLine(sLine)
    '                End If
    '            End If
    '        End If
    '    Next

    '    swMIF.Close()
    '    swMID.Close()

    '    Cursor = Cursors.Arrow
    'End Sub

    Private Sub ManageRecipientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageRecipientsToolStripMenuItem.Click

        frmExportManageRecipients.ShowDialog()
    End Sub

    Private Sub ManageExportHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageExportHistoryToolStripMenuItem.Click

        frmExportsManage.ShowDialog()
    End Sub

    Private Sub tsbRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRemove.Click

        If dgvRecords.SelectedRows.Count = 0 Then

            MessageBox.Show("No rows selected for removal from display.")
        Else
            For Each row In dgvRecords.SelectedRows
                dgvRecords.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub MakeGraphs()

        If dgvRecords.RowCount = 0 Then
            Chart1.Visible = False
            Exit Sub
        End If

        Chart1.ChartAreas.Clear()
        Chart1.Series.Clear()
        Chart1.Legends.Clear()

        Dim dte As Date
        Dim intYear As Integer
        Dim intMinYear As Integer = 9999
        Dim intMaxYear As Integer = 0
        Dim row As DataGridViewRow
        Dim colTaxa As Collection = New Collection
        Dim strTaxon As String
        Dim bTaxonValid As Boolean

        'Get min and max year and collection of taxa
        For Each row In dgvRecords.Rows
            If Not cfun.HasNoValue(row.Cells("Date").Value) Then

                'Record date
                Try
                    dte = DateTime.Parse(row.Cells("Date").Value)
                    intYear = Year(dte)
                Catch ex As Exception
                    Continue For
                End Try

                If intYear <= nudMaxYear.Value And intYear >= nudMinYear.Value Then
                    If intYear > intMaxYear Then
                        intMaxYear = intYear
                    End If
                    If intYear < intMinYear Then
                        intMinYear = intYear
                    End If
                End If

                'Taxa collection
                If chkCommon.Checked Then
                    bTaxonValid = Not cfun.HasNoValue(row.Cells("CommonName"))
                Else
                    bTaxonValid = Not cfun.HasNoValue(row.Cells("ScientificName"))
                End If
                If bTaxonValid Then

                    If chkCommon.Checked Then
                        strTaxon = row.Cells("CommonName").Value
                    Else
                        strTaxon = row.Cells("ScientificName").Value
                    End If

                    If Not colTaxa.Contains(strTaxon) Then
                        colTaxa.Add(strTaxon, strTaxon)
                    End If
                End If
            End If
        Next

        If rbYear.Checked Then
            'Organise graphs by year
            If cbYearsPerGraph.Text = "All" Then
                MakeGraph(intMinYear, intMaxYear)
            Else
                Dim intInterval As Integer = Val(cbYearsPerGraph.Text)
                For intYear = intMaxYear To intMinYear - 1 Step (0 - intInterval)
                    If Not intYear < intMinYear Then
                        MakeGraph(intYear - intInterval + 1, intYear)
                    End If
                Next
            End If
        Else
            'Organise graphs by taxa
            For Each strTaxon In colTaxa
                MakeGraphSpecies(intMinYear, intMaxYear, strTaxon)
            Next
        End If

        'Equalise axes if necessary
        EqualiseYaxes()

        'Adjust for empty graphs
        cbRemoveEmptyGraphs_CheckedChanged(Nothing, Nothing)

        'Chart colours
        Select Case cbChartColours.Text
            Case "Excel"
                Chart1.Palette = ChartColorPalette.Excel
            Case "Pastel"
                Chart1.Palette = ChartColorPalette.Pastel
            Case "Bright Pastel"
                Chart1.Palette = ChartColorPalette.BrightPastel
            Case "Bright"
                Chart1.Palette = ChartColorPalette.Bright
            Case "Earth Tones"
                Chart1.Palette = ChartColorPalette.EarthTones
            Case "Chocolate"
                Chart1.Palette = ChartColorPalette.Chocolate
            Case "Fire"
                Chart1.Palette = ChartColorPalette.Fire
            Case "Sea Green"
                Chart1.Palette = ChartColorPalette.SeaGreen
            Case Else
                Chart1.Palette = ChartColorPalette.Berry
        End Select

        'Make sure the chart is visible (hidden when first starts)
        Chart1.Visible = True
    End Sub

    Private Sub MakeGraph(intYearStart As Integer, intYearEnd As Integer)

        Dim intDayGrp As Integer = nudDayGrp.Value
        Dim intClasses As Integer
        Dim dte As Date
        Dim dte1 As Date
        Dim dte2 As Date
        Dim intClass As Integer
        Dim row As DataGridViewRow
        Dim intYear As Integer
        Dim intMaxDays As Integer
        Dim intDays As Integer
        Dim intAbundance As Integer
        Dim strLabel As String

        'The 'origin' date is set to the end day before the start of the year 2000, which is
        'a leap year. This helps us to convert any date from any year, to the equivalent number
        'of days into a leap year.
        Dim dte0 As Date = DateTime.Parse("31/12/1999")

        'Set the intMaxDays variable which for all years except this one will be 366. For this
        'year it should go up to current date. This prevents generation of points beyond current
        'date.
        Dim bThisYear As Boolean = (intYearEnd = intYearStart) And (Year(Today) = intYearEnd)
        If bThisYear Then
            dte1 = DateTime.Parse(Format(Today, "dd") & "/" & Format(Today, "MM") & "/2000")
            intMaxDays = DateDiff(DateInterval.Day, dte0, dte1)
        Else
            intMaxDays = 366
        End If

        'Set the number of classes for the year based on the size of the class in days
        'set by the user and the intMaxDays variable.
        intClasses = intMaxDays \ intDayGrp
        If intMaxDays Mod intDayGrp > 0 Then
            intClasses += 1
        End If
        Dim intY(intClasses - 1) As Integer

        For Each row In dgvRecords.Rows
            If Not cfun.HasNoValue(row.Cells("Date")) Then

                'Record date
                Try
                    dte = DateTime.Parse(row.Cells("Date").Value)
                    intYear = Year(dte)
                Catch ex As Exception
                    Continue For
                End Try

                'Only process record if its year falls within the ranges passed to the function
                If intYear >= intYearStart And intYear <= intYearEnd Then

                    'Work out the number of days into the year that this record falls on. This is the
                    'number of days into a leap year, so if this is a non leap year, then we need to
                    'take account of this and adjust. Do this by swapping year - whatever it is - to
                    'the year 2000.
                    dte1 = Date.Parse(Format(dte, "dd/MM/2000"))
                    intDays = DateDiff(DateInterval.Day, dte0, dte1)

                    'Work out the abundance for this record which can be 1 if user has set option
                    'to count records rather than add abundances. Otherwise try to discern abundance
                    'and use that instead.
                    If rbCountRecs.Checked Then
                        intAbundance = 1
                    Else
                        If cfun.HasNoValue(row.Cells("Abundance")) Then
                            intAbundance = 1
                        Else
                            intAbundance = Val(row.Cells("Abundance").Value)
                            If intAbundance = 0 Then
                                'If not abundance recorded, then assume 1.
                                intAbundance = 1
                            End If
                        End If
                    End If

                    'Determine which class this record falls into and update the abundance value
                    intClass = intDays \ intDayGrp
                    If intClass >= intClasses Then
                        intClass = intClasses - 1
                    End If
                    intY(intClass) += intAbundance
                End If
            End If
        Next

        'Set the name of the chart area and series
        Dim strChart As String
        If intYearStart = intYearEnd Then
            strChart = intYearStart.ToString
        Else
            strChart = intYearStart.ToString & "-" & intYearEnd.ToString
        End If

        'Create the new chart series
        Dim ser As Series = Chart1.Series.Add(strChart)

        'Create the new chart area and legend
        Dim area As ChartArea
        Dim leg As Legend
        If cbSuperimpose.Checked And Chart1.ChartAreas.Count = 1 Then
            'Charts are being superimposed, so use the existing area and legend
            area = Chart1.ChartAreas(0)
            leg = Chart1.Legends(0)
        Else
            'Create the new chart area and legend
            area = Chart1.ChartAreas.Add(strChart)
            leg = Chart1.Legends.Add(strChart)
            ser.Legend = strChart
        End If

        'Associate chart area with series
        ser.ChartArea = area.Name

        'Position the legend
        leg.DockedToChartArea = area.Name
        leg.IsDockedInsideChartArea = False

        'Chart type
        Select Case cbChartType.Text

            Case "Histogram"
                ser.ChartType = SeriesChartType.Column
                area.AlignmentOrientation = AreaAlignmentOrientations.Vertical
                ser.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=1"
            Case Else
                ser.ChartType = SeriesChartType.Spline
                ser.MarkerStyle = MarkerStyle.Diamond
                ser.MarkerSize = 10
                ser.MarkerBorderColor = Color.White
                ser.MarkerBorderWidth = 1
                ser.BorderWidth = 2
        End Select

        'area.Area3DStyle.Enable3D = True

        'Set the series values
        For i = 0 To intClasses - 1

            'Set dte1 and dte2 to start and end date for the class interval
            dte1 = DateAdd(DateInterval.Day, intDayGrp * i + 1, dte0)
            intDays = intDayGrp * (i + 1)
            If intDays > intMaxDays Then
                intDays = intMaxDays
            End If
            dte2 = DateAdd(DateInterval.Day, intDays, dte0)

            If dte1 = dte2 Then
                'One day class interval
                strLabel = Format(dte1, "d MMM")
            Else
                strLabel = Format(dte1, "d MMM") & " - " & Format(dte2, "d MMM")
            End If

            'X value of class is set to mid-point of class interval
            ser.Points.AddXY((i + 1) * intDayGrp - (intDayGrp / 2), intY(i))
            ser.Points(i).ToolTip = strLabel
        Next

        'Style X axis (removing grid, ticks and labels)
        area.AxisX.MajorTickMark.Enabled = False
        area.AxisX.LabelStyle.Enabled = False
        area.AxisX.MajorGrid.Enabled = False
        area.AxisX.Maximum = 366 'Set size of x axis

        'Style Y axis grid
        area.AxisY.MajorGrid.Enabled = True
        area.AxisY.MajorTickMark.Enabled = False
        area.AxisY.MajorGrid.LineColor = Color.FromArgb(190, 190, 190)
        area.AxisY.MajorGrid.LineWidth = 2
        area.AxisY.LineColor = Color.Transparent 'Hide Y axis line

        'Allow zooming on x-axis
        area.CursorX.IsUserSelectionEnabled = True
        area.AxisX.ScaleView.Zoomable = True

        'Colour the background of chart area to show months
        MarkupChartBackground(area)
    End Sub

    Private Sub MakeGraphSpecies(intYearStart As Integer, intYearEnd As Integer, strTaxon As String)

        Dim intDayGrp As Integer = nudDayGrp.Value
        Dim intClasses As Integer
        Dim dte As Date
        Dim dte1 As Date
        Dim dte2 As Date
        Dim intClass As Integer
        Dim row As DataGridViewRow
        Dim intYear As Integer
        Dim intMaxDays As Integer
        Dim intDays As Integer
        Dim intAbundance As Integer
        Dim strLabel As String
        Dim strRowTaxon As String

        'The 'origin' date is set to the end day before the start of the year 2000, which is
        'a leap year. This helps us to convert any date from any year, to the equivalent number
        'of days into a leap year.
        Dim dte0 As Date = DateTime.Parse("31/12/1999")

        'Set the intMaxDays variable which for all years except this one will be 366. For this
        'year it should go up to current date. This prevents generation of points beyond current
        'date.
        Dim bThisYear As Boolean = (intYearEnd = intYearStart) And (Year(Today) = intYearEnd)
        If bThisYear Then
            dte1 = DateTime.Parse(Format(Today, "dd") & "/" & Format(Today, "MM") & "/2000")
            intMaxDays = DateDiff(DateInterval.Day, dte0, dte1)
        Else
            intMaxDays = 366
        End If

        'Set the number of classes for the year based on the size of the class in days
        'set by the user and the intMaxDays variable.
        intClasses = intMaxDays \ intDayGrp
        If intMaxDays Mod intDayGrp > 0 Then
            intClasses += 1
        End If
        Dim intY(intClasses - 1) As Integer

        For Each row In dgvRecords.Rows
            If Not cfun.HasNoValue(row.Cells("Date")) And Not cfun.HasNoValue(row.Cells("ScientificName")) Then

                If chkCommon.Checked Then
                    strRowTaxon = row.Cells("CommonName").Value
                Else
                    strRowTaxon = row.Cells("ScientificName").Value
                End If

                If strRowTaxon = strTaxon Then
                    'Record date
                    dte = DateTime.Parse(row.Cells("Date").Value)
                    intYear = Year(dte)

                    'Only process record if its year falls within the ranges passed to the function
                    If intYear >= intYearStart And intYear <= intYearEnd Then

                        'Work out the number of days into the year that this record falls on. This is the
                        'number of days into a leap year, so if this is a non leap year, then we need to
                        'take account of this and adjust. Do this by swapping year - whatever it is - to
                        'the year 2000.
                        dte1 = Date.Parse(Format(dte, "dd/MM/2000"))
                        intDays = DateDiff(DateInterval.Day, dte0, dte1)

                        'Work out the abundance for this record which can be 1 if user has set option
                        'to count records rather than add abundances. Otherwise try to discern abundance
                        'and use that instead.
                        If rbCountRecs.Checked Then
                            intAbundance = 1
                        Else
                            If cfun.HasNoValue(row.Cells("Abundance")) Then
                                intAbundance = 1
                            Else
                                intAbundance = Val(row.Cells("Abundance").Value)
                                If intAbundance = 0 Then
                                    'If not abundance recorded, then assume 1.
                                    intAbundance = 1
                                End If
                            End If
                        End If

                        'Determine which class this record falls into and update the abundance value
                        intClass = intDays \ intDayGrp
                        If intClass >= intClasses Then
                            intClass = intClasses - 1
                        End If
                        intY(intClass) += intAbundance
                    End If
                End If
            End If
        Next

        'Set the name of the chart area and series
        Dim strChart As String = strTaxon

        'Create the new chart series
        Dim ser As Series = Chart1.Series.Add(strChart)

        'Create the new chart area and legend
        Dim area As ChartArea
        Dim leg As Legend
        If cbSuperimpose.Checked And Chart1.ChartAreas.Count = 1 Then
            'Charts are being superimposed, so use the existing area and legend
            area = Chart1.ChartAreas(0)
            leg = Chart1.Legends(0)
        Else
            'Create the new chart area and legend
            area = Chart1.ChartAreas.Add(strChart)
            leg = Chart1.Legends.Add(strChart)
            ser.Legend = strChart
        End If

        'Associate chart area with series
        ser.ChartArea = area.Name

        'Position the legend
        leg.DockedToChartArea = area.Name
        leg.IsDockedInsideChartArea = False

        'Chart type
        Select Case cbChartType.Text

            Case "Histogram"
                ser.ChartType = SeriesChartType.Column
                area.AlignmentOrientation = AreaAlignmentOrientations.Vertical
                ser.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=1"
            Case Else
                ser.ChartType = SeriesChartType.Spline
                ser.MarkerStyle = MarkerStyle.Diamond
                ser.MarkerSize = 10
                ser.MarkerBorderColor = Color.White
                ser.MarkerBorderWidth = 1
                ser.BorderWidth = 2
        End Select

        'area.Area3DStyle.Enable3D = True

        'Set the series values
        For i = 0 To intClasses - 1

            'Set dte1 and dte2 to start and end date for the class interval
            dte1 = DateAdd(DateInterval.Day, intDayGrp * i + 1, dte0)
            intDays = intDayGrp * (i + 1)
            If intDays > intMaxDays Then
                intDays = intMaxDays
            End If
            dte2 = DateAdd(DateInterval.Day, intDays, dte0)

            If dte1 = dte2 Then
                'One day class interval
                strLabel = Format(dte1, "d MMM")
            Else
                strLabel = Format(dte1, "d MMM") & " - " & Format(dte2, "d MMM")
            End If

            'X value of class is set to mid-point of class interval
            ser.Points.AddXY((i + 1) * intDayGrp - (intDayGrp / 2), intY(i))
            ser.Points(i).ToolTip = strLabel
        Next

        'Style X axis (removing grid, ticks and labels)
        area.AxisX.MajorTickMark.Enabled = False
        area.AxisX.LabelStyle.Enabled = False
        area.AxisX.MajorGrid.Enabled = False
        area.AxisX.Maximum = 366 'Set size of x axis

        'Style Y axis grid
        area.AxisY.MajorGrid.Enabled = True
        area.AxisY.MajorTickMark.Enabled = False
        area.AxisY.MajorGrid.LineColor = Color.FromArgb(190, 190, 190)
        area.AxisY.MajorGrid.LineWidth = 2
        area.AxisY.LineColor = Color.Transparent 'Hide Y axis line

        'Allow zooming on x-axis
        area.CursorX.IsUserSelectionEnabled = True
        area.AxisX.ScaleView.Zoomable = True

        'Colour the background of chart area to show months
        MarkupChartBackground(area)
    End Sub

    Private Sub MarkupChartBackground(area As ChartArea)

        Dim colMonths As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        colMonths.Add("Jan", 31)
        colMonths.Add("Feb", 29)
        colMonths.Add("Mar", 31)
        colMonths.Add("Apr", 30)
        colMonths.Add("May", 31)
        colMonths.Add("Jun", 30)
        colMonths.Add("Jul", 31)
        colMonths.Add("Aug", 31)
        colMonths.Add("Sep", 30)
        colMonths.Add("Oct", 31)
        colMonths.Add("Nov", 30)
        colMonths.Add("Dec", 31)

        Dim strMonth As String
        Dim intStripOffset As Integer = 0
        Dim intMonth As Integer = 0
        For Each strMonth In colMonths.Keys
            intMonth += 1
            Dim strip As StripLine = New StripLine()
            If intMonth Mod 2 = 0 Then
                strip.BackColor = Color.FromArgb(238, 245, 253)
            Else
                strip.BackColor = Color.FromArgb(229, 229, 229)
            End If
            strip.StripWidth = colMonths(strMonth)
            strip.IntervalOffset = intStripOffset
            intStripOffset += strip.StripWidth
            strip.Text = strMonth
            strip.TextAlignment = StringAlignment.Center
            strip.TextOrientation = TextOrientation.Horizontal

            area.AxisX.StripLines.Add(strip)
        Next
    End Sub
    Private Sub nudDayGrp_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudDayGrp.ValueChanged
        MakeGraphs()
    End Sub

    Private Sub rbCountRecs_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCountRecs.CheckedChanged
        MakeGraphs()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 1 Then

            SizeBlind(False)
            MakeGraphs()
        End If
    End Sub

    Private Sub cbYearsPerGraph_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbYearsPerGraph.SelectedIndexChanged
        MakeGraphs()
    End Sub

    Private Sub cbSuperimpose_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbSuperimpose.CheckedChanged
        MakeGraphs()
    End Sub

    Private Sub butBlind_Click(sender As System.Object, e As System.EventArgs) Handles butBlind.Click

        SizeBlind(True)
    End Sub

    Private Sub SizeBlind(bChange As Boolean)

        Dim bArrowDown As Boolean = True
        If butBlind.ImageIndex = 1 Then
            bArrowDown = False
        End If

        If Not bChange Then
            bArrowDown = Not bArrowDown
        End If

        If bArrowDown Then
            'Down
            butBlind.ImageIndex = 1

            Dim ctrl As Control
            Dim intMax As Integer = 0
            For Each ctrl In splitGraphs.Panel1.Controls

                If Not ctrl.Name = "butBlind" Then
                    If ctrl.Top + ctrl.Height > intMax Then
                        intMax = ctrl.Top + ctrl.Height
                    End If
                End If
            Next

            splitGraphs.SplitterDistance = intMax + 5
        Else
            'Up
            butBlind.ImageIndex = 0
            splitGraphs.SplitterDistance = 35
        End If

        butBlind.Top = splitGraphs.Panel1.Height - butBlind.Height - 5

        'Problem with anchoring on the Graph control, so do it manually
        Chart1.Left = 0
        Chart1.Top = 0
        Chart1.Width = splitGraphs.Panel2.Width
        Chart1.Height = splitGraphs.Panel2.Height
    End Sub

    Private Sub cbRemoveEmptyGraphs_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbRemoveEmptyGraphs.CheckedChanged

        Dim intGraph As Integer
        Dim dblY As Double
        Dim pnt As DataPoint

        If Not cbSuperimpose.Checked Then
            For intGraph = 0 To Chart1.Series.Count - 1

                dblY = 0
                For Each pnt In Chart1.Series(intGraph).Points
                    If pnt.YValues(0) > dblY Then
                        dblY = pnt.YValues(0)
                        Exit For
                    End If
                Next

                If dblY = 0 Then
                    Chart1.ChartAreas(intGraph).Visible = Not cbRemoveEmptyGraphs.Checked
                End If
            Next
        End If
    End Sub

    Private Sub EqualiseYaxes()

        Dim intGraph As Integer
        Dim dblY As Double = 0
        Dim intFact As Integer = 0
        Dim pnt As DataPoint

        If Chart1.ChartAreas.Count > 1 And cbEqualiseYaxes.Checked Then
            For intGraph = 0 To Chart1.Series.Count - 1

                For Each pnt In Chart1.Series(intGraph).Points
                    If pnt.YValues(0) > dblY Then
                        dblY = pnt.YValues(0)
                    End If
                Next
            Next

            If dblY < 5 Then
                intFact = 1
            ElseIf dblY < 15 Then
                intFact = 2
            ElseIf dblY < 50 Then
                intFact = 5
            ElseIf dblY < 100 Then
                intFact = 10
            ElseIf dblY < 200 Then
                intFact = 20
            ElseIf dblY < 500 Then
                intFact = 50
            Else
                intFact = 100
            End If

            dblY = (dblY \ intFact) * intFact + intFact

            For intGraph = 0 To Chart1.Series.Count - 1
                Chart1.ChartAreas(intGraph).AxisY.Maximum = dblY
                Chart1.ChartAreas(intGraph).AxisY.MajorGrid.Interval = intFact
            Next
        End If
    End Sub

    Private Sub cbEqualiseYaxes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbEqualiseYaxes.CheckedChanged

        MakeGraphs()
    End Sub

    Private Sub cbChartType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbChartType.SelectedIndexChanged

        MakeGraphs()
    End Sub

    Private Sub cbChartColours_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbChartColours.SelectedIndexChanged

        MakeGraphs()
    End Sub

    Private Sub nudMinYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudMinYear.ValueChanged

        MakeGraphs()
    End Sub

    Private Sub nudMaxYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudMaxYear.ValueChanged

        MakeGraphs()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

        tsbOptions_Click(Nothing, Nothing)
    End Sub

    Private Sub rbSpecies_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSpecies.CheckedChanged

        MakeGraphs()
        If rbSpecies.Checked Then
            cbYearsPerGraph.SelectedIndex = 0
            cbYearsPerGraph.Enabled = False
            chkCommon.Enabled = True
        Else
            cbYearsPerGraph.Enabled = True
            chkCommon.Enabled = False
        End If
    End Sub

    Private Sub chkCommon_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCommon.CheckedChanged

        MakeGraphs()
    End Sub

    Private Sub ExitGilbert21_Click(sender As System.Object, e As System.EventArgs) Handles ExitGilbert21.Click

        bAllowClose = True
        Me.Close()
    End Sub

    Private Sub G21Notify_BalloonTipClicked(sender As Object, e As System.EventArgs) Handles G21Notify.BalloonTipClicked

        bNotifyBalloonShowing = False
    End Sub

    Private Sub G21Notify_BalloonTipClosed(sender As Object, e As System.EventArgs) Handles G21Notify.BalloonTipClosed

        bNotifyBalloonShowing = False
    End Sub

    Private Sub G21Notify_BalloonTipShown(sender As Object, e As System.EventArgs) Handles G21Notify.BalloonTipShown

        bNotifyBalloonShowing = True
    End Sub
    Private Sub G21Notify_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles G21Notify.MouseMove

        If Not bNotifyBalloonShowing Then

            ShowNotifyMessage(True)
        End If
    End Sub

    Private Sub G21Notify_Click(sender As Object, e As System.EventArgs) Handles G21Notify.Click

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.G21Notify.Visible = False
    End Sub

    Private Sub timNotify_Tick(sender As System.Object, e As System.EventArgs) Handles timNotify.Tick

        If Me.WindowState = FormWindowState.Minimized And bWatchFolder Then

            ShowNotifyMessage(False)
        End If

    End Sub

    Private Sub ShowNotifyMessage(bShowIfNone As Boolean)

        If Directory.Exists(strImportFolder) Then
            Dim iCount As Integer = 0
            Dim fileEntries As String() = {}

            Try
                fileEntries = Directory.GetFiles(strImportFolder)
            Catch ex As Exception

            End Try

            Dim fileName As String

            For Each fileName In fileEntries

                If fileName.ToLower.EndsWith("wav") Or fileName.ToLower.EndsWith("3gp") Then

                    iCount += 1
                End If
            Next

            If iCount > 0 Or bShowIfNone Then
                Dim strMessage As String = iCount & " Gilbert 21 sound files are waiting to be processed in import folder."
                G21Notify.ShowBalloonTip(5000, "G21 Records waiting", strMessage, ToolTipIcon.Info)
            End If
        End If
    End Sub

    Private Sub tsbMoveDeleteFiles_Click(sender As System.Object, e As System.EventArgs) Handles tsbMoveDeleteFiles.Click

        Dim strFile As String
        Dim strFileTo As String

        If colInputAppSoundFiles.Count = 0 Then
            MessageBox.Show("Couldn't find G21 Android app sound files associated with open records.")
            Exit Sub
        End If

        If frmOptions.chkDelete.Checked Then
            'Delete the files
            If MessageBox.Show(colInputAppSoundFiles.Count & " G21 Android app sound files associated with displayed rows will be deleted. Are you sure you want to delete them?", "Confirm deletion", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then

                For Each strFile In colInputAppSoundFiles
                    Try
                        File.Delete(strFile)
                    Catch ex As Exception
                        MessageBox.Show("Couldn't delete file '" & strFile & "'.")
                    End Try
                Next
                colInputAppSoundFiles.Clear()
            End If
        Else
            'Move the files
            If Not Directory.Exists(frmOptions.txtProcessedFiles.Text) Then
                MessageBox.Show("The specified folder to which the sound files should be moved - '" & frmOptions.txtProcessedFiles.Text & "' - cannot be found.")
                Exit Sub
            End If

            If MessageBox.Show(colInputAppSoundFiles.Count & " G21 Android app sound files associated with displayed rows will be moved to the folder'" & frmOptions.txtProcessedFiles.Text & "'. Are you sure you want to move them?", "Confirm move", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                For Each strFile In colInputAppSoundFiles
                    strFileTo = Path.Combine(frmOptions.txtProcessedFiles.Text, Path.GetFileName(strFile))
                    Try
                        File.Move(strFile, strFileTo)
                    Catch ex As Exception
                        MessageBox.Show("Couldn't move file '" & strFile & "'.")
                    End Try
                Next
                colInputAppSoundFiles.Clear()
            End If
        End If
    End Sub
End Class



