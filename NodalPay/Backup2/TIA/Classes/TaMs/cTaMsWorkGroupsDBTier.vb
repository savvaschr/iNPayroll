Public Class cTaMsWorkGroupsDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT WrkGrp_Id," & _
            " WrkGrp_Code," & _
            " WrkGrp_Desc," & _
            " WrkGrp_IsActive" & _
            " FROM  TaMsWorkGroup" & _
            " WHERE (WrkGrp_Id =" & Id & ")"
        Return GetData(Str)

    End Function
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = " SELECT WrkGrp_Id," & _
            " WrkGrp_Code," & _
            " WrkGrp_Desc," & _
            " WrkGrp_IsActive" & _
            " FROM  TaMsWorkGroup" & _
            " WHERE (WrkGrp_Code =" & enQuoteString(Code) & ")"


        Return GetData(Str)

    End Function
    Protected Function Save(ByRef _cWorkGroups As cTaMsWorkGroups) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False

        With _cWorkGroups
            SpParams.Add(.Id)                                    '0
            SpNames.Add("WrkGrp_Id")
            SpParams.Add(.Code)                                  '1
            SpNames.Add("WrkGrp_Code")
            SpParams.Add(.Desc)                                  '2
            SpNames.Add("WrkGrp_Desc")
            SpParams.Add(.IsActive)                              '3
            SpNames.Add("WrkGrp_IsActive")
            SpParams.Add(CInt(0))                                '4
            SpNames.Add("NewId")
        End With
        If Me.StoredProcedure("TaMsWorkGroup_Save_Update", SpParams, SpNames, 5) Then
            _cWorkGroups.Id = DbNullToInt(SpParams(4))
            Return True
        Else
            Return False
        End If
    End Function
End Class
