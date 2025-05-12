Public Class cItem
    Inherits cItemDBTier
    Private mCode As String
    Private mDescL As String
    Private mDescS As String
    Private mAnl1Code As String
    Private mAnl2Code As String
    Private mAnl3Code As String
    Private mAnl4Code As String
    Private mAnl5Code As String
    Private mSuplierCode As String
    Private mStatusCode As String
    Private mBarcode As String
    Private mParentCode As String
    Private mParentFactor As Double
    Private mAltUnit1 As Double
    Private mAltUnit2 As Double
    Private mAltUnit3 As Double
    Private mAltUnit4 As Double
    Private mGWeight As Double
    Private mNWeight As Double
    Private mVolume As Double
    Private mBudType As String
    Private mPrice1 As Double
    Private mPrice2 As Double
    Private mPrice3 As Double
    Private mPrice4 As Double
    Private mTariffCode As String
    Private mCountryOfOriginCode As String
    Private mAltCode As String
    Private mCreatedBy As Integer
    Private mCreationDate As Date
    Private mAmendBy As Integer
    Private mAmendDate As Date


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
    Public Property Anl1Code() As String
        Get
            Return mAnl1Code
        End Get
        Set(ByVal Value As String)
            mAnl1Code = Value
        End Set
    End Property
    Public Property Anl2Code() As String
        Get
            Return mAnl2Code
        End Get
        Set(ByVal Value As String)
            mAnl2Code = Value
        End Set
    End Property
    Public Property Anl3Code() As String
        Get
            Return mAnl3Code
        End Get
        Set(ByVal Value As String)
            mAnl3Code = Value
        End Set
    End Property
    Public Property Anl4Code() As String
        Get
            Return mAnl4Code
        End Get
        Set(ByVal Value As String)
            mAnl4Code = Value
        End Set
    End Property
    Public Property Anl5Code() As String
        Get
            Return mAnl5Code
        End Get
        Set(ByVal Value As String)
            mAnl5Code = Value
        End Set
    End Property
    Public Property SuplierCode() As String
        Get
            Return mSuplierCode
        End Get
        Set(ByVal Value As String)
            mSuplierCode = Value
        End Set
    End Property
    Public Property StatusCode() As String
        Get
            Return mStatusCode
        End Get
        Set(ByVal Value As String)
            mStatusCode = Value
        End Set
    End Property
    Public Property Barcode() As String
        Get
            Return mBarcode
        End Get
        Set(ByVal Value As String)
            mBarcode = Value
        End Set
    End Property
    Public Property ParentCode() As String
        Get
            Return mParentCode
        End Get
        Set(ByVal Value As String)
            mParentCode = Value
        End Set
    End Property
    Public Property ParentFactor() As Double
        Get
            Return mParentFactor
        End Get
        Set(ByVal Value As Double)
            mParentFactor = Value
        End Set
    End Property
    Public Property AltUnit1() As Double
        Get
            Return mAltUnit1
        End Get
        Set(ByVal Value As Double)
            mAltUnit1 = Value
        End Set
    End Property
    Public Property AltUnit2() As Double
        Get
            Return mAltUnit2
        End Get
        Set(ByVal Value As Double)
            mAltUnit2 = Value
        End Set
    End Property
    Public Property AltUnit3() As Double
        Get
            Return mAltUnit3
        End Get
        Set(ByVal Value As Double)
            mAltUnit3 = Value
        End Set
    End Property
    Public Property AltUnit4() As Double
        Get
            Return mAltUnit4
        End Get
        Set(ByVal Value As Double)
            mAltUnit4 = Value
        End Set
    End Property
    Public Property GWeight() As Double
        Get
            Return mGWeight
        End Get
        Set(ByVal Value As Double)
            mGWeight = Value
        End Set
    End Property
    Public Property NWeight() As Double
        Get
            Return mNWeight
        End Get
        Set(ByVal Value As Double)
            mNWeight = Value
        End Set
    End Property
    Public Property Volume() As Double
        Get
            Return mVolume
        End Get
        Set(ByVal Value As Double)
            mVolume = Value
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
    Public Property Price1() As Double
        Get
            Return mPrice1
        End Get
        Set(ByVal Value As Double)
            mPrice1 = Value
        End Set
    End Property
    Public Property Price2() As Double
        Get
            Return mPrice2
        End Get
        Set(ByVal Value As Double)
            mPrice2 = Value
        End Set
    End Property
    Public Property Price3() As Double
        Get
            Return mPrice3
        End Get
        Set(ByVal Value As Double)
            mPrice3 = Value
        End Set
    End Property
    Public Property Price4() As Double
        Get
            Return mPrice4
        End Get
        Set(ByVal Value As Double)
            mPrice4 = Value
        End Set
    End Property
    Public Property TariffCode() As String
        Get
            Return mTariffCode
        End Get
        Set(ByVal Value As String)
            mTariffCode = Value
        End Set
    End Property
    Public Property CountryOfOriginCode() As String
        Get
            Return mCountryOfOriginCode
        End Get
        Set(ByVal Value As String)
            mCountryOfOriginCode = Value
        End Set
    End Property
    Public Property AltCode() As String
        Get
            Return mAltCode
        End Get
        Set(ByVal value As String)
            mAltCode = value
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
        Set(ByVal Value As Integer)
            mAmendBy = Value
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
        mAnl1Code = dbNullToString(dr.item(3))
        mAnl2Code = dbNullToString(dr.item(4))
        mAnl3Code = dbNullToString(dr.item(5))
        mAnl4Code = dbNullToString(dr.item(6))
        mAnl5Code = dbNullToString(dr.item(7))
        mSuplierCode = dbNullToString(dr.item(8))
        mStatusCode = dbNullToString(dr.item(9))
        mBarcode = dbNullToString(dr.item(10))
        mParentCode = dbNullToString(dr.item(11))
        mParentFactor = dbNulltoDouble(dr.item(12))
        mAltUnit1 = dbNulltoDouble(dr.item(13))
        mAltUnit2 = dbNulltoDouble(dr.item(14))
        mAltUnit3 = dbNulltoDouble(dr.item(15))
        mAltUnit4 = dbNulltoDouble(dr.item(16))
        mGWeight = dbNulltoDouble(dr.item(17))
        mNWeight = dbNulltoDouble(dr.item(18))
        mVolume = dbNulltoDouble(dr.item(19))
        mBudType = dbNullToString(dr.item(20))
        mPrice1 = dbNulltoDouble(dr.item(21))
        mPrice2 = DbNullToDouble(dr.Item(22))
        mPrice3 = DbNullToDouble(dr.Item(23))
        mPrice4 = DbNullToDouble(dr.Item(24))
        mTariffCode = DbNullToString(dr.Item(25))
        mCountryOfOriginCode = DbNullToString(dr.Item(26))
        mAltCode = DbNullToString(dr.Item(27))
        mCreatedBy = DbNullToInt(dr.Item(28))
        mCreationDate = DbNullToDate(dr.Item(29))
        mAmendBy = DbNullToInt(dr.Item(30))
        mAmendDate = DbNullToDate(dr.Item(31))
    End Sub
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class

