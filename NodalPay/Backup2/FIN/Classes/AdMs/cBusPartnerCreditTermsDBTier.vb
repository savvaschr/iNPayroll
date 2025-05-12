Public Class cBusPartnerCreditTermsDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BptTrm_Code," & _
        " BptTrm_Desc" & _
        " From AdMsBusinessPartnerCreditTerms Where BptTrm_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerCreditTerms As cBusPartnerCreditTerms, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerCreditTerms
            If Update Then
                Str = "INSERT INTO AdMsBusinessPartnerCreditTerms(" & _
                " BptTrm_Code," & _
                " BptTrm_Desc)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update AdMsBusinessPartnerCreditTerms" & _
                " SET BptTrm_Code =" & enQuoteString(.Code) & _
                ",BptTrm_Desc = " & enQuoteString(.Desc) & _
                " Where BptTrm_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
