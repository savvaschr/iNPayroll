Public Class cPrTxPositionHistoryDBTier
    Inherits cDataTier
    '
    Protected Function GetByID(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT " & _
        " PosHis_Id, " & _
        " Emp_code," & _
        " Pos_Code," & _
        " Pos_Desc," & _
        " Pos_Date " & _
        " FROM PrTxPositionsHistory " & _
        " Where PosHis_Id=" & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPosHis As cPrTxPositionHistory) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPosHis
            SpParams.Add(.Id)                                              '(0)
            SpNames.Add("PosHis_Id")                                       '(0)
            SpParams.Add(.EmpCode)                                         '(1)
            SpNames.Add("Emp_Code")                                        '(1)
            SpParams.Add(.PosCode)                                         '(2)
            SpNames.Add("Pos_Code")                                        '(2)
            SpParams.Add(.PosDesc)                                         '(3)
            SpNames.Add("Pos_Desc")                                        '(3)
            SpParams.Add(.PosDate)                                         '(4)
            SpNames.Add("Pos_Date")                                        '(4)

        End With
        SpNames.Add("NewId")                                                 '(5)
        SpParams.Add(CInt(0))                                                '(5)
        If Me.StoredProcedure("PrTxPositionHistory_Save_Update", SpParams, SpNames, 5) Then

            Return True
        Else
            Return False
        End If
    End Function

End Class
