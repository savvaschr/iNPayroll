<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaTotalTimePerWork
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.DateTo = New System.Windows.Forms.DateTimePicker
        Me.RadioWeek = New System.Windows.Forms.RadioButton
        Me.RadioMonth = New System.Windows.Forms.RadioButton
        Me.RadioDays = New System.Windows.Forms.RadioButton
        Me.btnSearch = New System.Windows.Forms.Button
        Me.BtnExcel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Employee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Employee, Me.WorkCode, Me.WorkDesc, Me.Total})
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(18, 113)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(807, 294)
        Me.DG1.TabIndex = 0
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(82, 42)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(150, 20)
        Me.DateFrom.TabIndex = 1
        '
        'DateTo
        '
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(82, 73)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(150, 20)
        Me.DateTo.TabIndex = 2
        '
        'RadioWeek
        '
        Me.RadioWeek.Location = New System.Drawing.Point(18, 12)
        Me.RadioWeek.Name = "RadioWeek"
        Me.RadioWeek.Size = New System.Drawing.Size(91, 17)
        Me.RadioWeek.TabIndex = 3
        Me.RadioWeek.Text = "Current Week"
        Me.RadioWeek.UseVisualStyleBackColor = True
        '
        'RadioMonth
        '
        Me.RadioMonth.AutoSize = True
        Me.RadioMonth.Location = New System.Drawing.Point(140, 12)
        Me.RadioMonth.Name = "RadioMonth"
        Me.RadioMonth.Size = New System.Drawing.Size(92, 17)
        Me.RadioMonth.TabIndex = 4
        Me.RadioMonth.Text = "Current Month"
        Me.RadioMonth.UseVisualStyleBackColor = True
        '
        'RadioDays
        '
        Me.RadioDays.AutoSize = True
        Me.RadioDays.Location = New System.Drawing.Point(275, 12)
        Me.RadioDays.Name = "RadioDays"
        Me.RadioDays.Size = New System.Drawing.Size(86, 17)
        Me.RadioDays.TabIndex = 5
        Me.RadioDays.TabStop = True
        Me.RadioDays.Text = "Select Dates"
        Me.RadioDays.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(275, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'BtnExcel
        '
        Me.BtnExcel.Location = New System.Drawing.Point(275, 70)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(87, 23)
        Me.BtnExcel.TabIndex = 7
        Me.BtnExcel.Text = "Excel"
        Me.BtnExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "To Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "From Date"
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "Name"
        Me.Employee.HeaderText = "Employee"
        Me.Employee.Name = "Employee"
        Me.Employee.Width = 200
        '
        'WorkCode
        '
        Me.WorkCode.DataPropertyName = "WrkCod_Code"
        Me.WorkCode.HeaderText = "Work Code"
        Me.WorkCode.Name = "WorkCode"
        '
        'WorkDesc
        '
        Me.WorkDesc.DataPropertyName = "WrkCod_Desc"
        Me.WorkDesc.HeaderText = "Work"
        Me.WorkDesc.Name = "WorkDesc"
        Me.WorkDesc.Width = 150
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle1
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'FrmTaTotalTimePerWork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 419)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnExcel)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.RadioDays)
        Me.Controls.Add(Me.RadioMonth)
        Me.Controls.Add(Me.RadioWeek)
        Me.Controls.Add(Me.DateTo)
        Me.Controls.Add(Me.DateFrom)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmTaTotalTimePerWork"
        Me.Text = "Employee Total Time Per Work"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioWeek As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMonth As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDays As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Employee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
