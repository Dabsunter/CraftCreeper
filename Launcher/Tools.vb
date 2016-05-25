Imports CraftCreeper_Launcher.Game.VersionType
Imports System.IO

Public Class Tools

    Public Shared Function Msg(ByVal Title As String, ByVal Message As String, Optional ByVal CloseAfterOk As Boolean = False)
        Dim MsgForm As New MsgBoxForm
        MsgForm.Text = Title
        MsgForm.PerplexTheme.Text = Title
        MsgForm.MsgLabel.Text = Message
        MsgForm.CloseAfterOk = CloseAfterOk
        MsgForm.Show()
        Return True
    End Function

    Public Shared Function WriteLog(ByVal Log As String, Optional ByVal HideTime As Boolean = False)
        If Not HideTime Then
            LauncherForm.LogsTextBox.AppendText(vbNewLine & "[" & Now & "] " & Log)
        Else
            Control.CheckForIllegalCrossThreadCalls = False
            LauncherForm.LogsTextBox.AppendText(vbNewLine & Log)
        End If
        Return True
    End Function

    Public Shared Sub UpdateInfoLabel(Optional ByVal CustomText As String = "")
        If CustomText <> "" Then
            LauncherForm.InfoLabel.Text = CustomText
        ElseIf Auth.LoggedIn And Directory.Exists(Config.GameDir & "\versions\" & Config.SelectedVersion) Then
            LauncherForm.InfoLabel.Text = "Ready to play " & MakeCn()
        ElseIf Auth.LoggedIn Then
            LauncherForm.InfoLabel.Text = "Ready to install " & MakeCn()
        Else
            LauncherForm.InfoLabel.Text = "Please, login."
        End If
    End Sub

    Public Shared Function MakeCn() As String
        Select Case Config.SelectedType
            Case Release, Snapshot
                Return "Minecraft " & Config.SelectedVersion
            Case Optifine
                Return "Optifine " & Config.SelectedVersion.Split(" ")(1)
            Case Else
                Return Config.SelectedVersion
        End Select
    End Function

    Public Shared Function Earn(ByVal FromURL As String, ByVal ToURL As String, Optional ByVal Text As String = "")
        Dim EarnPage As New EarnForm
        EarnPage.DestURL = ToURL
        If Text <> "" Then EarnPage.MsgLabel.Text = Text
        EarnPage.EarnWebBrowser.Navigate(FromURL)
        If EarnPage.ShowDialog = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
