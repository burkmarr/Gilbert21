Imports System.IO
Imports System.Math
Imports Microsoft.VisualBasic.FileIO

Public Class clsInputFileGeneral
    Inherits clsInputFile

    Dim dtRaw As DataTable = New DataTable

    Public Sub New(ByVal strFile As String)

        FilePath = strFile

        'Read the file
        Dim strFields() As String
        Dim strValues() As String
        Dim strField As String

        If File.Exists(strFile) Then

            Dim tfp As TextFieldParser = New TextFieldParser(strFile)
            tfp.TextFieldType = FieldType.Delimited
            tfp.Delimiters = New String() {","}

            'Get headers
            strFields = tfp.ReadFields()

            If Not strFields Is Nothing Then 'Can happen if file empty

                'If data table headers not already created, then do so
                If dtRaw.Columns.Count = 0 Then
                    For Each strField In strFields
                        dtRaw.Columns.Add(strField)
                    Next
                End If

                'Read the rest
                Do While Not tfp.EndOfData
                    strValues = tfp.ReadFields()
                    dtRaw.Rows.Add(strValues)
                Loop
            End If

            tfp.Close()
        End If

        'If there is a field named Date, rename to RecDate
        If dtRaw.Columns.Contains("Date") Then
            dtRaw.Columns("Date").ColumnName = "RecDate"
        End If
        'If there is a field named Time, rename to RecTime
        If dtRaw.Columns.Contains("Time") Then
            dtRaw.Columns("Time").ColumnName = "RecTime"
        End If

    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()

        'dt.Columns.Add("FileLon")
        'dt.Columns.Add("FileLat")
        'dt.Columns.Add("Filename")
        'dt.Columns.Add("FileIndex")
        'dt.Columns.Add("DateTimeKey")
        'dt.Columns.Add("RecDate")
        'dt.Columns.Add("RecTime")
        'dt.Columns.Add("VoiceFile")
        'dt.Columns.Add("MediaFile")

        If dtRaw.Columns.Count = 0 Then
            'This can happen if input file was empty
            Return dt
        End If

        Dim rowRaw As DataRow
        Dim row As DataRow
        Dim col As DataColumn

        For Each rowRaw In dtRaw.Rows

            row = dt.NewRow()

            'If any of the column names in input file, match those in the datatable, then
            'assign the values.
            For Each col In dt.Columns()
                If dtRaw.Columns.Contains(col.ColumnName) Then
                    row(col.ColumnName) = rowRaw(col.ColumnName)
                End If
            Next

            dt.Rows.Add(row)
        Next

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
