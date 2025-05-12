Public Class cAccountLineAnal7DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn7_Code," & _
        " AcLAn7_DescriptionL," & _
        " AcLAn7_DescriptionS," & _
        " AcLAn7_CreationDate, " & _
        " AcLAn7_AmendDate, " & _
        " AcLAn7_IsActive " & _
        " From FiAnAccountLineAnal7 " & _
        " Where AcLAn7_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal7 As cAccountLineAnal7, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal7
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal7(" & _
                " AcLAn7_Code," & _
                " AcLAn7_DescriptionL," & _
                " AcLAn7_DescriptionS," & _
                " AcLAn7_CreationDate," & _
                " AcLAn7_AmendDate," & _
                " AcLAn7_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal7" & _
                " SET  AcLAn7_Code=" & enQuoteString(.Code) & _
                ", AcLAn7_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn7_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn7_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn7_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn7_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn7_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
