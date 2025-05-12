Public Class FrmIR61_2019
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
        Dim DsDED As DataSet
        Dim DsCON As DataSet
        Dim DsCONPen As DataSet
        Dim DED As Double = 0
        Dim CON As Double = 0
        Dim dTax As Double = 0

        Dim DsDEDDirector As DataSet
        Dim DsCONDirector As DataSet



        Dim SIPeriod As cPrSsSocialInsPeriods
        SIPeriod = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Me.txtTaxMonth.Text = SIPeriod.DescriptionL

        Ds = Global1.Business.REPORT_IR61(PerGroup, SIPeriod)
        If CheckDataSet(Ds) Then
            Me.txtITAmount.Text = Format(DbNullToDouble(Ds.Tables(0).Rows(0).Item(0)), "0.00")
            dTax = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
        Else
            Me.txtITAmount.Text = "0.00"
            dTax = 0

        End If

        Dim DsTaxable As DataSet
        DsTaxable = Global1.Business.REPORT_IR61_GetTaxableIncome(PerGroup, SIPeriod)
        If CheckDataSet(DsTaxable) Then
            Me.txtTaxableIncome.Text = Format(DbNullToDouble(DsTaxable.Tables(0).Rows(0).Item(0)), "0.00")
            'dTax = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
        Else
            Me.txtTaxableIncome.Text = "0.00"
            'dTax = 0

        End If


        DsDED = Global1.Business.REPORT_IR61_Gesy_DEDUCTION(PerGroup, SIPeriod)
        If CheckDataSet(DsDED) Then
            Me.txtGesyDed.Text = Format(DbNullToDouble(DsDED.Tables(0).Rows(0).Item(0)), "0.00")
            DED = DbNullToDouble(DsDED.Tables(0).Rows(0).Item(0))
        Else
            Me.txtGesyDed.Text = "0.00"
            DED = 0
        End If

        DsCON = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION(PerGroup, SIPeriod)
        If CheckDataSet(DsCON) Then
            Me.txtGesyCon.Text = Format(DbNullToDouble(DsCON.Tables(0).Rows(0).Item(0)), "0.00")
            CON = DbNullToDouble(DsCON.Tables(0).Rows(0).Item(0))
        Else
            Me.txtGesyCon.Text = "0.00"
            CON = 0
        End If

        DsCONPen = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_LWBPen(PerGroup, SIPeriod)
        If CheckDataSet(DsCONPen) Then
            CON = CON + DbNullToDouble(DsCONPen.Tables(0).Rows(0).Item(0))
            Me.txtGesyCon.Text = Format(CON, "0.00")

        End If

        DsCONDirector = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_Directors(PerGroup, SIPeriod)
        If CheckDataSet(DsCONDirector) Then
            DED = DED + DbNullToDouble(DsCONDirector.Tables(0).Rows(0).Item(0))
            Me.txtGesyDed.Text = Format(DED, "0.00")

        End If

        DsDEDDirector = Global1.Business.REPORT_IR61_Gesy_DEDUCTION_Directors(PerGroup, SIPeriod)
        If CheckDataSet(DsDEDDirector) Then
            CON = CON + DbNullToDouble(DsDEDDirector.Tables(0).Rows(0).Item(0))
            Me.txtGesyCon.Text = Format(CON, "0.00")

        End If

        Dim TotalSpecialTax As Double = RoundMe3(DED + CON, 2)
        Me.txtTotal.Text = Format(dTax + TotalSpecialTax, "0.00")

        Dim Ar() As String
        Dim Ar1() As String
        Dim TAX As String

        TAX = txtTotal.Text

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
        ShowTheReport(False)
    End Sub
    Private Sub ShowTheReport(ByVal ToPrinter As Boolean)

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
        Dim Col_GesyDed As Integer = 10
        Dim Col_AWsp1 As Integer = 11
        Dim Col_AWsp2 As Integer = 12
        Dim Col_GrandTotal As Integer = 13
        Dim Col_AWG1 As Integer = 14
        Dim Col_AWG2 As Integer = 15

        Dim Col_GesyCon As Integer = 16
        Dim Col_AWsp11 As Integer = 17
        Dim Col_AWsp22 As Integer = 18


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
        '10
        dt.Columns.Add(New DataColumn("GesyDed", System.Type.GetType("System.Double")))
        '11
        dt.Columns.Add(New DataColumn("AWSP1", System.Type.GetType("System.String")))
        '12
        dt.Columns.Add(New DataColumn("AWSP2", System.Type.GetType("System.String")))
        '13
        dt.Columns.Add(New DataColumn("FinalTotal", System.Type.GetType("System.Double")))
        '14
        dt.Columns.Add(New DataColumn("AWFinal1", System.Type.GetType("System.String")))
        '15
        dt.Columns.Add(New DataColumn("AWFinal2", System.Type.GetType("System.String")))
        '16
        dt.Columns.Add(New DataColumn("GesyCon", System.Type.GetType("System.Double")))
        '17
        dt.Columns.Add(New DataColumn("AWSP11", System.Type.GetType("System.String")))
        '18
        dt.Columns.Add(New DataColumn("AWSP22", System.Type.GetType("System.String")))




        Dim FinalTotal As String = Me.txtTotal.Text
        Dim IT As String = Me.txtITAmount.Text

        Dim AWSP1 As String
        Dim AWSP2 As String

        Dim AWFinal1 As String
        Dim AWFinal2 As String

        Dim AWSP11 As String
        Dim AWSP22 As String



        ''Calculate Words for Gesy Deductions Total
        Dim Ar() As String
        Dim Ar1() As String
        Dim i As Integer
        Ar = Me.txtGesyDed.Text.Split(".")
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

        AWSP1 = Final1
        AWSP2 = Final2
        ''
        ''Calculate Words for IT

        Dim ArX() As String
        Dim Ar1X() As String
        k = 0
        Dim Final1x As String = ""
        Dim Final2x As String = ""
        Dim TempFinalx As String = ""

        ArX = Me.txtITAmount.Text.Split(".")

        Amount1 = Global1.Business.NumToWords(CInt(ArX(0)))
        Amount1 = UCase(Amount1) & " EURO "


        Amount2 = Global1.Business.NumToWords(CInt(ArX(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2

        If Amount1.Length > 40 Then
            Ar1X = Amount1.Split(" ")
            For i = 0 To Ar1X.Length - 1
                TempFinalx = TempFinalx & Ar1X(i) & " "
                If TempFinalx.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1x = TempFinalx
                End If
            Next
            For i = k To Ar1X.Length - 1
                Final2x = Final2x & Ar1X(i) & " "
            Next
        Else
            Final1x = Amount1
        End If

        AWFinal1 = Final1x
        AWFinal2 = Final2x
        ''

        ''Calculate Words for Gesy Contributions Total
        Dim ArY() As String
        Dim Ar1Y() As String
        k = 0
        Dim Final1Y As String = ""
        Dim Final2Y As String = ""
        Dim TempFinalY As String = ""

        ArY = Me.txtGesyCon.Text.Split(".")

        Amount1 = Global1.Business.NumToWords(CInt(ArY(0)))
        Amount1 = UCase(Amount1) & " EURO "


        Amount2 = Global1.Business.NumToWords(CInt(ArY(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2

        If Amount1.Length > 40 Then
            Ar1Y = Amount1.Split(" ")
            For i = 0 To Ar1Y.Length - 1
                TempFinalY = TempFinalY & Ar1Y(i) & " "
                If TempFinalY.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1Y = TempFinalY
                End If
            Next
            For i = k To Ar1Y.Length - 1
                Final2Y = Final2Y & Ar1Y(i) & " "
            Next
        Else
            Final1Y = Amount1
        End If

        AWSP11 = Final1Y
        AWSP22 = Final2Y






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
        R(Col_GesyDed) = Me.txtGesyDed.Text
        R(Col_AWsp1) = AWSP1
        R(Col_AWsp2) = AWSP2
        R(Col_GrandTotal) = Me.txtTotal.Text
        R(Col_AWG1) = AWFinal1
        R(Col_AWG2) = AWFinal2
        R(Col_GesyCon) = Me.txtGesyCon.Text
        R(Col_AWsp11) = AWSP11
        R(Col_AWsp22) = AWSP22




        dt.Rows.Add(R)

        '  Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\IR61")
        If CheckDataSet(Ds) Then
            Utils.ShowReport("IR61_2019.rpt", Ds, FrmReport, "CYPRUS MONTHLY INCOME TAX (Rpt 61)", ToPrinter)
        Else
            MsgBox("No records found")
        End If

    End Sub

    Private Sub CmbSIPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSIPeriod.SelectedIndexChanged
        If Loading Then Exit Sub

        Me.PanelLoading.Visible = True
        Application.DoEvents()
        IR61()
        Me.PanelLoading.Visible = False
        Application.DoEvents()
    End Sub

    Private Sub TSBSendToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSendToPrinter.Click
        ShowTheReport(True)
    End Sub

   
End Class