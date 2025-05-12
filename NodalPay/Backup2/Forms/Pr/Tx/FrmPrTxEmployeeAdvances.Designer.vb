<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxEmployeeAdvances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrTxEmployeeAdvances))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date1 = New System.Windows.Forms.DateTimePicker
        Me.lblId = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.lblEffArrearsDate = New System.Windows.Forms.Label
        Me.comboUser = New System.Windows.Forms.ComboBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcEmpSal_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Basic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_IsCola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffArrearsDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.sspStatus.SuspendLayout()
        Me.TS1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 496)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(400, 22)
        Me.sspStatus.TabIndex = 44
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 45
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Date"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(152, 96)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Amount"
        '
        'Date1
        '
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(152, 72)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(100, 20)
        Me.Date1.TabIndex = 56
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(268, 47)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 46
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(319, 44)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 47
        Me.txtId.Visible = False
        '
        'lblEffArrearsDate
        '
        Me.lblEffArrearsDate.AutoSize = True
        Me.lblEffArrearsDate.Location = New System.Drawing.Point(7, 44)
        Me.lblEffArrearsDate.Name = "lblEffArrearsDate"
        Me.lblEffArrearsDate.Size = New System.Drawing.Size(71, 13)
        Me.lblEffArrearsDate.TabIndex = 53
        Me.lblEffArrearsDate.Text = "Processed by"
        '
        'comboUser
        '
        Me.comboUser.Enabled = False
        Me.comboUser.Location = New System.Drawing.Point(152, 47)
        Me.comboUser.Name = "comboUser"
        Me.comboUser.Size = New System.Drawing.Size(100, 21)
        Me.comboUser.TabIndex = 51
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcEmpSal_id, Me.dgcEmpSal_Value, Me.dgcEmpSal_Basic, Me.dgcEmpSal_IsCola, Me.dgcEmpSal_EffArrearsDate})
        Me.DG1.Location = New System.Drawing.Point(7, 143)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(382, 285)
        Me.DG1.TabIndex = 54
        '
        'dgcEmpSal_id
        '
        Me.dgcEmpSal_id.DataPropertyName = "EmpAdv_Id"
        Me.dgcEmpSal_id.FillWeight = 150.0!
        Me.dgcEmpSal_id.HeaderText = "id"
        Me.dgcEmpSal_id.Name = "dgcEmpSal_id"
        Me.dgcEmpSal_id.ReadOnly = True
        Me.dgcEmpSal_id.Visible = False
        Me.dgcEmpSal_id.Width = 64
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
        'dgcEmpSal_Basic
        '
        Me.dgcEmpSal_Basic.DataPropertyName = "EmpAdv_Date"
        Me.dgcEmpSal_Basic.FillWeight = 150.0!
        Me.dgcEmpSal_Basic.HeaderText = "Date"
        Me.dgcEmpSal_Basic.Name = "dgcEmpSal_Basic"
        Me.dgcEmpSal_Basic.ReadOnly = True
        '
        'dgcEmpSal_IsCola
        '
        Me.dgcEmpSal_IsCola.DataPropertyName = "EmpAdv_User"
        Me.dgcEmpSal_IsCola.FillWeight = 150.0!
        Me.dgcEmpSal_IsCola.HeaderText = "Proc.By"
        Me.dgcEmpSal_IsCola.Name = "dgcEmpSal_IsCola"
        Me.dgcEmpSal_IsCola.ReadOnly = True
        Me.dgcEmpSal_IsCola.Visible = False
        Me.dgcEmpSal_IsCola.Width = 60
        '
        'dgcEmpSal_EffArrearsDate
        '
        Me.dgcEmpSal_EffArrearsDate.DataPropertyName = "EmpAdv_Amount"
        DataGridViewCellStyle1.Format = "0.00"
        Me.dgcEmpSal_EffArrearsDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcEmpSal_EffArrearsDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffArrearsDate.HeaderText = "Amount"
        Me.dgcEmpSal_EffArrearsDate.Name = "dgcEmpSal_EffArrearsDate"
        Me.dgcEmpSal_EffArrearsDate.ReadOnly = True
        Me.dgcEmpSal_EffArrearsDate.Width = 200
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(152, 449)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 453)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Total"
        '
        'FrmPrTxEmployeeAdvances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(400, 518)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblEffArrearsDate)
        Me.Controls.Add(Me.comboUser)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.sspStatus)
        Me.Name = "FrmPrTxEmployeeAdvances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Advances"
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblEffArrearsDate As System.Windows.Forms.Label
    Friend WithEvents comboUser As System.Windows.Forms.ComboBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgcEmpSal_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Basic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_IsCola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffArrearsDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
