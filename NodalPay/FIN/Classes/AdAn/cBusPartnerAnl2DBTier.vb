Public Class cBusPartnerAnl2DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BPaAn2_Code," & _
        " BPaAn2_AltCode," & _
        " BPaAn2_Desc," & _
        " BPaAn2_CreationDate," & _
        " BPaAn2_AmendDate," & _
        " BPaAn2_IsActive" & _
        " From AdAnBusPartnerAnal2 Where BPaAn2_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAnl2 As cBusPartnerAnl2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAnl2
            If Update Then
                Str = "INSERT INTO AdAnBusPartnerAnal2(" & _
                "BPaAn2_Code," & _
                "BPaAn2_AltCode," & _
                "BPaA22_Code," & _
                "BPaAn2_Desc," & _
                "BPaAn2_CreationDate," & _
                "BPaAn2_AmendDate," & _
                "BPaAn2_IsActive)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdAnBusPartnerAnal2" & _
                " SET BPaAn2_Code = " & enQuoteString(.Code) & _
                ",BPaAn2_AltCode = " & enQuoteString(.AltCode) & _
                ",BPaAn2_Desc = " & enQuoteString(.Desc) & _
                ",BPaAn2_CreationDate = " & enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & _
                ",BPaAn2_AmendDate = " & enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & _
                ",BPaAn2_IsActive = " & enQuoteString(.IsActive) & _
                " Where BPaAn2_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
