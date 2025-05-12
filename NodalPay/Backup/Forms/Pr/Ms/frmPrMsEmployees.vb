
Public Class frmPrMsEmployees
    Dim GLBTempGroup As New cPrMsTemplateGroup
    Dim tPrMsEmployees As New cPrMsEmployees
    Dim DG1Changing As Boolean = False
    Dim Ern(14) As E_Emp
    Dim Ded(14) As D_Emp
    Dim Con(14) As C_Emp
    Dim GlbCompany As New cAdMsCompany
    Public EmpCodeFromPayrollForm As String

    Dim CopyEmp As New cPrMsEmployees
    Dim CopyDsSalary As DataSet
    Dim CopyDsAnnualLeave As DataSet
    Dim CopyDsDiscounts As DataSet
    Dim CopyDsReminders As DataSet

    Public MyDs As DataSet
    Dim Dt1 As DataTable
    Dim GlbEmp As New cPrMsEmployees
    Public GLBExportReportType As String

    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Dim DsTemplateGroups As DataSet



    Private Sub frmPrMsEmployees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Top = 0
        Me.Left = 0

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        'If Global1.UserRole = Roles.Admin Then
        '    Me.UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Visible = True
        'Else
        '    Me.UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Visible = False
        'End If
        If TSBSave.Enabled Then
            Me.UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Visible = True
        Else
            Me.UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Visible = False
        End If
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            Me.mnuGDPR.Visible = True
            '            Me.btnCreateEmployees.Visible = True
            Me.ToolStripSeparator3.Visible = True
            Me.btnUpdateSalaries.Visible = True
            Me.BtnChangeTempGroupIntransactions.Visible = True

        Else
            Me.mnuGDPR.Visible = False
            Me.ToolStripSeparator3.Visible = False
            Me.btnUpdateSalaries.Visible = False
            Me.BtnChangeTempGroupIntransactions.Visible = False
            '    Me.btnCreateEmployees.Visible = False

        End If
        ' Me.TSBPayroll.Enabled = False
        CheckPermition()
        ' Me.TSBPayroll.Enabled = False
        'If CType(Me.MdiParent, FrmMain).MnuDoPayroll.Enabled Then
        'Me.TSBPayroll.Enabled = True
        ' End If
        If EmpCodeFromPayrollForm <> "" Then
            Dim Emp As New cPrMsEmployees(EmpCodeFromPayrollForm)
            If Emp.Code <> "" Then
                Me.txtCode.Text = Emp.Code
                LoadEmployee(Emp, False)
            End If
        End If

        InitDatatable()
        InitDataGrid()

        If Global1.GLBDedtorsInterface Then
            Me.Label11.Text = "Loan Account"
            Me.Label12.Text = "Rent Account"
        End If
        If Global1.GLBDedtorsInterface Then
            Me.Label13.Text = "Savings Account"
        End If


    End Sub





    Private Sub CheckPermition()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Employees")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                TSBSave.Enabled = False
                TSBDelete.Enabled = False
                TSBNew.Enabled = False

                Me.ExcelMenu.Enabled = False
                Me.TSBExcel.Enabled = False
                TabControl1.Enabled = False
                Me.ToolStripDropDownButton1.Enabled = False

                Me.ChangeCodeToolStripMenuItem.Enabled = False
                Me.ImportExtraBonusOnSalaryToolStripMenuItem.Enabled = False
                Me.mnuGDPR.Enabled = False
                Me.ChangeIBANNumberToolStripMenuItem.Enabled = False
                Me.ChangeCompanyBankToolStripMenuItem.Enabled = False
                Me.ChangeCompanyBankCodeIBANBasedOnEmployeeBankToolStripMenuItem.Enabled = False
                Me.ReplaceEDCValueToolStripMenuItem.Enabled = False
                Me.UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Enabled = False

                Me.mnuReminders.Enabled = False
                Me.mnuEmployeeSplit.Enabled = False
                Me.NewEmployeeSIRegFormToolStripMenuItem.Enabled = False
                Me.RegisterEmployeeCovidTestToolStripMenuItem.Enabled = False

                Me.ChangeEmployeePayslipReportToolStripMenuItem.Enabled = False






            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    TSBSalary.Enabled = False
                    Me.TSBPayroll.Enabled = False
                    Me.TSBExcel.Enabled = False
                    Me.ExcelMenu.Enabled = False
                    ToolStripSplitButton1.Enabled = False
                End If
            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "Discounts")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    TSBDiscounts.Enabled = False
                End If
            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "AnnualLeave")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    TSBAnnualLeave.Enabled = False
                End If
            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "Advances")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    TSBAdvances.Enabled = False
                End If
            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "ArchivePayslips")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    MnuArchivePayslips.Enabled = False
                End If
            End If
            P = New cPrSsUserPermitions("", Global1.GLBUserCode, "Loans")
            If P.id > 0 Then
                If P.NoPermission = 1 Then
                    mnuEmployeeLoans.Enabled = False
                End If
            End If

        Else
            MsgBox("Please Define User Permissions, Payroll", MsgBoxStyle.Critical)
            Me.Close()
        End If

        ''''''''''''''' Time Attendance HOSH ''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("ET", "EnableET")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "0" Then
                Global1.PARAM_ETFileEnable = False
            Else
                Global1.PARAM_ETFileEnable = True
            End If
        Else
            Global1.PARAM_ETFileEnable = False
        End If


        Ds = Global1.Business.GetParameter("ET", "FilePath")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_ETFilePath = Par.Value1
        Else
            Global1.PARAM_ETFilePath = ""
        End If

        If Global1.PARAM_ETFileEnable Then
            Me.ImportExtraBonusOnSalaryToolStripMenuItem.Visible = True
        Else
            Me.ImportExtraBonusOnSalaryToolStripMenuItem.Visible = False
        End If

        PARAM_warningonSIR = False
        Ds = Global1.Business.GetParameter("System", "WarnSI")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                PARAM_warningonSIR = True
            End If
        End If



    End Sub
    Private Sub Initialize()
        InitArray_Ern()
        InitArray_Ded()
        InitArray_Con()
        LoadCombos()
        ClearMe()
        PutDecimalValidationOnTxts()

    End Sub
    Private Sub InitArray_Ern()
        Ern(0) = Me.E_Emp1
        Ern(1) = Me.E_Emp2
        Ern(2) = Me.E_Emp3
        Ern(3) = Me.E_Emp4
        Ern(4) = Me.E_Emp5
        Ern(5) = Me.E_Emp6
        Ern(6) = Me.E_Emp7
        Ern(7) = Me.E_Emp8
        Ern(8) = Me.E_Emp9
        Ern(9) = Me.E_Emp10
        Ern(10) = Me.E_Emp11
        Ern(11) = Me.E_Emp12
        Ern(12) = Me.E_Emp13
        Ern(13) = Me.E_Emp14
        Ern(14) = Me.E_Emp15
    End Sub
    Private Sub InitArray_Ded()
        Ded(0) = Me.D_Emp1
        Ded(1) = Me.D_Emp2
        Ded(2) = Me.D_Emp3
        Ded(3) = Me.D_Emp4
        Ded(4) = Me.D_Emp5
        Ded(5) = Me.D_Emp6
        Ded(6) = Me.D_Emp7
        Ded(7) = Me.D_Emp8
        Ded(8) = Me.D_Emp9
        Ded(9) = Me.D_Emp10
        Ded(10) = Me.D_Emp11
        Ded(11) = Me.D_Emp12
        Ded(12) = Me.D_Emp13
        Ded(13) = Me.D_Emp14
        Ded(14) = Me.D_Emp15
    End Sub
    Private Sub InitArray_Con()
        Con(0) = Me.C_Emp1
        Con(1) = Me.C_Emp2
        Con(2) = Me.C_Emp3
        Con(3) = Me.C_Emp4
        Con(4) = Me.C_Emp5
        Con(5) = Me.C_Emp6
        Con(6) = Me.C_Emp7
        Con(7) = Me.C_Emp8
        Con(8) = Me.C_Emp9
        Con(9) = Me.C_Emp10
        Con(10) = Me.C_Emp11
        Con(11) = Me.C_Emp12
        Con(12) = Me.C_Emp13
        Con(13) = Me.C_Emp14
        Con(14) = Me.C_Emp15
    End Sub

    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        If Me.txtCode.Text = "" Then
            Flag = False
            Me.ErrCode.SetError(Me.txtCode, "Field is Required")
        End If
        'If Me.txtStatus.Text = "" Then
        '    Flag = False
        '    Me.ErrStatus.SetError(Me.txtStatus, "Field is Required")
        'End If
        If Me.txtTitle.Text = "" Then
            Flag = False
            Me.ErrTitle.SetError(Me.txtTitle, "Field is Required")
        End If
        If Me.txtLastName.Text = "" Then
            Flag = False
            Me.ErrLastName.SetError(Me.txtLastName, "Field is Required")
        End If
        If Me.txtFirstName.Text = "" Then
            Flag = False
            Me.ErrFirstName.SetError(Me.txtFirstName, "Field is Required")
        End If
        If Me.txtFullName.Text = "" Then
            Flag = False
            Me.ErrFullName.SetError(Me.txtFullName, "Field is Required")
        End If
        If Me.cmbSex.Text = "" Then
            Flag = False
            Me.ErrSex.SetError(Me.cmbSex, "Field is Required")
        End If
        'If Me.txtAddress1.Text = "" Then
        '    Flag = False
        '    Me.ErrAddress1.SetError(Me.txtAddress1, "Field is Required")
        'End If
        'If Me.txtAddress2.Text = "" Then
        '    Flag = False
        '    Me.ErrAddress2.SetError(Me.txtAddress2, "Field is Required")
        'End If
        'If Me.txtAddress3.Text = "" Then
        '    Flag = False
        '    Me.ErrAddress3.SetError(Me.txtAddress3, "Field is Required")
        'End If
        'If Me.txtPostCode.Text = "" Then
        '    Flag = False
        '    Me.ErrPostCode.SetError(Me.txtPostCode, "Field is Required")
        'End If
        'If Me.txtTelephone1.Text = "" Then
        '    Flag = False
        '    Me.ErrTelephone1.SetError(Me.txtTelephone1, "Field is Required")
        'End If
        'If Me.txtTelephone2.Text = "" Then
        '    Flag = False
        '    Me.ErrTelephone2.SetError(Me.txtTelephone2, "Field is Required")
        'End If
        'If Me.txtEmail.Text = "" Then
        '    Flag = False
        '    Me.ErrEmail.SetError(Me.txtEmail, "Field is Required")
        'End If
        'If Me.txtSocialInsNumber.Text = "" Then
        '    Flag = False
        '    Me.ErrSocialInsNumber.SetError(Me.txtSocialInsNumber, "Field is Required")
        'End If
        'If Me.txtComSin_EmpSocialInsNo.Text = "" Then
        '    Flag = False
        '    Me.ErrComSin_EmpSocialInsNo.SetError(Me.txtComSin_EmpSocialInsNo, "Field is Required")
        'End If
        'If Me.txtIdentificationCard.Text = "" Then
        '    Flag = False
        '    Me.ErrIdentificationCard.SetError(Me.txtIdentificationCard, "Field is Required")
        'End If
        'If Me.txtTaxId.Text = "" Then
        '    Flag = False
        '    Me.ErrTaxID.SetError(Me.txtTaxId, "Field is Required")
        'End If
        'If Me.txtPassportNumber.Text = "" Then
        '    Flag = False
        '    Me.ErrPassportNumber.SetError(Me.txtPassportNumber, "Field is Required")
        'End If
        'If Me.txtAlienNumber.Text = "" Then
        '    Flag = False
        '    Me.ErrAlienNumber.SetError(Me.txtAlienNumber, "Field is Required")
        'End If





        'If Me.cmbTaxCardType.Text = "" Then
        '    Flag = False
        '    Me.ErrTicTyp_Code.SetError(Me.cmbTaxCardType, "Field is Required")
        'Else
        '    Dim TaxCardType As String
        '    TaxCardType = CType(Me.cmbTaxCardType.SelectedItem, cPrAnTaxCardType).Code
        '    Select Case TaxCardType
        '        Case "1"
        '            If Me.txtTaxId.Text = "" Then
        '                MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'T.I.C. Cyprus ' but TIC number field has no Value, Please correct", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If
        '        Case "2"
        '            MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Passport' whitch is now an obsolete value, Valid Fields are 1,3,4 and 7.Please correct", MsgBoxStyle.Critical)
        '            Flag = False

        '        Case "3"
        '            If Me.txtIdentificationCard.Text = "" Then
        '                MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Identification' but Cyprus Identification field has no value, Please correct", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If

        '        Case "4"
        '            If Me.txtOhterCountryTIC.Text = "" Then
        '                MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Other Country TIC' but Other country TIC Number field has no value, Please correct", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If
        '        Case "5"
        '            MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Social Insurance' whitch is now an obsolete value Valid Fields are 1,3,4 and 7.Please correct", MsgBoxStyle.Critical)
        '            Flag = False
        '        Case "6"
        '            MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Drivers Licence' whitch is now an obsolete value Valid Fields are 1,3,4 and 7.Please correct", MsgBoxStyle.Critical)
        '            Flag = False
        '        Case "7"
        '            If Me.txtAlienNumber.Text = "" Then
        '                MsgBox("In Tab 'Personal' Tax Identification Type field is set to 'Alien Number' but Alien Number field has no value, Please correct", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If

        '    End Select
        ' End If
        If Me.txtPeriodUnits.Text = "" Then
            Flag = False
            Me.ErrPeriodUnits.SetError(Me.txtPeriodUnits, "Field is Required")
        Else
            If Not IsNumeric(Me.txtPeriodUnits.Text) Then
                Flag = False
                Me.ErrPeriodUnits.SetError(Me.txtPeriodUnits, "Field requires a number")
            Else
                If NullToDbl(Me.txtPeriodUnits.Text) < 0 Then
                    Flag = False
                    Me.ErrPeriodUnits.SetError(Me.txtPeriodUnits, "Field requires positive number")
                End If
            End If
        End If
        If Me.txtAnnualUnits.Text = "" Then
            Flag = False
            Me.ErrAnnualUnits.SetError(Me.txtAnnualUnits, "Field is Required")
        Else
            If Not IsNumeric(Me.txtAnnualUnits.Text) Then
                Flag = False
                Me.ErrAnnualUnits.SetError(Me.txtAnnualUnits, "Field requires a number")
            Else
                If NullToInt(Me.txtAnnualUnits.Text) < 0 Then
                    Flag = False
                    Me.ErrAnnualUnits.SetError(Me.txtAnnualUnits, "Field requires positive number")
                End If
            End If
        End If
        'If Me.txtBankAccount.Text <> "" Then
        '    If Not IsNumeric(Me.txtBankAccount.Text) Then
        '        Flag = False
        '        Me.ErrBankAccount.SetError(Me.txtBankAccount, "Use Only Numbers without '-' or other characters")
        '    End If
        'End If
        'If Me.txtBankAccountCo.Text <> "" Then
        '    If Not IsNumeric(Me.txtBankAccountCo.Text) Then
        '        Flag = False
        '        Me.ErrBankAccountCo.SetError(Me.txtBankAccountCo, "Use Only Numbers without '-' or other characters")
        '    End If
        'End If
        If Me.ComboProFund.Text = "" Then
            Flag = False
            Me.ErrProvFund.SetError(Me.ComboProFund, "Field is Required")
        End If
        If Me.ComboMedicalFund.Text = "" Then
            Flag = False
            Me.ErrMedFund.SetError(Me.ComboMedicalFund, "Field is Required")
        End If
        If Me.ComboSocialIns.Text = "" Then
            Flag = False
            Me.ErrSocialInsurance.SetError(Me.ComboSocialIns, "Field is Required")
        End If
        If Me.txtTerminateDate.Text <> "" Then
            Try
                Dim mDate As Date
                mDate = CDate(Me.txtTerminateDate.Text)
            Catch ex As Exception
                Flag = False
                MsgBox("Termination date Format is False!Format mus be yyyy/mm/dd, for example 2009/04/26.Please Correct!", MsgBoxStyle.Critical)
            End Try
        End If
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrMsEmployees As New cPrMsEmployees(Trim(Me.txtCode.Text))
                    If tPrMsEmployees.Code <> "" Then
                        MsgBox("Employee already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtCode.Text = ""
        'Me.mnuDiscounts.Enabled = False
        'Me.btnEmployeeSalary.Enabled = False
        Me.txtRehiredCode.Text = ""
        Me.txtCNPCode.Text = ""
        Me.txtTACode.Text = ""
        Me.txtHRCode.Text = ""

        Me.ComboHireReason.SelectedIndex = 0
        Me.ComboTermReason.SelectedIndex = 0

        CBLWBPen.Checked = False
        CBIsDirector.Checked = False
        CBOnMaternity.Checked = False
        Me.ComboStatus.SelectedIndex = 0
        Try
            Me.cmbPayTyp_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbTemGrp_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpSta_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtTitle.Text = ""
        Me.txtLastName.Text = ""
        Me.txtFirstName.Text = ""
        Me.txtFullName.Text = ""
        Try
            Me.cmbSex.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.DateBirth.Value = Now.Date
        Try
            Me.cmbMarSta_Code.SelectedIndex = 2
        Catch ex As Exception
        End Try
        Me.txtAddress1.Text = ""
        Me.txtAddress2.Text = ""
        Me.txtAddress3.Text = ""
        Me.txtPostCode.Text = ""
        Me.txtTelephone1.Text = ""
        Me.txtTelephone2.Text = ""
        Me.txtEmail.Text = ""
        Me.txtEmail2.Text = ""
        Me.txtSocialInsNumber.Text = ""
        Me.txtComSin_EmpSocialInsNo.Text = ""
        Me.txtIdentificationCard.Text = ""
        Me.txtTaxId.Text = ""
        Me.txtPassportNumber.Text = ""
        Me.txtAlienNumber.Text = ""
        Me.txtBankBenName.Text = ""
        Try
            Me.cmbTaxCardType.SelectedIndex = 0
        Catch ex As Exception

        End Try
        Try
            Me.cmbEmpAn1_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpAn2_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpAn3_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpAn4_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpAn5_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbUni_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbCou_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpPos_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbSic_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbEmpCmm_Code.SelectedIndex = 2
        Catch ex As Exception
        End Try
        Try
            Me.cmbPayUni_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtPeriodUnits.Text = "0"
        Me.txtAnnualUnits.Text = "0"
        Try
            Me.cmbCur_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbPmtMth_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            Me.cmbBnk_Code.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtBankAccount.Text = ""
        Try
            Me.cmbBnk_CodeCo.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboSectorPay.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboCommissionRates.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboPerformanceBonus.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboDutyHours.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboOverLay.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            Me.ComboFlightHours.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Me.txtBankAccountCo.Text = ""
        Me.DateStart.Value = Now.Date
        Me.txtTerminateDate.Text = ""
        Me.txtOtherIncome1.Text = "0.00"
        Me.txtOtherIncome2.Text = "0.00"
        Me.txtOtherIncome3.Text = "0.00"

        Me.txtAgreedSalary.Text = "0.00"
        Me.txtExtraBonusOnSalary.Text = "0.00"
        Me.txtTaxForSplit.Text = "0.00"

        Me.txtPreviousEarnings.Text = "0.00"
        Me.txtPrevInsurableforGESY.Text = "0.00"
        Me.txtEmp_PrevSIDeduct.Text = "0.00"
        Me.txtEmp_PrevSIContribute.Text = "0.00"
        Me.txtEmp_PrevITDeduct.Text = "0.00"
        Me.txtEmp_PrevPFDeduct.Text = "0.00"
        Me.DateCreated.Value = Now.Date
        Me.txtPayslipreport.Text = ""
        Me.txtEmployeeIBAN.Text = ""


        Me.txtPreviousDis.Text = "0.00"
        Me.txtPreviousLF.Text = "0.00"

        Me.txtPreviousST.Text = "0.00"

        Me.txtPreviusMF.Text = "0.00"
        Me.txtPreviusPenF.Text = "0.00"

        Me.txtOtherIncome4.Text = "0.00"

        Me.txtFullPassportName.Text = ""
        Me.txtTravelDocs.Text = ""
        Me.CBFirstEmployment.CheckState = CheckState.Unchecked
        Me.txtFEControlAmount.Text = "0.00"
        Me.CBForce50Percent.CheckState = CheckState.Unchecked
        Me.CBLimitTo20.CheckState = CheckState.Unchecked

        Me.txtNotes.Text = ""
        Me.txtBankBenName.Text = ""
        Me.txtPensionNo.Text = ""

        Me.txtPrevGesiD.Text = "0.00"
        Me.txtPrevGesiC.Text = "0.00"
        Me.txtNameDay.Text = ""
        Me.txtAnalGen1.Text = ""

        txtAnnualGesyFromSplit.Text = "0.00"

        Me.txtGLAnal1.Text = 0
        Me.txtGLAnal2.Text = 0
        Me.txtGLAnal3.Text = 0
        Me.txtGLAnal4.Text = 0
        Me.txtOhterCountryTIC.Text = ""

        EmpPhoto.Image = My.Resources.photo
        Try
            Me.cmbCreatedBy.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.DateAmend.Value = Now.Date
        Try
            Me.cmbAmendBy.SelectedIndex = 0
        Catch ex As Exception
        End Try
        ClearEDC()
    End Sub
    Private Sub ClearEDC()
        Dim i As Integer
        Dim Ds As DataSet
        Dim TempCode As String = ""
        'Earnings
        For i = 0 To Me.Ern.Length - 1
            Ern(i).ClearMe()
        Next
        TempCode = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code

        Ds = Global1.Business.GetAllPrMsTemplateEarnings(TempCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim E As New cPrMsTemplateEarnings(Ds.Tables(0).Rows(i))
                Ern(i).Ern = E
                Ern(i).LoadME()
            Next
        End If
        'Deductions
        For i = 0 To Me.Ded.Length - 1
            Ded(i).ClearMe()
        Next
        Ds = Global1.Business.GetAllPrMsTemplateDeductions(TempCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim D As New cPrMsTemplateDeductions(Ds.Tables(0).Rows(i))
                Ded(i).Ded = D
                Ded(i).LoadMe()
            Next
        End If
        'Contributions
        For i = 0 To Me.Con.Length - 1
            Con(i).ClearMe()
        Next
        Ds = Global1.Business.GetAllPrMsTemplateContributions(TempCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim C As New cPrMsTemplateContributions(Ds.Tables(0).Rows(i))
                Con(i).Con = C
                Con(i).LoadMe()
            Next
        End If
    End Sub
    '
    Private Sub LoadCombos()
        LoadPrSsEmployeeStatus()
        LoadPrSsPayrollTypes()
        LoadPrMsTemplateGroup()
        LoadPrAnEmploymentStatus()
        LoadPrAnMarritalStatus()
        LoadPrAnEmployeeAnalysis1()
        LoadPrAnEmployeeAnalysis2()
        LoadPrAnEmployeeAnalysis3()
        LoadPrAnEmployeeAnalysis4()
        LoadPrAnEmployeeAnalysis5()
        LoadPrAnUnions()
        LoadAdAnCountries()
        LoadPrAnEmployeePositions()
        LoadPrAnSocialInsCategories()
        LoadPrAnEmployeeCommunity()
        LoadPrSsPayrollUnits()
        LoadAdMsCurrency_Cur_Code()
        LoadPrAnPaymentMethods()
        LoadPrAnBanks()
        LoadPrAnBanks_Bnk_CodeCo()
        LoadPrAnTaxCardType()
        LoadAaSsUsers_Emp_CreatedBy()
        LoadAaSsUsers_Emp_AmendBy()
        LoadSex()
        LoadProvidentFund()
        LoadMedicalFund()
        LoadSocialInsurance()
        LoadIndustrial()
        LoadUnemployment()
        LoadSocialCohesion()
        LoadPensionTypes()
        'Airlines
        loadSectorPay()
        LoadcommissionRates()
        LoadPerformanceBonus()
        LoadDutyHours()
        LoadFlightHours()
        LoadOverLay()
        LoadGesi()


    End Sub
    Private Sub LoadPrSsEmployeeStatus()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsEmployeeStatus()
        If CheckDataSet(ds) Then
            Dim tPrSsEmpStatus As New cPrSsEmployeeStatus
            With Me.ComboStatus
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsEmpStatus = New cPrSsEmployeeStatus(ds.Tables(0).Rows(i))
                    .Items.Add(tPrSsEmpStatus)
                Next i
                '   .ValueMember = "PayTyp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    '
    Private Sub LoadPrSsPayrollTypes()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsPayrollTypes()
        If CheckDataSet(ds) Then
            Dim tPrSsPayrollTypes As New cPrSsPayrollTypes
            With Me.cmbPayTyp_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsPayrollTypes = New cPrSsPayrollTypes(ds.Tables(0).Rows(i))
                    .Items.Add(tPrSsPayrollTypes)
                Next i
                '   .ValueMember = "PayTyp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrMsTemplateGroup()

        Dim i As Integer
        'ds = Global1.Business.AG_GetAllPrMsTemplateGroup()
        dsTemplateGroups = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        If CheckDataSet(dsTemplateGroups) Then
            Dim tPrMsTemplateGroup As New cPrMsTemplateGroup
            With Me.cmbTemGrp_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To DsTemplateGroups.Tables(0).Rows.Count - 1
                    tPrMsTemplateGroup = New cPrMsTemplateGroup(DsTemplateGroups.Tables(0).Rows(i))
                    .Items.Add(tPrMsTemplateGroup)
                Next i
                '  .ValueMember = "TemGrp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrMsInterfaceTemplate(ByVal TemGrp As cPrMsTemplateGroup)
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemGrp.Code)
        If CheckDataSet(ds) Then
            Dim tPrMsInterfaceTemplate As New cPrMsInterfaceTemplate
            'Interface Template
            With Me.cmbIntTem_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'Provident Fund
            With Me.cmbIntPF
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'Medical Fund
            With Me.cmbIntMF
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'D/C    Accounts
            'With Me.cmbIntAC
            '    .BeginUpdate()
            '    .Items.Clear()
            '    For i = 0 To ds.Tables(0).Rows.Count - 1
            '        tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
            '        .Items.Add(tPrMsInterfaceTemplate)
            '    Next i
            '    .SelectedIndex = 0
            '    .EndUpdate()
            'End With

        End If
    End Sub
    Private Sub LoadPrAnEmploymentStatus()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmploymentStatus()
        If CheckDataSet(ds) Then
            Dim tPrAnEmploymentStatus As New cPrAnEmploymentStatus
            With Me.cmbEmpSta_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmploymentStatus = New cPrAnEmploymentStatus(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmploymentStatus)
                Next i
                '.ValueMember = "EmpSta_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnMarritalStatus()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnMarritalStatus()
        If CheckDataSet(ds) Then
            Dim tPrAnMarritalStatus As New cPrAnMarritalStatus
            With Me.cmbMarSta_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnMarritalStatus = New cPrAnMarritalStatus(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnMarritalStatus)
                Next i
                ' .ValueMember = "MarSta_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis1()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis1 As New cPrAnEmployeeAnalysis1
            With Me.cmbEmpAn1_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis1 = New cPrAnEmployeeAnalysis1(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis1)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis2()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis2 As New cPrAnEmployeeAnalysis2
            With Me.cmbEmpAn2_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis2 = New cPrAnEmployeeAnalysis2(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis2)
                Next i
                ' .ValueMember = "EmpAn2_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis3()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis3 As New cPrAnEmployeeAnalysis3
            With Me.cmbEmpAn3_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis3 = New cPrAnEmployeeAnalysis3(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis3)
                Next i
                '.ValueMember = "EmpAn3_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis4()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis4 As New cPrAnEmployeeAnalysis4
            With Me.cmbEmpAn4_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis4 = New cPrAnEmployeeAnalysis4(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis4)
                Next i
                '.ValueMember = "EmpAn4_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis5()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis5 As New cPrAnEmployeeAnalysis5
            With Me.cmbEmpAn5_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis5 = New cPrAnEmployeeAnalysis5(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis5)
                Next i
                ' .ValueMember = "EmpAn5_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnUnions()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnUnions()
        If CheckDataSet(ds) Then
            Dim tPrAnUnions As New cPrAnUnions
            With Me.cmbUni_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnUnions = New cPrAnUnions(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnUnions)
                Next i
                '  .ValueMember = "Uni_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAdAnCountries()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAdAnCountries()
        If CheckDataSet(ds) Then
            Dim tAdAnCountries As New cAdAnCountries
            With Me.cmbCou_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAdAnCountries = New cAdAnCountries(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAdAnCountries)
                Next i
                '  .ValueMember = "Cou_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeePositions()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeePositions(True)
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeePositions As New cPrAnEmployeePositions
            With Me.cmbEmpPos_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeePositions = New cPrAnEmployeePositions(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnEmployeePositions)
                Next i
                '.ValueMember = "EmpPos_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnSocialInsCategories()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnSocialInsCategories()
        If CheckDataSet(ds) Then
            Dim tPrAnSocialInsCategories As New cPrAnSocialInsCategories
            With Me.cmbSic_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnSocialInsCategories = New cPrAnSocialInsCategories(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnSocialInsCategories)
                Next i
                '.ValueMember = "Sic_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeCommunity()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeCommunity As New cPrAnEmployeeCommunity
            With Me.cmbEmpCmm_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeCommunity = New cPrAnEmployeeCommunity(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnEmployeeCommunity)
                Next i
                ' .ValueMember = "EmpCmm_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrSsPayrollUnits()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsPayrollUnits()
        If CheckDataSet(ds) Then
            Dim tPrSsPayrollUnits As New cPrSsPayrollUnits
            With Me.cmbPayUni_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsPayrollUnits = New cPrSsPayrollUnits(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsPayrollUnits)
                Next i
                '  .ValueMember = "PayUni_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAdMsCurrency_Cur_Code()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAdMsCurrency()
        If CheckDataSet(ds) Then
            Dim tAdMsCurrency As New cAdMsCurrency
            With Me.cmbCur_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAdMsCurrency = New cAdMsCurrency(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAdMsCurrency)
                Next i
                '  .ValueMember = "Cur_AlphaCode"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnPaymentMethods()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnPaymentMethods()
        If CheckDataSet(ds) Then
            Dim tPrAnPaymentMethods As New cPrAnPaymentMethods
            With Me.cmbPmtMth_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnPaymentMethods = New cPrAnPaymentMethods(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnPaymentMethods)
                Next i
                '   .ValueMember = "PmtMth_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnBanks()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.cmbBnk_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                Next i
                '   .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnBanks_Bnk_CodeCo()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.cmbBnk_CodeCo
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnTaxCardType()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllActivePrAnTaxCardType()
        If CheckDataSet(ds) Then
            Dim tPrAnTaxCardType As New cPrAnTaxCardType
            With Me.cmbTaxCardType
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnTaxCardType = New cPrAnTaxCardType(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnTaxCardType)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadSex()
        With Me.cmbSex
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("M - Male")
            .Items.Add("F - Female")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadProvidentFund()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsProvidentFund()
        If CheckDataSet(ds) Then
            Dim tPrSsProvidentFund As New cPrSsProvidentFund
            With Me.ComboProFund
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsProvidentFund = New cPrSsProvidentFund(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsProvidentFund)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadMedicalFund()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsMedicalFund()
        If CheckDataSet(ds) Then
            Dim tPrSsMedicalFund As New cPrSsMedicalFund
            With Me.ComboMedicalFund
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsMedicalFund = New cPrSsMedicalFund(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsMedicalFund)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadSocialInsurance()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSocialInsurance()
        If CheckDataSet(ds) Then
            Dim tPrSsSocialInsurance As New cPrSsSocialInsurance
            With Me.ComboSocialIns
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsSocialInsurance = New cPrSsSocialInsurance(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsSocialInsurance)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadIndustrial()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsIndustrial()
        If CheckDataSet(ds) Then
            Dim tPrSsIndustrial As New cPrSsIndustrial
            With Me.ComboIndustrial
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsIndustrial = New cPrSsIndustrial(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsIndustrial)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadGesi()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrSsGesi()
        If CheckDataSet(ds) Then
            Dim tPrSsGesi As New cPrSsGesi
            With Me.ComboGESI
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsGesi = New cPrSsGesi(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsGesi)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadUnemployment()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsUnemployment()
        If CheckDataSet(ds) Then
            Dim tPrSsUnemployment As New cPrSsUnemployment
            With Me.ComboUnemployment
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsUnemployment = New cPrSsUnemployment(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsUnemployment)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadSocialCohesion()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSocialCohesion()
        If CheckDataSet(ds) Then
            Dim tPrSsSocialCohesion As New cPrSsSocialCohesion
            With Me.ComboSocialCohesion
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsSocialCohesion = New cPrSsSocialCohesion(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsSocialCohesion)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAaSsUsers_Emp_CreatedBy()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.cmbCreatedBy
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAaSsUsers = New cAaSsUsers(DbNullToInt(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAaSsUsers)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAaSsUsers_Emp_AmendBy()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.cmbAmendBy
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAaSsUsers = New cAaSsUsers(DbNullToInt(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAaSsUsers)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPensionTypes()
        With Me.ComboPensionType
            .BeginUpdate()
            .Items.Add("0 - Not Applicable")
            .Items.Add("1 - Normal Pension")
            .Items.Add("2 - Widow Pension")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub loadSectorPay()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSectorPay()
        If CheckDataSet(ds) Then
            Dim tPrSsSectorPay As New cPrSsSectorPay
            With Me.ComboSectorPay
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsSectorPay = New cPrSsSectorPay(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsSectorPay)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadcommissionRates()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsCommissionRates()
        If CheckDataSet(ds) Then
            Dim tPrSsCommissionRates As New cPrSsCommissionRates
            With Me.ComboCommissionRates
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsCommissionRates = New cPrSsCommissionRates(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsCommissionRates)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPerformanceBonus()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsPerformanceBonus
        If CheckDataSet(ds) Then
            Dim tPrSsPerformanceBonus As New cPrSsPerformanceBonus
            With Me.ComboPerformanceBonus
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsPerformanceBonus = New cPrSsPerformanceBonus(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsPerformanceBonus)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadDutyHours()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsDutyHours
        If CheckDataSet(ds) Then
            Dim tPrSsDutyHours As New cPrSsDutyHours
            With Me.ComboDutyHours
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsDutyHours = New cPrSsDutyHours(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsDutyHours)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadOverLay()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsOverLay
        If CheckDataSet(ds) Then
            Dim tPrSsOverlay As New cPrSsOverLay
            With Me.ComboOverLay
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsOverlay = New cPrSsOverLay(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsOverlay)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadFlightHours()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsFlightHour
        If CheckDataSet(ds) Then
            Dim tPrSsflightHours As New cPrSsFlightHours
            With Me.ComboFlightHours
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsflightHours = New cPrSsFlightHours(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsflightHours)
                Next i
                '  .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If

    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtOtherIncome1.KeyPress, AddressOf NumericKeyPress
        AddHandler txtOtherIncome1.Leave, AddressOf NumericOnLeave
        AddHandler txtOtherIncome2.KeyPress, AddressOf NumericKeyPress
        AddHandler txtOtherIncome2.Leave, AddressOf NumericOnLeave
        AddHandler txtOtherIncome3.KeyPress, AddressOf NumericKeyPress
        AddHandler txtOtherIncome3.Leave, AddressOf NumericOnLeave
        AddHandler txtPreviousEarnings.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPreviousEarnings.Leave, AddressOf NumericOnLeave

        AddHandler txtPrevInsurableforGESY.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPrevInsurableforGESY.Leave, AddressOf NumericOnLeave

        AddHandler txtEmp_PrevSIDeduct.KeyPress, AddressOf NumericKeyPress
        AddHandler txtEmp_PrevSIDeduct.Leave, AddressOf NumericOnLeave
        AddHandler txtEmp_PrevSIContribute.KeyPress, AddressOf NumericKeyPress
        AddHandler txtEmp_PrevSIContribute.Leave, AddressOf NumericOnLeave
        AddHandler txtEmp_PrevITDeduct.KeyPress, AddressOf NumericKeyPress
        AddHandler txtEmp_PrevITDeduct.Leave, AddressOf NumericOnLeave
        AddHandler txtEmp_PrevPFDeduct.KeyPress, AddressOf NumericKeyPress
        AddHandler txtEmp_PrevPFDeduct.Leave, AddressOf NumericOnLeave

        AddHandler txtPrevGesiD.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPrevGesiD.Leave, AddressOf NumericOnLeave

        AddHandler txtPrevGesiC.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPrevGesiC.Leave, AddressOf NumericOnLeave

        AddHandler txtAgreedSalary.KeyPress, AddressOf NumericKeyPress
        AddHandler txtAgreedSalary.Leave, AddressOf NumericOnLeave

        AddHandler txtExtraBonusOnSalary.KeyPress, AddressOf NumericKeyPress
        AddHandler txtExtraBonusOnSalary.Leave, AddressOf NumericOnLeave

        AddHandler txtTaxForSplit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTaxForSplit.Leave, AddressOf NumericOnLeave

        AddHandler txtAnnualGesyFromSplit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtAnnualGesyFromSplit.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        'Me.ErrStatus.SetError(Me.txtStatus, "")
        Me.ErrPayTyp_Code.SetError(Me.cmbPayTyp_Code, "")
        Me.ErrTemGrp_Code.SetError(Me.cmbTemGrp_Code, "")
        Me.ErrEmpSta_Code.SetError(Me.cmbEmpSta_Code, "")
        Me.ErrTitle.SetError(Me.txtTitle, "")
        Me.ErrLastName.SetError(Me.txtLastName, "")
        Me.ErrFirstName.SetError(Me.txtFirstName, "")
        Me.ErrFullName.SetError(Me.txtFullName, "")
        Me.ErrSex.SetError(Me.cmbSex, "")
        'Me.ErrBirthDate.SetError(Me.txtBirthDate, "")
        Me.ErrMarSta_Code.SetError(Me.cmbMarSta_Code, "")
        Me.ErrAddress1.SetError(Me.txtAddress1, "")
        Me.ErrAddress2.SetError(Me.txtAddress2, "")
        Me.ErrAddress3.SetError(Me.txtAddress3, "")
        Me.ErrPostCode.SetError(Me.txtPostCode, "")
        Me.ErrTelephone1.SetError(Me.txtTelephone1, "")
        Me.ErrTelephone2.SetError(Me.txtTelephone2, "")
        Me.ErrEmail.SetError(Me.txtEmail, "")
        Me.ErrSocialInsNumber.SetError(Me.txtSocialInsNumber, "")
        Me.ErrComSin_EmpSocialInsNo.SetError(Me.txtComSin_EmpSocialInsNo, "")
        Me.ErrIdentificationCard.SetError(Me.txtIdentificationCard, "")
        Me.ErrTaxID.SetError(Me.txtTaxId, "")
        Me.ErrPassportNumber.SetError(Me.txtPassportNumber, "")
        Me.ErrAlienNumber.SetError(Me.txtAlienNumber, "")
        Me.ErrTicTyp_Code.SetError(Me.cmbTaxCardType, "")
        Me.ErrEmpAn1_Code.SetError(Me.cmbEmpAn1_Code, "")
        Me.ErrEmpAn2_Code.SetError(Me.cmbEmpAn2_Code, "")
        Me.ErrEmpAn3_Code.SetError(Me.cmbEmpAn3_Code, "")
        Me.ErrEmpAn4_Code.SetError(Me.cmbEmpAn4_Code, "")
        Me.ErrEmpAn5_Code.SetError(Me.cmbEmpAn5_Code, "")
        Me.ErrUni_Code.SetError(Me.cmbUni_Code, "")
        Me.ErrCou_Code.SetError(Me.cmbCou_Code, "")
        Me.ErrEmpPos_Code.SetError(Me.cmbEmpPos_Code, "")
        Me.ErrSic_Code.SetError(Me.cmbSic_Code, "")
        Me.ErrEmpCmm_Code.SetError(Me.cmbEmpCmm_Code, "")
        Me.ErrPayUni_Code.SetError(Me.cmbPayUni_Code, "")
        Me.ErrPeriodUnits.SetError(Me.txtPeriodUnits, "")
        Me.ErrAnnualUnits.SetError(Me.txtAnnualUnits, "")
        Me.ErrCur_Code.SetError(Me.cmbCur_Code, "")
        Me.ErrPmtMth_Code.SetError(Me.cmbPmtMth_Code, "")
        Me.ErrBnk_Code.SetError(Me.cmbBnk_Code, "")
        Me.ErrBankAccount.SetError(Me.txtBankAccount, "")
        Me.ErrBnk_CodeCo.SetError(Me.cmbBnk_CodeCo, "")
        Me.ErrBankAccountCo.SetError(Me.txtBankAccountCo, "")
        Me.ErrStartDate.SetError(Me.DateStart, "")
        Me.ErrTerminateDate.SetError(Me.txtTerminateDate, "")
        Me.ErrOtherIncome1.SetError(Me.txtOtherIncome1, "")
        Me.ErrOtherIncome2.SetError(Me.txtOtherIncome2, "")
        Me.ErrOtherIncome3.SetError(Me.txtOtherIncome3, "")
        Me.ErrPreviousEarnings.SetError(Me.txtPreviousEarnings, "")
        Me.ErrEmp_PrevSIDeduct.SetError(Me.txtEmp_PrevSIDeduct, "")
        Me.ErrEmp_PrevSIContribute.SetError(Me.txtEmp_PrevSIContribute, "")
        Me.ErrEmp_PrevITDeduct.SetError(Me.txtEmp_PrevITDeduct, "")
        Me.ErrEmp_PrevPFDeduct.SetError(Me.txtEmp_PrevPFDeduct, "")
        Me.ErrProvFund.SetError(Me.ComboProFund, "")
        Me.ErrMedFund.SetError(Me.ComboMedicalFund, "")
        Me.ErrSocialInsurance.SetError(Me.ComboSocialIns, "")
        'Me.ErrCreationDate.SetError(Me.txtCreationDate, "")
        Me.ErrCreatedBy.SetError(Me.cmbCreatedBy, "")
        'Me.ErrAmendDate.SetError(Me.txtAmendDate, "")
        Me.ErrAmendBy.SetError(Me.cmbAmendBy, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        NewClick()
    End Sub
    Private Sub NewClick()

        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsEmployees = New cPrMsEmployees
        GlbEmp = New cPrMsEmployees
        ClearMe()
        ClearErrors()
        Me.btnFindNextAvailable.Enabled = True
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtCode.Focus()
        Me.Cursor = Cursors.Default

        Me.LblHeaderStatus.Text = "A - Active"

        Me.LblHeaderStatus.ForeColor = Color.DodgerBlue
        


    End Sub
    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Me.TSBSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        TryToSave()
        If Global1.PARAM_warningonSIR Then
            If Me.txtComSin_EmpSocialInsNo.Text = "" Then
                If Me.txtTaxId.Text <> "?" Then
                    MsgBox("WARNING , Please fill in Company Social Insurance registration Number", MsgBoxStyle.Information)
                End If
            End If
        End If

        Me.TSBSave.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TryToSave(Optional ByVal ShowMsg As Boolean = True)
        If ValidateMe() Then
            Dim Update As Boolean = False
            'Dim CS As Integer
            Dim Exx As New Exception
            Dim S As String
            Dim Ar() As String
            Try
                Global1.Business.BeginTransaction()
                tPrMsEmployees = New cPrMsEmployees(Me.txtCode.Text)
                If Me.txtCode.ReadOnly Then
                    Update = True
                Else
                    Update = False
                End If

                If tPrMsEmployees.EmpPos_Code <> CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).Code Then
                    Dim PosHis As New cPrTxPositionHistory
                    PosHis.EmpCode = Me.txtCode.Text
                    PosHis.PosCode = CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).Code
                    PosHis.PosDesc = CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).DescriptionL
                    PosHis.PosDate = Now.Date
                    If Not PosHis.Save Then
                        Throw Exx
                    End If
                End If

                If tPrMsEmployees.StartDate <> Me.DateStart.Value.Date Or tPrMsEmployees.TerminateDate <> Me.txtTerminateDate.Text Then
                    Dim EmpHis As New cEmploymentHistory
                    EmpHis.EmpCode = Me.txtCode.Text
                    EmpHis.StartDate = Me.DateStart.Value.Date
                    If Me.txtTerminateDate.Text = "" Then
                        EmpHis.EndDate = CDate("1900-01-01")
                    Else
                        EmpHis.EndDate = Me.txtTerminateDate.Text
                    End If
                    If Not EmpHis.Save Then
                        Throw Exx
                    End If
                End If
                If Update Then
                    If tPrMsEmployees.EmpSta_Code = "A" Then
                        If CType(Me.cmbEmpSta_Code.SelectedItem, cPrAnEmploymentStatus).Code = "I" Then
                            If Global1.Business.CheckforCalcPayslipsForEmployee(tPrMsEmployees.Code) Then
                                MsgBox("This Employee has a Payroll in 'CALC' mode, cannot set Employee Innactive, POST or Delete Payroll", MsgBoxStyle.Exclamation)
                                Cursor.Current = Cursors.Default
                                Exit Sub
                            End If
                        End If
                    End If
                End If



                With tPrMsEmployees
                    .Code = CStr(Me.txtCode.Text)
                    .Status = CType(Me.ComboStatus.SelectedItem, cPrSsEmployeeStatus).EmpSta_Code
                    .PayTyp_Code = CType(Me.cmbPayTyp_Code.SelectedItem, cPrSsPayrollTypes).Code
                    .TemGrp_Code = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code

                    .EmpSta_Code = CType(Me.cmbEmpSta_Code.SelectedItem, cPrAnEmploymentStatus).Code

                    .Title = CStr(Me.txtTitle.Text)
                    .LastName = CStr(Me.txtLastName.Text)
                    .FirstName = CStr(Me.txtFirstName.Text)
                    .FullName = CStr(Me.txtFullName.Text)
                    S = Me.cmbSex.Text
                    Ar = S.Split("-")
                    .Sex = Trim(Ar(0))
                    .BirthDate = DateBirth.Value.Date
                    .MarSta_Code = CType(Me.cmbMarSta_Code.SelectedItem, cPrAnMarritalStatus).Code
                    .Address1 = CStr(Me.txtAddress1.Text)
                    .Address2 = CStr(Me.txtAddress2.Text)
                    .Address3 = CStr(Me.txtAddress3.Text)
                    .PostCode = CStr(Me.txtPostCode.Text)
                    .Telephone1 = CStr(Me.txtTelephone1.Text)
                    .Telephone2 = CStr(Me.txtTelephone2.Text)
                    .Email = CStr(Me.txtEmail.Text)
                    .Email2 = CStr(Me.txtEmail2.Text)
                    .SocialInsNumber = CStr(Me.txtSocialInsNumber.Text)
                    .ComSin_EmpSocialInsNo = CStr(Me.txtComSin_EmpSocialInsNo.Text)
                    .IdentificationCard = CStr(Me.txtIdentificationCard.Text)
                    .TaxID = CStr(Me.txtTaxId.Text)
                    .PassportNumber = CStr(Me.txtPassportNumber.Text)
                    .AlienNumber = CStr(Me.txtAlienNumber.Text)
                    .TicTyp_Code = CType(Me.cmbTaxCardType.SelectedItem, cPrAnTaxCardType).Code
                    .Rehire = Me.txtRehiredCode.Text

                    .CNPCode = Me.txtCNPCode.Text
                    .TACode = Me.txtTACode.Text
                    .HRCode = Me.txtHRCode.Text

                    .TermReason = GetFirstfromcombo(Me.ComboTermReason.Text)
                    .HireReason = GetFirstfromcombo(Me.ComboHireReason.Text)

                    .EmpAn1_Code = CType(Me.cmbEmpAn1_Code.SelectedItem, cPrAnEmployeeAnalysis1).Code
                    .EmpAn2_Code = CType(Me.cmbEmpAn2_Code.SelectedItem, cPrAnEmployeeAnalysis2).Code
                    .EmpAn3_Code = CType(Me.cmbEmpAn3_Code.SelectedItem, cPrAnEmployeeAnalysis3).Code
                    .EmpAn4_Code = CType(Me.cmbEmpAn4_Code.SelectedItem, cPrAnEmployeeAnalysis4).Code
                    .EmpAn5_Code = CType(Me.cmbEmpAn5_Code.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                    .Uni_Code = CType(Me.cmbUni_Code.SelectedItem, cPrAnUnions).Code
                    .Cou_Code = CType(Me.cmbCou_Code.SelectedItem, cAdAnCountries).Code
                    .EmpPos_Code = CType(Me.cmbEmpPos_Code.SelectedItem, cPrAnEmployeePositions).Code
                    .Sic_Code = CType(Me.cmbSic_Code.SelectedItem, cPrAnSocialInsCategories).Code
                    .EmpCmm_Code = CType(Me.cmbEmpCmm_Code.SelectedItem, cPrAnEmployeeCommunity).Code
                    .PayUni_Code = CType(Me.cmbPayUni_Code.SelectedItem, cPrSsPayrollUnits).Code
                    .PeriodUnits = CDbl(Me.txtPeriodUnits.Text)
                    .AnnualUnits = CDbl(Me.txtAnnualUnits.Text)
                    .Cur_Code = CType(Me.cmbCur_Code.SelectedItem, cAdMsCurrency).AlphaCode
                    .PmtMth_Code = CType(Me.cmbPmtMth_Code.SelectedItem, cPrAnPaymentMethods).Code
                    .Bnk_Code = CType(Me.cmbBnk_Code.SelectedItem, cPrAnBanks).Code
                    .BankAccount = CStr(Me.txtBankAccount.Text)
                    .Bnk_CodeCo = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks).Code
                    .BankAccountCo = CStr(Me.txtBankAccountCo.Text)
                    .StartDate = Me.DateStart.Value.Date
                    .TerminateDate = CStr(Me.txtTerminateDate.Text)
                    .OtherIncome1 = CDbl(Me.txtOtherIncome1.Text)
                    .OtherIncome2 = CDbl(Me.txtOtherIncome2.Text)
                    .OtherIncome3 = CDbl(Me.txtOtherIncome3.Text)
                    .PreviousEarnings = CDbl(Me.txtPreviousEarnings.Text)

                    ' .previousInsurableforGESY = CDbl(Me.txtPrevInsurableforGESY.Text)

                    .Emp_PrevSIDeduct = CDbl(Me.txtEmp_PrevSIDeduct.Text)
                    .Emp_PrevSIContribute = CDbl(Me.txtEmp_PrevSIContribute.Text)
                    .Emp_PrevITDeduct = CDbl(Me.txtEmp_PrevITDeduct.Text)
                    .Emp_PrevPFDeduct = CDbl(Me.txtEmp_PrevPFDeduct.Text)

                    If Me.CBLWBPen.CheckState = CheckState.Checked Then
                        .LWBPen = "1"
                    Else
                        .LWBPen = "0"
                    End If

                    If Me.CBIsDirector.CheckState = CheckState.Checked Then
                        .IsDirector = "1"
                    Else
                        .IsDirector = "0"
                    End If
                    If Me.CBOnMaternity.CheckState = CheckState.Checked Then
                        .Maternity = "1"
                    Else
                        .Maternity = "0"
                    End If

                    .ProFnd_Code = CType(Me.ComboProFund.SelectedItem, cPrSsProvidentFund).Code
                    .MedFnd_Code = CType(Me.ComboMedicalFund.SelectedItem, cPrSsMedicalFund).Code
                    .SocInc_Code = CType(Me.ComboSocialIns.SelectedItem, cPrSsSocialInsurance).Code

                    .Ind_Code = CType(Me.ComboIndustrial.SelectedItem, cPrSsIndustrial).Code
                    .Une_Code = CType(Me.ComboUnemployment.SelectedItem, cPrSsUnemployment).Code
                    .SocCoh_Code = CType(Me.ComboSocialCohesion.SelectedItem, cPrSsSocialCohesion).Code
                    .GESICode = CType(Me.ComboGESI.SelectedItem, cPrSsGesi).Code


                    .InterfaceTemCode = CType(Me.cmbIntTem_Code.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                    .InterfacePFCode = CType(Me.cmbIntPF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                    .InterfaceMFCode = CType(Me.cmbIntMF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                    '.InterfaceACCode = CType(Me.cmbIntAC.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
                    .DrivingLicense = Me.txtOhterCountryTIC.Text
                    .PensionNo = Me.txtPensionNo.Text
                    .MyPayslipReport = Me.txtPayslipreport.Text
                    .IBAN = Me.txtEmployeeIBAN.Text
                    .PreviousLifeIns = Me.txtPreviousLF.Text
                    .PreviousDis = Me.txtPreviousDis.Text
                    .PreviousST = Me.txtPreviousST.Text

                    .PreviousGesiD = Me.txtPrevGesiD.Text
                    .PreviousGesiC = Me.txtPrevGesiC.Text

                    .PrevMedFund = Me.txtPreviusMF.Text
                    .PrevPensionFund = Me.txtPreviusPenF.Text

                    .OtherIncome4 = Me.txtOtherIncome4.Text

                    .SectorPay = CType(Me.ComboSectorPay.SelectedItem, cPrSsSectorPay).Code
                    .CommissionRate = CType(Me.ComboCommissionRates.SelectedItem, cPrSsCommissionRates).Code
                    .PerformanceBonus = CType(Me.ComboPerformanceBonus.SelectedItem, cPrSsPerformanceBonus).Code
                    .DutyHours = CType(Me.ComboDutyHours.SelectedItem, cPrSsDutyHours).Code
                    .OverLay = CType(Me.ComboOverLay.SelectedItem, cPrSsOverLay).Code
                    .FlightHours = CType(Me.ComboFlightHours.SelectedItem, cPrSsFlightHours).Code

                    .FullPassName = Me.txtFullPassportName.Text
                    .Traveldocs = Me.txtTravelDocs.Text

                    If Me.CBFirstEmployment.CheckState = CheckState.Checked Then
                        .FirstEmployment = "1"
                    Else
                        .FirstEmployment = "0"
                    End If

                    .FEControlAmount = CDbl(Me.txtFEControlAmount.Text)

                    If Me.CBForce50Percent.CheckState = CheckState.Checked Then
                        .Force50Percent = "1"
                    Else
                        .Force50Percent = "0"
                    End If

                    If Me.CBLimitTo20.CheckState = CheckState.Checked Then
                        .f50PercOff = "1"
                    Else
                        .f50PercOff = "0"
                    End If

                    If Me.CBIsSI.CheckState = CheckState.Checked Then
                        .IsSI = 1
                    Else
                        .IsSI = 0
                    End If

                    .Emp_GLAnal1 = Me.txtGLAnal1.Text
                    .Emp_GLAnal2 = Me.txtGLAnal2.Text
                    .Emp_GLAnal3 = Me.txtGLAnal3.Text
                    .Emp_GLAnal4 = Me.txtGLAnal4.Text
                    .AnalGen1 = Me.txtAnalGen1.Text
                    .NameDay = Me.txtNameDay.Text

                    .Password = Me.txtPassword.Text
                    .BankBenName = Me.txtBankBenName.Text

                    .AgreedSalary = CDbl(Me.txtAgreedSalary.Text)
                    .BonusOnsalary = CDbl(Me.txtExtraBonusOnSalary.Text)
                    .TaxForSplit = CDbl(Me.txtTaxForSplit.Text)
                    .GesyFromSplit = CDbl(Me.txtAnnualGesyFromSplit.Text)


                    .Notes = Me.txtNotes.Text

                    If Me.CBSplitEmployment.CheckState = CheckState.Checked Then
                        .Splitemployement = 1
                    Else
                        .Splitemployement = 0
                    End If
                    If Me.CBNewEmployee.CheckState = CheckState.Checked Then
                        .NewEmployee = 1
                    Else
                        .NewEmployee = 0
                    End If

                    .PensionType = Me.ComboPensionType.SelectedIndex

                    If Not Update Then .CreationDate = Now.Date
                    If Not Update Then .CreatedBy = Global1.GLBUserId
                    .AmendDate = Now.Date
                    .AmendBy = Global1.GLBUserId

                    .MyPhoto = EmpPhoto.Image

                    If Not .Save() Then
                        Throw Exx
                    End If
                    Dim i As Integer
                    For i = 0 To Ern.Length - 1
                        If Ern(i).txtCode.Tag <> "" Then
                            Dim E As New cPrMsEmployeeEarnings(.Code, Ern(i).txtCode.Tag)
                            E.EmpCode = .Code
                            E.ErnCode = Ern(i).txtCode.Tag
                            E.MyValue = Ern(i).txtValue.Text
                            E.TemGrpCode = .TemGrp_Code
                            If Not E.Save Then
                                Throw Exx
                            End If
                        End If
                    Next
                    For i = 0 To Ded.Length - 1
                        If Ded(i).txtCode.Tag <> "" Then
                            Dim D As New cPrMsEmployeeDeductions(.Code, Ded(i).txtCode.Tag)
                            D.EmpCode = .Code
                            D.DedCode = Ded(i).txtCode.Tag
                            D.MyValue = Ded(i).txtValue.Text
                            D.TemGrpCode = .TemGrp_Code
                            If Not D.Save Then
                                Throw Exx
                            End If
                        End If
                    Next
                    For i = 0 To Con.Length - 1
                        If Con(i).txtCode.Tag <> "" Then
                            Dim C As New cPrMsEmployeeContributions(.Code, Con(i).txtCode.Tag)
                            C.EmpCode = .Code
                            C.ConCode = Con(i).txtCode.Tag
                            C.MyValue = Con(i).txtValue.Text
                            C.TemGrpCode = .TemGrp_Code
                            If Not C.Save Then
                                Throw Exx
                            End If
                        End If
                    Next
                    Global1.Business.DeleteEmployeeEarnings(.Code, .TemGrp_Code)

                    Global1.Business.DeleteEmployeeDeductions(.Code, .TemGrp_Code)

                    Global1.Business.DeleteEmployeeContributions(.Code, .TemGrp_Code)

                End With
                Global1.Business.CommitTransaction()
                If ShowMsg Then
                    MsgBox("Changes are successfully Saved", MsgBoxStyle.Information)
                    CheckForM2(tPrMsEmployees)
                End If
                Me.lblSSStatus.Text = "Changes are successfully Saved"
                PKInputReadOnly(True)
            Catch ex As Exception
                Global1.Business.Rollback()
                Utils.ShowException(ex)
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub CheckForM2(ByVal Emp As cPrMsEmployees)
        If Emp.Sic_Code = "M2" Then
            Dim S As New cPrSsSocialInsurance(Emp.SocInc_Code)
            If S.DedValue <> 0 Or S.ConValue <> 0 Then
                MsgBox("Employee is declared as M2 but Social Insurance percentage is not Zero, Please correct", MsgBoxStyle.Critical)
            End If

        End If

    End Sub
    Private Function GetFirstfromcombo(ByVal Text As String) As String
        Dim Ar() As String
        Ar = Text.Split("-")
        Return Trim(Ar(0))
    End Function
    '
    Private Sub LoadDatasetToExcel2(ByVal ShowDiscounts As Boolean)
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader
        Dim PeriodGroupCode As String
        Dim TemGrp As New cPrMsTemplateGroup
        TemGrp = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup)

        PeriodGroupCode = Global1.Business.GetLASTPeriodGroupsOfTemplateGroup(TemGrp.Code)

        ds = Global1.Business.GetAllEmployeesForExcelWithSalary(PeriodGroupCode, ShowDiscounts)

        HeaderStr.Add("Emp_Code")
        HeaderStr.Add("Emp_Status")
        HeaderStr.Add("ayTyp_Code")
        HeaderStr.Add("TemGrp_Code")
        HeaderStr.Add("EmpSta_Code")
        HeaderStr.Add("Emp_Title")
        HeaderStr.Add("Emp_LastName")
        HeaderStr.Add("mp_FirstName")
        HeaderStr.Add("Emp_FullName")
        HeaderStr.Add("Emp_Sex")
        HeaderStr.Add("Emp_BirthDate")
        HeaderStr.Add("MarSta_Code")
        HeaderStr.Add("Emp_Address1")
        HeaderStr.Add("Emp_Address2")
        HeaderStr.Add("Emp_Address3")
        HeaderStr.Add("Emp_PostCode")
        HeaderStr.Add("Emp_Telephone1")
        HeaderStr.Add("Emp_Telephone2")
        HeaderStr.Add("Emp_Email")
        HeaderStr.Add("Emp_SocialInsNumber")
        HeaderStr.Add("ComSin_EmpSocialInsNo")
        HeaderStr.Add("Emp_IdentificationCard")
        HeaderStr.Add("Emp_TaxID")
        HeaderStr.Add("Emp_PassportNumber")
        HeaderStr.Add("Emp_AlienNumber")
        HeaderStr.Add("TicTyp_Code")
        HeaderStr.Add("EmpAn1_Code")
        HeaderStr.Add("EmpAn2_Code")
        HeaderStr.Add("EmpAn3_Code")
        HeaderStr.Add("EmpAn4_Code")
        HeaderStr.Add("EmpAn5_Code")
        HeaderStr.Add("Uni_Code")
        HeaderStr.Add("Cou_Code")
        HeaderStr.Add("EmpPos_Code")
        HeaderStr.Add("Sic_Code")
        HeaderStr.Add("EmpCmm_Code")
        HeaderStr.Add("PayUni_Code")
        HeaderStr.Add("Emp_PeriodUnits")
        HeaderStr.Add("Emp_AnnualUnits")
        HeaderStr.Add("Cur_Code")
        HeaderStr.Add("PmtMth_Code")
        HeaderStr.Add("Bnk_Code")
        HeaderStr.Add("Emp_BankAccount")
        HeaderStr.Add("Bnk_CodeCo")
        HeaderStr.Add("Emp_BankAccountCo")
        HeaderStr.Add("Emp_StartDate")
        HeaderStr.Add("Emp_TerminateDate")
        HeaderStr.Add("Emp_OtherIncome1")
        HeaderStr.Add("Emp_OtherIncome2")
        HeaderStr.Add("Emp_OtherIncome3")
        HeaderStr.Add("Emp_PreviousEarnings")
        HeaderStr.Add("Emp_PrevSIDeduct")
        HeaderStr.Add("Emp_PrevSIContribute")
        HeaderStr.Add("Emp_PrevITDeduct")
        HeaderStr.Add("Emp_PrevPFDeduct")
        HeaderStr.Add("Emp_PrevGesiDeduction")
        HeaderStr.Add("Emp_PrevGesiContribution")
        HeaderStr.Add("ProFnd_Code")
        HeaderStr.Add("MedFnd_Code")
        HeaderStr.Add("SocInc_Code")
        HeaderStr.Add("Ind_Code")
        HeaderStr.Add("Une_Code")
        HeaderStr.Add("SocCoh_Code")
        HeaderStr.Add("Emp_CreationDate")
        HeaderStr.Add("Emp_CreatedBy")
        HeaderStr.Add("Emp_AmendDate")
        HeaderStr.Add("Emp_AmendBy")
        HeaderStr.Add("IntTem_Code")
        HeaderStr.Add("Emp_GLAnal1")
        HeaderStr.Add("Emp_GLAnal2")
        HeaderStr.Add("Emp_GLAnal3")
        HeaderStr.Add("Emp_GLAnal4")
        HeaderStr.Add("IntTem_PFCode")
        HeaderStr.Add("IntTem_MFCode")
        HeaderStr.Add("Emp_PensionNo")
        HeaderStr.Add("Emp_DrivingLicense")
        HeaderStr.Add("Emp_HasSI")
        HeaderStr.Add("Emp_PensionType")
        HeaderStr.Add("Emp_MyPayslipREPort")
        HeaderStr.Add("Emp_IBAN")
        HeaderStr.Add("Emp_PreviousLifeIns")
        HeaderStr.Add("EMp_PreviousDis")
        HeaderStr.Add("Emp_PreviousST")
        HeaderStr.Add("Emp_OtherIncome4")
        HeaderStr.Add("SecPay_Code")
        HeaderStr.Add("ComRat_Code")
        HeaderStr.Add("PerBon_Code")
        HeaderStr.Add("DutHou_Code")
        HeaderStr.Add("FliHou_Code")
        HeaderStr.Add("Emp_PassFullName")
        HeaderStr.Add("Emp_TravelDocs")
        HeaderStr.Add("Emp_FirstEmployment")
        HeaderStr.Add("OveLay_Code")
        HeaderStr.Add("Emp_Password")
        HeaderStr.Add("Emp_Splitemployement")
        HeaderStr.Add("Emp_NewEmployee")
        HeaderStr.Add("Emp_Force50Percent")
        HeaderStr.Add("Emp_Notes")
        HeaderStr.Add("Emp_BankBenName")
        HeaderStr.Add("Emp_AgreedSalary")
        HeaderStr.Add("Emp_BonusOnSalary")
        HeaderStr.Add("Emp_TaxForSplit")
        HeaderStr.Add("Emp_50PerOff")
        HeaderStr.Add("Emp_PrevMF")
        HeaderStr.Add("Emp_PrevPenF")
        HeaderStr.Add("50PerOff")
        HeaderStr.Add("Ges_Code")
        HeaderStr.Add("PrevGesiD")
        HeaderStr.Add("PrevGesiC")
        HeaderStr.Add("LWBPen")
        HeaderStr.Add("GESYFromSplit")
        HeaderStr.Add("AnalGen1")
        HeaderStr.Add("NameDay")
        HeaderStr.Add("IsDirector")
        HeaderStr.Add("Rehire")
        HeaderStr.Add("CNP")
        HeaderStr.Add("TACode")
        HeaderStr.Add("HRCode")
        HeaderStr.Add("TermReason")
        HeaderStr.Add("HireReason")
        HeaderStr.Add("Salary")
        If ShowDiscounts Then
            HeaderStr.Add("Discount 1")
            HeaderStr.Add("Discount 2")
            HeaderStr.Add("Discount 3")
            HeaderStr.Add("Discount 4")
            HeaderStr.Add("Discount 5")
            HeaderStr.Add("Discount 6")
            HeaderStr.Add("Discount 7")
            HeaderStr.Add("Discount 8")
            HeaderStr.Add("Discount 9")
            HeaderStr.Add("Discount 10")
            HeaderStr.Add("Life Insurance")
            HeaderStr.Add("Medical Fund")
        End If




        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)


        If ShowDiscounts Then
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
        End If


        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Sub LoadDataSetToExcel()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        ds = Global1.Business.AG_GetAllPrMsEmployees1()

        HeaderStr.Add("Code")
        HeaderStr.Add("Status")
        HeaderStr.Add("Payroll Type")
        HeaderStr.Add("Template Group")
        HeaderStr.Add("Employee Status Code")
        HeaderStr.Add("Title")
        HeaderStr.Add("Last Name")
        HeaderStr.Add("First Name")
        HeaderStr.Add("Full Name")
        HeaderStr.Add("Sex")
        HeaderStr.Add("Birth Date")
        HeaderStr.Add("Marital Status")
        HeaderStr.Add("Address 1")
        HeaderStr.Add("Address 2")
        HeaderStr.Add("Address 3")
        HeaderStr.Add("Post Code")
        HeaderStr.Add("Telephone 1")
        HeaderStr.Add("Telephone 2")
        HeaderStr.Add("Email")
        HeaderStr.Add("Email2")
        HeaderStr.Add("Soc. Insurance Number")
        HeaderStr.Add("EmpSocialInsNo")
        HeaderStr.Add("Identification Card")
        HeaderStr.Add("Tax ID")
        HeaderStr.Add("Passport Number")
        HeaderStr.Add("Alien Number")
        HeaderStr.Add("TicTyp_Code")
        HeaderStr.Add("Analysis 1")
        HeaderStr.Add("Analysis 2")
        HeaderStr.Add("Analysis 3")
        HeaderStr.Add("Analysis 4")
        HeaderStr.Add("Analysis 5")
        HeaderStr.Add("Union")
        HeaderStr.Add("Country")
        HeaderStr.Add("Employee Position")
        HeaderStr.Add("Soc. Ins. Category")
        HeaderStr.Add("Community")
        HeaderStr.Add("Units Code")
        HeaderStr.Add("Period Units")
        HeaderStr.Add("Annual Units")
        ''HeaderStr.Add("Is COLA")
        HeaderStr.Add("Currency")
        HeaderStr.Add("Payroll Method")
        HeaderStr.Add("Bank")
        HeaderStr.Add("Bank Account")
        HeaderStr.Add("Company Bank")
        HeaderStr.Add("Company Bank Account")
        HeaderStr.Add("Start Date")
        HeaderStr.Add("Terminate Date")
        HeaderStr.Add("Other Income1")
        HeaderStr.Add("Other Income2")
        HeaderStr.Add("Other Income3")
        HeaderStr.Add("PreviousEarnings")
        HeaderStr.Add("PrevSIDeduct")
        HeaderStr.Add("PrevSIContribute")
        HeaderStr.Add("PrevITDeduct")
        HeaderStr.Add("PrevPFDeduct")
        HeaderStr.Add("CreationDate")
        HeaderStr.Add("CreatedBy")
        HeaderStr.Add("AmendDate")
        HeaderStr.Add("AmendBy")

        HeaderSize.Add(16)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(6)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(60)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(1)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(50)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(2)
        HeaderSize.Add(12)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(3)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete " & Me.txtCode.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrMsEmployees.Delete(Trim(Me.txtCode.Text)) Then
                Me.lblSSStatus.Text = Me.txtCode.Text & " has been deleted"
                NewClick()
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub LoadEmployee(ByVal Emp As cPrMsEmployees, ByVal FromCopy As Boolean)
        Cursor.Current = Cursors.WaitCursor

        Dim TempCode As String
        If FromCopy Then
            TempCode = Me.txtCode.Text
        End If
        Me.ClearMe()
        ClearErrors()
        GlbEmp = Emp
        With Emp
            Me.lblSSStatus.Text = ""
            Me.txtCode.Text = .Code
            ' Dim Status As New cPrSsEmployeeStatus(.Status)
            'Me.ComboStatus.SelectedIndex = Me.ComboStatus.FindStringExact(Status.ToString)
            Me.ComboStatus.SelectedIndex = Me.ComboStatus.FindString(.Status & " - ")
            'Dim PayTyp As New cPrSsPayrollTypes(.PayTyp_Code)
            'Me.cmbPayTyp_Code.SelectedIndex = Me.cmbPayTyp_Code.FindStringExact(PayTyp.ToString)
            Me.cmbPayTyp_Code.SelectedIndex = Me.cmbPayTyp_Code.FindString(.PayTyp_Code)

            'Dim TemGrp As New cPrMsTemplateGroup(.TemGrp_Code)
            'Me.cmbTemGrp_Code.SelectedIndex = cmbTemGrp_Code.FindStringExact(TemGrp.ToString)
            Me.cmbTemGrp_Code.SelectedIndex = cmbTemGrp_Code.FindString(.TemGrp_Code & " - ")
            'Dim EmpSta As New cPrAnEmploymentStatus(.EmpSta_Code)
            'Me.cmbEmpSta_Code.SelectedIndex = cmbEmpSta_Code.FindStringExact(EmpSta.ToString)
            Me.cmbEmpSta_Code.SelectedIndex = cmbEmpSta_Code.FindString(.EmpSta_Code & " - ")

            Me.LblHeaderStatus.Text = Me.ComboStatus.Text
            If LblHeaderStatus.Text = "A - Active" Then
                Me.LblHeaderStatus.ForeColor = Color.DodgerBlue
            Else
                Me.LblHeaderStatus.ForeColor = Color.Red
            End If

            Me.txtTitle.Text = .Title
            Me.txtLastName.Text = .LastName
            Me.txtFirstName.Text = .FirstName
            Me.txtFullName.Text = .FullName
            Me.txtPassword.Text = .Password

            If .Sex = "M" Then
                Me.cmbSex.SelectedIndex = 0
            Else
                Me.cmbSex.SelectedIndex = 1
            End If

            If .LWBPen = "1" Then
                CBLWBPen.Checked = True
            Else
                CBLWBPen.Checked = False
            End If

            If .IsDirector = "1" Then
                CBIsDirector.Checked = True
            Else
                CBIsDirector.Checked = False
            End If

            If .Maternity = "1" Then
                CBOnMaternity.Checked = True
            Else
                CBOnMaternity.Checked = False
            End If


            Me.DateBirth.Value = .BirthDate
            'Dim MarSta As New cPrAnMarritalStatus(.MarSta_Code)
            Me.cmbMarSta_Code.SelectedIndex = cmbMarSta_Code.FindString(.MarSta_Code & " - ")
            Me.txtAddress1.Text = .Address1
            Me.txtAddress2.Text = .Address2
            Me.txtAddress3.Text = .Address3
            Me.txtPostCode.Text = .PostCode
            Me.txtTelephone1.Text = .Telephone1
            Me.txtTelephone2.Text = .Telephone2
            Me.txtEmail.Text = .Email
            Me.txtEmail2.Text = .Email2
            Me.txtSocialInsNumber.Text = .SocialInsNumber
            Me.txtComSin_EmpSocialInsNo.Text = .ComSin_EmpSocialInsNo
            Me.txtIdentificationCard.Text = .IdentificationCard
            Me.txtTaxId.Text = .TaxID
            Me.txtPassportNumber.Text = .PassportNumber
            Me.txtAlienNumber.Text = .AlienNumber

            'Dim tct As New cPrAnTaxCardType(.TicTyp_Code)
            'Me.cmbTaxCardType.SelectedIndex = Me.cmbTaxCardType.FindStringExact(tct.ToString)
            Me.cmbTaxCardType.SelectedIndex = Me.cmbTaxCardType.FindString(.TicTyp_Code & " - ")

            'Dim An1 As New cPrAnEmployeeAnalysis1(.EmpAn1_Code)
            'Me.cmbEmpAn1_Code.SelectedIndex = cmbEmpAn1_Code.FindStringExact(An1.ToString)
            Me.cmbEmpAn1_Code.SelectedIndex = cmbEmpAn1_Code.FindString(.EmpAn1_Code & " - ")
            'Dim An2 As New cPrAnEmployeeAnalysis2(.EmpAn2_Code)
            'Me.cmbEmpAn2_Code.SelectedIndex = cmbEmpAn2_Code.FindStringExact(An2.ToString)
            Me.cmbEmpAn2_Code.SelectedIndex = cmbEmpAn2_Code.FindString(.EmpAn2_Code & " - ")
            'Dim An3 As New cPrAnEmployeeAnalysis3(.EmpAn3_Code)
            'Me.cmbEmpAn3_Code.SelectedIndex = cmbEmpAn3_Code.FindStringExact(An3.ToString)
            Me.cmbEmpAn3_Code.SelectedIndex = cmbEmpAn3_Code.FindString(.EmpAn3_Code & " - ")
            'Dim An4 As New cPrAnEmployeeAnalysis4(.EmpAn4_Code)
            'Me.cmbEmpAn4_Code.SelectedIndex = cmbEmpAn4_Code.FindStringExact(An4.ToString)
            Me.cmbEmpAn4_Code.SelectedIndex = cmbEmpAn4_Code.FindString(.EmpAn4_Code & " - ")
            'Dim An5 As New cPrAnEmployeeAnalysis5(.EmpAn5_Code)
            'Me.cmbEmpAn5_Code.SelectedIndex = cmbEmpAn5_Code.FindStringExact(An5.ToString)
            Me.cmbEmpAn5_Code.SelectedIndex = cmbEmpAn5_Code.FindString(.EmpAn5_Code & " - ")

            'Dim Uni As New cPrAnUnions(.Uni_Code)
            'Me.cmbUni_Code.SelectedIndex = cmbUni_Code.FindStringExact(Uni.ToString)
            Me.cmbUni_Code.SelectedIndex = cmbUni_Code.FindString(.Uni_Code & " - ")

            'Dim Cou As New cAdAnCountries(.Cou_Code)
            'Me.cmbCou_Code.SelectedIndex = cmbCou_Code.FindStringExact(Cou.ToString)
            Me.cmbCou_Code.SelectedIndex = cmbCou_Code.FindString(.Cou_Code & " - ")
            'Dim EmpPos As New cPrAnEmployeePositions(.EmpPos_Code)
            'Me.cmbEmpPos_Code.SelectedIndex = cmbEmpPos_Code.FindStringExact(EmpPos.ToString)
            Me.cmbEmpPos_Code.SelectedIndex = cmbEmpPos_Code.FindString(.EmpPos_Code & " - ")

            'Dim SIC As New cPrAnSocialInsCategories(.Sic_Code)
            'Me.cmbSic_Code.SelectedIndex = cmbSic_Code.FindStringExact(SIC.ToString)
            Me.cmbSic_Code.SelectedIndex = cmbSic_Code.FindString(.Sic_Code & " - ")

            'Dim EmpCmm As New cPrAnEmployeeCommunity(.EmpCmm_Code)
            'Me.cmbEmpCmm_Code.SelectedIndex = cmbEmpCmm_Code.FindStringExact(EmpCmm.ToString)
            Me.cmbEmpCmm_Code.SelectedIndex = cmbEmpCmm_Code.FindString(.EmpCmm_Code & " - ")

            'Dim PayUni As New cPrSsPayrollUnits(.PayUni_Code)
            'Me.cmbPayUni_Code.SelectedIndex = cmbPayUni_Code.FindStringExact(PayUni.ToString)
            Me.cmbPayUni_Code.SelectedIndex = cmbPayUni_Code.FindString(.PayUni_Code & " - ")

            Me.txtPeriodUnits.Text = .PeriodUnits
            Me.txtAnnualUnits.Text = .AnnualUnits

            'Dim Cur As New cAdMsCurrency(.Cur_Code)
            'Me.cmbCur_Code.SelectedIndex = cmbCur_Code.FindStringExact(Cur.ToString)
            Me.cmbCur_Code.SelectedIndex = cmbCur_Code.FindString(.Cur_Code)

            'Dim PayMet As New cPrAnPaymentMethods(.PmtMth_Code)
            'Me.cmbPmtMth_Code.SelectedIndex = cmbPmtMth_Code.FindStringExact(PayMet.ToString)
            Me.cmbPmtMth_Code.SelectedIndex = cmbPmtMth_Code.FindString(.PmtMth_Code & " - ")

            'Dim EmpBank As New cPrAnBanks(.Bnk_Code)
            'Me.cmbBnk_Code.SelectedIndex = cmbBnk_Code.FindStringExact(EmpBank.ToString)
            Me.cmbBnk_Code.SelectedIndex = cmbBnk_Code.FindString(.Bnk_Code & " - ")

            Me.txtBankAccount.Text = .BankAccount
            'Dim CoBank As New cPrAnBanks(.Bnk_CodeCo)
            'Me.cmbBnk_CodeCo.SelectedIndex = cmbBnk_CodeCo.FindStringExact(CoBank.ToString)
            Me.cmbBnk_CodeCo.SelectedIndex = cmbBnk_CodeCo.FindString(.Bnk_CodeCo & " - ")

            Me.txtBankAccountCo.Text = .BankAccountCo
            Me.DateStart.Value = .StartDate
            Me.txtTerminateDate.Text = .TerminateDate
            Me.txtOtherIncome1.Text = .OtherIncome1
            Me.txtOtherIncome2.Text = .OtherIncome2
            Me.txtOtherIncome3.Text = .OtherIncome3

            Me.txtAgreedSalary.Text = .AgreedSalary
            Me.txtExtraBonusOnSalary.Text = .BonusOnsalary
            Me.txtTaxForSplit.Text = .TaxForSplit
            Me.txtAnnualGesyFromSplit.Text = .GesyFromSplit


            Me.txtPreviousEarnings.Text = .PreviousEarnings
            '   Me.txtPrevInsurableforGESY.Text = .Previousinsurableforgesy

            Me.txtEmp_PrevSIDeduct.Text = .Emp_PrevSIDeduct
            Me.txtEmp_PrevSIContribute.Text = .Emp_PrevSIContribute
            Me.txtEmp_PrevITDeduct.Text = .Emp_PrevITDeduct
            Me.txtEmp_PrevPFDeduct.Text = .Emp_PrevPFDeduct
            'Dim ProFund As New cPrSsProvidentFund(.ProFnd_Code)
            'Me.ComboProFund.SelectedIndex = ComboProFund.FindStringExact(ProFund.ToString)
            Me.ComboProFund.SelectedIndex = ComboProFund.FindString(.ProFnd_Code & " - ")

            'Dim MedFund As New cPrSsMedicalFund(.MedFnd_Code)
            'Me.ComboMedicalFund.SelectedIndex = ComboMedicalFund.FindStringExact(MedFund.ToString)
            Me.ComboMedicalFund.SelectedIndex = ComboMedicalFund.FindString(.MedFnd_Code & " - ")

            'Dim SocIns As New cPrSsSocialInsurance(.SocInc_Code)
            'Me.ComboSocialIns.SelectedIndex = ComboSocialIns.FindStringExact(SocIns.ToString)
            Me.ComboSocialIns.SelectedIndex = ComboSocialIns.FindString(.SocInc_Code & " - ")

            '
            'Dim Ind As New cPrSsIndustrial(.Ind_Code)
            'Me.ComboIndustrial.SelectedIndex = ComboIndustrial.FindStringExact(Ind.ToString)
            Me.ComboIndustrial.SelectedIndex = ComboIndustrial.FindString(.Ind_Code & " - ")

            'Dim Une As New cPrSsUnemployment(.Une_Code)
            'Me.ComboUnemployment.SelectedIndex = ComboUnemployment.FindStringExact(Une.ToString)
            Me.ComboUnemployment.SelectedIndex = ComboUnemployment.FindString(.Une_Code & " - ")

            'Dim SocCoh As New cPrSsSocialCohesion(.SocCoh_Code)
            'Me.ComboSocialCohesion.SelectedIndex = ComboSocialCohesion.FindStringExact(SocCoh.ToString)
            Me.ComboSocialCohesion.SelectedIndex = ComboSocialCohesion.FindString(.SocCoh_Code & " - ")
            '
            'Dim Ges As New cPrSsGesi(.GESICode)
            'Me.ComboGESI.SelectedIndex = ComboGESI.FindStringExact(Ges.ToString)
            Me.ComboGESI.SelectedIndex = ComboGESI.FindString(.GESICode & " - ")

            Me.DateCreated.Value = .CreationDate

            Dim User1 As New cAaSsUsers(.CreatedBy)
            Me.cmbCreatedBy.SelectedIndex = cmbCreatedBy.FindStringExact(User1.ToString)
            Me.DateAmend.Value = .AmendDate
            Dim User2 As New cAaSsUsers(.AmendBy)
            Me.cmbAmendBy.SelectedIndex = cmbAmendBy.FindStringExact(User2.ToString)

            'Dim IntTem As New cPrMsInterfaceTemplate(.InterfaceTemCode)
            'Me.cmbIntTem_Code.SelectedIndex = Me.cmbIntTem_Code.FindStringExact(IntTem.ToString)
            Me.cmbIntTem_Code.SelectedIndex = Me.cmbIntTem_Code.FindString(.InterfaceTemCode & " - ")

            'Dim IntTemPF As New cPrMsInterfaceTemplate(.InterfacePFCode)
            'Me.cmbIntPF.SelectedIndex = Me.cmbIntPF.FindStringExact(IntTemPF.ToString)
            Me.cmbIntPF.SelectedIndex = Me.cmbIntPF.FindString(.InterfacePFCode & " - ")

            'Dim IntTemMF As New cPrMsInterfaceTemplate(.InterfaceMFCode)
            'Me.cmbIntMF.SelectedIndex = Me.cmbIntMF.FindStringExact(IntTemMF.ToString)
            Me.cmbIntMF.SelectedIndex = Me.cmbIntMF.FindString(.InterfaceMFCode & " - ")

            '''
            'Dim SecPay As New cPrSsSectorPay(.SectorPay)
            'Me.ComboSectorPay.SelectedIndex = ComboSectorPay.FindStringExact(SecPay.ToString)
            Me.ComboSectorPay.SelectedIndex = ComboSectorPay.FindString(.SectorPay & " - ")

            'Dim ComRat As New cPrSsCommissionRates(.CommissionRate)
            'Me.ComboCommissionRates.SelectedIndex = ComboCommissionRates.FindStringExact(ComRat.ToString)
            Me.ComboCommissionRates.SelectedIndex = ComboCommissionRates.FindString(.CommissionRate & " - ")

            'Dim PerBon As New cPrSsPerformanceBonus(.PerformanceBonus)
            'Me.ComboPerformanceBonus.SelectedIndex = ComboPerformanceBonus.FindStringExact(PerBon.ToString)
            Me.ComboPerformanceBonus.SelectedIndex = ComboPerformanceBonus.FindString(.PerformanceBonus & " - ")


            'Dim DutHou As New cPrSsDutyHours(.DutyHours)
            'Me.ComboDutyHours.SelectedIndex = ComboDutyHours.FindStringExact(DutHou.ToString)
            Me.ComboDutyHours.SelectedIndex = ComboDutyHours.FindString(.DutyHours & " - ")

            'Dim OveLay As New cPrSsOverLay(.OverLay)
            'Me.ComboOverLay.SelectedIndex = ComboOverLay.FindStringExact(OveLay.ToString)
            Me.ComboOverLay.SelectedIndex = ComboOverLay.FindString(.OverLay & " - ")

            'Dim Flihou As New cPrSsFlightHours(.FlightHours)
            'Me.ComboFlightHours.SelectedIndex = ComboFlightHours.FindStringExact(Flihou.ToString)
            Me.ComboFlightHours.SelectedIndex = ComboFlightHours.FindString(.FlightHours & " - ")

            '''

            Me.txtOhterCountryTIC.Text = .DrivingLicense
            Me.txtPensionNo.Text = .PensionNo
            If .IsSI = 0 Then
                CBIsSI.Checked = False
            Else
                CBIsSI.Checked = True
            End If

            If .Splitemployement = "0" Then
                CBSplitEmployment.Checked = False
            Else
                CBSplitEmployment.Checked = True
            End If
            If .NewEmployee = "0" Then
                CBNewEmployee.Checked = False
            Else
                CBNewEmployee.Checked = True
            End If
            Me.ComboTermReason.SelectedIndex = ComboTermReason.FindString(.TermReason & " - ")
            If .HireReason = "" Then
                Me.ComboHireReason.SelectedIndex = 0
            Else
                Me.ComboHireReason.SelectedIndex = ComboHireReason.FindString(.HireReason & " - ")
            End If


            Me.txtRehiredCode.Text = .Rehire

            Me.txtCNPCode.Text = .CNPCode
            Me.txtTACode.Text = .TACode
            Me.txtHRCode.Text = .HRCode

            Me.txtGLAnal1.Text = .Emp_GLAnal1
            Me.txtGLAnal2.Text = .Emp_GLAnal2
            Me.txtGLAnal3.Text = .Emp_GLAnal3
            Me.txtGLAnal4.Text = .Emp_GLAnal4
            Me.ComboPensionType.SelectedIndex = .PensionType
            Me.txtPayslipreport.Text = .MyPayslipReport
            Me.txtEmployeeIBAN.Text = .IBAN

            Me.txtPreviousLF.Text = .PreviousLifeIns
            Me.txtPreviousDis.Text = .PreviousDis

            Me.txtPreviousST.Text = .PreviousST

            Me.txtPreviusMF.Text = .PrevMedFund
            Me.txtPreviusPenF.Text = .PrevPensionFund


            Me.txtOtherIncome4.Text = .OtherIncome4

            Me.txtFullPassportName.Text = .FullPassName
            Me.txtTravelDocs.Text = .Traveldocs
            Me.txtBankBenName.Text = .BankBenName

            If .FirstEmployment = "1" Then
                Me.CBFirstEmployment.CheckState = CheckState.Checked
            Else
                Me.CBFirstEmployment.CheckState = CheckState.Unchecked
            End If

            If .Force50Percent = "1" Then
                Me.CBForce50Percent.CheckState = CheckState.Checked
            Else
                Me.CBForce50Percent.CheckState = CheckState.Unchecked
            End If

            Me.txtFEControlAmount.Text = .FEControlAmount
            If .FEControlAmount = 100000 Then
                Me.CBControlAmount100.Checked = True
            ElseIf .FEControlAmount = 55000 Then
                Me.CBControlAmount55.Checked = True
            End If

            If .f50PercOff = "1" Then
                Me.CBLimitTo20.CheckState = CheckState.Checked
            Else
                Me.CBLimitTo20.CheckState = CheckState.Unchecked
            End If


            Me.txtPrevGesiD.Text = .PreviousGesiD
            Me.txtPrevGesiC.Text = .PreviousGesiC

            Me.txtNotes.Text = .Notes

            Me.txtAnalGen1.Text = .AnalGen1
            Me.txtNameDay.Text = .NameDay

            Me.EmpPhoto.Image = .MyPhoto

            PKInputReadOnly(True)
            LoadEDCForEmployee(Emp)

            If FromCopy Then
                Me.txtCode.Text = TempCode
                Emp.Code = TempCode
                Me.txtCode.ReadOnly = False
            End If

        End With
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub LoadEDCForEmployee(ByVal Emp As cPrMsEmployees)
        Dim ds As DataSet
        Dim i As Integer
        Dim k As Integer
        'Load employee Earnings Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeEarnings(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EE As New cPrMsEmployeeEarnings(ds.Tables(0).Rows(i))
                For k = 0 To Me.Ern.Length - 1
                    If EE.ErnCode = Ern(k).txtCode.Tag Then
                        'If Ern(k).Ern.FromMode = "T" Then
                        '    Me.FindEarningValue(EE)
                        'End If
                        Ern(k).txtValue.Text = Format(EE.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If
        'Load employee Deduction Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeDeductions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim ED As New cPrMsEmployeeDeductions(ds.Tables(0).Rows(i))
                For k = 0 To Me.Ded.Length - 1
                    If ED.DedCode = Ded(k).txtCode.Tag Then
                        If Ded(k).Ded.FromMode = "T" Then
                            Me.FindDeductionValue(ED, Emp)
                        End If
                        Ded(k).txtValue.Text = Format(ED.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If
        'Load employee Contribution Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeContributions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EC As New cPrMsEmployeeContributions(ds.Tables(0).Rows(i))
                For k = 0 To Me.Con.Length - 1
                    If EC.ConCode = Con(k).txtCode.Tag Then
                        If Con(k).Con.FromMode = "T" Then
                            Me.FindContributionValue(EC, Emp)
                        End If
                        Con(k).txtValue.Text = Format(EC.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If

    End Sub
    Private Function CheckFor_PF_MF_SI(ByVal k As Integer, ByVal ED As cPrMsEmployeeDeductions) As Boolean
        Dim Ded As New cPrMsDeductionCodes(ED.DedCode)
        Dim flag As Boolean = False
        If Ded.DedTypCode = "MF" Then
            flag = True

        ElseIf Ded.DedTypCode = "PF" Then
            flag = True

        ElseIf Ded.DedTypCode = "SI" Then
            flag = True

        End If
        Return flag

    End Function
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtCode.ReadOnly = RO
        Me.btnFindNextAvailable.Enabled = Not RO

    End Sub
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Dim f As New FrmEmployeeSearch
        f.CalledBy = 1
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub txtLastName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastName.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtFirstName.Focus()
        End If
    End Sub
    Private Sub txttitle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitle.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtLastName.Focus()
        End If
    End Sub

    Private Sub txtLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastName.TextChanged
        Me.txtFullName.Text = Me.txtLastName.Text & " " & Me.txtFirstName.Text
    End Sub

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName.TextChanged
        Me.txtFullName.Text = Me.txtLastName.Text & " " & Me.txtFirstName.Text
    End Sub
    Private Sub cmbTemGrp_Code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTemGrp_Code.SelectedIndexChanged
        ClearEDC()
        Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
        GLBTempGroup = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup)
        GlbCompany = New cAdMsCompany(GLBTempGroup.CompanyCode)
        Me.lblTemplate.Text = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).ToString
        Me.LoadEDCForEmployee(tEmp)
        Me.LoadPrMsInterfaceTemplate(GLBTempGroup)
    End Sub


    Private Sub TSBSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalary.Click
        ShowSalary()
    End Sub
    Public Sub ShowSalary(Optional ByVal GrossSal As Double = 0)
        If TSBSalary.Enabled Then
            If Me.txtCode.Text <> "" Then

                Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
                If tEmp.Code = "" Then
                    MsgBox("Please save First Employee and then Proceed to Employee Salary", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    Dim F As New frmPrTxEmployeeSalary
                    F.EmpCode = Me.txtCode.Text
                    F.EmpName = Me.txtFullName.Text

                    F.Employee = tEmp
                    F.Owner = Me

                    F.GrossFromCalc = GrossSal

                    F.ShowDialog()
                End If
            End If
        Else
            MsgBox("Current User Permitions are preventing this action", MsgBoxStyle.Information)
        End If
    End Sub


    Private Sub TSBDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDiscounts.Click
        If Me.txtCode.Text <> "" Then
            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Salary", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim F As New frmPrTxEmployeeDiscounts
                F.EmpCode = Me.txtCode.Text
                F.EmpName = Me.txtFullName.Text
                F.TempGrpCode = tEmp.TemGrp_Code
                F.Owner = Me
                F.ShowDialog()
            End If
        End If
    End Sub
    Private Sub TSBAnnualLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBAnnualLeave.Click
        If Me.txtCode.Text <> "" Then

            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Annueal Leave", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim F As New FrmPrTxEmployeeLeave
                F.EmpCode = Me.txtCode.Text
                F.Employee = tEmp
                F.Owner = Me
                F.ShowDialog()
            End If
        End If
    End Sub
    Private Sub TSBAnnualAdvances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBAdvances.Click
        If Me.txtCode.Text <> "" Then

            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Annueal Leave", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim F As New FrmPrTxEmployeeAdvances
                F.EmpCode = Me.txtCode.Text
                F.Employee = tEmp
                F.Owner = Me
                F.ShowDialog()
            End If
        End If
    End Sub
    Private Sub cmbPayUni_Code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayUni_Code.SelectedIndexChanged
        If Me.cmbPayUni_Code.Text <> "" Then
            Dim PayUni As New cPrSsPayrollUnits
            PayUni = CType(Me.cmbPayUni_Code.SelectedItem, cPrSsPayrollUnits)
            If PayUni.Code = 1 Then
                Me.txtAnnualUnits.ReadOnly = True
                Me.txtPeriodUnits.ReadOnly = False
            Else
                Me.txtAnnualUnits.ReadOnly = False
                Me.txtPeriodUnits.ReadOnly = False
            End If
        End If
    End Sub
    '#Region "Find Values For Employee earnings"
    '    Private Sub FindEarningValue(ByRef EE As cPrMsEmployeeEarnings, ByVal ActualUnits As Double)
    '        Dim Emp As New cPrMsEmployees(EE.EmpCode)
    '        Dim Earn As New cPrMsEarningCodes(EE.ErnCode)
    '        Select Case Earn.ErnTypCode
    '            Case "3A" '13 SALARY
    '                'E_13Salary(Emp, EE, Earn)
    '            Case "3E" '13 SALARY ESTIMATE
    '                ' E_Calculate13Estimate(Emp, EE, Earn)
    '            Case "4A" '14 SALARY
    '                'E_14Salary(Emp, EE, Earn)
    '            Case "4E" '14 SALARY ESTIMATE
    '                'E_Calculate14Estimate(Emp, EE, Earn)
    '            Case "AR" 'ARREARS
    '                'E_CalculateArrears(Emp, EE, Earn)
    '            Case "OT" 'OVERTIME
    '                'E_CalculateOverTime(Emp, EE, Earn)
    '            Case "SA" 'SALARY
    '                EE.MyValue = E_CalculateSalary(Emp, EE, Earn, ActualUnits)
    '            Case "SI" 'SOCIAL INSURANCE LEAVE

    '            Case "OE" 'OTHER INCOME
    '                EE.MyValue = E_CalculateOtherIncome(Emp, EE, Earn)

    '        End Select

    '    End Sub
    '    Private Function E_CalculateSalary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal ActualUnits As Double) As Double

    '        Dim Gross As Double = 0
    '        Dim Rate As Double = 0
    '        Dim Salary As Double = 0
    '        Dim NormalUnits As Double = 0

    '        Dim cSalary As New cPrTxEmployeeSalary()

    '        cSalary = Global1.Business.GetCurrentSalary(Emp.Code, Me.GLBCurrentPeriod.DateTo)
    '        Gross = cSalary.SalaryValue

    '        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
    '            'Hourly
    '            'RateForOvertimeCalc = Gross
    '            Rate = Gross
    '            Salary = RoundMe3(Rate * ActualUnits, 2)
    '        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
    '            'Period
    '            NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
    '            Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
    '            'RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
    '            'GrossFor13AND14Calc = Gross
    '            'GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
    '        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Contract_Code Then
    '            'contract
    '            NormalUnits = Emp.PeriodUnits
    '            Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
    '            'RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
    '            'GrossFor13AND14Calc = Gross
    '            'GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
    '        End If

    '        Return Salary

    '        'Me.txtSalary.Text = Format(Salary, "0.00")
    '    End Function
    '    'Private Sub E_CalculateOverTime(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim OverTime1 As Double = 0
    '    '    Dim OverTime2 As Double = 0

    '    '    If Me.txtOvertime1.Text = "" Then
    '    '        Me.txtOvertime1.Text = 0
    '    '    End If
    '    '    If Me.txtOvertime2.Text = "" Then
    '    '        Me.txtOvertime2.Text = 0
    '    '    End If
    '    '    OverTime1 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate1 * Me.txtOvertime1.Text, 2)
    '    '    OverTime2 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate2 * Me.txtOvertime2.Text, 2)

    '    '    Dim i As Integer
    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = OverTime1 + OverTime2
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    'Me.txtOver1.Text = Format(OverTime1, "0.00")
    '    'Me.txtOver2.Text = Format(OverTime2, "0.00")
    '    'End Sub
    '    'Private Sub E_CalculateArrears(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim Arrears As Double = 0
    '    '    Dim i As Integer
    '    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '    '        If Me.GlbEmpSalary.EffPayDate >= Me.GLBCurrentPeriod.DateFrom Then
    '    '            If Me.GlbEmpSalary.EffPayDate <= Me.GLBCurrentPeriod.DateTo Then
    '    '                Dim NumberOfPeriods As Integer
    '    '                NumberOfPeriods = Global1.Business.GetNumberOfNormalPeriodsBack(GlbEmpSalary, GLBCurrentPeriod)
    '    '                Arrears = NumberOfPeriods * GlbEmpSalary.EmpSal_Dif
    '    '            End If
    '    '        End If
    '    '    End If
    '    '    ArrearsFor13AND14Calc = Arrears
    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = Arrears
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    '    'Me.txtarrears.text = Format(Arrears, "0.00")
    '    'End Sub
    '    'Private Sub E_13Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim t13Salary As Double = 0
    '    '    Dim ActualUnits As Double = Me.txtActualUnits.Text
    '    '    Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
    '    '    Dim SumOfAnuallUnitOfNormalPeriods As Double
    '    '    Dim AnuallUnitsOfThisPeriod As Double = 0
    '    '    Dim i As Integer


    '    '    AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

    '    '    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

    '    '    t13Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)

    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = t13Salary
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    'End Sub
    '    'Private Sub E_14Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim t14Salary As Double = 0
    '    '    Dim ActualUnits As Double = Me.txtActualUnits.Text
    '    '    Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
    '    '    Dim SumOfAnuallUnitOfNormalPeriods As Double
    '    '    Dim AnuallUnitsOfThisPeriod As Double = 0
    '    '    Dim i As Integer

    '    '    AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

    '    '    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

    '    '    t14Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)
    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = t14Salary
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    'End Sub
    '    'Private Sub E_Calculate13Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim t13estimate As Double = 0
    '    '    Dim AnnualPeriodUnits As Double
    '    '    Dim t13thPeriodTotalUnits As Double
    '    '    Dim i As Integer

    '    '    t13thPeriodTotalUnits = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
    '    '    AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

    '    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '    '        If t13thPeriodTotalUnits <> 0 Then
    '    '            t13estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t13thPeriodTotalUnits)
    '    '        End If
    '    '    End If

    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = t13estimate
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    'End Sub
    '    'Private Sub E_Calculate14Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    '    Dim t14estimate As Double = 0
    '    '    Dim AnnualPeriodUnits As Double
    '    '    Dim t14thPeriodTotalUnits As Double
    '    '    Dim i As Integer

    '    '    t14thPeriodTotalUnits = Global1.Business.Find14nthPeriodUnits(Me.GLBCurrentPeriod)
    '    '    AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

    '    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '    '        If t14thPeriodTotalUnits <> 0 Then
    '    '            t14estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t14thPeriodTotalUnits)
    '    '        End If
    '    '    End If
    '    '    For i = 0 To E_Final.Length - 1
    '    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '    '            E_Final(i).MyValue = t14estimate
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    '    ' Me.txt14Estimate.Text = Format(t14estimate, "0.00")
    '    'End Sub
    '    Private Function E_CalculateOtherIncome(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes) As Double
    '        Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
    '        Dim OtherIncome As Double

    '        If TempErn.ErnCodCode <> "" Then
    '            If TempErn.TypeMode = "P" Then
    '                OtherIncome = EmpErn.MyValue
    '            ElseIf TempErn.TypeMode = "V" Then
    '                OtherIncome = EmpErn.MyValue
    '            End If
    '        End If

    '        Return OtherIncome


    '    End Function
    '#End Region
#Region "Find Values For Employee Deductions"
    Private Sub FindDeductionValue(ByRef ED As cPrMsEmployeeDeductions, ByVal Emp As cPrMsEmployees)
        'Dim Emp As New cPrMsEmployees(ED.EmpCode)
        Dim Ded As New cPrMsDeductionCodes(ED.DedCode)
        Select Case Ded.DedTypCode
            Case "AD" 'ADVANCES
                ED.MyValue = D_CalculateAdvances(Emp, ED, Ded)
            Case "CL" 'COMPANY LOAN
                ED.MyValue = D_CalculateCompanyLoan(Emp, ED, Ded)
            Case "IT" 'INCOME TAX

            Case "MF" 'MEDICAL FUND
                ED.MyValue = D_CalculateMedicalFund(Emp, ED, Ded)
            Case "PF" 'PROVIDENT FUND
                ED.MyValue = D_CalculateProvidentFund(Emp, ED, Ded)
            Case "PL" 'PROVIDENT FUND LOAN
                ED.MyValue = D_CalculateProvidentFundLoan(Emp, ED, Ded)
            Case "SI" 'SOCIAL INSURANCE
                ED.MyValue = D_CalculateSocialInsurance(Emp, ED, Ded)
            Case "U2" 'UNION NEWSPAPER
                D_CalculateUnion2(Emp, ED, Ded)
            Case "U3" 'OTHER
                D_CalculateUnion3(Emp, ED, Ded)
            Case "US" 'UNINON SUBSCRIPTION
                D_CalculateUnionSubscription(Emp, ED, Ded)
            Case "UM" 'UNINON SUBSCRIPTION
                D_CalculateUnionMedicalFund(Emp, ED, Ded)
            Case "GD"
                ED.MyValue = D_CalculateGESI(Emp, ED, Ded)
            Case "GT"
                ED.MyValue = D_CalculateGESIBIK(Emp, ED, Ded)
        End Select
    End Sub
    Private Function D_CalculateAdvances(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Advances As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                Advances = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                Advances = EmpDed.MyValue
            End If
        End If

        Return Advances

    End Function
    Private Function D_CalculateCompanyLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim CompanyLoan As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                CompanyLoan = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                CompanyLoan = EmpDed.MyValue
            End If
        End If

        Return CompanyLoan


    End Function
    Private Function D_CalculateProvidentFundLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim PFLoan As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                PFLoan = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                PFLoan = EmpDed.MyValue
            End If
        End If

        Return PFLoan


    End Function
    Private Function D_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim MFValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                MFValue = EmpDed.MyValue
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
            End If
        End If

        Return MFValue

    End Function
    Private Function D_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim PFValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.DedValue
                    Else
                        PFValue = 0
                    End If
                End If
                PFValue = PFValue
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.DedValue
                    Else
                        PFValue = 0
                    End If
                End If

            End If
        End If

        Return PFValue


    End Function
    Private Function D_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim SIValue As Double
        Dim Limits As New cPrSsLimits

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.DedValue
                    Else
                        SIValue = 0
                    End If
                End If

            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.DedValue
                    Else
                        SIValue = 0
                    End If
                End If

            End If
        End If
        Return SIValue


    End Function
    Private Function D_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim GESIValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GESIValue = Gesi.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If

            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GESIValue = Gesi.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If

            End If
        End If
        Return GESIValue


    End Function
    Private Function D_CalculateGESIBIK(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim GESIValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GESIValue = Gesi.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If

            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GESIValue = Gesi.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If

            End If
        End If
        Return GESIValue


    End Function
    Private Function D_CalculateUnionSubscription(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim UnionValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionValue = Union.Uni_SubscriptionValue
                    Else
                        UnionValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionValue = Union.Uni_SubscriptionValue
                    Else
                        UnionValue = 0
                    End If
                End If

            End If
        End If

        'Checking Or Union Sub. Limit 
        If UnionValue > Union.MonthlySubLimit Then
            UnionValue = Union.MonthlySubLimit
        End If


        Return UnionValue



    End Function
    Private Function D_CalculateUnion2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Union2Value As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union2Value = Union.Uni_Deduction1
                    Else
                        Union2Value = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union2Value = Union.Uni_Deduction1
                    Else
                        Union2Value = 0
                    End If
                End If

            End If
        End If

        Return Union2Value


    End Function
    Private Function D_CalculateUnion3(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Union3Value As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union3Value = Union.Uni_Deduction2
                    Else
                        Union3Value = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union3Value = Union.Uni_Deduction2
                    Else
                        Union3Value = 0
                    End If
                End If

            End If
        End If

        Return Union3Value

    End Function
    Private Function D_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) As Double
        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim UnionMFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionMFValue

    End Function
#End Region
#Region "Find Values For Employee Contributions"
    Private Sub FindContributionValue(ByRef EC As cPrMsEmployeeContributions, ByVal Emp As cPrMsEmployees)
        Dim Con As New cPrMsContributionCodes(EC.ConCode)
        'Dim Emp As New cPrMsEmployees(EC.EmpCode)
        Select Case Con.ConTypCode
            Case "IN" 'INDUSTRIAL
                EC.MyValue = C_CalculateIndustrial(Emp, EC, Con)
            Case "MF" 'MEDICAL FUND
                EC.MyValue = C_CalculateMedicalFund(Emp, EC, Con)
            Case "PF" 'PROVIDENT FUND
                EC.MyValue = C_CalculateProvidentFund(Emp, EC, Con)
            Case "SI" 'SOCIAL INSURANCE
                EC.MyValue = C_CalculateSocialInsurance(Emp, EC, Con)
            Case "ST" 'SOCIAL COHESION FUND
                EC.MyValue = C_CalculateSocialCohesionFund(Emp, EC, Con)
            Case "UN" 'UNEMPLOYMENT
                EC.MyValue = C_CalculateUnemploymentFund(Emp, EC, Con)
            Case "WF" 'WELFAIR FUND
                EC.MyValue = C_CalculateWelFairFund(Emp, EC, Con)
            Case "UM" 'UNION MEDICAL FUND
                EC.MyValue = C_CalculateUnionMedicalFund(Emp, EC, Con)
            Case "GC" 'GESI
                EC.MyValue = C_CalculateGESI(Emp, EC, Con)
        End Select

    End Sub
    Private Function C_CalculateIndustrial(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim Industrial As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Ind As New cPrSsIndustrial(Emp.Ind_Code)
                    If Ind.Code <> "" Then
                        Industrial = Ind.ConValue
                    Else
                        Industrial = 0
                    End If
                End If

                Industrial = Industrial
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Ind As New cPrSsIndustrial(Emp.Ind_Code)
                    If Ind.Code <> "" Then
                        Industrial = Ind.ConValue
                    Else
                        Industrial = 0
                    End If
                End If
            End If
        End If


        Return Industrial

    End Function
    Private Function C_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim MFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If
                MFValue = MFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If

            End If
        End If
        Return MFValue

    End Function
    Private Function C_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim PFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.ConValue
                    Else
                        PFValue = 0
                    End If
                End If
                PFValue = PFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.ConValue
                    Else
                        PFValue = 0
                    End If
                End If

            End If
        End If

        Return PFValue

    End Function
    Private Function C_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim SIValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.ConValue
                    Else
                        SIValue = 0
                    End If
                End If

                SIValue = SIValue

            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.ConValue
                    Else
                        SIValue = 0
                    End If
                End If

            End If
        End If

        Return SIValue


    End Function
    Private Function C_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim GesiValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    GesiValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GesiValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GesiValue = Gesi.ConValue
                    Else
                        GesiValue = 0
                    End If
                End If

                GesiValue = GesiValue

            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    GesiValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GesiValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Gesi As New cPrSsGesi(Emp.GESICode)
                    If Gesi.Code <> "" Then
                        GesiValue = Gesi.ConValue
                    Else
                        GesiValue = 0
                    End If
                End If

            End If
        End If

        Return GesiValue


    End Function
    Private Function C_CalculateSocialCohesionFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim SCValue As Double


        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
                    If SocCoh.Code <> "" Then
                        SCValue = SocCoh.ConValue
                    Else
                        SCValue = 0
                    End If
                End If
                SCValue = SCValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
                    If SocCoh.Code <> "" Then
                        SCValue = SocCoh.ConValue
                    Else
                        SCValue = 0
                    End If
                End If
            End If
        End If

        Return SCValue

    End Function
    Private Function C_CalculateUnemploymentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Une As New cPrSsUnemployment(Emp.Une_Code)
                    If Une.Code <> "" Then
                        UFValue = Une.ConValue
                    Else
                        UFValue = 0
                    End If
                End If

                UFValue = UFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Une As New cPrSsUnemployment(Emp.Une_Code)
                    If Une.Code <> "" Then
                        UFValue = Une.ConValue
                    Else
                        UFValue = 0
                    End If
                End If
            End If
        End If


        Return UFValue

    End Function
    Private Function C_CalculateWelFairFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UnionWFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionWFValue = Union.WelfareRate
                    Else
                        UnionWFValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionWFValue = Union.WelfareRate
                    Else
                        UnionWFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionWFValue

    End Function
    Private Function C_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes) As Double
        Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UnionMFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionMFValue

    End Function
#End Region



    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        GetEmployee(Me.txtCode.Text, False, False)
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        GetEmployee(Me.txtCode.Text, True, False)
    End Sub
    Public Sub NextEmployee_OnDiscounts(ByVal F As frmPrTxEmployeeDiscounts)
        GetEmployee(Me.txtCode.Text, True, False)

        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text
        F.TempGrpCode = GlbEmp.TemGrp_Code
        F.LoadMe()

    End Sub
    Public Sub PreviousEmployee_OnDiscounts(ByVal F As frmPrTxEmployeeDiscounts)
        GetEmployee(Me.txtCode.Text, False, False)

        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text
        F.TempGrpCode = GlbEmp.TemGrp_Code
        F.LoadMe()
    End Sub
    Public Sub NextEmployee_OnLeave(ByVal F As FrmPrTxEmployeeLeave)
        GetEmployee(Me.txtCode.Text, True, False)

        F.EmpCode = Me.txtCode.Text
        F.Employee = GlbEmp
        F.LoadMe()

    End Sub
    Public Sub PreviousEmployee_OnLeave(ByVal F As FrmPrTxEmployeeLeave)
        GetEmployee(Me.txtCode.Text, False, False)

        F.EmpCode = Me.txtCode.Text
        F.Employee = GlbEmp

        F.LoadMe()
    End Sub
    Public Sub NextEmployee_OnSalary(ByVal F As frmPrTxEmployeeSalary)
        GetEmployee(Me.txtCode.Text, True, False)

        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text

        F.LoadMe()

    End Sub
    Public Sub PreviousEmployee_OnSalary(ByVal F As frmPrTxEmployeeSalary)
        GetEmployee(Me.txtCode.Text, False, False)

        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text


        F.LoadMe()
    End Sub
    Public Sub NextEmployee_OnReminder(ByVal F As FrmPrMsReminder)
        GetEmployee(Me.txtCode.Text, True, False)

        F.EmpCode = Me.txtCode.Text
        F.Employee = Me.GlbEmp
        F.LoadMe()

    End Sub
    Public Sub PreviousEmployee_OnReminder(ByVal F As FrmPrMsReminder)
        GetEmployee(Me.txtCode.Text, False, False)

        F.EmpCode = Me.txtCode.Text
        F.Employee = Me.GlbEmp
        F.LoadMe()
    End Sub
    Public Sub NextEmployee_OnCovidTest(ByVal F As FrmPrTxEmployeeCovidTest)
        GetEmployee(Me.txtCode.Text, True, False)

        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text
        F.Employee = Me.GlbEmp

        F.LoadMe()

    End Sub
    Public Sub PreviousEmployee_OnCovidTest(ByVal F As FrmPrTxEmployeeCovidTest)
        GetEmployee(Me.txtCode.Text, False, False)
        F.Employee = Me.GlbEmp
        F.EmpCode = Me.txtCode.Text
        F.EmpName = Me.txtFullName.Text


        F.LoadMe()
    End Sub

    Private Sub GetEmployee(ByVal Code As String, ByVal NextEmp As Boolean, ByVal SameCode As Boolean)
        Dim ds As DataSet
        ds = Global1.Business.FindEmployeeOfUser(Code, NextEmp, Global1.UserName, SameCode)
        If CheckDataSet(ds) Then
            Dim Emp As New cPrMsEmployees(DbNullToString(ds.Tables(0).Rows(0).Item(0)))
            Me.txtCode.Text = Emp.Code
            Me.LoadEmployee(Emp, False)
        Else
            MsgBox("No Record Found", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            If txtCode.Text <> "" Then
                GetEmployee(Me.txtCode.Text, False, True)
            End If
        End If
    End Sub
    Private Sub Calculate_TIC_fromIDNumber(ByVal IDNumber As String)
        Dim Od_1 As Integer
        Dim Od_2 As Integer
        Dim Od_3 As Integer
        Dim Od_4 As Integer

        Dim Ev_1 As Integer
        Dim Ev_2 As Integer
        Dim Ev_3 As Integer
        Dim Ev_4 As Integer

        If IDNumber.Length > 8 Then
            MsgBox("ID Number Must Be Less Or Equeal than 8 digits")
        End If
        IDNumber = IDNumber.PadLeft(8, "0")

        Od_1 = IDNumber.Substring(0, 1)
        Ev_1 = IDNumber.Substring(1, 1)
        Od_2 = IDNumber.Substring(2, 1)
        Ev_2 = IDNumber.Substring(3, 1)
        Od_3 = IDNumber.Substring(4, 1)
        Ev_3 = IDNumber.Substring(5, 1)
        Od_4 = IDNumber.Substring(6, 1)
        Ev_4 = IDNumber.Substring(7, 1)

        Dim Ev_SUM As Integer = Ev_1 + Ev_2 + Ev_3 + Ev_4

        Od_1 = Get_Character_Value(Od_1)
        Od_2 = Get_Character_Value(Od_2)
        Od_3 = Get_Character_Value(Od_3)
        Od_4 = Get_Character_Value(Od_4)

        Dim Od_SUM As Integer = Od_1 + Od_2 + Od_3 + Od_4

        Dim Total_SUM As Integer = Od_SUM + Ev_SUM
        Dim IntPart As Integer
        Dim IntPart2 As Double
        'IntPart = Total_SUM / 26
        IntPart2 = Total_SUM / 26
        Dim AR() As String
        AR = IntPart2.ToString.Split(".")
        IntPart = AR(0)
        Dim Reminder As Integer
        Reminder = Math.Abs(Total_SUM - (IntPart * 26) + 1)

        Dim C As String
        C = ChrW(Reminder + 64)
        Dim TIC As String = IDNumber & C

        Me.txtTaxId.Text = TIC




    End Sub
    Private Function Get_Character_Value(ByVal Number As Integer) As Integer
        Dim RetNo As Integer
        Select Case Number
            Case 0
                RetNo = 1
            Case 1
                RetNo = 0
            Case 2
                RetNo = 5
            Case 3
                RetNo = 7
            Case 4
                RetNo = 9
            Case 5
                RetNo = 13
            Case 6
                RetNo = 15
            Case 7
                RetNo = 17
            Case 8
                RetNo = 19
            Case 9
                RetNo = 21

        End Select
        Return RetNo
    End Function
    Private Sub btnFindTIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTIC.Click
        If Me.txtIdentificationCard.Text <> "" Then
            If IsNumeric(Me.txtIdentificationCard.Text) Then
                Me.Calculate_TIC_fromIDNumber(Me.txtIdentificationCard.Text)
            Else
                MsgBox("ID Number Filed must be Numeric Field Not Greater than 8 digits", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Please Fill First ID Number field", MsgBoxStyle.Information)
        End If

    End Sub



    Private Sub UpdateEmployeesAfterEDCAddition()
        Dim EmpCode As String
        GetEmployee(Me.txtCode.Text, True, False)
        Do While txtCode.Text <> ""

            Application.DoEvents()
            If Me.txtCode.Text <> "" Then
                Me.TryToSave(False)
            End If
            EmpCode = Me.txtCode.Text
            GetEmployee(Me.txtCode.Text, True, False)
            If Me.txtCode.Text = EmpCode Then
                Exit Do
            End If

        Loop
    End Sub

    Private Sub MnuArchivePayslips_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuArchivePayslips.Click
        If Me.txtCode.Text <> "" Then
            Dim Emp As New cPrMsEmployees(Me.txtCode.Text)
            If Emp.Code <> "" Then
                Dim F As New FrmShowArchivePayroll
                F.CallBy = 1
                F.Owner = Me
                F.Emp = Emp
                F.Show()
            End If
        End If
    End Sub
    Public Sub PrintPayslip(ByVal Hdr As cPrTxTrxnHeader, ByVal Emp As cPrMsEmployees, ByVal Period As cPrMsPeriodCodes, ByVal SendToPrinter As Boolean, ByVal Export As Boolean, ByVal PayslipDir As String, Optional ByVal UseEncryption As Boolean = False)
        Dim ContinueWithPrinting = True


        Dim ReportToUse As String = GLB_PAYSLIPReport
        If Emp.MyPayslipReport <> "" Then
            ReportToUse = Emp.MyPayslipReport
        End If

        Cursor.Current = Cursors.WaitCursor

        If Hdr.Status = "POST" Or Hdr.Status = "CALC" Then
            Dim PrintInCurrency As Boolean = False
            If Hdr.Currency = "" Then
                Hdr.Currency = GlbCompany.CurSymbol
            End If
            If Hdr.Currency <> GlbCompany.CurSymbol Then
                Dim Ans As New MsgBoxResult
                Ans = MsgBox("Do you want to Print Payslip in currency " & Hdr.Currency, MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    PrintInCurrency = True
                End If
            End If
            Dim ds As DataSet
            ds = Global1.Business.REPORT_PreparePayslipFor(Emp, Period, Hdr, Now.Date, PrintInCurrency)

            'Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\Administrator\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Payslip")
            Me.Cursor = Cursors.Default

            If CheckDataSet(ds) Then
                If Not Export Then
                    Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", SendToPrinter)
                Else
                    Dim PayslipFileName As String
                    PayslipFileName = Emp.Code
                    If Global1.PARAM_PayslipNameOn Then
                        PayslipFileName = Emp.Code & "_" & Emp.FullName
                    End If

                    Dim ExportFile As String
                    If Not UseEncryption Then
                        ExportFile = PayslipDir & PayslipFileName & "_" & Period.Code & ".pdf"
                    Else
                        ExportFile = PayslipDir & PayslipFileName & "_" & Period.Code & "_t.pdf"
                    End If
                    Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, ExportFile)
                End If

            Else
                MsgBox("No records found to print.", MsgBoxStyle.Information)
            End If

        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub mnuEmployeeLoans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmployeeLoans.Click
        If Me.txtCode.Text <> "" Then
            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Loans", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim ds As DataSet
                Dim F As New FrmLoanTransaction
                F.EmpCode = Me.txtCode.Text
                F.Employee = tEmp
                Dim TempGrp As New cPrMsTemplateGroup(tEmp.TemGrp_Code)
                ds = Global1.Business.FindCurrentPeriod1(tEmp.TemGrp_Code)
                If CheckDataSet(ds) Then
                    Dim Per As New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
                    F.GlbTmpGrp = TempGrp
                    F.PeriodCode = Per.Code
                    F.PeriodGroup = Per.PrdGrpCode
                    F.Owner = Me
                    F.ShowDialog()
                End If
            End If
        End If

    End Sub



    Private Sub mnuEmployeeSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmployeeSplit.Click
        If Me.txtCode.Text <> "" Then

            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Split", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim F As New FrmPrSsEmployeeSplit
                F.EmpCode = Me.txtCode.Text
                F.Employee = tEmp
                F.Owner = Me
                F.ShowDialog()
            End If
        End If
    End Sub




    Private Sub CBNewEmployee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNewEmployee.CheckedChanged
        If Me.CBNewEmployee.CheckState = CheckState.Checked Then
            Me.CBNewEmployee.ForeColor = Color.Red
            Me.lblCode.ForeColor = Color.Red
            Me.lblFullName.ForeColor = Color.Red
        Else
            Me.CBNewEmployee.ForeColor = Color.Black
            Me.lblCode.ForeColor = Color.Black
            Me.lblFullName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BtnEmploymentHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New FrmEmployeeHistory
        F.ShowWhat = 1
        F.EmpCode = Me.txtCode.Text
        F.ShowDialog()

    End Sub

    Private Sub btnPositionHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPositionHistory.Click
        Dim F As New FrmEmployeeHistory
        F.ShowWhat = 2
        F.EmpCode = Me.txtCode.Text
        F.ShowDialog()

    End Sub

    Private Sub lblBankAccountCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBankAccountCo.Click
        Dim Emp As New cPrMsEmployees
        Emp = GetDetailsFromPrevious(Me.txtCode.Text)
        If Not Emp.Code Is Nothing Then
            If Emp.Code <> "" Then
                Me.txtBankAccountCo.Text = Emp.BankAccountCo
            End If
        End If
    End Sub
    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click
        Dim Emp As New cPrMsEmployees
        Emp = GetDetailsFromPrevious(Me.txtCode.Text)
        If Not Emp.Code Is Nothing Then
            If Emp.Code <> "" Then
                Me.txtPayslipreport.Text = Emp.MyPayslipReport
            End If
        End If
    End Sub
    Private Sub lblComSin_EmpSocialInsNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblComSin_EmpSocialInsNo.Click
        Dim Emp As New cPrMsEmployees
        Emp = GetDetailsFromPrevious(Me.txtCode.Text)
        If Not Emp.Code Is Nothing Then
            If Emp.Code <> "" Then
                Me.txtComSin_EmpSocialInsNo.Text = Emp.ComSin_EmpSocialInsNo
            End If
        End If
    End Sub
    Private Sub lblBnk_CodeCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBnk_CodeCo.Click
        Dim Emp As New cPrMsEmployees
        Emp = GetDetailsFromPrevious(Me.txtCode.Text)
        If Not Emp.Code Is Nothing Then
            If Emp.Code <> "" Then
                Dim CoBank As New cPrAnBanks(Emp.Bnk_CodeCo)
                Me.cmbBnk_CodeCo.SelectedIndex = cmbBnk_CodeCo.FindStringExact(CoBank.ToString)
            End If
        End If
    End Sub
    Private Function GetDetailsFromPrevious(ByVal Code As String) As cPrMsEmployees
        Dim Emp As New cPrMsEmployees
        Dim ds As DataSet
        ds = Global1.Business.FindEmployeeOfUser(Code, False, Global1.UserName, False)
        If CheckDataSet(ds) Then
            Emp = New cPrMsEmployees(DbNullToString(ds.Tables(0).Rows(0).Item(0)))
        Else
            MsgBox("No Previous Employee Record Found to copy from !", MsgBoxStyle.Information)
        End If
        Return Emp
    End Function
    Private Sub mnuGDPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGDPR.Click
        GDPR()
    End Sub
    Private Sub GDPR()
        If Me.txtCode.Text <> "" Then
            Dim Emp As New cPrMsEmployees(Me.txtCode.Text)
            If Emp.Code <> "" Then
                Dim D As Date
                If Emp.TerminateDate <> "" Then
                    If Emp.Status = "I" Then
                        D = CDate(Emp.TerminateDate)
                        Dim YearsDifference As Integer
                        YearsDifference = DateDiff(DateInterval.Year, Now, D)
                        If YearsDifference >= -1 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("Termination date of employee was last year - " & D.Year & ". Please ensure that you have submited all Legal documents (IR7,IR63 etc) before proceding. Proceed ?", MsgBoxStyle.YesNoCancel)
                            If Ans = MsgBoxResult.Yes Then
                                Dim Ans2 As MsgBoxResult
                                Ans2 = MsgBox("Are you sure ? ", MsgBoxStyle.YesNo)
                                If Ans2 = MsgBoxResult.Yes Then

                                    Me.txtFirstName.Text = Me.txtCode.Text
                                    Me.txtLastName.Text = "*** GDPR ***"
                                    If Trim(Me.txtAddress1.Text) <> "" Then
                                        Me.txtAddress1.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtAddress2.Text) <> "" Then
                                        Me.txtAddress2.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtAddress3.Text) <> "" Then
                                        Me.txtAddress3.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtTelephone1.Text) <> "" Then
                                        Me.txtTelephone1.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtTelephone2.Text) <> "" Then
                                        Me.txtTelephone2.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtPostCode.Text) <> "" Then
                                        Me.txtPostCode.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtEmail.Text) <> "" Then
                                        Me.txtEmail.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtEmail2.Text) <> "" Then
                                        Me.txtEmail2.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtPassword.Text) <> "" Then
                                        Me.txtPassword.Text = "*** GDPR ***"
                                    End If

                                    If Trim(Me.txtBankAccount.Text) <> "" Then
                                        Me.txtBankAccount.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtEmployeeIBAN.Text) <> "" Then
                                        Me.txtEmployeeIBAN.Text = "*** GDPR ***"
                                    End If

                                    If Trim(Me.txtIdentificationCard.Text) <> "" Then
                                        Me.txtIdentificationCard.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtSocialInsNumber.Text) <> "" Then
                                        Me.txtSocialInsNumber.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtTaxId.Text) <> "" Then
                                        Me.txtTaxId.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtOhterCountryTIC.Text) <> "" Then
                                        Me.txtOhterCountryTIC.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtAlienNumber.Text) <> "" Then
                                        Me.txtAlienNumber.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtPensionNo.Text) <> "" Then
                                        Me.txtPensionNo.Text = "*** GDPR ***"
                                    End If
                                    If Trim(Me.txtPassportNumber.Text) <> "" Then
                                        Me.txtPassportNumber.Text = "*** GDPR ***"
                                    End If

                                    If Emp.Save Then
                                        MsgBox("GDPR Changes are Completed", MsgBoxStyle.Information)
                                    Else
                                        MsgBox("Unable to Proceed with GDPR Changes", MsgBoxStyle.Critical)
                                    End If
                                End If
                            End If
                        End If

                        If YearsDifference >= 0 Then
                            MsgBox("Employee Termination is within the current year, Legaly we cannot apply GDPR regulations (IR7 submition)", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("Employee Status is not 'INACTIVE', cannot proceed", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Employee is not Terminated", MsgBoxStyle.Information)
                End If


            Else
                MsgBox("Employee Not Found", MsgBoxStyle.Critical)
            End If

        End If

    End Sub


    Private Sub ChangeCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCodeToolStripMenuItem.Click
        Dim F As New FrmChangeEmployeeCode

        F.OldCode = Me.txtCode.Text
        F.Owner = Me
        F.ShowDialog()

    End Sub

    Public Sub CalledFromChangeCode()
        Me.ClearMe()
    End Sub

    Private Sub ImportExtraBonusOnSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportExtraBonusOnSalaryToolStripMenuItem.Click
        ImportExtraBonusOnsalary()
    End Sub
    Private Sub ImportExtraBonusOnsalary()
        Dim ans1 As New MsgBoxResult
        ans1 = MsgBox("This action Imports Basic Salary on Employee Card. Continue ?", MsgBoxStyle.YesNoCancel)
        If ans1 <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Cursor.Current = Cursors.WaitCursor

        If Global1.PARAM_ETFilePath <> "" Then
            ''''''''''''''''''''''''''''''''''''''''''
            Dim Files() As String
            Dim i As Integer
            Dim Line As String = String.Empty
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileDir As String
            Me.Refresh()
            counter = 0
            '''
            FileDir = Global1.PARAM_ETFilePath
            Files = IO.Directory.GetFiles(FileDir)
            Me.Refresh()
            Dim EmpCode As String
            Dim sBonusOnSalary As String

            Dim DBL_BonusOnSalary As Double


            Dim AtLeast1 As Boolean = False

            If Files.Length = 0 Then
                MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                Cursor.Current = Cursors.Default
                Exit Sub

            End If

            For i = 0 To Files.Length - 1
                Me.Refresh()
                FileName = Files(i)
                Try
                    Dim Exx As New Exception
                    param_file = IO.File.OpenText(FileName)
                    LoadedOK = False
                    Do While param_file.Peek <> -1
                        Me.Refresh()
                        Dim Ar() As String
                        counter = counter + 1
                        Line = param_file.ReadLine()
                        Ar = Line.Split("	")
                        EmpCode = Ar(0).Replace("""", "")
                        sBonusOnSalary = Ar(18).Replace("""", "")


                        If sBonusOnSalary = "" Then
                            DBL_BonusOnSalary = 0
                        Else
                            DBL_BonusOnSalary = CDbl(sBonusOnSalary)
                        End If




                        Dim Emp As New cPrMsEmployees(EmpCode)
                        If Emp.Code = "" Then
                            Dim Ans As New MsgBoxResult
                            'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                            Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then

                                param_file.Close()
                                param_file.Dispose()
                                If AtLeast1 Then
                                    MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                End If
                                Cursor.Current = Cursors.Default
                                Exit Sub
                            End If
                        Else
                            AtLeast1 = True
                            If Not Global1.Business.UpdateEmployeeBonusOnSalary(Emp.Code, DBL_BonusOnSalary) Then
                                Throw Exx
                            End If
                        End If
                    Loop
                    If AtLeast1 Then
                        MsgBox("Loading Extra Basis on Salary Procedure has finished", MsgBoxStyle.Information)
                    End If
                    param_file.Close()
                    param_file.Dispose()
                Catch ex As Exception
                    Utils.ShowException(ex)
                    MsgBox("Unable to Load Extra Basis On Salary File", MsgBoxStyle.Critical)
                    param_file.Close()
                    param_file.Dispose()
                End Try
            Next

            MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

        Else
            MsgBox("Excel Template file Path is missing, please contact iNsoft Limited!", MsgBoxStyle.Critical)
        End If

        Cursor.Current = Cursors.Default

    End Sub



    Private Sub CopyEmployee()
        CopyEmp = New cPrMsEmployees(Me.txtCode.Text)


        Dim DsPer As DataSet
        DsPer = Global1.Business.FindCurrentPeriod1(CopyEmp.TemGrp_Code)
        Dim GLBCurrentPeriod As New cPrMsPeriodCodes

        If CheckDataSet(DsPer) Then
            GLBCurrentPeriod = New cPrMsPeriodCodes(DsPer.Tables(0).Rows(0))
        End If
        Dim FromDate As Date
        Dim ToDate As Date

        FromDate = CDate(GLBCurrentPeriod.DateFrom.Year & "/" & "01/01")
        ToDate = CDate(GLBCurrentPeriod.DateFrom.Year & "/" & "12/31")




        CopyDsSalary = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCodeForCopy(Me.txtCode.Text)
        CopyDsAnnualLeave = Global1.Business.GetAllPrTxEmployeeLeaveByEmpCodeForCopy(Me.txtCode.Text, FromDate, ToDate)
        CopyDsDiscounts = Global1.Business.GetAllPrTxEmployeeDiscountsForCopy(Me.txtCode.Text, GLBCurrentPeriod.PrdGrpCode)
        CopyDsReminders = Global1.Business.GetAllPrMsEmployeeRemindersForCopy(Me.txtCode.Text, GLBCurrentPeriod.PrdGrpCode)

    End Sub

    Private Sub PasteEmployee()
        Dim Exx As New System.Exception
        If CopyEmp.Code <> "" Then
            Me.LoadEmployee(CopyEmp, True)
        End If
    End Sub


    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CopyEmployee()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        PasteEmployee()
    End Sub

    Private Sub PasteToDifferentDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToDifferentDatabaseToolStripMenuItem.Click

        Dim Previous_MF As Double
        Dim Previous_PF As Double
        Dim Previous_PenF As Double
        Dim Previous_SI As Double
        Dim Previous_Earnings As Double
        Dim Previous_ITValue As Double
        Dim Previous_LifeInsurance As Double
        Dim Previous_Discounts As Double
        Dim Previous_ST As Double
        Dim Previous_GESY As Double


        Dim ToDate_MF As Double
        Dim ToDate_PF As Double
        Dim ToDate_DN As Double
        Dim ToDate_PenF As Double
        Dim ToDate_WidF As Double
        Dim ToDate_SI As Double
        Dim ToDate_Union As Double
        Dim ToDate_Tax As Double
        Dim ToDate_GESY As Double

        Dim EarningsToDate As Double
        Dim LifeIns_Todate As Double
        Dim Discounts_Todate As Double
        Dim insurableToDate As Double
        Dim FE_Todate As Double

        Dim DsPer As DataSet
        DsPer = Global1.Business.FindCurrentPeriod1(CopyEmp.TemGrp_Code)
        Dim GLBCurrentPeriod As New cPrMsPeriodCodes

        If CheckDataSet(DsPer) Then
            GLBCurrentPeriod = New cPrMsPeriodCodes(DsPer.Tables(0).Rows(0))
        End If



        If CopyEmp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
            'Previous_SI_PF_MF = Emp.Emp_PrevSIDeduct + Emp.Emp_PrevPFDeduct
            Previous_SI = CopyEmp.Emp_PrevSIDeduct
            Previous_PF = CopyEmp.Emp_PrevPFDeduct
            Previous_MF = CopyEmp.PrevMedFund
            Previous_PenF = CopyEmp.PrevPensionFund


            Previous_Earnings = CopyEmp.PreviousEarnings
            Previous_ITValue = CopyEmp.Emp_PrevITDeduct
            Previous_LifeInsurance = CopyEmp.PreviousLifeIns
            Previous_Discounts = CopyEmp.PreviousDis
            Previous_ST = CopyEmp.PreviousST

            Previous_GESY = CopyEmp.PreviousGesiD
        End If


        'Calculate Previous




        ToDate_MF = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "MF")
        ToDate_PF = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "PF")
        ToDate_DN = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "DN")
        ToDate_PenF = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "PN")
        ToDate_WidF = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "WO")
        ToDate_SI = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "SI")
        ToDate_Union = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "US")
        ToDate_Tax = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "IT")

        ToDate_GESY = Global1.Business.GetToDate_SI_PF_MF(CopyEmp, GLBCurrentPeriod, "GD")




        Dim ds As DataSet
        ds = Global1.Business.GetLifeInsurance_AND_Discounts_ToDate(CopyEmp, GLBCurrentPeriod)
        If CheckDataSet(ds) Then
            EarningsToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(0))
            LifeIns_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(1))
            Discounts_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(2))
            insurableToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(3))
            FE_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(4))
            Discounts_Todate = Discounts_Todate + FE_Todate
        End If

        With CopyEmp

            CopyEmp.Emp_PrevSIDeduct = Previous_SI + ToDate_SI
            CopyEmp.Emp_PrevPFDeduct = Previous_PF + ToDate_PF
            CopyEmp.PrevMedFund = Previous_MF + ToDate_MF
            CopyEmp.PrevPensionFund = Previous_PenF + ToDate_PenF
            CopyEmp.PreviousEarnings = Previous_Earnings + EarningsToDate
            CopyEmp.Emp_PrevITDeduct = Previous_ITValue + ToDate_Tax
            CopyEmp.PreviousLifeIns = Previous_LifeInsurance + LifeIns_Todate
            CopyEmp.PreviousDis = Previous_Discounts + Discounts_Todate
            CopyEmp.PreviousGesiD = Previous_GESY + ToDate_GESY


        End With




        Dim F As New FrmPasteToDiffDB
        F.Employee = CopyEmp
        F.DsSalary = CopyDsSalary
        F.DsAL = CopyDsAnnualLeave
        F.DsDiscounts = CopyDsDiscounts


        F.ShowDialog()
    End Sub

    Private Sub NewEmployeeSIRegFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewEmployeeSIRegFormToolStripMenuItem.Click

        'Dim ds As New DataSet
        Dt1.Rows.Clear()



        Dim Emp As New cPrMsEmployees(Me.txtCode.Text)
        If Emp.Code <> "" Then



            Dim Temp As New cPrMsTemplateGroup(Emp.TemGrp_Code)
            Dim Comp As New cAdMsCompany(Temp.CompanyCode)



            Dim CompanyName As String
            Dim CompanyPhone As String
            Dim CompanyFax As String

            CompanyName = Comp.Name
            CompanyPhone = Comp.Tel1
            CompanyFax = Comp.Fax1


            Dim PositionDesc As String
            Dim CommunityDesc As String
            Dim Pos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
            Dim Community As New cPrAnEmployeeCommunity(Emp.EmpCmm_Code)

            PositionDesc = Pos.DescriptionL
            CommunityDesc = Community.DescriptionL
            Dim r As DataRow = Dt1.NewRow()
            With Emp



                r(0) = .IdentificationCard
                r(1) = .AlienNumber
                r(2) = .PassportNumber
                r(3) = "" 'Dt1.Columns.Add("Nationality", System.Type.GetType("System.String"))
                r(4) = "" '1Dt1.Columns.Add("OtherCountryIns", System.Type.GetType("System.String"))
                r(5) = UCase(.FullName)
                r(6) = UCase(.Address1)
                r(7) = UCase(.Address3)
                r(8) = UCase(.Address2)
                r(9) = .PostCode
                r(10) = .Telephone1
                r(11) = Format(.BirthDate, "dd/MM/yyyy")
                r(12) = "" 'Dt1.Columns.Add("PlaceOfBirth", System.Type.GetType("System.String"))
                r(13) = UCase(CommunityDesc) 'Dt1.Columns.Add("Community", System.Type.GetType("System.String"))
                Dim SEX As String
                If .Sex = "M" Then
                    SEX = "Á"
                Else
                    SEX = "È"
                End If
                r(14) = SEX

                r(15) = "" 'Dt1.Columns.Add("Maried", System.Type.GetType("System.String"))
                r(16) = "" 'Dt1.Columns.Add("NotMaried", System.Type.GetType("System.String"))
                r(17) = "" 'Dt1.Columns.Add("Widow", System.Type.GetType("System.String"))
                r(18) = "" 'Dt1.Columns.Add("Divorced", System.Type.GetType("System.String"))
                If .MarSta_Code = "M" Then
                    r(15) = "X" 'Dt1.Columns.Add("Maried", System.Type.GetType("System.String"))
                End If
                If .MarSta_Code = "S" Then
                    r(16) = "X" 'Dt1.Columns.Add("NotMaried", System.Type.GetType("System.String"))
                End If
                If .MarSta_Code = "W" Then
                    r(17) = "X" 'Dt1.Columns.Add("Widow", System.Type.GetType("System.String"))
                End If
                If .MarSta_Code = "D" Then
                    r(18) = "X" 'Dt1.Columns.Add("Divorced", System.Type.GetType("System.String"))
                End If

                r(19) = UCase(PositionDesc)
                r(20) = Format(.StartDate, "dd/MM/yyyy")
                r(21) = UCase(CompanyName) 'Dt1.Columns.Add("CompanyName", System.Type.GetType("System.String"))
                r(22) = .ComSin_EmpSocialInsNo
                r(23) = CompanyPhone 'Dt1.Columns.Add("CompanyPhone", System.Type.GetType("System.String"))
                r(24) = CompanyFax 'Dt1.Columns.Add("CompanyFax", System.Type.GetType("System.String"))

            End With

            Dt1.Rows.Add(r)
            'Utils.WriteSchemaWithXmlTextWriter(MyDs, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - RND\NodalPay\XML\SINewReg")
            Utils.ShowReport("SINewRegistration.rpt", MyDs, FrmReport, "Social Insurance New Employee Part 1", False)
            Utils.ShowReport("SINewRegistration2.rpt", MyDs, FrmReport, "Social Insurance New Employee Part 2", False)
        End If

    End Sub
    Private Sub InitNewSIRegReport()

    End Sub
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)

    End Sub
    Private Sub InitDatatable()

        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("IDNo", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("AlienNo", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("PassPortNo", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Nationality", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("OtherCountryIns", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("FullName", System.Type.GetType("System.String"))
        '6
        Dt1.Columns.Add("Adr1", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("Adr2", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("City", System.Type.GetType("System.String"))
        '9
        Dt1.Columns.Add("PostCode", System.Type.GetType("System.String"))
        '10
        Dt1.Columns.Add("Phone", System.Type.GetType("System.String"))
        '11
        Dt1.Columns.Add("DOB", System.Type.GetType("System.String"))
        '12
        Dt1.Columns.Add("PlaceOfBirth", System.Type.GetType("System.String"))
        '13
        Dt1.Columns.Add("Community", System.Type.GetType("System.String"))
        '14
        Dt1.Columns.Add("SEX", System.Type.GetType("System.String"))
        '15
        Dt1.Columns.Add("Maried", System.Type.GetType("System.String"))
        '16
        Dt1.Columns.Add("NotMaried", System.Type.GetType("System.String"))
        '17
        Dt1.Columns.Add("Widow", System.Type.GetType("System.String"))
        '18
        Dt1.Columns.Add("Divorced", System.Type.GetType("System.String"))
        '19
        Dt1.Columns.Add("Position", System.Type.GetType("System.String"))
        '20
        Dt1.Columns.Add("StartDate", System.Type.GetType("System.String"))
        '21
        Dt1.Columns.Add("CompanyName", System.Type.GetType("System.String"))
        '22
        Dt1.Columns.Add("CompanySIReg", System.Type.GetType("System.String"))
        '23
        Dt1.Columns.Add("CompanyPhone", System.Type.GetType("System.String"))
        '24
        Dt1.Columns.Add("CompanyFax", System.Type.GetType("System.String"))

    End Sub


    Private Sub Excel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim F As New frmPrAnEmployeeAnalysis1
        F.MdiParent = Me.MdiParent
        F.Show()

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim F As New frmPrAnEmployeeAnalysis2
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim F As New frmPrAnEmployeeAnalysis3
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim F As New frmPrAnEmployeeAnalysis4
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim F As New frmPrAnEmployeeAnalysis5
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim F As New frmPrAnUnions
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New frmPrSsProvidentFund
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim f As New frmPrSsMedicalFund
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim f As New frmPrSsSocialInsurance
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As New FrmPrSsIndustrial
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim f As New FrmPrSsUnemployment
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim f As New FrmPrSsSocialCohesion
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim f As New FrmPrSsGesi
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim f As New frmPrAnEmployeePositions
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Dim F As New frmPrAnBanks
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        Dim F As New frmPrAnBanks
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub
    Private Sub ChangeIBANNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeIBANNumberToolStripMenuItem.Click
        Dim F As New FrmChangeIBANNumber
        F.ShowDialog()

    End Sub

    Private Sub ChangeEmployeePayslipReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeEmployeePayslipReportToolStripMenuItem.Click
        Dim F As New FrmChangeEmployeePayslip
        F.ShowDialog()
    End Sub

    Private Sub ReplaceEDCValueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceEDCValueToolStripMenuItem.Click

        If Me.txtCode.Text = "" Then
            MsgBox("Please Select Employee for the Template Group that you want the change to occur", MsgBoxStyle.Information)
        Else
            Dim F As New FrmReplaceEDCValue
            F.TempCode = Me.GLBTempGroup.Code
            F.ShowDialog()
        End If


    End Sub

    Private Sub btnCreateEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateEmployees.Click
        Try

            Dim exx As New System.Exception
            Dim i As Integer

            For i = 0 To 15
                NewClick()
                Me.txtCode.Text = (1 + i).ToString.PadLeft(4, "0")
                Me.txtTitle.Text = "Mr"
                Me.txtFirstName.Text = "Name"
                Me.txtLastName.Text = "Lastname " & i + 1
                Me.DateStart.Value = CDate("2019-01-01")
                Me.txtComSin_EmpSocialInsNo.Text = "1234567/1/4321"
                Me.txtBankAccountCo.Text = "12345678910"
                Me.txtBankAccount.Text = (i + 1).ToString.PadLeft(2, "0") & "99887766"
                Me.txtPayslipreport.Text = "Payslip15.rpt"
                Me.txtAddress1.Text = "No Name Street"
                Me.txtAddress2.Text = "Nicosia"
                Me.txtPostCode.Text = "1099"




                Me.TryToSave(False)


                Dim EmpSal As New cPrTxEmployeeSalary
                With EmpSal
                    .Id = 0
                    .Emp_Code = Me.txtCode.Text
                    .Date1 = Now
                    .SalaryValue = 2000 + (i * 150)
                    .Basic = 0
                    .EffPayDate = CDate("2019-01-01")
                    .Cola = 0
                    .EffArrearsDate = CDate("2019-01-01")
                    .Usr_Id = Global1.GLBUserId
                    .myRate = 0
                    .IsCola = "N"
                    .EmpSal_Dif = 0
                    If Not .Save() Then
                        Throw exx
                    End If
                End With

            Next
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub


    Private Sub GoToCalculationForm()

        If Me.txtCode.Text <> "" Then
            Dim F As New FrmPayroll1
            F.CalledByEmployee = True
            F.CalledByEmployee_TemplateGroup = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code
            F.CalledByEmployee_TemplateGroupToString = Me.cmbTemGrp_Code.SelectedItem.ToString
            F.CalledByEmployee_EmployeeCode = Me.txtCode.Text
            F.MdiParent = Me.MdiParent
            F.Show()
        Else
            MsgBox("Please select valid Employee Code", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub TSBPayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPayroll.Click
        GoToCalculationForm()
    End Sub

    Private Sub UpdateEmployeesAfterEDCAdditionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEmployeesAfterEDCAdditionToolStripMenuItem.Click
        UpdateEmployeesAfterEDCAddition()
    End Sub

    Private Sub ChangeCompanyBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompanyBankToolStripMenuItem.Click
        If Me.txtCode.Text <> "" Then
            Dim Emp As New cPrMsEmployees(Me.txtCode.Text)
            If Emp.Code <> "" Then
                Dim F As New FrmChangeCompanyBank
                F.Owner = Me
                F.TempGroupCode = Emp.TemGrp_Code
                F.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim i As Integer
        For i = 0 To 300
            GetEmployee(Me.txtCode.Text, True, False)
            If Me.CBNewEmployee.CheckState = CheckState.Checked Then
                tPrMsEmployees.Delete(Trim(Me.txtCode.Text))
            End If
        Next
    End Sub

    'Private Sub TToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TToolStripMenuItem.Click
    '    Dim Exx As New SystemException

    '    Dim EmpCode As String
    '    GetEmployee(Me.txtCode.Text, True, False)
    '    Do While txtCode.Text <> ""

    '        Application.DoEvents()
    '        If Me.txtCode.Text <> "" Then
    '            Dim Ds As DataSet
    '            Ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(Trim(Me.txtCode.Text))
    '            If Not CheckDataSet(Ds) Then
    '                Dim X As New cPrTxEmployeeSalary(Trim(Me.txtCode.Text))
    '                If X.Id = 0 Then
    '                    With X
    '                        .Id = 0
    '                        .Emp_Code = Me.txtCode.Text
    '                        .Date1 = Now
    '                        .SalaryValue = CDbl(0)
    '                        .Basic = CDbl(0)
    '                        .EffPayDate = Now.Date
    '                        .Cola = CDbl(0)
    '                        .EffArrearsDate = Now.Date
    '                        .Usr_Id = Global1.GLBUserId
    '                        .myRate = 0
    '                        .IsCola = "N"
    '                        .EmpSal_Dif = 0
    '                        If Not .Save() Then
    '                            Throw Exx
    '                        End If
    '                    End With

    '                End If
    '            End If
    '        End If
    '        EmpCode = Me.txtCode.Text
    '        GetEmployee(Me.txtCode.Text, True, False)
    '        If Me.txtCode.Text = EmpCode Then
    '            Exit Do
    '        End If

    '    Loop

    'End Sub


    Private Sub btnUpdatesalaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSalaries.Click
        Dim F As New FrmUpdateSalaries
        F.Owner = Me
        F.ShowDialog()

    End Sub
    Public Sub UpdateSalaries(ByVal Perc As Double, ByVal EffDate As Date)
        Try
            Dim Exx As New System.Exception
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("With this action all salaries will be changed by " & Perc & " %, Procced ? ", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                Dim EmpCode As String
                GetEmployee(Me.txtCode.Text, True, False)
                Do While txtCode.Text <> ""

                    Application.DoEvents()
                    If Me.txtCode.Text <> "" Then
                        Dim Sal As New cPrTxEmployeeSalary
                        Sal = Global1.Business.GetCurrentSalary(txtCode.Text, Now.Date)
                        With Sal
                            Dim Diff As Double
                            Dim OldSalValue As Double
                            OldSalValue = Sal.SalaryValue
                            .Id = 0
                            .Emp_Code = Me.txtCode.Text
                            .Date1 = Now
                            .SalaryValue = RoundMe2(.SalaryValue + (.SalaryValue * Perc / 100), 2)
                            Diff = .SalaryValue - OldSalValue
                            .Basic = 0
                            .EffPayDate = EffDate
                            .Cola = 0
                            .EffArrearsDate = EffDate
                            .Usr_Id = Global1.GLBUserId
                            .myRate = 0
                            .IsCola = "N"
                            .EmpSal_Dif = Diff
                            If Not .Save Then
                                MsgBox("Error calculating Salary for employee with Code " & Me.txtCode.Text)

                                Throw (Exx)
                            End If

                        End With
                    End If
                    EmpCode = Me.txtCode.Text
                    GetEmployee(Me.txtCode.Text, True, False)
                    If Me.txtCode.Text = EmpCode Then
                        Exit Do
                    End If

                Loop
                MsgBox("Finish")

            End If
        Catch ex As Exception

        End Try

    End Sub
   

    Private Sub mnuReminders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReminders.Click
        Dim F As New FrmPrMsReminder
        F.Owner = Me
        F.Employee = Me.GlbEmp
        F.EmpCode = Me.GlbEmp.Code
        F.ShowDialog()

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        LoadPrAnEmployeeAnalysis1()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpAn1_Code.SelectedIndex = cmbEmpAn1_Code.FindString(GlbEmp.EmpAn1_Code & " - ")
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        LoadPrAnEmployeeAnalysis2()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpAn2_Code.SelectedIndex = cmbEmpAn2_Code.FindString(GlbEmp.EmpAn2_Code & " - ")
        End If
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        LoadPrAnEmployeeAnalysis3()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpAn3_Code.SelectedIndex = cmbEmpAn3_Code.FindString(GlbEmp.EmpAn3_Code & " - ")
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        LoadPrAnEmployeeAnalysis4()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpAn4_Code.SelectedIndex = cmbEmpAn4_Code.FindString(GlbEmp.EmpAn4_Code & " - ")
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        LoadPrAnEmployeeAnalysis5()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpAn5_Code.SelectedIndex = cmbEmpAn5_Code.FindString(GlbEmp.EmpAn5_Code & " - ")
        End If
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Me.LoadPrAnUnions()
        If GlbEmp.Code <> "" Then
            Me.cmbUni_Code.SelectedIndex = cmbUni_Code.FindString(GlbEmp.Uni_Code & " - ")
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        LoadPrAnEmployeePositions()
        If GlbEmp.Code <> "" Then
            Me.cmbEmpPos_Code.SelectedIndex = cmbEmpPos_Code.FindString(GlbEmp.EmpPos_Code & " - ")
        End If

    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        LoadProvidentFund()
        If GlbEmp.Code <> "" Then
            Me.ComboProFund.SelectedIndex = ComboProFund.FindString(GlbEmp.ProFnd_Code & " - ")
        End If
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        LoadMedicalFund()
        If GlbEmp.Code <> "" Then
            Me.ComboMedicalFund.SelectedIndex = ComboMedicalFund.FindString(GlbEmp.MedFnd_Code & " - ")
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        LoadSocialInsurance()
        If GlbEmp.Code <> "" Then
            Me.ComboSocialIns.SelectedIndex = ComboSocialIns.FindString(GlbEmp.SocInc_Code & " - ")
        End If
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        LoadIndustrial()
        If GlbEmp.Code <> "" Then
            Me.ComboIndustrial.SelectedIndex = ComboIndustrial.FindString(GlbEmp.Ind_Code & " - ")
        End If
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        LoadUnemployment()
        If GlbEmp.Code <> "" Then
            Me.ComboUnemployment.SelectedIndex = ComboUnemployment.FindString(GlbEmp.Une_Code & " - ")
        End If
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        LoadSocialCohesion()
        If GlbEmp.Code <> "" Then
            Me.ComboSocialCohesion.SelectedIndex = ComboSocialCohesion.FindString(GlbEmp.SocCoh_Code & " - ")
        End If
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        LoadGesi()
        If GlbEmp.Code <> "" Then
            Me.ComboGESI.SelectedIndex = ComboGESI.FindString(GlbEmp.GESICode & " - ")
        End If
    End Sub

    Private Sub EEA31ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EEA31ToolStripMenuItem.Click
        Covid19Report1()
    End Sub

    Private Sub EEA32ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EEA32ToolStripMenuItem.Click
        Covid19Report2()
    End Sub
    Private Sub Covid19Report1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllEmployeesOfUser(UserName)
        If Not CheckDataSet(ds) Then
            MsgBox("No Record Found", MsgBoxStyle.Information)
        Else
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            HeaderStr.Add("Template Group")
            HeaderStr.Add("Code")
            HeaderStr.Add("Last Name")
            HeaderStr.Add("First Name")
            HeaderStr.Add("Date Of Birth")
            HeaderStr.Add("Soc.Ins. Number")
            HeaderStr.Add("ID")
            HeaderStr.Add("Alien Number")
            HeaderStr.Add("Employment Date")

            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)

            Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
        End If

    End Sub
    Private Sub Covid19Report2()
        Dim ds As DataSet
        ds = Global1.Business.GetAllEmployeesOfUserByDepartmentWithSalary_1(UserName)
        If Not CheckDataSet(ds) Then
            MsgBox("No Record Found", MsgBoxStyle.Information)
        Else
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader




            HeaderStr.Add("Template Group")
            HeaderStr.Add("Department Code")
            HeaderStr.Add("Department")
            HeaderStr.Add("Code")
            HeaderStr.Add("Last Name")
            HeaderStr.Add("First Name")
            HeaderStr.Add("Employment Date")
            HeaderStr.Add("Date Of Birth")
            HeaderStr.Add("Soc.Ins. Number")
            HeaderStr.Add("ID")
            HeaderStr.Add("Alien Number")
            HeaderStr.Add("Phone 1")
            HeaderStr.Add("Phone 2")
            HeaderStr.Add("SI Category")
            HeaderStr.Add("Salary")

            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)

            Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
        End If

    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        LoadPrAnBanks()
        LoadPrAnBanks_Bnk_CodeCo()
        If GlbEmp.Code <> "" Then
            Me.cmbBnk_Code.SelectedIndex = cmbBnk_Code.FindString(GlbEmp.Bnk_Code & " - ")
            Me.cmbBnk_CodeCo.SelectedIndex = cmbBnk_CodeCo.FindString(GlbEmp.Bnk_CodeCo & " - ")
        End If
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        LoadPrAnBanks()
        LoadPrAnBanks_Bnk_CodeCo()
        If GlbEmp.Code <> "" Then
            Me.cmbBnk_Code.SelectedIndex = cmbBnk_Code.FindString(GlbEmp.Bnk_Code & " - ")
            Me.cmbBnk_CodeCo.SelectedIndex = cmbBnk_CodeCo.FindString(GlbEmp.Bnk_CodeCo & " - ")
        End If
    End Sub



    Private Sub BtnChangeTempGroupIntransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeTempGroupIntransactions.Click
        Dim F As New FrmChangeTemplateGroupInTrxnHeader
        F.Emp = Me.GlbEmp
        F.ShowDialog()
    End Sub

    Private Sub ChangeCompanyBankCodeIBANBasedOnEmployeeBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompanyBankCodeIBANBasedOnEmployeeBankToolStripMenuItem.Click
        If Me.txtCode.Text <> "" Then
            Dim Emp As New cPrMsEmployees(Me.txtCode.Text)
            If Emp.Code <> "" Then
                Dim F As New FrmChangeCompanyBankIBANBasedOnempBank
                F.Owner = Me
                F.TempGroupCode = Emp.TemGrp_Code
                F.ShowDialog()
            End If
        Else
            MsgBox("Please select an employee of the template group you want to make changes", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub EmployeesWithSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesWithSalaryToolStripMenuItem.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDatasetToExcel2(False)
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeesWithSalaryDiscountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesWithSalaryDiscountsToolStripMenuItem.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDatasetToExcel2(True)
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNextAvailable.Click
        If Me.txtCode.ReadOnly = False Then
            Dim NextCode As String
            Dim TemplateGroup As String
            Dim P As String
            P = Me.txtCode.Text
            TemplateGroup = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code

            NextCode = Global1.Business.GetNextAvailableCode(P, TemplateGroup)
            If NextCode <> "" Then
                Me.txtCode.Text = NextCode
            End If


        End If
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        Dim F As New frmAdAnCountries
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

    Private Sub Button34_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        Me.LoadAdAnCountries()
        If GlbEmp.Code <> "" Then
            Me.cmbCou_Code.SelectedIndex = cmbCou_Code.FindString(GlbEmp.Cou_Code & " - ")
        End If
    End Sub

    Private Sub RegisterEmployeeCovidTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterEmployeeCovidTestToolStripMenuItem.Click

        If Me.txtCode.Text <> "" Then

            Dim tEmp As New cPrMsEmployees(Trim(Me.txtCode.Text))
            If tEmp.Code = "" Then
                MsgBox("Please save First Employee and then Proceed to Employee Annueal Leave", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim F As New FrmPrTxEmployeeCovidTest
                F.EmpCode = Me.txtCode.Text
                F.EmpName = Me.txtFullName.Text
                F.Employee = tEmp
                F.Owner = Me
                F.ShowDialog()
            End If
        End If
    End Sub

    Private Sub EmployeesReport1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesReport1ToolStripMenuItem.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDatasetToExcel3(False)
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDatasetToExcel3(ByVal ShowDiscounts As Boolean)
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader




        Dim MyYear As String = InputBox("Please Enter Year : ")
        Dim MyCompanyCode As String = InputBox("Please Enter Company Code (Write ALL for All Companies) : ")


        ds = Global1.Business.GetAllEmployeesFor_Report1(MyYear, MyCompanyCode)

        HeaderStr.Add("Code")
        HeaderStr.Add("FullName")
        HeaderStr.Add("Status")
        HeaderStr.Add("Start Date")
        HeaderStr.Add("Terminion Date ")
        HeaderStr.Add("Analysis1 Code")
        HeaderStr.Add("Analysis1 Description")
        HeaderStr.Add("Analysis2 Code")
        HeaderStr.Add("Analysis2 Description")
        HeaderStr.Add("Analysis3 Code")
        HeaderStr.Add("Analysis3 Description")
        HeaderStr.Add("Analysis4 Code")
        HeaderStr.Add("Analysis4 Description")
        HeaderStr.Add("Analysis5 Code")
        HeaderStr.Add("Analysis5 Description")
        HeaderStr.Add("Position Code")
        HeaderStr.Add("Position Description")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)

        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Sub SetNewEmployeeToFalseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetNewEmployeeToFalseToolStripMenuItem.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("With this action you will set New Employee Flag to False", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then
            If Global1.Business.SetNewEmployeeToFalse Then
                MsgBox("Procedure Finished!", MsgBoxStyle.Information)
            Else
                MsgBox("Procedure Failed!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub SetGenAnalysisToAnalysis2CodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetGenAnalysisToAnalysis2CodeToolStripMenuItem.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("With this action you will set General analysis 1 to Analysis 2 Code Value", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then
            If Global1.Business.SetGeneralAnalysis1ValueToAnaysis2 Then
                MsgBox("Procedure Finished!", MsgBoxStyle.Information)
            Else
                MsgBox("Procedure Failed!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub EmployeesReport2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesReport2ToolStripMenuItem.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDatasetToExcel4(False)
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDatasetToExcel4(ByVal ShowDiscounts As Boolean)
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader




        Dim MyYear As String = InputBox("Please Enter Year : ")
        Dim MyCompanyCode As String = InputBox("Please Enter Company Code (Write ALL for All Companies) : ")


        ds = Global1.Business.GetAllEmployeesFor_Report2(MyYear, MyCompanyCode)
        HeaderStr.Add("Code")
        HeaderStr.Add("Status")
        HeaderStr.Add("Template Group")
        HeaderStr.Add("Status 2")
        HeaderStr.Add("Title")
        HeaderStr.Add("LastName")
        HeaderStr.Add("FirstName")
        HeaderStr.Add("FullName")
        HeaderStr.Add("Sex")
        HeaderStr.Add("BirthDate")
        HeaderStr.Add("Marital Status")
        HeaderStr.Add("Address1")
        HeaderStr.Add("Address2")
        HeaderStr.Add("Address3")
        HeaderStr.Add("PostCode")
        HeaderStr.Add("Telephone1")
        HeaderStr.Add("Telephone2")
        HeaderStr.Add("Email")
        HeaderStr.Add("SocialInsNumber")
        HeaderStr.Add("Company Social Ins No")
        HeaderStr.Add("Identification Card")
        HeaderStr.Add("TaxID")
        HeaderStr.Add("PassportNumber")
        HeaderStr.Add("AlienNumber")
        HeaderStr.Add("TAx Id Type")
        HeaderStr.Add("Analysis 1 Code")
        HeaderStr.Add("Analysis 1")
        HeaderStr.Add("Analysis 2 Code")
        HeaderStr.Add("Analysis 2")
        HeaderStr.Add("Analysis 3 Code")
        HeaderStr.Add("Analysis 3")
        HeaderStr.Add("Analysis 4 Code")
        HeaderStr.Add("Analysis 4")
        HeaderStr.Add("Analysis 5 Code")
        HeaderStr.Add("Analysis 5")
        HeaderStr.Add("Emp_AnalGen1")
        HeaderStr.Add("Uni_Code")
        HeaderStr.Add("Cou_Code")
        HeaderStr.Add("Possition Code")
        HeaderStr.Add("Possition")
        HeaderStr.Add("Sic_Code")
        HeaderStr.Add("Community")
        HeaderStr.Add("PayUni_Code")
        HeaderStr.Add("PeriodUnits")
        HeaderStr.Add("AnnualUnits")
        HeaderStr.Add("Country")
        HeaderStr.Add("Payment Method")
        HeaderStr.Add("Empl. Bank Code")
        HeaderStr.Add("Empl. Bank Account")
        HeaderStr.Add("Company Bank Code")
        HeaderStr.Add("Company Bank Account")
        HeaderStr.Add("StartDate")
        HeaderStr.Add("TerminateDate")
        HeaderStr.Add("OtherIncome1")
        HeaderStr.Add("OtherIncome2")
        HeaderStr.Add("OtherIncome3")
        HeaderStr.Add("PreviousEarnings")
        HeaderStr.Add("PrevSIDeduct")
        HeaderStr.Add("PrevSIContribute")
        HeaderStr.Add("PrevITDeduct")
        HeaderStr.Add("PrevPFDeduct")
        HeaderStr.Add("CreationDate")
        HeaderStr.Add("CreatedBy")
        HeaderStr.Add("AmendDate")
        HeaderStr.Add("AmendBy")

        HeaderSize.Add(16)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(6)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(60)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(1)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(50)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(2)
        HeaderSize.Add(12)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(3)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)

        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Sub BtnCalculateAge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculateAge.Click
        Dim N As Date = Now
        Dim D As Long
        D = DateDiff(DateInterval.Hour, Me.DateBirth.Value.Date, N) / 8766
        MsgBox("Age is " & D & " years ")
    End Sub

    Private Sub EmployeesWithProvidentFundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesWithProvidentFundToolStripMenuItem.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDatasetToExcel5()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDatasetToExcel5()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader




        Dim MyCompanyCode As String = InputBox("Please Enter Company Code (Write ALL for All Companies) : ")
        Dim OnlyEmployeesWithNonZeroPF As Boolean = False
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Show Only Employees with Non Zero Provident Fund rates ?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            OnlyEmployeesWithNonZeroPF = True
        End If

        Me.Cursor = Cursors.WaitCursor()
        Application.DoEvents()
        ds = Global1.Business.GetAllEmployeesFor_EmployeesWithPF(MyCompanyCode, OnlyEmployeesWithNonZeroPF)

        HeaderStr.Add("Code")
        HeaderStr.Add("Status")
        HeaderStr.Add("Template Group")
        HeaderStr.Add("Status 2")
        HeaderStr.Add("Title")
        HeaderStr.Add("LastName")
        HeaderStr.Add("FirstName")
        HeaderStr.Add("FullName")
        HeaderStr.Add("Sex")
        HeaderStr.Add("BirthDate")
        HeaderStr.Add("Marital Status")
        HeaderStr.Add("Address1")
        HeaderStr.Add("Address2")
        HeaderStr.Add("Address3")
        HeaderStr.Add("PostCode")
        HeaderStr.Add("Telephone1")
        HeaderStr.Add("Telephone2")
        HeaderStr.Add("Email")
        HeaderStr.Add("SocialInsNumber")
        HeaderStr.Add("Company Social Ins No")
        HeaderStr.Add("Identification Card")
        HeaderStr.Add("TaxID")
        HeaderStr.Add("PassportNumber")
        HeaderStr.Add("AlienNumber")
        HeaderStr.Add("TAx Id Type")
        HeaderStr.Add("Analysis 1 Code")
        HeaderStr.Add("Analysis 1")
        HeaderStr.Add("Analysis 2 Code")
        HeaderStr.Add("Analysis 2")
        HeaderStr.Add("Analysis 3 Code")
        HeaderStr.Add("Analysis 3")
        HeaderStr.Add("Analysis 4 Code")
        HeaderStr.Add("Analysis 4")
        HeaderStr.Add("Analysis 5 Code")
        HeaderStr.Add("Analysis 5")
        HeaderStr.Add("Emp_AnalGen1")
        HeaderStr.Add("Uni_Code")
        HeaderStr.Add("Cou_Code")
        HeaderStr.Add("Possition Code")
        HeaderStr.Add("Possition")
        HeaderStr.Add("Sic_Code")
        HeaderStr.Add("Community")
        HeaderStr.Add("PayUni_Code")
        HeaderStr.Add("PeriodUnits")
        HeaderStr.Add("AnnualUnits")
        HeaderStr.Add("Country")
        HeaderStr.Add("Payment Method")
        HeaderStr.Add("Empl. Bank Code")
        HeaderStr.Add("Empl. Bank Account")
        HeaderStr.Add("Company Bank Code")
        HeaderStr.Add("Company Bank Account")
        HeaderStr.Add("StartDate")
        HeaderStr.Add("TerminateDate")
        HeaderStr.Add("OtherIncome1")
        HeaderStr.Add("OtherIncome2")
        HeaderStr.Add("OtherIncome3")
        HeaderStr.Add("PreviousEarnings")
        HeaderStr.Add("PrevSIDeduct")
        HeaderStr.Add("PrevSIContribute")
        HeaderStr.Add("PrevITDeduct")
        HeaderStr.Add("PrevPFDeduct")
        HeaderStr.Add("CreationDate")
        HeaderStr.Add("CreatedBy")
        HeaderStr.Add("AmendDate")
        HeaderStr.Add("AmendBy")
        HeaderStr.Add("PF Deduction Rate")
        HeaderStr.Add("PF Contr. Rate")

        HeaderSize.Add(16)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(6)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(60)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(1)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(50)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(2)
        HeaderSize.Add(12)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(3)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)

        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Sub AllEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllEmployeesToolStripMenuItem.Click
        PrepareEmployeeReport(False, "")
    End Sub

    Private Sub AllActiveEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllActiveEmployeesToolStripMenuItem.Click
        PrepareEmployeeReport(True, "")
    End Sub

    Private Sub SelectedEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectedEmployeeToolStripMenuItem.Click
        Dim EmpCode As String
        EmpCode = Me.txtCode.Text
        PrepareEmployeeReport(False, EmpCode)
    End Sub
    Private Sub PrepareEmployeeReport(ByVal OnlyActive As Boolean, ByVal SelectedEmployeeCode As String)
        Dim F As New FrmSelectReportType

        F.Owner = Me
        F.ShowDialog()
        Dim ShowOnScreen As Boolean = False
        Dim ExportinPDF As Boolean = False
        Dim SendToPrinter As Boolean = False
        Dim ExportInExcel As Boolean = False
        Dim ExportType As Integer

        If Me.GLBExportReportType <> 0 Then


            Dim Ds1 As DataSet
            Dim ExportDir As String
            Ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")

            If CheckDataSet(Ds1) Then
                Dim Par As New cPrSsParameters(Ds1.Tables(0).Rows(0))
                ExportDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
            Else
                ExportDir = "C:\"
            End If
            Dim ReportToUse As String
            Ds1 = Global1.Business.GetParameter("Reports", "EmpReport1")
            If CheckDataSet(Ds1) Then
                Dim Par As New cPrSsParameters(Ds1.Tables(0).Rows(0))
                ReportToUse = Par.Value1
            Else
                ReportToUse = "EmployeeReport1.rpt"
            End If


            If Me.GLBExportReportType = 1 Then
                ExportinPDF = True
            End If
            If Me.GLBExportReportType = 2 Then
                SendToPrinter = True
            End If
            If Me.GLBExportReportType = 3 Then
                ShowOnScreen = True
            End If
            If Me.GLBExportReportType = 4 Then
                ExportInExcel = True
            End If

            Dim Ds As DataSet
            Ds = Global1.Business.GetemployeeDetailsForPrinting1(OnlyActive, SelectedEmployeeCode)
            ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\EmployeeReport1")
            Dim ExportFile As Boolean = False
            Dim i As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim NewDs As DataSet
                Dim R As DataRow
                NewDs = Ds.Copy
                R = Ds.Tables(0).Rows(i)
                NewDs.Tables(0).Rows.Clear()
                NewDs.Tables(0).ImportRow(R)
                Dim ExportFileName As String = ""



                If ExportinPDF Then
                    Dim EmpCode As String
                    EmpCode = DbNullToString(NewDs.Tables(0).Rows(0).Item(0))
                    ExportFileName = ExportDir & EmpCode & "_Report1.pdf"
                    ExportType = 0
                    ExportFile = True
                End If
                If ExportInExcel Then
                    Dim EmpCode As String
                    EmpCode = DbNullToString(NewDs.Tables(0).Rows(0).Item(0))
                    ExportFileName = ExportDir & EmpCode & "_Report1.xls"
                    ExportType = 2
                    ExportFile = True
                End If

                Utils.ShowReport(ReportToUse, NewDs, FrmReport, "Employee Report 1", SendToPrinter, "", False, ExportFile, ExportFileName, False, ExportType)
            Next
            If ExportinPDF Or ExportInExcel Then
                MsgBox("Reports are axported in " & ExportDir, MsgBoxStyle.Information)

            End If
        Else
            MsgBox("Report Export aborted", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                EmpPhoto.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove.Click
        EmpPhoto.Image = My.Resources.photo
    End Sub

    Private Sub BStartCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStartCapture.Click
        Dim k As New frmCamera
        k.ShowDialog()
        If GLBWebCam_TempFileNames2.Length > 0 Then
            EmpPhoto.Image = Image.FromFile(GLBWebCam_TempFileNames2)
            Photoname = GLBWebCam_TempFileNames2
            IsImageChanged = True
        End If
    End Sub



   
   
    Private Sub CBFirstEmployment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBFirstEmployment.CheckedChanged

        If CBFirstEmployment.CheckState = CheckState.Checked Then
            Me.CBControlAmount100.Enabled = True
            Me.CBControlAmount55.Enabled = True
            Me.CBControlAmount55.CheckState = CheckState.Checked
            Me.CBControlAmount100.CheckState = CheckState.Unchecked

            Me.CBLimitTo20.Enabled = True
            Me.CBForce50Percent.Enabled = True
        Else
            Me.CBControlAmount100.Enabled = False
            Me.CBControlAmount55.Enabled = False
            Me.CBControlAmount55.CheckState = CheckState.Unchecked
            Me.CBControlAmount100.CheckState = CheckState.Unchecked
            Me.txtFEControlAmount.Text = "0.00"

            Me.CBLimitTo20.CheckState = CheckState.Unchecked
            Me.CBForce50Percent.CheckState = CheckState.Unchecked
            Me.CBLimitTo20.Enabled = False
            Me.CBForce50Percent.Enabled = False
        End If

    End Sub

    Private Sub CBControlAmount55_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBControlAmount55.CheckedChanged
        If CBFirstEmployment.CheckState = CheckState.Checked Then
            If CBControlAmount55.CheckState = CheckState.Checked Then
                Me.txtFEControlAmount.Text = "55000.00"
                Me.CBControlAmount100.CheckState = CheckState.Unchecked
            Else
                CBControlAmount100.CheckState = CheckState.Checked
            End If
        End If
    End Sub

    Private Sub CBControlAmount100_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBControlAmount100.CheckedChanged
        If CBFirstEmployment.CheckState = CheckState.Checked Then
            If CBControlAmount100.CheckState = CheckState.Checked Then
                Me.txtFEControlAmount.Text = "100000.00"
                Me.CBControlAmount55.CheckState = CheckState.Unchecked
            Else
                Me.CBControlAmount55.CheckState = CheckState.Checked
            End If
        End If
    End Sub

    Private Sub btnTemplateSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplateSearch.Click
        Dim F As New FrmTemplateSearch
        F.Owner = Me
        F.DsTemp = dsTemplateGroups
        F.CalledBy = 2
        F.ShowDialog()

    End Sub
End Class
