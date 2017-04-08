<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvernote
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
        Me.cbNotebooks = New System.Windows.Forms.ComboBox
        Me.lbNotes = New System.Windows.Forms.ListBox
        Me.butOkay = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbNotebooks
        '
        Me.cbNotebooks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbNotebooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNotebooks.FormattingEnabled = True
        Me.cbNotebooks.Location = New System.Drawing.Point(4, 5)
        Me.cbNotebooks.Name = "cbNotebooks"
        Me.cbNotebooks.Size = New System.Drawing.Size(283, 21)
        Me.cbNotebooks.TabIndex = 0
        '
        'lbNotes
        '
        Me.lbNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNotes.FormattingEnabled = True
        Me.lbNotes.Location = New System.Drawing.Point(4, 33)
        Me.lbNotes.Name = "lbNotes"
        Me.lbNotes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbNotes.Size = New System.Drawing.Size(283, 199)
        Me.lbNotes.TabIndex = 1
        '
        'butOkay
        '
        Me.butOkay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butOkay.Location = New System.Drawing.Point(214, 238)
        Me.butOkay.Name = "butOkay"
        Me.butOkay.Size = New System.Drawing.Size(72, 25)
        Me.butOkay.TabIndex = 2
        Me.butOkay.Text = "Download"
        Me.butOkay.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.Location = New System.Drawing.Point(136, 238)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(72, 25)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'frmEvernote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.butOkay)
        Me.Controls.Add(Me.lbNotes)
        Me.Controls.Add(Me.cbNotebooks)
        Me.Name = "frmEvernote"
        Me.Text = "Select Evernotes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbNotebooks As System.Windows.Forms.ComboBox
    Friend WithEvents lbNotes As System.Windows.Forms.ListBox
    Friend WithEvents butOkay As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
End Class
