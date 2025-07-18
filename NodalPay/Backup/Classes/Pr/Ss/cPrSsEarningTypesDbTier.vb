' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 13/02/2008 09:42:50
'
'
Public Class cPrSsEarningTypesDbTier
'
Inherits cDataTier
'
Protected Function GetByPK(ByVal tCode As String) as DataSet
Dim Str as String
Str = " SELECT" & _
        " ErnTyp_Code," & _
        " ErnTyp_DescriptionL," & _
        " ErnTyp_DescriptionS," & _
        " ErnTyp_TableSequence" & _
    "  FROM PrSsEarningTypes" & _
    "  WHERE ErnTyp_Code = '" & tCode & "'"
Return MyBase.GetData(Str)
End Function
Protected Function Save(ByVal _cPrSsEarningTypes AS cPrSsEarningTypes) As Boolean
Dim SpParams As New ArrayList
Dim SpNames As New ArrayList
Dim Flag As Boolean = False
With _cPrSsEarningTypes
   SpParams.Add(.Code)                                              '(0)
   SpNames.Add("ErnTyp_Code")                                       '(0)
   SpParams.Add(.DescriptionL)                                      '(1)
   SpNames.Add("ErnTyp_DescriptionL")                               '(1)
   SpParams.Add(.DescriptionS)                                      '(2)
   SpNames.Add("ErnTyp_DescriptionS")                               '(2)
   SpParams.Add(.Sequence)                                          '(3)
   SpNames.Add("ErnTyp_TableSequence")                              '(3)
End With
If Me.StoredProcedure("AG_PrSsEarningTypes_Save_Update",SpParams,SpNames) Then
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
         Str = " DELETE FROM PrSsEarningTypes" & _
            " WHERE ErnTyp_Code = '" & tCode & "'"
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
"SELECT COUNT(ErnTyp_Code) " & _
" FROM PrMsEarningCodes" & _
" WHERE ErnTyp_Code = '" & tCode & "'" & _ 
" " & _
" "
Return GetData(Str)
End Function
End Class
