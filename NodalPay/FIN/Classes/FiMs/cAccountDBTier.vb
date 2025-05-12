Public Class cAccountDBTier
    Inherits cDataTier
    Protected Function GetByCode(ByVal Code As String) As DataSet
        Dim Str As String
        Str = "Select Acc_Code," & _
        " Acc_ConsolCode," & _
        " Acc_DescriptionL," & _
        " Acc_DescriptionS," & _
        " Acc_Status," & _
        " Acc_AccTyp," & _
        " Acc_Level," & _
        " AccAn1_Code," & _
        " AccAn2_Code," & _
        " AccAn3_Code," & _
        " AccAn4_Code," & _
        " AccAn5_Code," & _
        " AccAn6_Code," & _
        " AccAn7_Code," & _
        " AccAn8_Code," & _
        " AccAn9_Code," & _
        " AccAn10_Code," & _
        " Acc_AutoOnlyFlag," & _
        " Cur_Code," & _
        " Acc_AllocatedFlag," & _
        " Acc_IsBank," & _
        " Acc_BankAcc," & _
        " TAnGrp_Code," & _
        " Acc_CreatedBy," & _
        " Acc_CreationDate," & _
        " Acc_AmendedBy," & _
        " Acc_AmendDate" & _
        " From FiMsAccount" & _
        " Where Acc_Code=" & enQuoteString(Code)

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cAccount As cAccount) As Boolean
        Dim Str As String
        With _cAccount
            If .Code > 0 Then
                Str = "INSERT INTO FiMsAccount(" & _
                "Acc_Code," & _
                "Acc_ConsolCode," & _
                "Acc_DescriptionL," & _
                "Acc_DescriptionS," & _
                "Acc_Status," & _
                "Acc_AccTyp," & _
                "Acc_Level," & _
                "AccAn1_Code," & _
                "AccAn2_Code," & _
                "AccAn3_Code," & _
                "AccAn4_Code," & _
                "AccAn5_Code," & _
                "AccAn6_Code," & _
                "AccAn7_Code," & _
                "AccAn8_Code," & _
                "AccAn9_Code," & _
                "AccAn10_Code," & _
                "Acc_AutoOnlyFlag," & _
                "Cur_Code," & _
                "Acc_AllocatedFlag," & _
                "Acc_IsBank," & _
                "Acc_BankAcc," & _
                "TAnGrp_Code," & _
                "Acc_CreatedBy," & _
                "Acc_CreationDate," & _
                "Acc_AmendedBy," & _
                "Acc_AmendDate)" & _
                "VALUES (" & enQuoteString(.Code) & "," & _
                enQuoteString(.ConsolCode) & "," & _
                enQuoteString(.DescriptionL) & "," & _
                enQuoteString(.DescriptionS) & "," & _
                enQuoteString(.Status) & "," & _
                enQuoteString(.AccTyp) & "," & _
                 .Level & "," & _
                enQuoteString(.AccAn1Code) & "," & _
                enQuoteString(.AccAn2Code) & "," & _
                enQuoteString(.AccAn3Code) & "," & _
                enQuoteString(.AccAn4Code) & "," & _
                enQuoteString(.AccAn5Code) & "," & _
                enQuoteString(.AccAn6Code) & "," & _
                enQuoteString(.AccAn7Code) & "," & _
                enQuoteString(.AccAn8Code) & "," & _
                enQuoteString(.AccAn9Code) & "," & _
                enQuoteString(.AccAn10Code) & "," & _
                enQuoteString(.AutoOnlyFlag) & "," & _
                enQuoteString(.CurCode) & "," & _
                enQuoteString(.AllocatedFlag) & "," & _
                enQuoteString(.IsBank) & "," & _
                enQuoteString(.BankAccount) & "," & _
                enQuoteString(.TAnGrpCode) & "," & _
                 .CreatedBy & "," & _
                 .CreationDate & "," & _
                 .AmendedBy & "," & _
                 .AmendDate & ")"
            Else
                Str = "Update FiMsAccount" & _
                " SET Acc_Code =" & enQuoteString(.Code) & _
                ",Acc_ConsolCode = " & enQuoteString(.ConsolCode) & _
                ",Acc_DescriptionL = " & enQuoteString(.DescriptionL) & _
                ",Acc_DescriptionS = " & enQuoteString(.DescriptionS) & _
                ",Acc_Status = " & enQuoteString(.Status) & _
                ",Acc_AccTyp = " & enQuoteString(.AccTyp) & _
                ",Acc_Level = " & .Level & _
                ",AccAn1_Code = " & enQuoteString(.AccAn1Code) & _
                ",AccAn2_Code = " & enQuoteString(.AccAn2Code) & _
                ",AccAn3_Code = " & enQuoteString(.AccAn3Code) & _
                ",AccAn4_Code = " & enQuoteString(.AccAn4Code) & _
                ",AccAn5_Code = " & enQuoteString(.AccAn5Code) & _
                ",AccAn6_Code = " & enQuoteString(.AccAn6Code) & _
                ",AccAn7_Code = " & enQuoteString(.AccAn7Code) & _
                ",AccAn8_Code = " & enQuoteString(.AccAn8Code) & _
                ",AccAn9_Code = " & enQuoteString(.AccAn9Code) & _
                ",AccAn10_Code = " & enQuoteString(.AccAn10Code) & _
                ",Acc_AutoOnlyFlag = " & enQuoteString(.AutoOnlyFlag) & _
                ",Cur_Code = " & enQuoteString(.CurCode) & _
                ",Acc_AllocatedFlag = " & enQuoteString(.AllocatedFlag) & _
                ",Acc_IsBank = " & enQuoteString(.IsBank) & _
                ",Acc_BankAcc = " & enQuoteString(.BankAccount) & _
                ",TAnGrp_Code = " & enQuoteString(.TAnGrpCode) & _
                ",Acc_CreatedBy = " & enQuoteString(.CreatedBy) & _
                ",Acc_CreationDate = " & .CreationDate & _
                ",Acc_AmendedBy = " & .AmendedBy & _
                ",Acc_AmendDate = " & .AmendDate & _
                " Where Acc_Code = " & .Code
            End If
        End With
        If MyBase.ExecuteNonQuery(Str) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

