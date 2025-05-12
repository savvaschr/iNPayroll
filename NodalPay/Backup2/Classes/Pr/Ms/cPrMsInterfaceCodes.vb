Public Class cPrMsInterfaceCodes
    Inherits cPrMsInterfaceCodesDBTier
    Private mCode As String
    Private mTemGrpCode As String
    Private mDescription As String
    Private mAccountType As String

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal value As String)
            mCode = value
        End Set
    End Property
    Public Property TemGrpCode() As String
        Get
            Return mTemGrpCode
        End Get
        Set(ByVal value As String)
            mTemGrpCode = value
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
    Public Property AccountType() As String
        Get
            Return mAccountType
        End Get
        Set(ByVal value As String)
            mAccountType = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal tCode As String)
        Dim ds As DataSet
        ds = MyBase.GetByCode(tCode)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal tGroupCode As String, ByVal tCode As String)
        Dim ds As DataSet
        ds = MyBase.GetByPK(tGroupCode, tCode)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)

        mCode = DbNullToString(dr.Item(0))
        mTemGrpCode = DbNullToString(dr.Item(1))
        mDescription = DbNullToString(dr.Item(2))
        mAccountType = DbNullToString(dr.Item(3))



    End Sub

    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.Description
    End Function

End Class
