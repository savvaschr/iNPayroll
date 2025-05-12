<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDisLFFE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.PeriodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Discount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LifeInsurance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FirstEmployment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxableIncome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PeriodSplit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIonPeriodSplit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxableFromOther = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnualUnits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtP = New System.Windows.Forms.TextBox
        Me.txtFE = New System.Windows.Forms.TextBox
        Me.txtLI = New System.Windows.Forms.TextBox
        Me.txtD = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTI = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTaxableFromOther = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPeriodSplit = New System.Windows.Forms.TextBox
        Me.txtSIonPeriodSplit = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAnnualUnits = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PeriodCode, Me.Discount, Me.LifeInsurance, Me.FirstEmployment, Me.TaxableIncome, Me.PeriodSplit, Me.SIonPeriodSplit, Me.TaxableFromOther, Me.AnnualUnits})
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(12, 21)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(946, 335)
        Me.DG1.TabIndex = 0
        '
        'PeriodCode
        '
        Me.PeriodCode.DataPropertyName = "PrdCod_Code"
        Me.PeriodCode.HeaderText = "Period Code"
        Me.PeriodCode.Name = "PeriodCode"
        '
        'Discount
        '
        Me.Discount.DataPropertyName = "TrxHdr_Discounts"
        Me.Discount.HeaderText = "Discount"
        Me.Discount.Name = "Discount"
        '
        'LifeInsurance
        '
        Me.LifeInsurance.DataPropertyName = "TrxHdr_LifeInsurance"
        Me.LifeInsurance.HeaderText = "Life Insurance"
        Me.LifeInsurance.Name = "LifeInsurance"
        '
        'FirstEmployment
        '
        Me.FirstEmployment.DataPropertyName = "TrxHdr_FE"
        Me.FirstEmployment.HeaderText = "First Employment"
        Me.FirstEmployment.Name = "FirstEmployment"
        '
        'TaxableIncome
        '
        Me.TaxableIncome.DataPropertyName = "TrxHdr_TaxableIncome"
        Me.TaxableIncome.HeaderText = "Taxable Income"
        Me.TaxableIncome.Name = "TaxableIncome"
        '
        'PeriodSplit
        '
        Me.PeriodSplit.DataPropertyName = "trxHdr_PeriodSplit"
        Me.PeriodSplit.HeaderText = "Period Split"
        Me.PeriodSplit.Name = "PeriodSplit"
        '
        'SIonPeriodSplit
        '
        Me.SIonPeriodSplit.DataPropertyName = "trxHdr_PeriodSplitSI"
        Me.SIonPeriodSplit.HeaderText = "SI on PeriodSplit"
        Me.SIonPeriodSplit.Name = "SIonPeriodSplit"
        '
        'TaxableFromOther
        '
        Me.TaxableFromOther.DataPropertyName = "trxHdr_TaxableFromOther"
        Me.TaxableFromOther.HeaderText = "Taxable From Other Sources"
        Me.TaxableFromOther.Name = "TaxableFromOther"
        '
        'AnnualUnits
        '
        Me.AnnualUnits.DataPropertyName = "TrxHdr_AnnualUnits"
        Me.AnnualUnits.HeaderText = "Annual Units"
        Me.AnnualUnits.Name = "AnnualUnits"
        '
        'txtP
        '
        Me.txtP.Location = New System.Drawing.Point(192, 378)
        Me.txtP.Name = "txtP"
        Me.txtP.ReadOnly = True
        Me.txtP.Size = New System.Drawing.Size(100, 20)
        Me.txtP.TabIndex = 1
        Me.txtP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFE
        '
        Me.txtFE.Location = New System.Drawing.Point(192, 456)
        Me.txtFE.Name = "txtFE"
        Me.txtFE.Size = New System.Drawing.Size(100, 20)
        Me.txtFE.TabIndex = 2
        Me.txtFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLI
        '
        Me.txtLI.Location = New System.Drawing.Point(192, 430)
        Me.txtLI.Name = "txtLI"
        Me.txtLI.Size = New System.Drawing.Size(100, 20)
        Me.txtLI.TabIndex = 3
        Me.txtLI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtD
        '
        Me.txtD.Location = New System.Drawing.Point(192, 404)
        Me.txtD.Name = "txtD"
        Me.txtD.Size = New System.Drawing.Size(100, 20)
        Me.txtD.TabIndex = 4
        Me.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(317, 378)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Period Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 411)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Period Discount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Period LifeInsurance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 463)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Period First Employement"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 489)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Period TxableIncome"
        '
        'txtTI
        '
        Me.txtTI.Location = New System.Drawing.Point(192, 482)
        Me.txtTI.Name = "txtTI"
        Me.txtTI.Size = New System.Drawing.Size(100, 20)
        Me.txtTI.TabIndex = 10
        Me.txtTI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(317, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Update Taxable Income"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(678, 433)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Taxable From Other"
        '
        'txtTaxableFromOther
        '
        Me.txtTaxableFromOther.Location = New System.Drawing.Point(858, 426)
        Me.txtTaxableFromOther.Name = "txtTaxableFromOther"
        Me.txtTaxableFromOther.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxableFromOther.TabIndex = 17
        Me.txtTaxableFromOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(678, 407)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "SI on Period Split"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(678, 381)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Period Split"
        '
        'txtPeriodSplit
        '
        Me.txtPeriodSplit.Location = New System.Drawing.Point(858, 374)
        Me.txtPeriodSplit.Name = "txtPeriodSplit"
        Me.txtPeriodSplit.Size = New System.Drawing.Size(100, 20)
        Me.txtPeriodSplit.TabIndex = 14
        Me.txtPeriodSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSIonPeriodSplit
        '
        Me.txtSIonPeriodSplit.Location = New System.Drawing.Point(858, 400)
        Me.txtSIonPeriodSplit.Name = "txtSIonPeriodSplit"
        Me.txtSIonPeriodSplit.Size = New System.Drawing.Size(100, 20)
        Me.txtSIonPeriodSplit.TabIndex = 13
        Me.txtSIonPeriodSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(883, 458)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Update"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(734, 489)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(224, 48)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Change Place of Taxable with Period Split and Calculate SI on Split"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 515)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Annual Units"
        '
        'txtAnnualUnits
        '
        Me.txtAnnualUnits.Location = New System.Drawing.Point(192, 508)
        Me.txtAnnualUnits.Name = "txtAnnualUnits"
        Me.txtAnnualUnits.Size = New System.Drawing.Size(100, 20)
        Me.txtAnnualUnits.TabIndex = 21
        Me.txtAnnualUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(317, 511)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(157, 23)
        Me.Button5.TabIndex = 23
        Me.Button5.Text = "Update Annual Units"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'FrmDisLFFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(970, 549)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAnnualUnits)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTaxableFromOther)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPeriodSplit)
        Me.Controls.Add(Me.txtSIonPeriodSplit)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtD)
        Me.Controls.Add(Me.txtLI)
        Me.Controls.Add(Me.txtFE)
        Me.Controls.Add(Me.txtP)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmDisLFFE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Discounts / Life Insurance / First Employment"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtP As System.Windows.Forms.TextBox
    Friend WithEvents txtFE As System.Windows.Forms.TextBox
    Friend WithEvents txtLI As System.Windows.Forms.TextBox
    Friend WithEvents txtD As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTI As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTaxableFromOther As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodSplit As System.Windows.Forms.TextBox
    Friend WithEvents txtSIonPeriodSplit As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAnnualUnits As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PeriodCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LifeInsurance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirstEmployment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxableIncome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodSplit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIonPeriodSplit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxableFromOther As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnualUnits As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
