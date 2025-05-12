<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsReminder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrMsReminder))
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmployeeName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.DateReq = New System.Windows.Forms.DateTimePicker
        Me.lblId = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.lblEffPayDate = New System.Windows.Forms.Label
        Me.lblCola = New System.Windows.Forms.Label
        Me.lblEffArrearsDate = New System.Windows.Forms.Label
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Notes = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.CBIsActive = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDeactivatedBy = New System.Windows.Forms.TextBox
        Me.txtDeactivatedAt = New System.Windows.Forms.TextBox
        Me.txtCreatedAt = New System.Windows.Forms.TextBox
        Me.txtCreatedBy = New System.Windows.Forms.TextBox
        Me.Rem_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_Reminderdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_CreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_DeactivatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_DeactivatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sspStatus.SuspendLayout()
        Me.TS1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Employee Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(134, 61)
        Me.txtEmployeeName.MaxLength = 15
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(316, 20)
        Me.txtEmployeeName.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Employee Code"
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Location = New System.Drawing.Point(134, 35)
        Me.txtEmployeeCode.MaxLength = 15
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.ReadOnly = True
        Me.txtEmployeeCode.Size = New System.Drawing.Size(100, 20)
        Me.txtEmployeeCode.TabIndex = 104
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 666)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(993, 22)
        Me.sspStatus.TabIndex = 97
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
        Me.TS1.TabIndex = 77
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
        'DateReq
        '
        Me.DateReq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateReq.Location = New System.Drawing.Point(132, 95)
        Me.DateReq.Name = "DateReq"
        Me.DateReq.Size = New System.Drawing.Size(100, 20)
        Me.DateReq.TabIndex = 89
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(402, 5)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(15, 13)
        Me.lblId.TabIndex = 78
        Me.lblId.Text = "id"
        Me.lblId.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(504, 5)
        Me.txtId.MaxLength = 9
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(70, 20)
        Me.txtId.TabIndex = 79
        Me.txtId.Visible = False
        '
        'lblEffPayDate
        '
        Me.lblEffPayDate.AutoSize = True
        Me.lblEffPayDate.Location = New System.Drawing.Point(14, 336)
        Me.lblEffPayDate.Name = "lblEffPayDate"
        Me.lblEffPayDate.Size = New System.Drawing.Size(56, 13)
        Me.lblEffPayDate.TabIndex = 82
        Me.lblEffPayDate.Text = "Created at"
        '
        'lblCola
        '
        Me.lblCola.AutoSize = True
        Me.lblCola.Location = New System.Drawing.Point(14, 96)
        Me.lblCola.Name = "lblCola"
        Me.lblCola.Size = New System.Drawing.Size(85, 13)
        Me.lblCola.TabIndex = 84
        Me.lblCola.Text = "Requested Date"
        '
        'lblEffArrearsDate
        '
        Me.lblEffArrearsDate.AutoSize = True
        Me.lblEffArrearsDate.Location = New System.Drawing.Point(14, 311)
        Me.lblEffArrearsDate.Name = "lblEffArrearsDate"
        Me.lblEffArrearsDate.Size = New System.Drawing.Size(58, 13)
        Me.lblEffArrearsDate.TabIndex = 85
        Me.lblEffArrearsDate.Text = "Created by"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.AllowUserToOrderColumns = True
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rem_Id, Me.Emp_Code, Me.Rem_Description, Me.Rem_Reminderdate, Me.Rem_IsActive, Me.Rem_CreatedBy, Me.Rem_CreatedAt, Me.Rem_DeactivatedBy, Me.Rem_DeactivatedAt})
        Me.DG1.Location = New System.Drawing.Point(9, 410)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(972, 266)
        Me.DG1.TabIndex = 86
        '
        'BtnNext
        '
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(377, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 102
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(296, 32)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 103
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 386)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Deactivated at"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 361)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Deactivated by"
        '
        'Notes
        '
        Me.Notes.AutoSize = True
        Me.Notes.Location = New System.Drawing.Point(14, 142)
        Me.Notes.Name = "Notes"
        Me.Notes.Size = New System.Drawing.Size(35, 13)
        Me.Notes.TabIndex = 112
        Me.Notes.Text = "Notes"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(132, 141)
        Me.txtNotes.MaxLength = 300
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(846, 163)
        Me.txtNotes.TabIndex = 113
        '
        'CBIsActive
        '
        Me.CBIsActive.AutoSize = True
        Me.CBIsActive.Location = New System.Drawing.Point(132, 121)
        Me.CBIsActive.Name = "CBIsActive"
        Me.CBIsActive.Size = New System.Drawing.Size(15, 14)
        Me.CBIsActive.TabIndex = 114
        Me.CBIsActive.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Is Active"
        '
        'txtDeactivatedBy
        '
        Me.txtDeactivatedBy.Location = New System.Drawing.Point(132, 358)
        Me.txtDeactivatedBy.Name = "txtDeactivatedBy"
        Me.txtDeactivatedBy.Size = New System.Drawing.Size(100, 20)
        Me.txtDeactivatedBy.TabIndex = 116
        '
        'txtDeactivatedAt
        '
        Me.txtDeactivatedAt.Location = New System.Drawing.Point(132, 380)
        Me.txtDeactivatedAt.Name = "txtDeactivatedAt"
        Me.txtDeactivatedAt.Size = New System.Drawing.Size(100, 20)
        Me.txtDeactivatedAt.TabIndex = 117
        '
        'txtCreatedAt
        '
        Me.txtCreatedAt.Location = New System.Drawing.Point(132, 333)
        Me.txtCreatedAt.Name = "txtCreatedAt"
        Me.txtCreatedAt.Size = New System.Drawing.Size(100, 20)
        Me.txtCreatedAt.TabIndex = 119
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Location = New System.Drawing.Point(132, 311)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Size = New System.Drawing.Size(100, 20)
        Me.txtCreatedBy.TabIndex = 118
        '
        'Rem_Id
        '
        Me.Rem_Id.DataPropertyName = "Rem_Id"
        Me.Rem_Id.HeaderText = "Rem_Id"
        Me.Rem_Id.Name = "Rem_Id"
        Me.Rem_Id.ReadOnly = True
        Me.Rem_Id.Width = 5
        '
        'Emp_Code
        '
        Me.Emp_Code.DataPropertyName = "Emp_Code"
        Me.Emp_Code.HeaderText = "Emp. Code"
        Me.Emp_Code.Name = "Emp_Code"
        Me.Emp_Code.ReadOnly = True
        '
        'Rem_Description
        '
        Me.Rem_Description.DataPropertyName = "Rem_Description"
        Me.Rem_Description.HeaderText = "Notes"
        Me.Rem_Description.Name = "Rem_Description"
        Me.Rem_Description.ReadOnly = True
        '
        'Rem_Reminderdate
        '
        Me.Rem_Reminderdate.DataPropertyName = "Rem_Reminderdate"
        Me.Rem_Reminderdate.HeaderText = "Reminder"
        Me.Rem_Reminderdate.Name = "Rem_Reminderdate"
        Me.Rem_Reminderdate.ReadOnly = True
        '
        'Rem_IsActive
        '
        Me.Rem_IsActive.DataPropertyName = "Rem_IsActive"
        Me.Rem_IsActive.HeaderText = "Is Active"
        Me.Rem_IsActive.Name = "Rem_IsActive"
        Me.Rem_IsActive.ReadOnly = True
        '
        'Rem_CreatedBy
        '
        Me.Rem_CreatedBy.DataPropertyName = "Rem_CreatedBy"
        Me.Rem_CreatedBy.HeaderText = "Created By"
        Me.Rem_CreatedBy.Name = "Rem_CreatedBy"
        Me.Rem_CreatedBy.ReadOnly = True
        '
        'Rem_CreatedAt
        '
        Me.Rem_CreatedAt.DataPropertyName = "Rem_CreatedAt"
        Me.Rem_CreatedAt.HeaderText = "Created At"
        Me.Rem_CreatedAt.Name = "Rem_CreatedAt"
        Me.Rem_CreatedAt.ReadOnly = True
        '
        'Rem_DeactivatedBy
        '
        Me.Rem_DeactivatedBy.DataPropertyName = "Rem_DeactivatedBy"
        Me.Rem_DeactivatedBy.HeaderText = "Deactivated By"
        Me.Rem_DeactivatedBy.Name = "Rem_DeactivatedBy"
        Me.Rem_DeactivatedBy.ReadOnly = True
        '
        'Rem_DeactivatedAt
        '
        Me.Rem_DeactivatedAt.DataPropertyName = "Rem_DeactivatedAt"
        Me.Rem_DeactivatedAt.HeaderText = "Deactivated At"
        Me.Rem_DeactivatedAt.Name = "Rem_DeactivatedAt"
        Me.Rem_DeactivatedAt.ReadOnly = True
        '
        'FrmPrMsReminder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 688)
        Me.Controls.Add(Me.txtCreatedAt)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.txtDeactivatedAt)
        Me.Controls.Add(Me.txtDeactivatedBy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CBIsActive)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Notes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.DateReq)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblEffPayDate)
        Me.Controls.Add(Me.lblCola)
        Me.Controls.Add(Me.lblEffArrearsDate)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmPrMsReminder"
        Me.Text = "Reminder"
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents DateReq As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblEffPayDate As System.Windows.Forms.Label
    Friend WithEvents lblCola As System.Windows.Forms.Label
    Friend WithEvents lblEffArrearsDate As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Notes As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents CBIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDeactivatedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtDeactivatedAt As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedAt As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents Rem_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_Reminderdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_CreatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_DeactivatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_DeactivatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
