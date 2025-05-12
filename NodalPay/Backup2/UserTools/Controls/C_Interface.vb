Public Class C_Interface
    Public TemCon As New cPrMsTemplateContributions
    Public ConInt As New cPrMsContributionsInterface
    Public IntTem As New cPrMsInterfaceTemplate
    Public DSInterfaceCodes As DataSet
    Private Sub C_Interface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadCombos()
        'LoadComboInterfaceAccounts()
    End Sub
    Public Sub LoadComboInterfaceAccounts()
        Dim i As Integer
        With Me.cmbCreditAcc
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("")
            If CheckDataSet(DSInterfaceCodes) Then
                For i = 0 To DSInterfaceCodes.Tables(0).Rows.Count - 1
                    Dim IntCod As New cPrMsInterfaceCodes(DSInterfaceCodes.Tables(0).Rows(i))
                    .Items.Add(IntCod.Code)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        With Me.cmbDebitAcc
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("")
            If CheckDataSet(DSInterfaceCodes) Then
                For i = 0 To DSInterfaceCodes.Tables(0).Rows.Count - 1
                    Dim IntCod As New cPrMsInterfaceCodes(DSInterfaceCodes.Tables(0).Rows(i))
                    .Items.Add(IntCod.Code)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With

    End Sub
    Public Sub LoadCombos()
        With Me.CmbConsolCredit
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1 - EDC Level")
            .Items.Add("2 - EMPLOYEE Level")
            .Items.Add("3 - TEMPLATE Level")
            .EndUpdate()
            .SelectedIndex = 2
        End With
        With Me.cmbConsolDebit
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1 - EDC Level")
            .Items.Add("2 - EMPLOYEE Level")
            .Items.Add("3 - TEMPLATE Level")
            .SelectedIndex = 2
            .EndUpdate()
        End With

    End Sub
    Public Sub LoadMe()
        If TemCon.Id > 0 Then
            Me.txtCon.Text = TemCon.DisplayName
        Else
            Me.txtCon.Text = ""
        End If
        If ConInt.Id > 0 Then
            With ConInt
                Me.cmbCreditAcc.SelectedIndex = Me.cmbCreditAcc.FindStringExact(ConInt.CreditAccount)
                Me.cmbDebitAcc.SelectedIndex = Me.cmbDebitAcc.FindStringExact(ConInt.DebitAccount)
                Me.CmbConsolCredit.SelectedIndex = CInt(ConInt.CreditConsol) - 1
                Me.cmbConsolDebit.SelectedIndex = CInt(ConInt.DebitConsol) - 1
                Me.txtCreditAnal.Text = .CreditAnal
                Me.txtDebitAnal.Text = .DebitAnal
            End With
        Else
            Me.cmbCreditAcc.SelectedIndex = 0
            Me.cmbDebitAcc.SelectedIndex = 0
            Me.CmbConsolCredit.SelectedIndex = 2
            Me.cmbConsolDebit.SelectedIndex = 2
            Me.txtCreditAnal.Text = ""
            Me.txtDebitAnal.Text = ""
        End If
    End Sub
    Public Function SaveMe() As Boolean
        Dim Flag As Boolean = True
        If Not TemCon Is Nothing Then
            If TemCon.Id > 0 Then
                With ConInt
                    .IntTemCode = IntTem.IntTemCode
                    .TemGrpCode = TemCon.TemGrp_Code
                    .ConCode = TemCon.ConCodCode
                    .CreditAccount = Me.cmbCreditAcc.Text
                    .CreditConsol = Me.CmbConsolCredit.SelectedIndex + 1
                    .DebitAccount = Me.cmbDebitAcc.Text
                    .DebitConsol = Me.cmbConsolDebit.SelectedIndex + 1
                    .CreditAnal = Me.txtCreditAnal.Text
                    .DebitAnal = Me.txtDebitAnal.Text
                    If Not .Save Then
                        Flag = False
                    End If
                End With
            End If
        End If
        Return Flag
    End Function

    Private Sub txtCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCon.Click
        Dim Flag As Boolean
        Flag = Me.txtCreditAnal.Visible
        If Flag = True Then
            If TemCon.Id > 0 Then
                Me.txtCon.Text = TemCon.DisplayName
            End If
        Else
            Me.txtCon.Text = "DONE"
        End If
        Me.txtCreditAnal.Visible = Not Flag
        Me.txtDebitAnal.Visible = Not Flag


        Me.cmbCreditAcc.Visible = Flag
        Me.cmbDebitAcc.Visible = Flag

        Me.CmbConsolCredit.Visible = Flag
        Me.cmbConsolDebit.Visible = Flag
    End Sub

    Private Sub btnShowDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDebit.Click
        If cmbDebitAcc.Text <> "" Then
            Dim Code As String = ""
            Code = cmbDebitAcc.Text
            Dim F As New FrmPrMsInterfaceCode
            F.Show()
            F.LoadSpecificCode(IntTem.TemGrpCode, Code)
        End If
    End Sub

    Private Sub BtnShowCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowCredit.Click
        If cmbCreditAcc.Text <> "" Then
            Dim Code As String = ""
            Code = cmbCreditAcc.Text
            Dim F As New FrmPrMsInterfaceCode
            F.Show()
            F.LoadSpecificCode(IntTem.TemGrpCode, Code)
        End If
    End Sub
End Class
