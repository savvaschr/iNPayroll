<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNavInterfaceHistory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TempGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FirstCreation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastCreation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Times = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnRegenerate = New System.Windows.Forms.Button
        Me.btnSenddataToExelsys = New System.Windows.Forms.Button
        Me.btnBatchCorrection = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBNOFTP = New System.Windows.Forms.CheckBox
        Me.cbreverse = New System.Windows.Forms.CheckBox
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG1
        '
        Me.DG1.AllowUserToAddRows = False
        Me.DG1.AllowUserToDeleteRows = False
        Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Period, Me.IdFrom, Me.IdTo, Me.TempGroup, Me.User, Me.FirstCreation, Me.LastCreation, Me.Times})
        Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DG1.Location = New System.Drawing.Point(12, 12)
        Me.DG1.Name = "DG1"
        Me.DG1.Size = New System.Drawing.Size(971, 339)
        Me.DG1.TabIndex = 0
        '
        'Id
        '
        Me.Id.DataPropertyName = "GenBat_Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 80
        '
        'Period
        '
        Me.Period.DataPropertyName = "PrdCod_DescriptionL"
        Me.Period.HeaderText = "Period"
        Me.Period.Name = "Period"
        '
        'IdFrom
        '
        Me.IdFrom.DataPropertyName = "GenBat_IdFrom"
        Me.IdFrom.HeaderText = "From"
        Me.IdFrom.Name = "IdFrom"
        Me.IdFrom.Width = 80
        '
        'IdTo
        '
        Me.IdTo.DataPropertyName = "GenBat_IdTo"
        Me.IdTo.HeaderText = "IdTo"
        Me.IdTo.Name = "IdTo"
        Me.IdTo.Width = 80
        '
        'TempGroup
        '
        Me.TempGroup.DataPropertyName = "TmpGrp_Code"
        Me.TempGroup.HeaderText = "Template Group"
        Me.TempGroup.Name = "TempGroup"
        '
        'User
        '
        Me.User.DataPropertyName = "GenBat_User"
        Me.User.HeaderText = "User"
        Me.User.Name = "User"
        '
        'FirstCreation
        '
        Me.FirstCreation.DataPropertyName = "GenBat_FirstCreation"
        DataGridViewCellStyle1.Format = "G"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FirstCreation.DefaultCellStyle = DataGridViewCellStyle1
        Me.FirstCreation.HeaderText = "First Creation At"
        Me.FirstCreation.Name = "FirstCreation"
        Me.FirstCreation.Width = 120
        '
        'LastCreation
        '
        Me.LastCreation.DataPropertyName = "GenBat_LastCreation"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.LastCreation.DefaultCellStyle = DataGridViewCellStyle2
        Me.LastCreation.HeaderText = "Last Creation At"
        Me.LastCreation.Name = "LastCreation"
        Me.LastCreation.Width = 120
        '
        'Times
        '
        Me.Times.DataPropertyName = "GenBat_Times"
        Me.Times.HeaderText = "Creation Times"
        Me.Times.Name = "Times"
        '
        'btnRegenerate
        '
        Me.btnRegenerate.Location = New System.Drawing.Point(825, 371)
        Me.btnRegenerate.Name = "btnRegenerate"
        Me.btnRegenerate.Size = New System.Drawing.Size(158, 23)
        Me.btnRegenerate.TabIndex = 1
        Me.btnRegenerate.Text = "Regenerate"
        Me.btnRegenerate.UseVisualStyleBackColor = True
        '
        'btnSenddataToExelsys
        '
        Me.btnSenddataToExelsys.Location = New System.Drawing.Point(12, 371)
        Me.btnSenddataToExelsys.Name = "btnSenddataToExelsys"
        Me.btnSenddataToExelsys.Size = New System.Drawing.Size(173, 23)
        Me.btnSenddataToExelsys.TabIndex = 2
        Me.btnSenddataToExelsys.Text = "Send Data To Exelsys"
        Me.btnSenddataToExelsys.UseVisualStyleBackColor = True
        '
        'btnBatchCorrection
        '
        Me.btnBatchCorrection.Location = New System.Drawing.Point(672, 371)
        Me.btnBatchCorrection.Name = "btnBatchCorrection"
        Me.btnBatchCorrection.Size = New System.Drawing.Size(135, 23)
        Me.btnBatchCorrection.TabIndex = 3
        Me.btnBatchCorrection.Text = "Batch Correction"
        Me.btnBatchCorrection.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 4
        '
        'CBNOFTP
        '
        Me.CBNOFTP.AutoSize = True
        Me.CBNOFTP.Location = New System.Drawing.Point(210, 375)
        Me.CBNOFTP.Name = "CBNOFTP"
        Me.CBNOFTP.Size = New System.Drawing.Size(115, 17)
        Me.CBNOFTP.TabIndex = 5
        Me.CBNOFTP.Text = "Dont FTP to Nodal"
        Me.CBNOFTP.UseVisualStyleBackColor = True
        '
        'cbreverse
        '
        Me.cbreverse.AutoSize = True
        Me.cbreverse.Location = New System.Drawing.Point(367, 375)
        Me.cbreverse.Name = "cbreverse"
        Me.cbreverse.Size = New System.Drawing.Size(66, 17)
        Me.cbreverse.TabIndex = 6
        Me.cbreverse.Text = "Reverse"
        Me.cbreverse.UseVisualStyleBackColor = True
        '
        'FrmNavInterfaceHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 406)
        Me.Controls.Add(Me.cbreverse)
        Me.Controls.Add(Me.CBNOFTP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBatchCorrection)
        Me.Controls.Add(Me.btnSenddataToExelsys)
        Me.Controls.Add(Me.btnRegenerate)
        Me.Controls.Add(Me.DG1)
        Me.Name = "FrmNavInterfaceHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Navision Interface History"
        CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegenerate As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirstCreation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastCreation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Times As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSenddataToExelsys As System.Windows.Forms.Button
    Friend WithEvents btnBatchCorrection As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBNOFTP As System.Windows.Forms.CheckBox
    Friend WithEvents cbreverse As System.Windows.Forms.CheckBox
End Class
