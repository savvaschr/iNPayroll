<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompanyUsers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompanyUsers))
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblErnTypCode = New System.Windows.Forms.Label()
        Me.ComboUser = New System.Windows.Forms.ComboBox()
        Me.DG1 = New System.Windows.Forms.DataGridView()
        Me.dgcErnCod_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcErnCod_DescriptionL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcErnTyp_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TS1 = New System.Windows.Forms.ToolStrip()
        Me.TSBSave = New System.Windows.Forms.ToolStripButton()
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnUserPermitions = New System.Windows.Forms.ToolStripButton()
        Me.btnAddUserToAllCompanies = New System.Windows.Forms.ToolStripButton()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(17, 47)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(79, 13)
        Me.lblCode.TabIndex = 14
        Me.lblCode.Text = "Company Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(137, 47)
        Me.txtCode.MaxLength = 6
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(308, 20)
        Me.txtCode.TabIndex = 15
        '
        'lblErnTypCode
        '
        Me.lblErnTypCode.AutoSize = True
        Me.lblErnTypCode.Location = New System.Drawing.Point(17, 67)
        Me.lblErnTypCode.Name = "lblErnTypCode"
        Me.lblErnTypCode.Size = New System.Drawing.Size(29, 13)
        Me.lblErnTypCode.TabIndex = 16
        Me.lblErnTypCode.Text = "User"
        '
        'ComboUser
        '
        Me.ComboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUser.Location = New System.Drawing.Point(137, 67)
        Me.ComboUser.Name = "ComboUser"
        Me.ComboUser.Size = New System.Drawing.Size(308, 21)
        Me.ComboUser.TabIndex = 17
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcErnCod_Code, Me.dgcErnCod_DescriptionL, Me.dgcErnTyp_Code})
        Me.DG1.Location = New System.Drawing.Point(4, 144)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(835, 365)
        Me.DG1.TabIndex = 23
        '
        'dgcErnCod_Code
        '
        Me.dgcErnCod_Code.DataPropertyName = "Usr_UserName"
        Me.dgcErnCod_Code.FillWeight = 150.0!
        Me.dgcErnCod_Code.HeaderText = "User"
        Me.dgcErnCod_Code.Name = "dgcErnCod_Code"
        Me.dgcErnCod_Code.ReadOnly = True
        Me.dgcErnCod_Code.Width = 300
        '
        'dgcErnCod_DescriptionL
        '
        Me.dgcErnCod_DescriptionL.DataPropertyName = "Usr_FullName"
        Me.dgcErnCod_DescriptionL.FillWeight = 150.0!
        Me.dgcErnCod_DescriptionL.HeaderText = "Name"
        Me.dgcErnCod_DescriptionL.Name = "dgcErnCod_DescriptionL"
        Me.dgcErnCod_DescriptionL.ReadOnly = True
        Me.dgcErnCod_DescriptionL.Width = 300
        '
        'dgcErnTyp_Code
        '
        Me.dgcErnTyp_Code.DataPropertyName = "Com_Code"
        Me.dgcErnTyp_Code.FillWeight = 150.0!
        Me.dgcErnTyp_Code.HeaderText = "Company"
        Me.dgcErnTyp_Code.Name = "dgcErnTyp_Code"
        Me.dgcErnTyp_Code.ReadOnly = True
        Me.dgcErnTyp_Code.Visible = False
        '
        'TS1
        '
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSave, Me.TSBDelete, Me.btnUserPermitions, Me.btnAddUserToAllCompanies})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(851, 25)
        Me.TS1.TabIndex = 25
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.Image = CType(resources.GetObject("TSBSave.Image"), System.Drawing.Image)
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBDelete
        '
        Me.TSBDelete.AutoSize = False
        Me.TSBDelete.Image = CType(resources.GetObject("TSBDelete.Image"), System.Drawing.Image)
        Me.TSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(60, 22)
        Me.TSBDelete.Text = "Delete"
        Me.TSBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUserPermitions
        '
        Me.btnUserPermitions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnUserPermitions.Image = CType(resources.GetObject("btnUserPermitions.Image"), System.Drawing.Image)
        Me.btnUserPermitions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUserPermitions.Name = "btnUserPermitions"
        Me.btnUserPermitions.Size = New System.Drawing.Size(100, 22)
        Me.btnUserPermitions.Text = "User Permissions"
        '
        'btnAddUserToAllCompanies
        '
        Me.btnAddUserToAllCompanies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddUserToAllCompanies.Image = CType(resources.GetObject("btnAddUserToAllCompanies.Image"), System.Drawing.Image)
        Me.btnAddUserToAllCompanies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddUserToAllCompanies.Name = "btnAddUserToAllCompanies"
        Me.btnAddUserToAllCompanies.Size = New System.Drawing.Size(154, 22)
        Me.btnAddUserToAllCompanies.Text = "Add User To All Companies"
        '
        'FrmCompanyUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(851, 517)
        Me.Controls.Add(Me.TS1)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblErnTypCode)
        Me.Controls.Add(Me.ComboUser)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmCompanyUsers"
        Me.Text = "Company Users"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblErnTypCode As System.Windows.Forms.Label
    Friend WithEvents ComboUser As System.Windows.Forms.ComboBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgcErnCod_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcErnCod_DescriptionL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcErnTyp_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUserPermitions As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAddUserToAllCompanies As ToolStripButton
End Class
