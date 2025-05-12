Public Class cPrSsCommissionRatesDBTier


    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " ComRat_Code," & _
                " Comrat_Desc," & _
                " ComRat_Value " & _
            "  FROM PrSsCommissionrates" & _
            "  WHERE ComRat_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrSsCommissionRates As cPrSsCommissionRates) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrSsCommissionRates
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("ComRat_Code")                                       '(0)
            SpParams.Add(.Desc)                                              '(1)
            SpNames.Add("ComRat_Desc")                                       '(1)
            SpParams.Add(.MyValue)                                          '(2)
            SpNames.Add("Comrat_Value")                                   '(2)

        End With
        If Me.StoredProcedure("AG_PrSsCommissionRates_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tCode As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrSsCommissionRates" & _
               " WHERE ComRat_Code = '" & tCode & "'"
            If MyBase.ExecuteNonQuery(Str) = -1 Then
                Throw Exx
            End If
            CommitTransaction()
        Catch ex As Exception
            Rollback()
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Protected Function CheckDeleteRecords(ByVal tCode As String) As DataSet
        Dim ds As DataSet
        '    Generation Note : 30/06/2008 10:18:54 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function




End Class
