<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAReportDates
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.RadioDays = New System.Windows.Forms.RadioButton
        Me.RadioMonth = New System.Windows.Forms.RadioButton
        Me.RadioWeek = New System.Windows.Forms.RadioButton
        Me.DateTo = New System.Windows.Forms.DateTimePicker
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "From Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "To Date"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(269, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 23)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Report"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'RadioDays
        '
        Me.RadioDays.AutoSize = True
        Me.RadioDays.Location = New System.Drawing.Point(269, 12)
        Me.RadioDays.Name = "RadioDays"
        Me.RadioDays.Size = New System.Drawing.Size(86, 17)
        Me.RadioDays.TabIndex = 14
        Me.RadioDays.TabStop = True
        Me.RadioDays.Text = "Select Dates"
        Me.RadioDays.UseVisualStyleBackColor = True
        '
        'RadioMonth
        '
        Me.RadioMonth.AutoSize = True
        Me.RadioMonth.Location = New System.Drawing.Point(134, 12)
        Me.RadioMonth.Name = "RadioMonth"
        Me.RadioMonth.Size = New System.Drawing.Size(92, 17)
        Me.RadioMonth.TabIndex = 13
        Me.RadioMonth.Text = "Current Month"
        Me.RadioMonth.UseVisualStyleBackColor = True
        '
        'RadioWeek
        '
        Me.RadioWeek.Location = New System.Drawing.Point(12, 12)
        Me.RadioWeek.Name = "RadioWeek"
        Me.RadioWeek.Size = New System.Drawing.Size(91, 17)
        Me.RadioWeek.TabIndex = 12
        Me.RadioWeek.Text = "Current Week"
        Me.RadioWeek.UseVisualStyleBackColor = True
        '
        'DateTo
        '
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(76, 73)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(150, 20)
        Me.DateTo.TabIndex = 11
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(76, 42)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(150, 20)
        Me.DateFrom.TabIndex = 10
        '
        'FrmTAReportDates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 106)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.RadioDays)
        Me.Controls.Add(Me.RadioMonth)
        Me.Controls.Add(Me.RadioWeek)
        Me.Controls.Add(Me.DateTo)
        Me.Controls.Add(Me.DateFrom)
        Me.Name = "FrmTAReportDates"
        Me.Text = "Report Dates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents RadioDays As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMonth As System.Windows.Forms.RadioButton
    Friend WithEvents RadioWeek As System.Windows.Forms.RadioButton
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
End Class
