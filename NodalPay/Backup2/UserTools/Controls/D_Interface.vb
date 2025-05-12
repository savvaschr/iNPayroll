Public Class D_Interface
    Public TemDed As New cPrMsTemplateDeductions
    Public DedInt As New cPrMsDeductionsInterface
    Public IntTem As New cPrMsInterfaceTemplate
    Public DSInterfaceCodes As DataSet
    Private Sub E_Interface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadCombos()
        ' LoadComboInterfaceAccounts()
    End Sub
    Public Sub LoadComboInterfaceAccounts()

        Dim i As Integer
        With Me.cmbCreditAcc
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("")
            If CheckDataSet(DsInterfaceCodes) Then
                For i = 0 To DsInterfaceCodes.Tables(0).Rows.Count - 1
                    Dim IntCod As New cPrMsInterfaceCodes(DsInterfaceCodes.Tables(0).Rows(i))
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
            If CheckDataSet(DsInterfaceCodes) Then
                For i = 0 To DsInterfaceCodes.Tables(0).Rows.Count - 1
                    Dim IntCod As New cPrMsInterfaceCodes(DsInterfaceCodes.Tables(0).Rows(i))
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
        If TemDed.Id > 0 Then
            Me.txtDed.Text = TemDed.DisplayName
        Else
            Me.txtDed.Text = ""
        End If

        If DedInt.Id > 0 Then
            With DedInt
                Me.cmbCreditAcc.SelectedIndex = Me.cmbCreditAcc.FindStringExact(DedInt.CreditAccount)
                Me.cmbDebitAcc.SelectedIndex = Me.cmbDebitAcc.FindStringExact(DedInt.DebitAccount)
                Me.CmbConsolCredit.SelectedIndex = DedInt.CreditConsol - 1
                Me.cmbConsolDebit.SelectedIndex = DedInt.DebitConsol - 1
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
        If Not TemDed Is Nothing Then
            If TemDed.Id > 0 Then
                With DedInt
                    .IntTemCode = IntTem.IntTemCode
                    .TemGrpCode = TemDed.TemGrpCode
                    .DedCode = TemDed.DedCodCode
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

    Private Sub txtDed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDed.Click
        Dim Flag As Boolean
        Flag = Me.txtCreditAnal.Visible
        If Flag = True Then
            If TemDed.Id > 0 Then
                Me.txtDed.Text = TemDed.DisplayName
            End If
        Else
            Me.txtDed.Text = "DONE"
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
