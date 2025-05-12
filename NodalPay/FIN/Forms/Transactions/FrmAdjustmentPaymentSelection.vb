

Public Class FrmAdjustmentPaymentSelection
    Public GlbBusPartnerCode
    Dim Counter As Integer
    Dim Col_Id As Integer = 0
    Dim Col_JouLineNo As Integer = 1
    Dim Col_DocDate As Integer = 2
    Dim Col_UnAllocBalanceLC As Integer = 3
    Dim Col_AlphaCode As Integer = 4
    Dim Col_UnAllocBalanceTC As Integer = 5
    Dim Col_Selected As Integer = 6
    Dim Col_Amount As Integer = 7

    Private Sub FrmAdjustmentPaymentSelection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.CalculateAmount()
        CType(Me.Owner, FrmFiTrxnHeader).txtAllocTotalAmount.text = Me.txtTotalAmount.Text
    End Sub

    Private Sub FrmAdjustmentPaymentSelection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim i As Integer
        For i = 0 To Counter
            DG1.Item(Col_Amount, i).Value = "0.00"
            DG1.Item(Col_Selected, i).Value = "0"
        Next
        CalculateAmount()
        Me.Close()
    End Sub
End Class