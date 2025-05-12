Public Class cMobulesDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select Mdl_Code," & _
        "Mdl_Description," & _
        "Mdl_IsEnabled" & _
        " From AaSsMobules Where Mdl_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cMobules As cMobules) As Boolean
        Dim Str As String
        With _cMobules
            If .Code = 0 Then
                Str = "INSERT INTO AaSsMobules(" & _
                "Mdl_Code," & _
                "Mdl_Description," & _
                "Mdl_IsEnabled)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.Desc) & "," & _
                enQuoteString(.IsEnabled) & ")"
            Else
                Str = "Update AaSsMobules" & _
                " SET Mdl_Description = " & enQuoteString(.Desc) & _
                ",Mdl_IsEnabled = " & enQuoteString(.IsEnabled) & _
                " Where Mdl_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


End Class

