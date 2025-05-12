Public Class cBusPartnerStatusDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BptSta_Code," & _
        " BptSta_Desc " & _
        " From AdMsBusinessPartnerStatus Where BptSta_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerStatus As cBusPartnerStatus, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerStatus
            If update Then
                Str = "INSERT INTO AdMsBusinessPartnerStatus(" & _
                " BptSta_Code," & _
                " BptSta_Desc)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & ")"
            Else
                Str = "Update AdMsBusinessPartnerStatus" & _
                " SET BptSta_Code =" & enQuoteString(.Code) & _
                ",BptSta_Desc = " & enQuoteString(.Desc) & _
                " Where BptSta_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

