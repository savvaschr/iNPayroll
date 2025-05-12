Public Class cItemStatusDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select ItmSta_Code," & _
        " ItmSta_Desc " & _
        " From MmMsItemStatus Where ItmSta_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItemStatus As cItemStatus, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cItemStatus
            If Not Update Then
                Str = "INSERT INTO MmMsItemStatus(" & _
                "ItmSta_Code," & _
                "ItmSta_Desc)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update MmMsItemStatus" & _
                " SET ItmSta_Code = " & enQuoteString(.Code) & _
                ",ItmSta_Desc = " & enQuoteString(.Desc) & _
                " Where ItmSta_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
   
End Class

