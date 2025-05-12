Public Class cAccountAnal6DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn6_Code," & _
        " AccAn6_DescriptionL," & _
        " AccAn6_DescriptionS," & _
        " AccAn6_CreationDate, " & _
        " AccAn6_AmendDate, " & _
        " AccAn6_IsActive " & _
        " From FiAnAccountAnal6 " & _
        " Where AccAn6_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal6 As cAccountAnal6, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal6
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal6(" & _
                " AccAn6_Code," & _
                " AccAn6_DescriptionL," & _
                " AccAn6_DescriptionS," & _
                " AccAn6_CreationDate," & _
                " AccAn6_AmendDate," & _
                " AccAn6_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal6" & _
                " SET  AccAn6_Code=" & enQuoteString(.Code) & _
                ", AccAn6_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn6_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn6_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn6_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn6_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn6_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
