Public Class cFiTrxnGroupsDBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal Code As String, ByVal TypeCode As String)
        Dim Str As String
        Str = "SELECT" & _
             " TrxGrp_Code," & _
             " TrxTyp_Code," & _
             " TrxGrp_DescriptionL," & _
             " TrxGrp_DescriptionS," & _
             " TrxGrp_IsActive," & _
             " TrxGrp_FiType," & _
             " TrxGrp_MultFactor" & _
             " FROM FiAdTrxnGroups " & _
             " WHERE TrxGrp_Code = " & enQuoteString(Code) & _
             " AND TrxTyp_Code = " & enQuoteString(Typecode)

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cFiTrxnGroups As cFiTrxnGroups) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cFiTrxnGroups

            
            SpParams.Add(.Code)                 ' (0)
            SpNames.Add("TrxGrp_Code")
            SpParams.Add(.TypeCode)             ' (1)
            SpNames.Add("TrxTyp_Code")
            SpParams.Add(.DescriptionL)         ' (2)
            SpNames.Add("TrxGrp_DescriptionL")
            SpParams.Add(.DescriptionS)         ' (3)
            SpNames.Add("TrxGrp_DescriptionS")
            SpParams.Add(.IsActive)             ' (4)
            SpNames.Add("TrxGrp_IsActive")
            SpParams.Add(.FiType)               ' (5)
            SpNames.Add("TrxGrp_FiType")
            SpParams.Add(.MultFactor)           ' (6)
            SpNames.Add("TrxGrp_MultFactor")
        End With

        If Me.StoredProcedure("AG_FiAdTrxnGroups_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

