Public Class FrmCopyDiscountFromPeriodtoPeriod

   
    Private Sub FrmCopyDiscountFromPeriodtoPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPrMsPeriodGroups()
    End Sub
    Private Sub LoadPrMsPeriodGroups()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrMsPeriodGroups()
        If CheckDataSet(ds) Then
            Dim tPrMsPeriodGroups As New cPrMsPeriodGroups
            With Me.ComboFromPeriod
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsPeriodGroups = New cPrMsPeriodGroups(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrMsPeriodGroups)
                Next i
                .ValueMember = "PrdGrp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If

        If CheckDataSet(ds) Then
            Dim tPrMsPeriodGroups As New cPrMsPeriodGroups
            With Me.ComboToPeriod
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsPeriodGroups = New cPrMsPeriodGroups(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrMsPeriodGroups)
                Next i
                .ValueMember = "PrdGrp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If

    End Sub


    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim PFrom As New cPrMsPeriodGroups
        Dim PTo As New cPrMsPeriodGroups

        PFrom = CType(Me.ComboFromPeriod.SelectedItem, cPrMsPeriodGroups)
        PTo = CType(Me.ComboToPeriod.SelectedItem, cPrMsPeriodGroups)

        If PFrom.TemGrpCode = PTo.TemGrpCode Then
            Dim Ds As DataSet
            Ds = Global1.Business.GetAllPrTxdiscountsForPeriodGroup(PFrom.Code)

            If CheckDataSet(Ds) Then
                Dim i As Integer
                Dim Exx As New System.Exception
                Global1.Business.BeginTransaction()
                Try
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Dim Disc1 As New cPrTxEmployeeDiscounts(Ds.Tables(0).Rows(i))
                        Dim Disc2 As New cPrTxEmployeeDiscounts(Disc1.Emp_Code, PTo.Code)
                        If Disc2.Id = 0 Then
                            Disc2 = New cPrTxEmployeeDiscounts(Ds.Tables(0).Rows(i))
                            Disc2.Id = 0
                            Disc2.PrdGrp_Code = PTo.Code
                            Disc2.CreationDate = Now
                            Disc2.AmendDate = Now
                            Disc2.Usr_Id = Global1.GLBUserId
                            If Not Disc2.Save() Then
                                Throw Exx
                            End If
                        End If
                    Next
                    Global1.Business.CommitTransaction()
                    MsgBox("Succefull Copy", MsgBoxStyle.Information)
                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Unable to Copy", MsgBoxStyle.Critical)
                End Try
            End If
        Else
            MsgBox("Template Group of Period From and Period To must Much in Order to Proceed with copy", MsgBoxStyle.Information)
        End If

    End Sub
End Class