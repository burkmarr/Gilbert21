Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class clsInputFileG21App

    Inherits clsInputFile

    Dim dblLat As Double = 0
    Dim dblLon As Double = 0
    Dim strDate As String = ""
    Dim strTime As String = ""
    Dim strDateTimeKey As String = ""
    Dim objGR As GridRef = New GridRef()

    Public Sub New(ByVal strFile As String)

        FilePath = strFile

        'Parse the file name to get lat, lon and time
        '1423390590011_1423390592864_53.74981_-3.00651.3gp
        '2015-02-14_20-54-29_SD65821128_18_0.wav
        '2015-02-14_20-54-45_53.59675_-2.51646_15_0.wav

        Dim strFileName As String = Path.GetFileNameWithoutExtension(strFile)
        Dim strParts() As String = strFileName.Split("_")

        If strParts.Length = 4 Then

            Dim lngTime As Long = Convert.ToUInt64(Val(strParts(0)))
            Dim dtEpoch = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            Dim dtTime As DateTime = dtEpoch.AddMilliseconds(lngTime)
            strDate = dtTime.ToString("dd/MM/yyyy")
            strTime = dtTime.ToString("H:mm")
            strDateTimeKey = dtTime.ToString("yyMMddHmmss")

            dblLat = Val(strParts(2))
            dblLon = Val(strParts(3))

        ElseIf strParts.Length = 5 Then

            Dim strDateRaw = strParts(0)
            Dim strPartsDate() As String = strDateRaw.Split("-")
            strDate = strPartsDate(2) & "/" & strPartsDate(1) & "/" & strPartsDate(0)

            Dim strTimeRaw = strParts(1)
            Dim strPartsTime() As String = strTimeRaw.Split("-")
            strTime = strPartsTime(0) & ":" & strPartsTime(1)

            strDateTimeKey = strPartsDate(0).Substring(2, 2) & strPartsDate(1) & strPartsDate(2)
            strDateTimeKey = strDateTimeKey & strPartsTime(0) & strPartsTime(1) & strPartsTime(2)

            objGR.MakePrefixArrays()
            objGR.GridRef = strParts(2)
            objGR.ParseGridRef(True)
            objGR.ParseInput(False)
            dblLat = objGR.Northing2LatWGS84(objGR.East, objGR.North, 0)
            dblLon = objGR.Easting2LongWGS84(objGR.East, objGR.North, 0)

        ElseIf strParts.Length = 6 Then

            Dim strDateRaw = strParts(0)
            Dim strPartsDate() As String = strDateRaw.Split("-")
            strDate = strPartsDate(2) & "/" & strPartsDate(1) & "/" & strPartsDate(0)

            Dim strTimeRaw = strParts(1)
            Dim strPartsTime() As String = strTimeRaw.Split("-")
            strTime = strPartsTime(0) & ":" & strPartsTime(1)

            strDateTimeKey = strPartsDate(0).Substring(2, 2) & strPartsDate(1) & strPartsDate(2)
            strDateTimeKey = strDateTimeKey & strPartsTime(0) & strPartsTime(1) & strPartsTime(2)

            dblLat = Val(strParts(2))
            dblLon = Val(strParts(3))
        End If
    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()
        Dim row As DataRow

        If Not strDateTimeKey = "" Then

            row = dt.NewRow()

            row("FileLon") = dblLon
            row("FileLat") = dblLat
            'row("Filename") = Path.GetFileName(FilePath)

            row("DateTimeKey") = strDateTimeKey
            'Date & time - asuume UTC, so convert to local time
            strDate = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecDate)
            strTime = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecTime)
            row("RecDate") = strDate
            row("RecTime") = strTime

            row("VoiceFile") = FilePath
            'row("FileName") = FilePath

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
