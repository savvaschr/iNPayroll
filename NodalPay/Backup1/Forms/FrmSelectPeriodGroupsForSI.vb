Public Class FrmSelectPeriodGroupsForSI
    Public TemGrp As cPrMsTemplateGroup
    Public PeriodGroup As cPrMsPeriodGroups
    Dim Ds As DataSet

    Private Sub FrmSelectPeriodGroupsForSI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Ds = New DataSet
        Global1.DSforSIfile = Ds
        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)



        Ds = Global1.Business.GetAllPeriodGroupsOfTemplateGroupCompany(Company.Code, PeriodGroup.Year)
        DG1.DataSource = Ds.Tables(0)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Global1.DSforSIfile = Ds
        Me.Close()
    End Sub
End Class