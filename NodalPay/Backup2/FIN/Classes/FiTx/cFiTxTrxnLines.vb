Public Class cFiTxTrxnLines
    '
    Inherits cFiTxTrxnLinesDBTier
    '
    Private mId As Integer
    Private mHdrId As Integer
    Private mAccCode As String
    Private mAn1_Code As String
    Private mAn2_Code As String
    Private mAn3_Code As String
    Private mAn4_Code As String
    Private mAn5_Code As String
    Private mAn6_Code As String
    Private mAn7_Code As String
    Private mAn8_Code As String
    Private mAn9_Code As String
    Private mAn10_Code As String
    Private mNotes As String
    Private mVatCode As String
    Private mVatRate As Double
    Private mAmount As Double
    Private mGross As Double
    Private mLneDisc As Double
    Private mLneDiscPerc As Double
    Private mLneDiscVAT As Double
    Private mOverallDisc As Double
    Private mOverallDiscVAT As Double
    Private mLneTotal As Double
    Private mLneVAT As Double
    Private mLneTotalLC As Double
    Private mLneVATLC As Double
    Private mTrxnTypeFactor As Integer
    Private mFactor As Integer

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property HdrId() As Integer
        Get
            Return mHdrId
        End Get
        Set(ByVal Value As Integer)
            mHdrId = Value
        End Set
    End Property
    Public Property AccCode() As String
        Get
            Return mAccCode
        End Get
        Set(ByVal Value As String)
            mAccCode = Value
        End Set
    End Property
    Public Property An1_Code() As String
        Get
            Return mAn1_Code
        End Get
        Set(ByVal Value As String)
            mAn1_Code = Value
        End Set
    End Property
    Public Property An2_Code() As String
        Get
            Return mAn2_Code
        End Get
        Set(ByVal Value As String)
            mAn2_Code = Value
        End Set
    End Property
    Public Property An3_Code() As String
        Get
            Return mAn3_Code
        End Get
        Set(ByVal Value As String)
            mAn3_Code = Value
        End Set
    End Property
    Public Property An4_Code() As String
        Get
            Return mAn4_Code
        End Get
        Set(ByVal Value As String)
            mAn4_Code = Value
        End Set
    End Property
    Public Property An5_Code() As String
        Get
            Return mAn5_Code
        End Get
        Set(ByVal Value As String)
            mAn5_Code = Value
        End Set
    End Property
    Public Property An6_Code() As String
        Get
            Return mAn6_Code
        End Get
        Set(ByVal Value As String)
            mAn6_Code = Value
        End Set
    End Property
    Public Property An7_Code() As String
        Get
            Return mAn7_Code
        End Get
        Set(ByVal Value As String)
            mAn7_Code = Value
        End Set
    End Property
    Public Property An8_Code() As String
        Get
            Return mAn8_Code
        End Get
        Set(ByVal Value As String)
            mAn8_Code = Value
        End Set
    End Property
    Public Property An9_Code() As String
        Get
            Return mAn9_Code
        End Get
        Set(ByVal Value As String)
            mAn9_Code = Value
        End Set
    End Property
    Public Property An10_Code() As String
        Get
            Return mAn10_Code
        End Get
        Set(ByVal Value As String)
            mAn10_Code = Value
        End Set
    End Property
    Public Property Notes() As String
        Get
            Return mNotes
        End Get
        Set(ByVal Value As String)
            mNotes = Value
        End Set
    End Property
    Public Property VatCode() As String
        Get
            Return mVatCode
        End Get
        Set(ByVal Value As String)
            mVatCode = Value
        End Set
    End Property
    Public Property VatRate() As Double
        Get
            Return mVatRate
        End Get
        Set(ByVal Value As Double)
            mVatRate = Value
        End Set
    End Property
    Public Property Amount() As Double
        Get
            Return mAmount
        End Get
        Set(ByVal Value As Double)
            mAmount = Value
        End Set
    End Property
    Public Property Gross() As Double
        Get
            Return mGross
        End Get
        Set(ByVal Value As Double)
            mGross = Value
        End Set
    End Property
    Public Property LneDisc() As Double
        Get
            Return mLneDisc
        End Get
        Set(ByVal Value As Double)
            mLneDisc = Value
        End Set
    End Property
    Public Property LneDiscPerc() As Double
        Get
            Return mLneDiscPerc
        End Get
        Set(ByVal Value As Double)
            mLneDiscPerc = Value
        End Set
    End Property
    Public Property LneDiscVAT() As Double
        Get
            Return mLneDiscVAT
        End Get
        Set(ByVal Value As Double)
            mLneDiscVAT = Value
        End Set
    End Property
    Public Property OverallDisc() As Double
        Get
            Return mOverallDisc
        End Get
        Set(ByVal Value As Double)
            mOverallDisc = Value
        End Set
    End Property
    Public Property OverallDiscVAT() As Double
        Get
            Return mOverallDiscVAT
        End Get
        Set(ByVal Value As Double)
            mOverallDiscVAT = Value
        End Set
    End Property
    Public Property LneTotal() As Double
        Get
            Return mLneTotal
        End Get
        Set(ByVal Value As Double)
            mLneTotal = Value
        End Set
    End Property
    Public Property LneVAT() As Double
        Get
            Return mLneVAT
        End Get
        Set(ByVal Value As Double)
            mLneVAT = Value
        End Set
    End Property
    Public Property LneTotalLC() As Double
        Get
            Return mLneTotalLC
        End Get
        Set(ByVal Value As Double)
            mLneTotalLC = Value
        End Set
    End Property
    Public Property LneVATLC() As Double
        Get
            Return mLneVATLC
        End Get
        Set(ByVal Value As Double)
            mLneVATLC = Value
        End Set
    End Property

    Public Property TrxnTypeFactor() As Integer
        Get
            Return mTrxnTypeFactor
        End Get
        Set(ByVal value As Integer)
            mTrxnTypeFactor = value
        End Set
    End Property

    Public Property Factor() As Integer
        Get
            Return mFactor
        End Get
        Set(ByVal value As Integer)
            mFactor = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tId As Integer, ByVal tHdrId As Integer)
        If tId <> 0 And tHdrId <> 0 Then
            Init(tId, tHdrId)
        End If
    End Sub
    Private Sub Init(ByVal tId As Integer, ByVal tHdrId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tId, tHdrId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mHdrId = DbNullToInt(dr.Item(1))
        mAccCode = DbNullToString(dr.Item(2))
        mAn1_Code = DbNullToString(dr.Item(3))
        mAn2_Code = DbNullToString(dr.Item(4))
        mAn3_Code = DbNullToString(dr.Item(5))
        mAn4_Code = DbNullToString(dr.Item(6))
        mAn5_Code = DbNullToString(dr.Item(7))
        mAn6_Code = DbNullToString(dr.Item(8))
        mAn7_Code = DbNullToString(dr.Item(9))
        mAn8_Code = DbNullToString(dr.Item(10))
        mAn9_Code = DbNullToString(dr.Item(11))
        mAn10_Code = DbNullToString(dr.Item(12))
        mNotes = DbNullToString(dr.Item(13))
        mVatCode = DbNullToString(dr.Item(14))
        mVatRate = DbNullToDouble(dr.Item(15))
        mAmount = DbNullToDouble(dr.Item(16))
        mGross = DbNullToDouble(dr.Item(17))
        mLneDisc = DbNullToDouble(dr.Item(18))
        mLneDiscPerc = DbNullToDouble(dr.Item(19))
        mLneDiscVAT = DbNullToDouble(dr.Item(20))
        mOverallDisc = DbNullToDouble(dr.Item(21))
        mOverallDiscVAT = DbNullToDouble(dr.Item(22))
        mLneTotal = DbNullToDouble(dr.Item(23))
        mLneVAT = DbNullToDouble(dr.Item(24))
        mLneTotalLC = DbNullToDouble(dr.Item(25))
        mLneVATLC = DbNullToDouble(dr.Item(26))
        mTrxnTypeFactor = DbNullToInt(dr.Item(27))
        mFactor = DbNullToInt(dr.Item(28))

    End Sub
    Public Shadows Function Delete(ByVal tId As Integer, ByVal tHdrId As Integer) As Boolean
        If CanDelete() <> True Then
            MsgBox("Transactions Exist For This item - Can not Delete")
            Exit Function
        End If
        Try
            Return MyBase.Delete(tId, tHdrId)
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
        For Counter = 0 To Ds.Tables.Count
            RecordCounter = RecordCounter + CInt(Ds.Tables(Counter).Rows(0).Item(0))
        Next Counter
        If RecordCounter = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

