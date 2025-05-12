<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLociiExport
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
        Me.CBShowAllYears = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbPeriodGroups = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbPeriod = New System.Windows.Forms.ComboBox
        Me.BtnExport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CBShowAllYears
        '
        Me.CBShowAllYears.AutoSize = True
        Me.CBShowAllYears.Location = New System.Drawing.Point(401, 18)
        Me.CBShowAllYears.Name = "CBShowAllYears"
        Me.CBShowAllYears.Size = New System.Drawing.Size(105, 17)
        Me.CBShowAllYears.TabIndex = 120
        Me.CBShowAllYears.Text = "Show ALL Years"
        Me.CBShowAllYears.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(128, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(267, 20)
        Me.TextBox1.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Period Groups"
        '
        'cmbPeriodGroups
        '
        Me.cmbPeriodGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodGroups.FormattingEnabled = True
        Me.cmbPeriodGroups.Location = New System.Drawing.Point(128, 16)
        Me.cmbPeriodGroups.Name = "cmbPeriodGroups"
        Me.cmbPeriodGroups.Size = New System.Drawing.Size(267, 21)
        Me.cmbPeriodGroups.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Period From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Template Group"
        '
        'CmbPeriod
        '
        Me.CmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeriod.FormattingEnabled = True
        Me.CmbPeriod.Location = New System.Drawing.Point(128, 58)
        Me.CmbPeriod.Name = "CmbPeriod"
        Me.CmbPeriod.Size = New System.Drawing.Size(267, 21)
        Me.CmbPeriod.TabIndex = 112
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(128, 128)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(267, 23)
        Me.BtnExport.TabIndex = 121
        Me.BtnExport.Text = "Create Export File"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'FrmLociiExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 194)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.CBShowAllYears)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPeriodGroups)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbPeriod)
        Me.Name = "FrmLociiExport"
        Me.Text = "Export to Locii"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBShowAllYears As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodGroups As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents BtnExport As System.Windows.Forms.Button
End Class
