Imports System.Math
Imports System.IO
Imports System.Threading
Imports System.Data.SQLite
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class cfun

    Public Enum RecDateTimeType
        RecDate
        RecTime
    End Enum

    Dim threadSound As Thread

    Shared Sub CheckGazDB()
        'Check that there are records in the gazetteer DB
        Dim db As clsDB = New clsDB
        Dim com As SQLiteCommand
        com = New SQLiteCommand("Select Count(*) from os50kgaz", db.conGazetteer)
        If com.ExecuteScalar() = 0 Then
            MessageBox.Show("You haven't set up your gazetteer yet, so grid references cannot be matched to location names. See how to set up the gazetteer on the quick-start guide in Help.")
        End If
        com.Dispose()
        db.Dispose()
    End Sub

    Shared Function UTC2LocalTime(ByVal utcDateTime As DateTime, ByVal dtType As RecDateTimeType) As String

        'use cst.StandardName to populate timezone in records table

        Dim localDateTime As DateTime = utcDateTime.ToLocalTime()

        If dtType = RecDateTimeType.RecDate Then

            Return (Format(localDateTime, "dd/MM/yyyy"))
        Else
            Return (Format(localDateTime, "HH:mm"))
        End If
    End Function

    Shared Function GetGridRef(ByVal dblLon As Double, ByVal dblLat As Double, ByVal intRes As Integer)

        Dim dblNorthing As Double
        Dim dblEasting As Double
        Dim strGR As String = ""

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        dblNorthing = objGridRef.LatWGS842Northing(dblLat, dblLon, 100)
        dblEasting = objGridRef.LongWGS842Easting(dblLat, dblLon, 100)

        Select Case intRes
            Case 10000
                strGR = objGridRef.EN2Hectad(dblEasting, dblNorthing)
            Case 2000
                strGR = objGridRef.EN2Tetrad(dblEasting, dblNorthing)
            Case 1000
                strGR = objGridRef.EN2Monad(dblEasting, dblNorthing)
            Case 100
                strGR = objGridRef.EN26fig(dblEasting, dblNorthing)
            Case 10
                strGR = objGridRef.EN28fig(dblEasting, dblNorthing)
            Case 1
                strGR = objGridRef.EN210fig(dblEasting, dblNorthing)
        End Select
        Return strGR
    End Function

    Shared Function GetByteArrayFromWav(ByVal strWavFile As String) As Byte()

        strWavFile = strWavFile.Replace(Chr(0), "")
        Dim arr() As Byte

        'Resize array so that it can accomodate the file
        ReDim arr(FileLen(strWavFile) - 1)
        FileOpen(1, strWavFile, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
        FileGet(1, arr)
        FileClose(1)
        Return arr
    End Function

    Shared Sub WriteWAVfromByteArray(ByVal strFile As String, ByVal data() As Byte)

        Dim fStream As New FileStream(strFile, FileMode.Create)
        Dim bw As New BinaryWriter(fStream)
        bw.Write(data)
        bw.Close()
        fStream.Close()
    End Sub

    Shared Function GetByteArraySoundResource(ByVal strm As IO.Stream) As Byte()

        Dim arr(CType(strm.Length, Integer)) As Byte
        strm.Read(arr, 0, Int(CType(strm.Length, Integer)))
        Return arr
    End Function

    Shared Function getVoiceFolder(ByVal bCreate As Boolean) As String

        If File.Exists(frmOptions.txtDB.Text) Then
            Dim strDBFolder As String = Path.GetDirectoryName(frmOptions.txtDB.Text)
            Dim strDBName As String = Path.GetFileName(frmOptions.txtDB.Text)
            Dim strVoiceFolderName As String = strDBName.Substring(0, strDBName.Length - 3) & "voice"
            Dim strVoiceFolder = Path.Combine(strDBFolder, strVoiceFolderName)

            'If the root folder doesn't exist, then create it
            If Not Directory.Exists(strVoiceFolder) And bCreate Then
                Directory.CreateDirectory(strVoiceFolder)
            End If

            Return strVoiceFolder
        Else
            Return ""
        End If
    End Function

    Shared Function getSoundFolder(ByVal bCreate As Boolean) As String

        If File.Exists(frmOptions.txtDB.Text) Then
            Dim strDBFolder As String = Path.GetDirectoryName(frmOptions.txtDB.Text)
            Dim strDBName As String = Path.GetFileName(frmOptions.txtDB.Text)
            Dim strSoundFolderName As String = strDBName.Substring(0, strDBName.Length - 3) & "sound"
            Dim strSoundFolder = Path.Combine(strDBFolder, strSoundFolderName)

            'If the root folder doesn't exist, then create it
            If Not Directory.Exists(strSoundFolder) And bCreate Then
                Directory.CreateDirectory(strSoundFolder)
            End If

            Return strSoundFolder
        Else
            Return ""
        End If
    End Function

    Shared Function getWavFolder(ByVal intID As Integer, ByVal bCreate As Boolean) As String

        Dim strVoiceFolder As String = getVoiceFolder(bCreate)
        Dim strVoiceSubFolder As String

        If intID < 0 Then
            strVoiceSubFolder = Path.Combine(strVoiceFolder, "TempVoice")
            If Not Directory.Exists(strVoiceSubFolder) And bCreate Then
                Directory.CreateDirectory(strVoiceSubFolder)
            End If
        Else
            'Get the relevant 1k folder
            Dim intOneThousand As Integer = (intID \ 1000) * 1000
            Dim strOneThousandFolder As String = intOneThousand.ToString() & "-" & (intOneThousand + 999).ToString()

            strVoiceSubFolder = Path.Combine(strVoiceFolder, strOneThousandFolder)
            If Not Directory.Exists(strVoiceSubFolder) And bCreate Then
                Directory.CreateDirectory(strVoiceSubFolder)
            End If

            'Get the relevant 100 folder
            Dim intOneHundred As Integer = (intID \ 100) * 100
            Dim strOneHundredFolder As String = intOneHundred.ToString() & "-" & (intOneHundred + 99).ToString()

            strVoiceSubFolder = Path.Combine(strVoiceSubFolder, strOneHundredFolder)
            If Not Directory.Exists(strVoiceSubFolder) And bCreate Then
                Directory.CreateDirectory(strVoiceSubFolder)
            End If
        End If

        Return strVoiceSubFolder
    End Function

    Shared Function getWavFolderV2(ByVal intID As Integer, ByVal bCreate As Boolean) As String

        Dim strSoundFolder As String = getSoundFolder(bCreate)
        Dim strSoundSubFolder As String

        If intID < 0 Then
            strSoundSubFolder = Path.Combine(strSoundFolder, "TempSound")
            If Not Directory.Exists(strSoundSubFolder) And bCreate Then
                Directory.CreateDirectory(strSoundSubFolder)
            End If
        Else
            'Get the relevant 1k folder
            Dim intOneThousand As Integer = (intID \ 1000) * 1000
            Dim strOneThousandFolder As String = intOneThousand.ToString() & "-" & (intOneThousand + 999).ToString()

            strSoundSubFolder = Path.Combine(strSoundFolder, strOneThousandFolder)
            If Not Directory.Exists(strSoundSubFolder) And bCreate Then
                Directory.CreateDirectory(strSoundSubFolder)
            End If

            'Get the relevant 100 folder
            Dim intOneHundred As Integer = (intID \ 100) * 100
            Dim strOneHundredFolder As String = intOneHundred.ToString() & "-" & (intOneHundred + 99).ToString()

            strSoundSubFolder = Path.Combine(strSoundSubFolder, strOneHundredFolder)
            If Not Directory.Exists(strSoundSubFolder) And bCreate Then
                Directory.CreateDirectory(strSoundSubFolder)
            End If
        End If

        Return strSoundSubFolder
    End Function

    Shared Sub SaveRecordWav(ByRef arr() As Byte, ByVal intID As Integer, ByVal intSeq As Integer)

        Dim strVoiceSubFolder = getWavFolder(intID, True)
        WriteWAVfromByteArray(Path.Combine(strVoiceSubFolder, intID.ToString() & "-" & intSeq.ToString() & ".wav"), arr)
    End Sub

    Shared Sub SaveRecordWavFile(ByRef strWav As String, ByVal intID As Integer, ByVal intSeq As Integer)

        Dim strVoiceSubFolder = getWavFolder(intID, True)
        File.Copy(strWav, Path.Combine(strVoiceSubFolder, intID.ToString() & "-" & intSeq.ToString() & ".wav"), True)
    End Sub

    Shared Sub CopyWavFiles(ByVal intFromID As Integer, ByVal intToID As Integer)

        Dim strFromVoiceSubFolder As String = getWavFolder(intFromID, False)
        If Not Directory.Exists(strFromVoiceSubFolder) Then
            Exit Sub
        End If

        Dim wavCopyFiles() As String = Directory.GetFiles(strFromVoiceSubFolder, intFromID.ToString() & "-*.wav")
        If wavCopyFiles.Length = 0 Then
            Exit Sub
        End If

        Dim strToVoiceSubFolder As String = getWavFolder(intToID, True)
        Dim wavCurrentFiles() As String = Directory.GetFiles(strToVoiceSubFolder, intToID.ToString() & "-*.wav")
        Dim intSuffix = wavCurrentFiles.Length

        Dim strWav As String
        For Each strWav In wavCopyFiles
            intSuffix = intSuffix + 1
            File.Copy(strWav, Path.Combine(strToVoiceSubFolder, intToID.ToString() & "-" & intSuffix.ToString & ".wav"))
        Next
    End Sub

    'Shared Sub PlayWavForID(ByVal intID As Integer)

    '    Dim strVoiceFolder As String = getVoiceFolder(True)
    '    Dim strVoiceSubFolder As String = getWavFolder(intID, False)
    '    Dim wavFiles() As String

    '    If Not Directory.Exists(strVoiceSubFolder) Then
    '        Exit Sub
    '    End If

    '    wavFiles = Directory.GetFiles(strVoiceSubFolder, intID.ToString() & "-*.wav")
    '    If wavFiles.Length = 0 Then
    '        'Does 'no voice' sound file exist in root voice folder? If so return it,
    '        'otherwise create it.
    '        If Not File.Exists(Path.Combine(strVoiceFolder, "no-voice.wav")) Then
    '            WriteWAVfromByteArray(Path.Combine(strVoiceFolder, "no-voice.wav"), cfun.GetByteArraySoundResource(My.Resources.ChangeMetadata))
    '        End If
    '        My.Computer.Audio.Play(Path.Combine(strVoiceFolder, "no-voice.wav"), AudioPlayMode.Background)
    '    Else
    '        Dim snd As clsSound = New clsSound()
    '        snd.SetWavFiles(wavFiles)
    '        Dim t As Thread
    '        t = New Thread(AddressOf snd.PlayWavs)
    '        t.IsBackground = True
    '        t.Start()
    '    End If
    'End Sub

    Public Sub PlayWavForIDV2(ByVal intID As Integer)

        Dim db As clsDB = New clsDB

        'Get all the voice WAVs associated with this record
        Dim strSQL As String = "select [order], sound, OriginalFilename from RecordSounds, Sounds where RecordID = " & intID.ToString & " and RecordSounds.SoundID = Sounds.SoundID order by [order]"
        Dim daSounds As SQLiteDataAdapter
        Dim dtSounds As DataTable = New DataTable()
        daSounds = New SQLiteDataAdapter(strSQL, db.conVoice)
        Try
            daSounds.Fill(dtSounds)
        Catch ex As Exception
            MessageBox.Show("Record selection query failed: " & ex.Message)
            Exit Sub
        End Try

        Dim dtRow As DataRow
        Dim arr() As Byte
        Dim strFilename As String
        Dim strTmpFile As String
        Dim wavFiles(dtSounds.Rows.Count - 1) As String
        Dim iWav As Integer = 0

        For Each dtRow In dtSounds.Rows
            arr = dtRow("sound")
            strFilename = dtRow("OriginalFilename")
            'Playing sound directly from a Byte array - Audio.Play(arr, AudioPlayMode.Background)
            'can cause unpredictable weird sounds and crashes (happened both when data stored
            'in Access DB and SQLite). So we write out temp files and play them instead.
            strTmpFile = Path.GetTempFileName()
            strTmpFile = strTmpFile.Substring(0, Len(strTmpFile) - 4) & Path.GetExtension(strFilename)
            cfun.WriteWAVfromByteArray(strTmpFile, arr)
            wavFiles(iWav) = strTmpFile
            iWav += 1
        Next

        'If there is already an active thread playing sound files, then abort it.
        If Not threadSound Is Nothing Then
            If threadSound.IsAlive Then
                threadSound.Abort()
            End If
        End If

        'The temp wav files are actually played by a background process so that control can
        'return to the application.
        Dim snd As clsSound = New clsSound()
        snd.SetWavFiles(wavFiles)
        threadSound = New Thread(AddressOf snd.PlayWavs)
        threadSound.SetApartmentState(ApartmentState.STA)
        threadSound.IsBackground = True
        threadSound.Start()

        'var t = new Thread(MyThreadStartMethod);
        't.SetApartmentState(ApartmentState.STA);
        't.Start();

    End Sub

    Shared Sub DeleteWavsForID(ByVal intID As Integer)

        Dim strVoiceSubFolder As String = getWavFolder(intID, False)

        If Not Directory.Exists(strVoiceSubFolder) Then
            Exit Sub
        End If

        Dim wavFiles() As String = Directory.GetFiles(strVoiceSubFolder, intID.ToString() & "-*.wav")
        Dim wavFile As String
        For Each wavFile In wavFiles
            File.Delete(wavFile)
        Next
    End Sub

    Shared Sub DeleteTmpWavs()
        Dim strVoiceFolder As String = getVoiceFolder(True)
        Dim strVoiceSubFolder As String
        strVoiceSubFolder = Path.Combine(strVoiceFolder, "TempVoice")
        If Not Directory.Exists(strVoiceSubFolder) Then
            Exit Sub
        End If
        Dim wavFiles() As String = Directory.GetFiles(strVoiceSubFolder, "*.wav")
        Dim wavFile As String
        For Each wavFile In wavFiles
            File.Delete(wavFile)
        Next
    End Sub

    Shared Sub DeleteTmpWavsV2()
        Dim strSoundFolder As String = getSoundFolder(True)
        Dim strSoundSubFolder As String

        'Empty the TmpRecordSounds datatable
        'frmMain.dtTmpRecordSounds.Rows.Clear()

        'Delete the temporary WAV files
        strSoundSubFolder = Path.Combine(strSoundFolder, "TempVoice")
        If Not Directory.Exists(strSoundSubFolder) Then
            Exit Sub
        End If

        Dim wavFiles() As String = Directory.GetFiles(strSoundSubFolder, "*.wav")
        Dim wavFile As String
        For Each wavFile In wavFiles
            File.Delete(wavFile)
        Next
    End Sub

    Shared Function GetByteArrayFromImg(ByVal img) As Byte()

        Dim imgStream As MemoryStream = New MemoryStream()

        img.Save(imgStream, Imaging.ImageFormat.Png)

        imgStream.Close()
        Dim arr As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return arr
    End Function

    Shared Function GetImageFromByteArray(ByVal arr As Byte()) As Image
        Dim ms As MemoryStream = New MemoryStream(arr)
        Dim img As Image = Drawing.Image.FromStream(ms)

        Return img
    End Function

    Shared Function ThumbFromImage(ByVal img As Image, ByVal iMax As Integer) As Image

        Dim tw As Integer, th As Integer, tx As Integer, ty As Integer
        Dim w As Integer = img.Width
        Dim h As Integer = img.Height

        Dim whRatio As Double = CDbl(w) / h
        If img.Width >= img.Height Then
            tw = iMax
            th = CInt(Math.Truncate(tw / whRatio))
        Else
            th = iMax
            tw = CInt(Math.Truncate(th * whRatio))
        End If

        tx = (iMax - tw) \ 2
        ty = (iMax - th) \ 2

        Dim thumb As New Bitmap(iMax, iMax, PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.Clear(Color.White)
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.DrawImage(img, New Rectangle(tx, ty, tw, th), New Rectangle(0, 0, w, h), GraphicsUnit.Pixel)

        Return thumb
    End Function

    Shared Function GetRelativePath(ByVal strPathName As String) As String

        Dim strDB As String = frmOptions.txtDBFolder.Text.ToLower()
        Dim strRelPath As String = ""

        If strPathName.ToLower.StartsWith(strDB) Then

            strRelPath = strPathName.Substring(strDB.Length)
            If strRelPath.StartsWith("\") Then
                strRelPath = strRelPath.Substring(1)
            End If
        Else
            strRelPath = ""
        End If

        Return strRelPath
    End Function

    Shared Function GetHeadlineFromText(ByVal strText As String) As String

        Dim strHeadline As String = ""
        Dim intHeadlineLength As Integer = 50

        If strText = "" Then
            Return ""
        End If

        'If there is a full stop or exclamation mark in string, then this is the endpoint
        Dim intStop As Integer = strText.IndexOf(".")
        Dim intExclamation As Integer = strText.IndexOf("!")
        Dim intCut As Integer = -1

        If intStop > -1 And intExclamation > -1 Then
            intCut = Math.Min(intStop, intExclamation)
        ElseIf intStop > -1 Then
            intCut = intStop
        ElseIf intExclamation > -1 Then
            intCut = intExclamation
        End If

        If intCut > -1 Then
            strHeadline = strText.Substring(0, intCut)
        Else
            strHeadline = strText
        End If

        If strHeadline.Length > intHeadlineLength Then
            strHeadline = strHeadline.Substring(0, intHeadlineLength)
        End If

        Return strHeadline
    End Function

    Shared Sub AddMediaFile(ByVal strFilename As String, ByVal intRecID As Integer, ByVal intOrder As Integer)

        Dim img As Image = Nothing
        Try
            img = Image.FromFile(strFilename)
        Catch ex As Exception
        End Try

        If img Is Nothing Then
            Exit Sub
        End If

        Dim info As FileInfo = New FileInfo(strFilename)

        'Add the image to the media table
        '(Should probably check here that it's not already there)

        Dim db As clsDB = New clsDB
        Dim comMedia As SQLiteCommand = New SQLiteCommand(db.conMedia)
        comMedia.CommandText = "insert into Media(FileName, FullPath, RelativePath, DateCreated, Comment, FileType, GenericFileType, Thumbnail) values(?,?,?,?,?,?,?,?)"
        comMedia.Parameters.AddWithValue("FileName", strFilename)
        comMedia.Parameters.AddWithValue("FullPath", strFilename)
        comMedia.Parameters.AddWithValue("RelativePath", cfun.GetRelativePath(strFilename))
        comMedia.Parameters.AddWithValue("DateCreated", info.CreationTime)
        comMedia.Parameters.AddWithValue("Comment", "")
        comMedia.Parameters.AddWithValue("FileType", strFilename.Substring(strFilename.Length - 3))
        comMedia.Parameters.AddWithValue("GenericFileType", "image")
        comMedia.Parameters.AddWithValue("Thumbnail", cfun.GetByteArrayFromImg(cfun.ThumbFromImage(img, 120)))
        comMedia.ExecuteNonQuery()

        'Add a reference in the RecordsMedia table
        comMedia.CommandText = "Select last_insert_rowid()"
        Dim intMediaID As Integer = comMedia.ExecuteScalar()
        comMedia.Parameters.Clear()
        comMedia.CommandText = "insert into RecordMedia (RecordID, FileID, [Order]) values(?,?,?);"
        comMedia.Parameters.AddWithValue("RecordID", intRecID)
        comMedia.Parameters.AddWithValue("FileID", intMediaID)
        comMedia.Parameters.AddWithValue("Order", intOrder)
        comMedia.ExecuteNonQuery()
    End Sub

    Shared Function HasNoValue(ByVal obj As Object) As Boolean

        If IsDBNull(obj) Then

            Return True

        ElseIf obj Is Nothing Then

            Return True

        ElseIf obj.ToString().ToLower = "null" Then

            'This may have been used early on
            Return True

        ElseIf obj.ToString.Trim = "" Then

            Return True
        Else
            Return False
        End If

    End Function

    Shared Function NullToEmpty(ByVal objValue As Object) As Object

        If HasNoValue(objValue) Then
            Return ""
        Else
            Return objValue
        End If
    End Function
End Class
