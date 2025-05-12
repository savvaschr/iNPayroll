Public Class cPrTxIr59DBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal TrxHdr_Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Pay_Id, " & _
            " Trxhdr_id, " & _
            " TemGrp_Code, " & _
            " PrdGrp_Code, " & _
            " PrdCod_Code, " & _
            " Emp_Code, " & _
            " Rec_GrossIncome, " & _
            " Act_GrossIncome, " & _
            " Rec_Discounts, " & _
            " Act_Discounts,  " & _
            " Rec_FirstEmployeement, " & _
            " Act_FirstEmployeement,  " & _
            " Rec_SalDecrease,  " & _
            " Act_Saldecrease, " & _
            " Rec_PenFund, " & _
            " Act_PenFund, " & _
            " Rec_WOFund, " & _
            " Act_WOFund, " & _
            " Rec_Union,  " & _
            " Act_Union,  " & _
            " Rec_LifeIns, " & _
            " Act_LifeIns, " & _
            " Rec_PF, " & _
            " Act_PF, " & _
            " Rec_PFLimit, " & _
            " Act_PFLimit, " & _
            " Rec_SI, " & _
            " Act_SI,  " & _
            " Rec_MF, " & _
            " Act_MF, " & _
            " Rec_MFLimit, " & _
            " Act_MFLimit, " & _
            " Rec_Total, " & _
            " Act_Total,  " & _
            " Rec_OneSixth, " & _
            " Act_OneSixth, " & _
            " Rec_Taxable, " & _
            " Act_Taxable, " & _
            " Rec_TotalTax, " & _
            " Act_TotalTax, " & _
            " Rec_PaidTax, " & _
            " Act_PaidTax, " & _
            " Rec_RemTax, " & _
            " Act_RemTax, " & _
            " Rec_RemDivTaxableP,  " & _
            " Act_RemDivTaxableP, " & _
            " Pay_RemTaxablePeriods, " & _
            " Pay_ActualDivNormal, " & _
            " Pay_Dif,  " & _
            " Pay_PeriodTax, " & _
            " Rec_Gesi, " & _
            " Act_Gesi, " & _
            " Rec_Gesi_BIK, " & _
            " Act_Gesi_BIK, " & _
            " Rec_Gesi_Limit, " & _
            " Act_Gesi_Limit " & _
            " FROM PrTxIr59 " & _
            " WHERE Trxhdr_id = " & TrxHdr_Id

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal Ir59 As cPrTxIr59) As Boolean
        Dim Str As String
        Dim i As Integer
        Dim Flag As Boolean
        If Ir59.Pay_Id <> 0 Then
            With Ir59
                Str = " Update PrTxIr59 " & _
                " set Trxhdr_id= " & .Trxhdr_id & _
                " ,TemGrp_Code= " & enQuoteString(.TemGrp_Code) & _
                " ,PrdGrp_Code= " & enQuoteString(.PrdGrp_Code) & _
                " ,PrdCod_Code= " & enQuoteString(.PrdCod_Code) & _
                " ,Emp_Code= " & enQuoteString(.Emp_Code) & _
                " ,Rec_GrossIncome= " & .Rec_GrossIncome & _
                " ,Act_GrossIncome= " & .Act_GrossIncome & _
                " ,Rec_Discounts= " & .Rec_Discounts & _
                " ,Act_Discounts= " & .Act_Discounts & _
                " ,Rec_FirstEmployeement= " & .Rec_FirstEmployeement & _
                " ,Act_FirstEmployeement= " & .Act_FirstEmployeement & _
                " ,Rec_SalDecrease= " & .Rec_SalDecrease & _
                " ,Act_Saldecrease= " & .Act_Saldecrease & _
                " ,Rec_PenFund= " & .Rec_PenFund & _
                " ,Act_PenFund= " & .Act_PenFund & _
                " ,Rec_WOFund= " & .Rec_WOFund & _
                " ,Act_WOFund= " & .Act_WOFund & _
                " ,Rec_Union= " & .Rec_Union & _
                " ,Act_Union= " & .Act_Union & _
                " ,Rec_LifeIns= " & .Rec_LifeIns & _
                " ,Act_LifeIns= " & .Act_LifeIns & _
                " ,Rec_PF = " & .Rec_PF & _
                " ,Act_PF = " & .Act_PF & _
                " ,Rec_PFLimit= " & .Rec_PFLimit & _
                " ,Act_PFLimit= " & .Act_PFLimit & _
                " ,Rec_SI= " & .Rec_SI & _
                " ,Act_SI= " & .Act_SI & _
                " ,Rec_MF= " & .Rec_MF & _
                " ,Act_MF= " & .Act_MF & _
                " ,Rec_MFLimit= " & .Rec_MFLimit & _
                " ,Act_MFLimit= " & .Act_MFLimit & _
                " ,Rec_Total= " & .Rec_Total & _
                " ,Act_Total= " & .Act_Total & _
                " ,Rec_OneSixth= " & .Rec_OneSixth & _
                " ,Act_OneSixth= " & .Act_OneSixth & _
                " ,Rec_Taxable= " & .Rec_Taxable & _
                " ,Act_Taxable= " & .Act_Taxable & _
                " ,Rec_TotalTax= " & .Rec_TotalTax & _
                " ,Act_TotalTax= " & .Act_TotalTax & _
                " ,Rec_PaidTax= " & .Rec_PaidTax & _
                " ,Act_PaidTax= " & .Act_PaidTax & _
                " ,Rec_RemTax= " & .Rec_RemTax & _
                " ,Act_RemTax= " & .Act_RemTax & _
                " ,Rec_RemDivTaxableP= " & .Rec_RemDivTaxableP & _
                " ,Act_RemDivTaxableP= " & .Act_RemDivTaxableP & _
                " ,Pay_RemTaxablePeriods= " & .Pay_RemTaxablePeriods & _
                " ,Pay_ActualDivNormal= " & .Pay_ActualDivNormal & _
                " ,Pay_Dif= " & .Pay_Dif & _
                " ,Pay_PeriodTax= " & .Pay_PeriodTax & _
                ", Rec_Gesi= " & .Rec_Gesi & _
                ", Act_Gesi= " & .Act_Gesi & _
                ", Rec_Gesi_BIK = " & .Rec_Gesi_BIK & _
                ", Act_Gesi_BIK = " & .Act_Gesi_BIK & _
                ", Rec_Gesi_Limit = " & .Rec_Gesi_Limit & _
                ", Act_Gesi_Limit = " & .Act_Gesi_Limit & _
                "  WHERE Trxhdr_id = " & enQuoteString(.Trxhdr_id)

            End With
        Else
            With Ir59

                Str = " Insert Into PrTxIr59 (" & _
                     " Trxhdr_id," & _
                    " TemGrp_Code," & _
                    " PrdGrp_Code," & _
                    " PrdCod_Code," & _
                    " Emp_Code," & _
                    " Rec_GrossIncome," & _
                    " Act_GrossIncome," & _
                    " Rec_Discounts," & _
                    " Act_Discounts, " & _
                    " Rec_FirstEmployeement," & _
                    " Act_FirstEmployeement," & _
                    " Rec_SalDecrease, " & _
                    " Act_Saldecrease, " & _
                    " Rec_PenFund," & _
                    " Act_PenFund," & _
                    " Rec_WOFund, " & _
                    " Act_WOFund," & _
                    " Rec_Union, " & _
                    " Act_Union," & _
                    " Rec_LifeIns," & _
                    " Act_LifeIns," & _
                    " Rec_PF," & _
                    " Act_PF," & _
                    " Rec_PFLimit," & _
                    " Act_PFLimit," & _
                    " Rec_SI," & _
                    " Act_SI," & _
                    " Rec_MF," & _
                    " Act_MF," & _
                    " Rec_MFLimit," & _
                    " Act_MFLimit, " & _
                    " Rec_Total," & _
                    " Act_Total, " & _
                    " Rec_OneSixth," & _
                    " Act_OneSixth," & _
                    " Rec_Taxable, " & _
                    " Act_Taxable," & _
                    " Rec_TotalTax," & _
                    " Act_TotalTax," & _
                    " Rec_PaidTax," & _
                    " Act_PaidTax," & _
                    " Rec_RemTax," & _
                    " Act_RemTax," & _
                    " Rec_RemDivTaxableP, " & _
                    " Act_RemDivTaxableP," & _
                    " Pay_RemTaxablePeriods," & _
                    " Pay_ActualDivNormal," & _
                    " Pay_Dif, " & _
                    " Pay_PeriodTax, " & _
                    " Rec_Gesi, " & _
                    " Act_Gesi,  " & _
                    " Rec_Gesi_BIK, " & _
                    " Act_Gesi_BIK,  " & _
                    " Rec_Gesi_Limit, " & _
                    " Act_Gesi_Limit  " & _
                    " )" & _
                    " Values (" & .Trxhdr_id & "," & _
                    enQuoteString(.TemGrp_Code) & "," & _
                    enQuoteString(.PrdGrp_Code) & "," & _
                    enQuoteString(.PrdCod_Code) & "," & _
                    enQuoteString(.Emp_Code) & "," & _
                    .Rec_GrossIncome & "," & _
                    .Act_GrossIncome & "," & _
                    .Rec_Discounts & "," & _
                    .Act_Discounts & "," & _
                    .Rec_FirstEmployeement & "," & _
                    .Act_FirstEmployeement & "," & _
                    .Rec_SalDecrease & "," & _
                    .Act_Saldecrease & "," & _
                    .Rec_PenFund & "," & _
                    .Act_PenFund & "," & _
                    .Rec_WOFund & "," & _
                    .Act_WOFund & "," & _
                    .Rec_Union & "," & _
                    .Act_Union & "," & _
                    .Rec_LifeIns & "," & _
                    .Act_LifeIns & "," & _
                    .Rec_PF & "," & _
                    .Act_PF & "," & _
                    .Rec_PFLimit & "," & _
                    .Act_PFLimit & "," & _
                    .Rec_SI & "," & _
                    .Act_SI & "," & _
                    .Rec_MF & "," & _
                    .Act_MF & "," & _
                    .Rec_MFLimit & "," & _
                    .Act_MFLimit & "," & _
                    .Rec_Total & "," & _
                    .Act_Total & "," & _
                    .Rec_OneSixth & "," & _
                    .Act_OneSixth & "," & _
                    .Rec_Taxable & "," & _
                    .Act_Taxable & "," & _
                    .Rec_TotalTax & "," & _
                    .Act_TotalTax & "," & _
                    .Rec_PaidTax & "," & _
                    .Act_PaidTax & "," & _
                    .Rec_RemTax & "," & _
                    .Act_RemTax & "," & _
                    .Rec_RemDivTaxableP & "," & _
                    .Act_RemDivTaxableP & "," & _
                    .Pay_RemTaxablePeriods & "," & _
                    .Pay_ActualDivNormal & "," & _
                    .Pay_Dif & "," & _
                    .Pay_PeriodTax & "," & _
                    .Rec_Gesi & "," & _
                    .Act_Gesi & "," & _
                    .Rec_Gesi_BIK & "," & _
                    .Act_Gesi_BIK & "," & _
                    .Rec_Gesi_Limit & "," & _
                    .Act_Gesi_Limit & ")"
            End With
        End If

        i = ExecuteNonQuery(Str)
        If i >= 0 Then
            Flag = True
        Else
            Flag = False
        End If

        Return Flag

    End Function
End Class
