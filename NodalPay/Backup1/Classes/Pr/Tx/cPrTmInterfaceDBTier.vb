Public Class cPrTmInterfaceDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Id," & _
            " Acc_Code," & _
            " TemGrp_Code," & _
            " Emp_Code," & _
            " EDC_Code, " & _
            " Con_Level, " & _
            " Amount," & _
            " Anal0," & _
            " Anal1," & _
            " Anal2," & _
            " Anal3," & _
            " Anal4," & _
            " Anal5," & _
            " AnalUnion," & _
            " ExternalDoc," & _
            " IsCheque," & _
            " AccType," & _
            " Anal0Pos," & _
            " Anal1Pos," & _
            " Anal2Pos," & _
            " Anal3Pos," & _
            " Anal4Pos," & _
            " Anal5Pos," & _
            " AnalUnionPos, " & _
            " BalAccount, " & _
            " ReasonCode " & _
            " FROM  PrTmInterface" & _
            " WHERE Id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTmInterface As cPrTmInterface) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTmInterface
            SpParams.Add(.Id)                                               '(0)
            SpNames.Add("Id")                                               '(0)
            SpParams.Add(.Acc_Code)                                         '(1)
            SpNames.Add("Acc_Code")                                         '(1)
            SpParams.Add(.TemGrp_Code)                                      '(2)
            SpNames.Add("TemGrp_Code")                                      '(2)
            SpParams.Add(.Emp_Code)                                         '(3)
            SpNames.Add("Emp_Code")                                         '(3)
            SpParams.Add(.EDC_Code)                                         '(4)
            SpNames.Add("EDC_Code")                                         '(4)
            SpParams.Add(.Con_Level)                                        '(5)
            SpNames.Add("Con_Level")                                        '(5)
            SpParams.Add(.Amount)                                           '(6)
            SpNames.Add("Amount")                                           '(6)
            SpParams.Add(.Anal0)                                            '(7)
            SpNames.Add("Anal0")                                            '(7)
            SpParams.Add(.Anal1)                                            '(8)
            SpNames.Add("Anal1")                                            '(8)
            SpParams.Add(.Anal2)                                            '(9)
            SpNames.Add("Anal2")                                            '(9)
            SpParams.Add(.Anal3)                                            '(10)
            SpNames.Add("Anal3")                                            '(10)
            SpParams.Add(.Anal4)                                            '(11)
            SpNames.Add("Anal4")                                            '(11)
            SpParams.Add(.Anal5)                                            '(12)
            SpNames.Add("Anal5")                                            '(12)
            SpParams.Add(.AnalUnion)                                        '(13)
            SpNames.Add("AnalUnion")                                        '(13)
            SpParams.Add(.ExternalDoc)                                      '(14)
            SpNames.Add("ExternalDoc")                                      '(14)
            SpParams.Add(.IsCheque)                                         '(15)
            SpNames.Add("IsCheque")                                         '(15)
            SpParams.Add(.AccType)                                          '(16)
            SpNames.Add("AccType")                                          '(16)
            SpParams.Add(.Anal0Pos)                                         '(17)
            SpNames.Add("Anal0Pos")                                         '(17)
            SpParams.Add(.Anal1Pos)                                         '(18)
            SpNames.Add("Anal1Pos")                                         '(18)
            SpParams.Add(.Anal2Pos)                                         '(19)
            SpNames.Add("Anal2Pos")                                         '(19)
            SpParams.Add(.Anal3Pos)                                         '(20)
            SpNames.Add("Anal3Pos")                                         '(20)
            SpParams.Add(.Anal4Pos)                                         '(21)
            SpNames.Add("Anal4Pos")                                         '(21)
            SpParams.Add(.Anal5Pos)                                         '(22)
            SpNames.Add("Anal5Pos")                                         '(22)
            SpParams.Add(.AnalUnionPos)                                     '(23)
            SpNames.Add("AnalUnionPos")                                     '(23)
            SpParams.Add(.BalAccount)                                       '(24)
            SpNames.Add("BalAccount")                                       '(24)
            SpParams.Add(.ReasonCode)                                       '(25)
            SpNames.Add("ReasonCode")                                       '(25)


        End With
        SpParams.Add(CInt(0))                                               '(26)
        SpNames.Add("NewId")                                                '(26)

        If Me.StoredProcedure("PrTmInterface_Save_Update", SpParams, SpNames, 26) Then
            If _cPrTmInterface.Id = 0 Then
               
                _cPrTmInterface.Id = DbNullToInt(SpParams(26))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    
    
End Class
