Public Class cVat
    Inherits cVatDBtier

    Private mCode As String
    Private mDescription As String
    Private mIsActive As String

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal Value As String)
            mDescription = Value
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

    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub

    Public Sub New(ByVal tCode As String)
        If tCode <> "" Then
            Init(tCode)
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
        mDescription = DbNullToString(dr.Item(1))
        mIsActive = DbNullToString(dr.Item(2))
    End Sub

    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.Description
    End Function

End Class
