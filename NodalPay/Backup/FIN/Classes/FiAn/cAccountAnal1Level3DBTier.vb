Public Class cAccountAnal1Level3DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccA31_Code," & _
        " AccA31_DescriptionL," & _
        " AccA31_DescriptionS," & _
        " AccA31_CreationDate, " & _
        " AccA31_AmendDate, " & _
        " AccA31_IsActive " & _
        " From FiAnAccountAnal1Level3 " & _
        " Where Acca31_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal1Level3 As cAccountAnal1Level3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal1Level3
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal1Level3(" & _
                " AccA31_Code," & _
                " AccA31_DescriptionL," & _
                " AccA31_DescriptionS," & _
                " AccA31_CreationDate," & _
                " AccA31_AmendDate," & _
                " AccA31_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal1Level3" & _
                " SET  AccA31_Code=" & enQuoteString(.Code) & _
                ", AccA31_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccA31_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccA31_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccA31_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccA31_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccA31_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
