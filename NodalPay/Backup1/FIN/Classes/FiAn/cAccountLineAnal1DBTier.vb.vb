Public Class cAccountLineAnal1DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn1_Code," & _
        " AcLA21_Code," & _
        " AcLAn1_DescriptionL," & _
        " AcLAn1_DescriptionS," & _
        " AcLAn1_CreationDate, " & _
        " AcLAn1_AmendDate, " & _
        " AcLAn1_IsActive " & _
        " From FiAnAccountLineAnal1 " & _
        " Where AcLAn1_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal1 As cAccountLineAnal1, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal1
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal1(" & _
                " AcLAn1_Code," & _
                " AcLA21_Code," & _
                " AcLAn1_DescriptionL," & _
                " AcLAn1_DescriptionS," & _
                " AcLAn1_CreationDate," & _
                " AcLAn1_AmendDate," & _
                " AcLAn1_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Code2) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal1" & _
                " SET  AcLAn1_Code=" & enQuoteString(.Code) & _
                ", AcLA21_Code =" & enQuoteString(.Code2) & _
                ", AcLAn1_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn1_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn1_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn1_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn1_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn1_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
