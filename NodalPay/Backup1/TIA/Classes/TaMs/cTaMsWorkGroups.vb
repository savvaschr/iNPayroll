Public Class cTaMsWorkGroups
    Inherits cTaMsWorkGroupsDBTier
    Private mId As Integer
    Private mCode As String
    Private mDesc As String
    Private mIsActive As String
    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal value As String)
            mCode = value
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return mDesc
        End Get
        Set(ByVal value As String)
            mDesc = value
        End Set
    End Property
    Public Property IsActive() As String
        Get
            Return mIsActive
        End Get
        Set(ByVal value As String)
            mIsActive = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId > 0 Then
            Dim ds As DataSet
            ds = MyBase.getbyid(tId)
            If CheckDataSet(ds) Then
                LoadDatarow(ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal tCode As String, ByVal tGroupCode As String)
        Dim ds As DataSet
        ds = MyBase.GetByCode(tCode)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal Dt As DataRow)
        LoadDataRow(Dt)
    End Sub
    Private Sub LoadDataRow(ByVal dt As DataRow)
        mId = DbNullToInt(dt.Item(0))
        mCode = DbNullToString(dt.Item(1))
        mDesc = DbNullToString(dt.Item(2))
        mIsActive = DbNullToString(dt.Item(3))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As Exception
            Return False

        End Try
    End Function



End Class
