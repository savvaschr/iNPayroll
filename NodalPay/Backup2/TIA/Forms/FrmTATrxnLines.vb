Public Class FrmTATrxnLines
    Dim Loading As Boolean = False

    Friend MyMode As TaStatus

    Public MyDs As DataSet
    Dim Dt1 As DataTable

    Public MyDs2 As DataSet
    Dim Dt2 As DataTable

    Public MyDs3 As DataSet
    Dim Dt3 As DataTable

    Public MyDs4 As DataSet
    Dim Dt4 As DataTable

    Dim GLBTempGroup As New cPrMsTemplateGroup
    Dim GLBCurrentPeriod As New cPrMsPeriodCodes

    Dim ArMon() As FrmTaForm
    Dim ArTue() As FrmTaForm
    Dim ArWed() As FrmTaForm
    Dim ArThu() As FrmTaForm
    Dim ArFri() As FrmTaForm
    Dim ArSat() As FrmTaForm
    Dim ArSun() As FrmTaForm



    Dim Column_EmpCode As Integer = 0
    Dim Column_EmpName As Integer = 1
    Dim Column_Mon As Integer = 2
    Dim Column_Tue As Integer = 3
    Dim Column_Wed As Integer = 4
    Dim Column_Thu As Integer = 5
    Dim Column_Fri As Integer = 6
    Dim Column_Sat As Integer = 7
    Dim Column_Sun As Integer = 8

    Public GLBAnalysis2Index As Integer
    Public GLBAnalysis2Code As String


    Private Sub FrmTATrxnLines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.MyMode = TaStatus.ACTUAL Then
            Me.Text = Me.Text & "  - ACTUAL"
            Me.TSBPostForProcess.Visible = False
            Me.TSSendToPayroll.Visible = True
        Else
            Me.Text = Me.Text & "  - SCHEDULE"
            Me.TSBPostForProcess.Visible = True
            Me.TSSendToPayroll.Visible = False
        End If

        Me.Top = 0
        Me.Left = 0

        LoadCombos()
        InitDataTable()
        InitDataGrid()

        InitDataTable2()
        InitDataGrid2()

        InitDataTable3()
        InitDataGrid3()

        InitDataTable4()
        InitDataGrid4()

        FindCurrentWeek()
        FindCurrentPeriod(True, False)

      
        Dim Ds1 As DataSet
        Dim Ds2 As DataSet
        Ds1 = Global1.Business.GetParameter("Split", "Split")
        If CheckDataSet(Ds1) Then
            Dim Par As New cPrSsParameters(Ds1.Tables(0).Rows(0))
            Global1.SplitRate = Par.Value1
        Else
            MsgBox("Missing Split Rate", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Ds2 = Global1.Business.GetParameter("Units", "Units")
        If CheckDataSet(Ds2) Then
            Dim Par As New cPrSsParameters(Ds2.Tables(0).Rows(0))
            Global1.PeriodUnitsForTA = Par.Value1
        Else
            MsgBox("Missing Units for Time Attendance'", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Ds2 = Global1.Business.GetParameter("System", "CostPerc")
        If CheckDataSet(Ds2) Then
            Dim Par As New cPrSsParameters(Ds2.Tables(0).Rows(0))
            Global1.Param_CostPercentageForTA = Par.Value1
        Else
            MsgBox("Missing Cost Percentage'", MsgBoxStyle.Critical)
            Exit Sub
        End If

       

    End Sub
    Private Sub FindCurrentWeek()
        Dim N As Date
        Dim WeekStart As Date
        Dim WeekEnd As Date
        N = Now
        If N.DayOfWeek = DayOfWeek.Monday Then
            WeekStart = Now
        Else
            Dim k As Integer
            Dim i As Integer
            For i = 1 To 7
                k = -i
                WeekStart = DateAdd(DateInterval.Day, k, N)
                If WeekStart.DayOfWeek = DayOfWeek.Monday Then
                    Exit For
                End If
            Next
        End If
        WeekEnd = DateAdd(DateInterval.Day, 6, WeekStart)
        Me.DateFrom.Value = WeekStart.Date
        Me.DateTo.Value = WeekEnd.Date

    End Sub
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("Mon", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Tue", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Wed", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("Thu", System.Type.GetType("System.String"))
        '6
        Dt1.Columns.Add("Fri", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("Sat", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("Sun", System.Type.GetType("System.String"))
    End Sub
    Private Sub ClearGrid()
        If CheckDataSet(MyDs) Then
            MyDs.Tables(0).Rows.Clear()
        End If

    End Sub
    Private Sub TSBSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSearch.Click
        Cursor = Cursors.WaitCursor
        Search(False)
        Cursor = Cursors.Default
    End Sub
    Private Sub Search(ByVal Reload As Boolean)
        MyDs.Tables(0).Rows.Clear()
        FindCurrentPeriod(False, Reload)
    End Sub
    Private Sub LoadCombos()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsTemplateGroup
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim Temp As New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
                    .Items.Add(Temp)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub

    Private Sub ComboTempGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboTempGroups.SelectedIndexChanged
        Try
            Me.ClearGrid()
            GLBTempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup)
            FindCurrentPeriod(True, False)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub FindCurrentPeriod(ByVal Clearing As Boolean, ByVal Reload As Boolean)
        If Loading Then Exit Sub
        Try
            Dim ds As DataSet
            ds = Global1.Business.FindCurrentPeriod1(GLBTempGroup.Code)
            If CheckDataSet(ds) Then
                GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
                With GLBCurrentPeriod
                    Me.txtPeriodCode.Text = .Code
                    Me.txtPeriodDescription.Text = .DescriptionL
                    Me.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                    Me.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
                End With
                SearchForEmployees(Clearing, Reload)


            Else
                MsgBox("There is no OPEN Period !Cannot Proceed with Payroll Calculations", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub SearchForEmployees(ByVal Clearing As Boolean, ByVal Reload As Boolean)
        If Clearing Then
            Dim ds As New DataSet
            Me.LoadEmployees(Clearing, ds, "", 0, "", "")
        Else
            Dim F As New FrmEmployeeSearch2
            F.TempGroupCode = Me.GLBTempGroup.Code
            F.CurrentPeriod = Me.GLBCurrentPeriod
            F.GLBFromDate = Me.DateFrom.Value.Date
            F.GLBToDate = Me.DateTo.Value.Date
            F.GLBAutoLoad = Reload
            F.Owner = Me

            F.Mystatus = Me.MyMode

            If Not Reload Then
                F.ShowDialog()
            Else
                F.Show()
                F.SetEmployeeAnalysisTo(Me.GLBAnalysis2Code)
                F.SearchForEmployees()
                F.LoadEmployees()

            End If

        End If
    End Sub
    Public Sub LoadEmployees(ByVal Clearing As Boolean, ByVal ds As DataSet, ByVal Analysis As String, ByVal AnalysisIndex As Integer, ByVal Analysis2Code As String, ByVal TemplateGroup As String)
        Me.LblAnalysis.Text = Analysis
        Me.GLBAnalysis2Index = AnalysisIndex
        Me.GLBAnalysis2Code = Analysis2Code

        Dim EmpCounter As Integer = 0
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim m As Integer

        Dim FromDate As Date = Me.DateFrom.Value
        Dim ToDate As Date = Me.DateTo.Value
        Dim TotalRows As Integer = 0

        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim found As Boolean = False

        Dim ErnCounter As Integer = 0
        Dim DedCounter As Integer = 0
        Dim ConCounter As Integer = 0

        Dim Ern(15) As String
        Dim ErnValue(15) As Double
        Dim DescCounter As Integer = 0

        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToInt(ds.Tables(0).Rows(i).Item(0)) = 1 Then
                    TotalRows = TotalRows + 1
                End If
            Next

            ReDim ArMon(TotalRows - 1)
            ReDim ArTue(TotalRows - 1)
            ReDim ArWed(TotalRows - 1)
            ReDim ArThu(TotalRows - 1)
            ReDim ArFri(TotalRows - 1)
            ReDim ArSat(TotalRows - 1)
            ReDim ArSun(TotalRows - 1)

            Dim EmpCode As String
            Dim EmpfullName As String
            Dim TypeOfemployee As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToInt(ds.Tables(0).Rows(i).Item(0)) = 1 Then
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpfullName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    TypeOfemployee = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    Debug.WriteLine(j)
                    LoadMyGrid(EmpCode, EmpfullName, i, j, FromDate, ToDate, True, AnalysisIndex, TypeOfemployee)
                    j = j + 1
                End If
            Next

            If j <> 0 Then
                LoadPreviusEmployeeforms(j - 1)
            End If
        End If

        If CheckDataSet(MyDs) Then
            Dim mycolor As Color
            mycolor = Color.Aqua
            For i = 0 To TotalRows - 1
                DG1.Rows(i).DefaultCellStyle.BackColor = mycolor
                If mycolor = Color.Aqua Then
                    mycolor = Color.White
                Else
                    mycolor = Color.Aqua
                End If
            Next
            Me.FixColors(TotalRows)
        End If


    End Sub
    
    Private Sub LoadMyGrid(ByVal Empcode As String, ByVal EmpFullname As String, ByVal i As Integer, ByVal j As Integer, ByVal FromDate As Date, ByVal Todate As Date, ByVal FirstTime As Boolean, ByVal AnalysisIndex As Integer, ByVal TypeOfEmployee As String)
        Try

        
            Dim k As Integer
            Dim MyStatus As String
            If j > 0 Then
                LoadPreviusEmployeeforms(j - 1)
            End If
            Dim dsLines As DataSet

            Dim dsWorkCodes As DataSet
            dsWorkCodes = Global1.Business.GetAllWorkCodes

            Dim DsAnal As DataSet
            DsAnal = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()

            If MyMode = TaStatus.ACTUAL Then
                dsLines = Global1.Business.GetTaTrxnLines2(Empcode, FromDate, Todate)
            Else
                dsLines = Global1.Business.GetTaTrxnLines(Empcode, FromDate, Todate)
            End If


            If CheckDataSet(dsLines) Then
                MyStatus = DbNullToString(dsLines.Tables(0).Rows(0).Item(13))
            Else
                If MyMode = TaStatus.ACTUAL Then
                    MyStatus = "POST"
                Else
                    MyStatus = "OUTS"
                End If
            End If
            InitializeMyforms(j, dsWorkCodes, Empcode, MyStatus, DsAnal, AnalysisIndex)



            If CheckDataSet(dsLines) Then

                Dim PreviusDay As String = ""
                Dim C As Integer
                Dim F As New FrmTaForm
                For k = 0 To dsLines.Tables(0).Rows.Count - 1
                    Dim Lin As New cTaTxTrxnLines()
                    Dim Lin2 As New cTaTxTrxnLines2()
                    If MyMode = TaStatus.ACTUAL Then
                        Lin2 = New cTaTxTrxnLines2(dsLines.Tables(0).Rows(k))
                        If Lin2.Day <> PreviusDay Then
                            PreviusDay = Lin2.Day
                            C = 0
                        End If
                    Else
                        Lin = New cTaTxTrxnLines(dsLines.Tables(0).Rows(k))
                        If Lin.Day <> PreviusDay Then
                            PreviusDay = Lin.Day
                            C = 0
                        End If
                    End If

                    If MyMode = TaStatus.ACTUAL Then
                        Select Case UCase(Lin2.Day)
                            Case UCase("Mon")
                                ArMon(j).TrxnLines2(C) = Lin2
                            Case UCase("Tue")
                                ArTue(j).TrxnLines2(C) = Lin2
                            Case UCase("Wed")
                                ArWed(j).TrxnLines2(C) = Lin2
                            Case UCase("Thu")
                                ArThu(j).TrxnLines2(C) = Lin2
                            Case UCase("Fri")
                                ArFri(j).TrxnLines2(C) = Lin2
                            Case UCase("Sat")
                                ArSat(j).TrxnLines2(C) = Lin2
                            Case UCase("Sun")
                                ArSun(j).TrxnLines2(C) = Lin2
                        End Select
                    Else
                        Select Case UCase(Lin.Day)
                            Case UCase("Mon")
                                ArMon(j).TrxnLines(C) = Lin
                            Case UCase("Tue")
                                ArTue(j).TrxnLines(C) = Lin
                            Case UCase("Wed")
                                ArWed(j).TrxnLines(C) = Lin
                            Case UCase("Thu")
                                ArThu(j).TrxnLines(C) = Lin
                            Case UCase("Fri")
                                ArFri(j).TrxnLines(C) = Lin
                            Case UCase("Sat")
                                ArSat(j).TrxnLines(C) = Lin
                            Case UCase("Sun")
                                ArSun(j).TrxnLines(C) = Lin
                        End Select
                    End If

                    C = C + 1
                Next
            End If
            If FirstTime Then
                If TypeOfEmployee = "" Then
                    Dim emp As New cPrMsEmployees(Empcode)
                    TypeOfEmployee = emp.PayUni_Code
                End If
                If TypeOfEmployee = 1 Then
                    TypeOfEmployee = "Full"
                Else
                    TypeOfEmployee = "PartTime"
                End If
                Dim r As DataRow = Dt1.NewRow()
                r(0) = Empcode
                r(1) = EmpFullname.Replace(" ", Chr(10)) & " - " & TypeOfEmployee
                r(2) = "0.00"
                r(3) = "0.00"
                r(4) = "0.00"
                r(5) = "0.00"
                r(6) = "0.00"
                r(7) = "0.00"
                r(8) = "0.00"

                Dt1.Rows.Add(r)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
   
    Private Sub InitializeMyforms(ByVal i As Integer, ByVal ds As DataSet, ByVal EmpCode As String, ByVal MyStatus As String, ByVal DsAnal As DataSet, ByVal Analysis2 As String)

        Dim k As Integer
        For k = 0 To 6
            Dim F As New FrmTaForm

            F.MyMode = MyMode
            F.MyOwner = Me
            F.NumberOfLines = 7 'ds.Tables(0).Rows.Count - 1

            F.InitializeMe(ds, DsAnal, Analysis2)
            F.MyStatus = MyStatus
            F.GlbEmpCode = EmpCode


            Select Case k
                Case 0
                    F.MyDay = "MON"
                    ArMon(i) = F
                Case 1
                    F.MyDay = "TUE"
                    ArTue(i) = F
                Case 2
                    F.MyDay = "WED"
                    ArWed(i) = F
                Case 3
                    F.MyDay = "THU"
                    ArThu(i) = F
                Case 4
                    F.MyDay = "FRI"
                    ArFri(i) = F
                Case 5
                    F.MyDay = "SAT"
                    ArSat(i) = F
                Case 6
                    F.MyDay = "SUN"
                    ArSun(i) = F
            End Select

        Next


    End Sub
    Private Sub LoadPreviusEmployeeforms(ByVal i As Integer)
        ArMon(i).Loading = True
        ArMon(i).LoadMe(i, 2, "Monday", DateFrom.Value)
        ArMon(i).Loading = False

        ArTue(i).Loading = True
        ArTue(i).LoadMe(i, 3, "Tuesday", DateFrom.Value)
        ArTue(i).Loading = False

        ArWed(i).Loading = True
        ArWed(i).LoadMe(i, 4, "Wednesday", DateFrom.Value)
        ArWed(i).Loading = False

        ArThu(i).Loading = True
        ArThu(i).LoadMe(i, 5, "Thursday", DateFrom.Value)
        ArThu(i).Loading = False

        ArFri(i).Loading = True
        ArFri(i).LoadMe(i, 6, "Friday", DateFrom.Value)
        ArFri(i).Loading = False

        ArSat(i).Loading = True
        ArSat(i).LoadMe(i, 7, "Satarday", DateFrom.Value)
        ArSat(i).Loading = False

        ArSun(i).Loading = True
        ArSun(i).LoadMe(i, 8, "Sunday", DateFrom.Value)
        ArSun(i).Loading = False
    End Sub



    Private Sub btnPreviousWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousWeek.Click
        Me.DateFrom.Value = DateAdd(DateInterval.Day, -7, Me.DateFrom.Value)
        Me.DateTo.Value = DateAdd(DateInterval.Day, 6, Me.DateFrom.Value)

        If CheckDataSet(MyDs) Then
            ReloadMyDs()
        End If


        If CheckDataSet(MyDs) Then
            Dim TotalRows As Integer
            TotalRows = MyDs.Tables(0).Rows.Count
            ReDim ArMon(TotalRows - 1)
            ReDim ArTue(TotalRows - 1)
            ReDim ArWed(TotalRows - 1)
            ReDim ArThu(TotalRows - 1)
            ReDim ArFri(TotalRows - 1)
            ReDim ArSat(TotalRows - 1)
            ReDim ArSun(TotalRows - 1)

            Dim EmpCode As String
            Dim EmpfullName As String
            Dim Fromdate As Date = DateFrom.Value
            Dim ToDate As Date = DateTo.Value
            Dim i As Integer
            Dim j As Integer
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(0))
                EmpfullName = DbNullToString(MyDs.Tables(0).Rows(i).Item(1))
                LoadMyGrid(EmpCode, EmpfullName, i, j, Fromdate, ToDate, False, GLBAnalysis2Index, 0)
                j = j + 1
            Next
            If j <> 0 Then
                LoadPreviusEmployeeforms(j - 1)
            End If
            Dim WeKdes As New cTaTxWeekDescription(Me.DateFrom.Value.Date, Me.DateTo.Value.Date, Me.GLBAnalysis2Code)
            If WeKdes.Id > 0 Then
                Me.txtDesc.Text = WeKdes.Desription
            Else
                Me.txtDesc.Text = ""
            End If
            FixColors(TotalRows)
        End If



    End Sub

    Private Sub btnNextWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextWeek.Click
        Me.DateFrom.Value = DateAdd(DateInterval.Day, 1, Me.DateTo.Value)
        Me.DateTo.Value = DateAdd(DateInterval.Day, 6, Me.DateFrom.Value)

        If CheckDataSet(MyDs) Then
            ReloadMyDs()
        End If

        If CheckDataSet(MyDs) Then
            Dim TotalRows As Integer
            TotalRows = MyDs.Tables(0).Rows.Count
            ReDim ArMon(TotalRows - 1)
            ReDim ArTue(TotalRows - 1)
            ReDim ArWed(TotalRows - 1)
            ReDim ArThu(TotalRows - 1)
            ReDim ArFri(TotalRows - 1)
            ReDim ArSat(TotalRows - 1)
            ReDim ArSun(TotalRows - 1)

            Dim EmpCode As String
            Dim EmpfullName As String
            Dim Fromdate As Date = DateFrom.Value
            Dim ToDate As Date = DateTo.Value
            Dim i As Integer
            Dim j As Integer
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(0))
                EmpfullName = DbNullToString(MyDs.Tables(0).Rows(i).Item(1))
                LoadMyGrid(EmpCode, EmpfullName, i, j, Fromdate, ToDate, False, GLBAnalysis2Index, 0)
                j = j + 1
            Next
            If j <> 0 Then
                LoadPreviusEmployeeforms(j - 1)
            End If
            Dim WeKdes As New cTaTxWeekDescription(Me.DateFrom.Value.Date, Me.DateTo.Value.Date, Me.GLBAnalysis2Code)
            If WeKdes.Id > 0 Then
                Me.txtDesc.Text = WeKdes.Desription
            Else
                Me.txtDesc.Text = ""
            End If


            FixColors(TotalRows)

        End If


    End Sub
    Private Sub ReloadMyDs()
        Search(True)
    End Sub
    Private Sub FixColors(ByVal TotalRows As Integer)
        Dim errorvalue = 1
        Dim mycolor As Color
        mycolor = Color.Aqua
        Dim i As Integer
        Dim j As Integer
        For i = 0 To TotalRows - 1
            For j = 0 To 8
                'DG1.Rows(i).DefaultCellStyle.BackColor = mycolor
                DG1.Rows(i).Cells(j).Style.BackColor = mycolor
                errorvalue = 2
            Next

            If mycolor = Color.Aqua Then
                mycolor = Color.White
            Else
                mycolor = Color.Aqua
            End If
        Next
        Dim SS As String
        SS = "Total Time : " & Format(0, "0.00") & Chr(10)
        errorvalue = 3
        SS = SS & " Total Value: " & Format(0, "0.00") '& Chr(10)
        errorvalue = 4
        Try


            For i = 0 To TotalRows - 1
                For j = 2 To 8
                    errorvalue = 5
                    Debug.WriteLine(DbNullToString(MyDs.Tables(0).Rows(i).Item(j)))
                    errorvalue = 6
                    Debug.WriteLine(SS)
                    errorvalue = 7
                    If DbNullToString(MyDs.Tables(0).Rows(i).Item(j)) <> SS Then
                        DG1.Rows(i).Cells(j).Style.BackColor = Color.Yellow
                        errorvalue = 8
                    End If
                Next
            Next
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Error Value 1:" & errorvalue)
        End Try

    End Sub

    Private Sub DG1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellClick
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            i = e.RowIndex
            If i = -1 Then Exit Sub
            Select Case e.ColumnIndex
                Case 2
                    CType(Me.ArMon(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArMon(i), FrmTaForm).Owner = Me
                    CType(Me.ArMon(i), FrmTaForm).ShowDialog()
                Case 3
                    CType(Me.ArTue(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArTue(i), FrmTaForm).Owner = Me
                    CType(Me.ArTue(i), FrmTaForm).ShowDialog()
                Case 4
                    CType(Me.ArWed(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArWed(i), FrmTaForm).Owner = Me
                    CType(Me.ArWed(i), FrmTaForm).ShowDialog()
                Case 5
                    CType(Me.ArThu(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArThu(i), FrmTaForm).Owner = Me
                    CType(Me.ArThu(i), FrmTaForm).ShowDialog()
                Case 6
                    CType(Me.ArFri(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArFri(i), FrmTaForm).Owner = Me
                    CType(Me.ArFri(i), FrmTaForm).ShowDialog()
                Case 7
                    CType(Me.ArSat(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArSat(i), FrmTaForm).Owner = Me
                    CType(Me.ArSat(i), FrmTaForm).ShowDialog()
                Case 8
                    CType(Me.ArSun(i), FrmTaForm).CalledFromAnalysis = Me.GLBAnalysis2Code
                    CType(Me.ArSun(i), FrmTaForm).Owner = Me
                    CType(Me.ArSun(i), FrmTaForm).ShowDialog()
            End Select
        End If
    End Sub
    Public Sub SaveWeekDescription()
        If Me.txtDesc.Text <> "" Then
            Dim WekDes As New cTaTxWeekDescription(Me.DateFrom.Value.Date, DateTo.Value.Date, GLBAnalysis2Code)

            WekDes.Fromdate = DateFrom.Value.Date
            WekDes.Todate = DateTo.Value.Date
            WekDes.AnalCode = GLBAnalysis2Code
            WekDes.Desription = Me.txtDesc.Text

            WekDes.Save()

        End If
    End Sub

    Private Sub DateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateFrom.ValueChanged
        Me.txtDateFrom.Text = Format(Me.DateFrom.Value.Date, "dd-MM-yyyy")
    End Sub

    Private Sub DateTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTo.ValueChanged
        Me.txtDateTo.Text = Format(Me.DateTo.Value.Date, "dd-MM-yyyy")
    End Sub

    Private Sub BtnSearchEmp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New FrmEmployeeSearch
        f.CalledBy = 5
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub BtnSearcEmp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New FrmEmployeeSearch
        f.CalledBy = 6
        f.Owner = Me
        f.ShowDialog()
    End Sub
    Private Sub TSBPostForProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPostForProcess.Click

        Dim Ans As MsgBoxResult
        Dim i As Integer

        Ans = MsgBox("Do you want to POST this Week Schedule for PROCESSING", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then
            Dim exx As New Exception()
            Dim Ar() As Integer
            Dim ReturnValue As Integer

            ReDim Ar(MyDs.Tables(0).Rows.Count - 1)

            Try

                Global1.Business.BeginTransaction()
                Dim EmpCode As String = ""
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    If Emp.EmpAn5_Code = Me.GLBAnalysis2Code Then
                        ReturnValue = Global1.Business.UpdateTaTxTrxnLines(EmpCode, Me.DateFrom.Value.Date, Me.DateTo.Value.Date, "POST")
                        If ReturnValue = -1 Then
                            Throw exx
                        End If
                        Ar(i) = ReturnValue
                    End If
                Next
                For i = 0 To Ar.Length - 1
                    If Ar(i) > 0 Then
                        Me.ArMon(i).StatusChangeToPROC()
                        Me.ArTue(i).StatusChangeToPROC()
                        Me.ArWed(i).StatusChangeToPROC()
                        Me.ArThu(i).StatusChangeToPROC()
                        Me.ArFri(i).StatusChangeToPROC()
                        Me.ArSat(i).StatusChangeToPROC()
                        Me.ArSun(i).StatusChangeToPROC()
                        ChangeRowStatusDescription(i, "OUTS", "POST", 0)
                    End If
                Next

                Global1.Business.CommitTransaction()
                MsgBox("Entries Are Posted", MsgBoxStyle.Information)
            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("Unable to Post Entries", MsgBoxStyle.Critical)
                Global1.Business.Rollback()
            End Try
        End If

    End Sub
    Private Sub ChangeRowStatusDescription(ByVal row As Integer, ByVal PreviusStatus As String, ByVal CurrentStatus As String, ByVal Column As Integer)
        Dim s As String
        If MyMode = TaStatus.ACTUAL Then
            s = DbNullToString(MyDs.Tables(0).Rows(row).Item(Column))
            s = s.Replace(PreviusStatus, CurrentStatus)
            MyDs.Tables(0).Rows(row).Item(Column) = s
        Else
            Dim i As Integer
            For i = 2 To 8
                s = DbNullToString(MyDs.Tables(0).Rows(row).Item(i))
                s = s.Replace(PreviusStatus, CurrentStatus)
                MyDs.Tables(0).Rows(row).Item(i) = s
            Next
        End If
    End Sub
    Private Sub ChangeRowStatusDescription2(ByVal row As Integer, ByVal PreviusStatus As String, ByVal CurrentStatus As String)
        Dim s As String
        Dim i As Integer
        For i = 2 To 8
            s = DbNullToString(MyDs.Tables(0).Rows(row).Item(i))
            s = s.Replace(PreviusStatus, CurrentStatus)
            MyDs.Tables(0).Rows(row).Item(i) = s
        Next
    End Sub

    Private Sub TestingMySub()
        Dim i As Integer
        Dim ds As New DataSet

        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1

            Next
        End If
    End Sub

    Private Sub DG1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG1.CellMouseClick
        If MyMode = TaStatus.ACTUAL Then
            Dim i As Integer
            Dim Col As Integer
            Dim Row As Integer
            Col = e.ColumnIndex
            Row = e.RowIndex
            If Col >= 2 And Col <= 8 Then


                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim Ans As New MsgBoxResult
                    Ans = MsgBox("Save as Actual", MsgBoxStyle.YesNoCancel)
                    If Ans = MsgBoxResult.Yes Then
                        Dim exx As New Exception()
                        Dim Ar() As Integer
                        Dim ReturnValue As Integer
                        Dim EmpCode As String
                        ReDim Ar(MyDs.Tables(0).Rows.Count - 1)

                        Try

                            Global1.Business.BeginTransaction()
                            If CheckDataSet(MyDs) Then
                                Dim MyDate As Date
                                MyDate = DateAdd(DateInterval.Day, Col - 2, DateFrom.Value.Date)
                                EmpCode = DbNullToString(MyDs.Tables(0).Rows(Row).Item(0))
                                ReturnValue = Global1.Business.UpdateTaTxTrxnLines2(EmpCode, MyDate, "ACTL")
                                If ReturnValue = -1 Then
                                    Throw exx
                                End If
                                Select Case Col
                                    Case 2
                                        Me.ArMon(Row).StatusChangeToACTL()
                                    Case 3
                                        Me.ArTue(Row).StatusChangeToACTL()
                                    Case 4
                                        Me.ArWed(Row).StatusChangeToACTL()
                                    Case 5
                                        Me.ArThu(Row).StatusChangeToACTL()
                                    Case 6
                                        Me.ArFri(Row).StatusChangeToACTL()
                                    Case 7
                                        Me.ArSat(Row).StatusChangeToACTL()
                                    Case 8
                                        Me.ArSun(Row).StatusChangeToACTL()
                                End Select
                                ChangeRowStatusDescription(Row, "POST", "ACTL", Col)
                            End If

                            Global1.Business.CommitTransaction()
                            MsgBox("Entries Are Posted", MsgBoxStyle.Information)
                        Catch ex As Exception
                            Utils.ShowException(ex)
                            MsgBox("Unable to Post Entries", MsgBoxStyle.Critical)
                            Global1.Business.Rollback()
                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SelectedEmployeeReport()
        If CheckDataSet(MyDs) Then
            Dim Index As Integer = 0
            Dim EmpCode As String = ""
            Index = DG1.CurrentRow.Index
            EmpCode = MyDs.Tables(0).Rows(Index).Item(Column_EmpCode)
            Dim F As New FrmTaTotalTimePerWork
            F.EmpCode = EmpCode
            F.FromDate = Me.DateFrom.Value.Date
            F.ToDate = Me.DateTo.Value.Date
            If Me.MyMode = TaStatus.ACTUAL Then
                F.ForActual = True
            Else
                F.ForActual = False
            End If
            F.ShowDialog()
        End If
    End Sub



    Private Sub PrepareReport()
        If CheckDataSet(MyDs2) Then
            MyDs2.Tables(0).Rows.Clear()
        End If
        Cursor.Current = Cursors.WaitCursor

        Dim i As Integer
        Dim ForActual As Boolean

        Dim TotalMon As Double
        Dim TotalTue As Double
        Dim TotalWed As Double
        Dim TotalThu As Double
        Dim TotalFri As Double
        Dim TotalSat As Double
        Dim TotalSun As Double

        Dim TotalMon2 As Double
        Dim TotalTue2 As Double
        Dim TotalWed2 As Double
        Dim TotalThu2 As Double
        Dim TotalFri2 As Double
        Dim TotalSat2 As Double
        Dim TotalSun2 As Double

        Dim TotalOver As Double
        Dim TotalSplit As Double
        Dim TotalLeave As Double
        Dim TotalErn As Double
        Dim TotalDed As Double

        If CheckDataSet(MyDs) Then
            If Me.MyMode = TaStatus.ACTUAL Then
                ForActual = True
            Else
                ForActual = False
            End If
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Dim EmpCode As String = ""
                Dim Ds As DataSet
                EmpCode = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)
                Dim Emp As New cPrMsEmployees(EmpCode)
                Dim D As Date
                Dim D2 As Date
                D = Me.DateFrom.Value.Date
                D2 = Me.DateTo.Value.Date

                TotalMon = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalMon2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalTue = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalTue2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalWed = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalWed2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalThu = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalThu2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalFri = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalFri2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalSat = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalSat2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                D = DateAdd(DateInterval.Day, 1, D)
                TotalSun = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                TotalSun2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)


                D = Me.DateFrom.Value.Date
                TotalOver = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "02", "02", ForActual, GLBAnalysis2Code)
                TotalSplit = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "03", "03", ForActual, GLBAnalysis2Code)
                TotalLeave = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "04", "07", ForActual, GLBAnalysis2Code)
                TotalErn = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "08", "08", ForActual, GLBAnalysis2Code)
                TotalDed = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "09", "09", ForActual, GLBAnalysis2Code)

                Dim r As DataRow = Dt2.NewRow()


                r(0) = Emp.Code
                r(1) = Emp.FullName

                r(2) = "MONDAY"
                r(3) = Format(D, "dd-MM-yyyy")
                r(4) = TotalMon + TotalMon2

                D = DateAdd(DateInterval.Day, 1, D)

                r(5) = "TUESDAY"
                r(6) = Format(D, "dd-MM-yyyy")
                r(7) = TotalTue + TotalTue2

                D = DateAdd(DateInterval.Day, 1, D)

                r(8) = "WEDNESD."
                r(9) = Format(D, "dd-MM-yyyy")
                r(10) = TotalWed + TotalWed2

                D = DateAdd(DateInterval.Day, 1, D)

                r(11) = "THURSDAY"
                r(12) = Format(D, "dd-MM-yyyy")
                r(13) = TotalThu + TotalThu2

                D = DateAdd(DateInterval.Day, 1, D)

                r(14) = "FRIDAY"
                r(15) = Format(D, "dd-MM-yyyy")
                r(16) = TotalFri + TotalFri2

                D = DateAdd(DateInterval.Day, 1, D)

                r(17) = "SATURDAY"
                r(18) = Format(D, "dd-MM-yyyy")
                r(19) = TotalSat + TotalSat2

                D = DateAdd(DateInterval.Day, 1, D)

                r(20) = "SUNDAY"
                r(21) = Format(D, "dd-MM-yyyy")
                r(22) = TotalSun + TotalSun2

                r(23) = TotalOver
                r(24) = TotalSplit
                r(25) = TotalLeave
                r(26) = TotalErn
                r(27) = TotalDed

                r(28) = Emp.Telephone1

                r(29) = Format(Me.DateFrom.Value, "dd-MM-yyyy")
                r(30) = Format(Me.DateTo.Value, "dd-MM-yyyy")
                r(31) = LblAnalysis.Text


                Dt2.Rows.Add(r)

            Next


            ' Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\TimeAttendance1")
            Utils.ShowReport("TimeAttendance1.rpt", MyDs2, FrmReport, "", False, "", False, False, "", True)


            Cursor.Current = Cursors.Default

        End If
    End Sub
    Private Sub PrepareReportTimes()
        Try

        

            If CheckDataSet(MyDs4) Then
                MyDs4.Tables(0).Rows.Clear()
            End If
            Dim WeekDescription As String

            Dim WekDes As New cTaTxWeekDescription(Me.DateFrom.Value.Date, Me.DateTo.Value.Date, Me.GLBAnalysis2Code)
            If WekDes.Id > 0 Then
                WeekDescription = WekDes.Desription
            End If
            Cursor.Current = Cursors.WaitCursor

            Dim i As Integer
            Dim ForActual As Boolean

            Dim TotalMon() As String
            Dim TotalTue() As String
            Dim TotalWed() As String
            Dim TotalThu() As String
            Dim TotalFri() As String
            Dim TotalSat() As String
            Dim TotalSun() As String

            Dim MonFromTo As String
            Dim TueFromTo As String
            Dim WedFromTo As String
            Dim ThuFromTo As String
            Dim FriFromTo As String
            Dim SatFromTo As String
            Dim SunFromTo As String


            Dim TotalMon2 As Double
            Dim TotalTue2 As Double
            Dim TotalWed2 As Double
            Dim TotalThu2 As Double
            Dim TotalFri2 As Double
            Dim TotalSat2 As Double
            Dim TotalSun2 As Double

            Dim NormalMon2 As Double
            Dim NormalTue2 As Double
            Dim NormalWed2 As Double
            Dim NormalThu2 As Double
            Dim NormalFri2 As Double
            Dim NormalSat2 As Double
            Dim NormalSun2 As Double

            Dim TotalOver As Double
            Dim TotalSplit As Double
            Dim TotalLeave As Double
            Dim TotalErn As Double
            Dim TotalDed As Double
            Dim TotalWeekNormal As Double

            If CheckDataSet(MyDs) Then
                If Me.MyMode = TaStatus.ACTUAL Then
                    ForActual = True
                Else
                    ForActual = False
                End If
                Dim Cost As Double = 0
                Dim EmpCost = 0
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Dim EmpCode As String = ""
                    Dim Ds As DataSet
                    EmpCode = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Dim D As Date
                    Dim D2 As Date
                    D = Me.DateFrom.Value.Date
                    D2 = Me.DateTo.Value.Date

                    TotalMon = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalMon2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalMon2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    D = DateAdd(DateInterval.Day, 1, D)

                    MonFromTo = TotalMon(0) & " - " & TotalMon(1)

                    TotalTue = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalTue2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalTue2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    TueFromTo = TotalTue(0) & " - " & TotalTue(1)

                    D = DateAdd(DateInterval.Day, 1, D)
                    TotalWed = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalWed2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalWed2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    WedFromTo = TotalWed(0) & " - " & TotalWed(1)

                    D = DateAdd(DateInterval.Day, 1, D)
                    TotalThu = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalThu2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalThu2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    ThuFromTo = TotalThu(0) & " - " & TotalThu(1)

                    D = DateAdd(DateInterval.Day, 1, D)
                    TotalFri = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalFri2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalFri2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    FriFromTo = TotalFri(0) & " - " & TotalFri(1)

                    D = DateAdd(DateInterval.Day, 1, D)
                    TotalSat = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalSat2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalSat2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    SatFromTo = TotalSat(0) & " - " & TotalSat(1)

                    D = DateAdd(DateInterval.Day, 1, D)
                    TotalSun = Global1.Business.GetEmployeeTotalPerDayPerWorkCodeTime(EmpCode, D, D, "01", "02", ForActual, GLBAnalysis2Code)
                    NormalSun2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "01", "01", ForActual, GLBAnalysis2Code)
                    TotalSun2 = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D, "10", "10", ForActual, GLBAnalysis2Code)
                    SunFromTo = TotalSun(0) & " - " & TotalSun(1)


                    D = Me.DateFrom.Value.Date
                    TotalOver = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "02", "02", ForActual, GLBAnalysis2Code)
                    TotalSplit = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "03", "03", ForActual, GLBAnalysis2Code)
                    TotalLeave = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "04", "07", ForActual, GLBAnalysis2Code)
                    TotalErn = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "08", "08", ForActual, GLBAnalysis2Code)
                    TotalDed = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "09", "09", ForActual, GLBAnalysis2Code)

                    Dim HourlyRate As Double
                    HourlyRate = FindEmployeeHourlyRate(Emp, Me.DateFrom.Value)

                    TotalWeekNormal = 0
                    TotalWeekNormal = TotalWeekNormal + NormalMon2 + TotalMon2
                    TotalWeekNormal = TotalWeekNormal + NormalTue2 + TotalTue2
                    TotalWeekNormal = TotalWeekNormal + NormalWed2 + TotalWed2
                    TotalWeekNormal = TotalWeekNormal + NormalThu2 + TotalThu2
                    TotalWeekNormal = TotalWeekNormal + NormalFri2 + TotalFri2
                    TotalWeekNormal = TotalWeekNormal + NormalSat2 + TotalSat2
                    TotalWeekNormal = TotalWeekNormal + NormalSun2 + TotalSun2


                    Dim r As DataRow = Dt4.NewRow()
                    Dim S As String = ""


                    r(0) = Emp.Code
                    r(1) = Emp.FullName

                    r(2) = "MONDAY"
                    r(3) = Format(D, "dd-MM-yyyy")
                    r(4) = MonFromTo


                    ' S = NormalMon2 & " N + " & TotalMon2 & " I=" & NormalMon2 + TotalMon2
                    r(5) = S 'NormalMon2 + TotalMon2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(6) = "TUESDAY"
                    r(7) = Format(D, "dd-MM-yyyy")
                    r(8) = TueFromTo
                    'S = NormalTue2 & " N + " & TotalTue2 & " I = " & NormalTue2 + TotalTue2
                    r(9) = S 'NormalTue2 + TotalTue2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(10) = "WEDNESD."
                    r(11) = Format(D, "dd-MM-yyyy")
                    r(12) = WedFromTo
                    'S = NormalWed2 & " N + " & TotalWed2 & " I = " & NormalWed2 + TotalWed2
                    r(13) = S 'NormalWed2 + TotalWed2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(14) = "THURSDAY"
                    r(15) = Format(D, "dd-MM-yyyy")
                    r(16) = ThuFromTo
                    'S = NormalThu2 & " N + " & TotalThu2 & " I = " & NormalThu2 + TotalThu2
                    r(17) = S 'normalThu2 + TotalThu2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(18) = "FRIDAY"
                    r(19) = Format(D, "dd-MM-yyyy")
                    r(20) = FriFromTo
                    'S = NormalFri2 & " N + " & TotalFri2 & " I = " & NormalFri2 + TotalFri2
                    r(21) = S ' NormalFri2 + TotalFri2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(22) = "SATURDAY"
                    r(23) = Format(D, "dd-MM-yyyy")
                    r(24) = SatFromTo
                    'S = NormalSat2 & " N + " & TotalSat2 & " I = " & NormalSat2 + TotalSat2
                    r(25) = S ' NormalSat2 + TotalSat2

                    D = DateAdd(DateInterval.Day, 1, D)

                    r(26) = "SUNDAY"
                    r(27) = Format(D, "dd-MM-yyyy")
                    r(28) = SunFromTo
                    'S = NormalSun2 & " N + " & TotalSun2 & " I = " & NormalSun2 + TotalSun2
                    r(29) = S 'NormalSun2 + TotalSun2

                    r(30) = TotalOver
                    r(31) = TotalSplit
                    r(32) = TotalLeave
                    r(33) = TotalErn
                    r(34) = TotalDed

                    r(35) = Emp.Telephone1

                    r(36) = Format(Me.DateFrom.Value, "dd-MM-yyyy")
                    r(37) = Format(Me.DateTo.Value, "dd-MM-yyyy")
                    r(38) = LblAnalysis.Text
                    r(39) = "/ " & TotalWeekNormal + TotalOver

                    r(40) = WeekDescription




                    Dim EmpGross As Double = 0

                    Dim minutes As Double = 0
                    Dim Sminutes As String
                    Dim Units As Double = 0
                    Dim totalN As Double = 0
                    minutes = TotalWeekNormal + TotalOver
                    Sminutes = Format(minutes, "0.00")
                    Dim ar() As String
                    Sminutes.ToString.Replace(",", ".")
                    ar = Sminutes.ToString.Split(".")
                    Dim H As String = "0"
                    Dim M As String = "00"
                    If ar.Length = 2 Then
                        M = RoundMe(ar(1) * 100 / 60, 2)
                    End If
                    H = ar(0)
                    totalN = CDbl(H & "." & M)



                    'EmpGross = RoundMe2((TotalWeekNormal + TotalOver) * HourlyRate, 2) + TotalSplit + TotalErn - TotalDed
                    EmpGross = RoundMe2((totalN) * HourlyRate, 2) + RoundMe2(TotalSplit * Global1.SplitRate, 2) + TotalErn - TotalDed

                    'Cost = Cost + EmpCost

                    r(41) = 0

                    EmpCost = EmpCost + EmpGross + RoundMe2(EmpGross * (Global1.PARAM_CostPercentageForTA / 100), 2)
                    Dt4.Rows.Add(r)

                Next
                If CheckDataSet(MyDs4) Then
                    For i = 0 To MyDs4.Tables(0).Rows.Count - 1
                        MyDs4.Tables(0).Rows(i).Item(41) = EmpCost
                    Next
                End If



                ' Utils.WriteSchemaWithXmlTextWriter(MyDs4, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\TimeAttendanceTimes")
                Utils.ShowReport("TimeAttendanceTimes.rpt", MyDs4, FrmReport, "", False, "", False, False, "", True)


                Cursor.Current = Cursors.Default

            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Cannot Load Report")
        End Try
    End Sub
    Private Function FindEmployeeHourlyRate(ByVal Emp As cPrMsEmployees, ByVal SearchDate As Date) As Double
        Dim EmpSalary As New cPrTxEmployeeSalary
        Dim Gross As Double
        Dim NormalPeriodUnits As Double = Global1.PeriodUnitsForTA

        Dim HourlyRate As Double
        EmpSalary = Global1.Business.GetCurrentSalary(Emp.Code, SearchDate)


        Gross = EmpSalary.SalaryValue


        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
            'Hourly
            HourlyRate = Gross
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
            If NormalPeriodUnits = 0 Then
                HourlyRate = 0
            Else
                HourlyRate = RoundMe(Gross / NormalPeriodUnits, 2)
            End If

        End If
        Return HourlyRate


    End Function
    Private Sub InitDataGrid2()
        MyDs2 = New DataSet
        MyDs2.Tables.Add(Dt2)

    End Sub
    Private Sub InitDataTable2()
        Dt2 = New DataTable("Table2")
        '0
        Dt2.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt2.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt2.Columns.Add("MON", System.Type.GetType("System.String"))
        '3
        Dt2.Columns.Add("MONDate", System.Type.GetType("System.String"))
        '4
        Dt2.Columns.Add("MONNormal", System.Type.GetType("System.String"))
        '5
        Dt2.Columns.Add("TUE", System.Type.GetType("System.String"))
        '6
        Dt2.Columns.Add("TUEDate", System.Type.GetType("System.String"))
        '7
        Dt2.Columns.Add("TUENormal", System.Type.GetType("System.String"))
        '8
        Dt2.Columns.Add("WED", System.Type.GetType("System.String"))
        '9
        Dt2.Columns.Add("WEDDate", System.Type.GetType("System.String"))
        '10
        Dt2.Columns.Add("WEDNormal", System.Type.GetType("System.String"))
        '11
        Dt2.Columns.Add("THU", System.Type.GetType("System.String"))
        '12
        Dt2.Columns.Add("THUDate", System.Type.GetType("System.String"))
        '13
        Dt2.Columns.Add("THUNormal", System.Type.GetType("System.String"))
        '14
        Dt2.Columns.Add("FRI", System.Type.GetType("System.String"))
        '15
        Dt2.Columns.Add("FRIDate", System.Type.GetType("System.String"))
        '16
        Dt2.Columns.Add("FRINormal", System.Type.GetType("System.String"))
        '17
        Dt2.Columns.Add("SAT", System.Type.GetType("System.String"))
        '18
        Dt2.Columns.Add("SATDate", System.Type.GetType("System.String"))
        '19
        Dt2.Columns.Add("SATNormal", System.Type.GetType("System.String"))
        '20
        Dt2.Columns.Add("SUN", System.Type.GetType("System.String"))
        '21
        Dt2.Columns.Add("SUNDate", System.Type.GetType("System.String"))
        '22
        Dt2.Columns.Add("SUNNormal", System.Type.GetType("System.String"))
        '23
        Dt2.Columns.Add("OverTime", System.Type.GetType("System.String"))
        '24
        Dt2.Columns.Add("Split", System.Type.GetType("System.String"))
        '25
        Dt2.Columns.Add("Leave", System.Type.GetType("System.String"))
        '26
        Dt2.Columns.Add("Earn", System.Type.GetType("System.String"))
        '27
        Dt2.Columns.Add("Deduction", System.Type.GetType("System.String"))
        '28
        Dt2.Columns.Add("Phone", System.Type.GetType("System.String"))
        '29
        Dt2.Columns.Add("FromDate", System.Type.GetType("System.String"))
        '30
        Dt2.Columns.Add("ToDate", System.Type.GetType("System.String"))
        '31
        Dt2.Columns.Add("Analysis", System.Type.GetType("System.String"))

    End Sub
    Private Sub InitDataGrid3()
        MyDs3 = New DataSet
        MyDs3.Tables.Add(Dt3)

    End Sub
    Private Sub InitDataTable3()
        Dt3 = New DataTable("Table3")
        '0
        Dt3.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt3.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt3.Columns.Add("Total", System.Type.GetType("System.String"))
        '3
        Dt3.Columns.Add("OverTime", System.Type.GetType("System.String"))
        '4
        Dt3.Columns.Add("Split", System.Type.GetType("System.String"))
        '5
        Dt3.Columns.Add("Leave", System.Type.GetType("System.String"))
        '6
        Dt3.Columns.Add("Earn", System.Type.GetType("System.String"))
        '7
        Dt3.Columns.Add("Deduction", System.Type.GetType("System.String"))
        '8
        Dt3.Columns.Add("Phone", System.Type.GetType("System.String"))
        '9
        Dt3.Columns.Add("FromDate", System.Type.GetType("System.String"))
        '10
        Dt3.Columns.Add("ToDate", System.Type.GetType("System.String"))
        '11
        Dt3.Columns.Add("Analysis", System.Type.GetType("System.String"))

    End Sub
    Private Sub InitDataGrid4()
        MyDs4 = New DataSet
        MyDs4.Tables.Add(Dt4)

    End Sub
    Private Sub InitDataTable4()
        Dt4 = New DataTable("Table4")
        '0
        Dt4.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt4.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt4.Columns.Add("MON", System.Type.GetType("System.String"))
        '3
        Dt4.Columns.Add("MONDate", System.Type.GetType("System.String"))
        '4
        Dt4.Columns.Add("MONNormal", System.Type.GetType("System.String"))
        '5
        Dt4.Columns.Add("MONTimes", System.Type.GetType("System.String"))
        '6
        Dt4.Columns.Add("TUE", System.Type.GetType("System.String"))
        '7
        Dt4.Columns.Add("TUEDate", System.Type.GetType("System.String"))
        '8
        Dt4.Columns.Add("TUENormal", System.Type.GetType("System.String"))
        '9
        Dt4.Columns.Add("TUETimes", System.Type.GetType("System.String"))
        '10
        Dt4.Columns.Add("WED", System.Type.GetType("System.String"))
        '11
        Dt4.Columns.Add("WEDDate", System.Type.GetType("System.String"))
        '12
        Dt4.Columns.Add("WEDNormal", System.Type.GetType("System.String"))
        '13
        Dt4.Columns.Add("WEDTimes", System.Type.GetType("System.String"))
        '14
        Dt4.Columns.Add("THU", System.Type.GetType("System.String"))
        '15
        Dt4.Columns.Add("THUDate", System.Type.GetType("System.String"))
        '16
        Dt4.Columns.Add("THUNormal", System.Type.GetType("System.String"))
        '17
        Dt4.Columns.Add("THUTimes", System.Type.GetType("System.String"))
        '18
        Dt4.Columns.Add("FRI", System.Type.GetType("System.String"))
        '19
        Dt4.Columns.Add("FRIDate", System.Type.GetType("System.String"))
        '20
        Dt4.Columns.Add("FRINormal", System.Type.GetType("System.String"))
        '21
        Dt4.Columns.Add("FRITimes", System.Type.GetType("System.String"))
        '22
        Dt4.Columns.Add("SAT", System.Type.GetType("System.String"))
        '23
        Dt4.Columns.Add("SATDate", System.Type.GetType("System.String"))
        '24
        Dt4.Columns.Add("SATNormal", System.Type.GetType("System.String"))
        '25
        Dt4.Columns.Add("SATTimes", System.Type.GetType("System.String"))
        '26
        Dt4.Columns.Add("SUN", System.Type.GetType("System.String"))
        '27
        Dt4.Columns.Add("SUNDate", System.Type.GetType("System.String"))
        '28
        Dt4.Columns.Add("SUNNormal", System.Type.GetType("System.String"))
        '29
        Dt4.Columns.Add("SUNTimes", System.Type.GetType("System.String"))
        '30
        Dt4.Columns.Add("OverTime", System.Type.GetType("System.String"))
        '31
        Dt4.Columns.Add("Split", System.Type.GetType("System.String"))
        '32
        Dt4.Columns.Add("Leave", System.Type.GetType("System.String"))
        '33
        Dt4.Columns.Add("Earn", System.Type.GetType("System.String"))
        '34
        Dt4.Columns.Add("Deduction", System.Type.GetType("System.String"))
        '35
        Dt4.Columns.Add("Phone", System.Type.GetType("System.String"))
        '36
        Dt4.Columns.Add("FromDate", System.Type.GetType("System.String"))
        '37
        Dt4.Columns.Add("ToDate", System.Type.GetType("System.String"))
        '38
        Dt4.Columns.Add("Analysis", System.Type.GetType("System.String"))
        '39
        Dt4.Columns.Add("TotalNormal", System.Type.GetType("System.String"))
        '40
        Dt4.Columns.Add("WeekDescription", System.Type.GetType("System.String"))
        '41
        Dt4.Columns.Add("Cost", System.Type.GetType("System.String"))



    End Sub


    Private Sub btnMonthReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub
    Private Sub PrepareReportMonthly(ByVal DateF As Date, ByVal DateT As Date)
        If CheckDataSet(MyDs3) Then
            MyDs3.Tables(0).Rows.Clear()
        End If
        Cursor.Current = Cursors.WaitCursor

        Dim i As Integer
        Dim ForActual As Boolean

        Dim TotalNormal As Double
        Dim TotalN As Double

        Dim TotalOver As Double
        Dim TotalSplit As Double
        Dim TotalLeave As Double
        Dim TotalErn As Double
        Dim TotalDed As Double

        If CheckDataSet(MyDs) Then
            If Me.MyMode = TaStatus.ACTUAL Then
                ForActual = True
            Else
                ForActual = False
            End If
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Dim EmpCode As String = ""
                Dim Ds As DataSet
                EmpCode = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)
                Dim Emp As New cPrMsEmployees(EmpCode)
                Dim D As Date
                Dim D2 As Date
                D = DateF
                D2 = DateT


                TotalNormal = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "01", "01", ForActual, GLBAnalysis2Code)
                TotalN = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "10", "10", ForActual, GLBAnalysis2Code)
                TotalOver = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "02", "02", ForActual, GLBAnalysis2Code)
                TotalSplit = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "03", "03", ForActual, GLBAnalysis2Code)
                TotalLeave = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "04", "07", ForActual, GLBAnalysis2Code)
                TotalErn = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "08", "08", ForActual, GLBAnalysis2Code)
                TotalDed = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, D, D2, "09", "09", ForActual, GLBAnalysis2Code)

                Dim r As DataRow = Dt3.NewRow()


                r(0) = Emp.Code
                r(1) = Emp.FullName

                r(2) = TotalNormal + TotalN

                r(3) = TotalOver
                r(4) = TotalSplit
                r(5) = TotalLeave
                r(6) = TotalErn
                r(7) = TotalDed

                r(8) = Emp.Telephone1

                r(9) = Format(DateF, "dd-MM-yyyy")
                r(10) = Format(DateT, "dd-MM-yyyy")
                r(11) = LblAnalysis.Text


                Dt3.Rows.Add(r)

            Next


            'Utils.WriteSchemaWithXmlTextWriter(MyDs3, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\TimeAttendance2")
            Utils.ShowReport("TimeAttendanceMonthly.rpt", MyDs3, FrmReport, "", False, "", False, False, "", True)


            Cursor.Current = Cursors.Default

        End If
    End Sub
    Public Sub CallMonthlyReport(ByVal DateF As Date, ByVal DateT As Date)
        PrepareReportMonthly(DateF, DateT)
    End Sub

    Private Sub WeeklyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeeklyReportToolStripMenuItem.Click
        PrepareReport()
    End Sub

    Private Sub MonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyReportToolStripMenuItem.Click
        Dim F As New FrmTAReportDates
        F.MyOwner = Me
        F.ShowDialog()
    End Sub

    Private Sub SelectedEmployeeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectedEmployeeReportToolStripMenuItem.Click
        SelectedEmployeeReport()
    End Sub

    Private Sub TSSendToPayroll_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSendToPayroll.ButtonClick
        If Global1.UserRole = Roles.TimeAttetance Then
            MsgBox("You do not have Permition to Interface with Payroll, No action will take place", MsgBoxStyle.Information)
        Else
            Dim F As New FrmTaInterfaceDates
            F.MyOwner = Me
            F.ShowDialog()
        End If
    End Sub
    Public Sub SendToPayroll(ByVal DateF As Date, ByVal DateT As Date)

        ' Exit Sub
        Dim F As New FrmPayroll1
        If ValidateStatus(DateF, DateT) Then
            'xxxxx()
            Global1.Business.BeginTransaction()
            Try
                Dim Ex As New System.Exception

                Cursor.Current = Cursors.WaitCursor

                Dim i As Integer = 0
                Dim ForActual As Boolean


                If CheckDataSet(MyDs) Then
                    If Me.MyMode = TaStatus.ACTUAL Then
                        ForActual = True
                    Else
                        ForActual = False
                    End If

                    F.Show()
                    F.LoadForm()
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1

                        'Validate(status)


                        Dim EmpCode As String = ""
                        Dim Ds As DataSet
                        EmpCode = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        If Emp.EmpAn5_Code = Me.GLBAnalysis2Code Then

                            Dim D As Date
                            Dim D2 As Date
                            D = DateF
                            D2 = DateT



                            Dim Clear As Boolean = False
                            If i = 0 Then
                                Clear = True
                            End If

                            F.FindCurentPeriodForTA(False, CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup), EmpCode, D, D2)


                            If Not Global1.Business.SetTAStatusToInterfaceForEmployee(EmpCode, D, D2) Then
                                Throw Ex
                            End If

                        End If
                        Application.DoEvents()
                    Next

                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        Dim EmpCode As String = ""
                        Dim Ds As DataSet
                        EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Column_EmpCode))

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        If Emp.EmpAn5_Code = Me.GLBAnalysis2Code Then
                            Dim D As Date
                            Dim D2 As Date
                            D = DateF
                            D2 = DateT


                            F.FixEmployeeTA(EmpCode, D, D2)
                        End If
                        Application.DoEvents()
                    Next
                    F.TryToSavePrepare(True)



                    Cursor.Current = Cursors.Default

                End If
                Global1.Business.CommitTransaction()
                F.Close()
            Catch ex As Exception
                F.Close()
                Utils.ShowException(ex)
                Global1.Business.Rollback()
            End Try


        End If
    End Sub
    Public Function ValidateStatus(ByVal DateF As Date, ByVal DateT As Date) As Boolean
        Dim i As Integer
        Dim Flag As Boolean = True
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            Dim EmpCode As String = ""
            Dim Ds As DataSet
            EmpCode = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)

            Dim D As Date
            Dim D2 As Date
            D = DateF
            D2 = DateT

            Ds = Global1.Business.FindEmployeeInterfaceStatusForTA(EmpCode, D, D2)
            If CheckDataSet(Ds) Then
                Dim k As Integer
                Dim Date1 As Date
                Dim Str As String
                Dim Emp As New cPrMsEmployees(EmpCode)
                If Emp.EmpAn5_Code = Me.GLBAnalysis2Code Then
                    Str = "Time Attendance for Employee " & EmpCode & " - " & Emp.FullName
                    Str = Str & " are already Send to Payroll For Dates " & Chr(13)
                    For k = 0 To Ds.Tables(0).Rows.Count - 1
                        Date1 = DbNullToDate(Ds.Tables(0).Rows(k).Item(1))
                        Str = Str & Format(Date1, "dd-MM-yyyy") & " " & Chr(13)
                    Next
                    Str = Str & " Cannot send Time Attendance entries Again"

                    MsgBox(Str, MsgBoxStyle.Critical)
                    Flag = False
                    Exit For
                End If
            End If
        Next
        Return Flag

    End Function

    Private Sub WeeklyReportPerTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeeklyReportPerTimeToolStripMenuItem.Click
        Me.PrepareReportTimes()
    End Sub

   


   
End Class