<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportManageRecipients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportManageRecipients))
        Me.lbRecipients = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecipient = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.butClose = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butSelect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butClear = New System.Windows.Forms.Button()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbRecipients
        '
        Me.lbRecipients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbRecipients.FormattingEnabled = True
        Me.lbRecipients.Location = New System.Drawing.Point(59, 5)
        Me.lbRecipients.Name = "lbRecipients"
        Me.lbRecipients.Size = New System.Drawing.Size(424, 160)
        Me.lbRecipients.TabIndex = 10
        Me.tt.SetToolTip(Me.lbRecipients, "List of recipients. You can select a recipient from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "this list in order to edit i" & _
        "t or select it for use with" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the export dialog.")
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Recipient:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Notes:"
        '
        'txtRecipient
        '
        Me.txtRecipient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecipient.Location = New System.Drawing.Point(59, 175)
        Me.txtRecipient.Name = "txtRecipient"
        Me.txtRecipient.Size = New System.Drawing.Size(424, 20)
        Me.txtRecipient.TabIndex = 30
        Me.tt.SetToolTip(Me.txtRecipient, "Edit the recipient name.")
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(59, 200)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(424, 155)
        Me.txtNote.TabIndex = 40
        Me.tt.SetToolTip(Me.txtNote, "Edit notes associated with this recipient.")
        '
        'butAdd
        '
        Me.butAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAdd.Location = New System.Drawing.Point(4, 15)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(64, 24)
        Me.butAdd.TabIndex = 60
        Me.butAdd.Text = "Add"
        Me.tt.SetToolTip(Me.butAdd, "Add a new recipient.")
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDelete.Location = New System.Drawing.Point(4, 69)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(64, 24)
        Me.butDelete.TabIndex = 80
        Me.butDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.butDelete, "Delete the selected recipient.")
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butUpdate
        '
        Me.butUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUpdate.Location = New System.Drawing.Point(4, 96)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(64, 24)
        Me.butUpdate.TabIndex = 90
        Me.butUpdate.Text = "Update"
        Me.tt.SetToolTip(Me.butUpdate, "Update the selected recipient with specified edits.")
        Me.butUpdate.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(489, 331)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(64, 24)
        Me.butClose.TabIndex = 110
        Me.butClose.Text = "Close"
        Me.tt.SetToolTip(Me.butClose, "Close the dialog.")
        Me.butClose.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(4, 123)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(64, 24)
        Me.butCancel.TabIndex = 100
        Me.butCancel.Text = "Cancel"
        Me.tt.SetToolTip(Me.butCancel, "Cancel pending edits to the selected recipient.")
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butSelect
        '
        Me.butSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSelect.Location = New System.Drawing.Point(489, 4)
        Me.butSelect.Name = "butSelect"
        Me.butSelect.Size = New System.Drawing.Size(64, 24)
        Me.butSelect.TabIndex = 20
        Me.butSelect.Text = "Select"
        Me.tt.SetToolTip(Me.butSelect, "Select the highlighted recipient and close the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dialog (for use when invoked from" & _
        " the export dialog).")
        Me.butSelect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Select:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.butClear)
        Me.GroupBox1.Controls.Add(Me.butUpdate)
        Me.GroupBox1.Controls.Add(Me.butAdd)
        Me.GroupBox1.Controls.Add(Me.butDelete)
        Me.GroupBox1.Controls.Add(Me.butCancel)
        Me.GroupBox1.Location = New System.Drawing.Point(485, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 153)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage"
        '
        'butClear
        '
        Me.butClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClear.Location = New System.Drawing.Point(4, 42)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(64, 24)
        Me.butClear.TabIndex = 70
        Me.butClear.Text = "Clear"
        Me.tt.SetToolTip(Me.butClear, "Clear all edit fields.")
        Me.butClear.UseVisualStyleBackColor = True
        '
        'frmExportManageRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 360)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.butSelect)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtRecipient)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbRecipients)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExportManageRecipients"
        Me.Text = "Select or manage export recipients"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbRecipients As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecipient As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butUpdate As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butSelect As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butClear As System.Windows.Forms.Button
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
