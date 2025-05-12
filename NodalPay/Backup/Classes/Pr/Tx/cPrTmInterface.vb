Public Class cPrTmInterface
    Inherits cPrTmInterfaceDBTier   '
    Private mId As Integer
    Private mAcc_Code As String
    Private mTemGrp_Code As String
    Private mEmp_Code As String
    Private mEDC_Code As String
    Private mCon_Level As String
    Private mAmount As Double
    Private mAnal0 As String
    Private mAnal1 As String
    Private mAnal2 As String
    Private mAnal3 As String
    Private mAnal4 As String
    Private mAnal5 As String
    Private mAnalUnion As String
    Private mExternalDoc As String
    Private mIsCheque As String
    Private mAccType As String
    Private mAnal0Pos As Integer
    Private mAnal1Pos As Integer
    Private mAnal2Pos As Integer
    Private mAnal3Pos As Integer
    Private mAnal4Pos As Integer
    Private mAnal5Pos As Integer
    Private mAnalUnionPos As Integer
    Private mBalAccount As String
    Private mReasonCode As String


    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal value As Integer)
            mId = value
        End Set
    End Property
    Public Property Acc_Code() As String
        Get
            Return mAcc_Code
        End Get
        Set(ByVal value As String)
            mAcc_Code = value
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
    Public Property Emp_Code() As String
        Get
            Return mEmp_Code
        End Get
        Set(ByVal value As String)
            mEmp_Code = value
        End Set
    End Property
    Public Property EDC_Code() As String
        Get
            Return mEDC_Code
        End Get
        Set(ByVal value As String)
            mEDC_Code = value
        End Set
    End Property
    Public Property Con_Level() As String
        Get
            Return mCon_Level
        End Get
        Set(ByVal value As String)
            mCon_Level = value
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
    Public Property Anal0() As String
        Get
            Return mAnal0
        End Get
        Set(ByVal value As String)
            mAnal0 = value
        End Set
    End Property
    Public Property Anal1() As String
        Get
            Return mAnal1
        End Get
        Set(ByVal value As String)
            mAnal1 = value
        End Set
    End Property
    Public Property Anal2() As String
        Get
            Return mAnal2
        End Get
        Set(ByVal value As String)
            mAnal2 = value
        End Set
    End Property
    Public Property Anal3() As String
        Get
            Return mAnal3
        End Get
        Set(ByVal value As String)
            mAnal3 = value
        End Set
    End Property
    Public Property Anal4() As String
        Get
            Return mAnal4
        End Get
        Set(ByVal value As String)
            mAnal4 = value
        End Set
    End Property
    Public Property Anal5() As String
        Get
            Return mAnal5
        End Get
        Set(ByVal value As String)
            mAnal5 = value
        End Set
    End Property
    Public Property AnalUnion() As String
        Get
            Return mAnalUnion
        End Get
        Set(ByVal value As String)
            mAnalUnion = value
        End Set
    End Property
    Public Property ExternalDoc() As String
        Get
            Return mExternalDoc
        End Get
        Set(ByVal value As String)
            mExternalDoc = value
        End Set
    End Property
    Public Property IsCheque() As String
        Get
            Return mIsCheque
        End Get
        Set(ByVal value As String)
            mIsCheque = value
        End Set
    End Property
    Public Property AccType() As String
        Get
            Return mAccType
        End Get
        Set(ByVal value As String)
            mAccType = value
        End Set
    End Property
    Public Property Anal0Pos() As Integer
        Get
            Return mAnal0Pos
        End Get
        Set(ByVal value As Integer)
            mAnal0Pos = value
        End Set
    End Property
    Public Property Anal1Pos() As Integer
        Get
            Return mAnal1Pos
        End Get
        Set(ByVal value As Integer)
            mAnal1Pos = value
        End Set
    End Property
    Public Property Anal2Pos() As Integer
        Get
            Return mAnal2Pos
        End Get
        Set(ByVal value As Integer)
            mAnal2Pos = value
        End Set
    End Property
    Public Property Anal3Pos() As Integer
        Get
            Return mAnal3Pos
        End Get
        Set(ByVal value As Integer)
            mAnal3Pos = value
        End Set
    End Property
    Public Property Anal4Pos() As Integer
        Get
            Return mAnal4Pos
        End Get
        Set(ByVal value As Integer)
            mAnal4Pos = value
        End Set
    End Property
    Public Property Anal5Pos() As Integer
        Get
            Return mAnal5Pos
        End Get
        Set(ByVal value As Integer)
            mAnal5Pos = value
        End Set
    End Property
    Public Property AnalUnionPos() As Integer
        Get
            Return mAnalUnionPos
        End Get
        Set(ByVal value As Integer)
            mAnalUnionPos = value
        End Set
    End Property
    Public Property BalAccount() As String
        Get
            Return mbalaccount
        End Get
        Set(ByVal value As String)
            mbalaccount = value
        End Set
    End Property
    Public Property ReasonCode() As String
        Get
            Return mreasoncode
        End Get
        Set(ByVal value As String)
            mreasoncode = value

        End Set
    End Property

   
    
   
    Public Sub New()

    End Sub
    Public Sub New(ByVal tId)
        Dim Ds As DataSet
        Ds = MyBase.GetByPK(tId)
        If CheckDataSet(Ds) Then
            LoadDataRow(Ds.Tables(0).Rows(0))
        End If
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If

    End Sub
    
    Private Sub LoadDataRow(ByVal dr As DataRow)
        Mid = DbNullToInt(dr.Item(0))
        mAcc_Code = DbNullToString(dr.Item(1))
        mTemGrp_Code = DbNullToString(dr.Item(2))
        mEmp_Code = DbNullToString(dr.Item(3))
        mEDC_Code = DbNullToString(dr.Item(4))
        mCon_Level = DbNullToString(dr.Item(5))
        mAmount = DbNullToDouble(dr.Item(6))
        mAnal0 = DbNullToString(dr.Item(7))
        mAnal1 = DbNullToString(dr.Item(8))
        mAnal2 = DbNullToString(dr.Item(9))
        mAnal3 = DbNullToString(dr.Item(10))
        mAnal4 = DbNullToString(dr.Item(11))
        mAnal5 = DbNullToString(dr.Item(12))
        mAnalUnion = DbNullToString(dr.Item(13))
        mExternalDoc = DbNullToString(dr.Item(14))
        mIsCheque = DbNullToString(dr.Item(15))
        mAccType = DbNullToString(dr.Item(16))
        mAnal0Pos = DbNullToInt(dr.Item(17))
        mAnal1Pos = DbNullToInt(dr.Item(18))
        mAnal2Pos = DbNullToInt(dr.Item(19))
        mAnal3Pos = DbNullToInt(dr.Item(20))
        mAnal4Pos = DbNullToInt(dr.Item(21))
        mAnal5Pos = DbNullToInt(dr.Item(22))
        mAnalUnionPos = DbNullToInt(dr.Item(23))
        mBalAccount = DbNullToString(dr.Item(24))
        mReasonCode = DbNullToString(dr.Item(25))


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
