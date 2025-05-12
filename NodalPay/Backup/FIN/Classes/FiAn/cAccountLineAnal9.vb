Public Class cAccountLineAnal9
    Inherits cAccountLineAnal9DBTier

    Private mcode As String
    Private mDescriptionL As String
    Private mDescriptionS As String
    Private mCreationDate As Date
    Private mAmendDate As Date
    Private mIsActive As String

    Public Property Code() As String
        Get
            Return mcode
        End Get
        Set(ByVal Value As String)
            mcode = Value
        End Set
    End Property

    Public Property descriptionL() As String
        Get
            Return mDescriptionL
        End Get
        Set(ByVal Value As String)
            mDescriptionL = Value
        End Set
    End Property

    Public Property DescriptionS() As String
        Get
            Return mDescriptionS
        End Get
        Set(ByVal Value As String)
            mDescriptionS = Value
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
        Set(ByVal value As String)
            mIsActive = value
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
        mcode = DbNullToString(dr.Item(0))
        mDescriptionL = DbNullToString(dr.Item(1))
        mDescriptionS = DbNullToString(dr.Item(2))
        mCreationDate = DbNullToDate(dr.Item(3))
        mAmendDate = DbNullToDate(dr.Item(4))
        mIsActive = DbNullToString(dr.Item(5))
    End Sub

    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.DescriptionS
    End Function
End Class
