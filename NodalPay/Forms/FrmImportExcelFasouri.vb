Public Class FrmImportExcelFasouri

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            OpenFile.FileName = ""
            OpenFile.ShowDialog()
            Me.txtToFile.Text = OpenFile.FileName
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
            Dim EDCType As String
            Dim EDCCode As String
        If OpenFile.FileName <> "" Then

            CType(Me.Owner, FrmPayroll1).ET2_FirstLine = Me.txtFirstLineInExcel.Text
            CType(Me.Owner, FrmPayroll1).ET2_EmpCode = Me.txtEmployeeCode.Text
            CType(Me.Owner, FrmPayroll1).ET2_MonthlyUnits = Me.txtMonthlyUnits.Text
            CType(Me.Owner, FrmPayroll1).ET2_E10 = Me.txtTraveling.Text
            CType(Me.Owner, FrmPayroll1).ET2_E13 = Me.txtAnnualLeave.Text
            CType(Me.Owner, FrmPayroll1).ET2_E14 = Me.txtOtherEarnings.Text
            CType(Me.Owner, FrmPayroll1).ET2_E23 = Me.txtBIK.Text
            CType(Me.Owner, FrmPayroll1).ET2_E25 = Me.txtUnits.Text
            CType(Me.Owner, FrmPayroll1).ET2_E6 = Me.txt13Salary.Text
            CType(Me.Owner, FrmPayroll1).ET2_D1 = Me.txtAdvances.Text
            CType(Me.Owner, FrmPayroll1).ET2_D12 = Me.txtOtherDeductions.Text
            CType(Me.Owner, FrmPayroll1).ET2_Overtime1 = Me.txtOvertime1.Text

            CType(Me.Owner, FrmPayroll1).ET2_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).ET2_Proceed = True


            Me.Close()
        Else
            CType(Me.Owner, FrmPayroll1).ET2_Proceed = False
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
            CType(Me.Owner, FrmPayroll1).ET2_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).ET2_Proceed = False

        End If

        End Sub

        Private Sub FrmLoadKELIO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub


    End Class