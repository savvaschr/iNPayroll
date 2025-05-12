Public Class cAccountAnal1DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn1_Code," & _
        " AccA21_Code," & _
        " AccAn1_DescriptionL," & _
        " AccAn1_DescriptionS," & _
        " AccAn1_CreationDate, " & _
        " AccAn1_AmendDate, " & _
        " AccAn1_IsActive " & _
        " From FiAnAccountAnal1 " & _
        " Where AccAn1_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal1 As cAccountAnal1, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal1
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal1(" & _
                " AccAn1_Code," & _
                " AccA21_Code," & _
                " AccAn1_DescriptionL," & _
                " AccAn1_DescriptionS," & _
                " AccAn1_CreationDate," & _
                " AccAn1_AmendDate," & _
                " AccAn1_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Code2) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal1" & _
                " SET  AccAn1_Code=" & enQuoteString(.Code) & _
                ", AccA21_Code =" & enQuoteString(.Code2) & _
                ", AccAn1_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn1_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn1_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn1_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn1_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn1_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
