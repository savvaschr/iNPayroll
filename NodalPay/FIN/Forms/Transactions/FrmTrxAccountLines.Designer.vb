<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrxAccountLines
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotalCredit = New System.Windows.Forms.TextBox
        Me.txtBalanceDebit = New System.Windows.Forms.TextBox
        Me.txtBalanceCredit = New System.Windows.Forms.TextBox
        Me.txtTotalDebit = New System.Windows.Forms.TextBox
        Me.TabHeader = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GBMain = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.MSKTxtPostDate = New System.Windows.Forms.MaskedTextBox
        Me.ComboJournalCode = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJournalNo = New System.Windows.Forms.TextBox
        Me.ComboPeriods = New System.Windows.Forms.ComboBox
        Me.txtJournalCodeDesc = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GBDetails = New System.Windows.Forms.GroupBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtAmendDate = New System.Windows.Forms.TextBox
        Me.txtAmendBy = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCreationDate = New System.Windows.Forms.TextBox
        Me.txtCreatedBy = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCurRate = New System.Windows.Forms.TextBox
        Me.ComboCurency = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnEdit = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCredit = New System.Windows.Forms.TextBox
        Me.btnAccountSearch = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtDebit = New System.Windows.Forms.TextBox
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblAn2 = New System.Windows.Forms.Label
        Me.MSKtxtDocDate = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblAn5 = New System.Windows.Forms.Label
        Me.txtAltRef = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblAn4 = New System.Windows.Forms.Label
        Me.LblAn1 = New System.Windows.Forms.Label
        Me.ComboAnl7 = New System.Windows.Forms.ComboBox
        Me.txtAccountCode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDocRef = New System.Windows.Forms.TextBox
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
        Me.Dg1 = New System.Windows.Forms.DataGridView
        Me.JouLineNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DocDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DocRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AltRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrdCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BusPrtCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DrCr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountLocCur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurAlphaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountTrxCur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrxCurDecimal = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.AllocStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllocRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnAllocBalanceLC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnAllocBalanceTC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllocDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllocPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExternalRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MyModule = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Er1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabHeader.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBMain.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GBDetails.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.TabHeader)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox13)
        Me.GroupBox1.Controls.Add(Me.Dg1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(920, 561)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtTotalCredit)
        Me.GroupBox5.Controls.Add(Me.txtBalanceDebit)
        Me.GroupBox5.Controls.Add(Me.txtBalanceCredit)
        Me.GroupBox5.Controls.Add(Me.txtTotalDebit)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 504)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(903, 54)
        Me.GroupBox5.TabIndex = 72
        Me.GroupBox5.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(281, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Totals"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(281, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Balance"
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalCredit.Location = New System.Drawing.Point(452, 10)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(82, 20)
        Me.txtTotalCredit.TabIndex = 53
        '
        'txtBalanceDebit
        '
        Me.txtBalanceDebit.BackColor = System.Drawing.SystemColors.Info
        Me.txtBalanceDebit.Location = New System.Drawing.Point(354, 30)
        Me.txtBalanceDebit.Name = "txtBalanceDebit"
        Me.txtBalanceDebit.ReadOnly = True
        Me.txtBalanceDebit.Size = New System.Drawing.Size(82, 20)
        Me.txtBalanceDebit.TabIndex = 54
        '
        'txtBalanceCredit
        '
        Me.txtBalanceCredit.BackColor = System.Drawing.SystemColors.Info
        Me.txtBalanceCredit.Location = New System.Drawing.Point(452, 30)
        Me.txtBalanceCredit.Name = "txtBalanceCredit"
        Me.txtBalanceCredit.ReadOnly = True
        Me.txtBalanceCredit.Size = New System.Drawing.Size(82, 20)
        Me.txtBalanceCredit.TabIndex = 69
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalDebit.Location = New System.Drawing.Point(354, 10)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(82, 20)
        Me.txtTotalDebit.TabIndex = 55
        '
        'TabHeader
        '
        Me.TabHeader.Controls.Add(Me.TabPage1)
        Me.TabHeader.Controls.Add(Me.TabPage2)
        Me.TabHeader.Location = New System.Drawing.Point(11, 10)
        Me.TabHeader.Name = "TabHeader"
        Me.TabHeader.SelectedIndex = 0
        Me.TabHeader.Size = New System.Drawing.Size(704, 85)
        Me.TabHeader.TabIndex = 68
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(696, 59)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBMain
        '
        Me.GBMain.Controls.Add(Me.Label1)
        Me.GBMain.Controls.Add(Me.Label29)
        Me.GBMain.Controls.Add(Me.Label7)
        Me.GBMain.Controls.Add(Me.MSKTxtPostDate)
        Me.GBMain.Controls.Add(Me.ComboJournalCode)
        Me.GBMain.Controls.Add(Me.Label5)
        Me.GBMain.Controls.Add(Me.txtJournalNo)
        Me.GBMain.Controls.Add(Me.ComboPeriods)
        Me.GBMain.Controls.Add(Me.txtJournalCodeDesc)
        Me.GBMain.Controls.Add(Me.Label28)
        Me.GBMain.Location = New System.Drawing.Point(10, 0)
        Me.GBMain.Name = "GBMain"
        Me.GBMain.Size = New System.Drawing.Size(680, 54)
        Me.GBMain.TabIndex = 69
        Me.GBMain.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Journal Code"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(459, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(61, 13)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "Journal No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Post Date"
        '
        'MSKTxtPostDate
        '
        Me.MSKTxtPostDate.Location = New System.Drawing.Point(340, 29)
        Me.MSKTxtPostDate.Mask = "00/00/0000"
        Me.MSKTxtPostDate.Name = "MSKTxtPostDate"
        Me.MSKTxtPostDate.Size = New System.Drawing.Size(113, 20)
        Me.MSKTxtPostDate.TabIndex = 31
        Me.MSKTxtPostDate.ValidatingType = GetType(Date)
        '
        'ComboJournalCode
        '
        Me.ComboJournalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboJournalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboJournalCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboJournalCode.FormattingEnabled = True
        Me.ComboJournalCode.Location = New System.Drawing.Point(90, 9)
        Me.ComboJournalCode.Name = "ComboJournalCode"
        Me.ComboJournalCode.Size = New System.Drawing.Size(184, 21)
        Me.ComboJournalCode.TabIndex = 67
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(282, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Period"
        '
        'txtJournalNo
        '
        Me.txtJournalNo.Location = New System.Drawing.Point(526, 9)
        Me.txtJournalNo.Name = "txtJournalNo"
        Me.txtJournalNo.Size = New System.Drawing.Size(132, 20)
        Me.txtJournalNo.TabIndex = 34
        '
        'ComboPeriods
        '
        Me.ComboPeriods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboPeriods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPeriods.FormattingEnabled = True
        Me.ComboPeriods.Location = New System.Drawing.Point(340, 9)
        Me.ComboPeriods.Name = "ComboPeriods"
        Me.ComboPeriods.Size = New System.Drawing.Size(113, 21)
        Me.ComboPeriods.TabIndex = 2
        '
        'txtJournalCodeDesc
        '
        Me.txtJournalCodeDesc.BackColor = System.Drawing.SystemColors.Info
        Me.txtJournalCodeDesc.Location = New System.Drawing.Point(90, 31)
        Me.txtJournalCodeDesc.Name = "txtJournalCodeDesc"
        Me.txtJournalCodeDesc.ReadOnly = True
        Me.txtJournalCodeDesc.Size = New System.Drawing.Size(184, 20)
        Me.txtJournalCodeDesc.TabIndex = 62
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 35)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 13)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "Journal Desc."
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GBDetails)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(696, 59)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GBDetails
        '
        Me.GBDetails.Controls.Add(Me.Label23)
        Me.GBDetails.Controls.Add(Me.txtAmendDate)
        Me.GBDetails.Controls.Add(Me.txtAmendBy)
        Me.GBDetails.Controls.Add(Me.Label24)
        Me.GBDetails.Controls.Add(Me.Label26)
        Me.GBDetails.Controls.Add(Me.txtCreationDate)
        Me.GBDetails.Controls.Add(Me.txtCreatedBy)
        Me.GBDetails.Controls.Add(Me.Label25)
        Me.GBDetails.Location = New System.Drawing.Point(10, 0)
        Me.GBDetails.Name = "GBDetails"
        Me.GBDetails.Size = New System.Drawing.Size(680, 54)
        Me.GBDetails.TabIndex = 60
        Me.GBDetails.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Created by"
        '
        'txtAmendDate
        '
        Me.txtAmendDate.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmendDate.Location = New System.Drawing.Point(319, 32)
        Me.txtAmendDate.Name = "txtAmendDate"
        Me.txtAmendDate.ReadOnly = True
        Me.txtAmendDate.Size = New System.Drawing.Size(100, 20)
        Me.txtAmendDate.TabIndex = 33
        '
        'txtAmendBy
        '
        Me.txtAmendBy.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmendBy.Location = New System.Drawing.Point(319, 12)
        Me.txtAmendBy.Name = "txtAmendBy"
        Me.txtAmendBy.ReadOnly = True
        Me.txtAmendBy.Size = New System.Drawing.Size(100, 20)
        Me.txtAmendBy.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(222, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 57
        Me.Label24.Text = "Amendment Date"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 29)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Creation Date"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.BackColor = System.Drawing.SystemColors.Info
        Me.txtCreationDate.Location = New System.Drawing.Point(105, 32)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.ReadOnly = True
        Me.txtCreationDate.Size = New System.Drawing.Size(100, 20)
        Me.txtCreationDate.TabIndex = 10
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.Info
        Me.txtCreatedBy.Location = New System.Drawing.Point(105, 12)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(100, 20)
        Me.txtCreatedBy.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(222, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "Amend By"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnPrint)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnSearch)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Location = New System.Drawing.Point(721, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 65)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCurRate)
        Me.GroupBox2.Controls.Add(Me.ComboCurency)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCredit)
        Me.GroupBox2.Controls.Add(Me.btnAccountSearch)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtDebit)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtComment)
        Me.GroupBox2.Controls.Add(Me.txtAccountDesc)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.LblAn8)
        Me.GroupBox2.Controls.Add(Me.LblAn7)
        Me.GroupBox2.Controls.Add(Me.LblAn10)
        Me.GroupBox2.Controls.Add(Me.LblAn9)
        Me.GroupBox2.Controls.Add(Me.LblAn6)
        Me.GroupBox2.Controls.Add(Me.LblAn3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.LblAn2)
        Me.GroupBox2.Controls.Add(Me.MSKtxtDocDate)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.LblAn5)
        Me.GroupBox2.Controls.Add(Me.txtAltRef)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.LblAn4)
        Me.GroupBox2.Controls.Add(Me.LblAn1)
        Me.GroupBox2.Controls.Add(Me.ComboAnl7)
        Me.GroupBox2.Controls.Add(Me.txtAccountCode)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDocRef)
        Me.GroupBox2.Controls.Add(Me.ComboAnl1)
        Me.GroupBox2.Controls.Add(Me.ComboAnl9)
        Me.GroupBox2.Controls.Add(Me.ComboAnl2)
        Me.GroupBox2.Controls.Add(Me.ComboAnl10)
        Me.GroupBox2.Controls.Add(Me.ComboAnl6)
        Me.GroupBox2.Controls.Add(Me.ComboAnl8)
        Me.GroupBox2.Controls.Add(Me.ComboAnl4)
        Me.GroupBox2.Controls.Add(Me.ComboAnl3)
        Me.GroupBox2.Controls.Add(Me.ComboAnl5)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(888, 174)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Curency"
        '
        'txtCurRate
        '
        Me.txtCurRate.Location = New System.Drawing.Point(244, 50)
        Me.txtCurRate.Name = "txtCurRate"
        Me.txtCurRate.Size = New System.Drawing.Size(59, 20)
        Me.txtCurRate.TabIndex = 70
        '
        'ComboCurency
        '
        Me.ComboCurency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCurency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCurency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCurency.FormattingEnabled = True
        Me.ComboCurency.Location = New System.Drawing.Point(73, 50)
        Me.ComboCurency.Name = "ComboCurency"
        Me.ComboCurency.Size = New System.Drawing.Size(165, 21)
        Me.ComboCurency.TabIndex = 69
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Controls.Add(Me.BtnAdd)
        Me.GroupBox4.Controls.Add(Me.BtnDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(602, 118)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(259, 37)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(90, 10)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 66
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(9, 10)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 65
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(171, 10)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 67
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(168, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Credit"
        '
        'txtCredit
        '
        Me.txtCredit.Location = New System.Drawing.Point(219, 71)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(84, 20)
        Me.txtCredit.TabIndex = 63
        '
        'btnAccountSearch
        '
        Me.btnAccountSearch.Location = New System.Drawing.Point(192, 7)
        Me.btnAccountSearch.Name = "btnAccountSearch"
        Me.btnAccountSearch.Size = New System.Drawing.Size(58, 23)
        Me.btnAccountSearch.TabIndex = 62
        Me.btnAccountSearch.Text = "Search"
        Me.btnAccountSearch.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 75)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(32, 13)
        Me.Label27.TabIndex = 55
        Me.Label27.Text = "Debit"
        '
        'txtDebit
        '
        Me.txtDebit.Location = New System.Drawing.Point(73, 71)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.Size = New System.Drawing.Size(89, 20)
        Me.txtDebit.TabIndex = 54
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 153)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Comments"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(73, 132)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(495, 39)
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
        Me.LblAn8.Location = New System.Drawing.Point(586, 58)
        Me.LblAn8.Name = "LblAn8"
        Me.LblAn8.Size = New System.Drawing.Size(45, 13)
        Me.LblAn8.TabIndex = 49
        Me.LblAn8.Text = "Analysis"
        '
        'LblAn7
        '
        Me.LblAn7.AutoSize = True
        Me.LblAn7.Location = New System.Drawing.Point(586, 37)
        Me.LblAn7.Name = "LblAn7"
        Me.LblAn7.Size = New System.Drawing.Size(45, 13)
        Me.LblAn7.TabIndex = 48
        Me.LblAn7.Text = "Analysis"
        '
        'LblAn10
        '
        Me.LblAn10.AutoSize = True
        Me.LblAn10.Location = New System.Drawing.Point(586, 100)
        Me.LblAn10.Name = "LblAn10"
        Me.LblAn10.Size = New System.Drawing.Size(45, 13)
        Me.LblAn10.TabIndex = 47
        Me.LblAn10.Text = "Analysis"
        '
        'LblAn9
        '
        Me.LblAn9.AutoSize = True
        Me.LblAn9.Location = New System.Drawing.Point(586, 79)
        Me.LblAn9.Name = "LblAn9"
        Me.LblAn9.Size = New System.Drawing.Size(45, 13)
        Me.LblAn9.TabIndex = 45
        Me.LblAn9.Text = "Analysis"
        '
        'LblAn6
        '
        Me.LblAn6.AutoSize = True
        Me.LblAn6.Location = New System.Drawing.Point(586, 16)
        Me.LblAn6.Name = "LblAn6"
        Me.LblAn6.Size = New System.Drawing.Size(45, 13)
        Me.LblAn6.TabIndex = 44
        Me.LblAn6.Text = "Analysis"
        '
        'LblAn3
        '
        Me.LblAn3.AutoSize = True
        Me.LblAn3.Location = New System.Drawing.Point(312, 59)
        Me.LblAn3.Name = "LblAn3"
        Me.LblAn3.Size = New System.Drawing.Size(45, 13)
        Me.LblAn3.TabIndex = 43
        Me.LblAn3.Text = "Analysis"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Doc. Date"
        '
        'LblAn2
        '
        Me.LblAn2.AutoSize = True
        Me.LblAn2.Location = New System.Drawing.Point(313, 38)
        Me.LblAn2.Name = "LblAn2"
        Me.LblAn2.Size = New System.Drawing.Size(45, 13)
        Me.LblAn2.TabIndex = 42
        Me.LblAn2.Text = "Analysis"
        '
        'MSKtxtDocDate
        '
        Me.MSKtxtDocDate.Location = New System.Drawing.Point(73, 91)
        Me.MSKtxtDocDate.Mask = "00/00/0000"
        Me.MSKtxtDocDate.Name = "MSKtxtDocDate"
        Me.MSKtxtDocDate.Size = New System.Drawing.Size(89, 20)
        Me.MSKtxtDocDate.TabIndex = 23
        Me.MSKtxtDocDate.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Alt.Ref."
        '
        'LblAn5
        '
        Me.LblAn5.AutoSize = True
        Me.LblAn5.Location = New System.Drawing.Point(313, 100)
        Me.LblAn5.Name = "LblAn5"
        Me.LblAn5.Size = New System.Drawing.Size(45, 13)
        Me.LblAn5.TabIndex = 41
        Me.LblAn5.Text = "Analysis"
        '
        'txtAltRef
        '
        Me.txtAltRef.Location = New System.Drawing.Point(219, 111)
        Me.txtAltRef.Name = "txtAltRef"
        Me.txtAltRef.Size = New System.Drawing.Size(84, 20)
        Me.txtAltRef.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Doc.Ref."
        '
        'LblAn4
        '
        Me.LblAn4.AutoSize = True
        Me.LblAn4.Location = New System.Drawing.Point(313, 79)
        Me.LblAn4.Name = "LblAn4"
        Me.LblAn4.Size = New System.Drawing.Size(45, 13)
        Me.LblAn4.TabIndex = 39
        Me.LblAn4.Text = "Analysis"
        '
        'LblAn1
        '
        Me.LblAn1.AutoSize = True
        Me.LblAn1.Location = New System.Drawing.Point(313, 17)
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
        Me.ComboAnl7.Location = New System.Drawing.Point(683, 34)
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
        'txtDocRef
        '
        Me.txtDocRef.Location = New System.Drawing.Point(73, 111)
        Me.txtDocRef.Name = "txtDocRef"
        Me.txtDocRef.Size = New System.Drawing.Size(89, 20)
        Me.txtDocRef.TabIndex = 6
        '
        'ComboAnl1
        '
        Me.ComboAnl1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboAnl1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboAnl1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAnl1.FormattingEnabled = True
        Me.ComboAnl1.Location = New System.Drawing.Point(408, 14)
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
        Me.ComboAnl9.Location = New System.Drawing.Point(683, 76)
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
        Me.ComboAnl2.Location = New System.Drawing.Point(408, 35)
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
        Me.ComboAnl10.Location = New System.Drawing.Point(683, 97)
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
        Me.ComboAnl6.Location = New System.Drawing.Point(683, 13)
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
        Me.ComboAnl8.Location = New System.Drawing.Point(683, 55)
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
        Me.ComboAnl4.Location = New System.Drawing.Point(408, 77)
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
        Me.ComboAnl3.Location = New System.Drawing.Point(408, 56)
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
        Me.ComboAnl5.Location = New System.Drawing.Point(408, 98)
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
        'Dg1
        '
        Me.Dg1.AllowUserToAddRows = False
        Me.Dg1.AllowUserToDeleteRows = False
        Me.Dg1.AllowUserToResizeColumns = False
        Me.Dg1.AllowUserToResizeRows = False
        Me.Dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JouLineNo, Me.AccCode, Me.AccDesc, Me.Debit, Me.Credit, Me.DocDate, Me.DocRef, Me.AltRef, Me.Comment, Me.PostDate, Me.DueDate, Me.PrdCode, Me.BusPrtCode, Me.DrCr, Me.AmountLocCur, Me.CurAlphaCode, Me.AmountTrxCur, Me.CurRate, Me.TrxCurDecimal, Me.AcLAn1Code, Me.AcLAn2Code, Me.AcLAn3Code, Me.AcLAn4Code, Me.AcLAn5Code, Me.AcLAn6Code, Me.AcLAn7Code, Me.AcLAn8Code, Me.AcLAn9Code, Me.AcLAn10Code, Me.AllocStatus, Me.AllocRef, Me.UnAllocBalanceLC, Me.UnAllocBalanceTC, Me.AllocDate, Me.AllocPeriod, Me.ExternalRef, Me.MyModule, Me.ModRef})
        Me.Dg1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dg1.Location = New System.Drawing.Point(11, 272)
        Me.Dg1.Name = "Dg1"
        Me.Dg1.Size = New System.Drawing.Size(903, 236)
        Me.Dg1.TabIndex = 0
        '
        'JouLineNo
        '
        Me.JouLineNo.DataPropertyName = "JouLineNo"
        Me.JouLineNo.HeaderText = "Line"
        Me.JouLineNo.Name = "JouLineNo"
        Me.JouLineNo.Width = 35
        '
        'AccCode
        '
        Me.AccCode.DataPropertyName = "AccCode"
        Me.AccCode.HeaderText = "Acc.Code"
        Me.AccCode.Name = "AccCode"
        Me.AccCode.Width = 80
        '
        'AccDesc
        '
        Me.AccDesc.DataPropertyName = "AccDesc"
        Me.AccDesc.HeaderText = "Acc.Description"
        Me.AccDesc.Name = "AccDesc"
        Me.AccDesc.Width = 200
        '
        'Debit
        '
        Me.Debit.DataPropertyName = "Debit"
        Me.Debit.HeaderText = "Debit"
        Me.Debit.Name = "Debit"
        Me.Debit.Width = 90
        '
        'Credit
        '
        Me.Credit.DataPropertyName = "Credit"
        Me.Credit.HeaderText = "Credit"
        Me.Credit.Name = "Credit"
        Me.Credit.Width = 90
        '
        'DocDate
        '
        Me.DocDate.DataPropertyName = "DocDate"
        Me.DocDate.HeaderText = "Doc.Date"
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Width = 90
        '
        'DocRef
        '
        Me.DocRef.DataPropertyName = "DocRef"
        Me.DocRef.HeaderText = "Doc.Ref."
        Me.DocRef.Name = "DocRef"
        Me.DocRef.Width = 110
        '
        'AltRef
        '
        Me.AltRef.DataPropertyName = "AltRef"
        Me.AltRef.HeaderText = "Alt.Ref."
        Me.AltRef.Name = "AltRef"
        Me.AltRef.Width = 110
        '
        'Comment
        '
        Me.Comment.DataPropertyName = "Comment"
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.Width = 250
        '
        'PostDate
        '
        Me.PostDate.DataPropertyName = "PostDate"
        Me.PostDate.HeaderText = "PostDate"
        Me.PostDate.Name = "PostDate"
        Me.PostDate.Visible = False
        '
        'DueDate
        '
        Me.DueDate.DataPropertyName = "DueDate"
        Me.DueDate.HeaderText = "DueDate"
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Visible = False
        '
        'PrdCode
        '
        Me.PrdCode.DataPropertyName = "PrdCode"
        Me.PrdCode.HeaderText = "PrdCode"
        Me.PrdCode.Name = "PrdCode"
        Me.PrdCode.Visible = False
        '
        'BusPrtCode
        '
        Me.BusPrtCode.DataPropertyName = "BusPrtCode"
        Me.BusPrtCode.HeaderText = "BusPrtCode"
        Me.BusPrtCode.Name = "BusPrtCode"
        Me.BusPrtCode.Visible = False
        '
        'DrCr
        '
        Me.DrCr.DataPropertyName = "DrCr"
        Me.DrCr.HeaderText = "DrCr"
        Me.DrCr.Name = "DrCr"
        Me.DrCr.Visible = False
        '
        'AmountLocCur
        '
        Me.AmountLocCur.DataPropertyName = "AmountLocCur"
        Me.AmountLocCur.HeaderText = "AmountLocCur"
        Me.AmountLocCur.Name = "AmountLocCur"
        Me.AmountLocCur.Visible = False
        '
        'CurAlphaCode
        '
        Me.CurAlphaCode.DataPropertyName = "CurAlphaCode"
        Me.CurAlphaCode.HeaderText = "CurAlphaCode"
        Me.CurAlphaCode.Name = "CurAlphaCode"
        Me.CurAlphaCode.Visible = False
        '
        'AmountTrxCur
        '
        Me.AmountTrxCur.DataPropertyName = "AmountTrxCur"
        Me.AmountTrxCur.HeaderText = "AmountTrxCur"
        Me.AmountTrxCur.Name = "AmountTrxCur"
        Me.AmountTrxCur.Visible = False
        '
        'CurRate
        '
        Me.CurRate.DataPropertyName = "CurRate"
        Me.CurRate.HeaderText = "CurRate"
        Me.CurRate.Name = "CurRate"
        Me.CurRate.Visible = False
        '
        'TrxCurDecimal
        '
        Me.TrxCurDecimal.DataPropertyName = "TrxCurDecimal"
        Me.TrxCurDecimal.HeaderText = "TrxCurDecimal"
        Me.TrxCurDecimal.Name = "TrxCurDecimal"
        Me.TrxCurDecimal.Visible = False
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
        'AllocStatus
        '
        Me.AllocStatus.DataPropertyName = "AllocStatus"
        Me.AllocStatus.HeaderText = "AllocStatus"
        Me.AllocStatus.Name = "AllocStatus"
        Me.AllocStatus.Visible = False
        '
        'AllocRef
        '
        Me.AllocRef.DataPropertyName = "AllocRef"
        Me.AllocRef.HeaderText = "AllocRef"
        Me.AllocRef.Name = "AllocRef"
        Me.AllocRef.Visible = False
        '
        'UnAllocBalanceLC
        '
        Me.UnAllocBalanceLC.DataPropertyName = "AllocBalanceLC"
        Me.UnAllocBalanceLC.HeaderText = "UnAllocBalanceLC"
        Me.UnAllocBalanceLC.Name = "UnAllocBalanceLC"
        Me.UnAllocBalanceLC.Visible = False
        '
        'UnAllocBalanceTC
        '
        Me.UnAllocBalanceTC.DataPropertyName = "AllocBalanceTC"
        Me.UnAllocBalanceTC.HeaderText = "UnAllocBalanceTC"
        Me.UnAllocBalanceTC.Name = "UnAllocBalanceTC"
        Me.UnAllocBalanceTC.Visible = False
        '
        'AllocDate
        '
        Me.AllocDate.DataPropertyName = "AllocDate"
        Me.AllocDate.HeaderText = "AllocDate"
        Me.AllocDate.Name = "AllocDate"
        Me.AllocDate.Visible = False
        '
        'AllocPeriod
        '
        Me.AllocPeriod.DataPropertyName = "AllocPeriod"
        Me.AllocPeriod.HeaderText = "AllocPeriod"
        Me.AllocPeriod.Name = "AllocPeriod"
        Me.AllocPeriod.Visible = False
        '
        'ExternalRef
        '
        Me.ExternalRef.DataPropertyName = "ExternalRef"
        Me.ExternalRef.HeaderText = "ExternalRef"
        Me.ExternalRef.Name = "ExternalRef"
        Me.ExternalRef.Visible = False
        '
        'MyModule
        '
        Me.MyModule.DataPropertyName = "Module"
        Me.MyModule.HeaderText = "MyModule"
        Me.MyModule.Name = "MyModule"
        Me.MyModule.Visible = False
        '
        'ModRef
        '
        Me.ModRef.DataPropertyName = "ModRef"
        Me.ModRef.HeaderText = "ModRef"
        Me.ModRef.Name = "ModRef"
        Me.ModRef.Visible = False
        '
        'Er1
        '
        Me.Er1.ContainerControl = Me
        '
        'FrmTrxAccountLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(973, 566)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmTrxAccountLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Entry "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabHeader.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBMain.ResumeLayout(False)
        Me.GBMain.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GBDetails.ResumeLayout(False)
        Me.GBDetails.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Er1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboAnl1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl10 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreationDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents ComboAnl2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl9 As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmendBy As System.Windows.Forms.TextBox
    Friend WithEvents ComboAnl5 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDocRef As System.Windows.Forms.TextBox
    Friend WithEvents ComboAnl8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnl3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboPeriods As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox13 As System.Windows.Forms.ComboBox
    Friend WithEvents MSKtxtDocDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAmendDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MSKTxtPostDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAltRef As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceDebit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
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
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDebit As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountSearch As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtJournalCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents ComboJournalCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Er1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabHeader As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceCredit As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GBMain As System.Windows.Forms.GroupBox
    Friend WithEvents GBDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCurRate As System.Windows.Forms.TextBox
    Friend WithEvents ComboCurency As System.Windows.Forms.ComboBox
    Friend WithEvents JouLineNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AltRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrdCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BusPrtCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrCr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountLocCur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurAlphaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountTrxCur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxCurDecimal As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents AllocStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllocRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnAllocBalanceLC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnAllocBalanceTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllocPeriod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MyModule As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModRef As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
