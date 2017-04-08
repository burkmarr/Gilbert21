Imports System.IO
Imports System.Data.SQLite

Public Class frmExportManageRecipients

    Dim intCurrentRecipientID As Integer = 0
    Dim intUpdatedRecipientID As Integer = 0
    Dim strCurrentNote As String = ""
    Dim strCurrentRecipient As String = ""

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click

        intRecipientID = 0
        strRecipientName = ""

        Me.Close()
    End Sub

    Private Sub SetFormState()

        'Add button
        If txtRecipient.Text.Trim = "" Then
            butAdd.Enabled = False
        ElseIf txtRecipient.Text = strCurrentRecipient Then
            butAdd.Enabled = False
        Else
            butAdd.Enabled = True
        End If

        'Delete button
        If lbRecipients.SelectedItem Is Nothing Then
            butDelete.Enabled = False
        ElseIf Not txtRecipient.Text = strCurrentRecipient Then
            butDelete.Enabled = False
        ElseIf Not txtNote.Text = strCurrentNote Then
            butDelete.Enabled = False
        Else
            butDelete.Enabled = True
        End If

        'Recipient list box and update, cancel and close buttons
        If Not txtNote.Text = strCurrentNote Or Not txtRecipient.Text = strCurrentRecipient Then
            lbRecipients.Enabled = False
            If txtRecipient.Text.Trim = "" Then
                butUpdate.Enabled = False
            Else
                butUpdate.Enabled = True
            End If
            butCancel.Enabled = True
            butSelect.Enabled = False
            butClose.Enabled = False
        Else
            lbRecipients.Enabled = True
            butUpdate.Enabled = False
            butCancel.Enabled = False
            butSelect.Enabled = True
            butClose.Enabled = True
        End If
    End Sub
    Private Sub PopulateList()

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        'Recipients list
        lbRecipients.DataSource = Nothing
        lbRecipients.DisplayMember = "Name"
        lbRecipients.ValueMember = "RecipientID"
        lbRecipients.Items.Clear()

        Dim strSQL As String = "Select * from recipients order by name"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conExports)
        Dim dtExport As DataTable = New DataTable()
        If odba.Fill(dtExport) > 0 Then
            lbRecipients.DataSource = dtExport
        End If

        'Select updated item if appropriate
        If intUpdatedRecipientID > 0 Then
            For Each row As DataRowView In lbRecipients.Items
                If row("RecipientID") = intUpdatedRecipientID Then
                    lbRecipients.SelectedItem = row
                    Exit For
                End If
            Next
        End If
        intUpdatedRecipientID = 0

        SetFormState()
    End Sub

    Private Sub frmExportManageRecipients_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        PopulateList()
        intRecipientID = 0
        strRecipientName = ""
    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        'Check that name not already in use
        comExport.CommandText = "Select count(*) from recipients where name like ?"
        comExport.Parameters.AddWithValue("Name", txtRecipient.Text.Trim)
        If comExport.ExecuteScalar() > 0 Then
            MessageBox.Show("A recipient with this name is already recorded.")
            Exit Sub
        End If

        comExport.CommandText = "Insert into recipients(Name, Notes) values(?,?)"
        comExport.Parameters.AddWithValue("Notes", txtNote.Text.Trim)
        comExport.ExecuteNonQuery()

        comExport.CommandText = "Select last_insert_rowid()"
        intUpdatedRecipientID = comExport.ExecuteScalar
        PopulateList()
    End Sub

    Private Sub lbRecipients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRecipients.DoubleClick

        butSelect_Click(Nothing, Nothing)
    End Sub

    Private Sub lbRecipients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRecipients.SelectedIndexChanged

        If lbRecipients.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        Dim row As DataRowView = lbRecipients.SelectedItem
        intCurrentRecipientID = row("RecipientID")

        txtRecipient.Text = row("Name")
        strCurrentRecipient = txtRecipient.Text

        txtNote.Text = row("Notes")
        strCurrentNote = txtNote.Text

        SetFormState()
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        Dim db As clsDB = New clsDB
        Dim com As SQLiteCommand = New SQLiteCommand()
        com.Connection = db.conExports

        'Is the recipient referenced by any exports? If so then tell user and
        'don't do the deletion

        com.CommandText = "Select count(*) from ExportRecipient where RecipientID = " & intCurrentRecipientID
        If com.ExecuteScalar > 0 Then
            MessageBox.Show("This recipient is referenced by previous exports. You will need to remove it from those exports before you can delete it.", "Cannot delete")
        Else
            If MessageBox.Show("Are you sure that you want to delete this recipient?", "Confirm deletion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                com.CommandText = "Delete from recipients where RecipientID = " & intCurrentRecipientID
                com.ExecuteNonQuery()
                PopulateList()
            End If
        End If
    End Sub

    Private Sub butUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUpdate.Click

        If lbRecipients.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Dim row As DataRowView = lbRecipients.SelectedItem
        Dim intRecipientID As Integer = row("RecipientID")

        If MessageBox.Show("Are you sure you want to update the recipient '" & row("Name") & "'?", "Update record", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim db As clsDB = New clsDB
            Dim comExport As SQLiteCommand = New SQLiteCommand()
            comExport.Connection = db.conExports

            comExport.CommandText = "Update recipients set Name=?, Notes=? where RecipientID=?"
            comExport.Parameters.AddWithValue("Name", txtRecipient.Text.Trim)
            comExport.Parameters.AddWithValue("Notes", txtNote.Text.Trim)
            comExport.Parameters.AddWithValue("RecipientID", intRecipientID)
            comExport.ExecuteNonQuery()

            intUpdatedRecipientID = intRecipientID

            PopulateList()
        End If
    End Sub

    Private Sub txtRecipient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipient.TextChanged
        SetFormState()
    End Sub

    Private Sub txtNote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.TextChanged
        SetFormState()
    End Sub

    Private intRecipientID As Integer
    Public ReadOnly Property RecipientID() As Integer
        Get
            Return intRecipientID
        End Get
    End Property

    Private strRecipientName As String
    Public ReadOnly Property RecipientName() As String
        Get
            Return strRecipientName
        End Get
    End Property

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click

        txtNote.Text = strCurrentNote
        txtRecipient.Text = strCurrentRecipient
    End Sub

    Private Sub butSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelect.Click

        If Not lbRecipients.SelectedItem Is Nothing Then

            Dim row As DataRowView = lbRecipients.SelectedItem
            intRecipientID = row("RecipientID")
            strRecipientName = row("Name")
        Else
            intRecipientID = 0
            strRecipientName = ""
        End If

        Me.Close()
    End Sub

    Private Sub butClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClear.Click
        txtRecipient.Text = ""
        txtNote.Text = ""
    End Sub
End Class