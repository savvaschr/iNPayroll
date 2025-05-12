Public Class cPrMsRemindersDBTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = "SELECT Rem_Id, " & _
            " Emp_Code, " & _
            " Rem_Description, " & _
            " Rem_ReminderDate, " & _
            " Rem_IsActive, " & _
            " Rem_CreatedBy, " & _
            " Rem_CreatedAt, " & _
            " Rem_DeactivatedBy,  " & _
            " Rem_DeactivatedAt " & _
            " FROM PrMsReminders " & _
            "  WHERE Rem_Id = " & tId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrMsReminder As cPrMsReminders) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsReminder
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("Rem_id")                                            '(0)
            SpParams.Add(.EmpCode)                                           '(1)
            SpNames.Add("Emp_Code")                                          '(1)
            SpParams.Add(.Description)                                       '(2)
            SpNames.Add("Rem_Description")                                   '(2)
            SpParams.Add(.ReminderDate)                                      '(3)
            SpNames.Add("Rem_reminderDate")                                  '(3)
            SpParams.Add(.IsActive)                                          '(4)
            SpNames.Add("Rem_IsActive")                                      '(4)
            SpParams.Add(.CreatedBy)                                         '(5)
            SpNames.Add("Rem_CreatedBy")                                     '(5)
            SpParams.Add(.CreatedAt)                                         '(6)
            SpNames.Add("Rem_CreatedAt")                                     '(6)
            SpParams.Add(.DeactivatedBy)                                     '(7)
            SpNames.Add("Rem_DeactivatedBy")                                 '(7)
            SpParams.Add(.DeactivatedAt)                                     '(8)
            SpNames.Add("Rem_DeactivatedAt")                                 '(8)
            
        End With
        SpNames.Add("NewId")                                             '(9)
        SpParams.Add(CInt(0))                                            '(9)
        If Me.StoredProcedure("AG_PrMsReminders_SAVE_UPDATE", SpParams, SpNames, 9) Then
            If _cPrMsReminder.Id = 0 Then
                _cPrMsReminder.Id = DbNullToInt(SpParams(9))
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
            Str = " DELETE FROM PrMsreminders" & _
               " WHERE Rem_id = " & tId
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
  
End Class

