Imports System.Security.Authentication
Imports System.Net
Public Class FrmShowArchivePayroll
    Public Emp As New cPrMsEmployees
    Public CurrPeriod As cPrMsPeriodCodes
    Public CalledBy As FrmPrTxCalculatePayroll
    Public CallBy As Integer = 0
    Dim ds As DataSet

    Const _Tls12 As SslProtocols = DirectCast(&HC00, SslProtocols)
    Const Tls12 As SecurityProtocolType = DirectCast(_Tls12, SecurityProtocolType)


    Private Sub FrmShowArchivePayroll_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CallBy = 1 Then
            LoadEmployeePastTransactionsAllYears()
            Me.Print.Visible = True
            Me.Export.Visible = True
            Me.BtnEmail.Visible = True
        Else
            LoadEmployeePastTransactions()
        End If

        Dim DsParam As DataSet
        DsParam = Global1.Business.GetParameter("Payslip", "ApprovedBy")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            Global1.PARAM_Payslip_ApprovedBy = Par.Value1
        Else
            Global1.PARAM_Payslip_ApprovedBy = ""
        End If

        DsParam = Global1.Business.GetParameter("Payslip", "PreparedBy")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            Global1.PARAM_Payslip_PreparedBy = Par.Value1
        Else
            Global1.PARAM_Payslip_PreparedBy = ""
        End If

        DsParam = Global1.Business.GetParameter("Payslip", "OnlyValues")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                GLBPayslipShowOnlyWithValue = True
            Else
                GLBPayslipShowOnlyWithValue = False
            End If
        Else
            GLBPayslipShowOnlyWithValue = False
        End If

        PARAM_ShowAnalysis3onPayslip = False
        DsParam = Global1.Business.GetParameter("Payslip", "Analysis3")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_ShowAnalysis3onPayslip = True
            End If
        End If

        Global1.PARAM_PayslipNameOn = False
        DsParam = Global1.Business.GetParameter("Payslip", "NameOnfile")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_PayslipNameOn = True
            End If
        End If

        Global1.PARAM_AddBIKOnEarnings = False
        DsParam = Global1.Business.GetParameter("Payslip", "AddBIK")
        If CheckDataSet(DsParam) Then
            Dim Par As New cPrSsParameters(DsParam.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_AddBIKOnEarnings = True
            End If
        End If



        CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                DG1.Enabled = False
            End If
        End If

    End Sub
    Private Sub LoadEmployeePastTransactionsAllYears()

        ds = Global1.Business.GetAllTrxnHeadersOfEmployee(Emp.Code)
        Me.DG1.DataSource = ds.Tables(0)

    End Sub
    Private Sub LoadEmployeePastTransactions()

        ds = Global1.Business.GetAllTrxnHeaders(Emp, CurrPeriod)
        Me.DG1.DataSource = ds.Tables(0)

    End Sub

    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        If CallBy = 1 Then
            If CheckDataSet(ds) Then
                Dim i As Integer
                Dim id As Integer
                Dim PeriodCode As String = ""
                Dim PeriodGroup As String = ""
                i = Me.DG1.CurrentRow.Index
                id = DbNullToInt(ds.Tables(0).Rows(i).Item(0))
                Dim TrxHdr As New cPrTxTrxnHeader(id)
                Dim Period As New cPrMsPeriodCodes(TrxHdr.PrdCod_Code, TrxHdr.PrdGrp_Code)
                CType(Me.Owner, frmPrMsEmployees).PrintPayslip(TrxHdr, Emp, Period, False, False, "C:\")
            End If
        Else
            If CheckDataSet(ds) Then
                Dim i As Integer
                Dim id As Integer
                Dim PeriodCode As String = ""
                Dim PeriodGroup As String = ""

                i = Me.DG1.CurrentRow.Index
                id = DbNullToInt(ds.Tables(0).Rows(i).Item(0))
                Dim TrxHdr As New cPrTxTrxnHeader(id)
                Dim Period As New cPrMsPeriodCodes(TrxHdr.PrdCod_Code, TrxHdr.PrdGrp_Code)

                Dim F As New FrmPrTxCalculatePayroll
                F.Initializeme("< >")
                F.GLBEmployee = Emp
                F.MakeAllControlsReadOnly()
                F.txtEmpCode.Text = Emp.Code
                F.txtEmpFullName.Text = Emp.FullName
                F.txtNetSalary.Text = Format(TrxHdr.NetSalary, "0.00")
                F.txtTotalEarnings.Text = Format(TrxHdr.TotalErnPeriod, "0.00")
                F.txtTotalDeductions.Text = Format(TrxHdr.TotalDedPeriod, "0.00")
                F.txtTotalContributions.Text = Format(TrxHdr.TotalConPeriod, "0.00")
                F.GLBCurrentPeriod = Period
                F.LoadedFromArchive = True

                'F.E_Final = CType(Me.CalledBy, FrmPrTxCalculatePayroll).E_Final
                'F.D_Final = CType(Me.CalledBy, FrmPrTxCalculatePayroll).D_Final
                'F.C_Final = CType(Me.CalledBy, FrmPrTxCalculatePayroll).C_Final

                'F.Ern = CType(Me.CalledBy, FrmPrTxCalculatePayroll).Ern
                'F.Ded = CType(Me.CalledBy, FrmPrTxCalculatePayroll).Ded
                'F.Con = CType(Me.CalledBy, FrmPrTxCalculatePayroll).Con

                F.LoadCalculatedOrPosted(TrxHdr, Period)

                F.Show()
                Me.Close()
            End If
        End If

    End Sub





    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print.Click
        If CheckDataSet(ds) Then

            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(7)) = "1" Then
                    Dim id As Integer
                    Dim PeriodCode As String = ""
                    Dim PeriodGroup As String = ""
                    id = DbNullToInt(ds.Tables(0).Rows(i).Item(0))
                    Dim TrxHdr As New cPrTxTrxnHeader(id)
                    Dim Period As New cPrMsPeriodCodes(TrxHdr.PrdCod_Code, TrxHdr.PrdGrp_Code)
                    CType(Me.Owner, frmPrMsEmployees).PrintPayslip(TrxHdr, Emp, Period, True, False, "C:\")
                End If
            Next
        End If
    End Sub

    Private Sub Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Export.Click
        If CheckDataSet(ds) Then

            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            Dim i As Integer

            Dim PayslipDir As String
            Dim ds1 As DataSet
            ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")
            If CheckDataSet(ds1) Then
                Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
                PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
            Else
                PayslipDir = "C:\"
            End If
            Dim Export1 As Boolean = False
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(7)) = "1" Then
                    Dim id As Integer
                    Dim PeriodCode As String = ""
                    Dim PeriodGroup As String = ""
                    id = DbNullToInt(ds.Tables(0).Rows(i).Item(0))
                    Dim TrxHdr As New cPrTxTrxnHeader(id)
                    Dim Period As New cPrMsPeriodCodes(TrxHdr.PrdCod_Code, TrxHdr.PrdGrp_Code)
                    CType(Me.Owner, frmPrMsEmployees).PrintPayslip(TrxHdr, Emp, Period, False, True, PayslipDir)
                    Export1 = True
                End If
            Next
            If Export1 Then
                MsgBox("Selected Payslips are exported in " & PayslipDir)
            Else
                MsgBox("Please Select Payslips for Export !")
            End If
        Else
            MsgBox("Please select Payslips first", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Email1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Email1.Click
        EmailPayslips(1)
    End Sub

    Private Sub Gmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gmail.Click
        EmailPayslips(2)
    End Sub

    Private Sub Email365_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Email365.Click
        EmailPayslips(3)
    End Sub

    Private Sub EmailSMTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailSMTP.Click
        EmailPayslips(4)
    End Sub
    Private Sub EmailPayslips(ByVal Method As Integer)
        Dim Ans As New MsgBoxResult
        Dim UseEncryption As Boolean = False
        Ans = MsgBox("Send Emails using Employee Password if exist?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            UseEncryption = True
        End If

        If CheckDataSet(ds) Then

            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            Dim PayslipFileName As String
            PayslipFileName = Emp.Code

            If Global1.PARAM_PayslipNameOn Then
                PayslipFileName = Emp.Code & "_" & Emp.FullName
            End If

            Dim i As Integer
            Dim FilesArray() As String
            Dim PayslipDir As String
            Dim ds1 As DataSet
            ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")
            If CheckDataSet(ds1) Then
                Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
                PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)

            Else
                PayslipDir = "C:\"
            End If
            Dim c As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(7)) = "1" Then
                    c = c + 1
                End If
            Next
            ReDim FilesArray(c - 1)
            c = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(7)) = "1" Then
                    Dim id As Integer
                    Dim PeriodCode As String = ""
                    Dim PeriodGroup As String = ""
                    id = DbNullToInt(ds.Tables(0).Rows(i).Item(0))
                    Dim TrxHdr As New cPrTxTrxnHeader(id)
                    Dim Period As New cPrMsPeriodCodes(TrxHdr.PrdCod_Code, TrxHdr.PrdGrp_Code)
                    Dim TempUseEncryption As Boolean = False
                    If UseEncryption And Trim(Emp.Password) <> "" Then
                        TempUseEncryption = True
                    End If

                    CType(Me.Owner, frmPrMsEmployees).PrintPayslip(TrxHdr, Emp, Period, False, True, PayslipDir, TempUseEncryption)
                    Dim TFile As String = PayslipDir & PayslipFileName & "_" & Period.Code & "_t.pdf"
                    Dim NFile As String = PayslipDir & PayslipFileName & "_" & Period.Code & ".pdf"
                    If TempUseEncryption Then
                        Utils.EncryptPdf(TFile, NFile, Trim(Emp.Password))
                    Else

                    End If

                    FilesArray(c) = NFile
                    Try
                        System.IO.File.Delete(TFile)
                    Catch ex As Exception

                    End Try
                    c = c + 1
                End If
            Next

            Dim CompanyDescription As String


            Select Case Method

                Case 1
                    EmailFile(FilesArray, Emp, CompanyDescription)
                Case 2
                    Dim F As New FrmGmail
                    F.ShowDialog()
                    GEmailFile(FilesArray, Emp, CompanyDescription)
                Case 3
                    Dim F As New FrmGmail
                    F.ShowDialog()
                    Me.Send365Email(FilesArray, Emp, CompanyDescription)
                Case 4
                    Dim F As New FrmGmail
                    F.ShowDialog()
                    Me.Send_SMTP_EmailFile(FilesArray, Emp, CompanyDescription, Global1.PARAM_SMTPEmailHost)
            End Select
            Try
                For i = 0 To FilesArray.Length - 1
                    System.IO.File.Delete(FilesArray(i))
                Next
            Catch ex As Exception

            End Try


            MsgBox("Selected Payslips are emailed ")
        Else
            MsgBox("Please select Payslips first", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub EmailFile(ByVal Filesarray() As String, ByVal Employee As cPrMsEmployees, ByVal CompanyDescription As String)

        Dim EmailSubject As String
        Dim Msg As String
        Dim EmployeeEmail As String
        If Me.CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If

        EmailSubject = "Requested Payslips "
        Msg = "Dear " & Employee.FullName & " Find attached the requested Payslip(s) "



        If EmployeeEmail <> "" Then
            Email.SendEmail2(EmployeeEmail, EmailSubject, Msg, Filesarray, "Payslips ")
        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If


    End Sub

    Private Sub GEmailFile(ByVal FilesArray() As String, ByVal Employee As cPrMsEmployees, ByVal CompanyDescription As String)

        Dim EmployeeEmail As String
        If Me.CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If

        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String





            EmailSubject = "Requested Payslips "
            Msg = "Dear " & Employee.FullName & " ,Please find attached therequested Payslip(s) "

            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True

            Dim mail As New System.Net.Mail.MailMessage()

            Try
                mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)



                mail.To.Add(EmployeeEmail)
                If Param_PayslipCC <> "" Then
                    mail.CC.Add(Global1.Param_PayslipCC)
                End If

                mail.Subject = EmailSubject
                mail.Body = Msg
                Dim i As Integer
                For i = 0 To FilesArray.Length - 1
                    mail.Attachments.Add(New System.Net.Mail.Attachment(FilesArray(i)))
                Next

                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Public Sub Send365Email(ByVal FilesArray() As String, ByVal Employee As cPrMsEmployees, ByVal CompanyDescription As String)
        Try
            Dim EmployeeEmail As String
            If Me.CBUseEmail2.CheckState = CheckState.Checked Then
                EmployeeEmail = Employee.Email2
            Else
                EmployeeEmail = Employee.Email
            End If

            If EmployeeEmail <> "" Then
                Dim EmailSubject As String
                Dim Msg As String
                EmailSubject = "Requested Payslips "
                Msg = "Dear " & Employee.FullName & " ,Please find attached the requested Payslip(s) "

                Dim mailClient As New System.Net.Mail.SmtpClient("smtp.office365.com")
                '  Dim mailClient2 As New System.Net


                mailClient.Port = Global1.PARAM_SMTPPort
                mailClient.EnableSsl = Global1.PARAM_SMTPSSLEnabled

                '   mailClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network



                ' mailClient.UseDefaultCredentials = False
                'Dim cred As New System.Net.NetworkCredential("payroll@cobalt.aero", "cobalt123.")
                Dim cred As New System.Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword)

                mailClient.Credentials = cred

                Dim message As New System.Net.Mail.MailMessage()


                'This DOES work  
                message.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "Payroll")

                message.[To].Add(EmployeeEmail)
                message.Subject = EmailSubject
                message.Body = Msg
                Dim i As Integer
                For i = 0 To FilesArray.Length - 1
                    message.Attachments.Add(New System.Net.Mail.Attachment(FilesArray(i)))
                Next

                ' System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Ssl3

                mailClient.Send(message)
            Else
                MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
        GC.Collect()
    End Sub


    Private Sub Send_SMTP_EmailFile(ByVal FilesArray() As String, ByVal Employee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal Host As String)
        Dim EmployeeEmail As String
        If Me.CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If

        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = "Requested Payslips "
            Msg = "Dear " & Employee.FullName & " ,Please find attached the requested Payslip(s) "

            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(Global1.PARAM_SMTPUser, Global1.GmailPassword)

            SmtpServer.Port = Global1.PARAM_SMTPPort
            SmtpServer.Host = Host
            SmtpServer.EnableSsl = Global1.PARAM_SMTPSSLEnabled

            Dim mail As New System.Net.Mail.MailMessage()

            Try
                mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)



                mail.To.Add(EmployeeEmail)

                mail.Subject = EmailSubject
                mail.Body = Msg
                Dim i As Integer
                For i = 0 To FilesArray.Length - 1
                    mail.Attachments.Add(New System.Net.Mail.Attachment(FilesArray(i)))
                Next
                ServicePointManager.SecurityProtocol = Tls12


                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub



    Private Sub DG1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.Validated
        DG1.Update()
    End Sub


End Class