<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_Interface
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cmbConsolDebit = New System.Windows.Forms.ComboBox
        Me.CmbConsolCredit = New System.Windows.Forms.ComboBox
        Me.txtCreditAnal = New System.Windows.Forms.TextBox
        Me.txtDebitAnal = New System.Windows.Forms.TextBox
        Me.txtDed = New System.Windows.Forms.Button
        Me.cmbCreditAcc = New System.Windows.Forms.ComboBox
        Me.cmbDebitAcc = New System.Windows.Forms.ComboBox
        Me.BtnShowCredit = New System.Windows.Forms.Button
        Me.btnShowDebit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmbConsolDebit
        '
        Me.cmbConsolDebit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsolDebit.DropDownWidth = 120
        Me.cmbConsolDebit.FormattingEnabled = True
        Me.cmbConsolDebit.Location = New System.Drawing.Point(261, 0)
        Me.cmbConsolDebit.Name = "cmbConsolDebit"
        Me.cmbConsolDebit.Size = New System.Drawing.Size(34, 21)
        Me.cmbConsolDebit.TabIndex = 10
        '
        'CmbConsolCredit
        '
        Me.CmbConsolCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbConsolCredit.DropDownWidth = 120
        Me.CmbConsolCredit.FormattingEnabled = True
        Me.CmbConsolCredit.Location = New System.Drawing.Point(436, 0)
        Me.CmbConsolCredit.Name = "CmbConsolCredit"
        Me.CmbConsolCredit.Size = New System.Drawing.Size(34, 21)
        Me.CmbConsolCredit.TabIndex = 9
        '
        'txtCreditAnal
        '
        Me.txtCreditAnal.Location = New System.Drawing.Point(301, 0)
        Me.txtCreditAnal.Name = "txtCreditAnal"
        Me.txtCreditAnal.Size = New System.Drawing.Size(129, 20)
        Me.txtCreditAnal.TabIndex = 11
        Me.txtCreditAnal.Visible = False
        '
        'txtDebitAnal
        '
        Me.txtDebitAnal.Location = New System.Drawing.Point(126, 0)
        Me.txtDebitAnal.Name = "txtDebitAnal"
        Me.txtDebitAnal.Size = New System.Drawing.Size(129, 20)
        Me.txtDebitAnal.TabIndex = 12
        Me.txtDebitAnal.Visible = False
        '
        'txtDed
        '
        Me.txtDed.BackColor = System.Drawing.Color.Yellow
        Me.txtDed.Location = New System.Drawing.Point(3, 0)
        Me.txtDed.Name = "txtDed"
        Me.txtDed.Size = New System.Drawing.Size(117, 23)
        Me.txtDed.TabIndex = 13
        Me.txtDed.UseVisualStyleBackColor = False
        '
        'cmbCreditAcc
        '
        Me.cmbCreditAcc.FormattingEnabled = True
        Me.cmbCreditAcc.Location = New System.Drawing.Point(301, 0)
        Me.cmbCreditAcc.Name = "cmbCreditAcc"
        Me.cmbCreditAcc.Size = New System.Drawing.Size(129, 21)
        Me.cmbCreditAcc.TabIndex = 14
        '
        'cmbDebitAcc
        '
        Me.cmbDebitAcc.FormattingEnabled = True
        Me.cmbDebitAcc.Location = New System.Drawing.Point(126, 0)
        Me.cmbDebitAcc.Name = "cmbDebitAcc"
        Me.cmbDebitAcc.Size = New System.Drawing.Size(129, 21)
        Me.cmbDebitAcc.TabIndex = 15
        '
        'BtnShowCredit
        '
        Me.BtnShowCredit.Location = New System.Drawing.Point(514, 0)
        Me.BtnShowCredit.Name = "BtnShowCredit"
        Me.BtnShowCredit.Size = New System.Drawing.Size(33, 23)
        Me.BtnShowCredit.TabIndex = 17
        Me.BtnShowCredit.Text = "C"
        Me.BtnShowCredit.UseVisualStyleBackColor = True
        '
        'btnShowDebit
        '
        Me.btnShowDebit.Location = New System.Drawing.Point(476, 0)
        Me.btnShowDebit.Name = "btnShowDebit"
        Me.btnShowDebit.Size = New System.Drawing.Size(32, 23)
        Me.btnShowDebit.TabIndex = 16
        Me.btnShowDebit.Text = "D"
        Me.btnShowDebit.UseVisualStyleBackColor = True
        '
        'D_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnShowCredit)
        Me.Controls.Add(Me.btnShowDebit)
        Me.Controls.Add(Me.txtDed)
        Me.Controls.Add(Me.txtDebitAnal)
        Me.Controls.Add(Me.cmbConsolDebit)
        Me.Controls.Add(Me.CmbConsolCredit)
        Me.Controls.Add(Me.txtCreditAnal)
        Me.Controls.Add(Me.cmbDebitAcc)
        Me.Controls.Add(Me.cmbCreditAcc)
        Me.Name = "D_Interface"
        Me.Size = New System.Drawing.Size(557, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbConsolDebit As System.Windows.Forms.ComboBox
    Friend WithEvents CmbConsolCredit As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreditAnal As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitAnal As System.Windows.Forms.TextBox
    Friend WithEvents txtDed As System.Windows.Forms.Button
    Friend WithEvents cmbCreditAcc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebitAcc As System.Windows.Forms.ComboBox
    Friend WithEvents BtnShowCredit As System.Windows.Forms.Button
    Friend WithEvents btnShowDebit As System.Windows.Forms.Button

End Class
