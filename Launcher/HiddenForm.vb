Public Class HiddenForm

    Dim HF As Form

    Sub HideForm(ByVal HiddedForm As Form)
        HF = HiddedForm
        Me.Text = HF.Text
        Me.Icon = HF.Icon
        HF.Hide()
        Me.Show()
    End Sub

    Sub Restore() Handles Me.GotFocus
        HF.Show()
        Me.Close()
    End Sub

End Class