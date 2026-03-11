Public Class FrmImportExcelTemplate3
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        Dim EDCType As String
        Dim EDCCode As String
        If OpenFile.FileName <> "" Then

            CType(Me.Owner, FrmPayroll1).ET3_FirstLine = Me.txtFirstLineInExcel.Text
            CType(Me.Owner, FrmPayroll1).ET3_EmpCode = Me.txtEmployeeCode.Text
            CType(Me.Owner, FrmPayroll1).ET3_MonthlyUnits = Me.txtMonthlyUnits.Text
            CType(Me.Owner, FrmPayroll1).ET3_Overtime1 = Me.txtOvertime1.Text
            CType(Me.Owner, FrmPayroll1).ET3_E33 = Me.txtSalaryAdjustment.Text
            CType(Me.Owner, FrmPayroll1).ET3_E34 = Me.txtAllowance.Text
            CType(Me.Owner, FrmPayroll1).ET3_E35 = Me.txtOnCallBonus.Text
            CType(Me.Owner, FrmPayroll1).ET3_E11 = Me.txtBonus.Text
            CType(Me.Owner, FrmPayroll1).ET3_E80 = Me.txtALNotice.Text
            CType(Me.Owner, FrmPayroll1).ET3_E81 = Me.txtExGratia.Text
            CType(Me.Owner, FrmPayroll1).ET3_E37 = Me.txtCashCancelOptions.Text
            CType(Me.Owner, FrmPayroll1).ET3_E38 = Me.TxtPerDiem.Text
            CType(Me.Owner, FrmPayroll1).ET3_E39 = Me.txtReimbOfExpenses.Text
            CType(Me.Owner, FrmPayroll1).ET3_E30 = Me.txtBIKforAssets.Text

            CType(Me.Owner, FrmPayroll1).ET3_D1 = Me.txtAdvances.Text
            CType(Me.Owner, FrmPayroll1).ET3_D12 = Me.txtOtherDeductions.Text
            CType(Me.Owner, FrmPayroll1).ET3_D23 = Me.txtTravelAdjustment.Text
            CType(Me.Owner, FrmPayroll1).ET3_D24 = Me.txtSportsDeduction.Text


            CType(Me.Owner, FrmPayroll1).ET3_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).ET3_Proceed = True


            Me.Close()
        Else
            CType(Me.Owner, FrmPayroll1).ET3_Proceed = False
            MsgBox("Please select valid File name to upload")
        End If
    End Sub

    Private Sub FrmLoadKELIO1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.txtToFile.Text = "" Then
            Dim Ans As MsgBoxResult
            Ans = MsgBox("The Source file is empty, close without selecting source file ?", MsgBoxStyle.YesNoCancel)
            If Ans <> MsgBoxResult.Yes Then
                e.Cancel = True
            End If
            CType(Me.Owner, FrmPayroll1).ET3_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).ET3_Proceed = False

        End If

    End Sub

End Class