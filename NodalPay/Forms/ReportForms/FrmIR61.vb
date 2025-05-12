Public Class FrmIR61
    Public PerGroup As New cPrMsPeriodGroups
    Public TempGroupCode As String
    Dim Loading As Boolean = True
    Private Sub FrmIR61_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSIPeriods()
        IR61()
        Dim TemGrp As New cPrMsTemplateGroup(TempGroupCode)

        Dim C As New cAdMsCompany(TemGrp.CompanyCode)
        Me.txtTAXId.Text = C.TIC
        Me.txtCompName.Text = C.Name
        Me.txtAdr1.Text = C.Address1 & " " & C.Address2
        Me.txtAdr2.Text = C.Address3 & " " & C.Address4
        Me.txtTaxYear.Text = PerGroup.Year




    End Sub
    Private Sub LoadSIPeriods()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSocialInsPeriods()
        With Me.CmbSIPeriod
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrSsSocialInsPeriods(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        loading = False
    End Sub
    Private Sub IR61()
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim dsEmp As DataSet
        Dim Ds As DataSet


        Dim SIPeriod As cPrSsSocialInsPeriods
        SIPeriod = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Me.txtTaxMonth.Text = SIPeriod.DescriptionL

        Ds = Global1.Business.REPORT_IR61(PerGroup, SIPeriod)
        Me.txtITAmount.Text = Format(DbNullToDouble(Ds.Tables(0).Rows(0).Item(0)), "0.00")

        Dim Ar() As String
        Dim Ar1() As String
        Dim TAX As String
        TAX = Format(DbNullToDouble(Ds.Tables(0).Rows(0).Item(0)), "0.00")
        Ar = TAX.Split(".")
        Dim Amount1 As String
        Amount1 = Global1.Business.NumToWords(CInt(Ar(0)))
        Amount1 = UCase(Amount1) & " EURO "

        Dim Amount2 As String
        Amount2 = Global1.Business.NumToWords(CInt(Ar(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2
        Dim k As Integer
        Dim Final1 As String = ""
        Dim Final2 As String = ""
        Dim TempFinal As String = ""
        If Amount1.Length > 40 Then
            Ar1 = Amount1.Split(" ")
            For i = 0 To Ar1.Length - 1
                TempFinal = TempFinal & Ar1(i) & " "
                If TempFinal.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1 = TempFinal
                End If
            Next
            For i = k To Ar1.Length - 1
                Final2 = Final2 & Ar1(i) & " "
            Next
        Else
            Final1 = Amount1
        End If

        Me.txtAIW1.Text = Final1
        Me.txtAIW2.Text = Final2

        Me.Cursor = Cursors.Default


    End Sub

   
    Private Sub TSBReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBReport.Click

        '  MsgBox("Please Put a formal Monthly Income Tax Document in Printer Tray and Click OK", MsgBoxStyle.Information)

        Dim Ds As New DataSet
        Dim Col_TAXId As Integer = 0
        Dim Col_CompanyName As Integer = 1
        Dim Col_Adr1 As Integer = 2
        Dim Col_Adr2 As Integer = 3
        Dim Col_Amount As Integer = 4
        Dim Col_ChequeNo As Integer = 5
        Dim Col_Year As Integer = 6
        Dim Col_Month As Integer = 7
        Dim Col_AW1 As Integer = 8
        Dim Col_AW2 As Integer = 9


        Dim dt As New DataTable

        dt = New DataTable("TAX")
        '0
        dt.Columns.Add(New DataColumn("TAXId", System.Type.GetType("System.String")))
        '1
        dt.Columns.Add(New DataColumn("CompanyName", System.Type.GetType("System.String")))
        '2
        dt.Columns.Add(New DataColumn("Adr1", System.Type.GetType("System.String")))
        '3
        dt.Columns.Add(New DataColumn("Adr2", System.Type.GetType("System.String")))
        '4
        dt.Columns.Add(New DataColumn("TaxAmount", System.Type.GetType("System.Double")))
        '5
        dt.Columns.Add(New DataColumn("ChequeNo", System.Type.GetType("System.String")))
        '6
        dt.Columns.Add(New DataColumn("YEAR", System.Type.GetType("System.String")))
        '7
        dt.Columns.Add(New DataColumn("Month", System.Type.GetType("System.String")))
        '8
        dt.Columns.Add(New DataColumn("AW", System.Type.GetType("System.String")))
        '9
        dt.Columns.Add(New DataColumn("AW2", System.Type.GetType("System.String")))


        Ds.Tables.Add(dt)
        Dim R As DataRow

        R = dt.NewRow
        R(Col_TAXId) = Me.txtTAXId.Text
        R(Col_CompanyName) = Me.txtCompName.Text
        R(Col_Adr1) = Me.txtAdr1.Text
        R(Col_Adr2) = Me.txtAdr2.Text
        R(Col_Amount) = Me.txtITAmount.Text
        R(Col_ChequeNo) = Me.txtChequeNo.Text
        R(Col_Year) = Me.txtTaxYear.Text
        R(Col_Month) = Me.txtTaxMonth.Text
        R(Col_AW1) = Me.txtAIW1.Text
        R(Col_AW2) = Me.txtAIW2.Text
        dt.Rows.Add(R)

        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR61")
        If CheckDataSet(Ds) Then
            Utils.ShowReport("IR61Nodal.rpt", Ds, FrmReport, "CYPRUS MONTHLY INCOME TAX (Rpt 61)", False)
        Else
            MsgBox("No records found")
        End If

    End Sub

    Private Sub CmbSIPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSIPeriod.SelectedIndexChanged
        If loading Then Exit Sub
        IR61()
    End Sub
End Class