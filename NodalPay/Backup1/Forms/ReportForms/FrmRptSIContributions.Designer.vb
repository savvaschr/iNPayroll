<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptSIContributions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptSIContributions))
        Me.CmbSIPeriod = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbPeriodGroups = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.ShowOnScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBFile = New System.Windows.Forms.ToolStripMenuItem
        Me.TSBFile_BasedOnActual = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBFile_ConsolPerComp = New System.Windows.Forms.ToolStripMenuItem
        Me.TSBFile_ConsolPerComp_BasedOnActual = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.TSBFile_MultibleSI = New System.Windows.Forms.ToolStripMenuItem
        Me.TSBFile_MultibleSI_BasedOnActual = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ReportOnlyWithTotalsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SIReportOnlyWithTotalsToPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.TestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.TestToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnNewEmployeesReport = New System.Windows.Forms.ToolStripButton
        Me.Test = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.CBSwitchToPeriod = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboPeriod = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CBExcludeNewEmployees = New System.Windows.Forms.CheckBox
        Me.CBShowALLYears = New System.Windows.Forms.CheckBox
        Me.btnPeriodGroupSearch = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbSIPeriod
        '
        Me.CmbSIPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSIPeriod.FormattingEnabled = True
        Me.CmbSIPeriod.Location = New System.Drawing.Point(135, 105)
        Me.CmbSIPeriod.Name = "CmbSIPeriod"
        Me.CmbSIPeriod.Size = New System.Drawing.Size(524, 21)
        Me.CmbSIPeriod.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Template Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Social Insurance Period"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Period Groups"
        '
        'cmbPeriodGroups
        '
        Me.cmbPeriodGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodGroups.FormattingEnabled = True
        Me.cmbPeriodGroups.Location = New System.Drawing.Point(135, 63)
        Me.cmbPeriodGroups.Name = "cmbPeriodGroups"
        Me.cmbPeriodGroups.Size = New System.Drawing.Size(524, 21)
        Me.cmbPeriodGroups.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(135, 84)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(524, 20)
        Me.TextBox1.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.BtnNewEmployeesReport, Me.Test, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(861, 25)
        Me.ToolStrip1.TabIndex = 67
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowOnScreenToolStripMenuItem, Me.SendToPrinterToolStripMenuItem, Me.ToolStripSeparator1, Me.TSBFile, Me.TSBFile_BasedOnActual, Me.ToolStripSeparator6, Me.TSBFile_ConsolPerComp, Me.TSBFile_ConsolPerComp_BasedOnActual, Me.ToolStripSeparator5, Me.TSBFile_MultibleSI, Me.TSBFile_MultibleSI_BasedOnActual, Me.ToolStripSeparator2, Me.CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem, Me.ToolStripSeparator8, Me.ReportOnlyWithTotalsToolStripMenuItem, Me.SIReportOnlyWithTotalsToPrinterToolStripMenuItem, Me.ToolStripSeparator3, Me.TestToolStripMenuItem1, Me.ToolStripSeparator4, Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem, Me.TestToolStripMenuItem, Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem, Me.ToolStripSeparator7, Me.TestToolStripMenuItem2})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripSplitButton1.Text = "Social Insurance Monthly Report"
        '
        'ShowOnScreenToolStripMenuItem
        '
        Me.ShowOnScreenToolStripMenuItem.Name = "ShowOnScreenToolStripMenuItem"
        Me.ShowOnScreenToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.ShowOnScreenToolStripMenuItem.Text = "Show On Screen"
        '
        'SendToPrinterToolStripMenuItem
        '
        Me.SendToPrinterToolStripMenuItem.Name = "SendToPrinterToolStripMenuItem"
        Me.SendToPrinterToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.SendToPrinterToolStripMenuItem.Text = "Send To Printer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(495, 6)
        '
        'TSBFile
        '
        Me.TSBFile.Name = "TSBFile"
        Me.TSBFile.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile.Text = "Create Monthly File"
        '
        'TSBFile_BasedOnActual
        '
        Me.TSBFile_BasedOnActual.Name = "TSBFile_BasedOnActual"
        Me.TSBFile_BasedOnActual.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile_BasedOnActual.Text = "Create Monthly File - Based on Actual Year Periods"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(495, 6)
        '
        'TSBFile_ConsolPerComp
        '
        Me.TSBFile_ConsolPerComp.Name = "TSBFile_ConsolPerComp"
        Me.TSBFile_ConsolPerComp.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile_ConsolPerComp.Text = "Create Monthly File - Consolidate Per Company"
        '
        'TSBFile_ConsolPerComp_BasedOnActual
        '
        Me.TSBFile_ConsolPerComp_BasedOnActual.Name = "TSBFile_ConsolPerComp_BasedOnActual"
        Me.TSBFile_ConsolPerComp_BasedOnActual.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile_ConsolPerComp_BasedOnActual.Text = "Create Montlhy File - Consolidate Per company - Based on Actual Year Periods"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(495, 6)
        '
        'TSBFile_MultibleSI
        '
        Me.TSBFile_MultibleSI.Name = "TSBFile_MultibleSI"
        Me.TSBFile_MultibleSI.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile_MultibleSI.Text = "Create Monthly File - Multible SI Numbers"
        '
        'TSBFile_MultibleSI_BasedOnActual
        '
        Me.TSBFile_MultibleSI_BasedOnActual.Name = "TSBFile_MultibleSI_BasedOnActual"
        Me.TSBFile_MultibleSI_BasedOnActual.Size = New System.Drawing.Size(498, 22)
        Me.TSBFile_MultibleSI_BasedOnActual.Text = "Create Monthly File - Multible SI Numbers - Based on Actual Year Periods"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(495, 6)
        '
        'CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem
        '
        Me.CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem.Name = "CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem"
        Me.CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem.Text = "Create Monthly File - For Period with 14 Salary"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(495, 6)
        '
        'ReportOnlyWithTotalsToolStripMenuItem
        '
        Me.ReportOnlyWithTotalsToolStripMenuItem.Name = "ReportOnlyWithTotalsToolStripMenuItem"
        Me.ReportOnlyWithTotalsToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.ReportOnlyWithTotalsToolStripMenuItem.Text = "S.I. Report Only with Totals - On Screen"
        '
        'SIReportOnlyWithTotalsToPrinterToolStripMenuItem
        '
        Me.SIReportOnlyWithTotalsToPrinterToolStripMenuItem.Name = "SIReportOnlyWithTotalsToPrinterToolStripMenuItem"
        Me.SIReportOnlyWithTotalsToPrinterToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.SIReportOnlyWithTotalsToPrinterToolStripMenuItem.Text = "S.I. Report Only with Totals - To Printer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(495, 6)
        Me.ToolStripSeparator3.Visible = False
        '
        'TestToolStripMenuItem1
        '
        Me.TestToolStripMenuItem1.Name = "TestToolStripMenuItem1"
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(498, 22)
        Me.TestToolStripMenuItem1.Text = "Test"
        Me.TestToolStripMenuItem1.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(495, 6)
        '
        'MultibleSINumbersFileWithOldSpecsToolStripMenuItem
        '
        Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem.Name = "MultibleSINumbersFileWithOldSpecsToolStripMenuItem"
        Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem.Text = "Multible SI Numbers File with Old Specs"
        Me.MultibleSINumbersFileWithOldSpecsToolStripMenuItem.Visible = False
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.TestToolStripMenuItem.Text = "Create Monthly File - Reverse 13 with 12 for SI Limits"
        Me.TestToolStripMenuItem.Visible = False
        '
        'CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem
        '
        Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem.Name = "CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem" & _
            ""
        Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem.Size = New System.Drawing.Size(498, 22)
        Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem.Text = "Create Monthly File - Consolidate Per Company - Reverse 13 with 12 for SI Limits"
        Me.CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(495, 6)
        '
        'TestToolStripMenuItem2
        '
        Me.TestToolStripMenuItem2.Name = "TestToolStripMenuItem2"
        Me.TestToolStripMenuItem2.Size = New System.Drawing.Size(498, 22)
        Me.TestToolStripMenuItem2.Text = "Test"
        '
        'BtnNewEmployeesReport
        '
        Me.BtnNewEmployeesReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnNewEmployeesReport.Image = CType(resources.GetObject("BtnNewEmployeesReport.Image"), System.Drawing.Image)
        Me.BtnNewEmployeesReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNewEmployeesReport.Name = "BtnNewEmployeesReport"
        Me.BtnNewEmployeesReport.Size = New System.Drawing.Size(152, 22)
        Me.BtnNewEmployeesReport.Text = "New Employees Statement"
        '
        'Test
        '
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(136, 22)
        Me.Test.Text = "Multible SI Numbers File"
        Me.Test.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripButton1.Text = "Company Consolitated File"
        Me.ToolStripButton1.Visible = False
        '
        'CBSwitchToPeriod
        '
        Me.CBSwitchToPeriod.AutoSize = True
        Me.CBSwitchToPeriod.Location = New System.Drawing.Point(12, 167)
        Me.CBSwitchToPeriod.Name = "CBSwitchToPeriod"
        Me.CBSwitchToPeriod.Size = New System.Drawing.Size(355, 17)
        Me.CBSwitchToPeriod.TabIndex = 68
        Me.CBSwitchToPeriod.Text = "Click here for the option to create separate report for 12 and 13 Salary"
        Me.CBSwitchToPeriod.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Period"
        '
        'ComboPeriod
        '
        Me.ComboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPeriod.FormattingEnabled = True
        Me.ComboPeriod.Location = New System.Drawing.Point(135, 132)
        Me.ComboPeriod.Name = "ComboPeriod"
        Me.ComboPeriod.Size = New System.Drawing.Size(524, 21)
        Me.ComboPeriod.TabIndex = 69
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 327)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(286, 23)
        Me.Button1.TabIndex = 71
        Me.Button1.Text = "Social Insurance Payment Website"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(13, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(286, 23)
        Me.Button2.TabIndex = 72
        Me.Button2.Text = "Open Social Insurance Payment File Directory"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CBExcludeNewEmployees
        '
        Me.CBExcludeNewEmployees.AutoSize = True
        Me.CBExcludeNewEmployees.Checked = True
        Me.CBExcludeNewEmployees.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBExcludeNewEmployees.Location = New System.Drawing.Point(12, 190)
        Me.CBExcludeNewEmployees.Name = "CBExcludeNewEmployees"
        Me.CBExcludeNewEmployees.Size = New System.Drawing.Size(198, 17)
        Me.CBExcludeNewEmployees.TabIndex = 73
        Me.CBExcludeNewEmployees.Text = "Exclude New Employees from SI File"
        Me.CBExcludeNewEmployees.UseVisualStyleBackColor = True
        '
        'CBShowALLYears
        '
        Me.CBShowALLYears.AutoSize = True
        Me.CBShowALLYears.Location = New System.Drawing.Point(710, 65)
        Me.CBShowALLYears.Name = "CBShowALLYears"
        Me.CBShowALLYears.Size = New System.Drawing.Size(105, 17)
        Me.CBShowALLYears.TabIndex = 74
        Me.CBShowALLYears.Text = "Show ALL Years"
        Me.CBShowALLYears.UseVisualStyleBackColor = True
        '
        'btnPeriodGroupSearch
        '
        Me.btnPeriodGroupSearch.Location = New System.Drawing.Point(665, 64)
        Me.btnPeriodGroupSearch.Name = "btnPeriodGroupSearch"
        Me.btnPeriodGroupSearch.Size = New System.Drawing.Size(27, 20)
        Me.btnPeriodGroupSearch.TabIndex = 113
        Me.btnPeriodGroupSearch.Text = "..."
        Me.btnPeriodGroupSearch.UseVisualStyleBackColor = True
        '
        'FrmRptSIContributions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(861, 375)
        Me.Controls.Add(Me.btnPeriodGroupSearch)
        Me.Controls.Add(Me.CBShowALLYears)
        Me.Controls.Add(Me.CBExcludeNewEmployees)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboPeriod)
        Me.Controls.Add(Me.CBSwitchToPeriod)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPeriodGroups)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbSIPeriod)
        Me.Name = "FrmRptSIContributions"
        Me.Text = "Sosial Insurance Contributions"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbSIPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodGroups As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CBSwitchToPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNewEmployeesReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Test As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ShowOnScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToPrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSBFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSBFile_ConsolPerComp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportOnlyWithTotalsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SIReportOnlyWithTotalsToPrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CBExcludeNewEmployees As System.Windows.Forms.CheckBox
    Friend WithEvents TestToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MultibleSINumbersFileWithOldSpecsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBShowALLYears As System.Windows.Forms.CheckBox
    Friend WithEvents TSBFile_BasedOnActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBFile_MultibleSI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSBFile_MultibleSI_BasedOnActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBFile_ConsolPerComp_BasedOnActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TestToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPeriodGroupSearch As System.Windows.Forms.Button
End Class
