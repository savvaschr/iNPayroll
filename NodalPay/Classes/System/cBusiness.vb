Public Class cBusiness
    Inherits cBusinessDBTier
#Region "FIN"
    Public Shadows Function GetFiscalPeriodsOfYear(ByVal Year As String, ByVal OnlyOpen As Boolean, ByVal OnlyNormal As Boolean) As DataSet
        Return MyBase.GetFiscalPeriodsOfYear(Year, OnlyOpen, OnlyNormal)
    End Function
    Public Shadows Function SearchForJournalCode(ByVal JournalType As String, ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean) As DataSet
        Return MyBase.SearchForJournalCode(JournalType, Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, ActiveOnly)
    End Function
    Public Shadows Function GetAllJournalCodesByJournalType(ByVal JournalType As String, ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetAllJournalCodesByJournalType(JournalType, OnlyActive)
    End Function
    Public Shadows Function GetAllJournalCodesForJournalEntry(ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetAllJournalCodesForJournalEntry(OnlyActive)
    End Function

    Public Shadows Function GetAllCurrencies() As DataSet
        Return MyBase.GetAllCurrencies()
    End Function

    Public Shadows Function GetAllCurrenciesRatesByCode(ByVal code As String) As DataSet
        Return MyBase.GetAllCurrenciesRatesByCode(code)
    End Function

    Public Shadows Function GetAllVatRatesByCode(ByVal code As String) As DataSet
        Return MyBase.GetAllVatRatesByCode(code)
    End Function

    Public Shadows Function GetAllJournalCodeByCode(ByVal code As String) As DataSet
        Return MyBase.GetAllJournalCodeByCode(code)
    End Function

    Public Shadows Function DeleteCurrency(ByVal code As String)
        Return MyBase.DeleteCurrency(code)
    End Function

    Public Shadows Function DeleteVat(ByVal code As String)
        Return MyBase.DeleteVat(code)
    End Function

    Public Shadows Function DeleteCurrencyRates(ByVal code As String)
        Return MyBase.DeleteCurrencyRates(code)
    End Function

    Public Shadows Function GetAllVats(ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetAllVats(OnlyActive)
    End Function

    Public Shadows Function GetAllJournalTypes() As DataSet
        Return MyBase.GetAllJournalTypes()
    End Function

    Public Shadows Function GetAllAnalysis(ByVal prefix As String, ByVal tableName As String, ByVal prefixForLevels As String) As DataSet
        Return MyBase.GetAllAnalysis(prefix, tableName, prefixForLevels)
    End Function

    Public Shadows Function GetAllAccountLineAnalysisLevel1(ByVal AnalysisNumber As Integer, ByVal OnlyActive As Boolean) As DataSet
        Dim Prefix As String = ""
        Dim TableName As String = ""
        Dim PrefixForLevels As String = ""

        Select Case AnalysisNumber
            Case 1
                Prefix = "AcLAn1"
                TableName = "FiAnAccountLineAnal1"
                PrefixForLevels = "AcLA21"
            Case 2
                Prefix = "AcLAn2"
                TableName = "FiAnAccountLineAnal2"
            Case 3
                Prefix = "AcLAn3"
                TableName = "FiAnAccountLineAnal3"
            Case 4
                Prefix = "AcLAn4"
                TableName = "FiAnAccountLineAnal4"
            Case 5
                Prefix = "AcLAn5"
                TableName = "FiAnAccountLineAnal5"
            Case 6
                Prefix = "AcLAn6"
                TableName = "FiAnAccountLineAnal6"
            Case 7
                Prefix = "AcLAn7"
                TableName = "FiAnAccountLineAnal7"
            Case 8
                Prefix = "AcLAn8"
                TableName = "FiAnAccountLineAnal8"
            Case 9
                Prefix = "AcLAn9"
                TableName = "FiAnAccountLineAnal9"
            Case 10
                Prefix = "AcLAn10"
                TableName = "FiAnAccountLineAnal10"
        End Select
        If AnalysisNumber = 1 Then
            Return MyBase.GetAllAccountLinesAnalysisLevel1(Prefix, TableName, OnlyActive, True)
        Else
            Return MyBase.GetAllAccountLinesAnalysisLevel1(Prefix, TableName, OnlyActive)
        End If
    End Function

    Public Shadows Function GetAllAccountLineAnalysisLevel2(ByVal OnlyActive As Boolean) As DataSet
        Dim Prefix As String = ""
        Dim TableName As String = ""
        Dim PrefixForLevels As String = ""

        Prefix = "AcLA21"
        TableName = "FiAnAccountLineAnal1Level2"
        PrefixForLevels = "AcLA31"
        Return MyBase.GetAllAccountLinesAnalysisLevel2(Prefix, TableName, PrefixForLevels, OnlyActive)
    End Function

    Public Shadows Function GetAllAccountLineAnalysisLevel3(ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetAllAccountLinesAnalysisLevel3(OnlyActive)
    End Function

    Public Shadows Function GetAllAccountAnalysisLevel1(ByVal AnalysisNumber As Integer, ByVal OnlyActive As Boolean) As DataSet
        Dim Prefix As String = ""
        Dim TableName As String = ""
        Dim PrefixForLevels As String = ""

        Select Case AnalysisNumber
            Case 1
                Prefix = "AccAn1"
                TableName = "FiAnAccountAnal1"
                PrefixForLevels = "AcLA21"
            Case 2
                Prefix = "AccAn2"
                TableName = "FiAnAccountAnal2"
            Case 3
                Prefix = "AccAn3"
                TableName = "FiAnAccountAnal3"
            Case 4
                Prefix = "AccAn4"
                TableName = "FiAnAccountAnal4"
            Case 5
                Prefix = "AccAn5"
                TableName = "FiAnAccountAnal5"
            Case 6
                Prefix = "AccAn6"
                TableName = "FiAnAccountAnal6"
            Case 7
                Prefix = "AccAn7"
                TableName = "FiAnAccountAnal7"
            Case 8
                Prefix = "AccAn8"
                TableName = "FiAnAccountAnal8"
            Case 9
                Prefix = "AccAn9"
                TableName = "FiAnAccountAnal9"
            Case 10
                Prefix = "AccAn10"
                TableName = "FiAnAccountAnal10"
        End Select
        If AnalysisNumber = 1 Then
            Return MyBase.GetAllAccountAnalysisLevel1(Prefix, TableName, OnlyActive, True)
        Else
            Return MyBase.GetAllAccountAnalysisLevel1(Prefix, TableName, OnlyActive)
        End If
    End Function

    Public Shadows Function GetAllAccountAnalysisLevel2(ByVal OnlyActive As Boolean) As DataSet
        Dim Prefix As String = ""
        Dim TableName As String = ""
        Dim PrefixForLevels As String = ""

        Prefix = "AccA21"
        TableName = "FiAnAccountAnal1Level2"
        PrefixForLevels = "AccA31"
        Return MyBase.GetAllAccountAnalysisLevel2(Prefix, TableName, PrefixForLevels, OnlyActive)
    End Function


    Public Shadows Function GetAllAccountAnalysisLevel3(ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetAllAccountAnalysisLevel3(OnlyActive)
    End Function

    Public Shadows Function GetLimitedAnalysis(ByVal code As String, ByVal descriptionS As String, ByVal choice As Integer, ByVal AnalysisCmbchoice As Integer)
        Return MyBase.GetLimitedAnalysis(code, descriptionS, choice, AnalysisCmbchoice)
    End Function

    Public Shadows Function SearchForAccountFin(ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean) As DataSet
        Return MyBase.SearchForAccountFin(Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, ActiveOnly)
    End Function
    Public Shadows Function GetWhatAnalysisToUse(ByVal AccTAnGrpCode) As DataSet
        Return MyBase.GetWhatAnalysisToUse(AccTAnGrpCode)
    End Function
    Public Shadows Function GetJournalCodeNextReferenceNo(ByVal JournalCode As cJournalCode) As String
        Return MyBase.GetJournalCodeNextReferenceNo(JournalCode)
    End Function
    Public Shadows Function GetFiTrxnCodeNextReferenceNo(ByVal TrxnCode As cFiTrxnCodes) As String
        Return MyBase.GetFiTrxnCodeNextReferenceNo(TrxnCode)
    End Function
    Public Shadows Function GetAllFiTrxnCodesByTrxnTypeByInvType(ByVal TrxnType As String, ByVal Invoicetype As String) As DataSet
        Return MyBase.GetAllFiTrxnCodesByTrxnTypeByInvType(TrxnType, Invoicetype)
    End Function
    Public Shadows Function GetCurruncyRate(ByVal Code As String, ByVal EffectiveDate As Date) As Double
        Return MyBase.GetCurruncyRate(Code, EffectiveDate)
    End Function
    Public Shadows Function GetVATRate(ByVal Code As String, ByVal EffectiveDate As Date) As Double
        Return MyBase.GetVATRate(Code, EffectiveDate)
    End Function
    Public Shadows Function GetJournalEntriesWithUnAllocBalance(ByVal BusPrtCode As String, ByVal DebitORCredit As String) As DataSet
        Return MyBase.GetJournalEntriesWithUnAllocBalance(BusPrtCode, DebitORCredit)
    End Function
    Public Shadows Function GetPeriodCode(ByVal PeriodDate As Date) As String
        Return MyBase.GetPeriodCode(PeriodDate)
    End Function
    Public Shadows Function SearchForBudget(ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean) As DataSet
        Return MyBase.SearchForBudget(Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, ActiveOnly)
    End Function
    Public Shadows Function GetFiTxAccountLinesLastIdSend() As Long
        Return MyBase.GetFiTxAccountLinesLastIdSend
    End Function
    Public Shadows Function GetFiTxAccountLinesMaxId() As Long
        Return MyBase.GetFiTxAccountLinesMaxId
    End Function

    Public Shadows Function GetAllFiTxAccountLinesFromID(ByVal IdFrom As Integer, ByVal IdTo As Integer) As DataSet
        Return MyBase.GetAllFiTxAccountLinesFromId(IdFrom, IdTo)
    End Function
    Public Shadows Function GetInterfaceToNodalHistory() As DataSet
        Return MyBase.getinterfacetonodalhistory
    End Function
    Public Shadows Function SearchForCustomer(ByVal Code As String, ByVal Description As String, ByVal Address As String, ByVal Phone As String, ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String, ByVal CustomerOnly As Boolean, ByVal SuplierOnly As Boolean) As DataSet
        Return MyBase.SearchForCustomer(Code, Description, Address, Phone, SearchCode, NextOrPrevius, PreviusSearchCode, CustomerOnly, SuplierOnly)
    End Function

#End Region
#Region "Payroll"
    Public Shadows Function GetAllPrMsTemplateGroup() As DataSet
        Return MyBase.GetAllPrMsTemplateGroup()
    End Function
    Public Shadows Function GetAllPrMsTemplateGroupOfUser(ByVal UserCode As String) As DataSet
        Return MyBase.GetAllPrMsTemplateGroupOfUser(UserCode)
    End Function
    Public Shadows Function GetAllPrMsContributionCodes() As DataSet
        Return MyBase.GetAllPrMsContributionCodes()
    End Function
    Public Shadows Function GetAllPrMsDeductionCodes() As DataSet
        Return MyBase.GetAllPrMsDeductionCodes()
    End Function
    Public Shadows Function GetAllPrMsEarningCodes() As DataSet
        Return MyBase.GetAllPrMsEarningCodes()
    End Function
    Public Shadows Function GetAllPrMsTemplateContributions(ByVal TemplateGroupCode As String) As DataSet
        Return MyBase.GetAllPrMsTemplateContributions(TemplateGroupCode)
    End Function
    Public Shadows Function GetAllPrMsTemplateDeductions(ByVal TemplateGroupCode As String) As DataSet
        Return MyBase.GetAllPrMsTemplateDeductions(TemplateGroupCode)
    End Function
    Public Shadows Function GetAllPrMsTemplateEarnings(ByVal TemplateGroupCode As String) As DataSet
        Return MyBase.GetAllPrMsTemplateEarnings(TemplateGroupCode)
    End Function
    Public Shadows Function DeleteEarnigsFromTemplateEarnings(ByVal GroupCode As String, ByVal EarnCode As String) As Boolean
        Return MyBase.DeleteEarnigsFromTemplateEarnings(GroupCode, EarnCode)
    End Function
    Public Shadows Function DeleteDeductionsFromTemplateDeductions(ByVal GroupCode As String, ByVal DeduCode As String) As Boolean
        Return MyBase.DeleteDeductionsFromTemplateDeductions(GroupCode, DeduCode)
    End Function
    Public Shadows Function DeleteContributionsFromTemplateContributions(ByVal GroupCode As String, ByVal ContCode As String) As Boolean
        Return MyBase.DeleteContributionsFromTemplateContributions(GroupCode, ContCode)
    End Function
    Public Shadows Function DeleteEarnigsFromEmployeeEarnings(ByVal GroupCode As String, ByVal EarnCode As String) As Boolean
        Return MyBase.DeleteEarnigsFromEmployeeEarnings(GroupCode, EarnCode)
    End Function
    Public Shadows Function DeleteDeductionsFromEmployeeDeductions(ByVal GroupCode As String, ByVal DeduCode As String) As Boolean
        Return MyBase.DeleteDeductionsFromEmployeeDeductions(GroupCode, DeduCode)
    End Function
    Public Shadows Function DeleteContributionsFromEmployeeContributions(ByVal GroupCode As String, ByVal ContCode As String) As Boolean
        Return MyBase.DeleteContributionsFromEmployeeContributions(GroupCode, ContCode)
    End Function
    ''
    Public Shadows Function DeleteEarnigsFromInterfaceEarnings(ByVal GroupCode As String, ByVal EarnCode As String) As Boolean
        Return MyBase.DeleteEarnigsFromInterfaceEarnings(GroupCode, EarnCode)
    End Function
    Public Shadows Function DeleteDeductionsFromInterfaceDeductions(ByVal GroupCode As String, ByVal DeduCode As String) As Boolean
        Return MyBase.DeleteDeductionsFromInterfaceDeductions(GroupCode, DeduCode)
    End Function
    Public Shadows Function DeleteContributionsFromInterfaceContributions(ByVal GroupCode As String, ByVal ContCode As String) As Boolean
        Return MyBase.DeleteContributionsFromInterfaceContributions(GroupCode, ContCode)
    End Function
    ''
    Public Shadows Function GetAllPrSsSocialInsPeriods() As DataSet
        Return MyBase.GetAllPrSsSocialInsPeriods()
    End Function
    Public Shadows Function GetAllPrSsPaymentCategory() As DataSet
        Return MyBase.GetAllPrSsPaymentCategory()
    End Function
    Public Shadows Function GetAllPrMsPeriodGroups() As DataSet
        Return MyBase.GetAllPrMsPeriodGroups
    End Function
    Public Shadows Function GetAllPrMsPeriodGroupsOfUser(ByVal UserCode As String, ByVal ShowALLYears As Boolean, ByVal Currentyear As String) As DataSet
        Return MyBase.GetAllPrMsPeriodGroupsOfUser(UserCode, ShowALLYears, Currentyear)
    End Function
    Public Shadows Function GetAllPrMsPeriodsByPeriodGroup(ByVal PeriodGroup As String)
        Return MyBase.GetAllPrMsPeriodsByPeriodGroup(PeriodGroup)
    End Function
    Public Shadows Function GetAllPrMsPeriodContributions(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False, Optional ByVal SortByReportingSequence As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodContributions(PeriodCode, PeriodGroupCode, OnlyActive, SortByReportingSequence)
    End Function
    Public Shadows Function GetAllPrMsPeriodDeductions(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False, Optional ByVal SortByReportingSequence As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodDeductions(PeriodCode, PeriodGroupCode, OnlyActive, SortByReportingSequence)
    End Function
    Public Shadows Function GetAllPrMsPeriodEarnings(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False, Optional ByVal SortByReportingSequence As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodEarnings(PeriodCode, PeriodGroupCode, OnlyActive, SortByReportingSequence)
    End Function
    ''
    Public Shadows Function GetAllPrMsPeriodContributionsOrderBySeq(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodContributionsOrderBySeq(PeriodCode, PeriodGroupCode, OnlyActive)
    End Function
    Public Shadows Function GetAllPrMsPeriodDeductionsOrderBySeq(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodDeductionsOrderBySeq(PeriodCode, PeriodGroupCode, OnlyActive)
    End Function
    Public Shadows Function GetAllPrMsPeriodEarningsOrderBySeq(ByVal PeriodCode As String, ByVal PeriodGroupCode As String, Optional ByVal OnlyActive As Boolean = False) As DataSet
        Return MyBase.GetAllPrMsPeriodEarningsOrderBySeq(PeriodCode, PeriodGroupCode, OnlyActive)
    End Function
    ''
    Public Shadows Function GetAllPrMsTemplateEarningsByTemplateGroup(ByVal TempGroup As String) As DataSet
        Return MyBase.GetAllPrMsTemplateEarningsByTemplateGroup(TempGroup)
    End Function
    Public Shadows Function GetAllPrMsTemplateDeductionsByTemplateGroup(ByVal TempGroup As String) As DataSet
        Return MyBase.GetAllPrMsTemplateDeductionsByTemplateGroup(TempGroup)
    End Function
    Public Shadows Function GetAllPrMsTemplateContributionsByTemplateGroup(ByVal TempGroup As String) As DataSet
        Return MyBase.GetAllPrMsTemplateContributionsByTemplateGroup(TempGroup)
    End Function
    Public Shadows Function DeletePrMsPeriodEarnings(ByVal PeriodCode As String, ByVal GroupCode As String) As Boolean
        Return MyBase.DeletePrmsPeriodEarnings(PeriodCode, GroupCode)
    End Function
    Public Shadows Function DeletePrMsPeriodDeductions(ByVal PeriodCode As String, ByVal GroupCode As String) As Boolean
        Return MyBase.DeletePrmsPeriodDeductions(PeriodCode, GroupCode)
    End Function
    Public Shadows Function DeletePrMsPeriodContributions(ByVal PeriodCode As String, ByVal GroupCode As String) As Boolean
        Return MyBase.DeletePrmsPeriodContributions(PeriodCode, GroupCode)
    End Function
    Public Shadows Function DeletePrMsPeriodCode(ByVal PeriodCode As String, ByVal GroupCode As String) As Boolean
        Return MyBase.DeletePrmsPeriodCode(PeriodCode, GroupCode)
    End Function
    Public Shadows Function SearchForEmployee(ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal Nextorprevius As String, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean, ByVal TempGroup As String) As DataSet
        Return MyBase.SearchForEmployee(Code, Description, SearchCode, Nextorprevius, PreviusSearchCode, ActiveOnly, TempGroup)
    End Function
    Public Shadows Function SearchForEmployeeByUser(ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal Nextorprevius As String, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean, ByVal TempGroup As String, ByVal UserCode As String, ByVal OnlyNew As Boolean, ByVal SI As String, ByVal ID As String, ByVal TIC As String, ByVal ARC As String, ByVal SICat As String, ByVal NoSI As Boolean, ByVal Phone As String) As DataSet
        Return MyBase.SearchForEmployeeByUser(Code, Description, SearchCode, Nextorprevius, PreviusSearchCode, ActiveOnly, TempGroup, UserCode, OnlyNew, SI, ID, TIC, ARC, SICat, NoSI, Phone)
    End Function
    Public Shadows Function SearchForEmployeeByUser2(ByVal Code As String, ByVal Description As String, ByVal SearchCode As String, ByVal Nextorprevius As String, ByVal PreviusSearchCode As String, ByVal ActiveOnly As Boolean, ByVal TempGroup As String, ByVal UserCode As String) As DataSet
        Return MyBase.SearchForEmployeeByUser2(Code, Description, SearchCode, Nextorprevius, PreviusSearchCode, ActiveOnly, TempGroup, UserCode)
    End Function
    Public Shadows Function SearchForEmployeesWithTermDateOfThisPeriod(ByVal TempGroup As String) As DataSet
        Return MyBase.SearchForEmployeesWithTermDateOfThisPeriod(TempGroup)
    End Function
    Public Shadows Function SearchForOnlyActiveEmployees(ByVal TempGroup As String) As DataSet
        Return MyBase.SearchForOnlyActiveEmployees(TempGroup)
    End Function
    Public Shadows Function SearchForEmployee2(ByVal Code As String, ByVal Description As String, ByVal ActiveOnly As Boolean) As DataSet
        Return MyBase.SearchForEmployee2(Code, Description, ActiveOnly)
    End Function
    Public Shadows Function GetAllPrTxEmployeeSalaryByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeSalaryByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetAllPrTxEmployeeSalaryByEmpCodeForCopy(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeSalaryByEmpCodeForCopy(EmpCode)
    End Function
    Public Shadows Function GetAllPrTxEmployeeLeaveByEmpCodeOfYear(ByVal EmpCode As String, ByVal YEAR As String, ByVal ALType As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeLeaveByEmpCodeOfYEAR(EmpCode, YEAR, ALType)
    End Function
    Public Shadows Function GetAllPrTxEmployeeLeaveByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeLeaveByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetAllPrTxEmployeeLeaveByEmpCodeAndYear(ByVal EmpCode As String, ByVal Year As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeLeaveByEmpCodeAndYear(EmpCode, Year)
    End Function
    Public Shadows Function GetAllPrTxEmployeeLeaveByEmpCodeForCopy(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
        Return MyBase.GetAllPrTxEmployeeLeaveByEmpCodeForCopy(EmpCode, FromDate, ToDate)
    End Function
    Public Shadows Function GetAllPrTxEmployeeAdvancesByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeAdvancesByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetAllPrTxEmployeeDiscountsByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeDiscountsByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetAllPrMsEmployeeContributions(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrMsEmployeeContributions(EmpCode)
    End Function
    Public Shadows Function GetAllPrMsEmployeeDeductions(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrMsEmployeeDeductions(EmpCode)
    End Function
    Public Shadows Function GetAllPrMsEmployeeEarnings(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrMsEmployeeEarnings(EmpCode)
    End Function
    Public Shadows Function DeleteEmployeeEarnings(ByVal EmpCode As String, ByVal TemGrpCode As String) As Boolean
        Return MyBase.DeleteEmployeeEarnings(EmpCode, TemGrpCode)
    End Function
    Public Shadows Function DeleteEmployeeDeductions(ByVal EmpCode As String, ByVal TemGrpCode As String) As Boolean
        Return MyBase.DeleteEmployeeDeductions(EmpCode, TemGrpCode)
    End Function
    Public Shadows Function DeleteEmployeeContributions(ByVal EmpCode As String, ByVal TemGrpCode As String) As Boolean
        Return MyBase.DeleteEmployeeContributions(EmpCode, TemGrpCode)
    End Function
    Public Shadows Function DeletePeriodEarnings(ByVal PerGrpCode As String) As Boolean
        Return MyBase.DeletePeriodEarnings(PerGrpCode)
    End Function
    Public Shadows Function DeletePeriodDeductions(ByVal PerGrpCode As String) As Boolean
        Return MyBase.DeletePeriodDeductions(PerGrpCode)
    End Function
    Public Shadows Function DeletePeriodContributions(ByVal PerGrpCode As String) As Boolean
        Return MyBase.DeletePeriodContributions(PerGrpCode)
    End Function
    Public Shadows Function FindCurrentPeriod1(ByVal TemGrpCode As String) As DataSet
        Return MyBase.FindCurrentPeriod1(TemGrpCode)
    End Function
    Public Shadows Function FindCurrentPeriodMonthNormalDays(ByVal Period As cPrMsPeriodCodes) As Double
        Return MyBase.FindCurrentPeriodMonthNormalDays(period)
    End Function
    Public Shadows Function GetCurrentSalary(ByVal EmpCode As String, ByVal CurDate As Date) As cPrTxEmployeeSalary
        Return MyBase.GetCurrentSalary(EmpCode, CurDate)
    End Function
    Public Shadows Function GetNumberOfNormalPeriodsBack(ByVal EmpSalary As cPrTxEmployeeSalary, ByVal CurrentPeriod As cPrMsPeriodCodes) As Integer
        Return MyBase.GetNumberOfNormalPeriodsBack(EmpSalary, CurrentPeriod)
    End Function
    Public Shadows Function GetNumberOfNormalWorkedPeriods(ByVal EmpCode As String, ByVal CurrentPeriod As cPrMsPeriodCodes) As Integer
        Return MyBase.GetNumberOfNormalWorkedPeriods(EmpCode, CurrentPeriod)
    End Function
    Public Shadows Function Find13nthPeriodUnits(ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.Find13nthPeriodUnits(CurrentPeriod)
    End Function
    Public Shadows Function Find14nthPeriodUnits(ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.Find14nthPeriodUnits(CurrentPeriod)
    End Function
    Public Shadows Function GetSumOfAnuallUnitsForX(ByVal GLBCurrentPeriod As cPrMsPeriodCodes, ByVal EmployeeCode As String) As Double
        Return MyBase.GetSumOfAnuallUnitsForX(GLBCurrentPeriod, EmployeeCode)
    End Function
    Public Shadows Function GetAllPrSsLimits() As DataSet
        Return MyBase.GetAllPrSsLimits()
    End Function
    Public Shadows Function GetActivelimitsForPeriod(ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetActiveLimitsForPeriod(Period)
    End Function
    Public Shadows Function FindSIIncomeForThisPeriodYearUntilNow(ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String, ByVal MyType As String, ByVal TempGroupCode As String) As Double
        Return MyBase.FindSIIncomeForThisPeriodYearUntilNow(Period, EmpCode, MyType, TempGroupCode)
    End Function
    Public Shadows Function FindSIValueForEmployeeForPeriod(ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String, ByVal MyType As String, ByVal TempGroupCode As String) As Double
        Return MyBase.FindSIValueForEmployeeForPeriod(Period, EmpCode, MyType, TempGroupCode)
    End Function
    Public Shadows Function FindSIPeriodInsurableIncomeForEmployeeForPeriod(ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String, ByVal TempGroupCode As String) As Double
        Return MyBase.FindSIPeriodInsurableIncomeForEmployeeForPeriod(Period, EmpCode, TempGroupCode)
    End Function
    Public Shadows Function FindSIPeriodInsurableIncomeForEmployeeForPeriodGroup(ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String, ByVal TempGroupCode As String) As Double
        Return MyBase.FindSIPeriodInsurableIncomeForEmployeeForPeriodGroup(Period, EmpCode, TempGroupCode)
    End Function
   

    Public Shadows Function GetAllPrMsEmployeesByTemplateGroup(ByVal TempGroupCode As String, ByVal FromEmployeeCode As String, ByVal ToEmployeeCode As String, ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal Analysis As Integer, ByVal AnalCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal SortOrder As Integer, ByVal OnlyLeavers As Boolean, ByVal GenAnal1 As String, ByVal StartCode As String, ByVal NorP As Integer, ByVal EndCode As String, ByVal TopValue As String, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetAllPrMsEmployeesByTemplateGroup(TempGroupCode, FromEmployeeCode, ToEmployeeCode, CurrentPeriod, Analysis, AnalCode, Cash, Cheque, Bank, SortOrder, OnlyLeavers, GenAnal1, StartCode, NorP, EndCode, TopValue, Ewallet)
    End Function
    Public Shadows Function GetAllPrMsEmployeesByTemplateGroupFORSearch(ByVal TempGroupCode As String, ByVal FromEmployeeCode As String, ByVal ToEmployeeCode As String, ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal AnalValue As String, ByVal SortOrder As Integer, ByVal Analysis As Integer, ByVal Punit1 As String, ByVal PUnit2 As String, ByVal PUnit3 As String) As DataSet
        Return MyBase.GetAllPrMsEmployeesByTemplateGroupFORSearch(TempGroupCode, FromEmployeeCode, ToEmployeeCode, CurrentPeriod, AnalValue, SortOrder, Analysis, Punit1, PUnit2, PUnit3)
    End Function
    Public Shadows Function GetAllPrTxEmployeeDiscounts(ByVal PrdGrp_Code As String, ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeDiscounts(PrdGrp_Code, EmpCode)
    End Function
    Public Shadows Function GetAllPrTxEmployeeDiscountsForCopy(ByVal EmpCode As String, ByVal PeriodGroupCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeDiscountsForCopy(EmpCode, PeriodGroupCode)
    End Function
    Public Shadows Function GetAllPrMsEmployeeRemindersForCopy(ByVal EmpCode As String, ByVal PeriodGroupCode As String) As DataSet
        Return MyBase.GetAllPrMsEmployeeRemindersForCopy(EmpCode, PeriodGroupCode)
    End Function
    Public Shadows Function FindSumForThisPeriodYearUntilNowOfContributionCodeType(ByVal Period As cPrMsPeriodCodes, ByVal ConCode As cPrMsContributionCodes, ByVal EmpCode As String) As Double
        Return MyBase.FindSumForThisPeriodYearUntilNowOfContributionCodeType(Period, ConCode, EmpCode)
    End Function
    Public Shadows Function GetToDate_SI_PF_MF(ByVal Emp As cPrMsEmployees, ByVal DedCod As cPrMsDeductionCodes, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetToDate_SI_PF_MF(Emp, DedCod, CurrentPeriod)
    End Function
    Public Shadows Function GetToDate_SplitSI(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes)
        Return MyBase.GetToDate_SplitSI(Emp, CurrentPeriod)
    End Function
    Public Shadows Function GetToDate_SI_PF_MF(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal DedType As String) As Double
        Return MyBase.GetToDate_SI_PF_MF(Emp, CurrentPeriod, DedType)
    End Function
    Public Shadows Function GetToDate_Contributions(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal DedType As String) As Double
        Return MyBase.GetToDate_Contributions(Emp, CurrentPeriod, DedType)
    End Function
    Public Shadows Function GetToDate_PeriodSplit(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetToDate_PeriodSplit(Emp, CurrentPeriod)
    End Function
    Public Shadows Function GetToDate_SpecialTax(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal DedType As String) As Double
        Return MyBase.GetToDate_SpecialTax(Emp, CurrentPeriod, DedType)
    End Function
    Public Shadows Function GetNumberOfTaxablePeriodsToDate(ByVal tPerCode As cPrMsPeriodCodes)
        Return MyBase.GetNumberOfTaxablePeriodsToDate(tPerCode)
    End Function
    Public Shadows Function GetPeriodValueOf_IT_ForEmployeeForPeriods(ByVal EmpCode As String, ByVal PerF As cPrMsPeriodCodes, ByVal perT As cPrMsPeriodCodes) As Double
        Return MyBase.GetPeriodvalueOf_IT_ForEmployeeForPeriods(EmpCode, PerF, perT)
    End Function
    Public Shadows Function GetPeriodValueOf_SI_ForEmployeeForPeriods(ByVal EmpCode As String, ByVal PerF As cPrMsPeriodCodes, ByVal perT As cPrMsPeriodCodes) As Double
        Return MyBase.GetPeriodvalueOf_SI_ForEmployeeForPeriods(EmpCode, PerF, perT)
    End Function
    Public Shadows Function GetPeriodValueOf_IT_ForHeader(ByVal HeaderId As Integer) As Double
        Return MyBase.GetPeriodvalueOf_IT_ForHeader(HeaderId)
    End Function
    Public Shadows Function GetPeriodValueOf_SI_ForHeader(ByVal HeaderId As Integer) As Double
        Return MyBase.GetPeriodvalueOf_SI_ForHeader(HeaderId)
    End Function

    Public Shadows Function GetLifeInsurance_AND_Discounts_ToDate(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetLifeInsurance_And_Discounts_ToDate(Emp, CurrentPeriod)
    End Function
    Public Shadows Function GetTaxableFromOther_ToDate(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetTaxableFromOther_ToDate(Emp, CurrentPeriod)
    End Function
    Public Shadows Function GetAllPrSsTaxTable() As DataSet
        Return MyBase.GetAllPrSsTaxTable()
    End Function
    Public Shadows Function GetAllPrSsExtraTaxTable() As DataSet
        Return MyBase.GetAllPrSsExtraTaxTable()
    End Function
    'Public Shadows Function GetAllPrSsDecreaseTable(ByVal Code As String) As DataSet
    '    Return MyBase.GetAllPrSsDecreaseTable(Code)
    'End Function
    Public Shadows Function GetAllPrSsDecreaseTable() As DataSet
        Return MyBase.GetAllPrSsDecreaseTable()
    End Function
    Public Shadows Function GetITValueToDate(ByVal Emp As cPrMsEmployees, ByVal DedCod As cPrMsDeductionCodes, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetITValueToDate(Emp, DedCod, CurrentPeriod)
    End Function
    Public Shadows Function DeleteAllEDCFromTrxnLines(ByVal HdrId As Integer) As Boolean
        Return MyBase.DeleteAllEDCFromTrxnLines(HdrId)
    End Function
    Public Shadows Function HasFutureRecords(ByVal EmpCode As String, ByVal HdrId As Integer) As Boolean
        Return MyBase.hasfuturerecords(EmpCode, HdrId)
    End Function
    Public Shadows Function DeleteAllAnnualLeaveOfHeaderID(ByVal HdrId As Integer) As Boolean
        Return MyBase.DeleteAllAnnualLeaveOfHeaderId(HdrId)
    End Function
    Public Shadows Function DeleteAllLoanLinesOfHeaderID(ByVal HDRId As Integer) As Boolean
        Return MyBase.DeleteAllLoanLinesOfHeaderId(HDRId)
    End Function
    Public Shadows Function DeleteAllAnnualLeaveOfEmployeeCode(ByVal EmpCode As String) As Boolean
        Return MyBase.DeleteAllAnnualLeaveOfEmployeeCode(EmpCode)
    End Function
    Public Shadows Function DeleteTrxnHeader(ByVal HdrId As Integer) As Boolean
        Return MyBase.DeleteTrxnHeader(HdrId)
    End Function
    Public Shadows Function DeleteIR59(ByVal HdrId As Integer) As Boolean
        Return MyBase.DeleteIR59(HdrId)
    End Function

    Public Shadows Function GetErnYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetErnYTD(GLBEmployee, GLBCurrentPeriod)
    End Function
    Public Shadows Function GetNetYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetNetYTD(GLBEmployee, GLBCurrentPeriod)
    End Function

    Public Shadows Function GetDedYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetDedYTD(GLBEmployee, GLBCurrentPeriod)
    End Function
    Public Shadows Function GetConYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.GetConYTD(GLBEmployee, GLBCurrentPeriod)
    End Function
    Public Shadows Function GetAllTrxnLines(ByVal HeaderId As Long) As DataSet
        Return MyBase.GetAllTrxnLines(HeaderId)
    End Function
    Public Shadows Function GetAllTrxnHeaders(ByVal Emp As cPrMsEmployees, ByVal CurrPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetAllTrxnHeaders(Emp, CurrPeriod)

    End Function
   
    Public Shadows Function GetAllTrxnHeadersOfEmployee(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllTrxnHeadersOfEmployee(EmpCode)
    End Function
    

    Public Shadows Function GetAllCompaniesFullRow(ByVal ComCode As String) As DataSet
        Return MyBase.GetAllCompaniesFullRow(ComCode)
    End Function
    Public Shadows Function GetAllCompaniesFullRow() As DataSet
        Return MyBase.GetAllCompaniesFullRow()
    End Function

    Public Shadows Function GetReportPaySlipEmployee(ByVal EmpCode As String) As DataSet
        Return MyBase.GetReportPaySlipEmployee(EmpCode)
    End Function

    Public Shadows Function GetReportPaySlipHeader(ByVal EmpCode As String, ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String) As DataSet
        Return MyBase.GetReportPaySlipHeader(EmpCode, PrdGrp_Code, PrdGrp_Code)
    End Function

    Public Shadows Function GetReportPaySlipLines(ByVal EmpCode As String, ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String, ByVal Type As String) As DataSet
        Return MyBase.GetReportPaySlipLines(EmpCode, PrdGrp_Code, PrdGrp_Code, Type)
    End Function

    Public Shadows Function GetReportIR63AHeader(ByVal EmpCode As String, ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String)
        Return MyBase.GetReportIR63AHeader(EmpCode, PrdGrp_Code, PrdGrp_Code)
    End Function

    Public Shadows Function GetReportIR63AEmpl(ByVal EmpCode As String) As DataSet
        Return MyBase.GetReportIR63AEmpl(EmpCode)
    End Function

    Public Shadows Function GetReportIR7(ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String) As DataSet
        Return MyBase.GetReportIR7(PrdGrp_Code, PrdCod_Code)
    End Function


    Public Shadows Function GetReportSIContributions(ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String) As DataSet
        Return MyBase.GetReportSIContributions(PrdGrp_Code, PrdCod_Code)
    End Function

    Public Shadows Function GetReportPayrollAnalysis(ByVal PrdGrp_Code As String, ByVal PrdCod_Code As String) As DataSet
        Return MyBase.GetReportPayrollAnalysis(PrdGrp_Code, PrdCod_Code)
    End Function


    Public Shadows Function FindYTD_EDC(ByVal Employee As cPrMsEmployees, ByVal Period As cPrMsPeriodCodes, ByVal EDCCode As String, ByVal EDCType As String) As Double
        Return MyBase.FindYTD_EDC(Employee, Period, EDCCode, EDCType)
    End Function
    Public Shadows Function FindYTD_EDC_2(ByVal EmpCode As String, ByVal Period As cPrMsPeriodCodes, ByVal EDCCode As String, ByVal EDCType As String) As Double
        Return MyBase.FindYTD_EDC_2(EmpCode, Period, EDCCode, EDCType)
    End Function
    Public Shadows Function CalculateUnitsFor13(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.CalculateUnitsFor13(Emp, CurrentPeriod)

    End Function
    Public Shadows Function CalculateSalaryFor13(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.CalculateSalaryFor13(Emp, CurrentPeriod)

    End Function
    Public Shadows Function CalculateEarningsFor13SalaryAverage(ByVal emp As cPrMsEmployees, ByVal Period As cPrMsPeriodCodes, ByVal EarningCode As String) As DataSet
        Return MyBase.CalculateEarningsFor13SalaryAverage(emp, Period, EarningCode)

    End Function
    Public Shadows Function CalculateNormalUnitsForPeriodsAfter(ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.CalculateNormalUnitsForPeriodsAfter(CurrentPeriod)
    End Function
    Public Shadows Function CalculateUnitsFor14(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.CalculateUnitsFor14(Emp, CurrentPeriod)

    End Function
    Public Shadows Function CalculateSalaryFor14(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.CalculateSalaryFor14(Emp, CurrentPeriod)

    End Function
    Public Shadows Function CalculateNormalUnitsForPeriodsAfterByDate(ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Return MyBase.CalculateNormalUnitsForPeriodsAfterByDate(CurrentPeriod)
    End Function
    Public Shadows Function GetAllActiveEmployeesForPeriod(ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetAllActiveEmployeesForPeriod(Period)
    End Function
    Public Shadows Function GetAllTrxnsForPeriodByStatus(ByVal Period As cPrMsPeriodCodes, ByVal Status As String, ByVal InterStatus As String) As DataSet
        Return MyBase.GetAllTrxnsForPeriodByStatus(Period, Status, InterStatus)
    End Function
    Public Shadows Function OpenNextPeriodIfExist(ByVal Period As cPrMsPeriodCodes) As Boolean
        Return MyBase.OpenNextPeriodIfExist(Period)
    End Function
    Public Shadows Function CheckIfLastPeriod(ByVal period As cPrMsPeriodCodes) As Boolean
        Return MyBase.checkiflastperiod(period)

    End Function
    Public Shadows Function GetTaTrxnLines(ByVal EmpCode As String, ByVal fromDate As Date, ByVal ToDate As Date) As DataSet
        Return MyBase.GetTaTrxnLines(EmpCode, fromDate, ToDate)
    End Function
    Public Shadows Function GetTaTrxnLines2(ByVal EmpCode As String, ByVal fromDate As Date, ByVal ToDate As Date) As DataSet
        Return MyBase.GetTaTrxnLines2(EmpCode, fromDate, ToDate)
    End Function
    Public Shadows Function GetTaTrxnLines2_SumPerAnalysis(ByVal EmpCode As String, ByVal fromDate As Date, ByVal ToDate As Date) As DataSet
        Return MyBase.GetTaTrxnLines2_SumPerAnalysis(EmpCode, fromDate, ToDate)
    End Function
    Public Shadows Function GetTaTrxnLines2_Sum(ByVal EmpCode As String, ByVal fromDate As Date, ByVal ToDate As Date) As Double
        Return MyBase.GetTaTrxnLines2_Sum(EmpCode, fromDate, ToDate)
    End Function
    Public Shadows Function GetAllWorkCodes() As DataSet
        Return MyBase.GetAllWorkCodes
    End Function
    Public Shadows Function REPORT_PreparePayslipFor(ByVal Emp As cPrMsEmployees, ByVal Prd As cPrMsPeriodCodes, ByVal Hdr As cPrTxTrxnHeader, ByVal chequeDate As Date, ByVal PrintIncurrency As Boolean) As DataSet
        Return MyBase.REPORT_PreparePayslipFor(Emp, Prd, Hdr, chequeDate, PrintIncurrency)
    End Function
    Public Shadows Function REPORT_PreparePayslipForAllMonths(ByVal Emp As cPrMsEmployees, ByVal Prd As cPrMsPeriodCodes, ByVal Hdr As cPrTxTrxnHeader, ByVal chequeDate As Date, ByVal PrintIncurrency As Boolean) As DataSet
        Return MyBase.REPORT_PreparePayslipForAllMonths(Emp, Prd, Hdr, chequeDate, PrintIncurrency)
    End Function
    Public Shadows Function REPORT_PreparePayslipForAllMonthsTOTALS(ByVal Emp As cPrMsEmployees, ByVal Prd As cPrMsPeriodCodes, ByVal Hdr As cPrTxTrxnHeader, ByVal chequeDate As Date, ByVal PrintIncurrency As Boolean) As DataSet
        Return MyBase.REPORT_PreparePayslipForAllMonthsTOTALS(Emp, Prd, Hdr, chequeDate, PrintIncurrency)
    End Function
    Public Shadows Function GetTypeOfEDCIfPercentage(TemplateCode As String) As DataSet
        Return MyBase.GetTypeOfEDCIfPercentage(TemplateCode)
    End Function

    Public Shadows Function GetCompanyDetailsForShowTotalsAsPayslipReport(ByVal CompanyCode As String)
        Return MyBase.GetCompanyDetailsForShowTotalsAsPayslipReport(CompanyCode)
    End Function
    Public Shadows Function GetEmployeeTimesheets(ByVal EmpCode As String, ByVal TemGroup As String, ByVal PerGroup As String, ByVal PerCode As String) As DataSet
        Return MyBase.GetEmployeeTimesheets(EmpCode, TemGroup, PerGroup, PerCode)
    End Function
    Public Shadows Function GetTimesheets(ByVal TemGroup As String, ByVal PerGroup As String, ByVal PerCode As String) As DataSet
        Return MyBase.GetTimesheets(TemGroup, PerGroup, PerCode)
    End Function
    Public Shadows Function UpdateEmployeeTimesheets(ByVal EmpCode As String, ByVal GLB_TempGroup As String, ByVal GLB_PeriodGroup As String, ByVal GLB_PeriodCode As String, ByVal MonthDiff As String, ByVal TotalMonthNormal As String, ByVal TotalAL As String, ByVal TotalSick As String, ByVal TotalArmy As String, ByVal TotalMater As String) As Boolean
        Return MyBase.UpdateEmployeeTimesheets(EmpCode, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode, MonthDiff, TotalMonthNormal, TotalAL, TotalSick, TotalArmy, TotalMater)
    End Function
    Public Shadows Function DeleteEmployeeTimesheets(ByVal TemGroup As String, ByVal PerGroup As String, ByVal PerCode As String) As Boolean
        Return MyBase.DeleteEmployeeTimesheets(TemGroup, PerGroup, PerCode)
    End Function
    Public Shadows Function GetEDCValueofHeaderId(ByVal HeaderID As Integer, ByVal Type As String, ByVal EDCTypeCode As String) As Double
        Return MyBase.GetEDCValueofHeaderId(HeaderID, Type, EDCTypeCode)
    End Function
    Public Shadows Function getCurrentAnalysisAndPosition(ByVal EmpCode As String) As DataSet
        Return MyBase.GetCurrentAnalysisAndPosition(EmpCode)
    End Function
    Public Shadows Function REPORT_IR63A(ByVal PerGrp As cPrMsPeriodGroups, ByVal EmpCode As String, ByVal DsIR7 As DataSet, ByVal NameOnIR63 As String, ByVal DesignationOnIR63 As String, ByVal PrintDateOnIR63 As String) As DataSet
        Return MyBase.REPORT_IR63A(PerGrp, EmpCode, DsIR7, NameOnIR63, DesignationOnIR63, PrintDateOnIR63)

    End Function
    Public Shadows Function REPORT_IR63A_2019(ByVal PerGrp As cPrMsPeriodGroups, ByVal EmpCode As String, ByVal DsIR7 As DataSet, ByVal NameOnIR63 As String, ByVal DesignationOnIR63 As String, ByVal PrintDateOnIR63 As String) As DataSet
        Return MyBase.REPORT_IR63A_2019(PerGrp, EmpCode, DsIR7, NameOnIR63, DesignationOnIR63, PrintDateOnIR63)

    End Function
    Public Shadows Function REPORT_IR63A_2020(ByVal PerGrp As cPrMsPeriodGroups, ByVal EmpCode As String, ByVal DsIR7 As DataSet, ByVal NameOnIR63 As String, ByVal DesignationOnIR63 As String, ByVal March As Boolean, ByVal Period14 As Boolean, ByVal PrintDateOnIR63 As String) As DataSet
        Return MyBase.REPORT_IR63A_2020(PerGrp, EmpCode, DsIR7, NameOnIR63, DesignationOnIR63, March, Period14, PrintDateOnIR63)

    End Function
    Public Shadows Function REPORT_SpecialContribution(ByVal PerGrp As cPrMsPeriodGroups, ByVal EmpCode As String, ByVal DsIR7 As DataSet) As DataSet
        Return MyBase.REPORT_SpecialContribution(PerGrp, EmpCode, DsIR7)

    End Function
    Public Shadows Function REPORT_IR7(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date) As DataSet
        Return MyBase.REPORT_IR7(PerGrp, FromCode, ToCode, YearDate)

    End Function
    Public Shadows Function REPORT_IR7_2(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date, Optional ByVal showmessages As Boolean = True) As DataSet
        Return MyBase.REPORT_IR7_2(PerGrp, FromCode, ToCode, YearDate, showmessages)

    End Function
    Public Shadows Function REPORT_IR7_3(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date, Optional ByVal showmessages As Boolean = True) As DataSet
        Return MyBase.REPORT_IR7_3(PerGrp, FromCode, ToCode, YearDate, showmessages)

    End Function
    Public Shadows Function REPORT_IR7_4(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date, Optional ByVal showmessages As Boolean = True, Optional ByVal ShowInExcel As Boolean = False, Optional ByVal BIKOnSI As Boolean = False, Optional ByVal Dissablerehire As Boolean = False) As DataSet
        Return MyBase.REPORT_IR7_4(PerGrp, FromCode, ToCode, YearDate, showmessages, ShowInExcel, BIKOnSI, Dissablerehire)

    End Function
    Public Shadows Function REPORT_IR7_4_ForPERIOD(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date, ForPeriodCode As String, Optional ByVal showmessages As Boolean = True, Optional ByVal ShowInExcel As Boolean = False, Optional ByVal BIKOnSI As Boolean = False, Optional ByVal Dissablerehire As Boolean = False) As DataSet
        Return MyBase.REPORT_IR7_4_ForPERIOD(PerGrp, FromCode, ToCode, YearDate, ForPeriodCode, showmessages, ShowInExcel, BIKOnSI, Dissablerehire)

    End Function

    Public Shadows Function REPORT_IR7_2017(ByVal PerGrp As cPrMsPeriodGroups, ByVal FromCode As String, ByVal ToCode As String, ByVal YearDate As Date, Optional ByVal showmessages As Boolean = True) As DataSet
        Return MyBase.REPORT_IR7_2017(PerGrp, FromCode, ToCode, YearDate, showmessages)

    End Function
    Public Shadows Function REPORT_IR61(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_GetTaxableIncome(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_GetTaxableIncome(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_GetTaxableIncome_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_GetTaxableIncome_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR112(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR112(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_ST_DEDUCTION(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_ST_DEDUCTION(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_ST_CONTRIBUTION(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_ST_CONTRIBUTION(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_DEDUCTION(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_DEDUCTION(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_DEDUCTION_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_DEDUCTION_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION_LWBPen(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION_LWBPen(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION_LWBPen_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION_LWBPen_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION_Directors(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION_Directors(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_CONTRIBUTION_Directors_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_CONTRIBUTION_Directors_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_DEDUCTION_Directors(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_DEDUCTION_Directors(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_IR61_Gesy_DEDUCTION_Directors_PerEmployee(ByVal PerGrp As cPrMsPeriodGroups, ByVal SIPeriod As cPrSsSocialInsPeriods) As DataSet
        Return MyBase.REPORT_IR61_Gesy_DEDUCTION_Directors_PerEmployee(PerGrp, SIPeriod)

    End Function
    Public Shadows Function REPORT_PrepareSIContributions(ByVal Per As cPrMsPeriodCodes, ByVal TemGrp As cPrMsTemplateGroup, ByVal SocInsCat As cPrAnSocialInsCategories, ByVal SocInsPeriod As cPrSsSocialInsPeriods, ByVal PerGrp As cPrMsPeriodGroups, ByVal CompanySINo As String) As DataSet
        Return MyBase.REPORT_PrepareSIContributions_PerCompany(Per, TemGrp, SocInsCat, SocInsPeriod, PerGrp, CompanySINo)

    End Function

    Public Shadows Function REPORT_PrepareSIContributionsPERPeriod(ByVal Per As cPrMsPeriodCodes, ByVal TemGrp As cPrMsTemplateGroup, ByVal SocInsCat As cPrAnSocialInsCategories, ByVal PerGrp As cPrMsPeriodGroups, ByVal CompanySINo As String) As DataSet
        Return MyBase.REPORT_PrepareSIContributionsPERPeriod_PerCompany(Per, TemGrp, SocInsCat, PerGrp, CompanySINo)

    End Function


    Public Shadows Function UpdateTaTxTrxnLines(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal Status As String) As Integer
        Return MyBase.UpdateTaTxTrxnLines(EmpCode, FromDate, ToDate, Status)
    End Function
    Public Shadows Function UpdateTaTxTrxnLines2(ByVal EmpCode As String, ByVal MyDate As Date, ByVal Status As String) As Integer
        Return MyBase.UpdateTaTxTrxnLines2(EmpCode, MyDate, Status)
    End Function
    Public Shadows Function CheckIfExistsOnTrxnLines(ByVal EmpCode As String, ByVal Mydate As Date) As Boolean
        Return MyBase.CheckIfExistsOnTrxnLines(EmpCode, Mydate)

    End Function
    Public Shadows Function CheckIfExistsOnTrxnLines2(ByVal EmpCode As String, ByVal Mydate As Date) As Boolean
        Return MyBase.CheckIfExistsOnTrxnLines2(EmpCode, Mydate)

    End Function
    Public Shadows Function GetTAReportForTotalTimePerWorkPerEmployeeForDates(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal ForActual As Boolean) As DataSet
        Return MyBase.GetTAReportForTotalTimePerWorkPerEmployeeForDates(EmpCode, FromDate, ToDate, ForActual)
    End Function
    Public Shadows Function GetEmployeeTotalPerDayPerWorkCode(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal FromWorkCode As String, ByVal ToWorkCode As String, ByVal Status As Boolean, ByVal Analysis2Code As String) As Double
        Return MyBase.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, FromWorkCode, ToWorkCode, Status, Analysis2Code)
    End Function
    Public Shadows Function GetEmployeeTotalPerDayPerWorkCodeTime(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal FromWorkCode As String, ByVal ToWorkCode As String, ByVal Status As Boolean, ByVal Analysis2Code As String) As String()
        Return MyBase.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, FromDate, ToDate, FromWorkCode, ToWorkCode, Status, Analysis2Code)
    End Function
    Public Shadows Function FindEmployeeInterfaceStatusForTA(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
        Return MyBase.FindEmployeeInterfaceStatusForTA(EmpCode, FromDate, ToDate)
    End Function
    Public Shadows Function SetTAStatusToInterfaceForEmployee(ByVal EmpCode As String, ByVal D As Date, ByVal D2 As Date) As Boolean
        Return MyBase.SetTAStatusToInterfaceForEmployee(EmpCode, D, D2)
    End Function
    Public Shadows Function GetEmployeeTotalPerTypePerAction(ByVal EmpCode As String, ByVal LeaveType As String, ByVal Action As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal Status As String, Optional ByVal ToDateLess As Boolean = False) As Double
        Return MyBase.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveType, Action, FromDate, ToDate, Status, ToDateLess)
    End Function
    Public Shadows Function GetParameter(ByVal Section As String, ByVal Item As String) As DataSet
        Return MyBase.GetParameter(Section, Item)
    End Function

    Public Shadows Function GetFTPParameters(ByVal Type As String, ByVal SubType As String, ByVal TemGrpCode As String) As DataSet
        Return MyBase.GetFTPParameters(Type, SubType, TemGrpCode)
    End Function
    Public Shadows Function GetMinAndMaxIDOfUnsendTrxns(ByVal TempGrp As cPrMsTemplateGroup) As DataSet
        Return MyBase.GetMinAndMaxIDOfUnsendTrxns(TempGrp) ', PeriodCode)
    End Function
    Public Shadows Function GetPrTxTrxnHeader(ByVal MinId As Integer, ByVal MaxId As Integer, ByVal Tempgroup As cPrMsTemplateGroup) As DataSet
        Return MyBase.GetPrTxTrxnHeader(MinId, MaxId, Tempgroup) ', PeriodCode)
    End Function
    Public Shadows Function GetPrTxTrxnLinesOfHeaderID(ByVal HeaderId) As DataSet
        Return MyBase.GetPrTxTrxnLinesOfHeaderID(HeaderId)
    End Function
    Public Shadows Function GetPrTrxnLinesOfHeaderIdOfAdvances(ByVal HeaderID As Integer) As DataSet
        Return MyBase.GetPrTrxnLinesOfHeaderIdOfAdvances(HeaderID)
    End Function
    Public Shadows Function GetDetailsForNavInterface(ByVal Hdr As cPrTxTrxnHeader) As DataSet
        Return MyBase.GetDetailsForNavInterface(Hdr)
    End Function
    Public Shadows Function UpdateTrxnHeaderAsPosted(ByVal MinId As Integer, ByVal MaxId As Integer, ByVal TempGroup As cPrMsTemplateGroup, ByVal status As String) As Boolean
        Return MyBase.UpdateTrxnHeaderAsPosted(MinId, MaxId, TempGroup, status)
    End Function
    Public Shadows Function GetAllPrSsNavBatch(ByVal TemGrp As cPrMsTemplateGroup) As DataSet
        Return MyBase.GetAllPrSsNavBatch(TemGrp)
    End Function
    Public Shadows Function GetAllPrSsNavBatch2(ByVal TemGrp As cPrMsTemplateGroup) As DataSet
        Return MyBase.GetAllPrSsNavBatch2(TemGrp)
    End Function
    Public Shadows Function GetAllPrTxHeader_InterfacedBankPayed(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBankCode As String) As DataSet
        Return MyBase.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Analysis, AnalysisCode, EmployeeBankCode)
    End Function
    Public Shadows Function GetAllPrTxHeader_InterfacedBankPayedCONSOL(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBank As String) As DataSet
        Return MyBase.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Create2Files, ThisIsCompanyBankFile, Analysis, AnalysisCode, EmployeeBank)
    End Function
    Public Shadows Function GetAllPrTxHeader_EWALLET(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBank As String) As DataSet
        Return MyBase.GetAllPrTxHeader_EWALLETFile(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Create2Files, ThisIsCompanyBankFile, Analysis, AnalysisCode, EmployeeBank)
    End Function
    Public Shadows Function GetAllIBANSReport(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal IncludeInactive As Boolean) As DataSet
        Return MyBase.GetAllIBANS_Report(TemGrp, Period, IncludeInactive)
    End Function
    Public Shadows Function GetAllPrTxHeader_InterfacedBankPayed_Alpha(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBankCode As String, ByVal OnlyAlpha As String) As DataSet
        Return MyBase.GetAllPrTxHeader_InterfacedBankPayed_Alpha(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Analysis, AnalysisCode, EmployeeBankCode, Onlyalpha)
    End Function
    Public Shadows Function GetAllPrTxHeader_InterfacedBankPayedCONSOL_Alpha(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBank As String, ByVal OnlyAlpha As String) As DataSet
        Return MyBase.GetAllPrTxHeader_InterfacedBankPayedCONSOL_Alpha(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Create2Files, ThisIsCompanyBankFile, Analysis, AnalysisCode, EmployeeBank, OnlyAlpha)
    End Function
    Public Shadows Function GetAllPrTxHeader_InterfacedBankPayedCONSOL_SEPAGA(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Bank As cPrAnBanks, ByVal CompanyBankAcc As String, ByVal ForReport As Boolean, ByVal IncludeInactive As Boolean, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal Analysis As String, ByVal AnalysisCode As String, ByVal EmployeeBank As String) As DataSet
        Return MyBase.GetAllPrTxHeader_InterfacedBankPayedCONSOL_SEPAGA(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, Create2Files, ThisIsCompanyBankFile, Analysis, AnalysisCode, EmployeeBank)
    End Function

    Public Shadows Function GetAllAdMsCompany() As DataSet
        Return MyBase.GetallAdMsCompany
    End Function
    Public Shadows Function GetAllAdMsCompanyOfUser(ByVal UserCode As String) As DataSet
        Return MyBase.GetAllAdMsCompanyOfUser(UserCode)
    End Function
    Public Shadows Function GetAllPrMsInterfaceTemplate() As DataSet
        Return MyBase.GetAllPrMsinterfaceTemplate
    End Function
    Public Shadows Function GetAllPrMsInterfaceTemplateforUser(ByVal UserName As String) As DataSet
        Return MyBase.GetAllPrMsinterfaceTemplateForUser(UserName)
    End Function
    Public Shadows Function GetAllPrMsInterfaceCodes(ByVal TmpGrpCode As String) As DataSet
        Return MyBase.GetAllPrMsinterfaceCodes(TmpGrpCode)
    End Function
    Public Shadows Function GetAllPrMsInterfaceCodesByTemplateGroup(ByVal TempGrpCode As String) As DataSet
        Return MyBase.GetAllPrMsInterfaceCodesByTemplateGroup(TempGrpCode)
    End Function
    Public Shadows Function GetAllPrMsInterfaceTemplateByTemplateGroup(ByVal TemGrpCode As String) As DataSet
        Return MyBase.GetAllPrMsInterfaceTemplateByTemplateGroup(TemGrpCode)
    End Function
    Public Shadows Function GetAllPrmsEarningsInterface(ByVal IntTemCode As String) As DataSet
        Return MyBase.GetAllPrmsEarningsInterface(IntTemCode)
    End Function
    Public Shadows Function GetAllPrmsDeductionsInterface(ByVal IntTemCode As String) As DataSet
        Return MyBase.GetAllPrmsDeductionsInterface(IntTemCode)
    End Function

    Public Shadows Function GetAllPrmsContributionsInterface(ByVal IntTemCode As String) As DataSet
        Return MyBase.GetAllPrmsContributionsInterface(IntTemCode)
    End Function
    Public Shadows Function FindTempInterfaceLevel1(ByVal AccCode As String, ByVal EDCCode As String, ByVal EmpCode As String, ByVal TemGrpCode As String, ByVal ConsolLevel As String, ByVal A0 As String, ByVal A1 As String, ByVal A2 As String, ByVal A3 As String, ByVal A4 As String, ByVal A5 As String, ByVal AU As String, ByVal BalCode As String, ByVal ThisIsCheque As Integer) As DataSet
        Return MyBase.FindTempInterfaceLevel1(AccCode, EDCCode, EmpCode, TemGrpCode, ConsolLevel, A0, A1, A2, A3, A4, A5, AU, BalCode, ThisIsCheque)
    End Function
    Public Shadows Function FindTempInterfaceLevel2(ByVal AccCode As String, ByVal EmpCode As String, ByVal TemGrpCode As String, ByVal ConsolLevel As String, ByVal A0 As String, ByVal A1 As String, ByVal A2 As String, ByVal A3 As String, ByVal A4 As String, ByVal A5 As String, ByVal AU As String, ByVal BalCode As String, ByVal ThisIsCheque As Integer) As DataSet
        Return MyBase.FindTempInterfaceLevel2(AccCode, EmpCode, TemGrpCode, ConsolLevel, A0, A1, A2, A3, A4, A5, AU, BalCode, ThisIsCheque)
    End Function
    Public Shadows Function FindTempInterfaceLevel3(ByVal AccCode As String, ByVal TemGrpCode As String, ByVal ConsolLevel As String, ByVal A0 As String, ByVal A1 As String, ByVal A2 As String, ByVal A3 As String, ByVal A4 As String, ByVal A5 As String, ByVal AU As String, ByVal BalCode As String, ByVal ThisIsCheque As Integer) As DataSet
        Return MyBase.FindTempInterfaceLevel3(AccCode, TemGrpCode, ConsolLevel, A0, A1, A2, A3, A4, A5, AU, BalCode, ThisIsCheque)
    End Function
    Public Shadows Function DeleteAllFromTempInterface(ByVal TemGrpCode) As Boolean
        Return MyBase.DeleteAllFromTempInterface(TemGrpCode)
    End Function
    Public Shadows Function FindEmployee(ByVal Code As String, ByVal NextEmp As Boolean) As DataSet
        Return MyBase.FindEmployee(Code, NextEmp)
    End Function
    Public Shadows Function FindEmployeeOfUser(ByVal Code As String, ByVal NextEmp As Boolean, ByVal UserName As String, ByVal SameCode As Boolean, OnlyActive As Boolean, OnlyThisTemplateGroup As String) As DataSet
        Return MyBase.FindEmployeeOfUser(Code, NextEmp, UserName, SameCode, OnlyActive,OnlyThisTemplateGroup )
    End Function
    Public Shadows Function GetAllEmployeesOfUser(ByVal UserName As String) As DataSet
        Return MyBase.GetAllEmployeesOfUser(UserName)
    End Function
    Public Shadows Function GetAllEmployeesOfUserByDepartmentWithSalary_1(ByVal UserName As String) As DataSet
        Return MyBase.GetAllEmployeesOfUserByDepartmentWithSalary_1(UserName)
    End Function

    Public Shadows Function GetAllPrTmInterface(ByVal TmpGrpCode As String) As DataSet
        Return MyBase.GetAllPrTmInterface(TmpGrpCode)
    End Function
    Public Shadows Function GetAllPrTmInterfaceAmountSumPerAccount(ByVal TmpGrpCode As String) As DataSet
        Return MyBase.GetAllPrTmInterfaceAmountSumPerAccount(TmpGrpCode)
    End Function
    Public Shadows Function GetAllPrTmInterface_TA(ByVal TmpGrpCode As String) As DataSet
        Return MyBase.GetAllPrTmInterface_TA(TmpGrpCode)
    End Function
    Public Shadows Function GetPrTmInterfacePerAccount(ByVal TmpGrpCode As String, ByVal accountCode As String) As DataSet
        Return MyBase.GetAllPrTmInterfacePerAccount(TmpGrpCode, accountCode)
    End Function
    Public Shadows Function GetPrTmInterfaceSumPerAccount(ByVal TmpGrpCode As String, ByVal accountCode As String) As Double
        Return MyBase.GetAllPrTmInterfaceSumPerAccount(TmpGrpCode, accountCode)
    End Function

    Public Shadows Function GetAllPrMsCodeMasking(ByVal InterfaceCode As String) As DataSet
        Return MyBase.GetAllPrMsCodeMasking(InterfaceCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriod(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal OnlyActiveEmployees As Boolean, ByVal GenAnal1 As String, ByVal orderbyanal As Integer, ByVal BankCode As String, ByVal EmpBankCode As String, ByVal OnlyEmpWithTermDate As Boolean, ByVal SICategory As String, ByVal AgeFilter As String, ByVal OnlyLeavers As Boolean, ByVal OnlyHiredThisYear As Boolean, ByVal EWallet As Boolean) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriod(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, OnlyActiveEmployees, GenAnal1, orderbyanal, BankCode, EmpBankCode, OnlyEmpWithTermDate, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, EWallet)
    End Function
    Public Shadows Function GetAllTrxnHeaderForTemplateGroupForPeriodGroup(ByVal TempGroup As String, ByVal PerGroup As String, ByVal PeriodGroupCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForTemplateGroupForPeriodGroup(TempGroup, PerGroup, PeriodGroupCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForTemplateGroupForPeriodGroupForPeriod(ByVal TempGroup As String, ByVal PerGroup As String, ByVal PeriodGroupCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForTemplateGroupForPeriodGroupForPeriod(TempGroup, PerGroup, PeriodGroupCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriodForUnitsReport(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal OnlyActiveEmployees As Boolean, ByVal GenAnal1 As String, ByVal orderbyanal As Integer, ByVal BankCode As String, ByVal EmpBankCode As String, ByVal OnlyEmpWithTermDate As Boolean, ByVal SICategory As String, ByVal AgeFilter As String, ByVal OnlyLeavers As Boolean, ByVal OnlyHiredThisYear As Boolean, ByVal PerTo As cPrMsPeriodCodes, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForUnitsReport(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, OnlyActiveEmployees, GenAnal1, orderbyanal, BankCode, EmpBankCode, OnlyEmpWithTermDate, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, PerTo, Ewallet)
    End Function

    
    Public Shadows Function GetAllTrxnHeaderForPeriodEDCTotals1(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal GenAnal1 As String, ByVal orderbyanal As Integer, ByVal Ern1 As String, ByVal Ern2 As String, ByVal BankCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodEDCTotals1(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, GenAnal1, orderbyanal, Ern1, Ern2, BankCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriod_GroupByAnalysis(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal OnlyActiveEmployees As Boolean, ByVal GenAnal1 As String, ByVal orderbyanal As Integer, ByVal SICategory As String, ByVal AgeFilter As String, ByVal OnlyLeavers As Boolean, ByVal OnlyHiredThisYear As Boolean, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriod_GroupByAnalysis(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, OnlyActiveEmployees, GenAnal1, orderbyanal, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)
    End Function


    Public Shadows Function GetUnitsReportForPeriod(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetUnitsReportForPeriod(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, Ewallet)
    End Function

    Public Shadows Function GetAllEmployeesForAL(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal IsSplitemployee As Boolean, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetAllEmployeesForAL(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, IsSplitemployee, Ewallet)
    End Function
    Public Shadows Function GetAllRmployessWithSplit(ByVal TempGroup As String) As DataSet
        Return MyBase.GetAllRmployessWithSplit(TempGroup)
    End Function
    Public Shadows Function GetAllEmployeesWithPayrollForPeriods(ByVal PerFrom As cPrMsPeriodCodes, ByVal PerTo As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String, ByVal Cash As Boolean, ByVal Cheque As Boolean, ByVal Bank As Boolean, ByVal Ewallet As Boolean) As DataSet
        Return MyBase.GetAllEmployeesWithPayrollForPeriods(PerFrom, PerTo, EmpFromcode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, Ewallet)
    End Function
    Public Shadows Function GetAllEDCLinesForPeriodsForEmployee(ByVal Per As cPrMsPeriodCodes, ByVal Empcode As String)
        Return MyBase.GetAllEDCLinesForPeriodsForEmployee(Per, Empcode)
    End Function

    Public Shadows Function GetAllLoansReport(ByVal TempGrpCode As String, ByVal EmpFromCode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalCode As String, ByVal LoanStatus As String) As DataSet
        Return MyBase.GetAllLoansReport(TempGrpCode, EmpFromCode, EmpToCode, Analysis, AnalCode, LoanStatus)
    End Function
    Public Shadows Function GetAllLoansReport2(ByVal TempGrpCode As String, ByVal EmpFromCode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalCode As String, ByVal LoanStatus As String, ByVal PeriodFrom As String, ByVal PeriodTo As String) As DataSet
        Return MyBase.GetAllLoansReport2(TempGrpCode, EmpFromCode, EmpToCode, Analysis, AnalCode, LoanStatus, PeriodFrom, PeriodTo)
    End Function

    Public Shadows Function GetAllTrxnHeaderForPeriodForPFReport(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForPFReport(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriodForPFReport_C12(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForPFReport_C12(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriodForPFReport_Loan(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForPFReport_Loan(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriodForPensionFundReport(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForPensionFundReport(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode)
    End Function
    Public Shadows Function GetAllTrxnHeaderForPeriodForPensionFundReport4(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal Analysis As Integer, ByVal AnalysisCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForPensionFundReport4(Per, EmpFromcode, EmpToCode, Analysis, AnalysisCode)
    End Function
  
    Public Shadows Function GetAllTrxnHeaderForPeriodForUNIONReport(ByVal Per As cPrMsPeriodCodes, ByVal EmpFromcode As String, ByVal EmpToCode As String, ByVal UnionCode As String) As DataSet
        Return MyBase.GetAllTrxnHeaderForPeriodForUNIONReport(Per, EmpFromcode, EmpToCode, UnionCode)
    End Function
    Public Shadows Function GetDeductionForHeader(ByVal HeaderID As Integer, ByVal DeductionType As String) As Double
        Return MyBase.GetDeductionForHeader(HeaderID, DeductionType)
    End Function
    Public Shadows Function GetDeductionCodeForHeader(ByVal HeaderID As Integer, ByVal DeductionCode As String) As Double
        Return MyBase.GetDeductionCodeForHeader(HeaderID, DeductionCode)
    End Function

    Public Shadows Function GetDeductionCodeForHeaderForPeriod(ByVal HeaderID As Integer, ByVal DeductionCode As String, ByVal PerGroup As String, ByVal PerCode As String) As Double
        Return MyBase.GetDeductionCodeForHeaderForPeriod(HeaderID, DeductionCode, PerGroup, PerCode)
    End Function
    Public Shadows Function GetEarningCodeForHeaderForPeriod(ByVal HeaderID As Integer, ByVal EarningCode As String, ByVal PerGroup As String, ByVal PerCode As String) As Double
        Return MyBase.GetEarningCodeForHeaderForPeriod(HeaderID, EarningCode, PerGroup, PerCode)
    End Function



    Public Shadows Function GetContributionForHeader(ByVal HeaderID As Integer, ByVal ContributionType As String) As Double
        Return MyBase.GetContributionForHeader(HeaderID, ContributionType)
    End Function
    Public Shadows Function GetEarningCodeForHeader(ByVal HeaderID As Integer, ByVal EarningCode As String) As Double
        Return MyBase.GetEarningCodeForHeader(HeaderID, EarningCode)
    End Function
    Public Shadows Function GetContributionCodeForHeader(ByVal HeaderID As Integer, ByVal ContributionCode As String) As Double
        Return MyBase.GetContributionCodeForHeader(HeaderID, ContributionCode)
    End Function


    Public Shadows Function GetContributionCodeForHeaderForPeriod(ByVal HeaderID As Integer, ByVal ContributionCode As String, ByVal PerGroup As String, ByVal PerCode As String) As Double
        Return MyBase.GetContributionCodeForHeaderForPeriod(HeaderID, ContributionCode, PerGroup, PerCode)
    End Function


    Public Shadows Function GetTrxnLinesEarningsForHeaderForPeriod(ByVal HeaderId As Integer, ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetTrxnLinesEarningsForHeaderForPeriod(HeaderId, Period)
    End Function
    Public Shadows Function GetTrxnLinesDeductionsForHeaderForPeriod(ByVal HeaderId As Integer, ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetTrxnLinesDeductionsForHeaderForPeriod(HeaderId, Period)
    End Function
    Public Shadows Function GetTrxnLinesContributionsForHeaderForPeriod(ByVal HeaderId As Integer, ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetTrxnLinesContributionsForHeaderForPeriod(HeaderId, Period)
    End Function
    Public Shadows Function GetDeductionofType_PF_PerPeriodGroupANDTemplate(ByVal GLBTempGroupCode As String, ByVal CurrentPeriod As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetDeductionofType_PF_PerPeriodGroupANDTemplate(GLBTempGroupCode, CurrentPeriod)
    End Function
    Public Shadows Function GetPeriodsRemainingForThisDeductionCode(ByVal DedCode As String, ByVal PeriodSequence As String, ByVal PeriodGroup As String) As Integer
        Return MyBase.GetPeriodsRemainingForThisDeductionCode(DedCode, PeriodSequence, PeriodGroup)
    End Function
    Public Shadows Function GetPeriodsRemainingForThisEarningCode(ByVal ErnCode As String, ByVal PeriodSequence As String, ByVal PeriodGroup As String) As Integer
        Return MyBase.GetPeriodsRemainingForThisEarningCode(ErnCode, PeriodSequence, PeriodGroup)
    End Function
    Public Shadows Function GetAllEmployeesOfCodeOfTemplateGroupForYear(ByVal FromEmpCode As String, ByVal ToEmpCode As String, ByVal TempGrpCode As String, ByVal YearPeriod As Date, ByVal OrderByanalysis2 As Boolean) As DataSet
        Return MyBase.GetAllEmployeesOfCodeOfTemplateGroupForYear(FromEmpCode, ToEmpCode, TempGrpCode, YearPeriod, OrderByAnalysis2)
    End Function
    Public Shadows Function GetAllEmployeesOfCompany(ByVal CompanyCode As String) As DataSet
        Return MyBase.GetAllEmployeesOfCompany(CompanyCode)
    End Function
    Public Shadows Function GetAllCompaniesDetails(ByVal FromCompany As String, ByVal ToCompany As String) As DataSet
        Return MyBase.GetAllCompanyDetails(FromCompany, ToCompany)
    End Function
    Public Shadows Function GetAllEmployeesOfCodeOfTemplateGroup(ByVal FromEmpCode As String, ByVal ToEmpCode As String, ByVal TempGrpCode As String) As DataSet
        Return MyBase.GetAllEmployeesOfCodeOfTemplateGroup(FromEmpCode, ToEmpCode, TempGrpCode)
    End Function
    Public Shadows Function GetAllEmployeesOfTemplateGroup(ByVal TempGrpCode As String) As DataSet
        Return MyBase.GetAllEmployeesOfTemplateGroup(TempGrpCode)
    End Function
    Public Shadows Function GetAllEmployees() As DataSet
        Return MyBase.GetAllEmployees()
    End Function
    Public Shadows Function GetAllEmployeesOfCodeOfTemplateGroup(ByVal TempGrpCode As String) As DataSet
        Return MyBase.GetAllEmployeesOfTemplateGroup(TempGrpCode)
    End Function
    Public Shadows Function DeleteMaskingCodesOfCode(ByVal InterfaceCode As String) As Boolean
        Return MyBase.DeleteMaskingCodesOfCode(InterfaceCode)
    End Function
    Public Shadows Function SI_File_GetEmployees(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal SicCode As String, ByRef StatusPrep As Boolean) As DataSet
        Return MyBase.SI_File_GetEmployees(TemGrp, Period, SicCode, StatusPrep)
    End Function
    Public Shadows Function SI_File_GetEmployees_New14(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal SicCode As String, ByRef StatusPrep As Boolean, ByVal SinPeriodCode As String) As DataSet
        Return MyBase.SI_File_GetEmployees_New14(TemGrp, Period, SicCode, StatusPrep, SinPeriodCode)
    End Function
    Public Shadows Function SI_File_GetEmployees_MultibleTemplates(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal SicCode As String, ByRef StatusPrep As Boolean) As DataSet
        Return MyBase.SI_File_GetEmployees_MultipleTemplates(TemGrp, Period, SicCode, StatusPrep)
    End Function
    Public Shadows Function SI_File_GetEmployees_2(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal SicCode As String, ByRef StatusPrep As Boolean, ByVal SI_RegNo As String) As DataSet
        Return MyBase.SI_File_GetEmployees_2(TemGrp, Period, SicCode, StatusPrep, SI_RegNo)
    End Function
    Public Shadows Function SI_File_GetEmployees_Company(ByVal dsPeriods As DataSet, ByVal SicCode As String, ByRef StatusPrep As Boolean) As DataSet
        Return MyBase.SI_File_GetEmployees_Company(dsPeriods, SicCode, StatusPrep)
    End Function
    Public Shadows Function SI_File_GetEmployees_Gross_Insurable(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String) As DataSet
        Return MyBase.SI_File_GetEmployees_Gross_Insurable(TemGrp, Period, EmpCode)
    End Function
    Public Shadows Function GetAnnualLeaveValueFromLineFor(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String) As Double
        Return MyBase.GetAnnualLeaveValueFromLineFor(TemGrp, Period, EmpCode)
    End Function
    Public Shadows Function GetBIKWithSCValueFromLineFor(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String) As Double
        Return MyBase.GetBIKWithSCValueFromLineFor(TemGrp, Period, EmpCode)
    End Function

    Public Shadows Function SI_File_GetEmployees_Gross_Insurable_New14(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal EmpCode As String, ByVal SIPeriodCode As String) As DataSet
        Return MyBase.SI_File_GetEmployees_Gross_Insurable_New14(TemGrp, Period, EmpCode, SIPeriodCode)
    End Function
    Public Shadows Function SI_File_GetEmployees_Gross_Insurable_Company1(ByVal DsPeriods As DataSet, ByVal EmpCode As String) As DataSet
        Return MyBase.SI_File_GetEmployees_Gross_Insurable_Company1(DsPeriods, EmpCode)
    End Function
    Public Shadows Function GetAllPeriodsOF_SIPeriod(ByVal SIPerCode As String, ByVal TemGrpCode As String, ByVal PeriodgroupCode As String) As DataSet
        Return MyBase.GetAllPeriodsOF_SIPeriod(SIPerCode, TemGrpCode, PeriodgroupCode)

    End Function
    Public Shadows Function GetAllPeriodsOF_SIPeriod_Company(ByVal SIPerCode As String, ByVal TemGrpCode As String, ByVal Periodgroup As cPrMsPeriodGroups) As DataSet
        Return MyBase.GetAllPeriodsOF_SIPeriod_Company(SIPerCode, TemGrpCode, Periodgroup)

    End Function
    Public Shadows Function Build_Template_STR_Company(ByVal SIPerCode As String, ByVal TemGrpCodeCOMCode As String, ByVal PeriodgroupCode As String) As String
        Return MyBase.Build_Template_STR_Company(SIPerCode, TemGrpCodeCOMCode, PeriodgroupCode)
    End Function
    Public Shadows Function Build_PeriodGroup_STR_Company(ByVal SIPerCode As String, ByVal TemGrpCodeCOMCode As String, ByVal PeriodgroupCode As String) As String
        Return MyBase.Build_PeriodGroup_STR_Company(SIPerCode, TemGrpCodeCOMCode, PeriodgroupCode)
    End Function
    Public Shadows Function GetPFAmount_A_And_B(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal IncludeInactive As Boolean) As Double()
        Return MyBase.GetPFAmount_A_And_B(TemGrp, Period, IncludeInactive)
    End Function
    Public Shadows Function GetPeriodRange(ByVal PerFrom As cPrMsPeriodCodes, ByVal PerTo As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetPeriodRange(PerFrom, PerTo)
    End Function
    Public Shadows Function GetNumberOfEmployeesMonthlyHourlyPeriod(ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal Type As String) As Integer
        Return MyBase.GetNumberOfEmployeesMonthlyHourlyPeriod(PeriodGroup, PeriodCode, Type)
    End Function
    Public Shadows Function GetDSOfEmployeesMonthlyHourlyPeriod(ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal Type As String) As DataSet
        Return MyBase.GetDSOfEmployeesMonthlyHourlyPeriod(PeriodGroup, PeriodCode, Type)
    End Function
    Public Shadows Function GetDecuctionCodeForSI() As String
        Return MyBase.GetDecuctionCodeForSI
    End Function
    Public Shadows Function GetContributionCodeForSI() As String
        Return MyBase.GetContributionCodeForSI
    End Function
    Public Shadows Function GetDecuctionCodeForIT() As String
        Return MyBase.GetDecuctionCodeForIT
    End Function
    Public Shadows Function GetEarningCodeFor13Estimate() As String
        Return MyBase.GetEarningCodeFor13Estimate
    End Function
    Public Shadows Function GetAllemployeesWithTerminationDate(ByVal TemGrp As String) As DataSet
        Return MyBase.GetAllEmployeesWithTerminationdate(TemGrp)
    End Function
    Public Shadows Function GetAllPrTxdiscountsForPeriodGroup(ByVal PeriodGroupCode As String) As DataSet
        Return MyBase.GetAllPrTxdiscountsForPeriodGroup(PeriodGroupCode)
    End Function
    Public Shadows Function GetAllPrSSAnnualLeaveTypes() As DataSet
        Return MyBase.GetAllPrSsAnnualLeaveTypes
    End Function
    Public Shadows Function GetERNFromTrxnLinesFor(ByVal Per As cPrMsPeriodCodes, ByVal EarningType As String) As DataSet
        Return MyBase.GetERNFromTrxnLinesFor(Per, EarningType)
    End Function
    Public Function GetSUM_Of_ERN_FromTrxnLinesFor(ByVal Per As cPrMsPeriodCodes, ByVal EarningType As String, ByVal EmpCode As String) As Double
        Return MyBase.GetSUM_Of_ERN_FromTrxnLinesFor(Per, EarningType, EmpCode)
    End Function
    Public Function GetSUM_Of_GESIABLE_FromTrxnHeaderFor(ByVal Per As cPrMsPeriodCodes, ByVal EmpCode As String) As Double
        Return MyBase.GetSUM_Of_GESIABLE_FromTrxnHeaderFor(Per, EmpCode)
    End Function
    Public Shadows Function GetERNFromTrxnLinesFor_New14(ByVal Per As cPrMsPeriodCodes, ByVal EarningType As String, ByVal SIPeriodCode As String) As DataSet
        Return MyBase.GetERNFromTrxnLinesFor_New14(Per, EarningType, SIPeriodCode)
    End Function
    Public Shadows Function GetDEDFromTrxnLinesFor(ByVal Per As cPrMsPeriodCodes, ByVal DeductionType As String) As DataSet
        Return MyBase.GetDEDFromTrxnLinesFor(Per, DeductionType)
    End Function
    Public Shadows Function GetCONFromTrxnLinesFor(ByVal Per As cPrMsPeriodCodes, ByVal ContributionType As String) As DataSet
        Return MyBase.GetCONFromTrxnLinesFor(Per, ContributionType)

    End Function
    Public Shadows Function FindBankAccounts(ByVal Company As cAdMsCompany, ByVal Bank As cPrAnBanks) As DataSet
        Return MyBase.FindBankAccounts(Company, Bank)
    End Function
    Public Shadows Function NumToWords(ByVal N As Integer) As String
        Return MyBase.NumToWords(N)
    End Function
    Public Shadows Function GetDalaryDiference(ByVal EmpCode As String, ByVal DatePay As Date) As DataSet
        Return MyBase.GetDalaryDiference(EmpCode, DatePay)

    End Function
    Public Shadows Function GetCompanyDetailsForPFReport(ByVal companyCode As String) As DataSet
        Return MyBase.GetCompanydetailsForPFreport(companyCode)

    End Function
    Public Shadows Function GetPeriodDetailsForPFreport(ByVal Period As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetPeriodDetailsForPFreport(Period)
    End Function
    Public Shadows Function GetAllActivePrAnTaxCardType() As DataSet
        Return MyBase.GetAllActivePrAnTaxCardType()
    End Function
    Public Shadows Function GetAllPrTxHeader_PFReportByanalysis(ByVal TemGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Analysis As Integer, ByVal AnalysisValue As String, ByVal PeriodDescription As String) As DataSet
        Return MyBase.GetAllPrTxHeader_PFReportByanalysis(TemGrp, Period, Analysis, AnalysisValue, PeriodDescription)
    End Function
    Public Shadows Function GetDeductionCodesForLoans() As DataSet
        Return MyBase.GetDeductionCodesForLoans
    End Function
    Public Shadows Function GetAllPrTxEmployeeLoansByEmpCode(ByVal EmpCode As String, ByVal EmpLoanCode As String) As DataSet
        Return MyBase.GetAllPrTxEmployeeLoansByEmpCode(EmpCode, EmpLoanCode)
    End Function
    Public Shadows Function GetEmployeeLoans(ByVal EmpCode As String) As DataSet
        Return MyBase.GetEmployeeLoans(EmpCode)
    End Function
    Public Shadows Function GetEmployeeLoans1(ByVal EmpCode As String, ByVal Status As String) As DataSet
        Return MyBase.GetEmployeeLoans1(EmpCode, Status)
    End Function
    Public Shadows Function CheckLoanValue(ByVal EmpCode As String, ByVal DeductionCode As String) As DataSet
        Return MyBase.CheckLoanValue(EmpCode, DeductionCode)
    End Function
    Public Shadows Function GetEmployeeLoans2(ByVal EmpCode As String, ByVal Status As String, ByVal LoanCode As String) As DataSet
        Return MyBase.GetEmployeeLoans2(EmpCode, Status, LoanCode)
    End Function
    Public Shadows Function GetEmployeeLoans3(ByVal EmpCode As String, ByVal Status As String, ByVal LoanCode As String) As Integer
        Return MyBase.GetEmployeeLoans3(EmpCode, Status, LoanCode)
    End Function
    Public Shadows Function GetEmployeeLoanTotal(ByVal EmpCode As String, ByVal LoanCode As String) As Double
        Return MyBase.GetEmployeeLoanTotal(EmpCode, LoanCode)
    End Function
    Public Shadows Function ChangeStatusofLoan(ByVal EmpCode As String, ByVal LoanCode As String) As Boolean
        Return MyBase.ChangeStatusOfLoan(EmpCode, LoanCode)

    End Function
    Public Shadows Function IsThereAnActiveLoanForThisDeductionCode(ByVal EmpCode As String, ByVal LoanCode As String, ByVal DedCode As String) As Boolean
        Return MyBase.IsThereAnActiveLoanForThisDeductionCode(EmpCode, LoanCode, DedCode)
    End Function
    Public Shadows Function IsThisTheFirstRecordOfLoan(ByVal EmpCode As String, ByVal LoanCode As String) As Boolean
        Return MyBase.IsThisTheFirstRecordOfLoan(EmpCode, LoanCode)
    End Function
    Public Shadows Function IsThereALoanWithTheSameCode(ByVal EmpCode As String, ByVal LoanCode As String) As Boolean
        Return MyBase.IsThereALoanWithTheSameCode(EmpCode, LoanCode)

    End Function
    Public Shadows Function Is13nthcalculated(ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal EmpCode As String) As Boolean
        Return MyBase.Is13nthcalculated(CurrentPeriod, EmpCode)
    End Function

    Public Shadows Function GetNumberOfTotalPeriodsFOREmployee(ByVal EmpCode As String, ByVal Year As String) As Integer
        Return MyBase.GetNumberOfTotalPeriodsFOREmployee(EmpCode, Year)
    End Function

    Public Shadows Function GetEmployeesForTAforAnalysis(ByVal analysiscode As String, ByVal MyStatus As String) As DataSet
        Return MyBase.GetEmployeesForTAforAnalysis(analysiscode, MyStatus)

    End Function
    Public Shadows Function createparameterAverage13()
        Return MyBase.createparameterAverage13()
    End Function
    Public Shadows Function GetCompanyNextId()
        Return MyBase.GetCompanyNextId()
    End Function
    Public Shadows Function GetcompanyTemplateGroup(ByVal CompanyCode As String) As DataSet
        Return MyBase.GetcompanyTemplateGroup(CompanyCode)
    End Function
    Public Shadows Function GetPeriodGroupOfTemplateGroup(ByVal TemplateGroupCode As String) As DataSet
        Return MyBase.GetPeriodGroupOfTemplateGroup(TemplateGroupCode)
    End Function
    Public Shadows Function GetAllPeriodGroupsOfTemplateGroupCompany(ByVal ComCode As String, ByVal Year As String) As DataSet
        Return MyBase.GetAllPeriodGroupsOfTemplateGroupCompany(ComCode, Year)
    End Function
    Public Shadows Function CreateNewPeriod(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewPeriod(OldCode, NewCode)
    End Function
    Public Shadows Function CreateNewPeriodEarnings(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewPeriodEarnings(OldCode, NewCode)
    End Function
    Public Shadows Function CreateNewPeriodDeductions(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewPeriodDeductions(OldCode, NewCode)
    End Function
    Public Shadows Function CreateNewPeriodContributions(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewPeriodContributions(OldCode, NewCode)
    End Function

    Public Shadows Function CreateNewTemplateEarnings(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewTemplateEarnings(OldCode, NewCode)
    End Function
    Public Shadows Function CreateNewTemplateDeductions(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewTemplateDeductions(OldCode, NewCode)
    End Function
    Public Shadows Function CreateNewTemplateContributions(ByVal OldCode As String, ByVal NewCode As String)
        Return MyBase.CreateNewTemplateContributions(OldCode, NewCode)
    End Function

    Public Shadows Function CreateNewInterfaceTemplateEarnings(ByVal OldCode As String, ByVal NewCode As String, ByVal NewTempGrpCode As String, ByVal OldComp As String, ByVal NewComp As String) As Boolean
        Return MyBase.CreateNewInterfaceTemplateEarnings(OldCode, NewCode, NewTempGrpCode, OldComp, NewComp)
    End Function
    Public Shadows Function CreateNewInterfaceTemplateDeductions(ByVal OldCode As String, ByVal NewCode As String, ByVal NewTempGrpCode As String, ByVal OldComp As String, ByVal NewComp As String) As Boolean
        Return MyBase.CreateNewInterfaceTemplateDeductions(OldCode, NewCode, NewTempGrpCode, OldComp, NewComp)
    End Function
    Public Shadows Function CreateNewInterfaceTemplateContributions(ByVal OldCode As String, ByVal NewCode As String, ByVal NewTempGrpCode As String, ByVal OldComp As String, ByVal NewComp As String) As Boolean
        Return MyBase.CreateNewInterfaceTemplateContributions(OldCode, NewCode, NewTempGrpCode, OldComp, NewComp)
    End Function

    Public Shadows Function CreateNewInterfaceCodes(ByVal NewTempGrpCode As String, ByVal OldTempGrpCode As String, ByVal OldComp As String, ByVal NewComp As String)
        Return MyBase.CreateNewInterfaceCodes(NewTempGrpCode, OldTempGrpCode, OldComp, NewComp)
    End Function
    Public Shadows Function AddUserOnCompany(ByVal UserName As String, ByVal Comp As cAdMsCompany) As Boolean
        Return MyBase.AddUserOnCompany(UserName, Comp)
    End Function
    Public Shadows Function UserExistInCompany(ByVal UserName As String, ByVal Comp As cAdMsCompany) As Boolean
        Return MyBase.UserExistInCompany(UserName, Comp)
    End Function
    Public Shadows Function DeleteUserFromCompany(ByVal UserName As String, ByVal Comp As cAdMsCompany) As Boolean
        Return MyBase.DeleteUserFromCompany(UserName, Comp)
    End Function
    Public Shadows Function GetUserCompanies(ByVal UserName As String) As DataSet
        Return MyBase.GetUserCompanies(UserName)
    End Function
    Public Shadows Function GetAllUserforAllCompanies(ByVal Year As String) As DataSet
        Return MyBase.GetAllUserForAllCompanies(Year)
    End Function
    Public Shadows Function GetAllPrSsEmployeeSplitByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrSsEmployeeSplitByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetSplitByEmpCodeForTAX_TimesPeriods(ByVal EmpCode As String, ByVal PeriodType As String) As Double
        Return MyBase.GetSplitByEmpCodeForTAX_TimesPeriods(EmpCode, PeriodType)
    End Function
    Public Shadows Function GetSplitByEmpCodeForTAX(ByVal EmpCode As String, ByVal PeriodType As String) As Double
        Return MyBase.GetSplitByEmpCodeForTAX(EmpCode, PeriodType)
    End Function
    Public Shadows Function GetSplitByEmpCodeForSpecialTax(ByVal EmpCode As String, ByVal PeriodType As String) As Double
        Return MyBase.GetSplitByEmpCodeForSpecialTAX(EmpCode, PeriodType)
    End Function
    Public Shadows Function GetSplitByEmpCodeForProvidentFund(ByVal EmpCode As String, ByVal PeriodType As String) As Double
        Return MyBase.GetSplitByEmpCodeForProvidentFund(EmpCode, PeriodType)
    End Function
    Public Shadows Function ChangePassword(ByVal User As String, ByVal OldPwd As String, ByVal NewPwd As String) As Boolean
        Dim status As Boolean = False
        Try
            status = MyBase.ChangePassword(User, OldPwd, NewPwd)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
        Return status
    End Function
    Public Shadows Function BackupDatabase(ByVal dbName As String, ByVal bDestination As String) As Boolean
        Return MyBase.BackupDatabase(dbName, bDestination)
    End Function
#End Region

#Region "Interface Timesheets"
    Public Shadows Function GetCompanyCostPerEmployee(ByVal PeriodGroup As String, ByVal PeriodCode As String) As DataSet

        Return MyBase.GetCompanyCostPerEmployee(PeriodGroup, PeriodCode)

    End Function
    Public Shadows Function NAV_FindIfItWasInterfacedAgain(ByVal Company As String, ByVal Year As String, ByVal PeriodCode As String) As DataSet

        Return MyBase.NAV_FindIfItWasInterfacedAgain(Company, Year, PeriodCode)

    End Function
    Public Shadows Function NAV_InsertValuesInNavisionTimesheets(ByVal CompanyCode As String, ByVal EmployeeCode As String, ByVal ResourceCode As String, ByVal Year As String, ByVal Period As String, ByVal CompanyCost As Double, ByVal WorkHours As Double, ByVal HourlyCostRate As Double) As Boolean
        Return MyBase.NAV_InsertValuesInNavisionTimesheets(CompanyCode, EmployeeCode, ResourceCode, Year, Period, CompanyCost, WorkHours, HourlyCostRate)
    End Function
    Public Shadows Function NAV_DeleteInterfacedTimesheetTransactions(ByVal Company As String, ByVal Year As String, ByVal PeriodCode As String)
        Return MyBase.NAV_DeleteInterfacedTimesheetTransactions(Company, Year, PeriodCode)
    End Function

    Public Shadows Function NAV_DeleteInterfacedTimesheetTransactionsFromPerJob(ByVal Company As String, ByVal Year As String, ByVal PeriodCode As String)
        Return MyBase.NAV_DeleteInterfacedTimesheetTransactionsFromPerJob(Company, Year, PeriodCode)
    End Function
    Public Shadows Function NAV_GetTotalHoursPerMonthPerResourse(ByVal DateFrom As String, ByVal DateTo As String, ByVal ResourceCode As String) As Double
        Return MyBase.NAV_GetTotalHoursPerMonthPerResourse(DateFrom, DateTo, ResourceCode)
    End Function
    Public Shadows Function NAV_GetPayrollCostForcompanyYearPeriod(ByVal Company As String, ByVal Year As String, ByVal Period As String) As DataSet
        Return MyBase.NAV_GetPayrollCostForcompanyYearPeriod(Company, Year, Period)
    End Function
    Public Shadows Function NAV_GetTotalHoursPerMonthPerResoursePerJob(ByVal DateFrom As String, ByVal DateTo As String, ByVal ResourceCode As String) As DataSet
        Return MyBase.NAV_GetTotalHoursPerMonthPerResoursePerJob(DateFrom, DateTo, ResourceCode)
    End Function
    Public Shadows Function NAV_InsertValuesInNavisionPerJob(ByVal CompanyCode As String, ByVal Empcode As String, ByVal ResourceCode As String, ByVal Year As String, ByVal Period As String, ByVal JobNo As String, ByVal JobQty As Double, ByVal HourlyRate As Double, ByVal PerJobCost As Double) As Boolean
        Return MyBase.NAV_InsertValuesInNavisionPerJob(CompanyCode, Empcode, ResourceCode, Year, Period, JobNo, JobQty, HourlyRate, PerJobCost)
    End Function
    Public Shadows Function NAV_InsertInto_GenJournalLines(ByVal JournalTemplateName As String, ByVal JournalBachName As String, ByVal LineNo As Integer, ByVal AccountNo As String, ByVal AccDescription As String, ByVal DocumentNo As String, ByVal BalancingAcc As String, ByVal ShortCutDimension2 As String, ByVal SourceCode As String, ByVal Amount As Double, ByVal DocDate As String, ByVal ExternalDocument As String, ByVal PostingNoSeries As String, ByVal ShortcutDimension1 As String) As Boolean
        Return MyBase.NAV_InsertInto_GenJournalLines(JournalTemplateName, JournalBachName, LineNo, AccountNo, AccDescription, DocumentNo, BalancingAcc, ShortCutDimension2, SourceCode, Amount, DocDate, ExternalDocument, PostingNoSeries, ShortcutDimension1)
    End Function
    Public Shadows Function NAV_SelectFromPayrollCostPerJob(ByVal Company As String, ByVal Year As String, ByVal Period As String) As DataSet
        Return MyBase.NAV_SelectFromPayrollCostPerJob(Company, Year, Period)
    End Function
    Public Shadows Function fixTotalContributiononHeader(ByVal Group As String, ByVal Code As String)
        Return MyBase.fixTotalContributiononHeader(Group, Code)
    End Function
    Public Shadows Function temp_Gencat(ByVal itemcode As String, ByVal cat9 As String, ByVal cat10 As String)
        Return MyBase.Temp_GenCat(itemcode, cat9, cat10)
    End Function
    Public Shadows Function GetWorkedPeriodsUntilNow(ByVal EmpCode As String, ByVal PeriodGroup As String) As Integer
        Return MyBase.GetWorkedPeriodsUntilNow(EmpCode, PeriodGroup)
    End Function
    Public Shadows Function GetWorkedTaxablePeriodsUntilNow(ByVal EmpCode As String, ByVal PeriodGroup As String) As Integer
        Return MyBase.GetWorkedTaxablePeriodsUntilNow(EmpCode, PeriodGroup)
    End Function
    Public Shadows Function GetWorkedPeriodsUntilNowTaxOrNoTax(ByVal EmpCode As String, ByVal PeriodGroup As String) As Integer
        Return MyBase.GetWorkedPeriodsUntilNowTaxOrNoTax(EmpCode, PeriodGroup)
    End Function
    Public Shadows Function FindYTD(ByVal Type As String, ByVal E_Code As String, ByVal D_Code As String, ByVal C_Code As String, ByVal Employee_Code As String, ByVal Period_Code As String, ByVal HdrId As Integer) As DataSet
        Return MyBase.FindYTD(Type, E_Code, D_Code, C_Code, Employee_Code, Period_Code, HdrId)
    End Function
    Public Shadows Function FindHeaderYTD(ByVal EmpCode As String, ByVal PerGrp As String, ByVal TempGrp As String, ByVal Per As String) As DataSet
        Return MyBase.FindHeaderYTD(EmpCode, PerGrp, TempGrp, Per)
    End Function
    Public Shadows Function Get14nthPeriodSequence(ByVal Period As cPrMsPeriodCodes) As Integer
        Return MyBase.Get14nthPeriodSequence(Period)

    End Function
    Public Shadows Function Get14nthTotalAnnualUnits(ByVal Period As cPrMsPeriodCodes) As Double
        Return MyBase.Get14nthTotalAnnualUnits(Period)
    End Function
    Public Shadows Function FindEmployeeCode(ByVal EmployeeMappCode As String, ByVal GLnumber As Integer) As String
        Return MyBase.FindEmployeeCode(EmployeeMappCode, GLnumber)
    End Function
    Public Shadows Function FindEmployeeCodeFromTACode(ByVal EmployeeMappCode As String) As String
        Return MyBase.FindEmployeeCodeFromTACode(EmployeeMappCode)
    End Function
    Public Shadows Function CalculateEmployeeAdvancesFromTable(ByVal EmpCode As String) As Double
        Return MyBase.CalculateEmployeeAdvancesFromTable(EmpCode)
    End Function
    Public Shadows Function FindAllEmployeesForPension(ByVal PensionAge As Integer, ByVal TempCode As String) As DataSet
        Return MyBase.FindAllEmployeesForPension(PensionAge, TempCode)
    End Function
    Public Shadows Function FindAllEmployeesForPF(ByVal PFReminder As Integer, ByVal TempCode As String) As DataSet
        Return MyBase.FindAllEmployeesForPF(PFReminder, TempCode)
    End Function
    Public Shadows Function UpdateAnnualLeaveHeaderId(ByVal EmpCode As String, ByVal HdrId As Integer)
        Return MyBase.UpdateAnnualLeaveHeaderId(EmpCode, HdrId)
    End Function
    Public Shadows Function GetUserPermitions(ByVal CompanyCode As String, ByVal User As String, ByVal GetDefaults As Boolean) As DataSet
        Return MyBase.GetUserPermitions(CompanyCode, User, GetDefaults)

    End Function
    Public Shadows Function GetTerminatedEmployeeswithStatusActive(ByVal CurrentPeriod As cPrMsPeriodCodes, ByVal TemplateGroupCode As String) As DataSet
        Return MyBase.GetTerminatedEmployeeswithStatusActive(CurrentPeriod, TemplateGroupCode)

    End Function
    Public Shadows Function SetEmpStatusToInactive(ByVal EmpCode As String)
        MyBase.SetEmpStatusToInactive(EmpCode)
    End Function
#End Region

#Region "Dashboard Employee Cost"
    Public Shadows Function GetALReportForAllemployees(ByVal PerGroup As cPrMsPeriodGroups, ByVal Per As cPrMsPeriodCodes) As DataSet
        Return MyBase.GetALReportForAllemployees(PerGroup, Per)
    End Function
    Public Shadows Function NAV_FindIfCOSTItWasInterfacedAgain(ByVal PeriodGroup As String, ByVal PeriodCode As String) As DataSet
        Return MyBase.NAV_FindIfCOSTItWasInterfacedAgain(PeriodGroup, PeriodCode)

    End Function
    Public Shadows Function NAV_InsertValuesInDashboardCost(ByVal EmpCode As String, ByVal EmpName As String, ByVal PostDate As Date, ByVal Cost As Double, ByVal Normal As Double, ByVal SILeave As Double, ByVal Sick As Double, ByVal Army As Double, ByVal Maternity As Double, ByVal Unexcused As Double, ByVal Other As Double, ByVal BALNormal As Double, ByVal BALSILeave As Double, ByVal BALSick As Double, ByVal BALArmy As Double, ByVal BALMaternity As Double, ByVal BALUnexcused As Double, ByVal BALOther As Double, ByVal PeriodCode As String, ByVal PeriodGroup As String) As Boolean
        Return MyBase.NAV_InsertValuesInDashboardCost(EmpCode, EmpName, PostDate, Cost, Normal, SILeave, Sick, Army, Maternity, Unexcused, Other, BALNormal, BALSILeave, BALSick, BALArmy, BALMaternity, BALUnexcused, BALOther, PeriodCode, PeriodGroup)
    End Function
    Public Shadows Function NAV_DeleteInterfacedDashboardValues(ByVal PeriodGroup As String, ByVal PeriodCode As String)
        Return MyBase.NAV_DeleteInterfacedDashboardValues(PeriodGroup, PeriodCode)
    End Function
    Public Shadows Function FixCarob()
        Return MyBase.FixCarob
    End Function
    Public Shadows Function FixFoodPoint()
        Return MyBase.FixFoodPoint
    End Function
    Public Shadows Function FixFoodExpress()
        Return MyBase.FixFoodExpress
    End Function
    Public Shadows Function IsThisLastPeriod(ByVal Period As cPrMsPeriodCodes) As Boolean
        Return MyBase.IsThisLastPeriod(Period)
    End Function
    Public Shadows Function GetAnnualInsurableToDateForEmployee(ByVal EmpCode As String, ByVal PeriodGroup As String) As Double
        Return MyBase.GetAnnualInsurableToDateForEmployee(EmpCode, PeriodGroup)
    End Function
    Public Shadows Function GetAllUsersOfCompany(ByVal ComCode As String) As DataSet
        Return MyBase.GetAllUsersOfCompany(ComCode)
    End Function
    Public Shadows Function DeleteAllAIMS() As Boolean
        Return MyBase.DeleteAllAIMS
    End Function
    Public Shadows Function GetDataFromAIMS() As DataSet
        Return MyBase.GetDataFromAIMS
    End Function
    Public Shadows Function GetEmployeeFromAIMSCode(ByVal No As String) As String
        Return MyBase.GetEmployeeFromAIMSCode(No)
    End Function
    Public Shadows Function Upgrade2016() As Boolean
        Return MyBase.Upgrade2016

    End Function
    Public Shadows Function Upgrade2016_B() As Boolean
        Return MyBase.Upgrade2016_B

    End Function
    Public Shadows Function Upgrade2017() As Boolean
        Return MyBase.Upgrade2017_A

    End Function
    Public Shadows Function Upgrade2017_B() As Boolean
        Return MyBase.Upgrade2017_B

    End Function
    Public Shadows Function Upgrade2017_C() As Boolean
        Return MyBase.Upgrade2017_C

    End Function
    Public Shadows Function Upgrade2017_D() As Boolean
        Return MyBase.Upgrade2017_D

    End Function
    Public Shadows Function Upgrade2017_E() As Boolean
        Return MyBase.Upgrade2017_E

    End Function
    Public Shadows Function Upgrade2017_F() As Boolean
        Return MyBase.Upgrade2017_F
    End Function
    Public Shadows Function Upgrade2017_F_2() As Boolean
        Return MyBase.Upgrade2017_F_2
    End Function
    Public Shadows Function Upgrade2017_F_3() As Boolean
        Return MyBase.Upgrade2017_F_3
    End Function
    Public Shadows Function Upgrade2018_1() As Boolean
        Return MyBase.Upgrade2018_1
    End Function
    Public Shadows Function Upgrade2018_2() As Boolean
        Return MyBase.Upgrade_2018_2
    End Function
    Public Shadows Function Upgrade2018_3() As Boolean
        Return MyBase.Upgrade_2018_3
    End Function
    Public Shadows Function Upgrade2018_4() As Boolean
        Return MyBase.Upgrade_2018_4
    End Function
    Public Shadows Function Upgrade2018_5() As Boolean
        Return MyBase.Upgrade_2018_5
    End Function
    Public Shadows Function Upgrade2018_6() As Boolean
        Return MyBase.Upgrade_2018_6
    End Function
    Public Shadows Function Upgrade2018_7() As Boolean
        Return MyBase.Upgrade_2018_7
    End Function
    Public Shadows Function Upgrade2018_8() As Boolean
        Return MyBase.Upgrade_2018_8
    End Function
    Public Shadows Function Upgrade2018_9() As Boolean
        Return MyBase.Upgrade_2018_9
    End Function

    Public Shadows Function Upgrade2018_10() As Boolean
        Return MyBase.Upgrade_2018_10
    End Function
    Public Shadows Function Upgrade2018_11() As Boolean
        Return MyBase.Upgrade_2018_11
    End Function
    Public Shadows Function Upgrade2018_12() As Boolean
        Return MyBase.Upgrade_2018_12
    End Function
    Public Shadows Function Upgrade2018_13() As Boolean
        Return MyBase.Upgrade_2018_13
    End Function
    Public Shadows Function Upgrade2018_14() As Boolean
        Return MyBase.Upgrade_2018_14
    End Function
    Public Shadows Function Upgrade2018_15() As Boolean
        Return MyBase.Upgrade_2018_15
    End Function
    Public Shadows Function Upgrade2019_1() As Boolean
        Return MyBase.Upgrade_2019_1
    End Function
    Public Shadows Function Upgrade2019_8() As Boolean
        Return MyBase.Upgrade_2019_8
    End Function
    Public Shadows Function Upgrade2019_9() As Boolean
        Return MyBase.Upgrade_2019_9
    End Function
    Public Shadows Function Upgrade2019_10() As Boolean
        Return MyBase.Upgrade_2019_10
    End Function
    Public Shadows Function Upgrade2019_2() As Boolean
        Return MyBase.Upgrade_2019_2
    End Function
    Public Shadows Function Upgrade2019_3() As Boolean
        Return MyBase.Upgrade_2019_3
    End Function
    Public Shadows Function Upgrade2019_4() As Boolean
        Return MyBase.Upgrade_2019_4
    End Function
    Public Shadows Function Upgrade2019_11() As Boolean
        Return MyBase.Upgrade_2019_11
    End Function
    Public Shadows Function Upgrade2019_12() As Boolean
        Return MyBase.Upgrade_2019_12
    End Function
    Public Shadows Function Upgrade2019_13() As Boolean
        Return MyBase.Upgrade_2019_13
    End Function
    Public Shadows Function Upgrade2019_14() As Boolean
        Return MyBase.Upgrade_2019_14
    End Function
    Public Shadows Function Upgrade2019_15() As Boolean
        Return MyBase.Upgrade_2019_15
    End Function
    Public Shadows Function Upgrade2019_16() As Boolean
        Return MyBase.Upgrade_2019_16
    End Function
    Public Shadows Function Upgrade2019_17() As Boolean
        Return MyBase.Upgrade_2019_17
    End Function
    Public Shadows Function Upgrade2019_5() As Boolean
        Return MyBase.Upgrade_2019_5
    End Function
    Public Shadows Function Upgrade2019_6() As Boolean
        Return MyBase.Upgrade_2019_6
    End Function
    Public Shadows Function Upgrade2019_7() As Boolean
        Return MyBase.Upgrade_2019_7
    End Function
    Public Shadows Function Upgrade2019_18() As Boolean
        Return MyBase.Upgrade_2019_18
    End Function
    Public Shadows Function Upgrade2019_19() As Boolean
        Return MyBase.Upgrade_2019_19
    End Function
    Public Shadows Function Upgrade2019_20() As Boolean
        Return MyBase.Upgrade_2019_20
    End Function
    Public Shadows Function Upgrade2020_01() As Boolean
        Return MyBase.Upgrade_2020_01
    End Function

    Public Shadows Function Upgrade2020_02() As Boolean
        Return MyBase.Upgrade_2020_02
    End Function
    Public Shadows Function Upgrade2020_03() As Boolean
        Return MyBase.Upgrade_2020_03
    End Function
    Public Shadows Function Upgrade2020_04() As Boolean
        Return MyBase.Upgrade_2020_04
    End Function
    Public Shadows Function Upgrade2020_05() As Boolean
        Return MyBase.Upgrade_2020_05
    End Function
    Public Shadows Function Upgrade2020_06() As Boolean
        Return MyBase.Upgrade_2020_06
    End Function
    Public Shadows Function Upgrade2020_07() As Boolean
        Return MyBase.Upgrade_2020_07
    End Function
    Public Shadows Function Upgrade2020_08() As Boolean
        Return MyBase.Upgrade_2020_08
    End Function
    Public Shadows Function Upgrade2020_09() As Boolean
        Return MyBase.Upgrade_2020_09
    End Function
    Public Shadows Function Upgrade2021_10() As Boolean
        Return MyBase.Upgrade_2021_10
    End Function

    Public Shadows Function Upgrade2021_11() As Boolean
        Return MyBase.Upgrade2021_11
    End Function
    Public Shadows Function Upgrade_2022_01() As Boolean
        Return MyBase.Upgrade_2022_01
    End Function
    Public Shadows Function Upgrade2022_02() As Boolean
        Return MyBase.Upgrade2022_02
    End Function

    Public Shadows Function Upgrade_2022_03() As Boolean
        Return MyBase.Upgrade_2022_03
    End Function
    Public Shadows Function Upgrade_2022_04() As Boolean
        Return MyBase.Upgrade_2022_04
    End Function
    Public Shadows Function Upgrade_2022_05() As Boolean
        Return MyBase.Upgrade_2022_05
    End Function
    Public Shadows Function Upgrade_2022_06() As Boolean
        Return MyBase.Upgrade_2022_06
    End Function
    Public Shadows Function Upgrade_2023_07() As Boolean
        Return MyBase.Upgrade_2023_07
    End Function
    Public Shadows Function Upgrade2017_G() As Boolean
        Return MyBase.Upgrade2017_G
    End Function
    Public Shadows Function Upgrade2017_H() As Boolean
        Return MyBase.Upgrade2017_H
    End Function
    Public Shadows Function Upgrade2017_I() As Boolean
        Return MyBase.Upgrade2017_I
    End Function
    Public Shadows Function Upgrade2017_K() As Boolean
        Return MyBase.Upgrade2017_K
    End Function
    Public Shadows Function Temp()
        Return MyBase.Temp

    End Function
    Public Shadows Function CreateValuesOnAirlinesTables() As Boolean
        Return MyBase.CreateValuesOnAirlinesTables

    End Function
    Public Shadows Function GetAllPrSsGesi() As DataSet
        Return MyBase.GetAllPrSsGESI
    End Function
    Public Shadows Function SetAirlinesDefault() As Boolean
        Return MyBase.SetAirlinesDefault

    End Function
    Public Shadows Function Upgrade2016_C() As Boolean
        Return MyBase.Upgrade2016_C

    End Function
    Public Shadows Function CreateValuesOnAirlinesTables2() As Boolean
        Return MyBase.CreateValuesOnAirlinesTables2

    End Function
    Public Shadows Function GetFirstTransactionPeriod(ByVal EmpCode As String, ByVal PrdGrpCode As String) As DataSet
        Return MyBase.GetFirstTransactionPeriod(EmpCode, PrdGrpCode)
    End Function
    Public Shadows Function SetTrxnLinesValuestoZero(ByVal HEaderId As Integer) As Boolean
        Return MyBase.SetTrxnLinesValuestoZero(HEaderId)
    End Function

#End Region
    Public Shadows Function GetTrxLineEarningOfTYPE(ByVal ErnType As String, ByVal HDRIdFrom As Integer) As Double
        Return MyBase.GetTrxLineEarningOfTYPE(ErnType, HDRIdFrom)

    End Function
    Public Shadows Function GetTrxLineEarningOfCODE(ByVal ErnCODE As String, ByVal HDRIdFrom As Integer) As Double
        Return MyBase.GetTrxLineEarningOfCODE(ErnCODE, HDRIdFrom)

    End Function
    Public Shadows Function GetTrxLineDeductionOfCODE(ByVal DedCODE As String, ByVal HDRIdFrom As Integer) As Double
        Return MyBase.GetTrxLineDeductionOfCODE(DedCODE, HDRIdFrom)

    End Function
    Public Shadows Function GetDiscountLifeInsuranceFirstEmployeemnt(ByVal EmpCode As String, ByVal PeriodGroup As String) As DataSet
        Return MyBase.GetDiscountLifeInsuranceFirstEmployeemnt(EmpCode, PeriodGroup)
    End Function

    Public Shadows Function UpdateDiscountLifeInsuranceFirstEmployement(ByVal EmpCode As String, ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal D As Double, ByVal LI As Double, ByVal FE As Double) As Boolean
        Return MyBase.UpdateDiscountLifeInsuranceFirstEmployement(EmpCode, PeriodGroup, PeriodCode, D, LI, FE)
    End Function
    Public Shadows Function UpdateDiscountLifeInsuranceFirstEmployementTaxableIncome(ByVal EmpCode As String, ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal D As Double, ByVal LI As Double, ByVal FE As Double, ByVal TI As Double) As Boolean
        Return MyBase.UpdateDiscountLifeInsuranceFirstEmployementTaxableIncome(EmpCode, PeriodGroup, PeriodCode, D, LI, FE, TI)
    End Function
    Public Shadows Function UpdateAnnualUnits(ByVal EmpCode As String, ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal AnnualUnits As Double) As Boolean
        Return MyBase.UpdateAnnualUnits(EmpCode, PeriodGroup, PeriodCode, AnnualUnits)
    End Function
    Public Shadows Function UpdatePeriodsplit_SIonPeriodSplit_TaxableFromOther(ByVal EmpCode As String, ByVal PeriodGroup As String, ByVal PeriodCode As String, ByVal PeriodSplit As Double, ByVal SIonPeriodSplit As Double, ByVal TaxableFromOther As Double) As Boolean
        Return MyBase.UpdatePeriodsplit_SIonPeriodSplit_TaxableFromOther(EmpCode, PeriodGroup, PeriodCode, PeriodSplit, SIonPeriodSplit, TaxableFromOther)
    End Function
    Public Shadows Function GetEmployeeEmploymentHistory(ByVal EmpCode As String) As DataSet
        Return MyBase.GetEmployeeEmploymentHistory(EmpCode)
    End Function
    Public Shadows Function GetEmployeePositionHistory(ByVal EmpCode As String) As DataSet
        Return MyBase.GetEmployeePositionHistory(EmpCode)
    End Function
    Public Shadows Function GetIr59ForPrinting(ByVal HeaderId As Integer)
        Return MyBase.GetIr59ForPrinting(HeaderId)
    End Function
    Public Shadows Function UpdateTrxnHeaderAnalysis(ByVal Analysis As String, ByVal HeaderID As Integer, ByVal Index As Integer)
        Return MyBase.UpdateTrxnHeaderAnalysis(Analysis, HeaderID, Index)
    End Function
    Public Shadows Function FindLastPayslipOfEmployee(EmpCode As String) As Integer
        Return MyBase.FindLastPayslipOfEmployee(EmpCode)
    End Function
    Public Shadows Function UpdateTrxnHeaderYTDNet(ByVal HeaderID As Integer)
        Return MyBase.UpdateTrxnHeaderYTDNet(HeaderID)
    End Function
    Public Shadows Function ChangeEmployeeCode(ByVal OldCode As String, ByVal NewCode As String) As Boolean
        Return MyBase.ChangeEmployeeCode(OldCode, NewCode)
    End Function
    Public Shadows Function UpdateEmployeeBonusOnSalary(ByVal EmpCode As String, ByVal BonusOnSalary As Double) As Boolean
        Return MyBase.UpdateEmployeeBonusOnSalary(EmpCode, BonusOnSalary)
    End Function
    Public Shadows Function TrytoCreateDataBaseUser(ByVal DBUser As String, ByVal DBPass As String) As Boolean
        Return MyBase.TrytoCreateDataBaseUser(DBUser, DBPass)
    End Function
    Public Shadows Function TrytoAddDataBaseUser(ByVal DBUser As String) As Boolean
        Return MyBase.TrytoAddDataBaseUser(DBUser)
    End Function
    Public Shadows Function GetEarningsForExcelTemplate(ByVal TemGrp_Code As String) As DataSet
        Return MyBase.GetEarningsForExcelTemplate(TemGrp_Code)
    End Function
    Public Shadows Function GetDeductionsForExcelTemplate(ByVal TemGrp_Code As String) As DataSet
        Return MyBase.GetDeductionsForExcelTemplate(TemGrp_Code)
    End Function
    Public Shadows Function GetContributionsForExcelTemplate(ByVal TemGrp_Code As String) As DataSet
        Return MyBase.GetContributionsForExcelTemplate(TemGrp_Code)
    End Function
    Public Shadows Function ReplaceEarningsFromLines(ByVal EDCFrom As cPrMsEarningCodes, ByVal EDCTo As cPrMsEarningCodes, ByVal PerGrp As cPrMsPeriodGroups, ByVal TemGroup As cPrMsTemplateGroup) As Boolean
        Return MyBase.ReplaceEarningsFromLines(EDCFrom, EDCTo, PerGrp, TemGroup)
    End Function
    Public Shadows Function ReplaceDeductionsFromLines(ByVal EDCFrom As cPrMsDeductionCodes, ByVal EDCTo As cPrMsDeductionCodes, ByVal PerGrp As cPrMsPeriodGroups, ByVal TemGroup As cPrMsTemplateGroup) As Boolean
        Return MyBase.ReplaceDeductionsFromLines(EDCFrom, EDCTo, PerGrp, TemGroup)
    End Function
    Public Shadows Function ReplaceContributionsFromLines(ByVal EDCFrom As cPrMsContributionCodes, ByVal EDCTo As cPrMsContributionCodes, ByVal PerGrp As cPrMsPeriodGroups, ByVal TemGroup As cPrMsTemplateGroup) As Boolean
        Return MyBase.ReplaceContributionsFromLines(EDCFrom, EDCTo, PerGrp, TemGroup)
    End Function
   
    Public Shadows Function ReplaceIBANno(ByVal oldiban As String, ByVal newiban As String) As Boolean
        Return MyBase.ReplaceIBANno(oldiban, newiban)
    End Function
    Public Shadows Function ReplaceCompanyBankCode(ByVal OldBank As String, ByVal NewBank As String, ByVal TemGrpCode As String) As Boolean
        Return MyBase.ReplaceCompanyBankCode(OldBank, NewBank, TemGrpCode)
    End Function
    Public Shadows Function ChangeCompanyBankCodeAndIBAN(ByVal EmpBank As String, ByVal ComBank As String, ByVal IBAN As String, ByVal TemGrpCode As String) As Boolean
        Return MyBase.ChangeCompanyBankCodeAndIBAN(EmpBank, ComBank, IBAN, TemGrpCode)
    End Function
    Public Shadows Function ReplacePayslipReport(ByVal oldPayslip As String, ByVal newPayslip As String) As Boolean
        Return MyBase.ReplacePayslipReport(oldPayslip, newPayslip)
    End Function
    Public Shadows Function CreateNodalInterfaceParameters()
        Return MyBase.CreateNodalInterfaceParameters()
    End Function
    Public Shadows Function ReplaceEmployeeEDCValue(ByVal TemGroupCode, ByVal EDCType, ByVal EDCCode, ByVal OldValue, ByVal NewValue) As Integer
        Return MyBase.ReplaceEmployeeEDCValue(TemGroupCode, EDCType, EDCCode, OldValue, NewValue)
    End Function
    Public Shadows Function ExecuteWithResults(ByVal Str As String) As DataSet
        Return MyBase.ExecuteWithResults(Str)
    End Function
    Public Shadows Function ExecuteWithOUTResults(ByVal Str As String) As Integer
        Return MyBase.ExecuteWithOUTResults(Str)
    End Function
    Public Shadows Function GetDepartment1CodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetDepartment1CodeFromDesc(Desc)
    End Function
    Public Shadows Function GetDepartment2CodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetDepartment2CodeFromDesc(Desc)
    End Function
    Public Shadows Function GetDepartment3CodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetDepartment3CodeFromDesc(Desc)
    End Function
    Public Shadows Function GetDepartment4CodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetDepartment4CodeFromDesc(Desc)
    End Function
    Public Shadows Function GetDepartment5CodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetDepartment5CodeFromDesc(Desc)
    End Function
    Public Shadows Function GetPositionCodeFromDesc(ByVal Desc As String) As String
        Return MyBase.GetPositionCodeFromDesc(Desc)
    End Function
    Public Shadows Function GetLastEmployeeCode(ByVal TempGroup As String) As String
        Return MyBase.GetLastEmployeeCode(TempGroup)
    End Function
    Public Shadows Function GetLastEmployeePositionCode() As String
        Return MyBase.GetLastEmployeePositionCode
    End Function
    Public Shadows Function GetAllIBANSOfTemplateGroupCode(ByVal TempGroupCode As String) As DataSet
        Return MyBase.GetAllIBANSOfTemplateGroupCode(TempGroupCode)

    End Function
    Public Shadows Function GetAllPayslipsOfTemplateGroupCode(ByVal TempGroupCode As String) As DataSet
        Return MyBase.GetAllPayslipsOfTemplateGroupCode(TempGroupCode)
    End Function
    Public Shadows Function CreateEmailPayslipWording() As Boolean
        Return MyBase.CreateEmailPayslipWording()
    End Function
    Public Shadows Function FixnVarcharOnAnalysis() As Boolean
        Return MyBase.FixNVARcharOnAnalysis

    End Function
    Public Shadows Function AddTaxRuleAsParameter() As Boolean
        Return MyBase.AddTaxRuleAsParameter
    End Function
    Public Shadows Function AddDefRowCount() As Boolean
        Return MyBase.AddDefRowCount
    End Function
    Public Shadows Function AddIndexes() As Boolean
        Return MyBase.AddIndexes
    End Function
    Public Shadows Function AddOverTimeParameters() As Boolean
        Return MyBase.AddOvertimeParameters
    End Function
    Public Shadows Function AddURLParameters() As Boolean
        Return MyBase.AddURLParameters
    End Function
    Public Shadows Function AddURLParameters2() As Boolean
        Return MyBase.AddURLParameters2
    End Function
    Public Shadows Function AlterCompanyName() As Boolean
        Return MyBase.AlterCompanyName
    End Function
    Public Shadows Function GetEmployeesWithManualTax(ByVal TempGroupCode As String) As DataSet
        Return MyBase.GetEmployeesWithManualTax(TempGroupCode)
    End Function
    Public Shadows Function GetEployeeInfoForLabels(ByVal EmpCode As String) As DataSet
        Return MyBase.GetEployeeInfoForLabels(EmpCode)
    End Function
    Public Shadows Function Upgrade_AddMFOnDiscounts_30() As Boolean
        Return MyBase.Upgrade_AddMFOndiscounts_30
    End Function
    Public Shadows Function Upgrade_AddPenFundOnDiscounts() As Boolean
        Return MyBase.Upgrade_AddPenFundOndiscounts
    End Function
    Public Shadows Function GetCompanyPayslipsPerPeriod(ByVal MyYear As String, ByVal CompanyCode As String) As DataSet
        Return MyBase.GetCompanyPayslipsPerPeriod(MyYear, CompanyCode)
    End Function
    Public Shadows Function GetCompanyPayslipsTotalPerCompany(ByVal MyYear As String, ByVal CompanyCode As String) As DataSet
        Return MyBase.GetCompanyPayslipsTotalPerCompany(MyYear, CompanyCode)
    End Function
    Public Function GetAllPrMsRemindersByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrMsRemindersByEmpCode(EmpCode)
    End Function
    Public Function GetRemindersForPeriodForTemGroup(ByVal TempGroup As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetRemindersForPeriodForTemGroup(TempGroup, FromDate, ToDate, OnlyActive)
    End Function
    Public Function CountRemindersForPeriodForTemGroup(ByVal TempGroup As String, ByVal FromDate As Date, ByVal ToDate As Date) As Integer
        Return MyBase.CountRemindersForPeriodForTemGroup(TempGroup, FromDate, ToDate)
    End Function
    Public Function GetTrxnHeaderOfEmployeeGroupByPeriodGroup(ByVal EmpCode As String) As DataSet
        Return MyBase.GetTrxnHeaderOfEmployeeGroupByPeriodGroup(EmpCode)
    End Function
    Public Function ChangeTemplateGroupCodeOfemployee(ByVal EmpCode As String, ByVal FromTemp As String, ByVal toTemp As String) As Boolean
        Return MyBase.ChangeTemplateGroupCodeOfEmployee(EmpCode, FromTemp, toTemp)
    End Function
    Public Function ChangePeriodGroupCodeOfEmployee(ByVal EmpCode As String, ByVal FromPerGroup As String, ByVal ToPerGroup As String) As Boolean
        Return MyBase.ChangePeriodGroupCodeOfEmployee(EmpCode, FromPerGroup, ToPerGroup)
    End Function

    Public Shadows Function REPORT_IR7_Gesy_DEDUCTION(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet

        Return MyBase.REPORT_IR7_Gesy_DEDUCTION(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function REPORT_IR7_Gesy_CONTRIBUTION(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet
        Return MyBase.REPORT_IR7_Gesy_CONTRIBUTION(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function REPORT_IR7_Gesy_CONTRIBUTION_LWBPen(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet
        Return MyBase.REPORT_IR7_Gesy_CONTRIBUTION_LWBPen(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function REPORT_IR7_Gesy_CONTRIBUTION_Directors(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet
        Return MyBase.REPORT_IR7_Gesy_CONTRIBUTION_Directors(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function REPORT_IR7_Gesy_DEDUCTION_Directors(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet
        Return MyBase.REPORT_IR7_Gesy_DEDUCTION_Directors(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function REPORT_IR7_OtherContributions_CONTRIBUTION(ByVal EmpCode As String, ByVal StrPeriodGroupCodes As String) As DataSet
        Return MyBase.REPORT_IR7_OtherContributions_CONTRIBUTION(EmpCode, StrPeriodGroupCodes)

    End Function
    Public Shadows Function GetLoanComments(ByVal LoanCode As String) As DataSet
        Return MyBase.GetLoanComments(LoanCode)
    End Function
    Public Shadows Function SearchForAnnualLeaveOfHeaderId(ByVal HdrId As Integer) As Boolean
        Return MyBase.SearchForAnnualLeaveOfHeaderId(HdrId)
    End Function
    Public Shadows Function GetEmployeeIBANS(ByVal TemplateGroup As String, ByVal OnlyActive As Boolean) As DataSet
        Return MyBase.GetEmployeeIBANS(TemplateGroup, OnlyActive)
    End Function
    Public Shadows Function GetLASTPeriodGroupsOfTemplateGroup(ByVal TempGroupCode As String) As String
        Return MyBase.GetLastPeriodGroupOfTemplateGroup(TempGroupCode)
    End Function
    Public Shadows Function GetNextAnalysisCode(ByVal Analysis As String) As String
        Return MyBase.GetNextAnalysisCode(Analysis)
    End Function
    Public Shadows Function GetNextAvailableCode(ByVal Prefix As String, ByVal TemplateGroup As String) As String
        Return MyBase.GetNextAvailableCode(Prefix, TemplateGroup)
    End Function
    Public Shadows Function CheckForLicence(ByVal EncryptedSerialNo As String) As DataSet
        Return MyBase.CheckForLicence(EncryptedSerialNo)
    End Function
    Public Shadows Function Get_EARNING_VALUE_FromTrxnLines_For_HeaderID(ByVal HdrId As Integer, ByVal ErnCode As String) As Double
        Return MyBase.Get_EARNING_VALUE_FromTrxnLines_For_HeaderID(HdrId, ErnCode)
    End Function
    Public Shadows Function FixGesiable(ByVal GesiableValue As Double, ByVal EmpCode As String, ByVal CurrentPeriod As cPrMsPeriodCodes) As Boolean
        Return MyBase.FixGesiable(GesiableValue, EmpCode, CurrentPeriod)
    End Function
    Public Shadows Function SearchForBanks(ByVal Code As String, ByVal Desc As String, ByVal Swift As String) As DataSet
        Return MyBase.SearchForBanks(Code, Desc, Swift)
    End Function
    Public Shadows Function DeletePeriodCode(ByVal Per As cPrMsPeriodCodes) As Boolean
        Return MyBase.DeletePeriodCode(Per)
    End Function
    Public Shadows Function GetAllPrMsEmployeeCovidTestByEmpCode(ByVal EmpCode As String) As DataSet
        Return MyBase.GetAllPrMsEmployeeCovidTestByEmpCode(EmpCode)
    End Function
    Public Shadows Function GetEmployeeCovidTestResult(ByVal TempGroup As String, ByVal DateFrom As Date, ByVal DateTo As Date, ByVal anlyactive As Boolean) As DataSet
        Return MyBase.GetEmployeeCovidTestResult(TempGroup, DateFrom, DateTo, anlyactive)
    End Function
    Public Shadows Function SetNewEmployeeToFalse() As Boolean
        Return MyBase.SetNewEmployeeToFalse
    End Function
    Public Shadows Function SetGeneralAnalysis1ValueToAnaysis2() As Boolean
        Return MyBase.SetGeneralAnalysis1ValueToAnaysis2
    End Function

    Public Shadows Function ChangeEarningDescriptionOnLines(ByVal ErnCode As String, ByVal TempCode As String, ByVal NewDescription As String) As Boolean
        Return MyBase.ChangeEarningDescriptionOnLines(ErnCode, TempCode, NewDescription)
    End Function
    Public Shadows Function ChangeDeductionsDescriptionOnLines(ByVal DedCode As String, ByVal TempCode As String, ByVal NewDescription As String) As Boolean
        Return MyBase.ChangeDeductionDescriptionOnLines(DedCode, TempCode, NewDescription)
    End Function
    Public Shadows Function ChangeContributionDescriptionOnLines(ByVal ConCode As String, ByVal TempCode As String, ByVal NewDescription As String) As Boolean
        Return MyBase.ChangeContributionDescriptionOnLines(ConCode, TempCode, NewDescription)
    End Function
    Public Shadows Function CheckforCalcPayslipsForEmployee(ByVal EmpCode As String) As Boolean
        Return MyBase.CheckforCalcPayslipsForEmployee(EmpCode)
    End Function
    Public Shadows Function FindnumberofPeriodsOnCompanyLevelForThisPeriodGroup(ByVal PerGroup As cPrMsPeriodGroups, ByVal TempGroup As cPrMsTemplateGroup) As Integer
        Return MyBase.FindnumberofPeriodsOnCompanyLevelForThisPeriodGroup(PerGroup, TempGroup)
    End Function
    Public Shadows Function Set50PercAmountto55000() As Boolean
        Return MyBase.Set50PercAmountto55000()
    End Function
    Public Shadows Function GetemployeeDetailsForPrinting1(ByVal OnlyActive As Boolean, ByVal SelectedEmployeeCode As String) As DataSet
        Return MyBase.GetEmployeeDetailsForPrinting1(OnlyActive, SelectedEmployeeCode)
    End Function
    Public Shadows Function GetMaximumYearOfPeriodGroups() As DataSet
        Return MyBase.getmaximumyearofperiodgroups

    End Function
#Region "Locii"
    Public Shadows Function LociiExport_PrAnBanks() As DataSet
        Return MyBase.LociiExport_PrAnBanks
    End Function
    Public Shadows Function LociiExport_PrAnEmployeeAnalysis1() As DataSet
        Return MyBase.LociiExport_PrAnEmployeeAnalysis1
    End Function
    Public Shadows Function LociiExport_PrAnEmployeeAnalysis2() As DataSet
        Return MyBase.LociiExport_PrAnEmployeeAnalysis2
    End Function
    Public Shadows Function LociiExport_PrAnEmployeeAnalysis3() As DataSet
        Return MyBase.LociiExport_PrAnEmployeeAnalysis3
    End Function
    Public Shadows Function LociiExport_PrAnEmployeeAnalysis4() As DataSet
        Return MyBase.LociiExport_PrAnEmployeeAnalysis4
    End Function
    'Public Shadows Function LociiExport_PrAnEmployeeAnalysis5() As DataSet
    '    Return MyBase.LociiExport_PrAnEmployeeAnalysis5
    'End Function
    Public Shadows Function LociiExport_PrAnEmployeeCommunity() As DataSet
        Return MyBase.LociiExport_PrAnEmployeeCommunity
    End Function
    Public Shadows Function LociiExport_PrAnEmployeePositions() As DataSet
        Return MyBase.LociiExport_PrAnEmployeePositions
    End Function

    Public Shadows Function LociiExport_PrAnMarritalStatus() As DataSet
        Return MyBase.LociiExport_PrAnMarritalStatus
    End Function
    Public Shadows Function LociiExport_PrMsEmployees(ByVal TemGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrMsEmployees(TemGrpCode)
    End Function
    Public Shadows Function LociiExport_PrMsTemplateContributions(ByVal TemGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrMsTemplateContributions(TemGrpCode)
    End Function
    Public Shadows Function LociiExport_PrMsTemplateDeductions(ByVal TemGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrMsTemplateDeductions(TemGrpCode)
    End Function
    Public Shadows Function LociiExport_PrMsTemplateEarnings(ByVal TemGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrMsTemplateEarnings(TemGrpCode)
    End Function
    Public Shadows Function LociiExport_PrTxTrxnHeader(ByVal TemGrpCode As String, ByVal PrdCode As String, ByVal PrdGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrTxTrxnHeader(TemGrpCode, PrdCode, PrdGrpCode)

    End Function
    Public Shadows Function LociiExport_PrTxTrxnLines(ByVal TemGrpCode As String, ByVal PrdCode As String, ByVal PrdGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrTxTrxnLines(TemGrpCode, PrdCode, PrdGrpCode)
    End Function
    Public Shadows Function LociiExport_PrTxEmployeeLeave(ByVal TemGrpCode As String, ByVal PrdCode As cPrMsPeriodCodes, ByVal PrdGrpCode As String) As DataSet
        Return MyBase.LociiExport_PrTxEmployeeLeave(TemGrpCode, PrdCode, PrdGrpCode)
    End Function
    Public Function FindBenefitsInKindTotalFor_Template_PeriodCode_Employee(ByVal TemGrpCode As String, ByVal PeriodCode As String, ByVal EmpCode As String) As DataSet
        Return MyBase.FindBenefitsInKindTotalFor_Template_PeriodCode_Employee(TemGrpCode, PeriodCode, EmpCode)
    End Function
    Public Function FindBenefitsInKindTotalFor_Template_PeriodGroup_Employee(ByVal TemGrpCode As String, ByVal PeriodGroup As String, ByVal EmpCode As String, ByVal PeriodCode As String) As DataSet
        Return MyBase.FindBenefitsInKindTotalFor_Template_PeriodGroup_Employee(TemGrpCode, PeriodGroup, EmpCode, PeriodCode)
    End Function
    Public Function GetSplitAcrossCompaniesForPeriods(ByVal empCode, ByVal PerF, ByVal PerT) As DataSet
        Return MyBase.GetSplitAcrossCompaniesForPeriods(empCode, PerF, PerT)
    End Function
    Public Function GetTaxCalculationReport(ByVal FromEmp As String, ByVal ToEmp As String, ByVal PeriodCode As String, ByVal PeriodGroup As String, ByVal TempGroup As String) As DataSet
        Return MyBase.GetTaxCalculationReport(FromEmp, ToEmp, PeriodCode, PeriodGroup, TempGroup)
    End Function
    Public Function Upgrade_2024_01() As Boolean
        Return MyBase.Upgrade_2024_01
    End Function
    Public Function Upgrade_2024_02() As Boolean
        Return MyBase.Upgrade_2024_02
    End Function
    Public Function Upgrade_2024_03() As Boolean
        Return MyBase.Upgrade_2024_03
    End Function
    Public Function Upgrade_2024_04() As Boolean
        Return MyBase.Upgrade_2024_04
    End Function
    Public Function Upgrade_2024_05() As Boolean
        Return MyBase.Upgrade_2024_05
    End Function
    Public Function Upgrade_2024_06() As Boolean
        Return MyBase.Upgrade_2024_06
    End Function
    Public Function Upgrade_2024_07() As Boolean
        Return MyBase.Upgrade_2024_07
    End Function
    Public Function Upgrade_2024_08() As Boolean
        Return MyBase.Upgrade_2024_08
    End Function
    Public Function Upgrade_2024_09() As Boolean
        Return MyBase.Upgrade_2024_09
    End Function
    Public Function Upgrade_2024_10() As Boolean
        Return MyBase.Upgrade_2024_10
    End Function
    Public Function Upgrade_2024_11() As Boolean
        Return MyBase.Upgrade_2024_11
    End Function
    Public Function Upgrade_2024_12() As Boolean
        Return MyBase.upgrade_2024_12

    End Function
    Public Function Upgrade_2024_13() As Boolean
        Return MyBase.Upgrade_2024_13
    End Function
    Public Function Upgrade_2025_01() As Boolean
        Return MyBase.Upgrade_2025_01
    End Function
    Public Function Upgrade_2025_02() As Boolean
        Return MyBase.Upgrade_2025_02
    End Function
    Public Function Upgrade_2025_03() As Boolean
        Return MyBase.Upgrade_2025_03
    End Function

    Public Function FindNumberOfNormalPeriodsForThisEmployeeForThisPeriodGroup(ByVal glbcurrentperiod As cPrMsPeriodCodes, ByVal EmpCode As String) As Integer
        Return MyBase.FindNumberOfNormalPeriodsForThisEmployeeForThisPeriodGroup(glbcurrentperiod, EmpCode)
    End Function
    Public Function RemoveFirstEmploymentFromActiveEmployees(ByVal TemplateGroup As String) As Boolean
        Return MyBase.RemoveFirstEmploymentFromActiveEmployees(TemplateGroup)
    End Function
    Public Function CheckIfThisAnalysisIsUsed(AnalysisCode As String, Analysis As Integer) As DataSet
        Return MyBase.CheckIfThisAnalysisIsUsed(AnalysisCode, Analysis)

    End Function
    Public Shadows Function GetAllPrAnScales1() As DataSet
        Return MyBase.GetAllPrAnScales1
    End Function
    Public Shadows Function GetAllPrAnScales2() As DataSet
        Return MyBase.GetAllPrAnScales2
    End Function
    Public Shadows Function GetAllPrAnScales3() As DataSet
        Return MyBase.GetAllPrAnScales3
    End Function
    Public Shadows Function GetAllPrMsEmployeeExtraDetails() As DataSet
        Return MyBase.GetAllPrMsEmployeeExtraDetails
    End Function
    Public Shadows Function getexelsysaudit_Employee(Fromdate As Date, ExceptNew As Boolean, OnlyNew As Boolean, ExceptLastUpdate As Boolean) As DataSet
        Return MyBase.GetExelsysAudit_Employee(Fromdate, ExceptNew, OnlyNew, ExceptLastUpdate)
    End Function
    Public Shadows Function getexelsysaudit_Salary(Fromdate As Date, ExceptNew As Boolean, OnlyNew As Boolean, ExceptLastUpdate As Boolean) As DataSet
        Return MyBase.GetExelsysAudit_Salary(Fromdate, ExceptNew, OnlyNew, ExceptLastUpdate)
    End Function
    Public Shadows Function FindProvFundCodeFromDedValueConValue(DedValue As Double, ConValue As Double) As String
        Return MyBase.FindProvFundCodeFromDedValueConValue(DedValue, ConValue)
    End Function
    Public Shadows Function FindSocialInsuranceCodeFromDedValueConValue(DedValue As Double, ConValue As Double) As String
        Return MyBase.FindSocialInsuranceCodeFromDedValueConValue(DedValue, ConValue)
    End Function
    Public Shadows Function DeleteAllEmployeeDiscountsOfPeriodGroup(PrdGrpCode As String) As Boolean
        Return MyBase.DeleteAllEmployeeDiscountsOfPeriodGroup(PrdGrpCode)
    End Function
    Public Shadows Function RemoveFirstEmploymentFromAllActiveEmployees(TempGrpCode As String) As Boolean
        Return MyBase.RemoveFirstEmploymentFromAllActiveEmployees(TempGrpCode)
    End Function

#End Region
End Class

