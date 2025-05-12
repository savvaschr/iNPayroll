Public Class cCreditProfiles
    Inherits cCreditProfilesDBTier
    '
    Private mCode As String
    Private mInvoiceType As String
    Private mDescription As String
    Private mCreditTerms As String
    Private mCreditDays As Integer
    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property InvoiceType() As String
        Get
            Return mInvoiceType
        End Get
        Set(ByVal Value As String)
            mInvoiceType = Value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal Value As String)
            mDescription = Value
        End Set
    End Property
    Public Property CreditTerms() As String
        Get
            Return mCreditTerms
        End Get
        Set(ByVal Value As String)
            mCreditTerms = Value
        End Set
    End Property
    Public Property CreditDays() As Integer
        Get
            Return mCreditDays
        End Get
        Set(ByVal Value As Integer)
            mCreditDays = Value
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
        mCode = DbNullToString(dr.item(0))
        mInvoiceType = DbNullToString(dr.item(1))
        mDescription = DbNullToString(dr.item(2))
        mCreditTerms = DbNullToString(dr.item(3))
        mCreditDays = DbNullToInt(dr.item(4))
    End Sub
    Public Shadows Function Delete(ByVal Code As String) As Boolean
        If CanDelete <> True Then
            MsgBox("Transactions Exist For This item - Can not Delete")
            Exit Function
        End If
        Try
            Return MyBase.Delete(Code)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Private Function CanDelete() As Boolean
        Dim RecordCounter As Integer
        Dim Counter As Integer
        Dim Ds As DataSet
        Ds = MyBase.CheckDeleteRecords
        For Counter = 0 To ds.Tables.Count
            RecordCounter = RecordCounter + CInt(Ds.Tables(Counter).Rows(0).Item(0))
        Next Counter
        If RecordCounter = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
