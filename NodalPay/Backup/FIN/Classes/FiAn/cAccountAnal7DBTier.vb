Public Class cAccountAnal7DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn7_Code," & _
        " AccAn7_DescriptionL," & _
        " AccAn7_DescriptionS," & _
        " AccAn7_CreationDate, " & _
        " AccAn7_AmendDate, " & _
        " AccAn7_IsActive " & _
        " From FiAnAccountAnal7 " & _
        " Where AccAn7_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal7 As cAccountAnal7, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal7
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal7(" & _
                " AccAn7_Code," & _
                " AccAn7_DescriptionL," & _
                " AccAn7_DescriptionS," & _
                " AccAn7_CreationDate," & _
                " AccAn7_AmendDate," & _
                " AccAn7_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal7" & _
                " SET  AccAn7_Code=" & enQuoteString(.Code) & _
                ", AccAn7_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn7_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn7_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn7_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn7_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn7_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
