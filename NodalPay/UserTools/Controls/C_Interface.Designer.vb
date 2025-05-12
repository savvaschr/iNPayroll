<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_Interface
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
        Me.txtCon = New System.Windows.Forms.Button
        Me.cmbDebitAcc = New System.Windows.Forms.ComboBox
        Me.cmbCreditAcc = New System.Windows.Forms.ComboBox
        Me.BtnShowCredit = New System.Windows.Forms.Button
        Me.btnShowDebit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmbConsolDebit
        '
        Me.cmbConsolDebit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsolDebit.DropDownWidth = 120
        Me.cmbConsolDebit.FormattingEnabled = True
        Me.cmbConsolDebit.Location = New System.Drawing.Point(265, 2)
        Me.cmbConsolDebit.Name = "cmbConsolDebit"
        Me.cmbConsolDebit.Size = New System.Drawing.Size(34, 21)
        Me.cmbConsolDebit.TabIndex = 10
        '
        'CmbConsolCredit
        '
        Me.CmbConsolCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbConsolCredit.DropDownWidth = 120
        Me.CmbConsolCredit.FormattingEnabled = True
        Me.CmbConsolCredit.Location = New System.Drawing.Point(440, 2)
        Me.CmbConsolCredit.Name = "CmbConsolCredit"
        Me.CmbConsolCredit.Size = New System.Drawing.Size(34, 21)
        Me.CmbConsolCredit.TabIndex = 9
        '
        'txtCreditAnal
        '
        Me.txtCreditAnal.Location = New System.Drawing.Point(305, 2)
        Me.txtCreditAnal.Name = "txtCreditAnal"
        Me.txtCreditAnal.Size = New System.Drawing.Size(129, 20)
        Me.txtCreditAnal.TabIndex = 11
        Me.txtCreditAnal.Visible = False
        '
        'txtDebitAnal
        '
        Me.txtDebitAnal.Location = New System.Drawing.Point(130, 2)
        Me.txtDebitAnal.Name = "txtDebitAnal"
        Me.txtDebitAnal.Size = New System.Drawing.Size(129, 20)
        Me.txtDebitAnal.TabIndex = 12
        Me.txtDebitAnal.Visible = False
        '
        'txtCon
        '
        Me.txtCon.BackColor = System.Drawing.Color.Yellow
        Me.txtCon.Location = New System.Drawing.Point(3, 2)
        Me.txtCon.Name = "txtCon"
        Me.txtCon.Size = New System.Drawing.Size(121, 23)
        Me.txtCon.TabIndex = 13
        Me.txtCon.UseVisualStyleBackColor = False
        '
        'cmbDebitAcc
        '
        Me.cmbDebitAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDebitAcc.FormattingEnabled = True
        Me.cmbDebitAcc.Location = New System.Drawing.Point(130, 2)
        Me.cmbDebitAcc.Name = "cmbDebitAcc"
        Me.cmbDebitAcc.Size = New System.Drawing.Size(129, 21)
        Me.cmbDebitAcc.TabIndex = 15
        '
        'cmbCreditAcc
        '
        Me.cmbCreditAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCreditAcc.FormattingEnabled = True
        Me.cmbCreditAcc.Location = New System.Drawing.Point(305, 2)
        Me.cmbCreditAcc.Name = "cmbCreditAcc"
        Me.cmbCreditAcc.Size = New System.Drawing.Size(129, 21)
        Me.cmbCreditAcc.TabIndex = 16
        '
        'BtnShowCredit
        '
        Me.BtnShowCredit.Location = New System.Drawing.Point(518, 2)
        Me.BtnShowCredit.Name = "BtnShowCredit"
        Me.BtnShowCredit.Size = New System.Drawing.Size(33, 23)
        Me.BtnShowCredit.TabIndex = 18
        Me.BtnShowCredit.Text = "C"
        Me.BtnShowCredit.UseVisualStyleBackColor = True
        '
        'btnShowDebit
        '
        Me.btnShowDebit.Location = New System.Drawing.Point(480, 2)
        Me.btnShowDebit.Name = "btnShowDebit"
        Me.btnShowDebit.Size = New System.Drawing.Size(32, 23)
        Me.btnShowDebit.TabIndex = 17
        Me.btnShowDebit.Text = "D"
        Me.btnShowDebit.UseVisualStyleBackColor = True
        '
        'C_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnShowCredit)
        Me.Controls.Add(Me.btnShowDebit)
        Me.Controls.Add(Me.cmbCreditAcc)
        Me.Controls.Add(Me.cmbDebitAcc)
        Me.Controls.Add(Me.txtCon)
        Me.Controls.Add(Me.txtDebitAnal)
        Me.Controls.Add(Me.txtCreditAnal)
        Me.Controls.Add(Me.cmbConsolDebit)
        Me.Controls.Add(Me.CmbConsolCredit)
        Me.Name = "C_Interface"
        Me.Size = New System.Drawing.Size(557, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbConsolDebit As System.Windows.Forms.ComboBox
    Friend WithEvents CmbConsolCredit As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreditAnal As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitAnal As System.Windows.Forms.TextBox
    Friend WithEvents txtCon As System.Windows.Forms.Button
    Friend WithEvents cmbDebitAcc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCreditAcc As System.Windows.Forms.ComboBox
    Friend WithEvents BtnShowCredit As System.Windows.Forms.Button
    Friend WithEvents btnShowDebit As System.Windows.Forms.Button

End Class
