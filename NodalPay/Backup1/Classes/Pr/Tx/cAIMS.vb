Public Class cAIMS
    Inherits cAIMSDBTier
    Private mNo As String
    Private mEmployee As String
    Private mDutyHours As String
    Private mSectors As String
    Private mFlightHours As String

    Public Property No() As String
        Get
            Return mNo
        End Get
        Set(ByVal value As String)
            mNo = value
        End Set
    End Property
    Public Property Employee() As String
        Get
            Return mEmployee
        End Get
        Set(ByVal value As String)
            mEmployee = Replace(value, """", "")
        End Set
    End Property
    Public Property DutyHours() As String
        Get
            Return mDutyHours
        End Get
        Set(ByVal value As String)
            mDutyHours = value
        End Set
    End Property
    Public Property Sectors() As String
        Get
            Return mSectors
        End Get
        Set(ByVal value As String)
            mSectors = value
        End Set
    End Property
    Public Property FlightHours() As String
        Get
            Return mFlightHours
        End Get
        Set(ByVal value As String)
            mFlightHours = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tEmpCode As String)
        If tEmpCode <> "" Then
            Try
                Dim ds As DataSet
                ds = MyBase.GetByPK(tEmpCode)
                If CheckDataSet(ds) Then
                    LoadDataRow(ds.Tables(0).Rows(0))
                End If
            Catch ex As System.Exception
            End Try
        End If
    End Sub

    Private Sub LoadDataRow(ByVal dr As DataRow)
        mNo = DbNullToString(dr.Item(0))
        mEmployee = DbNullToString(dr.Item(1))
        mSectors = DbNullToString(dr.Item(2))
        mDutyHours = DbNullToString(dr.Item(3))
        mFlightHours = DbNullToString(dr.Item(4))
    End Sub

    '
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function

End Class
