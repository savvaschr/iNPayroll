<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIR61_2019
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIR61_2019))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtAIW2 = New System.Windows.Forms.TextBox()
        Me.txtTaxMonth = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTaxYear = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAdr2 = New System.Windows.Forms.TextBox()
        Me.txtChequeNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAIW1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtITAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAdr1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCompName = New System.Windows.Forms.TextBox()
        Me.TSBSendToPrinter = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TSBReport = New System.Windows.Forms.ToolStripButton()
        Me.txtTAXId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSIPeriod = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CreateMonthlyFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateMonthlyFileWithExcelReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGesyCon = New System.Windows.Forms.TextBox()
        Me.txtGesyDed = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTaxableIncome = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PanelLoading = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 329)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Total Amount"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Aqua
        Me.txtTotal.Location = New System.Drawing.Point(152, 323)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtTotal.TabIndex = 139
        '
        'txtAIW2
        '
        Me.txtAIW2.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW2.Location = New System.Drawing.Point(152, 375)
        Me.txtAIW2.MaxLength = 40
        Me.txtAIW2.Name = "txtAIW2"
        Me.txtAIW2.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW2.TabIndex = 119
        '
        'txtTaxMonth
        '
        Me.txtTaxMonth.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxMonth.Location = New System.Drawing.Point(152, 193)
        Me.txtTaxMonth.Name = "txtTaxMonth"
        Me.txtTaxMonth.ReadOnly = True
        Me.txtTaxMonth.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxMonth.TabIndex = 136
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Tax Month"
        '
        'txtTaxYear
        '
        Me.txtTaxYear.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxYear.Location = New System.Drawing.Point(152, 167)
        Me.txtTaxYear.Name = "txtTaxYear"
        Me.txtTaxYear.ReadOnly = True
        Me.txtTaxYear.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxYear.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Tax Year"
        '
        'txtAdr2
        '
        Me.txtAdr2.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr2.Location = New System.Drawing.Point(152, 141)
        Me.txtAdr2.Name = "txtAdr2"
        Me.txtAdr2.ReadOnly = True
        Me.txtAdr2.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr2.TabIndex = 132
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(152, 417)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(141, 20)
        Me.txtChequeNo.TabIndex = 120
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 423)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Cheque Number if Used"
        '
        'txtAIW1
        '
        Me.txtAIW1.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW1.Location = New System.Drawing.Point(152, 349)
        Me.txtAIW1.MaxLength = 40
        Me.txtAIW1.Name = "txtAIW1"
        Me.txtAIW1.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW1.TabIndex = 118
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 355)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Amount in Words"
        '
        'txtITAmount
        '
        Me.txtITAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtITAmount.Location = New System.Drawing.Point(152, 245)
        Me.txtITAmount.Name = "txtITAmount"
        Me.txtITAmount.ReadOnly = True
        Me.txtITAmount.Size = New System.Drawing.Size(141, 20)
        Me.txtITAmount.TabIndex = 129
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "I.T Amount"
        '
        'txtAdr1
        '
        Me.txtAdr1.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr1.Location = New System.Drawing.Point(152, 115)
        Me.txtAdr1.Name = "txtAdr1"
        Me.txtAdr1.ReadOnly = True
        Me.txtAdr1.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr1.TabIndex = 127
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Company Address"
        '
        'txtCompName
        '
        Me.txtCompName.BackColor = System.Drawing.SystemColors.Info
        Me.txtCompName.Location = New System.Drawing.Point(152, 89)
        Me.txtCompName.Name = "txtCompName"
        Me.txtCompName.ReadOnly = True
        Me.txtCompName.Size = New System.Drawing.Size(374, 20)
        Me.txtCompName.TabIndex = 125
        '
        'TSBSendToPrinter
        '
        Me.TSBSendToPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBSendToPrinter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSendToPrinter.Name = "TSBSendToPrinter"
        Me.TSBSendToPrinter.Size = New System.Drawing.Size(91, 22)
        Me.TSBSendToPrinter.Text = "Send To Printer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Company Name"
        '
        'TSBReport
        '
        Me.TSBReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBReport.Name = "TSBReport"
        Me.TSBReport.Size = New System.Drawing.Size(95, 22)
        Me.TSBReport.Text = "Show on Screen"
        '
        'txtTAXId
        '
        Me.txtTAXId.BackColor = System.Drawing.SystemColors.Info
        Me.txtTAXId.Location = New System.Drawing.Point(152, 63)
        Me.txtTAXId.Name = "txtTAXId"
        Me.txtTAXId.ReadOnly = True
        Me.txtTAXId.Size = New System.Drawing.Size(141, 20)
        Me.txtTAXId.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Company Tax ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Social Insurance Period"
        '
        'CmbSIPeriod
        '
        Me.CmbSIPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSIPeriod.FormattingEnabled = True
        Me.CmbSIPeriod.Location = New System.Drawing.Point(152, 35)
        Me.CmbSIPeriod.Name = "CmbSIPeriod"
        Me.CmbSIPeriod.Size = New System.Drawing.Size(374, 21)
        Me.CmbSIPeriod.TabIndex = 117
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBReport, Me.TSBSendToPrinter, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(615, 25)
        Me.ToolStrip1.TabIndex = 116
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateMonthlyFileToolStripMenuItem, Me.CreateMonthlyFileWithExcelReportToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(149, 22)
        Me.ToolStripDropDownButton1.Text = "Monthly .xml File to TAX"
        '
        'CreateMonthlyFileToolStripMenuItem
        '
        Me.CreateMonthlyFileToolStripMenuItem.Name = "CreateMonthlyFileToolStripMenuItem"
        Me.CreateMonthlyFileToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.CreateMonthlyFileToolStripMenuItem.Text = "Create Monthly File"
        '
        'CreateMonthlyFileWithExcelReportToolStripMenuItem
        '
        Me.CreateMonthlyFileWithExcelReportToolStripMenuItem.Name = "CreateMonthlyFileWithExcelReportToolStripMenuItem"
        Me.CreateMonthlyFileWithExcelReportToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.CreateMonthlyFileWithExcelReportToolStripMenuItem.Text = "Create Monthly File With Excel Report"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(131, 13)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "G.H.S. Contribution (0711)"
        '
        'txtGesyCon
        '
        Me.txtGesyCon.BackColor = System.Drawing.SystemColors.Info
        Me.txtGesyCon.Location = New System.Drawing.Point(152, 271)
        Me.txtGesyCon.Name = "txtGesyCon"
        Me.txtGesyCon.ReadOnly = True
        Me.txtGesyCon.Size = New System.Drawing.Size(141, 20)
        Me.txtGesyCon.TabIndex = 147
        '
        'txtGesyDed
        '
        Me.txtGesyDed.BackColor = System.Drawing.SystemColors.Info
        Me.txtGesyDed.Location = New System.Drawing.Point(152, 297)
        Me.txtGesyDed.Name = "txtGesyDed"
        Me.txtGesyDed.ReadOnly = True
        Me.txtGesyDed.Size = New System.Drawing.Size(141, 20)
        Me.txtGesyDed.TabIndex = 146
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 277)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 13)
        Me.Label15.TabIndex = 145
        Me.Label15.Text = "G.H.S. Deduction (0701)"
        '
        'txtTaxableIncome
        '
        Me.txtTaxableIncome.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxableIncome.Location = New System.Drawing.Point(152, 219)
        Me.txtTaxableIncome.Name = "txtTaxableIncome"
        Me.txtTaxableIncome.ReadOnly = True
        Me.txtTaxableIncome.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxableIncome.TabIndex = 149
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Taxable Income"
        '
        'PanelLoading
        '
        Me.PanelLoading.BackColor = System.Drawing.SystemColors.Window
        Me.PanelLoading.Controls.Add(Me.Label12)
        Me.PanelLoading.Location = New System.Drawing.Point(76, 154)
        Me.PanelLoading.Name = "PanelLoading"
        Me.PanelLoading.Size = New System.Drawing.Size(477, 100)
        Me.PanelLoading.TabIndex = 151
        Me.PanelLoading.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label12.Location = New System.Drawing.Point(79, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(192, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Loading Values , Please wait ..."
        '
        'FrmIR61_2019
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(615, 566)
        Me.Controls.Add(Me.PanelLoading)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTaxableIncome)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtGesyCon)
        Me.Controls.Add(Me.txtGesyDed)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotal)
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
        Me.Name = "FrmIR61_2019"
        Me.Text = "IR61 Report for 2019 and onwards"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelLoading.ResumeLayout(False)
        Me.PanelLoading.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
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
    Friend WithEvents TSBSendToPrinter As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TSBReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtTAXId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSIPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGesyCon As System.Windows.Forms.TextBox
    Friend WithEvents txtGesyDed As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTaxableIncome As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PanelLoading As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents CreateMonthlyFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateMonthlyFileWithExcelReportToolStripMenuItem As ToolStripMenuItem
End Class
