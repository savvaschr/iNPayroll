Public Class cPrTxEmployeeLeave
    Inherits cPrTxEmployeeLeaveDBTier
    '
    Private mId As Integer
    Private mStatus As String
    Private mEmpCode As String
    Private mType As String
    Private mReqDate As Date
    Private mProcDate As Date
    Private mProcBy As Integer
    Private mFromDate As Date
    Private mToDate As Date
    Private mUnits As Double
    Private mAction As String
    Private mHdrId As Integer
    Private mComment As String
    Private mApprovedBy As String

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
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
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal value As String)
            mEmpCode = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return mType
        End Get
        Set(ByVal value As String)
            mType = value
        End Set
    End Property
    Public Property ReqDate() As Date
        Get
            Return mReqDate
        End Get
        Set(ByVal value As Date)
            mReqDate = value
        End Set
    End Property
    Public Property ProcDate() As Date
        Get
            Return mProcDate
        End Get
        Set(ByVal value As Date)
            mProcDate = value
        End Set
    End Property
    Public Property ProcBy() As Integer
        Get
            Return mProcBy
        End Get
        Set(ByVal value As Integer)
            mProcBy = value
        End Set
    End Property
    Public Property FromDate() As Date
        Get
            Return mFromDate
        End Get
        Set(ByVal value As Date)
            mFromDate = value
        End Set
    End Property
    Public Property ToDate() As Date
        Get
            Return mToDate
        End Get
        Set(ByVal value As Date)
            mToDate = value
        End Set
    End Property
    Public Property Units() As Double
        Get
            Return mUnits
        End Get
        Set(ByVal value As Double)
            mUnits = value
        End Set
    End Property
    Public Property Action() As String
        Get
            Return mAction
        End Get
        Set(ByVal value As String)
            mAction = value
        End Set
    End Property
    Public Property HdrId() As Integer
        Get
            Return mHdrId
        End Get
        Set(ByVal value As Integer)
            mHdrId = value
        End Set
    End Property
    Public Property Comment() As String
        Get
            Return mComment
        End Get
        Set(ByVal value As String)
            mComment = value
        End Set
    End Property
    Public Property ApprovedBy() As String
        Get
            Return mApprovedBy
        End Get
        Set(ByVal value As String)
            mApprovedBy = value
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
            ds = MyBase.GetByPK(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.item(0))
        mStatus = DbNullToString(dr.Item(1))
        mEmpCode = DbNullToString(dr.Item(2))
        mType = DbNullToString(dr.Item(3))
        mReqDate = DbNullToDate(dr.Item(4))
        mProcDate = DbNullToDate(dr.Item(5))
        mProcBy = DbNullToInt(dr.Item(6))
        mFromDate = DbNullToDate(dr.Item(7))
        mToDate = DbNullToDate(dr.Item(8))
        mUnits = DbNullToDouble(dr.Item(9))
        mAction = DbNullToString(dr.Item(10))
        mHdrId = DbNullToInt(dr.Item(11))
        mComment = DbNullToString(dr.Item(12))
        mApprovedBy = DbNullToString(dr.Item(13))
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Dim Counter As Integer
            Dim TableCount As Integer
            Dim RecordCount As Integer
            Dim TransStr As String = ""
            Dim ds As DataSet
            ds = MyBase.CheckDeleteRecords(tId)
            If CheckDataSet(ds) Then
                For Counter = 0 To ds.Tables.Count - 1
                    TableCount = TableCount + 1
                    RecordCount = RecordCount + DbNullToInt(ds.Tables(Counter).Rows(0).Item(0))
                    TransStr = TransStr & vbCrLf & "Table " & TableCount & "  Records " & RecordCount
                Next Counter
                If RecordCount = 0 Then
                    Return MyBase.Delete(tId)
                Else
                    MsgBox("Transactions Exist For This item - Can not Delete" & TransStr, MsgBoxStyle.Critical)
                End If
            Else
                Return MyBase.Delete(tId)
            End If
        Catch ex As System.Exception
        End Try
    End Function
    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
