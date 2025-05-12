<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferEDCCodeValueFromLines
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPeriodGroup = New System.Windows.Forms.TextBox
        Me.txtTempGroup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtToCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEDC = New System.Windows.Forms.ComboBox
        Me.txtFromCode = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.txtEDC = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(241, 135)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Period Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Template Group"
        '
        'txtPeriodGroup
        '
        Me.txtPeriodGroup.Location = New System.Drawing.Point(114, 32)
        Me.txtPeriodGroup.Name = "txtPeriodGroup"
        Me.txtPeriodGroup.ReadOnly = True
        Me.txtPeriodGroup.Size = New System.Drawing.Size(380, 20)
        Me.txtPeriodGroup.TabIndex = 19
        '
        'txtTempGroup
        '
        Me.txtTempGroup.Location = New System.Drawing.Point(114, 6)
        Me.txtTempGroup.Name = "txtTempGroup"
        Me.txtTempGroup.ReadOnly = True
        Me.txtTempGroup.Size = New System.Drawing.Size(380, 20)
        Me.txtTempGroup.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "To EDC Code"
        '
        'txtToCode
        '
        Me.txtToCode.Location = New System.Drawing.Point(114, 109)
        Me.txtToCode.Name = "txtToCode"
        Me.txtToCode.Size = New System.Drawing.Size(100, 20)
        Me.txtToCode.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "EDC Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "From EDC Code"
        '
        'ComboEDC
        '
        Me.ComboEDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEDC.FormattingEnabled = True
        Me.ComboEDC.Items.AddRange(New Object() {"E", "D", "C"})
        Me.ComboEDC.Location = New System.Drawing.Point(114, 135)
        Me.ComboEDC.Name = "ComboEDC"
        Me.ComboEDC.Size = New System.Drawing.Size(100, 21)
        Me.ComboEDC.TabIndex = 13
        '
        'txtFromCode
        '
        Me.txtFromCode.Location = New System.Drawing.Point(114, 83)
        Me.txtFromCode.Name = "txtFromCode"
        Me.txtFromCode.Size = New System.Drawing.Size(100, 20)
        Me.txtFromCode.TabIndex = 12
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(114, 58)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(133, 17)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Exclude current Period"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtEDC
        '
        Me.txtEDC.Location = New System.Drawing.Point(114, 176)
        Me.txtEDC.Name = "txtEDC"
        Me.txtEDC.Size = New System.Drawing.Size(100, 20)
        Me.txtEDC.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "EDC Code"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(241, 174)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "FixYTD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmTransferEDCCodeValueFromLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 326)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEDC)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPeriodGroup)
        Me.Controls.Add(Me.txtTempGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtToCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboEDC)
        Me.Controls.Add(Me.txtFromCode)
        Me.Name = "FrmTransferEDCCodeValueFromLines"
        Me.Text = "Transfer EDC Value From EDC to EDC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtTempGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtToCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEDC As System.Windows.Forms.ComboBox
    Friend WithEvents txtFromCode As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtEDC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
