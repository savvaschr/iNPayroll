<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectEDCToImport
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
        Me.txtEDCCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodePrefix = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCodeTotalLen = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPadchar = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 171)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtEDCCode
        '
        Me.txtEDCCode.Location = New System.Drawing.Point(221, 23)
        Me.txtEDCCode.Name = "txtEDCCode"
        Me.txtEDCCode.Size = New System.Drawing.Size(107, 20)
        Me.txtEDCCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "EDC Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Employee Code Prefix"
        '
        'txtCodePrefix
        '
        Me.txtCodePrefix.Location = New System.Drawing.Point(221, 64)
        Me.txtCodePrefix.Name = "txtCodePrefix"
        Me.txtCodePrefix.Size = New System.Drawing.Size(107, 20)
        Me.txtCodePrefix.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Employee Code Total Lenght"
        '
        'txtCodeTotalLen
        '
        Me.txtCodeTotalLen.Location = New System.Drawing.Point(221, 90)
        Me.txtCodeTotalLen.Name = "txtCodeTotalLen"
        Me.txtCodeTotalLen.Size = New System.Drawing.Size(107, 20)
        Me.txtCodeTotalLen.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pading Character"
        '
        'txtPadchar
        '
        Me.txtPadchar.Location = New System.Drawing.Point(221, 123)
        Me.txtPadchar.Name = "txtPadchar"
        Me.txtPadchar.Size = New System.Drawing.Size(107, 20)
        Me.txtPadchar.TabIndex = 7
        '
        'FrmSelectEDCToImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 224)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPadchar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodeTotalLen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodePrefix)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEDCCode)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmSelectEDCToImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select EDC To Import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtEDCCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodePrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodeTotalLen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPadchar As System.Windows.Forms.TextBox
End Class
