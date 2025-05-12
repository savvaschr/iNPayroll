Public Class cBusinessPartner
    Inherits cBusinessPartnerDBTier
    Private mCode As String
    Private mDescL As String
    Private mDescS As String
    Private mConsolidationCode As String
    Private mAnal1 As String
    Private mAnal2 As String
    Private mAnal3 As String
    Private mAnal4 As String
    Private mAnal5 As String
    Private mBudType As String
    Private mVisitFreq As String
    Private mAdrId1 As Integer
    Private mAdrId2 As Integer
    Private mAdrId3 As Integer
    Private mTAXId As String
    Private mVATRegNo As String
    Private mIsVatEnabled As String
    Private mIsVatIncluded As String
    Private mIdNo As String
    Private mAccountCode As String
    Private mStatusCode As String
    Private mTypeCode As String
    Private mTrmCode As String
    Private mCreatedBy As Integer
    Private mCreationDate As Date
    Private mAmendBy As Integer
    Private mAmendDate As Date
    Private mCurAlphaCode As String
    Private mCreditProfileCode As String




    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property DescL() As String
        Get
            Return mDescL
        End Get
        Set(ByVal Value As String)
            mDescL = Value
        End Set
    End Property
    Public Property DescS() As String
        Get
            Return mDescS
        End Get
        Set(ByVal Value As String)
            mDescS = Value
        End Set
    End Property
    Public Property ConsolidationCode() As String
        Get
            Return mConsolidationCode
        End Get
        Set(ByVal Value As String)
            mConsolidationCode = Value
        End Set
    End Property
    Public Property Anal1() As String
        Get
            Return mAnal1
        End Get
        Set(ByVal Value As String)
            mAnal1 = Value
        End Set
    End Property
    Public Property Anal2() As String
        Get
            Return mAnal2
        End Get
        Set(ByVal Value As String)
            mAnal2 = Value
        End Set
    End Property
    Public Property Anal3() As String
        Get
            Return mAnal3
        End Get
        Set(ByVal Value As String)
            mAnal3 = Value
        End Set
    End Property
    Public Property Anal4() As String
        Get
            Return mAnal4
        End Get
        Set(ByVal Value As String)
            mAnal4 = Value
        End Set
    End Property
    Public Property Anal5() As String
        Get
            Return mAnal5
        End Get
        Set(ByVal Value As String)
            mAnal5 = Value
        End Set
    End Property
    Public Property BudType() As String
        Get
            Return mBudType
        End Get
        Set(ByVal Value As String)
            mBudType = Value
        End Set
    End Property
    Public Property VisitFreq() As String
        Get
            Return mVisitFreq
        End Get
        Set(ByVal Value As String)
            mVisitFreq = Value
        End Set
    End Property
   
    Public Property AdrId1() As Integer
        Get
            Return mAdrId1
        End Get
        Set(ByVal Value As Integer)
            mAdrId1 = Value
        End Set
    End Property
    Public Property AdrId2() As Integer
        Get
            Return mAdrId2
        End Get
        Set(ByVal Value As Integer)
            mAdrId2 = Value
        End Set
    End Property
    Public Property AdrId3() As Integer
        Get
            Return mAdrId3
        End Get
        Set(ByVal Value As Integer)
            mAdrId3 = Value
        End Set
    End Property
    Public Property TAXId() As String
        Get
            Return mTAXId
        End Get
        Set(ByVal Value As String)
            mTAXId = Value
        End Set
    End Property
  
    Public Property VATRegNo() As String
        Get
            Return mVATRegNo
        End Get
        Set(ByVal Value As String)
            mVATRegNo = Value
        End Set
    End Property
    Public Property IsVATEnabled() As String
        Get
            Return Me.mIsVatEnabled
        End Get
        Set(ByVal value As String)
            Me.mIsVatEnabled = value
        End Set
    End Property
    Public Property IsVATIncluded() As String
        Get
            Return Me.mIsVatIncluded
        End Get
        Set(ByVal value As String)
            Me.mIsVatIncluded = value
        End Set
    End Property

    Public Property IdNo() As String
        Get
            Return mIdNo
        End Get
        Set(ByVal Value As String)
            mIdNo = Value
        End Set
    End Property
    Public Property AccountCode() As String
        Get
            Return Me.mAccountCode
        End Get
        Set(ByVal value As String)
            Me.mAccountCode = value
        End Set
    End Property
    Public Property StatusCode() As String
        Get
            Return Me.mStatusCode
        End Get
        Set(ByVal value As String)
            Me.mStatusCode = value
        End Set
    End Property
    Public Property TypeCode() As String
        Get
            Return Me.mTypeCode
        End Get
        Set(ByVal value As String)
            Me.mTypeCode = value
        End Set
    End Property
    Public Property TrmCode() As String
        Get
            Return mTrmCode
        End Get
        Set(ByVal value As String)
            mTrmCode = value
        End Set
    End Property
    Public Property CreatedBy() As Integer
        Get
            Return Me.mCreatedBy
        End Get
        Set(ByVal value As Integer)
            Me.mCreatedBy = value
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
    Public Property AmendBy() As Integer
        Get
            Return mAmendBy
        End Get
        Set(ByVal value As Integer)
            mAmendBy = value
        End Set
    End Property
    Public Property AmendDate() As Date
        Get
            Return mAmendDate
        End Get
        Set(ByVal Value As Date)
            mamendDate = Value
        End Set
    End Property
    Public Property CurAlphaCode() As String
        Get
            Return mCurAlphaCode
        End Get
        Set(ByVal value As String)
            mCurAlphaCode = value
        End Set
    End Property
    Public Property CreditProfileCode() As String
        Get
            Return mCreditProfileCode
        End Get
        Set(ByVal value As String)
            mCreditProfileCode = value
        End Set
    End Property


    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String)
        If tCode <> "" Then
            Init(tCode)
        End If

    End Sub
    Private Sub Init(ByVal tCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByCode(tCode)
            If CheckDataset(ds) Then
                LoadDataRow(ds.tables(0).rows(0))
            End If
        Catch ex As system.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = dbNullToString(dr.item(0))
        mDescL = dbNullToString(dr.item(1))
        mDescS = dbNullToString(dr.item(2))
        mConsolidationCode = dbNullToString(dr.item(3))
        mAnal1 = dbNullToString(dr.item(4))
        mAnal2 = dbNullToString(dr.item(5))
        mAnal3 = dbNullToString(dr.item(6))
        mAnal4 = dbNullToString(dr.item(7))
        mAnal5 = dbNullToString(dr.item(8))
        mBudType = dbNullToString(dr.item(9))
        mVisitFreq = dbNullToString(dr.item(10))
        mAdrId1 = DbNullToInt(dr.Item(11))
        mAdrId2 = DbNullToInt(dr.Item(12))
        mAdrId3 = DbNullToInt(dr.Item(13))
        mTAXId = DbNullToString(dr.Item(14))
        mVATRegNo = DbNullToString(dr.Item(15))
        mIsVatEnabled = DbNullToString(dr.Item(16))
        mIsVatIncluded = DbNullToString(dr.Item(17))
        mIdNo = DbNullToString(dr.Item(18))
        mAccountCode = DbNullToString(dr.Item(19))
        mStatusCode = DbNullToString(dr.Item(20))
        mTypeCode = DbNullToString(dr.Item(21))
        mTrmCode = DbNullToString(dr.Item(22))
        mCreatedBy = DbNullToInt(dr.Item(23))
        mCreationDate = DbNullToDate(dr.Item(24))
        mAmendBy = DbNullToInt(dr.Item(25))
        mAmendDate = DbNullToDate(dr.Item(26))
        mCurAlphaCode = DbNullToString(dr.Item(27))
        mCreditProfileCode = DbNullToString(dr.Item(28))

    End Sub
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class

