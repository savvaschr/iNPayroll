<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_Control
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtFormula = New System.Windows.Forms.TextBox
        Me.ComboFrom = New System.Windows.Forms.ComboBox
        Me.ComboMode = New System.Windows.Forms.ComboBox
        Me.CBIsDisplayed = New System.Windows.Forms.CheckBox
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtLabel = New System.Windows.Forms.Button
        Me.BtnDone = New System.Windows.Forms.Button
        Me.txtNavDebitAccount = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtNavCreditAccount = New System.Windows.Forms.TextBox
        Me.lblDebit = New System.Windows.Forms.Label
        Me.lblCredit = New System.Windows.Forms.Label
        Me.txtSeq = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(385, 3)
        Me.txtFormula.MaxLength = 20
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(107, 20)
        Me.txtFormula.TabIndex = 11
        '
        'ComboFrom
        '
        Me.ComboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFrom.DropDownWidth = 150
        Me.ComboFrom.FormattingEnabled = True
        Me.ComboFrom.Location = New System.Drawing.Point(330, 3)
        Me.ComboFrom.Name = "ComboFrom"
        Me.ComboFrom.Size = New System.Drawing.Size(50, 21)
        Me.ComboFrom.TabIndex = 10
        '
        'ComboMode
        '
        Me.ComboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMode.DropDownWidth = 150
        Me.ComboMode.FormattingEnabled = True
        Me.ComboMode.Location = New System.Drawing.Point(275, 3)
        Me.ComboMode.Name = "ComboMode"
        Me.ComboMode.Size = New System.Drawing.Size(50, 21)
        Me.ComboMode.TabIndex = 9
        '
        'CBIsDisplayed
        '
        Me.CBIsDisplayed.AutoSize = True
        Me.CBIsDisplayed.Location = New System.Drawing.Point(246, 6)
        Me.CBIsDisplayed.Name = "CBIsDisplayed"
        Me.CBIsDisplayed.Size = New System.Drawing.Size(15, 14)
        Me.CBIsDisplayed.TabIndex = 8
        Me.CBIsDisplayed.UseVisualStyleBackColor = True
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(108, 3)
        Me.txtDisplay.MaxLength = 20
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(124, 20)
        Me.txtDisplay.TabIndex = 7
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.DropDownWidth = 150
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(36, 3)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(68, 21)
        Me.Combo1.TabIndex = 6
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'txtLabel
        '
        Me.txtLabel.BackColor = System.Drawing.Color.Yellow
        Me.txtLabel.Location = New System.Drawing.Point(4, 3)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(26, 20)
        Me.txtLabel.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtLabel, "Click to Set Navision Interface Account Code")
        Me.txtLabel.UseVisualStyleBackColor = False
        '
        'BtnDone
        '
        Me.BtnDone.BackColor = System.Drawing.Color.Yellow
        Me.BtnDone.Location = New System.Drawing.Point(404, 3)
        Me.BtnDone.Name = "BtnDone"
        Me.BtnDone.Size = New System.Drawing.Size(75, 20)
        Me.BtnDone.TabIndex = 15
        Me.BtnDone.Text = "Done"
        Me.BtnDone.UseVisualStyleBackColor = False
        Me.BtnDone.Visible = False
        '
        'txtNavDebitAccount
        '
        Me.txtNavDebitAccount.BackColor = System.Drawing.Color.Yellow
        Me.txtNavDebitAccount.Location = New System.Drawing.Point(272, 3)
        Me.txtNavDebitAccount.MaxLength = 20
        Me.txtNavDebitAccount.Name = "txtNavDebitAccount"
        Me.txtNavDebitAccount.Size = New System.Drawing.Size(126, 20)
        Me.txtNavDebitAccount.TabIndex = 16
        Me.txtNavDebitAccount.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.ReshowDelay = 100
        '
        'txtNavCreditAccount
        '
        Me.txtNavCreditAccount.BackColor = System.Drawing.Color.Yellow
        Me.txtNavCreditAccount.Location = New System.Drawing.Point(74, 3)
        Me.txtNavCreditAccount.MaxLength = 20
        Me.txtNavCreditAccount.Name = "txtNavCreditAccount"
        Me.txtNavCreditAccount.Size = New System.Drawing.Size(126, 20)
        Me.txtNavCreditAccount.TabIndex = 17
        Me.txtNavCreditAccount.Visible = False
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Location = New System.Drawing.Point(227, 7)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(32, 13)
        Me.lblDebit.TabIndex = 18
        Me.lblDebit.Text = "Debit"
        Me.lblDebit.Visible = False
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Location = New System.Drawing.Point(36, 6)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(34, 13)
        Me.lblCredit.TabIndex = 19
        Me.lblCredit.Text = "Credit"
        Me.lblCredit.Visible = False
        '
        'txtSeq
        '
        Me.txtSeq.Location = New System.Drawing.Point(498, 3)
        Me.txtSeq.MaxLength = 2
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(48, 20)
        Me.txtSeq.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button1.Location = New System.Drawing.Point(547, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Change on Pslips"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'C_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSeq)
        Me.Controls.Add(Me.lblCredit)
        Me.Controls.Add(Me.lblDebit)
        Me.Controls.Add(Me.txtNavCreditAccount)
        Me.Controls.Add(Me.txtNavDebitAccount)
        Me.Controls.Add(Me.BtnDone)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.ComboFrom)
        Me.Controls.Add(Me.ComboMode)
        Me.Controls.Add(Me.CBIsDisplayed)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.Combo1)
        Me.Name = "C_Control"
        Me.Size = New System.Drawing.Size(627, 27)
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents ComboFrom As System.Windows.Forms.ComboBox
    Friend WithEvents ComboMode As System.Windows.Forms.ComboBox
    Friend WithEvents CBIsDisplayed As System.Windows.Forms.CheckBox
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtNavDebitAccount As System.Windows.Forms.TextBox
    Friend WithEvents BtnDone As System.Windows.Forms.Button
    Friend WithEvents txtLabel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNavCreditAccount As System.Windows.Forms.TextBox
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDebit As System.Windows.Forms.Label
    Friend WithEvents txtSeq As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
