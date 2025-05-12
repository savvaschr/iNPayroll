Public Class cFiTrxnTypeDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal Code As String)
        Dim Str As String
        Str = "SELECT" & _
            " TrxTyp_Code," & _
            " TrxTyp_DescriptionL," & _
            " TrxTyp_DescriptionS," & _
            " TrxTyp_IsActive" & _
            " FROM FiAdTrxnTypes & " & _
            " WHERE TrxTyp_Code = " & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cFiTrxnTypes As cFiTrxnType) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cFiTrxnTypes
            SpParams.Add(.Code)                 ' (0)
            SpNames.Add("TrxTyp_Code")
            SpParams.Add(.DescriptionL)         ' (1)
            SpNames.Add("TrxTyp_DescriptionL")
            SpParams.Add(.DescriptionS)         ' (2)
            SpNames.Add("TrxTyp_DescriptionS")
            SpParams.Add(.IsActive)             ' (3)
            SpNames.Add("TrxTyp_IsActive")
        End With
        If Me.StoredProcedure("AG_FiAdTrxnTypes_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
