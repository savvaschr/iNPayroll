Public Class cPrTxLoanCommentsDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tId As Integer) As DataSet
        Dim Str As String
        Str = "SELECT Lne_Id, " & _
        " Emp_Code,  " & _
        " Lne_Code, " & _
        " Lne_Date, " & _
        " Lne_Amount, " & _
        " Lne_Comment, " & _
        " Lne_Type,  " & _
        " Lne_ChequeNo " & _
        " FROM PrTxLoanComments " & _
        " Where Lne_Id= " & tId

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cPrTxLoanComments As cPrTxLoanComments) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrTxLoanComments

            SpParams.Add(.Id)                              '0
            SpNames.Add("Lne_Id")
            SpParams.Add(.EmpCode)                              '1
            SpNames.Add("Emp_Code")
            SpParams.Add(.LoanCode)                              '2
            SpNames.Add("Lne_Code")
            SpParams.Add(.MyDate)                              '3
            SpNames.Add("Lne_Date")
            SpParams.Add(.Amount)                              '4
            SpNames.Add("Lne_Amount")
            SpParams.Add(.Comment)                              '5
            SpNames.Add("Lne_Comment")
            SpParams.Add(.MyType)                              '6
            SpNames.Add("Lne_Type")
            SpParams.Add(.ChequeNo)                              '7
            SpNames.Add("Lne_ChequeNo")





        End With


        SpNames.Add("NewId")                                             '(8)
        SpParams.Add(CInt(0))                                            '(8)
        If Me.StoredProcedure("AG_PrTxLoanComments_Save_Update", SpParams, SpNames, 8) Then
            If _cPrTxLoanComments.Id = 0 Then
                _cPrTxLoanComments.Id = DbNullToInt(SpParams(8))
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
            Str = " DELETE FROM PrTxLoanComments" & _
               " WHERE Lne_id = " & tId
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
