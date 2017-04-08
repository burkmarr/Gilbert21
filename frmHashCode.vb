Imports System.IO
Imports System.Data.SQLite

Public Class frmHashCode

    Private Sub frmHashCode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitShortcutList()
        txtShortCut.Text = "#adhoc"

    End Sub

    Private Sub InitShortcutList()

        dgvHashCodes.DataSource = Nothing
        dgvHashCodes.Rows.Clear()

        Dim db As clsDB = New clsDB

        Dim comMain As SQLiteCommand = New SQLiteCommand()
        comMain.Connection = db.conMain

        Dim strSQL As String = "Select * from HashCodes order by hash"
        Dim odba As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMain)

        Dim dtHash As DataTable = New DataTable()

        If odba.Fill(dtHash) > 0 Then

            dgvHashCodes.DataSource = dtHash
        End If

        If dgvHashCodes.RowCount > 0 Then
            dgvHashCodes.Columns("ID").Visible = False
        End If

    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        If txtShortCut.Text.Length = 0 Then
            MessageBox.Show("You didn't enter a shortcut code.")
            Exit Sub
        ElseIf Not txtShortCut.Text.StartsWith("#") Then
            MessageBox.Show("The shortcut code must start with the '#' character.")
            Exit Sub
        End If

        If frmMain.dgvRecords.SelectedRows.Count <> 1 Then

            MessageBox.Show("You must first select a single record to add a hash code.")
        Else
            Dim db As clsDB = New clsDB

            Dim comMain As SQLiteCommand = New SQLiteCommand("Select Count(*) from HashCodes where Hash = ?", db.conMain)
            comMain.Parameters.AddWithValue("Hash", txtShortCut.Text)
            Dim iRecs As Integer = comMain.ExecuteScalar()
            comMain.Parameters.Clear()

            Dim row As DataGridViewRow = frmMain.dgvRecords.SelectedRows(0)

            If iRecs > 0 Then

                If Not txtShortCut.Text = "#adhoc" Then
                    If MessageBox.Show("There is already an entry in the HashCodes table with this value, do you want ot replace it?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If

                If ValOrEmpty(row.Cells("Date").Value).Length = 0 Then
                    comMain.CommandText = "Update HashCodes set CommonName=?, ScientificName=?, TaxonGroup=?, Abundance=?, Units=?, Location=?, Town=?, GridRef=?, Comment=? where Hash=?"
                Else
                    comMain.CommandText = "Update HashCodes set CommonName=?, ScientificName=?, TaxonGroup=?, Abundance=?, Units=?, Location=?, Town=?, GridRef=?, RecDate=?, Comment=? where Hash=?"
                End If
            Else
                If ValOrEmpty(row.Cells("Date").Value).Length = 0 Then
                    comMain.CommandText = "Insert into HashCodes(CommonName, ScientificName, TaxonGroup, Abundance, Units, Location, Town, GridRef, Comment, Hash ) values(?,?,?,?,?,?,?,?,?,?)"
                Else
                    comMain.CommandText = "Insert into HashCodes(CommonName, ScientificName, TaxonGroup, Abundance, Units, Location, Town, GridRef, RecDate, Comment, Hash ) values(?,?,?,?,?,?,?,?,?,?,?)"
                End If
            End If

            comMain.Parameters.AddWithValue("CommonName", ValOrEmpty(row.Cells("CommonName").Value))
            comMain.Parameters.AddWithValue("ScientificName", ValOrEmpty(row.Cells("ScientificName").Value))
            comMain.Parameters.AddWithValue("TaxonGroup", ValOrEmpty(row.Cells("TaxonGroup").Value))
            comMain.Parameters.AddWithValue("Abundance", ValOrEmpty(row.Cells("Abundance").Value))
            comMain.Parameters.AddWithValue("Units", ValOrEmpty(row.Cells("Units").Value))
            comMain.Parameters.AddWithValue("Location", ValOrEmpty(row.Cells("Location").Value))
            comMain.Parameters.AddWithValue("Town", ValOrEmpty(row.Cells("Town").Value))
            comMain.Parameters.AddWithValue("GridRef", ValOrEmpty(row.Cells("GridRef").Value))
            If ValOrEmpty(row.Cells("Date").Value).Length > 0 Then
                comMain.Parameters.AddWithValue("RecDate", Date.Parse(ValOrEmpty(row.Cells("Date").Value)))
            End If
            comMain.Parameters.AddWithValue("Comment", ValOrEmpty(row.Cells("Comment").Value))
            comMain.Parameters.AddWithValue("Hash", txtShortCut.Text)

            comMain.ExecuteNonQuery()
        End If

        InitShortcutList()
        frmMain.InitShortcutList(True)
        Me.Close()
    End Sub

    Private Function ValOrEmpty(ByVal strValue As String) As String

        If strValue Is Nothing Then
            Return ""
        Else
            Return strValue
        End If
    End Function

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        If dgvHashCodes.SelectedRows.Count <> 1 Then

            MessageBox.Show("You must select a single shortcut to delete it.")
            Exit Sub
        End If

        If MessageBox.Show("Are you sure that you want to delete this shortcut?", "Confirm deletion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim db As clsDB = New clsDB

            Dim com As SQLiteCommand = New SQLiteCommand()
            com.Connection = db.conMain
            com.CommandText = "Delete from HashCodes where ID = " & dgvHashCodes.SelectedRows(0).Cells("ID").Value
            com.ExecuteNonQuery()

            dgvHashCodes.Rows.Remove(dgvHashCodes.SelectedRows(0))
        End If

    End Sub

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click

        Me.Close()
    End Sub

    Private Sub txtShortCut_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShortCut.MouseHover

        tt.SetToolTip(txtShortCut, _
                "Specify a short-cut code in here before you click" & vbCrLf & _
                "the 'Add' button. It must start with the hash" & vbCrLf & _
                "symbol (#). If the short-cut code aleady exists," & vbCrLf & _
                "the existing short-cut will be updated with the" & vbCrLf & _
                "contents of the record you selected before invoking" & vbCrLf & _
                "the dialog. Otherwise a new short-cut will be created.")
    End Sub

    Private Sub butAdd_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.MouseHover

        tt.SetToolTip(butAdd, _
               "This will either add a new shortcut with the " & vbCrLf & _
               "specified code, or update one if the code is already " & vbCrLf & _
               "used. The contents of the shortcut are derived from " & vbCrLf & _
               "the record you selected before invoking the dialog.")
    End Sub

    Private Sub butDelete_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.MouseHover

        tt.SetToolTip(butDelete, _
               "Delete the shortcut currently selected from " & vbCrLf & _
               "the shortcut list.")
    End Sub
End Class