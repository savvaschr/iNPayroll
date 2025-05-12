Public Class cBusPartnerAccountTypeDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BptTyp_Code," & _
        " BptTyp_Desc" & _
        " From AdMsBusinessPartnerAccountType Where BptTyp_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAccountType As cBusPartnerAccountType, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAccountType
            If Update Then
                Str = "INSERT INTO AdMsBusinessPartnerAccountType(" & _
                " BptTyp_Code," & _
                " BptTyp_Desc)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update AdMsBusinessPartnerAccountType" & _
                " SET BptTyp_Code = " & enQuoteString(.Code) & _
                ",BptTyp_Desc = " & enQuoteString(.Desc) & _
                " Where BptTyp_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

