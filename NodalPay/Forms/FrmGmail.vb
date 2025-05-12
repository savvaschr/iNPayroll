Public Class FrmGmail

    Private Sub FrmGmail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Global1.gmailaccount = Me.txtGmailAccount.Text
        Global1.gmailpassword = Me.txtGmailPassword.Text
    End Sub

    Private Sub FrmGmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Ds As DataSet
        Global1.PARAM_SMTPEmailHost = ""
        Dim EmailAccount As String
        Ds = Global1.Business.GetParameter("Payslip", "GmailAccount")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtGmailAccount.Text = Par.Value1
        Else
            Me.txtGmailAccount.Text = ""
        End If

        Ds = Global1.Business.GetParameter("Payslip", "SMTPUser")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_SMTPUser = Par.Value1
        Else
            Global1.PARAM_SMTPUser = EmailAccount
        End If

        Ds = Global1.Business.GetParameter("Payslip", "SMTPHost")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_SMTPEmailHost = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Payslip", "SMTPPort")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_SMTPPort = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Payslip", "SMTPSSL")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_SMTPSSLEnabled = True
            Else
                Global1.PARAM_SMTPSSLEnabled = False
            End If
        End If


    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Me.Close()
    End Sub

   
End Class