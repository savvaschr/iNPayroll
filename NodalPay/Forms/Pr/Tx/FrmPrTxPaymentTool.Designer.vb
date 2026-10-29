<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxPaymentTool
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
        Me.TSBSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DG1 = New System.Windows.Forms.DataGridView()
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeaveUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(859, 25)
        Me.ToolStrip1.TabIndex = 91
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpCode, Me.EmpName, Me.LeaveUnits})
        Me.DG1.Location = New System.Drawing.Point(0, 43)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(859, 551)
        Me.DG1.TabIndex = 90
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
        Me.LeaveUnits.DataPropertyName = "Amount"
        Me.LeaveUnits.HeaderText = "Amount"
        Me.LeaveUnits.Name = "LeaveUnits"
        '
        'FrmPrTxPaymentTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(859, 606)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmPrTxPaymentTool"
        Me.Text = "Employees Payment Tool"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TSBSave As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents DG1 As DataGridView
    Friend WithEvents EmpCode As DataGridViewTextBoxColumn
    Friend WithEvents EmpName As DataGridViewTextBoxColumn
    Friend WithEvents LeaveUnits As DataGridViewTextBoxColumn
End Class
