<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageProperties
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
        Me.tcImageProps = New System.Windows.Forms.TabControl
        Me.tabComment = New System.Windows.Forms.TabPage
        Me.lblHeadline = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.tabSource = New System.Windows.Forms.TabPage
        Me.lblInDB = New System.Windows.Forms.Label
        Me.butResetImage = New System.Windows.Forms.Button
        Me.lblFullPath = New System.Windows.Forms.Label
        Me.lblRelativePath = New System.Windows.Forms.Label
        Me.pbThumbFromFull = New System.Windows.Forms.PictureBox
        Me.pbThumbFromRelative = New System.Windows.Forms.PictureBox
        Me.pbThumbInDB = New System.Windows.Forms.PictureBox
        Me.cbStoreInDB = New System.Windows.Forms.CheckBox
        Me.tabEXIF = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblLightSource = New System.Windows.Forms.Label
        Me.lblFlash = New System.Windows.Forms.Label
        Me.lblFocalLength = New System.Windows.Forms.Label
        Me.lblSubjectDistance = New System.Windows.Forms.Label
        Me.lblISOSensitivity = New System.Windows.Forms.Label
        Me.lblAperture = New System.Windows.Forms.Label
        Me.lblExposureMode = New System.Windows.Forms.Label
        Me.lblExposureProgram = New System.Windows.Forms.Label
        Me.lblExposureTime = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLon = New System.Windows.Forms.Label
        Me.lblLat = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblDigitised = New System.Windows.Forms.Label
        Me.lblOriginal = New System.Windows.Forms.Label
        Me.lblGeneral = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblSoftware = New System.Windows.Forms.Label
        Me.lblModel = New System.Windows.Forms.Label
        Me.lblMaker = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblOrientation = New System.Windows.Forms.Label
        Me.lblResolution = New System.Windows.Forms.Label
        Me.lblDimensions = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.butCommit = New System.Windows.Forms.Button
        Me.butCancel = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.tcImageProps.SuspendLayout()
        Me.tabComment.SuspendLayout()
        Me.tabSource.SuspendLayout()
        CType(Me.pbThumbFromFull, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbThumbFromRelative, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbThumbInDB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEXIF.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcImageProps
        '
        Me.tcImageProps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcImageProps.Controls.Add(Me.tabComment)
        Me.tcImageProps.Controls.Add(Me.tabSource)
        Me.tcImageProps.Controls.Add(Me.tabEXIF)
        Me.tcImageProps.Location = New System.Drawing.Point(-1, 3)
        Me.tcImageProps.Name = "tcImageProps"
        Me.tcImageProps.SelectedIndex = 0
        Me.tcImageProps.Size = New System.Drawing.Size(494, 454)
        Me.tcImageProps.TabIndex = 0
        '
        'tabComment
        '
        Me.tabComment.Controls.Add(Me.lblHeadline)
        Me.tabComment.Controls.Add(Me.txtComment)
        Me.tabComment.Location = New System.Drawing.Point(4, 22)
        Me.tabComment.Name = "tabComment"
        Me.tabComment.Size = New System.Drawing.Size(486, 428)
        Me.tabComment.TabIndex = 2
        Me.tabComment.Text = "Comment"
        Me.tabComment.UseVisualStyleBackColor = True
        '
        'lblHeadline
        '
        Me.lblHeadline.AutoSize = True
        Me.lblHeadline.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadline.Location = New System.Drawing.Point(3, 4)
        Me.lblHeadline.Name = "lblHeadline"
        Me.lblHeadline.Size = New System.Drawing.Size(110, 13)
        Me.lblHeadline.TabIndex = 1
        Me.lblHeadline.Text = "Comment headline"
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(2, 20)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(481, 405)
        Me.txtComment.TabIndex = 0
        Me.tt.SetToolTip(Me.txtComment, "You can type in a narrative comment " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "here to describe the picture.")
        '
        'tabSource
        '
        Me.tabSource.Controls.Add(Me.lblInDB)
        Me.tabSource.Controls.Add(Me.butResetImage)
        Me.tabSource.Controls.Add(Me.lblFullPath)
        Me.tabSource.Controls.Add(Me.lblRelativePath)
        Me.tabSource.Controls.Add(Me.pbThumbFromFull)
        Me.tabSource.Controls.Add(Me.pbThumbFromRelative)
        Me.tabSource.Controls.Add(Me.pbThumbInDB)
        Me.tabSource.Controls.Add(Me.cbStoreInDB)
        Me.tabSource.Location = New System.Drawing.Point(4, 22)
        Me.tabSource.Name = "tabSource"
        Me.tabSource.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSource.Size = New System.Drawing.Size(486, 428)
        Me.tabSource.TabIndex = 0
        Me.tabSource.Text = "Source"
        Me.tabSource.UseVisualStyleBackColor = True
        '
        'lblInDB
        '
        Me.lblInDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInDB.Location = New System.Drawing.Point(135, 26)
        Me.lblInDB.Name = "lblInDB"
        Me.lblInDB.Size = New System.Drawing.Size(340, 100)
        Me.lblInDB.TabIndex = 7
        Me.lblInDB.Text = "lblInDB"
        '
        'butResetImage
        '
        Me.butResetImage.Location = New System.Drawing.Point(6, 384)
        Me.butResetImage.Name = "butResetImage"
        Me.butResetImage.Size = New System.Drawing.Size(120, 22)
        Me.butResetImage.TabIndex = 6
        Me.butResetImage.Text = "Reset image"
        Me.tt.SetToolTip(Me.butResetImage, "Use this button to browse to the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "image again - effectively resetting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the image" & _
                ".")
        Me.butResetImage.UseVisualStyleBackColor = True
        '
        'lblFullPath
        '
        Me.lblFullPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFullPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullPath.Location = New System.Drawing.Point(135, 258)
        Me.lblFullPath.Name = "lblFullPath"
        Me.lblFullPath.Size = New System.Drawing.Size(340, 120)
        Me.lblFullPath.TabIndex = 5
        Me.lblFullPath.Text = "lblFullPath"
        '
        'lblRelativePath
        '
        Me.lblRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRelativePath.Location = New System.Drawing.Point(135, 132)
        Me.lblRelativePath.Name = "lblRelativePath"
        Me.lblRelativePath.Size = New System.Drawing.Size(340, 120)
        Me.lblRelativePath.TabIndex = 4
        Me.lblRelativePath.Text = "lblRelativePath"
        '
        'pbThumbFromFull
        '
        Me.pbThumbFromFull.BackColor = System.Drawing.Color.Silver
        Me.pbThumbFromFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbThumbFromFull.Location = New System.Drawing.Point(6, 258)
        Me.pbThumbFromFull.Name = "pbThumbFromFull"
        Me.pbThumbFromFull.Size = New System.Drawing.Size(120, 120)
        Me.pbThumbFromFull.TabIndex = 3
        Me.pbThumbFromFull.TabStop = False
        '
        'pbThumbFromRelative
        '
        Me.pbThumbFromRelative.BackColor = System.Drawing.Color.Silver
        Me.pbThumbFromRelative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbThumbFromRelative.Location = New System.Drawing.Point(6, 132)
        Me.pbThumbFromRelative.Name = "pbThumbFromRelative"
        Me.pbThumbFromRelative.Size = New System.Drawing.Size(120, 120)
        Me.pbThumbFromRelative.TabIndex = 2
        Me.pbThumbFromRelative.TabStop = False
        '
        'pbThumbInDB
        '
        Me.pbThumbInDB.BackColor = System.Drawing.Color.Silver
        Me.pbThumbInDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbThumbInDB.Location = New System.Drawing.Point(6, 6)
        Me.pbThumbInDB.Name = "pbThumbInDB"
        Me.pbThumbInDB.Size = New System.Drawing.Size(120, 120)
        Me.pbThumbInDB.TabIndex = 1
        Me.pbThumbInDB.TabStop = False
        '
        'cbStoreInDB
        '
        Me.cbStoreInDB.AutoSize = True
        Me.cbStoreInDB.Location = New System.Drawing.Point(138, 6)
        Me.cbStoreInDB.Name = "cbStoreInDB"
        Me.cbStoreInDB.Size = New System.Drawing.Size(109, 17)
        Me.cbStoreInDB.TabIndex = 0
        Me.cbStoreInDB.Text = "Store in database"
        Me.tt.SetToolTip(Me.cbStoreInDB, "If you tick this box, then the image is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "actually stored within the database." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Th" & _
                "e advantage is that you will not" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "lose the picture, but the disadvantage" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is tha" & _
                "t it takes up lots of space in the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DB.")
        Me.cbStoreInDB.UseVisualStyleBackColor = True
        '
        'tabEXIF
        '
        Me.tabEXIF.Controls.Add(Me.GroupBox5)
        Me.tabEXIF.Controls.Add(Me.GroupBox4)
        Me.tabEXIF.Controls.Add(Me.GroupBox3)
        Me.tabEXIF.Controls.Add(Me.GroupBox2)
        Me.tabEXIF.Controls.Add(Me.GroupBox1)
        Me.tabEXIF.Location = New System.Drawing.Point(4, 22)
        Me.tabEXIF.Name = "tabEXIF"
        Me.tabEXIF.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEXIF.Size = New System.Drawing.Size(486, 428)
        Me.tabEXIF.TabIndex = 1
        Me.tabEXIF.Text = "EXIF metadata"
        Me.tabEXIF.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.lblLightSource)
        Me.GroupBox5.Controls.Add(Me.lblFlash)
        Me.GroupBox5.Controls.Add(Me.lblFocalLength)
        Me.GroupBox5.Controls.Add(Me.lblSubjectDistance)
        Me.GroupBox5.Controls.Add(Me.lblISOSensitivity)
        Me.GroupBox5.Controls.Add(Me.lblAperture)
        Me.GroupBox5.Controls.Add(Me.lblExposureMode)
        Me.GroupBox5.Controls.Add(Me.lblExposureProgram)
        Me.GroupBox5.Controls.Add(Me.lblExposureTime)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 232)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(239, 190)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Shooting conditions"
        '
        'lblLightSource
        '
        Me.lblLightSource.AutoSize = True
        Me.lblLightSource.Location = New System.Drawing.Point(7, 165)
        Me.lblLightSource.Name = "lblLightSource"
        Me.lblLightSource.Size = New System.Drawing.Size(74, 13)
        Me.lblLightSource.TabIndex = 8
        Me.lblLightSource.Text = "lblLightSource"
        '
        'lblFlash
        '
        Me.lblFlash.AutoSize = True
        Me.lblFlash.Location = New System.Drawing.Point(7, 146)
        Me.lblFlash.Name = "lblFlash"
        Me.lblFlash.Size = New System.Drawing.Size(42, 13)
        Me.lblFlash.TabIndex = 7
        Me.lblFlash.Text = "lblFlash"
        '
        'lblFocalLength
        '
        Me.lblFocalLength.AutoSize = True
        Me.lblFocalLength.Location = New System.Drawing.Point(7, 128)
        Me.lblFocalLength.Name = "lblFocalLength"
        Me.lblFocalLength.Size = New System.Drawing.Size(76, 13)
        Me.lblFocalLength.TabIndex = 6
        Me.lblFocalLength.Text = "lblFocalLength"
        '
        'lblSubjectDistance
        '
        Me.lblSubjectDistance.AutoSize = True
        Me.lblSubjectDistance.Location = New System.Drawing.Point(7, 110)
        Me.lblSubjectDistance.Name = "lblSubjectDistance"
        Me.lblSubjectDistance.Size = New System.Drawing.Size(95, 13)
        Me.lblSubjectDistance.TabIndex = 5
        Me.lblSubjectDistance.Text = "lblSubjectDistance"
        '
        'lblISOSensitivity
        '
        Me.lblISOSensitivity.AutoSize = True
        Me.lblISOSensitivity.Location = New System.Drawing.Point(7, 93)
        Me.lblISOSensitivity.Name = "lblISOSensitivity"
        Me.lblISOSensitivity.Size = New System.Drawing.Size(82, 13)
        Me.lblISOSensitivity.TabIndex = 4
        Me.lblISOSensitivity.Text = "lblISOSensitivity"
        '
        'lblAperture
        '
        Me.lblAperture.AutoSize = True
        Me.lblAperture.Location = New System.Drawing.Point(7, 75)
        Me.lblAperture.Name = "lblAperture"
        Me.lblAperture.Size = New System.Drawing.Size(57, 13)
        Me.lblAperture.TabIndex = 3
        Me.lblAperture.Text = "lblAperture"
        '
        'lblExposureMode
        '
        Me.lblExposureMode.AutoSize = True
        Me.lblExposureMode.Location = New System.Drawing.Point(7, 57)
        Me.lblExposureMode.Name = "lblExposureMode"
        Me.lblExposureMode.Size = New System.Drawing.Size(88, 13)
        Me.lblExposureMode.TabIndex = 2
        Me.lblExposureMode.Text = "lblExposureMode"
        '
        'lblExposureProgram
        '
        Me.lblExposureProgram.AutoSize = True
        Me.lblExposureProgram.Location = New System.Drawing.Point(7, 39)
        Me.lblExposureProgram.Name = "lblExposureProgram"
        Me.lblExposureProgram.Size = New System.Drawing.Size(100, 13)
        Me.lblExposureProgram.TabIndex = 1
        Me.lblExposureProgram.Text = "lblExposureProgram"
        '
        'lblExposureTime
        '
        Me.lblExposureTime.AutoSize = True
        Me.lblExposureTime.Location = New System.Drawing.Point(7, 20)
        Me.lblExposureTime.Name = "lblExposureTime"
        Me.lblExposureTime.Size = New System.Drawing.Size(84, 13)
        Me.lblExposureTime.TabIndex = 0
        Me.lblExposureTime.Text = "lblExposureTime"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lblLon)
        Me.GroupBox4.Controls.Add(Me.lblLat)
        Me.GroupBox4.Location = New System.Drawing.Point(256, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 78)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Location"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 2
        '
        'lblLon
        '
        Me.lblLon.AutoSize = True
        Me.lblLon.Location = New System.Drawing.Point(7, 39)
        Me.lblLon.Name = "lblLon"
        Me.lblLon.Size = New System.Drawing.Size(35, 13)
        Me.lblLon.TabIndex = 1
        Me.lblLon.Text = "lblLon"
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(7, 20)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(32, 13)
        Me.lblLat.TabIndex = 0
        Me.lblLat.Text = "lblLat"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDigitised)
        Me.GroupBox3.Controls.Add(Me.lblOriginal)
        Me.GroupBox3.Controls.Add(Me.lblGeneral)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 78)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Date and time"
        '
        'lblDigitised
        '
        Me.lblDigitised.AutoSize = True
        Me.lblDigitised.Location = New System.Drawing.Point(6, 57)
        Me.lblDigitised.Name = "lblDigitised"
        Me.lblDigitised.Size = New System.Drawing.Size(57, 13)
        Me.lblDigitised.TabIndex = 2
        Me.lblDigitised.Text = "lblDigitised"
        '
        'lblOriginal
        '
        Me.lblOriginal.AutoSize = True
        Me.lblOriginal.Location = New System.Drawing.Point(6, 39)
        Me.lblOriginal.Name = "lblOriginal"
        Me.lblOriginal.Size = New System.Drawing.Size(52, 13)
        Me.lblOriginal.TabIndex = 1
        Me.lblOriginal.Text = "lblOriginal"
        '
        'lblGeneral
        '
        Me.lblGeneral.AutoSize = True
        Me.lblGeneral.Location = New System.Drawing.Point(6, 20)
        Me.lblGeneral.Name = "lblGeneral"
        Me.lblGeneral.Size = New System.Drawing.Size(54, 13)
        Me.lblGeneral.TabIndex = 0
        Me.lblGeneral.Text = "lblGeneral"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblSoftware)
        Me.GroupBox2.Controls.Add(Me.lblModel)
        Me.GroupBox2.Controls.Add(Me.lblMaker)
        Me.GroupBox2.Location = New System.Drawing.Point(256, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(212, 190)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Equipment"
        '
        'lblSoftware
        '
        Me.lblSoftware.AutoSize = True
        Me.lblSoftware.Location = New System.Drawing.Point(7, 57)
        Me.lblSoftware.Name = "lblSoftware"
        Me.lblSoftware.Size = New System.Drawing.Size(59, 13)
        Me.lblSoftware.TabIndex = 2
        Me.lblSoftware.Text = "lblSoftware"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(7, 39)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(46, 13)
        Me.lblModel.TabIndex = 1
        Me.lblModel.Text = "lblModel"
        '
        'lblMaker
        '
        Me.lblMaker.AutoSize = True
        Me.lblMaker.Location = New System.Drawing.Point(7, 20)
        Me.lblMaker.Name = "lblMaker"
        Me.lblMaker.Size = New System.Drawing.Size(47, 13)
        Me.lblMaker.TabIndex = 0
        Me.lblMaker.Text = "lblMaker"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblCopyright)
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Controls.Add(Me.lblOrientation)
        Me.GroupBox1.Controls.Add(Me.lblResolution)
        Me.GroupBox1.Controls.Add(Me.lblDimensions)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(7, 110)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(61, 13)
        Me.lblCopyright.TabIndex = 5
        Me.lblCopyright.Text = "lblCopyright"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(7, 93)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(70, 13)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "lblDescription"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(7, 75)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(37, 13)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "lblTitle"
        '
        'lblOrientation
        '
        Me.lblOrientation.AutoSize = True
        Me.lblOrientation.Location = New System.Drawing.Point(7, 57)
        Me.lblOrientation.Name = "lblOrientation"
        Me.lblOrientation.Size = New System.Drawing.Size(68, 13)
        Me.lblOrientation.TabIndex = 2
        Me.lblOrientation.Text = "lblOrientation"
        '
        'lblResolution
        '
        Me.lblResolution.AutoSize = True
        Me.lblResolution.Location = New System.Drawing.Point(7, 39)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(67, 13)
        Me.lblResolution.TabIndex = 1
        Me.lblResolution.Text = "lblResolution"
        '
        'lblDimensions
        '
        Me.lblDimensions.AutoSize = True
        Me.lblDimensions.Location = New System.Drawing.Point(7, 20)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(71, 13)
        Me.lblDimensions.TabIndex = 0
        Me.lblDimensions.Text = "lblDimensions"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 91)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(121, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(109, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Store in database"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'butCommit
        '
        Me.butCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCommit.Location = New System.Drawing.Point(411, 463)
        Me.butCommit.Name = "butCommit"
        Me.butCommit.Size = New System.Drawing.Size(76, 24)
        Me.butCommit.TabIndex = 1
        Me.butCommit.Text = "Commit"
        Me.butCommit.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancel.Location = New System.Drawing.Point(329, 463)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(76, 24)
        Me.butCancel.TabIndex = 2
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmImageProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 492)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butCommit)
        Me.Controls.Add(Me.tcImageProps)
        Me.Name = "frmImageProperties"
        Me.Text = "Image properties"
        Me.tcImageProps.ResumeLayout(False)
        Me.tabComment.ResumeLayout(False)
        Me.tabComment.PerformLayout()
        Me.tabSource.ResumeLayout(False)
        Me.tabSource.PerformLayout()
        CType(Me.pbThumbFromFull, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbThumbFromRelative, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbThumbInDB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEXIF.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcImageProps As System.Windows.Forms.TabControl
    Friend WithEvents tabComment As System.Windows.Forms.TabPage
    Friend WithEvents tabSource As System.Windows.Forms.TabPage
    Friend WithEvents tabEXIF As System.Windows.Forms.TabPage
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents pbThumbFromFull As System.Windows.Forms.PictureBox
    Friend WithEvents pbThumbFromRelative As System.Windows.Forms.PictureBox
    Friend WithEvents pbThumbInDB As System.Windows.Forms.PictureBox
    Friend WithEvents cbStoreInDB As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblRelativePath As System.Windows.Forms.Label
    Friend WithEvents butResetImage As System.Windows.Forms.Button
    Friend WithEvents lblFullPath As System.Windows.Forms.Label
    Friend WithEvents lblInDB As System.Windows.Forms.Label
    Friend WithEvents butCommit As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblHeadline As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblOrientation As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblDimensions As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSoftware As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblMaker As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDigitised As System.Windows.Forms.Label
    Friend WithEvents lblOriginal As System.Windows.Forms.Label
    Friend WithEvents lblGeneral As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLon As System.Windows.Forms.Label
    Friend WithEvents lblLat As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFocalLength As System.Windows.Forms.Label
    Friend WithEvents lblSubjectDistance As System.Windows.Forms.Label
    Friend WithEvents lblISOSensitivity As System.Windows.Forms.Label
    Friend WithEvents lblAperture As System.Windows.Forms.Label
    Friend WithEvents lblExposureMode As System.Windows.Forms.Label
    Friend WithEvents lblExposureProgram As System.Windows.Forms.Label
    Friend WithEvents lblExposureTime As System.Windows.Forms.Label
    Friend WithEvents lblLightSource As System.Windows.Forms.Label
    Friend WithEvents lblFlash As System.Windows.Forms.Label
    Friend WithEvents tt As System.Windows.Forms.ToolTip
End Class
