Public Class FrmReportName
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(Me.Owner, FrmPayrollTotalsX).Excel2Reportname = Me.TextBox1.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_BIK = Me.txtBenInKind.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_OtherDed = Me.txtOtherDeductions.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_ReimbOfExp = Me.txtReimbOfexpenses.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_Advances = Me.txtAdvances.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_IncomeTax = Me.txtIncomeTax.Text


        CType(Me.Owner, FrmPayrollTotalsX).R2_D_SI = Me.txtD_SI.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_D_NHS = Me.txtD_NHS.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_C_SI = Me.txtC_SI.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_C_Industrial = Me.txtC_Industrial.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_C_Unemployement = Me.txtC_Unemp.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_C_SocialCohesion = Me.txtC_SocCoh.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_C_NHS = Me.txtC_NHS.Text
        CType(Me.Owner, FrmPayrollTotalsX).R2_D_BikNHS = Me.txtD_BikNHS.Text
        Me.Close()
    End Sub

    

  
  
    Private Sub FrmReportName_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadParameters()
    End Sub
    Private Sub LoadParameters()
        Dim Ds As DataSet
        Dim P As New cPrSsParameters
        Ds = Global1.Business.GetParameter("PA", "BIK")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtBenInKind.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "RIM")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtReimbOfexpenses.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "OTD")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtOtherDeductions.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "ADV")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtAdvances.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "TAX")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtIncomeTax.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "DSI")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtD_SI.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "DGS")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtD_NHS.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "CSI")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtC_SI.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "CGS")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtC_NHS.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "CIN")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtC_Industrial.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "CUN")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtC_Unemp.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "CSC")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtC_SocCoh.Text = P.Value1
        End If
        Ds = Global1.Business.GetParameter("PA", "BNH")
        If CheckDataSet(Ds) Then
            P = New cPrSsParameters(Ds.Tables(0).Rows(0))
            Me.txtD_BikNHS.Text = P.Value1
        End If




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SaveParameters()
    End Sub
    Private Sub SaveParameters()
        Try

        
            Dim P1 As New cPrSsParameters("PA", "BIK")
            With P1
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "BIK"
                .Description = "PA " & .Item
                .Value1 = Me.txtBenInKind.Text
                .Save()
            End With

            Dim P2 As New cPrSsParameters("PA", "RIM")
            With P2
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "RIM"
                .Description = "PA " & .Item
                .Value1 = Me.txtReimbOfexpenses.Text
                .Save()
            End With

            Dim P3 As New cPrSsParameters("PA", "OTD")
            With P3
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "OTD"
                .Description = "PA " & .Item
                .Value1 = Me.txtOtherDeductions.Text
                .Save()
            End With

            Dim P4 As New cPrSsParameters("PA", "ADV")
            With P4
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "ADV"
                .Description = "PA " & .Item
                .Value1 = Me.txtAdvances.Text
                .Save()
            End With

            Dim P5 As New cPrSsParameters("PA", "TAX")
            With P5
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "TAX"
                .Description = "PA " & .Item
                .Value1 = Me.txtIncomeTax.Text
                .Save()
            End With

            Dim P6 As New cPrSsParameters("PA", "DSI")
            With P6
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "DSI"
                .Description = "PA " & .Item
                .Value1 = Me.txtD_SI.Text
                .Save()
            End With

            Dim P7 As New cPrSsParameters("PA", "DGS")
            With P7
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "DGS"
                .Description = "PA " & .Item
                .Value1 = Me.txtD_NHS.Text
                .Save()
            End With

            Dim P8 As New cPrSsParameters("PA", "CSI")
            With P8
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "CSI"
                .Description = "PA " & .Item
                .Value1 = Me.txtC_SI.Text
                .Save()
            End With

            Dim P9 As New cPrSsParameters("PA", "CGS")
            With P9
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "CGS"
                .Description = "PA " & .Item
                .Value1 = Me.txtC_NHS.Text
                .Save()
            End With

            Dim P10 As New cPrSsParameters("PA", "CIN")
            With P10
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "CIN"
                .Description = "PA " & .Item
                .Value1 = Me.txtC_Industrial.Text
                .Save()
            End With

            Dim P11 As New cPrSsParameters("PA", "CUN")
            With P11
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "CUN"
                .Description = "PA " & .Item
                .Value1 = Me.txtC_Unemp.Text
                .Save()
            End With

            Dim P12 As New cPrSsParameters("PA", "CSC")
            With P12
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "CSC"
                .Description = "PA " & .Item
                .Value1 = Me.txtC_SocCoh.Text
                .Save()
            End With


            Dim P13 As New cPrSsParameters("PA", "BNH")
            With P13
                .Type1 = "T"
                .System1 = "Y"
                .Section = "PA"
                .Item = "BNH"
                .Description = "PA " & .Item
                .Value1 = Me.txtD_BikNHS.Text
                .Save()
            End With


            MsgBox("Current Values are Saved", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Failed to Save Current Values", MsgBoxStyle.Information)
        End Try
    End Sub
End Class