Public Class cPrMsInterfaceTemplate
    Inherits cPrMsInterfaceTemplateDBTier
    Private mIntTemCode As String
    Private mTemGrpCode As String
    Private mIntTemDescription As String
    

    
    Public Property IntTemCode() As String
        Get
            Return mIntTemCode
        End Get
        Set(ByVal value As String)
            mIntTemCode = value
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
    Public Property IntTemDescription() As String
        Get
            Return mIntTemDescription
        End Get
        Set(ByVal value As String)
            mIntTemDescription = value
        End Set
    End Property
    
    Public Sub New()

    End Sub
    Public Sub New(ByVal tIntTem_Code As String)
        Dim ds As DataSet
        ds = MyBase.GetByCode(tIntTem_Code)
        If CheckDataSet(ds) Then
            LoadDataRow(ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal tTemGrp_Code As String, ByVal tIntTem_Code As String)
        Dim ds As DataSet
        ds = MyBase.GetByPK(tTemGrp_Code, tIntTem_Code)
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

        mIntTemCode = DbNullToString(dr.Item(0))
        mTemGrpCode = DbNullToString(dr.Item(1))
        mIntTemDescription = DbNullToString(dr.Item(2))
        

    End Sub

    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.IntTemCode & " - " & Me.IntTemDescription
    End Function

End Class
