Public Class FrmImportBetaBiz1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtOpenFile.Text = OpenFile.FileName
    End Sub

    Private Sub FrmImportBetaBiz1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.txtOpenFile.Text = "" Then
            Dim Ans As MsgBoxResult
            Ans = MsgBox("The Source file is empty, close without selecting source file ?", MsgBoxStyle.YesNoCancel)
            If Ans <> MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
        CType(Me.Owner, FrmMain).BetaBizFile = Me.txtOpenFile.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(Me.Owner, FrmMain).BetaBizFile = Me.txtOpenFile.Text
        Me.Close()
    End Sub
End Class