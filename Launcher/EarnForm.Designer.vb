<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EarnForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EarnForm))
        Me.PerplexTheme = New CraftCreeper_Launcher.PerplexTheme()
        Me.MsgLabel = New System.Windows.Forms.Label()
        Me.EarnWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.CancelEarnButton = New CraftCreeper_Launcher.PerplexButton()
        Me.PerplexTheme.SuspendLayout()
        Me.SuspendLayout()
        '
        'PerplexTheme
        '
        Me.PerplexTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.PerplexTheme.Controls.Add(Me.MsgLabel)
        Me.PerplexTheme.Controls.Add(Me.EarnWebBrowser)
        Me.PerplexTheme.Controls.Add(Me.CancelEarnButton)
        Me.PerplexTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PerplexTheme.Location = New System.Drawing.Point(0, 0)
        Me.PerplexTheme.Name = "PerplexTheme"
        Me.PerplexTheme.Size = New System.Drawing.Size(834, 462)
        Me.PerplexTheme.TabIndex = 0
        Me.PerplexTheme.Text = "Remuneration page"
        '
        'MsgLabel
        '
        Me.MsgLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MsgLabel.BackColor = System.Drawing.Color.Transparent
        Me.MsgLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.MsgLabel.Location = New System.Drawing.Point(12, 32)
        Me.MsgLabel.Name = "MsgLabel"
        Me.MsgLabel.Size = New System.Drawing.Size(810, 46)
        Me.MsgLabel.TabIndex = 9
        Me.MsgLabel.Text = "This page is used to remunerate installed mods authors."
        Me.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EarnWebBrowser
        '
        Me.EarnWebBrowser.AllowWebBrowserDrop = False
        Me.EarnWebBrowser.IsWebBrowserContextMenuEnabled = False
        Me.EarnWebBrowser.Location = New System.Drawing.Point(12, 81)
        Me.EarnWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.EarnWebBrowser.Name = "EarnWebBrowser"
        Me.EarnWebBrowser.ScriptErrorsSuppressed = True
        Me.EarnWebBrowser.Size = New System.Drawing.Size(810, 374)
        Me.EarnWebBrowser.TabIndex = 2
        Me.EarnWebBrowser.Url = New System.Uri("", System.UriKind.Relative)
        '
        'CancelEarnButton
        '
        Me.CancelEarnButton.BackColor = System.Drawing.Color.Transparent
        Me.CancelEarnButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.CancelEarnButton.Location = New System.Drawing.Point(752, 0)
        Me.CancelEarnButton.Name = "CancelEarnButton"
        Me.CancelEarnButton.Size = New System.Drawing.Size(81, 29)
        Me.CancelEarnButton.TabIndex = 1
        Me.CancelEarnButton.Text = "Cancel"
        '
        'EarnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.PerplexTheme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EarnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remuneration page"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.PerplexTheme.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PerplexTheme As CraftCreeper_Launcher.PerplexTheme
    Friend WithEvents CancelEarnButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents EarnWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents MsgLabel As System.Windows.Forms.Label
End Class
