Public Class cAccountLineAnal4DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn4_Code," & _
        " AcLAn4_DescriptionL," & _
        " AcLAn4_DescriptionS," & _
        " AcLAn4_CreationDate, " & _
        " AcLAn4_AmendDate, " & _
        " AcLAn4_IsActive " & _
        " From FiAnAccountLineAnal4 " & _
        " Where AcLAn4_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal4 As cAccountLineAnal4, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal4
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal4(" & _
                " AcLAn4_Code," & _
                " AcLAn4_DescriptionL," & _
                " AcLAn4_DescriptionS," & _
                " AcLAn4_CreationDate," & _
                " AcLAn4_AmendDate," & _
                " AcLAn4_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal4" & _
                " SET  AcLAn4_Code=" & enQuoteString(.Code) & _
                ", AcLAn4_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn4_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn4_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn4_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn4_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn4_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
