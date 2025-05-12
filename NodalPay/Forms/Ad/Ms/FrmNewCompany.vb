Public Class FrmNewCompany

   
    Private Sub FrmNewCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ds As DataSet
        Dim i As Integer
        Ds = Global1.Business.GetAllCompaniesFullRow()
        If CheckDataSet(Ds) Then
            With Me.ComboCompany
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim Com As New cAdMsCompany(DbNullToInt(Ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(Com)
                Next
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
        Me.txtCode.Focus()
    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If ValidateCompany() Then
            Dim C As New cAdMsCompany()
            C = CType(Me.ComboCompany.SelectedItem, cAdMsCompany)

            Dim T As New cPrMsTemplateGroup()
            T = CType(Me.ComboTempGroup.SelectedItem, cPrMsTemplateGroup)

            Dim P As New cPrMsPeriodGroups()
            P = CType(Me.ComboPerGroup.SelectedItem, cPrMsPeriodGroups)

            Dim IT As New cPrMsInterfaceTemplate()
            IT = CType(Me.ComboInterfaceGroup.SelectedItem, cPrMsInterfaceTemplate)



            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Create a company based on " & C.Code & " - " & C.Name, MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                If CreateNewCompany(C) Then
                    If CreateNewtemplateGroup(T) Then
                        If CreateNewPeriodGroupGroup(P) Then
                            If CreateNewInterfaceTemplate(IT) Then

                                CreatePeriodCodesAndPeriodEDC(P)
                                CreateTemplateEDC(T)
                                'CreateInterfaceCodes(IT)
                                CreateInterfaceEDCAndCodes(IT, CStr(Me.txtTempGroup.Text), C.Code, Trim(Me.txtCode.Text), T.Code)
                                AddUserOnNewCompany()
                                MsgBox("New Company Created Succefully", MsgBoxStyle.Information)

                            End If

                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub AddUserOnNewCompany()
        Dim C As New cAdMsCompany(Me.txtCode.Text)
        Global1.Business.AddUserOnCompany(Global1.UserName, C)

    End Sub
    Private Function CreateNewCompany(ByVal TemplateCompany As cAdMsCompany) As Boolean
        Dim F As Boolean = True
        Dim NewComp As New cAdMsCompany
        With NewComp
            .Id = FindCompanyNextID()
            .Code = Me.txtCode.Text.Trim()
            .Name = Me.txtDescL.Text.Trim()
            .NameShort = Me.txtDescS.Text.Trim()
            .TIC = ""
            .TaxCard = ""
            .SIRegNo = ""
            .CurSymbol = "EUR"
            .Address1 = ""
            .Address2 = ""
            .Address3 = ""
            .Address4 = ""
            .Tel1 = ""
            .Tel2 = ""
            .Fax1 = ""
            .Fax2 = ""
            .AccountantPostCode = ""
            .AccountantPOBox = ""
            .AccountantTitle = ""
            .AccountantTIC = ""

            .AccIdentity = TemplateCompany.AccIdentity
            .TICCategory = TemplateCompany.TICCategory
            .TICType = TemplateCompany.TICType

            .BankCode = ""
            .GLAnal1 = ""
            .GLAnal2 = ""
            .GLAnal3 = ""
            .GLAnal4 = ""
            .GLAnal5 = ""

            .TSAccount = ""
            .TSBalAccount = ""
            .TSDefaultJob = ""

            .SI2 = ""
            .SI3 = ""
            .SI4 = ""
            .SI5 = ""

            .BankCode2 = ""
            .BankCode3 = ""
            .BankCode4 = ""

            .ComLogo = My.Resources.Company1
            .ComStamp = My.Resources.Company1

            .TSAccountType = TemplateCompany.TSAccountType
            .TSBalAccountType = TemplateCompany.TSBalAccountType

            If Not .Save Then
                F = False
            End If
        End With
        Return F

    End Function
    Private Function CreateNewtemplateGroup(ByVal T As cPrMsTemplateGroup) As Boolean
        Dim F As Boolean = False
        Dim NewT As New cPrMsTemplateGroup
        With NewT
            .Code = CStr(Me.txtTempGroup.Text)
            .PayTypCode = T.PayTypCode
            .DescriptionL = CStr(Me.txtTempDescL.Text)
            .DescriptionS = CStr(Me.txtTempDescS.Text)
            .IsActive = "Y"
            .DayUnits = T.DayUnits
            .GLAnl1 = ""
            .GLAnl2 = ""
            .CompanyCode = Me.txtCode.Text
            If .Save() Then
                F = True
            End If
        End With

        Return F

    End Function
    Private Function CreateNewPeriodGroupGroup(ByVal P As cPrMsPeriodGroups)
        Dim F As Boolean = False
        Dim NewP As New cPrMsPeriodGroups
        With NewP
            .Code = CStr(Me.txtPeriodGroup.Text)
            .Status = P.Status
            .Year = P.Year
            .TemGrpCode = Trim(Me.txtTempGroup.Text)
            .DescriptionL = CStr(Me.txtTempDescL.Text)
            If .Save() Then
                F = True
            End If
        End With


        Return F

    End Function
    Private Function CreateNewInterfaceTemplate(ByVal IT As cPrMsInterfaceTemplate)
        Dim F As Boolean = False
        Dim NewIT As New cPrMsInterfaceTemplate
        With NewIT
            .IntTemCode = Trim(Me.txtNewInterfaceGroup.Text)
            .IntTemDescription = Trim(Me.txtNewInterfaceGroupDesc.Text)
            .TemGrpCode = Trim(Me.txtTempGroup.Text)
            If .Save() Then
                F = True
            End If
        End With
        Return F

    End Function
    Private Function CreatePeriodCodesAndPeriodEDC(ByVal P As cPrMsPeriodGroups) As Boolean
        Dim NewGroupCode As String = Me.txtPeriodGroup.Text
        Dim F As Boolean = False
        If Global1.Business.CreateNewPeriod(P.Code, NewGroupCode) Then
            If Global1.Business.CreateNewPeriodEarnings(P.Code, NewGroupCode) Then
                If Global1.Business.CreateNewPeriodDeductions(P.Code, NewGroupCode) Then
                    If Global1.Business.CreateNewPeriodContributions(P.Code, NewGroupCode) Then
                        F = True
                    End If
                End If
            End If
        End If
        Return F

    End Function
    Private Function CreateTemplateEDC(ByVal T As cPrMsTemplateGroup) As Boolean
        Dim NewTempCode As String
        Dim F As Boolean = False
        NewTempCode = Me.txtTempGroup.Text
        If Global1.Business.CreateNewTemplateEarnings(T.Code, NewTempCode) Then
            If Global1.Business.CreateNewTemplateDeductions(T.Code, NewTempCode) Then
                If Global1.Business.CreateNewTemplateContributions(T.Code, NewTempCode) Then
                    F = True
                End If
            End If
        End If
        Return F
    End Function
    Private Function CreateInterfaceEDCAndCodes(ByVal IT As cPrMsInterfaceTemplate, ByVal NewTempGrpCode As String, ByVal OldComp As String, ByVal NewComp As String, ByVal OldTempGrpCode As String) As Boolean
        Dim NewTempCode As String
        Dim F As Boolean = False
        NewTempCode = Me.txtTempGroup.Text

        If Global1.Business.CreateNewInterfaceTemplateEarnings(IT.IntTemCode, NewTempCode, NewTempGrpCode, OldComp, NewComp) Then
            If Global1.Business.CreateNewInterfaceTemplateDeductions(IT.IntTemCode, NewTempCode, NewTempGrpCode, OldComp, NewComp) Then
                If Global1.Business.CreateNewInterfaceTemplateContributions(IT.IntTemCode, NewTempCode, NewTempGrpCode, OldComp, NewComp) Then
                    If Global1.Business.CreateNewInterfaceCodes(NewTempGrpCode, OldTempGrpCode, OldComp, NewComp) Then
                        F = True
                    End If
                End If
            End If
        End If

        Return F
    End Function
    Private Function FindCompanyNextID() As Integer
        Return Global1.Business.GetCompanyNextId

    End Function
    Private Function ValidateCompany() As Boolean

        Dim F As Boolean = True
        If Trim(Me.txtCode.Text) = "" Then
            F = False
        End If
        If Trim(Me.txtDescL.Text) = "" Then
            F = False
        End If
        If Trim(Me.txtDescS.Text) = "" Then
            F = False
        End If
        If Trim(Me.txtTempGroup.Text) = "" Then
            F = False
        End If

        If Not F Then
            MsgBox("Please first fill in Company code, long and Short Description", MsgBoxStyle.Information)
        End If
        If F Then
            Dim C As New cAdMsCompany(Me.txtCode.Text)
            If C.Id <> 0 Then
                MsgBox("Company with code " & C.Code & " Already Exist , cannot create a new one with the same code", MsgBoxStyle.Critical)
                F = False
            End If
            If F Then
                Dim T As New cPrMsTemplateGroup(Me.txtTempGroup.Text)
                If T.Code <> "" Then
                    MsgBox("Template with code " & C.Code & " Already Exist , cannot create a new one with the same code", MsgBoxStyle.Critical)
                    F = False
                End If
            End If
            If F Then
                Dim P As New cPrMsPeriodGroups(Me.txtPeriodGroup.Text)
                If P.Code <> "" Then
                    MsgBox("PeriodGroup with code " & P.Code & " Already Exist , cannot create a new one with the same code", MsgBoxStyle.Critical)
                    F = False
                End If
            End If
            If F Then
                Dim IT As New cPrMsInterfaceTemplate(Me.txtNewInterfaceGroup.Text)
                If IT.IntTemCode <> "" Then
                    MsgBox("Interface Group with code " & IT.IntTemCode & " Already Exist , cannot create a new one with the same code", MsgBoxStyle.Critical)
                    F = False
                End If
            End If

        End If
        Return F

    End Function
    Private Sub ComboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCompany.SelectedIndexChanged
        LoadTemplateGroup()
    End Sub
    Private Sub LoadTemplateGroup()
        Dim C As New cAdMsCompany
        C = CType(Me.ComboCompany.SelectedItem, cAdMsCompany)
        Dim Ds As DataSet
        Ds = Global1.Business.GetcompanyTemplateGroup(C.Code)
        Dim i As Integer
        If CheckDataSet(Ds) Then
            With Me.ComboTempGroup
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim TemGrp As New cPrMsTemplateGroup(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(TemGrp)
                Next
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub

    Private Sub ComboTempGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTempGroup.SelectedIndexChanged
        LoadPeriodGroup()
        LoadInterfaceGroup()
    End Sub
    Private Sub LoadPeriodGroup()
        Dim T As New cPrMsTemplateGroup
        T = CType(Me.ComboTempGroup.SelectedItem, cPrMsTemplateGroup)
        Dim Ds As DataSet
        Ds = Global1.Business.GetPeriodGroupOfTemplateGroup(T.Code)
        Dim i As Integer
        If CheckDataSet(Ds) Then
            With Me.ComboPerGroup
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim PerGrp As New cPrMsPeriodGroups(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(PerGrp)
                Next
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadInterfaceGroup()
        Dim T As New cPrMsTemplateGroup
        T = CType(Me.ComboTempGroup.SelectedItem, cPrMsTemplateGroup)

        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(T.Code)
        If CheckDataSet(ds) Then
            Dim tPrMsInterfaceTemplate As New cPrMsInterfaceTemplate
            'Interface Template
            With Me.ComboInterfaceGroup
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsInterfaceTemplate = New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(tPrMsInterfaceTemplate)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If

    End Sub


 
    Private Sub txtTempGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTempGroup.TextChanged
        Me.txtNewInterfaceGroup.Text = Me.txtTempGroup.Text
    End Sub

    Private Sub txtDescL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescL.TextChanged
        Me.txtTempDescL.Text = Me.txtDescL.Text
        Me.txtTempDescS.Text = Me.txtDescL.Text
        Me.txtDescS.Text = Me.txtDescL.Text
        Me.txtNewInterfaceGroupDesc.Text = Me.txtDescL.Text
        'Me.txtPeriodDesc.Text = "2014 " & Me.txtDescL.Text
        'Me.txtPeriodGroup.Text = "2014" & Me.txtCode.Text


    End Sub
End Class