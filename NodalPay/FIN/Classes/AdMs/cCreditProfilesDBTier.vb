Public Class cCreditProfilesDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal Code As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " CrdPro_Code," & _
                " CrdPro_InvoiceType," & _
                " CrdPro_Description," & _
                " CrdPro_CreditTerms," & _
                " CrdPro_CreditDays" & _
                " FROM FiAdCreditProfiles" & _
                " WHERE CrdPro_Code = " & enQuoteString(Code)

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cFiAdCreditProfiles As cCreditProfiles) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False

        With _cFiAdCreditProfiles
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("CrdPro_Code")
            SpParams.Add(.InvoiceType)                                       '(1)
            SpNames.Add("CrdPro_InvoiceType")
            SpParams.Add(.Description)                                       '(2)
            SpNames.Add("CrdPro_Description")
            SpParams.Add(.CreditTerms)                                       '(3)
            SpNames.Add("CrdPro_CreditTerms")
            SpParams.Add(.CreditDays)                                        '(4)
            SpNames.Add("CrdPro_CreditDays")
        End With
        If Me.StoredProcedure("AG_FiAdCreditProfiles_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal Code As String) As Boolean
        ' note : this function closes the connection if you use programs that use an open connection comment out Cnx.Close lines
        '     closing connection does not affect dataset returning
        Dim Str As String
        Dim Flag As Boolean
        Try
            If Cnx.State <> ConnectionState.Open Then Cnx.Open()
            BeginTransaction()
            Str = " DELETE FROM FiAdCreditProfiles" & _
               " WHERE Code = '" & Code & "'"
            If MyBase.ExecuteNonQuery(Str) <> -1 Then
                CommitTransaction()
                Flag = True
                If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection 
            Else
                Rollback()
                Flag = False
                If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection
            End If
        Catch ex As Exception
            Rollback()
            Flag = False
            If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection
        End Try
        Return Flag
    End Function
    Protected Function CheckDeleteRecords() As DataSet
        Dim Str As String
        Str = " " & _
        "SELECT COUNT(CrdPro_Code FROM AdMsBusinessPartner" & _
        " " & _
        " "
        Return GetData(Str)
    End Function
End Class