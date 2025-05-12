<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJournal
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
        Me.TbcJournal = New System.Windows.Forms.TabControl
        Me.TabJournalType = New System.Windows.Forms.TabPage
        Me.CmbStatusType = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DgJournalType = New System.Windows.Forms.DataGridView
        Me.JouTyp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouTyp_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouTyp_Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.TxtDescriptionTyp = New System.Windows.Forms.TextBox
        Me.TxtTypeCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabJournalCode = New System.Windows.Forms.TabPage
        Me.txtTypCodDesc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtStartNo = New System.Windows.Forms.TextBox
        Me.TxtCurrentNo = New System.Windows.Forms.TextBox
        Me.TxtLength = New System.Windows.Forms.TextBox
        Me.TxtCodeDesc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbStatusCode = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnDelCode = New System.Windows.Forms.Button
        Me.BtnSaveCode = New System.Windows.Forms.Button
        Me.BtnNewCode = New System.Windows.Forms.Button
        Me.DgJournalCode = New System.Windows.Forms.DataGridView
        Me.JouCod_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouCod_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouTyp_Cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouCod_JouNoStart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouCod_JouNoCurrent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouCod_Length = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JouCod_Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmbTypeCode = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er3 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er4 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er5 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er6 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Er7 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TbcJournal.SuspendLayout()
        Me.TabJournalType.SuspendLayout()
        CType(Me.DgJournalType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabJournalCode.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgJournalCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbcJournal
        '
        Me.TbcJournal.Controls.Add(Me.TabJournalType)
        Me.TbcJournal.Controls.Add(Me.TabJournalCode)
        Me.TbcJournal.Location = New System.Drawing.Point(3, 1)
        Me.TbcJournal.Name = "TbcJournal"
        Me.TbcJournal.SelectedIndex = 0
        Me.TbcJournal.Size = New System.Drawing.Size(661, 382)
        Me.TbcJournal.TabIndex = 3
        '
        'TabJournalType
        '
        Me.TabJournalType.Controls.Add(Me.CmbStatusType)
        Me.TabJournalType.Controls.Add(Me.Label7)
        Me.TabJournalType.Controls.Add(Me.DgJournalType)
        Me.TabJournalType.Controls.Add(Me.GroupBox1)
        Me.TabJournalType.Controls.Add(Me.TxtDescriptionTyp)
        Me.TabJournalType.Controls.Add(Me.TxtTypeCode)
        Me.TabJournalType.Controls.Add(Me.Label3)
        Me.TabJournalType.Controls.Add(Me.Label1)
        Me.TabJournalType.Location = New System.Drawing.Point(4, 22)
        Me.TabJournalType.Name = "TabJournalType"
        Me.TabJournalType.Padding = New System.Windows.Forms.Padding(3)
        Me.TabJournalType.Size = New System.Drawing.Size(653, 356)
        Me.TabJournalType.TabIndex = 0
        Me.TabJournalType.Text = "Journal Type"
        Me.TabJournalType.UseVisualStyleBackColor = True
        '
        'CmbStatusType
        '
        Me.CmbStatusType.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem
        Me.CmbStatusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatusType.FormattingEnabled = True
        Me.CmbStatusType.Items.AddRange(New Object() {"A - Active", "I - InActive"})
        Me.CmbStatusType.Location = New System.Drawing.Point(101, 52)
        Me.CmbStatusType.Name = "CmbStatusType"
        Me.CmbStatusType.Size = New System.Drawing.Size(114, 21)
        Me.CmbStatusType.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Status"
        '
        'DgJournalType
        '
        Me.DgJournalType.AllowUserToAddRows = False
        Me.DgJournalType.AllowUserToDeleteRows = False
        Me.DgJournalType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgJournalType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JouTyp_Code, Me.JouTyp_Desc, Me.JouTyp_Status})
        Me.DgJournalType.Location = New System.Drawing.Point(11, 121)
        Me.DgJournalType.Name = "DgJournalType"
        Me.DgJournalType.ReadOnly = True
        Me.DgJournalType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgJournalType.Size = New System.Drawing.Size(631, 229)
        Me.DgJournalType.TabIndex = 13
        '
        'JouTyp_Code
        '
        Me.JouTyp_Code.DataPropertyName = "JouTyp_Code"
        Me.JouTyp_Code.HeaderText = "Type Code"
        Me.JouTyp_Code.Name = "JouTyp_Code"
        Me.JouTyp_Code.ReadOnly = True
        '
        'JouTyp_Desc
        '
        Me.JouTyp_Desc.DataPropertyName = "JouTyp_Desc"
        Me.JouTyp_Desc.HeaderText = "Description"
        Me.JouTyp_Desc.Name = "JouTyp_Desc"
        Me.JouTyp_Desc.ReadOnly = True
        Me.JouTyp_Desc.Width = 250
        '
        'JouTyp_Status
        '
        Me.JouTyp_Status.DataPropertyName = "JouTyp_Status"
        Me.JouTyp_Status.HeaderText = "Status"
        Me.JouTyp_Status.Name = "JouTyp_Status"
        Me.JouTyp_Status.ReadOnly = True
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
        'TxtDescriptionTyp
        '
        Me.TxtDescriptionTyp.Location = New System.Drawing.Point(101, 33)
        Me.TxtDescriptionTyp.MaxLength = 40
        Me.TxtDescriptionTyp.Name = "TxtDescriptionTyp"
        Me.TxtDescriptionTyp.Size = New System.Drawing.Size(211, 20)
        Me.TxtDescriptionTyp.TabIndex = 9
        '
        'TxtTypeCode
        '
        Me.TxtTypeCode.BackColor = System.Drawing.SystemColors.Info
        Me.TxtTypeCode.Location = New System.Drawing.Point(101, 12)
        Me.TxtTypeCode.MaxLength = 3
        Me.TxtTypeCode.Name = "TxtTypeCode"
        Me.TxtTypeCode.Size = New System.Drawing.Size(113, 20)
        Me.TxtTypeCode.TabIndex = 6
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
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type Code"
        '
        'TabJournalCode
        '
        Me.TabJournalCode.Controls.Add(Me.txtTypCodDesc)
        Me.TabJournalCode.Controls.Add(Me.Label11)
        Me.TabJournalCode.Controls.Add(Me.Label10)
        Me.TabJournalCode.Controls.Add(Me.Label9)
        Me.TabJournalCode.Controls.Add(Me.Label8)
        Me.TabJournalCode.Controls.Add(Me.TxtStartNo)
        Me.TabJournalCode.Controls.Add(Me.TxtCurrentNo)
        Me.TabJournalCode.Controls.Add(Me.TxtLength)
        Me.TabJournalCode.Controls.Add(Me.TxtCodeDesc)
        Me.TabJournalCode.Controls.Add(Me.Label2)
        Me.TabJournalCode.Controls.Add(Me.CmbStatusCode)
        Me.TabJournalCode.Controls.Add(Me.Label5)
        Me.TabJournalCode.Controls.Add(Me.TxtCode)
        Me.TabJournalCode.Controls.Add(Me.Label4)
        Me.TabJournalCode.Controls.Add(Me.GroupBox3)
        Me.TabJournalCode.Controls.Add(Me.DgJournalCode)
        Me.TabJournalCode.Controls.Add(Me.CmbTypeCode)
        Me.TabJournalCode.Controls.Add(Me.Label6)
        Me.TabJournalCode.Location = New System.Drawing.Point(4, 22)
        Me.TabJournalCode.Name = "TabJournalCode"
        Me.TabJournalCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TabJournalCode.Size = New System.Drawing.Size(653, 356)
        Me.TabJournalCode.TabIndex = 1
        Me.TabJournalCode.Text = "Journal code"
        Me.TabJournalCode.UseVisualStyleBackColor = True
        '
        'txtTypCodDesc
        '
        Me.txtTypCodDesc.Location = New System.Drawing.Point(101, 99)
        Me.txtTypCodDesc.MaxLength = 40
        Me.txtTypCodDesc.Name = "txtTypCodDesc"
        Me.txtTypCodDesc.Size = New System.Drawing.Size(227, 20)
        Me.txtTypCodDesc.TabIndex = 75
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Type Cod Desc"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(338, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Start NO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(338, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Current NO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(338, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Length"
        '
        'TxtStartNo
        '
        Me.TxtStartNo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtStartNo.Location = New System.Drawing.Point(399, 12)
        Me.TxtStartNo.MaxLength = 9
        Me.TxtStartNo.Name = "TxtStartNo"
        Me.TxtStartNo.Size = New System.Drawing.Size(141, 20)
        Me.TxtStartNo.TabIndex = 70
        '
        'TxtCurrentNo
        '
        Me.TxtCurrentNo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCurrentNo.Location = New System.Drawing.Point(399, 31)
        Me.TxtCurrentNo.MaxLength = 9
        Me.TxtCurrentNo.Name = "TxtCurrentNo"
        Me.TxtCurrentNo.Size = New System.Drawing.Size(141, 20)
        Me.TxtCurrentNo.TabIndex = 69
        '
        'TxtLength
        '
        Me.TxtLength.BackColor = System.Drawing.SystemColors.Window
        Me.TxtLength.Location = New System.Drawing.Point(399, 51)
        Me.TxtLength.MaxLength = 9
        Me.TxtLength.Name = "TxtLength"
        Me.TxtLength.Size = New System.Drawing.Size(141, 20)
        Me.TxtLength.TabIndex = 68
        '
        'TxtCodeDesc
        '
        Me.TxtCodeDesc.Location = New System.Drawing.Point(101, 34)
        Me.TxtCodeDesc.MaxLength = 40
        Me.TxtCodeDesc.Name = "TxtCodeDesc"
        Me.TxtCodeDesc.Size = New System.Drawing.Size(227, 20)
        Me.TxtCodeDesc.TabIndex = 67
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Description"
        '
        'CmbStatusCode
        '
        Me.CmbStatusCode.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem
        Me.CmbStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatusCode.FormattingEnabled = True
        Me.CmbStatusCode.Items.AddRange(New Object() {"A - Active", "I - InActive"})
        Me.CmbStatusCode.Location = New System.Drawing.Point(101, 55)
        Me.CmbStatusCode.Name = "CmbStatusCode"
        Me.CmbStatusCode.Size = New System.Drawing.Size(141, 21)
        Me.CmbStatusCode.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Status"
        '
        'TxtCode
        '
        Me.TxtCode.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCode.Location = New System.Drawing.Point(101, 12)
        Me.TxtCode.MaxLength = 8
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(141, 20)
        Me.TxtCode.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Type Code"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnDelCode)
        Me.GroupBox3.Controls.Add(Me.BtnSaveCode)
        Me.GroupBox3.Controls.Add(Me.BtnNewCode)
        Me.GroupBox3.Location = New System.Drawing.Point(559, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(83, 107)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'BtnDelCode
        '
        Me.BtnDelCode.Enabled = False
        Me.BtnDelCode.Location = New System.Drawing.Point(13, 71)
        Me.BtnDelCode.Name = "BtnDelCode"
        Me.BtnDelCode.Size = New System.Drawing.Size(54, 23)
        Me.BtnDelCode.TabIndex = 13
        Me.BtnDelCode.Text = "Delete"
        Me.BtnDelCode.UseVisualStyleBackColor = True
        '
        'BtnSaveCode
        '
        Me.BtnSaveCode.Location = New System.Drawing.Point(13, 42)
        Me.BtnSaveCode.Name = "BtnSaveCode"
        Me.BtnSaveCode.Size = New System.Drawing.Size(54, 23)
        Me.BtnSaveCode.TabIndex = 11
        Me.BtnSaveCode.Text = "Save"
        Me.BtnSaveCode.UseVisualStyleBackColor = True
        '
        'BtnNewCode
        '
        Me.BtnNewCode.Location = New System.Drawing.Point(13, 13)
        Me.BtnNewCode.Name = "BtnNewCode"
        Me.BtnNewCode.Size = New System.Drawing.Size(54, 23)
        Me.BtnNewCode.TabIndex = 10
        Me.BtnNewCode.Text = "New"
        Me.BtnNewCode.UseVisualStyleBackColor = True
        '
        'DgJournalCode
        '
        Me.DgJournalCode.AllowUserToAddRows = False
        Me.DgJournalCode.AllowUserToDeleteRows = False
        Me.DgJournalCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgJournalCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JouCod_Code, Me.JouCod_Desc, Me.JouTyp_Cod, Me.JouCod_JouNoStart, Me.JouCod_JouNoCurrent, Me.JouCod_Length, Me.JouCod_Status})
        Me.DgJournalCode.Location = New System.Drawing.Point(11, 131)
        Me.DgJournalCode.Name = "DgJournalCode"
        Me.DgJournalCode.ReadOnly = True
        Me.DgJournalCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgJournalCode.Size = New System.Drawing.Size(631, 219)
        Me.DgJournalCode.TabIndex = 14
        '
        'JouCod_Code
        '
        Me.JouCod_Code.DataPropertyName = "JouCod_Code"
        Me.JouCod_Code.HeaderText = "Code"
        Me.JouCod_Code.Name = "JouCod_Code"
        Me.JouCod_Code.ReadOnly = True
        Me.JouCod_Code.Width = 75
        '
        'JouCod_Desc
        '
        Me.JouCod_Desc.DataPropertyName = "JouCod_Desc"
        Me.JouCod_Desc.HeaderText = "Description"
        Me.JouCod_Desc.Name = "JouCod_Desc"
        Me.JouCod_Desc.ReadOnly = True
        Me.JouCod_Desc.Width = 300
        '
        'JouTyp_Cod
        '
        Me.JouTyp_Cod.DataPropertyName = "JouTyp_Code"
        Me.JouTyp_Cod.HeaderText = "Type Code"
        Me.JouTyp_Cod.Name = "JouTyp_Cod"
        Me.JouTyp_Cod.ReadOnly = True
        Me.JouTyp_Cod.Width = 90
        '
        'JouCod_JouNoStart
        '
        Me.JouCod_JouNoStart.DataPropertyName = "JouCod_JouNoStart"
        Me.JouCod_JouNoStart.HeaderText = "Start NO"
        Me.JouCod_JouNoStart.Name = "JouCod_JouNoStart"
        Me.JouCod_JouNoStart.ReadOnly = True
        Me.JouCod_JouNoStart.Visible = False
        '
        'JouCod_JouNoCurrent
        '
        Me.JouCod_JouNoCurrent.DataPropertyName = "JouCod_JouNoCurrent"
        Me.JouCod_JouNoCurrent.HeaderText = "Current NO"
        Me.JouCod_JouNoCurrent.Name = "JouCod_JouNoCurrent"
        Me.JouCod_JouNoCurrent.ReadOnly = True
        Me.JouCod_JouNoCurrent.Visible = False
        '
        'JouCod_Length
        '
        Me.JouCod_Length.DataPropertyName = "JouCod_Length"
        Me.JouCod_Length.HeaderText = "Length"
        Me.JouCod_Length.Name = "JouCod_Length"
        Me.JouCod_Length.ReadOnly = True
        Me.JouCod_Length.Visible = False
        '
        'JouCod_Status
        '
        Me.JouCod_Status.DataPropertyName = "JouCod_Status"
        Me.JouCod_Status.HeaderText = "Status"
        Me.JouCod_Status.Name = "JouCod_Status"
        Me.JouCod_Status.ReadOnly = True
        Me.JouCod_Status.Width = 75
        '
        'CmbTypeCode
        '
        Me.CmbTypeCode.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTypeCode.FormattingEnabled = True
        Me.CmbTypeCode.Location = New System.Drawing.Point(101, 77)
        Me.CmbTypeCode.Name = "CmbTypeCode"
        Me.CmbTypeCode.Size = New System.Drawing.Size(141, 21)
        Me.CmbTypeCode.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Code"
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
        'Er4
        '
        Me.Er4.ContainerControl = Me
        '
        'Er5
        '
        Me.Er5.ContainerControl = Me
        '
        'Er6
        '
        Me.Er6.ContainerControl = Me
        '
        'Er7
        '
        Me.Er7.ContainerControl = Me
        '
        'FrmJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(667, 385)
        Me.Controls.Add(Me.TbcJournal)
        Me.Name = "FrmJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Maintenance"
        Me.TbcJournal.ResumeLayout(False)
        Me.TabJournalType.ResumeLayout(False)
        Me.TabJournalType.PerformLayout()
        CType(Me.DgJournalType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabJournalCode.ResumeLayout(False)
        Me.TabJournalCode.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DgJournalCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbcJournal As System.Windows.Forms.TabControl
    Friend WithEvents TabJournalType As System.Windows.Forms.TabPage
    Friend WithEvents CmbStatusType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DgJournalType As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents TxtDescriptionTyp As System.Windows.Forms.TextBox
    Friend WithEvents TxtTypeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabJournalCode As System.Windows.Forms.TabPage
    Friend WithEvents CmbStatusCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelCode As System.Windows.Forms.Button
    Friend WithEvents BtnSaveCode As System.Windows.Forms.Button
    Friend WithEvents BtnNewCode As System.Windows.Forms.Button
    Friend WithEvents DgJournalCode As System.Windows.Forms.DataGridView
    Friend WithEvents CmbTypeCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtStartNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtCurrentNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtLength As System.Windows.Forms.TextBox
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er3 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er4 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er5 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er6 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Er7 As System.Windows.Forms.ErrorProvider
    Friend WithEvents JouTyp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouTyp_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouTyp_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouTyp_Cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_JouNoStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_JouNoCurrent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JouCod_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTypCodDesc As System.Windows.Forms.TextBox
End Class
