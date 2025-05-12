Public Class cPrMsInterfaceCodesDBTier
    Inherits cDataTier
    '
    Protected Function GetByCode(ByVal tIntTem_Code As String) As DataSet
        Dim Str As String
        Str = "SELECT IntCod_Code," & _
        " TemGrp_Code," & _
        " IntCod_Description, " & _
        " IntCod_AccountType " & _
        " From PrMsInterfaceCodes " & _
        " WHERE (IntCod_Code=" & enQuoteString(tIntTem_Code) & ")"

        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String) As DataSet
        Dim Str As String
        Str = "SELECT IntCod_Code," & _
        " TemGrp_Code," & _
        " IntCod_Description, " & _
        " IntCod_AccountType " & _
        " From PrMsInterfaceCodes " & _
        " WHERE (IntCod_Code=" & enQuoteString(tIntTem_Code) & ")" & _
        " AND (TemGrp_Code =" & enQuoteString(tTemGrp_Code) & ")"

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsInterfaceCode As cPrMsInterfaceCodes) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsInterfaceCode
            SpParams.Add(.Code)                                            '(0)
            SpNames.Add("IntCod_Code")                                     '(0)
            SpParams.Add(.TemGrpCode)                                      '(1)
            SpNames.Add("TemGrp_Code")                                     '(1)
            SpParams.Add(.Description)                                     '(2)
            SpNames.Add("IntCod_Description")                              '(2)
            SpParams.Add(.AccountType)                                     '(3)
            SpNames.Add("IntCod_AccountType")                              '(3)

        End With

        If Me.StoredProcedure("AG_PrMsInterfaceCodes_Save_Update", SpParams, SpNames) Then

            Return True
        Else
            Return False
        End If
    End Function
End Class
