Public Class cPrLcValuesDBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal tDesc As String, ByVal tLc As String) As DataSet
        Dim str As String
        str = "select PrLc_Desc," & _
        " PrLc_Lc " & _
        " from PrLcValues " & _
        " Where PrLc_Desc = " & enQuoteString(tDesc) & _
        " And PrLc_Lc = " & enQuoteString(tLc)
        Return GetData(str)
    End Function
    Protected Function Save(ByVal tLc As cPrLcValues, ByVal Update As Boolean) As Boolean
        Dim Str As String
        Dim Flag As Boolean = False
        If Not Update Then
            With tLc
                Str = "INSERT INTO PrLcValues " & _
               " (PrLc_Desc, " & _
               " PrLc_Lc) " & _
               " VALUES ( " & _
            enQuoteString(.Description) & ", " & _
            enQuoteString(.LC) & " )"

            End With
        Else
            With tLc
                Str = "Update PrLcValues " & _
               " Set PrLc_Desc " & enQuoteString(.Description) & ", " & _
               " PrLc_Lc) " & enQuoteString(.LC)
            End With
        End If
        Dim i As Integer
        i = MyBase.ExecuteNonQuery(Str)
        If i >= 0 Then
            Flag = True
        End If

        Return Flag

    End Function
End Class
