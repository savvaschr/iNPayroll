<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxEmployeeLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrTxEmployeeLeave))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.TSBShowTotals = New System.Windows.Forms.ToolStripButton
        Me.TsbPrintStatement = New System.Windows.Forms.ToolStripButton
        Me.DateReq = New System.Windows.Forms.DateTimePicker
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.DateProc = New System.Windows.Forms.DateTimePicker
        Me.lblId = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.lblSalaryValue = New System.Windows.Forms.Label
        Me.lblBasic = New System.Windows.Forms.Label
        Me.lblEffPayDate = New System.Windows.Forms.Label
        Me.lblCola = New System.Windows.Forms.Label
        Me.lblEffArrearsDate = New System.Windows.Forms.Label
        Me.comboUser = New System.Windows.Forms.ComboBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcEmpSal_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Basic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Cola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_IsCola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffPayDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcUsr_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffArrearsDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpLea_Comment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpLea_ApprovedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComboStatus = New System.Windows.Forms.ComboBox
        Me.ComboType = New System.Windows.Forms.ComboBox
        Me.DateTo = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUnits = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ComboAction = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCopyFrom = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmployeeName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        Me.lblPrdGrp_Code = New System.Windows.Forms.Label
        Me.cmbPrdGrp_Code = New System.Windows.Forms.ComboBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtApprovedBy = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TS1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel, Me.TSBShowTotals, Me.TsbPrintStatement})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(435, 25)
        Me.TS1.TabIndex = 1
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
        'TSBShowTotals
        '
        Me.TSBShowTotals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBShowTotals.Image = CType(resources.GetObject("TSBShowTotals.Image"), System.Drawing.Image)
        Me.TSBShowTotals.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBShowTotals.Name = "TSBShowTotals"
        Me.TSBShowTotals.Size = New System.Drawing.Size(90, 22)
        Me.TSBShowTotals.Text = "Leave Balances"
        '
        'TsbPrintStatement
        '
        Me.TsbPrintStatement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TsbPrintStatement.Image = CType(resources.GetObject("TsbPrintStatement.Image"), System.Drawing.Image)
        Me.TsbPrintStatement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbPrintStatement.Name = "TsbPrintStatement"
        Me.TsbPrintStatement.Size = New System.Drawing.Size(93, 22)
        Me.TsbPrintStatement.Text = "Print Statement"
        '
        'DateReq
        '
        Me.DateReq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateReq.Location = New System.Drawing.Point(134, 214)
        Me.DateReq.Name = "DateReq"
        Me.DateReq.Size = New System.Drawing.Size(100, 20)
        Me.DateReq.TabIndex = 34
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(442, 161)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(100, 20)
        Me.DateFrom.TabIndex = 33
        '
        'DateProc
        '
        Me.DateProc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateProc.Location = New System.Drawing.Point(134, 237)
        Me.DateProc.Name = "DateProc"
        Me.DateProc.Size = New System.Drawing.Size(100, 20)
        Me.DateProc.TabIndex = 32
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(402, 5)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 17
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(485, 32)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 18
        Me.txtId.Visible = False
        '
        'lblSalaryValue
        '
        Me.lblSalaryValue.AutoSize = True
        Me.lblSalaryValue.Location = New System.Drawing.Point(14, 140)
        Me.lblSalaryValue.Name = "lblSalaryValue"
        Me.lblSalaryValue.Size = New System.Drawing.Size(37, 13)
        Me.lblSalaryValue.TabIndex = 21
        Me.lblSalaryValue.Text = "Status"
        '
        'lblBasic
        '
        Me.lblBasic.AutoSize = True
        Me.lblBasic.Location = New System.Drawing.Point(14, 163)
        Me.lblBasic.Name = "lblBasic"
        Me.lblBasic.Size = New System.Drawing.Size(64, 13)
        Me.lblBasic.TabIndex = 23
        Me.lblBasic.Text = "Leave Type"
        '
        'lblEffPayDate
        '
        Me.lblEffPayDate.AutoSize = True
        Me.lblEffPayDate.Location = New System.Drawing.Point(14, 238)
        Me.lblEffPayDate.Name = "lblEffPayDate"
        Me.lblEffPayDate.Size = New System.Drawing.Size(83, 13)
        Me.lblEffPayDate.TabIndex = 24
        Me.lblEffPayDate.Text = "Processed Date"
        '
        'lblCola
        '
        Me.lblCola.AutoSize = True
        Me.lblCola.Location = New System.Drawing.Point(14, 215)
        Me.lblCola.Name = "lblCola"
        Me.lblCola.Size = New System.Drawing.Size(85, 13)
        Me.lblCola.TabIndex = 27
        Me.lblCola.Text = "Requested Date"
        '
        'lblEffArrearsDate
        '
        Me.lblEffArrearsDate.AutoSize = True
        Me.lblEffArrearsDate.Location = New System.Drawing.Point(322, 138)
        Me.lblEffArrearsDate.Name = "lblEffArrearsDate"
        Me.lblEffArrearsDate.Size = New System.Drawing.Size(71, 13)
        Me.lblEffArrearsDate.TabIndex = 28
        Me.lblEffArrearsDate.Text = "Processed by"
        '
        'comboUser
        '
        Me.comboUser.Enabled = False
        Me.comboUser.Location = New System.Drawing.Point(442, 137)
        Me.comboUser.Name = "comboUser"
        Me.comboUser.Size = New System.Drawing.Size(100, 21)
        Me.comboUser.TabIndex = 25
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcEmpSal_id, Me.Action, Me.dgcEmp_Code, Me.dgcEmpSal_Value, Me.dgcEmpSal_Date, Me.dgcEmpSal_Basic, Me.dgcEmpSal_Cola, Me.dgcEmpSal_IsCola, Me.dgcEmpSal_EffPayDate, Me.dgcUsr_Id, Me.dgcEmpSal_EffArrearsDate, Me.HeaderID, Me.EmpLea_Comment, Me.EmpLea_ApprovedBy})
        Me.DG1.Location = New System.Drawing.Point(6, 319)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(1052, 299)
        Me.DG1.TabIndex = 31
        '
        'dgcEmpSal_id
        '
        Me.dgcEmpSal_id.DataPropertyName = "EmpLea_Id"
        Me.dgcEmpSal_id.FillWeight = 150.0!
        Me.dgcEmpSal_id.HeaderText = "id"
        Me.dgcEmpSal_id.Name = "dgcEmpSal_id"
        Me.dgcEmpSal_id.ReadOnly = True
        Me.dgcEmpSal_id.Visible = False
        Me.dgcEmpSal_id.Width = 64
        '
        'Action
        '
        Me.Action.DataPropertyName = "EmpLea_Action"
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
        '
        'dgcEmp_Code
        '
        Me.dgcEmp_Code.DataPropertyName = "EmpLea_Status"
        Me.dgcEmp_Code.FillWeight = 150.0!
        Me.dgcEmp_Code.HeaderText = "Status"
        Me.dgcEmp_Code.Name = "dgcEmp_Code"
        Me.dgcEmp_Code.ReadOnly = True
        Me.dgcEmp_Code.Width = 106
        '
        'dgcEmpSal_Value
        '
        Me.dgcEmpSal_Value.DataPropertyName = "Emp_Code"
        Me.dgcEmpSal_Value.FillWeight = 150.0!
        Me.dgcEmpSal_Value.HeaderText = "Employee"
        Me.dgcEmpSal_Value.Name = "dgcEmpSal_Value"
        Me.dgcEmpSal_Value.ReadOnly = True
        Me.dgcEmpSal_Value.Visible = False
        '
        'dgcEmpSal_Date
        '
        Me.dgcEmpSal_Date.DataPropertyName = "EmpLea_Type"
        Me.dgcEmpSal_Date.FillWeight = 150.0!
        Me.dgcEmpSal_Date.HeaderText = "Type"
        Me.dgcEmpSal_Date.Name = "dgcEmpSal_Date"
        Me.dgcEmpSal_Date.ReadOnly = True
        Me.dgcEmpSal_Date.Width = 70
        '
        'dgcEmpSal_Basic
        '
        Me.dgcEmpSal_Basic.DataPropertyName = "EmpLea_ReqDate"
        DataGridViewCellStyle1.Format = "dd/MM/yyyy"
        Me.dgcEmpSal_Basic.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcEmpSal_Basic.FillWeight = 150.0!
        Me.dgcEmpSal_Basic.HeaderText = "Req.Date"
        Me.dgcEmpSal_Basic.Name = "dgcEmpSal_Basic"
        Me.dgcEmpSal_Basic.ReadOnly = True
        '
        'dgcEmpSal_Cola
        '
        Me.dgcEmpSal_Cola.DataPropertyName = "EmpLea_ProcDate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgcEmpSal_Cola.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgcEmpSal_Cola.FillWeight = 150.0!
        Me.dgcEmpSal_Cola.HeaderText = "Proc.Date"
        Me.dgcEmpSal_Cola.Name = "dgcEmpSal_Cola"
        Me.dgcEmpSal_Cola.ReadOnly = True
        '
        'dgcEmpSal_IsCola
        '
        Me.dgcEmpSal_IsCola.DataPropertyName = "EmpLea_ProcBy"
        Me.dgcEmpSal_IsCola.FillWeight = 150.0!
        Me.dgcEmpSal_IsCola.HeaderText = "Proc.By"
        Me.dgcEmpSal_IsCola.Name = "dgcEmpSal_IsCola"
        Me.dgcEmpSal_IsCola.ReadOnly = True
        Me.dgcEmpSal_IsCola.Visible = False
        Me.dgcEmpSal_IsCola.Width = 60
        '
        'dgcEmpSal_EffPayDate
        '
        Me.dgcEmpSal_EffPayDate.DataPropertyName = "EmpLea_FromDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgcEmpSal_EffPayDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgcEmpSal_EffPayDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffPayDate.HeaderText = "From Date"
        Me.dgcEmpSal_EffPayDate.Name = "dgcEmpSal_EffPayDate"
        Me.dgcEmpSal_EffPayDate.ReadOnly = True
        Me.dgcEmpSal_EffPayDate.Width = 70
        '
        'dgcUsr_Id
        '
        Me.dgcUsr_Id.DataPropertyName = "EmpLea_ToDate"
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dgcUsr_Id.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgcUsr_Id.FillWeight = 150.0!
        Me.dgcUsr_Id.HeaderText = "To Date"
        Me.dgcUsr_Id.Name = "dgcUsr_Id"
        Me.dgcUsr_Id.ReadOnly = True
        '
        'dgcEmpSal_EffArrearsDate
        '
        Me.dgcEmpSal_EffArrearsDate.DataPropertyName = "EmpLea_Units"
        Me.dgcEmpSal_EffArrearsDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffArrearsDate.HeaderText = "Units"
        Me.dgcEmpSal_EffArrearsDate.Name = "dgcEmpSal_EffArrearsDate"
        Me.dgcEmpSal_EffArrearsDate.ReadOnly = True
        Me.dgcEmpSal_EffArrearsDate.Width = 70
        '
        'HeaderID
        '
        Me.HeaderID.DataPropertyName = "Hdr_ID"
        Me.HeaderID.HeaderText = "Payslip ID"
        Me.HeaderID.Name = "HeaderID"
        Me.HeaderID.ReadOnly = True
        '
        'EmpLea_Comment
        '
        Me.EmpLea_Comment.DataPropertyName = "EmpLea_Comment"
        Me.EmpLea_Comment.HeaderText = "Comment"
        Me.EmpLea_Comment.Name = "EmpLea_Comment"
        Me.EmpLea_Comment.ReadOnly = True
        '
        'EmpLea_ApprovedBy
        '
        Me.EmpLea_ApprovedBy.DataPropertyName = "EmpLea_ApprovedBy"
        Me.EmpLea_ApprovedBy.HeaderText = "ApprovedBy"
        Me.EmpLea_ApprovedBy.Name = "EmpLea_ApprovedBy"
        Me.EmpLea_ApprovedBy.ReadOnly = True
        '
        'ComboStatus
        '
        Me.ComboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStatus.FormattingEnabled = True
        Me.ComboStatus.Location = New System.Drawing.Point(134, 137)
        Me.ComboStatus.Name = "ComboStatus"
        Me.ComboStatus.Size = New System.Drawing.Size(169, 21)
        Me.ComboStatus.TabIndex = 36
        '
        'ComboType
        '
        Me.ComboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboType.FormattingEnabled = True
        Me.ComboType.Location = New System.Drawing.Point(134, 161)
        Me.ComboType.Name = "ComboType"
        Me.ComboType.Size = New System.Drawing.Size(169, 21)
        Me.ComboType.TabIndex = 37
        '
        'DateTo
        '
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(442, 184)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(100, 20)
        Me.DateTo.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(322, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Units"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(442, 207)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(100, 20)
        Me.txtUnits.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(322, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "From Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "To Date"
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 621)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(1070, 22)
        Me.sspStatus.TabIndex = 43
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ComboAction
        '
        Me.ComboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAction.FormattingEnabled = True
        Me.ComboAction.Location = New System.Drawing.Point(134, 187)
        Me.ComboAction.Name = "ComboAction"
        Me.ComboAction.Size = New System.Drawing.Size(169, 21)
        Me.ComboAction.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Action"
        '
        'txtCopyFrom
        '
        Me.txtCopyFrom.Location = New System.Drawing.Point(878, 42)
        Me.txtCopyFrom.Name = "txtCopyFrom"
        Me.txtCopyFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtCopyFrom.TabIndex = 47
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(878, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 23)
        Me.Button3.TabIndex = 46
        Me.Button3.Text = "Copy From"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Employee Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(134, 61)
        Me.txtEmployeeName.MaxLength = 15
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(316, 20)
        Me.txtEmployeeName.TabIndex = 75
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Employee Code"
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Location = New System.Drawing.Point(134, 35)
        Me.txtEmployeeCode.MaxLength = 15
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.ReadOnly = True
        Me.txtEmployeeCode.Size = New System.Drawing.Size(100, 20)
        Me.txtEmployeeCode.TabIndex = 73
        '
        'BtnNext
        '
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(377, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 71
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(296, 32)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 72
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'lblPrdGrp_Code
        '
        Me.lblPrdGrp_Code.AutoSize = True
        Me.lblPrdGrp_Code.Location = New System.Drawing.Point(14, 87)
        Me.lblPrdGrp_Code.Name = "lblPrdGrp_Code"
        Me.lblPrdGrp_Code.Size = New System.Drawing.Size(97, 13)
        Me.lblPrdGrp_Code.TabIndex = 78
        Me.lblPrdGrp_Code.Text = "Period Group Code"
        '
        'cmbPrdGrp_Code
        '
        Me.cmbPrdGrp_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrdGrp_Code.Location = New System.Drawing.Point(134, 87)
        Me.cmbPrdGrp_Code.Name = "cmbPrdGrp_Code"
        Me.cmbPrdGrp_Code.Size = New System.Drawing.Size(318, 21)
        Me.cmbPrdGrp_Code.TabIndex = 77
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(134, 263)
        Me.txtComment.MaxLength = 100
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(619, 36)
        Me.txtComment.TabIndex = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Comment"
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Location = New System.Drawing.Point(442, 233)
        Me.txtApprovedBy.MaxLength = 50
        Me.txtApprovedBy.Multiline = True
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Size = New System.Drawing.Size(311, 20)
        Me.txtApprovedBy.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(322, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Approved By"
        '
        'FrmPrTxEmployeeLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1070, 643)
        Me.Controls.Add(Me.txtApprovedBy)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblPrdGrp_Code)
        Me.Controls.Add(Me.cmbPrdGrp_Code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.txtCopyFrom)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboAction)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTo)
        Me.Controls.Add(Me.ComboType)
        Me.Controls.Add(Me.ComboStatus)
        Me.Controls.Add(Me.DateReq)
        Me.Controls.Add(Me.DateFrom)
        Me.Controls.Add(Me.DateProc)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblSalaryValue)
        Me.Controls.Add(Me.lblBasic)
        Me.Controls.Add(Me.lblEffPayDate)
        Me.Controls.Add(Me.lblCola)
        Me.Controls.Add(Me.lblEffArrearsDate)
        Me.Controls.Add(Me.comboUser)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.TS1)
        Me.Name = "FrmPrTxEmployeeLeave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Leave"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents DateReq As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateProc As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblSalaryValue As System.Windows.Forms.Label
    Friend WithEvents lblBasic As System.Windows.Forms.Label
    Friend WithEvents lblEffPayDate As System.Windows.Forms.Label
    Friend WithEvents lblCola As System.Windows.Forms.Label
    Friend WithEvents lblEffArrearsDate As System.Windows.Forms.Label
    Friend WithEvents comboUser As System.Windows.Forms.ComboBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ComboType As System.Windows.Forms.ComboBox
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ComboAction As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TSBShowTotals As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCopyFrom As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TsbPrintStatement As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents lblPrdGrp_Code As System.Windows.Forms.Label
    Friend WithEvents cmbPrdGrp_Code As System.Windows.Forms.ComboBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtApprovedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgcEmpSal_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Basic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Cola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_IsCola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffPayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUsr_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffArrearsDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpLea_Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpLea_ApprovedBy As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
