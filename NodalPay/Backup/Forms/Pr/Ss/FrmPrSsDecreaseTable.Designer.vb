<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrSsDecreaseTable
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrSsDecreaseTable))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.lblTaxTbl_AmendDate = New System.Windows.Forms.Label
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcTaxTbl_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_Sequence = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_BracketAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_BracketRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTaxTbl_AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTaxTbl_Code = New System.Windows.Forms.TextBox
        Me.txtTaxTbl_DedRate = New System.Windows.Forms.TextBox
        Me.lblTaxTbl_CreationDate = New System.Windows.Forms.Label
        Me.lblTaxTbl_BracketRate = New System.Windows.Forms.Label
        Me.lblTaxTbl_CreatedBy = New System.Windows.Forms.Label
        Me.cmbTaxTbl_CreatedBy = New System.Windows.Forms.ComboBox
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.TSC1 = New System.Windows.Forms.ToolStripContainer
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.txtTaxTbl_id = New System.Windows.Forms.TextBox
        Me.lblTaxTbl_id = New System.Windows.Forms.Label
        Me.lblTaxTbl_BracketAmount = New System.Windows.Forms.Label
        Me.lblTaxTbl_Sequence = New System.Windows.Forms.Label
        Me.txtTaxTbl_BracketAmount = New System.Windows.Forms.TextBox
        Me.ErrTaxTbl_Sequence = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrTaxTbl_BracketRate = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrTaxTbl_BracketAmount = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DateAmend = New System.Windows.Forms.DateTimePicker
        Me.lblTaxTbl_AmendBy = New System.Windows.Forms.Label
        Me.ErrTaxTbl_id = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrTaxTbl_AmendBy = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbTaxTbl_AmendBy = New System.Windows.Forms.ComboBox
        Me.ErrTaxTbl_CreatedBy = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DateCreated = New System.Windows.Forms.DateTimePicker
        Me.txtTaxTbl_Sequence = New System.Windows.Forms.TextBox
        Me.ErrTaxTbl_CreationDate = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ErrTaxTbl_AmendDate = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        Me.TSC1.TopToolStripPanel.SuspendLayout()
        Me.TSC1.SuspendLayout()
        Me.sspStatus.SuspendLayout()
        CType(Me.ErrTaxTbl_Sequence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_BracketRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_BracketAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_id, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_AmendBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_CreatedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_CreationDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrTaxTbl_AmendDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSBDelete
        '
        Me.TSBDelete.AutoSize = False
        Me.TSBDelete.Image = CType(resources.GetObject("TSBDelete.Image"), System.Drawing.Image)
        Me.TSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(60, 22)
        Me.TSBDelete.Text = "Delete"
        Me.TSBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTaxTbl_AmendDate
        '
        Me.lblTaxTbl_AmendDate.AutoSize = True
        Me.lblTaxTbl_AmendDate.Location = New System.Drawing.Point(37, 180)
        Me.lblTaxTbl_AmendDate.Name = "lblTaxTbl_AmendDate"
        Me.lblTaxTbl_AmendDate.Size = New System.Drawing.Size(66, 13)
        Me.lblTaxTbl_AmendDate.TabIndex = 48
        Me.lblTaxTbl_AmendDate.Text = "Amend Date"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTaxTbl_id, Me.dgcTaxTbl_Sequence, Me.Column1, Me.dgcTaxTbl_BracketAmount, Me.dgcTaxTbl_BracketRate, Me.dgcTaxTbl_CreationDate, Me.dgcTaxTbl_CreatedBy, Me.dgcTaxTbl_AmendDate, Me.dgcTaxTbl_AmendBy})
        Me.DG1.Location = New System.Drawing.Point(12, 244)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(963, 272)
        Me.DG1.TabIndex = 51
        '
        'dgcTaxTbl_id
        '
        Me.dgcTaxTbl_id.DataPropertyName = "DecTbl_id"
        Me.dgcTaxTbl_id.FillWeight = 150.0!
        Me.dgcTaxTbl_id.HeaderText = "id"
        Me.dgcTaxTbl_id.Name = "dgcTaxTbl_id"
        Me.dgcTaxTbl_id.ReadOnly = True
        Me.dgcTaxTbl_id.Width = 64
        '
        'dgcTaxTbl_Sequence
        '
        Me.dgcTaxTbl_Sequence.DataPropertyName = "DecTbl_Sequence"
        Me.dgcTaxTbl_Sequence.FillWeight = 150.0!
        Me.dgcTaxTbl_Sequence.HeaderText = "Sequence"
        Me.dgcTaxTbl_Sequence.Name = "dgcTaxTbl_Sequence"
        Me.dgcTaxTbl_Sequence.ReadOnly = True
        Me.dgcTaxTbl_Sequence.Width = 60
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "DecTbl_Code"
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'dgcTaxTbl_BracketAmount
        '
        Me.dgcTaxTbl_BracketAmount.DataPropertyName = "DecTbl_BracketAmount"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgcTaxTbl_BracketAmount.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcTaxTbl_BracketAmount.FillWeight = 150.0!
        Me.dgcTaxTbl_BracketAmount.HeaderText = "BracketAmount"
        Me.dgcTaxTbl_BracketAmount.Name = "dgcTaxTbl_BracketAmount"
        Me.dgcTaxTbl_BracketAmount.ReadOnly = True
        '
        'dgcTaxTbl_BracketRate
        '
        Me.dgcTaxTbl_BracketRate.DataPropertyName = "DecTbl_DedRate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgcTaxTbl_BracketRate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgcTaxTbl_BracketRate.FillWeight = 150.0!
        Me.dgcTaxTbl_BracketRate.HeaderText = "Ded. Rate"
        Me.dgcTaxTbl_BracketRate.Name = "dgcTaxTbl_BracketRate"
        Me.dgcTaxTbl_BracketRate.ReadOnly = True
        '
        'dgcTaxTbl_CreationDate
        '
        Me.dgcTaxTbl_CreationDate.DataPropertyName = "DecTbl_CreationDate"
        DataGridViewCellStyle3.Format = "dd-MM-yyyy"
        Me.dgcTaxTbl_CreationDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgcTaxTbl_CreationDate.FillWeight = 150.0!
        Me.dgcTaxTbl_CreationDate.HeaderText = "CreationDate"
        Me.dgcTaxTbl_CreationDate.Name = "dgcTaxTbl_CreationDate"
        Me.dgcTaxTbl_CreationDate.ReadOnly = True
        Me.dgcTaxTbl_CreationDate.Width = 70
        '
        'dgcTaxTbl_CreatedBy
        '
        Me.dgcTaxTbl_CreatedBy.DataPropertyName = "DecTbl_CreatedBy"
        Me.dgcTaxTbl_CreatedBy.FillWeight = 150.0!
        Me.dgcTaxTbl_CreatedBy.HeaderText = "CreatedBy"
        Me.dgcTaxTbl_CreatedBy.Name = "dgcTaxTbl_CreatedBy"
        Me.dgcTaxTbl_CreatedBy.ReadOnly = True
        '
        'dgcTaxTbl_AmendDate
        '
        Me.dgcTaxTbl_AmendDate.DataPropertyName = "DecTbl_AmendDate"
        DataGridViewCellStyle4.Format = "dd-MM-yyyy"
        Me.dgcTaxTbl_AmendDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgcTaxTbl_AmendDate.FillWeight = 150.0!
        Me.dgcTaxTbl_AmendDate.HeaderText = "AmendDate"
        Me.dgcTaxTbl_AmendDate.Name = "dgcTaxTbl_AmendDate"
        Me.dgcTaxTbl_AmendDate.ReadOnly = True
        Me.dgcTaxTbl_AmendDate.Width = 70
        '
        'dgcTaxTbl_AmendBy
        '
        Me.dgcTaxTbl_AmendBy.DataPropertyName = "DecTbl_AmendBy"
        Me.dgcTaxTbl_AmendBy.FillWeight = 150.0!
        Me.dgcTaxTbl_AmendBy.HeaderText = "AmendBy"
        Me.dgcTaxTbl_AmendBy.Name = "dgcTaxTbl_AmendBy"
        Me.dgcTaxTbl_AmendBy.ReadOnly = True
        '
        'txtTaxTbl_Code
        '
        Me.txtTaxTbl_Code.Location = New System.Drawing.Point(157, 80)
        Me.txtTaxTbl_Code.MaxLength = 15
        Me.txtTaxTbl_Code.Name = "txtTaxTbl_Code"
        Me.txtTaxTbl_Code.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxTbl_Code.TabIndex = 56
        '
        'txtTaxTbl_DedRate
        '
        Me.txtTaxTbl_DedRate.Location = New System.Drawing.Point(157, 120)
        Me.txtTaxTbl_DedRate.MaxLength = 15
        Me.txtTaxTbl_DedRate.Name = "txtTaxTbl_DedRate"
        Me.txtTaxTbl_DedRate.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxTbl_DedRate.TabIndex = 44
        '
        'lblTaxTbl_CreationDate
        '
        Me.lblTaxTbl_CreationDate.AutoSize = True
        Me.lblTaxTbl_CreationDate.Location = New System.Drawing.Point(37, 140)
        Me.lblTaxTbl_CreationDate.Name = "lblTaxTbl_CreationDate"
        Me.lblTaxTbl_CreationDate.Size = New System.Drawing.Size(72, 13)
        Me.lblTaxTbl_CreationDate.TabIndex = 45
        Me.lblTaxTbl_CreationDate.Text = "Creation Date"
        '
        'lblTaxTbl_BracketRate
        '
        Me.lblTaxTbl_BracketRate.AutoSize = True
        Me.lblTaxTbl_BracketRate.Location = New System.Drawing.Point(37, 120)
        Me.lblTaxTbl_BracketRate.Name = "lblTaxTbl_BracketRate"
        Me.lblTaxTbl_BracketRate.Size = New System.Drawing.Size(82, 13)
        Me.lblTaxTbl_BracketRate.TabIndex = 43
        Me.lblTaxTbl_BracketRate.Text = "Deduction Rate"
        '
        'lblTaxTbl_CreatedBy
        '
        Me.lblTaxTbl_CreatedBy.AutoSize = True
        Me.lblTaxTbl_CreatedBy.Location = New System.Drawing.Point(37, 160)
        Me.lblTaxTbl_CreatedBy.Name = "lblTaxTbl_CreatedBy"
        Me.lblTaxTbl_CreatedBy.Size = New System.Drawing.Size(59, 13)
        Me.lblTaxTbl_CreatedBy.TabIndex = 47
        Me.lblTaxTbl_CreatedBy.Text = "Created By"
        '
        'cmbTaxTbl_CreatedBy
        '
        Me.cmbTaxTbl_CreatedBy.Enabled = False
        Me.cmbTaxTbl_CreatedBy.Location = New System.Drawing.Point(157, 160)
        Me.cmbTaxTbl_CreatedBy.Name = "cmbTaxTbl_CreatedBy"
        Me.cmbTaxTbl_CreatedBy.Size = New System.Drawing.Size(100, 21)
        Me.cmbTaxTbl_CreatedBy.TabIndex = 46
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
        Me.TSBNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(60, 22)
        Me.TSBNew.Text = "New"
        Me.TSBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.Image = CType(resources.GetObject("TSBSave.Image"), System.Drawing.Image)
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBExcel
        '
        Me.TSBExcel.AutoSize = False
        Me.TSBExcel.Image = Global.NodalPay.My.Resources.Resources.excel
        Me.TSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(60, 22)
        Me.TSBExcel.Text = "Excel"
        Me.TSBExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSC1
        '
        Me.TSC1.BottomToolStripPanelVisible = False
        '
        'TSC1.ContentPanel
        '
        Me.TSC1.ContentPanel.Size = New System.Drawing.Size(987, 1)
        Me.TSC1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TSC1.LeftToolStripPanelVisible = False
        Me.TSC1.Location = New System.Drawing.Point(0, 0)
        Me.TSC1.Name = "TSC1"
        Me.TSC1.RightToolStripPanelVisible = False
        Me.TSC1.Size = New System.Drawing.Size(987, 26)
        Me.TSC1.TabIndex = 52
        Me.TSC1.Text = "TSC1"
        '
        'TSC1.TopToolStripPanel
        '
        Me.TSC1.TopToolStripPanel.Controls.Add(Me.TS1)
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 529)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(987, 22)
        Me.sspStatus.TabIndex = 40
        Me.sspStatus.Text = "StatusStrip"
        '
        'txtTaxTbl_id
        '
        Me.txtTaxTbl_id.Enabled = False
        Me.txtTaxTbl_id.Location = New System.Drawing.Point(157, 40)
        Me.txtTaxTbl_id.MaxLength = 9
        Me.txtTaxTbl_id.Name = "txtTaxTbl_id"
        Me.txtTaxTbl_id.Size = New System.Drawing.Size(64, 20)
        Me.txtTaxTbl_id.TabIndex = 37
        '
        'lblTaxTbl_id
        '
        Me.lblTaxTbl_id.AutoSize = True
        Me.lblTaxTbl_id.Location = New System.Drawing.Point(37, 40)
        Me.lblTaxTbl_id.Name = "lblTaxTbl_id"
        Me.lblTaxTbl_id.Size = New System.Drawing.Size(15, 13)
        Me.lblTaxTbl_id.TabIndex = 36
        Me.lblTaxTbl_id.Text = "id"
        '
        'lblTaxTbl_BracketAmount
        '
        Me.lblTaxTbl_BracketAmount.AutoSize = True
        Me.lblTaxTbl_BracketAmount.Location = New System.Drawing.Point(37, 100)
        Me.lblTaxTbl_BracketAmount.Name = "lblTaxTbl_BracketAmount"
        Me.lblTaxTbl_BracketAmount.Size = New System.Drawing.Size(83, 13)
        Me.lblTaxTbl_BracketAmount.TabIndex = 42
        Me.lblTaxTbl_BracketAmount.Text = "Bracket Amount"
        '
        'lblTaxTbl_Sequence
        '
        Me.lblTaxTbl_Sequence.AutoSize = True
        Me.lblTaxTbl_Sequence.Location = New System.Drawing.Point(37, 60)
        Me.lblTaxTbl_Sequence.Name = "lblTaxTbl_Sequence"
        Me.lblTaxTbl_Sequence.Size = New System.Drawing.Size(56, 13)
        Me.lblTaxTbl_Sequence.TabIndex = 38
        Me.lblTaxTbl_Sequence.Text = "Sequence"
        '
        'txtTaxTbl_BracketAmount
        '
        Me.txtTaxTbl_BracketAmount.Location = New System.Drawing.Point(157, 100)
        Me.txtTaxTbl_BracketAmount.MaxLength = 15
        Me.txtTaxTbl_BracketAmount.Name = "txtTaxTbl_BracketAmount"
        Me.txtTaxTbl_BracketAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxTbl_BracketAmount.TabIndex = 41
        '
        'ErrTaxTbl_Sequence
        '
        Me.ErrTaxTbl_Sequence.ContainerControl = Me
        '
        'ErrTaxTbl_BracketRate
        '
        Me.ErrTaxTbl_BracketRate.ContainerControl = Me
        '
        'ErrTaxTbl_BracketAmount
        '
        Me.ErrTaxTbl_BracketAmount.ContainerControl = Me
        '
        'DateAmend
        '
        Me.DateAmend.Enabled = False
        Me.DateAmend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAmend.Location = New System.Drawing.Point(157, 181)
        Me.DateAmend.Name = "DateAmend"
        Me.DateAmend.Size = New System.Drawing.Size(100, 20)
        Me.DateAmend.TabIndex = 53
        '
        'lblTaxTbl_AmendBy
        '
        Me.lblTaxTbl_AmendBy.AutoSize = True
        Me.lblTaxTbl_AmendBy.Location = New System.Drawing.Point(37, 200)
        Me.lblTaxTbl_AmendBy.Name = "lblTaxTbl_AmendBy"
        Me.lblTaxTbl_AmendBy.Size = New System.Drawing.Size(55, 13)
        Me.lblTaxTbl_AmendBy.TabIndex = 50
        Me.lblTaxTbl_AmendBy.Text = "Amend By"
        '
        'ErrTaxTbl_id
        '
        Me.ErrTaxTbl_id.ContainerControl = Me
        '
        'ErrTaxTbl_AmendBy
        '
        Me.ErrTaxTbl_AmendBy.ContainerControl = Me
        '
        'cmbTaxTbl_AmendBy
        '
        Me.cmbTaxTbl_AmendBy.Enabled = False
        Me.cmbTaxTbl_AmendBy.Location = New System.Drawing.Point(157, 201)
        Me.cmbTaxTbl_AmendBy.Name = "cmbTaxTbl_AmendBy"
        Me.cmbTaxTbl_AmendBy.Size = New System.Drawing.Size(100, 21)
        Me.cmbTaxTbl_AmendBy.TabIndex = 49
        '
        'ErrTaxTbl_CreatedBy
        '
        Me.ErrTaxTbl_CreatedBy.ContainerControl = Me
        '
        'DateCreated
        '
        Me.DateCreated.Enabled = False
        Me.DateCreated.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCreated.Location = New System.Drawing.Point(157, 140)
        Me.DateCreated.Name = "DateCreated"
        Me.DateCreated.Size = New System.Drawing.Size(100, 20)
        Me.DateCreated.TabIndex = 54
        '
        'txtTaxTbl_Sequence
        '
        Me.txtTaxTbl_Sequence.Location = New System.Drawing.Point(157, 60)
        Me.txtTaxTbl_Sequence.MaxLength = 2
        Me.txtTaxTbl_Sequence.Name = "txtTaxTbl_Sequence"
        Me.txtTaxTbl_Sequence.Size = New System.Drawing.Size(64, 20)
        Me.txtTaxTbl_Sequence.TabIndex = 39
        '
        'ErrTaxTbl_CreationDate
        '
        Me.ErrTaxTbl_CreationDate.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Code"
        '
        'ErrTaxTbl_AmendDate
        '
        Me.ErrTaxTbl_AmendDate.ContainerControl = Me
        '
        'FrmPrSsDecreaseTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(987, 551)
        Me.Controls.Add(Me.lblTaxTbl_AmendDate)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.txtTaxTbl_Code)
        Me.Controls.Add(Me.txtTaxTbl_DedRate)
        Me.Controls.Add(Me.lblTaxTbl_CreationDate)
        Me.Controls.Add(Me.lblTaxTbl_BracketRate)
        Me.Controls.Add(Me.lblTaxTbl_CreatedBy)
        Me.Controls.Add(Me.cmbTaxTbl_CreatedBy)
        Me.Controls.Add(Me.TSC1)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.txtTaxTbl_id)
        Me.Controls.Add(Me.lblTaxTbl_id)
        Me.Controls.Add(Me.lblTaxTbl_BracketAmount)
        Me.Controls.Add(Me.lblTaxTbl_Sequence)
        Me.Controls.Add(Me.txtTaxTbl_BracketAmount)
        Me.Controls.Add(Me.DateAmend)
        Me.Controls.Add(Me.lblTaxTbl_AmendBy)
        Me.Controls.Add(Me.cmbTaxTbl_AmendBy)
        Me.Controls.Add(Me.DateCreated)
        Me.Controls.Add(Me.txtTaxTbl_Sequence)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPrSsDecreaseTable"
        Me.Text = "Decrease Of Income"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.TSC1.TopToolStripPanel.ResumeLayout(False)
        Me.TSC1.TopToolStripPanel.PerformLayout()
        Me.TSC1.ResumeLayout(False)
        Me.TSC1.PerformLayout()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        CType(Me.ErrTaxTbl_Sequence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_BracketRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_BracketAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_id, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_AmendBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_CreatedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_CreationDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrTaxTbl_AmendDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTaxTbl_AmendDate As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTaxTbl_Code As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxTbl_DedRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxTbl_CreationDate As System.Windows.Forms.Label
    Friend WithEvents lblTaxTbl_BracketRate As System.Windows.Forms.Label
    Friend WithEvents lblTaxTbl_CreatedBy As System.Windows.Forms.Label
    Friend WithEvents cmbTaxTbl_CreatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSC1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents txtTaxTbl_id As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxTbl_id As System.Windows.Forms.Label
    Friend WithEvents lblTaxTbl_BracketAmount As System.Windows.Forms.Label
    Friend WithEvents lblTaxTbl_Sequence As System.Windows.Forms.Label
    Friend WithEvents txtTaxTbl_BracketAmount As System.Windows.Forms.TextBox
    Friend WithEvents ErrTaxTbl_Sequence As System.Windows.Forms.ErrorProvider
    Friend WithEvents DateAmend As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTaxTbl_AmendBy As System.Windows.Forms.Label
    Friend WithEvents cmbTaxTbl_AmendBy As System.Windows.Forms.ComboBox
    Friend WithEvents DateCreated As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTaxTbl_Sequence As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrTaxTbl_BracketRate As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_BracketAmount As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_id As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_AmendBy As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_CreatedBy As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_CreationDate As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrTaxTbl_AmendDate As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgcTaxTbl_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_Sequence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_BracketAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_BracketRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTaxTbl_AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
