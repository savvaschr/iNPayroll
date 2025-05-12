Public Class cPrTxEmployeeAdvancesDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT EmpAdv_Id," & _
            " Emp_Code," & _
            " EmpAdv_Amount," & _
            " EmpAdv_User," & _
            " EmpAdv_Date " & _
            " FROM  PrTxEmployeeAdvances" & _
            " WHERE EmpAdv_id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxEmployeeAdvances As cPrTxEmployeeAdvances) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxEmployeeAdvances
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("EmpAdv_id")                                         '(0)
            SpParams.Add(.EmpCode)                                           '(1)
            SpNames.Add("Emp_Code")                                          '(1)
            SpParams.Add(.Amount)                                            '(2)
            SpNames.Add("EmpAdv_Amount")                                     '(2)
            SpParams.Add(.User)                                              '(3)
            SpNames.Add("EmpAdv_User")                                       '(3)
            SpParams.Add(.MyDate)                                            '(4)
            SpNames.Add("EmpAdv_Date")                                       '(4)

        End With
        SpNames.Add("NewId")                                                 '(5)
        SpParams.Add(CInt(0))                                                '(5)
        If Me.StoredProcedure("AG_PrTxEmployeeAdvances_Save_Update", SpParams, SpNames, 5) Then
            If _cPrTxEmployeeAdvances.Id = 0 Then
                _cPrTxEmployeeAdvances.Id = DbNullToInt(SpParams(5))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tId As Integer) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrTxEmployeeAdvances" & _
               " WHERE EmpAdv_id = " & tId
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
    Protected Function CheckDeleteRecords(ByVal tCode As Integer) As DataSet
        Dim ds As DataSet
        '    Generation Note : 20/05/2008 10:39:17 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function
End Class
