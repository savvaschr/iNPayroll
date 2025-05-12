Public Class FrmPrMsPeriods
    'testing VSS2005
    Dim Ar_Sequense() As TextBox
    Dim Ar_Txt() As TextBox
    Dim Ar_StartDate() As MaskedTextBox
    Dim Ar_EndDate() As MaskedTextBox
    Dim Ar_ComboStatus() As ComboBox
    Dim Ar_TxtNoOfDays() As TextBox
    Dim Ar_TxtNoOfUnits() As TextBox
    Dim Ar_TxtNoOfUnits2() As TextBox
    Dim Ar_ComboSIN() As ComboBox
    Dim Ar_ComboPayCat() As ComboBox
    Dim Ar_TxtDescL() As TextBox
    Dim Ar_TxtDescS() As TextBox
    Dim Ar_BtnEDC() As Button
    Public Ar_Earnings() As DataSet
    Public Ar_Deductions() As DataSet
    Public Ar_Contributions() As DataSet


    'Combo Definitions
    Dim DoNotEnter As Boolean = False
    Dim UpdateFlag As Boolean = False
    Dim CloseStatus As String = "C"
    Dim Openstatus As String = "O"
    Dim CloseValue As String = CloseStatus & " - Close"
    Dim OpenValue As String = Openstatus & " - Open"
    Dim NumberOfPeriods As Integer
    Dim NormalPaymentType As String = "k"
    Dim DsPeriodGroups As DataSet


    Private Sub FrmPrMsPeriods_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0

        LoadComboNumberOfPeriods()
        LoadComboYear()
        LoadComboPeriodGroups()

        Dim i As Integer
        For i = 0 To Me.ComboPeriodGroup.Items.Count - 1
            If CType(Me.ComboPeriodGroup.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year Then
                Me.ComboPeriodGroup.SelectedIndex = i
                Exit For
            End If
        Next

        Me.FiscalYearFROM.Focus()
    End Sub
    Private Sub LoadComboPeriodGroups()



        Dim i As Integer
        Dim ShowAllYears As Boolean = False

        If CBShowAllYears.CheckState = CheckState.Checked Then
            ShowAllYears = True
        Else
            ShowAllYears = False
        End If

        DsPeriodGroups = Global1.Business.GetAllPrMsPeriodGroupsOfUser(Global1.UserName, ShowAllYears, Global1.GLBCurrentYear)
        With Me.ComboPeriodGroup
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(DsPeriodGroups) Then
                For i = 0 To DsPeriodGroups.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodGroups(DsPeriodGroups.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub ComboPeriodGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboPeriodGroup.SelectedIndexChanged
        TryToLoadPeriods()
    End Sub
    Private Sub TryToLoadPeriods()
        If Trim(Me.ComboPeriodGroup.Text) <> "" Then
            Dim Group As String
            Dim Ds As DataSet
            Dim Count As Integer
            Dim Ptest As New cPrMsPeriodGroups
            Ptest = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups)
            Group = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
            Me.ComboYears.SelectedIndex = Me.ComboYears.FindStringExact(Ptest.Year)

            Debug.WriteLine(Ptest.DescriptionL)

            Ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(Group)
            Dim i As Integer
            If CheckDataSet(Ds) Then
                Count = Ds.Tables(0).Rows.Count
                Dim P1 As New cPrMsPeriodCodes(Ds.Tables(0).Rows(0))
                Dim P12 As New cPrMsPeriodCodes(Ds.Tables(0).Rows(11))
                Me.FiscalYearFROM.Text = Format(P1.DateFrom, "dd/MM/yyyy")
                Me.FiscalYearTo.Text = Format(P12.DateTo, "dd/MM/yyyy")
                If Count = 12 Then
                    Me.ComboNumberOfPeriods.SelectedIndex = Me.ComboNumberOfPeriods.FindStringExact("12")
                ElseIf Count = 13 Then
                    Me.ComboNumberOfPeriods.SelectedIndex = Me.ComboNumberOfPeriods.FindStringExact("13")
                ElseIf Count = 14 Then
                    Me.ComboNumberOfPeriods.SelectedIndex = Me.ComboNumberOfPeriods.FindStringExact("14")
                End If
                TryToCreateControls()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodCodes(Ds.Tables(0).Rows(i))
                    LoadPeriod(P, i)
                Next
                Me.btnCreateControls.Enabled = False
            Else
                Me.RemoveControls()
                Me.btnCreateControls.Enabled = True
            End If
        End If
    End Sub
    Private Sub LoadPeriod(ByVal Period As cPrMsPeriodCodes, ByVal index As Integer)
        With Period
            Me.Ar_Sequense(index).Text = .Sequence
            Dim PayCat As New cPrSsPaymentCategory(.PayCat_Code)
            Me.Ar_ComboPayCat(index).SelectedIndex = Me.Ar_ComboPayCat(index).FindStringExact(PayCat.ToString)
            Me.Ar_Txt(index).Text = .Code
            Me.Ar_StartDate(index).Text = Format(.DateFrom, "dd/MM/yyyy")
            Me.Ar_EndDate(index).Text = Format(.DateTo, "dd/MM/yyyy")
            Me.Ar_TxtDescL(index).Text = .DescriptionL
            Me.Ar_TxtDescS(index).Text = .DescriptionS
            Dim SIN As New cPrSsSocialInsPeriods(.SinPrdCode)
            Me.Ar_ComboSIN(index).SelectedIndex = Me.Ar_ComboSIN(index).FindStringExact(SIN.ToString)
            Me.Ar_TxtNoOfUnits(index).Text = Format(.PeriodUnits, "0.00")
            Me.Ar_TxtNoOfUnits2(index).Text = Format(.PeriodUnits2, "0.00")

            Dim StrStatus As String
            If .Status = "O" Then
                StrStatus = "O - Open"
            Else
                StrStatus = "C - Close"
            End If
            Me.Ar_ComboStatus(index).SelectedIndex = Me.Ar_ComboStatus(index).FindString(strStatus)
            Dim Ds As DataSet

            Ds = Global1.Business.GetAllPrMsPeriodEarnings(.Code, .PrdGrpCode)
            FixDSEarnings(Ds, index)

            Ds = Global1.Business.GetAllPrMsPeriodDeductions(.Code, .PrdGrpCode)
            FixDSDeductions(Ds, index)

            Ds = Global1.Business.GetAllPrMsPeriodContributions(.Code, .PrdGrpCode)
            FixDsContributions(Ds, index)

        End With
    End Sub

    Private Sub FixDSEarnings(ByVal Ds As DataSet, ByVal index As Integer)
        Dim i As Integer
        Dim k As Integer
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim PE As New cPrMsPeriodEarnings(Ds.Tables(0).Rows(i))
                If CheckDataSet(Me.Ar_Earnings(index)) Then
                    With Me.Ar_Earnings(index)
                        For k = 0 To .Tables(0).Rows.Count - 1
                            If PE.ErnCodCode = DbNullToString(.Tables(0).Rows(k).Item(1)) Then
                                .Tables(0).Rows(k).Item(0) = PE.Id
                                Debug.WriteLine(PE.Id)
                                If PE.IsActive = "Y" Then
                                    .Tables(0).Rows(k).Item(3) = 1
                                Else
                                    .Tables(0).Rows(k).Item(3) = 0
                                End If
                                Exit For
                            End If
                        Next
                    End With
                End If
            Next
        End If
    End Sub
    Private Sub FixDSDeductions(ByVal Ds As DataSet, ByVal index As Integer)
        Dim i As Integer
        Dim k As Integer
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim PD As New cPrMsPeriodDeductions(Ds.Tables(0).Rows(i))
                If CheckDataSet(Me.Ar_Deductions(index)) Then
                    With Me.Ar_Deductions(index)
                        For k = 0 To .Tables(0).Rows.Count - 1
                            If PD.DedCodCode = DbNullToString(.Tables(0).Rows(k).Item(1)) Then
                                .Tables(0).Rows(k).Item(0) = PD.Id
                                If PD.IsActive = "Y" Then
                                    .Tables(0).Rows(k).Item(3) = 1
                                Else
                                    .Tables(0).Rows(k).Item(3) = 0
                                End If
                                Exit For
                            End If
                        Next
                    End With
                End If
            Next
        End If
    End Sub
    Private Sub FixDSContributions(ByVal Ds As DataSet, ByVal index As Integer)
        Dim i As Integer
        Dim k As Integer
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim PC As New cPrMsPeriodContributions(Ds.Tables(0).Rows(i))
                If CheckDataSet(Me.Ar_Contributions(index)) Then
                    With Me.Ar_Contributions(index)
                        For k = 0 To .Tables(0).Rows.Count - 1
                            If PC.ConCodCode = DbNullToString(.Tables(0).Rows(k).Item(1)) Then
                                .Tables(0).Rows(k).Item(0) = PC.Id
                                If PC.IsActive = "Y" Then
                                    .Tables(0).Rows(k).Item(3) = 1
                                Else
                                    .Tables(0).Rows(k).Item(3) = 0
                                End If
                                Exit For
                            End If
                        Next
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub LoadComboNumberOfPeriods()
        With Me.ComboNumberOfPeriods
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("12")
            .Items.Add("13")
            .Items.Add("14")
            .SelectedIndex = 0
            .EndUpdate()
        End With
    End Sub
    Private Sub AddHandlersToControls()
        AddHandlersTo_EndDate()
        AddHandlersTo_ComboStatus()
        AddHandlersTo_NumberOfUnits()
        AddHandlersTo_BtnEDC()
    End Sub
    Private Sub AddHandlersTo_EndDate()
        Dim i As Integer
        For i = 0 To Ar_EndDate.Length - 1
            AddHandler CType(Ar_EndDate(i), MaskedTextBox).TextChanged, AddressOf EndDate_TextChanged
            AddHandler CType(Ar_EndDate(i), MaskedTextBox).KeyUp, AddressOf EndDate_KeyUp
        Next
    End Sub
    Private Sub AddHandlersTo_NumberOfUnits()
        Dim i As Integer
        For i = 0 To Me.Ar_TxtNoOfUnits.Length - 1
            AddHandler CType(Me.Ar_TxtNoOfUnits(i), TextBox).KeyPress, AddressOf NumericKeyPress
            AddHandler CType(Me.Ar_TxtNoOfUnits(i), TextBox).Leave, AddressOf NumericOnLeave
            Me.Ar_TxtNoOfUnits(i).Text = 0


            AddHandler CType(Me.Ar_TxtNoOfUnits2(i), TextBox).KeyPress, AddressOf NumericKeyPress
            AddHandler CType(Me.Ar_TxtNoOfUnits2(i), TextBox).Leave, AddressOf NumericOnLeave
            Me.Ar_TxtNoOfUnits2(i).Text = 0
        Next
    End Sub
    Private Sub AddHandlersTo_BtnEDC()
        Dim i As Integer
        For i = 0 To Ar_BtnEDC.Length - 1
            AddHandler CType(Ar_BtnEDC(i), Button).Click, AddressOf btnEDC_Click
        Next
    End Sub

    Private Sub AddHandlersTo_ComboStatus()
        Dim i As Integer
        For i = 0 To Me.Ar_ComboStatus.Length - 1
            AddHandler CType(Ar_ComboStatus(i), ComboBox).KeyUp, AddressOf ComboStatus_KeyUp
        Next
    End Sub
    Private Sub LoadComboYear()
        Dim i As Integer
        With ComboYears
            .BeginUpdate()
            .Items.Clear()
            For i = 2000 To 2100
                .Items.Add(i.ToString)
            Next
            .EndUpdate()
            .SelectedIndex = ComboYears.FindStringExact(Now.Year.ToString)
        End With
    End Sub
#Region "Controls Creation"

    Private Sub CreateControls(ByVal N As Integer)
        'Dim N As Integer
        'N = Global1.NumberOfFiscalPeriods
        Dim Dif1 As Integer = 20
        Dim Dif2 As Integer = 20
        Dim X As Integer = 5
        Dim X2 As Integer = 5
        Dim ORIGINALTOP = 123
        ReDim Ar_Sequense(N)
        ReDim Ar_Txt(N)
        ReDim Ar_StartDate(N)
        ReDim Ar_EndDate(N)
        ReDim Ar_ComboStatus(N)
        ReDim Ar_TxtNoOfDays(N)
        ReDim Ar_TxtNoOfUnits(N)
        ReDim Ar_TxtNoOfUnits2(N)
        ReDim Ar_ComboSIN(N)
        ReDim Ar_TxtDescL(N)
        ReDim Ar_TxtDescS(N)
        ReDim Ar_ComboPayCat(N)
        ReDim Ar_BtnEDC(N)
        ReDim Ar_Earnings(N)
        ReDim Ar_Deductions(N)
        ReDim Ar_Contributions(N)

        'TextBox Sequense
        Dim TextTop As Integer
        Dim TextLeft As Integer = Me.txtSequense.Left
        Me.txtSequense.Top = OriginalTop - Dif1
        Dim i As Integer
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtSequense.Size
            TextTop = OriginalTop + ((txtSequense.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "S_" & i + 1
            S.Text = i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Ar_Sequense(i) = S
            S.ReadOnly = True
            S.BackColor = Color.Yellow
        Next
        'TextBox
        TextTop = 0
        TextLeft = Me.txtP1.Left
        Me.txtP1.Top = OriginalTop - Dif1

        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtP1.Size
            TextTop = OriginalTop + ((txtP1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "P_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Ar_Txt(i) = S
            S.ReadOnly = True
            S.BackColor = Color.Yellow
        Next

        'Text Box 2
        Dim TextTop2 As Integer
        Dim TextLeft2 As Integer = Me.txtNOfDays.Left
        Me.txtNOfDays.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtNOfDays.Size
            TextTop2 = ORIGINALTOP + ((txtNOfDays.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft2, TextTop2)
            S.Name = "NOfDats_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtNoOfDays(i) = S
        Next

        'ComboBox

        Dim ComboTop As Integer
        Dim ComboLeft As Integer = Me.ComboStatus1.Left
        Me.ComboStatus1.Top = ORIGINALTOP - Dif2
        For i = 0 To N
            Dim S As New ComboBox
            S.Size = ComboStatus1.Size
            S.FormattingEnabled = True
            S.DropDownStyle = ComboBoxStyle.DropDownList
            ComboTop = ORIGINALTOP + ((txtP1.Height + X) * i) + Dif2
            S.Location = New System.Drawing.Point(ComboLeft, ComboTop)
            S.Name = "ComboStatus_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)

            Ar_ComboStatus(i) = S
            S.Tag = i
        Next
        'TextBox Desc Long
        TextTop = 0
        TextLeft = Me.txtDescL.Left
        Me.txtDescL.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtDescL.Size
            TextTop = ORIGINALTOP + ((txtDescL.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "TxtDescL_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtDescL(i) = S
            S.ReadOnly = False
            S.BackColor = SystemColors.Window
        Next

        'TextBox Desc Short
        TextTop = 0
        TextLeft = Me.txtDescS.Left
        Me.txtDescS.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtDescS.Size
            TextTop = ORIGINALTOP + ((txtDescS.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "TxtDescS_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtDescS(i) = S
            S.ReadOnly = False
            S.BackColor = SystemColors.Window
        Next

        'ComboBox SIN Period Codes
        ComboTop = 0
        ComboLeft = Me.ComboSIN.Left
        Me.ComboSIN.Top = ORIGINALTOP - Dif2
        For i = 0 To N
            Dim S As New ComboBox
            S.Size = ComboSIN.Size
            S.FormattingEnabled = True
            S.DropDownStyle = ComboBoxStyle.DropDownList
            ComboTop = ORIGINALTOP + ((txtP1.Height + X) * i) + Dif2
            S.Location = New System.Drawing.Point(ComboLeft, ComboTop)
            S.Name = "ComboSIN_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_ComboSIN(i) = S
            S.Tag = i
        Next
        'ComboBox Type
        ComboTop = 0
        ComboLeft = Me.ComboType.Left
        Me.ComboType.Top = ORIGINALTOP - Dif2
        For i = 0 To N
            Dim S As New ComboBox
            S.Size = ComboType.Size
            S.DropDownWidth = 120
            S.FormattingEnabled = True
            S.DropDownStyle = ComboBoxStyle.DropDownList
            ComboTop = ORIGINALTOP + ((txtP1.Height + X) * i) + Dif2
            S.Location = New System.Drawing.Point(ComboLeft, ComboTop)
            S.Name = "ComboType_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_ComboPayCat(i) = S
            S.Tag = i
        Next

        'TextBox Number Of Units
        TextTop = 0
        TextLeft = Me.txtUnits.Left
        Me.txtUnits.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtUnits.Size
            TextTop = ORIGINALTOP + ((txtUnits.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "TxtUnits_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtNoOfUnits(i) = S
            S.ReadOnly = False
            S.BackColor = SystemColors.Window
        Next



        'TextBox Number Of Units2
        TextTop = 0
        TextLeft = Me.txtUnits2.Left
        Me.txtUnits2.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtUnits2.Size
            TextTop = ORIGINALTOP + ((txtUnits2.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "TxtUnits2_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtNoOfUnits2(i) = S
            S.ReadOnly = False
            S.BackColor = SystemColors.Window
        Next

        'button EDC
        TextTop = 0
        TextLeft = Me.btnEDC.Left
        Me.btnEDC.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New Button
            S.Size = btnEDC.Size
            TextTop = ORIGINALTOP + ((txtP1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "BtnEDC_" & i + 1
            S.Visible = True
            S.Text = "EDC"
            Me.Controls.Add(S)
            Me.Ar_BtnEDC(i) = S
            S.BackColor = SystemColors.GradientActiveCaption
        Next

        'MaskedTextBox1
        Dim MaskTop1 As Integer
        Dim MaskLeft1 As Integer = Me.StartDate1.Left
        Me.StartDate1.Top = ORIGINALTOP - Dif1
        For i = 0 To N

            Dim S As New MaskedTextBox
            S.Size = StartDate1.Size
            MaskTop1 = ORIGINALTOP + ((StartDate1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(MaskLeft1, MaskTop1)
            S.Visible = True
            S.Mask = "00/00/0000"
            S.Name = "StartDate_" & i + 1
            S.ValidatingType = GetType(Date)
            Me.Controls.Add(S)
            Ar_StartDate(i) = S
            S.Tag = i
            If i = 0 Then
                S.ReadOnly = True
                S.BackColor = Color.Yellow
            End If
        Next
        'MaskedTextBox2
        Dim MaskTop2 As Integer
        Dim MaskLeft2 As Integer = Me.EndDate1.Left
        Me.EndDate1.Top = ORIGINALTOP - Dif1
        For i = 0 To N
            Dim S As New MaskedTextBox
            S.Size = EndDate1.Size
            MaskTop2 = ORIGINALTOP + ((EndDate1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(MaskLeft2, MaskTop2)
            S.Visible = True
            S.Mask = "00/00/0000"
            S.Name = "EndDate_" & i + 1
            S.ValidatingType = GetType(Date)
            Me.Controls.Add(S)
            Ar_EndDate(i) = S
            S.Tag = i
            If i = 11 Then
                S.ReadOnly = True
                'S.BackColor = SystemColors.Info
                S.BackColor = Color.Yellow
            End If
        Next

        For i = 0 To Me.Ar_ComboStatus.Length - 1
            With CType(Me.Ar_ComboStatus(i), ComboBox)
                .BeginUpdate()
                .Items.Add(OpenValue)
                .Items.Add(CloseValue)
                .SelectedIndex = 0
                .EndUpdate()
            End With
        Next

       

        Dim k As Integer
        Dim Ds As New DataSet
        Ds = Global1.Business.GetAllPrSsSocialInsPeriods
        Dim SinPrd As New cPrSsSocialInsPeriods
        For k = 0 To Me.Ar_ComboSIN.Length - 1
            With CType(Me.Ar_ComboSIN(k), ComboBox)
                .BeginUpdate()
                .Items.Clear()
                If CheckDataSet(Ds) Then
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        SinPrd = New cPrSsSocialInsPeriods(Ds.Tables(0).Rows(i))
                        .Items.Add(SinPrd)
                    Next
                    .SelectedIndex = 0
                End If
                .EndUpdate()
            End With
        Next
        Dim Period_N As New cPrSsPaymentCategory(Global1.GLB_PeriodCategory_Normal)
        Dim Period_13 As New cPrSsPaymentCategory(Global1.GLB_PeriodCategory_13)
        Dim Period_14 As New cPrSsPaymentCategory(Global1.GLB_PeriodCategory_14)
        Ds = Global1.Business.AG_GetAllPrSsPaymentCategory

        Dim PayCat As New cPrSsPaymentCategory
        For k = 0 To Me.Ar_ComboPayCat.Length - 1
            With CType(Me.Ar_ComboPayCat(k), ComboBox)
                .BeginUpdate()
                .Items.Clear()
                If CheckDataSet(Ds) Then
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        PayCat = New cPrSsPaymentCategory(Ds.Tables(0).Rows(i))
                        .Items.Add(PayCat)
                    Next
                    If k <= 11 Then
                        .SelectedIndex = .FindStringExact(Period_N.ToString)
                    ElseIf k = 12 Then
                        .SelectedIndex = .FindStringExact(Period_13.ToString)
                    ElseIf k = 13 Then
                        .SelectedIndex = .FindStringExact(Period_14.ToString)
                    End If
                End If
                .EndUpdate()
            End With
        Next
        
        Dim TemplateGroup As String = ""
        TemplateGroup = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).TemGrpCode

        

        For i = 0 To Me.Ar_Earnings.Length - 1
            Dim DsEarnings As New DataSet
            DsEarnings = Global1.Business.GetAllPrMsTemplateEarningsByTemplateGroup(TemplateGroup)
            Ar_Earnings(i) = DsEarnings
        Next
        For i = 0 To Me.Ar_Deductions.Length - 1
            Dim DsDeductions As New DataSet
            DsDeductions = Global1.Business.GetAllPrMsTemplateDeductionsByTemplateGroup(TemplateGroup)
            Ar_Deductions(i) = DsDeductions
        Next
        For i = 0 To Me.Ar_Contributions.Length - 1
            Dim DsContributions As New DataSet
            DsContributions = Global1.Business.GetAllPrMsTemplateContributionsByTemplateGroup(TemplateGroup)
            Ar_Contributions(i) = DsContributions
        Next

        Me.ComboYears.TabIndex = 0
        Me.FiscalYearFROM.TabIndex = 1
        Me.FiscalYearTo.TabIndex = 2

        Me.FiscalYearFROM.Focus()
    End Sub

#End Region
    Private Sub FillPeriodsWithValues()
        If Me.FiscalYearFROM.MaskCompleted Then
            Dim D1 As Date
            Dim D2 As Date
            Try
                D1 = Utils.ChangeMaskedFields(Me.FiscalYearFROM)
                D2 = Utils.ChangeMaskedFields(Me.FiscalYearTo)
                'If D1.Year.ToString = Me.ComboYears.Text.ToString Then
                If Me.FiscalYearTo.MaskCompleted Then
                    Try
                        'If D2.Year.ToString = Me.ComboYears.Text.ToString Then
                        If D1 >= D2 Then
                            MsgBox("End Date of Fiscal Year Must be Grater than Start Date", MsgBoxStyle.Critical)
                        End If
                        InitializePeriods()
                        'Else
                        'MsgBox("End Date must belong to the selected Fiscal Year", MsgBoxStyle.Critical)
                        'Me.FiscalYearTo.Focus()
                        'End If
                    Catch ex As Exception
                        MsgBox("Please type a valid End Date of Fiscal Year", MsgBoxStyle.Critical)
                        Me.FiscalYearTo.Focus()
                    End Try
                End If
                'Else
                'MsgBox("Start Date must belong to the selected Fiscal Year", MsgBoxStyle.Critical)
                'Me.FiscalYearFROM.Focus()
                'End If
            Catch ex As Exception
                MsgBox("Please type a valid Start Date of Fiscal Year", MsgBoxStyle.Critical)
                Me.FiscalYearFROM.Focus()
            End Try

        End If
    End Sub
    Private Sub InitializePeriods()
        Dim i As Integer
        Dim S As String
        For i = 0 To Ar_Txt.Length - 1
            'If i = Ar_Txt.Length - 1 Then
            '    S = ComboYears.Text.ToString & "99"
            'Else
            S = ComboYears.Text.ToString & (i + 1).ToString.PadLeft(2, "0")
            ' End If
            CType(Ar_Txt(i), TextBox).Text = S
        Next

        For i = 0 To Ar_StartDate.Length - 1
            If i = 0 Then
                S = FiscalYearFROM.Text
            ElseIf i = 11 Or i = 12 Or i = 13 Then
                S = FiscalYearFROM.Text
            Else
                S = ""
            End If
            CType(Ar_StartDate(i), MaskedTextBox).Text = S
        Next

        For i = 0 To Ar_EndDate.Length - 1
            DoNotEnter = True
            If i = 11 Or i = 12 Or i = 13 Then
                S = FiscalYearTo.Text
                '  CType(Ar_EndDate(i), MaskedTextBox).BackColor = Color.Yellow
                '  CType(Ar_EndDate(i), MaskedTextBox).ReadOnly = True
            Else
                CType(Ar_EndDate(i), MaskedTextBox).BackColor = SystemColors.Window
                CType(Ar_EndDate(i), MaskedTextBox).ReadOnly = False
                S = ""
            End If
            CType(Ar_EndDate(i), MaskedTextBox).Text = S
            DoNotEnter = False
        Next
        For i = 0 To Ar_ComboStatus.Length - 1
            CType(Ar_ComboStatus(i), ComboBox).SelectedIndex = 1
        Next
        For i = 0 To Ar_TxtNoOfDays.Length - 1
            CType(Ar_TxtNoOfDays(i), TextBox).Text = ""
            CType(Ar_TxtNoOfDays(i), TextBox).BackColor = SystemColors.Window
            CType(Ar_TxtNoOfDays(i), TextBox).ReadOnly = False
        Next
        CalculateDates()

    End Sub
    Private Sub CalculateDates()
        Dim S As String
        Dim i As Integer
        Dim D As Date
        S = "01/01/" & Me.ComboYears.Text
        If Me.FiscalYearFROM.Text = S Then
            S = "31/12/" & Me.ComboYears.Text
            If Me.FiscalYearTo.Text = S Then
                D = Utils.ChangeMaskedFields(Me.FiscalYearFROM)
                For i = 0 To NumberOfPeriods
                    If i <= 11 Then
                        D = DateAdd(DateInterval.Month, 1, D)
                        If i <> 11 Then
                            Me.Ar_StartDate(i + 1).Text = Format(D, "dd/MM/yyyy")
                        End If
                        D = DateAdd(DateInterval.Day, -1, D)
                        Me.DoNotEnter = True
                        Me.Ar_EndDate(i).Text = ""
                        Me.DoNotEnter = False
                        Me.Ar_EndDate(i).Text = Format(D, "dd/MM/yyyy")
                        D = DateAdd(DateInterval.Day, +1, D)
                    ElseIf i = 12 Then
                        Me.DoNotEnter = True
                        Me.Ar_EndDate(i).Text = ""

                        Me.Ar_StartDate(i).Text = FiscalYearFROM.Text
                        Me.Ar_EndDate(i).Text = FiscalYearTo.Text
                        Me.DoNotEnter = False
                    ElseIf i = 13 Then
                        Me.DoNotEnter = True
                        Me.Ar_EndDate(i).Text = ""

                        Me.Ar_StartDate(i).Text = FiscalYearFROM.Text
                        Me.Ar_EndDate(i).Text = FiscalYearTo.Text
                        Me.DoNotEnter = False
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub ComboYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboYears.SelectedIndexChanged
        Exit Sub
        Dim Year As String
        Dim ds As DataSet
        Year = Me.ComboYears.Text
        'ds = Global1.Business.GetFiscalPeriodsOfYear(Year, False, False)
        If CheckDataSet(ds) Then
            '   LoadPeriods(ds)
            UpdateFlag = True
        Else
            ClearPeriodsFields()
            UpdateFlag = False
        End If
    End Sub
  
    Private Sub ClearPeriodsFields()
        Dim i As Integer
        Me.FiscalYearFROM.Text = ""
        Me.FiscalYearTo.Text = ""
        For i = 0 To Ar_Txt.Length - 1
            CType(Ar_Txt(i), TextBox).Text = ""
            Me.Ar_Txt(i).ReadOnly = True
            Me.Ar_Txt(i).BackColor = SystemColors.Info
        Next

        For i = 0 To Me.Ar_TxtNoOfDays.Length - 1
            CType(Ar_TxtNoOfDays(i), TextBox).Text = ""
            Me.Ar_TxtNoOfDays(i).ReadOnly = True
            Me.Ar_TxtNoOfDays(i).BackColor = SystemColors.Info
        Next

        For i = 0 To Ar_StartDate.Length - 1
            CType(Ar_StartDate(i), MaskedTextBox).Text = ""
            Me.Ar_StartDate(i).ReadOnly = True
            Me.Ar_StartDate(i).BackColor = SystemColors.Info
        Next

        For i = 0 To Ar_EndDate.Length - 1
            CType(Ar_EndDate(i), MaskedTextBox).Text = ""
            Me.Ar_EndDate(i).ReadOnly = True
            Me.Ar_EndDate(i).BackColor = SystemColors.Info
        Next

        For i = 0 To Ar_ComboStatus.Length - 1
            CType(Ar_ComboStatus(i), ComboBox).SelectedIndex = 0
        Next

    End Sub

    Private Sub EndDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub
        Dim index As Integer
        Dim PrevDate As Date
        Dim CurrentDate As Date
        Dim CalcDate As Date
        index = CType(sender, MaskedTextBox).Tag
        If CType(sender, MaskedTextBox).MaskCompleted Then
            If CType(Me.Ar_StartDate(index), MaskedTextBox).MaskCompleted Then
                Try
                    If CType(Me.Ar_ComboPayCat(index).SelectedItem, cPrSsPaymentCategory).Code = Global1.GLB_PeriodCategory_Normal Then
                        PrevDate = Utils.ChangeMaskedFields(CType(Me.Ar_StartDate(index), MaskedTextBox))
                        CurrentDate = Utils.ChangeMaskedFields(CType(sender, MaskedTextBox))
                        If CurrentDate > PrevDate Then
                            CalcDate = DateAdd(DateInterval.Day, 1, CurrentDate)
                            '   'If index <= 10 Then
                            If index < 13 Then

                                If CType(Me.Ar_ComboPayCat(index + 1).SelectedItem, cPrSsPaymentCategory).Code = Global1.GLB_PeriodCategory_Normal Then
                                    CType(Me.Ar_StartDate(index + 1), MaskedTextBox).Text = Format(CalcDate, "dd/MM/yyyy")
                                Else
                                    If index = 11 Then
                                        If CType(Me.Ar_ComboPayCat(index + 1).SelectedItem, cPrSsPaymentCategory).Code = Global1.GLB_PeriodCategory_Normal Then
                                            CType(Me.Ar_StartDate(index + 1), MaskedTextBox).Text = Format(CalcDate, "dd/MM/yyyy")
                                        End If
                                    End If
                                    If index = 12 Then
                                        If CType(Me.Ar_ComboPayCat(index + 1).SelectedItem, cPrSsPaymentCategory).Code = Global1.GLB_PeriodCategory_Normal Then
                                            CType(Me.Ar_StartDate(index + 1), MaskedTextBox).Text = Format(CalcDate, "dd/MM/yyyy")
                                        End If
                                    End If
                                End If
                            End If
                            'Prevending Change of Index 12 and 13
                            '  '   If index <> 12 Or index <> 13 Then
                            ''ClearDatesFrom(index + 1)
                            ''End If
                            ''End If
                            Me.Ar_TxtNoOfDays(index).Text = DateDiff(DateInterval.Day, PrevDate, CurrentDate) + 1
                            CalculateSINMonth(index)
                        Else
                            MsgBox("End Date of Period " & CType(Me.Ar_Txt(index), TextBox).Text & " Must be Greater Than Start Date!", MsgBoxStyle.Critical)
                        End If
                    End If
                Catch ex As Exception
                    ' MsgBox("Please Fill End Date of Period " & CType(Me.Ar_Txt(index), TextBox).Text & " with a Valid Date!", MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("Please Fill End Date for Period " & CType(Me.Ar_Txt(index - 1), TextBox).Text & " First!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub CalculateSINMonth(ByVal index As Integer)
        If Me.Ar_EndDate(index).Text <> "" Then
            Dim D As Date
            Dim month As Integer
            D = Utils.ChangeMaskedFields(CType(Me.Ar_EndDate(index), MaskedTextBox))
            month = D.Month
            Me.Ar_ComboSIN(index).SelectedIndex = month - 1
        End If
    End Sub
    Private Sub ClearDatesFrom(ByVal index As Integer)
        Dim i As Integer
        For i = index To Me.Ar_EndDate.Length - 1
            If i <> Ar_EndDate.Length - 1 Then
                Me.Ar_EndDate(i).Text = ""
            End If
        Next
        For i = index + 1 To Me.Ar_StartDate.Length - 1
            If i <> Ar_StartDate.Length - 1 Then
                Me.Ar_StartDate(i).Text = ""
            End If
        Next
    End Sub
    Private Sub btnEDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New FrmPrMsPeriodEDC
        Dim s As String
        Dim Index As Integer
        Dim Label As String
        Dim Ar() As String
        s = CType(sender, Button).Name
        Ar = s.Split("_")
        Index = Ar(1) - 1
        Label = "Period: " & Me.Ar_Txt(Index).Text & "  " & Me.Ar_TxtDescL(Index).Text

        F.Owner = Me
        F.Index = Index
        F.LabelText = Label

        F.ShowDialog()
    End Sub
    Private Sub EndDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, MaskedTextBox).Tag
            Me.Ar_ComboStatus(index).Focus()
        End If
    End Sub

    Private Sub ComboStatus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, ComboBox).Tag
            If index + 1 < Ar_EndDate.Length - 1 Then
                Me.Ar_EndDate(index + 1).Focus()
            End If
        End If
    End Sub
    Private Sub btnCreateControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateControls.Click
        TryToCreateControls()
    End Sub
    Private Sub TryToCreateControls()
        RemoveControls()
        NumberOfPeriods = Me.ComboNumberOfPeriods.Text - 1
        Me.CreateControls(NumberOfPeriods)
        AddHandlersToControls()
        FillPeriodsWithValues()
    End Sub
    Private Sub RemoveControls()
        If NumberOfPeriods = 0 Then Exit Sub
        Dim i As Integer
        Try
            'Sequense
            For i = 0 To NumberOfPeriods
                Me.Controls.Remove(Me.Ar_Sequense(i))
                Me.Controls.Remove(Me.Ar_ComboPayCat(i))
                Me.Controls.Remove(Me.Ar_Txt(i))
                Me.Controls.Remove(Me.Ar_TxtNoOfDays(i))
                Me.Controls.Remove(Me.Ar_ComboStatus(i))
                Me.Controls.Remove(Me.Ar_TxtDescL(i))
                Me.Controls.Remove(Me.Ar_TxtDescS(i))
                Me.Controls.Remove(Me.Ar_ComboSIN(i))
                Me.Controls.Remove(Me.Ar_TxtNoOfUnits(i))
                Me.Controls.Remove(Me.Ar_TxtNoOfUnits2(i))
                Me.Controls.Remove(Me.Ar_StartDate(i))
                Me.Controls.Remove(Me.Ar_EndDate(i))
                Me.Controls.Remove(Me.Ar_BtnEDC(i))


            Next
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        TryToSave()
    End Sub
    Private Sub TryToSave()
        If ValidatePeriods() Then
            Dim Exx As New SystemException
            Try
                Dim i As Integer
                Dim k As Integer
                Dim Status As String = ""
                Dim S As String = ""
                Dim Ar() As String
                Dim GroupCode As String
                Dim Seq As Integer
                GroupCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
                Global1.Business.BeginTransaction()
                For i = 0 To NumberOfPeriods
                   
                    Dim Per As New cPrMsPeriodCodes(Me.Ar_Txt(i).Text, GroupCode)
                    With Per
                        '.Sequence = Me.Ar_Sequense(i).Text
                        .Sequence = Me.Ar_Sequense(i).Text


                        .Code = Me.Ar_Txt(i).Text
                        .PrdGrpCode = GroupCode
                        .PrdCod_Number = CStr(i + 1).PadLeft(2, "0")
                        'S = Me.Ar_TxtNoOfDays(i).Text
                        'If Not IsNumeric(S) Then
                        ' Me.Ar_TxtNoOfDays(i).Text = 0
                        ' S = 0
                        ' End If
                        '.NOfDays = CInt(S)
                        .DateFrom = Utils.ChangeMaskedFields(CType(Me.Ar_StartDate(i), MaskedTextBox))
                        .DateTo = Utils.ChangeMaskedFields(CType(Me.Ar_EndDate(i), MaskedTextBox))
                        .DescriptionL = Me.Ar_TxtDescL(i).Text
                        .DescriptionS = Me.Ar_TxtDescS(i).Text
                        Ar = Me.Ar_ComboStatus(i).Text.Split("-")
                        Status = Trim(Ar(0))
                        .Status = Status
                        .PeriodUnits = Me.Ar_TxtNoOfUnits(i).Text
                        .PeriodUnits2 = Me.Ar_TxtNoOfUnits2(i).Text
                        .SinPrdCode = CType(Me.Ar_ComboSIN(i).SelectedItem, cPrSsSocialInsPeriods).Code
                        .PayCat_Code = CType(Me.Ar_ComboPayCat(i).SelectedItem, cPrSsPaymentCategory).Code

                        If Not .Save() Then
                            Throw Exx
                        End If
                    End With
                Next
                Global1.Business.DeletePeriodEarnings(GroupCode)
                Global1.Business.DeletePeriodDeductions(GroupCode)
                Global1.Business.DeletePeriodContributions(GroupCode)

                'Saving Period Earnings
                For i = 0 To Me.Ar_Earnings.Length - 1
                    If CheckDataSet(Me.Ar_Earnings(i)) Then
                        With Me.Ar_Earnings(i).Tables(0)
                            For k = 0 To .Rows.Count - 1
                                Dim id As Integer
                                id = DbNullToInt(.Rows(k).Item(0))
                                Dim P As New cPrMsPeriodEarnings(id)
                                P.PrdCodCode = Me.Ar_Txt(i).Text
                                P.PrdgrpCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
                                P.ErnCodCode = DbNullToString(.Rows(k).Item(1))
                                If DbNullToInt(.Rows(k).Item(3)) = 1 Then
                                    P.IsActive = "Y"
                                Else
                                    P.IsActive = "N"
                                End If
                                If Not P.Save Then
                                    Throw Exx
                                End If
                            Next
                        End With
                    End If
                Next
                'Saving Period Deductions
                For i = 0 To Me.Ar_Deductions.Length - 1
                    If CheckDataSet(Me.Ar_Deductions(i)) Then
                        With Me.Ar_Deductions(i).Tables(0)
                            For k = 0 To .Rows.Count - 1
                                Dim id As Integer
                                id = DbNullToInt(.Rows(k).Item(0))
                                Dim P As New cPrMsPeriodDeductions(id)
                                P.PrdCodCode = Me.Ar_Txt(i).Text
                                P.PrdGrpCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
                                P.DedCodCode = DbNullToString(.Rows(k).Item(1))
                                If DbNullToInt(.Rows(k).Item(3)) = 1 Then
                                    P.IsActive = "Y"
                                Else
                                    P.IsActive = "N"
                                End If
                                If Not P.Save Then
                                    Throw Exx
                                End If
                            Next
                        End With
                    End If
                Next
                'Saving Period Contributions
                For i = 0 To Me.Ar_Contributions.Length - 1
                    If CheckDataSet(Me.Ar_Contributions(i)) Then
                        With Me.Ar_Contributions(i).Tables(0)
                            For k = 0 To .Rows.Count - 1
                                Dim id As Integer
                                id = DbNullToInt(.Rows(k).Item(0))
                                Dim P As New cPrMsPeriodContributions(id)
                                P.PrdCodCode = Me.Ar_Txt(i).Text
                                P.PrdGrpCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
                                P.ConCodCode = DbNullToString(.Rows(k).Item(1))
                                If DbNullToInt(.Rows(k).Item(3)) = 1 Then
                                    P.IsActive = "Y"
                                Else
                                    P.IsActive = "N"
                                End If
                                If Not P.Save Then
                                    Throw Exx
                                End If
                            Next
                        End With
                    End If
                Next

                If NumberOfPeriods = 12 Then
                    'Delete If Exists Period 14 of this Year
                    Dim Year As String
                    Dim PeriodCode As String
                    Year = Me.ComboYears.Text
                    PeriodCode = Year & "14"
                    Global1.Business.DeletePrMsPeriodEarnings(PeriodCode, GroupCode)
                    Global1.Business.DeletePrMsPeriodDeductions(PeriodCode, GroupCode)
                    Global1.Business.DeletePrMsPeriodContributions(PeriodCode, GroupCode)
                    Global1.Business.DeletePrMsPeriodCode(PeriodCode, GroupCode)
                ElseIf NumberOfPeriods = 11 Then
                    'Delete If Exists Period 13 of this Year
                    Dim Year As String
                    Dim PeriodCode As String
                    Year = Me.ComboYears.Text
                    For i = 13 To 14
                        PeriodCode = Year & i
                        Global1.Business.DeletePrMsPeriodEarnings(PeriodCode, GroupCode)
                        Global1.Business.DeletePrMsPeriodDeductions(PeriodCode, GroupCode)
                        Global1.Business.DeletePrMsPeriodContributions(PeriodCode, GroupCode)
                        Global1.Business.DeletePrMsPeriodCode(PeriodCode, GroupCode)
                    Next
                End If


                MsgBox("Changes are succefully saved", MsgBoxStyle.Information)
                Global1.Business.CommitTransaction()
                Me.TryToLoadPeriods()
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Function ValidatePeriods() As Boolean
        Dim Flag As Boolean = True

        Dim i As Integer
        For i = 0 To Me.Ar_StartDate.Length - 1
            If Not Ar_StartDate(i).MaskCompleted Then
                MsgBox("Please complete all Dates", MsgBoxStyle.Critical)
                Flag = False
                Exit For
            End If
        Next
        For i = 0 To Me.Ar_EndDate.Length - 1
            If Not Ar_EndDate(i).MaskCompleted Then
                MsgBox("Please complete all Dates", MsgBoxStyle.Critical)
                Flag = False
                Exit For
            End If
        Next

        Return Flag
    End Function

    'Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim index As Integer = 0
    '    Dim Sequence As String
    '    Dim PayCat_Code As String
    '    Dim code As String
    '    Dim DateFrom As String
    '    Dim DateTo As String
    '    Dim DescriptionL As String
    '    Dim DescriptionS As String
    '    Dim SinPrdCode As String
    '    Dim PeriodUnits As Double
    '    Dim status As String

    '    Sequence = Me.Ar_Sequense(index).Text
    '    Dim PayCat As New cPrSsPaymentCategory()
    '    PayCat = CType(Me.Ar_ComboPayCat(index).SelectedItem, cPrSsPaymentCategory)
    '    code = Me.Ar_Txt(index).Text
    '    DateFrom = Me.Ar_StartDate(index).Text
    '    DateTo = Me.Ar_EndDate(index).Text
    '    DescriptionL = Me.Ar_TxtDescL(index).Text
    '    DescriptionS = Me.Ar_TxtDescS(index).Text
    '    Dim SIN As New cPrSsSocialInsPeriods()
    '    SIN = CType(Me.Ar_ComboSIN(index).SelectedItem, cPrSsSocialInsPeriods)

    '    If Ar_ComboStatus(index).SelectedIndex.ToString = "O - Open" Then
    '        status = "O"
    '    Else
    '        status = "C"
    '    End If
    '    Dim Ds As DataSet

    '    'Ds = Global1.Business.GetAllPrMsPeriodEarnings(.Code)
    '    'FixDSEarnings(Ds, index)

    '    'Ds = Global1.Business.GetAllPrMsPeriodDeductions(.Code)
    '    'FixDSDeductions(Ds, index)

    '    'Ds = Global1.Business.GetAllPrMsPeriodContributions(.Code)
    '    'FixDSContributions(Ds, index)




    '    'Me.Ar_Sequense(index).Text = Sequence
    '    'Dim PayCat As New cPrSsPaymentCategory(.PayCat_Code)
    '    'Me.Ar_ComboPayCat(index).SelectedIndex = Me.Ar_ComboPayCat(index).FindStringExact(PayCat.ToString)
    '    'Me.Ar_Txt(index).Text = .Code
    '    'Me.Ar_StartDate(index).Text = Format(.DateFrom, "dd/MM/yyyy")
    '    'Me.Ar_EndDate(index).Text = Format(.DateTo, "dd/MM/yyyy")
    '    'Me.Ar_TxtDescL(index).Text = .DescriptionL
    '    'Me.Ar_TxtDescS(index).Text = .DescriptionS
    '    'Dim SIN As New cPrSsSocialInsPeriods(.SinPrdCode)
    '    'Me.Ar_ComboSIN(index).SelectedIndex = Me.Ar_ComboSIN(index).FindStringExact(SIN.ToString)
    '    'Me.Ar_TxtNoOfUnits(index).Text = Format(.PeriodUnits, "0.00")
    '    'Dim StrStatus As String
    '    'If .Status = "O" Then
    '    '    StrStatus = "O - Open"
    '    'Else
    '    '    StrStatus = "C - Close"
    '    'End If
    '    'Me.Ar_ComboStatus(index).SelectedIndex = Me.Ar_ComboStatus(index).FindString(StrStatus)
    '    'Dim Ds As DataSet

    '    'Ds = Global1.Business.GetAllPrMsPeriodEarnings(.Code)
    '    'FixDSEarnings(Ds, index)

    '    'Ds = Global1.Business.GetAllPrMsPeriodDeductions(.Code)
    '    'FixDSDeductions(Ds, index)

    '    'Ds = Global1.Business.GetAllPrMsPeriodContributions(.Code)
    '    'FixDSContributions(Ds, index)

    'End Sub

  

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEditSequence.Click
        'Global1.Business.FindTrxnHeadersofPeriodGroup()
        Dim i As Integer
        For i = 0 To Me.Ar_Sequense.Length - 1
            Me.Ar_Sequense(i).ReadOnly = False
        Next
    End Sub
   
    
   
   
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim F As New FrmUpdatePeriodEDC
        F.owner = Me
        F.showdialog()
    End Sub
    Public Function ActivateEDC(ByVal EDCCode As String, ByVal EDCType As String)
        Global1.Business.BeginTransaction()
        Dim F As Boolean = True

        Try


            Dim GroupCode As String
            Dim Exx As New System.Exception


            GroupCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
            Dim Group As New cPrMsPeriodGroups(GroupCode)
            Dim i As Integer


            Select Case EDCType
                Case "E"
                    Dim Ern As New cPrMsTemplateEarnings(Group.TemGrpCode, EDCCode)
                    If Ern.ErnCodCode = "" Or Ern.ErnCodCode Is Nothing Then
                        MsgBox("Invalid Earning Code", MsgBoxStyle.Critical)
                        Exit Function
                    End If
                    For i = 0 To NumberOfPeriods
                        Dim Per As New cPrMsPeriodCodes(Me.Ar_Txt(i).Text, GroupCode)
                        Dim P As New cPrMsPeriodEarnings(Per.Code, Per.PrdGrpCode, EDCCode)
                        If P.Id = 0 Then
                            P.PrdCodCode = Per.Code
                            P.PrdgrpCode = Per.PrdGrpCode
                            P.ErnCodCode = EDCCode
                            P.IsActive = "Y"
                            If Not P.Save Then
                                F = False
                                Throw Exx
                            End If
                        Else
                            P.IsActive = "Y"
                            If Not P.Save Then
                                F = False
                                Throw Exx
                            End If
                        End If
                    Next
                Case "D"
                    Dim Ded As New cPrMsTemplateDeductions(Group.TemGrpCode, EDCCode)
                    If Ded.DedCodCode = "" Or Ded.DedCodCode Is Nothing Then
                        MsgBox("Invalid Deduction Code", MsgBoxStyle.Critical)
                        Exit Function
                    End If
                    For i = 0 To NumberOfPeriods
                        Dim Per As New cPrMsPeriodCodes(Me.Ar_Txt(i).Text, GroupCode)
                        Dim P As New cPrMsPeriodDeductions(Per.Code, Per.PrdGrpCode, EDCCode)
                        If P.Id = 0 Then
                            P.PrdCodCode = Per.Code
                            P.PrdGrpCode = Per.PrdGrpCode
                            P.DedCodCode = EDCCode
                            P.IsActive = "Y"
                            If Not P.Save Then
                                F = False
                                Throw Exx
                            End If
                        Else
                            P.IsActive = "Y"
                            If Not P.Save Then
                                Throw Exx
                                F = False
                            End If
                        End If
                    Next
                Case "C"
                    Dim Con As New cPrMsTemplateContributions(Group.TemGrpCode, EDCCode)
                    If Con.ConCodCode = "" Or Con.ConCodCode Is Nothing Then
                        MsgBox("Invalid Contribution Code", MsgBoxStyle.Critical)
                        Exit Function
                    End If
                    For i = 0 To NumberOfPeriods
                        Dim Per As New cPrMsPeriodCodes(Me.Ar_Txt(i).Text, GroupCode)
                        Dim P As New cPrMsPeriodContributions(Per.Code, Per.PrdGrpCode, EDCCode)
                        If P.Id = 0 Then
                            P.PrdCodCode = Per.Code
                            P.PrdGrpCode = Per.PrdGrpCode
                            P.ConCodCode = EDCCode
                            P.IsActive = "Y"
                            If Not P.Save Then
                                Throw Exx
                                F = False
                            End If
                        Else
                            P.IsActive = "Y"
                            If Not P.Save Then
                                Throw Exx
                                F = False
                            End If
                        End If
                    Next
            End Select
            If F Then
                Global1.Business.CommitTransaction()
                MsgBox("Succesfull addition", MsgBoxStyle.Information)
            Else
                Global1.Business.Rollback()
            End If
        Catch ex As Exception
            Global1.Business.Rollback()
            MsgBox("Unable to Save Changes", MsgBoxStyle.Information)
        End Try


    End Function

   
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim AllowToProceed As Boolean = False

        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            AllowToProceed = True
        Else
            AllowToProceed = False
            Dim F As New FrmCompanyUsersPassword
            F.Owner = Me
            F.ShowDialog()

        End If
        If AllowToProceed Then
            Dim Percode As String
            Percode = InputBox("Please enter Period Code for Deletion")
            If Percode <> "" Then
                Dim GroupCode As String
                GroupCode = CType(Me.ComboPeriodGroup.SelectedItem, cPrMsPeriodGroups).Code
                Dim Per As New cPrMsPeriodCodes(Percode, GroupCode)
                If Per.Code <> "" Then
                    Dim Ans As New MsgBoxResult
                    Ans = MsgBox("Do you want to proceed with the Deletion of Period " & Per.Code & " " & Per.DescriptionL & " of Period Group " & Per.PrdGrpCode, MsgBoxStyle.YesNoCancel)
                    If Ans = MsgBoxResult.Yes Then
                        If Global1.Business.deletePeriodcode(Per) Then
                            MsgBox("Period is deleted", MsgBoxStyle.Information)
                        Else
                            MsgBox("Unable to Delete Period", MsgBoxStyle.Information)
                        End If
                    End If
                Else
                    MsgBox("There is no Valid Period with this code for this period group", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub CBShowAllYears_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShowAllYears.CheckedChanged
        Me.LoadComboPeriodGroups()
    End Sub

    Private Sub btnPeriodGroupSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodGroupSearch.Click
        Dim F As New FrmPeriodGroupSearch
        F.Owner = Me
        F.DsPeriodGroups = DsPeriodGroups
        F.CalledBy = 4
        F.ShowDialog()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("This action will set all units code the same as units codes of first Period, Proceed", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            Dim i As Integer
        Dim Units1 As Double = Ar_TxtNoOfUnits(0).Text

            For i = 0 To Ar_TxtNoOfUnits.Length - 1
                Me.Ar_TxtNoOfUnits(i).Text = Format(Units1, "0.00")
                Me.Ar_TxtNoOfUnits2(i).Text = Format(Units1, "0.00")
            Next
        End If
    End Sub
End Class