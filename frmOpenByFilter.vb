Imports System.IO
Imports System.Data.SQLite

Public Class frmOpenByFilter

    Dim bSuppressEvent As Boolean = False
    Private strUndoValue = ""
    Private strExportFilterType = ""
    Private colCheckedExports As Collection = New Collection
    Private strRecipientFilterType = ""
    Private colCheckedRecipients As Collection = New Collection

    Private bOkayed As Boolean

    Public ReadOnly Property Okayed() As Boolean
        Get
            Return bOkayed
        End Get
    End Property

    Dim strSQL As String

    Public ReadOnly Property SQL() As String
        Get
            Return strSQL
        End Get
    End Property

    Dim strBoundaryFile As String

    Public ReadOnly Property BoundaryFile() As String
        Get
            Return strBoundaryFile
        End Get
    End Property

    Dim strExportType As String

    Public ReadOnly Property ExportType() As String
        Get
            Return strExportType
        End Get
    End Property

    Dim strRecipientType As String

    Public ReadOnly Property RecipientType() As String
        Get
            Return strRecipientType
        End Get
    End Property

    Private Sub butCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCommit.Click

        Dim strOp As String

        strSQL = ""

        If txtCommonName.Text.Trim <> "" Then
            strSQL = "CommonName like '%" & txtCommonName.Text & "%' and "
        End If

        If txtScientificName.Text.Trim <> "" Then
            strSQL = strSQL & "ScientificName like '%" & txtScientificName.Text & "%' and "
        End If

        If txtTaxonGroup.Text.Trim <> "" Then
            strSQL = strSQL & "TaxonGroup like '%" & txtTaxonGroup.Text & "%' and "
        End If

        If txtComment.Text.Trim <> "" Then
            strSQL = strSQL & "Comment like '%" & txtComment.Text & "%' and "
        End If

        If txtPersonalNotes.Text.Trim <> "" Then
            strSQL = strSQL & "PersonalNotes like '%" & txtPersonalNotes.Text & "%' and "
        End If

        If Not cbIncludeExcluded.Checked Then
            strSQL = strSQL & "NoExport = 0 and "
        End If

        If cbOnAfterAfter.Checked Or cbOnAfterOn.Checked Then
            If cbOnAfterAfter.Checked And cbOnAfterOn.Checked Then
                strOp = ">="
            ElseIf cbOnAfterAfter.Checked Then
                strOp = ">"
            Else
                strOp = "="
            End If

            strSQL = strSQL & "julianday(RecDate) " & strOp & " julianday('" & dtpOnAfter.Value.ToString("yyyy-MM-dd") & "') and "
        End If

        If cbOnBeforeBefore.Checked Or cbOnBeforeOn.Checked Then
            If cbOnBeforeBefore.Checked And cbOnBeforeOn.Checked Then
                strOp = "<="
            ElseIf cbOnBeforeBefore.Checked Then
                strOp = "<"
            Else
                strOp = "="
            End If

            strSQL = strSQL & "julianday(RecDate) " & strOp & " julianday('" & dtpOnBefore.Value.ToString("yyyy-MM-dd") & "') and "
        End If

        'If there's any SQL specified by user, then joing this with an AND
        'clause, enclosing the user-specified stuff in parentheses.
        If txtSQL.Text.Trim.Length > 0 Then
            If strSQL.Length = 0 Then
                strSQL = txtSQL.Text
            Else
                strSQL = strSQL & "(" & txtSQL.Text & ")"
            End If
        End If

        strSQL = strSQL.Trim
        If strSQL.EndsWith(" and") Then
            strSQL = strSQL.Substring(0, strSQL.Length - 4)
        End If

        strBoundaryFile = txtBoundaryFile.Text.Trim

        bOkayed = True

        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click

        Me.Close()
    End Sub

    Private Sub EnableDateCheckboxState()

        If cbOnAfterAfter.Checked Or cbOnAfterOn.Checked Then

            dtpOnAfter.Enabled = True
        Else
            dtpOnAfter.Enabled = False
        End If

        If cbOnBeforeBefore.Checked Or cbOnBeforeOn.Checked Then

            dtpOnBefore.Enabled = True
        Else
            dtpOnBefore.Enabled = False
        End If

        CheckLights()
    End Sub

    Private Sub butClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClear.Click

        txtCommonName.Text = ""
        txtScientificName.Text = ""
        txtTaxonGroup.Text = ""
        txtComment.Text = ""
        txtPersonalNotes.Text = ""
        txtBoundaryFile.Text = ""

        cbOnAfterAfter.Checked = False
        cbOnAfterOn.Checked = False
        cbOnBeforeBefore.Checked = False
        cbOnBeforeOn.Checked = False
        EnableDateCheckboxState()

        txtSQL.Text = ""
        txtBoundaryFile.Text = ""

        cbExportFilterType.SelectedIndex = 0
        cbRecipientFilterType.SelectedIndex = 0
    End Sub

    Private Sub frmOpenByFilter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        SaveExportRecipientState()
    End Sub

    Private Sub frmOpenByFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BuildSQLMenus()
        butCommit.Focus()

    End Sub

    Private Sub BuildSQLMenus()

        If cmsSQL.Items.Count > 0 Then
            Exit Sub
        End If

        Dim tsmi As ToolStripMenuItem
        Dim tsmi2 As ToolStripMenuItem
        Dim sep As ToolStripSeparator

        tsmi = New ToolStripMenuItem
        tsmi.Text = "Clear"
        tsmi.Tag = "Clear"
        AddHandler tsmi.Click, AddressOf cmsSQL_Click
        cmsSQL.Items.Add(tsmi)

        tsmi = New ToolStripMenuItem
        tsmi.Text = "Undo"
        tsmi.Tag = "Undo"
        AddHandler tsmi.Click, AddressOf cmsSQL_Click
        cmsSQL.Items.Add(tsmi)

        tsmi = New ToolStripMenuItem
        tsmi.Text = "Move to end"
        tsmi.Tag = "End"
        AddHandler tsmi.Click, AddressOf cmsSQL_Click
        cmsSQL.Items.Add(tsmi)

        sep = New ToolStripSeparator
        cmsSQL.Items.Add(sep)

        tsmi = New ToolStripMenuItem
        tsmi.Text = "Operators etc"
        cmsSQL.Items.Add(tsmi)

        tsmi2 = New ToolStripMenuItem
        tsmi2.Text = "And"
        tsmi2.Tag = " And "
        AddHandler tsmi2.Click, AddressOf cmsSQL_Click
        tsmi.DropDownItems.Add(tsmi2)

        tsmi2 = New ToolStripMenuItem
        tsmi2.Text = "Or"
        tsmi2.Tag = " Or "
        AddHandler tsmi2.Click, AddressOf cmsSQL_Click
        tsmi.DropDownItems.Add(tsmi2)

        tsmi2 = New ToolStripMenuItem
        tsmi2.Text = ","
        tsmi2.Tag = ","
        AddHandler tsmi2.Click, AddressOf cmsSQL_Click
        tsmi.DropDownItems.Add(tsmi2)

        tsmi2 = New ToolStripMenuItem
        tsmi2.Text = "("
        tsmi2.Tag = "("
        AddHandler tsmi2.Click, AddressOf cmsSQL_Click
        tsmi.DropDownItems.Add(tsmi2)

        tsmi2 = New ToolStripMenuItem
        tsmi2.Text = ")"
        tsmi2.Tag = ")"
        AddHandler tsmi2.Click, AddressOf cmsSQL_Click
        tsmi.DropDownItems.Add(tsmi2)

        sep = New ToolStripSeparator
        cmsSQL.Items.Add(sep)

        Dim rms As clsRecordMappings = New clsRecordMappings
        Dim rm As clsRecordMapping

        For Each rm In rms

            If Not rm.DBType = OleDb.OleDbType.Binary Then

                tsmi = New ToolStripMenuItem
                tsmi.Text = rm.DBFieldName
                AddHandler tsmi.Click, AddressOf cmsSQL_Click
                cmsSQL.Items.Add(tsmi)

                Select Case rm.DBType

                    Case OleDb.OleDbType.Date
                        'strftime('%d-%m-%Y', ?) 
                        Dim tsmiDateToday As New ToolStripMenuItem
                        tsmiDateToday.Text = "Date is today"
                        tsmiDateToday.Tag = "Date(" & rm.DBFieldName & ") = '" & Format(Now(), "yyyy-MM-dd") & "'"
                        AddHandler tsmiDateToday.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateToday)

                        Dim tsmiDateE As New ToolStripMenuItem
                        tsmiDateE.Text = "Date is"
                        tsmiDateE.Tag = "Date(" & rm.DBFieldName & ") = 'yyyy-mm-dd'"
                        AddHandler tsmiDateE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateE)

                        Dim tsmiDateLTE As New ToolStripMenuItem
                        tsmiDateLTE.Text = "Date on or before"
                        tsmiDateLTE.Tag = "julianday(" & rm.DBFieldName & ") <= julianday('yyyy-mm-dd')"
                        AddHandler tsmiDateLTE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateLTE)

                        Dim tsmiDateLT As New ToolStripMenuItem
                        tsmiDateLT.Text = "Date before"
                        tsmiDateLT.Tag = "julianday(" & rm.DBFieldName & ") < julianday('yyyy-mm-dd')"
                        AddHandler tsmiDateLT.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateLT)

                        Dim tsmiDateGTE As New ToolStripMenuItem
                        tsmiDateGTE.Text = "Date on or after"
                        tsmiDateGTE.Tag = "julianday(" & rm.DBFieldName & ") >= julianday('yyyy-mm-dd')"
                        AddHandler tsmiDateGTE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateGTE)

                        Dim tsmiDateGT As New ToolStripMenuItem
                        tsmiDateGT.Text = "Date after"
                        tsmiDateGT.Tag = "julianday(" & rm.DBFieldName & ") > julianday('yyyy-mm-dd')"
                        AddHandler tsmiDateGT.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiDateGT)

                    Case OleDb.OleDbType.Double, OleDb.OleDbType.Integer

                        Dim tsmiNumE As New ToolStripMenuItem
                        tsmiNumE.Text = "Equals"
                        tsmiNumE.Tag = rm.DBFieldName & " = ??"
                        AddHandler tsmiNumE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiNumE)

                        Dim tsmiNumLTE As New ToolStripMenuItem
                        tsmiNumLTE.Text = "Less than or equals"
                        tsmiNumLTE.Tag = rm.DBFieldName & " <= ??"
                        AddHandler tsmiNumLTE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiNumLTE)

                        Dim tsmiNumLT As New ToolStripMenuItem
                        tsmiNumLT.Text = "Less than"
                        tsmiNumLT.Tag = rm.DBFieldName & " < ??"
                        AddHandler tsmiNumLT.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiNumLT)

                        Dim tsmiNumGTE As New ToolStripMenuItem
                        tsmiNumGTE.Text = "Greater than or equals"
                        tsmiNumGTE.Tag = rm.DBFieldName & " >= ??"
                        AddHandler tsmiNumGTE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiNumGTE)

                        Dim tsmiNumGT As New ToolStripMenuItem
                        tsmiNumGT.Text = "Greater than"
                        tsmiNumGT.Tag = rm.DBFieldName & " > ??"
                        AddHandler tsmiNumGT.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiNumGT)

                    Case OleDb.OleDbType.Boolean

                        Dim tsmiBoolT As New ToolStripMenuItem
                        tsmiBoolT.Text = "True"
                        tsmiBoolT.Tag = rm.DBFieldName & " = True"
                        AddHandler tsmiBoolT.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiBoolT)

                        Dim tsmiBoolF As New ToolStripMenuItem
                        tsmiBoolF.Text = "False"
                        tsmiBoolF.Tag = rm.DBFieldName & " = False"
                        AddHandler tsmiBoolF.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiBoolF)

                    Case Else

                        'Must be text
                        Dim tsmiTextE As New ToolStripMenuItem
                        tsmiTextE.Text = "Equals"
                        tsmiTextE.Tag = rm.DBFieldName & " = 'search string'"
                        AddHandler tsmiTextE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextE)

                        Dim tsmiTextNE As New ToolStripMenuItem
                        tsmiTextNE.Text = "Not equals"
                        tsmiTextNE.Tag = rm.DBFieldName & " <> 'search string'"
                        AddHandler tsmiTextNE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextNE)

                        Dim tsmiTextNothing As New ToolStripMenuItem
                        tsmiTextNothing.Text = "Is nothing"
                        tsmiTextNothing.Tag = rm.DBFieldName & " = '' or " & rm.DBFieldName & " is null"
                        AddHandler tsmiTextNothing.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextNothing)

                        Dim tsmiTextLike As New ToolStripMenuItem
                        tsmiTextLike.Text = "Like"
                        tsmiTextLike.Tag = rm.DBFieldName & " like '%search string%'"
                        AddHandler tsmiTextLike.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextLike)

                        Dim tsmiTextCIE As New ToolStripMenuItem
                        tsmiTextCIE.Text = "Case insensitive equals"
                        tsmiTextCIE.Tag = "lcase(" & rm.DBFieldName & ") = 'lower case search string'"
                        AddHandler tsmiTextCIE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextCIE)

                        Dim tsmiTextCINE As New ToolStripMenuItem
                        tsmiTextCINE.Text = "Case insensitive not equals"
                        tsmiTextCINE.Tag = "lcase(" & rm.DBFieldName & ") <> 'lower case search string'"
                        AddHandler tsmiTextCINE.Click, AddressOf cmsSQL_Click
                        tsmi.DropDownItems.Add(tsmiTextCINE)
                End Select
            End If
        Next
    End Sub

    Private Sub butBrowseBoundary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseBoundary.Click

        OpenFileDialog.Filter = "Text files (*.txt)|*.txt|Google Earth files (*.kml)|*.kml|MIF files (*.mif)|*.mif|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 0

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then
            txtBoundaryFile.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub frmOpenByFilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        PopulateExportFilters()
        PopulateSQLControls()
        bOkayed = False
        CheckLights()
    End Sub

    Private Sub PopulateSQLControls()

        Dim strCurrentSQL = txtSQL.Text

        Dim db As clsDB = New clsDB

        Dim da As SQLiteDataAdapter = New SQLiteDataAdapter("Select QuerySQL, QueryName from WhereClause", db.conMain)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)

        Dim vals() As String = {"", "New query"}
        dt.Rows.Add(vals)

        cboQueries.DataSource = dt
        cboQueries.DisplayMember = "QueryName"

        'txtSQL.DataBindings.Clear()
        'txtSQL.DataBindings.Add("Text", dt, "QuerySQL")

        cboQueries.SelectedIndex = cboQueries.Items.Count - 1

        txtSQL.Text = strCurrentSQL
    End Sub

    Private Sub PopulateExportFilters()

        Dim drv As DataRowView
        Dim i As Integer

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        'Exports list
        clbExports.DataSource = Nothing
        clbExports.Items.Clear()

        Dim strSQL As String = "Select * from exports order by ShortTitle"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conExports)
        Dim dt As DataTable = New DataTable()

        If odba.Fill(dt) > 0 Then
            clbExports.DataSource = dt
            clbExports.ValueMember = "ExportID"
            clbExports.DisplayMember = "ShortTitle"
        End If

        'Select previously selected values
        cbExportFilterType.SelectedIndex = 0
        For i = 0 To cbExportFilterType.Items.Count - 1
            If cbExportFilterType.Items(i) = strExportFilterType Then
                cbExportFilterType.SelectedIndex = i
            End If
        Next
        For Each strExport As String In colCheckedExports
            For i = 0 To clbExports.Items.Count - 1
                drv = clbExports.Items(i)
                If drv("ShortTitle") = strExport Then
                    clbExports.SetItemCheckState(i, CheckState.Checked)
                End If
            Next
        Next

        'Recipients list
        clbRecipient.DataSource = Nothing
        clbRecipient.Items.Clear()

        strSQL = "Select * from recipients order by name"
        odba = New SQLiteDataAdapter(strSQL, db.conExports)
        dt = New DataTable()
        If odba.Fill(dt) > 0 Then
            clbRecipient.DataSource = dt
            clbRecipient.ValueMember = "RecipientID"
            clbRecipient.DisplayMember = "Name"
        End If

        'Select previously selected values
        cbRecipientFilterType.SelectedIndex = 0
        For i = 0 To cbRecipientFilterType.Items.Count - 1
            If cbRecipientFilterType.Items(i) = strRecipientFilterType Then
                cbRecipientFilterType.SelectedIndex = i
            End If
        Next
        For Each strRecipient As String In colCheckedRecipients
            For i = 0 To clbRecipient.Items.Count - 1
                drv = clbRecipient.Items(i)
                If drv("Name") = strRecipient Then
                    clbRecipient.SetItemCheckState(i, CheckState.Checked)
                End If
            Next
        Next
    End Sub

    Private Sub cbExportFilterType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExportFilterType.SelectedIndexChanged

        If cbExportFilterType.SelectedIndex = 0 Then
            strExportType = ""
            For Each i As Integer In clbExports.CheckedIndices
                clbExports.SetItemCheckState(i, CheckState.Unchecked)
            Next
            clbExports.Enabled = False
        Else
            strExportType = cbExportFilterType.Text
            clbExports.Enabled = True
            cbRecipientFilterType.SelectedIndex = 0

            If Not (cbExportFilterType.Text = "Records included in" Or _
                cbExportFilterType.Text = "Records not included in") Then

                If clbExports.CheckedItems.Count > 1 Then
                    For Each i As Integer In clbExports.CheckedIndices
                        clbExports.SetItemCheckState(i, CheckState.Unchecked)
                    Next
                End If
            End If
        End If
        CheckLights()
    End Sub

    Private Sub cbRecipientFilterType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRecipientFilterType.SelectedIndexChanged

        If cbRecipientFilterType.SelectedIndex = 0 Then
            strRecipientType = ""
            For Each i As Integer In clbRecipient.CheckedIndices
                clbRecipient.SetItemCheckState(i, CheckState.Unchecked)
            Next
            clbRecipient.Enabled = False
        Else
            strRecipientType = cbRecipientFilterType.Text
            clbRecipient.Enabled = True
            cbExportFilterType.SelectedIndex = 0
        End If
        CheckLights()
    End Sub

    Private Sub clbExports_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbExports.ItemCheck

        If bSuppressEvent Then Exit Sub

        If Not (cbExportFilterType.Text = "Records included in" Or _
            cbExportFilterType.Text = "Records not included in") Then

            bSuppressEvent = True
            For Each i As Integer In clbExports.CheckedIndices

                If i <> e.Index Then
                    clbExports.SetItemCheckState(i, CheckState.Unchecked)
                End If
            Next
            bSuppressEvent = False
        End If
    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        Dim bModify As Boolean = False
        Dim strNewQuery As String

        If txtSQL.Text.Trim.Length = 0 Then
            MessageBox.Show("First you must specify some SQL for the saved query.")
            Exit Sub
        End If

        If cboQueries.Text.Trim.Length = 0 Then
            MessageBox.Show("First you must specify a name for your new saved query.")
            Exit Sub
        End If

        If cboQueries.Text = "New query" Then
            MessageBox.Show("First you must specify a new name for your new saved query.")
            Exit Sub
        End If

        Dim row As DataRowView
        For Each row In cboQueries.Items
            If row("QueryName") = cboQueries.Text.Trim Then
                If MessageBox.Show("This query name is already in use - do you want to modify the existing query?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    bModify = True
                Else
                    Exit Sub
                End If
            End If
        Next

        Dim db As clsDB = New clsDB

        Dim com As SQLiteCommand = New SQLiteCommand
        com.Connection = db.conMain
        If bModify Then
            com.CommandText = "Update  WhereClause set QuerySQL = ? where QueryName = ?"
            com.Parameters.AddWithValue("QuerySQL", txtSQL.Text.Trim)
            com.Parameters.AddWithValue("QueryName", cboQueries.Text.Trim)
        Else
            com.CommandText = "Insert into WhereClause(QuerySQL, QueryName) values(?,?)"
            com.Parameters.AddWithValue("QuerySQL", txtSQL.Text.Trim)
            com.Parameters.AddWithValue("QueryName", cboQueries.Text.Trim)
        End If

        com.ExecuteNonQuery()

        'Re-init SQL controls
        strNewQuery = cboQueries.Text.Trim
        PopulateSQLControls()
        'Re-select the new or modified query
        For Each row In cboQueries.Items
            If row("QueryName") = strNewQuery Then
                cboQueries.SelectedItem = row
                Exit For
            End If
        Next
    End Sub

    Private Sub cmsSQL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmsSQL.Click

        If sender.Tag = "" Then
            Exit Sub
        End If

        Dim strCurrentValue = txtSQL.Text

        Select Case sender.tag

            Case "Clear"
                txtSQL.Text = ""
            Case "Undo"
                txtSQL.Text = strUndoValue
            Case "End"
                txtSQL.SelectionStart = txtSQL.Text.Length
                txtSQL.SelectionLength = 0
            Case Else
                Dim iSelStart As Integer = txtSQL.SelectionStart

                txtSQL.Text = txtSQL.Text.Insert(iSelStart, sender.tag)

                txtSQL.Focus()

                If sender.tag.ToString.Contains("yyyy-mm-dd") Then
                    txtSQL.SelectionStart = iSelStart + InStr(sender.tag, "yyyy-mm-dd") - 1
                    txtSQL.SelectionLength = 10
                ElseIf sender.tag.ToString.Contains("??") Then
                    txtSQL.SelectionStart = iSelStart + InStr(sender.tag, "??") - 1
                    txtSQL.SelectionLength = 2
                ElseIf sender.tag.ToString.Contains("lower case search string") Then
                    txtSQL.SelectionStart = iSelStart + InStr(sender.tag, "lower case search string") - 1
                    txtSQL.SelectionLength = 24
                ElseIf sender.tag.ToString.Contains("search string") Then
                    txtSQL.SelectionStart = iSelStart + InStr(sender.tag, "search string") - 1
                    txtSQL.SelectionLength = 13
                Else
                    txtSQL.SelectionStart = iSelStart + sender.tag.ToString.Length
                    txtSQL.SelectionLength = 0
                End If
        End Select

        Application.DoEvents()
        strUndoValue = strCurrentValue
    End Sub

    Private Sub txtSQL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSQL.TextChanged

        strUndoValue = txtSQL.Text
        CheckLights()
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        If cboQueries.SelectedIndex = -1 Then
            MessageBox.Show("First you must select an existing query to delete.")
            Exit Sub
        Else
            If MessageBox.Show("Are you sure that you want to delete the query '" & cboQueries.Text & "'?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim db As clsDB = New clsDB

        Dim com As SQLiteCommand = New SQLiteCommand("Delete from WhereClause where QueryName=?", db.conMain)
        com.Parameters.AddWithValue("QueryName", cboQueries.Text.Trim)

        com.ExecuteNonQuery()

        'Re-init SQL controls
        PopulateSQLControls()
    End Sub

    Private Sub cbOnAfterOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnAfterOn.CheckedChanged
        EnableDateCheckboxState()
    End Sub

    Private Sub cbOnAfterAfter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnAfterAfter.CheckedChanged
        EnableDateCheckboxState()
    End Sub

    Private Sub cbOnBeforeOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnBeforeOn.CheckedChanged
        EnableDateCheckboxState()
    End Sub

    Private Sub cbOnBeforeBefore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnBeforeBefore.CheckedChanged
        EnableDateCheckboxState()
    End Sub

    Private Sub cboQueries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQueries.SelectedIndexChanged

        Dim row As DataRowView = cboQueries.SelectedItem
        txtSQL.Text = row("QuerySQL")
    End Sub

    Private Sub SaveExportRecipientState()

        strExportFilterType = cbExportFilterType.Text
        strRecipientFilterType = cbRecipientFilterType.Text
        Dim drv As DataRowView

        colCheckedExports.Clear()
        For Each drv In clbExports.CheckedItems
            colCheckedExports.Add(drv("ShortTitle"), drv("ShortTitle"))
        Next

        colCheckedRecipients.Clear()
        For Each drv In clbRecipient.CheckedItems
            colCheckedRecipients.Add(drv("Name"), drv("Name"))
        Next
    End Sub

    Private Sub rbFilteredRecords_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFilteredRecords.CheckedChanged
        AllOrFiltered()
    End Sub

    Private Sub AllOrFiltered()

        If rbAllRecords.Checked Then
            butClear_Click(Nothing, Nothing)
            TabControl1.SelectedIndex = 0
            TabControl1.Enabled = False
        Else
            TabControl1.Enabled = True
        End If
    End Sub

    Private Sub rbAllRecords_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllRecords.CheckedChanged
        AllOrFiltered()
    End Sub

    Private Sub CheckLights()

        'Easy select tab
        If txtCommonName.Text.Trim.Length > 0 Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf txtScientificName.Text.Length > 0 Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf txtTaxonGroup.Text.Length > 0 Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf txtComment.Text.Length > 0 Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf txtPersonalNotes.Text.Length > 0 Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf dtpOnAfter.Enabled Then
            TabControl1.TabPages(0).ImageIndex = 0
        ElseIf dtpOnBefore.Enabled Then
            TabControl1.TabPages(0).ImageIndex = 0
        Else
            TabControl1.TabPages(0).ImageIndex = 1
        End If

        'SQL select
        If txtSQL.Text.Length > 0 Then
            TabControl1.TabPages(1).ImageIndex = 0
        Else
            TabControl1.TabPages(1).ImageIndex = 1
        End If

        'Boundary select
        If txtBoundaryFile.Text.Length > 0 Then
            TabControl1.TabPages(2).ImageIndex = 0
        Else
            TabControl1.TabPages(2).ImageIndex = 1
        End If

        'Export select
        If cbExportFilterType.SelectedIndex > 0 Then
            TabControl1.TabPages(3).ImageIndex = 0
        ElseIf cbRecipientFilterType.SelectedIndex > 0 Then
            TabControl1.TabPages(3).ImageIndex = 0
        Else
            TabControl1.TabPages(3).ImageIndex = 1
        End If
    End Sub

    Private Sub txtCommonName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommonName.TextChanged
        CheckLights()
    End Sub

    Private Sub txtScientificName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScientificName.TextChanged
        CheckLights()
    End Sub

    Private Sub txtTaxonGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxonGroup.TextChanged
        CheckLights()
    End Sub

    Private Sub txtComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComment.TextChanged
        CheckLights()
    End Sub

    Private Sub txtPersonalNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersonalNotes.TextChanged
        CheckLights()
    End Sub

    Private Sub txtBoundaryFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoundaryFile.TextChanged
        CheckLights()
    End Sub
End Class