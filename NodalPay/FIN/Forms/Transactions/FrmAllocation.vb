Public Class FrmAllocation
    Public GlbBusPartnerCode
    Public GlbTrxnType As String

    Dim GLBDsAlloc As DataSet
    Dim Counter As Integer
    Dim Col_Id As Integer = 0
    Dim Col_JouLineNo As Integer = 1
    Dim Col_DocDate As Integer = 2
    Dim Col_UnAllocBalanceLC As Integer = 3
    Dim Col_AlphaCode As Integer = 4
    Dim Col_UnAllocBalanceTC As Integer = 5
    Dim Col_Selected As Integer = 6
    Dim Col_Amount As Integer = 7
    Dim GLBBusPrt As New cBusinessPartner

    Private Sub btnBusPrtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusPrtSearch.Click
        Dim F As New FrmSearchBusPartner
        F.Owner = Me

        '''''''''''''''''CUSTOMERS - BOTH'''''''''''''''''''''''
        If Me.GlbTrxnType = Global1.FI_TrxnType_SALES Then
            F.ShowOnlyCustomer = True
            F.ShowOnlySuplier = False
        ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_PURCHASES Then
            F.ShowOnlyCustomer = False
            F.ShowOnlySuplier = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''SUPPLIERS - BOTH'''''''''''''''''''''''
        'If Me.GlbTrxnType = Global1.FI_TrxnType_PURCHASES Then
        '    F.ShowOnlyCustomer = False
        '    F.ShowOnlySuplier = True
        'ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_PAYMENTS Then
        '    F.ShowOnlyCustomer = False
        '    F.ShowOnlySuplier = True
        'End If

        'If Me.GlbTrxnType = Global1.FI_TrxnType_CUSTOMER_ADJ Then
        '    F.ShowOnlyCustomer = True
        '    F.ShowOnlySuplier = False
        'ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_SUPPLIER_ADJ Then
        '    F.ShowOnlyCustomer = False
        '    F.ShowOnlySuplier = True
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        F.CalledBy = 4
        F.ShowDialog()

    End Sub
    Public Sub LoadDataGrid(ByRef Ds As DataSet)

        DG1.DataSource = Ds.Tables(0)
        Counter = Ds.Tables(0).Rows.Count - 1
        CalculateAmount()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick
        If e.ColumnIndex = Col_Selected Then
            Dim s As String
            Dim Amount As Double
            s = DbNullToString(DG1.Item(Col_Selected, DG1.CurrentRow.Index).Value)
            Amount = DbNullToDouble(DG1.Item(Col_UnAllocBalanceTC, DG1.CurrentRow.Index).Value)
            If s = CStr(0) Then
                DG1.Item(Col_Selected, DG1.CurrentRow.Index).Value = 1
                DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = Format(Amount, "0.00")
            Else
                DG1.Item(Col_Selected, DG1.CurrentRow.Index).Value = 0
                DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = "0.00"
            End If
            Debug.WriteLine(s)
            calculateAmount()
        End If
    End Sub

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        If e.ColumnIndex = Me.Col_Amount Then
            Dim s As String
            Dim TextEntered As String
            Dim UnAllocAmount As Double
            s = DbNullToString(DG1.Item(Col_Selected, DG1.CurrentRow.Index).Value)
            UnAllocAmount = DbNullToDouble(DG1.Item(Col_UnAllocBalanceTC, DG1.CurrentRow.Index).Value)
            TextEntered = DbNullToString(DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value)
            If s = CStr(1) Then
                If IsNumeric(TextEntered) Then
                    If TextEntered > UnAllocAmount Then
                        DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = "0.00"
                    Else
                        DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = Format(CDbl(TextEntered), "0.00")
                    End If
                Else
                    DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = "0.00"
                End If
            Else
                DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = "0.00"
            End If
            CalculateAmount()
        End If
    End Sub

    Private Sub CalculateAmount()
        Dim i As Integer
        Dim totalAmount As Double = 0
        For i = 0 To Counter
            totalAmount = totalAmount + DbNullToDouble(DG1.Item(Col_Amount, i).Value)
        Next
        Me.txtTotalAmount.Text = Format(totalAmount, "0.00")
    End Sub

    Private Sub BtnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProceed.Click
        CalculateAmount()
        If CDbl(Me.txtTotalAmount.Text) <> 0 Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Allocate Amount " & Format(CDbl(Me.txtTotalAmount.Text), "0.00"), MsgBoxStyle.YesNoCancel)
            Dim Periodcode As String
            Periodcode = Global1.Business.GetPeriodCode(Now.Date)
            If Ans = MsgBoxResult.Yes Then
                If UpdateAllocationBalances(0, Periodcode, Now.Date) Then
                    MsgBox("Allocation is succesfully Updated", MsgBoxStyle.Information)
                    Me.BtnProceed.Enabled = False
                Else
                    MsgBox("Fail to Updated allocation", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    Private Sub CallAllocation()
        Dim DC As String = ""
        Me.Cursor = Cursors.WaitCursor

        If Me.GLBBusPrt.Code <> "" Then
            If Me.GlbTrxnType = Global1.FI_TrxnType_SALES Then
                DC = "D"
            End If
            If Me.GlbTrxnType = Global1.FI_TrxnType_RECEIPTS Then
                DC = "C"
            End If

            GLBDsAlloc = Global1.Business.GetJournalEntriesWithUnAllocBalance(Me.GLBBusPrt.Code, DC)
            LoadDataGrid(GLBDsAlloc)
            Me.BtnProceed.Enabled = True
        Else
            MsgBox("Please Choose Valid Business Partner First", MsgBoxStyle.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtBusPartnerCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusPartnerCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            LoadBusinessPartner(Me.txtBusPartnerCode.Text)
        End If
    End Sub
    Private Sub txtBusPartnerCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBusPartnerCode.Validated
        LoadBusinessPartner(Me.txtBusPartnerCode.Text)
    End Sub
    Public Sub LoadBusinessPartner(ByVal Code As String)
        GLBBusPrt = New cBusinessPartner(Code)
        If GLBBusPrt.Code <> "" Then
            Me.txtBusPartnerCode.Text = GLBBusPrt.Code
            Me.txtBusPartnerDesc.Text = GLBBusPrt.DescL
            Err1.SetError(Me.txtBusPartnerCode, "")
            Me.txtCurRate.Text = Format(Global1.Business.GetCurruncyRate(GLBBusPrt.CurAlphaCode, Now.Date), "0.000000")
            CallAllocation()

        Else
            Me.txtBusPartnerDesc.Text = ""
            Err1.SetError(Me.txtBusPartnerCode, "Invalid Business Partner Code")
            Me.txtCurRate.Text = "0.000000"
        End If

    End Sub
    Private Function UpdateAllocationBalances(ByVal HeaderId As Integer, ByVal PeriodCode As String, ByVal AllocationDate As Date) As Boolean
        Dim Flag As Boolean = True
        Dim i As Integer
        Dim Exx As New SystemException
        Try
            Global1.Business.BeginTransaction()
        
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'CASE 1: Transaction Currency = Business Partner Currency = Local Currency
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Global1.LocalCurencyCode = GLBBusPrt.CurAlphaCode Then
                ' Sub Case 11: Selection of Allocation 
                If CheckDataSet(Me.GLBDsAlloc) Then
                    Dim Selected As String
                    Dim Id As String
                    Dim Amount As Double
                    For i = 0 To GLBDsAlloc.Tables(0).Rows.Count - 1
                        Selected = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Selected))
                        If Selected = CStr(1) Then
                            Id = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Id))
                            Amount = DbNullToDouble(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Amount))
                            Dim AccLin As New cAccountLines(Id)
                            AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - Amount
                            AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
                            If AccLin.UnAllocBalanceLC = 0 Then
                                AccLin.AllocStatus = "A"
                            Else
                                AccLin.AllocStatus = "P"
                            End If
                            AccLin.AmendBy = Global1.GLBUserId
                            AccLin.AmendDate = Now.Date
                            If Not AccLin.Save Then
                                Flag = False
                                Throw Exx
                            End If
                            If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, Amount, Amount) Then
                                Flag = False
                                Throw Exx
                            End If
                        End If
                    Next
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'CASE 2: Transaction Currency = Local Currency , Allocation Currency = Business Partner Currency
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Global1.LocalCurencyCode <> GLBBusPrt.CurAlphaCode Then
                ' Sub Case 21: Selection of Allocation 
                If CheckDataSet(Me.GLBDsAlloc) Then
                    Dim Selected As String
                    Dim Id As String
                    Dim Amount As Double
                    For i = 0 To GLBDsAlloc.Tables(0).Rows.Count - 1
                        Selected = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Selected))
                        If Selected = CStr(1) Then
                            Id = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Id))
                            Amount = DbNullToDouble(GLBDsAlloc.Tables(0).Rows(i).Item(Col_Amount))
                            Dim AccLin As New cAccountLines(Id)
                            If Amount = AccLin.UnAllocBalanceTC Then
                                AccLin.UnAllocBalanceLC = 0
                                AccLin.UnAllocBalanceTC = 0
                                AccLin.AllocStatus = "A"
                            Else
                                AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - (Amount * Me.txtCurRate.Text)
                                AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
                                AccLin.AllocStatus = "P"
                            End If
                            AccLin.AmendBy = Global1.GLBUserId
                            AccLin.AmendDate = Now.Date
                            If Not AccLin.Save Then
                                Flag = False
                                Throw Exx
                            End If
                            If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, (Amount * Me.txtCurRate.Text), Amount) Then
                                Flag = False
                                Throw Exx
                            End If
                        End If
                    Next
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''CASE 3: Transaction Currency <> Local Currency , Transaction Currency = Allocation Currency = Business Partner Currency
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Global1.LocalCurencyCode <> Me.btnTrxCur.Text And Me.btnTrxCur.Text = Me.btnBusCur.Text Then
            '    ' Sub Case 31: Selection of Allocation 
            '    If Me.CBAllocated.CheckState = CheckState.Checked Then
            '        If CheckDataSet(Me.GLBDsAlloc) Then
            '            Dim Selected As String
            '            Dim Id As String
            '            Dim Amount As Double
            '            Dim DayCurRate As Double

            '            DayCurRate = Global1.Business.GetCurruncyRate(Me.btnBusCur.Text, Now.Date)

            '            For i = 0 To GLBDsAlloc.Tables(0).Rows.Count - 1
            '                Selected = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(AllocCol_Selected))
            '                If Selected = CStr(1) Then
            '                    Id = DbNullToString(GLBDsAlloc.Tables(0).Rows(i).Item(AllocCol_Id))
            '                    Amount = DbNullToDouble(GLBDsAlloc.Tables(0).Rows(i).Item(AllocCol_Amount))
            '                    Dim AccLin As New cAccountLines(Id)
            '                    If Amount = AccLin.UnAllocBalanceTC Then
            '                        AccLin.UnAllocBalanceLC = 0
            '                        AccLin.UnAllocBalanceTC = 0
            '                        AccLin.AllocStatus = "A"
            '                    Else
            '                        AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - (Amount * DayCurRate)
            '                        AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
            '                        AccLin.AllocStatus = "P"
            '                    End If
            '                    AccLin.AmendBy = Global1.GLBUserId
            '                    AccLin.AmendDate = Now.Date
            '                    If Not AccLin.Save Then
            '                        Flag = False
            '                        Throw Exx
            '                    End If
            '                    If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, (Amount * DayCurRate), Amount) Then
            '                        Flag = False
            '                        Throw Exx
            '                    End If
            '                End If
            '            Next
            '        End If
            '    Else
            '        'Sub Case 32: No Allocation
            '    End If
            'End If
            Global1.Business.CommitTransaction()
        Catch ex As Exception
            Global1.Business.Rollback()
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function SaveAllocation(ByVal AccountLineId As Integer, ByVal HeaderId As Integer, ByVal PeriodCode As String, ByVal AllocationDate As Date, ByVal AmountLC As Double, ByVal AmountTC As Double) As Boolean
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            Dim Alloc As New cFiTxAllocations
            With Alloc
                .AccLineId = AccountLineId
                .TrxHeaderId = 0
                .PrdCode = PeriodCode
                .AllocationDate = AllocationDate
                .CurAlphaCode = GLBBusPrt.CurAlphaCode
                .AllocationRate = Me.txtCurRate.Text
                .AllocationAmountLC = AmountLC
                .AllocationAmountTC = AmountTC
                .CreationDate = Now.Date
                .CreatedBy = Global1.GLBUserId
                .AmendDate = Now.Date
                .AmendBy = Global1.GLBUserId
                If Not .Save Then
                    Throw Exx
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub FrmAllocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtCurRate.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtCurRate.Leave, AddressOf Utils.NumericOnLeave6Decimals
    End Sub
End Class