<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageLocations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageLocations))
        Me.lvLocations = New System.Windows.Forms.ListView
        Me.colLocation = New System.Windows.Forms.ColumnHeader
        Me.colType = New System.Windows.Forms.ColumnHeader
        Me.colIndex = New System.Windows.Forms.ColumnHeader
        Me.txtGR = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.butGE = New System.Windows.Forms.Button
        Me.butDelete = New System.Windows.Forms.Button
        Me.butUse = New System.Windows.Forms.Button
        Me.txtEasting = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNorthing = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.butAdd = New System.Windows.Forms.Button
        Me.butClose = New System.Windows.Forms.Button
        Me.butApply = New System.Windows.Forms.Button
        Me.butApplyClose = New System.Windows.Forms.Button
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lvLocations
        '
        Me.lvLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLocations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLocation, Me.colType, Me.colIndex})
        Me.lvLocations.FullRowSelect = True
        Me.lvLocations.Location = New System.Drawing.Point(17, 38)
        Me.lvLocations.MultiSelect = False
        Me.lvLocations.Name = "lvLocations"
        Me.lvLocations.Size = New System.Drawing.Size(297, 249)
        Me.lvLocations.TabIndex = 2
        Me.tt.SetToolTip(Me.lvLocations, "Select location to use with the Delete or Use buttons.")
        Me.lvLocations.UseCompatibleStateImageBehavior = False
        Me.lvLocations.View = System.Windows.Forms.View.Details
        '
        'colLocation
        '
        Me.colLocation.Text = "Location"
        Me.colLocation.Width = 111
        '
        'colType
        '
        Me.colType.Text = "Type"
        Me.colType.Width = 77
        '
        'colIndex
        '
        Me.colIndex.Text = "Index"
        Me.colIndex.Width = 81
        '
        'txtGR
        '
        Me.txtGR.Enabled = False
        Me.txtGR.Location = New System.Drawing.Point(76, 12)
        Me.txtGR.Multiline = True
        Me.txtGR.Name = "txtGR"
        Me.txtGR.Size = New System.Drawing.Size(125, 20)
        Me.txtGR.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Grid Ref: "
        '
        'butGE
        '
        Me.butGE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butGE.Location = New System.Drawing.Point(320, 38)
        Me.butGE.Name = "butGE"
        Me.butGE.Size = New System.Drawing.Size(67, 23)
        Me.butGE.TabIndex = 3
        Me.butGE.Text = "View"
        Me.tt.SetToolTip(Me.butGE, "Shows the current locations shown in the dialog in Googel Earth.")
        Me.butGE.UseVisualStyleBackColor = True
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDelete.Location = New System.Drawing.Point(320, 67)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(67, 23)
        Me.butDelete.TabIndex = 4
        Me.butDelete.Text = "Delete"
        Me.tt.SetToolTip(Me.butDelete, resources.GetString("butDelete.ToolTip"))
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butUse
        '
        Me.butUse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUse.Location = New System.Drawing.Point(320, 96)
        Me.butUse.Name = "butUse"
        Me.butUse.Size = New System.Drawing.Size(67, 23)
        Me.butUse.TabIndex = 5
        Me.butUse.Text = "Use"
        Me.butUse.UseVisualStyleBackColor = True
        '
        'txtEasting
        '
        Me.txtEasting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtEasting.Location = New System.Drawing.Point(76, 322)
        Me.txtEasting.Multiline = True
        Me.txtEasting.Name = "txtEasting"
        Me.txtEasting.Size = New System.Drawing.Size(125, 20)
        Me.txtEasting.TabIndex = 7
        Me.tt.SetToolTip(Me.txtEasting, "Easting of a new location to add to the gazetteer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can copy a point from Goo" & _
                "gle Earth and paste it in" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "here to automatically set the Easting and Northing.")
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 323)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Easting: "
        '
        'txtNorthing
        '
        Me.txtNorthing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNorthing.Location = New System.Drawing.Point(76, 348)
        Me.txtNorthing.Multiline = True
        Me.txtNorthing.Name = "txtNorthing"
        Me.txtNorthing.Size = New System.Drawing.Size(125, 20)
        Me.txtNorthing.TabIndex = 8
        Me.tt.SetToolTip(Me.txtNorthing, "Northing of a new location to add to the gazetteer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can copy a point from Go" & _
                "ogle Earth and paste it in" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "here to automatically set the Easting and Northing.")
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Northing:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(76, 296)
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(238, 20)
        Me.txtName.TabIndex = 6
        Me.tt.SetToolTip(Me.txtName, "Name of a new location to add to the gazetteer.")
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Name:"
        '
        'butAdd
        '
        Me.butAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAdd.Location = New System.Drawing.Point(320, 294)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(67, 23)
        Me.butAdd.TabIndex = 9
        Me.butAdd.Text = "Add"
        Me.tt.SetToolTip(Me.butAdd, "Adds the new location specified by the Name, Easting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and Northing fields to the " & _
                "gazetteer.")
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(320, 380)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(67, 23)
        Me.butClose.TabIndex = 10
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'butApply
        '
        Me.butApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butApply.Location = New System.Drawing.Point(139, 380)
        Me.butApply.Name = "butApply"
        Me.butApply.Size = New System.Drawing.Size(67, 23)
        Me.butApply.TabIndex = 34
        Me.butApply.Text = "Apply"
        Me.tt.SetToolTip(Me.butApply, "Re-specify the default location values for any open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from GPS data logger that ha" & _
                "ve not already been saved" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the database.")
        Me.butApply.UseVisualStyleBackColor = True
        '
        'butApplyClose
        '
        Me.butApplyClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butApplyClose.Location = New System.Drawing.Point(212, 380)
        Me.butApplyClose.Name = "butApplyClose"
        Me.butApplyClose.Size = New System.Drawing.Size(102, 23)
        Me.butApplyClose.TabIndex = 35
        Me.butApplyClose.Text = "Apply and Close"
        Me.tt.SetToolTip(Me.butApplyClose, "Re-specify the default location values for any open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from GPS data logger that ha" & _
                "ve not already been saved" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the database. Then close this dialog.")
        Me.butApplyClose.UseVisualStyleBackColor = True
        '
        'frmManageLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 410)
        Me.Controls.Add(Me.butApplyClose)
        Me.Controls.Add(Me.butApply)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNorthing)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEasting)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.butUse)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.butGE)
        Me.Controls.Add(Me.txtGR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvLocations)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManageLocations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage locations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvLocations As System.Windows.Forms.ListView
    Friend WithEvents colLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents colType As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtGR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents butGE As System.Windows.Forms.Button
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butUse As System.Windows.Forms.Button
    Friend WithEvents txtEasting As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNorthing As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents butApply As System.Windows.Forms.Button
    Friend WithEvents butApplyClose As System.Windows.Forms.Button
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
