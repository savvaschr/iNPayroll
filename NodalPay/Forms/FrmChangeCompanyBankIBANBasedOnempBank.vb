Public Class FrmChangeCompanyBankIBANBasedOnempBank

    Public TempGroupCode As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim EmpBank As String = ""
        Dim ComBank As String = ""
        Dim IBAN As String = ""


        EmpBank = CType(Me.ComboEmp.SelectedItem, cPrAnBanks).Code
        ComBank = CType(Me.ComboCom.SelectedItem, cPrAnBanks).Code
        IBAN = Me.TextBox1.Text

        Dim Ans As New MsgBoxResult
        Ans = MsgBox("By this Action Company Bank will be set to " & ComBank & " And Company IBAN to " & IBAN & " for All Employees with Bank Code " & EmpBank & ". Continue? ", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then


            If Global1.Business.ChangeCompanyBankCodeAndIBAN(EmpBank, ComBank, IBAN, TempGroupCode) Then
                MsgBox("IBAN/Account code is replaced succesfully", MsgBoxStyle.Information)
            Else
                MsgBox("Unable to replace IBAN/Account Code ", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub FrmChangeCompanyBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPrAnBanks()
    End Sub

    Private Sub LoadPrAnBanks()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            Me.ComboEmp.BeginUpdate()
            Me.ComboEmp.Items.Clear()

            Me.ComboCom.BeginUpdate()
            Me.ComboCom.Items.Clear()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                ComboEmp.Items.Add(tPrAnBanks)
                ComboCom.Items.Add(tPrAnBanks)
            Next i
            ComboEmp.SelectedIndex = 0
            ComboCom.SelectedIndex = 0
            ComboEmp.EndUpdate()
            ComboCom.EndUpdate()

        End If
    End Sub


End Class