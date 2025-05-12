Public Class E_Pay
    Public Ern As cPrMsTemplateEarnings
    Public MyType As String
    Dim NotNow As Boolean = False
    Private Sub E_Pay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtValue.KeyPress, AddressOf NumericKeyPressWithNegative
        AddHandler txtValue.Leave, AddressOf NumericOnLeaveWithNegative
    End Sub
    Public Sub ClearMe()
        Me.Enabled = False
        Me.txtCode.Text = ""
        Me.txtCode.Tag = ""
        Me.txtValue.Text = Format(0, "0.00")

    End Sub
    Public Sub LoadME()
        With Ern
            Me.Enabled = True
            Me.txtCode.Tag = .ErnCodCode
            Me.txtCode.Text = .ErnCodCode & " - " & .DisplayName
            If .FromMode = "F" Or .FromMode = "T" Then 'Employee
                Me.txtValue.ReadOnly = True
            Else
                Me.txtValue.ReadOnly = False
            End If
            MyType = Ern.TypeMode
           
        End With
    End Sub

    Public Sub MakeMeReadOnly()
        Me.txtValue.ReadOnly = True
    End Sub
End Class
