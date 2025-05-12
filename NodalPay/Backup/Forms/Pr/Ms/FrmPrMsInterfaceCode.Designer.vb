<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsInterfaceCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrMsInterfaceCode))
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.lblPayTypCode = New System.Windows.Forms.Label
        Me.cmbTemGrp = New System.Windows.Forms.ComboBox
        Me.lblDescriptionL = New System.Windows.Forms.Label
        Me.txtDescriptionL = New System.Windows.Forms.TextBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcTemGrp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPayTyp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.TSBMask = New System.Windows.Forms.ToolStripSplitButton
        Me.Copy = New System.Windows.Forms.ToolStripButton
        Me.ErrCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrPayTypCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrDescriptionL = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrDescriptionS = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrIsActive = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAccountType = New System.Windows.Forms.ComboBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrPayTypCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDescriptionL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDescriptionS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(37, 40)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(32, 13)
        Me.lblCode.TabIndex = 30
        Me.lblCode.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(157, 40)
        Me.txtCode.MaxLength = 20
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 31
        '
        'lblPayTypCode
        '
        Me.lblPayTypCode.AutoSize = True
        Me.lblPayTypCode.Location = New System.Drawing.Point(37, 63)
        Me.lblPayTypCode.Name = "lblPayTypCode"
        Me.lblPayTypCode.Size = New System.Drawing.Size(83, 13)
        Me.lblPayTypCode.TabIndex = 32
        Me.lblPayTypCode.Text = "Group Template"
        '
        'cmbTemGrp
        '
        Me.cmbTemGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemGrp.Location = New System.Drawing.Point(157, 62)
        Me.cmbTemGrp.Name = "cmbTemGrp"
        Me.cmbTemGrp.Size = New System.Drawing.Size(250, 21)
        Me.cmbTemGrp.TabIndex = 33
        '
        'lblDescriptionL
        '
        Me.lblDescriptionL.AutoSize = True
        Me.lblDescriptionL.Location = New System.Drawing.Point(36, 86)
        Me.lblDescriptionL.Name = "lblDescriptionL"
        Me.lblDescriptionL.Size = New System.Drawing.Size(60, 13)
        Me.lblDescriptionL.TabIndex = 34
        Me.lblDescriptionL.Text = "Description"
        '
        'txtDescriptionL
        '
        Me.txtDescriptionL.Location = New System.Drawing.Point(157, 85)
        Me.txtDescriptionL.MaxLength = 40
        Me.txtDescriptionL.Name = "txtDescriptionL"
        Me.txtDescriptionL.Size = New System.Drawing.Size(250, 20)
        Me.txtDescriptionL.TabIndex = 35
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTemGrp_Code, Me.dgcPayTyp_Code, Me.dgcTemGrp_DescriptionL, Me.Column1})
        Me.DG1.Location = New System.Drawing.Point(12, 134)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(963, 376)
        Me.DG1.TabIndex = 36
        '
        'dgcTemGrp_Code
        '
        Me.dgcTemGrp_Code.DataPropertyName = "IntCod_Code"
        Me.dgcTemGrp_Code.FillWeight = 150.0!
        Me.dgcTemGrp_Code.HeaderText = "Code"
        Me.dgcTemGrp_Code.Name = "dgcTemGrp_Code"
        Me.dgcTemGrp_Code.ReadOnly = True
        Me.dgcTemGrp_Code.Width = 150
        '
        'dgcPayTyp_Code
        '
        Me.dgcPayTyp_Code.DataPropertyName = "TemGrp_Code"
        Me.dgcPayTyp_Code.FillWeight = 150.0!
        Me.dgcPayTyp_Code.HeaderText = "Payroll Type Code"
        Me.dgcPayTyp_Code.Name = "dgcPayTyp_Code"
        Me.dgcPayTyp_Code.ReadOnly = True
        Me.dgcPayTyp_Code.Width = 150
        '
        'dgcTemGrp_DescriptionL
        '
        Me.dgcTemGrp_DescriptionL.DataPropertyName = "IntCod_Description"
        Me.dgcTemGrp_DescriptionL.FillWeight = 150.0!
        Me.dgcTemGrp_DescriptionL.HeaderText = "Long Description"
        Me.dgcTemGrp_DescriptionL.Name = "dgcTemGrp_DescriptionL"
        Me.dgcTemGrp_DescriptionL.ReadOnly = True
        Me.dgcTemGrp_DescriptionL.Width = 250
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "IntCod_AccountType"
        Me.Column1.HeaderText = "Account Type"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel, Me.TSBMask, Me.Copy})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(390, 25)
        Me.TS1.TabIndex = 37
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
        'TSBMask
        '
        Me.TSBMask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBMask.Image = CType(resources.GetObject("TSBMask.Image"), System.Drawing.Image)
        Me.TSBMask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBMask.Name = "TSBMask"
        Me.TSBMask.Size = New System.Drawing.Size(99, 22)
        Me.TSBMask.Text = "Code Masking"
        '
        'Copy
        '
        Me.Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Copy.Image = CType(resources.GetObject("Copy.Image"), System.Drawing.Image)
        Me.Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Copy.Name = "Copy"
        Me.Copy.Size = New System.Drawing.Size(39, 22)
        Me.Copy.Text = "Copy"
        '
        'ErrCode
        '
        Me.ErrCode.ContainerControl = Me
        '
        'ErrPayTypCode
        '
        Me.ErrPayTypCode.ContainerControl = Me
        '
        'ErrDescriptionL
        '
        Me.ErrDescriptionL.ContainerControl = Me
        '
        'ErrDescriptionS
        '
        Me.ErrDescriptionS.ContainerControl = Me
        '
        'ErrIsActive
        '
        Me.ErrIsActive.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Account Type"
        '
        'cmbAccountType
        '
        Me.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountType.Location = New System.Drawing.Point(157, 107)
        Me.cmbAccountType.Name = "cmbAccountType"
        Me.cmbAccountType.Size = New System.Drawing.Size(250, 21)
        Me.cmbAccountType.TabIndex = 39
        '
        'FrmPrMsInterfaceCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(987, 551)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbAccountType)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblPayTypCode)
        Me.Controls.Add(Me.cmbTemGrp)
        Me.Controls.Add(Me.lblDescriptionL)
        Me.Controls.Add(Me.txtDescriptionL)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmPrMsInterfaceCode"
        Me.Text = "Interface Code Maintenance Screen"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblPayTypCode As System.Windows.Forms.Label
    Friend WithEvents cmbTemGrp As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescriptionL As System.Windows.Forms.Label
    Friend WithEvents txtDescriptionL As System.Windows.Forms.TextBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrPayTypCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrDescriptionL As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrDescriptionS As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrIsActive As System.Windows.Forms.ErrorProvider
    Friend WithEvents TSBMask As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents dgcTemGrp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPayTyp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Copy As System.Windows.Forms.ToolStripButton
End Class
