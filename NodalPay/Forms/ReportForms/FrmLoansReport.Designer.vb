<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoansReport
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Emp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Emp_FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoanDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoanDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoanAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remaining = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.AllowUserToOrderColumns = True
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Emp_Code, Me.Emp_FullName, Me.IdCard, Me.LoanDesc, Me.LoanDate, Me.LoanAmount, Me.Payment, Me.Remaining})
        Me.DG1.Location = New System.Drawing.Point(1, 30)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1170, 566)
        Me.DG1.TabIndex = 0
        '
        'Emp_Code
        '
        Me.Emp_Code.DataPropertyName = "Emp_code"
        Me.Emp_Code.HeaderText = "Emp.Code"
        Me.Emp_Code.Name = "Emp_Code"
        '
        'Emp_FullName
        '
        Me.Emp_FullName.DataPropertyName = "Emp_FullName"
        Me.Emp_FullName.HeaderText = "Employee Name"
        Me.Emp_FullName.Name = "Emp_FullName"
        Me.Emp_FullName.Width = 250
        '
        'IdCard
        '
        Me.IdCard.DataPropertyName = "Emp_IdentificationCard"
        Me.IdCard.HeaderText = "Employee ID"
        Me.IdCard.Name = "IdCard"
        '
        'LoanDesc
        '
        Me.LoanDesc.DataPropertyName = "EmpLne_Description"
        Me.LoanDesc.HeaderText = "Loan Description"
        Me.LoanDesc.Name = "LoanDesc"
        Me.LoanDesc.Width = 200
        '
        'LoanDate
        '
        Me.LoanDate.DataPropertyName = "EmpLne_LoanDate"
        Me.LoanDate.HeaderText = "Loan Date"
        Me.LoanDate.Name = "LoanDate"
        '
        'LoanAmount
        '
        Me.LoanAmount.DataPropertyName = "OpeningAmount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LoanAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.LoanAmount.HeaderText = "Loan Amount"
        Me.LoanAmount.Name = "LoanAmount"
        Me.LoanAmount.Width = 115
        '
        'Payment
        '
        Me.Payment.DataPropertyName = "TotalPayments"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Payment.DefaultCellStyle = DataGridViewCellStyle8
        Me.Payment.HeaderText = "Total Payments"
        Me.Payment.Name = "Payment"
        Me.Payment.Width = 115
        '
        'Remaining
        '
        Me.Remaining.DataPropertyName = "Balance"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Remaining.DefaultCellStyle = DataGridViewCellStyle9
        Me.Remaining.HeaderText = "Remaining Amount"
        Me.Remaining.Name = "Remaining"
        Me.Remaining.Width = 115
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(1, 1)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(84, 23)
        Me.btnExcel.TabIndex = 71
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 23)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmLoansReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 599)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmLoansReport"
        Me.Text = "Loans Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Emp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emp_FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoanDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoanDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoanAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remaining As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
