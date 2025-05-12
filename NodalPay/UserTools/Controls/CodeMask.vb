Public Class CodeMask
    Dim Exx As New Exception
    Public CodeMask As New cPrMsCodeMasking
    Public IntCode As String
    Public Sub Loadcombo()
        With Me.ComboType
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("F -  Fixed Value")
            .Items.Add("V -  Variable Value")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub

    Public Sub ClearMe()
        Me.txtValue.Text = ""
        Me.ComboType.SelectedIndex = 0
    End Sub
    Public Sub LoadME()
        If CodeMask.id > 0 Then
            Me.txtPosition.Text = CodeMask.Position
            Me.txtValue.Text = CodeMask.Value
            Me.ComboType.SelectedIndex = CodeMask.Type
            IntCode = IntCode
        End If
    End Sub
    Public Function SaveMe() As Boolean
        Dim Flag As Boolean = True
        With CodeMask
            .Position = Me.txtPosition.Text
            .Value = Me.txtValue.Text
            .Type = Me.ComboType.SelectedIndex
            .IntCode = IntCode
            If Not .Save Then
                Flag = False
            End If
        End With
        Return Flag
    End Function

    Private Sub CodeMask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Loadcombo()
        Me.ClearMe()

    End Sub

    Private Sub txtPosition_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPosition.GotFocus
        Me.txtValue.SelectAll()
        Me.txtValue.Focus()
    End Sub

    
  

   
End Class
