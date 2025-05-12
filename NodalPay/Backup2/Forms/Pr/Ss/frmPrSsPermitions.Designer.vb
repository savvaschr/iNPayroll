<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrSsPermitions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrSsPermitions))
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Entity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullAccess = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReadOnlya = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoAccess = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TS1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(192, 25)
        Me.TS1.TabIndex = 1
        '
        'TSBNew
        '
        Me.TSBNew.AutoSize = False
        Me.TSBNew.Image = CType(resources.GetObject("TSBNew.Image"), System.Drawing.Image)
        Me.TSBNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(60, 22)
        Me.TSBNew.Text = "New"
        Me.TSBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.AllowUserToOrderColumns = True
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.CompanyCode, Me.UserCode, Me.Entity, Me.FullAccess, Me.ReadOnlya, Me.NoAccess})
        Me.DG1.Location = New System.Drawing.Point(12, 42)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(764, 535)
        Me.DG1.TabIndex = 2
        '
        'Id
        '
        Me.Id.DataPropertyName = "UsrAth_Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'CompanyCode
        '
        Me.CompanyCode.DataPropertyName = "Com_Code"
        Me.CompanyCode.HeaderText = "CompanyCode"
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.Visible = False
        '
        'UserCode
        '
        Me.UserCode.DataPropertyName = "Usr_Code"
        Me.UserCode.HeaderText = "UserCode"
        Me.UserCode.Name = "UserCode"
        '
        'Entity
        '
        Me.Entity.DataPropertyName = "UsrAth_entity"
        Me.Entity.HeaderText = "Entity"
        Me.Entity.Name = "Entity"
        Me.Entity.ReadOnly = True
        '
        'FullAccess
        '
        Me.FullAccess.DataPropertyName = "UsrAth_Full"
        Me.FullAccess.HeaderText = "Full Access"
        Me.FullAccess.Name = "FullAccess"
        '
        'ReadOnlya
        '
        Me.ReadOnlya.DataPropertyName = "UsrAth_ReadOnly"
        Me.ReadOnlya.HeaderText = "Read Only Access"
        Me.ReadOnlya.Name = "ReadOnlya"
        '
        'NoAccess
        '
        Me.NoAccess.DataPropertyName = "UsrAth_No"
        Me.NoAccess.HeaderText = "No Access"
        Me.NoAccess.Name = "NoAccess"
        '
        'frmPrSsPermitions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(788, 589)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.TS1)
        Me.Name = "frmPrSsPermitions"
        Me.Text = "User Permitions"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullAccess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReadOnlya As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoAccess As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
