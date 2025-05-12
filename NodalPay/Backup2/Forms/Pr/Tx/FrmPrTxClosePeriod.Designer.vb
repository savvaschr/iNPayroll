<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxClosePeriod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrTxClosePeriod))
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPeriodTo = New System.Windows.Forms.TextBox
        Me.txtPeriodFrom = New System.Windows.Forms.TextBox
        Me.txtPeriodDescription = New System.Windows.Forms.TextBox
        Me.txtPeriodCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboTempGroups = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBClose = New System.Windows.Forms.ToolStripButton
        Me.BtnPeriodNormalDays = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(536, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "-"
        '
        'txtPeriodTo
        '
        Me.txtPeriodTo.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodTo.Location = New System.Drawing.Point(552, 59)
        Me.txtPeriodTo.Name = "txtPeriodTo"
        Me.txtPeriodTo.ReadOnly = True
        Me.txtPeriodTo.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodTo.TabIndex = 34
        '
        'txtPeriodFrom
        '
        Me.txtPeriodFrom.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodFrom.Location = New System.Drawing.Point(450, 59)
        Me.txtPeriodFrom.Name = "txtPeriodFrom"
        Me.txtPeriodFrom.ReadOnly = True
        Me.txtPeriodFrom.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodFrom.TabIndex = 33
        '
        'txtPeriodDescription
        '
        Me.txtPeriodDescription.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodDescription.Location = New System.Drawing.Point(188, 59)
        Me.txtPeriodDescription.Name = "txtPeriodDescription"
        Me.txtPeriodDescription.ReadOnly = True
        Me.txtPeriodDescription.Size = New System.Drawing.Size(253, 20)
        Me.txtPeriodDescription.TabIndex = 32
        '
        'txtPeriodCode
        '
        Me.txtPeriodCode.BackColor = System.Drawing.SystemColors.Info
        Me.txtPeriodCode.Location = New System.Drawing.Point(96, 59)
        Me.txtPeriodCode.Name = "txtPeriodCode"
        Me.txtPeriodCode.ReadOnly = True
        Me.txtPeriodCode.Size = New System.Drawing.Size(86, 20)
        Me.txtPeriodCode.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Period"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Template Group"
        '
        'ComboTempGroups
        '
        Me.ComboTempGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTempGroups.FormattingEnabled = True
        Me.ComboTempGroups.Location = New System.Drawing.Point(96, 38)
        Me.ComboTempGroups.Name = "ComboTempGroups"
        Me.ComboTempGroups.Size = New System.Drawing.Size(345, 21)
        Me.ComboTempGroups.TabIndex = 28
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBClose, Me.BtnPeriodNormalDays, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(657, 25)
        Me.ToolStrip1.TabIndex = 66
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBClose
        '
        Me.TSBClose.AutoSize = False
        Me.TSBClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBClose.Name = "TSBClose"
        Me.TSBClose.Size = New System.Drawing.Size(60, 22)
        Me.TSBClose.Text = "Close"
        Me.TSBClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnPeriodNormalDays
        '
        Me.BtnPeriodNormalDays.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnPeriodNormalDays.Image = CType(resources.GetObject("BtnPeriodNormalDays.Image"), System.Drawing.Image)
        Me.BtnPeriodNormalDays.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPeriodNormalDays.Name = "BtnPeriodNormalDays"
        Me.BtnPeriodNormalDays.Size = New System.Drawing.Size(104, 22)
        Me.BtnPeriodNormalDays.Text = "Period Work Days"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(244, 22)
        Me.ToolStripButton1.Text = "Set Inactive Status to Terminated Employees"
        '
        'FrmPrTxClosePeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(657, 102)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPeriodTo)
        Me.Controls.Add(Me.txtPeriodFrom)
        Me.Controls.Add(Me.txtPeriodDescription)
        Me.Controls.Add(Me.txtPeriodCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTempGroups)
        Me.Name = "FrmPrTxClosePeriod"
        Me.Text = "Close Period"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodTo As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboTempGroups As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPeriodNormalDays As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
