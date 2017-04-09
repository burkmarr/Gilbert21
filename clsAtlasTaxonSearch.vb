Imports System.Runtime.Serialization

<DataContract()> Public Class clsAtlasTaxonSearch
    Public Sub New()
        'nothing to do here
    End Sub

    <DataMember(Name:="searchResults")> Public searchResults As atlasTaxonSearchResults
End Class

<DataContract()> Public Class atlasTaxonSearchResults

    'Public totalRecords As Integer
    <DataMember(Name:="results")> Public results As IEnumerable(Of atlasSearchTaxon)
End Class

<DataContract()> Public Class atlasSearchTaxon
    <DataMember(Name:="name")> Public name As String
    <DataMember(Name:="commonNameSingle")> Public commonNameSingle As String
    <DataMember(Name:="author")> Public author As String
    <DataMember(Name:="guid")> Public guid As String

    <DataMember(Name:="kingdom")> Public kingdom As String
    <DataMember(Name:="phylum")> Public phylum As String
    <DataMember(Name:="class")> Public tClass As String
    <DataMember(Name:="order")> Public order As String
    <DataMember(Name:="family")> Public family As String
    <DataMember(Name:="genus")> Public genus As String
End Class