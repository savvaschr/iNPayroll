<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrTxNavisionTimesheets
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSBSend = New System.Windows.Forms.ToolStripButton
        Me.CmbPeriod = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblStatus = New System.Windows.Forms.Label
        Me.DatePosting = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSend})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(481, 25)
        Me.ToolStrip1.TabIndex = 67
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBSend
        '
        Me.TSBSend.AutoSize = False
        Me.TSBSend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSend.Name = "TSBSend"
        Me.TSBSend.Size = New System.Drawing.Size(100, 22)
        Me.TSBSend.Text = "Send To Navision"
        Me.TSBSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbPeriod
        '
        Me.CmbPeriod.FormattingEnabled = True
        Me.CmbPeriod.Location = New System.Drawing.Point(131, 43)
        Me.CmbPeriod.Name = "CmbPeriod"
        Me.CmbPeriod.Size = New System.Drawing.Size(219, 21)
        Me.CmbPeriod.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Periods"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Location = New System.Drawing.Point(12, 103)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 13)
        Me.LblStatus.TabIndex = 70
        '
        'DatePosting
        '
        Me.DatePosting.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePosting.Location = New System.Drawing.Point(131, 70)
        Me.DatePosting.Name = "DatePosting"
        Me.DatePosting.Size = New System.Drawing.Size(219, 20)
        Me.DatePosting.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Navision Posting Date"
        '
        'FrmPrTxNavisionTimesheets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(481, 125)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DatePosting)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbPeriod)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmPrTxNavisionTimesheets"
        Me.Text = "Interface with Navision Timesheets"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBSend As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents DatePosting As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
