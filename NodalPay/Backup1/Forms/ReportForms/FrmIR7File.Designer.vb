<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIR7File
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTaxGiven = New System.Windows.Forms.TextBox
        Me.CBOriginal = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnFile = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tax Amount Given"
        '
        'txtTaxGiven
        '
        Me.txtTaxGiven.Location = New System.Drawing.Point(122, 12)
        Me.txtTaxGiven.Name = "txtTaxGiven"
        Me.txtTaxGiven.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxGiven.TabIndex = 1
        '
        'CBOriginal
        '
        Me.CBOriginal.AutoSize = True
        Me.CBOriginal.Location = New System.Drawing.Point(122, 41)
        Me.CBOriginal.Name = "CBOriginal"
        Me.CBOriginal.Size = New System.Drawing.Size(15, 14)
        Me.CBOriginal.TabIndex = 2
        Me.CBOriginal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "First Statment"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(122, 61)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(100, 23)
        Me.btnFile.TabIndex = 4
        Me.btnFile.Text = "Create File"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'FrmIR7File
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(292, 99)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBOriginal)
        Me.Controls.Add(Me.txtTaxGiven)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmIR7File"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IR7 File Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTaxGiven As System.Windows.Forms.TextBox
    Friend WithEvents CBOriginal As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFile As System.Windows.Forms.Button
End Class
