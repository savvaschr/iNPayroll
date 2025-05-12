Public Class cIr7DBTier
    Inherits cDataTier
    Protected Function GetByPK(ByVal tYear As String, ByVal tComp As String, ByVal tEmpCode As String) As DataSet
        Dim Str As String

        Str = " SELECT Ir7_Id, " & _
        " Ir7_Type,  " & _
        " Ir7_Year,  " & _
        " Ir7_ComCode, " & _
        " Ir7_EmpCode,  " & _
        " Ir7_TICNumber, " & _
        " Ir7_ArithmosTaftopoiisis,  " & _
        " Ir7_OtherCountryTIC, " & _
        " Ir7_SINumber, " & _
        " Ir7_Surname, " & _
        " Ir7_Name, " & _
        " Ir7_Street,  " & _
        " Ir7_Village,  " & _
        " Ir7_PostCode,  " & _
        " Ir7_EmailAddress,  " & _
        " Ir7_EmployeeType, " & _
        " Ir7_Gross, " & _
        " Ir7_GrossOut,  " & _
        " Ir7_BIKWithSI, " & _
        " Ir7_BIKWithoutSI,  " & _
        " Ir7_Total1234, " & _
        " Ir7_SIFund,  " & _
        " Ir7_PensionFund, " & _
        " Ir7_MedicalFund, " & _
        " Ir7_Unions, " & _
        " Ir7_LifeInsurance, " & _
        " Ir7_NonTaxable, " & _
        " Ir7_OtherDiscs, " & _
        " Ir7_TotalDiscs,  " & _
        " Ir7_TaxableIncome, " & _
        " Ir7_IncomeTAX,  " & _
        " Ir7_SyntaksiodotikaOfelimata, " & _
        " Ir7_MeiosiApolavon, " & _
        " Ir7_GESYtoSI, " & _
        " Ir7_GESYtoBIKDed, " & _
        " Ir7_GESYtoBIKCon, " & _
        " Ir7_StartDate,  " & _
        " Ir7_TermDate, " & _
        " Ir7_PensionNo,  " & _
        " Ir7_EmpType " & _
        " FROM PrRpIr7 " & _
        " Where Ir7_Year = " & enQuoteString(tYear) & _
        " And Ir7_ComCode = " & enQuoteString(tComp) & _
        " And Ir7_EmpCode = " & enQuoteString(tEmpCode)

        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal Ir7 As cIR7, ByVal Update As Boolean) As Boolean
        Dim Str As String
        Dim i As Integer
        Dim Flag As Boolean
        If Update Then
            With Ir7
                Str = " UPDATE PrRpIr7 " & _
                 "   SET  Ir7_Type = " & enQuoteString(.myType) & _
                 " ,[Ir7_Year] =  " & enQuoteString(.Year) & _
                 " ,[Ir7_ComCode] =  " & enQuoteString(.ComCode) & _
                 " ,[Ir7_EmpCode] =  " & enQuoteString(.EmpCode) & _
                 " ,[Ir7_TICNumber] =  " & enQuoteString(.TICNumber) & _
                 " ,[Ir7_ArithmosTaftopoiisis] =  " & enQuoteString(.ArithmosTaftopoiisis) & _
                 " ,[Ir7_OtherCountryTIC] =  " & enQuoteString(.OtherCountryTIC) & _
                 " ,[Ir7_SINumber] =  " & enQuoteString(.SINumber) & _
                 " ,[Ir7_Surname] =  " & enQuoteString(.Surname) & _
                 " ,[Ir7_Name] =  " & enQuoteString(.Name) & _
                 " ,[Ir7_Street] =  " & enQuoteString(.Street) & _
                 " ,[Ir7_Village] =  " & enQuoteString(.Village) & _
                 " ,[Ir7_PostCode] =  " & enQuoteString(.PostCode) & _
                 " ,[Ir7_EmailAddress] =  " & enQuoteString(.EmailAddress) & _
                 " ,[Ir7_EmployeeType] =  " & enQuoteString(.EmployeeType) & _
                 " ,[Ir7_Gross] =  " & .Gross & _
                 " ,[Ir7_GrossOut] =  " & .GrossOut & _
                 " ,[Ir7_BIKWithSI] =  " & .BIKWithSI & _
                 " ,[Ir7_BIKWithoutSI] =  " & .BIKWithoutSI & _
                 " ,[Ir7_Total1234] =  " & .Total1234 & _
                 " ,[Ir7_SIFund] =  " & .SIFund & _
                 " ,[Ir7_PensionFund] =  " & .PensionFund & _
                 " ,[Ir7_MedicalFund] =  " & .MedicalFund & _
                 " ,[Ir7_Unions] =  " & .Unions & _
                 " ,[Ir7_LifeInsurance] =  " & .LifeInsurance & _
                 " ,[Ir7_NonTaxable] =  " & .NonTaxable & _
                 " ,[Ir7_OtherDiscs] =  " & .OtherDiscs & _
                 " ,[Ir7_TotalDiscs] =  " & .TotalDiscs & _
                 " ,[Ir7_TaxableIncome] =  " & .TaxableIncome & _
                 " ,[Ir7_IncomeTAX] =  " & .IncomeTAX & _
                 " ,[Ir7_SyntaksiodotikaOfelimata] =  " & .SyntaksiodotikaOfelimata & _
                 " ,[Ir7_MeiosiApolavon] =  " & .MeiosiApolavon & _
                 " ,[Ir7_GESYtoSI] =  " & .GESYtoSI & _
                 " ,[Ir7_GESYtoBIKDed] =  " & .GESYtoBIKDed & _
                 " ,[Ir7_GESYtoBIKCon] =  " & .GESYtoBIKCon & _
                 " ,[Ir7_StartDate] =  " & enQuoteString(.StartDate) & _
                 " ,[Ir7_TermDate] =  " & enQuoteString(.TermDate) & _
                 " ,[Ir7_PensionNo] =  " & enQuoteString(.PensionNo) & _
                 " ,[Ir7_EmpType] =  " & enQuoteString(.EmpType) & _
                  " Where Ir7_Year = " & enQuoteString(.Year) & _
                  " And Ir7_ComCode = " & enQuoteString(.ComCode) & _
                  " And Ir7_EmpCode = " & enQuoteString(.EmpCode)

            End With

        Else
            With Ir7
                Str = "INSERT INTO PrRpIr7 " & _
                 "  ([Ir7_Type]" & _
                 "  ,[Ir7_Year] " & _
                 "  ,[Ir7_ComCode] " & _
                 "  ,[Ir7_EmpCode] " & _
                 "  ,[Ir7_TICNumber] " & _
                 "  ,[Ir7_ArithmosTaftopoiisis] " & _
                 "  ,[Ir7_OtherCountryTIC] " & _
                 "  ,[Ir7_SINumber] " & _
                 "  ,[Ir7_Surname] " & _
                 "  ,[Ir7_Name] " & _
                 "  ,[Ir7_Street] " & _
                 "  ,[Ir7_Village] " & _
                 "  ,[Ir7_PostCode] " & _
                 "  ,[Ir7_EmailAddress] " & _
                 "  ,[Ir7_EmployeeType] " & _
                 "  ,[Ir7_Gross] " & _
                 "  ,[Ir7_GrossOut] " & _
                 "  ,[Ir7_BIKWithSI] " & _
                 "  ,[Ir7_BIKWithoutSI] " & _
                 "  ,[Ir7_Total1234] " & _
                 "  ,[Ir7_SIFund] " & _
                 "  ,[Ir7_PensionFund] " & _
                 "  ,[Ir7_MedicalFund] " & _
                 "  ,[Ir7_Unions] " & _
                 "  ,[Ir7_LifeInsurance] " & _
                 "  ,[Ir7_NonTaxable] " & _
                 "  ,[Ir7_OtherDiscs] " & _
                 "  ,[Ir7_TotalDiscs] " & _
                 "  ,[Ir7_TaxableIncome] " & _
                 "  ,[Ir7_IncomeTAX] " & _
                 "  ,[Ir7_SyntaksiodotikaOfelimata] " & _
                 "  ,[Ir7_MeiosiApolavon] " & _
                 "  ,[Ir7_GESYtoSI] " & _
                 "  ,[Ir7_GESYtoBIKDed] " & _
                 "  ,[Ir7_GESYtoBIKCon] " & _
                 "  ,[Ir7_StartDate] " & _
                 "  ,[Ir7_TermDate] " & _
                 "  ,[Ir7_PensionNo] " & _
                 "  ,[Ir7_EmpType]) " & _
                 "VALUES (" & _
                enQuoteString(.myType) & "," & _
                enQuoteString(.Year) & "," & _
                enQuoteString(.ComCode) & "," & _
                enQuoteString(.EmpCode) & "," & _
                enQuoteString(.TICNumber) & "," & _
                enQuoteString(.ArithmosTaftopoiisis) & "," & _
                enQuoteString(.OtherCountryTIC) & "," & _
                enQuoteString(.SINumber) & "," & _
                enQuoteString(.Surname) & "," & _
                enQuoteString(.Name) & "," & _
                enQuoteString(.Street) & "," & _
                enQuoteString(.Village) & "," & _
                enQuoteString(.PostCode) & "," & _
                enQuoteString(.EmailAddress) & "," & _
                enQuoteString(.EmployeeType) & "," & _
                 .Gross & "," & _
                 .GrossOut & "," & _
                 .BIKWithSI & "," & _
                 .BIKWithoutSI & "," & _
                 .Total1234 & "," & _
                 .SIFund & "," & _
                 .PensionFund & "," & _
                 .MedicalFund & "," & _
                 .Unions & "," & _
                 .LifeInsurance & "," & _
                 .NonTaxable & "," & _
                 .OtherDiscs & "," & _
                 .TotalDiscs & "," & _
                 .TaxableIncome & "," & _
                 .IncomeTAX & "," & _
                 .SyntaksiodotikaOfelimata & "," & _
                 .MeiosiApolavon & "," & _
                 .GESYtoSI & "," & _
                 .GESYtoBIKDed & "," & _
                 .GESYtoBIKCon & "," & _
                enQuoteString(.StartDate) & "," & _
                enQuoteString(.TermDate) & "," & _
                enQuoteString(.PensionNo) & "," & _
                enQuoteString(.EmpType) & ")"
            End With
        End If
        i = ExecuteNonQuery(Str)
        If i >= 0 Then
            Flag = True
        Else
            Flag = False
        End If

        Return Flag

    End Function
End Class
