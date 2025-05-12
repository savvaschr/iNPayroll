<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVat
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TbcVat = New System.Windows.Forms.TabControl
        Me.TabVat = New System.Windows.Forms.TabPage
        Me.CmbIsActiveVAT = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DgVat = New System.Windows.Forms.DataGridView
        Me.Vat_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vat_Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vat_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.TxtDescription = New System.Windows.Forms.TextBox
        Me.TxtVatCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabVatRates = New System.Windows.Forms.TabPage
        Me.CmbISActiveVATRates = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtVatRate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnDelRates = New System.Windows.Forms.Button
        Me.BtnSaveRate = New System.Windows.Forms.Button
        Me.BtnNewRate = New System.Windows.Forms.Button
        Me.DgVatRates = New System.Windows.Forms.DataGridView
        Me.VatRte_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_Rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_EffectiveDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_AmendBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VatRte_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmbVatCode = New System.Windows.Forms.ComboBox
        Me.DtpCreatedDate = New System.Windows.Forms.DateTimePicker
        Me.DtpEffectiveDate = New System.Windows.Forms.DateTimePicker
        Me.DtpAmendDate = New System.Windows.Forms.DateTimePicker
        Me.TxtCreatedBy = New System.Windows.Forms.TextBox
        Me.TxtAmendBy = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er3 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrRate = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TbcVat.SuspendLayout()
        Me.TabVat.SuspendLayout()
        CType(Me.DgVat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabVatRates.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgVatRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbcVat
        '
        Me.TbcVat.Controls.Add(Me.TabVat)
        Me.TbcVat.Controls.Add(Me.TabVatRates)
        Me.TbcVat.Location = New System.Drawing.Point(3, 1)
        Me.TbcVat.Name = "TbcVat"
        Me.TbcVat.SelectedIndex = 0
        Me.TbcVat.Size = New System.Drawing.Size(661, 382)
        Me.TbcVat.TabIndex = 2
        '
        'TabVat
        '
        Me.TabVat.Controls.Add(Me.CmbIsActiveVAT)
        Me.TabVat.Controls.Add(Me.Label7)
        Me.TabVat.Controls.Add(Me.DgVat)
        Me.TabVat.Controls.Add(Me.GroupBox1)
        Me.TabVat.Controls.Add(Me.TxtDescription)
        Me.TabVat.Controls.Add(Me.TxtVatCode)
        Me.TabVat.Controls.Add(Me.Label3)
        Me.TabVat.Controls.Add(Me.Label1)
        Me.TabVat.Location = New System.Drawing.Point(4, 22)
        Me.TabVat.Name = "TabVat"
        Me.TabVat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVat.Size = New System.Drawing.Size(653, 356)
        Me.TabVat.TabIndex = 0
        Me.TabVat.Text = "VAT"
        Me.TabVat.UseVisualStyleBackColor = True
        '
        'CmbIsActiveVAT
        '
        Me.CmbIsActiveVAT.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem
        Me.CmbIsActiveVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbIsActiveVAT.FormattingEnabled = True
        Me.CmbIsActiveVAT.Items.AddRange(New Object() {"A - Active", "I - InActive"})
        Me.CmbIsActiveVAT.Location = New System.Drawing.Point(97, 52)
        Me.CmbIsActiveVAT.Name = "CmbIsActiveVAT"
        Me.CmbIsActiveVAT.Size = New System.Drawing.Size(114, 21)
        Me.CmbIsActiveVAT.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Active"
        '
        'DgVat
        '
        Me.DgVat.AllowUserToAddRows = False
        Me.DgVat.AllowUserToDeleteRows = False
        Me.DgVat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgVat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Vat_Code, Me.Vat_Description, Me.Vat_IsActive})
        Me.DgVat.Location = New System.Drawing.Point(11, 121)
        Me.DgVat.Name = "DgVat"
        Me.DgVat.ReadOnly = True
        Me.DgVat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgVat.Size = New System.Drawing.Size(631, 229)
        Me.DgVat.TabIndex = 13
        '
        'Vat_Code
        '
        Me.Vat_Code.DataPropertyName = "Vat_Code"
        Me.Vat_Code.HeaderText = "VAT Code"
        Me.Vat_Code.Name = "Vat_Code"
        Me.Vat_Code.ReadOnly = True
        '
        'Vat_Description
        '
        Me.Vat_Description.DataPropertyName = "Vat_Description"
        Me.Vat_Description.HeaderText = "Description"
        Me.Vat_Description.Name = "Vat_Description"
        Me.Vat_Description.ReadOnly = True
        Me.Vat_Description.Width = 300
        '
        'Vat_IsActive
        '
        Me.Vat_IsActive.DataPropertyName = "Vat_IsActive"
        Me.Vat_IsActive.HeaderText = "Is Active"
        Me.Vat_IsActive.Name = "Vat_IsActive"
        Me.Vat_IsActive.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnDelete)
        Me.GroupBox1.Controls.Add(Me.BtnSave)
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 107)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Location = New System.Drawing.Point(13, 71)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(54, 23)
        Me.BtnDelete.TabIndex = 13
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(13, 42)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(54, 23)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(13, 13)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(54, 23)
        Me.BtnNew.TabIndex = 10
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(97, 33)
        Me.TxtDescription.MaxLength = 30
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(211, 20)
        Me.TxtDescription.TabIndex = 9
        '
        'TxtVatCode
        '
        Me.TxtVatCode.BackColor = System.Drawing.SystemColors.Info
        Me.TxtVatCode.Location = New System.Drawing.Point(98, 14)
        Me.TxtVatCode.MaxLength = 3
        Me.TxtVatCode.Name = "TxtVatCode"
        Me.TxtVatCode.Size = New System.Drawing.Size(113, 20)
        Me.TxtVatCode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VAT Code"
        '
        'TabVatRates
        '
        Me.TabVatRates.Controls.Add(Me.CmbISActiveVATRates)
        Me.TabVatRates.Controls.Add(Me.Label5)
        Me.TabVatRates.Controls.Add(Me.TxtVatRate)
        Me.TabVatRates.Controls.Add(Me.Label4)
        Me.TabVatRates.Controls.Add(Me.GroupBox3)
        Me.TabVatRates.Controls.Add(Me.DgVatRates)
        Me.TabVatRates.Controls.Add(Me.CmbVatCode)
        Me.TabVatRates.Controls.Add(Me.DtpCreatedDate)
        Me.TabVatRates.Controls.Add(Me.DtpEffectiveDate)
        Me.TabVatRates.Controls.Add(Me.DtpAmendDate)
        Me.TabVatRates.Controls.Add(Me.TxtCreatedBy)
        Me.TabVatRates.Controls.Add(Me.TxtAmendBy)
        Me.TabVatRates.Controls.Add(Me.Label12)
        Me.TabVatRates.Controls.Add(Me.Label11)
        Me.TabVatRates.Controls.Add(Me.Label10)
        Me.TabVatRates.Controls.Add(Me.Label9)
        Me.TabVatRates.Controls.Add(Me.Label8)
        Me.TabVatRates.Controls.Add(Me.Label6)
        Me.TabVatRates.Location = New System.Drawing.Point(4, 22)
        Me.TabVatRates.Name = "TabVatRates"
        Me.TabVatRates.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVatRates.Size = New System.Drawing.Size(653, 356)
        Me.TabVatRates.TabIndex = 1
        Me.TabVatRates.Text = "VAT Rates"
        Me.TabVatRates.UseVisualStyleBackColor = True
        '
        'CmbISActiveVATRates
        '
        Me.CmbISActiveVATRates.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem
        Me.CmbISActiveVATRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbISActiveVATRates.FormattingEnabled = True
        Me.CmbISActiveVATRates.Items.AddRange(New Object() {"A - Active", "I - InActive"})
        Me.CmbISActiveVATRates.Location = New System.Drawing.Point(98, 70)
        Me.CmbISActiveVATRates.Name = "CmbISActiveVATRates"
        Me.CmbISActiveVATRates.Size = New System.Drawing.Size(141, 21)
        Me.CmbISActiveVATRates.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Active"
        '
        'TxtVatRate
        '
        Me.TxtVatRate.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVatRate.Location = New System.Drawing.Point(98, 34)
        Me.TxtVatRate.MaxLength = 6
        Me.TxtVatRate.Name = "TxtVatRate"
        Me.TxtVatRate.Size = New System.Drawing.Size(141, 20)
        Me.TxtVatRate.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Rate"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnDelRates)
        Me.GroupBox3.Controls.Add(Me.BtnSaveRate)
        Me.GroupBox3.Controls.Add(Me.BtnNewRate)
        Me.GroupBox3.Location = New System.Drawing.Point(559, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(83, 107)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'BtnDelRates
        '
        Me.BtnDelRates.Enabled = False
        Me.BtnDelRates.Location = New System.Drawing.Point(13, 71)
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
        'DgVatRates
        '
        Me.DgVatRates.AllowUserToAddRows = False
        Me.DgVatRates.AllowUserToDeleteRows = False
        Me.DgVatRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgVatRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VatRte_id, Me.AmendBy, Me.CreatedBy, Me.Code, Me.VatRte_Rate, Me.VatRte_EffectiveDate, Me.VatRte_CreatedBy, Me.VatRte_CreationDate, Me.VatRte_AmendBy, Me.VatRte_AmendDate, Me.VatRte_IsActive})
        Me.DgVatRates.Location = New System.Drawing.Point(11, 121)
        Me.DgVatRates.Name = "DgVatRates"
        Me.DgVatRates.ReadOnly = True
        Me.DgVatRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgVatRates.Size = New System.Drawing.Size(631, 229)
        Me.DgVatRates.TabIndex = 14
        '
        'VatRte_id
        '
        Me.VatRte_id.DataPropertyName = "VatRte_id"
        Me.VatRte_id.HeaderText = "VatRte_id"
        Me.VatRte_id.Name = "VatRte_id"
        Me.VatRte_id.ReadOnly = True
        Me.VatRte_id.Visible = False
        Me.VatRte_id.Width = 75
        '
        'AmendBy
        '
        Me.AmendBy.DataPropertyName = "AmendBy"
        Me.AmendBy.HeaderText = "AmendBy"
        Me.AmendBy.Name = "AmendBy"
        Me.AmendBy.ReadOnly = True
        Me.AmendBy.Visible = False
        '
        'CreatedBy
        '
        Me.CreatedBy.DataPropertyName = "CreatedBy"
        Me.CreatedBy.HeaderText = "CreatedBy"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.ReadOnly = True
        Me.CreatedBy.Visible = False
        '
        'Code
        '
        Me.Code.DataPropertyName = "vat_Code"
        Me.Code.HeaderText = "VAT Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        Me.Code.Width = 85
        '
        'VatRte_Rate
        '
        Me.VatRte_Rate.DataPropertyName = "VatRte_Rate"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.VatRte_Rate.DefaultCellStyle = DataGridViewCellStyle5
        Me.VatRte_Rate.HeaderText = "VAT Rate"
        Me.VatRte_Rate.Name = "VatRte_Rate"
        Me.VatRte_Rate.ReadOnly = True
        '
        'VatRte_EffectiveDate
        '
        Me.VatRte_EffectiveDate.DataPropertyName = "VatRte_EffectiveDate"
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.VatRte_EffectiveDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.VatRte_EffectiveDate.HeaderText = "Effective Date"
        Me.VatRte_EffectiveDate.Name = "VatRte_EffectiveDate"
        Me.VatRte_EffectiveDate.ReadOnly = True
        '
        'VatRte_CreatedBy
        '
        Me.VatRte_CreatedBy.DataPropertyName = "VatRte_CreatedBy"
        Me.VatRte_CreatedBy.HeaderText = "Created By"
        Me.VatRte_CreatedBy.Name = "VatRte_CreatedBy"
        Me.VatRte_CreatedBy.ReadOnly = True
        Me.VatRte_CreatedBy.Visible = False
        '
        'VatRte_CreationDate
        '
        Me.VatRte_CreationDate.DataPropertyName = "VatRte_CreationDate"
        DataGridViewCellStyle7.Format = "dd-MM-yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.VatRte_CreationDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.VatRte_CreationDate.HeaderText = "Creation Date"
        Me.VatRte_CreationDate.Name = "VatRte_CreationDate"
        Me.VatRte_CreationDate.ReadOnly = True
        '
        'VatRte_AmendBy
        '
        Me.VatRte_AmendBy.DataPropertyName = "VatRte_AmendBy"
        Me.VatRte_AmendBy.HeaderText = "VatRte_AmendBy"
        Me.VatRte_AmendBy.Name = "VatRte_AmendBy"
        Me.VatRte_AmendBy.ReadOnly = True
        Me.VatRte_AmendBy.Visible = False
        '
        'VatRte_AmendDate
        '
        Me.VatRte_AmendDate.DataPropertyName = "VatRte_AmendDate"
        DataGridViewCellStyle8.Format = "dd-MM-yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.VatRte_AmendDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.VatRte_AmendDate.HeaderText = "VatRte_AmendDate"
        Me.VatRte_AmendDate.Name = "VatRte_AmendDate"
        Me.VatRte_AmendDate.ReadOnly = True
        Me.VatRte_AmendDate.Visible = False
        '
        'VatRte_IsActive
        '
        Me.VatRte_IsActive.DataPropertyName = "VatRte_IsActive"
        Me.VatRte_IsActive.HeaderText = "Is Active"
        Me.VatRte_IsActive.Name = "VatRte_IsActive"
        Me.VatRte_IsActive.ReadOnly = True
        Me.VatRte_IsActive.Width = 75
        '
        'CmbVatCode
        '
        Me.CmbVatCode.BackColor = System.Drawing.SystemColors.Window
        Me.CmbVatCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVatCode.FormattingEnabled = True
        Me.CmbVatCode.Location = New System.Drawing.Point(98, 14)
        Me.CmbVatCode.Name = "CmbVatCode"
        Me.CmbVatCode.Size = New System.Drawing.Size(141, 21)
        Me.CmbVatCode.TabIndex = 13
        '
        'DtpCreatedDate
        '
        Me.DtpCreatedDate.Enabled = False
        Me.DtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpCreatedDate.Location = New System.Drawing.Point(328, 34)
        Me.DtpCreatedDate.Name = "DtpCreatedDate"
        Me.DtpCreatedDate.Size = New System.Drawing.Size(225, 20)
        Me.DtpCreatedDate.TabIndex = 12
        '
        'DtpEffectiveDate
        '
        Me.DtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpEffectiveDate.Location = New System.Drawing.Point(98, 53)
        Me.DtpEffectiveDate.Name = "DtpEffectiveDate"
        Me.DtpEffectiveDate.Size = New System.Drawing.Size(141, 20)
        Me.DtpEffectiveDate.TabIndex = 11
        '
        'DtpAmendDate
        '
        Me.DtpAmendDate.Enabled = False
        Me.DtpAmendDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpAmendDate.Location = New System.Drawing.Point(328, 72)
        Me.DtpAmendDate.Name = "DtpAmendDate"
        Me.DtpAmendDate.Size = New System.Drawing.Size(225, 20)
        Me.DtpAmendDate.TabIndex = 10
        '
        'TxtCreatedBy
        '
        Me.TxtCreatedBy.BackColor = System.Drawing.SystemColors.Info
        Me.TxtCreatedBy.Location = New System.Drawing.Point(328, 15)
        Me.TxtCreatedBy.Name = "TxtCreatedBy"
        Me.TxtCreatedBy.ReadOnly = True
        Me.TxtCreatedBy.Size = New System.Drawing.Size(225, 20)
        Me.TxtCreatedBy.TabIndex = 9
        '
        'TxtAmendBy
        '
        Me.TxtAmendBy.BackColor = System.Drawing.SystemColors.Info
        Me.TxtAmendBy.Location = New System.Drawing.Point(328, 53)
        Me.TxtAmendBy.Name = "TxtAmendBy"
        Me.TxtAmendBy.ReadOnly = True
        Me.TxtAmendBy.Size = New System.Drawing.Size(225, 20)
        Me.TxtAmendBy.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(252, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Amend Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(252, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Amend By"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(251, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Creation Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(251, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Created By"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Effective Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "VAT Code"
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
        'FrmVat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(667, 385)
        Me.Controls.Add(Me.TbcVat)
        Me.Name = "FrmVat"
        Me.Text = "VAT Maintenance"
        Me.TbcVat.ResumeLayout(False)
        Me.TabVat.ResumeLayout(False)
        Me.TabVat.PerformLayout()
        CType(Me.DgVat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabVatRates.ResumeLayout(False)
        Me.TabVatRates.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DgVatRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbcVat As System.Windows.Forms.TabControl
    Friend WithEvents TabVat As System.Windows.Forms.TabPage
    Friend WithEvents DgVat As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtVatCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabVatRates As System.Windows.Forms.TabPage
    Friend WithEvents TxtVatRate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelRates As System.Windows.Forms.Button
    Friend WithEvents BtnSaveRate As System.Windows.Forms.Button
    Friend WithEvents BtnNewRate As System.Windows.Forms.Button
    Friend WithEvents DgVatRates As System.Windows.Forms.DataGridView
    Friend WithEvents CmbVatCode As System.Windows.Forms.ComboBox
    Friend WithEvents DtpCreatedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpAmendDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents TxtAmendBy As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er3 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CmbIsActiveVAT As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbISActiveVATRates As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ErrRate As System.Windows.Forms.ErrorProvider
    Friend WithEvents Vat_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vat_Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vat_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_EffectiveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_AmendBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VatRte_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
