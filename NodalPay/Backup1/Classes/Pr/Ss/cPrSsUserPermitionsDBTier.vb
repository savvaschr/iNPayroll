Public Class cPrSsUserPermitionsDBTier
    Inherits cDataTier
    Protected Function GetByKey(ByVal ComCode As String, ByVal UserCode As String, ByVal Entity As String) As DataSet
        Dim Str As String
        Str = " SELECT UsrAth_Id," & _
        " Com_Code," & _
        " Usr_Code," & _
        " UsrAth_Entity," & _
        " UsrAth_Full," & _
        " UsrAth_ReadOnly," & _
        " UsrAth_No" & _
        " FROM PrSsUserPermition" & _
        " Where Com_Code=" & enQuoteString(ComCode) & _
        " AND Usr_Code=" & enQuoteString(UserCode) & _
        " AND UsrAth_Entity=" & enQuoteString(Entity)
        Return getdata(Str)

    End Function
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = " SELECT UsrAth_Id," & _
        " Com_Code," & _
        " Usr_Code," & _
        " UsrAth_Entity," & _
        " UsrAth_Full," & _
        " UsrAth_ReadOnly," & _
        " UsrAth_No" & _
        " FROM PrSsUserPermition" & _
        " Where UsrAth_Id=" & Id
        
        Return GetData(Str)

    End Function
    Protected Function Save(ByVal UserPermition As cPrSsUserPermitions)
        Dim Str As String
        Dim F As Boolean = False
        With UserPermition
            If .id > 0 Then
                Str = " Update PrSsUserPermition Set " & _
                " Com_Code=" & enQuoteString(.ComCode) & _
                " , Usr_Code=" & enQuoteString(.UserCode) & _
                " , UsrAth_Entity=" & enQuoteString(.Entity) & _
                " , UsrAth_full=" & .FullPermission & _
                " , UsrAth_ReadOnly=" & .ReadonlyPermission & _
                " , UsrAth_No=" & .NoPermission & _
                " Where UsrAth_Id=" & .id
            Else
                Str = " Insert into PrSsUserPermition " & _
                " (Com_Code " & _
                " ,Usr_Code" & _
                " ,UsrAth_Entity" & _
                " , UsrAth_full" & _
                " , UsrAth_ReadOnly" & _
                " , UsrAth_No)" & _
                " Values " & _
                "( " & enQuoteString(.ComCode) & _
                ", " & enQuoteString(.UserCode) & _
                ", " & enQuoteString(.Entity) & _
                ", " & .FullPermission & _
                ", " & .ReadonlyPermission & _
                ", " & .NoPermission & _
                ")"

            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            F = True
        Else
            F = False
        End If
        Return F
    End Function

End Class
