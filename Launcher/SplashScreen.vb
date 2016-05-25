Public NotInheritable Class SplashScreen
    Sub PlaySound() Handles MyBase.Load
        Dim Sound As New System.Media.SoundPlayer(My.Resources.SplashSound)
        Sound.Play()
    End Sub
End Class
