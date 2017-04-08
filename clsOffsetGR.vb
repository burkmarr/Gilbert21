Imports System.Data.SQLite
Imports System.Math

Public Class clsOffsetGR

    Private theta As Double
    Private objGridRef As GridRef = New GridRef

    Public Sub New(ByVal rowActive As DataGridViewRow, ByVal intOffset As Integer, ByVal intOclock As Integer, ByVal intPointNumber As Integer)

        objGridRef.MakePrefixArrays()

        'Get the associated track file, if any
        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)

        comTracks.CommandText = "select FileID from RecordTracks where RecordID = " & rowActive.Cells("ID").Value
        Dim intTrackID As Integer = comTracks.ExecuteScalar()

        Dim inFile As clsInputFile
        comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = " & intTrackID
        Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTrackFile As DataTable = New DataTable
        daTrackFile.Fill(dtTrackFile)

        If dtTrackFile.Rows.Count = 0 Then
            strMessage = "No track is associated with the record - offset cannot be rendered."
        Else
            If cfun.HasNoValue(dtTrackFile.Rows(0)("CurrentPath")) Then
                strMessage = "Track file record does not reference a file - offset cannot be rendered."
            Else
                Dim strTrackFile As String = dtTrackFile.Rows(0)("CurrentPath")
                Dim strFiletype As String = dtTrackFile.Rows(0)("FileType")

                inFile = Nothing
                Select Case strFiletype.ToLower()

                    Case "visiontac"
                        inFile = New clsInputFileVisiontac(strTrackFile)
                End Select

                'Render the path leading up to the point of recording
                Dim dtTrackToPoint As DataTable = inFile.TrackToPoint(cfun.NullToEmpty(rowActive.Cells("FileIndex").Value), cfun.NullToEmpty(rowActive.Cells("Date").Value), cfun.NullToEmpty(rowActive.Cells("Time").Value), intPointNumber)
                Dim row As DataRow
                For Each row In dtTrackToPoint.Rows
                    Dim ll As clsLatLon = New clsLatLon(row("Lat"), row("Lon"))
                    colTrack.Add(ll)
                Next

                'Get the path leading up to the point of recording
                LineOfBestFitCoords(dtTrackToPoint, rowActive)

                'Project the grid ref
                ProjectedCoords(intOffset, intOclock, rowActive)
            End If
        End If
    End Sub

    Private Sub ProjectedCoords(ByVal intOffset As Integer, ByVal intOclock As Integer, ByVal rowActive As DataGridViewRow)

        Dim colSegment As Collection
        Dim strKML As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim theta12Oclock As Double = theta + PI
        Dim deltaTheta As Double = 30 * PI / 180
        Dim deltaDeltaTheta As Double = 5 * PI / 180
        Dim kTheta As Double = 0
        Dim projectedTheta As Double

        'Origin
        Dim x0 As Double = objGridRef.LongWGS842Easting(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value, 100)
        Dim y0 As Double = objGridRef.LatWGS842Northing(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value, 100)

        Dim x1 As Double
        Dim y1 As Double
        Dim lon1 As Double
        Dim lat1 As Double

        For i = intOclock - 1 To intOclock + 1

            If i = intOclock - 1 Then
                colSegment = colSegment1
            ElseIf i = intOclock + 1 Then
                colSegment = colSegment3
            Else
                colSegment = colSegment2
            End If

            If i < 1 Then
                j = 12 - i
            ElseIf i > 12 Then
                j = i - 12
            Else
                j = i
            End If

            projectedTheta = theta12Oclock - j * deltaTheta

            colSegment.Add(New clsLatLon(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value))
            For k = -3 To 3

                kTheta = projectedTheta + k * deltaDeltaTheta
                x1 = x0 + intOffset * Cos(kTheta)
                y1 = y0 + intOffset * Sin(kTheta)

                lon1 = objGridRef.Easting2LongWGS84(x1, y1, 100)
                lat1 = objGridRef.Northing2LatWGS84(x1, y1, 100)

                colSegment.Add(New clsLatLon(lat1, lon1))
            Next

            colSegment.Add(New clsLatLon(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value))
        Next
    End Sub

    Private Sub LineOfBestFitCoords(ByVal dt As DataTable, ByVal rowActive As DataGridViewRow)

        'For the line of best fit Y = M * X + B:
        'M = (n * Sxy - Sx * Sy) / (n * Sx2 - Sx * Sx)
        'B = (Sy - M * Sx) / n
        'Where:
        'n = number of points
        'Sx = the SUM of all the X coordinates
        'Sy = the SUM of all the Y coordinates
        'Sxy = the SUM of all (x * y)
        'Sx2 = the SUM of all (x * x)

        'But we force the line through the origin (point of record)
        'so the line of best fit is Y = M * X and:
        'M = Sxy/Sx2

        Dim i As Integer
        Dim row As DataRow
        Dim l As Double
        Dim x As Double
        Dim y As Double
        Dim xd As Double
        Dim yd As Double
        Dim x1 As Double
        Dim y1 As Double
        Dim x2 As Double
        Dim y2 As Double
        Dim Sxy As Double = 0
        Dim Sx2 As Double = 0
        Dim n As Integer = 0
        Dim m As Double
        Dim x0 As Double
        Dim y0 As Double
        Dim xPrev As Double = 0
        Dim d As Double = 0

        For i = 0 To dt.Rows.Count - 1

            row = dt.Rows(i)
            If i = 0 Then
                'Origin
                x0 = objGridRef.LongWGS842Easting(row("Lat"), row("Lon"), 100)
                y0 = objGridRef.LatWGS842Northing(row("Lat"), row("Lon"), 100)
            Else
                x = objGridRef.LongWGS842Easting(row("Lat"), row("Lon"), 100)
                y = objGridRef.LatWGS842Northing(row("Lat"), row("Lon"), 100)
                'Force through origin
                xd = x - x0
                yd = y - y0
                Sxy = Sxy + xd * yd
                Sx2 = Sx2 + xd * xd
                n = n + 1
                l = Sqrt(xd ^ 2 + yd ^ 2)
            End If
        Next

        llBestFitStart = New clsLatLon(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value)

        'If there are not enough points to calculate line of best fit, sack it off
        If n < 2 Then
            llBestFitEnd = New clsLatLon(rowActive.Cells("FileLat").Value, rowActive.Cells("FileLon").Value)
        Else
            'Slope of the line of best fit
            m = Sxy / Sx2
            theta = Atan(m)

            'First possibility for end point of line of best fit
            x1 = x0 + l * Cos(theta)
            y1 = y0 + l * Sin(theta)

            'Second possibility for end point of line of best fit
            x2 = x0 + l * Cos(theta - PI)
            y2 = y0 + l * Sin(theta - PI)

            'For plotting the line, we use whichever point is closest to last point used to calculate best fit
            Dim lon1 As Double
            Dim lat1 As Double
            If Sqrt((x1 - x) ^ 2 + (y1 - y) ^ 2) < Sqrt((x2 - x) ^ 2 + (y2 - y) ^ 2) Then
                lon1 = objGridRef.Easting2LongWGS84(x1, y1, 100)
                lat1 = objGridRef.Northing2LatWGS84(x1, y1, 100)
            Else
                lon1 = objGridRef.Easting2LongWGS84(x2, y2, 100)
                lat1 = objGridRef.Northing2LatWGS84(x2, y2, 100)
                theta = theta - PI
            End If

            llBestFitEnd = New clsLatLon(lat1, lon1)
        End If
    End Sub

    Private strMessage As String = ""
    Public ReadOnly Property Message() As String
        Get
            Return strMessage
        End Get
    End Property

    Private colTrack As Collection = New Collection
    Public ReadOnly Property Track() As Collection
        Get
            Return colTrack
        End Get
    End Property

    Private colSegment1 As Collection = New Collection
    Public ReadOnly Property Segment1() As Collection
        Get
            Return colSegment1
        End Get
    End Property

    Private colSegment2 As Collection = New Collection
    Public ReadOnly Property Segment2() As Collection
        Get
            Return colSegment2
        End Get
    End Property

    Private colSegment3 As Collection = New Collection
    Public ReadOnly Property Segment3() As Collection
        Get
            Return colSegment3
        End Get
    End Property

    Private llBestFitStart As clsLatLon
    Public ReadOnly Property BestFitStart() As clsLatLon
        Get
            Return llBestFitStart
        End Get
    End Property

    Private llBestFitEnd As clsLatLon
    Public ReadOnly Property BestFitEnd() As clsLatLon
        Get
            Return llBestFitEnd
        End Get
    End Property

    Public Class clsLatLon

        Public Sub New(ByVal dblNewLat As Double, ByVal dblNewLon As Double)
            dblLat = dblNewLat
            dblLon = dblNewLon
        End Sub

        Private dblLat As Double
        Public ReadOnly Property Lat() As Double
            Get
                Return dblLat
            End Get
        End Property

        Private dblLon As Double
        Public ReadOnly Property Lon() As Double
            Get
                Return dblLon
            End Get
        End Property
    End Class
End Class
