Imports System.Data

Public Class FrmCopyUser
    Public ComCode As String
    Dim Company As New cAdMsCompany
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim Exx As New System.Exception
        Dim UFrom As New cUsers
        Dim Uto As New cUsers

        UFrom = CType(Me.ComboFrom.SelectedItem, cUsers)
        Uto = CType(Me.ComboTo.SelectedItem, cUsers)

        Dim DsU As DataSet
        Dim DsP As New DataSet
        Try


            If Global1.Business.UserExistInCompany(UFrom.UserName, Company) Then
                If Not Global1.Business.UserExistInCompany(Uto.UserName, Company) Then
                    If Global1.Business.AddUserOnCompany(Uto.UserName, Company) Then
                        MsgBox("User Added Succefully", MsgBoxStyle.Information)
                        DsP = Global1.Business.GetUserPermitions("", UFrom.UserName, False)
                        If CheckDataSet(DsP) Then
                            Dim i As Integer
                            For i = 0 To DsP.Tables(0).Rows.Count - 1
                                Dim UP As New cPrSsUserPermitions(DsP.Tables(0).Rows(i))
                                UP.id = 0
                                UP.UserCode = Uto.UserName
                                If Not UP.Save Then
                                    Throw Exx
                                End If
                            Next
                            MsgBox("User " & Uto.UserName & " Permitions Saved")

                        Else
                            MsgBox("User " & UFrom.UserName & " Has no permitions on company " & Company.Code)
                        End If
                    Else
                        MsgBox("Fail to add user " & Uto.UserName & " on company", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("User " & Uto.UserName & " Already exists on Company", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("User " & UFrom.UserName & " does not exists on Company", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try


    End Sub
   

    Private Sub FrmCopyUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Company = New cAdMsCompany(ComCode)
        LoadComboUsers()
    End Sub
    Private Sub LoadComboUsers()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsUsers()
        Dim i As Integer
        Dim UserCode As String
        If CheckDataSet(ds) Then
            Me.ComboFrom.BeginUpdate()
            Me.ComboFrom.Items.Clear()
            Me.ComboTo.BeginUpdate()
            Me.ComboTo.Items.Clear()
            For i = 0 To ds.Tables(0).Rows.Count - 1
                UserCode = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                Dim U As New cUsers(UserCode)
                Me.ComboFrom.Items.Add(U)
                Me.ComboTo.Items.Add(U)
            Next
            Me.ComboFrom.EndUpdate()
            Me.ComboFrom.SelectedIndex = 0
            Me.ComboTo.EndUpdate()
            Me.ComboTo.SelectedIndex = 0
        End If
    End Sub
End Class