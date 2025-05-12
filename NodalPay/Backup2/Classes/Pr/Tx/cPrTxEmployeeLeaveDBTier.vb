Public Class cPrTxEmployeeLeaveDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT EmpLea_Id," & _
            " EmpLea_Status," & _
            " Emp_Code," & _
            " EmpLea_Type," & _
            " EmpLea_ReqDate," & _
            " EmpLea_ProcDate," & _
            " EmpLea_ProcBy," & _
            " EmpLea_FromDate," & _
            " EmpLea_ToDate," & _
            " EmpLea_Units" & _
            " EmpLea_Action," & _
            " Hdr_Id," & _
            " EmpLea_Comment," & _
            " EmpLea_ApprovedBy " & _
            " FROM  PrTxEmployeeLeave" & _
            " WHERE EmpLea_id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxEmployeeLeave As cPrTxEmployeeLeave) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxEmployeeLeave
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("EmpLea_id")                                         '(0)
            SpParams.Add(.Status)                                            '(1)
            SpNames.Add("EmpLea_Status")                                     '(1)
            SpParams.Add(.EmpCode)                                           '(2)
            SpNames.Add("Emp_Code")                                          '(2)
            SpParams.Add(.Type)                                              '(3)
            SpNames.Add("EmpLea_Type")                                       '(3)
            SpParams.Add(.ReqDate)                                           '(4)
            SpNames.Add("EmpLea_ReqDate")                                    '(4)
            SpParams.Add(.ProcDate)                                          '(5)
            SpNames.Add("EmpLea_ProcDate")                                   '(5)
            SpParams.Add(.ProcBy)                                            '(6)
            SpNames.Add("EmpLea_ProcBy")                                     '(6)
            SpParams.Add(.FromDate)                                          '(7)
            SpNames.Add("EmpLea_FromDate")                                   '(7)
            SpParams.Add(.ToDate)                                            '(8)
            SpNames.Add("EmpLea_ToDate")                                     '(8)
            SpParams.Add(.Units)                                             '(9)
            SpNames.Add("EmpLea_Units")                                      '(9)
            SpParams.Add(.Action)                                            '(10)
            SpNames.Add("EmpLea_Action")                                     '(10)
            SpParams.Add(.HdrId)                                             '(11)
            SpNames.Add("Hdr_Id")                                            '(11)

            SpParams.Add(.Comment)                                           '(12)
            SpNames.Add("EmpLea_Comment")                                    '(12)
            SpParams.Add(.ApprovedBy)                                        '(13)
            SpNames.Add("EmpLea_ApprovedBy")                                 '(13)
            
        End With
        SpNames.Add("NewId")                                             '(14)
        SpParams.Add(CInt(0))                                            '(14)
        If Me.StoredProcedure("AG_PrTxEmployeeLeave_Save_Update", SpParams, SpNames, 14) Then
            If _cPrTxEmployeeLeave.Id = 0 Then
                _cPrTxEmployeeLeave.Id = DbNullToInt(SpParams(14))
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
            Str = " DELETE FROM PrTxEmployeeLeave" & _
               " WHERE EmpLea_id = " & tId
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
