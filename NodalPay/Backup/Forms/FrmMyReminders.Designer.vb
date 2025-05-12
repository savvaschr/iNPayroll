<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMyReminders
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
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.cbIsActive = New System.Windows.Forms.CheckBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnShowReminder = New System.Windows.Forms.Button
        Me.btnDeactivate = New System.Windows.Forms.Button
        Me.Rem_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_ReminderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_CreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_DeactivatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rem_DeactivatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rem_id, Me.Emp_Code, Me.Rem_Description, Me.Rem_ReminderDate, Me.Rem_IsActive, Me.Rem_CreatedBy, Me.Rem_CreatedAt, Me.Rem_DeactivatedBy, Me.Rem_DeactivatedAt})
        Me.DG1.Location = New System.Drawing.Point(15, 119)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1094, 520)
        Me.DG1.TabIndex = 0
        '
        'FromDate
        '
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(81, 20)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(114, 20)
        Me.FromDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Date"
        '
        'ToDate
        '
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(81, 49)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(114, 20)
        Me.ToDate.TabIndex = 4
        '
        'cbIsActive
        '
        Me.cbIsActive.AutoSize = True
        Me.cbIsActive.Location = New System.Drawing.Point(81, 78)
        Me.cbIsActive.Name = "cbIsActive"
        Me.cbIsActive.Size = New System.Drawing.Size(80, 17)
        Me.cbIsActive.TabIndex = 5
        Me.cbIsActive.Text = "Only Active"
        Me.cbIsActive.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(213, 20)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(114, 23)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnShowReminder
        '
        Me.btnShowReminder.Location = New System.Drawing.Point(213, 48)
        Me.btnShowReminder.Name = "btnShowReminder"
        Me.btnShowReminder.Size = New System.Drawing.Size(114, 23)
        Me.btnShowReminder.TabIndex = 7
        Me.btnShowReminder.Text = "Show Reminder"
        Me.btnShowReminder.UseVisualStyleBackColor = True
        '
        'btnDeactivate
        '
        Me.btnDeactivate.Location = New System.Drawing.Point(213, 77)
        Me.btnDeactivate.Name = "btnDeactivate"
        Me.btnDeactivate.Size = New System.Drawing.Size(114, 23)
        Me.btnDeactivate.TabIndex = 8
        Me.btnDeactivate.Text = "De-Activate Reminder"
        Me.btnDeactivate.UseVisualStyleBackColor = True
        '
        'Rem_id
        '
        Me.Rem_id.DataPropertyName = "Rem_id"
        Me.Rem_id.HeaderText = "Rem_Id"
        Me.Rem_id.Name = "Rem_id"
        Me.Rem_id.Width = 5
        '
        'Emp_Code
        '
        Me.Emp_Code.DataPropertyName = "Emp_Code"
        Me.Emp_Code.HeaderText = "Emp.Code"
        Me.Emp_Code.Name = "Emp_Code"
        Me.Emp_Code.Width = 150
        '
        'Rem_Description
        '
        Me.Rem_Description.DataPropertyName = "Rem_Description"
        Me.Rem_Description.HeaderText = "Description"
        Me.Rem_Description.Name = "Rem_Description"
        Me.Rem_Description.Width = 250
        '
        'Rem_ReminderDate
        '
        Me.Rem_ReminderDate.DataPropertyName = "Rem_ReminderDate"
        Me.Rem_ReminderDate.HeaderText = "Reminder Date"
        Me.Rem_ReminderDate.Name = "Rem_ReminderDate"
        Me.Rem_ReminderDate.Width = 150
        '
        'Rem_IsActive
        '
        Me.Rem_IsActive.DataPropertyName = "Rem_IsActive"
        Me.Rem_IsActive.HeaderText = "Is Active"
        Me.Rem_IsActive.Name = "Rem_IsActive"
        '
        'Rem_CreatedBy
        '
        Me.Rem_CreatedBy.DataPropertyName = "Rem_CreatedBy"
        Me.Rem_CreatedBy.HeaderText = "Created By"
        Me.Rem_CreatedBy.Name = "Rem_CreatedBy"
        '
        'Rem_CreatedAt
        '
        Me.Rem_CreatedAt.DataPropertyName = "Rem_CreatedAt"
        Me.Rem_CreatedAt.HeaderText = "Created At"
        Me.Rem_CreatedAt.Name = "Rem_CreatedAt"
        '
        'Rem_DeactivatedBy
        '
        Me.Rem_DeactivatedBy.DataPropertyName = "Rem_DeactivatedBy"
        Me.Rem_DeactivatedBy.HeaderText = "Deactivated By"
        Me.Rem_DeactivatedBy.Name = "Rem_DeactivatedBy"
        '
        'Rem_DeactivatedAt
        '
        Me.Rem_DeactivatedAt.DataPropertyName = "Rem_DeactivatedAt"
        Me.Rem_DeactivatedAt.HeaderText = "Deactivated At"
        Me.Rem_DeactivatedAt.Name = "Rem_DeactivatedAt"
        '
        'FrmMyReminders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 651)
        Me.Controls.Add(Me.btnDeactivate)
        Me.Controls.Add(Me.btnShowReminder)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.cbIsActive)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmMyReminders"
        Me.Text = "My Reminders"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnShowReminder As System.Windows.Forms.Button
    Friend WithEvents btnDeactivate As System.Windows.Forms.Button
    Friend WithEvents Rem_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_ReminderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_CreatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_DeactivatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rem_DeactivatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
