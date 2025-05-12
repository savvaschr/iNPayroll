<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.txtTotaltime = New System.Windows.Forms.TextBox
        Me.Combo = New System.Windows.Forms.ComboBox
        Me.TimeFrom = New System.Windows.Forms.MaskedTextBox
        Me.TimeTo = New System.Windows.Forms.MaskedTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txtDateAndDay = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.ComboAnal = New System.Windows.Forms.ComboBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.txtCost = New System.Windows.Forms.TextBox
        Me.txtTotalCost = New System.Windows.Forms.TextBox
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotaltime
        '
        Me.txtTotaltime.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotaltime.Location = New System.Drawing.Point(302, 52)
        Me.txtTotaltime.Name = "txtTotaltime"
        Me.txtTotaltime.ReadOnly = True
        Me.txtTotaltime.Size = New System.Drawing.Size(73, 20)
        Me.txtTotaltime.TabIndex = 1
        '
        'Combo
        '
        Me.Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo.FormattingEnabled = True
        Me.Combo.Location = New System.Drawing.Point(2, 51)
        Me.Combo.Name = "Combo"
        Me.Combo.Size = New System.Drawing.Size(128, 21)
        Me.Combo.TabIndex = 0
        '
        'TimeFrom
        '
        Me.TimeFrom.Location = New System.Drawing.Point(136, 52)
        Me.TimeFrom.Mask = "00:00"
        Me.TimeFrom.Name = "TimeFrom"
        Me.TimeFrom.Size = New System.Drawing.Size(69, 20)
        Me.TimeFrom.TabIndex = 8
        Me.TimeFrom.ValidatingType = GetType(Date)
        '
        'TimeTo
        '
        Me.TimeTo.Location = New System.Drawing.Point(221, 51)
        Me.TimeTo.Mask = "00:00"
        Me.TimeTo.Name = "TimeTo"
        Me.TimeTo.Size = New System.Drawing.Size(63, 20)
        Me.TimeTo.TabIndex = 9
        Me.TimeTo.ValidatingType = GetType(Date)
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Aqua
        Me.TextBox1.Location = New System.Drawing.Point(2, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(128, 20)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "WORK TYPE"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Aqua
        Me.TextBox2.Location = New System.Drawing.Point(136, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.Text = "FROM TIME"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Aqua
        Me.TextBox3.Location = New System.Drawing.Point(221, 28)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(63, 20)
        Me.TextBox3.TabIndex = 12
        Me.TextBox3.Text = "TO TIME"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.Aqua
        Me.TextBox4.Location = New System.Drawing.Point(302, 28)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(73, 20)
        Me.TextBox4.TabIndex = 13
        Me.TextBox4.Text = "TOTAL TIME"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDateAndDay
        '
        Me.txtDateAndDay.BackColor = System.Drawing.Color.Aqua
        Me.txtDateAndDay.Location = New System.Drawing.Point(2, 2)
        Me.txtDateAndDay.Name = "txtDateAndDay"
        Me.txtDateAndDay.ReadOnly = True
        Me.txtDateAndDay.Size = New System.Drawing.Size(373, 20)
        Me.txtDateAndDay.TabIndex = 14
        Me.txtDateAndDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 296)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 23)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(491, 296)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(174, 23)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit without Save"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.Aqua
        Me.TextBox5.Location = New System.Drawing.Point(381, 28)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(290, 20)
        Me.TextBox5.TabIndex = 19
        Me.TextBox5.Text = "ANALYSIS"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboAnal
        '
        Me.ComboAnal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnal.FormattingEnabled = True
        Me.ComboAnal.Location = New System.Drawing.Point(381, 51)
        Me.ComboAnal.Name = "ComboAnal"
        Me.ComboAnal.Size = New System.Drawing.Size(290, 21)
        Me.ComboAnal.TabIndex = 20
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.Aqua
        Me.TextBox6.Location = New System.Drawing.Point(701, 28)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(91, 20)
        Me.TextBox6.TabIndex = 22
        Me.TextBox6.Text = "Cost"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCost
        '
        Me.txtCost.BackColor = System.Drawing.SystemColors.Info
        Me.txtCost.Location = New System.Drawing.Point(701, 52)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.ReadOnly = True
        Me.txtCost.Size = New System.Drawing.Size(91, 20)
        Me.txtCost.TabIndex = 21
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalCost.Location = New System.Drawing.Point(698, 296)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalCost.TabIndex = 23
        Me.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmTaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 331)
        Me.Controls.Add(Me.txtTotalCost)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.txtCost)
        Me.Controls.Add(Me.ComboAnal)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtDateAndDay)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TimeTo)
        Me.Controls.Add(Me.TimeFrom)
        Me.Controls.Add(Me.Combo)
        Me.Controls.Add(Me.txtTotaltime)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTaForm"
        Me.Text = "Units Worked / Work Type"
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTotaltime As System.Windows.Forms.TextBox
    Friend WithEvents Combo As System.Windows.Forms.ComboBox
    Friend WithEvents TimeFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TimeTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDateAndDay As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ComboAnal As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
End Class
