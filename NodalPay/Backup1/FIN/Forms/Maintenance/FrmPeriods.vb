Public Class FrmPeriods
    'testing VSS2005
    Dim Ar_Txt() As TextBox
    Dim Ar_StartDate() As MaskedTextBox
    Dim Ar_EndDate() As MaskedTextBox
    Dim Ar_ComboStatus() As ComboBox
    Dim Ar_TxtNoOfDays() As TextBox

    'Combo Definitions
    Dim DoNotEnter As Boolean = False
    Dim UpdateFlag As Boolean = False
    Dim CloseStatus As String = "C"
    Dim Openstatus As String = "O"
    Dim CloseValue As String = CloseStatus & " - Close"
    Dim OpenValue As String = Openstatus & " - Open"


    Private Sub FrmPeriods_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CreateControls()
        AddHandlersToControls()
        LoadComboYear()
        Me.FiscalYearFROM.Focus()
    End Sub
    Private Sub AddHandlersToControls()
        AddHandlersTo_EndDate()
        AddHandlersTo_ComboStatus()

    End Sub
    Private Sub AddHandlersTo_EndDate()
        Dim i As Integer
        For i = 0 To Ar_EndDate.Length - 1
            AddHandler CType(Ar_EndDate(i), MaskedTextBox).TextChanged, AddressOf EndDate_TextChanged
            AddHandler CType(Ar_EndDate(i), MaskedTextBox).KeyUp, AddressOf EndDate_KeyUp
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

    Private Sub CreateControls()
        Dim N As Integer
        N = Global1.NumberOfFiscalPeriods
        Dim Dif1 As Integer = 20
        Dim Dif2 As Integer = 20
        Dim X As Integer = 5
        Dim X2 As Integer = 5
        ReDim Ar_Txt(N)
        ReDim Ar_StartDate(N)
        ReDim Ar_EndDate(N)
        ReDim Ar_ComboStatus(N)
        ReDim Ar_TxtNoOfDays(N)

        'TextBox
        Dim TextTop As Integer
        Dim TextLeft As Integer = Me.txtP1.Left
        Me.txtP1.Top = Me.txtP1.Top - Dif1
        Dim i As Integer
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtP1.Size
            TextTop = Me.txtP1.Top + ((txtP1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft, TextTop)
            S.Name = "P_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Ar_Txt(i) = S
            S.ReadOnly = True
            S.BackColor = SystemColors.Info
        Next

        'Text Box 2
        Dim TextTop2 As Integer
        Dim TextLeft2 As Integer = Me.txtNOfDays.Left
        Me.txtNOfDays.Top = Me.txtNOfDays.Top - Dif1
        For i = 0 To N
            Dim S As New TextBox
            S.Size = txtNOfDays.Size
            TextTop2 = Me.txtNOfDays.Top + ((txtNOfDays.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(TextLeft2, TextTop2)
            S.Name = "NOfDats_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Me.Ar_TxtNoOfDays(i) = S
        Next

        'ComboBox

        Dim ComboTop As Integer
        Dim ComboLeft As Integer = Me.ComboStatus1.Left
        Me.ComboStatus1.Top = Me.ComboStatus1.Top - Dif2
        For i = 0 To N
            Dim S As New ComboBox
            S.Size = ComboStatus1.Size
            S.FormattingEnabled = True
            S.DropDownStyle = ComboBoxStyle.DropDownList
            ComboTop = Me.ComboStatus1.Top + ((txtP1.Height + X) * i) + Dif2
            S.Location = New System.Drawing.Point(ComboLeft, ComboTop)
            S.Name = "ComboStatus_" & i + 1
            S.Visible = True
            Me.Controls.Add(S)
            Ar_ComboStatus(i) = S
            S.Tag = i
        Next
        'Combo Box 2

        'ComboBox

        'Dim ComboTop2 As Integer
        'Dim ComboLeft2 As Integer = Me.ComboStatus2.Left
        'Me.ComboStatus2.Top = Me.ComboStatus2.Top - Dif2
        'For i = 0 To N
        '    Dim S As New ComboBox
        '    S.Size = ComboStatus2.Size
        '    S.FormattingEnabled = True
        '    S.DropDownStyle = ComboBoxStyle.DropDownList
        '    ComboTop2 = Me.ComboStatus2.Top + ((txtP1.Height + X) * i) + Dif2
        '    S.Location = New System.Drawing.Point(ComboLeft2, ComboTop2)
        '    S.Name = "ComboStatus2_" & i + 1
        '    S.Visible = True
        '    Me.Controls.Add(S)
        '    Ar_ComboStatus2(i) = S
        '    S.Tag = i
        'Next

        'MaskedTextBox1
        Dim MaskTop1 As Integer
        Dim MaskLeft1 As Integer = Me.StartDate1.Left
        Me.StartDate1.Top = Me.StartDate1.Top - Dif1
        For i = 0 To N

            Dim S As New MaskedTextBox
            S.Size = StartDate1.Size
            MaskTop1 = Me.StartDate1.Top + ((StartDate1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(MaskLeft1, MaskTop1)
            S.Visible = True
            S.Mask = "00/00/0000"
            S.Name = "StartDate_" & i + 1
            S.ValidatingType = GetType(Date)
            Me.Controls.Add(S)
            Ar_StartDate(i) = S
            S.Tag = i
            If i <> N Then
                S.ReadOnly = True
                S.BackColor = SystemColors.Info
            End If
        Next
        'MaskedTextBox2
        Dim MaskTop2 As Integer
        Dim MaskLeft2 As Integer = Me.EndDate1.Left
        Me.EndDate1.Top = Me.EndDate1.Top - Dif1
        For i = 0 To N
            Dim S As New MaskedTextBox
            S.Size = EndDate1.Size
            MaskTop2 = Me.EndDate1.Top + ((EndDate1.Height + X) * i) + Dif1
            S.Location = New System.Drawing.Point(MaskLeft2, MaskTop2)
            S.Visible = True
            S.Mask = "00/00/0000"
            S.Name = "EndDate_" & i + 1
            S.ValidatingType = GetType(Date)
            Me.Controls.Add(S)
            Ar_EndDate(i) = S
            S.Tag = i
            If i = N Then
                S.ReadOnly = True
                S.BackColor = SystemColors.Info
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
        'For i = 0 To Me.Ar_ComboStatus2.Length - 1
        '    With CType(Me.Ar_ComboStatus2(i), ComboBox)
        '        .BeginUpdate()
        '        .Items.Add("O - Open")
        '        .Items.Add("C - Close")
        '        .SelectedIndex = 0
        '        .EndUpdate()
        '    End With
        'Next


        Me.ComboYears.TabIndex = 0
        Me.FiscalYearFROM.TabIndex = 1
        Me.FiscalYearTo.TabIndex = 2

        'CType(Ar_Txt(0), TextBox).TabIndex = 4
        'For i = 1 To Ar_Txt.Length - 1
        '    CType(Ar_Txt(i), TextBox).TabIndex = CType(Ar_Txt(i - 1), TextBox).TabIndex + 4
        'Next
        'CType(Ar_StartDate(0), MaskedTextBox).TabIndex = 5
        'For i = 1 To Ar_StartDate.Length - 1
        '    CType(Ar_StartDate(i), MaskedTextBox).TabIndex = CType(Ar_StartDate(i - 1), MaskedTextBox).TabIndex + 4
        'Next
        'CType(Ar_EndDate(0), MaskedTextBox).TabIndex = 6
        'For i = 1 To Ar_EndDate.Length - 1
        '    CType(Ar_EndDate(i), MaskedTextBox).TabIndex = CType(Ar_EndDate(i - 1), MaskedTextBox).TabIndex + 4
        'Next
        'CType(Ar_ComboStatus(0), ComboBox).TabIndex = 7
        'For i = 1 To Ar_ComboStatus.Length - 1
        '    CType(Ar_ComboStatus(i), ComboBox).TabIndex = CType(Ar_ComboStatus(i - 1), ComboBox).TabIndex + 4
        'Next
        'Me.ComboYears.TabIndex = 0
        'Me.FiscalYearFROM.TabIndex = 1
        'Me.FiscalYearTo.TabIndex = 2

        Me.FiscalYearFROM.Focus()


    End Sub

#End Region

    Private Sub BtnCreatePeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePeriods.Click
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
            If i = Ar_Txt.Length - 1 Then
                S = ComboYears.Text.ToString & "99"
            Else
                S = ComboYears.Text.ToString & (i + 1).ToString.PadLeft(2, "0")
            End If
            CType(Ar_Txt(i), TextBox).Text = S
        Next

        For i = 0 To Ar_StartDate.Length - 1
            If i = 0 Then
                S = FiscalYearFROM.Text
            ElseIf i = Ar_StartDate.Length - 1 Then
                S = FiscalYearFROM.Text
            Else
                S = ""
            End If
            CType(Ar_StartDate(i), MaskedTextBox).Text = S
        Next

        For i = 0 To Ar_EndDate.Length - 1
            DoNotEnter = True
            If i = Ar_EndDate.Length - 2 Then
                S = FiscalYearTo.Text
                CType(Ar_EndDate(i), MaskedTextBox).BackColor = SystemColors.Info
                CType(Ar_EndDate(i), MaskedTextBox).ReadOnly = True
            ElseIf i = Ar_EndDate.Length - 1 Then
                S = FiscalYearTo.Text
                CType(Ar_EndDate(i), MaskedTextBox).BackColor = SystemColors.Info
                CType(Ar_EndDate(i), MaskedTextBox).ReadOnly = True
            Else
                CType(Ar_EndDate(i), MaskedTextBox).BackColor = SystemColors.Window
                CType(Ar_EndDate(i), MaskedTextBox).ReadOnly = False
                S = ""
            End If
            CType(Ar_EndDate(i), MaskedTextBox).Text = S
            DoNotEnter = False
        Next
        For i = 0 To Ar_ComboStatus.Length - 1
            CType(Ar_ComboStatus(i), ComboBox).SelectedIndex = 0
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
                If Global1.NumberOfFiscalPeriods = 12 Then
                    D = Utils.ChangeMaskedFields(Me.FiscalYearFROM)
                    For i = 0 To 11
                        D = DateAdd(DateInterval.Month, 1, D)
                        If i <> 11 Then
                            Me.Ar_StartDate(i + 1).Text = Format(D, "dd/MM/yyyy")
                        End If
                        D = DateAdd(DateInterval.Day, -1, D)
                        Me.Ar_EndDate(i).Text = Format(D, "dd/MM/yyyy")
                        D = DateAdd(DateInterval.Day, +1, D)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ComboYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboYears.SelectedIndexChanged

        Dim Year As String
        Dim ds As DataSet
        Year = Me.ComboYears.Text
        ds = Global1.Business.GetFiscalPeriodsOfYear(Year, False, False)
        If CheckDataSet(ds) Then
            LoadPeriods(ds)
            UpdateFlag = True
        Else
            ClearPeriodsFields()
            UpdateFlag = False
        End If
    End Sub
    Private Sub LoadPeriods(ByVal Ds As DataSet)
        DoNotEnter = True
        ClearPeriodsFields()

        Dim i As Integer
        Dim Pr As New cFiscalPeriods

        For i = 0 To Ds.Tables(0).Rows.Count - 1
            Pr = New cFiscalPeriods(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
            With Pr
                Me.Ar_Txt(i).Text = .Code
                Me.Ar_StartDate(i).Text = Format(.FromDate, "dd/MM/yyyy")
                Me.Ar_EndDate(i).Text = Format(.ToDate, "dd/MM/yyyy")
                Me.Ar_TxtNoOfDays(i).Text = .NoOfDays
                If i <> Ds.Tables(0).Rows.Count - 1 Then
                    'NORMAL STATUS
                    If .StatusMain = CloseStatus Then
                        Me.Ar_ComboStatus(i).SelectedIndex = Me.Ar_ComboStatus(i).FindString(CloseValue)
                    ElseIf .StatusMain = Openstatus Then
                        Me.Ar_ComboStatus(i).SelectedIndex = Me.Ar_ComboStatus(i).FindString(OpenValue)
                    End If
                Else
                    'FININTIAL STATUS
                    If .StatusFin = CloseStatus Then
                        Me.Ar_ComboStatus(i).SelectedIndex = Me.Ar_ComboStatus(i).FindString(CloseValue)
                    ElseIf .StatusFin = Openstatus Then
                        Me.Ar_ComboStatus(i).SelectedIndex = Me.Ar_ComboStatus(i).FindString(OpenValue)
                    End If
                End If
                If i = 0 Then
                    Me.FiscalYearFROM.Text = Format(.FromDate, "dd/MM/yyyy")
                End If
                If i = Ds.Tables(0).Rows.Count - 1 Then
                    Me.FiscalYearTo.Text = Format(.ToDate, "dd/MM/yyyy")
                End If

            End With
            Me.Ar_Txt(i).ReadOnly = True
            Me.Ar_Txt(i).BackColor = SystemColors.Info
            Me.Ar_StartDate(i).ReadOnly = True
            Me.Ar_StartDate(i).BackColor = SystemColors.Info
            Me.Ar_EndDate(i).ReadOnly = True
            Me.Ar_EndDate(i).BackColor = SystemColors.Info
            Me.Ar_TxtNoOfDays(i).ReadOnly = True
            Me.Ar_TxtNoOfDays(i).BackColor = SystemColors.Info
        Next
        DoNotEnter = False
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
                    PrevDate = Utils.ChangeMaskedFields(CType(Me.Ar_StartDate(index), MaskedTextBox))
                    CurrentDate = Utils.ChangeMaskedFields(CType(sender, MaskedTextBox))
                    If CurrentDate > PrevDate Then
                        CalcDate = DateAdd(DateInterval.Day, 1, CurrentDate)
                        If index <> Global1.NumberOfFiscalPeriods - 1 Then
                            CType(Me.Ar_StartDate(index + 1), MaskedTextBox).Text = Format(CalcDate, "dd/MM/yyyy")
                            ClearDatesFrom(index + 1)
                        End If
                        Me.Ar_TxtNoOfDays(index).Text = DateDiff(DateInterval.Day, PrevDate, CurrentDate) + 1
                    Else
                        MsgBox("End Date of Period " & CType(Me.Ar_Txt(index), TextBox).Text & " Must be Greater Than Start Date!", MsgBoxStyle.Critical)
                    End If
                Catch ex As Exception
                    MsgBox("Please Fill End Date of Period " & CType(Me.Ar_Txt(index), TextBox).Text & " with a Valid Date!", MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("Please Fill End Date for Period " & CType(Me.Ar_Txt(index - 1), TextBox).Text & " First!", MsgBoxStyle.Critical)
            End If
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

    Private Sub btnSavePeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePeriods.Click
        TryToSave()
    End Sub
    Private Sub TryToSave()
        If ValidatePeriods() Then
            Dim i As Integer
            Dim Per As New cFiscalPeriods
            Dim Exx As New Exception
            Dim S As String
            Dim Status As String
            Dim Ar() As String
            Try

                Global1.Business.BeginTransaction()
                For i = 0 To Global1.NumberOfFiscalPeriods
                    With Per
                        .Code = Me.Ar_Txt(i).Text
                        .Year = Me.ComboYears.Text
                        .Number = i + 1
                        S = Me.Ar_TxtNoOfDays(i).Text
                        If Not IsNumeric(S) Then
                            Me.Ar_TxtNoOfDays(i).Text = 0
                            S = 0
                        End If
                        .NoOfDays = CInt(S)
                        .FromDate = Utils.ChangeMaskedFields(CType(Me.Ar_StartDate(i), MaskedTextBox))
                        .ToDate = Utils.ChangeMaskedFields(CType(Me.Ar_EndDate(i), MaskedTextBox))
                        .DescriptionL = Me.Ar_Txt(i).Text
                        .DescriptionS = Me.Ar_Txt(i).Text
                        Ar = Me.Ar_ComboStatus(i).Text.Split("-")
                        Status = Trim(Ar(0))
                        If i = Global1.NumberOfFiscalPeriods Then
                            .MyType = "F"
                            .StatusFin = Status
                            .StatusMain = CloseStatus
                        Else
                            .MyType = "N"
                            .StatusFin = CloseStatus
                            .StatusMain = Status
                        End If

                        If Not .Save(UpdateFlag) Then
                            Throw Exx
                        End If
                    End With
                Next
                Global1.Business.CommitTransaction()
                MsgBox("Periods are Succesfully Saved", MsgBoxStyle.Information)
            Catch ex As Exception
                Global1.Business.Rollback()
                MsgBox("Unable to Save Periods", MsgBoxStyle.Critical)
                Utils.ShowException(ex)
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
End Class