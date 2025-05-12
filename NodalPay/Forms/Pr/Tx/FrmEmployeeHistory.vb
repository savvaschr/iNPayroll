Public Class FrmEmployeeHistory
    Public ShowWhat As Integer = 0
    Public EmpCode As String = ""

    Private Sub FrmEmployeeHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ShowWhat = 1 Then
            loadDG1()
        Else
            loadDG2()
        End If
    End Sub
    Private Sub loadDG1()
        Dim ds As DataSet
        ds = Global1.Business.getEmployeeEmploymentHistory(EmpCode)
        DG1.DataSource = ds.Tables(0)
        DG1.Visible = True
        DG2.Visible = False

    End Sub
    Private Sub loadDG2()
        Dim ds As DataSet
        ds = Global1.Business.getEmployeePositionHistory(EmpCode)
        DG2.DataSource = ds.Tables(0)
        DG2.Visible = True
        DG1.Visible = False

    End Sub

End Class