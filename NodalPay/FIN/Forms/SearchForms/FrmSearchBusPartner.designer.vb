<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchBusPartner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSearchBusPartner))
        Me.btnSearch = New System.Windows.Forms.Button
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Adr1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnPrevius = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(73, 104)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'DG1
        '
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.DescL, Me.DescS, Me.Adr1, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DG1.Location = New System.Drawing.Point(12, 133)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(664, 392)
        Me.DG1.TabIndex = 5
        '
        'Code
        '
        Me.Code.DataPropertyName = "BusPrt_Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        '
        'DescL
        '
        Me.DescL.DataPropertyName = "BusPrt_DescriptionL"
        Me.DescL.HeaderText = "Long Description"
        Me.DescL.Name = "DescL"
        Me.DescL.Width = 170
        '
        'DescS
        '
        Me.DescS.DataPropertyName = "BusPrt_DescriptionS"
        Me.DescS.HeaderText = "Short Description"
        Me.DescS.Name = "DescS"
        '
        'Adr1
        '
        Me.Adr1.DataPropertyName = "Adr_Line1"
        Me.Adr1.HeaderText = "Address Line 1"
        Me.Adr1.Name = "Adr1"
        Me.Adr1.Width = 105
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Adr_Line2"
        Me.Column1.HeaderText = "Address Line 2"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 105
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Adr_Line3"
        Me.Column2.HeaderText = "Address Line 3"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 105
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Adr_Line4"
        Me.Column3.HeaderText = "Address Line 4"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 105
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Adr_Telephone1"
        Me.Column4.HeaderText = "Phone 1"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "adr_Telephone2"
        Me.Column5.HeaderText = "Phone 2"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Adr_Id"
        Me.Column6.HeaderText = "Adr_Id"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'txtPhone
        '
        Me.txtPhone.AcceptsReturn = True
        Me.txtPhone.Location = New System.Drawing.Point(73, 3)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(191, 20)
        Me.txtPhone.TabIndex = 0
        '
        'txtCode
        '
        Me.txtCode.AcceptsReturn = True
        Me.txtCode.Location = New System.Drawing.Point(73, 29)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(191, 20)
        Me.txtCode.TabIndex = 1
        '
        'txtAddress
        '
        Me.txtAddress.AcceptsReturn = True
        Me.txtAddress.Location = New System.Drawing.Point(72, 77)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(367, 20)
        Me.txtAddress.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.Location = New System.Drawing.Point(73, 53)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(366, 20)
        Me.txtDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Phone"
        '
        'BtnNext
        '
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(601, 531)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 6
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnPrevius
        '
        Me.BtnPrevius.Enabled = False
        Me.BtnPrevius.Image = CType(resources.GetObject("BtnPrevius.Image"), System.Drawing.Image)
        Me.BtnPrevius.Location = New System.Drawing.Point(520, 531)
        Me.BtnPrevius.Name = "BtnPrevius"
        Me.BtnPrevius.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevius.TabIndex = 7
        Me.BtnPrevius.UseVisualStyleBackColor = True
        '
        'FrmSearchBusPartner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(688, 560)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevius)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "FrmSearchBusPartner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search For Customer"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnPrevius As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adr1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
