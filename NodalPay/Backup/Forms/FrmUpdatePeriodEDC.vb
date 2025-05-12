Public Class FrmUpdatePeriodEDC
    Private Sub FrmUpdatePeriodEDC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ComboBox1.SelectedIndex = 0
        Me.ComboBox2.SelectedIndex = 0
        Me.ComboBox3.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ans As New MsgBoxResult
        ans = MsgBox("This action will activate this EDC to all periods, Proceed? ", MsgBoxStyle.YesNoCancel)
        Dim EDCCode As String
        EDCCode = Me.TextBox1.Text

        If ans = MsgBoxResult.Yes Then
            RunUpdate("E", EDCCode)

        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ans As New MsgBoxResult
        ans = MsgBox("This action will activate this EDC to all periods, Proceed? ", MsgBoxStyle.YesNoCancel)
        Dim EDCCode As String
        EDCCode = Me.TextBox2.Text

        If ans = MsgBoxResult.Yes Then
            RunUpdate("D", EDCCode)

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ans As New MsgBoxResult
        ans = MsgBox("This action will activate this EDC to all periods, Proceed? ", MsgBoxStyle.YesNoCancel)
        Dim EDCCode As String
        EDCCode = Me.TextBox3.Text

        If ans = MsgBoxResult.Yes Then
            RunUpdate("C", EDCCode)

        End If
    End Sub
    Private Sub RunUpdate(ByVal EDCType As String, ByVal EDCCode As String)

        If EDCCode <> "" Then
            CType(Me.Owner, FrmPrMsPeriods).ActivateEDC(EDCCode, EDCType)
        Else
            MsgBox("Please select Valid EDC Code", MsgBoxStyle.Critical)
        End If

    End Sub

   
   
End Class