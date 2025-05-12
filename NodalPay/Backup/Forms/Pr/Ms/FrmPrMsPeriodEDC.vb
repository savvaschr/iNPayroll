Public Class FrmPrMsPeriodEDC
    Public Index As Integer
    Public LabelText As String
    Dim E_Row As Integer

    Dim D_Row As Integer
    Dim C_Row As Integer

    'Private Sub FrmPrMsPeriodEDC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    DG_E.DataSource = Nothing
    '    DG_D.DataSource = Nothing
    '    DG_C.DataSource = Nothing
    'End Sub

    Private Sub FrmPrMsPeriodEDC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LblPeriod.Text = LabelText
        LoadDG()
    End Sub
    Private Sub LoadDG()
        DG_E.DataSource = CType(Me.Owner, FrmPrMsPeriods).Ar_Earnings(Index).Tables(0)
        DG_D.DataSource = CType(Me.Owner, FrmPrMsPeriods).Ar_Deductions(Index).Tables(0)
        DG_C.DataSource = CType(Me.Owner, FrmPrMsPeriods).Ar_Contributions(Index).Tables(0)
    End Sub

    Private Sub DG_E_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_E.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim s As String
            s = DbNullToString(DG_E.Item(3, DG_E.CurrentRow.Index).Value)
            With CType(Me.Owner, FrmPrMsPeriods).Ar_Earnings(Index).Tables(0).Rows(DG_E.CurrentRow.Index)
                If s = CStr(0) Then
                    .Item(3) = 1
                Else
                    .Item(3) = 0
                End If
            End With
        End If
    End Sub
    Private Sub DG_D_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_D.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim s As String
            s = DbNullToString(DG_D.Item(3, DG_D.CurrentRow.Index).Value)
            With CType(Me.Owner, FrmPrMsPeriods).Ar_Deductions(Index).Tables(0).Rows(DG_D.CurrentRow.Index)
                If s = CStr(0) Then
                    .Item(3) = 1
                Else
                    .Item(3) = 0
                End If
            End With
        End If
    End Sub
    Private Sub DG_C_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_C.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim s As String
            s = DbNullToString(DG_C.Item(3, DG_C.CurrentRow.Index).Value)
            With CType(Me.Owner, FrmPrMsPeriods).Ar_Contributions(Index).Tables(0).Rows(DG_C.CurrentRow.Index)
                If s = CStr(0) Then
                    .Item(3) = 1
                Else
                    .Item(3) = 0
                End If
            End With
        End If
    End Sub
    Private Sub btnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnE.Click
        Dim i As Integer
        For i = 0 To CType(Me.Owner, FrmPrMsPeriods).Ar_Earnings(Index).Tables(0).Rows.Count - 1
            CType(Me.Owner, FrmPrMsPeriods).Ar_Earnings(Index).Tables(0).Rows(i).Item(3) = 1
        Next

    End Sub

    Private Sub BtnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnD.Click
        Dim i As Integer
        For i = 0 To CType(Me.Owner, FrmPrMsPeriods).Ar_Deductions(Index).Tables(0).Rows.Count - 1
            CType(Me.Owner, FrmPrMsPeriods).Ar_Deductions(Index).Tables(0).Rows(i).Item(3) = 1
        Next
    End Sub

    Private Sub BtnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnC.Click
        Dim i As Integer
        For i = 0 To CType(Me.Owner, FrmPrMsPeriods).Ar_Contributions(Index).Tables(0).Rows.Count - 1
            CType(Me.Owner, FrmPrMsPeriods).Ar_Contributions(Index).Tables(0).Rows(i).Item(3) = 1
        Next
    End Sub
End Class