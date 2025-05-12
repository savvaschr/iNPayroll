<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoanTransaction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLoanTransaction))
        Me.ComboAction = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboDedCode = New System.Windows.Forms.ComboBox
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.lblBasic = New System.Windows.Forms.Label
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcEmpSal_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Basic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Cola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_IsCola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffPayDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcUsr_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffArrearsDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonthlyAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblId = New System.Windows.Forms.Label
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuNewLoan = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuNewPayment = New System.Windows.Forms.ToolStripMenuItem
        Me.NewLoanEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.txtLoanCode = New System.Windows.Forms.TextBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.txtInterest = New System.Windows.Forms.TextBox
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.txtMonthlyAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPayment = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboStatus = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtId = New System.Windows.Forms.TextBox
        Me.txtHeaderId = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRemAmount = New System.Windows.Forms.TextBox
        Me.btnSetAsClosed = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboAction
        '
        Me.ComboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAction.FormattingEnabled = True
        Me.ComboAction.Location = New System.Drawing.Point(80, 201)
        Me.ComboAction.Name = "ComboAction"
        Me.ComboAction.Size = New System.Drawing.Size(139, 21)
        Me.ComboAction.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Start Date"
        '
        'ComboDedCode
        '
        Me.ComboDedCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDedCode.FormattingEnabled = True
        Me.ComboDedCode.Location = New System.Drawing.Point(138, 92)
        Me.ComboDedCode.Name = "ComboDedCode"
        Me.ComboDedCode.Size = New System.Drawing.Size(282, 21)
        Me.ComboDedCode.TabIndex = 3
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(138, 62)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(98, 20)
        Me.DateFrom.TabIndex = 2
        '
        'lblBasic
        '
        Me.lblBasic.AutoSize = True
        Me.lblBasic.Location = New System.Drawing.Point(11, 95)
        Me.lblBasic.Name = "lblBasic"
        Me.lblBasic.Size = New System.Drawing.Size(119, 13)
        Me.lblBasic.TabIndex = 47
        Me.lblBasic.Text = "Linked Deduction Code"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcEmpSal_id, Me.Code, Me.dgcEmp_Code, Me.dgcEmpSal_Value, Me.dgcEmpSal_Date, Me.dgcEmpSal_Basic, Me.dgcEmpSal_Cola, Me.dgcEmpSal_IsCola, Me.dgcEmpSal_EffPayDate, Me.dgcUsr_Id, Me.dgcEmpSal_EffArrearsDate, Me.TotalAmount, Me.Description, Me.MonthlyAmount, Me.Action, Me.Payment, Me.UserId, Me.Status})
        Me.DG1.Location = New System.Drawing.Point(4, 275)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(832, 390)
        Me.DG1.TabIndex = 52
        '
        'dgcEmpSal_id
        '
        Me.dgcEmpSal_id.DataPropertyName = "EmpLne_Id"
        Me.dgcEmpSal_id.FillWeight = 150.0!
        Me.dgcEmpSal_id.HeaderText = "id"
        Me.dgcEmpSal_id.Name = "dgcEmpSal_id"
        Me.dgcEmpSal_id.ReadOnly = True
        Me.dgcEmpSal_id.Width = 64
        '
        'Code
        '
        Me.Code.DataPropertyName = "EmpLne_Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'dgcEmp_Code
        '
        Me.dgcEmp_Code.DataPropertyName = "Emp_Code"
        Me.dgcEmp_Code.FillWeight = 150.0!
        Me.dgcEmp_Code.HeaderText = "EmpCode"
        Me.dgcEmp_Code.Name = "dgcEmp_Code"
        Me.dgcEmp_Code.ReadOnly = True
        Me.dgcEmp_Code.Width = 106
        '
        'dgcEmpSal_Value
        '
        Me.dgcEmpSal_Value.DataPropertyName = "TemGrp_Code"
        Me.dgcEmpSal_Value.FillWeight = 150.0!
        Me.dgcEmpSal_Value.HeaderText = "TemGroup"
        Me.dgcEmpSal_Value.Name = "dgcEmpSal_Value"
        Me.dgcEmpSal_Value.ReadOnly = True
        '
        'dgcEmpSal_Date
        '
        Me.dgcEmpSal_Date.DataPropertyName = "PrdCod_Code"
        Me.dgcEmpSal_Date.FillWeight = 150.0!
        Me.dgcEmpSal_Date.HeaderText = "PeriodCode"
        Me.dgcEmpSal_Date.Name = "dgcEmpSal_Date"
        Me.dgcEmpSal_Date.ReadOnly = True
        Me.dgcEmpSal_Date.Width = 70
        '
        'dgcEmpSal_Basic
        '
        Me.dgcEmpSal_Basic.DataPropertyName = "PrdGrp_Code"
        Me.dgcEmpSal_Basic.FillWeight = 150.0!
        Me.dgcEmpSal_Basic.HeaderText = "Period Group"
        Me.dgcEmpSal_Basic.Name = "dgcEmpSal_Basic"
        Me.dgcEmpSal_Basic.ReadOnly = True
        '
        'dgcEmpSal_Cola
        '
        Me.dgcEmpSal_Cola.DataPropertyName = "DedCod_Code"
        Me.dgcEmpSal_Cola.FillWeight = 150.0!
        Me.dgcEmpSal_Cola.HeaderText = "Ded Code"
        Me.dgcEmpSal_Cola.Name = "dgcEmpSal_Cola"
        Me.dgcEmpSal_Cola.ReadOnly = True
        '
        'dgcEmpSal_IsCola
        '
        Me.dgcEmpSal_IsCola.DataPropertyName = "TrxHdr_Id"
        Me.dgcEmpSal_IsCola.FillWeight = 150.0!
        Me.dgcEmpSal_IsCola.HeaderText = "Hdr_Id"
        Me.dgcEmpSal_IsCola.Name = "dgcEmpSal_IsCola"
        Me.dgcEmpSal_IsCola.ReadOnly = True
        Me.dgcEmpSal_IsCola.Width = 60
        '
        'dgcEmpSal_EffPayDate
        '
        Me.dgcEmpSal_EffPayDate.DataPropertyName = "EmpLne_LoanDate"
        Me.dgcEmpSal_EffPayDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffPayDate.HeaderText = "Loan Date"
        Me.dgcEmpSal_EffPayDate.Name = "dgcEmpSal_EffPayDate"
        Me.dgcEmpSal_EffPayDate.ReadOnly = True
        Me.dgcEmpSal_EffPayDate.Width = 70
        '
        'dgcUsr_Id
        '
        Me.dgcUsr_Id.DataPropertyName = "EmpLne_Amount"
        Me.dgcUsr_Id.FillWeight = 150.0!
        Me.dgcUsr_Id.HeaderText = "Amount"
        Me.dgcUsr_Id.Name = "dgcUsr_Id"
        Me.dgcUsr_Id.ReadOnly = True
        '
        'dgcEmpSal_EffArrearsDate
        '
        Me.dgcEmpSal_EffArrearsDate.DataPropertyName = "EmpLne_Interest"
        Me.dgcEmpSal_EffArrearsDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffArrearsDate.HeaderText = "Interest"
        Me.dgcEmpSal_EffArrearsDate.Name = "dgcEmpSal_EffArrearsDate"
        Me.dgcEmpSal_EffArrearsDate.ReadOnly = True
        Me.dgcEmpSal_EffArrearsDate.Width = 70
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "EmpLne_TotalAmount"
        Me.TotalAmount.HeaderText = "Total amount"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "EmpLne_Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'MonthlyAmount
        '
        Me.MonthlyAmount.DataPropertyName = "EmpLne_MonthlyAmount"
        Me.MonthlyAmount.HeaderText = "Monthly Amount"
        Me.MonthlyAmount.Name = "MonthlyAmount"
        Me.MonthlyAmount.ReadOnly = True
        '
        'Action
        '
        Me.Action.DataPropertyName = "EmpLne_Type"
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
        '
        'Payment
        '
        Me.Payment.DataPropertyName = "EmpLne_Payment"
        Me.Payment.HeaderText = "Payment"
        Me.Payment.Name = "Payment"
        Me.Payment.ReadOnly = True
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "Usr_Id"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "EmpLne_Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(411, 14)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 66
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.TSBSave, Me.TSBDelete})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(176, 25)
        Me.TS1.TabIndex = 65
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewLoan, Me.MnuNewPayment, Me.NewLoanEventToolStripMenuItem})
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripDropDownButton1.Text = "New"
        '
        'mnuNewLoan
        '
        Me.mnuNewLoan.Name = "mnuNewLoan"
        Me.mnuNewLoan.Size = New System.Drawing.Size(159, 22)
        Me.mnuNewLoan.Text = "New Loan"
        '
        'MnuNewPayment
        '
        Me.MnuNewPayment.Name = "MnuNewPayment"
        Me.MnuNewPayment.Size = New System.Drawing.Size(159, 22)
        Me.MnuNewPayment.Text = "New Payment"
        '
        'NewLoanEventToolStripMenuItem
        '
        Me.NewLoanEventToolStripMenuItem.Name = "NewLoanEventToolStripMenuItem"
        Me.NewLoanEventToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NewLoanEventToolStripMenuItem.Text = "New Loan Event"
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
        'txtLoanCode
        '
        Me.txtLoanCode.Location = New System.Drawing.Point(138, 16)
        Me.txtLoanCode.MaxLength = 10
        Me.txtLoanCode.Name = "txtLoanCode"
        Me.txtLoanCode.Size = New System.Drawing.Size(98, 20)
        Me.txtLoanCode.TabIndex = 0
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(624, 27)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInterest
        '
        Me.txtInterest.Location = New System.Drawing.Point(624, 50)
        Me.txtInterest.Name = "txtInterest"
        Me.txtInterest.Size = New System.Drawing.Size(100, 20)
        Me.txtInterest.TabIndex = 6
        Me.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Location = New System.Drawing.Point(624, 73)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 7
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(138, 39)
        Me.txtDesc.MaxLength = 50
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(282, 20)
        Me.txtDesc.TabIndex = 1
        '
        'txtMonthlyAmount
        '
        Me.txtMonthlyAmount.Location = New System.Drawing.Point(624, 99)
        Me.txtMonthlyAmount.Name = "txtMonthlyAmount"
        Me.txtMonthlyAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtMonthlyAmount.TabIndex = 8
        Me.txtMonthlyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Loan Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Loan Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(458, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Loan Amount"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(458, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Loan Interest"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(458, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Total Loan Amount"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(458, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Indicative Payment"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 204)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Action"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Payment"
        '
        'txtPayment
        '
        Me.txtPayment.Location = New System.Drawing.Point(80, 228)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.Size = New System.Drawing.Size(139, 20)
        Me.txtPayment.TabIndex = 81
        Me.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Loan Status"
        '
        'ComboStatus
        '
        Me.ComboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStatus.FormattingEnabled = True
        Me.ComboStatus.Location = New System.Drawing.Point(138, 119)
        Me.ComboStatus.Name = "ComboStatus"
        Me.ComboStatus.Size = New System.Drawing.Size(282, 21)
        Me.ComboStatus.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblBasic)
        Me.GroupBox1.Controls.Add(Me.ComboStatus)
        Me.GroupBox1.Controls.Add(Me.DateFrom)
        Me.GroupBox1.Controls.Add(Me.ComboDedCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLoanCode)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtInterest)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMonthlyAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(824, 154)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(242, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 23)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(433, 11)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 67
        Me.txtId.Visible = False
        '
        'txtHeaderId
        '
        Me.txtHeaderId.Location = New System.Drawing.Point(570, 7)
        Me.txtHeaderId.MaxLength = 9
        Me.txtHeaderId.Name = "txtHeaderId"
        Me.txtHeaderId.Size = New System.Drawing.Size(70, 20)
        Me.txtHeaderId.TabIndex = 87
        Me.txtHeaderId.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(470, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Remaining Amount"
        '
        'txtRemAmount
        '
        Me.txtRemAmount.Enabled = False
        Me.txtRemAmount.Location = New System.Drawing.Point(636, 224)
        Me.txtRemAmount.Name = "txtRemAmount"
        Me.txtRemAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtRemAmount.TabIndex = 88
        Me.txtRemAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSetAsClosed
        '
        Me.btnSetAsClosed.Location = New System.Drawing.Point(241, 201)
        Me.btnSetAsClosed.Name = "btnSetAsClosed"
        Me.btnSetAsClosed.Size = New System.Drawing.Size(191, 23)
        Me.btnSetAsClosed.TabIndex = 90
        Me.btnSetAsClosed.Text = "Change Status to Closed"
        Me.btnSetAsClosed.UseVisualStyleBackColor = True
        '
        'FrmLoanTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(849, 677)
        Me.Controls.Add(Me.btnSetAsClosed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRemAmount)
        Me.Controls.Add(Me.txtHeaderId)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPayment)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.ComboAction)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmLoanTransaction"
        Me.Text = "Employee LoanTransaction"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboAction As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboDedCode As System.Windows.Forms.ComboBox
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBasic As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLoanCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthlyAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtHeaderId As System.Windows.Forms.TextBox
    Friend WithEvents dgcEmpSal_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Basic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Cola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_IsCola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffPayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUsr_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffArrearsDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthlyAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuNewLoan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuNewPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnSetAsClosed As System.Windows.Forms.Button
    Friend WithEvents NewLoanEventToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
