Public Class FrmCopyInterfaceCodesFunction
    Public DsTempGroups As DataSet
    Public DsInterfaceCodes As DataSet
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Global1.Business.BeginTransaction()

            Dim OldPrefix As String = Me.txtOldPrefix.Text
            Dim NewPrefix As String = Me.txtNewPrefix.Text
            Dim Exx As New System.Exception

            Dim tempGroup As New cPrMsTemplateGroup
            tempGroup = CType(Me.ComboBox1.SelectedItem, cPrMsTemplateGroup)
            If CheckDataSet(DsInterfaceCodes) Then
                Dim i As Integer
                Dim Int_Old As New cPrMsInterfaceCodes
                For i = 0 To DsInterfaceCodes.Tables(0).Rows.Count - 1
                    Int_Old = New cPrMsInterfaceCodes(DsInterfaceCodes.Tables(0).Rows(i))
                    Dim Int_New As New cPrMsInterfaceCodes
                    Int_New.Code = Int_Old.Code.Replace(OldPrefix, NewPrefix)
                    Int_New.TemGrpCode = tempGroup.Code
                    Int_New.AccountType = Int_Old.AccountType
                    Int_New.Description = Int_Old.Description

                    If Not Int_New.Save Then
                        Throw Exx
                    Else
                        Dim Ds As DataSet
                        Ds = Global1.Business.GetAllPrMsCodeMasking(Int_Old.Code)
                        Dim k As Integer
                        For k = 0 To Ds.Tables(0).Rows.Count - 1
                            Dim S1 As New cPrMsCodeMasking(DbNullToInt(Ds.Tables(0).Rows(k).Item(0)))
                            S1.id = 0
                            S1.IntCode = Int_New.Code
                            If Not S1.Save Then
                                Throw Exx
                            End If
                        Next
                    End If
                Next
            End If

            Global1.Business.CommitTransaction()
            MsgBox("Finish")

        Catch ex As Exception
            Global1.Business.Rollback()
        End Try



    End Sub

   
    Private Sub FrmCopyInterfaceCodesFunction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPrMsTemplateGroups()
    End Sub
    Private Sub LoadPrMsTemplateGroups()

        Dim i As Integer
        dsTempGroups = Global1.Business.AG_GetAllPrMsTemplateGroup()
        If CheckDataSet(dsTempGroups) Then
            Dim tPrMsTemplateGroup As New cPrMsTemplateGroup
            With Me.ComboBox1
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To DsTempGroups.Tables(0).Rows.Count - 1
                    tPrMsTemplateGroup = New cPrMsTemplateGroup(DbNullToString(DsTempGroups.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrMsTemplateGroup)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If

    End Sub
End Class