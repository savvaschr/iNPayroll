Public Class FrmAnnualLeave2
    Public DsEmp As DataSet
    Public DsAL As DataSet
    Public Per As cPrMsPeriodCodes
    Public TempGrp As cPrMsTemplateGroup

    Private Sub FrmAnnualLeave2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadLeaveTypes()
        Getdata()
    End Sub
    Private Sub LoadLeaveTypes()
        Dim dsLeaveTypes
        Dim i As Integer
        dsLeaveTypes = Global1.Business.AG_GetAllPrSsLeaveTypes
        If CheckDataSet(dsLeaveTypes) Then
            Dim LeaveType As New cPrSsLeaveTypes
            With Me.ComboType
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To dsLeaveTypes.Tables(0).Rows.Count - 1
                    LeaveType = New cPrSsLeaveTypes(DbNullToString(dsLeaveTypes.Tables(0).Rows(i).Item(0)))
                    .Items.Add(LeaveType)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GetData()
    End Sub
    Private Sub Getdata()
        Dim i As Integer

        If CheckDataSet(DsEmp) Then
            Dim EmpCode As String
            For i = 0 To DsEmp.Tables(0).Rows.Count - 1

                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(i).Item(0))

                Dim Balance As Double = 0
                Dim DaysBalance As Double = 0
                Dim LeaveTypes As New cPrSsLeaveTypes()
                LeaveTypes = CType(Me.ComboType.SelectedItem, cPrSsLeaveTypes)
                Dim LeaveCode As String

                Dim AL_Entitlement As Double
                Dim AL_Taken As Double
                Dim Month_Taken As Double = 0
                Dim Month_entitled As Double = 0

                Dim R_OpeningBalance As Double
                Dim R_MonthEntitlement As Double
                Dim R_MonthBooked As Double
                Dim R_ClosingBalance As Double


                If CheckDataSet(DsAL) Then
                    Dim TakenBeforePeriod As Double
                    ' Dim Par As New cPrSsParameters(DsAL.Tables(0).Rows(0))
                    ' LeaveCode = Par.Value1
                    ' LeaveTypes = New cPrSsLeaveTypes(LeaveCode)

                    Dim YearStart As Date = CDate(Per.DateFrom.Year & "/" & "01/01")
                    Dim YearEnd As Date = CDate(Per.DateFrom.Year & "/" & "12/31")
                    Dim LastPeriodEnd As Date = DateAdd(DateInterval.Day, -1, Per.DateFrom)

                    Dim EOY As Double = 0
                    Balance = 0
                    Balance = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_IncreaseCODE, YearStart, LastPeriodEnd, AN_Approved)
                    Balance = Balance + Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_CarryForwardCODE, YearStart, YearEnd, AN_Approved)
                    AL_Entitlement = Balance

                    AL_Taken = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_DecreaseCODE, YearStart, LastPeriodEnd, AN_Approved)
                    TakenBeforePeriod = AL_Taken
                    'AL_Taken = RoundMe3(Balance - TakenBeforePeriod, 2)


                    Month_Taken = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_DecreaseCODE, Per.DateFrom, Per.DateTo, AN_Approved)
                    Month_entitled = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_IncreaseCODE, Per.DateFrom, Per.DateTo, AN_Approved)

                    Balance = RoundMe3(Balance - TakenBeforePeriod - Month_Taken, 2)
                    DaysBalance = RoundMe3(Balance / TempGrp.DayUnits, 2)

                    R_OpeningBalance = RoundMe3(AL_Entitlement - TakenBeforePeriod, 2)
                    R_MonthEntitlement = Month_entitled
                    R_MonthBooked = Month_Taken
                    R_ClosingBalance = RoundMe3(R_OpeningBalance + R_MonthEntitlement - R_MonthBooked, 2)

                    DsEmp.Tables(0).Rows(i).Item(2) = Format(R_OpeningBalance, "0.00")
                    DsEmp.Tables(0).Rows(i).Item(3) = Format(R_MonthEntitlement, "0.00")
                    DsEmp.Tables(0).Rows(i).Item(4) = Format(R_MonthBooked, "0.00")
                    DsEmp.Tables(0).Rows(i).Item(5) = Format(R_ClosingBalance, "0.00")



                End If


                ''''''''''''''''''
            Next
        End If





        Me.DG1.DataSource = DsEmp.Tables(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer


        HeaderStr.Add("Emp Code")
        HeaderStr.Add("Emp Name")
        HeaderStr.Add("Opening Balance")
        HeaderStr.Add("Month Entitlement")
        HeaderStr.Add("Month Booked")
        HeaderStr.Add("Closing Balance")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(15)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)


        Loader.LoadIntoExcel(DsEmp, HeaderStr, HeaderSize)
    End Sub
End Class