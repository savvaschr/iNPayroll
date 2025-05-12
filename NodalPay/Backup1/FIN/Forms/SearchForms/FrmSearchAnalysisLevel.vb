Public Class FrmSearchAnalysisLevel
    Dim ds As DataSet
    Dim selected As Integer
    Public AnalysisChoice As Integer
    Public LevelChoice As Integer

    Private Sub FrmSearchAnalysisLevel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        If AnalysisChoice = 0 Then
            If LevelChoice = 0 Then
                Me.DgAnal.Visible = True
                Me.DgLinesAnal.Visible = False
                Me.DgAnalLineLevel3.Visible = False
                Me.Dg1AnalLevel3.Visible = False
            Else
                Me.DgAnal.Visible = False
                Me.DgLinesAnal.Visible = False
                Me.DgAnalLineLevel3.Visible = False
                Me.Dg1AnalLevel3.Visible = True
            End If

        ElseIf AnalysisChoice = 1 Then
            If LevelChoice = 0 Then
                Me.DgAnal.Visible = False
                Me.DgLinesAnal.Visible = True
                Me.DgAnalLineLevel3.Visible = False
                Me.Dg1AnalLevel3.Visible = False
            Else
                Me.DgAnal.Visible = False
                Me.DgLinesAnal.Visible = False
                Me.DgAnalLineLevel3.Visible = True
                Me.Dg1AnalLevel3.Visible = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
       
        If AnalysisChoice = 0 Then
            If LevelChoice = 0 Then
                ds = Global1.Business.GetLimitedAnalysis(Me.TxtCode.Text, TxtDescriptionS.Text, 0, 0)
                Me.DgAnal.DataSource = ds.Tables(0)

                'For i = 0 To (ds.Tables(0).Rows.Count - 1)
                '    If String.Compare(ds.Tables(0).Rows(i).Item(6).ToString, "A") = 0 Then
                '        DgAnal.Item(7, i).Value = "YES"
                '    Else
                '        DgAnal.Item(7, i).Value = "NO"
                '    End If
                'Next
            Else
                ds = Global1.Business.GetLimitedAnalysis(Me.TxtCode.Text, TxtDescriptionS.Text, 0, 1)
                Me.Dg1AnalLevel3.DataSource = ds.Tables(0)

                'For i = 0 To (ds.Tables(0).Rows.Count - 1)
                '    If String.Compare(ds.Tables(0).Rows(i).Item(5).ToString, "A") = 0 Then
                '        Dg1AnalLevel3.Item(6, i).Value = "YES"
                '    Else
                '        Dg1AnalLevel3.Item(6, i).Value = "NO"
                '    End If
                'Next
            End If
        Else
            If LevelChoice = 0 Then
                ds = Global1.Business.GetLimitedAnalysis(Me.TxtCode.Text, TxtDescriptionS.Text, 1, 0)
                Me.DgLinesAnal.DataSource = ds.Tables(0)

                'For i = 0 To (ds.Tables(0).Rows.Count - 1)
                '    If String.Compare(ds.Tables(0).Rows(i).Item(6).ToString, "A") = 0 Then
                '        DgLinesAnal.Item(7, i).Value = "YES"
                '    Else
                '        DgLinesAnal.Item(7, i).Value = "NO"
                '    End If
                'Next
            Else
                ds = Global1.Business.GetLimitedAnalysis(Me.TxtCode.Text, TxtDescriptionS.Text, 1, 1)
                Me.DgAnalLineLevel3.DataSource = ds.Tables(0)

                'For i = 0 To (ds.Tables(0).Rows.Count - 1)
                '    If String.Compare(ds.Tables(0).Rows(i).Item(5).ToString, "A") = 0 Then
                '        DgAnalLineLevel3.Item(6, i).Value = "YES"
                '    Else
                '        DgAnalLineLevel3.Item(6, i).Value = "NO"
                '    End If
                'Next
            End If
        End If

    End Sub

    Private Sub DgLinesAnal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgLinesAnal.DoubleClick
        Dim code As String
        selected = Me.DgLinesAnal.CurrentRow.Index
        code = ds.Tables(0).Rows(selected).Item(0)
        CType(Me.Owner, FrmAnalysis).LoadCode(code)
        Me.Close()
    End Sub

    Private Sub DgAnal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgAnal.DoubleClick
        Dim code As String
        selected = Me.DgAnal.CurrentRow.Index
        code = ds.Tables(0).Rows(selected).Item(0)
        CType(Me.Owner, FrmAnalysis).LoadCode(code)
        Me.Close()
    End Sub

    Private Sub DgAnalLineLevel3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgAnalLineLevel3.DoubleClick
        Dim code As String
        selected = Me.DgAnalLineLevel3.CurrentRow.Index
        code = ds.Tables(0).Rows(selected).Item(0)
        CType(Me.Owner, FrmAnalysis).LoadCode(code)
        Me.Close()
    End Sub

    Private Sub Dg1AnalLevel3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1AnalLevel3.DoubleClick
        Dim code As String
        selected = Me.Dg1AnalLevel3.CurrentRow.Index()
        code = ds.Tables(0).Rows(selected).Item(0)
        CType(Me.Owner, FrmAnalysis).LoadCode(code)
        Me.Close()
    End Sub
End Class