Public Class cTaTxTrxnLines2
    Inherits cTaTxTrxnLines2DBTier
    Private mId As Integer
    Private mDate As Date
    Private mEmpCode As String
    Private mDay As String
    Private mFromTime As String
    Private mToTime As String
    Private mTotalTime As Double
    Private mWorkGroupCode As String
    Private mWorkCode As String
    Private mUserId_Create As Integer
    Private mUserId_LastUpdate As Integer
    Private mCreated As Date
    Private mLastUpdate As Date
    Private mStatus As String
    Private mAnalCode As String
    Private mAnalDesc As String


    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property Mydate() As Date
        Get
            Return mDate
        End Get
        Set(ByVal value As Date)
            mDate = value
        End Set
    End Property
    Public Property EmployeeCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal value As String)
            mEmpCode = value
        End Set
    End Property
    Public Property Day() As String
        Get
            Return mDay
        End Get
        Set(ByVal value As String)
            mDay = value
        End Set
    End Property
    Public Property FromTime() As String
        Get
            Return mFromTime
        End Get
        Set(ByVal value As String)
            mFromTime = value
        End Set
    End Property
    Public Property ToTime() As String
        Get
            Return mToTime
        End Get
        Set(ByVal value As String)
            mToTime = value
        End Set
    End Property
    Public Property TotalTime() As Double
        Get
            Return mTotalTime
        End Get
        Set(ByVal value As Double)
            mTotalTime = value
        End Set
    End Property
    Public Property WorkGroupCode() As String
        Get
            Return mWorkGroupCode
        End Get
        Set(ByVal value As String)
            mWorkGroupCode = value
        End Set
    End Property
    Public Property WorkCode() As String
        Get
            Return mWorkCode
        End Get
        Set(ByVal value As String)
            mWorkCode = value
        End Set
    End Property
    Public Property UserId_Create() As Integer
        Get
            Return mUserId_Create
        End Get
        Set(ByVal value As Integer)
            mUserId_Create = value
        End Set
    End Property
    Public Property UserId_LastUpdate() As Integer
        Get
            Return mUserId_LastUpdate
        End Get
        Set(ByVal value As Integer)
            mUserId_LastUpdate = value
        End Set
    End Property
    Public Property Created() As Date
        Get
            Return mCreated
        End Get
        Set(ByVal value As Date)
            mCreated = value
        End Set
    End Property
    Public Property LastUpdate() As Date
        Get
            Return mLastUpdate
        End Get
        Set(ByVal value As Date)
            mLastUpdate = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal value As String)
            mStatus = value
        End Set
    End Property
    Public Property AnalCode() As String
        Get
            Return mAnalCode
        End Get
        Set(ByVal value As String)
            mAnalCode = value
        End Set
    End Property
    Public Property AnalDesc() As String
        Get
            Return mAnalDesc
        End Get
        Set(ByVal value As String)
            mAnalDesc = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId > 0 Then
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDatarow(ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal Dt As DataRow)
        LoadDatarow(Dt)
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shadows Function Delete() As Boolean
        Try
            Return MyBase.Delete(Me)
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub LoadDatarow(ByVal dt As DataRow)
        mId = DbNullToInt(dt.Item(0))
        mDate = DbNullToDate(dt.Item(1))
        mEmpCode = DbNullToString(dt.Item(2))
        mDay = DbNullToString(dt.Item(3))
        mFromTime = DbNullToString(dt.Item(4))
        mToTime = DbNullToString(dt.Item(5))
        mTotalTime = DbNullToDouble(dt.Item(6))
        mWorkGroupCode = DbNullToString(dt.Item(7))
        mWorkCode = DbNullToString(dt.Item(8))
        mUserId_Create = DbNullToInt(dt.Item(9))
        mUserId_LastUpdate = DbNullToInt(dt.Item(10))
        mCreated = DbNullToDate(dt.Item(11))
        mLastUpdate = DbNullToDate(dt.Item(12))
        mStatus = DbNullToString(dt.Item(13))
        mAnalCode = DbNullToString(dt.Item(14))
        mAnalDesc = DbNullToString(dt.Item(15))
    End Sub
End Class
