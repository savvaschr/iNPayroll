Public Class cPrSsNavBatch
    Inherits cPrSsNavBatchDBTier
    Private mId As Integer
    Private mIdFrom As Integer
    Private mIdTo As Integer
    Private mTemGrpCode As String
    Private mUser As String
    Private mFirstCreation As Date
    Private mLastCreation As Date
    Private mTimes As Integer
    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property IdFrom() As Integer
        Get
            Return mIdFrom
        End Get
        Set(ByVal value As Integer)
            mIdFrom = value
        End Set
    End Property
    Public Property IdTo() As Integer
        Get
            Return mIdTo
        End Get
        Set(ByVal value As Integer)
            mIdTo = value
        End Set
    End Property
    Public Property TemGrpCode() As String
        Get
            Return mTemGrpCode
        End Get
        Set(ByVal value As String)
            mTemGrpCode = value
        End Set
    End Property
    Public Property User() As String
        Get
            Return mUser
        End Get
        Set(ByVal value As String)
            mUser = value
        End Set
    End Property
    Public Property FirstCreation() As Date
        Get
            Return mFirstCreation
        End Get
        Set(ByVal value As Date)
            mFirstCreation = value
        End Set
    End Property
    Public Property LastCreation() As Date
        Get
            Return mLastCreation
        End Get
        Set(ByVal value As Date)
            mLastCreation = value
        End Set
    End Property
    Public Property Times() As Integer
        Get
            Return mTimes
        End Get
        Set(ByVal value As Integer)
            mTimes = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Init(tId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mIdFrom = DbNullToInt(dr.Item(1))
        mIdTo = DbNullToInt(dr.Item(2))
        mTemGrpCode = DbNullToString(dr.Item(3))
        mUser = DbNullToString(dr.Item(4))
        mFirstCreation = DbNullToDate(dr.Item(5))
        mLastCreation = DbNullToDate(dr.Item(6))
        mTimes = DbNullToInt(dr.Item(7))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
