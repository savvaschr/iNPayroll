<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeriods
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
        Me.StartDate1 = New System.Windows.Forms.MaskedTextBox
        Me.EndDate1 = New System.Windows.Forms.MaskedTextBox
        Me.ComboStatus1 = New System.Windows.Forms.ComboBox
        Me.txtP1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCreatePeriods = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboYears = New System.Windows.Forms.ComboBox
        Me.FiscalYearTo = New System.Windows.Forms.MaskedTextBox
        Me.FiscalYearFROM = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnSavePeriods = New System.Windows.Forms.Button
        Me.txtNOfDays = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartDate1
        '
        Me.StartDate1.Location = New System.Drawing.Point(136, 109)
        Me.StartDate1.Mask = "00/00/0000"
        Me.StartDate1.Name = "StartDate1"
        Me.StartDate1.Size = New System.Drawing.Size(100, 20)
        Me.StartDate1.TabIndex = 2
        Me.StartDate1.ValidatingType = GetType(Date)
        Me.StartDate1.Visible = False
        '
        'EndDate1
        '
        Me.EndDate1.Location = New System.Drawing.Point(250, 109)
        Me.EndDate1.Mask = "00/00/0000"
        Me.EndDate1.Name = "EndDate1"
        Me.EndDate1.Size = New System.Drawing.Size(100, 20)
        Me.EndDate1.TabIndex = 3
        Me.EndDate1.ValidatingType = GetType(Date)
        Me.EndDate1.Visible = False
        '
        'ComboStatus1
        '
        Me.ComboStatus1.FormattingEnabled = True
        Me.ComboStatus1.Location = New System.Drawing.Point(439, 109)
        Me.ComboStatus1.Name = "ComboStatus1"
        Me.ComboStatus1.Size = New System.Drawing.Size(103, 21)
        Me.ComboStatus1.TabIndex = 5
        Me.ComboStatus1.Visible = False
        '
        'txtP1
        '
        Me.txtP1.Location = New System.Drawing.Point(22, 109)
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(100, 20)
        Me.txtP1.TabIndex = 1
        Me.txtP1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fiscal Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Start Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(247, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Status"
        '
        'btnCreatePeriods
        '
        Me.btnCreatePeriods.Location = New System.Drawing.Point(15, 19)
        Me.btnCreatePeriods.Name = "btnCreatePeriods"
        Me.btnCreatePeriods.Size = New System.Drawing.Size(92, 23)
        Me.btnCreatePeriods.TabIndex = 3
        Me.btnCreatePeriods.Text = "Create Periods"
        Me.btnCreatePeriods.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboYears)
        Me.GroupBox1.Controls.Add(Me.FiscalYearTo)
        Me.GroupBox1.Controls.Add(Me.FiscalYearFROM)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 63)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'ComboYears
        '
        Me.ComboYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboYears.FormattingEnabled = True
        Me.ComboYears.Location = New System.Drawing.Point(72, 18)
        Me.ComboYears.Name = "ComboYears"
        Me.ComboYears.Size = New System.Drawing.Size(97, 21)
        Me.ComboYears.TabIndex = 14
        Me.ComboYears.Tag = "1"
        '
        'FiscalYearTo
        '
        Me.FiscalYearTo.Location = New System.Drawing.Point(298, 19)
        Me.FiscalYearTo.Mask = "00/00/0000"
        Me.FiscalYearTo.Name = "FiscalYearTo"
        Me.FiscalYearTo.Size = New System.Drawing.Size(100, 20)
        Me.FiscalYearTo.TabIndex = 1
        Me.FiscalYearTo.Tag = "3"
        '
        'FiscalYearFROM
        '
        Me.FiscalYearFROM.Location = New System.Drawing.Point(185, 19)
        Me.FiscalYearFROM.Mask = "00/00/0000"
        Me.FiscalYearFROM.Name = "FiscalYearFROM"
        Me.FiscalYearFROM.Size = New System.Drawing.Size(100, 20)
        Me.FiscalYearFROM.TabIndex = 0
        Me.FiscalYearFROM.Tag = "2"
        Me.FiscalYearFROM.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fiscal Year"
        '
        'btnSavePeriods
        '
        Me.btnSavePeriods.Location = New System.Drawing.Point(15, 48)
        Me.btnSavePeriods.Name = "btnSavePeriods"
        Me.btnSavePeriods.Size = New System.Drawing.Size(92, 23)
        Me.btnSavePeriods.TabIndex = 15
        Me.btnSavePeriods.Text = "Save"
        Me.btnSavePeriods.UseVisualStyleBackColor = True
        '
        'txtNOfDays
        '
        Me.txtNOfDays.Location = New System.Drawing.Point(364, 109)
        Me.txtNOfDays.Name = "txtNOfDays"
        Me.txtNOfDays.Size = New System.Drawing.Size(61, 20)
        Me.txtNOfDays.TabIndex = 4
        Me.txtNOfDays.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(361, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "No. Of Days"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCreatePeriods)
        Me.GroupBox2.Controls.Add(Me.btnSavePeriods)
        Me.GroupBox2.Location = New System.Drawing.Point(697, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 145)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'FrmPeriods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(861, 605)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNOfDays)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtP1)
        Me.Controls.Add(Me.ComboStatus1)
        Me.Controls.Add(Me.EndDate1)
        Me.Controls.Add(Me.StartDate1)
        Me.Name = "FrmPeriods"
        Me.Text = "Fiscal Year - Periods Maintenance"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartDate1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents EndDate1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboStatus1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtP1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCreatePeriods As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FiscalYearTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents FiscalYearFROM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboYears As System.Windows.Forms.ComboBox
    Friend WithEvents btnSavePeriods As System.Windows.Forms.Button
    Friend WithEvents txtNOfDays As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
