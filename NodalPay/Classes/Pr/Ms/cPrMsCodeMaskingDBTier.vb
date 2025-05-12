Public Class cPrMsCodeMaskingDBTier
    Inherits cDataTier
    '
    Protected Function GetById(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " CodMsk_Id," & _
                " IntCod_Code," & _
                " CodMsk_Position," & _
                " CodMsk_Type," & _
                " CodMsk_Value " & _
            "  FROM PrMsCodeMasking " & _
            "  WHERE CodMsk_Id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsCodeMasking As cPrMsCodeMasking) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsCodeMasking
            SpParams.Add(.id)                                        '(0)
            SpNames.Add("CodMsk_Id")                                 '(0)
            SpParams.Add(.IntCode)                                   '(1)
            SpNames.Add("IntCod_code")                               '(1)
            SpParams.Add(.Position)                                  '(2)
            SpNames.Add("CodMsk_Position")                           '(2)
            SpParams.Add(.Type)                                      '(3)
            SpNames.Add("CodMsk_Type")                               '(3)
            SpParams.Add(.Value)                                     '(4)
            SpNames.Add("CodMsk_Value")                              '(4)
        End With
        SpNames.Add("NewId")                                         '(5)
        SpParams.Add(CInt(0))                                        '(5)
        If Me.StoredProcedure("AG_PrMsCodeMasking_Save_Update", SpParams, SpNames, 5) Then
            If _cPrMsCodeMasking.id = 0 Then
                _cPrMsCodeMasking.id = DbNullToInt(SpParams(5))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    
End Class
