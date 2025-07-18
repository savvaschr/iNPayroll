' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 13/02/2008 09:42:49
'
'
Public Class cPrMsEarningCodesDbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " ErnCod_Code," & _
                " ErnTyp_Code," & _
                " ErnCod_DescriptionL," & _
                " ErnCod_DescriptionS," & _
                " ErnCod_IsActive" & _
            "  FROM PrMsEarningCodes" & _
            "  WHERE ErnCod_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsEarningCodes As cPrMsEarningCodes) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsEarningCodes
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("ErnCod_Code")                                       '(0)
            SpParams.Add(.ErnTypCode)                                        '(1)
            SpNames.Add("ErnTyp_Code")                                       '(1)
            SpParams.Add(.DescriptionL)                                      '(2)
            SpNames.Add("ErnCod_DescriptionL")                               '(2)
            SpParams.Add(.DescriptionS)                                      '(3)
            SpNames.Add("ErnCod_DescriptionS")                               '(3)
            SpParams.Add(.IsActive)                                          '(4)
            SpNames.Add("ErnCod_IsActive")                                   '(4)
        End With
        If Me.StoredProcedure("AG_PrMsEarningCodes_Save_Update", SpParams, SpNames) Then
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
            Str = " DELETE FROM PrMsEarningCodes" & _
               " WHERE ErnCod_Code = '" & tCode & "'"
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
        Dim Str As String
        Str = " " & _
        "SELECT COUNT(ErnCod_Code) " & _
        " FROM PrMsPeriodEarnings" & _
        " WHERE ErnCod_Code = '" & tCode & "'" & _
        " " & _
        "SELECT COUNT(ErnCod_Code) " & _
        " FROM PrMsTemplateEarnings" & _
        " WHERE ErnCod_Code = '" & tCode & "'" & _
        " " & _
        " "
        Return GetData(Str)
    End Function
End Class
