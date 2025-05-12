
Public Class cItemAnal1
    Inherits cItemAnal1DBTier
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
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToString(dr.Item(0))
        mAltCode = DbNullToString(dr.Item(1))
        mA21Code = DbNullToInt(dr.Item(2))
        mDesc = DbNullToString(dr.Item(3))
        mCreationDate = DbNullToDate(dr.Item(4))
        mAmendDate = DbNullToDate(dr.Item(5))
        mIsActive = DbNullToString(dr.Item(6))
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

