Public Class clsMediaItem

    Private strFullPath As String
    Public ReadOnly Property FullPath() As String
        Get
            Return strFullPath
        End Get
    End Property

    Private strHeadline As String
    Public ReadOnly Property Headline() As String
        Get
            Return strHeadline
        End Get
    End Property

    Private intMediaID As Integer
    Public ReadOnly Property MediaID() As Integer
        Get
            Return intMediaID
        End Get
    End Property

    Private intOrder As Integer
    Public ReadOnly Property Order() As Integer
        Get
            Return intOrder
        End Get
    End Property

    Public Overrides Function ToString() As String

        Dim strToString As String = intOrder.ToString & ". "

        If strHeadline <> "" Then
            strToString = strToString & strHeadline
        Else
            strToString = strToString & strFullPath
        End If

        Return strToString
    End Function

    Public Function ListViewItems() As String()

        Dim lvi(2) As String
        lvi(0) = Me.ToString
        lvi(1) = intMediaID.ToString
        lvi(2) = strFullPath
        Return lvi
    End Function

    Public Sub New(ByVal row As DataRow)

        If cfun.HasNoValue(row("Order")) Then
            intOrder = 0
        Else
            intOrder = row("Order")
        End If
        intMediaID = row("FileID")
        strFullPath = row("FullPath")
    End Sub
End Class
