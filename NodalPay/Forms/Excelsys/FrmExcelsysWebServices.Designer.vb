<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmExcelsysWebServices
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtEXLLogin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEXLPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEXLCompany = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEXLFillType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboSI = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboTempGroups = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtCompanyBank = New System.Windows.Forms.TextBox()
        Me.txtCompanyIBAN = New System.Windows.Forms.TextBox()
        Me.txtPayslip = New System.Windows.Forms.TextBox()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateLastUpdate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.btnSendPayslip = New System.Windows.Forms.Button()
        Me.SyncFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(699, 25)
        Me.ToolStrip1.TabIndex = 69
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(467, 549)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 58)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Get Data From Exelsys"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtEXLLogin
        '
        Me.txtEXLLogin.Location = New System.Drawing.Point(219, 58)
        Me.txtEXLLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEXLLogin.Name = "txtEXLLogin"
        Me.txtEXLLogin.ReadOnly = True
        Me.txtEXLLogin.Size = New System.Drawing.Size(437, 22)
        Me.txtEXLLogin.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 17)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Exelsys Login"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 94)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Exelsys Password"
        '
        'txtEXLPass
        '
        Me.txtEXLPass.Location = New System.Drawing.Point(219, 90)
        Me.txtEXLPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEXLPass.Name = "txtEXLPass"
        Me.txtEXLPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEXLPass.ReadOnly = True
        Me.txtEXLPass.Size = New System.Drawing.Size(437, 22)
        Me.txtEXLPass.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 126)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 17)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Exelsys Company"
        '
        'txtEXLCompany
        '
        Me.txtEXLCompany.Location = New System.Drawing.Point(219, 122)
        Me.txtEXLCompany.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEXLCompany.Name = "txtEXLCompany"
        Me.txtEXLCompany.ReadOnly = True
        Me.txtEXLCompany.Size = New System.Drawing.Size(437, 22)
        Me.txtEXLCompany.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 17)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Exelsys Employee Fill Type"
        '
        'txtEXLFillType
        '
        Me.txtEXLFillType.Location = New System.Drawing.Point(219, 154)
        Me.txtEXLFillType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEXLFillType.Name = "txtEXLFillType"
        Me.txtEXLFillType.ReadOnly = True
        Me.txtEXLFillType.Size = New System.Drawing.Size(437, 22)
        Me.txtEXLFillType.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 348)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 17)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Social Insurance Rate"
        '
        'ComboSI
        '
        Me.ComboSI.FormattingEnabled = True
        Me.ComboSI.Location = New System.Drawing.Point(219, 345)
        Me.ComboSI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboSI.Name = "ComboSI"
        Me.ComboSI.Size = New System.Drawing.Size(437, 24)
        Me.ComboSI.TabIndex = 86
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 315)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 17)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Payslip Report"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 282)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 17)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Company IBAN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 249)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 17)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Company Bank Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 215)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 17)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Select Company to Load"
        '
        'ComboTempGroups
        '
        Me.ComboTempGroups.FormattingEnabled = True
        Me.ComboTempGroups.Location = New System.Drawing.Point(219, 212)
        Me.ComboTempGroups.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboTempGroups.Name = "ComboTempGroups"
        Me.ComboTempGroups.Size = New System.Drawing.Size(437, 24)
        Me.ComboTempGroups.TabIndex = 80
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(219, 549)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(191, 58)
        Me.Button2.TabIndex = 93
        Me.Button2.Text = "Get Data From Exelsys DEMO"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'txtCompanyBank
        '
        Me.txtCompanyBank.Location = New System.Drawing.Point(219, 249)
        Me.txtCompanyBank.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCompanyBank.Name = "txtCompanyBank"
        Me.txtCompanyBank.Size = New System.Drawing.Size(437, 22)
        Me.txtCompanyBank.TabIndex = 94
        '
        'txtCompanyIBAN
        '
        Me.txtCompanyIBAN.Location = New System.Drawing.Point(219, 282)
        Me.txtCompanyIBAN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCompanyIBAN.Name = "txtCompanyIBAN"
        Me.txtCompanyIBAN.Size = New System.Drawing.Size(437, 22)
        Me.txtCompanyIBAN.TabIndex = 95
        '
        'txtPayslip
        '
        Me.txtPayslip.Location = New System.Drawing.Point(219, 315)
        Me.txtPayslip.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPayslip.Name = "txtPayslip"
        Me.txtPayslip.Size = New System.Drawing.Size(437, 22)
        Me.txtPayslip.TabIndex = 96
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblLoading.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblLoading.Location = New System.Drawing.Point(215, 507)
        Me.lblLoading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(270, 20)
        Me.lblLoading.TabIndex = 97
        Me.lblLoading.Text = "Please wait , Loading from Exelsys"
        Me.lblLoading.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 384)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Last Update date"
        '
        'DateLastUpdate
        '
        Me.DateLastUpdate.Enabled = False
        Me.DateLastUpdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateLastUpdate.Location = New System.Drawing.Point(219, 378)
        Me.DateLastUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateLastUpdate.Name = "DateLastUpdate"
        Me.DateLastUpdate.Size = New System.Drawing.Size(155, 22)
        Me.DateLastUpdate.TabIndex = 99
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 447)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 17)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Employee Code"
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Location = New System.Drawing.Point(213, 443)
        Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Size = New System.Drawing.Size(161, 22)
        Me.txtEmployeeCode.TabIndex = 101
        '
        'btnSendPayslip
        '
        Me.btnSendPayslip.Location = New System.Drawing.Point(0, 549)
        Me.btnSendPayslip.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSendPayslip.Name = "btnSendPayslip"
        Me.btnSendPayslip.Size = New System.Drawing.Size(135, 58)
        Me.btnSendPayslip.TabIndex = 102
        Me.btnSendPayslip.Text = "Send Payslip Demo"
        Me.btnSendPayslip.UseVisualStyleBackColor = True
        Me.btnSendPayslip.Visible = False
        '
        'SyncFromDate
        '
        Me.SyncFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.SyncFromDate.Location = New System.Drawing.Point(219, 408)
        Me.SyncFromDate.Margin = New System.Windows.Forms.Padding(4)
        Me.SyncFromDate.Name = "SyncFromDate"
        Me.SyncFromDate.Size = New System.Drawing.Size(155, 22)
        Me.SyncFromDate.TabIndex = 104
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 414)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 17)
        Me.Label12.TabIndex = 103
        Me.Label12.Text = "Sync From date"
        '
        'FrmExcelsysWebServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(699, 650)
        Me.Controls.Add(Me.SyncFromDate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnSendPayslip)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateLastUpdate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.txtPayslip)
        Me.Controls.Add(Me.txtCompanyIBAN)
        Me.Controls.Add(Me.txtCompanyBank)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboSI)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ComboTempGroups)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEXLFillType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEXLCompany)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEXLPass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEXLLogin)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmExcelsysWebServices"
        Me.Text = "Interface with Excelsys"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Button1 As Button
    Friend WithEvents txtEXLLogin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEXLPass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEXLCompany As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEXLFillType As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboSI As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboTempGroups As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txtCompanyBank As TextBox
    Friend WithEvents txtCompanyIBAN As TextBox
    Friend WithEvents txtPayslip As TextBox
    Friend WithEvents lblLoading As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DateLastUpdate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmployeeCode As TextBox
    Friend WithEvents btnSendPayslip As Button
    Friend WithEvents SyncFromDate As DateTimePicker
    Friend WithEvents Label12 As Label
End Class
