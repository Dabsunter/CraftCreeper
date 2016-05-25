Public Module ConsoleModule
    Public Sub Main()
        Try
            Console.Title = "Developpement Console (Beta)"
        Catch
        End Try
        Console.OpenStandardOutput()
    End Sub
    Public Sub Write(ByVal Message As String)
        Console.WriteLine(Message)
    End Sub
End Module
