Public Class cPrSsUserPermitions
    Inherits cPrSsUserPermitionsDBTier
    Dim mid As Integer
    Dim mComCode As String
    Dim mUserCode As String
    Dim mEntity As String
    Dim mFull As Integer
    Dim mReadonly As Integer
    Dim mNo As Integer

    Public Property id() As Integer
        Get
            Return mid
        End Get
        Set(ByVal value As Integer)
            mid = value
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
    Public Property UserCode() As String
        Get
            Return mUserCode
        End Get
        Set(ByVal value As String)
            mUserCode = value
        End Set
    End Property
    Public Property Entity() As String
        Get
            Return mEntity
        End Get
        Set(ByVal value As String)
            mEntity = value
        End Set
    End Property
    Public Property FullPermission() As Integer
        Get
            Return mFull
        End Get
        Set(ByVal value As Integer)
            mFull = value
        End Set
    End Property
    Public Property ReadonlyPermission() As Integer
        Get
            Return mReadonly
        End Get
        Set(ByVal value As Integer)
            mReadonly = value
        End Set
    End Property


    Public Property NoPermission() As Integer
        Get
            Return mNo
        End Get
        Set(ByVal value As Integer)
            mNo = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Shadows Function Save() As Boolean
        Return MyBase.Save(Me)
    End Function


    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDatarow(ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal tCompanyCode As String, ByVal tUserCode As String, ByVal tEntity As String)
        If tUserCode <> "" And tEntity <> "" Then
            Dim ds As DataSet
            ds = MyBase.GetByKey(tCompanyCode, tUserCode, tEntity)
            If CheckDataSet(ds) Then
                LoadDatarow(ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal tDr As DataRow)
        If Not tDr Is Nothing Then
            LoadDatarow(tDr)
        End If
    End Sub
    Private Sub LoadDatarow(ByVal dr As DataRow)
        mid = DbNullToInt(dr.Item(0))
        mComCode = DbNullToString(dr.Item(1))
        mUserCode = DbNullToString(dr.Item(2))
        mEntity = DbNullToString(dr.Item(3))
        mFull = DbNullToInt(dr.Item(4))
        mReadonly = DbNullToInt(dr.Item(5))
        mNo = DbNullToInt(dr.Item(6))
    End Sub

End Class
