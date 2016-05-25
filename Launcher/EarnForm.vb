Public Class EarnForm

    Public DestURL As String

    Private Sub OkPerplexButton_Click(sender As Object, e As EventArgs) Handles CancelEarnButton.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EarnWebBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles EarnWebBrowser.Navigated
        If EarnWebBrowser.Document.Url.AbsoluteUri.ToString = DestURL Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class