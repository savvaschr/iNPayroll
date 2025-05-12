Public Class FrmSelectEDCToPrint
    Public DS As DataSet
    Public Column_EV1 As Integer
    Public Column_E1 As Integer
    Public Column_DV1 As Integer
    Public Column_D1 As Integer
    Public Column_CV1 As Integer
    Public Column_C1 As Integer

    Public ReportDesc1 As String
    Public ReportDesc2 As String

    Public AllowSixSelections As Boolean = False

    Dim ArE(15) As CheckBox
    Dim ArD(15) As CheckBox
    Dim ArC(15) As CheckBox

    Dim ArECounter(15) As Integer
    Dim ArDCounter(15) As Integer
    Dim ArCCounter(15) As Integer



    Private Sub FrmSelectEDCToPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not AllowSixSelections Then
            If MoreThanOneSelection() Then
                e.Cancel = True
            Else
                FixDataset()
            End If
        Else
            If MoreThanSixSelections() Then
                e.Cancel = True
            Else
                FixDatasetSix()

            End If
        End If

    End Sub
    Public Function MoreThanOneSelection() As Boolean
        Dim F As Boolean = False
        Dim k As Integer
        Dim C As Integer = 0
        For k = 0 To 14
            If ArE(k).Checked Then
                C = C + 1
            End If
            If ArD(k).Checked Then
                C = C + 1
            End If
            If ArC(k).Checked Then
                C = C + 1
            End If
        Next
        If C > 1 Then
            MsgBox("You can only Select one EDC")
            F = True
        End If
        Return F

    End Function
    Public Function MoreThanSixSelections() As Boolean
        Dim F As Boolean = False
        Dim k As Integer
        Dim C As Integer = 0
        For k = 0 To 14
            If ArE(k).Checked Then
                C = C + 1
            End If
            If ArD(k).Checked Then
                C = C + 1
            End If
            If ArC(k).Checked Then
                C = C + 1
            End If
        Next
        If C > 6 Then
            MsgBox("You can only Select Six EDC")
            F = True
        End If
        Return F

    End Function
    Private Sub FrmSelectEDCToPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitArrays()
        If AllowSixSelections Then
            Me.txtDesc1.Visible = True
            Me.txtDesc2.Visible = True
        Else
            Me.txtDesc1.Visible = False
            Me.txtDesc2.Visible = False
        End If
        If CheckDataSet(DS) Then
            Dim i As Integer
            Dim k As Integer

            Dim C1 As Integer = 0
            Dim l As Integer = 0
            Dim D As String
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1)) <> "" Then
                    'Debug.WriteLine(DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1))
                    D = DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1)
                    ArE(l).Text = DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1)
                    ArE(l).Visible = True

                End If
                l = l + 1
                C1 = C1 + 2

            Next
            C1 = 0
            l = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1)) <> "" Then
                    D = DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1)
                    ArD(l).Text = DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1)
                    ArD(l).Visible = True
                End If
                l = l + 1
                C1 = C1 + 2

            Next
            C1 = 0
            l = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1)) <> "" Then
                    D = DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1)
                    ArC(l).Text = DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1)
                    ArC(l).Visible = True
                End If
                l = l + 1
                C1 = C1 + 2
            Next
        End If
    End Sub
    Private Sub InitArrays()
        ArE(0) = Me.CheckBox1
        ArE(1) = Me.CheckBox2
        ArE(2) = Me.CheckBox3
        ArE(3) = Me.CheckBox4
        ArE(4) = Me.CheckBox5
        ArE(5) = Me.CheckBox6
        ArE(6) = Me.CheckBox7
        ArE(7) = Me.CheckBox8
        ArE(8) = Me.CheckBox9
        ArE(9) = Me.CheckBox10
        ArE(10) = Me.CheckBox11
        ArE(11) = Me.CheckBox12
        ArE(12) = Me.CheckBox13
        ArE(13) = Me.CheckBox14
        ArE(14) = Me.CheckBox15

        ArD(0) = Me.CheckBox16
        ArD(1) = Me.CheckBox17
        ArD(2) = Me.CheckBox18
        ArD(3) = Me.CheckBox19
        ArD(4) = Me.CheckBox20
        ArD(5) = Me.CheckBox21
        ArD(6) = Me.CheckBox22
        ArD(7) = Me.CheckBox23
        ArD(8) = Me.CheckBox24
        ArD(9) = Me.CheckBox25
        ArD(10) = Me.CheckBox26
        ArD(11) = Me.CheckBox27
        ArD(12) = Me.CheckBox28
        ArD(13) = Me.CheckBox29
        ArD(14) = Me.CheckBox30

        ArC(0) = Me.CheckBox31
        ArC(1) = Me.CheckBox32
        ArC(2) = Me.CheckBox33
        ArC(3) = Me.CheckBox34
        ArC(4) = Me.CheckBox35
        ArC(5) = Me.CheckBox36
        ArC(6) = Me.CheckBox37
        ArC(7) = Me.CheckBox38
        ArC(8) = Me.CheckBox39
        ArC(9) = Me.CheckBox40
        ArC(10) = Me.CheckBox41
        ArC(11) = Me.CheckBox42
        ArC(12) = Me.CheckBox43
        ArC(13) = Me.CheckBox44
        ArC(14) = Me.CheckBox45
        Dim k As Integer
        For k = 0 To 14
            ArE(k).Text = ""
            ArE(k).Visible = False
            ' ArE(k).Checked = True

            ArD(k).Text = ""
            ArD(k).Visible = False
            ' ArD(k).Checked = True

            ArC(k).Text = ""
            ArC(k).Visible = False
            ' ArC(k).Checked = True



            ArECounter(k) = 0
            ArDCounter(k) = 0
            ArCCounter(k) = 0


        Next



    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub FixDataset()
        If CheckDataSet(DS) Then
            Dim i As Integer
            Dim k As Integer

            Dim C1 As Integer = 0
            Dim l As Integer = 0
            Dim N As Integer = 0
            Dim D As String
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1)) <> "" Then
                    If ArE(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_EV1 + C1) = 0
                    Else
                        ArECounter(N) = Me.Column_E1 + C1
                        N = N + 1
                    End If

                End If
                l = l + 1
                C1 = C1 + 2
            Next
            C1 = 0
            l = 0
            N = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1)) <> "" Then
                    If ArD(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_DV1 + C1) = 0
                    Else
                        ArDCounter(N) = Me.Column_D1 + C1
                        N = N + 1
                    End If
                End If
                l = l + 1
                C1 = C1 + 2

            Next
            C1 = 0
            l = 0
            N = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1)) <> "" Then
                    If ArC(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_CV1 + C1) = 0
                    Else
                        ArCCounter(N) = Me.Column_C1 + C1
                        N = N + 1
                    End If
                End If
                l = l + 1
                C1 = C1 + 2
            Next
        End If
        CType(Me.Owner, FrmPayrollTotalsX).ReturnFromselectionEDC(DS, ArECounter, ArDCounter, ArCCounter)
    End Sub
    Private Sub FixDatasetSix()
        If CheckDataSet(DS) Then
            Dim i As Integer
            Dim k As Integer

            Dim C1 As Integer = 0
            Dim l As Integer = 0
            Dim N As Integer = 0
            Dim D As String
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1)) <> "" Then
                    If ArE(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_E1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_EV1 + C1) = 0
                    Else
                        ArECounter(N) = Me.Column_E1 + C1
                        N = N + 1
                    End If

                End If
                l = l + 1
                C1 = C1 + 2
            Next
            C1 = 0
            l = 0
            N = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1)) <> "" Then
                    If ArD(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_D1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_DV1 + C1) = 0
                    Else
                        ArDCounter(N) = Me.Column_D1 + C1
                        N = N + 1
                    End If
                End If
                l = l + 1
                C1 = C1 + 2

            Next
            C1 = 0
            l = 0
            N = 0
            For k = 0 To 14
                If DbNullToString(DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1)) <> "" Then
                    If ArC(l).Checked = False Then
                        DS.Tables(0).Rows(0).Item(Me.Column_C1 + C1) = ""
                        DS.Tables(0).Rows(0).Item(Me.Column_CV1 + C1) = 0
                    Else
                        ArCCounter(N) = Me.Column_C1 + C1
                        N = N + 1
                    End If
                End If
                l = l + 1
                C1 = C1 + 2
            Next
        End If
        CType(Me.Owner, FrmPayrollTotalsX).ReturnFromselectionEDC_SIX(DS, ArECounter, ArDCounter, ArCCounter, Me.txtDesc1.Text, Me.txtDesc2.Text)
    End Sub
End Class