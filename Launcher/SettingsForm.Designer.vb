<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.JavaToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.JavaPathTextBox = New System.Windows.Forms.TextBox()
        Me.PerplexTheme = New CraftCreeper_Launcher.PerplexTheme()
        Me.LauncherGroupBox = New CraftCreeper_Launcher.PerplexGroupBox()
        Me.CWGSCheckBox = New CraftCreeper_Launcher.PerplexCheckBox()
        Me.AutoLoginCheckBox = New CraftCreeper_Launcher.PerplexCheckBox()
        Me.MinecraftGroupBox = New CraftCreeper_Launcher.PerplexGroupBox()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.TypeLabel = New System.Windows.Forms.Label()
        Me.VersionsComboBox = New System.Windows.Forms.ComboBox()
        Me.SaveButton = New CraftCreeper_Launcher.PerplexButton()
        Me.JavaGroupBox = New CraftCreeper_Launcher.PerplexGroupBox()
        Me.JavaArgsCheckBox = New CraftCreeper_Launcher.PerplexCheckBox()
        Me.JavaPathCheckBox = New CraftCreeper_Launcher.PerplexCheckBox()
        Me.JavaArgsTextBox = New System.Windows.Forms.TextBox()
        Me.PerplexTheme.SuspendLayout()
        Me.LauncherGroupBox.SuspendLayout()
        Me.MinecraftGroupBox.SuspendLayout()
        Me.JavaGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'JavaToolTip
        '
        Me.JavaToolTip.AutoPopDelay = 10000
        Me.JavaToolTip.InitialDelay = 500
        Me.JavaToolTip.IsBalloon = True
        Me.JavaToolTip.ReshowDelay = 100
        Me.JavaToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.JavaToolTip.ToolTipTitle = "Edit the used executable:"
        '
        'JavaPathTextBox
        '
        Me.JavaPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JavaPathTextBox.Enabled = False
        Me.JavaPathTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JavaPathTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.JavaPathTextBox.Location = New System.Drawing.Point(158, 34)
        Me.JavaPathTextBox.Name = "JavaPathTextBox"
        Me.JavaPathTextBox.Size = New System.Drawing.Size(496, 23)
        Me.JavaPathTextBox.TabIndex = 4
        Me.JavaToolTip.SetToolTip(Me.JavaPathTextBox, "Double-click here for select your executable.")
        '
        'PerplexTheme
        '
        Me.PerplexTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.PerplexTheme.Controls.Add(Me.LauncherGroupBox)
        Me.PerplexTheme.Controls.Add(Me.MinecraftGroupBox)
        Me.PerplexTheme.Controls.Add(Me.SaveButton)
        Me.PerplexTheme.Controls.Add(Me.JavaGroupBox)
        Me.PerplexTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PerplexTheme.Location = New System.Drawing.Point(0, 0)
        Me.PerplexTheme.Name = "PerplexTheme"
        Me.PerplexTheme.Size = New System.Drawing.Size(700, 245)
        Me.PerplexTheme.TabIndex = 0
        Me.PerplexTheme.Text = "Settings"
        '
        'LauncherGroupBox
        '
        Me.LauncherGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.LauncherGroupBox.Controls.Add(Me.CWGSCheckBox)
        Me.LauncherGroupBox.Controls.Add(Me.AutoLoginCheckBox)
        Me.LauncherGroupBox.Location = New System.Drawing.Point(354, 35)
        Me.LauncherGroupBox.Name = "LauncherGroupBox"
        Me.LauncherGroupBox.Size = New System.Drawing.Size(330, 95)
        Me.LauncherGroupBox.TabIndex = 9
        Me.LauncherGroupBox.Text = "Launcher"
        '
        'CWGSCheckBox
        '
        Me.CWGSCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.CWGSCheckBox.Checked = False
        Me.CWGSCheckBox.ForeColor = System.Drawing.Color.Black
        Me.CWGSCheckBox.Location = New System.Drawing.Point(13, 65)
        Me.CWGSCheckBox.Name = "CWGSCheckBox"
        Me.CWGSCheckBox.Size = New System.Drawing.Size(305, 14)
        Me.CWGSCheckBox.TabIndex = 0
        Me.CWGSCheckBox.Text = "Close when game start"
        '
        'AutoLoginCheckBox
        '
        Me.AutoLoginCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.AutoLoginCheckBox.Checked = False
        Me.AutoLoginCheckBox.ForeColor = System.Drawing.Color.Black
        Me.AutoLoginCheckBox.Location = New System.Drawing.Point(13, 37)
        Me.AutoLoginCheckBox.Name = "AutoLoginCheckBox"
        Me.AutoLoginCheckBox.Size = New System.Drawing.Size(305, 14)
        Me.AutoLoginCheckBox.TabIndex = 0
        Me.AutoLoginCheckBox.Text = "Sign in automatically on startup"
        '
        'MinecraftGroupBox
        '
        Me.MinecraftGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.MinecraftGroupBox.Controls.Add(Me.VersionLabel)
        Me.MinecraftGroupBox.Controls.Add(Me.TypeComboBox)
        Me.MinecraftGroupBox.Controls.Add(Me.TypeLabel)
        Me.MinecraftGroupBox.Controls.Add(Me.VersionsComboBox)
        Me.MinecraftGroupBox.Location = New System.Drawing.Point(18, 35)
        Me.MinecraftGroupBox.Name = "MinecraftGroupBox"
        Me.MinecraftGroupBox.Size = New System.Drawing.Size(330, 95)
        Me.MinecraftGroupBox.TabIndex = 9
        Me.MinecraftGroupBox.Text = "Minecraft        "
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.VersionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.VersionLabel.Location = New System.Drawing.Point(6, 63)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(62, 16)
        Me.VersionLabel.TabIndex = 8
        Me.VersionLabel.Text = "Version:"
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeComboBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Items.AddRange(New Object() {"Minecraft", "Minecraft Snapshot", "OptiFine", "Installed"})
        Me.TypeComboBox.Location = New System.Drawing.Point(83, 33)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(237, 22)
        Me.TypeComboBox.TabIndex = 0
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.BackColor = System.Drawing.Color.Transparent
        Me.TypeLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.TypeLabel.Location = New System.Drawing.Point(6, 35)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(44, 16)
        Me.TypeLabel.TabIndex = 8
        Me.TypeLabel.Text = "Type:"
        Me.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VersionsComboBox
        '
        Me.VersionsComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.VersionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VersionsComboBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionsComboBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.VersionsComboBox.FormattingEnabled = True
        Me.VersionsComboBox.Location = New System.Drawing.Point(83, 61)
        Me.VersionsComboBox.Name = "VersionsComboBox"
        Me.VersionsComboBox.Size = New System.Drawing.Size(237, 22)
        Me.VersionsComboBox.TabIndex = 0
        '
        'SaveButton
        '
        Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.SaveButton.Location = New System.Drawing.Point(618, 0)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(82, 29)
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "Save"
        '
        'JavaGroupBox
        '
        Me.JavaGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.JavaGroupBox.Controls.Add(Me.JavaArgsCheckBox)
        Me.JavaGroupBox.Controls.Add(Me.JavaPathCheckBox)
        Me.JavaGroupBox.Controls.Add(Me.JavaArgsTextBox)
        Me.JavaGroupBox.Controls.Add(Me.JavaPathTextBox)
        Me.JavaGroupBox.Location = New System.Drawing.Point(18, 136)
        Me.JavaGroupBox.Name = "JavaGroupBox"
        Me.JavaGroupBox.Size = New System.Drawing.Size(666, 98)
        Me.JavaGroupBox.TabIndex = 10
        Me.JavaGroupBox.Text = "Java"
        '
        'JavaArgsCheckBox
        '
        Me.JavaArgsCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.JavaArgsCheckBox.Checked = False
        Me.JavaArgsCheckBox.ForeColor = System.Drawing.Color.Black
        Me.JavaArgsCheckBox.Location = New System.Drawing.Point(9, 68)
        Me.JavaArgsCheckBox.Name = "JavaArgsCheckBox"
        Me.JavaArgsCheckBox.Size = New System.Drawing.Size(143, 14)
        Me.JavaArgsCheckBox.TabIndex = 0
        Me.JavaArgsCheckBox.Text = "Custom arguments:"
        '
        'JavaPathCheckBox
        '
        Me.JavaPathCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.JavaPathCheckBox.Checked = False
        Me.JavaPathCheckBox.ForeColor = System.Drawing.Color.Black
        Me.JavaPathCheckBox.Location = New System.Drawing.Point(9, 39)
        Me.JavaPathCheckBox.Name = "JavaPathCheckBox"
        Me.JavaPathCheckBox.Size = New System.Drawing.Size(143, 14)
        Me.JavaPathCheckBox.TabIndex = 0
        Me.JavaPathCheckBox.Text = "Custom executable:"
        '
        'JavaArgsTextBox
        '
        Me.JavaArgsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.JavaArgsTextBox.Enabled = False
        Me.JavaArgsTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JavaArgsTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.JavaArgsTextBox.Location = New System.Drawing.Point(158, 63)
        Me.JavaArgsTextBox.Name = "JavaArgsTextBox"
        Me.JavaArgsTextBox.Size = New System.Drawing.Size(496, 23)
        Me.JavaArgsTextBox.TabIndex = 4
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(700, 245)
        Me.Controls.Add(Me.PerplexTheme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.PerplexTheme.ResumeLayout(False)
        Me.LauncherGroupBox.ResumeLayout(False)
        Me.MinecraftGroupBox.ResumeLayout(False)
        Me.MinecraftGroupBox.PerformLayout()
        Me.JavaGroupBox.ResumeLayout(False)
        Me.JavaGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PerplexTheme As CraftCreeper_Launcher.PerplexTheme
    Friend WithEvents JavaPathCheckBox As CraftCreeper_Launcher.PerplexCheckBox
    Friend WithEvents JavaPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SaveButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents JavaToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MinecraftGroupBox As CraftCreeper_Launcher.PerplexGroupBox
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents VersionsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LauncherGroupBox As CraftCreeper_Launcher.PerplexGroupBox
    Friend WithEvents JavaGroupBox As CraftCreeper_Launcher.PerplexGroupBox
    Friend WithEvents CWGSCheckBox As CraftCreeper_Launcher.PerplexCheckBox
    Friend WithEvents AutoLoginCheckBox As CraftCreeper_Launcher.PerplexCheckBox
    Friend WithEvents JavaArgsCheckBox As CraftCreeper_Launcher.PerplexCheckBox
    Friend WithEvents JavaArgsTextBox As System.Windows.Forms.TextBox
End Class
