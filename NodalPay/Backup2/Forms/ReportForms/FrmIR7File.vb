Public Class FrmIR7File

    Private Sub FrmIR7File_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtTaxGiven.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTaxGiven.Leave, AddressOf NumericOnLeave
        Me.CBOriginal.Checked = True
        txtTaxGiven.Text = "0.00"

    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        CType(Me.Owner, FrmIR63A).TaxGiven = Me.txtTaxGiven.Text
        Dim Original As Integer
        If Me.CBOriginal.CheckState = CheckState.Checked Then
            Original = 1
        Else
            Original = 0
        End If
        CType(Me.Owner, FrmIR63A).Original = Original
        Me.Close()
    End Sub
End Class