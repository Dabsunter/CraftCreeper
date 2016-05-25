Imports System.Net
Imports System.IO
Imports CraftCreeper_Launcher.Game.VersionType

Public Class SettingsForm

    Private Sub JavaPathCheckBox_CheckedChanged(sender As Object) Handles JavaPathCheckBox.CheckedChanged
        If JavaPathCheckBox.Checked Then
            JavaPathTextBox.Enabled = True
        Else
            JavaPathTextBox.Enabled = False
            JavaPathTextBox.Text = Config.JavawPath
        End If
    End Sub

    Private Sub JavaArgsCheckBox_CheckedChanged(sender As Object) Handles JavaArgsCheckBox.CheckedChanged
        If JavaArgsCheckBox.Checked Then
            JavaArgsTextBox.Enabled = True
        Else
            JavaArgsTextBox.Enabled = False
            JavaArgsTextBox.Text = "-Xmx1G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M"
        End If
    End Sub

    Private Sub JavaTextBox_DoubleClick(sender As Object, e As EventArgs) Handles JavaPathTextBox.DoubleClick
        Dim OFD As New OpenFileDialog
        OFD.Title = "Choose your JVM Executable"
        OFD.Filter = "Java|javaw.exe"
        If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            JavaPathTextBox.Text = OFD.FileName
        End If
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        JavaPathCheckBox.Checked = Config.UseCustomJavawPath
        JavaPathTextBox.Enabled = Config.UseCustomJavawPath
        JavaPathTextBox.Text = Config.JavawPath

        JavaArgsCheckBox.Checked = Config.UseCustomJvmAguments
        JavaArgsTextBox.Enabled = Config.UseCustomJvmAguments
        JavaArgsTextBox.Text = Config.JvmArguments

        AutoLoginCheckBox.Checked = Config.AutoLogin

        CWGSCheckBox.Checked = Config.CWGS

        If Not Config.Internet Then
            TypeComboBox.SelectedIndex = 3
            TypeComboBox.Enabled = False
        Else
            TypeComboBox.SelectedIndex = Config.SelectedType
        End If

        Select Case TypeComboBox.SelectedIndex
            Case Release
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.MinecraftVersions)
            Case Snapshot
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.MinecraftSnapshotVersions)
            Case Optifine
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.OptifineVersions)
            Case Installed
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.InstalledVersions)
        End Select
        If IsNothing(Config.SelectedVersion) Then
            VersionsComboBox.SelectedIndex = 0
        Else
            VersionsComboBox.SelectedItem = Config.SelectedVersion
        End If
    End Sub

    Private Sub TypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBox.SelectedIndexChanged
        Select Case Config.SelectedType
            Case Release
                Config.LatestRelease = VersionsComboBox.Text
            Case Snapshot
                Config.LatestSnapshot = VersionsComboBox.Text
            Case Optifine
                Config.LatestOptifine = VersionsComboBox.Text
            Case Installed
                Config.LatestInstalled = VersionsComboBox.Text
        End Select
        Config.SelectedType = TypeComboBox.SelectedIndex
        Select Case TypeComboBox.SelectedIndex
            Case Release
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.MinecraftVersions)
                If IsNothing(Config.LatestRelease) Then
                    VersionsComboBox.SelectedIndex = 0
                Else
                    VersionsComboBox.SelectedItem = Config.LatestRelease
                End If
            Case Snapshot
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.MinecraftSnapshotVersions)
                If IsNothing(Config.LatestSnapshot) Then
                    VersionsComboBox.SelectedIndex = 0
                Else
                    VersionsComboBox.SelectedItem = Config.LatestSnapshot
                End If
            Case Optifine
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.OptifineVersions)
                If IsNothing(Config.LatestOptifine) Then
                    VersionsComboBox.SelectedIndex = 0
                Else
                    VersionsComboBox.SelectedItem = Config.LatestOptifine
                End If
            Case Installed
                VersionsComboBox.Items.Clear()
                VersionsComboBox.Items.AddRange(Config.InstalledVersions)
                If IsNothing(Config.LatestInstalled) Then
                    VersionsComboBox.SelectedIndex = 0
                Else
                    VersionsComboBox.SelectedItem = Config.LatestInstalled
                End If
        End Select
    End Sub

    Private Sub VersionsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles VersionsComboBox.SelectedIndexChanged
        Select Case Config.SelectedType
            Case Release
                Config.LatestRelease = VersionsComboBox.Text
            Case Snapshot
                Config.LatestSnapshot = VersionsComboBox.Text
            Case Optifine
                Config.LatestOptifine = VersionsComboBox.Text
            Case Installed
                Config.LatestInstalled = VersionsComboBox.Text
        End Select
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Config.SelectedVersion = VersionsComboBox.Text
        If JavaPathCheckBox.Checked Then
            Config.UseCustomJavawPath = True
            Config.JavawPath = JavaPathTextBox.Text
        Else
            Config.UseCustomJavawPath = False
        End If
        Config.GetJavaInfos()
        Config.UseCustomJvmAguments = JavaArgsCheckBox.Checked
        Config.JvmArguments = JavaArgsTextBox.Text
        Config.AutoLogin = AutoLoginCheckBox.Checked
        Config.CWGS = CWGSCheckBox.Checked
        Tools.UpdateInfoLabel()
        Me.Close()
    End Sub
End Class