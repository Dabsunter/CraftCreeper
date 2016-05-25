Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Guid
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Auth
    Public Shared Player As String
    Public Shared AccessToken As String = "0"
    Public Shared ClientToken As String = "0"
    Public Shared Uuid As String = "0"
    Public Shared LoggedIn As Boolean = False
    Public Shared Premium As Boolean

    Public Shared Function Login(ByVal Username As String, ByVal OnlineMode As Boolean, ByVal Password As String)
        Premium = OnlineMode
        If Not OnlineMode Then
            Player = Username
            Uuid = Username
        Else
            Try
                Dim WR As WebRequest = WebRequest.Create("https://authserver.mojang.com/authenticate")
                WR.Method = "POST"
                Dim PostData As String = "{""agent"": {""name"": ""Minecraft"",""version"": 1},""username"": """ & Username & """,""password"": """ & Password & """,""requestUser"":true}"
                WR.ContentType = "application/json"
                Dim ByteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
                WR.ContentLength = ByteArray.Length
                Dim DataStream As Stream = WR.GetRequestStream
                DataStream.Write(ByteArray, 0, ByteArray.Length)
                DataStream.Close()
                Dim JsonResponse As WebResponse = WR.GetResponse
                DataStream = JsonResponse.GetResponseStream
                Dim SR As New StreamReader(DataStream)
                Dim Response As String = SR.ReadToEnd
                Dim DecodedJson As New JObject
                DecodedJson = JsonConvert.DeserializeObject(Response)
                Player = DecodedJson.Item("selectedProfile").Item("name").ToString
                Uuid = DecodedJson.Item("selectedProfile").Item("id").ToString
                AccessToken = DecodedJson.Item("accessToken").ToString
                ClientToken = DecodedJson.Item("clientToken").ToString
            Catch ex As WebException
                Dim SR As New StreamReader(ex.Response.GetResponseStream)
                Dim DecodedJson As New JObject
                DecodedJson = JsonConvert.DeserializeObject(SR.ReadToEnd)
                Tools.Msg("Failed to Login", DecodedJson.Item("errorMessage"))
                Return False
                Exit Function
            End Try
        End If
        LoggedIn = True
        Tools.Msg("Successful Login", "Welcome " & Player & "!")
        ScreenManager.Login()
        Return True
    End Function

    Public Shared Function Logout()
        If Premium Then
            Try
                Dim WR As WebRequest = WebRequest.Create("https://authserver.mojang.com/invalidate")
                WR.Method = "POST"
                Dim PostData As String = "{""accessToken"": """ & AccessToken & """,""clientToken"": """ & ClientToken & """}"
                WR.ContentType = "application/json"
                Dim ByteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
                WR.ContentLength = ByteArray.Length
                Dim DataStream As Stream = WR.GetRequestStream
                DataStream.Write(ByteArray, 0, ByteArray.Length)
                DataStream.Close()
                Dim JsonResponse As WebResponse = WR.GetResponse
                JsonResponse.GetResponseStream()
            Catch ex As WebException
                Dim SR As New StreamReader(ex.Response.GetResponseStream)
                Dim DecodedJson As New JObject
                DecodedJson = JsonConvert.DeserializeObject(SR.ReadToEnd)
                Tools.Msg("Error", DecodedJson.Item("errorMessage"))
            End Try
        End If
        Player = Nothing
        AccessToken = "0"
        ClientToken = "0"
        Uuid = "0"
        LoggedIn = False
        Premium = Nothing
        ScreenManager.Logout()
        Return True
    End Function

    Public Shared Function Refresh(ByVal OldPlayer As String, ByVal OldAccessToken As String, ByVal OldClientToken As String, ByVal OldUuid As String, ByVal OnlineMode As Boolean)
        If Not OnlineMode Then
            Player = OldPlayer
        Else
            Dim AT As String = ParseExact(NewGuid.ToString, "d").ToString.Replace("-", "")
            Try
                Dim WR As WebRequest = WebRequest.Create("https://authserver.mojang.com/refresh")
                WR.Method = "POST"
                Dim PostData As String = "{""accessToken"": """ & AT & """,""clientToken"": """ & OldClientToken & """,""selectedProfile"": {""id"": """ & OldUuid & """,""name"": """ & OldPlayer & """}}"
                MsgBox(PostData)
                WR.ContentType = "application/json"
                Dim ByteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
                WR.ContentLength = ByteArray.Length
                Dim DataStream As Stream = WR.GetRequestStream
                DataStream.Write(ByteArray, 0, ByteArray.Length)
                DataStream.Close()
                Dim JsonResponse As WebResponse = WR.GetResponse
                DataStream = JsonResponse.GetResponseStream
                Dim SR As New StreamReader(DataStream)
                Dim Response As String = SR.ReadToEnd
                Dim DecodedJson As New JObject
                DecodedJson = JsonConvert.DeserializeObject(Response)
                Player = DecodedJson.Item("selectedProfile").Item("name").ToString
                Uuid = DecodedJson.Item("selectedProfile").Item("id").ToString
                AccessToken = DecodedJson.Item("accessToken").ToString
                ClientToken = DecodedJson.Item("clientToken").ToString
                Tools.Msg("Successful Login", "Welcome " & Player & "!")
            Catch ex As WebException
                Dim SR As New StreamReader(ex.Response.GetResponseStream)
                Dim DecodedJson As New JObject
                DecodedJson = JsonConvert.DeserializeObject(SR.ReadToEnd)
                Tools.Msg("Failed to Login", DecodedJson.Item("errorMessage"))
                Return False
                Exit Function
            End Try
        End If
        LoggedIn = True
        ScreenManager.Login()
        Return True
    End Function

End Class
