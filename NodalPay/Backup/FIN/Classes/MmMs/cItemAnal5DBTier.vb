Public Class cItemAnal5DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmAn5_Code," & _
        " ItmAn5_AltCode," & _
        " ItmAn5_Desc," & _
        " ItmAn5_CreationDate," & _
        " ItmAn5_AmendDate," & _
        " ItmAn5_IsActive" & _
        " From MmAnItemAnal5" & _
        " Where ItmAn5_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemAnal5 As cItemAnal5, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemAnal5
            If Not Update Then
                Str = "INSERT INTO MmAnItemAnal5(" & _
                " ItmAn5_Code," & _
                " ItmAn5_AltCode," & _
                " ItmAn5_Desc," & _
                " ItmAn5_CreationDate," & _
                " ItmAn5_AmendDate," & _
                " ItmAn5_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                   enQuoteString(.Desc) & "," & _
                 enQuoteString(ChangeDateForSaving(.CreationDate)) & "," & _
                 enQuoteString(ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update MmAnItemAnal5" & _
                " SET ItmAn5_Code = " & enQuoteString(.Code) & _
                ",ItmAn5_AltCode = " & enQuoteString(.AltCode) & _
                ",ItmAn5_Desc = " & enQuoteString(.Desc) & _
                ",ItmAn5_CreationDate = " & enQuoteString(ChangeDateForSaving(.CreationDate)) & _
                ",ItmAn5_AmendDate = " & enQuoteString(ChangeDateForSaving(.AmendDate)) & _
                ",ItmAn5_IsActive = " & enQuoteString(.IsActive) & _
                " Where ItmAn5_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
