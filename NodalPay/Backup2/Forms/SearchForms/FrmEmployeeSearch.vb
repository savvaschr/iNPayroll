Public Class FrmEmployeeSearch
    Public CalledBy As Integer
    Public RowIndex As Integer
    Public TempGroup As String
    Dim Ds As DataSet
    Dim LastCode As String
    Dim Counter As Integer = 0
    Dim ArBegin(5000) As String
    Dim ArEnd(5000) As String

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Counter = 0
        ReDim ArBegin(5000)
        ReDim ArEnd(5000)
        SearchForCustomer("", 1, "")
        Me.EnablePreviusNext(True)
        Cursor = Cursors.Default
    End Sub
    Private Sub SearchForCustomer(ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String)
        Dim Code As String
        Dim Description As String
        Dim ActiveOnly As Boolean = False
        Dim OnlyNew As Boolean = False
        Dim TempGroupCode As String




        Code = Me.txtCode.Text
        Description = Me.txtDescription.Text

        If CalledBy = 1 Then
            If Me.CBOnlyNew.CheckState = CheckState.Checked Then
                onlynew = True
            End If
        End If
        '    CustomerOnly = True
        'ElseIf CalledBy = 2 Then
        '    CustomerOnly = True
        'End If
        If Me.CBActive.CheckState = CheckState.Checked Then
            ActiveOnly = True
        Else
            ActiveOnly = False
        End If
        If TempGroup = "" Or TempGroup Is Nothing Then
            If Me.ComboTempGroups.SelectedIndex = 0 Then
                TempGroupCode = ""
            Else
                TempGroupCode = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
            End If
        Else
            TempGroupCode = TempGroup

        End If
        

        Dim Phone As String = Me.txtPhone.Text
        Dim SI As String = Me.txtSINo.Text
        Dim ID As String = Me.txtID.Text
        Dim TIC As String = Me.txtTICNo.Text
        Dim ARC As String = Me.txtARC.Text
        Dim SiCat As String = Me.txtSICat.Text
        Dim NoSI As Boolean = False
        If Me.CBNoSI.CheckState = CheckState.Checked Then
            NoSI = True
        End If

        Ds = Global1.Business.SearchForEmployeeByUser(Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, ActiveOnly, TempGroupCode, Global1.UserName, OnlyNew, SI, ID, TIC, ARC, SiCat, NoSI, Phone)
        Me.DG1.DataSource = Ds.Tables(0)


    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If CheckDataSet(Ds) Then
            Dim Row As Integer
            Dim Code As String
            Row = Ds.Tables(0).Rows.Count - 1
            Code = DbNullToString(Ds.Tables(0).Rows(Row).Item(0))
            ArBegin(Counter) = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
            ArEnd(Counter) = DbNullToString(Ds.Tables(0).Rows(Row).Item(0))
            SearchForCustomer(Code, 1, "")
            Counter = Counter + 1
        End If
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        If CheckDataSet(Ds) Or Counter > 0 Then
            If Counter = 0 Then Exit Sub
            Counter = Counter - 1
            SearchForCustomer(ArBegin(Counter), -1, ArEnd(Counter))
        End If
    End Sub

    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnSearch.Focus()
        End If
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        EnablePreviusNext(False)
    End Sub

    Private Sub txtDescription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnSearch.Focus()
        End If
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        EnablePreviusNext(False)
    End Sub


    Private Sub EnablePreviusNext(ByVal TF As Boolean)
        Me.BtnNext.Enabled = TF
        Me.BtnPrevius.Enabled = TF
    End Sub
    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        If CheckDataSet(Ds) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            If i <= Ds.Tables(0).Rows.Count - 1 Then

                Dim code As String
                Dim Desc As String
                code = DbNullToString(DG1.Item(0, i).Value)
                Desc = DbNullToString(DG1.Item(1, i).Value)
                If Me.CalledBy = 1 Then
                    Dim Emp As New cPrMsEmployees(code)
                    CType(Me.Owner, frmPrMsEmployees).txtCode.Text = code
                    CType(Me.Owner, frmPrMsEmployees).LoadEmployee(Emp, False)
                ElseIf Me.CalledBy = 2 Then
                    Dim Emp As New cPrMsEmployees(code)
                    CType(Me.Owner, frmPrTxCalc1).LoadEmployee(Emp)
                ElseIf Me.CalledBy = 3 Then
                    CType(Me.Owner, FrmPayroll1).txtFromEmployee.Text = code
                    CType(Me.Owner, FrmPayroll1).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 4 Then
                    CType(Me.Owner, FrmPayroll1).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 5 Then
                    CType(Me.Owner, FrmIR63A).txtFromEmployee.Text = code
                    CType(Me.Owner, FrmIR63A).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 6 Then
                    CType(Me.Owner, FrmIR63A).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 7 Then
                    CType(Me.Owner, FrmPayrollTotalsX).txtFromEmployee.Text = code
                    CType(Me.Owner, FrmPayrollTotalsX).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 8 Then
                    CType(Me.Owner, FrmPayrollTotalsX).txtToEmployee.Text = code
                End If

                Me.Close()
            End If
        End If
    End Sub
   
 
   
   
    Private Sub FrmEmployeeSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CalledBy = 1 Then
            Me.CBOnlyNew.Visible = True
        Else
            Me.CBOnlyNew.Visible = False
        End If
        LoadTemplateGroup()

        If Me.TempGroup = "" Then
            Me.ComboTempGroups.Visible = True
            Me.Label8.Visible = True
        Else
            Me.ComboTempGroups.Visible = False
            Me.Label8.Visible = False

        End If
    End Sub
    Private Sub LoadTemplateGroup()

        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("ALL")
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    Dim Temp As New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
                    .Items.Add(Temp)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With

    End Sub

   
End Class