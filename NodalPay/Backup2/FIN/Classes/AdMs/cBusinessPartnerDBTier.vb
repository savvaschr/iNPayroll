Public Class cBusinessPartnerDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select BusPrt_Code," & _
        "BusPrt_DescriptionL," & _
        "BusPrt_DescriptionS," & _
        "BusPrt_ConsolCode," & _
        "BPaAn1_Code," & _
        "BPaAn2_Code," & _
        "BPaAn3_Code," & _
        "BPaAn4_Code," & _
        "BPaAn5_Code," & _
        "BusPrt_BudType," & _
        "BusPrt_VisitFreq," & _
        "Adr_Id1," & _
        "Adr_Id2," & _
        "Adr_Id3," & _
        "BusPrt_TaxID," & _
        "BusPrt_VATRegNo," & _
        "BusPrt_IsVATEnabled," & _
        "BusPrt_IsVATIncluded," & _
        "BusPrt_IdNo," & _
        "Acc_Code," & _
        "BPtSta_Code," & _
        "BPtTyp_Code," & _
        "BPtTrm_Code," & _
        "BusPrt_CreatedBy," & _
        "BusPrt_CreationDate," & _
        "BusPrt_AmendedBy," & _
        "BusPrt_AmendDate," & _
        "Cur_AlphaCode, " & _
        "CrdPro_Code " & _
        " From AdMsBusinessPartner" & _
        " Where BusPrt_Code=" & enQuoteString(Code)
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cBusinessPartner As cBusinessPartner, ByVal Update As Boolean) As Boolean
        Dim Str As String
        

        With _cBusinessPartner
            Dim Adr1 As String = .AdrId1
            Dim Adr2 As String = .AdrId2
            Dim Adr3 As String = .AdrId3
            If .AdrId1 = 0 Then
                Adr1 = "null"
            End If
            If .AdrId2 = 0 Then
                Adr2 = "null"
            End If
            If .AdrId3 = 0 Then
                Adr3 = "null"
            End If

            If Not Update Then
                Str = "INSERT INTO AdMsBusinessPartner(" & _
                "BusPrt_Code," & _
                "BusPrt_DescriptionL," & _
                "BusPrt_DescriptionS," & _
                "BusPrt_ConsolCode," & _
                "BPaAn1_Code," & _
                "BPaAn2_Code," & _
                "BPaAn3_Code," & _
                "BPaAn4_Code," & _
                "BPaAn5_Code," & _
                "BusPrt_BudType," & _
                "BusPrt_VisitFreq," & _
                "Adr_Id1," & _
                "Adr_Id2," & _
                "Adr_Id3," & _
                "BusPrt_TaxID," & _
                "BusPrt_VATRegNo," & _
                "BusPrt_IsVATEnabled," & _
                "BusPrt_IsVATIncluded," & _
                "BusPrt_IdNo," & _
                "Acc_Code," & _
                "BPtSta_Code," & _
                "BPtTyp_Code," & _
                "BPtTrm_Code," & _
                "BusPrt_CreatedBy," & _
                "BusPrt_CreationDate," & _
                "BusPrt_AmendedBy," & _
                "BusPrt_AmendDate," & _
                "Cur_AlphaCode, " & _
                "CrdPro_Code)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.DescL) & "," & _
                enQuoteString(.DescS) & "," & _
                enQuoteString(.ConsolidationCode) & "," & _
                enQuoteString(.Anal1) & "," & _
                enQuoteString(.Anal2) & "," & _
                enQuoteString(.Anal3) & "," & _
                enQuoteString(.Anal4) & "," & _
                enQuoteString(.Anal5) & "," & _
                enQuoteString(.BudType) & "," & _
                enQuoteString(.VisitFreq) & "," & _
                Adr1 & "," & _
                Adr2 & "," & _
                Adr3 & "," & _
                enQuoteString(.TAXId) & "," & _
                enQuoteString(.VATRegNo) & "," & _
                enQuoteString(.IsVATEnabled) & "," & _
                enQuoteString(.IsVATIncluded) & "," & _
                enQuoteString(.IdNo) & "," & _
                enQuoteString(.AccountCode) & "," & _
                enQuoteString(.StatusCode) & "," & _
                enQuoteString(.TypeCode) & "," & _
                enQuoteString(.TrmCode) & "," & _
                .CreatedBy & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & "," & _
                .AmendBy & "," & _
                enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & "," & _
                enQuoteString(.CurAlphaCode) & "," & _
                enQuoteString(.CreditProfileCode) & ")"
            Else
                Str = "Update AdMsBusinessPartner" & _
                " SET BusPrt_Code = " & enQuoteString(.Code) & _
                ",BusPrt_DescriptionL = " & enQuoteString(.DescL) & _
                ",BusPrt_DescriptionS = " & enQuoteString(.DescS) & _
                ",BusPrt_ConsolCode = " & enQuoteString(.ConsolidationCode) & _
                ",BPaAn1_Code = " & enQuoteString(.Anal1) & _
                ",BPaAn2_Code = " & enQuoteString(.Anal2) & _
                ",BPaAn3_Code = " & enQuoteString(.Anal3) & _
                ",BPaAn4_Code = " & enQuoteString(.Anal4) & _
                ",BPaAn5_Code = " & enQuoteString(.Anal5) & _
                ",BusPrt_BudType = " & enQuoteString(.BudType) & _
                ",BusPrt_VisitFreq = " & enQuoteString(.VisitFreq) & _
                ",Adr_Id1 = " & Adr1 & _
                ",Adr_Id2 = " & Adr2 & _
                ",Adr_Id3 = " & Adr3 & _
                ",BusPrt_TaxID = " & enQuoteString(.TAXId) & _
                ",BusPrt_VATRegNo = " & enQuoteString(.VATRegNo) & _
                ",BusPrt_IsVATEnabled= " & enQuoteString(.IsVATEnabled) & _
                ",BusPrt_IsVATIncluded= " & enQuoteString(.IsVATEnabled) & _
                ",BusPrt_IdNo= " & enQuoteString(.IdNo) & _
                ",Acc_Code= " & enQuoteString(.AccountCode) & _
                ",BPtSta_Code= " & enQuoteString(.StatusCode) & _
                ",BPtTyp_Code= " & enQuoteString(.TypeCode) & _
                ",BPtTrm_Code= " & enQuoteString(.TrmCode) & _
                ",BusPrt_CreatedBy = " & .CreatedBy & _
                ",BusPrt_CreationDate = " & enQuoteString(Utils.ChangeDateForSaving(.CreationDate)) & _
                ",BusPrt_AmendedBy = " & .AmendBy & _
                ",BusPrt_AmendDate = " & enQuoteString(Utils.ChangeDateForSaving(.AmendDate)) & _
                ",Cur_AlphaCode = " & enQuoteString(.CurAlphaCode) & _
                ",CrdPro_Code = " & enQuoteString(.CreditProfileCode) & _
                " Where BusPrt_Code = " & enQuoteString(.Code)
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
