Public Class cPrTxTimesheets
    Inherits cPrTxTimesheetsDBTier
    Private mId As Integer
    Private mEmpCode As String
    Private mTemGroup As String
    Private mPeriodGroup As String
    Private mPeriodCode As String
    Private mTransDate As Date
    Private mIn1 As String
    Private mOut1 As String
    Private mIn2 As String
    Private mOut2 As String
    Private mIn3 As String
    Private mOut3 As String
    Private mTotalWorkPerDay As String
    Private mTotalWorkPerWeek As String
    Private mTotalWorkPerMonth As String
    Private mALHours As Double
    Private mSickHours As Double
    Private mArmyHours As Double
    Private mMaterHours As Double
    Private mNormaldayHours As String
    Private mDayDiff As String
    Private mMonthDiff As String
    Private mTotalMonthNormal As String
    Private mFromFile As Integer
    Private mBusTrip As Double
    Private mFamDeath As Double
    Private mStudyLeave As Double
    Private mWorkFromHome As Double
    Private mTotalAL As String
    Private mTotalSick As String
    Private mTotalArmy As String
    Private mTotalMater As String



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
    Public Property TemGroup() As String
        Get
            Return mTemGroup
        End Get
        Set(ByVal value As String)
            mTemGroup = value
        End Set
    End Property
    Public Property PeriodGroup() As String
        Get
            Return mPeriodGroup
        End Get
        Set(ByVal value As String)
            mPeriodGroup = value
        End Set
    End Property
    Public Property PeriodCode() As String
        Get
            Return mPeriodCode
        End Get
        Set(ByVal value As String)
            mPeriodCode = value
        End Set
    End Property
    Public Property TransDate() As Date
        Get
            Return mTransDate
        End Get
        Set(ByVal value As Date)
            mTransDate = value
        End Set
    End Property
    Public Property In1() As String
        Get
            Return mIn1
        End Get
        Set(ByVal value As String)
            mIn1 = value
        End Set
    End Property
    Public Property Out1() As String
        Get
            Return mOut1
        End Get
        Set(ByVal value As String)
            mOut1 = value
        End Set
    End Property
    Public Property In2() As String
        Get
            Return mIn2
        End Get
        Set(ByVal value As String)
            mIn2 = value
        End Set
    End Property
    Public Property Out2() As String
        Get
            Return mOut2
        End Get
        Set(ByVal value As String)
            mOut2 = value
        End Set
    End Property
    Public Property In3() As String
        Get
            Return mIn3
        End Get
        Set(ByVal value As String)
            mIn3 = value
        End Set
    End Property
    Public Property Out3() As String
        Get
            Return mOut3
        End Get
        Set(ByVal value As String)
            mOut3 = value
        End Set
    End Property
    Public Property TotalWorkPerDay() As String
        Get
            Return mTotalWorkPerDay
        End Get
        Set(ByVal value As String)
            mTotalWorkPerDay = value
        End Set
    End Property
    Public Property TotalWorkPerWeek() As String
        Get
            Return mTotalWorkPerWeek
        End Get
        Set(ByVal value As String)
            mTotalWorkPerWeek = value
        End Set
    End Property
    Public Property TotalWorkPerMonth() As String
        Get
            Return mTotalWorkPerMonth
        End Get
        Set(ByVal value As String)
            mTotalWorkPerMonth = value
        End Set
    End Property
    Public Property ALHours() As Double
        Get
            Return mALHours
        End Get
        Set(ByVal value As Double)
            mALHours = value
        End Set
    End Property
    Public Property SickHours() As Double
        Get
            Return mSickHours
        End Get
        Set(ByVal value As Double)
            mSickHours = value
        End Set
    End Property
    Public Property ArmyHours() As Double
        Get
            Return mArmyHours
        End Get
        Set(ByVal value As Double)
            mArmyHours = value
        End Set
    End Property
    Public Property MaterHours() As Double
        Get
            Return mMaterHours
        End Get
        Set(ByVal value As Double)
            mMaterHours = value
        End Set
    End Property
    
    Public Property NormalDayHours() As String
        Get
            Return mNormaldayHours
        End Get
        Set(ByVal value As String)
            mNormaldayHours = value
        End Set
    End Property
    Public Property DayDiff() As String
        Get
            Return mDayDiff
        End Get
        Set(ByVal value As String)
            mDayDiff = value
        End Set
    End Property
    Public Property MonthDiff() As String
        Get
            Return mMonthDiff
        End Get
        Set(ByVal value As String)
            mMonthDiff = value
        End Set
    End Property
    Public Property totalMonthNormal() As String
        Get
            Return mtotalMonthnormal
        End Get
        Set(ByVal value As String)
            mTotalMonthNormal = value
        End Set
    End Property
    Public Property FromFile() As Integer
        Get
            Return mFromFile
        End Get
        Set(ByVal value As Integer)
            mFromFile = value
        End Set
    End Property

    Public Property BusTrip() As Double
        Get
            Return mBusTrip
        End Get
        Set(ByVal value As Double)
            mBusTrip = value
        End Set
    End Property
    Public Property FamDeath() As Double
        Get
            Return mFamDeath
        End Get
        Set(ByVal value As Double)
            mFamDeath = value
        End Set
    End Property
    Public Property StudyLeave() As Double
        Get
            Return mStudyLeave
        End Get
        Set(ByVal value As Double)
            mStudyLeave = value
        End Set
    End Property
    Public Property WorkFromHome() As Double
        Get
            Return mWorkFromHome
        End Get
        Set(ByVal value As Double)
            mWorkFromHome = value
        End Set
    End Property
    Public Property TotalAL() As String
        Get
            Return mTotalAL
        End Get
        Set(ByVal value As String)
            mTotalAL = value
        End Set
    End Property
    Public Property TotalSick() As String
        Get
            Return mTotalSick
        End Get
        Set(ByVal value As String)
            mTotalSick = value
        End Set
    End Property
    Public Property TotalArmy() As String
        Get
            Return mTotalArmy
        End Get
        Set(ByVal value As String)
            mTotalArmy = value
        End Set
    End Property
    Public Property TotalMater() As String
        Get
            Return mTotalMater
        End Get
        Set(ByVal value As String)
            mTotalMater = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal EmpCode As String, ByVal D As Date, ByVal TemCode As String, ByVal PerGroup As String, ByVal PerCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK2(EmpCode, D, TemCode, PerGroup, PerCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try

    End Sub
    Public Sub New(ByVal tId As Integer)

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
        mTemGroup = DbNullToString(dr.Item(2))
        mPeriodGroup = DbNullToString(dr.Item(3))
        mPeriodCode = DbNullToString(dr.Item(4))
        mTransDate = DbNullToDate(dr.Item(5))
        mIn1 = DbNullToString(dr.Item(6))
        mOut1 = DbNullToString(dr.Item(7))
        mIn2 = DbNullToString(dr.Item(8))
        mOut2 = DbNullToString(dr.Item(9))
        mIn3 = DbNullToString(dr.Item(10))
        mOut3 = DbNullToString(dr.Item(11))
        mTotalWorkPerDay = DbNullToString(dr.Item(12))
        mTotalWorkPerWeek = DbNullToString(dr.Item(13))
        mTotalWorkPerMonth = DbNullToString(dr.Item(14))
        mALHours = DbNullToDouble(dr.Item(15))
        mSickHours = DbNullToDouble(dr.Item(16))
        mArmyHours = DbNullToDouble(dr.Item(17))
        mMaterHours = DbNullToDouble(dr.Item(18))
        mNormaldayHours = DbNullToString(dr.Item(19))
        mDayDiff = DbNullToString(dr.Item(20))
        mMonthDiff = DbNullToString(dr.Item(21))
        mTotalMonthNormal = DbNullToString(dr.Item(22))
        mFromFile = DbNullToString(dr.Item(23))
        mBusTrip = DbNullToDouble(dr.Item(24))
        mFamDeath = DbNullToDouble(dr.Item(25))
        mStudyLeave = DbNullToDouble(dr.Item(26))
        mWorkFromHome = DbNullToDouble(dr.Item(27))

        mTotalAL = DbNullToDouble(dr.Item(28))
        mTotalSick = DbNullToDouble(dr.Item(29))
        mTotalArmy = DbNullToDouble(dr.Item(30))
        mTotalMater = DbNullToDouble(dr.Item(31))

    End Sub
    Public Function Save() As Boolean
        Return MyBase.Save(Me)
    End Function








End Class
