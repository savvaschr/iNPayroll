Public Class cPrMsCovidDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Cov_Id, " & _
        " Emp_Code, " & _
        " TemGrp_Code, " & _
        " Com_Code, " & _
        " Cov_Date,  " & _
        " Cov_Week,  " & _
        " Cov_Month, " & _
        " Cov_Result,  " & _
        " Emp_Anl1,  " & _
        " Emp_Anl2, " & _
        " Emp_Anl3, " & _
        " Emp_Anl4,  " & _
        " Emp_Anl5,  " & _
        " Emp_GenAnal1 " & _
        " FROM PrMsCovidTest " & _
        " Where Cov_Id= " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrMsCovid As cPrMsCovid) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsCovid
            SpParams.Add(.Id)                                                  '(0)
            SpNames.Add("Cov_Id")                                              '(0)
            SpParams.Add(.EmpCode)                                             '(1)
            SpNames.Add("Emp_Code")                                            '(1)
            SpParams.Add(.TemGrpCode)                                          '(2)
            SpNames.Add("TemGrp_Code")                                         '(2)
            SpParams.Add(.ComCode)                                             '(3)
            SpNames.Add("Com_Code")                                            '(3)
            SpParams.Add(.CovDate)                                             '(4)
            SpNames.Add("Cov_Date")                                            '(4)
            SpParams.Add(.CovWeek)                                             '(5)
            SpNames.Add("Cov_Week")                                            '(5)
            SpParams.Add(.CovMonth)                                            '(6)
            SpNames.Add("Cov_Month")                                           '(6)
            SpParams.Add(.CovResult)                                           '(7)
            SpNames.Add("Cov_Result")                                          '(7)
            SpParams.Add(.Anl1)                                                '(8)
            SpNames.Add("Emp_Anl1")                                            '(8)
            SpParams.Add(.Anl2)                                                '(9)
            SpNames.Add("Emp_Anl2")                                            '(9)
            SpParams.Add(.Anl3)                                                '(10)
            SpNames.Add("Emp_Anl3")                                            '(10)
            SpParams.Add(.Anl4)                                                '(11)
            SpNames.Add("Emp_Anl4")                                            '(11)
            SpParams.Add(.Anl5)                                                '(12)
            SpNames.Add("Emp_Anl5")                                            '(12)
            SpParams.Add(.GenAnal1)                                            '(13)
            SpNames.Add("Emp_GenAnal1")                                        '(13)


        End With
        SpNames.Add("NewId")                                             '(14)
        SpParams.Add(CInt(0))                                            '(14)
        If Me.StoredProcedure("PrMsCovidTest_SAVE_UPDATE", SpParams, SpNames, 14) Then
            If _cPrMsCovid.Id = 0 Then
                _cPrMsCovid.Id = DbNullToInt(SpParams(14))
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
            Str = " DELETE FROM PrMsCovidTest " & _
               " WHERE Cov_id = " & tId
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
End Class
