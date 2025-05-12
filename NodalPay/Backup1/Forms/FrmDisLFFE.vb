Public Class FrmDisLFFE
    Public EmpCode As String
    Public Period As cPrMsPeriodCodes
    Dim Ds As DataSet
    Dim Loading As Boolean
    Private Sub FrmDisLFFE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitTextBoxes()
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
        Loading = True

        Ds = Global1.Business.GetDiscountLifeInsuranceFirstEmployeemnt(EmpCode, Period.PrdGrpCode)
        DG1.DataSource = Ds.Tables(0)

        Loading = False
        LoadValuesToText()
    End Sub
    Private Sub InitTextBoxes()
        AddHandler txtD.KeyPress, AddressOf NumericKeyPress
        AddHandler txtD.Leave, AddressOf NumericOnLeave

        AddHandler txtLI.KeyPress, AddressOf NumericKeyPress
        AddHandler txtLI.Leave, AddressOf NumericOnLeave

        AddHandler txtFE.KeyPress, AddressOf NumericKeyPress
        AddHandler txtFE.Leave, AddressOf NumericOnLeave

        AddHandler txtTI.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTI.Leave, AddressOf NumericOnLeave

        AddHandler txtPeriodSplit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPeriodSplit.Leave, AddressOf NumericOnLeave

        AddHandler txtSIonPeriodSplit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtSIonPeriodSplit.Leave, AddressOf NumericOnLeave

        AddHandler txtTaxableFromOther.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTaxableFromOther.Leave, AddressOf NumericOnLeave

        AddHandler txtannualunits.KeyPress, AddressOf NumericKeyPress
        AddHandler txtannualunits.Leave, AddressOf NumericOnLeave


    End Sub

    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        LoadValuesToText()
    End Sub
    Private Sub LoadValuesToText()
        If loading Then Exit Sub
        Dim i As Integer
        If CheckDataSet(Ds) Then
            i = DG1.CurrentRow.Index
            Me.txtP.Text = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
            Me.txtD.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(1))
            Me.txtLI.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(2))
            Me.txtFE.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(3))
            Me.txtTI.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(4))


            Me.txtPeriodSplit.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(5))
            Me.txtSIonPeriodSplit.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(6))
            Me.txtTaxableFromOther.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(7))
            Me.txtAnnualUnits.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(8))

        Else
            Me.txtP.Text = ""
            Me.txtD.Text = "0.00"
            Me.txtLI.Text = "0.00"
            Me.txtFE.Text = "0.00"
            Me.txtTI.Text = "0.00"

            Me.txtPeriodSplit.Text = "0.00"
            Me.txtSIonPeriodSplit.Text = "0.00"
            Me.txtTaxableFromOther.Text = "0.00"

            Me.txtAnnualUnits.Text = DbNullToDouble(Ds.Tables(0).Rows(i).Item(8))

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim P As String
        Dim D As Double
        Dim LI As Double
        Dim FE As Double
        P = Me.txtP.Text
        D = Me.txtD.Text
        LI = Me.txtLI.Text
        FE = Me.txtFE.Text

        If Global1.Business.UpdateDiscountLifeInsuranceFirstEmployement(EmpCode, Period.PrdGrpCode, P, D, LI, FE) Then
            MsgBox("Succesfull Update", MsgBoxStyle.Information)
            LoadGrid()
        Else
            MsgBox("Unable to Update Record", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim P As String
        Dim D As Double
        Dim LI As Double
        Dim FE As Double
        Dim TI As Double
        P = Me.txtP.Text
        D = Me.txtD.Text
        LI = Me.txtLI.Text
        FE = Me.txtFE.Text
        TI = Me.txtTI.Text

        If Global1.Business.UpdateDiscountLifeInsuranceFirstEmployementTaxableIncome(EmpCode, Period.PrdGrpCode, P, D, LI, FE, TI) Then
            MsgBox("Succesfull Update", MsgBoxStyle.Information)
            LoadGrid()
        Else
            MsgBox("Unable to Update Record", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim P As String
        P = Me.txtP.Text
        Dim PeriodSplit As Double = "0.00"
        Dim SIonPeriodSplit As Double = "0.00"
        Dim TaxableFromOther As Double = "0.00"

        PeriodSplit = txtPeriodSplit.Text
        SIonPeriodSplit = txtSIonPeriodSplit.Text
        TaxableFromOther = txtTaxableFromOther.Text

        If Global1.Business.UpdatePeriodsplit_SIonPeriodSplit_TaxableFromOther(EmpCode, Period.PrdGrpCode, P, PeriodSplit, SIonPeriodSplit, TaxableFromOther) Then
            MsgBox("Succesfull Update", MsgBoxStyle.Information)
            LoadGrid()
        Else
            MsgBox("Unable to Update Record", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim P As String



        If CheckDataSet(Ds) Then
            Dim F As Boolean = True
            Dim i As Integer = 0
            Dim PeriodSplit As Double = "0.00"
            Dim SIonPeriodSplit As Double = "0.00"
            Dim TaxableFromOther As Double = "0.00"
            Dim Taxable As Double
            Dim SIOnTaxable As Double
            Dim Limit As Double
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                
                P = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                taxable = DbNullToDouble(Ds.Tables(0).Rows(i).Item(4))
                PeriodSplit = DbNullToDouble(Ds.Tables(0).Rows(i).Item(5))
                SIonPeriodSplit = DbNullToDouble(Ds.Tables(0).Rows(i).Item(6))
                TaxableFromOther = DbNullToDouble(Ds.Tables(0).Rows(i).Item(7))
                PeriodSplit = TaxableFromOther
                SIonPeriodSplit = RoundMe3((7.8 * PeriodSplit / 100), 2)
                TaxableFromOther = 0

                SIOnTaxable = RoundMe3((7.8 * Taxable / 100), 2)
                limit = RoundMe3((7.8 * 4533 / 100), 2)

                If SIOnTaxable + SIonPeriodSplit > Limit Then
                    SIonPeriodSplit = Limit - SIOnTaxable
                    If SIonPeriodSplit < 0 Then
                        SIonPeriodSplit = 0
                    End If
                End If


                If Not Global1.Business.UpdatePeriodsplit_SIonPeriodSplit_TaxableFromOther(EmpCode, Period.PrdGrpCode, P, PeriodSplit, SIonPeriodSplit, TaxableFromOther) Then
                    MsgBox("Unable to Complete Fixing in Line " & i + 1, MsgBoxStyle.Critical)
                    F = False
                End If

            Next
            If F Then
                MsgBox("Fixing is completed", MsgBoxStyle.Information)
            End If
            LoadGrid()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim P As String
        Dim AnnualUnits As Double
        
        P = Me.txtP.Text
        AnnualUnits = Me.txtAnnualUnits.Text
        

        If Global1.Business.UpdateAnnualUnits(EmpCode, Period.PrdGrpCode, P, annualunits) Then
            MsgBox("Succesfull Update of AnnualUnits", MsgBoxStyle.Information)
            LoadGrid()
        Else
            MsgBox("Unable to Update Record", MsgBoxStyle.Critical)
        End If
    End Sub
End Class