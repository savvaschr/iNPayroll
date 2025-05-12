Public Class C_Final
    Public Con As cPrMsTemplateContributions
    Private mMyValue As Double
    Public Sub LoadMe()
        Me.txtDesc.Text = Con.ConCodCode & " - " & Con.DisplayName
    End Sub
    Public Sub ClearMe()
        Me.txtDesc.Text = ""
        Me.MyValue = 0
        Me.Con = New cPrMsTemplateContributions
    End Sub
    Public Property MyValue() As Double
        Get
            Return mmyvalue
        End Get
        Set(ByVal value As Double)
            mMyValue = value
            Me.txtValue.Text = Format(value, "0.00")
        End Set
    End Property
End Class
