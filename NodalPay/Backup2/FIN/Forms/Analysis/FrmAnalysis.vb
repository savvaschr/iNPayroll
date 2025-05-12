Public Class FrmAnalysis

    Dim DoNotRun As Boolean = True
    Public Selected_Anal As Integer = 0
    Dim CurrentAnalysis
    Public AnalysisChoice As Integer

    Dim MyDs As DataSet
    Dim Dt1 As DataTable
    Dim CurrentRow As Integer

    Dim Column_Code As Integer = 0
    Dim Column_Code2 As Integer = 1
    Dim Column_DescriptionL As Integer = 2
    Dim Column_DescriptionS As Integer = 3
    Dim Column_CreationDate As Integer = 4
    Dim Column_AmendDate As Integer = 5
    Dim Column_IsActive As Integer = 6

    Private Sub FrmAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DoNotRun = True
        Me.Top = 0
        Me.Left = 0
        LoadTabForLevel1()
        LoadTabLevel2()
        LoadTabLevel3()
        DoNotRun = False
    End Sub


#Region "Level1 code"

    Private Sub LoadTabForLevel1()
        InitDataTable()
        InitAnalysis()
        Me.TxtLevelCode.Enabled = False
        Me.CmbIsActive.SelectedIndex = 0
        CmbAnalysis.SelectedIndex = 0
        LoadAnalysis1()
        InitDataGrid()
        clearFields()
    End Sub

    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("Code", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("Level Code", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("DescriptionL", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("DescriptionS", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Creation Date", System.Type.GetType("System.DateTime"))
        '5
        Dt1.Columns.Add("Amend Date", System.Type.GetType("System.DateTime"))
        '6
        Dt1.Columns.Add("Is Active", System.Type.GetType("System.String"))

    End Sub

    Private Sub InitAnalysis()
        Dim i As Integer
        Dim name As String
        If AnalysisChoice = 0 Then
            name = "Account Analysis"
            For i = 1 To 10
                name = name & i.ToString
                Me.CmbAnalysis.Items.Add(name)
                name = "Account Analysis"
            Next
        ElseIf AnalysisChoice = 1 Then
            name = "Account Line Analysis"
            For i = 1 To 10
                name = name & i.ToString
                Me.CmbAnalysis.Items.Add(name)
                name = "Account Line Analysis"
            Next
        End If
    End Sub

    Private Sub LoadAnalysis(ByVal dt As DataRow, ByVal i As Integer)
        Dim r As DataRow = Dt1.NewRow()
        With dt
            If Me.CmbAnalysis.SelectedIndex = 0 Then
                r(Me.Column_Code) = .Item(0)
                r(Me.Column_Code2) = .Item(1)
                r(Me.Column_DescriptionL) = .Item(2)
                r(Me.Column_DescriptionS) = .Item(3)
                r(Me.Column_CreationDate) = .Item(4)
                r(Me.Column_AmendDate) = .Item(5)
                r(Me.Column_IsActive) = .Item(6)
                'If String.Compare(.Item(6), "A") = 0 Then
                '    r(Me.Column_IsActive) = "YES"
                'Else
                '    r(Me.Column_IsActive) = "NO"
                'End If
            Else
                r(Me.Column_Code) = .Item(0)
                r(Me.Column_DescriptionL) = .Item(1)
                r(Me.Column_DescriptionS) = .Item(2)
                r(Me.Column_CreationDate) = .Item(3)
                r(Me.Column_AmendDate) = .Item(4)
                r(Me.Column_IsActive) = .Item(5)
                'If String.Compare(.Item(5), "A") = 0 Then
                '    r(Me.Column_IsActive) = "YES"
                'Else
                '    r(Me.Column_IsActive) = "NO"
                'End If
            End If
        End With
        Dt1.Rows.Add(r)
    End Sub

    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)

    End Sub

    Public Sub LoadCode(ByVal code As String)
        If Me.TabAnalysis.SelectedIndex = 0 Then
            Me.TxtLevelCode.Text = code
        ElseIf Me.TabAnalysis.SelectedIndex = 1 Then
            Me.TxtLevelCodeLevel2.Text = code
        End If

    End Sub

    Private Sub LoadAnalysis1()
        Me.RenewGrid(0)
    End Sub

    Private Sub RenewGrid(ByVal selected_analysis As Integer)
        Dim Ds As DataSet
        Dim i As Integer

        If Me.Dt1.Rows.Count > 0 Then
            Dt1.Clear()
        End If
        Selected_Anal = Me.CmbAnalysis.SelectedIndex + 1

        If AnalysisChoice = 0 Then
            Ds = Global1.Business.GetAllAccountAnalysisLevel1(Selected_Anal, False)
        Else
            Ds = Global1.Business.GetAllAccountLineAnalysisLevel1(Selected_Anal, False)
        End If

        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                LoadAnalysis(Ds.Tables(0).Rows(i), i)
            Next
            Dim d As Integer = DG1.Columns.Count
            If Me.CmbAnalysis.SelectedIndex = 0 Then
                Dim x As Integer = DG1.Columns.Count
                Me.DG1.Columns(Column_Code2).Visible = True
            Else
                Me.DG1.Columns(Column_Code2).Visible = False
            End If
        End If
    End Sub

    Private Sub PointLastUpdate(ByVal code As String)
        Dim i As Integer = 0

        For i = 0 To DG1.RowCount - 1
            If code = DG1.Item(0, i).Value Then
                DG1.Rows(0).Selected = False
                DG1.Rows(i).Selected = True
                LoadFromDG1(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub DG1_CurrentCellChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        Dim i As Integer = -1
        If DoNotRun Then Exit Sub
        Try
            i = Me.DG1.CurrentRow.Index
            If i >= 0 Then
                LoadFromDG1(i)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromDG1(ByVal i As Integer)
        clearErrors()
        Dim currentAnalysis1 As New Object
        Try
            If DoNotRun Then Exit Sub
            'Dim i As Integer

            'i = DG1.CurrentRow.Index
            Dim Code As String
            Code = DG1.Item(0, i).Value
            If AnalysisChoice = 0 Then
                If Me.CmbAnalysis.SelectedIndex = 0 Then
                    currentAnalysis1 = New cAccountAnal1(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 1 Then
                    currentAnalysis1 = New cAccountAnal2(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 2 Then
                    currentAnalysis1 = New cAccountAnal3(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 3 Then
                    currentAnalysis1 = New cAccountAnal4(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 4 Then
                    currentAnalysis1 = New cAccountAnal5(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 5 Then
                    currentAnalysis1 = New cAccountAnal6(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 6 Then
                    currentAnalysis1 = New cAccountAnal7(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 7 Then
                    currentAnalysis1 = New cAccountAnal8(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 8 Then
                    currentAnalysis1 = New cAccountAnal9(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 9 Then
                    currentAnalysis1 = New cAccountAnal10(Code)
                End If
            Else
                If Me.CmbAnalysis.SelectedIndex = 0 Then
                    currentAnalysis1 = New cAccountLineAnal1(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 1 Then
                    currentAnalysis1 = New cAccountLineAnal2(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 2 Then
                    currentAnalysis1 = New cAccountLineAnal3(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 3 Then
                    currentAnalysis1 = New cAccountLineAnal4(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 4 Then
                    currentAnalysis1 = New cAccountLineAnal5(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 5 Then
                    currentAnalysis1 = New cAccountLineAnal6(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 6 Then
                    currentAnalysis1 = New cAccountLineAnal7(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 7 Then
                    currentAnalysis1 = New cAccountLineAnal8(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 8 Then
                    currentAnalysis1 = New cAccountLineAnal9(Code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 9 Then
                    currentAnalysis1 = New cAccountLineAnal10(Code)
                End If
            End If
            If currentAnalysis1.code <> "" Then
                With currentAnalysis1
                    Me.TxtCode.BackColor = SystemColors.Info
                    Me.TxtCode.Enabled = False
                    Me.TxtCode.Text = DbNullToString(.code)
                    If Me.CmbAnalysis.SelectedIndex = 0 Then
                        Me.TxtLevelCode.Text = DbNullToString(.code2)
                    End If
                    Me.TxtDescription.Text = DbNullToString(.DescriptionL)
                    Me.txtDescriptionS.Text = DbNullToString(.DescriptionS)
                    DTPCreationDate.Text = DbNullToDate(.CreationDate)
                    DTPAmendDate.Text = DbNullToDate(.AmendDate)
                    If .IsActive = "A" Then
                        Me.CmbIsActive.SelectedIndex = 0
                    Else
                        Me.CmbIsActive.SelectedIndex = 1
                    End If
                End With

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TryToSave()
    End Sub

    Private Sub TryToSave()
        Dim code As String = TxtCode.Text
        Dim CurrentAnalysis1 As New Object
        If ValidateBeforeSaving() Then
            If AnalysisChoice = 0 Then
                If Me.CmbAnalysis.SelectedIndex = 0 Then
                    CurrentAnalysis1 = New cAccountAnal1(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 1 Then
                    CurrentAnalysis1 = New cAccountAnal2(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 2 Then
                    CurrentAnalysis1 = New cAccountAnal3(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 3 Then
                    CurrentAnalysis1 = New cAccountAnal4(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 4 Then
                    CurrentAnalysis1 = New cAccountAnal5(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 5 Then
                    CurrentAnalysis1 = New cAccountAnal6(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 6 Then
                    CurrentAnalysis1 = New cAccountAnal7(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 7 Then
                    CurrentAnalysis1 = New cAccountAnal8(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 8 Then
                    CurrentAnalysis1 = New cAccountAnal9(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 9 Then
                    CurrentAnalysis1 = New cAccountAnal10(code)
                End If
            Else
                If Me.CmbAnalysis.SelectedIndex = 0 Then
                    CurrentAnalysis1 = New cAccountLineAnal1(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 1 Then
                    CurrentAnalysis1 = New cAccountLineAnal2(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 2 Then
                    CurrentAnalysis1 = New cAccountLineAnal3(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 3 Then
                    CurrentAnalysis1 = New cAccountLineAnal4(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 4 Then
                    CurrentAnalysis1 = New cAccountLineAnal5(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 5 Then
                    CurrentAnalysis1 = New cAccountLineAnal6(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 6 Then
                    CurrentAnalysis1 = New cAccountLineAnal7(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 7 Then
                    CurrentAnalysis1 = New cAccountLineAnal8(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 8 Then
                    CurrentAnalysis1 = New cAccountLineAnal9(code)
                ElseIf Me.CmbAnalysis.SelectedIndex = 9 Then
                    CurrentAnalysis1 = New cAccountLineAnal10(code)
                End If
            End If

            With CurrentAnalysis1
                If .code <> "" And Not Me.TxtCode.Enabled Then
                    .code = Me.TxtCode.Text
                    If Me.CmbAnalysis.SelectedIndex = 0 Then
                        .code2 = Me.TxtLevelCode.Text
                    End If
                    .DescriptionL = Me.TxtDescription.Text
                    .DescriptionS = Me.txtDescriptionS.Text
                    .AmendDate = Now.Date
                    If Me.CmbIsActive.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    If .save(False) Then
                        MsgBox("Succesfull Update", MsgBoxStyle.Information)
                        Me.TxtCode.Enabled = False
                        Me.RenewGrid(Me.CmbAnalysis.SelectedIndex)
                        PointLastUpdate(code)
                    Else

                        MsgBox("Failed to Update", MsgBoxStyle.Critical)
                    End If
                ElseIf CurrentAnalysis1.code = "" Then
                    .code = Me.TxtCode.Text
                    If Me.CmbAnalysis.SelectedIndex = 0 Then
                        .code2 = Me.TxtLevelCode.Text
                    End If
                    .DescriptionL = Me.TxtDescription.Text
                    .DescriptionS = Me.txtDescriptionS.Text
                    .CreationDate = Now.Date
                    .AmendDate = Now.Date
                    If Me.CmbIsActive.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    If .save(True) Then
                        MsgBox("Succesfull Safe", MsgBoxStyle.Information)
                        Me.TxtCode.Enabled = False
                        Me.RenewGrid(Me.CmbAnalysis.SelectedIndex)
                        PointLastUpdate(code)
                    Else

                        MsgBox("Failed to Save", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("This entry allready exist")
                    Me.TxtCode.Text = ""
                    Exit Sub
                End If

            End With
        End If
    End Sub

    Private Function ValidateBeforeSaving() As Boolean
        clearErrors()
        Dim flag As Boolean = True
        If Me.TxtCode.Text = "" Then
            flag = False
            Er1.SetError(Me.TxtCode, "Code Field is Required")
            'Else
            '    If Not IsNumeric(Me.TxtCode.Text) Then
            '        flag = False
            '        Er1.SetError(Me.TxtCode, "Code Field can be only Numeric")
            'End If
        End If
        If Me.TxtDescription.Text = "" Then
            flag = False
            Er2.SetError(Me.TxtDescription, "Description Field is Required")
        End If
        If Me.CmbAnalysis.SelectedIndex = 0 Then
            If Me.TxtLevelCode.Text = "" Then
                flag = False
                Me.ErrLevelCode.SetError(Me.TxtLevelCode, "Level code Field is Required")
            End If
        End If
        Return flag
    End Function

    Private Sub clearErrors()
        Er1.SetError(TxtCode, "")
        Er2.SetError(Me.TxtDescription, "")
        ErrLevelCode.SetError(Me.TxtLevelCode, "")
    End Sub

    Private Sub BtnNew_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        clearFields()
    End Sub

    Private Sub clearFields()
        clearErrors()
        Me.TxtCode.Text = ""
        Me.TxtLevelCode.Text = ""
        Me.TxtCode.BackColor = SystemColors.Window
        Me.TxtCode.Enabled = True
        Me.TxtDescription.Text = ""
        Me.txtDescriptionS.Text = ""
        Me.DTPAmendDate.Value = Now.Date
        Me.DTPCreationDate.Value = Now.Date
        Me.CmbIsActive.SelectedIndex = 0
    End Sub

    Private Sub CmbAnalysis_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAnalysis.SelectedIndexChanged
        clearFields()
        'If DoNotRun = True Then
        '    Exit Sub
        'End If
        Me.RenewGrid(CmbAnalysis.SelectedIndex)
        If Me.CmbAnalysis.SelectedIndex <> 0 Then
            Me.BtnSearch.Enabled = False
        Else
            Me.BtnSearch.Enabled = True
        End If
        Me.Selected_Anal = Me.CmbAnalysis.SelectedIndex
        AnalysisChoice = Me.CmbAnalysis.SelectedIndex
    End Sub

    Private Sub BtnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Dim f As New FrmSearchAnalysisLevel
        f.AnalysisChoice = AnalysisChoice
        f.LevelChoice = 0
        f.Owner = Me
        f.ShowDialog()
    End Sub

#End Region

#Region "Level2 code"
    Dim DsLevel2 As DataSet

    Private Sub LoadTabLevel2()
        LoadDataGridLevel2()
        clearFieldsLevel2()
    End Sub

    Private Sub RenewGridForLevel2()
        LoadDataGridLevel2()
    End Sub

    Private Sub LoadDataGridLevel2()

        If AnalysisChoice = 0 Then
            DsLevel2 = Global1.Business.GetAllAccountAnalysisLevel2(False)
            DgAnalysisLevel2.DataSource = DsLevel2.Tables(0)
            DgAnalysisLinesLevel2.Visible = False

            'For i = 0 To (DsLevel2.Tables(0).Rows.Count - 1)
            '    If String.Compare(DsLevel2.Tables(0).Rows(i).Item(6).ToString, "A") = 0 Then
            '        DgAnalysisLevel2.Item(6, i).Value = "YES"
            '    Else
            '        DgAnalysisLevel2.Item(6, i).Value = "NO"
            '    End If
            'Next
        Else
            DsLevel2 = Global1.Business.GetAllAccountLineAnalysisLevel2(False)
            DgAnalysisLinesLevel2.DataSource = DsLevel2.Tables(0)
            DgAnalysisLevel2.Visible = False

            'For i = 0 To (DsLevel2.Tables(0).Rows.Count - 1)
            '    If String.Compare(DsLevel2.Tables(0).Rows(i).Item(6).ToString, "A") = 0 Then
            '        DgAnalysisLinesLevel2.Item(6, i).Value = "YES"
            '    Else
            '        DgAnalysisLinesLevel2.Item(6, i).Value = "NO"
            '    End If
            'Next
        End If
    End Sub

    Private Sub BtnNewLevel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewLevel2.Click
        clearFieldsLevel2()
    End Sub

    Private Sub clearFieldsLevel2()
        clearErrorsForLevel2()
        Me.TxtCodeLevel2.Text = ""
        Me.TxtLevelCodeLevel2.Text = ""
        Me.TxtCodeLevel2.BackColor = SystemColors.Window
        Me.TxtCodeLevel2.Enabled = True
        Me.TxtDescLevel2.Text = ""
        Me.TxtDescSLevel2.Text = ""
        Me.DtpAmendDateLevel2.Value = Now.Date
        Me.DtpCreationDateLevel2.Value = Now.Date
        Me.CmbIsActiveLevel2.SelectedIndex = 0
    End Sub

    Private Function ValidateBeforeSavingForLevel2() As Boolean
        clearErrorsForLevel2()
        Dim flag As Boolean = True
        If Me.TxtCodeLevel2.Text = "" Then
            flag = False
            Me.ErrcodeLevel2.SetError(Me.TxtCodeLevel2, "Code Field is Required")
            'Else
            '    If Not IsNumeric(Me.TxtCodeLevel2.Text) Then
            '        flag = False
            '        Me.ErrcodeLevel2.SetError(Me.TxtCodeLevel2, "Code Field can be only Numeric")
            'End If
        End If
        If Me.TxtDescLevel2.Text = "" Then
            flag = False
            Me.ErrDescLevel2.SetError(Me.TxtDescLevel2, "Description Field is Required")
        End If
        If Me.TxtLevelCodeLevel2.Text = "" Then
            flag = False
            Me.ErrLevelCodeLevel2.SetError(Me.TxtLevelCodeLevel2, "Level code Field is Required")
        End If
        Return flag
    End Function

    Private Sub clearErrorsForLevel2()
        Me.ErrcodeLevel2.SetError(Me.TxtCodeLevel2, "")
        Me.ErrDescLevel2.SetError(Me.TxtDescLevel2, "")
        Me.ErrLevelCodeLevel2.SetError(Me.TxtLevelCodeLevel2, "")
    End Sub

    Private Sub BtnSaveLevel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveLevel2.Click
        TryToSaveLevel2()
    End Sub

    Private Sub TryToSaveLevel2()
        clearErrorsForLevel2()
        Dim code As String = Me.TxtCodeLevel2.Text
        Dim CurrentAnalysis1
        If ValidateBeforeSavingForLevel2() Then
            If AnalysisChoice = 0 Then
                CurrentAnalysis1 = New cAccountAnal1Level2(code)
            Else
                CurrentAnalysis1 = New cAccountLineAnal1Level2(code)
            End If
        Else
            Exit Sub
        End If

        With CurrentAnalysis1
            If .code <> "" And Not Me.TxtCodeLevel2.Enabled Then
                .code = Me.TxtCodeLevel2.Text
                .code2 = Me.TxtLevelCodeLevel2.Text
                .DescriptionL = Me.TxtDescLevel2.Text
                .DescriptionS = Me.TxtDescSLevel2.Text
                .AmendDate = Now.Date
                If Me.CmbIsActiveLevel2.SelectedIndex = 0 Then
                    .IsActive = "A"
                Else
                    .IsActive = "I"
                End If
                If .save(False) Then
                    MsgBox("Succesfull Update", MsgBoxStyle.Information)
                    Me.TxtCodeLevel2.Enabled = False
                    RenewGridForLevel2()
                    PointLastUpdateForLevel2(code)
                Else
                    MsgBox("Failed to Update", MsgBoxStyle.Critical)
                End If
            ElseIf CurrentAnalysis1.code = "" Then
                .code = Me.TxtCodeLevel2.Text
                .code2 = Me.TxtLevelCodeLevel2.Text
                .DescriptionL = Me.TxtDescLevel2.Text
                .DescriptionS = Me.TxtDescSLevel2.Text
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                If Me.CmbIsActiveLevel2.SelectedIndex = 0 Then
                    .IsActive = "A"
                Else
                    .IsActive = "I"
                End If
                If .save(True) Then
                    MsgBox("Succesfull Safe", MsgBoxStyle.Information)
                    Me.TxtCodeLevel2.Enabled = False
                    RenewGridForLevel2()
                    PointLastUpdateForLevel2(code)
                Else

                    MsgBox("Failed to Save", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("This entry allready exist")
                Me.TxtCodeLevel2.Text = ""
                Exit Sub
            End If

        End With
    End Sub

    Private Sub PointLastUpdateForLevel2(ByVal code As String)
        Dim i As Integer = 0
        If AnalysisChoice = 0 Then
            For i = 0 To DgAnalysisLevel2.RowCount - 1
                If code = DgAnalysisLevel2.Item(0, i).Value Then
                    DgAnalysisLevel2.Rows(0).Selected = False
                    DgAnalysisLevel2.Rows(i).Selected = True
                    LoadFromDgAnalysisLevel2(i)
                    Exit Sub
                End If
            Next i
        Else
            For i = 0 To DgAnalysisLinesLevel2.RowCount - 1
                If code = DgAnalysisLinesLevel2.Item(0, i).Value Then
                    DgAnalysisLinesLevel2.Rows(0).Selected = False
                    DgAnalysisLinesLevel2.Rows(i).Selected = True
                    LoadFromDgAnalysisLinesLevel2(i)
                    Exit Sub
                End If
            Next i
        End If
    End Sub

    Private Sub DgAnalysisLinesLevel2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgAnalysisLinesLevel2.CurrentCellChanged
        Dim i As Integer = -1
        If DoNotRun Then Exit Sub
        Try
            i = Me.DgAnalysisLinesLevel2.CurrentRow.Index
            If i >= 0 Then
                LoadFromDgAnalysisLinesLevel2(i)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromDgAnalysisLinesLevel2(ByVal i As Integer)
        clearErrorsForLevel2()
        Dim currentAnalysis1
        Try
            If DoNotRun Then Exit Sub 'na to elexw
            'Dim i As Integer
            'i = Me.DgAnalysisLinesLevel2.CurrentRow.Index
            Dim Code As String
            Code = DgAnalysisLinesLevel2.Item(0, i).Value
            currentAnalysis1 = New cAccountLineAnal1Level2(Code)

            If currentAnalysis1.code <> "" Then
                With currentAnalysis1
                    Me.TxtCodeLevel2.BackColor = SystemColors.Info
                    Me.TxtCodeLevel2.Enabled = False
                    Me.TxtCodeLevel2.Text = DbNullToString(.code)
                    Me.TxtLevelCodeLevel2.Text = DbNullToString(.code2)
                    Me.TxtDescLevel2.Text = DbNullToString(.DescriptionL)
                    Me.TxtDescSLevel2.Text = DbNullToString(.DescriptionS)
                    Me.DtpCreationDateLevel2.Text = DbNullToDate(.CreationDate)
                    Me.DtpAmendDateLevel2.Text = DbNullToDate(.AmendDate)
                    If .IsActive = "A" Then
                        Me.CmbIsActiveLevel2.SelectedIndex = 0
                    Else
                        Me.CmbIsActiveLevel2.SelectedIndex = 1
                    End If
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgAnalysisLevel2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgAnalysisLevel2.CurrentCellChanged
        Dim i As Integer = -1
        If DoNotRun Then Exit Sub
        Try
            i = Me.DgAnalysisLevel2.CurrentRow.Index
            If i >= 0 Then
                LoadFromDgAnalysisLevel2(i)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromDgAnalysisLevel2(ByVal i As Integer)
        clearErrorsForLevel2()
        Dim currentAnalysis1
        Try
            If DoNotRun Then Exit Sub 'na to elexw
            'Dim i As Integer
            'i = Me.DgAnalysisLevel2.CurrentRow.Index
            Dim Code As String
            Code = DgAnalysisLevel2.Item(0, i).Value
            currentAnalysis1 = New cAccountAnal1Level2(Code)

            If currentAnalysis1.code <> "" Then
                With currentAnalysis1
                    Me.TxtCodeLevel2.BackColor = SystemColors.Info
                    Me.TxtCodeLevel2.Enabled = False
                    Me.TxtCodeLevel2.Text = DbNullToString(.code)
                    Me.TxtLevelCodeLevel2.Text = DbNullToString(.code2)
                    Me.TxtDescLevel2.Text = DbNullToString(.DescriptionL)
                    Me.TxtDescSLevel2.Text = DbNullToString(.DescriptionS)
                    Me.DtpCreationDateLevel2.Text = DbNullToDate(.CreationDate)
                    Me.DtpAmendDateLevel2.Text = DbNullToDate(.AmendDate)
                    If .IsActive = "A" Then
                        Me.CmbIsActiveLevel2.SelectedIndex = 0
                    Else
                        Me.CmbIsActiveLevel2.SelectedIndex = 1
                    End If
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As New FrmSearchAnalysisLevel
        f.AnalysisChoice = AnalysisChoice
        f.LevelChoice = 1
        f.Owner = Me
        f.ShowDialog()
    End Sub

#End Region

#Region "Level3 code"
    Dim DsLevel3 As DataSet

    Private Sub LoadTabLevel3()
        LoadDataGridLevel3()
        clearFieldsLevel3()
    End Sub

    Private Sub RenewGridForLevel3()
        LoadDataGridLevel3()
    End Sub


    Private Sub LoadDataGridLevel3()
        'Dim i As Integer
        If AnalysisChoice = 0 Then
            DsLevel3 = Global1.Business.GetAllAccountAnalysisLevel3(False)
            Dg1AnalyisLevel3.DataSource = DsLevel3.Tables(0)
            DgAnalysisLinesLevel3.Visible = False

            'For i = 0 To (DsLevel3.Tables(0).Rows.Count - 1)
            '    If String.Compare(DsLevel3.Tables(0).Rows(i).Item(5).ToString, "A") = 0 Then
            '        Dg1AnalyisLevel3.Item(5, i).Value = "YES"
            '    Else
            '        Dg1AnalyisLevel3.Item(5, i).Value = "NO"
            '    End If
            'Next
        Else
            DsLevel3 = Global1.Business.GetAllAccountLineAnalysisLevel3(False)
            DgAnalysisLinesLevel3.DataSource = DsLevel3.Tables(0)
            Dg1AnalyisLevel3.Visible = False

            'For i = 0 To (DsLevel3.Tables(0).Rows.Count - 1)
            '    If String.Compare(DsLevel3.Tables(0).Rows(i).Item(5).ToString, "A") = 0 Then
            '        DgAnalysisLinesLevel3.Item(5, i).Value = "YES"
            '    Else
            '        DgAnalysisLinesLevel3.Item(5, i).Value = "NO"
            '    End If
            'Next
        End If
    End Sub

    Private Sub BtnNewLevel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewLevel3.Click
        clearFieldsLevel3()
    End Sub

    Private Sub clearFieldsLevel3()
        clearErrorsForLevel3()
        Me.TxtCodeLevel3.Text = ""
        Me.TxtCodeLevel3.BackColor = SystemColors.Window
        Me.TxtCodeLevel3.Enabled = True
        Me.TxtDescLLevel3.Text = ""
        Me.TxtDescSLevel3.Text = ""
        Me.DtpAmendDateLevel3.Value = Now.Date
        Me.DtpCreationDateLevel3.Value = Now.Date
        Me.CmbIsActiveLevel3.SelectedIndex = 0
    End Sub

    Private Function ValidateBeforeSavingForLevel3() As Boolean
        clearErrorsForLevel3()
        Dim flag As Boolean = True
        If Me.TxtCodeLevel3.Text = "" Then
            flag = False
            Me.ErrCodeLevel3.SetError(Me.TxtCodeLevel3, "Code Field is Required")
            'Else
            '    If Not IsNumeric(Me.TxtCodeLevel3.Text) Then
            '        flag = False
            '        Me.ErrCodeLevel3.SetError(Me.TxtCodeLevel3, "Code Field can be only Numeric")
            'End If
        End If
        If Me.TxtDescLLevel3.Text = "" Then
            flag = False
            Me.ErrDescLLevel3.SetError(Me.TxtDescLLevel3, "Description Field is Required")
        End If
        Return flag
    End Function

    Private Sub clearErrorsForLevel3()
        Me.ErrCodeLevel3.SetError(Me.TxtCodeLevel3, "")
        Me.ErrDescLLevel3.SetError(Me.TxtDescLLevel3, "")
    End Sub

    Private Sub BtnSaveLevel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveLevel3.Click
        TryToSaveLevel3()
    End Sub

    Private Sub TryToSaveLevel3()
        clearErrorsForLevel3()
        Dim code As String = Me.TxtCodeLevel3.Text
        Dim CurrentAnalysis1
        If ValidateBeforeSavingForLevel3() Then
            If AnalysisChoice = 0 Then
                CurrentAnalysis1 = New cAccountAnal1Level3(code)
            Else
                CurrentAnalysis1 = New cAccountLineAnal1Level3(code)
            End If
        Else
            Exit Sub
        End If

        With CurrentAnalysis1
            If .code <> "" And Not Me.TxtCodeLevel3.Enabled Then
                .code = Me.TxtCodeLevel3.Text
                .DescriptionL = Me.TxtDescLLevel3.Text
                .DescriptionS = Me.TxtDescSLevel3.Text
                .AmendDate = Now.Date
                If Me.CmbIsActiveLevel3.SelectedIndex = 0 Then
                    .IsActive = "A"
                Else
                    .IsActive = "I"
                End If
                If .save(False) Then
                    MsgBox("Succesfull Update", MsgBoxStyle.Information)
                    Me.TxtCodeLevel3.Enabled = False
                    RenewGridForLevel3()
                    PointLastUpdateForLevel3(.code)
                Else
                    MsgBox("Failed to Update", MsgBoxStyle.Critical)
                End If
            ElseIf .code = "" Then
                .code = Me.TxtCodeLevel3.Text
                .DescriptionL = Me.TxtDescLLevel3.Text
                .DescriptionS = Me.TxtDescSLevel3.Text
                .CreationDate = Now.Date
                .AmendDate = Now.Date
                If Me.CmbIsActiveLevel3.SelectedIndex = 0 Then
                    .IsActive = "A"
                Else
                    .IsActive = "I"
                End If
                If .save(True) Then
                    MsgBox("Succesfull Safe", MsgBoxStyle.Information)
                    Me.TxtCodeLevel3.Enabled = False
                    RenewGridForLevel3()
                    PointLastUpdateForLevel3(.code)
                Else

                    MsgBox("Failed to Save", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("This entry allready exist")
                Me.TxtCodeLevel3.Text = ""
                Exit Sub
            End If

        End With
    End Sub

    Private Sub PointLastUpdateForLevel3(ByVal code As String)
        Dim i As Integer = 0
        If AnalysisChoice = 0 Then
            For i = 0 To Dg1AnalyisLevel3.RowCount - 1
                If code = Dg1AnalyisLevel3.Item(0, i).Value Then
                    Dg1AnalyisLevel3.Rows(0).Selected = False
                    Dg1AnalyisLevel3.Rows(i).Selected = True
                    LoadFromDg1AnalyisLevel3(i)
                    Exit Sub
                End If
            Next i
        Else
            For i = 0 To DgAnalysisLinesLevel3.RowCount - 1
                If code = DgAnalysisLinesLevel3.Item(0, i).Value Then
                    DgAnalysisLinesLevel3.Rows(0).Selected = False
                    DgAnalysisLinesLevel3.Rows(i).Selected = True
                    LoadFromDgAnalysisLinesLevel3(i)
                    Exit Sub
                End If
            Next i
        End If
    End Sub

    Private Sub DgAnalysisLinesLevel3_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgAnalysisLinesLevel3.CurrentCellChanged
        Dim i As Integer = -1
        If DoNotRun Then Exit Sub
        Try
            i = Me.DgAnalysisLinesLevel3.CurrentRow.Index
            If i >= 0 Then
                LoadFromDgAnalysisLinesLevel3(i)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadFromDgAnalysisLinesLevel3(ByVal i As Integer)
        clearErrorsForLevel3()
        Dim currentAnalysis1
        Try
            If DoNotRun Then Exit Sub 'na to elexw
            'Dim i As Integer
            'i = Me.DgAnalysisLinesLevel3.CurrentRow.Index
            Dim Code As String
            Code = DgAnalysisLinesLevel3.Item(0, i).Value
            currentAnalysis1 = New cAccountLineAnal1Level3(Code)

            If currentAnalysis1.code <> "" Then
                With currentAnalysis1
                    Me.TxtCodeLevel3.BackColor = SystemColors.Info
                    Me.TxtCodeLevel3.Enabled = False
                    Me.TxtCodeLevel3.Text = DbNullToString(.code)
                    Me.TxtDescLLevel3.Text = DbNullToString(.DescriptionL())
                    Me.TxtDescSLevel3.Text = DbNullToString(.DescriptionS)
                    Me.DtpCreationDateLevel3.Text = DbNullToDate(.CreationDate)
                    Me.DtpAmendDateLevel3.Text = DbNullToDate(.AmendDate)
                    If .IsActive = "A" Then
                        Me.CmbIsActiveLevel3.SelectedIndex = 0
                    Else
                        Me.CmbIsActiveLevel3.SelectedIndex = 1
                    End If
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dg1AnalyisLevel3_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1AnalyisLevel3.CurrentCellChanged
        Dim i As Integer = -1
        If DoNotRun Then Exit Sub
        Try
            i = Me.Dg1AnalyisLevel3.CurrentRow.Index
            If i >= 0 Then
                LoadFromDg1AnalyisLevel3(i)
            End If
        Catch

        End Try
    End Sub

    Private Sub LoadFromDg1AnalyisLevel3(ByVal i As Integer)
        clearErrorsForLevel3()
        Dim currentAnalysis1
        Try
            If DoNotRun Then Exit Sub 'na to elexw
            'Dim i As Integer
            'i = Me.Dg1AnalyisLevel3.CurrentRow.Index
            Dim Code As String
            Code = Dg1AnalyisLevel3.Item(0, i).Value
            currentAnalysis1 = New cAccountAnal1Level3(Code)

            If currentAnalysis1.code <> "" Then
                With currentAnalysis1
                    Me.TxtCodeLevel3.BackColor = SystemColors.Info
                    Me.TxtCodeLevel3.Enabled = False
                    Me.TxtCodeLevel3.Text = DbNullToString(.code)
                    Me.TxtDescLLevel3.Text = DbNullToString(.DescriptionL)
                    Me.TxtDescSLevel3.Text = DbNullToString(.DescriptionS)
                    Me.DtpCreationDateLevel3.Text = DbNullToDate(.CreationDate)
                    Me.DtpAmendDateLevel3.Text = DbNullToDate(.AmendDate)
                    If .IsActive = "A" Then
                        Me.CmbIsActiveLevel3.SelectedIndex = 0
                    Else
                        Me.CmbIsActiveLevel3.SelectedIndex = 1
                    End If
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class