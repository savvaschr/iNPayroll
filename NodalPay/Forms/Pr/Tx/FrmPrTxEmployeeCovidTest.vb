Public Class FrmPrTxEmployeeCovidTest
    Public EmpCode As String
    Public EmpName As String
    Public Employee As cPrMsEmployees
    Dim tPrMsCovidtest As New cPrMsCovid
    Dim DG1Changing As Boolean = False

    Dim ds As DataSet
    Private Sub FrmPrTxEmployeeCovidTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe()
        'Initialize()
        'If Global1.UserRole = Roles.NoRole Then
        '    Me.TSBSave.Enabled = False
        'End If
        'FillDG1()
        'CheckPermitions()
    End Sub
    Public Sub LoadMe()
        Me.txtEmployeeCode.Text = Employee.Code
        Me.txtEmployeeName.Text = Employee.FullName

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        If CheckDataSet(ds) Then
            LoadDataFromDG1(0)
        End If
    End Sub

    Private Sub CheckPermitions()
        'Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Advances")
        'If P.id > 0 Then
        '    If P.ReadonlyPermission = 1 Then
        '        TSBSave.Enabled = False
        '        Me.TSBDelete.Enabled = False
        '    End If
        'End If

    End Sub
    Private Sub Initialize()

        ClearMe()

    End Sub
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        'If Me.txtId.Text = "" Then
        '    Flag = False
        '    Me.ErrId.SetError(Me.txtId, "Field is Required")
        'Else
        '    If Not IsNumeric(Me.txtId.Text) Then
        '        Flag = False
        '        Me.ErrId.SetError(Me.txtId, "Field requires a number")
        '    Else
        '        If NullToInt(Me.txtId.Text) < 0 Then
        '            Flag = False
        '            Me.ErrId.SetError(Me.txtId, "Field requires positive number")
        '        End If
        '    End If
        'End If

        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"

        Me.Date1.Value = Now.Date
        Me.CheckBox1.Checked = True
        
    End Sub
    '
   


   
    '
    Private Sub ClearErrors()
        'Me.ErrId.SetError(Me.txtId, "")
        'Me.ErrDate1.SetError(Me.DateCreation, "")
        'Me.ErrSalaryValue.SetError(Me.txtSalaryValue, "")
        'Me.ErrBasic.SetError(Me.txtBasic, "")
        'Me.ErrEffPayDate.SetError(Me.DatePay, "")
        'Me.ErrCola.SetError(Me.txtCola, "")
        'Me.ErrEffArrearsDate.SetError(DateArrears, "")
        'Me.ErrUsr_Id.SetError(Me.cmbUsr, "")
        'Me.ErrIsCola.SetError(Me.CBIsCOLA, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsCovidtest = New cPrMsCovid
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.Date1.Focus()
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
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
        If ValidateMe() Then
            Dim Update As Boolean = False
            Try
                Dim Temp As New cPrMsTemplateGroup(Employee.TemGrp_Code)
                With tPrMsCovidtest
                    .Id = NullToInt(Me.txtId.Text)
                    .EmpCode = EmpCode
                    .TemGrpCode = Employee.TemGrp_Code
                    .ComCode = Temp.CompanyCode
                    .CovDate = Date1.Value.Date
                    .CovWeek = GetWeekOfYear(Date1.Value.Date)
                    .CovMonth = Date1.Value.Month
                    If Me.CheckBox1.Checked Then
                        .CovResult = 1
                    Else
                        .CovResult = 0
                    End If
                    .Anl1 = Employee.EmpAn1_Code
                    .Anl2 = Employee.EmpAn2_Code
                    .Anl3 = Employee.EmpAn3_Code
                    .Anl4 = Employee.EmpAn4_Code
                    .Anl5 = Employee.EmpAn5_Code
                    .GenAnal1 = Employee.AnalGen1
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        FillDG1()
                        FindWhereToSelect(.Id)
                        PKInputReadOnly(True)
                    Else
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Function GetWeekOfYear(ByVal Mydate As Date) As Integer
        Dim S As Integer
        Dim DOY As Integer = Mydate.DayOfYear  ' Get the current day of year
        Dim NOD As Integer  'number of days in a year
        Dim NW As Integer = 52 'number of weeks in a year (might have to mess with this with leap years)
        Dim TY As Integer = Mydate.Year 'current year. for leap year checking
        Dim CW As Integer ' current week
        If Date.IsLeapYear(TY) = True Then
            NOD = 365
        Else
            NOD = 366
        End If
        CW = DOY / NOD * NW
        s = (Format(CW, "#"))
        Return s
    End Function

    '
    Private Sub LoadDataSetToExcel()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        ds = Global1.Business.GetAllPrMsEmployeeCovidTestByEmpCode(Employee.Code)
        HeaderStr.Add("id")
        HeaderStr.Add("Employee Code")
        HeaderStr.Add("Template Code")
        HeaderStr.Add("Company Code")
        HeaderStr.Add("Date")
        HeaderStr.Add("Week")
        HeaderStr.Add("Month")
        HeaderStr.Add("Is Negative")
        HeaderStr.Add("Analysis Code 1")
        HeaderStr.Add("Analysis Code 2")
        HeaderStr.Add("Analysis Code 3")
        HeaderStr.Add("Analysis Code 4")
        HeaderStr.Add("Analysis Code 5")
        HeaderStr.Add("General Analysis 1")
        HeaderSize.Add(15)
        HeaderSize.Add(16)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrMsEmployeeCovid(ByVal tId As Integer)
        tPrMsCovidtest = New cPrMsCovid(tId)
        If tPrMsCovidtest.Id <> 0 Then
            With tPrMsCovidtest
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.Date1.Value = CDate(.CovDate)
                If .CovResult = 1 Then
                    Me.CheckBox1.Checked = True
                Else
                    Me.CheckBox1.Checked = False
                End If
            End With
        End If
    End Sub
    Private Sub FillDG1()

        ds = Global1.Business.GetAllPrMsEmployeeCovidTestByEmpCode(EmpCode)
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
       
    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        If DG1Changing = False Then
            Try
                Dim i As Integer
                i = DG1.CurrentRow.Index
                LoadDataFromDG1(i)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete record " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrMsCovidtest.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                FillDG1()
                Me.LoadDataFromDG1(0)
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe()
        Call ClearErrors()
        Me.lblSSStatus.Text = ""
        If Me.DG1.RowCount > 0 Then
            Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.Date1.Value = CDate(DbNullToString(DG1.Item(4, i).Value))
            Dim Res As Integer = DbNullToString(DG1.Item(7, i).Value)
            If Res = 1 Then
                Me.CheckBox1.Checked = True
            Else
                Me.CheckBox1.Checked = False
            End If
        End If

        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim S As String
            S = DbNullToString(ds.Tables(0).Rows(i).Item(0))
            If S = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(0)
                LoadDataFromDG1(i)
                Exit Sub
            End If
        Next

    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To Me.DG1.RowCount - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub



    
    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnCovidTest(Me)
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnCovidTest(Me)
    End Sub
End Class