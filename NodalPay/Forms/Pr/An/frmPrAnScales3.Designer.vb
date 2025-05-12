<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrAnScales3
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
        Me.components = New System.ComponentModel.Container()
        Me.ErrSc3_Description = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblSc1_Description = New System.Windows.Forms.Label()
        Me.ErrSc3_Code = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblSc1_Code = New System.Windows.Forms.Label()
        Me.txtSc3_Code = New System.Windows.Forms.TextBox()
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton()
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton()
        Me.txtSc3_Description = New System.Windows.Forms.TextBox()
        Me.TSBSave = New System.Windows.Forms.ToolStripButton()
        Me.TS1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNew = New System.Windows.Forms.ToolStripButton()
        Me.TSC1 = New System.Windows.Forms.ToolStripContainer()
        Me.DG1 = New System.Windows.Forms.DataGridView()
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sspStatus = New System.Windows.Forms.StatusStrip()
        Me.dgcSc3_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcSc3_Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrSc3_Description, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrSc3_Code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS1.SuspendLayout()
        Me.TSC1.TopToolStripPanel.SuspendLayout()
        Me.TSC1.SuspendLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrSc3_Description
        '
        Me.ErrSc3_Description.ContainerControl = Me
        '
        'lblSc1_Description
        '
        Me.lblSc1_Description.AutoSize = True
        Me.lblSc1_Description.Location = New System.Drawing.Point(37, 60)
        Me.lblSc1_Description.Name = "lblSc1_Description"
        Me.lblSc1_Description.Size = New System.Drawing.Size(60, 13)
        Me.lblSc1_Description.TabIndex = 15
        Me.lblSc1_Description.Text = "Description"
        '
        'ErrSc3_Code
        '
        Me.ErrSc3_Code.ContainerControl = Me
        '
        'lblSc1_Code
        '
        Me.lblSc1_Code.AutoSize = True
        Me.lblSc1_Code.Location = New System.Drawing.Point(37, 40)
        Me.lblSc1_Code.Name = "lblSc1_Code"
        Me.lblSc1_Code.Size = New System.Drawing.Size(32, 13)
        Me.lblSc1_Code.TabIndex = 13
        Me.lblSc1_Code.Text = "Code"
        '
        'txtSc3_Code
        '
        Me.txtSc3_Code.Location = New System.Drawing.Point(157, 40)
        Me.txtSc3_Code.MaxLength = 20
        Me.txtSc3_Code.Name = "txtSc3_Code"
        Me.txtSc3_Code.Size = New System.Drawing.Size(130, 20)
        Me.txtSc3_Code.TabIndex = 14
        '
        'TSBExcel
        '
        Me.TSBExcel.AutoSize = False
        Me.TSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(60, 22)
        Me.TSBExcel.Text = "Excel"
        Me.TSBExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBDelete
        '
        Me.TSBDelete.AutoSize = False
        Me.TSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(60, 22)
        Me.TSBDelete.Text = "Delete"
        Me.TSBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSc3_Description
        '
        Me.txtSc3_Description.Location = New System.Drawing.Point(157, 60)
        Me.txtSc3_Description.MaxLength = 100
        Me.txtSc3_Description.Name = "txtSc3_Description"
        Me.txtSc3_Description.Size = New System.Drawing.Size(610, 20)
        Me.txtSc3_Description.TabIndex = 16
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TS1
        '
        Me.TS1.Dock = System.Windows.Forms.DockStyle.None
        Me.TS1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel})
        Me.TS1.Location = New System.Drawing.Point(3, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(252, 25)
        Me.TS1.TabIndex = 0
        '
        'TSBNew
        '
        Me.TSBNew.AutoSize = False
        Me.TSBNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(60, 22)
        Me.TSBNew.Text = "New"
        Me.TSBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSC1
        '
        Me.TSC1.BottomToolStripPanelVisible = False
        '
        'TSC1.ContentPanel
        '
        Me.TSC1.ContentPanel.Size = New System.Drawing.Size(1100, 2)
        Me.TSC1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TSC1.LeftToolStripPanelVisible = False
        Me.TSC1.Location = New System.Drawing.Point(0, 0)
        Me.TSC1.Name = "TSC1"
        Me.TSC1.RightToolStripPanelVisible = False
        Me.TSC1.Size = New System.Drawing.Size(1100, 27)
        Me.TSC1.TabIndex = 19
        Me.TSC1.Text = "TSC1"
        '
        'TSC1.TopToolStripPanel
        '
        Me.TSC1.TopToolStripPanel.Controls.Add(Me.TS1)
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcSc3_Code, Me.dgcSc3_Description})
        Me.DG1.Location = New System.Drawing.Point(12, 106)
        Me.DG1.Name = "DG1"
        Me.DG1.ReadOnly = True
        Me.DG1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG1.Size = New System.Drawing.Size(1033, 442)
        Me.DG1.TabIndex = 18
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 578)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(1100, 22)
        Me.sspStatus.TabIndex = 17
        Me.sspStatus.Text = "StatusStrip"
        '
        'dgcSc3_Code
        '
        Me.dgcSc3_Code.DataPropertyName = "Sc3_Code"
        Me.dgcSc3_Code.FillWeight = 150.0!
        Me.dgcSc3_Code.HeaderText = "Code"
        Me.dgcSc3_Code.Name = "dgcSc3_Code"
        Me.dgcSc3_Code.ReadOnly = True
        Me.dgcSc3_Code.Width = 130
        '
        'dgcSc3_Description
        '
        Me.dgcSc3_Description.DataPropertyName = "Sc3_Description"
        Me.dgcSc3_Description.FillWeight = 150.0!
        Me.dgcSc3_Description.HeaderText = "Description"
        Me.dgcSc3_Description.Name = "dgcSc3_Description"
        Me.dgcSc3_Description.ReadOnly = True
        Me.dgcSc3_Description.Width = 610
        '
        'frmPrAnScales3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1100, 600)
        Me.Controls.Add(Me.lblSc1_Description)
        Me.Controls.Add(Me.lblSc1_Code)
        Me.Controls.Add(Me.txtSc3_Code)
        Me.Controls.Add(Me.txtSc3_Description)
        Me.Controls.Add(Me.TSC1)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.sspStatus)
        Me.Name = "frmPrAnScales3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPrAnScales3"
        CType(Me.ErrSc3_Description, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrSc3_Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.TSC1.TopToolStripPanel.ResumeLayout(False)
        Me.TSC1.TopToolStripPanel.PerformLayout()
        Me.TSC1.ResumeLayout(False)
        Me.TSC1.PerformLayout()
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ErrSc3_Description As ErrorProvider
    Friend WithEvents lblSc1_Description As Label
    Friend WithEvents lblSc1_Code As Label
    Friend WithEvents txtSc3_Code As TextBox
    Friend WithEvents txtSc3_Description As TextBox
    Friend WithEvents TSC1 As ToolStripContainer
    Friend WithEvents TS1 As ToolStrip
    Friend WithEvents TSBNew As ToolStripButton
    Friend WithEvents TSBSave As ToolStripButton
    Friend WithEvents TSBDelete As ToolStripButton
    Friend WithEvents TSBExcel As ToolStripButton
    Friend WithEvents DG1 As DataGridView
    Friend WithEvents sspStatus As StatusStrip
    Friend WithEvents lblSSStatus As ToolStripStatusLabel
    Friend WithEvents ErrSc3_Code As ErrorProvider
    Friend WithEvents dgcSc3_Code As DataGridViewTextBoxColumn
    Friend WithEvents dgcSc3_Description As DataGridViewTextBoxColumn
End Class
