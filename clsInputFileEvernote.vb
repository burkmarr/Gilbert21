Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class clsInputFileEvernote
    Inherits clsInputFile

    Dim bmp As Bitmap = Nothing

    Public Sub New(ByVal strUser As String, ByVal strPassword As String)

        'ErrorMessage = frmEvernote.Authenticate(strUser, strPassword)
    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()
        'Dim row As DataRow
        'Dim rowEvernote As DataRow

        'frmEvernote.ShowDialog()
        'For Each rowEvernote In frmEvernote.Recs.Rows

        '    row = dt.NewRow()

        '    row("CommonName") = rowEvernote("Title")
        '    If rowEvernote("Lat") <> 0 Or rowEvernote("Lon") <> 0 Then
        '        row("FileLon") = rowEvernote("Lon")
        '        row("FileLat") = rowEvernote("Lat")
        '    End If
        '    row("RecDate") = rowEvernote("Date")
        '    row("RecTime") = rowEvernote("Time")
        '    row("DateTimeKey") = rowEvernote("DateTimeKey")
        '    row("Comment") = rowEvernote("Comment")
        '    row("VoiceFile") = rowEvernote("VoiceFile")
        '    row("MediaFile") = rowEvernote("MediaFile")

        '    dt.Rows.Add(row)
        'Next

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
