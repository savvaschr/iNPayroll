<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistredPCs
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
        Me.BtnGetSerial = New System.Windows.Forms.Button
        Me.txtSerialNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEncryptionKey = New System.Windows.Forms.TextBox
        Me.txtPCDescription = New System.Windows.Forms.TextBox
        Me.txtProductKey = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnGetProduct = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGetSerial
        '
        Me.BtnGetSerial.Location = New System.Drawing.Point(451, 13)
        Me.BtnGetSerial.Name = "BtnGetSerial"
        Me.BtnGetSerial.Size = New System.Drawing.Size(132, 23)
        Me.BtnGetSerial.TabIndex = 0
        Me.BtnGetSerial.Text = "Get Serial "
        Me.BtnGetSerial.UseVisualStyleBackColor = True
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Location = New System.Drawing.Point(114, 16)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.ReadOnly = True
        Me.txtSerialNo.Size = New System.Drawing.Size(322, 20)
        Me.txtSerialNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Serial Number"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(114, 157)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 219)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(775, 373)
        Me.DataGridView1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Encryption Key"
        '
        'txtEncryptionKey
        '
        Me.txtEncryptionKey.Location = New System.Drawing.Point(114, 42)
        Me.txtEncryptionKey.Name = "txtEncryptionKey"
        Me.txtEncryptionKey.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEncryptionKey.Size = New System.Drawing.Size(322, 20)
        Me.txtEncryptionKey.TabIndex = 5
        '
        'txtPCDescription
        '
        Me.txtPCDescription.Location = New System.Drawing.Point(114, 95)
        Me.txtPCDescription.Name = "txtPCDescription"
        Me.txtPCDescription.Size = New System.Drawing.Size(322, 20)
        Me.txtPCDescription.TabIndex = 7
        '
        'txtProductKey
        '
        Me.txtProductKey.Location = New System.Drawing.Point(114, 121)
        Me.txtProductKey.Name = "txtProductKey"
        Me.txtProductKey.Size = New System.Drawing.Size(322, 20)
        Me.txtProductKey.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "This PC Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Product Key"
        '
        'btnGetProduct
        '
        Me.btnGetProduct.Location = New System.Drawing.Point(451, 119)
        Me.btnGetProduct.Name = "btnGetProduct"
        Me.btnGetProduct.Size = New System.Drawing.Size(132, 23)
        Me.btnGetProduct.TabIndex = 11
        Me.btnGetProduct.Text = "Get Product Key"
        Me.btnGetProduct.UseVisualStyleBackColor = True
        '
        'FrmRegistredPCs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 604)
        Me.Controls.Add(Me.btnGetProduct)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProductKey)
        Me.Controls.Add(Me.txtPCDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEncryptionKey)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSerialNo)
        Me.Controls.Add(Me.BtnGetSerial)
        Me.Name = "FrmRegistredPCs"
        Me.Text = "PC Licence Registration "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnGetSerial As System.Windows.Forms.Button
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEncryptionKey As System.Windows.Forms.TextBox
    Friend WithEvents txtPCDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtProductKey As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGetProduct As System.Windows.Forms.Button
End Class
