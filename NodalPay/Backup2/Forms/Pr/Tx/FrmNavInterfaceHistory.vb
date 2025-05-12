Public Class FrmNavInterfaceHistory
    Public TemGrp As cPrMsTemplateGroup
    Dim ds As DataSet
    Private Sub FrmNavInterfaceHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        FillDG1()
        Me.Top = 420
        Me.Left = 200
        If Global1.PARAM_FTPToNodal Then
            Me.CBNOFTP.Visible = True
        Else
            Me.CBNOFTP.Visible = False
        End If


    End Sub
    Private Sub FillDG1()

        ds = Global1.Business.GetAllPrSsNavBatch2(TemGrp)
        Me.DG1.DataSource = ds.Tables(0)
        Me.DG1.AllowUserToOrderColumns = False

    End Sub

    Private Sub btnRegenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegenerate.Click
        Dim NoFTP As Boolean = False
        Dim Reverse As Boolean = False
        If Me.CBNOFTP.Visible Then
            If Me.CBNOFTP.CheckState = CheckState.Checked Then
                NoFTP = True
            Else
                NoFTP = False
            End If
        Else
            noftp = False
        End If
        If Me.cbreverse.CheckState = CheckState.Checked Then
            Reverse = True
        End If



        Me.Cursor = Cursors.WaitCursor
        If CheckDataSet(ds) Then
            Dim i As Integer
            Dim BatchId As Integer
            i = DG1.CurrentRow.Index
            BatchId = DG1.Item(0, i).Value
            Dim NavBatch As New cPrSsNavBatch(BatchId)
            CType(Me.Owner, FrmPayroll1).SendPaymentToNavision(NavBatch.IdFrom, NavBatch.IdTo, True, NavBatch, True, NoFTP, Reverse)
            FillDG1()
            GC.Collect()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSenddataToExelsys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSenddataToExelsys.Click
        Me.Cursor = Cursors.WaitCursor
        If CheckDataSet(ds) Then
            Dim i As Integer
            Dim BatchId As Integer
            i = DG1.CurrentRow.Index
            BatchId = DG1.Item(0, i).Value
            Dim NavBatch As New cPrSsNavBatch(BatchId)
            If CType(Me.Owner, FrmPayroll1).ExportPayslipsInPDFForExelsys(NavBatch.IdFrom, NavBatch.IdTo) Then
                CType(Me.Owner, FrmPayroll1).SendRecordsAndPayslipsToExelsys(NavBatch.IdFrom, NavBatch.IdTo, True, NavBatch, True)
                GC.Collect()
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnBatchCorrection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchCorrection.Click
        Me.Cursor = Cursors.WaitCursor
        If CheckDataSet(ds) Then
            Dim i As Integer
            Dim BatchId As Integer
            i = DG1.CurrentRow.Index
            BatchId = DG1.Item(0, i).Value
            Dim NavBatch As New cPrSsNavBatch(BatchId)
            Dim F As New FrmSsNavBatchCorrection
            F.batch = NavBatch
            F.showdialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class