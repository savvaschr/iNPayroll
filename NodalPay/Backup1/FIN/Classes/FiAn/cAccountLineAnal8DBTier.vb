Public Class cAccountLineAnal8DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn8_Code," & _
        " AcLAn8_DescriptionL," & _
        " AcLAn8_DescriptionS," & _
        " AcLAn8_CreationDate, " & _
        " AcLAn8_AmendDate, " & _
        " AcLAn8_IsActive " & _
        " From FiAnAccountLineAnal8 " & _
        " Where AcLAn8_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal8 As cAccountLineAnal8, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal8
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal8(" & _
                " AcLAn8_Code," & _
                " AcLAn8_DescriptionL," & _
                " AcLAn8_DescriptionS," & _
                " AcLAn8_CreationDate," & _
                " AcLAn8_AmendDate," & _
                " AcLAn8_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal8" & _
                " SET  AcLAn8_Code=" & enQuoteString(.Code) & _
                ", AcLAn8_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn8_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn8_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn8_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn8_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn8_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
