Public Class cPrMsPeriodWorkDaysDBTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String, ByVal tGroupCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                "  PrdNrm_Id," & _
                "  PrdGrp_Code," & _
                "  PrdCod_Code," & _
                "  PrdNrm_WorkDays " & _
                "  FROM PrMsPeriodWorkDays " & _
                "  WHERE PrdCod_Code = " & enQuoteString(tCode) & _
                "  AND PrdGrp_Code = " & enQuoteString(tGroupCode)

        Return MyBase.GetData(Str)
    End Function
    Protected Function GetById(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                "  PrdNrm_Id," & _
                "  PrdGrp_Code," & _
                "  PrdCod_Code," & _
                "  PrdNrm_WorkDays " & _
                "  FROM PrMsPeriodWorkDays " & _
                "  WHERE PrdNrm_Id = " & tId

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsPeriodWorkDays As cPrMsPeriodWorkDays) As Boolean
        Dim Str As String
        Dim F As Boolean = False
        With _cPrMsPeriodWorkDays
            If .ID = 0 Then
                Str = "Insert Into PrMsPeriodWorkDays" & _
                " (PrdGrp_Code," & _
                "PrdCod_Code," & _
                "PrdNrm_WorkDays ) " & _
                " Values ( " & _
                enQuoteString(.GrpCode) & "," & _
                enQuoteString(.PrdCode) & "," & _
                .NormalDays & ")"
            Else
                Str = "Update PrMsPeriodWorkDays Set" & _
                        " PrdGrp_Code = " & enQuoteString(.GrpCode) & _
                        ",PrdCod_Code = " & enQuoteString(.PrdCode) & _
                        ",PrdNrm_WorkDays = " & .NormalDays & _
                        " Where PrdNrm_Id=" & .ID
            End If

            If MyBase.ExecuteNonQuery(Str) > 0 Then
                f = True
            Else
                f = False
            End If
        End With
        Return F

    End Function
  
    
End Class
