Public Class cVatRates
    Inherits cVatRatesDBTier

    Private mId As Integer
    Private mCode As String
    Private mRate As String
    Private mEffectiveDate As Date
    Private mCreatedBy As Integer
    Private mCreationDate As Date
    Private mAmendBy As Integer
    Private mAmendDate As Date
    Private mIsActive As String

    Public Property id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property

    Public Property Rate() As Double
        Get
            Return mRate
        End Get
        Set(ByVal value As Double)
            mRate = value
        End Set
    End Property

    Public Property EffectiveDate() As Date
        Get
            Return mEffectiveDate
        End Get
        Set(ByVal Value As Date)
            mEffectiveDate = Value
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
        Set(ByVal value As Date)
            mCreationDate = value
        End Set
    End Property

    Public Property Amendby() As Integer
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
        Set(ByVal value As Date)
            mAmendDate = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal tid As Integer)
        If tId > 0 Then
            Init(tId)
        End If
    End Sub
    Public Sub New(ByVal tCode As String, ByVal tEffectiveDate As Date)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByCodeANDEffectiveDate(tCode, tEffectiveDate)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub Init(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mCode = DbNullToString(dr.Item(1))
        mRate = DbNullToDouble(dr.Item(2))
        mEffectiveDate = DbNullToDate(dr.Item(3))
        mCreatedBy = DbNullToInt(dr.Item(4))
        mCreationDate = DbNullToDate(dr.Item(5))
        mAmendBy = DbNullToInt(dr.Item(6))
        mAmendDate = DbNullToDate(dr.Item(7))
        mIsActive = DbNullToString(dr.Item(8))
    End Sub

    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
