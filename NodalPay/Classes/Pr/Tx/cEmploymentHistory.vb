Public Class cEmploymentHistory
    Inherits cEmploymentHistoryDBTier

    Private mId As Integer
    Private mEmpCode As String
    Private mStartDate As Date
    Private mEndDate As Date

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
    Public Property StartDate() As Date
        Get
            Return mStartDate
        End Get
        Set(ByVal value As Date)
            mStartDate = value
        End Set
    End Property
    Public Property EndDate() As Date
        Get
            Return mEndDate
        End Get
        Set(ByVal value As Date)
            mEndDate = value
        End Set
    End Property
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
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
        mStartDate = DbNullToDate(dr.Item(2))
        mEndDate = DbNullToDate(dr.Item(3))
    End Sub
    Public Shadows Function Save() As Boolean
        Return MyBase.Save(Me)
    End Function

End Class
