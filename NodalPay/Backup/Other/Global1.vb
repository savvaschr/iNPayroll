Module Global1
    Public Version As String = "2.2023.006"
    'YTD Report
    'Sum Annual Units for 13nth
    'Open Next Year Period Automatically

    Public VersionDate As String = "22/11/2023"
    '14th Salary
    'Payslip directory
    Public IsConnected As Boolean
    Public IsConnectedText As Boolean
    Public BeginTransactionFlag As Boolean
    Public Business As cBusiness
    Public GlobalCompanyId As Integer
    Public UserRole As Roles
    Public GLBUserId As Integer
    Public FullName As String
    Public IntefaceFileDone As Boolean

    Public IsUserEnabled As Boolean
    Public CurrentPeriodId As Integer

    Public GlbWorkstationId As Integer
    Public GlbLocationId As Integer
    Public BaseCurNumCode As String
    Public DbaseServerName As String
    Public DbaseName As String
    Public ServerDatabase(0, 0) As String
    Public UserName As String
    Public GlobalUser As cUsers
    Public FileName As String

    Public ShowMessages As Boolean = True
    Public SQLAuthentication As Boolean = True
    Public GLBPayslipShowOnlyWithValue As Boolean = False
    Public GlbLimits As cPrSsLimits
    Public PARAM_RemoveE37 As Boolean

    Public GlbCancelIr7 As Boolean = False
    Public GLBCurrentYear As String = ""


    'Public PAR_EquipmentDaysBack As Integer

    'Public GroupCode_PhilipsWorkshop As String = "10"
    'Public GroupCode_Workshop As String = "11"
    'Public GroupCode_Field As String = "12"
    'Public GroupCode_Delivery As String = "21"
    ''Fin
    'Public NumberOfFiscalPeriods As Integer = 12

    'Public TopMark As Integer = 140
    'Public LeftMark As Integer = 24
    'Public LocalCurencyCode As String = "CYP" 'TEMP

    'Public FI_TrxnType_SALES = "11"
    'Public FI_TrxnType_RECEIPTS = "21"
    'Public FI_TrxnType_CUSTOMER_ADJ = "31"
    'Public FI_TrxnType_PURCHASES = "51"
    'Public FI_TrxnType_PAYMENTS = "61"
    'Public FI_TrxnType_SUPPLIER_ADJ = "71"

    Public COLAPercentage As Double = 21
    Public GLB_Units_Period_Code As String = 1
    Public GLB_Units_Hourly_Code As String = 2
    Public GLB_Units_Contract_Code As String = 3
    Public GLB_PeriodCategory_Normal As String = "K"
    Public GLB_PeriodCategory_13 As String = "3"
    Public GLB_PeriodCategory_14 As String = "4"

    'Fin
    Public NumberOfFiscalPeriods As Integer = 12

    Public TopMark As Integer = 140
    Public LeftMark As Integer = 24
    Public LocalCurencyCode As String = "CYP" 'TEMP

    Public AN_DecreaseCODE As String = "DE"
    Public AN_IncreaseCODE As String = "IN"
    Public AN_CarryForwardCODE As String = "CF"
    Public AN_EndOfYearCODE As String = "EO"

    Public AN_Decrease As String = "DE - Decrease"
    Public AN_Increase As String = "IN - Increase"
    Public AN_CarryForward As String = "CF - Carry Forward"
    Public AN_EndOfYear As String = "EO - End Of Year"

    Public AN_Issue As String = "ISSUE"
    Public AN_Payment As String = "PAYMENT"

    Public AN_Approved As String = "Approved"
    Public AN_Rejected As String = "Rejected"
    Public AN_Requested As String = "Requested"

    Public AN_OPEN As String = "OPEN"
    Public AN_CLOSED As String = "CLOSED"


    Public FI_TrxnType_SALES = "11"
    Public FI_TrxnType_RECEIPTS = "21"
    Public FI_TrxnType_CUSTOMER_ADJ = "31"
    Public FI_TrxnType_PURCHASES = "51"
    Public FI_TrxnType_PAYMENTS = "61"
    Public FI_TrxnType_SUPPLIER_ADJ = "71"


    Public ACT_GLAccount As String = "0 - GL Account"
    Public ACT_Customer As String = "1 - Customer"
    Public ACT_Vendor As String = "2 - Vendor"
    Public ACT_Bank As String = "3 - Bank"
    Public ACT_FixAsset As String = "4 - Fix Asset"
    Public ACT_ICPartner As String = "5 - IC Partner"
    Public GLB_PAYSLIPReport As String = "payslip.rpt"

    Public GLBTempChequeNo As String
    Public GLBTempChequeDate As String


    Public GLBUserCode As String
    Public GLBUserPassword As String

    Public NAV_GLBCompPrefix As String '= "ACTION Cyprus LTD$"
    Public NAV_ServerName As String '= "10.0.0.106\SQL2008"
    Public NAV_DBName As String '= "ActionGlobal"
    Public NAV_User As String '= "Nodal"
    Public NAV_Pass As String '= "36132"



    Public NAV_JournalTemplateName As String '= "PRLL"
    Public NAV_JournalBachName As String '= "PRTM"
    Public NAV_AccountNo As String '= "601090"
    Public NAV_BalancingAcc As String '= "711090"
    Public NAV_SourceCode As String '= "PAYROLL"
    Public NAV_PostingNoSeries As String '= "PRLL"

    Public GLB_SpecialTaxDeductionLimit As Double
    Public GLB_SpecialTaxContributionLimit As Double

    Public GLB_MethodOfSI As Integer = 1

    Public GLB_OneInterfaceFile As Boolean = False

    Public OpenFormIndex As Integer = 0
    Public ConsolidateBankFile As Boolean = False

    Public GLB_IR7Discounts As Integer = 0
    Public GLB_IR63Description = "Annual Allowances, Other Receipts or Benefits such as Residence and Food, Rent, Private Use of Car etc. (Give details)."

    Public GLB_NoAnnualUnits As Boolean = False
    Public SplitRate As Double = 0
    Public PeriodUnitsForTA As Double = 0
    Public PARAM_Average_13_14 As Boolean = False
    Public PARAM_EarningsFor_13_14 As String
    Public PARAM_Allow_NegativeTAX As Boolean = True

    Public PARAM_TaxRule As Double = 16.67

    Public GLBShowInterfaceReport As Boolean = False
    Public GLBShowNetSuite As Boolean = False
    Public GLBShowSAP As Boolean = False
    Public GLBShowEsoft As Boolean = False
    Public GLBShowSoftOne As Boolean = False

    Public GLBShowInterfaceReportPF As Boolean = False

    Public PARAM_TAFileEnable As Boolean = False
    Public PARAM_TAFilePath As String = ""

    Public PARAM_ETFilePath As String = ""
    Public PARAM_ETFileEnable As Boolean = False

    Public PARAM_SpecialDedonPension As Boolean = False
    Public PARAM_TimeAttendanceInterface As Boolean = False
    Public PARAM_PensionAge As Integer = 0
    Public PARAM_PFReminder As Integer = 0

    Public PARAM_AnnualLeaveAllocation As Boolean = False
    Public PARAM_AnnualLeaveAllocationTemplateGroups As String = ""
    Public PARAM_Salary_1_2 As Boolean = False
    Public PARAM_CostPercentageForTA As Double = 0
    Public GLBMonthNormalDays As Double = 0
    Public PARAM_SpecialDedonOTI1 As Boolean = False

    'Public PARAM_SystemIsLocked As Boolean = False

    Public PARAM_HideEmpWithBlanksSIR As Boolean = True

    Public GmailAccount As String
    Public GmailPassword As String

    Public GLBAirlines As Boolean = True
    Public GLBHideOver As Boolean = False

    Public PARAM_UsePosition As Boolean = False
    Public PARAM_HCMIsenabled As Boolean = False
    Public PARAM_HCMdatabasePath As String = ""
    Public PARAM_HCMPayslipsUploadPath As String = ""
    Public PARAM_HCMTempGroup As String = ""

    Public RateForAnnualLeaveForAll As Double = 0

    Public PARAM_Payslip_ApprovedBy As String = ""
    Public PARAM_Payslip_PreparedBy As String = ""

    Public PARAM_P3toP7 As Boolean = False
    Public PARAM_USE_Workingdays As Boolean = False

    Public PARAM_OvertimeRateOfPreviousPeriod As Boolean = False
    Public PARAM_PAYE As Boolean = True
    Public PARAM_PAYEProRata As Boolean = False
    Public PARAM_MonthlyALBalance As Boolean = False
    Public PARAM_DefRowCount As Integer = 0

    Public Param_DiscountLabel1 As String = "Discount 1"
    Public Param_DiscountLabel2 As String = "Discount 2"
    Public Param_DiscountLabel3 As String = "Discount 3"
    Public Param_DiscountLabel4 As String = "Discount 4"
    Public Param_DiscountLabel5 As String = "Discount 5"
    Public Param_DiscountLabel6 As String = "Discount 6"
    Public Param_DiscountLabel7 As String = "Discount 7"
    Public Param_DiscountLabel8 As String = "Discount 8"
    Public Param_DiscountLabel9 As String = "Discount 9"
    Public Param_DiscountLabel10 As String = "Discount 10"

    Public PARAM_CobaltALCode As String = ""
    Public PARAM_BIKWithSCCode As String = ""

    Public PARAM_IR63_ShowBonusSeparatly As Boolean = False
    Public PARAM_IR63_BonusEarningCode As String = ""

    Public PARAM_IR63_ShowSep1 As Boolean = False
    Public PARAM_IR63_Sep1Code As String = ""
    Public PARAM_IR63_Sep1Desc As String = ""

    Public PARAM_IR63_ShowSep2 As Boolean = False
    Public PARAM_IR63_Sep2Code As String = ""
    Public PARAM_IR63_Sep2Desc As String = ""

    Public PARAM_IR63_ShowSep3 As Boolean = False
    Public PARAM_IR63_Sep3Code As String = ""
    Public PARAM_IR63_Sep3Desc As String = ""

    Public PARAM_IR63_ShowSep4 As Boolean = False
    Public PARAM_IR63_Sep4Code As String = ""
    Public PARAM_IR63_Sep4Desc As String = ""

    Public PARAM_IR63_ShowSep5 As Boolean = False
    Public PARAM_IR63_Sep5Code As String = ""
    Public PARAM_IR63_Sep5Desc As String = ""

    Public PARAM_IR63_ShowSep6 As Boolean = False
    Public PARAM_IR63_Sep6Code As String = ""
    Public PARAM_IR63_Sep6Desc As String = ""

    Public PARAM_IR63_ShowSep7 As Boolean = False
    Public PARAM_IR63_Sep7Code As String = ""
    Public PARAM_IR63_Sep7Desc As String = ""

    Public PARAM_IR63_ShowSep8 As Boolean = False
    Public PARAM_IR63_Sep8Code As String = ""
    Public PARAM_IR63_Sep8Desc As String = ""

    Public PARAM_IR63_ShowSep9 As Boolean = False
    Public PARAM_IR63_Sep9Code As String = ""
    Public PARAM_IR63_Sep9Desc As String = ""

    Public PARAM_IR63_ShowSep10 As Boolean = False
    Public PARAM_IR63_Sep10Code As String = ""
    Public PARAM_IR63_Sep10Desc As String = ""

    Public PARAM_IR63_Report As String = "IR63A2012.rpt"

    Public PARAM_AllowMarkAsInterface As Boolean = False
    Public PARAM_GetPFAmountFromAgreedSalary As Boolean = False
    Public PARAM_SplitIsEnabled As Boolean = False

    Public PARAM_RPUnitAmount As Double = 0
    Public PARAM_TempOnInt As Boolean = False

    Public PARAM_PrintTimeSheetsReport As Boolean = False


    Public PARAM_AddColaOnRate As Boolean = False
    Public PARAM_USDRate As Decimal = 1.0


    Public PARAM_UnionMedicalDedCode As String = ""
    Public PARAM_UnionMedicalConCode As String = ""
    Public PARAM_UnionFishes As String = ""
    Public PARAM_WelfareDedCode As String = ""

    Public Param_IncludeInTotal1 As String
    Public Param_IncludeInTotal2 As String
    Public Param_IncludeInTotal3 As String
    Public Param_IncludeInTotal4 As String
    Public Param_IncludeInTotal5 As String

    Public Param_PayslipCC As String = ""
    Public PARAM_EmpCodeinChequeRef As Boolean = False

    Public PARAM_FTPToNodal As Boolean = False

    Public PARAM_OvertimeRate_BasedOndays As Boolean = False
    Public PARAM_OvertimeRate_monthdays As Double = 0

    Public DSforSIfile As DataSet

    Public PARAM_SMTPPort As Integer = 587
    Public PARAM_SMTPSSLEnabled As Boolean = True

    Public PARAM_SMTPEmailHost As String = ""
    Public PARAM_SMTPUser As String = ""

    Public PARAM_COLAMinimum As Double = 0

    Public PARAM_ShowAnalysis3onPayslip As Boolean = False
    Public PARAM_Warningon20PercLimit As Boolean = False
    Public PARAM_PublicSector As String = ""

    Public PARAM_ShowEmpNameOnInterface As Boolean = False

    Public GLBDedtorsInterface As Boolean = False
    Public GLBDedtorsControl As String
    Public GLBCreditorsInterface As Boolean = False
    Public GLBCreditorsControl As String
    Public GLBLoanDedCode As String
    Public GLBRentDedCode As String
    Public GLBSavingsDedCode As String
    Public GLBTemplateforDCInterface As String = ""
    Public GLBTemplateforDCInterface2 As String = ""

    Public GLBGenerateFromMKT_To_IMK As Boolean = False
    Public GLBMKTToMKTInterfaceCode As String = ""
    Public GLBGenerateFromMKT_To_IMK_TemplateCode As String = ""
    Public GlbNoTransactions As Boolean = False

    Public GLBOnlyUpdateChequeNumbers As Boolean = False

    Public PARAM_NightShiftRate As Double = 0
    Public PARAM_NightShiftErnCode As String
    Public PARAM_OverTime3ToOtherEarnings As Boolean = False
    Public PARAM_Andrikian13PeriodLast As Boolean = False
    Public PARAM_AddOtherContributionsOnIR7Gross As Boolean = False

    Public PARAM_ShowPaymentDescOnBankFile As Boolean = False
    Public PARAM_NoAnnualUnitsDeduction As Boolean = False
    Public PARAM_OvertimeRate_BasedOnSalary2 As Boolean = False
    Public PARAM_GetOvertimeRate_FromRateOnSalary As Boolean = False
    Public PARAM_ShowNegativeNet As Boolean = True

    Public PARAM_warningonSIR As Boolean = False
    Public PARAM_PayslipNameOn As Boolean = False

    Public PARAM_ShowIncommision As Boolean = False
    Public PARAM_FiftyPercAplicableAmount As Double = 100000

    Public PARAM_HourlyAsSalaryForTax As Boolean = False

    Public GLBWebCam_TempFileNames2 As String
    Public PARAM_Variance25ShowAnl3 As Boolean = False

    Public PARAM_AddBIKOnEarnings As Boolean = False
    Public PARAM_SortByChequeNo As Boolean = False



    Public Enum Roles
        Admin
        Manager
        User
        NoRole
        TimeAttetance
    End Enum
    Public Enum TaStatus
        ACTUAL
        SCHEDULE
        POSTED
    End Enum


End Module
'PENDING

' Interface File to Bank , Company code missing
' Interface to Bank Tem_Group on company must be added


