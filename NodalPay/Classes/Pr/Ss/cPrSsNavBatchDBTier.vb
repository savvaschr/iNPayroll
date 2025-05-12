Public Class cPrSsNavBatchDBTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " GenBat_Id," & _
                " GenBat_IdFrom," & _
                " GenBat_IdTo," & _
                " TmpGrp_Code," & _
                " GenBat_User," & _
                " GenBat_FirstCreation," & _
                " GenBat_LastCreation," & _
                " GenBat_Times " & _
            "  FROM PrSsNavBatch" & _
            "  WHERE GenBat_Id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrSsNavBatch As cPrSsNavBatch) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrSsnavbatch
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("GenBat_Id")                                         '(0)
            SpParams.Add(.IdFrom)                                            '(1)
            SpNames.Add("GenBat_IdFrom")                                     '(1)
            SpParams.Add(.IdTo)                                              '(2)
            SpNames.Add("GenBat_IdTo")                                       '(2)
            SpParams.Add(.TemGrpCode)                                        '(3)
            SpNames.Add("TmpGrp_Code")                                       '(3)
            SpParams.Add(.User)                                              '(4)
            SpNames.Add("GenBat_User")                                       '(4)
            SpParams.Add(.FirstCreation)                                     '(5)
            SpNames.Add("GenBat_FirstCreation")                              '(5)
            SpParams.Add(.LastCreation)                                      '(6)
            SpNames.Add("GenBat_LastCreation")                               '(6)
            SpParams.Add(.Times)                                             '(7)
            SpNames.Add("GenBat_Times")                                      '(7)
        End With
        SpNames.Add("NewId")                                             '(8)
        SpParams.Add(CInt(0))                                            '(8)
        If Me.StoredProcedure("AG_PrSsNavBatch_Save_Update", SpParams, SpNames, 8) Then
            If _cPrSsNavBatch.Id = 0 Then
                _cPrSsNavBatch.Id = DbNullToInt(SpParams(8))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
