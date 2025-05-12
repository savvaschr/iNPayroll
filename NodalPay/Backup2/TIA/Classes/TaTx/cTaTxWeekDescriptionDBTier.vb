Public Class cTaTxWeekDescriptionDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim str As String
        str = "SELECT WekDes_Id," & _
        " WekDes_FromDate," & _
        " WekDes_ToDate," & _
        " WekDes_AnalCode," & _
        " WekDes_Description" & _
        "From TaTxWeekDescription " & _
        " WHERE (WekDes_Id = " & Id & ")"

        Return GetData(str)

    End Function
    Protected Function GetByPK(ByVal FromDate As Date, ByVal ToDate As Date, ByVal AnalCode As String) As DataSet
        Dim str As String
        Dim sFrom As String = Format(FromDate, "yyyy-MM-dd")
        sFrom = Utils.ChangeDateFormatForSearch(sFrom)

        Dim sTo As String = Format(ToDate, "yyyy-MM-dd")
        sTo = Utils.ChangeDateFormatForSearch(sTo)



        str = "SELECT WekDes_Id," & _
        " WekDes_FromDate," & _
        " WekDes_ToDate," & _
        " WekDes_AnalCode," & _
        " WekDes_Description" & _
        " From TaTxWeekDescription " & _
        " WHERE WekDes_FromDate = " & enQuoteString(sFrom) & _
        " AND WekDes_ToDate = " & enQuoteString(sTo) & _
        " AND WekDes_AnalCode = " & enQuoteString(AnalCode)

        Return GetData(str)

    End Function
    Protected Function Save(ByRef _cWekDes As cTaTxWeekDescription) As Boolean

        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False

        With _cWekDes
            SpParams.Add(.Id)                                    '0
            SpNames.Add("WekDes_Id")
            SpParams.Add(.Fromdate)                              '1
            SpNames.Add("WekDes_FromDate")
            SpParams.Add(.Todate)                                '2
            SpNames.Add("WekDes_ToDate")
            SpParams.Add(.AnalCode)                              '3
            SpNames.Add("WekDes_AnalCode")
            SpParams.Add(.Desription)                            '4
            SpNames.Add("WekDes_Description")
            SpParams.Add(CInt(0))                                '5
            SpNames.Add("NewId")

        End With
        If Me.StoredProcedure("TaTxWeekDescription_Save_Update", SpParams, SpNames, 5) Then
            If _cWekDes.Id = 0 Then
                _cWekDes.Id = DbNullToInt(SpParams(5))
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Delete(ByVal _cWeekDes As cTaTxWeekDescription) As Boolean
        Dim Str As String
        Dim i As Integer
        Str = "DELETE FROM TaTxWeekDescrioption WHERE WekDes_id=" & _cWeekDes.Id
        i = MyBase.ExecuteNonQuery(Str)
        If i < 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
