Public Class cPrAnScales2DbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tSc2_Code As String) As DataSet
        Dim Str As String
        Str = " SELECT" &
                " Sc2_Code," &
                " Sc2_Description" &
            "  FROM PrAnScales2" &
            "  WHERE Sc2_Code = '" & tSc2_Code & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrAnScales2 As cPrAnScales2) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrAnScales2
            SpParams.Add(.Sc2_Code)                                          '(0)
            SpNames.Add("Sc2_Code")                                          '(0)
            SpParams.Add(.Sc2_Description)                                   '(1)
            SpNames.Add("Sc2_Description")                                   '(1)
        End With
        If Me.StoredProcedure("AG_PrAnScales2_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tSc2_Code As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrAnScales2" &
               " WHERE Sc2_Code = '" & tSc2_Code & "'"
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
        '    Generation Note : 01/08/2024 13:26:04 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function
End Class

