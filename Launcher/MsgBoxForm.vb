Public Class MsgBoxForm

    Public CloseAfterOk As Boolean

    Private Sub OkPerplexButton_Click(sender As Object, e As EventArgs) Handles OkPerplexButton.Click
        If CloseAfterOk Then
            End
        Else
            Me.Close()
        End If
    End Sub
End Class