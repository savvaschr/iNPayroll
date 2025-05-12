<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiTrxnHeader
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBusCur = New System.Windows.Forms.Button
        Me.btnTrxCur = New System.Windows.Forms.Button
        Me.Dg1 = New System.Windows.Forms.DataGridView
        Me.LineNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HdrId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gross = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineDiscPerc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineDiscVAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverAllDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverAllDiscVAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineTotalVAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineTotalLocal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineTotalLocalVAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VATCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VATRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn1Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn2Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn3Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn4Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn5Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn6Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn7Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn8Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn9Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AcLAn10Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComboVatDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBAllocation = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAllocRate = New System.Windows.Forms.TextBox
        Me.CBAllocated = New System.Windows.Forms.CheckBox
        Me.BtnAllocation = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.txtTotalLC = New System.Windows.Forms.TextBox
        Me.btnAllocDispl = New System.Windows.Forms.Button
        Me.txtAllocTotalAmount = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtTotalLineDisc = New System.Windows.Forms.TextBox
        Me.btnOverAllDisc = New System.Windows.Forms.Button
        Me.TabHeader = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GBMain = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtXRefNo = New System.Windows.Forms.TextBox
        Me.CBVatIncluded = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBVatEnabled = New System.Windows.Forms.CheckBox
        Me.txtAcctRefNo = New System.Windows.Forms.TextBox
        Me.txtBusPartnerDesc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnBusPrtSearch = New System.Windows.Forms.Button
        Me.txtBusPartnerCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblDueDate = New System.Windows.Forms.Label
        Me.MSKTxtDueDate = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MSKTxtInvDate = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCurRate = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.ComboCurency = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.MSKTxtPostDate = New System.Windows.Forms.MaskedTextBox
        Me.ComboTrxnCode = New System.Windows.Forms.ComboBox
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GBDetails = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtHeaderComments = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtAmendDate = New System.Windows.Forms.TextBox
        Me.txtAmendBy = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCreationDate = New System.Windows.Forms.TextBox
        Me.txtCreatedBy = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtOverAllDisc = New System.Windows.Forms.TextBox
        Me.txtTotalVAT = New System.Windows.Forms.TextBox
        Me.txtOverAllDiscount2 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.GBLineBtns = New System.Windows.Forms.GroupBox
        Me.btnEdit = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.GBLine = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtVATRate = New System.Windows.Forms.TextBox
        Me.LblLineDisc = New System.Windows.Forms.Label
        Me.txtLineDisc = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ComboVAT = New System.Windows.Forms.ComboBox
        Me.btnAccountSearch = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtAccountDesc = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.LblAn8 = New System.Windows.Forms.Label
        Me.LblAn7 = New System.Windows.Forms.Label
        Me.LblAn10 = New System.Windows.Forms.Label
        Me.LblAn9 = New System.Windows.Forms.Label
        Me.LblAn6 = New System.Windows.Forms.Label
        Me.LblAn3 = New System.Windows.Forms.Label
        Me.LblAn2 = New System.Windows.Forms.Label
        Me.LblAn5 = New System.Windows.Forms.Label
        Me.LblAn4 = New System.Windows.Forms.Label
        Me.LblAn1 = New System.Windows.Forms.Label
        Me.ComboAnl7 = New System.Windows.Forms.ComboBox
        Me.txtAccountCode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboAnl1 = New System.Windows.Forms.ComboBox
        Me.ComboAnl9 = New System.Windows.Forms.ComboBox
        Me.ComboAnl2 = New System.Windows.Forms.ComboBox
        Me.ComboAnl10 = New System.Windows.Forms.ComboBox
        Me.ComboAnl6 = New System.Windows.Forms.ComboBox
        Me.ComboAnl8 = New System.Windows.Forms.ComboBox
        Me.ComboAnl4 = New System.Windows.Forms.ComboBox
        Me.ComboAnl3 = New System.Windows.Forms.ComboBox
        Me.ComboAnl5 = New System.Windows.Forms.ComboBox
        Me.ComboBox13 = New System.Windows.Forms.ComboBox
        Me.txtTotalNet = New System.Windows.Forms.TextBox
        Me.txtTotalGross = New System.Windows.Forms.TextBox
        Me.Err1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err3 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err4 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err5 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err6 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Err7 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBAllocation.SuspendLayout()
        Me.TabHeader.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBMain.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GBDetails.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GBLineBtns.SuspendLayout()
        Me.GBLine.SuspendLayout()
        CType(Me.Err1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Err7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBusCur)
        Me.GroupBox1.Controls.Add(Me.btnTrxCur)
        Me.GroupBox1.Controls.Add(Me.Dg1)
        Me.GroupBox1.Controls.Add(Me.GBAllocation)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.txtTotalLC)
        Me.GroupBox1.Controls.Add(Me.btnAllocDispl)
        Me.GroupBox1.Controls.Add(Me.txtAllocTotalAmount)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtTotalLineDisc)
        Me.GroupBox1.Controls.Add(Me.btnOverAllDisc)
        Me.GroupBox1.Controls.Add(Me.TabHeader)
        Me.GroupBox1.Controls.Add(Me.txtOverAllDisc)
        Me.GroupBox1.Controls.Add(Me.txtTotalVAT)
        Me.GroupBox1.Controls.Add(Me.txtOverAllDiscount2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GBLineBtns)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.GBLine)
        Me.GroupBox1.Controls.Add(Me.ComboBox13)
        Me.GroupBox1.Controls.Add(Me.txtTotalNet)
        Me.GroupBox1.Controls.Add(Me.txtTotalGross)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 549)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnBusCur
        '
        Me.btnBusCur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusCur.Location = New System.Drawing.Point(722, 498)
        Me.btnBusCur.Name = "btnBusCur"
        Me.btnBusCur.Size = New System.Drawing.Size(41, 23)
        Me.btnBusCur.TabIndex = 103
        Me.btnBusCur.Tag = "2"
        Me.btnBusCur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBusCur.UseVisualStyleBackColor = True
        '
        'btnTrxCur
        '
        Me.btnTrxCur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrxCur.Location = New System.Drawing.Point(608, 498)
        Me.btnTrxCur.Name = "btnTrxCur"
        Me.btnTrxCur.Size = New System.Drawing.Size(41, 23)
        Me.btnTrxCur.TabIndex = 102
        Me.btnTrxCur.Tag = "2"
        Me.btnTrxCur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTrxCur.UseVisualStyleBackColor = True
        '
        'Dg1
        '
        Me.Dg1.AllowUserToAddRows = False
        Me.Dg1.AllowUserToDeleteRows = False
        Me.Dg1.AllowUserToResizeColumns = False
        Me.Dg1.AllowUserToResizeRows = False
        Me.Dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineNo, Me.HdrId, Me.AccCode, Me.AccDesc, Me.Amount, Me.Gross, Me.LineDiscPerc, Me.LineDisc, Me.LineDiscVAT, Me.OverAllDisc, Me.OverAllDiscVAT, Me.LineTotal, Me.LineTotalVAT, Me.LineTotalLocal, Me.LineTotalLocalVAT, Me.VATCode, Me.VATRate, Me.Comments, Me.AcLAn1Code, Me.AcLAn2Code, Me.AcLAn3Code, Me.AcLAn4Code, Me.AcLAn5Code, Me.AcLAn6Code, Me.AcLAn7Code, Me.AcLAn8Code, Me.AcLAn9Code, Me.AcLAn10Code, Me.ComboVatDesc})
        Me.Dg1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dg1.Location = New System.Drawing.Point(7, 260)
        Me.Dg1.Name = "Dg1"
        Me.Dg1.Size = New System.Drawing.Size(952, 232)
        Me.Dg1.TabIndex = 0
        '
        'LineNo
        '
        Me.LineNo.DataPropertyName = "LineNo"
        Me.LineNo.HeaderText = "LineNo"
        Me.LineNo.Name = "LineNo"
        Me.LineNo.Width = 35
        '
        'HdrId
        '
        Me.HdrId.DataPropertyName = "HdrId"
        Me.HdrId.HeaderText = "HdrId"
        Me.HdrId.Name = "HdrId"
        Me.HdrId.Width = 80
        '
        'AccCode
        '
        Me.AccCode.DataPropertyName = "AccCode"
        Me.AccCode.HeaderText = "AccCode"
        Me.AccCode.Name = "AccCode"
        Me.AccCode.Width = 200
        '
        'AccDesc
        '
        Me.AccDesc.DataPropertyName = "AccDesc"
        Me.AccDesc.HeaderText = "AccDesc"
        Me.AccDesc.Name = "AccDesc"
        Me.AccDesc.Width = 90
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        DataGridViewCellStyle1.Format = "0.00"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle1
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'Gross
        '
        Me.Gross.DataPropertyName = "Gross"
        DataGridViewCellStyle2.Format = "0.00"
        Me.Gross.DefaultCellStyle = DataGridViewCellStyle2
        Me.Gross.HeaderText = "Gross"
        Me.Gross.Name = "Gross"
        Me.Gross.Width = 90
        '
        'LineDiscPerc
        '
        Me.LineDiscPerc.DataPropertyName = "LineDiscPerc"
        DataGridViewCellStyle3.Format = "0.00"
        Me.LineDiscPerc.DefaultCellStyle = DataGridViewCellStyle3
        Me.LineDiscPerc.HeaderText = "LineDiscPerc"
        Me.LineDiscPerc.Name = "LineDiscPerc"
        '
        'LineDisc
        '
        Me.LineDisc.DataPropertyName = "LineDisc"
        DataGridViewCellStyle4.Format = "0.00"
        Me.LineDisc.DefaultCellStyle = DataGridViewCellStyle4
        Me.LineDisc.HeaderText = "LineDisc"
        Me.LineDisc.Name = "LineDisc"
        Me.LineDisc.Width = 90
        '
        'LineDiscVAT
        '
        Me.LineDiscVAT.DataPropertyName = "LineDiscVAT"
        Me.LineDiscVAT.HeaderText = "LineDiscVAT"
        Me.LineDiscVAT.Name = "LineDiscVAT"
        Me.LineDiscVAT.Width = 110
        '
        'OverAllDisc
        '
        Me.OverAllDisc.DataPropertyName = "OverAllDisc"
        Me.OverAllDisc.HeaderText = "OverAllDisc"
        Me.OverAllDisc.Name = "OverAllDisc"
        Me.OverAllDisc.Width = 110
        '
        'OverAllDiscVAT
        '
        Me.OverAllDiscVAT.DataPropertyName = "OverAllDiscVAT"
        Me.OverAllDiscVAT.HeaderText = "OverAllDiscVAT"
        Me.OverAllDiscVAT.Name = "OverAllDiscVAT"
        Me.OverAllDiscVAT.Width = 250
        '
        'LineTotal
        '
        Me.LineTotal.DataPropertyName = "LineTotal"
        DataGridViewCellStyle5.Format = "0.00"
        Me.LineTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.LineTotal.HeaderText = "LineTotal"
        Me.LineTotal.Name = "LineTotal"
        '
        'LineTotalVAT
        '
        Me.LineTotalVAT.DataPropertyName = "LineTotalVAT"
        DataGridViewCellStyle6.Format = "0.00"
        Me.LineTotalVAT.DefaultCellStyle = DataGridViewCellStyle6
        Me.LineTotalVAT.HeaderText = "LineTotalVAT"
        Me.LineTotalVAT.Name = "LineTotalVAT"
        '
        'LineTotalLocal
        '
        Me.LineTotalLocal.DataPropertyName = "LineTotalLocal"
        DataGridViewCellStyle7.Format = "0.00"
        Me.LineTotalLocal.DefaultCellStyle = DataGridViewCellStyle7
        Me.LineTotalLocal.HeaderText = "LineTotalLocal"
        Me.LineTotalLocal.Name = "LineTotalLocal"
        '
        'LineTotalLocalVAT
        '
        Me.LineTotalLocalVAT.DataPropertyName = "LineTotalLocalVAT"
        DataGridViewCellStyle8.Format = "0.00"
        Me.LineTotalLocalVAT.DefaultCellStyle = DataGridViewCellStyle8
        Me.LineTotalLocalVAT.HeaderText = "LineTotalLocalVAT"
        Me.LineTotalLocalVAT.Name = "LineTotalLocalVAT"
        '
        'VATCode
        '
        Me.VATCode.DataPropertyName = "VATCode"
        Me.VATCode.HeaderText = "VATCode"
        Me.VATCode.Name = "VATCode"
        '
        'VATRate
        '
        Me.VATRate.DataPropertyName = "VATRate"
        Me.VATRate.HeaderText = "VATRate"
        Me.VATRate.Name = "VATRate"
        '
        'Comments
        '
        Me.Comments.DataPropertyName = "Comments"
        Me.Comments.HeaderText = "Comments"
        Me.Comments.Name = "Comments"
        Me.Comments.Visible = False
        '
        'AcLAn1Code
        '
        Me.AcLAn1Code.DataPropertyName = "AcLAn1Code"
        Me.AcLAn1Code.HeaderText = "AcLAn1Code"
        Me.AcLAn1Code.Name = "AcLAn1Code"
        Me.AcLAn1Code.Visible = False
        '
        'AcLAn2Code
        '
        Me.AcLAn2Code.DataPropertyName = "AcLAn2Code"
        Me.AcLAn2Code.HeaderText = "AcLAn2Code"
        Me.AcLAn2Code.Name = "AcLAn2Code"
        Me.AcLAn2Code.Visible = False
        '
        'AcLAn3Code
        '
        Me.AcLAn3Code.DataPropertyName = "AcLAn3Code"
        Me.AcLAn3Code.HeaderText = "AcLAn3Code"
        Me.AcLAn3Code.Name = "AcLAn3Code"
        Me.AcLAn3Code.Visible = False
        '
        'AcLAn4Code
        '
        Me.AcLAn4Code.DataPropertyName = "AcLAn4Code"
        Me.AcLAn4Code.HeaderText = "AcLAn4Code"
        Me.AcLAn4Code.Name = "AcLAn4Code"
        Me.AcLAn4Code.Visible = False
        '
        'AcLAn5Code
        '
        Me.AcLAn5Code.DataPropertyName = "AcLAn5Code"
        Me.AcLAn5Code.HeaderText = "AcLAn5Code"
        Me.AcLAn5Code.Name = "AcLAn5Code"
        Me.AcLAn5Code.Visible = False
        '
        'AcLAn6Code
        '
        Me.AcLAn6Code.DataPropertyName = "AcLAn6Code"
        Me.AcLAn6Code.HeaderText = "AcLAn6Code"
        Me.AcLAn6Code.Name = "AcLAn6Code"
        Me.AcLAn6Code.Visible = False
        '
        'AcLAn7Code
        '
        Me.AcLAn7Code.DataPropertyName = "AcLAn7Code"
        Me.AcLAn7Code.HeaderText = "AcLAn7Code"
        Me.AcLAn7Code.Name = "AcLAn7Code"
        Me.AcLAn7Code.Visible = False
        '
        'AcLAn8Code
        '
        Me.AcLAn8Code.DataPropertyName = "AcLAn8Code"
        Me.AcLAn8Code.HeaderText = "AcLAn8Code"
        Me.AcLAn8Code.Name = "AcLAn8Code"
        Me.AcLAn8Code.Visible = False
        '
        'AcLAn9Code
        '
        Me.AcLAn9Code.DataPropertyName = "AcLAn9Code"
        Me.AcLAn9Code.HeaderText = "AcLAn9Code"
        Me.AcLAn9Code.Name = "AcLAn9Code"
        Me.AcLAn9Code.Visible = False
        '
        'AcLAn10Code
        '
        Me.AcLAn10Code.DataPropertyName = "AcLAn10Code"
        Me.AcLAn10Code.HeaderText = "AcLAn10Code"
        Me.AcLAn10Code.Name = "AcLAn10Code"
        Me.AcLAn10Code.Visible = False
        '
        'ComboVatDesc
        '
        Me.ComboVatDesc.DataPropertyName = "ComboVATDesc"
        Me.ComboVatDesc.HeaderText = "ComboVatDesc"
        Me.ComboVatDesc.Name = "ComboVatDesc"
        '
        'GBAllocation
        '
        Me.GBAllocation.Controls.Add(Me.Label16)
        Me.GBAllocation.Controls.Add(Me.txtAllocRate)
        Me.GBAllocation.Controls.Add(Me.CBAllocated)
        Me.GBAllocation.Controls.Add(Me.BtnAllocation)
        Me.GBAllocation.Location = New System.Drawing.Point(787, 491)
        Me.GBAllocation.Name = "GBAllocation"
        Me.GBAllocation.Size = New System.Drawing.Size(165, 52)
        Me.GBAllocation.TabIndex = 101
        Me.GBAllocation.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "Alloc.Cur.Rate"
        '
        'txtAllocRate
        '
        Me.txtAllocRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtAllocRate.Location = New System.Drawing.Point(95, 30)
        Me.txtAllocRate.Name = "txtAllocRate"
        Me.txtAllocRate.Size = New System.Drawing.Size(64, 20)
        Me.txtAllocRate.TabIndex = 98
        Me.txtAllocRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CBAllocated
        '
        Me.CBAllocated.AutoSize = True
        Me.CBAllocated.Location = New System.Drawing.Point(95, 11)
        Me.CBAllocated.Name = "CBAllocated"
        Me.CBAllocated.Size = New System.Drawing.Size(64, 17)
        Me.CBAllocated.TabIndex = 71
        Me.CBAllocated.Text = "Allocate"
        Me.CBAllocated.UseVisualStyleBackColor = True
        '
        'BtnAllocation
        '
        Me.BtnAllocation.Location = New System.Drawing.Point(6, 7)
        Me.BtnAllocation.Name = "BtnAllocation"
        Me.BtnAllocation.Size = New System.Drawing.Size(75, 23)
        Me.BtnAllocation.TabIndex = 70
        Me.BtnAllocation.Text = "Allocation"
        Me.BtnAllocation.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(438, 498)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 23)
        Me.Button6.TabIndex = 100
        Me.Button6.Tag = "2"
        Me.Button6.Text = "Total Val. Local Cur."
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtTotalLC
        '
        Me.txtTotalLC.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalLC.Location = New System.Drawing.Point(438, 523)
        Me.txtTotalLC.Name = "txtTotalLC"
        Me.txtTotalLC.ReadOnly = True
        Me.txtTotalLC.Size = New System.Drawing.Size(97, 20)
        Me.txtTotalLC.TabIndex = 99
        Me.txtTotalLC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAllocDispl
        '
        Me.btnAllocDispl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllocDispl.Location = New System.Drawing.Point(655, 498)
        Me.btnAllocDispl.Name = "btnAllocDispl"
        Me.btnAllocDispl.Size = New System.Drawing.Size(67, 23)
        Me.btnAllocDispl.TabIndex = 98
        Me.btnAllocDispl.Tag = "2"
        Me.btnAllocDispl.Text = "Allocation"
        Me.btnAllocDispl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAllocDispl.UseVisualStyleBackColor = True
        '
        'txtAllocTotalAmount
        '
        Me.txtAllocTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtAllocTotalAmount.Location = New System.Drawing.Point(655, 523)
        Me.txtAllocTotalAmount.Name = "txtAllocTotalAmount"
        Me.txtAllocTotalAmount.ReadOnly = True
        Me.txtAllocTotalAmount.Size = New System.Drawing.Size(108, 20)
        Me.txtAllocTotalAmount.TabIndex = 97
        Me.txtAllocTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(541, 498)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(67, 23)
        Me.Button5.TabIndex = 96
        Me.Button5.Tag = "2"
        Me.Button5.Text = "Total "
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(361, 498)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(71, 23)
        Me.Button4.TabIndex = 95
        Me.Button4.Tag = "2"
        Me.Button4.Text = "VAT Value"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(161, 498)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(71, 23)
        Me.Button3.TabIndex = 94
        Me.Button3.Tag = "2"
        Me.Button3.Text = "Total Net"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(84, 498)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 23)
        Me.Button2.TabIndex = 93
        Me.Button2.Tag = "2"
        Me.Button2.Text = "Line Disc."
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(7, 498)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 23)
        Me.Button1.TabIndex = 92
        Me.Button1.Tag = "2"
        Me.Button1.Text = "Total Gross"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotalLineDisc
        '
        Me.txtTotalLineDisc.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalLineDisc.Location = New System.Drawing.Point(84, 523)
        Me.txtTotalLineDisc.Name = "txtTotalLineDisc"
        Me.txtTotalLineDisc.ReadOnly = True
        Me.txtTotalLineDisc.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalLineDisc.TabIndex = 89
        Me.txtTotalLineDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOverAllDisc
        '
        Me.btnOverAllDisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOverAllDisc.Location = New System.Drawing.Point(238, 498)
        Me.btnOverAllDisc.Name = "btnOverAllDisc"
        Me.btnOverAllDisc.Size = New System.Drawing.Size(60, 23)
        Me.btnOverAllDisc.TabIndex = 86
        Me.btnOverAllDisc.Tag = "2"
        Me.btnOverAllDisc.Text = "Disc.(%)"
        Me.btnOverAllDisc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOverAllDisc.UseVisualStyleBackColor = True
        '
        'TabHeader
        '
        Me.TabHeader.Controls.Add(Me.TabPage1)
        Me.TabHeader.Controls.Add(Me.TabPage2)
        Me.TabHeader.Location = New System.Drawing.Point(7, 10)
        Me.TabHeader.Multiline = True
        Me.TabHeader.Name = "TabHeader"
        Me.TabHeader.SelectedIndex = 0
        Me.TabHeader.Size = New System.Drawing.Size(698, 127)
        Me.TabHeader.TabIndex = 68
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(690, 101)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBMain
        '
        Me.GBMain.Controls.Add(Me.Label12)
        Me.GBMain.Controls.Add(Me.txtXRefNo)
        Me.GBMain.Controls.Add(Me.CBVatIncluded)
        Me.GBMain.Controls.Add(Me.Label6)
        Me.GBMain.Controls.Add(Me.CBVatEnabled)
        Me.GBMain.Controls.Add(Me.txtAcctRefNo)
        Me.GBMain.Controls.Add(Me.txtBusPartnerDesc)
        Me.GBMain.Controls.Add(Me.Label5)
        Me.GBMain.Controls.Add(Me.btnBusPrtSearch)
        Me.GBMain.Controls.Add(Me.txtBusPartnerCode)
        Me.GBMain.Controls.Add(Me.Label4)
        Me.GBMain.Controls.Add(Me.lblDueDate)
        Me.GBMain.Controls.Add(Me.MSKTxtDueDate)
        Me.GBMain.Controls.Add(Me.Label2)
        Me.GBMain.Controls.Add(Me.MSKTxtInvDate)
        Me.GBMain.Controls.Add(Me.Label11)
        Me.GBMain.Controls.Add(Me.Label1)
        Me.GBMain.Controls.Add(Me.txtCurRate)
        Me.GBMain.Controls.Add(Me.Label29)
        Me.GBMain.Controls.Add(Me.ComboCurency)
        Me.GBMain.Controls.Add(Me.Label7)
        Me.GBMain.Controls.Add(Me.MSKTxtPostDate)
        Me.GBMain.Controls.Add(Me.ComboTrxnCode)
        Me.GBMain.Controls.Add(Me.txtRefNo)
        Me.GBMain.Location = New System.Drawing.Point(10, 0)
        Me.GBMain.Name = "GBMain"
        Me.GBMain.Size = New System.Drawing.Size(680, 98)
        Me.GBMain.TabIndex = 69
        Me.GBMain.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(459, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "XRef. No."
        '
        'txtXRefNo
        '
        Me.txtXRefNo.Location = New System.Drawing.Point(526, 49)
        Me.txtXRefNo.Name = "txtXRefNo"
        Me.txtXRefNo.Size = New System.Drawing.Size(132, 20)
        Me.txtXRefNo.TabIndex = 83
        '
        'CBVatIncluded
        '
        Me.CBVatIncluded.AutoSize = True
        Me.CBVatIncluded.Enabled = False
        Me.CBVatIncluded.Location = New System.Drawing.Point(281, 74)
        Me.CBVatIncluded.Name = "CBVatIncluded"
        Me.CBVatIncluded.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBVatIncluded.Size = New System.Drawing.Size(73, 17)
        Me.CBVatIncluded.TabIndex = 70
        Me.CBVatIncluded.Text = "  .VATIncl"
        Me.CBVatIncluded.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(459, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Acct. Ref."
        '
        'CBVatEnabled
        '
        Me.CBVatEnabled.AutoSize = True
        Me.CBVatEnabled.Enabled = False
        Me.CBVatEnabled.Location = New System.Drawing.Point(364, 74)
        Me.CBVatEnabled.Name = "CBVatEnabled"
        Me.CBVatEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBVatEnabled.Size = New System.Drawing.Size(89, 17)
        Me.CBVatEnabled.TabIndex = 69
        Me.CBVatEnabled.Text = "VAT Enabled"
        Me.CBVatEnabled.UseVisualStyleBackColor = True
        '
        'txtAcctRefNo
        '
        Me.txtAcctRefNo.Location = New System.Drawing.Point(526, 29)
        Me.txtAcctRefNo.Name = "txtAcctRefNo"
        Me.txtAcctRefNo.Size = New System.Drawing.Size(132, 20)
        Me.txtAcctRefNo.TabIndex = 81
        '
        'txtBusPartnerDesc
        '
        Me.txtBusPartnerDesc.BackColor = System.Drawing.SystemColors.Info
        Me.txtBusPartnerDesc.Location = New System.Drawing.Point(90, 31)
        Me.txtBusPartnerDesc.Name = "txtBusPartnerDesc"
        Me.txtBusPartnerDesc.ReadOnly = True
        Me.txtBusPartnerDesc.Size = New System.Drawing.Size(184, 20)
        Me.txtBusPartnerDesc.TabIndex = 80
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Description"
        '
        'btnBusPrtSearch
        '
        Me.btnBusPrtSearch.Location = New System.Drawing.Point(216, 11)
        Me.btnBusPrtSearch.Name = "btnBusPrtSearch"
        Me.btnBusPrtSearch.Size = New System.Drawing.Size(58, 21)
        Me.btnBusPrtSearch.TabIndex = 78
        Me.btnBusPrtSearch.Text = "Search"
        Me.btnBusPrtSearch.UseVisualStyleBackColor = True
        '
        'txtBusPartnerCode
        '
        Me.txtBusPartnerCode.Location = New System.Drawing.Point(90, 11)
        Me.txtBusPartnerCode.Name = "txtBusPartnerCode"
        Me.txtBusPartnerCode.Size = New System.Drawing.Size(89, 20)
        Me.txtBusPartnerCode.TabIndex = 76
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Bus.Partner"
        '
        'lblDueDate
        '
        Me.lblDueDate.AutoSize = True
        Me.lblDueDate.Location = New System.Drawing.Point(282, 51)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(53, 13)
        Me.lblDueDate.TabIndex = 75
        Me.lblDueDate.Text = "Due Date"
        '
        'MSKTxtDueDate
        '
        Me.MSKTxtDueDate.Location = New System.Drawing.Point(340, 48)
        Me.MSKTxtDueDate.Mask = "00/00/0000"
        Me.MSKTxtDueDate.Name = "MSKTxtDueDate"
        Me.MSKTxtDueDate.Size = New System.Drawing.Size(113, 20)
        Me.MSKTxtDueDate.TabIndex = 74
        Me.MSKTxtDueDate.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Inv. Date"
        '
        'MSKTxtInvDate
        '
        Me.MSKTxtInvDate.Location = New System.Drawing.Point(340, 29)
        Me.MSKTxtInvDate.Mask = "00/00/0000"
        Me.MSKTxtInvDate.Name = "MSKTxtInvDate"
        Me.MSKTxtInvDate.Size = New System.Drawing.Size(113, 20)
        Me.MSKTxtInvDate.TabIndex = 72
        Me.MSKTxtInvDate.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Curency"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Trxn. Code"
        '
        'txtCurRate
        '
        Me.txtCurRate.Location = New System.Drawing.Point(216, 72)
        Me.txtCurRate.Name = "txtCurRate"
        Me.txtCurRate.Size = New System.Drawing.Size(59, 20)
        Me.txtCurRate.TabIndex = 70
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(459, 13)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(47, 13)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "Ref. No."
        '
        'ComboCurency
        '
        Me.ComboCurency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCurency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCurency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCurency.FormattingEnabled = True
        Me.ComboCurency.Location = New System.Drawing.Point(90, 71)
        Me.ComboCurency.Name = "ComboCurency"
        Me.ComboCurency.Size = New System.Drawing.Size(120, 21)
        Me.ComboCurency.TabIndex = 69
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Post Date"
        '
        'MSKTxtPostDate
        '
        Me.MSKTxtPostDate.Location = New System.Drawing.Point(340, 10)
        Me.MSKTxtPostDate.Mask = "00/00/0000"
        Me.MSKTxtPostDate.Name = "MSKTxtPostDate"
        Me.MSKTxtPostDate.Size = New System.Drawing.Size(113, 20)
        Me.MSKTxtPostDate.TabIndex = 31
        Me.MSKTxtPostDate.ValidatingType = GetType(Date)
        '
        'ComboTrxnCode
        '
        Me.ComboTrxnCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboTrxnCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboTrxnCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTrxnCode.FormattingEnabled = True
        Me.ComboTrxnCode.Location = New System.Drawing.Point(90, 50)
        Me.ComboTrxnCode.Name = "ComboTrxnCode"
        Me.ComboTrxnCode.Size = New System.Drawing.Size(184, 21)
        Me.ComboTrxnCode.TabIndex = 67
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(526, 9)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(132, 20)
        Me.txtRefNo.TabIndex = 34
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GBDetails)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabPage2.Size = New System.Drawing.Size(690, 101)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GBDetails
        '
        Me.GBDetails.Controls.Add(Me.Label13)
        Me.GBDetails.Controls.Add(Me.txtHeaderComments)
        Me.GBDetails.Controls.Add(Me.Label23)
        Me.GBDetails.Controls.Add(Me.txtAmendDate)
        Me.GBDetails.Controls.Add(Me.txtAmendBy)
        Me.GBDetails.Controls.Add(Me.Label24)
        Me.GBDetails.Controls.Add(Me.Label26)
        Me.GBDetails.Controls.Add(Me.txtCreationDate)
        Me.GBDetails.Controls.Add(Me.txtCreatedBy)
        Me.GBDetails.Controls.Add(Me.Label25)
        Me.GBDetails.Location = New System.Drawing.Point(6, 2)
        Me.GBDetails.Name = "GBDetails"
        Me.GBDetails.Size = New System.Drawing.Size(680, 92)
        Me.GBDetails.TabIndex = 60
        Me.GBDetails.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Comments"
        '
        'txtHeaderComments
        '
        Me.txtHeaderComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtHeaderComments.Location = New System.Drawing.Point(90, 53)
        Me.txtHeaderComments.Name = "txtHeaderComments"
        Me.txtHeaderComments.Size = New System.Drawing.Size(554, 20)
        Me.txtHeaderComments.TabIndex = 60
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Created by"
        '
        'txtAmendDate
        '
        Me.txtAmendDate.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmendDate.Location = New System.Drawing.Point(442, 32)
        Me.txtAmendDate.Name = "txtAmendDate"
        Me.txtAmendDate.ReadOnly = True
        Me.txtAmendDate.Size = New System.Drawing.Size(136, 20)
        Me.txtAmendDate.TabIndex = 33
        Me.txtAmendDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmendBy
        '
        Me.txtAmendBy.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmendBy.Location = New System.Drawing.Point(442, 9)
        Me.txtAmendBy.Name = "txtAmendBy"
        Me.txtAmendBy.ReadOnly = True
        Me.txtAmendBy.Size = New System.Drawing.Size(136, 20)
        Me.txtAmendBy.TabIndex = 7
        Me.txtAmendBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(345, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 57
        Me.Label24.Text = "Amendment Date"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 34)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Creation Date"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.BackColor = System.Drawing.SystemColors.Info
        Me.txtCreationDate.Location = New System.Drawing.Point(90, 31)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.ReadOnly = True
        Me.txtCreationDate.Size = New System.Drawing.Size(136, 20)
        Me.txtCreationDate.TabIndex = 10
        Me.txtCreationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.Info
        Me.txtCreatedBy.Location = New System.Drawing.Point(90, 9)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(136, 20)
        Me.txtCreatedBy.TabIndex = 9
        Me.txtCreatedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(345, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "Amend By"
        '
        'txtOverAllDisc
        '
        Me.txtOverAllDisc.BackColor = System.Drawing.SystemColors.Window
        Me.txtOverAllDisc.Location = New System.Drawing.Point(238, 523)
        Me.txtOverAllDisc.Name = "txtOverAllDisc"
        Me.txtOverAllDisc.Size = New System.Drawing.Size(60, 20)
        Me.txtOverAllDisc.TabIndex = 62
        Me.txtOverAllDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVAT
        '
        Me.txtTotalVAT.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalVAT.Location = New System.Drawing.Point(361, 523)
        Me.txtTotalVAT.Name = "txtTotalVAT"
        Me.txtTotalVAT.ReadOnly = True
        Me.txtTotalVAT.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalVAT.TabIndex = 91
        Me.txtTotalVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOverAllDiscount2
        '
        Me.txtOverAllDiscount2.BackColor = System.Drawing.SystemColors.Info
        Me.txtOverAllDiscount2.Location = New System.Drawing.Point(298, 523)
        Me.txtOverAllDiscount2.Name = "txtOverAllDiscount2"
        Me.txtOverAllDiscount2.ReadOnly = True
        Me.txtOverAllDiscount2.Size = New System.Drawing.Size(60, 20)
        Me.txtOverAllDiscount2.TabIndex = 85
        Me.txtOverAllDiscount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnPrint)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnSearch)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Location = New System.Drawing.Point(781, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 64)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(97, 38)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 69
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(6, 38)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 68
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(97, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 67
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(6, 9)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 66
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GBLineBtns
        '
        Me.GBLineBtns.Controls.Add(Me.btnEdit)
        Me.GBLineBtns.Controls.Add(Me.BtnAdd)
        Me.GBLineBtns.Controls.Add(Me.BtnDelete)
        Me.GBLineBtns.Location = New System.Drawing.Point(868, 132)
        Me.GBLineBtns.Name = "GBLineBtns"
        Me.GBLineBtns.Size = New System.Drawing.Size(91, 120)
        Me.GBLineBtns.TabIndex = 68
        Me.GBLineBtns.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(10, 49)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 66
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(10, 23)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 65
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(10, 75)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 67
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotal.Location = New System.Drawing.Point(541, 523)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(108, 20)
        Me.txtTotal.TabIndex = 90
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBLine
        '
        Me.GBLine.Controls.Add(Me.Label10)
        Me.GBLine.Controls.Add(Me.txtVATRate)
        Me.GBLine.Controls.Add(Me.LblLineDisc)
        Me.GBLine.Controls.Add(Me.txtLineDisc)
        Me.GBLine.Controls.Add(Me.Label14)
        Me.GBLine.Controls.Add(Me.ComboVAT)
        Me.GBLine.Controls.Add(Me.btnAccountSearch)
        Me.GBLine.Controls.Add(Me.Label27)
        Me.GBLine.Controls.Add(Me.txtAmount)
        Me.GBLine.Controls.Add(Me.Label22)
        Me.GBLine.Controls.Add(Me.txtComment)
        Me.GBLine.Controls.Add(Me.txtAccountDesc)
        Me.GBLine.Controls.Add(Me.Label21)
        Me.GBLine.Controls.Add(Me.LblAn8)
        Me.GBLine.Controls.Add(Me.LblAn7)
        Me.GBLine.Controls.Add(Me.LblAn10)
        Me.GBLine.Controls.Add(Me.LblAn9)
        Me.GBLine.Controls.Add(Me.LblAn6)
        Me.GBLine.Controls.Add(Me.LblAn3)
        Me.GBLine.Controls.Add(Me.LblAn2)
        Me.GBLine.Controls.Add(Me.LblAn5)
        Me.GBLine.Controls.Add(Me.LblAn4)
        Me.GBLine.Controls.Add(Me.LblAn1)
        Me.GBLine.Controls.Add(Me.ComboAnl7)
        Me.GBLine.Controls.Add(Me.txtAccountCode)
        Me.GBLine.Controls.Add(Me.Label8)
        Me.GBLine.Controls.Add(Me.ComboAnl1)
        Me.GBLine.Controls.Add(Me.ComboAnl9)
        Me.GBLine.Controls.Add(Me.ComboAnl2)
        Me.GBLine.Controls.Add(Me.ComboAnl10)
        Me.GBLine.Controls.Add(Me.ComboAnl6)
        Me.GBLine.Controls.Add(Me.ComboAnl8)
        Me.GBLine.Controls.Add(Me.ComboAnl4)
        Me.GBLine.Controls.Add(Me.ComboAnl3)
        Me.GBLine.Controls.Add(Me.ComboAnl5)
        Me.GBLine.Location = New System.Drawing.Point(7, 132)
        Me.GBLine.Name = "GBLine"
        Me.GBLine.Size = New System.Drawing.Size(851, 120)
        Me.GBLine.TabIndex = 37
        Me.GBLine.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(165, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "VAT Rate"
        '
        'txtVATRate
        '
        Me.txtVATRate.BackColor = System.Drawing.SystemColors.Info
        Me.txtVATRate.Location = New System.Drawing.Point(230, 70)
        Me.txtVATRate.Name = "txtVATRate"
        Me.txtVATRate.ReadOnly = True
        Me.txtVATRate.Size = New System.Drawing.Size(73, 20)
        Me.txtVATRate.TabIndex = 76
        '
        'LblLineDisc
        '
        Me.LblLineDisc.AutoSize = True
        Me.LblLineDisc.Location = New System.Drawing.Point(10, 75)
        Me.LblLineDisc.Name = "LblLineDisc"
        Me.LblLineDisc.Size = New System.Drawing.Size(60, 13)
        Me.LblLineDisc.TabIndex = 75
        Me.LblLineDisc.Text = "Discount %"
        '
        'txtLineDisc
        '
        Me.txtLineDisc.Location = New System.Drawing.Point(73, 70)
        Me.txtLineDisc.Name = "txtLineDisc"
        Me.txtLineDisc.Size = New System.Drawing.Size(89, 20)
        Me.txtLineDisc.TabIndex = 74
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(165, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "VAT"
        '
        'ComboVAT
        '
        Me.ComboVAT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboVAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVAT.FormattingEnabled = True
        Me.ComboVAT.Location = New System.Drawing.Point(199, 50)
        Me.ComboVAT.Name = "ComboVAT"
        Me.ComboVAT.Size = New System.Drawing.Size(104, 21)
        Me.ComboVAT.TabIndex = 72
        '
        'btnAccountSearch
        '
        Me.btnAccountSearch.Location = New System.Drawing.Point(199, 7)
        Me.btnAccountSearch.Name = "btnAccountSearch"
        Me.btnAccountSearch.Size = New System.Drawing.Size(58, 23)
        Me.btnAccountSearch.TabIndex = 62
        Me.btnAccountSearch.Text = "Search"
        Me.btnAccountSearch.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 13)
        Me.Label27.TabIndex = 55
        Me.Label27.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(73, 50)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(89, 20)
        Me.txtAmount.TabIndex = 54
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 96)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Comments"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(73, 90)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(230, 24)
        Me.txtComment.TabIndex = 52
        '
        'txtAccountDesc
        '
        Me.txtAccountDesc.BackColor = System.Drawing.SystemColors.Info
        Me.txtAccountDesc.Location = New System.Drawing.Point(73, 30)
        Me.txtAccountDesc.Name = "txtAccountDesc"
        Me.txtAccountDesc.ReadOnly = True
        Me.txtAccountDesc.Size = New System.Drawing.Size(230, 20)
        Me.txtAccountDesc.TabIndex = 51
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Description"
        '
        'LblAn8
        '
        Me.LblAn8.AutoSize = True
        Me.LblAn8.Location = New System.Drawing.Point(572, 55)
        Me.LblAn8.Name = "LblAn8"
        Me.LblAn8.Size = New System.Drawing.Size(45, 13)
        Me.LblAn8.TabIndex = 49
        Me.LblAn8.Text = "Analysis"
        '
        'LblAn7
        '
        Me.LblAn7.AutoSize = True
        Me.LblAn7.Location = New System.Drawing.Point(572, 33)
        Me.LblAn7.Name = "LblAn7"
        Me.LblAn7.Size = New System.Drawing.Size(45, 13)
        Me.LblAn7.TabIndex = 48
        Me.LblAn7.Text = "Analysis"
        '
        'LblAn10
        '
        Me.LblAn10.AutoSize = True
        Me.LblAn10.Location = New System.Drawing.Point(572, 96)
        Me.LblAn10.Name = "LblAn10"
        Me.LblAn10.Size = New System.Drawing.Size(45, 13)
        Me.LblAn10.TabIndex = 47
        Me.LblAn10.Text = "Analysis"
        '
        'LblAn9
        '
        Me.LblAn9.AutoSize = True
        Me.LblAn9.Location = New System.Drawing.Point(572, 75)
        Me.LblAn9.Name = "LblAn9"
        Me.LblAn9.Size = New System.Drawing.Size(45, 13)
        Me.LblAn9.TabIndex = 45
        Me.LblAn9.Text = "Analysis"
        '
        'LblAn6
        '
        Me.LblAn6.AutoSize = True
        Me.LblAn6.Location = New System.Drawing.Point(573, 12)
        Me.LblAn6.Name = "LblAn6"
        Me.LblAn6.Size = New System.Drawing.Size(45, 13)
        Me.LblAn6.TabIndex = 44
        Me.LblAn6.Text = "Analysis"
        '
        'LblAn3
        '
        Me.LblAn3.AutoSize = True
        Me.LblAn3.Location = New System.Drawing.Point(313, 55)
        Me.LblAn3.Name = "LblAn3"
        Me.LblAn3.Size = New System.Drawing.Size(45, 13)
        Me.LblAn3.TabIndex = 43
        Me.LblAn3.Text = "Analysis"
        '
        'LblAn2
        '
        Me.LblAn2.AutoSize = True
        Me.LblAn2.Location = New System.Drawing.Point(313, 33)
        Me.LblAn2.Name = "LblAn2"
        Me.LblAn2.Size = New System.Drawing.Size(45, 13)
        Me.LblAn2.TabIndex = 42
        Me.LblAn2.Text = "Analysis"
        '
        'LblAn5
        '
        Me.LblAn5.AutoSize = True
        Me.LblAn5.Location = New System.Drawing.Point(313, 96)
        Me.LblAn5.Name = "LblAn5"
        Me.LblAn5.Size = New System.Drawing.Size(45, 13)
        Me.LblAn5.TabIndex = 41
        Me.LblAn5.Text = "Analysis"
        '
        'LblAn4
        '
        Me.LblAn4.AutoSize = True
        Me.LblAn4.Location = New System.Drawing.Point(312, 75)
        Me.LblAn4.Name = "LblAn4"
        Me.LblAn4.Size = New System.Drawing.Size(45, 13)
        Me.LblAn4.TabIndex = 39
        Me.LblAn4.Text = "Analysis"
        '
        'LblAn1
        '
        Me.LblAn1.AutoSize = True
        Me.LblAn1.Location = New System.Drawing.Point(312, 10)
        Me.LblAn1.Name = "LblAn1"
        Me.LblAn1.Size = New System.Drawing.Size(45, 13)
        Me.LblAn1.TabIndex = 38
        Me.LblAn1.Text = "Analysis"
        '
        'ComboAnl7
        '
        Me.ComboAnl7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl7.FormattingEnabled = True
        Me.ComboAnl7.Location = New System.Drawing.Point(669, 30)
        Me.ComboAnl7.Name = "ComboAnl7"
        Me.ComboAnl7.Size = New System.Drawing.Size(172, 21)
        Me.ComboAnl7.TabIndex = 37
        '
        'txtAccountCode
        '
        Me.txtAccountCode.Location = New System.Drawing.Point(73, 10)
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(89, 20)
        Me.txtAccountCode.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Account"
        '
        'ComboAnl1
        '
        Me.ComboAnl1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl1.FormattingEnabled = True
        Me.ComboAnl1.Location = New System.Drawing.Point(408, 9)
        Me.ComboAnl1.Name = "ComboAnl1"
        Me.ComboAnl1.Size = New System.Drawing.Size(159, 21)
        Me.ComboAnl1.TabIndex = 16
        '
        'ComboAnl9
        '
        Me.ComboAnl9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl9.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl9.FormattingEnabled = True
        Me.ComboAnl9.Location = New System.Drawing.Point(669, 72)
        Me.ComboAnl9.Name = "ComboAnl9"
        Me.ComboAnl9.Size = New System.Drawing.Size(172, 21)
        Me.ComboAnl9.TabIndex = 15
        '
        'ComboAnl2
        '
        Me.ComboAnl2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl2.FormattingEnabled = True
        Me.ComboAnl2.Location = New System.Drawing.Point(408, 30)
        Me.ComboAnl2.Name = "ComboAnl2"
        Me.ComboAnl2.Size = New System.Drawing.Size(159, 21)
        Me.ComboAnl2.TabIndex = 14
        '
        'ComboAnl10
        '
        Me.ComboAnl10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl10.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl10.FormattingEnabled = True
        Me.ComboAnl10.Location = New System.Drawing.Point(669, 93)
        Me.ComboAnl10.Name = "ComboAnl10"
        Me.ComboAnl10.Size = New System.Drawing.Size(172, 21)
        Me.ComboAnl10.TabIndex = 12
        '
        'ComboAnl6
        '
        Me.ComboAnl6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl6.FormattingEnabled = True
        Me.ComboAnl6.Location = New System.Drawing.Point(669, 9)
        Me.ComboAnl6.Name = "ComboAnl6"
        Me.ComboAnl6.Size = New System.Drawing.Size(172, 21)
        Me.ComboAnl6.TabIndex = 21
        '
        'ComboAnl8
        '
        Me.ComboAnl8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl8.FormattingEnabled = True
        Me.ComboAnl8.Location = New System.Drawing.Point(669, 51)
        Me.ComboAnl8.Name = "ComboAnl8"
        Me.ComboAnl8.Size = New System.Drawing.Size(172, 21)
        Me.ComboAnl8.TabIndex = 18
        '
        'ComboAnl4
        '
        Me.ComboAnl4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl4.FormattingEnabled = True
        Me.ComboAnl4.Location = New System.Drawing.Point(408, 72)
        Me.ComboAnl4.Name = "ComboAnl4"
        Me.ComboAnl4.Size = New System.Drawing.Size(159, 21)
        Me.ComboAnl4.TabIndex = 13
        '
        'ComboAnl3
        '
        Me.ComboAnl3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl3.FormattingEnabled = True
        Me.ComboAnl3.Location = New System.Drawing.Point(408, 51)
        Me.ComboAnl3.Name = "ComboAnl3"
        Me.ComboAnl3.Size = New System.Drawing.Size(159, 21)
        Me.ComboAnl3.TabIndex = 20
        '
        'ComboAnl5
        '
        Me.ComboAnl5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl5.FormattingEnabled = True
        Me.ComboAnl5.Location = New System.Drawing.Point(408, 93)
        Me.ComboAnl5.Name = "ComboAnl5"
        Me.ComboAnl5.Size = New System.Drawing.Size(159, 21)
        Me.ComboAnl5.TabIndex = 17
        '
        'ComboBox13
        '
        Me.ComboBox13.FormattingEnabled = True
        Me.ComboBox13.Location = New System.Drawing.Point(326, 180)
        Me.ComboBox13.Name = "ComboBox13"
        Me.ComboBox13.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox13.TabIndex = 22
        '
        'txtTotalNet
        '
        Me.txtTotalNet.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalNet.Location = New System.Drawing.Point(161, 523)
        Me.txtTotalNet.Name = "txtTotalNet"
        Me.txtTotalNet.ReadOnly = True
        Me.txtTotalNet.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalNet.TabIndex = 88
        Me.txtTotalNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGross
        '
        Me.txtTotalGross.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalGross.Location = New System.Drawing.Point(7, 523)
        Me.txtTotalGross.Name = "txtTotalGross"
        Me.txtTotalGross.ReadOnly = True
        Me.txtTotalGross.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalGross.TabIndex = 87
        Me.txtTotalGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Err1
        '
        Me.Err1.ContainerControl = Me
        '
        'Err2
        '
        Me.Err2.ContainerControl = Me
        '
        'Err3
        '
        Me.Err3.ContainerControl = Me
        '
        'Err4
        '
        Me.Err4.ContainerControl = Me
        '
        'Err5
        '
        Me.Err5.ContainerControl = Me
        '
        'Err6
        '
        Me.Err6.ContainerControl = Me
        '
        'Err7
        '
        Me.Err7.ContainerControl = Me
        '
        'FrmFiTrxnHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(977, 556)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmFiTrxnHeader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Partner Transaction"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBAllocation.ResumeLayout(False)
        Me.GBAllocation.PerformLayout()
        Me.TabHeader.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBMain.ResumeLayout(False)
        Me.GBMain.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GBDetails.ResumeLayout(False)
        Me.GBDetails.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GBLineBtns.ResumeLayout(False)
        Me.GBLine.ResumeLayout(False)
        Me.GBLine.PerformLayout()
        CType(Me.Err1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Err7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabHeader As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GBMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MSKTxtPostDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboTrxnCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOverAllDisc As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GBDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtAmendDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAmendBy As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCreationDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents GBLine As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCurRate As System.Windows.Forms.TextBox
    Friend WithEvents GBLineBtns As System.Windows.Forms.GroupBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAccountSearch As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LblAn8 As System.Windows.Forms.Label
    Friend WithEvents LblAn7 As System.Windows.Forms.Label
    Friend WithEvents LblAn10 As System.Windows.Forms.Label
    Friend WithEvents LblAn9 As System.Windows.Forms.Label
    Friend WithEvents LblAn6 As System.Windows.Forms.Label
    Friend WithEvents LblAn3 As System.Windows.Forms.Label
    Friend WithEvents LblAn2 As System.Windows.Forms.Label
    Friend WithEvents LblAn5 As System.Windows.Forms.Label
    Friend WithEvents LblAn4 As System.Windows.Forms.Label
    Friend WithEvents LblAn1 As System.Windows.Forms.Label
    Friend WithEvents ComboAnl7 As System.Windows.Forms.ComboBox
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboAnl1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl9 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl10 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl5 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox13 As System.Windows.Forms.ComboBox
    Friend WithEvents Dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboCurency As System.Windows.Forms.ComboBox
    Friend WithEvents txtBusPartnerDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBusPrtSearch As System.Windows.Forms.Button
    Friend WithEvents txtBusPartnerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents MSKTxtDueDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MSKTxtInvDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtXRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAcctRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderComments As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboVAT As System.Windows.Forms.ComboBox
    Friend WithEvents LblLineDisc As System.Windows.Forms.Label
    Friend WithEvents txtLineDisc As System.Windows.Forms.TextBox
    Friend WithEvents Err1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err3 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err4 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err5 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err6 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Err7 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtOverAllDiscount2 As System.Windows.Forms.TextBox
    Friend WithEvents btnOverAllDisc As System.Windows.Forms.Button
    Friend WithEvents CBVatIncluded As System.Windows.Forms.CheckBox
    Friend WithEvents CBVatEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalLineDisc As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNet As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGross As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVAT As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVATRate As System.Windows.Forms.TextBox
    Friend WithEvents BtnAllocation As System.Windows.Forms.Button
    Friend WithEvents btnAllocDispl As System.Windows.Forms.Button
    Friend WithEvents txtAllocTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtTotalLC As System.Windows.Forms.TextBox
    Friend WithEvents GBAllocation As System.Windows.Forms.GroupBox
    Friend WithEvents CBAllocated As System.Windows.Forms.CheckBox
    Friend WithEvents btnBusCur As System.Windows.Forms.Button
    Friend WithEvents btnTrxCur As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAllocRate As System.Windows.Forms.TextBox
    Friend WithEvents LineNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HdrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gross As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineDiscPerc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineDiscVAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverAllDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverAllDiscVAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTotalVAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTotalLocal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTotalLocalVAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VATCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VATRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn1Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn2Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn3Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn4Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn5Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn6Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn7Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn8Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn9Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcLAn10Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboVatDesc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
