Public Class FrmPayslipPerCompany
    Public CompanyCode As String
    Public CompanyTotals As Boolean = False
    Dim Ds As DataSet

    Private Sub FrmPayslipPerCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCompany.Text = CompanyCode
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Total As Integer = 0
        If CompanyTotals Then
            Ds = Global1.Business.GetCompanyPayslipsTotalPerCompany(Me.txtYear.Text, CompanyCode)
            If CheckDataSet(Ds) Then
                Dim i As Integer
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Total = Total + DbNullToInt(Ds.Tables(0).Rows(i).Item(1))
                Next
            Else
                MsgBox("No results found", MsgBoxStyle.Information)
            End If
        Else
            Ds = Global1.Business.GetCompanyPayslipsPerPeriod(Me.txtYear.Text, CompanyCode)
            If CheckDataSet(Ds) Then
                Dim i As Integer
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Total = Total + DbNullToInt(Ds.Tables(0).Rows(i).Item(2))
                Next
            Else
                MsgBox("No results found", MsgBoxStyle.Information)
            End If
        End If
        DG1.DataSource = Ds.Tables(0)
        Me.txttotalPayslips.text = Total
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Company")
        HeaderStr.Add("No.Of Payslips")
        

        HeaderSize.Add(70)
        HeaderSize.Add(30)

        Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)
    End Sub
End Class