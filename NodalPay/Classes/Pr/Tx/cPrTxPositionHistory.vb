Public Class cPrTxPositionHistory
    Inherits cPrTxPositionHistoryDBTier
    Private mId As Integer
    Private mEmpCode As String
    Private mPosCode As String
    Private mPosDesc As String
    Private mPosDate As Date

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal value As String)
            mEmpCode = value
        End Set
    End Property
    Public Property PosCode() As String
        Get
            Return mPosCode
        End Get
        Set(ByVal value As String)
            mPosCode = value
        End Set
    End Property
    Public Property PosDesc() As String
        Get
            Return mPosDesc
        End Get
        Set(ByVal value As String)
            mPosDesc = value
        End Set
    End Property
    Public Property PosDate() As Date
        Get
            Return mPosDate
        End Get
        Set(ByVal value As Date)
            mPosDate = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Init(tId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mEmpCode = DbNullToString(dr.Item(1))
        mPosCode = DbNullToString(dr.Item(2))
        mPosDesc = DbNullToString(dr.Item(3))
        mPosDate = DbNullToDate(dr.Item(4))
    End Sub
    Public Shadows Function Save() As Boolean
        Return MyBase.Save(Me)
    End Function

End Class
