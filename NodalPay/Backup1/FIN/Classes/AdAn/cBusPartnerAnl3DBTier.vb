Public Class cBusPartnerAnl3DBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BPaAn3_Code," & _
        " BPaAn3_AltCode," & _
        " BPaAn3_Desc," & _
        " BPaAn3_CreationDate," & _
        " BPaAn3_AmendDate," & _
        " BPaAn3_IsActive" & _
        " From AdAnBusPartnerAnal3 Where BPaAn3_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusPartnerAnl3 As cBusPartnerAnl3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cBusPartnerAnl3
            If Update Then
                Str = "INSERT INTO AdAnBusPartnerAnal3(" & _
                "BPaAn3_Code," & _
                "BPaAn3_AltCode," & _
                "BPaA23_Code," & _
                "BPaAn3_Desc," & _
                "BPaAn3_CreationDate," & _
                "BPaAn3_AmendDate," & _
                "BPaAn3_IsActive)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.AltCode) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update AdAnBusPartnerAnal3" & _
                " SET BPaAn3_Code = " & enQuoteString(.Code) & _
                ",BPaAn3_AltCode = " & enQuoteString(.AltCode) & _
                ",BPaAn3_Desc = " & enQuoteString(.Desc) & _
                ",BPaAn3_CreationDate = " & enQuoteString(Utils.ChangeDateFormat(.CreationDate)) & _
                ",BPaAn3_AmendDate = " & enQuoteString(Utils.ChangeDateFormat(.AmendDate)) & _
                ",BPaAn3_IsActive = " & enQuoteString(.IsActive) & _
                " Where BPaAn3_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
