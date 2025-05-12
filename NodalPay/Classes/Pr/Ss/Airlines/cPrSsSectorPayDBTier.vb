Public Class cPrSsSectorPayDBTier
    
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " SecPay_Code," & _
                " SecPay_Desc," & _
                " SecPay_HourRate " & _
            "  FROM PrSsSectorPay" & _
            "  WHERE SecPay_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrSsSectorPay As cPrSsSectorPay) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrSsSectorPay
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("SecPay_Code")                                       '(0)
            SpParams.Add(.Desc)                                              '(1)
            SpNames.Add("SecPay_Desc")                                       '(1)
            SpParams.Add(.HourRate)                                          '(2)
            SpNames.Add("SecPay_HourRate")                                   '(2)
            
        End With
        If Me.StoredProcedure("AG_PrSsSectorPay_Save_Update", SpParams, SpNames) Then
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
            Str = " DELETE FROM PrSsSectorPay" & _
               " WHERE SecPay_Code = '" & tCode & "'"
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


