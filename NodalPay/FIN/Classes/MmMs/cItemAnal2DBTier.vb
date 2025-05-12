Public Class cItemAnal2DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmAn2_Code," & _
        " ItmAn2_AltCode," & _
        " ItmAn2_Desc," & _
        " ItmAn2_CreationDate," & _
        " ItmAn2_AmendDate," & _
        " ItmAn2_IsActive" & _
        " From MmAnItemAnal2" & _
        " Where ItmAn2_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemAnal2 As cItemAnal2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemAnal2
            If Not Update Then
                Str = "INSERT INTO MmAnItemAnal2(" & _
                " ItmAn2_Code," & _
                " ItmAn2_AltCode," & _
                " ItmAn2_Desc," & _
                " ItmAn2_CreationDate," & _
                " ItmAn2_AmendDate," & _
                " ItmAn2_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                 enQuoteString(.Desc) & "," & _
                 enQuoteString(ChangeDateForSaving(.CreationDate)) & "," & _
                 enQuoteString(ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update MmAnItemAnal2" & _
                " SET ItmAn2_Code = " & enQuoteString(.Code) & _
                ",ItmAn2_AltCode = " & enQuoteString(.AltCode) & _
                ",ItmAn2_Desc = " & enQuoteString(.Desc) & _
                ",ItmAn2_CreationDate = " & enQuoteString(ChangeDateForSaving(.CreationDate)) & _
                ",ItmAn2_AmendDate = " & enQuoteString(ChangeDateForSaving(.AmendDate)) & _
                ",ItmAn2_IsActive = " & enQuoteString(.IsActive) & _
                " Where ItmAn2_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
