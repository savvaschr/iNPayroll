<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPFReportByCompany
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.ComboSelectAnal = New System.Windows.Forms.ComboBox
        Me.ComboAnal = New System.Windows.Forms.ComboBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.btnExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Analysis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FirstN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PFA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PFB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PFTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Analysis"
        '
        'ComboSelectAnal
        '
        Me.ComboSelectAnal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSelectAnal.FormattingEnabled = True
        Me.ComboSelectAnal.Location = New System.Drawing.Point(130, 17)
        Me.ComboSelectAnal.Name = "ComboSelectAnal"
        Me.ComboSelectAnal.Size = New System.Drawing.Size(47, 21)
        Me.ComboSelectAnal.TabIndex = 93
        '
        'ComboAnal
        '
        Me.ComboAnal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnal.FormattingEnabled = True
        Me.ComboAnal.Location = New System.Drawing.Point(183, 17)
        Me.ComboAnal.Name = "ComboAnal"
        Me.ComboAnal.Size = New System.Drawing.Size(348, 21)
        Me.ComboAnal.TabIndex = 92
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Analysis, Me.Code, Me.FirstN, Me.LastN, Me.PFA, Me.PFB, Me.PFTotal})
        Me.DG1.Location = New System.Drawing.Point(17, 49)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(938, 488)
        Me.DG1.TabIndex = 95
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(871, 20)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(84, 23)
        Me.btnExcel.TabIndex = 96
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(781, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 23)
        Me.Button1.TabIndex = 97
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Analysis
        '
        Me.Analysis.DataPropertyName = "AnalX"
        Me.Analysis.HeaderText = "Analysis"
        Me.Analysis.Name = "Analysis"
        '
        'Code
        '
        Me.Code.DataPropertyName = "Emp_Code"
        Me.Code.HeaderText = "Emp.Code"
        Me.Code.Name = "Code"
        '
        'FirstN
        '
        Me.FirstN.DataPropertyName = "Emp_FirstName"
        Me.FirstN.HeaderText = "Name"
        Me.FirstN.Name = "FirstN"
        '
        'LastN
        '
        Me.LastN.DataPropertyName = "Emp_LastName"
        Me.LastN.HeaderText = "Surname"
        Me.LastN.Name = "LastN"
        '
        'PFA
        '
        Me.PFA.DataPropertyName = "DedValue"
        Me.PFA.HeaderText = "PF A Value"
        Me.PFA.Name = "PFA"
        '
        'PFB
        '
        Me.PFB.DataPropertyName = "ConValue"
        Me.PFB.HeaderText = "PF B Value"
        Me.PFB.Name = "PFB"
        '
        'PFTotal
        '
        Me.PFTotal.DataPropertyName = "Total"
        Me.PFTotal.HeaderText = "Total"
        Me.PFTotal.Name = "PFTotal"
        '
        'FrmPFReportByCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 549)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboSelectAnal)
        Me.Controls.Add(Me.ComboAnal)
        Me.Name = "FrmPFReportByCompany"
        Me.Text = "PF Report By Company"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboSelectAnal As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnal As System.Windows.Forms.ComboBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Analysis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirstN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PFA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PFB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PFTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
