Public Class cVatDBTier
    Inherits cDataTier

    Protected Function GetById(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select  Vat_Code ," & _
        " Vat_Description," & _
        " Vat_IsActive " & _
        " From AdMsVat " & _
        " Where Vat_Code =" & Utils.enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cVat As cVat, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cVat
            If Update Then
                Str = "INSERT INTO AdMsVat(" & _
                " Vat_Code," & _
                " Vat_Description," & _
                " Vat_IsActive )" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Description) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdMsVat" & _
                " SET  Vat_Code=" & enQuoteString(.Code) & _
                ", Vat_Description=" & enQuoteString(.Description) & _
                ", Vat_IsActive=" & enQuoteString(.IsActive) & _
                " Where Vat_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
