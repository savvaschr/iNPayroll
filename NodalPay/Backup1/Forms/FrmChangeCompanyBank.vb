
Public Class FrmChangeCompanyBank
    Public TempGroupCode As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim OldBank As String = ""
        Dim NewBank As String = ""


        OldBank = CType(Me.ComboOld.SelectedItem, cPrAnBanks).Code
        NewBank = CType(Me.ComboNew.SelectedItem, cPrAnBanks).Code

        If Global1.Business.ReplaceCompanyBankCode(OldBank, NewBank, TempGroupCode) Then
            MsgBox("IBAN/Account code is replaced succesfully", MsgBoxStyle.Information)
        Else
            MsgBox("Unable to replace IBAN/Account Code ", MsgBoxStyle.Information)
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
            Me.ComboOld.BeginUpdate()
            Me.ComboOld.Items.Clear()

            Me.ComboNew.BeginUpdate()
            Me.ComboNew.Items.Clear()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                ComboOld.Items.Add(tPrAnBanks)
                ComboNew.Items.Add(tPrAnBanks)
            Next i
            ComboOld.SelectedIndex = 0
            ComboNew.SelectedIndex = 0
            ComboOld.EndUpdate()
            ComboNew.EndUpdate()

        End If
    End Sub

End Class