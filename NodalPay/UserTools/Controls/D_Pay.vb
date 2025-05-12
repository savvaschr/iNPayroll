Public Class D_Pay
    Public Ded As New cPrMsTemplateDeductions
    Public MyType As String
    Dim NotNow As Boolean = False
    Private Sub D_Pay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        With Ded
            Me.Enabled = True
            Me.txtCode.Tag = .DedCodCode
            Me.txtCode.Text = .DedCodCode & " - " & .DisplayName
            'If .FromMode = "F" Or .FromMode = "T" Or .FromMode = "X" Then 'Employee
            If .FromMode = "F" Or .FromMode = "T" Then 'Or .FromMode = "X" Then 'Employee
                Me.txtValue.ReadOnly = True
            Else
                Me.txtValue.ReadOnly = False
            End If
            MyType = Ded.TypeMode
        End With

    End Sub
    Public Sub MakeMeReadOnly()
        Me.txtValue.ReadOnly = True
    End Sub
End Class
