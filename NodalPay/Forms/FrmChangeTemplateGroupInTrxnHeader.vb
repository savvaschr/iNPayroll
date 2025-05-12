Public Class FrmChangeTemplateGroupInTrxnHeader
    Public Emp As New cPrMsEmployees


    Private Sub FrmChangeTemplateGroupInTrxnHeader_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FromTemp As String = Me.txtFromTemp.Text
        Dim ToTemp As String = Me.txtToTemp.Text
        

        If Global1.Business.ChangeTemplateGroupCodeOfemployee(Emp.Code, FromTemp, ToTemp) Then
            MsgBox("Completed")
        Else
            MsgBox("Failed")
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
        Dim FromPer As String = Me.txtFromPeriod.Text
        Dim toPer As String = Me.txtToPeriod.Text

        If Global1.Business.ChangePeriodGroupCodeOfEmployee(Emp.Code, FromPer, toPer) Then
            MsgBox("Completed")
        Else
            MsgBox("Failed")
        End If
    End Sub
End Class