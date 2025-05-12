Public Class cBusPartnerAnl5DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BPaAn5_Code," & _
        " BPaAn5_AltCode," & _
        " BPaAn5_Desc," & _
        " BPaAn5_CreationDate," & _
        " BPaAn5_AmendDate," & _
        " BPaAn5_IsActive" & _
        " From AdAnBusPartnerAnal5 Where BPaAn5_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAnl5 As cBusPartnerAnl5, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAnl5
            If Update Then
                Str = "INSERT INTO AdAnBusPartnerAnal5(" & _
                "BPaAn5_Code," & _
                "BPaAn5_AltCode," & _
                "BPaAn5_Desc," & _
                "BPaAn5_CreationDate," & _
                "BPaAn5_AmendDate," & _
                "BPaAn5_IsActive)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdAnBusPartnerAnal5" & _
                " SET BPaAn5_Code = " & enQuoteString(.Code) & _
                ",BPaAn5_AltCode = " & enQuoteString(.AltCode) & _
                ",BPaAn5_Desc = " & enQuoteString(.Desc) & _
                ",BPaAn5_CreationDate = " & enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & _
                ",BPaAn5_AmendDate = " & enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & _
                ",BPaAn5_IsActive = " & enQuoteString(.IsActive) & _
                " Where BPaAn5_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
