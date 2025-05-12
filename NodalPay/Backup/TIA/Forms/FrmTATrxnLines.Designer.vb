<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTATrxnLines
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTATrxnLines))
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mon = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Tue = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Wed = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Thu = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Fri = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Sat = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Sun = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBSearch = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.WeeklyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MonthlyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectedEmployeeReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.WeeklyReportPerTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSendToPayroll = New System.Windows.Forms.ToolStripSplitButton
        Me.TSBPostForProcess = New System.Windows.Forms.ToolStripButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPeriodTo = New System.Windows.Forms.TextBox
        Me.txtPeriodFrom = New System.Windows.Forms.TextBox
        Me.txtPeriodDescription = New System.Windows.Forms.TextBox
        Me.txtPeriodCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboTempGroups = New System.Windows.Forms.ComboBox
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.DateTo = New System.Windows.Forms.DateTimePicker
        Me.btnPreviousWeek = New System.Windows.Forms.Button
        Me.btnNextWeek = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.LblAnalysis = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpCode, Me.EmpDesc, Me.Mon, Me.Tue, Me.Wed, Me.Thu, Me.Fri, Me.Sat, Me.Sun})
        Me.DG1.Location = New System.Drawing.Point(0, 179)
        Me.DG1.Name = "DG1"
        Me.DG1.RowTemplate.Height = 35
        Me.DG1.Size = New System.Drawing.Size(1012, 487)
        Me.DG1.TabIndex = 0
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "EmpCode"
        Me.EmpCode.Name = "EmpCode"
        Me.EmpCode.Visible = False
        Me.EmpCode.Width = 5
        '
        'EmpDesc
        '
        Me.EmpDesc.DataPropertyName = "EmpName"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmpDesc.DefaultCellStyle = DataGridViewCellStyle1
        Me.EmpDesc.HeaderText = "Employee"
        Me.EmpDesc.Name = "EmpDesc"
        Me.EmpDesc.Width = 140
        '
        'Mon
        '
        Me.Mon.DataPropertyName = "Mon"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Mon.DefaultCellStyle = DataGridViewCellStyle2
        Me.Mon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Mon.HeaderText = "Mon"
        Me.Mon.Name = "Mon"
        Me.Mon.Width = 112
        '
        'Tue
        '
        Me.Tue.DataPropertyName = "Tue"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tue.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Tue.HeaderText = "Tue"
        Me.Tue.Name = "Tue"
        Me.Tue.Width = 112
        '
        'Wed
        '
        Me.Wed.DataPropertyName = "Wed"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Wed.DefaultCellStyle = DataGridViewCellStyle4
        Me.Wed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Wed.HeaderText = "Wed"
        Me.Wed.Name = "Wed"
        Me.Wed.Width = 112
        '
        'Thu
        '
        Me.Thu.DataPropertyName = "Thu"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Thu.DefaultCellStyle = DataGridViewCellStyle5
        Me.Thu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Thu.HeaderText = "Thu"
        Me.Thu.Name = "Thu"
        Me.Thu.Width = 112
        '
        'Fri
        '
        Me.Fri.DataPropertyName = "Fri"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fri.DefaultCellStyle = DataGridViewCellStyle6
        Me.Fri.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fri.HeaderText = "Fri"
        Me.Fri.Name = "Fri"
        Me.Fri.Width = 112
        '
        'Sat
        '
        Me.Sat.DataPropertyName = "Sat"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Sat.DefaultCellStyle = DataGridViewCellStyle7
        Me.Sat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Sat.HeaderText = "Sat"
        Me.Sat.Name = "Sat"
        Me.Sat.Width = 112
        '
        'Sun
        '
        Me.Sun.DataPropertyName = "Sun"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Sun.DefaultCellStyle = DataGridViewCellStyle8
        Me.Sun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Sun.HeaderText = "Sun"
        Me.Sun.Name = "Sun"
        Me.Sun.Width = 112
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSearch, Me.ToolStripDropDownButton1, Me.TSSendToPayroll, Me.TSBPostForProcess})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1012, 25)
        Me.ToolStrip1.TabIndex = 66
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBSearch
        '
        Me.TSBSearch.AutoSize = False
        Me.TSBSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSearch.Name = "TSBSearch"
        Me.TSBSearch.Size = New System.Drawing.Size(60, 22)
        Me.TSBSearch.Text = "Search"
        Me.TSBSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WeeklyReportToolStripMenuItem, Me.MonthlyReportToolStripMenuItem, Me.SelectedEmployeeReportToolStripMenuItem, Me.ToolStripSeparator1, Me.WeeklyReportPerTimeToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripDropDownButton1.Text = "Reports"
        '
        'WeeklyReportToolStripMenuItem
        '
        Me.WeeklyReportToolStripMenuItem.Name = "WeeklyReportToolStripMenuItem"
        Me.WeeklyReportToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.WeeklyReportToolStripMenuItem.Text = "Weekly Report"
        '
        'MonthlyReportToolStripMenuItem
        '
        Me.MonthlyReportToolStripMenuItem.Name = "MonthlyReportToolStripMenuItem"
        Me.MonthlyReportToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.MonthlyReportToolStripMenuItem.Text = "Monthly Report"
        '
        'SelectedEmployeeReportToolStripMenuItem
        '
        Me.SelectedEmployeeReportToolStripMenuItem.Name = "SelectedEmployeeReportToolStripMenuItem"
        Me.SelectedEmployeeReportToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.SelectedEmployeeReportToolStripMenuItem.Text = "Selected Employee Report "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'WeeklyReportPerTimeToolStripMenuItem
        '
        Me.WeeklyReportPerTimeToolStripMenuItem.Name = "WeeklyReportPerTimeToolStripMenuItem"
        Me.WeeklyReportPerTimeToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.WeeklyReportPerTimeToolStripMenuItem.Text = "Weekly Report Per Time"
        '
        'TSSendToPayroll
        '
        Me.TSSendToPayroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSSendToPayroll.Image = CType(resources.GetObject("TSSendToPayroll.Image"), System.Drawing.Image)
        Me.TSSendToPayroll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSSendToPayroll.Name = "TSSendToPayroll"
        Me.TSSendToPayroll.Size = New System.Drawing.Size(105, 22)
        Me.TSSendToPayroll.Text = "Send To Payroll"
        '
        'TSBPostForProcess
        '
        Me.TSBPostForProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBPostForProcess.Image = CType(resources.GetObject("TSBPostForProcess.Image"), System.Drawing.Image)
        Me.TSBPostForProcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBPostForProcess.Name = "TSBPostForProcess"
        Me.TSBPostForProcess.Size = New System.Drawing.Size(126, 22)
        Me.TSBPostForProcess.Text = "Post For PROCESSING"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(543, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "-"
        '
        'txtPeriodTo
        '
        Me.txtPeriodTo.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodTo.Location = New System.Drawing.Point(559, 55)
        Me.txtPeriodTo.Name = "txtPeriodTo"
        Me.txtPeriodTo.ReadOnly = True
        Me.txtPeriodTo.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodTo.TabIndex = 73
        '
        'txtPeriodFrom
        '
        Me.txtPeriodFrom.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodFrom.Location = New System.Drawing.Point(457, 55)
        Me.txtPeriodFrom.Name = "txtPeriodFrom"
        Me.txtPeriodFrom.ReadOnly = True
        Me.txtPeriodFrom.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodFrom.TabIndex = 72
        '
        'txtPeriodDescription
        '
        Me.txtPeriodDescription.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodDescription.Location = New System.Drawing.Point(195, 55)
        Me.txtPeriodDescription.Name = "txtPeriodDescription"
        Me.txtPeriodDescription.ReadOnly = True
        Me.txtPeriodDescription.Size = New System.Drawing.Size(253, 20)
        Me.txtPeriodDescription.TabIndex = 71
        '
        'txtPeriodCode
        '
        Me.txtPeriodCode.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodCode.Location = New System.Drawing.Point(103, 55)
        Me.txtPeriodCode.Name = "txtPeriodCode"
        Me.txtPeriodCode.ReadOnly = True
        Me.txtPeriodCode.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodCode.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Period"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Template Group"
        '
        'ComboTempGroups
        '
        Me.ComboTempGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTempGroups.FormattingEnabled = True
        Me.ComboTempGroups.Location = New System.Drawing.Point(103, 28)
        Me.ComboTempGroups.Name = "ComboTempGroups"
        Me.ComboTempGroups.Size = New System.Drawing.Size(207, 21)
        Me.ComboTempGroups.TabIndex = 67
        '
        'DateFrom
        '
        Me.DateFrom.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DateFrom.CalendarTitleForeColor = System.Drawing.SystemColors.Info
        Me.DateFrom.Enabled = False
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(741, 52)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(99, 20)
        Me.DateFrom.TabIndex = 82
        Me.DateFrom.Visible = False
        '
        'DateTo
        '
        Me.DateTo.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DateTo.CalendarTitleForeColor = System.Drawing.SystemColors.Info
        Me.DateTo.Enabled = False
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(852, 52)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(99, 20)
        Me.DateTo.TabIndex = 83
        Me.DateTo.Visible = False
        '
        'btnPreviousWeek
        '
        Me.btnPreviousWeek.Image = CType(resources.GetObject("btnPreviousWeek.Image"), System.Drawing.Image)
        Me.btnPreviousWeek.Location = New System.Drawing.Point(103, 109)
        Me.btnPreviousWeek.Name = "btnPreviousWeek"
        Me.btnPreviousWeek.Size = New System.Drawing.Size(86, 23)
        Me.btnPreviousWeek.TabIndex = 84
        Me.btnPreviousWeek.UseVisualStyleBackColor = True
        '
        'btnNextWeek
        '
        Me.btnNextWeek.Image = CType(resources.GetObject("btnNextWeek.Image"), System.Drawing.Image)
        Me.btnNextWeek.Location = New System.Drawing.Point(195, 109)
        Me.btnNextWeek.Name = "btnNextWeek"
        Me.btnNextWeek.Size = New System.Drawing.Size(86, 23)
        Me.btnNextWeek.TabIndex = 85
        Me.btnNextWeek.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "WEEK"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.BackColor = System.Drawing.SystemColors.Info
        Me.txtDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtDateFrom.Location = New System.Drawing.Point(103, 81)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.ReadOnly = True
        Me.txtDateFrom.Size = New System.Drawing.Size(86, 22)
        Me.txtDateFrom.TabIndex = 87
        '
        'txtDateTo
        '
        Me.txtDateTo.BackColor = System.Drawing.SystemColors.Info
        Me.txtDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtDateTo.Location = New System.Drawing.Point(195, 81)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.ReadOnly = True
        Me.txtDateTo.Size = New System.Drawing.Size(86, 22)
        Me.txtDateTo.TabIndex = 88
        '
        'LblAnalysis
        '
        Me.LblAnalysis.AutoSize = True
        Me.LblAnalysis.Location = New System.Drawing.Point(369, 31)
        Me.LblAnalysis.Name = "LblAnalysis"
        Me.LblAnalysis.Size = New System.Drawing.Size(0, 13)
        Me.LblAnalysis.TabIndex = 90
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(319, 81)
        Me.txtDesc.MaxLength = 200
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(632, 20)
        Me.txtDesc.TabIndex = 91
        '
        'FrmTATrxnLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 669)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.LblAnalysis)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnNextWeek)
        Me.Controls.Add(Me.btnPreviousWeek)
        Me.Controls.Add(Me.DateTo)
        Me.Controls.Add(Me.DateFrom)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPeriodTo)
        Me.Controls.Add(Me.txtPeriodFrom)
        Me.Controls.Add(Me.txtPeriodDescription)
        Me.Controls.Add(Me.txtPeriodCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTempGroups)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmTATrxnLines"
        Me.Text = "Time Attendance"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodTo As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboTempGroups As System.Windows.Forms.ComboBox
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPreviousWeek As System.Windows.Forms.Button
    Friend WithEvents btnNextWeek As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents TSBPostForProcess As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblAnalysis As System.Windows.Forms.Label
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents WeeklyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthlyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectedEmployeeReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSendToPayroll As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WeeklyReportPerTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mon As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Tue As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Wed As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Thu As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Fri As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Sat As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Sun As System.Windows.Forms.DataGridViewButtonColumn
End Class
