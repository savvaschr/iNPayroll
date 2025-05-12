Public Class cAddress
    Inherits cAddressDBTier
    Private mId As Integer
    Private mAltCode As String
    Private mMyType As String
    Private mLine1 As String
    Private mLine2 As String
    Private mLine3 As String
    Private mLine4 As String
    Private mZipCode As String
    Private mTelephone1 As String
    Private mTelephone2 As String
    Private mFax As String
    Private mEmail As String
    Private mRemark1 As String
    Private mRemark2 As String
    Private mPOBox As String
    Private mContactPerson As String
    Private mWebSite As String
    Private mOrderEmail As String
    Private mAreaId As Integer

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property AltCode() As String
        Get
            Return mAltCode
        End Get
        Set(ByVal Value As String)
            mAltCode = Value
        End Set
    End Property
    Public Property MyType() As String
        Get
            Return mMyType
        End Get
        Set(ByVal Value As String)
            mMyType = Value
        End Set
    End Property
    Public Property Line1() As String
        Get
            Return mLine1
        End Get
        Set(ByVal Value As String)
            mLine1 = Value
        End Set
    End Property
    Public Property Line2() As String
        Get
            Return mLine2
        End Get
        Set(ByVal Value As String)
            mLine2 = Value
        End Set
    End Property
    Public Property Line3() As String
        Get
            Return mLine3
        End Get
        Set(ByVal Value As String)
            mLine3 = Value
        End Set
    End Property
    Public Property Line4() As String
        Get
            Return mLine4
        End Get
        Set(ByVal Value As String)
            mLine4 = Value
        End Set
    End Property
    Public Property ZipCode() As String
        Get
            Return mZipCode
        End Get
        Set(ByVal Value As String)
            mZipCode = Value
        End Set
    End Property
    Public Property Telephone1() As String
        Get
            Return mTelephone1
        End Get
        Set(ByVal Value As String)
            mTelephone1 = Value
        End Set
    End Property
    Public Property Telephone2() As String
        Get
            Return mTelephone2
        End Get
        Set(ByVal Value As String)
            mTelephone2 = Value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return mFax
        End Get
        Set(ByVal Value As String)
            mFax = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal Value As String)
            mEmail = Value
        End Set
    End Property
    Public Property Remark1() As String
        Get
            Return mRemark1
        End Get
        Set(ByVal Value As String)
            mRemark1 = Value
        End Set
    End Property
    Public Property Remark2() As String
        Get
            Return mRemark2
        End Get
        Set(ByVal Value As String)
            mRemark2 = Value
        End Set
    End Property
    Public Property POBox() As String
        Get
            Return mPOBox
        End Get
        Set(ByVal Value As String)
            mPOBox = Value
        End Set
    End Property
    Public Property Contactperson() As String
        Get
            Return mContactPerson
        End Get
        Set(ByVal Value As String)
            mContactPerson = Value
        End Set
    End Property
    Public Property WebSite() As String
        Get
            Return mWebSite
        End Get
        Set(ByVal Value As String)
            mWebSite = Value
        End Set
    End Property
    Public Property OrderEmail() As String
        Get
            Return mOrderEmail
        End Get
        Set(ByVal Value As String)
            mOrderEmail = Value
        End Set
    End Property

    Public Property AreaId() As Integer
        Get
            Return mAreaId
        End Get
        Set(ByVal Value As Integer)
            mAreaId = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId > 0 Then
            Init(tId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataset(ds) Then
                LoadDataRow(ds.tables(0).rows(0))
            End If
        Catch ex As system.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mAltCode = DbNullToString(dr.Item(1))
        mMyType = DbNullToString(dr.Item(2))
        mLine1 = DbNullToString(dr.Item(3))
        mLine2 = DbNullToString(dr.Item(4))
        mLine3 = DbNullToString(dr.Item(5))
        mLine4 = DbNullToString(dr.Item(6))
        mZipCode = DbNullToString(dr.Item(7))
        mTelephone1 = DbNullToString(dr.Item(8))
        mTelephone2 = DbNullToString(dr.Item(9))
        mFax = DbNullToString(dr.Item(10))
        mEmail = DbNullToString(dr.Item(11))
        mRemark1 = DbNullToString(dr.Item(12))
        mRemark2 = DbNullToString(dr.Item(13))
        mPOBox = DbNullToString(dr.Item(14))
        mContactPerson = DbNullToString(dr.Item(15))
        mWebSite = DbNullToString(dr.Item(16))
        mOrderEmail = DbNullToString(dr.Item(17))
        mAreaId = DbNullToInt(dr.Item(18))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try

    End Function
End Class

