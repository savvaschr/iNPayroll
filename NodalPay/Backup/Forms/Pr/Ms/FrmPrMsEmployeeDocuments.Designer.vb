<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsEmployeeDocuments
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
        Me.DGDocs = New System.Windows.Forms.DataGridView
        Me.txtDocs = New System.Windows.Forms.TextBox
        Me.btnOpenDocs = New System.Windows.Forms.Button
        Me.btnSaveDocs = New System.Windows.Forms.Button
        Me.btnBrowseDocs = New System.Windows.Forms.Button
        CType(Me.DGDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGDocs
        '
        Me.DGDocs.BackgroundColor = System.Drawing.Color.White
        Me.DGDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDocs.Location = New System.Drawing.Point(85, 92)
        Me.DGDocs.Name = "DGDocs"
        Me.DGDocs.Size = New System.Drawing.Size(644, 337)
        Me.DGDocs.TabIndex = 9
        '
        'txtDocs
        '
        Me.txtDocs.Location = New System.Drawing.Point(85, 28)
        Me.txtDocs.Name = "txtDocs"
        Me.txtDocs.Size = New System.Drawing.Size(456, 20)
        Me.txtDocs.TabIndex = 8
        '
        'btnOpenDocs
        '
        Me.btnOpenDocs.Location = New System.Drawing.Point(85, 54)
        Me.btnOpenDocs.Name = "btnOpenDocs"
        Me.btnOpenDocs.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenDocs.TabIndex = 7
        Me.btnOpenDocs.Text = "Open"
        Me.btnOpenDocs.UseVisualStyleBackColor = True
        '
        'btnSaveDocs
        '
        Me.btnSaveDocs.Location = New System.Drawing.Point(654, 26)
        Me.btnSaveDocs.Name = "btnSaveDocs"
        Me.btnSaveDocs.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveDocs.TabIndex = 6
        Me.btnSaveDocs.Text = "Save"
        Me.btnSaveDocs.UseVisualStyleBackColor = True
        '
        'btnBrowseDocs
        '
        Me.btnBrowseDocs.Location = New System.Drawing.Point(563, 26)
        Me.btnBrowseDocs.Name = "btnBrowseDocs"
        Me.btnBrowseDocs.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDocs.TabIndex = 5
        Me.btnBrowseDocs.Text = "Browse"
        Me.btnBrowseDocs.UseVisualStyleBackColor = True
        '
        'FrmPrMsEmployeeDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 455)
        Me.Controls.Add(Me.DGDocs)
        Me.Controls.Add(Me.txtDocs)
        Me.Controls.Add(Me.btnOpenDocs)
        Me.Controls.Add(Me.btnSaveDocs)
        Me.Controls.Add(Me.btnBrowseDocs)
        Me.Name = "FrmPrMsEmployeeDocuments"
        Me.Text = "FrmPrMsEmployeeDocuments"
        CType(Me.DGDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGDocs As System.Windows.Forms.DataGridView
    Friend WithEvents txtDocs As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenDocs As System.Windows.Forms.Button
    Friend WithEvents btnSaveDocs As System.Windows.Forms.Button
    Friend WithEvents btnBrowseDocs As System.Windows.Forms.Button
End Class
