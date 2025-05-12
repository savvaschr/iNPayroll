<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaymentRequest
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBank = New System.Windows.Forms.TextBox
        Me.txtBankRepresentative = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtKeyTest = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSubscriberNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAccountant = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAdministrator = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtIBAN = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSwift = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBankAccount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.lbldate = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBReport = New System.Windows.Forms.ToolStripButton
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAccountB = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtAccountA = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CBIncludePF = New System.Windows.Forms.CheckBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Bank"
        '
        'txtBank
        '
        Me.txtBank.BackColor = System.Drawing.Color.Yellow
        Me.txtBank.Location = New System.Drawing.Point(179, 59)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.Size = New System.Drawing.Size(264, 20)
        Me.txtBank.TabIndex = 1
        '
        'txtBankRepresentative
        '
        Me.txtBankRepresentative.Location = New System.Drawing.Point(179, 143)
        Me.txtBankRepresentative.Name = "txtBankRepresentative"
        Me.txtBankRepresentative.Size = New System.Drawing.Size(264, 20)
        Me.txtBankRepresentative.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bank Representative"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(179, 164)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(264, 20)
        Me.txtFax.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fax Number"
        '
        'txtKeyTest
        '
        Me.txtKeyTest.Location = New System.Drawing.Point(179, 185)
        Me.txtKeyTest.Name = "txtKeyTest"
        Me.txtKeyTest.Size = New System.Drawing.Size(264, 20)
        Me.txtKeyTest.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Key Test"
        '
        'txtSubscriberNo
        '
        Me.txtSubscriberNo.Location = New System.Drawing.Point(179, 206)
        Me.txtSubscriberNo.Name = "txtSubscriberNo"
        Me.txtSubscriberNo.Size = New System.Drawing.Size(264, 20)
        Me.txtSubscriberNo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Subscriber No."
        '
        'txtAccountant
        '
        Me.txtAccountant.Location = New System.Drawing.Point(179, 311)
        Me.txtAccountant.Name = "txtAccountant"
        Me.txtAccountant.Size = New System.Drawing.Size(264, 20)
        Me.txtAccountant.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 314)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Accountant Name"
        '
        'txtAdministrator
        '
        Me.txtAdministrator.Location = New System.Drawing.Point(179, 332)
        Me.txtAdministrator.Name = "txtAdministrator"
        Me.txtAdministrator.Size = New System.Drawing.Size(264, 20)
        Me.txtAdministrator.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 335)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Administrator Name"
        '
        'txtIBAN
        '
        Me.txtIBAN.Location = New System.Drawing.Point(179, 227)
        Me.txtIBAN.Name = "txtIBAN"
        Me.txtIBAN.Size = New System.Drawing.Size(264, 20)
        Me.txtIBAN.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "IBAN Code"
        '
        'txtSwift
        '
        Me.txtSwift.Location = New System.Drawing.Point(179, 248)
        Me.txtSwift.Name = "txtSwift"
        Me.txtSwift.Size = New System.Drawing.Size(264, 20)
        Me.txtSwift.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 251)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "SWIFT"
        '
        'txtBankAccount
        '
        Me.txtBankAccount.BackColor = System.Drawing.Color.Yellow
        Me.txtBankAccount.Location = New System.Drawing.Point(179, 80)
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.ReadOnly = True
        Me.txtBankAccount.Size = New System.Drawing.Size(264, 20)
        Me.txtBankAccount.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Company Bank Account"
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.Yellow
        Me.txtCompany.Location = New System.Drawing.Point(179, 38)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = True
        Me.txtCompany.Size = New System.Drawing.Size(264, 20)
        Me.txtCompany.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Company"
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.Yellow
        Me.txtDate.Location = New System.Drawing.Point(179, 101)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(264, 20)
        Me.txtDate.TabIndex = 3
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Location = New System.Drawing.Point(37, 104)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(106, 13)
        Me.lbldate.TabIndex = 22
        Me.lbldate.Text = "Requested Pay Date"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(498, 25)
        Me.ToolStrip1.TabIndex = 67
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBReport
        '
        Me.TSBReport.AutoSize = False
        Me.TSBReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBReport.Name = "TSBReport"
        Me.TSBReport.Size = New System.Drawing.Size(80, 22)
        Me.TSBReport.Text = "Show Report"
        Me.TSBReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRefNo
        '
        Me.txtRefNo.BackColor = System.Drawing.Color.Yellow
        Me.txtRefNo.Location = New System.Drawing.Point(179, 122)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.ReadOnly = True
        Me.txtRefNo.Size = New System.Drawing.Size(264, 20)
        Me.txtRefNo.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(37, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Reference No."
        '
        'txtAccountB
        '
        Me.txtAccountB.Location = New System.Drawing.Point(179, 290)
        Me.txtAccountB.Name = "txtAccountB"
        Me.txtAccountB.Size = New System.Drawing.Size(264, 20)
        Me.txtAccountB.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 293)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "PF B Account No"
        '
        'txtAccountA
        '
        Me.txtAccountA.Location = New System.Drawing.Point(179, 269)
        Me.txtAccountA.Name = "txtAccountA"
        Me.txtAccountA.Size = New System.Drawing.Size(264, 20)
        Me.txtAccountA.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 272)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "PF A Account No"
        '
        'CBIncludePF
        '
        Me.CBIncludePF.AutoSize = True
        Me.CBIncludePF.Location = New System.Drawing.Point(179, 367)
        Me.CBIncludePF.Name = "CBIncludePF"
        Me.CBIncludePF.Size = New System.Drawing.Size(229, 17)
        Me.CBIncludePF.TabIndex = 73
        Me.CBIncludePF.Text = "INCLUDE PROVIDENT FUND AMOUNTS"
        Me.CBIncludePF.UseVisualStyleBackColor = True
        '
        'FrmPaymentRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(498, 409)
        Me.Controls.Add(Me.CBIncludePF)
        Me.Controls.Add(Me.txtAccountB)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtAccountA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtBankAccount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSwift)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIBAN)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAdministrator)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAccountant)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSubscriberNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtKeyTest)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBankRepresentative)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPaymentRequest"
        Me.Text = "Payroll Payment Request"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents txtBankRepresentative As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKeyTest As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubscriberNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAccountant As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAdministrator As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIBAN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSwift As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBankAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAccountB As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAccountA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CBIncludePF As System.Windows.Forms.CheckBox
End Class
