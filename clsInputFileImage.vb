Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class clsInputFileImage
    Inherits clsInputFile

    Dim bmp As Bitmap = Nothing

    Public Sub New(ByVal strFile As String)

        FilePath = strFile

        'Read the image file
        Try
            bmp = New Bitmap(strFile)
        Catch ex As Exception
            ErrorMessage = "Couldn't load image file ' " & strFile & "'. Error message was: " & ex.Message
        End Try
    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()
        Dim row As DataRow

        'EXIF properties
        If Not bmp Is Nothing Then

            Dim exif As clsExifWorks = New clsExifWorks(bmp)

            row = dt.NewRow()

            Dim dblLon As Double = exif.Longitude
            Dim dblLat As Double = exif.Latitude
            If Not dblLon = Nothing Then
                row("FileLon") = dblLon
                row("FileLat") = dblLat
            End If

            row("Filename") = Path.GetFileName(FilePath)
            'row("FileIndex") 

            'Date & time - asuume in local time, so don't convert from UTC

            If Not exif.DateTimeOriginal = DateTime.MinValue Then
                row("RecDate") = exif.DateTimeOriginal.ToString("dd/MM/yyyy")
                row("RecTime") = exif.DateTimeOriginal.ToString("H:mm")
                row("DateTimeKey") = exif.DateTimeOriginal.ToString("yyMMddHmmss")
            End If

            row("MediaFile") = FilePath
            dt.Rows.Add(row)
        End If

        Return dt
    End Function

    Public Overrides Function GetTracks() As DataTable()

        Dim dt(0) As DataTable
        Return dt
    End Function

    Public Overrides Function LocationFromTime(ByVal dtetim As Date) As DataTable

        Dim dt As DataTable = New DataTable
        Return dt
    End Function

    Public Overrides Function TimeFromLocation(ByVal lat As Double, ByVal lon As Double) As DataTable

        Dim dt As DataTable = New DataTable
        Return dt
    End Function

    Public Overrides Function TrackToPoint(ByVal ref As String, ByVal dte As String, ByVal time As String, ByVal intPoints As Integer) As DataTable

        Dim dt As DataTable = New DataTable
        Return dt
    End Function

    Public Overrides Function AllTrackPoints() As DataTable

        Dim dt As DataTable = New DataTable
        Return dt
    End Function
End Class
