<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReplaceEDCValue
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
        Me.ComboEDC = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEDCCode = New System.Windows.Forms.TextBox
        Me.txtCurrentValue = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNewValue = New System.Windows.Forms.TextBox
        Me.txtTemGroup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(61, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(209, 38)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Replace"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboEDC
        '
        Me.ComboEDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEDC.FormattingEnabled = True
        Me.ComboEDC.Items.AddRange(New Object() {"E", "D", "C"})
        Me.ComboEDC.Location = New System.Drawing.Point(170, 48)
        Me.ComboEDC.Name = "ComboEDC"
        Me.ComboEDC.Size = New System.Drawing.Size(100, 21)
        Me.ComboEDC.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "EDC Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "EDC Code"
        '
        'txtEDCCode
        '
        Me.txtEDCCode.Location = New System.Drawing.Point(170, 78)
        Me.txtEDCCode.Name = "txtEDCCode"
        Me.txtEDCCode.Size = New System.Drawing.Size(100, 20)
        Me.txtEDCCode.TabIndex = 4
        '
        'txtCurrentValue
        '
        Me.txtCurrentValue.Location = New System.Drawing.Point(170, 104)
        Me.txtCurrentValue.Name = "txtCurrentValue"
        Me.txtCurrentValue.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentValue.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "New Value"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Current Value"
        '
        'txtNewValue
        '
        Me.txtNewValue.Location = New System.Drawing.Point(170, 130)
        Me.txtNewValue.Name = "txtNewValue"
        Me.txtNewValue.Size = New System.Drawing.Size(100, 20)
        Me.txtNewValue.TabIndex = 9
        '
        'txtTemGroup
        '
        Me.txtTemGroup.Location = New System.Drawing.Point(170, 22)
        Me.txtTemGroup.Name = "txtTemGroup"
        Me.txtTemGroup.ReadOnly = True
        Me.txtTemGroup.Size = New System.Drawing.Size(100, 20)
        Me.txtTemGroup.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Template Group"
        '
        'FrmReplaceEDCValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 235)
        Me.Controls.Add(Me.txtTemGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCurrentValue)
        Me.Controls.Add(Me.txtEDCCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboEDC)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmReplaceEDCValue"
        Me.Text = "Replace EDC Value"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboEDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEDCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNewValue As System.Windows.Forms.TextBox
    Friend WithEvents txtTemGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
