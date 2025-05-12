<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExelsysAuditReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DG1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DateLastUpdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CBExcludeLastUpdateField = New System.Windows.Forms.CheckBox()
        Me.RadioExceptNew = New System.Windows.Forms.RadioButton()
        Me.RadioOnlyNew = New System.Windows.Forms.RadioButton()
        Me.RadioAll = New System.Windows.Forms.RadioButton()
        Me.lblCounter = New System.Windows.Forms.Label()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.Employee, Me.UpdateDate, Me.UpdatedBy, Me.FieldName, Me.OldValue, Me.NewValue})
        Me.DG1.Location = New System.Drawing.Point(1, 139)
        Me.DG1.Margin = New System.Windows.Forms.Padding(2)
        Me.DG1.Name = "DG1"
        Me.DG1.RowTemplate.Height = 24
        Me.DG1.Size = New System.Drawing.Size(1135, 366)
        Me.DG1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Table Name"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Employee", "Salary"})
        Me.ComboBox1.Location = New System.Drawing.Point(112, 32)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(151, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'DateLastUpdate
        '
        Me.DateLastUpdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateLastUpdate.Location = New System.Drawing.Point(112, 52)
        Me.DateLastUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.DateLastUpdate.Name = "DateLastUpdate"
        Me.DateLastUpdate.Size = New System.Drawing.Size(151, 20)
        Me.DateLastUpdate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "From Update Date"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 84)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 26)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CBExcludeLastUpdateField
        '
        Me.CBExcludeLastUpdateField.AutoSize = True
        Me.CBExcludeLastUpdateField.Checked = True
        Me.CBExcludeLastUpdateField.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBExcludeLastUpdateField.Location = New System.Drawing.Point(545, 36)
        Me.CBExcludeLastUpdateField.Name = "CBExcludeLastUpdateField"
        Me.CBExcludeLastUpdateField.Size = New System.Drawing.Size(173, 17)
        Me.CBExcludeLastUpdateField.TabIndex = 6
        Me.CBExcludeLastUpdateField.Text = "Exclude Last Update Date field"
        Me.CBExcludeLastUpdateField.UseVisualStyleBackColor = True
        '
        'RadioExceptNew
        '
        Me.RadioExceptNew.AutoSize = True
        Me.RadioExceptNew.Location = New System.Drawing.Point(336, 54)
        Me.RadioExceptNew.Name = "RadioExceptNew"
        Me.RadioExceptNew.Size = New System.Drawing.Size(137, 17)
        Me.RadioExceptNew.TabIndex = 7
        Me.RadioExceptNew.TabStop = True
        Me.RadioExceptNew.Text = "Except New Employees"
        Me.RadioExceptNew.UseVisualStyleBackColor = True
        '
        'RadioOnlyNew
        '
        Me.RadioOnlyNew.AutoSize = True
        Me.RadioOnlyNew.Location = New System.Drawing.Point(336, 74)
        Me.RadioOnlyNew.Name = "RadioOnlyNew"
        Me.RadioOnlyNew.Size = New System.Drawing.Size(125, 17)
        Me.RadioOnlyNew.TabIndex = 8
        Me.RadioOnlyNew.TabStop = True
        Me.RadioOnlyNew.Text = "Only New Employees"
        Me.RadioOnlyNew.UseVisualStyleBackColor = True
        '
        'RadioAll
        '
        Me.RadioAll.AutoSize = True
        Me.RadioAll.Location = New System.Drawing.Point(336, 33)
        Me.RadioAll.Name = "RadioAll"
        Me.RadioAll.Size = New System.Drawing.Size(90, 17)
        Me.RadioAll.TabIndex = 9
        Me.RadioAll.TabStop = True
        Me.RadioAll.Text = "All Employees"
        Me.RadioAll.UseVisualStyleBackColor = True
        '
        'lblCounter
        '
        Me.lblCounter.AutoSize = True
        Me.lblCounter.Location = New System.Drawing.Point(0, 124)
        Me.lblCounter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(20, 13)
        Me.lblCounter.TabIndex = 10
        Me.lblCounter.Text = "#0"
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.Width = 70
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "Employee"
        Me.Employee.HeaderText = "Employee"
        Me.Employee.Name = "Employee"
        Me.Employee.Width = 200
        '
        'UpdateDate
        '
        Me.UpdateDate.DataPropertyName = "UpdateDate"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy hh:mm:ss"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.UpdateDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.UpdateDate.HeaderText = "UpdateDate"
        Me.UpdateDate.Name = "UpdateDate"
        '
        'UpdatedBy
        '
        Me.UpdatedBy.DataPropertyName = "UpdatedBy"
        Me.UpdatedBy.HeaderText = "UpdatedBy"
        Me.UpdatedBy.Name = "UpdatedBy"
        '
        'FieldName
        '
        Me.FieldName.DataPropertyName = "FieldName"
        Me.FieldName.HeaderText = "FieldName"
        Me.FieldName.Name = "FieldName"
        Me.FieldName.Width = 200
        '
        'OldValue
        '
        Me.OldValue.DataPropertyName = "OldValue"
        Me.OldValue.HeaderText = "OldValue"
        Me.OldValue.Name = "OldValue"
        Me.OldValue.Width = 200
        '
        'NewValue
        '
        Me.NewValue.DataPropertyName = "NewValue"
        Me.NewValue.HeaderText = "NewValue"
        Me.NewValue.Name = "NewValue"
        Me.NewValue.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1138, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBExcel
        '
        Me.TSBExcel.Image = Global.NodalPay.My.Resources.Resources.excel
        Me.TSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(54, 22)
        Me.TSBExcel.Text = "Excel"
        '
        'FrmExelsysAuditReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1138, 508)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblCounter)
        Me.Controls.Add(Me.RadioAll)
        Me.Controls.Add(Me.RadioOnlyNew)
        Me.Controls.Add(Me.RadioExceptNew)
        Me.Controls.Add(Me.CBExcludeLastUpdateField)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateLastUpdate)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DG1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmExelsysAuditReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exelsys Audit Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DG1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateLastUpdate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CBExcludeLastUpdateField As CheckBox
    Friend WithEvents RadioExceptNew As RadioButton
    Friend WithEvents RadioOnlyNew As RadioButton
    Friend WithEvents RadioAll As RadioButton
    Friend WithEvents lblCounter As Label
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents Employee As DataGridViewTextBoxColumn
    Friend WithEvents UpdateDate As DataGridViewTextBoxColumn
    Friend WithEvents UpdatedBy As DataGridViewTextBoxColumn
    Friend WithEvents FieldName As DataGridViewTextBoxColumn
    Friend WithEvents OldValue As DataGridViewTextBoxColumn
    Friend WithEvents NewValue As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TSBExcel As ToolStripButton
End Class
