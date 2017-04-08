Imports System.IO
Imports System.Data.SQLite
Imports System.Math
Imports System.Text.RegularExpressions

Public Class frmExport

    Private bOkayed As Boolean
    Private lstExcludeFromExport As List(Of String) = New List(Of String)

    Public Enum ExportType
        CSV
        MapMate
        GE
        MapInfo
        RODIS
        BirdTrackCasual
    End Enum

    Public ReadOnly Property Okayed() As Integer
        Get
            Return bOkayed
        End Get
    End Property

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click

        bOkayed = False
        Me.Close()
    End Sub

    Private Sub butCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCommit.Click

        If txtExportTitle.Text.Trim = "" Then
            MessageBox.Show("You must specify a title for this export.")
            Exit Sub
        End If

        If ddlExportType.Text = "" Then
            MessageBox.Show("You must specify an export type.")
            Exit Sub
        End If

        If chkBoxAppendGUID.Checked And Not frmMain.dgvRecords.Columns("Comment").Visible Then
            MessageBox.Show("You selected the option to append the GUID to the comment field, but the comment field is not visible (and therefore will not be exported).")
            Exit Sub
        End If

        If Not chkBoxAppendGUID.Checked And Not chkIncludeGUID.Checked Then
            If MessageBox.Show("You are not exporting global unique identifiers (GUID) with these records. Are you sure you want to continue?", "Confirm export with no GUID", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        'Any type specific pre-requisite checks?
        If ddlExportType.Text = "BirdTrack Casual" Then
            If Not frmOptions.txtBirdTrackUser.Text <> "" Then
                MessageBox.Show("You selected to export in BirdTrack casual record format. First you must specify your BTO BirdTrack UserID on the options form.")
                Exit Sub
            End If
        End If

        'Check that specified title isn't already used
        Dim intExportID As Integer = 0
        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        comExport.CommandText = "Select count(*) from exports where ShortTitle like '" & txtExportTitle.Text.Trim & "'"
        If comExport.ExecuteScalar() > 0 Then

            If ddlExportType.Text = "None" Then
                comExport.CommandText = "Select count(*) from exports where ShortTitle like '" & txtExportTitle.Text.Trim & "' and Type='None'"
                If comExport.ExecuteScalar() > 0 Then
                    If MessageBox.Show("An export record with this short title already exists. Do you want to append these records? (Notes and recipients will be ignored - you can maintain these through Manage Exports.)", "Append records", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    Else
                        comExport.CommandText = "Select ExportID from exports where ShortTitle like '" & txtExportTitle.Text.Trim & "' and Type='None'"
                        intExportID = comExport.ExecuteScalar
                    End If
                Else
                    'Short title used but not for an export of type none
                    MessageBox.Show("An export record (with a format other than 'None') with this short title already exists.")
                    Exit Sub
                End If
            Else
                MessageBox.Show("An export record with this short title already exists.")
                Exit Sub
            End If
        End If

        Dim cur As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor

        'Clear list of exported IDs
        lstExcludeFromExport.Clear()

        Dim bFileProduced As Boolean = False

        Dim bGUIDDisplayed As Boolean = frmMain.dgvRecords.Columns("GUID").Visible
        If chkIncludeGUID.Checked Then
            frmMain.dgvRecords.Columns("GUID").Visible = True
        End If

        Select Case ddlExportType.Text
            Case "CSV"
                bFileProduced = ExportToCSV()
            Case "MapMate"
                bFileProduced = ExportToMapMate()
            Case "Google Earth"
                bFileProduced = ExportToGE()
            Case "MapInfo"
                bFileProduced = ExportToMI()
            Case "RODIS"
                bFileProduced = ExportToRODIS()
            Case "BirdTrack Casual"
                bFileProduced = ExportToBirdTrackCasual()
            Case "None"
                bFileProduced = True
        End Select

        If Not bGUIDDisplayed Then
            frmMain.dgvRecords.Columns("GUID").Visible = False
        End If

        Me.Cursor = cur

        'comExport.CommandText = "Select last_insert_rowid()"

        If bFileProduced Then

            If intExportID = 0 Then
                'Insert record into Exports table
                comExport.CommandText = "Insert into exports(ShortTitle, Type,ExportDate,Notes,File) values(?,?,?,?,?)"
                comExport.Parameters.AddWithValue("ShortTitle", txtExportTitle.Text.Trim)
                comExport.Parameters.AddWithValue("Type", ddlExportType.Text)
                'comExport.Parameters.Add(New SQLiteParameter("ExportDate", DbType.Date))
                'comExport.Parameters("ExportDate").Value = Format(Date.Today, "dd/MM/yyyy")
                comExport.Parameters.AddWithValue("ExportDate", Date.Today)
                comExport.Parameters.AddWithValue("Notes", txtExportNotes.Text.Trim)
                If ddlExportType.Text <> "None" Then
                    comExport.Parameters.AddWithValue("File", SaveFileDialog.FileName)
                Else
                    comExport.Parameters.AddWithValue("File", "")
                End If
                comExport.ExecuteNonQuery()

                comExport.CommandText = "Select last_insert_rowid()"
                intExportID = comExport.ExecuteScalar

                'Insert records into ExportRecipient table
                comExport.CommandText = "Insert into ExportRecipient(ExportID, RecipientID) values(?,?)"
                comExport.Parameters.Clear()
                comExport.Parameters.AddWithValue("ExportID", 0)
                comExport.Parameters.AddWithValue("RecipientID", 0)

                Dim recipient As clsExportRecipient
                For Each recipient In lbExportRecipients.Items
                    comExport.Parameters("ExportID").Value = intExportID
                    comExport.Parameters("RecipientID").Value = recipient.RecipientID
                    comExport.ExecuteNonQuery()
                Next
            Else
                'Export record already exists, so records will be appended. Just update export date.
                comExport.CommandText = "Update exports set ExportDate=? where ExportID=?"
                comExport.Parameters.AddWithValue("ExportDate", Date.Today)
                comExport.Parameters.AddWithValue("ExportID", intExportID)
                comExport.ExecuteNonQuery()
            End If

            'Insert records into RecordExport table
            comExport.CommandText = "begin transaction"
            comExport.ExecuteNonQuery()

            comExport.Parameters.Clear()
            comExport.Parameters.AddWithValue("ExportID", 0)
            comExport.Parameters.AddWithValue("RecordID", 0)
            comExport.Parameters.AddWithValue("RecDateMod", Nothing)

            Dim row As DataGridViewRow
            For Each row In frmMain.dgvRecords.Rows
                If IsRecordForExport(row) And Not lstExcludeFromExport.Contains(row.Cells("ID").Value) Then

                    'Set parameters
                    comExport.Parameters("ExportID").Value = intExportID
                    comExport.Parameters("RecordID").Value = row.Cells("ID").Value
                    If cfun.HasNoValue(row.Cells("Modified").Value) Then
                        comExport.Parameters("RecDateMod").Value = Nothing
                    ElseIf row.Cells("Modified").Value = "today" Then
                        comExport.Parameters("RecDateMod").Value = Nothing
                    Else
                        comExport.Parameters("RecDateMod").Value = Date.Parse(row.Cells("Modified").Value)
                    End If

                    'Check for presence of this ExportID/RecordID already - can happen if appending to
                    'export of type 'None'
                    comExport.CommandText = "Select count(*) from RecordExport where ExportID=? and RecordID=?"
                    If comExport.ExecuteScalar > 0 Then
                        'Record is present - so delete. Therefore when record is inserted, the record modified
                        'date will be updated if that has changed.
                        comExport.CommandText = "Delete from RecordExport where ExportID=? and RecordID=?"
                        comExport.ExecuteNonQuery()
                    End If
                    comExport.CommandText = "Insert into RecordExport(ExportID, RecordID, RecDateMod) values(?,?, ?)"
                    comExport.ExecuteNonQuery()
                End If
            Next

            comExport.CommandText = "commit"
            comExport.ExecuteNonQuery()

            If ddlExportType.Text <> "None" Then
                If MessageBox.Show("Export complete. Do you want to view the exported file?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    'Open the exported with the default program
                    Try
                        System.Diagnostics.Process.Start(SaveFileDialog.FileName)
                    Catch ex As Exception
                        MessageBox.Show("Unable to open file '" & SaveFileDialog.FileName & "' directly from Gilbert. " & ex.Message)
                    End Try
                End If
            End If
            Me.Close()
        End If
    End Sub

    Private Sub frmExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbExportRecipients.DisplayMember = "RecipientName"
        lbExportRecipients.ValueMember = "RecipientID"
    End Sub

    Private Sub frmExport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        txtExportNotes.Text = ""
        txtExportTitle.Text = ""
        ddlExportType.SelectedIndex = -1
        lbExportRecipients.Items.Clear()

        If frmMain.dgvRecords.Columns("GUID").Visible Then
            chkIncludeGUID.Checked = True
            chkIncludeGUID.Enabled = False
        Else
            chkIncludeGUID.Enabled = True
        End If
    End Sub

    Public Sub ExportAtlas(ByVal expType As ExportType, ByVal sw As StreamWriter)

        Dim row As DataGridViewRow
        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()

        Dim lstHectads As List(Of String) = New List(Of String)
        Dim lstTetrads As List(Of String) = New List(Of String)
        Dim lstMonads As List(Of String) = New List(Of String)
        Dim strGR As String

        For Each row In frmMain.dgvRecords.Rows

            If IsRecordForExport(row) Then

                objGridRef.GridRef = row.Cells("GridRef").Value.ToString
                objGridRef.ParseGridRef(True)
                objGridRef.ParseInput(False)

                If objGridRef.sHectad <> "" And Not lstHectads.Contains(objGridRef.sHectad) Then
                    lstHectads.Add(objGridRef.sHectad)
                End If

                If objGridRef.sTetrad <> "" And Not lstTetrads.Contains(objGridRef.sTetrad) Then
                    lstTetrads.Add(objGridRef.sTetrad)
                End If

                If objGridRef.sMonad <> "" And Not lstMonads.Contains(objGridRef.sMonad) Then
                    lstMonads.Add(objGridRef.sMonad)
                End If
            End If
        Next

        sw.WriteLine("<Folder>")
        sw.WriteLine("<name>10 km (hectad) distribution</name>")
        For Each strGR In lstHectads

            objGridRef.GridRef = strGR
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)

            CreateAtlasCircle(objGridRef, sw, expType)
        Next
        sw.WriteLine("</Folder>")

        sw.WriteLine("<Folder>")
        sw.WriteLine("<name>2 km (tetrad) distribution</name>")
        For Each strGR In lstTetrads

            objGridRef.GridRef = strGR
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)

            CreateAtlasCircle(objGridRef, sw, expType)
        Next
        sw.WriteLine("</Folder>")

        sw.WriteLine("<Folder>")
        sw.WriteLine("<name>1 km (monad) distribution</name>")
        For Each strGR In lstMonads

            objGridRef.GridRef = strGR
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)

            CreateAtlasCircle(objGridRef, sw, expType)
        Next
        sw.WriteLine("</Folder>")
    End Sub

    Private Sub CreateAtlasCircle(objGridRef As GridRef, sw As StreamWriter, expType As ExportType)

        Dim dblX0 As Double = objGridRef.East
        Dim dblY0 As Double = objGridRef.North
        Dim dblRadius As Double = objGridRef.fWidth
        Dim dblX As Double = 0
        Dim dblY As Double = 0
        Dim dblRadians As Double = 0
        Dim strCoords As String = ""
        'Render the altas circle
        Select Case expType
            Case ExportType.GE

                sw.WriteLine("<Placemark>")
                sw.WriteLine("<name>" & objGridRef.GridRef & "</name>")
                sw.WriteLine("<styleUrl>#" & objGridRef.sRefType & "</styleUrl>")
                sw.WriteLine("<Polygon>")
                sw.WriteLine("<tessellate>1</tessellate>")
                sw.WriteLine("<outerBoundaryIs>")
                sw.WriteLine("<LinearRing>")

                'Make a point every 15 degrees
                For i = 0 To 360 Step 15

                    dblRadians = i * PI / 180
                    dblX = dblX0 + dblRadius * Cos(dblRadians)
                    dblY = dblY0 + dblRadius * Sin(dblRadians)
                    strCoords = strCoords & objGridRef.Easting2LongWGS84(dblX, dblY, 0).ToString & "," & objGridRef.Northing2LatWGS84(dblX, dblY, 0).ToString & " "
                Next
                sw.WriteLine("<coordinates>" & strCoords & "</coordinates>")
                sw.WriteLine("</LinearRing>")
                sw.WriteLine("</outerBoundaryIs>")
                sw.WriteLine("</Polygon>")
                sw.WriteLine("</Placemark>")
            Case Else
        End Select
    End Sub

    Public Sub ExportRows(ByVal expType As ExportType, ByVal sw As StreamWriter, ByVal sw2 As StreamWriter)

        Dim row As DataGridViewRow
        Dim bEastingNorthing As Boolean = cbEastingNorthing.Checked
        Dim conSQLiteResources As SQLiteConnection = Nothing
        Dim comSQLiteResources As SQLiteCommand = Nothing
        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()

        Dim strComment As String = ""

        Dim htBTOMatches As Hashtable = New Hashtable

        If expType = ExportType.BirdTrackCasual Then
            'Open the BTO bird names table
            Dim strResourcesDB As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "g21resources.db3")
            conSQLiteResources = New SQLiteConnection
            conSQLiteResources.ConnectionString = "Data Source=" & strResourcesDB & ";"
            conSQLiteResources.Open()
            comSQLiteResources = New SQLiteCommand("Select count(*) from BTOBirdNames where ScientificName=?;", conSQLiteResources)
            comSQLiteResources.Parameters.AddWithValue("ScientificName", "")
        End If

        For Each row In frmMain.dgvRecords.Rows

            If IsRecordForExport(row) Then

                If chkBoxAppendGUID.Checked Then
                    'Temporarily append GUID to comment
                    strComment = row.Cells("Comment").Value
                    row.Cells("Comment").Value = strComment & " Record GUID (from Gilbert 21): " & row.Cells("GUID").Value
                    row.Cells("Comment").Value = row.Cells("Comment").Value.ToString.Trim
                End If

                'Export the record
                Select Case expType
                    Case ExportType.CSV
                        ExportCSVRow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.MapMate
                        ExportMapMateRow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.GE
                        ExportGERow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.MapInfo
                        ExportMIRow(row, sw, sw2, objGridRef, bEastingNorthing)
                    Case ExportType.RODIS
                        ExportRODISRow(row, sw, objGridRef)
                    Case ExportType.BirdTrackCasual
                        ExportBirdTrackCasualRow(row, sw, objGridRef, comSQLiteResources, htBTOMatches)
                End Select

                If chkBoxAppendGUID.Checked Then
                    'Reset the comment
                    row.Cells("Comment").Value = strComment
                End If
            End If
        Next

        If expType = ExportType.BirdTrackCasual Then
            conSQLiteResources.Close()
        End If
    End Sub

    Private Function ExportToRODIS() As Boolean

        SaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)

            sw.WriteLine("Scientific Name,Date,Location,Grid-Ref,Observer,Determiner,Sex/Stage,Abundance,Record type,Comments")

            'Records
            ExportRows(ExportType.RODIS, sw, Nothing)
            sw.Close()

            MessageBox.Show("Sweet. Now you need to open the CSV file and save it as an Excel workbook (*.xls extension) in order to import it into RODIS.")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToBirdTrackCasual() As Boolean

        SaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)
           
            'No header line for this format

            'Records
            ExportRows(ExportType.BirdTrackCasual, sw, Nothing)
            sw.Close()

            MessageBox.Show("Now you need to open the CSV file and save it as an Excel workbook (Excel 97-2003 Workbook with an 'xls' extension) in order to import it into BirdTrack.")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToCSV() As Boolean

        SaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)

            Dim col As DataGridViewColumn
            Dim strLine As String = ""

            'Header
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    If strLine.Length > 0 Then
                        strLine = strLine & ","
                    End If
                    strLine = strLine & col.Name
                End If
            Next

            If cbEastingNorthing.Checked Then
                strLine = strLine & ",Easting,Northing"
            End If

            sw.WriteLine(strLine)

            'Records
            ExportRows(ExportType.CSV, sw, Nothing)
            sw.Close()

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToMapMate() As Boolean

        SaveFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)
            Dim strLine As String = ""

            'Header
            strLine = "Taxon"
            strLine = strLine & vbTab & "Site"
            strLine = strLine & vbTab & "Gridref"
            strLine = strLine & vbTab & "VC"
            strLine = strLine & vbTab & "Recorder"
            strLine = strLine & vbTab & "Determiner"
            strLine = strLine & vbTab & "Date"
            strLine = strLine & vbTab & "Quantity"
            strLine = strLine & vbTab & "Method"
            strLine = strLine & vbTab & "Sex"
            strLine = strLine & vbTab & "Stage"
            strLine = strLine & vbTab & "Status"
            strLine = strLine & vbTab & "Comment"

            sw.WriteLine(strLine)

            'Records
            ExportRows(ExportType.MapMate, sw, Nothing)
            sw.Close()

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToGE() As Boolean

        SaveFileDialog.Filter = "KML files (*.kml)|*.kml|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Call the common export code
            GEExportCommon(SaveFileDialog.FileName)
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToMI() As Boolean

        Dim htMIFieldLengths As Hashtable = New Hashtable
        Dim col As DataGridViewColumn
        Dim iCols As Integer
        Dim iLength As Integer
        Dim srMIF As StreamWriter
        Dim srMID As StreamWriter
        Dim srMIFTracks As StreamWriter
        Dim strMIDFile As String
        Dim strMIFTrack As String

        SaveFileDialog.Filter = "MIF files (*.mif)|*.mif|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            'Create the MIF file with the place markers
            srMIF = New StreamWriter(SaveFileDialog.FileName)
            strMIDFile = SaveFileDialog.FileName.Substring(0, SaveFileDialog.FileName.Length - 3) & "mid"
            strMIFTrack = SaveFileDialog.FileName.Substring(0, SaveFileDialog.FileName.Length - 4) & "-track.mif"
            srMID = New StreamWriter(strMIDFile)
            srMIFTracks = New StreamWriter(strMIFTrack)

            'Create the MapInfo MIF header
            srMIF.WriteLine("Version 300")
            srMIF.WriteLine("Charset ""WindowsLatin1""")
            srMIF.WriteLine("Delimiter "",""")
            srMIF.WriteLine("CoordSys Earth Projection 8, 79, ""m"", -2, 49, 0.9996012717, 400000, -100000 Bounds (-7845061.1011, -15524202.1641) (8645061.1011, 4470074.53373)")
            iCols = 0
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    iCols += 1
                End If
            Next
            srMIF.WriteLine("Columns " & iCols.ToString())

            'Get the maximum length of the field values for the MI table
            'and store in the hashtable
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    htMIFieldLengths.Add(col.Name, 0)
                End If
            Next

            Dim row As DataGridViewRow
            For Each row In frmMain.dgvRecords.Rows
                For Each col In frmMain.dgvRecords.Columns
                    If col.Visible Then
                        iLength = row.Cells(col.Name).Value.ToString.Length
                        If iLength > htMIFieldLengths(col.Name) Then
                            htMIFieldLengths(col.Name) = iLength
                        End If
                    End If
                Next
            Next

            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    iLength = htMIFieldLengths(col.Name)
                    If iLength > 254 Then
                        iLength = 254
                    End If
                    srMIF.WriteLine(col.Name & " Char(" & htMIFieldLengths(col.Name).ToString() & ")")
                End If
            Next

            srMIF.WriteLine("Data")

            'Records
            ExportRows(ExportType.MapInfo, srMIF, srMID)

            'Tracks
            If rbAllGPSTracks.Checked Then
                ExportTracks(ExportType.MapInfo, srMIFTracks, 0)
            End If

            srMID.Close()
            srMIF.Close()
            srMIFTracks.Close()

            Return True
        Else
            Return False
        End If
    End Function


    Private Function IsRecordForExport(ByVal row As DataGridViewRow) As Boolean

        Dim bExportRow As Boolean
        Dim bOnlySelected As Boolean = rbSelectedRecords.Checked
        Dim bBiologicalRecords As Boolean = cbBiologicalRecords.Checked
        Dim bInvalidModifiedCandidateRecords As Boolean = cbInvalidRecords.Checked
        Dim bIncludeExcluded As Boolean = cbIncludeExcluded.Checked

        If bOnlySelected And Not row.Selected Then
            'Only selected rows to be included and this record not selected
            bExportRow = False
        ElseIf row.Cells("NoExport").Value = "True" And Not bIncludeExcluded Then
            'Record is marked 'not for export' and this is not to be overidden 
            bExportRow = False
        Else
            If frmMain.IsValid(row, False) Then
                'IsValid will return true for candidate records and modified records
                'as well as valid saved records, so account for this.
                If cfun.HasNoValue(row.Cells("Modified").Value) Then
                    'Candidate record
                    If bInvalidModifiedCandidateRecords Then
                        bExportRow = True
                    Else
                        bExportRow = False
                    End If
                ElseIf row.Cells("Modified").Value = "today" Then
                    'Modifed (but valid) record
                    If bInvalidModifiedCandidateRecords Then
                        bExportRow = True
                    Else
                        bExportRow = False
                    End If
                Else
                    'Saved valid record
                    If bBiologicalRecords Then
                        bExportRow = True
                    Else
                        bExportRow = False
                    End If
                End If
            Else 'Invalid record
                If bInvalidModifiedCandidateRecords Then
                    bExportRow = True
                Else
                    bExportRow = False
                End If
            End If
        End If

        Return bExportRow
    End Function

    Private Sub ExportBirdTrackCasualRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, comSQLiteResources As SQLiteCommand, htBTOMatches As Hashtable)

        Dim bExportRow As Boolean = True

        'A: Username 
        'Your own BirdTrack login username.
        'Required field.
        Dim strLine As String = frmOptions.txtBirdTrackUser.Text & ","

        'B: Grid reference 
        'This can be at 100m (e.g. TL815825), 1km (TL8182), tetrad (e.g. TL88B) or 10km (e.g. TL88) resolution. 
        'Single prefix Irish grid references (e.g. H24) are acceptable (as is IH24).
        'If the record is for one of your existing BirdTrack sites, please ensure that you use the same grid reference. 
        'Required field.

        'If the G21 grid reference is 8 or 10 figure, convert to 6 figure
        Dim strGR As String = row.Cells("GridRef").Value.ToString
        Dim strPreciseGR As String = row.Cells("GridRef").Value.ToString

        If strGR.Length > 6 Then
            objGridRef.GridRef = strGR
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)
            strGR = objGridRef.sMonad
        End If

        If strPreciseGR.Length > 8 Then
            objGridRef.GridRef = strPreciseGR
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)
            strPreciseGR = objGridRef.s6Fig
        End If
        strLine = strLine & strGR & ","

        'C: Place name 
        'The name of the place where the bird was seen, or the nearest village or feature on the map (to assist location validation).
        'If the record is for one of your existing BirdTrack sites, please ensure that you use the same name. 
        'New places (not recorded at before) will be created for you. Please be accurate and brief, and avoid 'My garden' etc. 
        'Required field.
        Dim strLocation As String = ""
        If Not cfun.HasNoValue(row.Cells("Location")) And Not cfun.HasNoValue(row.Cells("Town")) Then
            strLocation = """" & row.Cells("Location").Value.ToString & ", " & row.Cells("Town").Value.ToString & """"
        ElseIf Not cfun.HasNoValue(row.Cells("Location")) Then
            strLocation = """" & row.Cells("Location").Value.ToString & """"
        Else
            strLocation = """" & row.Cells("Town").Value.ToString & """"
        End If
        strLine = strLine & strLocation & ","

        'D: Date of record 
        'The date of the record in dd/mm/yyyy format. Please note that Excel for Mac users may need to use d/m/yy format. 
        'Required field.
        strLine = strLine & row.Cells("Date").Value.ToString & ","

        'E: Species name 
        'The standard BTO English or scientific name of the species - click here for a list of standard names in Excel format. 
        'Required field.

        'Check that the scientific name is in the BTO names list
        Dim strG21ScientificName As String = row.Cells("ScientificName").Value.ToString
        comSQLiteResources.Parameters("ScientificName").Value = strG21ScientificName
        If comSQLiteResources.ExecuteScalar = 0 Then

            'If there's already been a match for this Scientific name, then use that, otherwise offer dialog for match
            If Not htBTOMatches.ContainsKey(strG21ScientificName) Then
                frmBTOBirdNameMatch.G21CommonName = row.Cells("CommonName").Value.ToString
                frmBTOBirdNameMatch.G21ScientificName = strG21ScientificName
                frmBTOBirdNameMatch.ShowDialog()

                htBTOMatches.Add(strG21ScientificName, frmBTOBirdNameMatch.BTOScientificName)
            End If

            If htBTOMatches(strG21ScientificName) = "" Then
                bExportRow = False
            Else
                strLine = strLine & htBTOMatches(strG21ScientificName) & ","
            End If
        Else
            strLine = strLine & strG21ScientificName & ","
        End If

        If bExportRow Then
            'F: Count 
            'The number of individuals seen, as an integer. 'c1' and '1+' formats are acceptable. 
            'Zero and '0' values are not acceptable and will generate an error. 
            'Optional field.

            'RegularExpressions.Regex.Replace(fullNote.Content, "<.*?>", "") Then
            Dim rxpNum As Regex = New Regex("^[0-9]+$") 'Any number
            Dim rxpNumPlys As Regex = New Regex("^[0-9]+\+$") 'Any number followed by a plus sign
            Dim rxpNumC As Regex = New Regex("^[cC][0-9]*$") 'Any number preceded by a c or C

            Dim strNum As String = ""
            If cfun.HasNoValue(row.Cells("Abundance")) Then
                strNum = ""
            ElseIf rxpNum.IsMatch(row.Cells("Abundance").Value.ToString) Or _
                rxpNumPlys.IsMatch(row.Cells("Abundance").Value.ToString) Or _
                rxpNumC.IsMatch(row.Cells("Abundance").Value.ToString) Then

                strNum = row.Cells("Abundance").Value.ToString
            Else
                'Leave blank
            End If

            strLine = strLine & strNum & ","

            'G: Breeding Code 
            'The breeding status of the record, following the standard BTO codes - click here to 
            'view a list of standard codes and explanation in a new window. 
            'Optional field.

            'No standard way of recording this in G21 and therefore no way of extracting it.
            strLine = strLine & ","

            'H: Time The observation hour (24 hour format e.g. 09). 
            'Optional field.
            If Not cfun.HasNoValue(row.Cells("Time")) Then
                If Not row.Cells("Time").Value.ToString = "00:00" Then 'These are legacy values - used to use these when no time recorded.
                    If row.Cells("Time").Value.ToString.Length > 2 Then
                        strLine = strLine & row.Cells("Time").Value.ToString.Substring(0, 2) & ","
                    Else
                        strLine = strLine & ","
                    End If
                Else
                    strLine = strLine & ","
                End If
            Else
                strLine = strLine & ","
            End If

            'I: Comment 
            'Any additional information about the observation made (max. 1000 characters). 
            'Comments will be visible to County Recorders, if you have given permission for your records to be accessed. 
            'Optional field.
            If Not cfun.HasNoValue(row.Cells("Comment")) Then
                'First 1000 characters
                Dim strComment As String = row.Cells("Comment").Value.ToString
                If strComment.Length > 1000 Then
                    strComment = strComment.Substring(0, 1000)
                End If
                strLine = strLine & """" & strComment & """" & ","
            Else
                strLine = strLine & ","
            End If

            'J: Sensitivity 
            'The record sensitivity; for an explanation click here. 
            'Records will be assumed not sensitive unless Y is used. 
            'Optional field.

            'Not applucable to G21
            strLine = strLine & ","

            'K: Observer
            'Name of observer. This feature is only available to Bird Clubs and other users with the 
            'functionality to record sightings from multiple observers. 
            'Optional field.

            'Not applicable to G21
            strLine = strLine & ","

            'L: Pinpoint sighting Record the 6-figure grid reference of a particular sighting. 
            'Useful for pinpointing nests, song-posts, unusual sightings etc.
            'Optional field.
            If Not strPreciseGR = strGR Then
                strLine = strLine & strPreciseGR
            End If
        End If

        If bExportRow Then
            sw.WriteLine(strLine)
        Else
            lstExcludeFromExport.Add(row.Cells("ID").Value)
        End If

    End Sub

    Private Sub ExportCSVRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim col As DataGridViewColumn
        Dim strLine As String = ""

        'Values
        For Each col In frmMain.dgvRecords.Columns

            If col.Visible Then
                If strLine.Length > 0 Then
                    strLine = strLine & ","
                End If
                strLine = strLine & """" & cfun.NullToEmpty(row.Cells(col.Name).Value).ToString().Replace("""", """""") & """"
            End If
        Next

        'Add easting and northing if required
        If bEastingNorthing Then
            If Not cfun.HasNoValue(row.Cells("GridRef").Value) Then
                objGridRef.GridRef = row.Cells("GridRef").Value.ToString
                objGridRef.ParseGridRef(True)
                objGridRef.ParseInput(False)

                strLine = strLine & "," & objGridRef.sEastingC & "," & objGridRef.sNorthingC
            End If
        End If

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportRODISRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef)

        Dim strCol As String
        Dim strLine As String = ""
        Dim strVal As String

        'Scientific Name,Date,Location,Grid-Ref,Observer,Determiner,Sex/Stage,Abundance,Record type,Comments
        'Values

        Dim colsRODIS As Collection = New Collection
        colsRODIS.Add("ScientificName") 'Scientific Name
        colsRODIS.Add("Date") 'Date
        colsRODIS.Add("Location") 'Location
        colsRODIS.Add("GridRef") 'Grid-Ref
        colsRODIS.Add("Recorder") 'Observer
        colsRODIS.Add("Determiner") 'Determiner
        colsRODIS.Add("Units") 'Sex/Stage
        colsRODIS.Add("Abundance") 'Abundance
        colsRODIS.Add("Blank") 'Record type
        colsRODIS.Add("Comment") 'Comments

        For Each strCol In colsRODIS

            If strLine.Length > 0 Then
                strLine = strLine & ","
            End If
            If strCol <> "Blank" Then
                strVal = cfun.NullToEmpty(row.Cells(strCol).Value).ToString().Replace("""", """""")
                If strVal.ToLower = "p" And strCol = "Abundance" Then
                    strVal = "Present"
                End If
                strLine = strLine & """" & strVal & """"
            End If
        Next

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportMIRow(ByVal row As DataGridViewRow, ByVal swMIF As StreamWriter, ByVal swMID As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim col As DataGridViewColumn
        Dim strLine As String = ""
        Dim strValue As String

        'MID file line
        For Each col In frmMain.dgvRecords.Columns

            If col.Visible Then
                If strLine.Length > 0 Then
                    strLine = strLine & ","
                End If
                strValue = row.Cells(col.Name).Value.ToString()
                If strValue.Length > 254 Then
                    strValue = strValue.Substring(0, 254)
                End If
                strLine = strLine & """" & cfun.NullToEmpty(strValue.Replace("""", """""")) & """"
            End If
        Next
        swMID.WriteLine(strLine)

        'MIF file line
        objGridRef.GridRef = row.Cells("GridRef").Value.ToString
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        swMIF.WriteLine("Point " & objGridRef.East.ToString() & " " & objGridRef.North.ToString())
        'Symbol(33, 255, 18)
    End Sub

    Private Sub ExportMapMateRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim strColName As String
        Dim strLine As String = ""

        If row.Cells("GridRef").Value.ToString = "" Then

            'Could happen for a personal note
            Exit Sub
        End If

        'MapMate columns:
        'Taxon,Site,Gridref,VC,Recorder,Determiner,Date,Quantity,Method,Sex,Stage,Status,Comment

        Dim alCols As ArrayList = New ArrayList
        alCols.Add("ScientificName")
        alCols.Add("Location")
        alCols.Add("GridRef")
        alCols.Add("VC")
        alCols.Add("Recorder")
        alCols.Add("Determiner")
        alCols.Add("Date")
        alCols.Add("Abundance")
        alCols.Add("skip")
        alCols.Add("skip")
        alCols.Add("Units")
        alCols.Add("skip")
        alCols.Add("Comment")


        'Values
        For Each strColName In alCols

            If strLine.Length > 0 Then
                strLine = strLine & vbTab
            End If

            If strColName = "skip" Then
                strLine = strLine & """"""
            ElseIf strColName = "VC" Then
                strLine = strLine & "0"
            Else
                strLine = strLine & """" & cfun.NullToEmpty(row.Cells(strColName).Value).ToString().Replace("""", """""") & """"
            End If
        Next

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportGERow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim strName As String = ""
        If Not cfun.HasNoValue(row.Cells("CommonName")) Then
            strName = row.Cells("CommonName").Value
        End If

        If strName = "" And Not cfun.HasNoValue(row.Cells("ScientificName")) Then
            strName = row.Cells("ScientificName").Value
        End If

        If strName = "" Then
            strName = "Not named"
        End If

        If row.Cells("GridRef").Value.ToString = "" Then
            'Could happen for a personal note
            Exit Sub
        End If

        strName = MakeValidXML(strName)

        sw.WriteLine("<Folder>")
        sw.WriteLine("<name>" & strName & "</name>")

        sw.WriteLine("<Placemark>")
        sw.WriteLine("<name>" & strName & "</name>")
        sw.WriteLine("<description>")
        'Values
        Dim strLine As String = ""
        For Each col In frmMain.dgvRecords.Columns
            If col.Visible Then
                strLine = strLine & "<tr><td><b>" & MakeValidXML(col.name) & "</b></td><td>" & MakeValidXML(cfun.NullToEmpty(row.Cells(col.Name).Value).ToString()) & "</td></tr>"
            End If
        Next

        objGridRef.GridRef = row.Cells("GridRef").Value.ToString
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)

        sw.WriteLine("<table>" & strLine & "</table>")
        sw.WriteLine("</description>")

        'If there's no value in the 'Modified' field, it's just a candidate record and
        'for our purposes here we want to style as invalid.
        If cfun.HasNoValue(row.Cells("Modified").Value) Then
            sw.WriteLine("<styleUrl>#invalid</styleUrl>")
        ElseIf frmMain.IsValid(row, False) Then
            sw.WriteLine("<styleUrl>#" & objGridRef.sRefType & "</styleUrl>")
        Else
            sw.WriteLine("<styleUrl>#invalid</styleUrl>")
        End If

        sw.WriteLine("<Point>")
        sw.WriteLine("<coordinates>")

        sw.WriteLine(objGridRef.Easting2LongWGS84(objGridRef.East, objGridRef.North, 0).ToString() & "," & objGridRef.Northing2LatWGS84(objGridRef.East, objGridRef.North, 0).ToString() & ",0")
        sw.WriteLine("</coordinates>")
        sw.WriteLine("</Point>")
        sw.WriteLine("</Placemark>")

        'Render the grid reference squares
        KML.RenderGR(sw, row.Cells("GridRef").Value.ToString, frmMain.IsValid(row, False))

        sw.WriteLine("</Folder>")
    End Sub

    Private Sub ExportTracksToGE(ByVal sw As StreamWriter, ByVal intInterval As Integer)

        Dim row As DataRow
        Dim col As DataColumn
        Dim rowDGV As DataGridViewRow
        Dim iCount As Integer
        Dim inFile As clsInputFile = Nothing
        Dim dtTrackDataTable As DataTable

        Dim strTrackFile As String = ""
        Dim strFiletype As String = ""

        'For each record, get the corresponding track FileID if there
        'is one and put into a collection
        Dim intTrackID As Integer
        Dim colFileID As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        comTracks.CommandText = "select FileID from RecordTracks where RecordID = ?;"
        Dim paramRecordID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramRecordID)
        For Each rowDGV In frmMain.dgvRecords.Rows
            paramRecordID.Value = rowDGV.Cells("ID").Value
            intTrackID = comTracks.ExecuteScalar()
            If Not colFileID.Contains(intTrackID.ToString) Then
                colFileID.Add(intTrackID, intTrackID.ToString)
            End If
        Next

        'Now for each of the identified track, get the filename and read in the file
        comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = ?;"
        comTracks.Parameters.Clear()
        Dim paramFileID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramFileID)
        Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTrackFile As DataTable = New DataTable

        If colFileID.Count > 10 Then
            If MessageBox.Show(colFileID.Count.ToString & " tracks are referenced. Are you sure you want to export all of them (it could take some time)?", "Export track warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        For Each intFileID In colFileID

            paramFileID.Value = intFileID
            dtTrackFile.Clear()
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count = 1 Then
                If Not IsDBNull(dtTrackFile.Rows(0)("CurrentPath")) Then
                    strTrackFile = dtTrackFile.Rows(0)("CurrentPath")
                    strFiletype = dtTrackFile.Rows(0)("FileType")

                    inFile = Nothing
                    Select Case strFiletype.ToLower()

                        Case "visiontac"
                            inFile = New clsInputFileVisiontac(strTrackFile)
                        Case "evernoteexport"
                            inFile = New clsInputFileEvernoteExport(strTrackFile)
                    End Select

                    If Not inFile Is Nothing Then
                        For Each dtTrackDataTable In inFile.GetTracks

                            sw.WriteLine("<Placemark>")
                            sw.WriteLine("<name>Untitled Path</name>")
                            sw.WriteLine("<styleUrl>#trackStyle</styleUrl>")
                            sw.WriteLine("<LineString>")
                            sw.WriteLine("<tessellate>1</tessellate>")
                            sw.WriteLine("<coordinates>")

                            For Each row In dtTrackDataTable.Rows

                                If rbAllGPSTracks.Checked Then
                                    sw.WriteLine(row("lon") & "," & row("lat") & ",0 ")
                                End If
                            Next

                            sw.WriteLine("</coordinates>")
                            sw.WriteLine("</LineString>")
                            sw.WriteLine("</Placemark>")

                            'Track interval points
                            If intInterval > 0 Then
                                iCount = 0
                                For Each row In dtTrackDataTable.Rows
                                    iCount += 1
                                    If iCount = 1 Or iCount = dtTrackDataTable.Rows.Count Or iCount Mod intInterval = 0 Then

                                        sw.WriteLine("<Placemark>")

                                        'Attributes
                                        sw.WriteLine("<description>")
                                        sw.WriteLine("<table>")
                                        For Each col In dtTrackDataTable.Columns

                                            sw.WriteLine("<tr><td><b>" & MakeValidXML(col.ColumnName) & "</b></td><td>" & MakeValidXML(row(col.ColumnName)) & "</td></tr>")
                                        Next
                                        sw.WriteLine("</table>")
                                        sw.WriteLine("</description>")

                                        sw.WriteLine("<styleUrl>#trackPoint</styleUrl>")
                                        sw.WriteLine("<Point>")
                                        sw.WriteLine("<coordinates>" & row("lon") & "," & row("lat") & ",0" & "</coordinates>")
                                        sw.WriteLine("</Point>")
                                        sw.WriteLine("</Placemark>")
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
            End If
        Next

        comTracks.Dispose()
        daTrackFile.Dispose()
        db.Dispose()
    End Sub

    Private Sub ExportTracks(ByVal expType As ExportType, ByVal sw As StreamWriter, ByVal intInterval As Integer)

        Dim rowDGV As DataGridViewRow
        Dim inFile As clsInputFile = Nothing
        Dim dtTrackDataTable As DataTable
        Dim intTrack As Integer = 0
        Dim strTrackFile As String = ""
        Dim strFiletype As String = ""

        'For each record, get the corresponding track FileID if there
        'is one and put into a collection
        Dim intTrackID As Integer
        Dim colFileID As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        comTracks.CommandText = "select FileID from RecordTracks where RecordID = ?;"
        Dim paramRecordID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramRecordID)
        For Each rowDGV In frmMain.dgvRecords.Rows
            paramRecordID.Value = rowDGV.Cells("ID").Value
            intTrackID = comTracks.ExecuteScalar()
            If Not colFileID.Contains(intTrackID.ToString) Then
                colFileID.Add(intTrackID, intTrackID.ToString)
            End If
        Next

        'Now for each of the identified track, get the filename and read in the file
        comTracks.CommandText = "select CurrentPath, FileType, DateCreated from Tracks where FileID = ?;"
        comTracks.Parameters.Clear()
        Dim paramFileID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramFileID)
        Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTrackFile As DataTable = New DataTable
        Dim strTrackTitle As String = ""

        If colFileID.Count > 1 Then
            If MessageBox.Show(colFileID.Count.ToString & " tracks are referenced. Are you sure you want to export all of them (if there are many it could take some time)?", "Export track warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If colFileID.Count > 0 Then
            sw.WriteLine("<Folder>") 'Tracks folder
            sw.WriteLine("<name>Tracks</name>")
        End If

        For Each intFileID In colFileID

            paramFileID.Value = intFileID
            dtTrackFile.Clear()
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count = 1 Then
                If Not IsDBNull(dtTrackFile.Rows(0)("CurrentPath")) Then
                    strTrackFile = dtTrackFile.Rows(0)("CurrentPath")
                    strFiletype = dtTrackFile.Rows(0)("FileType")

                    inFile = Nothing
                    Select Case strFiletype.ToLower()

                        Case "visiontac"
                            inFile = New clsInputFileVisiontac(strTrackFile)
                    End Select

                    If Not inFile Is Nothing Then
                        For Each dtTrackDataTable In inFile.GetTracks

                            Select Case expType

                                Case ExportType.GE
                                    ExportTrackGE(sw, intInterval, dtTrackDataTable)
                                Case ExportType.MapInfo
                                    intTrack += 1
                                    ExportTrackMI(sw, dtTrackDataTable, intTrack)
                            End Select
                        Next
                    End If
                End If
            End If
        Next

        If colFileID.Count > 0 Then
            sw.WriteLine("</Folder>") 'Tracks folder
        End If

        comTracks.Dispose()
        daTrackFile.Dispose()
        db.Dispose()
    End Sub

    Private Sub ExportTrackGE(ByVal sw As StreamWriter, ByVal intInterval As Integer, ByVal dtTrackDataTable As DataTable)

        Dim row As DataRow
        Dim col As DataColumn
        Dim iCount As Integer
        Dim strTrackTitle As String = "Track " & dtTrackDataTable.Rows(0)("Date") & " " & dtTrackDataTable.Rows(0)("Time")

        sw.WriteLine("<Folder>") 'Whole track folder
        sw.WriteLine("<name>" & strTrackTitle & "</name>")

        sw.WriteLine("<Placemark>") 'Track
        sw.WriteLine("<name>Track</name>")
        sw.WriteLine("<styleUrl>#trackStyle</styleUrl>")
        sw.WriteLine("<LineString>")
        sw.WriteLine("<tessellate>1</tessellate>")
        sw.WriteLine("<coordinates>")

        For Each row In dtTrackDataTable.Rows

            If rbAllGPSTracks.Checked Then
                sw.WriteLine(row("lon") & "," & row("lat") & ",0 ")
            End If
        Next

        sw.WriteLine("</coordinates>")
        sw.WriteLine("</LineString>")
        sw.WriteLine("</Placemark>") 'Track

        'Track interval points
        If intInterval > 0 Then
            iCount = 0

            sw.WriteLine("<Folder>") 'Track points folder
            sw.WriteLine("<name>Track points</name>")
            sw.WriteLine("<visibility>0</visibility>") 'By default, track points are not shown

            For Each row In dtTrackDataTable.Rows
                iCount += 1
                If iCount = 1 Or iCount = dtTrackDataTable.Rows.Count Or iCount Mod intInterval = 0 Then

                    sw.WriteLine("<Placemark>")
                    sw.WriteLine("<visibility>0</visibility>") 'By default, track points are not shown
                    'Attributes
                    sw.WriteLine("<description>")
                    sw.WriteLine("<table>")
                    For Each col In dtTrackDataTable.Columns

                        sw.WriteLine("<tr><td><b>" & MakeValidXML(col.ColumnName) & "</b></td><td>" & MakeValidXML(row(col.ColumnName)) & "</td></tr>")
                    Next
                    sw.WriteLine("</table>")
                    sw.WriteLine("</description>")

                    sw.WriteLine("<styleUrl>#trackPoint</styleUrl>")
                    sw.WriteLine("<Point>")
                    sw.WriteLine("<coordinates>" & row("lon") & "," & row("lat") & ",0" & "</coordinates>")
                    sw.WriteLine("</Point>")
                    sw.WriteLine("</Placemark>")
                End If
            Next

            sw.WriteLine("</Folder>") 'Track points folder
        End If

        sw.WriteLine("</Folder>") 'Whole track folder
    End Sub

    Private Sub ExportTrackMI(ByVal sw As StreamWriter, ByVal dtTrackDataTable As DataTable, ByVal intTrack As Integer)

        Dim row As DataRow
        Dim objGR As GridRef = New GridRef
        objGR.MakePrefixArrays()
        Dim dblEasting As Double
        Dim dblNorthing As Double

        If intTrack = 1 Then
            sw.WriteLine("Version 300")
            sw.WriteLine("Charset ""WindowsLatin1""")
            sw.WriteLine("Delimiter "",""")
            sw.WriteLine("CoordSys Earth Projection 8, 79, ""m"", -2, 49, 0.9996012717, 400000, -100000 Bounds (-7845061.1011, -15524202.1641) (8645061.1011, 4470074.53373)")
            sw.WriteLine("Columns 1")
            sw.WriteLine("ID Char(10)")
            sw.WriteLine("Data")
        End If

        sw.WriteLine("Pline " & dtTrackDataTable.Rows.Count)

        For Each row In dtTrackDataTable.Rows

            dblEasting = objGR.LongWGS842Easting(Convert.ToDouble(row("lat")), Convert.ToDouble(row("lon")), 0)
            dblNorthing = objGR.LatWGS842Northing(Convert.ToDouble(row("lat")), Convert.ToDouble(row("lon")), 0)
            If rbAllGPSTracks.Checked Then
                sw.WriteLine(CInt(dblEasting).ToString & " " & CInt(dblNorthing).ToString)
            End If
        Next
    End Sub

    Private Function MakeValidXML(ByVal objVal As Object) As String

        Dim i As Integer
        Dim chr As Char
        Dim chrNew As String
        Dim strNew As String = ""
        Dim strVal As String = ""

        If Not cfun.HasNoValue(objVal) Then
            strVal = objVal.ToString
        End If

        For i = 0 To strVal.Length - 1

            chr = strVal.Substring(i, 1)
            Select Case chr
                Case "&"
                    chrNew = "&amp;"
                Case "<"
                    chrNew = "&lt;"
                Case ">"
                    chrNew = "&gt;"
                Case """"
                    chrNew = "&quot;"
                Case "'"
                    chrNew = "&#39;"
                Case Else
                    'Test for null
                    If Asc(chr) = 0 Then
                        chrNew = ""
                    Else
                        chrNew = chr
                    End If
            End Select

            strNew = strNew & chrNew
        Next

        Return strNew
    End Function

    Private Sub GEExportCommon(strKMLFile As String)

        'Set export folder option if not already set
        If frmOptions.txtExportFolder.Text = "" Then
            frmOptions.txtExportFolder.Text = Path.GetDirectoryName(strKMLFile)
        End If

        'Create the KML file with the place markers
        Dim srKML As StreamWriter = New StreamWriter(strKMLFile)

        srKML.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        srKML.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")

        srKML.WriteLine("<Folder>")

        'The lookat tag is there to work around a feature in GE 7 whereby GE tilts automatically
        'when GE adjusts the view to accommodate a KML. It is a default view for whole of GB
        srKML.WriteLine("<LookAt>")
        srKML.WriteLine("<longitude>-1.58</longitude>")
        srKML.WriteLine("<latitude>53.97</latitude>")
        srKML.WriteLine("<altitude>0</altitude>")
        srKML.WriteLine("<tilt>0</tilt>")
        srKML.WriteLine("<range>1325141</range>")
        srKML.WriteLine("<heading>0.749054386832512</heading>")
        srKML.WriteLine("</LookAt>")

        srKML.WriteLine("<name>Gilbert 21 records</name>")

        'Styles for records
        KML.StyleKML(srKML, frmOptions.butStyle100km.BackColor, "100km")
        KML.StyleKML(srKML, frmOptions.butStyle10km.BackColor, "hectad")
        KML.StyleKML(srKML, frmOptions.butStyle2km.BackColor, "tetrad")
        KML.StyleKML(srKML, frmOptions.butStyle1km.BackColor, "monad")
        KML.StyleKML(srKML, frmOptions.butStyle100m.BackColor, "6fig")
        KML.StyleKML(srKML, frmOptions.butStyle10m.BackColor, "8fig")
        KML.StyleKML(srKML, frmOptions.butStyle1m.BackColor, "10fig")
        KML.StyleKML(srKML, frmOptions.butStyleInvalid.BackColor, "invalid")

        'Track point style
        srKML.WriteLine("<Style id=""trackPoint"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<color>ff7fffaa</color>")
        srKML.WriteLine("<scale>0.6</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")

        'Track line style
        srKML.WriteLine("<Style id=""trackStyle"">")
        srKML.WriteLine("<LineStyle>")
        srKML.WriteLine("<width>" & nudTrackThickness.Value & "</width>")
        srKML.WriteLine("</LineStyle>")
        srKML.WriteLine("</Style>")

        'Records
        srKML.WriteLine("<Folder>")
        srKML.WriteLine("<name>Records</name>")
        ExportRows(ExportType.GE, srKML, Nothing)
        srKML.WriteLine("</Folder>")

        'Atlas layers
        If cbAtlasLayers.Checked Then
            srKML.WriteLine("<Folder>")
            srKML.WriteLine("<name>Atlas</name>")
            ExportAtlas(ExportType.GE, srKML)
            srKML.WriteLine("</Folder>")
        End If

        'Tracks
        If rbAllGPSTracks.Checked Then
            ExportTracks(ExportType.GE, srKML, nudTrackInterval.Value)
        End If

        'Close file
        srKML.WriteLine("</Folder>")
        srKML.WriteLine("</kml>")
        srKML.Close()

    End Sub
    Public Sub GEQuick()

        Dim strKMLFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\G21QuickView.kml"

        'Store current value of KML export options
        Dim bAllRecs As Boolean = rbAllRecords.Checked
        Dim bBiologicalRecs As Boolean = cbBiologicalRecords.Checked
        Dim bInvalidRecs As Boolean = cbInvalidRecords.Checked
        Dim bIncludeExcluded As Boolean = cbIncludeExcluded.Checked
        Dim bIncludeGUID As Boolean = chkIncludeGUID.Checked
        Dim bAppendGUID As Boolean = chkBoxAppendGUID.Checked
        Dim bNoGPSTracks As Boolean = rbNoGPSTracks.Checked
        Dim bAtlasLayers As Boolean = cbAtlasLayers.Checked
        Dim intTrackInterval As Integer = nudTrackInterval.Value
        Dim intTrackThickness As Integer = nudTrackThickness.Value

        'Set the controls to values required for KML quick view
        rbAllRecords.Checked = True
        cbBiologicalRecords.Checked = True
        cbInvalidRecords.Checked = True
        cbIncludeExcluded.Checked = True
        chkIncludeGUID.Checked = False
        chkBoxAppendGUID.Checked = False
        rbAllGPSTracks.Checked = True
        cbAtlasLayers.Checked = True
        nudTrackInterval.Value = 20
        nudTrackThickness.Value = 2

        'Call the common export code
        GEExportCommon(strKMLFile)

        'Reset export dialog GE values
        If bAllRecs Then
            rbAllRecords.Checked = True
        Else
            rbSelectedRecords.Checked = True
        End If
        cbBiologicalRecords.Checked = bBiologicalRecs
        cbInvalidRecords.Checked = bInvalidRecs
        cbIncludeExcluded.Checked = bIncludeExcluded
        chkIncludeGUID.Checked = bIncludeGUID
        chkBoxAppendGUID.Checked = bAppendGUID
        If bNoGPSTracks Then
            rbNoGPSTracks.Checked = True
        Else
            rbAllGPSTracks.Checked = True
        End If
        cbAtlasLayers.Checked = bAtlasLayers
        nudTrackInterval.Value = intTrackInterval
        nudTrackThickness.Value = intTrackThickness

        'Open the KML file with the default program (Google Earth)
        If frmOptions.chkGE.Checked Then
            Try
                System.Diagnostics.Process.Start(strKMLFile)
            Catch ex As Exception
                MessageBox.Show("Could not open 'strKMLFile' from Gilbert. Try starting Google Earth first and then opening the file from there.")
            End Try
        Else
            MessageBox.Show("Created: " & strKMLFile & ". If you want GE files to open automatically, check the box on the options dialog.")
        End If
    End Sub

    Private Sub butAddRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddRecipient.Click

        frmExportManageRecipients.ShowDialog()
        Dim recipient As clsExportRecipient

        'Ensure that none of the items in the list has been deleted
        Dim colDeletedRecipients As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        For Each recipient In lbExportRecipients.Items
            comExport.CommandText = "Select count(*) from recipients where RecipientID = " & recipient.RecipientID.ToString
            If comExport.ExecuteScalar() = 0 Then
                colDeletedRecipients.Add(recipient)
            End If
        Next
        For Each recipient In colDeletedRecipients
            lbExportRecipients.Items.Remove(recipient)
        Next

        'Add selected recipient
        If frmExportManageRecipients.RecipientID > 0 Then
            For Each recipient In lbExportRecipients.Items
                If recipient.RecipientID = frmExportManageRecipients.RecipientID Then
                    MessageBox.Show("Recipient already included.")
                    Exit Sub
                End If
            Next
            recipient = New clsExportRecipient(frmExportManageRecipients.RecipientID, frmExportManageRecipients.RecipientName)
            lbExportRecipients.Items.Add(recipient)
        End If
    End Sub

    Private Sub butRemoveRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemoveRecipient.Click

        If Not lbExportRecipients Is Nothing Then

            lbExportRecipients.Items.Remove(lbExportRecipients.SelectedItem)
        End If
    End Sub

End Class