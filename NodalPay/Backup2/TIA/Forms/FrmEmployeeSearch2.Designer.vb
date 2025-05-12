<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeSearch2
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
        Me.btnSearch = New System.Windows.Forms.Button
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtToEmployee = New System.Windows.Forms.TextBox
        Me.txtFromEmployee = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnLoad = New System.Windows.Forms.Button
        Me.ComboAnal = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioName = New System.Windows.Forms.RadioButton
        Me.RadioAnalysis = New System.Windows.Forms.RadioButton
        Me.ComboSelectAnalysis = New System.Windows.Forms.ComboBox
        Me.CB1 = New System.Windows.Forms.CheckBox
        Me.CB2 = New System.Windows.Forms.CheckBox
        Me.CB3 = New System.Windows.Forms.CheckBox
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Analysis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(398, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.Code, Me.FullName, Me.Analysis, Me.Column1})
        Me.DG1.Location = New System.Drawing.Point(12, 164)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(865, 367)
        Me.DG1.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "To Code"
        '
        'txtToEmployee
        '
        Me.txtToEmployee.Location = New System.Drawing.Point(105, 32)
        Me.txtToEmployee.Name = "txtToEmployee"
        Me.txtToEmployee.Size = New System.Drawing.Size(126, 20)
        Me.txtToEmployee.TabIndex = 81
        '
        'txtFromEmployee
        '
        Me.txtFromEmployee.Location = New System.Drawing.Point(105, 12)
        Me.txtFromEmployee.Name = "txtFromEmployee"
        Me.txtFromEmployee.Size = New System.Drawing.Size(126, 20)
        Me.txtFromEmployee.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "From Code"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(479, 13)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 83
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'ComboAnal
        '
        Me.ComboAnal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnal.FormattingEnabled = True
        Me.ComboAnal.Location = New System.Drawing.Point(105, 85)
        Me.ComboAnal.Name = "ComboAnal"
        Me.ComboAnal.Size = New System.Drawing.Size(257, 21)
        Me.ComboAnal.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Analysis 1"
        '
        'RadioName
        '
        Me.RadioName.AutoSize = True
        Me.RadioName.Location = New System.Drawing.Point(272, 126)
        Me.RadioName.Name = "RadioName"
        Me.RadioName.Size = New System.Drawing.Size(90, 17)
        Me.RadioName.TabIndex = 86
        Me.RadioName.Text = "Sort By Name"
        Me.RadioName.UseVisualStyleBackColor = True
        '
        'RadioAnalysis
        '
        Me.RadioAnalysis.AutoSize = True
        Me.RadioAnalysis.Checked = True
        Me.RadioAnalysis.Location = New System.Drawing.Point(105, 126)
        Me.RadioAnalysis.Name = "RadioAnalysis"
        Me.RadioAnalysis.Size = New System.Drawing.Size(100, 17)
        Me.RadioAnalysis.TabIndex = 87
        Me.RadioAnalysis.TabStop = True
        Me.RadioAnalysis.Text = "Sort By Analysis"
        Me.RadioAnalysis.UseVisualStyleBackColor = True
        '
        'ComboSelectAnalysis
        '
        Me.ComboSelectAnalysis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSelectAnalysis.Enabled = False
        Me.ComboSelectAnalysis.FormattingEnabled = True
        Me.ComboSelectAnalysis.Location = New System.Drawing.Point(105, 58)
        Me.ComboSelectAnalysis.Name = "ComboSelectAnalysis"
        Me.ComboSelectAnalysis.Size = New System.Drawing.Size(257, 21)
        Me.ComboSelectAnalysis.TabIndex = 88
        '
        'CB1
        '
        Me.CB1.AutoSize = True
        Me.CB1.Location = New System.Drawing.Point(399, 85)
        Me.CB1.Name = "CB1"
        Me.CB1.Size = New System.Drawing.Size(81, 17)
        Me.CB1.TabIndex = 89
        Me.CB1.Text = "CheckBox1"
        Me.CB1.UseVisualStyleBackColor = True
        '
        'CB2
        '
        Me.CB2.AutoSize = True
        Me.CB2.Location = New System.Drawing.Point(399, 108)
        Me.CB2.Name = "CB2"
        Me.CB2.Size = New System.Drawing.Size(81, 17)
        Me.CB2.TabIndex = 90
        Me.CB2.Text = "CheckBox2"
        Me.CB2.UseVisualStyleBackColor = True
        '
        'CB3
        '
        Me.CB3.AutoSize = True
        Me.CB3.Location = New System.Drawing.Point(399, 131)
        Me.CB3.Name = "CB3"
        Me.CB3.Size = New System.Drawing.Size(81, 17)
        Me.CB3.TabIndex = 91
        Me.CB3.Text = "CheckBox3"
        Me.CB3.UseVisualStyleBackColor = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.FalseValue = "0"
        Me.Selected.HeaderText = ""
        Me.Selected.Name = "Selected"
        Me.Selected.Width = 50
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
        Me.FullName.Width = 250
        '
        'Analysis
        '
        Me.Analysis.DataPropertyName = "Analysis"
        Me.Analysis.HeaderText = "Analysis"
        Me.Analysis.Name = "Analysis"
        Me.Analysis.Width = 250
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "PayUni_Code"
        Me.Column1.HeaderText = "FullTime/Hourly"
        Me.Column1.Name = "Column1"
        '
        'FrmEmployeeSearch2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(971, 546)
        Me.Controls.Add(Me.CB3)
        Me.Controls.Add(Me.CB2)
        Me.Controls.Add(Me.CB1)
        Me.Controls.Add(Me.ComboSelectAnalysis)
        Me.Controls.Add(Me.RadioAnalysis)
        Me.Controls.Add(Me.RadioName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboAnal)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtToEmployee)
        Me.Controls.Add(Me.txtFromEmployee)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmEmployeeSearch2"
        Me.Text = "Employee Search"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtToEmployee As System.Windows.Forms.TextBox
    Friend WithEvents txtFromEmployee As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ComboAnal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioAnalysis As System.Windows.Forms.RadioButton
    Friend WithEvents ComboSelectAnalysis As System.Windows.Forms.ComboBox
    Friend WithEvents CB1 As System.Windows.Forms.CheckBox
    Friend WithEvents CB2 As System.Windows.Forms.CheckBox
    Friend WithEvents CB3 As System.Windows.Forms.CheckBox
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analysis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
