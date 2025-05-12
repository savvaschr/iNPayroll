Public Class frmPrMsEmployeeExtraDetails
    Public EmpCode As String
    Public EmpName As String
    Public Emp As cPrMsEmployees

    Dim tPrMsEmployeeExtraDetails As New cPrMsEmployeeExtraDetails
    Dim DG1Changing As Boolean = False
    Dim LoadingMe As Boolean = False
    Private Sub frmPrMsEmployeeExtraDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' LoadingMe = True
        Me.Top = 0
        Me.Left = 0
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        LoadMe()
        'LoadingMe = False
    End Sub
    Private Sub Initialize()
        LoadCombos()
        ' ClearMe()
        PutDecimalValidationOnTxts()
    End Sub
    'Private Function ValidateMe() As Boolean
    '    ClearErrors()
    '    Dim Flag As Boolean = True
    '    If Me.txtEmp_Code.Text = "" Then
    '        Flag = False
    '        Me.ErrEmp_Code.SetError(Me.txtEmp_Code, "Field is Required")
    '    End If
    '    If Me.txtPosCat_Code.Text = "" Then
    '        Flag = False
    '        Me.ErrPosCat_Code.SetError(Me.txtPosCat_Code, "Field is Required")
    '    End If
    '    If Me.txtPosRnk_Code.Text = "" Then
    '        Flag = False
    '        Me.ErrPosRnk_Code.SetError(Me.txtPosRnk_Code, "Field is Required")
    '    End If

    '    If Flag Then
    '        If Me.txtEmp_Code.Text <> "" Then
    '            If Not Me.txtEmp_Code.ReadOnly Then
    '                Dim tPrMsEmployeeExtraDetails As New cPrMsEmployeeExtraDetails(Trim(Me.txtEmp_Code.Text))
    '                If tPrMsEmployeeExtraDetails.Emp_Code <> "" Then
    '                    MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
    '                    Flag = False
    '                End If
    '            End If
    '        End If
    '    End If
    '    Return Flag
    'End Function
    Private Sub ClearMe()
        Me.txtEmp_Code.Text = ""
        Me.DateStartDateToPrevServ.Value = Now
        Try
            Me.ComboScale1.SelectedIndex = 0
        Catch ex As Exception

        End Try
        Try
            Me.ComboScale2.SelectedIndex = 0
        Catch ex As Exception

        End Try

        Try
            Me.ComboScale3.SelectedIndex = 0
        Catch ex As Exception

        End Try

        Me.DateRetirementDate63.Value = Now
        Me.DateRetirementDate65.Value = Now
        Me.DateComDate400Months.Value = Now
        Me.txtEmp_ExtraRatePerHour.Text = "0.00"
        Me.DateDOfNextRateIncrease.Value = Now
        Me.ComboIsTop.SelectedIndex = 0
        Me.ComboProFund.SelectedIndex = 0
        Me.ComboPenFund.SelectedIndex = 0
        Me.DateDOfStartPrFund.Value = Now
        Me.Combo10Percent.SelectedIndex = 0
    End Sub
    '
    Private Sub LoadCombos()
        LoadPrAnScale1()
        LoadPrAnScale2()
        LoadPrAnScale3()
    End Sub
    Private Sub LoadPrAnScale1()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrAnScales1
        If CheckDataSet(ds) Then
            Dim tPrAnScales1 As New cPrAnScales1
            With Me.ComboScale1
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnScales1 = New cPrAnScales1(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnScales1)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnScale2()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrAnScales2
        If CheckDataSet(ds) Then
            Dim tPrAnScales2 As New cPrAnScales2
            With Me.ComboScale2
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnScales2 = New cPrAnScales2(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnScales2)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnScale3()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrAnScales3
        If CheckDataSet(ds) Then
            Dim tPrAnScales3 As New cPrAnScales3
            With Me.ComboScale3
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnScales3 = New cPrAnScales3(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnScales3)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtEmp_ExtraRatePerHour.KeyPress, AddressOf NumericKeyPress
        AddHandler txtEmp_ExtraRatePerHour.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        'Me.ErrEmp_Code.SetError(Me.txtEmp_Code, "")
        'Me.ErrEmp_StartDateToPrevServ.SetError(Me.txtEmp_StartDateToPrevServ, "")
        'Me.ErrPosCat_Code.SetError(Me.txtPosCat_Code, "")
        'Me.ErrPosRnk_Code.SetError(Me.txtPosRnk_Code, "")
        'Me.ErrEmp_RetirementDate63.SetError(Me.txtEmp_RetirementDate63, "")
        'Me.ErrEmp_RetirementDate65.SetError(Me.txtEmp_RetirementDate65, "")
        'Me.ErrEmp_ComDate400Months.SetError(Me.txtEmp_ComDate400Months, "")
        'Me.ErrEmp_ExtraRatePerHour.SetError(Me.txtEmp_ExtraRatePerHour, "")
        'Me.ErrEmp_DOfNextRateIncrease.SetError(Me.txtEmp_DOfNextRateIncrease, "")
        'Me.ErrEmp_IsTop.SetError(Me.txtEmp_IsTop, "")
        'Me.ErrEmp_ProvidentFund.SetError(Me.txtEmp_ProvidentFund, "")
        'Me.ErrEmp_PensionFund.SetError(Me.txtEmp_PensionFund, "")
        'Me.ErrEmp_DOfStartPrFund.SetError(Me.txtEmp_DOfStartPrFund, "")
        'Me.ErrEmp_10PercentDecrease.SetError(Me.txtEmp_10PercentDecrease, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsEmployeeExtraDetails = New cPrMsEmployeeExtraDetails
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Me.TSBSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        TryToSave()
        Me.TSBSave.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TryToSave()
        '   If ValidateMe() Then
        Dim Update As Boolean = False
            Dim CS As Integer
            Try
                '  If Me.txtEmp_Code.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrMsEmployeeExtraDetails
                    .Emp_Code = CStr(Me.txtEmp_Code.Text)
                    .Emp_StartDateToPrevServ = DateStartDateToPrevServ.Value.Date
                .PosCat_Code = CType(Me.ComboScale1.SelectedItem, cPrAnScales1).Sc1_Code
                .PosRnk_Code = CType(Me.ComboScale2.SelectedItem, cPrAnScales2).Sc2_Code
                .Rnk_Code = CType(Me.ComboScale3.SelectedItem, cPrAnScales3).Sc3_Code
                .Emp_RetirementDate63 = DateRetirementDate63.Value.Date
                    .Emp_RetirementDate65 = DateRetirementDate65.Value.Date
                    .Emp_ComDate400Months = DateComDate400Months.Value.Date
                    .Emp_ExtraRatePerHour = CDbl(Me.txtEmp_ExtraRatePerHour.Text)
                    .Emp_DOfNextRateIncrease = DateDOfNextRateIncrease.Value.Date
                    .Emp_IsTop = ComboIsTop.Text
                    .Emp_ProvidentFund = ComboProFund.Text
                    .Emp_PensionFund = ComboPenFund.Text
                    .Emp_DOfStartPrFund = DateDOfStartPrFund.Value.Date
                    .Emp_10PercentDecrease = Combo10Percent.Text
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"

                        PKInputReadOnly(True)
                    Else
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        ' End If
    End Sub
    '

    '
    Public Sub LoadMe()
        If Not loadingme Then
            ClearMe()
        End If
        Me.txtEmp_Code.Text = EmpCode
        Me.txtEmployeeName.Text = EmpName
        LoadPrMsEmployeeExtraDetails(EmpCode)
    End Sub
    Private Sub LoadPrMsEmployeeExtraDetails(ByVal tEmp_Code As String)
        tPrMsEmployeeExtraDetails = New cPrMsEmployeeExtraDetails(tEmp_Code)

        Me.DateStartDateToPrevServ.Value = Emp.StartDate.Date

        If tPrMsEmployeeExtraDetails.Emp_Code <> "" Then
            With tPrMsEmployeeExtraDetails
                Me.DateStartDateToPrevServ.Value = .Emp_StartDateToPrevServ
                Dim Scal1 As New cPrAnScales1(.PosCat_Code)
                Dim Scal2 As New cPrAnScales2(.PosRnk_Code)
                Dim Scal3 As New cPrAnScales3(.Rnk_Code)

                Me.ComboScale1.SelectedIndex = Me.ComboScale1.FindStringExact(Scal1.ToString)
                Me.ComboScale2.SelectedIndex = Me.ComboScale2.FindStringExact(Scal2.ToString)
                Me.ComboScale3.SelectedIndex = Me.ComboScale3.FindStringExact(Scal3.ToString)
                Me.DateRetirementDate63.Value = .Emp_RetirementDate63
                Me.DateRetirementDate65.Value = .Emp_RetirementDate65
                Me.DateComDate400Months.Value = .Emp_ComDate400Months
                Me.txtEmp_ExtraRatePerHour.Text = Format(.Emp_ExtraRatePerHour, "0.0000")
                Me.DateDOfNextRateIncrease.Value = .Emp_DOfNextRateIncrease
                Me.ComboIsTop.SelectedIndex = ComboIsTop.FindStringExact(.Emp_IsTop)
                Me.ComboProFund.SelectedIndex = ComboProFund.FindStringExact(.Emp_ProvidentFund)
                Me.ComboPenFund.SelectedIndex = ComboPenFund.FindStringExact(.Emp_PensionFund)
                Me.DateDOfStartPrFund.Value = .Emp_DOfStartPrFund
                Me.Combo10Percent.SelectedIndex = Combo10Percent.FindStringExact(.Emp_10PercentDecrease)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub


    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete " & Me.txtEmp_Code.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrMsEmployeeExtraDetails.Delete(Trim(Me.txtEmp_Code.Text)) Then
                Me.lblSSStatus.Text = Me.txtEmp_Code.Text & " has been deleted"
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub LoadDataFromDG1(ByVal i As Integer)
    '    Me.ClearMe()
    '    Call ClearErrors()
    '    Me.lblSSStatus.Text = ""
    '    Me.txtEmp_Code.Text = DbNullToString(DG1.Item(0, i).Value)
    '    Me.txtEmp_StartDateToPrevServ.Text = DbNullToString(DG1.Item(1, i).Value)
    '    Me.txtPosCat_Code.Text = DbNullToString(DG1.Item(2, i).Value)
    '    Me.txtPosRnk_Code.Text = DbNullToString(DG1.Item(3, i).Value)
    '    Me.txtEmp_RetirementDate63.Text = DbNullToString(DG1.Item(4, i).Value)
    '    Me.txtEmp_RetirementDate65.Text = DbNullToString(DG1.Item(5, i).Value)
    '    Me.txtEmp_ComDate400Months.Text = DbNullToString(DG1.Item(6, i).Value)
    '    Me.txtEmp_ExtraRatePerHour.Text = DbNullToString(DG1.Item(7, i).Value)
    '    Me.txtEmp_DOfNextRateIncrease.Text = DbNullToString(DG1.Item(8, i).Value)
    '    Me.txtEmp_IsTop.Text = DbNullToString(DG1.Item(9, i).Value)
    '    Me.txtEmp_ProvidentFund.Text = DbNullToString(DG1.Item(10, i).Value)
    '    Me.txtEmp_PensionFund.Text = DbNullToString(DG1.Item(11, i).Value)
    '    Me.txtEmp_DOfStartPrFund.Text = DbNullToString(DG1.Item(12, i).Value)
    '    Me.txtEmp_10PercentDecrease.Text = DbNullToString(DG1.Item(13, i).Value)
    '    PKInputReadOnly(True)
    'End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtEmp_Code.ReadOnly = RO
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnExtraDetails(Me)
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnExtraDetails(Me)
    End Sub

    Private Sub ButtonAddScale1_Click(sender As Object, e As EventArgs) Handles ButtonAddScale1.Click

    End Sub

    Private Sub btnAutoCalc_Click(sender As Object, e As EventArgs) Handles btnAutoCalc.Click
        Dim Date63 As Date
        Dim Date65 As Date
        Dim DateStart400 As Date

        Date63 = DateAdd(DateInterval.Year, 63, Emp.BirthDate)
        Date65 = DateAdd(DateInterval.Year, 65, Emp.BirthDate)
        DateStart400 = DateAdd(DateInterval.Month, 400, Me.DateStartDateToPrevServ.Value.Date)

        Me.DateComDate400Months.Value = DateStart400
        Me.DateRetirementDate63.Value = Date63
        Me.DateRetirementDate65.Value = Date65

    End Sub
    Private Sub LoadDataSetToExcel()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        ds = Global1.Business.GetAllPrMsEmployeeExtraDetails

        HeaderStr.Add("Code")
        HeaderStr.Add("Employee Name")
        HeaderStr.Add("Status")
        HeaderStr.Add("Template Group")
        HeaderStr.Add("Social Ins. Number")
        HeaderStr.Add("Id. Card")
        HeaderStr.Add("Birth Date")
        HeaderStr.Add("Gender")
        HeaderStr.Add("Start Date to Previous Service")
        HeaderStr.Add("Scale 1")
        HeaderStr.Add("Scale 2")
        HeaderStr.Add("Scale 3")
        HeaderStr.Add("Retirement Date at 63")
        HeaderStr.Add("Retirement Date at 65")
        HeaderStr.Add("Date of Completion of 400 months")
        HeaderStr.Add("Extra Rate Per Hour")
        HeaderStr.Add("Date of Next Rate Increase")
        HeaderStr.Add("Is Top")
        HeaderStr.Add("Prov. Fund")
        HeaderStr.Add("Pension Fund")
        HeaderStr.Add("Prov.Fund Start Date")
        HeaderStr.Add("10% Decrease")


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

        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub


End Class
