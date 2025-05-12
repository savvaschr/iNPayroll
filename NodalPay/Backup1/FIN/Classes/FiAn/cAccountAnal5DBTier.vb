Public Class cAccountAnal5DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn5_Code," & _
        " AccAn5_DescriptionL," & _
        " AccAn5_DescriptionS," & _
        " AccAn5_CreationDate, " & _
        " AccAn5_AmendDate, " & _
        " AccAn5_IsActive " & _
        " From FiAnAccountAnal5 " & _
        " Where AccAn5_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal5 As cAccountAnal5, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal5
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal5(" & _
                " AccAn5_Code," & _
                " AccAn5_DescriptionL," & _
                " AccAn5_DescriptionS," & _
                " AccAn5_CreationDate," & _
                " AccAn5_AmendDate," & _
                " AccAn5_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal5" & _
                " SET  AccAn5_Code=" & enQuoteString(.Code) & _
                ", AccAn5_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn5_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn5_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn5_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn5_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn5_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
