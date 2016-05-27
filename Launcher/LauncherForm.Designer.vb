<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LauncherForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LauncherForm))
        Me.PerplexTheme = New CraftCreeper_Launcher.PerplexTheme()
        Me.LogsTextBox = New System.Windows.Forms.TextBox()
        Me.AvatarPictureBox = New System.Windows.Forms.PictureBox()
        Me.TestTextBox = New System.Windows.Forms.TextBox()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.NewsWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.SettingsPictureBox = New System.Windows.Forms.PictureBox()
        Me.LoadProgressBar = New CraftCreeper_Launcher.PerplexProgressBar()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.LogoutButton = New CraftCreeper_Launcher.PerplexButton()
        Me.LoginButton = New CraftCreeper_Launcher.PerplexButton()
        Me.OnlinemodeCheckBox = New CraftCreeper_Launcher.PerplexCheckBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PlayButton = New CraftCreeper_Launcher.PerplexButton()
        Me.PerplexControlBox = New CraftCreeper_Launcher.PerplexControlBox()
        Me.PerplexTheme.SuspendLayout()
        CType(Me.AvatarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettingsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PerplexTheme
        '
        Me.PerplexTheme.BackColor = System.Drawing.Color.Transparent
        Me.PerplexTheme.Controls.Add(Me.LogsTextBox)
        Me.PerplexTheme.Controls.Add(Me.AvatarPictureBox)
        Me.PerplexTheme.Controls.Add(Me.TestTextBox)
        Me.PerplexTheme.Controls.Add(Me.TestButton)
        Me.PerplexTheme.Controls.Add(Me.NewsWebBrowser)
        Me.PerplexTheme.Controls.Add(Me.SettingsPictureBox)
        Me.PerplexTheme.Controls.Add(Me.LoadProgressBar)
        Me.PerplexTheme.Controls.Add(Me.UsernameLabel)
        Me.PerplexTheme.Controls.Add(Me.InfoLabel)
        Me.PerplexTheme.Controls.Add(Me.LogoutButton)
        Me.PerplexTheme.Controls.Add(Me.LoginButton)
        Me.PerplexTheme.Controls.Add(Me.OnlinemodeCheckBox)
        Me.PerplexTheme.Controls.Add(Me.PasswordTextBox)
        Me.PerplexTheme.Controls.Add(Me.UsernameTextBox)
        Me.PerplexTheme.Controls.Add(Me.PlayButton)
        Me.PerplexTheme.Controls.Add(Me.PerplexControlBox)
        Me.PerplexTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PerplexTheme.Location = New System.Drawing.Point(0, 0)
        Me.PerplexTheme.Name = "PerplexTheme"
        Me.PerplexTheme.Size = New System.Drawing.Size(834, 462)
        Me.PerplexTheme.TabIndex = 0
        Me.PerplexTheme.Text = "CraftCreeper Launcher β0.0.2"
        '
        'LogsTextBox
        '
        Me.LogsTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LogsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LogsTextBox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogsTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogsTextBox.Location = New System.Drawing.Point(12, 32)
        Me.LogsTextBox.Multiline = True
        Me.LogsTextBox.Name = "LogsTextBox"
        Me.LogsTextBox.ReadOnly = True
        Me.LogsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LogsTextBox.Size = New System.Drawing.Size(810, 362)
        Me.LogsTextBox.TabIndex = 14
        Me.LogsTextBox.Text = "CraftCreeper Launcher - Developpement Console (Beta)"
        Me.LogsTextBox.Visible = False
        '
        'AvatarPictureBox
        '
        Me.AvatarPictureBox.Location = New System.Drawing.Point(15, 398)
        Me.AvatarPictureBox.Name = "AvatarPictureBox"
        Me.AvatarPictureBox.Size = New System.Drawing.Size(54, 54)
        Me.AvatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.AvatarPictureBox.TabIndex = 13
        Me.AvatarPictureBox.TabStop = False
        Me.AvatarPictureBox.Visible = False
        '
        'TestTextBox
        '
        Me.TestTextBox.Location = New System.Drawing.Point(569, 400)
        Me.TestTextBox.Multiline = True
        Me.TestTextBox.Name = "TestTextBox"
        Me.TestTextBox.Size = New System.Drawing.Size(124, 52)
        Me.TestTextBox.TabIndex = 12
        Me.TestTextBox.Visible = False
        '
        'TestButton
        '
        Me.TestButton.Location = New System.Drawing.Point(488, 415)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(75, 23)
        Me.TestButton.TabIndex = 10
        Me.TestButton.Text = "test"
        Me.TestButton.UseVisualStyleBackColor = True
        Me.TestButton.Visible = False
        '
        'NewsWebBrowser
        '
        Me.NewsWebBrowser.AllowNavigation = False
        Me.NewsWebBrowser.AllowWebBrowserDrop = False
        Me.NewsWebBrowser.IsWebBrowserContextMenuEnabled = False
        Me.NewsWebBrowser.Location = New System.Drawing.Point(12, 32)
        Me.NewsWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.NewsWebBrowser.Name = "NewsWebBrowser"
        Me.NewsWebBrowser.ScriptErrorsSuppressed = True
        Me.NewsWebBrowser.Size = New System.Drawing.Size(810, 362)
        Me.NewsWebBrowser.TabIndex = 1
        Me.NewsWebBrowser.Url = New System.Uri("http://mcupdate.tumblr.com/", System.UriKind.Absolute)
        '
        'SettingsPictureBox
        '
        Me.SettingsPictureBox.Image = Global.CraftCreeper_Launcher.My.Resources.Resources.Compile
        Me.SettingsPictureBox.Location = New System.Drawing.Point(757, 3)
        Me.SettingsPictureBox.Name = "SettingsPictureBox"
        Me.SettingsPictureBox.Size = New System.Drawing.Size(23, 23)
        Me.SettingsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SettingsPictureBox.TabIndex = 9
        Me.SettingsPictureBox.TabStop = False
        '
        'LoadProgressBar
        '
        Me.LoadProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.LoadProgressBar.Location = New System.Drawing.Point(12, 374)
        Me.LoadProgressBar.Maximum = 100
        Me.LoadProgressBar.Name = "LoadProgressBar"
        Me.LoadProgressBar.ShowPercentage = False
        Me.LoadProgressBar.Size = New System.Drawing.Size(810, 20)
        Me.LoadProgressBar.TabIndex = 8
        Me.LoadProgressBar.Value = 0
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.UsernameLabel.Location = New System.Drawing.Point(75, 402)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(0, 16)
        Me.UsernameLabel.TabIndex = 7
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsernameLabel.Visible = False
        '
        'InfoLabel
        '
        Me.InfoLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.InfoLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.InfoLabel.Location = New System.Drawing.Point(699, 400)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(123, 52)
        Me.InfoLabel.TabIndex = 7
        Me.InfoLabel.Text = "Please, login."
        Me.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogoutButton
        '
        Me.LogoutButton.BackColor = System.Drawing.Color.Transparent
        Me.LogoutButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.LogoutButton.Location = New System.Drawing.Point(75, 429)
        Me.LogoutButton.Name = "LogoutButton"
        Me.LogoutButton.Size = New System.Drawing.Size(60, 23)
        Me.LogoutButton.TabIndex = 6
        Me.LogoutButton.Text = "Logout"
        Me.LogoutButton.Visible = False
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.Transparent
        Me.LoginButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.LoginButton.Location = New System.Drawing.Point(118, 429)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(60, 23)
        Me.LoginButton.TabIndex = 6
        Me.LoginButton.Text = "Login"
        '
        'OnlinemodeCheckBox
        '
        Me.OnlinemodeCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.OnlinemodeCheckBox.Checked = True
        Me.OnlinemodeCheckBox.ForeColor = System.Drawing.Color.Black
        Me.OnlinemodeCheckBox.Location = New System.Drawing.Point(118, 404)
        Me.OnlinemodeCheckBox.Name = "OnlinemodeCheckBox"
        Me.OnlinemodeCheckBox.Size = New System.Drawing.Size(145, 14)
        Me.OnlinemodeCheckBox.TabIndex = 5
        Me.OnlinemodeCheckBox.Text = "Online-Mode"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasswordTextBox.Location = New System.Drawing.Point(12, 429)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.PasswordTextBox.Size = New System.Drawing.Size(100, 23)
        Me.PasswordTextBox.TabIndex = 4
        Me.PasswordTextBox.Text = "*****"
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UsernameTextBox.Location = New System.Drawing.Point(12, 400)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(100, 23)
        Me.UsernameTextBox.TabIndex = 3
        Me.UsernameTextBox.Text = "E-Mail"
        '
        'PlayButton
        '
        Me.PlayButton.BackColor = System.Drawing.Color.Transparent
        Me.PlayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.PlayButton.Location = New System.Drawing.Point(353, 400)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(129, 52)
        Me.PlayButton.TabIndex = 2
        Me.PlayButton.Text = "Play"
        '
        'PerplexControlBox
        '
        Me.PerplexControlBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PerplexControlBox.BackColor = System.Drawing.Color.Transparent
        Me.PerplexControlBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.PerplexControlBox.Location = New System.Drawing.Point(784, 3)
        Me.PerplexControlBox.Name = "PerplexControlBox"
        Me.PerplexControlBox.Size = New System.Drawing.Size(47, 23)
        Me.PerplexControlBox.TabIndex = 0
        '
        'LauncherForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.PerplexTheme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LauncherForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CraftCreeper Launcher β0.0.2"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.PerplexTheme.ResumeLayout(False)
        Me.PerplexTheme.PerformLayout()
        CType(Me.AvatarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettingsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PerplexTheme As CraftCreeper_Launcher.PerplexTheme
    Friend WithEvents PerplexControlBox As CraftCreeper_Launcher.PerplexControlBox
    Friend WithEvents NewsWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents PlayButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents OnlinemodeCheckBox As CraftCreeper_Launcher.PerplexCheckBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoginButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents LoadProgressBar As CraftCreeper_Launcher.PerplexProgressBar
    Friend WithEvents SettingsPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TestButton As System.Windows.Forms.Button
    Friend WithEvents TestTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AvatarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents LogoutButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents LogsTextBox As System.Windows.Forms.TextBox

End Class
