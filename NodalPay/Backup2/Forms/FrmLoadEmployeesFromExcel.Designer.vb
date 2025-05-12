<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadEmployeesFromExcel
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
        Me.ComboTempGroups = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboCompBank = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.comboCompanyIBAN = New System.Windows.Forms.ComboBox
        Me.comboPayslip = New System.Windows.Forms.ComboBox
        Me.ComboSI = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBLoadAddress = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'ComboTempGroups
        '
        Me.ComboTempGroups.FormattingEnabled = True
        Me.ComboTempGroups.Location = New System.Drawing.Point(185, 46)
        Me.ComboTempGroups.Name = "ComboTempGroups"
        Me.ComboTempGroups.Size = New System.Drawing.Size(329, 21)
        Me.ComboTempGroups.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Company to Load"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(749, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Company Bank Code"
        '
        'ComboCompBank
        '
        Me.ComboCompBank.FormattingEnabled = True
        Me.ComboCompBank.Location = New System.Drawing.Point(185, 73)
        Me.ComboCompBank.Name = "ComboCompBank"
        Me.ComboCompBank.Size = New System.Drawing.Size(329, 21)
        Me.ComboCompBank.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Company IBAN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Payslip Report"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(791, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(33, 23)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "..."
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(185, 181)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(600, 20)
        Me.txtToFile.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Select File To Upload"
        '
        'comboCompanyIBAN
        '
        Me.comboCompanyIBAN.FormattingEnabled = True
        Me.comboCompanyIBAN.Location = New System.Drawing.Point(185, 100)
        Me.comboCompanyIBAN.Name = "comboCompanyIBAN"
        Me.comboCompanyIBAN.Size = New System.Drawing.Size(329, 21)
        Me.comboCompanyIBAN.TabIndex = 3
        '
        'comboPayslip
        '
        Me.comboPayslip.FormattingEnabled = True
        Me.comboPayslip.Location = New System.Drawing.Point(185, 127)
        Me.comboPayslip.Name = "comboPayslip"
        Me.comboPayslip.Size = New System.Drawing.Size(329, 21)
        Me.comboPayslip.TabIndex = 4
        '
        'ComboSI
        '
        Me.ComboSI.FormattingEnabled = True
        Me.ComboSI.Location = New System.Drawing.Point(185, 154)
        Me.ComboSI.Name = "ComboSI"
        Me.ComboSI.Size = New System.Drawing.Size(329, 21)
        Me.ComboSI.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Social Insurance Rate"
        '
        'CBLoadAddress
        '
        Me.CBLoadAddress.AutoSize = True
        Me.CBLoadAddress.Location = New System.Drawing.Point(185, 220)
        Me.CBLoadAddress.Name = "CBLoadAddress"
        Me.CBLoadAddress.Size = New System.Drawing.Size(91, 17)
        Me.CBLoadAddress.TabIndex = 24
        Me.CBLoadAddress.Text = "Load Address"
        Me.CBLoadAddress.UseVisualStyleBackColor = True
        '
        'FrmLoadEmployeesFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 266)
        Me.Controls.Add(Me.CBLoadAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboSI)
        Me.Controls.Add(Me.comboPayslip)
        Me.Controls.Add(Me.comboCompanyIBAN)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboCompBank)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTempGroups)
        Me.Name = "FrmLoadEmployeesFromExcel"
        Me.Text = "Load Employees From Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboTempGroups As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboCompBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents comboCompanyIBAN As System.Windows.Forms.ComboBox
    Friend WithEvents comboPayslip As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSI As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBLoadAddress As System.Windows.Forms.CheckBox
End Class
