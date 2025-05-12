Public Class FrmCompanyUsers
    Public ComCode As String
    Dim Comp As New cAdMsCompany(ComCode)
    Dim MyDs As DataSet
    Public DsAllCompanies As DataSet
    Private Sub FrmCompanyUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Comp = New cAdMsCompany(ComCode)
        FillDG()
        LoadComboUsers()
        Me.txtCode.Text = ComCode
        Me.txtCode.ReadOnly = True

    End Sub
    Private Sub FillDG()

        MyDs = Global1.Business.GetAllUsersOfCompany(ComCode)
        Me.DG1.DataSource = MyDs.Tables(0)
    End Sub
        
    Private Sub LoadComboUsers()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsUsers()
        Dim i As Integer
        Dim UserCode As String
        If CheckDataSet(ds) Then
            Me.ComboUser.BeginUpdate()
            Me.ComboUser.Items.Clear()
            For i = 0 To ds.Tables(0).Rows.Count - 1
                UserCode = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                Dim U As New cUsers(UserCode)
                Me.ComboUser.Items.Add(U)
            Next
            Me.ComboUser.EndUpdate()
            Me.ComboUser.SelectedIndex = 0
        End If
    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        AddUserOnCompany()
    End Sub
    Private Sub AddUserOnCompany()
        If ValidateUserOnCompany Then

            If Global1.Business.AddUserOnCompany(CType(Me.ComboUser.SelectedItem, cUsers).UserName, Comp) Then
                MsgBox("User Added Succefully", MsgBoxStyle.Information)
                FillDG()
            End If
        End If
    End Sub
    Private Function ValidateUserOnCompany()
        Dim Flag As Boolean = True
        If Global1.Business.userexistincompany(CType(Me.ComboUser.SelectedItem, cUsers).UserName, Comp) Then
            flag = False
        End If
        If Not Flag Then
            MsgBox("User Already Exist in Company", MsgBoxStyle.Critical)
        End If
        Return Flag

    End Function

    Private Sub TSBDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Delete User " & CType(Me.ComboUser.SelectedItem, cUsers).UserName & " From Company?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            Dim User As String
            User = DbNullToString(MyDs.Tables(0).Rows(DG1.CurrentRow.Index).Item(0))
            Dim U As New cUsers(User)
            If Global1.Business.DeleteUserFromCompany(CType(Me.ComboUser.SelectedItem, cUsers).UserName, Comp) Then
                MsgBox("User Deleted succesfully", MsgBoxStyle.Information)
                FillDG()
            End If
        End If

    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        Try

        
            If CheckDataSet(MyDs) Then
                Dim User As String
                Dim i As Integer
                i = DG1.CurrentRow.Index
                User = DbNullToString(MyDs.Tables(0).Rows(i).Item(0))
                Dim U As New cUsers(User)
                Me.ComboUser.SelectedIndex = Me.ComboUser.FindStringExact(U.ToString)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnUserPermitions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserPermitions.Click
        Dim F As New frmPrSsPermitions

        F.User = CType(Me.ComboUser.SelectedItem, cUsers).UserName
        F.Company = "" ' ComCode
        F.show()
    End Sub
    Public Sub AssignUserPermitions()
        Dim i As Integer
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsUsers()
        Dim UserCode As String
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                UserCode = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                Dim U As New cUsers(UserCode)
                Dim F As New frmPrSsPermitions
                F.User = U.UserName
                F.Company = "" 'ComCode
                F.SaveMe2()
            Next
            
        End If
        

    End Sub

    Private Sub btnAddUserToAllCompanies_Click(sender As Object, e As EventArgs) Handles btnAddUserToAllCompanies.Click
        Dim Ex1 As New System.Exception
        Try
            Dim ans As New MsgBoxResult
            Dim User As String
            Dim ThisComp As New cAdMsCompany
            User = CType(Me.ComboUser.SelectedItem, cUsers).UserName
            ans = MsgBox("With this action User " & User & " will be added to All Companies, Do you want to Proceed ?", MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then
                Global1.Business.BeginTransaction()
                Dim i As Integer
                For i = 0 To DsAllCompanies.Tables(0).Rows.Count - 1
                    ThisComp = New cAdMsCompany(DsAllCompanies.Tables(0).Rows(i))
                    If Not Global1.Business.UserExistInCompany(User, ThisComp) Then
                        If Not Global1.Business.AddUserOnCompany(User, ThisComp) Then
                            Throw Ex1
                        End If
                    End If
                Next
                Global1.Business.CommitTransaction()
                MsgBox("User is succesfully Added to All Companies", MsgBoxStyle.Information)
                FillDG()
            End If
        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
        End Try
    End Sub
End Class