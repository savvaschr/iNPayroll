Public Class C_Pay
    Public Con As New cPrMsTemplateContributions
    Public MyType As String
    Dim NotNow As Boolean = False
    Private Sub C_Pay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtValue.KeyPress, AddressOf NumericKeyPressWithNegative
        AddHandler txtValue.Leave, AddressOf NumericOnLeaveWithNegative
    End Sub
    Public Sub ClearMe()
        Me.Enabled = False
        Me.txtCode.Text = ""
        Me.txtCode.Tag = ""
        Me.txtValue.Text = Format(0, "0.00")
    End Sub
    Public Sub LoadMe()
        With Con
            Me.Enabled = True
            Me.txtCode.Tag = .ConCodCode
            Me.txtCode.Text = .ConCodCode & " - " & .DisplayName
            If .FromMode = "F" Or .FromMode = "T" Then 'Or .FromMode = "X" Then 'Employee
                Me.txtValue.ReadOnly = True
            Else
                Me.txtValue.ReadOnly = False
            End If
            MyType = .TypeMode
        End With
    End Sub
    Public Sub MakeMeReadOnly()
        Me.txtValue.ReadOnly = True
    End Sub
End Class
