Public Class cFiTrxnHeaderDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " TrxHdr_Id," & _
                " TrxCod_Code," & _
                " BusPrt_Code," & _
                " TrxHdr_PostDate," & _
                " TrxHdr_InvDate," & _
                " TrxHdr_DueDate," & _
                " TrxHdr_RefNo," & _
                " TrxHdr_AcctRefNo," & _
                " TrxHdr_XRefNo," & _
                " Cur_AlphaCode," & _
                " TrxHdr_CurRate," & _
                " TrxHdr_IsVatIncl," & _
                " TrxHdr_IsReversed," & _
                " TrxHdr_Notes," & _
                " TrxHdr_OverallDiscTrxn," & _
                " TrxHdr_OverallDiscPerc," & _
                " TrxHdr_OverallDiscVatTrxn," & _
                " TrxHdr_TotalTrxn," & _
                " TrxHdr_CreationDate," & _
                " TrxHdr_AmendDate," & _
                " TrxHdr_TotalVATTrxn," & _
                " TrxHdr_CreatedBy," & _
                " TrxHdr_AmendBy," & _
                " TrxHdr_TrxnTypeFactor ," & _
                " TrxHdr_Factor " & _
                " FROM FiTxTrxnHeader" & _
                " WHERE TrxHdr_Id = " & tId
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByRef _cFiTrxnHeader As cFiTrxnHeader) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cFiTrxnHeader
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("TrxHdr_Id")                                         '(0)
            SpParams.Add(.TrxCodCode)                                        '(1)
            SpNames.Add("TrxCod_Code")                                       '(1)
            SpParams.Add(.BusPrtCode)                                        '(2)
            SpNames.Add("BusPrt_Code")                                       '(2)
            SpParams.Add(.PostDate)                                          '(3)
            SpNames.Add("TrxHdr_PostDate")                                   '(3)
            SpParams.Add(.InvDate)                                           '(4)
            SpNames.Add("TrxHdr_InvDate")                                    '(4)
            SpParams.Add(.DueDate)                                           '(5)
            SpNames.Add("TrxHdr_DueDate")                                    '(5)
            SpParams.Add(.RefNo)                                             '(6)
            SpNames.Add("TrxHdr_RefNo")                                      '(6)
            SpParams.Add(.AcctRefNo)                                         '(7)
            SpNames.Add("TrxHdr_AcctRefNo")                                  '(7)
            SpParams.Add(.XRefNo)                                            '(8)
            SpNames.Add("TrxHdr_XRefNo")                                     '(8)
            SpParams.Add(.CurAlphaCode)                                      '(9)
            SpNames.Add("Cur_AlphaCode")                                     '(9)
            SpParams.Add(.CurRate)                                           '(10)
            SpNames.Add("TrxHdr_CurRate")                                    '(10)
            SpParams.Add(.IsVatIncluded)                                     '(11)
            SpNames.Add("TrxHdr_IsVatIncl")                                  '(11)
            SpParams.Add(.IsReversed)                                        '(12)
            SpNames.Add("TrxHdr_IsReversed")                                 '(12)
            SpParams.Add(.Notes)                                             '(13)
            SpNames.Add("TrxHdr_Notes")                                      '(13)
            SpParams.Add(.OverallDiscTrxn)                                   '(14)
            SpNames.Add("TrxHdr_OverallDiscTrxn")                            '(14)
            SpParams.Add(.OverallDiscPerc)                                   '(15)
            SpNames.Add("TrxHdr_OverallDiscPerc")                            '(15)
            SpParams.Add(.OverallDiscVatTrxn)                                '(16)
            SpNames.Add("TrxHdr_OverallDiscVatTrxn")                         '(16)
            SpParams.Add(.TotalTrxn)                                         '(17)
            SpNames.Add("TrxHdr_TotalTrxn")                                  '(17)
            SpParams.Add(.CreationDate)                                      '(18)
            SpNames.Add("TrxHdr_CreationDate")                               '(18)
            SpParams.Add(.AmendDate)                                         '(19)
            SpNames.Add("TrxHdr_AmendDate")                                  '(19)
            SpParams.Add(.TotalVATTrxn)                                      '(20)
            SpNames.Add("TrxHdr_TotalVATTrxn")                               '(20)
            SpParams.Add(.CreatedBy)                                         '(21)
            SpNames.Add("TrxHdr_CreatedBy")                                  '(21)
            SpParams.Add(.AmendBy)                                           '(22)
            SpNames.Add("TrxHdr_AmendBy")                                    '(22)
            SpParams.Add(.TrxnTypeFactor)                                    '(23)
            SpNames.Add("TrxHdr_TrxnTypeFactor")                             '(23)
            SpParams.Add(.Factor)                                            '(24)
            SpNames.Add("TrxHdr_Factor")                                     '(24)
        End With

        SpNames.Add("NewId")
        SpParams.Add(CInt(0))                                                '(25)
        If Me.StoredProcedure("AG_FiTxTrxnHeader_Save_Update", SpParams, SpNames, 25) Then
            'If Me.StoredProcedure("AG_FiTxTrxnHeader_Save_Update", SpParams, 25) Then
            If _cFiTrxnHeader.Id = 0 Then
                _cFiTrxnHeader.Id = DbNullToInt(SpParams(25))
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function Delete(ByVal tId As Integer) As Boolean
        ' note : this function closes the connection if you use programs that use an open connection comment out Cnx.Close lines
        '     closing connection does not affect dataset returning
        Dim Str As String
        Dim Flag As Boolean
        Try
            If Cnx.State <> ConnectionState.Open Then Cnx.Open()
            BeginTransaction()
            Str = " DELETE FROM FiTxTrxnHeader" & _
               " WHERE tId = " & tId
            If MyBase.ExecuteNonQuery(Str) <> -1 Then
                CommitTransaction()
                Flag = True
                If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection 
            Else
                Rollback()
                Flag = False
                If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection
            End If
        Catch ex As Exception
            Rollback()
            Flag = False
            If Cnx.State = ConnectionState.Open Then Cnx.Close() ' ***** Closing connection
        End Try
        Return Flag
    End Function

    Protected Function CheckDeleteRecords() As DataSet
        Dim Str As String
        Str = " " & _
        "SELECT COUNT(TrxHdr_id FROM FiTx_Allocations" & _
        " " & _
        "SELECT COUNT(TrxHdr_Id FROM FiTxTrxnLines" & _
        " " & _
        " "
        Return GetData(Str)
    End Function

End Class

