Imports Microsoft.Win32
Imports System.Threading

Public Class clsSound

    'The purpose of this class is to enable a separate thread to be
    'run which plays consecutive wav files (therefore playmode is
    'WaitToComplete) without pausing the program.

    Dim wavFiles() As String

    'Dim intFfplayCheck As Integer = 0
    'Private Const SW_HIDE As Integer = 0
    'Private Const SW_RESTORE As Integer = 9
    'Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    'Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Public Sub SetWavFiles(ByVal wavs() As String)
        wavFiles = wavs
    End Sub

    Public Sub PlayWavs()
        'Found a problem here (1/4/2012) that WAV files generated from Evernote
        'caused Audio.Play to break because they are a different type of WAV file.
        'Found a class on the web which uses a Windows library to play file and
        'this can handle the Evernote ones. So switched to use this.

        Dim strWav As String
        Dim iCount As Integer = 0
        'Dim playMode As AudioPlayMode

        For Each strWav In wavFiles
            iCount += 1
            If Not strWav Is Nothing Then

                If strWav.ToLower.EndsWith("amr") Then

                    'AMRs wont play with any of the methods used to play WAVs.
                    'Currently only option seems to be to invoke external application to play them.
                    'Real Player will play AMR files. 

                    Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
                    Dim newkey As RegistryKey = key.CreateSubKey("Gilbert21")
                    Dim strFfplay As String = newkey.GetValue("FfplayExe")

                    If strFfplay.Trim.Length > 0 Then
                        Dim ProcessProperties As New ProcessStartInfo
                        Dim strProcName As String = "ffplay"
                        ProcessProperties.FileName = strFfplay
                        'The -nodisp option below doesn't seem to work and prevents any sound!
                        ProcessProperties.Arguments = " -i """ & strWav & """ -x 150 -y 20 -window_title " & strProcName & " -autoexit"
                        ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden
                        Process.Start(ProcessProperties)
                    Else
                        Process.Start(strWav)
                    End If
                ElseIf strWav.ToLower.EndsWith("wav") Then
                    'If this is the last file in the collection of files to be played, then
                    'play it in background mode so that it can be interrupted. If not last
                    'one, we have no choice but to play it as 'WaitToComplete' so that the
                    'files can be played consecutively.
                    'Changed to playing using call to windows library function from the audio.play
                    'function when the latter fell over with some WAV sounds (those generated
                    'with the Evernotes desktop application).
                    If iCount = wavFiles.Count Then
                        'playMode = AudioPlayMode.Background
                        clsSound2.PlayWaveFileAsync(strWav)
                    Else
                        'playMode = AudioPlayMode.WaitToComplete
                        clsSound2.PlayWaveFileSync(strWav)
                    End If
                    'My.Computer.Audio.Play(strWav, playMode)
                Else
                    Process.Start(strWav)
                End If
            End If
        Next
    End Sub
End Class
