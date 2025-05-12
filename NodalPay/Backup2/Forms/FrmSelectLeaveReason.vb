Public Class FrmSelectLeaveReason

    Private Sub FrmSelectLeaveReason_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim AR As String = "A"

        If Me.RadioButton1.Checked Then
            AR = "A"
        ElseIf Me.RadioButton2.Checked Then
            AR = "M"
        ElseIf Me.RadioButton3.Checked Then
            AR = "H"
        End If

        CType(Me.Owner, FrmRptSIContributions).GlbAbsentReason = AR

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class