Public Class E_Final
    Public Earn As cPrMsTemplateEarnings
    Private mMyValue As Double = 0
    Public Sub LoadMe()
        Me.txtDesc.Text = Earn.ErnCodCode & " - " & Earn.DisplayName
    End Sub
    Public Sub ClearMe()
        Me.txtDesc.Text = ""
        MyValue = 0
        Me.Earn = New cPrMsTemplateEarnings
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
