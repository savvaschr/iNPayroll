Imports System.Windows.Forms
Imports System.Threading
Imports System.Text
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO


'Imports Spire.Pdf
'Imports Spire.Pdf.Security



'Dim plainText As String = InputBox("Enter the plain text:")


Public Class FrmMain
    Dim DeepBlueCount As Integer
    Dim OneNetCount As Integer
    Dim BNcount As Integer
    Dim BPCount As Integer
    Dim NLCount As Integer
    Dim KSCount As Integer
    Public GLBLoadingFromExcel_TemGroup As String
    Public GLBProceedWithExcel_Loading As Boolean = False

    Public GLBProceedWithExcel_JIRA As Boolean = False
    Public GLBLoadingFromExcel_JIRAExcelFileToOpen As String

    Public GLBLoadingFromExcel_CompanyBankCode As String
    Public GLBLoadingFromExcel_CompanyIBAN As String
    Public GLBLoadingFromExcel_PayslipReport As String
    Public GLBLoadingFromExcel_ExcelFileToOpen As String
    Public GLBLoadingFromExcel_SIRateCode As String
    Public GLBLoadingFromExcel_loadaddress As Boolean

    Public GLBLoadingFromExcel_FirstRow As Integer

    Public GLBLoadingFromExcelSalaries_EffDate As Date

    Public SAL_FirstLine As Integer
    Public SAL_EmployeeColumnNo As Integer
    Public SAL_SalaryColumnNumber As Integer
    Public SAL_E1Code As String
    Public SAL_E1Number As Integer
    Public SAL_E2Code As String
    Public SAL_E2Number As Integer

    Public SAL_File As String
    Public SAL_Proceed As Boolean

    Public BetaBizFile As String
    Public ChangeBankAndIBANFile As String
    Public CBI_Code_Col As Integer
    Public CBI_BenName_Col As Integer
    Public CBI_BankCode_Col As Integer
    Public CBI_IBAN_Col As Integer
    Public CBI_FirstLine As Integer

    Public LeaversDateEmailFile As String
    Public dl_FirstLine As Integer
    Public dl_Code_Col As Integer
    Public dl_email_Col As Integer
    Public dl_leavedate_Col As Integer
    Public dl_TermReason_Col As Integer






#Region "Automatic MDIForm Code"


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuExit.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0
#End Region

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ToolStripStatusLabel.Text = "Status: Not Connected"
        InitializeMe()
        ArrangeMenus()
        Me.LoadDatabases()
        Dim F As New FrmLogin
        F.AutomaticLogin = False
        F.MdiParent = Me
        ' ChangeColor()
        F.Show()


    End Sub
    Private Sub ChangeColor()
        Dim ctl As Control
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                'ctlMDI.BackColor = Me.BackColor
                ctlMDI.BackColor = Color.LightBlue

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
    End Sub
    Public Sub ArrangeMenus()
        Dim Flag As Boolean
        Dim Flag2 As Boolean = True

        If Global1.IsConnected And Global1.IsUserEnabled Then
            Flag = True
        Else
            Flag = False
        End If

        If Flag Then
            Me.ToolStripStatusLabel.Text = "Status: Connected to Database - " & Global1.DbaseName
        Else
            Me.ToolStripStatusLabel.Text = "Status: Not Connected"
        End If

        Me.MnuLogin.Enabled = Not Flag
        Me.MnuLogout.Enabled = Flag
        Me.MnuTimeAttendance.Enabled = Flag
        Me.mnuChangeMyPass.Enabled = Flag

        If Global1.IsConnected And Global1.UserRole = Roles.TimeAttetance Then
            Me.MnuTimeAttendance.Enabled = True
            Flag = False
            Flag2 = False
        End If

        Me.MnuSystem.Enabled = Flag
        Me.MnuAdministration.Enabled = Flag
        Me.MnuPayroll.Enabled = Flag
        Me.MnuReports.Enabled = Flag
        Me.MnuTemplate.Enabled = Flag
        Me.MnuPeriodMenu.Enabled = Flag
        Me.MnuDoPayroll.Enabled = Flag
        Me.MnuMaintenance.Enabled = Flag
        Me.MnuApplicationSetup.Enabled = Flag
        Me.mnuImportFromExcelNew.Enabled = Flag

        Me.TSUrlJcc.Enabled = Flag
        Me.TSUrltaxportal.Enabled = Flag
        Me.TSUrlSI.Enabled = Flag
        Me.TSUrlTaxis.Enabled = Flag

        'Me.MnuAdminUtils.Visible = False
        Me.MnuAdminUtils.Visible = False
        Me.mnuSystemUpgrade.Visible = True
        Me.MnuLoadFileX.Visible = False

        Me.MnuAdminUtils.Enabled = False
        Me.mnuSystemUpgrade.Enabled = True
        Me.MnuLoadFileX.Enabled = False


        Me.MnuAdminUtils.Visible = False
        Me.MnuAdminUtils.Enabled = False

        Me.mnuSystemUpgrade.Visible = True
        Me.mnuSystemUpgrade.Enabled = True

        Me.mnuTest1.Visible = False

        If Global1.IsConnected Then
            Dim U As New cAaSsUsers(Global1.GLBUserId)
            If Not U Is Nothing Then
                If U.IsSA = "Y" Then
                    Me.MnuAdminUtils.Visible = True
                    Me.MnuAdminUtils.Enabled = True
                    Me.MnuLoadFileX.Visible = True
                    Me.MnuLoadFileX.Enabled = True
                    Me.mnuSystemUpgrade.Visible = True
                    Me.mnuSystemUpgrade.Enabled = True
                    Me.mnuTest1.Visible = True
                End If
            End If
            '   Me.mnuSystemUpgrade.Visible = True
            '  Me.mnuSystemUpgrade.Enabled = True
        End If
        '''''''''''''''''''''''''''''''''''''
        '     Me.MnuAdminUtils.Visible = True
        '     Me.MnuAdminUtils.Enabled = True
        ''''''''''''''''''''''''''''''''''''''

        Me.MnuSystem.Visible = Flag2
        Me.MnuAdministration.Visible = Flag2
        Me.MnuPayroll.Visible = Flag2
        Me.MnuReports.Visible = Flag2
        Me.MnuTemplate.Visible = Flag2
        Me.MnuPeriodMenu.Visible = Flag2
        Me.MnuDoPayroll.Visible = Flag2
        Me.MnuMaintenance.Visible = Flag2
        Me.MnuApplicationSetup.Visible = Flag2


        Me.mnuExelsys.Enabled = False
        If Flag Then
            CheckUserPermitions()
            LoadParameters()
            Me.mnuExelsys.Enabled = Global1.PARAM_HCMIsenabled
        End If

    End Sub
    Private Sub LoadParameters()
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("HCM", "IsEnabled")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_HCMIsenabled = True

            Else
                Global1.PARAM_HCMIsenabled = False
            End If
        Else
            Global1.PARAM_AnnualLeaveAllocation = False
        End If

        Ds = Global1.Business.GetParameter("HCM", "DBPath")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_HCMdatabasePath = Par.Value1
        Else
            Global1.PARAM_HCMdatabasePath = ""
        End If


        Ds = Global1.Business.GetParameter("HCM", "PayslipsPath")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_HCMPayslipsUploadPath = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            Global1.PARAM_HCMPayslipsUploadPath = ""
        End If

        Ds = Global1.Business.GetParameter("HCM", "TempGroup")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_HCMTempGroup = Par.Value1
        Else
            Global1.PARAM_HCMTempGroup = ""
        End If

        Ds = Global1.Business.GetParameter("Payslip", "ALMonthBal")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_MonthlyALBalance = True
            Else
                Global1.PARAM_MonthlyALBalance = False
            End If
        Else
            Global1.PARAM_MonthlyALBalance = False
        End If

        Ds = Global1.Business.GetParameter("System", "DefRowCount")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_DefRowCount = Par.Value1
        Else

            Global1.PARAM_DefRowCount = 3
        End If

        Ds = Global1.Business.GetParameter("System", "AnalysisSortByDesc")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_AnalysisSortByDescription = True
            Else
                Global1.PARAM_AnalysisSortByDescription = False
            End If
        End If


        Ds = Global1.Business.GetMaximumYearOfPeriodGroups
        If CheckDataSet(Ds) Then
            Global1.GLBCurrentYear = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
        Else
            Global1.GLBCurrentYear = Now.Date.Year
        End If

        Ds = Global1.Business.GetParameter("Payslip", "AllMonths")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_GLBAllMonthsPayslip = True
            Else
                Global1.PARAM_GLBAllMonthsPayslip = False
            End If
        End If


        Ds = Global1.Business.GetParameter("YearPayslip", "SIEDCCodes")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_SI_EDCCodes_ForReporting = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("YearPayslip", "TAXEDCCodes")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_TAX_EDCCodes_ForReporting = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("YearPayslip", "TAXCode")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_TAX_Code_ForReporting = Par.Value1
        End If

        PARAM_NonCompanyCostEarnings = ""
        Ds = Global1.Business.GetParameter("System", "NoComCost")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_NonCompanyCostEarnings = Par.Value1
        End If

        Param_Exelsys = False
        Ds = Global1.Business.GetParameter("System", "Exelsys")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Param_Exelsys = True
            End If
        End If



        ReadDiscountLabels()
        ReadDedtorsCreditorsInterfaceParameters()

    End Sub
    Private Sub ReadDedtorsCreditorsInterfaceParameters()
        GLBDedtorsInterface = False
        GLBDedtorsControl = ""
        GLBCreditorsInterface = False
        GLBCreditorsControl = ""
        GLBLoanDedCode = ""
        GLBRentDedCode = ""
        GLBSavingsDedCode = ""

        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("DC", "Dedtors")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                GLBDedtorsInterface = True
                Ds = Global1.Business.GetParameter("DC", "DedControl")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBDedtorsControl = Par.Value1
                Else
                    MsgBox("Please Define 'DC','DedControl' Parameter", MsgBoxStyle.Exclamation)
                End If
                Ds = Global1.Business.GetParameter("DC", "LoanDed")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBLoanDedCode = Par.Value1
                Else
                    MsgBox("Please Define 'DC','LoanDed' Parameter", MsgBoxStyle.Exclamation)
                End If
                Ds = Global1.Business.GetParameter("DC", "RentDed")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBRentDedCode = Par.Value1
                Else
                    MsgBox("Please Define 'DC','RentDed' Parameter", MsgBoxStyle.Exclamation)
                End If
            End If
        End If

        Ds = Global1.Business.GetParameter("DC", "Creditors")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                GLBCreditorsInterface = True
                Ds = Global1.Business.GetParameter("DC", "CreControl")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBCreditorsControl = Par.Value1
                Else
                    MsgBox("Please Define 'DC','CreControl' Parameter", MsgBoxStyle.Exclamation)
                End If

                Ds = Global1.Business.GetParameter("DC", "SavDed")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBSavingsDedCode = Par.Value1
                Else
                    MsgBox("Please Define 'DC','SavDed' Parameter", MsgBoxStyle.Exclamation)
                End If

                Ds = Global1.Business.GetParameter("DC", "TempGroup")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBTemplateforDCInterface = Par.Value1
                Else
                    MsgBox("Please Define 'DC','TempGroup' Parameter", MsgBoxStyle.Exclamation)
                End If

                Ds = Global1.Business.GetParameter("DC", "TempGroup2")
                If CheckDataSet(Ds) Then
                    Par = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBTemplateforDCInterface2 = Par.Value1
                Else
                    MsgBox("Please Define 'DC','TempGroup2' Parameter", MsgBoxStyle.Exclamation)
                End If

            End If
        End If

        GLBGenerateFromMKT_To_IMK = False
        Ds = Global1.Business.GetParameter("MKT", "MKTtoIMK")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                GLBGenerateFromMKT_To_IMK = True
                Ds = Global1.Business.GetParameter("MKT", "MKTTCode")
                If CheckDataSet(Ds) Then
                    Dim Par2 As New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBGenerateFromMKT_To_IMK_TemplateCode = Par2.Value1
                End If
                Ds = Global1.Business.GetParameter("MKT", "MKTICode")
                If CheckDataSet(Ds) Then
                    Dim Par3 As New cPrSsParameters(Ds.Tables(0).Rows(0))
                    GLBMKTToMKTInterfaceCode = Par3.Value1
                End If
            End If
        End If

    End Sub
    Private Sub ReadDiscountLabels()
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("Dis", "Discount1")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel1 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel2 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel3 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount4")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel4 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount5")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel5 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount6")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel6 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount7")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel7 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount8")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel8 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount9")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel9 = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Dis", "Discount10")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_DiscountLabel10 = Par.Value1
        End If
    End Sub



    Private Sub CheckUserPermitions()
        Dim ds As DataSet
        ds = Global1.Business.GetUserPermitions("", Global1.GLBUserCode, False)
        If CheckDataSet(ds) Then
            Dim i As Integer
            Dim P As New cPrSsUserPermitions
            Dim F As Boolean = False
            For i = 0 To ds.Tables(0).Rows.Count - 1
                P = New cPrSsUserPermitions(ds.Tables(0).Rows(i))
                If P.FullPermission = 1 Then
                    F = True
                ElseIf P.ReadonlyPermission = 1 Then
                    F = True
                ElseIf P.NoPermission = 1 Then
                    F = False
                End If
                Select Case P.Entity
                    Case "ApplicationSetup"
                        MnuApplicationSetup.Enabled = F
                    Case "Maintenance"
                        EDCToolStripMenuItem.Enabled = F
                        MnuTemplate.Enabled = F
                        MnuEDCInterfaceTemplate.Enabled = F
                        MnuPeriodMenu.Enabled = F
                        AnalysisToolStripMenuItem1.Enabled = F
                        MnPrAnBanks.Enabled = F
                        MnuPrAnUnions.Enabled = F
                    Case "Employees"
                        EmployeeCardToolStripMenuItem.Enabled = F
                    Case "Administration"
                        Me.MnuCompany.Enabled = F
                    Case "Payroll"
                        MnuPayroll.Enabled = F
                        'If Global1.PARAM_systemIsLocked Then
                        '    MnuPayroll.Enabled = False
                        'End If
                    Case "System"
                        MnuSystem.Enabled = F
                    Case "Reports"
                        MnuReports.Enabled = F
                    Case "PayrollAnalysis"
                        MnuPayrollAnalysis.Enabled = F
                    Case "SI Contributions"
                        MnuRptSIContributions.Enabled = F
                    Case "IR Reports"
                        MnuRptIR63A.Enabled = F
                End Select
            Next
        End If
    End Sub
    Private Sub InitializeMe()
        Dim Args() As String
        Dim i As Integer
        Dim Delimiter As String = "|"


        Args = ParseLineArgs(GetCommandLineArgs())
        If Args.Length < 1 Then
            Throw New System.Exception("Command line Arguments Missing.")
        End If

        If Args(0) = "" Then
            Throw New System.Exception("Database & Server names are undefined.")
        End If

        Dim SDBArray() As String = Split(Args(0), Delimiter)
        Dim TwoDimSDBArray(SDBArray.Length - 1, 1) As String
        Dim SDBDelimiter As String = ";"
        Dim pos As Integer = 0

        For i = 0 To SDBArray.Length - 1
            If InStr(SDBArray(i), SDBDelimiter) = 0 Then
                MsgBox("Delimiter ';' betweeen Server And DataBase is missing." &
                " Check Command Line Arguments")
            Else
                pos = InStr(SDBArray(i), SDBDelimiter)
                TwoDimSDBArray(i, 0) = SDBArray(i).Substring(0, pos - 1)
                If TwoDimSDBArray(i, 0) = "" Then
                    MsgBox("Server is missing", MsgBoxStyle.Critical, "Error""")
                End If
                TwoDimSDBArray(i, 1) = SDBArray(i).Substring(pos)
                If TwoDimSDBArray(i, 1) = "" Then
                    MsgBox("Database Name missing", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Next
        ReDim Global1.ServerDatabase(SDBArray.Length - 1, 1)
        Global1.ServerDatabase = TwoDimSDBArray

        Global1.DbaseServerName = Global1.ServerDatabase(0, 0)
        Global1.DbaseName = Global1.ServerDatabase(0, 1)

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Global1.UserRole = Global1.Roles.NoRole
    End Sub

    Private Function ParseLineArgs(ByVal Args() As String) As String()
        Dim myArgs(2) As String
        Dim i As Integer
        myArgs(2) = "False"
        For i = 0 To Args.Length - 1
            If Args(i).ToLower.StartsWith("/connection=") Then
                myArgs(0) = Args(i).Substring(12)
            End If
        Next
        Return myArgs
    End Function


    Private Sub MnuLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLogin.Click
        Dim F As New FrmLogin
        F.MdiParent = Me
        F.Top = 0
        F.Left = 0
        F.Show()
    End Sub
    Private Sub MnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLogout.Click
        Global1.IsConnected = False
        Global1.IsUserEnabled = False
        Global1.UserRole = Roles.NoRole
        Global1.UserName = ""
        Global1.Business = Nothing
        ArrangeMenus()
    End Sub

#Region "AaSs"
    Private Sub MnuAaSsParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAaSsParameters.Click
        Dim F As New frmAaSsParameters
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuAaSSPlaceHolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New frmAaSsPlaceHolder
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuAaSsUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAaSsUsers.Click
        Dim F As New frmAaSsUsers
        F.MdiParent = Me
        F.Show()
    End Sub
#End Region
#Region "AdAn & AdMs"



    Private Sub MnuAdAnCountries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdAnCountries.Click
        Dim F As New frmAdAnCountries
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuAdMsCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdMsCurrency.Click
        Dim F As New frmAdMsCurrency
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuAdMsCurrencyRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdMsCurrencyRates.Click
        Dim F As New frmAdMsCurrencyRates
        F.MdiParent = Me
        F.Show()
    End Sub
#End Region
#Region "PrAn"
    Private Sub MnPrAnBanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnPrAnBanks.Click
        Dim F As New frmPrAnBanks
        F.MdiParent = Me
        F.Show()

    End Sub

    Private Sub MnuPrAnEmployeeAnalysis1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeAnalysis1.Click
        Dim F As New frmPrAnEmployeeAnalysis1
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeeAnalysis2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeAnalysis2.Click
        Dim F As New frmPrAnEmployeeAnalysis2
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeeAnalysis3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeAnalysis3.Click
        Dim F As New frmPrAnEmployeeAnalysis3
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeeAnalysis4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeAnalysis4.Click
        Dim F As New frmPrAnEmployeeAnalysis4
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeeAnalysis5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeAnalysis5.Click
        Dim F As New frmPrAnEmployeeAnalysis5
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeeCommunity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeeCommunity.Click
        Dim F As New frmPrAnEmployeeCommunity
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmployeePositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmployeePositions.Click
        Dim F As New frmPrAnEmployeePositions
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnMarritalStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnMarritalStatus.Click
        Dim F As New frmPrAnMarritalStatus
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnEmploymentStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnEmploymentStatus.Click
        Dim F As New frmPrAnEmploymentStatus
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnPaymentMethods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnPaymentMethods.Click
        Dim F As New frmPrAnPaymentMethods
        F.MdiParent = Me
        F.Show()

    End Sub

    Private Sub MnuPrAnSocialInsuranceCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnSocialInsuranceCategories.Click
        Dim F As New frmPrAnSocialInsCategories
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnTaxCardType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnTaxCardType.Click
        Dim F As New frmPrAnTaxCardType
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrAnUnions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrAnUnions.Click
        Dim F As New frmPrAnUnions
        F.MdiParent = Me
        F.Show()
    End Sub
#End Region
#Region "PrMs"

    Private Sub MnuPrMsEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeCardToolStripMenuItem.Click
        Dim F As New frmPrMsEmployees
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrMsContributionCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrMsContributionCodes.Click
        Dim F As New frmPrMsContributionCodes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrMsDeductionCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrMsDeductionCodes.Click
        Dim F As New frmPrMsDeductionCodes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrMsEarningCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrMsEarningCodes.Click
        Dim F As New frmPrMsEarningCodes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrMsPeriodGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrMsPeriodGroups.Click
        Dim F As New frmPrMsPeriodGroups
        F.MdiParent = Me
        F.Show()
    End Sub



    Private Sub MnuPrMsTemplateGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrMsTemplateGroups.Click
        Dim F As New frmPrMsTemplateGroup
        F.MdiParent = Me
        F.Show()
    End Sub
#End Region
#Region "PrSs"
    Private Sub MnuPrSsContributionTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsContributionTypes.Click
        Dim F As New frmPrSsContributionTypes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsDeductionTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsDeductionTypes.Click
        Dim F As New frmPrSsDeductionTypes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsEarningTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsEarningTypes.Click
        Dim F As New frmPrSsEarningTypes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsEmployeeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsEmployeeStatus.Click
        Dim F As New frmPrSsEmployeeStatus
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsLeaveTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsLeaveTypes.Click
        Dim F As New frmPrSsLeaveTypes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsParameters.Click
        Dim F As New frmPrSsParameters
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsPaymentCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsPaymentCategory.Click
        Dim F As New frmPrSsPaymentCategory
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsPayrollTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsPayrollTypes.Click
        Dim F As New frmPrSsPayrollTypes
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsPayrollUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsPayrollUnits.Click
        Dim F As New frmPrSsPayrollUnits
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsSocialInsurancePeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsSocialInsurancePeriods.Click
        Dim F As New frmPrSsSocialInsPeriods
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPrSsTaxTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsTaxTable.Click
        Dim F As New frmPrSsTaxTable
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub MnuPrSsLimits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrSsLimits.Click
        Dim F As New frmPrSsLimits
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub MnuProvidentFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuProvidentFund.Click
        Dim F As New frmPrSsProvidentFund
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuMedicalFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMedicalFund.Click
        Dim F As New frmPrSsMedicalFund
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuSocialInsurance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSocialInsurance.Click
        Dim f As New frmPrSsSocialInsurance
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub MnuIndustrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuIndustrial.Click
        Dim f As New FrmPrSsIndustrial
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MnuUnemployment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUnemployment.Click
        Dim f As New FrmPrSsUnemployment
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MnuSocialCohesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSocialCohesion.Click
        Dim f As New FrmPrSsSocialCohesion
        f.MdiParent = Me
        f.Show()
    End Sub
#End Region
    Private Sub MnuTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuTemplate.Click
        Dim F As New FrmPrMsTemplateEDC
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub MnuEDCInterfaceTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEDCInterfaceTemplate.Click
        Dim F As New FrmEDCInterface
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPayrollCalculations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDoPayroll.Click
        Dim F As New FrmPayroll1
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New FrmPayroll1
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub Test2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New FrmPrTxCalculatePayroll
        f.MdiParent = Me
        f.Show()
    End Sub

#Region "Reports"


    Private Sub MnuRptEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim ds As DataSet
        ''ds = Global1.Business.AG_GetAllPrMsEmployees()
        ''Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\NodalD630\My Documents\Visual Studio 2005\Projects\NodalPay\XML\xmlEmployeeList")

        'Me.Cursor = Cursors.Default

        'If CheckDataSet(ds) Then
        '    Utils.ShowReport("EmployeeList.rpt", ds, FrmReport, "", False)
        'Else
        '    MsgBox("No records found to print.", MsgBoxStyle.Information)
        'End If
    End Sub

    Private Sub MnuRptPayslip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor

        'Dim ds As DataSet
        'ds = Global1.Business.GetREPORT_Payslip
        ''Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\NodalD630\My Documents\Visual Studio 2005\Projects\NodalPay\XML\xmlPayslip")
        'Me.Cursor = Cursors.Default
        'If CheckDataSet(ds) Then
        '    Utils.ShowReport("Payslip.rpt", ds, FrmReport, "", False)
        'Else
        '    MsgBox("No records found to print.", MsgBoxStyle.Information)
        'End If
    End Sub
    Private Sub MnuRptSIContributions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRptSIContributions.Click
        Dim F As New FrmRptSIContributions
        F.MdiParent = Me
        F.Show()

    End Sub
    Private Sub MnuRptSIContributionsFILE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New FrmRptSIContributions
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuRptPayrollAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim ds As DataSet
        ' ds = Global1.Business.GetREPORT_Payrollanalysis


        'Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\NodalD630\My Documents\Visual Studio 2005\Projects\NodalPay\XML\xmlPayrollAnalysis")

        Me.Cursor = Cursors.Default

        If CheckDataSet(ds) Then
            Utils.ShowReport("PayrollAnalysis.rpt", ds, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If
    End Sub


#End Region

    Private Sub MnuCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCompany.Click
        Dim F As New FrmAdMsCompany
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuClosePeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuClosePeriod.Click
        Dim F As New FrmPrTxClosePeriod
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPeriods.Click
        Dim F As New FrmPrMsPeriods
        F.MdiParent = Me
        F.Show()
    End Sub


#Region "CALLS Receivables/Payables"

    '    Case "RP_RC_Invoices"
    '        Call_Sales()
    '    Case "RP_RC_Receipts"
    '        Me.Call_Receipts()
    '    Case "RP_RC_Adjustments"
    '        Me.Call_CustomerADJ()
    '    Case "RP_RC_Allocations"
    '        Me.Call_SalesAllocation()
    '    Case "RP_PA_Invoices"
    '        Me.Call_Purchases()
    '    Case "RP_PA_Payments"
    '        Me.Call_Payments()
    '    Case "RP_PA_Asjustments"
    '        Me.Call_SupplierADJ()
    '    Case "RP_PA_Allocations"
    '        Me.Call_PurchasesAllocation()

    Private Sub Call_Sales()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_SALES
        F.GlbTrxnTypeFactor = 1
        F.GLBDisableVAT = False
        F.GLBEnableAllocation = False
        F.Owner = Me
        F.Text = "Receivables - Invoices/Credit Notes"
        F.Show()
        F.BringToFront()
    End Sub
    Private Sub Call_Purchases()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_PURCHASES
        F.GlbTrxnTypeFactor = -1
        F.GLBDisableVAT = False
        F.GLBEnableAllocation = False
        F.Text = "Payables - Invoices/Credit Notes"
        F.Owner = Me
        F.Show()
    End Sub
    Private Sub Call_Receipts()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_RECEIPTS
        F.GlbTrxnTypeFactor = -1
        F.GLBDisableVAT = True
        F.GLBEnableAllocation = True
        F.GLBDisableOverAllDiscount = True
        F.Owner = Me
        F.Text = "Receivables - Receipts"
        F.Show()
    End Sub
    Private Sub Call_Payments()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_PAYMENTS
        F.GlbTrxnTypeFactor = 1
        F.GLBDisableVAT = True
        F.GLBEnableAllocation = True
        F.GLBDisableOverAllDiscount = True
        F.Text = "Payables - Payments"
        F.Owner = Me
        F.Show()
    End Sub
    Private Sub Call_SupplierADJ()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_SUPPLIER_ADJ
        F.GlbTrxnTypeFactor = 1
        F.GLBDisableVAT = True
        F.GLBEnableAllocation = True
        F.GLBDisableDiscounts = True
        F.GLBDisableDueDate = True
        F.Text = "Payables - Customer Adjustments"

        F.Owner = Me
        F.Show()
    End Sub

    Private Sub Call_CustomerADJ()
        Dim F As New FrmFiTrxnHeader
        F.GlbTrxnType = Global1.FI_TrxnType_CUSTOMER_ADJ
        F.GlbTrxnTypeFactor = 1
        F.GLBDisableVAT = True
        F.GLBEnableAllocation = True
        F.GLBDisableDiscounts = True
        F.GLBDisableDueDate = True
        F.Text = "Receivables - Supplier Adjustments"
        F.Owner = Me
        F.Show()
    End Sub
    Private Sub Call_SalesAllocation()
        Dim F As New FrmAllocation
        F.GlbTrxnType = Global1.FI_TrxnType_SALES
        F.Owner = Me
        F.Text = "Receivables - Allocations"
        F.Show()
        F.BringToFront()
    End Sub

    Private Sub Call_PurchasesAllocation()
        Dim F As New FrmAllocation
        F.GlbTrxnType = Global1.FI_TrxnType_PURCHASES
        F.Text = "Payables - Allocations"
        F.Owner = Me
        F.Show()
    End Sub

#End Region

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        Me.Call_Sales()
    End Sub

    Private Sub ReceiptsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptsToolStripMenuItem.Click
        Me.Call_Receipts()
    End Sub

    Private Sub CustomerADJToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerADJToolStripMenuItem.Click
        Me.Call_CustomerADJ()
    End Sub

    Private Sub AllocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllocationToolStripMenuItem.Click
        Me.Call_SalesAllocation()
    End Sub

    Private Sub InvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicesToolStripMenuItem.Click
        Me.Call_Purchases()
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        Me.Call_Payments()
    End Sub

    Private Sub AdjustmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentsToolStripMenuItem.Click
        Me.Call_SupplierADJ()
    End Sub

    Private Sub AllocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllocationsToolStripMenuItem.Click
        Me.Call_PurchasesAllocation()
    End Sub

    Private Sub mnuSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSchedule.Click

        Dim F As New FrmTATrxnLines
        F.MdiParent = Me
        F.MyMode = TaStatus.SCHEDULE
        F.Show()

    End Sub

    Private Sub MnuActuall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuActuall.Click
        Dim F As New FrmTATrxnLines
        F.MdiParent = Me
        F.MyMode = TaStatus.ACTUAL
        F.Show()

    End Sub


    Private Sub MnuLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLoadFile.Click
        Cursor = Cursors.WaitCursor
        LoadingFile("", "")
        Cursor = Cursors.Default
    End Sub
    Private Sub LoadingFile(ByVal FileDir As String, ByVal FileName As String)
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader

        FileDir = "Master\"
        Files = IO.Directory.GetFiles(FileDir)
        'Me.Label1.Text = "Loading File in Progress . . ."
        'Me.Label2.Text = "Start At: " & Format(Now, "dd-MM-yyyy hh:mm:ss")
        Me.PanelfileLoad.Visible = True
        'Me.PanelLoading.Refresh()
        Me.Refresh()

        For i = 0 To Files.Length - 1



            Me.Refresh()
            '  Me.PanelLoading.Refresh()
            FileName = Files(i)
            Global1.Business.BeginTransaction()
            counter = 0
            Try


                Dim Exx As New Exception
                Dim HeaderLine As String

                FileName = Files(i)
                Global1.FileName = FileName
                param_file = IO.File.OpenText(FileName)
                LoadedOK = False
                Line = param_file.ReadLine()
                Do While param_file.Peek <> -1
                    '         txtcounter.Text = counter
                    '         txtcounter.Refresh()
                    Me.Refresh()
                    counter = counter + 1
                    System.Windows.Forms.Application.DoEvents()
                    Line = param_file.ReadLine()
                    'Debug.WriteLine("1" & Line)
                    Line = Line.Replace("'", " ")
                    'Debug.WriteLine("2" & Line)
                    '  HeaderLine = Line.Substring(0, 3)

                    Load_Employee(Line)
                    'Load Companies DS for checking

                Loop
                Global1.Business.CommitTransaction()
                MsgBox("File is Succesfully Loaded", MsgBoxStyle.Information)
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Load File", MsgBoxStyle.Critical)

            End Try
        Next
        Me.PanelfileLoad.Visible = False
    End Sub
    Private Sub Load_EmployeeAnalysis1(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("|")
        Dim Code As String = Ar(1) 'Trim(Line.Substring(4, 2))
        Dim Desc As String = Ar(2) 'Trim(Line.Substring(7, 30))
        Dim DescShort As String = Ar(3) 'Trim(Line.Substring(7, 30))

        Dim An1 As New cPrAnEmployeeAnalysis1(Code)

        If An1.Code = "" Then
            'Add New
            With An1
                .Code = Code
                .DescriptionL = Desc
                .DescriptionS = DescShort
                .IsActive = "Y"
                .GLAnal1 = 0
                .GLAnal2 = 0
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                If Not An1.Save Then
                    MsgBox("Error Analysis1 ")
                    Throw Exx
                End If
            End With
        Else
            'Update if Diferent
            With An1
                .Code = Code
                .DescriptionL = Desc
                .DescriptionS = DescShort
                .IsActive = "Y"
                .GLAnal1 = 0
                .GLAnal2 = 0
                '.CreationDate = Now.Date
                .AmendDate = Now.Date
                If Not An1.Save Then
                    MsgBox("Error loading Analysis1 ")
                    Throw Exx
                End If
            End With
        End If
    End Sub
    Private Sub Load_Employee(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")

        Dim a00 As String = Ar(0)
        Dim a01 As String = Ar(1)
        Dim a02 As String = Ar(2)
        Dim a03 As String = Ar(3)
        Dim a04 As String = Ar(4)
        Dim a05 As String = Ar(5)
        Dim a06 As String = Ar(6)
        Dim a07 As String = Ar(7)
        Dim a08 As String = Ar(8)
        Dim a09 As String = Ar(9)

        Dim a10 As String = Ar(10)
        Dim a11 As String = Ar(11)
        Dim a12 As String = Ar(12)
        Dim a13 As String = Ar(13)
        Dim a14 As String = Ar(14)
        Dim a15 As String = Ar(15)
        Dim a16 As String = Ar(16)
        Dim a17 As String = Ar(17)
        Dim a18 As String = Ar(18)
        Dim a19 As String = Ar(19)

        Dim a20 As String = Ar(20)
        Dim a21 As String = Ar(21)
        Dim a22 As String = Ar(22)
        Dim a23 As String = Ar(23)
        Dim a24 As String = Ar(24)
        Dim a25 As String = Ar(25)
        Dim a26 As String = Ar(26)
        Dim a27 As String = Ar(27)
        Dim a28 As String = Ar(28)
        Dim a29 As String = Ar(29)

        Dim a30 As String = Ar(30)
        Dim a31 As String = Ar(31)
        Dim a32 As String = Ar(32)
        Dim a33 As String = Ar(33)
        Dim a34 As String = Ar(34)
        Dim a35 As String = Ar(35)
        Dim a36 As String = Ar(36)
        Dim a37 As String = Ar(37)
        Dim a38 As String = Ar(38)
        Dim a39 As String = Ar(39)

        Dim a40 As String = Ar(40)
        Dim a41 As String = Ar(41)
        Dim a42 As String = Ar(42)
        Dim a43 As String = Ar(43)
        Dim a44 As String = Ar(44)
        Dim a45 As String = Ar(45)
        Dim a46 As String = Ar(46)
        Dim a47 As String = Ar(47)
        Dim a48 As String = Ar(48)
        Dim a49 As String = Ar(49)

        Dim a50 As String = Ar(50)





        Dim Emp As New cPrMsEmployees(a01)

        If Emp.Code = "" Then
            'Add New
            With Emp
                .Code = a01
                .Status = "A"
                .PayTyp_Code = "M01"
                .TemGrp_Code = "1001"
                .InterfaceTemCode = "1001"
                .InterfaceMFCode = "1001"
                .InterfacePFCode = "1001"
                .Emp_GLAnal1 = ""
                .Emp_GLAnal2 = ""
                .Emp_GLAnal3 = ""
                .Emp_GLAnal4 = ""
                .EmpSta_Code = "A"
                .Title = "MR"
                .LastName = a03
                .FirstName = a02
                .FullName = a03 & " " & a02
                If a11 = "MALE" Then
                    .Sex = "M"
                Else
                    .Sex = "F"

                End If
                Dim BD() As String
                BD = a25.Split("/")

                .BirthDate = CDate(BD(2) & "/" & BD(1) & "/" & BD(0))
                If a12 = "SINGLE" Then
                    .MarSta_Code = "S"
                Else
                    .MarSta_Code = "M"
                End If
                .Address1 = a05
                .Address2 = a06
                .Address3 = a27
                '.Addres4 = Address4
                Dim S() As String
                S = a07.Split(" ")
                .PostCode = S(0)

                .Telephone1 = a08
                .Telephone2 = ""
                .Email = ""
                .SocialInsNumber = a14
                .ComSin_EmpSocialInsNo = a16
                .IdentificationCard = a15
                .TaxID = a19
                .PassportNumber = a21
                .AlienNumber = a20
                If a18 = "CYPRUS-TIC" Then
                    .TicTyp_Code = 1
                Else
                    .TicTyp_Code = 3
                End If

                .EmpAn1_Code = "AN1"
                .EmpAn2_Code = "AN2"
                .EmpAn3_Code = "AN3"
                .EmpAn4_Code = "AN4"
                .EmpAn5_Code = "AN5"
                .Uni_Code = "UNION1"
                .Cou_Code = "CY"
                .EmpPos_Code = "01"
                If a23 = "SS" Then
                    a23 = "M2"
                End If
                .Sic_Code = a23
                .EmpCmm_Code = "E"
                .PayUni_Code = 1
                .PeriodUnits = 0
                .AnnualUnits = 0
                .Cur_Code = "EUR"
                If a13 = "TRANSFER" Then
                    .PmtMth_Code = "3"
                Else
                    .PmtMth_Code = "2"
                End If
                Dim BC As String = ""
                BC = FindBank(a30)
                If BC = "" Then
                    BC = "BOC"
                End If
                .Bnk_Code = BC
                .BankAccount = a37
                .Bnk_CodeCo = "BOC"
                .BankAccountCo = ""
                Dim SD() As String
                SD = a24.Split("/")

                .StartDate = CDate(SD(2) & "/" & SD(1) & "/" & SD(0))

                .TerminateDate = ""
                .OtherIncome1 = 0
                .OtherIncome2 = 0
                .OtherIncome3 = 0
                .PreviousEarnings = 0
                .Emp_PrevSIDeduct = 0
                .Emp_PrevSIContribute = 0
                .Emp_PrevITDeduct = 0
                .Emp_PrevPFDeduct = 0
                .ProFnd_Code = "0001"
                .MedFnd_Code = "0001"
                .SocInc_Code = "0001"
                .Ind_Code = "0001"
                .Une_Code = "0001"
                .SocCoh_Code = "0001"
                .DrivingLicense = ""
                .MyPayslipReport = ""
                .IBAN = a39
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                .CreatedBy = 1
                .AmendBy = 1

                If Not Emp.Save Then
                    MsgBox("Error in code " & a01)
                    Throw Exx
                End If


                Dim Sal As New cPrTxEmployeeSalary()
                Sal.Emp_Code = a01
                Sal.EffPayDate = CDate("01/01/2015")
                Sal.EffArrearsDate = CDate("01/01/2015")
                Sal.EmpSal_Dif = 0
                Sal.Cola = 0
                Sal.IsCola = 0
                Sal.Usr_Id = Global1.GLBUserId
                Sal.Date1 = Now.Date
                Sal.Basic = 0
                Sal.SalaryValue = a40.Replace(",", ".")
                If Not Sal.Save Then
                    MsgBox("Salary Error in code " & a01)
                    Throw Exx
                End If

                Dim Dis As New cPrTxEmployeeDiscounts(a01, "201501")
                Dis.Emp_Code = a01
                Dis.PrdGrp_Code = "201501"
                Dis.Discount1 = a42.Replace(",", ".")
                Dis.Discount2 = 0
                Dis.Discount3 = 0
                Dis.Discount4 = 0
                Dis.Discount5 = 0
                Dis.Discount6 = 0
                Dis.Discount7 = 0
                Dis.Discount8 = 0
                Dis.Discount9 = 0
                Dis.Discount10 = 0
                Dis.LifeInsurance = a43.Replace(",", ".")
                Dis.AmendDate = Now
                Dis.CreationDate = Now
                Dis.Usr_Id = Global1.GLBUserId
                If Not Dis.Save Then
                    MsgBox("Discount Error in code " & a01)
                    Throw Exx
                End If






            End With
        Else
            ''Update if Diferent
            'Dim Sal As New cPrTxEmployeeSalary()
            'Sal.Emp_Code = a01
            'Sal.EffPayDate = CDate("01/01/2015")
            'Sal.EffArrearsDate = CDate("01/01/2015")
            'Sal.EmpSal_Dif = 0
            'Sal.Cola = 0
            'Sal.IsCola = 0
            'Sal.Usr_Id = Global1.GLBUserId
            'Sal.Date1 = Now.Date
            'Sal.Basic = 0
            'Sal.SalaryValue = a40.Replace(",", ".")
            'If Not Sal.Save Then
            '    MsgBox("Salary Error in code " & a01)
            '    Throw Exx
            'End If
            Dim Dis As New cPrTxEmployeeDiscounts(a01, "201501")
            Dis.Emp_Code = a01
            Dis.PrdGrp_Code = "201501"
            Dis.Discount1 = a42.Replace(",", ".")
            Dis.Discount2 = 0
            Dis.Discount3 = 0
            Dis.Discount4 = 0
            Dis.Discount5 = 0
            Dis.Discount6 = 0
            Dis.Discount7 = 0
            Dis.Discount8 = 0
            Dis.Discount9 = 0
            Dis.Discount10 = 0
            Dis.LifeInsurance = a43.Replace(",", ".")
            Dis.AmendDate = Now
            Dis.CreationDate = Now
            Dis.Usr_Id = Global1.GLBUserId
            If Not Dis.Save Then
                MsgBox("Discount Error in code " & a01)
                Throw Exx
            End If

            'With Emp
            '    .Code = Code
            '    .Status = "A"
            '    .LastName = Last
            '    .FirstName = First
            '    .FullName = Name
            '    .Address1 = Address1
            '    .Address2 = Address2
            '    .Address3 = Address3
            '    .Telephone1 = Phone
            '    .SocialInsNumber = SocInsNo
            '    .IdentificationCard = IdCard
            '    .EmpAn1_Code = An1Code
            '    .AmendDate = Now.Date
            '    .AmendBy = 1
            '    If Not Emp.Save Then
            '        MsgBox("Error loading Employee ")
            '        Throw Exx
            '    End If
            'End With
        End If
    End Sub
    Private Function FindBank(ByVal Bank As String) As String
        Dim S As String = ""
        Select Case Trim(Bank)
            Case "05"
                S = "HELLENIC"
            Case "02"
                S = "BOC"
            Case "07"
                S = "COOP"
            Case "09"
                S = "ALPHA"
            Case "03"
                S = "MARFIN"
            Case "18"
                S = "EFGE"
            Case "11"
                S = "UNI"
        End Select
        Return S

    End Function



    Private Sub EarningsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrMsEmployeeEarnings()
        'Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\NodalD630\My Documents\Visual Studio 2005\Projects\NodalPay\XML\xmlEarningsList")

        Me.Cursor = Cursors.Default

        If CheckDataSet(ds) Then
            Utils.ShowReport("earnings.rpt", ds, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub MnuInterfaceTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuInterfaceTemplate.Click
        Dim F As New FrmPrMsInterfaceTemplate
        F.MdiParent = Me
        F.Show()
    End Sub
#Region "Loading One Net File"
    Private Sub MnuLoadFile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLoadFile2.Click
        Cursor = Cursors.WaitCursor
        LoadingFile2("", "")
        Cursor = Cursors.Default
    End Sub
    Private Sub LoadingFile2(ByVal FileDir As String, ByVal FileName As String)
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader

        FileDir = "Master\"
        Files = IO.Directory.GetFiles(FileDir)
        'Me.Label1.Text = "Loading File in Progress . . ."
        'Me.Label2.Text = "Start At: " & Format(Now, "dd-MM-yyyy hh:mm:ss")
        Me.PanelfileLoad.Visible = True
        'Me.PanelLoading.Refresh()
        Me.Refresh()

        For i = 0 To Files.Length - 1



            Me.Refresh()
            '  Me.PanelLoading.Refresh()
            FileName = Files(i)
            Global1.Business.BeginTransaction()
            counter = 0
            Try


                Dim Exx As New Exception
                Dim HeaderLine As String

                FileName = Files(i)
                Global1.FileName = FileName
                param_file = IO.File.OpenText(FileName)
                LoadedOK = False

                Do While param_file.Peek <> -1
                    '         txtcounter.Text = counter
                    '         txtcounter.Refresh()
                    Me.Refresh()
                    Dim SS As String
                    SS = Chr(34)
                    counter = counter + 1
                    System.Windows.Forms.Application.DoEvents()
                    Line = param_file.ReadLine()
                    Debug.WriteLine("1" & Line)
                    Line = Line.Replace("'", " ")
                    Line = Line.Replace(SS, " ")

                    Line = Line.Replace(Chr(9), "|")
                    Debug.WriteLine("2" & Line)

                    Load_Employee2(Line)

                Loop
                Global1.Business.CommitTransaction()
                MsgBox("File is Succesfully Loaded", MsgBoxStyle.Information)
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Load File", MsgBoxStyle.Critical)

            End Try
        Next
        Me.PanelfileLoad.Visible = False
    End Sub
    Private Sub Load_Employee2(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("|")





        Dim An1Code As String = Ar(0)
        Dim FirstName As String = Trim(Ar(1))


        Dim LastName As String = Trim(Ar(2))
        Dim FullName As String = Trim(Ar(3))
        Dim Adr1 As String = Ar(4)
        Dim Adr2 As String = Ar(5)
        Dim ZipCode As String = Ar(6)
        Dim Phone1 As String = Ar(7)
        Dim Retired As String = Ar(8)
        Dim Sex As String = Ar(9)
        Dim Married As String = Ar(10)
        Dim An2Code As String = Ar(11)
        Dim SDOE As String = Ar(12)
        Dim PayMethod As String = Ar(14)
        Dim Bank As String = Ar(15)
        Dim BankAcc As String = Ar(16)
        Dim SINo As String = Ar(17)
        Dim Salary As String = Ar(19)
        Dim Code As String = ""
        Dim TempGroup As String = ""

        If Married = "YES" Then
            Married = "M"
        ElseIf Married = "NO" Then
            Married = "S"
        ElseIf Married = "DIVORCEE" Then
            Married = "D"
        End If

        If PayMethod = "BANK_TRANSFER" Then
            PayMethod = "3"
        ElseIf PayMethod = "CHEQUE" Then
            PayMethod = "2"
        Else
            PayMethod = "1"
        End If


        If An1Code = "One Net Ltd" Then
            OneNetCount = OneNetCount + 1
            Code = "10"
            Code = "10" & CStr(OneNetCount).PadLeft(2, "0")
        ElseIf An1Code = "Deep Blue" Then
            DeepBlueCount = DeepBlueCount + 1
            Code = "15"
            Code = "15" & CStr(DeepBlueCount).PadLeft(2, "0")
        ElseIf Trim(An1Code) = "Bunker Net Ltd" Then
            BNcount = BNcount + 1
            Code = "20"
            Code = "20" & CStr(BNcount).PadLeft(2, "0")
        ElseIf Trim(An1Code) = "NAVILUB LTD" Then
            NLCount = NLCount + 1
            Code = "25"
            Code = "25" & CStr(NLCount).PadLeft(2, "0")
        ElseIf Trim(An1Code) = "KNIGHT STAR LTD" Then
            KSCount = KSCount + 1
            Code = "30"
            Code = "30" & CStr(KSCount).PadLeft(2, "0")
        ElseIf Trim(An1Code) = "BUNKER POINT LTD" Then
            BPCount = BPCount + 1
            Code = "35"
            Code = "35" & CStr(BPCount).PadLeft(2, "0")


        End If





        If Trim(An1Code) = "One Net Ltd" Then
            An1Code = "01"
            TempGroup = "GRP1"
        ElseIf Trim(An1Code) = "Deep Blue" Then
            An1Code = "02"
            TempGroup = "GRP2"
        ElseIf Trim(An1Code) = "Bunker Net Ltd" Then
            An1Code = "03"
            TempGroup = "GRP3"
        ElseIf Trim(An1Code) = "NAVILUB LTD" Then
            An1Code = "04"
            TempGroup = "GRP4"
        ElseIf Trim(An1Code) = "KNIGHT STAR LTD" Then
            An1Code = "05"
            TempGroup = "GRP5"
        ElseIf Trim(An1Code) = "BUNKER POINT LTD" Then
            An1Code = "06"
            TempGroup = "GRP6"


        End If

        If Trim(An2Code) = "ADMINISTRATION" Then
            An2Code = "01"
        ElseIf Trim(An2Code) = "SALES" Then
            An2Code = "02"
        ElseIf Trim(An2Code) = "ACCOUNTS" Then
            An2Code = "03"
        ElseIf Trim(An2Code) = "TECHNICAL" Then
            An2Code = "04"
        ElseIf Trim(An2Code) = "TRADERS" Then
            An2Code = "05"
        ElseIf Trim(An2Code) = "OPERATIONS" Then
            An2Code = "06"
        End If

        Ar = SDOE.Split("/")
        Dim S As String
        SDOE = Ar(2) & "/" & Ar(1) & "/" & Ar(0)


        Dim Emp As New cPrMsEmployees(Code)

        If Emp.Code = "" Then
            'Add New
            With Emp
                .Code = Code
                .Status = "A"
                .PayTyp_Code = "M01"
                .TemGrp_Code = TempGroup
                .EmpSta_Code = "A"
                .Title = "MR"
                .LastName = LastName
                .FirstName = FirstName
                .FullName = FullName
                .Sex = Sex
                .BirthDate = Now.Date
                .MarSta_Code = Married
                .Address1 = Adr1
                .Address2 = Adr2
                .Address3 = ""
                '.Addres4 = Address4
                .PostCode = ZipCode
                .Telephone1 = Phone1
                .Telephone2 = ""
                .Email = ""
                .SocialInsNumber = SINo
                .ComSin_EmpSocialInsNo = ""
                .IdentificationCard = ""
                .TaxID = ""
                .PassportNumber = ""
                .AlienNumber = ""
                .TicTyp_Code = 1
                .EmpAn1_Code = An1Code
                .EmpAn2_Code = An2Code
                .EmpAn3_Code = "AN3"
                .EmpAn4_Code = "AN4"
                .EmpAn5_Code = "AN5"
                .Uni_Code = "UNION1"
                .Cou_Code = "CY"
                .EmpPos_Code = "01"
                .Sic_Code = "AM"
                .EmpCmm_Code = "E"
                .PayUni_Code = 1
                .PeriodUnits = 0
                .AnnualUnits = 0
                .Cur_Code = "EUR"
                .PmtMth_Code = PayMethod
                .Bnk_Code = Bank
                .BankAccount = BankAcc
                .Bnk_CodeCo = "BOC"
                .BankAccountCo = ""
                .StartDate = CDate(SDOE)
                .TerminateDate = ""
                .OtherIncome1 = 0
                .OtherIncome2 = 0
                .OtherIncome3 = 0
                .PreviousEarnings = 0
                .Emp_PrevSIDeduct = 0
                .Emp_PrevSIContribute = 0
                .Emp_PrevITDeduct = 0
                .Emp_PrevPFDeduct = 0
                .ProFnd_Code = "0002"
                .MedFnd_Code = "0002"
                .SocInc_Code = "0001"
                .Ind_Code = "0001"
                .Une_Code = "0001"
                .SocCoh_Code = "0001"
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                .CreatedBy = 1
                .AmendBy = 1
                If Not Emp.Save Then
                    MsgBox("Error loading Employee ")
                    Throw Exx
                End If
            End With
            'Else
            '    'Update if Diferent
            '    With Emp
            '        .Code = Code
            '        .Status = "A"
            '        .LastName = Last
            '        .FirstName = First
            '        .FullName = Name
            '        .Address1 = Address1
            '        .Address2 = Address2
            '        .Address3 = Address3
            '        .Telephone1 = Phone
            '        .SocialInsNumber = SocInsNo
            '        .IdentificationCard = IdCard
            '        .EmpAn1_Code = An1Code
            '        .AmendDate = Now.Date
            '        .AmendBy = 1
            '        If Not Emp.Save Then
            '            MsgBox("Error loading Employee ")
            '            Throw Exx
            '        End If
            '    End With
        End If
    End Sub



#End Region


    Private Sub MnuInterfaceMskingCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuInterfaceCodes.Click
        Dim F As New FrmPrMsInterfaceCode
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPayrollAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPayrollAnalysis.Click
        Dim F As New FrmPayrollTotalsX
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuRptIR63A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRptIR63A.Click
        Dim F As New FrmIR63A
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim F As New FrmAbout
        F.MdiParent = Me
        F.Show()
    End Sub


    Private Sub MnuCopyEmployeeDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCopyEmployeeDiscounts.Click
        Dim F As New FrmCopyDiscountFromPeriodtoPeriod
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Ds As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim m As Integer
        Dim n As Integer


        Ds = Global1.Business.GetAllPrMsPeriodGroups
        For i = 0 To Ds.Tables(0).Rows.Count - 1
            Dim PerGrp As New cPrMsPeriodGroups
            PerGrp = New cPrMsPeriodGroups(Ds.Tables(0).Rows(i))
            Dim DsPeriods As DataSet
            DsPeriods = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGrp.Code)
            For k = 0 To DsPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(k))
                Global1.Business.fixTotalContributiononHeader(PerGrp.Code, Per.Code)
            Next
        Next
    End Sub


#Region "Loading Transactions"
    Private Sub Loading_Transactions()
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String
        FileDir = "Data\Transactions\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try
            Dim Exx As New Exception
            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Transactions\Header.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_TransactionHeader(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            MsgBox("Unable to Load Header", MsgBoxStyle.Critical)
            param_file.Close()
            param_file.Dispose()

        End Try

        Global1.Business.CommitTransaction()
        MsgBox("Header is Succesfully Loaded", MsgBoxStyle.Information)
        Try
            param_file = IO.File.OpenText("Data\Transactions\Line.txt")
            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_TransactionLine(Line)
            Loop
            param_file.Close()
            param_file.Dispose()

            Global1.Business.CommitTransaction()
            MsgBox("Line is Succesfully Loaded", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            MsgBox("Unable Load Line", MsgBoxStyle.Critical)
            param_file.Close()
            param_file.Dispose()

        End Try
        Me.PanelfileLoad.Visible = False
    End Sub
    Private Sub Load_TransactionHeader(ByVal Line As String)
        Dim TH As New cPrTxTrxnHeader
        Try
            Dim Exx As New Exception
            Dim Ar() As String
            Ar = Line.Split("	")
            Dim Employee_Code As String = Ar(0)
            Dim Period_Group As String = Ar(1)
            Dim Period_Code As String = Ar(2)
            Dim Period_Cat As String = Ar(3)
            Dim Trxn_Date As String = Ar(4)
            Dim Status As String = Ar(5)
            Dim Total_Earnings As Double = CDbl(Replace(Ar(6), ",", "."))
            Dim Prd_Total_Earning_YTD As Double = CDbl(Replace(Ar(7), ",", "."))
            Dim Total_Deductions As Double = CDbl(Replace(Ar(8), ",", "."))
            Dim Prd_Total_Deductions_YTD As Double = CDbl(Replace(Ar(9), ",", "."))
            Dim Total_Contributions As Double = CDbl(Replace(Ar(10), ",", "."))
            Dim Prd_Total_Contributions_YTD As Double = CDbl(Replace(Ar(11), ",", "."))
            Dim SI_Deduct As Double = CDbl(Replace(Ar(12), ",", "."))
            Dim Prd_Taxable_Income As Double = CDbl(Replace(Ar(13), ",", "."))
            Dim Prd_Pmt_Method As String = Ar(14)
            Dim Pay_Ref As String = Ar(15)
            Dim Period_Units As Double = CDbl(Replace(Ar(16), ",", "."))
            Dim Annual_Units As Double = CDbl(Replace(Ar(17), ",", "."))
            Dim Prd_Annual_Leave As Double = CDbl(Replace(Ar(18), ",", "."))
            Dim Life_Ins As Double = 0 'Ar(19)
            Dim Discounts As Double = 0 'Ar(20)
            Dim Int_Status As String = Ar(21)
            Dim OT1 As Double = 0 ' Ar(22)
            Dim OT2 As Double = 0 'Ar(23)
            Dim SI_Units As Double = 0 'Ar(24)
            Dim Monthly_Salary As Double = CDbl(Replace(Ar(25), ",", "."))
            Dim Net_Salary As Double = CDbl(Replace(Ar(26), ",", "."))
            Dim Period_Insurable_Income As Double = CDbl(Replace(Ar(27), ",", "."))
            Dim Template_Group_Code As String = Ar(28)
            Dim Cheque_No As String = Ar(29)

            Ar = Trxn_Date.Split("/")
            Trxn_Date = Ar(2) & "/" & Ar(1) & "/" & Ar(0)

            With TH
                .Emp_Code = Employee_Code
                .PrdGrp_Code = Period_Group
                .PrdCod_Code = Period_Code
                .PayCat_Code = Period_Cat
                .MyDate = Trxn_Date
                .Status = Status
                .TotalErnPeriod = Total_Earnings
                .TotalErnYTD = Prd_Total_Earning_YTD
                .TotalDedPeriod = Total_Deductions
                .TotalDedYTD = Prd_Total_Deductions_YTD
                .TotalConPeriod = Total_Contributions
                .TotalConYTD = Prd_Total_Contributions_YTD
                .SIIncome = SI_Deduct
                .TaxableIncome = Prd_Taxable_Income
                .PaymentMethod = Prd_Pmt_Method
                .PaymentRef = Pay_Ref
                .PeriodUnits = Period_Units
                .AnnualUnits = Annual_Units
                .AnnualLeave = Prd_Annual_Leave
                .LifeInsurance = Life_Ins
                .Discounts = Discounts
                .InterfaceStatus = Int_Status
                .Overtime1 = OT1
                .Overtime2 = OT2
                .SIUnits = SI_Units
                .MonthlySalary = Monthly_Salary
                .NetSalary = Net_Salary
                .PeriodInsurable = Period_Insurable_Income
                .TemGrpCode = Template_Group_Code
                .ChequeNo = Cheque_No
                If Not .Save Then
                    Throw Exx
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Function Load_TransactionLine(ByVal Line As String) As Integer
        Try


            Dim Exx As New Exception
            Dim Ar() As String
            Ar = Line.Split("	")
            Dim Employee_Code As String = Ar(0)
            Dim Period_Group As String = Ar(1)
            Dim Period_Code As String = Ar(2)
            Dim Line_No As Integer = Ar(3)
            Dim Type As String = Ar(4)
            Dim E_Code As String = Ar(5)
            Dim D_Code As String = Ar(6)
            Dim C_Code As String = Ar(7)
            Dim Period_Value As Double = CDbl(Replace(Ar(8), ",", "."))
            Dim Ds As DataSet

            Dim H As New cPrTxTrxnHeader(Employee_Code, Period_Code)

            '--------------------------------------------------------------
            Dim YTDValue As Double
            Ds = Global1.Business.FindYTD(Type, E_Code, D_Code, C_Code, Employee_Code, Period_Code, H.Id)
            If CheckDataSet(Ds) Then
                YTDValue = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
            Else
                YTDValue = 0
            End If
            YTDValue = YTDValue + Period_Value
            '--------------------------------------------------------------

            Dim YTD_Value As Double = 0 'Ar(9)
            Dim LineEDC As Double = 0 ' Ar(10)
            Dim Description As String = Ar(11)

            Dim L As New cPrTxTrxnLines

            If H.Id > 0 Then
                With L
                    .TrxHdr_Id = H.Id
                    .TrxLin_Id = Line_No
                    .TrxLin_Type = Type
                    Select Case Type
                        Case "E"
                            .ErnCod_Code = E_Code
                        Case "D"
                            .DedCod_Code = D_Code
                        Case "C"
                            .ConCod_Code = C_Code
                    End Select

                    .TrxLin_PeriodValue = Period_Value
                    .TrxLin_YTDValue = YTDValue
                    .TrxLin_EDC = LineEDC
                    .TrxLin_EDCDescription = Description
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            Else
                MsgBox("Header not Found")
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Function


#End Region

    Private Sub MnuLoadTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLoadTransactions.Click
        Me.Loading_Transactions()
    End Sub
    Private Sub LoadDiscountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadDiscountsToolStripMenuItem.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data\Discounts\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Discounts\Discounts.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Discounts(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Discounts - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
        Me.PanelfileLoad.Visible = False
        Me.Refresh()

    End Sub
    Private Sub MnuLoadEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLoadEmployees.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data\Employees\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Employees\Employees.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Employees(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Employees - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Employees\Employees.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_EmployeesSalary(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Employees Salary - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try

        Me.PanelfileLoad.Visible = False
        Me.Refresh()

    End Sub
    Private Sub Load_Employees(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")

        Dim Company As String = "01" 'Trim(Ar(0))
        Dim Employee_Code As String = Trim(Ar(1))
        Dim First_Name As String = Trim(Ar(2))

        Dim Last_Name As String = Trim(Ar(3))
        Dim Full_Name As String = Trim(Ar(4))
        Dim Address1 As String = Trim(Ar(5))
        Dim Address2 As String = Trim(Ar(6))
        Dim PostCode As String = Trim(Ar(7))
        Dim PhoneNo As String = Replace(Trim(Ar(8)), "-", "")
        Dim Retired As String = Trim(Ar(9))
        Dim Sex As String = Trim(Ar(10))
        Dim Married As String = Trim(Ar(11))
        Dim Department As String = Trim(Ar(12))
        Dim SDOE As String = Trim(Ar(13))
        Dim Pay_Method As String = Trim(Ar(14))
        Dim Bank As String = Trim(Ar(15))
        Dim Bank_Account As String = Trim(Ar(16))
        Dim Social_Ins_No As String = Trim(Ar(17))
        Dim ID_No As String = Trim(Ar(18))
        '''
        Dim TAX_ID As String = Trim(Ar(19))
        '''
        Dim Salary As String = Trim(Ar(20))
        Dim TempGroup As String = "1001" 'Trim(Ar(20))

        If PhoneNo Is Nothing Then
            PhoneNo = ""
        End If
        Dim AN2 As New cPrAnEmployeeAnalysis2(Department)
        If AN2.Code = "" Then
            With AN2
                .Code = Department
                .DescriptionL = Department
                .DescriptionS = Department
                .IsActive = "Y"
                .GLAnal1 = 0
                .GLAnal2 = 0
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                If Not .Save() Then
                    Throw Exx
                    MsgBox("Unable to Save Analysis2 Code:" & Department)
                End If
            End With

        End If

        If SDOE = "00/00/0000" Then
            SDOE = "01/01/1900"
        End If
        Ar = SDOE.Split("/")
        Dim S As String
        SDOE = Ar(2) & "/" & Ar(1) & "/" & Ar(0)

        If UCase(Married) = "YES" Then
            Married = "M"
        ElseIf UCase(Married) = "NO" Then
            Married = "S"
        ElseIf UCase(Married) = "DIVORCEE" Then
            Married = "D"
        ElseIf Married = "" Then
            Married = "S"
        End If
        Dim Emp As New cPrMsEmployees(Employee_Code)

        If Department = "SERVICE (COS)" Then
            Department = "03"
        ElseIf Department = "SALES" Then
            Department = "02"
        ElseIf Department = "ADMINISTRATION" Then
            Department = "01"
        End If


        If Emp.Code = "" Then
            'Add New
            With Emp
                .Code = Employee_Code
                .Status = "A"
                .PayTyp_Code = "M01"
                .TemGrp_Code = TempGroup
                .EmpSta_Code = "A"
                .Title = "MR"
                .LastName = Last_Name
                .FirstName = First_Name
                .FullName = Full_Name
                .Sex = Sex
                .BirthDate = Now.Date
                .MarSta_Code = Married
                .Address1 = Address1
                .Address2 = Address2
                .Address3 = ""
                '.Addres4 = Address4
                .PostCode = PostCode
                .Telephone1 = PhoneNo
                .Telephone2 = ""
                .Email = ""
                .SocialInsNumber = Social_Ins_No
                .ComSin_EmpSocialInsNo = ""
                .IdentificationCard = ID_No
                .TaxID = ""
                .PassportNumber = ""
                .AlienNumber = ""
                .TicTyp_Code = 1
                .EmpAn1_Code = "AN1"
                .EmpAn2_Code = "AN2"
                .EmpAn3_Code = "AN3"
                .EmpAn4_Code = "AN4"
                .EmpAn5_Code = "AN5"
                .Uni_Code = "UNION1"
                .Cou_Code = "CY"
                .EmpPos_Code = "01"
                .Sic_Code = "M1"
                .EmpCmm_Code = "E"
                .PayUni_Code = 1
                .PeriodUnits = 0
                .AnnualUnits = 0
                .Cur_Code = "EUR"
                '.PmtMth_Code = Pay_Method
                '.Bnk_Code = Bank
                '.BankAccount = Bank_Account
                '.Bnk_CodeCo = "BOC"
                .PmtMth_Code = "3"
                .Bnk_Code = "BOC"
                .BankAccount = ""
                .Bnk_CodeCo = "BOC"
                .BankAccountCo = ""
                .StartDate = CDate(SDOE)
                .TerminateDate = ""
                .OtherIncome1 = 0
                .OtherIncome2 = 0
                .OtherIncome3 = 0
                .PreviousEarnings = 0
                .Emp_PrevSIDeduct = 0
                .Emp_PrevSIContribute = 0
                .Emp_PrevITDeduct = 0
                .Emp_PrevPFDeduct = 0
                .ProFnd_Code = "0001"
                .MedFnd_Code = "0001"
                .SocInc_Code = "0001"
                .Ind_Code = "0001"
                .Une_Code = "0001"
                .SocCoh_Code = "0001"
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                .CreatedBy = 1
                .AmendBy = 1
                .Emp_GLAnal1 = ""
                .Emp_GLAnal2 = ""
                .Emp_GLAnal3 = ""
                .Emp_GLAnal4 = ""
                .InterfaceTemCode = TempGroup
                .InterfaceMFCode = TempGroup
                .InterfacePFCode = TempGroup
                .TaxID = TAX_ID


                If Not Emp.Save Then
                    MsgBox("Error loading Employee ")
                    Throw Exx
                End If
            End With
        End If
    End Sub
    Private Sub Load_Discounts(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")
        Dim Employee_Code As String = Trim(Ar(0))
        Dim Salary As String = Trim(Ar(1))
        Dim dis1 As String = Trim(Ar(2))
        Dim Lf As String = Trim(Ar(3))
        Dim Dis2 As String = Trim(Ar(4))


        Dim Sal As Double
        Salary = Replace(Salary, ",", "")
        Salary = Replace(Salary, ".", "")
        Sal = CDbl(Salary / 100)

        Dim dDis As Double
        dis1 = Replace(dis1, ",", "")
        dis1 = Replace(dis1, ".", "")
        If IsNothing(dis1) Then
            dDis = 0
        Else
            dDis = CDbl(dis1 / 100)
        End If


        Dim dLF As Double
        Lf = Replace(Lf, ",", "")
        Lf = Replace(Lf, ".", "")
        If IsNothing(dLF) Then
            dLF = 0
        Else
            dLF = CDbl(Lf / 100)
        End If


        Dim dDis2 As Double
        Dis2 = Replace(Dis2, ",", "")
        Dis2 = Replace(Dis2, ".", "")
        If IsNothing(Dis2) Then
            dDis2 = 0
        Else
            dDis2 = CDbl(Dis2 / 100)
        End If



        Dim Emp As New cPrMsEmployees(Employee_Code)

        If Emp.Code <> "" Then
            Dim EmpSalary As New cPrTxEmployeeSalary
            With EmpSalary
                .Id = 0
                .Emp_Code = Emp.Code
                .Date1 = Now.Date
                .SalaryValue = 0
                .Basic = Sal
                .EffPayDate = "2011/01/01"
                .Cola = 0
                .EffArrearsDate = "2011/01/01"
                .Usr_Id = Global1.GLBUserId
                .IsCola = "Y"
                .EmpSal_Dif = 0

                If Not .Save() Then
                    Throw Exx
                    MsgBox("Unable to save Salary of Employee " & Emp.Code)
                End If

            End With


            Dim tPrTxEmployeeDiscounts As New cPrTxEmployeeDiscounts(Emp.Code, "201101")
            With tPrTxEmployeeDiscounts
                .Emp_Code = Emp.Code
                .PrdGrp_Code = "201101"
                .Discount1 = dDis
                .Discount2 = dDis2
                .Discount3 = 0
                .Discount4 = 0
                .Discount5 = 0
                .Discount6 = 0
                .Discount7 = 0
                .Discount8 = 0
                .Discount9 = 0
                .Discount10 = 0
                .LifeInsurance = dLF
                .Usr_Id = Global1.GLBUserId
                If .Id = 0 Then
                    .CreationDate = Now.Date
                End If
                .AmendDate = Now.Date
                If Not .Save() Then
                    Throw Exx
                End If
            End With
        End If

    End Sub
    Private Sub Load_EmployeesSalary(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        'Ar = Line.Split("|")


        Dim Employee_Code As String = Trim(Ar(1))
        Dim Salary As String = Trim(Ar(21))
        Dim Sal As Double
        Salary = Replace(Salary, ",", "")
        Salary = Replace(Salary, ".", "")

        Sal = CDbl(Salary / 100)
        Dim Emp As New cPrMsEmployees(Employee_Code)

        If Emp.Code <> "" Then
            Dim EmpSalary As New cPrTxEmployeeSalary
            With EmpSalary
                .Id = 0
                .Emp_Code = Emp.Code
                .Date1 = Now.Date
                .SalaryValue = Sal
                .Basic = 0
                .EffPayDate = "2011/01/01"
                .Cola = 0
                .EffArrearsDate = "2011/01/01"
                .Usr_Id = Global1.GLBUserId
                .IsCola = "Y"
                .EmpSal_Dif = 0

                If Not .Save() Then
                    Throw Exx
                    MsgBox("Unable to save Salary of Employee " & Emp.Code)
                End If

            End With
        End If
    End Sub
    Private Sub Load_EmployeeIBAN(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")


        Dim Code As String = Trim(Ar(0))
        Dim IBAN As String = Trim(Ar(6))
        Dim BankCode As String = Trim(Ar(3))
        Dim Bankacc As String = Trim(Ar(4))

        Dim Emp As New cPrMsEmployees(Code)

        If Emp.Code <> "" Then
            'Add New
            With Emp
                .PmtMth_Code = "3"
                .Bnk_Code = BankCode
                .BankAccount = Bankacc
                .IBAN = IBAN
                .Bnk_CodeCo = "BOC"
                .BankAccountCo = ""

                If Not Emp.Save Then
                    MsgBox("Error loading Employee ")
                    Throw Exx
                End If
            End With
        End If
    End Sub
    'Temp
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim L As New cLogin
    '    Dim Strconnect As String
    '    Dim Server As String = "192.168.0.11\NAVSQL"
    '    Dim DB As String = "NYS"
    '    Dim User As String = "nodal"
    '    Dim Pass As String = "36132"

    '    Strconnect = "Server=" & Server & ";Database=" & DB & ";User ID=" + User + ";Password=" + Pass + ";"
    '    If L.TryToConnect(Strconnect, True) Then
    '        Global1.Business = New cBusiness
    '    Else
    '        MsgBox("Unable To connect To Navision.Please check Parameters", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If


    '    Dim Files() As String
    '    Dim i As Integer
    '    Dim Line As String = String.Empty
    '    Dim counter As Integer = 0
    '    Dim t As Date
    '    Dim LoadedOK As Boolean = False
    '    Dim param_file As IO.StreamReader
    '    Dim FileDir As String
    '    FileDir = "C:\NYS\"
    '    Files = IO.Directory.GetFiles(FileDir)

    '    For i = 0 To Files.Length - 1

    '        Me.Refresh()
    '        FileName = Files(i)
    '        Global1.Business.BeginTransaction()
    '        Try




    '            Dim Exx As New Exception
    '            Dim HeaderLine As String

    '            FileName = Files(i)
    '            Global1.FileName = FileName
    '            param_file = IO.File.OpenText(FileName)
    '            Dim ItemNo As String
    '            Dim Cat9 As String
    '            Dim Cat10 As String
    '            Dim Ar() As String
    '            Dim Vbtab As Char
    '            Vbtab = Chr(9)
    '            Do While param_file.Peek <> -1
    '                counter = counter + 1
    '                System.Windows.Forms.Application.DoEvents()
    '                Line = param_file.ReadLine()
    '                'Debug.WriteLine("1" & Line)
    '                Line = Line.Replace("'", " ")
    '                Ar = Line.Split(vbTab)

    '                ItemNo = Ar(0)
    '                Cat9 = Ar(1)
    '                Cat10 = Ar(2)
    '                Global1.Business.temp_Gencat(ItemNo, Cat9, Cat10)

    '            Loop
    '        Catch ex As Exception

    '        End Try
    '    Next
    '    Global1.Business.CommitTransaction()

    'End Sub
    Private Sub LoadPositionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPositionsToolStripMenuItem.Click

        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Positions\Positions.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Position(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Positions - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
        Me.PanelfileLoad.Visible = False
        Me.Refresh()

    End Sub
    Private Sub Load_Position(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")
        Dim Employee_Code As String = Trim(Ar(0))

        Dim posCode As String = Trim(Ar(9))
        Dim PosDesc As String = Trim(Ar(8))



        Dim P As New cPrAnEmployeePositions(posCode)
        If P.Code = "" Then
            P.Code = posCode
            P.DescriptionL = PosDesc
            P.DescriptionS = PosDesc
            P.IsActive = "Y"
            If Not P.Save Then
                Throw Exx
            End If
        End If


        Dim Emp As New cPrMsEmployees(Employee_Code)

        If Emp.Code <> "" Then
            Emp.EmpPos_Code = posCode
            If Not Emp.Save() Then
                Throw Exx
            End If
        End If


    End Sub



    Private Sub LoadEmployeesFromNODALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadEmployeesFromNODALToolStripMenuItem.Click

        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data\Employees\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\NODAL\Employees.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Employees_FROM_Nodal(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Employees - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try



        Me.PanelfileLoad.Visible = False
        Me.Refresh()

    End Sub
    Private Sub Load_Employees_FROM_Nodal(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        'Ar = Line.Split("	")
        Ar = Line.Split("|")

        Dim Company As String = "01" 'Trim(Ar(0))
        Dim Employee_Code As String = Trim(Ar(1))
        Dim First_Name As String = Trim(Ar(2))
        Dim Last_Name As String = Trim(Ar(3))
        Dim Full_Name As String = Trim(Ar(4))
        Dim Address1 As String = Trim(Ar(5))
        Dim Address2 As String = Trim(Ar(6))
        Dim PostCode As String = Trim(Ar(7))
        Dim PhoneNo As String = Replace(Trim(Ar(8)), "-", "")
        Dim Retired As String = Trim(Ar(9))
        Dim Sex As String = Trim(Ar(10))
        Dim Married As String = Trim(Ar(11))
        Dim SDOE As String = Trim(Ar(12))
        Dim Pay_Method As String = Trim(Ar(13))
        Dim Bank As String = Trim(Ar(14))
        Dim Bank_Account As String = Trim(Ar(15))
        Dim CoBank As String = Trim(Ar(16))
        Dim CoBank_Account As String = Trim(Ar(17))

        Dim Social_Ins_No As String = Trim(Ar(18))
        Dim ID_No As String = Trim(Ar(19))

        Dim TempGrp As String = "1001" 'Trim(Ar(20))
        Dim Anal1 As String = Trim(Ar(21))
        Dim AnalDes1 As String = Trim(Ar(22))
        Dim Anal2 As String = Trim(Ar(23))
        Dim AnalDes2 As String = Trim(Ar(24))
        Dim Anal3 As String = Trim(Ar(25))
        Dim AnalDes3 As String = Trim(Ar(26))
        Dim Anal4 As String = Trim(Ar(27))
        Dim AnalDes4 As String = Trim(Ar(28))
        Dim Union As String = Trim(Ar(29)) 'UNION
        Dim UnionDes As String = Trim(Ar(30))
        Dim TaxId As Integer = Trim(Ar(31))
        Dim TaxCardNo As String = Trim(Ar(32))
        Dim Alien As String = Trim(Ar(33))
        Dim Passport As String = Trim(Ar(34))
        Dim CommunityCode As String = Trim(Ar(35))
        Dim SICategory As String = Trim(Ar(36))
        Dim BasicSalary As String = Trim(Ar(37))
        Dim IsCOLAEnabled As String = Trim(Ar(38))
        Dim Discount As String = Trim(Ar(39))
        Dim LF As String = Trim(Ar(40))

        Dim SIType As String = Trim(Ar(41))
        Dim SIDeduction As String = Trim(Ar(42))
        Dim SIContribution As String = Trim(Ar(43))

        Dim PFType As String = Trim(Ar(44))
        Dim PFDeduction As String = Trim(Ar(45))
        Dim PFContribution As String = Trim(Ar(46))

        Dim MFType As String = Trim(Ar(47))
        Dim MFDeduction As String = Trim(Ar(48))
        Dim MFContribution As String = Trim(Ar(49))

        Dim IndustrialType As String = Trim(Ar(50))
        Dim IndustrialContr As String = Trim(Ar(51))
        Dim UnemployementType As String = Trim(Ar(52))
        Dim UnemployementContr As String = Trim(Ar(53))
        Dim UnionType As String = Trim(Ar(54))
        Dim UnionValue As String = Trim(Ar(55))
        Dim SILeavePerc As String = Trim(Ar(56))
        Dim PayrollType As String = Trim(Ar(57))









        If PhoneNo Is Nothing Then
            PhoneNo = ""
        End If



        If SDOE = "00/00/0000" Then
            SDOE = "01/01/1900"
        End If
        Ar = SDOE.Split("/")
        Dim S As String
        SDOE = Ar(2) & "/" & Ar(1) & "/" & Ar(0)

        Dim Emp As New cPrMsEmployees(Employee_Code)

        '-----------------------------------------------------
        'UNION AND MF Amount
        'If Emp.Code <> "" Then
        '    If Union <> "01" Then
        '        Emp.Uni_Code = Union
        '        Emp.Save()
        '    End If
        '    If MFType = "A" Then
        '        Dim P As New cPrMsEmployeeDeductions(Emp.Code, "D4")
        '        If P.DedCode <> "" Then
        '            P.MyValue = MFDeduction
        '            P.Save()

        '        End If
        '        Dim P2 As New cPrMsEmployeeContributions(Emp.Code, "C2")
        '        If P2.ConCode <> "" Then
        '            P2.MyValue = MFContribution
        '            P2.Save()

        '        End If
        '    End If

        'End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '-----------------------------------------------------
        If Emp.Code = "" Then
            With Emp
                '-------------------------------------------
                'DEFINE ANALYSIS IF MISSING
                '-------------------------------------------
                'ANALYSIS 1
                '-------------------------------------------

                If Anal1 <> "" Then
                    Dim AN1 As New cPrAnEmployeeAnalysis1(Anal1)
                    If AN1.Code = "" Then
                        With AN1
                            .Code = Anal1
                            .DescriptionL = AnalDes1
                            .DescriptionS = AnalDes1
                            .IsActive = "Y"
                            .GLAnal1 = 0
                            .GLAnal2 = 0
                            .CreationDate = Now.Date
                            .AmendDate = Now.Date
                            If Not .Save() Then
                                Throw Exx
                                MsgBox("Unable to Save Analysis1 Code:" & Anal1)
                            End If
                        End With
                    End If
                    .EmpAn1_Code = Anal1

                Else
                    .EmpAn1_Code = "AN1"
                End If
                '-------------------------------------------
                'ANALYSIS 2
                '-------------------------------------------
                If Anal2 <> "" Then
                    Dim AN2 As New cPrAnEmployeeAnalysis2(Anal2)
                    If AN2.Code = "" Then
                        With AN2
                            .Code = Anal2
                            .DescriptionL = AnalDes2
                            .DescriptionS = AnalDes2
                            .IsActive = "Y"
                            .GLAnal1 = 0
                            .GLAnal2 = 0
                            .CreationDate = Now.Date
                            .AmendDate = Now.Date
                            If Not .Save() Then
                                Throw Exx
                                MsgBox("Unable to Save Analysis2 Code:" & Anal2)
                            End If
                        End With
                    End If
                    .EmpAn2_Code = Anal2
                Else
                    .EmpAn2_Code = "AN2"
                End If
                '-------------------------------------------
                'ANALYSIS 3
                '-------------------------------------------
                If Anal3 <> "" Then
                    Dim AN3 As New cPrAnEmployeeAnalysis3(Anal3)
                    If AN3.Code = "" Then
                        With AN3
                            .Code = Anal3
                            .DescriptionL = AnalDes3
                            .DescriptionS = AnalDes3
                            .IsActive = "Y"
                            .GLAnal1 = 0
                            .GLAnal2 = 0
                            .CreationDate = Now.Date
                            .AmendDate = Now.Date
                            If Not .Save() Then
                                Throw Exx
                                MsgBox("Unable to Save Analysis3 Code:" & Anal3)
                            End If
                        End With
                    End If
                    .EmpAn3_Code = Anal3

                Else
                    .EmpAn3_Code = "AN3"
                End If
                '-------------------------------------------
                'ANALYSIS 4
                '-------------------------------------------
                If Anal4 <> "" Then
                    Dim AN4 As New cPrAnEmployeeAnalysis4(Anal4)
                    If AN4.Code = "" Then
                        With AN4
                            .Code = Anal4
                            .DescriptionL = AnalDes4
                            .DescriptionS = AnalDes4
                            .IsActive = "Y"
                            .GLAnal1 = 0
                            .GLAnal2 = 0
                            .CreationDate = Now.Date
                            .AmendDate = Now.Date
                            If Not .Save() Then
                                Throw Exx
                                MsgBox("Unable to Save Analysis4 Code:" & Anal4)
                            End If
                        End With
                    End If
                    .EmpAn4_Code = Anal4

                Else
                    .EmpAn4_Code = "AN4"
                End If
                '-------------------------------------------
                'ANALYSIS 5
                '-------------------------------------------
                .EmpAn5_Code = "AN5"
                '-------------------------------------------
                'ANALYSIS END
                '-------------------------------------------
                .Code = Employee_Code
                .Status = "A"
                .PayTyp_Code = "M01"
                .TemGrp_Code = TempGrp
                .EmpSta_Code = "A"
                .Title = "MR"
                .LastName = Last_Name
                .FirstName = First_Name
                .FullName = Full_Name
                .Sex = Sex
                .BirthDate = Now.Date
                .MarSta_Code = Married
                .Address1 = Address1
                .Address2 = Address2
                .Address3 = ""
                '.Addres4 = Address4
                .PostCode = PostCode
                .Telephone1 = PhoneNo
                .Telephone2 = ""
                .Email = ""
                .SocialInsNumber = Social_Ins_No
                .ComSin_EmpSocialInsNo = ""
                .IdentificationCard = ID_No
                .TaxID = TaxCardNo
                .PassportNumber = Passport
                .AlienNumber = Alien
                .TicTyp_Code = TaxId
                '.EmpAn1_Code = Anal1
                '.EmpAn2_Code = Anal2
                '.EmpAn3_Code = Anal3
                '.EmpAn4_Code = Anal4
                '.EmpAn5_Code = "AN5"
                .Uni_Code = "UNION1"
                .Cou_Code = "CY"
                .EmpPos_Code = "01"
                .Sic_Code = SICategory
                .EmpCmm_Code = CommunityCode
                .PayUni_Code = PayrollType
                .PeriodUnits = 0
                .AnnualUnits = 0
                .Cur_Code = "EUR"

                .Bnk_Code = FindBankCode(Bank)
                .BankAccount = Bank_Account
                .Bnk_CodeCo = FindBankCode(CoBank)
                .BankAccountCo = CoBank_Account
                If Bank = "99" Then
                    .PmtMth_Code = "2"
                Else
                    .PmtMth_Code = Pay_Method
                End If
                .StartDate = CDate(SDOE)
                .TerminateDate = ""
                .OtherIncome1 = 0
                .OtherIncome2 = 0
                .OtherIncome3 = 0
                .PreviousEarnings = 0
                .Emp_PrevSIDeduct = 0
                .Emp_PrevSIContribute = 0
                .Emp_PrevITDeduct = 0
                .Emp_PrevPFDeduct = 0
                Dim SS As String
                SS = FindPFCode(PFType, PFDeduction, PFContribution)
                .ProFnd_Code = SS
                SS = FindMFCode(MFType, MFDeduction, MFContribution)
                .MedFnd_Code = SS
                SS = FindSICode(SIType, SIDeduction, SIContribution)
                .SocInc_Code = SS

                .Ind_Code = "0001"
                .Une_Code = "0001"
                .SocCoh_Code = "0001"

                .CreationDate = Now.Date
                .AmendDate = Now.Date
                .CreatedBy = 1
                .AmendBy = 1
                .Emp_GLAnal1 = ""
                .Emp_GLAnal2 = ""
                .Emp_GLAnal3 = ""
                .Emp_GLAnal4 = ""
                .InterfaceTemCode = TempGrp
                .InterfaceMFCode = TempGrp
                .InterfacePFCode = TempGrp


                If Not Emp.Save Then
                    MsgBox("Error loading Employee ")
                    Throw Exx
                End If



                'Salary = Replace(Salary, ",", "")
                'Salary = Replace(Salary, ".", "")

                'Sal = CDbl(Salary / 100)
                '-------------------------------------------------------------
                'Salaries
                '------------------------------------------------------------
                Dim EmpSalary As New cPrTxEmployeeSalary
                With EmpSalary
                    .Id = 0
                    .Emp_Code = Emp.Code
                    .Date1 = Now.Date
                    .SalaryValue = BasicSalary
                    .Basic = BasicSalary
                    .EffPayDate = "2011/01/01"
                    .Cola = 0
                    .EffArrearsDate = "2011/01/01"
                    .Usr_Id = Global1.GLBUserId
                    .IsCola = IsCOLAEnabled
                    .EmpSal_Dif = 0

                    If Not .Save() Then
                        Throw Exx
                        MsgBox("Unable to save Salary of Employee " & Emp.Code)
                    End If
                End With


                '-------------------------------------------------------------
                'Discounts
                '------------------------------------------------------------
                Dim tPrTxEmployeeDiscounts As New cPrTxEmployeeDiscounts(Emp.Code, "201101")
                With tPrTxEmployeeDiscounts
                    .Emp_Code = Emp.Code
                    .PrdGrp_Code = "201101"
                    .Discount1 = Discount
                    .Discount2 = 0
                    .Discount3 = 0
                    .Discount4 = 0
                    .Discount5 = 0
                    .Discount6 = 0
                    .Discount7 = 0
                    .Discount8 = 0
                    .Discount9 = 0
                    .Discount10 = 0
                    .LifeInsurance = LF
                    .Usr_Id = Global1.GLBUserId
                    If .Id = 0 Then
                        .CreationDate = Now.Date
                    End If
                    .AmendDate = Now.Date
                    If Not .Save() Then
                        Throw Exx
                    End If
                End With
            End With
        End If
    End Sub
    Private Function FindPFCode(ByVal Type As String, ByVal Deduction As Double, ByVal Contribution As Double) As String
        Dim Exx As New System.Exception
        If Type = "A" Then
            If Deduction <> 0 Or Contribution <> 0 Then
                MsgBox("PF Amount Deduction" & Deduction & " Contribution" & Contribution)
            End If
            Deduction = 0
            Contribution = 0
        End If
        Dim Ds As DataSet
        Dim CODE As String = ""
        Dim i As Integer
        Ds = Global1.Business.AG_GetAllPrSsProvidentFund
        Dim P As New cPrSsProvidentFund
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                P = New cPrSsProvidentFund(Ds.Tables(0).Rows(i))
                If P.DedValue = Deduction And P.ConValue = Contribution Then
                    CODE = P.Code
                    Exit For
                End If
            Next
        End If
        If CODE = "" Then
            MsgBox("Provident Fund Deduction " & Deduction & " Contribution " & Contribution & " Does not Exits")
            Throw Exx
        End If

        Return CODE
    End Function
    Private Function FindMFCode(ByVal Type As String, ByVal Deduction As Double, ByVal Contribution As Double) As String
        Dim Exx As New System.Exception

        If Type = "A" Then
            If Deduction <> 0 Or Contribution <> 0 Then
                'MsgBox("MF Amount Deduction" & Deduction & " Contribution" & Contribution)
            End If
            Deduction = 0
            Contribution = 0
        End If
        Dim Ds As DataSet
        Dim CODE As String = ""
        Dim i As Integer
        Ds = Global1.Business.AG_GetAllPrSsMedicalFund
        Dim P As New cPrSsMedicalFund
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                P = New cPrSsMedicalFund(Ds.Tables(0).Rows(i))
                If P.DedValue = Deduction And P.ConValue = Contribution Then
                    CODE = P.Code
                    Exit For
                End If
            Next
        End If
        If CODE = "" Then
            MsgBox("Medical F. Deduction " & Deduction & " Contribution " & Contribution & " Does not Exits")
            Throw Exx
        End If

        Return CODE
    End Function
    Private Function FindSICode(ByVal Type As String, ByVal Deduction As Double, ByVal Contribution As Double) As String
        Dim Exx As New System.Exception
        If Type = "A" Then
            If Deduction <> 0 Or Contribution <> 0 Then
                MsgBox("SI Amount Deduction" & Deduction & " Contribution" & Contribution)
            End If
            Deduction = 0
            Contribution = 0
        End If
        Dim Ds As DataSet
        Dim CODE As String = ""
        Dim i As Integer
        Ds = Global1.Business.AG_GetAllPrSsSocialInsurance
        Dim P As New cPrSsSocialInsurance
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                P = New cPrSsSocialInsurance(Ds.Tables(0).Rows(i))
                If P.DedValue = Deduction And P.ConValue = Contribution Then
                    CODE = P.Code
                    Exit For
                End If
            Next
        End If
        If CODE = "" Then
            MsgBox("Social Ins. Deduction " & Deduction & " Contribution " & Contribution & " Does not Exits")
            Throw Exx
        End If
        Return CODE
    End Function
    Private Function FindBankCode(ByVal BankCode) As String
        Dim Ds As DataSet
        Dim i As Integer
        Dim Code As String
        Dim RetValue As String = "BOC"
        Ds = Global1.Business.AG_GetAllPrAnBanks
        For i = 0 To Ds.Tables(0).Rows.Count - 1
            Code = DbNullToString(Ds.Tables(0).Rows(i).Item(4))
            If BankCode = Code Then
                RetValue = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                Exit For
            End If
        Next
        Return RetValue
    End Function

    Private Sub FixEmployeeYTDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixEmployeeYTDToolStripMenuItem.Click
        Dim F As New FrmFixYTD
        F.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Global1.Business.FixCarob()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Global1.Business.FixFoodPoint()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Global1.Business.FixFoodExpress()
    End Sub

    Private Sub MnuExtraTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExtraTax.Click
        Dim F As New FrmPrSsExtraTaxTable
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub MnuSectorPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSectorPay.Click
        Dim F As New FrmPrSsSectorPay
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuDutyHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDutyHours.Click
        Dim F As New FrmPrSsDutyHours
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub mnuOverLay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOverLay.Click
        Dim F As New FrmPrSsOverLay
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub MnuFlightHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuFlightHours.Click
        Dim F As New FrmPrSsFlightHour
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuCommissionRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCommissionRates.Click
        Dim F As New FrmPrSsCommissionRates
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub MnuPerformanceBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPerformanceBonus.Click
        Dim F As New FrmPrSsPerformanceBonus
        F.MdiParent = Me
        F.Show()
    End Sub
    '''
    Private Sub LoadDatabases()
        Dim i As Integer
        Dim N As Integer
        Dim ConnectTo As String
        N = Global1.ServerDatabase.GetUpperBound(0)
        If N = 0 Then
            Exit Sub
        End If

        mnuConnectTo.DropDownItems.Clear()
        For i = 0 To N
            'Dim NewMenu As New MenuItem
            Dim NewMenu As New ToolStripMenuItem
            AddHandler NewMenu.Click, AddressOf ConnectToDatabase
            'NewMenu.Index = i
            ConnectTo = Global1.ServerDatabase(i, 1).ToString & " on " & Global1.ServerDatabase(i, 0).ToString
            NewMenu.Text = ConnectTo
            mnuConnectTo.DropDownItems.Add(NewMenu)

        Next
    End Sub

    Private Sub ConnectToDatabase(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConnectTo.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("This Action will close all Open Forms if any.Continue?", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then


            CloseAllForms()

            Dim i As Integer
            Dim OldUserName As String = Global1.GLBUserCode
            Dim OldPwd As String = Global1.GLBUserPassword
            Dim OldServer As String = Global1.DbaseServerName
            Dim OldDbase As String = Global1.DbaseName
            Dim NewServer As String
            Dim NewDbase As String
            Dim F As New cLogin
            Dim strConnect As String

            i = mnuConnectTo.DropDownItems.IndexOf(CType(sender, ToolStripMenuItem))
            ' i = CInt(CType(sender, MenuItem).Index)

            NewServer = Global1.ServerDatabase(i, 0)
            NewDbase = Global1.ServerDatabase(i, 1)

            If Global1.OpenFormIndex = 0 Then
                Global1.IsConnected = False
                Global1.IsUserEnabled = False
                Global1.UserRole = Roles.NoRole
                Global1.UserName = ""
                Global1.DbaseName = ""
                Global1.DbaseServerName = ""

                Global1.Business = Nothing
                ArrangeMenus()
                ' FrmMain.MdiChildren.AsReadOnly()
                'system.windows.Forms.Application.

                'connect to new database
                'strConnect = "Provider=SQLOLEDB;server=" & NewServer & ";uid=" + OldUserName + ";pwd=" + OldPwd + ";database=" & NewDbase
                If Global1.SQLAuthentication Then
                    strConnect = "Server=" & NewServer & ";Database=" & NewDbase & ";User ID=" + OldUserName + ";Password=" + OldPwd + ";"
                Else
                    strConnect = "Server=" & NewServer & ";Database=" & NewDbase & ";Trusted_Connection=Yes;"
                End If

                If F.TryToConnect(strConnect, True) Then
                    Global1.Business = New cBusiness
                    Dim CUser As New cUsers(OldUserName)
                    If CUser.Id = 0 Then
                        MsgBox("User " & OldUserName & " is not registered", MsgBoxStyle.Critical)
                    Else
                        If CUser.Id > 0 Then
                            Global1.GlobalUser = CUser
                            Global1.GLBUserId = CUser.Id
                            Global1.UserName = CUser.UserName
                            Global1.GLBUserPassword = OldPwd
                            Global1.IsUserEnabled = CUser.IsEnabled
                            Global1.DbaseServerName = NewServer
                            Global1.DbaseName = NewDbase
                            If Not Global1.IsUserEnabled Then
                                MsgBox("User " & Global1.UserName & " is not enabled", MsgBoxStyle.Critical)
                                Exit Sub
                            End If
                            If CUser.IsUserSA Then
                                Global1.UserRole = Roles.Admin
                            ElseIf CUser.MyRole = 1 Then
                                Global1.UserRole = Roles.User
                            ElseIf CUser.MyRole = 2 Then
                                Global1.UserRole = Roles.NoRole
                            End If
                            ArrangeMenus()

                        End If
                    End If

                    'connect to old database
                Else

                    'strConnect = "Provider=SQLOLEDB;server=" & OldServer & ";uid=" + OldUserName + ";pwd=" + OldPwd + ";database=" & OldDbase
                    If Global1.SQLAuthentication Then
                        strConnect = "Server=" & OldServer & ";Database=" & OldDbase & ";User ID=" + OldUserName + ";Password=" + OldPwd + ";"
                    Else
                        strConnect = "Server=" & OldServer & ";Database=" & OldDbase & ";Trusted_Connection=Yes;"
                    End If
                    If F.TryToConnect(strConnect, True) Then
                        MsgBox("Unable to connect to new server.You are now connected to previous connection settings.", MsgBoxStyle.Exclamation)
                        Dim CUser As New cUsers(OldUserName)
                        Global1.Business = New cBusiness
                        If CUser.Id = 0 Then
                            MsgBox("User " & OldUserName & " is not registered", MsgBoxStyle.Critical)
                        Else
                            If CUser.Id > 0 Then
                                Global1.GlobalUser = CUser
                                Global1.GLBUserId = CUser.Id
                                Global1.UserName = CUser.UserName
                                Global1.GLBUserPassword = OldPwd
                                Global1.IsUserEnabled = CUser.IsEnabled
                                Global1.DbaseServerName = OldServer
                                Global1.DbaseName = OldDbase
                                If Not Global1.IsUserEnabled Then
                                    MsgBox("User " & Global1.UserName & " is not enabled", MsgBoxStyle.Critical)
                                    Exit Sub
                                End If
                                If CUser.IsUserSA Then
                                    Global1.UserRole = Roles.Admin
                                ElseIf CUser.MyRole = 1 Then
                                    Global1.UserRole = Roles.User
                                ElseIf CUser.MyRole = 2 Then
                                    Global1.UserRole = Roles.NoRole
                                End If
                                ArrangeMenus()
                            End If
                        End If
                    End If
                End If

                'If Not F.Login(OldUserName, OldPwd, True, NewServer, NewDbase, False) Then
                '    F.Login(OldUserName, OldPwd, True, OldServer, OldDbase, False)
                'End If

            Else
                MsgBox("You have to Close all open forms before changing Company or Server", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub CloseAllForms()
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Dispose()
        Next frm
        Global1.OpenFormIndex = 0

    End Sub

    '''


    Private Sub Create13AverageParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create13AverageParameterToolStripMenuItem.Click
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("System", "Average13")
        If CheckDataSet(Ds) Then
            MsgBox("Parameter already Exist")
        Else
            If Global1.Business.createparameterAverage13() Then
                MsgBox("Parameter Created")
            Else
                MsgBox("Unable to Create Parameter")
            End If

        End If
    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub


    Private Sub LoadExcelTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadExcelTemplateToolStripMenuItem.Click
        LoadTransactions_FromExcelTemplate()
    End Sub

    Private Sub LoadTransactions_FromExcelTemplate()
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim HeaderLine As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try
            Dim Exx As New Exception
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\ExcelTemplate\TestImport.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                If counter = 0 Then
                    HeaderLine = param_file.ReadLine()
                End If
                counter = counter + 1
                Line = param_file.ReadLine()
                Load_TransactionLineET(Line, HeaderLine)

            Loop
            param_file.Close()
            param_file.Dispose()
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            MsgBox("Unable to Load Header", MsgBoxStyle.Critical)
            param_file.Close()
            param_file.Dispose()

        End Try

        Global1.Business.CommitTransaction()
        MsgBox("Header is Succesfully Loaded", MsgBoxStyle.Information)

        Me.PanelfileLoad.Visible = False
    End Sub
    Private Sub Load_TransactionHeaderET(ByVal Line As String)
        Dim TH As New cPrTxTrxnHeader
        Try
            Dim Exx As New Exception
            Dim Ar() As String
            Ar = Line.Split("	")
            Dim Employee_Code As String = Ar(0)
            Dim Period_Group As String = Ar(1)
            Dim Period_Code As String = Ar(2)
            Dim Period_Cat As String = Ar(3)
            Dim Trxn_Date As String = Ar(4)
            Dim Status As String = Ar(5)
            Dim Total_Earnings As Double = CDbl(Replace(Ar(6), ",", "."))
            Dim Prd_Total_Earning_YTD As Double = CDbl(Replace(Ar(7), ",", "."))
            Dim Total_Deductions As Double = CDbl(Replace(Ar(8), ",", "."))
            Dim Prd_Total_Deductions_YTD As Double = CDbl(Replace(Ar(9), ",", "."))
            Dim Total_Contributions As Double = CDbl(Replace(Ar(10), ",", "."))
            Dim Prd_Total_Contributions_YTD As Double = CDbl(Replace(Ar(11), ",", "."))
            Dim SI_Deduct As Double = CDbl(Replace(Ar(12), ",", "."))
            Dim Prd_Taxable_Income As Double = CDbl(Replace(Ar(13), ",", "."))
            Dim Prd_Pmt_Method As String = Ar(14)
            Dim Pay_Ref As String = Ar(15)
            Dim Period_Units As Double = CDbl(Replace(Ar(16), ",", "."))
            Dim Annual_Units As Double = CDbl(Replace(Ar(17), ",", "."))
            Dim Prd_Annual_Leave As Double = CDbl(Replace(Ar(18), ",", "."))
            Dim Life_Ins As Double = 0 'Ar(19)
            Dim Discounts As Double = 0 'Ar(20)
            Dim Int_Status As String = Ar(21)
            Dim OT1 As Double = 0 ' Ar(22)
            Dim OT2 As Double = 0 'Ar(23)
            Dim SI_Units As Double = 0 'Ar(24)
            Dim Monthly_Salary As Double = CDbl(Replace(Ar(25), ",", "."))
            Dim Net_Salary As Double = CDbl(Replace(Ar(26), ",", "."))
            Dim Period_Insurable_Income As Double = CDbl(Replace(Ar(27), ",", "."))
            Dim Template_Group_Code As String = Ar(28)
            Dim Cheque_No As String = Ar(29)

            Ar = Trxn_Date.Split("/")
            Trxn_Date = Ar(2) & "/" & Ar(1) & "/" & Ar(0)

            With TH
                .Emp_Code = Employee_Code
                .PrdGrp_Code = Period_Group
                .PrdCod_Code = Period_Code
                .PayCat_Code = Period_Cat
                .MyDate = Trxn_Date
                .Status = Status
                .TotalErnPeriod = Total_Earnings
                .TotalErnYTD = Prd_Total_Earning_YTD
                .TotalDedPeriod = Total_Deductions
                .TotalDedYTD = Prd_Total_Deductions_YTD
                .TotalConPeriod = Total_Contributions
                .TotalConYTD = Prd_Total_Contributions_YTD
                .SIIncome = SI_Deduct
                .TaxableIncome = Prd_Taxable_Income
                .PaymentMethod = Prd_Pmt_Method
                .PaymentRef = Pay_Ref
                .PeriodUnits = Period_Units
                .AnnualUnits = Annual_Units
                .AnnualLeave = Prd_Annual_Leave
                .LifeInsurance = Life_Ins
                .Discounts = Discounts
                .InterfaceStatus = Int_Status
                .Overtime1 = OT1
                .Overtime2 = OT2
                .SIUnits = SI_Units
                .MonthlySalary = Monthly_Salary
                .NetSalary = Net_Salary
                .PeriodInsurable = Period_Insurable_Income
                .TemGrpCode = Template_Group_Code
                .ChequeNo = Cheque_No
                If Not .Save Then
                    Throw Exx
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Function Load_TransactionLineET(ByVal Line As String, ByVal HeaderLine As String) As Integer
        Try

            Dim Header As New cPrTxTrxnHeader
            Dim Salary As Double = 0
            Dim Exx As New Exception
            Dim Ar() As String
            Dim ArH() As String
            Dim HT As String

            ArH = HeaderLine.Split("	")
            Ar = Line.Split("	")


            Dim Company As String = ""
            Dim Employee As String = ""
            Dim Year As String = ""
            Dim Period As String = ""
            Dim Insurable As Double = 0
            Dim Units As Double = 0
            Dim EDC As Double = 0
            Dim EDCString As String = ""
            Dim LastName As String = ""
            Dim FirstName As String = ""
            Dim TemplateCode As String = ""
            Dim PeriodGroup As String = ""
            Dim YTDValue As Double = 0
            Dim Discount As Double = 0
            Dim LifeInsurance As Double = 0
            Dim IncomeFromOther As Double = 0
            Dim SILeave As Double = 0

            Dim i As Integer
            Dim k As Integer
            'For i = 0 To Ar.Length - 1
            Dim ArrLen As Integer = 30
            ArrLen = ArrLen - 1
            For i = 0 To ArrLen 'ArH(i).Length - 1
                HT = ArH(i)
                If HT = "COMP" Then
                    Company = Ar(i)
                ElseIf HT = "TEMPGRP" Then
                    TemplateCode = Ar(i)
                ElseIf HT = "EMP" Then
                    Employee = Ar(i)
                ElseIf HT = "YEAR" Then
                    Year = Ar(i)
                ElseIf HT = "PER" Then
                    Period = Ar(i)
                ElseIf HT = "PERGRP" Then
                    PeriodGroup = Ar(i)
                ElseIf HT = "INSU" Then
                    Insurable = Replace(Ar(i), ",", ".")
                ElseIf HT = "UNITS" Then
                    Units = Replace(Ar(i), ",", ".")
                ElseIf HT = "LASTNAME" Then
                    LastName = Ar(i)
                ElseIf HT = "FIRSTNAME" Then
                    FirstName = Ar(i)
                ElseIf HT = "LI" Then
                    If Ar(i) <> "" Then
                        LifeInsurance = Replace(Ar(i), ",", ".")
                    Else
                        LifeInsurance = 0
                    End If
                ElseIf HT = "DIS" Then
                    If Ar(i) <> "" Then
                        Discount = Replace(Ar(i), ",", ".")
                    Else
                        Discount = 0
                    End If

                ElseIf HT = "TFO" Then
                    If Ar(i) <> "" Then
                        IncomeFromOther = Replace(Ar(i), ",", ".")
                    Else
                        IncomeFromOther = 0
                    End If

                ElseIf HT = "E5" Then
                    If Ar(i) <> "" Then
                        SILeave = Replace(Ar(i), ",", ".")
                    Else
                        SILeave = 0
                    End If

                End If


            Next
            Dim Emp As New cPrMsEmployees(Employee)
            If Emp.Code Is Nothing Or Emp.Code = "" Then
                'Add New
                With Emp
                    .Code = Employee
                    .Status = "A"
                    .PayTyp_Code = "M01"
                    .TemGrp_Code = TemplateCode
                    .InterfaceTemCode = TemplateCode
                    .InterfaceMFCode = TemplateCode
                    .InterfacePFCode = TemplateCode
                    .Emp_GLAnal1 = ""
                    .Emp_GLAnal2 = ""
                    .Emp_GLAnal3 = ""
                    .Emp_GLAnal4 = ""
                    .EmpSta_Code = "A"
                    .Title = "MR"
                    .LastName = LastName
                    .FirstName = FirstName
                    .FullName = LastName & " " & FirstName
                    .Sex = "M"
                    .BirthDate = Now.Date
                    .MarSta_Code = "S"
                    .Address1 = ""
                    .Address2 = ""
                    .Address3 = ""
                    '.Addres4 = Address4
                    .PostCode = ""
                    .Telephone1 = ""
                    .Telephone2 = ""
                    .Email = ""
                    .SocialInsNumber = ""
                    .ComSin_EmpSocialInsNo = ""
                    .IdentificationCard = ""
                    .TaxID = ""
                    .PassportNumber = ""
                    .AlienNumber = ""
                    .TicTyp_Code = 1
                    .EmpAn1_Code = "01"
                    .EmpAn2_Code = "02"
                    .EmpAn3_Code = "03"
                    .EmpAn4_Code = "04"
                    .EmpAn5_Code = "05"
                    .Uni_Code = "UNION1"
                    .Cou_Code = "CY"
                    .EmpPos_Code = "01"
                    .Sic_Code = "M1"
                    .EmpCmm_Code = "E"
                    .PayUni_Code = 1
                    .PeriodUnits = 0
                    .AnnualUnits = 0
                    .Cur_Code = "EUR"
                    .PmtMth_Code = "1"
                    .Bnk_Code = "BOC"
                    .BankAccount = ""
                    .Bnk_CodeCo = "BOC"
                    .BankAccountCo = ""
                    .StartDate = Now.Date
                    .TerminateDate = ""
                    .OtherIncome1 = 0
                    .OtherIncome2 = 0
                    .OtherIncome3 = 0
                    .PreviousEarnings = 0
                    .Emp_PrevSIDeduct = 0
                    .Emp_PrevSIContribute = 0
                    .Emp_PrevITDeduct = 0
                    .Emp_PrevPFDeduct = 0
                    .ProFnd_Code = "0001"
                    .MedFnd_Code = "0001"
                    .SocInc_Code = "0001"
                    .Ind_Code = "0001"
                    .Une_Code = "0001"
                    .SocCoh_Code = "0001"
                    .DrivingLicense = ""
                    .MyPayslipReport = ""
                    .IBAN = ""
                    .CreationDate = Now.Date
                    .AmendDate = Now.Date
                    .CreatedBy = 1
                    .AmendBy = 1
                    .SectorPay = "0000"
                    .DutyHours = "0000"
                    .FlightHours = "0000"
                    .PerformanceBonus = "0000"
                    .CommissionRate = "0000"
                    .Password = ""


                    If Not Emp.Save Then
                        Throw Exx
                    End If
                End With
            End If
            Dim Found As Boolean = False
            Dim Type As String
            Dim LineNo As Integer
            Dim TotalERN As Double = 0
            Dim TotalDED As Double = 0
            Dim TotalCON As Double = 0
            Dim SIDeduction As Double = 0
            Dim SIContribution As Double = 0


            'For i = 0 To Ar.Length - 1
            For i = 0 To ArrLen 'ArH(i).Length - 1
                LineNo = LineNo + 1
                Found = False
                Type = ""
                HT = ArH(i)

                If HT <> "COMP" And HT <> "EMP" And HT <> "YEAR" And HT <> "PER" And HT <> "INSU" And HT <> "UNITS" And HT <> "PERGRP" And HT <> "TEMPGRP" And HT <> "LASTNAME" And HT <> "FIRSTNAME" And HT <> "" And HT <> "DIS" And HT <> "LI" And HT <> "TFO" Then
                    EDC = Replace(Ar(i), ",", ".")
                    Found = True
                End If
                Dim E_Code As String = ""
                Dim D_Code As String = ""
                Dim C_Code As String = ""

                Dim Ds As DataSet

                If Found Then
                    If HT.Contains("E") Then
                        E_Code = HT
                        Type = "E"
                        If HT = "E1" Then
                            Salary = EDC
                        End If
                        TotalERN = TotalERN + EDC
                    ElseIf HT.Contains("D") Then
                        D_Code = HT
                        Type = "D"
                        TotalDED = TotalDED + EDC
                        If HT = "D7" Then
                            SIDeduction = EDC
                        End If
                    ElseIf HT.Contains("C") Then
                        If Not HT.Contains("CA") Then
                            C_Code = HT
                            Type = "C"
                            TotalCON = TotalCON + EDC
                            If HT = "C4" Then
                                SIContribution = EDC
                            End If
                        End If
                    End If

                    Header = New cPrTxTrxnHeader(Employee, Period)
                    If Header.Id = 0 Then
                        If Insurable > 4533 Then
                            Insurable = 4533
                        End If
                        With Header
                            .Emp_Code = Employee
                            .PrdGrp_Code = PeriodGroup
                            .PrdCod_Code = Period
                            .PayCat_Code = "K"
                            .MyDate = Now.Date
                            .Status = "POST"
                            .TotalErnPeriod = 0
                            .TotalErnYTD = 0
                            .TotalDedPeriod = 0
                            .TotalDedYTD = 0
                            .TotalConPeriod = 0
                            .TotalConYTD = 0
                            .SIIncome = 0
                            .TaxableIncome = 0
                            .PaymentMethod = "BANK"
                            .PaymentRef = ""
                            .PeriodUnits = 0
                            .AnnualUnits = 0
                            .AnnualLeave = 0
                            .LifeInsurance = LifeInsurance
                            .Discounts = Discount
                            .InterfaceStatus = "POST"
                            .Overtime1 = 0
                            .Overtime2 = 0
                            .SIUnits = 0
                            .MonthlySalary = Salary
                            .NetSalary = 0
                            .PeriodInsurable = Insurable
                            .TemGrpCode = TemplateCode
                            .ChequeNo = ""
                            .TaxableFromOther = IncomeFromOther
                            .NormalDays = 0
                            .Salary1 = 0
                            .Salary2 = 0
                            If Not .Save Then
                                Throw Exx
                            End If
                        End With
                    End If
                    '--------------------------------------------------------------

                    Ds = Global1.Business.FindYTD(Type, E_Code, D_Code, C_Code, Employee, Period, Header.Id)
                    If CheckDataSet(Ds) Then
                        YTDValue = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
                    Else
                        YTDValue = 0
                    End If
                    YTDValue = YTDValue + EDC
                    '--------------------------------------------------------------

                    Dim YTD_Value As Double = 0 'Ar(9)
                    Dim LineEDC As Double = 0 ' Ar(10)
                    Dim Description As String = Ar(11)

                    Dim L As New cPrTxTrxnLines

                    If Header.Id > 0 Then
                        With L
                            .TrxHdr_Id = Header.Id
                            .TrxLin_Id = LineNo
                            .TrxLin_Type = Type
                            Select Case Type
                                Case "E"
                                    .ErnCod_Code = E_Code
                                    Dim Ern As New cPrMsEarningCodes(E_Code)
                                    Description = Ern.DescriptionS
                                Case "D"
                                    .DedCod_Code = D_Code
                                    Dim Ded As New cPrMsDeductionCodes(D_Code)
                                    Description = Ded.DescriptionS
                                Case "C"
                                    .ConCod_Code = C_Code
                                    Dim Con As New cPrMsContributionCodes(C_Code)
                                    Description = Con.DescriptionS
                            End Select

                            .TrxLin_PeriodValue = EDC
                            .TrxLin_YTDValue = YTDValue
                            .TrxLin_EDC = LineEDC
                            .TrxLin_EDCDescription = Description
                            If Not .Save Then
                                Throw Exx
                            End If
                        End With
                    Else
                        MsgBox("Header not Found")
                    End If
                End If
            Next

            Dim YTDUnits As Double = 0
            Dim YTDErn As Double = 0
            Dim YTDded As Double = 0
            Dim YTDcon As Double = 0

            Dim Ds1 As DataSet
            Ds1 = Global1.Business.FindHeaderYTD(Header.Emp_Code, Header.PrdGrp_Code, Header.TemGrpCode, Header.PrdCod_Code)
            If CheckDataSet(Ds1) Then
                YTDUnits = DbNullToDouble(Ds1.Tables(0).Rows(0).Item(0)) + Units
                YTDErn = DbNullToDouble(Ds1.Tables(0).Rows(0).Item(1)) + TotalERN
                YTDded = DbNullToDouble(Ds1.Tables(0).Rows(0).Item(2)) + TotalDED
                YTDcon = DbNullToDouble(Ds1.Tables(0).Rows(0).Item(3)) + TotalCON
            End If
            With Header
                .TotalErnPeriod = TotalERN - SILeave
                .TotalDedPeriod = TotalDED
                .TotalConPeriod = TotalCON
                .PeriodInsurable = Insurable
                .MonthlySalary = Salary
                .NetSalary = TotalERN - TotalDED - SILeave
                .PeriodUnits = Units
                .AnnualUnits = YTDUnits
                .TotalErnYTD = YTDErn - SILeave
                .TotalDedYTD = YTDded
                .TotalConYTD = YTDcon
                .TaxableIncome = TotalERN
                .SIIncome = SIDeduction

                If Not .Save Then
                    Throw Exx
                End If
            End With

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Function
    Private Sub mnuLoadInterfaceTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadInterfaceTemplate.Click
        LoadInterfaceTemplate_FromExcelTemplate()
    End Sub
    Private Sub LoadInterfaceTemplate_FromExcelTemplate()
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim HeaderLine As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0
        '''
        FileDir = "Data\ExcelTemplateInt\"
        Files = IO.Directory.GetFiles(FileDir)




        Me.Refresh()

        For i = 0 To Files.Length - 1



            Me.Refresh()

            FileName = Files(i)




            Try
                Dim Exx As New Exception
                param_file = IO.File.OpenText(FileName)
                'param_file = IO.File.OpenText("Data\ExcelTemplateInt\TestImport.txt")
                LoadedOK = False

                Do While param_file.Peek <> -1
                    Me.Refresh()
                    counter = counter + 1
                    Line = param_file.ReadLine()
                    Load_InterfaceLineET(Line)
                Loop
                param_file.Close()
                param_file.Dispose()
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Load Interface Line", MsgBoxStyle.Critical)
                param_file.Close()
                param_file.Dispose()

            End Try
        Next
        Global1.Business.CommitTransaction()
        MsgBox("Interface is Succesfully Loaded", MsgBoxStyle.Information)

        Me.PanelfileLoad.Visible = False

    End Sub
    Private Function Load_InterfaceLineET(ByVal Line As String) As Integer
        Try


            Dim Exx As New Exception
            Dim Ar() As String


            Ar = Line.Split("	")

            Dim TempGrp As String = ""
            Dim IntGrp As String = ""
            Dim EDC As String = ""
            Dim EDCDesc As String = ""
            Dim DebitAcc As String = ""
            Dim CreditAcc As String = ""
            Dim Prefix As String = ""

            Dim i As Integer
            Dim k As Integer
            'For i = 0 To Ar.Length - 1
            Dim ArrLen As Integer = 7


            TempGrp = Ar(0)
            IntGrp = Ar(1)
            EDC = Ar(2)
            EDCDesc = Ar(3)
            DebitAcc = Ar(4)
            CreditAcc = Ar(5)
            Prefix = Ar(6)

            Dim EDCExists As Boolean = False

            If EDC.StartsWith("E") Then
                Dim TempErn As New cPrMsTemplateEarnings(TempGrp, EDC)
                If TempErn.Id > 0 Then
                    EDCExists = True
                End If
            ElseIf EDC.StartsWith("D") Then
                Dim TempDed As New cPrMsTemplateDeductions(TempGrp, EDC)
                If TempDed.Id > 0 Then
                    EDCExists = True
                End If

            ElseIf EDC.StartsWith("C") Then
                Dim TempCon As New cPrMsTemplateContributions(TempGrp, EDC)
                If TempCon.Id > 0 Then
                    EDCExists = True
                End If

            End If

            If EDCExists Then
                Dim DebitAccountWithPrefix As String
                DebitAccountWithPrefix = Prefix & "-" & DebitAcc

                Dim IC1 As New cPrMsInterfaceCodes(TempGrp, DebitAccountWithPrefix)
                With IC1
                    If .Code = "" Or .Code Is Nothing Then
                        .Code = DebitAccountWithPrefix
                        .AccountType = 0
                        .Description = DebitAcc
                        .TemGrpCode = TempGrp
                        If Not .Save Then
                            Throw Exx
                        End If
                        For i = 0 To DebitAcc.Length - 1
                            Dim cm As New cPrMsCodeMasking()
                            cm.IntCode = DebitAccountWithPrefix
                            cm.Position = i + 1
                            cm.Type = 0
                            cm.Value = DebitAcc.Substring(i, 1)
                            If Not cm.Save Then
                                Throw Exx
                            End If
                        Next
                    End If
                End With
                Dim CreditAccountWithPrefix As String
                CreditAccountWithPrefix = Prefix & "-" & CreditAcc
                Dim IC2 As New cPrMsInterfaceCodes(TempGrp, CreditAccountWithPrefix)
                With IC2
                    If .Code = "" Or .Code Is Nothing Then
                        .Code = CreditAccountWithPrefix
                        .AccountType = 0
                        .Description = CreditAcc
                        .TemGrpCode = TempGrp
                        If Not .Save Then
                            Throw Exx
                        End If

                        For i = 0 To CreditAcc.Length - 1
                            Dim cm As New cPrMsCodeMasking()
                            cm.IntCode = CreditAccountWithPrefix
                            cm.Position = i + 1
                            cm.Type = 0
                            cm.Value = CreditAcc.Substring(i, 1)
                            If Not cm.Save Then
                                Throw Exx
                            End If
                        Next
                    End If
                End With
                If EDC.StartsWith("E") Then
                    Dim E As New cPrMsEarningsInterface(TempGrp, IntGrp, EDC)
                    If E.Id = 0 Then
                        E.TemGrpCode = TempGrp
                        E.IntTemCode = IntGrp
                        E.ErnCode = EDC
                        E.DebitAccount = DebitAccountWithPrefix
                        E.CreditAccount = CreditAccountWithPrefix
                        E.CreditConsol = 3
                        E.DebitConsol = 3
                        E.DebitAnal = ""
                        E.CreditAnal = ""
                        If Not E.Save Then
                            Throw Exx
                        End If
                    End If
                ElseIf EDC.StartsWith("D") Then
                    Dim D As New cPrMsDeductionsInterface(TempGrp, IntGrp, EDC)
                    If D.Id = 0 Then
                        D.TemGrpCode = TempGrp
                        D.IntTemCode = IntGrp
                        D.DedCode = EDC
                        D.DebitAccount = DebitAccountWithPrefix
                        D.CreditAccount = CreditAccountWithPrefix
                        D.CreditConsol = 3
                        D.DebitConsol = 3
                        D.DebitAnal = ""
                        D.CreditAnal = ""
                        If Not D.Save Then
                            Throw Exx
                        End If
                    End If

                ElseIf EDC.StartsWith("C") Then
                    Dim C As New cPrMsContributionsInterface(TempGrp, IntGrp, EDC)
                    If C.Id = 0 Then
                        C.TemGrpCode = TempGrp
                        C.IntTemCode = IntGrp
                        C.ConCode = EDC
                        C.DebitAccount = DebitAccountWithPrefix
                        C.CreditAccount = CreditAccountWithPrefix
                        C.CreditConsol = 3
                        C.DebitConsol = 3
                        C.DebitAnal = ""
                        C.CreditAnal = ""
                        If Not C.Save Then
                            Throw Exx
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Function


    Private Sub LoadSalary12ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSalary12ToolStripMenuItem.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Salary.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Salary_1_2(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Salary - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
    End Sub
    Private Sub Load_Salary_1_2(ByVal Line As String)
        Dim Exx As New Exception



        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")
        Dim EmpCode As String = Trim(Ar(0))
        Dim Salary1 As String = Trim(Ar(3))
        Dim Salary2 As String = Trim(Ar(4))
        Dim TotalSalary As Double

        Salary1 = Salary1.Replace(",", ".")
        Salary2 = Salary2.Replace(",", ".")

        If Not IsNumeric(Salary1) Then
            Salary1 = "0"
        End If
        If Not IsNumeric(Salary2) Then
            Salary2 = "0"
        End If

        TotalSalary = CDbl(Salary1) + CDbl(Salary2)
        Dim emp As New cPrMsEmployees(EmpCode)
        If emp.Code <> "" Or Not IsNothing(emp.Code) Then


            Dim S As New cPrTxEmployeeSalary
            With S
                .Id = 0
                .Emp_Code = EmpCode
                .Date1 = Now.Date
                .SalaryValue = CDbl(TotalSalary)
                .Basic = CDbl(Salary1)
                .Cola = CDbl(Salary2)
                .EffPayDate = Now.Date
                .EffArrearsDate = Now.Date
                .Usr_Id = Global1.GLBUserId


                .IsCola = "N"
                .EmpSal_Dif = 0

                If Not .Save() Then
                    Throw Exx
                End If

            End With
        End If

    End Sub

    Private Sub LoadAnnualLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadAnnualLeaveToolStripMenuItem.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\AnnualLeave.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_AnnualLeave(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Annual Leave - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
    End Sub
    Private Sub Load_AnnualLeave(ByVal Line As String)

        Dim Exx As New SystemException
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")
        Dim EmpCode As String = Trim(Ar(0))
        Dim Days As String = Trim(Ar(7))


        Days = Days.Replace(",", ".")
        Dim Units As Double
        Units = RoundMe2(Days * 8, 2)

        Dim emp As New cPrMsEmployees(EmpCode)
        If emp.Code <> "" Or Not IsNothing(emp.Code) Then

            Global1.Business.DeleteAllAnnualLeaveOfEmployeeCode(emp.Code)
            Dim S As New cPrTxEmployeeLeave
            With S
                .Id = 0
                .EmpCode = EmpCode
                .Status = "Approved"
                .Type = "1"
                .ReqDate = Now.Date
                .ProcDate = Now.Date
                .FromDate = Now.Date
                .ToDate = Now.Date
                .ProcBy = Global1.GLBUserId
                .Units = Units
                .Action = "IN"
                If Not .Save() Then
                    Throw Exx
                End If

            End With
        End If

    End Sub

    Private Sub LoadSalary12PartTimersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSalary12PartTimersToolStripMenuItem.Click

        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\SalaryPart.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Salary_1_2_Part(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Salary - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
        Me.PanelfileLoad.Visible = False
        Me.Refresh()
    End Sub
    Private Sub Load_Salary_1_2_Part(ByVal Line As String)

        Dim Exx As New SystemException

        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")
        Dim EmpCode As String = Trim(Ar(0))
        Dim Salary1 As String = Trim(Ar(4))
        Dim Salary2 As String = Trim(Ar(5))
        Dim TotalSalary As Double

        Salary1 = Salary1.Replace(",", ".")
        Salary2 = Salary2.Replace(",", ".")

        If Not IsNumeric(Salary1) Then
            Salary1 = "0"
        End If
        If Not IsNumeric(Salary2) Then
            Salary2 = "0"
        End If

        TotalSalary = CDbl(Salary1) + CDbl(Salary2)

        Dim emp As New cPrMsEmployees(EmpCode)
        If emp.Code <> "" Or Not IsNothing(emp.Code) Then

            Dim S As New cPrTxEmployeeSalary
            With S
                .Id = 0
                .Emp_Code = EmpCode
                .Date1 = Now.Date
                .SalaryValue = CDbl(TotalSalary)
                .Basic = CDbl(Salary1)
                .Cola = CDbl(Salary2)
                .EffPayDate = Now.Date
                .EffArrearsDate = Now.Date
                .Usr_Id = Global1.GLBUserId


                .IsCola = "N"
                .EmpSal_Dif = 0

                If Not .Save() Then
                    Throw Exx
                End If

            End With
        End If

    End Sub

    Private Sub UpgradeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeToolStripMenuItem.Click
        If Global1.Business.Upgrade2016() Then
            MsgBox("succesfull Upgrade to 2016 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2016 Version", MsgBoxStyle.Critical)
        End If

    End Sub


    Private Sub AirlinesUpgradeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirlinesUpgradeToolStripMenuItem.Click
        If Global1.Business.Upgrade2016_B() Then
            If Global1.Business.CreateValuesOnAirlinesTables() Then

                MsgBox("succesfull Upgrade to 2016 Airlines", MsgBoxStyle.Information)
            Else
                MsgBox("Failed to Upgrade to 2016 Airlines", MsgBoxStyle.Critical)
            End If
        Else

        End If
    End Sub

    Private Sub LoadEmployeeIBANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadEmployeeIBANToolStripMenuItem.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data\Employees\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Employees\IBAN.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_EmployeeIBAN(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Employees - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try

    End Sub

    Private Sub LoadAnalysis2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadAnalysis2ToolStripMenuItem.Click
        Dim Files() As String
        Dim i As Integer
        Dim Line As String = String.Empty
        Dim counter As Integer = 0
        Dim LoadedOK As Boolean = False
        Dim param_file As IO.StreamReader
        Dim FileDir As String

        FileDir = "Data\Employees\"
        Files = IO.Directory.GetFiles(FileDir)
        Me.PanelfileLoad.Visible = True
        Me.Refresh()
        Global1.Business.BeginTransaction()
        counter = 0

        Try

            FileName = Files(i)
            Global1.FileName = FileName
            param_file = IO.File.OpenText("Data\Employees\analysis2.txt")
            LoadedOK = False

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine()
                Load_Analysis2(Line)
            Loop
            param_file.Close()
            param_file.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Analysis - LOADED OK", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            param_file.Close()
            param_file.Dispose()
        End Try
    End Sub
    Private Sub Load_Analysis2(ByVal Line As String)
        Dim Exx As New Exception
        Dim Ar() As String
        Ar = Line.Split("	")
        ' Ar = Line.Split("|")


        Dim Code As String = Trim(Ar(0))
        Dim Desc As String = Trim(Ar(1))
        Dim DescL As String
        If Desc.Length > 40 Then
            DescL = Desc.Substring(0, 39)
        Else
            DescL = Desc
        End If

        Dim DescS As String
        If Desc.Length > 15 Then
            DescS = Desc.Substring(0, 14)
        Else
            DescS = Desc
        End If



        Dim Anl2 As New cPrMsEmployees(Code)

        Dim AN2 As New cPrAnEmployeeAnalysis2(Code)
        If AN2.Code = "" Then
            With AN2
                .Code = Code
                .DescriptionL = DescL
                .DescriptionS = DescS
                .IsActive = "Y"
                .GLAnal1 = Code
                .GLAnal2 = 0
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                If Not .Save() Then
                    Throw Exx
                    MsgBox("Unable to Save Analysis2 Code:" & Code)
                End If
            End With

        End If
    End Sub


    Private Sub UpgradeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeToolStripMenuItem1.Click
        If Global1.Business.Upgrade2016_C() Then
            If Global1.Business.CreateValuesOnAirlinesTables2() Then
                Global1.Business.SetAirlinesDefault()
                MsgBox("succesfull Upgrade to 2016 2 Upgrade", MsgBoxStyle.Information)
            Else
                MsgBox("Failed to Upgrade to 2016 2 Upgrade", MsgBoxStyle.Critical)
            End If
        Else

        End If
    End Sub

    Private Sub mnuChangeMyPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeMyPass.Click
        Dim F As New FrmChangePassword
        F.ShowDialog()
    End Sub
    Private Sub DeleteRecordsFromHCMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRecordsFromHCMToolStripMenuItem.Click
        DeleteRecordsFromHCM()
    End Sub
    Private Sub DeleteRecordsFromHCM()

        'I'm declaring a connectionobject within this class called pCn
        Dim pCn As OleDb.OleDbConnection
        Dim AccessDBFile As String


        If Global1.PARAM_HCMdatabasePath = "" Then
            MsgBox("Please define HCM system Database path", MsgBoxStyle.Critical)
            Exit Sub
        End If

        AccessDBFile = Global1.PARAM_HCMdatabasePath
        'AccessDBFile = "C:\Program Files (x86)\Exelsys Ltd\Exelsys HCM Sync\DB\ExelsysHCMGSync.accdb"

        Dim Str2 As String = ""




        Try


            'on form load instantiate the connection object
            pCn = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & AccessDBFile & ";Persist Security Info=False;")
            Try
                'try to open the connection
                Call pCn.Open()
            Catch ex As Exception
                MessageBox.Show("Could not connect for some reason.... is the file on the right location? --> check connectionstring")
            End Try

            If pCn.State = ConnectionState.Open Then
                Str2 = "Delete from Employee"

                Dim SQL2 As New OleDb.OleDbCommand(Str2, pCn)
                Dim DataAdapter2 As New OleDb.OleDbDataAdapter(SQL2)

                Dim DT2 As New DataTable("Delete")
                DataAdapter2.Fill(DT2)
                MsgBox("Finish HCM initialization", MsgBoxStyle.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDataFromHCMsystem(ByVal OnlyNewEmployees As Boolean)
        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        'I'm declaring a connectionobject within this class called pCn
        Dim pCn As OleDb.OleDbConnection
        Dim AccessDBFile As String


        If Global1.PARAM_HCMdatabasePath = "" Then
            MsgBox("Please define HCM system Database path", MsgBoxStyle.Critical)
            Exit Sub
        End If

        AccessDBFile = Global1.PARAM_HCMdatabasePath
        'AccessDBFile = "C:\Program Files (x86)\Exelsys Ltd\Exelsys HCM Sync\DB\ExelsysHCMGSync.accdb"




        Try
            'on form load instantiate the connection object
            pCn = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & AccessDBFile & ";Persist Security Info=False;")
            Try
                'try to open the connection
                Call pCn.Open()
            Catch ex As Exception
                MessageBox.Show("Could not connect for some reason.... is the file on the right location? --> check connectionstring")
            End Try

            If pCn.State = ConnectionState.Open Then
                Dim Str As String = ""


                Str = "Select FirstName," &
                " MiddleName," &
                " LastName," &
                " EmployeeCode," &
                " Gender," &
                " JobTitle," &
                " BirthDate," &
                " Status," &
                " EmploymentDate," &
                " MaritalStatus," &
                " SocialSecurityNo," &
                " IdentityCardNo," &
                " PassportNo," &
                " IncomeTaxNo," &
                " WorkEMail," &
                " DepartmentCode," &
                " PayrollNo," &
                " BankName," &
                " BankAccountNo," &
                " IBAN," &
                " SWIFT," &
                " TerminationDate," &
                " AddressLine1," &
                " AddressLine2," &
                " AddressLine3," &
                " PostCode," &
                " POBox," &
                " POBoxPostCode," &
                " City," &
                " PhoneNo," &
                " MobilePhone," &
                " Email, " &
                " JobDescriptionCode," &
                " EmployeeJobDescription," &
                " PayrollCompanyNo  " &
                " FROM Employee"
                '" EmployeestatisticalCode " & _




                Dim SQL As New OleDb.OleDbCommand(Str, pCn)
                Dim DataAdapter As New OleDb.OleDbDataAdapter(SQL)

                'Create a datatable to house the results from the query


                Dim DT As New DataTable("Employee")

                'Bash the query results in the datatable
                DataAdapter.Fill(DT)


                If Not DT Is Nothing Then

                    Dim FirstName As String
                    Dim MiddleName As String
                    Dim LastName As String
                    Dim EmployeeCode As String
                    Dim Gender As String
                    Dim JobTitle As String
                    Dim BirthDate As String
                    Dim Status As String
                    Dim EmploymentDate As String
                    Dim MaritalStatus As String
                    Dim SocialSecurityNo As String
                    Dim IdentityCardNo As String
                    Dim PassportNo As String
                    Dim IncomeTaxNo As String
                    Dim WorkEMail As String
                    Dim DepartmentCode As String
                    'Dim PayrollNo As String
                    Dim BankName As String
                    Dim BankAccountNo As String
                    Dim IBAN As String
                    Dim SWIFT As String
                    Dim TerminationDate As String
                    Dim AddressLine1 As String
                    Dim AddressLine2 As String
                    Dim AddressLine3 As String
                    Dim PostCode As String
                    Dim POBox As String
                    Dim POBoxPostCode As String
                    Dim City As String
                    Dim PhoneNo As String
                    Dim MobilePhone As String
                    Dim Email As String
                    Dim JobDescriptionCode As String
                    Dim EmployeeJobDescription As String
                    Dim PayrollCompanyNo As String
                    Dim TemplateGroupCode As String
                    ''''''''''''''''''''''''''''''''''''''''''''''
                    'FindDefaults()
                    Dim dsTemplateGroup As DataSet
                    Dim dsAnal1 As DataSet
                    Dim dsAnal2 As DataSet
                    Dim dsAnal3 As DataSet
                    Dim dsAnal4 As DataSet
                    Dim dsAnal5 As DataSet
                    Dim dsUnions As DataSet
                    Dim dsCountries As DataSet
                    Dim dsEmpPosition As DataSet
                    Dim dsSIcategory As DataSet
                    Dim dsEmpCommunity As DataSet
                    Dim dsPayUnits As DataSet
                    Dim dsCurCode As DataSet
                    Dim dsPayMethods As DataSet
                    Dim dsBanks As DataSet
                    Dim dsTaxCardtype As DataSet
                    Dim dsProFund As DataSet
                    Dim dsMedicalFund As DataSet
                    Dim dsSocialInsurance As DataSet
                    Dim dsIndustrial As DataSet
                    Dim dsUnemployment As DataSet
                    Dim dsSocialCohesion As DataSet
                    Dim dsSectorPay As DataSet
                    Dim dsCommissionRates As DataSet
                    Dim dsPerformanceBonus As DataSet
                    Dim dsdutyHours As DataSet
                    Dim dsOverLay As DataSet
                    Dim dsFlightHours As DataSet
                    Dim ContinueWithLoading As Boolean




                    dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                    dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                    dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                    dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                    dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                    dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                    dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                    dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                    dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                    dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                    dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                    dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                    dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                    dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                    dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                    dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                    dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                    dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                    dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                    dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                    dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                    dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                    dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                    dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                    dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                    dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                    dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour

                    '''''''''''''''''''''''''''''''''''''''''''''''

                    Dim i As Integer

                    Try
                        Dim Exx As New Exception



                        Global1.Business.BeginTransaction()


                        For i = 0 To DT.Rows.Count - 1
                            ContinueWithLoading = True
                            FirstName = DbNullToString(DT.Rows(i).Item(0))
                            MiddleName = DbNullToString(DT.Rows(i).Item(1))
                            LastName = DbNullToString(DT.Rows(i).Item(2))
                            EmployeeCode = DbNullToString(DT.Rows(i).Item(3))
                            Gender = DbNullToString(DT.Rows(i).Item(4))
                            JobTitle = DbNullToString(DT.Rows(i).Item(5))
                            BirthDate = DbNullToString(DT.Rows(i).Item(6))
                            Status = DbNullToString(DT.Rows(i).Item(7))
                            EmploymentDate = DbNullToString(DT.Rows(i).Item(8))
                            MaritalStatus = DbNullToString(DT.Rows(i).Item(9))
                            SocialSecurityNo = DbNullToString(DT.Rows(i).Item(10))
                            IdentityCardNo = DbNullToString(DT.Rows(i).Item(11))
                            PassportNo = DbNullToString(DT.Rows(i).Item(12))
                            IncomeTaxNo = DbNullToString(DT.Rows(i).Item(13))
                            WorkEMail = DbNullToString(DT.Rows(i).Item(14))
                            DepartmentCode = DbNullToString(DT.Rows(i).Item(15))
                            'PayrollNo = DbNullToString(DT.Rows(i).Item(16))
                            BankName = DbNullToString(DT.Rows(i).Item(17))
                            BankAccountNo = DbNullToString(DT.Rows(i).Item(18))
                            IBAN = DbNullToString(DT.Rows(i).Item(19))
                            SWIFT = DbNullToString(DT.Rows(i).Item(20))
                            TerminationDate = DbNullToString(DT.Rows(i).Item(21))
                            AddressLine1 = DbNullToString(DT.Rows(i).Item(22))
                            AddressLine2 = DbNullToString(DT.Rows(i).Item(23))
                            AddressLine3 = DbNullToString(DT.Rows(i).Item(24))
                            PostCode = DbNullToString(DT.Rows(i).Item(25))
                            POBox = DbNullToString(DT.Rows(i).Item(26))
                            POBoxPostCode = DbNullToString(DT.Rows(i).Item(27))
                            City = DbNullToString(DT.Rows(i).Item(28))
                            PhoneNo = DbNullToString(DT.Rows(i).Item(29))
                            MobilePhone = DbNullToString(DT.Rows(i).Item(30))
                            Email = DbNullToString(DT.Rows(i).Item(31))
                            JobDescriptionCode = DbNullToString(DT.Rows(i).Item(32))
                            EmployeeJobDescription = DbNullToString(DT.Rows(i).Item(33))
                            PayrollCompanyNo = DbNullToString(DT.Rows(i).Item(34))


                            'TemplateGroupCode = DbNullToString(DT.Rows(i).Item(35))

                            TemplateGroupCode = Global1.PARAM_HCMTempGroup

                            '

                            dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                            Dim NewEmployee As Boolean = False
                            Dim Emp As New cPrMsEmployees(EmployeeCode)

                            If Emp.Code Is Nothing Then
                                NewEmployee = True
                            End If

                            If Emp.Code = "" Then
                                NewEmployee = True
                            End If

                            If TemplateGroupCode = "" Or PayrollCompanyNo = "" Or EmployeeCode = "" Then
                                If NewEmployee And Status = "Terminated" Then
                                    ContinueWithLoading = False
                                Else
                                    MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                                    ContinueWithLoading = False
                                    Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                                End If
                            End If


                            If ContinueWithLoading Then

                                If NewEmployee Then


                                    With Emp
                                        .Code = EmployeeCode
                                        If Status = "Terminated" Then
                                            .Status = "I"
                                        Else
                                            .Status = "A"
                                        End If
                                        .PayTyp_Code = "M01"
                                        .TemGrp_Code = TemplateGroupCode
                                        .EmpSta_Code = "A"

                                        .LastName = LastName
                                        .FirstName = FirstName
                                        .FullName = LastName & " " & FirstName
                                        If Gender = "Female" Then
                                            .Sex = "F"
                                            .Title = "MRS"
                                        Else
                                            .Sex = "M"
                                            .Title = "MR"
                                        End If
                                        If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                            .BirthDate = Now.Date
                                        Else
                                            .BirthDate = CDate(BirthDate).Date
                                        End If
                                        If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                            .MarSta_Code = "S"
                                        ElseIf MaritalStatus = "Married" Then
                                            .MarSta_Code = "M"
                                        ElseIf MaritalStatus = "Divorce" Then
                                            .MarSta_Code = "D"
                                        ElseIf MaritalStatus = "Widow" Then
                                            .MarSta_Code = "W"
                                        End If

                                        .Address1 = AddressLine1
                                        .Address2 = City
                                        .Address3 = AddressLine2

                                        .PostCode = PostCode
                                        .Telephone1 = PhoneNo
                                        .Telephone2 = MobilePhone
                                        .Email = WorkEMail
                                        .SocialInsNumber = SocialSecurityNo
                                        .ComSin_EmpSocialInsNo = ""
                                        .IdentificationCard = IdentityCardNo
                                        .TaxID = IncomeTaxNo
                                        .PassportNumber = PassportNo
                                        .AlienNumber = ""
                                        .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype)
                                        .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                                        .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode)
                                        .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                        .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                        .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                        .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                        .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                        .EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition)
                                        .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)
                                        .EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity)
                                        .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                        .PeriodUnits = 0
                                        .AnnualUnits = 0
                                        .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                        .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods)
                                        .Bnk_Code = FindBankCodeFromSWIFT(dsBanks, SWIFT, True)
                                        .BankAccount = BankAccountNo
                                        .Bnk_CodeCo = GetFirstRecordOfDataset(dsBanks)
                                        .BankAccountCo = ""
                                        If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                            .StartDate = Now.Date
                                        Else
                                            .StartDate = CDate(EmploymentDate).Date
                                        End If
                                        If TerminationDate <> "" Then
                                            Dim S As String
                                            Dim D As Date
                                            Dim Ar() As String
                                            D = CDate(TerminationDate).Date.ToString
                                            S = Format(D, "yyyy/MM/dd")

                                            .TerminateDate = S
                                        Else
                                            .TerminateDate = ""
                                        End If

                                        .OtherIncome1 = CDbl(0)
                                        .OtherIncome2 = CDbl(0)
                                        .OtherIncome3 = CDbl(0)
                                        .PreviousEarnings = CDbl(0)
                                        .Emp_PrevSIDeduct = CDbl(0)
                                        .Emp_PrevSIContribute = CDbl(0)
                                        .Emp_PrevITDeduct = CDbl(0)
                                        .Emp_PrevPFDeduct = CDbl(0)

                                        .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                        .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                        .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)

                                        .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                        .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                        .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                        .InterfaceTemCode = TemplateGroupCode
                                        .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                        .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                        .DrivingLicense = ""
                                        .PensionNo = ""
                                        .MyPayslipReport = ""
                                        .IBAN = IBAN
                                        .PreviousLifeIns = CDbl(0)
                                        .PreviousDis = CDbl(0)
                                        .PreviousST = CDbl(0)
                                        .OtherIncome4 = CDbl(0)

                                        .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                        .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                        .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                        .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                        .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                        .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                        .FullPassName = ""
                                        .Traveldocs = ""

                                        .FirstEmployment = "0"
                                        .IsSI = 0
                                        .Password = ""
                                        .Splitemployement = "0"
                                        .NewEmployee = "1"

                                        .Force50Percent = "0"
                                        .Notes = ""


                                        .Emp_GLAnal1 = ""
                                        .Emp_GLAnal2 = ""
                                        .Emp_GLAnal3 = ""
                                        .Emp_GLAnal4 = ""

                                        .PensionType = "0"

                                        .CreationDate = Now.Date
                                        .CreatedBy = Global1.GLBUserId
                                        .AmendDate = Now.Date
                                        .AmendBy = Global1.GLBUserId

                                        If Not .Save() Then
                                            Throw Exx
                                        End If


                                        '''
                                        Dim k As Integer
                                        Dim DsErn As DataSet
                                        DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                        If CheckDataSet(DsErn) Then
                                            For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                                Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                                Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                                EmpErn.EmpCode = .Code
                                                EmpErn.ErnCode = E1.ErnCodCode
                                                EmpErn.MyValue = "0.00"
                                                EmpErn.TemGrpCode = .TemGrp_Code
                                                If Not EmpErn.Save Then
                                                    Throw Exx
                                                End If
                                            Next
                                        End If
                                        'Deductions
                                        Dim DsDed As DataSet
                                        DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                        If CheckDataSet(DsDed) Then
                                            For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                                Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                                Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                                EmpDed.EmpCode = .Code
                                                EmpDed.DedCode = D.DedCodCode
                                                EmpDed.MyValue = "0.00"
                                                EmpDed.TemGrpCode = .TemGrp_Code
                                                If Not EmpDed.Save Then
                                                    Throw Exx
                                                End If
                                            Next
                                        End If
                                        'Contributions
                                        Dim DsCon As DataSet
                                        DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                        If CheckDataSet(DsCon) Then
                                            For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                                Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                                Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                                EmpCon.EmpCode = .Code
                                                EmpCon.ConCode = C.ConCodCode
                                                EmpCon.MyValue = "0.00"
                                                EmpCon.TemGrpCode = .TemGrp_Code
                                                If Not C.Save Then
                                                    Throw Exx
                                                End If
                                            Next
                                        End If

                                    End With



                                Else
                                    '''''''''
                                    If Not OnlyNewEmployees Then
                                        With Emp
                                            '  .Code = CStr(Me.txtCode.Text)
                                            If Status = "Terminated" Then
                                                .Status = "I"
                                            Else
                                                .Status = "A"
                                            End If
                                            ' .PayTyp_Code = CType(Me.cmbPayTyp_Code.SelectedItem, cPrSsPayrollTypes).Code
                                            '.TemGrp_Code = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code
                                            '.EmpSta_Code = CType(Me.cmbEmpSta_Code.SelectedItem, cPrAnEmploymentStatus).Code

                                            .LastName = LastName
                                            .FirstName = FirstName
                                            .FullName = LastName & " " & FirstName
                                            If Gender = "Female" Then
                                                .Sex = "F"
                                                .Title = "MRS"
                                            Else
                                                .Sex = "M"
                                                .Title = "MR"
                                            End If
                                            If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                                .BirthDate = Now.Date
                                            Else
                                                .BirthDate = CDate(BirthDate).Date
                                            End If
                                            If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                                .MarSta_Code = "S"
                                            ElseIf MaritalStatus = "Married" Then
                                                .MarSta_Code = "M"
                                            ElseIf MaritalStatus = "Divorce" Then
                                                .MarSta_Code = "D"
                                            ElseIf MaritalStatus = "Widow" Then
                                                .MarSta_Code = "W"
                                            End If

                                            .Address1 = AddressLine1
                                            .Address2 = City
                                            .Address3 = AddressLine2

                                            .PostCode = PostCode
                                            .Telephone1 = PhoneNo
                                            .Telephone2 = MobilePhone
                                            .Email = WorkEMail
                                            .SocialInsNumber = SocialSecurityNo
                                            ' .ComSin_EmpSocialInsNo = ""
                                            .IdentificationCard = IdentityCardNo
                                            .TaxID = IncomeTaxNo
                                            .PassportNumber = PassportNo
                                            '  .AlienNumber = CStr(Me.txtAlienNumber.Text)
                                            '  .TicTyp_Code = CType(Me.cmbTaxCardType.SelectedItem, cPrAnTaxCardType).Code
                                            '  .EmpAn1_Code = CType(Me.cmbEmpAn1_Code.SelectedItem, cPrAnEmployeeAnalysis1).Code
                                            .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode)
                                            '  .EmpAn3_Code = CType(Me.cmbEmpAn3_Code.SelectedItem, cPrAnEmployeeAnalysis3).Code
                                            '  .EmpAn4_Code = CType(Me.cmbEmpAn4_Code.SelectedItem, cPrAnEmployeeAnalysis4).Code
                                            '  .EmpAn5_Code = CType(Me.cmbEmpAn5_Code.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                            '  .Uni_Code = CType(Me.cmbUni_Code.SelectedItem, cPrAnUnions).Code
                                            '  .Cou_Code = CType(Me.cmbCou_Code.SelectedItem, cAdAnCountries).Code
                                            '  .EmpPos_Code = CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).Code
                                            '  .Sic_Code = CType(Me.cmbSic_Code.SelectedItem, cPrAnSocialInsCategories).Code
                                            '  .EmpCmm_Code = CType(Me.cmbEmpCmm_Code.SelectedItem, cPrAnEmployeeCommunity).Code
                                            '  .PayUni_Code = CType(Me.cmbPayUni_Code.SelectedItem, cPrSsPayrollUnits).Code
                                            '  .PeriodUnits = NullToInt(Me.txtPeriodUnits.Text)
                                            '  .AnnualUnits = NullToInt(Me.txtAnnualUnits.Text)
                                            '  .Cur_Code = CType(Me.cmbCur_Code.SelectedItem, cAdMsCurrency).AlphaCode
                                            '  .PmtMth_Code = CType(Me.cmbPmtMth_Code.SelectedItem, cPrAnPaymentMethods).Code
                                            .Bnk_Code = FindBankCodeFromSWIFT(dsBanks, SWIFT, True)
                                            .BankAccount = BankAccountNo
                                            ' .Bnk_CodeCo = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks).Code
                                            ' .BankAccountCo = ""
                                            If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                                .StartDate = Now.Date
                                            Else
                                                .StartDate = CDate(EmploymentDate).Date
                                            End If

                                            If TerminationDate <> "" Then
                                                Dim S As String
                                                Dim D As Date
                                                Dim Ar() As String
                                                D = CDate(TerminationDate).Date.ToString
                                                S = Format(D, "yyyy/MM/dd")

                                                .TerminateDate = S
                                            Else
                                                .TerminateDate = ""
                                            End If

                                            '.OtherIncome1 = CDbl(Me.txtOtherIncome1.Text)
                                            '.OtherIncome2 = CDbl(Me.txtOtherIncome2.Text)
                                            '.OtherIncome3 = CDbl(Me.txtOtherIncome3.Text)
                                            '.PreviousEarnings = CDbl(Me.txtPreviousEarnings.Text)
                                            '.Emp_PrevSIDeduct = CDbl(Me.txtEmp_PrevSIDeduct.Text)
                                            '.Emp_PrevSIContribute = CDbl(Me.txtEmp_PrevSIContribute.Text)
                                            '.Emp_PrevITDeduct = CDbl(Me.txtEmp_PrevITDeduct.Text)
                                            '.Emp_PrevPFDeduct = CDbl(Me.txtEmp_PrevPFDeduct.Text)

                                            ' .ProFnd_Code = CType(Me.ComboProFund.SelectedItem, cPrSsProvidentFund).Code
                                            ' .MedFnd_Code = CType(Me.ComboMedicalFund.SelectedItem, cPrSsMedicalFund).Code
                                            ' .SocInc_Code = CType(Me.ComboSocialIns.SelectedItem, cPrSsSocialInsurance).Code

                                            '.Ind_Code = CType(Me.ComboIndustrial.SelectedItem, cPrSsIndustrial).Code
                                            '.Une_Code = CType(Me.ComboUnemployment.SelectedItem, cPrSsUnemployment).Code
                                            '.SocCoh_Code = CType(Me.ComboSocialCohesion.SelectedItem, cPrSsSocialCohesion).Code
                                            '.InterfaceTemCode = CType(Me.cmbIntTem_Code.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                                            '.InterfacePFCode = CType(Me.cmbIntPF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                                            '.InterfaceMFCode = CType(Me.cmbIntMF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                                            '.InterfaceACCode = CType(Me.cmbIntAC.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                                            '.DrivingLicense = Me.txtDrivingLicense.Text
                                            '.PensionNo = Me.txtPensionNo.Text
                                            '.MyPayslipReport = Me.txtPayslipreport.Text
                                            .IBAN = IBAN
                                            '.PreviousLifeIns = Me.txtPreviousLF.Text
                                            '.PreviousDis = Me.txtPreviousDis.Text
                                            '.PreviousST = Me.txtPreviousST.Text
                                            '.OtherIncome4 = Me.txtOtherIncome4.Text

                                            ' .SectorPay = CType(Me.ComboSectorPay.SelectedItem, cPrSsSectorPay).Code
                                            ' .CommissionRate = CType(Me.ComboCommissionRates.SelectedItem, cPrSsCommissionRates).Code
                                            ' .PerformanceBonus = CType(Me.ComboPerformanceBonus.SelectedItem, cPrSsPerformanceBonus).Code
                                            ' .DutyHours = CType(Me.ComboDutyHours.SelectedItem, cPrSsDutyHours).Code
                                            ' .OverLay = CType(Me.ComboOverLay.SelectedItem, cPrSsOverLay).Code
                                            ' .FlightHours = CType(Me.ComboFlightHours.SelectedItem, cPrSsFlightHours).Code

                                            '.FullPassName = Me.txtFullPassportName.Text
                                            '.Traveldocs = Me.txtTravelDocs.Text
                                            'If Me.CBFirstEmployment.CheckState = CheckState.Checked Then
                                            ' .FirstEmployment = "1"
                                            ' Else
                                            ' .FirstEmployment = "0"
                                            ' End If

                                            'If Me.CBIsSI.CheckState = CheckState.Checked Then
                                            ' .IsSI = 1
                                            ' Else
                                            ' .IsSI = 0
                                            ' End If

                                            '.Emp_GLAnal1 = Me.txtGLAnal1.Text
                                            '.Emp_GLAnal2 = Me.txtGLAnal2.Text
                                            '.Emp_GLAnal3 = Me.txtGLAnal3.Text
                                            '.Emp_GLAnal4 = Me.txtGLAnal4.Text

                                            '.PensionType = Me.ComboPensionType.SelectedIndex

                                            'If Not Update() Then .CreationDate = Now.Date
                                            'If Not Update() Then .CreatedBy = Global1.GLBUserId
                                            .AmendDate = Now.Date
                                            .AmendBy = Global1.GLBUserId
                                            If Not .Save() Then
                                                Throw Exx
                                            End If
                                            'Dim i As Integer
                                            'For i = 0 To Ern.Length - 1
                                            '    If Ern(i).txtCode.Tag <> "" Then
                                            '        Dim E As New cPrMsEmployeeEarnings(.Code, Ern(i).txtCode.Tag)
                                            '        E.EmpCode = .Code
                                            '        E.ErnCode = Ern(i).txtCode.Tag
                                            '        E.MyValue = Ern(i).txtValue.Text
                                            '        E.TemGrpCode = .TemGrp_Code
                                            '        If Not E.Save Then
                                            '            Throw Exx
                                            '        End If
                                            '    End If
                                            'Next
                                            'For i = 0 To Ded.Length - 1
                                            '    If Ded(i).txtCode.Tag <> "" Then
                                            '        Dim D As New cPrMsEmployeeDeductions(.Code, Ded(i).txtCode.Tag)
                                            '        D.EmpCode = .Code
                                            '        D.DedCode = Ded(i).txtCode.Tag
                                            '        D.MyValue = Ded(i).txtValue.Text
                                            '        D.TemGrpCode = .TemGrp_Code
                                            '        If Not D.Save Then
                                            '            Throw Exx
                                            '        End If
                                            '    End If
                                            'Next
                                            'For i = 0 To Con.Length - 1
                                            '    If Con(i).txtCode.Tag <> "" Then
                                            '        Dim C As New cPrMsEmployeeContributions(.Code, Con(i).txtCode.Tag)
                                            '        C.EmpCode = .Code
                                            '        C.ConCode = Con(i).txtCode.Tag
                                            '        C.MyValue = Con(i).txtValue.Text
                                            '        C.TemGrpCode = .TemGrp_Code
                                            '        If Not C.Save Then
                                            '            Throw Exx
                                            '        End If
                                            '    End If
                                            'Next

                                        End With

                                    End If

                                    '''''''''


                                End If

                            End If
                        Next


                        Global1.Business.CommitTransaction()
                        MsgBox("Loading from Exelsys has finishd", MsgBoxStyle.Information)
                    Catch ex As Exception
                        Global1.Business.Rollback()
                        Utils.ShowException(ex)
                        MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                    End Try
                End If

                'Update / Deletes additions, you name it all use the same technology. 
            End If
        Catch ex As Exception
            'when there is "an" error, do something, then continu running the app
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function GetFirstRecordOfDataset(ByVal ds As DataSet, Optional ByVal Code As String = "", Optional ByVal SearchOnDescription As Boolean = False) As String


        Dim Str As String = ""
        Dim RetCode As String = ""
        If Code = "" Then
            If CheckDataSet(ds) Then

                Str = DbNullToString(ds.Tables(0).Rows(0).Item(0))
            End If
        Else
            If CheckDataSet(ds) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If SearchOnDescription Then
                        Str = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    Else
                        Str = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    End If

                    ' Debug.WriteLine(Code)
                    If Str = Code Then
                        RetCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    End If
                Next
                If RetCode = "" Then
                    If CheckDataSet(ds) Then
                        Str = DbNullToString(ds.Tables(0).Rows(0).Item(0))
                    End If
                Else
                    Str = RetCode
                End If

            End If
        End If

        Return Str
    End Function
    Private Function FindBankCodeFromSWIFT(ByVal dsBanks As DataSet, ByVal SWIFT As String, ByVal CheckFurther As Boolean) As String
        Dim S As String = ""
        Dim BankCode As String = ""
        Select Case SWIFT
            Case "CBCYCY2N"
                S = "01"
            Case "BCYPCY2N"
                S = "02"
            Case "LIKICY2N"
                S = "03"
            Case "HEBACY2N"
                S = "05"
            Case "ETHNCY2N"
                S = "06"
            Case "CCBKCY2N"
                S = "07"
            Case "PIRBCY2N"
                S = "08"
            Case "ABKLCY2N"
                S = "09"
            Case "EMPOCY2N"
                S = "10"
            Case "UNVKCY2N"
                S = "11"
            Case "SOGECY2N"
                S = "12"
            Case "CYDBCY2N"
                S = "14"
            Case "EFGBCY2N"
                S = "18"
            Case "CECBCY2N"
                S = "20"
            Case "CCBKCY2N"
                S = "21"
            Case "RCBLCY2I"
                S = "23"
            Case "ERBKCY2N"
                S = "24"
            Case "ANCOCY2N"
                S = "97"
            Case "INGBNL2A"
                S = "99"
            Case "ERBKGRAASEC"
                S = "98"
            Case "WIREDEMM"
                S = "90"
            Case "POALILIT"
                S = "96"
            Case "RNCBROBU"
                S = "95"
            Case "AIZKLV22"
                S = "94"
            Case "LOYDGB2L"
                S = "93"
            Case "DNBANOKK"
                S = "92"
        End Select

        If CheckDataSet(dsBanks) Then
            Dim i As Integer
            Dim Code As String = ""
            For i = 0 To dsBanks.Tables(0).Rows.Count - 1
                Code = DbNullToString(dsBanks.Tables(0).Rows(i).Item(4))
                If Code = S And Code <> "" Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
            If CheckFurther Then
                If BankCode = "" Then
                    If SWIFT = "" Or SWIFT Is Nothing Then
                        BankCode = DbNullToString(dsBanks.Tables(0).Rows(0).Item(0))
                    Else
                        MsgBox("Swift number not found " & SWIFT)
                    End If
                End If
            End If
        End If

        Return BankCode

    End Function
    Private Function FindBankCodeFromSWIFT2(ByVal dsBanks As DataSet, ByVal SWIFT As String) As String
        Dim S As String = ""
        Dim BankCode As String = ""
        Dim Swift1 As String

        If CheckDataSet(dsBanks) Then
            Dim i As Integer
            Dim Code As String = ""
            For i = 0 To dsBanks.Tables(0).Rows.Count - 1
                Swift1 = DbNullToString(dsBanks.Tables(0).Rows(i).Item(5))
                If Swift1 = SWIFT Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
            If BankCode = "" Then
                If SWIFT = "" Or SWIFT Is Nothing Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(0).Item(0))
                Else
                    MsgBox("Swift number not found " & SWIFT)
                End If
            End If
        End If

        Return BankCode

    End Function

    Private Sub BackupDatabase()
        Try


            Dim Filename As String
            Dim D As String
            D = Format(Now.Date, "yyyyMMdd")
            Dim Ds As DataSet
            Dim PayslipDir As String
            Ds = Global1.Business.GetParameter("Backup", "ExportFileDir")
            If CheckDataSet(Ds) Then
                Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
                PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
            Else
                PayslipDir = "C:\"
            End If
            Filename = PayslipDir & "PayrollBackup_" & D & ".bak"

            'On Error Resume Next
            'Kill(Filename)
            'On Error GoTo 0

            If Global1.Business.BackupDatabase(Global1.DbaseName, Filename) Then
                MessageBox.Show("Backup completed succesfully. File name: " & Filename, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to backup the database", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub ImportDataFromExelsysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportDataFromExelsysToolStripMenuItem.Click
        If Global1.PARAM_HCMIsenabled Then
            LoadDataFromHCMsystem(False)
        Else
            MsgBox("Loading Data from HCM system is not enabled", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub ImportDataFromExcelsysOnlyNEWEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportDataFromExcelsysOnlyNEWEmployeesToolStripMenuItem.Click
        If Global1.PARAM_HCMIsenabled Then
            LoadDataFromHCMsystem(True)
        Else
            MsgBox("Loading Data from HCM system is not enabled", MsgBoxStyle.Information)
        End If
    End Sub



    Private Sub BackupDatabaseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDatabaseToolStripMenuItem1.Click
        BackupDatabase()
    End Sub

    Private Sub ImportEmployeesFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportEmployeesFromExcelToolStripMenuItem.Click
        ImportEmployeesFromExcel()
    End Sub
    Private Sub ImportEmployeesFromExcel()
        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        OpenFileDialog1.Reset()
        OpenFileDialog1.ShowDialog()
        Dim Filename As String
        Filename = OpenFileDialog1.FileName



        Dim InitFile As Boolean = True
        Dim ApendFile As Boolean = True
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        Dim AccountCode As String



        xlWorkBook = xlApp.Workbooks.Open(Filename)
        xlWorkSheet = xlWorkBook.Worksheets(1)


        Dim FullName As String
        Dim FirstName As String
        Dim MiddleName As String
        Dim LastName As String
        Dim EmployeeCode As String
        Dim Gender As String
        Dim JobTitle As String
        Dim BirthDate As String
        Dim Status As String
        Dim EmploymentDate As String
        Dim MaritalStatus As String
        Dim SocialSecurityNo As String
        Dim IdentityCardNo As String
        Dim PassportNo As String
        Dim IncomeTaxNo As String
        Dim WorkEMail As String
        Dim DepartmentCode As String
        Dim PayrollNo As String
        Dim BankName As String
        Dim BankAccountNo As String
        Dim IBAN As String
        Dim SWIFT As String
        Dim TerminationDate As String
        Dim AddressLine1 As String
        Dim AddressLine2 As String
        Dim AddressLine3 As String
        Dim PostCode As String
        Dim POBox As String
        Dim POBoxPostCode As String
        Dim City As String
        Dim PhoneNo As String
        Dim MobilePhone As String
        Dim Email As String
        Dim JobDescriptionCode As String
        Dim EmployeeJobDescription As String
        Dim PayrollCompanyNo As String
        Dim TemplateGroupCode As String
        Dim ARC As String
        Dim ForeignID As String
        Dim EUCard As String
        Dim Address As String
        Dim strSalary As String
        Dim Salary As Double
        ''''''''''''''''''''''''''''''''''''''''''''''
        'FindDefaults()
        Dim dsTemplateGroup As DataSet
        Dim dsAnal1 As DataSet
        Dim dsAnal2 As DataSet
        Dim dsAnal3 As DataSet
        Dim dsAnal4 As DataSet
        Dim dsAnal5 As DataSet
        Dim dsUnions As DataSet
        Dim dsCountries As DataSet
        Dim dsEmpPosition As DataSet
        Dim dsSIcategory As DataSet
        Dim dsEmpCommunity As DataSet
        Dim dsPayUnits As DataSet
        Dim dsCurCode As DataSet
        Dim dsPayMethods As DataSet
        Dim dsBanks As DataSet
        Dim dsTaxCardtype As DataSet
        Dim dsProFund As DataSet
        Dim dsMedicalFund As DataSet
        Dim dsSocialInsurance As DataSet
        Dim dsIndustrial As DataSet
        Dim dsUnemployment As DataSet
        Dim dsSocialCohesion As DataSet
        Dim dsSectorPay As DataSet
        Dim dsCommissionRates As DataSet
        Dim dsPerformanceBonus As DataSet
        Dim dsdutyHours As DataSet
        Dim dsOverLay As DataSet
        Dim dsFlightHours As DataSet




        dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        dsUnions = Global1.Business.AG_GetAllPrAnUnions()
        dsCountries = Global1.Business.AG_GetAllAdAnCountries()
        dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
        dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
        dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
        dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
        dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
        dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
        dsBanks = Global1.Business.AG_GetAllPrAnBanks()
        dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
        dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
        dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
        dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
        dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
        dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
        dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
        dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
        dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
        dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
        dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
        dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
        dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour

        '''''''''''''''''''''''''''''''''''''''''''''''

        Dim i As Integer

        Try
            Dim Exx As New Exception



            ' Global1.Business.BeginTransaction()

            Dim totalRows As Integer
            Dim totalColumns As Integer
            xlWorkSheet = xlWorkBook.Worksheets(1)
            totalRows = xlWorkSheet.UsedRange.Rows.Count
            totalColumns = xlWorkSheet.UsedRange.Columns.Count()

            'Dim TW As System.IO.TextWriter
            For i = 2 To totalRows


                EmployeeCode = xlWorkSheet.Cells(i, 1).value
                If EmployeeCode <> "" And Not EmployeeCode Is Nothing Then

                    With xlWorkSheet



                        FullName = .Cells(i, 2).value
                        Dim Ar() As String
                        Ar = Trim(FullName).Split(" ")
                        If Ar.Length = 2 Then
                            FirstName = Ar(0)
                            LastName = Ar(1)
                        ElseIf Ar.Length = 3 Then
                            FirstName = Ar(0)
                            LastName = Ar(2)
                        End If

                        Gender = .Cells(i, 3).value

                        IdentityCardNo = NullToString(.Cells(i, 4).value)
                        ARC = NullToString(.Cells(i, 5).value)
                        PassportNo = NullToString(.Cells(i, 6).value)

                        IncomeTaxNo = NullToString(.Cells(i, 7).value)
                        SocialSecurityNo = NullToString(.Cells(i, 8).value)
                        BirthDate = .Cells(i, 10).value
                        EmploymentDate = .Cells(i, 11).value

                        ForeignID = NullToString(.Cells(i, 12).value)
                        EUCard = NullToString(.Cells(i, 13).value)


                        Address = NullToString(.Cells(i, 14).value)
                        Dim ar2() As String
                        ar2 = Address.Split(",")
                        If ar2.Length = 1 Then
                            AddressLine1 = ar2(0)
                            AddressLine2 = ""
                            AddressLine3 = ""
                            PostCode = ""
                            City = ""

                        ElseIf ar2.Length = 5 Then
                            AddressLine1 = ar2(0)
                            AddressLine2 = ar2(1)
                            PostCode = ar2(2)
                            City = ar2(3)
                        ElseIf ar2.Length = 4 Then
                            AddressLine1 = ar2(0)
                            PostCode = ar2(1)
                            City = ar2(2)
                        ElseIf ar2.Length = 6 Then
                            AddressLine1 = ar2(0)
                            AddressLine2 = ar2(1)
                            AddressLine3 = ar2(2)
                            PostCode = ar2(3)
                            City = ar2(4)
                        ElseIf ar2.Length = 3 Then
                            AddressLine1 = ar2(0)
                            AddressLine2 = ar2(1)
                            PostCode = ar2(2)
                            AddressLine3 = ""
                            City = ""
                        ElseIf ar2.Length = 2 Then
                            AddressLine1 = ar2(0)
                            AddressLine2 = ar2(1)
                            PostCode = ""
                            AddressLine3 = ""
                            PostCode = ""
                            City = ""
                        Else
                            AddressLine1 = ""
                            AddressLine2 = ""
                            AddressLine3 = ""
                            PostCode = ""
                            City = ""
                        End If


                        PhoneNo = NullToString(.Cells(i, 15).value)
                        MobilePhone = NullToString(.Cells(i, 16).value)
                        Email = NullToString(.Cells(i, 18).value)



                        DepartmentCode = .Cells(i, 19).value()
                        EmployeeJobDescription = .Cells(i, 20).value()

                        strSalary = .Cells(i, 21).value()
                        If IsNumeric(strSalary) Then
                            Salary = .Cells(i, 21).value()
                        Else
                            MsgBox("Employee Salary with code " & EmployeeCode & " is not numeric")
                        End If


                        IBAN = .Cells(i, 24).value()
                        SWIFT = .Cells(i, 26).value()

                        PayrollCompanyNo = "01"
                        Status = "A"
                        MaritalStatus = ""

                    End With

                    TemplateGroupCode = "1001"
                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False

                    EmployeeCode = EmployeeCode.PadLeft(4, "0")

                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If NewEmployee Then


                        With Emp
                            .Code = EmployeeCode
                            If Status = "Terminated" Then
                                .Status = "I"
                            Else
                                .Status = "A"
                            End If
                            .PayTyp_Code = "M01"
                            .TemGrp_Code = TemplateGroupCode
                            .EmpSta_Code = "A"

                            .LastName = LastName
                            .FirstName = FirstName
                            .FullName = LastName & " " & FirstName
                            If Gender = "F" Then
                                .Sex = "F"
                                .Title = "MRS"
                            Else
                                .Sex = "M"
                                .Title = "MR"
                            End If
                            If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                .BirthDate = Now.Date
                            Else
                                .BirthDate = CDate(Utils.ChangeDateFormat_ddMMyyyy_to_yyyyMMdd(BirthDate)).Date
                            End If
                            If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                .MarSta_Code = "S"
                            ElseIf MaritalStatus = "Married" Then
                                .MarSta_Code = "M"
                            ElseIf MaritalStatus = "Divorce" Then
                                .MarSta_Code = "D"
                            ElseIf MaritalStatus = "Widow" Then
                                .MarSta_Code = "W"
                            End If

                            .Address1 = AddressLine1
                            .Address2 = AddressLine2
                            .Address3 = City
                            .PostCode = PostCode
                            .Telephone1 = PhoneNo
                            .Telephone2 = MobilePhone
                            .Email = Email
                            .SocialInsNumber = SocialSecurityNo
                            .ComSin_EmpSocialInsNo = ""
                            .IdentificationCard = IdentityCardNo
                            .TaxID = IncomeTaxNo
                            .PassportNumber = PassportNo
                            .AlienNumber = ARC
                            .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype)
                            .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                            .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode, True)
                            .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                            .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                            .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                            .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                            .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                            .EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, EmployeeJobDescription, True)
                            .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)
                            .EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity)
                            .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                            .PeriodUnits = 0
                            .AnnualUnits = 0
                            .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                            .PmtMth_Code = "3" ' GetFirstRecordOfDataset(dsPayMethods)
                            .Bnk_Code = FindBankCodeFromSWIFT(dsBanks, SWIFT, True)
                            .BankAccount = "" 'BankAccountNo
                            .Bnk_CodeCo = GetFirstRecordOfDataset(dsBanks)
                            .BankAccountCo = ""
                            If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                .StartDate = Now.Date
                            Else
                                .StartDate = CDate(ChangeDateFormat_ddMMyyyy_to_yyyyMMdd(EmploymentDate))
                            End If
                            If TerminationDate <> "" Then
                                Dim S As String
                                Dim D As Date
                                Dim Ar() As String
                                D = CDate(TerminationDate).Date.ToString
                                S = Format(D, "yyyy/MM/dd")

                                .TerminateDate = S
                            Else
                                .TerminateDate = ""
                            End If

                            .OtherIncome1 = CDbl(0)
                            .OtherIncome2 = CDbl(0)
                            .OtherIncome3 = CDbl(0)
                            .PreviousEarnings = CDbl(0)
                            .Emp_PrevSIDeduct = CDbl(0)
                            .Emp_PrevSIContribute = CDbl(0)
                            .Emp_PrevITDeduct = CDbl(0)
                            .Emp_PrevPFDeduct = CDbl(0)

                            .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                            .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                            .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)

                            .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                            .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                            .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                            .InterfaceTemCode = TemplateGroupCode
                            .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                            .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                            .DrivingLicense = ForeignID
                            .PensionNo = ""
                            .MyPayslipReport = ""
                            .IBAN = IBAN
                            .PreviousLifeIns = CDbl(0)
                            .PreviousDis = CDbl(0)
                            .PreviousST = CDbl(0)
                            .OtherIncome4 = CDbl(0)

                            .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                            .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                            .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                            .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                            .OverLay = GetFirstRecordOfDataset(dsOverLay)
                            .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                            .FullPassName = ""
                            .Traveldocs = ""

                            .FirstEmployment = "0"
                            .IsSI = 0


                            .Emp_GLAnal1 = ""
                            .Emp_GLAnal2 = ""
                            .Emp_GLAnal3 = ""
                            .Emp_GLAnal4 = ""

                            .PensionType = "0"

                            .CreationDate = Now.Date
                            .CreatedBy = Global1.GLBUserId
                            .AmendDate = Now.Date
                            .AmendBy = Global1.GLBUserId



                            If Not .Save() Then
                                Throw Exx
                            End If


                            '''
                            Dim k As Integer
                            Dim DsErn As DataSet
                            DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                            If CheckDataSet(DsErn) Then
                                For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                    Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                    Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                    EmpErn.EmpCode = .Code
                                    EmpErn.ErnCode = E1.ErnCodCode
                                    EmpErn.MyValue = "0.00"
                                    EmpErn.TemGrpCode = .TemGrp_Code
                                    If Not EmpErn.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If
                            'Deductions
                            Dim DsDed As DataSet
                            DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                            If CheckDataSet(DsDed) Then
                                For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                    Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                    Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                    EmpDed.EmpCode = .Code
                                    EmpDed.DedCode = D.DedCodCode
                                    EmpDed.MyValue = "0.00"
                                    EmpDed.TemGrpCode = .TemGrp_Code
                                    If Not EmpDed.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If
                            'Contributions
                            Dim DsCon As DataSet
                            DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                            If CheckDataSet(DsCon) Then
                                For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                    Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                    Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                    EmpCon.EmpCode = .Code
                                    EmpCon.ConCode = C.ConCodCode
                                    EmpCon.MyValue = "0.00"
                                    EmpCon.TemGrpCode = .TemGrp_Code
                                    If Not C.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If

                        End With

                        Dim EmpSal As New cPrTxEmployeeSalary

                        EmpSal.Emp_Code = EmployeeCode
                        EmpSal.SalaryValue = Salary
                        EmpSal.Basic = 0
                        EmpSal.Cola = 0
                        EmpSal.IsCola = "0"
                        EmpSal.EffPayDate = "2017/01/01"
                        EmpSal.EffArrearsDate = "2017/01/01"
                        EmpSal.EmpSal_Dif = 0
                        EmpSal.Date1 = Now

                        EmpSal.Usr_Id = Global1.GLBUserId



                        If Not EmpSal.Save Then
                            Throw Exx
                        End If



                    Else
                        '''''''''

                        'With Emp
                        '    '  .Code = CStr(Me.txtCode.Text)
                        '    If Status = "Terminated" Then
                        '        .Status = "I"
                        '    Else
                        '        .Status = "A"
                        '    End If
                        '    ' .PayTyp_Code = CType(Me.cmbPayTyp_Code.SelectedItem, cPrSsPayrollTypes).Code
                        '    '.TemGrp_Code = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code
                        '    '.EmpSta_Code = CType(Me.cmbEmpSta_Code.SelectedItem, cPrAnEmploymentStatus).Code

                        '    .LastName = LastName
                        '    .FirstName = FirstName
                        '    .FullName = LastName & " " & FirstName
                        '    If Gender = "Female" Then
                        '        .Sex = "F"
                        '        .Title = "MRS"
                        '    Else
                        '        .Sex = "M"
                        '        .Title = "MR"
                        '    End If
                        '    If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                        '        .BirthDate = Now.Date
                        '    Else
                        '        .BirthDate = CDate(ChangeDateFormat_ddMMyyyy_to_yyyyMMdd(BirthDate))
                        '    End If
                        '    If MaritalStatus = "" Or MaritalStatus = "Single" Then
                        '        .MarSta_Code = "S"
                        '    ElseIf MaritalStatus = "Married" Then
                        '        .MarSta_Code = "M"
                        '    ElseIf MaritalStatus = "Divorce" Then
                        '        .MarSta_Code = "D"
                        '    ElseIf MaritalStatus = "Widow" Then
                        '        .MarSta_Code = "W"
                        '    End If

                        '    .Address1 = AddressLine1
                        '    .Address2 = AddressLine2
                        '    .Address3 = City
                        '    .PostCode = PostCode
                        '    .Telephone1 = PhoneNo
                        '    .Telephone2 = MobilePhone
                        '    .Email = WorkEMail
                        '    .SocialInsNumber = SocialSecurityNo
                        '    ' .ComSin_EmpSocialInsNo = ""
                        '    .IdentificationCard = IdentityCardNo
                        '    .TaxID = IncomeTaxNo
                        '    .PassportNumber = PassportNo
                        '    '  .AlienNumber = CStr(Me.txtAlienNumber.Text)
                        '    '  .TicTyp_Code = CType(Me.cmbTaxCardType.SelectedItem, cPrAnTaxCardType).Code
                        '    '  .EmpAn1_Code = CType(Me.cmbEmpAn1_Code.SelectedItem, cPrAnEmployeeAnalysis1).Code
                        '    .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode)
                        '    '  .EmpAn3_Code = CType(Me.cmbEmpAn3_Code.SelectedItem, cPrAnEmployeeAnalysis3).Code
                        '    '  .EmpAn4_Code = CType(Me.cmbEmpAn4_Code.SelectedItem, cPrAnEmployeeAnalysis4).Code
                        '    '  .EmpAn5_Code = CType(Me.cmbEmpAn5_Code.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                        '    '  .Uni_Code = CType(Me.cmbUni_Code.SelectedItem, cPrAnUnions).Code
                        '    '  .Cou_Code = CType(Me.cmbCou_Code.SelectedItem, cAdAnCountries).Code
                        '    '  .EmpPos_Code = CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).Code
                        '    '  .Sic_Code = CType(Me.cmbSic_Code.SelectedItem, cPrAnSocialInsCategories).Code
                        '    '  .EmpCmm_Code = CType(Me.cmbEmpCmm_Code.SelectedItem, cPrAnEmployeeCommunity).Code
                        '    '  .PayUni_Code = CType(Me.cmbPayUni_Code.SelectedItem, cPrSsPayrollUnits).Code
                        '    '  .PeriodUnits = NullToInt(Me.txtPeriodUnits.Text)
                        '    '  .AnnualUnits = NullToInt(Me.txtAnnualUnits.Text)
                        '    '  .Cur_Code = CType(Me.cmbCur_Code.SelectedItem, cAdMsCurrency).AlphaCode
                        '    '  .PmtMth_Code = CType(Me.cmbPmtMth_Code.SelectedItem, cPrAnPaymentMethods).Code
                        '    .Bnk_Code = FindBankCodeFromSWIFT(dsBanks, SWIFT)
                        '    .BankAccount = BankAccountNo
                        '    ' .Bnk_CodeCo = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks).Code
                        '    ' .BankAccountCo = ""
                        '    If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                        '        .StartDate = Now.Date
                        '    Else
                        '        .StartDate = CDate(ChangeDateFormat_ddMMyyyy_to_yyyyMMdd(EmploymentDate))
                        '    End If

                        '    If TerminationDate <> "" Then
                        '        Dim S As String
                        '        Dim D As Date
                        '        Dim Ar() As String
                        '        D = CDate(TerminationDate).Date.ToString
                        '        S = Format(D, "yyyy/MM/dd")

                        '        .TerminateDate = S
                        '    Else
                        '        .TerminateDate = ""
                        '    End If

                        '    '.OtherIncome1 = CDbl(Me.txtOtherIncome1.Text)
                        '    '.OtherIncome2 = CDbl(Me.txtOtherIncome2.Text)
                        '    '.OtherIncome3 = CDbl(Me.txtOtherIncome3.Text)
                        '    '.PreviousEarnings = CDbl(Me.txtPreviousEarnings.Text)
                        '    '.Emp_PrevSIDeduct = CDbl(Me.txtEmp_PrevSIDeduct.Text)
                        '    '.Emp_PrevSIContribute = CDbl(Me.txtEmp_PrevSIContribute.Text)
                        '    '.Emp_PrevITDeduct = CDbl(Me.txtEmp_PrevITDeduct.Text)
                        '    '.Emp_PrevPFDeduct = CDbl(Me.txtEmp_PrevPFDeduct.Text)

                        '    ' .ProFnd_Code = CType(Me.ComboProFund.SelectedItem, cPrSsProvidentFund).Code
                        '    ' .MedFnd_Code = CType(Me.ComboMedicalFund.SelectedItem, cPrSsMedicalFund).Code
                        '    ' .SocInc_Code = CType(Me.ComboSocialIns.SelectedItem, cPrSsSocialInsurance).Code

                        '    '.Ind_Code = CType(Me.ComboIndustrial.SelectedItem, cPrSsIndustrial).Code
                        '    '.Une_Code = CType(Me.ComboUnemployment.SelectedItem, cPrSsUnemployment).Code
                        '    '.SocCoh_Code = CType(Me.ComboSocialCohesion.SelectedItem, cPrSsSocialCohesion).Code
                        '    '.InterfaceTemCode = CType(Me.cmbIntTem_Code.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                        '    '.InterfacePFCode = CType(Me.cmbIntPF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                        '    '.InterfaceMFCode = CType(Me.cmbIntMF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                        '    '.InterfaceACCode = CType(Me.cmbIntAC.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                        '    '.DrivingLicense = Me.txtDrivingLicense.Text
                        '    '.PensionNo = Me.txtPensionNo.Text
                        '    '.MyPayslipReport = Me.txtPayslipreport.Text
                        '    .IBAN = IBAN
                        '    '.PreviousLifeIns = Me.txtPreviousLF.Text
                        '    '.PreviousDis = Me.txtPreviousDis.Text
                        '    '.PreviousST = Me.txtPreviousST.Text
                        '    '.OtherIncome4 = Me.txtOtherIncome4.Text

                        '    ' .SectorPay = CType(Me.ComboSectorPay.SelectedItem, cPrSsSectorPay).Code
                        '    ' .CommissionRate = CType(Me.ComboCommissionRates.SelectedItem, cPrSsCommissionRates).Code
                        '    ' .PerformanceBonus = CType(Me.ComboPerformanceBonus.SelectedItem, cPrSsPerformanceBonus).Code
                        '    ' .DutyHours = CType(Me.ComboDutyHours.SelectedItem, cPrSsDutyHours).Code
                        '    ' .OverLay = CType(Me.ComboOverLay.SelectedItem, cPrSsOverLay).Code
                        '    ' .FlightHours = CType(Me.ComboFlightHours.SelectedItem, cPrSsFlightHours).Code

                        '    '.FullPassName = Me.txtFullPassportName.Text
                        '    '.Traveldocs = Me.txtTravelDocs.Text
                        '    'If Me.CBFirstEmployment.CheckState = CheckState.Checked Then
                        '    ' .FirstEmployment = "1"
                        '    ' Else
                        '    ' .FirstEmployment = "0"
                        '    ' End If

                        '    'If Me.CBIsSI.CheckState = CheckState.Checked Then
                        '    ' .IsSI = 1
                        '    ' Else
                        '    ' .IsSI = 0
                        '    ' End If

                        '    '.Emp_GLAnal1 = Me.txtGLAnal1.Text
                        '    '.Emp_GLAnal2 = Me.txtGLAnal2.Text
                        '    '.Emp_GLAnal3 = Me.txtGLAnal3.Text
                        '    '.Emp_GLAnal4 = Me.txtGLAnal4.Text

                        '    '.PensionType = Me.ComboPensionType.SelectedIndex

                        '    'If Not Update() Then .CreationDate = Now.Date
                        '    'If Not Update() Then .CreatedBy = Global1.GLBUserId
                        '    .AmendDate = Now.Date
                        '    .AmendBy = Global1.GLBUserId
                        '    If Not .Save() Then
                        '        Throw Exx
                        '    End If
                        '    'Dim i As Integer
                        '    'For i = 0 To Ern.Length - 1
                        '    '    If Ern(i).txtCode.Tag <> "" Then
                        '    '        Dim E As New cPrMsEmployeeEarnings(.Code, Ern(i).txtCode.Tag)
                        '    '        E.EmpCode = .Code
                        '    '        E.ErnCode = Ern(i).txtCode.Tag
                        '    '        E.MyValue = Ern(i).txtValue.Text
                        '    '        E.TemGrpCode = .TemGrp_Code
                        '    '        If Not E.Save Then
                        '    '            Throw Exx
                        '    '        End If
                        '    '    End If
                        '    'Next
                        '    'For i = 0 To Ded.Length - 1
                        '    '    If Ded(i).txtCode.Tag <> "" Then
                        '    '        Dim D As New cPrMsEmployeeDeductions(.Code, Ded(i).txtCode.Tag)
                        '    '        D.EmpCode = .Code
                        '    '        D.DedCode = Ded(i).txtCode.Tag
                        '    '        D.MyValue = Ded(i).txtValue.Text
                        '    '        D.TemGrpCode = .TemGrp_Code
                        '    '        If Not D.Save Then
                        '    '            Throw Exx
                        '    '        End If
                        '    '    End If
                        '    'Next
                        '    'For i = 0 To Con.Length - 1
                        '    '    If Con(i).txtCode.Tag <> "" Then
                        '    '        Dim C As New cPrMsEmployeeContributions(.Code, Con(i).txtCode.Tag)
                        '    '        C.EmpCode = .Code
                        '    '        C.ConCode = Con(i).txtCode.Tag
                        '    '        C.MyValue = Con(i).txtValue.Text
                        '    '        C.TemGrpCode = .TemGrp_Code
                        '    '        If Not C.Save Then
                        '    '            Throw Exx
                        '    '        End If
                        '    '    End If
                        '    'Next

                        'End With



                        ''''''''''


                    End If

                End If
            Next


            ' Global1.Business.CommitTransaction()
            MsgBox("Loading from Exelsys has finishd", MsgBoxStyle.Information)
        Catch ex As Exception
            'Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        GC.Collect()


    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


    Private Sub OpenALForAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenALForAllToolStripMenuItem.Click
        Try

            Dim Exx As New Exception
            Dim Ds As DataSet
            Ds = Global1.Business.GetAllEmployees
            Dim i As Integer
            Dim EmpCode As String
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim tPrTxEmployeeLeave As New cPrTxEmployeeLeave
                    EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                    With tPrTxEmployeeLeave
                        .Id = 0
                        .EmpCode = EmpCode
                        .Status = "Approved"
                        .Type = "1"
                        .ReqDate = CDate("01/01/2017")
                        .ProcDate = CDate("01/01/2017")
                        .FromDate = CDate("01/01/2017")
                        .ToDate = CDate("01/01/2017")
                        .ProcBy = Global1.GLBUserId
                        .Units = 168
                        .Action = "IN"
                        If Not .Save() Then
                            Throw Exx
                        End If
                    End With

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub






    Private Sub OpenPDFDocToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPDFDocToolStripMenuItem.Click
        If Global1.Business.Upgrade2017() Then
            MsgBox("succesfull Upgrade to 2017 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 Version", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_B() Then
            MsgBox("succesfull Upgrade to 2017 B Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 B Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TempToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Global1.Business.temp()

    End Sub

    Private Sub UpgradeEmployeeSplitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeEmployeeSplitToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_C() Then
            MsgBox("succesfull Upgrade to 2017 C Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 C Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub UpgradeNewEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeNewEmployeeToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_D() Then
            MsgBox("succesfull Upgrade to 2017 D Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 D Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub UpgradeNewTRXNFieldsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeNewTRXNFieldsToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_E() Then
            MsgBox("succesfull Upgrade to 2017 E Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 E Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpgradeNewEarningTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeNewEarningTypesToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_F() Then
            MsgBox("succesfull Upgrade to 2017 F Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 F Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpgradeToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeToolStripMenuItem2.Click
        If Global1.Business.Upgrade2017_F_2() Then
            MsgBox("succesfull Upgrade to 2017 F-2 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 F-2 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpgradeFECToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeFECToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_F_3() Then
            MsgBox("succesfull Upgrade to 2017 F-3 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 F-3 Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub DecreaseOfIncomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecreaseOfIncomeToolStripMenuItem.Click
        Dim F As New FrmPrSsDecreaseTable
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub UpgradeForce50ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeForce50ToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_G() Then
            MsgBox("succesfull Upgrade to 2017 G Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 G Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpgradeEmployeeNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeEmployeeNotesToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_H() Then
            MsgBox("succesfull Upgrade to 2017 H Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 H Version", MsgBoxStyle.Critical)
        End If
    End Sub



    Private Function Cdate1(ByVal S As String) As Date
        Dim Ar() As String
        Dim Ar1() As String

        Ar1 = S.Split(" ")

        S = Ar1(0)

        Ar = S.Split("/")

        Dim D As String = Ar(0)
        Dim M As String = Ar(1)
        Dim Y As String = Ar(2)

        Dim date1 As Date
        date1 = CDate(Y & "/" & M & "/" & D)
        Return date1

    End Function
    'Private Function Cdate2(ByVal S As String) As Date
    '    Dim Ar() As String
    '    Dim Ar1() As String

    '    Ar1 = S.Split(" ")

    '    S = Ar1(0)

    '    Ar = S.Split("/")

    '    Dim M As String = Ar(0)
    '    Dim D As String = Ar(1)
    '    Dim Y As String = Ar(2)

    '    Dim date1 As Date
    '    date1 = CDate(Y & "/" & M & "/" & D)
    '    Return date1

    'End Function

    Private Sub UpgradeHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeHistoryToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_I() Then
            MsgBox("succesfull Upgrade to 2017 I Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 I Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpgradeSalaryRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeSalaryRateToolStripMenuItem.Click
        If Global1.Business.Upgrade2017_K() Then
            MsgBox("succesfull Upgrade to 2017 K Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2017 K Version", MsgBoxStyle.Critical)
        End If
    End Sub





    Private Sub UpgradeNetYTDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeNetYTDToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_1() Then
            MsgBox("succesfull Upgrade to 2018 1 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 1 Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub UpgradeToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeToolStripMenuItem3.Click
        If Global1.Business.Upgrade2018_2() Then
            MsgBox("succesfull Upgrade to 2018 2 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 2 Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub AgreedSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgreedSalaryToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_3() Then
            MsgBox("succesfull Upgrade to 2018 3 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 3 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UpdateExtraBonusOnSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateExtraBonusOnSalaryToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_4() Then
            MsgBox("succesfull Upgrade to 2018 4 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 4 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BasisAndPFOnHeaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasisAndPFOnHeaderToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_5() Then
            MsgBox("succesfull Upgrade to 2018 5 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 5 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub InterCompanyTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterCompanyTaxToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_6() Then
            MsgBox("succesfull Upgrade to 2018 6 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 6 Version", MsgBoxStyle.Critical)
        End If
    End Sub



    Private Sub TestToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        Dim F As New FrmTestEncryption
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub PositionUnitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PositionUnitsToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_7() Then
            MsgBox("succesfull Upgrade to 2018 7 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 7 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PreviousFieldsOnEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousFieldsOnEmployeeToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_8() Then
            MsgBox("succesfull Upgrade to 2018 8 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 8 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub ImportEmployeesFromExcelToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportEmployeesFromExcelToolStripMenuItem1.Click
        Import_From_Excel_Employees_Template_1()
    End Sub


    Private Sub ImportEmployeesFromExcelTemplate2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportEmployeesFromExcelTemplate2ToolStripMenuItem.Click
        Import_From_Excel_Employees_Template_2()
    End Sub
    Private Sub Import_From_Excel_Employees_Template_1()

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        'I'm declaring a connectionobject within this class called pCn



        Try
            'on form load instantiate the connection object
            Dim param_file As IO.StreamReader
            Dim FileDir As String

            Dim Exx As New Exception
            Global1.FileName = FileName
            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()
            Dim sr2 As IO.StreamReader = New IO.StreamReader("Data\Excel\Employees.txt", System.Text.Encoding.GetEncoding(1253))


            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Do While sr2.Peek <> -1
                Me.Refresh()
                'Line = param_file.Read
                Line = sr2.ReadLine
                Ar = Line.Split("	")

                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim EmployeeCode As String
                Dim Gender As String
                Dim JobTitle As String
                Dim BirthDate As String
                Dim Status As String
                Dim EmploymentDate As String
                Dim MaritalStatus As String
                Dim SocialSecurityNo As String
                Dim IdentityCardNo As String
                Dim PassportNo As String
                Dim IncomeTaxNo As String
                Dim WorkEMail As String
                Dim DepartmentCode As String
                'Dim PayrollNo As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String
                Dim TerminationDate As String
                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Email As String
                Dim JobDescriptionCode As String
                Dim EmployeeJobDescription As String
                Dim PayrollCompanyNo As String
                Dim TemplateGroupCode As String
                Dim Notes As String
                ''''''''''''''''''''''''''''''''''''''''''''''
                'FindDefaults()
                Dim dsTemplateGroup As DataSet
                Dim dsAnal1 As DataSet
                Dim dsAnal2 As DataSet
                Dim dsAnal3 As DataSet
                Dim dsAnal4 As DataSet
                Dim dsAnal5 As DataSet
                Dim dsUnions As DataSet
                Dim dsCountries As DataSet
                Dim dsEmpPosition As DataSet
                Dim dsSIcategory As DataSet
                Dim dsEmpCommunity As DataSet
                Dim dsPayUnits As DataSet
                Dim dsCurCode As DataSet
                Dim dsPayMethods As DataSet
                Dim dsBanks As DataSet
                Dim dsTaxCardtype As DataSet
                Dim dsProFund As DataSet
                Dim dsMedicalFund As DataSet
                Dim dsSocialInsurance As DataSet
                Dim dsIndustrial As DataSet
                Dim dsUnemployment As DataSet
                Dim dsSocialCohesion As DataSet
                Dim dsSectorPay As DataSet
                Dim dsCommissionRates As DataSet
                Dim dsPerformanceBonus As DataSet
                Dim dsdutyHours As DataSet
                Dim dsOverLay As DataSet
                Dim dsFlightHours As DataSet
                Dim ContinueWithLoading As Boolean

                dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour

                '''''''''''''''''''''''''''''''''''''''''''''''


                Try

                    ContinueWithLoading = True
                    FirstName = Ar(0)
                    MiddleName = Ar(1)
                    LastName = Ar(2)
                    EmployeeCode = Ar(3)
                    Gender = Ar(4)
                    JobTitle = Ar(5)
                    BirthDate = Ar(6)
                    Status = Ar(7)
                    EmploymentDate = Ar(8)
                    MaritalStatus = Ar(9)
                    SocialSecurityNo = Ar(10)
                    IdentityCardNo = Ar(11)
                    PassportNo = Ar(12)
                    IncomeTaxNo = Ar(13)
                    WorkEMail = Ar(14)
                    DepartmentCode = Ar(15)
                    'PayrollNo = ar(16)
                    BankName = Ar(17)
                    BankAccountNo = Ar(18)
                    IBAN = Ar(19)
                    SWIFT = Ar(20)
                    TerminationDate = Ar(21)
                    AddressLine1 = Ar(22)
                    AddressLine2 = Ar(23)
                    AddressLine3 = Ar(24)
                    PostCode = Ar(25)
                    POBox = Ar(26)
                    POBoxPostCode = Ar(26)
                    City = Ar(27)
                    PhoneNo = Ar(28)
                    MobilePhone = Ar(29)
                    Email = Ar(30)
                    JobDescriptionCode = Ar(31)
                    EmployeeJobDescription = Ar(32)
                    PayrollCompanyNo = Ar(33)
                    Notes = Ar(34)


                    'TemplateGroupCode = DbNullToString(DT.Rows(i).Item(35))
                    Select Case Trim(PayrollCompanyNo)
                        Case "1"
                            PayrollCompanyNo = "1001"
                        Case "2"
                            PayrollCompanyNo = "3001"
                        Case "3"
                            PayrollCompanyNo = "2001"

                    End Select


                    TemplateGroupCode = PayrollCompanyNo 'Global1.PARAM_HCMTempGroup

                    '

                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False
                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If TemplateGroupCode = "" Or PayrollCompanyNo = "" Or EmployeeCode = "" Then
                        If NewEmployee And Status = "Terminated" Then
                            ContinueWithLoading = False
                        Else
                            MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                            ContinueWithLoading = False
                            Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                        End If
                    End If


                    If ContinueWithLoading Then

                        If NewEmployee Then


                            With Emp
                                .Code = EmployeeCode
                                If Status = "INNACTIVE" Then
                                    .Status = "I"
                                Else
                                    .Status = "A"
                                End If
                                .PayTyp_Code = "M01"
                                .TemGrp_Code = TemplateGroupCode
                                .EmpSta_Code = "A"

                                .LastName = LastName
                                .FirstName = FirstName
                                .FullName = LastName & " " & FirstName
                                If Gender = "Female" Then
                                    .Sex = "F"
                                    .Title = "MRS"
                                Else
                                    .Sex = "M"
                                    .Title = "MR"
                                End If
                                If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                    .BirthDate = Now.Date
                                Else
                                    .BirthDate = Cdate1(BirthDate)
                                End If
                                If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                    .MarSta_Code = "S"
                                ElseIf MaritalStatus = "Married" Then
                                    .MarSta_Code = "M"
                                ElseIf MaritalStatus = "Divorce" Then
                                    .MarSta_Code = "D"
                                ElseIf MaritalStatus = "Widow" Then
                                    .MarSta_Code = "W"
                                End If

                                .Address1 = AddressLine1
                                .Address2 = City
                                .Address3 = AddressLine2

                                .PostCode = PostCode
                                .Telephone1 = PhoneNo
                                .Telephone2 = MobilePhone
                                .Email = WorkEMail
                                .SocialInsNumber = SocialSecurityNo
                                .ComSin_EmpSocialInsNo = ""
                                .IdentificationCard = IdentityCardNo
                                .TaxID = IncomeTaxNo
                                .PassportNumber = PassportNo
                                .AlienNumber = ""
                                .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype)
                                .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                                .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode)
                                .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                .EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition)
                                .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)
                                .EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity)
                                .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                .PeriodUnits = 0
                                .AnnualUnits = 0
                                .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods)
                                .Bnk_Code = FindBankCodeFromSWIFT(dsBanks, SWIFT, True)
                                .BankAccount = BankAccountNo
                                .Bnk_CodeCo = GetFirstRecordOfDataset(dsBanks)
                                .BankAccountCo = ""
                                If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                    .StartDate = Now.Date
                                Else
                                    .StartDate = Cdate1(EmploymentDate)
                                End If
                                If TerminationDate <> "" Then
                                    Dim S As String
                                    Dim D As Date
                                    D = Cdate1(TerminationDate)
                                    S = Format(D, "yyyy/MM/dd")

                                    .TerminateDate = S
                                Else
                                    .TerminateDate = ""
                                End If

                                .OtherIncome1 = CDbl(0)
                                .OtherIncome2 = CDbl(0)
                                .OtherIncome3 = CDbl(0)
                                .PreviousEarnings = CDbl(0)
                                .Emp_PrevSIDeduct = CDbl(0)
                                .Emp_PrevSIContribute = CDbl(0)
                                .Emp_PrevITDeduct = CDbl(0)
                                .Emp_PrevPFDeduct = CDbl(0)

                                .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)

                                .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                .InterfaceTemCode = TemplateGroupCode
                                .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                .DrivingLicense = ""
                                .PensionNo = ""
                                .MyPayslipReport = ""
                                .IBAN = IBAN
                                .PreviousLifeIns = CDbl(0)
                                .PreviousDis = CDbl(0)
                                .PreviousST = CDbl(0)
                                .OtherIncome4 = CDbl(0)

                                .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                .FullPassName = ""
                                .Traveldocs = ""

                                .FirstEmployment = "0"
                                .IsSI = 0
                                .Password = ""
                                .Splitemployement = "0"
                                .NewEmployee = "0"



                                .Emp_GLAnal1 = ""
                                .Emp_GLAnal2 = ""
                                .Emp_GLAnal3 = ""
                                .Emp_GLAnal4 = ""

                                .PensionType = "0"

                                .CreationDate = Now.Date
                                .CreatedBy = Global1.GLBUserId
                                .AmendDate = Now.Date
                                .AmendBy = Global1.GLBUserId
                                .Notes = Notes

                                If Not .Save() Then
                                    Throw Exx
                                End If


                                '''
                                Dim k As Integer
                                Dim DsErn As DataSet
                                DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                If CheckDataSet(DsErn) Then
                                    For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                        Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                        Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                        EmpErn.EmpCode = .Code
                                        EmpErn.ErnCode = E1.ErnCodCode
                                        EmpErn.MyValue = "0.00"
                                        EmpErn.TemGrpCode = .TemGrp_Code
                                        If Not EmpErn.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Deductions
                                Dim DsDed As DataSet
                                DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                If CheckDataSet(DsDed) Then
                                    For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                        Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                        Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                        EmpDed.EmpCode = .Code
                                        EmpDed.DedCode = D.DedCodCode
                                        EmpDed.MyValue = "0.00"
                                        EmpDed.TemGrpCode = .TemGrp_Code
                                        If Not EmpDed.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Contributions
                                Dim DsCon As DataSet
                                DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                If CheckDataSet(DsCon) Then
                                    For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                        Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                        Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                        EmpCon.EmpCode = .Code
                                        EmpCon.ConCode = C.ConCodCode
                                        EmpCon.MyValue = "0.00"
                                        EmpCon.TemGrpCode = .TemGrp_Code
                                        If Not C.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If

                            End With



                        End If

                        '''''''''


                    End If




                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

            Loop
            sr2.Close()
            sr2.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Loading from Exelsys has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 

        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub Import_From_Excel_Employees_Template_2()



        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        'I'm declaring a connectionobject within this class called pCn



        Try
            'on form load instantiate the connection object
            Dim param_file As IO.StreamReader
            Dim FileDir As String

            Dim Exx As New Exception
            Global1.FileName = FileName
            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()
            Dim sr2 As IO.StreamReader = New IO.StreamReader("Data\Excel\NewEmployees.txt", System.Text.Encoding.GetEncoding(1253))


            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Do While sr2.Peek <> -1
                Me.Refresh()
                'Line = param_file.Read
                Line = sr2.ReadLine
                If Counter <> 0 Then


                    Ar = Line.Split("	")

                    Dim FirstName As String
                    Dim MiddleName As String
                    Dim LastName As String
                    Dim EmployeeCode As String
                    Dim Gender As String
                    Dim JobTitle As String
                    Dim BirthDate As String
                    Dim Status As String
                    Dim EmploymentDate As String
                    Dim MaritalStatus As String
                    Dim SocialSecurityNo As String
                    Dim IdentityCardNo As String
                    Dim PassportNo As String
                    Dim IncomeTaxNo As String
                    Dim WorkEMail As String
                    Dim DepartmentCode As String
                    'Dim PayrollNo As String
                    Dim BankName As String
                    Dim BankAccountNo As String
                    Dim IBAN As String
                    Dim SWIFT As String
                    Dim TerminationDate As String

                    Dim FullAddress As String
                    Dim AddressLine1 As String
                    Dim AddressLine2 As String
                    Dim AddressLine3 As String
                    Dim PostCode As String
                    Dim POBox As String
                    Dim POBoxPostCode As String
                    Dim City As String
                    Dim PhoneNo As String
                    Dim MobilePhone As String
                    Dim Email As String
                    Dim JobDescriptionCode As String
                    Dim EmployeeJobDescription As String
                    Dim PayrollCompanyNo As String
                    Dim TemplateGroupCode As String
                    Dim Notes As String
                    Dim Password As String
                    '----------------------------------------------

                    Dim DepFull1 As String
                    Dim DepFull2 As String
                    Dim PosFull As String
                    Dim SocCatFull As String
                    Dim BankCodeFull As String


                    Dim DepartmentCode1 As String
                    Dim DepartmentCode2 As String
                    Dim Position As String
                    Dim SiCatCode As String
                    Dim BankCode As String

                    Dim Salary As String


                    '----------------------------------------------
                    'FindDefaults()
                    Dim dsTemplateGroup As DataSet
                    Dim dsAnal1 As DataSet
                    Dim dsAnal2 As DataSet
                    Dim dsAnal3 As DataSet
                    Dim dsAnal4 As DataSet
                    Dim dsAnal5 As DataSet
                    Dim dsUnions As DataSet
                    Dim dsCountries As DataSet
                    Dim dsEmpPosition As DataSet
                    Dim dsSIcategory As DataSet
                    Dim dsEmpCommunity As DataSet
                    Dim dsPayUnits As DataSet
                    Dim dsCurCode As DataSet
                    Dim dsPayMethods As DataSet
                    Dim dsBanks As DataSet
                    Dim dsTaxCardtype As DataSet
                    Dim dsProFund As DataSet
                    Dim dsMedicalFund As DataSet
                    Dim dsSocialInsurance As DataSet
                    Dim dsIndustrial As DataSet
                    Dim dsUnemployment As DataSet
                    Dim dsSocialCohesion As DataSet
                    Dim dsSectorPay As DataSet
                    Dim dsCommissionRates As DataSet
                    Dim dsPerformanceBonus As DataSet
                    Dim dsdutyHours As DataSet
                    Dim dsOverLay As DataSet
                    Dim dsFlightHours As DataSet
                    Dim ContinueWithLoading As Boolean

                    dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                    dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                    dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                    dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                    dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                    dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                    dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                    dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                    dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                    dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                    dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                    dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                    dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                    dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                    dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                    dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                    dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                    dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                    dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                    dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                    dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                    dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                    dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                    dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                    dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                    dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                    dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour

                    '''''''''''''''''''''''''''''''''''''''''''''''


                    Try

                        ContinueWithLoading = True
                        EmployeeCode = Ar(1)
                        EmployeeCode = Trim(EmployeeCode).PadLeft(4, "0")
                        LastName = Ar(2)
                        FirstName = Ar(3)
                        MiddleName = ""

                        Gender = Ar(4)
                        BirthDate = Ar(5)
                        EmploymentDate = Ar(6)

                        FullAddress = Replace(Ar(10), """", "")
                        Dim Ara() As String
                        Ara = FullAddress.Split(",")
                        Try
                            AddressLine1 = Ara(0)
                        Catch ex As Exception
                            AddressLine1 = ""
                        End Try
                        Try
                            AddressLine2 = Ara(1)
                        Catch ex As Exception
                            AddressLine2 = ""
                        End Try
                        Try
                            AddressLine3 = Ara(4)
                        Catch ex As Exception
                            AddressLine3 = ""
                        End Try
                        Try
                            PostCode = Ara(2)
                        Catch ex As Exception
                            PostCode = ""
                        End Try
                        Try
                            City = Ara(3)
                        Catch ex As Exception
                            City = ""
                        End Try


                        POBox = ""
                        POBoxPostCode = ""


                        PhoneNo = ""
                        MobilePhone = Ar(11)
                        Email = Ar(13)
                        Password = Ar(14)

                        JobTitle = ""

                        Status = "ACTIVE"

                        MaritalStatus = ""

                        SocialSecurityNo = Ar(15)
                        IdentityCardNo = Ar(16)
                        PassportNo = Ar(16)
                        IncomeTaxNo = Ar(17)
                        Notes = Ar(12)



                        DepFull1 = Ar(23)
                        Dim Dep1() As String
                        Dep1 = DepFull1.Split("-")

                        DepFull2 = Ar(24)
                        Dim Dep2() As String
                        Dep2 = DepFull1.Split("-")

                        PosFull = Ar(25)
                        Dim Pos() As String
                        Pos = PosFull.Split("-")

                        SocCatFull = Ar(18)
                        Dim SiCat() As String
                        SiCat = SocCatFull.Split("-")

                        DepartmentCode1 = Dep1(0)
                        DepartmentCode2 = Dep2(0)
                        Position = Pos(0)
                        SiCatCode = SiCat(0)


                        BankName = ""
                        BankAccountNo = ""
                        IBAN = Ar(28)
                        SWIFT = Ar(27)

                        Dim BankCodeAr() As String
                        BankCodeFull = Ar(26)
                        BankCodeAr = BankCodeFull.Split("-")
                        BankCode = BankCodeAr(0)


                        TerminationDate = ""

                        Salary = Ar(7)


                        JobDescriptionCode = ""
                        EmployeeJobDescription = ""

                        PayrollCompanyNo = Trim(Ar(30))
                        Notes = ""


                        'TemplateGroupCode = DbNullToString(DT.Rows(i).Item(35))


                        TemplateGroupCode = PayrollCompanyNo 'Global1.PARAM_HCMTempGroup

                        '

                        dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                        Dim NewEmployee As Boolean = False
                        Dim Emp As New cPrMsEmployees(EmployeeCode)

                        If Emp.Code Is Nothing Then
                            NewEmployee = True
                        End If

                        If Emp.Code = "" Then
                            NewEmployee = True
                        End If

                        If TemplateGroupCode = "" Or PayrollCompanyNo = "" Or EmployeeCode = "" Then
                            If NewEmployee And Status = "Terminated" Then
                                ContinueWithLoading = False
                            Else
                                MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                                ContinueWithLoading = False
                                Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                            End If
                        End If


                        If ContinueWithLoading Then

                            If NewEmployee Then


                                With Emp
                                    .Code = EmployeeCode
                                    If Status = "INNACTIVE" Then
                                        .Status = "I"
                                    Else
                                        .Status = "A"
                                    End If
                                    .PayTyp_Code = "M01"
                                    .TemGrp_Code = TemplateGroupCode
                                    .EmpSta_Code = "A"

                                    .LastName = LastName
                                    .FirstName = FirstName
                                    .FullName = LastName & " " & FirstName
                                    If Gender = "Female" Then
                                        .Sex = "F"
                                        .Title = "MRS"
                                    Else
                                        .Sex = "M"
                                        .Title = "MR"
                                    End If
                                    If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                        .BirthDate = Now.Date
                                    Else
                                        .BirthDate = Cdate1(BirthDate)
                                    End If
                                    If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                        .MarSta_Code = "S"
                                    ElseIf MaritalStatus = "Married" Then
                                        .MarSta_Code = "M"
                                    ElseIf MaritalStatus = "Divorce" Then
                                        .MarSta_Code = "D"
                                    ElseIf MaritalStatus = "Widow" Then
                                        .MarSta_Code = "W"
                                    End If

                                    .Address1 = AddressLine1
                                    .Address2 = City
                                    .Address3 = AddressLine2

                                    .PostCode = PostCode
                                    .Telephone1 = PhoneNo
                                    .Telephone2 = MobilePhone
                                    .Email = Email
                                    .SocialInsNumber = SocialSecurityNo
                                    .ComSin_EmpSocialInsNo = ""
                                    .IdentificationCard = IdentityCardNo
                                    .TaxID = IncomeTaxNo
                                    .PassportNumber = PassportNo
                                    .AlienNumber = ""
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype)
                                    .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                                    .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode1)
                                    .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3, DepartmentCode2)
                                    .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                    .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                    .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                    .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                    .EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)
                                    .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)
                                    .EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)
                                    .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                    .PeriodUnits = 0
                                    .AnnualUnits = 0
                                    .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                    .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods)
                                    .Bnk_Code = BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)
                                    .BankAccount = BankAccountNo
                                    .Bnk_CodeCo = GetFirstRecordOfDataset(dsBanks)
                                    .BankAccountCo = ""
                                    If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                        .StartDate = Now.Date
                                    Else
                                        .StartDate = Cdate1(EmploymentDate)
                                    End If
                                    If TerminationDate <> "" Then
                                        Dim S As String
                                        Dim D As Date
                                        D = Cdate1(TerminationDate)
                                        S = Format(D, "yyyy/MM/dd")

                                        .TerminateDate = S
                                    Else
                                        .TerminateDate = ""
                                    End If

                                    .OtherIncome1 = CDbl(0)
                                    .OtherIncome2 = CDbl(0)
                                    .OtherIncome3 = CDbl(0)
                                    .PreviousEarnings = CDbl(0)
                                    .Emp_PrevSIDeduct = CDbl(0)
                                    .Emp_PrevSIContribute = CDbl(0)
                                    .Emp_PrevITDeduct = CDbl(0)
                                    .Emp_PrevPFDeduct = CDbl(0)

                                    .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                    .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                    .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)

                                    .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                    .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                    .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                    .InterfaceTemCode = TemplateGroupCode
                                    .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                    .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                    .DrivingLicense = ""
                                    .PensionNo = ""
                                    .MyPayslipReport = ""
                                    .IBAN = IBAN
                                    .PreviousLifeIns = CDbl(0)
                                    .PreviousDis = CDbl(0)
                                    .PreviousST = CDbl(0)
                                    .OtherIncome4 = CDbl(0)

                                    .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                    .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                    .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                    .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                    .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                    .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                    .FullPassName = ""
                                    .Traveldocs = ""

                                    .FirstEmployment = "0"
                                    .IsSI = 0
                                    .Password = Password
                                    .Splitemployement = "0"
                                    .NewEmployee = "1"



                                    .Emp_GLAnal1 = ""
                                    .Emp_GLAnal2 = ""
                                    .Emp_GLAnal3 = ""
                                    .Emp_GLAnal4 = ""

                                    .PensionType = "0"

                                    .CreationDate = Now.Date
                                    .CreatedBy = Global1.GLBUserId
                                    .AmendDate = Now.Date
                                    .AmendBy = Global1.GLBUserId
                                    .Notes = Notes

                                    If Not .Save() Then
                                        Throw Exx
                                    End If

                                    Dim SalVal As Double
                                    Salary = Replace(Salary, "$", "")
                                    Salary = Replace(Salary, "€", "")
                                    Salary = Replace(Salary, """", "")
                                    Salary = Trim(Salary)
                                    SalVal = CDbl(Salary)


                                    Dim EmpSal As New cPrTxEmployeeSalary
                                    With EmpSal

                                        .Id = 0
                                        .Emp_Code = EmployeeCode
                                        .Date1 = Now.Date
                                        .SalaryValue = CDbl(SalVal)
                                        .Basic = CDbl(0)
                                        .EffPayDate = Cdate1(EmploymentDate)
                                        .Cola = CDbl(0)
                                        .EffArrearsDate = Cdate1(EmploymentDate)
                                        .Usr_Id = Global1.GLBUserId
                                        .myRate = CDbl(0)
                                        .IsCola = "N"
                                        .EmpSal_Dif = CDbl(0)

                                        If Not .Save() Then
                                            Throw Exx
                                        End If


                                    End With


                                    '''
                                    Dim k As Integer
                                    Dim DsErn As DataSet
                                    DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                    If CheckDataSet(DsErn) Then
                                        For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                            Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                            Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                            EmpErn.EmpCode = .Code
                                            EmpErn.ErnCode = E1.ErnCodCode
                                            EmpErn.MyValue = "0.00"
                                            EmpErn.TemGrpCode = .TemGrp_Code
                                            If Not EmpErn.Save Then
                                                Throw Exx
                                            End If
                                        Next
                                    End If
                                    'Deductions
                                    Dim DsDed As DataSet
                                    DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                    If CheckDataSet(DsDed) Then
                                        For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                            Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                            Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                            EmpDed.EmpCode = .Code
                                            EmpDed.DedCode = D.DedCodCode
                                            EmpDed.MyValue = "0.00"
                                            EmpDed.TemGrpCode = .TemGrp_Code
                                            If Not EmpDed.Save Then
                                                Throw Exx
                                            End If
                                        Next
                                    End If
                                    'Contributions
                                    Dim DsCon As DataSet
                                    DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                    If CheckDataSet(DsCon) Then
                                        For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                            Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                            Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                            EmpCon.EmpCode = .Code
                                            EmpCon.ConCode = C.ConCodCode
                                            EmpCon.MyValue = "0.00"
                                            EmpCon.TemGrpCode = .TemGrp_Code
                                            If Not C.Save Then
                                                Throw Exx
                                            End If
                                        Next
                                    End If

                                End With



                            End If

                            '''''''''

                        End If





                    Catch ex As Exception
                        Global1.Business.Rollback()
                        Utils.ShowException(ex)
                        MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                    End Try
                End If
                Counter = Counter + 1
            Loop
            sr2.Close()
            sr2.Dispose()
            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 

        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub AllowanceOptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllowanceOptionToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_9() Then
            MsgBox("succesfull Upgrade to 2018 9 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 9 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub SplitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_10() Then
            MsgBox("succesfull Upgrade to 2018 10 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 10 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub SwiftCodeOnBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwiftCodeOnBankToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_11() Then
            MsgBox("succesfull Upgrade to 2018 11 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 11 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            Dim F As New frmAaSsUsers
            F.MdiParent = Me
            F.Show()
        Else
            MsgBox("You need special rights to access this Menu", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub TimeSheetsTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeSheetsTableToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_12() Then
            MsgBox("succesfull Upgrade to 2018 12 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 12 Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub PeriodUnits2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodUnits2ToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_13() Then
            MsgBox("succesfull Upgrade to 2018 13 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 13 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TimeSheetsTable2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeSheetsTable2ToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_14() Then
            MsgBox("succesfull Upgrade to 2018 14 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 14 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TimeSheetsTable3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeSheetsTable3ToolStripMenuItem.Click
        If Global1.Business.Upgrade2018_15() Then
            MsgBox("succesfull Upgrade to 2018 15 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2018 15 Version", MsgBoxStyle.Critical)
        End If
    End Sub



    Private Sub mnuSystemUpgrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSystemUpgrade.Click
        Dim F As New FrmSystemUpgrade
        F.ShowDialog()
    End Sub

    Private Sub MnuGESI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuGESI.Click
        Dim f As New FrmPrSsGesi
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuExecuteQueries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExecuteQueries.Click
        Dim F As New FrmQueries
        F.MdiParent = Me
        F.Show()

    End Sub

    Private Sub ImportEmployeesFromExcelTemplate2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportEmployeesFromExcelTemplate2ToolStripMenuItem1.Click
        Dim F As New FrmLoadEmployeesFromExcel
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            Import_From_Excel_Employees_Template_3(GLBLoadingFromExcel_TemGroup)
        End If

    End Sub
    Private Sub Import_From_Excel_Employees_Template_3(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 3
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCodeNumeric As String
                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim EmployeeCode As String
                Dim Gender As String
                Dim JobTitle As String
                Dim BirthDate As String
                Dim Status As String
                Dim EmploymentDate As String
                Dim AnnualLeave As String
                Dim MaritalStatus As String
                Dim SocialSecurityNo As String
                Dim IdentityCardNo As String
                Dim PassportNo As String
                Dim AlienNumber As String
                Dim IncomeTaxNo As String
                Dim WorkEMail As String
                Dim Department As String
                Dim DepartmentCode1 As String

                'Dim Analysis1 As String
                'Dim Analysis2 As String
                'Dim Analysis3 As String
                'Dim Analysis4 As String

                'Dim PayrollNo As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String
                Dim TerminationDate As String

                Dim FullAddress As String
                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Email As String
                Dim Email2 As String
                Dim JobDescriptionCode As String
                Dim EmployeeJobDescription As String
                Dim PayrollCompanyNo As String
                Dim TemplateGroupCode As String
                Dim Notes As String
                Dim Password As String
                Dim Nationality As String
                Dim BankBenName As String
                '----------------------------------------------

                Dim DepFull1 As String
                Dim DepFull2 As String
                Dim PosFull As String
                Dim SocCatFull As String
                Dim BankCodeFull As String


                'Dim DepartmentCode1 As String
                'Dim DepartmentCode2 As String
                'Dim DepartmentCode3 As String
                'Dim DepartmentCode4 As String

                Dim Position As String
                Dim PositionCode1 As String
                Dim SiCatCode As String
                Dim BankCode As String

                Dim Salary As String
                Dim HireReason As String


                '----------------------------------------------
                'FindDefaults()
                Dim dsTemplateGroup As DataSet
                Dim dsAnal1 As DataSet
                Dim dsAnal2 As DataSet
                Dim dsAnal3 As DataSet
                Dim dsAnal4 As DataSet
                Dim dsAnal5 As DataSet
                Dim dsUnions As DataSet
                Dim dsCountries As DataSet
                Dim dsEmpPosition As DataSet
                Dim dsSIcategory As DataSet
                Dim dsEmpCommunity As DataSet
                Dim dsPayUnits As DataSet
                Dim dsCurCode As DataSet
                Dim dsPayMethods As DataSet
                Dim dsBanks As DataSet
                Dim dsTaxCardtype As DataSet
                Dim dsProFund As DataSet
                Dim dsMedicalFund As DataSet
                Dim dsSocialInsurance As DataSet
                Dim dsGesi As DataSet

                Dim dsIndustrial As DataSet
                Dim dsUnemployment As DataSet
                Dim dsSocialCohesion As DataSet
                Dim dsSectorPay As DataSet
                Dim dsCommissionRates As DataSet
                Dim dsPerformanceBonus As DataSet
                Dim dsdutyHours As DataSet
                Dim dsOverLay As DataSet
                Dim dsFlightHours As DataSet
                Dim ContinueWithLoading As Boolean
                Dim CompanySocialInsuranceNo As String

                Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
                Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
                Dim ALLeaveInUnits As Double

                Dim Units As String
                Dim GenAnalysis1 As String

                Dim EmpCodeFromExcel As String

                CompanySocialInsuranceNo = Comp.SIRegNo




                dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
                dsGesi = Global1.Business.GetAllPrSsGesi

                EmployeeCodeNumeric = Global1.Business.GetLastEmployeeCode(Me.GLBLoadingFromExcel_TemGroup)


                '''''''''''''''''''''''''''''''''''''''''''''''

                Try

                    ContinueWithLoading = True



                    ' If EmployeeCodeNumeric <> "" Then
                    ' EmployeeCodeNumeric = EmployeeCodeNumeric + 1
                    ' End If

                    EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                    If EmpCodeFromExcel <> "" Then
                        EmployeeCodeNumeric = EmpCodeFromExcel
                    End If

                    EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
                    LastName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                    FirstName = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)

                    If FirstName = "" Then
                        Exit Do
                    End If
                    'Dim arr() As String
                    'arr = FirstName.Split(" ")

                    'LastName = arr(1)
                    'FirstName = arr(0)


                    MiddleName = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                    FirstName = FirstName & " " & MiddleName

                    Gender = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                    BirthDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


                    EmploymentDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
                    AnnualLeave = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)
                    ALLeaveInUnits = 0

                    If AnnualLeave <> "" Then
                        If IsNumeric(AnnualLeave) Then
                            ALLeaveInUnits = RoundMe2(AnnualLeave * TGroup.DayUnits, 2)
                        End If
                    End If


                    AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
                    AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
                    If AddressLine1 Is Nothing Then
                        AddressLine1 = ""
                    End If
                    If AddressLine2 Is Nothing Then
                        AddressLine2 = ""
                    End If



                    City = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
                    PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

                    POBox = ""
                    POBoxPostCode = ""

                    '''''''''''''
                    'Dim Ara() As String
                    'Ara = AddressLine1.Split(",")
                    'AddressLine1 = Ara(0)
                    'AddressLine2 = Ara(1)
                    'PostCode = Ara(2)
                    'City = Ara(3)

                    ''''''''''''

                    PhoneNo = ""

                    MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
                    If MobilePhone Is Nothing Then
                        MobilePhone = ""
                    End If

                    Email = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
                    If Email Is Nothing Then
                        Email = ""
                    End If
                    Email2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
                    If Email2 Is Nothing Then
                        Email2 = ""
                    End If
                    If Email2 <> "" Then
                        Email = Email2
                    End If

                    Password = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
                    If Password Is Nothing Then
                        Password = ""
                    End If

                    JobTitle = ""

                    Status = "ACTIVE"

                    MaritalStatus = ""

                    SocialSecurityNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
                    IdentityCardNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
                    PassportNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
                    IncomeTaxNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
                    AlienNumber = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)

                    Nationality = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)

                    Department = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                    'Analysis2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                    'Analysis3 = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    'Analysis4 = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)


                    DepartmentCode1 = FindDepartment1CodeFromDesc(Department)
                    ' DepartmentCode2 = FindDepartment2CodeFromDesc(Department)
                    ' DepartmentCode3 = FindDepartment3CodeFromDesc(Department)
                    ' DepartmentCode4 = FindDepartment4CodeFromDesc(Department)




                    If DepartmentCode1 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department:   " & Department & Chr(10)
                    End If

                    Position = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    PositionCode1 = GetPositionCodeFromDesc(Position)

                    SiCatCode = FindSICatCodeFromNationality(Nationality)




                    BankAccountNo = ""
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
                    SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)


                    BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                    If BankCode = "" Then
                        BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                    End If



                    TerminationDate = ""

                    Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
                    If Salary = "" Then
                        Salary = 0
                    End If
                    BankBenName = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)

                    Units = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)
                    GenAnalysis1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 35).value)
                    HireReason = NothingToEmpty(xlWorkSheet.Cells(Counter, 36).value)

                    If HireReason <> "N" Or HireReason <> "T" Then
                        HireReason = "N"
                    End If


                    JobDescriptionCode = ""
                    EmployeeJobDescription = ""

                    PayrollCompanyNo = ""
                    Notes = ""


                    TemplateGroupCode = TemplateGroupForLoading

                    '

                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False
                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If TemplateGroupCode = "" Or EmployeeCode = "" Then
                        If NewEmployee And Status = "Terminated" Then
                            ContinueWithLoading = False
                        Else
                            MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                            ContinueWithLoading = False
                            Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                        End If
                    End If


                    If ContinueWithLoading Then

                        If NewEmployee Then


                            With Emp
                                .Code = EmployeeCode
                                If Status = "INNACTIVE" Then
                                    .Status = "I"
                                Else
                                    .Status = "A"
                                End If
                                .PayTyp_Code = "M01"
                                .TemGrp_Code = TemplateGroupCode
                                .EmpSta_Code = "A"

                                .LastName = LastName
                                .FirstName = FirstName
                                .FullName = LastName & " " & FirstName
                                If Gender = "Female" Then
                                    .Sex = "F"
                                    .Title = "MRS"
                                Else
                                    .Sex = "M"
                                    .Title = "MR"
                                End If
                                If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                    .BirthDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = BirthDate.Split("/")
                                    BirthDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .BirthDate = CDate(BirthDate)
                                End If
                                If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                    .MarSta_Code = "S"
                                ElseIf MaritalStatus = "Married" Then
                                    .MarSta_Code = "M"
                                ElseIf MaritalStatus = "Divorce" Then
                                    .MarSta_Code = "D"
                                ElseIf MaritalStatus = "Widow" Then
                                    .MarSta_Code = "W"
                                End If

                                .Address1 = AddressLine1
                                .Address2 = City
                                .Address3 = AddressLine2

                                .PostCode = PostCode
                                .Telephone1 = PhoneNo
                                .Telephone2 = MobilePhone
                                .Email = Email
                                .SocialInsNumber = SocialSecurityNo

                                .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                                .IdentificationCard = IdentityCardNo
                                .TaxID = IncomeTaxNo
                                .PassportNumber = PassportNo
                                .AlienNumber = AlienNumber

                                If AlienNumber <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "7")
                                End If
                                If IncomeTaxNo <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "1")
                                End If
                                If AlienNumber = "" And IncomeTaxNo = "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "3")
                                End If



                                .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                                '**********************************
                                .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, Department)


                                .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                '.EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)

                                .EmpPos_Code = PositionCode1


                                .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)

                                .EmpCmm_Code = FindSICatCodeFromNationality(Nationality)
                                '.EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)

                                .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                If IsNumeric(Units) Then
                                    .PeriodUnits = Units
                                Else
                                    .PeriodUnits = 0
                                End If

                                .AnnualUnits = 0
                                .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods, "3")

                                .Bnk_Code = BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)

                                .BankAccount = BankAccountNo
                                .Bnk_CodeCo = Me.GLBLoadingFromExcel_CompanyBankCode 'GetFirstRecordOfDataset(dsBanks)
                                .BankAccountCo = Me.GLBLoadingFromExcel_CompanyIBAN

                                If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                    .StartDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = EmploymentDate.Split("/")
                                    EmploymentDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .StartDate = CDate(EmploymentDate)

                                End If
                                If TerminationDate <> "" Then
                                    Dim S As String
                                    Dim D As Date
                                    D = Cdate1(TerminationDate)
                                    S = Format(D, "yyyy/MM/dd")

                                    .TerminateDate = S
                                Else
                                    .TerminateDate = ""
                                End If

                                .OtherIncome1 = CDbl(0)
                                .OtherIncome2 = CDbl(0)
                                .OtherIncome3 = CDbl(0)
                                .PreviousEarnings = CDbl(0)
                                .Emp_PrevSIDeduct = CDbl(0)
                                .Emp_PrevSIContribute = CDbl(0)
                                .Emp_PrevITDeduct = CDbl(0)
                                .Emp_PrevPFDeduct = CDbl(0)

                                .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance, GLBLoadingFromExcel_SIRateCode)
                                .GESICode = GetFirstRecordOfDataset(dsGesi)

                                .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                .InterfaceTemCode = TemplateGroupCode
                                .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                .DrivingLicense = ""
                                .PensionNo = ""
                                .MyPayslipReport = Me.GLBLoadingFromExcel_PayslipReport
                                .IBAN = IBAN
                                .PreviousLifeIns = CDbl(0)
                                .PreviousDis = CDbl(0)
                                .PreviousST = CDbl(0)
                                .OtherIncome4 = CDbl(0)

                                .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                .FullPassName = ""
                                .Traveldocs = ""

                                .FirstEmployment = "0"
                                .IsSI = 0
                                .Password = Password
                                .Splitemployement = "0"
                                .BankBenName = BankBenName
                                .NewEmployee = "1"



                                .Emp_GLAnal1 = ""
                                .Emp_GLAnal2 = ""
                                .Emp_GLAnal3 = ""
                                .Emp_GLAnal4 = ""

                                .PensionType = "0"

                                .CreationDate = Now.Date
                                .CreatedBy = Global1.GLBUserId
                                .AmendDate = Now.Date
                                .AmendBy = Global1.GLBUserId
                                .Notes = Notes
                                .AnalGen1 = GenAnalysis1
                                .HireReason = HireReason
                                .TermReason = ""

                                If Not .Save(False) Then
                                    Throw Exx
                                End If

                                Dim SalVal As Double
                                Salary = Replace(Salary, "$", "")
                                Salary = Replace(Salary, "€", "")
                                Salary = Replace(Salary, """", "")
                                Salary = Trim(Salary)
                                SalVal = CDbl(Salary)


                                Dim EmpSal As New cPrTxEmployeeSalary
                                With EmpSal

                                    .Id = 0
                                    .Emp_Code = EmployeeCode
                                    .Date1 = Now.Date
                                    .SalaryValue = CDbl(SalVal)
                                    .Basic = CDbl(0)
                                    .EffPayDate = CDate(EmploymentDate)
                                    .Cola = CDbl(0)
                                    .EffArrearsDate = CDate(EmploymentDate)
                                    .Usr_Id = Global1.GLBUserId
                                    .myRate = CDbl(0)
                                    .IsCola = "N"
                                    .EmpSal_Dif = CDbl(0)

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With


                                Dim EmpAL As New cPrTxEmployeeLeave
                                With EmpAL

                                    .Id = 0
                                    .EmpCode = EmployeeCode
                                    .Status = "Approved"
                                    .Type = "1"
                                    .ReqDate = EmploymentDate
                                    .ProcDate = EmploymentDate
                                    .FromDate = EmploymentDate
                                    .ToDate = EmploymentDate
                                    .ProcBy = Global1.GLBUserId
                                    .Units = ALLeaveInUnits
                                    .Action = AN_IncreaseCODE

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With



                                '''
                                Dim k As Integer
                                Dim DsErn As DataSet
                                DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                If CheckDataSet(DsErn) Then
                                    For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                        Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                        Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                        EmpErn.EmpCode = .Code
                                        EmpErn.ErnCode = E1.ErnCodCode
                                        EmpErn.MyValue = "0.00"
                                        EmpErn.TemGrpCode = .TemGrp_Code
                                        If Not EmpErn.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Deductions
                                Dim DsDed As DataSet
                                DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                If CheckDataSet(DsDed) Then
                                    For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                        Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                        Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                        EmpDed.EmpCode = .Code
                                        EmpDed.DedCode = D.DedCodCode
                                        EmpDed.MyValue = "0.00"
                                        EmpDed.TemGrpCode = .TemGrp_Code
                                        If Not EmpDed.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Contributions
                                Dim DsCon As DataSet
                                DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                If CheckDataSet(DsCon) Then
                                    For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                        Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                        Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                        EmpCon.EmpCode = .Code
                                        EmpCon.ConCode = C.ConCodCode
                                        EmpCon.MyValue = "0.00"
                                        EmpCon.TemGrpCode = .TemGrp_Code
                                        If Not C.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If

                            End With



                        End If

                        '''''''''

                    End If

                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Sub Import_From_Excel_Employees_Template_3_NEW(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 3
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCodeNumeric As String
                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim EmployeeCode As String
                Dim Gender As String
                Dim JobTitle As String
                Dim BirthDate As String
                Dim Status As String
                Dim EmploymentDate As String
                Dim AnnualLeave As String
                Dim MaritalStatus As String
                Dim SocialSecurityNo As String
                Dim IdentityCardNo As String
                Dim PassportNo As String
                Dim AlienNumber As String
                Dim IncomeTaxNo As String
                Dim WorkEMail As String
                Dim DepartmentCode As String

                Dim Analysis1 As String
                Dim Analysis2 As String
                Dim Analysis3 As String
                Dim Analysis4 As String

                'Dim PayrollNo As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String
                Dim TerminationDate As String

                Dim FullAddress As String
                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Email As String
                Dim Email2 As String
                Dim JobDescriptionCode As String
                Dim EmployeeJobDescription As String
                Dim PayrollCompanyNo As String
                Dim TemplateGroupCode As String
                Dim Notes As String
                Dim Password As String
                Dim Nationality As String
                Dim BankBenName As String
                '----------------------------------------------

                Dim DepFull1 As String
                Dim DepFull2 As String
                Dim PosFull As String
                Dim SocCatFull As String
                Dim BankCodeFull As String


                Dim DepartmentCode1 As String
                Dim DepartmentCode2 As String
                Dim DepartmentCode3 As String
                Dim DepartmentCode4 As String

                Dim Position As String
                Dim PositionCode1 As String
                Dim SiCatCode As String
                Dim BankCode As String

                Dim Salary As String


                '----------------------------------------------
                'FindDefaults()
                Dim dsTemplateGroup As DataSet
                Dim dsAnal1 As DataSet
                Dim dsAnal2 As DataSet
                Dim dsAnal3 As DataSet
                Dim dsAnal4 As DataSet
                Dim dsAnal5 As DataSet
                Dim dsUnions As DataSet
                Dim dsCountries As DataSet
                Dim dsEmpPosition As DataSet
                Dim dsSIcategory As DataSet
                Dim dsEmpCommunity As DataSet
                Dim dsPayUnits As DataSet
                Dim dsCurCode As DataSet
                Dim dsPayMethods As DataSet
                Dim dsBanks As DataSet
                Dim dsTaxCardtype As DataSet
                Dim dsProFund As DataSet
                Dim dsMedicalFund As DataSet
                Dim dsSocialInsurance As DataSet
                Dim dsGesi As DataSet

                Dim dsIndustrial As DataSet
                Dim dsUnemployment As DataSet
                Dim dsSocialCohesion As DataSet
                Dim dsSectorPay As DataSet
                Dim dsCommissionRates As DataSet
                Dim dsPerformanceBonus As DataSet
                Dim dsdutyHours As DataSet
                Dim dsOverLay As DataSet
                Dim dsFlightHours As DataSet
                Dim ContinueWithLoading As Boolean
                Dim CompanySocialInsuranceNo As String

                Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
                Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
                Dim ALLeaveInUnits As Double

                Dim Units As String
                Dim GenAnalysis1 As String

                Dim EmpCodeFromExcel As String

                CompanySocialInsuranceNo = Comp.SIRegNo




                dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
                dsGesi = Global1.Business.GetAllPrSsGesi

                EmployeeCodeNumeric = Global1.Business.GetLastEmployeeCode(Me.GLBLoadingFromExcel_TemGroup)


                '''''''''''''''''''''''''''''''''''''''''''''''

                Try

                    ContinueWithLoading = True



                    If EmployeeCodeNumeric <> "" Then
                        EmployeeCodeNumeric = EmployeeCodeNumeric + 1
                    End If

                    EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                    If EmpCodeFromExcel <> "" Then
                        EmployeeCodeNumeric = EmpCodeFromExcel
                    End If

                    EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
                    LastName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                    FirstName = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)

                    If FirstName = "" Then
                        Exit Do
                    End If
                    'Dim arr() As String
                    'arr = FirstName.Split(" ")

                    'LastName = arr(1)
                    'FirstName = arr(0)


                    MiddleName = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                    FirstName = FirstName & " " & MiddleName

                    Gender = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                    BirthDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


                    EmploymentDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
                    AnnualLeave = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)
                    ALLeaveInUnits = 0

                    If AnnualLeave <> "" Then
                        If IsNumeric(AnnualLeave) Then
                            ALLeaveInUnits = RoundMe2(AnnualLeave * TGroup.DayUnits, 2)
                        End If
                    End If


                    AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
                    AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
                    If AddressLine1 Is Nothing Then
                        AddressLine1 = ""
                    End If
                    If AddressLine2 Is Nothing Then
                        AddressLine2 = ""
                    End If



                    City = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
                    PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

                    POBox = ""
                    POBoxPostCode = ""

                    '''''''''''''
                    'Dim Ara() As String
                    'Ara = AddressLine1.Split(",")
                    'AddressLine1 = Ara(0)
                    'AddressLine2 = Ara(1)
                    'PostCode = Ara(2)
                    'City = Ara(3)

                    ''''''''''''

                    PhoneNo = ""

                    MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
                    If MobilePhone Is Nothing Then
                        MobilePhone = ""
                    End If

                    Email = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
                    If Email Is Nothing Then
                        Email = ""
                    End If
                    Email2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
                    If Email2 Is Nothing Then
                        Email2 = ""
                    End If
                    If Email2 <> "" Then
                        Email = Email2
                    End If

                    Password = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
                    If Password Is Nothing Then
                        Password = ""
                    End If

                    JobTitle = ""

                    Status = "ACTIVE"

                    MaritalStatus = ""

                    SocialSecurityNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
                    IdentityCardNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
                    PassportNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
                    IncomeTaxNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
                    AlienNumber = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)

                    Nationality = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)

                    Analysis2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                    Analysis2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                    Analysis3 = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    Analysis4 = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)


                    ' DepartmentCode1 = FindDepartment1CodeFromDesc(Department)
                    ' DepartmentCode2 = FindDepartment2CodeFromDesc(Department)
                    ' DepartmentCode3 = FindDepartment3CodeFromDesc(Department)
                    ' DepartmentCode4 = FindDepartment4CodeFromDesc(Department)




                    If DepartmentCode1 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department:   " & Analysis2 & Chr(10)
                    End If

                    Position = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    PositionCode1 = GetPositionCodeFromDesc(Position)

                    SiCatCode = FindSICatCodeFromNationality(Nationality)




                    BankAccountNo = ""
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
                    SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)


                    BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                    If BankCode = "" Then
                        BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                    End If



                    TerminationDate = ""

                    Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
                    If Salary = "" Then
                        Salary = 0
                    End If
                    BankBenName = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)

                    Units = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)
                    GenAnalysis1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 35).value)


                    JobDescriptionCode = ""
                    EmployeeJobDescription = ""

                    PayrollCompanyNo = ""
                    Notes = ""


                    TemplateGroupCode = TemplateGroupForLoading

                    '

                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False
                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If TemplateGroupCode = "" Or EmployeeCode = "" Then
                        If NewEmployee And Status = "Terminated" Then
                            ContinueWithLoading = False
                        Else
                            MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                            ContinueWithLoading = False
                            Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                        End If
                    End If


                    If ContinueWithLoading Then

                        If NewEmployee Then


                            With Emp
                                .Code = EmployeeCode
                                If Status = "INNACTIVE" Then
                                    .Status = "I"
                                Else
                                    .Status = "A"
                                End If
                                .PayTyp_Code = "M01"
                                .TemGrp_Code = TemplateGroupCode
                                .EmpSta_Code = "A"

                                .LastName = LastName
                                .FirstName = FirstName
                                .FullName = LastName & " " & FirstName
                                If Gender = "Female" Then
                                    .Sex = "F"
                                    .Title = "MRS"
                                Else
                                    .Sex = "M"
                                    .Title = "MR"
                                End If
                                If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                    .BirthDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = BirthDate.Split("/")
                                    BirthDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .BirthDate = CDate(BirthDate)
                                End If
                                If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                    .MarSta_Code = "S"
                                ElseIf MaritalStatus = "Married" Then
                                    .MarSta_Code = "M"
                                ElseIf MaritalStatus = "Divorce" Then
                                    .MarSta_Code = "D"
                                ElseIf MaritalStatus = "Widow" Then
                                    .MarSta_Code = "W"
                                End If

                                .Address1 = AddressLine1
                                .Address2 = City
                                .Address3 = AddressLine2

                                .PostCode = PostCode
                                .Telephone1 = PhoneNo
                                .Telephone2 = MobilePhone
                                .Email = Email
                                .SocialInsNumber = SocialSecurityNo

                                .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                                .IdentificationCard = IdentityCardNo
                                .TaxID = IncomeTaxNo
                                .PassportNumber = PassportNo
                                .AlienNumber = AlienNumber

                                If AlienNumber <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "7")
                                End If
                                If IncomeTaxNo <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "1")
                                End If
                                If AlienNumber = "" And IncomeTaxNo = "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "3")
                                End If



                                .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)

                                .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode1)


                                .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                '.EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)

                                .EmpPos_Code = PositionCode1


                                .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)

                                .EmpCmm_Code = FindSICatCodeFromNationality(Nationality)
                                '.EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)

                                .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                If IsNumeric(Units) Then
                                    .PeriodUnits = Units
                                Else
                                    .PeriodUnits = 0
                                End If

                                .AnnualUnits = 0
                                .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods, "3")

                                .Bnk_Code = BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)

                                .BankAccount = BankAccountNo
                                .Bnk_CodeCo = Me.GLBLoadingFromExcel_CompanyBankCode 'GetFirstRecordOfDataset(dsBanks)
                                .BankAccountCo = Me.GLBLoadingFromExcel_CompanyIBAN

                                If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                    .StartDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = EmploymentDate.Split("/")
                                    EmploymentDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .StartDate = CDate(EmploymentDate)

                                End If
                                If TerminationDate <> "" Then
                                    Dim S As String
                                    Dim D As Date
                                    D = Cdate1(TerminationDate)
                                    S = Format(D, "yyyy/MM/dd")

                                    .TerminateDate = S
                                Else
                                    .TerminateDate = ""
                                End If

                                .OtherIncome1 = CDbl(0)
                                .OtherIncome2 = CDbl(0)
                                .OtherIncome3 = CDbl(0)
                                .PreviousEarnings = CDbl(0)
                                .Emp_PrevSIDeduct = CDbl(0)
                                .Emp_PrevSIContribute = CDbl(0)
                                .Emp_PrevITDeduct = CDbl(0)
                                .Emp_PrevPFDeduct = CDbl(0)

                                .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance, GLBLoadingFromExcel_SIRateCode)
                                .GESICode = GetFirstRecordOfDataset(dsGesi)

                                .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                .InterfaceTemCode = TemplateGroupCode
                                .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                .DrivingLicense = ""
                                .PensionNo = ""
                                .MyPayslipReport = Me.GLBLoadingFromExcel_PayslipReport
                                .IBAN = IBAN
                                .PreviousLifeIns = CDbl(0)
                                .PreviousDis = CDbl(0)
                                .PreviousST = CDbl(0)
                                .OtherIncome4 = CDbl(0)

                                .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                .FullPassName = ""
                                .Traveldocs = ""

                                .FirstEmployment = "0"
                                .IsSI = 0
                                .Password = Password
                                .Splitemployement = "0"
                                .BankBenName = BankBenName
                                .NewEmployee = "1"



                                .Emp_GLAnal1 = ""
                                .Emp_GLAnal2 = ""
                                .Emp_GLAnal3 = ""
                                .Emp_GLAnal4 = ""

                                .PensionType = "0"

                                .CreationDate = Now.Date
                                .CreatedBy = Global1.GLBUserId
                                .AmendDate = Now.Date
                                .AmendBy = Global1.GLBUserId
                                .Notes = Notes
                                .AnalGen1 = GenAnalysis1

                                If Not .Save() Then
                                    Throw Exx
                                End If

                                Dim SalVal As Double
                                Salary = Replace(Salary, "$", "")
                                Salary = Replace(Salary, "€", "")
                                Salary = Replace(Salary, """", "")
                                Salary = Trim(Salary)
                                SalVal = CDbl(Salary)


                                Dim EmpSal As New cPrTxEmployeeSalary
                                With EmpSal

                                    .Id = 0
                                    .Emp_Code = EmployeeCode
                                    .Date1 = Now.Date
                                    .SalaryValue = CDbl(SalVal)
                                    .Basic = CDbl(0)
                                    .EffPayDate = CDate(EmploymentDate)
                                    .Cola = CDbl(0)
                                    .EffArrearsDate = CDate(EmploymentDate)
                                    .Usr_Id = Global1.GLBUserId
                                    .myRate = CDbl(0)
                                    .IsCola = "N"
                                    .EmpSal_Dif = CDbl(0)

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With


                                Dim EmpAL As New cPrTxEmployeeLeave
                                With EmpAL

                                    .Id = 0
                                    .EmpCode = EmployeeCode
                                    .Status = "Approved"
                                    .Type = "1"
                                    .ReqDate = EmploymentDate
                                    .ProcDate = EmploymentDate
                                    .FromDate = EmploymentDate
                                    .ToDate = EmploymentDate
                                    .ProcBy = Global1.GLBUserId
                                    .Units = ALLeaveInUnits
                                    .Action = AN_IncreaseCODE

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With



                                '''
                                Dim k As Integer
                                Dim DsErn As DataSet
                                DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                If CheckDataSet(DsErn) Then
                                    For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                        Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                        Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                        EmpErn.EmpCode = .Code
                                        EmpErn.ErnCode = E1.ErnCodCode
                                        EmpErn.MyValue = "0.00"
                                        EmpErn.TemGrpCode = .TemGrp_Code
                                        If Not EmpErn.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Deductions
                                Dim DsDed As DataSet
                                DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                If CheckDataSet(DsDed) Then
                                    For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                        Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                        Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                        EmpDed.EmpCode = .Code
                                        EmpDed.DedCode = D.DedCodCode
                                        EmpDed.MyValue = "0.00"
                                        EmpDed.TemGrpCode = .TemGrp_Code
                                        If Not EmpDed.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Contributions
                                Dim DsCon As DataSet
                                DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                If CheckDataSet(DsCon) Then
                                    For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                        Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                        Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                        EmpCon.EmpCode = .Code
                                        EmpCon.ConCode = C.ConCodCode
                                        EmpCon.MyValue = "0.00"
                                        EmpCon.TemGrpCode = .TemGrp_Code
                                        If Not C.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If

                            End With



                        End If

                        '''''''''

                    End If

                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub ImportSalariesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportSalariesToolStripMenuItem.Click
        Dim F As New FrmLoadsalariesFromExcel
        SAL_Proceed = False
        F.Owner = Me
        F.ShowDialog()
        If SAL_Proceed Then
            Import_From_Excel_EmployeesSalaries_Template_1(GLBLoadingFromExcelSalaries_EffDate)
        End If





    End Sub
    Private Sub Import_From_Excel_EmployeesSalaries_Template_1(ByVal EffDate As Date)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass
        Try
            Dim ContinueWithLoading As Boolean = False
            Dim FileDir As String
            Dim Exx As New Exception
            Global1.Business.BeginTransaction()

            xlWorkBook = xlApp.Workbooks.Open(SAL_File)
            xlWorkSheet = xlWorkBook.Worksheets(1)

            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False




            Counter = SAL_FirstLine


            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCode As String
                Dim Salary As String
                Dim E1 As String
                Dim E2 As String

                '''''''''''''''''''''''''''''''''''''''''''''''

                Try

                    ContinueWithLoading = True
                    EmployeeCode = NothingToEmpty(xlWorkSheet.Cells(Counter, SAL_EmployeeColumnNo).value)
                    Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, SAL_SalaryColumnNumber).value)


                    If SAL_E1Code <> "" Then
                        E1 = NothingToEmpty(xlWorkSheet.Cells(Counter, SAL_E1Number).value)
                    End If
                    If SAL_E2Code <> "" Then
                        E2 = NothingToEmpty(xlWorkSheet.Cells(Counter, SAL_E2Number).value)
                    End If

                    If EmployeeCode = "" Then
                        ContinueWithLoading = False
                        StopInput = True
                    End If
                    Dim Emp As New cPrMsEmployees(EmployeeCode)
                    If Emp.Code <> "" Then
                        If ContinueWithLoading Then
                            Dim SalVal As Double
                            SalVal = RoundMe2(CDbl(Salary), 2)

                            Dim EmpSal As New cPrTxEmployeeSalary
                            With EmpSal

                                .Id = 0
                                .Emp_Code = EmployeeCode
                                .Date1 = Now.Date
                                .SalaryValue = CDbl(SalVal)
                                .Basic = CDbl(0)
                                .EffPayDate = CDate(EffDate)
                                .Cola = CDbl(0)
                                .EffArrearsDate = CDate(EffDate)
                                .Usr_Id = Global1.GLBUserId
                                .myRate = CDbl(0)
                                .IsCola = "N"
                                .EmpSal_Dif = CDbl(0)

                                If Not .Save() Then
                                    Throw Exx
                                End If
                            End With

                            If SAL_E1Code <> "" Then
                                Dim EmpErn As New cPrMsEmployeeEarnings(EmployeeCode, SAL_E1Code)
                                If EmpErn.Id <> 0 Then
                                    EmpErn.MyValue = E1
                                    If Not EmpErn.Save() Then
                                        Throw Exx
                                    End If
                                End If
                            End If

                            If SAL_E2Code <> "" Then
                                Dim EmpErn As New cPrMsEmployeeEarnings(EmployeeCode, SAL_E2Code)
                                If EmpErn.Id <> 0 Then
                                    EmpErn.MyValue = E2
                                    If Not EmpErn.Save() Then
                                        Throw Exx
                                    End If
                                End If
                            End If





                        End If
                    End If
                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                    StopInput = True
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                    Exit Sub
                End Try
                Counter = Counter + 1
            Loop

            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)

            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub






    Private Function FindDepartment1CodeFromDesc(ByVal DepartmentDesc As String) As String
        Dim Code As String = ""
        Code = Global1.Business.GetDepartment1CodeFromDesc(DepartmentDesc)
        Return Code
    End Function
    Private Function FindDepartment2CodeFromDesc(ByVal DepartmentDesc As String) As String
        Dim Code As String = ""
        Code = Global1.Business.GetDepartment2CodeFromDesc(DepartmentDesc)
        Return Code
    End Function
    Private Function FindDepartment3CodeFromDesc(ByVal DepartmentDesc As String) As String
        Dim Code As String = ""
        Code = Global1.Business.GetDepartment3CodeFromDesc(DepartmentDesc)
        Return Code
    End Function
    Private Function FindDepartment4CodeFromDesc(ByVal DepartmentDesc As String) As String
        Dim Code As String = ""
        Code = Global1.Business.GetDepartment4CodeFromDesc(DepartmentDesc)
        Return Code
    End Function
    Private Function FindDepartment5CodeFromDesc(ByVal DepartmentDesc As String) As String
        Dim Code As String = ""
        Code = Global1.Business.GetDepartment5CodeFromDesc(DepartmentDesc)
        Return Code
    End Function
    Private Function GetPositionCodeFromDesc(ByVal PositionDesc As String) As String
        Dim Code As String = ""
        Try
            Code = Global1.Business.GetPositionCodeFromDesc(PositionDesc)
            If Code = "" Then
                Code = Global1.Business.GetLastEmployeePositionCode
                Dim P As New cPrAnEmployeePositions(Code)
                If P.Code = "" Then
                    P.Code = Code
                    P.DescriptionL = PositionDesc
                    P.DescriptionS = PositionDesc
                    P.IsActive = True
                    P.Units = ""
                    P.Save()
                End If
            End If
        Catch ex As Exception

        End Try
        Return Code
    End Function

    Private Function FindSICatCodeFromNationality(ByVal Desc As String) As String
        Dim Code As String
        If UCase(Desc) = "CYPRIOT" Then
            Code = "E"
        Else
            Code = "K"
        End If
        Return Code
    End Function


    Private Sub ImportFromExcel4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportFromExcel4ToolStripMenuItem.Click
        Dim F As New FrmLoadEmployeesFromExcel
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            If Not GLBLoadingFromExcel_loadaddress Then
                Import_From_Excel_Employees_Template_4(GLBLoadingFromExcel_TemGroup)
            Else
                Import_From_Excel_Employees_Address(GLBLoadingFromExcel_TemGroup)
            End If
        End If

    End Sub
    Private Sub Import_From_Excel_Employees_Template_4(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 3
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCodeNumeric As String
                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim EmployeeCode As String
                Dim Gender As String
                Dim JobTitle As String
                Dim BirthDate As String
                Dim Status As String
                Dim EmploymentDate As String
                Dim AnnualLeave As String
                Dim MaritalStatus As String
                Dim SocialSecurityNo As String
                Dim IdentityCardNo As String
                Dim PassportNo As String
                Dim AlienNumber As String
                Dim IncomeTaxNo As String
                Dim WorkEMail As String
                Dim DepartmentCode As String
                Dim Department1 As String
                Dim Department2 As String
                Dim Department3 As String
                Dim Department4 As String

                'Dim PayrollNo As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String
                Dim TerminationDate As String

                Dim FullAddress As String
                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Email As String
                Dim Email2 As String
                Dim Email22 As String
                Dim JobDescriptionCode As String
                Dim EmployeeJobDescription As String
                Dim PayrollCompanyNo As String
                Dim TemplateGroupCode As String
                Dim Notes As String
                Dim Password As String
                Dim Nationality As String
                Dim BankBenName As String
                '----------------------------------------------

                Dim DepFull1 As String
                Dim DepFull2 As String
                Dim PosFull As String
                Dim SocCatFull As String
                Dim BankCodeFull As String


                Dim DepartmentCode1 As String = ""
                Dim DepartmentCode2 As String = ""
                Dim DepartmentCode3 As String = ""
                Dim DepartmentCode4 As String = ""
                Dim DepartmentCode5 As String = ""

                Dim Position As String
                Dim PositionCode1 As String

                Dim SiCatCode As String

                Dim BankCode As String

                Dim Salary As String

                Dim BanAccount As String
                Dim HireReason As String = ""

                '----------------------------------------------
                'FindDefaults()
                Dim dsTemplateGroup As DataSet
                Dim dsAnal1 As DataSet
                Dim dsAnal2 As DataSet
                Dim dsAnal3 As DataSet
                Dim dsAnal4 As DataSet
                Dim dsAnal5 As DataSet
                Dim dsUnions As DataSet
                Dim dsCountries As DataSet
                Dim dsEmpPosition As DataSet
                Dim dsSIcategory As DataSet
                Dim dsEmpCommunity As DataSet
                Dim dsPayUnits As DataSet
                Dim dsCurCode As DataSet
                Dim dsPayMethods As DataSet
                Dim dsBanks As DataSet
                Dim dsTaxCardtype As DataSet
                Dim dsProFund As DataSet
                Dim dsMedicalFund As DataSet
                Dim dsSocialInsurance As DataSet
                Dim dsGesi As DataSet

                Dim dsIndustrial As DataSet
                Dim dsUnemployment As DataSet
                Dim dsSocialCohesion As DataSet
                Dim dsSectorPay As DataSet
                Dim dsCommissionRates As DataSet
                Dim dsPerformanceBonus As DataSet
                Dim dsdutyHours As DataSet
                Dim dsOverLay As DataSet
                Dim dsFlightHours As DataSet
                Dim ContinueWithLoading As Boolean
                Dim CompanySocialInsuranceNo As String

                Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
                Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
                Dim ALLeaveInUnits As Double

                Dim Units As String
                Dim GenAnalysis1 As String

                Dim EmpCodeFromExcel As String

                CompanySocialInsuranceNo = Comp.SIRegNo




                dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
                dsGesi = Global1.Business.GetAllPrSsGesi

                EmployeeCodeNumeric = Global1.Business.GetLastEmployeeCode(Me.GLBLoadingFromExcel_TemGroup)

                '''''''''''''''''''''''''''''''''''''''''''''''

                Try

                    ContinueWithLoading = True



                    'If EmployeeCodeNumeric = "" Then
                    'EmployeeCodeNumeric = 0
                    'End If
                    'EmployeeCodeNumeric = EmployeeCodeNumeric + 1

                    EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                    If EmpCodeFromExcel <> "" Then
                        EmployeeCodeNumeric = EmpCodeFromExcel
                    End If

                    EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
                    LastName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                    FirstName = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)


                    If Trim(FirstName) = "" Then
                        Exit Do
                    End If
                    ' Dim arn() As String
                    ' arn = FirstName.Split(" ")
                    ' FirstName = arn(1)
                    ' LastName = arn(0)

                    MiddleName = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                    FirstName = FirstName & " " & MiddleName

                    Gender = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                    BirthDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


                    EmploymentDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
                    AnnualLeave = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)
                    ALLeaveInUnits = 0

                    If AnnualLeave <> "" Then
                        If IsNumeric(AnnualLeave) Then
                            ALLeaveInUnits = RoundMe2(AnnualLeave * TGroup.DayUnits, 2)
                        End If
                    End If


                    AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
                    AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
                    If AddressLine1 Is Nothing Then
                        AddressLine1 = ""
                    End If
                    If AddressLine2 Is Nothing Then
                        AddressLine2 = ""
                    End If
                    AddressLine1 = AddressLine1.Replace("!", "")
                    AddressLine1 = AddressLine1.Replace("&", "")
                    AddressLine1 = AddressLine1.Replace("$", "")
                    AddressLine1 = AddressLine1.Replace("@", "")
                    AddressLine1 = AddressLine1.Replace("/", "")
                    AddressLine1 = AddressLine1.Replace(",", "")
                    AddressLine1 = AddressLine1.Replace("-", "")
                    AddressLine1 = AddressLine1.Replace(".", "")
                    AddressLine1 = AddressLine1.Replace("'", "")

                    AddressLine2 = AddressLine2.Replace("!", "")
                    AddressLine2 = AddressLine2.Replace("&", "")
                    AddressLine2 = AddressLine2.Replace("$", "")
                    AddressLine2 = AddressLine2.Replace("@", "")
                    AddressLine2 = AddressLine2.Replace(",", "")
                    AddressLine2 = AddressLine2.Replace("-", "")
                    AddressLine2 = AddressLine2.Replace(".", "")
                    AddressLine2 = AddressLine2.Replace("'", "")




                    City = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
                    PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

                    POBox = ""
                    POBoxPostCode = ""



                    PhoneNo = ""

                    MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
                    If MobilePhone Is Nothing Then
                        MobilePhone = ""
                    End If

                    Email = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
                    If Email Is Nothing Then
                        Email = ""
                    End If
                    Email2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
                    If Email2 Is Nothing Then
                        Email2 = ""
                    End If
                    If Email2 <> "" Then
                        Email = Email2
                    End If

                    Email22 = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)

                    Password = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
                    If Password Is Nothing Then
                        Password = ""
                    End If

                    JobTitle = ""

                    Status = "ACTIVE"

                    MaritalStatus = ""

                    SocialSecurityNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
                    IdentityCardNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
                    PassportNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
                    IncomeTaxNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
                    If IncomeTaxNo = IdentityCardNo Then
                        IncomeTaxNo = ""
                    End If
                    AlienNumber = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)

                    Nationality = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)

                    Department1 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 38).value))
                    Department2 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value))
                    'Desk
                    Department3 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 36).value))
                    'Brand
                    Department4 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 37).value))




                    Dim Dep() As String
                    Dep = Department2.Split("/")
                    If Dep.Length = 2 Then
                        Department2 = Trim(Dep(0))
                        Department3 = Trim(Dep(1))
                    End If

                    DepartmentCode1 = FindDepartment1CodeFromDesc(Department1)
                    DepartmentCode2 = FindDepartment2CodeFromDesc(Department2)
                    DepartmentCode3 = FindDepartment3CodeFromDesc(Department3)
                    DepartmentCode4 = FindDepartment4CodeFromDesc(Department4)
                    If DepartmentCode1 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department 1" & Department1 & " Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 1:   " & Department1 & Chr(10)
                    End If

                    DepartmentCode2 = FindDepartment2CodeFromDesc(Department2)
                    If DepartmentCode2 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department 2" & Department2 & " Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 2:   " & Department2 & Chr(10)
                    End If

                    DepartmentCode3 = FindDepartment3CodeFromDesc(Department3)
                    If DepartmentCode3 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department 3" & Department3 & " Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 3:   " & Department3 & Chr(10)
                    End If

                    DepartmentCode4 = FindDepartment4CodeFromDesc(Department4)
                    If DepartmentCode4 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department 4" & Department4 & " Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 4:   " & Department4 & Chr(10)
                    End If

                    Position = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    PositionCode1 = GetPositionCodeFromDesc(Position)
                    If PositionCode1 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Position " & Position & " Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Position:   " & Position & Chr(10)

                    End If

                    SiCatCode = Nationality 'FindSICatCodeFromNationality(Nationality)




                    BankAccountNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 39).value)
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
                    SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)


                    BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                    If BankCode = "" Then
                        BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                    End If



                    TerminationDate = ""

                    Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
                    BankBenName = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)

                    Units = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)
                    GenAnalysis1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 35).value)


                    HireReason = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 40).value))
                    If HireReason <> "N" Or HireReason <> "T" Then
                        HireReason = "N"
                    End If


                    JobDescriptionCode = ""
                    EmployeeJobDescription = ""

                    PayrollCompanyNo = ""
                    Notes = ""


                    TemplateGroupCode = TemplateGroupForLoading

                    '

                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False
                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If TemplateGroupCode = "" Or EmployeeCode = "" Then
                        If NewEmployee And Status = "Terminated" Then
                            ContinueWithLoading = False
                        Else
                            MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                            ContinueWithLoading = False
                            Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                        End If
                    End If


                    If ContinueWithLoading Then

                        If NewEmployee Then


                            With Emp
                                .Code = EmployeeCode
                                If Status = "INNACTIVE" Then
                                    .Status = "I"
                                Else
                                    .Status = "A"
                                End If
                                .PayTyp_Code = "M01"
                                .TemGrp_Code = TemplateGroupCode
                                .EmpSta_Code = "A"

                                .LastName = LastName
                                .FirstName = FirstName
                                .FullName = LastName & " " & FirstName
                                If Gender = "Female" Then
                                    .Sex = "F"
                                    .Title = "MRS"
                                Else
                                    .Sex = "M"
                                    .Title = "MR"
                                End If
                                If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                    .BirthDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = BirthDate.Split("/")
                                    BirthDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .BirthDate = CDate(BirthDate)
                                End If
                                If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                    .MarSta_Code = "S"
                                ElseIf MaritalStatus = "Married" Then
                                    .MarSta_Code = "M"
                                ElseIf MaritalStatus = "Divorce" Then
                                    .MarSta_Code = "D"
                                ElseIf MaritalStatus = "Widow" Then
                                    .MarSta_Code = "W"
                                End If

                                .Address1 = AddressLine1
                                .Address2 = City
                                .Address3 = AddressLine2

                                .PostCode = PostCode
                                .Telephone1 = PhoneNo
                                .Telephone2 = MobilePhone
                                .Email = Email
                                .Email2 = Email22
                                .SocialInsNumber = SocialSecurityNo

                                .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                                .IdentificationCard = IdentityCardNo
                                .TaxID = IncomeTaxNo
                                .PassportNumber = PassportNo
                                .AlienNumber = AlienNumber

                                If AlienNumber <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "7")
                                End If
                                If IncomeTaxNo <> "" And IncomeTaxNo <> "?" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "1")
                                End If
                                If AlienNumber = "" And (IncomeTaxNo = "" Or IncomeTaxNo = "?") Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "3")
                                End If


                                If DepartmentCode1 = "" Then
                                    .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
                                Else
                                    .EmpAn1_Code = DepartmentCode1
                                End If
                                If DepartmentCode2 = "" Then
                                    .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2)
                                Else
                                    .EmpAn2_Code = DepartmentCode2
                                End If
                                If DepartmentCode3 = "" Then
                                    .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                Else
                                    .EmpAn3_Code = DepartmentCode3
                                End If
                                If DepartmentCode4 = "" Then
                                    .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                Else
                                    .EmpAn4_Code = DepartmentCode4
                                End If
                                If DepartmentCode5 = "" Then
                                    .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                Else
                                    .EmpAn5_Code = DepartmentCode5
                                End If


                                .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                '.EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)

                                .EmpPos_Code = PositionCode1


                                .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)

                                .EmpCmm_Code = FindSICatCodeFromNationality(Nationality)
                                '.EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)

                                .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                If IsNumeric(Units) Then
                                    .PeriodUnits = Units
                                Else
                                    .PeriodUnits = 0
                                End If

                                .AnnualUnits = 0
                                .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods, "3")

                                .Bnk_Code = BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)

                                .BankAccount = BankAccountNo
                                .Bnk_CodeCo = Me.GLBLoadingFromExcel_CompanyBankCode 'GetFirstRecordOfDataset(dsBanks)
                                .BankAccountCo = Me.GLBLoadingFromExcel_CompanyIBAN

                                If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                    .StartDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = EmploymentDate.Split("/")
                                    EmploymentDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .StartDate = CDate(EmploymentDate)

                                End If
                                If TerminationDate <> "" Then
                                    Dim S As String
                                    Dim D As Date
                                    D = Cdate1(TerminationDate)
                                    S = Format(D, "yyyy/MM/dd")

                                    .TerminateDate = S
                                Else
                                    .TerminateDate = ""
                                End If

                                .OtherIncome1 = CDbl(0)
                                .OtherIncome2 = CDbl(0)
                                .OtherIncome3 = CDbl(0)
                                .PreviousEarnings = CDbl(0)
                                .Emp_PrevSIDeduct = CDbl(0)
                                .Emp_PrevSIContribute = CDbl(0)
                                .Emp_PrevITDeduct = CDbl(0)
                                .Emp_PrevPFDeduct = CDbl(0)

                                .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance, GLBLoadingFromExcel_SIRateCode)
                                .GESICode = GetFirstRecordOfDataset(dsGesi)

                                .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                .InterfaceTemCode = TemplateGroupCode
                                .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                .DrivingLicense = ""
                                .PensionNo = ""
                                .MyPayslipReport = Me.GLBLoadingFromExcel_PayslipReport
                                .IBAN = IBAN

                                .PreviousLifeIns = CDbl(0)
                                .PreviousDis = CDbl(0)
                                .PreviousST = CDbl(0)
                                .OtherIncome4 = CDbl(0)

                                .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                .FullPassName = ""
                                .Traveldocs = ""

                                .FirstEmployment = "0"
                                .IsSI = 0
                                .Password = Password
                                .Splitemployement = "0"
                                .BankBenName = BankBenName
                                .NewEmployee = "1"



                                .Emp_GLAnal1 = ""
                                .Emp_GLAnal2 = ""
                                .Emp_GLAnal3 = ""
                                .Emp_GLAnal4 = ""

                                .PensionType = "0"

                                .CreationDate = Now.Date
                                .CreatedBy = Global1.GLBUserId
                                .AmendDate = Now.Date
                                .AmendBy = Global1.GLBUserId
                                .Notes = Notes
                                .AnalGen1 = GenAnalysis1
                                .HireReason = HireReason
                                .TermReason = ""

                                If Not .Save(False) Then
                                    Throw Exx
                                End If

                                Dim SalVal As Double
                                Salary = Replace(Salary, "$", "")
                                Salary = Replace(Salary, "€", "")
                                Salary = Replace(Salary, """", "")
                                Salary = Trim(Salary)
                                SalVal = CDbl(Salary)


                                Dim EmpSal As New cPrTxEmployeeSalary
                                With EmpSal

                                    .Id = 0
                                    .Emp_Code = EmployeeCode
                                    .Date1 = Now.Date
                                    .SalaryValue = CDbl(SalVal)
                                    .Basic = CDbl(0)
                                    .EffPayDate = CDate(EmploymentDate)
                                    .Cola = CDbl(0)
                                    .EffArrearsDate = CDate(EmploymentDate)
                                    .Usr_Id = Global1.GLBUserId
                                    .myRate = CDbl(0)
                                    .IsCola = "N"
                                    .EmpSal_Dif = CDbl(0)

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With


                                Dim EmpAL As New cPrTxEmployeeLeave
                                With EmpAL

                                    .Id = 0
                                    .EmpCode = EmployeeCode
                                    .Status = "Approved"
                                    .Type = "1"
                                    .ReqDate = EmploymentDate
                                    .ProcDate = EmploymentDate
                                    .FromDate = EmploymentDate
                                    .ToDate = EmploymentDate
                                    .ProcBy = Global1.GLBUserId
                                    .Units = ALLeaveInUnits
                                    .Action = AN_IncreaseCODE

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With



                                '''
                                Dim k As Integer
                                Dim DsErn As DataSet
                                DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                If CheckDataSet(DsErn) Then
                                    For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                        Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                        Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                        EmpErn.EmpCode = .Code
                                        EmpErn.ErnCode = E1.ErnCodCode
                                        EmpErn.MyValue = "0.00"
                                        EmpErn.TemGrpCode = .TemGrp_Code
                                        If Not EmpErn.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Deductions
                                Dim DsDed As DataSet
                                DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                If CheckDataSet(DsDed) Then
                                    For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                        Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                        Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                        EmpDed.EmpCode = .Code
                                        EmpDed.DedCode = D.DedCodCode
                                        EmpDed.MyValue = "0.00"
                                        EmpDed.TemGrpCode = .TemGrp_Code
                                        If Not EmpDed.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Contributions
                                Dim DsCon As DataSet
                                DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                If CheckDataSet(DsCon) Then
                                    For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                        Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                        Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                        EmpCon.EmpCode = .Code
                                        EmpCon.ConCode = C.ConCodCode
                                        EmpCon.MyValue = "0.00"
                                        EmpCon.TemGrpCode = .TemGrp_Code
                                        If Not C.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If

                            End With



                        End If

                        '''''''''

                    End If

                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Sub Import_From_Excel_Employees_Address(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass




        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 3
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCodeNumeric As String
                Dim EmployeeCode As String

                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Birthdate As String





                Dim EmpCodeFromExcel As String


                Try




                    EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)
                    If EmpCodeFromExcel <> "" Then
                        EmployeeCodeNumeric = EmpCodeFromExcel
                    Else
                        Exit Do
                    End If

                    EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
                    Dim Emp As New cPrMsEmployees(EmployeeCode)
                    If Emp.Code <> "" Then


                        AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)
                        AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                        If AddressLine1 Is Nothing Then
                            AddressLine1 = ""
                        End If
                        If AddressLine2 Is Nothing Then
                            AddressLine2 = ""
                        End If

                        'AddressLine1 = AddressLine1 & AddressLine2
                        City = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                        'PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

                        POBox = ""
                        PostCode = ""



                        PhoneNo = ""

                        MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                        If MobilePhone Is Nothing Then
                            MobilePhone = ""
                        End If
                        If MobilePhone <> "" Then
                            MobilePhone = Trim(MobilePhone)
                            If MobilePhone.Length >= 8 Then
                                MobilePhone = MobilePhone.Substring(MobilePhone.Length - 8, 8)
                            End If
                        End If

                        Birthdate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)







                        With Emp


                            .Address1 = AddressLine1
                            .Address2 = City
                            .Address3 = AddressLine2

                            .PostCode = PostCode
                            .Telephone1 = PhoneNo
                            .Telephone2 = MobilePhone
                            If Birthdate = "" Or Birthdate = "12:00:00 AM" Then
                                .BirthDate = Now.Date
                            Else
                                Dim Ar1() As String
                                Ar1 = Birthdate.Split("/")
                                Birthdate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                .BirthDate = CDate(Birthdate)
                            End If

                            If Not .Save() Then
                                Throw Exx
                            End If


                        End With
                    End If
                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub





    Private Sub PrintChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintChequeToolStripMenuItem.Click
        Dim F As New FrmPrintCheques
        F.MdiParent = Me
        F.Show()
    End Sub


    Private Sub UpdateDOB()
        Dim Line As String
        Try

            'on form load instantiate the connection object
            Dim param_file As IO.StreamReader
            Dim FileDir As String

            Dim Exx As New Exception
            Global1.FileName = FileName
            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()
            Dim sr2 As IO.StreamReader = New IO.StreamReader("Data\DOB.txt", System.Text.Encoding.GetEncoding(1253))



            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Do While sr2.Peek <> -1
                Me.Refresh()
                'Line = param_file.Read
                Line = sr2.ReadLine
                Ar = Line.Split("	")

                Dim EmpCode As String
                Dim DOB As String


                If Ar.Length = 2 Then
                    EmpCode = Ar(0)
                    DOB = Ar(1)
                    If EmpCode <> "" Then
                        EmpCode = EmpCode.PadLeft(4, "0")
                        Dim emp As New cPrMsEmployees(EmpCode)

                        If emp.Code <> "" And Trim(DOB) <> "" Then
                            Dim Ar1() As String
                            Dim BirthDate As String = DOB
                            Ar1 = BirthDate.Split("/")
                            BirthDate = Ar1(2) & "/" & Ar1(1) & "/" & Ar1(0)
                            emp.BirthDate = CDate(BirthDate)
                            If Not emp.Save Then
                                MsgBox("Employee " & emp.Code & " error")
                                Throw Exx
                            End If
                        End If
                    End If
                End If

            Loop
            MsgBox("Finish")
        Catch ex As Exception
            MsgBox(Line)
            Utils.ShowException(ex)
        End Try



    End Sub


    Private Sub DOBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOBToolStripMenuItem.Click
        Me.UpdateDOB()
    End Sub

    Private Sub EmailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailsToolStripMenuItem.Click
        UpdateEmails()
    End Sub
    Private Sub UpdateEmails()
        Dim Line As String
        Try

            'on form load instantiate the connection object
            Dim param_file As IO.StreamReader
            Dim FileDir As String

            Dim Exx As New Exception
            Global1.FileName = FileName
            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()
            Dim sr2 As IO.StreamReader = New IO.StreamReader("Data\Emails.txt", System.Text.Encoding.GetEncoding(1253))



            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Do While sr2.Peek <> -1
                Me.Refresh()
                'Line = param_file.Read
                Line = sr2.ReadLine
                Ar = Line.Split("	")

                Dim EmpCode As String
                Dim email As String


                If Ar.Length = 2 Then
                    EmpCode = Ar(0)
                    email = Ar(1)
                    If EmpCode <> "" Then
                        '   EmpCode = EmpCode.PadLeft(4, "0")
                        Dim emp As New cPrMsEmployees(EmpCode)

                        If emp.Code <> "" And Trim(email) <> "" Then
                            emp.Email = email
                            If Not emp.Save Then
                                MsgBox("Employee " & emp.Code & " error")
                                Throw Exx
                            End If
                        End If
                    End If
                End If

            Loop
            MsgBox("Finish")
            Global1.Business.CommitTransaction()
        Catch ex As Exception
            MsgBox(Line)
            Utils.ShowException(ex)
        End Try



    End Sub



    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Timer1.Interval = 1000
    '    Timer1.Enabled = True
    '    MsgBox("x")
    '    Timer1.Start()
    '    MsgBox("y")
    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    If Now.Hour = 14 Then
    '        'MsgBox(2)
    '        If Now.Minute >= 55 And Now.Minute <= 56 Then
    '            MsgBox(3)
    '        End If
    '    End If
    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    Timer1.Enabled = False
    'End Sub



    Private Sub ImportLeaveFromBetaBiz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportLeaveFromBetaBiz.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass


        BetaBizFile = ""
        Dim F As New FrmImportBetaBiz1
        F.Owner = Me
        F.ShowDialog()
        If BetaBizFile = "" Then
            Exit Sub
        End If


        Dim EmpName As String
        Dim EmpCode As String
        Dim LeaveDate As String
        Dim LeaveType As String
        Dim LeaveDays As String
        Dim Lt As String
        Dim Units As String
        Dim MyDate As String

        Try

            Dim FileDir As String

            Dim Exx As New Exception


            Global1.Business.BeginTransaction()
            xlWorkBook = xlApp.Workbooks.Open(BetaBizFile)
            xlWorkSheet = xlWorkBook.Worksheets(1)

            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 2

            Cursor.Current = Cursors.WaitCursor


            Dim ErrorM As String = ""
            Do While StopInput = False
                Try

                    Application.DoEvents()
                    Me.Refresh()
                    'Line = param_file.Read
                    EmpName = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)
                    If EmpName = "" Then
                        StopInput = True
                        Exit Do
                    End If

                    EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)
                    LeaveDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                    LeaveType = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)
                    LeaveDays = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)


                    Dim Emp As New cPrMsEmployees(EmpCode)
                    If Emp.Code = "" Then
                        MsgBox("Invalid Employee Code in Line " & Counter)
                        Throw Exx
                    End If
                    Dim Temp As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    If Temp.DayUnits = 0 Then
                        Units = RoundMe2(LeaveDays * 8, 2)
                    End If
                    Units = RoundMe2(LeaveDays * Temp.DayUnits, 2)

                    If LeaveType = "Vacation" Then
                        Lt = "1"
                    ElseIf LeaveType = "Sick" Then
                        Lt = "3"
                    Else
                        MsgBox("Invalid Leave Type in Line " & Counter)
                        Throw Exx
                    End If

                    MyDate = CDate(LeaveDate)



                    Dim EmpLeave As New cPrTxEmployeeLeave
                    With EmpLeave
                        .Id = 0
                        .EmpCode = EmpCode
                        .Status = "Approved"
                        .Type = Lt
                        .ReqDate = MyDate
                        .ProcDate = MyDate
                        .FromDate = MyDate
                        .ToDate = MyDate
                        .ProcBy = Global1.GLBUserId
                        .Units = Units
                        .Action = "DE"
                        If Not .Save() Then
                            Throw Exx

                        End If
                    End With
                    Counter = Counter + 1
                Catch ex As Exception
                    Global1.Business.Rollback()
                    StopInput = True
                    Cursor.Current = Cursors.Default
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                    Exit Sub
                End Try



            Loop
            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 

        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmpCode, MsgBoxStyle.Critical)

        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub


    Private Sub ToolStripLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUrlSI.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "SI")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','SI' Social Insurance URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUrlTaxis.Click

        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "TaxisNet")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','TaxisNet' Taxis Net URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub


    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUrlJcc.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "JCC")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','JCC' JCC payment URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub TSUrlTaxPortal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUrlTaxPortal.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "TaxPortal")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','TaxPortal' Tax Portal URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub ShowWeb(ByVal Str As String)
        System.Diagnostics.Process.Start(Str)
    End Sub

    Private Sub ChangeEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeEmployeeToolStripMenuItem.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass


        ChangeBankAndIBANFile = ""
        Dim F As New FrmChangeEmployeeBankAndIBAN
        F.Owner = Me
        F.ShowDialog()
        If ChangeBankAndIBANFile = "" Then
            Exit Sub
        End If



        Dim EmpCode As String
        Dim BankCode As String
        Dim IBAN As String
        Dim BenName As String


        Try

            Dim FileDir As String

            Dim Exx As New Exception


            Global1.Business.BeginTransaction()
            xlWorkBook = xlApp.Workbooks.Open(Me.ChangeBankAndIBANFile)
            xlWorkSheet = xlWorkBook.Worksheets(1)

            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = CBI_FirstLine

            Cursor.Current = Cursors.WaitCursor


            Dim ErrorM As String = ""
            Do While StopInput = False
                Try

                    Application.DoEvents()
                    Me.Refresh()
                    'Line = param_file.Read

                    EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, CBI_Code_Col).value)
                    BenName = NothingToEmpty(xlWorkSheet.Cells(Counter, CBI_BenName_Col).value)
                    BankCode = NothingToEmpty(xlWorkSheet.Cells(Counter, CBI_BankCode_Col).value)
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, CBI_IBAN_Col).value)
                    If EmpCode = "" Then
                        StopInput = True
                        Exit Do
                    End If

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    If Emp.Code = "" Then
                        MsgBox("Employee with Code " & EmpCode & " Does not exist, line " & Counter, MsgBoxStyle.Critical)
                        StopInput = True
                        Exit Do
                    End If
                    Dim Bank As New cPrAnBanks(BankCode)
                    If Bank.Code = "" Then
                        MsgBox("Bank with Code " & BankCode & " Does not exist, line " & Counter, MsgBoxStyle.Critical)
                        StopInput = True
                        Exit Do
                    End If

                    Emp.IBAN = IBAN
                    Emp.Bnk_Code = BankCode
                    Emp.BankBenName = BenName
                    If Not Emp.Save() Then
                        Throw Exx
                    End If

                    Counter = Counter + 1
                Catch ex As Exception
                    Global1.Business.Rollback()
                    StopInput = True
                    Cursor.Current = Cursors.Default
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                    Exit Sub
                End Try



            Loop
            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 

        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmpCode, MsgBoxStyle.Critical)

        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub ImportLeaversDateAndEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportLeaversDateAndEmailToolStripMenuItem.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass


        LeaversDateEmailFile = ""
        Dim F As New FrmImportLeaversDateAndEmail
        F.Owner = Me
        F.ShowDialog()
        If LeaversDateEmailFile = "" Then
            Exit Sub
        End If



        Dim EmpCode As String
        Dim LeaveDate As String
        Dim Email As String
        Dim TermReason As String



        Try

            Dim FileDir As String

            Dim Exx As New Exception


            Global1.Business.BeginTransaction()
            xlWorkBook = xlApp.Workbooks.Open(Me.LeaversDateEmailFile)
            xlWorkSheet = xlWorkBook.Worksheets(1)

            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = dl_FirstLine

            Cursor.Current = Cursors.WaitCursor


            Dim ErrorM As String = ""
            Do While StopInput = False
                Try

                    Application.DoEvents()
                    Me.Refresh()
                    'Line = param_file.Read

                    EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, dl_Code_Col).value)
                    Email = NothingToEmpty(xlWorkSheet.Cells(Counter, dl_email_Col).value)
                    LeaveDate = NothingToEmpty(xlWorkSheet.Cells(Counter, dl_leavedate_Col).value)
                    TermReason = NothingToEmpty(xlWorkSheet.Cells(Counter, dl_TermReason_Col).value)
                    If TermReason = "" Or TermReason = "L" Or TermReason = "R" Or TermReason = "T" Then

                    Else

                        TermReason = ""
                    End If


                    If EmpCode = "" Then
                        StopInput = True
                        Exit Do
                    End If

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    If Emp.Code = "" Then
                        MsgBox("Employee with Code " & EmpCode & " Does not exist, line " & Counter, MsgBoxStyle.Critical)
                        StopInput = True
                        Exit Do
                    End If
                    Dim Dat() As String
                    Dat = LeaveDate.Split("/")
                    Dim sTermDate As String = ""
                    sTermDate = Dat(2) & "/" & Dat(0) & "/" & Dat(1)

                    Emp.TerminateDate = sTermDate
                    Emp.Email = Email
                    Emp.TermReason = TermReason

                    If Not Emp.Save() Then
                        Throw Exx
                    End If

                    Counter = Counter + 1
                Catch ex As Exception
                    Global1.Business.Rollback()
                    StopInput = True
                    Cursor.Current = Cursors.Default
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                    Exit Sub
                End Try



            Loop
            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 

        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmpCode, MsgBoxStyle.Critical)

        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub




    Private Sub AdminImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminImportToolStripMenuItem.Click
        Dim F As New FrmLoadEmployeesFromExcel
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            Import_From_Excel_Employees_Admin(GLBLoadingFromExcel_TemGroup)
        End If

    End Sub
    Private Sub Import_From_Excel_Employees_Admin(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp


        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 3
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmployeeCodeNumeric As String
                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim EmployeeCode As String
                Dim Gender As String
                Dim JobTitle As String
                Dim BirthDate As String
                Dim Status As String
                Dim EmploymentDate As String
                Dim AnnualLeave As String
                Dim MaritalStatus As String
                Dim SocialSecurityNo As String
                Dim IdentityCardNo As String
                Dim PassportNo As String
                Dim AlienNumber As String
                Dim IncomeTaxNo As String
                Dim WorkEMail As String
                Dim DepartmentCode As String
                Dim Department As String
                'Dim PayrollNo As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String
                Dim TerminationDate As String

                Dim FullAddress As String
                Dim AddressLine1 As String
                Dim AddressLine2 As String
                Dim AddressLine3 As String
                Dim PostCode As String
                Dim POBox As String
                Dim POBoxPostCode As String
                Dim City As String
                Dim PhoneNo As String
                Dim MobilePhone As String
                Dim Email As String
                Dim Email2 As String
                Dim JobDescriptionCode As String
                Dim EmployeeJobDescription As String
                Dim PayrollCompanyNo As String
                Dim TemplateGroupCode As String
                Dim Notes As String
                Dim Password As String
                Dim Nationality As String
                Dim BankBenName As String
                '----------------------------------------------

                Dim DepFull1 As String
                Dim DepFull2 As String
                Dim PosFull As String
                Dim SocCatFull As String
                Dim BankCodeFull As String


                Dim DepartmentCode1 As String
                Dim DepartmentCode2 As String
                Dim Position As String
                Dim PositionCode1 As String
                Dim SiCatCode As String
                Dim BankCode As String

                Dim Salary As String


                '----------------------------------------------
                'FindDefaults()
                Dim dsTemplateGroup As DataSet
                Dim dsAnal1 As DataSet
                Dim dsAnal2 As DataSet
                Dim dsAnal3 As DataSet
                Dim dsAnal4 As DataSet
                Dim dsAnal5 As DataSet
                Dim dsUnions As DataSet
                Dim dsCountries As DataSet
                Dim dsEmpPosition As DataSet
                Dim dsSIcategory As DataSet
                Dim dsEmpCommunity As DataSet
                Dim dsPayUnits As DataSet
                Dim dsCurCode As DataSet
                Dim dsPayMethods As DataSet
                Dim dsBanks As DataSet
                Dim dsTaxCardtype As DataSet
                Dim dsProFund As DataSet
                Dim dsMedicalFund As DataSet
                Dim dsSocialInsurance As DataSet
                Dim dsGesi As DataSet

                Dim dsIndustrial As DataSet
                Dim dsUnemployment As DataSet
                Dim dsSocialCohesion As DataSet
                Dim dsSectorPay As DataSet
                Dim dsCommissionRates As DataSet
                Dim dsPerformanceBonus As DataSet
                Dim dsdutyHours As DataSet
                Dim dsOverLay As DataSet
                Dim dsFlightHours As DataSet
                Dim ContinueWithLoading As Boolean
                Dim CompanySocialInsuranceNo As String

                Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
                Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
                Dim ALLeaveInUnits As Double

                Dim Units As String
                Dim GenAnalysis1 As String

                Dim EmpCodeFromExcel As String

                CompanySocialInsuranceNo = Comp.SIRegNo




                dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
                dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
                dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
                dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
                dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
                dsUnions = Global1.Business.AG_GetAllPrAnUnions()
                dsCountries = Global1.Business.AG_GetAllAdAnCountries()
                dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
                dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
                dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
                dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
                dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
                dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
                dsBanks = Global1.Business.AG_GetAllPrAnBanks()
                dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
                dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
                dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
                dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
                dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
                dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
                dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
                dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
                dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
                dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
                dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
                dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
                dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
                dsGesi = Global1.Business.GetAllPrSsGesi

                EmployeeCodeNumeric = Global1.Business.GetLastEmployeeCode(Me.GLBLoadingFromExcel_TemGroup)


                '''''''''''''''''''''''''''''''''''''''''''''''

                Try

                    ContinueWithLoading = True



                    If EmployeeCodeNumeric <> "" Then
                        EmployeeCodeNumeric = EmployeeCodeNumeric + 1
                    End If

                    EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                    If EmpCodeFromExcel <> "" Then
                        EmployeeCodeNumeric = EmpCodeFromExcel
                    End If

                    EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
                    LastName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                    FirstName = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)

                    If FirstName = "" Then
                        Exit Do
                    End If
                    'Dim arr() As String
                    'arr = FirstName.Split(" ")

                    'LastName = arr(1)
                    'FirstName = arr(0)


                    MiddleName = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                    FirstName = FirstName & " " & MiddleName

                    Gender = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                    BirthDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


                    EmploymentDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
                    AnnualLeave = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)
                    ALLeaveInUnits = 0

                    If AnnualLeave <> "" Then
                        If IsNumeric(AnnualLeave) Then
                            ALLeaveInUnits = RoundMe2(AnnualLeave * TGroup.DayUnits, 2)
                        End If
                    End If


                    AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
                    AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
                    If AddressLine1 Is Nothing Then
                        AddressLine1 = ""
                    End If
                    If AddressLine2 Is Nothing Then
                        AddressLine2 = ""
                    End If



                    City = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
                    PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

                    POBox = ""
                    POBoxPostCode = ""

                    ''''''''''''
                    Dim Ara() As String
                    Ara = AddressLine1.Split(",")
                    If Ara.Length >= 1 Then
                        AddressLine1 = Ara(0)
                    End If
                    If Ara.Length >= 2 Then
                        AddressLine2 = Ara(1)
                    End If
                    If Ara.Length >= 3 Then
                        'PostCode = Ara(2)
                    End If
                    If Ara.Length >= 4 Then
                        City = Ara(3)
                    End If

                    ''''''''''''

                    PhoneNo = ""

                    MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
                    If MobilePhone Is Nothing Then
                        MobilePhone = ""
                    End If

                    Email = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
                    If Email Is Nothing Then
                        Email = ""
                    End If
                    Email2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
                    If Email2 Is Nothing Then
                        Email2 = ""
                    End If
                    If Email2 <> "" Then
                        Email = Email2
                    End If

                    Password = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
                    If Password Is Nothing Then
                        Password = ""
                    End If

                    JobTitle = ""

                    Status = "ACTIVE"

                    MaritalStatus = ""

                    SocialSecurityNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
                    IdentityCardNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
                    PassportNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
                    IncomeTaxNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
                    AlienNumber = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)

                    Nationality = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)

                    'Department = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                    'DepartmentCode1 = FindDepartment1CodeFromDesc(Department)


                    DepartmentCode1 = Nationality
                    DepartmentCode1 = FindDepartment2CodeFromDesc(Nationality)

                    'Dim Anal5 As String = ""
                    'Anal5 = FindDepartment5CodeFromDesc(Nationality)


                    If DepartmentCode1 = "" Then
                        If ErrorM = "" Then
                            ErrorM = "Department Not found for the following Employees " & Chr(10) & Chr(10)
                        End If
                        ErrorM = ErrorM & FirstName & " " & LastName & "  - Department:   " & Department & Chr(10)
                    End If

                    Position = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                    PositionCode1 = GetPositionCodeFromDesc(Position)

                    SiCatCode = FindSICatCodeFromNationality(Nationality)




                    BankAccountNo = ""
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
                    SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)


                    'BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                    'If BankCode = "" Then
                    ' BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                    ' End If
                    ' If BankCode = "" Then
                    ' BankCode = Me.GLBLoadingFromExcel_CompanyBankCode
                    ' End If




                    TerminationDate = ""

                    Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
                    If Salary = "" Then
                        Salary = 0
                    End If
                    BankBenName = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)

                    Units = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)
                    GenAnalysis1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 35).value)


                    JobDescriptionCode = ""
                    EmployeeJobDescription = ""

                    PayrollCompanyNo = ""
                    Notes = ""


                    TemplateGroupCode = TemplateGroupForLoading

                    '

                    dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

                    Dim NewEmployee As Boolean = False
                    Dim Emp As New cPrMsEmployees(EmployeeCode)

                    If Emp.Code Is Nothing Then
                        NewEmployee = True
                    End If

                    If Emp.Code = "" Then
                        NewEmployee = True
                    End If

                    If TemplateGroupCode = "" Or EmployeeCode = "" Then
                        If NewEmployee And Status = "Terminated" Then
                            ContinueWithLoading = False
                        Else
                            MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
                            ContinueWithLoading = False
                            Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
                        End If
                    End If


                    If ContinueWithLoading Then

                        If NewEmployee Then


                            With Emp
                                .Code = EmployeeCode
                                If Status = "INNACTIVE" Then
                                    .Status = "I"
                                Else
                                    .Status = "A"
                                End If
                                .PayTyp_Code = "M01"
                                .TemGrp_Code = TemplateGroupCode
                                .EmpSta_Code = "A"

                                .LastName = LastName
                                .FirstName = FirstName
                                .FullName = LastName & " " & FirstName
                                If Gender = "Female" Then
                                    .Sex = "F"
                                    .Title = "MRS"
                                Else
                                    .Sex = "M"
                                    .Title = "MR"
                                End If
                                If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
                                    .BirthDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = BirthDate.Split("/")
                                    BirthDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .BirthDate = CDate(BirthDate)
                                End If
                                If MaritalStatus = "" Or MaritalStatus = "Single" Then
                                    .MarSta_Code = "S"
                                ElseIf MaritalStatus = "Married" Then
                                    .MarSta_Code = "M"
                                ElseIf MaritalStatus = "Divorce" Then
                                    .MarSta_Code = "D"
                                ElseIf MaritalStatus = "Widow" Then
                                    .MarSta_Code = "W"
                                End If

                                .Address1 = AddressLine1
                                .Address2 = City
                                .Address3 = AddressLine2

                                .PostCode = PostCode
                                .Telephone1 = PhoneNo
                                .Telephone2 = MobilePhone
                                .Email = Email
                                .SocialInsNumber = SocialSecurityNo

                                .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                                .IdentificationCard = IdentityCardNo
                                .TaxID = IncomeTaxNo
                                .PassportNumber = PassportNo
                                .AlienNumber = AlienNumber

                                If AlienNumber <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "7")
                                End If
                                If IncomeTaxNo <> "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "1")
                                End If
                                If AlienNumber = "" And IncomeTaxNo = "" Then
                                    .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "3")
                                End If



                                .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)

                                .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2, DepartmentCode1)


                                .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
                                .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                                .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
                                .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                                .Cou_Code = GetFirstRecordOfDataset(dsCountries)
                                '.EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)

                                .EmpPos_Code = PositionCode1


                                .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)

                                .EmpCmm_Code = FindSICatCodeFromNationality(Nationality)
                                '.EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)



                                .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
                                If IsNumeric(Units) Then
                                    .PeriodUnits = Units
                                Else
                                    .PeriodUnits = 0
                                End If

                                .AnnualUnits = 0
                                .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
                                .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods, "3")

                                .Bnk_Code = Me.GLBLoadingFromExcel_CompanyBankCode 'BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)

                                .BankAccount = BankAccountNo
                                .Bnk_CodeCo = Me.GLBLoadingFromExcel_CompanyBankCode 'GetFirstRecordOfDataset(dsBanks)
                                .BankAccountCo = Me.GLBLoadingFromExcel_CompanyIBAN

                                If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
                                    .StartDate = Now.Date
                                Else
                                    Dim Ar1() As String
                                    Ar1 = EmploymentDate.Split("/")
                                    EmploymentDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
                                    .StartDate = CDate(EmploymentDate)

                                End If
                                If TerminationDate <> "" Then
                                    Dim S As String
                                    Dim D As Date
                                    D = Cdate1(TerminationDate)
                                    S = Format(D, "yyyy/MM/dd")

                                    .TerminateDate = S
                                Else
                                    .TerminateDate = ""
                                End If

                                .OtherIncome1 = CDbl(0)
                                .OtherIncome2 = CDbl(0)
                                .OtherIncome3 = CDbl(0)
                                .PreviousEarnings = CDbl(0)
                                .Emp_PrevSIDeduct = CDbl(0)
                                .Emp_PrevSIContribute = CDbl(0)
                                .Emp_PrevITDeduct = CDbl(0)
                                .Emp_PrevPFDeduct = CDbl(0)

                                .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                                .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                                .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance, GLBLoadingFromExcel_SIRateCode)
                                .GESICode = GetFirstRecordOfDataset(dsGesi)

                                .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                                .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                                .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
                                .InterfaceTemCode = TemplateGroupCode
                                .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
                                .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

                                .DrivingLicense = ""
                                .PensionNo = ""
                                .MyPayslipReport = Me.GLBLoadingFromExcel_PayslipReport
                                .IBAN = IBAN
                                .PreviousLifeIns = CDbl(0)
                                .PreviousDis = CDbl(0)
                                .PreviousST = CDbl(0)
                                .OtherIncome4 = CDbl(0)

                                .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                                .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                                .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                                .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                                .OverLay = GetFirstRecordOfDataset(dsOverLay)
                                .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                                .FullPassName = ""
                                .Traveldocs = ""

                                .FirstEmployment = "0"
                                .IsSI = 0
                                .Password = Password
                                .Splitemployement = "0"
                                .BankBenName = BankBenName
                                .NewEmployee = "1"



                                .Emp_GLAnal1 = ""
                                .Emp_GLAnal2 = ""
                                .Emp_GLAnal3 = ""
                                .Emp_GLAnal4 = ""

                                .PensionType = "0"

                                .CreationDate = Now.Date
                                .CreatedBy = Global1.GLBUserId
                                .AmendDate = Now.Date
                                .AmendBy = Global1.GLBUserId
                                .Notes = Notes
                                .AnalGen1 = GenAnalysis1

                                If Not .Save() Then
                                    Throw Exx
                                End If

                                Dim SalVal As Double
                                Salary = Replace(Salary, "$", "")
                                Salary = Replace(Salary, "€", "")
                                Salary = Replace(Salary, """", "")
                                Salary = Trim(Salary)
                                SalVal = CDbl(Salary)


                                Dim EmpSal As New cPrTxEmployeeSalary
                                With EmpSal

                                    .Id = 0
                                    .Emp_Code = EmployeeCode
                                    .Date1 = Now.Date
                                    .SalaryValue = CDbl(SalVal)
                                    .Basic = CDbl(0)
                                    .EffPayDate = CDate(EmploymentDate)
                                    .Cola = CDbl(0)
                                    .EffArrearsDate = CDate(EmploymentDate)
                                    .Usr_Id = Global1.GLBUserId
                                    .myRate = CDbl(0)
                                    .IsCola = "N"
                                    .EmpSal_Dif = CDbl(0)

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With


                                Dim EmpAL As New cPrTxEmployeeLeave
                                With EmpAL

                                    .Id = 0
                                    .EmpCode = EmployeeCode
                                    .Status = "Approved"
                                    .Type = "1"
                                    .ReqDate = EmploymentDate
                                    .ProcDate = EmploymentDate
                                    .FromDate = EmploymentDate
                                    .ToDate = EmploymentDate
                                    .ProcBy = Global1.GLBUserId
                                    .Units = ALLeaveInUnits
                                    .Action = AN_IncreaseCODE

                                    If Not .Save() Then
                                        Throw Exx
                                    End If


                                End With



                                '''
                                Dim k As Integer
                                Dim DsErn As DataSet
                                DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
                                If CheckDataSet(DsErn) Then
                                    For k = 0 To DsErn.Tables(0).Rows.Count - 1
                                        Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                                        Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                        EmpErn.EmpCode = .Code
                                        EmpErn.ErnCode = E1.ErnCodCode
                                        EmpErn.MyValue = "0.00"
                                        EmpErn.TemGrpCode = .TemGrp_Code
                                        If Not EmpErn.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Deductions
                                Dim DsDed As DataSet
                                DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
                                If CheckDataSet(DsDed) Then
                                    For k = 0 To DsDed.Tables(0).Rows.Count - 1
                                        Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                                        Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                        EmpDed.EmpCode = .Code
                                        EmpDed.DedCode = D.DedCodCode
                                        EmpDed.MyValue = "0.00"
                                        EmpDed.TemGrpCode = .TemGrp_Code
                                        If Not EmpDed.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If
                                'Contributions
                                Dim DsCon As DataSet
                                DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
                                If CheckDataSet(DsCon) Then
                                    For k = 0 To DsCon.Tables(0).Rows.Count - 1
                                        Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                                        Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                        EmpCon.EmpCode = .Code
                                        EmpCon.ConCode = C.ConCodCode
                                        EmpCon.MyValue = "0.00"
                                        EmpCon.TemGrpCode = .TemGrp_Code
                                        If Not C.Save Then
                                            Throw Exx
                                        End If
                                    Next
                                End If

                            End With



                        End If

                        '''''''''

                    End If

                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
                End Try

                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub AdminImport2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminImport2ToolStripMenuItem.Click

        Dim F As New FrmLoadEmployeesFromExcel
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            Import_From_Excel_Employees_Iban_and_Swifts(GLBLoadingFromExcel_TemGroup)
        End If

    End Sub
    Private Sub Import_From_Excel_Employees_Iban_and_Swifts(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass




        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
            Global1.Business.BeginTransaction()

            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim Counter As Integer
            Counter = 0
            Dim StopInput As Boolean = False
            Counter = 2
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read

                Dim EmpCode As String
                Dim BankName As String
                Dim BankAccountNo As String
                Dim IBAN As String
                Dim SWIFT As String

                Try


                    EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)
                    BankName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                    IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                    SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


                    If EmpCode = "" Then
                        Exit Do
                    End If
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    If Emp.Code <> "" Then
                        Dim Code As String = ""
                        If BankName.Length > 12 Then
                            Code = BankName.Substring(0, 12)
                        Else
                            Code = BankName
                        End If
                        Code = Code.Replace(" ", "_")
                        Dim Bank As New cPrAnBanks(Code)

                        If Bank.Code = "" Then

                            Dim DescL As String = ""
                            Dim DescS As String = ""

                            If BankName.Length > 40 Then
                                DescL = BankName.Substring(0, 40)
                            Else
                                DescL = BankName
                            End If
                            If BankName.Length > 15 Then
                                DescS = BankName.Substring(0, 15)
                            Else
                                DescS = BankName
                            End If

                            Bank = New cPrAnBanks
                            With Bank
                                .Code = Code
                                .DescriptionL = DescL
                                .DescriptionS = DescS
                                .IsActive = "Y"
                                .SwiftCode = SWIFT
                                If Not .Save Then
                                    Throw Exx
                                End If
                            End With

                        End If
                        Emp.IBAN = IBAN
                        Emp.Bnk_Code = Code
                        Emp.Save()

                    End If
                    Counter = Counter + 1


                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Error loading employee with Code " & EmpCode, MsgBoxStyle.Critical)
                End Try


            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub mnuImportEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportEmails.Click
        LoadVarious(1, True)
    End Sub
    Private Sub mnuImportIBANs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportIBANs.Click
        LoadVarious(2, True)
    End Sub

    Private Sub mnuImportAccountNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportAccountNo.Click
        LoadVarious(3, True)
    End Sub
    Private Sub ImportGL1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportGL1ToolStripMenuItem.Click
        LoadVarious(9, True)
    End Sub


    Private Sub LoadVarious(ByVal Type As String, ByVal Usecode As Boolean)
        Dim F As New FrmLoadGeneralImportForm
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.LoadingType = Type
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            Import_From_Excel_GeneralImport(Type, Usecode)
        End If
    End Sub
    Private Sub Import_From_Excel_GeneralImport(ByVal LoadingType As String, ByVal UseCode As Boolean)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp
        Dim EmpCode As String = ""
        Dim Data As String = ""
        Dim Counter As Integer = 0

        Try
            Dim FileDir As String
            Dim Exx As New Exception
            Global1.Business.BeginTransaction()
            xlWorkBook = xlApp.Workbooks.Open(GLBLoadingFromExcel_ExcelFileToOpen)
            xlWorkSheet = xlWorkBook.Worksheets(1)


            Dim Line As String
            Dim Ar() As String

            Dim StopInput As Boolean = False
            Dim ErrorM As String = ""
            Counter = Me.GLBLoadingFromExcel_FirstRow

            Do While StopInput = False
                Me.Refresh()



                EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)

                If EmpCode = "" Then
                    StopInput = True
                    Exit Do
                End If
                Dim Emp As New cPrMsEmployees(EmpCode)
                If Emp.Code = "" Then
                    MsgBox("Invalid Employee Code " & EmpCode & " at row " & Counter, MsgBoxStyle.Critical)
                    Throw Exx
                End If

                Data = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)

                Select Case LoadingType
                    Case 1
                        Emp.Email = Data
                    Case 2
                        Emp.IBAN = Data
                    Case 3
                        Emp.BankAccount = Data
                    Case 4
                        If UseCode Then
                            Emp.EmpAn1_Code = Data
                        Else
                            Dim code As String = ""
                            If Data.Length > 40 Then
                                Data = Data.Substring(0, 40)
                            End If

                            code = Me.FindDepartment1CodeFromDesc(Data)

                            If code = "" Then
                                MsgBox("Cannot Find Analysis 1 with Description '" & Data & "'", MsgBoxStyle.Critical)
                                Throw Exx
                            End If
                            Emp.EmpAn1_Code = code
                        End If
                    Case 5
                        If UseCode Then
                            Emp.EmpAn2_Code = Data
                        Else
                            Dim code As String = ""
                            If Data.Length > 40 Then
                                Data = Data.Substring(0, 40)
                            End If

                            code = Me.FindDepartment2CodeFromDesc(Data)
                            If code = "" Then
                                MsgBox("Cannot Find Analysis 2 with Description '" & Data & "'", MsgBoxStyle.Critical)
                                Throw Exx
                            End If
                            Emp.EmpAn2_Code = code
                        End If
                    Case 6
                        If UseCode Then
                            Emp.EmpAn3_Code = Data
                        Else
                            Dim code As String = ""
                            If Data.Length > 40 Then
                                Data = Data.Substring(0, 40)
                            End If
                            code = Me.FindDepartment3CodeFromDesc(Data)
                            If code = "" Then
                                MsgBox("Cannot Find Analysis 3 with Description '" & Data & "'", MsgBoxStyle.Critical)
                                Throw Exx
                            End If
                            Emp.EmpAn3_Code = code
                        End If
                    Case 7
                        If UseCode Then
                            Emp.EmpAn4_Code = Data
                        Else
                            Dim code As String = ""
                            If Data.Length > 40 Then
                                Data = Data.Substring(0, 40)
                            End If
                            code = Me.FindDepartment4CodeFromDesc(Data)
                            If code = "" Then
                                MsgBox("Cannot Find Analysis 4 with Description '" & Data & "'", MsgBoxStyle.Critical)
                                Throw Exx
                            End If
                            Emp.EmpAn4_Code = code
                        End If
                    Case 8
                        If UseCode Then
                            Emp.EmpAn5_Code = Data
                        Else
                            Dim code As String = ""
                            If Data.Length > 40 Then
                                Data = Data.Substring(0, 40)
                            End If
                            code = Me.FindDepartment5CodeFromDesc(Data)
                            If code = "" Then
                                MsgBox("Cannot Find Analysis 5 with Description '" & Data & "'", MsgBoxStyle.Critical)
                                Throw Exx
                            End If
                            Emp.EmpAn5_Code = code
                        End If
                    Case 9
                        Emp.Emp_GLAnal1 = Data

                End Select

                If Not Emp.Save Then
                    Throw Exx
                End If

                Counter = Counter + 1
            Loop

            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmpCode & " at line " & Counter, MsgBoxStyle.Critical)
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Function FindNextAnalysisCode(ByVal Analysis) As String
        Dim Code As String
        Code = Global1.Business.GetNextAnalysisCode(Analysis)
        Return Code
    End Function



    Private Sub mnuCodeAnalysis1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCodeAnalysis1.Click
        LoadVarious(4, True)
    End Sub

    Private Sub mnuCodeAnalysis2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCodeAnalysis2.Click
        LoadVarious(5, True)
    End Sub

    Private Sub mnuCodeAnalysis3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCodeAnalysis3.Click
        LoadVarious(6, True)
    End Sub

    Private Sub mnuCodeAnalysis4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCodeAnalysis4.Click
        LoadVarious(7, True)
    End Sub

    Private Sub mnuCodeAnalysis5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCodeAnalysis5.Click
        LoadVarious(8, True)
    End Sub

    Private Sub mnudesAnalysis1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesAnalysis1.Click
        LoadVarious(4, False)
    End Sub

    Private Sub mnudesAnalysis2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDesAnalysis2.Click
        LoadVarious(5, False)
    End Sub

    Private Sub mnudesAnalysis3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDesAnalysis3.Click
        LoadVarious(6, False)
    End Sub

    Private Sub mnudesAnalysis4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDesAnalysis4.Click
        LoadVarious(7, False)
    End Sub

    Private Sub mnudesAnalysis5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDesAnalysis5.Click
        LoadVarious(8, False)
    End Sub



    Private Sub TestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim F As New FrmLoadEmployeesFromExcel
        GLBProceedWithExcel_Loading = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_Loading Then
            Import_From_Excel_Employees_Template_4(GLBLoadingFromExcel_TemGroup)
        End If

    End Sub



    Public Function GetDriveSerialNumber() As String
        Dim DriveSerial As Integer
        'Create a FileSystemObject object
        Dim fso As Object = CreateObject("Scripting.FileSystemObject")
        Dim Drv As Object = fso.GetDrive(fso.GetDriveName(Application.StartupPath))
        With Drv
            If .IsReady Then
                DriveSerial = .SerialNumber

            Else    '"Drive Not Ready!"
                DriveSerial = -1
            End If
        End With
        Return DriveSerial.ToString("X2")
    End Function

    Private Function CheckForCLicence() As String
        Dim Key As String = "amx30b2!"
        Dim EncryptedSerialNo As String
        Dim DriverSerialNo As String
        Dim Description As String = ""
        Dim Ds As DataSet

        DriverSerialNo = GetDriverSerialNumber()
        EncryptedSerialNo = EncryptMe(DriverSerialNo, Key)

        Ds = Global1.Business.CheckForLicence(EncryptedSerialNo)
        If CheckDataSet(Ds) Then
            Description = DbNullToString(Ds.Tables(0).Rows(0).Item(0))

        End If

        Return Description


    End Function


    Public Function GetDriverSerialNumber() As String
        Dim S As String
        S = GetDriveSerialNumber()
        Return S
    End Function

    Public Function EncryptMe(ByVal TextForEncryption As String, ByVal Key As String) As String
        Dim wrapper As New Simple3Des(Key)
        Dim cipherText As String = wrapper.EncryptData(TextForEncryption)

        Return cipherText

    End Function
    Private Function Decoding(ByVal EncryptedText As String, ByVal Key As String) As String
        Dim wrapper As New Simple3Des(Key)
        Dim Result As String = ""
        ' DecryptData throws if the wrong password is used.
        Try
            Result = wrapper.DecryptData(EncryptedText)

        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
        Return Result
    End Function

    Public Sub CheckForLicenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForLicenceToolStripMenuItem.Click
        Dim Description As String
        Description = Me.CheckForCLicence
        If Description = "" Then
            MsgBox("This PC is not Licenced, Please contact SC Insoft Limited , or Enter a Product Key", MsgBoxStyle.Critical)
        Else
            MsgBox("This PC is Licenced under the Description: " & Description, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub RegisterThisPCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterThisPCToolStripMenuItem.Click
        Dim F As New FrmRegistredPCs
        F.Owner = Me
        F.ShowDialog()
        If CheckForCLicence() = "" Then
            MsgBox("This PC is not Licenced, Please contact SC Insoft Limited , or Enter a Product Key", MsgBoxStyle.Critical)
        End If


    End Sub
    Private Sub Import_DateOfBirth()

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass

        Dim Ern(14) As E_Emp
        Dim Ded(14) As D_Emp
        Dim Con(14) As C_Emp
        Dim EmpCode As String = ""
        Dim Data As String = ""
        Dim Counter As Integer = 0

        Try
            Dim FileDir As String
            Dim Exx As New Exception
            Global1.Business.BeginTransaction()
            xlWorkBook = xlApp.Workbooks.Open("c:\DOB3.xlsx")
            xlWorkSheet = xlWorkBook.Worksheets(1)


            Dim Line As String
            Dim Ar() As String

            Dim StopInput As Boolean = False
            Dim ErrorM As String = ""
            Counter = Me.GLBLoadingFromExcel_FirstRow
            Counter = 1
            Do While StopInput = False
                Me.Refresh()
                Dim DoNotLoad As Boolean = False

                EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)

                If EmpCode = "" Then
                    StopInput = True
                    Exit Do
                End If
                EmpCode = EmpCode.PadLeft(4, "0")

                Dim Emp As New cPrMsEmployees(EmpCode)
                If Emp.Code = "" Then
                    MsgBox("Invalid Employee Code " & EmpCode & " at row " & Counter, MsgBoxStyle.Critical)
                    DoNotLoad = True
                End If
                If Not DoNotLoad Then
                    Data = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                    If Data = "" Then
                        MsgBox("Employee " & Emp.Code & " " & Emp.FullName & " has no DOB")
                    Else
                        Data = Trim(Data)
                        Data = Data.Replace(" ", "")
                        Dim ar1() As String
                        ar1 = Data.Split("/")
                        Dim BirthDate As String
                        Dim Replace As Boolean = False
                        Dim D As Date
                        BirthDate = Trim(ar1(2)) & "/" & Trim(ar1(0)) & "/" & Trim(ar1(1))

                        Try
                            D = CDate(BirthDate)
                        Catch ex As Exception
                            MsgBox("ERRORLOADING Employee " & Emp.Code & " " & D)
                            DoNotLoad = True
                        End Try
                        If Not DoNotLoad Then
                            Replace = True
                            If Emp.BirthDate <> CDate(BirthDate) Then
                                Dim ans As New MsgBoxResult

                                ans = MsgBox("Employee " & Emp.Code & " " & Emp.FullName & " System DOB:" & Emp.BirthDate & " File DOB:" & Format(CDate(BirthDate), "dd/MM/yyyy") & " Replace?", MsgBoxStyle.YesNoCancel)
                                If ans = MsgBoxResult.Yes Then
                                    Replace = True
                                Else
                                    Replace = False
                                End If
                            End If
                            If Replace Then
                                Emp.BirthDate = CDate(BirthDate)
                                If Not Emp.Save Then
                                    MsgBox("Employee " & Emp.Code & " error")
                                    Throw Exx
                                End If
                            End If
                        End If
                    End If
                End If
                Counter = Counter + 1
            Loop

            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading employee with Code " & EmpCode & " at line " & Counter, MsgBoxStyle.Critical)
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub


    Private Sub TestToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem2.Click
        Import_DateOfBirth()
    End Sub


    Private Sub ExportToLociiReportingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToLociiReportingToolStripMenuItem.Click
        Dim F As New FrmLociiExport
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub mnuImportExcelFromJIRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportExcelFromJIRA.Click

        Dim F As New FrmLoadJIRAFromExcel
        GLBProceedWithExcel_JIRA = False
        F.Owner = Me
        F.ShowDialog()
        If GLBProceedWithExcel_JIRA Then
            PanelJira.Visible = True
            Import_From_Excel_JIRA_1(GLBLoadingFromExcel_TemGroup)
            PanelJira.Visible = False
        End If

    End Sub
    Private Sub Import_From_Excel_JIRA_1(ByVal TemplateGroupForLoading As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass


        Global1.Business.BeginTransaction()
        Dim Counter As Integer
        Try
            'on form load instantiate the connection object
            Dim FileDir As String

            Dim Exx As New Exception

            'param_file = IO.File.OpenText("Data\Excel\Employees.txt")


            'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")

            xlWorkBook = xlApp.Workbooks.Open(Me.GLBLoadingFromExcel_JIRAExcelFileToOpen)

            xlWorkSheet = xlWorkBook.Worksheets(1)



            Dim Line As String
            Dim Ar() As String
            'Do While param_file.Peek <> -1
            Dim StopInput As Boolean = False
            Counter = 2
            Dim ErrorM As String = ""
            Do While StopInput = False
                Me.Refresh()
                'Line = param_file.Read
                Dim Issue_Key As String = "" = ""
                Dim Issue_summary As String = ""
                Dim Hours As String = ""
                Dim Work_date As String = ""
                Dim User_Account_ID As String = ""
                Dim Full_name As String = ""
                Dim Tempo_Team As String = ""
                Dim Program As String = ""
                Dim ProgramManager As String = ""
                Dim Period As String = ""
                Dim Account_Key As String = ""
                Dim Account_Name As String = ""
                Dim Account_Lead_ID As String = ""
                Dim Account_Category As String = ""
                Dim Account_Customer As String = ""
                Dim Activity_Name As String = ""
                Dim Component As String = ""
                Dim All_Components As String = ""
                Dim Version_Name As String = ""
                Dim Issue_Type As String = ""
                Dim Issue_Status As String = ""
                Dim Project_Key As String = ""
                Dim Project_Name As String = ""
                Dim Epic As String = ""
                Dim Epic_Link As String = ""
                Dim Work_Description As String = ""
                Dim Parent_Key As String = ""
                Dim Reporter_ID As String = ""
                Dim External_Hours As String = ""
                Dim Billed_Hours As String = ""
                Dim Issue_Original_Estimate As String = ""
                Dim Issue_Remaining_Estimate As String = ""
                Dim Date_created As String = ""
                Dim Date_updated As String = ""

                Dim SkipThis As Boolean = False

                Me.LabelJirastatus.Text = "Please wait ... Loading from Jira Line: " & Counter
                Application.DoEvents()

                Issue_Key = NothingToEmpty(xlWorkSheet.Cells(Counter, 1).value)
                If Issue_Key = "" Then
                    Exit Do
                End If
                Issue_summary = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
                Hours = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)
                Work_date = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
                User_Account_ID = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
                Full_name = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
                Tempo_Team = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)
                Program = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
                ProgramManager = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
                Period = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)

                Account_Key = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
                Account_Name = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
                Account_Lead_ID = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
                Account_Category = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)
                Account_Customer = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
                Activity_Name = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
                Component = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
                All_Components = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
                Version_Name = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
                Issue_Type = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
                Issue_Status = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
                Project_Key = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
                Project_Name = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)
                Epic = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)
                Epic_Link = NothingToEmpty(xlWorkSheet.Cells(Counter, 25).value)
                Work_Description = NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value)
                Parent_Key = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
                Reporter_ID = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)
                External_Hours = NothingToEmpty(xlWorkSheet.Cells(Counter, 29).value)
                Billed_Hours = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
                Issue_Original_Estimate = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)
                Issue_Remaining_Estimate = NothingToEmpty(xlWorkSheet.Cells(Counter, 32).value)
                Date_created = NothingToEmpty(xlWorkSheet.Cells(Counter, 33).value)
                Date_updated = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)

                Dim Ta As New cTaTxTrxnLines2

                With Ta
                    .Id = 0
                    .Mydate = CDate(Work_date).Date
                    '**********************************************
                    '  .Mydate = DateAdd(DateInterval.Month, -1, .Mydate)
                    '**********************************************

                    Dim EmpTemp() As String
                    EmpTemp = Full_name.Split("-")

                    Dim Emp As New cPrMsEmployees(Trim(EmpTemp(0)))
                    SkipThis = False
                    'If Emp.Code = "" Then
                    '    Dim Ans As MsgBoxResult
                    '    Ans = MsgBox("Employee with Code: " & Trim(EmpTemp(0)) & " at line: " & Counter & " Does not exist , Proceed with Loading ?", MsgBoxStyle.YesNo)
                    '    If Ans = MsgBoxResult.No Then
                    '        Throw Exx
                    '    Else
                    '        skipthis = True
                    '    End If
                    'End If
                    If Not SkipThis Then
                        .EmployeeCode = Trim(EmpTemp(0))
                        .Day = FindDayOfWeek(.Mydate.DayOfWeek)
                        .FromTime = Format(CDate(Work_date), "hh:mm:ss")


                        Dim dMinutes As Double
                        dMinutes = RoundMe2(Hours * 60, 2)
                        Dim dToDate As Date
                        dToDate = DateAdd(DateInterval.Minute, dMinutes, CDate(Work_date))
                        .ToTime = Format(dToDate, "hh:mm:ss")

                        Dim dhours As Double
                        dhours = ConvertToTime(dMinutes)

                        .TotalTime = CDbl(dhours)
                        .WorkGroupCode = "01"
                        .WorkCode = "01"
                        .UserId_Create = Global1.GLBUserId
                        .UserId_LastUpdate = Global1.GLBUserId
                        .Created = Now
                        .LastUpdate = Now
                        .Status = "POST"
                        Dim DescS As String = ""

                        Dim Anl5 As New cPrAnEmployeeAnalysis5(Account_Key)
                        If Anl5.EmpAn5_Code = "" Or Anl5.EmpAn5_Code Is Nothing Then
                            Anl5.EmpAn5_Code = Account_Key
                            If Account_Name.Length > 40 Then
                                Account_Name = Account_Name.Substring(0, 39)
                            End If
                            Anl5.EmpAn5_DescriptionL = Account_Name
                            If Project_Name.Length > 14 Then
                                DescS = Account_Name.Substring(0, 13)
                            Else
                                DescS = Account_Name
                            End If
                            Anl5.EmpAn5_DescriptionS = DescS
                            Anl5.EmpAn5_IsActive = "Y"
                            Anl5.GLAnal1 = Account_Key
                            Anl5.GLAnal2 = "8|0"
                            Anl5.EmpAn5_CreationDate = Now.Date
                            Anl5.EmpAn5_AmendDate = Now.Date

                            If Not Anl5.Save Then
                                Throw Exx
                            End If
                        End If
                        .AnalCode = Account_Key
                        .AnalDesc = Account_Name

                        If Not .Save() Then
                            Throw Exx
                        End If
                    End If


                End With



                Counter = Counter + 1
            Loop



            Global1.Business.CommitTransaction()
            MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
            'Update / Deletes additions, you name it all use the same technology. 
            If ErrorM <> "" Then
                MsgBox(ErrorM)
            End If
        Catch ex As Exception

            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Error loading line  " & Counter, MsgBoxStyle.Critical)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
    Private Function FindDayOfWeek(ByVal k As Integer) As String
        Dim S As String
        Select Case k
            Case 0
                S = "MON"

            Case 1
                S = "TUE"

            Case 2
                S = "WED"

            Case 3
                S = "THU"

            Case 4
                S = "FRI"

            Case 5
                S = "SAT"

            Case 6
                S = "SUN"

        End Select
        Return S

    End Function
    Private Function ConvertToTime(ByVal D As Double) As String
        Dim M As Double
        Dim Ar() As String
        Dim H As Double
        Dim Time As String
        M = D Mod 60
        Ar = (D / 60).ToString.Split(".")
        H = Ar(0)

        Time = Math.Abs(H) & "." & Format(Math.Abs(M), "00")

        Return CDbl(Time)
    End Function

    Private Sub TmnuTest1_Click(sender As Object, e As EventArgs) Handles mnuTest1.Click
        Dim F As New FrmExcelsysWebServices
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub mnuScale1_Click(sender As Object, e As EventArgs) Handles mnuScale1.Click
        Dim F As New frmPrAnScales1
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub mnuScale2_Click(sender As Object, e As EventArgs) Handles mnuScale2.Click
        Dim F As New frmPrAnScales2
        F.MdiParent = Me
        F.Show()
    End Sub

    Private Sub Scale3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale3ToolStripMenuItem.Click
        Dim F As New frmPrAnScales3
        F.MdiParent = Me
        F.Show()
    End Sub
End Class
