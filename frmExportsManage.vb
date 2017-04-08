Imports System.IO
Imports System.Data.SQLite

Public Class frmExportsManage

    Private Sub PopulateForm()

        ddlExportTitle.DataSource = Nothing
        ddlExportTitle.DisplayMember = "ShortTitle"
        'ddlExportTitle.Items.Clear()

        Dim db As clsDB = New clsDB

        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        If cbRecipient.SelectedItem Is Nothing Then
            comExport.CommandText = "Select * from Exports order by ShortTitle"
        ElseIf cbRecipient.Text <> cbRecipient.SelectedItem("Name") Then
            comExport.CommandText = "Select * from Exports order by ShortTitle"
        Else
            comExport.CommandText = "Select Exports.* from Exports inner join ExportRecipient on Exports.ExportID = ExportRecipient.ExportID  inner join Recipients on Recipients.RecipientID = ExportRecipient.RecipientID where Recipients.Name = ? order by ShortTitle"
            comExport.Parameters.AddWithValue("Name", cbRecipient.Text)
        End If

        Dim odba As SQLiteDataAdapter
        odba = New SQLiteDataAdapter(comExport)
        Dim dtExport As DataTable = New DataTable()

        If odba.Fill(dtExport) > 0 Then

            If txtExportTitleFilter.Text.Trim <> "" Then
                Dim dtFiltered As DataTable = dtExport.Clone
                Dim drFiltered As DataRow() = dtExport.Select("ShortTitle like '%" & txtExportTitleFilter.Text.Trim & "%'", "ShortTitle")
                For Each row As DataRow In drFiltered
                    dtFiltered.ImportRow(row)
                Next
                ddlExportTitle.DataSource = dtFiltered
            Else
                ddlExportTitle.DataSource = dtExport
            End If
        End If

        CheckUpdateStatus()
    End Sub

    Private Sub PopulateRecipientDropdown()

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        'Recipients list
        cbRecipient.DataSource = Nothing
        cbRecipient.DisplayMember = "Name"
        cbRecipient.Items.Clear()

        Dim strSQL As String = "Select * from recipients order by name"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conExports)
        Dim dtRecipients As DataTable = New DataTable()
        If odba.Fill(dtRecipients) > 0 Then
            cbRecipient.DataSource = dtRecipients
        End If

        cbRecipient.Text = ""
    End Sub

    Private Sub txtExportNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExportNotes.TextChanged

        CheckUpdateStatus()
    End Sub

    Private Sub frmExportsManage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbExportRecipients.DisplayMember = "RecipientName"
        lbExportRecipients.ValueMember = "RecipientID"
    End Sub

    Private Sub frmExportsManage_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        PopulateRecipientDropdown()
        PopulateForm()
    End Sub

    Private Sub butCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCommit.Click

        If ddlExportTitle.Enabled Then
            Me.Close()
        Else
            MessageBox.Show("Edits are pending. First either cancel the edits or accept (update button).")
        End If
    End Sub

    Private Sub txtExportTitleFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExportTitleFilter.TextChanged
        PopulateForm()

        txtExportTitleFilter.Focus()
    End Sub

    Private Sub ddlExportTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlExportTitle.SelectedIndexChanged

        If Not ddlExportTitle.SelectedItem Is Nothing Then
            Dim row As DataRowView = ddlExportTitle.SelectedItem

            dtpExportDate.Value = row("ExportDate")
            txtExportFile.Text = row("File")
            txtExportTitle.Text = row("ShortTitle")
            txtExportNotes.Text = row("Notes")

            ddlExportType.SelectedItem = Nothing
            Dim strType As String
            For Each strType In ddlExportType.Items
                If strType = row("Type") Then
                    ddlExportType.SelectedItem = strType
                End If
            Next

            'Update the export recipients list
            lbExportRecipients.Items.Clear()
            Dim db As clsDB = New clsDB()
            Dim strSQL As String = "select Recipients.RecipientID as RecipientID, Name from ExportRecipient, Recipients where ExportRecipient.RecipientID = Recipients.RecipientID and ExportID=" & row("ExportID")
            Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conExports)
            Dim dtExportRecipient As DataTable = New DataTable()
            odba.Fill(dtExportRecipient)
            For Each dtRow As DataRow In dtExportRecipient.Rows
                Dim recipient As clsExportRecipient = New clsExportRecipient(dtRow("RecipientID"), dtRow("Name"))
                lbExportRecipients.Items.Add(recipient)
            Next
        Else
            dtpExportDate.Text = ""
            txtExportFile.Text = ""
            txtExportTitle.Text = ""
            txtExportNotes.Text = ""
            ddlExportType.SelectedItem = Nothing
            lbExportRecipients.Items.Clear()
        End If
        CheckUpdateStatus()
    End Sub

    Private Sub ddlExportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlExportType.SelectedIndexChanged

        CheckUpdateStatus()
    End Sub

    Private Sub CheckUpdateStatus()

        Dim row As DataRowView = ddlExportTitle.SelectedItem
        If row Is Nothing Then
            Exit Sub
        End If

        If Not row("ShortTitle") = txtExportTitle.Text Or _
            Not row("Type") = ddlExportType.Text Or _
            Not row("ExportDate") = dtpExportDate.Value Or _
            Not row("Notes") = txtExportNotes.Text Or _
            Not row("File") = txtExportFile.Text Then

            ddlExportTitle.Enabled = False
            txtExportTitleFilter.Enabled = False
            butTitleFilterClear.Enabled = False
            cbRecipient.Enabled = False
            butRecipientFilterClear.Enabled = False
            butCommit.Enabled = False
            butImport.Enabled = False
            butDelete.Enabled = False
            butUpdate.Enabled = True
            butCancel.Enabled = True
        Else
            ddlExportTitle.Enabled = True
            txtExportTitleFilter.Enabled = True
            butTitleFilterClear.Enabled = True
            cbRecipient.Enabled = True
            butRecipientFilterClear.Enabled = True
            butCommit.Enabled = True
            butImport.Enabled = True
            butDelete.Enabled = True
            butUpdate.Enabled = False
            butCancel.Enabled = False

            'Check recipients
            'Ensure that none of the items in the list has been deleted
            'and if it has, then delete it.
            Dim db As clsDB = New clsDB
            Dim comExport As SQLiteCommand = New SQLiteCommand()
            comExport.Connection = db.conExports
            comExport.CommandText = "Select count(*) from ExportRecipient where ExportID = " & row("ExportID")
            Dim intRecipientsDB As Integer = comExport.ExecuteScalar()
            If Not intRecipientsDB = lbExportRecipients.Items.Count Then
                ddlExportTitle.Enabled = False
                txtExportTitleFilter.Enabled = False
                butTitleFilterClear.Enabled = False
                cbRecipient.Enabled = False
                butRecipientFilterClear.Enabled = False
                butCommit.Enabled = False
                butImport.Enabled = False
                butDelete.Enabled = False
                butUpdate.Enabled = True
                butCancel.Enabled = True
            Else
                Dim colListedRecipients As Collection = New Collection
                For Each recipient As clsExportRecipient In lbExportRecipients.Items
                    colListedRecipients.Add(recipient.RecipientID.ToString, recipient.RecipientID.ToString)
                Next
                Dim strSQL As String = "select RecipientID from ExportRecipient where ExportID=" & row("ExportID")
                Dim odba As SQLiteDataAdapter
                odba = New SQLiteDataAdapter(strSQL, db.conExports)
                Dim dtExportRecipient As DataTable = New DataTable()
                odba.Fill(dtExportRecipient)
                For Each rowRecipient As DataRow In dtExportRecipient.Rows
                    If Not colListedRecipients.Contains(rowRecipient("RecipientID").ToString) Then
                        ddlExportTitle.Enabled = False
                        txtExportTitleFilter.Enabled = False
                        butTitleFilterClear.Enabled = False
                        cbRecipient.Enabled = False
                        butRecipientFilterClear.Enabled = False
                        butCommit.Enabled = False
                        butImport.Enabled = False
                        butDelete.Enabled = False
                        butUpdate.Enabled = True
                        butCancel.Enabled = True
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub CancelUpdate()

        Dim row As DataRowView = ddlExportTitle.SelectedItem
        ddlExportTitle_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub txtExportFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExportFile.TextChanged

        CheckUpdateStatus()
    End Sub

    Private Sub txtExportTitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExportTitle.TextChanged

        CheckUpdateStatus()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click

        CancelUpdate()
    End Sub

    Private Sub butAddRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddRecipient.Click

        frmExportManageRecipients.ShowDialog()
        Dim recipient As clsExportRecipient

        'Ensure that none of the items in the list has been deleted
        'and if it has, then delete it.
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

            CheckUpdateStatus()
    End Sub

    Private Sub butRemoveRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemoveRecipient.Click

        If Not lbExportRecipients Is Nothing Then

            lbExportRecipients.Items.Remove(lbExportRecipients.SelectedItem)
            CheckUpdateStatus()
        End If
    End Sub

    Private Sub butUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUpdate.Click

        Dim row As DataRowView = ddlExportTitle.SelectedItem
        Dim intExportID As Integer = row("ExportID")

        If txtExportTitle.Text.Trim = "" Then
            MessageBox.Show("You must specify a title for this export.")
            Exit Sub
        End If

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        'Check that specified title isn't already used if it has changed
        If row("ShortTitle") <> txtExportTitle.Text.Trim Then
            comExport.CommandText = "Select count(*) from exports where ShortTitle like '" & txtExportTitle.Text.Trim & "'"
            If comExport.ExecuteScalar() > 0 Then
                MessageBox.Show("An export record with this short title already exists.")
                Exit Sub
            End If
        End If

        'Update the export record
        comExport.CommandText = "Update exports set ShortTitle=?, Type=?, ExportDate=?, Notes=?, File=? where ExportID=?"
        comExport.Parameters.AddWithValue("ShortTitle", txtExportTitle.Text.Trim)
        comExport.Parameters.AddWithValue("Type", ddlExportType.Text)
        comExport.Parameters.AddWithValue("ExportDate", dtpExportDate.Value)
        comExport.Parameters.AddWithValue("Notes", txtExportNotes.Text.Trim)
        comExport.Parameters.AddWithValue("File", txtExportFile.Text.Trim)
        comExport.Parameters.AddWithValue("ExportID", intExportID)
        comExport.ExecuteNonQuery()

        'Update the export/recipient relationships
        'First of all select all the recipients currently associated with this export record
        Dim strSQL As String = "select RecipientID from ExportRecipient where ExportID=" & intExportID
        Dim odba As SQLiteDataAdapter
        odba = New SQLiteDataAdapter(strSQL, db.conExports)
        Dim dtExportRecipient As DataTable = New DataTable()
        odba.Fill(dtExportRecipient)
        Dim recipient As clsExportRecipient
        Dim bRecipientFound As Boolean
        'Delete record in database no longer in list
        For Each dtRow As DataRow In dtExportRecipient.Rows
            bRecipientFound = False
            For Each recipient In lbExportRecipients.Items
                If dtRow("RecipientID") = recipient.RecipientID Then
                    bRecipientFound = True
                    Exit For
                End If
            Next
            If Not bRecipientFound Then
                comExport.Parameters.Clear()
                comExport.CommandText = "delete from ExportRecipient where ExportID=? and RecipientID=?"
                comExport.Parameters.AddWithValue("ExportID", intExportID)
                comExport.Parameters.AddWithValue("RecipientID", dtRow("RecipientID"))
                comExport.ExecuteNonQuery()
            End If
        Next
        'Insert records into database that are in list but not yet in DB
        For Each recipient In lbExportRecipients.Items
            bRecipientFound = False
            For Each dtRow As DataRow In dtExportRecipient.Rows
                If dtRow("RecipientID") = recipient.RecipientID Then
                    bRecipientFound = True
                    Exit For
                End If
            Next
            If Not bRecipientFound Then
                comExport.Parameters.Clear()
                comExport.CommandText = "Insert into ExportRecipient(ExportID, RecipientID) values(?,?)"
                comExport.Parameters.AddWithValue("ExportID", intExportID)
                comExport.Parameters.AddWithValue("RecipientID", recipient.RecipientID)
                comExport.ExecuteNonQuery()
            End If
        Next
        'Refresh the display
        PopulateForm()
        'Reselect the current item
        For Each export As DataRowView In ddlExportTitle.Items
            If export("ExportID") = intExportID Then
                ddlExportTitle.SelectedItem = export
                Exit For
            End If
        Next
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        If MessageBox.Show("Are you sure you want to delete this export history record and all associated information?", "Confirm deletion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim row As DataRowView = ddlExportTitle.SelectedItem
            Dim intExportID As Integer = row("ExportID")

            Dim db As clsDB = New clsDB
            Dim comExport As SQLiteCommand = New SQLiteCommand()
            comExport.Connection = db.conExports
            comExport.Parameters.AddWithValue("ExportID", intExportID)

            'Delete all records in the RecordExport table pertaining to this ExportID
            comExport.CommandText = "delete from RecordExport where ExportID=?"
            comExport.ExecuteNonQuery()

            'Delete all records from the RecordRecipient table pertaining to this ExportID
            comExport.CommandText = "delete from ExportRecipient where ExportID=?"
            comExport.ExecuteNonQuery()

            'Delete the record from the Exports table
            comExport.CommandText = "delete from Exports where ExportID=?"
            comExport.ExecuteNonQuery()

            PopulateForm()
        End If
    End Sub

    Private Sub cbRecipient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRecipient.SelectedIndexChanged

        PopulateForm()
    End Sub

    Private Sub cbRecipient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRecipient.TextChanged
        PopulateForm()
    End Sub

    Private Sub butRecipientFilterClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRecipientFilterClear.Click
        cbRecipient.Text = ""
    End Sub

    Private Sub butTitleFilterClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTitleFilterClear.Click
        txtExportTitleFilter.Text = ""
    End Sub

    Private Sub butImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butImport.Click


        'Dim row As DataRowView = ddlExportTitle.SelectedItem
        'If Not row Is Nothing Then
        '    If row("ShortTitle") = txtExportTitle.Text Then
        '        MessageBox.Show("You must first specify a new short title for the export")
        '        Exit Sub
        '    End If
        'End If

        'Open the CSV file containing the record IDs
        OpenFileDialog.Filter = "CSV files (*.csv)|*.csv|All files|*.*"

        OpenFileDialog.FilterIndex = 1
        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            Cursor = Cursors.WaitCursor

            Dim db As clsDB = New clsDB
            Dim comExport As SQLiteCommand = New SQLiteCommand()
            comExport.Connection = db.conExports

            'Creat a new record in the Export table
            comExport.CommandText = "Insert into exports(ShortTitle, Type,ExportDate,Notes,File) values(?,?,?,?,?)"
            comExport.Parameters.AddWithValue("ShortTitle", "New export - rename")
            comExport.Parameters.AddWithValue("Type", "CSV")
            'comExport.Parameters.Add(New SQLiteParameter("ExportDate", DbType.Date))
            Dim fiExport As FileInfo = New FileInfo(OpenFileDialog.FileName)
            'comExport.Parameters("ExportDate").Value = Format(fiExport.CreationTime, "dd/MM/yyyy")
            comExport.Parameters.AddWithValue("ExportDate", fiExport.CreationTime)
            comExport.Parameters.AddWithValue("Notes", "")
            comExport.Parameters.AddWithValue("File", OpenFileDialog.FileName)
            comExport.ExecuteNonQuery()

            comExport.CommandText = "Select last_insert_rowid()"
            Dim intExportID As Integer = comExport.ExecuteScalar

            'Insert records into ExportRecipient table
            'comExport.CommandText = "Insert into ExportRecipient(ExportID, RecipientID) values(?,?)"
            'comExport.Parameters.Clear()
            'comExport.Parameters.AddWithValue("ExportID", 0)
            'comExport.Parameters.AddWithValue("RecipientID", 0)

            'Dim recipient As clsExportRecipient
            'For Each recipient In lbExportRecipients.Items
            '    comExport.Parameters("ExportID").Value = intExportID
            '    comExport.Parameters("RecipientID").Value = recipient.RecipientID
            '    comExport.ExecuteNonQuery()
            'Next

            'Create schema
            Dim dt As DataTable = New DataTable
            DeleteSchema(OpenFileDialog.FileName)
            LoadCSVFile(OpenFileDialog.FileName, dt, False)
            CreateSchema(OpenFileDialog.FileName, dt)
            dt.Clear()
            dt.Columns.Clear()

            'Insert records into RecordExport table
            LoadCSVFile(OpenFileDialog.FileName, dt, True)
            comExport.CommandText = "begin transaction"
            comExport.ExecuteNonQuery()

            comExport.CommandText = "Insert into RecordExport(ExportID, RecordID, RecDateMod) values(?,?, ?)"
            comExport.Parameters.Clear()
            comExport.Parameters.AddWithValue("ExportID", intExportID)
            comExport.Parameters.AddWithValue("RecordID", 0)
            comExport.Parameters.AddWithValue("RecDateMod", Nothing)

            Dim comModDate As SQLiteCommand = New SQLiteCommand()
            comModDate.Connection = db.conMain
            comModDate.CommandText = "select Modified from Records where ID=?"
            comModDate.Parameters.AddWithValue("ID", 0)

            'Expecting to find the ID in the first column
            For Each rowID As DataRow In dt.Rows
                If Integer.TryParse(rowID(0), Nothing) Then
                    comModDate.Parameters("ID").Value = rowID(0)
                    comExport.Parameters("RecordID").Value = rowID(0)
                    comExport.Parameters("RecDateMod").Value = comModDate.ExecuteScalar
                    comExport.ExecuteNonQuery()
                End If
            Next

            comExport.CommandText = "commit"
            comExport.ExecuteNonQuery()

            PopulateForm()

            'Reselect the current item
            For Each export As DataRowView In ddlExportTitle.Items
                If export("ExportID") = intExportID Then
                    ddlExportTitle.SelectedItem = export
                    Exit For
                End If
            Next

            Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub CreateSchema(ByVal strFilename As String, ByVal dt As DataTable)

        Dim sFileName As String
        Dim sPathName As String
        Dim sIniFile As String
        Dim sw As StreamWriter
        Dim iCol As Integer = 0
        Dim col As DataColumn

        'Create the schema ini file
        sPathName = System.IO.Path.GetDirectoryName(strFilename)
        sFileName = System.IO.Path.GetFileName(strFilename)
        sIniFile = System.IO.Path.Combine(sPathName, "schema.ini")

        sw = New StreamWriter(sIniFile)

        sw.WriteLine("[" & sFileName & "]")
        sw.WriteLine("ColNameHeader = True")
        For Each col In dt.Columns
            iCol = iCol + 1
            sw.WriteLine("Col" & iCol.ToString() & "=""" & col.ColumnName & """ Text")
        Next
        sw.Close()
    End Sub

    Private Sub DeleteSchema(ByVal strFilename As String)

        Dim sFileName As String
        Dim sPathName As String
        Dim sIniFile As String

        'Delete the schema ini file if it exists already
        sPathName = System.IO.Path.GetDirectoryName(strFilename)
        sFileName = System.IO.Path.GetFileName(strFilename)
        sIniFile = System.IO.Path.Combine(sPathName, "schema.ini")

        If File.Exists(sIniFile) Then
            File.Delete(sIniFile)
        End If
    End Sub

    Private Sub LoadCSVFile(ByVal strFilename As String, ByVal dt As DataTable, ByVal bData As Boolean)

        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim sFileName As String
        Dim sPathName As String

        Dim sRows As String = ""
        If Not bData Then
            sRows = "top 1"
        End If

        sPathName = System.IO.Path.GetDirectoryName(strFilename)
        'Connect to the CSV folder
        MyConnection = New System.Data.OleDb.OleDbConnection( _
             "provider=Microsoft.Jet.OLEDB.4.0; " & _
             "data source=" & sPathName & "; " & _
             "Extended Properties=""text;HDR=Yes;IMEX=1;FMT=Delimited"";")
        MyConnection.Open()

        'Select the data from relevant CSV file
        sFileName = System.IO.Path.GetFileName(strFilename)
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select " & sRows & " * from [" & sFileName & "]", MyConnection)
        MyCommand.Fill(dt)
        MyConnection.Close()

        MyCommand.Dispose()
        MyConnection.Dispose()
    End Sub

    Private Sub dtpExportDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpExportDate.ValueChanged

        CheckUpdateStatus()
    End Sub
End Class