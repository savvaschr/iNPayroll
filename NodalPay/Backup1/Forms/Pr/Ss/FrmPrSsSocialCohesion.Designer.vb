<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrSsSocialCohesion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrSsSocialCohesion))
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.ErrDedValue = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrDesc = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ErrConValue = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.lblDesc = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.lblDedValue = New System.Windows.Forms.Label
        Me.txtDedValue = New System.Windows.Forms.TextBox
        Me.lblConValue = New System.Windows.Forms.Label
        Me.txtConValue = New System.Windows.Forms.TextBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcMedFnd_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcMedFnd_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcMedFnd_DedValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcMedFnd_ConValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TS1.SuspendLayout()
        CType(Me.ErrDedValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspStatus.SuspendLayout()
        CType(Me.ErrConValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(3, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 4
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
        'ErrDedValue
        '
        Me.ErrDedValue.ContainerControl = Me
        '
        'ErrDesc
        '
        Me.ErrDesc.ContainerControl = Me
        '
        'ErrCode
        '
        Me.ErrCode.ContainerControl = Me
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 529)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(987, 22)
        Me.sspStatus.TabIndex = 5
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ErrConValue
        '
        Me.ErrConValue.ContainerControl = Me
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(30, 37)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(32, 13)
        Me.lblCode.TabIndex = 11
        Me.lblCode.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(150, 37)
        Me.txtCode.MaxLength = 4
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(34, 20)
        Me.txtCode.TabIndex = 12
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(30, 57)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(60, 13)
        Me.lblDesc.TabIndex = 14
        Me.lblDesc.Text = "Description"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(150, 57)
        Me.txtDesc.MaxLength = 40
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(250, 20)
        Me.txtDesc.TabIndex = 13
        '
        'lblDedValue
        '
        Me.lblDedValue.AutoSize = True
        Me.lblDedValue.Location = New System.Drawing.Point(30, 77)
        Me.lblDedValue.Name = "lblDedValue"
        Me.lblDedValue.Size = New System.Drawing.Size(86, 13)
        Me.lblDedValue.TabIndex = 16
        Me.lblDedValue.Text = "Deduction Value"
        '
        'txtDedValue
        '
        Me.txtDedValue.Location = New System.Drawing.Point(150, 77)
        Me.txtDedValue.MaxLength = 15
        Me.txtDedValue.Name = "txtDedValue"
        Me.txtDedValue.Size = New System.Drawing.Size(100, 20)
        Me.txtDedValue.TabIndex = 15
        '
        'lblConValue
        '
        Me.lblConValue.AutoSize = True
        Me.lblConValue.Location = New System.Drawing.Point(30, 97)
        Me.lblConValue.Name = "lblConValue"
        Me.lblConValue.Size = New System.Drawing.Size(93, 13)
        Me.lblConValue.TabIndex = 18
        Me.lblConValue.Text = "Contribution Value"
        '
        'txtConValue
        '
        Me.txtConValue.Location = New System.Drawing.Point(150, 97)
        Me.txtConValue.MaxLength = 15
        Me.txtConValue.Name = "txtConValue"
        Me.txtConValue.Size = New System.Drawing.Size(100, 20)
        Me.txtConValue.TabIndex = 17
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcMedFnd_Code, Me.dgcMedFnd_Desc, Me.dgcMedFnd_DedValue, Me.dgcMedFnd_ConValue})
        Me.DG1.Location = New System.Drawing.Point(5, 133)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(963, 378)
        Me.DG1.TabIndex = 19
        '
        'dgcMedFnd_Code
        '
        Me.dgcMedFnd_Code.DataPropertyName = "SocCoh_Code"
        Me.dgcMedFnd_Code.FillWeight = 150.0!
        Me.dgcMedFnd_Code.HeaderText = "Code"
        Me.dgcMedFnd_Code.Name = "dgcMedFnd_Code"
        Me.dgcMedFnd_Code.ReadOnly = True
        Me.dgcMedFnd_Code.Width = 60
        '
        'dgcMedFnd_Desc
        '
        Me.dgcMedFnd_Desc.DataPropertyName = "SocCoh_Desc"
        Me.dgcMedFnd_Desc.FillWeight = 150.0!
        Me.dgcMedFnd_Desc.HeaderText = "Description"
        Me.dgcMedFnd_Desc.Name = "dgcMedFnd_Desc"
        Me.dgcMedFnd_Desc.ReadOnly = True
        Me.dgcMedFnd_Desc.Width = 250
        '
        'dgcMedFnd_DedValue
        '
        Me.dgcMedFnd_DedValue.DataPropertyName = "SocCoh_DedValue"
        Me.dgcMedFnd_DedValue.FillWeight = 150.0!
        Me.dgcMedFnd_DedValue.HeaderText = "Deduction Value"
        Me.dgcMedFnd_DedValue.Name = "dgcMedFnd_DedValue"
        Me.dgcMedFnd_DedValue.ReadOnly = True
        '
        'dgcMedFnd_ConValue
        '
        Me.dgcMedFnd_ConValue.DataPropertyName = "SocCoh_ConValue"
        Me.dgcMedFnd_ConValue.FillWeight = 150.0!
        Me.dgcMedFnd_ConValue.HeaderText = "Contribution Value"
        Me.dgcMedFnd_ConValue.Name = "dgcMedFnd_ConValue"
        Me.dgcMedFnd_ConValue.ReadOnly = True
        '
        'FrmPrSsSocialCohesion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(987, 551)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.lblDedValue)
        Me.Controls.Add(Me.txtDedValue)
        Me.Controls.Add(Me.lblConValue)
        Me.Controls.Add(Me.txtConValue)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.sspStatus)
        Me.Name = "FrmPrSsSocialCohesion"
        Me.Text = "FrmPrSsSocialCohesion"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.ErrDedValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        CType(Me.ErrConValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrDedValue As System.Windows.Forms.ErrorProvider
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ErrDesc As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrConValue As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDedValue As System.Windows.Forms.Label
    Friend WithEvents txtDedValue As System.Windows.Forms.TextBox
    Friend WithEvents lblConValue As System.Windows.Forms.Label
    Friend WithEvents txtConValue As System.Windows.Forms.TextBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgcMedFnd_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMedFnd_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMedFnd_DedValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMedFnd_ConValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
