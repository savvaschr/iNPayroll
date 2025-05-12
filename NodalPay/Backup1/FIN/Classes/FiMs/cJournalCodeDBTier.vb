Public Class cJournalCodeDBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select  JouCod_code ," & _
        " JouCod_Desc," & _
        " JouTyp_code," & _
        " JouCod_JouNoStart," & _
        " JouCod_JouNoCurrent, " & _
        " JouCod_Length, " & _
        " JouCod_Status " & _
        " From  FiMsJournalCode" & _
        " Where  JouCod_code=" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cJournalCode As cJournalCode, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cJournalCode
            If Update Then
                Str = "INSERT INTO FiMsJournalCode(" & _
                " JouCod_code," & _
                " JouCod_Desc," & _
                " JouTyp_code," & _
                " JouCod_JouNoStart," & _
                " JouCod_JouNoCurrent, " & _
                " JouCod_Length, " & _
                " JouCod_Status )" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(.TypeCode) & "," & _
                .JouNoStart & "," & _
                .JouNoCurrent & "," & _
                .length & "," & _
                enQuoteString(.Status) & ")"
            Else
                Str = "Update FiMsJournalCode" & _
                " SET  JouCod_code=" & enQuoteString(.Code) & _
                ", JouCod_Desc= " & enQuoteString(.Desc) & _
                ", JouTyp_code=" & enQuoteString(.TypeCode) & _
                ", JouCod_JouNoStart=" & .JouNoStart & _
                ", JouCod_JouNoCurrent=" & .JouNoCurrent & _
                ", JouCod_Length=" & .length & _
                ", JouCod_Status=" & enQuoteString(.Status) & _
                " Where JouCod_code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
