Public Class FrmLoadOvertimesFromExcel1
   

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        Dim EDCType As String
        Dim EDCCode As String
        If OpenFile.FileName <> "" Then
            Dim S As String
            EDCCode = Me.txtEDCCode.Text
            EDCType = "E"




            CType(Me.Owner, FrmPayroll1).LFE_OV1_EDCType = EDCType
            CType(Me.Owner, FrmPayroll1).LFE_OV1_EDCCode = EDCCode
            CType(Me.Owner, FrmPayroll1).LFE_OV1_FirstLine = Me.txtFirstLineToRead.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV1_EmployeeColumnNo = Me.txtEmployeeColumnNo.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV1_EmployeeTotalLen = Me.txtEmployeeTotalLen.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV1_EmployeePrefix = Me.txtEmployeePrefix.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV1_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV1_Proceed = True


            Me.Close()
        Else
            CType(Me.Owner, FrmPayroll1).LFE_OV1_Proceed = False
            MsgBox("Please select valid File name to upload")
        End If
    End Sub

    Private Sub FrmLoadEDCFromExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim i As Integer
        'If CheckDataSet(dsErn) Then
        '    For i = 0 To dsErn.Tables(0).Rows.Count - 1
        '        Me.ComboEDC.BeginUpdate()
        '        Dim Ern As New cPrMsEarningCodes(DbNullToString(dsErn.Tables(0).Rows(i).Item(3)))
        '        Me.ComboEDC.Items.Add("E - " & Ern.Code & " - " & Ern.DescriptionL)
        '        Me.ComboEDC.EndUpdate()
        '        Me.ComboEDC.SelectedIndex = 0
        '    Next
        'End If
        'If CheckDataSet(dsDed) Then
        '    For i = 0 To dsDed.Tables(0).Rows.Count - 1
        '        Me.ComboEDC.BeginUpdate()
        '        Dim Ded As New cPrMsDeductionCodes(DbNullToString(dsDed.Tables(0).Rows(i).Item(3)))
        '        Me.ComboEDC.Items.Add("D - " & Ded.Code & " - " & Ded.DescriptionL)
        '        Me.ComboEDC.EndUpdate()
        '        Me.ComboEDC.SelectedIndex = 0
        '    Next
        'End If
        'If CheckDataSet(dsCon) Then
        '    For i = 0 To dsCon.Tables(0).Rows.Count - 1
        '        Me.ComboEDC.BeginUpdate()
        '        Dim Con As New cPrMsContributionCodes(DbNullToString(dsCon.Tables(0).Rows(i).Item(3)))
        '        Me.ComboEDC.Items.Add("C - & " & Con.Code & " - " & Con.DescriptionL)
        '        Me.ComboEDC.EndUpdate()
        '        Me.ComboEDC.SelectedIndex = 0
        '    Next
        'End If

    End Sub


End Class