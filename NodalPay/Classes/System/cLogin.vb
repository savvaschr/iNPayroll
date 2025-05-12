Public Class cLogin

    Inherits cDataTier
    Public ReadOnly Property IsConnected() As Boolean
        Get
            If Cnx.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Friend Function TryToConnect(ByVal thisConnectionString As String, ByVal UseThisIfSuccess As Boolean) As Boolean
        Dim Success As Boolean = False
        Debug.WriteLine(thisConnectionString)
        Try
            Dim thisCnx As New SqlClient.SqlConnection
            Debug.WriteLine(thisConnectionString)
            thisCnx.ConnectionString = thisConnectionString
            thisCnx.Open()

            If UseThisIfSuccess Then
                Cnx.Close()
                Me.ConnectionString = thisConnectionString

                Cnx = thisCnx

                Cmd.Connection = Cnx


                SetDBEnvironment()
            Else
                thisCnx.Close()
                thisCnx.Dispose()
            End If
            thisCnx = Nothing

            If Cnx.State = ConnectionState.Open Then
                Success = True
                Global1.IsConnected = True
            Else
                Global1.IsConnected = False
            End If
        Catch e As System.Exception

            ShowException(e)
        End Try

        Return Success
    End Function


    Friend Function Logout() As Boolean
        If Cnx.State = ConnectionState.Open Then
            Cnx.Close()
        End If
        If Cnx.State = ConnectionState.Closed Then
            Me.ConnectionString = ""
            Global1.IsConnected = False
            Return True
        Else
            Return False
        End If


    End Function
    Protected Sub Shutdown()
        Rollback()

        If Not IsNothing(Cmd) Then
            Cmd.Dispose()
        End If

        If Not IsNothing(Cnx) Then
            Cnx.Close()
        End If
        Cnx.Dispose()
    End Sub

End Class





