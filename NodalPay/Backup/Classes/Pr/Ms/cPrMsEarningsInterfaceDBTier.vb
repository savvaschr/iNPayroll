Public Class cPrMsEarningsInterfaceDBTier
    Inherits cDataTier
    '
    Protected Function GetById(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = "SELECT ErnInt_Id," & _
        " IntTem_Code," & _
        " TemGrp_Code," & _
        " ErnCod_Code, " & _
        " ErnInt_CreditAcc," & _
        " ErnInt_CreditConsolLevel," & _
        " ErnInt_DebitAcc, " & _
        " ErnInt_DebitConsolLevel," & _
        " ErnInt_CreditAnal," & _
        " ErnInt_DebitAnal" & _
        " FROM PrMsEarningsInterface" & _
        " WHERE (ErnInt_Id=" & tId & ")"

        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String, ByVal tErnCode As String) As DataSet
        Dim Str As String
        Str = "SELECT ErnInt_Id," & _
            " IntTem_Code," & _
            " TemGrp_Code," & _
            " ErnCod_Code, " & _
            " ErnInt_CreditAcc," & _
            " ErnInt_CreditConsolLevel," & _
            " ErnInt_DebitAcc," & _
            " ErnInt_DebitConsolLevel," & _
            " ErnInt_CreditAnal," & _
            " ErnInt_DebitAnal" & _
            " FROM PrMsEarningsInterface" & _
            " WHERE (TemGrp_Code =" & enQuoteString(tTemGrp_Code) & ")" & _
            " AND (IntTem_Code = " & enQuoteString(tIntTem_Code) & ")" & _
            " AND (ErnCod_Code = " & enQuoteString(tErnCode) & ")"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrMsEarningsInterface As cPrMsEarningsInterface) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsEarningsInterface
            SpParams.Add(.Id)                                              '(0)
            SpNames.Add("ErnInt_Id")                                       '(0)
            SpParams.Add(.IntTemCode)                                      '(1)
            SpNames.Add("IntTem_Code")                                     '(1)
            SpParams.Add(.TemGrpCode)                                      '(2)
            SpNames.Add("TemGrp_Code")                                     '(2)
            SpParams.Add(.ErnCode)                                         '(3)
            SpNames.Add("ErnCod_Code")                                     '(3)
            SpParams.Add(.CreditAccount)                                   '(4)
            SpNames.Add("ErnInt_CreditAcc")                                '(4)
            SpParams.Add(.CreditConsol)                                    '(5)
            SpNames.Add("ErnInt_CreditConsolLevel")                        '(5)
            SpParams.Add(.DebitAccount)                                    '(6)
            SpNames.Add("ErnInt_DebitAcc")                                 '(6)
            SpParams.Add(.DebitConsol)                                     '(7)
            SpNames.Add("ErnInt_DebitConsolLevel")                         '(7)
            SpParams.Add(.CreditAnal)                                      '(8)
            SpNames.Add("ErnInt_CreditAnal")                               '(8)
            SpParams.Add(.Debitanal)                                       '(9)
            SpNames.Add("ErnInt_DebitAnal")                                '(9)
        End With
        SpNames.Add("NewId")                                             '(10)
        SpParams.Add(CInt(0))                                            '(10)
        If Me.StoredProcedure("AG_PrMsEarningsInterface_Save_Update", SpParams, SpNames, 10) Then
            If _cPrMsEarningsInterface.Id = 0 Then
                _cPrMsEarningsInterface.Id = DbNullToInt(SpParams(10))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
