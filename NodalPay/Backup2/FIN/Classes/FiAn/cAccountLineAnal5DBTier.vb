Public Class cAccountLineAnal5DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn5_Code," & _
        " AcLAn5_DescriptionL," & _
        " AcLAn5_DescriptionS," & _
        " AcLAn5_CreationDate, " & _
        " AcLAn5_AmendDate, " & _
        " AcLAn5_IsActive " & _
        " From FiAnAccountLineAnal5 " & _
        " Where AcLAn5_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal5 As cAccountLineAnal5, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal5
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal5(" & _
                " AcLAn5_Code," & _
                " AcLAn5_DescriptionL," & _
                " AcLAn5_DescriptionS," & _
                " AcLAn5_CreationDate," & _
                " AcLAn5_AmendDate," & _
                " AcLAn5_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal5" & _
                " SET  AcLAn5_Code=" & enQuoteString(.Code) & _
                ", AcLAn5_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn5_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn5_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn5_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn5_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn5_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
