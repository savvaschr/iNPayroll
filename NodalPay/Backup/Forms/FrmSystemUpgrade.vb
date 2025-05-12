Public Class FrmSystemUpgrade

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Global1.Business.Upgrade2019_1() Then
            MsgBox("succesfull Upgrade to 2019 1 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 1 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Global1.Business.Upgrade2019_2() Then
            MsgBox("succesfull Upgrade to 2019 2 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 2 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Global1.Business.Upgrade2019_3() Then
            MsgBox("succesfull Upgrade to 2019 3 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 3 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Global1.Business.Upgrade2019_4() Then
            MsgBox("succesfull Upgrade to 2019 4 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 4 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor.Current = Cursors.WaitCursor
        If Global1.Business.Upgrade2019_5() Then
            MsgBox("succesfull Upgrade to 2019 5 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 5 Version", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Global1.Business.Upgrade2019_6() Then
            MsgBox("succesfull Upgrade to 2019 6 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 6 Version", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Global1.Business.Upgrade2019_7() Then
            MsgBox("succesfull Upgrade to 2019 7 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 7 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Global1.Business.Upgrade2019_8() Then
            MsgBox("succesfull Upgrade to 2019 8 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 8 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Global1.Business.Upgrade2019_9() Then
            MsgBox("succesfull Upgrade to 2019 9 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 9 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Global1.Business.Upgrade2019_10() Then
            MsgBox("succesfull Upgrade to 2019 10 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 10 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Global1.Business.Upgrade2019_11() Then
            MsgBox("succesfull Upgrade to 2019 11 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 11 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If Global1.Business.Upgrade2019_12() Then
            MsgBox("succesfull Value Update", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 11 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If Global1.Business.Upgrade2019_13() Then
            MsgBox("succesfull Value Update", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 13 Version", MsgBoxStyle.Critical)
        End If
    End Sub
    

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Global1.Business.Upgrade2019_14() Then
            MsgBox("Succesfull Upgrade to 2019 8 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 8 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If Global1.Business.CreateNodalInterfaceParameters() Then
            MsgBox("Parameters are added", MsgBoxStyle.Information)
        Else
            MsgBox("Fail to add Paramaters", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If Global1.Business.Upgrade2019_15() Then
            MsgBox("succesfull Upgrade to 2019 15 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 15 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If Global1.Business.Upgrade2019_16() Then
            MsgBox("succesfull Upgrade to 2019 16 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 16 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Global1.Business.Upgrade2019_17()

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        If Global1.Business.Upgrade2019_18() Then
            MsgBox("succesfull Upgrade to 2019 18 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 18 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If Global1.Business.Upgrade2019_19() Then
            MsgBox("succesfull Upgrade to 2019 19 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 19 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If Global1.Business.Upgrade2019_20() Then
            MsgBox("succesfull Upgrade to 2019 20 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2019 20 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If Global1.Business.CreateEmailPayslipWording() Then
            MsgBox("succesfull Creation of Parameters for Email wording", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Create Parameters for Email wording", MsgBoxStyle.Critical)
        End If



    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If Global1.Business.Fixnvarcharonanalysis() Then

            MsgBox("succesfull Fix", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Fix", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        If Global1.Business.AddTaxRuleAsParameter() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        If Global1.Business.AddDefRowCount() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        If Global1.Business.AddIndexes() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        If Global1.Business.AddOverTimeParameters() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
        
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        killprocess()
    End Sub
    Private Sub killprocess()
        Dim pName As String
        For Each p As Process In Process.GetProcesses
            pName = p.ProcessName
            If UCase(pName) Like UCase("inpayroll") Then
                p.Kill()
            End If
        Next
    End Sub


    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Dim P As New cPrSsParameters
        P.Id = 0
        P.Section = "IT"
        P.Item = "TaxRule"
        P.Description = "Tax Rule"
        P.Value1 = 20
        P.Type1 = "T"
        P.System1 = "Y"
        If P.Save Then
            MsgBox("succesfull Save", MsgBoxStyle.Information)
        Else
            MsgBox("Fail to Save ", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Try
            Dim tPrSsLimits As New cPrSsLimits
            With tPrSsLimits
                .Id = 0
                .EffectiveDate = CDate("2020/01/01")
                .Cola = CDbl(1.27)
                .InsurableWk = CDbl(1055)
                .InsurableMth = CDbl(4572)
                .InsurableAnnual = CDbl(54864)
                .DedContrAnnual = CDbl(9107.42)
                .IndAnnual = CDbl(274.32)
                .EffectiveDate = CDate("2020/01/01")
                .UnemAnnual = CDbl(658.37)
                .GesiD = CDbl(3060)
                .GesiC = CDbl(3330)
                If .Save() Then
                    MsgBox("Succesfull Limits Change for 2020", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
        End Try
      
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        If Global1.Business.Upgrade_AddMFOnDiscounts_30() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub BtnAddDirector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDirector.Click
        If Global1.Business.Upgrade2020_01() Then
            MsgBox("succesfull Upgrade to 2020 01 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 01 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        If Global1.Business.Upgrade2020_02() Then
            MsgBox("succesfull Upgrade to 2020 02 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 02 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        If Global1.Business.Upgrade2020_03() Then
            MsgBox("succesfull Upgrade to 2020 03 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 03 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        'If Global1.Business.Upgrade2020_04() Then
        '    MsgBox("succesfull Upgrade to 2020 04 Version", MsgBoxStyle.Information)
        'Else
        '    MsgBox("Failed to Upgrade to 2020 04 Version", MsgBoxStyle.Critical)
        'End If
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        If Global1.Business.AddURLParameters() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        If Global1.Business.AlterCompanyName() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        If Global1.Business.Upgrade2020_05() Then
            MsgBox("Succesfull Upgrade - Loan Comments", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade  - Loan Comments", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        If Global1.Business.Upgrade2020_06() Then
            MsgBox("succesfull Upgrade to 2020 06 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 06 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        If Global1.Business.Upgrade2020_07() Then
            MsgBox("succesfull Upgrade to 2020 07 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 07 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        If Global1.Business.Upgrade2020_08() Then
            MsgBox("succesfull Upgrade to 2020 08 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 08 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    
    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Try
            Dim tPrSsLimits As New cPrSsLimits
            With tPrSsLimits
                .Id = 0
                .EffectiveDate = CDate("2021/01/01")
                .Cola = CDbl(1.27)
                .InsurableWk = CDbl(1104)
                .InsurableMth = CDbl(4784)
                .InsurableAnnual = CDbl(57408)
                .DedContrAnnual = CDbl(9529.73)
                .IndAnnual = CDbl(287.04)
                .EffectiveDate = CDate("2021/01/01")
                .UnemAnnual = CDbl(688.9)
                .GesiD = CDbl(4770)
                .GesiC = CDbl(5220)
                If .Save() Then
                    MsgBox("Succesfull Limits Change for 2021", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        If Global1.Business.Upgrade2020_09() Then
            MsgBox("succesfull Upgrade to 2020 09 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2020 09 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        If Global1.Business.Upgrade2021_10() Then
            MsgBox("succesfull Upgrade to 2021 10 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2021 10 Version", MsgBoxStyle.Critical)
        End If
    End Sub


    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        If Global1.Business.Upgrade2021_11() Then
            MsgBox("succesfull Upgrade to 2021 11 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2021 11 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        If Global1.Business.Set50PercAmountto55000() Then
            MsgBox("Amount for 50% rule is set to 55000", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add parameter", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Global1.Business.Upgrade_2022_01()
        'If Global1.Business.Upgrade_2022_01() Then
        '    MsgBox("succesfull Upgrade to 2022 01 Version", MsgBoxStyle.Information)
        'Else
        '    MsgBox("Failed to Upgrade to 2022 01 Version", MsgBoxStyle.Critical)
        'End If
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        If Global1.Business.Upgrade2022_02() Then
            MsgBox("succesfull Upgrade to 2022 02 Version", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Upgrade to 2022 02 Version", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        Global1.Business.Upgrade_2022_03()
    End Sub

    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Global1.Business.Upgrade_2022_04()
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Global1.Business.Upgrade_2022_05()
    End Sub
    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Try
            Dim tPrSsLimits As New cPrSsLimits
            With tPrSsLimits
                .Id = 0
                .EffectiveDate = CDate("2022/01/01")
                .Cola = CDbl(2.56)
                .InsurableWk = CDbl(1117)
                .InsurableMth = CDbl(4840)
                .InsurableAnnual = CDbl(58080)
                .DedContrAnnual = CDbl(9641.28)
                .IndAnnual = CDbl(290.4)
                .UnemAnnual = CDbl(696.96)
                .GesiD = CDbl(4770)
                .GesiC = CDbl(5220)
                If .Save() Then
                    MsgBox("Succesfull Limits Change for 2022", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        Try
            Dim tPrSsLimits As New cPrSsLimits
            With tPrSsLimits
                .Id = 0
                .EffectiveDate = CDate("2023/01/01")
                .Cola = CDbl(7.03)
                .InsurableWk = CDbl(1155)
                .InsurableMth = CDbl(5005)
                .InsurableAnnual = CDbl(60060)
                .DedContrAnnual = CDbl(9970.08)
                .IndAnnual = CDbl(300.3)
                .UnemAnnual = CDbl(720.72)
                .GesiD = CDbl(4770)
                .GesiC = CDbl(5220)
                If .Save() Then
                    MsgBox("Succesfull Limits Change for 2023", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                End If
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button53.Click
        Global1.Business.Upgrade_2022_06()
    End Sub

    Private Sub Button54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button54.Click
        If Global1.Business.Upgrade_AddPenFundOnDiscounts() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button55.Click
        Dim Par As New cPrSsParameters
        Par.Id = 0
        Par.Section = "Payslip"
        Par.Item = "AddBIK"
        Par.Value1 = 1
        Par.Type1 = "T"
        Par.System1 = "N"
        Par.Description = "Add BIK on Pay Total"
        If Par.Save() Then
            MsgBox("Set to True")
        Else
            MsgBox("Error")
        End If

    End Sub

    Private Sub Button56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button56.Click
        If Global1.Business.AddURLParameters2() Then
            MsgBox("Succesfull Add", MsgBoxStyle.Information)
        Else
            MsgBox("Failed to Add", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button57.Click
        Global1.Business.Upgrade_2023_07()

    End Sub

    Private Sub Button58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button58.Click
        Dim Par As New cPrSsParameters
        Par.Id = 0
        Par.Section = "System"
        Par.Item = "AllocationStatus"
        Par.Value1 = "MjAyMw=="
        Par.Type1 = "T"
        Par.System1 = "Y"
        Par.Description = "Add BIK on Pay Total"
        If Par.Save() Then
            MsgBox("Set")
        Else
            MsgBox("Error")
        End If
    End Sub
End Class