Public Class cFiTrxnCodesDBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal Code As String, ByVal GroupCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " TrxCod_Code," & _
                " TrxGrp_Code," & _
                " TrxCod_DescriptionL," & _
                " TrxCod_DescriptionS," & _
                " TrxCod_IsActive," & _
                " RefSch_Id," & _
                " JouCod_Code," & _
                " TrxCod_DocTemplate," & _
                " TrxCod_AutoPrint," & _
                " Acc_CodeHdr," & _
                " Acc_CodeDisc," & _
                " Acc_CodeVAT," & _
                " TrxCod_AllowLneDisc," & _
                " TrxCod_AllowOverallDisc" & _
                " FROM FiAdTrxnCodes" & _
                " WHERE TrxCod_Code = " & enQuoteString(Code) & _
                " AND TrxGrp_Code = " & enQuoteString(GroupCode)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cFiAdTrxnCodes As cFiTrxnCodes) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cFiAdTrxnCodes
            SpParams.Add(.Code)                                       '(0)
            SpNames.Add("TrxCod_Code")                                '(0)
            SpParams.Add(.GroupCode)                                  '(1)
            SpNames.Add("TrxGrp_Code")                                '(1)
            SpParams.Add(.DescriptionL)                               '(2)
            SpNames.Add("TrxCod_DescriptionL")                        '(2)
            SpParams.Add(.DescriptionS)                               '(3)
            SpNames.Add("TrxCod_DescriptionS")                        '(3)
            SpParams.Add(.IsActive)                                   '(4)
            SpNames.Add("TrxCod_IsActive")                            '(4)
            SpParams.Add(.RefSchId)                                   '(5)
            SpNames.Add("RefSch_Id")                                  '(5)
            SpParams.Add(.JouCode)                                    '(6)
            SpNames.Add("JouCod_Code")                                '(6)
            SpParams.Add(.DocTemplate)                                '(7)
            SpNames.Add("TrxCod_DocTemplate")                         '(7)
            SpParams.Add(.AutoPrint)                                  '(8)
            SpNames.Add("TrxCod_AutoPrint")                           '(8)
            SpParams.Add(.AccountCodeHeader)                          '(9)
            SpNames.Add("Acc_CodeHdr")                                '(9)
            SpParams.Add(.AccountCodeDiscount)                        '(10)
            SpNames.Add("Acc_CodeDisc")                               '(10)
            SpParams.Add(.AccountCodeVAT)                             '(11)
            SpNames.Add("Acc_CodeVAT")                                '(11)
            SpParams.Add(.AllowLineDisc)                              '(12)
            SpNames.Add("TrxCod_AllowLneDisc")                        '(12)
            SpParams.Add(.AllowOverAllDisc)                           '(13)
            SpNames.Add("TrxCod_AllowOverallDisc")                    '(13)
        End With
        If Me.StoredProcedure("AG_FiAdTrxnCodes_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class


