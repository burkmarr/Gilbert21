Imports System.Data.SQLite
Imports System.IO

Public Class clsDB

    Implements IDisposable

    Public Sub Dispose() Implements System.IDisposable.Dispose

        ' Perform any object clean up here.

        conSQLiteMain.Close()
        conSQLiteGazetteer.Close()
        conSQLiteVoice.Close()
        conSQLiteTracks.Close()
        conSQLiteMedia.Close()
    End Sub

    Private strErrorMessage As String
    Public Property ErrorMessage() As String
        Get
            Return strErrorMessage
        End Get
        Set(ByVal value As String)
            strErrorMessage = value
        End Set
    End Property

    Private conSQLiteMain As New SQLiteConnection
    Public ReadOnly Property conMain() As SQLiteConnection
        Get
            Return conSQLiteMain
        End Get
    End Property

    Private conSQLiteGazetteer As New SQLiteConnection
    Public ReadOnly Property conGazetteer() As SQLiteConnection
        Get
            Return conSQLiteGazetteer
        End Get
    End Property

    Private conSQLiteVoice As New SQLiteConnection
    Public ReadOnly Property conVoice() As SQLiteConnection
        Get
            Return conSQLiteVoice
        End Get
    End Property

    Private conSQLiteTracks As New SQLiteConnection
    Public ReadOnly Property conTracks() As SQLiteConnection
        Get
            Return conSQLiteTracks
        End Get
    End Property

    Private conSQLiteMedia As New SQLiteConnection
    Public ReadOnly Property conMedia() As SQLiteConnection
        Get
            Return conSQLiteMedia
        End Get
    End Property

    Private conSQLiteExports As New SQLiteConnection
    Public ReadOnly Property conExports() As SQLiteConnection
        Get
            Return conSQLiteExports
        End Get
    End Property

    Public Sub New()

        'SQLite DB connections (will create DBs if not already exist)
        strErrorMessage = ""

        'Check that the database folder and files exist
        If frmOptions.txtDBFolder.Text = "" Then
            strErrorMessage = "The database folder has not yet been set. Go to options to set the path for the database folder. Learn about this and other important set-up tasks in the quick-start guide from Help."
            Exit Sub
        End If

        If Not File.Exists(Path.Combine(frmOptions.txtDBFolder.Text, "g21main.db3")) Then
            strErrorMessage = "There's no database in the database folder. Learn about this and other important set-up tasks in the quick-start guide from Help."
            Exit Sub
        End If

        conSQLiteMain.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21main.db3") & ";"
        Try
            conSQLiteMain.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 main DB: " & ex.Message
            Exit Sub
        End Try

        conSQLiteGazetteer.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21gazetteer.db3") & ";"
        Try
            conSQLiteGazetteer.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 gazetteer DB: " & ex.Message
            Exit Sub
        End Try

        conSQLiteVoice.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21voice.db3") & ";"
        Try
            conSQLiteVoice.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 voice DB: " & ex.Message
            Exit Sub
        End Try

        conSQLiteTracks.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21tracks.db3") & ";"
        Try
            conSQLiteTracks.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 tracks DB: " & ex.Message
            Exit Sub
        End Try

        conSQLiteMedia.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21media.db3") & ";"
        Try
            conSQLiteMedia.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 media DB: " & ex.Message
            Exit Sub
        End Try

        conSQLiteExports.ConnectionString = "Data Source=" & Path.Combine(frmOptions.txtDBFolder.Text, "g21export.db3") & ";"
        Try
            conSQLiteExports.Open()
        Catch ex As Exception
            strErrorMessage = "Failed to connect to Gilbert 21 export DB: " & ex.Message
            Exit Sub
        End Try

        'Additional checks and updates
        CheckGUIDField()
        CreateExportDB()
    End Sub

    Private Sub CheckGUIDField()

        'Check that the main table has the GUID field (29th Dec 2012) and, if not, then add it in
        'and populate it
        Dim com As SQLiteCommand = New SQLiteCommand(conSQLiteMain)
        com.CommandText = "select GUID from Records limit 1;"
        Dim bGUIDPresent As Boolean = False
        Try
            Dim str As String = com.ExecuteNonQuery()
            bGUIDPresent = True
        Catch
        End Try
        If Not bGUIDPresent Then
            'GUID field not found, therefore add it in
            com.CommandText = "alter table records add column GUID char(36);"
            com.ExecuteNonQuery()
        End If

        Dim SQLtransaction As SQLiteTransaction
        SQLtransaction = conSQLiteMain.BeginTransaction()

        'Now populate with GUIDs
        Dim daRecords As SQLiteDataAdapter = New SQLiteDataAdapter("select * from records where GUID is null", conSQLiteMain)
        Dim cbRecords As SQLiteCommandBuilder = New SQLiteCommandBuilder(daRecords)
        Dim dsRecords As DataSet = New DataSet
        daRecords.Fill(dsRecords, "records")
        Dim row As DataRow
        For Each row In dsRecords.Tables("records").Rows
            row("GUID") = System.Guid.NewGuid.ToString()
        Next
        daRecords.Update(dsRecords, "records")
        SQLtransaction.Commit()

    End Sub

    Private Sub CreateExportDB()

        'Create the SQLiteCommand object
        Dim SQLcommand As SQLiteCommand
        SQLcommand = conSQLiteExports.CreateCommand()
        Dim strSQL As String

        'Create the Records table
        strSQL = "CREATE TABLE if not exists Exports (" & _
            "    ExportID       INTEGER PRIMARY KEY AUTOINCREMENT," & _
            "    ShortTitle     TEXT," & _
            "    Type           TEXT," & _
            "    ExportDate     DATE," & _
            "    Notes          TEXT," & _
            "    File           TEXT" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        'Create the RecordExports table
        strSQL = "CREATE TABLE if not exists RecordExport (" & _
            "    RecordID       INTEGER," & _
            "    ExportID       INTEGER," & _
            "    RecDateMod     DATE" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        'Create the RecordExports table
        strSQL = "CREATE TABLE if not exists Recipients (" & _
            "    RecipientID    INTEGER PRIMARY KEY AUTOINCREMENT," & _
            "    Name           String," & _
            "    Notes          String" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        'Create the RecordExports table
        strSQL = "CREATE TABLE if not exists ExportRecipient (" & _
            "    ExportID       INTEGER," & _
            "    RecipientID    INTEGER" & _
            ");"
        SQLcommand.CommandText = strSQL
        SQLcommand.ExecuteNonQuery()

        SQLcommand.Dispose()
    End Sub
End Class
