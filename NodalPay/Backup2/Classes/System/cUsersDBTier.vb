Public Class cUsersDBTier
    Inherits cDataTier
    Protected Function GetByUser(ByVal User As String) As DataSet
        Dim str As String
        str = "Select Usr_id," & _
        " Usr_UserName," & _
        " Usr_FullName," & _
        " Usr_CreatedOn," & _
        " Usr_IsEnabled," & _
        " Usr_IsSa," & _
        " Usr_MyRole " & _
        " From AaSsUsers " & _
        " Where Usr_UserName=" & enQuoteString(User)
        Return getData(str)
    End Function
    Protected Function GetByUserID(ByVal Id As Integer) As DataSet
        Dim str As String
        str = "Select Usr_id," & _
        " Usr_UserName," & _
        " Usr_FullName," & _
        " Usr_CreatedOn," & _
        " Usr_IsEnabled," & _
        " Usr_IsSa," & _
        " Usr_MyRole " & _
        " From AaSsUsers " & _
        " Where Usr_Id=" & Id
        Return getData(str)
    End Function
End Class
