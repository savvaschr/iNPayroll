<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewCompany
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
        Me.ComboCompany = New System.Windows.Forms.ComboBox()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescL = New System.Windows.Forms.TextBox()
        Me.txtDescS = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTempGroup = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPeriodGroup = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPeriodDesc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboTempGroup = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTempDescL = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTempDescS = New System.Windows.Forms.TextBox()
        Me.ComboPerGroup = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboInterfaceGroup = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNewInterfaceGroupDesc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNewInterfaceGroup = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ComboCompany
        '
        Me.ComboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCompany.FormattingEnabled = True
        Me.ComboCompany.Location = New System.Drawing.Point(220, 98)
        Me.ComboCompany.Name = "ComboCompany"
        Me.ComboCompany.Size = New System.Drawing.Size(271, 21)
        Me.ComboCompany.TabIndex = 0
        '
        'BtnCreate
        '
        Me.BtnCreate.Location = New System.Drawing.Point(220, 428)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(271, 23)
        Me.BtnCreate.TabIndex = 9
        Me.BtnCreate.Text = "Create"
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Based on Company"
        '
        'txtDescL
        '
        Me.txtDescL.Location = New System.Drawing.Point(220, 48)
        Me.txtDescL.MaxLength = 100
        Me.txtDescL.Name = "txtDescL"
        Me.txtDescL.Size = New System.Drawing.Size(437, 20)
        Me.txtDescL.TabIndex = 2
        '
        'txtDescS
        '
        Me.txtDescS.Location = New System.Drawing.Point(220, 72)
        Me.txtDescS.MaxLength = 30
        Me.txtDescS.Name = "txtDescS"
        Me.txtDescS.Size = New System.Drawing.Size(271, 20)
        Me.txtDescS.TabIndex = 3
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(220, 24)
        Me.txtCode.MaxLength = 8
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Short Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Long Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "New Company Code"
        '
        'txtTempGroup
        '
        Me.txtTempGroup.Location = New System.Drawing.Point(220, 219)
        Me.txtTempGroup.MaxLength = 6
        Me.txtTempGroup.Name = "txtTempGroup"
        Me.txtTempGroup.Size = New System.Drawing.Size(100, 20)
        Me.txtTempGroup.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "New Template Group"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "New Period Group"
        '
        'txtPeriodGroup
        '
        Me.txtPeriodGroup.Location = New System.Drawing.Point(220, 303)
        Me.txtPeriodGroup.MaxLength = 6
        Me.txtPeriodGroup.Name = "txtPeriodGroup"
        Me.txtPeriodGroup.Size = New System.Drawing.Size(100, 20)
        Me.txtPeriodGroup.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 332)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Period Group Description"
        '
        'txtPeriodDesc
        '
        Me.txtPeriodDesc.Location = New System.Drawing.Point(220, 327)
        Me.txtPeriodDesc.MaxLength = 40
        Me.txtPeriodDesc.Name = "txtPeriodDesc"
        Me.txtPeriodDesc.Size = New System.Drawing.Size(271, 20)
        Me.txtPeriodDesc.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Based on Template Group"
        '
        'ComboTempGroup
        '
        Me.ComboTempGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTempGroup.FormattingEnabled = True
        Me.ComboTempGroup.Location = New System.Drawing.Point(220, 125)
        Me.ComboTempGroup.Name = "ComboTempGroup"
        Me.ComboTempGroup.Size = New System.Drawing.Size(271, 21)
        Me.ComboTempGroup.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "New Template Group Description"
        '
        'txtTempDescL
        '
        Me.txtTempDescL.Location = New System.Drawing.Point(220, 243)
        Me.txtTempDescL.MaxLength = 40
        Me.txtTempDescL.Name = "txtTempDescL"
        Me.txtTempDescL.Size = New System.Drawing.Size(271, 20)
        Me.txtTempDescL.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(25, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(192, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "New Template Group Short Description"
        '
        'txtTempDescS
        '
        Me.txtTempDescS.Location = New System.Drawing.Point(220, 269)
        Me.txtTempDescS.MaxLength = 15
        Me.txtTempDescS.Name = "txtTempDescS"
        Me.txtTempDescS.Size = New System.Drawing.Size(271, 20)
        Me.txtTempDescS.TabIndex = 6
        '
        'ComboPerGroup
        '
        Me.ComboPerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPerGroup.FormattingEnabled = True
        Me.ComboPerGroup.Location = New System.Drawing.Point(220, 152)
        Me.ComboPerGroup.Name = "ComboPerGroup"
        Me.ComboPerGroup.Size = New System.Drawing.Size(271, 21)
        Me.ComboPerGroup.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Based on Period Group"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 183)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Based on Interface Group"
        '
        'ComboInterfaceGroup
        '
        Me.ComboInterfaceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboInterfaceGroup.FormattingEnabled = True
        Me.ComboInterfaceGroup.Location = New System.Drawing.Point(220, 179)
        Me.ComboInterfaceGroup.Name = "ComboInterfaceGroup"
        Me.ComboInterfaceGroup.Size = New System.Drawing.Size(271, 21)
        Me.ComboInterfaceGroup.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(162, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "New Interface Group Description"
        '
        'txtNewInterfaceGroupDesc
        '
        Me.txtNewInterfaceGroupDesc.Location = New System.Drawing.Point(220, 386)
        Me.txtNewInterfaceGroupDesc.MaxLength = 40
        Me.txtNewInterfaceGroupDesc.Name = "txtNewInterfaceGroupDesc"
        Me.txtNewInterfaceGroupDesc.Size = New System.Drawing.Size(271, 20)
        Me.txtNewInterfaceGroupDesc.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 365)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "New Interface Group"
        '
        'txtNewInterfaceGroup
        '
        Me.txtNewInterfaceGroup.Location = New System.Drawing.Point(220, 362)
        Me.txtNewInterfaceGroup.MaxLength = 6
        Me.txtNewInterfaceGroup.Name = "txtNewInterfaceGroup"
        Me.txtNewInterfaceGroup.Size = New System.Drawing.Size(100, 20)
        Me.txtNewInterfaceGroup.TabIndex = 9
        '
        'FrmNewCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 480)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtNewInterfaceGroupDesc)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNewInterfaceGroup)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboInterfaceGroup)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTempDescS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTempDescL)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboPerGroup)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboTempGroup)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPeriodDesc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPeriodGroup)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTempGroup)
        Me.Controls.Add(Me.txtDescL)
        Me.Controls.Add(Me.txtDescS)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.ComboCompany)
        Me.Name = "FrmNewCompany"
        Me.Text = "New Company Based on"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescL As System.Windows.Forms.TextBox
    Friend WithEvents txtDescS As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTempGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboTempGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTempDescL As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTempDescS As System.Windows.Forms.TextBox
    Friend WithEvents ComboPerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboInterfaceGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNewInterfaceGroupDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNewInterfaceGroup As System.Windows.Forms.TextBox
End Class
