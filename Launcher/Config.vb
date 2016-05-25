Imports System.Xml
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net

Public Class Config

    Public Shared GameDir As String = Application.StartupPath
    Public Shared SystemArch As String
    Public Shared JavawPath As String
    Public Shared JvmArguments As String = "-Xmx1G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M"
    Public Shared UseCustomJavawPath As Boolean = False
    Public Shared UseCustomJvmAguments As Boolean = False
    Public Shared ConfigFile As XDocument
    Public Shared OldPlayer As String
    Public Shared OldAccessToken As String
    Public Shared OldClientToken As String
    Public Shared OldUuid As String
    Public Shared OnlineMode As Boolean = True
    Public Shared SelectedType As Integer = 0
    Public Shared SelectedVersion As String
    Public Shared SelectedVersionWithCN As String
    Public Shared LatestRelease As String = ""
    Public Shared LatestSnapshot As String
    Public Shared LatestOptifine As String
    Public Shared LatestInstalled As String
    Public Shared Internet As Boolean
    Public Shared MinecraftVersions() As String
    Public Shared MinecraftSnapshotVersions() As String
    Public Shared OptifineVersions() As String
    Public Shared InstalledVersions() As String
    Public Shared AutoLogin As Boolean = True
    Public Shared CWGS As Boolean = True

    Public Shared Sub Load()
        Dim FirstRun As Boolean = True
        Try
            Dim InternetTest = XDocument.Load("http://files.mc-craftcreeper.url.ph/webtest")
            If InternetTest.<IsWebTestSuccess>.@result Then Internet = True Else Internet = False
        Catch
            Internet = False
        End Try

        If File.Exists(GameDir & "\config\Launcher.cfg") Then
            FirstRun = False
            ConfigFile = XDocument.Load(GameDir & "\config\Launcher.cfg")

            Try
                If My.Application.Info.Version.ToString <> ConfigFile.<LauncherConfig>.<LastEarn>.Value Then
                    Tools.Earn("http://files.mc-craftcreeper.url.ph/freedonation.html",
                               "http://mc-craftcreeper.url.ph/thank/",
                               "CraftCreeper Launcher has been updated!" & vbNewLine & "If you wish CraftCreeper development does not stop there, click on the link below.")
                End If
            Catch

            End Try

            Try
                SelectedType = ConfigFile.<LauncherConfig>.<SelectedVersion>.@type
                LatestRelease = ConfigFile.<LauncherConfig>.<SelectedVersion>.<Release>.Value
                LatestSnapshot = ConfigFile.<LauncherConfig>.<SelectedVersion>.<Snapshot>.Value
                LatestOptifine = ConfigFile.<LauncherConfig>.<SelectedVersion>.<Optifine>.Value
                LatestInstalled = ConfigFile.<LauncherConfig>.<SelectedVersion>.<Installed>.Value

                Select Case SelectedType
                    Case 0
                        SelectedVersion = LatestRelease
                    Case 1
                        SelectedVersion = LatestSnapshot
                    Case 2
                        SelectedVersion = LatestOptifine
                    Case 3
                        SelectedVersion = LatestInstalled
                End Select

                If ConfigFile.<LauncherConfig>.<Java>.<CustomPath>.@use Then
                    JavawPath = ConfigFile.<LauncherConfig>.<Java>.<CustomPath>.Value
                    UseCustomJavawPath = True
                End If
                If ConfigFile.<LauncherConfig>.<Java>.<CustomArgs>.@use Then
                    JvmArguments = ConfigFile.<LauncherConfig>.<Java>.<CustomArgs>.Value
                    UseCustomJvmAguments = True
                End If

                'OldPlayer = ConfigFile.<LauncherConfig>.<Auth>.<Player>.Value
                'OldAccessToken = ConfigFile.<LauncherConfig>.<Auth>.<AccessToken>.Value
                'OldClientToken = ConfigFile.<LauncherConfig>.<Auth>.<ClientToken>.Value
                'OldUuid = ConfigFile.<LauncherConfig>.<Auth>.<Uuid>.Value
                OnlineMode = ConfigFile.<LauncherConfig>.<Auth>.<OnlineMode>.Value
                AutoLogin = ConfigFile.<LauncherConfig>.<Auth>.@use
                If AutoLogin And ConfigFile.<LauncherConfig>.<Auth>.@loggedin Then
                    Dim U As String = ConfigFile.<LauncherConfig>.<Auth>.<Credentials>.@u
                    Dim P As String = ConfigFile.<LauncherConfig>.<Auth>.<Credentials>.@p
                    LauncherForm.UsernameTextBox.Text = U
                    LauncherForm.PasswordTextBox.Text = P
                    LauncherForm.OnlinemodeCheckBox.Checked = OnlineMode
                    Auth.Login(U, OnlineMode, P)
                End If
                CWGS = ConfigFile.<LauncherConfig>.<CWGS>.Value
            Catch ex As Exception
                MsgBox("Error while loading" & vbNewLine & ex.InnerException.ToString)
                Save()
            End Try
        End If

        If Internet Then
            GetOfficialVersions()
            GetOptifineVersions()
        End If
        GetJavaInfos()
        ListInstalledVersions()

        If FirstRun Then
            LatestRelease = MinecraftVersions(0)
        End If

        Tools.UpdateInfoLabel()
    End Sub

    Public Shared Function GetOfficialVersions()
        Dim NWC As New WebClient
        Dim VersionsString As String = NWC.DownloadString("http://s3.amazonaws.com/Minecraft.Download/versions/versions.json")
        Dim VersionsJson As New JObject
        VersionsJson = JsonConvert.DeserializeObject(VersionsString)
        Dim MV As Integer = 0
        Dim MSV As Integer = 0
        For StepId = 0 To VersionsJson.Item("versions").Count - 1
            If VersionsJson.Item("versions").ElementAt(StepId).Item("type").ToString = "release" Then
                ReDim Preserve MinecraftVersions(MV)
                MinecraftVersions.SetValue(VersionsJson.Item("versions").ElementAt(StepId).Item("id").ToString, MV)
                MV += 1
            Else
                ReDim Preserve MinecraftSnapshotVersions(MSV)
                MinecraftSnapshotVersions.SetValue(VersionsJson.Item("versions").ElementAt(StepId).Item("id").ToString, MSV)
                MSV += 1
            End If
        Next
        Return True
    End Function

    Public Shared Function GetOptifineVersions()
        Dim NWC As New WebClient
        Dim VersionString As String = NWC.DownloadString("http://optifine.net/downloads")
        Dim VersionArray() As String = Split(VersionString, "<td class='downloadLineFileFirst'>")
        MsgBox("ok" & vbNewLine & VersionArray(1))
        Dim TableNb As Integer = VersionArray.Count - 2
        For TableId As Integer = 0 To TableNb
            ReDim Preserve OptifineVersions(TableId)
            OptifineVersions.SetValue(Split(VersionArray(TableId + 1), "</td>")(0), TableId)
        Next
        Return True
    End Function

    Public Shared Function ListInstalledVersions()
        Directory.CreateDirectory(GameDir & "\versions")
        Dim IV As Integer = 0
        For Each CurrentPath As String In Directory.EnumerateDirectories(GameDir & "\versions")
            ReDim Preserve InstalledVersions(IV)
            InstalledVersions.SetValue(CurrentPath.Remove(0, CurrentPath.LastIndexOf("\") + 1), IV)
            IV += 1
        Next
        Return True
    End Function

    Public Shared Sub GetJavaInfos()
        If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\Java") And Not UseCustomJavawPath Then
            Dim JavaVersion As Integer = 0
            For Each JP As String In Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\Java", "javaw.exe", SearchOption.AllDirectories)
                Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(JP)
                If FileProperties.FileMajorPart > JavaVersion Then
                    JavawPath = JP
                    JavaVersion = FileProperties.FileMajorPart
                End If
            Next
            If File.Exists(JavawPath.Remove(JavawPath.LastIndexOf("\")) & "\WindowsAccessBridge-64.dll") Then
                SystemArch = "64"
            Else
                SystemArch = "32"
            End If
        ElseIf Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) & "\Java") And Not UseCustomJavawPath Then
            Dim JavaVersion As Integer = 0
            For Each JP As String In Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) & "\Java", "javaw.exe", SearchOption.AllDirectories)
                Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(JP)
                If FileProperties.FileMajorPart > JavaVersion Then
                    JavawPath = JP
                    JavaVersion = FileProperties.FileMajorPart
                End If
            Next
            SystemArch = "32"
        ElseIf UseCustomJavawPath Then
            If File.Exists(JavawPath.Remove(JavawPath.LastIndexOf("\")) & "\WindowsAccessBridge-64.dll") Then
                SystemArch = "64"
            Else
                SystemArch = "32"
            End If
        Else
            Tools.Msg("Java isn't installed", "Please, install Java or specify his path in settings.")
        End If
    End Sub

    Public Shared Sub ShowForm()

    End Sub

    Public Shared Function Save()
        Directory.CreateDirectory(GameDir & "\config")
        Dim CF As XElement = <LauncherConfig>
                                 <Auth use=<%= AutoLogin %> loggedin=<%= Auth.LoggedIn %>>
                                     <Credentials u=<%= LauncherForm.UsernameTextBox.Text %> p=<%= LauncherForm.PasswordTextBox.Text %>/><!--This method is not secure, but only temporary-->
                                     <OnlineMode><%= OnlineMode %></OnlineMode>
                                 </Auth>
                                 <SelectedVersion type=<%= SelectedType %>>
                                     <Release><%= LatestRelease %></Release>
                                     <Snapshot><%= LatestSnapshot %></Snapshot>
                                     <Optifine><%= LatestOptifine %></Optifine>
                                     <Installed><%= LatestInstalled %></Installed>
                                 </SelectedVersion>
                                 <CWGS><%= CWGS %></CWGS>
                                 <Java>
                                     <CustomPath use=<%= UseCustomJavawPath %> arch=<%= SystemArch %>><%= JavawPath %></CustomPath>
                                     <CustomArgs use=<%= UseCustomJvmAguments %>><%= JvmArguments %></CustomArgs>
                                 </Java>
                                 <LastEarn><%= My.Application.Info.Version.ToString %></LastEarn>
                             </LauncherConfig>
        CF.Save(GameDir & "\config\Launcher.cfg")
        '<Player><%= Auth.Player %></Player>
        '<Uuid><%= Auth.Uuid %></Uuid>
        '<AccessToken><%= Auth.AccessToken %></AccessToken>
        '<ClientToken><%= Auth.ClientToken %></ClientToken>
        'Dim SW As New StreamWriter(GameDir & "\config\Launcher.cfg")
        'SW.Write(ConfigFile.ToString)
        'SW.Close()


        Return True
    End Function

End Class
