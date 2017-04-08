Imports System.Data.SQLite

Public Class frmSearchGazetteer

    Dim objGridRef As GridRef = New GridRef

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click
        strGR = ""
        Me.Close()
    End Sub

    Private Sub butSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearch.Click

        Dim dblEast As Double
        Dim dblNorth As Double
        Dim dr As DataRow

        Dim dtInput As DataTable = New DataTable()
        Dim daSQLite As SQLiteDataAdapter

        Dim db As clsDB = New clsDB

        'Select Town from the OS50k Gaz view
        Dim strSQL As String = "Select east as x, north as y, def_nam as name from os50kgaz where def_nam like ?"
        'MessageBox.Show(strSQL)
        Dim com As SQLiteCommand = New SQLiteCommand(strSQL, db.conGazetteer)
        com.Parameters.AddWithValue("place", txtSearch.Text.Replace("*", "%"))

        Dim dtTowns As DataTable = New DataTable()
        'daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
        daSQLite = New SQLiteDataAdapter(com)

        daSQLite.Fill(dtTowns)

        'Add the Towns to the list
        lvLocations.Items.Clear()
        For Each dr In dtTowns.Rows

            dblEast = dr.Item("x")
            dblNorth = dr.Item("y")
            Dim item As ListViewItem = lvLocations.Items.Add(dr.Item("name"))
            item.SubItems.Add(objGridRef.EN2Monad(dblEast, dblNorth))
        Next
        lvLocations.Update()

        db.Dispose()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objGridRef.MakePrefixArrays()
    End Sub

    Private Sub butUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUse.Click

        If lvLocations.SelectedItems.Count > 0 Then
            strGR = lvLocations.SelectedItems(0).SubItems(1).Text
        Else
            strGR = ""
        End If
        Me.Close()
    End Sub

    Private strGR As String
    Public ReadOnly Property GR() As String
        Get
            Return strGR
        End Get
    End Property

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            butSearch_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub frmSearchGazetteer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        txtSearch.Focus()
        txtSearch.SelectAll()
    End Sub
End Class