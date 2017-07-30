<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportsManage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportsManage))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.butRemoveRecipient = New System.Windows.Forms.Button()
        Me.butAddRecipient = New System.Windows.Forms.Button()
        Me.lbExportRecipients = New System.Windows.Forms.ListBox()
        Me.txtExportTitle = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExportNotes = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddlExportType = New System.Windows.Forms.ComboBox()
        Me.butCommit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtExportFile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ddlExportTitle = New System.Windows.Forms.ComboBox()
        Me.txtExportTitleFilter = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbRecipient = New System.Windows.Forms.ComboBox()
        Me.butRecipientFilterClear = New System.Windows.Forms.Button()
        Me.butTitleFilterClear = New System.Windows.Forms.Button()
        Me.butImport = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.dtpExportDate = New System.Windows.Forms.DateTimePicker()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Recipients:"
        '
        'butRemoveRecipient
        '
        Me.butRemoveRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRemoveRecipient.Location = New System.Drawing.Point(462, 287)
        Me.butRemoveRecipient.Name = "butRemoveRecipient"
        Me.butRemoveRecipient.Size = New System.Drawing.Size(67, 23)
        Me.butRemoveRecipient.TabIndex = 120
        Me.butRemoveRecipient.Text = "Remove"
        Me.tt.SetToolTip(Me.butRemoveRecipient, "Remove a recipient from the list for this export.")
        Me.butRemoveRecipient.UseVisualStyleBackColor = True
        '
        'butAddRecipient
        '
        Me.butAddRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddRecipient.Location = New System.Drawing.Point(462, 261)
        Me.butAddRecipient.Name = "butAddRecipient"
        Me.butAddRecipient.Size = New System.Drawing.Size(67, 23)
        Me.butAddRecipient.TabIndex = 110
        Me.butAddRecipient.Text = "Add"
        Me.tt.SetToolTip(Me.butAddRecipient, "Add a recipient to the list for this export.")
        Me.butAddRecipient.UseVisualStyleBackColor = True
        '
        'lbExportRecipients
        '
        Me.lbExportRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbExportRecipients.FormattingEnabled = True
        Me.lbExportRecipients.Location = New System.Drawing.Point(91, 261)
        Me.lbExportRecipients.Name = "lbExportRecipients"
        Me.lbExportRecipients.Size = New System.Drawing.Size(365, 82)
        Me.lbExportRecipients.TabIndex = 100
        Me.tt.SetToolTip(Me.lbExportRecipients, "Displays the recipients listed for the selected export.")
        '
        'txtExportTitle
        '
        Me.txtExportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportTitle.Location = New System.Drawing.Point(91, 138)
        Me.txtExportTitle.Name = "txtExportTitle"
        Me.txtExportTitle.Size = New System.Drawing.Size(438, 20)
        Me.txtExportTitle.TabIndex = 80
        Me.tt.SetToolTip(Me.txtExportTitle, "You can use this text box to change the short title of the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected export if yo" &
        "u wish.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "New short title:"
        '
        'txtExportNotes
        '
        Me.txtExportNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportNotes.Location = New System.Drawing.Point(91, 164)
        Me.txtExportNotes.Multiline = True
        Me.txtExportNotes.Name = "txtExportNotes"
        Me.txtExportNotes.Size = New System.Drawing.Size(437, 91)
        Me.txtExportNotes.TabIndex = 90
        Me.tt.SetToolTip(Me.txtExportNotes, "See/edit the notes associated with the selected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "export record.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Notes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Export format:"
        '
        'ddlExportType
        '
        Me.ddlExportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlExportType.FormattingEnabled = True
        Me.ddlExportType.Items.AddRange(New Object() {"CSV", "iRecord", "MapMate", "Google Earth", "MapInfo", "RODIS", "BirdTrack Casual", "None"})
        Me.ddlExportType.Location = New System.Drawing.Point(91, 84)
        Me.ddlExportType.Name = "ddlExportType"
        Me.ddlExportType.Size = New System.Drawing.Size(252, 21)
        Me.ddlExportType.TabIndex = 60
        '
        'butCommit
        '
        Me.butCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCommit.Location = New System.Drawing.Point(462, 349)
        Me.butCommit.Name = "butCommit"
        Me.butCommit.Size = New System.Drawing.Size(67, 23)
        Me.butCommit.TabIndex = 170
        Me.butCommit.Text = "Close"
        Me.tt.SetToolTip(Me.butCommit, "Close the dialog.")
        Me.butCommit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Export date:"
        '
        'txtExportFile
        '
        Me.txtExportFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportFile.Location = New System.Drawing.Point(91, 111)
        Me.txtExportFile.Name = "txtExportFile"
        Me.txtExportFile.Size = New System.Drawing.Size(438, 20)
        Me.txtExportFile.TabIndex = 70
        Me.tt.SetToolTip(Me.txtExportFile, "Indicates (editable) the file location of the file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "generated for this export.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Export file:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Short title:"
        '
        'ddlExportTitle
        '
        Me.ddlExportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlExportTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlExportTitle.FormattingEnabled = True
        Me.ddlExportTitle.Items.AddRange(New Object() {"CSV", "MapMate", "Google Earth", "MapInfo", "RODIS"})
        Me.ddlExportTitle.Location = New System.Drawing.Point(91, 57)
        Me.ddlExportTitle.Name = "ddlExportTitle"
        Me.ddlExportTitle.Size = New System.Drawing.Size(438, 21)
        Me.ddlExportTitle.TabIndex = 50
        Me.tt.SetToolTip(Me.ddlExportTitle, "Select an export by it's short title.")
        '
        'txtExportTitleFilter
        '
        Me.txtExportTitleFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportTitleFilter.Location = New System.Drawing.Point(91, 31)
        Me.txtExportTitleFilter.Name = "txtExportTitleFilter"
        Me.txtExportTitleFilter.Size = New System.Drawing.Size(374, 20)
        Me.txtExportTitleFilter.TabIndex = 30
        Me.tt.SetToolTip(Me.txtExportTitleFilter, "Filter the exports that appear in the short title drop-down" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "based on them matchi" &
        "ng (partially) a string you specify here.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Short title filter:"
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butDelete.Location = New System.Drawing.Point(236, 349)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(67, 23)
        Me.butDelete.TabIndex = 150
        Me.butDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.butDelete, "Delete the selected export record.")
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butUpdate
        '
        Me.butUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butUpdate.Location = New System.Drawing.Point(90, 349)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(67, 23)
        Me.butUpdate.TabIndex = 130
        Me.butUpdate.Text = "Update"
        Me.tt.SetToolTip(Me.butUpdate, "Update an edited export record.")
        Me.butUpdate.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(163, 349)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 140
        Me.butCancel.Text = "Cancel"
        Me.tt.SetToolTip(Me.butCancel, "Cancel pending updates to an export record.")
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Recipient filter:"
        '
        'cbRecipient
        '
        Me.cbRecipient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbRecipient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbRecipient.FormattingEnabled = True
        Me.cbRecipient.Location = New System.Drawing.Point(91, 5)
        Me.cbRecipient.Name = "cbRecipient"
        Me.cbRecipient.Size = New System.Drawing.Size(374, 21)
        Me.cbRecipient.TabIndex = 10
        Me.tt.SetToolTip(Me.cbRecipient, "Filter the exports that appear in the short title drop-down" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "based on them having" &
        " recipients which match (partially)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a string you specify here.")
        '
        'butRecipientFilterClear
        '
        Me.butRecipientFilterClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butRecipientFilterClear.Location = New System.Drawing.Point(471, 5)
        Me.butRecipientFilterClear.Name = "butRecipientFilterClear"
        Me.butRecipientFilterClear.Size = New System.Drawing.Size(58, 21)
        Me.butRecipientFilterClear.TabIndex = 20
        Me.butRecipientFilterClear.Text = "Clear"
        Me.butRecipientFilterClear.UseVisualStyleBackColor = True
        '
        'butTitleFilterClear
        '
        Me.butTitleFilterClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butTitleFilterClear.Location = New System.Drawing.Point(470, 31)
        Me.butTitleFilterClear.Name = "butTitleFilterClear"
        Me.butTitleFilterClear.Size = New System.Drawing.Size(58, 21)
        Me.butTitleFilterClear.TabIndex = 40
        Me.butTitleFilterClear.Text = "Clear"
        Me.butTitleFilterClear.UseVisualStyleBackColor = True
        '
        'butImport
        '
        Me.butImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butImport.Location = New System.Drawing.Point(369, 349)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(87, 23)
        Me.butImport.TabIndex = 160
        Me.butImport.Text = "New from CSV"
        Me.tt.SetToolTip(Me.butImport, "Create a new export record from a CSV file containing" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Gilbert21 RecIDs in th" &
        "e first column.")
        Me.butImport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'dtpExportDate
        '
        Me.dtpExportDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpExportDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpExportDate.Location = New System.Drawing.Point(420, 85)
        Me.dtpExportDate.Name = "dtpExportDate"
        Me.dtpExportDate.Size = New System.Drawing.Size(109, 20)
        Me.dtpExportDate.TabIndex = 65
        '
        'frmExportsManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 375)
        Me.Controls.Add(Me.dtpExportDate)
        Me.Controls.Add(Me.butImport)
        Me.Controls.Add(Me.butTitleFilterClear)
        Me.Controls.Add(Me.butRecipientFilterClear)
        Me.Controls.Add(Me.cbRecipient)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butUpdate)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.txtExportTitleFilter)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ddlExportTitle)
        Me.Controls.Add(Me.txtExportFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.butRemoveRecipient)
        Me.Controls.Add(Me.butAddRecipient)
        Me.Controls.Add(Me.lbExportRecipients)
        Me.Controls.Add(Me.txtExportTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtExportNotes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ddlExportType)
        Me.Controls.Add(Me.butCommit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExportsManage"
        Me.Text = "Manage export records"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents butRemoveRecipient As System.Windows.Forms.Button
    Friend WithEvents butAddRecipient As System.Windows.Forms.Button
    Friend WithEvents lbExportRecipients As System.Windows.Forms.ListBox
    Friend WithEvents txtExportTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtExportNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ddlExportType As System.Windows.Forms.ComboBox
    Friend WithEvents butCommit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtExportFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ddlExportTitle As System.Windows.Forms.ComboBox
    Friend WithEvents txtExportTitleFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butUpdate As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbRecipient As System.Windows.Forms.ComboBox
    Friend WithEvents butRecipientFilterClear As System.Windows.Forms.Button
    Friend WithEvents butTitleFilterClear As System.Windows.Forms.Button
    Friend WithEvents butImport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dtpExportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
