Public Class cJournalCode
    Inherits cJournalCodeDBTier

    Private mCode As String
    Private mDesc As String
    Private mTypCode As String
    Private mJouNoStart As Integer
    Private mJouNoCurrent As Integer
    Private mLength As Integer
    Private mStatus As String

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

    Public Property TypeCode() As String
        Get
            Return mTypCode
        End Get
        Set(ByVal value As String)
            mTypCode = value
        End Set
    End Property

    Public Property JouNoStart() As Integer
        Get
            Return mJouNoStart
        End Get
        Set(ByVal value As Integer)
            mJouNoStart = value
        End Set
    End Property

    Public Property JouNoCurrent() As Integer
        Get
            Return mJouNoCurrent
        End Get
        Set(ByVal value As Integer)
            mJouNoCurrent = value
        End Set
    End Property

    Public Property length() As Integer
        Get
            Return mLength
        End Get
        Set(ByVal value As Integer)
            mLength = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal value As String)
            mStatus = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal tCode As String)
        If tCode <> "" Then
            Init(tCode)
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Private Sub Init(ByVal tCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try
    End Sub


    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToString(dr.Item(0))
        mDesc = DbNullToString(dr.Item(1))
        mTypCode = DbNullToString(dr.Item(2))
        mJouNoStart = DbNullToInt(dr.Item(3))
        mJouNoCurrent = DbNullToInt(dr.Item(4))
        mLength = DbNullToString(dr.Item(5))
        mStatus = DbNullToString(dr.Item(6))
    End Sub

    Public Shadows Function Save(ByVal UpDate As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, UpDate)
        Catch ex As System.Exception
            Return False
        End Try

    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.Desc
    End Function

End Class
