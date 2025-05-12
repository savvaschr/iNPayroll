<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIR61_2012
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBReport = New System.Windows.Forms.ToolStripButton
        Me.TSBSendToPrinter = New System.Windows.Forms.ToolStripButton
        Me.txtAIW2 = New System.Windows.Forms.TextBox
        Me.txtTaxMonth = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTaxYear = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAdr2 = New System.Windows.Forms.TextBox
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAIW1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtITAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAdr1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCompName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTAXId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbSIPeriod = New System.Windows.Forms.ComboBox
        Me.txtSPTaxD = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSPTaxC = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSPTotal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBReport, Me.TSBSendToPrinter})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 71
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBReport
        '
        Me.TSBReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBReport.Name = "TSBReport"
        Me.TSBReport.Size = New System.Drawing.Size(95, 22)
        Me.TSBReport.Text = "Show on Screen"
        '
        'TSBSendToPrinter
        '
        Me.TSBSendToPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBSendToPrinter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSendToPrinter.Name = "TSBSendToPrinter"
        Me.TSBSendToPrinter.Size = New System.Drawing.Size(92, 22)
        Me.TSBSendToPrinter.Text = "Send To Printer"
        '
        'txtAIW2
        '
        Me.txtAIW2.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW2.Location = New System.Drawing.Point(141, 391)
        Me.txtAIW2.MaxLength = 40
        Me.txtAIW2.Name = "txtAIW2"
        Me.txtAIW2.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW2.TabIndex = 90
        '
        'txtTaxMonth
        '
        Me.txtTaxMonth.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxMonth.Location = New System.Drawing.Point(140, 193)
        Me.txtTaxMonth.Name = "txtTaxMonth"
        Me.txtTaxMonth.ReadOnly = True
        Me.txtTaxMonth.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxMonth.TabIndex = 107
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(0, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Tax Month"
        '
        'txtTaxYear
        '
        Me.txtTaxYear.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxYear.Location = New System.Drawing.Point(140, 167)
        Me.txtTaxYear.Name = "txtTaxYear"
        Me.txtTaxYear.ReadOnly = True
        Me.txtTaxYear.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxYear.TabIndex = 105
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Tax Year"
        '
        'txtAdr2
        '
        Me.txtAdr2.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr2.Location = New System.Drawing.Point(140, 141)
        Me.txtAdr2.Name = "txtAdr2"
        Me.txtAdr2.ReadOnly = True
        Me.txtAdr2.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr2.TabIndex = 103
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(141, 431)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(141, 20)
        Me.txtChequeNo.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 437)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Cheque Number if Used"
        '
        'txtAIW1
        '
        Me.txtAIW1.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW1.Location = New System.Drawing.Point(141, 365)
        Me.txtAIW1.MaxLength = 40
        Me.txtAIW1.Name = "txtAIW1"
        Me.txtAIW1.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW1.TabIndex = 89
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 371)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Amount in Words"
        '
        'txtITAmount
        '
        Me.txtITAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtITAmount.Location = New System.Drawing.Point(140, 219)
        Me.txtITAmount.Name = "txtITAmount"
        Me.txtITAmount.ReadOnly = True
        Me.txtITAmount.Size = New System.Drawing.Size(141, 20)
        Me.txtITAmount.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "I.T Amount"
        '
        'txtAdr1
        '
        Me.txtAdr1.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr1.Location = New System.Drawing.Point(140, 115)
        Me.txtAdr1.Name = "txtAdr1"
        Me.txtAdr1.ReadOnly = True
        Me.txtAdr1.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr1.TabIndex = 98
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Company Address"
        '
        'txtCompName
        '
        Me.txtCompName.BackColor = System.Drawing.SystemColors.Info
        Me.txtCompName.Location = New System.Drawing.Point(140, 89)
        Me.txtCompName.Name = "txtCompName"
        Me.txtCompName.ReadOnly = True
        Me.txtCompName.Size = New System.Drawing.Size(374, 20)
        Me.txtCompName.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Company Name"
        '
        'txtTAXId
        '
        Me.txtTAXId.BackColor = System.Drawing.SystemColors.Info
        Me.txtTAXId.Location = New System.Drawing.Point(140, 63)
        Me.txtTAXId.Name = "txtTAXId"
        Me.txtTAXId.ReadOnly = True
        Me.txtTAXId.Size = New System.Drawing.Size(141, 20)
        Me.txtTAXId.TabIndex = 94
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Company Tax ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Social Insurance Period"
        '
        'CmbSIPeriod
        '
        Me.CmbSIPeriod.FormattingEnabled = True
        Me.CmbSIPeriod.Location = New System.Drawing.Point(140, 35)
        Me.CmbSIPeriod.Name = "CmbSIPeriod"
        Me.CmbSIPeriod.Size = New System.Drawing.Size(267, 21)
        Me.CmbSIPeriod.TabIndex = 88
        '
        'txtSPTaxD
        '
        Me.txtSPTaxD.BackColor = System.Drawing.SystemColors.Info
        Me.txtSPTaxD.Location = New System.Drawing.Point(140, 245)
        Me.txtSPTaxD.Name = "txtSPTaxD"
        Me.txtSPTaxD.ReadOnly = True
        Me.txtSPTaxD.Size = New System.Drawing.Size(141, 20)
        Me.txtSPTaxD.TabIndex = 109
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(0, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 13)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "Special Tax DEDUCTION"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Aqua
        Me.txtTotal.Location = New System.Drawing.Point(141, 339)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtTotal.TabIndex = 110
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1, 345)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "Total Amount"
        '
        'txtSPTaxC
        '
        Me.txtSPTaxC.BackColor = System.Drawing.SystemColors.Info
        Me.txtSPTaxC.Location = New System.Drawing.Point(140, 271)
        Me.txtSPTaxC.Name = "txtSPTaxC"
        Me.txtSPTaxC.ReadOnly = True
        Me.txtSPTaxC.Size = New System.Drawing.Size(141, 20)
        Me.txtSPTaxC.TabIndex = 113
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(0, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 13)
        Me.Label12.TabIndex = 112
        Me.Label12.Text = "Special Tax CONTR/TION"
        '
        'txtSPTotal
        '
        Me.txtSPTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtSPTotal.Location = New System.Drawing.Point(141, 297)
        Me.txtSPTotal.Name = "txtSPTotal"
        Me.txtSPTotal.ReadOnly = True
        Me.txtSPTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtSPTotal.TabIndex = 114
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 300)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "Special Tax TOTAL"
        '
        'FrmIR61_2012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 493)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSPTotal)
        Me.Controls.Add(Me.txtSPTaxC)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtSPTaxD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtAIW2)
        Me.Controls.Add(Me.txtTaxMonth)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTaxYear)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAdr2)
        Me.Controls.Add(Me.txtChequeNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAIW1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtITAmount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAdr1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCompName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTAXId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbSIPeriod)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmIR61_2012"
        Me.Text = "I.R.61 2012 and above"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtAIW2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTaxYear As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAdr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAIW1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtITAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAdr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCompName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTAXId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSIPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents txtSPTaxD As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSPTaxC As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSPTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TSBSendToPrinter As System.Windows.Forms.ToolStripButton
End Class
