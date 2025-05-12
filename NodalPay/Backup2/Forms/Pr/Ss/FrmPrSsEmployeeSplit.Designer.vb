<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrSsEmployeeSplit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrSsEmployeeSplit))
        Me.cbIsEnabled = New System.Windows.Forms.CheckBox
        Me.DateCreated = New System.Windows.Forms.DateTimePicker
        Me.lblId = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.lblDate1 = New System.Windows.Forms.Label
        Me.lblSalaryValue = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.lblBasic = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.Usr = New System.Windows.Forms.Label
        Me.lblIsCola = New System.Windows.Forms.Label
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmplCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsEnabled = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoOfPeriods = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsPF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsST = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivePeriods = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSC1 = New System.Windows.Forms.ToolStripContainer
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.cbIsPF = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbIsSP = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboPeriods = New System.Windows.Forms.ComboBox
        Me.DateAmend = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCreatedUser = New System.Windows.Forms.TextBox
        Me.txtAmendUser = New System.Windows.Forms.TextBox
        Me.txtPeriodTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboActivePeriods = New System.Windows.Forms.ComboBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSC1.TopToolStripPanel.SuspendLayout()
        Me.TSC1.SuspendLayout()
        Me.TS1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbIsEnabled
        '
        Me.cbIsEnabled.AutoSize = True
        Me.cbIsEnabled.Location = New System.Drawing.Point(217, 94)
        Me.cbIsEnabled.Name = "cbIsEnabled"
        Me.cbIsEnabled.Size = New System.Drawing.Size(15, 14)
        Me.cbIsEnabled.TabIndex = 37
        Me.cbIsEnabled.UseVisualStyleBackColor = True
        '
        'DateCreated
        '
        Me.DateCreated.Enabled = False
        Me.DateCreated.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCreated.Location = New System.Drawing.Point(634, 61)
        Me.DateCreated.Name = "DateCreated"
        Me.DateCreated.Size = New System.Drawing.Size(100, 20)
        Me.DateCreated.TabIndex = 35
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(634, 165)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 19
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(674, 165)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 20
        Me.txtId.Visible = False
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(514, 62)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(72, 13)
        Me.lblDate1.TabIndex = 21
        Me.lblDate1.Text = "Creation Date"
        '
        'lblSalaryValue
        '
        Me.lblSalaryValue.AutoSize = True
        Me.lblSalaryValue.Location = New System.Drawing.Point(12, 47)
        Me.lblSalaryValue.Name = "lblSalaryValue"
        Me.lblSalaryValue.Size = New System.Drawing.Size(60, 13)
        Me.lblSalaryValue.TabIndex = 23
        Me.lblSalaryValue.Text = "Description"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(217, 44)
        Me.txtDesc.MaxLength = 40
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(257, 20)
        Me.txtDesc.TabIndex = 22
        '
        'lblBasic
        '
        Me.lblBasic.AutoSize = True
        Me.lblBasic.Location = New System.Drawing.Point(12, 67)
        Me.lblBasic.Name = "lblBasic"
        Me.lblBasic.Size = New System.Drawing.Size(34, 13)
        Me.lblBasic.TabIndex = 24
        Me.lblBasic.Text = "Value"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(217, 67)
        Me.txtValue.MaxLength = 15
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(100, 20)
        Me.txtValue.TabIndex = 25
        '
        'Usr
        '
        Me.Usr.AutoSize = True
        Me.Usr.Location = New System.Drawing.Point(514, 42)
        Me.Usr.Name = "Usr"
        Me.Usr.Size = New System.Drawing.Size(59, 13)
        Me.Usr.TabIndex = 31
        Me.Usr.Text = "Created By"
        '
        'lblIsCola
        '
        Me.lblIsCola.AutoSize = True
        Me.lblIsCola.Location = New System.Drawing.Point(12, 91)
        Me.lblIsCola.Name = "lblIsCola"
        Me.lblIsCola.Size = New System.Drawing.Size(57, 13)
        Me.lblIsCola.TabIndex = 32
        Me.lblIsCola.Text = "Is Enabled"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.EmplCode, Me.Description, Me.Value, Me.IsEnabled, Me.NoOfPeriods, Me.IsPF, Me.IsST, Me.CreationDate, Me.CreatedBy, Me.AmendDate, Me.AmendBy, Me.ActivePeriods})
        Me.DG1.Location = New System.Drawing.Point(8, 218)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(849, 216)
        Me.DG1.TabIndex = 33
        '
        'Id
        '
        Me.Id.DataPropertyName = "Spl_Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'EmplCode
        '
        Me.EmplCode.DataPropertyName = "Emp_code"
        Me.EmplCode.HeaderText = "EmpCode"
        Me.EmplCode.Name = "EmplCode"
        Me.EmplCode.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Spl_Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Value
        '
        Me.Value.DataPropertyName = "Spl_Value"
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        '
        'IsEnabled
        '
        Me.IsEnabled.DataPropertyName = "Spl_Enabled"
        Me.IsEnabled.HeaderText = "IsEnabled"
        Me.IsEnabled.Name = "IsEnabled"
        Me.IsEnabled.ReadOnly = True
        '
        'NoOfPeriods
        '
        Me.NoOfPeriods.DataPropertyName = "Spl_NoOfPeriods"
        Me.NoOfPeriods.HeaderText = "NoOfPeriods"
        Me.NoOfPeriods.Name = "NoOfPeriods"
        Me.NoOfPeriods.ReadOnly = True
        '
        'IsPF
        '
        Me.IsPF.DataPropertyName = "Spl_IsPF"
        Me.IsPF.HeaderText = "IsPF"
        Me.IsPF.Name = "IsPF"
        Me.IsPF.ReadOnly = True
        '
        'IsST
        '
        Me.IsST.DataPropertyName = "Spl_IsST"
        Me.IsST.HeaderText = "IsST"
        Me.IsST.Name = "IsST"
        Me.IsST.ReadOnly = True
        '
        'CreationDate
        '
        Me.CreationDate.DataPropertyName = "Spl_CreationDate"
        Me.CreationDate.HeaderText = "CreationDate"
        Me.CreationDate.Name = "CreationDate"
        Me.CreationDate.ReadOnly = True
        '
        'CreatedBy
        '
        Me.CreatedBy.DataPropertyName = "Spl_CreatedBy"
        Me.CreatedBy.HeaderText = "CreatedBy"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.ReadOnly = True
        '
        'AmendDate
        '
        Me.AmendDate.DataPropertyName = "Spl_Amenddate"
        Me.AmendDate.HeaderText = "AmendDate"
        Me.AmendDate.Name = "AmendDate"
        Me.AmendDate.ReadOnly = True
        '
        'AmendBy
        '
        Me.AmendBy.DataPropertyName = "Spl_AmendedBy"
        Me.AmendBy.HeaderText = "AmendBy"
        Me.AmendBy.Name = "AmendBy"
        Me.AmendBy.ReadOnly = True
        '
        'ActivePeriods
        '
        Me.ActivePeriods.DataPropertyName = "Spl_ActivePeriods"
        Me.ActivePeriods.HeaderText = "Active Periods"
        Me.ActivePeriods.Name = "ActivePeriods"
        Me.ActivePeriods.ReadOnly = True
        '
        'TSC1
        '
        Me.TSC1.BottomToolStripPanelVisible = False
        '
        'TSC1.ContentPanel
        '
        Me.TSC1.ContentPanel.Size = New System.Drawing.Size(857, 1)
        Me.TSC1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TSC1.LeftToolStripPanelVisible = False
        Me.TSC1.Location = New System.Drawing.Point(0, 0)
        Me.TSC1.Name = "TSC1"
        Me.TSC1.RightToolStripPanelVisible = False
        Me.TSC1.Size = New System.Drawing.Size(857, 26)
        Me.TSC1.TabIndex = 40
        Me.TSC1.Text = "TSC1"
        '
        'TSC1.TopToolStripPanel
        '
        Me.TSC1.TopToolStripPanel.Controls.Add(Me.TS1)
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(3, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 0
        '
        'TSBNew
        '
        Me.TSBNew.AutoSize = False
        Me.TSBNew.Image = CType(resources.GetObject("TSBNew.Image"), System.Drawing.Image)
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(60, 22)
        Me.TSBNew.Text = "New"
        Me.TSBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.Image = CType(resources.GetObject("TSBSave.Image"), System.Drawing.Image)
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBDelete
        '
        Me.TSBDelete.AutoSize = False
        Me.TSBDelete.Image = CType(resources.GetObject("TSBDelete.Image"), System.Drawing.Image)
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(60, 22)
        Me.TSBDelete.Text = "Delete"
        Me.TSBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBExcel
        '
        Me.TSBExcel.AutoSize = False
        Me.TSBExcel.Image = Global.NodalPay.My.Resources.Resources.excel
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(60, 22)
        Me.TSBExcel.Text = "Excel"
        Me.TSBExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbIsPF
        '
        Me.cbIsPF.AutoSize = True
        Me.cbIsPF.Location = New System.Drawing.Point(217, 119)
        Me.cbIsPF.Name = "cbIsPF"
        Me.cbIsPF.Size = New System.Drawing.Size(15, 14)
        Me.cbIsPF.TabIndex = 42
        Me.cbIsPF.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Provident Fund Deduction/Contribution"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Special Tax Deduction/Contribution"
        Me.Label2.Visible = False
        '
        'cbIsSP
        '
        Me.cbIsSP.AutoSize = True
        Me.cbIsSP.Location = New System.Drawing.Point(217, 144)
        Me.cbIsSP.Name = "cbIsSP"
        Me.cbIsSP.Size = New System.Drawing.Size(15, 14)
        Me.cbIsSP.TabIndex = 44
        Me.cbIsSP.UseVisualStyleBackColor = True
        Me.cbIsSP.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "No. Of Periods"
        '
        'ComboPeriods
        '
        Me.ComboPeriods.FormattingEnabled = True
        Me.ComboPeriods.Location = New System.Drawing.Point(217, 165)
        Me.ComboPeriods.Name = "ComboPeriods"
        Me.ComboPeriods.Size = New System.Drawing.Size(121, 21)
        Me.ComboPeriods.TabIndex = 46
        '
        'DateAmend
        '
        Me.DateAmend.Enabled = False
        Me.DateAmend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAmend.Location = New System.Drawing.Point(634, 105)
        Me.DateAmend.Name = "DateAmend"
        Me.DateAmend.Size = New System.Drawing.Size(100, 20)
        Me.DateAmend.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Last Amendmend Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(514, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Last Amended By"
        '
        'txtCreatedUser
        '
        Me.txtCreatedUser.Enabled = False
        Me.txtCreatedUser.Location = New System.Drawing.Point(634, 39)
        Me.txtCreatedUser.MaxLength = 15
        Me.txtCreatedUser.Name = "txtCreatedUser"
        Me.txtCreatedUser.Size = New System.Drawing.Size(100, 20)
        Me.txtCreatedUser.TabIndex = 51
        '
        'txtAmendUser
        '
        Me.txtAmendUser.Enabled = False
        Me.txtAmendUser.Location = New System.Drawing.Point(634, 83)
        Me.txtAmendUser.MaxLength = 15
        Me.txtAmendUser.Name = "txtAmendUser"
        Me.txtAmendUser.Size = New System.Drawing.Size(100, 20)
        Me.txtAmendUser.TabIndex = 52
        '
        'txtPeriodTotal
        '
        Me.txtPeriodTotal.Enabled = False
        Me.txtPeriodTotal.Location = New System.Drawing.Point(217, 451)
        Me.txtPeriodTotal.Name = "txtPeriodTotal"
        Me.txtPeriodTotal.Size = New System.Drawing.Size(121, 20)
        Me.txtPeriodTotal.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 454)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Period Total (For PF Calculation)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Active Periods"
        Me.Label7.Visible = False
        '
        'ComboActivePeriods
        '
        Me.ComboActivePeriods.FormattingEnabled = True
        Me.ComboActivePeriods.Location = New System.Drawing.Point(217, 192)
        Me.ComboActivePeriods.Name = "ComboActivePeriods"
        Me.ComboActivePeriods.Size = New System.Drawing.Size(121, 21)
        Me.ComboActivePeriods.TabIndex = 57
        Me.ComboActivePeriods.Visible = False
        '
        'FrmPrSsEmployeeSplit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(857, 534)
        Me.Controls.Add(Me.ComboActivePeriods)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPeriodTotal)
        Me.Controls.Add(Me.txtAmendUser)
        Me.Controls.Add(Me.txtCreatedUser)
        Me.Controls.Add(Me.DateAmend)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboPeriods)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbIsSP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbIsPF)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TSC1)
        Me.Controls.Add(Me.cbIsEnabled)
        Me.Controls.Add(Me.DateCreated)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblDate1)
        Me.Controls.Add(Me.lblSalaryValue)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.lblBasic)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.Usr)
        Me.Controls.Add(Me.lblIsCola)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmPrSsEmployeeSplit"
        Me.Text = "Employee Split"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSC1.TopToolStripPanel.ResumeLayout(False)
        Me.TSC1.TopToolStripPanel.PerformLayout()
        Me.TSC1.ResumeLayout(False)
        Me.TSC1.PerformLayout()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbIsEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents DateCreated As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents lblSalaryValue As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblBasic As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Usr As System.Windows.Forms.Label
    Friend WithEvents lblIsCola As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TSC1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbIsPF As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbIsSP As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboPeriods As System.Windows.Forms.ComboBox
    Friend WithEvents DateAmend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCreatedUser As System.Windows.Forms.TextBox
    Friend WithEvents txtAmendUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboActivePeriods As System.Windows.Forms.ComboBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmplCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsEnabled As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfPeriods As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsPF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivePeriods As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
