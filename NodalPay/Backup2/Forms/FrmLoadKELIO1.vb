Public Class FrmLoadKELIO1
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        Dim EDCType As String
        Dim EDCCode As String
        If OpenFile.FileName <> "" Then

            CType(Me.Owner, FrmPayroll1).KELIO_Prefix = Me.txtKelioPrefix.Text
            CType(Me.Owner, FrmPayroll1).KELIO_FirstLine = Me.txtFirstLineToRead.Text
            CType(Me.Owner, FrmPayroll1).KELIO_ErnCode = Me.txtErnCode.Text
            CType(Me.Owner, FrmPayroll1).KELIO_ErnColumnNo = Me.txtErnCodeInExcel.Text
            CType(Me.Owner, FrmPayroll1).KELIO_EmployeeColumnNo = Me.txtEmpCodeinExcel.Text
            CType(Me.Owner, FrmPayroll1).KELIO_Over1 = Me.txtOverTime1Column.Text
            CType(Me.Owner, FrmPayroll1).KELIO_Over2 = Me.txtOvertime2Column.Text
            CType(Me.Owner, FrmPayroll1).KELIO_PM = Me.txtPMOver1Column.Text
            CType(Me.Owner, FrmPayroll1).KELIO_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).KELIO_Proceed = True


            Me.Close()
        Else
            CType(Me.Owner, FrmPayroll1).LFE_Proceed = False
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
            CType(Me.Owner, FrmPayroll1).KELIO_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).KELIO_Proceed = False

        End If
        
    End Sub

    Private Sub FrmLoadKELIO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtKelioPrefix.Text = ""
        Me.txtFirstLineToRead.Text = 1
        Me.txtErnCode.Text = "E22"
        Me.txtEmpCodeinExcel.Text = 1
        Me.txtErnCodeInExcel.Text = 4
        Me.txtOverTime1Column.Text = 7
        Me.txtOvertime2Column.Text = 8
        Me.txtPMOver1Column.Text = 10
        
    End Sub

End Class