Public Class frmIr63NameAndDesignation
    Public PrdGrp As cPrMsPeriodGroups

    Private Sub frmIr63NameAndDesignation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim StrPrintDate As String

        StrPrintDate = Format(Me.DateTimePicker1.Value, "dd/MM/yyyy")

        CType(Me.Owner, FrmIR63A).GLB_Name_OnIR63 = Me.txtName.Text
        CType(Me.Owner, FrmIR63A).GLB_Designation_OnIR63 = Me.txtdesignation.Text
        CType(Me.Owner, FrmIR63A).GLB_Printdate_OnIR63 = StrPrintDate

    End Sub

    Private Sub frmIr63NameAndDesignation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim TemplateGroup As New cPrMsTemplateGroup(PrdGrp.TemGrpCode)
        Dim Comp As New cAdMsCompany(TemplateGroup.CompanyCode)

        Me.txtName.Text = Comp.AccountantTitle

        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("IR63", "Designation")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtdesignation.Text = Par.Value1
        End If
        Me.DateTimePicker1.Value = Now.Date

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

End Class