' This Class has been autogenerated by Nodalsoft
' Do NOT adjust as it will be overwritten
' Generation Date : 17/03/2008 11:11:57
'
'
Public Class cPrMsPeriodCodesDbTier
    '
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String, ByVal tGroup As String) As DataSet
        Dim Str As String
        Str = " SELECT" & _
                " PrdCod_Code," & _
                " PrdGrp_Code," & _
                " PrdCod_Status," & _
                " PrdCod_Number," & _
                " PrdCod_DescriptionL," & _
                " PrdCod_DescriptionS," & _
                " PrdCod_Sequence," & _
                " SinPrd_Code," & _
                " PrdCod_DateFrom," & _
                " PrdCod_DateTo," & _
                " PrdCod_PeriodUnits," & _
                " PayCat_Code," & _
                " PrdCod_PeriodUnits2 " & _
            "  FROM PrMsPeriodCodes" & _
            "  WHERE PrdCod_Code = '" & tCode & "'" & _
            "  AND PrdGrp_Code = '" & tGroup & "'"
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByVal _cPrMsPeriodCodes As cPrMsPeriodCodes) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsPeriodCodes
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("PrdCod_Code")                                       '(0)
            SpParams.Add(.PrdGrpCode)                                        '(1)
            SpNames.Add("PrdGrp_Code")                                       '(1)
            SpParams.Add(.Status)                                            '(2)
            SpNames.Add("PrdCod_Status")                                     '(2)
            SpParams.Add(.PrdCod_Number)                                     '(3)
            SpNames.Add("PrdCod_Number")                                     '(3)
            SpParams.Add(.DescriptionL)                                      '(4)
            SpNames.Add("PrdCod_DescriptionL")                               '(4)
            SpParams.Add(.DescriptionS)                                      '(5)
            SpNames.Add("PrdCod_DescriptionS")                               '(5)
            SpParams.Add(.Sequence)                                          '(6)
            SpNames.Add("PrdCod_Sequence")                                   '(6)
            SpParams.Add(.SinPrdCode)                                        '(7)
            SpNames.Add("SinPrd_Code")                                       '(7)
            SpParams.Add(.DateFrom)                                          '(8)
            SpNames.Add("PrdCod_DateFrom")                                   '(8)
            SpParams.Add(.DateTo)                                            '(9)
            SpNames.Add("PrdCod_DateTo")                                     '(9)
            SpParams.Add(.PeriodUnits)                                       '(10)
            SpNames.Add("PrdCod_PeriodUnits")                                '(10)
            SpParams.Add(.PayCat_Code)                                       '(11)
            SpNames.Add("PayCat_Code")                                       '(11)
            SpParams.Add(.PeriodUnits2)                                       '(11)
            SpNames.Add("PrdCod_PeriodUnits2")                                '(11)
        End With
        If Me.StoredProcedure("AG_PrMsPeriodCodes_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function Delete(ByVal tCode As String) As Boolean
        Dim Str As String
        Dim Flag As Boolean = True
        Dim Exx As New System.Exception
        Try
            BeginTransaction()
            Str = " DELETE FROM PrMsPeriodCodes" & _
               " WHERE PrdCod_Code = '" & tCode & "'"
            If MyBase.ExecuteNonQuery(Str) = -1 Then
                Throw Exx
            End If
            CommitTransaction()
        Catch ex As Exception
            Rollback()
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Protected Function CheckDeleteRecords(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " " & _
        "SELECT COUNT(PrdCod_Code) " & _
        " FROM PrMsPeriodContributions" & _
        " WHERE PrdCod_Code = '" & tCode & "'" & _
        " " & _
        "SELECT COUNT(PrdCod_Code) " & _
        " FROM PrMsPeriodDeductions" & _
        " WHERE PrdCod_Code = '" & tCode & "'" & _
        " " & _
        "SELECT COUNT(PrdCod_Code) " & _
        " FROM PrMsPeriodEarnings" & _
        " WHERE PrdCod_Code = '" & tCode & "'" & _
        " " & _
        " "
        Return GetData(Str)
    End Function
    Protected Function GetNumberOfNormalPeriods(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1
        Str = "SELECT  COUNT(*)" & _
            " FROM PrMsPeriodCodes" & _
            " WHERE PayCat_Code='K'" & _
            " AND PrdGrp_Code=" & enQuoteString(tPerCode.PrdGrpCode)
        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOfNormalPeriodsUntilNow(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0
        Str = "SELECT count(*) from PrMsPeriodCodes" & _
        " WHERE PrdGrp_code=" & enQuoteString(tPerCode.PrdGrpCode) & _
        " AND PayCat_code='K'" & _
        " AND PrdCod_sequence<" & tPerCode.Sequence
        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    '**********************************************
    Protected Function GetNumberOf_NOT_NormalPeriods(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1
        Str = "SELECT  COUNT(*)" & _
            " FROM PrMsPeriodCodes" & _
            " WHERE (PayCat_Code='3' OR PayCat_Code='4' )" & _
            " AND PrdGrp_Code=" & enQuoteString(tPerCode.PrdGrpCode)
        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOf_NOT_NormalPeriodsUntilNow(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0
        Str = "SELECT count(*) from PrMsPeriodCodes" & _
        " WHERE PrdGrp_code=" & enQuoteString(tPerCode.PrdGrpCode) & _
        " AND (PayCat_code='3' OR PayCat_code='4')  " & _
        " AND PrdCod_sequence<" & tPerCode.Sequence
        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    '**********************************************
    Protected Function GetNumberOfTaxablePeriodsUntilNow(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0
        'Str = "SELECT count(*) from PrMsPeriodCodes" & _
        '" WHERE PrdGrp_code=" & enQuoteString(tPerCode.PrdGrpCode) & _
        '" AND PayCat_code='K'" & _
        '" AND PrdCod_sequence<" & tPerCode.Sequence

        Str = "SELECT COUNT(*) AS Expr1" & _
        " FROM PrMsPeriodDeductions INNER JOIN" & _
        " PrMsDeductionCodes ON PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
        " PrMsPeriodCodes ON PrMsPeriodDeductions.PrdCod_Code = PrMsPeriodCodes.PrdCod_Code AND " & _
        " PrMsPeriodDeductions.PrdGrp_Code = PrMsPeriodCodes.PrdGrp_Code" & _
        " WHERE (PrMsPeriodCodes.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
        " AND (PrMsPeriodCodes.PrdCod_Sequence < " & tPerCode.Sequence & ")" & _
        " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'Y')" & _
        " AND (PrMsDeductionCodes.DedTyp_Code = 'IT')"

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOfTaxable(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1

        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodDeductions INNER JOIN" & _
            " PrMsDeductionCodes ON " & _
            " PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
            " PrSsDeductionTypes ON" & _
            " PrMsDeductionCodes.DedTyp_Code = PrSsDeductionTypes.DedTyp_Code" & _
            " WHERE (PrMsPeriodDeductions.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
            " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'Y')" & _
            " AND (PrSsDeductionTypes.DedTyp_Code = 'IT')"

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetTOTALPeriods(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1

        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodcodes " & _
            " WHERE PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode)
            

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOfNonTaxable(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0

        'Str = " SELECT count(*) " & _
        Str = " SELECT PrdCod_Code " & _
           " FROM PrMsPeriodDeductions INNER JOIN" & _
           " PrMsDeductionCodes ON " & _
           " PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
           " PrSsDeductionTypes ON" & _
           " PrMsDeductionCodes.DedTyp_Code = PrSsDeductionTypes.DedTyp_Code" & _
           " WHERE (PrMsPeriodDeductions.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
           " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'N')" & _
           " AND (PrSsDeductionTypes.DedTyp_Code = 'IT')"



        DS = GetData(Str)

        If CheckDataSet(DS) Then
            Dim i As Integer
            Dim Per As New cPrMsPeriodCodes
            Dim Code As String
            For i = 0 To DS.Tables(0).Rows.Count - 1
                Code = DbNullToString(DS.Tables(0).Rows(i).Item(0))
                Per = New cPrMsPeriodCodes(Code, tPerCode.PrdGrpCode)
                If Per.Sequence > tPerCode.Sequence Then
                    NOfPeriods = NOfPeriods + 1
                End If
            Next

        Else
            NOfPeriods = 0
        End If


        Return NOfPeriods
    End Function
    Protected Function GetNumberOfTotalPeriods_taxable(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1
        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodDeductions INNER JOIN" & _
            " PrMsDeductionCodes ON " & _
            " PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
            " PrSsDeductionTypes ON" & _
            " PrMsDeductionCodes.DedTyp_Code = PrSsDeductionTypes.DedTyp_Code" & _
            " WHERE (PrMsPeriodDeductions.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
            " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'Y')" & _
         " AND (PrSsDeductionTypes.DedTyp_Code = 'IT')"

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function

    Protected Function GetNumberOfTaxableFORDisplayONLY(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 1

        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodDeductions INNER JOIN" & _
            " PrMsDeductionCodes ON " & _
            " PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
            " PrSsDeductionTypes ON" & _
            " PrMsDeductionCodes.DedTyp_Code = PrSsDeductionTypes.DedTyp_Code" & _
            " WHERE (PrMsPeriodDeductions.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
            " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'Y')" & _
            " AND (PrSsDeductionTypes.DedTyp_Code = 'IT')"

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOfNonTaxableFORDisplayONLY(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0

        Str = " SELECT count(*) " & _
           " FROM PrMsPeriodDeductions INNER JOIN" & _
           " PrMsDeductionCodes ON " & _
           " PrMsPeriodDeductions.DedCod_Code = PrMsDeductionCodes.DedCod_Code INNER JOIN" & _
           " PrSsDeductionTypes ON" & _
           " PrMsDeductionCodes.DedTyp_Code = PrSsDeductionTypes.DedTyp_Code" & _
           " WHERE (PrMsPeriodDeductions.PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & ")" & _
           " AND (PrMsPeriodDeductions.PrdDed_IsActive = 'N')" & _
           " AND (PrSsDeductionTypes.DedTyp_Code = 'IT')"


        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods


        Return NOfPeriods
    End Function
    Protected Function GetNumberOfTotalPeriodsFORDisplayONLY(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0
        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodCodes " & _
            " WHERE PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode)

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function GetNumberOfNotNormalPeriodsTocome(ByVal tPerCode As cPrMsPeriodCodes)
        Dim Str As String
        Dim DS As DataSet
        Dim NOfPeriods As Integer = 0
        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodCodes " & _
            " WHERE PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & _
            " AND PrdCod_Sequence > " & tPerCode.Sequence & _
            " AND PayCat_Code<>'K'"

        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NOfPeriods = DbNullToInt(DS.Tables(0).Rows(0).Item(0))
        End If
        Return NOfPeriods
    End Function
    Protected Function RatioTotalPeriodsToWorkPeriods(ByVal tPerCode As cPrMsPeriodCodes, ByVal Emp As cPrMsEmployees) As Double
        Dim NoOfPeriods As Integer = 0
        Dim NoOfPeriodsToWork As Integer = 0
        Dim Sequence As Integer = 0
        Dim Str As String
        Dim Ds As DataSet
        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodCodes " & _
            " WHERE PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & _
            " AND PayCat_Code='K'"
        DS = GetData(Str)
        If CheckDataSet(DS) Then
            NoOfPeriods = DbNullToInt(Ds.Tables(0).Rows(0).Item(0))
        End If

        Str = "select PrdCod_sequence  from Prmsperiodcodes" & _
        " where ( PrdCod_DateFrom <=" & enQuoteString(Emp.StartDate) & _
        " and  PrdCod_Dateto >=" & enQuoteString(Emp.StartDate) & ")" & _
        " and PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & _
        " and PayCat_Code ='K'"
        Ds = GetData(Str)
        If CheckDataSet(Ds) Then
            Sequence = DbNullToInt(Ds.Tables(0).Rows(0).Item(0))
        End If

        Str = " SELECT count(*) " & _
            " FROM PrMsPeriodCodes " & _
            " WHERE PrdGrp_Code =" & enQuoteString(tPerCode.PrdGrpCode) & _
            " AND PayCat_Code='K'" & _
            " AND PrdCod_sequence>=" & Sequence
        Ds = GetData(Str)
        If CheckDataSet(Ds) Then
            NOofPeriodstowork = DbNullToInt(Ds.Tables(0).Rows(0).Item(0))
        End If

        Return (NoOfPeriodsToWork / NoOfPeriods)

    End Function
    Protected Function GetPreviousPeriod(ByVal CurPeriod As cPrMsPeriodCodes) As cPrMsPeriodCodes
        Dim Str As String
        Dim sequence As Integer = 0
        sequence = CurPeriod.Sequence
        Dim NewPeriodGroupCode As String = ""
        Dim PrevPeriod As New cPrMsPeriodCodes

        If sequence <> 1 Then
            sequence = sequence - 1
            newperiodgroupcode = CurPeriod.PrdGrpCode
        Else
            sequence = 0
            Dim PeriodGroup As New cPrMsPeriodGroups(CurPeriod.PrdGrpCode)
            Dim Year As Integer = PeriodGroup.Year
            Dim PrevYear As Integer
            PrevYear = Year - 1
            NewPeriodGroupCode = Replace(PeriodGroup.Code, Year.ToString, PrevYear.ToString)
            ' Dim NewPeriodGroup As New cPrMsPeriodGroups(NewPeriodGroupCode)

            Str = " SELECT max(PrdCod_Sequence) from PrMsPeriodCodes " & _
                  "  WHERE PrdGrp_Code = " & enQuoteString(NewPeriodGroupCode)
            Dim Ds As DataSet

            Ds = GetData(Str)
            If CheckDataSet(Ds) Then
                sequence = DbNullToInt(Ds.Tables(0).Rows(0).Item(0))
            End If
        End If
        If sequence <> 0 Then
            Str = " SELECT" & _
                      " PrdCod_Code," & _
                      " PrdGrp_Code," & _
                      " PrdCod_Status," & _
                      " PrdCod_Number," & _
                      " PrdCod_DescriptionL," & _
                      " PrdCod_DescriptionS," & _
                      " PrdCod_Sequence," & _
                      " SinPrd_Code," & _
                      " PrdCod_DateFrom," & _
                      " PrdCod_DateTo," & _
                      " PrdCod_PeriodUnits," & _
                      " PayCat_Code," & _
                      " PrdCod_PeriodUnits2 " & _
                  "  FROM PrMsPeriodCodes" & _
                  "  WHERE PrdGrp_Code = " & enQuoteString(NewPeriodGroupCode) & _
                  "  AND PrdCod_Sequence =" & sequence
            Dim Ds As DataSet
            Ds = GetData(Str)
            PrevPeriod = New cPrMsPeriodCodes(Ds.Tables(0).Rows(0))
        End If

        Return PrevPeriod

    End Function
   
   
End Class
