<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeriodGroupSearch
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
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.dgcPrdGrp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPrdGrp_Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPrdGpr_Year = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcTemGrp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgcPrdGrp_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcPrdGrp_Code, Me.dgcPrdGrp_Status, Me.dgcPrdGpr_Year, Me.dgcTemGrp_Code, Me.dgcPrdGrp_DescriptionL})
        Me.DG1.Location = New System.Drawing.Point(0, 12)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(608, 592)
        Me.DG1.TabIndex = 11
        '
        'dgcPrdGrp_Code
        '
        Me.dgcPrdGrp_Code.DataPropertyName = "PrdGrp_Code"
        Me.dgcPrdGrp_Code.FillWeight = 150.0!
        Me.dgcPrdGrp_Code.HeaderText = "Code"
        Me.dgcPrdGrp_Code.Name = "dgcPrdGrp_Code"
        Me.dgcPrdGrp_Code.ReadOnly = True
        Me.dgcPrdGrp_Code.Width = 60
        '
        'dgcPrdGrp_Status
        '
        Me.dgcPrdGrp_Status.DataPropertyName = "PrdGrp_Status"
        Me.dgcPrdGrp_Status.FillWeight = 150.0!
        Me.dgcPrdGrp_Status.HeaderText = "Status"
        Me.dgcPrdGrp_Status.Name = "dgcPrdGrp_Status"
        Me.dgcPrdGrp_Status.ReadOnly = True
        Me.dgcPrdGrp_Status.Visible = False
        Me.dgcPrdGrp_Status.Width = 60
        '
        'dgcPrdGpr_Year
        '
        Me.dgcPrdGpr_Year.DataPropertyName = "PrdGpr_Year"
        Me.dgcPrdGpr_Year.FillWeight = 150.0!
        Me.dgcPrdGpr_Year.HeaderText = "Year"
        Me.dgcPrdGpr_Year.Name = "dgcPrdGpr_Year"
        Me.dgcPrdGpr_Year.ReadOnly = True
        Me.dgcPrdGpr_Year.Width = 60
        '
        'dgcTemGrp_Code
        '
        Me.dgcTemGrp_Code.DataPropertyName = "TemGrp_Code"
        Me.dgcTemGrp_Code.FillWeight = 150.0!
        Me.dgcTemGrp_Code.HeaderText = "Template Code"
        Me.dgcTemGrp_Code.Name = "dgcTemGrp_Code"
        Me.dgcTemGrp_Code.ReadOnly = True
        '
        'dgcPrdGrp_DescriptionL
        '
        Me.dgcPrdGrp_DescriptionL.DataPropertyName = "PrdGrp_DescriptionL"
        Me.dgcPrdGrp_DescriptionL.FillWeight = 150.0!
        Me.dgcPrdGrp_DescriptionL.HeaderText = "Long Description"
        Me.dgcPrdGrp_DescriptionL.Name = "dgcPrdGrp_DescriptionL"
        Me.dgcPrdGrp_DescriptionL.ReadOnly = True
        Me.dgcPrdGrp_DescriptionL.Width = 250
        '
        'FrmPeriodGroupSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(605, 603)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmPeriodGroupSearch"
        Me.Text = "Select Period Group"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgcPrdGrp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPrdGrp_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPrdGpr_Year As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTemGrp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPrdGrp_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
