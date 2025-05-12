Public Class cPrSsSocialCohesionDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " SocCoh_Code," & _
                " SocCoh_Desc," & _
                " SocCoh_DedValue," & _
                " SocCoh_ConValue" & _
            "  FROM PrSsSocialCohesion " & _
            "  WHERE SocCoh_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrSsSocialCohesion As cPrSsSocialCohesion) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrSsSocialCohesion
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("SocCoh_Code")                                       '(0)
            SpParams.Add(.Desc)                                              '(1)
            SpNames.Add("SocCoh_Desc")                                       '(1)
            SpParams.Add(.DedValue)                                          '(2)
            SpNames.Add("SocCoh_DedValue")                                   '(2)
            SpParams.Add(.ConValue)                                          '(3)
            SpNames.Add("SocCoh_ConValue")                                   '(3)
        End With
        If Me.StoredProcedure("AG_PrSsSocialCohesion_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tCode As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrSsSocialCohesion" & _
               " WHERE SocCoh_Code = '" & tCode & "'"
            If MyBase.ExecuteNonQuery(Str) = -1 Then
                Throw Exx
            End If
            CommitTransaction()
        Catch ex As Exception
            Rollback()
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Protected Function CheckDeleteRecords(ByVal tCode As String) As DataSet
        Dim ds As DataSet
        '    Generation Note : 30/06/2008 10:18:54 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function
End Class
