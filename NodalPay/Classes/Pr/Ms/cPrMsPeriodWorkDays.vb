Public Class cPrMsPeriodWorkDays
    
    Inherits cPrMsPeriodWorkDaysDBTier
    '
    Private mId As Integer
    Private mGrpCode As String
    Private mPrdCode As String
    Private mNormalDays As Double
    
    Public Property ID() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property GrpCode() As String
        Get
            Return mGrpCode
        End Get
        Set(ByVal Value As String)
            mGrpCode = Value
        End Set
    End Property
    Public Property PrdCode() As String
        Get
            Return mPrdCode
        End Get
        Set(ByVal Value As String)
            mPrdCode = Value
        End Set
    End Property
  
    Public Property NormalDays() As Double
        Get
            Return mNormalDays
        End Get
        Set(ByVal Value As Double)
            mNormalDays = Value
        End Set
    End Property
    
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)

        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try

    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tPeriodCode As String, ByVal tGroup As String)
        If tPeriodCode <> "" And tGroup <> "" Then
            Init(tPeriodCode, tGroup)
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
        mId = DbNullToInt(dr.Item(0))
        mGrpCode = DbNullToString(dr.Item(1))
        mPrdCode = DbNullToString(dr.Item(2))
        mNormalDays = DbNullToDouble(dr.Item(3))
        
    End Sub
  
    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function


End Class
