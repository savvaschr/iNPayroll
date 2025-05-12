<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInterfaceToNodal
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
        Me.txtIdTo = New System.Windows.Forms.TextBox
        Me.lblIdTo = New System.Windows.Forms.Label
        Me.txtIdFrom = New System.Windows.Forms.TextBox
        Me.lblIdFrom = New System.Windows.Forms.Label
        Me.btnExtract = New System.Windows.Forms.Button
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.BtnRegenerate = New System.Windows.Forms.Button
        Me.Bat_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_FromId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_ToId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_Creationtimes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_CreationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_UpdateDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bat_UpdatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LblProgress = New System.Windows.Forms.Label
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIdTo
        '
        Me.txtIdTo.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdTo.Location = New System.Drawing.Point(108, 33)
        Me.txtIdTo.Name = "txtIdTo"
        Me.txtIdTo.ReadOnly = True
        Me.txtIdTo.Size = New System.Drawing.Size(148, 20)
        Me.txtIdTo.TabIndex = 11
        '
        'lblIdTo
        '
        Me.lblIdTo.AutoSize = True
        Me.lblIdTo.Location = New System.Drawing.Point(12, 27)
        Me.lblIdTo.Name = "lblIdTo"
        Me.lblIdTo.Size = New System.Drawing.Size(68, 13)
        Me.lblIdTo.TabIndex = 10
        Me.lblIdTo.Text = "Extract To Id"
        '
        'txtIdFrom
        '
        Me.txtIdFrom.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdFrom.Location = New System.Drawing.Point(108, 6)
        Me.txtIdFrom.Name = "txtIdFrom"
        Me.txtIdFrom.ReadOnly = True
        Me.txtIdFrom.Size = New System.Drawing.Size(148, 20)
        Me.txtIdFrom.TabIndex = 9
        '
        'lblIdFrom
        '
        Me.lblIdFrom.AutoSize = True
        Me.lblIdFrom.Location = New System.Drawing.Point(12, 9)
        Me.lblIdFrom.Name = "lblIdFrom"
        Me.lblIdFrom.Size = New System.Drawing.Size(80, 13)
        Me.lblIdFrom.TabIndex = 8
        Me.lblIdFrom.Text = "Extract From ID"
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(262, 3)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(241, 23)
        Me.btnExtract.TabIndex = 7
        Me.btnExtract.Text = "Create Interface File"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Bat_Id, Me.Bat_FromId, Me.Bat_ToId, Me.Bat_Creationtimes, Me.Bat_CreationDate, Me.Bat_CreatedBy, Me.Bat_UpdateDate, Me.Bat_UpdatedBy})
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(12, 87)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(864, 488)
        Me.DG1.TabIndex = 14
        '
        'BtnRegenerate
        '
        Me.BtnRegenerate.Location = New System.Drawing.Point(262, 33)
        Me.BtnRegenerate.Name = "BtnRegenerate"
        Me.BtnRegenerate.Size = New System.Drawing.Size(241, 23)
        Me.BtnRegenerate.TabIndex = 15
        Me.BtnRegenerate.Text = "Re Generate File"
        Me.BtnRegenerate.UseVisualStyleBackColor = True
        '
        'Bat_Id
        '
        Me.Bat_Id.DataPropertyName = "Bat_Id"
        Me.Bat_Id.HeaderText = "Bat_Id"
        Me.Bat_Id.Name = "Bat_Id"
        Me.Bat_Id.Visible = False
        '
        'Bat_FromId
        '
        Me.Bat_FromId.DataPropertyName = "Bat_FromId"
        Me.Bat_FromId.HeaderText = "From Id"
        Me.Bat_FromId.Name = "Bat_FromId"
        '
        'Bat_ToId
        '
        Me.Bat_ToId.DataPropertyName = "Bat_ToId"
        Me.Bat_ToId.HeaderText = "To Id"
        Me.Bat_ToId.Name = "Bat_ToId"
        '
        'Bat_Creationtimes
        '
        Me.Bat_Creationtimes.DataPropertyName = "Bat_Creationtimes"
        Me.Bat_Creationtimes.HeaderText = "Creation Times"
        Me.Bat_Creationtimes.Name = "Bat_Creationtimes"
        '
        'Bat_CreationDate
        '
        Me.Bat_CreationDate.DataPropertyName = "Bat_CreationDate"
        Me.Bat_CreationDate.HeaderText = "Creation Date"
        Me.Bat_CreationDate.Name = "Bat_CreationDate"
        '
        'Bat_CreatedBy
        '
        Me.Bat_CreatedBy.DataPropertyName = "CreatedBy"
        Me.Bat_CreatedBy.HeaderText = "Created By"
        Me.Bat_CreatedBy.Name = "Bat_CreatedBy"
        '
        'Bat_UpdateDate
        '
        Me.Bat_UpdateDate.DataPropertyName = "Bat_UpdateDate"
        Me.Bat_UpdateDate.HeaderText = "Update Date"
        Me.Bat_UpdateDate.Name = "Bat_UpdateDate"
        '
        'Bat_UpdatedBy
        '
        Me.Bat_UpdatedBy.DataPropertyName = "UpdatedBy"
        Me.Bat_UpdatedBy.HeaderText = "Updated By"
        Me.Bat_UpdatedBy.Name = "Bat_UpdatedBy"
        '
        'LblProgress
        '
        Me.LblProgress.AutoSize = True
        Me.LblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblProgress.ForeColor = System.Drawing.Color.Red
        Me.LblProgress.Location = New System.Drawing.Point(259, 59)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(349, 20)
        Me.LblProgress.TabIndex = 16
        Me.LblProgress.Text = "Please Wait Interface File creation in progress ..."
        Me.LblProgress.Visible = False
        '
        'FrmInterfaceToNodal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(888, 587)
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.BtnRegenerate)
        Me.Controls.Add(Me.DG1)
        Me.Controls.Add(Me.txtIdTo)
        Me.Controls.Add(Me.lblIdTo)
        Me.Controls.Add(Me.txtIdFrom)
        Me.Controls.Add(Me.lblIdFrom)
        Me.Controls.Add(Me.btnExtract)
        Me.Name = "FrmInterfaceToNodal"
        Me.Text = "FrmInterfaceToNodal"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdTo As System.Windows.Forms.TextBox
    Friend WithEvents lblIdTo As System.Windows.Forms.Label
    Friend WithEvents txtIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblIdFrom As System.Windows.Forms.Label
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRegenerate As System.Windows.Forms.Button
    Friend WithEvents Bat_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_FromId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_ToId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_Creationtimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_CreationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_UpdateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bat_UpdatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblProgress As System.Windows.Forms.Label
End Class
