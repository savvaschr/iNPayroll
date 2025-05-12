Public Class FrmPrTxLoanComments
    Public MyEmp As New cPrMsEmployees
    Public LoanId As String
    Dim Loan As New cPrTxEmployeeLoan
    Dim DG1Changing As Boolean

    
    Private Sub FrmPrTxLoanComments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
        Loan = New cPrTxEmployeeLoan(LoanId)
        FillDG1()
        Me.txtEmployeeName.Text = MyEmp.FullName
        Me.txtEmployeeName.Enabled = False


    End Sub
    Private Sub Init()
        ClearMe()
        PutDecimalValidationOnTxts()
    End Sub
    Private Sub FillDG1()

        Dim Ds As DataSet
        Ds = Global1.Business.GetLoanComments(Loan.LoanCode)
        DG1Changing = True
        Me.DG1.DataSource = Ds.Tables(0)
        DG1Changing = False
        Me.LoadDataFromDG1(0)
    End Sub
    Private Sub ClearMe()
        Me.txtAmount.Text = 0.0
        Me.txtComment.Text = ""
        Me.txtId.Text = 0
        Me.ComboBox1.SelectedIndex = 0
        Me.DateMy.Value = Now.Date
        Me.txtChequeNo.Text = ""

    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtAmount.Leave, AddressOf NumericOnLeave
    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        If DG1Changing = False Then
            Try
                Dim i As Integer
                i = DG1.CurrentRow.Index
                LoadDataFromDG1(i)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe()

        If Me.DG1.RowCount > 0 Then
            Me.txtId.Text = DbNullToInt(DG1.Item(0, i).Value)
            Me.DateMy.Value = DbNullToDate(DG1.Item(3, i).Value)
            Me.txtAmount.Text = DbNullToDouble(DG1.Item(4, i).Value)
            Me.txtComment.Text = DbNullToString(DG1.Item(5, i).Value)
            Me.ComboBox1.SelectedIndex = DbNullToInt(DG1.Item(6, i).Value)
            Me.txtChequeNo.Text = DbNullToString(DG1.Item(7, i).Value)
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        ClearMe()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TryToSave()
    End Sub
    Private Sub TryToSave()


        Try
            Dim LoanComment As New cPrTxLoanComments(Me.txtId.Text)
            With LoanComment
                .LoanCode = Loan.LoanCode
                .EmpCode = MyEmp.Code
                .Amount = Me.txtAmount.Text
                .MyDate = Me.DateMy.Value.Date
                .MyType = Me.ComboBox1.SelectedIndex
                .Comment = Me.txtComment.Text
                .ChequeNo = Me.txtChequeNo.Text



                If .Save() Then
                    MsgBox("Changes are successfully Saved")
                    FillDG1()
                    FindWhereToSelect(.Id)
                Else
                    MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To Me.DG1.RowCount - 1
            If DbNullToString(DG1.Item(0, i).Value) = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(3)
                LoadDataFromDG1(i)
                Exit Sub
            End If
        Next

    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To Me.DG1.RowCount - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim LoanComment As New cPrTxLoanComments(Me.txtId.Text)
        If LoanComment.Id <> 0 Then
            If LoanComment.Delete(LoanComment.Id) Then
                MsgBox("Succesfull Event Deletion", MsgBoxStyle.Information)
            Else
                MsgBox("Fail to Delete the Specific Event", MsgBoxStyle.Information)
            End If
        End If

    End Sub
End Class