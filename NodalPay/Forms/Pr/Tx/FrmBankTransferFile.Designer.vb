<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankTransferFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblBnk_CodeCo = New System.Windows.Forms.Label()
        Me.cmbBnk_CodeCo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbCompany = New System.Windows.Forms.ComboBox()
        Me.DatePay = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnPaymentRequest = New System.Windows.Forms.Button()
        Me.CBInactive = New System.Windows.Forms.CheckBox()
        Me.ComboBankAcc = New System.Windows.Forms.ComboBox()
        Me.CBAutopay = New System.Windows.Forms.CheckBox()
        Me.CBConsolidate = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDaysDiff = New System.Windows.Forms.TextBox()
        Me.btnViewPFReport = New System.Windows.Forms.Button()
        Me.ComboBankFileCode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboOnlyBank = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CBSelectEmployees = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtLimitPerEmployee = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.btnIBANReportWithAllemployees = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.BtnCreateEWallet = New System.Windows.Forms.Button()
        Me.BtnCreateEWalletNoNames = New System.Windows.Forms.Button()
        Me.BtniSXMoney = New System.Windows.Forms.Button()
        Me.btnEcommbx2 = New System.Windows.Forms.Button()
        Me.btnGURUPay = New System.Windows.Forms.Button()
        Me.BtnMoneyGate = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.BtnCreateKyribaExcelFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(783, 16)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(300, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Create Bank File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblBnk_CodeCo
        '
        Me.lblBnk_CodeCo.AutoSize = True
        Me.lblBnk_CodeCo.Location = New System.Drawing.Point(7, 53)
        Me.lblBnk_CodeCo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBnk_CodeCo.Name = "lblBnk_CodeCo"
        Me.lblBnk_CodeCo.Size = New System.Drawing.Size(103, 17)
        Me.lblBnk_CodeCo.TabIndex = 47
        Me.lblBnk_CodeCo.Text = "Company Bank"
        '
        'cmbBnk_CodeCo
        '
        Me.cmbBnk_CodeCo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBnk_CodeCo.Location = New System.Drawing.Point(304, 49)
        Me.cmbBnk_CodeCo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBnk_CodeCo.Name = "cmbBnk_CodeCo"
        Me.cmbBnk_CodeCo.Size = New System.Drawing.Size(425, 24)
        Me.cmbBnk_CodeCo.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 17)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Company Bank Account to Be Debited"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Company"
        '
        'CmbCompany
        '
        Me.CmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompany.Location = New System.Drawing.Point(304, 16)
        Me.CmbCompany.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbCompany.Name = "CmbCompany"
        Me.CmbCompany.Size = New System.Drawing.Size(425, 24)
        Me.CmbCompany.TabIndex = 50
        '
        'DatePay
        '
        Me.DatePay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePay.Location = New System.Drawing.Point(304, 180)
        Me.DatePay.Margin = New System.Windows.Forms.Padding(4)
        Me.DatePay.Name = "DatePay"
        Me.DatePay.Size = New System.Drawing.Size(131, 22)
        Me.DatePay.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 185)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 17)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Requested Pay Date"
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(783, 185)
        Me.btnViewReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(300, 28)
        Me.btnViewReport.TabIndex = 54
        Me.btnViewReport.Text = "View BANK Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnPaymentRequest
        '
        Me.btnPaymentRequest.Location = New System.Drawing.Point(783, 91)
        Me.btnPaymentRequest.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPaymentRequest.Name = "btnPaymentRequest"
        Me.btnPaymentRequest.Size = New System.Drawing.Size(300, 28)
        Me.btnPaymentRequest.TabIndex = 55
        Me.btnPaymentRequest.Text = "Create Payment Request - Format 1"
        Me.btnPaymentRequest.UseVisualStyleBackColor = True
        '
        'CBInactive
        '
        Me.CBInactive.AutoSize = True
        Me.CBInactive.Location = New System.Drawing.Point(51, 332)
        Me.CBInactive.Margin = New System.Windows.Forms.Padding(4)
        Me.CBInactive.Name = "CBInactive"
        Me.CBInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBInactive.Size = New System.Drawing.Size(260, 21)
        Me.CBInactive.TabIndex = 56
        Me.CBInactive.Text = "Include Inactive Employees               "
        Me.CBInactive.UseVisualStyleBackColor = True
        '
        'ComboBankAcc
        '
        Me.ComboBankAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBankAcc.FormattingEnabled = True
        Me.ComboBankAcc.Location = New System.Drawing.Point(304, 80)
        Me.ComboBankAcc.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBankAcc.Name = "ComboBankAcc"
        Me.ComboBankAcc.Size = New System.Drawing.Size(425, 24)
        Me.ComboBankAcc.TabIndex = 58
        '
        'CBAutopay
        '
        Me.CBAutopay.AutoSize = True
        Me.CBAutopay.Location = New System.Drawing.Point(51, 361)
        Me.CBAutopay.Margin = New System.Windows.Forms.Padding(4)
        Me.CBAutopay.Name = "CBAutopay"
        Me.CBAutopay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBAutopay.Size = New System.Drawing.Size(264, 21)
        Me.CBAutopay.TabIndex = 59
        Me.CBAutopay.Text = "Marfin Autopay Layout                       "
        Me.CBAutopay.UseVisualStyleBackColor = True
        '
        'CBConsolidate
        '
        Me.CBConsolidate.AutoSize = True
        Me.CBConsolidate.Location = New System.Drawing.Point(51, 389)
        Me.CBConsolidate.Margin = New System.Windows.Forms.Padding(4)
        Me.CBConsolidate.Name = "CBConsolidate"
        Me.CBConsolidate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBConsolidate.Size = New System.Drawing.Size(263, 21)
        Me.CBConsolidate.TabIndex = 60
        Me.CBConsolidate.Text = "Consolidate Bank File Per Company  "
        Me.CBConsolidate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 215)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(285, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Non Company Bank, Banks Days Difference"
        '
        'txtDaysDiff
        '
        Me.txtDaysDiff.Location = New System.Drawing.Point(304, 212)
        Me.txtDaysDiff.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDaysDiff.Name = "txtDaysDiff"
        Me.txtDaysDiff.Size = New System.Drawing.Size(131, 22)
        Me.txtDaysDiff.TabIndex = 62
        '
        'btnViewPFReport
        '
        Me.btnViewPFReport.Location = New System.Drawing.Point(783, 267)
        Me.btnViewPFReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewPFReport.Name = "btnViewPFReport"
        Me.btnViewPFReport.Size = New System.Drawing.Size(300, 28)
        Me.btnViewPFReport.TabIndex = 63
        Me.btnViewPFReport.Text = "View Prov.Fund Report By Analysis"
        Me.btnViewPFReport.UseVisualStyleBackColor = True
        '
        'ComboBankFileCode
        '
        Me.ComboBankFileCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBankFileCode.FormattingEnabled = True
        Me.ComboBankFileCode.Location = New System.Drawing.Point(304, 113)
        Me.ComboBankFileCode.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBankFileCode.Name = "ComboBankFileCode"
        Me.ComboBankFileCode.Size = New System.Drawing.Size(425, 24)
        Me.ComboBankFileCode.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 117)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 17)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Company Bank File Code"
        '
        'ComboOnlyBank
        '
        Me.ComboOnlyBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboOnlyBank.FormattingEnabled = True
        Me.ComboOnlyBank.Location = New System.Drawing.Point(304, 146)
        Me.ComboOnlyBank.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboOnlyBank.Name = "ComboOnlyBank"
        Me.ComboOnlyBank.Size = New System.Drawing.Size(425, 24)
        Me.ComboOnlyBank.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 17)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Only Employees Of Bank"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(783, 126)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(300, 28)
        Me.Button2.TabIndex = 68
        Me.Button2.Text = "Create Payment Request - Format 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CBSelectEmployees
        '
        Me.CBSelectEmployees.AutoSize = True
        Me.CBSelectEmployees.Location = New System.Drawing.Point(783, 769)
        Me.CBSelectEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.CBSelectEmployees.Name = "CBSelectEmployees"
        Me.CBSelectEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBSelectEmployees.Size = New System.Drawing.Size(142, 21)
        Me.CBSelectEmployees.TabIndex = 71
        Me.CBSelectEmployees.Text = "Select Employees"
        Me.CBSelectEmployees.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(783, 332)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(300, 28)
        Me.Button3.TabIndex = 72
        Me.Button3.Text = "Create .CSV File - Malta"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(783, 368)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(300, 28)
        Me.Button4.TabIndex = 73
        Me.Button4.Text = "Create .CSV File - Handels Bank"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtLimitPerEmployee
        '
        Me.txtLimitPerEmployee.Location = New System.Drawing.Point(304, 244)
        Me.txtLimitPerEmployee.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLimitPerEmployee.Name = "txtLimitPerEmployee"
        Me.txtLimitPerEmployee.Size = New System.Drawing.Size(131, 22)
        Me.txtLimitPerEmployee.TabIndex = 75
        Me.txtLimitPerEmployee.Text = "0.00"
        Me.txtLimitPerEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 247)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Limit per Employee"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(783, 404)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(300, 28)
        Me.Button5.TabIndex = 76
        Me.Button5.Text = "Create .CSV File - CIM Banque"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(783, 546)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(300, 28)
        Me.Button6.TabIndex = 77
        Me.Button6.Text = "Create BARCLAYS SIF - SEPA  Payment File"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(783, 439)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(300, 28)
        Me.Button7.TabIndex = 78
        Me.Button7.Text = "Create .CSV File - Ecommbx"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(783, 702)
        Me.Button8.Margin = New System.Windows.Forms.Padding(4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(300, 28)
        Me.Button8.TabIndex = 79
        Me.Button8.Text = "Create SEPA .txt File - Alpha Bank"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(783, 737)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(300, 28)
        Me.Button9.TabIndex = 80
        Me.Button9.Text = "Create SEPA .csv File - Alpha Bank"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.UseVisualStyleBackColor = True
        '
        'btnIBANReportWithAllemployees
        '
        Me.btnIBANReportWithAllemployees.Location = New System.Drawing.Point(783, 220)
        Me.btnIBANReportWithAllemployees.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIBANReportWithAllemployees.Name = "btnIBANReportWithAllemployees"
        Me.btnIBANReportWithAllemployees.Size = New System.Drawing.Size(300, 28)
        Me.btnIBANReportWithAllemployees.TabIndex = 81
        Me.btnIBANReportWithAllemployees.Text = "IBANs report with ALL employees"
        Me.btnIBANReportWithAllemployees.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(783, 582)
        Me.Button10.Margin = New System.Windows.Forms.Padding(4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(300, 28)
        Me.Button10.TabIndex = 82
        Me.Button10.Text = "Create .CSV File - Astro Bank"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(783, 53)
        Me.Button11.Margin = New System.Windows.Forms.Padding(4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(300, 28)
        Me.Button11.TabIndex = 83
        Me.Button11.Text = "Open Bank File Directory"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(783, 618)
        Me.Button12.Margin = New System.Windows.Forms.Padding(4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(300, 28)
        Me.Button12.TabIndex = 84
        Me.Button12.Text = "Create .CSV File - Sepaga Bank"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.UseVisualStyleBackColor = True
        '
        'BtnCreateEWallet
        '
        Me.BtnCreateEWallet.Location = New System.Drawing.Point(1100, 16)
        Me.BtnCreateEWallet.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCreateEWallet.Name = "BtnCreateEWallet"
        Me.BtnCreateEWallet.Size = New System.Drawing.Size(300, 28)
        Me.BtnCreateEWallet.TabIndex = 85
        Me.BtnCreateEWallet.Text = "Create E-Wallet File - With Names"
        Me.BtnCreateEWallet.UseVisualStyleBackColor = True
        '
        'BtnCreateEWalletNoNames
        '
        Me.BtnCreateEWalletNoNames.Location = New System.Drawing.Point(1100, 53)
        Me.BtnCreateEWalletNoNames.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCreateEWalletNoNames.Name = "BtnCreateEWalletNoNames"
        Me.BtnCreateEWalletNoNames.Size = New System.Drawing.Size(300, 28)
        Me.BtnCreateEWalletNoNames.TabIndex = 86
        Me.BtnCreateEWalletNoNames.Text = "Create E-Wallet File - Without Names"
        Me.BtnCreateEWalletNoNames.UseVisualStyleBackColor = True
        '
        'BtniSXMoney
        '
        Me.BtniSXMoney.Location = New System.Drawing.Point(783, 654)
        Me.BtniSXMoney.Margin = New System.Windows.Forms.Padding(4)
        Me.BtniSXMoney.Name = "BtniSXMoney"
        Me.BtniSXMoney.Size = New System.Drawing.Size(300, 28)
        Me.BtniSXMoney.TabIndex = 87
        Me.BtniSXMoney.Text = "Create .CSV File - iSXMoney"
        Me.BtniSXMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtniSXMoney.UseVisualStyleBackColor = True
        '
        'btnEcommbx2
        '
        Me.btnEcommbx2.Location = New System.Drawing.Point(783, 475)
        Me.btnEcommbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEcommbx2.Name = "btnEcommbx2"
        Me.btnEcommbx2.Size = New System.Drawing.Size(300, 28)
        Me.btnEcommbx2.TabIndex = 88
        Me.btnEcommbx2.Text = "Create .CSV File - Ecommbx V2"
        Me.btnEcommbx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEcommbx2.UseVisualStyleBackColor = True
        '
        'btnGURUPay
        '
        Me.btnGURUPay.Location = New System.Drawing.Point(1100, 91)
        Me.btnGURUPay.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGURUPay.Name = "btnGURUPay"
        Me.btnGURUPay.Size = New System.Drawing.Size(300, 28)
        Me.btnGURUPay.TabIndex = 89
        Me.btnGURUPay.Text = "Create GURU Pay .xml file"
        Me.btnGURUPay.UseVisualStyleBackColor = True
        '
        'BtnMoneyGate
        '
        Me.BtnMoneyGate.Location = New System.Drawing.Point(1100, 127)
        Me.BtnMoneyGate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnMoneyGate.Name = "BtnMoneyGate"
        Me.BtnMoneyGate.Size = New System.Drawing.Size(300, 28)
        Me.BtnMoneyGate.TabIndex = 90
        Me.BtnMoneyGate.Text = "Create Money Gate .csv file"
        Me.BtnMoneyGate.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(783, 511)
        Me.Button13.Margin = New System.Windows.Forms.Padding(4)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(300, 28)
        Me.Button13.TabIndex = 91
        Me.Button13.Text = "Create .CSV File - Ecommbx V3"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.UseVisualStyleBackColor = True
        '
        'BtnCreateKyribaExcelFile
        '
        Me.BtnCreateKyribaExcelFile.Location = New System.Drawing.Point(1103, 185)
        Me.BtnCreateKyribaExcelFile.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCreateKyribaExcelFile.Name = "BtnCreateKyribaExcelFile"
        Me.BtnCreateKyribaExcelFile.Size = New System.Drawing.Size(300, 28)
        Me.BtnCreateKyribaExcelFile.TabIndex = 92
        Me.BtnCreateKyribaExcelFile.Text = "Create .CSV File - Kyriba"
        Me.BtnCreateKyribaExcelFile.UseVisualStyleBackColor = True
        '
        'FrmBankTransferFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1416, 836)
        Me.Controls.Add(Me.BtnCreateKyribaExcelFile)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.BtnMoneyGate)
        Me.Controls.Add(Me.btnGURUPay)
        Me.Controls.Add(Me.btnEcommbx2)
        Me.Controls.Add(Me.BtniSXMoney)
        Me.Controls.Add(Me.BtnCreateEWalletNoNames)
        Me.Controls.Add(Me.BtnCreateEWallet)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.btnIBANReportWithAllemployees)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtLimitPerEmployee)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CBSelectEmployees)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboOnlyBank)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBankFileCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnViewPFReport)
        Me.Controls.Add(Me.txtDaysDiff)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CBConsolidate)
        Me.Controls.Add(Me.CBAutopay)
        Me.Controls.Add(Me.ComboBankAcc)
        Me.Controls.Add(Me.CBInactive)
        Me.Controls.Add(Me.btnPaymentRequest)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DatePay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBnk_CodeCo)
        Me.Controls.Add(Me.cmbBnk_CodeCo)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmBankTransferFile"
        Me.Text = "Bank Transfer File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblBnk_CodeCo As System.Windows.Forms.Label
    Friend WithEvents cmbBnk_CodeCo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents DatePay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnPaymentRequest As System.Windows.Forms.Button
    Friend WithEvents CBInactive As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBankAcc As System.Windows.Forms.ComboBox
    Friend WithEvents CBAutopay As System.Windows.Forms.CheckBox
    Friend WithEvents CBConsolidate As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDaysDiff As System.Windows.Forms.TextBox
    Friend WithEvents btnViewPFReport As System.Windows.Forms.Button
    Friend WithEvents ComboBankFileCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboOnlyBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CBSelectEmployees As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtLimitPerEmployee As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btnIBANReportWithAllemployees As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents BtnCreateEWallet As System.Windows.Forms.Button
    Friend WithEvents BtnCreateEWalletNoNames As System.Windows.Forms.Button
    Friend WithEvents BtniSXMoney As System.Windows.Forms.Button
    Friend WithEvents btnEcommbx2 As System.Windows.Forms.Button
    Friend WithEvents btnGURUPay As System.Windows.Forms.Button
    Friend WithEvents BtnMoneyGate As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents BtnCreateKyribaExcelFile As Button
End Class
