
Imports System.Security.Principal

Public Class FrmLogin
    Dim ADcurrentUser As String = ""
    Friend AutomaticLogin As Boolean = False

    Friend Sub TryToLogin(Optional ByVal User As String = "")

        Dim strConnect As String
        Dim Flag As Boolean = True
        Dim Flag2 As Boolean = False

        If User = "" Then
            Err1.SetError(TxtUser, "")
            If TxtUser.Text = "" Then
                Err1.SetError(TxtUser, "User field is required")
                Flag = False
            Else
                User = TxtUser.Text
            End If
        Else
            Flag2 = True
        End If

        If Flag Then
            Try
                Global1.GLBUserCode = Trim(Me.TxtUser.Text)
                Global1.GLBUserPassword = Trim(Me.txtPass.Text)
                Dim L As New cLogin
                If Global1.SQLAuthentication Then
                    strConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";User ID=" + Trim(User) + ";Password=" + Trim(txtPass.Text) + ";"
                Else
                    strConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";Trusted_Connection=Yes;"
                    ' strConnect = "Server=tcp:insoft-gn.database.windows.net,1433;Initial Catalog=insoft;Persist Security Info=False;User ID=insoft-gn-User;Password=HS2hKnXcXFAqq8Qa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                    'Global1.GLBUserCode = "nodal"
                    'User = "Nodal"
                End If
                Debug.WriteLine(strConnect)
                If L.TryToConnect(strConnect, True) Then
                    If Not AutomaticLogin Then
                        MsgBox("Succesfull login for user " & User, MsgBoxStyle.Information)
                    End If
                    Global1.UserName = User

                    Global1.Business = New cBusiness
                    Dim CUser As New cUsers(User)
                    If Not CUser Is Nothing Then
                        If CUser.Id > 0 Then
                            Global1.GLBUserId = CUser.Id
                            Global1.GlobalUser = CUser
                        End If
                    End If

                    Dim Role As String

                    'Role = Global1.Business.GetUserRole
                    If CUser.MyRole = 1 Then
                        Role = Global1.Roles.Admin
                    ElseIf CUser.MyRole = 2 Then
                        Role = Global1.Roles.Manager
                    ElseIf CUser.MyRole = 3 Then
                        Role = Global1.Roles.User
                    ElseIf CUser.MyRole = 4 Then
                        Role = Global1.Roles.TimeAttetance
                    End If

                    Global1.UserRole = Role

                    If Role = "" Then
                        Role = "-1"
                    End If
                    Global1.IsUserEnabled = False

                    'If CInt(Role) <> Global1.Roles.Admin Then
                    ' Global1.UserRole = Global1.Roles.User
                    If Not CUser Is Nothing Then
                        If CUser.Id > 0 Then
                            Global1.IsUserEnabled = CUser.IsEnabled
                            If Not Global1.IsUserEnabled Then
                                MsgBox("User " & User & " is not Enabled as Nodal Payroll User", MsgBoxStyle.Critical)
                            End If
                        Else
                            If Not AutomaticLogin Then
                                MsgBox("User Does not Exist as Nodal Payroll User", MsgBoxStyle.Critical)
                            End If
                        End If
                    Else
                        If Not AutomaticLogin Then
                            MsgBox("User Does not Exist as Nodal Payroll User", MsgBoxStyle.Critical)
                        End If
                    End If
                    'Else
                    '   Global1.IsUserEnabled = True
                    '  Global1.UserRole = Global1.Roles.Admin
                    'End If
                    If Global1.IsUserEnabled Then
                        If Not AutomaticLogin Then
                            CType(Me.MdiParent, FrmMain).ArrangeMenus()
                        End If
                    End If
                    If Not AutomaticLogin Then
                        Me.Close()
                    End If
                Else
                    If Not Flag2 Then
                        If Not AutomaticLogin Then
                            MsgBox("Login fails for user " & User, MsgBoxStyle.Critical)
                        End If
                        Me.TxtUser.Focus()
                        'CType(Me.MdiParent, FrmMain).InitStatusBar()
                    End If
                End If
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                ' CType(Me.MdiParent, FrmMain).InitStatusBar()
            End Try
        End If

    End Sub

    Private Sub FrmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To Global1.ServerDatabase.GetUpperBound(0)
            CmbServer.Items.Add(Global1.ServerDatabase(i, 1) & " on " & Global1.ServerDatabase(i, 0))
        Next

        CmbServer.SelectedIndex = 0
        Global1.DbaseServerName = Global1.ServerDatabase(CmbServer.SelectedIndex, 0)
        Global1.DbaseName = Global1.ServerDatabase(CmbServer.SelectedIndex, 1)

        Me.Left = 0 'CType(Me.MdiParent, FrmMain).PanelTree.Width + 2
        Me.Top = 0
        Me.TxtUser.Focus()
        ADcurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()


        If Me.AutomaticLogin Then
            TryToLogin()
        End If

    End Sub

    Private Sub cmbServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbServer.SelectedIndexChanged
        Global1.DbaseServerName = Global1.ServerDatabase(CmbServer.SelectedIndex, 0)
        Global1.DbaseName = Global1.ServerDatabase(CmbServer.SelectedIndex, 1)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Me.CBAuthenticationMethod.CheckState = CheckState.Checked Then
            Global1.SQLAuthentication = False
        Else
            Global1.SQLAuthentication = True
        End If
        TryToLogin()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtPass.Focus()
        End If
    End Sub

    Private Sub txtPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnLogin.Focus()
        End If
    End Sub

    Private Sub CBAuthenticationMethod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBAuthenticationMethod.CheckedChanged
        If Me.CBAuthenticationMethod.CheckState = CheckState.Checked Then
            Me.TxtUser.Text = ADcurrentUser
        Else
            Me.TxtUser.Text = ""
        End If
    End Sub
End Class



