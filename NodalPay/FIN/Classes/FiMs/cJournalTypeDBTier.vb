Public Class cJournalTypeDBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select  JouTyp_Code ," & _
        " JouTyp_Desc," & _
        " JouTyp_Status " & _
        " From FiMsJournalType " & _
        " Where JouTyp_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cJournalType As cJournalType, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cJournalType
            If Update Then
                Str = "INSERT INTO FiMsJournalType(" & _
                " JouTyp_Code," & _
                " JouTyp_Desc," & _
                " JouTyp_Status )" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(.Status) & ")"
            Else
                Str = "Update FiMsJournalType" & _
                " SET  JouTyp_Code=" & enQuoteString(.Code) & _
                ", JouTyp_Desc=" & enQuoteString(.Desc) & _
                ", JouTyp_Status=" & enQuoteString(.Status) & _
                " Where JouTyp_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
