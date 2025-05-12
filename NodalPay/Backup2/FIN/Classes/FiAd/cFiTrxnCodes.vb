Public Class cFiTrxnCodes
    Inherits cFiTrxnCodesDBTier

    Private mCode As String
    Private mGrpCode As String
    Private mDescriptionL As String
    Private mDescriptionS As String
    Private mIsActive As String
    Private mRefSchId As Integer
    Private mJournalCode As String
    Private mDocTemplate As String
    Private mAutoPrint As String
    Private mAccountCodeHeader As String
    Private mAccountCodeDiscount As String
    Private mAccountCodeVAT As String
    Private mAllowLineDisc As String
    Private mAllowOverAllDisc As String
    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property GroupCode() As String
        Get
            Return mGrpCode
        End Get
        Set(ByVal Value As String)
            mGrpCode = Value
        End Set
    End Property
    Public Property DescriptionL() As String
        Get
            Return mDescriptionL
        End Get
        Set(ByVal Value As String)
            mDescriptionL = Value
        End Set
    End Property
    Public Property DescriptionS() As String
        Get
            Return mDescriptionS
        End Get
        Set(ByVal Value As String)
            mDescriptionS = Value
        End Set
    End Property
    Public Property IsActive() As String
        Get
            Return mIsActive
        End Get
        Set(ByVal Value As String)
            mIsActive = Value
        End Set
    End Property
    Public Property RefSchId() As Integer
        Get
            Return mRefSchId
        End Get
        Set(ByVal Value As Integer)
            mRefSchId = Value
        End Set
    End Property
    Public Property JouCode() As String
        Get
            Return mJournalCode
        End Get
        Set(ByVal value As String)
            mJournalCode = value
        End Set
    End Property
    Public Property DocTemplate() As String
        Get
            Return mDocTemplate
        End Get
        Set(ByVal value As String)
            mDocTemplate = value
        End Set
    End Property
    Public Property AutoPrint() As String
        Get
            Return mAutoPrint
        End Get
        Set(ByVal value As String)
            mAutoPrint = value
        End Set
    End Property
    Public Property AccountCodeHeader() As String
        Get
            Return mAccountCodeHeader
        End Get
        Set(ByVal value As String)
            mAccountCodeHeader = value
        End Set
    End Property
    Public Property AccountCodeDiscount() As String
        Get
            Return mAccountCodeDiscount
        End Get
        Set(ByVal value As String)
            mAccountCodeDiscount = value
        End Set
    End Property

    Public Property AccountCodeVAT() As String
        Get
            Return mAccountCodeVAT
        End Get
        Set(ByVal value As String)
            mAccountCodeVAT = value
        End Set
    End Property
    Public Property AllowLineDisc() As String
        Get
            Return mAllowLineDisc
        End Get
        Set(ByVal value As String)
            mAllowLineDisc = value
        End Set
    End Property
    Public Property AllowOverAllDisc() As String
        Get
            Return mAllowOverAllDisc
        End Get
        Set(ByVal value As String)
            mAllowOverAllDisc = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String, ByVal tGroup As String)
        If tCode <> "" Then
            Init(tCode, tGroup)
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Private Sub Init(ByVal tCode As String, ByVal tGroup As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tCode, tGroup)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToString(dr.Item(0))
        mGrpCode = DbNullToString(dr.Item(1))
        mDescriptionL = DbNullToString(dr.Item(2))
        mDescriptionS = DbNullToString(dr.Item(3))
        mIsActive = DbNullToString(dr.Item(4))
        mRefSchId = DbNullToInt(dr.Item(5))
        mJournalCode = DbNullToInt(dr.Item(6))
        mDocTemplate = DbNullToInt(dr.Item(7))
        mAutoPrint = DbNullToInt(dr.Item(8))
        mAccountCodeHeader = DbNullToInt(dr.Item(9))
        mAccountCodeDiscount = DbNullToInt(dr.Item(10))
        mAccountCodeVAT = DbNullToInt(dr.Item(11))
        mAllowLineDisc = DbNullToInt(dr.Item(12))
        mAllowOverAllDisc = DbNullToInt(dr.Item(13))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.DescriptionS
    End Function
End Class
