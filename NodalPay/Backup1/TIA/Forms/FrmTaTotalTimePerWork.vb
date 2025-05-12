Public Class FrmTaTotalTimePerWork
    Friend EmpCode As String
    Friend FromDate As Date
    Friend ToDate As Date
    Friend ForActual As Boolean
    Dim Ds As DataSet

    Private Sub FrmTaTotalTimePerWork_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.RadioWeek.Checked = True
        LoadDG()
    End Sub
    Private Sub LoadDG()

        ds = Global1.Business.GetTAReportForTotalTimePerWorkPerEmployeeForDates(EmpCode, DateFrom.Value.Date, DateTo.Value.Date, ForActual)
        Me.DG1.DataSource = ds.Tables(0)


    End Sub

    
    Private Sub RadioMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMonth.CheckedChanged
        If RadioMonth.Checked = True Then
            Dim Fdate As Date
            Dim tDate As Date
            Dim D As String
            D = Format(FromDate.Month, "00") & "/" & "01" & "/" & Format(FromDate.Year, "0000")
            Fdate = CDate(D)
            DateFrom.Value = Fdate
            Fdate = DateAdd(DateInterval.Month, 1, Fdate)
            DateTo.Value = DateAdd(DateInterval.Day, -1, Fdate)
            Me.DateFrom.Enabled = False
            Me.DateTo.Enabled = False
        End If
    End Sub

    Private Sub RadioWeek_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioWeek.CheckedChanged
        If RadioWeek.Checked = True Then
            Me.DateFrom.Value = FromDate
            Me.DateTo.Value = ToDate
            Me.DateFrom.Enabled = False
            Me.DateTo.Enabled = False
        End If

    End Sub

    Private Sub RadioDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDays.CheckedChanged
        If RadioDays.Checked = True Then
            Me.DateFrom.Enabled = True
            Me.DateTo.Enabled = True
            Me.DateFrom.Value = FromDate
            Me.DateTo.Value = FromDate
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.LoadDG()
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        LoadDataSetToExcel()
    End Sub
    Private Sub LoadDataSetToExcel()


        Dim HeaderStr As New ArrayList

        Dim HeaderSize As New ArrayList

        Dim Loader As New cExcelLoader

        If Not CheckDataSet(Ds) Then
            LoadDG()
            If Not CheckDataSet(Ds) Then
                MsgBox("No Results to Show", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If



        HeaderStr.Add("Name")

        HeaderStr.Add("Work Code")

        HeaderStr.Add("Work Description")

        HeaderStr.Add("Total")

        HeaderSize.Add(50)

        HeaderSize.Add(25)

        HeaderSize.Add(40)

        HeaderSize.Add(15)

        
        Loader.PrintFooter = Me.Text & " Printed At:" & Format(Now, "yyyy-MM-dd hh:mm:ss")
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
End Class