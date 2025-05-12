Public Class cItemDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select Itm_Code," & _
        "Itm_DescriptionL," & _
        "Itm_DescriptionS," & _
        "ItmAn1_Code," & _
        "ItmAn2_Code," & _
        "ItmAn3_Code," & _
        "ItmAn4_Code," & _
        "ItmAn5_Code," & _
        "Itm_SupCode," & _
        "ItmSta_Code," & _
        "Itm_Barcode," & _
        "Itm_Parentcode," & _
        "Itm_ParentFactor," & _
        "Itm_AltUnit1," & _
        "Itm_AltUnit2," & _
        "Itm_AltUnit3," & _
        "Itm_AltUnit4," & _
        "Itm_GWeight," & _
        "Itm_NWeight," & _
        "Itm_Volume," & _
        "Itm_BudType," & _
        "Itm_Price1," & _
        "Itm_Price2," & _
        "Itm_Price3," & _
        "Itm_Price4," & _
        "Tariff_Code," & _
        "CoO_Code," & _
        "Itm_AltCode," & _
        "Itm_CreatedBy," & _
        "Itm_CreationDate," & _
        "Itm_AmendBy," & _
        "Itm_AmendDate " & _
        " From MmMsItem" & _
        " Where Itm_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cItem As cItem, ByVal Update As Boolean) As Boolean

        Dim Str As String
        With _cItem
            If Not Update Then
                Str = "INSERT INTO MmMsItem(" & _
                "Itm_Code," & _
                "Itm_DescriptionL," & _
                "Itm_DescriptionS," & _
                "ItmAn1_Code," & _
                "ItmAn2_Code," & _
                "ItmAn3_Code," & _
                "ItmAn4_Code," & _
                "ItmAn5_Code," & _
                "Itm_SupCode," & _
                "ItmSta_Code," & _
                "Itm_Barcode," & _
                "Itm_Parentcode," & _
                "Itm_ParentFactor," & _
                "Itm_AltUnit1," & _
                "Itm_AltUnit2," & _
                "Itm_AltUnit3," & _
                "Itm_AltUnit4," & _
                "Itm_GWeight," & _
                "Itm_NWeight," & _
                "Itm_Volume," & _
                "Itm_BudType," & _
                "Itm_Price1," & _
                "Itm_Price2," & _
                "Itm_Price3," & _
                "Itm_Price4," & _
                "Tariff_Code," & _
                "CoO_Code," & _
                "Itm_AltCode," & _
                "Itm_CreatedBy," & _
                "Itm_CreationDate," & _
                "Itm_AmendBy," & _
                "Itm_AmendDate) " & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.DescL) & "," & _
                enQuoteString(.DescS) & "," & _
                enQuoteString(.Anl1Code) & "," & _
                enQuoteString(.Anl2Code) & "," & _
                enQuoteString(.Anl3Code) & "," & _
                enQuoteString(.Anl4Code) & "," & _
                enQuoteString(.Anl5Code) & "," & _
                enQuoteString(.SuplierCode) & "," & _
                enQuoteString(.StatusCode) & "," & _
                enQuoteString(.Barcode) & "," & _
                enQuoteString(.ParentCode) & "," & _
                 .ParentFactor & "," & _
                 .AltUnit1 & "," & _
                 .AltUnit2 & "," & _
                 .AltUnit3 & "," & _
                 .AltUnit4 & "," & _
                 .GWeight & "," & _
                 .NWeight & "," & _
                 .Volume & "," & _
                enQuoteString(.BudType) & "," & _
                 .Price1 & "," & _
                 .Price2 & "," & _
                  .Price3 & "," & _
                 .Price4 & "," & _
                enQuoteString(.TariffCode) & "," & _
                enQuoteString(.CountryOfOriginCode) & "," & _
                enQuoteString(.AltCode) & "," & _
                .CreatedBy & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                .AmendBy & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & ")"
            Else
                Str = "Update MmMsItem" & _
                " SET Itm_DescriptionL = " & enQuoteString(.DescL) & _
                    ",Itm_DescriptionS = " & enQuoteString(.DescS) & _
                    ",ItmAn1_Code = " & enQuoteString(.Anl1Code) & _
                    ",ItmAn2_Code = " & enQuoteString(.Anl2Code) & _
                    ",ItmAn3_Code = " & enQuoteString(.Anl3Code) & _
                    ",ItmAn4_Code = " & enQuoteString(.Anl4Code) & _
                    ",ItmAn5_Code = " & enQuoteString(.Anl5Code) & _
                    ",Itm_SupCode = " & enQuoteString(.SuplierCode) & _
                    ",ItmSta_Code = " & enQuoteString(.StatusCode) & _
                    ",Itm_Barcode = " & enQuoteString(.Barcode) & _
                    ",Itm_Parentcode = " & enQuoteString(.ParentCode) & _
                    ",Itm_ParentFactor = " & .ParentFactor & _
                    ",Itm_AltUnit1 = " & .AltUnit1 & _
                    ",Itm_AltUnit2 = " & .AltUnit2 & _
                    ",Itm_AltUnit3 = " & .AltUnit3 & _
                    ",Itm_AltUnit4 = " & .AltUnit4 & _
                    ",Itm_GWeight = " & .GWeight & _
                    ",Itm_NWeight = " & .NWeight & _
                    ",Itm_Volume = " & .Volume & _
                    ",Itm_BudType = " & enQuoteString(.BudType) & _
                    ",Itm_Price1= " & .Price1 & _
                    ",Itm_Price2= " & .Price2 & _
                    ",Itm_Price3= " & .Price3 & _
                    ",Itm_Price4= " & .Price4 & _
                    ",Tariff_Code= " & enQuoteString(.TariffCode) & _
                    ",CoO_Code= " & enQuoteString(.CountryOfOriginCode) & _
                    ",Itm_AltCode= " & enQuoteString(.AltCode) & _
                    ",Itm_CreatedBy= " & .CreatedBy & _
                    ",Itm_CreationDate= " & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                    ",Itm_AmendBy= " & .AmendBy & _
                    ",Itm_AmendDate= " & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                    " Where Itm_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

