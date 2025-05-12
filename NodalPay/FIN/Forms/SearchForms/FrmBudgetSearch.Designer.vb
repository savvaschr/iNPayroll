<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBudgetSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBudgetSearch))
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescL = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.DescL})
        Me.DG1.Location = New System.Drawing.Point(15, 48)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(471, 352)
        Me.DG1.TabIndex = 21
        '
        'BtnNext
        '
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(411, 406)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 22
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Enabled = False
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(330, 406)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 23
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.Location = New System.Drawing.Point(78, 22)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(280, 20)
        Me.txtDescription.TabIndex = 25
        '
        'txtCode
        '
        Me.txtCode.AcceptsReturn = True
        Me.txtCode.Location = New System.Drawing.Point(78, 2)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(191, 20)
        Me.txtCode.TabIndex = 24
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(414, 19)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 26
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Code
        '
        Me.Code.DataPropertyName = "Bud_Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        '
        'DescL
        '
        Me.DescL.DataPropertyName = "Bud_DescriptionL"
        Me.DescL.HeaderText = "Long Description"
        Me.DescL.Name = "DescL"
        Me.DescL.Width = 300
        '
        'FrmBudgetSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(498, 433)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmBudgetSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search For Budget"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
