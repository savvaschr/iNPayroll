Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmAIMS


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Ds = Global1.Business.GetParameter("AIMS", "CCFile")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            Par.Value1 = Me.txtCCFile.Text
            Par.Save()
        Else
            Dim Par As New cPrSsParameters()
            Par.Section = "AIMS"
            Par.Item = "CCFile"
            Par.Value1 = Me.txtCCFile.Text
            Par.Description = "Cabin Crew File"
            Par.System1 = "Y"
            Par.Type1 = "T"
            Par.Save()
        End If

        Ds = Global1.Business.GetParameter("AIMS", "PLFile")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            Par.Value1 = Me.txtPLFile.Text
            Par.Save()
        Else
            Dim Par As New cPrSsParameters()
            Par.Section = "AIMS"
            Par.Item = "PLFile"
            Par.Value1 = Me.txtPLFile.Text
            Par.Description = "Pilots File"
            Par.System1 = "Y"
            Par.Type1 = "T"
            Par.Save()
        End If

        Ds = Global1.Business.GetParameter("AIMS", "PLFlight")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            Par.Value1 = Me.txtPLFlight.Text
            Par.Save()
        Else
            Dim Par As New cPrSsParameters()
            Par.Section = "AIMS"
            Par.Item = "PLFlight"
            Par.Value1 = Me.txtPLFlight.Text
            Par.Description = "Pilots Flight hours File"
            Par.System1 = "Y"
            Par.Type1 = "T"
            Par.Save()
        End If

        'Ds = Global1.Business.GetParameter("AIMS", "DestFile")
        'If CheckDataSet(ds) Then
        '    Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
        '    Par.Value1 = Me.txtDestination.Text
        '    Par.Save()
        'Else
        '    Dim Par As New cPrSsParameters()
        '    Par.Section = "AIMS"
        '    Par.Item = "DestFile"
        '    Par.Value1 = Me.txtCCFile.Text
        '    Par.Description = "Destination File"
        '    Par.System1 = "Y"
        '    Par.Type1 = "T"
        '    Par.Save()
        'End If

        MsgBox("Settings are Saved", MsgBoxStyle.Information)
    End Sub

    Private Sub FrmAIMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("AIMS", "CCFile")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtCCFile.Text = Par.Value1
        Else
            Me.txtCCFile.Text = ""
        End If
        Ds = Global1.Business.GetParameter("AIMS", "PLFile")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtPLFile.Text = Par.Value1
        Else
            Me.txtPLFile.Text = ""
        End If
        Ds = Global1.Business.GetParameter("AIMS", "PLFlight")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtPLFlight.Text = Par.Value1
        Else
            Me.txtPLFlight.Text = ""
        End If
        'Ds = Global1.Business.GetParameter("AIMS", "DestFile")
        'If CheckDataSet(Ds) Then
        '    Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
        '    Me.txtDestination.Text = Par.Value1
        'Else
        '    Me.txtDestination.Text = ""
        'End If
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ReadTextFile()
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub ReadTextFile()
        Global1.Business.DeleteAllAIMS()

        Cursor.Current = Cursors.WaitCursor

        Dim F As String
        Dim Counter As Integer = 0

        Try


            Dim Exx As System.Exception
            Dim param_file As IO.StreamReader

            Dim LoadedOK As Boolean = False

            Dim Line As String



            Dim No As String = ""
            Dim EmployeeName As String = ""
            Dim DutyHours As String = ""
            Dim Sectors As String = ""
            Dim FlightHours As String = ""

            Dim DeadHeadDuty As String = ""
            Dim DeadHeadSectors As String = ""

            Dim FileNameCC As String = Me.txtCCFile.Text
            Dim FileNamePL As String = Me.txtPLFile.Text
            Dim FileNamePLF As String = Me.txtPLFlight.Text

            param_file = IO.File.OpenText(Me.txtCCFile.Text)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''                  CABIN CREW                             '''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Do While param_file.Peek <> -1
                Application.DoEvents()
                Me.Refresh()
                Dim Ar() As String
                F = Me.txtCCFile.Text
                Counter = Counter + 1
                Line = param_file.ReadLine()
                Ar = Line.Split("	")
                No = Ar(0)
                EmployeeName = Ar(1)
                DutyHours = Ar(7)
                Sectors = Ar(9)
                FlightHours = 0

                DeadHeadDuty = Ar(6)
                DeadHeadSectors = Ar(8)
                If DutyHours = "00:00" Then
                    DutyHours = "00:00:00"
                End If
                If DeadHeadDuty = "00:00" Then
                    DeadHeadDuty = "00:00:00"
                End If


                Dim Aims As New cAIMS(No)
                Dim Update As Boolean = False
               
                If Aims.No = "" Then
                    Dim ts2 As TimeSpan = MyTimeSpanParse(DutyHours)
                    Dim ts3 As TimeSpan = MyTimeSpanParse(DeadHeadDuty)

                    Dim tsSum As TimeSpan = ts2 + ts3

                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.DutyHours = CheckForDays(tsSum.ToString)
                    Aims.Sectors = CInt(Sectors) + CInt(DeadHeadSectors)
                    Aims.FlightHours = "00:00:00"
                Else
                    Dim ts1 As TimeSpan = MyTimeSpanParse(Aims.DutyHours)
                    Dim ts2 As TimeSpan = MyTimeSpanParse(DutyHours)
                    Dim ts3 As TimeSpan = MyTimeSpanParse(DeadHeadDuty)

                    Dim tsSum As TimeSpan = ts1 + ts2 + ts3

                    Update = True
                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.DutyHours = CheckForDays(tsSum.ToString)
                    Aims.Sectors = CInt(Aims.Sectors) + CInt(Sectors) + CInt(DeadHeadSectors)
                    Aims.FlightHours = "00:00:00"
                End If

                If Not Aims.Save(Update) Then
                    Throw Exx
                End If


            Loop


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''                  PILOTS                             '''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Counter = 0
            param_file.Close()
            param_file = IO.File.OpenText(Me.txtPLFile.Text)
            Do While param_file.Peek <> -1
                Application.DoEvents()
                Me.Refresh()
                Dim Ar() As String
                Counter = Counter + 1
                F = Me.txtPLFile.Text

                Line = param_file.ReadLine()
                Ar = Line.Split("	")
                No = Ar(0)
                EmployeeName = Ar(1)
                DutyHours = Ar(7)
                Sectors = Ar(9)
                FlightHours = 0
                DeadHeadDuty = Ar(6)
                DeadHeadSectors = Ar(8)

                If DutyHours = "00:00" Then
                    DutyHours = "00:00:00"
                End If
                If DeadHeadDuty = "00:00" Then
                    DeadHeadDuty = "00:00:00"
                End If


                Dim Aims As New cAIMS(No)
                Dim Update As Boolean = False
               

                If Aims.No = "" Then

                    Dim ts2 As TimeSpan = MyTimeSpanParse(DutyHours)
                    Dim ts3 As TimeSpan = MyTimeSpanParse(DeadHeadDuty)

                    Dim tsSum As TimeSpan = ts2 + ts3
                    'Dim tsSum2 As String = AddTimeSpan(ts2.ToString, ts3.ToString)
                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.DutyHours = CheckForDays(tsSum.ToString)
                    Aims.Sectors = CInt(Sectors) + CInt(DeadHeadSectors)
                    Aims.FlightHours = "00:00:00"
                Else
                    Dim ts1 As TimeSpan = MyTimeSpanParse(Aims.DutyHours)
                    Dim ts2 As TimeSpan = MyTimeSpanParse(DutyHours)
                    Dim ts3 As TimeSpan = MyTimeSpanParse(DeadHeadDuty)
                    Dim tsSum As TimeSpan = ts1 + ts2 + ts3
                    Update = True
                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.DutyHours = CheckForDays(tsSum.ToString)
                    Aims.Sectors = CInt(Aims.Sectors) + CInt(Sectors) + CInt(DeadHeadSectors)
                    Aims.FlightHours = "00:00:00"
                End If

                If Not Aims.Save(Update) Then
                    Throw Exx
                End If


            Loop
            param_file.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''                 FLIGHT HOURS                             ''''''''''''''''''''''''''''''''' 
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            param_file = IO.File.OpenText(Me.txtPLFlight.Text)
            Counter = 0
            Do While param_file.Peek <> -1
                Application.DoEvents()
                Me.Refresh()
                Dim Ar() As String
                Counter = Counter + 1
                F = Me.txtPLFlight.Text
                Line = param_file.ReadLine()
                Ar = Line.Split("	")
                No = Ar(0)
                EmployeeName = Ar(1)
                DutyHours = "00:00:00"
                Sectors = 0
                FlightHours = Ar(10)


                If FlightHours = "00:00" Then
                    FlightHours = "00:00:00"
                End If


                Dim Aims As New cAIMS(No)

                Dim Update As Boolean = False
                
                If Aims.No = "" Then
                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.DutyHours = DutyHours
                    Aims.Sectors = CInt(Sectors)
                    Aims.FlightHours = FlightHours
                Else
                    Update = True
                    Dim ts1 As TimeSpan = MyTimeSpanParse(Aims.FlightHours)
                    Dim ts2 As TimeSpan = MyTimeSpanParse(FlightHours)
                    Dim tsSum As TimeSpan = ts1 + ts2
                    ' Dim tsSum2 As String = AddTimeSpan(ts1.ToString, ts2.ToString)
                    Aims.No = No
                    Aims.Employee = EmployeeName
                    Aims.FlightHours = CheckForDays(tsSum.ToString)
                End If

                If Not Aims.Save(Update) Then
                    Throw Exx
                End If


            Loop
            param_file.Close()
            MsgBox("Data are uploaded Succesfully", MsgBoxStyle.Information)

            ShowDataOnExcel()

        Catch ex As Exception
            MsgBox("Error in file " & F & " in Line " & Counter, MsgBoxStyle.Critical)
            Utils.ShowException(ex)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Private Function MyTimeSpanParse(ByVal TimeSpan As String) As TimeSpan
        Dim T() As String
        Dim Hours As String
        Dim Minutes As String
        Dim Seconds As String
        T = TimeSpan.Split(":")
        Hours = T(0)
        Minutes = T(1)
        If T.Length = 2 Then
            Seconds = "00"
        Else
            Seconds = T(2)
        End If
        Dim Ts As New TimeSpan(Hours, Minutes, Seconds)
        Return Ts

    End Function
    'Private Function AddTimeSpan(ByVal T1 As String, ByVal T2 As String) As String
    '    Dim TT1() As String
    '    Dim TT2() As String
    '    TT1 = T1.Split(":")
    '    TT2 = T2.Split(":")
    '    Dim H3 As Integer
    '    Dim M3 As Integer
    '    Dim S3 As Integer

    '    Dim H1 As Integer = TT1(0)
    '    Dim M1 As Integer = TT1(1)
    '    Dim S1 As Integer = TT1(2)

    '    Dim H2 As Integer = TT2(0)
    '    Dim M2 As Integer = TT2(1)
    '    Dim S2 As Integer = TT2(2)

    '    Dim SMod As Integer
    '    Dim MMod As Integer

    '    S3 = S1 + S2
    '    If S3 > 60 Then
    '        Dim ExtraM As Integer
    '        Dim D1 As Integer
    '        Dim D2 As Integer
    '        D1 = S3
    '        Dim N As Boolean = False
    '        Do While N = False
    '            D2 = D1 - 60
    '            If D2 <= 0 Then
    '                N = True
    '            Else
    '                extraM = extraM + 1
    '                S3 = D2
    '            End If
    '        Loop
    '        M1 = M1 + ExtraM
    '    End If
    '    M3 = M1 + M2
    '    If M3 > 60 Then
    '        Dim ExtraH As Integer
    '        Dim D1 As Integer
    '        Dim D2 As Integer
    '        D1 = M3
    '        Dim N As Boolean = False
    '        Do While N = False
    '            D2 = D1 - 60
    '            If D2 <= 0 Then
    '                N = True
    '            Else
    '                ExtraH = ExtraH + 1
    '                M3 = D2
    '            End If
    '        Loop
    '        H1 = H1 + ExtraH
    '    End If

    '    H3 = H1 + H2
    '    Dim Final As String
    '    Final = Format(H3, "00") & ":" & Format(M3, "00") & ":" & Format(S3, "00")

    '    Return Final

    'End Function
    Private Function CheckForDays(ByVal Timespan As String) As String
        Dim V As String
        Dim t() As String
        t = Timespan.Split(":")
        If t(0).Contains(".") Then
            Dim DH() As String
            Dim D As Integer
            Dim H As Integer
            DH = t(0).Split(".")
            H = DH(0) * 24
            H = H + CInt(DH(1))

            V = H & ":" & t(1) & ":" & t(2)

        Else
            V = Timespan
        End If
        Return V
    End Function
    Private Sub ShowDataOnExcel()

        Dim Ds As DataSet
        Ds = Global1.Business.getdataFromAIMS

        If CheckDataSet(Ds) Then
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            Dim i As Integer


            HeaderStr.Add("Emp Code")
            HeaderStr.Add("Emp Name")
            HeaderStr.Add("Sectors")
            HeaderStr.Add("Duty Hours")
            HeaderStr.Add("Flight Hours")

            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(15)
            HeaderSize.Add(20)
            HeaderSize.Add(20)


            Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)


        Else
            MsgBox("There are no Data to Show", MsgBoxStyle.Information)
        End If
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