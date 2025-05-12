Public Class FrmLoadOvertimesFromExcel2

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        
        If OpenFile.FileName <> "" Then

            
            CType(Me.Owner, FrmPayroll1).LFE_OV2_FirstLine = Me.txtFirstLineToRead.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_EmployeeColumnNo = Me.txtEmployeeColumnNo.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_EmployeeTotalLen = Me.txtEmployeeTotalLen.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_EmployeePrefix = Me.txtEmployeePrefix.Text

            CType(Me.Owner, FrmPayroll1).LFE_OV2_colOver1 = Me.txtColOv1.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_colOver2 = Me.txtColOv2.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_colOver3 = Me.txtColOv3.Text

            CType(Me.Owner, FrmPayroll1).LFE_OV2_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).LFE_OV2_Proceed = True


            Me.Close()
        Else
            CType(Me.Owner, FrmPayroll1).LFE_OV2_Proceed = False
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
