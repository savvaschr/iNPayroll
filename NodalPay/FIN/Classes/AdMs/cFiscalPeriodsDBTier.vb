Public Class cFiscalPeriodsDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As Integer) As DataSet
        Dim Str As String
        Str = "Select Prd_Code," & _
        " Prd_Year," & _
        " Prd_Number," & _
        " Prd_From," & _
        " Prd_To," & _
        " Prd_NoOfDays," & _
        " Prd_DescriptionL," & _
        " Prd_DescriptionS," & _
        " Prd_Type," & _
        " Prd_StatusFIN," & _
        " Prd_StatusMain" & _
        " From AdMsPeriods" & _
        " Where Prd_Code=" & Code
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cFiscalPeriods As cFiscalPeriods, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cFiscalPeriods
            If Not Update Then
                Str = "INSERT INTO AdMsPeriods(" & _
                "Prd_Code," & _
                "Prd_Year," & _
                "Prd_Number," & _
                "Prd_From," & _
                "Prd_To," & _
                "Prd_NoOfDays," & _
                "Prd_DescriptionL," & _
                "Prd_DescriptionS," & _
                "Prd_Type," & _
                "Prd_StatusFIN," & _
                "Prd_StatusMain)" & _
                "VALUES (" & .Code & "," & _
                 .Year & "," & _
                 .Number & "," & _
                 enQuoteString(Utils.ChangeDateForSaving(.FromDate)) & "," & _
                 enQuoteString(Utils.ChangeDateForSaving(.ToDate)) & "," & _
                 .NoOfDays & "," & _
                enQuoteString(.DescriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(.MyType) & "," & _
                enQuoteString(.StatusFin) & "," & _
                enQuoteString(.StatusMain) & ")"
            Else
                Str = "Update AdMsPeriods" & _
                " SET Prd_Year = " & .Year & _
                ",Prd_Number = " & .Number & _
                ",Prd_From = " & enQuoteString(Utils.ChangeDateForSaving(.FromDate)) & _
                ",Prd_To = " & enQuoteString(Utils.ChangeDateForSaving(.ToDate)) & _
                ",Prd_NoOfDays = " & .NoOfDays & _
                ",Prd_DescriptionL = " & enQuoteString(.DescriptionL) & _
                ",Prd_DescriptionS = " & enQuoteString(.DescriptionS) & _
                ",Prd_Type = " & enQuoteString(.MyType) & _
                ",Prd_StatusFIN = " & enQuoteString(.StatusFin) & _
                ",Prd_StatusMain = " & enQuoteString(.StatusMain) & _
                " Where Prd_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

