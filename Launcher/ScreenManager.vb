Public Class ScreenManager

    Public Shared DeveloppementMode As Boolean = False
#Region " Auth "
    Public Shared Sub Login()
        LauncherForm.UsernameTextBox.Hide()
        LauncherForm.PasswordTextBox.Hide()
        LauncherForm.OnlinemodeCheckBox.Hide()
        LauncherForm.LoginButton.Hide()
        LauncherForm.AvatarPictureBox.Show()
        LauncherForm.AvatarPictureBox.LoadAsync("https://minotar.net/helm/" & Auth.Player & "/54.png")
        LauncherForm.UsernameLabel.Show()
        LauncherForm.UsernameLabel.Text = Auth.Player
        LauncherForm.LogoutButton.Show()
        Tools.UpdateInfoLabel()
    End Sub

    Public Shared Sub Logout()
        LauncherForm.AvatarPictureBox.Hide()
        LauncherForm.UsernameLabel.Hide()
        LauncherForm.LogoutButton.Hide()
        LauncherForm.UsernameTextBox.Show()
        LauncherForm.PasswordTextBox.Show()
        LauncherForm.OnlinemodeCheckBox.Show()
        LauncherForm.LoginButton.Show()
        If LauncherForm.OnlinemodeCheckBox.Checked Then
            LauncherForm.UsernameTextBox.Text = "E-Mail"
            LauncherForm.PasswordTextBox.Text = "*****"
            LauncherForm.PasswordTextBox.Enabled = True
        Else
            LauncherForm.UsernameTextBox.Text = "Username"
            LauncherForm.PasswordTextBox.Text = "*****"
            LauncherForm.PasswordTextBox.Enabled = False
        End If
        Tools.UpdateInfoLabel()
    End Sub

    Public Shared Sub OnlineModeSwitch()
        If LauncherForm.OnlinemodeCheckBox.Checked Then
            LauncherForm.UsernameTextBox.Text = "E-Mail"
            LauncherForm.PasswordTextBox.Enabled = True
        Else
            LauncherForm.UsernameTextBox.Text = "Username"
            LauncherForm.PasswordTextBox.Text = "*****"
            LauncherForm.PasswordTextBox.Enabled = False
        End If
    End Sub
#End Region
    Public Shared Sub ShowConsole()
        LauncherForm.NewsWebBrowser.Hide()
        LauncherForm.LogsTextBox.Show()
        DeveloppementMode = True
    End Sub

    Public Shared Sub HideConsole()
        LauncherForm.LogsTextBox.Hide()
        LauncherForm.NewsWebBrowser.Show()
        DeveloppementMode = False
    End Sub

    Public Shared Sub ShowLoadProgressBar()
        LauncherForm.NewsWebBrowser.Height = 342
        LauncherForm.LogsTextBox.Height = 342
    End Sub

    Public Shared Sub HideLoadProgressBar()
        LauncherForm.NewsWebBrowser.Height = 362
        LauncherForm.LogsTextBox.Height = 362
    End Sub
End Class
