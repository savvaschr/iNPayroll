<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsPeriodEDC
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
        Me.DG_E = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DG_D = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DedCod_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DedCod_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DG_C = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConCod_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConCod_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.LblPeriod = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnE = New System.Windows.Forms.Button
        Me.BtnD = New System.Windows.Forms.Button
        Me.BtnC = New System.Windows.Forms.Button
        CType(Me.DG_E, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DG_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DG_C, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG_E
        '
        Me.DG_E.AllowUserToAddRows = False
        Me.DG_E.AllowUserToDeleteRows = False
        Me.DG_E.AllowUserToOrderColumns = True
        Me.DG_E.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG_E.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_E.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column5})
        Me.DG_E.Location = New System.Drawing.Point(2, 52)
        Me.DG_E.Name = "DG_E"
        Me.DG_E.Size = New System.Drawing.Size(319, 369)
        Me.DG_E.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Id"
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ErnCod_Code"
        Me.Column3.HeaderText = "Code"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "ErnCod_DescriptionL"
        Me.Column4.HeaderText = "Description"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 120
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "IsActive"
        Me.Column5.FalseValue = "0"
        Me.Column5.HeaderText = "Active"
        Me.Column5.Name = "Column5"
        Me.Column5.TrueValue = "1"
        Me.Column5.Width = 50
        '
        'DG_D
        '
        Me.DG_D.AllowUserToAddRows = False
        Me.DG_D.AllowUserToDeleteRows = False
        Me.DG_D.AllowUserToOrderColumns = True
        Me.DG_D.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.DedCod_Code, Me.DedCod_DescriptionL, Me.IsActive})
        Me.DG_D.Location = New System.Drawing.Point(327, 52)
        Me.DG_D.Name = "DG_D"
        Me.DG_D.Size = New System.Drawing.Size(319, 369)
        Me.DG_D.TabIndex = 1
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'DedCod_Code
        '
        Me.DedCod_Code.DataPropertyName = "DedCod_Code"
        Me.DedCod_Code.HeaderText = "Code"
        Me.DedCod_Code.Name = "DedCod_Code"
        Me.DedCod_Code.ReadOnly = True
        Me.DedCod_Code.Width = 70
        '
        'DedCod_DescriptionL
        '
        Me.DedCod_DescriptionL.DataPropertyName = "DedCod_DescriptionL"
        Me.DedCod_DescriptionL.HeaderText = "Description"
        Me.DedCod_DescriptionL.Name = "DedCod_DescriptionL"
        Me.DedCod_DescriptionL.ReadOnly = True
        Me.DedCod_DescriptionL.Width = 120
        '
        'IsActive
        '
        Me.IsActive.DataPropertyName = "isActive"
        Me.IsActive.FalseValue = "0"
        Me.IsActive.HeaderText = "Active"
        Me.IsActive.Name = "IsActive"
        Me.IsActive.TrueValue = "1"
        Me.IsActive.Width = 50
        '
        'DG_C
        '
        Me.DG_C.AllowUserToAddRows = False
        Me.DG_C.AllowUserToDeleteRows = False
        Me.DG_C.AllowUserToOrderColumns = True
        Me.DG_C.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG_C.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_C.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.ConCod_Code, Me.ConCod_DescriptionL, Me.DataGridViewCheckBoxColumn1})
        Me.DG_C.Location = New System.Drawing.Point(652, 52)
        Me.DG_C.Name = "DG_C"
        Me.DG_C.Size = New System.Drawing.Size(319, 369)
        Me.DG_C.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'ConCod_Code
        '
        Me.ConCod_Code.DataPropertyName = "ConCod_Code"
        Me.ConCod_Code.HeaderText = "Code"
        Me.ConCod_Code.Name = "ConCod_Code"
        Me.ConCod_Code.ReadOnly = True
        Me.ConCod_Code.Width = 70
        '
        'ConCod_DescriptionL
        '
        Me.ConCod_DescriptionL.DataPropertyName = "ConCod_DescriptionL"
        Me.ConCod_DescriptionL.HeaderText = "Description"
        Me.ConCod_DescriptionL.Name = "ConCod_DescriptionL"
        Me.ConCod_DescriptionL.ReadOnly = True
        Me.ConCod_DescriptionL.Width = 120
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsActive"
        Me.DataGridViewCheckBoxColumn1.FalseValue = "0"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Active"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.TrueValue = "1"
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'LblPeriod
        '
        Me.LblPeriod.AutoSize = True
        Me.LblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblPeriod.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblPeriod.Location = New System.Drawing.Point(12, 9)
        Me.LblPeriod.Name = "LblPeriod"
        Me.LblPeriod.Size = New System.Drawing.Size(58, 16)
        Me.LblPeriod.TabIndex = 3
        Me.LblPeriod.Text = "Period:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Earnings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(334, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Deductions"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(660, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contributions"
        '
        'btnE
        '
        Me.btnE.Location = New System.Drawing.Point(232, 23)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(53, 23)
        Me.btnE.TabIndex = 7
        Me.btnE.Text = "Apply"
        Me.btnE.UseVisualStyleBackColor = True
        '
        'BtnD
        '
        Me.BtnD.Location = New System.Drawing.Point(558, 23)
        Me.BtnD.Name = "BtnD"
        Me.BtnD.Size = New System.Drawing.Size(53, 23)
        Me.BtnD.TabIndex = 8
        Me.BtnD.Text = "Apply"
        Me.BtnD.UseVisualStyleBackColor = True
        '
        'BtnC
        '
        Me.BtnC.Location = New System.Drawing.Point(884, 23)
        Me.BtnC.Name = "BtnC"
        Me.BtnC.Size = New System.Drawing.Size(53, 23)
        Me.BtnC.TabIndex = 9
        Me.BtnC.Text = "Apply"
        Me.BtnC.UseVisualStyleBackColor = True
        '
        'FrmPrMsPeriodEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(974, 433)
        Me.Controls.Add(Me.BtnC)
        Me.Controls.Add(Me.BtnD)
        Me.Controls.Add(Me.btnE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblPeriod)
        Me.Controls.Add(Me.DG_C)
        Me.Controls.Add(Me.DG_D)
        Me.Controls.Add(Me.DG_E)
        Me.Name = "FrmPrMsPeriodEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Period EDC"
        CType(Me.DG_E, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DG_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DG_C, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG_E As System.Windows.Forms.DataGridView
    Friend WithEvents DG_D As System.Windows.Forms.DataGridView
    Friend WithEvents DG_C As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DedCod_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DedCod_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConCod_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConCod_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LblPeriod As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnE As System.Windows.Forms.Button
    Friend WithEvents BtnD As System.Windows.Forms.Button
    Friend WithEvents BtnC As System.Windows.Forms.Button
End Class
