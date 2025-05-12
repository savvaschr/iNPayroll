<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadsalariesFromExcel
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
        Me.txtSalaryColumnNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmployeeColumnNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox
        Me.btnProceed = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateEff = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtE1Code = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtE1NumInExcel = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtE2Code = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtE2NumInExcel = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtSalaryColumnNo
        '
        Me.txtSalaryColumnNo.Location = New System.Drawing.Point(217, 58)
        Me.txtSalaryColumnNo.Name = "txtSalaryColumnNo"
        Me.txtSalaryColumnNo.Size = New System.Drawing.Size(121, 20)
        Me.txtSalaryColumnNo.TabIndex = 73
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 13)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Salary Column Number in Excel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Employee Code Column Number in Excel"
        '
        'txtEmployeeColumnNo
        '
        Me.txtEmployeeColumnNo.Location = New System.Drawing.Point(217, 32)
        Me.txtEmployeeColumnNo.Name = "txtEmployeeColumnNo"
        Me.txtEmployeeColumnNo.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeeColumnNo.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "First Excel Line to Read"
        '
        'txtFirstLineToRead
        '
        Me.txtFirstLineToRead.Location = New System.Drawing.Point(217, 6)
        Me.txtFirstLineToRead.Name = "txtFirstLineToRead"
        Me.txtFirstLineToRead.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstLineToRead.TabIndex = 67
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(217, 327)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 75
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(786, 285)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 77
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(217, 287)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Select File To Upload"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Salary Effective Date"
        '
        'DateEff
        '
        Me.DateEff.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateEff.Location = New System.Drawing.Point(217, 87)
        Me.DateEff.Name = "DateEff"
        Me.DateEff.Size = New System.Drawing.Size(121, 20)
        Me.DateEff.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Earn 1 Code"
        '
        'txtE1Code
        '
        Me.txtE1Code.Location = New System.Drawing.Point(217, 136)
        Me.txtE1Code.Name = "txtE1Code"
        Me.txtE1Code.Size = New System.Drawing.Size(121, 20)
        Me.txtE1Code.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Earn 1 column Number in Excel"
        '
        'txtE1NumInExcel
        '
        Me.txtE1NumInExcel.Location = New System.Drawing.Point(217, 162)
        Me.txtE1NumInExcel.Name = "txtE1NumInExcel"
        Me.txtE1NumInExcel.Size = New System.Drawing.Size(121, 20)
        Me.txtE1NumInExcel.TabIndex = 89
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Earn 2 Code"
        '
        'txtE2Code
        '
        Me.txtE2Code.Location = New System.Drawing.Point(217, 188)
        Me.txtE2Code.Name = "txtE2Code"
        Me.txtE2Code.Size = New System.Drawing.Size(121, 20)
        Me.txtE2Code.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(156, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Earn 2 Column Number in Excel"
        '
        'txtE2NumInExcel
        '
        Me.txtE2NumInExcel.Location = New System.Drawing.Point(217, 214)
        Me.txtE2NumInExcel.Name = "txtE2NumInExcel"
        Me.txtE2NumInExcel.Size = New System.Drawing.Size(121, 20)
        Me.txtE2NumInExcel.TabIndex = 93
        '
        'FrmLoadsalariesFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 388)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtE2NumInExcel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtE2Code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtE1NumInExcel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtE1Code)
        Me.Controls.Add(Me.DateEff)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSalaryColumnNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmployeeColumnNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstLineToRead)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmLoadsalariesFromExcel"
        Me.Text = "Load Salaries From Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSalaryColumnNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeColumnNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstLineToRead As System.Windows.Forms.TextBox
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateEff As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtE1Code As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtE1NumInExcel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtE2Code As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtE2NumInExcel As System.Windows.Forms.TextBox
End Class
