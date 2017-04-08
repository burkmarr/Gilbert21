Public Class clsExportRecipient

    Public Sub New(ByVal intNewRecipientID As Integer, ByVal strNewRecipientName As String)
        intRecipientID = intNewRecipientID
        strRecipientName = strNewRecipientName
    End Sub 'New 

    'Public Overrides Function ToString() As String
    '    Return strRecipientName
    'End Function

    Private intRecipientID As Integer
    Public ReadOnly Property RecipientID() As Integer
        Get
            Return intRecipientID
        End Get
    End Property

    Private strRecipientName As String
    Public ReadOnly Property RecipientName() As String
        Get
            Return strRecipientName
        End Get
    End Property

End Class
