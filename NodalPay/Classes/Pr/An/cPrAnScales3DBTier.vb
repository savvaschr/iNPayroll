Public Class cPrAnScales3DBTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tSc3_Code As String) As DataSet
        Dim Str As String
        Str = " SELECT" &
                " Sc3_Code," &
                " Sc3_Description" &
            "  FROM PrAnScales3" &
            "  WHERE Sc3_Code = '" & tSc3_Code & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrAnScales3 As cPrAnScales3) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrAnScales3
            SpParams.Add(.Sc3_Code)                                          '(0)
            SpNames.Add("Sc3_Code")                                          '(0)
            SpParams.Add(.Sc3_Description)                                   '(1)
            SpNames.Add("Sc3_Description")                                   '(1)
        End With
        If Me.StoredProcedure("AG_PrAnScales3_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tSc3_Code As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrAnScales3" &
               " WHERE Sc3_Code = '" & tSc3_Code & "'"
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



