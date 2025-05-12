Public Class cPrSsPerformanceBonusDBTier

    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " PerBon_Code," & _
                " PerBon_Desc," & _
                " PerBon_Value, " & _
                " PerBon_Rate, " & _
                " PerBon_Type, " & _
                " PerBon_Formula " & _
            "  FROM PrSsPerformanceBonus" & _
            "  WHERE PerBon_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrSsPerformanceBonus As cPrSsPerformanceBonus) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrSsPerformanceBonus
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("PerBon_Code")                                       '(0)
            SpParams.Add(.Desc)                                              '(1)
            SpNames.Add("PerBon_Desc")                                       '(1)
            SpParams.Add(.MyValue)                                          '(2)
            SpNames.Add("PerBon_Value")                                     '(2)
            SpParams.Add(.Rate)                                             '(2)
            SpNames.Add("PerBon_Rate")                                      '(2)
            SpParams.Add(.Type)                                             '(2)
            SpNames.Add("PerBon_Type")                                      '(2)
            SpParams.Add(.Formula)                                          '(2)
            SpNames.Add("PerBon_Formula")                                   '(2)

        End With
        If Me.StoredProcedure("AG_PrSsPerformanceBonus_Save_Update", SpParams, SpNames) Then
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
            Str = " DELETE FROM PrSsPerformanceBonus" & _
               " WHERE PerBon_Code = '" & tCode & "'"
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
