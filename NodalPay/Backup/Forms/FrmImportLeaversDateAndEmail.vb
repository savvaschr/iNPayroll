Public Class FrmImportLeaversDateAndEmail

    Private Sub FrmImportLeaversDateAndEmail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TextBox1.Text = 1
        Me.TextBox2.Text = 1
        Me.TextBox3.Text = 2
        Me.TextBox4.Text = 3
        Me.TextBox5.Text = 4


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtOpenFile.Text = OpenFile.FileName
    End Sub

    Private Sub FrmImportLeaversDateAndEmail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.txtOpenFile.Text = "" Then
            Dim Ans As MsgBoxResult
            Ans = MsgBox("The Source file is empty, close without selecting source file ?", MsgBoxStyle.YesNoCancel)
            If Ans <> MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
        CType(Me.Owner, FrmMain).leaversdateemailFile = Me.txtOpenFile.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(Me.Owner, FrmMain).ChangeBankAndIBANFile = Me.txtOpenFile.Text
        CType(Me.Owner, FrmMain).dl_FirstLine = Me.TextBox1.Text
        CType(Me.Owner, FrmMain).dl_Code_Col = Me.TextBox2.Text
        CType(Me.Owner, FrmMain).dl_email_Col = Me.TextBox3.Text
        CType(Me.Owner, FrmMain).dl_leavedate_Col = Me.TextBox4.Text
        CType(Me.Owner, FrmMain).dl_TermReason_Col = Me.TextBox5.Text

        Me.Close()
    End Sub

   
End Class