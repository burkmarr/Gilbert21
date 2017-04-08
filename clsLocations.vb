Imports System.Math
Imports System.IO
Imports System.Data.SQLite

Public Class clsLocations

    Private objLocations() As clsLocation
    Private objTowns() As clsLocation

    Public Enum PlaceType
        Location
        Town
    End Enum

    Public Sub New(ByVal strGR As String, ByVal strDB As String)

        Dim dblEast As Double
        Dim dblNorth As Double
        Dim dblDistance As Double
        Dim intIndex As Integer
        Dim charType As Char
        Dim dr As DataRow

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()
        objGridRef.GridRef = strGR
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        Dim dblEasting As Double = Math.Round(objGridRef.East)
        Dim dblNorthing As Double = Math.Round(objGridRef.North)

        Dim dtInput As DataTable = New DataTable()
        Dim daSQLite As SQLiteDataAdapter

        Dim db As clsDB = New clsDB

        'Select from the OSDistrictVector Gaz
        '(This query was failing in Access when a ten fig grid ref was used and easting and northing 
        'had values of nnnnnn.5. Don't know why. Rounding easting and northing to nearest
        'whole number fixed the problem.)
        Dim strSQL As String = "Select id, x, y, name, type from osDistrictVectorGaz where "
        strSQL = strSQL & "x > " & dblEasting - 1000 & " and x < " & dblEasting + 1000 & " and "
        strSQL = strSQL & "y > " & dblNorthing - 1000 & " and y < " & dblNorthing + 1000

        daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
        daSQLite.Fill(dtInput) 'Should append

        If dtInput.Rows.Count = 0 Then
            'Select from the OS50k Gaz
            strSQL = "Select seq as id, east as x, north as y, def_nam as name, '' as type from os50kgaz where "
            strSQL = strSQL & "east > " & dblEasting - 2000 & " and east < " & dblEasting + 2000 & " and "
            strSQL = strSQL & "north > " & dblNorthing - 2000 & " and north < " & dblNorthing + 2000

            daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
            daSQLite.Fill(dtInput)
        End If

        'Select Town from the OS50k Gaz view
        strSQL = "Select east as x, north as y, def_nam as name from os50kgazTownsCities where "
        strSQL = strSQL & "east > " & dblEasting - 10000 & " and east < " & dblEasting + 10000 & " and "
        strSQL = strSQL & "north > " & dblNorthing - 10000 & " and north < " & dblNorthing + 10000

        Dim dtTowns As DataTable = New DataTable()
        daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
        daSQLite.Fill(dtTowns)

        'If no Towns within 10km then try within 25
        If dtTowns.Rows.Count = 0 Then
            strSQL = "Select east as x, north as y, def_nam as name from os50kgazTownsCities where "
            strSQL = strSQL & "east > " & dblEasting - 25000 & " and east < " & dblEasting + 25000 & " and "
            strSQL = strSQL & "north > " & dblNorthing - 25000 & " and north < " & dblNorthing + 25000

            daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
            daSQLite.Fill(dtTowns)
        End If

        'Add the Towns to the collection
        For Each dr In dtTowns.Rows

            dblEast = dr.Item("x")
            dblNorth = dr.Item("y")
            dblDistance = Sqrt((dblEasting - dblEast) ^ 2 + (dblNorthing - dblNorth) ^ 2)

            AddLocation(PlaceType.Town, dr.Item("name"), dblDistance, 0, "", dblEast, dblNorth)
        Next

        'Add the locations to the collection
        For Each dr In dtInput.Rows

            dblEast = dr.Item("x")
            dblNorth = dr.Item("y")
            dblDistance = Sqrt((dblEasting - dblEast) ^ 2 + (dblNorthing - dblNorth) ^ 2)
            intIndex = dr.Item("id")
            If cfun.HasNoValue(dr.Item("type")) Then
                charType = ""
            Else
                charType = dr.Item("type")
            End If
            AddLocation(PlaceType.Location, dr.Item("name"), dblDistance, intIndex, charType, dblEast, dblNorth)
        Next
        daSQLite.Dispose()
        db.Dispose()
    End Sub

    Public Sub New(ByVal strLocation As String, ByVal strTown As String, ByVal strPrefix As String, ByVal strDB As String)

        Dim dblEast As Double
        Dim dblNorth As Double
        Dim dblDistance As Double
        Dim intIndex As Integer
        Dim charType As Char
        Dim dr As DataRow

        Dim dtInput As DataTable = New DataTable()
        Dim daSQLite As SQLiteDataAdapter

        Dim db As clsDB = New clsDB

        'Select from the OSDistrictVector Gaz

        Dim strSQL As String = "Select id, x, y, name, type from osDistrictVectorGaz where name like '" & strLocation & "'"

        daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
        daSQLite.Fill(dtInput) 'Should append

        If dtInput.Rows.Count = 0 Then
            'Select from the OS50k Gaz
            strSQL = "Select seq as id, east as x, north as y, def_nam as name, '' as type from os50kgaz where def_nam like '" & strLocation & "'"

            daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
            daSQLite.Fill(dtInput)
        End If

        'Select Town from the OS50k Gaz view
        'strSQL = "Select east as x, north as y, def_nam as name from os50kgazTownsCities where "

        'Dim dtTowns As DataTable = New DataTable()
        'daSQLite = New SQLiteDataAdapter(strSQL, db.conGazetteer)
        'daSQLite.Fill(dtTowns)

        'Add the Towns to the collection
        'For Each dr In dtTowns.Rows

        '    dblEast = dr.Item("x")
        '    dblNorth = dr.Item("y")
        '    dblDistance = Sqrt((dblEasting - dblEast) ^ 2 + (dblNorthing - dblNorth) ^ 2)

        '    AddLocation(PlaceType.Town, dr.Item("name"), dblDistance, 0, "", dblEast, dblNorth)
        'Next

        'Add the locations to the collection
        For Each dr In dtInput.Rows

            dblEast = dr.Item("x")
            dblNorth = dr.Item("y")
            'dblDistance = Sqrt((dblEasting - dblEast) ^ 2 + (dblNorthing - dblNorth) ^ 2)
            dblDistance = 0
            intIndex = dr.Item("id")
            If cfun.HasNoValue(dr.Item("type")) Then
                charType = ""
            Else
                charType = dr.Item("type")
            End If
            AddLocation(PlaceType.Location, dr.Item("name"), dblDistance, intIndex, charType, dblEast, dblNorth)
        Next
        daSQLite.Dispose()
        db.Dispose()
    End Sub

    Shared Function IsPrefixLoaded(ByVal strPrefix As String) As Boolean

        Dim bResult As Boolean
        Dim db As clsDB = New clsDB

        Dim objGR As GridRef = New GridRef
        objGR.MakePrefixArrays()
        objGR.GridRef = strPrefix
        objGR.ParseGridRef(True)
        objGR.ParseInput(False)

        Dim strSQL As String = "Select count(*) from osDistrictVectorGaz where "
        strSQL = strSQL & "x > " & objGR.East - 50000 & " and x < " & objGR.East + 50000 & " and "
        strSQL = strSQL & "y > " & objGR.North - 50000 & " and y < " & objGR.North + 50000
        Dim comSQL As SQLiteCommand = New SQLiteCommand(strSQL, db.conGazetteer)


        If comSQL.ExecuteScalar > 100 Then
            bResult = True
        Else
            bResult = False
        End If
        comSQL.Dispose()
        db.Dispose()

        Return bResult
    End Function

    Public Sub AddLocation(ByVal type As PlaceType, ByVal strLocation As String, ByVal dblDistance As Double, ByVal intIndex As Integer, ByVal charType As Char, ByVal dblEasting As Double, ByVal dblNorthing As Double)

        Dim i As Integer
        Dim objLoc() As clsLocation

        Select Case type
            Case PlaceType.Location
                objLoc = objLocations
            Case Else
                objLoc = objTowns
        End Select

        If objLoc Is Nothing Then
            i = 1
        Else
            i = objLoc.Length + 1
        End If
        Array.Resize(objLoc, i)

        objLoc(i - 1) = New clsLocation(strLocation, dblDistance, intIndex, charType, dblEasting, dblNorthing)

        Select Case type
            Case PlaceType.Location
                objLocations = objLoc
            Case Else
                objTowns = objLoc
        End Select
    End Sub

    Public Function getNearestLocationName(ByVal type As PlaceType) As String

        Dim objLocs() As clsLocation
        Dim objLoc As clsLocation
        Dim retVal As String = ""

        Select Case type
            Case PlaceType.Location
                objLocs = objLocations
            Case Else
                objLocs = objTowns
        End Select

        If Not objLocs Is Nothing Then
            Array.Sort(objLocs)

            For Each objLoc In objLocs

                If objLoc.Type <> "D" Then
                    retVal = objLoc.PlaceName
                    Exit For
                End If
            Next

            Return retVal
        Else
            Return ""
        End If
    End Function

    Public Sub PopulateManageLocationsDGV(ByRef lv As ListView)

        Dim green As Color = Color.FromArgb(210, 255, 210)
        Dim red As Color = Color.FromArgb(255, 210, 210)

        lv.Items.Clear()

        For i = 0 To objLocations.Length - 1

            Dim item As ListViewItem = lv.Items.Add(objLocations(i).PlaceName)
            item.SubItems.Add(objLocations(i).Type)
            item.SubItems.Add(objLocations(i).Index)
            item.SubItems.Add(Round(objLocations(i).Easting))
            item.SubItems.Add(Round(objLocations(i).Northing))

            If objLocations(i).Type = "G" Then
                item.BackColor = green
                item.UseItemStyleForSubItems = True
            ElseIf objLocations(i).Type = "D" Then
                item.BackColor = red
                item.UseItemStyleForSubItems = True
            End If
        Next
    End Sub

    Public Sub PopulateDataGridView(ByRef lv As ListView, ByVal type As PlaceType)

        Dim i As Integer
        Dim bShaded As Boolean
        Dim bShadingEnded As Boolean

        Dim objLoc() As clsLocation

        Select Case type
            Case PlaceType.Location
                objLoc = objLocations
            Case Else
                objLoc = objTowns
        End Select

        lv.Items.Clear()

        'If no grid ref is yet specified, then objLoc can be null here - exit sub if so
        If objLoc Is Nothing Then
            Exit Sub
        End If

        Array.Sort(objLoc)

        Dim shaded As Color = Color.FromArgb(210, 255, 210)

        For i = 0 To objLoc.Length - 1

            If Not objLoc(i).Type = "D" Then

                Dim item As ListViewItem = lv.Items.Add(objLoc(i).PlaceName)
                item.SubItems.Add(Round(objLoc(i).Distance))

                'If the gazetteer entry is of type 'G' which means added by Gilbert 21, then
                'tag the item with the index of the item so that it can be located in DB.
                If objLoc(i).Type = "G" Then
                    item.Tag = objLoc(i).Index
                Else
                    item.Tag = 0
                End If

                If i = 0 Then
                    bShaded = True
                ElseIf objLoc(i).Distance = objLoc(i - 1).Distance Then
                    bShaded = True
                Else
                    bShadingEnded = True
                    bShaded = False
                End If

                If bShaded And Not bShadingEnded Then
                    item.BackColor = shaded
                    item.UseItemStyleForSubItems = True
                End If
            End If
        Next
    End Sub

    Public Sub GenerateLocationKML()

        Dim objLoc As clsLocation
        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()

        'Create the KML file with the place markers
        Dim strKMLFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\G21GridRef.kml"
        Dim srKML As StreamWriter = New StreamWriter(strKMLFile)

        srKML.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        srKML.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")

        srKML.WriteLine("<Folder>")
        srKML.WriteLine("<name>Gilbert 21 Locations</name>")

        'Recorded location style
        srKML.WriteLine("<Style id=""recYellow"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<scale>0.8</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("<hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels""/>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")

        srKML.WriteLine("<Style id=""recRed"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<scale>0.8</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("<hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels""/>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")

        srKML.WriteLine("<Style id=""recGreen"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<scale>0.8</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/pushpin/grn-pushpin.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("<hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels""/>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")


        For Each objLoc In objLocations
            'Render the recorded lat/lon position 
            srKML.WriteLine("<Placemark>")
            srKML.WriteLine("<name>" & objLoc.PlaceName & " (" & objLoc.Index.ToString & ")</name>")

            Select Case objLoc.Type
                Case "G"
                    srKML.WriteLine("<styleUrl>#recGreen</styleUrl>")
                Case "D"
                    srKML.WriteLine("<styleUrl>#recRed</styleUrl>")
                Case Else
                    srKML.WriteLine("<styleUrl>#recYellow</styleUrl>")
            End Select

            srKML.WriteLine("<Point>")
            srKML.WriteLine("<coordinates>")
            srKML.WriteLine(objGridRef.Easting2LongWGS84(objLoc.Easting, objLoc.Northing, 100) & "," & objGridRef.Northing2LatWGS84(objLoc.Easting, objLoc.Northing, 100) & ",0")
            srKML.WriteLine("</coordinates>")
            srKML.WriteLine("</Point>")
            srKML.WriteLine("</Placemark>")
        Next

        'Close file
        srKML.WriteLine("</Folder>")
        srKML.WriteLine("</kml>")
        srKML.Close()

        'Open the KML files with the default program (Google Earth)
        If frmOptions.chkGE.Checked Then
            System.Diagnostics.Process.Start(strKMLFile)
        Else
            MessageBox.Show("Created: " & strKMLFile & ". If you want GE files to open automatically, check the box on the options dialog.")
        End If

    End Sub
End Class

Class EnumeratorLoc
    Implements IEnumerator

    Private objLocation() As clsLocation
    Private Cursor As Integer

    Sub New(ByVal objRecordMapping() As clsRecordMapping)
        Me.objLocation = objLocation
        Cursor = -1
    End Sub

    Public Sub Reset() Implements IEnumerator.Reset
        Cursor = -1
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        If Cursor < objLocation.Length Then
            Cursor = Cursor + 1
        End If

        If (Cursor = objLocation.Length) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            If ((Cursor < 0) Or (Cursor = objLocation.Length)) Then
                Throw New InvalidOperationException()
            Else
                Return objLocation(Cursor)
            End If
        End Get
    End Property

End Class

Public Class clsLocation

    Implements IComparable

    Sub New(ByVal strPlaceNameIn As String, ByVal dblDistanceIn As Double, ByVal intIndexIn As Integer, ByVal charTypeIn As Char, ByVal dblEastingIn As Double, ByVal dblNorthingIn As Double)

        strPlaceName = strPlaceNameIn
        dblDistance = dblDistanceIn
        dblEasting = dblEastingIn
        dblNorthing = dblNorthingIn
        intIndex = intIndexIn
        charType = charTypeIn
    End Sub

    Private intIndex As Integer
    Public Property Index() As String
        Get
            Return intIndex
        End Get
        Set(ByVal value As String)
            intIndex = value
        End Set
    End Property

    Private charType As Char
    Public Property Type() As String
        Get
            Return charType
        End Get
        Set(ByVal value As String)
            charType = value
        End Set
    End Property

    Private strPlaceName As String
    Public Property PlaceName() As String
        Get
            Return strPlaceName
        End Get
        Set(ByVal value As String)
            strPlaceName = value
        End Set
    End Property

    Private dblDistance As Double
    Public Property Distance() As Double
        Get
            Return dblDistance
        End Get
        Set(ByVal value As Double)
            dblDistance = value
        End Set
    End Property

    Private dblEasting As Double
    Public Property Easting() As Double
        Get
            Return dblEasting
        End Get
        Set(ByVal value As Double)
            dblEasting = value
        End Set
    End Property

    Private dblNorthing As Double
    Public Property Northing() As Double
        Get
            Return dblNorthing
        End Get
        Set(ByVal value As Double)
            dblNorthing = value
        End Set
    End Property

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

        Dim objLoc As clsLocation
        objLoc = obj

        If dblDistance < objLoc.Distance Then
            'If distance of this location less than that of comparable object then return 1
            Return -1
        ElseIf dblDistance = objLoc.Distance Then
            'If distances are equal then return according to alpabetical sort of names
            If String.Compare(strPlaceName, objLoc.PlaceName, False) > -1 Then
                Return -1
            Else
                Return 1
            End If
        Else
            Return 1
        End If
    End Function
End Class