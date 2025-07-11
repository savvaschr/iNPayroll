' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 13/02/2008 09:42:51
'
'
Public Class cPrTxEmployeeDiscountsDbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " EmpDis_id," & _
                " Emp_Code," & _
                " PrdGrp_Code," & _
                " EmpDis_Discount1," & _
                " EmpDis_Discount2," & _
                " EmpDis_Discount3," & _
                " EmpDis_Discount4," & _
                " EmpDis_Discount5," & _
                " EmpDis_Discount6," & _
                " EmpDis_Discount7," & _
                " EmpDis_Discount8," & _
                " EmpDis_Discount9," & _
                " EmpDis_Discount10," & _
                " EmpDis_LifeInsurance," & _
                " Usr_Id," & _
                " EmpDis_CreationDate," & _
                " EmpDis_AmendDate," & _
                " EmpDis_Medical, " & _
                " EmpDis_Pensionfund " & _
            "  FROM PrTxEmployeeDiscounts" & _
            "  WHERE EmpDis_id = " & tId
        Return MyBase.GetData(Str)
    End Function

    Protected Function GetByEmpCodePeriodGroupCode(ByVal tEmpcode As String, ByVal tPeriodGroup As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " EmpDis_id," & _
                " Emp_Code," & _
                " PrdGrp_Code," & _
                " EmpDis_Discount1," & _
                " EmpDis_Discount2," & _
                " EmpDis_Discount3," & _
                " EmpDis_Discount4," & _
                " EmpDis_Discount5," & _
                " EmpDis_Discount6," & _
                " EmpDis_Discount7," & _
                " EmpDis_Discount8," & _
                " EmpDis_Discount9," & _
                " EmpDis_Discount10," & _
                " EmpDis_LifeInsurance," & _
                " Usr_Id," & _
                " EmpDis_CreationDate," & _
                " EmpDis_AmendDate," & _
                " EmpDis_Medical, " & _
                " EmpDis_PensionFund " & _
            "  FROM PrTxEmployeeDiscounts" & _
            "  WHERE Emp_Code = " & enQuoteString(tEmpcode) & _
             " AND PrdGrp_Code =" & enQuoteString(tPeriodGroup)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxEmployeeDiscounts As cPrTxEmployeeDiscounts) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxEmployeeDiscounts
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("EmpDis_id")                                         '(0)
            SpParams.Add(.Emp_Code)                                          '(1)
            SpNames.Add("Emp_Code")                                          '(1)
            SpParams.Add(.PrdGrp_Code)                                       '(2)
            SpNames.Add("PrdGrp_Code")                                       '(2)
            SpParams.Add(.Discount1)                                         '(3)
            SpNames.Add("EmpDis_Discount1")                                  '(3)
            SpParams.Add(.Discount2)                                         '(4)
            SpNames.Add("EmpDis_Discount2")                                  '(4)
            SpParams.Add(.Discount3)                                         '(5)
            SpNames.Add("EmpDis_Discount3")                                  '(5)
            SpParams.Add(.Discount4)                                         '(6)
            SpNames.Add("EmpDis_Discount4")                                  '(6)
            SpParams.Add(.Discount5)                                         '(7)
            SpNames.Add("EmpDis_Discount5")                                  '(7)
            SpParams.Add(.Discount6)                                         '(8)
            SpNames.Add("EmpDis_Discount6")                                  '(8)
            SpParams.Add(.Discount7)                                         '(9)
            SpNames.Add("EmpDis_Discount7")                                  '(9)
            SpParams.Add(.Discount8)                                         '(10)
            SpNames.Add("EmpDis_Discount8")                                  '(10)
            SpParams.Add(.Discount9)                                         '(11)
            SpNames.Add("EmpDis_Discount9")                                  '(11)
            SpParams.Add(.Discount10)                                        '(12)
            SpNames.Add("EmpDis_Discount10")                                 '(12)
            SpParams.Add(.LifeInsurance)                                     '(13)
            SpNames.Add("EmpDis_LifeInsurance")                              '(13)
            SpParams.Add(.Usr_Id)                                            '(14)
            SpNames.Add("Usr_Id")                                            '(14)
            SpParams.Add(.CreationDate)                                      '(15)
            SpNames.Add("EmpDis_CreationDate")                               '(15)
            SpParams.Add(.AmendDate)                                         '(16)
            SpNames.Add("EmpDis_AmendDate")                                  '(16)
            SpParams.Add(.Medical)                                          '(17)
            SpNames.Add("EmpDis_Medical")                                    '(17)
            SpParams.Add(.PensionFund)                                       '(18)
            SpNames.Add("EmpDis_PensionFund")                                 '(18)
        End With
        SpNames.Add("NewId")                                             '(19)
        SpParams.Add(CInt(0))                                            '(19)
        If Me.StoredProcedure("AG_PrTxEmployeeDiscounts_Save_Update", SpParams, SpNames, 19) Then
            If _cPrTxEmployeeDiscounts.Id = 0 Then
                _cPrTxEmployeeDiscounts.Id = DbNullToInt(SpParams(19))
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
            Str = " DELETE FROM PrTxEmployeeDiscounts" & _
               " WHERE EmpDis_id = " & tId
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
        '    Generation Note : 13/02/2008 09:42:51 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function
End Class
