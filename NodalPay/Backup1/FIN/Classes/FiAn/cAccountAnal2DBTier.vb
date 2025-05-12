Public Class cAccountAnal2DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn2_Code," & _
        " AccAn2_DescriptionL," & _
        " AccAn2_DescriptionS," & _
        " AccAn2_CreationDate, " & _
        " AccAn2_AmendDate, " & _
        " AccAn2_IsActive " & _
        " From FiAnAccountAnal2 " & _
        " Where AccAn2_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal2 As cAccountAnal2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal2
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal2(" & _
                " AccAn2_Code," & _
                " AccAn2_DescriptionL," & _
                " AccAn2_DescriptionS," & _
                " AccAn2_CreationDate," & _
                " AccAn2_AmendDate," & _
                " AccAn2_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal2" & _
                " SET  AccAn2_Code=" & enQuoteString(.Code) & _
                ", AccAn2_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn2_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn2_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn2_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn2_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn2_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
