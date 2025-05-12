Option Explicit On
Option Strict On
Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class cDataTier

    Friend ConnectionString As String
    Protected Shared Cnx As SqlConnection
    Protected Shared Cmd As SqlCommand

    Shared Sub New()
        Cnx = New SqlConnection
        Cmd = New SqlCommand
        Cmd.Connection = Cnx
    End Sub
    Protected Friend Sub BeginTransaction()
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Cmd.Transaction = Cnx.BeginTransaction()
            BeginTransactionFlag = True
        Catch e As SqlException
            BeginTransactionFlag = False
            ShowSQLException(e)
        Catch e As System.Exception
            BeginTransactionFlag = False
            ShowException(e)
        End Try
    End Sub
    Protected Friend Sub CommitTransaction()
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            If Not (Cmd.Transaction Is Nothing) Then
                Cmd.Transaction.Commit()
                BeginTransactionFlag = False
                Cnx.Close()
            End If
        Catch e As SqlException
            BeginTransactionFlag = False
            MessageBox.Show("Could not commit the changes", "Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cmd.Transaction = Nothing
            ShowSQLException(e)
        Catch e As System.Exception
            BeginTransactionFlag = False
            ShowException(e)
        End Try
    End Sub
    Protected Friend Function Rollback() As Boolean
        Dim Success As Boolean = False
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Success = False
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            If Not IsNothing(Cmd.Transaction) Then
                Cmd.Transaction.Rollback()
                Success = True
                Cnx.Close()
                BeginTransactionFlag = False
            End If
        Catch e As SqlException
            BeginTransactionFlag = False
        Catch e As System.Exception
        Finally
            Try
                Cmd.Transaction = Nothing
                BeginTransactionFlag = False
            Catch e2 As System.Exception
            End Try
        End Try
        Return Success
    End Function
    Protected Function GetData(ByVal Query As String) As DataSet
        Dim ds As New DataSet
        Dim Adapter As New SqlDataAdapter
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Adapter.SelectCommand = Cmd
            Cmd.Connection = Cnx
            Cmd.CommandText = Query
            Cmd.CommandType = CommandType.Text
            Adapter.Fill(ds)
            If Not BeginTransactionFlag Then
                Cnx.Close()
            End If
        Catch e As SqlException
            ShowSQLException(e)
        Catch e As System.Exception
            ShowException(e)
        Finally
            Adapter.Dispose()
            Adapter = Nothing
        End Try
        Return ds
    End Function
    Protected Function GetDataRO(ByVal Query As String) As SqlDataReader
        Dim Reader As SqlDataReader

        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Cmd.Connection = Cnx
            Cmd.CommandText = Query
            Cmd.CommandType = CommandType.Text
            Reader = Cmd.ExecuteReader()
            Reader.Read()
            If Not BeginTransactionFlag Then
                Cnx.Close()
            End If
        Catch e As SqlException
            ShowSQLException(e)
        Catch e As System.Exception
            ShowException(e)
        Finally
            Reader = Nothing
        End Try
        Return Reader
    End Function
    Protected Sub ShowSQLException(ByVal e As SqlException)
        Dim eTitle As String = "Database Error"
        Dim i As Integer
        Dim Ans As New MsgBoxResult

        If Global1.ShowMessages Then
            Ans = MsgBox("Rolling back...", MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                If Me.Rollback() Then
                    MsgBox("Roll back succesfully")
                End If
            End If
        Else
            Me.Rollback()
        End If

        Try
            ' LogToFile(e)
            If Global1.ShowMessages Then
                MsgBox("Message: " & e.Message.ToString & ControlChars.Cr.ToString _
                    & "Source: " & e.Source.ToString & ControlChars.Cr.ToString _
                    & "ErrorCode: " & e.ErrorCode.ToString & ControlChars.Cr.ToString _
                    & "BaseException: " + e.GetBaseException.ToString + ControlChars.Cr.ToString _
                    & "Type: " & e.GetType.ToString, MsgBoxStyle.Critical, eTitle)
            End If
        Catch err As System.Exception
            If Global1.ShowMessages Then
                MsgBox(e.ToString, MsgBoxStyle.Critical, eTitle)
            End If
        End Try
        If Global1.ShowMessages Then
            For i = 0 To e.Errors.Count - 1
                Try
                    '  LogToFile(e.Errors(i).ToString)

                    MsgBox("Message: " & e.Errors(i).Message.ToString & ControlChars.Cr.ToString _
                   & "Source: " & e.Errors(i).Source.ToString & ControlChars.Cr.ToString _
                   & "SQLState: " & e.Errors(i).State.ToString & ControlChars.Cr.ToString _
                   & "ErrorType: " & e.Errors(i).GetType.ToString, MsgBoxStyle.Information, "Error " & (i + 1).ToString)
                Catch err As System.Exception
                    MsgBox(e.ToString, MsgBoxStyle.Critical, eTitle)
                End Try
            Next
        End If
    End Sub
    Protected Sub ShowConnectionStatus()
        MsgBox(Cnx.State.ToString, MsgBoxStyle.Information, "Connection")
    End Sub
    Protected Sub ShowException(ByVal e As System.Exception)
        ' LogToFile(e)
        Try
            MsgBox("Message: " + e.Message.ToString + ControlChars.Cr _
               + "Source: " + e.Source.ToString + ControlChars.Cr _
               + "BaseException: " + e.GetBaseException.ToString + ControlChars.Cr.ToString _
               + "ErrorType: " + e.GetType.ToString, MsgBoxStyle.Exclamation, "DataTier: Error Handler")

            Dim str As String = "Message: " & e.Message.ToString & ControlChars.Cr + "Source: " + e.Source.ToString + ControlChars.Cr _
               + "BaseException: " + e.GetBaseException.ToString + ControlChars.Cr.ToString _
               + "ErrorType: " + e.GetType.ToString

            'Debug.WriteLine(str)

        Catch e2 As System.Exception
            MsgBox(e.ToString)
        End Try

        Me.Rollback()
    End Sub
    Protected Function ExecuteScalar(ByVal Query As String, Optional ByVal ErrorValue As String = "-1") As String
        Dim Value As String
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Query
            Value = SuppressDBNull(Cmd.ExecuteScalar())
            If Not BeginTransactionFlag Then
                Cnx.Close()
            End If
        Catch e As SqlException
            ShowSQLException(e)
            Value = ErrorValue
        Catch e As System.Exception
            ShowException(e)
            Value = ErrorValue
        Finally
        End Try
        Return Value
    End Function

    Protected Function ExecuteNonQuery(ByVal Query As String) As Integer
        'Executes a query and returns the number of rows affected
        Dim i As Integer
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Cmd.CommandText = Query
            Cmd.CommandType = CommandType.Text
            i = Cmd.ExecuteNonQuery()
            If i = -1 Then i = 0
        Catch e As SqlException 'OleDbException
            ShowSQLException(e)
            i = -1
        Catch e As System.Exception
            ShowException(e)
            i = -1
        Finally

        End Try

        Return i
    End Function
    Protected Function ExecuteNonQueryNoMessages(ByVal Query As String) As Integer
        'Executes a query and returns the number of rows affected
        Dim i As Integer
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If
            Cmd.CommandText = Query
            Cmd.CommandType = CommandType.Text
            i = Cmd.ExecuteNonQuery()
            If i = -1 Then i = 0
        Catch e As SqlException 'OleDbException
            ' ShowSQLException(e)
            i = -1
        Catch e As System.Exception
            'ShowException(e)
            i = -1
        Finally

        End Try

        Return i
    End Function
    Protected Function StoredProcedure(ByVal StoredProcedureName As String, ByRef spParams As ArrayList, ByVal spNames As ArrayList, Optional ByVal FirstOutputParamIndex As Integer = -1, Optional ByVal UseNoTimeOut As Boolean = False) As Boolean
        Dim Success As Boolean = False
        Dim i As Integer
        Try
            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If

            CreateParameters(spParams, spNames, FirstOutputParamIndex)
            Cmd.CommandText = StoredProcedureName
            If UseNoTimeOut Then
                Cmd.CommandTimeout = 900
            End If
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.ExecuteNonQuery()
            Success = True
            If Not BeginTransactionFlag Then
                Cnx.Close()
            End If
        Catch e As System.Exception
            ShowException(e)
            ' Debug.WriteLine(e)
        Finally
            Try
                'Place the return params back to the arraylist
                If FirstOutputParamIndex > -1 Then
                    For i = FirstOutputParamIndex To Cmd.Parameters.Count - 1
                        spParams(i) = Cmd.Parameters(i).Value
                    Next
                End If
            Catch ex As System.Exception
                Success = False
            End Try
            Cmd.Parameters.Clear()
        End Try
        Cmd.CommandTimeout = 30
        Return Success
    End Function
    Private Sub CreateParameters(ByVal spParams As ArrayList, ByVal spNames As ArrayList, Optional ByVal FirstOutputParamIndex As Integer = -1)

        Dim Param As SqlParameter 'OleDbParameter
        Dim Success As Boolean = False
        Dim i As Integer

        Try
            For i = 0 To spParams.Count - 1
                Param = New SqlParameter 'OleDbParameter
                ' added parameter name 16/10/07 for SQL Client Connection
                Param.ParameterName = CStr(spNames(i))

                If FirstOutputParamIndex > -1 And i >= FirstOutputParamIndex Then
                    Param.Direction = ParameterDirection.Output
                Else
                    Param.Direction = ParameterDirection.Input
                End If

                Param.SqlValue = spParams(i) ' Param.Value

                'Select Case spParams(i).GetType.ToString
                '    Case "System.Int32"
                '        Param.SqlDbType = SqlDbType.Int
                '        'Param.OleDbType = OleDbType.Integer
                '    Case "System.Int16"
                '        Param.SqlDbType = SqlDbType.SmallInt
                '        'Param.OleDbType = OleDbType.SmallInt
                '    Case "System.DateTime"
                '        Param.SqlDbType = SqlDbType.SmallDateTime
                '        Dim NullDate As Date
                '        If CDate(Param.Value) = NullDate Then
                '            Param.Value = DBNull.Value
                '        End If
                '        'End If
                '    Case "System.String"
                '        'Param.OleDbType = OleDbType.VarWChar
                '        Param.SqlDbType = SqlDbType.Char
                '        'Param.OleDbType = OleDbType.VarChar
                '        'Param.SqlDbType = SqlDbType.Char
                '        If Param.Direction = ParameterDirection.Output Then
                '            Param.Size = CInt(Param.Value)
                '            'Console.WriteLine(Param.Size)
                '        Else
                '            Param.Size = Param.Value.ToString.Length
                '        End If
                '    Case "System.Decimal"
                '        Param.SqlDbType = SqlDbType.Decimal
                '        'Param.OleDbType = OleDbType.Double
                '    Case "System.Char"
                '        Param.SqlDbType = SqlDbType.Char
                '        'Param.OleDbType = OleDbType.Char
                '        Param.Size = Param.Value.ToString.Length
                '    Case "System.Boolean"
                '        Param.SqlDbType = SqlDbType.Char
                '        'Param.OleDbType = OleDbType.Char
                '        Param.Size = 1
                '        If CBool(spParams(i)) Then
                '            Param.Value = "Y"
                '        Else
                '            Param.Value = "N"
                '        End If
                '    Case Else
                '        Throw New System.Exception(spParams(i).GetType.ToString & " is not supported")
                'End Select

                If Param.Value Is Nothing Then
                    Param.Value = DBNull.Value
                End If
                'Debug.WriteLine("GetType: (" & i & "): " & spParams(i).GetType().ToString & " Value=" & Param.ToString)
                Cmd.Parameters.Add(Param)
                ' Debug.WriteLine(Param.SqlValue.ToString)
            Next i
            'For i = 0 To Cmd.Parameters.Count - 1
            '    Debug.WriteLine(Cmd.Parameters(i).OleDbType.ToString)
            'Next
        Catch e As System.Exception
            'ShowException(e)
            Cmd.Parameters.Clear()
            Throw e
        End Try


    End Sub

    Protected Function StoredProcedureDs(ByVal StoredProcedureName As String, ByRef spParams As ArrayList, ByVal spNames As ArrayList, _
                    Optional ByVal FirstOutputParamIndex As Integer = -1, Optional ByRef Status As Boolean = False) As DataSet

        Dim i As Integer
        Dim ds As New DataSet
        Dim Adapter As New SqlDataAdapter
        Try
            Status = False  'Indicates Success or failure

            If Cnx.State <> ConnectionState.Open Then
                Cnx.Open()
                If Cnx.State <> ConnectionState.Open Then
                    Throw New System.Exception("Can not establish connection to database")
                End If
            End If

            CreateParameters(spParams, spNames, FirstOutputParamIndex)

            Adapter.SelectCommand = Cmd
            Cmd.Connection = Cnx
            Cmd.CommandText = StoredProcedureName
            Cmd.CommandType = CommandType.StoredProcedure

            Adapter.Fill(ds)
            If Not BeginTransactionFlag Then
                Cnx.Close()
            End If
        Catch e As SqlException
            ShowSQLException(e)
        Catch e As System.Exception
            ShowException(e)
        Finally
            Try
                'Place the return params back to the arraylist
                If FirstOutputParamIndex > -1 Then
                    For i = FirstOutputParamIndex To Cmd.Parameters.Count - 1
                        spParams(i) = Cmd.Parameters(i).Value
                    Next
                End If
                Status = True
            Catch ex As System.Exception
                'Ignore
            End Try

            Cmd.Parameters.Clear()
            Adapter.Dispose()
            Adapter = Nothing
        End Try

        Return ds
    End Function
    Private Function SuppressDBNull(ByVal o As Object) As String
        If o Is Nothing Then
            Return ""
        ElseIf IsDBNull(o) Then
            Return ""
        Else
            Return o.ToString
        End If
    End Function
    Protected Function dbConnected() As Boolean
        Return (Cnx.State = ConnectionState.Open)
    End Function
    Protected Function DBDateString(ByVal Dt As Date) As String
        Return Format$(Dt, "dd/MM/yyyy hh:mm:ss")
    End Function
    Protected Function DBSmallDateTime(ByVal dt As Date) As String
        Dim dtNULL As Date

        If dtNULL = dt Then
            Return "NULL"
        Else
            Return Format$(dt, "dd/MM/yyyy hh:mm")
        End If
    End Function
    Protected Function NothingToDBNull(ByVal s As String) As String
        If IsNothing(s) Then
            Return DBNull.Value.ToString
        ElseIf s.Trim = "" Then
            Return DBNull.Value.ToString
        Else
            Return s.Trim
        End If
    End Function
    Protected Sub FillDataSet(ByRef dsName As DataSet, ByVal StoredProcedureName As String, ByRef spParams As ArrayList, ByRef arTableNames As ArrayList)
        Dim Adapter As New SqlDataAdapter
        Dim i As Integer
        Dim SourceTable As String
        Dim spnames As New ArrayList

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = StoredProcedureName
        CreateParameters(spParams, spnames)

        Adapter.SelectCommand = Cmd

        For i = 0 To arTableNames.Count - 1
            SourceTable = "Table" & CChar(IIf(i = 0, "", i))
            Adapter.TableMappings.Add(Trim(SourceTable), CStr(arTableNames(i)))
        Next
        Adapter.Fill(dsName)
        Adapter = Nothing
    End Sub
    Public Sub SetDBEnvironment()
        Me.ExecuteNonQuery("SET LOCK_TIMEOUT -1 SET DATEFORMAT 'dmy'")
    End Sub
    Public Sub SetDBEnvironmentLong()
        Me.ExecuteNonQuery("SET LOCK_TIMEOUT 1800000 SET DATEFORMAT 'dmy'")
    End Sub
    Public Sub Connection(ByVal thisConnection As SqlConnection)
        Cnx = thisConnection
        Cmd.Connection = Cnx
    End Sub
End Class









