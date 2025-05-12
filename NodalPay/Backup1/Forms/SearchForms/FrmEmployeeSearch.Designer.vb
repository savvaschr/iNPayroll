<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmployeeSearch))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TermDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSearch = New System.Windows.Forms.Button
        Me.CBOnlyNew = New System.Windows.Forms.CheckBox
        Me.CBActive = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSINo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTICNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtARC = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSICat = New System.Windows.Forms.TextBox
        Me.ComboTempGroups = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        Me.CBNoSI = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.Location = New System.Drawing.Point(101, 37)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(280, 20)
        Me.txtDescription.TabIndex = 2
        '
        'txtCode
        '
        Me.txtCode.AcceptsReturn = True
        Me.txtCode.Location = New System.Drawing.Point(101, 16)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(191, 20)
        Me.txtCode.TabIndex = 1
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.FullName, Me.TemGroup, Me.Status, Me.StartDate, Me.TermDate})
        Me.DG1.Location = New System.Drawing.Point(3, 245)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(1073, 424)
        Me.DG1.TabIndex = 25
        '
        'Code
        '
        Me.Code.DataPropertyName = "Emp_Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'FullName
        '
        Me.FullName.DataPropertyName = "Emp_FullName"
        Me.FullName.HeaderText = "Name"
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        Me.FullName.Width = 300
        '
        'TemGroup
        '
        Me.TemGroup.DataPropertyName = "TemGrp_DescriptionL"
        Me.TemGroup.HeaderText = "Temp Group"
        Me.TemGroup.Name = "TemGroup"
        Me.TemGroup.Width = 300
        '
        'Status
        '
        Me.Status.DataPropertyName = "Emp_Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'StartDate
        '
        Me.StartDate.DataPropertyName = "Emp_StartDate"
        DataGridViewCellStyle1.Format = "dd/MM/yyyy"
        Me.StartDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.StartDate.HeaderText = "Start Date"
        Me.StartDate.Name = "StartDate"
        '
        'TermDate
        '
        Me.TermDate.DataPropertyName = "Emp_TerminateDate"
        Me.TermDate.HeaderText = "TerminationDate"
        Me.TermDate.Name = "TermDate"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(401, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'CBOnlyNew
        '
        Me.CBOnlyNew.AutoSize = True
        Me.CBOnlyNew.Location = New System.Drawing.Point(401, 65)
        Me.CBOnlyNew.Name = "CBOnlyNew"
        Me.CBOnlyNew.Size = New System.Drawing.Size(134, 17)
        Me.CBOnlyNew.TabIndex = 31
        Me.CBOnlyNew.Text = "ONLY New Employees"
        Me.CBOnlyNew.UseVisualStyleBackColor = True
        '
        'CBActive
        '
        Me.CBActive.AutoSize = True
        Me.CBActive.Location = New System.Drawing.Point(401, 42)
        Me.CBActive.Name = "CBActive"
        Me.CBActive.Size = New System.Drawing.Size(142, 17)
        Me.CBActive.TabIndex = 32
        Me.CBActive.Text = "ONLY Active Employees"
        Me.CBActive.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "S.I Number"
        '
        'txtSINo
        '
        Me.txtSINo.AcceptsReturn = True
        Me.txtSINo.Location = New System.Drawing.Point(101, 108)
        Me.txtSINo.Name = "txtSINo"
        Me.txtSINo.Size = New System.Drawing.Size(280, 20)
        Me.txtSINo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "ID Number"
        '
        'txtID
        '
        Me.txtID.AcceptsReturn = True
        Me.txtID.Location = New System.Drawing.Point(101, 130)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(280, 20)
        Me.txtID.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "TIC Number"
        '
        'txtTICNo
        '
        Me.txtTICNo.AcceptsReturn = True
        Me.txtTICNo.Location = New System.Drawing.Point(101, 152)
        Me.txtTICNo.Name = "txtTICNo"
        Me.txtTICNo.Size = New System.Drawing.Size(280, 20)
        Me.txtTICNo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "ARC Number"
        '
        'txtARC
        '
        Me.txtARC.AcceptsReturn = True
        Me.txtARC.Location = New System.Drawing.Point(101, 174)
        Me.txtARC.Name = "txtARC"
        Me.txtARC.Size = New System.Drawing.Size(280, 20)
        Me.txtARC.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "SI Cat"
        '
        'txtSICat
        '
        Me.txtSICat.AcceptsReturn = True
        Me.txtSICat.Location = New System.Drawing.Point(101, 196)
        Me.txtSICat.Name = "txtSICat"
        Me.txtSICat.Size = New System.Drawing.Size(55, 20)
        Me.txtSICat.TabIndex = 7
        '
        'ComboTempGroups
        '
        Me.ComboTempGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTempGroups.FormattingEnabled = True
        Me.ComboTempGroups.Location = New System.Drawing.Point(101, 61)
        Me.ComboTempGroups.Name = "ComboTempGroups"
        Me.ComboTempGroups.Size = New System.Drawing.Size(280, 21)
        Me.ComboTempGroups.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Template Group"
        '
        'BtnNext
        '
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(1001, 675)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 26
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Enabled = False
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(903, 675)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 27
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'CBNoSI
        '
        Me.CBNoSI.AutoSize = True
        Me.CBNoSI.Location = New System.Drawing.Point(401, 88)
        Me.CBNoSI.Name = "CBNoSI"
        Me.CBNoSI.Size = New System.Drawing.Size(169, 17)
        Me.CBNoSI.TabIndex = 45
        Me.CBNoSI.Text = "Employees with No SI Number"
        Me.CBNoSI.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Phone Number"
        '
        'txtPhone
        '
        Me.txtPhone.AcceptsReturn = True
        Me.txtPhone.Location = New System.Drawing.Point(101, 86)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(280, 20)
        Me.txtPhone.TabIndex = 46
        '
        'FrmEmployeeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1079, 698)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.CBNoSI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboTempGroups)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSICat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtARC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTICNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSINo)
        Me.Controls.Add(Me.CBActive)
        Me.Controls.Add(Me.CBOnlyNew)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmEmployeeSearch"
        Me.Text = "Employee Search"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents CBOnlyNew As System.Windows.Forms.CheckBox
    Friend WithEvents CBActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSINo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTICNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtARC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSICat As System.Windows.Forms.TextBox
    Friend WithEvents ComboTempGroups As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBNoSI As System.Windows.Forms.CheckBox
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TermDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
End Class
