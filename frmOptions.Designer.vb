<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.butClose = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkDelete = New System.Windows.Forms.CheckBox()
        Me.butBrowseProcessedFolder = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtProcessedFiles = New System.Windows.Forms.TextBox()
        Me.chkWatchImport = New System.Windows.Forms.CheckBox()
        Me.chkGE = New System.Windows.Forms.CheckBox()
        Me.butBrowseDatabaseFolder = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDBFolder = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTaxonDictionaryFilter = New System.Windows.Forms.TextBox()
        Me.chkPlaySound = New System.Windows.Forms.CheckBox()
        Me.butBrowseDB = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.butBrowseExportFolder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtExportFolder = New System.Windows.Forms.TextBox()
        Me.butBrowseInputFolder = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtImportFolder = New System.Windows.Forms.TextBox()
        Me.clbClearFieldsOnCopy = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDeterminer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRecorder = New System.Windows.Forms.TextBox()
        Me.clbFields = New System.Windows.Forms.CheckedListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtBirdTrackUser = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtNBNUser = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtNBNPassword = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudFfplayDelay = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.butFfplayExe = New System.Windows.Forms.Button()
        Me.txtFfplayExe = New System.Windows.Forms.TextBox()
        Me.butEvernoteFolder = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEvernoteFolder = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEvernoteUser = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEvernotePassword = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.butStyleNoExportRec = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.butStyleModRec = New System.Windows.Forms.Button()
        Me.butStyleValidRec = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.butStyleOtherRec = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.butStyle2km = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.butStyle100km = New System.Windows.Forms.Button()
        Me.butStyleInvalid = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.butStyle10km = New System.Windows.Forms.Button()
        Me.butStyle1m = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.butStyle10m = New System.Windows.Forms.Button()
        Me.butStyle1km = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.butStyle100m = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.rbVisiontacAllTags = New System.Windows.Forms.RadioButton()
        Me.rbVistiotacVoiceTags = New System.Windows.Forms.RadioButton()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudFfplayDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(619, 391)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(67, 24)
        Me.butClose.TabIndex = 99
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(684, 387)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkDelete)
        Me.TabPage1.Controls.Add(Me.butBrowseProcessedFolder)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.txtProcessedFiles)
        Me.TabPage1.Controls.Add(Me.chkWatchImport)
        Me.TabPage1.Controls.Add(Me.chkGE)
        Me.TabPage1.Controls.Add(Me.butBrowseDatabaseFolder)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtDBFolder)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtTaxonDictionaryFilter)
        Me.TabPage1.Controls.Add(Me.chkPlaySound)
        Me.TabPage1.Controls.Add(Me.butBrowseDB)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtDB)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.butBrowseExportFolder)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtExportFolder)
        Me.TabPage1.Controls.Add(Me.butBrowseInputFolder)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtImportFolder)
        Me.TabPage1.Controls.Add(Me.clbClearFieldsOnCopy)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDeterminer)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtRecorder)
        Me.TabPage1.Controls.Add(Me.clbFields)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(676, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Location = New System.Drawing.Point(562, 96)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(57, 17)
        Me.chkDelete.TabIndex = 50
        Me.chkDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.chkDelete, resources.GetString("chkDelete.ToolTip"))
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'butBrowseProcessedFolder
        '
        Me.butBrowseProcessedFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseProcessedFolder.Location = New System.Drawing.Point(620, 93)
        Me.butBrowseProcessedFolder.Name = "butBrowseProcessedFolder"
        Me.butBrowseProcessedFolder.Size = New System.Drawing.Size(53, 21)
        Me.butBrowseProcessedFolder.TabIndex = 48
        Me.butBrowseProcessedFolder.Text = "Browse"
        Me.butBrowseProcessedFolder.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(5, 97)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(106, 13)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Folder for processed:"
        '
        'txtProcessedFiles
        '
        Me.txtProcessedFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessedFiles.Enabled = False
        Me.txtProcessedFiles.Location = New System.Drawing.Point(123, 94)
        Me.txtProcessedFiles.Name = "txtProcessedFiles"
        Me.txtProcessedFiles.Size = New System.Drawing.Size(429, 20)
        Me.txtProcessedFiles.TabIndex = 47
        Me.tt.SetToolTip(Me.txtProcessedFiles, "This defines the folder that the processed sound files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "are moved to. If this is " & _
        "left blank then the files are" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "deleted instead.")
        '
        'chkWatchImport
        '
        Me.chkWatchImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkWatchImport.AutoSize = True
        Me.chkWatchImport.Location = New System.Drawing.Point(562, 70)
        Me.chkWatchImport.Name = "chkWatchImport"
        Me.chkWatchImport.Size = New System.Drawing.Size(58, 17)
        Me.chkWatchImport.TabIndex = 46
        Me.chkWatchImport.Text = "Watch"
        Me.tt.SetToolTip(Me.chkWatchImport, resources.GetString("chkWatchImport.ToolTip"))
        Me.chkWatchImport.UseVisualStyleBackColor = True
        '
        'chkGE
        '
        Me.chkGE.AutoSize = True
        Me.chkGE.Location = New System.Drawing.Point(427, 202)
        Me.chkGE.Name = "chkGE"
        Me.chkGE.Size = New System.Drawing.Size(141, 17)
        Me.chkGE.TabIndex = 12
        Me.chkGE.Text = "Invoke GE automatically"
        Me.tt.SetToolTip(Me.chkGE, resources.GetString("chkGE.ToolTip"))
        Me.chkGE.UseVisualStyleBackColor = True
        '
        'butBrowseDatabaseFolder
        '
        Me.butBrowseDatabaseFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseDatabaseFolder.Location = New System.Drawing.Point(620, 144)
        Me.butBrowseDatabaseFolder.Name = "butBrowseDatabaseFolder"
        Me.butBrowseDatabaseFolder.Size = New System.Drawing.Size(53, 21)
        Me.butBrowseDatabaseFolder.TabIndex = 8
        Me.butBrowseDatabaseFolder.Text = "Browse"
        Me.butBrowseDatabaseFolder.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(26, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Database folder:"
        '
        'txtDBFolder
        '
        Me.txtDBFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDBFolder.Enabled = False
        Me.txtDBFolder.Location = New System.Drawing.Point(123, 145)
        Me.txtDBFolder.Name = "txtDBFolder"
        Me.txtDBFolder.Size = New System.Drawing.Size(493, 20)
        Me.txtDBFolder.TabIndex = 7
        Me.tt.SetToolTip(Me.txtDBFolder, "This indicates the folder which contains" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "your SQLite database files.")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(2, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Taxon dictionary filter:"
        '
        'txtTaxonDictionaryFilter
        '
        Me.txtTaxonDictionaryFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaxonDictionaryFilter.Location = New System.Drawing.Point(123, 220)
        Me.txtTaxonDictionaryFilter.Name = "txtTaxonDictionaryFilter"
        Me.txtTaxonDictionaryFilter.Size = New System.Drawing.Size(256, 20)
        Me.txtTaxonDictionaryFilter.TabIndex = 11
        Me.tt.SetToolTip(Me.txtTaxonDictionaryFilter, resources.GetString("txtTaxonDictionaryFilter.ToolTip"))
        '
        'chkPlaySound
        '
        Me.chkPlaySound.AutoSize = True
        Me.chkPlaySound.Checked = True
        Me.chkPlaySound.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPlaySound.Location = New System.Drawing.Point(427, 225)
        Me.chkPlaySound.Name = "chkPlaySound"
        Me.chkPlaySound.Size = New System.Drawing.Size(177, 17)
        Me.chkPlaySound.TabIndex = 13
        Me.chkPlaySound.Text = "Play sound when dialogs shown"
        Me.tt.SetToolTip(Me.chkPlaySound, "Uncheck this if you would prefer to always " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "specifically request that a sound is" & _
        " played.")
        Me.chkPlaySound.UseVisualStyleBackColor = True
        '
        'butBrowseDB
        '
        Me.butBrowseDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseDB.Location = New System.Drawing.Point(620, 172)
        Me.butBrowseDB.Name = "butBrowseDB"
        Me.butBrowseDB.Size = New System.Drawing.Size(53, 20)
        Me.butBrowseDB.TabIndex = 10
        Me.butBrowseDB.Text = "Browse"
        Me.butBrowseDB.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "(V1) Database:"
        '
        'txtDB
        '
        Me.txtDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDB.Enabled = False
        Me.txtDB.Location = New System.Drawing.Point(121, 173)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(493, 20)
        Me.txtDB.TabIndex = 9
        Me.tt.SetToolTip(Me.txtDB, "This is only required if you are converting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a version 1.1 database to a version " & _
        "2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "database.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(315, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "'Clear on copy' fields:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(46, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Display fields:"
        '
        'butBrowseExportFolder
        '
        Me.butBrowseExportFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseExportFolder.Location = New System.Drawing.Point(620, 118)
        Me.butBrowseExportFolder.Name = "butBrowseExportFolder"
        Me.butBrowseExportFolder.Size = New System.Drawing.Size(53, 21)
        Me.butBrowseExportFolder.TabIndex = 6
        Me.butBrowseExportFolder.Text = "Browse"
        Me.butBrowseExportFolder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Default export folder:"
        '
        'txtExportFolder
        '
        Me.txtExportFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportFolder.Enabled = False
        Me.txtExportFolder.Location = New System.Drawing.Point(123, 119)
        Me.txtExportFolder.Name = "txtExportFolder"
        Me.txtExportFolder.Size = New System.Drawing.Size(493, 20)
        Me.txtExportFolder.TabIndex = 5
        Me.tt.SetToolTip(Me.txtExportFolder, "This defines the folder that the export" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file save dialog defaults to.")
        '
        'butBrowseInputFolder
        '
        Me.butBrowseInputFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseInputFolder.Location = New System.Drawing.Point(620, 67)
        Me.butBrowseInputFolder.Name = "butBrowseInputFolder"
        Me.butBrowseInputFolder.Size = New System.Drawing.Size(53, 21)
        Me.butBrowseInputFolder.TabIndex = 4
        Me.butBrowseInputFolder.Text = "Browse"
        Me.butBrowseInputFolder.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Default import folder:"
        '
        'txtImportFolder
        '
        Me.txtImportFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImportFolder.Enabled = False
        Me.txtImportFolder.Location = New System.Drawing.Point(123, 68)
        Me.txtImportFolder.Name = "txtImportFolder"
        Me.txtImportFolder.Size = New System.Drawing.Size(429, 20)
        Me.txtImportFolder.TabIndex = 3
        Me.tt.SetToolTip(Me.txtImportFolder, "You should set this to the folder that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "normally contains your input files. It" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "d" & _
        "etermines the location that the file open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dialog defaults to when opening files" & _
        " for" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "creating records.")
        '
        'clbClearFieldsOnCopy
        '
        Me.clbClearFieldsOnCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clbClearFieldsOnCopy.CheckOnClick = True
        Me.clbClearFieldsOnCopy.FormattingEnabled = True
        Me.clbClearFieldsOnCopy.Location = New System.Drawing.Point(427, 262)
        Me.clbClearFieldsOnCopy.Name = "clbClearFieldsOnCopy"
        Me.clbClearFieldsOnCopy.Size = New System.Drawing.Size(160, 94)
        Me.clbClearFieldsOnCopy.TabIndex = 15
        Me.tt.SetToolTip(Me.clbClearFieldsOnCopy, "When you copy a record, you can indicate using this list" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "any fields that you wis" & _
        "h to be cleared after the copy.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Default determiner:"
        '
        'txtDeterminer
        '
        Me.txtDeterminer.Location = New System.Drawing.Point(123, 42)
        Me.txtDeterminer.Name = "txtDeterminer"
        Me.txtDeterminer.Size = New System.Drawing.Size(277, 20)
        Me.txtDeterminer.TabIndex = 2
        Me.tt.SetToolTip(Me.txtDeterminer, "The name of the default determiner.")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Default recorder:"
        '
        'txtRecorder
        '
        Me.txtRecorder.Location = New System.Drawing.Point(123, 16)
        Me.txtRecorder.Name = "txtRecorder"
        Me.txtRecorder.Size = New System.Drawing.Size(277, 20)
        Me.txtRecorder.TabIndex = 1
        Me.tt.SetToolTip(Me.txtRecorder, "The name of the default recorder.")
        '
        'clbFields
        '
        Me.clbFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clbFields.CheckOnClick = True
        Me.clbFields.FormattingEnabled = True
        Me.clbFields.Location = New System.Drawing.Point(123, 262)
        Me.clbFields.Name = "clbFields"
        Me.clbFields.Size = New System.Drawing.Size(160, 94)
        Me.clbFields.TabIndex = 14
        Me.tt.SetToolTip(Me.clbFields, "Indicate which record table fields are displayed.")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(676, 361)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Data options"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.txtBirdTrackUser)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 80)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(682, 50)
        Me.GroupBox6.TabIndex = 56
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BTO credentials"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(30, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(79, 13)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "BirdTrack user:"
        '
        'txtBirdTrackUser
        '
        Me.txtBirdTrackUser.Location = New System.Drawing.Point(117, 19)
        Me.txtBirdTrackUser.Name = "txtBirdTrackUser"
        Me.txtBirdTrackUser.Size = New System.Drawing.Size(202, 20)
        Me.txtBirdTrackUser.TabIndex = 1
        Me.tt.SetToolTip(Me.txtBirdTrackUser, "Your NBN Gateway user name.")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txtNBNUser)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.txtNBNPassword)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(682, 75)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NBN Gateway"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(55, 22)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 13)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "NBN user:"
        '
        'txtNBNUser
        '
        Me.txtNBNUser.Location = New System.Drawing.Point(117, 19)
        Me.txtNBNUser.Name = "txtNBNUser"
        Me.txtNBNUser.Size = New System.Drawing.Size(202, 20)
        Me.txtNBNUser.TabIndex = 1
        Me.tt.SetToolTip(Me.txtNBNUser, "Your NBN Gateway user name.")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(30, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 13)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "NBN password:"
        '
        'txtNBNPassword
        '
        Me.txtNBNPassword.Location = New System.Drawing.Point(117, 45)
        Me.txtNBNPassword.Name = "txtNBNPassword"
        Me.txtNBNPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNBNPassword.Size = New System.Drawing.Size(202, 20)
        Me.txtNBNPassword.TabIndex = 2
        Me.tt.SetToolTip(Me.txtNBNPassword, "Your NBN Gateway password.")
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.nudFfplayDelay)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.butFfplayExe)
        Me.GroupBox1.Controls.Add(Me.txtFfplayExe)
        Me.GroupBox1.Controls.Add(Me.butEvernoteFolder)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtEvernoteFolder)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtEvernoteUser)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtEvernotePassword)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 233)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 154)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Evernote"
        Me.GroupBox1.Visible = False
        '
        'nudFfplayDelay
        '
        Me.nudFfplayDelay.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudFfplayDelay.Location = New System.Drawing.Point(117, 123)
        Me.nudFfplayDelay.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.nudFfplayDelay.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudFfplayDelay.Name = "nudFfplayDelay"
        Me.nudFfplayDelay.Size = New System.Drawing.Size(61, 20)
        Me.nudFfplayDelay.TabIndex = 53
        Me.tt.SetToolTip(Me.nudFfplayDelay, resources.GetString("nudFfplayDelay.ToolTip"))
        Me.nudFfplayDelay.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(45, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 13)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "Ffplay delay:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 51
        Me.Label22.Text = "Ffplay executable:"
        '
        'butFfplayExe
        '
        Me.butFfplayExe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butFfplayExe.Location = New System.Drawing.Point(626, 96)
        Me.butFfplayExe.Name = "butFfplayExe"
        Me.butFfplayExe.Size = New System.Drawing.Size(53, 21)
        Me.butFfplayExe.TabIndex = 50
        Me.butFfplayExe.Text = "Browse"
        Me.tt.SetToolTip(Me.butFfplayExe, "Browse for ffplay exe file.")
        Me.butFfplayExe.UseVisualStyleBackColor = True
        '
        'txtFfplayExe
        '
        Me.txtFfplayExe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFfplayExe.Location = New System.Drawing.Point(117, 97)
        Me.txtFfplayExe.Name = "txtFfplayExe"
        Me.txtFfplayExe.Size = New System.Drawing.Size(505, 20)
        Me.txtFfplayExe.TabIndex = 49
        Me.tt.SetToolTip(Me.txtFfplayExe, resources.GetString("txtFfplayExe.ToolTip"))
        '
        'butEvernoteFolder
        '
        Me.butEvernoteFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butEvernoteFolder.Location = New System.Drawing.Point(626, 70)
        Me.butEvernoteFolder.Name = "butEvernoteFolder"
        Me.butEvernoteFolder.Size = New System.Drawing.Size(53, 21)
        Me.butEvernoteFolder.TabIndex = 47
        Me.butEvernoteFolder.Text = "Browse"
        Me.tt.SetToolTip(Me.butEvernoteFolder, "Browse for folder.")
        Me.butEvernoteFolder.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 13)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "Download file folder:"
        '
        'txtEvernoteFolder
        '
        Me.txtEvernoteFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEvernoteFolder.Location = New System.Drawing.Point(117, 71)
        Me.txtEvernoteFolder.Name = "txtEvernoteFolder"
        Me.txtEvernoteFolder.Size = New System.Drawing.Size(505, 20)
        Me.txtEvernoteFolder.TabIndex = 46
        Me.tt.SetToolTip(Me.txtEvernoteFolder, "This indicates the folder to which Evernote resource" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files (e.g. sound files) wi" & _
        "ll be downloaded.")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Evernote user:"
        '
        'txtEvernoteUser
        '
        Me.txtEvernoteUser.Location = New System.Drawing.Point(117, 19)
        Me.txtEvernoteUser.Name = "txtEvernoteUser"
        Me.txtEvernoteUser.Size = New System.Drawing.Size(202, 20)
        Me.txtEvernoteUser.TabIndex = 28
        Me.tt.SetToolTip(Me.txtEvernoteUser, "Your Evernote user name.")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Evernote password:"
        '
        'txtEvernotePassword
        '
        Me.txtEvernotePassword.Location = New System.Drawing.Point(117, 45)
        Me.txtEvernotePassword.Name = "txtEvernotePassword"
        Me.txtEvernotePassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEvernotePassword.Size = New System.Drawing.Size(202, 20)
        Me.txtEvernotePassword.TabIndex = 29
        Me.tt.SetToolTip(Me.txtEvernotePassword, "Your Evernote password.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 13)
        Me.Label16.TabIndex = 30
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(676, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Style options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.butStyleNoExportRec)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.butStyleModRec)
        Me.GroupBox5.Controls.Add(Me.butStyleValidRec)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.butStyleOtherRec)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Location = New System.Drawing.Point(294, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(271, 166)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Record styles"
        '
        'butStyleNoExportRec
        '
        Me.butStyleNoExportRec.BackColor = System.Drawing.Color.Salmon
        Me.butStyleNoExportRec.Location = New System.Drawing.Point(6, 125)
        Me.butStyleNoExportRec.Name = "butStyleNoExportRec"
        Me.butStyleNoExportRec.Size = New System.Drawing.Size(32, 30)
        Me.butStyleNoExportRec.TabIndex = 38
        Me.tt.SetToolTip(Me.butStyleNoExportRec, "Header style for records excluded from export.")
        Me.butStyleNoExportRec.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(44, 134)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(142, 13)
        Me.Label25.TabIndex = 39
        Me.Label25.Text = "Excluded from export header"
        '
        'butStyleModRec
        '
        Me.butStyleModRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butStyleModRec.Location = New System.Drawing.Point(6, 89)
        Me.butStyleModRec.Name = "butStyleModRec"
        Me.butStyleModRec.Size = New System.Drawing.Size(32, 30)
        Me.butStyleModRec.TabIndex = 36
        Me.tt.SetToolTip(Me.butStyleModRec, "Style for modified records.")
        Me.butStyleModRec.UseVisualStyleBackColor = False
        '
        'butStyleValidRec
        '
        Me.butStyleValidRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butStyleValidRec.Location = New System.Drawing.Point(6, 16)
        Me.butStyleValidRec.Name = "butStyleValidRec"
        Me.butStyleValidRec.Size = New System.Drawing.Size(32, 30)
        Me.butStyleValidRec.TabIndex = 32
        Me.tt.SetToolTip(Me.butStyleValidRec, "Style for valid biological records.")
        Me.butStyleValidRec.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(44, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(115, 13)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "Valid biological records"
        '
        'butStyleOtherRec
        '
        Me.butStyleOtherRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.butStyleOtherRec.Location = New System.Drawing.Point(6, 53)
        Me.butStyleOtherRec.Name = "butStyleOtherRec"
        Me.butStyleOtherRec.Size = New System.Drawing.Size(32, 30)
        Me.butStyleOtherRec.TabIndex = 34
        Me.tt.SetToolTip(Me.butStyleOtherRec, "Style for other records.")
        Me.butStyleOtherRec.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(44, 62)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(71, 13)
        Me.Label30.TabIndex = 35
        Me.Label30.Text = "Other records"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(44, 98)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(85, 13)
        Me.Label32.TabIndex = 37
        Me.Label32.Text = "Modified records"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.butStyle2km)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.butStyle100km)
        Me.GroupBox2.Controls.Add(Me.butStyleInvalid)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.butStyle10km)
        Me.GroupBox2.Controls.Add(Me.butStyle1m)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.butStyle10m)
        Me.GroupBox2.Controls.Add(Me.butStyle1km)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.butStyle100m)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 320)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mapping styles"
        '
        'butStyle2km
        '
        Me.butStyle2km.BackColor = System.Drawing.Color.Lime
        Me.butStyle2km.Location = New System.Drawing.Point(6, 89)
        Me.butStyle2km.Name = "butStyle2km"
        Me.butStyle2km.Size = New System.Drawing.Size(32, 30)
        Me.butStyle2km.TabIndex = 36
        Me.tt.SetToolTip(Me.butStyle2km, "Style for tetrad grid refs.")
        Me.butStyle2km.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(44, 294)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Invalid records"
        '
        'butStyle100km
        '
        Me.butStyle100km.BackColor = System.Drawing.Color.Blue
        Me.butStyle100km.Location = New System.Drawing.Point(6, 16)
        Me.butStyle100km.Name = "butStyle100km"
        Me.butStyle100km.Size = New System.Drawing.Size(32, 30)
        Me.butStyle100km.TabIndex = 32
        Me.tt.SetToolTip(Me.butStyle100km, "Style for 100 km grid refs.")
        Me.butStyle100km.UseVisualStyleBackColor = False
        '
        'butStyleInvalid
        '
        Me.butStyleInvalid.BackColor = System.Drawing.Color.Yellow
        Me.butStyleInvalid.Location = New System.Drawing.Point(6, 285)
        Me.butStyleInvalid.Name = "butStyleInvalid"
        Me.butStyleInvalid.Size = New System.Drawing.Size(32, 30)
        Me.butStyleInvalid.TabIndex = 46
        Me.tt.SetToolTip(Me.butStyleInvalid, "Style for invalid records.")
        Me.butStyleInvalid.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "100 km (e.g. ""SD"")"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(44, 247)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(214, 13)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "10 figure GR or 1 m (e.g. ""SD1234567890"")"
        '
        'butStyle10km
        '
        Me.butStyle10km.BackColor = System.Drawing.Color.Gray
        Me.butStyle10km.Location = New System.Drawing.Point(6, 53)
        Me.butStyle10km.Name = "butStyle10km"
        Me.butStyle10km.Size = New System.Drawing.Size(32, 30)
        Me.butStyle10km.TabIndex = 34
        Me.tt.SetToolTip(Me.butStyle10km, "Style for hectad grid refs.")
        Me.butStyle10km.UseVisualStyleBackColor = False
        '
        'butStyle1m
        '
        Me.butStyle1m.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butStyle1m.Location = New System.Drawing.Point(6, 238)
        Me.butStyle1m.Name = "butStyle1m"
        Me.butStyle1m.Size = New System.Drawing.Size(32, 30)
        Me.butStyle1m.TabIndex = 44
        Me.tt.SetToolTip(Me.butStyle1m, "Style for ten figure grid refs.")
        Me.butStyle1m.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Hectad or 10 km (e.g. ""SD12"")"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(44, 207)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(202, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "8 figure GR or 10 m (e.g. ""SD12345678"")"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(44, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Tetrad or 2 km (e.g. ""SD12A"")"
        '
        'butStyle10m
        '
        Me.butStyle10m.BackColor = System.Drawing.Color.Fuchsia
        Me.butStyle10m.Location = New System.Drawing.Point(6, 198)
        Me.butStyle10m.Name = "butStyle10m"
        Me.butStyle10m.Size = New System.Drawing.Size(32, 30)
        Me.butStyle10m.TabIndex = 42
        Me.tt.SetToolTip(Me.butStyle10m, "Style for eight figure grid refs.")
        Me.butStyle10m.UseVisualStyleBackColor = False
        '
        'butStyle1km
        '
        Me.butStyle1km.BackColor = System.Drawing.Color.Cyan
        Me.butStyle1km.Location = New System.Drawing.Point(6, 125)
        Me.butStyle1km.Name = "butStyle1km"
        Me.butStyle1km.Size = New System.Drawing.Size(32, 30)
        Me.butStyle1km.TabIndex = 38
        Me.tt.SetToolTip(Me.butStyle1km, "Style for monad grid refs.")
        Me.butStyle1km.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(44, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(196, 13)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "6 figure GR or 100 m (e.g. ""SD123456"")"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(44, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Monad or 1 km (e.g. ""SD1234"")"
        '
        'butStyle100m
        '
        Me.butStyle100m.BackColor = System.Drawing.Color.Red
        Me.butStyle100m.Location = New System.Drawing.Point(6, 161)
        Me.butStyle100m.Name = "butStyle100m"
        Me.butStyle100m.Size = New System.Drawing.Size(32, 30)
        Me.butStyle100m.TabIndex = 40
        Me.tt.SetToolTip(Me.butStyle100m, "Style for six figure grid refs.")
        Me.butStyle100m.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(676, 361)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Input file options"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.rbVisiontacAllTags)
        Me.GroupBox4.Controls.Add(Me.rbVistiotacVoiceTags)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(682, 50)
        Me.GroupBox4.TabIndex = 56
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Visiontac/Columbus file options"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(152, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Create candidate records from:"
        '
        'rbVisiontacAllTags
        '
        Me.rbVisiontacAllTags.AutoSize = True
        Me.rbVisiontacAllTags.Location = New System.Drawing.Point(289, 19)
        Me.rbVisiontacAllTags.Name = "rbVisiontacAllTags"
        Me.rbVisiontacAllTags.Size = New System.Drawing.Size(59, 17)
        Me.rbVisiontacAllTags.TabIndex = 1
        Me.rbVisiontacAllTags.Text = "All tags"
        Me.tt.SetToolTip(Me.rbVisiontacAllTags, "Select this option to make candidate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records from all tags.")
        Me.rbVisiontacAllTags.UseVisualStyleBackColor = True
        '
        'rbVistiotacVoiceTags
        '
        Me.rbVistiotacVoiceTags.AutoSize = True
        Me.rbVistiotacVoiceTags.Checked = True
        Me.rbVistiotacVoiceTags.Location = New System.Drawing.Point(173, 19)
        Me.rbVistiotacVoiceTags.Name = "rbVistiotacVoiceTags"
        Me.rbVistiotacVoiceTags.Size = New System.Drawing.Size(97, 17)
        Me.rbVistiotacVoiceTags.TabIndex = 0
        Me.rbVistiotacVoiceTags.TabStop = True
        Me.rbVistiotacVoiceTags.Text = "Voice tags only"
        Me.tt.SetToolTip(Me.rbVistiotacVoiceTags, "Select this option to make candidate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "records from voice tags only.")
        Me.rbVistiotacVoiceTags.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        Me.OpenFileDialog.Multiselect = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 416)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.butClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gilbert 21 options"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudFfplayDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents butStyle1m As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents butStyle10m As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents butStyle100m As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents butStyle1km As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butStyle2km As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butStyle10km As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butStyle100km As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkPlaySound As System.Windows.Forms.CheckBox
    Friend WithEvents butBrowseDB As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents butBrowseExportFolder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExportFolder As System.Windows.Forms.TextBox
    Friend WithEvents butBrowseInputFolder As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtImportFolder As System.Windows.Forms.TextBox
    Friend WithEvents clbClearFieldsOnCopy As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDeterminer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRecorder As System.Windows.Forms.TextBox
    Friend WithEvents clbFields As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTaxonDictionaryFilter As System.Windows.Forms.TextBox
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents butStyleInvalid As System.Windows.Forms.Button
    Friend WithEvents butBrowseDatabaseFolder As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDBFolder As System.Windows.Forms.TextBox
    Friend WithEvents chkGE As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEvernotePassword As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEvernoteUser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents butEvernoteFolder As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEvernoteFolder As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents butFfplayExe As System.Windows.Forms.Button
    Friend WithEvents txtFfplayExe As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents nudFfplayDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtNBNUser As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtNBNPassword As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents rbVisiontacAllTags As System.Windows.Forms.RadioButton
    Friend WithEvents rbVistiotacVoiceTags As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents butStyleModRec As System.Windows.Forms.Button
    Friend WithEvents butStyleValidRec As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents butStyleOtherRec As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents butStyleNoExportRec As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtBirdTrackUser As System.Windows.Forms.TextBox
    Friend WithEvents chkWatchImport As System.Windows.Forms.CheckBox
    Friend WithEvents butBrowseProcessedFolder As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtProcessedFiles As System.Windows.Forms.TextBox
    Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
End Class
