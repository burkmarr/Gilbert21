Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Xml
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Web.Script.Serialization

Public Class frmRecordDetails

    '<DllImport("user32.dll")> _
    'Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    'End Function
    <DllImport("user32.dll")> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function
    Private Const SWP_NOSIZE As Integer = &H1
    Private Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Private rowActive As DataGridViewRow
    Private rowOriginal As DataGridViewRow
    Private strInputFolder As String
    Private strTaxonDictionaryFilter As String
    Private objGridRef As GridRef = New GridRef
    Private theta As Double
    Private oClockPreventRecurse As Boolean = False
    Private oClockCurrentValue As Integer
    Private dtTaxonGroup As DataTable = New DataTable()
    Private dtAllTaxonGroups As DataTable = New DataTable()
    Private bCtrlPressed As Boolean
    Private intZoomLevel As Integer = 0
    Private dblWestLongitude As Double
    Private dblEastLongitude As Double
    Private dblSouthLatitude As Double
    Private dblNorthLatitude As Double
    Private dblPixPerDegree As Double
    Private dblMapCentreLat As Double
    Private dblMapCentreLon As Double
    Private pntMouseDown As Point
    Private mgrOffset As clsOffsetGR
    Private dtTrack As DataTable
    Private pntsTrack() As Point

    Private Enum MoveDirection
        Up
        Down
    End Enum

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objGridRef.MakePrefixArrays()

        'Init map type selection
        cbMapType.SelectedIndex = 0

        'Initialise the position of the map image
        pbMap.Left = 0
        pbMap.Top = 0
        pbMap.Width = panMap.Width
        pbMap.Height = panMap.Height
    End Sub

    Public Sub Init(ByVal row As DataGridViewRow, ByVal strFolder As String, ByVal strFilter As String, ByVal strTab As String)

        dtTrack = Nothing
        ReDim pntsTrack(0)

        rowActive = row
        rowOriginal = row.Clone
        For i = 0 To rowActive.Cells.Count - 1
            rowOriginal.Cells(i).Value = rowActive.Cells(i).Value
        Next

        strInputFolder = strFolder
        strTaxonDictionaryFilter = strFilter

        InitWho()
        InitWhat()
        InitWhere()
        InitWhen()
        InitComments()

        refreshMediaImageTab()

        'Init the right tab
        tcMain.SelectedTab = tcMain.TabPages(strTab)
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
        TreeView1.Nodes.Clear()
        Application.DoEvents()

        Try
            Dim url As String = GetURL(strSearchString, True)

            Dim request As WebRequest = WebRequest.Create(url)
            Dim ws As WebResponse = request.GetResponse()

            Dim jsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(clsTaxonRest))
            Dim matchingTaxa As clsTaxonRest = CType(jsonSerializer.ReadObject(ws.GetResponseStream()), clsTaxonRest)

            Dim tnCat As TreeNode
            Dim tnTaxon As TreeNode

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

        Catch wex As WebException
            'exceptions from the server are communicated with a 4xx status code
            HandleWebException(wex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Rest call problem")
        End Try

        Cursor = Cursors.Arrow
    End Sub

    'Private Sub NBNSearch(ByVal strSearchString As String)

    '    'If MessageBox.Show("Search the NBN taxon dictionary for '" & strSearchString & "'?", "NBN Taxon search", MessageBoxButtons.YesNo) = DialogResult.No Then
    '    'Exit Sub
    '    'End If

    '    Cursor = Cursors.WaitCursor

    '    Dim tgws As nbn35.GatewayWebService = New nbn35.GatewayWebService()
    '    Dim Req As New nbn35.TaxonomySearchRequest
    '    Dim resp As nbn35.TaxonomySearchResponse = Nothing

    '    TreeView1.Nodes.Clear()
    '    'ClearTaxonControls()

    '    Req.Item = strSearchString
    '    Req.ItemElementName = nbn35.ItemChoiceType1.SearchTerm
    '    'Set the Gilber 21 NBN 'varaible access' key
    '    Req.registrationKey = "b00b856c1b2626d7ec1c35d5aa9023431a7ace08"
    '    Req.username = ""
    '    Req.userPassKey = ""
    '    Req.includeDesignation = False
    '    Req.includeFormerDesignations = False

    '    Application.DoEvents()

    '    Try
    '        resp = tgws.GetTaxonomySearch(Req)
    '    Catch ex As Exception
    '        If InStr(ex.Message, "connection was closed", CompareMethod.Text) > 0 Then

    '            MessageBox.Show("Could not establish an internet connection. Make sure that your internet connection is open.", "Gilbert21", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            MessageBox.Show("No matches could be found at " & " NBN " & " for '" & strSearchString & "'.", "Taxa Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    End Try

    '    If Not resp Is Nothing Then

    '        Dim tn As TreeNode
    '        Dim t As nbn35.Taxon
    '        Dim syn As nbn35.Taxon
    '        Dim lower As nbn35.Taxon
    '        Dim agg As nbn35.Taxon
    '        Dim tnCat As TreeNode
    '        Dim tnTaxon As TreeNode
    '        Dim tnSyn As TreeNode
    '        Dim tnLowerFolder As TreeNode
    '        Dim tnAggFolder As TreeNode
    '        Dim tnLower As TreeNode
    '        Dim tnAgg As TreeNode
    '        Dim strAuthority As String = ""

    '        For Each t In resp.Taxa

    '            't.taxonVersionKey()

    '            tnCat = Nothing
    '            For Each tn In TreeView1.Nodes

    '                If tn.Text = StrConv(t.TaxonReportingCategory.Value, VbStrConv.ProperCase) Then

    '                    tnCat = tn
    '                    Exit For
    '                End If
    '            Next

    '            If tnCat Is Nothing Then

    '                tnCat = TreeView1.Nodes.Add(StrConv(t.TaxonReportingCategory.Value, VbStrConv.ProperCase))
    '                tnCat.ImageIndex = 0
    '                tnCat.SelectedImageIndex = 0
    '            End If

    '            If Not t.Authority Is Nothing Then
    '                strAuthority = t.Authority.Replace("&nbsp;", "")
    '            Else
    '                strAuthority = ""
    '            End If

    '            tnTaxon = tnCat.Nodes.Add(t.TaxonName.Value & " " & strAuthority)
    '            tnTaxon.Tag = t 't.TaxonName.Value
    '            tnTaxon.ImageIndex = 3
    '            tnTaxon.SelectedImageIndex = 3

    '            Application.DoEvents()

    '            If Not t.SynonymList Is Nothing Then
    '                For Each syn In t.SynonymList

    '                    If Not syn.Authority Is Nothing Then
    '                        strAuthority = syn.Authority.Replace("&nbsp;", "")
    '                    Else
    '                        strAuthority = ""
    '                    End If

    '                    tnSyn = tnTaxon.Nodes.Add(syn.TaxonName.Value & " " & strAuthority)
    '                    tnSyn.Tag = syn 'syn.TaxonName.Value
    '                    tnSyn.ImageIndex = 2
    '                    tnSyn.SelectedImageIndex = 2
    '                Next
    '            End If

    '            If Not t.LowerTaxaList Is Nothing Then

    '                tnLowerFolder = tnTaxon.Nodes.Add("Lower taxa")
    '                tnLowerFolder.ImageIndex = 4
    '                tnLowerFolder.SelectedImageIndex = 4

    '                For Each lower In t.LowerTaxaList

    '                    tnLower = tnLowerFolder.Nodes.Add(lower.TaxonName.Value & " " & lower.Authority)
    '                    tnLower.Tag = lower
    '                    tnLower.ImageIndex = 3
    '                    tnLower.SelectedImageIndex = 3
    '                Next
    '            End If

    '            If Not t.AggregateList Is Nothing Then

    '                tnAggFolder = tnTaxon.Nodes.Add("Aggregates")
    '                tnAggFolder.ImageIndex = 4
    '                tnAggFolder.SelectedImageIndex = 4

    '                For Each agg In t.AggregateList

    '                    tnAgg = tnAggFolder.Nodes.Add(agg.TaxonName.Value & " " & agg.Authority)
    '                    tnAgg.Tag = agg
    '                    tnAgg.ImageIndex = 3
    '                    tnAgg.SelectedImageIndex = 3
    '                Next
    '            End If
    '        Next

    '        For Each tn In TreeView1.Nodes
    '            tn.Expand()
    '        Next

    '    End If

    '    Cursor = Cursors.Arrow
    'End Sub

    'Private Sub NBNSearch31(ByVal strSearchString As String)

    '    'If MessageBox.Show("Search the NBN taxon dictionary for '" & strSearchString & "'?", "NBN Taxon search", MessageBoxButtons.YesNo) = DialogResult.No Then
    '    'Exit Sub
    '    'End If

    '    Cursor = Cursors.WaitCursor

    '    Dim tgws As nbn31.GatewayWebService = New nbn31.GatewayWebService()
    '    Dim Req As New nbn31.TaxonomySearchRequest
    '    Dim resp() As nbn31.Taxon = Nothing

    '    TreeView1.Nodes.Clear()
    '    'ClearTaxonControls()

    '    Req.Item = strSearchString
    '    Req.ItemElementName = nbn31.ItemChoiceType.SpeciesName

    '    Application.DoEvents()

    '    Try
    '        resp = tgws.GetTaxonomySearch(Req)
    '    Catch ex As Exception
    '        If InStr(ex.Message, "connection was closed", CompareMethod.Text) > 0 Then

    '            MessageBox.Show("Could not establish an internet connection. Make sure that your internet connection is open.", "Gilbert21", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            MessageBox.Show("No matches could be found at " & " NBN " & " for '" & strSearchString & "'.", "Taxa Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    End Try

    '    If Not resp Is Nothing Then

    '        Dim tn As TreeNode
    '        Dim t As nbn31.Taxon
    '        Dim syn As nbn31.Taxon
    '        Dim lower As nbn31.Taxon
    '        Dim agg As nbn31.Taxon
    '        Dim tnCat As TreeNode
    '        Dim tnTaxon As TreeNode
    '        Dim tnSyn As TreeNode
    '        Dim tnLowerFolder As TreeNode
    '        Dim tnAggFolder As TreeNode
    '        Dim tnLower As TreeNode
    '        Dim tnAgg As TreeNode
    '        Dim strAuthority As String = ""

    '        For Each t In resp

    '            't.taxonVersionKey()

    '            tnCat = Nothing
    '            For Each tn In TreeView1.Nodes

    '                If tn.Text = StrConv(t.TaxonReportingCategory, VbStrConv.ProperCase) Then

    '                    tnCat = tn
    '                    Exit For
    '                End If
    '            Next

    '            If tnCat Is Nothing Then

    '                tnCat = TreeView1.Nodes.Add(StrConv(t.TaxonReportingCategory, VbStrConv.ProperCase))
    '                tnCat.ImageIndex = 0
    '                tnCat.SelectedImageIndex = 0
    '            End If

    '            If Not t.Authority Is Nothing Then
    '                strAuthority = t.Authority.Replace("&nbsp;", "")
    '            Else
    '                strAuthority = ""
    '            End If

    '            tnTaxon = tnCat.Nodes.Add(t.TaxonName.Value & " " & strAuthority)
    '            tnTaxon.Tag = t 't.TaxonName.Value
    '            tnTaxon.ImageIndex = 3
    '            tnTaxon.SelectedImageIndex = 3

    '            Application.DoEvents()

    '            If Not t.SynonymList Is Nothing Then
    '                For Each syn In t.SynonymList

    '                    If Not syn.Authority Is Nothing Then
    '                        strAuthority = syn.Authority.Replace("&nbsp;", "")
    '                    Else
    '                        strAuthority = ""
    '                    End If

    '                    tnSyn = tnTaxon.Nodes.Add(syn.TaxonName.Value & " " & strAuthority)
    '                    tnSyn.Tag = syn 'syn.TaxonName.Value
    '                    tnSyn.ImageIndex = 2
    '                    tnSyn.SelectedImageIndex = 2
    '                Next
    '            End If

    '            If Not t.LowerTaxaList Is Nothing Then

    '                tnLowerFolder = tnTaxon.Nodes.Add("Lower taxa")
    '                tnLowerFolder.ImageIndex = 4
    '                tnLowerFolder.SelectedImageIndex = 4

    '                For Each lower In t.LowerTaxaList

    '                    tnLower = tnLowerFolder.Nodes.Add(lower.TaxonName.Value & " " & lower.Authority)
    '                    tnLower.Tag = lower
    '                    tnLower.ImageIndex = 3
    '                    tnLower.SelectedImageIndex = 3
    '                Next
    '            End If

    '            If Not t.AggregateList Is Nothing Then

    '                tnAggFolder = tnTaxon.Nodes.Add("Aggregates")
    '                tnAggFolder.ImageIndex = 4
    '                tnAggFolder.SelectedImageIndex = 4

    '                For Each agg In t.AggregateList

    '                    tnAgg = tnAggFolder.Nodes.Add(agg.TaxonName.Value & " " & agg.Authority)
    '                    tnAgg.Tag = agg
    '                    tnAgg.ImageIndex = 3
    '                    tnAgg.SelectedImageIndex = 3
    '                Next
    '            End If
    '        Next

    '        For Each tn In TreeView1.Nodes
    '            tn.Expand()
    '        Next

    '    End If

    '    Cursor = Cursors.Arrow
    'End Sub

    'Private Function GetNBNImage(ByVal dblLatLL As Double, ByVal dblLonLL As Double, ByVal dblLatUR As Double, ByVal dblLonUR As Double) As String

    '    Dim sb As StringBuilder = New StringBuilder("http://gis.nbn.org.uk/arcgis/rest/services/grids/SingleSpeciesMap/")

    '    sb.Append("NBNSYS0000007054")
    '    sb.Append("/WMSServer?REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&BBOX=")
    '    'sb.Append(dblLatLL.ToString)
    '    'sb.Append(",")
    '    'sb.Append(dblLonLL.ToString)
    '    'sb.Append(",")
    '    'sb.Append(dblLatUR.ToString)
    '    'sb.Append(",")
    '    'sb.Append(dblLonUR.ToString)

    '    sb.Append(dblLonLL.ToString)
    '    sb.Append(",")
    '    sb.Append(dblLatLL.ToString)
    '    sb.Append(",")
    '    sb.Append(dblLonUR.ToString)
    '    sb.Append(",")
    '    sb.Append(dblLatUR.ToString)

    '    sb.Append("&WIDTH=")
    '    sb.Append(pbMap.Width.ToString)
    '    sb.Append("&HEIGHT=")
    '    sb.Append(pbMap.Height.ToString)
    '    sb.Append("&CRS=CRS:84&FORMAT=image/png&LAYERS=3,2,1,0&TRANSPARENT=true")
    '    'CRS:84
    '    'EPSG:4326

    '    Return sb.ToString
    'End Function

    'Private Sub GetMapNBN(ByVal dblLat As Double, ByVal dblLon As Double)

    '    'Check for valid GR
    '    objGridRef.GridRef = txtGR.Text
    '    objGridRef.sErrorMessage = ""
    '    objGridRef.ParseGridRef(True)
    '    objGridRef.ParseInput(False)

    '    If objGridRef.sErrorMessage <> "" Then
    '        MessageBox.Show(objGridRef.sErrorMessage)
    '        Exit Sub
    '    End If

    '    Dim dblZoom4Width As Double = 1384992.94054433 * 2
    '    Dim dblMapWidth As Double = dblZoom4Width / 2 ^ (tbZoom.Value - 4)
    '    Dim dblMapHeight As Double = dblMapWidth * panMap.Height / panMap.Width
    '    Dim x As Double = objGridRef.LongWGS842Easting(dblLat, dblLon, 0)
    '    Dim y As Double = objGridRef.LatWGS842Northing(dblLat, dblLon, 0)

    '    'Reposition the map image
    '    pbMap.Left = 0
    '    pbMap.Top = 0
    '    pbMap.Width = panMap.Width
    '    pbMap.Height = panMap.Height

    '    'Rest service
    '    Dim minx As Double = x - dblMapWidth / 2
    '    Dim maxx As Double = minx + dblMapWidth
    '    Dim miny As Double = y - dblMapHeight / 2
    '    Dim maxy As Double = miny + dblMapHeight
    '    Dim strBB As String = minx.ToString & "," & miny.ToString & "," & maxx.ToString & "," & maxy.ToString
    '    Dim strRestURL As String = "http://gis.nbn.org.uk/arcgis/rest/services/grids/SingleSpeciesMap/NHMSYS0000551100/WMSServer?REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&BBOX=" & strBB & "&WIDTH=" & pbMap.Width.ToString & "&HEIGHT=" & pbMap.Height.ToString & "&CRS=EPSG:27700&FORMAT=image/png&LAYERS=3"

    '    pbMap.Load(strRestURL)
    'End Sub

    Private Sub ClearTaxonControls()
        txtVersionKey.Text = ""
        txtAuthority.Text = ""
        cboCommonName.Text = ""
        cboScientificName.Text = ""
        cboTaxonGroup.Text = ""
        chkScientific.Checked = False
        chkPreferred.Checked = False
        chkWellFormed.Checked = False
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim ndeSelected As TreeNode = TreeView1.SelectedNode

        ClearTaxonControls()

        If ndeSelected Is Nothing Then Exit Sub

        Dim t As taxon = ndeSelected.Tag

        If t Is Nothing Then Exit Sub

        Try
            'MessageBox.Show("tvk: " & t.ptaxonVersionKey)

            Dim url As String = GetURL(t.ptaxonVersionKey, False)
            Dim request As WebRequest = WebRequest.Create(url)
            Dim ws As WebResponse = request.GetResponse()
            Dim jsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(clsTVK))
            Dim fullTaxon As clsTVK = CType(jsonSerializer.ReadObject(ws.GetResponseStream()), clsTVK)

            cboScientificName.Text = fullTaxon.name

            If fullTaxon.commonName <> "" Then
                'Otherwise scientific names gets sent to blank too
                cboCommonName.Text = fullTaxon.commonName
            End If

            txtVersionKey.Text = fullTaxon.taxonVersionKey
            txtAuthority.Text = fullTaxon.authority

            cboTaxonGroup.Text = fullTaxon.taxonOutputGroupName
            'chkScientific.Checked = t.TaxonName.isScientific
            chkPreferred.Checked = (fullTaxon.nameStatus = "Recommended")
            chkWellFormed.Checked = (fullTaxon.versionForm = "Well-formed")

        Catch wex As WebException
            'exceptions from the server are communicated with a 4xx status code
            HandleWebException(wex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Rest call problem")
        End Try


        txtAbundance.Focus() 'Doesn't seem to work


        'Dim ndeSelected As TreeNode = TreeView1.SelectedNode

        'ClearTaxonControls()

        'If ndeSelected Is Nothing Then Exit Sub

        'Dim t As nbn35.Taxon = ndeSelected.Tag
        'Dim t2 As nbn35.Taxon

        'If t Is Nothing Then Exit Sub

        'If t.TaxonName.isScientific Then

        '    cboScientificName.Text = t.TaxonName.Value
        '    txtVersionKey.Text = t.TaxonVersionKey
        '    txtAuthority.Text = t.Authority

        '    If Not t.SynonymList Is Nothing Then
        '        For Each t2 In t.SynonymList
        '            If Not t2.TaxonName.isScientific Then
        '                cboCommonName.Text = t2.TaxonName.Value
        '                Exit For
        '            End If
        '        Next
        '    End If
        'Else
        '    cboCommonName.Text = t.TaxonName.Value
        '    t2 = ndeSelected.Parent.Tag
        '    cboScientificName.Text = t2.TaxonName.Value
        '    txtVersionKey.Text = t2.TaxonVersionKey
        '    txtAuthority.Text = t2.Authority
        'End If

        'cboTaxonGroup.Text = t.TaxonReportingCategory.Value
        'chkScientific.Checked = t.TaxonName.isScientific
        'chkPreferred.Checked = t.TaxonName.isPreferredName
        'chkWellFormed.Checked = t.TaxonName.wellFormed

        'txtAbundance.Focus() 'Doesn't seem to work

    End Sub

    Private Sub butVoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butVoice.Click

        Dim objCF As cfun = New cfun
        objCF.PlayWavForIDV2(rowActive.Cells("ID").Value)

        cboCommonName.Focus()
        If cboCommonName.Text.StartsWith("Audio recording") Then
            cboCommonName.SelectionStart = 0
            cboCommonName.SelectionLength = cboCommonName.Text.Length
        End If
        If frmOptions.txtFfplayExe.Text.Trim.Length > 0 Then
            tmrActivateWindow.Enabled = True
        End If
    End Sub

    Private Sub CommitDialog()

        'Who
        rowActive.Cells("Recorder").Value = txtRecorder.Text
        rowActive.Cells("Determiner").Value = txtDeterminer.Text
        rowActive.Cells("Confirmer").Value = txtConfirmer.Text
        'What
        rowActive.Cells("CommonName").Value = cboCommonName.Text
        rowActive.Cells("ScientificName").Value = cboScientificName.Text
        rowActive.Cells("TaxonGroup").Value = cboTaxonGroup.Text
        rowActive.Cells("Abundance").Value = txtAbundance.Text
        rowActive.Cells("Units").Value = txtAbundanceUnits.Text
        'Where
        rowActive.Cells("GridRef").Value = txtGR.Text
        rowActive.Cells("Location").Value = txtLocation.Text
        rowActive.Cells("Town").Value = txtTown.Text
        'When
        If chkNoDate.Checked Then
            rowActive.Cells("Date").Value = ""
        Else
            rowActive.Cells("Date").Value = Format(dtpDate.Value, "dd/MM/yyyy")
        End If
        If chkNoTime.Checked Then
            rowActive.Cells("Time").Value = ""
        Else
            rowActive.Cells("Time").Value = Format(dtpTime.Value, "HH:mm")
        End If

        'Comment
        rowActive.Cells("Comment").Value = txtComment.Text
        rowActive.Cells("PersonalNotes").Value = txtPersonalNotes.Text
        rowActive.Cells("NoExport").Value = chkExcludeFromExport.Checked

        'Save the taxon to Gilbert21 TaxonDictionary if necessary
        UpdateTaxonDictionary(cboCommonName.Text, cboScientificName.Text, cboTaxonGroup.Text)
        'Update gazetteer if necessary
        If chkNewLocation.Checked Then
            UpdateGazetteer()
        End If

        'Now check whether or not the active row values differ from those
        'saved when dialog started. If it does then set record status to modified.
        For i = 0 To rowActive.Cells.Count - 1
            If CellsDiffer(rowActive.Cells(i).Value, rowOriginal.Cells(i).Value) Then

                'frmMain.UpdateRecStatus(rowActive, frmMain.RecStatus.Modified)
                rowActive.Cells("Modified").Value = "today"
                frmMain.UpdateRecRowDisplay(rowActive)
                Exit For
            End If
        Next

        Me.Close()
    End Sub

    Private Function CellsDiffer(ByVal objVal1 As Object, ByVal objVal2 As Object) As Boolean

        If cfun.HasNoValue(objVal1) And Not cfun.HasNoValue(objVal2) Then
            Return True
        ElseIf Not cfun.HasNoValue(objVal1) And cfun.HasNoValue(objVal2) Then
            Return True
        ElseIf cfun.HasNoValue(objVal1) And cfun.HasNoValue(objVal2) Then
            Return False
        ElseIf objVal1 <> objVal2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub UpdateFromHash(ByRef valCurrent As String, ByVal val As Object)

        If valCurrent = "" Then
            valCurrent = val.ToString()
        End If
    End Sub

    Private Sub UpdateTaxonDictionary(ByVal strCommonName As String, ByVal strScientificName As String, ByVal strTaxonGroup As String)

        Dim db As clsDB = New clsDB
        Dim com As SQLiteCommand

        com = New SQLiteCommand("Select Count(*) from TaxonDictionary where ScientificName=?", db.conMain)
        com.Parameters.AddWithValue("ScientificName", strScientificName)
        Dim iRecsScientific As Integer = com.ExecuteScalar()
        com.Dispose()

        com = New SQLiteCommand("Select Count(*) from TaxonDictionary where ScientificName=? and CommonName=? and TaxonGroup=?", db.conMain)
        com.Parameters.AddWithValue("ScientificName", strScientificName)
        com.Parameters.AddWithValue("CommonName", strCommonName)
        com.Parameters.AddWithValue("TaxonGroup", strTaxonGroup)
        Dim iRecsExactMatch As Integer = com.ExecuteScalar()
        com.Dispose()

        If iRecsExactMatch = 0 Then
            If strScientificName.Length > 0 Or strCommonName.Length > 0 Then
                If iRecsScientific = 0 Then
                    com = New SQLiteCommand("Insert into TaxonDictionary(CommonName, TaxonGroup, ScientificName) values(?,?,?)", db.conMain)
                Else
                    com = New SQLiteCommand("Update TaxonDictionary set CommonName=?, TaxonGroup=? where ScientificName=?", db.conMain)
                End If
                com.Parameters.AddWithValue("CommonName", strCommonName)
                com.Parameters.AddWithValue("TaxonGroup", strTaxonGroup)
                com.Parameters.AddWithValue("ScientificName", strScientificName)
                com.ExecuteNonQuery()
                com.Dispose()
            End If
        End If

        db.Dispose()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub

    Private Sub cboScientificName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboScientificName.KeyUp

        If e.KeyCode = Keys.Return Then

            If cboScientificName.SelectedIndex = -1 And cboScientificName.Text <> "" Then
                'User has entered a taxon which is not in list and then hit return - do
                'a search.

                'If MessageBox.Show("Do you want to search the NBN taxon dictionary for '" & cboCommonName.Text & "'?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'cboCommonName.Text = ""
                NBNSearchJSON(cboScientificName.Text)
                'End If
            Else 'ElseIf cboScientificName.Text = "" Then
                'Shift focus to abundance
                txtAbundance.Focus()
            End If
        End If
    End Sub

    Private Sub cboScientificName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScientificName.SelectedIndexChanged

        cboCommonName.Text = cboScientificName.SelectedValue
        SetTaxonGroup()
    End Sub

    Private Sub SetTaxonGroup()

        cboTaxonGroup.Text = ""
        'Must escape single quotes which can occur in names like Enchanter's Nightshade
        Dim row() As DataRow = dtTaxonGroup.Select("ScientificName='" & cboScientificName.Text.Replace("'", "''") & "' and CommonName='" & cboCommonName.Text.Replace("'", "''") & "'")

        If row.Length > 0 Then
            cboTaxonGroup.Text = row(0).Item("TaxonGroup").ToString()
            'If the text value is set before the form is shown, then it goes to blank
            'on form display, so we set the tag value and set from this once displayed.
            cboTaxonGroup.Tag = row(0).Item("TaxonGroup").ToString()
        End If

    End Sub

    Private Sub cboCommonName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCommonName.KeyUp

        'This shifts the focus to the okay button when a hash code is entered
        If e.KeyCode = Keys.Return Then

            If cboCommonName.Text.StartsWith("#") Then

                ValuesFromShortCut(cboCommonName.Text)
                'Shift the focus to abundance if taxon named
                If cboScientificName.Text <> "" Then
                    txtAbundance.Focus()
                End If
            ElseIf cboCommonName.SelectedIndex = -1 And cboCommonName.Text <> "" Then
                'User has entered a taxon which is not in list and then hit return - do
                'a search.
                NBNSearchJSON(cboCommonName.Text)
            ElseIf cboCommonName.Text = "" Then
                'Shift focus to scientific name 
                cboScientificName.Focus()
            ElseIf cboScientificName.Text = "" Then
                'Shift focus to scientific name 
                cboScientificName.Focus()
            Else
                'Shift focus to abundance
                txtAbundance.Focus()
            End If
        End If
    End Sub

    Private Sub cboCommonName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCommonName.LostFocus

        'DynamicScientificNameDropDown()
    End Sub

    Private Sub cboCommonName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCommonName.SelectedIndexChanged

        cboScientificName.Text = cboCommonName.SelectedValue
        SetTaxonGroup()
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If cboScientificName.SelectedIndex > 0 Then

            MessageBox.Show("Delete " & cboScientificName.Text)
        End If
    End Sub

    Private Sub txtAbundance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbundance.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True
            If txtAbundance.Text.Length = 0 Then
                'No abundance data being added so shift focus to commit button
                butOkay.Focus()
            Else
                txtAbundanceUnits.Focus()
            End If
        End If
    End Sub

    Private Sub txtAbundanceUnits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbundanceUnits.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True
            'Shift focus to commit button

            butOkay.Focus()
        End If
    End Sub

    Private Sub butOkay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkay.Click

        If Control.ModifierKeys = Keys.Shift Then
            'If shift was held down, will act as if butOkay6fig was clicked
            GridRefResChanged(100)
        End If

        CommitDialog()
    End Sub

    Private Sub dtpDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.CloseUp

        butOkay.Focus()
    End Sub


    Public Sub InitWho()

        txtRecorder.Text = rowActive.Cells("Recorder").Value
        txtDeterminer.Text = rowActive.Cells("Determiner").Value
        txtConfirmer.Text = rowActive.Cells("Confirmer").Value
    End Sub

    Private Sub InitWhat()
        TreeView1.Nodes.Clear()

        txtAuthority.Text = ""
        cboTaxonGroup.Text = ""
        txtVersionKey.Text = ""
        chkPreferred.Checked = False
        chkScientific.Checked = False
        chkWellFormed.Checked = False

        txtAbundance.Text = rowActive.Cells("Abundance").Value
        txtAbundanceUnits.Text = rowActive.Cells("Units").Value

        Dim db As clsDB = New clsDB
        Dim da As SQLiteDataAdapter

        Dim strSQLCommonName As String
        Dim strSQLScientificName As String
        Dim strSQLTaxonGroup As String
        If strTaxonDictionaryFilter.Trim().Length = 0 Then
            strSQLCommonName = "Select ScientificName, CommonName, TaxonGroup from TaxonDictionary where not CommonName = ''"
            strSQLScientificName = "Select ScientificName, CommonName, TaxonGroup from TaxonDictionary where not ScientificName = ''"
            strSQLTaxonGroup = "Select TaxonGroup, ScientificName, CommonName from TaxonDictionary"
        Else
            strSQLCommonName = "Select ScientificName, CommonName, TaxonGroup from TaxonDictionary where not CommonName = '' and TaxonGroup like '%" & strTaxonDictionaryFilter & "%'"
            strSQLScientificName = "Select ScientificName, CommonName, TaxonGroup from TaxonDictionary where not ScientificName = '' and TaxonGroup like '%" & strTaxonDictionaryFilter & "%'"
            strSQLTaxonGroup = "Select TaxonGroup, ScientificName, CommonName from TaxonDictionary where TaxonGroup like '%" & strTaxonDictionaryFilter & "%'"
        End If

        da = New SQLiteDataAdapter(strSQLCommonName, db.conMain)
        Dim dtCommonName As DataTable = New DataTable()
        da.Fill(dtCommonName)

        da = New SQLiteDataAdapter(strSQLScientificName, db.conMain)
        Dim dtScientificName As DataTable = New DataTable()
        da.Fill(dtScientificName)

        dtTaxonGroup.Clear()
        da = New SQLiteDataAdapter(strSQLTaxonGroup, db.conMain)
        da.Fill(dtTaxonGroup)

        'Text has to be set after form displayed. If done in init sub and value does not match one
        'in bound list, just shows a value from bound list. So for now we just set tag property and
        'this is used to set the text property in the shown event.

        cboCommonName.DisplayMember = "CommonName"
        cboCommonName.ValueMember = "ScientificName"
        cboCommonName.DataSource = dtCommonName
        cboCommonName.Tag = rowActive.Cells("CommonName").Value

        cboScientificName.DisplayMember = "ScientificName"
        cboScientificName.ValueMember = "CommonName"
        'cboScientificName.DataSource = dtScientificName
        Dim bs As BindingSource = New BindingSource
        bs.DataSource = dtScientificName
        cboScientificName.DataSource = bs
        cboScientificName.Tag = rowActive.Cells("ScientificName").Value

        'Taxon group drop-down list
        'If dtAllTaxonGroups.Rows.Count = 0 Then
        InitTaxonGroupList()
        'End If
        cboTaxonGroup.DisplayMember = "TaxonGroup"
        cboTaxonGroup.ValueMember = "TaxonGroup"
        cboTaxonGroup.DataSource = dtAllTaxonGroups
        cboTaxonGroup.Tag = rowActive.Cells("TaxonGroup").Value

        da.Dispose()
        db.Dispose()
    End Sub

    Private Sub DynamicScientificNameDropDown()

        Dim bs As BindingSource = cboScientificName.DataSource

        If Not bs Is Nothing Then
            If cboCommonName.Text <> "" Then
                bs.Filter = "CommonName = '" & cboCommonName.Text & "'"
                cboScientificName.DroppedDown = True
            Else
                bs.Filter = ""
            End If
        End If
    End Sub

    Private Sub InitTaxonGroupList()

        Dim strSQLTaxonGroup As String
        Dim db As clsDB = New clsDB

        'Get unique taxon group values from records table
        strSQLTaxonGroup = "select count(distinct TaxonGroup) from Records"
        Dim com As SQLiteCommand = New SQLiteCommand(db.conMain)
        com.CommandText = strSQLTaxonGroup
        If com.ExecuteScalar() > cboTaxonGroup.Items.Count Then
            strSQLTaxonGroup = "Select distinct TaxonGroup from Records"
            Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQLTaxonGroup, db.conMain)
            dtAllTaxonGroups.Clear()
            da.Fill(dtAllTaxonGroups)
        End If
    End Sub

    Public Sub InitWhere()

        txtGR.Text = rowActive.Cells("GridRef").Value
        txtLocation.Text = rowActive.Cells("Location").Value
        txtTown.Text = rowActive.Cells("Town").Value
        chkNewLocation.Checked = False
        chkProjectLocation.Checked = False

        txtGRMove.Text = ""
        Select Case txtGR.Text.Length
            Case 12 '10 fig 
                cbPrecision.SelectedIndex = 0
            Case 10 '8 fig
                cbPrecision.SelectedIndex = 1
            Case 8 '6 fig
                cbPrecision.SelectedIndex = 2
            Case 6 'Monad
                cbPrecision.SelectedIndex = 3
            Case 5 'Tetrad
                cbPrecision.SelectedIndex = 4
            Case 4
                cbPrecision.SelectedIndex = 5
            Case Else
                cbPrecision.SelectedIndex = 2
        End Select

        Dim objLocations As clsLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
        objLocations.PopulateDataGridView(lvLocations, clsLocations.PlaceType.Location)
        objLocations.PopulateDataGridView(lvTowns, clsLocations.PlaceType.Town)
    End Sub

    Public Sub InitWhen()

        Dim bNoDateValue As Boolean
        Dim bNoTimeValue As Boolean

        'Attempt to initialise date value from current row
        If rowActive.Cells("Date").Value Is Nothing Then
            bNoDateValue = True
        ElseIf rowActive.Cells("Date").Value = "" Then
            bNoDateValue = True
        Else
            dtpDate.Value = Convert.ToDateTime(rowActive.Cells("Date").Value)
            bNoDateValue = False
        End If

        If bNoDateValue Then
            chkNoDate.Checked = True
        Else
            chkNoDate.Checked = False
        End If

        If bNoDateValue Then
            'Attempt to initialise value from previous row, but leave 'no date'
            'checkbox checked.
            Dim i As Integer = frmMain.dgvRecords.SelectedRows(0).Index
            If i > 0 Then
                Dim previousRow As DataGridViewRow = frmMain.dgvRecords.Rows(i - 1)

                If previousRow.Cells("Date").Value Is Nothing Then
                    bNoDateValue = True
                ElseIf previousRow.Cells("Date").Value = "" Then
                    bNoDateValue = True
                Else
                    dtpDate.Value = Convert.ToDateTime(previousRow.Cells("Date").Value)
                    bNoDateValue = False
                End If
            End If
        End If

        If bNoDateValue Then
            'Default to today's date, but leave 'no date'
            'checkbox checked.
            dtpDate.Value = Now()
        End If

        'Attempt to initialise time value from current row
        If rowActive.Cells("Time").Value Is Nothing Then
            bNoTimeValue = True
        ElseIf rowActive.Cells("Time").Value = "" Then
            bNoTimeValue = True
        Else
            dtpTime.Value = Convert.ToDateTime(rowActive.Cells("Time").Value)
            bNoTimeValue = False
        End If

        If bNoTimeValue Then
            chkNoTime.Checked = True
        Else
            chkNoTime.Checked = False
        End If

        If bNoTimeValue Then
            'Attempt to initialise value from previous row, but leave 'no time'
            'checkbox checked.
            Dim i As Integer = frmMain.dgvRecords.SelectedRows(0).Index
            If i > 0 Then
                Dim previousRow As DataGridViewRow = frmMain.dgvRecords.Rows(i - 1)

                If previousRow.Cells("Time").Value Is Nothing Then
                    bNoTimeValue = True
                ElseIf previousRow.Cells("Time").Value = "" Then
                    bNoTimeValue = True
                Else
                    dtpTime.Value = Convert.ToDateTime(previousRow.Cells("Time").Value)
                    bNoTimeValue = False
                End If
            End If
        End If

        If bNoTimeValue Then
            'Default to midnight
            dtpTime.Value = Convert.ToDateTime("00:00")
        End If
    End Sub

    Public Sub InitComments()

        txtComment.Text = rowActive.Cells("Comment").Value
        txtPersonalNotes.Text = rowActive.Cells("PersonalNotes").Value
        chkExcludeFromExport.Checked = rowActive.Cells("NoExport").Value
    End Sub

    Private Sub frmRecordDetails_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        pbMap.Image = Nothing

        Dim pFfplay() As Process = Process.GetProcessesByName("ffplay")
        Dim p As Process
        For Each p In pFfplay
            p.Kill()
        Next
    End Sub

    Private Sub frmRecordDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'Text has to be set after form displayed. If done in init field and value does not match one
        'in bound list, just shows a value from bound list.

        cboCommonName.SelectedItem = Nothing
        cboScientificName.SelectedItem = Nothing
        cboTaxonGroup.SelectedItem = Nothing

        cboScientificName.Text = cboScientificName.Tag
        cboCommonName.Text = cboCommonName.Tag
        cboTaxonGroup.Text = cboTaxonGroup.Tag

        'If cboCommonName.Text = "" And cboScientificName.Text = "" Then
        '    cboTaxonGroup.Text = ""
        'End If

        'Initialise tab display
        InitTab()

        'Play voice clip if 'what' tab is active

        If tcMain.SelectedTab Is tcMain.TabPages("tabWhat") Then
            If Not sender Is Nothing Then
                If frmOptions.chkPlaySound.Checked Then
                    butVoice_Click(Nothing, Nothing)
                End If
            End If
        End If

        'Initialise the frmNBNTaxonSelection form
        frmNBNTaxonSelection.SetName(cboScientificName.Text)
    End Sub

    Private Sub txtRecorder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecorder.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True

            txtDeterminer.Focus()
            txtDeterminer.SelectAll()
        End If
    End Sub

    Private Sub txtDeterminer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeterminer.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True

            txtConfirmer.Focus()
            txtConfirmer.SelectAll()
        End If
    End Sub

    Private Sub txtConfirmer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConfirmer.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True
            'Shift focus to commit button
            butOkay.Focus()
        End If
    End Sub

    Private Sub txtComment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComment.KeyDown

        If e.Alt Then
            bCtrlPressed = True
        Else
            bCtrlPressed = False
        End If
    End Sub

    Private Sub txtComment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComment.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            If Not bCtrlPressed Then
                'Suppresses the windows ding sound when enter is presses in a single-line textbox
                e.Handled = True
                txtPersonalNotes.Focus()
            End If
        End If
    End Sub

    Private Sub lvLocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLocations.Click

        txtLocation.Text = lvLocations.FocusedItem.Text
    End Sub

    Private Sub lvTowns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTowns.Click

        txtTown.Text = lvTowns.FocusedItem.Text()
    End Sub

    Private Sub nudOclock_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudOclock.ValueChanged

        If Not oClockPreventRecurse Then

            If nudOclock.Value = nudOclock.Maximum Then
                oClockPreventRecurse = True
                nudOclock.Value = nudOclock.Minimum + 1
            ElseIf nudOclock.Value = nudOclock.Minimum Then
                oClockPreventRecurse = True
                nudOclock.Value = nudOclock.Maximum - 1
            End If
        Else
            oClockPreventRecurse = False
        End If
    End Sub

    Private Sub chkProjectLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProjectLocation.CheckedChanged

        nudOffset.Enabled = chkProjectLocation.Checked
        nudOclock.Enabled = chkProjectLocation.Checked
        grpLineOfBestFit.Enabled = chkProjectLocation.Checked
    End Sub

    Private Sub radAutoBestFit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAutoBestFit.CheckedChanged

        nudGEPoints.Enabled = Not radAutoBestFit.Checked
    End Sub

    Private Sub txtGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGR.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            butGetLocation_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub txtGR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGR.TextChanged

        If txtGR.Text.StartsWith("<?xml") Then

            Dim str As String = txtGR.Text

            str = str.Replace(ControlChars.FormFeed, "")
            str = str.Replace(ControlChars.NewLine, "")
            str = str.Replace(ControlChars.VerticalTab, "")
            str = str.Replace(ControlChars.Tab, "")
            str = str.Replace(ControlChars.CrLf, "")
            str = str.Replace(ControlChars.Lf, "")
            str = str.Replace(ControlChars.Cr, "")

            Dim objGridRef As GridRef = New GridRef
            objGridRef.MakePrefixArrays()
            Dim xmlNode As XmlNode
            Dim XMLnr As XmlNodeReader

            Dim xmlDoc As New XmlDocument
            Dim ns As XmlNamespaceManager
            ns = New XmlNamespaceManager(xmlDoc.NameTable)
            ns.AddNamespace("gx", "http://www.google.com/kml/ext/2.2")
            ns.AddNamespace("kml", "http://www.opengis.net/kml/2.2")
            ns.AddNamespace("atom", "http://www.w3.org/2005/Atom")

            Dim strXml As String = str
            Try
                xmlDoc.LoadXml(strXml)
            Catch ex As Exception
                txtGR.Text = ""
                MessageBox.Show("Couldn't parse XML string - report this as a bug. Error message: " & ex.Message)
                Exit Sub
            End Try

            Dim root As XmlElement = xmlDoc.DocumentElement

            'First look for a name element that has a valid grid ref
            xmlNode = root.SelectSingleNode("//kml:Placemark/kml:name", ns)
            If Not xmlNode Is Nothing Then
                XMLnr = New XmlNodeReader(xmlNode)
                objGridRef.GridRef = xmlNode.InnerText
                objGridRef.ParseGridRef(False)
                If objGridRef.sErrorMessage = "" Then
                    'The name of the placemark was a valid grid reference so use this
                    txtGR.Text = objGridRef.GridRef
                Else
                    'Look now for placemark point coordinates, convert to 10 fig GR and use that 
                    xmlNode = root.SelectSingleNode("//kml:Placemark/kml:Point/kml:coordinates", ns)

                    If Not xmlNode Is Nothing Then
                        XMLnr = New XmlNodeReader(xmlNode)

                        Dim coords() As String = xmlNode.InnerText.Split(",")
                        Dim dblLon As Double = Convert.ToDouble(coords(0))
                        Dim dblLat As Double = Convert.ToDouble(coords(1))

                        Dim dblLonOSGB36 As Double = objGridRef.WGS84Long2OSGGB36(dblLat, dblLon, 100)
                        Dim dblLatOSGB36 As Double = objGridRef.WGS84Lat2OSGGB36(dblLat, dblLon, 100)

                        txtGR.Text = objGridRef.EN210fig(objGridRef.Lon2Easting(dblLatOSGB36, dblLonOSGB36), objGridRef.Lat2Northing(dblLatOSGB36, dblLonOSGB36))
                        butGetLocation_Click(Nothing, Nothing)
                    Else
                        txtGR.Text = ""
                    End If
                End If
            End If
        Else
            txtGR.Text = txtGR.Text.ToUpper()
            txtGR.SelectionStart = txtGR.Text.Length
        End If
    End Sub

    Private Sub butGetLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetLocation.Click

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        objGridRef.sErrorMessage = ""
        objGridRef.GridRef = txtGR.Text
        objGridRef.ParseGridRef(False)

        If Not objGridRef.sErrorMessage.Length = 0 Then

            MessageBox.Show(objGridRef.sErrorMessage)
        Else
            cfun.CheckGazDB()

            'Reset location and town lists from current grid reference
            Dim objLocations As clsLocations = New clsLocations(txtGR.Text, frmOptions.txtDB.Text)
            objLocations.PopulateDataGridView(lvLocations, clsLocations.PlaceType.Location)
            objLocations.PopulateDataGridView(lvTowns, clsLocations.PlaceType.Town)

            If lvLocations.Items.Count > 0 Then
                txtLocation.Text = lvLocations.Items(0).SubItems(0).Text
            End If
            If lvTowns.Items.Count > 0 Then
                txtTown.Text = lvTowns.Items(0).SubItems(0).Text
            End If

            butOkay.Focus()
            End If
    End Sub

    Public Sub GridRefResChanged(ByVal intRes As Integer)

        If cfun.HasNoValue(rowActive.Cells("FileLat").Value) Then
            MessageBox.Show("Grid reference can only be reset for records generated from GPS data.")
        ElseIf rowActive.Cells("FileLat").Value = 1 And rowActive.Cells("FileLon").Value = 1 Then
            'For some reason, I have a number of moth records where filelat and 
            'filelon are zero
            MessageBox.Show("Grid reference can only be reset for records generated from GPS data.")
        Else
            txtGR.Text = cfun.GetGridRef(rowActive.Cells("FileLon").Value, rowActive.Cells("FileLat").Value, intRes)
        End If
    End Sub

    Private Sub UpdateGazetteer()

        Dim db As clsDB = New clsDB

        objGridRef.GridRef = txtGR.Text
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        Dim com As SQLiteCommand = New SQLiteCommand("Insert into osDistrictVectorGaz(X, Y, Name, Type) values(?,?,?,?)", db.conGazetteer)
        com.Parameters.AddWithValue("X", objGridRef.East)
        com.Parameters.AddWithValue("Y", objGridRef.North)
        com.Parameters.AddWithValue("Location", txtLocation.Text)
        com.Parameters.AddWithValue("Type", "G")

        'Trap this to prevent crashing if duplicates attempted
        Try
            com.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Insertion of new location in gazetteer failed: " & ex.Message)
        End Try

        com.Dispose()
        db.Dispose()
    End Sub

    Private Sub tcMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMain.SelectedIndexChanged

        InitTab()
    End Sub

    Private Sub InitTab()
        Select Case tcMain.SelectedTab.Name

            Case "tabWho"
                txtRecorder.Focus()
                txtRecorder.SelectAll()
            Case "tabWhat"
                cboCommonName.Focus()
                cboCommonName.SelectionStart = 0
                cboCommonName.SelectionLength = cboCommonName.Text.Length
            Case "tabWhere"
                txtGR.Focus()
            Case "tabComment"
                txtComment.Focus()
                txtComment.SelectionStart = txtComment.Text.Length
                txtComment.SelectionLength = 0
            Case Else

        End Select
    End Sub

    Private Function ProjectedGR() As String

        Dim strGR As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim theta12Oclock As Double = theta + PI
        Dim deltaTheta As Double = 30 * PI / 180
        Dim projectedTheta As Double

        'Origin easting/northings
        Dim x0 As Double = objGridRef.LongWGS842Easting(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value, 100)
        Dim y0 As Double = objGridRef.LatWGS842Northing(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value, 100)

        'Projected easting/northings
        Dim x1 As Double
        Dim y1 As Double

        'Work out projected angle
        i = nudOclock.Value
        If i < 1 Then
            j = 12 - i
        ElseIf i > 12 Then
            j = i - 12
        Else
            j = i
        End If
        projectedTheta = theta12Oclock - j * deltaTheta

        x1 = x0 + nudOffset.Value * Cos(projectedTheta)
        y1 = y0 + nudOffset.Value * Sin(projectedTheta)

        Select Case txtGR.Text.Length
            'Precision of returned value matches whatever is currently specified
            'for GR. Defaults to 8 fig.
            Case 4
                strGR = objGridRef.EN2Hectad(x1, y1)
            Case 5
                strGR = objGridRef.EN2Tetrad(x1, y1)
            Case 6
                strGR = objGridRef.EN2Monad(x1, y1)
            Case 8
                strGR = objGridRef.EN26fig(x1, y1)
            Case 12
                strGR = objGridRef.EN210fig(x1, y1)
            Case Else
                strGR = objGridRef.EN28fig(x1, y1)
        End Select

        Return strGR
    End Function

    Protected Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean

        'if the focus is in a control in the tab control then tab just moves
        'between tabs of the tab control. Otherwise, do the usual thing.

        Dim intTab As Integer = tcMain.SelectedIndex

        If (ActiveControl.Parent Is Me And Not ActiveControl Is tcMain) Or ActiveControl.Parent Is grpOkay Then
            Return MyBase.ProcessTabKey(forward)
        Else
            If forward Then
                intTab += 1
            Else
                intTab -= 1
            End If

            If intTab < 0 Then
                intTab = tcMain.TabPages.Count - 1
            ElseIf intTab > tcMain.TabPages.Count - 1 Then
                intTab = 0
            End If
            tcMain.SelectedIndex = intTab

            Return True 'Ensures tab not put into current active control
        End If
    End Function

    Private Sub butSearchCommonName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearchCommonName.Click

        NBNSearchJSON(cboCommonName.Text)
    End Sub

    Private Sub butSearchScientificName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearchScientificName.Click

        NBNSearchJSON(cboScientificName.Text)
    End Sub

    Private Sub timDebug_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timDebug.Tick

        lblComSelIndex.Text = "cboCommonName.SelectedIndex: " & cboCommonName.SelectedIndex.ToString
        lblComValue.Text = "cboCommonName.SelectedValue:" & cboCommonName.SelectedValue
        lblSciSelIndex.Text = "cboScientificName.SelectedIndex:" & cboScientificName.SelectedIndex.ToString
        lblSciValue.Text = "cboScientificName.SelectedIndex:" & cboScientificName.SelectedValue
    End Sub

    Private Sub chkDebug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebug.CheckedChanged
        gbDebug.Visible = chkDebug.Checked
        timDebug.Enabled = chkDebug.Checked
    End Sub

    Private Sub but6fig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but6fig.Click
        GridRefResChanged(100)
    End Sub

    Private Sub butMonad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMonad.Click
        GridRefResChanged(1000)
    End Sub

    Private Sub butHectad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHectad.Click
        GridRefResChanged(10000)
    End Sub

    Private Sub butTetrad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTetrad.Click
        GridRefResChanged(2000)
    End Sub

    Private Sub but8fig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but8fig.Click
        GridRefResChanged(10)
    End Sub

    Private Sub but10fig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but10fig.Click
        GridRefResChanged(1)
    End Sub

    Private Sub butOkay6fig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkay6fig.Click

        GridRefResChanged(100)
        CommitDialog()
    End Sub

    Private Sub butOkayMonad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkayMonad.Click

        GridRefResChanged(1000)
        CommitDialog()
    End Sub

    Private Sub ValuesFromShortCut(ByVal strHash As String)

        'A hash code was specified - update the controls according to values stored against the
        'hash code in the database.
        Dim db As clsDB = New clsDB

        Dim com As SQLiteCommand = New SQLiteCommand("Select * from HashCodes where Hash = ?", db.conMain)
        com.Parameters.AddWithValue("Hash", strHash)
        Dim odr As SQLiteDataReader = com.ExecuteReader()

        If Not odr.HasRows Then

            MessageBox.Show("The code you specified was not found in the database")
        Else
            odr.Read()
            Dim strDate As String
            If cfun.HasNoValue(odr.Item("RecDate")) Then
                strDate = ""
            Else
                strDate = Format(odr.Item("RecDate"), "dd/MM/yyyy")
            End If
            UpdateFromHash(cboCommonName.Text, odr.Item("CommonName"))
            UpdateFromHash(cboScientificName.Text, odr.Item("ScientificName"))
            UpdateFromHash(cboTaxonGroup.Text, odr.Item("TaxonGroup"))
            UpdateFromHash(txtAbundance.Text, odr.Item("Abundance"))
            UpdateFromHash(txtAbundanceUnits.Text, odr.Item("Units"))
            UpdateFromHash(txtLocation.Text, odr.Item("Location"))
            UpdateFromHash(txtTown.Text, odr.Item("Town"))
            UpdateFromHash(txtGR.Text, odr.Item("GridRef"))
            UpdateFromHash(txtComment.Text, odr.Item("Comment"))
        End If
        odr.Close()
    End Sub

    Private Sub butAddMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddMedia.Click

        OpenFileDialog.Filter = "JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.fig|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            cfun.AddMediaFile(OpenFileDialog.FileName, rowActive.Cells("ID").Value, lvMedia.Items.Count + 1)
            refreshMediaImageTab()
        End If
    End Sub

    Private Sub refreshMediaImageTab()

        Dim db As clsDB = New clsDB
        Dim strSQL As String = "select * from media, recordmedia where recordmedia.recordID = " & rowActive.Cells("ID").Value.ToString & " and media.fileid = recordmedia.fileid order by [Order]"
        Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMedia)
        Dim dtMedia As DataTable = New DataTable()

        da.Fill(dtMedia)

        imlMedia.Images.Clear()
        lvMedia.Clear()

        Dim row As DataRow
        Dim intImage As Integer = 0

        For Each row In dtMedia.Rows

            Dim mi As clsMediaItem = New clsMediaItem(row)
            imlMedia.Images.Add(cfun.GetImageFromByteArray(row("Thumbnail")))

            Dim lvi As ListViewItem = New ListViewItem(mi.ListViewItems, intImage)
            lvMedia.Items.Add(lvi)
            intImage += 1

            lvi.Text = intImage.ToString & ". " & GetMediaListViewItemText(row)
        Next

        If lvMedia.Items.Count > 0 Then
            lvMedia.Items(0).Selected = True
        Else
            picMedia.Image = Nothing
        End If
    End Sub

    Private Function GetMediaListViewItemText(ByVal row As DataRow)

        Dim strCaption As String

        If cfun.HasNoValue(row("Comment")) Then
            strCaption = ""
        Else
            strCaption = cfun.GetHeadlineFromText(row("Comment"))
        End If

        If strCaption = "" Then

            Dim strBuiltPath As String = Path.Combine(frmOptions.txtDBFolder.Text, row("RelativePath"))
            If File.Exists(strBuiltPath) Then
                strCaption = Path.GetFileName(strBuiltPath)
            ElseIf File.Exists(row("FullPath")) Then
                strCaption = Path.GetFileName(row("FullPath"))
            End If
        End If

        Return strCaption
    End Function

    Private Sub lvMedia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMedia.SelectedIndexChanged

        Dim strImagePath As String = ""
        picMedia.Image = Nothing

        If lvMedia.SelectedItems.Count > 0 Then

            Dim db As clsDB = New clsDB
            Dim strSQL As String = "select * from media where FileID = " & lvMedia.SelectedItems(0).SubItems(1).Text
            Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMedia)
            Dim dtMedia As DataTable = New DataTable()
            da.Fill(dtMedia)
            Dim row As DataRow = dtMedia.Rows(0)

            'Comment
            lblMediaComment.Text = row("Comment")


            If Not cfun.HasNoValue(row("Data")) Then
                'If the image is stored directly in the DB, then display it.
                Try
                    picMedia.Image = cfun.GetImageFromByteArray(row("Data"))
                Catch
                End Try
            Else
                Dim strBuiltPath As String = Path.Combine(frmOptions.txtDBFolder.Text, row("RelativePath"))
                If File.Exists(strBuiltPath) Then
                    'If the image can be located via relative path, then display this.
                    Try
                        picMedia.Load(strBuiltPath)
                    Catch
                    End Try
                ElseIf File.Exists(row("FullPath")) Then
                    'If the image can be located via full path, then display this.
                    Try
                        picMedia.Load(row("FullPath"))
                    Catch
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub butDeleteMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteMedia.Click

        Dim strImagePath As String = ""

        If lvMedia.SelectedItems.Count > 0 Then

            Dim db As clsDB = New clsDB
            Dim comMedia As SQLiteCommand = New SQLiteCommand(db.conMedia)
            'Delete from RecordMedia table for this RecordID and FileID
            comMedia.CommandText = "Delete from RecordMedia where RecordID = " & rowActive.Cells("ID").Value.ToString() & " and FileID = " & lvMedia.SelectedItems(0).SubItems(1).Text
            comMedia.ExecuteNonQuery()
            'Delete media orphans
            comMedia.CommandText = "delete from Media where FileID not in (Select FileID from RecordMedia);"
            comMedia.ExecuteNonQuery()

            'Re-calculate the order fields
            Dim strSQL As String = "select * from recordmedia where recordmedia.recordID = " & rowActive.Cells("ID").Value.ToString & " order by [Order]"
            Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMedia)
            Dim dtMedia As DataTable = New DataTable()
            da.Fill(dtMedia)
            comMedia.CommandText = "update RecordMedia set [Order]=? where RecordID = " & rowActive.Cells("ID").Value.ToString() & " and FileID = ?"
            Dim paramOrder As SQLiteParameter = New SQLiteParameter
            comMedia.Parameters.Add(paramOrder)
            Dim paramFileID As SQLiteParameter = New SQLiteParameter
            comMedia.Parameters.Add(paramFileID)
            Dim i As Integer
            For i = 0 To dtMedia.Rows.Count - 1
                paramOrder.Value = i + 1
                paramFileID.Value = dtMedia.Rows(i).Item("FileID")
                comMedia.ExecuteNonQuery()
            Next

            refreshMediaImageTab()
        Else
            MessageBox.Show("Select an image to delete first.", "No image selected")
        End If

    End Sub

    Private Sub MoveMediaItem(ByVal direction As MoveDirection)

        If lvMedia.SelectedItems.Count > 0 Then

            Dim db As clsDB = New clsDB
            Dim comMedia As SQLiteCommand = New SQLiteCommand(db.conMedia)

            Dim iSwapIndex1 As Integer
            Dim iSwapIndex2 As Integer
            Dim iNewIndex As Integer
            Dim iFileID1 As Integer
            Dim iFileID2 As Integer

            If direction = MoveDirection.Down Then
                iSwapIndex1 = lvMedia.SelectedItems(0).Index
                iSwapIndex2 = iSwapIndex1 + 1
                iNewIndex = iSwapIndex2
            Else
                iSwapIndex2 = lvMedia.SelectedItems(0).Index
                iSwapIndex1 = iSwapIndex2 - 1
                iNewIndex = iSwapIndex1
            End If

            If iSwapIndex1 >= 0 And iSwapIndex2 < lvMedia.Items.Count Then

                'Its a valid move
                iFileID1 = CInt(lvMedia.Items(iSwapIndex1).SubItems(1).Text)
                iFileID2 = CInt(lvMedia.Items(iSwapIndex2).SubItems(1).Text)
                comMedia.CommandText = "update RecordMedia set [Order]=? where RecordID = " & rowActive.Cells("ID").Value.ToString() & " and FileID = ?"

                Dim paramOrder As SQLiteParameter = New SQLiteParameter
                comMedia.Parameters.Add(paramOrder)
                Dim paramFileID As SQLiteParameter = New SQLiteParameter
                comMedia.Parameters.Add(paramFileID)

                paramOrder.Value = iSwapIndex2 + 1 'Because list is zero based but order is not
                paramFileID.Value = iFileID1
                comMedia.ExecuteNonQuery()

                paramOrder.Value = iSwapIndex1 + 1 'Because list is zero based but order is not
                paramFileID.Value = iFileID2
                comMedia.ExecuteNonQuery()

                refreshMediaImageTab()
                'Retain original selection
                lvMedia.SelectedIndices.Clear()
                lvMedia.Items(iNewIndex).Selected = True
            End If
        Else
            MessageBox.Show("Select an image to move first.", "No image selected")
        End If
    End Sub
    Private Sub butMediaUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMediaUp.Click

        MoveMediaItem(MoveDirection.Up)
    End Sub

    Private Sub butMediaDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMediaDown.Click

        MoveMediaItem(MoveDirection.Down)
    End Sub

    Private Sub butMediaProps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMediaProps.Click

        frmImageProperties.InitForFileID(lvMedia.SelectedItems(0).SubItems(1).Text)
        frmImageProperties.ShowDialog()

        If frmImageProperties.DialogCommitted Then
            If lvMedia.SelectedIndices.Count > 0 Then
                Dim iSelIndex As Integer = lvMedia.SelectedIndices(0)
                refreshMediaImageTab()
                'Retain original selection
                lvMedia.SelectedIndices.Clear()
                lvMedia.Items(iSelIndex).Selected = True
            End If
        End If
    End Sub

    Private Sub txtComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComment.TextChanged

        SetHeadlineComment()
    End Sub

    Private Sub SetHeadlineComment()

        If txtPersonalNotes.Text.Trim <> "" Then

            lblHeadlineComment.Text = cfun.GetHeadlineFromText(txtPersonalNotes.Text.Trim)

        ElseIf txtComment.Text.Trim <> "" Then

            lblHeadlineComment.Text = cfun.GetHeadlineFromText(txtComment.Text.Trim)
        Else
            lblHeadlineComment.Text = "Headline comment"
        End If
    End Sub

    Private Sub txtPersonalNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonalNotes.KeyDown

        If e.Control Then
            bCtrlPressed = True
        Else
            bCtrlPressed = False
        End If
    End Sub

    Private Sub txtPersonalNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonalNotes.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            If Not bCtrlPressed Then
                'Suppresses the windows ding sound when enter is presses in a single-line textbox
                e.Handled = True
                'Shift focus to commit button
                butOkay.Focus()
            End If
        End If
    End Sub

    Private Sub txtPersonalNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersonalNotes.TextChanged

        SetHeadlineComment()
    End Sub

    Private Sub chkNoTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoTime.CheckedChanged

        dtpTime.Enabled = Not chkNoTime.Checked
        If chkNoTime.Checked Then
            chkNoTime.Font = New Font(chkNoTime.Font, FontStyle.Bold)
        Else
            chkNoTime.Font = New Font(chkNoTime.Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub chkNoDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoDate.CheckedChanged

        dtpDate.Enabled = Not chkNoDate.Checked
        If chkNoDate.Checked Then
            chkNoDate.Font = New Font(chkNoTime.Font, FontStyle.Bold)
        Else
            chkNoDate.Font = New Font(chkNoTime.Font, FontStyle.Regular)
        End If
    End Sub

    Private Sub butOffsetGR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOffsetGR.Click

        Cursor = Cursors.WaitCursor

        Dim intPointNumber As Integer

        'Check for valid GR
        objGridRef.GridRef = txtGR.Text
        objGridRef.sErrorMessage = ""
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage <> "" Then
            MessageBox.Show(objGridRef.sErrorMessage)
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        If chkProjectLocation.Checked Then

            'Get the associated track file, if any
            Dim db As clsDB = New clsDB
            Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)

            comTracks.CommandText = "select FileID from RecordTracks where RecordID = " & rowActive.Cells("ID").Value
            Dim intTrackID As Integer = comTracks.ExecuteScalar()

            Dim inFile As clsInputFile
            comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = " & intTrackID
            Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
            Dim dtTrackFile As DataTable = New DataTable
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count = 0 Then
                MessageBox.Show("You cannot calculate an offset grid reference if no track is associated with the record.")
            Else
                Dim strTrackFile As String = dtTrackFile.Rows(0)("CurrentPath")
                Dim strFiletype As String = dtTrackFile.Rows(0)("FileType")

                inFile = Nothing
                Select Case strFiletype.ToLower()

                    Case "visiontac"
                        inFile = New clsInputFileVisiontac(strTrackFile)
                End Select

                If radAutoBestFit.Checked Then
                    intPointNumber = 0
                Else
                    intPointNumber = nudGEPoints.Value
                End If
                Dim dtTrackToPoint As DataTable = inFile.TrackToPoint(cfun.NullToEmpty(rowActive.Cells("FileIndex").Value), cfun.NullToEmpty(rowActive.Cells("Date").Value), cfun.NullToEmpty(rowActive.Cells("Time").Value), intPointNumber)

                'Following function removed to clsOffsetGR - would need to sort this out if re-implemented
                'LineOfBestFitCoords(dtTrackToPoint) 'Calculates theta global variable required by ProjectedGR

                txtGR.Text = ProjectedGR()
            End If
        End If

        Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTaxonGroup_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTaxonGroup.KeyUp

        If e.KeyCode = Keys.Return Then

            'Shift focus to abundance
            txtAbundance.Focus()
        End If
    End Sub

    Private Sub butMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMap.Click

        'Check for valid GR
        If txtGR.Text.Trim = "" Then
            MessageBox.Show("You must first specify a grid reference.")
            Exit Sub
        End If
        objGridRef.GridRef = txtGR.Text
        objGridRef.sErrorMessage = ""
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage <> "" Then
            MessageBox.Show(objGridRef.sErrorMessage)
            Exit Sub
        End If

        txtGRMove.Text = ""

        If Not rbMapsGE.Checked Then
            Select Case objGridRef.sRefType
                Case "100km"
                    tbZoom.Value = 5
                Case "hectad"
                    tbZoom.Value = 10
                Case "tetrad"
                    tbZoom.Value = 12
                Case "monad"
                    tbZoom.Value = 13
                Case "6fig"
                    tbZoom.Value = 16
                Case "8fig"
                    tbZoom.Value = 17
                Case "10fig"
                    tbZoom.Value = 19
                Case Else
                    tbZoom.Value = 13
            End Select
        End If

        Dim dblLon = objGridRef.Easting2LongWGS84(objGridRef.East, objGridRef.North, 0)
        Dim dblLat = objGridRef.Northing2LatWGS84(objGridRef.East, objGridRef.North, 0)

        If chkProjectLocation.Checked Then
            Dim iPoints As Integer
            If radAutoBestFit.Checked Then
                iPoints = 0
            Else
                iPoints = nudGEPoints.Value
            End If
            mgrOffset = New clsOffsetGR(rowActive, nudOffset.Value, nudOclock.Value, iPoints)
            If mgrOffset.Message <> "" Then

                Dim strMessage = mgrOffset.Message
                'mgrOffset must be set to nothing before messagebox is shown
                'because of event firing when messagebox invalidates map
                mgrOffset = Nothing
                MessageBox.Show(strMessage)
                chkProjectLocation.Checked = False
            End If
        Else
            mgrOffset = Nothing
        End If

        If rbMapsBing.Checked Then
            GetMapBing(dblLat, dblLon)
        ElseIf rbMapsGoogle.Checked Then
            GetMapGoogle(dblLat, dblLon)
        Else 'rbMapsGE.checked
            GetMapGE()
        End If

        CalculateTrack()
    End Sub

    Private Sub GetMapGE()

        'Create the KML file with the place markers
        Dim strKMLFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\G21GridRef.kml"
        Dim srKML As StreamWriter = New StreamWriter(strKMLFile)

        srKML.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        srKML.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")

        srKML.WriteLine("<Folder>")
        srKML.WriteLine("<name>Gilbert 21 grid ref</name>")

        'Define the LookAt tag if only the GR is displayed
        If Not chkProjectLocation.Checked Then
            KML.LookAtKML(srKML, txtGR.Text)
        End If

        KML.StyleKML(srKML, frmOptions.butStyle100km.BackColor, "100km")
        KML.StyleKML(srKML, frmOptions.butStyle10km.BackColor, "hectad")
        KML.StyleKML(srKML, frmOptions.butStyle2km.BackColor, "tetrad")
        KML.StyleKML(srKML, frmOptions.butStyle1km.BackColor, "monad")
        KML.StyleKML(srKML, frmOptions.butStyle100m.BackColor, "6fig")
        KML.StyleKML(srKML, frmOptions.butStyle10m.BackColor, "8fig")
        KML.StyleKML(srKML, frmOptions.butStyle1m.BackColor, "10fig")

        If chkProjectLocation.Checked Then
            'Path line style
            srKML.WriteLine("<Style id=""pathLine"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>3</width>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("</Style>")

            'Best fit line style
            srKML.WriteLine("<Style id=""bestFitLine"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>3</width>")
            srKML.WriteLine("<color>ff0000ff</color>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("</Style>")

            'Projected sector style 1
            srKML.WriteLine("<Style id=""projectedSect1"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>1</width>")
            srKML.WriteLine("<color>ff0000ff</color>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("<PolyStyle>")
            srKML.WriteLine("<color>7fffffff</color>")
            srKML.WriteLine("</PolyStyle>")
            srKML.WriteLine("</Style>")

            'Projected sector style 2
            srKML.WriteLine("<Style id=""projectedSect2"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>1</width>")
            srKML.WriteLine("<color>ff0000ff</color>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("<PolyStyle>")
            srKML.WriteLine("<color>b2ffffff</color>")
            srKML.WriteLine("</PolyStyle>")
            srKML.WriteLine("</Style>")

            'Projected sector style 3
            srKML.WriteLine("<Style id=""projectedSect3"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>1</width>")
            srKML.WriteLine("<color>ff0000ff</color>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("<PolyStyle>")
            srKML.WriteLine("<color>7fffffff</color>")
            srKML.WriteLine("</PolyStyle>")
            srKML.WriteLine("</Style>")
        End If

        'Recorded location style
        srKML.WriteLine("<Style id=""recLatLon"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<scale>0.8</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("<hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels""/>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")

        'If Not rowActive.Cells("FileLat").Value Is Nothing Then

        '    'Render the recorded lat/lon position 
        '    srKML.WriteLine("<Placemark>")
        '    srKML.WriteLine("<styleUrl>#recLatLon</styleUrl>")
        '    srKML.WriteLine("<Point>")
        '    srKML.WriteLine("<coordinates>")
        '    srKML.WriteLine(rowActive.Cells("FileLon").Value.ToString() & "," & rowActive.Cells("FileLat").Value.ToString() & ",0")
        '    srKML.WriteLine("</coordinates>")
        '    srKML.WriteLine("</Point>")
        '    srKML.WriteLine("</Placemark>")
        'End If

        'Render the grid reference squares
        KML.RenderGR(srKML, txtGR.Text, True)

        'Do the offset
        If chkProjectLocation.Checked Then
            Dim iPoints As Integer
            If radAutoBestFit.Checked Then
                iPoints = 0
            Else
                iPoints = nudGEPoints.Value
            End If

            If Not mgrOffset Is Nothing Then
                Dim ll As clsOffsetGR.clsLatLon

                'Render the path leading up to the point of recording
                srKML.WriteLine("<Placemark>")
                srKML.WriteLine("<styleUrl>#pathLine</styleUrl>")
                srKML.WriteLine("<LineString>")
                srKML.WriteLine("<tessellate>1</tessellate>")
                srKML.WriteLine("<coordinates>")

                For Each ll In mgrOffset.Track
                    srKML.WriteLine(" " & ll.Lon.ToString & "," & ll.Lat.ToString & ",0")
                Next
                srKML.WriteLine("</coordinates>")
                srKML.WriteLine("</LineString>")
                srKML.WriteLine("</Placemark>")

                'Render the best fit line
                srKML.WriteLine("<Placemark>")
                srKML.WriteLine("<styleUrl>#bestFitLine</styleUrl>")
                srKML.WriteLine("<LineString>")
                srKML.WriteLine("<tessellate>1</tessellate>")
                srKML.WriteLine("<coordinates>")
                srKML.WriteLine(mgrOffset.BestFitStart.Lon.ToString & "," & mgrOffset.BestFitStart.Lat.ToString & ",0 " & mgrOffset.BestFitEnd.Lon.ToString & "," & mgrOffset.BestFitEnd.Lat.ToString & ",0")
                srKML.WriteLine("</coordinates>")
                srKML.WriteLine("</LineString>")
                srKML.WriteLine("</Placemark>")

                'Render the offset graphics
                Dim iSect As Integer
                For iSect = 1 To 3
                    Dim colPoints As Collection
                    If iSect = 1 Then
                        colPoints = mgrOffset.Segment1
                    ElseIf iSect = 2 Then
                        colPoints = mgrOffset.Segment2
                    Else
                        colPoints = mgrOffset.Segment3
                    End If

                    srKML.WriteLine("<Placemark>")
                    srKML.WriteLine("<styleUrl>#projectedSect" & iSect.ToString() & "</styleUrl>")
                    srKML.WriteLine("<Polygon>")
                    srKML.WriteLine("<tessellate>1</tessellate>")
                    srKML.WriteLine("<outerBoundaryIs>")
                    srKML.WriteLine("<LinearRing>")
                    srKML.WriteLine("<coordinates>")
                    For Each ll In colPoints
                        srKML.WriteLine(ll.Lon.ToString() & "," & ll.Lat.ToString() & ",0 ")
                    Next
                    srKML.WriteLine("</coordinates>")
                    srKML.WriteLine("</LinearRing>")
                    srKML.WriteLine("</outerBoundaryIs>")
                    srKML.WriteLine("</Polygon>")
                    srKML.WriteLine("</Placemark>")
                Next
            End If
        End If

        'Close file
        srKML.WriteLine("</Folder>")
        srKML.WriteLine("</kml>")
        srKML.Close()

        'Open the KML files with the default program (Google Earth)
        If frmOptions.chkGE.Checked Then
            'var psi = new ProcessStartInfo();
            'psi.FileName = txtEXEName.Text;
            'psi.Arguments = txtParams.Text;
            'psi.WindowStyle = ProcessWindowStyle.Normal;
            'Dim proc As System.Diagnostics.Process
            'proc = System.Diagnostics.Process.Start(strKMLFile)
            'proc.WaitForInputIdle(0)
            'proc.WaitForExit(0)
            System.Diagnostics.Process.Start(strKMLFile)
        Else
            MessageBox.Show("Created: " & strKMLFile & ". If you want GE files to open automatically, check the box on the options dialog.")
        End If
    End Sub
    Private Sub GetMapGoogle(ByVal dblLat As Double, ByVal dblLon As Double)

        Dim strGoogleLimitation As String = _
            "Gilbert uses Google Maps for free on a not-for-profit basis. " & _
            "There's a limit on the number of map requests that can " & _
            "be made from a single computer in a 24 hour " & _
            "period. You may have reached that limit. Switch to Bing Maps " & _
            "- you should be able to use Google Maps again soon."

        'Check for valid GR
        objGridRef.GridRef = txtGR.Text
        objGridRef.sErrorMessage = ""
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage <> "" Then
            MessageBox.Show(objGridRef.sErrorMessage)
            Exit Sub
        End If

        Dim sb As StringBuilder = New StringBuilder("http://maps.googleapis.com/maps/api/staticmap?sensor=false&")

        sb.Append("center=")
        sb.Append(dblLat.ToString)
        sb.Append(",")
        sb.Append(dblLon.ToString)
        sb.Append("&size=")
        sb.Append(pbMap.Width.ToString)
        sb.Append("x")
        sb.Append(pbMap.Height.ToString)
        sb.Append("&zoom=")
        sb.Append(tbZoom.Value)

        sb.Append("&maptype=")
        Select Case cbMapType.Text
            Case "Aerial"
                sb.Append("satellite")
            Case "Terrain or OS"
                sb.Append("terrain")
            Case "Aerial with labels"
                sb.Append("hybrid")
            Case Else
                sb.Append("roadmap")
        End Select

        Try
            pbMap.ImageLocation = sb.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading Google map image. " & ex.Message & ". " & strGoogleLimitation)
            Exit Sub
        End Try

        dblPixPerDegree = (2 ^ tbZoom.Value * 256) / 360
        dblMapCentreLat = dblLat
        dblMapCentreLon = dblLon

        'Reposition the map image
        pbMap.Left = 0
        pbMap.Top = 0
        pbMap.Width = panMap.Width
        pbMap.Height = panMap.Height

        'NBN
        'Need the follow global WGS84 variables describing map window for AddNBNMap
        dblWestLongitude = MapPixToLongGoogle(0)
        dblEastLongitude = MapPixToLongGoogle(pbMap.Width)
        dblSouthLatitude = MapPixToLatGoogle(pbMap.Height)
        dblNorthLatitude = MapPixToLatGoogle(0)
        AddNBNMap()
    End Sub

    Private Sub GetMapBing(ByVal dblLat As Double, ByVal dblLon As Double)

        'Check for valid GR
        objGridRef.GridRef = txtGR.Text
        objGridRef.sErrorMessage = ""
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage <> "" Then
            MessageBox.Show(objGridRef.sErrorMessage)
            Exit Sub
        End If

        Dim strKey As String = "AlPTtfgPkY9sMOCCkfVvR8JosVUQE2kDpdsAGYlG5fhuIyOpEiYnyMHKugfoRipe"
        Dim sbImage As StringBuilder = New StringBuilder("http://dev.virtualearth.net/REST/v1/Imagery/Map/")
        Dim sbMetadata As StringBuilder = New StringBuilder()

        Select Case cbMapType.Text
            Case "Aerial"
                sbImage.Append("Aerial")
            Case "Aerial with labels"
                sbImage.Append("AerialWithLabels")
            Case "Terrain or OS"
                sbImage.Append("OrdnanceSurvey")
            Case Else
                sbImage.Append("Road")
        End Select
        sbImage.Append("/")

        sbImage.Append(dblLat.ToString)
        sbImage.Append(",")
        sbImage.Append(dblLon.ToString)
        sbImage.Append("/")
        sbImage.Append(tbZoom.Value)
        sbImage.Append("?mapSize=")
        sbImage.Append(pbMap.Width.ToString)
        sbImage.Append(",")
        sbImage.Append(pbMap.Height.ToString)

        sbMetadata.Append(sbImage.ToString())
        sbMetadata.Append("&mapMetadata=1&o=xml")
        sbMetadata.Append("&key=")
        sbMetadata.Append(strKey)

        sbImage.Append("&key=")
        sbImage.Append(strKey)

        Dim strXML As String = ""
        Try
            Using wc As New System.Net.WebClient()
                strXML = wc.DownloadString(sbMetadata.ToString())
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading Bing metadata. " & ex.Message)
            Exit Sub
        End Try

        Try
            pbMap.Load(sbImage.ToString())
        Catch ex As Exception
            MessageBox.Show("Error loading Bing map image. " & ex.Message)
            Exit Sub
        End Try

        If strXML.Length > 0 Then
            dblWestLongitude = Convert.ToDouble(getTagValue("WestLongitude", strXML))
            dblEastLongitude = Convert.ToDouble(getTagValue("EastLongitude", strXML))
            dblSouthLatitude = Convert.ToDouble(getTagValue("SouthLatitude", strXML))
            dblNorthLatitude = Convert.ToDouble(getTagValue("NorthLatitude", strXML))
        End If

        dblMapCentreLat = dblLat
        dblMapCentreLon = dblLon

        'Dim dblZoom4Width As Double = 1384992.94054433 * 2
        'Dim mapWidth As Double = dblZoom4Width / 2 ^ (tbZoom.Value - 4)
        'Dim dblmin As Double = objGridRef.LongWGS842Easting(dblLat, dblWestLongitude, 0)
        'Dim dblmax As Double = objGridRef.LongWGS842Easting(dblLat, dblEastLongitude, 0)
        'MessageBox.Show(tbZoom.Value.ToString & ": " & (dblmax - dblmin).ToString & " - " & mapWidth.ToString)

        'Reposition the map image
        pbMap.Left = 0
        pbMap.Top = 0
        pbMap.Width = panMap.Width
        pbMap.Height = panMap.Height

        'NBN
        AddNBNMap()
    End Sub

    Public Sub AddNBNMap()

        Dim cur As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()
        Application.DoEvents()

        Dim strErr As String = ""

        If frmNBNTaxonSelection.txtVersionKey.Text <> "" Then

            Dim strLevels As String = ""
            Dim dblWidth As Double = dblEastLongitude - dblWestLongitude

            Console.WriteLine(dblWidth.ToString)

            If frmNBNTaxonSelection.cbo10km.Text = "On" Or (frmNBNTaxonSelection.cbo10km.Text = "Auto" And dblWidth > 0.6) Then
                strLevels = ",Grid-10km"
            End If
            If frmNBNTaxonSelection.cbo2km.Text = "On" Or (frmNBNTaxonSelection.cbo2km.Text = "Auto" And dblWidth < 1.4 And dblWidth > 0.04) Then
                strLevels = strLevels & ",Grid-2km"
            End If
            If frmNBNTaxonSelection.cbo1km.Text = "On" Or (frmNBNTaxonSelection.cbo1km.Text = "Auto" And dblWidth < 0.8 And dblWidth > 0.02) Then
                strLevels = strLevels & ",Grid-1km"
            End If
            If frmNBNTaxonSelection.cbo100m.Text = "On" Or (frmNBNTaxonSelection.cbo100m.Text = "Auto" And dblWidth < 0.16) Then
                strLevels = strLevels & ",Grid-100m"
            End If

            If strLevels <> "" Then

                strLevels = strLevels.Substring(1)

                Dim sb As StringBuilder = New StringBuilder("https://gis.nbn.org.uk/SingleSpecies/")

                sb.Append(frmNBNTaxonSelection.txtVersionKey.Text)
                sb.Append("?REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&BBOX=")
                'sb.Append(dblSouthLatitude.ToString)
                'sb.Append(",")
                'sb.Append(dblWestLongitude.ToString)
                'sb.Append(",")
                'sb.Append(dblNorthLatitude.ToString)
                'sb.Append(",")
                'sb.Append(dblEastLongitude.ToString)

                sb.Append(dblWestLongitude.ToString)
                sb.Append(",")
                sb.Append(dblSouthLatitude.ToString)
                sb.Append(",")
                sb.Append(dblEastLongitude.ToString)
                sb.Append(",")
                sb.Append(dblNorthLatitude.ToString)

                sb.Append("&WIDTH=")
                sb.Append(pbMap.Width.ToString)
                sb.Append("&HEIGHT=")
                sb.Append(pbMap.Height.ToString)
                sb.Append("&CRS=CRS:84&FORMAT=image/png")
                sb.Append("&LAYERS=")
                sb.Append(strLevels)
                '&LAYERS=3,2,1,0")
                'CRS:84
                'EPSG:4326

                sb.Append("&TRANSPARENT=true")
                sb.Append("&abundance=" & frmNBNTaxonSelection.cboRecords.Text.ToLower())
                sb.Append("&startyear=" & frmNBNTaxonSelection.nudStartYear.Value.ToString())
                sb.Append("&endyear=" & frmNBNTaxonSelection.nudEndYear.Value.ToString())

                If frmNBNTaxonSelection.rbSpecificUser.Checked Then
                    sb.Append("&username=" & frmNBNTaxonSelection.txtNBNUser.Text)
                    sb.Append("&userkey=" & frmNBNTaxonSelection.NBNPassword)
                End If

                Dim bmBasemap As New Bitmap(pbMap.Image)
                Dim bNBNOkay As Boolean = False
                Try
                    pbMap.Load(sb.ToString)
                    bNBNOkay = True
                Catch ex As Exception
                    strErr = ex.Message
                End Try

                If bNBNOkay Then
                    Dim bmNBN As New Bitmap(pbMap.Image)
                    bmNBN = FadeBitmap(bmNBN, frmNBNTaxonSelection.nudOpacity.Value)
                    Dim g As Graphics = Graphics.FromImage(bmBasemap)
                    g.DrawImage(bmNBN, 0, 0)

                    pbMap.Image = bmBasemap
                    g.Dispose()
                Else
                    If MessageBox.Show("Error getting distribution map from NBN WMS service: " & strErr & ". Do you want to try the generated URL in a browser to see what the problem was?", "No NBN distribution map", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Process.Start(sb.ToString())
                    End If
                End If
            End If
        End If

        Me.Cursor = cur
    End Sub

    Private Function FadeBitmap(ByVal bmp As Bitmap, ByVal OpacityPercent As Single) As Bitmap
        Dim bmp2 As New Bitmap(bmp.Width, bmp.Height, Imaging.PixelFormat.Format32bppArgb)
        OpacityPercent = Math.Min(OpacityPercent, 100)

        Using ia As New Imaging.ImageAttributes
            Dim cm As New Imaging.ColorMatrix
            cm.Matrix33 = OpacityPercent / 100.0F
            ia.SetColorMatrix(cm)
            Dim destpoints() As PointF = _
                   {New Point(0, 0), New Point(bmp.Width, 0), New Point(0, bmp.Height)}
            Using g As Graphics = Graphics.FromImage(bmp2)
                g.Clear(Color.Transparent)
                g.DrawImage(bmp, destpoints, _
                   New RectangleF(Point.Empty, bmp.Size), GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp2
    End Function

    Private Sub DrawGR(ByVal strGR As String, ByVal colBorder As Color)

        objGridRef.GridRef = strGR
        objGridRef.sErrorMessage = ""
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        If objGridRef.sErrorMessage <> "" Then
            Exit Sub
        End If

        Dim dblMinEast As Double = objGridRef.East - objGridRef.fWidth
        Dim dblMaxEast As Double = objGridRef.East + objGridRef.fWidth
        Dim dblMinNorth As Double = objGridRef.North - objGridRef.fWidth
        Dim dblMaxNorth As Double = objGridRef.North + objGridRef.fWidth

        Dim dblLLLon As Double = objGridRef.Easting2LongWGS84(dblMinEast, dblMinNorth, 0)
        Dim dblLLLat As Double = objGridRef.Northing2LatWGS84(dblMinEast, dblMinNorth, 0)
        Dim dblULLon As Double = objGridRef.Easting2LongWGS84(dblMinEast, dblMaxNorth, 0)
        Dim dblULLat As Double = objGridRef.Northing2LatWGS84(dblMinEast, dblMaxNorth, 0)
        Dim dblURLon As Double = objGridRef.Easting2LongWGS84(dblMaxEast, dblMaxNorth, 0)
        Dim dblURLat As Double = objGridRef.Northing2LatWGS84(dblMaxEast, dblMaxNorth, 0)
        Dim dblLRLon As Double = objGridRef.Easting2LongWGS84(dblMaxEast, dblMinNorth, 0)
        Dim dblLRLat As Double = objGridRef.Northing2LatWGS84(dblMaxEast, dblMinNorth, 0)

        Dim intLLX As Integer
        Dim intULX As Integer
        Dim intURX As Integer
        Dim intLRX As Integer
        Dim intLLY As Integer
        Dim intULY As Integer
        Dim intURY As Integer
        Dim intLRY As Integer

        If rbMapsBing.Checked Then
            intLLX = LongToMapPixBing(dblLLLon)
            intULX = LongToMapPixBing(dblULLon)
            intURX = LongToMapPixBing(dblURLon)
            intLRX = LongToMapPixBing(dblLRLon)
            intLLY = LatToMapPixBing(dblLLLat)
            intULY = LatToMapPixBing(dblULLat)
            intURY = LatToMapPixBing(dblURLat)
            intLRY = LatToMapPixBing(dblLRLat)
        Else
            intLLX = LongToMapPixGoogle(dblLLLon)
            intULX = LongToMapPixGoogle(dblULLon)
            intURX = LongToMapPixGoogle(dblURLon)
            intLRX = LongToMapPixGoogle(dblLRLon)
            intLLY = LatToMapPixGoogle(dblLLLat)
            intULY = LatToMapPixGoogle(dblULLat)
            intURY = LatToMapPixGoogle(dblURLat)
            intLRY = LatToMapPixGoogle(dblLRLat)
        End If

        'Creates the graphics object for the PictureBox
        Dim p As New System.Drawing.Pen(Color.Red, 1)
        Dim g As Graphics = pbMap.CreateGraphics()
        Dim point1 As New Point(intLLX, intLLY)
        Dim point2 As New Point(intULX, intULY)
        Dim point3 As New Point(intURX, intURY)
        Dim point4 As New Point(intLRX, intLRY)
        Dim grPoints As Point() = {point1, point2, point3, point4}

        Dim c As Color
        Select Case objGridRef.sRefType
            Case "100km"
                c = frmOptions.butStyle100km.BackColor
            Case "hectad"
                c = frmOptions.butStyle10km.BackColor
            Case "tetrad"
                c = frmOptions.butStyle2km.BackColor
            Case "monad"
                c = frmOptions.butStyle1km.BackColor
            Case "6fig"
                c = frmOptions.butStyle100m.BackColor
            Case "8fig"
                c = frmOptions.butStyle10m.BackColor
            Case "10fig"
                c = frmOptions.butStyle1m.BackColor
            Case Else
                c = frmOptions.butStyleInvalid.BackColor
        End Select
        c = Color.FromArgb(150, c)
        g.FillPolygon(New SolidBrush(c), grPoints)
        g.DrawPolygon(New Pen(colBorder, 1), grPoints)
    End Sub

    Private Sub CalculateTrack()

        If cbShowTrack.Checked And dtTrack Is Nothing Then

            'Get the associated track file, if any
            Dim db As clsDB = New clsDB
            Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)

            comTracks.CommandText = "select FileID from RecordTracks where RecordID = " & rowActive.Cells("ID").Value
            Dim intTrackID As Integer = comTracks.ExecuteScalar()

            Dim inFile As clsInputFile
            comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = " & intTrackID
            Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
            Dim dtTrackFile As DataTable = New DataTable
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count > 0 Then

                If Not cfun.HasNoValue(dtTrackFile.Rows(0)("CurrentPath")) Then

                    Dim strTrackFile As String = dtTrackFile.Rows(0)("CurrentPath")
                    Dim strFiletype As String = dtTrackFile.Rows(0)("FileType")

                    inFile = Nothing
                    Select Case strFiletype.ToLower()

                        Case "visiontac"
                            inFile = New clsInputFileVisiontac(strTrackFile)
                    End Select

                    dtTrack = inFile.AllTrackPoints()
                End If
            End If
        End If

        If Not dtTrack Is Nothing Then

            'Render the track 
            Dim i As Integer = 0
            ReDim pntsTrack(dtTrack.Rows.Count - 1)
            Dim lon As Double
            Dim lat As Double
            For Each row In dtTrack.Rows
                lon = Convert.ToDouble(row("Lon"))
                lat = Convert.ToDouble(row("Lat"))
                pntsTrack(i) = New Point(LongToMapPix(lon), LatToMapPix(lat))
                i += 1
            Next
        End If
    End Sub

    Private Sub DrawTrack()

        Dim g As Graphics = pbMap.CreateGraphics()
        g.DrawLines(New Pen(Color.Magenta, 2), pntsTrack)
    End Sub

    Private Sub DrawRecs()

        Dim row As DataGridViewRow
        For Each row In frmMain.dgvRecords.Rows

            If Not row Is rowActive Then
                DrawGR(row.Cells("GridRef").Value, Color.Black)
            End If
        Next
    End Sub

    Private Sub DrawGROffset()

        If mgrOffset Is Nothing Then
            Exit Sub
        End If

        Dim ll As clsOffsetGR.clsLatLon
        Dim g As Graphics = pbMap.CreateGraphics()
        Dim i As Integer
        Dim c As Color

        'The line of best fit
        g.DrawLine(New Pen(Color.Red, 2), LongToMapPix(mgrOffset.BestFitStart.Lon), LatToMapPix(mgrOffset.BestFitStart.Lat), LongToMapPix(mgrOffset.BestFitEnd.Lon), LatToMapPix(mgrOffset.BestFitEnd.Lat))

        'The track
        Dim pntsTrack(mgrOffset.Track.Count - 1) As Point
        i = 0
        For Each ll In mgrOffset.Track
            pntsTrack(i) = New Point(LongToMapPix(ll.Lon), LatToMapPix(ll.Lat))
            i += 1
        Next
        g.DrawLines(New Pen(Color.White, 2), pntsTrack)

        'The projected segments
        Dim pntsSegment(mgrOffset.Segment1.Count - 1) As Point
        i = 0
        For Each ll In mgrOffset.Segment1
            pntsSegment(i) = New Point(LongToMapPix(ll.Lon), LatToMapPix(ll.Lat))
            i += 1
        Next
        c = Color.FromArgb(120, Color.White)
        g.FillPolygon(New SolidBrush(c), pntsSegment)
        g.DrawPolygon(New Pen(Color.Black, 1), pntsSegment)

        ReDim pntsSegment(mgrOffset.Segment2.Count - 1)
        i = 0
        For Each ll In mgrOffset.Segment2
            pntsSegment(i) = New Point(LongToMapPix(ll.Lon), LatToMapPix(ll.Lat))
            i += 1
        Next
        c = Color.FromArgb(150, Color.White)
        g.FillPolygon(New SolidBrush(c), pntsSegment)
        g.DrawPolygon(New Pen(Color.Black, 1), pntsSegment)

        ReDim pntsSegment(mgrOffset.Segment3.Count - 1)
        i = 0
        For Each ll In mgrOffset.Segment3
            pntsSegment(i) = New Point(LongToMapPix(ll.Lon), LatToMapPix(ll.Lat))
            i += 1
        Next
        c = Color.FromArgb(120, Color.White)
        g.FillPolygon(New SolidBrush(c), pntsSegment)
        g.DrawPolygon(New Pen(Color.Black, 1), pntsSegment)
    End Sub

    Function ATanH(ByVal value As Double) As Double
        ATanH = Log((1 / value + 1) / (1 / value - 1)) / 2
    End Function

    Private Function LongToMapPix(ByVal dblLong As Double) As Integer
        If rbMapsBing.Checked Then
            Return LongToMapPixBing(dblLong)
        Else
            Return LongToMapPixGoogle(dblLong)
        End If
    End Function
    Private Function LatToMapPix(ByVal dblLat As Double) As Integer
        If rbMapsBing.Checked Then
            Return LatToMapPixBing(dblLat)
        Else
            Return LatToMapPixGoogle(dblLat)
        End If
    End Function
    Private Function LongToMapPixBing(ByVal dblLong As Double) As Integer
        Return ((dblLong - dblWestLongitude) / (dblEastLongitude - dblWestLongitude)) * pbMap.Width
    End Function

    Private Function LatToMapPixBing(ByVal dblLat As Double) As Integer
        Return ((dblNorthLatitude - dblLat) / (dblNorthLatitude - dblSouthLatitude)) * pbMap.Height
    End Function

    Private Function MapPixToLongBing(ByVal intX As Integer) As Double
        Return dblWestLongitude + ((dblEastLongitude - dblWestLongitude) * intX / pbMap.Width)
    End Function

    Private Function MapPixToLatBing(ByVal intY As Integer) As Double
        Return dblNorthLatitude - (dblNorthLatitude - dblSouthLatitude) * intY / pbMap.Height
    End Function

    Private Function LongToMapPixGoogle(ByVal dblLong As Double) As Integer
        Return pbMap.Width / 2 - (dblMapCentreLon - dblLong) * dblPixPerDegree
    End Function

    Private Function LatToMapPixGoogle(ByVal dblLat As Double) As Integer
        Dim dblPixPerRadian = dblPixPerDegree * 180 / PI
        Dim atanhCentre As Double = ATanH(Sin(dblMapCentreLat * PI / 180))
        Dim centreY As Double = dblPixPerRadian * atanhCentre
        Dim pixelLatitudeRadians As Double
        Dim localAtanh As Double
        Dim realPixelLatitude As Double
        Dim pixelLatitude As Double

        pixelLatitudeRadians = dblLat * PI / 180
        localAtanh = ATanH(Sin(pixelLatitudeRadians))
        realPixelLatitude = dblPixPerRadian * localAtanh
        pixelLatitude = centreY - realPixelLatitude 'convert from our virtual map to the displayed portion

        Return pixelLatitude + (pbMap.Height / 2)
    End Function

    Private Function MapPixToLongGoogle(ByVal intX As Integer) As Double
        Return dblMapCentreLon - (pbMap.Width / 2 - intX) / dblPixPerDegree
    End Function

    Private Function MapPixToLatGoogle(ByVal intY As Integer) As Double
        Dim dblPixPerRadian = dblPixPerDegree * 180 / PI
        Dim atanhCentre As Double = ATanH(Sin(dblMapCentreLat * PI / 180))
        Dim centreY As Double = dblPixPerRadian * atanhCentre
        Dim pixelLatitudeRadians As Double
        Dim localAtanh As Double
        Dim realPixelLatitude As Double
        Dim pixelLatitude As Double

        pixelLatitude = intY - (pbMap.Height / 2)
        realPixelLatitude = centreY - pixelLatitude
        localAtanh = realPixelLatitude / dblPixPerRadian
        pixelLatitudeRadians = Asin(Tanh(localAtanh))
        Return pixelLatitudeRadians * 180 / PI
    End Function

    Private Function getTagValue(ByVal strTag As String, ByVal strXML As String) As String

        Dim strTagValue As String = ""

        Dim intStart As Integer = strXML.IndexOf("<" & strTag & ">")
        Dim intEnd As Integer = strXML.IndexOf("</" & strTag & ">")

        strTagValue = strXML.Substring(intStart + 2 + strTag.Length, intEnd - intStart - strTag.Length - 2)

        Return strTagValue
    End Function

    Private Sub cbMapType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMapType.SelectedIndexChanged
        RedisplayMap()
    End Sub

    Private Sub tbZoom_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbZoom.MouseUp
        If Not tbZoom.Value = intZoomLevel Then
            intZoomLevel = tbZoom.Value
            RedisplayMap()
        End If
    End Sub

    Private Sub RedisplayMap()
        If Not pbMap.Image Is Nothing Then

            If rbMapsBing.Checked Then
                GetMapBing(dblMapCentreLat, dblMapCentreLon)
            ElseIf rbMapsGoogle.Checked Then
                GetMapGoogle(dblMapCentreLat, dblMapCentreLon)
            Else
                pbMap.Image = Nothing
            End If

            CalculateTrack()
        End If
    End Sub

    Private Function getGRAtPointGoogle(ByVal intX As Integer, ByVal intY As Integer) As Point

        Dim dblLong As Double = MapPixToLongGoogle(intX)
        Dim dblLat As Double = MapPixToLatGoogle(intY)
        Dim dblNorthing As Double = objGridRef.LatWGS842Northing(dblLat, dblLong, 0)
        Dim dblEasting As Double = objGridRef.LongWGS842Easting(dblLat, dblLong, 0)

        Return New Point(Convert.ToInt32(dblEasting), Convert.ToInt32(dblNorthing))
    End Function

    Private Function getGRAtPointBing(ByVal intX As Integer, ByVal intY As Integer) As Point

        Dim dblLat As Double = MapPixToLatBing(intY)
        Dim dblLong As Double = MapPixToLongBing(intX)
        Dim dblNorthing As Double = objGridRef.LatWGS842Northing(dblLat, dblLong, 0)
        Dim dblEasting As Double = objGridRef.LongWGS842Easting(dblLat, dblLong, 0)

        Return New Point(Convert.ToInt32(dblEasting), Convert.ToInt32(dblNorthing))
    End Function

    Private Sub pbMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbMap.MouseDown

        If e.Button = MouseButtons.Left And Not pbMap.Image Is Nothing Then
            pntMouseDown = e.Location
        End If
    End Sub

    Private Sub pbMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbMap.MouseMove

        If e.Button = MouseButtons.Left And Not pbMap.Image Is Nothing Then

            Dim mousePosNow As Point = e.Location

            Dim deltaX As Integer = mousePosNow.X - pntMouseDown.X
            Dim deltaY As Integer = mousePosNow.Y - pntMouseDown.Y

            Dim newX As Integer = pbMap.Location.X + deltaX
            Dim newY As Integer = pbMap.Location.Y + deltaY

            pbMap.Location = New Point(newX, newY)
        End If
    End Sub

    Private Sub pbMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbMap.MouseUp

        If pbMap.Left = 0 And pbMap.Top = 0 And Not pbMap.Image Is Nothing Then

            'Get the grid reference

            Dim pntGR As Point
            Dim strGR As String

            If rbMapsBing.Checked Then
                pntGR = getGRAtPointBing(e.X, e.Y)
            Else
                pntGR = getGRAtPointGoogle(e.X, e.Y)
            End If

            Select Case cbPrecision.Text.ToLower
                Case "10 km"
                    strGR = objGridRef.EN2Hectad(pntGR.X, pntGR.Y)
                Case "2 km"
                    strGR = objGridRef.EN2Tetrad(pntGR.X, pntGR.Y)
                Case "1 km"
                    strGR = objGridRef.EN2Monad(pntGR.X, pntGR.Y)
                Case "6 fig"
                    strGR = objGridRef.EN26fig(pntGR.X, pntGR.Y)
                Case "8 fig"
                    strGR = objGridRef.EN28fig(pntGR.X, pntGR.Y)
                Case "10 fig"
                    strGR = objGridRef.EN210fig(pntGR.X, pntGR.Y)
                Case Else
                    strGR = objGridRef.EN26fig(pntGR.X, pntGR.Y)
            End Select

            txtGRMove.Text = strGR
            pbMap.Invalidate()

        ElseIf Not pbMap.Image Is Nothing Then

            'Pan the map
            Dim dblLat As Double
            Dim dblLon As Double

            If rbMapsBing.Checked Then

                dblLat = MapPixToLatBing(pbMap.Height / 2 - pbMap.Top)
                dblLon = MapPixToLongBing(pbMap.Width / 2 - pbMap.Left)
                GetMapBing(dblLat, dblLon)
            Else
                dblLat = MapPixToLatGoogle(pbMap.Height / 2 - pbMap.Top)
                dblLon = MapPixToLongGoogle(pbMap.Width / 2 - pbMap.Left)
                GetMapGoogle(dblLat, dblLon)
            End If

            CalculateTrack()
            pbMap.Invalidate()
        End If
    End Sub

    Private Sub pbMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbMap.Paint

        If Not pbMap.Image Is Nothing Then
            timMapGraphics.Enabled = True
        End If
    End Sub

    Private Sub timMapGraphics_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timMapGraphics.Tick

        If txtGR.Text.Length > 0 Then
            DrawGR(txtGR.Text, Color.Red)
        End If
        If txtGRMove.Text.Length > 0 Then
            DrawGR(txtGRMove.Text, Color.Yellow)
        End If
        If chkProjectLocation.Checked Then
            DrawGROffset()
        End If
        If cbShowTrack.Checked And pntsTrack.Length > 1 Then
            DrawTrack()
        End If
        If cbOtherRecs.Checked Then
            DrawRecs()
        End If
        timMapGraphics.Enabled = False
    End Sub

    Private Sub rbMapsBing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMapsBing.CheckedChanged
        RedisplayMap()
    End Sub

    Private Sub rbMapsGoogle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMapsGoogle.CheckedChanged
        RedisplayMap()
    End Sub

    Private Sub butUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUse.Click
        If txtGRMove.Text.Length > 0 Then
            txtGR.Text = txtGRMove.Text
            txtGRMove.Text = ""
            pbMap.Invalidate()
        End If
    End Sub

    Private Sub rbMapsGE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMapsGE.CheckedChanged
        RedisplayMap()
    End Sub

    Private Sub butSearchGaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearchGaz.Click

        frmSearchGazetteer.ShowDialog()
        If frmSearchGazetteer.GR <> "" Then
            txtGR.Text = frmSearchGazetteer.GR
            butGetLocation_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tmrActivateWindow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrActivateWindow.Tick

        If Not GetForegroundWindow() = Me.Handle Then
            'SetForegroundWindow(Me.Handle)

            If FindWindow(vbNullString, "ffplay") > 0 Then
                SetWindowPos(FindWindow(vbNullString, "ffplay"), 0, Me.Left, Me.Top, 0, 0, SWP_NOSIZE)
                'A shorter period of sleep below seems to result in sound not being audible
                '(no sleep at all normally results in ffplay window appearing on top of vb form)
                Thread.Sleep(frmOptions.nudFfplayDelay.Value)
                'SetForegroundWindow(FindWindow(vbNullString, "ffplay"))
                Me.Activate()
                tmrActivateWindow.Enabled = False
            End If
        End If
    End Sub

    Private Sub butNBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNBN.Click

        If frmNBNTaxonSelection.txtVersionKey.Text = "" Then
            frmNBNTaxonSelection.SetName(cboScientificName.Text)
        End If
        frmNBNTaxonSelection.ShowDialog()

        RedisplayMap()

        'butMap_Click(Nothing, Nothing)
    End Sub

    Private Sub cbShowTrack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowTrack.CheckedChanged
        CalculateTrack()
        pbMap.Invalidate()
    End Sub

    Private Sub cbOtherRecs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOtherRecs.CheckedChanged
        pbMap.Invalidate()
    End Sub
End Class
