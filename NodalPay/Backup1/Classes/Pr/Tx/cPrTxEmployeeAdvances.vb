Public Class cPrTxEmployeeAdvances
    Inherits cPrTxEmployeeAdvancesDBTier
    '
    Private mId As Integer
    Private mEmpCode As String
    Private mAmount As Double
    Private mUser As Integer
    Private mMyDate As Date

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal value As String)
            mEmpCode = value
        End Set
    End Property
    Public Property Amount() As Double
        Get
            Return mAmount
        End Get
        Set(ByVal value As Double)
            mAmount = value
        End Set
    End Property
    Public Property User() As Integer
        Get
            Return mUser
        End Get
        Set(ByVal value As Integer)
            mUser = value
        End Set
    End Property
    Public Property MyDate() As Date
        Get
            Return mMyDate
        End Get
        Set(ByVal value As Date)
            mMyDate = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tId As Integer)
        If tId <> 0 Then
            Init(tId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mEmpCode = DbNullToString(dr.Item(1))
        mAmount = DbNullToDouble(dr.Item(2))
        mUser = DbNullToInt(dr.Item(3))
        mMyDate = DbNullToDate(dr.Item(4))
        
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Dim Counter As Integer
            Dim TableCount As Integer
            Dim RecordCount As Integer
            Dim TransStr As String = ""
            Dim ds As DataSet
            ds = MyBase.CheckDeleteRecords(tId)
            If CheckDataSet(ds) Then
                For Counter = 0 To ds.Tables.Count - 1
                    TableCount = TableCount + 1
                    RecordCount = RecordCount + DbNullToInt(ds.Tables(Counter).Rows(0).Item(0))
                    TransStr = TransStr & vbCrLf & "Table " & TableCount & "  Records " & RecordCount
                Next Counter
                If RecordCount = 0 Then
                    Return MyBase.Delete(tId)
                Else
                    MsgBox("Transactions Exist For This item - Can not Delete" & TransStr, MsgBoxStyle.Critical)
                End If
            Else
                Return MyBase.Delete(tId)
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
End Class
