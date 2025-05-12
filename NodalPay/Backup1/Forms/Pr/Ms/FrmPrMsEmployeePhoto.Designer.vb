<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsEmployeePhoto
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
        Dim Label8 As System.Windows.Forms.Label
        Me.Picture = New System.Windows.Forms.PictureBox
        Me.BStartCapture = New System.Windows.Forms.Button
        Me.Browse = New System.Windows.Forms.Button
        Me.BRemove = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Label8 = New System.Windows.Forms.Label
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(190, 260)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(23, 13)
        Label8.TabIndex = 295
        Label8.Text = "OR"
        '
        'Picture
        '
        Me.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture.Location = New System.Drawing.Point(116, 66)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(186, 152)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 296
        Me.Picture.TabStop = False
        '
        'BStartCapture
        '
        Me.BStartCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BStartCapture.ForeColor = System.Drawing.Color.Black
        Me.BStartCapture.Location = New System.Drawing.Point(116, 287)
        Me.BStartCapture.Name = "BStartCapture"
        Me.BStartCapture.Size = New System.Drawing.Size(186, 23)
        Me.BStartCapture.TabIndex = 294
        Me.BStartCapture.Text = "Use Webcam"
        Me.BStartCapture.UseVisualStyleBackColor = True
        '
        'Browse
        '
        Me.Browse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.ForeColor = System.Drawing.Color.Black
        Me.Browse.Location = New System.Drawing.Point(116, 224)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(80, 23)
        Me.Browse.TabIndex = 292
        Me.Browse.Text = "Browse..."
        Me.Browse.UseVisualStyleBackColor = True
        '
        'BRemove
        '
        Me.BRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRemove.ForeColor = System.Drawing.Color.Black
        Me.BRemove.Location = New System.Drawing.Point(200, 224)
        Me.BRemove.Name = "BRemove"
        Me.BRemove.Size = New System.Drawing.Size(100, 23)
        Me.BRemove.TabIndex = 293
        Me.BRemove.Text = "Remove"
        Me.BRemove.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmPrMsEmployeePhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(418, 376)
        Me.Controls.Add(Me.Picture)
        Me.Controls.Add(Me.BStartCapture)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.BRemove)
        Me.Name = "FrmPrMsEmployeePhoto"
        Me.Text = "Employee Photo"
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Picture As System.Windows.Forms.PictureBox
    Private WithEvents BStartCapture As System.Windows.Forms.Button
    Private WithEvents Browse As System.Windows.Forms.Button
    Private WithEvents BRemove As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
