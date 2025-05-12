<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBudget
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
        Me.components = New System.ComponentModel.Container
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.BudLin_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bud_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Prd_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AccountSearch = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Acc_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Acc_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudLin_Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn1_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn2_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn3_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn4_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn5_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn6_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn7_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn8_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn9_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AcLAn10_Code = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.BudLin_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudLin_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudLin_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudLin_AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnBudgetSearch = New System.Windows.Forms.Button
        Me.txtBudgetCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBudgetDesc = New System.Windows.Forms.TextBox
        Me.ComboYears = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Err1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnNew = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BudLin_Id, Me.Bud_Code, Me.Prd_Code, Me.AccountSearch, Me.Acc_Code, Me.Acc_DescriptionL, Me.BudLin_Amount, Me.AcLAn1_Code, Me.AcLAn2_Code, Me.AcLAn3_Code, Me.AcLAn4_Code, Me.AcLAn5_Code, Me.AcLAn6_Code, Me.AcLAn7_Code, Me.AcLAn8_Code, Me.AcLAn9_Code, Me.AcLAn10_Code, Me.BudLin_CreationDate, Me.BudLin_AmendDate, Me.BudLin_CreatedBy, Me.BudLin_AmendBy})
        Me.DG1.Location = New System.Drawing.Point(12, 116)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(953, 350)
        Me.DG1.TabIndex = 0
        '
        'BudLin_Id
        '
        Me.BudLin_Id.DataPropertyName = "BudLin_Id"
        Me.BudLin_Id.HeaderText = "Id"
        Me.BudLin_Id.Name = "BudLin_Id"
        Me.BudLin_Id.ReadOnly = True
        Me.BudLin_Id.Visible = False
        '
        'Bud_Code
        '
        Me.Bud_Code.DataPropertyName = "Bud_Code"
        Me.Bud_Code.HeaderText = "Budget Code"
        Me.Bud_Code.Name = "Bud_Code"
        Me.Bud_Code.ReadOnly = True
        Me.Bud_Code.Visible = False
        '
        'Prd_Code
        '
        Me.Prd_Code.DataPropertyName = "Prd_Code"
        Me.Prd_Code.HeaderText = "Period"
        Me.Prd_Code.Name = "Prd_Code"
        Me.Prd_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Prd_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Prd_Code.Width = 75
        '
        'AccountSearch
        '
        Me.AccountSearch.HeaderText = ""
        Me.AccountSearch.Name = "AccountSearch"
        Me.AccountSearch.Text = "Search"
        Me.AccountSearch.Width = 20
        '
        'Acc_Code
        '
        Me.Acc_Code.DataPropertyName = "Acc_Code"
        Me.Acc_Code.HeaderText = "AccountCode"
        Me.Acc_Code.Name = "Acc_Code"
        '
        'Acc_DescriptionL
        '
        Me.Acc_DescriptionL.DataPropertyName = "Acc_DescriptionL"
        Me.Acc_DescriptionL.HeaderText = "Account Description"
        Me.Acc_DescriptionL.Name = "Acc_DescriptionL"
        Me.Acc_DescriptionL.ReadOnly = True
        Me.Acc_DescriptionL.Width = 170
        '
        'BudLin_Amount
        '
        Me.BudLin_Amount.DataPropertyName = "BudLin_Amount"
        Me.BudLin_Amount.HeaderText = "Amount"
        Me.BudLin_Amount.Name = "BudLin_Amount"
        '
        'AcLAn1_Code
        '
        Me.AcLAn1_Code.DataPropertyName = "AcLAn1_Code"
        Me.AcLAn1_Code.HeaderText = "Analisys1"
        Me.AcLAn1_Code.Name = "AcLAn1_Code"
        Me.AcLAn1_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn1_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn2_Code
        '
        Me.AcLAn2_Code.DataPropertyName = "AcLAn2_Code"
        Me.AcLAn2_Code.HeaderText = "Analysis2"
        Me.AcLAn2_Code.Name = "AcLAn2_Code"
        Me.AcLAn2_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn2_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn3_Code
        '
        Me.AcLAn3_Code.DataPropertyName = "AcLAn3_Code"
        Me.AcLAn3_Code.HeaderText = "Analysis3"
        Me.AcLAn3_Code.Name = "AcLAn3_Code"
        Me.AcLAn3_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn3_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn4_Code
        '
        Me.AcLAn4_Code.DataPropertyName = "AcLAn4_Code"
        Me.AcLAn4_Code.HeaderText = "Analisys4"
        Me.AcLAn4_Code.Name = "AcLAn4_Code"
        Me.AcLAn4_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn4_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn5_Code
        '
        Me.AcLAn5_Code.DataPropertyName = "AcLAn5_Code"
        Me.AcLAn5_Code.HeaderText = "Analisys5"
        Me.AcLAn5_Code.Name = "AcLAn5_Code"
        Me.AcLAn5_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn5_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn6_Code
        '
        Me.AcLAn6_Code.DataPropertyName = "AcLAn6_Code"
        Me.AcLAn6_Code.HeaderText = "Analysis6"
        Me.AcLAn6_Code.Name = "AcLAn6_Code"
        Me.AcLAn6_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn6_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn7_Code
        '
        Me.AcLAn7_Code.DataPropertyName = "AcLAn7_Code"
        Me.AcLAn7_Code.HeaderText = "Analysis7"
        Me.AcLAn7_Code.Name = "AcLAn7_Code"
        Me.AcLAn7_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn7_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn8_Code
        '
        Me.AcLAn8_Code.DataPropertyName = "AcLAn8_Code"
        Me.AcLAn8_Code.HeaderText = "Analisys8"
        Me.AcLAn8_Code.Name = "AcLAn8_Code"
        Me.AcLAn8_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn8_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn9_Code
        '
        Me.AcLAn9_Code.DataPropertyName = "AcLAn9_Code"
        Me.AcLAn9_Code.HeaderText = "Analysis9"
        Me.AcLAn9_Code.Name = "AcLAn9_Code"
        Me.AcLAn9_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn9_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AcLAn10_Code
        '
        Me.AcLAn10_Code.DataPropertyName = "AcLAn10_Code"
        Me.AcLAn10_Code.HeaderText = "Analysis10"
        Me.AcLAn10_Code.Name = "AcLAn10_Code"
        Me.AcLAn10_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AcLAn10_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'BudLin_CreationDate
        '
        Me.BudLin_CreationDate.DataPropertyName = "BudLin_CreationDate"
        Me.BudLin_CreationDate.HeaderText = "CreationDate"
        Me.BudLin_CreationDate.Name = "BudLin_CreationDate"
        Me.BudLin_CreationDate.ReadOnly = True
        Me.BudLin_CreationDate.Visible = False
        '
        'BudLin_AmendDate
        '
        Me.BudLin_AmendDate.DataPropertyName = "BudLin_AmendDate"
        Me.BudLin_AmendDate.HeaderText = "AmendDate"
        Me.BudLin_AmendDate.Name = "BudLin_AmendDate"
        Me.BudLin_AmendDate.ReadOnly = True
        Me.BudLin_AmendDate.Visible = False
        '
        'BudLin_CreatedBy
        '
        Me.BudLin_CreatedBy.DataPropertyName = "BudLin_CreatedBy"
        Me.BudLin_CreatedBy.HeaderText = "CreatedBy"
        Me.BudLin_CreatedBy.Name = "BudLin_CreatedBy"
        Me.BudLin_CreatedBy.ReadOnly = True
        Me.BudLin_CreatedBy.Visible = False
        '
        'BudLin_AmendBy
        '
        Me.BudLin_AmendBy.DataPropertyName = "BudLin_AmendBy"
        Me.BudLin_AmendBy.HeaderText = "AmendBy"
        Me.BudLin_AmendBy.Name = "BudLin_AmendBy"
        Me.BudLin_AmendBy.ReadOnly = True
        Me.BudLin_AmendBy.Visible = False
        '
        'BtnBudgetSearch
        '
        Me.BtnBudgetSearch.Location = New System.Drawing.Point(222, 12)
        Me.BtnBudgetSearch.Name = "BtnBudgetSearch"
        Me.BtnBudgetSearch.Size = New System.Drawing.Size(75, 23)
        Me.BtnBudgetSearch.TabIndex = 1
        Me.BtnBudgetSearch.Text = "Search"
        Me.BtnBudgetSearch.UseVisualStyleBackColor = True
        '
        'txtBudgetCode
        '
        Me.txtBudgetCode.Location = New System.Drawing.Point(116, 14)
        Me.txtBudgetCode.Name = "txtBudgetCode"
        Me.txtBudgetCode.Size = New System.Drawing.Size(100, 20)
        Me.txtBudgetCode.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Budget Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Budget Description"
        '
        'txtBudgetDesc
        '
        Me.txtBudgetDesc.Location = New System.Drawing.Point(116, 40)
        Me.txtBudgetDesc.Name = "txtBudgetDesc"
        Me.txtBudgetDesc.Size = New System.Drawing.Size(176, 20)
        Me.txtBudgetDesc.TabIndex = 5
        '
        'ComboYears
        '
        Me.ComboYears.FormattingEnabled = True
        Me.ComboYears.Location = New System.Drawing.Point(116, 66)
        Me.ComboYears.Name = "ComboYears"
        Me.ComboYears.Size = New System.Drawing.Size(100, 21)
        Me.ComboYears.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Year"
        '
        'Err1
        '
        Me.Err1.ContainerControl = Me
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalAmount.Location = New System.Drawing.Point(772, 79)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 8
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(6, 56)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Location = New System.Drawing.Point(878, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(87, 96)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(6, 27)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 10
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(681, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Total Amount"
        '
        'FrmBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 556)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboYears)
        Me.Controls.Add(Me.txtBudgetDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBudgetCode)
        Me.Controls.Add(Me.BtnBudgetSearch)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBudget"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBudgetSearch As System.Windows.Forms.Button
    Friend WithEvents txtBudgetCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetDesc As System.Windows.Forms.TextBox
    Friend WithEvents ComboYears As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Err1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents BudLin_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bud_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prd_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AccountSearch As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Acc_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acc_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudLin_Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn1_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn2_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn3_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn4_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn5_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn6_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn7_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn8_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn9_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AcLAn10_Code As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents BudLin_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudLin_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudLin_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudLin_AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
