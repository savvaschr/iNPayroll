<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEDCInterface
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEDCInterface))
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbInterfaceTemplate = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.E_InterHead1 = New NodalPay.E_InterHead
        Me.E_InterHead2 = New NodalPay.E_InterHead
        Me.D_Interface15 = New NodalPay.D_Interface
        Me.D_Interface14 = New NodalPay.D_Interface
        Me.D_Interface13 = New NodalPay.D_Interface
        Me.D_Interface12 = New NodalPay.D_Interface
        Me.D_Interface11 = New NodalPay.D_Interface
        Me.D_Interface10 = New NodalPay.D_Interface
        Me.D_Interface9 = New NodalPay.D_Interface
        Me.D_Interface8 = New NodalPay.D_Interface
        Me.D_Interface7 = New NodalPay.D_Interface
        Me.D_Interface6 = New NodalPay.D_Interface
        Me.D_Interface5 = New NodalPay.D_Interface
        Me.D_Interface4 = New NodalPay.D_Interface
        Me.D_Interface3 = New NodalPay.D_Interface
        Me.D_Interface2 = New NodalPay.D_Interface
        Me.D_Interface1 = New NodalPay.D_Interface
        Me.E_InterHead3 = New NodalPay.E_InterHead
        Me.C_Interface15 = New NodalPay.C_Interface
        Me.C_Interface14 = New NodalPay.C_Interface
        Me.C_Interface13 = New NodalPay.C_Interface
        Me.C_Interface12 = New NodalPay.C_Interface
        Me.C_Interface11 = New NodalPay.C_Interface
        Me.C_Interface10 = New NodalPay.C_Interface
        Me.C_Interface9 = New NodalPay.C_Interface
        Me.C_Interface8 = New NodalPay.C_Interface
        Me.C_Interface7 = New NodalPay.C_Interface
        Me.C_Interface6 = New NodalPay.C_Interface
        Me.C_Interface5 = New NodalPay.C_Interface
        Me.C_Interface4 = New NodalPay.C_Interface
        Me.C_Interface3 = New NodalPay.C_Interface
        Me.C_Interface2 = New NodalPay.C_Interface
        Me.C_Interface1 = New NodalPay.C_Interface
        Me.E_Inter15 = New NodalPay.E_Interface
        Me.E_Inter14 = New NodalPay.E_Interface
        Me.E_Inter13 = New NodalPay.E_Interface
        Me.E_Inter12 = New NodalPay.E_Interface
        Me.E_Inter11 = New NodalPay.E_Interface
        Me.E_Inter10 = New NodalPay.E_Interface
        Me.E_Inter9 = New NodalPay.E_Interface
        Me.E_Inter8 = New NodalPay.E_Interface
        Me.E_Inter7 = New NodalPay.E_Interface
        Me.E_Inter6 = New NodalPay.E_Interface
        Me.E_Inter5 = New NodalPay.E_Interface
        Me.E_Inter4 = New NodalPay.E_Interface
        Me.E_Inter3 = New NodalPay.E_Interface
        Me.E_Inter2 = New NodalPay.E_Interface
        Me.E_Inter1 = New NodalPay.E_Interface
        Me.TS1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS1
        '
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel, Me.ToolStripButton1})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(1143, 25)
        Me.TS1.TabIndex = 2
        '
        'TSBNew
        '
        Me.TSBNew.AutoSize = False
        Me.TSBNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(60, 22)
        Me.TSBNew.Text = "New"
        Me.TSBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBSave
        '
        Me.TSBSave.AutoSize = False
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(60, 22)
        Me.TSBSave.Text = "Save"
        Me.TSBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBDelete
        '
        Me.TSBDelete.AutoSize = False
        Me.TSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(60, 22)
        Me.TSBDelete.Text = "Delete"
        Me.TSBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSBExcel
        '
        Me.TSBExcel.AutoSize = False
        Me.TSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExcel.Name = "TSBExcel"
        Me.TSBExcel.Size = New System.Drawing.Size(60, 22)
        Me.TSBExcel.Text = "Excel"
        Me.TSBExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripButton1.Text = "Create New Interface Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Interface Template"
        '
        'CmbInterfaceTemplate
        '
        Me.CmbInterfaceTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbInterfaceTemplate.FormattingEnabled = True
        Me.CmbInterfaceTemplate.Location = New System.Drawing.Point(129, 35)
        Me.CmbInterfaceTemplate.Name = "CmbInterfaceTemplate"
        Me.CmbInterfaceTemplate.Size = New System.Drawing.Size(215, 21)
        Me.CmbInterfaceTemplate.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(563, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(577, 476)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.E_InterHead2)
        Me.TabPage1.Controls.Add(Me.D_Interface15)
        Me.TabPage1.Controls.Add(Me.D_Interface14)
        Me.TabPage1.Controls.Add(Me.D_Interface13)
        Me.TabPage1.Controls.Add(Me.D_Interface12)
        Me.TabPage1.Controls.Add(Me.D_Interface11)
        Me.TabPage1.Controls.Add(Me.D_Interface10)
        Me.TabPage1.Controls.Add(Me.D_Interface9)
        Me.TabPage1.Controls.Add(Me.D_Interface8)
        Me.TabPage1.Controls.Add(Me.D_Interface7)
        Me.TabPage1.Controls.Add(Me.D_Interface6)
        Me.TabPage1.Controls.Add(Me.D_Interface5)
        Me.TabPage1.Controls.Add(Me.D_Interface4)
        Me.TabPage1.Controls.Add(Me.D_Interface3)
        Me.TabPage1.Controls.Add(Me.D_Interface2)
        Me.TabPage1.Controls.Add(Me.D_Interface1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(569, 450)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Deductions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.E_InterHead3)
        Me.TabPage2.Controls.Add(Me.C_Interface15)
        Me.TabPage2.Controls.Add(Me.C_Interface14)
        Me.TabPage2.Controls.Add(Me.C_Interface13)
        Me.TabPage2.Controls.Add(Me.C_Interface12)
        Me.TabPage2.Controls.Add(Me.C_Interface11)
        Me.TabPage2.Controls.Add(Me.C_Interface10)
        Me.TabPage2.Controls.Add(Me.C_Interface9)
        Me.TabPage2.Controls.Add(Me.C_Interface8)
        Me.TabPage2.Controls.Add(Me.C_Interface7)
        Me.TabPage2.Controls.Add(Me.C_Interface6)
        Me.TabPage2.Controls.Add(Me.C_Interface5)
        Me.TabPage2.Controls.Add(Me.C_Interface4)
        Me.TabPage2.Controls.Add(Me.C_Interface3)
        Me.TabPage2.Controls.Add(Me.C_Interface2)
        Me.TabPage2.Controls.Add(Me.C_Interface1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(569, 450)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contributions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'E_InterHead1
        '
        Me.E_InterHead1.Location = New System.Drawing.Point(0, 57)
        Me.E_InterHead1.Name = "E_InterHead1"
        Me.E_InterHead1.Size = New System.Drawing.Size(479, 23)
        Me.E_InterHead1.TabIndex = 21
        '
        'E_InterHead2
        '
        Me.E_InterHead2.Location = New System.Drawing.Point(7, 6)
        Me.E_InterHead2.Name = "E_InterHead2"
        Me.E_InterHead2.Size = New System.Drawing.Size(479, 23)
        Me.E_InterHead2.TabIndex = 22
        '
        'D_Interface15
        '
        Me.D_Interface15.Location = New System.Drawing.Point(11, 413)
        Me.D_Interface15.Name = "D_Interface15"
        Me.D_Interface15.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface15.TabIndex = 14
        '
        'D_Interface14
        '
        Me.D_Interface14.Location = New System.Drawing.Point(11, 386)
        Me.D_Interface14.Name = "D_Interface14"
        Me.D_Interface14.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface14.TabIndex = 13
        '
        'D_Interface13
        '
        Me.D_Interface13.Location = New System.Drawing.Point(11, 359)
        Me.D_Interface13.Name = "D_Interface13"
        Me.D_Interface13.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface13.TabIndex = 12
        '
        'D_Interface12
        '
        Me.D_Interface12.Location = New System.Drawing.Point(11, 332)
        Me.D_Interface12.Name = "D_Interface12"
        Me.D_Interface12.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface12.TabIndex = 11
        '
        'D_Interface11
        '
        Me.D_Interface11.Location = New System.Drawing.Point(11, 305)
        Me.D_Interface11.Name = "D_Interface11"
        Me.D_Interface11.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface11.TabIndex = 10
        '
        'D_Interface10
        '
        Me.D_Interface10.Location = New System.Drawing.Point(11, 278)
        Me.D_Interface10.Name = "D_Interface10"
        Me.D_Interface10.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface10.TabIndex = 9
        '
        'D_Interface9
        '
        Me.D_Interface9.Location = New System.Drawing.Point(11, 251)
        Me.D_Interface9.Name = "D_Interface9"
        Me.D_Interface9.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface9.TabIndex = 8
        '
        'D_Interface8
        '
        Me.D_Interface8.Location = New System.Drawing.Point(11, 224)
        Me.D_Interface8.Name = "D_Interface8"
        Me.D_Interface8.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface8.TabIndex = 7
        '
        'D_Interface7
        '
        Me.D_Interface7.Location = New System.Drawing.Point(11, 197)
        Me.D_Interface7.Name = "D_Interface7"
        Me.D_Interface7.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface7.TabIndex = 6
        '
        'D_Interface6
        '
        Me.D_Interface6.Location = New System.Drawing.Point(11, 170)
        Me.D_Interface6.Name = "D_Interface6"
        Me.D_Interface6.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface6.TabIndex = 5
        '
        'D_Interface5
        '
        Me.D_Interface5.Location = New System.Drawing.Point(11, 143)
        Me.D_Interface5.Name = "D_Interface5"
        Me.D_Interface5.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface5.TabIndex = 4
        '
        'D_Interface4
        '
        Me.D_Interface4.Location = New System.Drawing.Point(11, 116)
        Me.D_Interface4.Name = "D_Interface4"
        Me.D_Interface4.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface4.TabIndex = 3
        '
        'D_Interface3
        '
        Me.D_Interface3.Location = New System.Drawing.Point(11, 89)
        Me.D_Interface3.Name = "D_Interface3"
        Me.D_Interface3.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface3.TabIndex = 2
        '
        'D_Interface2
        '
        Me.D_Interface2.Location = New System.Drawing.Point(11, 62)
        Me.D_Interface2.Name = "D_Interface2"
        Me.D_Interface2.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface2.TabIndex = 1
        '
        'D_Interface1
        '
        Me.D_Interface1.Location = New System.Drawing.Point(11, 35)
        Me.D_Interface1.Name = "D_Interface1"
        Me.D_Interface1.Size = New System.Drawing.Size(552, 27)
        Me.D_Interface1.TabIndex = 0
        '
        'E_InterHead3
        '
        Me.E_InterHead3.Location = New System.Drawing.Point(7, 6)
        Me.E_InterHead3.Name = "E_InterHead3"
        Me.E_InterHead3.Size = New System.Drawing.Size(479, 23)
        Me.E_InterHead3.TabIndex = 22
        '
        'C_Interface15
        '
        Me.C_Interface15.Location = New System.Drawing.Point(6, 413)
        Me.C_Interface15.Name = "C_Interface15"
        Me.C_Interface15.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface15.TabIndex = 14
        '
        'C_Interface14
        '
        Me.C_Interface14.Location = New System.Drawing.Point(6, 386)
        Me.C_Interface14.Name = "C_Interface14"
        Me.C_Interface14.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface14.TabIndex = 13
        '
        'C_Interface13
        '
        Me.C_Interface13.Location = New System.Drawing.Point(6, 359)
        Me.C_Interface13.Name = "C_Interface13"
        Me.C_Interface13.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface13.TabIndex = 12
        '
        'C_Interface12
        '
        Me.C_Interface12.Location = New System.Drawing.Point(6, 332)
        Me.C_Interface12.Name = "C_Interface12"
        Me.C_Interface12.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface12.TabIndex = 11
        '
        'C_Interface11
        '
        Me.C_Interface11.Location = New System.Drawing.Point(6, 305)
        Me.C_Interface11.Name = "C_Interface11"
        Me.C_Interface11.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface11.TabIndex = 10
        '
        'C_Interface10
        '
        Me.C_Interface10.Location = New System.Drawing.Point(6, 278)
        Me.C_Interface10.Name = "C_Interface10"
        Me.C_Interface10.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface10.TabIndex = 9
        '
        'C_Interface9
        '
        Me.C_Interface9.Location = New System.Drawing.Point(6, 251)
        Me.C_Interface9.Name = "C_Interface9"
        Me.C_Interface9.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface9.TabIndex = 8
        '
        'C_Interface8
        '
        Me.C_Interface8.Location = New System.Drawing.Point(6, 224)
        Me.C_Interface8.Name = "C_Interface8"
        Me.C_Interface8.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface8.TabIndex = 7
        '
        'C_Interface7
        '
        Me.C_Interface7.Location = New System.Drawing.Point(6, 197)
        Me.C_Interface7.Name = "C_Interface7"
        Me.C_Interface7.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface7.TabIndex = 6
        '
        'C_Interface6
        '
        Me.C_Interface6.Location = New System.Drawing.Point(6, 170)
        Me.C_Interface6.Name = "C_Interface6"
        Me.C_Interface6.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface6.TabIndex = 5
        '
        'C_Interface5
        '
        Me.C_Interface5.Location = New System.Drawing.Point(6, 143)
        Me.C_Interface5.Name = "C_Interface5"
        Me.C_Interface5.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface5.TabIndex = 4
        '
        'C_Interface4
        '
        Me.C_Interface4.Location = New System.Drawing.Point(6, 116)
        Me.C_Interface4.Name = "C_Interface4"
        Me.C_Interface4.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface4.TabIndex = 3
        '
        'C_Interface3
        '
        Me.C_Interface3.Location = New System.Drawing.Point(6, 89)
        Me.C_Interface3.Name = "C_Interface3"
        Me.C_Interface3.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface3.TabIndex = 2
        '
        'C_Interface2
        '
        Me.C_Interface2.Location = New System.Drawing.Point(6, 62)
        Me.C_Interface2.Name = "C_Interface2"
        Me.C_Interface2.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface2.TabIndex = 1
        '
        'C_Interface1
        '
        Me.C_Interface1.Location = New System.Drawing.Point(6, 35)
        Me.C_Interface1.Name = "C_Interface1"
        Me.C_Interface1.Size = New System.Drawing.Size(557, 27)
        Me.C_Interface1.TabIndex = 0
        '
        'E_Inter15
        '
        Me.E_Inter15.Location = New System.Drawing.Point(0, 464)
        Me.E_Inter15.Name = "E_Inter15"
        Me.E_Inter15.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter15.TabIndex = 19
        '
        'E_Inter14
        '
        Me.E_Inter14.Location = New System.Drawing.Point(0, 437)
        Me.E_Inter14.Name = "E_Inter14"
        Me.E_Inter14.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter14.TabIndex = 18
        '
        'E_Inter13
        '
        Me.E_Inter13.Location = New System.Drawing.Point(0, 410)
        Me.E_Inter13.Name = "E_Inter13"
        Me.E_Inter13.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter13.TabIndex = 17
        '
        'E_Inter12
        '
        Me.E_Inter12.Location = New System.Drawing.Point(0, 383)
        Me.E_Inter12.Name = "E_Inter12"
        Me.E_Inter12.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter12.TabIndex = 16
        '
        'E_Inter11
        '
        Me.E_Inter11.Location = New System.Drawing.Point(0, 356)
        Me.E_Inter11.Name = "E_Inter11"
        Me.E_Inter11.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter11.TabIndex = 15
        '
        'E_Inter10
        '
        Me.E_Inter10.Location = New System.Drawing.Point(0, 329)
        Me.E_Inter10.Name = "E_Inter10"
        Me.E_Inter10.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter10.TabIndex = 14
        '
        'E_Inter9
        '
        Me.E_Inter9.Location = New System.Drawing.Point(0, 302)
        Me.E_Inter9.Name = "E_Inter9"
        Me.E_Inter9.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter9.TabIndex = 13
        '
        'E_Inter8
        '
        Me.E_Inter8.Location = New System.Drawing.Point(0, 275)
        Me.E_Inter8.Name = "E_Inter8"
        Me.E_Inter8.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter8.TabIndex = 12
        '
        'E_Inter7
        '
        Me.E_Inter7.Location = New System.Drawing.Point(0, 248)
        Me.E_Inter7.Name = "E_Inter7"
        Me.E_Inter7.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter7.TabIndex = 11
        '
        'E_Inter6
        '
        Me.E_Inter6.Location = New System.Drawing.Point(0, 221)
        Me.E_Inter6.Name = "E_Inter6"
        Me.E_Inter6.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter6.TabIndex = 10
        '
        'E_Inter5
        '
        Me.E_Inter5.Location = New System.Drawing.Point(0, 194)
        Me.E_Inter5.Name = "E_Inter5"
        Me.E_Inter5.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter5.TabIndex = 9
        '
        'E_Inter4
        '
        Me.E_Inter4.Location = New System.Drawing.Point(0, 167)
        Me.E_Inter4.Name = "E_Inter4"
        Me.E_Inter4.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter4.TabIndex = 8
        '
        'E_Inter3
        '
        Me.E_Inter3.Location = New System.Drawing.Point(0, 140)
        Me.E_Inter3.Name = "E_Inter3"
        Me.E_Inter3.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter3.TabIndex = 7
        '
        'E_Inter2
        '
        Me.E_Inter2.Location = New System.Drawing.Point(0, 113)
        Me.E_Inter2.Name = "E_Inter2"
        Me.E_Inter2.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter2.TabIndex = 6
        '
        'E_Inter1
        '
        Me.E_Inter1.Location = New System.Drawing.Point(0, 86)
        Me.E_Inter1.Name = "E_Inter1"
        Me.E_Inter1.Size = New System.Drawing.Size(557, 27)
        Me.E_Inter1.TabIndex = 5
        '
        'FrmEDCInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1143, 530)
        Me.Controls.Add(Me.E_InterHead1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.E_Inter15)
        Me.Controls.Add(Me.E_Inter14)
        Me.Controls.Add(Me.E_Inter13)
        Me.Controls.Add(Me.E_Inter12)
        Me.Controls.Add(Me.E_Inter11)
        Me.Controls.Add(Me.E_Inter10)
        Me.Controls.Add(Me.E_Inter9)
        Me.Controls.Add(Me.E_Inter8)
        Me.Controls.Add(Me.E_Inter7)
        Me.Controls.Add(Me.E_Inter6)
        Me.Controls.Add(Me.E_Inter5)
        Me.Controls.Add(Me.E_Inter4)
        Me.Controls.Add(Me.E_Inter3)
        Me.Controls.Add(Me.E_Inter2)
        Me.Controls.Add(Me.E_Inter1)
        Me.Controls.Add(Me.CmbInterfaceTemplate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TS1)
        Me.Name = "FrmEDCInterface"
        Me.Text = "EDC Interface Template Maintenance Form"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbInterfaceTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents E_Inter1 As NodalPay.E_Interface
    Friend WithEvents E_Inter2 As NodalPay.E_Interface
    Friend WithEvents E_Inter3 As NodalPay.E_Interface
    Friend WithEvents E_Inter4 As NodalPay.E_Interface
    Friend WithEvents E_Inter5 As NodalPay.E_Interface
    Friend WithEvents E_Inter6 As NodalPay.E_Interface
    Friend WithEvents E_Inter7 As NodalPay.E_Interface
    Friend WithEvents E_Inter14 As NodalPay.E_Interface
    Friend WithEvents E_Inter13 As NodalPay.E_Interface
    Friend WithEvents E_Inter12 As NodalPay.E_Interface
    Friend WithEvents E_Inter11 As NodalPay.E_Interface
    Friend WithEvents E_Inter10 As NodalPay.E_Interface
    Friend WithEvents E_Inter9 As NodalPay.E_Interface
    Friend WithEvents E_Inter8 As NodalPay.E_Interface
    Friend WithEvents E_Inter15 As NodalPay.E_Interface
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents D_Interface15 As NodalPay.D_Interface
    Friend WithEvents D_Interface14 As NodalPay.D_Interface
    Friend WithEvents D_Interface13 As NodalPay.D_Interface
    Friend WithEvents D_Interface12 As NodalPay.D_Interface
    Friend WithEvents D_Interface11 As NodalPay.D_Interface
    Friend WithEvents D_Interface10 As NodalPay.D_Interface
    Friend WithEvents D_Interface9 As NodalPay.D_Interface
    Friend WithEvents D_Interface8 As NodalPay.D_Interface
    Friend WithEvents D_Interface7 As NodalPay.D_Interface
    Friend WithEvents D_Interface6 As NodalPay.D_Interface
    Friend WithEvents D_Interface5 As NodalPay.D_Interface
    Friend WithEvents D_Interface4 As NodalPay.D_Interface
    Friend WithEvents D_Interface3 As NodalPay.D_Interface
    Friend WithEvents D_Interface2 As NodalPay.D_Interface
    Friend WithEvents D_Interface1 As NodalPay.D_Interface
    Friend WithEvents C_Interface15 As NodalPay.C_Interface
    Friend WithEvents C_Interface14 As NodalPay.C_Interface
    Friend WithEvents C_Interface13 As NodalPay.C_Interface
    Friend WithEvents C_Interface12 As NodalPay.C_Interface
    Friend WithEvents C_Interface11 As NodalPay.C_Interface
    Friend WithEvents C_Interface10 As NodalPay.C_Interface
    Friend WithEvents C_Interface9 As NodalPay.C_Interface
    Friend WithEvents C_Interface8 As NodalPay.C_Interface
    Friend WithEvents C_Interface7 As NodalPay.C_Interface
    Friend WithEvents C_Interface6 As NodalPay.C_Interface
    Friend WithEvents C_Interface5 As NodalPay.C_Interface
    Friend WithEvents C_Interface4 As NodalPay.C_Interface
    Friend WithEvents C_Interface3 As NodalPay.C_Interface
    Friend WithEvents C_Interface2 As NodalPay.C_Interface
    Friend WithEvents C_Interface1 As NodalPay.C_Interface
    Friend WithEvents E_InterHead2 As NodalPay.E_InterHead
    Friend WithEvents E_InterHead3 As NodalPay.E_InterHead
    Friend WithEvents E_InterHead1 As NodalPay.E_InterHead
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
