<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchGazetteer
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
        Me.butSearch = New System.Windows.Forms.Button
        Me.butClose = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lvLocations = New System.Windows.Forms.ListView
        Me.colTown = New System.Windows.Forms.ColumnHeader
        Me.colGR = New System.Windows.Forms.ColumnHeader
        Me.butUse = New System.Windows.Forms.Button
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'butSearch
        '
        Me.butSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSearch.Location = New System.Drawing.Point(188, 4)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(66, 21)
        Me.butSearch.TabIndex = 32
        Me.butSearch.Text = "Search"
        Me.tt.SetToolTip(Me.butSearch, "Search the OS 1:50,000 gazetteer.")
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClose.Location = New System.Drawing.Point(114, 262)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(67, 21)
        Me.butClose.TabIndex = 30
        Me.butClose.Text = "Close"
        Me.tt.SetToolTip(Me.butClose, "Close the dialog.")
        Me.butClose.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(3, 4)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(179, 20)
        Me.txtSearch.TabIndex = 28
        Me.tt.SetToolTip(Me.txtSearch, "Enter a search string here for the place name. This" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is case insensitive. You can" & _
                " use the * symbol as" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a wildcard (matches any number of characters).")
        '
        'lvLocations
        '
        Me.lvLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLocations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTown, Me.colGR})
        Me.lvLocations.FullRowSelect = True
        Me.lvLocations.Location = New System.Drawing.Point(3, 31)
        Me.lvLocations.MultiSelect = False
        Me.lvLocations.Name = "lvLocations"
        Me.lvLocations.Size = New System.Drawing.Size(250, 225)
        Me.lvLocations.TabIndex = 29
        Me.tt.SetToolTip(Me.lvLocations, "Lists place names which match the search criterion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you specified. To use one of " & _
                "these, select it and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "then click the 'Use' button.")
        Me.lvLocations.UseCompatibleStateImageBehavior = False
        Me.lvLocations.View = System.Windows.Forms.View.Details
        '
        'colTown
        '
        Me.colTown.Text = "Place"
        Me.colTown.Width = 147
        '
        'colGR
        '
        Me.colGR.Text = "Grid reference"
        Me.colGR.Width = 96
        '
        'butUse
        '
        Me.butUse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUse.Location = New System.Drawing.Point(187, 262)
        Me.butUse.Name = "butUse"
        Me.butUse.Size = New System.Drawing.Size(67, 21)
        Me.butUse.TabIndex = 33
        Me.butUse.Text = "Use"
        Me.tt.SetToolTip(Me.butUse, "Use the grid reference associated with the place" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected in the list.")
        Me.butUse.UseVisualStyleBackColor = True
        '
        'frmSearchGazetteer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 286)
        Me.Controls.Add(Me.butUse)
        Me.Controls.Add(Me.butSearch)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lvLocations)
        Me.Name = "frmSearchGazetteer"
        Me.Text = "Search for place-name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butSearch As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lvLocations As System.Windows.Forms.ListView
    Friend WithEvents colTown As System.Windows.Forms.ColumnHeader
    Friend WithEvents colGR As System.Windows.Forms.ColumnHeader
    Friend WithEvents butUse As System.Windows.Forms.Button
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
