Public Class FrmPaymentRequest
    Public DS As DataSet
    Public RefNo As String
    Public AmountA As Double
    Public AmountB As Double
    Public ReportSelection As Integer

   
    Private Sub TSBReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBReport.Click
        Dim Ac_A_Desc As String = ""
        Dim Ac_B_Desc As String = ""

        Dim dsParam As DataSet
        dsParam = Global1.Business.GetParameter("PF", "ADesc")
        If CheckDataSet(dsParam) Then
            Dim Par As New cPrSsParameters(dsParam.Tables(0).Rows(0))
            Ac_A_Desc = Par.Value1
        Else
            Ac_A_Desc = "Provident Fund A/C A"
        End If
        dsParam = Global1.Business.GetParameter("PF", "BDesc")
        If CheckDataSet(dsParam) Then
            Dim Par As New cPrSsParameters(dsParam.Tables(0).Rows(0))
            Ac_B_Desc = Par.Value1
        Else
            Ac_B_Desc = "Provident Fund A/C B"
        End If


        'DS = New DataSet
        If DS.Tables.Count - 1 = 1 Then
            DS.Tables.Remove("HeadDetails")

        End If
        Dim R As DataRow

        Dim C_Company As Integer = 0
        Dim C_Bank As Integer = 1
        Dim C_Account As Integer = 2
        Dim C_BankRepr As Integer = 3
        Dim C_PayDate As Integer = 4
        Dim C_Fax As Integer = 5
        Dim C_KeyTest As Integer = 6
        Dim C_Swift As Integer = 7
        Dim C_SubNo As Integer = 8
        Dim C_IBAN As Integer = 9
        Dim C_Accountant As Integer = 10
        Dim C_Admin As Integer = 11
        Dim C_PFAAccount As Integer = 12
        Dim C_PFBAccount As Integer = 13
        Dim C_PFAAmount As Integer = 14
        Dim C_PFBAmount As Integer = 15
        Dim C_Total As Integer = 16
        Dim C_RefNo As Integer = 17
        Dim C_ADesc As Integer = 18
        Dim C_BDesc As Integer = 19


        ' Define Data Table
        Dim dt As New DataTable

        dt = New DataTable("HeadDetails")
        '0
        dt.Columns.Add(New DataColumn("Company", System.Type.GetType("System.String")))
        '1
        dt.Columns.Add(New DataColumn("Bank", System.Type.GetType("System.String")))
        '2
        dt.Columns.Add(New DataColumn("Account", System.Type.GetType("System.String")))
        '3
        dt.Columns.Add(New DataColumn("BankRepr", System.Type.GetType("System.String")))
        '4
        dt.Columns.Add(New DataColumn("PayDate", System.Type.GetType("System.String")))
        '5
        dt.Columns.Add(New DataColumn("Fax", System.Type.GetType("System.String")))
        '6
        dt.Columns.Add(New DataColumn("KeyTest", System.Type.GetType("System.String")))
        '7
        dt.Columns.Add(New DataColumn("SWIFT", System.Type.GetType("System.String")))
        '8
        dt.Columns.Add(New DataColumn("SubNo", System.Type.GetType("System.String")))
        '9
        dt.Columns.Add(New DataColumn("IBAN", System.Type.GetType("System.String")))
        '10
        dt.Columns.Add(New DataColumn("Accountant", System.Type.GetType("System.String")))
        '11
        dt.Columns.Add(New DataColumn("Admin", System.Type.GetType("System.String")))
        '12
        dt.Columns.Add(New DataColumn("PFAAccount", System.Type.GetType("System.String")))
        '13
        dt.Columns.Add(New DataColumn("PFBAccount", System.Type.GetType("System.String")))
        '14
        dt.Columns.Add(New DataColumn("PFAAmount", System.Type.GetType("System.Double")))
        '15
        dt.Columns.Add(New DataColumn("PFBAmount", System.Type.GetType("System.Double")))
        '16
        dt.Columns.Add(New DataColumn("Total", System.Type.GetType("System.Double")))
        '17
        dt.Columns.Add(New DataColumn("RefNo", System.Type.GetType("System.String")))
        '18
        dt.Columns.Add(New DataColumn("PFAAccountDesc", System.Type.GetType("System.String")))
        '19
        dt.Columns.Add(New DataColumn("PFBAccountDesc", System.Type.GetType("System.String")))



        Dim ds2 As New DataSet

        If CheckDataSet(DS) Then
            Dim i As Integer
            Dim Total As Double
            For i = 0 To DS.Tables(0).Rows.Count - 1
                Total = Total + DS.Tables(0).Rows(i).Item(2)
            Next
            If Me.CBIncludePF.CheckState = CheckState.Unchecked Then
                AmountA = 0
                AmountB = 0
            End If

            Total = Total + AmountA + AmountB


            R = dt.NewRow
            R(C_Company) = Me.txtCompany.Text
            R(C_Bank) = Me.txtBank.Text
            R(C_Account) = Me.txtBankAccount.Text
            R(C_BankRepr) = Me.txtBankRepresentative.Text
            R(C_PayDate) = Me.txtDate.Text
            R(C_Fax) = Me.txtFax.Text
            R(C_KeyTest) = Me.txtKeyTest.Text
            R(C_Swift) = Me.txtSwift.Text
            R(C_SubNo) = Me.txtSubscriberNo.Text
            R(C_IBAN) = Me.txtIBAN.Text
            R(C_Accountant) = Me.txtAccountant.Text
            R(C_Admin) = Me.txtAdministrator.Text
            R(C_PFAAccount) = txtAccountA.Text
            R(C_PFBAccount) = txtAccountB.Text
            R(C_PFAAmount) = AmountA
            R(C_PFBAmount) = AmountB
            R(C_Total) = Total
            R(C_RefNo) = RefNo
            R(C_Adesc) = Ac_A_Desc
            R(C_BDesc) = Ac_B_Desc


            dt.Rows.Add(R)

            ds2.Tables.Add(dt)

            DS.Tables.Add(ds2.Tables(0).Copy)

            ' Utils.WriteSchemaWithXmlTextWriter(DS, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PaymentRequest")
            If ReportSelection = 1 Then
                Utils.ShowReport("PayRequest.rpt", DS, FrmReport, "Payment Request", False)
            ElseIf ReportSelection = 2 Then
                Utils.ShowReport("PayRequest2.rpt", DS, FrmReport, "Payment Request", False)
            End If
        Else
            MsgBox("No records found", MsgBoxStyle.Information)
        End If
    End Sub

    
    Private Sub FrmPaymentRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CBIncludePF.Checked = True
    End Sub
End Class