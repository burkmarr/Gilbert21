<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBTOBirdNameMatch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBTOBirdNameMatch))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblG21CommonName = New System.Windows.Forms.Label()
        Me.lblG21ScientificName = New System.Windows.Forms.Label()
        Me.butOK = New System.Windows.Forms.Button()
        Me.cboScientificName = New System.Windows.Forms.ComboBox()
        Me.cboCommonName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(556, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'lblG21CommonName
        '
        Me.lblG21CommonName.AutoSize = True
        Me.lblG21CommonName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG21CommonName.Location = New System.Drawing.Point(115, 66)
        Me.lblG21CommonName.Name = "lblG21CommonName"
        Me.lblG21CommonName.Size = New System.Drawing.Size(122, 13)
        Me.lblG21CommonName.TabIndex = 1
        Me.lblG21CommonName.Text = "lblG21CommonName"
        '
        'lblG21ScientificName
        '
        Me.lblG21ScientificName.AutoSize = True
        Me.lblG21ScientificName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG21ScientificName.Location = New System.Drawing.Point(115, 92)
        Me.lblG21ScientificName.Name = "lblG21ScientificName"
        Me.lblG21ScientificName.Size = New System.Drawing.Size(128, 13)
        Me.lblG21ScientificName.TabIndex = 2
        Me.lblG21ScientificName.Text = "lblG21ScientificName"
        '
        'butOK
        '
        Me.butOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butOK.Location = New System.Drawing.Point(485, 171)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(67, 23)
        Me.butOK.TabIndex = 30
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'cboScientificName
        '
        Me.cboScientificName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboScientificName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboScientificName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboScientificName.FormattingEnabled = True
        Me.cboScientificName.Location = New System.Drawing.Point(118, 146)
        Me.cboScientificName.Name = "cboScientificName"
        Me.cboScientificName.Size = New System.Drawing.Size(434, 21)
        Me.cboScientificName.TabIndex = 20
        '
        'cboCommonName
        '
        Me.cboCommonName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCommonName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommonName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCommonName.FormattingEnabled = True
        Me.cboCommonName.Location = New System.Drawing.Point(118, 119)
        Me.cboCommonName.Name = "cboCommonName"
        Me.cboCommonName.Size = New System.Drawing.Size(434, 21)
        Me.cboCommonName.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "BTO Common Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "BTO Scientific Name:"
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(412, 171)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 40
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "G21 Common Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "G21 Scientific Name:"
        '
        'frmBTOBirdNameMatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 199)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboScientificName)
        Me.Controls.Add(Me.cboCommonName)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.lblG21ScientificName)
        Me.Controls.Add(Me.lblG21CommonName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBTOBirdNameMatch"
        Me.Text = "Match against standard BTO bird name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblG21CommonName As System.Windows.Forms.Label
    Friend WithEvents lblG21ScientificName As System.Windows.Forms.Label
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents cboScientificName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCommonName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
