Public Class cPrMsEarningsInterface
    Inherits cPrMsEarningsInterfaceDBTier
    Private mId As Integer
    Private mIntTemCode As String
    Private mTemGrpCode As String
    Private mErnCode As String
    Private mCreditAccount As String
    Private mCreditConsol As String
    Private mDebitAccount As String
    Private mDebitConsol As String
    Private mCreditAnal As String
    Private mDebitAnal As String

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property IntTemCode() As String
        Get
            Return mIntTemCode
        End Get
        Set(ByVal value As String)
            mIntTemCode = value
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
    Public Property ErnCode() As String
        Get
            Return mErnCode
        End Get
        Set(ByVal value As String)
            mErnCode = value
        End Set
    End Property
    Public Property CreditAccount() As String
        Get
            Return mCreditAccount
        End Get
        Set(ByVal value As String)
            mCreditAccount = value
        End Set
    End Property
    Public Property CreditConsol() As String
        Get
            Return mCreditConsol
        End Get
        Set(ByVal value As String)
            mCreditConsol = value
        End Set
    End Property
    Public Property DebitAccount() As String
        Get
            Return mDebitAccount
        End Get
        Set(ByVal value As String)
            mDebitAccount = value
        End Set
    End Property
    Public Property DebitConsol() As String
        Get
            Return mDebitConsol
        End Get
        Set(ByVal value As String)
            mDebitConsol = value
        End Set
    End Property
    Public Property CreditAnal() As String
        Get
            Return mCreditAnal
        End Get
        Set(ByVal value As String)
            mCreditanal = value
        End Set
    End Property
    Public Property DebitAnal() As String
        Get
            Return mDebitAnal
        End Get
        Set(ByVal value As String)
            mDebitAnal = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        Dim ds As DataSet
        ds = MyBase.getbyid(tId)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String, ByVal tErnCode As String)
        Dim ds As DataSet
        ds = MyBase.getbyPK(tTemGrp_Code, tIntTem_Code, tErnCode)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)

        mId = DbNullToInt(dr.Item(0))
        mIntTemCode = DbNullToString(dr.Item(1))
        mTemGrpCode = DbNullToString(dr.Item(2))
        mErnCode = DbNullToString(dr.Item(3))
        mCreditAccount = DbNullToString(dr.Item(4))
        mCreditConsol = DbNullToString(dr.Item(5))
        mDebitAccount = DbNullToString(dr.Item(6))
        mDebitConsol = DbNullToString(dr.Item(7))
        mCreditAnal = DbNullToString(dr.Item(8))
        mDebitAnal = DbNullToString(dr.Item(9))

    End Sub

    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    


End Class
