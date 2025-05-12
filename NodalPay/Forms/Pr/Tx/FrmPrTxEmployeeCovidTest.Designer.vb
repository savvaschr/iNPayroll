<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxEmployeeCovidTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrTxEmployeeCovidTest))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date1 = New System.Windows.Forms.DateTimePicker
        Me.lblId = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.dgcEmpSal_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_Basic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_IsCola = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcEmpSal_EffArrearsDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cov_Week = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cov_Month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cov_Result = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_anal1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_anal2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_Anal3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_Anal4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_Anal5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_genAnal1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmployeeName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox
        Me.TS1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Negative"
        '
        'Date1
        '
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(133, 94)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(100, 20)
        Me.Date1.TabIndex = 73
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(265, 103)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 68
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(316, 100)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 69
        Me.txtId.Visible = False
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
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
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
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 67
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
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcEmpSal_id, Me.dgcEmpSal_Value, Me.dgcEmpSal_Basic, Me.dgcEmpSal_IsCola, Me.dgcEmpSal_EffArrearsDate, Me.Cov_Week, Me.Cov_Month, Me.Cov_Result, Me.Emp_anal1, Me.Emp_anal2, Me.Emp_Anal3, Me.Emp_Anal4, Me.Emp_Anal5, Me.Emp_genAnal1})
        Me.DG1.Location = New System.Drawing.Point(7, 160)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(1025, 397)
        Me.DG1.TabIndex = 72
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 547)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(1065, 22)
        Me.sspStatus.TabIndex = 66
        Me.sspStatus.Text = "StatusStrip"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(133, 126)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 77
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dgcEmpSal_id
        '
        Me.dgcEmpSal_id.DataPropertyName = "Cov_Id"
        Me.dgcEmpSal_id.FillWeight = 150.0!
        Me.dgcEmpSal_id.HeaderText = "id"
        Me.dgcEmpSal_id.Name = "dgcEmpSal_id"
        Me.dgcEmpSal_id.ReadOnly = True
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
        Me.dgcEmpSal_Basic.DataPropertyName = "TemGrp_Code"
        Me.dgcEmpSal_Basic.FillWeight = 150.0!
        Me.dgcEmpSal_Basic.HeaderText = "Template"
        Me.dgcEmpSal_Basic.Name = "dgcEmpSal_Basic"
        Me.dgcEmpSal_Basic.ReadOnly = True
        Me.dgcEmpSal_Basic.Visible = False
        '
        'dgcEmpSal_IsCola
        '
        Me.dgcEmpSal_IsCola.DataPropertyName = "Com_Code"
        Me.dgcEmpSal_IsCola.FillWeight = 150.0!
        Me.dgcEmpSal_IsCola.HeaderText = "Company"
        Me.dgcEmpSal_IsCola.Name = "dgcEmpSal_IsCola"
        Me.dgcEmpSal_IsCola.ReadOnly = True
        Me.dgcEmpSal_IsCola.Visible = False
        Me.dgcEmpSal_IsCola.Width = 60
        '
        'dgcEmpSal_EffArrearsDate
        '
        Me.dgcEmpSal_EffArrearsDate.DataPropertyName = "Cov_Date"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgcEmpSal_EffArrearsDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgcEmpSal_EffArrearsDate.FillWeight = 150.0!
        Me.dgcEmpSal_EffArrearsDate.HeaderText = "Test Date"
        Me.dgcEmpSal_EffArrearsDate.Name = "dgcEmpSal_EffArrearsDate"
        Me.dgcEmpSal_EffArrearsDate.ReadOnly = True
        Me.dgcEmpSal_EffArrearsDate.Width = 200
        '
        'Cov_Week
        '
        Me.Cov_Week.DataPropertyName = "Cov_Week"
        Me.Cov_Week.HeaderText = "Cov_Week"
        Me.Cov_Week.Name = "Cov_Week"
        Me.Cov_Week.ReadOnly = True
        Me.Cov_Week.Visible = False
        '
        'Cov_Month
        '
        Me.Cov_Month.DataPropertyName = "Cov_Month"
        Me.Cov_Month.HeaderText = "Cov_Month"
        Me.Cov_Month.Name = "Cov_Month"
        Me.Cov_Month.ReadOnly = True
        Me.Cov_Month.Visible = False
        '
        'Cov_Result
        '
        Me.Cov_Result.DataPropertyName = "Cov_Result"
        Me.Cov_Result.HeaderText = "Is Negative"
        Me.Cov_Result.Name = "Cov_Result"
        Me.Cov_Result.ReadOnly = True
        '
        'Emp_anal1
        '
        Me.Emp_anal1.DataPropertyName = "Emp_anl1"
        Me.Emp_anal1.HeaderText = "Analysis 1 code"
        Me.Emp_anal1.Name = "Emp_anal1"
        Me.Emp_anal1.ReadOnly = True
        '
        'Emp_anal2
        '
        Me.Emp_anal2.DataPropertyName = "Emp_anl2"
        Me.Emp_anal2.HeaderText = "Analysis 2 code"
        Me.Emp_anal2.Name = "Emp_anal2"
        Me.Emp_anal2.ReadOnly = True
        '
        'Emp_Anal3
        '
        Me.Emp_Anal3.DataPropertyName = "Emp_Anl3"
        Me.Emp_Anal3.HeaderText = "Analysis 3 code"
        Me.Emp_Anal3.Name = "Emp_Anal3"
        Me.Emp_Anal3.ReadOnly = True
        '
        'Emp_Anal4
        '
        Me.Emp_Anal4.DataPropertyName = "Emp_anl4"
        Me.Emp_Anal4.HeaderText = "Analysis 4 code"
        Me.Emp_Anal4.Name = "Emp_Anal4"
        Me.Emp_Anal4.ReadOnly = True
        '
        'Emp_Anal5
        '
        Me.Emp_Anal5.DataPropertyName = "Emp_anl5"
        Me.Emp_Anal5.HeaderText = "Analysis 5 code"
        Me.Emp_Anal5.Name = "Emp_Anal5"
        Me.Emp_Anal5.ReadOnly = True
        '
        'Emp_genAnal1
        '
        Me.Emp_genAnal1.DataPropertyName = "Emp_GenAnal1"
        Me.Emp_genAnal1.HeaderText = "Gen . Anal 1"
        Me.Emp_genAnal1.Name = "Emp_genAnal1"
        Me.Emp_genAnal1.ReadOnly = True
        '
        'BtnNext
        '
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(374, 36)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 79
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(293, 36)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 80
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Employee Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(133, 65)
        Me.txtEmployeeName.MaxLength = 15
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(316, 20)
        Me.txtEmployeeName.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Employee Code"
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Location = New System.Drawing.Point(133, 39)
        Me.txtEmployeeCode.MaxLength = 15
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.ReadOnly = True
        Me.txtEmployeeCode.Size = New System.Drawing.Size(100, 20)
        Me.txtEmployeeCode.TabIndex = 83
        '
        'FrmPrTxEmployeeCovidTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 569)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.sspStatus)
        Me.Name = "FrmPrTxEmployeeCovidTest"
        Me.Text = "Employee Covid Test"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents dgcEmpSal_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_Basic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_IsCola As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEmpSal_EffArrearsDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cov_Week As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cov_Month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cov_Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_anal1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_anal2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_Anal3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_Anal4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_Anal5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_genAnal1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
End Class
