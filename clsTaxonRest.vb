Public Class clsTaxonRest

    Public Sub New()
        'nothing to do here
    End Sub

    Public results As List(Of taxon)
End Class

Public Class taxon
    Public searchMatchTitle As String
    Public descript As String
    Public pExtendedName As String
    Public taxonVersionKey As String
    Public name As String
    Public authority As String
    Public languageKey As String
    Public taxonOutputGroupKey As String
    Public taxonOutputGroupName As String
    Public organismKey As String
    Public rank As String
    Public nameStatus As String
    Public versionForm As String
    Public gatewayRecordCount As Long
    Public href As String
    Public ptaxonVersionKey As String
End Class