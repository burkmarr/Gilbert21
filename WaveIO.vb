'*********************************
' Wave concatenation class
'
' CopyRights Ehab Essa 2006
'**********************************

Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices

Class WaveIO
    Public length As Integer
    Public channels As Short
    Public samplerate As Integer
    Public DataLength As Integer
    Public BitsPerSample As Short

    Private Sub WaveHeaderIN(ByVal spath As String)
        Dim fs As New FileStream(spath, FileMode.Open, FileAccess.Read)

        Dim br As New BinaryReader(fs)
        length = CInt(fs.Length) - 8
        fs.Position = 22
        channels = br.ReadInt16()
        fs.Position = 24
        samplerate = br.ReadInt32()
        fs.Position = 34

        BitsPerSample = br.ReadInt16()
        DataLength = CInt(fs.Length) - 44
        br.Close()
        fs.Close()

    End Sub

    Private Sub WaveHeaderOUT(ByVal sPath As String)
        Dim fs As New FileStream(sPath, FileMode.Create, FileAccess.Write)

        Dim bw As New BinaryWriter(fs)
        fs.Position = 0
        bw.Write(New Char(3) {"R"c, "I"c, "F"c, "F"c})

        bw.Write(length)

        bw.Write(New Char(7) {"W"c, "A"c, "V"c, "E"c, "f"c, "m"c, _
         "t"c, " "c})

        bw.Write(CInt(16))

        bw.Write(CShort(1))
        bw.Write(channels)

        bw.Write(samplerate)

        bw.Write(CInt(samplerate * ((BitsPerSample * channels) \ 8)))

        bw.Write(CShort((BitsPerSample * channels) \ 8))

        bw.Write(BitsPerSample)

        bw.Write(New Char(3) {"d"c, "a"c, "t"c, "a"c})
        bw.Write(DataLength)
        bw.Close()
        fs.Close()
    End Sub
    Public Sub Merge(ByVal files As String(), ByVal outfile As String)
        Dim wa_IN As New WaveIO()
        Dim wa_out As New WaveIO()

        wa_out.DataLength = 0
        wa_out.length = 0


        'Gather header data
        For Each path As String In files
            wa_IN.WaveHeaderIN(path)
            wa_out.DataLength += wa_IN.DataLength

            wa_out.length += wa_IN.length
        Next

        'Recontruct new header
        wa_out.BitsPerSample = wa_IN.BitsPerSample
        wa_out.channels = wa_IN.channels
        wa_out.samplerate = wa_IN.samplerate
        wa_out.WaveHeaderOUT(outfile)

        For Each path As String In files
            Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim arrfile As Byte() = New Byte(fs.Length - 45) {}
            fs.Position = 44
            fs.Read(arrfile, 0, arrfile.Length)
            fs.Close()

            Dim fo As New FileStream(outfile, FileMode.Append, FileAccess.Write)
            Dim bw As New BinaryWriter(fo)
            bw.Write(arrfile)
            bw.Close()
            fo.Close()
        Next

    End Sub
End Class

