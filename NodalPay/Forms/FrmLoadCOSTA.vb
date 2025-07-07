Public Class FrmLoadCOSTA
    Public glbtextfile As Boolean = False
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            OpenFile.FileName = ""
            OpenFile.ShowDialog()
            Me.txtToFile.Text = OpenFile.FileName
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
            Dim EDCType As String
            Dim EDCCode As String
            If OpenFile.FileName <> "" Then

            CType(Me.Owner, FrmPayroll1).COSTA_FirstLine = Me.txtFirstLineToRead.Text
            CType(Me.Owner, FrmPayroll1).COSTA_EmpMapCodes_COLNo = Me.txtEmpTACode.Text
            CType(Me.Owner, FrmPayroll1).COSTA_Units_COLNo = Me.txtUnits.Text
            CType(Me.Owner, FrmPayroll1).COSTA_Overtime1_COLNo = Me.txtOvertime1.Text
            CType(Me.Owner, FrmPayroll1).COSTA_Overtime3_COLNo = Me.txtOvertime3.Text
            CType(Me.Owner, FrmPayroll1).COSTA_E14_COLNo = Me.txtE14.Text
            CType(Me.Owner, FrmPayroll1).COSTA_E36_COLNo = Me.txtE36.Text
            CType(Me.Owner, FrmPayroll1).COSTA_E35_COLNo = Me.txtE35.Text

            CType(Me.Owner, FrmPayroll1).COSTA_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).COSTA_Proceed = True


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
            CType(Me.Owner, FrmPayroll1).COSTA_File = Me.txtToFile.Text
            CType(Me.Owner, FrmPayroll1).COSTA_Proceed = False

        End If

    End Sub

    Private Sub FrmLoadKELIO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not glbtextfile Then
            Me.txtFirstLineToRead.Text = 2
            Me.txtEmpTACode.Text = 2
            Me.txtUnits.Text = 3
            Me.txtOvertime1.Text = 4
            Me.txtOvertime3.Text = 5
            Me.txtE14.Text = 6
            Me.txtE36.Text = 7
            Me.txtE35.Text = 8
        Else
            Me.txtFirstLineToRead.Text = 0
            Me.txtEmpTACode.Text = 1
            Me.txtUnits.Text = 2
            Me.txtOvertime1.Text = 3
            Me.txtOvertime3.Text = 4
            Me.txtE14.Text = 5
            Me.txtE36.Text = 6
            Me.txtE35.Text = 7
            Me.txtFirstLineToRead.Enabled = False
            Me.txtEmpTACode.Enabled = False
            Me.txtUnits.Enabled = False
            Me.txtOvertime1.Enabled = False
            Me.txtOvertime3.Enabled = False
            Me.txtE14.Enabled = False
            Me.txtE36.Enabled = False
            Me.txtE35.Enabled = False
        End If


    End Sub


    End Class