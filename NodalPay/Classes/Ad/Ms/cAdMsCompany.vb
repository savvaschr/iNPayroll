Imports System.Data
Public Class cAdMsCompany
    Inherits cAdMsCompanyDBTier
    Private mId As Integer
    Private mCode As String
    Private mName As String
    Private mNameShort As String

    Private mTIC As String
    Private mTaxCard As String
    Private mSIRegNo As String
    Private mCurSymbol As String
    Private mAddress1 As String
    Private mAddress2 As String
    Private mAddress3 As String
    Private mAddress4 As String
    Private mTel1 As String
    Private mTel2 As String
    Private mFax1 As String
    Private mFax2 As String
    Private mAccountantPostCode As String
    Private mAccountantPOBox As String
    Private mAccountantTitle As String
    Private mAccountantTIC As String
    Private mAccIdentity As Integer
    Private mTICCategory As Integer
    Private mTICType As Integer
    Private mBankCode As String
    Private mGLAnal1 As String
    Private mGLAnal2 As String
    Private mGLAnal3 As String
    Private mGLAnal4 As String
    Private mGLAnal5 As String
    Private mTSAccount As String
    Private mTSAccountType As String
    Private mTSBalAccount As String
    Private mTSBalAccountType As String
    Private mTSDefaultJob As String
    Private mSI2 As String
    Private mSI3 As String
    Private mSI4 As String
    Private mSI5 As String
    Private mBankCode2 As String
    Private mBankCode3 As String
    Private mBankCode4 As String
    Private mLogo As Image
    Private mStamp As Image

    Public Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal Value As Integer)
            mId = Value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property
    Public Property NameShort() As String
        Get
            Return mNameShort
        End Get
        Set(ByVal Value As String)
            mNameShort = Value
        End Set
    End Property



  

    Public Property TIC() As String
        Get
            Return mTIC
        End Get
        Set(ByVal Value As String)
            mTIC = Value
        End Set
    End Property

    Public Property TaxCard() As String
        Get
            Return mTaxCard
        End Get
        Set(ByVal Value As String)
            mTaxCard = Value
        End Set
    End Property
    Public Property SIRegNo() As String
        Get
            Return mSIRegNo
        End Get
        Set(ByVal Value As String)
            mSIRegNo = Value
        End Set
    End Property
    Public Property CurSymbol() As String
        Get
            Return mCurSymbol
        End Get
        Set(ByVal Value As String)
            mCurSymbol = Value
        End Set
    End Property

  
    Public Property Address1() As String
        Get
            Return mAddress1
        End Get
        Set(ByVal Value As String)
            mAddress1 = Value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return mAddress2
        End Get
        Set(ByVal Value As String)
            mAddress2 = Value
        End Set
    End Property
    Public Property Address3() As String
        Get
            Return mAddress3
        End Get
        Set(ByVal Value As String)
            mAddress3 = Value
        End Set
    End Property
    Public Property Address4() As String
        Get
            Return mAddress4
        End Get
        Set(ByVal Value As String)
            mAddress4 = Value
        End Set
    End Property

   

    Public Property Tel1() As String
        Get
            Return mTel1
        End Get
        Set(ByVal Value As String)
            mTel1 = Value
        End Set
    End Property
    Public Property Tel2() As String
        Get
            Return mTel2
        End Get
        Set(ByVal Value As String)
            mTel2 = Value
        End Set
    End Property

    Public Property Fax1() As String
        Get
            Return mFax1
        End Get
        Set(ByVal Value As String)
            mFax1 = Value
        End Set
    End Property

    Public Property Fax2() As String
        Get
            Return mFax2
        End Get
        Set(ByVal Value As String)
            mFax2 = Value
        End Set
    End Property

    Public Property AccountantPostCode() As String
        Get
            Return mAccountantPostCode
        End Get
        Set(ByVal Value As String)
            mAccountantPostCode = Value
        End Set
    End Property

    Public Property AccountantPOBox() As String
        Get
            Return mAccountantPOBox
        End Get
        Set(ByVal Value As String)
            mAccountantPOBox = Value
        End Set
    End Property

    Public Property AccountantTitle() As String
        Get
            Return mAccountantTitle
        End Get
        Set(ByVal Value As String)
            mAccountantTitle = Value
        End Set
    End Property
    Public Property AccountantTIC()
        Get
            Return mAccountantTIC
        End Get
        Set(ByVal value)
            mAccountantTIC = value
        End Set
    End Property
    Public Property AccIdentity() As Integer
        Get
            Return mAccIdentity
        End Get
        Set(ByVal value As Integer)
            mAccIdentity = value
        End Set
    End Property
    Public Property TICCategory() As Integer
        Get
            Return mTICCategory
        End Get
        Set(ByVal value As Integer)
            mTICCategory = value
        End Set
    End Property
    Public Property TICType() As Integer
        Get
            Return mTICType
        End Get
        Set(ByVal value As Integer)
            mTICType = value
        End Set
    End Property
    Public Property BankCode() As String
        Get
            Return mBankCode
        End Get
        Set(ByVal value As String)
            mBankCode = value
        End Set
    End Property
    Public Property GLAnal1() As String
        Get
            Return mGLAnal1
        End Get
        Set(ByVal value As String)
            mGLAnal1 = value
        End Set
    End Property
    Public Property GLAnal2() As String
        Get
            Return mGLAnal2
        End Get
        Set(ByVal value As String)
            mGLAnal2 = value
        End Set
    End Property
    Public Property GLAnal3() As String
        Get
            Return mGLAnal3
        End Get
        Set(ByVal value As String)
            mGLAnal3 = value
        End Set
    End Property
    Public Property GLAnal4() As String
        Get
            Return mGLAnal4
        End Get
        Set(ByVal value As String)
            mGLAnal4 = value
        End Set
    End Property
    Public Property GLAnal5() As String
        Get
            Return mGLAnal5
        End Get
        Set(ByVal value As String)
            mGLAnal5 = value
        End Set
    End Property
    Public Property TSAccount() As String
        Get
            Return mTSAccount
        End Get
        Set(ByVal value As String)
            mTSAccount = value
        End Set
    End Property
    Public Property TSAccountType() As String
        Get
            Return mTSAccountType
        End Get
        Set(ByVal value As String)
            mTSAccountType = value
        End Set
    End Property
    Public Property TSBalAccount() As String
        Get
            Return Me.mTSBalAccount
        End Get
        Set(ByVal value As String)
            Me.mTSBalAccount = value

        End Set
    End Property
    Public Property TSBalAccountType() As String
        Get
            Return Me.mTSBalAccountType
        End Get
        Set(ByVal value As String)
            Me.mTSBalAccountType = value

        End Set
    End Property
    Public Property TSDefaultJob() As String
        Get
            Return Me.mTSDefaultJob
        End Get
        Set(ByVal value As String)
            Me.mTSDefaultJob = value
        End Set
    End Property
    Public Property SI2() As String
        Get
            Return mSI2
        End Get
        Set(ByVal value As String)
            mSI2 = value
        End Set
    End Property
    Public Property SI3() As String
        Get
            Return mSI3
        End Get
        Set(ByVal value As String)
            mSI3 = value
        End Set
    End Property
    Public Property SI4() As String
        Get
            Return mSI4
        End Get
        Set(ByVal value As String)
            mSI4 = value
        End Set
    End Property
    Public Property SI5() As String
        Get
            Return mSI5
        End Get
        Set(ByVal value As String)
            mSI5 = value
        End Set
    End Property
    Public Property BankCode2() As String
        Get
            Return mBankCode2
        End Get
        Set(ByVal value As String)
            mBankCode2 = value
        End Set
    End Property
    Public Property BankCode3() As String
        Get
            Return mBankCode3
        End Get
        Set(ByVal value As String)
            mBankCode3 = value
        End Set
    End Property

    Public Property BankCode4() As String
        Get
            Return mBankCode4
        End Get
        Set(ByVal value As String)
            mBankCode4 = value
        End Set
    End Property
    Public Property ComLogo() As Image
        Get
            Return mLogo
        End Get
        Set(ByVal value As Image)
            mLogo = value
        End Set
    End Property
    Public Property ComStamp() As Image
        Get
            Return mStamp
        End Get
        Set(ByVal value As Image)
            mStamp = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal dr As DataRow)
        If Not dr Is Nothing Then
            LoadDataRow(dr)
        End If
    End Sub

    Public Sub New(ByVal tId As Integer)
        Try
            Dim ds As DataSet
            ds = MyBase.GetById(tId)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try

    End Sub
    Public Sub New(ByVal tCode As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByCode(tCode)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception

        End Try

    End Sub

    Private Sub LoadDataRow(ByVal dr As DataRow)
        mId = DbNullToInt(dr.Item(0))
        mCode = DbNullToString(dr.Item(1))
        mName = DbNullToString(dr.Item(2))
        mNameShort = DbNullToString(dr.Item(3))
        mTIC = DbNullToString(dr.Item(4))
        mTaxCard = DbNullToString(dr.Item(5))
        mSIRegNo = DbNullToString(dr.Item(6))
        mCurSymbol = DbNullToString(dr.Item(7))
        mAddress1 = DbNullToString(dr.Item(8))
        mAddress2 = DbNullToString(dr.Item(9))
        mAddress3 = DbNullToString(dr.Item(10))
        mAddress4 = DbNullToString(dr.Item(11))
        mTel1 = DbNullToString(dr.Item(12))
        mTel2 = DbNullToString(dr.Item(13))
        mFax1 = DbNullToString(dr.Item(14))
        mFax2 = DbNullToString(dr.Item(15))
        mAccountantPostCode = DbNullToString(dr.Item(16))
        mAccountantPOBox = DbNullToString(dr.Item(17))
        mAccountantTitle = DbNullToString(dr.Item(18))
        mAccountantTIC = DbNullToString(dr.Item(19))
        mAccIdentity = DbNullToInt(dr.Item(20))
        mTICCategory = DbNullToInt(dr.Item(21))
        mTICType = DbNullToInt(dr.Item(22))
        mBankCode = DbNullToString(dr.Item(23))
        mGLAnal1 = DbNullToString(dr.Item(24))
        mGLAnal2 = DbNullToString(dr.Item(25))
        mGLAnal3 = DbNullToString(dr.Item(26))
        mGLAnal4 = DbNullToString(dr.Item(27))
        mGLAnal5 = DbNullToString(dr.Item(28))
        mTSAccount = DbNullToString(dr.Item(29))
        mTSAccountType = DbNullToString(dr.Item(30))
        mTSBalAccount = DbNullToString(dr.Item(31))
        mTSBalAccountType = DbNullToString(dr.Item(32))
        mTSDefaultJob = DbNullToString(dr.Item(33))
        '
        mSI2 = DbNullToString(dr.Item(34))
        mSI3 = DbNullToString(dr.Item(35))
        mSI4 = DbNullToString(dr.Item(36))
        mSI5 = DbNullToString(dr.Item(37))
        mBankCode2 = DbNullToString(dr.Item(38))
        mBankCode3 = DbNullToString(dr.Item(39))
        mBankCode4 = DbNullToString(dr.Item(40))

        If IsDBNull(dr.Item(41)) Then
            mLogo = My.Resources.photo
        Else
            Dim data As Byte() = DirectCast(dr.Item(41), Byte())
            Dim ms As New System.IO.MemoryStream(data)
            mLogo = Image.FromStream(ms)
        End If

        If IsDBNull(dr.Item(42)) Then
            mStamp = My.Resources.photo
        Else
            Dim data As Byte() = DirectCast(dr.Item(42), Byte())
            Dim ms As New System.IO.MemoryStream(data)
            mStamp = Image.FromStream(ms)
        End If


    End Sub
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Shadows Function Delete(ByVal CompanyCode As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Dim TempCode As String = ""
        Try

            Str = "select temgrp_code from prMstemplategroup where com_code=" & enQuoteString(CompanyCode)
            Dim Ds As DataSet
            Ds = GetData(Str)
            If CheckDataSet(Ds) Then
                Dim i As Integer
                BeginTransaction()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    TempCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                    Str = "delete from PrtxIr59 where Trxhdr_id in (select Trxhdr_id from Prtxtrxnheader where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete from Prtxtrxnlines where Trxhdr_id in (select Trxhdr_id from Prtxtrxnheader where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete from PrtxTrxnheader where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    TempCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                    Str = "delete from PrtxEmployeediscounts where emp_code in (select emp_code from prmsemployees where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete  from PrMsTemplateEarnings where TemGrp_Code=" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete  from PrMsTemplateDeductions where TemGrp_Code=" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete  from PrMsTemplateContributions where TemGrp_Code=" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete  from PrtxemployeeSalary where emp_code in (Select emp_code from prmsemployees where TemGrp_Code=" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete  from PrTxemployeeDiscounts where emp_code in (Select emp_code from prmsemployees where TemGrp_Code=" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete  from PrMsemployeeDeductions where  emp_code in (Select emp_code from prmsemployees where TemGrp_Code=" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete from  PrTxEmployeeDiscounts where PrdGrp_Code in (select PrdGrp_Code from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If


                    Str = "delete  from PrMsemployeeEarnings where  emp_code in (Select emp_code from prmsemployees where TemGrp_Code=" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete  from PrMsemployeeContributions where emp_code in (Select emp_code from prmsemployees where TemGrp_Code=" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If


                    Str = "delete  from PrMsemployees where TemGrp_Code=" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsPeriodEarnings where PrdGrp_Code in (select PrdGrp_Code  from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsPerioddeductions where PrdGrp_Code in (select PrdGrp_Code  from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsPeriodcontributions where PrdGrp_Code in (select PrdGrp_Code  from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsPeriodCodes  where PrdGrp_Code in (select PrdGrp_Code  from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode) & ")"
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsPeriodGroups where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                    Str = "delete from PrMsearningsinterface where TemGrp_Code=" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsdeductionsinterface where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMscontributionsInterface where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsInterfaceCodes where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsInterfaceTemplate where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrMsTemplateGroup where TemGrp_Code =" & enQuoteString(TempCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from PrSsCompanyUsers  where com_Code =" & enQuoteString(CompanyCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If
                    Str = "delete from admsCompany  where com_Code =" & enQuoteString(CompanyCode)
                    If MyBase.ExecuteNonQuery(Str) = -1 Then
                        Throw Exx
                    End If

                Next

                CommitTransaction()
            Else
                BeginTransaction()

                Str = "delete from PrSsCompanyUsers  where com_Code =" & enQuoteString(CompanyCode)
                If MyBase.ExecuteNonQuery(Str) = -1 Then
                    Throw Exx
                End If
                Str = "delete from admsCompany  where com_Code =" & enQuoteString(CompanyCode)
                If MyBase.ExecuteNonQuery(Str) = -1 Then
                    Throw Exx
                End If

                CommitTransaction()

                Flag = False
            End If
        Catch ex As Exception
            Rollback()
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function

    Public Shadows Function Exists() As Boolean
        Try
            Return MyBase.Exists(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Overrides Function Tostring() As String
        Return Me.Code & " - " & NameShort
    End Function
    Public Shadows Function CheckForDeletion() As Boolean
        Try
            Return MyBase.checkfordeletion(Me)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
