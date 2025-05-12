Public Class cFiTxTrxnLinesDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer, ByVal tHdrId As Integer) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " TrxLne_Id," & _
                " TrxHdr_Id," & _
                " Acc_Code," & _
                " TxLAn1_Code," & _
                " TxLAn2_Code," & _
                " TxLAn3_Code," & _
                " TxLAn4_Code," & _
                " TxLAn5_Code," & _
                " TxLAn6_Code," & _
                " TxLAn7_Code," & _
                " TxLAn8_Code," & _
                " TxLAn9_Code," & _
                " TxLAn10_Code," & _
                " TrxLne_Notes," & _
                " Vat_Code," & _
                " TrxLne_VatRate," & _
                " TrxLne_AmountTC," & _
                " TrxLne_GrossValTC," & _
                " TrxLne_LneDiscValTC," & _
                " TrxLne_LneDiscPerc," & _
                " TrxLne_LneVatValTC," & _
                " TrxLne_OverallDiscValTC," & _
                " TrxLne_OverallDiscVatTC," & _
                " TrxLne_LneTotalTC," & _
                " TrxLne_LneVatTC," & _
                " TrxLne_LneTotaLC," & _
                " TrxLne_LneVatLC," & _
                " TrxLne_TrxnTypeFactor," & _
                " TrxLne_Factor " & _
                " FROM FiTxTrxnLines" & _
                " WHERE TrxLne_Id =" & tId & _
                " AND  TrxHdr_Id = " & tHdrId
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cFiTxTrxnLines As cFiTxTrxnLines) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cFiTxTrxnLines
            SpParams.Add(.Id)                                                '(0)
            SpNames.Add("TrxLne_Id")                                         '(0)
            SpParams.Add(.HdrId)                                             '(1)
            SpNames.Add("TrxHdr_Id")                                         '(1)
            SpParams.Add(.AccCode)                                           '(2)
            SpNames.Add("Acc_Code")                                          '(2)
            SpParams.Add(.An1_Code)                                          '(3)
            SpNames.Add("TxLAn1_Code")                                       '(3)
            SpParams.Add(.An2_Code)                                          '(4)
            SpNames.Add("TxLAn2_Code")                                       '(4)
            SpParams.Add(.An3_Code)                                          '(5)
            SpNames.Add("TxLAn3_Code")                                       '(5)
            SpParams.Add(.An4_Code)                                          '(6)
            SpNames.Add("TxLAn4_Code")                                       '(6)
            SpParams.Add(.An5_Code)                                          '(7)
            SpNames.Add("TxLAn5_Code")                                       '(7)
            SpParams.Add(.An6_Code)                                          '(8)
            SpNames.Add("TxLAn6_Code")                                       '(8)
            SpParams.Add(.An7_Code)                                          '(9)
            SpNames.Add("TxLAn7_Code")                                       '(9)
            SpParams.Add(.An8_Code)                                          '(10)
            SpNames.Add("TxLAn8_Code")                                       '(10)
            SpParams.Add(.An9_Code)                                          '(11)
            SpNames.Add("TxLAn9_Code")                                       '(11)
            SpParams.Add(.An10_Code)                                         '(12)
            SpNames.Add("TxLAn10_Code")                                      '(12)
            SpParams.Add(.Notes)                                             '(13)
            SpNames.Add("TrxLne_Notes")                                      '(13)
            SpParams.Add(.VatCode)                                           '(14)
            SpNames.Add("Vat_Code")                                          '(14)
            SpParams.Add(.VatRate)                                           '(15)
            SpNames.Add("TrxLne_VatRate")                                    '(15)
            SpParams.Add(.Amount)                                            '(16)
            SpNames.Add("TrxLne_AmountTC")                                   '(16)
            SpParams.Add(.Gross)                                             '(17)
            SpNames.Add("TrxLne_GrossValTC")                                 '(17)
            SpParams.Add(.LneDisc)                                           '(18)
            SpNames.Add("TrxLne_LneDiscValTC")                               '(18)
            SpParams.Add(.LneDiscPerc)                                       '(19)
            SpNames.Add("TrxLne_LneDiscPerc")                                '(19)
            SpParams.Add(.LneDiscVAT)                                        '(20)
            SpNames.Add("TrxLne_LneVatValTC")                                '(20)
            SpParams.Add(.OverallDisc)                                       '(21)
            SpNames.Add("TrxLne_OverallDiscValTC")                           '(21)
            SpParams.Add(.OverallDiscVAT)                                    '(22)
            SpNames.Add("TrxLne_OverallDiscVatTC")                           '(22)
            SpParams.Add(.LneTotal)                                          '(23)
            SpNames.Add("TrxLne_LneTotalTC")                                 '(23)
            SpParams.Add(.LneVAT)                                            '(24)
            SpNames.Add("TrxLne_LneVatTC")                                   '(24)
            SpParams.Add(.LneTotalLC)                                        '(25)
            SpNames.Add("TrxLne_LneTotaLC")                                  '(25)
            SpParams.Add(.LneVATLC)                                          '(26)
            SpNames.Add("TrxLne_LneVatLC")                                   '(26)
            SpParams.Add(.TrxnTypeFactor)                                    '(27)
            SpNames.Add("TrxLne_TrxnTypeFactor")                             '(27)
            SpParams.Add(.Factor)                                            '(28)
            SpNames.Add("TrxLne_Factor")                                     '(28)
        End With
        If Me.StoredProcedure("AG_FiTxTrxnLines_Save_Update", SpParams, SpNames) Then
            'If Me.StoredProcedure("FiTxTrxnLines_Save_Update", SpParams) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tId As Integer, ByVal tHdrId As Integer) As Boolean
        ' note : this function closes the connection if you use programs that use an open connection comment out Cnx.Close lines
        '     closing connection does not affect dataset returning
        Dim Str As String
        Dim Flag As Boolean
        Try
            If Cnx.State <> ConnectionState.Open Then Cnx.Open()
            BeginTransaction()
            Str = " DELETE FROM FiTxTrxnLines" & _
                  " WHERE TrxLne_Id =" & tId & _
                  " AND  TrxHdr_Id = " & tHdrId
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
        ' No Forien Key Constraints where found
        Dim Ds As New DataSet
        Return Ds
    End Function

End Class


