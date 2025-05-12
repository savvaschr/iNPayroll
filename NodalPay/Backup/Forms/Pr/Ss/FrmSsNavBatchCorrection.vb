Public Class FrmSsNavBatchCorrection
    Public Batch As cPrSsNavBatch

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Batch.IdFrom = Me.txtIdFrom.Text
        Batch.IdTo = Me.txtIdTo.Text
        If Batch.Save Then
            MsgBox("Succesfully Saved")
        Else
            MsgBox("Unable to Save Changes")
        End If


    End Sub

    

    Private Sub FrmSsNavBatchCorrection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtGenBatId.Text = 0
        Me.txtIdFrom.Text = 0
        Me.txtIdTo.Text = 0

        Me.txtGenBatId.Text = Batch.Id
        Me.txtIdFrom.Text = Batch.IdFrom
        Me.txtIdTo.Text = Batch.IdTo
    End Sub
End Class