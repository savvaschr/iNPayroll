Public Class cPrSsEmployeeSplitDBTier
   

    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT Spl_id, " & _
        " Emp_Code, " & _
        " Spl_Description, " & _
        " Spl_Value,  " & _
        " Spl_Enabled, " & _
        " Spl_NoOfPeriods, " & _
        " Spl_IsPF,  " & _
        " Spl_IsST, " & _
        " Spl_CreationDate, " & _
        " Spl_CreatedBy, " & _
        " Spl_AmendDate,  " & _
        " Spl_AmendedBy,  " & _
        " Spl_ActivePeriods  " & _
        " FROM PrSsEmployeeSplit " & _
        " WHERE Spl_id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrSsEmployeeSplit As cPrSsEmployeeSplit) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
     
        With _cPrSsEmployeeSplit
            SpParams.Add(.id)                                             '(0)
            SpNames.Add("Spl_id")                                         '(0)
            SpParams.Add(.EmpCode)                                        '(1)
            SpNames.Add("Emp_Code")                                       '(1)
            SpParams.Add(.Description)                                    '(2)
            SpNames.Add("Spl_Description")                                '(2)
            SpParams.Add(.myValue)                                        '(3)
            SpNames.Add("Spl_Value")                                      '(3)
            SpParams.Add(.Enabled)                                        '(4)
            SpNames.Add("Spl_Enabled")                                    '(4)
            SpParams.Add(.NoOfPeriods)                                    '(5)
            SpNames.Add("Spl_NoOfPeriods")                                '(5)
            SpParams.Add(.IsPF)                                           '(6)
            SpNames.Add("Spl_IsPF")                                       '(6)
            SpParams.Add(.IsST)                                           '(7)
            SpNames.Add("Spl_IsST")                                       '(7)
            SpParams.Add(.CreationDate)                                   '(8)
            SpNames.Add("Spl_CreationDate")                               '(8)
            SpParams.Add(.CreatedBy)                                      '(9)
            SpNames.Add("Spl_CreatedBy")                                  '(9)
            SpParams.Add(.AmendDate)                                      '(10)
            SpNames.Add("Spl_AmendDate")                                  '(10)
            SpParams.Add(.AmendedBy)                                      '(11)
            SpNames.Add("Spl_AmendedBy")                                  '(11)
            SpParams.Add(.ActivePeriods)                                      '(12)
            SpNames.Add("Spl_ActivePeriods")                                  '(12)
        End With
        SpNames.Add("NewId")                                             '(13)
        SpParams.Add(CInt(0))                                            '(13)
        If Me.StoredProcedure("PrSsEmployeeSplit_Save_Update", SpParams, SpNames, 13) Then
            If _cPrSsEmployeeSplit.id = 0 Then
                _cPrSsEmployeeSplit.id = DbNullToInt(SpParams(13))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tId As Integer) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrSsEmployeeSplit" & _
               " WHERE Spl_id = " & tId
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
    Protected Function CheckDeleteRecords(ByVal tCode As Integer) As DataSet
        Dim ds As DataSet
        '    Generation Note : 20/05/2008 10:39:17 :- No Foriegn Key Constraints where found
        ds = Nothing
        Return ds
    End Function

End Class
