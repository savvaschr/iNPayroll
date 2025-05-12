Public Class cVatRatesDBTier
    Inherits cDataTier

    Protected Function GetById(ByVal Id As Integer) As DataSet
        Dim Str As String
        Str = "Select  VatRte_id ," & _
         " Vat_Code ," & _
         " VatRte_rate, " & _
         " VatRte_EffectiveDate ," & _
         " VatRte_CreatedBy ," & _
         " VatRte_CreationDate ," & _
         " VatRte_AmendBy ," & _
         " VatRte_AmendDate," & _
         " VatRte_IsActive" & _
        " From AdMsVatRates " & _
        " Where  VatRte_id=" & Utils.enQuoteString(Id)
        Return MyBase.GetData(Str)
    End Function
    Protected Function GetByCodeANDEffectiveDate(ByVal Code As String, ByVal EffectiveDate As Date) As DataSet
        Dim Str As String
        Dim EffectDate As String = Format(EffectiveDate, "yyyy-MM-dd")
        EffectDate = Utils.ChangeDateFormatForSearching(EffectDate)

        Str = "Select  VatRte_id ," & _
         " Vat_Code ," & _
         " VatRte_rate, " & _
         " VatRte_EffectiveDate ," & _
         " VatRte_CreatedBy ," & _
         " VatRte_CreationDate ," & _
         " VatRte_AmendBy ," & _
         " VatRte_AmendDate," & _
         " VatRte_IsActive" & _
        " From AdMsVatRates " & _
        " Where  Vat_Code=" & Utils.enQuoteString(Code) & " and  VatRte_EffectiveDate = " & Utils.enQuoteString(EffectDate)
        Return MyBase.GetData(Str)
    End Function

    Protected Function Save(ByRef _cVatRates As cVatRates) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList

      
        With _cVatRates
            SpParams.Add(.id)              '0
            SpNames.Add("VatRte_id")
            SpParams.Add(.Code)            '1
            SpNames.Add("Vat_Code")
            SpParams.Add(.Rate)            '2
            SpNames.Add("VatRte_Rate")
            SpParams.Add(.EffectiveDate)   '3
            SpNames.Add("VatRte_EffectiveDate")
            SpParams.Add(.CreatedBy)       '4
            SpNames.Add("VatRte_CreatedBy")
            SpParams.Add(.CreationDate)    '5
            SpNames.Add("VatRte_CreationDate")
            SpParams.Add(.Amendby)         '6
            SpNames.Add("VatRte_AmendBy")
            SpParams.Add(.AmendDate)       '7
            SpNames.Add("VatRte_AmendDate")
            SpParams.Add(.IsActive)        '8
            SpNames.Add("VatRte_IsActive")
            SpParams.Add(CInt(0))          '9
            SpNames.Add("NewId")

        End With

        If Me.StoredProcedure("AdMsVatRates_Save", SpParams, SpNames, 9) Then
            If _cVatRates.id = 0 Then
                _cVatRates.id = DbNullToInt(SpParams(9))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
