<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFixYTD
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
        Me.btnReCalc = New System.Windows.Forms.Button
        Me.txtEmpCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPeriodGroup = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnReCalc
        '
        Me.btnReCalc.Location = New System.Drawing.Point(113, 115)
        Me.btnReCalc.Name = "btnReCalc"
        Me.btnReCalc.Size = New System.Drawing.Size(115, 23)
        Me.btnReCalc.TabIndex = 0
        Me.btnReCalc.Text = "Button1"
        Me.btnReCalc.UseVisualStyleBackColor = True
        '
        'txtEmpCode
        '
        Me.txtEmpCode.Location = New System.Drawing.Point(113, 44)
        Me.txtEmpCode.Name = "txtEmpCode"
        Me.txtEmpCode.Size = New System.Drawing.Size(115, 20)
        Me.txtEmpCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Employee Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Period Group"
        '
        'txtPeriodGroup
        '
        Me.txtPeriodGroup.Location = New System.Drawing.Point(113, 70)
        Me.txtPeriodGroup.Name = "txtPeriodGroup"
        Me.txtPeriodGroup.Size = New System.Drawing.Size(115, 20)
        Me.txtPeriodGroup.TabIndex = 3
        '
        'FrmFixYTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 213)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPeriodGroup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmpCode)
        Me.Controls.Add(Me.btnReCalc)
        Me.Name = "FrmFixYTD"
        Me.Text = "FrmFixYTD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReCalc As System.Windows.Forms.Button
    Friend WithEvents txtEmpCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodGroup As System.Windows.Forms.TextBox
End Class
