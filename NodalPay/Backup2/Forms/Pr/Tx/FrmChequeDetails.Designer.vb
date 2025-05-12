<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequeDetails
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
        Me.DateCheque = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnContinue = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateCheque
        '
        Me.DateCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCheque.Location = New System.Drawing.Point(130, 25)
        Me.DateCheque.Name = "DateCheque"
        Me.DateCheque.Size = New System.Drawing.Size(95, 20)
        Me.DateCheque.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cheque Date"
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(130, 59)
        Me.txtChequeNo.MaxLength = 15
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(182, 20)
        Me.txtChequeNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "First Cheque Number"
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(130, 94)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(182, 27)
        Me.btnContinue.TabIndex = 4
        Me.btnContinue.Text = "Print Payslip and Cheque"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'FrmChequeDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(337, 154)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtChequeNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateCheque)
        Me.Name = "FrmChequeDetails"
        Me.Text = "Cheque Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnContinue As System.Windows.Forms.Button
End Class
