Public Class cTariffCodesDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select Tariff_Code," & _
        " Tariff_Desc" & _
        " From MmMsTariffCode Where Tariff_Code=" & enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cTariffCodes As cTariffCodes, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cTariffCodes
            If Not Update Then
                Str = "INSERT INTO MmMsTariffCode(" & _
                "Tariff_Code," & _
                "Tariff_Desc)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update MmMsTariffCode" & _
                " SET Tariff_Code = " & enQuoteString(.Code) & _
                ",Tariff_Desc = " & enQuoteString(.Desc) & _
                " Where Tariff_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
