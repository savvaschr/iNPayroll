Public Class cAccountAnal3DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn3_Code," & _
        " AccAn3_DescriptionL," & _
        " AccAn3_DescriptionS," & _
        " AccAn3_CreationDate, " & _
        " AccAn3_AmendDate, " & _
        " AccAn3_IsActive " & _
        " From FiAnAccountAnal3 " & _
        " Where AccAn3_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal3 As cAccountAnal3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal3
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal3(" & _
                " AccAn3_Code," & _
                " AccAn3_DescriptionL," & _
                " AccAn3_DescriptionS," & _
                " AccAn3_CreationDate," & _
                " AccAn3_AmendDate," & _
                " AccAn3_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal3" & _
                " SET  AccAn3_Code=" & enQuoteString(.Code) & _
                ", AccAn3_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn3_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn3_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn3_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn3_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn3_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
