Public Class cAccountLineAnal3DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn3_Code," & _
        " AcLAn3_DescriptionL," & _
        " AcLAn3_DescriptionS," & _
        " AcLAn3_CreationDate, " & _
        " AcLAn3_AmendDate, " & _
        " AcLAn3_IsActive " & _
        " From FiAnAccountLineAnal3 " & _
        " Where AcLAn3_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal3 As cAccountLineAnal3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal3
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal3(" & _
                " AcLAn3_Code," & _
                " AcLAn3_DescriptionL," & _
                " AcLAn3_DescriptionS," & _
                " AcLAn3_CreationDate," & _
                " AcLAn3_AmendDate," & _
                " AcLAn3_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal3" & _
                " SET  AcLAn3_Code=" & enQuoteString(.Code) & _
                ", AcLAn3_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn3_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn3_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn3_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn3_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn3_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
