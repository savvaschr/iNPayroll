Public Class FrmChangeEDCCodeFromLines
    Public Tempgroup As cPrMsTemplateGroup
    Public Period As cPrMsPeriodCodes
    Dim PerGrp As New cPrMsPeriodGroups

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim EDCFromCode As String
        Dim EDCToCode As String
        Dim Type As String

        EDCFromcode = Me.txtFromCode.Text
        EDCToCode = Me.txtToCode.Text

        Type = Me.ComboEDC.SelectedItem.ToString

        Select Case Type
            Case "E"
                Dim ErnFrom As New cPrMsEarningCodes(EDCFromCode)
                Dim ErnTo As New cPrMsEarningCodes(EDCToCode)
                If ErnFrom.Code <> "" And ErnTo.Code <> "" Then
                    If Global1.Business.ReplaceEarningsFromLines(ErnFrom, ErnTo, PerGrp, Tempgroup) Then
                        MsgBox("Succesfully Changed to New EDC", MsgBoxStyle.Information)
                    Else
                        MsgBox("Failed to Changed to New EDC", MsgBoxStyle.Information)
                    End If

                Else
                    MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)

                End If
            Case "D"
                Dim DedFrom As New cPrMsDeductionCodes(EDCFromCode)
                Dim DedTo As New cPrMsDeductionCodes(EDCToCode)
                If DedFrom.Code <> "" And DedTo.Code <> "" Then
                    If Global1.Business.ReplaceDeductionsFromLines(DedFrom, DedTo, PerGrp, Tempgroup) Then
                        MsgBox("Succesfully Changed to New EDC", MsgBoxStyle.Information)
                    Else
                        MsgBox("Failed to Changed to New EDC", MsgBoxStyle.Information)
                    End If

                Else
                    MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)

                End If
            Case "C"
                Dim ConFrom As New cPrMsContributionCodes(EDCFromCode)
                Dim ConTo As New cPrMsContributionCodes(EDCToCode)
                If ConFrom.Code <> "" And ConTo.Code <> "" Then
                    If Global1.Business.ReplaceContributionsFromLines(ConFrom, ConTo, PerGrp, Tempgroup) Then
                        MsgBox("Succesfully Changed to New EDC", MsgBoxStyle.Information)
                    Else
                        MsgBox("Failed to Changed to New EDC", MsgBoxStyle.Information)
                    End If

                Else
                    MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)

                End If
        End Select





    End Sub

    Private Sub FrmChangeEDCCodeFromLines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PerGrp = New cPrMsPeriodGroups(Period.PrdGrpCode)
        Me.txtPeriodGroup.Text = PerGrp.Code & " " & PerGrp.DescriptionL
        Me.txtTempGroup.Text = Tempgroup.Code & " " & Tempgroup.DescriptionL
        Me.ComboEDC.SelectedIndex = 0


    End Sub
End Class