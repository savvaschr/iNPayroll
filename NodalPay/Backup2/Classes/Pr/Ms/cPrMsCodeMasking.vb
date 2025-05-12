Public Class cPrMsCodeMasking
    Inherits cPrMsCodeMaskingDBTier
    Private mid As Integer
    Private mIntCode As String
    Private mPosition As Integer
    Private mType As String
    Private mValue As String
    Public Property id() As Integer
        Get
            Return mid
        End Get
        Set(ByVal value As Integer)
            mid = value

        End Set
    End Property
    Public Property IntCode() As String
        Get
            Return mIntCode
        End Get
        Set(ByVal value As String)
            mIntCode = value
        End Set
    End Property
    Public Property Position() As Integer
        Get
            Return mPosition
        End Get
        Set(ByVal value As Integer)
            mPosition = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return mType
        End Get
        Set(ByVal value As String)
            mType = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal value As String)
            mValue = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Dim Ds As DataSet
            Ds = MyBase.getById(tId)
            If CheckDataSet(Ds) Then
                LoadDataRow(Ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If

    End Sub
    Private Sub LoadDataRow(ByVal Dr As DataRow)
        mid = DbNullToInt(Dr.Item(0))
        mIntCode = DbNullToString(Dr.Item(1))
        mPosition = DbNullToInt(Dr.Item(2))
        mType = DbNullToString(Dr.Item(3))
        mValue = DbNullToString(Dr.Item(4))
    End Sub
    Public Shadows Function Save() As Boolean

        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
