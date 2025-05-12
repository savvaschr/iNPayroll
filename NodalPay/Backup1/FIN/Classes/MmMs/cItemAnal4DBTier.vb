Public Class cItemAnal4DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmAn4_Code," & _
        " ItmAn4_AltCode," & _
        " ItmAn4_Desc," & _
        " ItmAn4_CreationDate," & _
        " ItmAn4_AmendDate," & _
        " ItmAn4_IsActive" & _
        " From MmAnItemAnal4" & _
        " Where ItmAn4_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemAnal4 As cItemAnal4, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemAnal4
            If Not Update Then
                Str = "INSERT INTO MmAnItemAnal4(" & _
                " ItmAn4_Code," & _
                " ItmAn4_AltCode," & _
                " ItmAn4_Desc," & _
                " ItmAn4_CreationDate," & _
                " ItmAn4_AmendDate," & _
                " ItmAn4_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                 enQuoteString(.Desc) & "," & _
                 enQuoteString(ChangeDateForSaving(.CreationDate)) & "," & _
                 enQuoteString(ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update MmAnItemAnal4" & _
                " SET ItmAn4_Code = " & enQuoteString(.Code) & _
                ",ItmAn4_AltCode = " & enQuoteString(.AltCode) & _
                ",ItmAn4_Desc = " & enQuoteString(.Desc) & _
                ",ItmAn4_CreationDate = " & enQuoteString(ChangeDateForSaving(.CreationDate)) & _
                ",ItmAn4_AmendDate = " & enQuoteString(ChangeDateForSaving(.AmendDate)) & _
                ",ItmAn4_IsActive = " & enQuoteString(.IsActive) & _
                " Where ItmAn4_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
