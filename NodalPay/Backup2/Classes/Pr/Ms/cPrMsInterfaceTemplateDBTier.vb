Public Class cPrMsInterfaceTemplateDBTier
    Inherits cDataTier
    '
    Protected Function GetByCode(ByVal tIntTem_Code As String) As DataSet
        Dim Str As String
        Str = "SELECT IntTem_Code," & _
        " TemGrp_Code," & _
        " IntTem_Description " & _
        " From PrMsInterfaceTemplate " & _
        " WHERE (IntTem_Code=" & enQuoteString(tIntTem_Code) & ")"

        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByPK(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String) As DataSet
        Dim Str As String
        Str = "SELECT IntTem_Code," & _
        " TemGrp_Code," & _
        " IntTem_Description " & _
        " From PrMsInterfaceTemplate " & _
        " WHERE (IntTem_Code=" & enQuoteString(tIntTem_Code) & ")" & _
        " AND (TemGrp_Code =" & enQuoteString(tTemGrp_Code) & ")"

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsInterfaceTemplate As cPrMsInterfaceTemplate) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsInterfaceTemplate
            SpParams.Add(.IntTemCode)                                      '(0)
            SpNames.Add("IntTem_Code")                                     '(0)
            SpParams.Add(.TemGrpCode)                                      '(1)
            SpNames.Add("TemGrp_Code")                                     '(1)
            SpParams.Add(.IntTemDescription)                               '(2)
            SpNames.Add("IntTem_Description")                              '(2)
        End With

        If Me.StoredProcedure("AG_PrMsInterfaceTemplate_Save_Update", SpParams, SpNames) Then

            Return True
        Else
            Return False
        End If
    End Function
End Class
