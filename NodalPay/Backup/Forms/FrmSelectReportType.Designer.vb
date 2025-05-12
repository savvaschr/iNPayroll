<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectReportType
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.RadioSendToScreen = New System.Windows.Forms.RadioButton
        Me.RadioPrinter = New System.Windows.Forms.RadioButton
        Me.RadioPDF = New System.Windows.Forms.RadioButton
        Me.RadioExcel = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.RadioExcel)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.RadioSendToScreen)
        Me.Panel1.Controls.Add(Me.RadioPrinter)
        Me.Panel1.Controls.Add(Me.RadioPDF)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 238)
        Me.Panel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(182, 182)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(101, 182)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 8
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'RadioSendToScreen
        '
        Me.RadioSendToScreen.AutoSize = True
        Me.RadioSendToScreen.Location = New System.Drawing.Point(126, 126)
        Me.RadioSendToScreen.Name = "RadioSendToScreen"
        Me.RadioSendToScreen.Size = New System.Drawing.Size(103, 17)
        Me.RadioSendToScreen.TabIndex = 7
        Me.RadioSendToScreen.TabStop = True
        Me.RadioSendToScreen.Text = "Send To Screen"
        Me.RadioSendToScreen.UseVisualStyleBackColor = True
        '
        'RadioPrinter
        '
        Me.RadioPrinter.AutoSize = True
        Me.RadioPrinter.Location = New System.Drawing.Point(126, 95)
        Me.RadioPrinter.Name = "RadioPrinter"
        Me.RadioPrinter.Size = New System.Drawing.Size(99, 17)
        Me.RadioPrinter.TabIndex = 6
        Me.RadioPrinter.TabStop = True
        Me.RadioPrinter.Text = "Send To Printer"
        Me.RadioPrinter.UseVisualStyleBackColor = True
        '
        'RadioPDF
        '
        Me.RadioPDF.AutoSize = True
        Me.RadioPDF.Location = New System.Drawing.Point(126, 33)
        Me.RadioPDF.Name = "RadioPDF"
        Me.RadioPDF.Size = New System.Drawing.Size(91, 17)
        Me.RadioPDF.TabIndex = 5
        Me.RadioPDF.TabStop = True
        Me.RadioPDF.Text = "Export In PDF"
        Me.RadioPDF.UseVisualStyleBackColor = True
        '
        'RadioExcel
        '
        Me.RadioExcel.AutoSize = True
        Me.RadioExcel.Location = New System.Drawing.Point(126, 64)
        Me.RadioExcel.Name = "RadioExcel"
        Me.RadioExcel.Size = New System.Drawing.Size(95, 17)
        Me.RadioExcel.TabIndex = 10
        Me.RadioExcel.TabStop = True
        Me.RadioExcel.Text = "Send To Excel"
        Me.RadioExcel.UseVisualStyleBackColor = True
        '
        'FrmSelectReportType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(383, 262)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSelectReportType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Report Type"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents RadioSendToScreen As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPrinter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPDF As System.Windows.Forms.RadioButton
    Friend WithEvents RadioExcel As System.Windows.Forms.RadioButton
End Class
