Public Class FrmChangeEmployeeCode
    Public OldCode As String
    Public GlbTemplateGroupCode As String
    Private Sub FrmChangeEmployeeCode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TextBox1.Text = OldCode

        'Me.BtnChange.Visible = False
        'Me.btnCopy.Visible = False

        'If CalledFor = 1 Then
        '    Me.BtnChange.Visible = True
        '    Me.btnCopy.Visible = False
        'End If
        'If CalledFor = 2 Then
        '    Me.BtnChange.Visible = False
        '    Me.btnCopy.Visible = True
        'End If

    End Sub
    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        Dim NewCode As String = Me.TextBox2.Text
        Dim Exx As New System.Exception
        Dim Flag As Boolean = False

        If NewCode <> "" Then
            Dim NewEmp As New cPrMsEmployees(NewCode)
            If NewEmp.Code <> "" Then
                MsgBox("Employee with code " & NewCode & " already Exists", MsgBoxStyle.Critical)
                Exit Sub
            Else

                Global1.Business.BeginTransaction()

                Try
                    Dim Oldemp As New cPrMsEmployees(OldCode)
                    Oldemp.Code = NewCode
                    If Oldemp.Save() Then
                        If Global1.Business.ChangeEmployeeCode(OldCode, NewCode) Then
                            MsgBox("Change of employee Code Completed", MsgBoxStyle.Information)
                            Flag = True
                        Else
                            Throw Exx
                        End If
                    Else
                        Throw Exx
                    End If



                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Unable to change Employee Code", MsgBoxStyle.Critical)
                End Try
                Global1.Business.CommitTransaction()

            End If
        Else

            MsgBox("Please select a Valid Code", MsgBoxStyle.Critical)
        End If

        If Flag Then
            CType(Me.Owner, frmPrMsEmployees).CalledFromChangeCode()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("With this action ALL Employees code will change to new ones as a combination of PREFIX + Old employee Code, Proceed ?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            Dim Prefix As String = ""
            Prefix = Me.txtPrefix.Text
            Dim Flag As Boolean = False
            Dim EmpCode As String
            Dim NewCode As String
            If Prefix = "" Then
                MsgBox("Please enter valid prefix", MsgBoxStyle.Critical)
            Else
                Dim Ds As DataSet
                Ds = Global1.Business.GetAllEmployeesOfTemplateGroup(GlbTemplateGroupCode)
                Try
                    Global1.Business.BeginTransaction()
                    Dim Exx As New System.Exception
                    If CheckDataSet(Ds) Then
                        Dim i As Integer
                        For i = 0 To Ds.Tables(0).Rows.Count - 1

                            EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                            OldCode = EmpCode
                            newcode = Prefix & EmpCode


                            If NewCode <> "" Then
                                Dim NewEmp As New cPrMsEmployees(NewCode)
                                If NewEmp.Code <> "" Then
                                    MsgBox("Employee with code " & NewCode & " already Exists", MsgBoxStyle.Critical)
                                    Throw Exx
                                Else
                                    Dim Oldemp As New cPrMsEmployees(OldCode)
                                    Oldemp.Code = NewCode
                                    If Oldemp.Save() Then
                                        If Global1.Business.ChangeEmployeeCode(OldCode, NewCode) Then
                                            Flag = True
                                        Else
                                            Throw Exx
                                        End If
                                    Else
                                        Throw Exx
                                    End If
                                End If
                            Else

                                MsgBox("Please select a Valid Code", MsgBoxStyle.Critical)
                            End If
                        Next
                    End If

                Catch ex As Exception
                    Global1.Business.Rollback()
                    Utils.ShowException(ex)
                    MsgBox("Unable to change Employee Code (NewCode: " & NewCode & " Old Code:" & OldCode, MsgBoxStyle.Critical)
                    Exit Sub
                End Try

                Global1.Business.CommitTransaction()
                MsgBox("Finsh with Changing", MsgBoxStyle.Information)
            End If
            If Flag Then
                CType(Me.Owner, frmPrMsEmployees).CalledFromChangeCode()
                Me.Close()
            End If
        End If
    End Sub

    'Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
    '    Dim NewCode As String = Me.TextBox2.Text
    '    Dim Exx As New System.Exception
    '    Dim Flag As Boolean = False

    '    If NewCode <> "" Then
    '        Dim NewEmp As New cPrMsEmployees(NewCode)
    '        If NewEmp.Code <> "" Then
    '            MsgBox("Employee with code " & NewCode & " already Exists", MsgBoxStyle.Critical)
    '            Exit Sub
    '        Else


    '        End If
    '    Else

    '        MsgBox("Please select a Valid Code", MsgBoxStyle.Critical)
    '    End If

    '    If Flag Then
    '        CType(Me.Owner, frmPrMsEmployees).CalledFromChangeCode()
    '        Me.Close()
    '    End If
    'End Sub
End Class