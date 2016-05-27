Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq

Public Class StartForm

    Dim Internet As Boolean
    Dim WithEvents NWC As New WebClient
    Dim LastVersion As String
    Dim GameDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.CraftCreeper"

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim InternetTest = XDocument.Load("http://dabsunter.github.io/CraftCreeper/webtest")
            Internet = InternetTest.<IsWebTestSuccess>.@result
        Catch
            Internet = False
        End Try
        If Internet Then
            Dim Xml = XDocument.Load("http://dabsunter.github.io/CraftCreeper/versions/versions.xml")
            LastVersion = Xml.<Versions>.<Launcher>.Value
            If File.Exists(GameDir & "\Launcher.exe") Then
                Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(GameDir & "\Launcher.exe")
                If FileProperties.FileVersion <> LastVersion Then
                    AskForUpdate()
                Else
                    StartLauncher()
                End If
            Else
                AskForUpdate()
            End If
        Else
            If File.Exists(GameDir & "\Launcher.exe") Then
                StartLauncher()
            Else
                MsgBox("Missing files and can't be downloaded...", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Sub AskForUpdate()
        If MsgBox("CraftCreeper Launcher version " & LastVersion.Remove(LastVersion.LastIndexOf(".")) & " is available." & vbNewLine & "Do you want to download it now?", MsgBoxStyle.YesNo, "New version available") = MsgBoxResult.Yes Then
            DownloadForm.Show()
            Download()
        Else
            End
        End If
    End Sub

    Sub Download()
        Try
            DownloadForm.InfoLabel.Text = "Downloading..."
            Directory.CreateDirectory(GameDir)
            If File.Exists(GameDir & "\launcher.zip") Then File.Delete(GameDir & "\launcher.zip")
            NWC.DownloadFileAsync(New Uri("http://dabsunter.github.io/CraftCreeper/launcher.zip"), GameDir & "\launcher.zip")
        Catch
            MsgBox("An error occurred while downloading the file!", MsgBoxStyle.Exclamation, "Error")
            End
        End Try
    End Sub

    Sub Downloading(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles NWC.DownloadProgressChanged
        DownloadForm.ProgressBar.Value = e.ProgressPercentage
    End Sub

    Function Extract()
        Directory.CreateDirectory(GameDir & "\extract")
        Compression.ZipFile.ExtractToDirectory(GameDir & "\launcher.zip", GameDir & "\extract")
        For Each FilePath In Directory.EnumerateFiles(GameDir & "\extract", ".", SearchOption.AllDirectories)
            File.Copy(FilePath, FilePath.Replace("\extract", ""), True)
        Next
        Directory.Delete(GameDir & "\extract", True)
        Return True
    End Function

    Sub Download_Completed() Handles NWC.DownloadFileCompleted
        DownloadForm.InfoLabel.Text = "Extracting..."
        DownloadForm.ProgressBar.Style = ProgressBarStyle.Marquee
        Extract()
        StartLauncher()
    End Sub

    Sub StartLauncher()
        Dim ProcessProperty As New ProcessStartInfo
        ProcessProperty.FileName = GameDir & "\Launcher.exe"
        ProcessProperty.Arguments = Application.ExecutablePath
        ProcessProperty.WorkingDirectory = GameDir
        Process.Start(ProcessProperty)
        End
    End Sub
End Class