<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeCompanyBank
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboOld = New System.Windows.Forms.ComboBox
        Me.ComboNew = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "New Bank Code"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(379, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Replace"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Old Bank Code"
        '
        'ComboOld
        '
        Me.ComboOld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboOld.Location = New System.Drawing.Point(202, 15)
        Me.ComboOld.Name = "ComboOld"
        Me.ComboOld.Size = New System.Drawing.Size(314, 21)
        Me.ComboOld.TabIndex = 46
        '
        'ComboNew
        '
        Me.ComboNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboNew.Location = New System.Drawing.Point(202, 42)
        Me.ComboNew.Name = "ComboNew"
        Me.ComboNew.Size = New System.Drawing.Size(314, 21)
        Me.ComboNew.TabIndex = 47
        '
        'FrmChangeCompanyBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 143)
        Me.Controls.Add(Me.ComboNew)
        Me.Controls.Add(Me.ComboOld)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmChangeCompanyBank"
        Me.Text = "Change Company Bank"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboOld As System.Windows.Forms.ComboBox
    Friend WithEvents ComboNew As System.Windows.Forms.ComboBox
End Class
