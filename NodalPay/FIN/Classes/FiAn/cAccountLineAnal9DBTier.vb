Public Class cAccountLineAnal9DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn9_Code," & _
        " AcLAn9_DescriptionL," & _
        " AcLAn9_DescriptionS," & _
        " AcLAn9_CreationDate, " & _
        " AcLAn9_AmendDate, " & _
        " AcLAn9_IsActive " & _
        " From FiAnAccountLineAnal9 " & _
        " Where AcLAn9_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal9 As cAccountLineAnal9, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal9
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal9(" & _
                " AcLAn9_Code," & _
                " AcLAn9_DescriptionL," & _
                " AcLAn9_DescriptionS," & _
                " AcLAn9_CreationDate," & _
                " AcLAn9_AmendDate," & _
                " AcLAn9_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal9" & _
                " SET  AcLAn9_Code=" & enQuoteString(.Code) & _
                ", AcLAn9_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn9_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn9_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn9_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn9_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn9_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
