Public Class DownloadForm

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        If Me.Text = "Updating" Then
            Me.Text = "Updating."
        ElseIf Me.Text = "Updating." Then
            Me.Text = "Updating.."
        ElseIf Me.Text = "Updating.." Then
            Me.Text = "Updating..."
        ElseIf Me.Text = "Updating..." Then
            Me.Text = "Updating"
        End If
    End Sub
End Class