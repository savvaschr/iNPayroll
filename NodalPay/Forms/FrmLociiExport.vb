Public Class FrmLociiExport
 
    Dim Loading As Boolean = False
    Dim PerGroup As cPrMsPeriodGroups
    Dim TemGrp As cPrMsTemplateGroup
    Dim ExportFileDir As String
    Dim InitFile As Boolean = True

    Private Sub FrmLociiExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        LoadCombos()

        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("Reports", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            ExportFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing Bank File Parameter Section 'System' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Me.BtnExport.Enabled = False
        End If
    End Sub
    Private Sub LoadCombos()
        LoadPeriodGroup()
        LoadPeriods()
        ' LoadPeriodsTo()
        
        Dim Found As Boolean = True
        Dim i As Integer
        For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
            If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year Then
                found = True
                Me.cmbPeriodGroups.SelectedIndex = i
                Exit For
            End If
        Next
        If Not Found Then
            For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
                If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year - 1 Then
                    Found = True
                    Me.cmbPeriodGroups.SelectedIndex = i
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub LoadPeriodGroup()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer

        Dim ShowALLYears As Boolean = False
        If CBShowAllYears.CheckState = CheckState.Checked Then
            ShowALLYears = True
        Else
            ShowALLYears = False
        End If
        ds = Global1.Business.GetAllPrMsPeriodGroupsOfUser(Global1.UserName, ShowALLYears, Global1.GLBCurrentYear)

        With Me.cmbPeriodGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim PG As New cPrMsPeriodGroups(ds.Tables(0).Rows(i))
                    .Items.Add(PG)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub
    Private Sub LoadPeriods()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGroup.Code)
        With Me.CmbPeriod
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub
    Private Sub cmbPeriodGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriodGroups.SelectedIndexChanged
        Try
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            TemGrp = New cPrMsTemplateGroup(PerGroup.TemGrpCode)
            Me.TextBox1.Text = TemGrp.Code & " - " & TemGrp.DescriptionL
            LoadPeriods()
            ' LoadPeriodsTo()

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    'Private Sub LoadPeriodsTo()
    '    Loading = True
    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGroup.Code)
    '    With Me.cmbPeriodTo
    '        .BeginUpdate()
    '        .Items.Clear()
    '        If CheckDataSet(ds) Then
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
    '                .Items.Add(P)
    '            Next
    '        End If
    '        .EndUpdate()
    '        .SelectedIndex = 0
    '    End With
    '    Loading = False
    'End Sub
    Private Sub CBShowAllYears_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShowAllYears.CheckedChanged
        Me.LoadPeriodGroup()
    End Sub

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Try

        
            InitFile = True

            Dim TempGroupCode As String = ""
            TempGroupCode = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode
            Dim TempGroup As New cPrMsTemplateGroup(TempGroupCode)

            Dim Filename As String
            Dim PerCode As New cPrMsPeriodCodes
            PerCode = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)

            Filename = ExportFileDir & TempGroup.DescriptionL & "_" & PerCode.Code & ".txt"

            Dim Ds As DataSet
            Dim i As Integer
            Dim Line As String = ""
            Dim SEP As String = "|||"
            Dim Counter As Integer = 1

            Ds = Global1.Business.LociiExport_PrAnBanks
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnBanks" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnEmployeeAnalysis1
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeAnalysis1" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnEmployeeAnalysis2
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeAnalysis2" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnEmployeeAnalysis3
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeAnalysis3" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnEmployeeAnalysis4
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeAnalysis4" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            'Ds = Global1.Business.LociiExport_PrAnEmployeeAnalysis5
            'If CheckDataSet(Ds) Then
            '    For i = 0 To Ds.Tables(0).Rows.Count - 1
            '        Line = "PrAnEmployeeAnalysis5" & SEP
            '        Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
            '        Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
            '        Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
            '        Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3))
            '        Me.WriteToExportFile(Line, Filename)
            '        Counter = Counter + 1
            '    Next
            'End If
            Ds = Global1.Business.LociiExport_PrAnEmployeeCommunity
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeCommunity" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnEmployeePositions
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeePositions" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrAnMarritalStatus
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrAnEmployeeMarritalStatus" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrMsEmployees(TempGroupCode)

            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrMsEmployees" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(6)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(7)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(8)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(9)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(10)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(11)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(12)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(13)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(14)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(15)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(16)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(17)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(18)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(19)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(20)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(21)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(22)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(23)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(24)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(25)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(26)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(27)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(28)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(29)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(30)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(31)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(32)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(33))

                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If

            Ds = Global1.Business.LociiExport_PrMsTemplateContributions(TempGroupCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrMsTemplateContributions" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrMsTemplateDeductions(TempGroupCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrMsTemplateDeductions" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrMsTemplateEarnings(TempGroupCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrMsTemplateEarnings" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5))
                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If
            Ds = Global1.Business.LociiExport_PrTxTrxnHeader(TempGroupCode, PerCode.Code, PerCode.PrdGrpCode)

            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrTxTrxnHeader" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(6)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(7)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(8)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(9)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(10)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(11)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(12)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(13)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(14)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(15)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(16)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(17)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(18)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(19)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(20)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(21)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(22))

                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If

            Ds = Global1.Business.LociiExport_PrTxTrxnLines(TempGroupCode, PerCode.Code, PerCode.PrdGrpCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrTxTrxnLines" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(4)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(5)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(6))

                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If

            Ds = Global1.Business.LociiExport_PrTxEmployeeLeave(TempGroupCode, PerCode, PerCode.PrdGrpCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Line = "PrTxEmployeeLeave" & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(0)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(1)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(2)) & SEP
                    Line = Line & DbNullToString(Ds.Tables(0).Rows(i).Item(3)) 

                    Me.WriteToExportFile(Line, Filename)
                    Counter = Counter + 1
                Next
            End If

            Me.WriteToExportFile(Counter, Filename)
            MsgBox("File Exported in " & ExportFileDir & " with File Name " & Filename)
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unnable to Export File", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function WriteToExportFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String
            If fName = "" Then
                FileName = ExportFileDir & "Lociifile.TXT"
            Else
                FileName = fName
            End If
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

   
End Class