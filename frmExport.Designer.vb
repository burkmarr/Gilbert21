<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExport))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbSelectedRecords = New System.Windows.Forms.RadioButton()
        Me.rbAllRecords = New System.Windows.Forms.RadioButton()
        Me.cbBiologicalRecords = New System.Windows.Forms.CheckBox()
        Me.cbInvalidRecords = New System.Windows.Forms.CheckBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butCommit = New System.Windows.Forms.Button()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.nudTrackInterval = New System.Windows.Forms.NumericUpDown()
        Me.cbEastingNorthing = New System.Windows.Forms.CheckBox()
        Me.chkBoxAppendGUID = New System.Windows.Forms.CheckBox()
        Me.chkIncludeGUID = New System.Windows.Forms.CheckBox()
        Me.rbNoGPSTracks = New System.Windows.Forms.RadioButton()
        Me.rbAllGPSTracks = New System.Windows.Forms.RadioButton()
        Me.cbIncludeExcluded = New System.Windows.Forms.CheckBox()
        Me.butRemoveRecipient = New System.Windows.Forms.Button()
        Me.butAddRecipient = New System.Windows.Forms.Button()
        Me.lbExportRecipients = New System.Windows.Forms.ListBox()
        Me.txtExportTitle = New System.Windows.Forms.TextBox()
        Me.txtExportNotes = New System.Windows.Forms.TextBox()
        Me.ddlExportType = New System.Windows.Forms.ComboBox()
        Me.nudTrackThickness = New System.Windows.Forms.NumericUpDown()
        Me.cbAtlasLayers = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTrackThickness = New System.Windows.Forms.Label()
        Me.lblTrackInterval2 = New System.Windows.Forms.Label()
        Me.lblTrackInterval1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.nudTrackInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTrackThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbSelectedRecords)
        Me.Panel2.Controls.Add(Me.rbAllRecords)
        Me.Panel2.Location = New System.Drawing.Point(8, 8)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(363, 40)
        Me.Panel2.TabIndex = 3
        '
        'rbSelectedRecords
        '
        Me.rbSelectedRecords.AutoSize = True
        Me.rbSelectedRecords.Location = New System.Drawing.Point(132, 5)
        Me.rbSelectedRecords.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbSelectedRecords.Name = "rbSelectedRecords"
        Me.rbSelectedRecords.Size = New System.Drawing.Size(186, 24)
        Me.rbSelectedRecords.TabIndex = 3
        Me.rbSelectedRecords.TabStop = True
        Me.rbSelectedRecords.Text = "Selected records only"
        Me.tt.SetToolTip(Me.rbSelectedRecords, "Select this option to export only selected records.")
        Me.rbSelectedRecords.UseVisualStyleBackColor = True
        '
        'rbAllRecords
        '
        Me.rbAllRecords.AutoSize = True
        Me.rbAllRecords.Checked = True
        Me.rbAllRecords.Location = New System.Drawing.Point(4, 5)
        Me.rbAllRecords.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbAllRecords.Name = "rbAllRecords"
        Me.rbAllRecords.Size = New System.Drawing.Size(108, 24)
        Me.rbAllRecords.TabIndex = 2
        Me.rbAllRecords.TabStop = True
        Me.rbAllRecords.Text = "All records"
        Me.tt.SetToolTip(Me.rbAllRecords, "Select this option to export all displayed records.")
        Me.rbAllRecords.UseVisualStyleBackColor = True
        '
        'cbBiologicalRecords
        '
        Me.cbBiologicalRecords.AutoSize = True
        Me.cbBiologicalRecords.Checked = True
        Me.cbBiologicalRecords.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBiologicalRecords.Location = New System.Drawing.Point(12, 57)
        Me.cbBiologicalRecords.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbBiologicalRecords.Name = "cbBiologicalRecords"
        Me.cbBiologicalRecords.Size = New System.Drawing.Size(294, 24)
        Me.cbBiologicalRecords.TabIndex = 4
        Me.cbBiologicalRecords.Text = "Include valid saved biological records"
        Me.tt.SetToolTip(Me.cbBiologicalRecords, "Check this box to include all valid, saved biological" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records in the export.")
        Me.cbBiologicalRecords.UseVisualStyleBackColor = True
        '
        'cbInvalidRecords
        '
        Me.cbInvalidRecords.AutoSize = True
        Me.cbInvalidRecords.Location = New System.Drawing.Point(12, 91)
        Me.cbInvalidRecords.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbInvalidRecords.Name = "cbInvalidRecords"
        Me.cbInvalidRecords.Size = New System.Drawing.Size(454, 24)
        Me.cbInvalidRecords.TabIndex = 6
        Me.cbInvalidRecords.Text = "Include all modified or unsaved records, whether valid or not"
        Me.tt.SetToolTip(Me.cbInvalidRecords, "Check this box to include all modified" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "or unsaved records, whether or not" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "they " &
        "are valid, in the export.")
        Me.cbInvalidRecords.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(572, 443)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(100, 35)
        Me.butCancel.TabIndex = 100
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butCommit
        '
        Me.butCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCommit.Location = New System.Drawing.Point(681, 443)
        Me.butCommit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butCommit.Name = "butCommit"
        Me.butCommit.Size = New System.Drawing.Size(100, 35)
        Me.butCommit.TabIndex = 99
        Me.butCommit.Text = "OK"
        Me.butCommit.UseVisualStyleBackColor = True
        '
        'nudTrackInterval
        '
        Me.nudTrackInterval.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTrackInterval.Location = New System.Drawing.Point(138, 72)
        Me.nudTrackInterval.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudTrackInterval.Name = "nudTrackInterval"
        Me.nudTrackInterval.Size = New System.Drawing.Size(58, 26)
        Me.nudTrackInterval.TabIndex = 9
        Me.tt.SetToolTip(Me.nudTrackInterval, "This is useful for thining out the number" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of points shown on a track - the highe" &
        "r" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the number, the fewer points are shown.")
        '
        'cbEastingNorthing
        '
        Me.cbEastingNorthing.AutoSize = True
        Me.cbEastingNorthing.Checked = True
        Me.cbEastingNorthing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEastingNorthing.Location = New System.Drawing.Point(15, 29)
        Me.cbEastingNorthing.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbEastingNorthing.Name = "cbEastingNorthing"
        Me.cbEastingNorthing.Size = New System.Drawing.Size(252, 24)
        Me.cbEastingNorthing.TabIndex = 5
        Me.cbEastingNorthing.Text = "Include eastings and northings"
        Me.tt.SetToolTip(Me.cbEastingNorthing, "This can be useful if you are exporting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a CSV to someone who wants to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "import in" &
        "to GIS.")
        Me.cbEastingNorthing.UseVisualStyleBackColor = True
        '
        'chkBoxAppendGUID
        '
        Me.chkBoxAppendGUID.AutoSize = True
        Me.chkBoxAppendGUID.Location = New System.Drawing.Point(176, 29)
        Me.chkBoxAppendGUID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkBoxAppendGUID.Name = "chkBoxAppendGUID"
        Me.chkBoxAppendGUID.Size = New System.Drawing.Size(225, 24)
        Me.chkBoxAppendGUID.TabIndex = 3
        Me.chkBoxAppendGUID.Text = "Append GUID to comment"
        Me.tt.SetToolTip(Me.chkBoxAppendGUID, "This can be useful if you are exporting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a CSV to someone who wants to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "import in" &
        "to GIS.")
        Me.chkBoxAppendGUID.UseVisualStyleBackColor = True
        '
        'chkIncludeGUID
        '
        Me.chkIncludeGUID.AutoSize = True
        Me.chkIncludeGUID.Checked = True
        Me.chkIncludeGUID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeGUID.Location = New System.Drawing.Point(15, 29)
        Me.chkIncludeGUID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkIncludeGUID.Name = "chkIncludeGUID"
        Me.chkIncludeGUID.Size = New System.Drawing.Size(133, 24)
        Me.chkIncludeGUID.TabIndex = 2
        Me.chkIncludeGUID.Text = "Include GUID"
        Me.tt.SetToolTip(Me.chkIncludeGUID, "This can be useful if you are exporting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a CSV to someone who wants to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "import in" &
        "to GIS.")
        Me.chkIncludeGUID.UseVisualStyleBackColor = True
        '
        'rbNoGPSTracks
        '
        Me.rbNoGPSTracks.AutoSize = True
        Me.rbNoGPSTracks.Checked = True
        Me.rbNoGPSTracks.Location = New System.Drawing.Point(15, 29)
        Me.rbNoGPSTracks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbNoGPSTracks.Name = "rbNoGPSTracks"
        Me.rbNoGPSTracks.Size = New System.Drawing.Size(139, 24)
        Me.rbNoGPSTracks.TabIndex = 7
        Me.rbNoGPSTracks.TabStop = True
        Me.rbNoGPSTracks.Text = "No GPS tracks"
        Me.tt.SetToolTip(Me.rbNoGPSTracks, "Select this option if you do not want to include" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tracks in the Google Earth KML " &
        "file.")
        Me.rbNoGPSTracks.UseVisualStyleBackColor = True
        '
        'rbAllGPSTracks
        '
        Me.rbAllGPSTracks.AutoSize = True
        Me.rbAllGPSTracks.Location = New System.Drawing.Point(176, 29)
        Me.rbAllGPSTracks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbAllGPSTracks.Name = "rbAllGPSTracks"
        Me.rbAllGPSTracks.Size = New System.Drawing.Size(159, 24)
        Me.rbAllGPSTracks.TabIndex = 8
        Me.rbAllGPSTracks.Text = "Show GPS tracks"
        Me.tt.SetToolTip(Me.rbAllGPSTracks, "Select this option if you want to include tracks" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the Google Earth KML file.")
        Me.rbAllGPSTracks.UseVisualStyleBackColor = True
        '
        'cbIncludeExcluded
        '
        Me.cbIncludeExcluded.AutoSize = True
        Me.cbIncludeExcluded.Location = New System.Drawing.Point(12, 126)
        Me.cbIncludeExcluded.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbIncludeExcluded.Name = "cbIncludeExcluded"
        Me.cbIncludeExcluded.Size = New System.Drawing.Size(343, 24)
        Me.cbIncludeExcluded.TabIndex = 12
        Me.cbIncludeExcluded.Text = "Include records even if marked for exclusion"
        Me.tt.SetToolTip(Me.cbIncludeExcluded, "Check this box to override the 'exclude record from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "export' option if set on ind" &
        "ividual records in those" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "which are candidates for export.")
        Me.cbIncludeExcluded.UseVisualStyleBackColor = True
        '
        'butRemoveRecipient
        '
        Me.butRemoveRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRemoveRecipient.Location = New System.Drawing.Point(652, 305)
        Me.butRemoveRecipient.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butRemoveRecipient.Name = "butRemoveRecipient"
        Me.butRemoveRecipient.Size = New System.Drawing.Size(100, 35)
        Me.butRemoveRecipient.TabIndex = 6
        Me.butRemoveRecipient.Text = "Remove"
        Me.tt.SetToolTip(Me.butRemoveRecipient, "Remove selected recipient from list of recipients" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for this export.")
        Me.butRemoveRecipient.UseVisualStyleBackColor = True
        '
        'butAddRecipient
        '
        Me.butAddRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddRecipient.Location = New System.Drawing.Point(652, 263)
        Me.butAddRecipient.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butAddRecipient.Name = "butAddRecipient"
        Me.butAddRecipient.Size = New System.Drawing.Size(100, 35)
        Me.butAddRecipient.TabIndex = 5
        Me.butAddRecipient.Text = "Add"
        Me.tt.SetToolTip(Me.butAddRecipient, "Click this button to invoke recipient selection dialog.")
        Me.butAddRecipient.UseVisualStyleBackColor = True
        '
        'lbExportRecipients
        '
        Me.lbExportRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbExportRecipients.FormattingEnabled = True
        Me.lbExportRecipients.ItemHeight = 20
        Me.lbExportRecipients.Location = New System.Drawing.Point(122, 263)
        Me.lbExportRecipients.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbExportRecipients.Name = "lbExportRecipients"
        Me.lbExportRecipients.Size = New System.Drawing.Size(520, 124)
        Me.lbExportRecipients.TabIndex = 4
        Me.tt.SetToolTip(Me.lbExportRecipients, "Optionally indicate the recipients for this export.")
        '
        'txtExportTitle
        '
        Me.txtExportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportTitle.Location = New System.Drawing.Point(123, 54)
        Me.txtExportTitle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtExportTitle.Name = "txtExportTitle"
        Me.txtExportTitle.Size = New System.Drawing.Size(628, 26)
        Me.txtExportTitle.TabIndex = 2
        Me.tt.SetToolTip(Me.txtExportTitle, "Specify a short title for the export.")
        '
        'txtExportNotes
        '
        Me.txtExportNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportNotes.Location = New System.Drawing.Point(122, 95)
        Me.txtExportNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtExportNotes.Multiline = True
        Me.txtExportNotes.Name = "txtExportNotes"
        Me.txtExportNotes.Size = New System.Drawing.Size(631, 156)
        Me.txtExportNotes.TabIndex = 3
        Me.tt.SetToolTip(Me.txtExportNotes, "Optionally specify notes for this export.")
        '
        'ddlExportType
        '
        Me.ddlExportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlExportType.FormattingEnabled = True
        Me.ddlExportType.Items.AddRange(New Object() {"CSV", "iRecord", "iNaturalist", "MapMate", "Google Earth", "MapInfo", "RODIS", "BirdTrack Casual", "None"})
        Me.ddlExportType.Location = New System.Drawing.Point(122, 9)
        Me.ddlExportType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ddlExportType.Name = "ddlExportType"
        Me.ddlExportType.Size = New System.Drawing.Size(630, 28)
        Me.ddlExportType.TabIndex = 1
        Me.tt.SetToolTip(Me.ddlExportType, "Select an export format.")
        '
        'nudTrackThickness
        '
        Me.nudTrackThickness.Location = New System.Drawing.Point(138, 118)
        Me.nudTrackThickness.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudTrackThickness.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTrackThickness.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTrackThickness.Name = "nudTrackThickness"
        Me.nudTrackThickness.Size = New System.Drawing.Size(58, 26)
        Me.nudTrackThickness.TabIndex = 11
        Me.tt.SetToolTip(Me.nudTrackThickness, "Specify a thickness (in pixels) for the tracks.")
        Me.nudTrackThickness.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'cbAtlasLayers
        '
        Me.cbAtlasLayers.AutoSize = True
        Me.cbAtlasLayers.Checked = True
        Me.cbAtlasLayers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAtlasLayers.Location = New System.Drawing.Point(15, 162)
        Me.cbAtlasLayers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbAtlasLayers.Name = "cbAtlasLayers"
        Me.cbAtlasLayers.Size = New System.Drawing.Size(170, 24)
        Me.cbAtlasLayers.TabIndex = 12
        Me.cbAtlasLayers.Text = "Include atlas layers"
        Me.tt.SetToolTip(Me.cbAtlasLayers, "If this box is checked, then your Google Earth file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will include distribution of" &
        " your exported records" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "summarised at hectad, tetrad and monad levels.")
        Me.cbAtlasLayers.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbAtlasLayers)
        Me.GroupBox1.Controls.Add(Me.rbNoGPSTracks)
        Me.GroupBox1.Controls.Add(Me.rbAllGPSTracks)
        Me.GroupBox1.Controls.Add(Me.lblTrackThickness)
        Me.GroupBox1.Controls.Add(Me.nudTrackThickness)
        Me.GroupBox1.Controls.Add(Me.lblTrackInterval2)
        Me.GroupBox1.Controls.Add(Me.lblTrackInterval1)
        Me.GroupBox1.Controls.Add(Me.nudTrackInterval)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 157)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(748, 231)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Google Earth export options"
        '
        'lblTrackThickness
        '
        Me.lblTrackThickness.AutoSize = True
        Me.lblTrackThickness.Location = New System.Drawing.Point(10, 122)
        Me.lblTrackThickness.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackThickness.Name = "lblTrackThickness"
        Me.lblTrackThickness.Size = New System.Drawing.Size(119, 20)
        Me.lblTrackThickness.TabIndex = 13
        Me.lblTrackThickness.Text = "Track thickness"
        '
        'lblTrackInterval2
        '
        Me.lblTrackInterval2.AutoSize = True
        Me.lblTrackInterval2.Location = New System.Drawing.Point(206, 75)
        Me.lblTrackInterval2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackInterval2.Name = "lblTrackInterval2"
        Me.lblTrackInterval2.Size = New System.Drawing.Size(105, 20)
        Me.lblTrackInterval2.TabIndex = 10
        Me.lblTrackInterval2.Text = "point on track"
        '
        'lblTrackInterval1
        '
        Me.lblTrackInterval1.AutoSize = True
        Me.lblTrackInterval1.Location = New System.Drawing.Point(45, 75)
        Me.lblTrackInterval1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackInterval1.Name = "lblTrackInterval1"
        Me.lblTrackInterval1.Size = New System.Drawing.Size(85, 20)
        Me.lblTrackInterval1.TabIndex = 9
        Me.lblTrackInterval1.Text = "Mark every"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbEastingNorthing)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 83)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(748, 68)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CSV export options"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 5)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 437)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.butRemoveRecipient)
        Me.TabPage1.Controls.Add(Me.butAddRecipient)
        Me.TabPage1.Controls.Add(Me.lbExportRecipients)
        Me.TabPage1.Controls.Add(Me.txtExportTitle)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtExportNotes)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ddlExportType)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(768, 404)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 263)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Recipients:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 57)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 20)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Short title:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Notes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Export format:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.cbInvalidRecords)
        Me.TabPage3.Controls.Add(Me.cbIncludeExcluded)
        Me.TabPage3.Controls.Add(Me.cbBiologicalRecords)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(768, 404)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Filters"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Size = New System.Drawing.Size(768, 404)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkIncludeGUID)
        Me.GroupBox3.Controls.Add(Me.chkBoxAppendGUID)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(748, 68)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "All formats"
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 483)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butCommit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export records"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudTrackInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTrackThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbSelectedRecords As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllRecords As System.Windows.Forms.RadioButton
    Friend WithEvents cbBiologicalRecords As System.Windows.Forms.CheckBox
    Friend WithEvents cbInvalidRecords As System.Windows.Forms.CheckBox
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butCommit As System.Windows.Forms.Button
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTrackInterval2 As System.Windows.Forms.Label
    Friend WithEvents lblTrackInterval1 As System.Windows.Forms.Label
    Friend WithEvents nudTrackInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTrackThickness As System.Windows.Forms.Label
    Friend WithEvents nudTrackThickness As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbAllGPSTracks As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoGPSTracks As System.Windows.Forms.RadioButton
    Friend WithEvents cbEastingNorthing As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbIncludeExcluded As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ddlExportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExportNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtExportTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbExportRecipients As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents butRemoveRecipient As System.Windows.Forms.Button
    Friend WithEvents butAddRecipient As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBoxAppendGUID As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeGUID As System.Windows.Forms.CheckBox
    Friend WithEvents cbAtlasLayers As System.Windows.Forms.CheckBox
End Class
