Public Class FrmPrMsEmployeePhoto
    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources.photo
    End Sub

    Private Sub BStartCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStartCapture.Click
        Dim k As New frmCamera
        k.ShowDialog()
        If GLBWebCam_TempFileNames2.Length > 0 Then
            Picture.Image = Image.FromFile(GLBWebCam_TempFileNames2)
            Photoname = GLBWebCam_TempFileNames2
            IsImageChanged = True
        End If
    End Sub
End Class