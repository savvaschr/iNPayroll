
Public Class E_Control
    Public MyIndex As Integer
    Public DS_E As DataSet
    Dim NotNow As Boolean = True
    Dim MyTempCode As String = ""
    Public Sub LoadME()
        LoadComboEarnings()
        LoadComboMode()
        LoadComboFrom()
        LoadIndex()
        AddHandler txtSeq.KeyPress, AddressOf IntegerKeyPress
        AddHandler txtSeq.Leave, AddressOf IntegerOnLeave
    End Sub
    Private Sub LoadIndex()
        Select Case MyIndex
            Case 0
                Me.txtLabel.Text = "1"
            Case 1
                Me.txtLabel.Text = "2"
            Case 2
                Me.txtLabel.Text = "3"
            Case 3
                Me.txtLabel.Text = "4"
            Case 4
                Me.txtLabel.Text = "5"
            Case 5
                Me.txtLabel.Text = "6"
            Case 6
                Me.txtLabel.Text = "7"
            Case 7
                Me.txtLabel.Text = "8"
            Case 8
                Me.txtLabel.Text = "9"
            Case 9
                Me.txtLabel.Text = "A"
            Case 10
                Me.txtLabel.Text = "B"
            Case 11
                Me.txtLabel.Text = "C"
            Case 12
                Me.txtLabel.Text = "D"
            Case 13
                Me.txtLabel.Text = "E"
            Case 14
                Me.txtLabel.Text = "F"
        End Select
    End Sub
    Public Sub ClearME()
        Me.Combo1.SelectedIndex = 0
        Me.txtDisplay.Text = ""
        Me.ComboFrom.SelectedIndex = 0
        Me.ComboMode.SelectedIndex = 0
        Me.CBIsDisplayed.Checked = False
        Me.txtNavCreditAccount.Text = ""
        Me.txtNavDebitAccount.Text = ""
    End Sub
    Public Sub LoadME(ByVal E As cPrMsTemplateEarnings)
        MyTempCode = E.TemGrpCode
        With E
            Dim Ern As New cPrMsEarningCodes(E.ErnCodCode)

            Me.Combo1.SelectedIndex = Me.Combo1.FindStringExact(Ern.ToString)
            Me.ComboFrom.SelectedIndex = Me.ComboFrom.FindStringExact(FindDescForComboFrom(E.FromMode))
            Me.ComboMode.SelectedIndex = Me.ComboMode.FindStringExact(FindDescForComboMode(E.TypeMode))
            Me.txtFormula.Text = E.CalcFormula
            If E.IsDispalyed = "Y" Then
                Me.CBIsDisplayed.Checked = True
            Else
                Me.CBIsDisplayed.Checked = False
            End If
            Me.txtDisplay.Text = E.DisplayName
            Me.txtNavCreditAccount.Text = E.ConsolDesc
            Me.txtNavDebitAccount.Text = E.NavDebitAccount
            Me.txtSeq.Text = E.ReportingSequence
        End With
    End Sub
    Private Function FindDescForComboFrom(ByVal FromMode As String) As String
        Dim S As String = ""
        Select Case FromMode
            Case "E"
                S = "E - Employee Default"
            Case "F"
                S = "F - Employee Fixed"
            Case "T"
                S = "T - From Table"
        End Select
        Return S
    End Function
    Private Function FindDescForComboMode(ByVal TypeMode As String) As String
        Dim S As String = ""
        Select Case TypeMode
            Case "V"
                S = "V - €"
            Case "P"
                S = "P - %"
        End Select
        Return S
    End Function
    Private Sub LoadComboEarnings()
        NotNow = True
        Dim i As Integer

        Dim E As New cPrMsEarningCodes
        With Me.Combo1
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(DS_E) Then
                .Items.Add(" ")
                For i = 0 To DS_E.Tables(0).Rows.Count - 1
                    E = New cPrMsEarningCodes(DS_E.Tables(0).Rows(i))
                    .Items.Add(E)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
        NotNow = False
    End Sub
    Private Sub LoadComboMode()
        With Me.ComboMode
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("V - €")
            .Items.Add("P - %")
            .SelectedIndex = 0
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadComboFrom()
        With Me.ComboFrom
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("E - Employee Default")
            .Items.Add("F - Employee Fixed")
            .Items.Add("T - From Table")
            .SelectedIndex = 0
            .EndUpdate()
        End With
    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo1.SelectedIndexChanged
        If NotNow Then Exit Sub
        If Me.Combo1.SelectedIndex <> 0 Then
            Me.txtDisplay.Text = CType(Me.Combo1.SelectedItem, cPrMsEarningCodes).DescriptionL
            Me.CBIsDisplayed.Checked = True
            Me.ComboMode.SelectedIndex = 0
            Me.ComboFrom.SelectedIndex = 0
            Me.txtFormula.Text = ""
        Else
            Me.txtDisplay.Text = ""
            Me.CBIsDisplayed.Checked = False
            Me.ComboMode.SelectedIndex = 0
            Me.ComboFrom.SelectedIndex = 0
            Me.txtFormula.Text = ""
        End If
    End Sub
    Public ReadOnly Property MyTypeMode() As String
        Get
            Dim S As String
            Dim Ar() As String
            S = Me.ComboMode.Text
            Ar = Split(S, "-")
            S = Trim(Ar(0))
            Return S
        End Get
    End Property
    Public ReadOnly Property MyFromMode() As String
        Get
            Dim S As String
            Dim Ar() As String
            S = Me.ComboFrom.Text
            Ar = Split(S, "-")
            S = Trim(Ar(0))
            Return S
        End Get
    End Property
    Public Sub SetError(ByVal Text As String)
        Er1.SetError(Me.txtDisplay, Text)
    End Sub

    Private Sub txtLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabel.Click
        ShowHideControls(False)
        Me.txtNavCreditAccount.Focus()
    End Sub

    Private Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDone.Click
        ShowHideControls(True)
    End Sub
    Private Sub ShowHideControls(ByVal TF As Boolean)

        Me.txtNavCreditAccount.Visible = Not TF
        Me.txtNavDebitAccount.Visible = Not TF
        Me.BtnDone.Visible = Not TF
        Me.lblCredit.Visible = Not TF
        Me.LblDebit.Visible = Not TF


        Me.txtLabel.Enabled = TF
        Me.txtDisplay.Visible = TF
        Me.Combo1.Visible = TF
        Me.ComboFrom.Visible = TF
        Me.txtFormula.Visible = TF
        Me.CBIsDisplayed.Visible = TF
        Me.ComboMode.Visible = TF


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MyTempCode <> "" Then
            Dim Ern As New cPrMsEarningCodes()

            Ern = CType(Me.Combo1.SelectedItem, cPrMsEarningCodes)
            If MyTempCode <> "" And Ern.Code <> "" Then
                If Global1.Business.ChangeEarningDescriptionOnLines(Ern.Code, MyTempCode, Me.txtDisplay.Text) Then
                    MsgBox("Description is Changed on 'CALC' Payslips", MsgBoxStyle.Information)
                Else
                    MsgBox("Failed to Change Description 'CALC' Payslips", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
End Class
