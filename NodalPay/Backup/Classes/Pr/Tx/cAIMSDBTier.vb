Public Class cAIMSDBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal EmpCode As String) As DataSet
        Dim Str As String
        Str = " SELECT No," & _
            " Employee," & _
            " Sectors," & _
            " DutyHours," & _
            " FlightHours  " & _
            " FROM  PrTxAims " & _
            " WHERE No = " & enQuoteString(empCode)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal Aims As cAIMS, ByVal Update As Boolean) As Boolean
        Dim Str As String
        Dim i As Integer
        Dim Flag As Boolean
        If Update Then
            Str = " Update PrTxAims " & _
            " set Employee =" & enQuoteString(Aims.Employee) & _
            ", Sectors = " & enQuoteString(Aims.Sectors) & _
            ", DutyHours = " & enQuoteString(Aims.DutyHours) & _
            ", FlightHours=  " & enQuoteString(Aims.FlightHours) & _
            " WHERE No = " & enQuoteString(Aims.No)
        Else
            Str = " Insert Into PrTxAims (" & _
                   " No," & _
                   " Employee," & _
                   " Sectors," & _
                   " DutyHours," & _
                   " FlightHours)  " & _
                   " Values (" & enQuoteString(Aims.No) & "," & _
                    enQuoteString(Aims.Employee) & "," & _
                    enQuoteString(Aims.Sectors) & "," & _
                    enQuoteString(Aims.DutyHours) & "," & _
                    enQuoteString(Aims.FlightHours) & ")"
        End If
        i = ExecuteNonQuery(Str)
        If i >= 0 Then
            Flag = True
        Else
            Flag = False
        End If

        Return Flag

    End Function
End Class
