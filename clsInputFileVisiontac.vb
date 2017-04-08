Imports System.IO
Imports System.Math
Imports Microsoft.VisualBasic.FileIO

Public Class clsInputFileVisiontac
    Inherits clsInputFile

    Dim dtRaw As DataTable = New DataTable

    Public Sub New(ByVal strFile As String)

        FilePath = strFile

        'Read the visiontac file
        Dim strFields() As String
        Dim strValues() As String
        Dim strField As String

        'If the file doesn't exist, search the current import folder and sub-folders
        'for a file of that name. Temporary workaround added 6th June 2012 to find 
        'tracks from drop-box where dropbox is stored on a different path to that on
        'the computer where it was saved.
        If Not File.Exists(strFile) Then
            strFile = SearchFolderForFile(frmOptions.txtImportFolder.Text, strFile)
        End If

        If File.Exists(strFile) Then

            Dim tfp As TextFieldParser = New TextFieldParser(strFile)
            tfp.TextFieldType = FieldType.Delimited
            tfp.Delimiters = New String() {","}

            'Get headers
            strFields = tfp.ReadFields()

            'Sometimes Visiontac can create empty files with no header line or
            'anything. Account for that here.
            Dim bVisiontacFieldsOK As Boolean = True
            If Not strFields Is Nothing Then

                'Check that expected Visiontac fields present - if
                'not then set error message
                Dim listFields As List(Of String) = New List(Of String)
                listFields.Add("INDEX")
                listFields.Add("TAG")
                listFields.Add("DATE")
                listFields.Add("TIME")
                listFields.Add("LATITUDE N/S")
                listFields.Add("LONGITUDE E/W")
                listFields.Add("HEIGHT")
                listFields.Add("SPEED")
                listFields.Add("HEADING")
                listFields.Add("VOX")

                'For Each strField In strFields
                '    If Not strField.Trim = "" Then
                '        If Not listFields.Contains(strField.Trim("""")) Then
                '            bVisiontacFieldsOK = False
                '            ErrorMessage = "Expected visiontac fields missing"
                '            Exit For
                '        End If
                '    End If
                'Next

                For Each strField In listFields
                    If Not strField.Trim = "" Then
                        If Not strFields.Contains(strField.Trim("""")) Then
                            bVisiontacFieldsOK = False
                            ErrorMessage = "Expected visiontac fields missing"
                            Exit For
                        End If
                    End If
                Next
            End If

            If bVisiontacFieldsOK And Not strFields Is Nothing Then 'Can happen if file empty

                'If data table headers not already created, then do so
                If dtRaw.Columns.Count = 0 Then
                    For Each strField In strFields
                        dtRaw.Columns.Add(strField)
                    Next
                End If

                'Read the rest
                Do While Not tfp.EndOfData
                    strValues = tfp.ReadFields()
                    Try
                        dtRaw.Rows.Add(strValues)
                    Catch ex As Exception
                        'MessageBox.Show("There was a problem importing a row")
                    End Try

                Loop
            End If

            tfp.Close()
        End If
    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()

        If dtRaw.Columns.Count = 0 Then
            'This can happen if input file was empty
            Return dt
        End If

        Dim rowRaw As DataRow
        Dim row As DataRow
        Dim rowsTagged As DataRow()

        If frmOptions.rbVistiotacVoiceTags.Checked Then
            rowsTagged = dtRaw.Select("TAG = 'V'")
        Else
            rowsTagged = dtRaw.Select("not TAG = 'T'")
        End If

        Dim strDate As String
        Dim strTime As String

        For Each rowRaw In rowsTagged

            row = dt.NewRow()
            row("FileLon") = GetLonFromVisiontac(rowRaw("LONGITUDE E/W"))
            row("FileLat") = GetLatFromVisiontac(rowRaw("LATITUDE N/S"))
            row("Filename") = Path.GetFileName(FilePath)
            row("FileIndex") = rowRaw("INDEX").Trim(vbNullChar)
            row("DateTimeKey") = rowRaw("DATE") & rowRaw("TIME")

            'We assume the dates and times in Visiontac files are UTC
            strDate = rowRaw("DATE")
            strDate = strDate.Substring(4, 2) & "/" & strDate.Substring(2, 2) & "/20" & strDate.Substring(0, 2)
            strTime = rowRaw("TIME")
            If strTime.Length = 5 Then
                strTime = "0" & strTime
            End If
            strTime = strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)
            strDate = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecDate)
            strTime = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecTime)
            row("RecDate") = strDate
            row("RecTime") = strTime

            If Not cfun.HasNoValue(rowRaw("VOX")) Then
                row("VoiceFile") = rowRaw("VOX").Replace(Chr(0), "")
            End If
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

    Public Overrides Function GetTracks() As DataTable()

        'There's only a single track in each Visiontac file

        Dim rowRaw As DataRow
        Dim row As DataRow
        Dim strDate As String
        Dim strTime As String
        Dim dt(0) As DataTable
        dt(0) = GetEmptyTrackDatatable()
        For Each rowRaw In dtRaw.Rows

            row = dt(0).NewRow()
            row("Lon") = GetLonFromVisiontac(rowRaw("LONGITUDE E/W"))
            row("Lat") = GetLatFromVisiontac(rowRaw("LATITUDE N/S"))
            'We assume the dates and times in Visiontac files are UTC
            strDate = rowRaw("DATE")
            strDate = strDate.Substring(4, 2) & "/" & strDate.Substring(2, 2) & "/20" & strDate.Substring(0, 2)
            strTime = rowRaw("TIME")
            strTime = strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)
            strDate = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecDate)
            strTime = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecTime)
            row("Date") = strDate
            row("Time") = strTime
            dt(0).Rows.Add(row)
        Next

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
        dt.Columns.Add("Lat")
        dt.Columns.Add("Lon")

        'For Visiontac, the ref should have a value
        If Not ref = "" Then

            Dim iIndex As Integer = CInt(ref)
            Dim i As Integer
            Dim strLat As String
            Dim strLon As String
            Dim row As DataRow
            Dim strFilter As String
            Dim x0 As Double
            Dim y0 As Double
            Dim x1 As Double
            Dim y1 As Double
            Dim n As Integer = 0
            Dim rowNew As DataRow

            For i = iIndex To 1 Step -1
                strFilter = "INDEX='" & i.ToString() & "'"
                row = dtRaw.Select(strFilter)(0)
                If i = iIndex Then
                    strLat = row.Item("LATITUDE N/S").ToString()
                    strLon = row.Item("LONGITUDE E/W").ToString()
                    x0 = GetLonFromVisiontac(strLon)
                    y0 = GetLatFromVisiontac(strLat)
                End If
                strLat = row.Item("LATITUDE N/S").ToString()
                strLon = row.Item("LONGITUDE E/W").ToString()
                rowNew = dt.NewRow()
                rowNew("Lat") = GetLatFromVisiontac(strLat)
                rowNew("Lon") = GetLonFromVisiontac(strLon)
                dt.Rows.Add(rowNew)
                n = n + 1

                If intPoints = 0 Then
                    'If the distance between this point and the record point is greater than 20m
                    'and more than three points have been considered then that's enough
                    x1 = GetEastingFromVisiontac(strLon, strLat)
                    y1 = GetNorthingFromVisiontac(strLon, strLat)
                    If Sqrt((x0 - x1) ^ 2 + (y0 - y1) ^ 2) > 20 And n > 3 Then
                        Exit For
                    End If
                Else
                    If intPoints = n Then
                        Exit For
                    End If
                End If
            Next
        End If
        Return dt
    End Function

    Public Overrides Function AllTrackPoints() As DataTable

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Lat")
        dt.Columns.Add("Lon")

        Dim strLat As String
        Dim strLon As String
        Dim row As DataRow
        Dim rowNew As DataRow

        For Each row In dtRaw.Rows

            strLat = row.Item("LATITUDE N/S").ToString()
            strLon = row.Item("LONGITUDE E/W").ToString()
            rowNew = dt.NewRow()
            rowNew("Lat") = GetLatFromVisiontac(strLat)
            rowNew("Lon") = GetLonFromVisiontac(strLon)
            dt.Rows.Add(rowNew)
        Next

        Return dt
    End Function

    Private Function GetLonFromVisiontac(ByVal strLon As String) As Double

        strLon = strLon.Trim
        If strLon.Substring(strLon.Length - 1, 1) = "E" Then
            strLon = strLon.Substring(0, strLon.Length - 1)
        Else
            strLon = "-" & strLon.Substring(0, strLon.Length - 1)
        End If
        Return Val(strLon)
    End Function

    Private Function GetLatFromVisiontac(ByVal strLat As String) As Double

        strLat = strLat.Trim
        If strLat.Substring(strLat.Length - 1, 1) = "N" Then
            strLat = strLat.Substring(0, strLat.Length - 1)
        Else
            strLat = "-" & strLat.Substring(0, strLat.Length - 1)
        End If
        Return Val(strLat)
    End Function

    Private Function GetNorthingFromVisiontac(ByVal strLon As String, ByVal strLat As String)

        Dim dblLon As Double
        Dim dblLat As Double
        Dim strGR As String = ""

        strLon = strLon.Trim
        If strLon.Substring(strLon.Length - 1, 1) = "E" Then
            strLon = strLon.Substring(0, strLon.Length - 1)
        Else
            strLon = "-" & strLon.Substring(0, strLon.Length - 1)
        End If
        dblLon = Val(strLon)

        strLat = strLat.Trim
        If strLat.Substring(strLat.Length - 1, 1) = "N" Then
            strLat = strLat.Substring(0, strLat.Length - 1)
        Else
            strLat = "-" & strLat.Substring(0, strLat.Length - 1)
        End If
        dblLat = Val(strLat)

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        Return objGridRef.LatWGS842Northing(dblLat, dblLon, 100)
    End Function

    Private Function GetEastingFromVisiontac(ByVal strLon As String, ByVal strLat As String)

        Dim dblLon As Double
        Dim dblLat As Double
        Dim strGR As String = ""

        strLon = strLon.Trim
        If strLon.Substring(strLon.Length - 1, 1) = "E" Then
            strLon = strLon.Substring(0, strLon.Length - 1)
        Else
            strLon = "-" & strLon.Substring(0, strLon.Length - 1)
        End If
        dblLon = Val(strLon)

        strLat = strLat.Trim
        If strLat.Substring(strLat.Length - 1, 1) = "N" Then
            strLat = strLat.Substring(0, strLat.Length - 1)
        Else
            strLat = "-" & strLat.Substring(0, strLat.Length - 1)
        End If
        dblLat = Val(strLat)

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        Return objGridRef.LongWGS842Easting(dblLat, dblLon, 100)
    End Function
End Class
