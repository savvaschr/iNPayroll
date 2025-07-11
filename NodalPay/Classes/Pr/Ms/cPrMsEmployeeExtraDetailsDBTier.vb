﻿' This Class has been autogenerated by SC INSOFT LIMITED
' Do NOT adjust as it will be overwritten
' Generation Date : 31/07/2024 16:48:52
'
'
Public Class cPrMsEmployeeExtraDetailsDbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tEmp_Code As String) As DataSet
        Dim Str As String
        Str = " SELECT" &
                " Emp_Code," &
                " Emp_StartDateToPrevServ," &
                " PosCat_Code," &
                " PosRnk_Code," &
                " Emp_RetirementDate63," &
                " Emp_RetirementDate65," &
                " Emp_ComDate400Months," &
                " Emp_ExtraRatePerHour," &
                " Emp_DOfNextRateIncrease," &
                " Emp_IsTop," &
                " Emp_ProvidentFund," &
                " Emp_PensionFund," &
                " Emp_DOfStartPrFund," &
                " Emp_10PercentDecrease," &
                " Rnk_Code" &
            "  FROM PrMsEmployeeExtraDetails" &
            "  WHERE Emp_Code = '" & tEmp_Code & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsEmployeeExtraDetails As cPrMsEmployeeExtraDetails) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsEmployeeExtraDetails
            SpParams.Add(.Emp_Code)                                          '(0)
            SpNames.Add("Emp_Code")                                          '(0)
            SpParams.Add(.Emp_StartDateToPrevServ)                           '(1)
            SpNames.Add("Emp_StartDateToPrevServ")                           '(1)
            SpParams.Add(.PosCat_Code)                                       '(2)
            SpNames.Add("PosCat_Code")                                       '(2)
            SpParams.Add(.PosRnk_Code)                                       '(3)
            SpNames.Add("PosRnk_Code")                                       '(3)
            SpParams.Add(.Emp_RetirementDate63)                              '(4)
            SpNames.Add("Emp_RetirementDate63")                              '(4)
            SpParams.Add(.Emp_RetirementDate65)                              '(5)
            SpNames.Add("Emp_RetirementDate65")                              '(5)
            SpParams.Add(.Emp_ComDate400Months)                              '(6)
            SpNames.Add("Emp_ComDate400Months")                              '(6)
            SpParams.Add(.Emp_ExtraRatePerHour)                              '(7)
            SpNames.Add("Emp_ExtraRatePerHour")                              '(7)
            SpParams.Add(.Emp_DOfNextRateIncrease)                           '(8)
            SpNames.Add("Emp_DOfNextRateIncrease")                           '(8)
            SpParams.Add(.Emp_IsTop)                                         '(9)
            SpNames.Add("Emp_IsTop")                                         '(9)
            SpParams.Add(.Emp_ProvidentFund)                                 '(10)
            SpNames.Add("Emp_ProvidentFund")                                 '(10)
            SpParams.Add(.Emp_PensionFund)                                   '(11)
            SpNames.Add("Emp_PensionFund")                                   '(11)
            SpParams.Add(.Emp_DOfStartPrFund)                                '(12)
            SpNames.Add("Emp_DOfStartPrFund")                                '(12)
            SpParams.Add(.Emp_10PercentDecrease)                             '(13)
            SpNames.Add("Emp_10PercentDecrease")                             '(13)
            SpParams.Add(.Rnk_Code)                                          '(14)
            SpNames.Add("Rnk_Code")                                          '(14)
        End With
        If Me.StoredProcedure("AG_PrMsEmployeeExtraDetails_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tEmp_Code As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrMsEmployeeExtraDetails" &
               " WHERE Emp_Code = '" & tEmp_Code & "'"
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
        '    Generation Note : 31/07/2024 16:48:52 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function
End Class
