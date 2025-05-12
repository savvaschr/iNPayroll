Public Class cCountryOfOriginDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select CoO_Code," & _
        " CoO_Desc " & _
        " From MmMsCountryOfOrigin Where CoO_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cCountryOfOrigin As cCountryOfOrigin, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cCountryOfOrigin
            If Not Update Then
                Str = "INSERT INTO MmMsCountryOfOrigin(" & _
                " CoO_Code," & _
                " CoO_Desc)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update MmMsCountryOfOrigin" & _
                " SET CoO_Code =" & enQuoteString(.Code) & _
                ",CoO_Desc = " & enQuoteString(.Desc) & _
                " Where CoO_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
   
End Class

