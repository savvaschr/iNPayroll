Public Class cAccountLineAnal1Level2DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLA21_Code," & _
        " AcLA31_Code," & _
        " AcLA21_DescriptionL," & _
        " AcLA21_DescriptionS," & _
        " AcLA21_CreationDate, " & _
        " AcLA21_AmendDate, " & _
        " AcLA21_IsActive " & _
        " From FiAnAccountLineAnal1Level2 " & _
        " Where AcLa21_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal1Level2 As cAccountLineAnal1Level2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal1Level2
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal1Level2(" & _
                " AcLA21_Code," & _
                " AcLA31_Code," & _
                " AcLA21_DescriptionL," & _
                " AcLA21_DescriptionS," & _
                " AcLA21_CreationDate," & _
                " AcLA21_AmendDate," & _
                " AcLA21_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Code2) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal1Level2" & _
                " SET  AcLA21_Code=" & enQuoteString(.Code) & _
                ", AcLA31_Code =" & enQuoteString(.Code2) & _
                ", AcLA21_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLA21_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLA21_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLA21_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLA21_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLA21_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
