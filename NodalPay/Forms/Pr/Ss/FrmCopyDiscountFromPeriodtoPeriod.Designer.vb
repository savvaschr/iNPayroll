<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopyDiscountFromPeriodtoPeriod
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
        Me.ComboFromPeriod = New System.Windows.Forms.ComboBox
        Me.ComboToPeriod = New System.Windows.Forms.ComboBox
        Me.BtnCopy = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboFromPeriod
        '
        Me.ComboFromPeriod.FormattingEnabled = True
        Me.ComboFromPeriod.Location = New System.Drawing.Point(105, 12)
        Me.ComboFromPeriod.Name = "ComboFromPeriod"
        Me.ComboFromPeriod.Size = New System.Drawing.Size(232, 21)
        Me.ComboFromPeriod.TabIndex = 0
        '
        'ComboToPeriod
        '
        Me.ComboToPeriod.FormattingEnabled = True
        Me.ComboToPeriod.Location = New System.Drawing.Point(105, 39)
        Me.ComboToPeriod.Name = "ComboToPeriod"
        Me.ComboToPeriod.Size = New System.Drawing.Size(232, 21)
        Me.ComboToPeriod.TabIndex = 1
        '
        'BtnCopy
        '
        Me.BtnCopy.Location = New System.Drawing.Point(105, 75)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(232, 23)
        Me.BtnCopy.TabIndex = 2
        Me.BtnCopy.Text = "Copy"
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To Period"
        '
        'FrmCopyDiscountFromPeriodtoPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 118)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.ComboToPeriod)
        Me.Controls.Add(Me.ComboFromPeriod)
        Me.Name = "FrmCopyDiscountFromPeriodtoPeriod"
        Me.Text = "Copy Discounts From Period to Period"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboFromPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents ComboToPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
