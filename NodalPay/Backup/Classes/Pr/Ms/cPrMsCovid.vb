Public Class cPrMsCovid
    Inherits cPrMsCovidDBTier
    Private mId As Integer
    Private mEmpCode As String
    Private mTemGrpCode As String
    Private mComCode As String
    Private mCovDate As String
    Private mCovWeek As String
    Private mCovMonth As Integer
    Private mCovResult As Integer
    Private mAnl1 As String
    Private mAnl2 As String
    Private mAnl3 As String
    Private mAnl4 As String
    Private mAnl5 As String
    Private mGenAnal1 As String


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
    Public Property TemGrpCode() As String
        Get
            Return mTemGrpCode
        End Get
        Set(ByVal value As String)
            mTemGrpCode = value
        End Set
    End Property
    Public Property ComCode() As String
        Get
            Return mComCode
        End Get
        Set(ByVal value As String)
            mComCode = value
        End Set
    End Property
    Public Property CovDate() As String
        Get
            Return mCovDate
        End Get
        Set(ByVal value As String)
            mCovDate = value
        End Set
    End Property
    Public Property CovWeek() As String
        Get
            Return mCovWeek
        End Get
        Set(ByVal value As String)
            mCovWeek = value
        End Set
    End Property
    Public Property CovMonth() As Integer
        Get
            Return mCovMonth
        End Get
        Set(ByVal value As Integer)
            mCovMonth = value
        End Set
    End Property
    Public Property CovResult() As Integer
        Get
            Return mCovResult
        End Get
        Set(ByVal value As Integer)
            mCovResult = value
        End Set
    End Property
    Public Property Anl1() As String
        Get
            Return mAnl1
        End Get
        Set(ByVal value As String)
            mAnl1 = value
        End Set
    End Property
    Public Property Anl2() As String
        Get
            Return mAnl2
        End Get
        Set(ByVal value As String)
            mAnl2 = value
        End Set
    End Property
    Public Property Anl3() As String
        Get
            Return mAnl3
        End Get
        Set(ByVal value As String)
            mAnl3 = value
        End Set
    End Property
    Public Property Anl4() As String
        Get
            Return mAnl4
        End Get
        Set(ByVal value As String)
            mAnl4 = value
        End Set
    End Property
    Public Property Anl5() As String
        Get
            Return mAnl5
        End Get
        Set(ByVal value As String)
            mAnl5 = value
        End Set
    End Property
    Public Property GenAnal1() As String
        Get
            Return mGenAnal1
        End Get
        Set(ByVal value As String)
            mGenAnal1 = value
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
        mId = DbNullToInt(dr.Item(0))
        mEmpCode = DbNullToString(dr.Item(1))
        mTemGrpCode = DbNullToString(dr.Item(2))
        mComCode = DbNullToString(dr.Item(3))
        mCovDate = DbNullToString(dr.Item(4))
        mCovWeek = DbNullToString(dr.Item(5))
        mCovMonth = DbNullToInt(dr.Item(6))
        mCovResult = DbNullToInt(dr.Item(7))
        mAnl1 = DbNullToString(dr.Item(8))
        mAnl2 = DbNullToString(dr.Item(9))
        mAnl3 = DbNullToString(dr.Item(10))
        mAnl4 = DbNullToString(dr.Item(11))
        mAnl5 = DbNullToString(dr.Item(12))
        mGenAnal1 = DbNullToString(dr.Item(13))
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Return MyBase.Delete(tId)
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
