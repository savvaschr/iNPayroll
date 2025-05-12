Public Class D_Final
    Public Ded As cPrMsTemplateDeductions
    Private mMyValue As Double
    Public Sub LoadMe()
        Me.txtDesc.Text = Ded.DedCodCode & " - " & Ded.DisplayName
    End Sub
    Public Sub ClearMe()
        Me.txtDesc.Text = ""
        Me.MyValue = 0
        Me.Ded = New cPrMsTemplateDeductions
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
