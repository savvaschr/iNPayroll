<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeEDCCodeFromLines
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
        Me.txtFromCode = New System.Windows.Forms.TextBox
        Me.ComboEDC = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtToCode = New System.Windows.Forms.TextBox
        Me.txtTempGroup = New System.Windows.Forms.TextBox
        Me.txtPeriodGroup = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtFromCode
        '
        Me.txtFromCode.Location = New System.Drawing.Point(138, 100)
        Me.txtFromCode.Name = "txtFromCode"
        Me.txtFromCode.Size = New System.Drawing.Size(100, 20)
        Me.txtFromCode.TabIndex = 0
        '
        'ComboEDC
        '
        Me.ComboEDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEDC.FormattingEnabled = True
        Me.ComboEDC.Items.AddRange(New Object() {"E", "D", "C"})
        Me.ComboEDC.Location = New System.Drawing.Point(138, 152)
        Me.ComboEDC.Name = "ComboEDC"
        Me.ComboEDC.Size = New System.Drawing.Size(100, 21)
        Me.ComboEDC.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From EDC Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "EDC Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "To EDC Code"
        '
        'txtToCode
        '
        Me.txtToCode.Location = New System.Drawing.Point(138, 126)
        Me.txtToCode.Name = "txtToCode"
        Me.txtToCode.Size = New System.Drawing.Size(100, 20)
        Me.txtToCode.TabIndex = 5
        '
        'txtTempGroup
        '
        Me.txtTempGroup.Location = New System.Drawing.Point(138, 23)
        Me.txtTempGroup.Name = "txtTempGroup"
        Me.txtTempGroup.ReadOnly = True
        Me.txtTempGroup.Size = New System.Drawing.Size(380, 20)
        Me.txtTempGroup.TabIndex = 7
        '
        'txtPeriodGroup
        '
        Me.txtPeriodGroup.Location = New System.Drawing.Point(138, 49)
        Me.txtPeriodGroup.Name = "txtPeriodGroup"
        Me.txtPeriodGroup.ReadOnly = True
        Me.txtPeriodGroup.Size = New System.Drawing.Size(380, 20)
        Me.txtPeriodGroup.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Template Group"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Period Group"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmChangeEDCCodeFromLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 216)
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
        Me.Name = "FrmChangeEDCCodeFromLines"
        Me.Text = "Change EDC Code From Lines"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFromCode As System.Windows.Forms.TextBox
    Friend WithEvents ComboEDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtToCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTempGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
