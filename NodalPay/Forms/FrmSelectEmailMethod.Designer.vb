<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelectEmailMethod
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
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CBSchedule = New System.Windows.Forms.CheckBox()
        Me.Date1 = New System.Windows.Forms.DateTimePicker()
        Me.Time1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(59, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(115, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Email To Employee"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(59, 57)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(116, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Gmail To Employee"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(59, 91)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(174, 17)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Email to Employee Using SMTP"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(59, 212)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 22)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CBSchedule
        '
        Me.CBSchedule.AutoSize = True
        Me.CBSchedule.Location = New System.Drawing.Point(59, 150)
        Me.CBSchedule.Name = "CBSchedule"
        Me.CBSchedule.Size = New System.Drawing.Size(144, 17)
        Me.CBSchedule.TabIndex = 5
        Me.CBSchedule.Text = "Schedule Date and Time"
        Me.CBSchedule.UseVisualStyleBackColor = True
        '
        'Date1
        '
        Me.Date1.Enabled = False
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(70, 173)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(86, 20)
        Me.Date1.TabIndex = 6
        '
        'Time1
        '
        Me.Time1.Enabled = False
        Me.Time1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Time1.Location = New System.Drawing.Point(162, 173)
        Me.Time1.Name = "Time1"
        Me.Time1.Size = New System.Drawing.Size(82, 20)
        Me.Time1.TabIndex = 7
        '
        'FrmSelectEmailMethod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(380, 259)
        Me.Controls.Add(Me.Time1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.CBSchedule)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectEmailMethod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Email Method"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents CBSchedule As CheckBox
    Friend WithEvents Date1 As DateTimePicker
    Friend WithEvents Time1 As DateTimePicker
End Class
