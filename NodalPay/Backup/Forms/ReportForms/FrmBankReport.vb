Public Class FrmBankReport
    Public ds As DataSet
    Public CompName As String
    Public Period As cPrMsPeriodCodes
    Public TemGrp As cPrMsTemplateGroup

    Public NoOfEmployees As String


    Private Sub FrmBankReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = ds.Tables(0)
        findTotal()
    End Sub
    Private Sub FindTotal()
        Dim i As Integer
        Dim Total As Double = 0
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Total = Total + DbNullToDouble(ds.Tables(0).Rows(i).Item(2))
            Next
        End If
        Me.txttotal1.Text = "Total: " & Format(Total, "0.00")
        'Me.txtTotal.Text = "Total: " & Format(Total, "0.00")

    End Sub

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer
       

        HeaderStr.Add("Emp. Code")
        HeaderStr.Add("Emp. Name")
        HeaderStr.Add("Net Salary")
        HeaderStr.Add("Emp. Bank Code")
        HeaderStr.Add("Emp. Bank Account")
        HeaderStr.Add("Emp. Bank")
        HeaderStr.Add("Emp. IBAN")
        HeaderStr.Add("Emp. ID")
        HeaderStr.Add("Beneficiary Name")
        HeaderStr.Add("Swhift Code")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(15)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)

        
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)

    End Sub

  
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim R As DataRow

        Dim C_Company As Integer = 0
        Dim C_Period As Integer = 1
       

        ' Define Data Table
        Dim dt As New DataTable

        dt = New DataTable("HeadDetails")
        '0
        dt.Columns.Add(New DataColumn("Company", System.Type.GetType("System.String")))
        '1
        dt.Columns.Add(New DataColumn("Period", System.Type.GetType("System.String")))
        

        Dim ds2 As New DataSet
        Dim Comp As New cAdMsCompany(TemGrp.CompanyCode)
        R = dt.NewRow
        R(C_Company) = Comp.Name
        R(C_Period) = Me.Period.DescriptionL

        dt.Rows.Add(R)

        ds2.Tables.Add(dt)
        If ds.Tables.Count = 1 Then
            ds.Tables.Add(ds2.Tables(0).Copy)
        End If


        ' Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\BankFileReport")

        If CheckDataSet(ds) Then
            Utils.ShowReport("BankFileReport.rpt", ds, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If


    End Sub
End Class