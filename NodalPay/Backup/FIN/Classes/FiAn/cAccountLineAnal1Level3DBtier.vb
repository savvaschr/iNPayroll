Public Class cAccountLineAnal1Level3DBTier
    Inherits cDataTier

    Protected Function GetById(ByVal code As String) As DataSet
        Dim Str As String
        Str = "Select AcLA31_Code," & _
        " AcLA31_DescriptionL," & _
        " AcLA31_DescriptionS," & _
        " AcLA31_CreationDate, " & _
        " AcLA31_AmendDate, " & _
        " AcLA31_IsActive " & _
        " From FiAnAccountLineAnal1Level3 " & _
        " Where AcLa31_Code =" & Utils.enQuoteString(code)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByVal _cAccountLineAnal1Level3 As cAccountLineAnal1Level3, ByVal Update As Boolean) As Boolean
        Dim Str As String
        With _cAccountLineAnal1Level3
            If Update Then
                Str = "INSERT INTO FiAnAccountLineAnal1Level3(" & _
                " AcLA31_Code," & _
                " AcLA31_DescriptionL," & _
                " AcLA31_DescriptionS," & _
                " AcLA31_CreationDate," & _
                " AcLA31_AmendDate," & _
                " AcLA31_IsActive)" & _
                " VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.descriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.IsActive) & ")"
            Else
                Str = "Update FiAnAccountLineAnal1Level3" & _
                " SET  AcLA31_Code=" & enQuoteString(.Code) & _
                ", AcLA31_DescriptionL= " & enQuoteString(.descriptionL) & _
                ", AcLA31_DescriptionS=" & enQuoteString(.DescriptionS) & _
                ", AcLA31_CreationDate=" & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ", AcLA31_AmendDate=" & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ", AcLA31_IsActive=" & enQuoteString(.IsActive) & _
                " Where AcLA31_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
