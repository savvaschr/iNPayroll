Public Class FrmLoadsalariesFromExcel
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub

    Private Sub FrmLoadsalariesFromExcel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        If OpenFile.FileName <> "" Then


            CType(Me.Owner, FrmMain).SAL_FirstLine = Me.txtFirstLineToRead.Text
            CType(Me.Owner, FrmMain).SAL_EmployeeColumnNo = Me.txtEmployeeColumnNo.Text

            CType(Me.Owner, FrmMain).SAL_SalaryColumnNumber = Me.txtSalaryColumnNo.Text

            CType(Me.Owner, FrmMain).SAL_File = Me.txtToFile.Text


            CType(Me.Owner, FrmMain).SAL_E1Code = Me.txtE1Code.Text
            If Me.txtE1Code.Text <> "" Then
                CType(Me.Owner, FrmMain).SAL_E1Number = Me.txtE1NumInExcel.Text
            Else
                CType(Me.Owner, FrmMain).SAL_E1Number = 0
            End If
            CType(Me.Owner, FrmMain).SAL_E2Code = Me.txtE2Code.Text
            If Me.txtE2Code.Text <> "" Then
                CType(Me.Owner, FrmMain).SAL_E2Number = Me.txtE2NumInExcel.Text
            Else
                CType(Me.Owner, FrmMain).SAL_E2Number = 0
            End If


            CType(Me.Owner, FrmMain).GLBLoadingFromExcelSalaries_EffDate = Me.DateEff.Value.Date
            CType(Me.Owner, FrmMain).SAL_Proceed = True

            Me.Close()
        Else
            CType(Me.Owner, FrmMain).SAL_Proceed = False
            MsgBox("Please select valid File name to upload")
        End If
    End Sub
End Class