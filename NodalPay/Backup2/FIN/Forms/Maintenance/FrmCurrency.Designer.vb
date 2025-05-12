<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCurrency
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TbcCurrency = New System.Windows.Forms.TabControl
        Me.TabCurrency = New System.Windows.Forms.TabPage
        Me.CmbIsActiveCur = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.DgCurrencies = New System.Windows.Forms.DataGridView
        Me.Cur_AlphaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cur_NumericCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cur_Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cur_Symbol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cur_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.TxtDescription = New System.Windows.Forms.TextBox
        Me.TxtSymbol = New System.Windows.Forms.TextBox
        Me.TxtNumericCode = New System.Windows.Forms.TextBox
        Me.TxtAlphaCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabCurrencyRates = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnDelRates = New System.Windows.Forms.Button
        Me.BtnSaveRate = New System.Windows.Forms.Button
        Me.BtnNewRate = New System.Windows.Forms.Button
        Me.DgCurRates = New System.Windows.Forms.DataGridView
        Me.CurRte_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AlphaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_Rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_EffectiveDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRte_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmbAlphaCode = New System.Windows.Forms.ComboBox
        Me.DtpCreatedDate = New System.Windows.Forms.DateTimePicker
        Me.DtpEffectiveDate = New System.Windows.Forms.DateTimePicker
        Me.DtpAmendDate = New System.Windows.Forms.DateTimePicker
        Me.TxtCreatedBy = New System.Windows.Forms.TextBox
        Me.TxtAmendBy = New System.Windows.Forms.TextBox
        Me.TxtRate = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er3 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrRate = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TbcCurrency.SuspendLayout()
        Me.TabCurrency.SuspendLayout()
        CType(Me.DgCurrencies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabCurrencyRates.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgCurRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbcCurrency
        '
        Me.TbcCurrency.Controls.Add(Me.TabCurrency)
        Me.TbcCurrency.Controls.Add(Me.TabCurrencyRates)
        Me.TbcCurrency.Location = New System.Drawing.Point(4, 4)
        Me.TbcCurrency.Name = "TbcCurrency"
        Me.TbcCurrency.SelectedIndex = 0
        Me.TbcCurrency.Size = New System.Drawing.Size(660, 378)
        Me.TbcCurrency.TabIndex = 1
        '
        'TabCurrency
        '
        Me.TabCurrency.Controls.Add(Me.CmbIsActiveCur)
        Me.TabCurrency.Controls.Add(Me.Label13)
        Me.TabCurrency.Controls.Add(Me.DgCurrencies)
        Me.TabCurrency.Controls.Add(Me.GroupBox1)
        Me.TabCurrency.Controls.Add(Me.TxtDescription)
        Me.TabCurrency.Controls.Add(Me.TxtSymbol)
        Me.TabCurrency.Controls.Add(Me.TxtNumericCode)
        Me.TabCurrency.Controls.Add(Me.TxtAlphaCode)
        Me.TabCurrency.Controls.Add(Me.Label4)
        Me.TabCurrency.Controls.Add(Me.Label3)
        Me.TabCurrency.Controls.Add(Me.Label2)
        Me.TabCurrency.Controls.Add(Me.Label1)
        Me.TabCurrency.Location = New System.Drawing.Point(4, 22)
        Me.TabCurrency.Name = "TabCurrency"
        Me.TabCurrency.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCurrency.Size = New System.Drawing.Size(652, 352)
        Me.TabCurrency.TabIndex = 0
        Me.TabCurrency.Text = "Currency"
        Me.TabCurrency.UseVisualStyleBackColor = True
        '
        'CmbIsActiveCur
        '
        Me.CmbIsActiveCur.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem
        Me.CmbIsActiveCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbIsActiveCur.FormattingEnabled = True
        Me.CmbIsActiveCur.Items.AddRange(New Object() {"A - Active", "I - InActive"})
        Me.CmbIsActiveCur.Location = New System.Drawing.Point(100, 52)
        Me.CmbIsActiveCur.Name = "CmbIsActiveCur"
        Me.CmbIsActiveCur.Size = New System.Drawing.Size(118, 21)
        Me.CmbIsActiveCur.TabIndex = 64
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Active"
        '
        'DgCurrencies
        '
        Me.DgCurrencies.AllowUserToAddRows = False
        Me.DgCurrencies.AllowUserToDeleteRows = False
        Me.DgCurrencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCurrencies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cur_AlphaCode, Me.Cur_NumericCode, Me.Cur_Description, Me.Cur_Symbol, Me.Cur_IsActive})
        Me.DgCurrencies.Location = New System.Drawing.Point(11, 120)
        Me.DgCurrencies.Name = "DgCurrencies"
        Me.DgCurrencies.ReadOnly = True
        Me.DgCurrencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgCurrencies.Size = New System.Drawing.Size(631, 229)
        Me.DgCurrencies.TabIndex = 13
        '
        'Cur_AlphaCode
        '
        Me.Cur_AlphaCode.DataPropertyName = "Cur_AlphaCode"
        Me.Cur_AlphaCode.HeaderText = "Alpha Code"
        Me.Cur_AlphaCode.Name = "Cur_AlphaCode"
        Me.Cur_AlphaCode.ReadOnly = True
        Me.Cur_AlphaCode.Width = 90
        '
        'Cur_NumericCode
        '
        Me.Cur_NumericCode.DataPropertyName = "Cur_NumericCode"
        Me.Cur_NumericCode.HeaderText = "Numeric Code"
        Me.Cur_NumericCode.Name = "Cur_NumericCode"
        Me.Cur_NumericCode.ReadOnly = True
        '
        'Cur_Description
        '
        Me.Cur_Description.DataPropertyName = "Cur_Description"
        Me.Cur_Description.HeaderText = "Description"
        Me.Cur_Description.Name = "Cur_Description"
        Me.Cur_Description.ReadOnly = True
        Me.Cur_Description.Width = 270
        '
        'Cur_Symbol
        '
        Me.Cur_Symbol.DataPropertyName = "Cur_Symbol"
        Me.Cur_Symbol.HeaderText = "Symbol"
        Me.Cur_Symbol.Name = "Cur_Symbol"
        Me.Cur_Symbol.ReadOnly = True
        Me.Cur_Symbol.Width = 50
        '
        'Cur_IsActive
        '
        Me.Cur_IsActive.DataPropertyName = "Cur_IsActive"
        Me.Cur_IsActive.HeaderText = "Is Active"
        Me.Cur_IsActive.Name = "Cur_IsActive"
        Me.Cur_IsActive.ReadOnly = True
        Me.Cur_IsActive.Width = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnDelete)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Location = New System.Drawing.Point(561, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(81, 108)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Location = New System.Drawing.Point(15, 74)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(54, 23)
        Me.BtnDelete.TabIndex = 13
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(15, 44)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(54, 23)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(15, 15)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(54, 23)
        Me.BtnNew.TabIndex = 10
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(333, 15)
        Me.TxtDescription.MaxLength = 30
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(222, 20)
        Me.TxtDescription.TabIndex = 9
        '
        'TxtSymbol
        '
        Me.TxtSymbol.Location = New System.Drawing.Point(333, 34)
        Me.TxtSymbol.MaxLength = 1
        Me.TxtSymbol.Name = "TxtSymbol"
        Me.TxtSymbol.Size = New System.Drawing.Size(100, 20)
        Me.TxtSymbol.TabIndex = 8
        '
        'TxtNumericCode
        '
        Me.TxtNumericCode.Location = New System.Drawing.Point(100, 35)
        Me.TxtNumericCode.MaxLength = 3
        Me.TxtNumericCode.Name = "TxtNumericCode"
        Me.TxtNumericCode.Size = New System.Drawing.Size(118, 20)
        Me.TxtNumericCode.TabIndex = 7
        '
        'TxtAlphaCode
        '
        Me.TxtAlphaCode.BackColor = System.Drawing.SystemColors.Info
        Me.TxtAlphaCode.Location = New System.Drawing.Point(100, 15)
        Me.TxtAlphaCode.MaxLength = 3
        Me.TxtAlphaCode.Name = "TxtAlphaCode"
        Me.TxtAlphaCode.Size = New System.Drawing.Size(118, 20)
        Me.TxtAlphaCode.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Symbol"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numeric Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Alpha Code"
        '
        'TabCurrencyRates
        '
        Me.TabCurrencyRates.Controls.Add(Me.GroupBox3)
        Me.TabCurrencyRates.Controls.Add(Me.DgCurRates)
        Me.TabCurrencyRates.Controls.Add(Me.CmbAlphaCode)
        Me.TabCurrencyRates.Controls.Add(Me.DtpCreatedDate)
        Me.TabCurrencyRates.Controls.Add(Me.DtpEffectiveDate)
        Me.TabCurrencyRates.Controls.Add(Me.DtpAmendDate)
        Me.TabCurrencyRates.Controls.Add(Me.TxtCreatedBy)
        Me.TabCurrencyRates.Controls.Add(Me.TxtAmendBy)
        Me.TabCurrencyRates.Controls.Add(Me.TxtRate)
        Me.TabCurrencyRates.Controls.Add(Me.Label12)
        Me.TabCurrencyRates.Controls.Add(Me.Label11)
        Me.TabCurrencyRates.Controls.Add(Me.Label10)
        Me.TabCurrencyRates.Controls.Add(Me.Label9)
        Me.TabCurrencyRates.Controls.Add(Me.Label8)
        Me.TabCurrencyRates.Controls.Add(Me.Label7)
        Me.TabCurrencyRates.Controls.Add(Me.Label6)
        Me.TabCurrencyRates.Location = New System.Drawing.Point(4, 22)
        Me.TabCurrencyRates.Name = "TabCurrencyRates"
        Me.TabCurrencyRates.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCurrencyRates.Size = New System.Drawing.Size(652, 352)
        Me.TabCurrencyRates.TabIndex = 1
        Me.TabCurrencyRates.Text = "Currency Rates"
        Me.TabCurrencyRates.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnDelRates)
        Me.GroupBox3.Controls.Add(Me.BtnSaveRate)
        Me.GroupBox3.Controls.Add(Me.BtnNewRate)
        Me.GroupBox3.Location = New System.Drawing.Point(561, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(79, 105)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'BtnDelRates
        '
        Me.BtnDelRates.Enabled = False
        Me.BtnDelRates.Location = New System.Drawing.Point(13, 72)
        Me.BtnDelRates.Name = "BtnDelRates"
        Me.BtnDelRates.Size = New System.Drawing.Size(54, 23)
        Me.BtnDelRates.TabIndex = 13
        Me.BtnDelRates.Text = "Delete"
        Me.BtnDelRates.UseVisualStyleBackColor = True
        '
        'BtnSaveRate
        '
        Me.BtnSaveRate.Location = New System.Drawing.Point(13, 42)
        Me.BtnSaveRate.Name = "BtnSaveRate"
        Me.BtnSaveRate.Size = New System.Drawing.Size(54, 23)
        Me.BtnSaveRate.TabIndex = 11
        Me.BtnSaveRate.Text = "Save"
        Me.BtnSaveRate.UseVisualStyleBackColor = True
        '
        'BtnNewRate
        '
        Me.BtnNewRate.Location = New System.Drawing.Point(13, 13)
        Me.BtnNewRate.Name = "BtnNewRate"
        Me.BtnNewRate.Size = New System.Drawing.Size(54, 23)
        Me.BtnNewRate.TabIndex = 10
        Me.BtnNewRate.Text = "New"
        Me.BtnNewRate.UseVisualStyleBackColor = True
        '
        'DgCurRates
        '
        Me.DgCurRates.AllowUserToAddRows = False
        Me.DgCurRates.AllowUserToDeleteRows = False
        Me.DgCurRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCurRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CurRte_id, Me.CreatedBy, Me.AmendBy, Me.AlphaCode, Me.CurRte_Rate, Me.CurRte_EffectiveDate, Me.CurRte_CreatedBy, Me.CurRte_CreationDate, Me.CurRte_AmendBy, Me.CurRte_AmendDate})
        Me.DgCurRates.Location = New System.Drawing.Point(9, 120)
        Me.DgCurRates.Name = "DgCurRates"
        Me.DgCurRates.ReadOnly = True
        Me.DgCurRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgCurRates.Size = New System.Drawing.Size(631, 229)
        Me.DgCurRates.TabIndex = 14
        '
        'CurRte_id
        '
        Me.CurRte_id.DataPropertyName = "CurRte_id"
        Me.CurRte_id.HeaderText = "CurRte_id"
        Me.CurRte_id.Name = "CurRte_id"
        Me.CurRte_id.ReadOnly = True
        Me.CurRte_id.Visible = False
        '
        'CreatedBy
        '
        Me.CreatedBy.DataPropertyName = "CreatedBy"
        Me.CreatedBy.HeaderText = "CreatedBy"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.ReadOnly = True
        Me.CreatedBy.Visible = False
        '
        'AmendBy
        '
        Me.AmendBy.DataPropertyName = "AmendBy"
        Me.AmendBy.HeaderText = "AmendBy"
        Me.AmendBy.Name = "AmendBy"
        Me.AmendBy.ReadOnly = True
        Me.AmendBy.Visible = False
        '
        'AlphaCode
        '
        Me.AlphaCode.DataPropertyName = "cur_AlphaCode"
        Me.AlphaCode.HeaderText = "Alpha Code"
        Me.AlphaCode.Name = "AlphaCode"
        Me.AlphaCode.ReadOnly = True
        '
        'CurRte_Rate
        '
        Me.CurRte_Rate.DataPropertyName = "CurRte_Rate"
        DataGridViewCellStyle1.Format = "N5"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CurRte_Rate.DefaultCellStyle = DataGridViewCellStyle1
        Me.CurRte_Rate.HeaderText = "Rate"
        Me.CurRte_Rate.Name = "CurRte_Rate"
        Me.CurRte_Rate.ReadOnly = True
        '
        'CurRte_EffectiveDate
        '
        Me.CurRte_EffectiveDate.DataPropertyName = "CurRte_EffectiveDate"
        DataGridViewCellStyle2.Format = "dd-MM-yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CurRte_EffectiveDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.CurRte_EffectiveDate.HeaderText = "Effective Date"
        Me.CurRte_EffectiveDate.Name = "CurRte_EffectiveDate"
        Me.CurRte_EffectiveDate.ReadOnly = True
        '
        'CurRte_CreatedBy
        '
        Me.CurRte_CreatedBy.DataPropertyName = "CurRte_CreatedBy"
        Me.CurRte_CreatedBy.HeaderText = "CurRte_CreatedBy"
        Me.CurRte_CreatedBy.Name = "CurRte_CreatedBy"
        Me.CurRte_CreatedBy.ReadOnly = True
        Me.CurRte_CreatedBy.Visible = False
        '
        'CurRte_CreationDate
        '
        Me.CurRte_CreationDate.DataPropertyName = "CurRte_CreationDate"
        DataGridViewCellStyle3.Format = "dd-MM-yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CurRte_CreationDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.CurRte_CreationDate.HeaderText = "Creation Date"
        Me.CurRte_CreationDate.Name = "CurRte_CreationDate"
        Me.CurRte_CreationDate.ReadOnly = True
        '
        'CurRte_AmendBy
        '
        Me.CurRte_AmendBy.DataPropertyName = "CurRte_AmendBy"
        Me.CurRte_AmendBy.HeaderText = "CurRte_AmendBy"
        Me.CurRte_AmendBy.Name = "CurRte_AmendBy"
        Me.CurRte_AmendBy.ReadOnly = True
        Me.CurRte_AmendBy.Visible = False
        '
        'CurRte_AmendDate
        '
        Me.CurRte_AmendDate.DataPropertyName = "CurRte_AmendDate"
        DataGridViewCellStyle4.Format = "dd-MM-yyyy"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.CurRte_AmendDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.CurRte_AmendDate.HeaderText = "CurRte_AmendDate"
        Me.CurRte_AmendDate.Name = "CurRte_AmendDate"
        Me.CurRte_AmendDate.ReadOnly = True
        Me.CurRte_AmendDate.Visible = False
        '
        'CmbAlphaCode
        '
        Me.CmbAlphaCode.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlphaCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlphaCode.FormattingEnabled = True
        Me.CmbAlphaCode.Location = New System.Drawing.Point(100, 15)
        Me.CmbAlphaCode.Name = "CmbAlphaCode"
        Me.CmbAlphaCode.Size = New System.Drawing.Size(202, 21)
        Me.CmbAlphaCode.TabIndex = 13
        '
        'DtpCreatedDate
        '
        Me.DtpCreatedDate.Enabled = False
        Me.DtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpCreatedDate.Location = New System.Drawing.Point(399, 34)
        Me.DtpCreatedDate.Name = "DtpCreatedDate"
        Me.DtpCreatedDate.Size = New System.Drawing.Size(145, 20)
        Me.DtpCreatedDate.TabIndex = 12
        '
        'DtpEffectiveDate
        '
        Me.DtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpEffectiveDate.Location = New System.Drawing.Point(101, 56)
        Me.DtpEffectiveDate.Name = "DtpEffectiveDate"
        Me.DtpEffectiveDate.Size = New System.Drawing.Size(126, 20)
        Me.DtpEffectiveDate.TabIndex = 11
        '
        'DtpAmendDate
        '
        Me.DtpAmendDate.Enabled = False
        Me.DtpAmendDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpAmendDate.Location = New System.Drawing.Point(399, 79)
        Me.DtpAmendDate.Name = "DtpAmendDate"
        Me.DtpAmendDate.Size = New System.Drawing.Size(145, 20)
        Me.DtpAmendDate.TabIndex = 10
        '
        'TxtCreatedBy
        '
        Me.TxtCreatedBy.BackColor = System.Drawing.SystemColors.Info
        Me.TxtCreatedBy.Location = New System.Drawing.Point(399, 15)
        Me.TxtCreatedBy.Name = "TxtCreatedBy"
        Me.TxtCreatedBy.ReadOnly = True
        Me.TxtCreatedBy.Size = New System.Drawing.Size(145, 20)
        Me.TxtCreatedBy.TabIndex = 9
        '
        'TxtAmendBy
        '
        Me.TxtAmendBy.BackColor = System.Drawing.SystemColors.Info
        Me.TxtAmendBy.Location = New System.Drawing.Point(399, 60)
        Me.TxtAmendBy.Name = "TxtAmendBy"
        Me.TxtAmendBy.ReadOnly = True
        Me.TxtAmendBy.Size = New System.Drawing.Size(145, 20)
        Me.TxtAmendBy.TabIndex = 8
        '
        'TxtRate
        '
        Me.TxtRate.Location = New System.Drawing.Point(100, 36)
        Me.TxtRate.MaxLength = 11
        Me.TxtRate.Name = "TxtRate"
        Me.TxtRate.Size = New System.Drawing.Size(126, 20)
        Me.TxtRate.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(317, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Amend Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(319, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Amend By"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(318, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Creation Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(320, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Created By"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Effective Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Rate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Alpha Code"
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'Er2
        '
        Me.Er2.ContainerControl = Me
        '
        'Er3
        '
        Me.Er3.ContainerControl = Me
        '
        'ErrRate
        '
        Me.ErrRate.ContainerControl = Me
        '
        'FrmCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(667, 385)
        Me.Controls.Add(Me.TbcCurrency)
        Me.Name = "FrmCurrency"
        Me.Text = "Currency Maintenance"
        Me.TbcCurrency.ResumeLayout(False)
        Me.TabCurrency.ResumeLayout(False)
        Me.TabCurrency.PerformLayout()
        CType(Me.DgCurrencies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabCurrencyRates.ResumeLayout(False)
        Me.TabCurrencyRates.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DgCurRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbcCurrency As System.Windows.Forms.TabControl
    Friend WithEvents TabCurrency As System.Windows.Forms.TabPage
    Friend WithEvents DgCurrencies As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtSymbol As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumericCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtAlphaCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabCurrencyRates As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelRates As System.Windows.Forms.Button
    Friend WithEvents BtnSaveRate As System.Windows.Forms.Button
    Friend WithEvents BtnNewRate As System.Windows.Forms.Button
    Friend WithEvents DgCurRates As System.Windows.Forms.DataGridView
    Friend WithEvents CmbAlphaCode As System.Windows.Forms.ComboBox
    Friend WithEvents DtpCreatedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpAmendDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents TxtAmendBy As System.Windows.Forms.TextBox
    Friend WithEvents TxtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er3 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CmbIsActiveCur As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ErrRate As System.Windows.Forms.ErrorProvider
    Friend WithEvents Cur_AlphaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_NumericCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_Symbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlphaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_EffectiveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRte_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
