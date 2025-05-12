<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportTimeSheetsFromExcel
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.txt_M_SourceLocationExcel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_M_ConvertFile = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(575, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 20)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_M_SourceLocationExcel
        '
        Me.txt_M_SourceLocationExcel.Location = New System.Drawing.Point(168, 45)
        Me.txt_M_SourceLocationExcel.Name = "txt_M_SourceLocationExcel"
        Me.txt_M_SourceLocationExcel.Size = New System.Drawing.Size(401, 20)
        Me.txt_M_SourceLocationExcel.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Source file (.txt tab delimeted)"
        '
        'btn_M_ConvertFile
        '
        Me.btn_M_ConvertFile.Location = New System.Drawing.Point(19, 156)
        Me.btn_M_ConvertFile.Name = "btn_M_ConvertFile"
        Me.btn_M_ConvertFile.Size = New System.Drawing.Size(585, 29)
        Me.btn_M_ConvertFile.TabIndex = 35
        Me.btn_M_ConvertFile.Text = "Import TimeSheets from Text File"
        Me.btn_M_ConvertFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmImportTimeSheetsFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 230)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_M_SourceLocationExcel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_M_ConvertFile)
        Me.Name = "FrmImportTimeSheetsFromExcel"
        Me.Text = "Import Time Sheets From Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_M_SourceLocationExcel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_M_ConvertFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
