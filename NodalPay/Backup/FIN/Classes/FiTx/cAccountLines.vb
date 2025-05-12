Public Class cAccountLines
    Inherits cAccountLinesDBTier
    Private mId As Integer
    Private mJournalCode As String
    Private mJournalNumber As Integer
    Private mJournalLineNo As Integer
    Private mDocRef As String
    Private mAltRef As String
    Private mDocDate As Date
    Private mPostDate As Date
    Private mDueDate As Date
    Private mPeriodCode As Integer
    Private mAccountCode As String
    Private mBusPrtCode As String
    Private mDrCr As String
    Private mAmountLocCur As Double
    Private mCurAlphaCode As String
    Private mAmountTrxCur As Double
    Private mCurRate As Double
    Private mTrxCurDecimal As Integer
    Private mAcLAn1Code As String
    Private mAcLAn2Code As String
    Private mAcLAn3Code As String
    Private mAcLAn4Code As String
    Private mAcLAn5Code As String
    Private mAcLAn6Code As String
    Private mAcLAn7Code As String
    Private mAcLAn8Code As String
    Private mAcLAn9Code As String
    Private mAcLAn10Code As String
    Private mAllocStatus As String
    Private mAllocRef As Integer
    Private mUnAllocBalanceLC As Double
    Private mUnAllocBalanceTC As Double
    Private mAllocDate As Date
    Private mAllocPeriod As Integer
    Private mComment As String
    Private mExternalRef As Integer
    Private mModule As String
    Private mModRef As Integer
    Private mCreationDate As Date
    Private mAmendDate As Date
    Private mCreatedBy As Integer
    Private mAmendBy As Integer
    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property JournalCode() As String
        Get
            Return mJournalCode
        End Get
        Set(ByVal Value As String)
            mJournalCode = Value
        End Set
    End Property
    Public Property JournalNumber() As Integer
        Get
            Return mJournalNumber
        End Get
        Set(ByVal Value As Integer)
            mJournalNumber = Value
        End Set
    End Property
    Public Property JournalLineNo() As Integer
        Get
            Return mJournalLineNo
        End Get
        Set(ByVal Value As Integer)
            mJournalLineNo = Value
        End Set
    End Property
    Public Property DocRef() As String
        Get
            Return mDocRef
        End Get
        Set(ByVal Value As String)
            mDocRef = Value
        End Set
    End Property
    Public Property AltRef() As String
        Get
            Return mAltRef
        End Get
        Set(ByVal Value As String)
            mAltRef = Value
        End Set
    End Property
    Public Property DocDate() As Date
        Get
            Return mDocDate
        End Get
        Set(ByVal Value As Date)
            mDocDate = Value
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
    Public Property DueDate() As Date
        Get
            Return mDueDate
        End Get
        Set(ByVal Value As Date)
            mDueDate = Value
        End Set
    End Property
    Public Property PeriodCode() As Integer
        Get
            Return mPeriodCode
        End Get
        Set(ByVal Value As Integer)
            mPeriodCode = Value
        End Set
    End Property
    Public Property AccountCode() As String
        Get
            Return mAccountCode
        End Get
        Set(ByVal Value As String)
            mAccountCode = Value
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
    Public Property DrCr() As String
        Get
            Return mDrCr
        End Get
        Set(ByVal Value As String)
            mDrCr = Value
        End Set
    End Property
    Public Property AmountLocCur() As Double
        Get
            Return mAmountLocCur
        End Get
        Set(ByVal Value As Double)
            mAmountLocCur = Value
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
    Public Property AmountTrxCur() As Double
        Get
            Return mAmountTrxCur
        End Get
        Set(ByVal Value As Double)
            mAmountTrxCur = Value
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
    Public Property TrxCurDecimal() As Integer
        Get
            Return mTrxCurDecimal
        End Get
        Set(ByVal Value As Integer)
            mTrxCurDecimal = Value
        End Set
    End Property
    Public Property AcLAn1Code() As String
        Get
            Return mAcLAn1Code
        End Get
        Set(ByVal Value As String)
            mAcLAn1Code = Value
        End Set
    End Property
    Public Property AcLAn2Code() As String
        Get
            Return mAcLAn2Code
        End Get
        Set(ByVal Value As String)
            mAcLAn2Code = Value
        End Set
    End Property
    Public Property AcLAn3Code() As String
        Get
            Return mAcLAn3Code
        End Get
        Set(ByVal Value As String)
            mAcLAn3Code = Value
        End Set
    End Property
    Public Property AcLAn4Code() As String
        Get
            Return mAcLAn4Code
        End Get
        Set(ByVal Value As String)
            mAcLAn4Code = Value
        End Set
    End Property
    Public Property AcLAn5Code() As String
        Get
            Return mAcLAn5Code
        End Get
        Set(ByVal Value As String)
            mAcLAn5Code = Value
        End Set
    End Property
    Public Property AcLAn6Code() As String
        Get
            Return mAcLAn6Code
        End Get
        Set(ByVal Value As String)
            mAcLAn6Code = Value
        End Set
    End Property
    Public Property AcLAn7Code() As String
        Get
            Return mAcLAn7Code
        End Get
        Set(ByVal Value As String)
            mAcLAn7Code = Value
        End Set
    End Property
    Public Property AcLAn8Code() As String
        Get
            Return mAcLAn8Code
        End Get
        Set(ByVal Value As String)
            mAcLAn8Code = Value
        End Set
    End Property
    Public Property AcLAn9Code() As String
        Get
            Return mAcLAn9Code
        End Get
        Set(ByVal Value As String)
            mAcLAn9Code = Value
        End Set
    End Property
    Public Property AcLAn10Code() As String
        Get
            Return mAcLAn10Code
        End Get
        Set(ByVal Value As String)
            mAcLAn10Code = Value
        End Set
    End Property
    Public Property AllocStatus() As String
        Get
            Return mAllocStatus
        End Get
        Set(ByVal Value As String)
            mAllocStatus = Value
        End Set
    End Property
    Public Property AllocRef() As Integer
        Get
            Return mAllocRef
        End Get
        Set(ByVal Value As Integer)
            mAllocRef = Value
        End Set
    End Property
    Public Property UnAllocBalanceLC() As Double
        Get
            Return mUnAllocBalanceLC
        End Get
        Set(ByVal Value As Double)
            mUnAllocBalanceLC = Value
        End Set
    End Property
    Public Property UnAllocBalanceTC() As Double
        Get
            Return mUnAllocBalanceTC
        End Get
        Set(ByVal Value As Double)
            mUnAllocBalanceTC = Value
        End Set
    End Property
    Public Property AllocDate() As Date
        Get
            Return mAllocDate
        End Get
        Set(ByVal Value As Date)
            mAllocDate = Value
        End Set
    End Property
    Public Property AllocPeriod() As Integer
        Get
            Return mAllocPeriod
        End Get
        Set(ByVal Value As Integer)
            mAllocPeriod = Value
        End Set
    End Property
    Public Property Comment() As String
        Get
            Return mComment
        End Get
        Set(ByVal Value As String)
            mComment = Value
        End Set
    End Property
    Public Property ExternalRef() As Integer
        Get
            Return mExternalRef
        End Get
        Set(ByVal Value As Integer)
            mExternalRef = Value
        End Set
    End Property
    Public Property MyModule() As String
        Get
            Return mModule
        End Get
        Set(ByVal Value As String)
            mModule = Value
        End Set
    End Property
    Public Property ModRef() As Integer
        Get
            Return mModRef
        End Get
        Set(ByVal Value As Integer)
            mModRef = Value
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

    Public Sub New()

    End Sub
    Public Sub New(ByVal tJournalCode As String)
        If tJournalCode > 0 Then
            Init(tJournalCode)
        End If

    End Sub
    Private Sub Init(ByVal tJournalCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tJournalCode)
            If CheckDataset(ds) Then
                LoadDataRow(ds.tables(0).rows(0))
            End If
        Catch ex As system.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mJournalCode = DbNullToString(dr.Item(1))
        mJournalNumber = DbNullToInt(dr.Item(2))
        mJournalLineNo = DbNullToInt(dr.Item(3))
        mDocRef = DbNullToString(dr.Item(4))
        mAltRef = DbNullToString(dr.Item(5))
        mDocDate = DbNullToDate(dr.Item(6))
        mPostDate = DbNullToDate(dr.Item(7))
        mDueDate = DbNullToDate(dr.Item(8))
        mPeriodCode = DbNullToInt(dr.Item(9))
        mAccountCode = DbNullToString(dr.Item(10))
        mBusPrtCode = DbNullToString(dr.Item(11))
        mDrCr = DbNullToString(dr.Item(12))
        mAmountLocCur = DbNullToDouble(dr.Item(13))
        mCurAlphaCode = DbNullToString(dr.Item(14))
        mAmountTrxCur = DbNullToDouble(dr.Item(15))
        mCurRate = DbNullToDouble(dr.Item(16))
        mTrxCurDecimal = DbNullToInt(dr.Item(17))
        mAcLAn1Code = DbNullToString(dr.Item(18))
        mAcLAn2Code = DbNullToString(dr.Item(19))
        mAcLAn3Code = DbNullToString(dr.Item(20))
        mAcLAn4Code = DbNullToString(dr.Item(21))
        mAcLAn5Code = DbNullToString(dr.Item(22))
        mAcLAn6Code = DbNullToString(dr.Item(23))
        mAcLAn7Code = DbNullToString(dr.Item(24))
        mAcLAn8Code = DbNullToString(dr.Item(25))
        mAcLAn9Code = DbNullToString(dr.Item(26))
        mAcLAn10Code = DbNullToString(dr.Item(27))
        mAllocStatus = DbNullToString(dr.Item(28))
        mAllocRef = DbNullToInt(dr.Item(29))
        mUnAllocBalanceLC = DbNullToDouble(dr.Item(30))
        mUnAllocBalanceTC = DbNullToDouble(dr.Item(31))
        mAllocDate = DbNullToDate(dr.Item(32))
        mAllocPeriod = DbNullToInt(dr.Item(33))
        mComment = DbNullToString(dr.Item(34))
        mExternalRef = DbNullToInt(dr.Item(35))
        mModule = DbNullToString(dr.Item(36))
        mModRef = DbNullToInt(dr.Item(37))
        mCreationDate = DbNullToDate(dr.Item(38))
        mAmendDate = DbNullToDate(dr.Item(39))
        mCreatedBy = DbNullToInt(dr.Item(40))
        mAmendBy = DbNullToInt(dr.Item(41))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
