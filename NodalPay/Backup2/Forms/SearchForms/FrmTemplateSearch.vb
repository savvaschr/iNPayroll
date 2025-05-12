Public Class FrmTemplateSearch
    Public DsTemp As DataSet
    Public CalledBy As Integer

   
    Private Sub FrmTemplateSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = DsTemp.Tables(0)
    End Sub

    Private Sub DG1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellDoubleClick

        Dim Code As String
        Code = DbNullToString(DsTemp.Tables(0).Rows(e.RowIndex).Item(0))
        Dim Temp As New cPrMsTemplateGroup(Code)
        If Temp.Code <> "" Then
            Select Case CalledBy
                Case 1
                    CType(Me.Owner, FrmPayroll1).ComboTempGroups.SelectedIndex = CType(Me.Owner, FrmPayroll1).ComboTempGroups.FindStringExact(Temp.ToString)
                Case 2
                    CType(Me.Owner, frmPrMsEmployees).cmbTemGrp_Code.SelectedIndex = CType(Me.Owner, frmPrMsEmployees).cmbTemGrp_Code.FindStringExact(Temp.ToString)
            End Select
        End If
        Me.Close()

    End Sub
   
    
End Class