<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_Emp
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
        Me.components = New System.ComponentModel.Container
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.LblVP = New System.Windows.Forms.Label
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.Yellow
        Me.txtCode.Location = New System.Drawing.Point(3, 4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(167, 20)
        Me.txtCode.TabIndex = 0
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(176, 4)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(53, 20)
        Me.txtValue.TabIndex = 1
        '
        'LblVP
        '
        Me.LblVP.AutoSize = True
        Me.LblVP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblVP.Location = New System.Drawing.Point(254, 7)
        Me.LblVP.Name = "LblVP"
        Me.LblVP.Size = New System.Drawing.Size(16, 13)
        Me.LblVP.TabIndex = 2
        Me.LblVP.Text = "%"
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'E_Emp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LblVP)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.txtCode)
        Me.Name = "E_Emp"
        Me.Size = New System.Drawing.Size(273, 27)
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents LblVP As System.Windows.Forms.Label
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider

End Class
