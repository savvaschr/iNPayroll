<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadOvertimesFromExcel1
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmployeeTotalLen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmployeeColumnNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox
        Me.btnProceed = New System.Windows.Forms.Button
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEDCCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEmployeePrefix = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "TimeOff Code in Payroll"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Employee Total Lenght"
        '
        'txtEmployeeTotalLen
        '
        Me.txtEmployeeTotalLen.Location = New System.Drawing.Point(217, 56)
        Me.txtEmployeeTotalLen.Name = "txtEmployeeTotalLen"
        Me.txtEmployeeTotalLen.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeeTotalLen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Employee Code Column Number in Excel"
        '
        'txtEmployeeColumnNo
        '
        Me.txtEmployeeColumnNo.Location = New System.Drawing.Point(217, 32)
        Me.txtEmployeeColumnNo.Name = "txtEmployeeColumnNo"
        Me.txtEmployeeColumnNo.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeeColumnNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "First Excel Line to Read"
        '
        'txtFirstLineToRead
        '
        Me.txtFirstLineToRead.Location = New System.Drawing.Point(217, 6)
        Me.txtFirstLineToRead.Name = "txtFirstLineToRead"
        Me.txtFirstLineToRead.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstLineToRead.TabIndex = 1
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(217, 174)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 7
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(786, 132)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 37
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(217, 134)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Select File To Upload"
        '
        'txtEDCCode
        '
        Me.txtEDCCode.Location = New System.Drawing.Point(217, 108)
        Me.txtEDCCode.Name = "txtEDCCode"
        Me.txtEDCCode.Size = New System.Drawing.Size(121, 20)
        Me.txtEDCCode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Employee Prefix Character"
        '
        'txtEmployeePrefix
        '
        Me.txtEmployeePrefix.Location = New System.Drawing.Point(217, 82)
        Me.txtEmployeePrefix.Name = "txtEmployeePrefix"
        Me.txtEmployeePrefix.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeePrefix.TabIndex = 4
        '
        'FrmLoadOvertimesFormExcel1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 214)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmployeePrefix)
        Me.Controls.Add(Me.txtEDCCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmployeeTotalLen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmployeeColumnNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstLineToRead)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmLoadOvertimesFormExcel1"
        Me.Text = "Load Overtimes Form Excel1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeTotalLen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeColumnNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstLineToRead As System.Windows.Forms.TextBox
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEDCCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeePrefix As System.Windows.Forms.TextBox
End Class
