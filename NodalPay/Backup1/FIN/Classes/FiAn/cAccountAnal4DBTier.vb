Public Class cAccountAnal4DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn4_Code," & _
        " AccAn4_DescriptionL," & _
        " AccAn4_DescriptionS," & _
        " AccAn4_CreationDate, " & _
        " AccAn4_AmendDate, " & _
        " AccAn4_IsActive " & _
        " From FiAnAccountAnal4 " & _
        " Where AccAn4_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal4 As cAccountAnal4, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal4
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal4(" & _
                " AccAn4_Code," & _
                " AccAn4_DescriptionL," & _
                " AccAn4_DescriptionS," & _
                " AccAn4_CreationDate," & _
                " AccAn4_AmendDate," & _
                " AccAn4_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal4" & _
                " SET  AccAn4_Code=" & enQuoteString(.Code) & _
                ", AccAn4_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn4_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn4_CreationDate=" & Utils.ChangeDateForSaving(.CreationDate) & _
                ", AccAn4_AmendDate=" & Utils.ChangeDateForSaving(.AmendDate) & _
                ", AccAn4_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn4_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
