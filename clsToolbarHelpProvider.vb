Public Class ToolbarHelpProvider

    Inherits HelpProvider

    Public Overrides Function GetHelpString(ByVal ctl As Control) As String
        Dim ts As ToolStrip = TryCast(ctl, ToolStrip)
        If ts IsNot Nothing Then
            For Each item As ToolStripItem In ts.Items
                If item.Selected Then
                    Dim helpString As String = TryCast(item.Tag, String)
                    If helpString IsNot Nothing Then
                        Return helpString
                    End If
                End If
            Next
        End If
        If ctl Is Nothing Then
            Return "no control"
        Else
            Return "returning: " & ctl.ToString()
        End If

        'MyBase.GetHelpString(ctl)
    End Function
End Class
