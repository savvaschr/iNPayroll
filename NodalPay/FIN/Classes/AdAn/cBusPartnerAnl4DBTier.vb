Public Class cBusPartnerAnl4DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BPaAn4_Code," & _
        " BPaAn4_AltCode," & _
        " BPaAn4_Desc," & _
        " BPaAn4_CreationDate," & _
        " BPaAn4_AmendDate," & _
        " BPaAn4_IsActive" & _
        " From AdAnBusPartnerAnal4 Where BPaAn4_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAnl4 As cBusPartnerAnl4, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAnl4
            If Update Then
                Str = "INSERT INTO AdAnBusPartnerAnal4(" & _
                "BPaAn4_Code," & _
                "BPaAn4_AltCode," & _
                "BPaA24_Code," & _
                "BPaAn4_Desc," & _
                "BPaAn4_CreationDate," & _
                "BPaAn4_AmendDate," & _
                "BPaAn4_IsActive)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdAnBusPartnerAnal4" & _
                " SET BPaAn4_Code = " & enQuoteString(.Code) & _
                ",BPaAn4_AltCode = " & enQuoteString(.AltCode) & _
                ",BPaAn4_Desc = " & enQuoteString(.Desc) & _
                ",BPaAn4_CreationDate = " & enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & _
                ",BPaAn4_AmendDate = " & enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & _
                ",BPaAn4_IsActive = " & enQuoteString(.IsActive) & _
                " Where BPaAn4_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
