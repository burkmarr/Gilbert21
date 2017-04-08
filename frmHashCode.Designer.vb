<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHashCode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHashCode))
        Me.dgvHashCodes = New System.Windows.Forms.DataGridView
        Me.butAdd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtShortCut = New System.Windows.Forms.TextBox
        Me.butDelete = New System.Windows.Forms.Button
        Me.butClose = New System.Windows.Forms.Button
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvHashCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvHashCodes
        '
        Me.dgvHashCodes.AllowUserToAddRows = False
        Me.dgvHashCodes.AllowUserToDeleteRows = False
        Me.dgvHashCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHashCodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHashCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHashCodes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHashCodes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvHashCodes.Location = New System.Drawing.Point(0, 1)
        Me.dgvHashCodes.Name = "dgvHashCodes"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHashCodes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHashCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHashCodes.Size = New System.Drawing.Size(766, 283)
        Me.dgvHashCodes.TabIndex = 0
        '
        'butAdd
        '
        Me.butAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butAdd.Location = New System.Drawing.Point(169, 293)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(67, 23)
        Me.butAdd.TabIndex = 2
        Me.butAdd.Text = "Add"
        Me.tt.SetToolTip(Me.butAdd, "Add a new shortcut.")
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "New shortcut:"
        '
        'txtShortCut
        '
        Me.txtShortCut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtShortCut.Location = New System.Drawing.Point(91, 295)
        Me.txtShortCut.Name = "txtShortCut"
        Me.txtShortCut.Size = New System.Drawing.Size(72, 20)
        Me.txtShortCut.TabIndex = 1
        Me.tt.SetToolTip(Me.txtShortCut, "Specify the name of a shortcut here.")
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butDelete.Location = New System.Drawing.Point(242, 293)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(67, 23)
        Me.butDelete.TabIndex = 3
        Me.butDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.butDelete, "Delete the selected shortcut.")
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(693, 293)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(67, 23)
        Me.butClose.TabIndex = 4
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'frmHashCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 324)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.txtShortCut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.dgvHashCodes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHashCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage shortcuts"
        CType(Me.dgvHashCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvHashCodes As System.Windows.Forms.DataGridView
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShortCut As System.Windows.Forms.TextBox
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
