Imports System.Data.SQLite
Imports System.IO

Public Class frmManageTaxonDictionary

    Private Sub frmManageTaxonDictionary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim db As clsDB = New clsDB

        Dim comMain As SQLiteCommand = New SQLiteCommand()
        comMain.Connection = db.conMain

        Dim strSQL As String = "Select * from TaxonDictionary"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMain)

        Dim dtTaxa As DataTable = New DataTable()

        If odba.Fill(dtTaxa) > 0 Then

            dgvTaxa.DataSource = dtTaxa
        End If
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        If dgvTaxa.SelectedRows.Count <> 1 Then

            MessageBox.Show("You must select a single row to delete a record.")
            Exit Sub
        End If

        If MessageBox.Show("Are you sure that you want to delete this row from Taxon dictionary?", "Confirm deletion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim db As clsDB = New clsDB

            Dim com As SQLiteCommand = New SQLiteCommand()
            com.Connection = db.conMain
            com.CommandText = "Delete from TaxonDictionary where ID = " & dgvTaxa.SelectedRows(0).Cells("ID").Value
            com.ExecuteNonQuery()

            dgvTaxa.Rows.Remove(dgvTaxa.SelectedRows(0))
        End If
    End Sub

    Private Sub butDelete_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.MouseHover

        tt.SetToolTip(butDelete, _
           "Deletes the selected entry from the convenience taxon dictionary.")
    End Sub

    Private Sub dgvTaxa_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTaxa.MouseHover

        tt.SetToolTip(dgvTaxa, _
           "Select the entry to be deleted from the convenience taxon dictionary.")
    End Sub
End Class