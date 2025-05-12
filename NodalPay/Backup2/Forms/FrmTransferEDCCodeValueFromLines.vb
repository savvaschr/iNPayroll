Public Class FrmTransferEDCCodeValueFromLines
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
        Dim Ds As DataSet

        Dim PeriodCode As String
        If Me.CheckBox1.CheckState = CheckState.Checked Then
            PeriodCode = Period.Code
        Else
            PeriodCode = ""
        End If
        Ds = Global1.Business.GetAllTrxnHeaderForTemplateGroupForPeriodGroup(Tempgroup.Code, PerGrp.Code, PeriodCode)
        Dim Proceed As Boolean = False

        If CheckDataSet(Ds) Then
            Dim ErnFrom As New cPrMsEarningCodes()
            Dim ErnTo As New cPrMsEarningCodes()
            Dim DedFrom As New cPrMsDeductionCodes()
            Dim DedTo As New cPrMsDeductionCodes()

            Dim ConFrom As New cPrMsContributionCodes()
            Dim ConTo As New cPrMsContributionCodes()


            Dim i As Integer
            Select Case Type
                Case "E"
                    ErnFrom = New cPrMsEarningCodes(EDCFromCode)
                    ErnTo = New cPrMsEarningCodes(EDCToCode)
                    If ErnFrom.Code <> "" And ErnTo.Code <> "" Then
                        proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)

                    End If
                Case "D"
                    DedFrom = New cPrMsDeductionCodes(EDCFromCode)
                    DedTo = New cPrMsDeductionCodes(EDCToCode)
                    If DedFrom.Code <> "" And DedTo.Code <> "" Then
                        proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)
                    End If
                Case "C"
                    ConFrom = New cPrMsContributionCodes(EDCFromCode)
                    ConTo = New cPrMsContributionCodes(EDCToCode)
                    If ConFrom.Code <> "" And ConTo.Code <> "" Then
                        proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)
                    End If
            End Select

            If Proceed Then
                Dim Exx As New SystemException
                Try
                    Global1.Business.BeginTransaction()
                    Cursor.Current = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1

                        Application.DoEvents()


                        Dim TrxHdrID As Integer
                        TrxHdrID = DbNullToInt(Ds.Tables(0).Rows(i).Item(0))
                        Select Case Type
                            Case "E"
                                Dim trxLinFrom As New cPrTxTrxnLines(TrxHdrID, ErnFrom.Code, "E")
                                Dim trxLinTo As New cPrTxTrxnLines(TrxHdrID, ErnTo.Code, "E")
                                If trxLinTo.TrxLin_Id <> 0 And trxLinFrom.TrxLin_Id <> 0 Then
                                    trxLinTo.TrxLin_PeriodValue = trxLinTo.TrxLin_PeriodValue + trxLinFrom.TrxLin_PeriodValue
                                    trxLinTo.TrxLin_YTDValue = trxLinTo.TrxLin_YTDValue + trxLinFrom.TrxLin_YTDValue
                                    trxLinTo.TrxLin_EDC = CDbl(trxLinTo.TrxLin_EDC) + CDbl(trxLinFrom.TrxLin_EDC)
                                    If Not trxLinTo.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                    trxLinFrom.TrxLin_PeriodValue = 0
                                    trxLinFrom.TrxLin_YTDValue = 0
                                    trxLinFrom.TrxLin_EDC = 0
                                    If Not trxLinFrom.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                            Case "D"
                                Dim trxLinFrom As New cPrTxTrxnLines(TrxHdrID, DedFrom.Code, "D")
                                Dim trxLinTo As New cPrTxTrxnLines(TrxHdrID, DedTo.Code, "D")
                                If trxLinTo.TrxLin_Id <> 0 And trxLinFrom.TrxLin_Id <> 0 Then
                                    trxLinTo.TrxLin_PeriodValue = trxLinTo.TrxLin_PeriodValue + trxLinFrom.TrxLin_PeriodValue
                                    trxLinTo.TrxLin_YTDValue = trxLinTo.TrxLin_YTDValue + trxLinFrom.TrxLin_YTDValue
                                    trxLinTo.TrxLin_EDC = CDbl(trxLinTo.TrxLin_EDC) + CDbl(trxLinFrom.TrxLin_EDC)
                                    If Not trxLinTo.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                    trxLinFrom.TrxLin_PeriodValue = 0
                                    trxLinFrom.TrxLin_YTDValue = 0
                                    trxLinFrom.TrxLin_EDC = 0
                                    If Not trxLinFrom.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                            Case "C"
                                Dim trxLinFrom As New cPrTxTrxnLines(TrxHdrID, ConFrom.Code, "C")
                                Dim trxLinTo As New cPrTxTrxnLines(TrxHdrID, ConTo.Code, "C")
                                If trxLinTo.TrxLin_Id <> 0 And trxLinFrom.TrxLin_Id <> 0 Then
                                    trxLinTo.TrxLin_PeriodValue = trxLinTo.TrxLin_PeriodValue + trxLinFrom.TrxLin_PeriodValue
                                    trxLinTo.TrxLin_YTDValue = trxLinTo.TrxLin_YTDValue + trxLinFrom.TrxLin_YTDValue
                                    trxLinTo.TrxLin_EDC = CDbl(trxLinTo.TrxLin_EDC) + CDbl(trxLinFrom.TrxLin_EDC)
                                    If Not trxLinTo.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                    trxLinFrom.TrxLin_PeriodValue = 0
                                    trxLinFrom.TrxLin_YTDValue = 0
                                    trxLinFrom.TrxLin_EDC = 0
                                    If Not trxLinFrom.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                        End Select
                    Next

                    Global1.Business.CommitTransaction()
                    MsgBox("Changes are Done", MsgBoxStyle.Information)
                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(exx)
                End Try

            End If
        Else
            MsgBox("No Values Found")
        End If
        Cursor.Current = Cursors.Default
        Application.DoEvents()

    End Sub

    Private Sub FrmChangeEDCCodeFromLines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PerGrp = New cPrMsPeriodGroups(Period.PrdGrpCode)
        Me.txtPeriodGroup.Text = PerGrp.Code & " " & PerGrp.DescriptionL
        Me.txtTempGroup.Text = Tempgroup.Code & " " & Tempgroup.DescriptionL
        Me.ComboEDC.SelectedIndex = 0


    End Sub
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim EDCCode As String
        Dim Type As String

        EDCCode = Me.txtEDC.Text

        Type = Me.ComboEDC.SelectedItem.ToString
        Dim Ds As DataSet

       
        Ds = Global1.Business.GetAllTrxnHeaderForTemplateGroupForPeriodGroupForPeriod(Tempgroup.Code, PerGrp.Code, Period.Code)
        Dim Proceed As Boolean = False

        If CheckDataSet(Ds) Then
            Dim ErnCode As New cPrMsEarningCodes()
            Dim DedCode As New cPrMsDeductionCodes()
            Dim ConCode As New cPrMsContributionCodes()

            Dim i As Integer
            Select Case Type
                Case "E"
                    ErnCode = New cPrMsEarningCodes(EDCCode)
                    If ErnCode.Code <> "" Then
                        Proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)
                    End If
                Case "D"
                    DedCode = New cPrMsDeductionCodes(EDCCode)

                    If DedCode.Code <> "" Then
                        Proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)
                    End If
                Case "C"
                    ConCode = New cPrMsContributionCodes(EDCCode)

                    If ConCode.Code <> "" Then
                        Proceed = True
                    Else
                        MsgBox("Invalid EDC Codes", MsgBoxStyle.Critical)
                    End If
            End Select

            If Proceed Then
                Dim Exx As New SystemException
                Try
                    Global1.Business.BeginTransaction()
                    Cursor.Current = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Application.DoEvents()
                        Dim TrxHdrID As Integer
                        Dim EmpCode As String
                        TrxHdrID = DbNullToInt(Ds.Tables(0).Rows(i).Item(0))
                        EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(1))

                        Dim NewYTDValue As Double = 0
                        Select Case Type

                            Case "E"
                                NewYTDValue = Global1.Business.FindYTD_EDC_2(EmpCode, Period, ErnCode.Code, "E")
                                Dim trxLin As New cPrTxTrxnLines(TrxHdrID, ErnCode.Code, "E")
                                If trxLin.TrxLin_Id <> 0 Then
                                    trxLin.TrxLin_YTDValue = NewYTDValue
                                    If Not trxLin.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                            Case "D"
                                NewYTDValue = Global1.Business.FindYTD_EDC_2(EmpCode, Period, DedCode.Code, "D")
                                Dim trxLin As New cPrTxTrxnLines(TrxHdrID, DedCode.Code, "D")
                                If trxLin.TrxLin_Id <> 0 Then
                                    trxLin.TrxLin_YTDValue = NewYTDValue
                                    If Not trxLin.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                            Case "C"
                                NewYTDValue = Global1.Business.FindYTD_EDC_2(EmpCode, Period, ConCode.Code, "C")
                                Dim trxLin As New cPrTxTrxnLines(TrxHdrID, ConCode.Code, "C")
                                If trxLin.TrxLin_Id <> 0 Then
                                    trxLin.TrxLin_YTDValue = NewYTDValue
                                    If Not trxLin.UpdateMyValues() Then
                                        Throw Exx
                                    End If
                                End If
                        End Select
                    Next

                    Global1.Business.CommitTransaction()
                    MsgBox("Changes are Done", MsgBoxStyle.Information)
                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(Exx)
                End Try

            End If
        Else
            MsgBox("No Values Found")
        End If
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
End Class