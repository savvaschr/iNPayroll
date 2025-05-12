<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodeMask
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtPosition = New System.Windows.Forms.TextBox
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.ComboType = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.Color.Yellow
        Me.txtPosition.Location = New System.Drawing.Point(0, 0)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(29, 20)
        Me.txtPosition.TabIndex = 0
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(165, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(102, 20)
        Me.txtValue.TabIndex = 2
        '
        'ComboType
        '
        Me.ComboType.FormattingEnabled = True
        Me.ComboType.Location = New System.Drawing.Point(38, 0)
        Me.ComboType.Name = "ComboType"
        Me.ComboType.Size = New System.Drawing.Size(121, 21)
        Me.ComboType.TabIndex = 1
        '
        'CodeMask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboType)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.txtPosition)
        Me.Name = "CodeMask"
        Me.Size = New System.Drawing.Size(270, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents ComboType As System.Windows.Forms.ComboBox

End Class
