' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 13/02/2008 09:42:51
'
'
Public Class cPrSsPayrollTypesDbTier
'
Inherits cDataTier
'
Protected Function GetByPK(ByVal tCode As String) as DataSet
Dim Str as String
Str = " SELECT" & _
        " PayTyp_Code," & _
        " PayTyp_DescriptionL," & _
        " PayTyp_DescriptionS," & _
        " PayTyp_IsActive" & _
    "  FROM PrSsPayrollTypes" & _
    "  WHERE PayTyp_Code = '" & tCode & "'"
Return MyBase.GetData(Str)
End Function
Protected Function Save(ByVal _cPrSsPayrollTypes AS cPrSsPayrollTypes) As Boolean
Dim SpParams As New ArrayList
Dim SpNames As New ArrayList
Dim Flag As Boolean = False
With _cPrSsPayrollTypes
   SpParams.Add(.Code)                                              '(0)
   SpNames.Add("PayTyp_Code")                                       '(0)
   SpParams.Add(.DescriptionL)                                      '(1)
   SpNames.Add("PayTyp_DescriptionL")                               '(1)
   SpParams.Add(.DescriptionS)                                      '(2)
   SpNames.Add("PayTyp_DescriptionS")                               '(2)
   SpParams.Add(.IsActive)                                          '(3)
   SpNames.Add("PayTyp_IsActive")                                   '(3)
End With
If Me.StoredProcedure("AG_PrSsPayrollTypes_Save_Update",SpParams,SpNames) Then
  Return True
Else
  Return False
End if
End Function
Protected Function Delete(ByVal tCode As String) as Boolean
Dim Str as String
Dim Flag As Boolean = True
Dim Exx As New System.Exception
   Try
         BeginTransaction()
         Str = " DELETE FROM PrSsPayrollTypes" & _
            " WHERE PayTyp_Code = '" & tCode & "'"
         If MyBase.ExecuteNonQuery(Str) = -1 Then
                 Throw Exx
         End If
         CommitTransaction()
   Catch ex as Exception
            Rollback()
            Utils.ShowException(ex)
            Flag = False
   End Try
Return Flag
End Function
Protected Function CheckDeleteRecords(ByVal tCode As String) as DataSet
Dim Str as String
Str = " " & _
"SELECT COUNT(PayTyp_Code) " & _
" FROM PrMsEmployees" & _
" WHERE PayTyp_Code = '" & tCode & "'" & _ 
" " & _
"SELECT COUNT(PayTyp_Code) " & _
" FROM PrMsTemplateGroup" & _
" WHERE PayTyp_Code = '" & tCode & "'" & _ 
" " & _
" "
Return GetData(Str)
End Function
End Class
