'Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmImportTimeSheetsFromExcel
    Public GLB_TempGroup As String
    Public GLB_PeriodGroup As String
    Public GLB_PeriodCode As String


    Private Sub btn_M_ConvertFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_M_ConvertFile.Click
        Dim FromFile As String = ""
        Dim ToFile As String = ""
        If Me.txt_M_SourceLocationExcel.Text = "" Then
            MsgBox("Select Valid Source for text File", MsgBoxStyle.Critical)
            Exit Sub
        Else
            FromFile = Me.txt_M_SourceLocationExcel.Text
        End If
        If Initializemonth() Then
            If Import_Excel_to_Table(FromFile) Then
                If SumDifferencesPerEmployee() Then
                    MsgBox("Finish Importing Timesheets", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to import Timesheets", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Unable to Initialize Timesheets", MsgBoxStyle.Critical)
        End If

    End Sub
    Private Function Initializemonth() As Boolean
        Dim Exx As System.Exception
        Dim Flag As Boolean = True
        Try
            Global1.Business.BeginTransaction()

            Global1.Business.DeleteEmployeeTimesheets(GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode)
            Dim ds As DataSet
            Dim P As New cPrMsPeriodCodes(GLB_PeriodCode, GLB_PeriodGroup)
            ds = Global1.Business.GetAllPrMsEmployeesByTemplateGroup(GLB_TempGroup, "", "", P, 0, "0", False, False, False, 0, False, "", "", 1, "", 0, False)

            Dim FromDate As Date
            Dim ToDate As Date

            FromDate = CDate(P.DateFrom)
            ToDate = CDate(P.DateTo)


            If CheckDataSet(ds) Then
                Dim i As Integer
                Dim EmpCode As String
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Dim F As Boolean = True
                    Dim StopNext As Boolean = False
                    Dim D1 As Date = FromDate
                    Dim emp As New cPrMsEmployees(EmpCode)
                    If emp.Code <> "" Then
                        If emp.TemGrp_Code = GLB_TempGroup Then

                            Do While F = True
                                Dim Tsh As New cPrTxTimesheets(EmpCode, D1, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode)
                                With Tsh
                                    .EmpCode = EmpCode
                                    .TemGroup = GLB_TempGroup
                                    .PeriodGroup = GLB_PeriodGroup
                                    .PeriodCode = GLB_PeriodCode
                                    .TransDate = D1
                                    .In1 = ""
                                    .Out1 = ""
                                    .In2 = ""
                                    .Out2 = ""
                                    .In3 = ""
                                    .Out3 = ""
                                    .TotalWorkPerDay = "00:00"
                                    .TotalWorkPerWeek = ""
                                    .TotalWorkPerMonth = ""
                                    .ALHours = 0
                                    .SickHours = 0
                                    .ArmyHours = 0
                                    .MaterHours = 0
                                    .NormalDayHours = "00:00"
                                    .DayDiff = "+00:00"
                                    .MonthDiff = 0
                                    .totalMonthNormal = "00:00"
                                    .FromFile = 0
                                    .BusTrip = 0
                                    .FamDeath = 0
                                    .StudyLeave = 0
                                    .WorkFromHome = 0

                                    If Not .Save Then
                                        Throw Exx
                                    End If
                                End With

                                If StopNext Then
                                    F = False
                                End If
                                D1 = DateAdd(DateInterval.Day, 1, D1)
                                If D1 = ToDate Then
                                    StopNext = True
                                End If
                            Loop
                        End If
                    End If
                Next
            End If
            Global1.Business.CommitTransaction()
        Catch ex As Exception
            Flag = False
            Global1.Business.Rollback()
        End Try
        Return Flag

    End Function
    Private Function Import_Excel_to_Table(ByVal FromFileName As String) As Boolean

        Dim Normal_day_hours As String
        Normal_day_hours = "09:00"

        Dim Holiday_day_hours As String
        Holiday_day_hours = "00:00"

        Dim Zero_day_hours As String
        Zero_day_hours = "00:00"

        Dim Exx As New Exception

        Cursor.Current = Cursors.WaitCursor
        Dim InitFile As Boolean = True
        Dim ApendFile As Boolean = True
        '    Dim xlApp As Excel.Application
        '    Dim xlWorkBook As Excel.Workbook
        '    Dim xlWorkSheet As Excel.Worksheet

        Dim TotalRows As Integer = 0
        Dim TotalColumns As Integer = 0

        Dim c_EmpCode As String = ""
        Dim c_TransDate As String = ""
        Dim c_In1 As String = ""
        Dim c_Out1 As String = ""
        Dim c_In2 As String = ""
        Dim c_Out2 As String = ""
        Dim c_In3 As String = ""
        Dim c_Out3 As String = ""
        Dim c_TotalDay As String = ""
        Dim c_TotalWeek As String = ""
        Dim c_TotalMonth As String = ""

        Dim c_An_Leave As String = ""
        Dim c_An_SickLeave As String = ""
        Dim c_Holiday As String = ""
        Dim c_An_Army As String = ""
        Dim c_An_BusTrip As String = ""
        Dim c_An_FamDeath As String = ""
        Dim c_An_StudyLeave As String = ""
        Dim c_An_WorkFromHome As String = ""
        Dim c_An_Maternity As String = ""

        Dim Line As String = ""

        'xlApp = New Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Open(FromFileName)
        'xlWorkSheet = xlWorkBook.Worksheets(1)


        'TotalRows = xlWorkSheet.UsedRange.Rows.Count
        'TotalColumns = xlWorkSheet.UsedRange.Columns.Count()
        'Dim i As Integer
        'Dim SEP As String = "|||"
        Dim SEP As String = "	"
        Dim Counter As Integer = 0
        'Dim TW As System.IO.TextWriter
        Dim param_file As IO.StreamReader
        Dim LoadedOk As Boolean = False
        Dim NextDay As Integer
        Dim NextEmp As String = ""
        Try


            Global1.Business.BeginTransaction()
            param_file = IO.File.OpenText(FromFileName)
            LoadedOk = False


            Counter = 0

            Do While param_file.Peek <> -1
                Dim d As Date

                Me.Refresh()
                Dim Ar() As String

                Line = param_file.ReadLine()
                NextDay = 1
                If Counter <> 0 Then


                    Ar = Line.Split("	")



                    c_EmpCode = Ar(3)
                    c_TransDate = Ar(4)
                    c_In1 = Ar(5)
                    c_Out1 = Ar(6)
                    c_In2 = Ar(7)
                    c_Out2 = Ar(8)
                    c_In2 = Ar(9)
                    c_Out3 = Ar(10)

                    c_TotalDay = Ar(35)
                    c_TotalWeek = Ar(36)
                    c_TotalMonth = Ar(37)

                    c_An_Leave = Ar(38)
                    c_An_SickLeave = Ar(39)
                    c_Holiday = Ar(40)
                    c_An_Army = Ar(41)
                    c_An_BusTrip = Ar(42)
                    c_An_FamDeath = Ar(43)
                    c_An_StudyLeave = Ar(44)
                    c_An_WorkFromHome = Ar(45)
                    '   c_An_Maternity = Ar(47)


                    If c_An_Leave = "" Then
                        c_An_Leave = Zero_day_hours
                    End If
                    If c_An_SickLeave = "" Then
                        c_An_SickLeave = Zero_day_hours
                    End If

                    If c_An_Army = "" Then
                        c_An_Army = Zero_day_hours
                    End If

                    If c_An_BusTrip = "" Then
                        c_An_BusTrip = Zero_day_hours
                    End If
                    If c_An_FamDeath = "" Then
                        c_An_FamDeath = Zero_day_hours
                    End If
                    If c_An_StudyLeave = "" Then
                        c_An_StudyLeave = Zero_day_hours
                    End If
                    If c_An_WorkFromHome = "" Then
                        c_An_WorkFromHome = Zero_day_hours
                    End If

                    Dim TotalHoliday As String
                    TotalHoliday = c_An_Leave
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_SickLeave)
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_Army)
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_BusTrip)
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_FamDeath)
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_StudyLeave)
                    TotalHoliday = Me.Adddays(TotalHoliday, c_An_WorkFromHome)



                    Dim emp As New cPrMsEmployees(c_EmpCode)
                    If emp.Code = "" Or emp.Code Is Nothing Then
                        '   MsgBox("Line " & Counter & " Employee code " & c_EmpCode & " Does not exist", MsgBoxStyle.Critical)
                        '  Throw Exx
                    Else


                        If emp.TemGrp_Code = GLB_TempGroup Then
                            'If emp.Code = "02" Then
                            '    MsgBox(1)
                            'End If
                            Dim ar1() As String
                            ar1 = c_TransDate.Split("/")
                            d = CDate(ar1(2) & "/" & ar1(1) & "/" & ar1(0))
                            If c_TotalDay = "" Then
                                c_TotalDay = "0:00:00"
                            End If
                            If c_TotalWeek = "" Then
                                c_TotalWeek = "0:00:00"
                            End If
                            If c_TotalMonth = "" Then
                                c_TotalMonth = "0:00:00"

                            End If
                            If c_Holiday = "" Then
                                c_Holiday = "0"
                            End If

                            Dim Tsh As New cPrTxTimesheets(c_EmpCode, d, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode)
                            With Tsh
                                .EmpCode = c_EmpCode
                                .TemGroup = GLB_TempGroup
                                .PeriodGroup = GLB_PeriodGroup
                                .PeriodCode = GLB_PeriodCode
                                .TransDate = d
                                .In1 = c_In1
                                .Out1 = c_Out1
                                .In2 = c_In2
                                .Out2 = c_Out2
                                .In3 = c_In3
                                .Out3 = c_Out3
                                .TotalWorkPerDay = c_TotalDay
                                .TotalWorkPerWeek = c_TotalWeek
                                .TotalWorkPerMonth = c_TotalMonth



                                If c_Holiday = "1" Then
                                    .NormalDayHours = Holiday_day_hours
                                Else
                                    .NormalDayHours = Normal_day_hours
                                End If
                                .MaterHours = 0



                                .DayDiff = Finddaydiff(.NormalDayHours, c_TotalDay)
                                .DayDiff = Adddays(.DayDiff, TotalHoliday)

                                .MonthDiff = 0
                                .totalMonthNormal = "00:00"
                                .FromFile = 1

                                .ALHours = Replace(c_An_Leave, ":", ".")
                                .SickHours = Replace(c_An_SickLeave, ":", ".")
                                .ArmyHours = Replace(c_An_Army, ":", ".")
                                .BusTrip = Replace(c_An_BusTrip, ":", ".")
                                .FamDeath = Replace(c_An_FamDeath, ":", ".")
                                .StudyLeave = Replace(c_An_StudyLeave, ":", ".")
                                .WorkFromHome = Replace(c_An_WorkFromHome, ":", ".")

                                If Not .Save Then
                                    Throw Exx
                                End If

                            End With


                        End If
                    End If
                End If
                'If Counter = 1525 Then
                '    MsgBox(1)
                'End If
                Counter = Counter + 1

            Loop

            Global1.Business.CommitTransaction()
            LoadedOk = True
        Catch ex As Exception

            LoadedOk = False
            Global1.Business.Rollback()
            Utils.ShowException(ex)
            MsgBox("Last Line working on " & Counter)
        End Try





        'xlWorkBook.Close()
        'xlApp.Quit()


        'releaseObject(xlApp)
        'releaseObject(xlWorkBook)
        'releaseObject(xlWorkSheet)

        param_file.Close()
        param_file.Dispose()

        GC.Collect()
        If Not LoadedOk Then
            MsgBox("Unable to Import Timesheets", MsgBoxStyle.Information)
        End If
        Return LoadedOk
        Cursor.Current = Cursors.Default
    End Function
    Private Function SumDifferencesPerEmployee() As Boolean
        Dim Exx As System.Exception
        Dim F As Boolean = True
        Try

            Dim Ds As DataSet
            Ds = Global1.Business.GetTimesheets(GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode)
            If CheckDataSet(Ds) Then
                Dim cEmp As String = ""
                Dim EmpCode As String = ""
                Dim Diff As String
                Dim i As Integer
                Dim totalHours As Integer
                Dim TotalMinutes As Integer

                Dim totalHours2 As Integer
                Dim TotalMinutes2 As Integer

                Dim totalHours3 As Integer
                Dim TotalMinutes3 As Integer

                Dim totalHours4 As Integer
                Dim TotalMinutes4 As Integer

                Dim totalHours5 As Integer
                Dim TotalMinutes5 As Integer

                Dim totalHours6 As Integer
                Dim TotalMinutes6 As Integer

             

                Dim Normal As String
                Dim AL As String
                Dim Sick As String
                Dim Army As String
                Dim Mater As String
                Dim TTDiff As String = "00:00"

                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim Time1 As String
                    EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                    Diff = DbNullToString(Ds.Tables(0).Rows(i).Item(20))
                    Normal = DbNullToString(Ds.Tables(0).Rows(i).Item(19))

                    al = DbNullToString(Ds.Tables(0).Rows(i).Item(15))
                    sick = DbNullToString(Ds.Tables(0).Rows(i).Item(16))
                    army = DbNullToString(Ds.Tables(0).Rows(i).Item(17))
                    Mater = DbNullToString(Ds.Tables(0).Rows(i).Item(18))
                    'If EmpCode = "02" Then
                    '    MsgBox(1)
                    'End If
                    AL = AL.Replace(".", ":")
                    Sick = Sick.Replace(".", ":")
                    Army = Army.Replace(".", ":")
                    Mater = Mater.Replace(".", ":")

                    If cEmp <> EmpCode Then
                        If cEmp <> "" Then
                            If Not UpdateTimesheetsTotalDifference(cEmp, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode, totalHours, TotalMinutes, totalHours2, TotalMinutes2, totalHours3, TotalMinutes3, totalHours4, TotalMinutes4, totalHours5, TotalMinutes5, totalHours6, TotalMinutes6) Then
                                Throw Exx
                            End If
                            cEmp = EmpCode
                        Else
                            cEmp = EmpCode
                        End If
                        totalHours = 0
                        TotalMinutes = 0
                        totalHours2 = 0
                        TotalMinutes2 = 0
                        totalHours3 = 0
                        TotalMinutes3 = 0
                        totalHours4 = 0
                        TotalMinutes4 = 0
                        totalHours5 = 0
                        TotalMinutes5 = 0
                        TTDiff = "00:00"
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                   
                    '  TTDiff = Me.Adddays(TTDiff, Diff)

                    Dim Ar1() As String
                    Dim H1 As Integer
                    Dim M1 As Integer
                    Ar1 = Diff.Split(":")
                    H1 = Ar1(0)
                    M1 = Ar1(1)
                    If H1 < 0 Or M1 < 0 Then
                        totalHours = totalHours - Math.Abs(H1)
                        TotalMinutes = TotalMinutes - Math.Abs(M1)
                    Else
                        totalHours = totalHours + H1
                        TotalMinutes = TotalMinutes + M1
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Ar2() As String
                    Dim H2 As Integer
                    Dim M2 As Integer
                    Ar2 = Normal.Split(":")
                    H2 = Ar2(0)
                    M2 = Ar2(1)
                    If H2 < 0 Or M2 < 0 Then
                        totalHours2 = totalHours2 - Math.Abs(H2)
                        TotalMinutes2 = TotalMinutes2 - Math.Abs(M2)
                    Else
                        totalHours2 = totalHours2 + H2
                        TotalMinutes2 = TotalMinutes2 + M2
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Ar3() As String
                    Dim H3 As Integer
                    Dim M3 As Integer
                    Ar3 = AL.Split(":")
                    H3 = Ar3(0)
                    M3 = Ar3(1)
                    If H3 < 0 Or M3 < 0 Then
                        totalHours3 = totalHours3 - Math.Abs(H3)
                        TotalMinutes3 = TotalMinutes3 - Math.Abs(M3)
                    Else
                        totalHours3 = totalHours3 + H3
                        TotalMinutes3 = TotalMinutes3 + M3
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Ar4() As String
                    Dim H4 As Integer
                    Dim M4 As Integer
                    Ar4 = Sick.Split(":")
                    H4 = Ar4(0)
                    M4 = Ar4(1)
                    If H4 < 0 Or M4 < 0 Then
                        totalHours4 = totalHours4 - Math.Abs(H4)
                        TotalMinutes4 = TotalMinutes4 - Math.Abs(M4)
                    Else
                        totalHours4 = totalHours4 + H4
                        TotalMinutes4 = TotalMinutes4 + M4
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Ar5() As String
                    Dim H5 As Integer
                    Dim M5 As Integer
                    Ar5 = Army.Split(":")
                    H5 = Ar5(0)
                    M5 = Ar5(1)
                    If H5 < 0 Or M5 < 0 Then
                        totalHours5 = totalHours5 - Math.Abs(H5)
                        TotalMinutes5 = TotalMinutes5 - Math.Abs(M5)
                    Else
                        totalHours5 = totalHours5 + H5
                        TotalMinutes5 = TotalMinutes5 + M5
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Ar6() As String
                    Dim H6 As Integer
                    Dim M6 As Integer
                    Ar6 = Mater.Split(":")
                    H6 = Ar6(0)
                    M6 = Ar6(1)
                    If H6 < 0 Or M6 < 0 Then
                        totalHours6 = totalHours6 - Math.Abs(H6)
                        TotalMinutes6 = TotalMinutes6 - Math.Abs(M6)
                    Else
                        totalHours6 = totalHours6 + H6
                        TotalMinutes6 = TotalMinutes6 + M6
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Next
                If Not UpdateTimesheetsTotalDifference(EmpCode, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode, totalHours, TotalMinutes, totalHours2, TotalMinutes2, totalHours3, TotalMinutes3, totalHours4, TotalMinutes4, totalHours5, TotalMinutes5, totalHours6, TotalMinutes6) Then
                    Throw Exx
                End If
            End If


        Catch ex As Exception
            MsgBox("Unable to Sum Differences", MsgBoxStyle.Critical)
            F = False
        End Try
        Return f
    End Function
    Private Function UpdateTimesheetsTotalDifference(ByVal EmpCode As String, ByVal GLB_TempGroup As String, ByVal GLB_PeriodGroup As String, ByVal GLB_PeriodCode As String, ByVal totalHours As Integer, ByVal TotalMinutes As Integer, ByVal TotalHours2 As Integer, ByVal TotalMinutes2 As Integer, ByVal TotalHours3 As Integer, ByVal TotalMinutes3 As Integer, ByVal TotalHours4 As Integer, ByVal TotalMinutes4 As Integer, ByVal TotalHours5 As Integer, ByVal TotalMinutes5 As Integer, ByVal TotalHours6 As Integer, ByVal TotalMinutes6 As Integer) As Boolean
        Dim F As Boolean = False
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M As Integer
            Dim H As Double
            If TotalMinutes > 60 Then
                M = TotalMinutes Mod 60
                H = TotalMinutes / 60
                Dim HH As String
                HH = Format(H, "0.00")
                Dim Ar() As String
                Ar = HH.Split(".")
                H = Ar(0)
                TotalMinutes = M
            End If
            totalHours = totalHours + H


            Dim MonthDiff As String
            Dim Sign As String = "+"
            If CInt(totalHours) < 0 Or CInt(TotalMinutes) < 0 Then
                Sign = "-"
            End If

            MonthDiff = Sign & Math.Abs(totalHours) & ":" & Math.Abs(TotalMinutes).ToString.PadLeft(2, "0")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M2 As Integer
            Dim H2 As Double
            If TotalMinutes2 > 60 Then
                M2 = TotalMinutes2 Mod 60
                H2 = TotalMinutes2 / 60
                Dim HH2 As String
                HH2 = Format(H2, "0.00")
                Dim Ar2() As String
                Ar2 = HH2.Split(".")
                H2 = Ar2(0)
                TotalMinutes2 = M2
            End If
            TotalHours2 = TotalHours2 + H2


            Dim Total2 As String
            Dim Sign2 As String = "+"
            If CInt(TotalHours2) < 0 Or CInt(TotalMinutes2) < 0 Then
                Sign2 = "-"
            End If

            Total2 = Sign2 & Math.Abs(TotalHours2) & ":" & Math.Abs(TotalMinutes2).ToString.PadLeft(2, "0")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M3 As Integer
            Dim H3 As Double
            If TotalMinutes3 > 60 Then
                M3 = TotalMinutes3 Mod 60
                H3 = TotalMinutes3 / 60
                Dim HH3 As String
                HH3 = Format(H3, "0.00")
                Dim Ar3() As String
                Ar3 = HH3.Split(".")
                H3 = Ar3(0)
                TotalMinutes3 = M3
            End If
            TotalHours3 = TotalHours3 + H3


            Dim Total3 As String
            Dim Sign3 As String = "+"
            If CInt(TotalHours3) < 0 Or CInt(TotalMinutes3) < 0 Then
                Sign3 = "-"
            End If

            Total3 = Sign3 & Math.Abs(TotalHours3) & ":" & Math.Abs(TotalMinutes3).ToString.PadLeft(2, "0")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M4 As Integer
            Dim H4 As Double
            If TotalMinutes4 > 60 Then
                M4 = TotalMinutes4 Mod 60
                H4 = TotalMinutes4 / 60
                Dim HH4 As String
                HH4 = Format(H4, "0.00")
                Dim Ar4() As String
                Ar4 = HH4.Split(".")
                H4 = Ar4(0)
                TotalMinutes4 = M4
            End If
            TotalHours4 = TotalHours4 + H4


            Dim Total4 As String
            Dim Sign4 As String = "+"
            If CInt(TotalHours4) < 0 Or CInt(TotalMinutes4) < 0 Then
                Sign4 = "-"
            End If

            Total4 = Sign4 & Math.Abs(TotalHours4) & ":" & Math.Abs(TotalMinutes4).ToString.PadLeft(2, "0")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M5 As Integer
            Dim H5 As Double
            If TotalMinutes5 > 60 Then
                M5 = TotalMinutes5 Mod 60
                H5 = TotalMinutes5 / 60
                Dim HH5 As String
                HH5 = Format(H5, "0.00")
                Dim Ar5() As String
                Ar5 = HH5.Split(".")
                H5 = Ar5(0)
                TotalMinutes5 = M5
            End If
            TotalHours5 = TotalHours5 + H5


            Dim Total5 As String
            Dim Sign5 As String = "+"
            If CInt(TotalHours5) < 0 Or CInt(TotalMinutes5) < 0 Then
                Sign5 = "-"
            End If

            Total5 = Sign5 & Math.Abs(TotalHours5) & ":" & Math.Abs(TotalMinutes5).ToString.PadLeft(2, "0")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim M6 As Integer
            Dim H6 As Double
            If TotalMinutes6 > 60 Then
                M6 = TotalMinutes6 Mod 60
                H6 = TotalMinutes6 / 60
                Dim HH6 As String
                HH6 = Format(H6, "0.00")
                Dim Ar6() As String
                Ar6 = HH6.Split(".")
                H6 = Ar6(0)
                TotalMinutes6 = M6
            End If
            TotalHours6 = TotalHours6 + H6


            Dim Total6 As String
            Dim Sign6 As String = "+"
            If CInt(TotalHours6) < 0 Or CInt(TotalMinutes6) < 0 Then
                Sign6 = "-"
            End If

            Total6 = Sign6 & Math.Abs(TotalHours6) & ":" & Math.Abs(TotalMinutes6).ToString.PadLeft(2, "0")


            If Global1.Business.UpdateEmployeeTimesheets(EmpCode, GLB_TempGroup, GLB_PeriodGroup, GLB_PeriodCode, MonthDiff, Total2, Total3, Total4, Total5, Total6) Then
                F = True
            End If
        Catch ex As Exception
            F = False
        End Try
        Return F

    End Function
    Private Function Adddays(ByVal D1 As String, ByVal D2 As String) As String
        Dim Ar1() As String
        Dim Ar2() As String
        Dim H1 As String
        Dim H2 As String
        Dim M1 As String
        Dim M2 As String


        Ar1 = D1.Split(":")
        H1 = Ar1(0)
        M1 = Ar1(1)

        Ar2 = D2.Split(":")
        H2 = Ar2(0)
        M2 = Ar2(1)



        Dim Day1D As New TimeSpan(0, H1, M1, 0, 0)
        Dim Day2D As New TimeSpan(0, H2, M2, 0, 0)

        Dim Result As TimeSpan = Day1D.Add(Day2D)

        Dim S As String
        Dim RD As String = Result.Days
        Dim RH As String = Result.Hours
        Dim RM As String = Result.Minutes

        RH = RH + (RD * 24)
        Dim Sign As String = "+"
        If RH < 0 Or RM < 0 Then
            Sign = "-"
            RH = Math.Abs(CInt(RH))
            RM = Math.Abs(CInt(RM))
        End If

        S = Sign & RH.PadLeft(2, "0") & ":" & RM.PadLeft(2, "0")

        Return S





    End Function
    Private Function Finddaydiff(ByVal Normal As String, ByVal TS As String) As String
        Dim Ar1() As String
        Dim Ar2() As String
        Dim H1 As String
        Dim H2 As String
        Dim M1 As String
        Dim M2 As String

     
        Ar1 = Normal.Split(":")
        H1 = Ar1(0)
        M1 = Ar1(1)

        Ar2 = TS.Split(":")
        H2 = Ar2(0)
        M2 = Ar2(1)



        Dim NormalD As New DateTime(2001, 1, 1, H1, M1, 0)
        Dim WorkedD As New DateTime(2001, 1, 1, H2, M2, 0)

        Dim Result As TimeSpan = WorkedD - NormalD

        Dim S As String
        Dim RH As String = Result.Hours
        Dim RM As String = Result.Minutes
        Dim Sign As String = "+"
        If RH < 0 Or RM < 0 Then
            Sign = "-"
            RH = Math.Abs(CInt(RH))
            RM = Math.Abs(CInt(RM))
        End If

        S = Sign & RH.PadLeft(2, "0") & ":" & RM.PadLeft(2, "0")

        Return S





    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Reset()
        OpenFileDialog1.ShowDialog()
        Me.txt_M_SourceLocationExcel.Text = OpenFileDialog1.FileName
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class