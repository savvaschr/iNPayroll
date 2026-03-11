Public Class FrmLoadGeneralImportForm
    Public LoadingType As String
    Private Sub FrmLoadGeneralImportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Loading As String = ""
        Select Case LoadingType
            Case "1"
                LoadingType = "Emails"
            Case "2"
                LoadingType = "IBANs"
            Case "3"
                LoadingType = "Account Numbers"
            Case "4"
                LoadingType = "Analisys 1"
            Case "5"
                LoadingType = "Analisys 2"
            Case "6"
                LoadingType = "Analisys 3"
            Case "7"
                LoadingType = "Analisys 4"
            Case "8"
                LoadingType = "Analisys 5"
            Case "9"
                LoadingType = "GL Analisys 1"
            Case "10"
                'Provident Fund
                LoadingType = "10"


        End Select
        Me.txtFirstRow.Text = 2

        Me.Label1.Text = Label1.Text & " " & LoadingType
        If LoadingType = "10" Then
            Me.Label1.Text = "The Excel must have 4 columns , 1.Emp Code, 2.Emp Name, 3.PF Ded.Value 4.PF Con. Value "
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If LoadingType <> "10" Then
            If OpenFile.FileName <> "" Then
                CType(Me.Owner, FrmMain).GLBProceedWithExcel_Loading = True
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_ExcelFileToOpen = OpenFile.FileName
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_FirstRow = Me.txtFirstRow.Text

                Me.Close()
            Else
                MsgBox("Please select valid File name to upload")
            End If
        Else
            If OpenFile.FileName <> "" Then
                CType(Me.Owner, frmPrMsEmployees).GLBProceedWithExcel_Loading = True
                CType(Me.Owner, frmPrMsEmployees).GLBLoadingFromExcel_ExcelFileToOpen = OpenFile.FileName
                CType(Me.Owner, frmPrMsEmployees).GLBLoadingFromExcel_FirstRow = Me.txtFirstRow.Text

                Me.Close()
            Else
                MsgBox("Please select valid File name to upload")
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        OpenFile.FileName = ""
        OpenFile.ShowDialog()
        Me.txtToFile.Text = OpenFile.FileName
    End Sub
End Class
