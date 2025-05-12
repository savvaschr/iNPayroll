<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIR112
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
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
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
        Me.TSBSendToPrinter = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TSBReport = New System.Windows.Forms.ToolStripButton
        Me.txtTAXId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbSIPeriod = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Total Amount"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Aqua
        Me.txtTotal.Location = New System.Drawing.Point(153, 338)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtTotal.TabIndex = 139
        '
        'txtAIW2
        '
        Me.txtAIW2.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW2.Location = New System.Drawing.Point(153, 390)
        Me.txtAIW2.MaxLength = 40
        Me.txtAIW2.Name = "txtAIW2"
        Me.txtAIW2.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW2.TabIndex = 119
        '
        'txtTaxMonth
        '
        Me.txtTaxMonth.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxMonth.Location = New System.Drawing.Point(152, 192)
        Me.txtTaxMonth.Name = "txtTaxMonth"
        Me.txtTaxMonth.ReadOnly = True
        Me.txtTaxMonth.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxMonth.TabIndex = 136
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 198)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Tax Month"
        '
        'txtTaxYear
        '
        Me.txtTaxYear.BackColor = System.Drawing.SystemColors.Info
        Me.txtTaxYear.Location = New System.Drawing.Point(152, 166)
        Me.txtTaxYear.Name = "txtTaxYear"
        Me.txtTaxYear.ReadOnly = True
        Me.txtTaxYear.Size = New System.Drawing.Size(141, 20)
        Me.txtTaxYear.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Tax Year"
        '
        'txtAdr2
        '
        Me.txtAdr2.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr2.Location = New System.Drawing.Point(152, 140)
        Me.txtAdr2.Name = "txtAdr2"
        Me.txtAdr2.ReadOnly = True
        Me.txtAdr2.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr2.TabIndex = 132
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(153, 430)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(141, 20)
        Me.txtChequeNo.TabIndex = 120
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 436)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Cheque Number if Used"
        '
        'txtAIW1
        '
        Me.txtAIW1.BackColor = System.Drawing.Color.Aqua
        Me.txtAIW1.Location = New System.Drawing.Point(153, 364)
        Me.txtAIW1.MaxLength = 40
        Me.txtAIW1.Name = "txtAIW1"
        Me.txtAIW1.Size = New System.Drawing.Size(374, 20)
        Me.txtAIW1.TabIndex = 118
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 370)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Amount in Words"
        '
        'txtITAmount
        '
        Me.txtITAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtITAmount.Location = New System.Drawing.Point(152, 218)
        Me.txtITAmount.Name = "txtITAmount"
        Me.txtITAmount.ReadOnly = True
        Me.txtITAmount.Size = New System.Drawing.Size(141, 20)
        Me.txtITAmount.TabIndex = 129
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Salary Decreace"
        '
        'txtAdr1
        '
        Me.txtAdr1.BackColor = System.Drawing.SystemColors.Info
        Me.txtAdr1.Location = New System.Drawing.Point(152, 114)
        Me.txtAdr1.Name = "txtAdr1"
        Me.txtAdr1.ReadOnly = True
        Me.txtAdr1.Size = New System.Drawing.Size(374, 20)
        Me.txtAdr1.TabIndex = 127
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Company Address"
        '
        'txtCompName
        '
        Me.txtCompName.BackColor = System.Drawing.SystemColors.Info
        Me.txtCompName.Location = New System.Drawing.Point(152, 88)
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
        Me.TSBSendToPrinter.Size = New System.Drawing.Size(92, 22)
        Me.TSBSendToPrinter.Text = "Send To Printer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 94)
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
        Me.txtTAXId.Location = New System.Drawing.Point(152, 62)
        Me.txtTAXId.Name = "txtTAXId"
        Me.txtTAXId.ReadOnly = True
        Me.txtTAXId.Size = New System.Drawing.Size(141, 20)
        Me.txtTAXId.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Company Tax ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Social Insurance Period"
        '
        'CmbSIPeriod
        '
        Me.CmbSIPeriod.FormattingEnabled = True
        Me.CmbSIPeriod.Location = New System.Drawing.Point(152, 34)
        Me.CmbSIPeriod.Name = "CmbSIPeriod"
        Me.CmbSIPeriod.Size = New System.Drawing.Size(267, 21)
        Me.CmbSIPeriod.TabIndex = 117
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBReport, Me.TSBSendToPrinter})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(543, 25)
        Me.ToolStrip1.TabIndex = 116
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FrmIR112
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 493)
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
        Me.Name = "FrmIR112"
        Me.Text = "FrmIR112"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
End Class
