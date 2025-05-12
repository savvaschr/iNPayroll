Public Class FrmRegistredPCs

   
    Private Sub BtnGetSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSerial.Click
        Dim S As String
        S = CType(Me.Owner, FrmMain).GetDriverSerialNumber
        Me.txtSerialNo.Text = S

    End Sub

    Private Sub btnGetProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProduct.Click
        Dim S As String
        If Me.txtEncryptionKey.Text <> "" Then
            S = CType(Me.Owner, FrmMain).EncryptMe(Me.txtSerialNo.Text, Me.txtEncryptionKey.Text)
            Me.txtProductKey.Text = S
        Else
            MsgBox("Encryption Key must not be empty", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ProductKey As String = Me.txtProductKey.Text
        Dim Desc As String = txtPCDescription.Text

        If ProductKey <> "" Then
            If Desc <> "" Then
                Dim S As New cPrLcValues(Desc, ProductKey)
                If S.Description <> "" Then
                    Dim Ans As New MsgBoxResult
                    MsgBox("This Record Already Exists!", MsgBoxStyle.Information)
                Else
                    S.Description = Desc
                    S.LC = ProductKey
                    If Not S.Save(False) Then
                        MsgBox("Unable to Save, Please contact SC Insoft Limited", MsgBoxStyle.Critical)
                    Else
                        MsgBox("Succesfull Registration !", MsgBoxStyle.Information)
                    End If

                End If
            Else
                MsgBox("PC Description is a mandatory Field", MsgBoxStyle.Critical)

            End If
        Else
            MsgBox("Missing Product Key", MsgBoxStyle.Critical)
        End If
    End Sub
End Class