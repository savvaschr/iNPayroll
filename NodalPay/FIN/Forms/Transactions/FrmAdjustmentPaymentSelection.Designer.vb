<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdjustmentPaymentSelection
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
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.AccLin_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccLin_JouNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccLin_DocDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccLin_UnAllocBalanceLC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cur_AlphaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Acc_LinUnAllocBalanceTC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.BtnProceed = New System.Windows.Forms.Button
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.AllowUserToOrderColumns = True
        Me.DG1.AllowUserToResizeColumns = False
        Me.DG1.AllowUserToResizeRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccLin_Id, Me.AccLin_JouNo, Me.AccLin_DocDate, Me.AccLin_UnAllocBalanceLC, Me.Cur_AlphaCode, Me.Acc_LinUnAllocBalanceTC, Me.Selected, Me.Amount})
        Me.DG1.Location = New System.Drawing.Point(12, 0)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(799, 346)
        Me.DG1.TabIndex = 0
        '
        'AccLin_Id
        '
        Me.AccLin_Id.DataPropertyName = "AccLin_Id"
        Me.AccLin_Id.HeaderText = "Id"
        Me.AccLin_Id.Name = "AccLin_Id"
        Me.AccLin_Id.ReadOnly = True
        Me.AccLin_Id.Visible = False
        '
        'AccLin_JouNo
        '
        Me.AccLin_JouNo.DataPropertyName = "AccLin_JouNo"
        Me.AccLin_JouNo.HeaderText = "Journal No."
        Me.AccLin_JouNo.Name = "AccLin_JouNo"
        Me.AccLin_JouNo.ReadOnly = True
        Me.AccLin_JouNo.Width = 120
        '
        'AccLin_DocDate
        '
        Me.AccLin_DocDate.DataPropertyName = "AccLin_DocDate"
        Me.AccLin_DocDate.HeaderText = "Doc.Date"
        Me.AccLin_DocDate.Name = "AccLin_DocDate"
        Me.AccLin_DocDate.ReadOnly = True
        '
        'AccLin_UnAllocBalanceLC
        '
        Me.AccLin_UnAllocBalanceLC.DataPropertyName = "AccLin_UnAllocBalanceLC"
        Me.AccLin_UnAllocBalanceLC.HeaderText = "Unallocate Local Balance"
        Me.AccLin_UnAllocBalanceLC.Name = "AccLin_UnAllocBalanceLC"
        Me.AccLin_UnAllocBalanceLC.ReadOnly = True
        Me.AccLin_UnAllocBalanceLC.Width = 110
        '
        'Cur_AlphaCode
        '
        Me.Cur_AlphaCode.DataPropertyName = "Cur_AlphaCode"
        Me.Cur_AlphaCode.HeaderText = "Currency"
        Me.Cur_AlphaCode.Name = "Cur_AlphaCode"
        Me.Cur_AlphaCode.ReadOnly = True
        '
        'Acc_LinUnAllocBalanceTC
        '
        Me.Acc_LinUnAllocBalanceTC.DataPropertyName = "AccLin_UnAllocBalanceTC"
        Me.Acc_LinUnAllocBalanceTC.HeaderText = "Unallocated Transaction Balance"
        Me.Acc_LinUnAllocBalanceTC.Name = "Acc_LinUnAllocBalanceTC"
        Me.Acc_LinUnAllocBalanceTC.ReadOnly = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.HeaderText = "Select"
        Me.Selected.Name = "Selected"
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 110
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalAmount.Location = New System.Drawing.Point(711, 381)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 2
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(711, 352)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 23)
        Me.Button5.TabIndex = 97
        Me.Button5.Tag = "2"
        Me.Button5.Text = "Total Value"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCancel)
        Me.GroupBox4.Controls.Add(Me.BtnProceed)
        Me.GroupBox4.Location = New System.Drawing.Point(500, 352)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(185, 37)
        Me.GroupBox4.TabIndex = 98
        Me.GroupBox4.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(100, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 66
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'BtnProceed
        '
        Me.BtnProceed.Location = New System.Drawing.Point(9, 9)
        Me.BtnProceed.Name = "BtnProceed"
        Me.BtnProceed.Size = New System.Drawing.Size(75, 23)
        Me.BtnProceed.TabIndex = 65
        Me.BtnProceed.Text = "&Proceed"
        Me.BtnProceed.UseVisualStyleBackColor = True
        '
        'FrmAdjustmentPaymentSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(824, 410)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmAdjustmentPaymentSelection"
        Me.Text = "FrmAdjustmentPaymentSelection"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents AccLin_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccLin_JouNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccLin_DocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccLin_UnAllocBalanceLC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_AlphaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acc_LinUnAllocBalanceTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnProceed As System.Windows.Forms.Button
End Class
