﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExport))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbSelectedRecords = New System.Windows.Forms.RadioButton
        Me.rbAllRecords = New System.Windows.Forms.RadioButton
        Me.cbBiologicalRecords = New System.Windows.Forms.CheckBox
        Me.cbInvalidRecords = New System.Windows.Forms.CheckBox
        Me.butCancel = New System.Windows.Forms.Button
        Me.butCommit = New System.Windows.Forms.Button
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbDaylightSaving = New System.Windows.Forms.CheckBox
        Me.nudTrackInterval = New System.Windows.Forms.NumericUpDown
        Me.cbEastingNorthing = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbNoGPSTracks = New System.Windows.Forms.RadioButton
        Me.rbAllGPSTracks = New System.Windows.Forms.RadioButton
        Me.lblTrackThickness = New System.Windows.Forms.Label
        Me.nudTrackThickness = New System.Windows.Forms.NumericUpDown
        Me.lblTrackInterval2 = New System.Windows.Forms.Label
        Me.lblTrackInterval1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbIncludeExcluded = New System.Windows.Forms.CheckBox
        Me.cbIncludeNoChecking = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.butRemoveRecipient = New System.Windows.Forms.Button
        Me.butAddRecipient = New System.Windows.Forms.Button
        Me.lbExportRecipients = New System.Windows.Forms.ListBox
        Me.txtExportTitle = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtExportNotes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ddlExportType = New System.Windows.Forms.ComboBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.Panel2.SuspendLayout()
        CType(Me.nudTrackInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudTrackThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbSelectedRecords)
        Me.Panel2.Controls.Add(Me.rbAllRecords)
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(242, 26)
        Me.Panel2.TabIndex = 3
        '
        'rbSelectedRecords
        '
        Me.rbSelectedRecords.AutoSize = True
        Me.rbSelectedRecords.Location = New System.Drawing.Point(88, 3)
        Me.rbSelectedRecords.Name = "rbSelectedRecords"
        Me.rbSelectedRecords.Size = New System.Drawing.Size(127, 17)
        Me.rbSelectedRecords.TabIndex = 3
        Me.rbSelectedRecords.TabStop = True
        Me.rbSelectedRecords.Text = "Selected records only"
        Me.rbSelectedRecords.UseVisualStyleBackColor = True
        '
        'rbAllRecords
        '
        Me.rbAllRecords.AutoSize = True
        Me.rbAllRecords.Checked = True
        Me.rbAllRecords.Location = New System.Drawing.Point(3, 3)
        Me.rbAllRecords.Name = "rbAllRecords"
        Me.rbAllRecords.Size = New System.Drawing.Size(74, 17)
        Me.rbAllRecords.TabIndex = 2
        Me.rbAllRecords.TabStop = True
        Me.rbAllRecords.Text = "All records"
        Me.rbAllRecords.UseVisualStyleBackColor = True
        '
        'cbBiologicalRecords
        '
        Me.cbBiologicalRecords.AutoSize = True
        Me.cbBiologicalRecords.Checked = True
        Me.cbBiologicalRecords.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBiologicalRecords.Location = New System.Drawing.Point(8, 37)
        Me.cbBiologicalRecords.Name = "cbBiologicalRecords"
        Me.cbBiologicalRecords.Size = New System.Drawing.Size(239, 17)
        Me.cbBiologicalRecords.TabIndex = 4
        Me.cbBiologicalRecords.Text = "Include valid saved biological records (green)"
        Me.cbBiologicalRecords.UseVisualStyleBackColor = True
        '
        'cbInvalidRecords
        '
        Me.cbInvalidRecords.AutoSize = True
        Me.cbInvalidRecords.Location = New System.Drawing.Point(8, 83)
        Me.cbInvalidRecords.Name = "cbInvalidRecords"
        Me.cbInvalidRecords.Size = New System.Drawing.Size(408, 17)
        Me.cbInvalidRecords.TabIndex = 6
        Me.cbInvalidRecords.Text = "Include all modified or unsaved records, whether valid or not (red, white or ambe" & _
            "r)"
        Me.cbInvalidRecords.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(381, 288)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 8
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butCommit
        '
        Me.butCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCommit.Location = New System.Drawing.Point(454, 288)
        Me.butCommit.Name = "butCommit"
        Me.butCommit.Size = New System.Drawing.Size(67, 23)
        Me.butCommit.TabIndex = 7
        Me.butCommit.Text = "OK"
        Me.butCommit.UseVisualStyleBackColor = True
        '
        'cbDaylightSaving
        '
        Me.cbDaylightSaving.AutoSize = True
        Me.cbDaylightSaving.Location = New System.Drawing.Point(10, 72)
        Me.cbDaylightSaving.Name = "cbDaylightSaving"
        Me.cbDaylightSaving.Size = New System.Drawing.Size(228, 17)
        Me.cbDaylightSaving.TabIndex = 11
        Me.cbDaylightSaving.Text = "Correct track point times for daylight saving"
        Me.tt.SetToolTip(Me.cbDaylightSaving, "Applies daylight saving to times stored against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "track points, where appropriate." & _
                "")
        Me.cbDaylightSaving.UseVisualStyleBackColor = True
        '
        'nudTrackInterval
        '
        Me.nudTrackInterval.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTrackInterval.Location = New System.Drawing.Point(69, 46)
        Me.nudTrackInterval.Name = "nudTrackInterval"
        Me.nudTrackInterval.Size = New System.Drawing.Size(39, 20)
        Me.nudTrackInterval.TabIndex = 8
        Me.tt.SetToolTip(Me.nudTrackInterval, "This is useful for thining out the number" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of points shown on a track - the highe" & _
                "r" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the number, the fewer points are shown.")
        '
        'cbEastingNorthing
        '
        Me.cbEastingNorthing.AutoSize = True
        Me.cbEastingNorthing.Checked = True
        Me.cbEastingNorthing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEastingNorthing.Location = New System.Drawing.Point(10, 19)
        Me.cbEastingNorthing.Name = "cbEastingNorthing"
        Me.cbEastingNorthing.Size = New System.Drawing.Size(170, 17)
        Me.cbEastingNorthing.TabIndex = 10
        Me.cbEastingNorthing.Text = "Include eastings and northings"
        Me.tt.SetToolTip(Me.cbEastingNorthing, "This can be useful if you are exporting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a CSV to someone who wants to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "import in" & _
                "to GIS.")
        Me.cbEastingNorthing.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbNoGPSTracks)
        Me.GroupBox1.Controls.Add(Me.rbAllGPSTracks)
        Me.GroupBox1.Controls.Add(Me.lblTrackThickness)
        Me.GroupBox1.Controls.Add(Me.nudTrackThickness)
        Me.GroupBox1.Controls.Add(Me.cbDaylightSaving)
        Me.GroupBox1.Controls.Add(Me.lblTrackInterval2)
        Me.GroupBox1.Controls.Add(Me.lblTrackInterval1)
        Me.GroupBox1.Controls.Add(Me.nudTrackInterval)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 131)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Google Earth export options"
        '
        'rbNoGPSTracks
        '
        Me.rbNoGPSTracks.AutoSize = True
        Me.rbNoGPSTracks.Checked = True
        Me.rbNoGPSTracks.Location = New System.Drawing.Point(10, 19)
        Me.rbNoGPSTracks.Name = "rbNoGPSTracks"
        Me.rbNoGPSTracks.Size = New System.Drawing.Size(96, 17)
        Me.rbNoGPSTracks.TabIndex = 15
        Me.rbNoGPSTracks.TabStop = True
        Me.rbNoGPSTracks.Text = "No GPS tracks"
        Me.rbNoGPSTracks.UseVisualStyleBackColor = True
        '
        'rbAllGPSTracks
        '
        Me.rbAllGPSTracks.AutoSize = True
        Me.rbAllGPSTracks.Location = New System.Drawing.Point(117, 19)
        Me.rbAllGPSTracks.Name = "rbAllGPSTracks"
        Me.rbAllGPSTracks.Size = New System.Drawing.Size(109, 17)
        Me.rbAllGPSTracks.TabIndex = 14
        Me.rbAllGPSTracks.Text = "Show GPS tracks"
        Me.rbAllGPSTracks.UseVisualStyleBackColor = True
        '
        'lblTrackThickness
        '
        Me.lblTrackThickness.AutoSize = True
        Me.lblTrackThickness.Location = New System.Drawing.Point(7, 97)
        Me.lblTrackThickness.Name = "lblTrackThickness"
        Me.lblTrackThickness.Size = New System.Drawing.Size(84, 13)
        Me.lblTrackThickness.TabIndex = 13
        Me.lblTrackThickness.Text = "TrackThickness"
        '
        'nudTrackThickness
        '
        Me.nudTrackThickness.Location = New System.Drawing.Point(97, 95)
        Me.nudTrackThickness.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTrackThickness.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTrackThickness.Name = "nudTrackThickness"
        Me.nudTrackThickness.Size = New System.Drawing.Size(39, 20)
        Me.nudTrackThickness.TabIndex = 12
        Me.nudTrackThickness.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblTrackInterval2
        '
        Me.lblTrackInterval2.AutoSize = True
        Me.lblTrackInterval2.Location = New System.Drawing.Point(114, 48)
        Me.lblTrackInterval2.Name = "lblTrackInterval2"
        Me.lblTrackInterval2.Size = New System.Drawing.Size(72, 13)
        Me.lblTrackInterval2.TabIndex = 10
        Me.lblTrackInterval2.Text = "point on track"
        '
        'lblTrackInterval1
        '
        Me.lblTrackInterval1.AutoSize = True
        Me.lblTrackInterval1.Location = New System.Drawing.Point(7, 48)
        Me.lblTrackInterval1.Name = "lblTrackInterval1"
        Me.lblTrackInterval1.Size = New System.Drawing.Size(60, 13)
        Me.lblTrackInterval1.TabIndex = 9
        Me.lblTrackInterval1.Text = "Mark every"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbEastingNorthing)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(489, 44)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CSV export options"
        '
        'cbIncludeExcluded
        '
        Me.cbIncludeExcluded.AutoSize = True
        Me.cbIncludeExcluded.Location = New System.Drawing.Point(8, 106)
        Me.cbIncludeExcluded.Name = "cbIncludeExcluded"
        Me.cbIncludeExcluded.Size = New System.Drawing.Size(234, 17)
        Me.cbIncludeExcluded.TabIndex = 12
        Me.cbIncludeExcluded.Text = "Include records even if marked for exclusion"
        Me.cbIncludeExcluded.UseVisualStyleBackColor = True
        '
        'cbIncludeNoChecking
        '
        Me.cbIncludeNoChecking.AutoSize = True
        Me.cbIncludeNoChecking.Location = New System.Drawing.Point(8, 60)
        Me.cbIncludeNoChecking.Name = "cbIncludeNoChecking"
        Me.cbIncludeNoChecking.Size = New System.Drawing.Size(264, 17)
        Me.cbIncludeNoChecking.TabIndex = 13
        Me.cbIncludeNoChecking.Text = "Include saved records marked 'no checking' (blue)"
        Me.cbIncludeNoChecking.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(517, 284)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(509, 258)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Recipients:"
        '
        'butRemoveRecipient
        '
        Me.butRemoveRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRemoveRecipient.Location = New System.Drawing.Point(435, 198)
        Me.butRemoveRecipient.Name = "butRemoveRecipient"
        Me.butRemoveRecipient.Size = New System.Drawing.Size(67, 23)
        Me.butRemoveRecipient.TabIndex = 27
        Me.butRemoveRecipient.Text = "Remove"
        Me.butRemoveRecipient.UseVisualStyleBackColor = True
        '
        'butAddRecipient
        '
        Me.butAddRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddRecipient.Location = New System.Drawing.Point(435, 171)
        Me.butAddRecipient.Name = "butAddRecipient"
        Me.butAddRecipient.Size = New System.Drawing.Size(67, 23)
        Me.butAddRecipient.TabIndex = 26
        Me.butAddRecipient.Text = "Add"
        Me.butAddRecipient.UseVisualStyleBackColor = True
        '
        'lbExportRecipients
        '
        Me.lbExportRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbExportRecipients.FormattingEnabled = True
        Me.lbExportRecipients.Location = New System.Drawing.Point(81, 171)
        Me.lbExportRecipients.Name = "lbExportRecipients"
        Me.lbExportRecipients.Size = New System.Drawing.Size(348, 82)
        Me.lbExportRecipients.TabIndex = 25
        '
        'txtExportTitle
        '
        Me.txtExportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportTitle.Location = New System.Drawing.Point(82, 35)
        Me.txtExportTitle.Name = "txtExportTitle"
        Me.txtExportTitle.Size = New System.Drawing.Size(420, 20)
        Me.txtExportTitle.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Short title:"
        '
        'txtExportNotes
        '
        Me.txtExportNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportNotes.Location = New System.Drawing.Point(81, 62)
        Me.txtExportNotes.Multiline = True
        Me.txtExportNotes.Name = "txtExportNotes"
        Me.txtExportNotes.Size = New System.Drawing.Size(422, 103)
        Me.txtExportNotes.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Notes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Export format:"
        '
        'ddlExportType
        '
        Me.ddlExportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddlExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlExportType.FormattingEnabled = True
        Me.ddlExportType.Items.AddRange(New Object() {"CSV", "MapMate", "Google Earth", "MapInfo", "RODIS"})
        Me.ddlExportType.Location = New System.Drawing.Point(81, 6)
        Me.ddlExportType.Name = "ddlExportType"
        Me.ddlExportType.Size = New System.Drawing.Size(421, 21)
        Me.ddlExportType.TabIndex = 15
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.cbInvalidRecords)
        Me.TabPage3.Controls.Add(Me.cbIncludeExcluded)
        Me.TabPage3.Controls.Add(Me.cbBiologicalRecords)
        Me.TabPage3.Controls.Add(Me.cbIncludeNoChecking)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(509, 258)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Filters"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(509, 258)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 314)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butCommit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export records"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudTrackInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudTrackThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
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
    Friend WithEvents cbDaylightSaving As System.Windows.Forms.CheckBox
    Friend WithEvents lblTrackThickness As System.Windows.Forms.Label
    Friend WithEvents nudTrackThickness As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbAllGPSTracks As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoGPSTracks As System.Windows.Forms.RadioButton
    Friend WithEvents cbEastingNorthing As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbIncludeExcluded As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncludeNoChecking As System.Windows.Forms.CheckBox
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
End Class
