Public Class FrmFiTrxnHeader
    Public GlbTrxnType As String
    Public GlbTrxnTypeFactor As Integer

    Public GLBEnableAllocation As Boolean
    Public GLBDisableVAT As Boolean
    Public GLBDisableDiscounts As Boolean
    Public GLBDisableDueDate As Boolean
    Public GLBDisableOverAllDiscount As Boolean

    Dim GlbHeader As New cFiTrxnHeader
    Dim GLBTrxGroupCode As String
    Dim GLBTrxCodesDS As DataSet
    Dim GLBCurenciesDs As DataSet
    Dim GLBVatDs As DataSet
    Dim GLBCreditProfile As New cCreditProfiles

    Dim GlbFactor As Integer = 1
    Dim GlbDsAlloc As DataSet

    Dim GLB_IsVATIncluded As Boolean = False
    Dim GLB_IsVATEnabled As Boolean = False
    Dim GLB_IsReversed As Boolean = False

    Dim GLBBusPrt As New cBusinessPartner
    Dim GLBAnl1 As DataSet
    Dim GLBAnl2 As DataSet
    Dim GLBAnl3 As DataSet
    Dim GLBAnl4 As DataSet
    Dim GLBAnl5 As DataSet
    Dim GLBAnl6 As DataSet
    Dim GLBAnl7 As DataSet
    Dim GLBAnl8 As DataSet
    Dim GLBAnl9 As DataSet
    Dim GLBAnl10 As DataSet

    Dim MyDs As DataSet
    Dim Dt1 As DataTable
    '''''''''''''''''''''''''''''''''''''
    Dim AllocCol_Id As Integer = 0
    Dim AllocCol_JouLineNo As Integer = 1
    Dim AllocCol_DocDate As Integer = 2
    Dim AllocCol_UnAllocBalanceLC As Integer = 3
    Dim AllocCol_AlphaCode As Integer = 4
    Dim AllocCol_UnAllocBalanceTC As Integer = 5
    Dim AllocCol_Selected As Integer = 6
    Dim AllocCol_Amount As Integer = 7
    ''' '''''''''''''''''''''''''''''''''
    
    Dim Col_LineNo As Integer = 0
    Dim Col_HdrId As Integer = 1
    Dim Col_AccCode As Integer = 2
    Dim Col_AccDesc As Integer = 3
    Dim Col_Amount As Integer = 4
    Dim Col_Gross As Integer = 5
    Dim Col_LineDiscPerc As Integer = 6
    Dim Col_LineDisc As Integer = 7
    Dim Col_LineDiscVAT As Integer = 8
    Dim Col_OverAllDisc As Integer = 9
    Dim Col_OverAllDiscVAT As Integer = 10
    Dim Col_LineTotal As Integer = 11
    Dim Col_LineTotalVAT As Integer = 12
    Dim Col_LineTotalLocal As Integer = 13
    Dim Col_LineTotalVATLocal As Integer = 14
    Dim Col_VATCode As Integer = 15
    Dim Col_VATRate As Integer = 16
    Dim Col_Comments As Integer = 17
    Dim Col_AcLAn1Code As Integer = 18
    Dim Col_AcLAn2Code As Integer = 19
    Dim Col_AcLAn3Code As Integer = 20
    Dim Col_AcLAn4Code As Integer = 21
    Dim Col_AcLAn5Code As Integer = 22
    Dim Col_AcLAn6Code As Integer = 23
    Dim Col_AcLAn7Code As Integer = 24
    Dim Col_AcLAn8Code As Integer = 25
    Dim Col_AcLAn9Code As Integer = 26
    Dim Col_AcLAn10Code As Integer = 27
    Dim Col_VatComboDesc As Integer = 28


    Dim CurrentRow As Integer = 0
    Dim DoNotVisitNow As Boolean = False
    Dim Allocating As Boolean = False

    Dim OriginalDiscount As Double
    Dim GLBOverAllDiscountPerc As Double
    Dim DoNotExecute As Boolean = False
    Private Sub DisableDiscounts()
        If GLBDisableDiscounts Then
            Me.txtOverAllDisc.Visible = False
            Me.txtOverAllDiscount2.Visible = False
            Me.btnOverAllDisc.Visible = False
            Me.txtLineDisc.Visible = False
            Me.LblLineDisc.Visible = False
        End If
    End Sub
    Private Sub DisableOverAlldiscount()
        If GLBDisableOverAllDiscount Then
            Me.txtOverAllDisc.Visible = False
            Me.txtOverAllDiscount2.Visible = False
            Me.btnOverAllDisc.Visible = False
        End If
    End Sub
    Private Sub DisableDueDate()
        If GLBDisableDueDate Then
            Me.MSKTxtDueDate.Visible = False
            lblDueDate.Visible = False
        End If
    End Sub
    Private Sub DisableVAT()
        If GLBDisableVAT Then
            Dim VAT As New cVat("$")
            If VAT.Code <> "" Then
                Me.ComboVAT.SelectedIndex = ComboVAT.FindStringExact(VAT.ToString)
            End If
            Me.ComboVAT.Enabled = False
            Me.txtVATRate.Text = "0.00"
            Me.CBVatEnabled.CheckState = CheckState.Unchecked
            Me.CBVatIncluded.CheckState = CheckState.Unchecked
        End If
    End Sub
    Private Sub EnableAllocation()
        Me.GBAllocation.Visible = GLBEnableAllocation
        Me.btnAllocDispl.Visible = GLBEnableAllocation
        Me.txtAllocTotalAmount.Visible = GLBEnableAllocation
        Me.btnBusCur.Visible = GLBEnableAllocation
    End Sub
    Private Sub FrmTrxnHeader_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitDataTable()
        InitDataGrid()
        LoadAnalysis()
        LoadCurencies()
        LoadVAT()
        InitDecimalValueFields()
        ClearHeader()
        ClearLines()
        Me.CBAllocated.CheckState = CheckState.Checked
        EnableAllocation()
        DisableVAT()
        DisableDueDate()
        DisableDiscounts()
        DisableOverAlldiscount()
    End Sub
    Private Sub ClearHeader()
        GlbHeader = New cFiTrxnHeader
        Me.GlbDsAlloc = New DataSet
        ClearHeaderErrors()
        Me.GBMain.Enabled = True
        Me.GBDetails.Enabled = True
        Me.txtAllocTotalAmount.Text = "0.00"
        Me.txtBusPartnerCode.Text = ""
        Me.txtBusPartnerDesc.Text = ""
        Me.ComboTrxnCode.Text = ""
        Me.ComboTrxnCode.Enabled = False
        Me.MSKTxtPostDate.Text = Format(Now.Date, ("dd/MM/yyyy"))
        Me.MSKTxtInvDate.Text = Format(Now.Date, ("dd/MM/yyyy"))
        'Temp
        Me.MSKTxtDueDate.Text = ""
        '
        Me.txtOverAllDisc.Text = "0.00"
        Me.txtRefNo.Text = ""
        Me.txtXRefNo.Text = ""
        Me.txtAcctRefNo.Text = ""
        Me.txtCurRate.Text = "0.00"
        Me.txtAmendBy.Text = Global1.UserName
        Me.txtCreatedBy.Text = Global1.UserName
    End Sub
    Private Sub ClearLines()
        Me.txtAccountCode.Text = ""
        Me.txtAccountDesc.Text = ""
        Me.txtAmount.Text = "0.00"
        Me.txtLineDisc.Text = "0.00"
        Me.txtComment.Text = ""
        Dim Acc As New cAccount
        Me.FixAnalysis(acc)
    End Sub
    Private Sub ClearGrid()
        CurrentRow = 0
        If CheckDataSet(MyDs) Then
            MyDs.Tables(0).Rows.Clear()
        End If
    End Sub
    Private Sub InitDecimalValueFields()
        AddHandler txtAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtAmount.Leave, AddressOf NumericOnLeave

        AddHandler txtLineDisc.KeyPress, AddressOf NumericKeyPress
        AddHandler txtLineDisc.Leave, AddressOf NumericOnLeave

        AddHandler txtOverAllDisc.KeyPress, AddressOf NumericKeyPress
        AddHandler txtOverAllDisc.Leave, AddressOf NumericOnLeave

        AddHandler txtCurRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtCurRate.Leave, AddressOf NumericOnLeave

    End Sub

    Private Sub LoadCurencies()
        Dim C As New cAdMsCurrency
        Dim i As Integer

        GLBCurenciesDs = Global1.Business.GetAllCurrencies()
        If CheckDataSet(GLBCurenciesDs) Then
            With Me.ComboCurency
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To GLBCurenciesDs.Tables(0).Rows.Count - 1
                    C = New cAdMsCurrency(GLBCurenciesDs.Tables(0).Rows(i))
                    .Items.Add(C)
                Next
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadTrxnCodes(ByVal InvoiceType As String)
        Dim i As Integer
        If Me.GlbTrxnType = Global1.FI_TrxnType_PAYMENTS Then
            InvoiceType = "N"
        End If
        If Me.GlbTrxnType = Global1.FI_TrxnType_RECEIPTS Then
            InvoiceType = "N"
        End If
        If Me.GlbTrxnType = Global1.FI_TrxnType_CUSTOMER_ADJ Then
            InvoiceType = "N"
        End If
        If Me.GlbTrxnType = Global1.FI_TrxnType_SUPPLIER_ADJ Then
            InvoiceType = "N"
        End If

        GLBTrxCodesDS = Global1.Business.GetAllFiTrxnCodesByTrxnTypeByInvType(GlbTrxnType, InvoiceType)
        With Me.ComboTrxnCode
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(GLBTrxCodesDS) Then
                For i = 0 To GLBTrxCodesDS.Tables(0).Rows.Count - 1
                    Dim C As New cFiTrxnCodes(GLBTrxCodesDS.Tables(0).Rows(i))
                    .Items.Add(C)
                Next
                Me.ComboTrxnCode.Enabled = True
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadVAT()
        Dim C As New cVat
        Dim i As Integer

        GLBVatDs = Global1.Business.GetAllVats(True)
        If CheckDataSet(GLBVatDs) Then
            With Me.ComboVAT
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To GLBVatDs.Tables(0).Rows.Count - 1
                    C = New cVat(GLBVatDs.Tables(0).Rows(i))
                    .Items.Add(C)
                Next
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAnalysis()
        LoadAnalysis1()
        LoadAnalysis2()
        LoadAnalysis3()
        LoadAnalysis4()
        LoadAnalysis5()
        LoadAnalysis6()
        LoadAnalysis7()
        LoadAnalysis8()
        LoadAnalysis9()
        LoadAnalysis10()
        
    End Sub
    Private Sub LoadAnalysis1()
        Dim i As Integer
        With Me.ComboAnl1
            .BeginUpdate()
            .Items.Clear()
            GLBAnl1 = Global1.Business.GetAllAccountLineAnalysisLevel1(1, True)
            If CheckDataSet(GLBAnl1) Then
                For i = 0 To GLBAnl1.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal1(GLBAnl1.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis2()
        Dim i As Integer
        With Me.ComboAnl2
            .BeginUpdate()
            .Items.Clear()
            GLBAnl2 = Global1.Business.GetAllAccountLineAnalysisLevel1(2, True)
            If CheckDataSet(GLBAnl2) Then
                For i = 0 To GLBAnl2.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal2(GLBAnl2.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis3()
        Dim i As Integer
        With Me.ComboAnl3
            .BeginUpdate()
            .Items.Clear()
            GLBAnl3 = Global1.Business.GetAllAccountLineAnalysisLevel1(3, True)
            If CheckDataSet(GLBAnl3) Then
                For i = 0 To GLBAnl3.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal3(GLBAnl3.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis4()
        Dim i As Integer
        With Me.ComboAnl4
            .BeginUpdate()
            .Items.Clear()
            GLBAnl4 = Global1.Business.GetAllAccountLineAnalysisLevel1(4, True)
            If CheckDataSet(GLBAnl4) Then
                For i = 0 To GLBAnl4.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal4(GLBAnl4.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis5()
        Dim i As Integer
        With Me.ComboAnl5
            .BeginUpdate()
            .Items.Clear()
            GLBAnl5 = Global1.Business.GetAllAccountLineAnalysisLevel1(5, True)
            If CheckDataSet(GLBAnl5) Then
                For i = 0 To GLBAnl5.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal5(GLBAnl5.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis6()
        Dim i As Integer
        With Me.ComboAnl6
            .BeginUpdate()
            .Items.Clear()
            GLBAnl6 = Global1.Business.GetAllAccountLineAnalysisLevel1(6, True)
            If CheckDataSet(GLBAnl6) Then
                For i = 0 To GLBAnl6.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal6(GLBAnl6.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis7()
        Dim i As Integer
        With Me.ComboAnl7
            .BeginUpdate()
            .Items.Clear()
            GLBAnl7 = Global1.Business.GetAllAccountLineAnalysisLevel1(7, True)
            If CheckDataSet(GLBAnl7) Then
                For i = 0 To GLBAnl7.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal7(GLBAnl7.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis8()
        Dim i As Integer
        With Me.ComboAnl8
            .BeginUpdate()
            .Items.Clear()
            GLBAnl8 = Global1.Business.GetAllAccountLineAnalysisLevel1(8, True)
            If CheckDataSet(GLBAnl8) Then
                For i = 0 To GLBAnl8.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal8(GLBAnl8.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis9()
        Dim i As Integer
        With Me.ComboAnl9
            .BeginUpdate()
            .Items.Clear()
            GLBAnl9 = Global1.Business.GetAllAccountLineAnalysisLevel1(9, True)
            If CheckDataSet(GLBAnl9) Then
                For i = 0 To GLBAnl9.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal9(GLBAnl9.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis10()
        Dim i As Integer
        With Me.ComboAnl10
            .BeginUpdate()
            .Items.Clear()
            GLBAnl10 = Global1.Business.GetAllAccountLineAnalysisLevel1(10, True)
            If CheckDataSet(GLBAnl10) Then
                For i = 0 To GLBAnl10.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal10(GLBAnl10.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        Dg1.DataSource = MyDs.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("LineNo", System.Type.GetType("System.Int32"))
        '1
        Dt1.Columns.Add("HdrId", System.Type.GetType("System.Int32"))
        '2
        Dt1.Columns.Add("AccCode", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("AccDesc", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Amount", System.Type.GetType("System.Double"))
        '5
        Dt1.Columns.Add("Gross", System.Type.GetType("System.Double"))
        '6
        Dt1.Columns.Add("LineDiscPerc", System.Type.GetType("System.Double"))
        '7
        Dt1.Columns.Add("LineDisc", System.Type.GetType("System.Double"))
        '8
        Dt1.Columns.Add("LineDiscVAT", System.Type.GetType("System.Double"))
        '9
        Dt1.Columns.Add("OverAllDisc", System.Type.GetType("System.Double"))
        '10
        Dt1.Columns.Add("OverAllDiscVAT", System.Type.GetType("System.Double"))
        '11
        Dt1.Columns.Add("LineTotal", System.Type.GetType("System.Double"))
        '12
        Dt1.Columns.Add("LineTotalVAT", System.Type.GetType("System.Double"))
        '13
        Dt1.Columns.Add("LineTotalLocal", System.Type.GetType("System.Double"))
        '14
        Dt1.Columns.Add("LineTotalLocalVAT", System.Type.GetType("System.Double"))
        '15
        Dt1.Columns.Add("VATCode", System.Type.GetType("System.String"))
        '16
        Dt1.Columns.Add("VATRate", System.Type.GetType("System.Double"))
        '17
        Dt1.Columns.Add("Comments", System.Type.GetType("System.String"))
        '18
        Dt1.Columns.Add("AcLAn1Code", System.Type.GetType("System.String"))
        '19
        Dt1.Columns.Add("AcLAn2Code", System.Type.GetType("System.String"))
        '20
        Dt1.Columns.Add("AcLAn3Code", System.Type.GetType("System.String"))
        '21
        Dt1.Columns.Add("AcLAn4Code", System.Type.GetType("System.String"))
        '22
        Dt1.Columns.Add("AcLAn5Code", System.Type.GetType("System.String"))
        '23
        Dt1.Columns.Add("AcLAn6Code", System.Type.GetType("System.String"))
        '24
        Dt1.Columns.Add("AcLAn7Code", System.Type.GetType("System.String"))
        '25
        Dt1.Columns.Add("AcLAn8Code", System.Type.GetType("System.String"))
        '26
        Dt1.Columns.Add("AcLAn9Code", System.Type.GetType("System.String"))
        '27
        Dt1.Columns.Add("AcLAn10Code", System.Type.GetType("System.String"))
        '28
        Dt1.Columns.Add("ComboVatDesc", System.Type.GetType("System.String"))

    End Sub
    Private Sub txtBusPartnerCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusPartnerCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            LoadBusinessPartner(Me.txtBusPartnerCode.Text)
        End If
    End Sub
    Private Sub txtBusPartnerCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBusPartnerCode.Validated
        LoadBusinessPartner(Me.txtBusPartnerCode.Text)
    End Sub
    Public Sub LoadBusinessPartner(ByVal Code As String)
        GLBBusPrt = New cBusinessPartner(Code)
        If GLBBusPrt.Code <> "" Then
            Me.ComboCurency.Enabled = True
            FindVATEnabledVATIncluded()
            Me.txtBusPartnerCode.Text = GLBBusPrt.Code
            Me.txtBusPartnerDesc.Text = GLBBusPrt.DescL
            Err1.SetError(Me.txtBusPartnerCode, "")

            'Currency Selection And Currency Rate
            ''''''''''''''''''''''''''''''''''''''''
            DoNotExecute = True
            Dim C As New cAdMsCurrency(GLBBusPrt.CurAlphaCode)
            If C.AlphaCode <> "" Then
                Me.ComboCurency.SelectedIndex = Me.ComboCurency.FindStringExact(C.ToString)
                Me.btnBusCur.Text = GLBBusPrt.CurAlphaCode
            Else
                C = New cAdMsCurrency(Global1.LocalCurencyCode)
                Me.ComboCurency.SelectedIndex = Me.ComboCurency.FindStringExact(C.ToString)
                Me.btnBusCur.Text = C.AlphaCode
            End If
            DoNotExecute = False
            '''''''''''''''''''''''''''''''''''''''''
            Me.FindCurrencyRate()

            If GLBBusPrt.CurAlphaCode <> Global1.LocalCurencyCode Then
                Me.ComboCurency.Focus()
            End If
            GLBCreditProfile = New cCreditProfiles(GLBBusPrt.CreditProfileCode)
            If GLBCreditProfile.Code <> "" Then
                Me.LoadTrxnCodes(GLBCreditProfile.InvoiceType)
            Else
                Me.ComboTrxnCode.Enabled = False
                Me.ComboTrxnCode.Text = ""
            End If

        Else
            Me.ComboCurency.Enabled = False
            Me.txtBusPartnerDesc.Text = ""
            Err1.SetError(Me.txtBusPartnerCode, "Invalid Business Partner Code")
        End If
        CalculateDueDate()
    End Sub
    Private Sub btnBusPrtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusPrtSearch.Click
        Dim F As New FrmSearchBusPartner
        F.Owner = Me

        '''''''''''''''''CUSTOMERS - BOTH'''''''''''''''''''''''
        If Me.GlbTrxnType = Global1.FI_TrxnType_SALES Then
            F.ShowOnlyCustomer = True
            F.ShowOnlySuplier = False
        ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_RECEIPTS Then
            F.ShowOnlyCustomer = True
            F.ShowOnlySuplier = False
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''SUPPLIERS - BOTH'''''''''''''''''''''''
        If Me.GlbTrxnType = Global1.FI_TrxnType_PURCHASES Then
            F.ShowOnlyCustomer = False
            F.ShowOnlySuplier = True
        ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_PAYMENTS Then
            F.ShowOnlyCustomer = False
            F.ShowOnlySuplier = True
        End If

        If Me.GlbTrxnType = Global1.FI_TrxnType_CUSTOMER_ADJ Then
            F.ShowOnlyCustomer = True
            F.ShowOnlySuplier = False
        ElseIf Me.GlbTrxnType = Global1.FI_TrxnType_SUPPLIER_ADJ Then
            F.ShowOnlyCustomer = False
            F.ShowOnlySuplier = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        F.CalledBy = 3
        F.ShowDialog()

    End Sub
    Private Sub btnAccountSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountSearch.Click
        Dim F As New FrmAccountFINSearch
        F.Owner = Me
        F.CalledBy = 2
        F.Show()
    End Sub

    Private Sub txtAccountCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            FindAccount()
        End If
    End Sub
    Private Sub txtAccountCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.Validated
        FindAccount()
    End Sub
    Public Sub FindAccount()
        Dim Acc As New cAccount
        If Me.txtAccountCode.Text <> "" Then
            Acc = New cAccount(Trim(Me.txtAccountCode.Text))
            If Acc.Code <> "" Then
                Me.txtAccountDesc.Text = Acc.DescriptionL
                Err2.SetError(Me.txtAccountCode, "")
                Me.txtAmount.Text = "0.00"
                Me.txtLineDisc.Text = "0.00"
                Me.ComboVAT.SelectedIndex = 0
                Me.txtComment.Text = ""
                Me.txtAmount.Focus()
                Me.txtAmount.SelectAll()
            Else
                Me.txtAccountDesc.Text = ""
                Err2.SetError(Me.txtAccountCode, "Invalid Account Code")
                Me.txtAmount.Text = "0.00"
                Me.txtLineDisc.Text = "0.00"
                Me.ComboVAT.SelectedIndex = 0
                Me.txtComment.Text = ""
            End If
        Else
            Me.btnAccountSearch.Focus()
        End If
       
        FixAnalysis(Acc)
    End Sub
    Private Sub FixAnalysis(ByVal Acc As cAccount)
        If Acc.Code = "" Then
            Me.LblAn1.Enabled = False
            Me.LblAn2.Enabled = False
            Me.LblAn3.Enabled = False
            Me.LblAn4.Enabled = False
            Me.LblAn5.Enabled = False
            Me.LblAn6.Enabled = False
            Me.LblAn7.Enabled = False
            Me.LblAn8.Enabled = False
            Me.LblAn9.Enabled = False
            Me.LblAn10.Enabled = False

            Me.ComboAnl1.Enabled = False
            Me.ComboAnl2.Enabled = False
            Me.ComboAnl3.Enabled = False
            Me.ComboAnl4.Enabled = False
            Me.ComboAnl5.Enabled = False
            Me.ComboAnl6.Enabled = False
            Me.ComboAnl7.Enabled = False
            Me.ComboAnl8.Enabled = False
            Me.ComboAnl9.Enabled = False
            Me.ComboAnl10.Enabled = False

            Try
                Me.ComboAnl1.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl2.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl3.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl4.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl5.SelectedIndex = 0
            Catch ex As Exception

            End Try

            Try
                Me.ComboAnl6.SelectedIndex = 0
            Catch ex As Exception

            End Try

            Try
                Me.ComboAnl7.SelectedIndex = 0
            Catch ex As Exception

            End Try

            Try
                Me.ComboAnl8.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl9.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Try
                Me.ComboAnl10.SelectedIndex = 0
            Catch ex As Exception

            End Try
        Else
            Dim Ds As DataSet
            Ds = Global1.Business.GetWhatAnalysisToUse(Acc.TAnGrpCode)
            If CheckDataSet(Ds) Then
                Me.LblAn1.Enabled = CheckDataRowForanalysis(Ds, 1)
                Me.ComboAnl1.Enabled = CheckDataRowForanalysis(Ds, 1)

                Me.LblAn2.Enabled = CheckDataRowForanalysis(Ds, 2)
                Me.ComboAnl2.Enabled = CheckDataRowForanalysis(Ds, 2)

                Me.LblAn3.Enabled = CheckDataRowForanalysis(Ds, 3)
                Me.ComboAnl3.Enabled = CheckDataRowForanalysis(Ds, 3)

                Me.LblAn4.Enabled = CheckDataRowForanalysis(Ds, 4)
                Me.ComboAnl4.Enabled = CheckDataRowForanalysis(Ds, 4)

                Me.LblAn5.Enabled = CheckDataRowForanalysis(Ds, 5)
                Me.ComboAnl5.Enabled = CheckDataRowForanalysis(Ds, 5)

                Me.LblAn6.Enabled = CheckDataRowForanalysis(Ds, 6)
                Me.ComboAnl6.Enabled = CheckDataRowForanalysis(Ds, 6)

                Me.LblAn7.Enabled = CheckDataRowForanalysis(Ds, 7)
                Me.ComboAnl7.Enabled = CheckDataRowForanalysis(Ds, 7)

                Me.LblAn8.Enabled = CheckDataRowForanalysis(Ds, 8)
                Me.ComboAnl8.Enabled = CheckDataRowForanalysis(Ds, 8)

                Me.LblAn9.Enabled = CheckDataRowForanalysis(Ds, 9)
                Me.ComboAnl9.Enabled = CheckDataRowForanalysis(Ds, 9)

                Me.LblAn10.Enabled = CheckDataRowForanalysis(Ds, 10)
                Me.ComboAnl10.Enabled = CheckDataRowForanalysis(Ds, 10)
            Else
                Me.LblAn1.Enabled = False
                Me.LblAn2.Enabled = False
                Me.LblAn3.Enabled = False
                Me.LblAn4.Enabled = False
                Me.LblAn5.Enabled = False
                Me.LblAn6.Enabled = False
                Me.LblAn7.Enabled = False
                Me.LblAn8.Enabled = False
                Me.LblAn9.Enabled = False
                Me.LblAn10.Enabled = False

                Me.ComboAnl1.Enabled = False
                Me.ComboAnl2.Enabled = False
                Me.ComboAnl3.Enabled = False
                Me.ComboAnl4.Enabled = False
                Me.ComboAnl5.Enabled = False
                Me.ComboAnl6.Enabled = False
                Me.ComboAnl7.Enabled = False
                Me.ComboAnl8.Enabled = False
                Me.ComboAnl9.Enabled = False
                Me.ComboAnl10.Enabled = False
            End If
        End If
    End Sub
    Private Function CheckDataRowForanalysis(ByVal Ds As DataSet, ByVal X As Integer)
        If DbNullToString(Ds.Tables(0).Rows(0).Item(X)) = "A" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Cursor = Cursors.WaitCursor
        LockScreen(True)
        Me.ClearHeader()
        Me.ClearLines()
        Me.btnBusCur.Text = ""
        Me.btnTrxCur.Text = ""
        ClearGrid()
        Me.CalculateDGAmounts()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LockScreen(ByVal TF As Boolean)
        Me.GBLine.Enabled = TF
        Me.GBLineBtns.Enabled = TF
        Me.btnOverAllDisc.Enabled = TF
        Me.txtOverAllDiscount2.Enabled = TF
        Me.txtOverAllDisc.Enabled = TF
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteRow()
    End Sub
    Private Sub DeleteRow()
        If CheckDataSet(MyDs) Then
            Me.DoNotVisitNow = True
            Dim i As Integer
            i = Dg1.CurrentRow.Index
            If i <= MyDs.Tables(0).Rows.Count - 1 Then
                MyDs.Tables(0).Rows(i).Delete()
            End If
            Me.DoNotVisitNow = False
            CurrentRow = 0
            AllocateDiscount()
            If Not CheckDataSet(MyDs) Then
                Me.GBMain.Enabled = True
                Me.GBDetails.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim Flag As Boolean = True
        If Not CheckDataSet(MyDs) Then
            If Not ValidateHeader() Then
                Flag = False
            End If
        End If
        If Flag Then
            If ValidateLines() Then
                Me.DoCalculations("A")
                Me.GBMain.Enabled = False
                Me.GBDetails.Enabled = False
            End If
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If CheckDataSet(MyDs) Then
            If ValidateLines() Then
                Me.DoCalculations("E")
            End If
        End If
    End Sub
    Private Sub ClearHeaderErrors()
        Err1.SetError(Me.txtBusPartnerCode, "")
        Err3.SetError(Me.MSKTxtPostDate, "")
        Err4.SetError(Me.MSKTxtDueDate, "")
        Err5.SetError(Me.MSKTxtInvDate, "")
    End Sub
    Private Function ValidateHeader()
        ClearHeaderErrors()
        Dim Flag As Boolean = True
        If Me.txtBusPartnerDesc.Text = "" Then
            Err1.SetError(Me.txtBusPartnerCode, "Invalid Business Partner Code")
            Flag = False
        Else
            If Me.ComboTrxnCode.Text <> "" Then
                Dim Groupcode As String
                Groupcode = CType(Me.ComboTrxnCode.SelectedItem, cFiTrxnCodes).GroupCode
                Dim TrxnGroup As New cFiTrxnGroups(Groupcode, Me.GlbTrxnType)
                GlbFactor = TrxnGroup.MultFactor
            End If
        End If
        If Me.MSKTxtPostDate.MaskCompleted Then
            Try
                Dim D As Date
                D = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
            Catch ex As Exception
                Err3.SetError(Me.MSKTxtPostDate, "Please Enter a Valid Date")
                Flag = False
            End Try
        Else
            Err3.SetError(Me.MSKTxtPostDate, "Please Enter a Valid Date")
            Flag = False
        End If
        If Me.MSKTxtDueDate.MaskCompleted Then
            Try
                Dim D As Date
                D = Utils.ChangeMaskedFields(Me.MSKTxtDueDate)
            Catch ex As Exception
                Err4.SetError(Me.MSKTxtDueDate, "Please Enter a Valid Date")
                Flag = False
            End Try
        Else
            Err4.SetError(Me.MSKTxtDueDate, "Please Enter a Valid Date")
            Flag = False
        End If
        If Me.MSKTxtInvDate.MaskCompleted Then
            Try
                Dim D As Date
                D = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
            Catch ex As Exception
                Err5.SetError(Me.MSKTxtInvDate, "Please Enter a Valid Date")
                Flag = False
            End Try
        Else
            Err5.SetError(Me.MSKTxtInvDate, "Please Enter a Valid Date")
            Flag = False
        End If
        Return Flag
    End Function
    Private Sub ClearLineErrors()
        Err2.SetError(Me.txtAccountCode, "")

    End Sub
    Private Function ValidateLines()
        Dim Flag As Boolean = True
        ClearLineErrors()

        If Me.txtAccountDesc.Text = "" Then
            Err2.SetError(Me.txtAccountCode, "Please Enter a Valid Account Code")
            Flag = False
        End If
        Return Flag

    End Function
    Private Sub FindVATEnabledVATIncluded()

        If Me.GLBDisableVAT Then
            Me.CBVatEnabled.CheckState = CheckState.Unchecked
            Me.CBVatIncluded.CheckState = CheckState.Unchecked
            Exit Sub
        End If

        If GLBBusPrt.IsVATEnabled = "Y" Then
            GLB_IsVATEnabled = True
            If GLBBusPrt.IsVATIncluded = "Y" Then
                GLB_IsVATIncluded = True
            Else
                GLB_IsVATIncluded = False
            End If
        Else
            GLB_IsVATEnabled = False
            GLB_IsVATIncluded = False
        End If
        If GLB_IsVATEnabled Then
            Me.CBVatEnabled.CheckState = CheckState.Checked
        Else
            Me.CBVatEnabled.CheckState = CheckState.Unchecked
        End If
        If GLB_IsVATIncluded Then
            Me.CBVatIncluded.CheckState = CheckState.Checked
        Else
            Me.CBVatIncluded.CheckState = CheckState.Unchecked
        End If
    End Sub
    Private Sub DoCalculations(ByVal AddOrEditRow As String)

        Dim Price As Double = 0
        Dim Amount As Double = 0
        Dim VatRate As Double
        Dim CurRate As Double
        Dim LinediscountPerc As Double = CDbl(Me.txtLineDisc.Text)
        Dim InvoiceDate As Date
        Dim VATCode As String
        If ComboVAT.Enabled Then
            VATCode = CType(ComboVAT.SelectedItem, cVat).Code
        Else
            VATCode = "$"
        End If

        InvoiceDate = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
        VatRate = Global1.Business.GetVATRate(VATCode, InvoiceDate)
        Amount = CDbl(Me.txtAmount.Text)
        Price = Amount

        CurRate = CDbl(Me.txtCurRate.Text)
        'If IsVATEnable Then
        '    If IsVATIncluded Then
        '        Price = RoundMe2((Amount * (1 - (VatRate / 100))), 2)
        '    Else
        '        Price = Amount
        '    End If
        'Else
        '    Price = Amount
        'End If

        CalculateLineValues(Price, VatRate, LinediscountPerc, VATCode, AddOrEditRow, CurRate)

    End Sub
    Private Sub CalculateLineValues(ByVal Amount As Double, ByVal VatPerc As Double, ByVal LineDiscountPerc As Double, ByVal VATCode As String, ByVal AddOrEditRow As String, ByVal CurRate As Double)

        Dim LineUnitPrice As Double
        Dim LineDiscount As Double
        Dim LineDiscountVAT As Double
        Dim LineGrossPrice As Double
        Dim LineFinalNet As Double
        Dim LineFinalNetVAT As Double
        Dim LineFinalNetLocal As Double
        Dim LineFinalNetVATLocal As Double


        '-----------------------------------------------------

        '-------------------------
        Dim Discount As Double          '3
        Dim DiscountVAT As Double       '4
        Dim DiscountNoVAT As Double     '5
        '--------------------------
        Dim NetPrice As Double          '6
        Dim NetPriceVAT As Double       '7
        Dim NetPriceNoVAT As Double     '8
        '--------------------------
        Dim GrossPrice As Double        '9
        '--------------------------
        'This is Temporary Variables
        Dim UnitWithVatNoRound As Double
        Dim DiscNoRound As Double
        Dim NetNoRound As Double
        Dim NetPriceVATNoRound As Double
        '-----------------------------------------------------


        If GLB_IsVATEnabled Then
            If GLB_IsVATIncluded Then
                'VAT Is Enabled & VAT Is Included
                GrossPrice = Amount
                DiscNoRound = ((Amount * LineDiscountPerc / 100))
                Discount = RoundMe3(DiscNoRound, 2)
                DiscountVAT = RoundMe3((DiscNoRound - (DiscNoRound / ((100 + VatPerc) / 100))), 2)
                NetNoRound = (Amount - (Amount * LineDiscountPerc / 100))
                NetPrice = RoundMe3(NetNoRound, 2)
                NetPriceVATNoRound = (NetNoRound - (NetNoRound / ((100 + VatPerc) / 100)))
                NetPriceVAT = RoundMe3((NetNoRound - (NetNoRound / ((100 + VatPerc) / 100))), 2)
                NetPriceNoVAT = RoundMe3((NetNoRound / ((100 + VatPerc) / 100)), 2)
                'If OverAllDiscountMethod = 1 Then
                '    FinalNet = RoundMe3(NetNoRound - (NetNoRound * OverAllDiscountPerc / 100), 2)
                '    FinalNetVat = RoundMe3((NetPriceVATNoRound - (NetPriceVATNoRound / ((100 + VatPerc) / 100))), 2)
                'End If
            Else
                'VAT Is Enabled & VAT Is Not Included
                UnitWithVatNoRound = (Amount + (Amount * VatPerc / 100))
                GrossPrice = Amount
                DiscNoRound = (Amount * LineDiscountPerc / 100)
                Discount = RoundMe3(DiscNoRound, 2)
                DiscountVAT = RoundMe3((DiscNoRound * VatPerc / 100), 2)
                DiscountNoVAT = RoundMe3(DiscNoRound, 2)
                NetNoRound = (Amount - (Amount * LineDiscountPerc / 100))
                NetPrice = RoundMe3(NetNoRound, 2)
                NetPriceVATNoRound = (NetNoRound * VatPerc / 100)
                NetPriceVAT = RoundMe3((NetNoRound * VatPerc / 100), 2)
                NetPriceNoVAT = RoundMe3(NetNoRound, 2)
            End If
        Else
            'VAT Is NOT Enabled & VAT Is Not Included
            GrossPrice = Amount
            NetNoRound = (Amount - (Amount * LineDiscountPerc / 100))
            NetPrice = RoundMe3(NetNoRound, 2)
            NetPriceVAT = 0
            NetPriceNoVAT = NetPrice
            DiscNoRound = (Amount * LineDiscountPerc / 100)
            Discount = RoundMe3(DiscNoRound, 2)
            DiscountVAT = 0
            DiscountNoVAT = Discount
        End If

        LineUnitPrice = Amount
        LineDiscount = Discount
        LineDiscountVAT = DiscountVAT
        LineGrossPrice = RoundMe3(GrossPrice, 2)
        LineDiscountPerc = LineDiscountPerc
        LineFinalNet = NetPrice
        LineFinalNetVAT = NetPriceVAT
        LineFinalNetLocal = CurRate * LineFinalNet
        LineFinalNetVATLocal = CurRate * LineFinalNetVAT

        If AddOrEditRow = "A" Then
            AddRow(LineGrossPrice, LineDiscountPerc, LineDiscount, LineDiscountVAT, LineFinalNet, LineFinalNetVAT, VATCode, VatPerc, LineFinalNetLocal, LineFinalNetVATLocal)
        Else
            EditRow(LineGrossPrice, LineDiscountPerc, LineDiscount, LineDiscountVAT, LineFinalNet, LineFinalNetVAT, VATCode, VatPerc, LineFinalNetLocal, LineFinalNetVATLocal)
        End If

    End Sub
    
    Private Sub AddRow(ByVal GrossPrice As Double, ByVal LDiscPerc As Double, ByVal LDisc As Double, ByVal LDiscVAT As Double, ByVal LTotal As Double, ByVal LTotalVAT As Double, ByVal VATCode As String, ByVal VATRate As Double, ByVal LTotalLOCAL As Double, ByVal LTotalVATLOCAL As Double)
        Dim Counter As Integer
        If CheckDataSet(MyDs) Then
            Counter = MyDs.Tables(0).Rows.Count + 1
        Else
            Counter = 1
        End If
        Dim r As DataRow = Dt1.NewRow()
        r(Col_LineNo) = Counter
        r(Col_HdrId) = 0
        r(Col_AccCode) = Me.txtAccountCode.Text
        r(Col_AccDesc) = Me.txtAccountDesc.Text
        r(Col_Amount) = Me.txtAmount.Text
        r(Col_Gross) = Format(GrossPrice, "0.00")
        r(Col_LineDiscPerc) = Format(LDiscPerc, "0.00")
        r(Col_LineDisc) = Format(LDisc, "0.00")
        r(Col_LineDiscVAT) = Format(LDiscVAT, "0.00")
        r(Col_OverAllDisc) = 0
        r(Col_OverAllDiscVAT) = 0
        r(Col_LineTotal) = Format(LTotal, "0.00")
        r(Col_LineTotalVAT) = Format(LTotalVAT, "0.00")
        'temp
        r(Col_LineTotalLocal) = Format(LTotalLOCAL, "0.00")
        r(Col_LineTotalVATLocal) = Format(LTotalVATLOCAL, "0.00")
        r(Col_VATCode) = VATCode
        r(Col_VATRate) = Format(VATRate, "0.00")
        r(Col_Comments) = txtComment.Text

        'Analysis

        '1
        If ComboAnl1.Enabled Then
            r(Col_AcLAn1Code) = ComboAnl1.Text
        Else
            r(Col_AcLAn1Code) = "$"
        End If
        '2
        If ComboAnl2.Enabled Then
            r(Col_AcLAn2Code) = ComboAnl2.Text
        Else
            r(Col_AcLAn2Code) = "$"
        End If
        '3
        If ComboAnl3.Enabled Then
            r(Col_AcLAn3Code) = ComboAnl3.Text
        Else
            r(Col_AcLAn3Code) = "$"
        End If
        '4
        If ComboAnl4.Enabled Then
            r(Col_AcLAn4Code) = ComboAnl4.Text
        Else
            r(Col_AcLAn4Code) = "$"
        End If
        '5
        If ComboAnl5.Enabled Then
            r(Col_AcLAn5Code) = ComboAnl5.Text
        Else
            r(Col_AcLAn5Code) = "$"
        End If
        '6
        If ComboAnl6.Enabled Then
            r(Col_AcLAn6Code) = ComboAnl6.Text
        Else
            r(Col_AcLAn6Code) = "$"
        End If
        '7
        If ComboAnl7.Enabled Then
            r(Col_AcLAn7Code) = ComboAnl7.Text
        Else
            r(Col_AcLAn7Code) = "$"
        End If
        '8
        If ComboAnl8.Enabled Then
            r(Col_AcLAn8Code) = ComboAnl8.Text
        Else
            r(Col_AcLAn8Code) = "$"
        End If
        '9
        If ComboAnl9.Enabled Then
            r(Col_AcLAn9Code) = ComboAnl9.Text
        Else
            r(Col_AcLAn9Code) = "$"
        End If
        '10
        If ComboAnl10.Enabled Then
            r(Col_AcLAn10Code) = ComboAnl10.Text
        Else
            r(Col_AcLAn10Code) = "$"
        End If

        r(Me.Col_VatComboDesc) = Me.ComboVAT.Text

        Dt1.Rows.Add(r)
        Dg1.Rows(CurrentRow).Selected = False
        Dg1.Rows(Counter - 1).Selected = True


        If Counter > 1 Then
            CurrentRow = CurrentRow + 1
        End If
        ' CalculateTotals()
        'Me.txtAccountCode.Focus()
        'Me.txtAccountCode.SelectAll()
        AllocateDiscount()
    End Sub
    Private Sub EditRow(ByVal GrossPrice As Double, ByVal LDiscPerc As Double, ByVal LDisc As Double, ByVal LDiscVAT As Double, ByVal LTotal As Double, ByVal LTotalVAT As Double, ByVal VATCode As String, ByVal VATRate As Double, ByVal LTotalLOCAL As Double, ByVal LTotalVATLOCAL As Double)
        Dim i As Integer

        i = CurrentRow

        Dg1(Col_HdrId, i).Value = 0
        Dg1(Col_AccCode, i).Value = Me.txtAccountCode.Text
        Dg1(Col_AccDesc, i).Value = Me.txtAccountDesc.Text
        Dg1(Col_Amount, i).Value = Me.txtAmount.Text
        Dg1(Col_Gross, i).Value = Format(GrossPrice, "0.00")
        Dg1(Col_LineDiscPerc, i).Value = Format(LDiscPerc, "0.00")
        Dg1(Col_LineDisc, i).Value = Format(LDisc, "0.00")
        Dg1(Col_LineDiscVAT, i).Value = Format(LDiscVAT, "0.00")
        Dg1(Col_OverAllDisc, i).Value = 0
        Dg1(Col_OverAllDiscVAT, i).Value = 0
        Dg1(Col_LineTotal, i).Value = Format(LTotal, "0.00")
        Dg1(Col_LineTotalVAT, i).Value = Format(LTotalVAT, "0.00")
        'temp
        Dg1(Col_LineTotalLocal, i).Value = Format(LTotalLOCAL, "0.00")
        Dg1(Col_LineTotalVATLocal, i).Value = Format(LTotalVATLOCAL, "0.00")
        '
        Dg1(Col_VATCode, i).Value = VATCode
        Dg1(Col_VATRate, i).Value = Format(VATRate, "0.00")
        Dg1(Col_Comments, i).Value = txtComment.Text

        'Analysis

        '1
        If ComboAnl1.Enabled Then
            Dg1(Col_AcLAn1Code, i).Value = ComboAnl1.Text
        Else
            Dg1(Col_AcLAn1Code, i).Value = "$"
        End If
        '2
        If ComboAnl2.Enabled Then
            Dg1(Col_AcLAn2Code, i).Value = ComboAnl2.Text
        Else
            Dg1(Col_AcLAn2Code, i).Value = "$"
        End If

        '3
        If ComboAnl3.Enabled Then
            Dg1(Col_AcLAn3Code, i).Value = ComboAnl3.Text
        Else
            Dg1(Col_AcLAn3Code, i).Value = "$"
        End If
        '4
        If ComboAnl4.Enabled Then
            Dg1(Col_AcLAn4Code, i).Value = ComboAnl4.Text
        Else
            Dg1(Col_AcLAn4Code, i).Value = "$"
        End If
        '5
        If ComboAnl5.Enabled Then
            Dg1(Col_AcLAn5Code, i).Value = ComboAnl5.Text
        Else
            Dg1(Col_AcLAn5Code, i).Value = "$"
        End If
        '6
        If ComboAnl6.Enabled Then
            Dg1(Col_AcLAn6Code, i).Value = ComboAnl6.Text
        Else
            Dg1(Col_AcLAn6Code, i).Value = "$"
        End If
        '7
        If ComboAnl7.Enabled Then
            Dg1(Col_AcLAn7Code, i).Value = ComboAnl7.Text
        Else
            Dg1(Col_AcLAn7Code, i).Value = "$"
        End If
        '8
        If ComboAnl8.Enabled Then
            Dg1(Col_AcLAn8Code, i).Value = ComboAnl8.Text
        Else
            Dg1(Col_AcLAn8Code, i).Value = "$"
        End If
        '9
        If ComboAnl9.Enabled Then
            Dg1(Col_AcLAn9Code, i).Value = ComboAnl9.Text
        Else
            Dg1(Col_AcLAn9Code, i).Value = "$"
        End If
        '10
        If ComboAnl10.Enabled Then
            Dg1(Col_AcLAn10Code, i).Value = ComboAnl10.Text
        Else
            Dg1(Col_AcLAn10Code, i).Value = "$"
        End If

        Dg1(Col_VatComboDesc, i).Value = Me.ComboVAT.Text

        'Me.txtAccountCode.Focus()
        'Me.txtAccountCode.SelectAll()
        AllocateDiscount()
    End Sub
    Private Sub AllocateDiscount()
        Try
            Allocating = True
            Dim InvalidDiscount As Boolean = False
            Dim i As Integer
            Dim Dis As Double
            Dim DisPerc As Double
            Dim TotalNet As Double = 0
            Dim TotalNetVAT As Double = 0
            Dim TotalOverDisc As Double
            Dim LineOverDisc As Double
            Dim LineOverDiscVAT As Double
            Dim LineNet As Double
            Dim LineNetVAT As Double
            Dim LineDiscPerc As Double
            Dim VATPerc As Double
            Dim Dif As Double

            If CheckDataSet(MyDs) Then
                'Calculate Amounts
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    With MyDs.Tables(0).Rows(i)
                        TotalNet = TotalNet + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Col_LineTotal))
                        TotalNetVAT = TotalNetVAT + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Col_LineTotalVAT))
                    End With
                Next
                'Find OverAllDscount AMOUNT
                If Me.btnOverAllDisc.Tag = "1" Then
                    Dis = Me.txtOverAllDisc.Text
                    If TotalNet < 0 Then
                        Dis = 0 - Dis
                    End If
                ElseIf Me.btnOverAllDisc.Tag = "2" Then
                    DisPerc = Me.txtOverAllDisc.Text
                    Dis = TotalNet * DisPerc / 100
                    Dis = RoundMe3(Dis, 2)
                    Me.txtOverAllDiscount2.Text = Format(Dis, "0.00")
                    Me.txtOverAllDiscount2.Visible = True
                End If
                Debug.WriteLine("Dis:" & Dis)
                'This is when Ord VAT is Included
                If GLB_IsVATIncluded Then
                    If Math.Abs(Dis) > Math.Abs(TotalNet) Then
                        InvalidDiscount = True
                    End If
                    If Dis < 0 And TotalNet > 0 Then
                        InvalidDiscount = True
                    End If
                    If Dis > 0 And TotalNet < 0 Then
                        InvalidDiscount = True
                    End If
                    If InvalidDiscount Then
                        MsgBox("Invalid Discount Value", MsgBoxStyle.Critical)
                        If Me.btnOverAllDisc.Tag = "2" Then
                            Me.txtOverAllDisc.Text = Format(GLBOverAllDiscountPerc, "0.00")
                        Else
                            Me.txtOverAllDisc.Text = Format(0, "0.00")
                        End If
                        AllocateDiscount()
                        Allocating = False
                        Exit Sub
                    End If
                    OriginalDiscount = Dis
                    'VAT IS INCLUDED

                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            LineDiscPerc = .Item(Col_LineDiscPerc)
                            VATPerc = .Item(Col_VATRate)
                            LineNet = .Item(Col_LineTotal)
                            LineNetVAT = .Item(Col_LineTotalVAT)
                            If TotalNet = 0 Then
                                LineOverDisc = 0
                            Else
                                LineOverDisc = RoundMe3((LineNet / TotalNet * Dis), 2)
                            End If
                            LineOverDiscVAT = RoundMe3((LineOverDisc - (LineOverDisc / ((100 + VATPerc) / 100))), 2)
                            TotalOverDisc = TotalOverDisc + LineOverDisc
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    Next
                    'Add or Substract Any diference between
                    'Actual Discount and allocated discount
                    If TotalOverDisc > Dis Then
                        Dif = RoundMe3((TotalOverDisc - Dis), 2)
                        i = MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            VATPerc = .Item(Col_VATRate)
                            LineOverDisc = .Item(Col_OverAllDisc) - Dif
                            LineOverDiscVAT = RoundMe3((LineOverDisc - (LineOverDisc / ((100 + VATPerc) / 100))), 2)
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    ElseIf TotalOverDisc < Dis Then
                        Dif = RoundMe3(Dis - TotalOverDisc, 2)
                        i = MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            VATPerc = .Item(Col_VATRate)
                            LineOverDisc = .Item(Col_OverAllDisc) + Dif
                            LineOverDiscVAT = RoundMe3((LineOverDisc - (LineOverDisc / ((100 + VATPerc) / 100))), 2)
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    End If
                Else
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'This is when VAT IS *NOT INCLUDED
                    If Dis <> 0 Then
                        If Math.Abs(Dis) > Math.Abs((TotalNet + TotalNetVAT)) Then
                            InvalidDiscount = True
                        End If
                        If Dis < 0 And TotalNet + TotalNetVAT > 0 Then
                            InvalidDiscount = True
                        End If
                        If Dis > 0 And TotalNet + TotalNetVAT < 0 Then
                            InvalidDiscount = True
                        End If
                        If InvalidDiscount Then
                            MsgBox("Invalid Discount Value", MsgBoxStyle.Critical)

                            If Me.btnOverAllDisc.Tag = "2" Then
                                Me.txtOverAllDisc.Text = Format(GLBOverAllDiscountPerc, "0.00")
                            Else
                                Me.txtOverAllDisc.Text = Format(0, "0.00")
                            End If
                            AllocateDiscount()
                            Allocating = False
                            Exit Sub
                        End If
                    End If

                    OriginalDiscount = Dis
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            LineDiscPerc = .Item(Col_LineDiscPerc)
                            VATPerc = .Item(Col_VATRate)
                            LineNet = .Item(Col_LineTotal)
                            LineNetVAT = .Item(Col_LineTotalVAT)
                            If TotalNet = 0 Then
                                LineOverDisc = 0
                            Else
                                LineOverDisc = RoundMe3((LineNet / TotalNet * Dis), 2)
                            End If
                            If Not GLB_IsVATEnabled Then
                                LineOverDiscVAT = 0
                            Else
                                LineOverDiscVAT = RoundMe3((LineOverDisc * VATPerc / 100), 2)
                            End If
                            TotalOverDisc = TotalOverDisc + LineOverDisc
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    Next
                    'Add or Substract Any diference between
                    'Actual Discount and allocated discount
                    If TotalOverDisc > Dis Then
                        Dif = RoundMe3((TotalOverDisc - Dis), 2)
                        i = MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            LineOverDisc = .Item(23) - Dif

                            If Not GLB_IsVATEnabled Then
                                LineOverDiscVAT = 0
                            Else
                                LineOverDiscVAT = RoundMe3((LineOverDisc * VATPerc / 100), 2)
                            End If

                            TotalOverDisc = TotalOverDisc + LineOverDisc
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    ElseIf TotalOverDisc < Dis Then
                        Dif = RoundMe3(Dis - TotalOverDisc, 2)
                        i = MyDs.Tables(0).Rows.Count - 1
                        With MyDs.Tables(0).Rows(i)
                            LineOverDisc = .Item(Col_OverAllDisc) + Dif

                            If Not GLB_IsVATEnabled Then
                                LineOverDiscVAT = 0
                            Else
                                LineOverDiscVAT = RoundMe3((LineOverDisc * VATPerc / 100), 2)
                            End If
                            TotalOverDisc = TotalOverDisc + LineOverDisc
                            .Item(Col_OverAllDisc) = LineOverDisc
                            .Item(Col_OverAllDiscVAT) = LineOverDiscVAT
                        End With
                    End If
                End If
                Me.CalculateDGAmounts()
            Else
                Me.txtOverAllDisc.Text = Format(0, "0.00")
                Me.txtOverAllDiscount2.Text = Format(0, "0.00")
            End If
        Catch ex As System.Exception
        End Try
        Allocating = False
    End Sub
    Private Sub CalculateDGAmounts()
        Dim i As Integer
        Dim k As Integer
        Dim Discount As Double
        Dim DiscountVAT As Double
        '--------------------------
        Dim LineFinalNetPrice As Double
        Dim LineFinalNetPriceVAT As Double
        '--------------------------
        Dim GrossPrice As Double
        Dim OverDiscount As Double
        Dim OverDiscountVAT As Double
        ''''''''''''''''
        Dim HDRLinesDisc As Double = 0
        Dim HDRLinesDiscVAT As Double = 0
        Dim HDRNetVatPrice As Double = 0
        Dim HDRGrossPrice As Double = 0
        Dim HDROverAllDisc As Double = 0
        Dim HDROverAllDiscVAT As Double = 0
        Dim HDROverAllDiscPerc = 0
        Dim HDRtotal = 0
        Dim HDRtotalLocal = 0
        '''''''''''''''
        Dim CurRate As Double
        CurRate = CDbl(Me.txtCurRate.Text)
        If CheckDataSet(MyDs) Then
            i = Dg1.CurrentRow.Index
            k = MyDs.Tables(0).Rows.Count - 1
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                With MyDs.Tables(0).Rows(i)
                    Try
                        Discount = Discount + .Item(Col_LineDisc)
                        DiscountVAT = DiscountVAT + .Item(Col_LineDiscVAT)
                        OverDiscount = OverDiscount + .Item(Col_OverAllDisc)
                        OverDiscountVAT = OverDiscountVAT + .Item(Col_OverAllDiscVAT)
                        LineFinalNetPrice = LineFinalNetPrice + .Item(Col_LineTotal)
                        LineFinalNetPriceVAT = LineFinalNetPriceVAT + .Item(Col_LineTotalVAT)
                        GrossPrice = GrossPrice + .Item(Col_Gross)
                    Catch ex As System.Exception
                        'Utils.ShowException(ex)
                        Exit For
                    End Try
                End With
            Next
        End If
        
        If CheckDataSet(MyDs) Then
            HDRLinesDisc = Discount
            HDRLinesDiscVAT = DiscountVAT
            'savvas
            HDRNetVatPrice = RoundMe3(LineFinalNetPriceVAT - OverDiscountVAT, 2)
            HDRGrossPrice = GrossPrice
            HDROverAllDisc = OverDiscount
            HDROverAllDiscVAT = OverDiscountVAT
            If Me.btnOverAllDisc.Tag = 2 Then
                If Not IsNumeric(txtOverAllDisc.Text) Then
                    HDROverAllDiscPerc = 0
                Else
                    HDROverAllDiscPerc = txtOverAllDisc.Text
                End If
            Else
                Dim Dis As Double
                If Not IsNumeric(txtOverAllDisc.Text) Then
                    Dis = 0
                Else
                    Dis = Me.txtOverAllDisc.Text
                End If
            End If

            If GLB_IsVATIncluded Then
                Me.txtTotalGross.Text = Format(GrossPrice, "0.00")
                Me.txtTotalLineDisc.Text = Format(Discount, "0.00")
                Me.txtTotalNet.Text = Format(GrossPrice - Discount, "0.00")
                Me.txtTotalVAT.Text = Format(HDRNetVatPrice, "0.00")
                HDRTotal = LineFinalNetPrice - OverDiscount
                Me.txtTotal.Text = Format(HDRtotal, "0.00")
                Me.txtTotalLC.Text = Format(RoundMe2((HDRtotal * currate), 2), "0.00")
            Else
                Me.txtTotalGross.Text = Format(GrossPrice, "0.00")
                Me.txtTotalLineDisc.Text = Format(Discount, "0.00")
                Me.txtTotalNet.Text = Format(GrossPrice - Discount, "0.00")
                Me.txtTotalVAT.Text = Format(HDRNetVatPrice, "0.00")
                HDRtotal = LineFinalNetPrice + HDRNetVatPrice - OverDiscount
                Me.txtTotal.Text = Format(HDRtotal, "0.00")
                Me.txtTotalLC.Text = Format(RoundMe2((HDRtotal * currate), 2), "0.00")
            End If
        Else
            Me.txtTotalGross.Text = Format(GrossPrice, "0.00")
            Me.txtTotalLineDisc.Text = Format(Discount, "0.00")
            Me.txtTotalNet.Text = Format(Discount, "0.00")
            Me.txtTotalVAT.Text = Format(LineFinalNetPriceVAT, "0.00")
            Me.txtTotal.Text = Format(LineFinalNetPrice, "0.00")
            Me.txtTotalLC.Text = "0.00"
        End If

        Me.GlbHeader.TotalTrxn = HDRtotal
        Me.GlbHeader.TotalVATTrxn = HDRNetVatPrice
        Me.GlbHeader.OverallDiscPerc = HDROverAllDiscPerc
        Me.GlbHeader.OverallDiscTrxn = HDROverAllDisc
        Me.GlbHeader.OverallDiscVatTrxn = HDROverAllDiscVAT

    End Sub
#Region "Key Ups"


    Private Sub txtAmount_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.ComboVAT.Enabled Then
                Me.ComboVAT.Focus()
            Else
                Me.txtLineDisc.Focus()
                Me.txtLineDisc.SelectAll()
            End If
        End If
    End Sub

    Private Sub ComboVAT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboVAT.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtLineDisc.Focus()
            Me.txtLineDisc.SelectAll()
        End If
    End Sub
    Private Sub txtLineDisc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLineDisc.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtComment.Focus()
            Me.txtComment.SelectAll()
        End If
    End Sub
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComment.KeyUp
        If e.KeyCode = Keys.Enter Then
            ComboFocus(1)
        End If
    End Sub
    Private Sub ComboAnl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(2)
        End If
    End Sub
    Private Sub ComboAnl2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl2.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(3)
        End If
    End Sub
    Private Sub ComboAnl3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl3.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(4)
        End If
    End Sub
    Private Sub ComboAnl4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl4.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(5)
        End If
    End Sub
    Private Sub ComboAnl5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl5.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(6)
        End If
    End Sub
    Private Sub ComboAnl6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl6.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(7)
        End If
    End Sub
    Private Sub ComboAnl7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl7.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(8)
        End If
    End Sub
    Private Sub ComboAnl8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl8.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(9)
        End If
    End Sub
    Private Sub ComboAnl9_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl9.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(10)
        End If
    End Sub
    Private Sub ComboAnl10_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl10.KeyUp
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Focus()
        End If
    End Sub
    Private Sub ComboFocus(ByVal Ind As Integer)
        Select Case Ind
            Case 1
                If Me.ComboAnl1.Enabled Then
                    Me.ComboAnl1.Focus()
                Else
                    ComboFocus(2)
                End If
            Case 2
                If Me.ComboAnl2.Enabled Then
                    Me.ComboAnl2.Focus()
                Else
                    ComboFocus(3)
                End If
            Case 3
                If Me.ComboAnl3.Enabled Then
                    Me.ComboAnl3.Focus()
                Else
                    ComboFocus(4)
                End If
            Case 4
                If Me.ComboAnl4.Enabled Then
                    Me.ComboAnl4.Focus()
                Else
                    ComboFocus(5)
                End If
            Case 5
                If Me.ComboAnl5.Enabled Then
                    Me.ComboAnl5.Focus()
                Else
                    ComboFocus(6)
                End If
            Case 6
                If Me.ComboAnl6.Enabled Then
                    Me.ComboAnl6.Focus()
                Else
                    ComboFocus(7)
                End If
            Case 7
                If Me.ComboAnl7.Enabled Then
                    Me.ComboAnl7.Focus()
                Else
                    ComboFocus(8)
                End If
            Case 8
                If Me.ComboAnl8.Enabled Then
                    Me.ComboAnl8.Focus()
                Else
                    ComboFocus(9)
                End If
            Case 9
                If Me.ComboAnl9.Enabled Then
                    Me.ComboAnl9.Focus()
                Else
                    ComboFocus(10)
                End If
            Case 10
                If Me.ComboAnl10.Enabled Then
                    Me.ComboAnl10.Focus()
                Else
                    BtnAdd.Focus()
                End If

        End Select

    End Sub
#End Region


    Private Sub btnOverAllDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverAllDisc.Click
        ChangeDiscMethod()
    End Sub
    Private Sub ChangeDiscMethod()
        If Me.btnOverAllDisc.Tag = "1" Then
            Me.btnOverAllDisc.Tag = "2"
            Me.btnOverAllDisc.Text = "Disc.(%)"
            Me.txtOverAllDiscount2.Visible = True
        ElseIf Me.btnOverAllDisc.Tag = "2" Then
            Me.btnOverAllDisc.Tag = "1"
            Me.btnOverAllDisc.Text = "Disc.(£)"
            Me.txtOverAllDiscount2.Visible = False
        End If
        Me.txtOverAllDisc.Focus()
        Me.txtOverAllDisc.SelectAll()
        ' If AddingNewRow Then Exit Sub
        AllocateDiscount()
    End Sub

    Private Sub txtOverAllDisc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverAllDisc.TextChanged

        'If NotNow Then Exit Sub
        'If AddingNewRow Then Exit Sub
        If Allocating Then Exit Sub
        If Me.txtOverAllDisc.Text = "" Or Me.txtOverAllDisc.Text = "." Then
            Me.txtOverAllDisc.Text = 0
            Me.txtOverAllDisc.SelectAll()
        End If
        AllocateDiscount()
    End Sub

    Private Sub txtOverAllDisc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverAllDisc.Validated
        'If NotNow Then Exit Sub
        If Me.txtOverAllDisc.Text = "" Or Me.txtOverAllDisc.Text = "." Then
            Me.txtOverAllDisc.Text = 0
            Me.txtOverAllDisc.SelectAll()
        End If
        ' If AddingNewRow Then Exit Sub
        If Allocating Then Exit Sub
        AllocateDiscount()
    End Sub
    Private Sub DG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1.Click
        Try
            If DoNotVisitNow Then Exit Sub
            Dim i As Integer
            Dg1.Rows(CurrentRow).Selected = False
            i = Dg1.CurrentRow.Index
            CurrentRow = i
            Dg1.Rows(CurrentRow).Selected = True
            LoadFromGridCellsToLineDetails()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Dg1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1.SelectionChanged
        DG1SelectionChange()
    End Sub
    Private Sub DG1SelectionChange()
        Try
            If DoNotVisitNow Then Exit Sub
            If CheckDataSet(MyDs) Then
                Dim i As Integer
                i = Dg1.CurrentRow.Index
                If i <> CurrentRow Then
                    CurrentRow = i
                    LoadFromGridCellsToLineDetails()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadFromGridCellsToLineDetails()
        If CheckDataSet(MyDs) Then
            If CurrentRow <= MyDs.Tables(0).Rows.Count - 1 Then
                With MyDs.Tables(0).Rows(CurrentRow)
                    Me.txtAccountCode.Text = DbNullToString(.Item(Col_AccCode))
                    Me.txtAccountDesc.Text = DbNullToString(.Item(Col_AccDesc))
                    Me.txtAmount.Text = Format(DbNullToDouble(.Item(Col_Amount)), "0.00")
                    Me.ComboVAT.SelectedIndex = Me.ComboVAT.FindStringExact(DbNullToString(.Item(Col_VatComboDesc)))
                    Me.txtLineDisc.Text = Format(DbNullToDouble(.Item(Col_LineDiscPerc)), "0.00")
                    Me.txtComment.Text = DbNullToString(.Item(Col_Comments))

                    Dim S As String

                    S = DbNullToString(.Item(Me.Col_AcLAn1Code))
                    If S = "$" Then
                        Me.ComboAnl1.SelectedIndex = 0
                        Me.ComboAnl1.Enabled = False
                    Else
                        Me.ComboAnl1.SelectedIndex = Me.ComboAnl1.FindStringExact(S)
                        Me.ComboAnl1.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn2Code))
                    If S = "$" Then
                        Me.ComboAnl2.SelectedIndex = 0
                        Me.ComboAnl2.Enabled = False
                    Else
                        Me.ComboAnl2.SelectedIndex = Me.ComboAnl2.FindStringExact(S)
                        Me.ComboAnl2.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn3Code))
                    If S = "$" Then
                        Me.ComboAnl3.SelectedIndex = 0
                        Me.ComboAnl3.Enabled = False
                    Else
                        Me.ComboAnl3.SelectedIndex = Me.ComboAnl3.FindStringExact(S)
                        Me.ComboAnl3.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn4Code))
                    If S = "$" Then
                        Me.ComboAnl4.SelectedIndex = 0
                        Me.ComboAnl4.Enabled = False
                    Else
                        Me.ComboAnl4.SelectedIndex = Me.ComboAnl4.FindStringExact(S)
                        Me.ComboAnl4.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn5Code))
                    If S = "$" Then
                        Me.ComboAnl5.SelectedIndex = 0
                        Me.ComboAnl5.Enabled = False
                    Else
                        Me.ComboAnl5.SelectedIndex = Me.ComboAnl5.FindStringExact(S)
                        Me.ComboAnl5.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn6Code))
                    If S = "$" Then
                        Me.ComboAnl6.SelectedIndex = 0
                        Me.ComboAnl6.Enabled = False
                    Else
                        Me.ComboAnl6.SelectedIndex = Me.ComboAnl6.FindStringExact(S)
                        Me.ComboAnl6.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn7Code))
                    If S = "$" Then
                        Me.ComboAnl7.SelectedIndex = 0
                        Me.ComboAnl7.Enabled = False
                    Else
                        Me.ComboAnl7.SelectedIndex = Me.ComboAnl7.FindStringExact(S)
                        Me.ComboAnl7.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn8Code))
                    If S = "$" Then
                        Me.ComboAnl8.SelectedIndex = 0
                        Me.ComboAnl8.Enabled = False
                    Else
                        Me.ComboAnl8.SelectedIndex = Me.ComboAnl8.FindStringExact(S)
                        Me.ComboAnl8.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn9Code))
                    If S = "$" Then
                        Me.ComboAnl9.SelectedIndex = 0
                        Me.ComboAnl9.Enabled = False
                    Else
                        Me.ComboAnl9.SelectedIndex = Me.ComboAnl9.FindStringExact(S)
                        Me.ComboAnl9.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn10Code))
                    If S = "$" Then
                        Me.ComboAnl10.SelectedIndex = 0
                        Me.ComboAnl10.Enabled = False
                    Else
                        Me.ComboAnl10.SelectedIndex = Me.ComboAnl10.FindStringExact(S)
                        Me.ComboAnl10.Enabled = True
                    End If

                End With
            End If
        Else
            Me.ClearLines()
        End If
    End Sub

    Private Sub ComboVAT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboVAT.SelectedIndexChanged

        Dim flag As Boolean = True
        Me.txtVATRate.Text = ""
        If Me.ComboVAT.Text <> "" Then
            Dim VATCode As String
            Dim InvoiceDate As Date
            If Me.MSKTxtInvDate.MaskCompleted Then
                VATCode = CType(ComboVAT.SelectedItem, cVat).Code
                Try
                    InvoiceDate = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
                    Me.txtVATRate.Text = Format(Global1.Business.GetVATRate(VATCode, InvoiceDate), "0.00")
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        TryToSaveMe()
    End Sub
    Private Sub TryToSaveMe()
        If GlbHeader.Id <> 0 Then
            Exit Sub
        End If
        If CheckDataSet(MyDs) Then
            If Not GlbHeader Is Nothing Then
                If Me.GLBEnableAllocation Then
                    If Not CheckAllocationAmounts() Then
                        Exit Sub
                    End If
                End If

                Dim Modify As Boolean = False
                Dim Exx As New SystemException
                Dim i As Integer
                Dim PeriodCode As String
                Dim Allocationdate As Date = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)

                PeriodCode = Global1.Business.GetPeriodCode(Allocationdate)
                If PeriodCode = "" Then
                    MsgBox("There is not Period Defined for date " & Me.MSKTxtPostDate.Text & Chr(13) & " Unable to Save!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Global1.Business.BeginTransaction()
                Try
                    With GlbHeader
                        .TrxCodCode = CType(Me.ComboTrxnCode.SelectedItem, cFiTrxnCodes).Code
                        .BusPrtCode = Me.txtBusPartnerCode.Text
                        .PostDate = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
                        .InvDate = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
                        .DueDate = Utils.ChangeMaskedFields(Me.MSKTxtDueDate)
                        .RefNo = Global1.Business.GetFiTrxnCodeNextReferenceNo(CType(Me.ComboTrxnCode.SelectedItem, cFiTrxnCodes))
                        .AcctRefNo = Me.txtAcctRefNo.Text
                        .XRefNo = Me.txtXRefNo.Text
                        .CurAlphaCode = CType(Me.ComboCurency.SelectedItem, cAdMsCurrency).AlphaCode
                        .TrxnTypeFactor = Me.GlbTrxnTypeFactor
                        .CurRate = Me.txtCurRate.Text
                        .Factor = Me.GlbFactor
                        If GLB_IsVATIncluded Then
                            .IsVatIncluded = "Y"
                        Else
                            .IsVatIncluded = "N"
                        End If
                        If GLB_IsReversed Then
                            .IsReversed = "Y"
                        Else
                            .IsReversed = "N"
                        End If
                        .Notes = Me.txtHeaderComments.Text
                        If Modify Then
                            .AmendDate = Now.Date
                            .AmendBy = Global1.GLBUserId
                        Else
                            .CreationDate = Now.Date
                            .AmendDate = Now.Date
                            .CreatedBy = Global1.GLBUserId
                            .AmendBy = Global1.GLBUserId
                        End If

                        If Not .Save Then
                            Throw Exx
                        End If
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            Dim Line As New cFiTxTrxnLines
                            LoadFromGridToClass(GlbHeader.Id, i + 1, Line)
                            If Not Line.Save Then
                                Throw Exx
                            End If
                        Next
                    End With
                    If Me.GLBEnableAllocation Then
                        If Not UpdateAllocationBalances(GlbHeader.Id, PeriodCode, Allocationdate) Then
                            Throw Exx
                        End If
                    End If
                    If Not SaveExtraLines(CType(Me.ComboTrxnCode.SelectedItem, cFiTrxnCodes)) Then
                        Throw Exx
                    End If
                    Global1.Business.CommitTransaction()
                    Me.txtRefNo.Text = GlbHeader.RefNo
                    Me.txtAmendDate.Text = Format(GlbHeader.AmendDate, "dd-MM-yyyy")
                    Me.txtCreatedBy.Text = Format(GlbHeader.CreatedBy, "dd-MM-yyyy")

                    MsgBox("Transaction is Succesfully Saved", MsgBoxStyle.Information)
                    LockScreen(False)
                Catch ex As Exception
                    MsgBox("Failed to save Transaction", MsgBoxStyle.Critical)
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    If Not Modify Then
                        Me.GlbHeader.Id = 0
                    End If
                End Try
            End If
        End If
    End Sub

    Private Function CheckForAllocationNeed() As Boolean
        Dim Flag As Boolean = False
        If CDbl(Me.txtAllocTotalAmount.Text) = CDbl("0") Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Do you want to Allocate Transaction Amounts?", MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                Flag = True
            End If
        End If

        If Flag Then
            CallAllocation()
        End If
        Return Flag
    End Function

    Private Function UpdateAllocationBalances(ByVal HeaderId As Integer, ByVal PeriodCode As String, ByVal AllocationDate As Date) As Boolean
        Dim Flag As Boolean = True
        Dim i As Integer
        Dim Exx As New SystemException

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 1: Transaction Currency = Business Partner Currency = Local Currency
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode = Me.btnTrxCur.Text And Global1.LocalCurencyCode = Me.btnBusCur.Text Then
            If Me.CBAllocated.CheckState = CheckState.Checked Then
                ' Sub Case 11: Selection of Allocation 
                If CheckDataSet(Me.GlbDsAlloc) Then
                    Dim Selected As String
                    Dim Id As String
                    Dim Amount As Double
                    For i = 0 To GlbDsAlloc.Tables(0).Rows.Count - 1
                        Selected = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Selected))
                        If Selected = CStr(1) Then
                            Id = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Id))
                            Amount = DbNullToDouble(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Amount))
                            Dim AccLin As New cAccountLines(Id)
                            AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - Amount
                            AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
                            If AccLin.UnAllocBalanceLC = 0 Then
                                AccLin.AllocStatus = "A"
                            Else
                                AccLin.AllocStatus = "P"
                            End If
                            AccLin.AmendBy = Global1.GLBUserId
                            AccLin.AmendDate = Now.Date
                            If Not AccLin.Save Then
                                Flag = False
                                Throw Exx
                            End If
                            If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, Amount, Amount) Then
                                Flag = False
                                Throw Exx
                            End If
                        End If
                    Next
                End If
            Else
                'Sub Case 12: No Allocation
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 2: Transaction Currency = Local Currency , Allocation Currency = Business Partner Currency
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode = Me.btnTrxCur.Text And Me.GLBBusPrt.CurAlphaCode = Me.btnBusCur.Text Then
            ' Sub Case 21: Selection of Allocation 
            If Me.CBAllocated.CheckState = CheckState.Checked Then
                If CheckDataSet(Me.GlbDsAlloc) Then
                    Dim Selected As String
                    Dim Id As String
                    Dim Amount As Double
                    For i = 0 To GlbDsAlloc.Tables(0).Rows.Count - 1
                        Selected = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Selected))
                        If Selected = CStr(1) Then
                            Id = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Id))
                            Amount = DbNullToDouble(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Amount))
                            Dim AccLin As New cAccountLines(Id)
                            If Amount = AccLin.UnAllocBalanceTC Then
                                AccLin.UnAllocBalanceLC = 0
                                AccLin.UnAllocBalanceTC = 0
                                AccLin.AllocStatus = "A"
                            Else
                                AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - (Amount * Me.txtAllocRate.Text)
                                AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
                                AccLin.AllocStatus = "P"
                            End If
                            AccLin.AmendBy = Global1.GLBUserId
                            AccLin.AmendDate = Now.Date
                            If Not AccLin.Save Then
                                Flag = False
                                Throw Exx
                            End If
                            If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, (Amount * Me.txtAllocRate.Text), Amount) Then
                                Flag = False
                                Throw Exx
                            End If
                        End If
                    Next
                End If
            Else
                'Sub Case 22: No Allocation
            End If
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 3: Transaction Currency <> Local Currency , Transaction Currency = Allocation Currency = Business Partner Currency
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode <> Me.btnTrxCur.Text And Me.btnTrxCur.Text = Me.btnBusCur.Text Then
            ' Sub Case 31: Selection of Allocation 
            If Me.CBAllocated.CheckState = CheckState.Checked Then
                If CheckDataSet(Me.GlbDsAlloc) Then
                    Dim Selected As String
                    Dim Id As String
                    Dim Amount As Double
                    Dim DayCurRate As Double

                    DayCurRate = Global1.Business.GetCurruncyRate(Me.btnBusCur.Text, Now.Date)

                    For i = 0 To GlbDsAlloc.Tables(0).Rows.Count - 1
                        Selected = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Selected))
                        If Selected = CStr(1) Then
                            Id = DbNullToString(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Id))
                            Amount = DbNullToDouble(GlbDsAlloc.Tables(0).Rows(i).Item(AllocCol_Amount))
                            Dim AccLin As New cAccountLines(Id)
                            If Amount = AccLin.UnAllocBalanceTC Then
                                AccLin.UnAllocBalanceLC = 0
                                AccLin.UnAllocBalanceTC = 0
                                AccLin.AllocStatus = "A"
                            Else
                                AccLin.UnAllocBalanceLC = AccLin.UnAllocBalanceLC - (Amount * DayCurRate)
                                AccLin.UnAllocBalanceTC = AccLin.UnAllocBalanceTC - Amount
                                AccLin.AllocStatus = "P"
                            End If
                            AccLin.AmendBy = Global1.GLBUserId
                            AccLin.AmendDate = Now.Date
                            If Not AccLin.Save Then
                                Flag = False
                                Throw Exx
                            End If
                            If Not SaveAllocation(AccLin.Id, HeaderId, PeriodCode, AllocationDate, (Amount * DayCurRate), Amount) Then
                                Flag = False
                                Throw Exx
                            End If
                        End If
                    Next
                End If
            Else
                'Sub Case 32: No Allocation
            End If
        End If
        Return Flag
    End Function
    Private Function SaveAllocation(ByVal AccountLineId As Integer, ByVal HeaderId As Integer, ByVal PeriodCode As String, ByVal AllocationDate As Date, ByVal AmountLC As Double, ByVal AmountTC As Double) As Boolean
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            Dim Alloc As New cFiTxAllocations
            With Alloc
                .AccLineId = AccountLineId
                .TrxHeaderId = HeaderId
                .PrdCode = PeriodCode
                .AllocationDate = AllocationDate
                .CurAlphaCode = Me.btnTrxCur.Text
                .AllocationRate = Me.txtAllocRate.Text
                .AllocationAmountLC = AmountLC
                .AllocationAmountTC = AmountTC
                .CreationDate = Now.Date
                .CreatedBy = Global1.GLBUserId
                .AmendDate = Now.Date
                .AmendBy = Global1.GLBUserId
                If Not .Save Then
                    Throw Exx
                End If
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function SaveExtraLines(ByVal TrxnCode As cFiTrxnCodes) As Boolean
        Dim DC As String = ""
        Dim AccountCode As String = ""
        Dim PeriodCode As String = ""
        Dim Currency As String = ""
        Dim CurrencyRate As String = ""
        Dim AmountTC As Double = 0
        Dim AmoutLC As Double = 0
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Dim JC As New cJournalCode(TrxnCode.JouCode)
        Dim i As Integer
        Dim Discount As Double = 0
        Dim DiscountVAT As Double = 0
        Dim Amount As Double = 0
        Dim VatRate As Double = 0
        Dim VAT As Double = 0
        Try
            PeriodCode = Global1.Business.GetPeriodCode(Utils.ChangeMaskedFields(Me.MSKTxtPostDate))
            Currency = Me.btnTrxCur.Text
            CurrencyRate = Me.txtCurRate.Text

            Select Case TrxnCode.GroupCode

                Case "1101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                            CASH SALES
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeHeader
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - discountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'SALES
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VATRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VATRate / 100)) / (1 + (VATRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                    'DEBTOR 1
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DEBTOR 2
                    DC = "C"
                    'Header:TotalTrxn
                    AccountCode = Me.GLBBusPrt.AccountCode
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                Case "1102"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                            CASH REFUND
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeHeader
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'SALES
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                    'DEBTOR 1
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DEBTOR 2
                    DC = "C"
                    'Header:TotalTrxn
                    AccountCode = Me.GLBBusPrt.AccountCode
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                Case "1103"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                            CREDIT SALES
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'DEBTOR
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn

                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "U", AmountTC) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'SALES
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                Case "1104"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                            CREDIT NOTE
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'DEBTOR
                    DC = "C"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'SALES
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                Case "2101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                RECEIPTS
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        'Lines:LineTotalTC
                        AmountTC = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        'Lines: LineDiscValTC + OverAllDiscValTC
                        Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'DEBTOR 1
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = Me.GLBBusPrt.AccountCode
                        'Lines: LineDiscValTC + OverAllDiscValTC+ LineTotalTC
                        Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        AmountTC = Amount + Discount
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next

                Case "3101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                ADJUSTMENTS
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'DEBTOR
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'OTHER
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        'Lines: LineDiscValTC + OverAllDiscValTC+ LineTotalTC
                        Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        AmountTC = Amount
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next
                    

                Case "5101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                CASH PURCHASE
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeHeader
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'PURCH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                    'CREDITOR 1
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'CREDITOR 2
                    DC = "C"
                    'Header:TotalTrxn
                    AccountCode = Me.GLBBusPrt.AccountCode
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                Case "5102"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                CASH REFUND
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeHeader
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'PURCH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                    'CREDITOR 1
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'CREDITOR 2
                    DC = "C"
                    'Header:TotalTrxn
                    AccountCode = Me.GLBBusPrt.AccountCode
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                Case "5103"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                CREDIT PURCHASE
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CREDITOR
                    DC = "C"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "U", AmountTC) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'PURCH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "D"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                Case "5104"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                CREDIT NOTE
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CREDIT NOT
                    DC = "D"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        If GlbHeader.IsVatIncluded = "Y" Then
                            'Lines: LineDiscValTC - LineVatValTC + OverAllDiscValTC - OverAllDiscVATValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                            DiscountVAT = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT)
                            Discount = Discount - DiscountVAT
                        Else
                            'Lines: LineDiscValTC + OverAllDiscValTC
                            Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        End If
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'PURCH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        If GlbHeader.IsVatIncluded = "Y" Then
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                            VatRate = MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate)
                            Amount = Amount - ((Amount * (VatRate / 100)) / (1 + (VatRate / 100)))
                        Else
                            Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_Amount)
                        End If
                        If Amount <> 0 Then
                            AmountTC = Amount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'VAT
                    DC = "C"
                    AccountCode = TrxnCode.AccountCodeVAT
                    'Header:TotalVATTrxn
                    VAT = GlbHeader.TotalVATTrxn
                    If VAT <> 0 Then
                        AmountTC = VAT
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                            Throw Exx
                        End If
                    End If
                Case "6101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                PAYMENTS
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CASH
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        'Lines:LineTotalTC
                        AmountTC = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next
                    'DISCOUNT
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = TrxnCode.AccountCodeDiscount
                        'Lines: LineDiscValTC + OverAllDiscValTC
                        Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        If Discount <> 0 Then
                            AmountTC = Discount
                            If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                                Throw Exx
                            End If
                        End If
                    Next
                    'CREDITOR 1
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "D"
                        AccountCode = Me.GLBBusPrt.AccountCode
                        'Lines: LineDiscValTC + OverAllDiscValTC+ LineTotalTC
                        Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        Discount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc) + MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc)
                        AmountTC = Amount + Discount
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next

                Case "7101"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '                                ADJUSTMENTS
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'CREDITOR
                    DC = "C"
                    AccountCode = Me.GLBBusPrt.AccountCode
                    'Header:TotalTrxn
                    AmountTC = GlbHeader.TotalTrxn
                    If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, 0, False, "A", 0) Then
                        Throw Exx
                    End If
                    'OTHER
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        DC = "C"
                        AccountCode = MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode)
                        'Lines: LineDiscValTC + OverAllDiscValTC+ LineTotalTC
                        Amount = MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal)
                        AmountTC = Amount
                        If Not Me.SaveToFiTxAccountLines(JC, DC, AccountCode, PeriodCode, AmountTC, Currency, CurrencyRate, i, True, "A", 0) Then
                            Throw Exx
                        End If
                    Next

            End Select
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag

    End Function
    Private Function SaveToFiTxAccountLines(ByVal JC As cJournalCode, ByVal DC As String, ByVal AccountCode As String, ByVal PeriodCode As String, ByVal Amount As Double, ByVal CurrencyCode As String, ByVal CurrencyRate As Double, ByVal LineIndex As Integer, ByVal UseLine As Boolean, ByVal Allocstatus As String, ByVal UnAllocAmountTC As Double) As Boolean
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            Dim AccLine As New cAccountLines

            With AccLine
                .Id = 0
                .JournalCode = JC.Code
                Dim ReferenceNumber As String
                ReferenceNumber = Global1.Business.GetJournalCodeNextReferenceNo(JC)
                .JournalNumber = ReferenceNumber
                '    If Reversal Then
                '        .JournalLineNo = (MyDs.Tables(0).Rows.Count) + i + 1
                '    Else
                '        .JournalLineNo = i + 1
                '    End If
                .JournalLineNo = 1
                .DocRef = ""
                .AltRef = ""
                .AccountCode = AccountCode
                .BusPrtCode = Me.txtBusPartnerCode.Text
                '    If Reversal Then
                '        .PeriodCode = Me.GLBReversePeriod.Code
                '        .AllocPeriod = Me.GLBReversePeriod.Code
                '        .DocDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DocDate))
                '        .PostDate = Me.GLBReversePeriod.FromDate
                '        .DueDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DueDate))
                '        .DrCr = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_DrCr))
                '        If .DrCr = "D" Then
                '            .DrCr = "C"
                '        ElseIf .DrCr = "C" Then
                '            .DrCr = "D"
                '        End If
                '    Else
                .PeriodCode = PeriodCode 'Post date
                .AllocPeriod = PeriodCode
                .DocDate = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
                .PostDate = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
                .DueDate = Utils.ChangeMaskedFields(Me.MSKTxtDueDate)
                .DrCr = DC
                '    End If

                .AmountLocCur = Amount * CurrencyRate
                .CurAlphaCode = CurrencyCode
                .AmountTrxCur = Amount
                .CurRate = CurrencyRate
                .TrxCurDecimal = 0 'not used

                '    'Loading Of Analysis
                If UseLine Then
                    .AcLAn1Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn1Code)))
                    .AcLAn2Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn2Code)))
                    .AcLAn3Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn3Code)))
                    .AcLAn4Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn4Code)))
                    .AcLAn5Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn5Code)))
                    .AcLAn6Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn6Code)))
                    .AcLAn7Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn7Code)))
                    .AcLAn8Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn8Code)))
                    .AcLAn9Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn9Code)))
                    .AcLAn10Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(LineIndex).Item(Me.Col_AcLAn10Code)))
                Else
                    .AcLAn1Code = "$"
                    .AcLAn2Code = "$"
                    .AcLAn3Code = "$"
                    .AcLAn4Code = "$"
                    .AcLAn5Code = "$"
                    .AcLAn6Code = "$"
                    .AcLAn7Code = "$"
                    .AcLAn8Code = "$"
                    .AcLAn9Code = "$"
                    .AcLAn10Code = "$"
                End If

                '"O" Outstanding
                '"P" 0 < Unaallocated < Amount
                '"A" Allocated

                .AllocStatus = Allocstatus
                .AllocRef = 0
                .UnAllocBalanceLC = UnAllocAmountTC * CurrencyRate
                .UnAllocBalanceTC = UnAllocAmountTC

                .AllocDate = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
                .Comment = ""
                .ExternalRef = 0 'Header REF
                .MyModule = 0 'FI
                .ModRef = GlbHeader.Id

                .CreationDate = Now.Date
                .CreatedBy = Global1.GLBUserId
                .AmendDate = Now.Date
                .AmendBy = Global1.GLBUserId
                If Not .Save Then
                    Throw Exx
                End If
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    Private Function CheckAllocationAmounts() As Boolean
        Dim Flag As Boolean = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 1: Transaction Currency = Business Partner Currency = Local Currency
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode = Me.btnTrxCur.Text And Global1.LocalCurencyCode = Me.btnBusCur.Text Then
            If Me.CBAllocated.CheckState = CheckState.Checked Then
                ' Sub Case 11: Selection of Allocation 
                If Me.txtAllocTotalAmount.Text = Me.txtTotal.Text Then
                    Flag = True
                Else
                    MsgBox("Allocation amount must be the same as Total Amount!" & Chr(13) & "Cannot Proceed with saving", MsgBoxStyle.Information)
                End If
            Else
                'Sub Case 12: No Allocation
                Flag = True
            End If
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 2: Transaction Currency = Local Currency , Allocation Currency = Business Partner Currency
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode = Me.btnTrxCur.Text And Me.GLBBusPrt.CurAlphaCode = Me.btnBusCur.Text Then
            Flag = True
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'CASE 3: Transaction Currency <> Local Currency , Transaction Currency = Allocation Currency = Business Partner Currency
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.LocalCurencyCode <> Me.btnTrxCur.Text And Me.btnTrxCur.Text = Me.btnBusCur.Text Then
            If Me.CBAllocated.CheckState = CheckState.Checked Then
                ' Sub Case 31: Selection of Allocation 
                If Me.txtAllocTotalAmount.Text = Me.txtTotal.Text Then
                    Flag = True
                Else
                    MsgBox("Allocation amount must be the same as Total Amount!" & Chr(13) & "Cannot Proceed with saving", MsgBoxStyle.Information)
                End If
            Else
                'Sub Case 32: No Allocation
                Flag = True
            End If
        End If

        Return Flag
    End Function
    Private Sub LoadFromGridToClass(ByVal HeaderId As Integer, ByVal LineCounter As Integer, ByRef Line As cFiTxTrxnLines)
        Dim i As Integer = LineCounter - 1
        With Line
            .Id = LineCounter
            .HdrId = HeaderId
            .AccCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode))
            .An1_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn1Code)))
            .An2_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn2Code)))
            .An3_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn3Code)))
            .An4_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn4Code)))
            .An5_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn5Code)))
            .An6_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn6Code)))
            .An7_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn7Code)))
            .An8_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn8Code)))
            .An9_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn9Code)))
            .An10_Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn10Code)))
            .Notes = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_Comments))
            .VatCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_VATCode))
            .VatRate = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_VATRate))
            .Amount = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_Amount))
            .Gross = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_Gross))
            .LneDisc = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineDisc))
            .LneDiscVAT = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscVAT))
            .LneDiscPerc = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineDiscPerc))
            .OverallDisc = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDisc))
            .OverallDiscVAT = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_OverAllDiscVAT))
            .LneTotal = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotal))
            .LneVAT = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotalVAT))
            .LneTotalLC = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotalLocal))
            .LneVATLC = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_LineTotalVATLocal))
            .TrxnTypeFactor = Me.GlbTrxnTypeFactor
            .Factor = Me.GlbFactor
        End With
    End Sub
    Private Function FindAnalysisCode(ByVal S As String) As String
        Dim RetValue As String = ""
        Dim Ar() As String
        If Trim(S) = "$" Then
            RetValue = "$"
        Else
            Ar = Split(Trim(S), "-")
            RetValue = Ar(0)
        End If
        Return RetValue
    End Function
    Private Sub ComboCurency_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCurency.Validated
        Dim Flag As Boolean = True
        Dim Str As String = ""
        If DoNotExecute Then Exit Sub
        If CType(Me.ComboCurency.SelectedItem, cAdMsCurrency).AlphaCode <> Global1.LocalCurencyCode Then
            If GLBBusPrt.CurAlphaCode <> "" Then
                If CType(Me.ComboCurency.SelectedItem, cAdMsCurrency).AlphaCode <> GLBBusPrt.CurAlphaCode Then
                    Str = GLBBusPrt.CurAlphaCode
                    Flag = False
                End If
            Else
                Flag = False
            End If
        End If
        If Not Flag Then
            If Str <> "" Then
                MsgBox("Alowed Currencies are " & Global1.LocalCurencyCode & " And " & Str & " Only", MsgBoxStyle.Critical)
            Else
                MsgBox("Alowed Currency is Only " & Global1.LocalCurencyCode, MsgBoxStyle.Critical)
            End If
            Me.ComboCurency.Focus()
        End If
    End Sub
    Private Sub ComboCurency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCurency.SelectedIndexChanged
        Dim Flag As Boolean = True
        Dim Str As String = ""
        If DoNotExecute Then Exit Sub
        FindCurrencyRate()
    End Sub
    Private Sub FindCurrencyRate()
        If Me.ComboCurency.Text <> "" Then
            Dim C As New cAdMsCurrency
            C = CType(Me.ComboCurency.SelectedItem, cAdMsCurrency)
            Dim Rate As Double
            Rate = Global1.Business.GetCurruncyRate(C.AlphaCode, Now.Date)
            Me.txtCurRate.Text = Format(Rate, "0.000000")
            Me.btnTrxCur.Text = C.AlphaCode
        End If
    End Sub
    Private Sub MSKTxtInvDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MSKTxtInvDate.TextChanged
        If Me.MSKTxtInvDate.MaskCompleted Then
            CalculateDueDate()
        Else
            Me.MSKTxtDueDate.Text = ""
        End If
    End Sub
    Private Sub CalculateDueDate()
        If Me.GLBDisableDueDate Then
            Me.MSKTxtDueDate.Text = Me.MSKTxtInvDate.Text
            Exit Sub
        End If
        Dim Flag As Boolean = False
        Dim D As Date
        If Me.GLBCreditProfile.Code <> "" Then
            If Me.MSKTxtInvDate.MaskCompleted Then
                Try
                    D = Utils.ChangeMaskedFields(Me.MSKTxtInvDate)
                    Flag = True
                Catch ex As Exception
                    Me.MSKTxtDueDate.Text = ""
                End Try
            Else
                Me.MSKTxtDueDate.Text = ""
            End If

            If Flag Then
                Dim DueDate As Date
                If GLBCreditProfile.CreditTerms = 1 Then
                    'InoiceDate + CreditDays
                    DueDate = DateAdd(DateInterval.Day, GLBCreditProfile.CreditDays, D)
                ElseIf GLBCreditProfile.CreditTerms = 2 Then
                    '1st day of InoiceDate Month + CreditDays
                    Dim Str As String
                    Dim MM As String
                    Dim YY As String
                    MM = Format(D, "MM")
                    YY = Format(D, "yyyy")
                    Str = MM & "/" & "01/" & YY
                    D = CDate(Str)
                    DueDate = DateAdd(DateInterval.Day, GLBCreditProfile.CreditDays, D)
                ElseIf GLBCreditProfile.CreditTerms = 3 Then
                    '1st day of InoiceDate Month + 1 month + CreditDays
                    D = DateAdd(DateInterval.Month, 1, D)
                    Dim Str As String
                    Dim MM As String
                    Dim YY As String
                    MM = Format(D, "MM")
                    YY = Format(D, "yyyy")
                    Str = MM & "/" & "01/" & YY
                    D = CDate(Str)
                    DueDate = DateAdd(DateInterval.Day, GLBCreditProfile.CreditDays, D)
                End If
                Me.MSKTxtDueDate.Text = Format(DueDate, "dd/MM/yyyy")
            Else
                Me.MSKTxtDueDate.Text = ""
            End If
        End If

    End Sub

    Private Sub BtnAllocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllocation.Click
        CallAllocation()
    End Sub
    Private Sub CallAllocation()
        Dim DC As String = ""
        Me.Cursor = Cursors.WaitCursor
        If Me.GLBBusPrt.Code <> "" Then
            Dim F As New FrmAdjustmentPaymentSelection
            F.Owner = Me
            If Not CheckDataSet(GlbDsAlloc) Then
                If Me.GlbTrxnType = Global1.FI_TrxnType_PAYMENTS Then
                    DC = "D"
                End If
                If Me.GlbTrxnType = Global1.FI_TrxnType_RECEIPTS Then
                    DC = "C"
                End If
                If Me.GlbTrxnType = Global1.FI_TrxnType_CUSTOMER_ADJ Then
                    DC = "C"
                End If
                If Me.GlbTrxnType = Global1.FI_TrxnType_SUPPLIER_ADJ Then
                    DC = "D"
                End If
                GlbDsAlloc = Global1.Business.GetJournalEntriesWithUnAllocBalance(Me.GLBBusPrt.Code, DC)
            End If
            F.LoadDataGrid(GlbDsAlloc)
            F.ShowDialog()

        Else
            MsgBox("Please Choose Valid Business Partner First", MsgBoxStyle.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CBAllocated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBAllocated.CheckedChanged
        If CBAllocated.CheckState = CheckState.Checked Then
            Me.txtAllocTotalAmount.ReadOnly = True
            Me.txtAllocTotalAmount.BackColor = SystemColors.Info
            Me.BtnAllocation.Enabled = True
        Else
            Me.txtAllocTotalAmount.ReadOnly = False
            Me.txtAllocTotalAmount.BackColor = SystemColors.Window
            Me.BtnAllocation.Enabled = False
        End If
    End Sub

  
    Private Sub txtAllocTotalAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllocTotalAmount.TextChanged
        CalculateAllocationRate()
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        CalculateAllocationRate()
    End Sub
    Private Sub CalculateAllocationRate()
        Dim Flag As Boolean = True
        If Me.btnBusCur.Text = Me.btnTrxCur.Text Then
            Me.txtAllocRate.Text = "1.00"
            Me.txtAllocRate.BackColor = SystemColors.Info
            Me.txtAllocRate.ReadOnly = True
        Else
            'Me.txtAllocRate.BackColor = SystemColors.Window
            'Me.txtAllocRate.ReadOnly = False

            Me.txtAllocRate.BackColor = SystemColors.Info
            Me.txtAllocRate.ReadOnly = True
            If Me.txtAllocTotalAmount.Text = "" Then
                Flag = False
            End If
            If Me.txtTotal.Text = "" Then
                Flag = False
            End If
            If Flag Then
                If Me.txtTotal.Text <> 0 And Me.txtAllocTotalAmount.Text <> 0 Then
                    Dim d As Double
                    d = Me.txtTotal.Text / Me.txtAllocTotalAmount.Text
                    Me.txtAllocRate.Text = Format(d, "0.000000")
                Else
                    Flag = False
                End If
            End If
            If Not Flag Then
                Me.txtAllocRate.Text = "0.000000"
            End If
        End If
    End Sub

   

   
    
End Class

