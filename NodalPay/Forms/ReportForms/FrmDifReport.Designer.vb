<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDifReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PeriodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PeriodUnits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalErn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCont = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Net = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IncomeTax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EXCEL = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Company, Me.PeriodCode, Me.EmpCode, Me.EmpName, Me.PeriodUnits, Me.TotalErn, Me.TotalDed, Me.TotalCont, Me.Net, Me.IncomeTax, Me.SI})
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(1, 34)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(964, 510)
        Me.DG1.TabIndex = 0
        '
        'Company
        '
        Me.Company.DataPropertyName = "Company"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        '
        'PeriodCode
        '
        Me.PeriodCode.DataPropertyName = "PeriodCode"
        Me.PeriodCode.HeaderText = "Period Code"
        Me.PeriodCode.Name = "PeriodCode"
        '
        'EmpCode
        '
        Me.EmpCode.DataPropertyName = "EmpCode"
        Me.EmpCode.HeaderText = "Emp Code"
        Me.EmpCode.Name = "EmpCode"
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Emp. Name"
        Me.EmpName.Name = "EmpName"
        '
        'PeriodUnits
        '
        Me.PeriodUnits.DataPropertyName = "ActualUnits"
        DataGridViewCellStyle1.Format = "0.00"
        Me.PeriodUnits.DefaultCellStyle = DataGridViewCellStyle1
        Me.PeriodUnits.HeaderText = "Period Units"
        Me.PeriodUnits.Name = "PeriodUnits"
        '
        'TotalErn
        '
        Me.TotalErn.DataPropertyName = "TotalEarnings"
        DataGridViewCellStyle2.Format = "0.00"
        Me.TotalErn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalErn.HeaderText = "Total Earnings"
        Me.TotalErn.Name = "TotalErn"
        '
        'TotalDed
        '
        Me.TotalDed.DataPropertyName = "TotalDeductions"
        DataGridViewCellStyle3.Format = "0.00"
        Me.TotalDed.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalDed.HeaderText = "Total Deductions"
        Me.TotalDed.Name = "TotalDed"
        '
        'TotalCont
        '
        Me.TotalCont.DataPropertyName = "TotalContributions"
        DataGridViewCellStyle4.Format = "0.00"
        Me.TotalCont.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalCont.HeaderText = "Total Contributions"
        Me.TotalCont.Name = "TotalCont"
        '
        'Net
        '
        Me.Net.DataPropertyName = "Net"
        DataGridViewCellStyle5.Format = "0.00"
        Me.Net.DefaultCellStyle = DataGridViewCellStyle5
        Me.Net.HeaderText = "Net Salary"
        Me.Net.Name = "Net"
        '
        'IncomeTax
        '
        Me.IncomeTax.DataPropertyName = "TaxDeduction"
        DataGridViewCellStyle6.Format = "0.00"
        Me.IncomeTax.DefaultCellStyle = DataGridViewCellStyle6
        Me.IncomeTax.HeaderText = "Income Tax Deduction"
        Me.IncomeTax.Name = "IncomeTax"
        '
        'SI
        '
        Me.SI.DataPropertyName = "SIDeduction"
        DataGridViewCellStyle7.Format = "0.00"
        Me.SI.DefaultCellStyle = DataGridViewCellStyle7
        Me.SI.HeaderText = "S.I. Deduction"
        Me.SI.Name = "SI"
        '
        'EXCEL
        '
        Me.EXCEL.Location = New System.Drawing.Point(12, 5)
        Me.EXCEL.Name = "EXCEL"
        Me.EXCEL.Size = New System.Drawing.Size(75, 23)
        Me.EXCEL.TabIndex = 1
        Me.EXCEL.Text = "Excel"
        Me.EXCEL.UseVisualStyleBackColor = True
        '
        'FrmDifReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 549)
        Me.Controls.Add(Me.EXCEL)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmDifReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Split Employement Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalErn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Net As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IncomeTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXCEL As System.Windows.Forms.Button
End Class
