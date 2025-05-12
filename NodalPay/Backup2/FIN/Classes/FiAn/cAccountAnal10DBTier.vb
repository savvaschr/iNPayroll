Public Class cAccountAnal10DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AccAn10_Code," & _
        " AccAn10_DescriptionL," & _
        " AccAn10_DescriptionS," & _
        " AccAn10_CreationDate, " & _
        " AccAn10_AmendDate, " & _
        " AccAn10_IsActive " & _
        " From FiAnAccountAnal10 " & _
        " Where AccAn10_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountAnal10 As cAccountAnal10, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountAnal10
            If Update Then
                Str = "INSERT INTO FiAnAccountAnal10(" & _
                " AccAn10_Code," & _
                " AccAn10_DescriptionL," & _
                " AccAn10_DescriptionS," & _
                " AccAn10_CreationDate," & _
                " AccAn10_AmendDate," & _
                " AccAn10_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountAnal10" & _
                " SET  AccAn10_Code=" & enQuoteString(.Code) & _
                ", AccAn10_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AccAn10_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AccAn10_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AccAn10_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AccAn10_IsActive=" & enQuoteString(.IsActive) & _
                " Where AccAn10_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
