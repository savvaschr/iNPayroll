Public Class cTaTxWeekDescription
    Inherits cTaTxWeekDescriptionDBTier
    Private mId As Integer
    Private mFromDate As Date
    Private mToDate As Date
    Private mAnalCode As String
    Private mDescription As String
    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property Fromdate() As Date
        Get
            Return mFromDate
        End Get
        Set(ByVal value As Date)
            mFromDate = value
        End Set
    End Property
    Public Property Todate() As Date
        Get
            Return mToDate
        End Get
        Set(ByVal value As Date)
            mToDate = value
        End Set
    End Property
    Public Property AnalCode() As String
        Get
            Return mAnalCode
        End Get
        Set(ByVal value As String)
            mAnalCode = value
        End Set
    End Property
    Public Property Desription() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property
  
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId > 0 Then
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDatarow(ds.Tables(0).Rows(0))
            End If
        End If
    End Sub
    Public Sub New(ByVal tFrom As Date, ByVal tTo As Date, ByVal tAnalCode As String)

        Dim ds As DataSet
        ds = MyBase.GetByPK(tFrom, tTo, tAnalCode)
        If CheckDataSet(ds) Then
            LoadDatarow(ds.Tables(0).Rows(0))
        End If

    End Sub
    Public Sub New(ByVal Dt As DataRow)
        LoadDatarow(Dt)
    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shadows Function Delete() As Boolean
        Try
            Return MyBase.Delete(Me)
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub LoadDatarow(ByVal dt As DataRow)
        mId = DbNullToInt(dt.Item(0))
        mFromDate = DbNullToDate(dt.Item(1))
        mToDate = DbNullToDate(dt.Item(2))
        mAnalCode = DbNullToString(dt.Item(3))
        mDescription = DbNullToString(dt.Item(4))
    End Sub

End Class
