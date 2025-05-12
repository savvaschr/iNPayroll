<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTxInterfaceDate
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
        Me.DateNavPost = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnContinue = New System.Windows.Forms.Button
        Me.CBIncludeEmployees = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'DateNavPost
        '
        Me.DateNavPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateNavPost.Location = New System.Drawing.Point(150, 32)
        Me.DateNavPost.Name = "DateNavPost"
        Me.DateNavPost.Size = New System.Drawing.Size(92, 20)
        Me.DateNavPost.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Journal Posting Date"
        '
        'BtnContinue
        '
        Me.BtnContinue.Location = New System.Drawing.Point(15, 108)
        Me.BtnContinue.Name = "BtnContinue"
        Me.BtnContinue.Size = New System.Drawing.Size(227, 27)
        Me.BtnContinue.TabIndex = 2
        Me.BtnContinue.Text = "Continue"
        Me.BtnContinue.UseVisualStyleBackColor = True
        '
        'CBIncludeEmployees
        '
        Me.CBIncludeEmployees.AutoSize = True
        Me.CBIncludeEmployees.Location = New System.Drawing.Point(15, 69)
        Me.CBIncludeEmployees.Name = "CBIncludeEmployees"
        Me.CBIncludeEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBIncludeEmployees.Size = New System.Drawing.Size(151, 17)
        Me.CBIncludeEmployees.TabIndex = 3
        Me.CBIncludeEmployees.Text = "Include Employees            "
        Me.CBIncludeEmployees.UseVisualStyleBackColor = True
        '
        'FrmTxInterfaceDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(292, 158)
        Me.Controls.Add(Me.CBIncludeEmployees)
        Me.Controls.Add(Me.BtnContinue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateNavPost)
        Me.Name = "FrmTxInterfaceDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Posting Date"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateNavPost As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnContinue As System.Windows.Forms.Button
    Friend WithEvents CBIncludeEmployees As System.Windows.Forms.CheckBox
End Class
