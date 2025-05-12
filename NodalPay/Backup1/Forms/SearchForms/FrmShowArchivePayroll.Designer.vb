<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowArchivePayroll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShowArchivePayroll))
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.TrxHdr_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PeriodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PeriodDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrxnDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InterStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Print = New System.Windows.Forms.ToolStripButton
        Me.Export = New System.Windows.Forms.ToolStripButton
        Me.BtnEmail = New System.Windows.Forms.ToolStripDropDownButton
        Me.Email1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Gmail = New System.Windows.Forms.ToolStripMenuItem
        Me.Email365 = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailSMTP = New System.Windows.Forms.ToolStripMenuItem
        Me.CBUseEmail2 = New System.Windows.Forms.CheckBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrxHdr_Id, Me.Year, Me.PeriodCode, Me.PeriodDesc, Me.TrxnDate, Me.Status, Me.InterStatus, Me.Selected})
        Me.DG1.Location = New System.Drawing.Point(12, 37)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(767, 595)
        Me.DG1.TabIndex = 0
        '
        'TrxHdr_Id
        '
        Me.TrxHdr_Id.DataPropertyName = "TrxHdr_Id"
        Me.TrxHdr_Id.HeaderText = "HdrId"
        Me.TrxHdr_Id.Name = "TrxHdr_Id"
        Me.TrxHdr_Id.ReadOnly = True
        Me.TrxHdr_Id.Visible = False
        '
        'Year
        '
        Me.Year.DataPropertyName = "PrdGpr_Year"
        Me.Year.HeaderText = "Year"
        Me.Year.Name = "Year"
        Me.Year.ReadOnly = True
        '
        'PeriodCode
        '
        Me.PeriodCode.DataPropertyName = "PrdCod_Code"
        Me.PeriodCode.HeaderText = "Code"
        Me.PeriodCode.Name = "PeriodCode"
        Me.PeriodCode.ReadOnly = True
        '
        'PeriodDesc
        '
        Me.PeriodDesc.DataPropertyName = "PrdCod_DescriptionL"
        Me.PeriodDesc.HeaderText = "Period"
        Me.PeriodDesc.Name = "PeriodDesc"
        Me.PeriodDesc.ReadOnly = True
        '
        'TrxnDate
        '
        Me.TrxnDate.DataPropertyName = "TrxHdr_Date"
        Me.TrxnDate.HeaderText = "Trxn Date"
        Me.TrxnDate.Name = "TrxnDate"
        Me.TrxnDate.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "TrxHdr_Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'InterStatus
        '
        Me.InterStatus.DataPropertyName = "TrxHdr_InterfaceStatus"
        Me.InterStatus.HeaderText = "Interface"
        Me.InterStatus.Name = "InterStatus"
        Me.InterStatus.ReadOnly = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.HeaderText = "Selected"
        Me.Selected.Name = "Selected"
        Me.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Print, Me.Export, Me.BtnEmail})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(808, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Print
        '
        Me.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Print.Image = CType(resources.GetObject("Print.Image"), System.Drawing.Image)
        Me.Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(36, 22)
        Me.Print.Text = "Print"
        '
        'Export
        '
        Me.Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Export.Image = CType(resources.GetObject("Export.Image"), System.Drawing.Image)
        Me.Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(44, 22)
        Me.Export.Text = "Export"
        '
        'BtnEmail
        '
        Me.BtnEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnEmail.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Email1, Me.Gmail, Me.Email365, Me.EmailSMTP})
        Me.BtnEmail.Image = CType(resources.GetObject("BtnEmail.Image"), System.Drawing.Image)
        Me.BtnEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(49, 22)
        Me.BtnEmail.Text = "Email"
        '
        'Email1
        '
        Me.Email1.Name = "Email1"
        Me.Email1.Size = New System.Drawing.Size(191, 22)
        Me.Email1.Text = "Email to Employee"
        '
        'Gmail
        '
        Me.Gmail.Name = "Gmail"
        Me.Gmail.Size = New System.Drawing.Size(191, 22)
        Me.Gmail.Text = "Gmail to Employee"
        '
        'Email365
        '
        Me.Email365.Name = "Email365"
        Me.Email365.Size = New System.Drawing.Size(191, 22)
        Me.Email365.Text = "Email using Office 365"
        '
        'EmailSMTP
        '
        Me.EmailSMTP.Name = "EmailSMTP"
        Me.EmailSMTP.Size = New System.Drawing.Size(191, 22)
        Me.EmailSMTP.Text = "Email using SMTP"
        '
        'CBUseEmail2
        '
        Me.CBUseEmail2.AutoSize = True
        Me.CBUseEmail2.Location = New System.Drawing.Point(193, 5)
        Me.CBUseEmail2.Name = "CBUseEmail2"
        Me.CBUseEmail2.Size = New System.Drawing.Size(131, 17)
        Me.CBUseEmail2.TabIndex = 4
        Me.CBUseEmail2.Text = "Use Employee Email 2"
        Me.CBUseEmail2.UseVisualStyleBackColor = True
        '
        'FrmShowArchivePayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 644)
        Me.Controls.Add(Me.CBUseEmail2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmShowArchivePayroll"
        Me.Text = "Archive Payroll Transactions"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TrxHdr_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Year As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEmail As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Email1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Gmail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Email365 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailSMTP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBUseEmail2 As System.Windows.Forms.CheckBox
End Class
