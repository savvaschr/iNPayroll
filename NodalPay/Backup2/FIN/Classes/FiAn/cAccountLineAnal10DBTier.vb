Public Class cAccountLineAnal10DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLAn10_Code," & _
        " AcLAn10_DescriptionL," & _
        " AcLAn10_DescriptionS," & _
        " AcLAn10_CreationDate, " & _
        " AcLAn10_AmendDate, " & _
        " AcLAn10_IsActive " & _
        " From FiAnAccountLineAnal10 " & _
        " Where AcLAn10_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal10 As cAccountLineAnal10, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal10
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal10(" & _
                " AcLAn10_Code," & _
                " AcLAn10_DescriptionL," & _
                " AcLAn10_DescriptionS," & _
                " AcLAn10_CreationDate," & _
                " AcLAn10_AmendDate," & _
                " AcLAn10_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal10" & _
                " SET  AcLAn10_Code=" & enQuoteString(.Code) & _
                ", AcLAn10_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLAn10_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLAn10_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLAn10_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLAn10_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLAn10_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
