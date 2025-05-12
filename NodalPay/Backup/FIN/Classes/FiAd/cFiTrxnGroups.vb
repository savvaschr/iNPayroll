Public Class cFiTrxnGroups
    Inherits cFiTrxnGroupsDBTier
    '
    Private mCode As String
    Private mTypCode As String
    Private mDescriptionL As String
    Private mDescriptionS As String
    Private mIsActive As String
    Private mFiType As String
    Private mMultFactor As Integer

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property TypeCode() As String
        Get
            Return mTypCode
        End Get
        Set(ByVal Value As String)
            mTypCode = Value
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
    Public Property FiType() As String
        Get
            Return mfitype
        End Get
        Set(ByVal Value As String)
            mfitype = Value
        End Set
    End Property
    Public Property MultFactor() As Integer
        Get
            Return mMultFactor
        End Get
        Set(ByVal Value As Integer)
            mMultFactor = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String, ByVal tTypeCode As String)
        If tCode <> "" Then
            Init(tCode, tTypeCode)
        End If
    End Sub
    Private Sub Init(ByVal tCode As String, ByVal tTypeCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tCode, tTypeCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToString(dr.Item(0))
        mTypCode = DbNullToString(dr.Item(1))
        mDescriptionL = DbNullToString(dr.Item(2))
        mDescriptionS = DbNullToString(dr.Item(3))
        mIsActive = DbNullToString(dr.Item(4))
        mFiType = DbNullToString(dr.Item(5))
        mMultFactor = DbNullToInt(dr.Item(6))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
