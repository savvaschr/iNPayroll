Public Class cPrTxEmployeeLoanDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT EmpLne_Id, " & _
        " EmpLne_Code," & _
        " Emp_Code ," & _
        " TemGrp_Code ," & _
        " PrdCod_Code ," & _
        " PrdGrp_Code ," & _
        " DedCod_Code ," & _
        " TrxHdr_Id ," & _
        " EmpLne_LoanDate ," & _
        " EmpLne_Amount ," & _
        " EmpLne_Interest ," & _
        " EmpLne_TotalAmount ," & _
        " EmpLne_Description ," & _
        " EmpLne_MonthlyAmount ," & _
        " EmpLne_Type ," & _
        " EmpLne_Payment ," & _
        " Usr_Id," & _
        " EmpLne_Status " & _
        " FROM  PrTxEmployeeLoan" & _
        " WHERE EmpLne_id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxEmployeeLoan As cPrTxEmployeeLoan) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxEmployeeLoan
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("EmpLne_id")
            SpParams.Add(.LoanCode)                                          '(1)
            SpNames.Add("EmpLne_Code")
            SpParams.Add(.EmpCode)                                           '(2)
            SpNames.Add("Emp_Code")
            SpParams.Add(.TempGroupCode)                                     '(3)
            SpNames.Add("TemGrp_Code")
            SpParams.Add(.PeriodCode)                                        '(4)
            SpNames.Add("PrdCod_Code")
            SpParams.Add(.PeriodGroup)                                       '(5)
            SpNames.Add("PrdGrp_Code")
            SpParams.Add(.DedCode)                                           '(6)
            SpNames.Add("DedCod_Code")
            SpParams.Add(.TrxHdr_Id)                                         '(7)
            SpNames.Add("TrxHdr_Id")
            SpParams.Add(.LoanDate)                                          '(8)
            SpNames.Add("EmpLne_LoanDate")
            SpParams.Add(.Amount)                                            '(9)
            SpNames.Add("EmpLne_Amount")
            SpParams.Add(.Interest)                                          '(10)
            SpNames.Add("EmpLne_Interest")
            SpParams.Add(.TotalAmount)                                       '(11)
            SpNames.Add("EmpLne_TotalAmount")
            SpParams.Add(.Description)                                       '(12)
            SpNames.Add("EmpLne_Description")
            SpParams.Add(.MonthlyAmount)                                     '(13)
            SpNames.Add("EmpLne_MonthlyAmount")
            SpParams.Add(.Type)                                              '(14)
            SpNames.Add("EmpLne_Type")
            SpParams.Add(.Payment)                                           '(15)
            SpNames.Add("EmpLne_Payment")
            SpParams.Add(.UserId)                                            '(16)
            SpNames.Add("Usr_Id")
            SpParams.Add(.Status)                                            '(17)
            SpNames.Add("EmpLne_Status")

        End With


        SpNames.Add("NewId")                                             '(18)
        SpParams.Add(CInt(0))                                            '(18)
        If Me.StoredProcedure("AG_PrTxEmployeeLoan_Save_Update", SpParams, SpNames, 18) Then
            If _cPrTxEmployeeLoan.Id = 0 Then
                _cPrTxEmployeeLoan.Id = DbNullToInt(SpParams(18))
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
            Str = " DELETE FROM PrTxEmployeeLoan" & _
               " WHERE EmpLne_id = " & tId
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
