Imports System.Data
Public Class FrmExelsysAuditReport
    Dim GLBDs As DataSet
    Private Sub FrmExelsysAuditReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CBExcludeLastUpdateField.Checked = True
        Me.RadioAll.Checked = True
        ComboBox1.SelectedIndex = 0
        Me.DateLastUpdate.Value = Now
        Loaddatagrid(0)
    End Sub
    Private Sub Loaddatagrid(TableIndex As Integer)
        If TableIndex = 0 Then
            Dim Ds As DataSet
            Dim Date1 As Date = Me.DateLastUpdate.Value.Date

            Dim ExceptNew As Boolean = False
            Dim OnlyNew As Boolean = False
            Dim ExceptLastUpdate As Boolean = False

            If CBExcludeLastUpdateField.CheckState = CheckState.Checked Then
                ExceptLastUpdate = True
            End If
            If RadioExceptNew.Checked Then
                    ExceptNew = True
                End If
                If RadioOnlyNew.Checked Then
                    OnlyNew = True
                End If


            GLBDs = Global1.Business.getexelsysaudit_Employee(Date1, ExceptNew, OnlyNew, ExceptLastUpdate)
            DG1.DataSource = GLBDs.Tables(0)
            If CheckDataSet(GLBDs) Then
                Me.lblCounter.Text = "# " & GLBDs.Tables(0).Rows.Count
            Else
                Me.lblCounter.Text = "# 0"
            End If
            Me.lblCounter.Text = GLBDs.Tables(0).Rows.Count
        Else
            Dim Ds As DataSet
            Dim Date1 As Date = Me.DateLastUpdate.Value.Date

            Dim ExceptNew As Boolean = False
            Dim OnlyNew As Boolean = False
            Dim ExceptLastUpdate As Boolean = False

            If CBExcludeLastUpdateField.CheckState = CheckState.Checked Then
                ExceptLastUpdate = True
            End If
            If RadioExceptNew.Checked Then
                ExceptNew = True
            End If
            If RadioOnlyNew.Checked Then
                OnlyNew = True
            End If


            GLBDs = Global1.Business.getexelsysaudit_Salary(Date1, ExceptNew, OnlyNew, ExceptLastUpdate)
            DG1.DataSource = GLBDs.Tables(0)
            If CheckDataSet(GLBDs) Then
                Me.lblCounter.Text = "# " & GLBDs.Tables(0).Rows.Count
            Else
                Me.lblCounter.Text = "# 0"
            End If
            Me.lblCounter.Text = GLBDs.Tables(0).Rows.Count
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Loaddatagrid(Me.ComboBox1.SelectedIndex)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataSetToExcel()

        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Code")
        HeaderStr.Add("Employee")
        HeaderStr.Add("UpdateDate")
        HeaderStr.Add("UpdatedBy")
        HeaderStr.Add("FieldName")
        HeaderStr.Add("OldValue")
        HeaderStr.Add("NewValue")
        HeaderSize.Add(12)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        Loader.LoadIntoExcel(GLBDs, HeaderStr, HeaderSize)
    End Sub
End Class