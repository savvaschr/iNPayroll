Public Class cPrMsDeductionsInterfaceDBTier
    Inherits cDataTier
    '
    Protected Function GetById(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = "SELECT DedInt_Id," & _
        " IntTem_Code," & _
        " TemGrp_Code," & _
        " DedCod_Code, " & _
        " DedInt_CreditAcc," & _
        " DedInt_CreditConsolLevel," & _
        " DedInt_DebitAcc," & _
        " DedInt_DebitConsolLevel," & _
        " DedInt_CreditAnal," & _
        " DedInt_DebitAnal" & _
        " FROM PrMsDeductionsInterface" & _
        " WHERE (DedInt_Id=" & tId & ")"
        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String, ByVal tDedCode As String) As DataSet
        Dim Str As String
        Str = "SELECT DedInt_Id," & _
           " IntTem_Code," & _
           " TemGrp_Code," & _
           " DedCod_Code, " & _
           " DedInt_CreditAcc," & _
           " DedInt_CreditConsolLevel," & _
           " DedInt_DebitAcc, " & _
           " DedInt_DebitConsolLevel," & _
           " DedInt_CreditAnal," & _
           " DedInt_DebitAnal" & _
           " FROM PrMsDeductionsInterface" & _
           " WHERE (TemGrp_Code =" & enQuoteString(tTemGrp_Code) & ")" & _
           " AND (IntTem_Code = " & enQuoteString(tIntTem_Code) & ")" & _
           " AND (DedCod_Code = " & enQuoteString(tDedCode) & ")"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrMsDeductionsInterface As cPrMsDeductionsInterface) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsDeductionsInterface
            SpParams.Add(.Id)                                              '(0)
            SpNames.Add("DedInt_Id")                                       '(0)
            SpParams.Add(.IntTemCode)                                      '(1)
            SpNames.Add("IntTem_Code")                                     '(1)
            SpParams.Add(.TemGrpCode)                                      '(2)
            SpNames.Add("TemGrp_Code")                                     '(2)
            SpParams.Add(.DedCode)                                         '(3)
            SpNames.Add("DedCod_Code")                                     '(3)
            SpParams.Add(.CreditAccount)                                   '(4)
            SpNames.Add("DedInt_CreditAcc")                                '(4)
            SpParams.Add(.CreditConsol)                                    '(5)
            SpNames.Add("DedInt_CreditConsolLevel")                        '(5)
            SpParams.Add(.DebitAccount)                                    '(6)
            SpNames.Add("DedInt_DebitAcc")                                 '(6)
            SpParams.Add(.DebitConsol)                                     '(7)
            SpNames.Add("DedInt_DebitConsolLevel")                         '(7)
            SpParams.Add(.CreditAnal)                                      '(8)
            SpNames.Add("DedInt_CreditAnal")                               '(8)
            SpParams.Add(.Debitanal)                                       '(9)
            SpNames.Add("DedInt_DebitAnal")                                '(9)
        End With
        SpNames.Add("NewId")                                             '(10)
        SpParams.Add(CInt(0))                                            '(10)
        If Me.StoredProcedure("AG_PrMsDeductionsInterface_Save_Update", SpParams, SpNames, 10) Then
            If _cPrMsDeductionsInterface.Id = 0 Then
                _cPrMsDeductionsInterface.Id = DbNullToInt(SpParams(10))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
