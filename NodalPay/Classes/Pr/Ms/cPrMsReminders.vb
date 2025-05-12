Public Class cPrMsReminders
    Inherits cPrMsRemindersDBTier
    '
    Private mId As Integer
    Private mEmpCode As String
    Private mDescription As String
    Private mReminderDate As Date
    Private mIsActive As String
    Private mCreatedBy As String
    Private mCreatedAt As Date
    Private mDeactivatedBy As String
    Private mDeactivatedAt As Date

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
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property
    Public Property ReminderDate() As Date
        Get
            Return mReminderDate
        End Get
        Set(ByVal value As Date)
            mReminderDate = value
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
    Public Property CreatedBy() As String
        Get
            Return mCreatedBy
        End Get
        Set(ByVal value As String)
            mCreatedBy = value
        End Set
    End Property
    Public Property CreatedAt() As Date
        Get
            Return mCreatedAt
        End Get
        Set(ByVal value As Date)
            mCreatedAt = value
        End Set
    End Property
    Public Property DeactivatedBy() As String
        Get
            Return mDeactivatedBy
        End Get
        Set(ByVal value As String)
            mDeactivatedBy = value
        End Set
    End Property

    Public Property DeactivatedAt() As Date
        Get
            Return mDeactivatedAt
        End Get
        Set(ByVal value As Date)
            mDeactivatedAt = value
        End Set
    End Property





    Public Sub New()
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Init(tId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer)
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
        mDescription = DbNullToString(dr.Item(2))
        mReminderDate = DbNullToDate(dr.Item(3))
        mIsActive = DbNullToString(dr.Item(4))
        mCreatedBy = DbNullToString(dr.Item(5))
        mCreatedAt = DbNullToDate(dr.Item(6))
        mDeactivatedBy = DbNullToString(dr.Item(7))
        mDeactivatedAt = DbNullToDate(dr.Item(8))
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Return MyBase.Delete(tId)
        Catch ex As System.Exception
        End Try
    End Function
    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class


