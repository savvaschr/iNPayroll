Public Class FrmSelectEDCToImport

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(Me.Owner, FrmPayroll1).GLBSelectedEDCforImport = Me.txtEDCCode.Text
        CType(Me.Owner, FrmPayroll1).GLB_Import_Prefix = Trim(Me.txtCodePrefix.Text)
        CType(Me.Owner, FrmPayroll1).GLB_Import_CodeLen = Me.txtCodeTotalLen.Text
        CType(Me.Owner, FrmPayroll1).GLB_Import_PadingChar = Trim(Me.txtPadchar.Text)


        Me.Close()
    End Sub
End Class