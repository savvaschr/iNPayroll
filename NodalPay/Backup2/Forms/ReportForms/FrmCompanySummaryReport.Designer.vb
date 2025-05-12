<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompanySummaryReport
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
        Me.ComboFromCompany = New System.Windows.Forms.ComboBox
        Me.ComboToCompany = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.btnReport = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboFromCompany
        '
        Me.ComboFromCompany.FormattingEnabled = True
        Me.ComboFromCompany.Location = New System.Drawing.Point(108, 6)
        Me.ComboFromCompany.Name = "ComboFromCompany"
        Me.ComboFromCompany.Size = New System.Drawing.Size(296, 21)
        Me.ComboFromCompany.TabIndex = 0
        '
        'ComboToCompany
        '
        Me.ComboToCompany.FormattingEnabled = True
        Me.ComboToCompany.Location = New System.Drawing.Point(108, 33)
        Me.ComboToCompany.Name = "ComboToCompany"
        Me.ComboToCompany.Size = New System.Drawing.Size(296, 21)
        Me.ComboToCompany.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Company"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Company"
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(15, 60)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1239, 520)
        Me.DG1.TabIndex = 4
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(410, 4)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(167, 23)
        Me.btnReport.TabIndex = 5
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1179, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmCompanySummaryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1266, 592)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboToCompany)
        Me.Controls.Add(Me.ComboFromCompany)
        Me.Name = "FrmCompanySummaryReport"
        Me.Text = "Company Summary Report"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboFromCompany As System.Windows.Forms.ComboBox
    Friend WithEvents ComboToCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
