Public Class cPrTxTimesheetsDBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Tms_Id, " & _
            " Emp_Code, " & _
            " TemGrp_Code, " & _
            " PrdGrp_Code, " & _
            " PrdCod_Code, " & _
            " Tms_Date, " & _
            " Tms_In1, " & _
            " Tms_Out1, " & _
            " Tms_In2, " & _
            " Tms_Out2,  " & _
            " Tms_In3, " & _
            " Tms_Out3,  " & _
            " Tms_TotalWorkPerDay,  " & _
            " Tms_TotalWorkPerWeek, " & _
            " Tms_TotalWorkPerMonth, " & _
            " Tms_ALHours, " & _
            " Tms_SickHours, " & _
            " Tms_ArmyHours, " & _
            " Tms_MaterHours,  " & _
            " Tms_NormalDayHours,  " & _
            " Tms_DayDiff,  " & _
            " Tms_MonthDiff,  " & _
            " Tms_TotalMonthNormal,  " & _
            " Tms_FromFile,  " & _
            " Tms_BusTrip, " & _
            " Tms_FamDeath, " & _
            " Tms_Study, " & _
            " Tms_WFH,  " & _
            " Tms_TotalMAL,  " & _
            " Tms_TotalMSic,  " & _
            " Tms_TotalMArmy,  " & _
            " Tms_TotalMMat  " & _
            " FROM PrTxTimeSheets " & _
            " WHERE Tms_id = " & Id

        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK2(ByVal EmpCode As String, ByVal D As Date, ByVal TemCode As String, ByVal PerGroup As String, ByVal PerCode As String) As DataSet
        Dim Str As String


        Dim Ddate As String = Format(D, "yyyy-MM-dd")
        Ddate = Utils.ChangeDateFormatForSearch(Ddate)




        Str = " SELECT Tms_Id, " & _
            " Emp_Code, " & _
            " TemGrp_Code, " & _
            " PrdGrp_Code, " & _
            " PrdCod_Code, " & _
            " Tms_Date, " & _
            " Tms_In1, " & _
            " Tms_Out1, " & _
            " Tms_In2, " & _
            " Tms_Out2,  " & _
            " Tms_In3, " & _
            " Tms_Out3,  " & _
            " Tms_TotalWorkPerDay,  " & _
            " Tms_TotalWorkPerWeek, " & _
            " Tms_TotalWorkPerMonth, " & _
            " Tms_ALHours, " & _
            " Tms_SickHours, " & _
            " Tms_ArmyHours, " & _
            " Tms_MaterHours,  " & _
            " Tms_NormalDayHours,  " & _
            " Tms_DayDiff,  " & _
            " Tms_MonthDiff,  " & _
            " Tms_TotalMonthNormal,  " & _
            " Tms_FromFile,  " & _
             " Tms_BusTrip, " & _
            " Tms_FamDeath, " & _
            " Tms_Study, " & _
            " Tms_WFH, " & _
            " Tms_TotalMAL,  " & _
            " Tms_TotalMSic,  " & _
            " Tms_TotalMArmy,  " & _
            " Tms_TotalMMat  " & _
            " FROM PrTxTimeSheets " & _
            " WHERE Emp_Code = " & enQuoteString(EmpCode) & _
            " AND TemGrp_Code = " & enQuoteString(TemCode) & _
            " AND PrdGrp_Code = " & enQuoteString(PerGroup) & _
            " AND PrdCod_Code = " & enQuoteString(PerCode) & _
            " AND Tms_Date = " & enQuoteString(Ddate)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal Tms As cPrTxTimesheets) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With Tms
            SpParams.Add(.Id)                                               '(0)
            SpNames.Add("Id")                                           '(0)

            SpParams.Add(.EmpCode)                                          '(1)
            SpNames.Add("EmpCode")                                         '(1)

            SpParams.Add(.TemGroup)
            SpNames.Add("TemGroup")

            SpParams.Add(.PeriodGroup)                                      '(3)
            SpNames.Add("PeriodGroup")                                      '(3)

            SpParams.Add(.PeriodCode)                                       '(4)
            SpNames.Add("PeriodCode")                                      '5)

            SpParams.Add(.TransDate)                                        '(5)
            SpNames.Add("TransDate")                                         '(5)

            SpParams.Add(.In1)                                              '(6)
            SpNames.Add("In1")                                          '(6)

            SpParams.Add(.Out1)                                             '(7)
            SpNames.Add("Out1")                                         '(7)

            SpParams.Add(.In2)                                              '(8)
            SpNames.Add("In2")                                          '(8)

            SpParams.Add(.Out2)                                             '(9)
            SpNames.Add("Out2")                                         '(9)

            SpParams.Add(.In3)                                              '(10)
            SpNames.Add("In3")                                          '(10)

            SpParams.Add(.Out3)                                             '(11)
            SpNames.Add("Out3")                                         '(11)

            SpParams.Add(.TotalWorkPerDay)                                  '(12)
            SpNames.Add("TotalWorkPerDay")                              '(12)

            SpParams.Add(.TotalWorkPerWeek)                                 '(13)
            SpNames.Add("TotalWorkPerWeek")                            '(13)

            SpParams.Add(.TotalWorkPerMonth)                                '(14)
            SpNames.Add("TotalWorkPerMonth")                            '(14)

            SpParams.Add(.ALHours)                                          '(15
            SpNames.Add("AlHours")                                      '(15)

            SpParams.Add(.SickHours)                                        '(16)
            SpNames.Add("SickHours")                                    '(16)

            SpParams.Add(.ArmyHours)                                        '(17)
            SpNames.Add("ArmyHours")                                    '(17)

            SpParams.Add(.MaterHours)                                       '(18)
            SpNames.Add("MaterHours")                                   '(18)

            SpParams.Add(.NormalDayHours)                                       '(19)
            SpNames.Add("NormaldayHours")                                   '(19)

            SpParams.Add(.DayDiff)                                       '(20)
            SpNames.Add("DayDiff")                                   '(20)

            SpParams.Add(.MonthDiff)                                       '(21)
            SpNames.Add("MonthDiff")                                   '(21)

            SpParams.Add(.totalMonthNormal)                                       '(22)
            SpNames.Add("TotalMonthNormal")                                   '(22)

            SpParams.Add(.FromFile)                                       '(23)
            SpNames.Add("FromFile")                                   '(23)

            SpParams.Add(.BusTrip)                                       '(24)
            SpNames.Add("BusTrip")                                   '(24)

            SpParams.Add(.FamDeath)                                       '(25)
            SpNames.Add("FamDeath")                                   '(25)

            SpParams.Add(.StudyLeave)                                       '(26)
            SpNames.Add("Study")                                   '(26)

            SpParams.Add(.WorkFromHome)                                       '(27)
            SpNames.Add("WFH")                                   '(27)

            SpParams.Add(.TotalAL)                                       '(28)
            SpNames.Add("TotalMAL")                                   '(28)

            SpParams.Add(.TotalSick)                                     '(29)
            SpNames.Add("TotalMSic")                                   '(29)

            SpParams.Add(.TotalArmy)                                       '(30)
            SpNames.Add("TotalMArmy")                                   '(30)

            SpParams.Add(.TotalMater)                                       '(31)
            SpNames.Add("TotalMMat")                                   '(31)




        End With
        SpNames.Add("NewId")                                                 '(32)
        SpParams.Add(CInt(0))                                                '(32)
        If Me.StoredProcedure("PrTxTimesheets_SAVE_UPDATE", SpParams, SpNames, 32) Then
            If Tms.Id = 0 Then
                Tms.Id = DbNullToInt(SpParams(32))
            End If
            Return True
        Else
            Return False
        End If

    End Function
End Class


