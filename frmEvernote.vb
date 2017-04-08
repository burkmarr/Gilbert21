Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Xml
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
'Imports Thrift
'Imports Thrift.Protocol
'Imports Thrift.Transport
'Imports Evernote.EDAM.Type
'Imports Evernote.EDAM.UserStore
'Imports Evernote.EDAM.NoteStore
'Imports Evernote.EDAM.Error

Public Class frmEvernote

    'Public Class NoteListItem
    '    Private mText As String
    '    Private mValue As String

    '    Public Sub New(ByVal pText As String, ByVal pValue As String)
    '        mText = pText
    '        mValue = pValue
    '    End Sub

    '    Public ReadOnly Property Text() As String
    '        Get
    '            Return mText
    '        End Get
    '    End Property

    '    Public ReadOnly Property Value() As String
    '        Get
    '            Return mValue
    '        End Get
    '    End Property

    '    Public Overrides Function ToString() As String
    '        Return mText
    '    End Function
    'End Class

    'Dim authResult As AuthenticationResult = Nothing
    'Dim user As User = Nothing
    'Dim authToken As String
    'Dim noteStore As NoteStore.Client

    'Private dtRecs As DataTable = New DataTable
    'Public ReadOnly Property Recs() As DataTable
    '    Get
    '        Return dtRecs
    '    End Get
    'End Property

    'Public Function Authenticate(ByVal strUser As String, ByVal strPassword As String) As String

    '    Dim strErr As String = ""
    '    user = Nothing
    '    authToken = Nothing
    '    authResult = Nothing

    '    ' NOTE: You must change the consumer key and consumer secret to the 
    '    '       key and secret that you received from Evernote.
    '    '       To get an API key, visit http://dev.evernote.com/documentation/cloud/
    '    Dim consumerKey As String = "burkmarr"
    '    Dim consumerSecret As String = "2972741bf1d64045"

    '    'Dim evernoteHost As String = "sandbox.evernote.com"
    '    Dim evernoteHost As String = "www.evernote.com"
    '    Dim edamBaseUrl As String = "https://" & evernoteHost

    '    Dim userStoreUrl As New Uri(edamBaseUrl & "/edam/user")
    '    Dim userStoreTransport As TTransport = New THttpClient(userStoreUrl)
    '    Dim userStoreProtocol As TProtocol = New TBinaryProtocol(userStoreTransport)
    '    Dim userStore As New UserStore.Client(userStoreProtocol)

    '    Dim versionOK As Boolean
    '    Try
    '        versionOK = userStore.checkVersion("C# EDAMTest", Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MAJOR, Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MINOR)
    '    Catch
    '        versionOK = False
    '    End Try

    '    If Not versionOK Then
    '        strErr = "Problem connecting to Evernote. Check internet connection."
    '        'EDAM protocol version is not up to date.
    '        Return strErr
    '    End If

    '    Try
    '        authResult = userStore.authenticate(strUser, strPassword, consumerKey, consumerSecret)
    '    Catch ex As EDAMUserException
    '        Dim parameter As [String] = ex.Parameter
    '        Dim errorCode As EDAMErrorCode = ex.ErrorCode
    '        strErr = "Authentication failed (parameter: " & parameter & " errorCode: " & errorCode & ")."

    '        If errorCode = EDAMErrorCode.INVALID_AUTH Then
    '            If parameter = "consumerKey" Then
    '                strErr = strErr & " The application consumer key was not accepted by " & evernoteHost & "."
    '            ElseIf parameter = "username" Then
    '                strErr = strErr & " You must authenticate using a username and password from " & evernoteHost & "."
    '            ElseIf parameter = "password" Then
    '                strErr = strErr & " The password that you entered is incorrect."
    '            End If
    '        End If
    '        Return strErr
    '    End Try

    '    user = authResult.User
    '    authToken = authResult.AuthenticationToken
    '    Return ""
    'End Function

    'Private Sub cbNotebooks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNotebooks.SelectedIndexChanged

    '    lbNotes.Items.Clear()

    '    Dim filter As NoteFilter = New NoteFilter()
    '    Dim nli As NoteListItem = cbNotebooks.SelectedItem
    '    filter.NotebookGuid = nli.Value
    '    Dim spec As NotesMetadataResultSpec = New NotesMetadataResultSpec()
    '    spec.IncludeTitle = True

    '    Dim nml As NotesMetadataList = noteStore.findNotesMetadata(authToken, filter, 0, 100, spec)
    '    Dim nm As NoteMetadata

    '    For Each nm In nml.Notes
    '        lbNotes.Items.Add(New NoteListItem(nm.Title, nm.Guid))
    '    Next
    'End Sub

    'Private Sub frmEvernote_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    '    cbNotebooks.Items.Clear()
    '    dtRecs.Rows.Clear()

    '    Dim noteStoreTransport As TTransport = New THttpClient(New Uri(authResult.NoteStoreUrl))
    '    Dim noteStoreProtocol As TProtocol = New TBinaryProtocol(noteStoreTransport)
    '    noteStore = New NoteStore.Client(noteStoreProtocol)
    '    Dim notebooks As List(Of Notebook) = noteStore.listNotebooks(authToken)
    '    'Dim defaultNotebook As Notebook = notebooks(0)
    '    'notebook.DefaultNotebook
    '    cbNotebooks.Items.Clear()
    '    For Each notebook As Notebook In notebooks
    '        cbNotebooks.Items.Add(New NoteListItem(notebook.Name, notebook.Guid))
    '    Next
    '    cbNotebooks.SelectedIndex = 0
    'End Sub

    'Private Sub butOkay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkay.Click

    '    Cursor = Cursors.WaitCursor

    '    dtRecs.Columns.Clear()
    '    dtRecs.Columns.Add("Title")
    '    dtRecs.Columns.Add("Lat")
    '    dtRecs.Columns.Add("Lon")
    '    dtRecs.Columns.Add("Date")
    '    dtRecs.Columns.Add("Time")
    '    dtRecs.Columns.Add("DateTimeKey")
    '    dtRecs.Columns.Add("Comment")
    '    dtRecs.Columns.Add("VoiceFile")
    '    dtRecs.Columns.Add("MediaFile")

    '    Dim fullNote As Note
    '    Dim nli As NoteListItem
    '    Dim base As New DateTime(1970, 1, 1)
    '    Dim dt As DateTime
    '    Dim millisecs As Double
    '    Dim doc As XmlDocument = New XmlDocument
    '    doc.XmlResolver = Nothing
    '    Dim strResourceFile As String
    '    Dim strExt As String = ""
    '    Dim r As Resource
    '    Dim row As DataRow
    '    Dim byteData() As Byte
    '    Dim oFileStream As System.IO.FileStream
    '    Dim strComment As String
    '    Dim strDate As String
    '    Dim strTime As String

    '    For Each nli In lbNotes.SelectedItems

    '        fullNote = noteStore.getNote(authToken, nli.Value, True, False, False, False)

    '        millisecs = fullNote.Created
    '        dt = base.AddMilliseconds(millisecs)

    '        row = dtRecs.NewRow()
    '        row("Title") = fullNote.Title
    '        row("Lat") = fullNote.Attributes.Latitude
    '        row("Lon") = fullNote.Attributes.Longitude
    '        row("DateTimeKey") = Format(dt, "yyMMddHmmss")

    '        'We assume the dates and times in are UTC
    '        strDate = Format(dt, "dd/MM/yyyy")
    '        strTime = Format(dt, "H:mm")
    '        strDate = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecDate)
    '        strTime = cfun.UTC2LocalTime(DateTime.Parse(strDate & " " & strTime & ":00"), cfun.RecDateTimeType.RecTime)
    '        row("Date") = strDate
    '        row("Time") = strTime

    '        'We extract comment with regular expression because trying to parse XML was problematic
    '        'due to things like &nbsp;. Resolving the DTD might have helped this, but if this isn't
    '        'disabled with doc.XmlResolver = Nothing, the document wont load at all.
    '        strComment = RegularExpressions.Regex.Replace(fullNote.Content, "<.*?>", "")
    '        strComment = RegularExpressions.Regex.Replace(strComment, "&nbsp;", " ")
    '        strComment = RegularExpressions.Regex.Replace(strComment, vbCr, "")
    '        strComment = RegularExpressions.Regex.Replace(strComment, vbLf, "")
    '        strComment = RegularExpressions.Regex.Replace(strComment, vbCrLf, "")
    '        row("Comment") = strComment

    '        'Resources
    '        If Not fullNote.Resources Is Nothing Then
    '            For Each r In fullNote.Resources
    '                If r.Mime.StartsWith("audio") Or r.Mime.StartsWith("image") Then
    '                    'Its an audio (voice) file
    '                    If r.Mime.EndsWith("wav") Then strExt = ".wav"
    '                    If r.Mime.EndsWith("mpeg") Then strExt = ".mpg"
    '                    If r.Mime.EndsWith("amr") Then strExt = ".amr"
    '                    If r.Mime.EndsWith("gif") Then strExt = ".gif"
    '                    If r.Mime.EndsWith("jpeg") Then strExt = ".jpg"
    '                    If r.Mime.EndsWith("png") Then strExt = ".png"

    '                    If Directory.Exists(frmOptions.txtEvernoteFolder.Text) Then

    '                        strResourceFile = Path.Combine(frmOptions.txtEvernoteFolder.Text, row("DateTimeKey") & strExt)
    '                        byteData = noteStore.getResourceData(authToken, r.Guid)
    '                        oFileStream = New System.IO.FileStream(strResourceFile, System.IO.FileMode.Create)
    '                        oFileStream.Write(byteData, 0, byteData.Length)
    '                        oFileStream.Close()

    '                        If r.Mime.StartsWith("audio") Then
    '                            row("VoiceFile") = strResourceFile
    '                        Else
    '                            row("MediaFile") = strResourceFile
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        End If

    '        dtRecs.Rows.Add(row)
    '    Next

    '    Cursor = Cursors.Arrow

    '    Me.Close()
    'End Sub

    'Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
    '    Me.Close()
    'End Sub
End Class