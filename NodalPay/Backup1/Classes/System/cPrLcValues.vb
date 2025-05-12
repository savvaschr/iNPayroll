Public Class cPrLcValues
    Inherits cPrLcValuesDBTier
    Private mDesc As String
    Private mLc As String
    Public Property Description() As String
        Get
            Return mDesc
        End Get
        Set(ByVal value As String)
            mDesc = value
        End Set
    End Property
    Public Property LC() As String
        Get
            Return mLc
        End Get
        Set(ByVal value As String)
            mLc = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tLc As String, ByVal tDesc As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tLc, tDesc)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mDesc = DbNullToString(dr.Item(0))
        mLc = DbNullToString(dr.Item(1))
        
    End Sub
    Public Shadows Function Save(ByVal Update As Boolean) As Boolean
        Try
            Return MyBase.Save(Me, Update)
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
