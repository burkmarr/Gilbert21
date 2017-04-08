<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvertDB
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
        Me.pbConvert = New System.Windows.Forms.ProgressBar
        Me.lblProgress = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDBFolder = New System.Windows.Forms.TextBox
        Me.butBrowseDB = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtDB = New System.Windows.Forms.TextBox
        Me.btnConvert = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'pbConvert
        '
        Me.pbConvert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbConvert.Location = New System.Drawing.Point(8, 91)
        Me.pbConvert.Name = "pbConvert"
        Me.pbConvert.Size = New System.Drawing.Size(663, 21)
        Me.pbConvert.TabIndex = 0
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(8, 72)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(112, 13)
        Me.lblProgress.TabIndex = 1
        Me.lblProgress.Text = "Conversion progress..."
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(5, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 31)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "V2 Database folder: (set in options)"
        '
        'txtDBFolder
        '
        Me.txtDBFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDBFolder.Enabled = False
        Me.txtDBFolder.Location = New System.Drawing.Point(109, 9)
        Me.txtDBFolder.Name = "txtDBFolder"
        Me.txtDBFolder.Size = New System.Drawing.Size(503, 20)
        Me.txtDBFolder.TabIndex = 49
        '
        'butBrowseDB
        '
        Me.butBrowseDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseDB.Location = New System.Drawing.Point(618, 40)
        Me.butBrowseDB.Name = "butBrowseDB"
        Me.butBrowseDB.Size = New System.Drawing.Size(53, 20)
        Me.butBrowseDB.TabIndex = 47
        Me.butBrowseDB.Text = "Browse"
        Me.butBrowseDB.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(33, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "V1 Database:"
        '
        'txtDB
        '
        Me.txtDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDB.Enabled = False
        Me.txtDB.Location = New System.Drawing.Point(109, 40)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(503, 20)
        Me.txtDB.TabIndex = 46
        Me.tt.SetToolTip(Me.txtDB, "Set this to the path of the Access" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DB you want to convert.")
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(593, 118)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(78, 24)
        Me.btnConvert.TabIndex = 51
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmConvertDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 148)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtDBFolder)
        Me.Controls.Add(Me.butBrowseDB)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbConvert)
        Me.Name = "frmConvertDB"
        Me.Text = "Convert Access to SQLite"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbConvert As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDBFolder As System.Windows.Forms.TextBox
    Friend WithEvents butBrowseDB As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
