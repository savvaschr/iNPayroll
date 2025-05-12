Public Class FrmPrMsTemplateEDC
    Dim Earr(14) As E_Control
    Dim Darr(14) As D_Control
    Dim Carr(14) As C_Control
    Dim Delete_E As New ArrayList
    Dim Delete_D As New ArrayList
    Dim Delete_C As New ArrayList

    Private Sub FrmPrMsTemplateEDC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        LoadComboTemplateGroup()
        LoadArray_E()
        LoadArray_D()
        LoadArray_C()
        LoadControls_E()
        LoadControls_D()
        LoadControls_C()
    End Sub
    Private Sub LoadComboTemplateGroup()
        Dim Ds As DataSet
        Dim i As Integer
        Ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTemplateGroup
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(" ")
            Dim TGrp As New cPrMsTemplateGroup
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    TGrp = New cPrMsTemplateGroup(Ds.Tables(0).Rows(i))
                    .Items.Add(TGrp)
                Next
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadArray_E()
        Earr(0) = Me.E_Con1
        Earr(1) = Me.E_Con2
        Earr(2) = Me.E_Con3
        Earr(3) = Me.E_Con4
        Earr(4) = Me.E_Con5
        Earr(5) = Me.E_Con6
        Earr(6) = Me.E_Con7
        Earr(7) = Me.E_Con8
        Earr(8) = Me.E_Con9
        Earr(9) = Me.E_Con10
        Earr(10) = Me.E_Con11
        Earr(11) = Me.E_Con12
        Earr(12) = Me.E_Con13
        Earr(13) = Me.E_Con14
        Earr(14) = Me.E_Con15
    End Sub
    Private Sub LoadArray_D()
        Darr(0) = Me.D_Con1
        Darr(1) = Me.D_Con2
        Darr(2) = Me.D_Con3
        Darr(3) = Me.D_Con4
        Darr(4) = Me.D_Con5
        Darr(5) = Me.D_Con6
        Darr(6) = Me.D_Con7
        Darr(7) = Me.D_Con8
        Darr(8) = Me.D_Con9
        Darr(9) = Me.D_Con10
        Darr(10) = Me.D_Con11
        Darr(11) = Me.D_Con12
        Darr(12) = Me.D_Con13
        Darr(13) = Me.D_Con14
        Darr(14) = Me.D_Con15
    End Sub
    Private Sub LoadArray_C()
        Carr(0) = Me.C_Con1
        Carr(1) = Me.C_Con2
        Carr(2) = Me.C_Con3
        Carr(3) = Me.C_Con4
        Carr(4) = Me.C_Con5
        Carr(5) = Me.C_Con6
        Carr(6) = Me.C_Con7
        Carr(7) = Me.C_Con8
        Carr(8) = Me.C_Con9
        Carr(9) = Me.C_Con10
        Carr(10) = Me.C_Con11
        Carr(11) = Me.C_Con12
        Carr(12) = Me.C_Con13
        Carr(13) = Me.C_Con14
        Carr(14) = Me.C_Con15
    End Sub
    Private Sub LoadControls_E()
        Dim i As Integer
        Dim Ds As DataSet
        Ds = Global1.Business.AG_GetAllPrMsEarningCodes
        For i = 0 To Earr.Length - 1
            Earr(i).MyIndex = i
            Earr(i).DS_E = Ds
            Earr(i).LoadME()
        Next
    End Sub
    Private Sub LoadControls_D()
        Dim i As Integer
        Dim Ds As DataSet
        Ds = Global1.Business.AG_GetAllPrMsDeductionCodes
        For i = 0 To Darr.Length - 1
            Darr(i).MyIndex = i
            Darr(i).DS_D = Ds
            Darr(i).LoadME()
        Next
    End Sub
    Private Sub LoadControls_C()
        Dim i As Integer
        Dim Ds As DataSet
        Ds = Global1.Business.AG_GetAllPrMsContributionCodes
        For i = 0 To Earr.Length - 1
            Carr(i).MyIndex = i
            Carr(i).DS_C = Ds
            Carr(i).LoadME()
        Next
    End Sub
    Private Sub ComboTemplateGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTemplateGroup.SelectedIndexChanged
        LoadTemplatesForGroup()
    End Sub
    Private Sub LoadTemplatesForGroup()
        Dim TempGrp As New cPrMsTemplateGroup
        If Trim(Me.ComboTemplateGroup.Text) <> "" Then
            TempGrp = CType(Me.ComboTemplateGroup.SelectedItem, cPrMsTemplateGroup)
        End If
        LoadEarnings(TempGrp)
        LoadDeductions(TempGrp)
        LoadContributions(TempGrp)
    End Sub
    Private Sub LoadEarnings(ByVal TempGrp As cPrMsTemplateGroup)
        Dim Ds As DataSet
        Dim i As Integer
        Dim E As New cPrMsTemplateEarnings
        Dim k As Integer
        Dim S As String
        For i = 0 To Earr.Length - 1
            Earr(i).ClearME()
        Next
        If TempGrp.Code <> "" Then
            Ds = Global1.Business.GetAllPrMsTemplateEarnings(TempGrp.Code)
            
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                E = New cPrMsTemplateEarnings(Ds.Tables(0).Rows(i))
                For k = 0 To Earr.Length - 1
                    S = findSfor(k)
                    If S = E.Sequence Then
                        Earr(k).LoadME(E)
                    End If
                Next k
            Next
        End If


    End Sub
    Private Sub LoadDeductions(ByVal TempGrp As cPrMsTemplateGroup)
        Dim Ds As DataSet
        Dim i As Integer
        Dim D As New cPrMsTemplateDeductions
        Dim k As Integer
        Dim S As String

        For i = 0 To Darr.Length - 1
            Darr(i).ClearME()
        Next
        If TempGrp.Code <> "" Then
            Ds = Global1.Business.GetAllPrMsTemplateDeductions(TempGrp.Code)

            For i = 0 To Ds.Tables(0).Rows.Count - 1
                D = New cPrMsTemplateDeductions(Ds.Tables(0).Rows(i))
                For k = 0 To Darr.Length - 1
                    S = findSfor(k)
                    If S = D.Sequence Then
                        Darr(k).LoadME(D)
                    End If
                Next k
            Next
        End If
    End Sub
    Private Sub LoadContributions(ByVal TempGrp As cPrMsTemplateGroup)
        Dim Ds As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim C As New cPrMsTemplateContributions
        For i = 0 To Carr.Length - 1
            Carr(i).ClearME()
        Next
        If TempGrp.Code <> "" Then
            Ds = Global1.Business.GetAllPrMsTemplateContributions(TempGrp.Code)
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                C = New cPrMsTemplateContributions(Ds.Tables(0).Rows(i))
                For k = 0 To Carr.Length - 1
                    S = findSfor(k)
                    If s = C.Sequence Then
                        Carr(k).LoadME(C)
                    End If
                Next k
            Next
        End If
    End Sub
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        TrytoSaveGroupTemplate()
    End Sub
    Private Sub TrytoSaveGroupTemplate()
        If ValidateMe() Then
            Dim Exx As New SystemException
            Dim TempGroup As New cPrMsTemplateGroup
            TempGroup = CType(Me.ComboTemplateGroup.SelectedItem, cPrMsTemplateGroup)
            Dim E As New cPrMsTemplateEarnings
            Dim D As New cPrMsTemplateDeductions
            Dim C As New cPrMsTemplateContributions
            Dim Saved_E As New ArrayList
            Dim Saved_D As New ArrayList
            Dim Saved_C As New ArrayList

            Dim EarnCode As New cPrMsEarningCodes
            Dim DeduCode As New cPrMsDeductionCodes
            Dim ContCode As New cPrMsContributionCodes

            Dim i As Integer
            Dim k As Integer
            Global1.Business.BeginTransaction()
            Try
                Dim ds As New DataSet
                ds = Global1.Business.GetAllPrMsTemplateEarnings(TempGroup.Code)
                If CheckDataSet(ds) Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Saved_E.Add(DbNullToString(ds.Tables(0).Rows(i).Item(2)))
                    Next
                End If
                ds = Global1.Business.GetAllPrMsTemplateDeductions(TempGroup.Code)
                If CheckDataSet(ds) Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Saved_D.Add(DbNullToString(ds.Tables(0).Rows(i).Item(2)))
                    Next
                End If
                ds = Global1.Business.GetAllPrMsTemplateContributions(TempGroup.Code)
                If CheckDataSet(ds) Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Saved_C.Add(DbNullToString(ds.Tables(0).Rows(i).Item(2)))
                    Next
                End If
                'Try To Save Earnings
                For i = 0 To Earr.Length - 1
                    If Trim(Earr(i).Combo1.Text) <> "" Then
                        EarnCode = CType(Earr(i).Combo1.SelectedItem, cPrMsEarningCodes)
                        E = New cPrMsTemplateEarnings(TempGroup.Code, EarnCode.Code)
                        With E
                            .TemGrpCode = TempGroup.Code
                            .ErnCodCode = EarnCode.Code
                            .DisplayName = Earr(i).txtDisplay.Text
                            If Earr(i).CBIsDisplayed.CheckState = CheckState.Checked Then
                                .IsDispalyed = "Y"
                            Else
                                .IsDispalyed = "N"
                            End If
                            .Sequence = Earr(i).txtLabel.Text
                            .TypeMode = Earr(i).MyTypeMode
                            .FromMode = Earr(i).MyFromMode
                            .CalcFormula = UCase(Earr(i).txtFormula.Text)
                            If E.Id = 0 Then
                                .CreatedBy = Global1.GLBUserId
                                .CreationDate = Now.Date
                            End If
                            .AmendBy = Global1.GLBUserId
                            .AmendDate = Now.Date
                            .ConsolDesc = Earr(i).txtNavCreditAccount.Text
                            .NavDebitAccount = Earr(i).txtNavDebitAccount.Text
                            .reportingsequence = Earr(i).txtSeq.Text
                            If Not .Save Then
                                Throw Exx
                            End If
                           
                            Saved_E.Remove(EarnCode.Code)
                           
                        End With
                    End If
                Next
                '''''''''''''''''''''''''''''''''''''''''''''
                'Try To Save Deductions
                For i = 0 To Darr.Length - 1
                    If Trim(Darr(i).Combo1.Text) <> "" Then
                        DeduCode = CType(Darr(i).Combo1.SelectedItem, cPrMsDeductionCodes)
                        D = New cPrMsTemplateDeductions(TempGroup.Code, DeduCode.Code)
                        With D
                            .TemGrpCode = TempGroup.Code
                            .DedCodCode = DeduCode.Code
                            .DisplayName = Darr(i).txtDisplay.Text
                            If Darr(i).CBIsDisplayed.CheckState = CheckState.Checked Then
                                .IsDispalyed = "Y"
                            Else
                                .IsDispalyed = "N"
                            End If
                            .Sequence = Darr(i).txtLabel.Text
                            .TypeMode = Darr(i).MyTypeMode
                            .FromMode = Darr(i).MyFromMode
                            .CalcFormula = UCase(Darr(i).txtFormula.Text)
                            If D.Id = 0 Then
                                .CreatedBy = Global1.GLBUserId
                                .CreationDate = Now.Date
                            End If
                            .AmendBy = Global1.GLBUserId
                            .AmendDate = Now.Date
                            .ConsolDesc = Darr(i).txtNavCreditAccount.Text
                            .NavDebitAccount = Darr(i).txtNavDebitAccount.Text
                            .reportingsequence = Darr(i).txtSeq.Text
                            If Not .Save Then
                                Throw Exx
                            End If
                            Saved_D.Remove(DeduCode.Code)
                        End With
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Try To Save Contributions
                For i = 0 To Carr.Length - 1
                    If Trim(Carr(i).Combo1.Text) <> "" Then
                        ContCode = CType(Carr(i).Combo1.SelectedItem, cPrMsContributionCodes)
                        C = New cPrMsTemplateContributions(TempGroup.Code, ContCode.Code)
                        With C
                            .TemGrp_Code = TempGroup.Code
                            .ConCodCode = ContCode.Code
                            .DisplayName = Carr(i).txtDisplay.Text
                            If Carr(i).CBIsDisplayed.CheckState = CheckState.Checked Then
                                .IsDispalyed = "Y"
                            Else
                                .IsDispalyed = "N"
                            End If
                            .Sequence = Carr(i).txtLabel.Text
                            .TypeMode = Carr(i).MyTypeMode
                            .FromMode = Carr(i).MyFromMode
                            .CalcFormula = UCase(Carr(i).txtFormula.Text)
                            If C.Id = 0 Then
                                .CreatedBy = Global1.GLBUserId
                                .CreationDate = Now.Date
                            End If
                            .AmendBy = Global1.GLBUserId
                            .AmendDate = Now.Date
                            .ConsolDesc = Carr(i).txtNavCreditAccount.Text
                            .NavDebitAccount = Carr(i).txtNavDebitAccount.Text
                            .reportingsequence = Carr(i).txtSeq.Text
                            If Not .Save Then
                                Throw Exx
                            End If
                            Saved_C.Remove(ContCode.Code)
                        End With
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''
                For i = 0 To Saved_E.Count - 1
                    Global1.Business.DeleteEarnigsFromTemplateEarnings(TempGroup.Code, Saved_E.Item(i))
                    Global1.Business.DeleteEarnigsFromEmployeeEarnings(TempGroup.Code, Saved_E.Item(i))
                    Global1.Business.DeleteEarnigsFromInterfaceEarnings(TempGroup.Code, Saved_E.Item(i))

                Next
                For i = 0 To Saved_D.Count - 1
                    Global1.Business.DeleteDeductionsFromTemplateDeductions(TempGroup.Code, Saved_D.Item(i))
                    Global1.Business.DeleteDeductionsFromEmployeeDeductions(TempGroup.Code, Saved_D.Item(i))
                    Global1.Business.DeleteDeductionsFromInterfaceDeductions(TempGroup.Code, Saved_D.Item(i))

                Next
                For i = 0 To Saved_C.Count - 1
                    Global1.Business.DeleteContributionsFromTemplateContributions(TempGroup.Code, Saved_C.Item(i))
                    Global1.Business.DeleteContributionsFromEmployeeContributions(TempGroup.Code, Saved_C.Item(i))
                    Global1.Business.DeleteContributionsFromInterfaceContributions(TempGroup.Code, Saved_C.Item(i))
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''
                Global1.Business.CommitTransaction()
                MsgBox("Changes are succesfully saved", MsgBoxStyle.Information)
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Failed to Save Changes!", MsgBoxStyle.Critical)
            End Try
        Else
            MsgBox("Unable to Save, Please correct any Errors", MsgBoxStyle.Critical)
        End If


    End Sub
   
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim l As Integer = 0
        Dim S As String = ""
        Dim Found As Boolean = False
        Dim Code As String
        Dim ECode As String
        Dim DCode As String
        Dim CCode As String
        Dim Text1 As String
        Dim DoubleUseFlag As Boolean

        If Trim(Me.ComboTemplateGroup.Text) = "" Then
            Er1.SetError(Me.ComboTemplateGroup, "Please sellect Valid Template Group Code")
            Flag = False

        End If
        '------------------------------------------
        'Validate Earnings Double Use
        '------------------------------------------
        For i = 0 To Earr.Length - 1
            If Trim(Earr(i).Combo1.Text) <> "" Then
                ECode = Trim(Earr(i).Combo1.Text)
                For k = i + 1 To Earr.Length - 1
                    If ECode = Trim(Earr(k).Combo1.Text) Then
                        Earr(k).SetError(ECode & " is Already Used ")
                        DoubleUseFlag = True
                    End If
                Next
            End If
        Next
        '------------------------------------------
        'Validate Deductions Double Use
        '------------------------------------------
        For i = 0 To Darr.Length - 1
            If Trim(Darr(i).Combo1.Text) <> "" Then
                DCode = Trim(Darr(i).Combo1.Text)
                For k = i + 1 To Darr.Length - 1
                    If DCode = Trim(Darr(k).Combo1.Text) Then
                        Darr(k).SetError(DCode & " is Already Used ")
                        DoubleUseFlag = True
                    End If
                Next
            End If
        Next
        '------------------------------------------
        'Validate Contributions Double Use
        '------------------------------------------
        For i = 0 To Carr.Length - 1
            If Trim(Carr(i).Combo1.Text) <> "" Then
                CCode = Trim(Carr(i).Combo1.Text)
                For k = i + 1 To Carr.Length - 1
                    If CCode = Trim(Carr(k).Combo1.Text) Then
                        Carr(k).SetError(CCode & " is Already Used ")
                        DoubleUseFlag = True
                    End If
                Next
            End If
        Next
        If Not DoubleUseFlag Then
            '------------------------------------------
            'Validate Earnings
            '------------------------------------------
            For i = 0 To Earr.Length - 1
                If Trim(Earr(i).Combo1.Text) <> "" Then
                    If Trim(Earr(i).txtFormula.Text) <> "" Then
                        S = Trim(Earr(i).txtFormula.Text)
                        For l = 0 To S.Length - 1
                            Code = UCase(S.Substring(l, 1))
                            Found = False
                            Text1 = ""
                            For k = 0 To Earr.Length - 1
                                If Code = Earr(k).txtLabel.Text Then
                                    Found = True
                                    If k = i Then
                                        Text1 = "Earning " & Earr(k).txtLabel.Text & " Cannot be Use to Calculate its self"
                                    End If
                                    If Trim(Earr(k).Combo1.Text) = "" Then
                                        Text1 = "Earning " & Earr(k).txtLabel.Text & " cannot be part of the calulation Formula"
                                    End If
                                End If
                                If Code > Earr(i).txtLabel.Text Then
                                    Found = True
                                    Text1 = "Earning in Position " & Code & " Cannot be Use to Calculate This Earning,it belongs to Lower level calculation"
                                End If
                            Next
                            If Not Found Then
                                Earr(i).SetError("Earning with Code " & Code & " Does not exist")
                                Flag = False
                            Else
                                If Text1 <> "" Then
                                    Earr(i).SetError(Text1)
                                    Flag = False
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            '------------------------------------------
            '         Validate Deductions
            '------------------------------------------
            For i = 0 To Darr.Length - 1
                If Trim(Darr(i).Combo1.Text) <> "" Then
                    If Trim(Darr(i).txtFormula.Text) <> "" Then
                        S = Trim(Darr(i).txtFormula.Text)
                        For l = 0 To S.Length - 1
                            Code = UCase(S.Substring(l, 1))
                            Found = False
                            Text1 = ""
                            For k = 0 To Earr.Length - 1
                                If Code = Earr(k).txtLabel.Text Then
                                    Found = True
                                    If Trim(Earr(k).Combo1.Text) = "" Then
                                        Text1 = "Earning " & Earr(k).txtLabel.Text & " cannot be part of the calulation Formula"
                                    End If
                                End If
                            Next
                            If Not Found Then
                                Darr(i).SetError("Earning with Code " & Code & " Does not exist")
                                Flag = False
                            Else
                                If Text1 <> "" Then
                                    Darr(i).SetError(Text1)
                                    Flag = False
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            '------------------------------------------
            '        Validate Contributions
            '------------------------------------------
            For i = 0 To Carr.Length - 1
                If Trim(Carr(i).Combo1.Text) <> "" Then
                    If Trim(Carr(i).txtFormula.Text) <> "" Then
                        S = Trim(Carr(i).txtFormula.Text)
                        For l = 0 To S.Length - 1
                            Code = UCase(S.Substring(l, 1))
                            Found = False
                            Text1 = ""
                            For k = 0 To Earr.Length - 1
                                If Code = Earr(k).txtLabel.Text Then
                                    Found = True
                                    If Trim(Earr(k).Combo1.Text) = "" Then
                                        Text1 = "Earning " & Earr(k).txtLabel.Text & " cannot be part of the calulation Formula"
                                    End If
                                End If
                            Next
                            If Not Found Then
                                Carr(i).SetError("Earning with Code " & Code & " Does not exist")
                                Flag = False
                            Else
                                If Text1 <> "" Then
                                    Carr(i).SetError(Text1)
                                    Flag = False
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Else
            Flag = False ' Double Use Flag
        End If

        Return Flag
    End Function
    Private Sub ClearErrors()
        Dim i As Integer
        Er1.SetError(Me.ComboTemplateGroup, "")
        For i = 0 To Earr.Length - 1
            Earr(i).SetError("")
            Darr(i).SetError("")
            Carr(i).SetError("")
        Next

    End Sub
    Private Function findSfor(ByVal k As Integer) As String
        Dim S As String
        Select Case k
            Case 0
                S = "1"
            Case 1
                S = "2"
            Case 2
                S = "3"
            Case 3
                S = "4"
            Case 4
                S = "5"
            Case 5
                S = "6"
            Case 6
                S = "7"
            Case 7
                S = "8"
            Case 8
                S = "9"
            Case 9
                S = "A"
            Case 10
                S = "B"
            Case 11
                S = "C"
            Case 12
                S = "D"
            Case 13
                S = "E"
            Case 14
                S = "F"
        End Select
        Return S

    End Function

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        ' ShowExcel()
    End Sub
   
    
    Private Sub FixSequence()
        Dim i As Integer
        For i = 0 To Earr.Length - 1
            If Trim(Earr(i).Combo1.Text) <> "" Then
                Earr(i).txtSeq.Text = i + 1
            End If
        Next
        For i = 0 To Darr.Length - 1
            If Trim(Darr(i).Combo1.Text) <> "" Then
                Darr(i).txtSeq.Text = i + 1
            End If
        Next
        For i = 0 To Carr.Length - 1
            If Trim(Carr(i).Combo1.Text) <> "" Then
                Carr(i).txtSeq.Text = i + 1
            End If
        Next
    End Sub

    Private Sub BtnFixSequence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFixSequence.Click
        FixSequence()
    End Sub
End Class