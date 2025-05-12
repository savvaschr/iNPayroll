<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTemplateSearch
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
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcTemGrp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPayTyp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayUnits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAnl1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAnl2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTemGrp_Code, Me.dgcPayTyp_Code, Me.dgcTemGrp_DescriptionL, Me.dgcTemGrp_DescriptionS, Me.dgcTemGrp_IsActive, Me.DayUnits, Me.GLAnl1, Me.GLAnl2, Me.Company})
        Me.DG1.Location = New System.Drawing.Point(1, 12)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(549, 586)
        Me.DG1.TabIndex = 11
        '
        'dgcTemGrp_Code
        '
        Me.dgcTemGrp_Code.DataPropertyName = "TemGrp_Code"
        Me.dgcTemGrp_Code.FillWeight = 150.0!
        Me.dgcTemGrp_Code.HeaderText = "Code"
        Me.dgcTemGrp_Code.Name = "dgcTemGrp_Code"
        Me.dgcTemGrp_Code.ReadOnly = True
        Me.dgcTemGrp_Code.Width = 60
        '
        'dgcPayTyp_Code
        '
        Me.dgcPayTyp_Code.DataPropertyName = "PayTyp_Code"
        Me.dgcPayTyp_Code.FillWeight = 150.0!
        Me.dgcPayTyp_Code.HeaderText = "Payroll Type Code"
        Me.dgcPayTyp_Code.Name = "dgcPayTyp_Code"
        Me.dgcPayTyp_Code.ReadOnly = True
        Me.dgcPayTyp_Code.Visible = False
        '
        'dgcTemGrp_DescriptionL
        '
        Me.dgcTemGrp_DescriptionL.DataPropertyName = "TemGrp_DescriptionL"
        Me.dgcTemGrp_DescriptionL.FillWeight = 150.0!
        Me.dgcTemGrp_DescriptionL.HeaderText = "Long Description"
        Me.dgcTemGrp_DescriptionL.Name = "dgcTemGrp_DescriptionL"
        Me.dgcTemGrp_DescriptionL.ReadOnly = True
        Me.dgcTemGrp_DescriptionL.Width = 250
        '
        'dgcTemGrp_DescriptionS
        '
        Me.dgcTemGrp_DescriptionS.DataPropertyName = "TemGrp_DescriptionS"
        Me.dgcTemGrp_DescriptionS.FillWeight = 150.0!
        Me.dgcTemGrp_DescriptionS.HeaderText = "Short Description"
        Me.dgcTemGrp_DescriptionS.Name = "dgcTemGrp_DescriptionS"
        Me.dgcTemGrp_DescriptionS.ReadOnly = True
        Me.dgcTemGrp_DescriptionS.Visible = False
        '
        'dgcTemGrp_IsActive
        '
        Me.dgcTemGrp_IsActive.DataPropertyName = "TemGrp_IsActive"
        Me.dgcTemGrp_IsActive.FillWeight = 150.0!
        Me.dgcTemGrp_IsActive.HeaderText = "Is Active"
        Me.dgcTemGrp_IsActive.Name = "dgcTemGrp_IsActive"
        Me.dgcTemGrp_IsActive.ReadOnly = True
        Me.dgcTemGrp_IsActive.Visible = False
        Me.dgcTemGrp_IsActive.Width = 60
        '
        'DayUnits
        '
        Me.DayUnits.DataPropertyName = "TemGrp_DayUnits"
        DataGridViewCellStyle1.Format = "0.00"
        Me.DayUnits.DefaultCellStyle = DataGridViewCellStyle1
        Me.DayUnits.HeaderText = "Day Units"
        Me.DayUnits.Name = "DayUnits"
        Me.DayUnits.ReadOnly = True
        Me.DayUnits.Visible = False
        '
        'GLAnl1
        '
        Me.GLAnl1.DataPropertyName = "TemGrp_GlAnl1"
        Me.GLAnl1.HeaderText = "GLAnl1"
        Me.GLAnl1.Name = "GLAnl1"
        Me.GLAnl1.ReadOnly = True
        Me.GLAnl1.Visible = False
        '
        'GLAnl2
        '
        Me.GLAnl2.DataPropertyName = "TemGrp_GLAnl2"
        Me.GLAnl2.HeaderText = "GLAnl2"
        Me.GLAnl2.Name = "GLAnl2"
        Me.GLAnl2.ReadOnly = True
        Me.GLAnl2.Visible = False
        '
        'Company
        '
        Me.Company.DataPropertyName = "Com_Code"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        '
        'FrmTemplateSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(550, 603)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmTemplateSearch"
        Me.Text = "Select Template"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgcTemGrp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPayTyp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAnl1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAnl2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
