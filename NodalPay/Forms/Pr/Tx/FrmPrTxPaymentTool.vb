Public Class FrmPrTxPaymentTool

    Public MyDs As DataSet
    Public Per As cPrMsPeriodCodes
    Dim MyDs2 As DataSet
    Dim Dt1 As DataTable




    Private Sub FrmPrTxPaymentTool_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitDataTable()
        InitDataGrid()

        LoadValuesIntoGrid()



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
        Dt1.Columns.Add("Amount", System.Type.GetType("System.Double"))


    End Sub
    Private Sub LoadValuesIntoGrid()


        Dim Str As String = ""


        Dim i As Integer

        Dim EmpCode As String
        Dim EmpName As String
        Dim Amount As Double = 0
        Dim EOY As Double = 0
        Dim PerGroup As New cPrMsPeriodGroups(Per.PrdGrpCode)
        Dim TemGroup As New cPrMsTemplateGroup(PerGroup.TemGrpCode)

        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            EmpCode = MyDs.Tables(0).Rows(i).Item(2)
            EmpName = MyDs.Tables(0).Rows(i).Item(3)
            Amount = 0


            Dim r As DataRow
            r = Dt1.NewRow
            r(0) = EmpCode
            r(1) = EmpName
            r(2) = Amount

            Dt1.Rows.Add(r)
        Next
        Dim Ds2 As DataSet
        Ds2 = Global1.Business.GetAllEmployeesPayments(TemGroup.Code, PerGroup.Code, Per.Code)
        If CheckDataSet(Ds2) Then
            Dim EmpCode1 As String = ""
            Dim EmpCode2 As String = ""
            Dim Amount2 As Double = 0
            Dim k As Integer
            For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                EmpCode1 = DbNullToString(MyDs2.Tables(0).Rows(i).Item(0))
                For k = 0 To Ds2.Tables(0).Rows.Count - 1
                    EmpCode2 = DbNullToString(Ds2.Tables(0).Rows(k).Item(6))
                    Amount2 = DbNullToDouble(Ds2.Tables(0).Rows(k).Item(8))
                    If EmpCode1 = EmpCode2 Then
                        MyDs2.Tables(0).Rows(i).Item(2) = Amount2
                        Exit For
                    End If
                Next
            Next
        End If


    End Sub

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        If CheckDataSet(MyDs2) Then
            'If MyDs2.Tables(0).Rows(e.RowIndex).Item(5) <> 0 Then
            ' If MyDs2.Tables(0).Rows(e.RowIndex).Item(4) <> 0 Then
            ' MsgBox("Carry forward For this Employee has already being Saved.Carry Forward Value will be set to Zero.")
            ' MyDs2.Tables(0).Rows(e.RowIndex).Item(4) = 0
            'End If
            'End If
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


        Dim Ans As MsgBoxResult
        Ans = MsgBox("Please make sure that Amounts are Correct !Proceed with Saving ?", MsgBoxStyle.YesNoCancel)
        If Ans <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Dim Exx As New Exception
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If
        Dim PerGroup As New cPrMsPeriodGroups(Per.PrdGrpCode)
        Dim TemGroup As New cPrMsTemplateGroup(PerGroup.TemGrpCode)


        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            Try

                Global1.Business.BeginTransaction()

                Global1.Business.DeleteEmployeesPayments(TemGroup.Code, PerGroup.Code, Per.Code)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1

                    'End Of Year
                    Dim PrTxEmployeePayments As New cPrTxEmployeesPayments
                    With PrTxEmployeePayments
                        .Id = 0
                        .EmpCode = MyDs2.Tables(0).Rows(i).Item(0)
                        .EmpFullName = MyDs2.Tables(0).Rows(i).Item(1)
                        .TemGrp_Code = TemGroup.Code
                        .Com_Code = TemGroup.CompanyCode
                        .PrdCod_Code = Per.Code
                        .PrdGrp_Code = Per.PrdGrpCode
                        .PayAmount = MyDs2.Tables(0).Rows(i).Item(2)
                        .MyYear = PerGroup.Year


                        If Not .Save() Then
                            Throw Exx
                        End If
                    End With
                Next
                Global1.Business.CommitTransaction()
                MsgBox("Payment Amounts Are Saved", MsgBoxStyle.Information)
                ReLoad()
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Save Payment Amounts", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub ReLoad()
        MyDs2.Tables(0).Rows.Clear()
        LoadValuesIntoGrid()
    End Sub

End Class