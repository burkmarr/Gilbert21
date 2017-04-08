<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine1 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine2 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(5.0R, "5,0,0,0,0,0")
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(10.0R, "10,0,0,0,0,0")
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(15.0R, "5,0,0,0,0,0")
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(20.0R, "20,0,0,0,0,0")
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, "0,0,0,0,0,0")
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, "0,0,0,0,0,0")
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenEvernoteNotebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenByFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitGilbert21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadGazetteerFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateEmptyDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DBConversionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Version1To2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopulateTracksTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LegacyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Version10To11ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetLocationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageRecipientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageExportHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabRecords = New System.Windows.Forms.TabPage()
        Me.lblInputFile = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.pbLoad = New System.Windows.Forms.ProgressBar()
        Me.dgvRecords = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.splitGraphs = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkCommon = New System.Windows.Forms.CheckBox()
        Me.rbYear = New System.Windows.Forms.RadioButton()
        Me.rbSpecies = New System.Windows.Forms.RadioButton()
        Me.nudMaxYear = New System.Windows.Forms.NumericUpDown()
        Me.nudMinYear = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbChartColours = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbChartType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEqualiseYaxes = New System.Windows.Forms.CheckBox()
        Me.cbRemoveEmptyGraphs = New System.Windows.Forms.CheckBox()
        Me.butBlind = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.rbSumAbundances = New System.Windows.Forms.RadioButton()
        Me.cbSuperimpose = New System.Windows.Forms.CheckBox()
        Me.nudDayGrp = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbCountRecs = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbYearsPerGraph = New System.Windows.Forms.ComboBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemove = New System.Windows.Forms.ToolStripButton()
        Me.tsbValidate = New System.Windows.Forms.ToolStripButton()
        Me.tsbCopy = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAddHashCode = New System.Windows.Forms.ToolStripButton()
        Me.tscbHash = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPlaySound = New System.Windows.Forms.ToolStripButton()
        Me.tsbMergeWAV = New System.Windows.Forms.ToolStripButton()
        Me.tsbDeleteWAV = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbManageLocation = New System.Windows.Forms.ToolStripButton()
        Me.tsbManageTaxa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGE = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMoveDeleteFiles = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.G21Notify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.timNotify = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabRecords.SuspendLayout()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.splitGraphs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitGraphs.Panel1.SuspendLayout()
        Me.splitGraphs.Panel2.SuspendLayout()
        Me.splitGraphs.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudMaxYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDayGrp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        Me.OpenFileDialog.Multiselect = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(737, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.OpenEvernoteNotebookToolStripMenuItem, Me.OpenByFilterToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ClearRecordsToolStripMenuItem, Me.ExportRecordsToolStripMenuItem, Me.ToolStripSeparator6, Me.ExitGilbert21})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OpenToolStripMenuItem.Text = "Open files"
        Me.OpenToolStripMenuItem.ToolTipText = "Create candidate records by opening files."
        '
        'OpenEvernoteNotebookToolStripMenuItem
        '
        Me.OpenEvernoteNotebookToolStripMenuItem.Name = "OpenEvernoteNotebookToolStripMenuItem"
        Me.OpenEvernoteNotebookToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OpenEvernoteNotebookToolStripMenuItem.Text = "Open Evernote notebook"
        Me.OpenEvernoteNotebookToolStripMenuItem.ToolTipText = "Deprecated functionality - click for information."
        '
        'OpenByFilterToolStripMenuItem
        '
        Me.OpenByFilterToolStripMenuItem.Name = "OpenByFilterToolStripMenuItem"
        Me.OpenByFilterToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OpenByFilterToolStripMenuItem.Text = "Open records"
        Me.OpenByFilterToolStripMenuItem.ToolTipText = "Open records from the database."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SaveToolStripMenuItem.Text = "Save records"
        Me.SaveToolStripMenuItem.ToolTipText = "Save records to the database. "
        '
        'ClearRecordsToolStripMenuItem
        '
        Me.ClearRecordsToolStripMenuItem.Name = "ClearRecordsToolStripMenuItem"
        Me.ClearRecordsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ClearRecordsToolStripMenuItem.Text = "Clear records"
        Me.ClearRecordsToolStripMenuItem.ToolTipText = "Clear all records from the current display." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Does not delete records from the da" & _
    "tabase.)"
        '
        'ExportRecordsToolStripMenuItem
        '
        Me.ExportRecordsToolStripMenuItem.Name = "ExportRecordsToolStripMenuItem"
        Me.ExportRecordsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ExportRecordsToolStripMenuItem.Text = "Export records"
        Me.ExportRecordsToolStripMenuItem.ToolTipText = "Export records." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invokes a dialog with various options for" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "exporting the records" & _
    " currently displayed (or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "optionally just those selected). You can choose" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from " & _
    "a number of export formats."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(203, 6)
        '
        'ExitGilbert21
        '
        Me.ExitGilbert21.Name = "ExitGilbert21"
        Me.ExitGilbert21.Size = New System.Drawing.Size(206, 22)
        Me.ExitGilbert21.Text = "Exit Gilbert 21"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadGazetteerFileToolStripMenuItem, Me.CreateEmptyDatabaseToolStripMenuItem, Me.DBConversionToolStripMenuItem, Me.ResetLocationsToolStripMenuItem, Me.ExportsToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'LoadGazetteerFileToolStripMenuItem
        '
        Me.LoadGazetteerFileToolStripMenuItem.Name = "LoadGazetteerFileToolStripMenuItem"
        Me.LoadGazetteerFileToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.LoadGazetteerFileToolStripMenuItem.Text = "Load gazetteer file"
        Me.LoadGazetteerFileToolStripMenuItem.ToolTipText = resources.GetString("LoadGazetteerFileToolStripMenuItem.ToolTipText")
        '
        'CreateEmptyDatabaseToolStripMenuItem
        '
        Me.CreateEmptyDatabaseToolStripMenuItem.Name = "CreateEmptyDatabaseToolStripMenuItem"
        Me.CreateEmptyDatabaseToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.CreateEmptyDatabaseToolStripMenuItem.Text = "Create empty database"
        Me.CreateEmptyDatabaseToolStripMenuItem.ToolTipText = "Create a new empty Gilbert 21 database."
        '
        'DBConversionToolStripMenuItem
        '
        Me.DBConversionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Version1To2ToolStripMenuItem, Me.PopulateTracksTableToolStripMenuItem, Me.LegacyToolStripMenuItem})
        Me.DBConversionToolStripMenuItem.Name = "DBConversionToolStripMenuItem"
        Me.DBConversionToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.DBConversionToolStripMenuItem.Text = "DB conversion"
        Me.DBConversionToolStripMenuItem.ToolTipText = "Utilities for modifying G21 databases."
        '
        'Version1To2ToolStripMenuItem
        '
        Me.Version1To2ToolStripMenuItem.Name = "Version1To2ToolStripMenuItem"
        Me.Version1To2ToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.Version1To2ToolStripMenuItem.Text = "Version 1 to 2"
        Me.Version1To2ToolStripMenuItem.ToolTipText = "Convert a old version 1 (Access)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "database to a new version 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(SQLite) database." & _
    ""
        '
        'PopulateTracksTableToolStripMenuItem
        '
        Me.PopulateTracksTableToolStripMenuItem.Name = "PopulateTracksTableToolStripMenuItem"
        Me.PopulateTracksTableToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PopulateTracksTableToolStripMenuItem.Text = "Initialise tracks tables"
        Me.PopulateTracksTableToolStripMenuItem.ToolTipText = "Create 'tracks' records in a new" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "version 2 database from visiontac" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files under " & _
    "a root folder."
        '
        'LegacyToolStripMenuItem
        '
        Me.LegacyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Version10To11ToolStripMenuItem1})
        Me.LegacyToolStripMenuItem.Name = "LegacyToolStripMenuItem"
        Me.LegacyToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.LegacyToolStripMenuItem.Text = "Legacy"
        Me.LegacyToolStripMenuItem.ToolTipText = "Legacy functionality."
        '
        'Version10To11ToolStripMenuItem1
        '
        Me.Version10To11ToolStripMenuItem1.Name = "Version10To11ToolStripMenuItem1"
        Me.Version10To11ToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.Version10To11ToolStripMenuItem1.Text = "Version 1.0 to 1.1"
        Me.Version10To11ToolStripMenuItem1.ToolTipText = "Convert a version 1.0 database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to a 1.1database (both Access)."
        '
        'ResetLocationsToolStripMenuItem
        '
        Me.ResetLocationsToolStripMenuItem.Name = "ResetLocationsToolStripMenuItem"
        Me.ResetLocationsToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ResetLocationsToolStripMenuItem.Text = "Reset locations"
        Me.ResetLocationsToolStripMenuItem.ToolTipText = "Update the calculated locations from record" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "grid references - but only if record" & _
    " not yet" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "saved to DB. This is used where the Locations" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "database has been manag" & _
    "ed."
        '
        'ExportsToolStripMenuItem
        '
        Me.ExportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageRecipientsToolStripMenuItem, Me.ManageExportHistoryToolStripMenuItem})
        Me.ExportsToolStripMenuItem.Name = "ExportsToolStripMenuItem"
        Me.ExportsToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ExportsToolStripMenuItem.Text = "Exports"
        Me.ExportsToolStripMenuItem.ToolTipText = "Manage export recipients or history."
        '
        'ManageRecipientsToolStripMenuItem
        '
        Me.ManageRecipientsToolStripMenuItem.Name = "ManageRecipientsToolStripMenuItem"
        Me.ManageRecipientsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ManageRecipientsToolStripMenuItem.Text = "Manage recipients"
        Me.ManageRecipientsToolStripMenuItem.ToolTipText = "Manage export recipient details."
        '
        'ManageExportHistoryToolStripMenuItem
        '
        Me.ManageExportHistoryToolStripMenuItem.Name = "ManageExportHistoryToolStripMenuItem"
        Me.ManageExportHistoryToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ManageExportHistoryToolStripMenuItem.Text = "Manage export history"
        Me.ManageExportHistoryToolStripMenuItem.ToolTipText = "Manage export history details."
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        Me.OptionsToolStripMenuItem.ToolTipText = "Manage Gilbert 21 options"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        Me.AboutToolStripMenuItem.ToolTipText = "See information on version etc."
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        Me.HelpToolStripMenuItem1.ToolTipText = "Invoke the web-based help."
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabRecords)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 52)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(737, 360)
        Me.TabControl1.TabIndex = 9
        '
        'tabRecords
        '
        Me.tabRecords.Controls.Add(Me.lblInputFile)
        Me.tabRecords.Controls.Add(Me.lblDatabase)
        Me.tabRecords.Controls.Add(Me.pbLoad)
        Me.tabRecords.Controls.Add(Me.dgvRecords)
        Me.tabRecords.Location = New System.Drawing.Point(4, 22)
        Me.tabRecords.Name = "tabRecords"
        Me.tabRecords.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRecords.Size = New System.Drawing.Size(729, 334)
        Me.tabRecords.TabIndex = 1
        Me.tabRecords.Text = "Records"
        Me.tabRecords.UseVisualStyleBackColor = True
        '
        'lblInputFile
        '
        Me.lblInputFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInputFile.AutoSize = True
        Me.lblInputFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputFile.Location = New System.Drawing.Point(479, 298)
        Me.lblInputFile.Name = "lblInputFile"
        Me.lblInputFile.Size = New System.Drawing.Size(57, 13)
        Me.lblInputFile.TabIndex = 3
        Me.lblInputFile.Text = "Input file"
        '
        'lblDatabase
        '
        Me.lblDatabase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabase.Location = New System.Drawing.Point(3, 318)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(61, 13)
        Me.lblDatabase.TabIndex = 2
        Me.lblDatabase.Text = "Database"
        '
        'pbLoad
        '
        Me.pbLoad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoad.Location = New System.Drawing.Point(0, 295)
        Me.pbLoad.Name = "pbLoad"
        Me.pbLoad.Size = New System.Drawing.Size(476, 20)
        Me.pbLoad.TabIndex = 1
        '
        'dgvRecords
        '
        Me.dgvRecords.AllowUserToAddRows = False
        Me.dgvRecords.AllowUserToDeleteRows = False
        Me.dgvRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecords.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvRecords.EnableHeadersVisualStyles = False
        Me.dgvRecords.Location = New System.Drawing.Point(0, 3)
        Me.dgvRecords.Name = "dgvRecords"
        Me.dgvRecords.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecords.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecords.Size = New System.Drawing.Size(729, 291)
        Me.dgvRecords.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.splitGraphs)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(729, 334)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Phenology"
        '
        'splitGraphs
        '
        Me.splitGraphs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitGraphs.BackColor = System.Drawing.Color.White
        Me.splitGraphs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitGraphs.Location = New System.Drawing.Point(0, 3)
        Me.splitGraphs.Name = "splitGraphs"
        Me.splitGraphs.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitGraphs.Panel1
        '
        Me.splitGraphs.Panel1.Controls.Add(Me.Panel1)
        Me.splitGraphs.Panel1.Controls.Add(Me.nudMaxYear)
        Me.splitGraphs.Panel1.Controls.Add(Me.nudMinYear)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label6)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbChartColours)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label5)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbChartType)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label4)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label3)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbEqualiseYaxes)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbRemoveEmptyGraphs)
        Me.splitGraphs.Panel1.Controls.Add(Me.butBlind)
        Me.splitGraphs.Panel1.Controls.Add(Me.rbSumAbundances)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbSuperimpose)
        Me.splitGraphs.Panel1.Controls.Add(Me.nudDayGrp)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label2)
        Me.splitGraphs.Panel1.Controls.Add(Me.rbCountRecs)
        Me.splitGraphs.Panel1.Controls.Add(Me.Label1)
        Me.splitGraphs.Panel1.Controls.Add(Me.cbYearsPerGraph)
        '
        'splitGraphs.Panel2
        '
        Me.splitGraphs.Panel2.Controls.Add(Me.Chart1)
        Me.splitGraphs.Size = New System.Drawing.Size(726, 328)
        Me.splitGraphs.SplitterDistance = 106
        Me.splitGraphs.SplitterWidth = 3
        Me.splitGraphs.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkCommon)
        Me.Panel1.Controls.Add(Me.rbYear)
        Me.Panel1.Controls.Add(Me.rbSpecies)
        Me.Panel1.Location = New System.Drawing.Point(361, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 22)
        Me.Panel1.TabIndex = 321
        '
        'chkCommon
        '
        Me.chkCommon.AutoSize = True
        Me.chkCommon.Location = New System.Drawing.Point(163, 3)
        Me.chkCommon.Name = "chkCommon"
        Me.chkCommon.Size = New System.Drawing.Size(117, 17)
        Me.chkCommon.TabIndex = 241
        Me.chkCommon.Text = "Use common name"
        Me.tt.SetToolTip(Me.chkCommon, "To superimpose different series in a single graph" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tick this box. Otherwise each " & _
        "series will apear in" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a separate graph.")
        Me.chkCommon.UseVisualStyleBackColor = True
        '
        'rbYear
        '
        Me.rbYear.AutoSize = True
        Me.rbYear.Checked = True
        Me.rbYear.Location = New System.Drawing.Point(3, 2)
        Me.rbYear.Name = "rbYear"
        Me.rbYear.Size = New System.Drawing.Size(60, 17)
        Me.rbYear.TabIndex = 1
        Me.rbYear.TabStop = True
        Me.rbYear.Text = "By year"
        Me.rbYear.UseVisualStyleBackColor = True
        '
        'rbSpecies
        '
        Me.rbSpecies.AutoSize = True
        Me.rbSpecies.Location = New System.Drawing.Point(69, 2)
        Me.rbSpecies.Name = "rbSpecies"
        Me.rbSpecies.Size = New System.Drawing.Size(76, 17)
        Me.rbSpecies.TabIndex = 0
        Me.rbSpecies.Text = "By species"
        Me.rbSpecies.UseVisualStyleBackColor = True
        '
        'nudMaxYear
        '
        Me.nudMaxYear.Location = New System.Drawing.Point(173, 64)
        Me.nudMaxYear.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudMaxYear.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.nudMaxYear.Name = "nudMaxYear"
        Me.nudMaxYear.Size = New System.Drawing.Size(50, 20)
        Me.nudMaxYear.TabIndex = 280
        Me.tt.SetToolTip(Me.nudMaxYear, "Use this control to set a maximum year filter for the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records - records occuring" & _
        " after this year will not be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "included in the graphs.")
        Me.nudMaxYear.Value = New Decimal(New Integer() {1700, 0, 0, 0})
        '
        'nudMinYear
        '
        Me.nudMinYear.Location = New System.Drawing.Point(57, 64)
        Me.nudMinYear.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudMinYear.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.nudMinYear.Name = "nudMinYear"
        Me.nudMinYear.Size = New System.Drawing.Size(50, 20)
        Me.nudMinYear.TabIndex = 270
        Me.tt.SetToolTip(Me.nudMinYear, "Use this control to set a minimum year filter for the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records - records earlier " & _
        "than this year will not be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "included in the graphs.")
        Me.nudMinYear.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Year min:"
        '
        'cbChartColours
        '
        Me.cbChartColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChartColours.FormattingEnabled = True
        Me.cbChartColours.Items.AddRange(New Object() {"Berry", "Excel", "Pastel", "Bright Pastel", "Earth Tones", "Chocolate", "Fire", "Sea Green", "Bright"})
        Me.cbChartColours.Location = New System.Drawing.Point(435, 63)
        Me.cbChartColours.Name = "cbChartColours"
        Me.cbChartColours.Size = New System.Drawing.Size(89, 21)
        Me.cbChartColours.TabIndex = 310
        Me.tt.SetToolTip(Me.cbChartColours, "Select a colour scheme for the charts.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Colours:"
        '
        'cbChartType
        '
        Me.cbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChartType.FormattingEnabled = True
        Me.cbChartType.Items.AddRange(New Object() {"Line chart", "Histogram"})
        Me.cbChartType.Location = New System.Drawing.Point(288, 63)
        Me.cbChartType.Name = "cbChartType"
        Me.cbChartType.Size = New System.Drawing.Size(89, 21)
        Me.cbChartType.TabIndex = 290
        Me.tt.SetToolTip(Me.cbChartType, "Select the chart style.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Year max:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Chart type:"
        '
        'cbEqualiseYaxes
        '
        Me.cbEqualiseYaxes.AutoSize = True
        Me.cbEqualiseYaxes.Checked = True
        Me.cbEqualiseYaxes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEqualiseYaxes.Location = New System.Drawing.Point(103, 35)
        Me.cbEqualiseYaxes.Name = "cbEqualiseYaxes"
        Me.cbEqualiseYaxes.Size = New System.Drawing.Size(101, 17)
        Me.cbEqualiseYaxes.TabIndex = 250
        Me.cbEqualiseYaxes.Text = "Equalise Y axes"
        Me.tt.SetToolTip(Me.cbEqualiseYaxes, "Tick this box to have all graphs shown with the same" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Y axis. If left untick, the" & _
        "n the Y axis of each graph will" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "be scaled to suit the data displayed.")
        Me.cbEqualiseYaxes.UseVisualStyleBackColor = True
        '
        'cbRemoveEmptyGraphs
        '
        Me.cbRemoveEmptyGraphs.AutoSize = True
        Me.cbRemoveEmptyGraphs.Checked = True
        Me.cbRemoveEmptyGraphs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRemoveEmptyGraphs.Location = New System.Drawing.Point(221, 35)
        Me.cbRemoveEmptyGraphs.Name = "cbRemoveEmptyGraphs"
        Me.cbRemoveEmptyGraphs.Size = New System.Drawing.Size(106, 17)
        Me.cbRemoveEmptyGraphs.TabIndex = 260
        Me.cbRemoveEmptyGraphs.Text = "No empty graphs"
        Me.tt.SetToolTip(Me.cbRemoveEmptyGraphs, "Tick this box if you wish to removes graphs with no" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records to be removed from t" & _
        "he display.")
        Me.cbRemoveEmptyGraphs.UseVisualStyleBackColor = True
        '
        'butBlind
        '
        Me.butBlind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBlind.ImageIndex = 0
        Me.butBlind.ImageList = Me.ImageList
        Me.butBlind.Location = New System.Drawing.Point(676, 74)
        Me.butBlind.Name = "butBlind"
        Me.butBlind.Size = New System.Drawing.Size(44, 27)
        Me.butBlind.TabIndex = 320
        Me.tt.SetToolTip(Me.butBlind, "Display/hide extra graphing options.")
        Me.butBlind.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "DownArrow")
        Me.ImageList.Images.SetKeyName(1, "UpArrow")
        '
        'rbSumAbundances
        '
        Me.rbSumAbundances.AutoSize = True
        Me.rbSumAbundances.Location = New System.Drawing.Point(103, 6)
        Me.rbSumAbundances.Name = "rbSumAbundances"
        Me.rbSumAbundances.Size = New System.Drawing.Size(108, 17)
        Me.rbSumAbundances.TabIndex = 210
        Me.rbSumAbundances.Text = "Sum abundances"
        Me.tt.SetToolTip(Me.rbSumAbundances, "Select this option to sum abundances.")
        Me.rbSumAbundances.UseVisualStyleBackColor = True
        '
        'cbSuperimpose
        '
        Me.cbSuperimpose.AutoSize = True
        Me.cbSuperimpose.Location = New System.Drawing.Point(7, 35)
        Me.cbSuperimpose.Name = "cbSuperimpose"
        Me.cbSuperimpose.Size = New System.Drawing.Size(87, 17)
        Me.cbSuperimpose.TabIndex = 240
        Me.cbSuperimpose.Text = "Superimpose"
        Me.tt.SetToolTip(Me.cbSuperimpose, "To superimpose different series in a single graph" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tick this box. Otherwise each " & _
        "series will apear in" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a separate graph.")
        Me.cbSuperimpose.UseVisualStyleBackColor = True
        '
        'nudDayGrp
        '
        Me.nudDayGrp.Location = New System.Drawing.Point(473, 6)
        Me.nudDayGrp.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudDayGrp.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDayGrp.Name = "nudDayGrp"
        Me.nudDayGrp.Size = New System.Drawing.Size(50, 20)
        Me.nudDayGrp.TabIndex = 230
        Me.tt.SetToolTip(Me.nudDayGrp, "Indicate how many days there will be for each" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "data point - in other words the cl" & _
        "ass size.")
        Me.nudDayGrp.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(389, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Days per point:"
        '
        'rbCountRecs
        '
        Me.rbCountRecs.AutoSize = True
        Me.rbCountRecs.Checked = True
        Me.rbCountRecs.Location = New System.Drawing.Point(6, 6)
        Me.rbCountRecs.Name = "rbCountRecs"
        Me.rbCountRecs.Size = New System.Drawing.Size(91, 17)
        Me.rbCountRecs.TabIndex = 200
        Me.rbCountRecs.TabStop = True
        Me.rbCountRecs.Text = "Count records"
        Me.tt.SetToolTip(Me.rbCountRecs, "Select this option to count the number of records.")
        Me.rbCountRecs.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(229, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Years per graph:"
        '
        'cbYearsPerGraph
        '
        Me.cbYearsPerGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearsPerGraph.FormattingEnabled = True
        Me.cbYearsPerGraph.Items.AddRange(New Object() {"All", "10", "5", "4", "3", "2", "1"})
        Me.cbYearsPerGraph.Location = New System.Drawing.Point(320, 5)
        Me.cbYearsPerGraph.Name = "cbYearsPerGraph"
        Me.cbYearsPerGraph.Size = New System.Drawing.Size(50, 21)
        Me.cbYearsPerGraph.TabIndex = 220
        Me.tt.SetToolTip(Me.cbYearsPerGraph, "Indicate how you want to group years.")
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.None
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        StripLine1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StripLine1.StripWidth = 10.0R
        StripLine2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        StripLine2.IntervalOffset = 10.0R
        StripLine2.StripWidth = 15.0R
        StripLine2.Text = "Feb"
        StripLine2.TextAlignment = System.Drawing.StringAlignment.Center
        ChartArea1.AxisX.StripLines.Add(StripLine1)
        ChartArea1.AxisX.StripLines.Add(StripLine2)
        ChartArea1.AxisY.LineColor = System.Drawing.Color.Transparent
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.DockedToChartArea = "ChartArea1"
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(50, 19)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Series1.BorderColor = System.Drawing.Color.Black
        Series1.BorderWidth = 0
        Series1.ChartArea = "ChartArea1"
        Series1.CustomProperties = "DrawingStyle=Cylinder, PointWidth=1"
        Series1.Legend = "Legend1"
        Series1.MarkerBorderColor = System.Drawing.Color.Black
        Series1.MarkerSize = 12
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond
        Series1.Name = "Series1"
        DataPoint1.LabelBorderWidth = 1
        DataPoint1.MarkerBorderWidth = 1
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series1.Points.Add(DataPoint4)
        Series1.Points.Add(DataPoint5)
        Series1.Points.Add(DataPoint6)
        Series1.YValuesPerPoint = 6
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(608, 201)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDelete, Me.tsbRemove, Me.tsbValidate, Me.tsbCopy, Me.tsbNew, Me.ToolStripSeparator1, Me.tsbAddHashCode, Me.tscbHash, Me.ToolStripSeparator4, Me.tsbPlaySound, Me.tsbMergeWAV, Me.tsbDeleteWAV, Me.ToolStripSeparator2, Me.tsbManageLocation, Me.tsbManageTaxa, Me.ToolStripSeparator3, Me.tsbGE, Me.ToolStripSeparator5, Me.tsbOptions, Me.ToolStripSeparator7, Me.tsbMoveDeleteFiles})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(737, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsbDelete.Text = "Delete Record"
        Me.tsbDelete.ToolTipText = "Delete Record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Delete the selected record(s)."
        '
        'tsbRemove
        '
        Me.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRemove.Image = CType(resources.GetObject("tsbRemove.Image"), System.Drawing.Image)
        Me.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemove.Name = "tsbRemove"
        Me.tsbRemove.Size = New System.Drawing.Size(23, 22)
        Me.tsbRemove.Text = "Remove record"
        Me.tsbRemove.ToolTipText = "Remove record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Remove the record from those presented, but" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "do not delete from t" & _
    "he database."
        '
        'tsbValidate
        '
        Me.tsbValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbValidate.Image = CType(resources.GetObject("tsbValidate.Image"), System.Drawing.Image)
        Me.tsbValidate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbValidate.Name = "tsbValidate"
        Me.tsbValidate.Size = New System.Drawing.Size(23, 22)
        Me.tsbValidate.Text = "Validate record"
        Me.tsbValidate.ToolTipText = "Validate record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Validates the selected record and indicates any" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "errors found i" & _
    "n a message box."
        '
        'tsbCopy
        '
        Me.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCopy.Image = CType(resources.GetObject("tsbCopy.Image"), System.Drawing.Image)
        Me.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCopy.Name = "tsbCopy"
        Me.tsbCopy.Size = New System.Drawing.Size(23, 22)
        Me.tsbCopy.Text = "Copy Record"
        Me.tsbCopy.ToolTipText = "Copy Record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copy the selected record. All fields from the selected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "record will" & _
    " be copied except those speciefied in the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "'clear on copy' list in the options d" & _
    "ialog."
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbNew.Text = "Create new record"
        Me.tsbNew.ToolTipText = "Create new record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Creates a new record - based on the selected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "shortcut templa" & _
    "te if one is selected."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbAddHashCode
        '
        Me.tsbAddHashCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddHashCode.Image = CType(resources.GetObject("tsbAddHashCode.Image"), System.Drawing.Image)
        Me.tsbAddHashCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddHashCode.Name = "tsbAddHashCode"
        Me.tsbAddHashCode.Size = New System.Drawing.Size(23, 22)
        Me.tsbAddHashCode.Tag = "Use this toolbutton to invoke the hash code dialog from where you can define data" & _
    " entry shortcuts."
        Me.tsbAddHashCode.Text = "Add hash code"
        Me.tsbAddHashCode.ToolTipText = "Manage shortcuts." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invokes a dialog from which shortcuts" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "can be added or deleted" & _
    "."
        '
        'tscbHash
        '
        Me.tscbHash.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tscbHash.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tscbHash.Name = "tscbHash"
        Me.tscbHash.Size = New System.Drawing.Size(100, 25)
        Me.tscbHash.ToolTipText = "Select a shortcut." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The selected shortcut will be used as a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "template when new r" & _
    "ecords are created."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPlaySound
        '
        Me.tsbPlaySound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPlaySound.Image = CType(resources.GetObject("tsbPlaySound.Image"), System.Drawing.Image)
        Me.tsbPlaySound.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPlaySound.Name = "tsbPlaySound"
        Me.tsbPlaySound.Size = New System.Drawing.Size(23, 22)
        Me.tsbPlaySound.Text = "Play sound"
        Me.tsbPlaySound.ToolTipText = "Play sound." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Play the sound associated with the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected record."
        '
        'tsbMergeWAV
        '
        Me.tsbMergeWAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMergeWAV.Image = CType(resources.GetObject("tsbMergeWAV.Image"), System.Drawing.Image)
        Me.tsbMergeWAV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMergeWAV.Name = "tsbMergeWAV"
        Me.tsbMergeWAV.Size = New System.Drawing.Size(23, 22)
        Me.tsbMergeWAV.Text = "Merge sounds"
        Me.tsbMergeWAV.ToolTipText = "Merge sound." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Merge the sounds of two or more selected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records and assigned the " & _
    "new merged sound" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the first selected record."
        '
        'tsbDeleteWAV
        '
        Me.tsbDeleteWAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDeleteWAV.Image = CType(resources.GetObject("tsbDeleteWAV.Image"), System.Drawing.Image)
        Me.tsbDeleteWAV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteWAV.Name = "tsbDeleteWAV"
        Me.tsbDeleteWAV.Size = New System.Drawing.Size(23, 22)
        Me.tsbDeleteWAV.Text = "Remove sound"
        Me.tsbDeleteWAV.ToolTipText = "Remove sound." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Completely remove the sound associated" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "with a record."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbManageLocation
        '
        Me.tsbManageLocation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbManageLocation.Image = CType(resources.GetObject("tsbManageLocation.Image"), System.Drawing.Image)
        Me.tsbManageLocation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbManageLocation.Name = "tsbManageLocation"
        Me.tsbManageLocation.Size = New System.Drawing.Size(23, 22)
        Me.tsbManageLocation.Text = "Manage locations"
        Me.tsbManageLocation.ToolTipText = "Manage the locations gazetteer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invokes a dialog from which you can manage the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
    "locations gazetteer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tsbManageTaxa
        '
        Me.tsbManageTaxa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbManageTaxa.Image = CType(resources.GetObject("tsbManageTaxa.Image"), System.Drawing.Image)
        Me.tsbManageTaxa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbManageTaxa.Name = "tsbManageTaxa"
        Me.tsbManageTaxa.Size = New System.Drawing.Size(23, 22)
        Me.tsbManageTaxa.Text = "Manage taxon dictionary"
        Me.tsbManageTaxa.ToolTipText = "Manage the taxon dictionary." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invokes a dialog from which you can manage the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "'co" & _
    "nvenience' taxon dictionary."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbGE
        '
        Me.tsbGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbGE.Image = CType(resources.GetObject("tsbGE.Image"), System.Drawing.Image)
        Me.tsbGE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGE.Name = "tsbGE"
        Me.tsbGE.Size = New System.Drawing.Size(23, 22)
        Me.tsbGE.Text = "Google Earth View"
        Me.tsbGE.ToolTipText = "Google Earth View." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quick view of currently open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records in Google Earth."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbOptions
        '
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOptions.Image = CType(resources.GetObject("tsbOptions.Image"), System.Drawing.Image)
        Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptions.Name = "tsbOptions"
        Me.tsbOptions.Size = New System.Drawing.Size(23, 22)
        Me.tsbOptions.Text = "Options"
        Me.tsbOptions.ToolTipText = "Manage the applications options." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invokes a dialog from where you can" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "manage var" & _
    "ious options."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMoveDeleteFiles
        '
        Me.tsbMoveDeleteFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMoveDeleteFiles.Image = CType(resources.GetObject("tsbMoveDeleteFiles.Image"), System.Drawing.Image)
        Me.tsbMoveDeleteFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMoveDeleteFiles.Name = "tsbMoveDeleteFiles"
        Me.tsbMoveDeleteFiles.Size = New System.Drawing.Size(23, 22)
        Me.tsbMoveDeleteFiles.Text = "Move/delete G21 App sound files"
        Me.tsbMoveDeleteFiles.ToolTipText = "Move/delete G21 App sound files associated with" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "open records."
        '
        'G21Notify
        '
        Me.G21Notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.G21Notify.Icon = CType(resources.GetObject("G21Notify.Icon"), System.Drawing.Icon)
        Me.G21Notify.Text = "Gilbert 21"
        Me.G21Notify.Visible = True
        '
        'timNotify
        '
        Me.timNotify.Enabled = True
        Me.timNotify.Interval = 1800000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 413)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "The Gilbert 21 Project"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabRecords.ResumeLayout(False)
        Me.tabRecords.PerformLayout()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.splitGraphs.Panel1.ResumeLayout(False)
        Me.splitGraphs.Panel1.PerformLayout()
        Me.splitGraphs.Panel2.ResumeLayout(False)
        CType(Me.splitGraphs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitGraphs.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudMaxYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDayGrp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabRecords As System.Windows.Forms.TabPage
    Friend WithEvents dgvRecords As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbValidate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMergeWAV As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeleteWAV As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPlaySound As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbManageLocation As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbManageTaxa As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAddHashCode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClearRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tscbHash As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DBConversionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGE As System.Windows.Forms.ToolStripButton
    Friend WithEvents Version1To2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopulateTracksTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadGazetteerFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateEmptyDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LegacyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Version10To11ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenByFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetLocationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenEvernoteNotebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbLoad As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents lblInputFile As System.Windows.Forms.Label
    Friend WithEvents ExportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageRecipientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageExportHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents nudDayGrp As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbSumAbundances As System.Windows.Forms.RadioButton
    Friend WithEvents rbCountRecs As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbYearsPerGraph As System.Windows.Forms.ComboBox
    Friend WithEvents cbSuperimpose As System.Windows.Forms.CheckBox
    Friend WithEvents splitGraphs As System.Windows.Forms.SplitContainer
    Friend WithEvents butBlind As System.Windows.Forms.Button
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents cbRemoveEmptyGraphs As System.Windows.Forms.CheckBox
    Friend WithEvents cbEqualiseYaxes As System.Windows.Forms.CheckBox
    Friend WithEvents cbChartType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbChartColours As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudMaxYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMinYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbYear As System.Windows.Forms.RadioButton
    Friend WithEvents rbSpecies As System.Windows.Forms.RadioButton
    Friend WithEvents chkCommon As System.Windows.Forms.CheckBox
    Friend WithEvents G21Notify As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitGilbert21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timNotify As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbMoveDeleteFiles As System.Windows.Forms.ToolStripButton

End Class
