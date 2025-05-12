Public Class cPrMsEmployeePhoto
    Inherits cPrMsEmployeePhotoDBTier
    '
    Private mCode As String
    Private mMyPhoto As Image
    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property MyPhoto() As Image
        Get
            Return mMyPhoto
        End Get
        Set(ByVal value As Image)
            mMyPhoto = value
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
            ds = MyBase.GetByPK(tCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mCode = DbNullToString(dr.Item(0))
        If IsDBNull(dr.Item(1)) Then
            mMyPhoto = My.Resources.photo
        Else
            Dim data As Byte() = DirectCast(dr.Item(1), Byte())
            Dim ms As New System.IO.MemoryStream(data)
            mMyPhoto = Image.FromStream(ms)
        End If


    End Sub

    '
    Public Shadows Function Save(Optional ByVal SavePhoto As Boolean = True) As Boolean
        Try
            Return MyBase.Save(Me, SavePhoto)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
