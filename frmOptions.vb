Imports Microsoft.Win32
Imports System.IO

Public Class frmOptions

    Private mImportFileTypeIndex As Integer = 0
    Public Property importFileTypeIndex() As Integer
        Get
            Return mImportFileTypeIndex
        End Get
        Set(ByVal value As Integer)
            mImportFileTypeIndex = value
        End Set
    End Property

    Private Sub butColour(ByVal but As Button)

        If Not ColorDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then

            but.BackColor = ColorDialog.Color
        End If
    End Sub

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click

        WriteRegistrySettings()
        Me.Close()
    End Sub

    Public Sub WriteRegistrySettings()

        Dim i As Integer = 0
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")
        newkey.SetValue("DefaultRecorder", txtRecorder.Text)
        newkey.SetValue("DefaultDeterminer", txtDeterminer.Text)
        newkey.SetValue("Database", txtDB.Text) 'Version 1 database
        newkey.SetValue("DatabaseFolder", txtDBFolder.Text)
        newkey.SetValue("ImportFolder", txtImportFolder.Text)
        newkey.SetValue("ProcessedFolder", txtProcessedFiles.Text)
        newkey.SetValue("ExportFolder", txtExportFolder.Text)
        newkey.SetValue("EvernoteUser", txtEvernoteUser.Text)
        newkey.SetValue("EvernotePassword", txtEvernotePassword.Text)
        newkey.SetValue("EvernoteFolder", txtEvernoteFolder.Text)
        newkey.SetValue("FfplayExe", txtFfplayExe.Text)
        newkey.SetValue("NBNUser", txtNBNUser.Text)
        newkey.SetValue("NBNPassword", txtNBNPassword.Text)
        newkey.SetValue("BirdTrackUser", txtBirdTrackUser.Text)

        If chkGE.Checked Then
            newkey.SetValue("InvokeGE", "true")
        Else
            newkey.SetValue("InvokeGE", "false")
        End If

        If chkWatchImport.Checked Then
            newkey.SetValue("WatchImport", "true")
        Else
            newkey.SetValue("WatchImport", "false")
        End If

        If chkDelete.Checked Then
            newkey.SetValue("DeleteProcessedSoundFiles", "true")
        Else
            newkey.SetValue("DeleteProcessedSoundFiles", "false")
        End If


        newkey.SetValue("StyleValidRec", butStyleValidRec.BackColor.ToArgb.ToString)
        newkey.SetValue("StyleOtherRec", butStyleOtherRec.BackColor.ToArgb.ToString)
        newkey.SetValue("StyleModRec", butStyleModRec.BackColor.ToArgb.ToString)
        newkey.SetValue("StyleNoExportRec", butStyleNoExportRec.BackColor.ToArgb.ToString)

        newkey.SetValue("Style100km", butStyle100km.BackColor.ToArgb.ToString)
        newkey.SetValue("Style10km", butStyle10km.BackColor.ToArgb.ToString)
        newkey.SetValue("Style2km", butStyle2km.BackColor.ToArgb.ToString)
        newkey.SetValue("Style1km", butStyle1km.BackColor.ToArgb.ToString)
        newkey.SetValue("Style100m", butStyle100m.BackColor.ToArgb.ToString)
        newkey.SetValue("Style10m", butStyle10m.BackColor.ToArgb.ToString)
        newkey.SetValue("Style1m", butStyle1m.BackColor.ToArgb.ToString)
        newkey.SetValue("StyleInvalid", butStyleInvalid.BackColor.ToArgb.ToString)

        For i = 0 To clbFields.Items.Count - 1
            If clbFields.GetItemChecked(i) Then
                newkey.SetValue("FieldVis_" & clbFields.Items(i), "true")
            Else
                newkey.SetValue("FieldVis_" & clbFields.Items(i), "false")
            End If
        Next

        newkey.SetValue("ImportFileTypeIndex", Convert.ToString(mImportFileTypeIndex))
    End Sub

    Public Sub ReadRegistrySettings()
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")

        txtRecorder.Text = newkey.GetValue("DefaultRecorder")
        txtDeterminer.Text = newkey.GetValue("DefaultDeterminer")
        txtDB.Text = newkey.GetValue("Database")
        txtDBFolder.Text = newkey.GetValue("DatabaseFolder")
        If txtDBFolder.Text.Length = 0 And File.Exists(txtDB.Text) Then
            'This is for first time in before V1 database converted to V2
            txtDBFolder.Text = Path.GetDirectoryName(txtDB.Text)
        End If
        txtImportFolder.Text = newkey.GetValue("ImportFolder")
        txtProcessedFiles.Text = newkey.GetValue("ProcessedFolder")
        txtExportFolder.Text = newkey.GetValue("ExportFolder")
        txtEvernoteUser.Text = newkey.GetValue("EvernoteUser")
        txtEvernotePassword.Text = newkey.GetValue("EvernotePassword")
        txtEvernoteFolder.Text = newkey.GetValue("EvernoteFolder")
        txtFfplayExe.Text = newkey.GetValue("FfplayExe")
        txtNBNUser.Text = newkey.GetValue("NBNUser")
        txtNBNPassword.Text = newkey.GetValue("NBNPassword")
        txtBirdTrackUser.Text = newkey.GetValue("BirdTrackUser")

        chkGE.Checked = (newkey.GetValue("InvokeGE") = "true")
        chkWatchImport.Checked = (newkey.GetValue("WatchImport") = "true")
        chkDelete.Checked = (newkey.GetValue("DeleteProcessedSoundFiles") = "true")

        If newkey.GetValue("StyleValidRec") <> "" Then
            butStyleValidRec.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("StyleValidRec")))
            butStyleOtherRec.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("StyleOtherRec")))
            butStyleModRec.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("StyleModRec")))
            butStyleNoExportRec.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("StyleNoExportRec")))

            butStyle100km.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style100km")))
            butStyle10km.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style10km")))
            butStyle2km.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style2km")))
            butStyle1km.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style1km")))
            butStyle100m.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style100m")))
            butStyle10m.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style10m")))
            butStyle1m.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("Style1m")))
            butStyleInvalid.BackColor = Color.FromArgb(Convert.ToInt32(newkey.GetValue("StyleInvalid")))
        End If

        ReadRegistrySettingsFieldVis()

        'Import file type index
        If newkey.GetValue("ImportFileTypeIndex") <> "" Then
            mImportFileTypeIndex = Convert.ToInt16(newkey.GetValue("ImportFileTypeIndex"))
        Else
            mImportFileTypeIndex = 0
        End If
    End Sub

    Private Sub ReadRegistrySettingsFieldVis()
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
        Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")
        Dim i As Integer = 0

        Try
            If newkey.GetValue("FieldVis_" & clbFields.Items(0)) <> "" Then
                For i = 0 To clbFields.Items.Count - 1
                    clbFields.SetItemChecked(i, (newkey.GetValue("FieldVis_" & clbFields.Items(i)) = "true"))
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub clbFields_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbFields.ItemCheck

        frmMain.dgvRecords.Columns(clbFields.Items(e.Index).ToString()).Visible = e.NewValue
    End Sub

    Private Sub butBrowseInputFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseInputFolder.Click

        FolderBrowserDialog.SelectedPath = txtImportFolder.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            txtImportFolder.Text = FolderBrowserDialog.SelectedPath
        End If

        WriteRegistrySettings()
    End Sub

    Private Sub butBrowseExportFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseExportFolder.Click

        FolderBrowserDialog.SelectedPath = txtExportFolder.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            txtExportFolder.Text = FolderBrowserDialog.SelectedPath
        End If

        WriteRegistrySettings()
    End Sub

    Private Sub butBrowseDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseDB.Click

        OpenFileDialog.Filter = "Access DB (*.mdb)|*.mdb|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            Cursor = Cursors.WaitCursor

            frmMain.dgvRecords.Rows.Clear()

            txtDB.Text = OpenFileDialog.FileName
            frmMain.CheckDB()

            WriteRegistrySettings()

            Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub butStyle100km_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle100km.Click

        butColour(sender)
    End Sub

    Private Sub butStyle10km_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle10km.Click

        butColour(sender)
    End Sub

    Private Sub butStyle2km_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle2km.Click

        butColour(sender)
    End Sub

    Private Sub butStyle1km_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle1km.Click

        butColour(sender)
    End Sub

    Private Sub butStyle100m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle100m.Click

        butColour(sender)
    End Sub

    Private Sub butStyle10m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle10m.Click

        butColour(sender)
    End Sub

    Private Sub butStyle1m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyle1m.Click

        butColour(sender)
    End Sub

    Public Sub initCheckBoxes()

        ' Add any initialization after the InitializeComponent() call.
        If clbFields.Items.Count = 0 Then
            Dim rms As clsRecordMappings = New clsRecordMappings
            Dim rm As clsRecordMapping

            For Each rm In rms
                clbFields.Items.Add(rm.G21FieldName, rm.InitiallyVisible)
                If rm.CanBeClearedOnCopy Then
                    clbClearFieldsOnCopy.Items.Add(rm.G21FieldName, rm.InitiallyClearedOnCopy)
                End If
            Next

            ReadRegistrySettingsFieldVis()
        End If
    End Sub

    Private Sub txtRecorder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecorder.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True

            txtDeterminer.Focus()
            txtDeterminer.SelectAll()
        End If
    End Sub

    Private Sub txtDeterminer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeterminer.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True

            txtTaxonDictionaryFilter.Focus()
            txtTaxonDictionaryFilter.SelectAll()
        End If
    End Sub

    Private Sub txtTaxonDictionaryFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxonDictionaryFilter.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Suppresses the windows ding sound when enter is presses in a single-line textbox
            e.Handled = True
            butClose.Focus()
        End If
    End Sub

    Private Sub frmOptions_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        txtTaxonDictionaryFilter.Focus()
        txtTaxonDictionaryFilter.SelectAll()
    End Sub

    Private Sub butBrowseDatabaseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseDatabaseFolder.Click

        FolderBrowserDialog.SelectedPath = txtDBFolder.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            frmMain.CheckForUnsavedRecords()
            frmMain.dgvRecords.Rows.Clear()

            txtDBFolder.Text = FolderBrowserDialog.SelectedPath
        End If

        WriteRegistrySettings()
    End Sub

    Private Sub butEvernoteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEvernoteFolder.Click

        FolderBrowserDialog.SelectedPath = txtEvernoteFolder.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            txtEvernoteFolder.Text = FolderBrowserDialog.SelectedPath
        End If

        WriteRegistrySettings()
    End Sub

    Private Sub butFfplayExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFfplayExe.Click

        OpenFileDialog.Filter = "Executable (*.exe)|*.exe|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1

        If Not OpenFileDialog.ShowDialog() = DialogResult.Cancel Then

            Cursor = Cursors.WaitCursor

            txtFfplayExe.Text = OpenFileDialog.FileName

            WriteRegistrySettings()

            Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub butStyleInvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyleInvalid.Click

        butColour(sender)
    End Sub

    Private Sub butStyleValidRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyleValidRec.Click

        butColour(sender)
    End Sub

    Private Sub butStyleOtherRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyleOtherRec.Click

        butColour(sender)
    End Sub

    Private Sub butStyleModRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyleModRec.Click

        butColour(sender)
    End Sub

    Private Sub butStyleNoExportRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStyleNoExportRec.Click

        butColour(sender)
    End Sub

    Private Sub butBrowseProcessedFolder_Click(sender As System.Object, e As System.EventArgs) Handles butBrowseProcessedFolder.Click

        FolderBrowserDialog.SelectedPath = txtProcessedFiles.Text

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            chkDelete.Checked = False
            txtProcessedFiles.Text = FolderBrowserDialog.SelectedPath
        End If

        WriteRegistrySettings()
    End Sub

    Private Sub chkDelete_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDelete.CheckedChanged

        If chkDelete.Checked Then
            txtProcessedFiles.Text = ""
        End If
    End Sub

End Class