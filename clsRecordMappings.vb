Imports System.Collections

Public Class clsRecordMappings
    Implements ICollection

    Private objRecordMapping(27) As clsRecordMapping

    Private Ct As Integer

    Sub New()

        objRecordMapping(0) = New clsRecordMapping("ID", "ID", OleDb.OleDbType.Integer, 0, False, False, False)
        objRecordMapping(1) = New clsRecordMapping("GUID", "GUID", OleDb.OleDbType.VarWChar, 36, False, False, False)
        objRecordMapping(2) = New clsRecordMapping("FileName", "FileName", OleDb.OleDbType.VarWChar, 50, False, False, False)
        objRecordMapping(3) = New clsRecordMapping("FileIndex", "FileIndex", OleDb.OleDbType.Integer, 0, False, False, False)
        objRecordMapping(4) = New clsRecordMapping("FileLon", "FileLon", OleDb.OleDbType.Double, 0, False, False, False)
        objRecordMapping(5) = New clsRecordMapping("FileLat", "FileLat", OleDb.OleDbType.Double, 0, False, False, False)
        objRecordMapping(6) = New clsRecordMapping("Entered", "Entered", OleDb.OleDbType.Date, 0, False, False, False)
        objRecordMapping(7) = New clsRecordMapping("Modified", "Modified", OleDb.OleDbType.Date, 0, False, False, False)
        objRecordMapping(8) = New clsRecordMapping("NoExport", "NoExport", OleDb.OleDbType.Boolean, 0, False, True, False)
        objRecordMapping(9) = New clsRecordMapping("DateTimeKey", "DateTimeKey", OleDb.OleDbType.VarWChar, 12, False, False, False)
        objRecordMapping(10) = New clsRecordMapping("Recorder", "Recorder", OleDb.OleDbType.VarWChar, 255, True, True, False)
        objRecordMapping(11) = New clsRecordMapping("Determiner", "Determiner", OleDb.OleDbType.VarWChar, 255, False, True, False)
        objRecordMapping(12) = New clsRecordMapping("Confirmer", "Confirmer", OleDb.OleDbType.VarWChar, 255, False, True, False)
        objRecordMapping(13) = New clsRecordMapping("CommonName", "CommonName", OleDb.OleDbType.VarWChar, 255, True, True, True)
        objRecordMapping(14) = New clsRecordMapping("ScientificName", "ScientificName", OleDb.OleDbType.VarWChar, 255, True, True, True)
        objRecordMapping(15) = New clsRecordMapping("TaxonGroup", "TaxonGroup", OleDb.OleDbType.VarWChar, 50, False, True, True)
        objRecordMapping(16) = New clsRecordMapping("Abundance", "Abundance", OleDb.OleDbType.VarWChar, 50, True, True, True)
        objRecordMapping(17) = New clsRecordMapping("Units", "Units", OleDb.OleDbType.VarWChar, 50, True, True, True)
        objRecordMapping(18) = New clsRecordMapping("Location", "Location", OleDb.OleDbType.VarWChar, 255, True, True, False)
        objRecordMapping(19) = New clsRecordMapping("Town", "Town", OleDb.OleDbType.VarWChar, 255, True, True, False)
        objRecordMapping(20) = New clsRecordMapping("GridRef", "GridRef", OleDb.OleDbType.VarWChar, 12, True, True, False)
        objRecordMapping(21) = New clsRecordMapping("Lon", "Lon", OleDb.OleDbType.Double, 0, False, False, False)
        objRecordMapping(22) = New clsRecordMapping("Lat", "Lat", OleDb.OleDbType.Double, 0, False, False, False)
        objRecordMapping(23) = New clsRecordMapping("RecDate", "Date", OleDb.OleDbType.Date, 0, True, True, False)
        objRecordMapping(24) = New clsRecordMapping("RecTime", "Time", OleDb.OleDbType.VarWChar, 5, False, True, False)
        objRecordMapping(25) = New clsRecordMapping("TimeZone", "TimeZone", OleDb.OleDbType.VarWChar, 50, False, False, False)
        objRecordMapping(26) = New clsRecordMapping("Comment", "Comment", OleDb.OleDbType.LongVarWChar, 0, True, True, False)
        objRecordMapping(27) = New clsRecordMapping("PersonalNotes", "PersonalNotes", OleDb.OleDbType.LongVarWChar, 0, True, False, False)

    End Sub

    Public Sub CopyTo(ByVal myArr As Array, ByVal index As Integer) Implements ICollection.CopyTo
        'Dim i As Integer
        'For Each i In intArr
        'myArr(index) = i
        'index = index + 1
        'Next
    End Sub

    Public Function GetEnumerator() As IEnumerator Implements ICollection.GetEnumerator
        Return New Enumerator(objRecordMapping)
    End Function

    'The IsSynchronized Boolean property returns True if the 
    'collection is designed to be thread safe; otherwise, it returns False.
    ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property

    'The SyncRoot property returns an object, which is used to synchronize 
    'the collection. This should return the instance of the object or return the 
    'SyncRoot of another collection if the collection contains other collections.
    '
    ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property

    'The ReadOnly property Count returns the number 
    'of items in the custom collection.
    ReadOnly Property Count() As Integer Implements ICollection.Count
        Get
            Return Ct
        End Get
    End Property

End Class

Class Enumerator
    Implements IEnumerator

    Private objRecordMapping() As clsRecordMapping
    Private Cursor As Integer

    Sub New(ByVal objRecordMapping() As clsRecordMapping)
        Me.objRecordMapping = objRecordMapping
        Cursor = -1
    End Sub

    Public Sub Reset() Implements IEnumerator.Reset
        Cursor = -1
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        If Cursor < objRecordMapping.Length Then
            Cursor = Cursor + 1
        End If

        If (Cursor = objRecordMapping.Length) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            If ((Cursor < 0) Or (Cursor = objRecordMapping.Length)) Then
                Throw New InvalidOperationException()
            Else
                Return objRecordMapping(Cursor)
            End If
        End Get
    End Property

End Class

Public Class clsRecordMapping

    Sub New(ByVal sDBFieldName As String, ByVal sG21FieldName As String, ByVal dType As OleDb.OleDbType, ByVal intLength As Integer, ByVal bInitiallyVisible As Boolean, ByVal bCanBeClearedOnCopy As Boolean, ByVal bInitiallyClearedOnCopy As Boolean)

        DBFieldName = sDBFieldName
        G21FieldName = sG21FieldName
        DBType = dType
        FieldLength = intFieldLength
        InitiallyVisible = bInitiallyVisible
        CanBeClearedOnCopy = bCanBeClearedOnCopy
        InitiallyClearedOnCopy = bInitiallyClearedOnCopy
    End Sub

    Private strDBFieldName As String
    Public Property DBFieldName() As String
        Get
            Return strDBFieldName
        End Get
        Set(ByVal value As String)
            strDBFieldName = value
        End Set
    End Property

    Private strG21FieldName As String
    Public Property G21FieldName() As String
        Get
            Return strG21FieldName
        End Get
        Set(ByVal value As String)
            strG21FieldName = value
        End Set
    End Property

    Private dbtType As OleDb.OleDbType
    Public Property DBType() As OleDb.OleDbType
        Get
            Return dbtType
        End Get
        Set(ByVal value As OleDb.OleDbType)
            dbtType = value
        End Set
    End Property

    Private intFieldLength As Integer
    Public Property FieldLength() As Integer
        Get
            Return intFieldLength
        End Get
        Set(ByVal value As Integer)
            intFieldLength = value
        End Set
    End Property

    Private bInitiallyVisible As Boolean
    Public Property InitiallyVisible() As Boolean
        Get
            Return bInitiallyVisible
        End Get
        Set(ByVal value As Boolean)
            bInitiallyVisible = value
        End Set
    End Property

    Private bCanBeClearedOnCopy As Boolean
    Public Property CanBeClearedOnCopy() As Boolean
        Get
            Return bCanBeClearedOnCopy
        End Get
        Set(ByVal value As Boolean)
            bCanBeClearedOnCopy = value
        End Set
    End Property

    Private bInitiallyClearedOnCopy As Boolean
    Public Property InitiallyClearedOnCopy() As Boolean
        Get
            Return bInitiallyClearedOnCopy
        End Get
        Set(ByVal value As Boolean)
            bInitiallyClearedOnCopy = value
        End Set
    End Property
End Class

