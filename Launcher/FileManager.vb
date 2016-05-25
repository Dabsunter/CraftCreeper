Imports System.IO
Imports Ionic.Zip
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports CraftCreeper_Launcher.Game.VersionType

Public Class FileManager

    Public Shared StepId As Integer = 0
    Public Shared ArrayId As Integer = 0
    Public Shared AssetsIndex As String
    Public Shared WorkingVersion As String
    Public Shared Sub Verify()
        Select Case Config.SelectedType
            Case Release, Snapshot
                VerifyOfficial()
            Case Optifine
                VerifyOptifine()
            Case Installed
                VerifyInstalled()
        End Select
    End Sub

    Public Shared Sub VerifyOfficial()
        Select Case StepId
            Case 0
                WorkingVersion = Config.SelectedVersion
                Directory.CreateDirectory(Config.GameDir & "\versions\" & Config.SelectedVersion)
                Dim NWC As New WebClient
                NWC.DownloadFile("http://s3.amazonaws.com/Minecraft.Download/versions/" & Config.SelectedVersion & "/" & Config.SelectedVersion & ".json",
                                        Config.GameDir & "\versions\" & Config.SelectedVersion & "\" & Config.SelectedVersion & ".json")
                If Not File.Exists(Config.GameDir & "\versions\" & Config.SelectedVersion & "\" & Config.SelectedVersion & ".jar") Then
                    Tools.UpdateInfoLabel("Downloading version...")
                    Tools.WriteLog("Downloading version to " & Config.GameDir & "\versions\" & Config.SelectedVersion & "\" & Config.SelectedVersion & ".jar")
                    Download("http://s3.amazonaws.com/Minecraft.Download/versions/" & Config.SelectedVersion & "/" & Config.SelectedVersion & ".jar",
                             Config.GameDir & "\versions\" & Config.SelectedVersion & "\" & Config.SelectedVersion & ".jar")
                    StepId += 1
                Else
                    StepId += 1
                    Verify()
                End If
            Case 1
                DownloadLibraries()
            Case 2
                DownloadAssets()
            Case 3
                Game.Launch()
        End Select
    End Sub

    Public Shared Sub VerifyOptifine()
        Select Case StepId
            Case 0
                WorkingVersion = Config.SelectedVersion.Split(" ")(1)
                Directory.CreateDirectory(Config.GameDir & "\versions\" & WorkingVersion)
                Dim NWC As New WebClient
                NWC.DownloadFile("http://s3.amazonaws.com/Minecraft.Download/versions/" & WorkingVersion & "/" & WorkingVersion & ".json",
                                        Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".json")
                If Not File.Exists(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".jar") Then
                    Tools.UpdateInfoLabel("Downloading version...")
                    Tools.WriteLog("Downloading version to " & Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".jar")
                    Download("http://s3.amazonaws.com/Minecraft.Download/versions/" & WorkingVersion & "/" & WorkingVersion & ".jar",
                             Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".jar")
                    StepId += 1
                Else
                    StepId += 1
                    Verify()
                End If
            Case 1
                Directory.CreateDirectory(Config.GameDir & "\versions\" & Config.SelectedVersion.Replace(" ", "_"))
                File.Copy(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".json",
                          Config.GameDir & "\versions\" & Config.SelectedVersion.Replace(" ", "_") & "\" & Config.SelectedVersion.Replace(" ", "_") & ".json", True)
                If Not File.Exists(Config.GameDir & "\versions\" & Config.SelectedVersion.Replace(" ", "_") & "\" & Config.SelectedVersion.Replace(" ", "_") & ".jar") Then
                    Dim OfInt As Integer = 0
                    While Config.SelectedVersion <> Config.OptifineVersions(OfInt)
                        OfInt += 1
                    End While
                    Dim NWC As New WebClient
                    Dim VersionString As String = NWC.DownloadString("http://optifine.net/downloads").Replace("&nbsp;", "")
                    Dim VersionsXml = XDocument.Parse(VersionString)
                    Dim FromUrl As String = VersionsXml.<html>.<body>.<table>.<tr>.ElementAt(2).<td>.<table>.<tr>.<td>.<table>.ElementAt(OfInt).<tr>.<td>.ElementAt(1).<a>.@href
                    Dim ToUrl As String = VersionsXml.<html>.<body>.<table>.<tr>.ElementAt(2).<td>.<table>.<tr>.<td>.<table>.ElementAt(OfInt).<tr>.<td>.ElementAt(2).<a>.@href
                    If Not Tools.Earn(FromUrl, ToUrl, "This page is used for remunerate OptiFine's author.") Then
                        Game.Reset()
                        Exit Sub
                    End If
                    VersionString = NWC.DownloadString(ToUrl)
                    Dim DownloadUrl As String = "http://optifine.net/downloadx?f=" & Split(VersionString, "<a href=""downloadx?f=")(1).Split("""")(0)
                    Download(DownloadUrl, Config.GameDir & "\extract\" & Config.SelectedVersion.Replace(" ", "_"))
                    Tools.WriteLog("Downloading " & Config.SelectedVersion)
                    StepId += 1
                Else
                    StepId += 2
                    Verify()
                End If

            Case 2
                Directory.CreateDirectory(Config.GameDir & "\extract\of")
                Dim Optifine As ZipFile = ZipFile.Read(Config.GameDir & "\extract\" & Config.SelectedVersion.Replace(" ", "_"))
                Optifine.ExtractAll(Config.GameDir & "\extract\of")
                Optifine = ZipFile.Read(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".jar")
                Optifine.UpdateDirectory(Config.GameDir & "\extract\of", "")
                Tools.WriteLog("Patching " & Config.SelectedVersion & " on " & WorkingVersion)
                Optifine.RemoveSelectedEntries(".", "META-INF")
                Optifine.Save(Config.GameDir & "\versions\" & Config.SelectedVersion.Replace(" ", "_") & "\" & Config.SelectedVersion.Replace(" ", "_") & ".jar")
                MsgBox("done")
                Directory.Delete(Config.GameDir & "\extract", True)
                StepId += 1
                Verify()
            Case 3
                WorkingVersion = Config.SelectedVersion.Replace(" ", "_")
                DownloadLibraries()
            Case 4
                DownloadAssets()
            Case 5
                Game.Launch()
        End Select
    End Sub

    Public Shared Sub VerifyInstalled()
        If File.Exists(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".json") Then
            Select Case StepId
                Case 0
                    If Not File.Exists(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".jar") Then
                        Tools.Msg("Invalid version", "Missing JAR file.")
                        Game.Reset()
                        Exit Sub
                    End If
                    StepId += 1
                    Verify()
                Case 1
                    DownloadLibraries()
                Case 2
                    DownloadAssets()
                Case 3
                    Game.Launch()
            End Select
            'ElseIf File.Exists(Config.GameDir & "\versions\" & Config.SelectedVersion & "\" & Config.SelectedVersion & ".xml") Then

        Else
            Tools.Msg("Invalid version", """" & Config.SelectedVersion & """ is not valid!" & vbNewLine & "Please, remove this folder.")
        End If
    End Sub

    Public Shared Sub GetJsonInfos()

    End Sub

    Public Shared Sub DownloadLibraries()
        Dim SR As New StreamReader(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".json")
        Dim JsonString As String = SR.ReadToEnd
        SR.Close()
        Dim Json As New JObject
        Json = JsonConvert.DeserializeObject(JsonString)
        If ArrayId = Json.Item("libraries").Count Then
            StepId += 1
            ArrayId = 0
            Verify()
            Exit Sub
        End If
        If Not CheckLibrary(Json.Item("libraries").ElementAt(ArrayId).ToString) Then
            ArrayId += 1
            Verify()
            Exit Sub
        End If
        Dim LibraryPackage As String = Json.Item("libraries").ElementAt(ArrayId).Item("name").ToString.Split(":")(0)
        Dim LibraryName As String = Json.Item("libraries").ElementAt(ArrayId).Item("name").ToString.Split(":")(1)
        Dim LibraryVersion As String = Json.Item("libraries").ElementAt(ArrayId).Item("name").ToString.Split(":")(2)
        Dim LibraryUrl As String
        Try
            LibraryUrl = Json.Item("libraries").ElementAt(ArrayId).Item("url").ToString
        Catch
            LibraryUrl = "https://libraries.minecraft.net/"
        End Try
        Tools.UpdateInfoLabel("Verifing libraries..." & vbNewLine & "(" & ArrayId & "/" & Json.Item("libraries").Count & ")")
        Try
            Dim LibraryNativeString As String = Json.Item("libraries").ElementAt(ArrayId).Item("natives").Item("windows").ToString.Replace("${arch}", Config.SystemArch)
            If File.Exists(Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar") Then
                Dim LibraryFile As ZipFile = ZipFile.Read(Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar")
                LibraryFile.ExtractAll(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & "-natives")
                Tools.UpdateInfoLabel("Downloading libraries..." & vbNewLine & "(" & ArrayId & "/" & Json.Item("libraries").Count & ")")
                Tools.WriteLog("Unpacking natives of " & Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar")
                Directory.Delete(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & "-natives\META-INF", True)
                ArrayId += 1
                Verify()
            Else
                Download(LibraryUrl & LibraryPackage.Replace(".", "/") & "/" & LibraryName & "/" & LibraryVersion & "/" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar",
                         Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar")
                Tools.UpdateInfoLabel("Downloading libraries..." & vbNewLine & "(" & ArrayId & "/" & Json.Item("libraries").Count & ")")
                Tools.WriteLog("Downloading libraries to " & Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & "-" & LibraryNativeString & ".jar")
            End If
        Catch ex As Exception
            If File.Exists(Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & ".jar") Then
                If IsNothing(Game.LibrariesList) Then
                    If Directory.Exists(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & "-natives") Then
                        Directory.Delete(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & "-natives", True)
                    End If
                    Game.LibrariesList = Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & ".jar;"
                Else
                    Game.LibrariesList += Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & ".jar;"
                End If
                ArrayId += 1
                Verify()
            Else
                Download(LibraryUrl & LibraryPackage.Replace(".", "/") & "/" & LibraryName & "/" & LibraryVersion & "/" & LibraryName & "-" & LibraryVersion & ".jar",
                         Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & ".jar")
                Tools.UpdateInfoLabel("Downloading libraries..." & vbNewLine & "(" & ArrayId & "/" & Json.Item("libraries").Count & ")")
                Tools.WriteLog("Downloading libraries to " & Config.GameDir & "\libraries\" & LibraryName & "-" & LibraryVersion & ".jar")
            End If
        End Try
    End Sub

    Public Shared Function CheckLibrary(ByVal LibraryInfos As String) As Boolean
        Dim Json As New JObject
        Json = JsonConvert.DeserializeObject(LibraryInfos)
        Try
            For RuleId As Integer = 0 To Json.Item("rules").Count - 1
                If Json.Item("rules").ElementAt(RuleId).Item("action").ToString = "allow" Then
                    Try
                        If Json.Item("rules").ElementAt(RuleId).Item("os").Item("name").ToString = "windows" Then
                            Return True
                            Exit Function
                        Else
                            Return False
                            Exit Function
                        End If
                    Catch
                    End Try
                Else
                    Try
                        If Json.Item("rules").ElementAt(RuleId).Item("os").Item("name").ToString = "windows" Then
                            Return False
                            Exit Function
                        Else
                            Return True
                            Exit Function
                        End If
                    Catch
                        Return True
                    End Try
                End If
            Next
        Catch
            Return True
        End Try
    End Function

    Public Shared Sub DownloadAssets()
        If IsNothing(AssetsIndex) Then
            Dim SR_ As New StreamReader(Config.GameDir & "\versions\" & WorkingVersion & "\" & WorkingVersion & ".json")
            Dim JsonString_ As String = SR_.ReadToEnd
            SR_.Close()
            Dim Json_ As New JObject
            Json_ = JsonConvert.DeserializeObject(JsonString_)
            Try
                AssetsIndex = Json_.Item("assets").ToString
            Catch
                AssetsIndex = "legacy"
            End Try
            If Config.Internet Then
                Directory.CreateDirectory(Config.GameDir & "\assets\indexes")
                Dim NWC As New WebClient
                NWC.DownloadFile("https://s3.amazonaws.com/Minecraft.Download/indexes/" & AssetsIndex & ".json",
                                 Config.GameDir & "\assets\indexes\" & AssetsIndex & ".json")
            ElseIf Not File.Exists(Config.GameDir & "\assats\indexes\" & AssetsIndex & ".json") Then
                Tools.Msg("Error", "Missing files and they can't be downloaded.")
                Game.Reset()
                Exit Sub
            End If
        End If
        Dim SR As New StreamReader(Config.GameDir & "\assets\indexes\" & AssetsIndex & ".json")
        Dim JsonString As String = SR.ReadToEnd
        SR.Close()
        Dim Json As New JObject
        Json = JsonConvert.DeserializeObject(JsonString)
        For AI As Integer = ArrayId To Json.Item("objects").Children.ToArray().Count - 1
            Dim Path As String = Json.Item("objects").Children.ToArray()(AI).ToString.Split("""")(1)
            Dim Hash As String = Json.Item("objects").Item(Path).Item("hash").ToString
            Dim Size As String = Json.Item("objects").Item(Path).Item("size").ToString
            Try
                If File.ReadAllBytes(Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash).Length <> Size Then
                    Download("http://resources.download.minecraft.net/" & Hash.Remove(2) & "/" & Hash,
                             Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash)
                    Tools.UpdateInfoLabel("Downloading assets..." & vbNewLine & "(" & AI & "/" & Json.Item("objects").Children.ToArray().Count & ")")
                    Tools.WriteLog("Downloading assets object to " & Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash)
                    ArrayId = AI
                    Exit Sub
                End If
            Catch
                Download("http://resources.download.minecraft.net/" & Hash.Remove(2) & "/" & Hash,
                                             Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash)
                Tools.UpdateInfoLabel("Downloading assets..." & vbNewLine & "(" & AI & "/" & Json.Item("objects").Children.ToArray().Count & ")")
                Tools.WriteLog("Downloading assets object to " & Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash)
                ArrayId = AI
                Exit Sub
            End Try
            If AssetsIndex = "legacy" Then
                Dim FullPath As String = Config.GameDir & "\assets\legacy\" & Path.Replace("/", "\")
                Directory.CreateDirectory(FullPath.Remove(FullPath.LastIndexOf("\")))
                File.Copy(Config.GameDir & "\assets\objects\" & Hash.Remove(2) & "\" & Hash,
                          FullPath, True)
                Tools.WriteLog("Create legacy asset of " & Hash & " to " & FullPath)
            End If
        Next
        StepId += 1
        ArrayId = 0
        Verify()
    End Sub

    Public Shared Sub Download(ByVal Adress As String, ByVal FileName As String)
        If Not Config.Internet Then
            Tools.Msg("Error", "Missing files and they can't be downloaded.")
            Game.Reset()
            Exit Sub
        End If
        ScreenManager.ShowLoadProgressBar()
        Dim Downloader As New WebClient
        AddHandler Downloader.DownloadProgressChanged, AddressOf Downloader_Progress
        AddHandler Downloader.DownloadFileCompleted, AddressOf Downloader_Completed
        Directory.CreateDirectory(FileName.Remove(FileName.LastIndexOf("\")))
        Downloader.DownloadFileAsync(New Uri(Adress), FileName)
    End Sub

    Public Shared Sub Downloader_Progress(sender As Object, e As System.Net.DownloadProgressChangedEventArgs)
        LauncherForm.LoadProgressBar.Value = e.ProgressPercentage
    End Sub

    Public Shared Sub Downloader_Completed()
        ScreenManager.HideLoadProgressBar()
        Verify()
    End Sub
End Class
