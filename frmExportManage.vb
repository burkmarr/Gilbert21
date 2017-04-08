Imports System.IO
Imports System.Data.SQLite

Public Class frmExport

    Private bOkayed As Boolean

    Public Enum ExportType
        CSV
        MapMate
        GE
        MapInfo
        RODIS
    End Enum

    Public ReadOnly Property Okayed() As Integer
        Get
            Return bOkayed
        End Get
    End Property

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click

        bOkayed = False
        Me.Close()
    End Sub

    Private Sub butCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCommit.Click

        If txtExportTitle.Text.Trim = "" Then
            MessageBox.Show("You must specify a title for this export.")
            Exit Sub
        End If

        If ddlExportType.Text = "" Then
            MessageBox.Show("You must specify an export type.")
            Exit Sub
        End If

        'Check that specified title isn't already used
        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        comExport.CommandText = "Select count(*) from exports where ShortTitle like '" & txtExportTitle.Text.Trim & "'"
        If comExport.ExecuteScalar() > 0 Then
            MessageBox.Show("An export record with this short title already exists.")
            Exit Sub
        End If

        Dim cur As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor

        Dim bFileProduced As Boolean = False

        Select Case ddlExportType.Text

            Case "CSV"
                bFileProduced = ExportToCSV()
            Case "MapMate"
                bFileProduced = ExportToMapMate()
            Case "Google Earth"
                bFileProduced = ExportToGE()
            Case "MapInfo"
                bFileProduced = ExportToMI()
            Case "RODIS"
                bFileProduced = ExportToRODIS()
        End Select

        Me.Cursor = cur

        'comExport.CommandText = "Select last_insert_rowid()"

        If bFileProduced Then
            comExport.CommandText = "Insert into exports(ShortTitle, Type,ExportDate,Notes,File) values(?,?,?,?,?)"
            comExport.Parameters.AddWithValue("ShortTitle", txtExportTitle.Text.Trim)
            comExport.Parameters.AddWithValue("Type", ddlExportType.Text)
            comExport.Parameters.AddWithValue("ExportDate", Format(Today, "dd/MM/yyyy"))
            comExport.Parameters.AddWithValue("Notes", txtExportNotes.Text.Trim)
            comExport.Parameters.AddWithValue("File", SaveFileDialog.FileName)
            comExport.ExecuteNonQuery()

            If MessageBox.Show("Export complete. Do you want to view the exported file?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                'Open the exported with the default program
                Try
                    System.Diagnostics.Process.Start(SaveFileDialog.FileName)
                Catch ex As Exception
                    MessageBox.Show("Unable to open file '" & SaveFileDialog.FileName & "' directly from Gilbert. " & ex.Message)
                End Try
            End If
            Me.Close()
        End If
    End Sub

    Private Sub rbAllRecords_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllRecords.MouseHover

        tt.SetToolTip(rbAllRecords, _
                "Take this option to export all those records " & vbCrLf & _
                "that you've currently got open.")
    End Sub

    Private Sub rbSelectedRecords_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSelectedRecords.MouseHover

        tt.SetToolTip(rbSelectedRecords, _
                "Take this option to export only those records " & vbCrLf & _
                "which you have specifically selected (highlighted).")
    End Sub

    Private Sub cbBiologicalRecords_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBiologicalRecords.MouseHover

        tt.SetToolTip(cbBiologicalRecords, _
                "Check this box to include records " & vbCrLf & _
                "which pass biological record validity checking.")
    End Sub

    Private Sub cbInvalidRecords_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInvalidRecords.MouseHover

        tt.SetToolTip(cbInvalidRecords, _
                "Check this box to include records " & vbCrLf & _
                "the export.")
    End Sub

    Private Sub lblTrackInverval1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrackInterval1.MouseHover

        tt.SetToolTip(lblTrackInterval1, _
                "Add points to Google Earth to mark the GPS " & vbCrLf & _
                "track at the specified point interval.")
    End Sub

    Private Sub lblTrackInterval2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrackInterval2.MouseHover

        tt.SetToolTip(lblTrackInterval2, _
                "Add points to Google Earth to mark the GPS " & vbCrLf & _
                "track at the specified point interval.")
    End Sub

    Private Sub rbNoGPSTracks_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoGPSTracks.MouseHover

        tt.SetToolTip(rbNoGPSTracks, _
                "Don't show any GPS tracks.")
    End Sub

    Private Sub rbAllGPSTracks_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllGPSTracks.MouseHover

        tt.SetToolTip(rbAllGPSTracks, _
                "Show GPS tracks.")
    End Sub

    Private Sub frmExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbExportRecipients.DisplayMember = "RecipientName"
        lbExportRecipients.ValueMember = "RecipientID"
    End Sub

    Private Sub frmExport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        txtExportNotes.Text = ""
        txtExportTitle.Text = ""
        ddlExportType.SelectedIndex = -1
        lbExportRecipients.Items.Clear()
    End Sub

    Public Sub ExportRows(ByVal expType As ExportType, ByVal sw As StreamWriter, ByVal sw2 As StreamWriter)

        Dim row As DataGridViewRow
        Dim bEastingNorthing As Boolean = cbEastingNorthing.Checked

        Dim objGridRef As GridRef = New GridRef
        objGridRef.MakePrefixArrays()

        For Each row In frmMain.dgvRecords.Rows

            If IsRecordForExport(row) Then
                'Export the record
                Select Case expType
                    Case ExportType.CSV
                        ExportCSVRow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.MapMate
                        ExportMapMateRow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.GE
                        ExportGERow(row, sw, objGridRef, bEastingNorthing)
                    Case ExportType.MapInfo
                        ExportMIRow(row, sw, sw2, objGridRef, bEastingNorthing)
                    Case ExportType.RODIS
                        ExportRODISRow(row, sw, objGridRef)
                End Select
            End If
        Next

    End Sub

    Private Function ExportToRODIS() As Boolean

        SaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)

            sw.WriteLine("Scientific Name,Date,Location,Grid-Ref,Observer,Determiner,Sex/Stage,Abundance,Record type,Comments")

            'Records
            ExportRows(ExportType.RODIS, sw, Nothing)
            sw.Close()

            MessageBox.Show("Sweet. Now you need to open the CSV file and save it as an Excel workbook (*.xls extension) in order to import it into RODIS.")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToCSV() As Boolean

        SaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)

            Dim col As DataGridViewColumn
            Dim strLine As String = ""

            'Header
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    If strLine.Length > 0 Then
                        strLine = strLine & ","
                    End If
                    strLine = strLine & col.Name
                End If
            Next

            If cbEastingNorthing.Checked Then
                strLine = strLine & ",Easting,Northing"
            End If

            sw.WriteLine(strLine)

            'Records
            ExportRows(ExportType.CSV, sw, Nothing)
            sw.Close()

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToMapMate() As Boolean

        SaveFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.FileName)
            Dim strLine As String = ""

            'Header
            strLine = "Taxon"
            strLine = strLine & vbTab & "Site"
            strLine = strLine & vbTab & "Gridref"
            strLine = strLine & vbTab & "VC"
            strLine = strLine & vbTab & "Recorder"
            strLine = strLine & vbTab & "Determiner"
            strLine = strLine & vbTab & "Date"
            strLine = strLine & vbTab & "Quantity"
            strLine = strLine & vbTab & "Method"
            strLine = strLine & vbTab & "Sex"
            strLine = strLine & vbTab & "Stage"
            strLine = strLine & vbTab & "Status"
            strLine = strLine & vbTab & "Comment"

            sw.WriteLine(strLine)

            'Records
            ExportRows(ExportType.MapMate, sw, Nothing)
            sw.Close()

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToGE() As Boolean

        SaveFileDialog.Filter = "KML files (*.kml)|*.kml|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            'Create the KML file with the place markers
            Dim srKML As StreamWriter = New StreamWriter(SaveFileDialog.FileName)

            srKML.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            srKML.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")

            srKML.WriteLine("<Folder>")
            srKML.WriteLine("<name>Gilbert 21 records</name>")

            'Styles for records
            KML.StyleKML(srKML, frmOptions.butStyle100km.BackColor, "100km")
            KML.StyleKML(srKML, frmOptions.butStyle10km.BackColor, "hectad")
            KML.StyleKML(srKML, frmOptions.butStyle2km.BackColor, "tetrad")
            KML.StyleKML(srKML, frmOptions.butStyle1km.BackColor, "monad")
            KML.StyleKML(srKML, frmOptions.butStyle100m.BackColor, "6fig")
            KML.StyleKML(srKML, frmOptions.butStyle10m.BackColor, "8fig")
            KML.StyleKML(srKML, frmOptions.butStyle1m.BackColor, "10fig")
            KML.StyleKML(srKML, frmOptions.butStyleInvalid.BackColor, "invalid")

            'Track point style
            srKML.WriteLine("<Style id=""trackPoint"">")
            srKML.WriteLine("<IconStyle>")
            srKML.WriteLine("<color>ff7fffaa</color>")
            srKML.WriteLine("<scale>0.6</scale>")
            srKML.WriteLine("<Icon>")
            srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>")
            srKML.WriteLine("</Icon>")
            srKML.WriteLine("</IconStyle>")
            srKML.WriteLine("</Style>")

            'Track line style
            srKML.WriteLine("<Style id=""trackStyle"">")
            srKML.WriteLine("<LineStyle>")
            srKML.WriteLine("<width>" & nudTrackThickness.Value & "</width>")
            srKML.WriteLine("</LineStyle>")
            srKML.WriteLine("</Style>")

            'Records
            ExportRows(ExportType.GE, srKML, Nothing)

            'Tracks
            If rbAllGPSTracks.Checked Then
                'ExportTracksToGE(srKML, nudTrackInterval.Value)
                ExportTracks(ExportType.GE, srKML, nudTrackInterval.Value)
            End If

            'Close file
            srKML.WriteLine("</Folder>")
            srKML.WriteLine("</kml>")
            srKML.Close()

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExportToMI() As Boolean

        Dim htMIFieldLengths As Hashtable = New Hashtable
        Dim col As DataGridViewColumn
        Dim iCols As Integer
        Dim iLength As Integer
        Dim srMIF As StreamWriter
        Dim srMID As StreamWriter
        Dim srMIFTracks As StreamWriter
        Dim strMIDFile As String
        Dim strMIFTrack As String

        SaveFileDialog.Filter = "MIF files (*.mif)|*.mif|All files (*.*)|*.*"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.InitialDirectory = frmOptions.txtExportFolder.Text

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'Set export folder option if not already set
            If frmOptions.txtExportFolder.Text = "" Then
                frmOptions.txtExportFolder.Text = Path.GetDirectoryName(SaveFileDialog.FileName)
            End If

            'Create the MIF file with the place markers
            srMIF = New StreamWriter(SaveFileDialog.FileName)
            strMIDFile = SaveFileDialog.FileName.Substring(0, SaveFileDialog.FileName.Length - 3) & "mid"
            strMIFTrack = SaveFileDialog.FileName.Substring(0, SaveFileDialog.FileName.Length - 4) & "-track.mif"
            srMID = New StreamWriter(strMIDFile)
            srMIFTracks = New StreamWriter(strMIFTrack)

            'Create the MapInfo MIF header
            srMIF.WriteLine("Version 300")
            srMIF.WriteLine("Charset ""WindowsLatin1""")
            srMIF.WriteLine("Delimiter "",""")
            srMIF.WriteLine("CoordSys Earth Projection 8, 79, ""m"", -2, 49, 0.9996012717, 400000, -100000 Bounds (-7845061.1011, -15524202.1641) (8645061.1011, 4470074.53373)")
            iCols = 0
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    iCols += 1
                End If
            Next
            srMIF.WriteLine("Columns " & iCols.ToString())

            'Get the maximum length of the field values for the MI table
            'and store in the hashtable
            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    htMIFieldLengths.Add(col.Name, 0)
                End If
            Next

            Dim row As DataGridViewRow
            For Each row In frmMain.dgvRecords.Rows
                For Each col In frmMain.dgvRecords.Columns
                    If col.Visible Then
                        iLength = row.Cells(col.Name).Value.ToString.Length
                        If iLength > htMIFieldLengths(col.Name) Then
                            htMIFieldLengths(col.Name) = iLength
                        End If
                    End If
                Next
            Next

            For Each col In frmMain.dgvRecords.Columns
                If col.Visible Then
                    iLength = htMIFieldLengths(col.Name)
                    If iLength > 254 Then
                        iLength = 254
                    End If
                    srMIF.WriteLine(col.Name & " Char(" & htMIFieldLengths(col.Name).ToString() & ")")
                End If
            Next

            srMIF.WriteLine("Data")

            'Records
            ExportRows(ExportType.MapInfo, srMIF, srMID)

            'Tracks
            If rbAllGPSTracks.Checked Then
                ExportTracks(ExportType.MapInfo, srMIFTracks, 0)
            End If

            srMID.Close()
            srMIF.Close()
            srMIFTracks.Close()

            Return True
        Else
            Return False
        End If
    End Function



    Private Function IsRecordForExport(ByVal row As DataGridViewRow) As Boolean

        Dim bExportRow As Boolean
        Dim bOnlySelected As Boolean = rbSelectedRecords.Checked
        Dim bBiologicalRecords As Boolean = cbBiologicalRecords.Checked
        Dim bNoCheckingRecords As Boolean = cbIncludeNoChecking.Checked
        Dim bInvalidRecords As Boolean = cbInvalidRecords.Checked
        Dim bIncludeExcluded As Boolean = cbIncludeExcluded.Checked

        If bOnlySelected And Not row.Selected Then
            'Only selected rows to be included and this record not selected
            bExportRow = False
        ElseIf row.Cells("NoExport").Value = "True" And Not bIncludeExcluded Then
            'Record is marked 'not for export' and this is not to be overidden 
            bExportRow = False
        Else
            'If bBiologicalRecords And IsValid(row, True, False) Then
            '    'This is a valid biological record and these are to be included
            '    bExportRow = True
            'ElseIf bInvalidRecords And Not IsValid(row, True, False) Then
            '    'This is not a valid biological record, but these are to be included
            '    bExportRow = True
            'Else
            '    'Otherwise exclude
            '    bExportRow = False
            'End If
            If row.DefaultCellStyle.BackColor = Color.FromArgb(210, 255, 210) Then
                'Saved valid record
                If bBiologicalRecords Then
                    bExportRow = True
                Else
                    bExportRow = False
                End If
            ElseIf row.DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 255) Then
                'Saved record marked no checking
                If bNoCheckingRecords Then
                    bExportRow = True
                Else
                    bExportRow = False
                End If
            Else 'Modified, new or invalid record
                If bInvalidRecords Then
                    bExportRow = True
                Else
                    bExportRow = False
                End If
            End If
        End If

        Return bExportRow
    End Function

    Private Sub ExportCSVRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim col As DataGridViewColumn
        Dim strLine As String = ""

        'Values
        For Each col In frmMain.dgvRecords.Columns

            If col.Visible Then
                If strLine.Length > 0 Then
                    strLine = strLine & ","
                End If
                strLine = strLine & """" & cfun.NullToEmpty(row.Cells(col.Name).Value).ToString().Replace("""", """""") & """"
            End If
        Next

        'Add easting and northing if required
        If bEastingNorthing Then
            objGridRef.GridRef = row.Cells("GridRef").Value.ToString
            objGridRef.ParseGridRef(True)
            objGridRef.ParseInput(False)

            strLine = strLine & "," & objGridRef.sEastingC & "," & objGridRef.sNorthingC
        End If

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportRODISRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef)

        Dim strCol As String
        Dim strLine As String = ""
        Dim strVal As String

        'Scientific Name,Date,Location,Grid-Ref,Observer,Determiner,Sex/Stage,Abundance,Record type,Comments
        'Values

        Dim colsRODIS As Collection = New Collection
        colsRODIS.Add("ScientificName") 'Scientific Name
        colsRODIS.Add("Date") 'Date
        colsRODIS.Add("Location") 'Location
        colsRODIS.Add("GridRef") 'Grid-Ref
        colsRODIS.Add("Recorder") 'Observer
        colsRODIS.Add("Determiner") 'Determiner
        colsRODIS.Add("Units") 'Sex/Stage
        colsRODIS.Add("Abundance") 'Abundance
        colsRODIS.Add("Blank") 'Record type
        colsRODIS.Add("Comment") 'Comments

        For Each strCol In colsRODIS

            If strLine.Length > 0 Then
                strLine = strLine & ","
            End If
            If strCol <> "Blank" Then
                strVal = cfun.NullToEmpty(row.Cells(strCol).Value).ToString().Replace("""", """""")
                If strVal.ToLower = "p" And strCol = "Abundance" Then
                    strVal = "Present"
                End If
                strLine = strLine & """" & strVal & """"
            End If
        Next

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportMIRow(ByVal row As DataGridViewRow, ByVal swMIF As StreamWriter, ByVal swMID As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim col As DataGridViewColumn
        Dim strLine As String = ""
        Dim strValue As String

        'MID file line
        For Each col In frmMain.dgvRecords.Columns

            If col.Visible Then
                If strLine.Length > 0 Then
                    strLine = strLine & ","
                End If
                strValue = row.Cells(col.Name).Value.ToString()
                If strValue.Length > 254 Then
                    strValue = strValue.Substring(0, 254)
                End If
                strLine = strLine & """" & cfun.NullToEmpty(strValue.Replace("""", """""")) & """"
            End If
        Next
        swMID.WriteLine(strLine)

        'MIF file line
        objGridRef.GridRef = row.Cells("GridRef").Value.ToString
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)
        swMIF.WriteLine("Point " & objGridRef.East.ToString() & " " & objGridRef.North.ToString())
        'Symbol(33, 255, 18)
    End Sub

    Private Sub ExportMapMateRow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)

        Dim strColName As String
        Dim strLine As String = ""

        If row.Cells("GridRef").Value.ToString = "" Then

            'Could happen for a personal note
            Exit Sub
        End If

        'MapMate columns:
        'Taxon,Site,Gridref,VC,Recorder,Determiner,Date,Quantity,Method,Sex,Stage,Status,Comment

        Dim alCols As ArrayList = New ArrayList
        alCols.Add("ScientificName")
        alCols.Add("Location")
        alCols.Add("GridRef")
        alCols.Add("VC")
        alCols.Add("Recorder")
        alCols.Add("Determiner")
        alCols.Add("Date")
        alCols.Add("Abundance")
        alCols.Add("skip")
        alCols.Add("skip")
        alCols.Add("Units")
        alCols.Add("skip")
        alCols.Add("Comment")


        'Values
        For Each strColName In alCols

            If strLine.Length > 0 Then
                strLine = strLine & vbTab
            End If

            If strColName = "skip" Then
                strLine = strLine & """"""
            ElseIf strColName = "VC" Then
                strLine = strLine & "0"
            Else
                strLine = strLine & """" & cfun.NullToEmpty(row.Cells(strColName).Value).ToString().Replace("""", """""") & """"
            End If
        Next

        sw.WriteLine(strLine)
    End Sub

    Private Sub ExportGERow(ByVal row As DataGridViewRow, ByVal sw As StreamWriter, ByVal objGridRef As GridRef, ByVal bEastingNorthing As Boolean)


        Dim strName As String = ""
        If Not cfun.HasNoValue(row.Cells("CommonName")) Then
            strName = row.Cells("CommonName").Value
        ElseIf Not cfun.HasNoValue(row.Cells("ScientificName")) Then
            strName = row.Cells("ScientificName").Value
        End If

        If row.Cells("GridRef").Value.ToString = "" Then

            'Could happen for a personal note
            Exit Sub
        End If

        sw.WriteLine("<Folder>")
        sw.WriteLine("<name>" & strName & "</name>")

        sw.WriteLine("<Placemark>")
        sw.WriteLine("<name>" & strName & "</name>")
        sw.WriteLine("<description>")
        'Values
        Dim strLine As String = ""
        For Each col In frmMain.dgvRecords.Columns
            If col.Visible Then
                strLine = strLine & "<tr><td><b>" & MakeValidXML(col.name) & "</b></td><td>" & MakeValidXML(cfun.NullToEmpty(row.Cells(col.Name).Value).ToString()) & "</td></tr>"
            End If
        Next

        objGridRef.GridRef = row.Cells("GridRef").Value.ToString
        objGridRef.ParseGridRef(True)
        objGridRef.ParseInput(False)

        sw.WriteLine("<table>" & strLine & "</table>")
        sw.WriteLine("</description>")

        If frmMain.IsValid(row, False, False) Then
            sw.WriteLine("<styleUrl>#" & objGridRef.sRefType & "</styleUrl>")
        Else
            sw.WriteLine("<styleUrl>#invalid</styleUrl>")
        End If

        sw.WriteLine("<Point>")
        sw.WriteLine("<coordinates>")

        sw.WriteLine(objGridRef.Easting2LongWGS84(objGridRef.East, objGridRef.North, 0).ToString() & "," & objGridRef.Northing2LatWGS84(objGridRef.East, objGridRef.North, 0).ToString() & ",0")
        sw.WriteLine("</coordinates>")
        sw.WriteLine("</Point>")
        sw.WriteLine("</Placemark>")

        'Render the grid reference squares
        KML.RenderGR(sw, row.Cells("GridRef").Value.ToString, frmMain.IsValid(row, False, False))

        sw.WriteLine("</Folder>")
    End Sub

    Private Sub ExportTracksToGE(ByVal sw As StreamWriter, ByVal intInterval As Integer)

        Dim row As DataRow
        Dim col As DataColumn
        Dim rowDGV As DataGridViewRow
        Dim iCount As Integer
        Dim inFile As clsInputFile = Nothing
        Dim dtTrackDataTable As DataTable

        Dim strTrackFile As String = ""
        Dim strFiletype As String = ""

        'For each record, get the corresponding track FileID if there
        'is one and put into a collection
        Dim intTrackID As Integer
        Dim colFileID As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        comTracks.CommandText = "select FileID from RecordTracks where RecordID = ?;"
        Dim paramRecordID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramRecordID)
        For Each rowDGV In frmMain.dgvRecords.Rows
            paramRecordID.Value = rowDGV.Cells("ID").Value
            intTrackID = comTracks.ExecuteScalar()
            If Not colFileID.Contains(intTrackID.ToString) Then
                colFileID.Add(intTrackID, intTrackID.ToString)
            End If
        Next

        'Now for each of the identified track, get the filename and read in the file
        comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = ?;"
        comTracks.Parameters.Clear()
        Dim paramFileID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramFileID)
        Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTrackFile As DataTable = New DataTable

        If colFileID.Count > 10 Then
            If MessageBox.Show(colFileID.Count.ToString & " tracks are referenced. Are you sure you want to export all of them (it could take some time)?", "Export track warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        For Each intFileID In colFileID

            paramFileID.Value = intFileID
            dtTrackFile.Clear()
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count = 1 Then
                If Not IsDBNull(dtTrackFile.Rows(0)("CurrentPath")) Then
                    strTrackFile = dtTrackFile.Rows(0)("CurrentPath")
                    strFiletype = dtTrackFile.Rows(0)("FileType")

                    inFile = Nothing
                    Select Case strFiletype.ToLower()

                        Case "visiontac"
                            inFile = New clsInputFileVisiontac(strTrackFile)
                        Case "evernoteexport"
                            inFile = New clsInputFileEvernoteExport(strTrackFile)
                    End Select

                    If Not inFile Is Nothing Then
                        For Each dtTrackDataTable In inFile.GetTracks

                            sw.WriteLine("<Placemark>")
                            sw.WriteLine("<name>Untitled Path</name>")
                            sw.WriteLine("<styleUrl>#trackStyle</styleUrl>")
                            sw.WriteLine("<LineString>")
                            sw.WriteLine("<tessellate>1</tessellate>")
                            sw.WriteLine("<coordinates>")

                            For Each row In dtTrackDataTable.Rows

                                If rbAllGPSTracks.Checked Then
                                    sw.WriteLine(row("lon") & "," & row("lat") & ",0 ")
                                End If
                            Next

                            sw.WriteLine("</coordinates>")
                            sw.WriteLine("</LineString>")
                            sw.WriteLine("</Placemark>")

                            'Track interval points
                            If intInterval > 0 Then
                                iCount = 0
                                For Each row In dtTrackDataTable.Rows
                                    iCount += 1
                                    If iCount = 1 Or iCount = dtTrackDataTable.Rows.Count Or iCount Mod intInterval = 0 Then

                                        sw.WriteLine("<Placemark>")

                                        'Attributes
                                        sw.WriteLine("<description>")
                                        sw.WriteLine("<table>")
                                        For Each col In dtTrackDataTable.Columns

                                            sw.WriteLine("<tr><td><b>" & MakeValidXML(col.ColumnName) & "</b></td><td>" & MakeValidXML(row(col.ColumnName)) & "</td></tr>")
                                        Next
                                        sw.WriteLine("</table>")
                                        sw.WriteLine("</description>")

                                        sw.WriteLine("<styleUrl>#trackPoint</styleUrl>")
                                        sw.WriteLine("<Point>")
                                        sw.WriteLine("<coordinates>" & row("lon") & "," & row("lat") & ",0" & "</coordinates>")
                                        sw.WriteLine("</Point>")
                                        sw.WriteLine("</Placemark>")
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
            End If
        Next

        comTracks.Dispose()
        daTrackFile.Dispose()
        db.Dispose()
    End Sub

    Private Sub ExportTracks(ByVal expType As ExportType, ByVal sw As StreamWriter, ByVal intInterval As Integer)

        Dim rowDGV As DataGridViewRow
        Dim inFile As clsInputFile = Nothing
        Dim dtTrackDataTable As DataTable
        Dim intTrack As Integer = 0
        Dim strTrackFile As String = ""
        Dim strFiletype As String = ""

        'For each record, get the corresponding track FileID if there
        'is one and put into a collection
        Dim intTrackID As Integer
        Dim colFileID As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comTracks As SQLiteCommand = New SQLiteCommand(db.conTracks)
        comTracks.CommandText = "select FileID from RecordTracks where RecordID = ?;"
        Dim paramRecordID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramRecordID)
        For Each rowDGV In frmMain.dgvRecords.Rows
            paramRecordID.Value = rowDGV.Cells("ID").Value
            intTrackID = comTracks.ExecuteScalar()
            If Not colFileID.Contains(intTrackID.ToString) Then
                colFileID.Add(intTrackID, intTrackID.ToString)
            End If
        Next

        'Now for each of the identified track, get the filename and read in the file
        comTracks.CommandText = "select CurrentPath, FileType from Tracks where FileID = ?;"
        comTracks.Parameters.Clear()
        Dim paramFileID As SQLiteParameter = New SQLiteParameter
        comTracks.Parameters.Add(paramFileID)
        Dim daTrackFile As SQLiteDataAdapter = New SQLiteDataAdapter(comTracks)
        Dim dtTrackFile As DataTable = New DataTable

        If colFileID.Count > 10 Then
            If MessageBox.Show(colFileID.Count.ToString & " tracks are referenced. Are you sure you want to export all of them (it could take some time)?", "Export track warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        For Each intFileID In colFileID

            paramFileID.Value = intFileID
            dtTrackFile.Clear()
            daTrackFile.Fill(dtTrackFile)

            If dtTrackFile.Rows.Count = 1 Then
                If Not IsDBNull(dtTrackFile.Rows(0)("CurrentPath")) Then
                    strTrackFile = dtTrackFile.Rows(0)("CurrentPath")
                    strFiletype = dtTrackFile.Rows(0)("FileType")

                    inFile = Nothing
                    Select Case strFiletype.ToLower()

                        Case "visiontac"
                            inFile = New clsInputFileVisiontac(strTrackFile)
                    End Select

                    If Not inFile Is Nothing Then
                        For Each dtTrackDataTable In inFile.GetTracks

                            Select Case expType

                                Case ExportType.GE
                                    ExportTrackGE(sw, intInterval, dtTrackDataTable)
                                Case ExportType.MapInfo
                                    intTrack += 1
                                    ExportTrackMI(sw, dtTrackDataTable, intTrack)
                            End Select
                        Next
                    End If
                End If
            End If
        Next

        comTracks.Dispose()
        daTrackFile.Dispose()
        db.Dispose()
    End Sub

    Private Sub ExportTrackGE(ByVal sw As StreamWriter, ByVal intInterval As Integer, ByVal dtTrackDataTable As DataTable)

        Dim row As DataRow
        Dim col As DataColumn
        Dim iCount As Integer

        sw.WriteLine("<Placemark>")
        sw.WriteLine("<name>Untitled Path</name>")
        sw.WriteLine("<styleUrl>#trackStyle</styleUrl>")
        sw.WriteLine("<LineString>")
        sw.WriteLine("<tessellate>1</tessellate>")
        sw.WriteLine("<coordinates>")

        For Each row In dtTrackDataTable.Rows

            If rbAllGPSTracks.Checked Then
                sw.WriteLine(row("lon") & "," & row("lat") & ",0 ")
            End If
        Next

        sw.WriteLine("</coordinates>")
        sw.WriteLine("</LineString>")
        sw.WriteLine("</Placemark>")

        'Track interval points
        If intInterval > 0 Then
            iCount = 0
            For Each row In dtTrackDataTable.Rows
                iCount += 1
                If iCount = 1 Or iCount = dtTrackDataTable.Rows.Count Or iCount Mod intInterval = 0 Then

                    sw.WriteLine("<Placemark>")

                    'Attributes
                    sw.WriteLine("<description>")
                    sw.WriteLine("<table>")
                    For Each col In dtTrackDataTable.Columns

                        sw.WriteLine("<tr><td><b>" & MakeValidXML(col.ColumnName) & "</b></td><td>" & MakeValidXML(row(col.ColumnName)) & "</td></tr>")
                    Next
                    sw.WriteLine("</table>")
                    sw.WriteLine("</description>")

                    sw.WriteLine("<styleUrl>#trackPoint</styleUrl>")
                    sw.WriteLine("<Point>")
                    sw.WriteLine("<coordinates>" & row("lon") & "," & row("lat") & ",0" & "</coordinates>")
                    sw.WriteLine("</Point>")
                    sw.WriteLine("</Placemark>")
                End If
            Next
        End If
    End Sub

    Private Sub ExportTrackMI(ByVal sw As StreamWriter, ByVal dtTrackDataTable As DataTable, ByVal intTrack As Integer)

        Dim row As DataRow
        Dim objGR As GridRef = New GridRef
        objGR.MakePrefixArrays()
        Dim dblEasting As Double
        Dim dblNorthing As Double

        If intTrack = 1 Then
            sw.WriteLine("Version 300")
            sw.WriteLine("Charset ""WindowsLatin1""")
            sw.WriteLine("Delimiter "",""")
            sw.WriteLine("CoordSys Earth Projection 8, 79, ""m"", -2, 49, 0.9996012717, 400000, -100000 Bounds (-7845061.1011, -15524202.1641) (8645061.1011, 4470074.53373)")
            sw.WriteLine("Columns 1")
            sw.WriteLine("ID Char(10)")
            sw.WriteLine("Data")
        End If

        sw.WriteLine("Pline " & dtTrackDataTable.Rows.Count)

        For Each row In dtTrackDataTable.Rows

            dblEasting = objGR.LongWGS842Easting(Convert.ToDouble(row("lat")), Convert.ToDouble(row("lon")), 0)
            dblNorthing = objGR.LatWGS842Northing(Convert.ToDouble(row("lat")), Convert.ToDouble(row("lon")), 0)
            If rbAllGPSTracks.Checked Then
                sw.WriteLine(CInt(dblEasting).ToString & " " & CInt(dblNorthing).ToString)
            End If
        Next
    End Sub

    Private Function MakeValidXML(ByVal objVal As Object) As String

        Dim i As Integer
        Dim chr As Char
        Dim chrNew As String
        Dim strNew As String = ""
        Dim strVal As String = ""

        If Not cfun.HasNoValue(objVal) Then
            strVal = objVal.ToString
        End If

        For i = 0 To strVal.Length - 1

            chr = strVal.Substring(i, 1)
            Select Case chr
                Case "&"
                    chrNew = "&amp;"
                Case "<"
                    chrNew = "&lt;"
                Case ">"
                    chrNew = "&gt;"
                Case """"
                    chrNew = "&quot;"
                Case "'"
                    chrNew = "&#39;"
                Case Else
                    'Test for null
                    If Asc(chr) = 0 Then
                        chrNew = ""
                    Else
                        chrNew = chr
                    End If
            End Select

            strNew = strNew & chrNew
        Next

        Return strNew
    End Function

    Public Sub GEQuick()

        Dim strKMLFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\G21QuickView.kml"

        'Set export folder option if not already set
        If frmOptions.txtExportFolder.Text = "" Then
            frmOptions.txtExportFolder.Text = Path.GetDirectoryName(strKMLFile)
        End If

        'Create the KML file with the place markers
        Dim srKML As StreamWriter = New StreamWriter(strKMLFile)

        srKML.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        srKML.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")

        srKML.WriteLine("<Folder>")
        srKML.WriteLine("<name>Gilbert 21 records</name>")

        'Styles for records
        KML.StyleKML(srKML, frmOptions.butStyle100km.BackColor, "100km")
        KML.StyleKML(srKML, frmOptions.butStyle10km.BackColor, "hectad")
        KML.StyleKML(srKML, frmOptions.butStyle2km.BackColor, "tetrad")
        KML.StyleKML(srKML, frmOptions.butStyle1km.BackColor, "monad")
        KML.StyleKML(srKML, frmOptions.butStyle100m.BackColor, "6fig")
        KML.StyleKML(srKML, frmOptions.butStyle10m.BackColor, "8fig")
        KML.StyleKML(srKML, frmOptions.butStyle1m.BackColor, "10fig")
        KML.StyleKML(srKML, frmOptions.butStyleInvalid.BackColor, "invalid")

        'Track point style
        srKML.WriteLine("<Style id=""trackPoint"">")
        srKML.WriteLine("<IconStyle>")
        srKML.WriteLine("<color>ff7fffaa</color>")
        srKML.WriteLine("<scale>0.6</scale>")
        srKML.WriteLine("<Icon>")
        srKML.WriteLine("<href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>")
        srKML.WriteLine("</Icon>")
        srKML.WriteLine("</IconStyle>")
        srKML.WriteLine("</Style>")

        'Records
        ExportRows(ExportType.GE, srKML, Nothing)

        'Close file
        srKML.WriteLine("</Folder>")
        srKML.WriteLine("</kml>")
        srKML.Close()

        'Open the KML file with the default program (Google Earth)
        If frmOptions.chkGE.Checked Then
            Try
                System.Diagnostics.Process.Start(strKMLFile)
            Catch ex As Exception
                MessageBox.Show("Could not open 'strKMLFile' from Gilbert. Try starting Google Earth first and then opening the file from there.")
            End Try
        Else
            MessageBox.Show("Created: " & strKMLFile & ". If you want GE files to open automatically, check the box on the options dialog.")
        End If
    End Sub

    Private Sub butAddRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddRecipient.Click

        frmExportSelectRecipients.ShowDialog()
        Dim recipient As clsRecipient
  
        'Ensure that none of the items in the list has been deleted
        Dim colDeletedRecipients As Collection = New Collection
        Dim db As clsDB = New clsDB
        Dim comExport As SQLiteCommand = New SQLiteCommand()
        comExport.Connection = db.conExports

        For Each recipient In lbExportRecipients.Items
            comExport.CommandText = "Select count(*) from recipients where RecipientID = " & recipient.RecipientID.ToString
            If comExport.ExecuteScalar() = 0 Then
                colDeletedRecipients.Add(recipient)
            End If
        Next
        For Each recipient In colDeletedRecipients
            lbExportRecipients.Items.Remove(recipient)
        Next

        'Add selected recipient
        If frmExportSelectRecipients.RecipientID > 0 Then
            For Each recipient In lbExportRecipients.Items
                If recipient.RecipientID = frmExportSelectRecipients.RecipientID Then
                    MessageBox.Show("Recipient already included.")
                    Exit Sub
                End If
            Next
            recipient = New clsRecipient(frmExportSelectRecipients.RecipientID, frmExportSelectRecipients.RecipientName)
            lbExportRecipients.Items.Add(recipient)
        End If
    End Sub

    Private Sub butRemoveRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemoveRecipient.Click

        If Not lbExportRecipients Is Nothing Then

            lbExportRecipients.Items.Remove(lbExportRecipients.SelectedItem)
        End If
    End Sub

    Private Class clsRecipient

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

    End Class 'clsRecipient


End Class