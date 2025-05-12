Public Class FrmLoansReport
    Public Ds As DataSet
    Private Sub FrmLoansReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = Ds.Tables(0)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Emp.Code")
        HeaderStr.Add("Emp.Name")
        HeaderStr.Add("Emp.ID")
        HeaderStr.Add("Loan Description")
        HeaderStr.Add("Loan Date")
        HeaderStr.Add("Loan Amount")
        HeaderStr.Add("Total Payments")
        HeaderStr.Add("Remaining Amount")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)



        Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - RND\NodalPay\XML\Loans1")

        If CheckDataSet(Ds) Then
            Utils.ShowReport("Loans1.rpt", Ds, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

    End Sub

End Class