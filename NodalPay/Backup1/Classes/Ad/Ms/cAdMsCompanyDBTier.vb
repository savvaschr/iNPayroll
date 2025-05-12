Imports System.Data
Public Class cAdMsCompanyDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = "Select Com_Id," & _
        "  Com_Code," & _
        " Com_Name," & _
        " Com_NameS, " & _
        " Com_TIC, " & _
        " Com_TaxCard, " & _
        " Com_SIRegNo, " & _
        " Com_CurSymbol, " & _
        " Com_Address1, " & _
        " Com_Address2, " & _
        " Com_Address3, " & _
        " Com_Address4, " & _
        " Com_Tel1, " & _
        " Com_Tel2, " & _
        " Com_Fax1, " & _
        " Com_Fax2, " & _
        " Com_AccountantPostCode, " & _
        " Com_AccountantPOBox," & _
        " Com_AccountantTitle," & _
        " Com_AccTIC," & _
        " Com_AccIdentity," & _
        " Com_TICCategory," & _
        " Com_TICType," & _
        " Com_BankCode, " & _
        " Com_GLAnal1, " & _
        " Com_GLAnal2, " & _
        " Com_GLAnal3, " & _
        " Com_GLAnal4, " & _
        " Com_GLAnal5," & _
        " Com_TSAccount, " & _
        " Com_TSAccountType, " & _
        " Com_TSBalAccount, " & _
        " Com_TSBalAccountType, " & _
        " Com_TSDefaultJob, " & _
        " Com_SI2, " & _
        " Com_SI3," & _
        " Com_SI4," & _
        " Com_SI5," & _
        " Com_BankCode2," & _
        " Com_BankCode3," & _
        " Com_BankCode4, " & _
        " Com_Logo, " & _
        " Com_Stamp " & _
        " FROM AdMsCompany Where Com_Id=" & Id
        Return MyBase.GetData(Str)
    End Function

    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select Com_Id," & _
        "  Com_Code," & _
        " Com_Name," & _
        " Com_NameS, " & _
        " Com_TIC, " & _
        " Com_TaxCard, " & _
        " Com_SIRegNo, " & _
        " Com_CurSymbol, " & _
        " Com_Address1, " & _
        " Com_Address2, " & _
        " Com_Address3, " & _
        " Com_Address4, " & _
        " Com_Tel1, " & _
        " Com_Tel2, " & _
        " Com_Fax1, " & _
        " Com_Fax2, " & _
        " Com_AccountantPostCode, " & _
        " Com_AccountantPOBox," & _
        " Com_AccountantTitle," & _
        " Com_AccTIC," & _
        " Com_AccIdentity," & _
        " Com_TICCategory," & _
        " Com_TICType," & _
        " Com_BankCode," & _
        " Com_GLAnal1, " & _
        " Com_GLAnal2, " & _
        " Com_GLAnal3, " & _
        " Com_GLAnal4, " & _
        " Com_GLAnal5," & _
        " Com_TSAccount, " & _
        " Com_TSAccountType, " & _
        " Com_TSBalAccount, " & _
        " Com_TSBalAccountType, " & _
        " Com_TSDefaultJob , " & _
        " Com_SI2, " & _
        " Com_SI3," & _
        " Com_SI4," & _
        " Com_SI5," & _
        " Com_BankCode2," & _
        " Com_BankCode3," & _
        " Com_BankCode4, " & _
        " Com_Logo, " & _
        " Com_Stamp " & _
        " FROM AdMsCompany Where Com_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function


    Protected Function Save(ByVal _cCompany As cAdMsCompany) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cCompany
            SpParams.Add(.Id)
            SpNames.Add("Com_Id")

            SpParams.Add(.Code)
            SpNames.Add("Com_Code")
            SpParams.Add(.Name)
            SpNames.Add("Com_Name")
            SpParams.Add(.NameShort)
            SpNames.Add("Com_NameS")
            SpParams.Add(.TIC)
            SpNames.Add("Com_TIC")
            SpParams.Add(.TaxCard)
            SpNames.Add("Com_TaxCard")
            SpParams.Add(.SIRegNo)
            SpNames.Add("Com_SIRegNo")
            SpParams.Add(.CurSymbol)
            SpNames.Add("Com_CurSymbol")
            SpParams.Add(.Address1)
            SpNames.Add("Com_Address1")
            SpParams.Add(.Address2)
            SpNames.Add("Com_Address2")
            SpParams.Add(.Address3)
            SpNames.Add("Com_Address3")
            SpParams.Add(.Address4)
            SpNames.Add("Com_Address4")
            SpParams.Add(.Tel1)
            SpNames.Add("Com_Tel1")
            SpParams.Add(.Tel2)
            SpNames.Add("Com_Tel2")
            SpParams.Add(.Fax1)
            SpNames.Add("Com_Fax1")
            SpParams.Add(.Fax2)
            SpNames.Add("Com_Fax2")
            SpParams.Add(.AccountantPostCode)
            SpNames.Add("Com_AccountantPostCode")
            SpParams.Add(.AccountantPOBox)
            SpNames.Add("Com_AccountantPOBox")
            SpParams.Add(.AccountantTitle)
            SpNames.Add("Com_AccountantTitle")
            SpParams.Add(.AccountantTIC)
            SpNames.Add("Com_AccTIC")
            SpParams.Add(.AccIdentity)
            SpNames.Add("Com_AccIdentity")
            SpParams.Add(.TICCategory)
            SpNames.Add("Com_TICCategory")
            SpParams.Add(.TICType)
            SpNames.Add("Com_TICType")
            SpParams.Add(.BankCode)
            SpNames.Add("Com_BankCode")
            SpParams.Add(.GLAnal1)
            SpNames.Add("Com_GLAnal1")
            SpParams.Add(.GLAnal2)
            SpNames.Add("Com_GLAnal2")
            SpParams.Add(.GLAnal3)
            SpNames.Add("Com_GLAnal3")
            SpParams.Add(.GLAnal4)
            SpNames.Add("Com_GLAnal4")
            SpParams.Add(.GLAnal5)
            SpNames.Add("Com_GLAnal5")
            SpParams.Add(.TSAccount)
            SpNames.Add("Com_TSAccount")
            SpParams.Add(.TSAccountType)
            SpNames.Add("Com_TSAccountType")
            SpParams.Add(.TSBalAccount)
            SpNames.Add("Com_TSBalAccount")
            SpParams.Add(.TSBalAccountType)
            SpNames.Add("Com_TSBalAccountType")
            SpParams.Add(.TSDefaultJob)
            SpNames.Add("Com_TSDefaultJob")
            SpParams.Add(.SI2)
            SpNames.Add("Com_SI2")
            SpParams.Add(.SI3)
            SpNames.Add("Com_SI3")
            SpParams.Add(.SI4)
            SpNames.Add("Com_SI4")
            SpParams.Add(.SI5)
            SpNames.Add("Com_SI5")
            SpParams.Add(.BankCode2)
            SpNames.Add("Com_BankCode2")
            SpParams.Add(.BankCode3)
            SpNames.Add("Com_BankCode3")
            SpParams.Add(.BankCode4)
            SpNames.Add("Com_BankCode4")

            If Not .ComLogo Is Nothing Then
                Dim ms As New System.IO.MemoryStream()
                Dim bmpImage As New Bitmap(.ComLogo)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()

                SpParams.Add(data)
                SpNames.Add("Com_Logo")
            Else
                'Create an empty stream in memory.
                Dim ms As New System.IO.MemoryStream()
                'Dim bmpImage As New Bitmap(0, 0, System.Drawing.Imaging.ImageFormat.Jpeg)
                ' bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()

                SpParams.Add(data)
                SpNames.Add("Com_Logo")
            End If

            If Not .ComStamp Is Nothing Then
                Dim ms As New System.IO.MemoryStream()
                Dim bmpImage As New Bitmap(.ComStamp)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()

                SpParams.Add(data)
                SpNames.Add("Com_Stamp")
            Else
                'Create an empty stream in memory.
                Dim ms As New System.IO.MemoryStream()
                'Dim bmpImage As New Bitmap(0, 0, System.Drawing.Imaging.ImageFormat.Jpeg)
                ' bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()

                SpParams.Add(data)
                SpNames.Add("Com_Stamp")
            End If




        End With
        If Me.StoredProcedure("AG_AdMsCompany_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function Delete(ByVal _cCompany As cAdMsCompany) As Boolean
        Dim Str As String

        With _cCompany
            Str = "Delete from AdMsCompany where Com_Id=" & .Id
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function CheckForDeletion(ByVal _cCompany As cAdMsCompany) As Boolean
        Dim Str As String
        Dim Ds As DataSet
        Dim flag As Boolean = False
        Str = " select * from PrTxtrxnheader" & _
              " where TemGrp_Code in" & _
              " (select TemGrp_Code from PrMsTemplateGroup where Com_Code =" & enQuoteString(_cCompany.Code) & ")"
        Ds = GetData(Str)
        If CheckDataSet(Ds) Then
            flag = False
        Else
            flag = True
        End If
        Return flag

    End Function


    Protected Function Exists(ByVal _cCompany As cAdMsCompany) As Boolean
        Dim Str As String
        Dim Ds As DataSet
        Dim CodeExists As Boolean = False

        With _cCompany
            'Str = ""
            'Ds = MyBase.GetData(Str)
            'If CInt(Ds.Tables(0).Rows(0)("NumRows").ToString()) > 0 Then
            '    Return True
            'End If

            Return False

        End With
        Return CodeExists

    End Function

End Class