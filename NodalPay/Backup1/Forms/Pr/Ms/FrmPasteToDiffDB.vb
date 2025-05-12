Public Class FrmPasteToDiffDB
    Public Employee As New cPrMsEmployees
    Public DsSalary As DataSet
    Public DsDiscounts As DataSet
    Public DsAL As DataSet

    Dim GLBTempGroup As New cPrMsTemplateGroup
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '----------------------------------------------------------------------------------------------
        'Try To Connect To Second Database
        'Dim NAV_ServerName As String = "savvashp"
        'Dim NAV_DBName As String = "Cameleon"
        'Dim NAV_user As String = "nodal"
        'Dim NAV_Pass As String = "36132"

        Dim N_ServerName As String = ""
        Dim N_DBName As String = ""
        Dim N_user As String = ""
        Dim N_Pass As String = ""
        
        N_ServerName = Me.txtServerName.Text
        N_DBName = Me.txtDBName.Text
        N_user = Global1.GLBUserCode
        N_Pass = Global1.GLBUserPassword


        Dim StrConnect As String
        Dim L As New cLogin
        'StrConnect = "Server=" & NAV_ServerName & ";Database=" & NAV_DBName & ";User ID=" + NAV_user + ";Password=" + NAV_Pass + ";"
        'StrConnect = "Provider=SQLOLEDB;server=" & N_ServerName & ";uid=" + Trim(N_user) + ";pwd=" + Trim(N_Pass) + ";database=" & N_DBName
        StrConnect = "Server=" & N_ServerName & ";Database=" & N_DBName & ";User ID=" + Trim(N_user) + ";Password=" + Trim(N_Pass) + ";"
        Debug.WriteLine(StrConnect)
        If L.TryToConnect(StrConnect, True) Then
            ''''''''''''
            Dim CUser As New cUsers(N_user)
            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.GLBUserId = CUser.Id
                    Global1.GlobalUser = CUser
                End If
            End If

            Dim Role As String

            'Role = Global1.Business.GetUserRole
            If CUser.MyRole = 1 Then
                Role = Global1.Roles.Admin
            ElseIf CUser.MyRole = 2 Then
                Role = Global1.Roles.Manager
            ElseIf CUser.MyRole = 3 Then
                Role = Global1.Roles.User
            ElseIf CUser.MyRole = 4 Then
                Role = Global1.Roles.TimeAttetance
            End If

            Global1.UserRole = Role

            If Role = "" Then
                Role = "-1"
            End If
            Global1.IsUserEnabled = False


            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.IsUserEnabled = CUser.IsEnabled
                    If Not Global1.IsUserEnabled Then
                        MsgBox("User " & N_user & " is not Enabled as Payroll User", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
            End If
            '''''''''''''
            Global1.Business = New cBusiness
            LoadCombos()
            tryToLoadValuesOfCombos()
        Else
            MsgBox("Unable To connect To Database " & N_DBName, MsgBoxStyle.Critical)
            Exit Sub

            'StrConnect = "Provider=SQLOLEDB;server=" & Global1.DbaseServerName & ";uid=" + Global1.GLBUserCode + ";pwd=" + Global1.GLBUserPassword + ";database=" & Global1.DbaseName
            StrConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";User ID=" + Global1.GLBUserCode + ";Password=" + Global1.GLBUserPassword + ";"
            If L.TryToConnect(StrConnect, True) Then
                Global1.Business = New cBusiness
            End If
            Dim CUser As New cUsers(N_user)
            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.GLBUserId = CUser.Id
                    Global1.GlobalUser = CUser
                End If
            End If

            Dim Role As String

            'Role = Global1.Business.GetUserRole
            If CUser.MyRole = 1 Then
                Role = Global1.Roles.Admin
            ElseIf CUser.MyRole = 2 Then
                Role = Global1.Roles.Manager
            ElseIf CUser.MyRole = 3 Then
                Role = Global1.Roles.User
            ElseIf CUser.MyRole = 4 Then
                Role = Global1.Roles.TimeAttetance
            End If

            Global1.UserRole = Role

            If Role = "" Then
                Role = "-1"
            End If
            Global1.IsUserEnabled = False


            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.IsUserEnabled = CUser.IsEnabled
                    If Not Global1.IsUserEnabled Then
                        MsgBox("User " & N_user & " is not Enabled as Payroll User", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
            End If

        End If
        'End Of connection
        '----------------------------------------------------------------------------------------------

       

       


    End Sub
    Private Sub LoadCombos()
      
        LoadPrMsTemplateGroup()
      
        LoadPrAnEmployeeAnalysis1()
        LoadPrAnEmployeeAnalysis2()
        LoadPrAnEmployeeAnalysis3()
        LoadPrAnEmployeeAnalysis4()
        LoadPrAnEmployeeAnalysis5()
        LoadPrAnUnions()
        LoadPrAnEmployeePositions()
        Me.LoadPrAnBanks_Employee()
        Me.LoadPrAnBanks_Company()
        
        

    End Sub
    Private Sub tryToLoadValuesOfCombos()
        With Employee
            Dim An1 As New cPrAnEmployeeAnalysis1(.EmpAn1_Code)
            If An1.Code <> "" Then
                Me.cmbEmpAn1_Code.SelectedIndex = cmbEmpAn1_Code.FindStringExact(An1.ToString)
            Else
                MsgBox("Analysis 1 Code " & .EmpAn1_Code & " does not much", MsgBoxStyle.Information)
            End If


            Dim An2 As New cPrAnEmployeeAnalysis2(.EmpAn2_Code)
            If An2.Code <> "" Then
                Me.cmbEmpAn2_Code.SelectedIndex = cmbEmpAn2_Code.FindStringExact(An2.ToString)
            Else
                MsgBox("Analysis 2 Code" & .EmpAn2_Code & " does not much", MsgBoxStyle.Information)
            End If

            Dim An3 As New cPrAnEmployeeAnalysis3(.EmpAn3_Code)
            If An3.Code <> "" Then
                Me.cmbEmpAn3_Code.SelectedIndex = cmbEmpAn3_Code.FindStringExact(An3.ToString)
            Else
                MsgBox("Analysis 3 Code" & .EmpAn3_Code & " does not much", MsgBoxStyle.Information)
            End If


            Dim An4 As New cPrAnEmployeeAnalysis4(.EmpAn4_Code)
            If An4.Code <> "" Then
                Me.cmbEmpAn4_Code.SelectedIndex = cmbEmpAn4_Code.FindStringExact(An4.ToString)
            Else
                MsgBox("Analysis 4 Code " & .EmpAn4_Code & "does not much", MsgBoxStyle.Information)
            End If


            Dim An5 As New cPrAnEmployeeAnalysis5(.EmpAn5_Code)
            If An5.EmpAn5_Code <> "" Then
                Me.cmbEmpAn5_Code.SelectedIndex = cmbEmpAn5_Code.FindStringExact(An5.ToString)
            Else
                MsgBox("Analysis 5 Code" & .EmpAn5_Code & " does not much", MsgBoxStyle.Information)
            End If


            Dim Uni As New cPrAnUnions(.Uni_Code)
            If Uni.Code <> "" Then
                Me.cmbUni_Code.SelectedIndex = cmbUni_Code.FindStringExact(Uni.ToString)
            Else
                MsgBox("Union Code " & .Uni_Code & " does not much", MsgBoxStyle.Information)
            End If

            Dim EmpPos As New cPrAnEmployeePositions(.EmpPos_Code)
            If EmpPos.Code <> "" Then
                Me.ComboPosition.SelectedIndex = ComboPosition.FindStringExact(EmpPos.ToString)
            Else
                MsgBox("Employee Position " & .EmpPos_Code & " does not much", MsgBoxStyle.Information)
            End If

            Dim BankEmp As New cPrAnBanks(.Bnk_Code)
            If BankEmp.Code <> "" Then
                Me.ComboEmpBank.SelectedIndex = ComboEmpBank.FindStringExact(BankEmp.ToString)
            Else
                MsgBox("Employee Bank " & BankEmp.Code & " does not much", MsgBoxStyle.Information)
            End If

            Dim CompBank As New cPrAnBanks(.Bnk_CodeCo)
            If CompBank.Code <> "" Then
                Me.ComboComBank.SelectedIndex = ComboComBank.FindStringExact(CompBank.ToString)
            Else
                MsgBox("Company Bank " & CompBank.Code & " does not much", MsgBoxStyle.Information)
            End If




        End With

    End Sub

    Private Sub LoadPrMsTemplateGroup()
        Dim ds As DataSet
        Dim i As Integer
        'ds = Global1.Business.AG_GetAllPrMsTemplateGroup()
        ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        If CheckDataSet(ds) Then
            Dim tPrMsTemplateGroup As New cPrMsTemplateGroup
            With Me.cmbTemGrp_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsTemplateGroup = New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsTemplateGroup)
                Next i
                '  .ValueMember = "TemGrp_Code"
                .SelectedIndex = 0
                .EndUpdate()
                GLBTempGroup = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup)

            End With
        End If
    End Sub
    Private Sub LoadPrMsInterfaceTemplate(ByVal TemGrp As cPrMsTemplateGroup)
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemGrp.Code)
        If CheckDataSet(ds) Then
            Dim tPrMsInterfaceTemplate As New cPrMsInterfaceTemplate
            'Interface Template
            With Me.cmbIntTem_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'Provident Fund
            With Me.cmbIntPF
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'Medical Fund
            With Me.cmbIntMF
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
            'D/C    Accounts
            'With Me.cmbIntAC
            '    .BeginUpdate()
            '    .Items.Clear()
            '    For i = 0 To ds.Tables(0).Rows.Count - 1
            '        tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
            '        .Items.Add(tPrMsInterfaceTemplate)
            '    Next i
            '    .SelectedIndex = 0
            '    .EndUpdate()
            'End With

        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis1()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis1 As New cPrAnEmployeeAnalysis1
            With Me.cmbEmpAn1_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis1 = New cPrAnEmployeeAnalysis1(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis1)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis2()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis2 As New cPrAnEmployeeAnalysis2
            With Me.cmbEmpAn2_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis2 = New cPrAnEmployeeAnalysis2(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis2)
                Next i
                ' .ValueMember = "EmpAn2_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis3()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis3 As New cPrAnEmployeeAnalysis3
            With Me.cmbEmpAn3_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis3 = New cPrAnEmployeeAnalysis3(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis3)
                Next i
                '.ValueMember = "EmpAn3_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis4()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis4 As New cPrAnEmployeeAnalysis4
            With Me.cmbEmpAn4_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis4 = New cPrAnEmployeeAnalysis4(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis4)
                Next i
                '.ValueMember = "EmpAn4_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis5()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis5 As New cPrAnEmployeeAnalysis5
            With Me.cmbEmpAn5_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis5 = New cPrAnEmployeeAnalysis5(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis5)
                Next i
                ' .ValueMember = "EmpAn5_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnUnions()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnUnions()
        If CheckDataSet(ds) Then
            Dim tPrAnUnions As New cPrAnUnions
            With Me.cmbUni_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnUnions = New cPrAnUnions(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnUnions)
                Next i
                '  .ValueMember = "Uni_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeePositions()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeePositions(True)
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeePositions As New cPrAnEmployeePositions
            With Me.ComboPosition
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeePositions = New cPrAnEmployeePositions(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnEmployeePositions)
                Next i
                '.ValueMember = "EmpPos_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnBanks_Employee()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.ComboEmpBank
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                Next i
                '   .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnBanks_Company()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.ComboComBank
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
   

    Private Sub FrmPasteToDiffDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtServerName.Text = Global1.DbaseServerName
    End Sub

    Private Sub cmbTemGrp_Code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTemGrp_Code.SelectedIndexChanged
        GLBTempGroup = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup)
        Me.LoadPrMsInterfaceTemplate(GLBTempGroup)
        Dim ds As DataSet
        ds = Global1.Business.FindCurrentPeriod1(GLBTempGroup.Code)
        Dim PrdGrpCode As String
        PrdGrpCode = DbNullToString(ds.Tables(0).Rows(0).Item(1))
        'Dim PrdGroup As New cPrMsPeriodGroups(PrdGrpCode)
        Me.txtPeriodGroup.text = PrdGrpCode


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click




        Dim Exx As New Exception
        Dim StrConnect As String
        Dim L As New cLogin
        Dim Update As Boolean = False


        Dim sEmp As New cPrMsEmployees(CStr(Me.txtNewCode.Text))
        If sEmp.Code <> "" Then
            MsgBox("Employee with Code " & CStr(Me.txtNewCode.Text) & " Already Exists in Database  " & Me.txtDBName.Text, MsgBoxStyle.Critical)
            Exit Sub
        End If

        With Employee

            .Code = CStr(Me.txtNewCode.Text)
            .TemGrp_Code = CType(Me.cmbTemGrp_Code.SelectedItem, cPrMsTemplateGroup).Code

            .EmpAn1_Code = CType(Me.cmbEmpAn1_Code.SelectedItem, cPrAnEmployeeAnalysis1).Code
            .EmpAn2_Code = CType(Me.cmbEmpAn2_Code.SelectedItem, cPrAnEmployeeAnalysis2).Code
            .EmpAn3_Code = CType(Me.cmbEmpAn3_Code.SelectedItem, cPrAnEmployeeAnalysis3).Code
            .EmpAn4_Code = CType(Me.cmbEmpAn4_Code.SelectedItem, cPrAnEmployeeAnalysis4).Code
            .EmpAn5_Code = CType(Me.cmbEmpAn5_Code.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
            .Uni_Code = CType(Me.cmbUni_Code.SelectedItem, cPrAnUnions).Code

            .EmpPos_Code = CType(Me.ComboPosition.SelectedItem, cPrAnEmployeePositions).Code

            .InterfaceTemCode = CType(Me.cmbIntTem_Code.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
            .InterfacePFCode = CType(Me.cmbIntPF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode
            .InterfaceMFCode = CType(Me.cmbIntMF.SelectedItem, cPrMsInterfaceTemplate).IntTemCode

            .Bnk_Code = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
            .Bnk_CodeCo = CType(Me.ComboComBank.SelectedItem, cPrAnBanks).Code


            '.PreviousEarnings = CDbl(Me.txtPreviousEarnings.Text)
            '.Emp_PrevSIDeduct = CDbl(Me.txtEmp_PrevSIDeduct.Text)
            '.Emp_PrevSIContribute = CDbl(Me.txtEmp_PrevSIContribute.Text)
            '.Emp_PrevITDeduct = CDbl(Me.txtEmp_PrevITDeduct.Text)
            '.Emp_PrevPFDeduct = CDbl(Me.txtEmp_PrevPFDeduct.Text)
            '.PreviousEarnings = CDbl(Me.txtPreviousEarnings.Text)
            '.Emp_PrevSIDeduct = CDbl(Me.txtEmp_PrevSIDeduct.Text)
            '.Emp_PrevSIContribute = CDbl(Me.txtEmp_PrevSIContribute.Text)
            '.Emp_PrevITDeduct = CDbl(Me.txtEmp_PrevITDeduct.Text)
            '.Emp_PrevPFDeduct = CDbl(Me.txtEmp_PrevPFDeduct.Text)
            '.PreviousLifeIns = Me.txtPreviousLF.Text
            '.PreviousDis = Me.txtPreviousDis.Text
            '.PreviousST = Me.txtPreviousST.Text
            '.PrevMedFund = Me.txtPreviusMF.Text
            '.PrevPensionFund = Me.txtPreviusPenF.Text
            .Status = "A"
            .TerminateDate = ""


            .NewEmployee = 1


            ' .CreationDate = Now.Date
            .CreatedBy = Global1.GLBUserId

            '.AmendDate = Now.Date
            .AmendBy = Global1.GLBUserId
            If Not .Save() Then
                MsgBox("Unable to Save Employee !", MsgBoxStyle.Critical)
            Else
                ''''End Salary Save
                Global1.Business.BeginTransaction()
                Try
                    If CheckDataSet(DsSalary) Then
                        Dim i As Integer
                        For i = 0 To DsSalary.Tables(0).Rows.Count - 1
                            Dim id As Integer
                            id = DbNullToInt(DsSalary.Tables(0).Rows(i).Item(0))
                            'Dim Sal As New cPrTxEmployeeSalary(id)
                            Dim Sal2 As New cPrTxEmployeeSalary(DsSalary.Tables(0).Rows(i))
                            With Sal2
                                .Id = 0
                                .Emp_Code = Me.txtNewCode.Text
                                '.Date1 = Cdate1(Sal.Date1)
                                '.SalaryValue = Sal.SalaryValue
                                '.Basic = Sal.Basic
                                '.EffPayDate = CDate1(Sal.EffPayDate)
                                '.Cola = Sal.Cola
                                '.EffArrearsDate = CDate1(Sal.EffArrearsDate)
                                .Usr_Id = Global1.GLBUserId
                                '.myRate = Sal.myRate
                                '.IsCola = "N"
                                '.EmpSal_Dif = Sal.EmpSal_Dif
                            End With
                           
                            If Not Sal2.Save() Then
                                Throw Exx
                            End If
                        Next
                    End If
                    Global1.Business.CommitTransaction()
                Catch ex As Exception
                    Global1.Business.Rollback()
                    MsgBox("Unable to Save Employee Salary")
                End Try

                Global1.Business.BeginTransaction()
                Try

                    If CheckDataSet(DsAL) Then
                        Dim i As Integer
                        For i = 0 To DsAL.Tables(0).Rows.Count - 1
                            Dim Al As New cPrTxEmployeeLeave(DsAL.Tables(0).Rows(i))
                            Al.Id = 0
                            Al.EmpCode = Trim(Me.txtNewCode.Text)
                            If Not Al.Save() Then
                                Throw Exx
                            End If
                        Next
                    End If
                    Global1.Business.CommitTransaction()
                Catch ex As Exception
                    Global1.Business.Rollback()
                    MsgBox("Unable to Save Employee Annual Leave")
                End Try


                Global1.Business.BeginTransaction()
                Try

                    If CheckDataSet(DsDiscounts) Then
                        Dim i As Integer
                        For i = 0 To DsDiscounts.Tables(0).Rows.Count - 1
                            Dim Dis As New cPrTxEmployeeDiscounts(DsDiscounts.Tables(0).Rows(i))
                            Dis.Id = 0
                            Dis.Emp_Code = Trim(Me.txtNewCode.Text)
                            Dis.PrdGrp_Code = Me.txtPeriodGroup.Text
                            Dis.Usr_Id = Global1.GLBUserId
                            If Not Dis.Save() Then
                                Throw Exx
                            End If
                        Next
                    End If
                    Global1.Business.CommitTransaction()
                Catch ex As Exception
                    Global1.Business.Rollback()
                    MsgBox("Unable to Save Employee Discounts")
                End Try



                MsgBox("Succesfull Paste!", MsgBoxStyle.Information)
            End If

        End With



        'Connect Back to Payroll
        StrConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";User ID=" + Global1.GLBUserCode + ";Password=" + Global1.GLBUserPassword + ";"

        If L.TryToConnect(StrConnect, True) Then
            Global1.Business = New cBusiness
            Dim CUser As New cUsers(Global1.GLBUserCode)
            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.GLBUserId = CUser.Id
                    Global1.GlobalUser = CUser
                End If
            End If

            Dim Role As String

            'Role = Global1.Business.GetUserRole
            If CUser.MyRole = 1 Then
                Role = Global1.Roles.Admin
            ElseIf CUser.MyRole = 2 Then
                Role = Global1.Roles.Manager
            ElseIf CUser.MyRole = 3 Then
                Role = Global1.Roles.User
            ElseIf CUser.MyRole = 4 Then
                Role = Global1.Roles.TimeAttetance
            End If

            Global1.UserRole = Role

            If Role = "" Then
                Role = "-1"
            End If
            Global1.IsUserEnabled = False


            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.IsUserEnabled = CUser.IsEnabled
                    If Not Global1.IsUserEnabled Then
                        MsgBox("User " & Global1.GLBUserCode & " is not Enabled as Payroll User", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Function Cdate1(ByVal S As String) As Date
        Dim Ar() As String
        Dim Ar1() As String

        Ar1 = S.Split(" ")

        S = Ar1(0)

        Ar = S.Split("/")

        Dim D As String = Ar(0)
        Dim M As String = Ar(1)
        Dim Y As String = Ar(2)

        Dim date1 As Date
        date1 = CDate(Y & "/" & M & "/" & D)
        Return date1

    End Function

    Private Sub FrmPasteToDiffDB_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim StrConnect As String
        Dim L As New cLogin


        'Connect Back to Payroll
        StrConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";User ID=" + Global1.GLBUserCode + ";Password=" + Global1.GLBUserPassword + ";"

        If L.TryToConnect(StrConnect, True) Then
            Global1.Business = New cBusiness
            Dim CUser As New cUsers(Global1.GLBUserCode)
            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.GLBUserId = CUser.Id
                    Global1.GlobalUser = CUser
                End If
            End If

            Dim Role As String

            'Role = Global1.Business.GetUserRole
            If CUser.MyRole = 1 Then
                Role = Global1.Roles.Admin
            ElseIf CUser.MyRole = 2 Then
                Role = Global1.Roles.Manager
            ElseIf CUser.MyRole = 3 Then
                Role = Global1.Roles.User
            ElseIf CUser.MyRole = 4 Then
                Role = Global1.Roles.TimeAttetance
            End If

            Global1.UserRole = Role

            If Role = "" Then
                Role = "-1"
            End If
            Global1.IsUserEnabled = False


            If Not CUser Is Nothing Then
                If CUser.Id > 0 Then
                    Global1.IsUserEnabled = CUser.IsEnabled
                    If Not Global1.IsUserEnabled Then
                        MsgBox("User " & Global1.GLBUserCode & " is not Enabled as Payroll User", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("User Does not Exist as Payroll User", MsgBoxStyle.Critical)
            End If
        End If

    End Sub
End Class