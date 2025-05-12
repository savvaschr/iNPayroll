Public Class cPrSsEmployeeSplit
    
    Inherits cPrSsEmployeeSplitDBTier
    '
    Private mid As Integer
    Private mEmpCode As String
    Private mDescription As String
    Private mValue As Double
    Private mEnabled As String
    Private mNoOfPeriods As String
    Private mIsPF As String
    Private mIsST As String
    Private mCreationDate As Date
    Private mCreatedBy As Integer
    Private mAmendDate As Date
    Private mAmendedBy As Integer
    Private mActivePeriods As Integer

    Public Property id() As Integer
        Get
            Return mid
        End Get
        Set(ByVal value As Integer)
            mid = value
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
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property
    Public Property myValue() As Double
        Get
            Return mValue
        End Get
        Set(ByVal value As Double)
            mValue = value
        End Set
    End Property
    Public Property Enabled() As String
        Get
            Return mEnabled
        End Get
        Set(ByVal value As String)
            mEnabled = value
        End Set
    End Property
    Public Property NoOfPeriods() As String
        Get
            Return mNoOfPeriods
        End Get
        Set(ByVal value As String)
            mNoOfPeriods = value
        End Set
    End Property
    Public Property IsPF() As String
        Get
            Return mIsPF
        End Get
        Set(ByVal value As String)
            mIsPF = value
        End Set
    End Property
    Public Property IsST() As String
        Get
            Return mIsST
        End Get
        Set(ByVal value As String)
            mIsST = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            Return mCreationDate
        End Get
        Set(ByVal value As Date)
            mCreationDate = value
        End Set
    End Property
    Public Property CreatedBy() As Integer
        Get
            Return mCreatedBy
        End Get
        Set(ByVal value As Integer)
            mCreatedBy = value
        End Set
    End Property
    Public Property AmendDate() As Date
        Get
            Return mAmendDate
        End Get
        Set(ByVal value As Date)
            mAmendDate = value
        End Set
    End Property
    Public Property AmendedBy() As Integer
        Get
            Return mAmendedBy
        End Get
        Set(ByVal value As Integer)
            mAmendedBy = value
        End Set
    End Property
    Public Property ActivePeriods() As Integer
        Get
            Return mActivePeriods
        End Get
        Set(ByVal value As Integer)
            mActivePeriods = value
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
        mid = DbNullToInt(dr.Item(0))
        mEmpCode = DbNullToString(dr.Item(1))
        mDescription = DbNullToString(dr.Item(2))
        mValue = DbNullToDouble(dr.Item(3))
        mEnabled = DbNullToString(dr.Item(4))
        mNoOfPeriods = DbNullToString(dr.Item(5))
        mIsPF = DbNullToString(dr.Item(6))
        mIsST = DbNullToString(dr.Item(7))
        mCreationDate = DbNullToDate(dr.Item(8))
        mCreatedBy = DbNullToInt(dr.Item(9))
        mAmendDate = DbNullToDate(dr.Item(10))
        mAmendedBy = DbNullToInt(dr.Item(11))
        mActivePeriods = DbNullToInt(dr.Item(12))
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


