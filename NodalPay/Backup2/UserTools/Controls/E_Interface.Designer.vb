<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_Interface
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
        Me.CmbConsolCredit = New System.Windows.Forms.ComboBox
        Me.cmbConsolDebit = New System.Windows.Forms.ComboBox
        Me.txtErn = New System.Windows.Forms.Button
        Me.txtCreditAnal = New System.Windows.Forms.TextBox
        Me.txtDebitAnal = New System.Windows.Forms.TextBox
        Me.cmbCreditAcc = New System.Windows.Forms.ComboBox
        Me.cmbDebitAcc = New System.Windows.Forms.ComboBox
        Me.btnShowDebit = New System.Windows.Forms.Button
        Me.BtnShowCredit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CmbConsolCredit
        '
        Me.CmbConsolCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbConsolCredit.DropDownWidth = 120
        Me.CmbConsolCredit.FormattingEnabled = True
        Me.CmbConsolCredit.Location = New System.Drawing.Point(441, 1)
        Me.CmbConsolCredit.Name = "CmbConsolCredit"
        Me.CmbConsolCredit.Size = New System.Drawing.Size(34, 21)
        Me.CmbConsolCredit.TabIndex = 4
        '
        'cmbConsolDebit
        '
        Me.cmbConsolDebit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsolDebit.DropDownWidth = 120
        Me.cmbConsolDebit.FormattingEnabled = True
        Me.cmbConsolDebit.Location = New System.Drawing.Point(267, 1)
        Me.cmbConsolDebit.Name = "cmbConsolDebit"
        Me.cmbConsolDebit.Size = New System.Drawing.Size(34, 21)
        Me.cmbConsolDebit.TabIndex = 5
        '
        'txtErn
        '
        Me.txtErn.BackColor = System.Drawing.Color.Yellow
        Me.txtErn.Location = New System.Drawing.Point(3, 1)
        Me.txtErn.Name = "txtErn"
        Me.txtErn.Size = New System.Drawing.Size(120, 23)
        Me.txtErn.TabIndex = 6
        Me.txtErn.UseVisualStyleBackColor = False
        '
        'txtCreditAnal
        '
        Me.txtCreditAnal.Location = New System.Drawing.Point(305, 1)
        Me.txtCreditAnal.Name = "txtCreditAnal"
        Me.txtCreditAnal.Size = New System.Drawing.Size(130, 20)
        Me.txtCreditAnal.TabIndex = 7
        Me.txtCreditAnal.Visible = False
        '
        'txtDebitAnal
        '
        Me.txtDebitAnal.Location = New System.Drawing.Point(134, 1)
        Me.txtDebitAnal.Name = "txtDebitAnal"
        Me.txtDebitAnal.Size = New System.Drawing.Size(130, 20)
        Me.txtDebitAnal.TabIndex = 8
        Me.txtDebitAnal.Visible = False
        '
        'cmbCreditAcc
        '
        Me.cmbCreditAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCreditAcc.FormattingEnabled = True
        Me.cmbCreditAcc.Location = New System.Drawing.Point(305, 1)
        Me.cmbCreditAcc.Name = "cmbCreditAcc"
        Me.cmbCreditAcc.Size = New System.Drawing.Size(130, 21)
        Me.cmbCreditAcc.TabIndex = 9
        '
        'cmbDebitAcc
        '
        Me.cmbDebitAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDebitAcc.FormattingEnabled = True
        Me.cmbDebitAcc.Location = New System.Drawing.Point(134, 1)
        Me.cmbDebitAcc.Name = "cmbDebitAcc"
        Me.cmbDebitAcc.Size = New System.Drawing.Size(130, 21)
        Me.cmbDebitAcc.TabIndex = 10
        '
        'btnShowDebit
        '
        Me.btnShowDebit.Location = New System.Drawing.Point(481, 1)
        Me.btnShowDebit.Name = "btnShowDebit"
        Me.btnShowDebit.Size = New System.Drawing.Size(32, 23)
        Me.btnShowDebit.TabIndex = 11
        Me.btnShowDebit.Text = "D"
        Me.btnShowDebit.UseVisualStyleBackColor = True
        '
        'BtnShowCredit
        '
        Me.BtnShowCredit.Location = New System.Drawing.Point(519, 1)
        Me.BtnShowCredit.Name = "BtnShowCredit"
        Me.BtnShowCredit.Size = New System.Drawing.Size(33, 23)
        Me.BtnShowCredit.TabIndex = 12
        Me.BtnShowCredit.Text = "C"
        Me.BtnShowCredit.UseVisualStyleBackColor = True
        '
        'E_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnShowCredit)
        Me.Controls.Add(Me.btnShowDebit)
        Me.Controls.Add(Me.txtErn)
        Me.Controls.Add(Me.cmbConsolDebit)
        Me.Controls.Add(Me.cmbDebitAcc)
        Me.Controls.Add(Me.cmbCreditAcc)
        Me.Controls.Add(Me.CmbConsolCredit)
        Me.Controls.Add(Me.txtDebitAnal)
        Me.Controls.Add(Me.txtCreditAnal)
        Me.Name = "E_Interface"
        Me.Size = New System.Drawing.Size(557, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbConsolCredit As System.Windows.Forms.ComboBox
    Friend WithEvents cmbConsolDebit As System.Windows.Forms.ComboBox
    Friend WithEvents txtErn As System.Windows.Forms.Button
    Friend WithEvents txtCreditAnal As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitAnal As System.Windows.Forms.TextBox
    Friend WithEvents cmbCreditAcc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebitAcc As System.Windows.Forms.ComboBox
    Friend WithEvents btnShowDebit As System.Windows.Forms.Button
    Friend WithEvents BtnShowCredit As System.Windows.Forms.Button

End Class
