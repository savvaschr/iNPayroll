' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 13/02/2008 09:42:45
'
'
Public Class cAaSsParametersDbTier
'
Inherits cDataTier
'
Protected Function GetByPK(ByVal tId As Integer) as DataSet
Dim Str as String
Str = " SELECT" & _
        " Par_Id," & _
        " Par_Section," & _
        " Par_Item," & _
        " Par_Value," & _
        " Par_Description," & _
        " Par_System," & _
        " Par_Type" & _
    "  FROM AaSsParameters" & _
    "  WHERE Par_Id = " & tId
Return MyBase.GetData(Str)
    End Function
    Protected Function GetBySectionItem(ByVal Section As String, ByVal Item As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " Par_Id," & _
                " Par_Section," & _
                " Par_Item," & _
                " Par_Value," & _
                " Par_Description," & _
                " Par_System," & _
                " Par_Type" & _
            "  FROM AaSsParameters" & _
            "  WHERE Par_Section= " & enQuoteString(Section) & _
            "  And Par_Item= " & enQuoteString(Item)
        Return MyBase.GetData(Str)
    End Function
Protected Function Save(ByRef _cAaSsParameters AS cAaSsParameters) As Boolean
Dim SpParams As New ArrayList
Dim SpNames As New ArrayList
Dim Flag As Boolean = False
With _cAaSsParameters
   SpParams.Add(.Id)                                                '(0)
   SpNames.Add("Par_Id")                                            '(0)
   SpParams.Add(.Section)                                           '(1)
   SpNames.Add("Par_Section")                                       '(1)
   SpParams.Add(.Item)                                              '(2)
   SpNames.Add("Par_Item")                                          '(2)
   SpParams.Add(.Value1)                                            '(3)
   SpNames.Add("Par_Value")                                         '(3)
   SpParams.Add(.Description)                                       '(4)
   SpNames.Add("Par_Description")                                   '(4)
   SpParams.Add(.System1)                                           '(5)
   SpNames.Add("Par_System")                                        '(5)
   SpParams.Add(.Type1)                                             '(6)
   SpNames.Add("Par_Type")                                          '(6)
End With
   SpNames.Add("NewId")                                             '(7)
   SpParams.Add(CInt(0))                                            '(7)
If Me.StoredProcedure("AG_AaSsParameters_Save_Update",SpParams, SpNames,7) Then
   If _cAaSsParameters.Id = 0 Then
        _cAaSsParameters.Id = DbNullToInt(SpParams(7))
   End if
  Return True
Else
  Return False
End if
End Function
Protected Function Delete(ByVal tId As Integer) as Boolean
Dim Str as String
Dim Flag As Boolean = True
Dim Exx As New System.Exception
   Try
         BeginTransaction()
         Str = " DELETE FROM AaSsParameters" & _
            " WHERE Par_Id = " & tId
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
Protected Function CheckDeleteRecords(ByVal tCode As Integer) as DataSet
 Dim ds As DataSet
'    Generation Note : 13/02/2008 09:42:45 :- No Foriegn Key Constraints where found
     ds = nothing
     Return ds
End Function
End Class
