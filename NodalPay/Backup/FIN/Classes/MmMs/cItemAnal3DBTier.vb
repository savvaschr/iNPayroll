Public Class cItemAnal3DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmAn3_Code," & _
        " ItmAn3_AltCode," & _
        " ItmAn3_Desc," & _
        " ItmAn3_CreationDate," & _
        " ItmAn3_AmendDate," & _
        " ItmAn3_IsActive" & _
        " From MmAnItemAnal3" & _
        " Where ItmAn3_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemAnal3 As cItemAnal3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemAnal3
            If Not Update Then
                Str = "INSERT INTO MmAnItemAnal3(" & _
                " ItmAn3_Code," & _
                " ItmAn3_AltCode," & _
                " ItmAn3_Desc," & _
                " ItmAn3_CreationDate," & _
                " ItmAn3_AmendDate," & _
                " ItmAn3_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                  enQuoteString(.Desc) & "," & _
                 enQuoteString(ChangeDateForSaving(.CreationDate)) & "," & _
                 enQuoteString(ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update MmAnItemAnal3" & _
                " SET ItmAn3_Code = " & enQuoteString(.Code) & _
                ",ItmAn3_AltCode = " & enQuoteString(.AltCode) & _
                ",ItmAn3_Desc = " & enQuoteString(.Desc) & _
                ",ItmAn3_CreationDate = " & enQuoteString(ChangeDateForSaving(.CreationDate)) & _
                ",ItmAn3_AmendDate = " & enQuoteString(ChangeDateForSaving(.AmendDate)) & _
                ",ItmAn3_IsActive = " & enQuoteString(.IsActive) & _
                " Where ItmAn3_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
