<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_Pay
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(180, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(53, 20)
        Me.txtValue.TabIndex = 5
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.Yellow
        Me.txtCode.Location = New System.Drawing.Point(4, 0)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(167, 20)
        Me.txtCode.TabIndex = 4
        '
        'D_Pay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.txtCode)
        Me.Name = "D_Pay"
        Me.Size = New System.Drawing.Size(236, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox

End Class
