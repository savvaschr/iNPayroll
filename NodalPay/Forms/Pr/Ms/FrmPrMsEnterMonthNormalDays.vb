Public Class FrmPrMsEnterMonthNormalDays
    Public Period As cPrMsPeriodCodes
    Dim P As New cPrMsPeriodWorkDays()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim exx As New Exception
        Try
            P.GrpCode = Period.PrdGrpCode
            P.PrdCode = Period.Code
            P.NormalDays = Me.txtWorkingDays.Text
            If Not P.Save Then
                MsgBox("Unable to Save Month Working Days", MsgBoxStyle.Critical)
                Throw exx
            Else
                MsgBox("Month Working Days are Saved", MsgBoxStyle.Information)
                Me.Close()
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

    End Sub

    Private Sub FrmPrMsEnterMonthNormalDays_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        P = New cPrMsPeriodWorkDays(Period.Code, Period.PrdGrpCode)
        If P.ID = 0 Then
            Me.txtWorkingDays.Text = 0
        Else
            Me.txtWorkingDays.Text = P.NormalDays
        End If
    End Sub
End Class