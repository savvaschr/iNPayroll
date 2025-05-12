Public Class cTaTxTrxnLines2DBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim str As String
        str = "SELECT TrxLin_Id," & _
        " TrxLin_Date," & _
        " Emp_Code," & _
        " TrxLin_Day," & _
        " TrxLin_FromTime," & _
        " TrxLin_ToTime," & _
        " TrxLin_TotalTime," & _
        " WrkGrp_Code," & _
        " WrkCod_Code," & _
        " Usr_IdCreate," & _
        " Usr_IdLastUpdate," & _
        " TrxLin_Created," & _
        " TrxLin_LastUpdate," & _
        " TrxLin_Status" & _
        " TrxLin_AnalCode" & _
        " TrxLin_AnalDesc" & _
        " FROM TaTxTrxnLines2" & _
        " WHERE (TrxLin_Id = " & Id & ")"

        Return GetData(str)

    End Function
    Protected Function Save(ByRef _cTrxnLin As cTaTxTrxnLines2) As Boolean

        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False

        With _cTrxnLin
            SpParams.Add(.Id)                                    '0
            SpNames.Add("TrxLin_Id")
            SpParams.Add(.Mydate)                                  '1
            SpNames.Add("TrxLin_Date")
            SpParams.Add(.EmployeeCode)                          '2
            SpNames.Add("Emp_Code")
            SpParams.Add(.Day)                                   '3
            SpNames.Add("TrxLin_Day")
            SpParams.Add(.FromTime)                              '4
            SpNames.Add("TrxLin_FromTime")
            SpParams.Add(.ToTime)                                '5
            SpNames.Add("TrxLin_ToTime")
            SpParams.Add(.TotalTime)                             '6   
            SpNames.Add("TrxLin_TotalTime")
            SpParams.Add(.WorkGroupCode)                         '7
            SpNames.Add("WrkGrp_Code")
            SpParams.Add(.WorkCode)                              '8
            SpNames.Add("WrkCod_Code")
            SpParams.Add(.UserId_Create)                         '9
            SpNames.Add("Usr_IdCreate")
            SpParams.Add(.UserId_LastUpdate)                     '10
            SpNames.Add("Usr_IdLastUpdate")
            SpParams.Add(.Created)                               '11
            SpNames.Add("TrxLin_Created")
            SpParams.Add(.LastUpdate)                            '12
            SpNames.Add("TrxLin_LastUpdate")
            SpParams.Add(.Status)                                '13
            SpNames.Add("TrxLin_Status")
            SpParams.Add(.AnalCode)                               '14
            SpNames.Add("TrxLin_AnalCode")
            SpParams.Add(.AnalDesc)                                '15
            SpNames.Add("TrxLin_AnalDesc")
            SpParams.Add(CInt(0))                                '16
            SpNames.Add("NewId")

        End With
        If Me.StoredProcedure("TaTxTrxnLines2_Save_Update", SpParams, SpNames, 16) Then
            If _cTrxnLin.Id = 0 Then
                _cTrxnLin.Id = DbNullToInt(SpParams(16))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Delete(ByVal _cTrxnLin As cTaTxTrxnLines2) As Boolean
        Dim Str As String
        Dim i As Integer
        Str = "DELETE FROM TaTxTrxnLines2 WHERE TrxLin_id=" & _cTrxnLin.Id
        i = MyBase.ExecuteNonQuery(Str)
        If i < 0 Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
