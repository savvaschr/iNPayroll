<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadEDCFromExcel
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
        Me.btnOpen = New System.Windows.Forms.Button
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.txtToFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnProceed = New System.Windows.Forms.Button
        Me.txtFirstLineToRead = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmployeeColumnNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEDCValueColumn = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboEDC = New System.Windows.Forms.ComboBox
        Me.CBLoadUnits = New System.Windows.Forms.CheckBox
        Me.CBSetdiffInSI = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(793, 126)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(33, 23)
        Me.btnOpen.TabIndex = 22
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtToFile
        '
        Me.txtToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtToFile.Location = New System.Drawing.Point(224, 128)
        Me.txtToFile.Name = "txtToFile"
        Me.txtToFile.Size = New System.Drawing.Size(563, 20)
        Me.txtToFile.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Select File To Upload"
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(224, 168)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 23
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'txtFirstLineToRead
        '
        Me.txtFirstLineToRead.Location = New System.Drawing.Point(224, 52)
        Me.txtFirstLineToRead.Name = "txtFirstLineToRead"
        Me.txtFirstLineToRead.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstLineToRead.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "First Excel Line to Read"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Employee Code Column Number in Excel"
        '
        'txtEmployeeColumnNo
        '
        Me.txtEmployeeColumnNo.Location = New System.Drawing.Point(224, 78)
        Me.txtEmployeeColumnNo.Name = "txtEmployeeColumnNo"
        Me.txtEmployeeColumnNo.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeeColumnNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "EDC Value Column Number in Excel"
        '
        'txtEDCValueColumn
        '
        Me.txtEDCValueColumn.Location = New System.Drawing.Point(224, 102)
        Me.txtEDCValueColumn.Name = "txtEDCValueColumn"
        Me.txtEDCValueColumn.Size = New System.Drawing.Size(121, 20)
        Me.txtEDCValueColumn.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "EDC Code in Payroll"
        '
        'ComboEDC
        '
        Me.ComboEDC.FormattingEnabled = True
        Me.ComboEDC.Location = New System.Drawing.Point(224, 25)
        Me.ComboEDC.Name = "ComboEDC"
        Me.ComboEDC.Size = New System.Drawing.Size(344, 21)
        Me.ComboEDC.TabIndex = 1
        '
        'CBLoadUnits
        '
        Me.CBLoadUnits.AutoSize = True
        Me.CBLoadUnits.Location = New System.Drawing.Point(624, 27)
        Me.CBLoadUnits.Name = "CBLoadUnits"
        Me.CBLoadUnits.Size = New System.Drawing.Size(77, 17)
        Me.CBLoadUnits.TabIndex = 34
        Me.CBLoadUnits.Text = "Load Units" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.CBLoadUnits.UseVisualStyleBackColor = True
        '
        'CBSetdiffInSI
        '
        Me.CBSetdiffInSI.AutoSize = True
        Me.CBSetdiffInSI.Location = New System.Drawing.Point(749, 27)
        Me.CBSetdiffInSI.Name = "CBSetdiffInSI"
        Me.CBSetdiffInSI.Size = New System.Drawing.Size(145, 17)
        Me.CBSetdiffInSI.TabIndex = 35
        Me.CBSetdiffInSI.Text = "Set Difference in SI Units"
        Me.CBSetdiffInSI.UseVisualStyleBackColor = True
        Me.CBSetdiffInSI.Visible = False
        '
        'FrmLoadEDCFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 217)
        Me.Controls.Add(Me.CBSetdiffInSI)
        Me.Controls.Add(Me.CBLoadUnits)
        Me.Controls.Add(Me.ComboEDC)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEDCValueColumn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmployeeColumnNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstLineToRead)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtToFile)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmLoadEDCFromExcel"
        Me.Text = "Load EDC From Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtToFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents txtFirstLineToRead As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeColumnNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEDCValueColumn As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboEDC As System.Windows.Forms.ComboBox
    Friend WithEvents CBLoadUnits As System.Windows.Forms.CheckBox
    Friend WithEvents CBSetdiffInSI As System.Windows.Forms.CheckBox
End Class
