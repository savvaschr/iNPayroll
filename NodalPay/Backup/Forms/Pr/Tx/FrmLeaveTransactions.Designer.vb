<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeaveTransactions
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
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.txtCurrentPeriod = New System.Windows.Forms.TextBox
        Me.LblCurrentPeriod = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeaveUnits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateFrom = New System.Windows.Forms.DateTimePicker
        Me.DateTo = New System.Windows.Forms.DateTimePicker
        Me.ComboType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUnits = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboAction = New System.Windows.Forms.ComboBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurrentPeriod
        '
        Me.txtCurrentPeriod.Location = New System.Drawing.Point(92, 43)
        Me.txtCurrentPeriod.Name = "txtCurrentPeriod"
        Me.txtCurrentPeriod.ReadOnly = True
        Me.txtCurrentPeriod.Size = New System.Drawing.Size(206, 20)
        Me.txtCurrentPeriod.TabIndex = 74
        '
        'LblCurrentPeriod
        '
        Me.LblCurrentPeriod.AutoSize = True
        Me.LblCurrentPeriod.Location = New System.Drawing.Point(12, 46)
        Me.LblCurrentPeriod.Name = "LblCurrentPeriod"
        Me.LblCurrentPeriod.Size = New System.Drawing.Size(74, 13)
        Me.LblCurrentPeriod.TabIndex = 73
        Me.LblCurrentPeriod.Text = "Current Period"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(851, 25)
        Me.ToolStrip1.TabIndex = 72
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpCode, Me.EmpName, Me.LeaveUnits})
        Me.DG1.Location = New System.Drawing.Point(12, 234)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(816, 481)
        Me.DG1.TabIndex = 71
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "Employee Code"
        Me.EmpCode.Name = "EmpCode"
        Me.EmpCode.ReadOnly = True
        Me.EmpCode.Width = 200
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 400
        '
        'LeaveUnits
        '
        Me.LeaveUnits.DataPropertyName = "LeaveUnits"
        Me.LeaveUnits.HeaderText = "Units"
        Me.LeaveUnits.Name = "LeaveUnits"
        '
        'DateFrom
        '
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFrom.Location = New System.Drawing.Point(92, 69)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(200, 20)
        Me.DateFrom.TabIndex = 75
        '
        'DateTo
        '
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTo.Location = New System.Drawing.Point(92, 95)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(200, 20)
        Me.DateTo.TabIndex = 76
        '
        'ComboType
        '
        Me.ComboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboType.FormattingEnabled = True
        Me.ComboType.Location = New System.Drawing.Point(92, 121)
        Me.ComboType.Name = "ComboType"
        Me.ComboType.Size = New System.Drawing.Size(200, 21)
        Me.ComboType.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "From Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "To Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Leave Type"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(92, 182)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(200, 20)
        Me.txtUnits.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Leave Units"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 182)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "Set to All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(533, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 41)
        Me.Button2.TabIndex = 84
        Me.Button2.Text = "Upload Annual Leave ENTITLEMENT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(533, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(150, 41)
        Me.Button3.TabIndex = 85
        Me.Button3.Text = "Upload Sick Leave ENTITLEMENT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Action"
        '
        'ComboAction
        '
        Me.ComboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAction.FormattingEnabled = True
        Me.ComboAction.Location = New System.Drawing.Point(92, 149)
        Me.ComboAction.Name = "ComboAction"
        Me.ComboAction.Size = New System.Drawing.Size(200, 21)
        Me.ComboAction.TabIndex = 86
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(689, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(150, 41)
        Me.Button4.TabIndex = 88
        Me.Button4.Text = "Upload Annual Leave BOOKED"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(689, 96)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(150, 41)
        Me.Button5.TabIndex = 89
        Me.Button5.Text = "Upload Sick Leave BOOKED"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'FrmLeaveTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 741)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboAction)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboType)
        Me.Controls.Add(Me.DateTo)
        Me.Controls.Add(Me.DateFrom)
        Me.Controls.Add(Me.txtCurrentPeriod)
        Me.Controls.Add(Me.LblCurrentPeriod)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmLeaveTransactions"
        Me.Text = "Leave Transactions"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCurrentPeriod As System.Windows.Forms.TextBox
    Friend WithEvents LblCurrentPeriod As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeaveUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboAction As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
