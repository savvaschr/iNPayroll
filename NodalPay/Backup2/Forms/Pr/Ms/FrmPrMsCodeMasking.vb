Public Class FrmPrMsCodeMasking
    Dim Ar(19) As CodeMask
    Public InterfaceCode As String
    Private Sub FrmPrMsInterfaceCodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtInterfaceCode.Text = InterfaceCode
        LoadControlsIntoArray()
        Dim Ds As DataSet
        Ds = Global1.Business.GetAllPrMsCodeMasking(InterfaceCode)
        Dim i As Integer
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                Dim CodMsk As New cPrMsCodeMasking(Ds.Tables(0).Rows(i))
                Ar(i).CodeMask = CodMsk
                Ar(i).LoadME()
            Next
        End If
    End Sub
    Private Sub LoadControlsIntoArray()
        Dim i As Integer
        Ar(0) = Me.CodeMask1
        Ar(1) = Me.CodeMask2
        Ar(2) = Me.CodeMask3
        Ar(3) = Me.CodeMask4
        Ar(4) = Me.CodeMask5
        Ar(5) = Me.CodeMask6
        Ar(6) = Me.CodeMask7
        Ar(7) = Me.CodeMask8
        Ar(8) = Me.CodeMask9
        Ar(9) = Me.CodeMask10
        Ar(10) = Me.CodeMask11
        Ar(11) = Me.CodeMask12
        Ar(12) = Me.CodeMask13
        Ar(13) = Me.CodeMask14
        Ar(14) = Me.CodeMask15
        Ar(15) = Me.CodeMask16
        Ar(16) = Me.CodeMask17
        Ar(17) = Me.CodeMask18
        Ar(18) = Me.CodeMask19
        Ar(19) = Me.CodeMask20
        For i = 0 To Ar.Length - 1
            Ar(i).txtPosition.Text = i + 1
        Next
    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Dim i As Integer
        Dim Exx As Exception
        Try

            Global1.Business.BeginTransaction()
            If Not Global1.Business.DeleteMaskingCodesOfCode(Me.txtInterfaceCode.Text) Then
                Throw Exx
            End If
            For i = 0 To Ar.Length - 1
                If Ar(i).txtValue.Text <> "" Then
                    Ar(i).IntCode = Me.txtInterfaceCode.Text
                    Ar(i).txtPosition.Text = i + 1
                    If Not Ar(i).SaveMe() Then
                        Throw Exx
                    End If

                End If
            Next
            Global1.Business.CommitTransaction()
            MsgBox("Changes Are Saved", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Unable to Save Changes", MsgBoxStyle.Critical)
            Utils.ShowException(ex)
            Global1.Business.Rollback()

        End Try
    End Sub
End Class