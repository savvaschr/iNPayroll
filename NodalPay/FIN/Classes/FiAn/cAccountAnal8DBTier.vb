Public Class cAccountAnal8DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn8_Code," & _
        " AccAn8_DescriptionL," & _
        " AccAn8_DescriptionS," & _
        " AccAn8_CreationDate, " & _
        " AccAn8_AmendDate, " & _
        " AccAn8_IsActive " & _
        " From FiAnAccountAnal8 " & _
        " Where AccAn8_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal8 As cAccountAnal8, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal8
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal8(" & _
                " AccAn8_Code," & _
                " AccAn8_DescriptionL," & _
                " AccAn8_DescriptionS," & _
                " AccAn8_CreationDate," & _
                " AccAn8_AmendDate," & _
                " AccAn8_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal8" & _
                " SET  AccAn8_Code=" & enQuoteString(.Code) & _
                ", AccAn8_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn8_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn8_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn8_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn8_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn8_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
