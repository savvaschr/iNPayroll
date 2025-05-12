Public Class cTaMsWorkCodesDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT WrkCod_Id," & _
            " WrkCod_Code," & _
            " WrkGrp_Code," & _
            " WrkCod_Desc," & _
            " WrkCod_IsActive," & _
            " WrkCod_Type," & _
            " Int_Code" & _
            " FROM  TaMsWorkCodes" & _
            " WHERE (WrkCod_Id =" & Id & ")"

        Return GetData(Str)

    End Function
    Protected Function GetByCodeAndGroup(ByVal Code As String, ByVal GroupCode As String) As DataSet
        Dim Str As String
        Str = " SELECT WrkCod_Id," & _
            " WrkCod_Code," & _
            " WrkGrp_Code," & _
            " WrkCod_Desc," & _
            " WrkCod_IsActive," & _
            " WrkCod_Type," & _
            " Int_Code" & _
            " FROM  TaMsWorkCodes" & _
            " WHERE (WrkCod_Code =" & enQuoteString(Code) & ")" & _
            " AND (WrkGrp_Code =" & enQuoteString(GroupCode) & ")"

        Return GetData(Str)
    End Function
    Protected Function Save(ByRef _cWorkCodes As cTaMsWorkCodes) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False

        With _cWorkCodes
            SpParams.Add(.Id)                                    '0
            SpNames.Add("WrkCod_Id")
            SpParams.Add(.Code)                                  '1
            SpNames.Add("WrkCod_Code")
            SpParams.Add(.GroupCode)                             '2
            SpNames.Add("WrkGrp_Code")
            SpParams.Add(.Desc)                                  '3
            SpNames.Add("WrkCod_Desc")
            SpParams.Add(.IsActive)                              '4
            SpNames.Add("WrkCod_IsActive")
            SpParams.Add(.Mytype)                              '4
            SpNames.Add("WrkCod_Type")
            SpParams.Add(.IntCode)                              '4
            SpNames.Add("Int_Code")
            SpParams.Add(CInt(0))                                '5
            SpNames.Add("NewId")
        End With
        If Me.StoredProcedure("TaMsWorkCodes_Save_Update", SpParams, SpNames, 6) Then
            _cWorkCodes.Id = DbNullToInt(SpParams(6))
            Return True
        Else
            Return False
        End If
    End Function
End Class
