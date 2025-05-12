<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrSsSectorPay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrSsSectorPay))
        Me.lblCode = New System.Windows.Forms.Label
        Me.lblDesc = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.ErrCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.ErrDesc = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDedValue = New System.Windows.Forms.Label
        Me.ErrDedValue = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtHourRate = New System.Windows.Forms.TextBox
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSC1 = New System.Windows.Forms.ToolStripContainer
        Me.ErrConValue = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgcMedFnd_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcMedFnd_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcMedFnd_DedValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDedValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspStatus.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        Me.TSC1.TopToolStripPanel.SuspendLayout()
        Me.TSC1.SuspendLayout()
        CType(Me.ErrConValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(37, 40)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(32, 13)
        Me.lblCode.TabIndex = 13
        Me.lblCode.Text = "Code"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(37, 60)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(60, 13)
        Me.lblDesc.TabIndex = 15
        Me.lblDesc.Text = "Description"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(157, 60)
        Me.txtDesc.MaxLength = 40
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(250, 20)
        Me.txtDesc.TabIndex = 16
        '
        'ErrCode
        '
        Me.ErrCode.ContainerControl = Me
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(157, 40)
        Me.txtCode.MaxLength = 4
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(34, 20)
        Me.txtCode.TabIndex = 14
        '
        'ErrDesc
        '
        Me.ErrDesc.ContainerControl = Me
        '
        'lblDedValue
        '
        Me.lblDedValue.AutoSize = True
        Me.lblDedValue.Location = New System.Drawing.Point(37, 80)
        Me.lblDedValue.Name = "lblDedValue"
        Me.lblDedValue.Size = New System.Drawing.Size(64, 13)
        Me.lblDedValue.TabIndex = 17
        Me.lblDedValue.Text = "Sector Rate"
        '
        'ErrDedValue
        '
        Me.ErrDedValue.ContainerControl = Me
        '
        'txtHourRate
        '
        Me.txtHourRate.Location = New System.Drawing.Point(157, 80)
        Me.txtHourRate.MaxLength = 15
        Me.txtHourRate.Name = "txtHourRate"
        Me.txtHourRate.Size = New System.Drawing.Size(100, 20)
        Me.txtHourRate.TabIndex = 18
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 529)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(987, 22)
        Me.sspStatus.TabIndex = 19
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
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
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcMedFnd_Code, Me.dgcMedFnd_Desc, Me.dgcMedFnd_DedValue})
        Me.DG1.Location = New System.Drawing.Point(12, 136)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(963, 378)
        Me.DG1.TabIndex = 22
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
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(3, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 0
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
        Me.TSC1.TabIndex = 23
        Me.TSC1.Text = "TSC1"
        '
        'TSC1.TopToolStripPanel
        '
        Me.TSC1.TopToolStripPanel.Controls.Add(Me.TS1)
        '
        'ErrConValue
        '
        Me.ErrConValue.ContainerControl = Me
        '
        'dgcMedFnd_Code
        '
        Me.dgcMedFnd_Code.DataPropertyName = "SecPay_Code"
        Me.dgcMedFnd_Code.FillWeight = 150.0!
        Me.dgcMedFnd_Code.HeaderText = "Code"
        Me.dgcMedFnd_Code.Name = "dgcMedFnd_Code"
        Me.dgcMedFnd_Code.ReadOnly = True
        Me.dgcMedFnd_Code.Width = 60
        '
        'dgcMedFnd_Desc
        '
        Me.dgcMedFnd_Desc.DataPropertyName = "SecPay_Desc"
        Me.dgcMedFnd_Desc.FillWeight = 150.0!
        Me.dgcMedFnd_Desc.HeaderText = "Description"
        Me.dgcMedFnd_Desc.Name = "dgcMedFnd_Desc"
        Me.dgcMedFnd_Desc.ReadOnly = True
        Me.dgcMedFnd_Desc.Width = 250
        '
        'dgcMedFnd_DedValue
        '
        Me.dgcMedFnd_DedValue.DataPropertyName = "SecPay_HourRate"
        Me.dgcMedFnd_DedValue.FillWeight = 150.0!
        Me.dgcMedFnd_DedValue.HeaderText = "Sector Rate"
        Me.dgcMedFnd_DedValue.Name = "dgcMedFnd_DedValue"
        Me.dgcMedFnd_DedValue.ReadOnly = True
        '
        'FrmPsSsSectorPay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 551)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblDedValue)
        Me.Controls.Add(Me.txtHourRate)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.TSC1)
        Me.Name = "FrmPsSsSectorPay"
        Me.Text = "FrmPsSsSectorPay"
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrDedValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.TSC1.TopToolStripPanel.ResumeLayout(False)
        Me.TSC1.TopToolStripPanel.PerformLayout()
        Me.TSC1.ResumeLayout(False)
        Me.TSC1.PerformLayout()
        CType(Me.ErrConValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents ErrCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDedValue As System.Windows.Forms.Label
    Friend WithEvents txtHourRate As System.Windows.Forms.TextBox
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TSC1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrDesc As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrDedValue As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrConValue As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgcMedFnd_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMedFnd_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMedFnd_DedValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
