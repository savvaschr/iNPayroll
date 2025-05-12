Public Class FrmPrMsReminder

    Public EmpCode As String
    Public Employee As cPrMsEmployees
    Dim tPrMsReminder As New cPrMsReminders
    Dim DG1Changing As Boolean = False

    Dim MyDs As DataSet

    Private Sub FrmPrMsReminder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe()
    End Sub
    Public Sub LoadMe()
        Me.txtEmployeeCode.Text = Employee.Code
        Me.txtEmployeeName.Text = Employee.FullName

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        If CheckDataSet(MyDs) Then
            LoadDataFromDG1(0)
        End If
    End Sub

    Private Sub Initialize()
        ClearMe()

    End Sub
    Private Function ValidateMe() As Boolean
        Dim Flag As Boolean = True
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.DateReq.Value = Now.Date
        Me.CBIsActive.Checked = True
        Me.txtNotes.Text = ""
        Me.txtCreatedBy.Text = Global1.UserName
        Me.txtCreatedAt.Text = Format(Now.Date, "yyyy-MM-dd")
        Me.txtDeactivatedBy.Text = ""
        Me.txtDeactivatedAt.Text = ""
    End Sub
    '
   
   
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsReminder = New cPrMsReminders
        ClearMe()
        Me.TSBNew.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Me.TSBSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        TryToSave()
        Me.TSBSave.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TryToSave()
        If ValidateMe() Then

            Dim Update As Boolean = False
            Try
                With tPrMsReminder
                    .Id = NullToInt(Me.txtId.Text)
                    .EmpCode = EmpCode
                    .ReminderDate = Me.DateReq.Value.Date
                    If .Id = 0 Then
                        .CreatedBy = Global1.UserName
                        .CreatedAt = Now.Date
                        .IsActive = "Y"
                        .DeactivatedBy = ""
                        .DeactivatedAt = CDate("1900-01-01")
                    End If
                    If Me.CBIsActive.CheckState = CheckState.Unchecked Then
                        .DeactivatedBy = Global1.UserName
                        .DeactivatedAt = Now.Date
                        .IsActive = "N"
                    Else
                        .DeactivatedBy = ""
                        .DeactivatedAt = CDate("1900-01-01")
                        .IsActive = "Y"
                    End If
                    .Description = Me.txtNotes.Text

                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        FillDG1()
                        FindWhereToSelect(.Id)
                        PKInputReadOnly(True)
                    Else
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
  
    '
    Private Sub LoadDataSetToExcel()
        'Dim ds As DataSet
        'Dim HeaderStr As New ArrayList
        'Dim HeaderSize As New ArrayList
        'Dim Loader As New cExcelLoader

        'ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(EmpCode)
        'HeaderStr.Add("id")
        'HeaderStr.Add("Employee Code")
        'HeaderStr.Add("Date")
        'HeaderStr.Add("Salary Value")
        'HeaderStr.Add("Basic Value")
        'HeaderStr.Add("Pay Date")
        'HeaderStr.Add("Cola Value")
        'HeaderStr.Add("Arrears Date")
        'HeaderStr.Add("User Id")
        'HeaderStr.Add("Is Cola Enabled")
        'HeaderSize.Add(15)
        'HeaderSize.Add(16)
        'HeaderSize.Add(12)
        'HeaderSize.Add(18)
        'HeaderSize.Add(18)
        'HeaderSize.Add(12)
        'HeaderSize.Add(18)
        'HeaderSize.Add(12)
        'HeaderSize.Add(15)
        'HeaderSize.Add(1)
        'Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeLeave(ByVal tId As Integer)
        tPrMsReminder = New cPrMsReminders(tId)
        If tPrMsReminder.Id <> 0 Then
            With tPrMsReminder
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.DateReq.Value = .ReminderDate
                If .IsActive = "Y" Then
                    CBIsActive.Checked = True
                Else
                    CBIsActive.Checked = False
                End If
                Me.txtNotes.Text = .Description
                Me.txtCreatedBy.Text = .CreatedBy
                Me.txtCreatedAt.Text = Format(.CreatedAt, "yyyy-MM-dd")
                If .DeactivatedAt = "1900-01-01" Then
                    Me.txtDeactivatedAt.Text = ""
                Else
                    Me.txtDeactivatedAt.Text = Format(.DeactivatedAt, "yyyy-MM-dd")
                End If
                Me.txtDeactivatedBy.Text = .DeactivatedBy
            End With
        End If
    End Sub
  
    Private Sub FillDG1()

        myds = Global1.Business.GetAllPrMsRemindersByEmpCode(EmpCode)
        DG1Changing = True
        Me.DG1.DataSource = myds.Tables(0)
        DG1Changing = False
    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        If DG1Changing = False Then
            Try
                Dim i As Integer
                i = DG1.CurrentRow.Index
                LoadDataFromDG1(i)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete record " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrMsReminder.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                FillDG1()
                Me.LoadDataFromDG1(0)
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe()

        Me.lblSSStatus.Text = ""
        If Me.DG1.RowCount > 0 Then

            Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
            LoadPrTxEmployeeLeave(CInt(Me.txtId.Text))
        End If



        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()
        If CheckDataSet(myds) Then
            For i = 0 To Me.myds.tables(0).rows.count - 1
                If DbNullToString(MyDs.Tables(0).Rows(i).Item(0)) = MapColumn Then
                    DG1.Rows(i).Selected = True
                    DG1.CurrentCell = DG1.Rows(i).Cells(3)
                    LoadDataFromDG1(i)
                    Exit Sub
                End If
            Next
        End If

    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To Me.DG1.RowCount - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub



    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnReminder(Me)
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnReminder(Me)
    End Sub


End Class