Public Class cAccountLineAnal2DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn2_Code," & _
        " AcLAn2_DescriptionL," & _
        " AcLAn2_DescriptionS," & _
        " AcLAn2_CreationDate, " & _
        " AcLAn2_AmendDate, " & _
        " AcLAn2_IsActive " & _
        " From FiAnAccountLineAnal2 " & _
        " Where AcLAn2_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal2 As cAccountLineAnal2, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal2
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal2(" & _
                " AcLAn2_Code," & _
                " AcLAn2_DescriptionL," & _
                " AcLAn2_DescriptionS," & _
                " AcLAn2_CreationDate," & _
                " AcLAn2_AmendDate," & _
                " AcLAn2_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal2" & _
                " SET  AcLAn2_Code=" & enQuoteString(.Code) & _
                ", AcLAn2_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn2_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn2_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn2_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn2_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn2_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
