Public Class cAccountAnal9DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn9_Code," & _
        " AccAn9_DescriptionL," & _
        " AccAn9_DescriptionS," & _
        " AccAn9_CreationDate, " & _
        " AccAn9_AmendDate, " & _
        " AccAn9_IsActive " & _
        " From FiAnAccountAnal9 " & _
        " Where AccAn9_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal9 As cAccountAnal9, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal9
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal9(" & _
                " AccAn9_Code," & _
                " AccAn9_DescriptionL," & _
                " AccAn9_DescriptionS," & _
                " AccAn9_CreationDate," & _
                " AccAn9_AmendDate," & _
                " AccAn9_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal9" & _
                " SET  AccAn9_Code=" & enQuoteString(.Code) & _
                ", AccAn9_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn9_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn9_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn9_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn9_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn9_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
