Public Class cUsers
    Inherits cUsersDBTier
    Private mId As Integer
    Private mUserName As String
    Private mFullName As String
    Private mCreatedOn As Date
    Private mIsEnabled As Char
    Private mIsSA As Char
    Private mMyRole As Integer
    'test
    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return mUserName
        End Get
        Set(ByVal Value As String)
            mUserName = Value
        End Set
    End Property
    Public Property FullName() As String
        Get
            Return mFullName
        End Get
        Set(ByVal Value As String)
            mFullName = Value
        End Set
    End Property
    Public Property IsEnabled() As Boolean
        Get
            If mIsEnabled = CChar("Y") Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                mIsEnabled = CChar("Y")
            Else
                mIsEnabled = CChar("N")
            End If
        End Set
    End Property
    Public Property IsUserSA() As Boolean
        Get
            If mIsSA = CChar("Y") Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                mIsSA = CChar("Y")
            Else
                mIsSA = CChar("N")
            End If
        End Set
    End Property
    Public Property CreatedOn() As Date
        Get
            Return mCreatedOn
        End Get
        Set(ByVal value As Date)
            mCreatedOn = value
        End Set
    End Property
    Public Property MyRole() As Integer
        Get
            Return mMyRole
        End Get
        Set(ByVal value As Integer)
            mMyRole = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        Try
            If tId > 0 Then
                Dim ds As DataSet
                ds = MyBase.GetByUserID(tId)
                If CheckDataSet(ds) Then
                    LoadDataRow(ds.Tables(0).Rows(0))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub New(ByVal tUser As String)
        If Not tUser Is Nothing Then
            If Not Trim(tUser) = "" Then
                Init(tUser)
            End If
        End If
    End Sub
    Private Sub Init(ByVal tUser As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByUser(Trim(tUser))
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mUserName = DbNullToString(dr.Item(1))
        mFullName = DbNullToString(dr.Item(2))
        mCreatedOn = DbNullToDate(dr.Item(3))
        mIsEnabled = DbNullToChar(dr.Item(4))
        mIsSA = DbNullToChar(dr.Item(5))
        mMyRole = DbNullToInt(dr.Item(6))
    End Sub
    Public Overrides Function ToString() As String
        Return Me.UserName
    End Function
End Class
