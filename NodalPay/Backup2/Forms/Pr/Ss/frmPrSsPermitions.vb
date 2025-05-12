Public Class frmPrSsPermitions
    Public User As String
    Public Company As String
    Dim Ds As DataSet

    Private Sub frmPrSsPermitions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Ds = Global1.Business.getUserPermitions(Company, User, False)
        If Not CheckDataSet(Ds) Then
            CreateDefaultUserPermitions()
            Ds = Global1.Business.GetUserPermitions(Company, User, False)
            'Ds = Global1.Business.GetUserPermitions(Company, User, True)
            'Dim i As Integer
            'For i = 0 To Ds.Tables(0).Rows.Count - 1
            '    Ds.Tables(0).Rows(i).Item(1) = Company
            '    Ds.Tables(0).Rows(i).Item(2) = User
            'Next
        End If
        DG1.DataSource = Ds.Tables(0)
    End Sub
    Private Sub CreateDefaultUserPermitions()
        Dim P As New cPrSsUserPermitions
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "ApplicationSetup"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Employees"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Administration"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Payroll"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "System"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Reports"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Payroll Analysis"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "SI Contributions"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "IR Reports"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Salary"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Discounts"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "AnnualLeave"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Advances"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "ArchivePayslips"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Loans"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
        With P
            .id = 0
            .ComCode = Company
            .UserCode = User
            .Entity = "Payroll AnnualLeave"
            .FullPermission = 1
            .ReadonlyPermission = 0
            .NoPermission = 0
            .Save()
        End With
    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        SaveMe(True)
    End Sub
    Private Function SaveMe(ByVal showmsg As Boolean)
        Dim Exx As New System.Exception
        If ValidateGrid() Then
            Try
                Global1.Business.BeginTransaction()

                If CheckDataSet(Ds) Then
                    Dim i As Integer
                    Dim Entity As String
                    Dim Full As Integer
                    Dim ROnly As Integer
                    Dim No As Integer
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Entity = DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                        Full = DbNullToString(Ds.Tables(0).Rows(i).Item(4))
                        ROnly = DbNullToString(Ds.Tables(0).Rows(i).Item(5))
                        No = DbNullToString(Ds.Tables(0).Rows(i).Item(6))
                        Dim UP As New cPrSsUserPermitions(Company, User, Entity)
                        UP.ComCode = Company
                        UP.UserCode = User
                        UP.Entity = Entity
                        UP.FullPermission = Full
                        UP.ReadonlyPermission = ROnly
                        UP.NoPermission = No
                        If Not UP.Save Then
                            Throw Exx
                        End If
                    Next
                End If
            Catch ex As Exception
                Global1.Business.Rollback()
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
            Global1.Business.CommitTransaction()
            If showmsg Then
                MsgBox("Changes are Saved", MsgBoxStyle.Information)
            End If
        End If
    End Function
    Private Function ValidateGrid() As Boolean
        Dim F As Boolean = True
        If CheckDataSet(Ds) Then
            Dim i As Integer
            Dim Entity As String
            Dim Full As Integer
            Dim ROnly As Integer
            Dim No As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Entity = DbNullToString(Ds.Tables(0).Rows(i).Item(3))
                Full = DbNullToString(Ds.Tables(0).Rows(i).Item(4))
                ROnly = DbNullToString(Ds.Tables(0).Rows(i).Item(5))
                No = DbNullToString(Ds.Tables(0).Rows(i).Item(6))
                If Entity <> "Salary" Then
                    If Full <> 0 And Full <> 1 Then
                        F = False
                    End If
                    If ROnly <> 0 And ROnly <> 1 Then
                        F = False
                    End If
                    If No <> 0 And No <> 1 Then
                        F = False
                    End If
                Else
                    If Full <> 0 And Full <> 1 And Full <> 2 Then
                        F = False
                    End If
                    If ROnly <> 0 And ROnly <> 1 Then
                        F = False
                    End If
                    If No <> 0 And No <> 1 Then
                        F = False
                    End If
                End If
            Next
        End If
        If Not F Then
            MsgBox("Please correct Values of Permissions.Accepted values are 0 or 1 (For Salary 'full' 2 is accepted ) ", MsgBoxStyle.Critical)
        End If
        Return F
    End Function

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        Dim S As String
        Dim c As Integer = e.ColumnIndex
        Dim r As Integer = e.RowIndex
        S = DG1.Item(c, r).Value
        If S <> 0 And S <> 1 And S <> 2 Then
            MsgBox("Cell Value must be 0  or 1 (Salary 2) ", MsgBoxStyle.Critical)
        End If
    End Sub
    Public Sub SaveMe2()
        Ds = Global1.Business.GetUserPermitions(Company, User, False)
        If Not CheckDataSet(Ds) Then
            CreateDefaultUserPermitions()
            Ds = Global1.Business.GetUserPermitions(Company, User, False)
            'Ds = Global1.Business.GetUserPermitions(Company, User, True)
            'Dim i As Integer
            'For i = 0 To Ds.Tables(0).Rows.Count - 1
            '    Ds.Tables(0).Rows(i).Item(1) = Company
            '    Ds.Tables(0).Rows(i).Item(2) = User
            'Next
        End If
        DG1.DataSource = Ds.Tables(0)
        SaveMe(False)
    End Sub
End Class