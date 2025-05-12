Public Class FrmTxEmployeeAnnualLeave
    Public MyDs As DataSet
    Public Per As cPrMsPeriodCodes
    Dim MyDs2 As DataSet
    Dim Dt1 As DataTable
    Dim LeaveTypes As cPrSsLeaveTypes
    Dim NewYear As Date

    Private Sub FrmTxEmployeeAnnualLeave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LeaveCode As String
        Dim ds As DataSet
        ds = Global1.Business.GetParameter("Leave Type", "Annual Leave ID")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            LeaveCode = Par.Value1
        Else
            MsgBox("Annual Leave Parameter is missing", MsgBoxStyle.Critical)
            Me.TSBSave.Enabled = False
            Exit Sub
        End If
        LeaveTypes = New cPrSsLeaveTypes(LeaveCode)

        InitDataTable()
        InitDataGrid()
        Me.txtLimit.Text = 0.0

        LoadValuesIntoGrid()

        NewYear = DateAdd(DateInterval.Year, 1, Per.DateFrom)
        NewYear = CDate(NewYear.Year & "/01/01")
        Me.txtCurrentPeriod.Text = Format(Per.DateFrom, "yyyy-MM-dd") & " - " & Format(Per.DateTo, "yyyy-MM-dd")
        Me.txtYearTocurryOver.Text = Format(NewYear, "yyyy-MM-dd")

        AddHandler txtLimit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtLimit.Leave, AddressOf NumericOnLeave

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
        Dt1.Columns.Add("Balance", System.Type.GetType("System.Double"))
        '3
        Dt1.Columns.Add("Limit", System.Type.GetType("System.Double"))
        '4
        Dt1.Columns.Add("Carry", System.Type.GetType("System.Double"))
        '5
        Dt1.Columns.Add("EOY", System.Type.GetType("System.Double"))

    End Sub
    Private Sub LoadValuesIntoGrid()

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

        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            EmpCode = MyDs.Tables(0).Rows(i).Item(2)
            EmpName = MyDs.Tables(0).Rows(i).Item(3)
            Balance = 0

            Balance = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
            Balance = Balance + Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
            Balance = Balance - Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
            EOY = Global1.Business.GetEmployeeTotalPerTypePerAction(EmpCode, LeaveTypes.Code, AN_EndOfYearCODE, FromDate, ToDate, AN_Approved)

            Dim r As DataRow
            r = Dt1.NewRow
            r(0) = EmpCode
            r(1) = EmpName
            r(2) = Balance
            r(3) = LeaveTypes.CarryOverMax
            
            r(5) = EOY
            If EOY <> 0 Then
                r(4) = 0
            Else
                If Balance <= LeaveTypes.CarryOverMax Then
                    r(4) = Balance
                Else
                    r(4) = LeaveTypes.CarryOverMax
                End If
            End If

            Dt1.Rows.Add(r)
        Next




    End Sub

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        If CheckDataSet(MyDs2) Then
            If MyDs2.Tables(0).Rows(e.RowIndex).Item(5) <> 0 Then
                If MyDs2.Tables(0).Rows(e.RowIndex).Item(4) <> 0 Then
                    MsgBox("Carry forward For this Employee has already being Saved.Carry Forward Value will be set to Zero.")
                    MyDs2.Tables(0).Rows(e.RowIndex).Item(4) = 0
                End If
            End If
        End If
    End Sub
    Private Sub DG1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG1.DataError
        Dim str As String
        Dim Column As Integer
        Dim Row As Integer
        Column = e.ColumnIndex
        Row = e.RowIndex
        str = e.Exception.Message.ToString
        Dim RowEmployee As String = ""
        Dim ColumnHeader As String = ""
        If CheckDataSet(MyDs2) Then
            RowEmployee = UCase(DbNullToString(MyDs2.Tables(0).Rows(Row).Item(1)))
            ColumnHeader = UCase(DG1.Columns(Column).HeaderText)
        End If

        If e.Exception.Message.ToString = "Input string was not in a correct format." Then
            MsgBox("Please enter a numeric Value in Column '" & ColumnHeader & "' (Column No." & Column & ") Of Employee '" & RowEmployee & "' (Row No." & Row + 1 & ")", MsgBoxStyle.Exclamation)
        End If
    End Sub
    
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Dim Exx As New Exception
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If
        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            Try

                Global1.Business.BeginTransaction()

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If MyDs2.Tables(0).Rows(i).Item(5) = 0 Then
                        If MyDs2.Tables(0).Rows(i).Item(4) <> 0 Then
                            'End Of Year
                            Dim PrTxEmployeeLeave As New cPrTxEmployeeLeave
                            With PrTxEmployeeLeave
                                .Id = 0
                                .EmpCode = MyDs2.Tables(0).Rows(i).Item(0)
                                .Status = AN_Approved
                                .Type = LeaveTypes.Code
                                .ReqDate = Per.DateTo
                                .ProcDate = Per.DateTo
                                .FromDate = Per.DateTo
                                .ToDate = Per.DateTo
                                .ProcBy = Global1.GLBUserId
                                .Units = MyDs2.Tables(0).Rows(i).Item(4)
                                .Action = AN_EndOfYearCODE
                                If Not .Save() Then
                                    Throw Exx
                                End If
                            End With
                            'End Of Year
                            PrTxEmployeeLeave = New cPrTxEmployeeLeave
                            With PrTxEmployeeLeave
                                .Id = 0
                                .EmpCode = MyDs2.Tables(0).Rows(i).Item(0)
                                .Status = AN_Approved
                                .Type = LeaveTypes.Code
                                .ReqDate = NewYear
                                .ProcDate = NewYear
                                .FromDate = NewYear
                                .ToDate = NewYear
                                .ProcBy = Global1.GLBUserId
                                .Units = MyDs2.Tables(0).Rows(i).Item(4)
                                .Action = AN_CarryForwardCODE
                                If Not .Save() Then
                                    Throw Exx
                                End If
                            End With
                        End If
                    End If
                Next
                Global1.Business.CommitTransaction()
                MsgBox("Changes Are Saved", MsgBoxStyle.Information)
                ReLoad()
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub ReLoad()
        MyDs2.Tables(0).Rows.Clear()
        LoadValuesIntoGrid()
    End Sub

    Private Sub btnTransferUnlimited_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferUnlimited.Click
        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                MyDs2.Tables(0).Rows(i).Item(4) = MyDs2.Tables(0).Rows(i).Item(2)
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                If MyDs2.Tables(0).Rows(i).Item(2) > Me.txtLimit.Text Then
                    MyDs2.Tables(0).Rows(i).Item(4) = Me.txtLimit.Text
                Else
                    MyDs2.Tables(0).Rows(i).Item(4) = MyDs2.Tables(0).Rows(i).Item(2)
                End If
            Next
        End If

    End Sub
End Class