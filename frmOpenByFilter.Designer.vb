<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenByFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenByFilter))
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.butCommit = New System.Windows.Forms.Button()
        Me.butClear = New System.Windows.Forms.Button()
        Me.txtBoundaryFile = New System.Windows.Forms.TextBox()
        Me.butBrowseBoundary = New System.Windows.Forms.Button()
        Me.cbOnBeforeBefore = New System.Windows.Forms.CheckBox()
        Me.cbOnBeforeOn = New System.Windows.Forms.CheckBox()
        Me.cbOnAfterAfter = New System.Windows.Forms.CheckBox()
        Me.cbOnAfterOn = New System.Windows.Forms.CheckBox()
        Me.txtPersonalNotes = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.txtTaxonGroup = New System.Windows.Forms.TextBox()
        Me.txtScientificName = New System.Windows.Forms.TextBox()
        Me.txtCommonName = New System.Windows.Forms.TextBox()
        Me.cbIncludeExcluded = New System.Windows.Forms.CheckBox()
        Me.cboQueries = New System.Windows.Forms.ComboBox()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.cmsSQL = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.butDelete = New System.Windows.Forms.Button()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.cbIncludeInvalid = New System.Windows.Forms.CheckBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.dtpOnBefore = New System.Windows.Forms.DateTimePicker()
        Me.dtpOnAfter = New System.Windows.Forms.DateTimePicker()
        Me.cbRecipientFilterType = New System.Windows.Forms.ComboBox()
        Me.clbRecipient = New System.Windows.Forms.CheckedListBox()
        Me.cbExportFilterType = New System.Windows.Forms.ComboBox()
        Me.clbExports = New System.Windows.Forms.CheckedListBox()
        Me.rbAllRecords = New System.Windows.Forms.RadioButton()
        Me.rbFilteredRecords = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ilTabs = New System.Windows.Forms.ImageList(Me.components)
        Me.rbWithinBoundary = New System.Windows.Forms.RadioButton()
        Me.rbWithoutBoundary = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'butCommit
        '
        Me.butCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCommit.Location = New System.Drawing.Point(380, 356)
        Me.butCommit.Name = "butCommit"
        Me.butCommit.Size = New System.Drawing.Size(67, 23)
        Me.butCommit.TabIndex = 210
        Me.butCommit.Text = "Commit"
        Me.tt.SetToolTip(Me.butCommit, "Run a query constructed from the specified" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "filters against the database to retri" & _
        "eve records.")
        Me.butCommit.UseVisualStyleBackColor = True
        '
        'butClear
        '
        Me.butClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butClear.Location = New System.Drawing.Point(1, 356)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(67, 23)
        Me.butClear.TabIndex = 200
        Me.butClear.Text = "Clear"
        Me.tt.SetToolTip(Me.butClear, "Clear all the filter input fields.")
        Me.butClear.UseVisualStyleBackColor = True
        '
        'txtBoundaryFile
        '
        Me.txtBoundaryFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBoundaryFile.Location = New System.Drawing.Point(63, 6)
        Me.txtBoundaryFile.Name = "txtBoundaryFile"
        Me.txtBoundaryFile.Size = New System.Drawing.Size(299, 20)
        Me.txtBoundaryFile.TabIndex = 10
        Me.tt.SetToolTip(Me.txtBoundaryFile, "Boundary file for filtering records geographically.")
        '
        'butBrowseBoundary
        '
        Me.butBrowseBoundary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseBoundary.Location = New System.Drawing.Point(368, 4)
        Me.butBrowseBoundary.Name = "butBrowseBoundary"
        Me.butBrowseBoundary.Size = New System.Drawing.Size(67, 23)
        Me.butBrowseBoundary.TabIndex = 20
        Me.butBrowseBoundary.Text = "Browse"
        Me.tt.SetToolTip(Me.butBrowseBoundary, "Browse for a boundary file to filter records.")
        Me.butBrowseBoundary.UseVisualStyleBackColor = True
        '
        'cbOnBeforeBefore
        '
        Me.cbOnBeforeBefore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnBeforeBefore.AutoSize = True
        Me.cbOnBeforeBefore.Location = New System.Drawing.Point(377, 186)
        Me.cbOnBeforeBefore.Name = "cbOnBeforeBefore"
        Me.cbOnBeforeBefore.Size = New System.Drawing.Size(57, 17)
        Me.cbOnBeforeBefore.TabIndex = 110
        Me.cbOnBeforeBefore.Text = "Before"
        Me.tt.SetToolTip(Me.cbOnBeforeBefore, "Check this box to select records which were" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "made before the specified date.")
        Me.cbOnBeforeBefore.UseVisualStyleBackColor = True
        '
        'cbOnBeforeOn
        '
        Me.cbOnBeforeOn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnBeforeOn.AutoSize = True
        Me.cbOnBeforeOn.Location = New System.Drawing.Point(334, 186)
        Me.cbOnBeforeOn.Name = "cbOnBeforeOn"
        Me.cbOnBeforeOn.Size = New System.Drawing.Size(40, 17)
        Me.cbOnBeforeOn.TabIndex = 100
        Me.cbOnBeforeOn.Text = "On"
        Me.tt.SetToolTip(Me.cbOnBeforeOn, "Check this box to select records which were" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "made on the specified date.")
        Me.cbOnBeforeOn.UseVisualStyleBackColor = True
        '
        'cbOnAfterAfter
        '
        Me.cbOnAfterAfter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnAfterAfter.AutoSize = True
        Me.cbOnAfterAfter.Location = New System.Drawing.Point(377, 156)
        Me.cbOnAfterAfter.Name = "cbOnAfterAfter"
        Me.cbOnAfterAfter.Size = New System.Drawing.Size(48, 17)
        Me.cbOnAfterAfter.TabIndex = 80
        Me.cbOnAfterAfter.Text = "After"
        Me.tt.SetToolTip(Me.cbOnAfterAfter, "Check this box to select records which were" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "made after the specified date.")
        Me.cbOnAfterAfter.UseVisualStyleBackColor = True
        '
        'cbOnAfterOn
        '
        Me.cbOnAfterOn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnAfterOn.AutoSize = True
        Me.cbOnAfterOn.Location = New System.Drawing.Point(334, 156)
        Me.cbOnAfterOn.Name = "cbOnAfterOn"
        Me.cbOnAfterOn.Size = New System.Drawing.Size(40, 17)
        Me.cbOnAfterOn.TabIndex = 70
        Me.cbOnAfterOn.Text = "On"
        Me.tt.SetToolTip(Me.cbOnAfterOn, "Check this box to select records which were" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "made on the specified date.")
        Me.cbOnAfterOn.UseVisualStyleBackColor = True
        '
        'txtPersonalNotes
        '
        Me.txtPersonalNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPersonalNotes.Location = New System.Drawing.Point(158, 123)
        Me.txtPersonalNotes.Name = "txtPersonalNotes"
        Me.txtPersonalNotes.Size = New System.Drawing.Size(274, 20)
        Me.txtPersonalNotes.TabIndex = 50
        Me.tt.SetToolTip(Me.txtPersonalNotes, "Specify a partial string to match against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Personal notes field or leave blan" & _
        "k.")
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(158, 93)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(274, 20)
        Me.txtComment.TabIndex = 40
        Me.tt.SetToolTip(Me.txtComment, "Specify a partial string to match against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the comment field or leave blank.")
        '
        'txtTaxonGroup
        '
        Me.txtTaxonGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaxonGroup.Location = New System.Drawing.Point(158, 63)
        Me.txtTaxonGroup.Name = "txtTaxonGroup"
        Me.txtTaxonGroup.Size = New System.Drawing.Size(274, 20)
        Me.txtTaxonGroup.TabIndex = 30
        Me.tt.SetToolTip(Me.txtTaxonGroup, "Specify a partial string to match against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the taxon group or leave blank.")
        '
        'txtScientificName
        '
        Me.txtScientificName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScientificName.Location = New System.Drawing.Point(158, 34)
        Me.txtScientificName.Name = "txtScientificName"
        Me.txtScientificName.Size = New System.Drawing.Size(274, 20)
        Me.txtScientificName.TabIndex = 20
        Me.tt.SetToolTip(Me.txtScientificName, "Specify a partial string to match against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the scientific name or leave blank.")
        '
        'txtCommonName
        '
        Me.txtCommonName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommonName.Location = New System.Drawing.Point(158, 5)
        Me.txtCommonName.Name = "txtCommonName"
        Me.txtCommonName.Size = New System.Drawing.Size(274, 20)
        Me.txtCommonName.TabIndex = 10
        Me.tt.SetToolTip(Me.txtCommonName, "Specify a partial string to match against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the common name or leave blank.")
        '
        'cbIncludeExcluded
        '
        Me.cbIncludeExcluded.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIncludeExcluded.AutoSize = True
        Me.cbIncludeExcluded.Location = New System.Drawing.Point(163, 29)
        Me.cbIncludeExcluded.Name = "cbIncludeExcluded"
        Me.cbIncludeExcluded.Size = New System.Drawing.Size(236, 17)
        Me.cbIncludeExcluded.TabIndex = 4
        Me.cbIncludeExcluded.Text = "Include records marked 'exclude from export'"
        Me.tt.SetToolTip(Me.cbIncludeExcluded, "Check this box if you want to include records marked as" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "being 'exclude from expo" & _
        "rt' when you open them from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the database.")
        Me.cbIncludeExcluded.UseVisualStyleBackColor = True
        '
        'cboQueries
        '
        Me.cboQueries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQueries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQueries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQueries.FormattingEnabled = True
        Me.cboQueries.Location = New System.Drawing.Point(1, 213)
        Me.cboQueries.Name = "cboQueries"
        Me.cboQueries.Size = New System.Drawing.Size(434, 21)
        Me.cboQueries.TabIndex = 20
        Me.tt.SetToolTip(Me.cboQueries, "Select a saved query from this drop-down" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "list. The associated SQL will be shown " & _
        "above" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and can be edited if required.")
        '
        'txtSQL
        '
        Me.txtSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQL.ContextMenuStrip = Me.cmsSQL
        Me.txtSQL.Location = New System.Drawing.Point(0, 3)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(435, 205)
        Me.txtSQL.TabIndex = 10
        Me.tt.SetToolTip(Me.txtSQL, "You can build/modify an SQL query to be " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "used against the records database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "by e" & _
        "ither typing directly here, or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "by using the right mouse context" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "menu to build " & _
        "a query interactively.")
        '
        'cmsSQL
        '
        Me.cmsSQL.Name = "cmsSQL"
        Me.cmsSQL.Size = New System.Drawing.Size(61, 4)
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butDelete.Location = New System.Drawing.Point(80, 238)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(73, 23)
        Me.butDelete.TabIndex = 40
        Me.butDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.butDelete, "Delete the query with the specified" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "name from the database.")
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butAdd
        '
        Me.butAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butAdd.Location = New System.Drawing.Point(1, 238)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(73, 23)
        Me.butAdd.TabIndex = 30
        Me.butAdd.Text = "Add/Modify"
        Me.tt.SetToolTip(Me.butAdd, "If a new name is specified, then the displayed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SQL is associated with that name " & _
        "and saved" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as a named query. If an existing name is " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "specified, then the query " & _
        "is updated in the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "database.")
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'cbIncludeInvalid
        '
        Me.cbIncludeInvalid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIncludeInvalid.AutoSize = True
        Me.cbIncludeInvalid.Location = New System.Drawing.Point(9, 29)
        Me.cbIncludeInvalid.Name = "cbIncludeInvalid"
        Me.cbIncludeInvalid.Size = New System.Drawing.Size(132, 17)
        Me.cbIncludeInvalid.TabIndex = 3
        Me.cbIncludeInvalid.Text = "Include invalid records"
        Me.tt.SetToolTip(Me.cbIncludeInvalid, "Check this box if you want to include records not valid as true" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "biological recor" & _
        "ds when you open them from the database.")
        Me.cbIncludeInvalid.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(306, 356)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 220
        Me.butCancel.Text = "Cancel"
        Me.tt.SetToolTip(Me.butCancel, "Cancel the open operation.")
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'dtpOnBefore
        '
        Me.dtpOnBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpOnBefore.Enabled = False
        Me.dtpOnBefore.Location = New System.Drawing.Point(158, 183)
        Me.dtpOnBefore.Name = "dtpOnBefore"
        Me.dtpOnBefore.Size = New System.Drawing.Size(159, 20)
        Me.dtpOnBefore.TabIndex = 90
        Me.tt.SetToolTip(Me.dtpOnBefore, "Specify the latest date for selected records.")
        '
        'dtpOnAfter
        '
        Me.dtpOnAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpOnAfter.Enabled = False
        Me.dtpOnAfter.Location = New System.Drawing.Point(158, 153)
        Me.dtpOnAfter.Name = "dtpOnAfter"
        Me.dtpOnAfter.Size = New System.Drawing.Size(159, 20)
        Me.dtpOnAfter.TabIndex = 60
        Me.tt.SetToolTip(Me.dtpOnAfter, "Specify the earliest date for selected records.")
        '
        'cbRecipientFilterType
        '
        Me.cbRecipientFilterType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbRecipientFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRecipientFilterType.FormattingEnabled = True
        Me.cbRecipientFilterType.Items.AddRange(New Object() {"No recipient filter", "Records exported to", "Records not exported to"})
        Me.cbRecipientFilterType.Location = New System.Drawing.Point(3, 145)
        Me.cbRecipientFilterType.Name = "cbRecipientFilterType"
        Me.cbRecipientFilterType.Size = New System.Drawing.Size(430, 21)
        Me.cbRecipientFilterType.TabIndex = 30
        Me.tt.SetToolTip(Me.cbRecipientFilterType, "Indicate the type of selection rule to be used against " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the specified recipients" & _
        ".")
        '
        'clbRecipient
        '
        Me.clbRecipient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbRecipient.CheckOnClick = True
        Me.clbRecipient.FormattingEnabled = True
        Me.clbRecipient.Location = New System.Drawing.Point(1, 171)
        Me.clbRecipient.Name = "clbRecipient"
        Me.clbRecipient.Size = New System.Drawing.Size(432, 94)
        Me.clbRecipient.TabIndex = 40
        Me.tt.SetToolTip(Me.clbRecipient, "Check the recipients for the selection criterion.")
        '
        'cbExportFilterType
        '
        Me.cbExportFilterType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbExportFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbExportFilterType.FormattingEnabled = True
        Me.cbExportFilterType.Items.AddRange(New Object() {"No export filter", "Records included in", "Records not included in", "Records created since", "Records included but since modified", "Records created or modified since"})
        Me.cbExportFilterType.Location = New System.Drawing.Point(3, 5)
        Me.cbExportFilterType.Name = "cbExportFilterType"
        Me.cbExportFilterType.Size = New System.Drawing.Size(432, 21)
        Me.cbExportFilterType.TabIndex = 10
        Me.tt.SetToolTip(Me.cbExportFilterType, "Indicate the type of selection rule to be used against " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "specified exports.")
        '
        'clbExports
        '
        Me.clbExports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbExports.CheckOnClick = True
        Me.clbExports.FormattingEnabled = True
        Me.clbExports.Location = New System.Drawing.Point(3, 30)
        Me.clbExports.Name = "clbExports"
        Me.clbExports.Size = New System.Drawing.Size(432, 109)
        Me.clbExports.TabIndex = 20
        Me.tt.SetToolTip(Me.clbExports, "Check the exports for the selection criterion.")
        '
        'rbAllRecords
        '
        Me.rbAllRecords.AutoSize = True
        Me.rbAllRecords.Location = New System.Drawing.Point(106, 6)
        Me.rbAllRecords.Name = "rbAllRecords"
        Me.rbAllRecords.Size = New System.Drawing.Size(74, 17)
        Me.rbAllRecords.TabIndex = 2
        Me.rbAllRecords.Text = "All records"
        Me.tt.SetToolTip(Me.rbAllRecords, "Select this option if you want to open all records in the database.")
        Me.rbAllRecords.UseVisualStyleBackColor = True
        '
        'rbFilteredRecords
        '
        Me.rbFilteredRecords.AutoSize = True
        Me.rbFilteredRecords.Checked = True
        Me.rbFilteredRecords.Location = New System.Drawing.Point(9, 6)
        Me.rbFilteredRecords.Name = "rbFilteredRecords"
        Me.rbFilteredRecords.Size = New System.Drawing.Size(85, 17)
        Me.rbFilteredRecords.TabIndex = 1
        Me.rbFilteredRecords.TabStop = True
        Me.rbFilteredRecords.Text = "Filter records"
        Me.tt.SetToolTip(Me.rbFilteredRecords, "Check this box if you want to filter records by some criteria" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "which you will spe" & _
        "cify on one or more of the tabs.")
        Me.rbFilteredRecords.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Boundary:"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ImageList = Me.ilTabs
        Me.TabControl1.Location = New System.Drawing.Point(1, 52)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(446, 302)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbOnBeforeBefore)
        Me.TabPage1.Controls.Add(Me.cbOnBeforeOn)
        Me.TabPage1.Controls.Add(Me.cbOnAfterAfter)
        Me.TabPage1.Controls.Add(Me.cbOnAfterOn)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.dtpOnBefore)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.dtpOnAfter)
        Me.TabPage1.Controls.Add(Me.txtPersonalNotes)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtComment)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtTaxonGroup)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtScientificName)
        Me.TabPage1.Controls.Add(Me.txtCommonName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.ImageIndex = 1
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(438, 275)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Easy select"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(84, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "on/before:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Record date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(84, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "on/after:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Record date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(95, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "contains: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Personal notes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "contains: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Comment"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "contains: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Taxon group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "contains: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Scientific name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "contains: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Common name"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Transparent
        Me.TabPage4.Controls.Add(Me.cboQueries)
        Me.TabPage4.Controls.Add(Me.txtSQL)
        Me.TabPage4.Controls.Add(Me.butDelete)
        Me.TabPage4.Controls.Add(Me.butAdd)
        Me.TabPage4.ImageIndex = 1
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(438, 275)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "SQL select"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rbWithoutBoundary)
        Me.TabPage2.Controls.Add(Me.rbWithinBoundary)
        Me.TabPage2.Controls.Add(Me.txtBoundaryFile)
        Me.TabPage2.Controls.Add(Me.butBrowseBoundary)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.ForeColor = System.Drawing.Color.Black
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(438, 275)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Geographic filter"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cbRecipientFilterType)
        Me.TabPage3.Controls.Add(Me.clbRecipient)
        Me.TabPage3.Controls.Add(Me.cbExportFilterType)
        Me.TabPage3.Controls.Add(Me.clbExports)
        Me.TabPage3.ImageIndex = 1
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(438, 275)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Export filters"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ilTabs
        '
        Me.ilTabs.ImageStream = CType(resources.GetObject("ilTabs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTabs.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTabs.Images.SetKeyName(0, "greenlight.gif")
        Me.ilTabs.Images.SetKeyName(1, "redlight.gif")
        '
        'rbWithinBoundary
        '
        Me.rbWithinBoundary.AutoSize = True
        Me.rbWithinBoundary.Checked = True
        Me.rbWithinBoundary.Location = New System.Drawing.Point(8, 32)
        Me.rbWithinBoundary.Name = "rbWithinBoundary"
        Me.rbWithinBoundary.Size = New System.Drawing.Size(248, 17)
        Me.rbWithinBoundary.TabIndex = 37
        Me.rbWithinBoundary.Text = "Within boundary (includes those which overlap)"
        Me.tt.SetToolTip(Me.rbWithinBoundary, "Select this option if you want to include all records " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "which are within or overl" & _
        "ap the boundary.")
        Me.rbWithinBoundary.UseVisualStyleBackColor = True
        '
        'rbWithoutBoundary
        '
        Me.rbWithoutBoundary.AutoSize = True
        Me.rbWithoutBoundary.Location = New System.Drawing.Point(7, 55)
        Me.rbWithoutBoundary.Name = "rbWithoutBoundary"
        Me.rbWithoutBoundary.Size = New System.Drawing.Size(294, 17)
        Me.rbWithoutBoundary.TabIndex = 38
        Me.rbWithoutBoundary.Text = "Without boundary (does not include those which overlap)"
        Me.tt.SetToolTip(Me.rbWithoutBoundary, "Select this option if you want to select records " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "which are outside and do not o" & _
        "verlap the boundary.")
        Me.rbWithoutBoundary.UseVisualStyleBackColor = True
        '
        'frmOpenByFilter
        '
        Me.AcceptButton = Me.butCommit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 382)
        Me.Controls.Add(Me.cbIncludeInvalid)
        Me.Controls.Add(Me.rbFilteredRecords)
        Me.Controls.Add(Me.rbAllRecords)
        Me.Controls.Add(Me.cbIncludeExcluded)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.butClear)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butCommit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmOpenByFilter"
        Me.Text = "Open records"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butCommit As System.Windows.Forms.Button
    Friend WithEvents butClear As System.Windows.Forms.Button
    Friend WithEvents txtBoundaryFile As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents butBrowseBoundary As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cbOnBeforeBefore As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnBeforeOn As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnAfterAfter As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnAfterOn As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpOnBefore As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpOnAfter As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPersonalNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTaxonGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtScientificName As System.Windows.Forms.TextBox
    Friend WithEvents txtCommonName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents clbExports As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbExportFilterType As System.Windows.Forms.ComboBox
    Friend WithEvents cbRecipientFilterType As System.Windows.Forms.ComboBox
    Friend WithEvents clbRecipient As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbIncludeExcluded As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncludeInvalid As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cboQueries As System.Windows.Forms.ComboBox
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents cmsSQL As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents rbAllRecords As System.Windows.Forms.RadioButton
    Friend WithEvents rbFilteredRecords As System.Windows.Forms.RadioButton
    Friend WithEvents ilTabs As System.Windows.Forms.ImageList
    Friend WithEvents rbWithoutBoundary As System.Windows.Forms.RadioButton
    Friend WithEvents rbWithinBoundary As System.Windows.Forms.RadioButton
End Class
