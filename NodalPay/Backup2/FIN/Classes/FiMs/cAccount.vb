Public Class cAccount
    Inherits cAccountDBTier
    Private mCode As String
    Private mConsolCode As String
    Private mDescriptionL As String
    Private mDescriptionS As String
    Private mStatus As String
    Private mAccTyp As String
    Private mLevel As Integer
    Private mAccAn1Code As String
    Private mAccAn2Code As String
    Private mAccAn3Code As String
    Private mAccAn4Code As String
    Private mAccAn5Code As String
    Private mAccAn6Code As String
    Private mAccAn7Code As String
    Private mAccAn8Code As String
    Private mAccAn9Code As String
    Private mAccAn10Code As String
    Private mAutoOnlyFlag As String
    Private mCurCode As String
    Private mAllocatedFlag As String
    Private mIsBank As String
    Private mBankAccount As String
    Private mTAnGrpCode As String
    Private mCreatedBy As Integer
    Private mCreationDate As Date
    Private mAmendedBy As Integer
    Private mAmendDate As Date

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property ConsolCode() As String
        Get
            Return mConsolCode
        End Get
        Set(ByVal Value As String)
            mConsolCode = Value
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
    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal Value As String)
            mStatus = Value
        End Set
    End Property
    Public Property AccTyp() As String
        Get
            Return mAccTyp
        End Get
        Set(ByVal Value As String)
            mAccTyp = Value
        End Set
    End Property
    Public Property Level() As Integer
        Get
            Return mLevel
        End Get
        Set(ByVal Value As Integer)
            mLevel = Value
        End Set
    End Property
    Public Property AccAn1Code() As String
        Get
            Return mAccAn1Code
        End Get
        Set(ByVal Value As String)
            mAccAn1Code = Value
        End Set
    End Property
    Public Property AccAn2Code() As String
        Get
            Return mAccAn2Code
        End Get
        Set(ByVal Value As String)
            mAccAn2Code = Value
        End Set
    End Property
    Public Property AccAn3Code() As String
        Get
            Return mAccAn3Code
        End Get
        Set(ByVal Value As String)
            mAccAn3Code = Value
        End Set
    End Property
    Public Property AccAn4Code() As String
        Get
            Return mAccAn4Code
        End Get
        Set(ByVal Value As String)
            mAccAn4Code = Value
        End Set
    End Property
    Public Property AccAn5Code() As String
        Get
            Return mAccAn5Code
        End Get
        Set(ByVal Value As String)
            mAccAn5Code = Value
        End Set
    End Property
    Public Property AccAn6Code() As String
        Get
            Return mAccAn6Code
        End Get
        Set(ByVal Value As String)
            mAccAn6Code = Value
        End Set
    End Property
    Public Property AccAn7Code() As String
        Get
            Return mAccAn7Code
        End Get
        Set(ByVal Value As String)
            mAccAn7Code = Value
        End Set
    End Property
    Public Property AccAn8Code() As String
        Get
            Return mAccAn8Code
        End Get
        Set(ByVal Value As String)
            mAccAn8Code = Value
        End Set
    End Property
    Public Property AccAn9Code() As String
        Get
            Return mAccAn9Code
        End Get
        Set(ByVal Value As String)
            mAccAn9Code = Value
        End Set
    End Property
    Public Property AccAn10Code() As String
        Get
            Return mAccAn10Code
        End Get
        Set(ByVal Value As String)
            mAccAn10Code = Value
        End Set
    End Property
    Public Property AutoOnlyFlag() As String
        Get
            Return mAutoOnlyFlag
        End Get
        Set(ByVal Value As String)
            mAutoOnlyFlag = Value
        End Set
    End Property
    Public Property CurCode() As String
        Get
            Return mCurCode
        End Get
        Set(ByVal Value As String)
            mCurCode = Value
        End Set
    End Property
    Public Property AllocatedFlag() As String
        Get
            Return mAllocatedFlag
        End Get
        Set(ByVal Value As String)
            mAllocatedFlag = Value
        End Set
    End Property
    Public Property IsBank() As String
        Get
            Return mIsBank
        End Get
        Set(ByVal Value As String)
            mIsBank = Value
        End Set
    End Property
    Public Property BankAccount() As String
        Get
            Return mBankAccount
        End Get
        Set(ByVal Value As String)
            mBankAccount = Value
        End Set
    End Property
    Public Property TAnGrpCode() As String
        Get
            Return mTAnGrpCode
        End Get
        Set(ByVal Value As String)
            mTAnGrpCode = Value
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
    Public Property AmendedBy() As Integer
        Get
            Return mAmendedBy
        End Get
        Set(ByVal Value As Integer)
            mAmendedBy = Value
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
        If tCode > 0 Then
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
        mConsolCode = dbNullToString(dr.item(1))
        mDescriptionL = dbNullToString(dr.item(2))
        mDescriptionS = dbNullToString(dr.item(3))
        mStatus = dbNullToString(dr.item(4))
        mAccTyp = dbNullToString(dr.item(5))
        mLevel = dbNulltoInt(dr.item(6))
        mAccAn1Code = dbNullToString(dr.item(7))
        mAccAn2Code = dbNullToString(dr.item(8))
        mAccAn3Code = dbNullToString(dr.item(9))
        mAccAn4Code = dbNullToString(dr.item(10))
        mAccAn5Code = dbNullToString(dr.item(11))
        mAccAn6Code = dbNullToString(dr.item(12))
        mAccAn7Code = dbNullToString(dr.item(13))
        mAccAn8Code = dbNullToString(dr.item(14))
        mAccAn9Code = dbNullToString(dr.item(15))
        mAccAn10Code = dbNullToString(dr.item(16))
        mAutoOnlyFlag = dbNullToString(dr.item(17))
        mCurCode = dbNullToString(dr.item(18))
        mAllocatedFlag = dbNullToString(dr.item(19))
        mIsBank = dbNullToString(dr.item(20))
        mBankAccount = dbNullToString(dr.item(21))
        mTAnGrpCode = dbNullToString(dr.item(22))
        mCreatedBy = dbNulltoInt(dr.item(23))
        mCreationDate = dbNullToDate(dr.item(24))
        mAmendedBy = dbNulltoInt(dr.item(25))
        mAmendDate = dbNullToDate(dr.item(26))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class

