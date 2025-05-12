Public Class FrmReplaceEDCValue
    Public TempCode As String
    Private Sub FrmReplaceEDCValue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTemGroup.Text = TempCode
        Me.ComboEDC.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Ans As New MsgBoxResult

        Dim TemGroupCode As String
        Dim EDCType As String
        Dim EDCCode As String
        Dim OldValue As Double
        Dim NewValue As Double

        TemGroupCode = Me.txtTemGroup.Text
        EDCType = Me.ComboEDC.SelectedItem.ToString
        EDCCode = Me.txtEDCCode.Text
        OldValue = Me.txtCurrentValue.Text
        NewValue = Me.txtNewValue.Text
        Try

        

            If EDCType <> "" And EDCCode <> "" Then
                Ans = MsgBox("Do you want to Replace " & EDCCode & " from " & OldValue & " to " & NewValue, MsgBoxStyle.YesNoCancel)
                If Ans = MsgBoxResult.Yes Then
                    Dim i As Integer
                    i = Global1.Business.ReplaceEmployeeEDCValue(TemGroupCode, EDCType, EDCCode, OldValue, NewValue)
                    MsgBox(i & " number of replacements occured", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

    End Sub

   
End Class