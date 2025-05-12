Public Class FrmXMLDestination

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ValidateDestination() Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'SaveFile.InitialDirectory = OpenFile.InitialDirectory
        SaveFile.FileName = ""
        SaveFile.ShowDialog()
        Me.txtToFile.Text = SaveFile.FileName
    End Sub
    Private Function ValidateDestination() As Boolean
        Dim Flag As Boolean = True
        If Me.txtToFile.Text = "" Then
            Flag = False
        Else
            Dim Ar() As String
            Ar = Me.txtToFile.Text.Split(".")
            If Ar.Length = 2 Then
                If Ar(1) <> "xml" Then
                    Flag = False
                End If
            Else
                Flag = False
            End If
        End If
        If Not Flag Then
            MsgBox("Please select Valid File Name, file name extension must be '.xml' ", MsgBoxStyle.Critical)
        End If
        Return Flag
    End Function

    Private Sub FrmXMLDestination_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Global1.GlbCancelIr7 Then
            If Me.ValidateDestination Then
                CType(Me.Owner, FrmIR63A).GLB_XMLDestinationFile = Me.txtToFile.Text
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Do you want to Cancel the procedure?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            Global1.GlbCancelIr7 = True
            Me.Close()
        End If
    End Sub

    Private Sub FrmXMLDestination_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Global1.GlbCancelIr7 = False
    End Sub
End Class