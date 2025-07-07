
Imports System.Web.Mail
Imports Microsoft.Office.interop.outlook
Imports Microsoft.Office
Imports System.Exception




Module Email

    'Sub Main(ByVal Sender As String, ByVal Recever As String, ByVal Subject As String, ByVal Message As String)

    '    Dim oMsg As MailMessage = New MailMessage()

    '    ' TODO: Replace with sender e-mail address.
    '    oMsg.From = Sender
    '    ' TODO: Replace with recipient e-mail address.
    '    oMsg.To = Recever
    '    oMsg.Subject = subject

    '    ' SEND IN HTML FORMAT (comment this line to send plain text).
    '    oMsg.BodyFormat = MailFormat.Html

    '    'HTML Body (remove HTML tags for plain text).
    '    oMsg.Body = "<HTML><BODY><B>Hello World!</B></BODY></HTML>"

    '    ' ADD AN ATTACHMENT.
    '    ' TODO: Replace with path to attachment.
    '    ''Dim sFile As String = "C:\temp\Hello.txt"
    '    ''Dim oAttch As MailAttachment = New MailAttachment(sFile, MailEncoding.Base64)

    '    ''oMsg.Attachments.Add(oAttch)

    '    ' TODO: Replace with the name of your remote SMTP server.
    '    SmtpMail.SmtpServer = "MySMTPServer"
    '    SmtpMail.Send(oMsg)

    '    oMsg = Nothing
    '    'oAttch = Nothing
    'End Sub
    Friend Sub SendEmail(ByVal MailTO As String, ByVal Subject As String, ByVal Message As String, ByVal AttachmentFile As String, ByVal AttachmentName As String, ByVal AttachmentFile2 As String, SendDateTime As Date, Scheduled As Boolean) ' Create an Outlook application.

        Try

            Dim oApp As Microsoft.Office.Interop.Outlook.Application
            Try
                oApp = New Microsoft.Office.Interop.Outlook.Application()
            Catch exx As system.Exception
                MsgBox("Error at creating outlook application")

            End Try

            ' Create a new MailItem.
            Dim oMsg As Microsoft.Office.Interop.Outlook._MailItem
            oMsg = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)


            oMsg.Subject = Subject
            oMsg.Body = Message
            oMsg.To = MailTO

            'Dim sAttaSource As String = "C:\Temp\Hello.txt"
            ' TODO: Replace with attachment name
            'Dim sDisplayName As String = "Hello.txt"
            If AttachmentFile <> "" Then
                Dim sBodyLen As String = oMsg.Body.Length
                Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = oMsg.Attachments
                Dim oAttach As Microsoft.Office.Interop.Outlook.Attachment
                oAttach = oAttachs.Add(AttachmentFile, , sBodyLen + 1, AttachmentName)
                If AttachmentFile2 <> "" Then
                    oAttach = oAttachs.Add(AttachmentFile2, , sBodyLen + 1, AttachmentName)
                End If
            End If

            ' Send
            If Scheduled Then
                If SendDateTime >= DateTime.Now Then
                    oMsg.DeferredDeliveryTime = SendDateTime
                    ' System.Threading.Thread.Sleep(1000) ' 1 second delay to allow Outlook to process
                    'oMsg.Save()
                    'System.Threading.Thread.Sleep(500)
                    oMsg.Send()
                Else
                    oMsg.Send()
                End If
            Else
                oMsg.Send()
            End If



            ' Clean up
            oApp = Nothing
            oMsg = Nothing
            'oAttach = Nothing
            'oAttachs = Nothing
        Catch ex As System.Exception
            Utils.ShowException(ex)
        End Try

    End Sub
    Friend Sub SendEmailTEST(ByVal MailTO As String, ByVal Subject As String, ByVal Message As String, ByVal AttachmentFile As String, ByVal AttachmentName As String, ByVal AttachmentFile2 As String, SendDateTime As Date, Scheduled As Boolean) ' Create an Outlook application.

        Try


            Dim oApp As Object = Nothing
            Try
                oApp = Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application")
            Catch ex As system.Exception
                oApp = CreateObject("Outlook.Application")
            End Try

            'Dim oApp As Microsoft.Office.Interop.Outlook.Application
            'Try
            '    oApp = New Microsoft.Office.Interop.Outlook.Application()
            'Catch exx As System.Exception
            '    MsgBox("Error at creating outlook application")

            'End Try

            ' Create a new MailItem.
            Dim oMsg As Microsoft.Office.Interop.Outlook._MailItem
            oMsg = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)


            oMsg.Subject = Subject
            oMsg.Body = Message
            oMsg.To = MailTO

            'Dim sAttaSource As String = "C:\Temp\Hello.txt"
            ' TODO: Replace with attachment name
            'Dim sDisplayName As String = "Hello.txt"
            If AttachmentFile <> "" Then
                Dim sBodyLen As String = oMsg.Body.Length
                Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = oMsg.Attachments
                Dim oAttach As Microsoft.Office.Interop.Outlook.Attachment
                oAttach = oAttachs.Add(AttachmentFile, , sBodyLen + 1, AttachmentName)
                If AttachmentFile2 <> "" Then
                    oAttach = oAttachs.Add(AttachmentFile2, , sBodyLen + 1, AttachmentName)
                End If
            End If

            ' Send
            If Scheduled Then
                If SendDateTime >= DateTime.Now Then
                    oMsg.DeferredDeliveryTime = SendDateTime
                    ' System.Threading.Thread.Sleep(1000) ' 1 second delay to allow Outlook to process
                    'oMsg.Save()
                    'System.Threading.Thread.Sleep(500)
                    oMsg.Send()
                Else
                    oMsg.Send()
                End If
            Else
                oMsg.Send()
            End If



            ' Clean up
            oApp = Nothing
            oMsg = Nothing
            'oAttach = Nothing
            'oAttachs = Nothing
        Catch ex As System.Exception
            Utils.ShowException(ex)
        End Try

    End Sub
    Friend Sub SendEmail2(ByVal MailTO As String, ByVal Subject As String, ByVal Message As String, ByVal FilesArray() As String, ByVal AttachmentName As String)

        Try



            Dim oApp As Microsoft.Office.Interop.Outlook.Application
            oApp = New Microsoft.Office.Interop.Outlook.Application()

            ' Create a new MailItem.
            Dim oMsg As Microsoft.Office.Interop.Outlook._MailItem
            oMsg = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)


            oMsg.Subject = Subject
            oMsg.Body = Message
            oMsg.To = MailTO

            'Dim sAttaSource As String = "C:\Temp\Hello.txt"
            ' TODO: Replace with attachment name
            'Dim sDisplayName As String = "Hello.txt"
            Dim i As Integer
            For i = 0 To FilesArray.Length - 1
                Dim sBodyLen As String = oMsg.Body.Length
                Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = oMsg.Attachments
                Dim oAttach As Microsoft.Office.Interop.Outlook.Attachment
                Dim name As String = AttachmentName & i
                Dim Att As String = FilesArray(i)
                oAttach = oAttachs.Add(Att, , sBodyLen + i + 1, name)

            Next

            ' Send

            oMsg.Send()

            ' Clean up
            oApp = Nothing
            oMsg = Nothing
            'oAttach = Nothing
            'oAttachs = Nothing
        Catch ex As System.Exception
            Utils.ShowException(ex)
        End Try

    End Sub
    Friend Sub SendEmail_2()
        'create the mail message
        Dim mail As New System.Net.Mail.MailMessage()

        'set the addresses
        mail.From = New System.Net.Mail.MailAddress("savvaschr@nodalsoft.com.cy")
        mail.To.Add("savvaschr@nodalsoft.com.cy")

        'set the content
        mail.Subject = "This is an email"
        mail.Body = "this is a sample body"

        'send the message
        Dim smtp As New System.Net.Mail.SmtpClient("10.0.0.130")
        smtp.Send(mail)
    End Sub

End Module



