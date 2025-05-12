Public Class cFiTrxnHeader
    Inherits cFiTrxnHeaderDBTier
    '
    Private mId As Integer
    Private mTrxCodCode As String
    Private mBusPrtCode As String
    Private mPostDate As Date
    Private mInvDate As Date
    Private mDueDate As Date
    Private mRefNo As String
    Private mAcctRefNo As String
    Private mXRefNo As String
    Private mCurAlphaCode As String
    Private mCurRate As Double
    Private mIsVatIncluded As String
    Private mIsReversed As String
    Private mNotes As String
    Private mOverallDiscTrxn As Double
    Private mOverallDiscPerc As Double
    Private mOverallDiscVatTrxn As Double
    Private mTotalTrxn As Double
    Private mCreationDate As Date
    Private mAmendDate As Date
    Private mTotalVATTrxn As Double
    Private mCreatedBy As Integer
    Private mAmendBy As Integer
    Private mTrxnTypeFactor As Integer
    Private mFactor As Integer

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property TrxCodCode() As String
        Get
            Return mTrxCodCode
        End Get
        Set(ByVal Value As String)
            mTrxCodCode = Value
        End Set
    End Property
    Public Property BusPrtCode() As String
        Get
            Return mBusPrtCode
        End Get
        Set(ByVal Value As String)
            mBusPrtCode = Value
        End Set
    End Property
    Public Property PostDate() As Date
        Get
            Return mPostDate
        End Get
        Set(ByVal Value As Date)
            mPostDate = Value
        End Set
    End Property
    Public Property InvDate() As Date
        Get
            Return mInvDate
        End Get
        Set(ByVal Value As Date)
            mInvDate = Value
        End Set
    End Property
    Public Property DueDate() As Date
        Get
            Return mDueDate
        End Get
        Set(ByVal Value As Date)
            mDueDate = Value
        End Set
    End Property
    Public Property RefNo() As String
        Get
            Return mRefNo
        End Get
        Set(ByVal Value As String)
            mRefNo = Value
        End Set
    End Property
    Public Property AcctRefNo() As String
        Get
            Return mAcctRefNo
        End Get
        Set(ByVal Value As String)
            mAcctRefNo = Value
        End Set
    End Property
    Public Property XRefNo() As String
        Get
            Return mXRefNo
        End Get
        Set(ByVal Value As String)
            mXRefNo = Value
        End Set
    End Property
    Public Property CurAlphaCode() As String
        Get
            Return mCurAlphaCode
        End Get
        Set(ByVal Value As String)
            mCurAlphaCode = Value
        End Set
    End Property
    Public Property CurRate() As Double
        Get
            Return mCurRate
        End Get
        Set(ByVal Value As Double)
            mCurRate = Value
        End Set
    End Property
    Public Property IsVatIncluded() As String
        Get
            Return mIsVatIncluded
        End Get
        Set(ByVal Value As String)
            mIsVatIncluded = Value
        End Set
    End Property
    Public Property IsReversed() As String
        Get
            Return mIsReversed
        End Get
        Set(ByVal Value As String)
            mIsReversed = Value
        End Set
    End Property
    Public Property Notes() As String
        Get
            Return mNotes
        End Get
        Set(ByVal Value As String)
            mNotes = Value
        End Set
    End Property
    Public Property OverallDiscTrxn() As Double
        Get
            Return mOverallDiscTrxn
        End Get
        Set(ByVal Value As Double)
            mOverallDiscTrxn = Value
        End Set
    End Property
    Public Property OverallDiscPerc() As Double
        Get
            Return mOverallDiscPerc
        End Get
        Set(ByVal Value As Double)
            mOverallDiscPerc = Value
        End Set
    End Property
    Public Property OverallDiscVatTrxn() As Double
        Get
            Return mOverallDiscVatTrxn
        End Get
        Set(ByVal Value As Double)
            mOverallDiscVatTrxn = Value
        End Set
    End Property
    Public Property TotalTrxn() As Double
        Get
            Return mTotalTrxn
        End Get
        Set(ByVal Value As Double)
            mTotalTrxn = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            Return mCreationDate
        End Get
        Set(ByVal Value As Date)
            mCreationDate = Value
        End Set
    End Property
    Public Property AmendDate() As Date
        Get
            Return mAmendDate
        End Get
        Set(ByVal Value As Date)
            mAmendDate = Value
        End Set
    End Property
    Public Property TotalVATTrxn() As Double
        Get
            Return mTotalVATTrxn
        End Get
        Set(ByVal Value As Double)
            mTotalVATTrxn = Value
        End Set
    End Property
    Public Property CreatedBy() As Integer
        Get
            Return mCreatedBy
        End Get
        Set(ByVal Value As Integer)
            mCreatedBy = Value
        End Set
    End Property
    Public Property AmendBy() As Integer
        Get
            Return mAmendBy
        End Get
        Set(ByVal Value As Integer)
            mAmendBy = Value
        End Set
    End Property

    Public Property TrxnTypeFactor() As Integer
        Get
            Return mTrxnTypeFactor
        End Get
        Set(ByVal value As Integer)
            mTrxnTypeFactor = value
        End Set
    End Property

    Public Property Factor() As Integer
        Get
            Return mFactor
        End Get
        Set(ByVal value As Integer)
            mFactor = value
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
        mTrxCodCode = DbNullToString(dr.item(1))
        mBusPrtCode = DbNullToString(dr.item(2))
        mPostDate = DbNullToDate(dr.item(3))
        mInvDate = DbNullToDate(dr.item(4))
        mDueDate = DbNullToDate(dr.item(5))
        mRefNo = DbNullToString(dr.item(6))
        mAcctRefNo = DbNullToString(dr.item(7))
        mXRefNo = DbNullToString(dr.item(8))
        mCurAlphaCode = DbNullToString(dr.item(9))
        mCurRate = DbNullToDouble(dr.item(10))
        mIsVatIncluded = DbNullToString(dr.item(11))
        mIsReversed = DbNullToString(dr.item(12))
        mNotes = DbNullToString(dr.item(13))
        mOverallDiscTrxn = DbNullToDouble(dr.item(14))
        mOverallDiscPerc = DbNullToDouble(dr.item(15))
        mOverallDiscVatTrxn = DbNullToDouble(dr.item(16))
        mTotalTrxn = DbNullToDouble(dr.item(17))
        mCreationDate = DbNullToDate(dr.item(18))
        mAmendDate = DbNullToDate(dr.item(19))
        mTotalVATTrxn = DbNullToDouble(dr.item(20))
        mCreatedBy = DbNullToInt(dr.item(21))
        mAmendBy = DbNullToInt(dr.Item(22))
        mTrxnTypeFactor = DbNullToInt(dr.Item(23))
        mFactor = DbNullToInt(dr.Item(24))
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        If CanDelete <> True Then
            MsgBox("Transactions Exist For This item - Can not Delete")
            Exit Function
        End If
        Try
            Return MyBase.Delete(tId)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Private Function CanDelete() As Boolean
        Dim RecordCounter As Integer
        Dim Counter As Integer
        Dim Ds As DataSet
        Ds = MyBase.CheckDeleteRecords
        For Counter = 0 To ds.Tables.Count
            RecordCounter = RecordCounter + CInt(Ds.Tables(Counter).Rows(0).Item(0))
        Next Counter
        If RecordCounter = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

