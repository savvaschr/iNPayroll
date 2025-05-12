Public Class cAccountAnal1Level2DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccA21_Code," & _
        " AccA31_Code," & _
        " AccA21_DescriptionL," & _
        " AccA21_DescriptionS," & _
        " AccA21_CreationDate, " & _
        " AccA21_AmendDate, " & _
        " AccA21_IsActive " & _
        " From FiAnAccountAnal1Level2 " & _
        " Where Acca21_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal1Level2 As cAccountAnal1Level2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal1Level2
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal1Level2(" & _
                " AccA21_Code," & _
                " AccA31_Code," & _
                " AccA21_DescriptionL," & _
                " AccA21_DescriptionS," & _
                " AccA21_CreationDate," & _
                " AccA21_AmendDate," & _
                " AccA21_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Code2) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal1Level2" & _
                " SET  AccA21_Code=" & enQuoteString(.Code) & _
                ", AccA31_Code =" & enQuoteString(.Code2) & _
                ", AccA21_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccA21_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccA21_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccA21_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccA21_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccA21_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
