Public Class FrmChequeDetails
    Public CalledBY As Integer
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        If Not IsNumeric(Me.txtChequeNo.Text) Then
            MsgBox("Cheque Number value Must be Numeric,Please Correct", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim Ans As MsgBoxResult
        Ans = MsgBox("Please Put the cheques in the Printer and Click 'OK' to start printing")
        If CalledBY = 1 Then
            CType(Me.Owner, FrmPayroll1).GLBChequeNo = Me.txtChequeNo.Text
            CType(Me.Owner, FrmPayroll1).GLBChequeDate = Me.DateCheque.Value.Date
        ElseIf CalledBY = 2 Then
            Global1.GLBTempChequeNo = Me.txtChequeNo.Text
            Global1.GLBTempChequeDate = Me.DateCheque.Value.Date
        End If


        Me.Close()
    End Sub

    Private Sub FrmChequeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DateCheque.Value = Now.Date
    End Sub
End Class