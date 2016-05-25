Imports System.Xml
Imports System.Xml.Linq
Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Guid

Public Class LauncherForm

    Private Sub LauncherForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Config.Load()
    End Sub

    Private Sub OnlinemodePerplexCheckBox_CheckedChanged(sender As Object) Handles OnlinemodeCheckBox.CheckedChanged
        ScreenManager.OnlineModeSwitch()
        Config.OnlineMode = OnlinemodeCheckBox.Checked
    End Sub

    Private Sub SettingsPictureBox_Click(sender As Object, e As EventArgs) Handles SettingsPictureBox.Click
        'SettingsForm.Close()
        SettingsForm.Show()
    End Sub


    Private Sub LoginPerplexButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Auth.Login(UsernameTextBox.Text, OnlinemodeCheckBox.Checked, PasswordTextBox.Text)
    End Sub

    Private Sub LogoutPerplexButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Auth.Logout()
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If Not Auth.LoggedIn Then
            Tools.Msg("Error", "Please, login.")
            Exit Sub
        End If
        PlayButton.Enabled = False
        ScreenManager.ShowConsole()
        FileManager.Verify()
    End Sub

    Private Sub test_Click(sender As Object, e As EventArgs) Handles TestButton.Click
        Dim txt As New WebClient
        Dim XML = XDocument.Parse(txt.DownloadString("http://optifine.net/downloads").Replace("&nbsp;", "")) '                                        ici                                et là
        TestTextBox.Text = XML.<html>.<body>.<table>.ElementAt(0).<tr>.ElementAt(2).<td>.ElementAt(0).<table>.ElementAt(0).<tr>.<td>.<table>.ElementAt(0).<tr>.ElementAt(0).<td>.ElementAt(2).<a>.@href
    End Sub

    Private Sub LauncherForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Config.Save()
        End
    End Sub
End Class
