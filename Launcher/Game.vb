Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Diagnostics
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text

Public Class Game

    Public Shared WithEvents Javaw As Process
    Public Shared MainClass As String
    Public Shared GameArguments As String
    Public Shared LibrariesList As String

    Enum VersionType
        Release = 0
        Snapshot = 1
        Optifine = 2
        Installed = 3
    End Enum

   

    Public Shared Sub Launch()
        Dim SR As New StreamReader(Config.GameDir & "\versions\" & FileManager.WorkingVersion & "\" & FileManager.WorkingVersion & ".json")
        Dim JsonString As String = SR.ReadToEnd
        SR.Close()
        Dim Json As New JObject
        Json = JsonConvert.DeserializeObject(JsonString)
        Dim AssetsDir As String = Config.GameDir & "\assets"
        Dim ProcessProperties As New ProcessStartInfo
        
        Dim Arguments As String = Config.JvmArguments & " -Djava.library.path=" & Config.GameDir & "\versions\" & FileManager.WorkingVersion & "\" & FileManager.WorkingVersion & "-natives -cp " & LibrariesList &
            Config.GameDir & "\versions\" & FileManager.WorkingVersion & "\" & FileManager.WorkingVersion & ".jar " & MainClass & " " &
            GameArguments.Replace("${auth_player_name}", Auth.Player).Replace("${auth_uuid}", Auth.Uuid).Replace("${auth_access_token}", Auth.AccessToken).Replace("${version_name}", FileManager.WorkingVersion).Replace("${game_directory}", Config.GameDir).Replace("${assets_root}", AssetsDir).Replace("${game_assets}", AssetsDir & "\legacy").Replace("${assets_index_name}", FileManager.AssetsIndex).Replace("${user_properties}", "{}").Replace("${user_type}", "mojang")
        ProcessProperties.FileName = Config.JavawPath
        ProcessProperties.WorkingDirectory = Config.GameDir
        ProcessProperties.Arguments = Arguments
        ProcessProperties.UseShellExecute = False
        ProcessProperties.RedirectStandardError = False
        ProcessProperties.RedirectStandardInput = False
        ProcessProperties.RedirectStandardOutput = False
        Tools.WriteLog("Half command: " & Config.JavawPath & " " & Arguments)
        Javaw = Process.Start(ProcessProperties)
        If Config.CWGS Then
            LauncherForm.Close()
            Exit Sub
        End If
        LauncherForm.Hide()
        Javaw.WaitForExit()
        LauncherForm.Show()
        Dim SR_ As New StreamReader(Config.GameDir & "\logs\latest.log")
        Tools.WriteLog(SR_.ReadToEnd, True)
        SR_.Close()

        Reset()
    End Sub

    Public Shared Sub Reset()
        FileManager.StepId = 0
        FileManager.ArrayId = 0
        LauncherForm.PlayButton.Enabled = True
        FileManager.AssetsIndex = Nothing
        FileManager.WorkingVersion = Nothing
        ScreenManager.HideConsole()
        Tools.UpdateInfoLabel()
    End Sub
End Class
