<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecordDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecordDetails))
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tabWho = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConfirmer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeterminer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecorder = New System.Windows.Forms.TextBox()
        Me.tabWhat = New System.Windows.Forms.TabPage()
        Me.cboTaxonGroup = New System.Windows.Forms.ComboBox()
        Me.gbDebug = New System.Windows.Forms.GroupBox()
        Me.lblSciValue = New System.Windows.Forms.Label()
        Me.lblSciSelIndex = New System.Windows.Forms.Label()
        Me.lblComValue = New System.Windows.Forms.Label()
        Me.lblComSelIndex = New System.Windows.Forms.Label()
        Me.butSearchScientificName = New System.Windows.Forms.Button()
        Me.butSearchCommonName = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.imlTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.cboScientificName = New System.Windows.Forms.ComboBox()
        Me.cboCommonName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAbundanceUnits = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAbundance = New System.Windows.Forms.TextBox()
        Me.txtAuthority = New System.Windows.Forms.TextBox()
        Me.txtVersionKey = New System.Windows.Forms.TextBox()
        Me.chkWellFormed = New System.Windows.Forms.CheckBox()
        Me.chkScientific = New System.Windows.Forms.CheckBox()
        Me.chkPreferred = New System.Windows.Forms.CheckBox()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblVersionKey = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabWhere = New System.Windows.Forms.TabPage()
        Me.cbOtherRecs = New System.Windows.Forms.CheckBox()
        Me.cbShowTrack = New System.Windows.Forms.CheckBox()
        Me.butNBN = New System.Windows.Forms.Button()
        Me.butSearchGaz = New System.Windows.Forms.Button()
        Me.panMap = New System.Windows.Forms.Panel()
        Me.txtGRMove = New System.Windows.Forms.TextBox()
        Me.butUse = New System.Windows.Forms.Button()
        Me.cbPrecision = New System.Windows.Forms.ComboBox()
        Me.tbZoom = New System.Windows.Forms.TrackBar()
        Me.cbMapType = New System.Windows.Forms.ComboBox()
        Me.pbMap = New System.Windows.Forms.PictureBox()
        Me.butMap = New System.Windows.Forms.Button()
        Me.but10fig = New System.Windows.Forms.Button()
        Me.but8fig = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbMapsGE = New System.Windows.Forms.RadioButton()
        Me.rbMapsBing = New System.Windows.Forms.RadioButton()
        Me.rbMapsGoogle = New System.Windows.Forms.RadioButton()
        Me.butTetrad = New System.Windows.Forms.Button()
        Me.butHectad = New System.Windows.Forms.Button()
        Me.butMonad = New System.Windows.Forms.Button()
        Me.butGetLocation = New System.Windows.Forms.Button()
        Me.chkNewLocation = New System.Windows.Forms.CheckBox()
        Me.but6fig = New System.Windows.Forms.Button()
        Me.grpLineOfBestFit = New System.Windows.Forms.GroupBox()
        Me.radSpecifyBestFit = New System.Windows.Forms.RadioButton()
        Me.radAutoBestFit = New System.Windows.Forms.RadioButton()
        Me.nudGEPoints = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkProjectLocation = New System.Windows.Forms.CheckBox()
        Me.nudOffset = New System.Windows.Forms.NumericUpDown()
        Me.nudOclock = New System.Windows.Forms.NumericUpDown()
        Me.lvTowns = New System.Windows.Forms.ListView()
        Me.colTown = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTownDistance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lvLocations = New System.Windows.Forms.ListView()
        Me.colLocation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDistance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtGR = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tabWhen = New System.Windows.Forms.TabPage()
        Me.chkNoTime = New System.Windows.Forms.CheckBox()
        Me.chkNoDate = New System.Windows.Forms.CheckBox()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.tabComment = New System.Windows.Forms.TabPage()
        Me.lblHeadlineComment = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPersonalNotes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.tabMedia = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvMedia = New System.Windows.Forms.ListView()
        Me.imlMedia = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.picMedia = New System.Windows.Forms.PictureBox()
        Me.lblMediaComment = New System.Windows.Forms.Label()
        Me.butMediaProps = New System.Windows.Forms.Button()
        Me.butMediaDown = New System.Windows.Forms.Button()
        Me.butMediaUp = New System.Windows.Forms.Button()
        Me.butDeleteMedia = New System.Windows.Forms.Button()
        Me.butAddMedia = New System.Windows.Forms.Button()
        Me.butOffsetGR = New System.Windows.Forms.Button()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
        Me.chkExcludeFromExport = New System.Windows.Forms.CheckBox()
        Me.butVoice = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.grpOkay = New System.Windows.Forms.GroupBox()
        Me.butOkay = New System.Windows.Forms.Button()
        Me.butOkayMonad = New System.Windows.Forms.Button()
        Me.butOkay6fig = New System.Windows.Forms.Button()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.timDebug = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.timMapGraphics = New System.Windows.Forms.Timer(Me.components)
        Me.tmrActivateWindow = New System.Windows.Forms.Timer(Me.components)
        Me.tcMain.SuspendLayout()
        Me.tabWho.SuspendLayout()
        Me.tabWhat.SuspendLayout()
        Me.gbDebug.SuspendLayout()
        Me.tabWhere.SuspendLayout()
        Me.panMap.SuspendLayout()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grpLineOfBestFit.SuspendLayout()
        CType(Me.nudGEPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudOclock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWhen.SuspendLayout()
        Me.tabComment.SuspendLayout()
        Me.tabMedia.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.picMedia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOkay.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Controls.Add(Me.tabWho)
        Me.tcMain.Controls.Add(Me.tabWhat)
        Me.tcMain.Controls.Add(Me.tabWhere)
        Me.tcMain.Controls.Add(Me.tabWhen)
        Me.tcMain.Controls.Add(Me.tabComment)
        Me.tcMain.Controls.Add(Me.tabMedia)
        Me.tcMain.Location = New System.Drawing.Point(4, 30)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(704, 410)
        Me.tcMain.TabIndex = 0
        '
        'tabWho
        '
        Me.tabWho.Controls.Add(Me.Label3)
        Me.tabWho.Controls.Add(Me.txtConfirmer)
        Me.tabWho.Controls.Add(Me.Label4)
        Me.tabWho.Controls.Add(Me.txtDeterminer)
        Me.tabWho.Controls.Add(Me.Label5)
        Me.tabWho.Controls.Add(Me.txtRecorder)
        Me.tabWho.Location = New System.Drawing.Point(4, 22)
        Me.tabWho.Name = "tabWho"
        Me.tabWho.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWho.Size = New System.Drawing.Size(696, 384)
        Me.tabWho.TabIndex = 0
        Me.tabWho.Text = "Who?"
        Me.tabWho.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Confirmer:"
        '
        'txtConfirmer
        '
        Me.txtConfirmer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConfirmer.Location = New System.Drawing.Point(79, 63)
        Me.txtConfirmer.Name = "txtConfirmer"
        Me.txtConfirmer.Size = New System.Drawing.Size(611, 20)
        Me.txtConfirmer.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Determiner:"
        '
        'txtDeterminer
        '
        Me.txtDeterminer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeterminer.Location = New System.Drawing.Point(79, 34)
        Me.txtDeterminer.Name = "txtDeterminer"
        Me.txtDeterminer.Size = New System.Drawing.Size(611, 20)
        Me.txtDeterminer.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Recorder:"
        '
        'txtRecorder
        '
        Me.txtRecorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecorder.Location = New System.Drawing.Point(79, 8)
        Me.txtRecorder.Name = "txtRecorder"
        Me.txtRecorder.Size = New System.Drawing.Size(611, 20)
        Me.txtRecorder.TabIndex = 21
        '
        'tabWhat
        '
        Me.tabWhat.Controls.Add(Me.cboTaxonGroup)
        Me.tabWhat.Controls.Add(Me.gbDebug)
        Me.tabWhat.Controls.Add(Me.butSearchScientificName)
        Me.tabWhat.Controls.Add(Me.butSearchCommonName)
        Me.tabWhat.Controls.Add(Me.TreeView1)
        Me.tabWhat.Controls.Add(Me.cboScientificName)
        Me.tabWhat.Controls.Add(Me.cboCommonName)
        Me.tabWhat.Controls.Add(Me.Label6)
        Me.tabWhat.Controls.Add(Me.txtAbundanceUnits)
        Me.tabWhat.Controls.Add(Me.Label7)
        Me.tabWhat.Controls.Add(Me.txtAbundance)
        Me.tabWhat.Controls.Add(Me.txtAuthority)
        Me.tabWhat.Controls.Add(Me.txtVersionKey)
        Me.tabWhat.Controls.Add(Me.chkWellFormed)
        Me.tabWhat.Controls.Add(Me.chkScientific)
        Me.tabWhat.Controls.Add(Me.chkPreferred)
        Me.tabWhat.Controls.Add(Me.lblAuthority)
        Me.tabWhat.Controls.Add(Me.lblGroup)
        Me.tabWhat.Controls.Add(Me.lblVersionKey)
        Me.tabWhat.Controls.Add(Me.Label2)
        Me.tabWhat.Controls.Add(Me.Label1)
        Me.tabWhat.Location = New System.Drawing.Point(4, 22)
        Me.tabWhat.Name = "tabWhat"
        Me.tabWhat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWhat.Size = New System.Drawing.Size(696, 384)
        Me.tabWhat.TabIndex = 1
        Me.tabWhat.Text = "What?"
        Me.tabWhat.UseVisualStyleBackColor = True
        '
        'cboTaxonGroup
        '
        Me.cboTaxonGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTaxonGroup.FormattingEnabled = True
        Me.cboTaxonGroup.Location = New System.Drawing.Point(105, 102)
        Me.cboTaxonGroup.Name = "cboTaxonGroup"
        Me.cboTaxonGroup.Size = New System.Drawing.Size(223, 21)
        Me.cboTaxonGroup.TabIndex = 73
        '
        'gbDebug
        '
        Me.gbDebug.Controls.Add(Me.lblSciValue)
        Me.gbDebug.Controls.Add(Me.lblSciSelIndex)
        Me.gbDebug.Controls.Add(Me.lblComValue)
        Me.gbDebug.Controls.Add(Me.lblComSelIndex)
        Me.gbDebug.Location = New System.Drawing.Point(9, 255)
        Me.gbDebug.Name = "gbDebug"
        Me.gbDebug.Size = New System.Drawing.Size(319, 96)
        Me.gbDebug.TabIndex = 72
        Me.gbDebug.TabStop = False
        Me.gbDebug.Text = "Debug"
        Me.gbDebug.Visible = False
        '
        'lblSciValue
        '
        Me.lblSciValue.AutoSize = True
        Me.lblSciValue.Location = New System.Drawing.Point(6, 59)
        Me.lblSciValue.Name = "lblSciValue"
        Me.lblSciValue.Size = New System.Drawing.Size(59, 13)
        Me.lblSciValue.TabIndex = 70
        Me.lblSciValue.Text = "lblSciValue"
        '
        'lblSciSelIndex
        '
        Me.lblSciSelIndex.AutoSize = True
        Me.lblSciSelIndex.Location = New System.Drawing.Point(6, 76)
        Me.lblSciSelIndex.Name = "lblSciSelIndex"
        Me.lblSciSelIndex.Size = New System.Drawing.Size(73, 13)
        Me.lblSciSelIndex.TabIndex = 71
        Me.lblSciSelIndex.Text = "lblSciSelIndex"
        '
        'lblComValue
        '
        Me.lblComValue.AutoSize = True
        Me.lblComValue.Location = New System.Drawing.Point(6, 19)
        Me.lblComValue.Name = "lblComValue"
        Me.lblComValue.Size = New System.Drawing.Size(65, 13)
        Me.lblComValue.TabIndex = 68
        Me.lblComValue.Text = "lblComValue"
        '
        'lblComSelIndex
        '
        Me.lblComSelIndex.AutoSize = True
        Me.lblComSelIndex.Location = New System.Drawing.Point(6, 36)
        Me.lblComSelIndex.Name = "lblComSelIndex"
        Me.lblComSelIndex.Size = New System.Drawing.Size(79, 13)
        Me.lblComSelIndex.TabIndex = 69
        Me.lblComSelIndex.Text = "lblComSelIndex"
        '
        'butSearchScientificName
        '
        Me.butSearchScientificName.Image = CType(resources.GetObject("butSearchScientificName.Image"), System.Drawing.Image)
        Me.butSearchScientificName.Location = New System.Drawing.Point(304, 34)
        Me.butSearchScientificName.Name = "butSearchScientificName"
        Me.butSearchScientificName.Size = New System.Drawing.Size(24, 21)
        Me.butSearchScientificName.TabIndex = 67
        Me.tt.SetToolTip(Me.butSearchScientificName, "Search the NBN taxon dictionary.")
        Me.butSearchScientificName.UseVisualStyleBackColor = True
        '
        'butSearchCommonName
        '
        Me.butSearchCommonName.Image = CType(resources.GetObject("butSearchCommonName.Image"), System.Drawing.Image)
        Me.butSearchCommonName.Location = New System.Drawing.Point(304, 8)
        Me.butSearchCommonName.Name = "butSearchCommonName"
        Me.butSearchCommonName.Size = New System.Drawing.Size(24, 21)
        Me.butSearchCommonName.TabIndex = 66
        Me.tt.SetToolTip(Me.butSearchCommonName, "Search the NBN taxon dictionary.")
        Me.butSearchCommonName.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imlTreeView
        Me.TreeView1.Indent = 10
        Me.TreeView1.Location = New System.Drawing.Point(334, 6)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(356, 360)
        Me.TreeView1.TabIndex = 54
        Me.tt.SetToolTip(Me.TreeView1, resources.GetString("TreeView1.ToolTip"))
        '
        'imlTreeView
        '
        Me.imlTreeView.ImageStream = CType(resources.GetObject("imlTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTreeView.Images.SetKeyName(0, "")
        Me.imlTreeView.Images.SetKeyName(1, "")
        Me.imlTreeView.Images.SetKeyName(2, "")
        Me.imlTreeView.Images.SetKeyName(3, "")
        Me.imlTreeView.Images.SetKeyName(4, "")
        Me.imlTreeView.Images.SetKeyName(5, "taxonomy20x16.png")
        '
        'cboScientificName
        '
        Me.cboScientificName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboScientificName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboScientificName.FormattingEnabled = True
        Me.cboScientificName.Location = New System.Drawing.Point(105, 35)
        Me.cboScientificName.Name = "cboScientificName"
        Me.cboScientificName.Size = New System.Drawing.Size(193, 21)
        Me.cboScientificName.TabIndex = 45
        Me.tt.SetToolTip(Me.cboScientificName, resources.GetString("cboScientificName.ToolTip"))
        '
        'cboCommonName
        '
        Me.cboCommonName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommonName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCommonName.FormattingEnabled = True
        Me.cboCommonName.Location = New System.Drawing.Point(105, 8)
        Me.cboCommonName.Name = "cboCommonName"
        Me.cboCommonName.Size = New System.Drawing.Size(193, 21)
        Me.cboCommonName.TabIndex = 44
        Me.tt.SetToolTip(Me.cboCommonName, resources.GetString("cboCommonName.ToolTip"))
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Abundance units:"
        '
        'txtAbundanceUnits
        '
        Me.txtAbundanceUnits.Location = New System.Drawing.Point(105, 201)
        Me.txtAbundanceUnits.Name = "txtAbundanceUnits"
        Me.txtAbundanceUnits.Size = New System.Drawing.Size(223, 20)
        Me.txtAbundanceUnits.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Abundance:"
        '
        'txtAbundance
        '
        Me.txtAbundance.Location = New System.Drawing.Point(105, 175)
        Me.txtAbundance.Name = "txtAbundance"
        Me.txtAbundance.Size = New System.Drawing.Size(223, 20)
        Me.txtAbundance.TabIndex = 46
        '
        'txtAuthority
        '
        Me.txtAuthority.Enabled = False
        Me.txtAuthority.Location = New System.Drawing.Point(105, 77)
        Me.txtAuthority.Name = "txtAuthority"
        Me.txtAuthority.Size = New System.Drawing.Size(223, 20)
        Me.txtAuthority.TabIndex = 63
        Me.tt.SetToolTip(Me.txtAuthority, resources.GetString("txtAuthority.ToolTip"))
        '
        'txtVersionKey
        '
        Me.txtVersionKey.Enabled = False
        Me.txtVersionKey.Location = New System.Drawing.Point(105, 129)
        Me.txtVersionKey.Name = "txtVersionKey"
        Me.txtVersionKey.Size = New System.Drawing.Size(223, 20)
        Me.txtVersionKey.TabIndex = 61
        '
        'chkWellFormed
        '
        Me.chkWellFormed.Enabled = False
        Me.chkWellFormed.Location = New System.Drawing.Point(254, 152)
        Me.chkWellFormed.Name = "chkWellFormed"
        Me.chkWellFormed.Size = New System.Drawing.Size(87, 24)
        Me.chkWellFormed.TabIndex = 60
        Me.chkWellFormed.Text = "Well-formed"
        Me.chkWellFormed.Visible = False
        '
        'chkScientific
        '
        Me.chkScientific.Enabled = False
        Me.chkScientific.Location = New System.Drawing.Point(180, 152)
        Me.chkScientific.Name = "chkScientific"
        Me.chkScientific.Size = New System.Drawing.Size(80, 24)
        Me.chkScientific.TabIndex = 59
        Me.chkScientific.Text = "Scientific"
        Me.chkScientific.Visible = False
        '
        'chkPreferred
        '
        Me.chkPreferred.Enabled = False
        Me.chkPreferred.Location = New System.Drawing.Point(105, 152)
        Me.chkPreferred.Name = "chkPreferred"
        Me.chkPreferred.Size = New System.Drawing.Size(72, 24)
        Me.chkPreferred.TabIndex = 58
        Me.chkPreferred.Text = "Preferred"
        Me.chkPreferred.Visible = False
        '
        'lblAuthority
        '
        Me.lblAuthority.Location = New System.Drawing.Point(35, 78)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(64, 16)
        Me.lblAuthority.TabIndex = 57
        Me.lblAuthority.Text = "Authority:"
        Me.lblAuthority.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGroup
        '
        Me.lblGroup.Location = New System.Drawing.Point(35, 103)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(64, 16)
        Me.lblGroup.TabIndex = 56
        Me.lblGroup.Text = "Group:"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersionKey
        '
        Me.lblVersionKey.Location = New System.Drawing.Point(17, 129)
        Me.lblVersionKey.Name = "lblVersionKey"
        Me.lblVersionKey.Size = New System.Drawing.Size(82, 20)
        Me.lblVersionKey.TabIndex = 55
        Me.lblVersionKey.Text = "Version key:"
        Me.lblVersionKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Scientific name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Common name:"
        '
        'tabWhere
        '
        Me.tabWhere.Controls.Add(Me.cbOtherRecs)
        Me.tabWhere.Controls.Add(Me.cbShowTrack)
        Me.tabWhere.Controls.Add(Me.butNBN)
        Me.tabWhere.Controls.Add(Me.butSearchGaz)
        Me.tabWhere.Controls.Add(Me.panMap)
        Me.tabWhere.Controls.Add(Me.butMap)
        Me.tabWhere.Controls.Add(Me.but10fig)
        Me.tabWhere.Controls.Add(Me.but8fig)
        Me.tabWhere.Controls.Add(Me.Panel1)
        Me.tabWhere.Controls.Add(Me.butTetrad)
        Me.tabWhere.Controls.Add(Me.butHectad)
        Me.tabWhere.Controls.Add(Me.butMonad)
        Me.tabWhere.Controls.Add(Me.butGetLocation)
        Me.tabWhere.Controls.Add(Me.chkNewLocation)
        Me.tabWhere.Controls.Add(Me.but6fig)
        Me.tabWhere.Controls.Add(Me.grpLineOfBestFit)
        Me.tabWhere.Controls.Add(Me.Label12)
        Me.tabWhere.Controls.Add(Me.Label13)
        Me.tabWhere.Controls.Add(Me.chkProjectLocation)
        Me.tabWhere.Controls.Add(Me.nudOffset)
        Me.tabWhere.Controls.Add(Me.nudOclock)
        Me.tabWhere.Controls.Add(Me.lvTowns)
        Me.tabWhere.Controls.Add(Me.txtTown)
        Me.tabWhere.Controls.Add(Me.Label14)
        Me.tabWhere.Controls.Add(Me.txtLocation)
        Me.tabWhere.Controls.Add(Me.Label15)
        Me.tabWhere.Controls.Add(Me.lvLocations)
        Me.tabWhere.Controls.Add(Me.txtGR)
        Me.tabWhere.Controls.Add(Me.Label16)
        Me.tabWhere.Location = New System.Drawing.Point(4, 22)
        Me.tabWhere.Name = "tabWhere"
        Me.tabWhere.Size = New System.Drawing.Size(696, 384)
        Me.tabWhere.TabIndex = 2
        Me.tabWhere.Text = "Where?"
        Me.tabWhere.UseVisualStyleBackColor = True
        '
        'cbOtherRecs
        '
        Me.cbOtherRecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOtherRecs.AutoSize = True
        Me.cbOtherRecs.Location = New System.Drawing.Point(580, 172)
        Me.cbOtherRecs.Name = "cbOtherRecs"
        Me.cbOtherRecs.Size = New System.Drawing.Size(103, 17)
        Me.cbOtherRecs.TabIndex = 99
        Me.cbOtherRecs.Tag = ""
        Me.cbOtherRecs.Text = "Show other recs"
        Me.tt.SetToolTip(Me.cbOtherRecs, "Check this box if you want to show an " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the location of other open records.")
        Me.cbOtherRecs.UseVisualStyleBackColor = True
        '
        'cbShowTrack
        '
        Me.cbShowTrack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbShowTrack.AutoSize = True
        Me.cbShowTrack.Location = New System.Drawing.Point(488, 172)
        Me.cbShowTrack.Name = "cbShowTrack"
        Me.cbShowTrack.Size = New System.Drawing.Size(80, 17)
        Me.cbShowTrack.TabIndex = 98
        Me.cbShowTrack.Tag = ""
        Me.cbShowTrack.Text = "Show track"
        Me.tt.SetToolTip(Me.cbShowTrack, "Check this box if you want to show an " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "associated track.")
        Me.cbShowTrack.UseVisualStyleBackColor = True
        '
        'butNBN
        '
        Me.butNBN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butNBN.Location = New System.Drawing.Point(644, 6)
        Me.butNBN.Name = "butNBN"
        Me.butNBN.Size = New System.Drawing.Size(49, 23)
        Me.butNBN.TabIndex = 97
        Me.butNBN.Text = "NBN"
        Me.tt.SetToolTip(Me.butNBN, "Download a grid map from the NBN showing the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "distribution of the currently selec" &
        "ted taxon.")
        Me.butNBN.UseVisualStyleBackColor = True
        Me.butNBN.Visible = False
        '
        'butSearchGaz
        '
        Me.butSearchGaz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSearchGaz.Location = New System.Drawing.Point(331, 59)
        Me.butSearchGaz.Name = "butSearchGaz"
        Me.butSearchGaz.Size = New System.Drawing.Size(111, 23)
        Me.butSearchGaz.TabIndex = 89
        Me.butSearchGaz.Tag = ""
        Me.butSearchGaz.Text = "Find town/village"
        Me.tt.SetToolTip(Me.butSearchGaz, resources.GetString("butSearchGaz.ToolTip"))
        Me.butSearchGaz.UseVisualStyleBackColor = True
        '
        'panMap
        '
        Me.panMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panMap.Controls.Add(Me.txtGRMove)
        Me.panMap.Controls.Add(Me.butUse)
        Me.panMap.Controls.Add(Me.cbPrecision)
        Me.panMap.Controls.Add(Me.tbZoom)
        Me.panMap.Controls.Add(Me.cbMapType)
        Me.panMap.Controls.Add(Me.pbMap)
        Me.panMap.Location = New System.Drawing.Point(4, 87)
        Me.panMap.Name = "panMap"
        Me.panMap.Size = New System.Drawing.Size(478, 294)
        Me.panMap.TabIndex = 94
        '
        'txtGRMove
        '
        Me.txtGRMove.Enabled = False
        Me.txtGRMove.Location = New System.Drawing.Point(69, 5)
        Me.txtGRMove.Name = "txtGRMove"
        Me.txtGRMove.Size = New System.Drawing.Size(96, 20)
        Me.txtGRMove.TabIndex = 98
        Me.tt.SetToolTip(Me.txtGRMove, "Grid reference of selected point on map.")
        '
        'butUse
        '
        Me.butUse.Location = New System.Drawing.Point(171, 5)
        Me.butUse.Name = "butUse"
        Me.butUse.Size = New System.Drawing.Size(35, 21)
        Me.butUse.TabIndex = 97
        Me.butUse.Text = "Use"
        Me.tt.SetToolTip(Me.butUse, "Use this button use the grid reference selected from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the map as the grid referen" &
        "ce for the record.")
        Me.butUse.UseVisualStyleBackColor = True
        '
        'cbPrecision
        '
        Me.cbPrecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrecision.FormattingEnabled = True
        Me.cbPrecision.Items.AddRange(New Object() {"10 fig", "8 fig", "6 fig", "1 km", "2 km", "10 km"})
        Me.cbPrecision.Location = New System.Drawing.Point(3, 4)
        Me.cbPrecision.Name = "cbPrecision"
        Me.cbPrecision.Size = New System.Drawing.Size(60, 21)
        Me.cbPrecision.TabIndex = 96
        Me.tt.SetToolTip(Me.cbPrecision, "Use this to set the precision of grid references" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "obtained by clicking on the map" &
        ".")
        '
        'tbZoom
        '
        Me.tbZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbZoom.LargeChange = 1
        Me.tbZoom.Location = New System.Drawing.Point(428, 27)
        Me.tbZoom.Maximum = 20
        Me.tbZoom.Minimum = 5
        Me.tbZoom.Name = "tbZoom"
        Me.tbZoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbZoom.Size = New System.Drawing.Size(45, 104)
        Me.tbZoom.TabIndex = 93
        Me.tbZoom.Value = 13
        '
        'cbMapType
        '
        Me.cbMapType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMapType.FormattingEnabled = True
        Me.cbMapType.Items.AddRange(New Object() {"Road", "Aerial", "Aerial with labels", "Terrain or OS"})
        Me.cbMapType.Location = New System.Drawing.Point(353, 3)
        Me.cbMapType.Name = "cbMapType"
        Me.cbMapType.Size = New System.Drawing.Size(120, 21)
        Me.cbMapType.TabIndex = 91
        '
        'pbMap
        '
        Me.pbMap.ImageLocation = ""
        Me.pbMap.Location = New System.Drawing.Point(19, 44)
        Me.pbMap.Name = "pbMap"
        Me.pbMap.Size = New System.Drawing.Size(236, 183)
        Me.pbMap.TabIndex = 89
        Me.pbMap.TabStop = False
        Me.pbMap.WaitOnLoad = True
        '
        'butMap
        '
        Me.butMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butMap.Location = New System.Drawing.Point(496, 33)
        Me.butMap.Name = "butMap"
        Me.butMap.Size = New System.Drawing.Size(56, 23)
        Me.butMap.TabIndex = 90
        Me.butMap.Text = "Map"
        Me.tt.SetToolTip(Me.butMap, "This will display a map of the current grid reference and," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "optionally, an offset" &
        " position for records generated with" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a GPS track (calculated from the parameter" &
        "s specified).")
        Me.butMap.UseVisualStyleBackColor = True
        '
        'but10fig
        '
        Me.but10fig.Location = New System.Drawing.Point(397, 6)
        Me.but10fig.Name = "but10fig"
        Me.but10fig.Size = New System.Drawing.Size(45, 23)
        Me.but10fig.TabIndex = 87
        Me.but10fig.Tag = "You can use this button to..."
        Me.but10fig.Text = "10 fig"
        Me.tt.SetToolTip(Me.but10fig, "This will reset an OS ten figure grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and l" &
        "ongitude recorded by the GPS.")
        Me.but10fig.UseVisualStyleBackColor = True
        '
        'but8fig
        '
        Me.but8fig.Location = New System.Drawing.Point(358, 6)
        Me.but8fig.Name = "but8fig"
        Me.but8fig.Size = New System.Drawing.Size(38, 23)
        Me.but8fig.TabIndex = 86
        Me.but8fig.Tag = "You can use this button to..."
        Me.but8fig.Text = "8 fig"
        Me.tt.SetToolTip(Me.but8fig, "This will reset an OS eight figure grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and" &
        " longitude recorded by the GPS.")
        Me.but8fig.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rbMapsGE)
        Me.Panel1.Controls.Add(Me.rbMapsBing)
        Me.Panel1.Controls.Add(Me.rbMapsGoogle)
        Me.Panel1.Location = New System.Drawing.Point(493, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(146, 21)
        Me.Panel1.TabIndex = 96
        '
        'rbMapsGE
        '
        Me.rbMapsGE.AutoSize = True
        Me.rbMapsGE.BackColor = System.Drawing.Color.Transparent
        Me.rbMapsGE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMapsGE.Location = New System.Drawing.Point(103, 2)
        Me.rbMapsGE.Margin = New System.Windows.Forms.Padding(5)
        Me.rbMapsGE.Name = "rbMapsGE"
        Me.rbMapsGE.Size = New System.Drawing.Size(40, 17)
        Me.rbMapsGE.TabIndex = 96
        Me.rbMapsGE.Text = "GE"
        Me.tt.SetToolTip(Me.rbMapsGE, "Use Google Earth to display grid references.")
        Me.rbMapsGE.UseVisualStyleBackColor = False
        '
        'rbMapsBing
        '
        Me.rbMapsBing.AutoSize = True
        Me.rbMapsBing.BackColor = System.Drawing.Color.Transparent
        Me.rbMapsBing.Checked = True
        Me.rbMapsBing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMapsBing.Location = New System.Drawing.Point(5, 2)
        Me.rbMapsBing.Margin = New System.Windows.Forms.Padding(5)
        Me.rbMapsBing.Name = "rbMapsBing"
        Me.rbMapsBing.Size = New System.Drawing.Size(46, 17)
        Me.rbMapsBing.TabIndex = 95
        Me.rbMapsBing.TabStop = True
        Me.rbMapsBing.Text = "Bing"
        Me.tt.SetToolTip(Me.rbMapsBing, "Use Bing Maps to display a map on the Where tab.")
        Me.rbMapsBing.UseVisualStyleBackColor = False
        '
        'rbMapsGoogle
        '
        Me.rbMapsGoogle.AutoSize = True
        Me.rbMapsGoogle.BackColor = System.Drawing.Color.Transparent
        Me.rbMapsGoogle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMapsGoogle.Location = New System.Drawing.Point(56, 2)
        Me.rbMapsGoogle.Margin = New System.Windows.Forms.Padding(5)
        Me.rbMapsGoogle.Name = "rbMapsGoogle"
        Me.rbMapsGoogle.Size = New System.Drawing.Size(42, 17)
        Me.rbMapsGoogle.TabIndex = 94
        Me.rbMapsGoogle.Text = "GM"
        Me.tt.SetToolTip(Me.rbMapsGoogle, "Use Google Maps to display a map on the Where tab.")
        Me.rbMapsGoogle.UseVisualStyleBackColor = False
        '
        'butTetrad
        '
        Me.butTetrad.Location = New System.Drawing.Point(320, 6)
        Me.butTetrad.Name = "butTetrad"
        Me.butTetrad.Size = New System.Drawing.Size(38, 23)
        Me.butTetrad.TabIndex = 85
        Me.butTetrad.Tag = "You can use this button to..."
        Me.butTetrad.Text = "2 km"
        Me.tt.SetToolTip(Me.butTetrad, "This will reset an OS tetrad grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and longi" &
        "tude recorded by the GPS.")
        Me.butTetrad.UseVisualStyleBackColor = True
        '
        'butHectad
        '
        Me.butHectad.Location = New System.Drawing.Point(273, 6)
        Me.butHectad.Name = "butHectad"
        Me.butHectad.Size = New System.Drawing.Size(47, 23)
        Me.butHectad.TabIndex = 84
        Me.butHectad.Tag = "You can use this button to..."
        Me.butHectad.Text = "10 km"
        Me.tt.SetToolTip(Me.butHectad, "This will reset an OS hectad grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and longi" &
        "tude recorded by the GPS.")
        Me.butHectad.UseVisualStyleBackColor = True
        '
        'butMonad
        '
        Me.butMonad.Location = New System.Drawing.Point(235, 6)
        Me.butMonad.Name = "butMonad"
        Me.butMonad.Size = New System.Drawing.Size(38, 23)
        Me.butMonad.TabIndex = 83
        Me.butMonad.Tag = "You can use this button to..."
        Me.butMonad.Text = "1 km"
        Me.tt.SetToolTip(Me.butMonad, "This will reset an OS monad grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and longit" &
        "ude recorded by the GPS.")
        Me.butMonad.UseVisualStyleBackColor = True
        '
        'butGetLocation
        '
        Me.butGetLocation.Location = New System.Drawing.Point(57, 59)
        Me.butGetLocation.Name = "butGetLocation"
        Me.butGetLocation.Size = New System.Drawing.Size(103, 23)
        Me.butGetLocation.TabIndex = 66
        Me.butGetLocation.Text = "Location from GR"
        Me.tt.SetToolTip(Me.butGetLocation, "This will reset the location and town names from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Gilbert gazetteer based on " &
        "the current grid reference.")
        Me.butGetLocation.UseVisualStyleBackColor = True
        '
        'chkNewLocation
        '
        Me.chkNewLocation.AutoSize = True
        Me.chkNewLocation.Location = New System.Drawing.Point(166, 63)
        Me.chkNewLocation.Name = "chkNewLocation"
        Me.chkNewLocation.Size = New System.Drawing.Size(114, 17)
        Me.chkNewLocation.TabIndex = 69
        Me.chkNewLocation.Text = "Save new location"
        Me.tt.SetToolTip(Me.chkNewLocation, resources.GetString("chkNewLocation.ToolTip"))
        Me.chkNewLocation.UseVisualStyleBackColor = True
        '
        'but6fig
        '
        Me.but6fig.Location = New System.Drawing.Point(197, 6)
        Me.but6fig.Name = "but6fig"
        Me.but6fig.Size = New System.Drawing.Size(38, 23)
        Me.but6fig.TabIndex = 82
        Me.but6fig.Tag = "You can use this button to..."
        Me.but6fig.Text = "6 fig"
        Me.tt.SetToolTip(Me.but6fig, "This will reset an OS six figure grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and l" &
        "ongitude recorded by the GPS.")
        Me.but6fig.UseVisualStyleBackColor = True
        '
        'grpLineOfBestFit
        '
        Me.grpLineOfBestFit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLineOfBestFit.Controls.Add(Me.radSpecifyBestFit)
        Me.grpLineOfBestFit.Controls.Add(Me.radAutoBestFit)
        Me.grpLineOfBestFit.Controls.Add(Me.nudGEPoints)
        Me.grpLineOfBestFit.Controls.Add(Me.Label11)
        Me.grpLineOfBestFit.Enabled = False
        Me.grpLineOfBestFit.Location = New System.Drawing.Point(491, 88)
        Me.grpLineOfBestFit.Name = "grpLineOfBestFit"
        Me.grpLineOfBestFit.Padding = New System.Windows.Forms.Padding(5)
        Me.grpLineOfBestFit.Size = New System.Drawing.Size(193, 78)
        Me.grpLineOfBestFit.TabIndex = 81
        Me.grpLineOfBestFit.TabStop = False
        Me.grpLineOfBestFit.Text = "Line of best fit calculation"
        '
        'radSpecifyBestFit
        '
        Me.radSpecifyBestFit.AutoSize = True
        Me.radSpecifyBestFit.Location = New System.Drawing.Point(101, 23)
        Me.radSpecifyBestFit.Name = "radSpecifyBestFit"
        Me.radSpecifyBestFit.Size = New System.Drawing.Size(91, 17)
        Me.radSpecifyBestFit.TabIndex = 13
        Me.radSpecifyBestFit.Text = "Specify points"
        Me.tt.SetToolTip(Me.radSpecifyBestFit, resources.GetString("radSpecifyBestFit.ToolTip"))
        Me.radSpecifyBestFit.UseVisualStyleBackColor = True
        '
        'radAutoBestFit
        '
        Me.radAutoBestFit.AutoSize = True
        Me.radAutoBestFit.Checked = True
        Me.radAutoBestFit.Location = New System.Drawing.Point(8, 23)
        Me.radAutoBestFit.Name = "radAutoBestFit"
        Me.radAutoBestFit.Size = New System.Drawing.Size(72, 17)
        Me.radAutoBestFit.TabIndex = 12
        Me.radAutoBestFit.TabStop = True
        Me.radAutoBestFit.Text = "Automatic"
        Me.tt.SetToolTip(Me.radAutoBestFit, "Use this option to let the software use the default number" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of track points to ca" &
        "lculate the track in order to find" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the offset location.")
        Me.radAutoBestFit.UseVisualStyleBackColor = True
        '
        'nudGEPoints
        '
        Me.nudGEPoints.Enabled = False
        Me.nudGEPoints.Location = New System.Drawing.Point(6, 44)
        Me.nudGEPoints.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudGEPoints.Name = "nudGEPoints"
        Me.nudGEPoints.Size = New System.Drawing.Size(44, 20)
        Me.nudGEPoints.TabIndex = 14
        Me.nudGEPoints.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(58, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "points"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(643, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "o'clock"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(547, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "metres at"
        '
        'chkProjectLocation
        '
        Me.chkProjectLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkProjectLocation.AutoSize = True
        Me.chkProjectLocation.Location = New System.Drawing.Point(563, 37)
        Me.chkProjectLocation.Name = "chkProjectLocation"
        Me.chkProjectLocation.Size = New System.Drawing.Size(94, 17)
        Me.chkProjectLocation.TabIndex = 71
        Me.chkProjectLocation.Tag = ""
        Me.chkProjectLocation.Text = "Offset location"
        Me.tt.SetToolTip(Me.chkProjectLocation, "Check this box if you want to show an offset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "location from the grid reference.")
        Me.chkProjectLocation.UseVisualStyleBackColor = True
        '
        'nudOffset
        '
        Me.nudOffset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudOffset.Enabled = False
        Me.nudOffset.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudOffset.Location = New System.Drawing.Point(497, 62)
        Me.nudOffset.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudOffset.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudOffset.Name = "nudOffset"
        Me.nudOffset.Size = New System.Drawing.Size(44, 20)
        Me.nudOffset.TabIndex = 72
        Me.nudOffset.Tag = ""
        Me.nudOffset.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'nudOclock
        '
        Me.nudOclock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudOclock.Enabled = False
        Me.nudOclock.Location = New System.Drawing.Point(603, 62)
        Me.nudOclock.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.nudOclock.Name = "nudOclock"
        Me.nudOclock.Size = New System.Drawing.Size(34, 20)
        Me.nudOclock.TabIndex = 73
        Me.nudOclock.Tag = ""
        Me.nudOclock.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'lvTowns
        '
        Me.lvTowns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTowns.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTown, Me.colTownDistance})
        Me.lvTowns.Location = New System.Drawing.Point(488, 296)
        Me.lvTowns.Name = "lvTowns"
        Me.lvTowns.Size = New System.Drawing.Size(196, 85)
        Me.lvTowns.TabIndex = 76
        Me.tt.SetToolTip(Me.lvTowns, "Shows the nearest towns to the specified grid reference " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "together with their dis" &
        "tances from that grid reference. Select" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a town from this list to enter it in th" &
        "e Town field.")
        Me.lvTowns.UseCompatibleStateImageBehavior = False
        Me.lvTowns.View = System.Windows.Forms.View.Details
        '
        'colTown
        '
        Me.colTown.Text = "Town"
        Me.colTown.Width = 123
        '
        'colTownDistance
        '
        Me.colTownDistance.Text = "Distance"
        '
        'txtTown
        '
        Me.txtTown.Location = New System.Drawing.Point(331, 33)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(111, 20)
        Me.txtTown.TabIndex = 68
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(293, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "Town:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(58, 33)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(224, 20)
        Me.txtLocation.TabIndex = 67
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Location:"
        '
        'lvLocations
        '
        Me.lvLocations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLocations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLocation, Me.colDistance})
        Me.lvLocations.Location = New System.Drawing.Point(488, 194)
        Me.lvLocations.Name = "lvLocations"
        Me.lvLocations.Size = New System.Drawing.Size(196, 96)
        Me.lvLocations.TabIndex = 75
        Me.tt.SetToolTip(Me.lvLocations, "Shows the nearest locations to the specified grid reference " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "together with their" &
        " distances from that grid reference. Select" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a location from this list to enter " &
        "it in the Location field.")
        Me.lvLocations.UseCompatibleStateImageBehavior = False
        Me.lvLocations.View = System.Windows.Forms.View.Details
        '
        'colLocation
        '
        Me.colLocation.Text = "Location"
        Me.colLocation.Width = 123
        '
        'colDistance
        '
        Me.colDistance.Text = "Distance"
        Me.colDistance.Width = 59
        '
        'txtGR
        '
        Me.txtGR.Location = New System.Drawing.Point(58, 8)
        Me.txtGR.Multiline = True
        Me.txtGR.Name = "txtGR"
        Me.txtGR.Size = New System.Drawing.Size(136, 20)
        Me.txtGR.TabIndex = 64
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Grid Ref: "
        '
        'tabWhen
        '
        Me.tabWhen.Controls.Add(Me.chkNoTime)
        Me.tabWhen.Controls.Add(Me.chkNoDate)
        Me.tabWhen.Controls.Add(Me.dtpTime)
        Me.tabWhen.Controls.Add(Me.dtpDate)
        Me.tabWhen.Location = New System.Drawing.Point(4, 22)
        Me.tabWhen.Name = "tabWhen"
        Me.tabWhen.Size = New System.Drawing.Size(696, 384)
        Me.tabWhen.TabIndex = 3
        Me.tabWhen.Text = "When?"
        Me.tabWhen.UseVisualStyleBackColor = True
        '
        'chkNoTime
        '
        Me.chkNoTime.AutoSize = True
        Me.chkNoTime.Location = New System.Drawing.Point(135, 39)
        Me.chkNoTime.Name = "chkNoTime"
        Me.chkNoTime.Size = New System.Drawing.Size(62, 17)
        Me.chkNoTime.TabIndex = 7
        Me.chkNoTime.Text = "No time"
        Me.chkNoTime.UseVisualStyleBackColor = True
        '
        'chkNoDate
        '
        Me.chkNoDate.AutoSize = True
        Me.chkNoDate.Location = New System.Drawing.Point(9, 39)
        Me.chkNoDate.Name = "chkNoDate"
        Me.chkNoDate.Size = New System.Drawing.Size(64, 17)
        Me.chkNoDate.TabIndex = 6
        Me.chkNoDate.Text = "No date"
        Me.chkNoDate.UseVisualStyleBackColor = True
        '
        'dtpTime
        '
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(135, 13)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(120, 20)
        Me.dtpTime.TabIndex = 5
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(8, 13)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpDate.TabIndex = 4
        '
        'tabComment
        '
        Me.tabComment.Controls.Add(Me.lblHeadlineComment)
        Me.tabComment.Controls.Add(Me.Label9)
        Me.tabComment.Controls.Add(Me.txtPersonalNotes)
        Me.tabComment.Controls.Add(Me.Label10)
        Me.tabComment.Controls.Add(Me.txtComment)
        Me.tabComment.Location = New System.Drawing.Point(4, 22)
        Me.tabComment.Name = "tabComment"
        Me.tabComment.Size = New System.Drawing.Size(696, 384)
        Me.tabComment.TabIndex = 4
        Me.tabComment.Text = "Commentary"
        Me.tabComment.UseVisualStyleBackColor = True
        '
        'lblHeadlineComment
        '
        Me.lblHeadlineComment.AutoSize = True
        Me.lblHeadlineComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadlineComment.Location = New System.Drawing.Point(106, 11)
        Me.lblHeadlineComment.Name = "lblHeadlineComment"
        Me.lblHeadlineComment.Size = New System.Drawing.Size(111, 13)
        Me.lblHeadlineComment.TabIndex = 81
        Me.lblHeadlineComment.Text = "Headline comment"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Personal note:"
        '
        'txtPersonalNotes
        '
        Me.txtPersonalNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPersonalNotes.Location = New System.Drawing.Point(109, 92)
        Me.txtPersonalNotes.Multiline = True
        Me.txtPersonalNotes.Name = "txtPersonalNotes"
        Me.txtPersonalNotes.Size = New System.Drawing.Size(539, 81)
        Me.txtPersonalNotes.TabIndex = 82
        Me.tt.SetToolTip(Me.txtPersonalNotes, "Personal notes can be used for comments" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that you do not want to be part of the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "public record when you export records." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can use [ctrl] and Enter together to" &
        " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "enter a newline.")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(49, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Comment:"
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(109, 34)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(539, 52)
        Me.txtComment.TabIndex = 81
        Me.tt.SetToolTip(Me.txtComment, "You can use [ctrl] and Enter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "together to enter a newline.")
        '
        'tabMedia
        '
        Me.tabMedia.Controls.Add(Me.SplitContainer1)
        Me.tabMedia.Controls.Add(Me.butMediaProps)
        Me.tabMedia.Controls.Add(Me.butMediaDown)
        Me.tabMedia.Controls.Add(Me.butMediaUp)
        Me.tabMedia.Controls.Add(Me.butDeleteMedia)
        Me.tabMedia.Controls.Add(Me.butAddMedia)
        Me.tabMedia.Location = New System.Drawing.Point(4, 22)
        Me.tabMedia.Name = "tabMedia"
        Me.tabMedia.Size = New System.Drawing.Size(696, 384)
        Me.tabMedia.TabIndex = 5
        Me.tabMedia.Text = "Media"
        Me.tabMedia.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvMedia)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(563, 366)
        Me.SplitContainer1.SplitterDistance = 159
        Me.SplitContainer1.TabIndex = 10
        '
        'lvMedia
        '
        Me.lvMedia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMedia.HideSelection = False
        Me.lvMedia.LargeImageList = Me.imlMedia
        Me.lvMedia.Location = New System.Drawing.Point(0, 0)
        Me.lvMedia.Name = "lvMedia"
        Me.lvMedia.Size = New System.Drawing.Size(157, 365)
        Me.lvMedia.TabIndex = 4
        Me.lvMedia.UseCompatibleStateImageBehavior = False
        '
        'imlMedia
        '
        Me.imlMedia.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlMedia.ImageSize = New System.Drawing.Size(120, 120)
        Me.imlMedia.TransparentColor = System.Drawing.Color.Transparent
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.picMedia)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblMediaComment)
        Me.SplitContainer2.Size = New System.Drawing.Size(399, 366)
        Me.SplitContainer2.SplitterDistance = 280
        Me.SplitContainer2.TabIndex = 0
        '
        'picMedia
        '
        Me.picMedia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picMedia.Location = New System.Drawing.Point(0, 0)
        Me.picMedia.Name = "picMedia"
        Me.picMedia.Size = New System.Drawing.Size(394, 275)
        Me.picMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMedia.TabIndex = 5
        Me.picMedia.TabStop = False
        '
        'lblMediaComment
        '
        Me.lblMediaComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMediaComment.Location = New System.Drawing.Point(0, 0)
        Me.lblMediaComment.Name = "lblMediaComment"
        Me.lblMediaComment.Size = New System.Drawing.Size(398, 81)
        Me.lblMediaComment.TabIndex = 1
        '
        'butMediaProps
        '
        Me.butMediaProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butMediaProps.Location = New System.Drawing.Point(571, 119)
        Me.butMediaProps.Name = "butMediaProps"
        Me.butMediaProps.Size = New System.Drawing.Size(75, 23)
        Me.butMediaProps.TabIndex = 9
        Me.butMediaProps.Text = "Properties"
        Me.butMediaProps.UseVisualStyleBackColor = True
        '
        'butMediaDown
        '
        Me.butMediaDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butMediaDown.Location = New System.Drawing.Point(571, 90)
        Me.butMediaDown.Name = "butMediaDown"
        Me.butMediaDown.Size = New System.Drawing.Size(75, 23)
        Me.butMediaDown.TabIndex = 8
        Me.butMediaDown.Text = "Move down"
        Me.butMediaDown.UseVisualStyleBackColor = True
        '
        'butMediaUp
        '
        Me.butMediaUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butMediaUp.Location = New System.Drawing.Point(571, 61)
        Me.butMediaUp.Name = "butMediaUp"
        Me.butMediaUp.Size = New System.Drawing.Size(75, 23)
        Me.butMediaUp.TabIndex = 7
        Me.butMediaUp.Text = "Move up"
        Me.butMediaUp.UseVisualStyleBackColor = True
        '
        'butDeleteMedia
        '
        Me.butDeleteMedia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDeleteMedia.Location = New System.Drawing.Point(571, 32)
        Me.butDeleteMedia.Name = "butDeleteMedia"
        Me.butDeleteMedia.Size = New System.Drawing.Size(75, 23)
        Me.butDeleteMedia.TabIndex = 6
        Me.butDeleteMedia.Text = "Delete"
        Me.butDeleteMedia.UseVisualStyleBackColor = True
        '
        'butAddMedia
        '
        Me.butAddMedia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddMedia.Location = New System.Drawing.Point(571, 3)
        Me.butAddMedia.Name = "butAddMedia"
        Me.butAddMedia.Size = New System.Drawing.Size(75, 23)
        Me.butAddMedia.TabIndex = 0
        Me.butAddMedia.Text = "Add"
        Me.butAddMedia.UseVisualStyleBackColor = True
        '
        'butOffsetGR
        '
        Me.butOffsetGR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butOffsetGR.Location = New System.Drawing.Point(555, 3)
        Me.butOffsetGR.Name = "butOffsetGR"
        Me.butOffsetGR.Size = New System.Drawing.Size(67, 23)
        Me.butOffsetGR.TabIndex = 88
        Me.butOffsetGR.Tag = ""
        Me.butOffsetGR.Text = "Offset GR"
        Me.tt.SetToolTip(Me.butOffsetGR, resources.GetString("butOffsetGR.ToolTip"))
        Me.butOffsetGR.UseVisualStyleBackColor = True
        Me.butOffsetGR.Visible = False
        '
        'chkDebug
        '
        Me.chkDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Location = New System.Drawing.Point(628, 7)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(78, 17)
        Me.chkDebug.TabIndex = 72
        Me.chkDebug.Text = "Debug lists"
        Me.chkDebug.UseVisualStyleBackColor = True
        Me.chkDebug.Visible = False
        '
        'chkExcludeFromExport
        '
        Me.chkExcludeFromExport.AutoSize = True
        Me.chkExcludeFromExport.Location = New System.Drawing.Point(9, 7)
        Me.chkExcludeFromExport.Name = "chkExcludeFromExport"
        Me.chkExcludeFromExport.Size = New System.Drawing.Size(119, 17)
        Me.chkExcludeFromExport.TabIndex = 84
        Me.chkExcludeFromExport.Text = "Exclude from export"
        Me.tt.SetToolTip(Me.chkExcludeFromExport, "By default, exclude this record from export.")
        Me.chkExcludeFromExport.UseVisualStyleBackColor = True
        '
        'butVoice
        '
        Me.butVoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butVoice.Image = CType(resources.GetObject("butVoice.Image"), System.Drawing.Image)
        Me.butVoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butVoice.Location = New System.Drawing.Point(718, 50)
        Me.butVoice.Name = "butVoice"
        Me.butVoice.Size = New System.Drawing.Size(63, 24)
        Me.butVoice.TabIndex = 1
        Me.butVoice.Text = "Voice"
        Me.butVoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tt.SetToolTip(Me.butVoice, "Play the voice file associated with this record.")
        Me.butVoice.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butCancel.Location = New System.Drawing.Point(718, 416)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(63, 24)
        Me.butCancel.TabIndex = 7
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'grpOkay
        '
        Me.grpOkay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOkay.Controls.Add(Me.butOkay)
        Me.grpOkay.Controls.Add(Me.butOkayMonad)
        Me.grpOkay.Controls.Add(Me.butOkay6fig)
        Me.grpOkay.Location = New System.Drawing.Point(709, 309)
        Me.grpOkay.Name = "grpOkay"
        Me.grpOkay.Size = New System.Drawing.Size(80, 105)
        Me.grpOkay.TabIndex = 3
        Me.grpOkay.TabStop = False
        '
        'butOkay
        '
        Me.butOkay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butOkay.Location = New System.Drawing.Point(9, 14)
        Me.butOkay.Name = "butOkay"
        Me.butOkay.Size = New System.Drawing.Size(63, 24)
        Me.butOkay.TabIndex = 3
        Me.butOkay.Text = "Okay"
        Me.tt.SetToolTip(Me.butOkay, "Commit changes.")
        Me.butOkay.UseVisualStyleBackColor = True
        '
        'butOkayMonad
        '
        Me.butOkayMonad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butOkayMonad.Location = New System.Drawing.Point(9, 74)
        Me.butOkayMonad.Name = "butOkayMonad"
        Me.butOkayMonad.Size = New System.Drawing.Size(63, 24)
        Me.butOkayMonad.TabIndex = 5
        Me.butOkayMonad.Text = "1 km GR"
        Me.tt.SetToolTip(Me.butOkayMonad, "This will reset an OS monad grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and longit" &
        "ude recorded by the GPS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and commit all changes you've made.")
        Me.butOkayMonad.UseVisualStyleBackColor = True
        '
        'butOkay6fig
        '
        Me.butOkay6fig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butOkay6fig.Location = New System.Drawing.Point(9, 44)
        Me.butOkay6fig.Name = "butOkay6fig"
        Me.butOkay6fig.Size = New System.Drawing.Size(63, 24)
        Me.butOkay6fig.TabIndex = 4
        Me.butOkay6fig.Text = "6 fig GR"
        Me.tt.SetToolTip(Me.butOkay6fig, "This will reset an OS six figure grid reference from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "original latitude and l" &
        "ongitude recorded by the GPS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and commit all changes you've made.")
        Me.butOkay6fig.UseVisualStyleBackColor = True
        '
        'timDebug
        '
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'timMapGraphics
        '
        '
        'tmrActivateWindow
        '
        Me.tmrActivateWindow.Interval = 200
        '
        'frmRecordDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 447)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.chkExcludeFromExport)
        Me.Controls.Add(Me.butOffsetGR)
        Me.Controls.Add(Me.grpOkay)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butVoice)
        Me.Controls.Add(Me.tcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRecordDetails"
        Me.Text = "Record Details"
        Me.tt.SetToolTip(Me, "This will reset an OS six figure grid reference from the original latitude and lo" &
        "ngitude recorded by the GPS.")
        Me.tcMain.ResumeLayout(False)
        Me.tabWho.ResumeLayout(False)
        Me.tabWho.PerformLayout()
        Me.tabWhat.ResumeLayout(False)
        Me.tabWhat.PerformLayout()
        Me.gbDebug.ResumeLayout(False)
        Me.gbDebug.PerformLayout()
        Me.tabWhere.ResumeLayout(False)
        Me.tabWhere.PerformLayout()
        Me.panMap.ResumeLayout(False)
        Me.panMap.PerformLayout()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpLineOfBestFit.ResumeLayout(False)
        Me.grpLineOfBestFit.PerformLayout()
        CType(Me.nudGEPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudOclock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWhen.ResumeLayout(False)
        Me.tabWhen.PerformLayout()
        Me.tabComment.ResumeLayout(False)
        Me.tabComment.PerformLayout()
        Me.tabMedia.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.picMedia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOkay.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tabWho As System.Windows.Forms.TabPage
    Friend WithEvents tabWhat As System.Windows.Forms.TabPage
    Friend WithEvents butVoice As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents grpOkay As System.Windows.Forms.GroupBox
    Friend WithEvents butOkay As System.Windows.Forms.Button
    Friend WithEvents butOkayMonad As System.Windows.Forms.Button
    Friend WithEvents butOkay6fig As System.Windows.Forms.Button
    Friend WithEvents tabWhere As System.Windows.Forms.TabPage
    Friend WithEvents tabWhen As System.Windows.Forms.TabPage
    Friend WithEvents tabComment As System.Windows.Forms.TabPage
    Friend WithEvents tabMedia As System.Windows.Forms.TabPage
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents cboScientificName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCommonName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAbundanceUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAbundance As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthority As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionKey As System.Windows.Forms.TextBox
    Friend WithEvents chkWellFormed As System.Windows.Forms.CheckBox
    Friend WithEvents chkScientific As System.Windows.Forms.CheckBox
    Friend WithEvents chkPreferred As System.Windows.Forms.CheckBox
    Friend WithEvents lblAuthority As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblVersionKey As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents imlTreeView As System.Windows.Forms.ImageList
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDeterminer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRecorder As System.Windows.Forms.TextBox
    Friend WithEvents chkExcludeFromExport As System.Windows.Forms.CheckBox
    Friend WithEvents lblHeadlineComment As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPersonalNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents butGetLocation As System.Windows.Forms.Button
    Friend WithEvents grpLineOfBestFit As System.Windows.Forms.GroupBox
    Friend WithEvents radSpecifyBestFit As System.Windows.Forms.RadioButton
    Friend WithEvents radAutoBestFit As System.Windows.Forms.RadioButton
    Friend WithEvents nudGEPoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkProjectLocation As System.Windows.Forms.CheckBox
    Friend WithEvents nudOffset As System.Windows.Forms.NumericUpDown
    Private WithEvents nudOclock As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkNewLocation As System.Windows.Forms.CheckBox
    Friend WithEvents lvTowns As System.Windows.Forms.ListView
    Friend WithEvents colTown As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTownDistance As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvLocations As System.Windows.Forms.ListView
    Friend WithEvents colLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDistance As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtGR As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents butSearchCommonName As System.Windows.Forms.Button
    Friend WithEvents butSearchScientificName As System.Windows.Forms.Button
    Friend WithEvents lblComValue As System.Windows.Forms.Label
    Friend WithEvents lblComSelIndex As System.Windows.Forms.Label
    Friend WithEvents lblSciSelIndex As System.Windows.Forms.Label
    Friend WithEvents lblSciValue As System.Windows.Forms.Label
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents timDebug As System.Windows.Forms.Timer
    Friend WithEvents gbDebug As System.Windows.Forms.GroupBox
    Friend WithEvents but6fig As System.Windows.Forms.Button
    Friend WithEvents but10fig As System.Windows.Forms.Button
    Friend WithEvents but8fig As System.Windows.Forms.Button
    Friend WithEvents butTetrad As System.Windows.Forms.Button
    Friend WithEvents butHectad As System.Windows.Forms.Button
    Friend WithEvents butMonad As System.Windows.Forms.Button
    Friend WithEvents butAddMedia As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lvMedia As System.Windows.Forms.ListView
    Friend WithEvents imlMedia As System.Windows.Forms.ImageList
    Friend WithEvents picMedia As System.Windows.Forms.PictureBox
    Friend WithEvents butMediaDown As System.Windows.Forms.Button
    Friend WithEvents butMediaUp As System.Windows.Forms.Button
    Friend WithEvents butDeleteMedia As System.Windows.Forms.Button
    Friend WithEvents butMediaProps As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblMediaComment As System.Windows.Forms.Label
    Friend WithEvents chkNoDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoTime As System.Windows.Forms.CheckBox
    Friend WithEvents butOffsetGR As System.Windows.Forms.Button
    Friend WithEvents cboTaxonGroup As System.Windows.Forms.ComboBox
    Friend WithEvents pbMap As System.Windows.Forms.PictureBox
    Friend WithEvents butMap As System.Windows.Forms.Button
    Friend WithEvents cbMapType As System.Windows.Forms.ComboBox
    Friend WithEvents tbZoom As System.Windows.Forms.TrackBar
    Friend WithEvents panMap As System.Windows.Forms.Panel
    Friend WithEvents timMapGraphics As System.Windows.Forms.Timer
    Friend WithEvents rbMapsBing As System.Windows.Forms.RadioButton
    Friend WithEvents rbMapsGoogle As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbPrecision As System.Windows.Forms.ComboBox
    Friend WithEvents txtGRMove As System.Windows.Forms.TextBox
    Friend WithEvents butUse As System.Windows.Forms.Button
    Friend WithEvents rbMapsGE As System.Windows.Forms.RadioButton
    Friend WithEvents butSearchGaz As System.Windows.Forms.Button
    Friend WithEvents tmrActivateWindow As System.Windows.Forms.Timer
    Friend WithEvents butNBN As System.Windows.Forms.Button
    Friend WithEvents cbShowTrack As System.Windows.Forms.CheckBox
    Friend WithEvents cbOtherRecs As System.Windows.Forms.CheckBox
End Class
