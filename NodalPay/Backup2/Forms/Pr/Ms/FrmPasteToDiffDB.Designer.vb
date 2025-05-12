<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPasteToDiffDB
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNewCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbTemGrp_Code = New System.Windows.Forms.ComboBox
        Me.cmbIntTem_Code = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblTemGrp_Code = New System.Windows.Forms.Label
        Me.cmbIntPF = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbIntMF = New System.Windows.Forms.ComboBox
        Me.lblEmpAn3_Code = New System.Windows.Forms.Label
        Me.lblEmpAn4_Code = New System.Windows.Forms.Label
        Me.lblEmpAn5_Code = New System.Windows.Forms.Label
        Me.cmbEmpAn3_Code = New System.Windows.Forms.ComboBox
        Me.cmbEmpAn4_Code = New System.Windows.Forms.ComboBox
        Me.cmbEmpAn5_Code = New System.Windows.Forms.ComboBox
        Me.cmbUni_Code = New System.Windows.Forms.ComboBox
        Me.lblUni_Code = New System.Windows.Forms.Label
        Me.lblEmpAn1_Code = New System.Windows.Forms.Label
        Me.lblEmpAn2_Code = New System.Windows.Forms.Label
        Me.cmbEmpAn2_Code = New System.Windows.Forms.ComboBox
        Me.cmbEmpAn1_Code = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPeriodGroup = New System.Windows.Forms.TextBox
        Me.ComboPosition = New System.Windows.Forms.ComboBox
        Me.Position = New System.Windows.Forms.Label
        Me.ComboEmpBank = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboComBank = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database Name"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(157, 23)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(275, 20)
        Me.txtServerName.TabIndex = 1
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(157, 49)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(275, 20)
        Me.txtDBName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Server Name"
        '
        'txtNewCode
        '
        Me.txtNewCode.Location = New System.Drawing.Point(157, 145)
        Me.txtNewCode.Name = "txtNewCode"
        Me.txtNewCode.Size = New System.Drawing.Size(275, 20)
        Me.txtNewCode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "New Code"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(461, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Connect to DB"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbTemGrp_Code
        '
        Me.cmbTemGrp_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemGrp_Code.Location = New System.Drawing.Point(157, 187)
        Me.cmbTemGrp_Code.Name = "cmbTemGrp_Code"
        Me.cmbTemGrp_Code.Size = New System.Drawing.Size(190, 21)
        Me.cmbTemGrp_Code.TabIndex = 73
        '
        'cmbIntTem_Code
        '
        Me.cmbIntTem_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntTem_Code.Location = New System.Drawing.Point(157, 214)
        Me.cmbIntTem_Code.Name = "cmbIntTem_Code"
        Me.cmbIntTem_Code.Size = New System.Drawing.Size(190, 21)
        Me.cmbIntTem_Code.TabIndex = 74
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Interface Template"
        '
        'lblTemGrp_Code
        '
        Me.lblTemGrp_Code.AutoSize = True
        Me.lblTemGrp_Code.Location = New System.Drawing.Point(25, 190)
        Me.lblTemGrp_Code.Name = "lblTemGrp_Code"
        Me.lblTemGrp_Code.Size = New System.Drawing.Size(83, 13)
        Me.lblTemGrp_Code.TabIndex = 72
        Me.lblTemGrp_Code.Text = "Template Group"
        '
        'cmbIntPF
        '
        Me.cmbIntPF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntPF.Location = New System.Drawing.Point(157, 238)
        Me.cmbIntPF.Name = "cmbIntPF"
        Me.cmbIntPF.Size = New System.Drawing.Size(190, 21)
        Me.cmbIntPF.TabIndex = 76
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(25, 270)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Interface Medical Fund"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(25, 246)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Interface Prov. Fund"
        '
        'cmbIntMF
        '
        Me.cmbIntMF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntMF.Location = New System.Drawing.Point(157, 262)
        Me.cmbIntMF.Name = "cmbIntMF"
        Me.cmbIntMF.Size = New System.Drawing.Size(190, 21)
        Me.cmbIntMF.TabIndex = 78
        '
        'lblEmpAn3_Code
        '
        Me.lblEmpAn3_Code.AutoSize = True
        Me.lblEmpAn3_Code.Location = New System.Drawing.Point(25, 415)
        Me.lblEmpAn3_Code.Name = "lblEmpAn3_Code"
        Me.lblEmpAn3_Code.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpAn3_Code.TabIndex = 84
        Me.lblEmpAn3_Code.Text = "Analysis 3"
        '
        'lblEmpAn4_Code
        '
        Me.lblEmpAn4_Code.AutoSize = True
        Me.lblEmpAn4_Code.Location = New System.Drawing.Point(25, 441)
        Me.lblEmpAn4_Code.Name = "lblEmpAn4_Code"
        Me.lblEmpAn4_Code.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpAn4_Code.TabIndex = 87
        Me.lblEmpAn4_Code.Text = "Analysis 4"
        '
        'lblEmpAn5_Code
        '
        Me.lblEmpAn5_Code.AutoSize = True
        Me.lblEmpAn5_Code.Location = New System.Drawing.Point(25, 467)
        Me.lblEmpAn5_Code.Name = "lblEmpAn5_Code"
        Me.lblEmpAn5_Code.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpAn5_Code.TabIndex = 89
        Me.lblEmpAn5_Code.Text = "Analysis 5"
        '
        'cmbEmpAn3_Code
        '
        Me.cmbEmpAn3_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpAn3_Code.Location = New System.Drawing.Point(157, 415)
        Me.cmbEmpAn3_Code.Name = "cmbEmpAn3_Code"
        Me.cmbEmpAn3_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbEmpAn3_Code.TabIndex = 85
        '
        'cmbEmpAn4_Code
        '
        Me.cmbEmpAn4_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpAn4_Code.Location = New System.Drawing.Point(157, 441)
        Me.cmbEmpAn4_Code.Name = "cmbEmpAn4_Code"
        Me.cmbEmpAn4_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbEmpAn4_Code.TabIndex = 86
        '
        'cmbEmpAn5_Code
        '
        Me.cmbEmpAn5_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpAn5_Code.Location = New System.Drawing.Point(157, 467)
        Me.cmbEmpAn5_Code.Name = "cmbEmpAn5_Code"
        Me.cmbEmpAn5_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbEmpAn5_Code.TabIndex = 88
        '
        'cmbUni_Code
        '
        Me.cmbUni_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUni_Code.Location = New System.Drawing.Point(157, 493)
        Me.cmbUni_Code.Name = "cmbUni_Code"
        Me.cmbUni_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbUni_Code.TabIndex = 91
        '
        'lblUni_Code
        '
        Me.lblUni_Code.AutoSize = True
        Me.lblUni_Code.Location = New System.Drawing.Point(25, 493)
        Me.lblUni_Code.Name = "lblUni_Code"
        Me.lblUni_Code.Size = New System.Drawing.Size(35, 13)
        Me.lblUni_Code.TabIndex = 90
        Me.lblUni_Code.Text = "Union"
        '
        'lblEmpAn1_Code
        '
        Me.lblEmpAn1_Code.AutoSize = True
        Me.lblEmpAn1_Code.Location = New System.Drawing.Point(25, 363)
        Me.lblEmpAn1_Code.Name = "lblEmpAn1_Code"
        Me.lblEmpAn1_Code.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpAn1_Code.TabIndex = 80
        Me.lblEmpAn1_Code.Text = "Analysis 1"
        '
        'lblEmpAn2_Code
        '
        Me.lblEmpAn2_Code.AutoSize = True
        Me.lblEmpAn2_Code.Location = New System.Drawing.Point(25, 389)
        Me.lblEmpAn2_Code.Name = "lblEmpAn2_Code"
        Me.lblEmpAn2_Code.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpAn2_Code.TabIndex = 82
        Me.lblEmpAn2_Code.Text = "Analysis 2"
        '
        'cmbEmpAn2_Code
        '
        Me.cmbEmpAn2_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpAn2_Code.Location = New System.Drawing.Point(157, 389)
        Me.cmbEmpAn2_Code.Name = "cmbEmpAn2_Code"
        Me.cmbEmpAn2_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbEmpAn2_Code.TabIndex = 83
        '
        'cmbEmpAn1_Code
        '
        Me.cmbEmpAn1_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpAn1_Code.Location = New System.Drawing.Point(157, 363)
        Me.cmbEmpAn1_Code.Name = "cmbEmpAn1_Code"
        Me.cmbEmpAn1_Code.Size = New System.Drawing.Size(483, 21)
        Me.cmbEmpAn1_Code.TabIndex = 81
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(461, 142)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 23)
        Me.Button2.TabIndex = 92
        Me.Button2.Text = "Paste"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 311)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Period Group"
        '
        'txtPeriodGroup
        '
        Me.txtPeriodGroup.Location = New System.Drawing.Point(157, 308)
        Me.txtPeriodGroup.Name = "txtPeriodGroup"
        Me.txtPeriodGroup.ReadOnly = True
        Me.txtPeriodGroup.Size = New System.Drawing.Size(190, 20)
        Me.txtPeriodGroup.TabIndex = 95
        '
        'ComboPosition
        '
        Me.ComboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPosition.Location = New System.Drawing.Point(157, 520)
        Me.ComboPosition.Name = "ComboPosition"
        Me.ComboPosition.Size = New System.Drawing.Size(483, 21)
        Me.ComboPosition.TabIndex = 97
        '
        'Position
        '
        Me.Position.AutoSize = True
        Me.Position.Location = New System.Drawing.Point(25, 520)
        Me.Position.Name = "Position"
        Me.Position.Size = New System.Drawing.Size(93, 13)
        Me.Position.TabIndex = 96
        Me.Position.Text = "Employee Position"
        '
        'ComboEmpBank
        '
        Me.ComboEmpBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpBank.Location = New System.Drawing.Point(157, 547)
        Me.ComboEmpBank.Name = "ComboEmpBank"
        Me.ComboEmpBank.Size = New System.Drawing.Size(483, 21)
        Me.ComboEmpBank.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Employee Bank"
        '
        'ComboComBank
        '
        Me.ComboComBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComBank.Location = New System.Drawing.Point(157, 574)
        Me.ComboComBank.Name = "ComboComBank"
        Me.ComboComBank.Size = New System.Drawing.Size(483, 21)
        Me.ComboComBank.TabIndex = 101
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 574)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Company Bank"
        '
        'FrmPasteToDiffDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 665)
        Me.Controls.Add(Me.ComboComBank)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboEmpBank)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboPosition)
        Me.Controls.Add(Me.Position)
        Me.Controls.Add(Me.txtPeriodGroup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblEmpAn3_Code)
        Me.Controls.Add(Me.lblEmpAn4_Code)
        Me.Controls.Add(Me.lblEmpAn5_Code)
        Me.Controls.Add(Me.cmbEmpAn3_Code)
        Me.Controls.Add(Me.cmbEmpAn4_Code)
        Me.Controls.Add(Me.cmbEmpAn5_Code)
        Me.Controls.Add(Me.cmbUni_Code)
        Me.Controls.Add(Me.lblUni_Code)
        Me.Controls.Add(Me.lblEmpAn1_Code)
        Me.Controls.Add(Me.lblEmpAn2_Code)
        Me.Controls.Add(Me.cmbEmpAn2_Code)
        Me.Controls.Add(Me.cmbEmpAn1_Code)
        Me.Controls.Add(Me.cmbTemGrp_Code)
        Me.Controls.Add(Me.cmbIntTem_Code)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblTemGrp_Code)
        Me.Controls.Add(Me.cmbIntPF)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbIntMF)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtNewCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPasteToDiffDB"
        Me.Text = "Create Employee in Different Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbTemGrp_Code As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIntTem_Code As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblTemGrp_Code As System.Windows.Forms.Label
    Friend WithEvents cmbIntPF As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbIntMF As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpAn3_Code As System.Windows.Forms.Label
    Friend WithEvents lblEmpAn4_Code As System.Windows.Forms.Label
    Friend WithEvents lblEmpAn5_Code As System.Windows.Forms.Label
    Friend WithEvents cmbEmpAn3_Code As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpAn4_Code As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpAn5_Code As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUni_Code As System.Windows.Forms.ComboBox
    Friend WithEvents lblUni_Code As System.Windows.Forms.Label
    Friend WithEvents lblEmpAn1_Code As System.Windows.Forms.Label
    Friend WithEvents lblEmpAn2_Code As System.Windows.Forms.Label
    Friend WithEvents cmbEmpAn2_Code As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpAn1_Code As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodGroup As System.Windows.Forms.TextBox
    Friend WithEvents ComboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Position As System.Windows.Forms.Label
    Friend WithEvents ComboEmpBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboComBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
