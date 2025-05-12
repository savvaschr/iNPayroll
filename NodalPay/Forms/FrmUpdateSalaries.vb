Public Class FrmUpdateSalaries

    Private Sub FrmUpdateSalaries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtPerc.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPerc.Leave, AddressOf NumericOnLeave
        Me.DateTimePicker1.Value = Now.Date
        Me.txtperc.text = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(Me.Owner, frmPrMsEmployees).UpdateSalaries(Me.txtPerc.Text, Me.DateTimePicker1.Value.Date)
        Me.Close()
    End Sub
End Class