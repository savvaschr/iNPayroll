<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectPeriodGroupsForSI
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PeriodGroup1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TemplateGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.PeriodGroup1, Me.TemplateGroup, Me.Description})
        Me.DG1.Location = New System.Drawing.Point(12, 12)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1009, 218)
        Me.DG1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(946, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Done"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.HeaderText = "Selected"
        Me.Selected.Name = "Selected"
        '
        'PeriodGroup1
        '
        Me.PeriodGroup1.DataPropertyName = "PrdGrp_Code"
        Me.PeriodGroup1.HeaderText = "Period Group"
        Me.PeriodGroup1.Name = "PeriodGroup1"
        Me.PeriodGroup1.Width = 200
        '
        'TemplateGroup
        '
        Me.TemplateGroup.DataPropertyName = "TemGrp_Code"
        Me.TemplateGroup.HeaderText = "Template Group"
        Me.TemplateGroup.Name = "TemplateGroup"
        Me.TemplateGroup.Width = 200
        '
        'Description
        '
        Me.Description.DataPropertyName = "PrdGrp_DescriptionL"
        Me.Description.HeaderText = "Period Group Desc."
        Me.Description.Name = "Description"
        Me.Description.Width = 250
        '
        'FrmSelectPeriodGroupsForSI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 318)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmSelectPeriodGroupsForSI"
        Me.Text = "FrmSelectPeriodGroupsForSI"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PeriodGroup1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemplateGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
