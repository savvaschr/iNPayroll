Public Class cPrMsContributionsInterfaceDBTier
    Inherits cDataTier
    '
    Protected Function GetById(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = "SELECT ConInt_Id," & _
        " IntTem_Code," & _
        " TemGrp_Code," & _
        " ConCod_Code, " & _
        " ConInt_CreditAcc," & _
        " ConInt_CreditConsolLevel," & _
        " ConInt_DebitAcc, " & _
        " ConInt_DebitConsolLevel," & _
        " ConInt_CreditAnal," & _
        " ConInt_DebitAnal " & _
        " FROM PrMsContributionsInterface" & _
        " WHERE (DedInt_Id=" & tId & ")"
        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String, ByVal tConCode As String) As DataSet
        Dim Str As String
        Str = "SELECT ConInt_Id," & _
           " IntTem_Code," & _
           " TemGrp_Code," & _
           " ConCod_Code, " & _
           " ConInt_CreditAcc," & _
           " ConInt_CreditConsolLevel," & _
           " ConInt_DebitAcc, " & _
           " ConInt_DebitConsolLevel," & _
           " ConInt_CreditAnal," & _
           " ConInt_DebitAnal " & _
           " FROM PrMsContributionsInterface" & _
           " WHERE (TemGrp_Code =" & enQuoteString(tTemGrp_Code) & ")" & _
           " AND (IntTem_Code = " & enQuoteString(tIntTem_Code) & ")" & _
           " AND (ConCod_Code = " & enQuoteString(tConCode) & ")"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrMsContributionsInterface As cPrMsContributionsInterface) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsContributionsInterface
            SpParams.Add(.Id)                                              '(0)
            SpNames.Add("ConInt_Id")                                       '(0)
            SpParams.Add(.IntTemCode)                                      '(1)
            SpNames.Add("IntTem_Code")                                     '(1)
            SpParams.Add(.TemGrpCode)                                      '(2)
            SpNames.Add("TemGrp_Code")                                     '(2)
            SpParams.Add(.ConCode)                                         '(3)
            SpNames.Add("ConCod_Code")                                     '(3)
            SpParams.Add(.CreditAccount)                                   '(4)
            SpNames.Add("ConInt_CreditAcc")                                '(4)
            SpParams.Add(.CreditConsol)                                    '(5)
            SpNames.Add("ConInt_CreditConsolLevel")                        '(5)
            SpParams.Add(.DebitAccount)                                    '(6)
            SpNames.Add("ConInt_DebitAcc")                                 '(6)
            SpParams.Add(.DebitConsol)                                     '(7)
            SpNames.Add("ConInt_DebitConsolLevel")                         '(7)
            SpParams.Add(.CreditAnal)                                      '(8)
            SpNames.Add("ConInt_CreditAnal")                               '(8)
            SpParams.Add(.Debitanal)                                       '(9)
            SpNames.Add("ConInt_DebitAnal")                                '(9)
        End With
        SpNames.Add("NewId")                                             '(10)
        SpParams.Add(CInt(0))                                            '(10)
        If Me.StoredProcedure("AG_PrMsContributionsInterface_Save_Update", SpParams, SpNames, 10) Then
            If _cPrMsContributionsInterface.Id = 0 Then
                _cPrMsContributionsInterface.Id = DbNullToInt(SpParams(10))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
