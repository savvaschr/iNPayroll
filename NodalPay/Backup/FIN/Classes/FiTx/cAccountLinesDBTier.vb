Public Class cAccountLinesDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As Dataset
        Dim Str As String
        Str = " SELECT" & _
         " AccLin_Id," & _
         " JouCod_Code," & _
         " AccLin_JouNo," & _
         " AccLin_JouLineNo," & _
         " AccLin_DocRef," & _
         " AccLin_AltRef," & _
         " AccLin_DocDate," & _
         " AccLin_PostDate," & _
         " AccLin_DueDate," & _
         " Prd_Code," & _
         " Acc_Code," & _
         " BusPrt_Code," & _
         " AccLin_DrCr," & _
         " AccLin_AmountLocCur," & _
         " Cur_AlphaCode," & _
         " AccLin_AmountTrxCur," & _
         " AccLin_CurRate," & _
         " AccLin_TrxCurDecimal," & _
         " AcLAn1_Code," & _
         " AcLAn2_Code," & _
         " AcLAn3_Code," & _
         " AcLAn4_Code," & _
         " AcLAn5_Code," & _
         " AcLAn6_Code," & _
         " AcLAn7_Code," & _
         " AcLAn8_Code," & _
         " AcLAn9_Code," & _
         " AcLAn10_Code," & _
         " AccLin_AllocStatus," & _
         " AccLin_AllocRef," & _
         " AccLin_UnAllocBalanceLC," & _
         " AccLin_UnAllocBalanceTC," & _
         " AccLin_AllocDate," & _
         " AccLin_AllocPeriod," & _
         " AccLin_Comment," & _
         " AccLin_ExternalRef," & _
         " AccLin_Module," & _
         " AccLin_ModRef," & _
         " AccLin_CreationDate," & _
         " AccLin_AmendDate," & _
         " AccLin_CreatedBy," & _
         " AccLin_AmendBy" & _
         "  FROM FiTxAccountLines" & _
         " Where AccLin_Id=" & Id
        Return MyBase.GetData(Str)
    End Function
    'Protected Function Save(ByVal _cAccountLines As cAccountLines, ByVal Update As Boolean) As Boolean
    '    Dim Str As String
    '    With _cAccountLines
    '        If Not Update Then
    '            Str = "INSERT INTO FiTxAccountLines(" & _
    '                "JouCod_Code," & _
    '                "AccLin_JouNo," & _
    '                "AccLin_JouLineNo," & _
    '                "AccLin_DocRef," & _
    '                "AccLin_AltRef," & _
    '                "AccLin_DocDate," & _
    '                "AccLin_PostDate," & _
    '                "AccLin_DueDate," & _
    '                "Prd_Code," & _
    '                "Acc_Code," & _
    '                "BusPrt_Code," & _
    '                "AccLin_DrCr," & _
    '                "AccLin_AmountLocCur," & _
    '                "Cur_AlphaCode," & _
    '                "AccLin_AmountTrxCur," & _
    '                "AccLin_CurRate," & _
    '                "AccLin_TrxCurDecimal," & _
    '                "AcLAn1_Code," & _
    '                "AcLAn2_Code," & _
    '                "AcLAn3_Code," & _
    '                "AcLAn4_Code," & _
    '                "AcLAn5_Code," & _
    '                "AcLAn6_Code," & _
    '                "AcLAn7_Code," & _
    '                "AcLAn8_Code," & _
    '                "AcLAn9_Code," & _
    '                "AcLAn10_Code," & _
    '                "AccLin_AllocStatus," & _
    '                "AccLin_AllocRef," & _
    '                "AccLin_UnAllocBalanceLC," & _
    '                "AccLin_UnAllocBalanceTC," & _
    '                "AccLin_AllocDate," & _
    '                "AccLin_AllocPeriod," & _
    '                "AccLin_Comment," & _
    '                "AccLin_ExternalRef," & _
    '                "AccLin_Module," & _
    '                "AccLin_ModRef," & _
    '                "AccLin_CreationDate," & _
    '                "AccLin_AmendDate," & _
    '                "AccLin_CreatedBy," & _
    '                "AccLin_AmendBy)" & _
    '                "VALUES (" & enQuoteString(.JournalCode) & "," & _
    '                 .JournalNumber & "," & _
    '                 .JournalLineNo & "," & _
    '                  enQuoteString(.DocRef) & "," & _
    '                  enQuoteString(.AltRef) & "," & _
    '                  enQuoteString(Utils.ChangeDateForSaving(.DocDate)) & "," & _
    '                 enQuoteString(Utils.ChangeDateForSaving(.PostDate)) & "," & _
    '                 enQuoteString(Utils.ChangeDateForSaving(.DueDate)) & "," & _
    '                 .PeriodCode & "," & _
    '                  enQuoteString(.AccountCode) & "," & _
    '                  enQuoteString(.BusPrtCode) & "," & _
    '                  enQuoteString(.DrCr) & "," & _
    '                 .AmountLocCur & "," & _
    '                  enQuoteString(.CurAlphaCode) & "," & _
    '                 .AmountTrxCur & "," & _
    '                 .CurRate & "," & _
    '                 .TrxCurDecimal & "," & _
    '                  enQuoteString(.AcLAn1Code) & "," & _
    '                  enQuoteString(.AcLAn2Code) & "," & _
    '                  enQuoteString(.AcLAn3Code) & "," & _
    '                  enQuoteString(.AcLAn4Code) & "," & _
    '                  enQuoteString(.AcLAn5Code) & "," & _
    '                  enQuoteString(.AcLAn6Code) & "," & _
    '                  enQuoteString(.AcLAn7Code) & "," & _
    '                  enQuoteString(.AcLAn8Code) & "," & _
    '                  enQuoteString(.AcLAn9Code) & "," & _
    '                  enQuoteString(.AcLAn10Code) & "," & _
    '                  enQuoteString(.AllocStatus) & "," & _
    '                 .AllocRef & "," & _
    '                 .UnAllocBalanceLC & "," & _
    '                 .UnAllocBalanceTC & "," & _
    '                 enQuoteString(Utils.ChangeDateForSaving(.AllocDate)) & "," & _
    '                 .AllocPeriod & "," & _
    '                  enQuoteString(.Comment) & "," & _
    '                 .ExternalRef & "," & _
    '                 enQuoteString(.MyModule) & "," & _
    '                 .ModRef & "," & _
    '                 enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
    '                 enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
    '                 .CreatedBy & "," & _
    '                 .AmendBy & ")"
    '        Else
    '            Str = "Update FiTxAccountLines" & _
    '            " SET JouCod_Code = " & enQuoteString(.JournalCode) & _
    '            ",AccLin_JouNo = " & .JournalNumber & _
    '            ",AccLin_JouLineNo = " & .JournalLineNo & _
    '            ",AccLin_DocRef = " & enQuoteString(.DocRef) & _
    '            ",AccLin_AltRef = " & enQuoteString(.AltRef) & _
    '            ",AccLin_DocDate = " & enQuoteString(Utils.ChangeDateForSaving(.DocDate)) & _
    '            ",AccLin_PostDate = " & enQuoteString(Utils.ChangeDateForSaving(.PostDate)) & _
    '            ",AccLin_DueDate = " & enQuoteString(Utils.ChangeDateForSaving(.DueDate)) & _
    '            ",Prd_Code = " & .PeriodCode & _
    '            ",Acc_Code = " & enQuoteString(.AccountCode) & _
    '            ",BusPrt_Code = " & enQuoteString(.BusPrtCode) & _
    '            ",AccLin_DrCr = " & enQuoteString(.DrCr) & _
    '            ",AccLin_AmountLocCur = " & .AmountLocCur & _
    '            ",Cur_AlphaCode = " & enQuoteString(.CurAlphaCode) & _
    '            ",AccLin_AmountTrxCur = " & .AmountTrxCur & _
    '            ",AccLin_CurRate = " & .CurRate & _
    '            ",AccLin_TrxCurDecimal = " & .TrxCurDecimal & _
    '            ",AcLAn1_Code = " & enQuoteString(.AcLAn1Code) & _
    '            ",AcLAn2_Code = " & enQuoteString(.AcLAn2Code) & _
    '            ",AcLAn3_Code = " & enQuoteString(.AcLAn3Code) & _
    '            ",AcLAn4_Code = " & enQuoteString(.AcLAn4Code) & _
    '            ",AcLAn5_Code = " & enQuoteString(.AcLAn5Code) & _
    '            ",AcLAn6_Code = " & enQuoteString(.AcLAn6Code) & _
    '            ",AcLAn7_Code = " & enQuoteString(.AcLAn7Code) & _
    '            ",AcLAn8_Code = " & enQuoteString(.AcLAn8Code) & _
    '            ",AcLAn9_Code = " & enQuoteString(.AcLAn9Code) & _
    '            ",AcLAn10_Code = " & enQuoteString(.AcLAn10Code) & _
    '            ",AccLin_AllocStatus = " & enQuoteString(.AllocStatus) & _
    '            ",AccLin_AllocRef = " & .AllocRef & _
    '            ",AccLin_UnAllocBalanceLC = " & .UnAllocBalanceLC & _
    '            ",AccLin_UnAllocBalanceTC = " & .UnAllocBalanceTC & _
    '            ",AccLin_AllocDate = " & enQuoteString(Utils.ChangeDateForSaving(.AllocDate)) & _
    '            ",AccLin_AllocPeriod = " & .AllocPeriod & _
    '            ",AccLin_Comment = " & enQuoteString(.Comment) & _
    '            ",AccLin_ExternalRef = " & .ExternalRef & _
    '            ",AccLin_Module = " & enQuoteString(.MyModule) & _
    '            ",AccLin_ModRef = " & .ModRef & _
    '            ",AccLin_CreationDate = " & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
    '            ",AccLin_AmendDate = " & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
    '            ",AccLin_CreatedBy = " & enQuoteString(.CreatedBy) & _
    '            ",AccLin_AmendBy = " & .AmendBy & _
    '            " Where JouCod_Code = " & enQuoteString(.JournalCode) & _
    '            " AND AccLin_JouNo=" & .JournalNumber & _
    '            " AND AccLin_JouLineNo=" & .JournalLineNo
    '        End If
    '    End With
    '    If MyBase.ExecuteNonQuery(Str) > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    Protected Function Save(ByVal _cAccountLines As cAccountLines) As Boolean
        Dim SpParams As New ArrayList
        Dim Flag As Boolean = False
        Dim SpNames As New ArrayList
        With _cAccountLines
            SpNames.Add("AccLin_Id")                                '0
            SpNames.Add("JouCod_Code")                              '1
            SpNames.Add("AccLin_JouNo")                             '2
            SpNames.Add("AccLin_JouLineNo")                         '3
            SpNames.Add("AccLin_DocRef")                            '4
            SpNames.Add("AccLin_AltRef")                            '5
            SpNames.Add("AccLin_DocDate")                           '6
            SpNames.Add("AccLin_PostDate")                          '7
            SpNames.Add("AccLin_DueDate")                           '8
            SpNames.Add("Prd_Code")                                 '9
            SpNames.Add("Acc_Code")                                 '10
            SpNames.Add("BusPrt_Code")                              '11
            SpNames.Add("AccLin_DrCr")                              '12
            SpNames.Add("AccLin_AmountLocCur")                      '13
            SpNames.Add("Cur_AlphaCode")                            '14
            SpNames.Add("AccLin_AmountTrxCur")                      '15
            SpNames.Add("AccLin_CurRate")                           '16
            SpNames.Add("AccLin_TrxCurDecimal")                     '17
            SpNames.Add("AcLAn1_Code")                              '18
            SpNames.Add("AcLAn2_Code")                              '19
            SpNames.Add("AcLAn3_Code")                              '20
            SpNames.Add("AcLAn4_Code")                              '21
            SpNames.Add("AcLAn5_Code")                              '22
            SpNames.Add("AcLAn6_Code")                              '23
            SpNames.Add("AcLAn7_Code")                              '24
            SpNames.Add("AcLAn8_Code")                              '25
            SpNames.Add("AcLAn9_Code")                              '26
            SpNames.Add("AcLAn10_Code")                             '27
            SpNames.Add("AccLin_AllocStatus")                       '28
            SpNames.Add("AccLin_AllocRef")                          '29
            SpNames.Add("AccLin_UnAllocBalanceLC")                  '30
            SpNames.Add("AccLin_UnAllocBalanceTC")                  '31
            SpNames.Add("AccLin_AllocDate")                         '32
            SpNames.Add("AccLin_AllocPeriod")                       '33
            SpNames.Add("AccLin_Comment")                           '34
            SpNames.Add("AccLin_ExternalRef")                       '35
            SpNames.Add("AccLin_Module")                            '36
            SpNames.Add("AccLin_ModRef")                            '37
            SpNames.Add("AccLin_CreationDate")                      '38
            SpNames.Add("AccLin_AmendDate")                         '39
            SpNames.Add("AccLin_CreatedBy")                         '40
            SpNames.Add("AccLin_AmendBy")                           '41
            SpNames.Add("NewId")                                    '42


            SpParams.Add(.Id)                                       '0
            SpParams.Add(.JournalCode)                              '1
            SpParams.Add(.JournalNumber)                            '2
            SpParams.Add(.JournalLineNo)                            '3
            SpParams.Add(.DocRef)                                   '4
            SpParams.Add(.AltRef)                                   '5
            SpParams.Add(.DocDate)                                  '6
            SpParams.Add(.PostDate)                                 '7
            SpParams.Add(.DueDate)                                  '8
            SpParams.Add(.PeriodCode)                               '9
            SpParams.Add(.AccountCode)                              '10
            SpParams.Add(.BusPrtCode)                               '11
            SpParams.Add(.DrCr)                                     '12
            SpParams.Add(.AmountLocCur)                             '13
            SpParams.Add(.CurAlphaCode)                             '14
            SpParams.Add(.AmountTrxCur)                             '15
            SpParams.Add(.CurRate)                                  '16
            SpParams.Add(.TrxCurDecimal)                            '17
            SpParams.Add(.AcLAn1Code)                               '18
            SpParams.Add(.AcLAn2Code)                               '19
            SpParams.Add(.AcLAn3Code)                               '20
            SpParams.Add(.AcLAn4Code)                               '21
            SpParams.Add(.AcLAn5Code)                               '22
            SpParams.Add(.AcLAn6Code)                               '23
            SpParams.Add(.AcLAn7Code)                               '24
            SpParams.Add(.AcLAn8Code)                               '25
            SpParams.Add(.AcLAn9Code)                               '26
            SpParams.Add(.AcLAn10Code)                              '27
            SpParams.Add(.AllocStatus)                              '28
            SpParams.Add(.AllocRef)                                 '29
            SpParams.Add(.UnAllocBalanceLC)                         '30
            SpParams.Add(.UnAllocBalanceTC)                         '31
            SpParams.Add(.AllocDate)                                '32
            SpParams.Add(.AllocPeriod)                              '33
            SpParams.Add(.Comment)                                  '34
            SpParams.Add(.ExternalRef)                              '35
            SpParams.Add(.MyModule)                                 '36
            SpParams.Add(.ModRef)                                   '37
            SpParams.Add(.CreationDate)                             '38
            SpParams.Add(.AmendDate)                                '39
            SpParams.Add(.CreatedBy)                                '40
            SpParams.Add(.AmendBy)                                  '41
            SpParams.Add(CInt(0))                                   '42
        End With

        If Me.StoredProcedure("AG_FiTxAccountLines_SAVE_UPDATE", SpParams, spnames, 42) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class