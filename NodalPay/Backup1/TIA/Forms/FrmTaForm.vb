Public Class FrmTaForm

    Public AnalysisIndex As Integer

    ' Public GLBAnalysisHours As Integer = 9
    Dim Ar_combo() As ComboBox
    Dim Ar_Fromtime() As MaskedTextBox
    Dim Ar_Totime() As MaskedTextBox
    Dim Ar_TotalTime() As TextBox
    Dim Ar_ComboAnal() As ComboBox
    Dim Ar_txtcost() As TextBox

    Dim Ar_Error1() As System.Windows.Forms.ErrorProvider
    Dim Ar_Error2() As System.Windows.Forms.ErrorProvider

    Public ScreenMode As String
    Public NumberOfLines As Integer
    Public TrxnLines() As cTaTxTrxnLines
    Public TrxnLines2() As cTaTxTrxnLines2
    Public MyStatus As String = "OUTS"

    Friend MyMode As TaStatus

    Public MyOwner As FrmTATrxnLines
    Dim DoNotEnter As Boolean = False
    Public GlbEmpCode As String
    Public MyDay As String
    Public MyRow As Integer
    Public MyColumn As Integer

    Dim Type_Normal As String = "N"
    Dim Type_Leave As String = "L"
    Dim Type_Overtime As String = "O"
    Dim Type_Split As String = "S"
    Dim Type_Earning As String = "E"
    Dim Type_Deduction As String = "D"
    Dim Type_IN As String = "I"


    Dim SalaryPerUnit As Double

    Dim Mydate As Date
    Dim DoNotSave As Boolean = False

    Dim Saved As Boolean = False
    Public Loading As Boolean = False
    Public CalledFromAnalysis

    Public Sub StatusChangeToPROC()

        MyStatus = "POST"
        RefreshStatus("OUTS", "POST")
        DisableControls()


        'FindColumnText()
    End Sub
    Public Sub StatusChangeToACTL()

        MyStatus = "ACTL"
        RefreshStatus("POST", "ACTL")
        DisableControls()


        'FindColumnText()
    End Sub
    Private Sub DisableControls()
        btnSave.Enabled = False

        Dim i As Integer

        For i = 0 To Ar_combo.Length - 1
            Ar_combo(i).Enabled = False
            Ar_Fromtime(i).Enabled = False
            Ar_Totime(i).Enabled = False
            Ar_TotalTime(i).Enabled = False
            Ar_ComboAnal(i).Enabled = False
            Ar_txtcost(i).Enabled = False
        Next
    End Sub

    Private Sub FrmTaForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
       
        'Show Total On button
        Dim i As Integer
        'Dim totalTime As Double = CalculateTotalForTime()

        'Me.MyOwner.MyDs.Tables(0).Rows(MyRow).Item(MyColumn) = Format(totalTime, "0.00")

        FindColumnText()
        If MyMode = TaStatus.ACTUAL Then
            For i = 0 To TrxnLines2.Length - 1
                Me.Ar_combo(i).SelectedIndex = 0
                Me.Ar_ComboAnal(i).SelectedIndex = AnalysisIndex
                Me.Ar_Fromtime(i).Text = "00:00"
                Me.Ar_Totime(i).Text = "00:00"
                Me.Ar_TotalTime(i).Text = "0.00"
            Next

        Else
            For i = 0 To TrxnLines.Length - 1
                Me.Ar_combo(i).SelectedIndex = 0
                Me.Ar_ComboAnal(i).SelectedIndex = AnalysisIndex
                Me.Ar_Fromtime(i).Text = "00:00"
                Me.Ar_Totime(i).Text = "00:00"
                Me.Ar_TotalTime(i).Text = "0.00"
            Next

        End If


    End Sub
    Public Sub FindColumnText()

        If Saved Or Loading Then


            Dim i As Integer
            Dim s As String = ""
            Dim Desc As String = ""
            Dim Counter As Integer = 0
            Dim MyType As String
            Dim TotalAmount As Double
            Dim totalCost As Double = 0

            If MyMode = TaStatus.ACTUAL Then
                For i = 0 To TrxnLines2.Length - 1
                    If Me.Ar_combo(i).Text <> "" Then
                        Counter = Counter + 1
                        MyType = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Mytype
                        If MyType = Me.Type_Earning Then
                            s = s & " " & Ar_TotalTime(i).Text
                            TotalAmount = TotalAmount + CDbl(Ar_TotalTime(i).Text)
                        ElseIf MyType = Me.Type_Deduction Then
                            s = s & "-" & Ar_TotalTime(i).Text
                            TotalAmount = TotalAmount - CDbl(Ar_TotalTime(i).Text)
                        ElseIf MyType = Me.Type_Split Then
                            s = s & " SPLIT"
                        ElseIf MyType = Me.Type_IN Then
                            s = s & " " & Ar_TotalTime(i).Text & "              "
                        Else
                            s = s & " " & Ar_Fromtime(i).Text & " - " & Ar_Totime(i).Text
                              
                        End If
                        If MyType <> Type_Split Then
                            Desc = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Desc
                            If Desc.Length > 3 Then
                                Desc = Desc.Substring(0, 3)
                            End If
                            s = s & " " & Desc
                        End If
                        s = s & Chr(10)
                        totalCost = totalCost + Ar_txtcost(i).Text
                    End If
                Next
            Else
                For i = 0 To TrxnLines.Length - 1
                    If Me.Ar_combo(i).Text <> "" Then
                        Counter = Counter + 1
                        MyType = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Mytype
                        If MyType = Me.Type_Earning Then
                            s = s & " " & Ar_TotalTime(i).Text
                            TotalAmount = TotalAmount + CDbl(Ar_TotalTime(i).Text)
                        ElseIf MyType = Me.Type_Deduction Then
                            s = s & "-" & Ar_TotalTime(i).Text
                            TotalAmount = TotalAmount - CDbl(Ar_TotalTime(i).Text)
                        ElseIf MyType = Me.Type_Split Then
                            s = s & " SPLIT"
                        ElseIf MyType = Me.Type_IN Then
                            s = s & " " & Ar_TotalTime(i).Text & "              "
                        Else
                            s = s & " " & Ar_Fromtime(i).Text & " - " & Ar_Totime(i).Text
                        End If
                        If MyType <> Type_Split Then
                            Desc = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Desc
                            If Desc.Length > 3 Then
                                Desc = Desc.Substring(0, 3)
                            End If
                            s = s & " " & Desc
                        End If
                        s = s & Chr(10)
                        totalCost = totalCost + Ar_txtcost(i).Text
                    End If
                Next
            End If




            Dim totalTime As Double = CalculateTotalForTime()
            If Counter <> 0 Then
                's = s & "________________" & Chr(10)
                s = s & " -------  " & MyStatus & "  -------" & Chr(10)
            End If
            s = s & " Total Time : " & Format(totalTime, "0.00") & Chr(10)
            s = s & " Total Value: " & Format(TotalAmount, "0.00") '& Chr(10)
            's = s & " Total Cost : " & Format(TotalCost, "0.00")
            's = s & MyStatus

            Me.MyOwner.MyDs.Tables(0).Rows(MyRow).Item(MyColumn) = s
            If Not Loading Then
                Dim SS As String
                SS = SS & " Total Time : " & Format(0, "0.00") & Chr(10)
                SS = SS & " Total Value: " & Format(0, "0.00") '& Chr(10)
                If s <> SS Then
                    CType(Me.Owner, FrmTATrxnLines).DG1.Rows(MyRow).Cells(MyColumn).Style.BackColor = Drawing.Color.Yellow
                Else
                    CType(Me.Owner, FrmTATrxnLines).DG1.Rows(MyRow).Cells(MyColumn).Style.BackColor = CType(Me.Owner, FrmTATrxnLines).DG1.Rows(MyRow).Cells(0).Style.BackColor
                End If
            End If

            CheckLineHeight()
        End If

    End Sub
    Private Function CheckLineHeight() As Integer
        Dim RowH As Integer
        Dim i As Integer
        Dim S As String = ""
        Dim Ar() As String
        Dim max As Integer = 0
        For i = 2 To 8
            S = MyOwner.MyDs.Tables(0).Rows(MyRow).Item(i)
            Ar = S.Split(Chr(10))
            If max < Ar.Length Then
                max = Ar.Length
            End If
        Next
        If max <> 0 Then
            If max <= 2 Then
                RowH = max * 35
            ElseIf max <= 4 Then
                RowH = max * 25
            Else
                RowH = max * 20
            End If

            Me.MyOwner.DG1.Rows(MyRow).Height = RowH
        Else
            Me.MyOwner.DG1.Rows(MyRow).Height = 35
        End If


    End Function
    Private Sub FrmTaForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CalculateSalaryperunits(Mydate)

        DoNotEnter = True
        Dim i As Integer
        If MyMode = TaStatus.ACTUAL Then
            For i = 0 To TrxnLines2.Length - 1
                If Not TrxnLines2(i) Is Nothing Then

                    Dim W As New cTaMsWorkCodes(TrxnLines2(i).WorkCode, TrxnLines2(i).WorkGroupCode)
                    Dim A As New cPrAnEmployeeAnalysis5(TrxnLines2(i).AnalCode)
                    If Not A.EmpAn5_Code Is Nothing Then
                        Me.Ar_ComboAnal(i).SelectedIndex = Me.Ar_ComboAnal(i).FindStringExact(A.ToString)

                    End If
                    


                    Me.Ar_combo(i).SelectedIndex = Me.Ar_combo(i).FindStringExact(W.ToString)
                    Me.Ar_Fromtime(i).Text = TrxnLines2(i).FromTime

                    Me.Ar_Totime(i).Text = TrxnLines2(i).ToTime
                    Me.Ar_TotalTime(i).Text = Format(TrxnLines2(i).TotalTime, "0.00")
                    CalculateLineCost(i)

                End If
            Next
        Else
            For i = 0 To TrxnLines.Length - 1
                If Not TrxnLines(i) Is Nothing Then

                    Dim W As New cTaMsWorkCodes(TrxnLines(i).WorkCode, TrxnLines(i).WorkGroupCode)

                    Dim A As New cPrAnEmployeeAnalysis5(TrxnLines(i).AnalCode)

                    If Not A.EmpAn5_Code Is Nothing Then
                        Me.Ar_ComboAnal(i).SelectedIndex = Me.Ar_ComboAnal(i).FindStringExact(A.ToString)
                    End If

                    Me.Ar_combo(i).SelectedIndex = Me.Ar_combo(i).FindStringExact(W.ToString)
                    Me.Ar_Fromtime(i).Text = TrxnLines(i).FromTime

                    Me.Ar_Totime(i).Text = TrxnLines(i).ToTime
                    Me.Ar_TotalTime(i).Text = Format(TrxnLines(i).TotalTime, "0.00")
                    CalculateLineCost(i)

                  

                End If
            Next
        End If

        Dim Emp As New cPrMsEmployees(Me.GlbEmpCode)

        If CalledFromAnalysis <> Emp.EmpAn5_Code Then
            DisableControls()
            Me.btnSave.Enabled = False
        Else
            Me.btnSave.Enabled = True
        End If
        DoNotEnter = False
        CalculateTotalCost()
    End Sub
    Private Sub CalculateTotalCost()
        'Dim i As Integer
        'Dim TotalCost As Double
        'For i = 0 To Ar_txtcost.Length - 1
        ' TotalCost = TotalCost + Ar_txtcost(i).Text
        ' Next
        ' Me.txtTotalCost.Text = Format(totalcost, "0.00")
    End Sub
    Private Sub CalculateLineCost(ByVal i As Integer)

        'Me.Ar_txtcost(i).Text = Format(RoundMe2(TrxnLines(i).TotalTime * Me.SalaryPerUnit, 2), "0.00")
    End Sub
    Private Sub CalculateLine2Cost(ByVal i As Integer)
        'Me.Ar_txtcost(i).Text = Format(RoundMe2(Ar_TotalTime(i).Text * Me.SalaryPerUnit, 2), "0.00")
    End Sub
    Private Sub CalculateSplitRate(ByVal i As Integer)
        'Me.Ar_txtcost(i).Text = Format(Global1.SplitRate, "0.00")
    End Sub

    Public Sub RefreshStatus(ByVal Oldstatus As String, ByVal Newstatus As String)

        Dim s As String
        s = Me.txtDateAndDay.Text
        s = s.Replace(Oldstatus, Newstatus)
        Me.txtDateAndDay.Text = s
    End Sub
    Public Sub LoadMe(ByVal Row As Integer, ByVal Column As Integer, ByVal Day As String, ByVal DisplayDate As Date)
        Dim i As Integer
        Dim Error1 As String
        Error1 = 1
        Try

            DoNotEnter = True
            If MyMode = TaStatus.SCHEDULE Then
                If MyStatus = "POST" Then
                    DisableControls()
                Else
                    Me.btnSave.Enabled = True
                End If
            Else
                MyStatus = "POST"
                For i = 0 To TrxnLines2.Length - 1
                    If Not TrxnLines2(i) Is Nothing Then
                        MyStatus = TrxnLines2(i).Status
                    End If
                Next
                If MyStatus = "ACTL" Then
                    DisableControls()
                Else
                    Me.btnSave.Enabled = True

                End If
            End If

            Dim TotalTime As Double = 0

            MyRow = Row
            MyColumn = Column
            Mydate = DateAdd(DateInterval.Day, (Column - 2), DisplayDate)
            Me.txtDateAndDay.Text = UCase(Day) & "   " & DateAdd(DateInterval.Day, (Column - 2), DisplayDate)
            Me.txtDateAndDay.Text = Me.txtDateAndDay.Text & " STATUS = " & MyStatus


            If MyMode = TaStatus.ACTUAL Then

                For i = 0 To TrxnLines2.Length - 1
                    Me.Ar_combo(i).SelectedIndex = 0
                    Me.Ar_Fromtime(i).Text = "00:00"
                    Me.Ar_Totime(i).Text = "00:00"
                    Me.Ar_TotalTime(i).Text = "0.00"
                    Me.Ar_ComboAnal(i).SelectedIndex = Me.AnalysisIndex
                Next

                For i = 0 To TrxnLines2.Length - 1
                    If Not TrxnLines2(i) Is Nothing Then
                        MyStatus = TrxnLines2(i).Status
                        Dim W As New cTaMsWorkCodes(TrxnLines2(i).WorkCode, TrxnLines2(i).WorkGroupCode)

                        Dim A As New cPrAnEmployeeAnalysis5(TrxnLines2(i).AnalCode)
                        If Not A.EmpAn5_Code Is Nothing Then
                            Me.Ar_ComboAnal(i).SelectedIndex = Me.Ar_ComboAnal(i).FindStringExact(A.ToString)
                        End If

                        Me.Ar_combo(i).SelectedIndex = Me.Ar_combo(i).FindStringExact(W.ToString)
                        Me.Ar_Fromtime(i).Text = TrxnLines2(i).FromTime

                        Me.Ar_Totime(i).Text = TrxnLines2(i).ToTime
                        Me.Ar_TotalTime(i).Text = Format(TrxnLines2(i).TotalTime, "0.00")

                        Me.Ar_ComboAnal(i).SelectedIndex = Me.AnalysisIndex


                        If MyStatus <> "ACTL" Then
                            Select Case W.Mytype
                                Case Me.Type_Normal
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Split
                                    Me.Ar_TotalTime(i).Enabled = False
                                    Me.EnableObjects(False, i)
                                Case Me.Type_Leave
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Overtime
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Deduction
                                    Me.EnableObjects(False, i)
                                Case Me.Type_Earning
                                    Me.EnableObjects(False, i)
                                Case Me.Type_IN
                                    Me.Ar_TotalTime(i).Enabled = False
                                    Me.EnableObjects(True, i)
                              
                            End Select
                        End If

                    End If

                Next
            Else

                For i = 0 To TrxnLines.Length - 1
                    Me.Ar_combo(i).SelectedIndex = 0
                    Me.Ar_Fromtime(i).Text = "00:00"
                    Me.Ar_Totime(i).Text = "00:00"
                    Me.Ar_TotalTime(i).Text = "0.00"
                    Me.Ar_txtcost(i).Text = "0.00"
                    Me.Ar_ComboAnal(i).SelectedIndex = Me.AnalysisIndex
                Next

                For i = 0 To TrxnLines.Length - 1
                    If Not TrxnLines(i) Is Nothing Then
                        MyStatus = TrxnLines(i).Status
                        Dim W As New cTaMsWorkCodes(TrxnLines(i).WorkCode, TrxnLines(i).WorkGroupCode)

                        Dim A As New cPrAnEmployeeAnalysis5(TrxnLines(i).AnalCode)
                        If Not A.EmpAn5_Code Is Nothing Then
                            Me.Ar_ComboAnal(i).SelectedIndex = Me.Ar_ComboAnal(i).FindStringExact(A.ToString)
                        End If

                        Me.Ar_combo(i).SelectedIndex = Me.Ar_combo(i).FindStringExact(W.ToString)
                        Me.Ar_Fromtime(i).Text = TrxnLines(i).FromTime

                        Me.Ar_Totime(i).Text = TrxnLines(i).ToTime
                        Me.Ar_TotalTime(i).Text = Format(TrxnLines(i).TotalTime, "0.00")
                        If MyStatus <> "POST" Then
                            Select Case W.Mytype
                                Case Me.Type_Normal
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Split
                                    Me.Ar_TotalTime(i).Enabled = False
                                    Me.EnableObjects(False, i)
                                Case Me.Type_Leave
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Overtime
                                    Me.EnableObjects(True, i)
                                Case Me.Type_Deduction
                                    Me.EnableObjects(False, i)
                                Case Me.Type_Earning
                                    Me.EnableObjects(False, i)
                                Case Me.Type_IN
                                    Me.Ar_TotalTime(i).Enabled = True
                                    Me.EnableObjects(False, i)
                              
                            End Select
                        End If

                    End If

                Next
            End If
            Error1 = 2
            TotalTime = CalculateTotalForTime()
            Error1 = 3


            '  Me.MyOwner.MyDs.Tables(0).Rows(Row).Item(Column) = Format(TotalTime, "0.00")
            FindColumnText()
            DoNotEnter = False
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Error 2:" & Error1)
        End Try
    End Sub
    Public Sub CalculateSalaryperunits(ByVal DateFor As Date)

        Try
            SalaryPerUnit = 0
            Dim PeriodUnits As Double = Global1.PeriodUnitsForTA
            Dim cEmp As New cPrMsEmployees(Me.GlbEmpCode)

            Dim Salary As cPrTxEmployeeSalary
            Salary = Global1.Business.GetCurrentSalary(GlbEmpCode, DateFor)
            If cEmp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                If PeriodUnits <> 0 Then
                    Me.SalaryPerUnit = RoundMe3(Salary.SalaryValue / PeriodUnits, 2)
                End If
            Else
                SalaryPerUnit = Salary.SalaryValue
            End If


        Catch ex As Exception
            SalaryPerUnit = 0
        End Try

    End Sub
    Public Sub InitializeMe(ByVal ds As DataSet, ByVal DsAnal As DataSet, ByVal Analysis2Index As Integer)

        
        Dim i As Integer

        Me.AnalysisIndex = Analysis2Index

        TryToCreateControls(NumberOfLines)
        If MyMode = TaStatus.ACTUAL Then
            ReDim TrxnLines2(NumberOfLines)
            'MyStatus = "POST"
        Else
            ReDim TrxnLines(NumberOfLines)
            'MyStatus = "OUTS"
        End If
        For i = 0 To NumberOfLines
            LoadCombo(i, ds)
            LoadComboAnal(i, DsAnal, Analysis2Index)

        Next
    End Sub
    Public Sub LoadCombo(ByVal i As Integer, ByVal ds As DataSet)
        Dim k As Integer
        With Ar_combo(i)
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("")
            For k = 0 To ds.Tables(0).Rows.Count - 1
                Dim W As New cTaMsWorkCodes(ds.Tables(0).Rows(k))
                .Items.Add(W)
            Next
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Public Sub LoadComboAnal(ByVal i As Integer, ByVal dsAnal As DataSet, ByVal analysis2index As Integer)
        Dim k As Integer
        With Ar_ComboAnal(i)
            .BeginUpdate()
            .Items.Clear()
            For k = 0 To dsAnal.Tables(0).Rows.Count - 1
                Dim W As New cPrAnEmployeeAnalysis5(dsAnal.Tables(0).Rows(k))
                .Items.Add(W)
            Next
            .EndUpdate()
            .SelectedIndex = analysis2index
        End With
    End Sub
    Private Sub TryToCreateControls(ByVal N As Integer)
        DoNotEnter = True

        Dim Dif1 As Integer = 20
        Dim Dif2 As Integer = 20
        Dim X As Integer = 5
        Dim X2 As Integer = 5
        Dim ORIGINALTOP = 45

        ReDim Ar_combo(N)
        ReDim Ar_Fromtime(N)
        ReDim Ar_Totime(N)
        ReDim Ar_TotalTime(N)
        ReDim Ar_Error1(N)
        ReDim Ar_Error2(N)
        ReDim Ar_ComboAnal(N)
        ReDim Ar_txtcost(N)

        'Combo
        Dim CTop As Integer
        Dim CLeft As Integer = Me.Combo.Left
        Me.Combo.Visible = False
        Dim i As Integer

        For i = 0 To N
            Dim S As New ComboBox
            S.Size = Me.Combo.Size
            CTop = ORIGINALTOP + ((Combo.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(CLeft, CTop)
            S.Name = "Combo_" & i + 1
            S.Text = ""
            S.Tag = i
            S.TabIndex = i
            S.Visible = True
            S.DropDownStyle = Me.Combo.DropDownStyle
            Me.Controls.Add(S)
            Ar_combo(i) = S
            S.BackColor = Color.Yellow
        Next

        'From Time
        Dim FTTop As Integer
        Dim FTLeft As Integer = Me.TimeFrom.Left
        Me.TimeFrom.Visible = False


        For i = 0 To N
            Dim S As New MaskedTextBox
            S.Size = Me.TimeFrom.Size
            S.Mask = Me.TimeFrom.Mask
            FTTop = ORIGINALTOP + ((Combo.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(FTLeft, FTTop)
            S.Name = "TimeFrom_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            S.Text = "00:00"
            S.Tag = i
            S.ValidatingType = GetType(DateAndTime)
            Ar_Fromtime(i) = S
            S.BackColor = Color.Yellow
        Next

        'To Time
        Dim TTTop As Integer
        Dim TTLeft As Integer = Me.TimeTo.Left
        Me.TimeTo.Visible = False


        For i = 0 To N
            Dim S As New MaskedTextBox
            S.Size = Me.TimeTo.Size
            S.Mask = Me.TimeTo.Mask
            TTTop = ORIGINALTOP + ((Combo.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TTLeft, TTTop)
            S.Name = "TimeTo_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            S.Text = "00:00"
            S.Tag = i
            S.ValidatingType = GetType(DateAndTime)
            Ar_Totime(i) = S
            S.BackColor = Color.Yellow
        Next

        'Total Time
        Dim TTop As Integer
        Dim TLeft As Integer = Me.txtTotaltime.Left
        Me.txtTotaltime.Visible = False


        For i = 0 To N
            Dim S As New TextBox
            S.Size = Me.txtTotaltime.Size
            TTop = ORIGINALTOP + ((Combo.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TLeft, TTop)
            S.Name = "txtTotalTime_" & i + 1
            S.Text = "0.00"
            S.Tag = i
            S.Visible = True
            Me.Controls.Add(S)

            Ar_TotalTime(i) = S
            S.BackColor = Color.Yellow
        Next
        For i = 0 To N
            Dim S As New System.Windows.Forms.ErrorProvider
            CType(S, System.ComponentModel.ISupportInitialize).BeginInit()
            S.ContainerControl = Me
            CType(S, System.ComponentModel.ISupportInitialize).EndInit()
            Ar_Error1(i) = S
        Next
        For i = 0 To N
            Dim S As New System.Windows.Forms.ErrorProvider
            CType(S, System.ComponentModel.ISupportInitialize).BeginInit()
            S.ContainerControl = Me
            CType(S, System.ComponentModel.ISupportInitialize).EndInit()
            Ar_Error2(i) = S
        Next

        Dim ATop As Integer
        Dim ALeft As Integer = Me.ComboAnal.Left
        ComboAnal.Visible = False

        For i = 0 To N
            Dim S As New ComboBox
            S.Size = Me.ComboAnal.Size
            ATop = ORIGINALTOP + ((ComboAnal.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(ALeft, ATop)
            S.Name = "ComboAnal_" & i + 1
            S.Text = ""
            S.Tag = i
            S.TabIndex = i
            S.Visible = True
            S.DropDownStyle = Me.ComboAnal.DropDownStyle
            Me.Controls.Add(S)
            Ar_ComboAnal(i) = S
            S.BackColor = Color.Yellow
        Next

        Dim CostTop As Integer
        Dim CostLeft As Integer = Me.txtCost.Left
        txtCost.Visible = False

        For i = 0 To N
            Dim S As New TextBox
            S.Size = Me.txtCost.Size
            CostTop = ORIGINALTOP + ((txtCost.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(CostLeft, CostTop)
            S.Name = "txtCost_" & i + 1
            S.Text = "0.00"
            S.Tag = i
            S.TabIndex = i
            S.Visible = True
            Me.Controls.Add(S)
            Ar_txtCost(i) = S
            S.BackColor = Color.Yellow
        Next






        DoNotEnter = False
        Me.AddHandlersTo_Combo()
        Me.AddHandlersTo_FromTime()
        Me.AddHandlersTo_ToTime()
        Me.AddHandlersTo_TotalTime()
        Me.AddHandlersTo_ComboAnal()
    End Sub
    Private Sub AddHandlersTo_Combo()
        Dim i As Integer
        For i = 0 To Ar_combo.Length - 1
            AddHandler CType(Ar_combo(i), ComboBox).KeyUp, AddressOf ComboBox_KeyUp
            AddHandler CType(Ar_combo(i), ComboBox).SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged
        Next
    End Sub
    Private Sub AddHandlersTo_ComboAnal()
        Dim i As Integer
        For i = 0 To Ar_combo.Length - 1
            AddHandler CType(Ar_combo(i), ComboBox).KeyUp, AddressOf ComboBoxAnal_KeyUp
            AddHandler CType(Ar_combo(i), ComboBox).SelectedIndexChanged, AddressOf ComboAnal_SelectedIndexChanged
        Next
    End Sub
    Private Sub AddHandlersTo_FromTime()
        Dim i As Integer
        For i = 0 To Ar_Fromtime.Length - 1
            AddHandler CType(Ar_Fromtime(i), MaskedTextBox).TextChanged, AddressOf Fromtime_TextChanged
            AddHandler CType(Ar_Fromtime(i), MaskedTextBox).KeyUp, AddressOf FromTime_KeyUp
        Next
    End Sub
    Private Sub AddHandlersTo_ToTime()
        Dim i As Integer
        For i = 0 To Ar_Totime.Length - 1
            AddHandler CType(Ar_Totime(i), MaskedTextBox).TextChanged, AddressOf Totime_TextChanged
            AddHandler CType(Ar_Totime(i), MaskedTextBox).KeyUp, AddressOf ToTime_KeyUp
        Next
    End Sub
    Private Sub AddHandlersTo_TotalTime()
        Dim i As Integer
        For i = 0 To Ar_TotalTime.Length - 1
            AddHandler CType(Ar_TotalTime(i), TextBox).KeyUp, AddressOf TotalTime_KeyUp
            AddHandler CType(Ar_TotalTime(i), TextBox).TextChanged, AddressOf TotalTime_TextChanged
        Next
    End Sub
    Private Sub Fromtime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub
        Dim index As Integer
        index = CType(sender, MaskedTextBox).Tag
        If Me.Ar_Fromtime(index).MaskCompleted Then
            If IsFromTimeDate(index) Then
                If Me.Ar_Totime(index).MaskCompleted Then
                    If IsToTimeDate(index) Then
                        AutomaticAddTime(index)
                        CalculateTotalTime(index)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Totime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub
        Dim index As Integer
        index = CType(sender, MaskedTextBox).Tag
        If Me.Ar_Totime(index).MaskCompleted Then
            If IsToTimeDate(index) Then
                If Me.Ar_Fromtime(index).MaskCompleted Then
                    If IsFromTimeDate(index) Then
                        CalculateTotalTime(index)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Totaltime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub

        Dim index As Integer
        Dim OverHour As Integer = 0
        Dim OverMin As Integer = 0
        index = CType(sender, TextBox).Tag
        Dim GLBAnalysisHour As Integer
        Dim GLBAnalysisbreak As Integer

        If Ar_combo(index).SelectedIndex <> 0 Then
            If CType(Me.Ar_combo(index).SelectedItem, cTaMsWorkCodes).Mytype = Type_Normal Then
                Dim AddOvertime As Boolean = False
                Dim Dif As Integer
                Dim OverTimeminutes As Integer
                '''''''''''''''
                Dim F1 As String
                Dim T1 As String
                Dim F2 As Date
                Dim T2 As Date

                F1 = Me.Ar_Fromtime(index).Text
                T1 = Me.Ar_Totime(index).Text
                Dim NewT As Date


                F2 = Now.Date & " " & F1 & ":00"
                T2 = Now.Date & " " & T1 & ":00"
                If T2 < F2 Then
                    NewT = DateAdd(DateInterval.Day, 1, Now.Date)
                    T2 = NewT & " " & T1 & ":00"
                End If


                Dim TT() As String
                Dim S As String
                S = CType(Ar_ComboAnal(index).SelectedItem, cPrAnEmployeeAnalysis5).GLAnal2
                TT = S.Split("|")
                GLBAnalysisHour = TT(0)
                GLBAnalysisbreak = TT(1)

                Dim SumOfAllNormal As Double
                SumOfAllNormal = CalculateAlloftype_normal(index)

                Dif = DateDiff(DateInterval.Minute, CDate(F2), CDate(T2))
                Dif = Dif + SumOfAllNormal
                Dif = CalculateAllNormalTimexx()



                If GLBAnalysisHour * 60 < Dif Then
                    AddOvertime = True
                Else
                    AddOvertime = False
                End If

                OverTimeminutes = Dif - (GLBAnalysisHour * 60)

                'Minutes = Dif Mod 60
                'Ar = (Dif / 60).ToString.Split(".")
                'Hours = Ar(0)

                If AddOvertime Then
                    F1 = Me.Ar_Totime(index).Text
                    F2 = Now.Date & " " & F1 & ":00"
                    F2 = DateAdd(DateInterval.Minute, -OverTimeminutes, F2)
                    Me.Ar_Totime(index).Text = F2.Hour.ToString.PadLeft(2, "0") & ":" & OverMin.ToString.PadLeft(2, "0")

                    'AddOvertime
                    Ar_combo(index + 1).SelectedIndex = 2
                    Me.Ar_Fromtime(index + 1).Text = Me.Ar_Totime(index).Text
                    Me.Ar_Totime(index + 1).Text = Me.Ar_Totime(index).Text

                    F1 = Me.Ar_Fromtime(index + 1).Text
                    F2 = Now.Date & " " & F1 & ":00"
                    F2 = DateAdd(DateInterval.Minute, OverTimeminutes, F2)
                    Me.Ar_Totime(index + 1).Text = F2.Hour.ToString.PadLeft(2, "0") & ":" & F2.Minute.ToString.PadLeft(2, "0")
                    Me.Ar_ComboAnal(index + 1).SelectedIndex = Me.Ar_ComboAnal(index).SelectedIndex
                End If

            End If
        End If

    End Sub
    Private Function CalculateAlloftype_normal(ByVal index As Integer) As Integer

        Dim i As Integer = 0
        Dim TotalTimeInMinutes As Integer = 0
        For i = 0 To Ar_combo.Length - 1
            If Me.Ar_combo(i).SelectedIndex <> 0 Then
                If CType(Me.Ar_combo(i).SelectedItem, cTaMsWorkCodes).Mytype = Type_Normal Then
                    If i <> index Then
                        Dim Ar() As String
                        Dim H As Integer
                        Dim M As Integer
                        Ar = Me.Ar_TotalTime(i).Text.Split(".")
                        H = Ar(0)
                        M = Ar(1)
                        TotalTimeInMinutes = TotalTimeInMinutes + H * 60 + M
                    End If
                End If
            End If
        Next

        Return TotalTimeInMinutes

    End Function

    Private Sub FromTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, MaskedTextBox).Tag
            If Me.Ar_Fromtime(index).MaskCompleted Then
                AutomaticAddTime(index)
            End If
            Me.Ar_Totime(index).Focus()
            Me.Ar_Totime(index).SelectAll()
        End If
    End Sub
    Private Sub ToTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, MaskedTextBox).Tag
            If index < Me.Ar_combo.Length - 1 Then
                Me.Ar_combo(index + 1).Focus()
                Me.Ar_combo(index + 1).SelectAll()
            Else
                Me.btnSave.Focus()
            End If
        End If
    End Sub
    Private Sub TotalTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, TextBox).Tag
            If index < Me.Ar_combo.Length - 1 Then
                Me.Ar_combo(index + 1).Focus()
                Me.Ar_combo(index + 1).SelectAll()
            End If
        End If
    End Sub
    Private Sub ComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer
            index = CType(sender, ComboBox).Tag
            If Me.Ar_Fromtime(index).Enabled = False Then
                Me.Ar_TotalTime(index).Focus()
                Me.Ar_TotalTime(index).SelectAll()
            Else
                Me.Ar_Fromtime(index).Focus()
                Me.Ar_Fromtime(index).SelectAll()
            End If
        End If
    End Sub
    Private Sub AutomaticAddTime(ByVal Index As Integer)

        If Ar_combo(Index).SelectedIndex <> 0 Then
            If CType(Ar_combo(Index).SelectedItem, cTaMsWorkCodes).Mytype = Me.Type_Normal Then
                If Ar_combo(Index).Text = "11 SPLIT 2" Then
                    Me.Ar_Totime(Index).Text = Me.Ar_Fromtime(Index).Text
                Else
                    Dim GLBAnalysisHours As Integer
                    Dim GLBAnalysisBreak As Int16
                    Dim TT() As String
                    Dim S As String
                    S = CType(Ar_ComboAnal(Index).SelectedItem, cPrAnEmployeeAnalysis5).GLAnal2
                    TT = S.Split("|")
                    GLBAnalysisHours = TT(0)
                    GLBAnalysisBreak = TT(1)


                    Dim F1 As String
                    Dim F2 As Date

                    F1 = Me.Ar_Fromtime(Index).Text

                    F2 = Now.Date & " " & F1 & ":00"

                    F2 = DateAdd(DateInterval.Hour, GLBAnalysisHours, F2)

                    Me.Ar_Totime(Index).Text = F2.Hour.ToString.PadLeft(2, "0") & ":" & F2.Minute.ToString.PadLeft(2, "0")
                End If
                Me.CalculateTotalTime(Index)
            End If
            End If

    End Sub
    Private Sub ComboBoxAnal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
    Private Sub CalculateTotalTime(ByVal Index As Integer)
        Dim F1 As String
        Dim T1 As String
        Dim F2 As String
        Dim T2 As String
        Dim NewT As String
        Dim Dif As Double
        Dim Hours As String
        Dim Minutes As String
        Dim Ar() As String

        F1 = Me.Ar_Fromtime(Index).Text
        T1 = Me.Ar_Totime(Index).Text

        F2 = Now.Date & " " & F1 & ":00"
        T2 = Now.Date & " " & T1 & ":00"
        If T2 < F2 Then
            NewT = DateAdd(DateInterval.Day, 1, Now.Date)
            T2 = NewT & " " & T1 & ":00"
        End If

       
        Dim GLBAnalysisBreak As Integer
        Dim GLBAnalysisHour As Integer
        Dim TT() As String
        Dim S As String
        S = CType(Ar_ComboAnal(Index).SelectedItem, cPrAnEmployeeAnalysis5).GLAnal2
        TT = S.Split("|")
        GLBAnalysisHour = TT(0)
        GLBAnalysisBreak = TT(1)


        Dif = DateDiff(DateInterval.Minute, CDate(F2), CDate(T2))
        'Dif = CalculateAllNormalTime()


        If GLBAnalysisHour * 60 <= Dif Then
            If GLBAnalysisBreak = "1" Then
                Dif = Dif - 30
            End If
            If GLBAnalysisBreak = "2" Then
                Dif = Dif - 60
            End If
        End If



        Minutes = Dif Mod 60
        Ar = (Dif / 60).ToString.Split(".")
        Hours = Ar(0)



        Me.Ar_TotalTime(Index).Text = Math.Abs(CInt(Hours)) & "." & Format(Math.Abs(CInt(Minutes)), "00")

        CalculateLine2Cost(Index)


    End Sub
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        TryToSave()
        Me.Close()
    End Sub
    Private Sub SaveWeekDescription()

        CType(Me.Owner, FrmTATrxnLines).SaveWeekDescription()

    End Sub

    Private Function TryToSave() As Boolean
        SaveWeekDescription()
        Dim i As Integer

        Dim Exx As New Exception
        If MyMode = TaStatus.ACTUAL Then
            If ValidateMe() Then
                If Me.CheckIfExistsOnTrxnLines(Me.GlbEmpCode, Mydate) Then
                    Global1.Business.BeginTransaction()
                    Try
                        For i = 0 To Me.Ar_combo.Length - 1
                            If Ar_combo(i).Text <> "" Then
                                If Not Me.TrxnLines2(i) Is Nothing Then
                                    If Me.TrxnLines2(i).Status = "INTE" Then
                                        Global1.Business.Rollback()
                                        MsgBox("This Time Attendance Record has already being Sent to Payroll, Cannot make any changes", MsgBoxStyle.Critical)
                                        Saved = False
                                        Exit Function
                                    End If
                                    With Me.TrxnLines2(i)
                                        .Mydate = Mydate 'Now.Date
                                        .EmployeeCode = Me.GlbEmpCode
                                        .Day = MyDay
                                        .FromTime = Me.Ar_Fromtime(i).Text
                                        .ToTime = Me.Ar_Totime(i).Text
                                        .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                        .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                        .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                        .UserId_Create = Global1.GLBUserId
                                        .UserId_LastUpdate = Global1.GLBUserId
                                        .Created = Now.Date
                                        .LastUpdate = Now.Date
                                        .Status = "POST"
                                        .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                        .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL

                                        If Not .Save Then
                                            Throw Exx
                                        End If
                                    End With
                                Else
                                    Dim TrxLine2 As New cTaTxTrxnLines2
                                    With TrxLine2
                                        .Id = 0
                                        .Mydate = Mydate 'Now.Date
                                        .EmployeeCode = Me.GlbEmpCode
                                        .Day = MyDay
                                        .FromTime = Me.Ar_Fromtime(i).Text
                                        .ToTime = Me.Ar_Totime(i).Text
                                        .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                        .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                        .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                        .UserId_Create = Global1.GLBUserId
                                        .UserId_LastUpdate = Global1.GLBUserId
                                        .Created = Now.Date
                                        .LastUpdate = Now.Date
                                        .Status = "POST"
                                        .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                        .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL


                                        If Not .Save Then
                                            Throw Exx
                                        End If
                                        Me.TrxnLines2(i) = TrxLine2
                                    End With
                                End If
                            Else
                                If Not Me.TrxnLines2(i) Is Nothing Then
                                    If Not Me.TrxnLines2(i).Delete() Then
                                        Throw Exx
                                    End If
                                    Me.TrxnLines2(i) = Nothing
                                End If
                            End If
                        Next
                        Global1.Business.CommitTransaction()
                        ' MsgBox("Changes Are Saved", MsgBoxStyle.Information)
                        Saved = True
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        Global1.Business.Rollback()
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End Try
                End If
            End If
        Else
            If ValidateMe() Then
                If Me.CheckIfExistsOnTrxnLines2(Me.GlbEmpCode, Mydate) Then
                    Global1.Business.BeginTransaction()
                    Try
                        For i = 0 To Me.Ar_combo.Length - 1
                            If Ar_combo(i).Text <> "" Then
                                If Not Me.TrxnLines(i) Is Nothing Then
                                    With Me.TrxnLines(i)
                                        .Mydate = Mydate 'Now.Date
                                        .EmployeeCode = Me.GlbEmpCode
                                        .Day = MyDay
                                        .FromTime = Me.Ar_Fromtime(i).Text
                                        .ToTime = Me.Ar_Totime(i).Text
                                        .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                        .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                        .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                        .UserId_Create = Global1.GLBUserId
                                        .UserId_LastUpdate = Global1.GLBUserId
                                        .Created = Now.Date
                                        .LastUpdate = Now.Date
                                        .Status = "OUTS"
                                        .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                        .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL

                                        If Not .Save Then
                                            Throw Exx
                                        End If
                                    End With
                                Else
                                    Dim TrxLine As New cTaTxTrxnLines
                                    With TrxLine
                                        .Id = 0
                                        .Mydate = Mydate 'Now.Date
                                        .EmployeeCode = Me.GlbEmpCode
                                        .Day = MyDay
                                        .FromTime = Me.Ar_Fromtime(i).Text
                                        .ToTime = Me.Ar_Totime(i).Text
                                        .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                        .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                        .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                        .UserId_Create = Global1.GLBUserId
                                        .UserId_LastUpdate = Global1.GLBUserId
                                        .Created = Now.Date
                                        .LastUpdate = Now.Date
                                        .Status = "OUTS"
                                        .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                        .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL

                                        If Not .Save Then
                                            Throw Exx
                                        End If
                                        Me.TrxnLines(i) = TrxLine
                                    End With
                                End If
                            Else
                                If Not Me.TrxnLines(i) Is Nothing Then
                                    If Not Me.TrxnLines(i).Delete() Then
                                        Throw Exx
                                    End If
                                    Me.TrxnLines(i) = Nothing
                                End If
                            End If
                        Next
                        Global1.Business.CommitTransaction()
                        ' MsgBox("Changes Are Saved", MsgBoxStyle.Information)
                        Saved = True
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        Global1.Business.Rollback()
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End Try
                End If
            End If
        End If
        Return Saved
    End Function
    Private Function CheckIfExistsOnTrxnLines(ByVal EmpCode As String, ByVal MyDate As Date) As Boolean
        Dim Flag As Boolean = True
        Flag = Global1.Business.CheckIfExistsOnTrxnLines(EmpCode, MyDate)
        If Not Flag Then
            MsgBox("There is an Outsdanding Entry in Schedule for this employee for this day, Please Post and then Continue", MsgBoxStyle.Critical)
        End If
        Return Flag
    End Function
    Private Function CheckIfExistsOnTrxnLines2(ByVal EmpCode As String, ByVal MyDate As Date) As Boolean
        Dim Flag As Boolean = True
        Flag = Global1.Business.CheckIfExistsOnTrxnLines2(EmpCode, MyDate)
        If Not Flag Then
            MsgBox("There is an Entry in Actual for this employee for this day, Cannot Save Entry", MsgBoxStyle.Critical)
        End If
        Return Flag
    End Function


    Private Function TryToSaveACTUAL() As Boolean
        Dim i As Integer
        Dim Saved As Boolean = False
        Dim Exx As New Exception
        If ValidateMe() Then
            Global1.Business.BeginTransaction()
            Try
                For i = 0 To Me.Ar_combo.Length - 1
                    If Ar_combo(i).Text <> "" Then
                        If Not Me.TrxnLines(i) Is Nothing Then
                            With Me.TrxnLines(i)
                                .Mydate = Mydate 'Now.Date
                                .EmployeeCode = Me.GlbEmpCode
                                .Day = MyDay
                                .FromTime = Me.Ar_Fromtime(i).Text
                                .ToTime = Me.Ar_Totime(i).Text
                                .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                .UserId_Create = Global1.GLBUserId
                                .UserId_LastUpdate = Global1.GLBUserId
                                .Created = Now.Date
                                .LastUpdate = Now.Date
                                .Status = "OUTS"
                                .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL
                                If Not .Save Then
                                    Throw Exx
                                End If
                            End With
                        Else
                            Dim TrxLine As New cTaTxTrxnLines
                            With TrxLine
                                .Id = 0
                                .Mydate = Mydate 'Now.Date
                                .EmployeeCode = Me.GlbEmpCode
                                .Day = MyDay
                                .FromTime = Me.Ar_Fromtime(i).Text
                                .ToTime = Me.Ar_Totime(i).Text
                                .TotalTime = CDbl(Me.Ar_TotalTime(i).Text)
                                .WorkGroupCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).GroupCode
                                .WorkCode = CType(Ar_combo(i).SelectedItem, cTaMsWorkCodes).Code
                                .UserId_Create = Global1.GLBUserId
                                .UserId_LastUpdate = Global1.GLBUserId
                                .Created = Now.Date
                                .LastUpdate = Now.Date
                                .Status = "OUTS"
                                .AnalCode = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
                                .AnalDesc = CType(Ar_ComboAnal(i).SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_DescriptionL
                                If Not .Save Then
                                    Throw Exx
                                End If
                                Me.TrxnLines(i) = TrxLine
                            End With
                        End If
                    Else
                        If Not Me.TrxnLines(i) Is Nothing Then
                            If Not Me.TrxnLines(i).Delete() Then
                                Throw Exx
                            End If
                            Me.TrxnLines(i) = Nothing
                        End If
                    End If
                Next
                Global1.Business.CommitTransaction()
                MsgBox("Changes Are Saved", MsgBoxStyle.Information)
                Saved = True
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        End If
        Return Saved
    End Function
    Private Function ValidateMe() As Boolean
        Dim i As Integer
        Dim Flag As Boolean = True
        ClearErrors()
        For i = 0 To Me.Ar_combo.Length - 1
            If Ar_combo(i).Text <> "" Then
                If Me.Ar_Fromtime(i).MaskCompleted Then
                    If Not IsFromTimeDate(i) Then
                        Me.Ar_Error1(i).SetError(Ar_Fromtime(i), "Please Enter Valid Time")
                        Flag = False
                    End If
                Else
                    Me.Ar_Error1(i).SetError(Ar_Fromtime(i), "Please Enter Valid Time")
                    Flag = False
                End If
                If Me.Ar_Totime(i).MaskCompleted Then
                    If Not IsToTimeDate(i) Then
                        Me.Ar_Error2(i).SetError(Ar_Totime(i), "Please Enter Valid Time")
                        Flag = False
                    End If
                Else
                    Me.Ar_Error2(i).SetError(Ar_Totime(i), "Please Enter Valid Time")
                    Flag = False
                End If
            End If
        Next
        Return Flag
    End Function
    Private Sub ClearErrors()
        Dim i As Integer
        For i = 0 To Me.Ar_Error1.Length - 1
            Me.Ar_Error1(i).SetError(Me.Ar_Fromtime(i), "")
            Me.Ar_Error2(i).SetError(Me.Ar_Totime(i), "")
        Next
    End Sub
    Private Function IsFromTimeDate(ByVal i As Integer) As Boolean
        Dim Flag As Boolean = False
        Dim D As String
        Dim MyDate As String
        D = Now.Date & " " & Me.Ar_Fromtime(i).Text & ":00"
        Try
            MyDate = CDate(D)
            Flag = True
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function IsToTimeDate(ByVal i As Integer) As Boolean
        Dim Flag As Boolean = False
        Dim D As String
        Dim MyDate As String
        D = Now.Date & " " & Me.Ar_Totime(i).Text & ":00"
        Try
            MyDate = CDate(D)
            Flag = True
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function ConvertToTime(ByVal D As Double) As String
        Dim M As Double
        Dim Ar() As String
        Dim H As Double
        Dim Time As String
        M = D Mod 60
        Ar = (D / 60).ToString.Split(".")
        H = Ar(0)

        Time = Math.Abs(H) & "." & Format(Math.Abs(M), "00")

        Return CDbl(Time)
    End Function

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub

        Dim Type As String
        Dim Index As Integer = 0
        If CType(sender, ComboBox).SelectedIndex > 0 Then

            Type = CType(CType(sender, ComboBox).SelectedItem, cTaMsWorkCodes).Mytype
            Index = CInt(CType(sender, ComboBox).Tag.ToString)


            Select Case Type
                Case Type_Normal
                    CalculateTotalTime(Index)
                    EnableObjects(True, Index)
                Case Type_Overtime
                    CalculateTotalTime(Index)
                    EnableObjects(True, Index)
                Case Type_Leave
                    CalculateTotalTime(Index)
                    EnableObjects(True, Index)
                Case Type_Split
                    Me.Ar_TotalTime(Index).Text = "1"
                    Me.Ar_TotalTime(Index).Enabled = False
                    CalculateSplitRate(Index)
                    EnableObjects(False, Index)
                Case Type_Earning
                    Me.Ar_TotalTime(Index).Enabled = True
                    EnableObjects(False, Index)
                Case Type_Deduction
                    Me.Ar_TotalTime(Index).Enabled = True
                    EnableObjects(False, Index)
                Case Type_IN
                    Me.Ar_TotalTime(Index).Text = "8.00"
                    Me.Ar_TotalTime(Index).Enabled = True
                    EnableObjects(False, Index)

            End Select
        Else
            Index = CInt(CType(sender, ComboBox).Tag.ToString)
            Me.Ar_Fromtime(Index).Text = "00.00"
            Me.Ar_Totime(Index).Text = "00.00"
            Me.Ar_TotalTime(Index).Text = "0.00"
            Me.Ar_Fromtime(Index).Enabled = True
            Me.Ar_Totime(Index).Enabled = True
            Me.Ar_TotalTime(Index).Enabled = True
        End If
        CalculateTotalCost()
    End Sub
    Private Sub ComboAnal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If DoNotEnter Then Exit Sub

        'Dim Type As String
        'Dim Index As Integer = 0
        'If CType(sender, ComboBox).SelectedIndex > 0 Then

        '    Type = CType(CType(sender, ComboBox).SelectedItem, cTaMsWorkCodes).Mytype
        '    Index = CInt(CType(sender, ComboBox).Tag.ToString)


        '    Select Case Type
        '        Case Type_Normal
        '            CalculateTotalTime(Index)
        '            EnableObjects(True, Index)
        '        Case Type_Overtime
        '            CalculateTotalTime(Index)
        '            EnableObjects(True, Index)
        '        Case Type_Leave
        '            CalculateTotalTime(Index)
        '            EnableObjects(True, Index)
        '        Case Type_Split
        '            Me.Ar_TotalTime(Index).Text = "1"
        '            Me.Ar_TotalTime(Index).Enabled = False
        '            EnableObjects(False, Index)
        '        Case Type_Earning
        '            Me.Ar_TotalTime(Index).Enabled = True
        '            EnableObjects(False, Index)
        '        Case Type_Deduction
        '            Me.Ar_TotalTime(Index).Enabled = True
        '            EnableObjects(False, Index)
        '        Case Type_IN
        '            Me.Ar_TotalTime(Index).Text = "8.00"
        '            Me.Ar_TotalTime(Index).Enabled = True
        '            EnableObjects(False, Index)
        '    End Select
        'End If
    End Sub
    Private Sub EnableObjects(ByVal TF As Boolean, ByVal Index As Integer)
        If TF = False Then
            DoNotEnter = True
            Me.Ar_Fromtime(Index).Text = "00:00"
            Me.Ar_Totime(Index).Text = "00:00"
            DoNotEnter = False
        End If
        Me.Ar_Fromtime(Index).Enabled = TF
        Me.Ar_Totime(Index).Enabled = TF
        If TF = True Then
            Me.Ar_TotalTime(Index).Enabled = TF
        End If

    End Sub
    Private Function CalculateTotalForTime() As String

        Dim Error1 As String = 1
        Try


            Dim i As Integer
            Dim H As Double = 0
            Dim M As Double = 0
            Dim Ar() As String
            Dim D As String

            Dim Code As String
            Dim GroupCode As String
            Dim Work As New cTaMsWorkCodes

            If MyMode = TaStatus.ACTUAL Then
                For i = 0 To Me.TrxnLines2.Length - 1
                    If Not TrxnLines2(i) Is Nothing Then
                        With TrxnLines2(i)
                            Code = TrxnLines2(i).WorkCode
                            GroupCode = TrxnLines2(i).WorkGroupCode
                            Work = New cTaMsWorkCodes(Code, GroupCode)
                            If Work.Mytype <> Me.Type_Earning And Work.Mytype <> Me.Type_Deduction And Work.Mytype <> Me.Type_Split Then
                                Error1 = 2
                                D = Format(.TotalTime, "0.00")
                                Error1 = 3
                                Ar = D.Split(".")
                                Error1 = 4
                                H = H + Ar(0).ToString
                                Error1 = 5
                                M = M + Ar(1).ToString
                                Error1 = 6
                            End If
                        End With
                    End If
                Next
            Else
                For i = 0 To Me.TrxnLines.Length - 1
                    If Not TrxnLines(i) Is Nothing Then
                        With TrxnLines(i)
                            Code = TrxnLines(i).WorkCode
                            GroupCode = TrxnLines(i).WorkGroupCode
                            Work = New cTaMsWorkCodes(Code, GroupCode)
                            If Work.Mytype <> Me.Type_Earning And Work.Mytype <> Me.Type_Deduction And Work.Mytype <> Me.Type_Split Then
                                Error1 = 7
                                D = Format(.TotalTime, "0.00")
                                Error1 = 8
                                Ar = D.Split(".")
                                Error1 = 9
                                H = H + Ar(0).ToString
                                Error1 = 10
                                M = M + Ar(1).ToString
                                Error1 = 11
                            End If
                        End With
                    End If
                Next

            End If
            H = H * 60
            'If M <> 0 Then
            '    M = M / 10
            'End If
            M = M + H
            Return ConvertToTime(M)
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Error 3:" & Error1)
        End Try
    End Function




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Function CalculateAllNormalTimexx() As Integer
        Dim index As Integer
        Dim F1 As String
        Dim T1 As String
        Dim F2 As String
        Dim T2 As String
        Dim NewT As String
        Dim Dif As Double
        Dim Hours As String
        Dim Minutes As String
        Dim Ar() As String
        Dim S As String

        For index = 0 To Ar_combo.Length - 1
            If Me.Ar_combo(index).SelectedIndex <> 0 Then
                If CType(Me.Ar_combo(index).SelectedItem, cTaMsWorkCodes).Mytype = Type_Normal Then

                    F1 = Me.Ar_Fromtime(index).Text
                    T1 = Me.Ar_Totime(index).Text

                    F2 = Now.Date & " " & F1 & ":00"
                    T2 = Now.Date & " " & T1 & ":00"
                    If T2 < F2 Then
                        NewT = DateAdd(DateInterval.Day, 1, Now.Date)
                        T2 = NewT & " " & T1 & ":00"
                    End If




                    Dif = Dif + DateDiff(DateInterval.Minute, CDate(F2), CDate(T2))


                    S = CType(Ar_ComboAnal(index).SelectedItem, cPrAnEmployeeAnalysis5).GLAnal2


                End If
            End If
        Next

        Dim GLBAnalysisBreak As Integer
        Dim GLBAnalysisHour As Integer
        Dim TT() As String

        TT = S.Split("|")
        GLBAnalysisHour = TT(0)
        GLBAnalysisBreak = TT(1)

        '----changeHere
        'If GLBAnalysisHour * 60 <= Dif Then
        '    If GLBAnalysisBreak = "1" Then
        '        Dif = Dif - 30
        '    End If
        '    If GLBAnalysisBreak = "2" Then
        '        Dif = Dif - 60
        '    End If
        'End If
        '----changeHere



        'Minutes = Dif Mod 60
        'Ar = (Dif / 60).ToString.Split(".")
        'Hours = Ar(0)

        Dim TotalNormalTimeInMinutes As Integer

        'Me.Ar_TotalTime(index).Text = Math.Abs(CInt(Hours)) & "." & Format(Math.Abs(CInt(Minutes)), "00")

        TotalNormalTimeInMinutes = Dif
        Return TotalNormalTimeInMinutes
    End Function

End Class