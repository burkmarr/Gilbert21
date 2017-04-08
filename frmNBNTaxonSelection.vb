Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Web.Script.Serialization

Public Class frmNBNTaxonSelection

    Private Sub ClearControls()
        TreeView1.Nodes.Clear()
        txtAuthority.Text = ""
        txtTaxonGroup.Text = ""
        txtVersionKey.Text = ""
        chkPreferred.Checked = False
        chkScientific.Checked = False
        chkWellFormed.Checked = False
    End Sub

    Private Sub butSearchScientificName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearchScientificName.Click
        NBNSearchJSON(txtName.Text)
    End Sub

    Private Function GetURL(ByVal strSearchString As String, ByVal bSearch As Boolean) As String

        Dim baseURL As String

        If bSearch Then
            baseURL = "https://data.nbn.org.uk/api/search/taxa?q={0}"
        Else
            baseURL = "https://data.nbn.org.uk/api/taxa/{0}"
        End If

        Dim url As String = String.Format(baseURL, strSearchString)
        Return url
    End Function

    Private Sub HandleWebException(ByVal wex As WebException)
        Dim msg As String = "The server did not like your request."
        Dim hwr As HttpWebResponse = CType(wex.Response, HttpWebResponse)
        If hwr IsNot Nothing Then
            msg += vbCrLf + String.Format("The status code is {0}, the status message: {1}.", hwr.StatusCode, hwr.StatusDescription)
            Using sreader As System.IO.StreamReader = New System.IO.StreamReader(hwr.GetResponseStream())
                Dim errorMessage As String = sreader.ReadToEnd()
                If Not String.IsNullOrEmpty(errorMessage) Then
                    msg += vbCrLf + vbCrLf + "The further data sent from the server are:" + vbCrLf + errorMessage
                End If
            End Using
        End If
        MessageBox.Show(msg, "Bad Request!")
    End Sub

    Private Sub NBNSearchJSON(ByVal strSearchString As String)

        Cursor = Cursors.WaitCursor
        Me.Refresh()
        Application.DoEvents()

        Try
            Dim url As String = GetURL(strSearchString, True)

            Dim request As WebRequest = WebRequest.Create(url)
            Dim ws As WebResponse = request.GetResponse()

            Dim jsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(clsTaxonRest))
            Dim matchingTaxa As clsTaxonRest = CType(jsonSerializer.ReadObject(ws.GetResponseStream()), clsTaxonRest)

            Dim tnCat As TreeNode
            Dim tnTaxon As TreeNode
            Dim tnSelect As TreeNode = Nothing

            For Each t In matchingTaxa.results

                tnCat = Nothing
                For Each tn In TreeView1.Nodes

                    If tn.Text = StrConv(t.taxonOutputGroupName, VbStrConv.ProperCase) Then

                        tnCat = tn
                        Exit For
                    End If
                Next

                If tnCat Is Nothing Then

                    tnCat = TreeView1.Nodes.Add(StrConv(t.taxonOutputGroupName, VbStrConv.ProperCase))
                    tnCat.ImageIndex = 0
                    tnCat.SelectedImageIndex = 0
                End If

                'authority field is not always present so can't concatennate that with the name field.
                'But authority always seems to be included in pExtendedName field, so use that, but trim 
                'off last bit which just restates output group.

                Dim i As Integer = t.pExtendedName.LastIndexOf(",")

                tnTaxon = tnCat.Nodes.Add(t.pExtendedName.Substring(0, i))
                tnTaxon.Tag = t
                tnTaxon.ImageIndex = 3
                tnTaxon.SelectedImageIndex = 3
            Next

            For Each tn In TreeView1.Nodes
                tn.Expand()
            Next

            'If one of the taxon nodes matched search string, then select that node.
            If Not tnSelect Is Nothing Then
                TreeView1.SelectedNode = tnSelect
                TreeView1.Focus()
            End If

        Catch wex As WebException
            'exceptions from the server are communicated with a 4xx status code
            HandleWebException(wex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Rest call problem")
        End Try

        Cursor = Cursors.Arrow
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim ndeSelected As TreeNode = TreeView1.SelectedNode

        If ndeSelected Is Nothing Then Exit Sub

        Dim t As taxon = ndeSelected.Tag
        'Dim t2 As nbn35.Taxon

        If t Is Nothing Then Exit Sub

        Try
            Dim url As String = GetURL(t.ptaxonVersionKey, False)
            Dim request As WebRequest = WebRequest.Create(url)
            Dim ws As WebResponse = request.GetResponse()
            Dim jsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(clsTVK))
            Dim fullTaxon As clsTVK = CType(jsonSerializer.ReadObject(ws.GetResponseStream()), clsTVK)

            txtName.Text = fullTaxon.name
            txtVersionKey.Text = fullTaxon.taxonVersionKey
            txtAuthority.Text = fullTaxon.authority

            txtTaxonGroup.Text = fullTaxon.taxonOutputGroupName
            'chkScientific.Checked = t.TaxonName.isScientific
            chkPreferred.Checked = (fullTaxon.nameStatus = "Recommended")
            chkWellFormed.Checked = (fullTaxon.versionForm = "Well-formed")

        Catch wex As WebException
            'exceptions from the server are communicated with a 4xx status code
            HandleWebException(wex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Rest call problem")
        End Try
    End Sub

    Public Sub SetName(ByVal strName As String)

        txtName.Text = strName
        ClearControls()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        ClearControls()
        Me.Close()
    End Sub

    Private Sub butOkay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkay.Click
        Me.Close()
    End Sub

    Private Sub frmNBNTaxonSelection_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If txtVersionKey.Text = "" Then
            If txtName.Text <> "" Then
                NBNSearchJSON(txtName.Text)
            End If
        End If
    End Sub

    Private Sub frmNBNTaxonSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If cbo100m.SelectedIndex = -1 Then
            cbo100m.SelectedIndex = 0
            cbo1km.SelectedIndex = 0
            cbo2km.SelectedIndex = 0
            cbo10km.SelectedIndex = 0
            cboRecords.SelectedIndex = 0
            nudEndYear.Maximum = Now().Year
            nudEndYear.Value = Now().Year
            nudStartYear.Maximum = Now().Year

            txtNBNUser.Text = frmOptions.txtNBNUser.Text
            txtNBNPassword.Text = frmOptions.txtNBNPassword.Text

            If txtNBNUser.Text <> "" Then
                rbSpecificUser.Checked = True
            End If
        End If
    End Sub

    Private Sub rbPublic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPublic.CheckedChanged

        If rbPublic.Checked Then
            txtNBNUser.Enabled = False
            txtNBNPassword.Enabled = False
        Else
            txtNBNUser.Enabled = True
            txtNBNPassword.Enabled = True
        End If
    End Sub

    Private Sub txtName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp

        If e.KeyCode = Keys.Return Then
            If txtName.Text <> "" Then
                NBNSearchJSON(txtName.Text)
            End If
        End If
    End Sub

    Public ReadOnly Property NBNPassword() As String
        Get
            Dim md5 As MD5 = System.Security.Cryptography.MD5.Create()
            Dim inputBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(txtNBNPassword.Text)
            Dim hash As Byte() = md5.ComputeHash(inputBytes)
            Dim sb As New StringBuilder()
            For i As Integer = 0 To hash.Length - 1
                sb.Append(hash(i).ToString("x2"))
            Next
            Dim hashtext As [String] = sb.ToString()
            While hashtext.Length < 32
                hashtext = "0" & hashtext
            End While

            Return hashtext
        End Get
    End Property
End Class