<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGmail
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
        Me.txtGmailAccount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGmailPassword = New System.Windows.Forms.TextBox
        Me.btnSend = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtGmailAccount
        '
        Me.txtGmailAccount.Location = New System.Drawing.Point(184, 43)
        Me.txtGmailAccount.Name = "txtGmailAccount"
        Me.txtGmailAccount.Size = New System.Drawing.Size(280, 20)
        Me.txtGmailAccount.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Gmail/Office 365 Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Gmail/Office 365 Password"
        '
        'txtGmailPassword
        '
        Me.txtGmailPassword.Location = New System.Drawing.Point(184, 69)
        Me.txtGmailPassword.Name = "txtGmailPassword"
        Me.txtGmailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtGmailPassword.Size = New System.Drawing.Size(280, 20)
        Me.txtGmailPassword.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(184, 117)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(280, 23)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'FrmGmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 181)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGmailPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGmailAccount)
        Me.Name = "FrmGmail"
        Me.Text = "Gmail/Office 365 Account "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGmailAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGmailPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
End Class
