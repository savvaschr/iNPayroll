Public Class cPrTxEmployeeLoan
    Inherits cPrTxEmployeeLoanDBTier


    Private mEmpLne_Id As Integer
    Private mEmpLne_Code As String
    Private mEmp_Code As String
    Private mTemGrp_Code As String
    Private mPrdCod_Code As String
    Private mPrdGrp_Code As String
    Private mDedCod_Code As String
    Private mTrxHdr_Id As Integer
    Private mEmpLne_LoanDate As Date
    Private mEmpLne_Amount As Double
    Private mEmpLne_Interest As Double
    Private mEmpLne_TotalAmount As Double
    Private mEmpLne_Description As String
    Private mEmpLne_MonthlyAmount As Double
    Private mEmpLne_Type As String
    Private mEmpLne_Payment As Double
    Private mUsr_Id As Integer
    Private mStatus As String


    Public Property Id() As Integer
        Get
            Return mEmpLne_Id
        End Get
        Set(ByVal value As Integer)
            mEmpLne_Id = value
        End Set
    End Property
    Public Property LoanCode() As String
        Get
            Return mEmpLne_Code
        End Get
        Set(ByVal value As String)
            mEmpLne_Code = value
        End Set
    End Property
    Public Property EmpCode() As String
        Get
            Return mEmp_Code
        End Get
        Set(ByVal value As String)
            mEmp_Code = value
        End Set
    End Property
    Public Property TempGroupCode() As String
        Get
            Return mTemGrp_Code
        End Get
        Set(ByVal value As String)
            mTemGrp_Code = value
        End Set
    End Property
    Public Property PeriodCode() As String
        Get
            Return mPrdCod_Code
        End Get
        Set(ByVal value As String)
            mPrdCod_Code = value
        End Set
    End Property
    Public Property PeriodGroup() As String
        Get
            Return mPrdGrp_Code
        End Get
        Set(ByVal value As String)
            mPrdGrp_Code = value
        End Set
    End Property
    Public Property DedCode() As String
        Get
            Return mDedCod_Code
        End Get
        Set(ByVal value As String)
            mDedCod_Code = value
        End Set
    End Property
    Public Property TrxHdr_Id() As Integer
        Get
            Return mTrxHdr_Id
          
        End Get
        Set(ByVal value As Integer)
            mTrxHdr_Id = value
        End Set
    End Property
    Public Property LoanDate() As Date
        Get
            Return mEmpLne_LoanDate
           
        End Get
        Set(ByVal value As Date)
            mEmpLne_LoanDate = value
        End Set
    End Property
    Public Property Amount() As Double
        Get
            Return mEmpLne_Amount
           
        End Get
        Set(ByVal value As Double)
            mEmpLne_Amount = value
        End Set
    End Property
    Public Property Interest() As Double
        Get
            Return mEmpLne_Interest
          
        End Get
        Set(ByVal value As Double)
            mEmpLne_Interest = value
        End Set
    End Property
    Public Property TotalAmount() As Double
        Get
            Return mEmpLne_TotalAmount
           
        End Get
        Set(ByVal value As Double)
            mEmpLne_TotalAmount = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return mEmpLne_Description
         
        End Get
        Set(ByVal value As String)
            mEmpLne_Description = value
        End Set
    End Property
    Public Property MonthlyAmount() As Double
        Get
            Return mEmpLne_MonthlyAmount
          
        End Get
        Set(ByVal value As Double)
            mEmpLne_MonthlyAmount = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return mEmpLne_Type
           
        End Get
        Set(ByVal value As String)
            mEmpLne_Type = value
        End Set
    End Property
    Public Property Payment() As Double
        Get
            Return mEmpLne_Payment

        End Get
        Set(ByVal value As Double)
            mEmpLne_Payment = value
        End Set
    End Property
    Public Property UserId() As Integer
        Get
            Return mUsr_Id
        End Get
        Set(ByVal value As Integer)
            mUsr_Id = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal value As String)
            mStatus = value
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
        mEmpLne_Id = DbNullToInt(dr.Item(0))
        mEmpLne_Code = DbNullToString(dr.Item(1))
        mEmp_Code = DbNullToString(dr.Item(2))
        mTemGrp_Code = DbNullToString(dr.Item(3))
        mPrdCod_Code = DbNullToString(dr.Item(4))
        mPrdGrp_Code = DbNullToString(dr.Item(5))
        mDedCod_Code = DbNullToString(dr.Item(6))
        mTrxHdr_Id = DbNullToInt(dr.Item(7))
        mEmpLne_LoanDate = DbNullToDate(dr.Item(8))
        mEmpLne_Amount = DbNullToDouble(dr.Item(9))
        mEmpLne_Interest = DbNullToDouble(dr.Item(10))
        mEmpLne_TotalAmount = DbNullToDouble(dr.Item(11))
        mEmpLne_Description = DbNullToString(dr.Item(12))
        mEmpLne_MonthlyAmount = DbNullToDouble(dr.Item(13))
        mEmpLne_Type = DbNullToString(dr.Item(14))
        mEmpLne_Payment = DbNullToDouble(dr.Item(15))
        mUsr_Id = DbNullToInt(dr.Item(16))
        mStatus = DbNullToString(dr.Item(17))
    End Sub
    Public Shadows Function Delete(ByVal tId As Integer) As Boolean
        Try
            Return MyBase.Delete(Me.Id)
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
