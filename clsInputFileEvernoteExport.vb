Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Xml

Public Class clsInputFileEvernoteExport
    Inherits clsInputFile

    Dim bmp As Bitmap = Nothing
    Dim xmlDoc As XmlDocument
    Dim strSourceFile As String

    Public Sub New(ByVal strFile As String)

        FilePath = strFile

        xmlDoc = New XmlDocument()

        Try
            xmlDoc.Load(strFile)
        Catch
            MessageBox.Show("Failed to load Evernote export file. If you have no internet " & _
                            "connection, this could be because the ENEX (XML) file references " & _
                            "a remote DTD. If you can't get an internet connection, you can " & _
                            "try to work around this by editing a copy of the ENEX file and " & _
                            "removing the DTD reference line (probably second line).")
        End Try

        strSourceFile = strFile
    End Sub

    Public Overrides Function GetPotentialRecords() As DataTable

        Dim dt As DataTable = GetEmptyRecordsDatatable()
        Dim row As DataRow

        If Not xmlDoc Is Nothing Then

            Dim ndes As XmlNodeList = xmlDoc.GetElementsByTagName("note")
            Dim ndeNote As XmlNode
            Dim ndeNoteAttributes As XmlNode
            Dim strCreated As String
            Dim dtCreated As DateTime
            Dim strDate As String
            Dim strTime As String
            Dim formatString As String = "yyyyMMdd'T'HHmmss'Z'"
            Dim docContent As XmlDocument = New XmlDocument()
            Dim ndeContent As XmlNode
            Dim strContent As String
            Dim frag As XmlDocumentFragment = xmlDoc.CreateDocumentFragment()
            Dim intDivStart As Integer
            Dim intDivEnd As Integer
            Dim strMime As String
            Dim strData As String
            Dim strFile As String
            Dim ndeResource As XmlNode
            Dim strResourceFile As String
            Dim sw As FileStream
            Dim bt64 As Byte()

            For Each ndeNote In ndes

                row = dt.NewRow()
                ndeNoteAttributes = ndeNote.SelectSingleNode("note-attributes")
                strCreated = ndeNote.SelectSingleNode("created").InnerText
                'dtCreated = New DateTime(strCreated)
                dtCreated = DateTime.ParseExact(strCreated, formatString, Nothing)
                row("CommonName") = ndeNote.SelectSingleNode("title").InnerText
                If Not ndeNoteAttributes Is Nothing Then
                    row("FileLon") = ndeNoteAttributes.SelectSingleNode("longitude").InnerText
                    row("FileLat") = ndeNoteAttributes.SelectSingleNode("latitude").InnerText
                End If
                strDate = Format(dtCreated, "dd/MM/yyyy")
                strTime = Format(dtCreated, "H:mm")
                strDate = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecDate)
                strTime = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecTime)
                row("RecDate") = strDate
                row("RecTime") = strTime
                row("DateTimeKey") = Format(dtCreated, "yyMMddHmmss")

                ndeContent = ndeNote.SelectSingleNode("content")
                strContent = ndeContent.InnerText
                intDivStart = strContent.IndexOf("<div>")
                intDivEnd = strContent.IndexOf("</div>")
                If intDivStart > 0 And intDivEnd > intDivStart + 5 Then
                    row("Comment") = strContent.Substring(intDivStart + 5, intDivEnd - intDivStart - 5)
                End If

                ndeResource = ndeNote.SelectSingleNode("resource")
                If Not ndeResource Is Nothing Then
                    strMime = ndeResource.SelectSingleNode("mime").InnerText
                    strData = ndeResource.SelectSingleNode("data").InnerText
                    strFile = ndeResource.SelectSingleNode("resource-attributes/file-name").InnerText

                    'Between version 4 and version 5 of Evernote export file, there was a change to the way
                    'the file-name attribute is expressed. In version 5, some the of characters used in it
                    'are no longer valid filename characters - causing the creation of the filestream to fall
                    'over, so this needs to be corrected here.

                    strFile = strFile.Replace(" ", "-")
                    strFile = strFile.Replace(":", "-")

                    strResourceFile = Path.Combine(Path.GetDirectoryName(strSourceFile), strFile)
                   
                    If strMime.StartsWith("audio") Then
                        row("VoiceFile") = strResourceFile
                    Else
                        row("MediaFile") = strResourceFile
                    End If

                    'Write the media file
                    bt64 = Convert.FromBase64String(strData)
                    If File.Exists(strResourceFile) Then
                        File.Delete(strResourceFile)
                    End If

                    



                    sw = New FileStream(strResourceFile, FileMode.Create)
                    sw.Write(bt64, 0, bt64.Length)
                    sw.Close()
                End If

                dt.Rows.Add(row)
            Next
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
