<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeSelectiveSearch
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
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CBSelectGrid = New System.Windows.Forms.CheckBox
        Me.btnFinishSelection = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(381, 30)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 35
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.Location = New System.Drawing.Point(78, 32)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(280, 20)
        Me.txtDescription.TabIndex = 32
        '
        'txtCode
        '
        Me.txtCode.AcceptsReturn = True
        Me.txtCode.Location = New System.Drawing.Point(78, 12)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(191, 20)
        Me.txtCode.TabIndex = 31
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.Code, Me.FullName, Me.TemGroup})
        Me.DG1.Location = New System.Drawing.Point(-1, 107)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(894, 392)
        Me.DG1.TabIndex = 36
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.HeaderText = "Selected"
        Me.Selected.Name = "Selected"
        '
        'Code
        '
        Me.Code.DataPropertyName = "Emp_Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'FullName
        '
        Me.FullName.DataPropertyName = "Emp_FullName"
        Me.FullName.HeaderText = "Name"
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        Me.FullName.Width = 300
        '
        'TemGroup
        '
        Me.TemGroup.DataPropertyName = "TemGrp_DescriptionL"
        Me.TemGroup.HeaderText = "Temp Group"
        Me.TemGroup.Name = "TemGroup"
        Me.TemGroup.Width = 350
        '
        'CBSelectGrid
        '
        Me.CBSelectGrid.AutoSize = True
        Me.CBSelectGrid.Location = New System.Drawing.Point(78, 57)
        Me.CBSelectGrid.Name = "CBSelectGrid"
        Me.CBSelectGrid.Size = New System.Drawing.Size(15, 14)
        Me.CBSelectGrid.TabIndex = 84
        Me.CBSelectGrid.UseVisualStyleBackColor = True
        '
        'btnFinishSelection
        '
        Me.btnFinishSelection.Location = New System.Drawing.Point(474, 29)
        Me.btnFinishSelection.Name = "btnFinishSelection"
        Me.btnFinishSelection.Size = New System.Drawing.Size(130, 23)
        Me.btnFinishSelection.TabIndex = 85
        Me.btnFinishSelection.Text = "&Finish Selection"
        Me.btnFinishSelection.UseVisualStyleBackColor = True
        '
        'FrmEmployeeSelectiveSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(898, 511)
        Me.Controls.Add(Me.btnFinishSelection)
        Me.Controls.Add(Me.CBSelectGrid)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtCode)
        Me.Name = "FrmEmployeeSelectiveSearch"
        Me.Text = "Employee Selective Search"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBSelectGrid As System.Windows.Forms.CheckBox
    Friend WithEvents btnFinishSelection As System.Windows.Forms.Button
End Class
