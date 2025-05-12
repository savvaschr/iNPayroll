Public Class cFiscalPeriods
    Inherits cFiscalPeriodsDBTier
    Private mCode As Integer
    Private mYear As Integer
    Private mNumber As Integer
    Private mFrom As Date
    Private mTo As Date
    Private mNoOfDays As Integer
    Private mDescriptionL As String
    Private mDescriptionS As String
    Private mType As String
    Private mStatusFin As String
    Private mStatusMain As String

    Public Property Code() As Integer
        Get
            Return mCode
        End Get
        Set(ByVal Value As Integer)
            mCode = Value
        End Set
    End Property
    Public Property Year() As Integer
        Get
            Return mYear
        End Get
        Set(ByVal Value As Integer)
            mYear = Value
        End Set
    End Property
    Public Property Number() As Integer
        Get
            Return mNumber
        End Get
        Set(ByVal Value As Integer)
            mNumber = Value
        End Set
    End Property
    Public Property FromDate() As Date
        Get
            Return mFrom
        End Get
        Set(ByVal Value As Date)
            mFrom = Value
        End Set
    End Property
    Public Property ToDate() As Date
        Get
            Return mTo
        End Get
        Set(ByVal Value As Date)
            mTo = Value
        End Set
    End Property
    Public Property NoOfDays() As Integer
        Get
            Return mNoOfDays
        End Get
        Set(ByVal Value As Integer)
            mNoOfDays = Value
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
    Public Property MyType() As String
        Get
            Return mType
        End Get
        Set(ByVal Value As String)
            mType = Value
        End Set
    End Property
    Public Property StatusFin() As String
        Get
            Return mStatusFin
        End Get
        Set(ByVal Value As String)
            mStatusFin = Value
        End Set
    End Property
    Public Property StatusMain() As String
        Get
            Return mStatusMain
        End Get
        Set(ByVal Value As String)
            mStatusMain = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If

    End Sub
    Public Sub New(ByVal tCode As Integer)
        If tCode > 0 Then
            Init(tCode)
        End If

    End Sub
    Private Sub Init(ByVal tCode As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByCode(tCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToInt(dr.Item(0))
        mYear = DbNullToInt(dr.Item(1))
        mNumber = DbNullToInt(dr.Item(2))
        mFrom = DbNullToDate(dr.Item(3))
        mTo = DbNullToDate(dr.Item(4))
        mNoOfDays = DbNullToInt(dr.Item(5))
        mDescriptionL = DbNullToString(dr.Item(6))
        mDescriptionS = DbNullToString(dr.Item(7))
        mType = DbNullToString(dr.Item(8))
        mStatusFin = DbNullToString(dr.Item(9))
        mStatusMain = DbNullToString(dr.Item(10))
    End Sub
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code
    End Function
End Class