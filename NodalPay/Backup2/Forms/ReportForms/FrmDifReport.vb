Public Class FrmDifReport
    Public Ds As DataSet
    Public FromPeriod As String
    Public ToPeriod As String

    Private Sub FrmDifReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DG1.DataSource = Ds.Tables(0)

    End Sub
    Private Sub LoadDataSetToExcel()

        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader



        HeaderStr.Add("From Period Code")


        '1
        HeaderStr.Add("fromperiodDesc")
        '2
        HeaderStr.Add("PeriodToCode")
        '3
        HeaderStr.Add("PeriodToDesc")
        '4
        HeaderStr.Add("EmpCode")
        '5
        HeaderStr.Add("EmpName")
        '6
        HeaderStr.Add("Units " & FromPeriod)
        '7
        HeaderStr.Add("Units " & ToPeriod)
        '8
        HeaderStr.Add("Units Diff")
        '9
        HeaderStr.Add("NetSal " & FromPeriod)
        '10
        HeaderStr.Add("NetSal " & ToPeriod)
        '11
        HeaderStr.Add("NetSal Diff")
        '12
        HeaderStr.Add("TotalE " & FromPeriod)
        '13
        HeaderStr.Add("TotalE " & ToPeriod)
        '14
        HeaderStr.Add("TotalE Diff")
        '15
        HeaderStr.Add("TotalD " & FromPeriod)
        '16
        HeaderStr.Add("TotalD " & ToPeriod)
        '17
        HeaderStr.Add("TotalD Diff")
        '18
        HeaderStr.Add("TotalC " & FromPeriod)
        '19
        HeaderStr.Add("TotalC " & ToPeriod)
        '20
        HeaderStr.Add("TotalC Diff")
        '21
        HeaderStr.Add("TotalCCost " & FromPeriod)
        '22
        HeaderStr.Add("TotalCCost " & ToPeriod)
        '23
        HeaderStr.Add("TotalCCost Diff")

        '24
        HeaderStr.Add("Bonus " & FromPeriod)
        '25
        HeaderStr.Add("Bonus " & ToPeriod)
        '26
        HeaderStr.Add("Bonus Diff")
        '27
        HeaderStr.Add("Analysis2")
        '28
        HeaderStr.Add("Position")

        '29
        HeaderStr.Add("BonS " & FromPeriod)
        '30
        HeaderStr.Add("BonS " & ToPeriod)
        '31
        HeaderStr.Add("BonS Diff")


        '32
        HeaderStr.Add("MS " & FromPeriod)
        '33
        HeaderStr.Add("MS " & ToPeriod)
        '34
        HeaderStr.Add("MS Diff")

        '35
        HeaderStr.Add("BIK " & FromPeriod)
        '36
        HeaderStr.Add("BIK " & ToPeriod)
        '37
        HeaderStr.Add("BIK Diff")

        '38
        HeaderStr.Add("CostWithBIK " & FromPeriod)
        '39
        HeaderStr.Add("CostWithBIK " & ToPeriod)
        '40
        HeaderStr.Add("CostWithBIK Diff")


        '41
        HeaderStr.Add("Fine " & FromPeriod)
        '42
        HeaderStr.Add("Fine " & ToPeriod)
        '43
        HeaderStr.Add("Fine Diff")



   
        
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)

        
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Sub EXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL.Click
        LoadDataSetToExcel()
    End Sub
End Class