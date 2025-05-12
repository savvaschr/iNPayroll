Public Class cMobules
    Inherits cMobulesDBTier
    Private mCode As String
    Private mDesc As String
    Private mIsEnabled As String

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
    Public Property IsEnabled() As String
        Get
            Return mIsEnabled
        End Get
        Set(ByVal Value As String)
            mIsEnabled = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String)
        If tCode > 0 Then
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
        mDesc = dbNullToString(dr.item(1))
        mIsEnabled = dbNullToString(dr.item(2))
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class

