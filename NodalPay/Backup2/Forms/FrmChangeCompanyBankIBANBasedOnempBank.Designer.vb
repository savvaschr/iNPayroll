<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeCompanyBankIBANBasedOnempBank
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
        Me.ComboCom = New System.Windows.Forms.ComboBox
        Me.ComboEmp = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ComboCom
        '
        Me.ComboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCom.Location = New System.Drawing.Point(200, 39)
        Me.ComboCom.Name = "ComboCom"
        Me.ComboCom.Size = New System.Drawing.Size(314, 21)
        Me.ComboCom.TabIndex = 52
        '
        'ComboEmp
        '
        Me.ComboEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmp.Location = New System.Drawing.Point(200, 12)
        Me.ComboEmp.Name = "ComboEmp"
        Me.ComboEmp.Size = New System.Drawing.Size(314, 21)
        Me.ComboEmp.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Set Company Bank to"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(200, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(314, 23)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Change Comapny Bank and IBAN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Employee Bank"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Set Company IBAN to"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(200, 66)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(314, 20)
        Me.TextBox1.TabIndex = 54
        '
        'FrmChangeCompanyBankIBANBasedOnempBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 167)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboCom)
        Me.Controls.Add(Me.ComboEmp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmChangeCompanyBankIBANBasedOnempBank"
        Me.Text = "Change Company Bank and IBAN Based On Employee Bank"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboCom As System.Windows.Forms.ComboBox
    Friend WithEvents ComboEmp As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
