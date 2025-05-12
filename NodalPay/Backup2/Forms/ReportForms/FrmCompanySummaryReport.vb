Public Class FrmCompanySummaryReport
    Dim DsComp As DataSet
    Private Sub FrmCompanySummaryReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadComboCompanies()

    End Sub
    Private Sub LoadComboCompanies()
        Dim Ds As DataSet
        Ds = Global1.Business.GetAllCompaniesFullRow
        If CheckDataSet(Ds) Then
            Dim i As Integer
            Dim Com As New cAdMsCompany
            Me.ComboFromCompany.BeginUpdate()
            Me.ComboFromCompany.Items.Clear()

            Me.ComboToCompany.BeginUpdate()
            Me.ComboToCompany.Items.Clear()

            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Com = New cAdMsCompany(Ds.Tables(0).Rows(i))
                ComboFromCompany.Items.Add(Com)
                ComboToCompany.Items.Add(Com)
            Next

            ComboFromCompany.EndUpdate()
            ComboFromCompany.SelectedIndex = 0
            ComboToCompany.EndUpdate()
            ComboToCompany.SelectedIndex = 0

        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim FromCompany As String = ""
        Dim ToCompany As String = ""
        FromCompany = CType(Me.ComboFromCompany.SelectedItem, cAdMsCompany).Code
        ToCompany = CType(Me.ComboToCompany.SelectedItem, cAdMsCompany).Code


        Dim DsComEmp As DataSet
        DsComp = Global1.Business.GetAllCompaniesDetails(FromCompany, ToCompany)

        If CheckDataSet(DsComp) Then
            Dim i As Integer
            Dim k As Integer
            Dim Comp As String
            Dim EmpCode As String
            Dim Gross As Double = 0
            Dim CompTotal As Double = 0
            Dim employeecounter As Integer = 0
            Dim EmpSalary As New cPrTxEmployeeSalary
            For i = 0 To DsComp.Tables(0).Rows.Count - 1
                CompTotal = 0
                employeecounter = 0
                Comp = DbNullToString(DsComp.Tables(0).Rows(i).Item(0))
                DsComEmp = Global1.Business.GetAllEmployeesOfCompany(Comp)
                If CheckDataSet(DsComEmp) Then
                    For k = 0 To DsComEmp.Tables(0).Rows.Count - 1
                        employeecounter = employeecounter + 1
                        Gross = 0
                        EmpCode = DbNullToString(DsComEmp.Tables(0).Rows(k).Item(0))
                        EmpSalary = Global1.Business.GetCurrentSalary(EmpCode, Now.Date)
                        Gross = EmpSalary.SalaryValue
                        CompTotal = CompTotal + Gross
                    Next
                    DsComp.Tables(0).Rows(i).Item(10) = employeecounter
                    DsComp.Tables(0).Rows(i).Item(11) = RoundMe2(CompTotal, 2)
                End If
            Next
        Else
            MsgBox("No employees found!", MsgBoxStyle.Information)
        End If
        DG1.DataSource = DsComp.Tables(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer

        HeaderStr.Add("Code")
        HeaderStr.Add("Company Name")
        HeaderStr.Add("TIC Number")
        HeaderStr.Add("SI Registration Number")
        HeaderStr.Add("Address Line1")
        HeaderStr.Add("Address Line2")
        HeaderStr.Add("Address Line3")
        HeaderStr.Add("Address Line4")
        HeaderStr.Add("Phone 1")
        HeaderStr.Add("Phone 2")
        HeaderStr.Add("Number of Employees")
        HeaderStr.Add("Total Gross")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)


        Loader.LoadIntoExcel(DsComp, HeaderStr, HeaderSize)


    End Sub
End Class