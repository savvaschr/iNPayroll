Public Class D_Emp
    Public Ded As New cPrMsTemplateDeductions
    Dim NotNow As Boolean = False
    Private Sub D_Emp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler txtValue.KeyPress, AddressOf NumericKeyPressWithNegative
        AddHandler txtValue.Leave, AddressOf NumericOnLeaveWithNegative
    End Sub
    Public Sub ClearMe()
        Me.Enabled = False
        Me.txtCode.Text = ""
        Me.txtCode.Tag = ""
        Me.txtValue.Text = Format(0, "0.00")
        Me.LblVP.Text = ""
    End Sub
    Public Sub LoadMe()
        With Ded
            Me.Enabled = True
            Me.txtCode.Tag = .DedCodCode
            Me.txtCode.Text = .DedCodCode & " - " & .DisplayName
            If .FromMode = "E" Or .FromMode = "F" Or .FromMode = "X" Then 'Employee
                Me.txtValue.ReadOnly = False
            Else
                Me.txtValue.ReadOnly = True
            End If

            If .TypeMode = "V" Then
                Me.LblVP.Text = ""
            Else
                Me.LblVP.Text = "%"
            End If
            Me.txtValue.Tag = .TypeMode

        End With

    End Sub
    Private Sub txtValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.Validated
        If NotNow Then
            NotNow = False
            Exit Sub
        End If
        If Ded.FromMode = "X" Then Exit Sub
        Er1.SetError(txtValue, "")
        If Me.LblVP.Text = "%" Then
            If Me.txtValue.Text > 100 Then
                Er1.SetError(Me.txtValue, "Invalid Discount Value, discount must be between 0 and 100")
                Me.txtValue.Text = "0.00"
                Me.txtValue.SelectAll()
                Me.txtValue.Focus()
                NotNow = True
            End If
        End If

    End Sub
End Class
