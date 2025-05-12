Public Class cLocation
    Inherits cLocationDBTier
    Private mCode As String
    Private mDescL As String
    Private mDescS As String
    Private mLocTypeCode As String

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property DescL() As String
        Get
            Return mDescL
        End Get
        Set(ByVal Value As String)
            mDescL = Value
        End Set
    End Property
    Public Property DescS() As String
        Get
            Return mDescS
        End Get
        Set(ByVal Value As String)
            mDescS = Value
        End Set
    End Property
    Public Property LocTypeCode() As String
        Get
            Return mLocTypeCode
        End Get
        Set(ByVal Value As String)
            mLocTypeCode = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String)
        If tCode <> "" Then
            Init(tCode)
        End If

    End Sub
    Private Sub Init(ByVal tCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByCode(tCode)
            If CheckDataset(ds) Then
                LoadDataRow(ds.tables(0).rows(0))
            End If
        Catch ex As system.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = dbNullToString(dr.item(0))
        mDescL = dbNullToString(dr.item(1))
        mDescS = dbNullToString(dr.item(2))
        mLocTypeCode = dbNullToString(dr.item(3))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.DescL
    End Function
End Class

