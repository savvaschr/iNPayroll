Public Class cBusPartnerAnl1DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BPaAn1_Code," & _
        " BPaAn1_AltCode," & _
        " BPaA21_Code," & _
        " BPaAn1_Desc," & _
        " BPaAn1_CreationDate," & _
        " BPaAn1_AmendDate," & _
        " BPaAn1_IsActive" & _
        " From AdAnBusPartnerAnal1 Where BPaAn1_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAnl1 As cBusPartnerAnl1, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAnl1
            If Update Then
                Str = "INSERT INTO AdAnBusPartnerAnal1(" & _
                "BPaAn1_Code," & _
                "BPaAn1_AltCode," & _
                "BPaA21_Code," & _
                "BPaAn1_Desc," & _
                "BPaAn1_CreationDate," & _
                "BPaAn1_AmendDate," & _
                "BPaAn1_IsActive)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                 .A21Code & "," & _
                enQuoteString(.Desc) & "," & _
                 enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & "," & _
                 enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdAnBusPartnerAnal1" & _
                " SET BPaAn1_Code = " & enQuoteString(.Code) & _
                ",BPaAn1_AltCode = " & enQuoteString(.AltCode) & _
                ",BPaA21_Code = " & .A21Code & _
                ",BPaAn1_Desc = " & enQuoteString(.Desc) & _
                ",BPaAn1_CreationDate = " & enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & _
                ",BPaAn1_AmendDate = " & enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & _
                ",BPaAn1_IsActive = " & enQuoteString(.IsActive) & _
                " Where BPaAn1_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

