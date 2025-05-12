Public Class FrmLeaveTransactions
    Public MyDs As DataSet
    Public Per As cPrMsPeriodCodes
    Dim MyDs2 As DataSet
    Dim Dt1 As DataTable
    Dim LeaveTypes As cPrSsLeaveTypes
    Dim NewYear As Date
    Dim dsLeaveTypes As DataSet

    Private Sub FrmTxEmployeeAnnualLeave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LeaveCode As String
        Dim ds As DataSet
        ds = Global1.Business.GetParameter("Leave Type", "Annual Leave ID")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            LeaveCode = Par.Value1
        Else
            MsgBox("Annual Leave Parameter is missing", MsgBoxStyle.Critical)
            Me.TSBSave.Enabled = False
            Exit Sub
        End If
        LeaveTypes = New cPrSsLeaveTypes(LeaveCode)

        InitDataTable()
        InitDataGrid()

        LoadValuesIntoGrid()
        LoadLeaveTypes()
        LoadAction()
      
        Me.txtCurrentPeriod.Text = Format(Per.DateFrom, "yyyy-MM-dd") & " - " & Format(Per.DateTo, "yyyy-MM-dd")

        AddHandler txtunits.KeyPress, AddressOf NumericKeyPress
        AddHandler txtunits.Leave, AddressOf NumericOnLeave

    End Sub
    Private Sub LoadLeaveTypes()

        Dim i As Integer
        dsLeaveTypes = Global1.Business.AG_GetAllPrSsLeaveTypes
        If CheckDataSet(dsLeaveTypes) Then
            Dim LeaveType As New cPrSsLeaveTypes
            With Me.ComboType
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To dsLeaveTypes.Tables(0).Rows.Count - 1
                    LeaveType = New cPrSsLeaveTypes(DbNullToString(dsLeaveTypes.Tables(0).Rows(i).Item(0)))
                    .Items.Add(LeaveType)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadAction()

        Dim i As Integer

        With Me.ComboAction
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(Global1.AN_IncreaseCODE)
            .Items.Add(Global1.AN_DecreaseCODE)
            .SelectedIndex = 0
            .EndUpdate()
        End With

    End Sub
    Private Sub InitDataGrid()
        MyDs2 = New DataSet
        MyDs2.Tables.Add(Dt1)
        DG1.DataSource = MyDs2.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("LeaveUnits", System.Type.GetType("System.Double"))
        

    End Sub
    Private Sub LoadValuesIntoGrid()

        Dim FromDate As Date
        Dim ToDate As Date
        Dim Str As String = ""


        Dim i As Integer
        FromDate = CDate(Per.DateFrom.Year & "/" & "01/01")
        ToDate = CDate(Per.DateFrom.Year & "/" & "12/31")
        Dim EmpCode As String
        Dim EmpName As String
        Dim leaveunits As Double = 0
        Dim EOY As Double = 0

        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            EmpCode = MyDs.Tables(0).Rows(i).Item(2)
            EmpName = MyDs.Tables(0).Rows(i).Item(3)
            leaveunits = 0


            Dim r As DataRow
            r = Dt1.NewRow
            r(0) = EmpCode
            r(1) = EmpName
            r(2) = leaveunits

            Dt1.Rows.Add(r)
        Next




    End Sub

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        If CheckDataSet(MyDs2) Then
            'If MyDs2.Tables(0).Rows(e.RowIndex).Item(5) <> 0 Then
            ' If MyDs2.Tables(0).Rows(e.RowIndex).Item(4) <> 0 Then
            ' MsgBox("Carry forward For this Employee has already being Saved.Carry Forward Value will be set to Zero.")
            ' MyDs2.Tables(0).Rows(e.RowIndex).Item(4) = 0
            'End If
            'End If
        End If
    End Sub
    Private Sub DG1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG1.DataError
        Dim str As String
        Dim Column As Integer
        Dim Row As Integer
        Column = e.ColumnIndex
        Row = e.RowIndex
        str = e.Exception.Message.ToString
        Dim RowEmployee As String = ""
        Dim ColumnHeader As String = ""
        If CheckDataSet(MyDs2) Then
            RowEmployee = UCase(DbNullToString(MyDs2.Tables(0).Rows(Row).Item(1)))
            ColumnHeader = UCase(DG1.Columns(Column).HeaderText)
        End If

        If e.Exception.Message.ToString = "Input string was not in a correct format." Then
            MsgBox("Please enter a numeric Value in Column '" & ColumnHeader & "' (Column No." & Column & ") Of Employee '" & RowEmployee & "' (Row No." & Row + 1 & ")", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click


        Dim Ans As MsgBoxResult
        Ans = MsgBox("Please make sure that Leave Type and Action Selections are Correct !, Proceed with Saving ?", MsgBoxStyle.YesNoCancel)
        If Ans <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Dim Exx As New Exception
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If
        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            Try

                Global1.Business.BeginTransaction()

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1

                    'End Of Year
                    Dim PrTxEmployeeLeave As New cPrTxEmployeeLeave
                    With PrTxEmployeeLeave
                        .Id = 0
                        .EmpCode = MyDs2.Tables(0).Rows(i).Item(0)
                        .Status = AN_Approved
                        .Type = CType(Me.ComboType.SelectedItem, cPrSsLeaveTypes).Code
                        .ReqDate = Now.Date
                        .ProcDate = Now.Date
                        .FromDate = Me.DateFrom.Value.Date
                        .ToDate = Me.DateTo.Value.Date
                        .ProcBy = Global1.GLBUserId
                        .Units = MyDs2.Tables(0).Rows(i).Item(2)
                        .Action = Me.ComboAction.SelectedItem.ToString
                        .Comment = ""
                        .ApprovedBy = ""

                        If Not .Save() Then
                            Throw Exx
                        End If
                    End With
                Next
                Global1.Business.CommitTransaction()
                MsgBox("Changes Are Saved", MsgBoxStyle.Information)
                ReLoad()
            Catch ex As Exception
                Utils.ShowException(ex)
                Global1.Business.Rollback()
                MsgBox("Unable to Save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub ReLoad()
        MyDs2.Tables(0).Rows.Clear()
        LoadValuesIntoGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        If CheckDataSet(MyDs2) Then
            For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                MyDs2.Tables(0).Rows(i).Item(2) = Me.txtUnits.Text
            Next
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.ComboType.SelectedIndex = 0
        Me.ComboAction.SelectedIndex = 0
        UploadFromExcel_Hoch(0)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.ComboType.SelectedIndex = 0
        Me.ComboAction.SelectedIndex = 1
        UploadFromExcel_Hoch(1)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.ComboType.SelectedIndex = 2
        Me.ComboAction.SelectedIndex = 0
        UploadFromExcel_Hoch(2)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.ComboType.SelectedIndex = 0
        Me.ComboAction.SelectedIndex = 1
        UploadFromExcel_Hoch(3)
    End Sub
   
    Private Sub UploadFromExcel_Hoch(ByVal myIndex As Integer)
        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_ETFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_ETFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpCode As String


                Dim AL As String
                Dim SL As String

                Dim DBL_AL As Double
                Dim DBL_SL As Double


                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If
                Dim index As Integer
                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpCode = Ar(0).Replace("""", "")

                            index = 17 + myIndex
                            AL = Ar(index).Replace("""", "")
                            

                            If AL = "" Then
                                DBL_AL = 0
                            Else
                                DBL_AL = CDbl(AL)
                            End If



                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.Code = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs2.Tables(0).Rows.Count - 1
                                    If MyDs2.Tables(0).Rows(k).Item(0) = EmpCode Then
                                        MyDs2.Tables(0).Rows(k).Item(2) = DBL_AL
                                    End If
                                Next

                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()

                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Excel Template file Path is missing, please contact iNsoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    
   
  
End Class