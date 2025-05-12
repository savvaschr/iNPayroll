Public Class cBusPartnerAnl1
    Inherits cBusPartnerAnl1DBTier
    Private mCode As String
    Private mAltCode As String
    Private mA21Code As Integer
    Private mDesc As String
    Private mCreationDate As Date
    Private mAmendDate As Date
    Private mIsActive As String

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property AltCode() As String
        Get
            Return mAltCode
        End Get
        Set(ByVal Value As String)
            mAltCode = Value
        End Set
    End Property
    Public Property A21Code() As Integer
        Get
            Return mA21Code
        End Get
        Set(ByVal Value As Integer)
            mA21Code = Value
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
    Public Property CreationDate() As Date
        Get
            Return mCreationDate
        End Get
        Set(ByVal Value As Date)
            mCreationDate = Value
        End Set
    End Property
    Public Property AmendDate() As Date
        Get
            Return mAmendDate
        End Get
        Set(ByVal Value As Date)
            mAmendDate = Value
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
        mAltCode = dbNullToString(dr.item(1))
        mA21Code = dbNulltoInt(dr.item(2))
        mDesc = dbNullToString(dr.item(3))
        mCreationDate = dbNullToDate(dr.item(4))
        mAmendDate = dbNullToDate(dr.item(5))
        mIsActive = dbNullToString(dr.item(6))
    End Sub
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.Desc
    End Function
End Class

