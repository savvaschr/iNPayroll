<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadKELIO1
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
        Me.txtOverTime1Column = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtKelioPrefix = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox
        Me.btnProceed = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOvertime2Column = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPMOver1Column = New System.Windows.Forms.TextBox
        Me.txtEmpCodeinExcel = New System.Windows.Forms.TextBox
        Me.txtErnCode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtErnCodeInExcel = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Employee Code Column in Excel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "OverTime1 Column Number in Excel"
        '
        'txtOverTime1Column
        '
        Me.txtOverTime1Column.Location = New System.Drawing.Point(335, 127)
        Me.txtOverTime1Column.Name = "txtOverTime1Column"
        Me.txtOverTime1Column.Size = New System.Drawing.Size(121, 20)
        Me.txtOverTime1Column.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "KELIO Prefix in Employee Code"
        '
        'txtKelioPrefix
        '
        Me.txtKelioPrefix.Location = New System.Drawing.Point(335, 12)
        Me.txtKelioPrefix.Name = "txtKelioPrefix"
        Me.txtKelioPrefix.Size = New System.Drawing.Size(121, 20)
        Me.txtKelioPrefix.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "First Excel Line to Read"
        '
        'txtFirstLineToRead
        '
        Me.txtFirstLineToRead.Location = New System.Drawing.Point(335, 35)
        Me.txtFirstLineToRead.Name = "txtFirstLineToRead"
        Me.txtFirstLineToRead.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstLineToRead.TabIndex = 35
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(335, 257)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 41
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(921, 229)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 40
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(337, 231)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Select File To Upload"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "OverTime2 Column Number in Excel"
        '
        'txtOvertime2Column
        '
        Me.txtOvertime2Column.Location = New System.Drawing.Point(335, 150)
        Me.txtOvertime2Column.Name = "txtOvertime2Column"
        Me.txtOvertime2Column.Size = New System.Drawing.Size(121, 20)
        Me.txtOvertime2Column.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(253, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "OverTime Previous Months Column Number in Excel"
        '
        'txtPMOver1Column
        '
        Me.txtPMOver1Column.Location = New System.Drawing.Point(335, 173)
        Me.txtPMOver1Column.Name = "txtPMOver1Column"
        Me.txtPMOver1Column.Size = New System.Drawing.Size(121, 20)
        Me.txtPMOver1Column.TabIndex = 48
        '
        'txtEmpCodeinExcel
        '
        Me.txtEmpCodeinExcel.Location = New System.Drawing.Point(335, 104)
        Me.txtEmpCodeinExcel.Name = "txtEmpCodeinExcel"
        Me.txtEmpCodeinExcel.Size = New System.Drawing.Size(121, 20)
        Me.txtEmpCodeinExcel.TabIndex = 50
        '
        'txtErnCode
        '
        Me.txtErnCode.Location = New System.Drawing.Point(335, 58)
        Me.txtErnCode.Name = "txtErnCode"
        Me.txtErnCode.Size = New System.Drawing.Size(121, 20)
        Me.txtErnCode.TabIndex = 54
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Earning Code Payroll"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Earning Column In Excel"
        '
        'txtErnCodeInExcel
        '
        Me.txtErnCodeInExcel.Location = New System.Drawing.Point(335, 81)
        Me.txtErnCodeInExcel.Name = "txtErnCodeInExcel"
        Me.txtErnCodeInExcel.Size = New System.Drawing.Size(121, 20)
        Me.txtErnCodeInExcel.TabIndex = 51
        '
        'FrmLoadKELIO1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 313)
        Me.Controls.Add(Me.txtErnCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtErnCodeInExcel)
        Me.Controls.Add(Me.txtEmpCodeinExcel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPMOver1Column)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOvertime2Column)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOverTime1Column)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKelioPrefix)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstLineToRead)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmLoadKELIO1"
        Me.Text = "Load KELIO File - 1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOverTime1Column As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKelioPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstLineToRead As System.Windows.Forms.TextBox
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOvertime2Column As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPMOver1Column As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpCodeinExcel As System.Windows.Forms.TextBox
    Friend WithEvents txtErnCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtErnCodeInExcel As System.Windows.Forms.TextBox
End Class
