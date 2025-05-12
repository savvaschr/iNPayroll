Public Class FrmMonthlyHourlyReport
    Public Ds As DataSet
    Public Ds44 As DataSet

    Private Sub FrmMonthlyHourlyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = Ds.Tables(0)
        DG2.DataSource = Ds44.Tables(0)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Period")
        HeaderStr.Add("Monthly")
        HeaderStr.Add("Hourly")
        HeaderStr.Add("Total")

        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)

        Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)



        Dim HeaderStr2 As New ArrayList
        Dim HeaderSize2 As New ArrayList
        Dim Loader2 As New cExcelLoader

        HeaderStr.Add("Period")
        HeaderStr.Add("Type")
        HeaderStr.Add("Total")
        HeaderStr.Add("Code")
        HeaderStr.Add("Description")

        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)

        Loader.LoadIntoExcel(Ds44, HeaderStr2, HeaderSize2)

    End Sub
End Class