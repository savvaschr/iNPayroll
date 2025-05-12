<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsNavBatchCorrection
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
        Me.txtGenBatId = New System.Windows.Forms.TextBox
        Me.txtIdTo = New System.Windows.Forms.TextBox
        Me.txtIdFrom = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtGenBatId
        '
        Me.txtGenBatId.Enabled = False
        Me.txtGenBatId.Location = New System.Drawing.Point(130, 23)
        Me.txtGenBatId.Name = "txtGenBatId"
        Me.txtGenBatId.Size = New System.Drawing.Size(100, 20)
        Me.txtGenBatId.TabIndex = 0
        '
        'txtIdTo
        '
        Me.txtIdTo.Location = New System.Drawing.Point(130, 75)
        Me.txtIdTo.Name = "txtIdTo"
        Me.txtIdTo.Size = New System.Drawing.Size(100, 20)
        Me.txtIdTo.TabIndex = 3
        '
        'txtIdFrom
        '
        Me.txtIdFrom.Location = New System.Drawing.Point(130, 49)
        Me.txtIdFrom.Name = "txtIdFrom"
        Me.txtIdFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtIdFrom.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "General Batch Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Id From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Id To"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(414, 95)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'FrmSsNavBatchCorrection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 140)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdFrom)
        Me.Controls.Add(Me.txtIdTo)
        Me.Controls.Add(Me.txtGenBatId)
        Me.Name = "FrmSsNavBatchCorrection"
        Me.Text = "Batch Correction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGenBatId As System.Windows.Forms.TextBox
    Friend WithEvents txtIdTo As System.Windows.Forms.TextBox
    Friend WithEvents txtIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
End Class
