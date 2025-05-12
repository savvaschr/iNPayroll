Public Class cPrSsFlightHours
    Inherits cPrSsFlightHoursDBTier
    Private mCode As String
    Private mDesc As String
    Private mHourRate As Double
    Private mLimit As Double
    Private mLimitCode As String

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
    Public Property HourRate() As Double
        Get
            Return mHourRate
        End Get
        Set(ByVal Value As Double)
            mHourRate = Value
        End Set
    End Property
    Public Property Limit() As Double
        Get
            Return mLimit
        End Get
        Set(ByVal Value As Double)
            mLimit = Value
        End Set
    End Property
    Public Property LimitCode() As String
        Get
            Return mLimitCode
        End Get
        Set(ByVal Value As String)
            mLimitCode = Value
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
        mDesc = DbNullToString(dr.Item(1))
        mHourRate = DbNullToDouble(dr.Item(2))
        mLimit = DbNullToDouble(dr.Item(3))
        mLimitCode = DbNullToString(dr.Item(4))

    End Sub
    Public Shadows Function Delete(ByVal tCode As String) As Boolean
        Try
            Dim Counter As Integer
            Dim TableCount As Integer
            Dim RecordCount As Integer
            Dim TransStr As String = ""
            Dim ds As DataSet
            ds = MyBase.CheckDeleteRecords(tCode)
            If CheckDataSet(ds) Then
                For Counter = 0 To ds.Tables.Count - 1
                    TableCount = TableCount + 1
                    RecordCount = RecordCount + DbNullToInt(ds.Tables(Counter).Rows(0).Item(0))
                    TransStr = TransStr & vbCrLf & "Table " & TableCount & "  Records " & RecordCount
                Next Counter
                If RecordCount = 0 Then
                    Return MyBase.Delete(tCode)
                Else
                    MsgBox("Transactions Exist For This item - Can not Delete" & TransStr, MsgBoxStyle.Critical)
                End If
            Else
                Return MyBase.Delete(tCode)
            End If
        Catch ex As System.Exception
        End Try
    End Function
    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Code & " - " & Me.Desc
    End Function


End Class
