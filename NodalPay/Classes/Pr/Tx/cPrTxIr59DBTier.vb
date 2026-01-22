Public Class cPrTxIr59DBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal TrxHdr_Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Pay_Id, " &
            " Trxhdr_id, " &
            " TemGrp_Code, " &
            " PrdGrp_Code, " &
            " PrdCod_Code, " &
            " Emp_Code, " &
            " Rec_GrossIncome, " &
            " Act_GrossIncome, " &
            " Rec_Discounts, " &
            " Act_Discounts,  " &
            " Rec_FirstEmployeement, " &
            " Act_FirstEmployeement,  " &
            " Rec_SalDecrease,  " &
            " Act_Saldecrease, " &
            " Rec_PenFund, " &
            " Act_PenFund, " &
            " Rec_WOFund, " &
            " Act_WOFund, " &
            " Rec_Union,  " &
            " Act_Union,  " &
            " Rec_LifeIns, " &
            " Act_LifeIns, " &
            " Rec_PF, " &
            " Act_PF, " &
            " Rec_PFLimit, " &
            " Act_PFLimit, " &
            " Rec_SI, " &
            " Act_SI,  " &
            " Rec_MF, " &
            " Act_MF, " &
            " Rec_MFLimit, " &
            " Act_MFLimit, " &
            " Rec_Total, " &
            " Act_Total,  " &
            " Rec_OneSixth, " &
            " Act_OneSixth, " &
            " Rec_Taxable, " &
            " Act_Taxable, " &
            " Rec_TotalTax, " &
            " Act_TotalTax, " &
            " Rec_PaidTax, " &
            " Act_PaidTax, " &
            " Rec_RemTax, " &
            " Act_RemTax, " &
            " Rec_RemDivTaxableP,  " &
            " Act_RemDivTaxableP, " &
            " Pay_RemTaxablePeriods, " &
            " Pay_ActualDivNormal, " &
            " Pay_Dif,  " &
            " Pay_PeriodTax, " &
            " Rec_Gesi, " &
            " Act_Gesi, " &
            " Rec_Gesi_BIK, " &
            " Act_Gesi_BIK, " &
            " Rec_Gesi_Limit, " &
            " Act_Gesi_Limit, " &
            " ARec_Current, " &
            " ARec_SI, " &
            " ARec_Other, " &
            " ARec_Previous, " &
            " ARec_Notional, " &
            " ARec_Total, " &
            " TRec_Current, " &
            " TRec_SI, " &
            " TRec_Other, " &
            " TRec_Previous, " &
            " TRec_Notional, " &
            " TRec_Total, " &
            " APer_Current, " &
            " APer_SI, " &
            " APer_Other, " &
            " APer_Previous, " &
            " APer_Notional, " &
            " APer_Total, " &
            " TPer_Current, " &
            " TPer_SI, " &
            " TPer_Other, " &
            " TPer_Previous, " &
            " TPer_Notional, " &
            " TPer_Total, " &
            " New_Difference, " &
            " New_Paid, " &
            " Rec_NewPAYE, " &
            " Per_NewPAYE,  " &
            " Per_NewPeriodTax,  " &
            " Per_TotalCurSINot, " &
            " Per_NewRemaining, " &
            " Per_MethodUsed,  " &
            " ARec_Split, " &
            " TRec_Split,  " &
            " APer_Split, " &
            " TPer_Split, " &
            " Rec_sDis1, " &
            " Act_sDis1, " &
            " Rec_sDis2, " &
            " Act_sDis2, " &
            " Rec_sDis3, " &
            " Act_sDis3, " &
            " Rec_sDis4, " &
            " Act_sDis4, " &
            " Rec_NewTaxable, " &
            " Act_NewTaxable, " &
            " Rec_Limit1, " &
            " Act_Limit1 " &
            " FROM PrTxIr59 " &
            " WHERE Trxhdr_id = " & TrxHdr_Id

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal Ir59 As cPrTxIr59) As Boolean
        Dim Str As String
        Dim i As Integer
        Dim Flag As Boolean
        If Ir59.Pay_Id <> 0 Then
            With Ir59
                Str = " Update PrTxIr59 " &
                " set Trxhdr_id= " & .Trxhdr_id &
                " ,TemGrp_Code= " & enQuoteString(.TemGrp_Code) &
                " ,PrdGrp_Code= " & enQuoteString(.PrdGrp_Code) &
                " ,PrdCod_Code= " & enQuoteString(.PrdCod_Code) &
                " ,Emp_Code= " & enQuoteString(.Emp_Code) &
                " ,Rec_GrossIncome= " & .Rec_GrossIncome &
                " ,Act_GrossIncome= " & .Act_GrossIncome &
                " ,Rec_Discounts= " & .Rec_Discounts &
                " ,Act_Discounts= " & .Act_Discounts &
                " ,Rec_FirstEmployeement= " & .Rec_FirstEmployeement &
                " ,Act_FirstEmployeement= " & .Act_FirstEmployeement &
                " ,Rec_SalDecrease= " & .Rec_SalDecrease &
                " ,Act_Saldecrease= " & .Act_Saldecrease &
                " ,Rec_PenFund= " & .Rec_PenFund &
                " ,Act_PenFund= " & .Act_PenFund &
                " ,Rec_WOFund= " & .Rec_WOFund &
                " ,Act_WOFund= " & .Act_WOFund &
                " ,Rec_Union= " & .Rec_Union &
                " ,Act_Union= " & .Act_Union &
                " ,Rec_LifeIns= " & .Rec_LifeIns &
                " ,Act_LifeIns= " & .Act_LifeIns &
                " ,Rec_PF = " & .Rec_PF &
                " ,Act_PF = " & .Act_PF &
                " ,Rec_PFLimit= " & .Rec_PFLimit &
                " ,Act_PFLimit= " & .Act_PFLimit &
                " ,Rec_SI= " & .Rec_SI &
                " ,Act_SI= " & .Act_SI &
                " ,Rec_MF= " & .Rec_MF &
                " ,Act_MF= " & .Act_MF &
                " ,Rec_MFLimit= " & .Rec_MFLimit &
                " ,Act_MFLimit= " & .Act_MFLimit &
                " ,Rec_Total= " & .Rec_Total &
                " ,Act_Total= " & .Act_Total &
                " ,Rec_OneSixth= " & .Rec_OneSixth &
                " ,Act_OneSixth= " & .Act_OneSixth &
                " ,Rec_Taxable= " & .Rec_Taxable &
                " ,Act_Taxable= " & .Act_Taxable &
                " ,Rec_TotalTax= " & .Rec_TotalTax &
                " ,Act_TotalTax= " & .Act_TotalTax &
                " ,Rec_PaidTax= " & .Rec_PaidTax &
                " ,Act_PaidTax= " & .Act_PaidTax &
                " ,Rec_RemTax= " & .Rec_RemTax &
                " ,Act_RemTax= " & .Act_RemTax &
                " ,Rec_RemDivTaxableP= " & .Rec_RemDivTaxableP &
                " ,Act_RemDivTaxableP= " & .Act_RemDivTaxableP &
                " ,Pay_RemTaxablePeriods= " & .Pay_RemTaxablePeriods &
                " ,Pay_ActualDivNormal= " & .Pay_ActualDivNormal &
                " ,Pay_Dif= " & .Pay_Dif &
                " ,Pay_PeriodTax= " & .Pay_PeriodTax &
                ", Rec_Gesi= " & .Rec_Gesi &
                ", Act_Gesi= " & .Act_Gesi &
                ", Rec_Gesi_BIK = " & .Rec_Gesi_BIK &
                ", Act_Gesi_BIK = " & .Act_Gesi_BIK &
                ", Rec_Gesi_Limit = " & .Rec_Gesi_Limit &
                ", Act_Gesi_Limit = " & .Act_Gesi_Limit &
                ", ARec_Current = " & .ARec_Current &
                ", ARec_SI = " & .ARec_SI &
                ", ARec_Other = " & .ARec_Other &
                ", ARec_Previous = " & .ARec_Previous &
                ", ARec_Notional = " & .ARec_Notional &
                ", ARec_Total = " & .ARec_Total &
                ", TRec_Current = " & .TRec_Current &
                ", TRec_SI = " & .TRec_SI &
                ", TRec_Other = " & .TRec_Other &
                ", TRec_Previous = " & .TRec_Previous &
                ", TRec_Notional = " & .TRec_Notional &
                ", TRec_Total = " & .TRec_Total &
                ", APer_Current = " & .APer_Current &
                ", APer_SI = " & .APer_SI &
                ", APer_Other = " & .APer_Other &
                ", APer_Previous = " & .APer_Previous &
                ", APer_Notional = " & .APer_Notional &
                ", APer_Total = " & .APer_Total &
                ", TPer_Current = " & .TPer_Current &
                ", TPer_SI = " & .TPer_SI &
                ", TPer_Other = " & .TPer_Other &
                ", TPer_Previous = " & .TPer_Previous &
                ", TPer_Notional = " & .TPer_Notional &
                ", TPer_Total = " & .TPer_Total &
                ", New_Difference = " & .New_Difference &
                ", New_Paid = " & .New_Paid &
                ", Rec_NewPAYE = " & .Rec_NewPAYE &
                ", Per_NewPAYE  = " & .Per_NewPAYE &
                ", Per_NewPeriodTax = " & .Per_NewPeriodTax &
                ", Per_TotalCurSINot = " & .Per_TotalCurSINot &
                ", Per_NewRemaining = " & .Per_NewRemaining &
                ", Per_MethodUsed = " & enQuoteString(.Per_MethodUsed) &
                ", ARec_Split = " & .ARec_Split &
                ", TRec_Split=   " & .TRec_Split &
                ", APer_Split = " & .APer_Split &
                ", TPer_Split = " & .APer_Split &
                ", Rec_sDis1 = " & .Rec_sDis1 &
                ", Act_sDis1 = " & .Act_sDis1 &
                ", Rec_sDis2 = " & .Rec_sDis2 &
                ", Act_sDis2 = " & .Act_sDis2 &
                ", Rec_sDis3 = " & .Rec_sDis3 &
                ", Act_sDis3 = " & .Act_sDis3 &
                ", Rec_sDis4 = " & .Rec_sDis4 &
                ", Act_sDis4 = " & .Act_sDis4 &
                ", Rec_NewTaxable = " & .Rec_NewTaxable &
                ", Act_NewTaxable = " & .Rec_NewTaxable &
                ", Rec_Limit1 = " & .Rec_Limit1 &
                ", Act_Limit1 = " & .Rec_Limit1 &
                 "  WHERE Trxhdr_id = " & enQuoteString(.Trxhdr_id)


            End With
        Else
            With Ir59

                Str = " Insert Into PrTxIr59 (" &
                     " Trxhdr_id," &
                    " TemGrp_Code," &
                    " PrdGrp_Code," &
                    " PrdCod_Code," &
                    " Emp_Code," &
                    " Rec_GrossIncome," &
                    " Act_GrossIncome," &
                    " Rec_Discounts," &
                    " Act_Discounts, " &
                    " Rec_FirstEmployeement," &
                    " Act_FirstEmployeement," &
                    " Rec_SalDecrease, " &
                    " Act_Saldecrease, " &
                    " Rec_PenFund," &
                    " Act_PenFund," &
                    " Rec_WOFund, " &
                    " Act_WOFund," &
                    " Rec_Union, " &
                    " Act_Union," &
                    " Rec_LifeIns," &
                    " Act_LifeIns," &
                    " Rec_PF," &
                    " Act_PF," &
                    " Rec_PFLimit," &
                    " Act_PFLimit," &
                    " Rec_SI," &
                    " Act_SI," &
                    " Rec_MF," &
                    " Act_MF," &
                    " Rec_MFLimit," &
                    " Act_MFLimit, " &
                    " Rec_Total," &
                    " Act_Total, " &
                    " Rec_OneSixth," &
                    " Act_OneSixth," &
                    " Rec_Taxable, " &
                    " Act_Taxable," &
                    " Rec_TotalTax," &
                    " Act_TotalTax," &
                    " Rec_PaidTax," &
                    " Act_PaidTax," &
                    " Rec_RemTax," &
                    " Act_RemTax," &
                    " Rec_RemDivTaxableP, " &
                    " Act_RemDivTaxableP," &
                    " Pay_RemTaxablePeriods," &
                    " Pay_ActualDivNormal," &
                    " Pay_Dif, " &
                    " Pay_PeriodTax, " &
                    " Rec_Gesi, " &
                    " Act_Gesi,  " &
                    " Rec_Gesi_BIK, " &
                    " Act_Gesi_BIK,  " &
                    " Rec_Gesi_Limit, " &
                    " Act_Gesi_Limit,  " &
                    " ARec_Current,  " &
                    " ARec_SI,  " &
                    " ARec_Other,  " &
                    " ARec_Previous,  " &
                    " ARec_Notional,  " &
                    " ARec_Total,  " &
                    " TRec_Current,  " &
                    " TRec_SI,  " &
                    " TRec_Other,  " &
                    " TRec_Previous,  " &
                    " TRec_Notional,  " &
                    " TRec_Total,  " &
                    " APer_Current,  " &
                    " APer_SI,  " &
                    " APer_Other,  " &
                    " APer_Previous,  " &
                    " APer_Notional,  " &
                    " APer_Total,  " &
                    " TPer_Current,  " &
                    " TPer_SI,  " &
                    " TPer_Other,  " &
                    " TPer_Previous,  " &
                    " TPer_Notional,  " &
                    " TPer_Total,  " &
                    " New_Difference,  " &
                    " New_Paid,  " &
                    " Rec_NewPAYE,  " &
                    " Per_NewPAYE,   " &
                    " Per_NewPeriodTax, " &
                    " Per_TotalCurSINot," &
                    " Per_NewRemaining, " &
                    " Per_MethodUsed,  " &
                    " ARec_Split, " &
                    " TRec_Split, " &
                    " APer_Split, " &
                    " TPer_Split, " &
                    " Rec_sDis1, " &
                    " Act_sDis1, " &
                    " Rec_sDis2, " &
                    " Act_sDis2, " &
                    " Rec_sDis3, " &
                    " Act_sDis3, " &
                    " Rec_sDis4, " &
                    " Act_sDis4, " &
                    " Rec_NewTaxable, " &
                    " Act_NewTaxable, " &
                    " Rec_Limit1, " &
                    " Act_Limit1 " &
                    " )" &
                    " Values (" & .Trxhdr_id & "," &
                    enQuoteString(.TemGrp_Code) & "," &
                    enQuoteString(.PrdGrp_Code) & "," &
                    enQuoteString(.PrdCod_Code) & "," &
                    enQuoteString(.Emp_Code) & "," &
                    .Rec_GrossIncome & "," &
                    .Act_GrossIncome & "," &
                    .Rec_Discounts & "," &
                    .Act_Discounts & "," &
                    .Rec_FirstEmployeement & "," &
                    .Act_FirstEmployeement & "," &
                    .Rec_SalDecrease & "," &
                    .Act_Saldecrease & "," &
                    .Rec_PenFund & "," &
                    .Act_PenFund & "," &
                    .Rec_WOFund & "," &
                    .Act_WOFund & "," &
                    .Rec_Union & "," &
                    .Act_Union & "," &
                    .Rec_LifeIns & "," &
                    .Act_LifeIns & "," &
                    .Rec_PF & "," &
                    .Act_PF & "," &
                    .Rec_PFLimit & "," &
                    .Act_PFLimit & "," &
                    .Rec_SI & "," &
                    .Act_SI & "," &
                    .Rec_MF & "," &
                    .Act_MF & "," &
                    .Rec_MFLimit & "," &
                    .Act_MFLimit & "," &
                    .Rec_Total & "," &
                    .Act_Total & "," &
                    .Rec_OneSixth & "," &
                    .Act_OneSixth & "," &
                    .Rec_Taxable & "," &
                    .Act_Taxable & "," &
                    .Rec_TotalTax & "," &
                    .Act_TotalTax & "," &
                    .Rec_PaidTax & "," &
                    .Act_PaidTax & "," &
                    .Rec_RemTax & "," &
                    .Act_RemTax & "," &
                    .Rec_RemDivTaxableP & "," &
                    .Act_RemDivTaxableP & "," &
                    .Pay_RemTaxablePeriods & "," &
                    .Pay_ActualDivNormal & "," &
                    .Pay_Dif & "," &
                    .Pay_PeriodTax & "," &
                    .Rec_Gesi & "," &
                    .Act_Gesi & "," &
                    .Rec_Gesi_BIK & "," &
                    .Act_Gesi_BIK & "," &
                    .Rec_Gesi_Limit & "," &
                    .Act_Gesi_Limit & "," &
                    .ARec_Current & "," &
                    .ARec_SI & "," &
                    .ARec_Other & "," &
                    .ARec_Previous & "," &
                    .ARec_Notional & "," &
                    .ARec_Total & "," &
                    .TRec_Current & "," &
                    .TRec_SI & "," &
                    .TRec_Other & "," &
                    .TRec_Previous & "," &
                    .TRec_Notional & "," &
                    .TRec_Total & "," &
                    .APer_Current & "," &
                    .APer_SI & "," &
                    .APer_Other & "," &
                    .APer_Previous & "," &
                    .APer_Notional & "," &
                    .APer_Total & "," &
                    .TPer_Current & "," &
                    .TPer_SI & "," &
                    .TPer_Other & "," &
                    .TPer_Previous & "," &
                    .TPer_Notional & "," &
                    .TPer_Total & "," &
                    .New_Difference & "," &
                    .New_Paid & "," &
                    .Rec_NewPAYE & "," &
                    .Per_NewPAYE & "," &
                    .Per_NewPeriodTax & "," &
                    .Per_TotalCurSINot & "," &
                    .Per_NewRemaining & "," &
                    enQuoteString(.Per_MethodUsed) & "," &
                    .ARec_Split & "," &
                    .TRec_Split & "," &
                    .APer_Split & "," &
                    .TPer_Split & "," &
                    .Rec_sDis1 & "," &
                     .Act_sDis1 & "," &
                     .Rec_sDis2 & "," &
                     .Act_sDis2 & "," &
                     .Rec_sDis3 & "," &
                     .Act_sDis3 & "," &
                     .Rec_sDis4 & "," &
                     .Act_sDis4 & "," &
                     .Rec_NewTaxable & "," &
                     .Act_NewTaxable & "," &
                     .Rec_Limit1 & "," &
                     .Act_Limit1 & ")"


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
