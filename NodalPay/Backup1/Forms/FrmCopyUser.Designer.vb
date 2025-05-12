<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopyUser
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
        Me.ComboFrom = New System.Windows.Forms.ComboBox
        Me.ComboTo = New System.Windows.Forms.ComboBox
        Me.btnCopy = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboFrom
        '
        Me.ComboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFrom.FormattingEnabled = True
        Me.ComboFrom.Location = New System.Drawing.Point(113, 25)
        Me.ComboFrom.Name = "ComboFrom"
        Me.ComboFrom.Size = New System.Drawing.Size(179, 21)
        Me.ComboFrom.TabIndex = 0
        '
        'ComboTo
        '
        Me.ComboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTo.FormattingEnabled = True
        Me.ComboTo.Location = New System.Drawing.Point(113, 52)
        Me.ComboTo.Name = "ComboTo"
        Me.ComboTo.Size = New System.Drawing.Size(179, 21)
        Me.ComboTo.TabIndex = 1
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(113, 101)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(179, 23)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From User"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To User"
        '
        'FrmCopyUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 147)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.ComboTo)
        Me.Controls.Add(Me.ComboFrom)
        Me.Name = "FrmCopyUser"
        Me.Text = "Copy User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboFrom As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
