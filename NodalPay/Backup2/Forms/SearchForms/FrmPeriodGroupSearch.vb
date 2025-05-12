Public Class FrmPeriodGroupSearch
    Public DsPeriodGroups As DataSet
    Public CalledBy As Integer
   

    Private Sub FrmPeriodGroupSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = DsPeriodGroups.Tables(0)
    End Sub
   
    Private Sub DG1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellDoubleClick

        Dim Code As String
        Code = DbNullToString(DsPeriodGroups.Tables(0).Rows(e.RowIndex).Item(0))
        Dim PerGrp As New cPrMsPeriodGroups(Code)
        If PerGrp.Code <> "" Then
            Select Case CalledBy
                Case 1
                    CType(Me.Owner, FrmPayrollTotalsX).cmbPeriodGroups.SelectedIndex = CType(Me.Owner, FrmPayrollTotalsX).cmbPeriodGroups.FindStringExact(PerGrp.ToString)
                Case 2
                    CType(Me.Owner, FrmRptSIContributions).cmbPeriodGroups.SelectedIndex = CType(Me.Owner, FrmRptSIContributions).cmbPeriodGroups.FindStringExact(PerGrp.ToString)
                Case 3
                    CType(Me.Owner, FrmIR63A).cmbPeriodGroups.SelectedIndex = CType(Me.Owner, FrmIR63A).cmbPeriodGroups.FindStringExact(PerGrp.ToString)
                Case 4
                    CType(Me.Owner, FrmPrMsPeriods).ComboPeriodGroup.SelectedIndex = CType(Me.Owner, FrmPrMsPeriods).ComboPeriodGroup.FindStringExact(PerGrp.ToString)
            End Select
        End If
        Me.Close()

    End Sub

End Class