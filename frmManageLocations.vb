Imports System.Data.SQLite
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmManageLocations

    Dim objLocations As clsLocations

    Public Sub Init(ByVal strGridRef As String)

        txtGR.Text = strGridRef
        objLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
        objLocations.PopulateManageLocationsDGV(lvLocations)
    End Sub

    Private Sub butGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGE.Click

        objLocations.GenerateLocationKML()
    End Sub


    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click

        If lvLocations.SelectedItems.Count = 0 Then

            MessageBox.Show("You must first select a location from the list")
        Else
            Dim db As clsDB = New clsDB

            Dim comGaz As SQLiteCommand
            Select Case lvLocations.SelectedItems(0).SubItems(1).Text

                Case "D"
                    'Item already marked not for use in gazetteer.
                    MessageBox.Show("This location is already marked in the gazetteer to indicate that it is out of use")
                Case "G"
                    'If the selected item has a type of 'G' then it was added by Gilbert 21 and can simply be
                    'deleted from the Gazetteer.
                    comGaz = New SQLiteCommand("Delete from osDistrictVectorGaz where ID=?", db.conGazetteer)
                    comGaz.Parameters.AddWithValue("ID", lvLocations.SelectedItems(0).SubItems(2).Text)
                    comGaz.ExecuteNonQuery()
                Case Else
                    'The selected item has no type and is therefore a system (OS) supplied gazetteer entry
                    'which should be marked to indicate that it should not be used.
                    comGaz = New SQLiteCommand("Update osDistrictVectorGaz set Type=? where ID=?", db.conGazetteer)
                    comGaz.Parameters.AddWithValue("Type", "D")
                    comGaz.Parameters.AddWithValue("ID", lvLocations.SelectedItems(0).SubItems(2).Text)
                    comGaz.ExecuteNonQuery()
            End Select

            If lvLocations.SelectedItems(0).SubItems(1).Text <> "D" Then
                objLocations = Nothing
                objLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
                objLocations.PopulateManageLocationsDGV(lvLocations)
            End If
        End If
    End Sub

    Private Sub butUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUse.Click

        If lvLocations.SelectedItems.Count = 0 Then

            MessageBox.Show("You must first select a location from the list")
        Else
            Dim db As clsDB = New clsDB

            Dim comGaz As SQLiteCommand
            If lvLocations.SelectedItems(0).SubItems(1).Text = "D" Then
                comGaz = New SQLiteCommand("Update osDistrictVectorGaz set Type=? where ID=?", db.conGazetteer)
                comGaz.Parameters.AddWithValue("Type", "")
                comGaz.Parameters.AddWithValue("ID", lvLocations.SelectedItems(0).SubItems(2).Text)
                comGaz.ExecuteNonQuery()
            Else
                'Location already in use.
                MessageBox.Show("This location is already in use")
            End If

            If lvLocations.SelectedItems(0).SubItems(1).Text = "D" Then
                objLocations = Nothing
                objLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
                objLocations.PopulateManageLocationsDGV(lvLocations)
            End If
        End If
    End Sub

    Private Sub txtEasting_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEasting.TextChanged

        parseXML(txtEasting.Text)
    End Sub

    Private Sub parseXML(ByVal strText As String)

        Dim str As String = strText
        Str = Str.Replace(ControlChars.FormFeed, "")
        Str = Str.Replace(ControlChars.NewLine, "")
        Str = Str.Replace(ControlChars.VerticalTab, "")
        Str = Str.Replace(ControlChars.Tab, "")
        Str = Str.Replace(ControlChars.CrLf, "")
        Str = Str.Replace(ControlChars.Lf, "")
        Str = Str.Replace(ControlChars.Cr, "")

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        Dim xmlNode As XmlNode
        Dim XMLnr As XmlNodeReader

        If str.StartsWith("<?xml") Then

            Dim xmlDoc As New XmlDocument
            Dim ns As XmlNamespaceManager

            Dim strXml As String = str
            Try
                xmlDoc.LoadXml(strXml)
            Catch ex As Exception
                txtEasting.Text = ""
                txtNorthing.Text = ""
                MessageBox.Show("Couldn't parse XML string - report this as a bug. Error message: " & ex.Message)
                Exit Sub
            End Try

            ns = New XmlNamespaceManager(xmlDoc.NameTable)
            ns.AddNamespace("gx", "http://www.google.com/kml/ext/2.2")
            ns.AddNamespace("kml", "http://www.opengis.net/kml/2.2")
            ns.AddNamespace("atom", "http://www.w3.org/2005/Atom")
            Dim root As XmlElement = xmlDoc.DocumentElement

            'Look for placemark point coordinates, convert to easting and northings 
            xmlNode = root.SelectSingleNode("//kml:Placemark/kml:Point/kml:coordinates", ns)

            If Not xmlNode Is Nothing Then
                XMLnr = New XmlNodeReader(xmlNode)
                Dim coords() As String = xmlNode.InnerText.Split(",")
                Dim dblLon As Double = Convert.ToDouble(coords(0))
                Dim dblLat As Double = Convert.ToDouble(coords(1))

                txtEasting.Text = Math.Round(objGridRef.LongWGS842Easting(dblLat, dblLon, 100))
                txtNorthing.Text = Math.Round(objGridRef.LatWGS842Northing(dblLat, dblLon, 100))
            End If
        End If
    End Sub

    Private Sub txtNorthing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNorthing.TextChanged
        parseXML(txtNorthing.Text)
    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        If txtName.Text.Trim.Length = 0 Then

            MessageBox.Show("You must specify a location name")
            Exit Sub
        End If

        If txtName.Text.Length > 255 Then

            MessageBox.Show("The location name cannot be more than 255 characters in length")
            Exit Sub
        End If

        'Dim objRegex As Regex = New Regex("^[1-9][0-9][0-9][0-9][0-9][0-9]$")
        Dim objRegex As Regex = New Regex("^[1-9]([0-9])*$")

        If Not objRegex.IsMatch(txtEasting.Text.Trim) Then
            MessageBox.Show("Easting must be a number")
            Exit Sub
        End If

        If Not objRegex.IsMatch(txtNorthing.Text.Trim) Then
            MessageBox.Show("Northing must be a number")
            Exit Sub
        End If

        If Not Convert.ToDouble(txtEasting.Text.Trim) < 700000 Then
            MessageBox.Show("Easting must be less than 700000")
            Exit Sub
        End If

        If Not Convert.ToDouble(txtNorthing.Text.Trim) < 1300000 Then
            MessageBox.Show("Northing must be less than 1300000")
            Exit Sub
        End If

        Dim db As clsDB = New clsDB

        Dim comGaz As SQLiteCommand

        comGaz = New SQLiteCommand("Insert into osDistrictVectorGaz (X,Y,Name,Type) values (?,?,?,?)", db.conGazetteer)
        comGaz.Parameters.AddWithValue("X", Convert.ToDouble(txtEasting.Text.Trim))
        comGaz.Parameters.AddWithValue("Y", Convert.ToDouble(txtNorthing.Text.Trim))
        comGaz.Parameters.AddWithValue("Location", txtName.Text)
        comGaz.Parameters.AddWithValue("Type", "G")
        comGaz.ExecuteNonQuery()

        txtName.Text = ""
        txtEasting.Text = ""
        txtNorthing.Text = ""

        objLocations = Nothing
        objLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
        objLocations.PopulateManageLocationsDGV(lvLocations)
    End Sub

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click

        Me.Close()
    End Sub

    Private Sub butApplyClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butApplyClose.Click

        frmMain.ResetCalculatedLocations(False)
        Me.Close()
    End Sub

    Private Sub butApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butApply.Click

        frmMain.ResetCalculatedLocations(False)
    End Sub

    Private Sub lvLocations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLocations.SelectedIndexChanged

        If lvLocations.SelectedItems.Count > 0 Then
            txtName.Text = lvLocations.SelectedItems(0).SubItems(0).Text
            txtEasting.Text = lvLocations.SelectedItems(0).SubItems(3).Text
            txtNorthing.Text = lvLocations.SelectedItems(0).SubItems(4).Text
        End If

    End Sub
End Class