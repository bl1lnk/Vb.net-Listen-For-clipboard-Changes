'Public Class Form1
'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
' TextBox1.Text = My.Computer.Clipboard.GetText
' Clipboard.SetText("hello", "wawa");
' Clipboard.SetText("hello world")
'Dim copiedText As String

'TextBox1.Text = My.Computer.Clipboard.GetText

Public Class Form1

    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    Private Declare Function SetClipboardViewer Lib "user32" Alias "SetClipboardViewer" (ByVal hwnd As Integer) As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim result As Integer = SetClipboardViewer(Me.Handle.ToInt32)
        While result <> Me.Handle.ToInt32
            result = SetClipboardViewer(Me.Handle.ToInt32)
        End While
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_DRAWCLIPBOARD Then
            'clipboard changed
            TextBox1.Text = My.Computer.Clipboard.GetText
        End If
        MyBase.WndProc(m)
    End Sub

End Class

'End Sub
'End Class
