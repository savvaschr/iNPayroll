<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrMsTemplateGroup
Inherits System.Windows.Forms.Form
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
If Disposing AndAlso components IsNot Nothing Then
components.Dispose()
End If
MyBase.Dispose(Disposing)
End Sub
Private components As System.ComponentModel.IContainer
' AutoGenerated Form by Nodalsoft
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrMsTemplateGroup))
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcTemGrp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPayTyp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayUnits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAnl1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAnl2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSC1 = New System.Windows.Forms.ToolStripContainer
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.ErrCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblPayTypCode = New System.Windows.Forms.Label
        Me.cmbPayTypCode = New System.Windows.Forms.ComboBox
        Me.ErrPayTypCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDescriptionL = New System.Windows.Forms.Label
        Me.txtDescriptionL = New System.Windows.Forms.TextBox
        Me.ErrDescriptionL = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDescriptionS = New System.Windows.Forms.Label
        Me.txtDescriptionS = New System.Windows.Forms.TextBox
        Me.ErrDescriptionS = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblIsActive = New System.Windows.Forms.Label
        Me.ErrIsActive = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CBIsActive = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDayUnits = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGLAnl1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGlAnl2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbCompany = New System.Windows.Forms.ComboBox
        Me.sspStatus.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSC1.TopToolStripPanel.SuspendLayout()
        Me.TSC1.SuspendLayout()
        Me.TS1.SuspendLayout()
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrPayTypCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDescriptionL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDescriptionS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 559)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(987, 22)
        Me.sspStatus.TabIndex = 3
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTemGrp_Code, Me.dgcPayTyp_Code, Me.dgcTemGrp_DescriptionL, Me.dgcTemGrp_DescriptionS, Me.dgcTemGrp_IsActive, Me.DayUnits, Me.GLAnl1, Me.GLAnl2, Me.Company})
        Me.DG1.Location = New System.Drawing.Point(12, 233)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(963, 299)
        Me.DG1.TabIndex = 10
        '
        'dgcTemGrp_Code
        '
        Me.dgcTemGrp_Code.DataPropertyName = "TemGrp_Code"
        Me.dgcTemGrp_Code.FillWeight = 150.0!
        Me.dgcTemGrp_Code.HeaderText = "Code"
        Me.dgcTemGrp_Code.Name = "dgcTemGrp_Code"
        Me.dgcTemGrp_Code.ReadOnly = True
        Me.dgcTemGrp_Code.Width = 60
        '
        'dgcPayTyp_Code
        '
        Me.dgcPayTyp_Code.DataPropertyName = "PayTyp_Code"
        Me.dgcPayTyp_Code.FillWeight = 150.0!
        Me.dgcPayTyp_Code.HeaderText = "Payroll Type Code"
        Me.dgcPayTyp_Code.Name = "dgcPayTyp_Code"
        Me.dgcPayTyp_Code.ReadOnly = True
        '
        'dgcTemGrp_DescriptionL
        '
        Me.dgcTemGrp_DescriptionL.DataPropertyName = "TemGrp_DescriptionL"
        Me.dgcTemGrp_DescriptionL.FillWeight = 150.0!
        Me.dgcTemGrp_DescriptionL.HeaderText = "Long Description"
        Me.dgcTemGrp_DescriptionL.Name = "dgcTemGrp_DescriptionL"
        Me.dgcTemGrp_DescriptionL.ReadOnly = True
        Me.dgcTemGrp_DescriptionL.Width = 250
        '
        'dgcTemGrp_DescriptionS
        '
        Me.dgcTemGrp_DescriptionS.DataPropertyName = "TemGrp_DescriptionS"
        Me.dgcTemGrp_DescriptionS.FillWeight = 150.0!
        Me.dgcTemGrp_DescriptionS.HeaderText = "Short Description"
        Me.dgcTemGrp_DescriptionS.Name = "dgcTemGrp_DescriptionS"
        Me.dgcTemGrp_DescriptionS.ReadOnly = True
        '
        'dgcTemGrp_IsActive
        '
        Me.dgcTemGrp_IsActive.DataPropertyName = "TemGrp_IsActive"
        Me.dgcTemGrp_IsActive.FillWeight = 150.0!
        Me.dgcTemGrp_IsActive.HeaderText = "Is Active"
        Me.dgcTemGrp_IsActive.Name = "dgcTemGrp_IsActive"
        Me.dgcTemGrp_IsActive.ReadOnly = True
        Me.dgcTemGrp_IsActive.Width = 60
        '
        'DayUnits
        '
        Me.DayUnits.DataPropertyName = "TemGrp_DayUnits"
        DataGridViewCellStyle1.Format = "0.00"
        Me.DayUnits.DefaultCellStyle = DataGridViewCellStyle1
        Me.DayUnits.HeaderText = "Day Units"
        Me.DayUnits.Name = "DayUnits"
        Me.DayUnits.ReadOnly = True
        '
        'GLAnl1
        '
        Me.GLAnl1.DataPropertyName = "TemGrp_GlAnl1"
        Me.GLAnl1.HeaderText = "GLAnl1"
        Me.GLAnl1.Name = "GLAnl1"
        Me.GLAnl1.ReadOnly = True
        '
        'GLAnl2
        '
        Me.GLAnl2.DataPropertyName = "TemGrp_GLAnl2"
        Me.GLAnl2.HeaderText = "GLAnl2"
        Me.GLAnl2.Name = "GLAnl2"
        Me.GLAnl2.ReadOnly = True
        '
        'Company
        '
        Me.Company.DataPropertyName = "Com_Code"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
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
        Me.TSC1.TabIndex = 12
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
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(37, 40)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(32, 13)
        Me.lblCode.TabIndex = 0
        Me.lblCode.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(157, 40)
        Me.txtCode.MaxLength = 6
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 1
        '
        'ErrCode
        '
        Me.ErrCode.ContainerControl = Me
        '
        'lblPayTypCode
        '
        Me.lblPayTypCode.AutoSize = True
        Me.lblPayTypCode.Location = New System.Drawing.Point(37, 61)
        Me.lblPayTypCode.Name = "lblPayTypCode"
        Me.lblPayTypCode.Size = New System.Drawing.Size(93, 13)
        Me.lblPayTypCode.TabIndex = 2
        Me.lblPayTypCode.Text = "Payroll Type Code"
        '
        'cmbPayTypCode
        '
        Me.cmbPayTypCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPayTypCode.Location = New System.Drawing.Point(157, 61)
        Me.cmbPayTypCode.Name = "cmbPayTypCode"
        Me.cmbPayTypCode.Size = New System.Drawing.Size(100, 21)
        Me.cmbPayTypCode.TabIndex = 2
        '
        'ErrPayTypCode
        '
        Me.ErrPayTypCode.ContainerControl = Me
        '
        'lblDescriptionL
        '
        Me.lblDescriptionL.AutoSize = True
        Me.lblDescriptionL.Location = New System.Drawing.Point(36, 103)
        Me.lblDescriptionL.Name = "lblDescriptionL"
        Me.lblDescriptionL.Size = New System.Drawing.Size(87, 13)
        Me.lblDescriptionL.TabIndex = 3
        Me.lblDescriptionL.Text = "Long Description"
        '
        'txtDescriptionL
        '
        Me.txtDescriptionL.Location = New System.Drawing.Point(157, 105)
        Me.txtDescriptionL.MaxLength = 40
        Me.txtDescriptionL.Name = "txtDescriptionL"
        Me.txtDescriptionL.Size = New System.Drawing.Size(250, 20)
        Me.txtDescriptionL.TabIndex = 3
        '
        'ErrDescriptionL
        '
        Me.ErrDescriptionL.ContainerControl = Me
        '
        'lblDescriptionS
        '
        Me.lblDescriptionS.AutoSize = True
        Me.lblDescriptionS.Location = New System.Drawing.Point(37, 124)
        Me.lblDescriptionS.Name = "lblDescriptionS"
        Me.lblDescriptionS.Size = New System.Drawing.Size(88, 13)
        Me.lblDescriptionS.TabIndex = 4
        Me.lblDescriptionS.Text = "Short Description"
        '
        'txtDescriptionS
        '
        Me.txtDescriptionS.Location = New System.Drawing.Point(157, 126)
        Me.txtDescriptionS.MaxLength = 15
        Me.txtDescriptionS.Name = "txtDescriptionS"
        Me.txtDescriptionS.Size = New System.Drawing.Size(100, 20)
        Me.txtDescriptionS.TabIndex = 4
        '
        'ErrDescriptionS
        '
        Me.ErrDescriptionS.ContainerControl = Me
        '
        'lblIsActive
        '
        Me.lblIsActive.AutoSize = True
        Me.lblIsActive.Location = New System.Drawing.Point(37, 166)
        Me.lblIsActive.Name = "lblIsActive"
        Me.lblIsActive.Size = New System.Drawing.Size(48, 13)
        Me.lblIsActive.TabIndex = 5
        Me.lblIsActive.Text = "Is Active"
        '
        'ErrIsActive
        '
        Me.ErrIsActive.ContainerControl = Me
        '
        'CBIsActive
        '
        Me.CBIsActive.AutoSize = True
        Me.CBIsActive.Location = New System.Drawing.Point(157, 168)
        Me.CBIsActive.Name = "CBIsActive"
        Me.CBIsActive.Size = New System.Drawing.Size(15, 14)
        Me.CBIsActive.TabIndex = 13
        Me.CBIsActive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Day Units"
        '
        'txtDayUnits
        '
        Me.txtDayUnits.Location = New System.Drawing.Point(157, 147)
        Me.txtDayUnits.MaxLength = 15
        Me.txtDayUnits.Name = "txtDayUnits"
        Me.txtDayUnits.Size = New System.Drawing.Size(100, 20)
        Me.txtDayUnits.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "GL Analysis 1"
        '
        'txtGLAnl1
        '
        Me.txtGLAnl1.Location = New System.Drawing.Point(157, 183)
        Me.txtGLAnl1.MaxLength = 20
        Me.txtGLAnl1.Name = "txtGLAnl1"
        Me.txtGLAnl1.Size = New System.Drawing.Size(250, 20)
        Me.txtGLAnl1.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "GL Analysis 2"
        '
        'txtGlAnl2
        '
        Me.txtGlAnl2.Location = New System.Drawing.Point(157, 204)
        Me.txtGlAnl2.MaxLength = 20
        Me.txtGlAnl2.Name = "txtGlAnl2"
        Me.txtGlAnl2.Size = New System.Drawing.Size(250, 20)
        Me.txtGlAnl2.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Company"
        '
        'CmbCompany
        '
        Me.CmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompany.Location = New System.Drawing.Point(157, 83)
        Me.CmbCompany.Name = "CmbCompany"
        Me.CmbCompany.Size = New System.Drawing.Size(250, 21)
        Me.CmbCompany.TabIndex = 20
        '
        'frmPrMsTemplateGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(987, 581)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbCompany)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGlAnl2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGLAnl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDayUnits)
        Me.Controls.Add(Me.CBIsActive)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblPayTypCode)
        Me.Controls.Add(Me.cmbPayTypCode)
        Me.Controls.Add(Me.lblDescriptionL)
        Me.Controls.Add(Me.txtDescriptionL)
        Me.Controls.Add(Me.lblDescriptionS)
        Me.Controls.Add(Me.txtDescriptionS)
        Me.Controls.Add(Me.lblIsActive)
        Me.Controls.Add(Me.TSC1)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.DG1)
        Me.Name = "frmPrMsTemplateGroup"
        Me.Text = "Template Groups"
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSC1.TopToolStripPanel.ResumeLayout(False)
        Me.TSC1.TopToolStripPanel.PerformLayout()
        Me.TSC1.ResumeLayout(False)
        Me.TSC1.PerformLayout()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrPayTypCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrDescriptionL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrDescriptionS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrIsActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ErrCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblPayTypCode As System.Windows.Forms.Label
    Friend WithEvents cmbPayTypCode As System.Windows.Forms.ComboBox
    Friend WithEvents ErrPayTypCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDescriptionL As System.Windows.Forms.Label
    Friend WithEvents txtDescriptionL As System.Windows.Forms.TextBox
    Friend WithEvents ErrDescriptionL As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDescriptionS As System.Windows.Forms.Label
    Friend WithEvents txtDescriptionS As System.Windows.Forms.TextBox
    Friend WithEvents ErrDescriptionS As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblIsActive As System.Windows.Forms.Label
    Friend WithEvents ErrIsActive As System.Windows.Forms.ErrorProvider
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TSC1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents CBIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDayUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGlAnl2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGLAnl1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents dgcTemGrp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPayTyp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAnl1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAnl2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
