Public Class cPrTxIr59
    Inherits cPrTxIr59DBTier
    Private mPay_Id As Integer
    Private mTrxhdr_id As Integer
    Private mTemGrp_Code As String
    Private mPrdGrp_Code As String
    Private mPrdCod_Code As String
    Private mEmp_Code As String
    Private mRec_GrossIncome As Double
    Private mAct_GrossIncome As Double
    Private mRec_Discounts As Double
    Private mAct_Discounts As Double
    Private mRec_FirstEmployeement As Double
    Private mAct_FirstEmployeement As Double
    Private mRec_SalDecrease As Double
    Private mAct_Saldecrease As Double
    Private mRec_PenFund As Double
    Private mAct_PenFund As Double
    Private mRec_WOFund As Double
    Private mAct_WOFund As Double
    Private mRec_Union As Double
    Private mAct_Union As Double
    Private mRec_LifeIns As Double
    Private mAct_LifeIns As Double
    Private mRec_PF As Double
    Private mAct_PF As Double
    Private mRec_PFLimit As Double
    Private mAct_PFLimit As Double
    Private mRec_SI As Double
    Private mAct_SI As Double
    Private mRec_MF As Double
    Private mAct_MF As Double
    Private mRec_MFLimit As Double
    Private mAct_MFLimit As Double
    Private mRec_Total As Double
    Private mAct_Total As Double
    Private mRec_OneSixth As Double
    Private mAct_OneSixth As Double
    Private mRec_Taxable As Double
    Private mAct_Taxable As Double
    Private mRec_TotalTax As Double
    Private mAct_TotalTax As Double
    Private mRec_PaidTax As Double
    Private mAct_PaidTax As Double
    Private mRec_RemTax As Double
    Private mAct_RemTax As Double
    Private mRec_RemDivTaxableP As Double
    Private mAct_RemDivTaxableP As Double
    Private mPay_RemTaxablePeriods As Integer
    Private mPay_ActualDivNormal As Double
    Private mPay_Dif As Double
    Private mPay_PeriodTax As Double
    Private mRec_Gesi As Double
    Private mAct_Gesi As Double
    Private mRec_Gesi_BIK As Double
    Private mAct_Gesi_BIK As Double

    Private mRec_Gesi_Limit As Double
    Private mAct_Gesi_Limit As Double


    Public Property Pay_Id() As Integer
        Get
            Return mPay_Id
        End Get
        Set(ByVal value As Integer)
            mPay_Id = value
        End Set
    End Property
    Public Property Trxhdr_id() As Integer
        Get
            Return mTrxhdr_id
        End Get
        Set(ByVal value As Integer)
            mTrxhdr_id = value
        End Set
    End Property
    Public Property TemGrp_Code() As String
        Get
            Return mTemGrp_Code
        End Get
        Set(ByVal value As String)
            mTemGrp_Code = value
        End Set
    End Property
    Public Property PrdGrp_Code() As String
        Get
            Return mPrdGrp_Code
        End Get
        Set(ByVal value As String)
            mPrdGrp_Code = value
        End Set
    End Property
    Public Property PrdCod_Code() As String
        Get
            Return mPrdCod_Code
        End Get
        Set(ByVal value As String)
            mPrdCod_Code = value
        End Set
    End Property
    Public Property Emp_Code() As String
        Get
            Return mEmp_Code
        End Get
        Set(ByVal value As String)
            mEmp_Code = value
        End Set
    End Property
    Public Property Rec_GrossIncome() As Double
        Get
            Return mRec_GrossIncome
        End Get
        Set(ByVal value As Double)
            mRec_GrossIncome = value
        End Set
    End Property
    Public Property Act_GrossIncome() As Double
        Get
            Return mAct_GrossIncome
        End Get
        Set(ByVal value As Double)
            mAct_GrossIncome = value
        End Set
    End Property
    Public Property Rec_Discounts() As Double
        Get
            Return mRec_Discounts
        End Get
        Set(ByVal value As Double)
            mRec_Discounts = value
        End Set
    End Property
    Public Property Act_Discounts() As Double
        Get
            Return mAct_Discounts
        End Get
        Set(ByVal value As Double)
            mAct_Discounts = value
        End Set
    End Property
    Public Property Rec_FirstEmployeement() As Double
        Get
            Return mRec_FirstEmployeement
        End Get
        Set(ByVal value As Double)
            mRec_FirstEmployeement = value
        End Set
    End Property
    Public Property Act_FirstEmployeement() As Double
        Get
            Return mAct_FirstEmployeement
        End Get
        Set(ByVal value As Double)
            mAct_FirstEmployeement = value
        End Set
    End Property
    Public Property Rec_SalDecrease() As Double
        Get
            Return mRec_SalDecrease
        End Get
        Set(ByVal value As Double)
            mRec_SalDecrease = value
        End Set
    End Property
    Public Property Act_Saldecrease() As Double
        Get
            Return mAct_Saldecrease
        End Get
        Set(ByVal value As Double)
            mAct_Saldecrease = value
        End Set
    End Property
    Public Property Rec_PenFund() As Double
        Get
            Return mRec_PenFund
        End Get
        Set(ByVal value As Double)
            mRec_PenFund = value
        End Set
    End Property
    Public Property Act_PenFund() As Double
        Get
            Return mAct_PenFund
        End Get
        Set(ByVal value As Double)
            mAct_PenFund = value
        End Set
    End Property
    Public Property Rec_WOFund() As Double
        Get
            Return mRec_WOFund
        End Get
        Set(ByVal value As Double)
            mRec_WOFund = value
        End Set
    End Property
    Public Property Act_WOFund() As Double
        Get
            Return mAct_WOFund
        End Get
        Set(ByVal value As Double)
            mAct_WOFund = value
        End Set
    End Property
    Public Property Rec_Union() As Double
        Get
            Return mRec_Union
        End Get
        Set(ByVal value As Double)
            mRec_Union = value
        End Set
    End Property
    Public Property Act_Union() As Double
        Get
            Return mAct_Union
        End Get
        Set(ByVal value As Double)
            mAct_Union = value
        End Set
    End Property
    Public Property Rec_LifeIns() As Double
        Get
            Return mRec_LifeIns
        End Get
        Set(ByVal value As Double)
            mRec_LifeIns = value
        End Set
    End Property
    Public Property Act_LifeIns() As Double
        Get
            Return mAct_LifeIns
        End Get
        Set(ByVal value As Double)
            mAct_LifeIns = value
        End Set
    End Property
    Public Property Rec_PF() As Double
        Get
            Return mRec_PF
        End Get
        Set(ByVal value As Double)
            mRec_PF = value
        End Set
    End Property
    Public Property Act_PF() As Double
        Get
            Return mAct_PF
        End Get
        Set(ByVal value As Double)
            mAct_PF = value
        End Set
    End Property
    Public Property Rec_PFLimit() As Double
        Get
            Return mRec_PFLimit
        End Get
        Set(ByVal value As Double)
            mRec_PFLimit = value
        End Set
    End Property
    Public Property Act_PFLimit() As Double
        Get
            Return mAct_PFLimit
        End Get
        Set(ByVal value As Double)
            mAct_PFLimit = value
        End Set
    End Property
    Public Property Rec_SI() As Double
        Get
            Return mRec_SI
        End Get
        Set(ByVal value As Double)
            mRec_SI = value
        End Set
    End Property
    Public Property Act_SI() As Double
        Get
            Return mAct_SI
        End Get
        Set(ByVal value As Double)
            mAct_SI = value
        End Set
    End Property
    Public Property Rec_MF() As Double
        Get
            Return mRec_MF
        End Get
        Set(ByVal value As Double)
            mRec_MF = value
        End Set
    End Property
    Public Property Act_MF() As Double
        Get
            Return mAct_MF
        End Get
        Set(ByVal value As Double)
            mAct_MF = value
        End Set
    End Property
    Public Property Rec_MFLimit() As Double
        Get
            Return mRec_MFLimit
        End Get
        Set(ByVal value As Double)
            mRec_MFLimit = value
        End Set
    End Property
    Public Property Act_MFLimit() As Double
        Get
            Return mAct_MFLimit
        End Get
        Set(ByVal value As Double)
            mAct_MFLimit = value
        End Set
    End Property
    Public Property Rec_Total() As Double
        Get
            Return mRec_Total
        End Get
        Set(ByVal value As Double)
            mRec_Total = value
        End Set
    End Property
    Public Property Act_Total() As Double
        Get
            Return mAct_Total
        End Get
        Set(ByVal value As Double)
            mAct_Total = value
        End Set
    End Property
    Public Property Rec_OneSixth() As Double
        Get
            Return mRec_OneSixth
        End Get
        Set(ByVal value As Double)
            mRec_OneSixth = value
        End Set
    End Property

    Public Property Act_OneSixth() As Double
        Get
            Return mAct_OneSixth
        End Get
        Set(ByVal value As Double)
            mAct_OneSixth = value
        End Set
    End Property
    Public Property Rec_Taxable() As Double
        Get
            Return mRec_Taxable
        End Get
        Set(ByVal value As Double)
            mRec_Taxable = value
        End Set
    End Property
    Public Property Act_Taxable() As Double
        Get
            Return mAct_Taxable
        End Get
        Set(ByVal value As Double)
            mAct_Taxable = value
        End Set
    End Property
    Public Property Rec_TotalTax() As Double
        Get
            Return mRec_TotalTax
        End Get
        Set(ByVal value As Double)
            mRec_TotalTax = value
        End Set
    End Property
    Public Property Act_TotalTax() As Double
        Get
            Return mAct_TotalTax
        End Get
        Set(ByVal value As Double)
            mAct_TotalTax = value
        End Set
    End Property
    Public Property Rec_PaidTax() As Double
        Get
            Return mRec_PaidTax
        End Get
        Set(ByVal value As Double)
            mRec_PaidTax = value
        End Set
    End Property
    Public Property Act_PaidTax() As Double
        Get
            Return mAct_PaidTax
        End Get
        Set(ByVal value As Double)
            mAct_PaidTax = value
        End Set
    End Property
    Public Property Rec_RemTax() As Double
        Get
            Return mRec_RemTax
        End Get
        Set(ByVal value As Double)
            mRec_RemTax = value
        End Set
    End Property
    Public Property Act_RemTax() As Double
        Get
            Return mAct_RemTax
        End Get
        Set(ByVal value As Double)
            mAct_RemTax = value
        End Set
    End Property
    Public Property Rec_RemDivTaxableP() As Double
        Get
            Return mRec_RemDivTaxableP
        End Get
        Set(ByVal value As Double)
            mRec_RemDivTaxableP = value
        End Set
    End Property
    Public Property Act_RemDivTaxableP() As Double
        Get
            Return mAct_RemDivTaxableP
        End Get
        Set(ByVal value As Double)
            mAct_RemDivTaxableP = value
        End Set
    End Property
    Public Property Pay_RemTaxablePeriods() As Integer
        Get
            Return mPay_RemTaxablePeriods
        End Get
        Set(ByVal value As Integer)
            mPay_RemTaxablePeriods = value
        End Set
    End Property
    Public Property Pay_ActualDivNormal() As Double
        Get
            Return mPay_ActualDivNormal
        End Get
        Set(ByVal value As Double)
            mPay_ActualDivNormal = value
        End Set
    End Property
    Public Property Pay_Dif() As Double
        Get
            Return mPay_Dif
        End Get
        Set(ByVal value As Double)
            mPay_Dif = value
        End Set
    End Property
    Public Property Pay_PeriodTax() As Double
        Get
            Return mPay_PeriodTax
        End Get
        Set(ByVal value As Double)
            mPay_PeriodTax = value
        End Set
    End Property
    Public Property Rec_Gesi() As Double
        Get
            Return mRec_Gesi
        End Get
        Set(ByVal value As Double)
            mRec_Gesi = value
        End Set
    End Property
    Public Property Act_Gesi() As Double
        Get
            Return mAct_Gesi
        End Get
        Set(ByVal value As Double)
            mAct_Gesi = value
        End Set
    End Property
    Public Property Rec_Gesi_BIK() As Double
        Get
            Return mRec_Gesi_BIK
        End Get
        Set(ByVal value As Double)
            mRec_Gesi_BIK = value
        End Set
    End Property
    Public Property Act_Gesi_BIK() As Double
        Get
            Return mAct_Gesi_BIK
        End Get
        Set(ByVal value As Double)
            mAct_Gesi_BIK = value
        End Set
    End Property

    Public Property Rec_Gesi_Limit() As Double
        Get
            Return mRec_Gesi_Limit
        End Get
        Set(ByVal value As Double)
            mRec_Gesi_Limit = value
        End Set
    End Property
    Public Property Act_Gesi_Limit() As Double
        Get
            Return mAct_Gesi_Limit
        End Get
        Set(ByVal value As Double)
            mAct_Gesi_Limit = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal tTrxHdr_Id As Integer)

        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tTrxHdr_Id)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try

    End Sub

    Private Sub LoadDataRow(ByVal dr As DataRow)
        mPay_Id = DbNullToInt(dr.Item(0))
        mTrxhdr_id = DbNullToInt(dr.Item(1))
        mTemGrp_Code = DbNullToString(dr.Item(2))
        mPrdGrp_Code = DbNullToString(dr.Item(3))
        mPrdCod_Code = DbNullToString(dr.Item(4))
        mEmp_Code = DbNullToString(dr.Item(5))
        mRec_GrossIncome = DbNullToDouble(dr.Item(6))
        mAct_GrossIncome = DbNullToDouble(dr.Item(7))
        mRec_Discounts = DbNullToDouble(dr.Item(8))
        mAct_Discounts = DbNullToDouble(dr.Item(9))
        mRec_FirstEmployeement = DbNullToDouble(dr.Item(10))
        mAct_FirstEmployeement = DbNullToDouble(dr.Item(11))
        mRec_SalDecrease = DbNullToDouble(dr.Item(12))
        mAct_Saldecrease = DbNullToDouble(dr.Item(13))
        mRec_PenFund = DbNullToDouble(dr.Item(14))
        mAct_PenFund = DbNullToDouble(dr.Item(15))
        mRec_WOFund = DbNullToDouble(dr.Item(16))
        mAct_WOFund = DbNullToDouble(dr.Item(17))
        mRec_Union = DbNullToDouble(dr.Item(18))
        mAct_Union = DbNullToDouble(dr.Item(19))
        mRec_LifeIns = DbNullToDouble(dr.Item(20))
        mAct_LifeIns = DbNullToDouble(dr.Item(21))
        mRec_PF = DbNullToDouble(dr.Item(22))
        mAct_PF = DbNullToDouble(dr.Item(23))
        mRec_PFLimit = DbNullToDouble(dr.Item(24))
        mAct_PFLimit = DbNullToDouble(dr.Item(25))
        mRec_SI = DbNullToDouble(dr.Item(26))
        mAct_SI = DbNullToDouble(dr.Item(27))
        mRec_MF = DbNullToDouble(dr.Item(28))
        mAct_MF = DbNullToDouble(dr.Item(29))
        mRec_MFLimit = DbNullToDouble(dr.Item(30))
        mAct_MFLimit = DbNullToDouble(dr.Item(31))
        mRec_Total = DbNullToDouble(dr.Item(32))
        mAct_Total = DbNullToDouble(dr.Item(33))
        mRec_OneSixth = DbNullToDouble(dr.Item(34))
        mAct_OneSixth = DbNullToDouble(dr.Item(35))
        mRec_Taxable = DbNullToDouble(dr.Item(36))
        mAct_Taxable = DbNullToDouble(dr.Item(37))
        mRec_TotalTax = DbNullToDouble(dr.Item(38))
        mAct_TotalTax = DbNullToDouble(dr.Item(39))
        mRec_PaidTax = DbNullToDouble(dr.Item(40))
        mAct_PaidTax = DbNullToDouble(dr.Item(41))
        mRec_RemTax = DbNullToDouble(dr.Item(42))
        mAct_RemTax = DbNullToDouble(dr.Item(43))
        mRec_RemDivTaxableP = DbNullToDouble(dr.Item(44))
        mAct_RemDivTaxableP = DbNullToDouble(dr.Item(45))
        mPay_RemTaxablePeriods = DbNullToInt(dr.Item(46))
        mPay_ActualDivNormal = DbNullToDouble(dr.Item(47))
        mPay_Dif = DbNullToDouble(dr.Item(48))
        mPay_PeriodTax = DbNullToDouble(dr.Item(49))

        mRec_Gesi = DbNullToDouble(dr.Item(50))
        mAct_Gesi = DbNullToDouble(dr.Item(51))

        mRec_Gesi_BIK = DbNullToDouble(dr.Item(52))
        mAct_Gesi_BIK = DbNullToDouble(dr.Item(53))

        mRec_Gesi_Limit = DbNullToDouble(dr.Item(54))
        mAct_Gesi_Limit = DbNullToDouble(dr.Item(55))
    End Sub

    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class
