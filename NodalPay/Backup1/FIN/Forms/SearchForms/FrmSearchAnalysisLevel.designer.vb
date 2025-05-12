<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchAnalysisLevel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button1 = New System.Windows.Forms.Button
        Me.DgAnal = New System.Windows.Forms.DataGridView
        Me.AccA21_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA21_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA21_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA21_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA21_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA21_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Act = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TxtDescriptionS = New System.Windows.Forms.TextBox
        Me.TxtCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DgLinesAnal = New System.Windows.Forms.DataGridView
        Me.AcLA21_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA21_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA21_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA21_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA21_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA21_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Active = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dg1AnalLevel3 = New System.Windows.Forms.DataGridView
        Me.AccA31_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA31_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA31_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA31_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA31_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccA31_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Activ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DgAnalLineLevel3 = New System.Windows.Forms.DataGridView
        Me.AcLA31_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA31_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA31_DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA31_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA31_AmendDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLA31_IsActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Activv = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DgAnal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgLinesAnal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dg1AnalLevel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgAnalLineLevel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(595, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DgAnal
        '
        Me.DgAnal.AllowUserToAddRows = False
        Me.DgAnal.AllowUserToDeleteRows = False
        Me.DgAnal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgAnal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccA21_Code, Me.Code, Me.AccA21_DescriptionL, Me.AccA21_DescriptionS, Me.AccA21_CreationDate, Me.AccA21_AmendDate, Me.AccA21_IsActive, Me.Act})
        Me.DgAnal.Location = New System.Drawing.Point(23, 65)
        Me.DgAnal.Name = "DgAnal"
        Me.DgAnal.ReadOnly = True
        Me.DgAnal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgAnal.Size = New System.Drawing.Size(645, 300)
        Me.DgAnal.TabIndex = 14
        '
        'AccA21_Code
        '
        Me.AccA21_Code.DataPropertyName = "AccA21_Code"
        Me.AccA21_Code.HeaderText = "Code"
        Me.AccA21_Code.Name = "AccA21_Code"
        Me.AccA21_Code.ReadOnly = True
        '
        'Code
        '
        Me.Code.DataPropertyName = "AccA31_Code"
        Me.Code.HeaderText = "Code Level3"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'AccA21_DescriptionL
        '
        Me.AccA21_DescriptionL.DataPropertyName = "AccA21_DescriptionL"
        Me.AccA21_DescriptionL.HeaderText = "DescriptionL"
        Me.AccA21_DescriptionL.Name = "AccA21_DescriptionL"
        Me.AccA21_DescriptionL.ReadOnly = True
        Me.AccA21_DescriptionL.Visible = False
        '
        'AccA21_DescriptionS
        '
        Me.AccA21_DescriptionS.DataPropertyName = "AccA21_DescriptionS"
        Me.AccA21_DescriptionS.HeaderText = "Description Short"
        Me.AccA21_DescriptionS.Name = "AccA21_DescriptionS"
        Me.AccA21_DescriptionS.ReadOnly = True
        Me.AccA21_DescriptionS.Width = 200
        '
        'AccA21_CreationDate
        '
        Me.AccA21_CreationDate.DataPropertyName = "AccA21_CreationDate"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.AccA21_CreationDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.AccA21_CreationDate.HeaderText = "Creation Date"
        Me.AccA21_CreationDate.Name = "AccA21_CreationDate"
        Me.AccA21_CreationDate.ReadOnly = True
        '
        'AccA21_AmendDate
        '
        Me.AccA21_AmendDate.DataPropertyName = "AccA21_AmendDate"
        DataGridViewCellStyle2.Format = "dd-MM-yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.AccA21_AmendDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.AccA21_AmendDate.HeaderText = "Amend Date"
        Me.AccA21_AmendDate.Name = "AccA21_AmendDate"
        Me.AccA21_AmendDate.ReadOnly = True
        '
        'AccA21_IsActive
        '
        Me.AccA21_IsActive.DataPropertyName = "AccA21_IsActive"
        Me.AccA21_IsActive.HeaderText = "Is Active"
        Me.AccA21_IsActive.Name = "AccA21_IsActive"
        Me.AccA21_IsActive.ReadOnly = True
        '
        'Act
        '
        Me.Act.HeaderText = "Is Active"
        Me.Act.Name = "Act"
        Me.Act.ReadOnly = True
        Me.Act.Visible = False
        '
        'TxtDescriptionS
        '
        Me.TxtDescriptionS.Location = New System.Drawing.Point(159, 31)
        Me.TxtDescriptionS.Name = "TxtDescriptionS"
        Me.TxtDescriptionS.Size = New System.Drawing.Size(184, 20)
        Me.TxtDescriptionS.TabIndex = 19
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(159, 11)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(184, 20)
        Me.TxtCode.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "DescriptionS"
        '
        'DgLinesAnal
        '
        Me.DgLinesAnal.AllowUserToAddRows = False
        Me.DgLinesAnal.AllowUserToDeleteRows = False
        Me.DgLinesAnal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgLinesAnal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AcLA21_Code, Me.DataGridViewTextBoxColumn1, Me.AcLA21_DescriptionL, Me.AcLA21_DescriptionS, Me.AcLA21_CreationDate, Me.AcLA21_AmendDate, Me.AcLA21_IsActive, Me.Active})
        Me.DgLinesAnal.Location = New System.Drawing.Point(23, 65)
        Me.DgLinesAnal.Name = "DgLinesAnal"
        Me.DgLinesAnal.ReadOnly = True
        Me.DgLinesAnal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLinesAnal.Size = New System.Drawing.Size(645, 300)
        Me.DgLinesAnal.TabIndex = 23
        '
        'AcLA21_Code
        '
        Me.AcLA21_Code.DataPropertyName = "AcLA21_Code"
        Me.AcLA21_Code.HeaderText = "Code"
        Me.AcLA21_Code.Name = "AcLA21_Code"
        Me.AcLA21_Code.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "AcLA31_Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code Level3"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'AcLA21_DescriptionL
        '
        Me.AcLA21_DescriptionL.DataPropertyName = "AcLA21_DescriptionL"
        Me.AcLA21_DescriptionL.HeaderText = "DescriptionL"
        Me.AcLA21_DescriptionL.Name = "AcLA21_DescriptionL"
        Me.AcLA21_DescriptionL.ReadOnly = True
        Me.AcLA21_DescriptionL.Visible = False
        '
        'AcLA21_DescriptionS
        '
        Me.AcLA21_DescriptionS.DataPropertyName = "AcLA21_DescriptionS"
        Me.AcLA21_DescriptionS.HeaderText = "Description Short"
        Me.AcLA21_DescriptionS.Name = "AcLA21_DescriptionS"
        Me.AcLA21_DescriptionS.ReadOnly = True
        Me.AcLA21_DescriptionS.Width = 200
        '
        'AcLA21_CreationDate
        '
        Me.AcLA21_CreationDate.DataPropertyName = "AcLA21_CreationDate"
        DataGridViewCellStyle3.Format = "dd-MM-yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.AcLA21_CreationDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.AcLA21_CreationDate.HeaderText = "Creation Date"
        Me.AcLA21_CreationDate.Name = "AcLA21_CreationDate"
        Me.AcLA21_CreationDate.ReadOnly = True
        '
        'AcLA21_AmendDate
        '
        Me.AcLA21_AmendDate.DataPropertyName = "AcLA21_AmendDate"
        DataGridViewCellStyle4.Format = "dd-MM-yyyy"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.AcLA21_AmendDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.AcLA21_AmendDate.HeaderText = "Amend Date"
        Me.AcLA21_AmendDate.Name = "AcLA21_AmendDate"
        Me.AcLA21_AmendDate.ReadOnly = True
        '
        'AcLA21_IsActive
        '
        Me.AcLA21_IsActive.DataPropertyName = "AcLA21_IsActive"
        Me.AcLA21_IsActive.HeaderText = "Is Active"
        Me.AcLA21_IsActive.Name = "AcLA21_IsActive"
        Me.AcLA21_IsActive.ReadOnly = True
        '
        'Active
        '
        Me.Active.HeaderText = "Is Active"
        Me.Active.Name = "Active"
        Me.Active.ReadOnly = True
        Me.Active.Visible = False
        '
        'Dg1AnalLevel3
        '
        Me.Dg1AnalLevel3.AllowUserToAddRows = False
        Me.Dg1AnalLevel3.AllowUserToDeleteRows = False
        Me.Dg1AnalLevel3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg1AnalLevel3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccA31_Code, Me.AccA31_DescriptionL, Me.AccA31_DescriptionS, Me.AccA31_CreationDate, Me.AccA31_AmendDate, Me.AccA31_IsActive, Me.Activ})
        Me.Dg1AnalLevel3.Location = New System.Drawing.Point(23, 65)
        Me.Dg1AnalLevel3.Name = "Dg1AnalLevel3"
        Me.Dg1AnalLevel3.ReadOnly = True
        Me.Dg1AnalLevel3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dg1AnalLevel3.Size = New System.Drawing.Size(645, 300)
        Me.Dg1AnalLevel3.TabIndex = 24
        '
        'AccA31_Code
        '
        Me.AccA31_Code.DataPropertyName = "AccA31_Code"
        Me.AccA31_Code.HeaderText = "Code"
        Me.AccA31_Code.Name = "AccA31_Code"
        Me.AccA31_Code.ReadOnly = True
        '
        'AccA31_DescriptionL
        '
        Me.AccA31_DescriptionL.DataPropertyName = "AccA31_DescriptionL"
        Me.AccA31_DescriptionL.HeaderText = "DescriptionL"
        Me.AccA31_DescriptionL.Name = "AccA31_DescriptionL"
        Me.AccA31_DescriptionL.ReadOnly = True
        Me.AccA31_DescriptionL.Visible = False
        '
        'AccA31_DescriptionS
        '
        Me.AccA31_DescriptionS.DataPropertyName = "AccA31_DescriptionS"
        Me.AccA31_DescriptionS.HeaderText = "Description Short"
        Me.AccA31_DescriptionS.Name = "AccA31_DescriptionS"
        Me.AccA31_DescriptionS.ReadOnly = True
        Me.AccA31_DescriptionS.Width = 200
        '
        'AccA31_CreationDate
        '
        Me.AccA31_CreationDate.DataPropertyName = "AccA31_CreationDate"
        DataGridViewCellStyle5.Format = "dd-MM-yyyy"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.AccA31_CreationDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.AccA31_CreationDate.HeaderText = "Creation Date"
        Me.AccA31_CreationDate.Name = "AccA31_CreationDate"
        Me.AccA31_CreationDate.ReadOnly = True
        '
        'AccA31_AmendDate
        '
        Me.AccA31_AmendDate.DataPropertyName = "AccA31_AmendDate"
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        Me.AccA31_AmendDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.AccA31_AmendDate.HeaderText = "Amend Date"
        Me.AccA31_AmendDate.Name = "AccA31_AmendDate"
        Me.AccA31_AmendDate.ReadOnly = True
        '
        'AccA31_IsActive
        '
        Me.AccA31_IsActive.DataPropertyName = "AccA31_IsActive"
        Me.AccA31_IsActive.HeaderText = "Is Active"
        Me.AccA31_IsActive.Name = "AccA31_IsActive"
        Me.AccA31_IsActive.ReadOnly = True
        '
        'Activ
        '
        Me.Activ.HeaderText = "Is Active"
        Me.Activ.Name = "Activ"
        Me.Activ.ReadOnly = True
        Me.Activ.Visible = False
        '
        'DgAnalLineLevel3
        '
        Me.DgAnalLineLevel3.AllowUserToAddRows = False
        Me.DgAnalLineLevel3.AllowUserToDeleteRows = False
        Me.DgAnalLineLevel3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgAnalLineLevel3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AcLA31_Code, Me.AcLA31_DescriptionL, Me.AcLA31_DescriptionS, Me.AcLA31_CreationDate, Me.AcLA31_AmendDate, Me.AcLA31_IsActive, Me.Activv})
        Me.DgAnalLineLevel3.Location = New System.Drawing.Point(23, 65)
        Me.DgAnalLineLevel3.Name = "DgAnalLineLevel3"
        Me.DgAnalLineLevel3.ReadOnly = True
        Me.DgAnalLineLevel3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgAnalLineLevel3.Size = New System.Drawing.Size(645, 300)
        Me.DgAnalLineLevel3.TabIndex = 25
        '
        'AcLA31_Code
        '
        Me.AcLA31_Code.DataPropertyName = "AcLA31_Code"
        Me.AcLA31_Code.HeaderText = "Code"
        Me.AcLA31_Code.Name = "AcLA31_Code"
        Me.AcLA31_Code.ReadOnly = True
        '
        'AcLA31_DescriptionL
        '
        Me.AcLA31_DescriptionL.DataPropertyName = "AcLA31_DescriptionL"
        Me.AcLA31_DescriptionL.HeaderText = "DescriptionL"
        Me.AcLA31_DescriptionL.Name = "AcLA31_DescriptionL"
        Me.AcLA31_DescriptionL.ReadOnly = True
        Me.AcLA31_DescriptionL.Visible = False
        '
        'AcLA31_DescriptionS
        '
        Me.AcLA31_DescriptionS.DataPropertyName = "AcLA31_DescriptionS"
        Me.AcLA31_DescriptionS.HeaderText = "Description Short"
        Me.AcLA31_DescriptionS.Name = "AcLA31_DescriptionS"
        Me.AcLA31_DescriptionS.ReadOnly = True
        Me.AcLA31_DescriptionS.Width = 200
        '
        'AcLA31_CreationDate
        '
        Me.AcLA31_CreationDate.DataPropertyName = "AcLA31_CreationDate"
        DataGridViewCellStyle7.Format = "dd-MM-yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.AcLA31_CreationDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.AcLA31_CreationDate.HeaderText = "Creation Date"
        Me.AcLA31_CreationDate.Name = "AcLA31_CreationDate"
        Me.AcLA31_CreationDate.ReadOnly = True
        '
        'AcLA31_AmendDate
        '
        Me.AcLA31_AmendDate.DataPropertyName = "AcLA31_AmendDate"
        DataGridViewCellStyle8.Format = "dd-MM-yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.AcLA31_AmendDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.AcLA31_AmendDate.HeaderText = "Amend Date"
        Me.AcLA31_AmendDate.Name = "AcLA31_AmendDate"
        Me.AcLA31_AmendDate.ReadOnly = True
        '
        'AcLA31_IsActive
        '
        Me.AcLA31_IsActive.DataPropertyName = "AcLA31_IsActive"
        Me.AcLA31_IsActive.HeaderText = "Is Active"
        Me.AcLA31_IsActive.Name = "AcLA31_IsActive"
        Me.AcLA31_IsActive.ReadOnly = True
        '
        'Activv
        '
        Me.Activv.HeaderText = "Is Active"
        Me.Activv.Name = "Activv"
        Me.Activv.ReadOnly = True
        Me.Activv.Visible = False
        '
        'FrmSearchAnalysisLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(691, 372)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.TxtDescriptionS)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DgAnalLineLevel3)
        Me.Controls.Add(Me.Dg1AnalLevel3)
        Me.Controls.Add(Me.DgLinesAnal)
        Me.Controls.Add(Me.DgAnal)
        Me.Name = "FrmSearchAnalysisLevel"
        Me.Text = "Levels Analysis Search"
        CType(Me.DgAnal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgLinesAnal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dg1AnalLevel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgAnalLineLevel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DgAnal As System.Windows.Forms.DataGridView
    Friend WithEvents TxtDescriptionS As System.Windows.Forms.TextBox
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgLinesAnal As System.Windows.Forms.DataGridView
    Friend WithEvents Dg1AnalLevel3 As System.Windows.Forms.DataGridView
    Friend WithEvents DgAnalLineLevel3 As System.Windows.Forms.DataGridView
    Friend WithEvents AcLA31_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA31_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA31_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA31_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA31_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA31_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA21_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Act As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLA21_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Active As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_DescriptionS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_AmendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccA31_IsActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activ As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
