<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgBoxForm
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
        Me.PerplexTheme = New CraftCreeper_Launcher.PerplexTheme()
        Me.MsgLabel = New System.Windows.Forms.Label()
        Me.OkPerplexButton = New CraftCreeper_Launcher.PerplexButton()
        Me.PerplexTheme.SuspendLayout()
        Me.SuspendLayout()
        '
        'PerplexTheme
        '
        Me.PerplexTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.PerplexTheme.Controls.Add(Me.OkPerplexButton)
        Me.PerplexTheme.Controls.Add(Me.MsgLabel)
        Me.PerplexTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PerplexTheme.Location = New System.Drawing.Point(0, 0)
        Me.PerplexTheme.Name = "PerplexTheme"
        Me.PerplexTheme.Size = New System.Drawing.Size(315, 85)
        Me.PerplexTheme.TabIndex = 0
        Me.PerplexTheme.Text = "Message Title"
        '
        'MsgLabel
        '
        Me.MsgLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MsgLabel.BackColor = System.Drawing.Color.Transparent
        Me.MsgLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.MsgLabel.Location = New System.Drawing.Point(12, 30)
        Me.MsgLabel.Name = "MsgLabel"
        Me.MsgLabel.Size = New System.Drawing.Size(291, 46)
        Me.MsgLabel.TabIndex = 8
        Me.MsgLabel.Text = "Message"
        Me.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OkPerplexButton
        '
        Me.OkPerplexButton.BackColor = System.Drawing.Color.Transparent
        Me.OkPerplexButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.OkPerplexButton.Location = New System.Drawing.Point(233, 0)
        Me.OkPerplexButton.Name = "OkPerplexButton"
        Me.OkPerplexButton.Size = New System.Drawing.Size(81, 29)
        Me.OkPerplexButton.TabIndex = 0
        Me.OkPerplexButton.Text = "OK"
        '
        'MsgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 85)
        Me.Controls.Add(Me.PerplexTheme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MsgForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.PerplexTheme.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PerplexTheme As CraftCreeper_Launcher.PerplexTheme
    Friend WithEvents OkPerplexButton As CraftCreeper_Launcher.PerplexButton
    Friend WithEvents MsgLabel As System.Windows.Forms.Label
End Class
