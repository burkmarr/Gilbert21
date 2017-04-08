<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInitTracks
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
        Me.butBrowseDatabaseFolder = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtParentFolder = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.butProcess = New System.Windows.Forms.Button
        Me.pbInitiate = New System.Windows.Forms.ProgressBar
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'butBrowseDatabaseFolder
        '
        Me.butBrowseDatabaseFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseDatabaseFolder.Location = New System.Drawing.Point(389, 11)
        Me.butBrowseDatabaseFolder.Name = "butBrowseDatabaseFolder"
        Me.butBrowseDatabaseFolder.Size = New System.Drawing.Size(53, 21)
        Me.butBrowseDatabaseFolder.TabIndex = 47
        Me.butBrowseDatabaseFolder.Text = "Browse"
        Me.tt.SetToolTip(Me.butBrowseDatabaseFolder, "Browse to a top level folder than " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "contains - either directly or in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sub-folder" & _
                "s - all the tracks that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you want to match against records" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the database.")
        Me.butBrowseDatabaseFolder.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Parent folder:"
        '
        'txtParentFolder
        '
        Me.txtParentFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParentFolder.Enabled = False
        Me.txtParentFolder.Location = New System.Drawing.Point(82, 12)
        Me.txtParentFolder.Name = "txtParentFolder"
        Me.txtParentFolder.Size = New System.Drawing.Size(301, 20)
        Me.txtParentFolder.TabIndex = 46
        Me.tt.SetToolTip(Me.txtParentFolder, "Set this to a top level folder than " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "contains - either directly or in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sub-fold" & _
                "ers - all the tracks that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you want to match against records" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the database.")
        '
        'butProcess
        '
        Me.butProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butProcess.Location = New System.Drawing.Point(380, 64)
        Me.butProcess.Name = "butProcess"
        Me.butProcess.Size = New System.Drawing.Size(62, 20)
        Me.butProcess.TabIndex = 49
        Me.butProcess.Text = "Go"
        Me.butProcess.UseVisualStyleBackColor = True
        '
        'pbInitiate
        '
        Me.pbInitiate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbInitiate.Location = New System.Drawing.Point(9, 38)
        Me.pbInitiate.Name = "pbInitiate"
        Me.pbInitiate.Size = New System.Drawing.Size(433, 17)
        Me.pbInitiate.TabIndex = 50
        '
        'frmInitTracks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 96)
        Me.Controls.Add(Me.pbInitiate)
        Me.Controls.Add(Me.butProcess)
        Me.Controls.Add(Me.butBrowseDatabaseFolder)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtParentFolder)
        Me.Name = "frmInitTracks"
        Me.Text = "Initiate Tracks"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butBrowseDatabaseFolder As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtParentFolder As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents butProcess As System.Windows.Forms.Button
    Friend WithEvents pbInitiate As System.Windows.Forms.ProgressBar
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
