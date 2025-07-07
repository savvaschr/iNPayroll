<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadCOSTA
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
        Me.txtEmpTACode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.txtOvertime1 = New System.Windows.Forms.TextBox()
        Me.label34 = New System.Windows.Forms.Label()
        Me.txtE36 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtE14 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOvertime3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.txtToFile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtE35 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtEmpTACode
        '
        Me.txtEmpTACode.Location = New System.Drawing.Point(213, 52)
        Me.txtEmpTACode.Name = "txtEmpTACode"
        Me.txtEmpTACode.Size = New System.Drawing.Size(121, 20)
        Me.txtEmpTACode.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Employee TA Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Units Column In Excel"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(213, 75)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(121, 20)
        Me.txtUnits.TabIndex = 71
        '
        'txtOvertime1
        '
        Me.txtOvertime1.Location = New System.Drawing.Point(213, 98)
        Me.txtOvertime1.Name = "txtOvertime1"
        Me.txtOvertime1.Size = New System.Drawing.Size(121, 20)
        Me.txtOvertime1.TabIndex = 70
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(12, 170)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(144, 13)
        Me.label34.TabIndex = 69
        Me.label34.Text = "E36 Column Number in Excel"
        '
        'txtE36
        '
        Me.txtE36.Location = New System.Drawing.Point(213, 167)
        Me.txtE36.Name = "txtE36"
        Me.txtE36.Size = New System.Drawing.Size(121, 20)
        Me.txtE36.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "E14 Column Number in Excel"
        '
        'txtE14
        '
        Me.txtE14.Location = New System.Drawing.Point(213, 144)
        Me.txtE14.Name = "txtE14"
        Me.txtE14.Size = New System.Drawing.Size(121, 20)
        Me.txtE14.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(177, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Overtime 1 Column Number In Excel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Overtime 3 Column Number in Excel"
        '
        'txtOvertime3
        '
        Me.txtOvertime3.Location = New System.Drawing.Point(213, 121)
        Me.txtOvertime3.Name = "txtOvertime3"
        Me.txtOvertime3.Size = New System.Drawing.Size(121, 20)
        Me.txtOvertime3.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "First Excel Line to Read"
        '
        'txtFirstLineToRead
        '
        Me.txtFirstLineToRead.Location = New System.Drawing.Point(213, 29)
        Me.txtFirstLineToRead.Name = "txtFirstLineToRead"
        Me.txtFirstLineToRead.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstLineToRead.TabIndex = 55
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(211, 255)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 61
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(797, 227)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 60
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(213, 229)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Select File To Upload"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "E35 Column Number in Excel"
        '
        'txtE35
        '
        Me.txtE35.Location = New System.Drawing.Point(213, 190)
        Me.txtE35.Name = "txtE35"
        Me.txtE35.Size = New System.Drawing.Size(121, 20)
        Me.txtE35.TabIndex = 76
        '
        'FrmLoadCOSTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(959, 289)
        Me.Controls.Add(Me.txtE35)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmpTACode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.txtOvertime1)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.txtE36)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtE14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOvertime3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstLineToRead)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmLoadCOSTA"
        Me.Text = "Load CC file"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEmpTACode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUnits As TextBox
    Friend WithEvents txtOvertime1 As TextBox
    Friend WithEvents label34 As Label
    Friend WithEvents txtE36 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtE14 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOvertime3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFirstLineToRead As TextBox
    Friend WithEvents btnProceed As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents txtToFile As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents txtE35 As TextBox
End Class
