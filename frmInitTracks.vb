Imports Microsoft.Win32
Imports System.Data.SQLite
Imports System.IO

Public Class frmInitTracks

    Private Sub butBrowseDatabaseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseDatabaseFolder.Click

        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")

        FolderBrowserDialog.SelectedPath = txtParentFolder.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            txtParentFolder.Text = FolderBrowserDialog.SelectedPath
        End If

        newkey.SetValue("ParentTrackFolder", txtParentFolder.Text)
    End Sub

    Private Sub frmInitTracks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")

        txtParentFolder.Text = newkey.GetValue("ParentTrackFolder")
    End Sub

    Private Sub butProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butProcess.Click

        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        Dim comRecords As SQLiteCommand = New SQLiteCommand(db.conMain)

        'Does folder exist
        If Not Directory.Exists(txtParentFolder.Text) Then

            MessageBox.Show("The parent folder is not set to the path of an existing folder.")
            Exit Sub
        End If

        'Are there any records in the Tracks table already? If so warn and delete.
        comTracks.CommandText = "Select count(*) from Tracks;"
        If comTracks.ExecuteScalar() > 0 Then

            If MessageBox.Show("There are already records in the Tracks table. If you continue, you will completely replace these. Do you want to continue?", "Tracks exist", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                comTracks.CommandText = "Delete from Tracks;"
                comTracks.ExecuteNonQuery()
                comTracks.CommandText = "Delete from RecordTracks;"
                comTracks.ExecuteNonQuery()
            End If
        End If

        Cursor = Cursors.WaitCursor

        'First insert a value in the Tracks table for every unique value of Filename field
        'in the Records table.
        Dim dtRecords As DataTable = New DataTable
        Dim daRecords As SQLiteDataAdapter

        Dim strSQL As String = "Select distinct Filename from Records where filename not null;"
        daRecords = New SQLiteDataAdapter(strSQL, db.conMain)
        daRecords.Fill(dtRecords)

        Dim paramFilename As SQLiteParameter = New SQLiteParameter()
        comTracks.Parameters.Add(paramFilename)
        comTracks.CommandText = "insert into Tracks (Filename) Values (?)"

        Dim rowRecord As DataRow
        Dim transTracks As SQLiteTransaction = db.conTracks.BeginTransaction()
        For Each rowRecord In dtRecords.Rows

            paramFilename.Value = rowRecord("Filename")
            comTracks.ExecuteNonQuery()
        Next
        transTracks.Commit()

        'Now go find every CSV file under the parent directory and if it matches an
        'entry in the Tracks table, then complete the details in the table. If more than
        'one file exists with the same name, create entries for both.
        transTracks = db.conTracks.BeginTransaction()
        UpdateTracksFromFiles(txtParentFolder.Text, comTracks)
        transTracks.Commit()

        'Now go through all the records in the Records table and which link to a track
        'and create a corresponding link entry in the RecordTracks table.
        strSQL = "Select ID, Filename from Records where filename not null;"
        daRecords = New SQLiteDataAdapter(strSQL, db.conMain)
        dtRecords.Clear()
        daRecords.Fill(dtRecords)

        comTracks.Parameters.Clear()
        comTracks.CommandText = "Select FileID from Tracks where filename = ?;"
        comTracks.Parameters.Add(paramFilename)
        Dim daTracks As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTracks As DataTable = New DataTable
        Dim rowTracks As DataRow
        Dim comRecordTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        comRecordTracks.CommandText = "insert into RecordTracks (RecordID, FileID) values(?,?);"
        Dim paramRecordID As SQLiteParameter = New SQLiteParameter
        comRecordTracks.Parameters.Add(paramRecordID)
        Dim paramFileID As SQLiteParameter = New SQLiteParameter
        comRecordTracks.Parameters.Add(paramFileID)

        pbInitiate.Maximum = dtRecords.Rows.Count

        transTracks = db.conTracks.BeginTransaction()
        For Each rowRecord In dtRecords.Rows

            paramFilename.Value = rowRecord("Filename")
            dtTracks.Clear()
            daTracks.Fill(dtTracks)

            For Each rowTracks In dtTracks.Rows

                paramRecordID.Value = rowRecord("ID")
                paramFileID.Value = rowTracks("FileID")
                comRecordTracks.ExecuteNonQuery()
            Next

            pbInitiate.Value += 1
        Next
        transTracks.Commit()

        Cursor = Cursors.Arrow

        MessageBox.Show("Track initialisation is complete.", "Gilbert 21")
        Me.Close()
    End Sub

    Private Sub UpdateTracksFromFiles(ByVal strFolder As String, ByVal comTracks As SQLiteCommand)

        'For each file in this folder that is found in the Tracks table,
        'update Tracks details. For each sub-folder of this folder, call this
        'sub-routine recursively.

        Dim strFile As String
        Dim strSubFolder As String
        Dim strFileName As String
        Dim fi As FileInfo

        For Each strFile In Directory.GetFiles(strFolder)

            strFileName = Path.GetFileName(strFile)
            comTracks.CommandText = "Select count(*) from Tracks where FileName = '" & strFileName & "';"
            If comTracks.ExecuteScalar() > 0 Then
                'The file needs to be recorded in the Tracks table.
                'If the existing record's OriginalPath value is null, then update that record,
                'else insert a new one.
                fi = New FileInfo(strFile)
                comTracks.CommandText = "Select OriginalPath from Tracks where FileName = '" & strFileName & "';"
                If cfun.HasNoValue(comTracks.ExecuteScalar()) Then
                    comTracks.CommandText = "Update Tracks set OriginalPath=?, CurrentPath=?, DateCreated=?, FileType=?, GenericFileType=? where FileName = '" & strFileName & "';"
                    comTracks.Parameters.Clear()
                    comTracks.Parameters.AddWithValue("OriginalPath", strFile)
                    comTracks.Parameters.AddWithValue("CurrentPath", strFile)
                    comTracks.Parameters.AddWithValue("DateCreated", fi.CreationTime)
                    comTracks.Parameters.AddWithValue("FileType", "Visiontac") 'Ref to visiontac okay
                    comTracks.Parameters.AddWithValue("GenericFileType", "CSV")
                    comTracks.ExecuteNonQuery()
                Else
                    'Need to insert a new row into Tracks.
                    comTracks.CommandText = "Insert into Tracks (Filename, OriginalPath, CurrentPath, DateCreated, FileType, GenericFileType) values(?,?,?,?,?,?);"
                    comTracks.Parameters.Clear()
                    comTracks.Parameters.AddWithValue("FileName", strFileName)
                    comTracks.Parameters.AddWithValue("OriginalPath", strFile)
                    comTracks.Parameters.AddWithValue("CurrentPath", strFile)
                    comTracks.Parameters.AddWithValue("DateCreated", fi.CreationTime)
                    comTracks.Parameters.AddWithValue("FileType", "Visiontac") 'Ref to visiontac okay
                    comTracks.Parameters.AddWithValue("GenericFileType", "CSV")
                    comTracks.ExecuteNonQuery()
                End If
            End If
        Next

        For Each strSubFolder In Directory.GetDirectories(strFolder)

            UpdateTracksFromFiles(strSubFolder, comTracks)
        Next
    End Sub
End Class