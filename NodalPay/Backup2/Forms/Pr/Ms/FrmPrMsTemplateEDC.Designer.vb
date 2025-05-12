<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrMsTemplateEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrMsTemplateEDC))
        Me.TS1 = New System.Windows.Forms.ToolStrip
        Me.TSBNew = New System.Windows.Forms.ToolStripButton
        Me.TSBSave = New System.Windows.Forms.ToolStripButton
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton
        Me.TSBExcel = New System.Windows.Forms.ToolStripButton
        Me.BtnFixSequence = New System.Windows.Forms.ToolStripButton
        Me.sspStatus = New System.Windows.Forms.StatusStrip
        Me.lblSSStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.D_Con15 = New NodalPay.D_Control
        Me.D_Con14 = New NodalPay.D_Control
        Me.D_Con13 = New NodalPay.D_Control
        Me.D_Con12 = New NodalPay.D_Control
        Me.D_Con11 = New NodalPay.D_Control
        Me.D_Con10 = New NodalPay.D_Control
        Me.D_Con9 = New NodalPay.D_Control
        Me.D_Con8 = New NodalPay.D_Control
        Me.D_Con7 = New NodalPay.D_Control
        Me.D_Con6 = New NodalPay.D_Control
        Me.D_Con5 = New NodalPay.D_Control
        Me.D_Con4 = New NodalPay.D_Control
        Me.D_Con3 = New NodalPay.D_Control
        Me.D_Con2 = New NodalPay.D_Control
        Me.D_Con1 = New NodalPay.D_Control
        Me.D_Headline1 = New NodalPay.D_Headline
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.C_Con15 = New NodalPay.C_Control
        Me.C_Con14 = New NodalPay.C_Control
        Me.C_Con13 = New NodalPay.C_Control
        Me.C_Con12 = New NodalPay.C_Control
        Me.C_Con11 = New NodalPay.C_Control
        Me.C_Con10 = New NodalPay.C_Control
        Me.C_Con9 = New NodalPay.C_Control
        Me.C_Con8 = New NodalPay.C_Control
        Me.C_Con7 = New NodalPay.C_Control
        Me.C_Con6 = New NodalPay.C_Control
        Me.C_Con5 = New NodalPay.C_Control
        Me.C_Con4 = New NodalPay.C_Control
        Me.C_Con3 = New NodalPay.C_Control
        Me.C_Con2 = New NodalPay.C_Control
        Me.C_Con1 = New NodalPay.C_Control
        Me.C_HeadLine1 = New NodalPay.C_HeadLine
        Me.ComboTemplateGroup = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.E_Con9 = New NodalPay.E_Control
        Me.E_Con3 = New NodalPay.E_Control
        Me.E_Con14 = New NodalPay.E_Control
        Me.E_Con5 = New NodalPay.E_Control
        Me.E_Con13 = New NodalPay.E_Control
        Me.E_Con15 = New NodalPay.E_Control
        Me.E_Con11 = New NodalPay.E_Control
        Me.E_Con4 = New NodalPay.E_Control
        Me.E_Con1 = New NodalPay.E_Control
        Me.E_Con8 = New NodalPay.E_Control
        Me.E_Con10 = New NodalPay.E_Control
        Me.E_Con12 = New NodalPay.E_Control
        Me.E_Con6 = New NodalPay.E_Control
        Me.E_Con7 = New NodalPay.E_Control
        Me.E_Con2 = New NodalPay.E_Control
        Me.E_HeadLine1 = New NodalPay.E_HeadLine
        Me.TS1.SuspendLayout()
        Me.sspStatus.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TS1
        '
        Me.TS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNew, Me.TSBSave, Me.TSBDelete, Me.TSBExcel, Me.BtnFixSequence})
        Me.TS1.Location = New System.Drawing.Point(0, 0)
        Me.TS1.Name = "TS1"
        Me.TS1.Size = New System.Drawing.Size(1355, 25)
        Me.TS1.TabIndex = 1
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
        'BtnFixSequence
        '
        Me.BtnFixSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnFixSequence.Image = CType(resources.GetObject("BtnFixSequence.Image"), System.Drawing.Image)
        Me.BtnFixSequence.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFixSequence.Name = "BtnFixSequence"
        Me.BtnFixSequence.Size = New System.Drawing.Size(150, 22)
        Me.BtnFixSequence.Text = "Setup Reporting Sequence"
        '
        'sspStatus
        '
        Me.sspStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sspStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSSStatus})
        Me.sspStatus.Location = New System.Drawing.Point(0, 534)
        Me.sspStatus.Name = "sspStatus"
        Me.sspStatus.Size = New System.Drawing.Size(1355, 22)
        Me.sspStatus.TabIndex = 4
        Me.sspStatus.Text = "StatusStrip"
        '
        'lblSSStatus
        '
        Me.lblSSStatus.Name = "lblSSStatus"
        Me.lblSSStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(660, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(683, 477)
        Me.TabControl1.TabIndex = 21
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.D_Con15)
        Me.TabPage1.Controls.Add(Me.D_Con14)
        Me.TabPage1.Controls.Add(Me.D_Con13)
        Me.TabPage1.Controls.Add(Me.D_Con12)
        Me.TabPage1.Controls.Add(Me.D_Con11)
        Me.TabPage1.Controls.Add(Me.D_Con10)
        Me.TabPage1.Controls.Add(Me.D_Con9)
        Me.TabPage1.Controls.Add(Me.D_Con8)
        Me.TabPage1.Controls.Add(Me.D_Con7)
        Me.TabPage1.Controls.Add(Me.D_Con6)
        Me.TabPage1.Controls.Add(Me.D_Con5)
        Me.TabPage1.Controls.Add(Me.D_Con4)
        Me.TabPage1.Controls.Add(Me.D_Con3)
        Me.TabPage1.Controls.Add(Me.D_Con2)
        Me.TabPage1.Controls.Add(Me.D_Con1)
        Me.TabPage1.Controls.Add(Me.D_Headline1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(675, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Deductions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'D_Con15
        '
        Me.D_Con15.Location = New System.Drawing.Point(3, 417)
        Me.D_Con15.Name = "D_Con15"
        Me.D_Con15.Size = New System.Drawing.Size(638, 27)
        Me.D_Con15.TabIndex = 15
        '
        'D_Con14
        '
        Me.D_Con14.Location = New System.Drawing.Point(3, 390)
        Me.D_Con14.Name = "D_Con14"
        Me.D_Con14.Size = New System.Drawing.Size(638, 27)
        Me.D_Con14.TabIndex = 14
        '
        'D_Con13
        '
        Me.D_Con13.Location = New System.Drawing.Point(3, 363)
        Me.D_Con13.Name = "D_Con13"
        Me.D_Con13.Size = New System.Drawing.Size(638, 27)
        Me.D_Con13.TabIndex = 13
        '
        'D_Con12
        '
        Me.D_Con12.Location = New System.Drawing.Point(3, 336)
        Me.D_Con12.Name = "D_Con12"
        Me.D_Con12.Size = New System.Drawing.Size(638, 27)
        Me.D_Con12.TabIndex = 12
        '
        'D_Con11
        '
        Me.D_Con11.Location = New System.Drawing.Point(3, 309)
        Me.D_Con11.Name = "D_Con11"
        Me.D_Con11.Size = New System.Drawing.Size(638, 27)
        Me.D_Con11.TabIndex = 11
        '
        'D_Con10
        '
        Me.D_Con10.Location = New System.Drawing.Point(3, 282)
        Me.D_Con10.Name = "D_Con10"
        Me.D_Con10.Size = New System.Drawing.Size(638, 27)
        Me.D_Con10.TabIndex = 10
        '
        'D_Con9
        '
        Me.D_Con9.Location = New System.Drawing.Point(3, 255)
        Me.D_Con9.Name = "D_Con9"
        Me.D_Con9.Size = New System.Drawing.Size(638, 27)
        Me.D_Con9.TabIndex = 9
        '
        'D_Con8
        '
        Me.D_Con8.Location = New System.Drawing.Point(3, 228)
        Me.D_Con8.Name = "D_Con8"
        Me.D_Con8.Size = New System.Drawing.Size(638, 27)
        Me.D_Con8.TabIndex = 8
        '
        'D_Con7
        '
        Me.D_Con7.Location = New System.Drawing.Point(3, 201)
        Me.D_Con7.Name = "D_Con7"
        Me.D_Con7.Size = New System.Drawing.Size(638, 27)
        Me.D_Con7.TabIndex = 7
        '
        'D_Con6
        '
        Me.D_Con6.Location = New System.Drawing.Point(3, 174)
        Me.D_Con6.Name = "D_Con6"
        Me.D_Con6.Size = New System.Drawing.Size(638, 27)
        Me.D_Con6.TabIndex = 6
        '
        'D_Con5
        '
        Me.D_Con5.Location = New System.Drawing.Point(3, 147)
        Me.D_Con5.Name = "D_Con5"
        Me.D_Con5.Size = New System.Drawing.Size(638, 27)
        Me.D_Con5.TabIndex = 5
        '
        'D_Con4
        '
        Me.D_Con4.Location = New System.Drawing.Point(3, 120)
        Me.D_Con4.Name = "D_Con4"
        Me.D_Con4.Size = New System.Drawing.Size(638, 27)
        Me.D_Con4.TabIndex = 4
        '
        'D_Con3
        '
        Me.D_Con3.Location = New System.Drawing.Point(3, 93)
        Me.D_Con3.Name = "D_Con3"
        Me.D_Con3.Size = New System.Drawing.Size(638, 27)
        Me.D_Con3.TabIndex = 3
        '
        'D_Con2
        '
        Me.D_Con2.Location = New System.Drawing.Point(3, 66)
        Me.D_Con2.Name = "D_Con2"
        Me.D_Con2.Size = New System.Drawing.Size(638, 27)
        Me.D_Con2.TabIndex = 2
        '
        'D_Con1
        '
        Me.D_Con1.Location = New System.Drawing.Point(3, 39)
        Me.D_Con1.Name = "D_Con1"
        Me.D_Con1.Size = New System.Drawing.Size(638, 27)
        Me.D_Con1.TabIndex = 1
        '
        'D_Headline1
        '
        Me.D_Headline1.Location = New System.Drawing.Point(3, 6)
        Me.D_Headline1.Name = "D_Headline1"
        Me.D_Headline1.Size = New System.Drawing.Size(562, 28)
        Me.D_Headline1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.C_Con15)
        Me.TabPage2.Controls.Add(Me.C_Con14)
        Me.TabPage2.Controls.Add(Me.C_Con13)
        Me.TabPage2.Controls.Add(Me.C_Con12)
        Me.TabPage2.Controls.Add(Me.C_Con11)
        Me.TabPage2.Controls.Add(Me.C_Con10)
        Me.TabPage2.Controls.Add(Me.C_Con9)
        Me.TabPage2.Controls.Add(Me.C_Con8)
        Me.TabPage2.Controls.Add(Me.C_Con7)
        Me.TabPage2.Controls.Add(Me.C_Con6)
        Me.TabPage2.Controls.Add(Me.C_Con5)
        Me.TabPage2.Controls.Add(Me.C_Con4)
        Me.TabPage2.Controls.Add(Me.C_Con3)
        Me.TabPage2.Controls.Add(Me.C_Con2)
        Me.TabPage2.Controls.Add(Me.C_Con1)
        Me.TabPage2.Controls.Add(Me.C_HeadLine1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(675, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contributions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'C_Con15
        '
        Me.C_Con15.Location = New System.Drawing.Point(3, 417)
        Me.C_Con15.Name = "C_Con15"
        Me.C_Con15.Size = New System.Drawing.Size(648, 27)
        Me.C_Con15.TabIndex = 15
        '
        'C_Con14
        '
        Me.C_Con14.Location = New System.Drawing.Point(3, 390)
        Me.C_Con14.Name = "C_Con14"
        Me.C_Con14.Size = New System.Drawing.Size(648, 27)
        Me.C_Con14.TabIndex = 14
        '
        'C_Con13
        '
        Me.C_Con13.Location = New System.Drawing.Point(3, 363)
        Me.C_Con13.Name = "C_Con13"
        Me.C_Con13.Size = New System.Drawing.Size(648, 27)
        Me.C_Con13.TabIndex = 13
        '
        'C_Con12
        '
        Me.C_Con12.Location = New System.Drawing.Point(3, 336)
        Me.C_Con12.Name = "C_Con12"
        Me.C_Con12.Size = New System.Drawing.Size(648, 27)
        Me.C_Con12.TabIndex = 12
        '
        'C_Con11
        '
        Me.C_Con11.Location = New System.Drawing.Point(3, 309)
        Me.C_Con11.Name = "C_Con11"
        Me.C_Con11.Size = New System.Drawing.Size(648, 27)
        Me.C_Con11.TabIndex = 11
        '
        'C_Con10
        '
        Me.C_Con10.Location = New System.Drawing.Point(3, 282)
        Me.C_Con10.Name = "C_Con10"
        Me.C_Con10.Size = New System.Drawing.Size(648, 27)
        Me.C_Con10.TabIndex = 10
        '
        'C_Con9
        '
        Me.C_Con9.Location = New System.Drawing.Point(3, 255)
        Me.C_Con9.Name = "C_Con9"
        Me.C_Con9.Size = New System.Drawing.Size(648, 27)
        Me.C_Con9.TabIndex = 9
        '
        'C_Con8
        '
        Me.C_Con8.Location = New System.Drawing.Point(3, 228)
        Me.C_Con8.Name = "C_Con8"
        Me.C_Con8.Size = New System.Drawing.Size(648, 27)
        Me.C_Con8.TabIndex = 8
        '
        'C_Con7
        '
        Me.C_Con7.Location = New System.Drawing.Point(3, 201)
        Me.C_Con7.Name = "C_Con7"
        Me.C_Con7.Size = New System.Drawing.Size(648, 27)
        Me.C_Con7.TabIndex = 7
        '
        'C_Con6
        '
        Me.C_Con6.Location = New System.Drawing.Point(3, 174)
        Me.C_Con6.Name = "C_Con6"
        Me.C_Con6.Size = New System.Drawing.Size(648, 27)
        Me.C_Con6.TabIndex = 6
        '
        'C_Con5
        '
        Me.C_Con5.Location = New System.Drawing.Point(3, 147)
        Me.C_Con5.Name = "C_Con5"
        Me.C_Con5.Size = New System.Drawing.Size(648, 27)
        Me.C_Con5.TabIndex = 5
        '
        'C_Con4
        '
        Me.C_Con4.Location = New System.Drawing.Point(3, 120)
        Me.C_Con4.Name = "C_Con4"
        Me.C_Con4.Size = New System.Drawing.Size(648, 27)
        Me.C_Con4.TabIndex = 4
        '
        'C_Con3
        '
        Me.C_Con3.Location = New System.Drawing.Point(3, 93)
        Me.C_Con3.Name = "C_Con3"
        Me.C_Con3.Size = New System.Drawing.Size(648, 27)
        Me.C_Con3.TabIndex = 3
        '
        'C_Con2
        '
        Me.C_Con2.Location = New System.Drawing.Point(3, 66)
        Me.C_Con2.Name = "C_Con2"
        Me.C_Con2.Size = New System.Drawing.Size(648, 27)
        Me.C_Con2.TabIndex = 2
        '
        'C_Con1
        '
        Me.C_Con1.Location = New System.Drawing.Point(3, 39)
        Me.C_Con1.Name = "C_Con1"
        Me.C_Con1.Size = New System.Drawing.Size(648, 27)
        Me.C_Con1.TabIndex = 1
        '
        'C_HeadLine1
        '
        Me.C_HeadLine1.Location = New System.Drawing.Point(3, 6)
        Me.C_HeadLine1.Name = "C_HeadLine1"
        Me.C_HeadLine1.Size = New System.Drawing.Size(567, 28)
        Me.C_HeadLine1.TabIndex = 0
        '
        'ComboTemplateGroup
        '
        Me.ComboTemplateGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTemplateGroup.FormattingEnabled = True
        Me.ComboTemplateGroup.Location = New System.Drawing.Point(141, 28)
        Me.ComboTemplateGroup.Name = "ComboTemplateGroup"
        Me.ComboTemplateGroup.Size = New System.Drawing.Size(171, 21)
        Me.ComboTemplateGroup.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Template Group"
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'E_Con9
        '
        Me.E_Con9.Location = New System.Drawing.Point(0, 301)
        Me.E_Con9.Name = "E_Con9"
        Me.E_Con9.Size = New System.Drawing.Size(643, 27)
        Me.E_Con9.TabIndex = 20
        '
        'E_Con3
        '
        Me.E_Con3.Location = New System.Drawing.Point(0, 139)
        Me.E_Con3.Name = "E_Con3"
        Me.E_Con3.Size = New System.Drawing.Size(643, 27)
        Me.E_Con3.TabIndex = 19
        '
        'E_Con14
        '
        Me.E_Con14.Location = New System.Drawing.Point(0, 436)
        Me.E_Con14.Name = "E_Con14"
        Me.E_Con14.Size = New System.Drawing.Size(643, 27)
        Me.E_Con14.TabIndex = 18
        '
        'E_Con5
        '
        Me.E_Con5.Location = New System.Drawing.Point(0, 193)
        Me.E_Con5.Name = "E_Con5"
        Me.E_Con5.Size = New System.Drawing.Size(643, 27)
        Me.E_Con5.TabIndex = 17
        '
        'E_Con13
        '
        Me.E_Con13.Location = New System.Drawing.Point(0, 409)
        Me.E_Con13.Name = "E_Con13"
        Me.E_Con13.Size = New System.Drawing.Size(643, 27)
        Me.E_Con13.TabIndex = 16
        '
        'E_Con15
        '
        Me.E_Con15.Location = New System.Drawing.Point(0, 463)
        Me.E_Con15.Name = "E_Con15"
        Me.E_Con15.Size = New System.Drawing.Size(643, 27)
        Me.E_Con15.TabIndex = 15
        '
        'E_Con11
        '
        Me.E_Con11.Location = New System.Drawing.Point(0, 355)
        Me.E_Con11.Name = "E_Con11"
        Me.E_Con11.Size = New System.Drawing.Size(643, 27)
        Me.E_Con11.TabIndex = 14
        '
        'E_Con4
        '
        Me.E_Con4.Location = New System.Drawing.Point(0, 166)
        Me.E_Con4.Name = "E_Con4"
        Me.E_Con4.Size = New System.Drawing.Size(643, 27)
        Me.E_Con4.TabIndex = 13
        '
        'E_Con1
        '
        Me.E_Con1.Location = New System.Drawing.Point(0, 85)
        Me.E_Con1.Name = "E_Con1"
        Me.E_Con1.Size = New System.Drawing.Size(643, 27)
        Me.E_Con1.TabIndex = 12
        '
        'E_Con8
        '
        Me.E_Con8.Location = New System.Drawing.Point(0, 274)
        Me.E_Con8.Name = "E_Con8"
        Me.E_Con8.Size = New System.Drawing.Size(643, 27)
        Me.E_Con8.TabIndex = 11
        '
        'E_Con10
        '
        Me.E_Con10.Location = New System.Drawing.Point(0, 328)
        Me.E_Con10.Name = "E_Con10"
        Me.E_Con10.Size = New System.Drawing.Size(643, 27)
        Me.E_Con10.TabIndex = 10
        '
        'E_Con12
        '
        Me.E_Con12.Location = New System.Drawing.Point(0, 382)
        Me.E_Con12.Name = "E_Con12"
        Me.E_Con12.Size = New System.Drawing.Size(643, 27)
        Me.E_Con12.TabIndex = 9
        '
        'E_Con6
        '
        Me.E_Con6.Location = New System.Drawing.Point(0, 220)
        Me.E_Con6.Name = "E_Con6"
        Me.E_Con6.Size = New System.Drawing.Size(643, 27)
        Me.E_Con6.TabIndex = 8
        '
        'E_Con7
        '
        Me.E_Con7.Location = New System.Drawing.Point(0, 247)
        Me.E_Con7.Name = "E_Con7"
        Me.E_Con7.Size = New System.Drawing.Size(643, 27)
        Me.E_Con7.TabIndex = 7
        '
        'E_Con2
        '
        Me.E_Con2.Location = New System.Drawing.Point(0, 112)
        Me.E_Con2.Name = "E_Con2"
        Me.E_Con2.Size = New System.Drawing.Size(643, 27)
        Me.E_Con2.TabIndex = 6
        '
        'E_HeadLine1
        '
        Me.E_HeadLine1.Location = New System.Drawing.Point(0, 51)
        Me.E_HeadLine1.Name = "E_HeadLine1"
        Me.E_HeadLine1.Size = New System.Drawing.Size(536, 28)
        Me.E_HeadLine1.TabIndex = 5
        '
        'FrmPrMsTemplateEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1355, 556)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTemplateGroup)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.E_Con9)
        Me.Controls.Add(Me.E_Con3)
        Me.Controls.Add(Me.E_Con14)
        Me.Controls.Add(Me.E_Con5)
        Me.Controls.Add(Me.E_Con13)
        Me.Controls.Add(Me.E_Con15)
        Me.Controls.Add(Me.E_Con11)
        Me.Controls.Add(Me.E_Con4)
        Me.Controls.Add(Me.E_Con1)
        Me.Controls.Add(Me.E_Con8)
        Me.Controls.Add(Me.E_Con10)
        Me.Controls.Add(Me.E_Con12)
        Me.Controls.Add(Me.E_Con6)
        Me.Controls.Add(Me.E_Con7)
        Me.Controls.Add(Me.E_Con2)
        Me.Controls.Add(Me.E_HeadLine1)
        Me.Controls.Add(Me.sspStatus)
        Me.Controls.Add(Me.TS1)
        Me.Name = "FrmPrMsTemplateEDC"
        Me.Text = "EDC Template Maintenance Form"
        Me.TS1.ResumeLayout(False)
        Me.TS1.PerformLayout()
        Me.sspStatus.ResumeLayout(False)
        Me.sspStatus.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents sspStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSSStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents E_HeadLine1 As NodalPay.E_HeadLine
    Friend WithEvents E_Con2 As NodalPay.E_Control
    Friend WithEvents E_Con7 As NodalPay.E_Control
    Friend WithEvents E_Con6 As NodalPay.E_Control
    Friend WithEvents E_Con12 As NodalPay.E_Control
    Friend WithEvents E_Con10 As NodalPay.E_Control
    Friend WithEvents E_Con8 As NodalPay.E_Control
    Friend WithEvents E_Con1 As NodalPay.E_Control
    Friend WithEvents E_Con4 As NodalPay.E_Control
    Friend WithEvents E_Con11 As NodalPay.E_Control
    Friend WithEvents E_Con15 As NodalPay.E_Control
    Friend WithEvents E_Con13 As NodalPay.E_Control
    Friend WithEvents E_Con5 As NodalPay.E_Control
    Friend WithEvents E_Con14 As NodalPay.E_Control
    Friend WithEvents E_Con3 As NodalPay.E_Control
    Friend WithEvents E_Con9 As NodalPay.E_Control
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents D_Headline1 As NodalPay.D_Headline
    Friend WithEvents C_Con15 As NodalPay.C_Control
    Friend WithEvents C_Con14 As NodalPay.C_Control
    Friend WithEvents C_Con13 As NodalPay.C_Control
    Friend WithEvents C_Con12 As NodalPay.C_Control
    Friend WithEvents C_Con11 As NodalPay.C_Control
    Friend WithEvents C_Con10 As NodalPay.C_Control
    Friend WithEvents C_Con9 As NodalPay.C_Control
    Friend WithEvents C_Con8 As NodalPay.C_Control
    Friend WithEvents C_Con7 As NodalPay.C_Control
    Friend WithEvents C_Con6 As NodalPay.C_Control
    Friend WithEvents C_Con5 As NodalPay.C_Control
    Friend WithEvents C_Con4 As NodalPay.C_Control
    Friend WithEvents C_Con3 As NodalPay.C_Control
    Friend WithEvents C_Con2 As NodalPay.C_Control
    Friend WithEvents C_Con1 As NodalPay.C_Control
    Friend WithEvents C_HeadLine1 As NodalPay.C_HeadLine
    Friend WithEvents D_Con15 As NodalPay.D_Control
    Friend WithEvents D_Con14 As NodalPay.D_Control
    Friend WithEvents D_Con13 As NodalPay.D_Control
    Friend WithEvents D_Con12 As NodalPay.D_Control
    Friend WithEvents D_Con11 As NodalPay.D_Control
    Friend WithEvents D_Con10 As NodalPay.D_Control
    Friend WithEvents D_Con9 As NodalPay.D_Control
    Friend WithEvents D_Con8 As NodalPay.D_Control
    Friend WithEvents D_Con7 As NodalPay.D_Control
    Friend WithEvents D_Con6 As NodalPay.D_Control
    Friend WithEvents D_Con5 As NodalPay.D_Control
    Friend WithEvents D_Con4 As NodalPay.D_Control
    Friend WithEvents D_Con3 As NodalPay.D_Control
    Friend WithEvents D_Con2 As NodalPay.D_Control
    Friend WithEvents D_Con1 As NodalPay.D_Control
    Friend WithEvents ComboTemplateGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnFixSequence As System.Windows.Forms.ToolStripButton
End Class
