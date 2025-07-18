' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 20/05/2008 10:39:17
'
'
Public Class cPrTxEmployeeSalaryDbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " EmpSal_id," & _
                " Emp_Code," & _
                " EmpSal_Date," & _
                " EmpSal_Value," & _
                " EmpSal_Basic," & _
                " EmpSal_EffPayDate," & _
                " EmpSal_EffArrearsDate," & _
                " EmpSal_Cola," & _
                " Usr_Id," & _
                " EmpSal_IsCola," & _
                " EmpSal_Dif," & _
                " EmpSal_Rate," & _
                " EmpSal_RateSalary " & _
            "  FROM PrTxEmployeeSalary" & _
            "  WHERE EmpSal_id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxEmployeeSalary As cPrTxEmployeeSalary) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxEmployeeSalary
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("EmpSal_id")                                         '(0)
            SpParams.Add(.Emp_Code)                                          '(1)
            SpNames.Add("Emp_Code")                                          '(1)
            SpParams.Add(.Date1)                                             '(2)
            SpNames.Add("EmpSal_Date")                                       '(2)
            SpParams.Add(.SalaryValue)                                       '(3)
            SpNames.Add("EmpSal_Value")                                      '(3)
            SpParams.Add(.Basic)                                             '(4)
            SpNames.Add("EmpSal_Basic")                                      '(4)
            SpParams.Add(.EffPayDate)                                        '(5)
            SpNames.Add("EmpSal_EffPayDate")                                 '(5)
            SpParams.Add(.EffArrearsDate)                                    '(6)
            SpNames.Add("EmpSal_EffArrearsDate")                             '(6)
            SpParams.Add(.Cola)                                              '(7)
            SpNames.Add("EmpSal_Cola")                                       '(7)
            SpParams.Add(.Usr_Id)                                            '(8)
            SpNames.Add("Usr_Id")                                            '(8)
            SpParams.Add(.IsCola)                                            '(9)
            SpNames.Add("EmpSal_IsCola")                                     '(9)
            SpParams.Add(.EmpSal_Dif)                                        '(10)
            SpNames.Add("EmpSal_Dif")                                        '(10)
            SpParams.Add(.myRate)                                            '(11)
            SpNames.Add("EmpSal_Rate")                                       '(11)
            SpParams.Add(.myRateSalary)                                            '(12)
            SpNames.Add("EmpSal_RateSalary")                                       '(12)
        End With
        SpNames.Add("NewId")                                             '(13)
        SpParams.Add(CInt(0))                                            '(13)
        If Me.StoredProcedure("AG_PrTxEmployeeSalary_Save_Update", SpParams, SpNames, 13) Then
            If _cPrTxEmployeeSalary.Id = 0 Then
                _cPrTxEmployeeSalary.Id = DbNullToInt(SpParams(13))
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
            Str = " DELETE FROM PrTxEmployeeSalary" & _
               " WHERE EmpSal_id = " & tId
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
