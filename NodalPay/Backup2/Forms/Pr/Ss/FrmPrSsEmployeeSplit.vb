Public Class FrmPrSsEmployeeSplit
    Public GlbEmpCode As String
    Public EmpCode As String
    Public Employee As cPrMsEmployees
    Dim tPrssEmployeeSplit As New cPrSsEmployeeSplit
    Dim DG1Changing As Boolean = False
    Dim GLBCode As String = ""
    Dim tEffDate As Date = Now
    Private Sub frmPrSsEmployeeSplit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        Me.LoadDataFromDG1(0)
        'CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                TSBSave.Enabled = False
                Me.TSBDelete.Enabled = False
            End If
        End If

    End Sub
    Private Sub Initialize()
        LoadCombos()

        ClearMe()
        PutDecimalValidationOnTxts()

    End Sub
    
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        If Me.txtDesc.Text = "" Then
            Flag = False
            MsgBox("Description Field is Required", MsgBoxStyle.Critical)
        End If
       
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.txtDesc.Text = ""
        Me.txtValue.Text = "0.00"
        Me.cbIsEnabled.Checked = True
        Me.cbIsPF.Checked = True
        Me.cbIsSP.Checked = True

        Try
            Dim U As New cAaSsUsers(Global1.GLBUserId)
            Me.txtCreatedUser.Text = U.UserName
            Me.txtAmendUser.Text = U.UserName
            Me.DateAmend.Value = Now.Date
            Me.DateCreated.Value = Now.Date
        Catch ex As Exception

        End Try

    End Sub
    '
    Private Sub LoadCombos()
        LoadPeriods()
        LoadActivePeriods()
    End Sub
  
    Private Sub LoadPeriods()
        With Me.ComboPeriods
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .Items.Add("6")
            .Items.Add("7")
            .Items.Add("8")
            .Items.Add("9")
            .Items.Add("10")
            .Items.Add("11")
            .Items.Add("12")
            .Items.Add("13")
            '.Items.Add("14")
            .SelectedIndex = 0
            .EndUpdate()
        End With

    End Sub
    Private Sub LoadActivePeriods()
        With Me.ComboActivePeriods
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("12")
            .Items.Add("13")
            '.Items.Add("14")
            .SelectedIndex = 0
            .EndUpdate()
        End With

    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtValue.KeyPress, AddressOf NumericKeyPress
        AddHandler txtValue.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
     
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtDesc.Focus()
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
    Private Sub TryToSave(Optional ByVal SupressMsg As Boolean = False)
        If ValidateMe() Then
            Dim Update As Boolean = False
            'Dim CS As Integer
            tPrssEmployeeSplit = New cPrSsEmployeeSplit(NullToInt(Me.txtId.Text))
            Try

                With tPrssEmployeeSplit
                    .id = NullToInt(Me.txtId.Text)
                    .EmpCode = EmpCode
                    .Description = Me.txtDesc.Text
                    .myValue = Me.txtValue.Text
                    If Me.cbIsEnabled.Checked Then
                        .Enabled = "Y"
                    Else
                        .Enabled = "N"
                    End If
                    If Me.cbIsPF.Checked Then
                        .IsPF = "Y"
                    Else
                        .IsPF = "N"
                    End If
                    If Me.cbIsSP.Checked Then
                        .IsST = "Y"
                    Else
                        .IsST = "N"
                    End If
                    .NoOfPeriods = Me.ComboPeriods.SelectedItem.ToString
                    .ActivePeriods = Me.ComboPeriods.SelectedItem.ToString
                    If .id = 0 Then
                        .CreatedBy = Global1.GLBUserId
                        .CreationDate = Now.Date
                        .AmendedBy = Global1.GLBUserId
                        .AmendDate = Now.Date
                    Else
                        .CreatedBy = Global1.GLBUserId
                        .CreationDate = Now.Date
                        .AmendedBy = Global1.GLBUserId
                        .AmendDate = Now.Date
                    End If
                    

                    If .Save() Then
                        MsgBox("Changes are successfully Saved", MsgBoxStyle.Information)
                        FillDG1()
                        FindWhereToSelect(.id)
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
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader
        'ds = Global1.Business.AG_GetAllPrTxEmployeeSalary()
        ds = Global1.Business.GetAllPrSsEmployeeSplitByEmpCode(EmpCode)
        HeaderStr.Add("id")
        HeaderStr.Add("Employee Code")
        HeaderStr.Add("Description")
        HeaderStr.Add("Value")
        HeaderStr.Add("Is Enabled")
        HeaderStr.Add("Provident fund Ded/Con")
        HeaderStr.Add("Special Tax Ded/Con")
        HeaderStr.Add("No Of Periods")
        HeaderStr.Add("Created By")
        HeaderStr.Add("Creation Date")
        HeaderStr.Add("Amended By")
        HeaderStr.Add("Amendmend Date")
        HeaderSize.Add(15)
        HeaderSize.Add(16)
        HeaderSize.Add(40)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrSsEmployeeSplit(ByVal tId As Integer)
        tPrssEmployeeSplit = New cPrSsEmployeeSplit(tId)
        If tPrssEmployeeSplit.id <> 0 Then
            With tPrssEmployeeSplit
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.id)
                Me.txtDesc.Text = .Description
                Me.txtValue.Text = Format(.myValue, "0.00")
                If .Enabled = "Y" Then
                    Me.cbIsEnabled.Checked = True
                Else
                    Me.cbIsEnabled.Checked = False
                End If
                If .IsPF = "Y" Then
                    Me.cbIsPF.Checked = True
                Else
                    Me.cbIsPF.Checked = False
                End If
                If .IsST = "Y" Then
                    Me.cbIsSP.Checked = True
                Else
                    Me.cbIsSP.Checked = False
                End If
                Me.ComboPeriods.SelectedIndex = Me.ComboPeriods.FindStringExact(.NoOfPeriods)
                Me.ComboActivePeriods.SelectedIndex = Me.ComboPeriods.FindStringExact(.ActivePeriods)

                Dim User1 As New cAaSsUsers(.CreatedBy)
                Me.txtCreatedUser.Text = User1.UserName

                Me.DateCreated.Value = .CreationDate

                Dim User2 As New cAaSsUsers(.AmendedBy)
                Me.txtAmendUser.Text = User2.UserName

                Me.DateAmend.Value = .AmendDate


                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrSsEmployeeSplitByEmpCode(EmpCode)
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        Dim total As Double = 0
        If CheckDataSet(ds) Then
            Dim i As Integer

            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(4)) = "Y" Then
                    total = total + DbNullToDouble(ds.Tables(0).Rows(i).Item(3))
                End If

            Next
        End If
        Me.txtPeriodTotal.Text = Format(total, "0.00")
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
            If tPrssEmployeeSplit.Delete(CInt(Trim(Me.txtId.Text))) Then
                MsgBox("Record has been deleted", MsgBoxStyle.Information)
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
        Call ClearErrors()

        If Me.DG1.RowCount > 0 Then
            Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtDesc.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.txtValue.Text = DbNullToDouble(DG1.Item(3, i).Value)
            If DbNullToString(DG1.Item(4, i).Value) = "Y" Then
                Me.cbIsEnabled.Checked = True
            Else
                Me.cbIsEnabled.Checked = False
            End If

            Me.ComboPeriods.SelectedIndex = Me.ComboPeriods.FindStringExact(DbNullToString(DG1.Item(5, i).Value))
            Me.ComboActivePeriods.SelectedIndex = Me.ComboActivePeriods.FindStringExact(DbNullToString(DG1.Item(12, i).Value))

            If DbNullToString(DG1.Item(6, i).Value) = "Y" Then
                Me.cbIsPF.Checked = True
            Else
                Me.cbIsPF.Checked = False
            End If
            If DbNullToString(DG1.Item(7, i).Value) = "Y" Then
                Me.cbIsSP.Checked = True
            Else
                Me.cbIsSP.Checked = False
            End If

            Me.DateCreated.Value = DbNullToDate(DG1.Item(8, i).Value)
            Dim U1 As New cAaSsUsers(DbNullToInt(DG1.Item(9, i).Value))
            Me.txtCreatedUser.Text = U1.UserName


            Me.DateAmend.Value = DbNullToDate(DG1.Item(10, i).Value)
            Dim U2 As New cAaSsUsers(DbNullToInt(DG1.Item(11, i).Value))
            Me.txtAmendUser.Text = U2.UserName


          
        End If



        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

  
   

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To Me.DG1.RowCount - 1
            If DbNullToString(DG1.Item(0, i).Value) = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(2)
                LoadDataFromDG1(i)
                Exit Sub
            End If
        Next

    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To Me.DG1.RowCount - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub

   
  
    
  
  
   

End Class