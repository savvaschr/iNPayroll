<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonthlyHourlyReport
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
        Me.btnExcel = New System.Windows.Forms.Button
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Emp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoanDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DG2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnalysisDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DG2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(12, 12)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(74, 26)
        Me.btnExcel.TabIndex = 75
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.AllowUserToOrderColumns = True
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Emp_Code, Me.Emp_FullName, Me.IdCard, Me.LoanDesc})
        Me.DG1.Location = New System.Drawing.Point(12, 44)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(989, 100)
        Me.DG1.TabIndex = 74
        '
        'Emp_Code
        '
        Me.Emp_Code.DataPropertyName = "Period"
        Me.Emp_Code.HeaderText = "Period"
        Me.Emp_Code.Name = "Emp_Code"
        Me.Emp_Code.Width = 300
        '
        'Emp_FullName
        '
        Me.Emp_FullName.DataPropertyName = "Monthly"
        Me.Emp_FullName.HeaderText = "Monthly"
        Me.Emp_FullName.Name = "Emp_FullName"
        '
        'IdCard
        '
        Me.IdCard.DataPropertyName = "Hourly"
        Me.IdCard.HeaderText = "Hourly"
        Me.IdCard.Name = "IdCard"
        '
        'LoanDesc
        '
        Me.LoanDesc.DataPropertyName = "Total"
        Me.LoanDesc.HeaderText = "Total"
        Me.LoanDesc.Name = "LoanDesc"
        '
        'DG2
        '
        Me.DG2.AllowUserToAddRows = False
        Me.DG2.AllowUserToDeleteRows = False
        Me.DG2.AllowUserToOrderColumns = True
        Me.DG2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.AnalysisDesc})
        Me.DG2.Location = New System.Drawing.Point(12, 175)
        Me.DG2.Name = "DG2"
        Me.DG2.Size = New System.Drawing.Size(989, 527)
        Me.DG2.TabIndex = 76
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Period"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Period"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Total"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "AnalysisCode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Analisys Code"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'AnalysisDesc
        '
        Me.AnalysisDesc.DataPropertyName = "AnalysisDesc"
        Me.AnalysisDesc.HeaderText = "Analysis Description"
        Me.AnalysisDesc.Name = "AnalysisDesc"
        '
        'FrmMonthlyHourlyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 714)
        Me.Controls.Add(Me.DG2)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmMonthlyHourlyReport"
        Me.Text = "Period Monthly Hourly Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DG2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Emp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoanDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DG2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnalysisDesc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
