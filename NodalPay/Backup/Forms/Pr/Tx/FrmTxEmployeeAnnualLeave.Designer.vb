<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTxEmployeeAnnualLeave
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
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Limit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Carry = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EOY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.LblCurrentPeriod = New System.Windows.Forms.Label
        Me.txtCurrentPeriod = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtYearTocurryOver = New System.Windows.Forms.TextBox
        Me.btnTransferUnlimited = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtLimit = New System.Windows.Forms.TextBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpCode, Me.EmpName, Me.Balance, Me.Limit, Me.Carry, Me.EOY})
        Me.DG1.Location = New System.Drawing.Point(12, 96)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1009, 540)
        Me.DG1.TabIndex = 0
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "Employee Code"
        Me.EmpCode.Name = "EmpCode"
        Me.EmpCode.ReadOnly = True
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 250
        '
        'Balance
        '
        Me.Balance.DataPropertyName = "Balance"
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        '
        'Limit
        '
        Me.Limit.DataPropertyName = "Limit"
        Me.Limit.HeaderText = "Limit"
        Me.Limit.Name = "Limit"
        Me.Limit.ReadOnly = True
        '
        'Carry
        '
        Me.Carry.DataPropertyName = "Carry"
        Me.Carry.HeaderText = "Carry Forward"
        Me.Carry.Name = "Carry"
        '
        'EOY
        '
        Me.EOY.DataPropertyName = "EOY"
        Me.EOY.HeaderText = "EOY"
        Me.EOY.Name = "EOY"
        Me.EOY.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1033, 25)
        Me.ToolStrip1.TabIndex = 66
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'LblCurrentPeriod
        '
        Me.LblCurrentPeriod.AutoSize = True
        Me.LblCurrentPeriod.Location = New System.Drawing.Point(12, 39)
        Me.LblCurrentPeriod.Name = "LblCurrentPeriod"
        Me.LblCurrentPeriod.Size = New System.Drawing.Size(74, 13)
        Me.LblCurrentPeriod.TabIndex = 67
        Me.LblCurrentPeriod.Text = "Current Period"
        '
        'txtCurrentPeriod
        '
        Me.txtCurrentPeriod.Location = New System.Drawing.Point(92, 36)
        Me.txtCurrentPeriod.Name = "txtCurrentPeriod"
        Me.txtCurrentPeriod.ReadOnly = True
        Me.txtCurrentPeriod.Size = New System.Drawing.Size(206, 20)
        Me.txtCurrentPeriod.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(325, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Year to Carry Over"
        '
        'txtYearTocurryOver
        '
        Me.txtYearTocurryOver.Location = New System.Drawing.Point(435, 36)
        Me.txtYearTocurryOver.Name = "txtYearTocurryOver"
        Me.txtYearTocurryOver.ReadOnly = True
        Me.txtYearTocurryOver.Size = New System.Drawing.Size(206, 20)
        Me.txtYearTocurryOver.TabIndex = 70
        '
        'btnTransferUnlimited
        '
        Me.btnTransferUnlimited.Location = New System.Drawing.Point(647, 34)
        Me.btnTransferUnlimited.Name = "btnTransferUnlimited"
        Me.btnTransferUnlimited.Size = New System.Drawing.Size(257, 23)
        Me.btnTransferUnlimited.TabIndex = 71
        Me.btnTransferUnlimited.Text = "Transfer Balance to Carry Forward"
        Me.btnTransferUnlimited.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(647, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(257, 23)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "Transfer Balance to Carry Forward with Limit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtLimit
        '
        Me.txtLimit.Location = New System.Drawing.Point(921, 65)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.Size = New System.Drawing.Size(100, 20)
        Me.txtLimit.TabIndex = 73
        Me.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmTxEmployeeAnnualLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 648)
        Me.Controls.Add(Me.txtLimit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnTransferUnlimited)
        Me.Controls.Add(Me.txtYearTocurryOver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCurrentPeriod)
        Me.Controls.Add(Me.LblCurrentPeriod)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmTxEmployeeAnnualLeave"
        Me.Text = "Employee Annual Leave Carry Forward Transaction"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Limit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EOY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblCurrentPeriod As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtYearTocurryOver As System.Windows.Forms.TextBox
    Friend WithEvents btnTransferUnlimited As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtLimit As System.Windows.Forms.TextBox
End Class
