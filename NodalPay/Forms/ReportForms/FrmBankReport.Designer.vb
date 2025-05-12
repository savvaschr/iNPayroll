<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBankReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.txttotal1 = New System.Windows.Forms.ToolStripTextBox
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bank = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IBAN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeneficiaryName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwiftNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Bank, Me.Column4, Me.Column5, Me.IBAN, Me.EmpID, Me.BeneficiaryName, Me.SwiftNo})
        Me.DG1.Location = New System.Drawing.Point(-2, 28)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1239, 475)
        Me.DG1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBExcel, Me.ToolStripButton1, Me.txttotal1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1237, 25)
        Me.ToolStrip1.TabIndex = 66
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBExcel
        '
        Me.TSBExcel.AutoSize = False
        Me.TSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(60, 22)
        Me.TSBExcel.Text = "Excel"
        Me.TSBExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButton1.Text = "Print"
        '
        'txttotal1
        '
        Me.txttotal1.Name = "txttotal1"
        Me.txttotal1.Size = New System.Drawing.Size(100, 25)
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Emp_Code"
        Me.Column1.HeaderText = "Employee Code"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Emp_FullName"
        Me.Column2.HeaderText = "Employee Name"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "TrxHdr_NetSalary"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "0.00"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Net Salary"
        Me.Column3.Name = "Column3"
        '
        'Bank
        '
        Me.Bank.DataPropertyName = "Bnk_DescriptionL"
        Me.Bank.HeaderText = "Bank"
        Me.Bank.Name = "Bank"
        Me.Bank.Width = 150
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Bnk_Code"
        Me.Column4.HeaderText = "Bank Code"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Emp_BankAccount"
        Me.Column5.HeaderText = "Bank Account"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 130
        '
        'IBAN
        '
        Me.IBAN.DataPropertyName = "Emp_IBAN"
        Me.IBAN.HeaderText = "IBAN"
        Me.IBAN.Name = "IBAN"
        '
        'EmpID
        '
        Me.EmpID.DataPropertyName = "Emp_IdentificationCard"
        Me.EmpID.HeaderText = "Identification Card"
        Me.EmpID.Name = "EmpID"
        '
        'BeneficiaryName
        '
        Me.BeneficiaryName.DataPropertyName = "Emp_BankBenName"
        Me.BeneficiaryName.HeaderText = "Beneficiary Name"
        Me.BeneficiaryName.Name = "BeneficiaryName"
        Me.BeneficiaryName.Width = 250
        '
        'SwiftNo
        '
        Me.SwiftNo.DataPropertyName = "Bnk_SwiftCode"
        Me.SwiftNo.HeaderText = "Swift Code"
        Me.SwiftNo.Name = "SwiftNo"
        '
        'FrmBankReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(1237, 522)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmBankReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank File Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txttotal1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IBAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeneficiaryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwiftNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
