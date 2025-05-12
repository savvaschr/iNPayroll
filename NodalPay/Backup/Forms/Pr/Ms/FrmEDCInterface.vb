Public Class FrmEDCInterface

    Dim LoadNow As Boolean = False

    Dim E_Arr(14) As E_Interface
    Dim D_Arr(14) As D_Interface
    Dim C_Arr(14) As C_Interface

    Private Sub FrmEDCInterface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Me.E_InterHead1.LoadMe("Earnings")
        Me.E_InterHead2.LoadMe("Deductions")
        Me.E_InterHead3.LoadMe("Contributions")
        LoadEDCIntoArray()
        LoadComboInterfaceTemplate()
        ClearEDC()
    End Sub
    Private Sub LoadEDCIntoArray()
        E_Arr(0) = Me.E_Inter1
        E_Arr(1) = Me.E_Inter2
        E_Arr(2) = Me.E_Inter3
        E_Arr(3) = Me.E_Inter4
        E_Arr(4) = Me.E_Inter5
        E_Arr(5) = Me.E_Inter6
        E_Arr(6) = Me.E_Inter7
        E_Arr(7) = Me.E_Inter8
        E_Arr(8) = Me.E_Inter9
        E_Arr(9) = Me.E_Inter10
        E_Arr(10) = Me.E_Inter11
        E_Arr(11) = Me.E_Inter12
        E_Arr(12) = Me.E_Inter13
        E_Arr(13) = Me.E_Inter14
        E_Arr(14) = Me.E_Inter15

        D_Arr(0) = Me.D_Interface1
        D_Arr(1) = Me.D_Interface2
        D_Arr(2) = Me.D_Interface3
        D_Arr(3) = Me.D_Interface4
        D_Arr(4) = Me.D_Interface5
        D_Arr(5) = Me.D_Interface6
        D_Arr(6) = Me.D_Interface7
        D_Arr(7) = Me.D_Interface8
        D_Arr(8) = Me.D_Interface9
        D_Arr(9) = Me.D_Interface10
        D_Arr(10) = Me.D_Interface11
        D_Arr(11) = Me.D_Interface12
        D_Arr(12) = Me.D_Interface13
        D_Arr(13) = Me.D_Interface14
        D_Arr(14) = Me.D_Interface15

        C_Arr(0) = Me.C_Interface1
        C_Arr(1) = Me.C_Interface2
        C_Arr(2) = Me.C_Interface3
        C_Arr(3) = Me.C_Interface4
        C_Arr(4) = Me.C_Interface5
        C_Arr(5) = Me.C_Interface6
        C_Arr(6) = Me.C_Interface7
        C_Arr(7) = Me.C_Interface8
        C_Arr(8) = Me.C_Interface9
        C_Arr(9) = Me.C_Interface10
        C_Arr(10) = Me.C_Interface11
        C_Arr(11) = Me.C_Interface12
        C_Arr(12) = Me.C_Interface13
        C_Arr(13) = Me.C_Interface14
        C_Arr(14) = Me.C_Interface15



    End Sub
    Private Sub LoadComboInterfaceTemplate()
        LoadNow = True
        Dim i As Integer
        With Me.CmbInterfaceTemplate
            .BeginUpdate()
            Dim ds As DataSet
            ds = Global1.Business.GetAllPrMsInterfaceTemplateforUser(Global1.UserName)
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim IntTem As New cPrMsInterfaceTemplate(ds.Tables(0).Rows(i))
                    .Items.Add(IntTem)
                Next
            End If
            .EndUpdate()
        End With
        LoadNow = False
    End Sub

    Private Sub CmbInterfaceTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbInterfaceTemplate.SelectedIndexChanged
        Try
            If LoadNow Then Exit Sub
            Dim IntTem As New cPrMsInterfaceTemplate
            ClearEDC()
            IntTem = Me.CmbInterfaceTemplate.SelectedItem
            LoadEDC(IntTem)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try


    End Sub
    Private Sub ClearEDC()
        Dim i As Integer
        For i = 0 To E_Arr.Length - 1
            E_Arr(i).TemErn = New cPrMsTemplateEarnings
            E_Arr(i).ErnInt = New cPrMsEarningsInterface
            E_Arr(i).IntTem = New cPrMsInterfaceTemplate
            E_Arr(i).LoadComboInterfaceAccounts()
            E_Arr(i).LoadCombos()
            E_Arr(i).LoadMe()
        Next
        For i = 0 To D_Arr.Length - 1
            D_Arr(i).TemDed = New cPrMsTemplateDeductions
            D_Arr(i).DedInt = New cPrMsDeductionsInterface
            D_Arr(i).IntTem = New cPrMsInterfaceTemplate
            D_Arr(i).LoadComboInterfaceAccounts()
            D_Arr(i).LoadCombos()
            D_Arr(i).LoadMe()
        Next
        For i = 0 To C_Arr.Length - 1
            C_Arr(i).TemCon = New cPrMsTemplateContributions
            C_Arr(i).ConInt = New cPrMsContributionsInterface
            C_Arr(i).IntTem = New cPrMsInterfaceTemplate
            C_Arr(i).LoadComboInterfaceAccounts()
            C_Arr(i).LoadCombos()
            C_Arr(i).LoadMe()
        Next
    End Sub
    Private Sub LoadEDC(ByVal IntTem As cPrMsInterfaceTemplate)
        Dim DsE_interface As DataSet
        Dim DsD_interface As DataSet
        Dim DsC_interface As DataSet
        Dim DsTemErn As DataSet
        Dim DsTemDed As DataSet
        Dim DsTemCon As DataSet
        Dim EI As New cPrMsEarningsInterface
        Dim DI As New cPrMsDeductionsInterface
        Dim CI As New cPrMsContributionsInterface
        Dim i As Integer
        Dim k As Integer
        Dim DSInterfaceCodes As DataSet

        DSInterfaceCodes = Global1.Business.GetAllPrMsInterfaceCodesByTemplateGroup(IntTem.TemGrpCode)

        DsTemErn = Global1.Business.GetAllPrMsTemplateEarnings(IntTem.TemGrpCode)
        DsTemDed = Global1.Business.GetAllPrMsTemplateDeductions(IntTem.TemGrpCode)
        DsTemCon = Global1.Business.GetAllPrMsTemplateContributions(IntTem.TemGrpCode)

        DsE_interface = Global1.Business.GetAllPrmsEarningsInterface(IntTem.IntTemCode)
        DsD_interface = Global1.Business.GetAllPrmsDeductionsInterface(IntTem.IntTemCode)
        DsC_interface = Global1.Business.GetAllPrmsContributionsInterface(IntTem.IntTemCode)
        'Earnings
        If CheckDataSet(DsTemErn) Then
            For i = 0 To DsTemErn.Tables(0).Rows.Count - 1
                Dim TemErn As New cPrMsTemplateEarnings(DsTemErn.Tables(0).Rows(i))
                Me.E_Arr(i).TemErn = TemErn
            Next
        End If

        If CheckDataSet(DsE_interface) Then
            For i = 0 To DsE_interface.Tables(0).Rows.Count - 1
                EI = New cPrMsEarningsInterface(DsE_interface.Tables(0).Rows(i))
                For k = 0 To E_Arr.Length - 1
                    If EI.ErnCode = E_Arr(k).TemErn.ErnCodCode Then
                        Me.E_Arr(k).ErnInt = EI
                        Exit For
                    End If
                Next
            Next
        End If
        For i = 0 To E_Arr.Length - 1
            E_Arr(i).IntTem = IntTem
            E_Arr(i).DsInterfaceCodes = DSInterfaceCodes
            E_Arr(i).LoadComboInterfaceAccounts()
            E_Arr(i).LoadMe()
        Next

        'Deductions
        If CheckDataSet(DsTemDed) Then
            For i = 0 To DsTemDed.Tables(0).Rows.Count - 1
                Dim Temded As New cPrMsTemplateDeductions(DsTemDed.Tables(0).Rows(i))
                Me.D_Arr(i).TemDed = Temded
            Next
        End If
        If CheckDataSet(DsD_interface) Then
            For i = 0 To DsD_interface.Tables(0).Rows.Count - 1
                DI = New cPrMsDeductionsInterface(DsD_interface.Tables(0).Rows(i))
                For k = 0 To D_Arr.Length - 1
                    If DI.DedCode = D_Arr(k).TemDed.DedCodCode Then
                        Me.D_Arr(k).DedInt = DI
                        Exit For
                    End If
                Next
            Next
        End If
        For i = 0 To D_Arr.Length - 1
            D_Arr(i).IntTem = IntTem
            D_Arr(i).DSInterfaceCodes = DSInterfaceCodes
            D_Arr(i).LoadComboInterfaceAccounts()
            D_Arr(i).LoadMe()
        Next

        'Contributions

        If CheckDataSet(DsTemCon) Then
            For i = 0 To DsTemCon.Tables(0).Rows.Count - 1
                Dim TemCon As New cPrMsTemplateContributions(DsTemCon.Tables(0).Rows(i))
                Me.C_Arr(i).TemCon = TemCon
            Next
        End If
        If CheckDataSet(DsC_interface) Then
            For i = 0 To DsC_interface.Tables(0).Rows.Count - 1
                CI = New cPrMsContributionsInterface(DsC_interface.Tables(0).Rows(i))
                For k = 0 To C_Arr.Length - 1
                    If CI.ConCode = C_Arr(k).TemCon.ConCodCode Then
                        Me.C_Arr(k).ConInt = CI
                        Exit For
                    End If
                Next
            Next
        End If
        For i = 0 To C_Arr.Length - 1
            C_Arr(i).IntTem = IntTem
            C_Arr(i).DSInterfaceCodes = DSInterfaceCodes
            C_Arr(i).LoadComboInterfaceAccounts()
            C_Arr(i).LoadMe()
        Next
    End Sub


    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        TryToSave()
    End Sub
    Private Sub TryToSave()
        Dim i As Integer
        Dim Exx As New Exception
        Try

            If Me.CmbInterfaceTemplate.Text <> "" Then
                Global1.Business.BeginTransaction()
                For i = 0 To Me.E_Arr.Length - 1
                    With Me.E_Arr(i)
                        If Not E_Arr(i).SaveMe Then
                            Throw Exx
                        End If

                    End With
                Next
                For i = 0 To Me.D_Arr.Length - 1
                    With Me.D_Arr(i)
                        If Not D_Arr(i).SaveMe Then
                            Throw Exx
                        End If

                    End With
                Next
                For i = 0 To Me.C_Arr.Length - 1
                    With Me.C_Arr(i)
                        If Not C_Arr(i).SaveMe Then
                            Throw Exx
                        End If

                    End With
                Next

                Global1.Business.CommitTransaction()
                MsgBox("Succesfull Save", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
            Global1.Business.Rollback()
            MsgBox("Unable to Save", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Try

        
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            Dim IntTem As New cPrMsInterfaceTemplate
            IntTem = Me.CmbInterfaceTemplate.SelectedItem

            Dim i As Integer
            Dim DsTemErn As DataSet
            Dim DsTemDed As DataSet
            Dim DsTemCon As DataSet
            DsTemErn = Global1.Business.GetEarningsForExcelTemplate(IntTem.TemGrpCode)
            DsTemDed = Global1.Business.GetDeductionsForExcelTemplate(IntTem.TemGrpCode)
            DsTemCon = Global1.Business.GetContributionsForExcelTemplate(IntTem.TemGrpCode)


            HeaderStr.Add("Temp Group")
            HeaderStr.Add("Interface Group")
            HeaderStr.Add("EDC Code")
            HeaderStr.Add("EDC Description")
            HeaderStr.Add("Debit Account")
            HeaderStr.Add("Credit Account")
            HeaderStr.Add("Prefix")

            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(35)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)

            Loader.LoadIntoExcel(DsTemErn, HeaderStr, HeaderSize)
            Loader.LoadIntoExcel(DsTemDed, HeaderStr, HeaderSize)
            Loader.LoadIntoExcel(DsTemCon, HeaderStr, HeaderSize)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim F As New FrmPrMsInterfaceCode
        F.MdiParent = Me.MdiParent
        F.Show()
    End Sub

   
End Class