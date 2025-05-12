Public Class cItemAnal1DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmAn1_Code," & _
        " ItmAn1_AltCode," & _
        " ItmA21_Code," & _
        " ItmAn1_Desc," & _
        " ItmAn1_CreationDate," & _
        " ItmAn1_AmendDate," & _
        " ItmAn1_IsActive" & _
        " From MmAnItemAnal1" & _
        " Where ItmAn1_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemAnal1 As cItemAnal1, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemAnal1
            If Not Update Then
                Str = "INSERT INTO MmAnItemAnal1(" & _
                " ItmAn1_Code," & _
                " ItmAn1_AltCode," & _
                " ItmA21_Code," & _
                " ItmAn1_Desc," & _
                " ItmAn1_CreationDate," & _
                " ItmAn1_AmendDate," & _
                " ItmAn1_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                 .A21Code & "," & _
                enQuoteString(.Desc) & "," & _
                 enQuoteString(ChangeDateForSaving(.CreationDate)) & "," & _
                 enQuoteString(ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update MmAnItemAnal1" & _
                " SET ItmAn1_Code = " & enQuoteString(.Code) & _
                ",ItmAn1_AltCode = " & enQuoteString(.AltCode) & _
                ",ItmA21_Code = " & .A21Code & _
                ",ItmAn1_Desc = " & enQuoteString(.Desc) & _
                ",ItmAn1_CreationDate = " & enQuoteString(ChangeDateForSaving(.CreationDate)) & _
                ",ItmAn1_AmendDate = " & enQuoteString(ChangeDateForSaving(.AmendDate)) & _
                ",ItmAn1_IsActive = " & enQuoteString(.IsActive) & _
                " Where ItmAn1_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
