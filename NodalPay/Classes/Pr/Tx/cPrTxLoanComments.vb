Public Class cPrTxLoanComments
    Inherits cPrTxLoanCommentsDBTier


    Private mId As Integer
    Private mEmpCode As String
    Private mLoanCode As String
    Private mMyDate As Date
    Private mAmount As Double
    Private mComment As String
    Private mType As String
    Private mChequeNo As String



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
    Public Property LoanCode() As String
        Get
            Return mLoanCode
        End Get
        Set(ByVal value As String)
            mLoanCode = value
        End Set
    End Property
    Public Property MyDate() As Date
        Get
            Return mMyDate
        End Get
        Set(ByVal value As Date)
            mMyDate = value
        End Set
    End Property
    Public Property Amount() As Double
        Get
            Return mAmount
        End Get
        Set(ByVal value As Double)
            mAmount = value
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
    Public Property MyType() As String
        Get
            Return mType
        End Get
        Set(ByVal value As String)
            mType = value
        End Set
    End Property

    Public Property ChequeNo() As String
        Get
            Return mChequeNo
        End Get
        Set(ByVal value As String)
            mChequeNo = value
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
        mLoanCode = DbNullToString(dr.Item(2))
        mMyDate = DbNullToDate(dr.Item(3))
        mAmount = DbNullToDouble(dr.Item(4))
        mComment = DbNullToString(dr.Item(5))
        mType = DbNullToString(dr.Item(6))
        mChequeNo = DbNullToString(dr.Item(7))

        
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Return MyBase.Delete(Me.Id)
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
