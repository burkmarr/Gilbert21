Imports System.Data.SQLite
Imports System.IO

Public Class frmImageProperties

    Dim bmpPrecedent As Bitmap
    Dim intFileID
    Dim arrInDB() As Byte
    Dim strRelativePath As String
    Dim strFullPath As String
    Dim strComment As String

    Private bDialogCommitted As Boolean
    Public ReadOnly Property DialogCommitted() As Boolean
        Get
            Return bDialogCommitted
        End Get
    End Property


    Public Sub InitForFileID(ByVal strFileID As String)

        bmpPrecedent = Nothing
        arrInDB = Nothing
        strRelativePath = ""
        strFullPath = ""
        strComment = ""

        Dim db As clsDB = New clsDB
        Dim strSQL As String = "select * from media where FileID = " & strFileID
        Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, db.conMedia)
        Dim dtMedia As DataTable = New DataTable()
        da.Fill(dtMedia)
        Dim row As DataRow = dtMedia.Rows(0)

        If Not cfun.HasNoValue(row("Data")) Then
            arrInDB = row("Data")
        End If

        If Not cfun.HasNoValue(row("RelativePath")) Then
            strRelativePath = row("RelativePath")
        End If

        If Not cfun.HasNoValue(row("FullPath")) Then
            strFullPath = row("FullPath")
        End If

        If Not cfun.HasNoValue(row("Comment")) Then
            strComment = row("Comment")
        End If

        intFileID = CInt(strFileID)

        InitControls()
    End Sub

    Public Sub InitControls()

        Dim bmp As Bitmap
        Dim exif As clsExifWorks = Nothing

        pbThumbFromFull.Image = Nothing
        pbThumbFromRelative.Image = Nothing
        pbThumbInDB.Image = Nothing
        cbStoreInDB.Checked = False

        'If the image is stored directly in the DB, then display it.
        If Not arrInDB Is Nothing Then
            Try
                bmpPrecedent = cfun.GetImageFromByteArray(arrInDB)
                pbThumbInDB.Image = cfun.ThumbFromImage(bmpPrecedent, 120)
                lblInDB.Text = "The image is stored directly in the database. This image has precedence."
                lblInDB.ForeColor = Color.Green
                cbStoreInDB.Checked = True
            Catch
                lblInDB.Text = "Failed to load the image from the database."
                lblInDB.ForeColor = Color.Red
            End Try
        Else
            lblInDB.Text = "The image is not stored directly in the database."
            lblInDB.ForeColor = Color.Black
        End If

        'If the relative path of the image points to an existing file, then display it.
        Dim strBuiltPath As String = Path.Combine(frmOptions.txtDBFolder.Text, strRelativePath)
        If strRelativePath = "" Then
            lblRelativePath.Text = "A relative path is not specified for the image."
            lblRelativePath.ForeColor = Color.Black
        ElseIf File.Exists(strBuiltPath) Then
            Try
                bmp = New Bitmap(strBuiltPath)
                pbThumbFromRelative.Image = cfun.ThumbFromImage(bmp, 120)
                lblRelativePath.Text = "Successfully loaded '" & strBuiltPath & "' (from relative path '" & strRelativePath & "')."
                lblRelativePath.ForeColor = Color.Green
                If bmpPrecedent Is Nothing Then
                    lblRelativePath.Text = lblRelativePath.Text & " This image has precedence."
                    bmpPrecedent = bmp.Clone()
                End If
            Catch
                lblFullPath.Text = "Couldn't load '" & strBuiltPath & "' (from relative path '" & strRelativePath & "')."
                lblFullPath.ForeColor = Color.Red
            End Try
        Else
            lblRelativePath.Text = "Couldn't find '" & strBuiltPath & "' (from relative path '" & strRelativePath & "')."
            lblRelativePath.ForeColor = Color.Red
        End If

        'If the full path of the image points to an existing file, then display it.
        If strFullPath = "" Then
            lblFullPath.Text = "A full path is not specified for the image."
            lblFullPath.ForeColor = Color.Black
        ElseIf File.Exists(strFullPath) Then
            Try
                bmp = New Bitmap(strFullPath)
                pbThumbFromFull.Image = cfun.ThumbFromImage(bmp, 120)
                lblFullPath.Text = "Successfully loaded '" & strFullPath & "' from the specified full pathname."
                lblFullPath.ForeColor = Color.Green
                If bmpPrecedent Is Nothing Then
                    lblFullPath.Text = lblFullPath.Text & " This image has precedence."
                    bmpPrecedent = bmp.Clone()
                End If
            Catch
                lblFullPath.Text = "Couldn't load '" & strFullPath & "' specified by the full pathname."
                lblFullPath.ForeColor = Color.Red
            End Try
        Else
            lblFullPath.Text = "Couldn't find '" & strFullPath & "' specified by the full pathname."
            lblFullPath.ForeColor = Color.Red
        End If

        'Comment
        txtComment.Text = strComment

        'EXIF properties
        If Not bmpPrecedent Is Nothing Then
            exif = New clsExifWorks(bmpPrecedent)
            'lblExif.Text = exif.ToString & vbCrLf & "Lat: " & exif.Latitude & vbCrLf & "Lon: " & exif.Longitude

            lblDimensions.Text = "Dimensions: " & exif.Width & " x " & exif.Height & " px"
            lblResolution.Text = "Resolution: " & exif.ResolutionX & " x " & exif.ResolutionY & " dpi"
            lblOrientation.Text = "Orientation: " & exif.OrientationString
            lblTitle.Text = "Title: " & exif.Title
            lblDescription.Text = "Description: " & exif.Description
            lblCopyright.Text = "Copyright: " & exif.Copyright
            lblMaker.Text = "Maker: " & exif.EquipmentMaker
            lblModel.Text = "Model: " & exif.EquipmentModel
            lblSoftware.Text = "Software: " & exif.Software
            lblGeneral.Text = "General: " & exif.DateTimeLastModified.ToString()
            lblOriginal.Text = "Original: " & exif.DateTimeOriginal.ToString()
            lblDigitised.Text = "Digitised: " & exif.DateTimeDigitized.ToString()
            lblLat.Text = "Latitude: " & exif.Latitude
            lblLon.Text = "Longitude: " & exif.Longitude
            lblExposureTime.Text = "Exposure time: " & exif.ExposureTime.ToString("N4") & " s"
            lblExposureProgram.Text = "Exposure program: " & exif.ExposureProgramString
            lblExposureMode.Text = "Exposure mode: " & exif.ExposureMeteringModeString
            lblAperture.Text = "Aperture: F" & exif.Aperture.ToString("N2")
            lblISOSensitivity.Text = "ISO sensitivity: " & exif.ISO
            lblSubjectDistance.Text = "Subject distance: " & exif.SubjectDistance.ToString("N2") & " m"
            lblFocalLength.Text = "Focal length: " & exif.FocalLength
            lblFlash.Text = "Flash: " & exif.FlashModeString
            lblLightSource.Text = "Light source (WB): " & exif.LightSourceString
        End If
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        bDialogCommitted = False
        Me.Close()
    End Sub

    Private Sub butCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCommit.Click

        'Update the blah blah

        If Not bmpPrecedent Is Nothing Then

            Dim strFileExt As String = ""
            If strRelativePath <> "" Then
                strFileExt = strRelativePath.Substring(strRelativePath.Length - 3)
            ElseIf strFullPath <> "" Then
                strFileExt = strFullPath.Substring(strFullPath.Length - 3)
            End If

            Dim db As clsDB = New clsDB
            Dim comMedia As SQLiteCommand = New SQLiteCommand(db.conMedia)

            comMedia.CommandText = "Update Media set FileName=?, FullPath=?, RelativePath=?, Data=?, Comment=?, FileType=?, GenericFileType=?, Thumbnail=? where FileID=?;"
            comMedia.Parameters.AddWithValue("FileName", strFullPath)
            comMedia.Parameters.AddWithValue("FullPath", strFullPath)
            comMedia.Parameters.AddWithValue("RelativePath", strRelativePath)
            If cbStoreInDB.Checked Then
                comMedia.Parameters.AddWithValue("Data", cfun.GetByteArrayFromImg(bmpPrecedent))
            Else
                comMedia.Parameters.AddWithValue("Data", DBNull.Value)
            End If
            comMedia.Parameters.AddWithValue("Comment", txtComment.Text)
            comMedia.Parameters.AddWithValue("FileType", strFileExt)
            comMedia.Parameters.AddWithValue("GenericFileType", "image")
            comMedia.Parameters.AddWithValue("Thumbnail", cfun.GetByteArrayFromImg(cfun.ThumbFromImage(bmpPrecedent, 120)))
            comMedia.Parameters.AddWithValue("FileID", intFileID)
            comMedia.ExecuteNonQuery()

            bDialogCommitted = True
        Else
            bDialogCommitted = False
        End If

        Me.Close()
    End Sub

    Private Sub butResetImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butResetImage.Click

        OpenFileDialog.Filter = "JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.fig|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1
        'OpenFileDialog.InitialDirectory = frmOptions.txtImportFolder.Text

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            strFullPath = OpenFileDialog.FileName
            strRelativePath = cfun.GetRelativePath(OpenFileDialog.FileName)
            arrInDB = Nothing
            bmpPrecedent = Nothing

            InitControls()
        End If
    End Sub

    Private Sub txtComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComment.TextChanged

        Dim strHeadline As String = cfun.GetHeadlineFromText(txtComment.Text)

        If strHeadline.Trim = "" Then

            lblHeadline.Text = "Comment headline"
        Else
            lblHeadline.Text = strHeadline
        End If
    End Sub


End Class