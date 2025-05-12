Public Class FrmSelectEmployeesForBankFile
    Public Ds As DataSet
    Public ForHellenic As Boolean = False

  
    Private Sub FrmSelectEmployeesForBankFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DG1.DataSource = Ds.Tables(0)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        CType(Me.Owner, FrmBankTransferFile).DsSelection = Ds
        CType(Me.Owner, FrmBankTransferFile).RunSelection = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckDataSet(Ds) Then
            Dim S As String = "0"
            If Me.CheckBox1.CheckState = CheckState.Checked Then
                s = "1"
            End If

            Dim i As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ForHellenic Then
                    Ds.Tables(0).Rows(i).Item(10) = S
                Else
                    Ds.Tables(0).Rows(i).Item(11) = S
                End If
            Next
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If CheckDataSet(Ds) Then
            Dim i As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ForHellenic Then
                    If UCase(DbNullToString(Ds.Tables(0).Rows(i).Item(11))) = UCase(Me.txtGenAnal1.Text) Then
                        Ds.Tables(0).Rows(i).Item(10) = 1
                    Else
                        Ds.Tables(0).Rows(i).Item(10) = 0
                    End If
                Else
                    If UCase(DbNullToString(Ds.Tables(0).Rows(i).Item(12))) = UCase(Me.txtGenAnal1.Text) Then
                        Ds.Tables(0).Rows(i).Item(11) = 1
                    Else
                        Ds.Tables(0).Rows(i).Item(11) = 0
                    End If
                End If
            Next
        End If
    End Sub
End Class