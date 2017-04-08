<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNBNTaxonSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNBNTaxonSelection))
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.imlTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.butSearchScientificName = New System.Windows.Forms.Button
        Me.txtAuthority = New System.Windows.Forms.TextBox
        Me.txtVersionKey = New System.Windows.Forms.TextBox
        Me.chkWellFormed = New System.Windows.Forms.CheckBox
        Me.chkScientific = New System.Windows.Forms.CheckBox
        Me.chkPreferred = New System.Windows.Forms.CheckBox
        Me.lblAuthority = New System.Windows.Forms.Label
        Me.lblGroup = New System.Windows.Forms.Label
        Me.lblVersionKey = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtTaxonGroup = New System.Windows.Forms.TextBox
        Me.butOkay = New System.Windows.Forms.Button
        Me.butCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboRecords = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudEndYear = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudStartYear = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.nudOpacity = New System.Windows.Forms.NumericUpDown
        Me.cbo100m = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo1km = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo2km = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo10km = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbSpecificUser = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.rbPublic = New System.Windows.Forms.RadioButton
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtNBNUser = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtNBNPassword = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imlTreeView
        Me.TreeView1.Location = New System.Drawing.Point(309, 5)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(352, 391)
        Me.TreeView1.TabIndex = 55
        '
        'imlTreeView
        '
        Me.imlTreeView.ImageStream = CType(resources.GetObject("imlTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTreeView.Images.SetKeyName(0, "")
        Me.imlTreeView.Images.SetKeyName(1, "")
        Me.imlTreeView.Images.SetKeyName(2, "")
        Me.imlTreeView.Images.SetKeyName(3, "")
        Me.imlTreeView.Images.SetKeyName(4, "")
        '
        'butSearchScientificName
        '
        Me.butSearchScientificName.Image = CType(resources.GetObject("butSearchScientificName.Image"), System.Drawing.Image)
        Me.butSearchScientificName.Location = New System.Drawing.Point(279, 5)
        Me.butSearchScientificName.Name = "butSearchScientificName"
        Me.butSearchScientificName.Size = New System.Drawing.Size(24, 21)
        Me.butSearchScientificName.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.butSearchScientificName, "Click this button to start NBN taxon dictionary search")
        Me.butSearchScientificName.UseVisualStyleBackColor = True
        '
        'txtAuthority
        '
        Me.txtAuthority.Enabled = False
        Me.txtAuthority.Location = New System.Drawing.Point(80, 33)
        Me.txtAuthority.Name = "txtAuthority"
        Me.txtAuthority.Size = New System.Drawing.Size(223, 20)
        Me.txtAuthority.TabIndex = 84
        Me.ToolTip1.SetToolTip(Me.txtAuthority, "Taxon authority")
        '
        'txtVersionKey
        '
        Me.txtVersionKey.Enabled = False
        Me.txtVersionKey.Location = New System.Drawing.Point(80, 85)
        Me.txtVersionKey.Name = "txtVersionKey"
        Me.txtVersionKey.Size = New System.Drawing.Size(223, 20)
        Me.txtVersionKey.TabIndex = 83
        Me.ToolTip1.SetToolTip(Me.txtVersionKey, "NBN taxon version key (TVK)")
        '
        'chkWellFormed
        '
        Me.chkWellFormed.Enabled = False
        Me.chkWellFormed.Location = New System.Drawing.Point(225, 114)
        Me.chkWellFormed.Name = "chkWellFormed"
        Me.chkWellFormed.Size = New System.Drawing.Size(83, 24)
        Me.chkWellFormed.TabIndex = 82
        Me.chkWellFormed.Text = "Well-formed"
        Me.ToolTip1.SetToolTip(Me.chkWellFormed, "Indicates if this is considered to be a well-formed name")
        '
        'chkScientific
        '
        Me.chkScientific.Enabled = False
        Me.chkScientific.Location = New System.Drawing.Point(153, 114)
        Me.chkScientific.Name = "chkScientific"
        Me.chkScientific.Size = New System.Drawing.Size(80, 24)
        Me.chkScientific.TabIndex = 81
        Me.chkScientific.Text = "Scientific"
        Me.ToolTip1.SetToolTip(Me.chkScientific, "Indicates if this is a scientific name")
        '
        'chkPreferred
        '
        Me.chkPreferred.Enabled = False
        Me.chkPreferred.Location = New System.Drawing.Point(80, 114)
        Me.chkPreferred.Name = "chkPreferred"
        Me.chkPreferred.Size = New System.Drawing.Size(72, 24)
        Me.chkPreferred.TabIndex = 80
        Me.chkPreferred.Text = "Preferred"
        Me.ToolTip1.SetToolTip(Me.chkPreferred, "Indicates if this is the preferred name for this taxon")
        '
        'lblAuthority
        '
        Me.lblAuthority.Location = New System.Drawing.Point(10, 34)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(64, 16)
        Me.lblAuthority.TabIndex = 79
        Me.lblAuthority.Text = "Authority:"
        Me.lblAuthority.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGroup
        '
        Me.lblGroup.Location = New System.Drawing.Point(10, 59)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(64, 16)
        Me.lblGroup.TabIndex = 78
        Me.lblGroup.Text = "Group:"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersionKey
        '
        Me.lblVersionKey.Location = New System.Drawing.Point(-8, 85)
        Me.lblVersionKey.Name = "lblVersionKey"
        Me.lblVersionKey.Size = New System.Drawing.Size(82, 20)
        Me.lblVersionKey.TabIndex = 77
        Me.lblVersionKey.Text = "Version key:"
        Me.lblVersionKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(80, 6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(193, 20)
        Me.txtName.TabIndex = 88
        Me.ToolTip1.SetToolTip(Me.txtName, "Enter a search term for NBN taxon dictionary")
        '
        'txtTaxonGroup
        '
        Me.txtTaxonGroup.Enabled = False
        Me.txtTaxonGroup.Location = New System.Drawing.Point(80, 59)
        Me.txtTaxonGroup.Name = "txtTaxonGroup"
        Me.txtTaxonGroup.Size = New System.Drawing.Size(223, 20)
        Me.txtTaxonGroup.TabIndex = 89
        Me.ToolTip1.SetToolTip(Me.txtTaxonGroup, "Taxon group")
        '
        'butOkay
        '
        Me.butOkay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butOkay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butOkay.Location = New System.Drawing.Point(598, 399)
        Me.butOkay.Name = "butOkay"
        Me.butOkay.Size = New System.Drawing.Size(63, 24)
        Me.butOkay.TabIndex = 90
        Me.butOkay.Text = "Okay"
        Me.ToolTip1.SetToolTip(Me.butOkay, "Apply NBN Gateway overlay to map")
        Me.butOkay.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butCancel.Location = New System.Drawing.Point(529, 399)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(63, 24)
        Me.butCancel.TabIndex = 91
        Me.butCancel.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.butCancel, "Remove NBN Gateway overlay from map")
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboRecords)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.nudEndYear)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.nudStartYear)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nudOpacity)
        Me.GroupBox1.Controls.Add(Me.cbo100m)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo1km)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbo2km)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo10km)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 129)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NBN grid map display options"
        '
        'cboRecords
        '
        Me.cboRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecords.FormattingEnabled = True
        Me.cboRecords.Items.AddRange(New Object() {"Presence", "Absence", "All"})
        Me.cboRecords.Location = New System.Drawing.Point(229, 97)
        Me.cboRecords.Name = "cboRecords"
        Me.cboRecords.Size = New System.Drawing.Size(60, 21)
        Me.cboRecords.TabIndex = 108
        Me.cboRecords.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(149, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 20)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Records:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(161, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 20)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "End year:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudEndYear
        '
        Me.nudEndYear.Location = New System.Drawing.Point(229, 71)
        Me.nudEndYear.Maximum = New Decimal(New Integer() {2012, 0, 0, 0})
        Me.nudEndYear.Minimum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.nudEndYear.Name = "nudEndYear"
        Me.nudEndYear.Size = New System.Drawing.Size(60, 20)
        Me.nudEndYear.TabIndex = 105
        Me.ToolTip1.SetToolTip(Me.nudEndYear, "Set the end year for selecting NBN records for the distribution map")
        Me.nudEndYear.Value = New Decimal(New Integer() {2012, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(161, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 20)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Start year:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudStartYear
        '
        Me.nudStartYear.Location = New System.Drawing.Point(229, 43)
        Me.nudStartYear.Maximum = New Decimal(New Integer() {2012, 0, 0, 0})
        Me.nudStartYear.Minimum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.nudStartYear.Name = "nudStartYear"
        Me.nudStartYear.Size = New System.Drawing.Size(60, 20)
        Me.nudStartYear.TabIndex = 103
        Me.ToolTip1.SetToolTip(Me.nudStartYear, "Set the start year for selecting NBN records for the distribution map")
        Me.nudStartYear.Value = New Decimal(New Integer() {1800, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(164, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 20)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Opacity:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudOpacity
        '
        Me.nudOpacity.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudOpacity.Location = New System.Drawing.Point(229, 16)
        Me.nudOpacity.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudOpacity.Name = "nudOpacity"
        Me.nudOpacity.Size = New System.Drawing.Size(60, 20)
        Me.nudOpacity.TabIndex = 101
        Me.ToolTip1.SetToolTip(Me.nudOpacity, "Set the opacity of the NBN gridmap overlay")
        Me.nudOpacity.Value = New Decimal(New Integer() {75, 0, 0, 0})
        '
        'cbo100m
        '
        Me.cbo100m.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo100m.FormattingEnabled = True
        Me.cbo100m.Items.AddRange(New Object() {"Auto", "On", "Off"})
        Me.cbo100m.Location = New System.Drawing.Point(89, 96)
        Me.cbo100m.Name = "cbo100m"
        Me.cbo100m.Size = New System.Drawing.Size(60, 21)
        Me.cbo100m.TabIndex = 100
        Me.ToolTip1.SetToolTip(Me.cbo100m, "Set the visibility of 6 fig GR squares")
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "6 fig. squares:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo1km
        '
        Me.cbo1km.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo1km.FormattingEnabled = True
        Me.cbo1km.Items.AddRange(New Object() {"Auto", "On", "Off"})
        Me.cbo1km.Location = New System.Drawing.Point(89, 70)
        Me.cbo1km.Name = "cbo1km"
        Me.cbo1km.Size = New System.Drawing.Size(60, 21)
        Me.cbo1km.TabIndex = 98
        Me.ToolTip1.SetToolTip(Me.cbo1km, "Set the visibility of 1 km squares")
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "1 km squares:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo2km
        '
        Me.cbo2km.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo2km.FormattingEnabled = True
        Me.cbo2km.Items.AddRange(New Object() {"Auto", "On", "Off"})
        Me.cbo2km.Location = New System.Drawing.Point(89, 44)
        Me.cbo2km.Name = "cbo2km"
        Me.cbo2km.Size = New System.Drawing.Size(60, 21)
        Me.cbo2km.TabIndex = 96
        Me.ToolTip1.SetToolTip(Me.cbo2km, "Set the visibility of 2 km squares")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "2 km squares:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo10km
        '
        Me.cbo10km.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo10km.FormattingEnabled = True
        Me.cbo10km.Items.AddRange(New Object() {"Auto", "On", "Off"})
        Me.cbo10km.Location = New System.Drawing.Point(89, 17)
        Me.cbo10km.Name = "cbo10km"
        Me.cbo10km.Size = New System.Drawing.Size(60, 21)
        Me.cbo10km.TabIndex = 94
        Me.ToolTip1.SetToolTip(Me.cbo10km, "Set the visibility of 10 km squares")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "10 km squares:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbSpecificUser)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.rbPublic)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txtNBNUser)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.txtNBNPassword)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 295)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(295, 101)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NBN Gateway user credentials"
        '
        'rbSpecificUser
        '
        Me.rbSpecificUser.AutoSize = True
        Me.rbSpecificUser.Location = New System.Drawing.Point(153, 19)
        Me.rbSpecificUser.Name = "rbSpecificUser"
        Me.rbSpecificUser.Size = New System.Drawing.Size(92, 17)
        Me.rbSpecificUser.TabIndex = 35
        Me.rbSpecificUser.Text = "Specified user"
        Me.ToolTip1.SetToolTip(Me.rbSpecificUser, "Use access level for a specific NBN Gateway user")
        Me.rbSpecificUser.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(40, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Access:"
        '
        'rbPublic
        '
        Me.rbPublic.AutoSize = True
        Me.rbPublic.Checked = True
        Me.rbPublic.Location = New System.Drawing.Point(92, 19)
        Me.rbPublic.Name = "rbPublic"
        Me.rbPublic.Size = New System.Drawing.Size(54, 17)
        Me.rbPublic.TabIndex = 33
        Me.rbPublic.TabStop = True
        Me.rbPublic.Text = "Public"
        Me.ToolTip1.SetToolTip(Me.rbPublic, "Use public level access")
        Me.rbPublic.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(29, 46)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 13)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "NBN user:"
        '
        'txtNBNUser
        '
        Me.txtNBNUser.Location = New System.Drawing.Point(91, 43)
        Me.txtNBNUser.Name = "txtNBNUser"
        Me.txtNBNUser.Size = New System.Drawing.Size(198, 20)
        Me.txtNBNUser.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.txtNBNUser, "NBN user name")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(4, 72)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 13)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "NBN password:"
        '
        'txtNBNPassword
        '
        Me.txtNBNPassword.Location = New System.Drawing.Point(91, 69)
        Me.txtNBNPassword.Name = "txtNBNPassword"
        Me.txtNBNPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNBNPassword.Size = New System.Drawing.Size(198, 20)
        Me.txtNBNPassword.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.txtNBNPassword, "NBN user password")
        '
        'frmNBNTaxonSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 425)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOkay)
        Me.Controls.Add(Me.txtTaxonGroup)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.butSearchScientificName)
        Me.Controls.Add(Me.txtAuthority)
        Me.Controls.Add(Me.txtVersionKey)
        Me.Controls.Add(Me.chkWellFormed)
        Me.Controls.Add(Me.chkScientific)
        Me.Controls.Add(Me.chkPreferred)
        Me.Controls.Add(Me.lblAuthority)
        Me.Controls.Add(Me.lblGroup)
        Me.Controls.Add(Me.lblVersionKey)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "frmNBNTaxonSelection"
        Me.Text = "NBN mapping taxon selection"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents butSearchScientificName As System.Windows.Forms.Button
    Friend WithEvents txtAuthority As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionKey As System.Windows.Forms.TextBox
    Friend WithEvents chkWellFormed As System.Windows.Forms.CheckBox
    Friend WithEvents chkScientific As System.Windows.Forms.CheckBox
    Friend WithEvents chkPreferred As System.Windows.Forms.CheckBox
    Friend WithEvents lblAuthority As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblVersionKey As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imlTreeView As System.Windows.Forms.ImageList
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxonGroup As System.Windows.Forms.TextBox
    Friend WithEvents butOkay As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo10km As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo2km As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo1km As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo100m As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboRecords As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSpecificUser As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rbPublic As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtNBNUser As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtNBNPassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
