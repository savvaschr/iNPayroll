Public Class cJournalType
    Inherits cJournalTypeDBTier
    Private mCode As String
    Private mDesc As String
    Private mStatus As String

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property

    Public Property Desc() As String
        Get
            Return mDesc
        End Get
        Set(ByVal Value As String)
            mDesc = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal Value As String)
            mStatus = Value
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
        mDesc = DbNullToString(dr.Item(1))
        mStatus = DbNullToString(dr.Item(2))
    End Sub

    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Overrides Function ToString() As String
        Return Me.Code
    End Function
End Class
