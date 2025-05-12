<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadOvertimesFromExcel2
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
        Me.txtEmployeePrefix = New System.Windows.Forms.TextBox
        Me.txtColOv1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmployeeTotalLen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmployeeColumnNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox
        Me.btnProceed = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtColOv2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtColOv3 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Employee Prefix Character"
        '
        'txtEmployeePrefix
        '
        Me.txtEmployeePrefix.Location = New System.Drawing.Point(217, 82)
        Me.txtEmployeePrefix.Name = "txtEmployeePrefix"
        Me.txtEmployeePrefix.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeePrefix.TabIndex = 4
        '
        'txtColOv1
        '
        Me.txtColOv1.Location = New System.Drawing.Point(217, 108)
        Me.txtColOv1.Name = "txtColOv1"
        Me.txtColOv1.Size = New System.Drawing.Size(121, 20)
        Me.txtColOv1.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Overtime 1 Column Number in Excel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 60
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
        Me.Label3.TabIndex = 59
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
        Me.Label2.TabIndex = 58
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
        Me.btnProceed.Location = New System.Drawing.Point(218, 229)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 55
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(787, 187)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 57
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(218, 189)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Select File To Upload"
        '
        'txtColOv2
        '
        Me.txtColOv2.Location = New System.Drawing.Point(217, 134)
        Me.txtColOv2.Name = "txtColOv2"
        Me.txtColOv2.Size = New System.Drawing.Size(121, 20)
        Me.txtColOv2.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Overtime 2 Column Number in Excel"
        '
        'txtColOv3
        '
        Me.txtColOv3.Location = New System.Drawing.Point(217, 160)
        Me.txtColOv3.Name = "txtColOv3"
        Me.txtColOv3.Size = New System.Drawing.Size(121, 20)
        Me.txtColOv3.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Overtime 3 Column Number in Excel"
        '
        'FrmLoadOvertimesFromExcel2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 268)
        Me.Controls.Add(Me.txtColOv3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtColOv2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmployeePrefix)
        Me.Controls.Add(Me.txtColOv1)
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
        Me.Name = "FrmLoadOvertimesFromExcel2"
        Me.Text = "Load Overtime From Excel 2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeePrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtColOv1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeTotalLen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeColumnNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstLineToRead As System.Windows.Forms.TextBox
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtColOv2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtColOv3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
End Class
