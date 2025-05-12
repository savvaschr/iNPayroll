Public Class cAccountLineAnal6DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn6_Code," & _
        " AcLAn6_DescriptionL," & _
        " AcLAn6_DescriptionS," & _
        " AcLAn6_CreationDate, " & _
        " AcLAn6_AmendDate, " & _
        " AcLAn6_IsActive " & _
        " From FiAnAccountLineAnal6 " & _
        " Where AcLAn6_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal6 As cAccountLineAnal6, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal6
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal6(" & _
                " AcLAn6_Code," & _
                " AcLAn6_DescriptionL," & _
                " AcLAn6_DescriptionS," & _
                " AcLAn6_CreationDate," & _
                " AcLAn6_AmendDate," & _
                " AcLAn6_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal6" & _
                " SET  AcLAn6_Code=" & enQuoteString(.Code) & _
                ", AcLAn6_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn6_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn6_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn6_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn6_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn6_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
