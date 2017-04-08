Imports System.IO

Public MustInherit Class clsInputFile

    Shared Function GetFileOpenFilter() As String

        Dim alInputFileTypes As ArrayList = New ArrayList
        Dim ift As clsInputFileTypes

        'Visiontac
        ift = New clsInputFileTypes
        ift.FileTypeDisplay = "Visiontac"
        ift.FileType = "visiontac"
        ift.AddFileExtension("csv")
        alInputFileTypes.Add(ift)

        'G21App
        ift = New clsInputFileTypes
        ift.FileTypeDisplay = "Gilbert 21 App sound files"
        ift.FileType = "G21App"
        ift.AddFileExtension("wav")
        ift.AddFileExtension("3gp")
        alInputFileTypes.Add(ift)

        'Evernote export file
        ift = New clsInputFileTypes
        ift.FileTypeDisplay = "Evernote export file"
        ift.FileType = "evernoteexport"
        ift.AddFileExtension("enex")
        alInputFileTypes.Add(ift)

        'Images
        ift = New clsInputFileTypes
        ift.FileTypeDisplay = "Images"
        ift.FileType = "image"
        ift.AddFileExtension("bmp")
        ift.AddFileExtension("jpg")
        ift.AddFileExtension("jpeg")
        ift.AddFileExtension("gif")
        ift.AddFileExtension("tif")
        ift.AddFileExtension("tiff")
        alInputFileTypes.Add(ift)

        'Return file open dialog string
        Dim strFilter As String = ""
        Dim i As Integer
        Dim j As Integer

        For i = 0 To alInputFileTypes.Count - 1
            ift = alInputFileTypes(i)
            If i > 0 Then
                strFilter = strFilter & "|"
            End If
            strFilter = strFilter & ift.FileTypeDisplay & " (*."
            For j = 0 To ift.FileExtensions.Count - 1
                If j > 0 Then
                    strFilter = strFilter & "; *."
                End If
                strFilter = strFilter & ift.FileExtensions(j)
            Next
            strFilter = strFilter & ")|*."
            For j = 0 To ift.FileExtensions.Count - 1
                If j > 0 Then
                    strFilter = strFilter & "; *."
                End If
                strFilter = strFilter & ift.FileExtensions(j)
            Next
        Next
        Return strFilter & "|All files (*.*)|*.*"
    End Function

    Public Function SearchFolderForFile(ByVal strFolder As String, ByVal strFile As String) As String

        Dim strSubFolder As String
        Dim strFoundFile As String
        Dim strFileName = Path.GetFileName(strFile)

        If Directory.Exists(strFolder) Then

            For Each strFoundFile In Directory.GetFiles(strFolder)
                If Path.GetFileName(strFoundFile).ToLower = strFileName.ToLower Then
                    Return strFoundFile
                End If
            Next

            For Each strSubFolder In Directory.GetDirectories(strFolder)
                strFoundFile = SearchFolderForFile(strSubFolder, strFile)
                If strFoundFile <> "" Then
                    Return strFoundFile
                End If
            Next
        End If

        Return ""
    End Function

    Public Function GetEmptyRecordsDatatable() As DataTable

        '####
        'objRecordMapping(0) = New clsRecordMapping("ID", "ID", OleDb.OleDbType.Integer, 0, False, False, False)
        'objRecordMapping(1) = New clsRecordMapping("GUID", "GUID", OleDb.OleDbType.VarWChar, 36, False, False, False)
        'bjRecordMapping(6) = New clsRecordMapping("Entered", "Entered", OleDb.OleDbType.Date, 0, False, False, False)
        'objRecordMapping(7) = New clsRecordMapping("Modified", "Modified", OleDb.OleDbType.Date, 0, False, False, False)
        'objRecordMapping(8) = New clsRecordMapping("NoExport", "NoExport", OleDb.OleDbType.Boolean, 0, False, True, False)
        'objRecordMapping(21) = New clsRecordMapping("Lon", "Lon", OleDb.OleDbType.Double, 0, False, False, False)
        'objRecordMapping(22) = New clsRecordMapping("Lat", "Lat", OleDb.OleDbType.Double, 0, False, False, False)
        'objRecordMapping(25) = New clsRecordMapping("TimeZone", "TimeZone", OleDb.OleDbType.VarWChar, 50, False, False, False)
        '#####
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("GUID")
        dt.Columns.Add("FileLon")
        dt.Columns.Add("FileLat")
        dt.Columns.Add("Filename")
        dt.Columns.Add("FileIndex")
        dt.Columns.Add("DateTimeKey")
        dt.Columns.Add("RecDate")
        dt.Columns.Add("RecTime")
        dt.Columns.Add("VoiceFile")
        dt.Columns.Add("MediaFile")

        dt.Columns.Add("Recorder")
        dt.Columns.Add("Determiner")
        dt.Columns.Add("Confirmer")
        dt.Columns.Add("GridRef")
        dt.Columns.Add("Location")
        dt.Columns.Add("Town")
        dt.Columns.Add("ScientificName")
        dt.Columns.Add("CommonName")
        dt.Columns.Add("TaxonGroup")
        dt.Columns.Add("Abundance")
        dt.Columns.Add("Units")
        dt.Columns.Add("Comment")
        dt.Columns.Add("PersonalNotes")

        Return dt
    End Function

    Public Function GetEmptyTrackDatatable() As DataTable

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("TrackID")
        dt.Columns.Add("Lon")
        dt.Columns.Add("Lat")
        dt.Columns.Add("Date")
        dt.Columns.Add("Time")
        Return dt
    End Function

    Private strErrorMessage As String = ""
    Public Property ErrorMessage() As String
        Get
            Return strErrorMessage
        End Get
        Set(ByVal value As String)
            strErrorMessage = value
        End Set
    End Property

    Private strFilePath As String = ""
    Public Property FilePath() As String
        Get
            Return strFilePath
        End Get
        Set(ByVal value As String)
            strFilePath = value
        End Set
    End Property

    Public MustOverride Function GetTracks() As DataTable()

    Public MustOverride Function AllTrackPoints() As DataTable

    Public MustOverride Function GetPotentialRecords() As DataTable

    Public MustOverride Function LocationFromTime(ByVal dtetim As DateTime) As DataTable

    Public MustOverride Function TimeFromLocation(ByVal lat As Double, ByVal lon As Double) As DataTable

    Public MustOverride Function TrackToPoint(ByVal ref As String, ByVal dte As String, ByVal time As String, ByVal intPoints As Integer) As DataTable

    Public Class clsInputFileTypes

        Private strFileType As String = ""
        Public Property FileType() As String
            Get
                Return strFileTypeDisplay
            End Get
            Set(ByVal value As String)
                strFileType = value
            End Set
        End Property

        Private strFileTypeDisplay As String = ""
        Public Property FileTypeDisplay() As String
            Get
                Return strFileTypeDisplay
            End Get
            Set(ByVal value As String)
                strFileTypeDisplay = value
            End Set
        End Property

        Private alFileExtensions As ArrayList = New ArrayList
        Public ReadOnly Property FileExtensions() As ArrayList
            Get
                Return alFileExtensions
            End Get
        End Property

        Public Sub AddFileExtension(ByVal strExtension)

            alFileExtensions.Add(strExtension)
        End Sub
    End Class
End Class
