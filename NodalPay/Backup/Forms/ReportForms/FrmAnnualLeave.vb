Public Class FrmAnnualLeave
    Public MyDs As DataSet
    Public Per As cPrMsPeriodCodes
    Dim MyDs2 As DataSet
    Dim Dt1 As DataTable
    Dim LeaveTypes As cPrSsLeaveTypes
    Dim NewYear As Date

    Public TempGrp As cPrMsTemplateGroup


    Private Sub FrmAnnualLeave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LeaveCode As String
        Dim ds As DataSet
        ds = Global1.Business.GetParameter("Leave Type", "Annual Leave ID")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            LeaveCode = Par.Value1
        Else
            MsgBox("Annual Leave Parameter is missing", MsgBoxStyle.Critical)

            Exit Sub
        End If
        LeaveTypes = New cPrSsLeaveTypes(LeaveCode)

        InitDataTable()
        InitDataGrid()

        LoadValuesIntoGrid()

        ' NewYear = DateAdd(DateInterval.Year, 1, Per.DateFrom)
        ' NewYear = CDate(NewYear.Year & "/01/01")


    End Sub
    Private Sub InitDataGrid()
        MyDs2 = New DataSet
        MyDs2.Tables.Add(Dt1)
        DG1.DataSource = MyDs2.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("Annual Leave(Units)", System.Type.GetType("System.Double"))
        '3
        Dt1.Columns.Add("Annual Leave(Days)", System.Type.GetType("System.Double"))
        '4
        Dt1.Columns.Add("Annual SI Leave(Units)", System.Type.GetType("System.Double"))
        '5
        Dt1.Columns.Add("Annual SI Leave(Days)", System.Type.GetType("System.Double"))
        '6
        Dt1.Columns.Add("Sick Leave(Units)", System.Type.GetType("System.Double"))
        '7
        Dt1.Columns.Add("Sick Leave(Days)", System.Type.GetType("System.Double"))
        '8
        Dt1.Columns.Add("Army Leave(Units)", System.Type.GetType("System.Double"))
        '9
        Dt1.Columns.Add("Army Leave(Days)", System.Type.GetType("System.Double"))
        '10
        Dt1.Columns.Add("Maternity(Units)", System.Type.GetType("System.Double"))
        '11
        Dt1.Columns.Add("Maternity(Days)", System.Type.GetType("System.Double"))
        '12
        Dt1.Columns.Add("Unexused Leave(Units)", System.Type.GetType("System.Double"))
        '13
        Dt1.Columns.Add("Unexused Leave(Days)", System.Type.GetType("System.Double"))
        

    End Sub
    Private Sub LoadValuesIntoGrid()
        Dim DayRate As Double
        DayRate = TempGrp.DayUnits


        Dim FromDate As Date
        Dim ToDate As Date
        Dim Str As String = ""


        Dim i As Integer
        FromDate = CDate(Per.DateFrom.Year & "/" & "01/01")
        ToDate = CDate(Per.DateFrom.Year & "/" & "12/31")
        Dim EmpCode As String
        Dim EmpName As String
        Dim Balance As Double = 0
        Dim EOY As Double = 0
        Dim DSLeaveTypes As New DataSet
        Dim PrevEmpCode As String
        Dim k As Integer
        DSLeaveTypes = Global1.Business.AG_GetAllPrSsLeaveTypes

        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            EmpCode = MyDs.Tables(0).Rows(i).Item(2)
            EmpName = MyDs.Tables(0).Rows(i).Item(3)
            Balance = 0
            Dim r As DataRow
            r = Dt1.NewRow
            r(0) = EmpCode
            r(1) = EmpName
            If CheckDataSet(DSLeaveTypes) Then
                For k = 0 To DSLeaveTypes.Tables(0).Rows.Count - 1
                    LeaveTypes = New cPrSsLeaveTypes(DSLeaveTypes.Tables(0).Rows(k))
                    Balance = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
                    Balance = Balance + Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
                    Balance = Balance - Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
                    Balance = Balance - Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_EndOfYearCODE, FromDate, ToDate, AN_Approved)



                    If LeaveTypes.Code = 1 Then
                        r(2) = Balance
                        r(3) = RoundMe3(Balance / DayRate, 2)
                    ElseIf LeaveTypes.Code = 2 Then
                        r(4) = Balance
                        r(5) = RoundMe3(Balance / DayRate, 2)
                    ElseIf LeaveTypes.Code = 3 Then
                        r(6) = Balance
                        r(7) = RoundMe3(Balance / DayRate, 2)
                    ElseIf LeaveTypes.Code = 4 Then
                        r(8) = Balance
                        r(9) = RoundMe3(Balance / DayRate, 2)
                    ElseIf LeaveTypes.Code = 5 Then
                        r(10) = Balance
                        r(11) = RoundMe3(Balance / DayRate, 2)
                    ElseIf LeaveTypes.Code = 6 Then
                        r(12) = Balance
                        r(13) = RoundMe3(Balance / DayRate, 2)
                    End If
                Next
            Else
                r(2) = 0
                r(3) = 0
                r(4) = 0
                r(5) = 0
                r(6) = 0
                r(7) = 0
                r(8) = 0
                r(9) = 0
                r(10) = 0
                r(11) = 0
                r(12) = 0
                r(13) = 0
            End If
            Dt1.Rows.Add(r)
            ' EOY = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_EndOfYearCODE, FromDate, ToDate, AN_Approved)

        Next


    End Sub

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer


        HeaderStr.Add("Emp Code")
        HeaderStr.Add("Emp Name")
        HeaderStr.Add("Anual Leave(Units)")
        HeaderStr.Add("Anual Leave(Days)")
        HeaderStr.Add("Anual SI Leave(Units)")
        HeaderStr.Add("Anual SI Leave(Days)")
        HeaderStr.Add("Sick Leave(Units)")
        HeaderStr.Add("Sick Leave(Days)")
        HeaderStr.Add("Army Leave(Units)")
        HeaderStr.Add("Army Leave(Days)")
        HeaderStr.Add("Maternity(Units)")
        HeaderStr.Add("Maternity(Days)")
        HeaderStr.Add("Unexused Leave(Units)")
        HeaderStr.Add("Unexused Leave(Days)")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(15)
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



        Loader.LoadIntoExcel(MyDs2, HeaderStr, HeaderSize)
    End Sub
End Class
