Public Class cLocationDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select Loc_Code," & _
        "Loc_DescriptionL," & _
        "Loc_DescriptionS," & _
        "LocTyp_Code From MmMsLocation Where Loc_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cLocation As cLocation) As Boolean
        Dim Str As String
        With _cLocation
            If .Code = 0 Then
                Str = "INSERT INTO MmMsLocation(" & _
                "Loc_Code," & _
                "Loc_DescriptionL," & _
                "Loc_DescriptionS," & _
                "LocTyp_Code)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.DescL) & "," & _
                enQuoteString(.DescS) & "," & _
                enQuoteString(.LocTypeCode) & ")"
            Else
                Str = "Update MmMsLocation" & _
                " SET Loc_DescriptionL = " & enQuoteString(.DescL) & _
                ",Loc_DescriptionS = " & enQuoteString(.DescS) & _
                ",LocTyp_Code = " & enQuoteString(.LocTypeCode) & _
                " Where Loc_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
