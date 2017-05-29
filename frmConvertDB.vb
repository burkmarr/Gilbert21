Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.Win32
Imports System.Data.SQLite

Public Class frmConvertDB

    Dim conAccessDB As OleDbConnection
    Dim conMain As New SQLiteConnection
    Dim conGazetteer As New SQLiteConnection
    Dim conVoice As New SQLiteConnection
    Dim conTracks As New SQLiteConnection
    Dim conMedia As New SQLiteConnection

    Public Sub V2DB(ByVal bCopyAccessSpecified As Boolean)

        Cursor = Cursors.WaitCursor

        Dim bCopyAccess As Boolean = bCopyAccessSpecified

        If bCopyAccess Then
            If txtDB.Text.Length > 0 Then

                'Test access DB connection
                conAccessDB = New OleDbConnection("Provider=Microsoft.jet.oledb.4.0;data source=" & txtDB.Text)
                Try
                    conAccessDB.Open()
                Catch ex As Exception
                    MessageBox.Show("Failed to connect to V1 Gilbert 21 DB: " & ex.Message)
                    Cursor = Cursors.Arrow
                    Exit Sub
                End Try
            Else
                bCopyAccess = False
            End If
        End If

        'Delete the SQLite DB if it already exists
        If Not Directory.Exists(txtDBFolder.Text) Then
            MessageBox.Show("The folder '" & txtDBFolder.Text & "' must be created first.")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        'The connection will create empty database files so just checking if the files are
        'present isn't enough. In order to see if an active DB is present, we need to check
        'if the DB files are over a certain size.
        Dim fi As FileInfo
        Dim bNonEmptyFile As Boolean = False
        For Each strFile In Directory.GetFiles(txtDBFolder.Text, "*.db3")
            fi = New FileInfo(strFile)
            If fi.Length > 0 Then
                bNonEmptyFile = True
            End If
        Next

        If bNonEmptyFile Then

            Dim response As MessageBoxButtons = MessageBox.Show("Database files already exist in '" & txtDBFolder.Text & "'. Are you sure that you want to overwrite them?", "Database exists", MessageBoxButtons.YesNo)
            If response = Windows.Forms.DialogResult.No Then
                Cursor = Cursors.Arrow
                Exit Sub
            ElseIf response = Windows.Forms.DialogResult.Yes Then
                Dim strFile2 As String
                For Each strFile2 In Directory.GetFiles(txtDBFolder.Text, "*.db3")
                    File.Delete(strFile2)
                Next
            Else
                'Windows.Forms.DialogResult.No - just carry on
            End If
        End If

        'Test SQLite DB connections (will create DBs if not already exist)
        conMain.ConnectionString = "Data Source=" & Path.Combine(txtDBFolder.Text, "g21main.db3") & ";"
        Try
            conMain.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 main DB: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        conGazetteer.ConnectionString = "Data Source=" & Path.Combine(txtDBFolder.Text, "g21gazetteer.db3") & ";"
        Try
            conGazetteer.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 gazetteer DB: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        conVoice.ConnectionString = "Data Source=" & Path.Combine(txtDBFolder.Text, "g21voice.db3") & ";"
        Try
            conVoice.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 gazetteer DB: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        conTracks.ConnectionString = "Data Source=" & Path.Combine(txtDBFolder.Text, "g21tracks.db3") & ";"
        Try
            conTracks.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 tracks DB: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        conMedia.ConnectionString = "Data Source=" & Path.Combine(txtDBFolder.Text, "g21media.db3") & ";"
        Try
            conMedia.Open()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to Gilbert 21 media DB: " & ex.Message)
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        'Create and copy tables
        CreateAndCopyRecordsTable(bCopyAccess)
        CreateAndCopyHashCodesTable(bCopyAccess)
        CreateAndCopyos50kgazTable(bCopyAccess)
        CreateAndCopyosDistrictVectorGazTable(bCopyAccess)
        CreateAndCopyTaxonDictionaryTable(bCopyAccess)
        CreateAndCopyWhereClauseTable(bCopyAccess)
        CreateAndPopulateVoiceTable(bCopyAccess)
        CreateTrackTables(bCopyAccess)
        CreateMultiMediaTables(bCopyAccess)

        lblProgress.Text = "Processing complete."

        Cursor = Cursors.Arrow

        MessageBox.Show("Database creation is complete.", "Gilbert 21")
        Me.Close()
    End Sub

    Private Sub CreateTrackTables(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing Track table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conTracks.CreateCommand()

        'Create the Tracks table
        SQLcommand.CommandText = "CREATE TABLE Tracks (" & _
            "   FileID          INTEGER  PRIMARY KEY AUTOINCREMENT," & _
            "   Filename        TEXT," & _
            "   OriginalPath    TEXT," & _
            "   CurrentPath     TEXT," & _
            "   DateCreated     DATETIME," & _
            "   FileType        TEXT," & _
            "   GenericFileType Text" & _
            ");"
        SQLcommand.ExecuteNonQuery()

        'Create the RecordTracks table
        SQLcommand.CommandText = "create table RecordTracks (RecordID INTEGER, FileID INTEGER);"
        SQLcommand.ExecuteNonQuery()
    End Sub

    Private Sub CreateMultiMediaTables(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing multi-media table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conMedia.CreateCommand()

        'Create the Tracks table
        SQLcommand.CommandText = "CREATE TABLE Media (" & _
            "   FileID          INTEGER  PRIMARY KEY AUTOINCREMENT," & _
            "   Filename        TEXT," & _
            "   Comment         TEXT," & _
            "   FullPath     TEXT," & _
            "   RelativePath    TEXT," & _
            "   Data            BLOB," & _
            "   Thumbnail       BLOB," & _
            "   DateCreated     DATETIME," & _
            "   FileType        TEXT," & _
            "   GenericFileType Text" & _
            ");"
        SQLcommand.ExecuteNonQuery()

        'Create the RecordMedia table
        SQLcommand.CommandText = "create table RecordMedia (RecordID INTEGER, FileID INTEGER, [Order] INTEGER);"
        SQLcommand.ExecuteNonQuery()
    End Sub

    Private Sub CreateAndCopyRecordsTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing Records table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conMain.CreateCommand()

        'Create the Records table
        Dim strSQL As String = "CREATE TABLE Records (" & _
            "    ID             INTEGER PRIMARY KEY AUTOINCREMENT," & _
            "    IsTempRow      BOOLEAN," & _
            "    Filename       TEXT," & _
            "    FileIndex      INTEGER," & _
            "    FileLon        NUMERIC," & _
            "    FileLat        NUMERIC," & _
            "    DateTimeKey    TEXT," & _
            "    Entered        DATE," & _
            "    Modified       DATE," & _
            "    NoExport       BOOLEAN," & _
            "    Recorder       TEXT," & _
            "    Determiner     TEXT," & _
            "    Confirmer      TEXT," & _
            "    CommonName     TEXT," & _
            "    ScientificName TEXT," & _
            "    TaxonGroup     TEXT," & _
            "    Abundance      TEXT," & _
            "    Units          TEXT," & _
            "    Location       TEXT," & _
            "    Town           TEXT," & _
            "    GridRef        TEXT," & _
            "    Lon            NUMERIC," & _
            "    Lat            NUMERIC," & _
            "    RecDate        DATE," & _
            "    RecTime        TEXT," & _
            "    TimeZone       TEXT," & _
            "    Comment        TEXT," & _
            "    PersonalNotes  TEXT " & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from Records", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramID As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramID)
            Dim paramIsTempRow As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramIsTempRow)
            Dim paramFilename As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramFilename)
            Dim paramFileIndex As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramFileIndex)
            Dim paramFileLon As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramFileLon)
            Dim paramFileLat As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramFileLat)
            Dim paramDateTimeKey As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramDateTimeKey)
            Dim paramEntered As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramEntered)
            Dim paramModified As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramModified)
            Dim paramNoExport As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramNoExport)
            Dim paramRecorder As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramRecorder)
            Dim paramDeterminer As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramDeterminer)
            Dim paramConfirmer As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramConfirmer)
            Dim paramCommonName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramCommonName)
            Dim paramScientificName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramScientificName)
            Dim paramTaxonGroup As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramTaxonGroup)
            Dim paramAbundance As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramAbundance)
            Dim paramUnits As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramUnits)
            Dim paramLocation As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramLocation)
            Dim paramTown As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramTown)
            Dim paramGridRef As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramGridRef)
            Dim paramRecDate As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramRecDate)
            Dim paramRecTime As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramRecTime)
            Dim paramComment As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramComment)
            Dim paramPersonalNotes As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramPersonalNotes)

            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conMain.BeginTransaction()

            paramIsTempRow.Value = False

            For Each dtRow In dtInput.Rows
                paramID.Value = ModVal(dtRow("ID"))
                paramFilename.Value = ModVal(dtRow("Filename"))
                paramFileIndex.Value = ModVal(dtRow("FileIndex"))
                paramFileLon.Value = ModVal(dtRow("Lon"))
                paramFileLat.Value = ModVal(dtRow("Lat"))
                paramDateTimeKey.Value = ModVal(dtRow("DateTimeKey"))
                paramEntered.Value = ModVal(dtRow("Entered"))
                paramModified.Value = ModVal(dtRow("Modified"))
                paramNoExport.Value = ModVal(False)
                paramRecorder.Value = ModVal(dtRow("Recorder"))
                paramDeterminer.Value = ModVal(dtRow("Determiner"))
                paramConfirmer.Value = ModVal(dtRow("Confirmer"))
                paramCommonName.Value = ModVal(dtRow("CommonName"))
                paramScientificName.Value = ModVal(dtRow("ScientificName"))
                paramTaxonGroup.Value = ModVal(dtRow("TaxonGroup"))
                paramAbundance.Value = ModVal(dtRow("Abundance"))
                paramUnits.Value = ModVal(dtRow("Units"))
                paramLocation.Value = ModVal(dtRow("Location"))
                paramTown.Value = ModVal(dtRow("Town"))
                paramGridRef.Value = ModVal(dtRow("GridRef"))
                paramRecDate.Value = ModVal(dtRow("RecDate"))
                paramRecTime.Value = ModVal(dtRow("RecTime"))
                paramComment.Value = ModVal(dtRow("Comment"))
                paramPersonalNotes.Value = ModVal(dtRow("PersonalNotes"))
                SQLcommand.CommandText = "INSERT INTO Records (ID,IsTempRow, Filename,FileIndex,FileLon,FileLat,DateTimeKey,Entered,Modified,NoExport, Recorder,Determiner,Confirmer,CommonName,ScientificName,TaxonGroup,Abundance,Units,Location,Town,GridRef,RecDate,RecTime,Comment,PersonalNotes) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()
        End If
        SQLcommand.Dispose()
    End Sub

    Private Function ModVal(ByVal objVal As Object) As Object

        Dim objRet As Object = Nothing
        If Not objVal Is Nothing Then
            If Not objVal.ToString() = "Null" Then
                objRet = objVal
            End If
        End If
        Return objRet
    End Function

    Private Sub CreateAndCopyHashCodesTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing CodeHash table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conMain.CreateCommand()

        'Create the Records table
        Dim strSQL As String = "CREATE TABLE HashCodes (" & _
            "    ID             INTEGER PRIMARY KEY," & _
            "    Hash           TEXT," & _
            "    CommonName     TEXT," & _
            "    ScientificName TEXT," & _
            "    TaxonGroup     TEXT," & _
            "    Abundance      TEXT," & _
            "    Units          TEXT," & _
            "    Location       TEXT," & _
            "    Town           TEXT," & _
            "    RecDate        DATE," & _
            "    GridRef        TEXT," & _
            "    Comment        TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from HashCodes", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramID As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramID)
            Dim paramHash As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramHash)
            Dim paramCommonName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramCommonName)
            Dim paramScientificName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramScientificName)
            Dim paramTaxonGroup As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramTaxonGroup)
            Dim paramAbundance As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramAbundance)
            Dim paramUnits As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramUnits)
            Dim paramLocation As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramLocation)
            Dim paramTown As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramTown)
            Dim paramRecDate As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramRecDate)
            Dim paramGridRef As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramGridRef)
            Dim paramComment As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramComment)

            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conMain.BeginTransaction()

            For Each dtRow In dtInput.Rows
                paramID.Value = dtRow("ID")
                paramHash.Value = dtRow("Hash")
                paramCommonName.Value = dtRow("CommonName")
                paramScientificName.Value = dtRow("ScientificName")
                paramTaxonGroup.Value = dtRow("TaxonGroup")
                paramAbundance.Value = dtRow("Abundance")
                paramUnits.Value = dtRow("Units")
                paramLocation.Value = dtRow("Location")
                paramTown.Value = dtRow("Town")
                paramRecDate.Value = dtRow("RecDate")
                paramGridRef.Value = dtRow("GridRef")
                paramComment.Value = dtRow("Comment")
                SQLcommand.CommandText = "INSERT INTO HashCodes (ID,Hash,CommonName,ScientificName,TaxonGroup,Abundance,Units,Location,Town,RecDate,GridRef,Comment) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)"
                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()

        End If
        SQLcommand.Dispose()

    End Sub

    Private Sub CreateAndCopyos50kgazTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing os50kgaz table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conGazetteer.CreateCommand()

        'Create the Records table
        Dim strSQL As String = "CREATE TABLE os50kgaz (" & _
            "    SEQ            INTEGER," & _
            "    DEF_NAM        TEXT," & _
            "    NORTH          INTEGER," & _
            "    EAST           INTEGER," & _
            "    COUNTY         TEXT," & _
            "    FULL_COUNTY    TEXT," & _
            "    F_CODE         TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from os50kgaz", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramSEQ As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramSEQ)
            Dim paramDEF_NAM As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramDEF_NAM)
            Dim paramNORTH As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramNORTH)
            Dim paramEAST As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramEAST)
            Dim paramCOUNTY As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramCOUNTY)
            Dim paramFULL_COUNTY As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramFULL_COUNTY)
            Dim paramF_CODE As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramF_CODE)


            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conGazetteer.BeginTransaction()

            For Each dtRow In dtInput.Rows
                paramSEQ.Value = dtRow("SEQ")
                paramDEF_NAM.Value = dtRow("DEF_NAM")
                paramNORTH.Value = dtRow("NORTH")
                paramEAST.Value = dtRow("EAST")
                paramCOUNTY.Value = dtRow("COUNTY")
                paramFULL_COUNTY.Value = dtRow("FULL_COUNTY")
                paramF_CODE.Value = dtRow("F_CODE")
                SQLcommand.CommandText = "INSERT INTO os50kgaz (SEQ,DEF_NAM,NORTH,EAST,COUNTY,FULL_COUNTY,F_CODE) VALUES(?,?,?,?,?,?,?)"
                SQLcommand.CommandText = "INSERT INTO os50kgaz (SEQ,DEF_NAM,NORTH,EAST,COUNTY,FULL_COUNTY,F_CODE) VALUES(?,?,?,?,?,?,?)"
                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()
        End If

        'Create the view os50kgazTownsCities
        strSQL = "Create View os50kgazTownsCities as " & _
            "SELECT os50kgaz.NORTH, os50kgaz.EAST, os50kgaz.DEF_NAM FROM os50kgaz " & _
            "WHERE (((os50kgaz.F_CODE)='C' Or (os50kgaz.F_CODE)='T'));"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()
    End Sub

    Private Sub CreateAndCopyosDistrictVectorGazTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing osDistrictVectorGaz table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conGazetteer.CreateCommand()

        'Create the osDistrictVectorGaz table
        Dim strSQL As String = "CREATE TABLE osDistrictVectorGaz (" & _
            "    ID            INTEGER PRIMARY KEY," & _
            "    X             INTEGER," & _
            "    Y             INTEGER," & _
            "    NAME          TEXT," & _
            "    Type          TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from osDistrictVectorGaz", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramID As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramID)
            Dim paramX As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramX)
            Dim paramY As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramY)
            Dim paramNAME As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramNAME)
            Dim paramType As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramType)

            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conGazetteer.BeginTransaction()

            For Each dtRow In dtInput.Rows
                paramID.Value = dtRow("ID")
                paramX.Value = dtRow("X")
                paramY.Value = dtRow("Y")
                paramNAME.Value = dtRow("NAME")
                paramType.Value = dtRow("Type")
                SQLcommand.CommandText = "INSERT INTO osDistrictVectorGaz (ID,X,Y,Name,Type) VALUES(?,?,?,?,?)"
                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()
        End If
        SQLcommand.Dispose()

    End Sub

    Private Sub CreateAndCopyTaxonDictionaryTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing TaxonDictionary table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conMain.CreateCommand()

        'Create the Records table
        Dim strSQL As String = "CREATE TABLE TaxonDictionary (" & _
            "    ID             INTEGER PRIMARY KEY," & _
            "    ScientificName TEXT," & _
            "    CommonName     TEXT," & _
            "    TaxonGroup     TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from TaxonDictionary", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramID As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramID)
            Dim paramCommonName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramCommonName)
            Dim paramScientificName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramScientificName)
            Dim paramTaxonGroup As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramTaxonGroup)

            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conMain.BeginTransaction()

            For Each dtRow In dtInput.Rows
                paramID.Value = dtRow("ID")
                paramCommonName.Value = dtRow("CommonName")
                paramScientificName.Value = dtRow("ScientificName")
                paramTaxonGroup.Value = dtRow("TaxonGroup")
                SQLcommand.CommandText = "INSERT INTO TaxonDictionary (ID,CommonName,ScientificName,TaxonGroup) VALUES(?,?,?,?)"
                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()
        End If
        SQLcommand.Dispose()

    End Sub

    Private Sub CreateAndCopyWhereClauseTable(ByVal bCopyAccess As Boolean)

        lblProgress.Text = "Processing WhereClause table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conMain.CreateCommand()

        'Create the Records table
        Dim strSQL As String = "CREATE TABLE WhereClause (" & _
            "    QuerySQL   TEXT, " & _
            "    QueryName  TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Copy the Access DB to SQLite
            Dim daAccessDB As OleDbDataAdapter = New OleDbDataAdapter("Select * from WhereClause", conAccessDB)
            Dim dtInput As DataTable = New DataTable
            Try
                daAccessDB.Fill(dtInput)
            Catch ex As Exception
                MessageBox.Show("Record selection query failed: " & ex.Message)
                Exit Sub
            End Try

            Dim dtRow As DataRow
            Dim i As Integer = 0

            Dim paramQuerySQL As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramQuerySQL)
            Dim paramQueryName As New SQLite.SQLiteParameter()
            SQLcommand.Parameters.Add(paramQueryName)

            pbConvert.Maximum = dtInput.Rows.Count
            pbConvert.Value = 0
            Dim SQLtransaction As SQLite.SQLiteTransaction
            SQLtransaction = conMain.BeginTransaction()

            For Each dtRow In dtInput.Rows
                paramQuerySQL.Value = dtRow("QuerySQL")
                paramQueryName.Value = dtRow("QueryName")
                SQLcommand.CommandText = "INSERT INTO WhereClause (QuerySQL,QueryName) VALUES(?,?)"
                SQLcommand.ExecuteNonQuery()
                pbConvert.Value += 1
            Next
            SQLtransaction.Commit()
        End If
        SQLcommand.Dispose()

    End Sub

    Private Function PrepareValForSQLite(ByVal objVal As Object) As Object

        If cfun.HasNoValue(objVal) Then
            Return objVal
        ElseIf objVal.GetType Is GetType(String) Then
            Return objVal.Replace("'", "''")
        Else
            Return objVal
        End If
    End Function

    Private Sub frmConvertDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitialiseFormFields()
    End Sub

    Public Sub InitialiseFormFields()

        txtDBFolder.Text = frmOptions.txtDBFolder.Text

        'Read V1 DB from registry settings
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")
        txtDB.Text = newkey.GetValue("Database")
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click

        V2DB(True)
    End Sub

    Private Sub butBrowseDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseDB.Click

        OpenFileDialog.Filter = "Access DB (*.mdb)|*.mdb|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then
            txtDB.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub CreateAndPopulateVoiceTable(ByVal bCopyAccess As Boolean)
        Cursor = Cursors.WaitCursor

        lblProgress.Text = "Creating and populating voice table..."
        Me.Refresh()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conVoice.CreateCommand()
        'Create the Records table
        SQLcommand.CommandText = "create table Sounds (SoundID INTEGER PRIMARY KEY AUTOINCREMENT," & _
            "OriginalFilename TEXT, OriginalTrackFilename TEXT," & _
            "[Date] DATE, [Time] TEXT, FileLon FLOAT, FileLat FLOAT, Sound BLOB);"

        SQLcommand.ExecuteNonQuery()

        'Create a new table to cross-reference WAV files and records
        SQLcommand.CommandText = "create table RecordSounds (RecordID INTEGER, SoundID INTEGER,[Order] INTEGER);"
        '"foreign key(SoundID) references Sounds(SoundID));"
        SQLcommand.ExecuteNonQuery()

        If bCopyAccess Then
            'Populate new tables
            'Go through each file in Gilbert21.voice and make an entry in the sounds table
            Dim strDBFolder As String = Path.GetDirectoryName(txtDB.Text)
            Dim strDBName As String = Path.GetFileName(txtDB.Text)
            Dim strVoiceFolderName As String = strDBName.Substring(0, strDBName.Length - 3) & "voice"
            Dim strVoiceFolder = Path.Combine(strDBFolder, strVoiceFolderName)

            If Directory.Exists(strVoiceFolder) Then
                Dim folder1 As String
                Dim folder2 As String
                Dim soundFile As String
                Dim soundFileName As String
                Dim intSoundID As Integer
                Dim intRecordID As Integer
                Dim intOrder As Integer
                Dim strSplit() As String

                Dim SQLcommandSounds As SQLiteCommand
                SQLcommandSounds = conVoice.CreateCommand()
                Dim SQLcommandRecordSounds As SQLiteCommand
                SQLcommandRecordSounds = conVoice.CreateCommand()

                Dim paramNull As New SQLite.SQLiteParameter()
                SQLcommandSounds.Parameters.Add(paramNull)
                paramNull = Nothing
                Dim paramOriginalFilename As New SQLite.SQLiteParameter()
                SQLcommandSounds.Parameters.Add(paramOriginalFilename)
                Dim paramSound As New SQLite.SQLiteParameter()
                SQLcommandSounds.Parameters.Add(paramSound)
                paramSound.DbType = DbType.Binary

                Dim paramRecordID As New SQLite.SQLiteParameter()
                SQLcommandRecordSounds.Parameters.Add(paramRecordID)
                Dim paramSoundID As New SQLite.SQLiteParameter()
                SQLcommandRecordSounds.Parameters.Add(paramSoundID)
                Dim paramOrder As New SQLite.SQLiteParameter()
                SQLcommandRecordSounds.Parameters.Add(paramOrder)

                Dim intFiles As Integer = 0
                For Each folder1 In Directory.GetDirectories(strVoiceFolder)
                    If Not folder1.EndsWith("TempVoice") Then
                        For Each folder2 In Directory.GetDirectories(folder1)
                            For Each soundFile In Directory.GetFiles(folder2)
                                intFiles += 1
                            Next
                        Next
                    End If
                Next

                pbConvert.Maximum = intFiles
                pbConvert.Value = 0

                Dim SQLtransaction As SQLite.SQLiteTransaction
                SQLtransaction = conVoice.BeginTransaction()

                For Each folder1 In Directory.GetDirectories(strVoiceFolder)
                    If Not folder1.EndsWith("TempVoice") Then
                        For Each folder2 In Directory.GetDirectories(folder1)
                            For Each soundFile In Directory.GetFiles(folder2)

                                soundFileName = soundFile.Substring(folder2.Length + 1)
                                paramOriginalFilename.Value = soundFileName
                                FileToBlobParam(soundFile, paramSound)
                                SQLcommandSounds.CommandText = "INSERT INTO Sounds (SoundID, OriginalFilename, Sound) VALUES(?,?,?)"
                                SQLcommandSounds.ExecuteNonQuery()
                                'SQLcommandSounds.CommandText = "select max(SoundID) from Sounds"
                                SQLcommandSounds.CommandText = "Select last_insert_rowid()"
                                intSoundID = SQLcommandSounds.ExecuteScalar()

                                'Get recordID and order from sound filename
                                strSplit = soundFileName.Substring(0, soundFileName.Length - 4).Split("-")
                                intRecordID = strSplit(0)
                                intOrder = strSplit(1)

                                paramRecordID.Value = intRecordID
                                paramSoundID.Value = intSoundID
                                paramOrder.Value = intOrder

                                SQLcommandRecordSounds.CommandText = "insert into RecordSounds (RecordID, SoundID, [Order]) Values(?,?,?)"
                                SQLcommandRecordSounds.ExecuteNonQuery()

                                pbConvert.Value += 1
                            Next
                        Next
                    End If
                Next

                SQLtransaction.Commit()
                SQLcommand.Dispose()
                SQLcommandSounds.Dispose()
                SQLcommandRecordSounds.Dispose()
            End If
        End If
        Cursor = Cursors.Arrow
    End Sub

    Public Sub FileToBlobParam(ByVal filePath As String, ByRef param As SQLiteParameter)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bm() As Byte = br.ReadBytes(fs.Length)
        br.Close()
        fs.Close()
        param.Value = bm
    End Sub

    Public Sub ExecuteSQLiteNonQuery(ByVal cmd As SQLiteCommand)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("SQLite command '" & cmd.CommandText & "' failed: " & ex.Message)
            Exit Sub
        End Try
    End Sub
End Class