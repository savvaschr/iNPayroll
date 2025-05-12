Public Class D_Control
    Public MyIndex As Integer
    Public DS_D As DataSet
    Dim NotNow As Boolean = True
    Dim MyTempCode As String = ""
    Public Sub LoadME()
        LoadCombodeductions()
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
    Public Sub LoadME(ByVal D As cPrMsTemplateDeductions)
        MyTempCode = D.TemGrpCode
        With D
            Dim Ded As New cPrMsDeductionCodes(D.DedCodCode)
            Me.Combo1.SelectedIndex = Me.Combo1.FindStringExact(Ded.ToString)
            Me.ComboFrom.SelectedIndex = Me.ComboFrom.FindStringExact(FindDescForComboFrom(D.FromMode))
            Me.ComboMode.SelectedIndex = Me.ComboMode.FindStringExact(FindDescForComboMode(D.TypeMode))
            Me.txtFormula.Text = D.CalcFormula
            If D.IsDispalyed = "Y" Then
                Me.CBIsDisplayed.Checked = True
            Else
                Me.CBIsDisplayed.Checked = False
            End If
            Me.txtDisplay.Text = D.DisplayName
            Me.txtNavCreditAccount.Text = D.ConsolDesc
            Me.txtNavDebitAccount.Text = D.NavDebitAccount
            Me.txtSeq.Text = D.ReportingSequence

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
            Case "X"
                S = "X - User Defined"

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
    Private Sub LoadCombodeductions()
        NotNow = True
        Dim i As Integer

        Dim D As New cPrMsDeductionCodes
        With Me.Combo1
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(DS_D) Then
                .Items.Add(" ")
                For i = 0 To DS_D.Tables(0).Rows.Count - 1
                    D = New cPrMsDeductionCodes(DS_D.Tables(0).Rows(i))
                    .Items.Add(D)
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
            .Items.Add("X - User Defined")
            .SelectedIndex = 0
            .EndUpdate()
        End With
    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo1.SelectedIndexChanged
        If notnow Then Exit Sub
        If Me.Combo1.SelectedIndex <> 0 Then
            Me.txtDisplay.Text = CType(Me.Combo1.SelectedItem, cPrMsDeductionCodes).DescriptionL
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

    Private Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
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
            Dim Ded As New cPrMsDeductionCodes()


            Ded = CType(Me.Combo1.SelectedItem, cPrMsDeductionCodes)
            If MyTempCode <> "" And Ded.Code <> "" Then
                If Global1.Business.ChangeDeductionsDescriptionOnLines(Ded.Code, MyTempCode, Me.txtDisplay.Text) Then
                    MsgBox("Description is Changed on 'CALC' Payslips", MsgBoxStyle.Information)
                Else
                    MsgBox("Failed to Change Description 'CALC' Payslips", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
End Class
