Public Class cEmploymentHistoryDBTier
    Inherits cDataTier
    '
    Protected Function GetByID(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT " & _
        " EmpHis_Id, " & _
        " Emp_code," & _
        " Emp_StartDate," & _
        " Emp_EndDate" & _
        " FROM PrTxEmploymentHistory " & _
        " Where EmpHis_Id=" & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cEmpHis As cEmploymentHistory) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cEmpHis
            SpParams.Add(.Id)                                              '(0)
            SpNames.Add("EmpHis_Id")                                       '(0)
            SpParams.Add(.EmpCode)                                         '(1)
            SpNames.Add("Emp_Code")                                        '(1)
            SpParams.Add(.StartDate)                                       '(2)
            SpNames.Add("Emp_StartDate")                                   '(2)
            SpParams.Add(.EndDate)                                         '(3)
            SpNames.Add("Emp_EndDate")                                     '(3)
        End With
        SpNames.Add("NewId")                                                 '(4)
        SpParams.Add(CInt(0))                                                '(4)
        If Me.StoredProcedure("PrTxEmploymentHistory_Save_Update", SpParams, SpNames, 4) Then
            Return True
        Else
            Return False
        End If
    End Function










End Class
