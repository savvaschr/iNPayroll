Public Class cIR7
    Inherits cIr7DBTier
    Private mId As Integer
    Private mType As String
    Private mYear As String
    Private mComCode As String
    Private mEmpCode As String
    Private mTICNumber As String
    Private mArithmosTaftopoiisis As String
    Private mOtherCountryTIC As String
    Private mSINumber As String
    Private mSurname As String
    Private mName As String
    Private mStreet As String
    Private mVillage As String
    Private mPostCode As String
    Private mEmailAddress As String
    Private mEmployeeType As String
    Private mGross As Double
    Private mGrossOut As Double
    Private mBIKWithSI As Double
    Private mBIKWithoutSI As Double
    Private mTotal1234 As Double
    Private mSIFund As Double
    Private mPensionFund As Double
    Private mMedicalFund As Double
    Private mUnions As Double
    Private mLifeInsurance As Double
    Private mNonTaxable As Double
    Private mOtherDiscs As Double
    Private mTotalDiscs As Double
    Private mTaxableIncome As Double
    Private mIncomeTAX As Double
    Private mSyntaksiodotikaOfelimata As Double
    Private mMeiosiApolavon As Double
    Private mGESYtoSI As Double
    Private mGESYtoBIKDed As Double
    Private mGESYtoBIKCon As Double
    Private mStartDate As String
    Private mTermDate As String
    Private mPensionNo As String
    Private mEmpType As String

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property myType() As String
        Get
            Return mType
        End Get
        Set(ByVal value As String)
            mType = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return mYear
        End Get
        Set(ByVal value As String)
            mYear = value
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
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal value As String)
            mEmpCode = value
        End Set
    End Property
    Public Property TICNumber() As String
        Get
            Return mTICNumber
        End Get
        Set(ByVal value As String)
            mTICNumber = value
        End Set
    End Property
    Public Property ArithmosTaftopoiisis() As String
        Get
            Return mArithmosTaftopoiisis
        End Get
        Set(ByVal value As String)
            mArithmosTaftopoiisis = value
        End Set
    End Property
    Public Property OtherCountryTIC() As String
        Get
            Return mOtherCountryTIC
        End Get
        Set(ByVal value As String)
            mOtherCountryTIC = value
        End Set
    End Property
    Public Property SINumber() As String
        Get
            Return mSINumber
        End Get
        Set(ByVal value As String)
            mSINumber = value
        End Set
    End Property
    Public Property Surname() As String
        Get
            Return mSurname
        End Get
        Set(ByVal value As String)
            mSurname = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property
    Public Property Street() As String
        Get
            Return mStreet
        End Get
        Set(ByVal value As String)
            mStreet = value

        End Set
    End Property
    Public Property Village() As String
        Get
            Return mVillage
        End Get
        Set(ByVal value As String)
            mVillage = value
        End Set
    End Property
    Public Property PostCode() As String
        Get
            Return mPostCode
        End Get
        Set(ByVal value As String)
            mPostCode = value
        End Set
    End Property
    Public Property EmailAddress() As String
        Get
            Return mEmailAddress
        End Get
        Set(ByVal value As String)
            mEmailAddress = value
        End Set
    End Property
    Public Property EmployeeType() As String
        Get
            Return mEmployeeType
        End Get
        Set(ByVal value As String)
            mEmployeeType = value
        End Set
    End Property
    Public Property Gross() As Double
        Get
            Return mGross
        End Get
        Set(ByVal value As Double)
            mGross = value
        End Set
    End Property
    Public Property GrossOut() As Double
        Get
            Return mGrossOut
        End Get
        Set(ByVal value As Double)
            mGrossOut = value
        End Set
    End Property
    Public Property BIKWithSI() As Double
        Get
            Return mBIKWithSI
        End Get
        Set(ByVal value As Double)
            mBIKWithSI = value
        End Set
    End Property
    Public Property BIKWithoutSI() As Double
        Get
            Return mBIKWithoutSI
        End Get
        Set(ByVal value As Double)
            mBIKWithoutSI = value
        End Set
    End Property
    Public Property Total1234() As Double
        Get
            Return mTotal1234
        End Get
        Set(ByVal value As Double)
            mTotal1234 = value
        End Set
    End Property
    Public Property SIFund() As Double
        Get
            Return mSIFund
        End Get
        Set(ByVal value As Double)
            mSIFund = value
        End Set
    End Property
    Public Property PensionFund() As Double
        Get
            Return mPensionFund
        End Get
        Set(ByVal value As Double)
            mPensionFund = value
        End Set
    End Property
    Public Property MedicalFund() As Double
        Get
            Return mMedicalFund
        End Get
        Set(ByVal value As Double)
            mMedicalFund = value
        End Set
    End Property
    Public Property Unions() As Double
        Get
            Return mUnions
        End Get
        Set(ByVal value As Double)
            mUnions = value
        End Set
    End Property
    Public Property LifeInsurance() As Double
        Get
            Return mLifeInsurance
        End Get
        Set(ByVal value As Double)
            mLifeInsurance = value
        End Set
    End Property
    Public Property NonTaxable() As Double
        Get
            Return mNonTaxable
        End Get
        Set(ByVal value As Double)
            mNonTaxable = value
        End Set
    End Property
    Public Property OtherDiscs() As Double
        Get
            Return mOtherDiscs
        End Get
        Set(ByVal value As Double)
            mOtherDiscs = value
        End Set
    End Property
    Public Property TotalDiscs() As Double
        Get
            Return mTotalDiscs
        End Get
        Set(ByVal value As Double)
            mTotalDiscs = value
        End Set
    End Property
    Public Property TaxableIncome() As Double
        Get
            Return mTaxableIncome
        End Get
        Set(ByVal value As Double)
            mTaxableIncome = value
        End Set
    End Property
    Public Property IncomeTAX() As Double
        Get
            Return mIncomeTAX
        End Get
        Set(ByVal value As Double)
            mIncomeTAX = value
        End Set
    End Property
    Public Property SyntaksiodotikaOfelimata() As Double
        Get
            Return mSyntaksiodotikaOfelimata
        End Get
        Set(ByVal value As Double)
            mSyntaksiodotikaOfelimata = value
        End Set
    End Property
    Public Property MeiosiApolavon() As Double
        Get
            Return mMeiosiApolavon
        End Get
        Set(ByVal value As Double)
            mMeiosiApolavon = value
        End Set
    End Property
    Public Property GESYtoSI() As Double
        Get
            Return mGESYtoSI
        End Get
        Set(ByVal value As Double)
            mGESYtoSI = value
        End Set
    End Property
    Public Property GESYtoBIKDed() As Double
        Get
            Return mGESYtoBIKDed
        End Get
        Set(ByVal value As Double)
            mGESYtoBIKDed = value
        End Set
    End Property
    Public Property GESYtoBIKCon() As Double
        Get
            Return mGESYtoBIKCon
        End Get
        Set(ByVal value As Double)
            mGESYtoBIKCon = value
        End Set
    End Property
    Public Property StartDate() As String
        Get
            Return mStartDate
        End Get
        Set(ByVal value As String)
            mStartDate = value
        End Set
    End Property
    Public Property TermDate() As String
        Get
            Return mTermDate
        End Get
        Set(ByVal value As String)
            mTermDate = value
        End Set
    End Property
    Public Property PensionNo() As String
        Get
            Return mPensionNo
        End Get
        Set(ByVal value As String)
            mPensionNo = value
        End Set
    End Property
    Public Property EmpType() As String
        Get
            Return mEmpType
        End Get
        Set(ByVal value As String)
            mEmpType = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tYear As String, ByVal tComp As String, ByVal tEmpCode As String)
        If tEmpCode <> "" Then
            Try
                Dim ds As DataSet
                ds = MyBase.GetByPK(tYear, tComp, tEmpCode)
                If CheckDataSet(ds) Then
                    LoadDataRow(ds.Tables(0).Rows(0))
                End If
            Catch ex As System.Exception
            End Try
        End If
    End Sub

    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mType = DbNullToString(dr.Item(1))
        mYear = DbNullToString(dr.Item(2))
        mComCode = DbNullToString(dr.Item(3))
        mEmpCode = DbNullToString(dr.Item(4))
        mTICNumber = DbNullToString(dr.Item(5))
        mArithmosTaftopoiisis = DbNullToString(dr.Item(6))
        mOtherCountryTIC = DbNullToString(dr.Item(7))
        mSINumber = DbNullToString(dr.Item(8))
        mSurname = DbNullToString(dr.Item(9))
        mName = DbNullToString(dr.Item(10))
        mStreet = DbNullToString(dr.Item(11))
        mVillage = DbNullToString(dr.Item(12))
        mPostCode = DbNullToString(dr.Item(13))
        mEmailAddress = DbNullToString(dr.Item(14))
        mEmployeeType = DbNullToString(dr.Item(15))
        mGross = DbNullToDouble(dr.Item(16))
        mGrossOut = DbNullToDouble(dr.Item(17))
        mBIKWithSI = DbNullToDouble(dr.Item(18))
        mBIKWithoutSI = DbNullToDouble(dr.Item(19))
        mTotal1234 = DbNullToDouble(dr.Item(20))
        mSIFund = DbNullToDouble(dr.Item(21))
        mPensionFund = DbNullToDouble(dr.Item(22))
        mMedicalFund = DbNullToDouble(dr.Item(23))
        mUnions = DbNullToDouble(dr.Item(24))
        mLifeInsurance = DbNullToDouble(dr.Item(24))
        mNonTaxable = DbNullToDouble(dr.Item(25))
        mOtherDiscs = DbNullToDouble(dr.Item(26))
        mTotalDiscs = DbNullToDouble(dr.Item(27))
        mTaxableIncome = DbNullToDouble(dr.Item(28))
        mIncomeTAX = DbNullToDouble(dr.Item(29))
        mSyntaksiodotikaOfelimata = DbNullToDouble(dr.Item(30))
        mMeiosiApolavon = DbNullToDouble(dr.Item(31))
        mGESYtoSI = DbNullToDouble(dr.Item(32))
        mGESYtoBIKDed = DbNullToDouble(dr.Item(33))
        mGESYtoBIKCon = DbNullToDouble(dr.Item(34))
        mStartDate = DbNullToString(dr.Item(35))
        mTermDate = DbNullToString(dr.Item(36))
        mPensionNo = DbNullToString(dr.Item(37))
        mEmpType = DbNullToString(dr.Item(38))
    End Sub

    '
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
