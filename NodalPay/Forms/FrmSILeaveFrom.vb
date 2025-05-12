Public Class FrmSILeaveFrom

   
    Dim ArAL(10) As TextBox
    Dim ArSI(10) As TextBox
    Dim ArUP(10) As TextBox

    Dim ArALDateF(10) As DateTimePicker
    Dim ArALDateT(10) As DateTimePicker

    Dim ArSIDateF(10) As DateTimePicker
    Dim ArSIDateT(10) As DateTimePicker

    Dim ArUPDateF(10) As DateTimePicker
    Dim ArUPDateT(10) As DateTimePicker

    Public DefTdate As Date
    Public DefFdate As Date

    Public Header As cPrTxTrxnHeader
    Public GLBEmpCode As String
    Public GLBEmpName As String

    Public DefUnits As Double
    Public ActualUnits As Double
    Dim Diff As Double





    Private Sub FrmSILeaveFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Initarrays()
        PutDecimalValidationOnTxts()
        Me.txtEmployee.Text = GLBEmpName

        diff = RoundMe2(DefUnits - ActualUnits, 2)
        ArAL(0).Text = Diff
        Me.txtUnitsDiff.Text = Format(Diff, "0.00")

    End Sub
    Private Sub Initarrays()
        ArAL(0) = Me.txtAL1
        ArAL(1) = Me.txtAL2
        ArAL(2) = Me.txtAL3
        ArAL(3) = Me.txtAL4
        ArAL(4) = Me.txtAL5
        ArAL(5) = Me.txtAL6
        ArAL(6) = Me.txtAL7
        ArAL(7) = Me.txtAL8
        ArAL(8) = Me.txtAL9
        ArAL(9) = Me.txtAL10

        ArSI(0) = Me.txtSI1
        ArSI(1) = Me.txtSI2
        ArSI(2) = Me.txtSI3
        ArSI(3) = Me.txtsi4
        ArSI(4) = Me.txtSI5
        ArSI(5) = Me.txtSI6
        ArSI(6) = Me.txtSI7
        ArSI(7) = Me.txtSI8
        ArSI(8) = Me.txtSI9
        ArSI(9) = Me.txtSI10


        ArUP(0) = Me.txtUP1
        ArUP(1) = Me.txtUP2
        ArUP(2) = Me.txtUP3
        ArUP(3) = Me.txtUP4
        ArUP(4) = Me.txtUP5
        ArUP(5) = Me.txtUP6
        ArUP(6) = Me.txtUP7
        ArUP(7) = Me.txtUP8
        ArUP(8) = Me.txtUP9
        ArUP(9) = Me.txtUP10

        ArALDateF(0) = Me.DALf1
        ArALDateF(1) = Me.DALf2
        ArALDateF(2) = Me.DALf3
        ArALDateF(3) = Me.DALf4
        ArALDateF(4) = Me.DALf5
        ArALDateF(5) = Me.DALf6
        ArALDateF(6) = Me.DALf7
        ArALDateF(7) = Me.DALf8
        ArALDateF(8) = Me.DALf9
        ArALDateF(9) = Me.DALf10


        ArALDateT(0) = Me.DALt1
        ArALDateT(1) = Me.DALt2
        ArALDateT(2) = Me.DALt3
        ArALDateT(3) = Me.DALt4
        ArALDateT(4) = Me.DALt5
        ArALDateT(5) = Me.DALt6
        ArALDateT(6) = Me.DALt7
        ArALDateT(7) = Me.DALt8
        ArALDateT(8) = Me.DALt9
        ArALDateT(9) = Me.DALt10

        ArSIDateF(0) = Me.DSIf1
        ArSIDateF(1) = Me.DSIf2
        ArSIDateF(2) = Me.DSIf3
        ArSIDateF(3) = Me.DSIf4
        ArSIDateF(4) = Me.DSIf5
        ArSIDateF(5) = Me.DSIf6
        ArSIDateF(6) = Me.DSIf7
        ArSIDateF(7) = Me.DSIf8
        ArSIDateF(8) = Me.DSIf9
        ArSIDateF(9) = Me.DSIf10

        ArSIDateT(0) = Me.DSIt1
        ArSIDateT(1) = Me.DSIt2
        ArSIDateT(2) = Me.DSIt3
        ArSIDateT(3) = Me.DSIt4
        ArSIDateT(4) = Me.DSIt5
        ArSIDateT(5) = Me.DSIt6
        ArSIDateT(6) = Me.DSIt7
        ArSIDateT(7) = Me.DSIt8
        ArSIDateT(8) = Me.DSIt9
        ArSIDateT(9) = Me.DSIt10

        ArUPDateF(0) = Me.DUPf1
        ArUPDateF(1) = Me.DUPf2
        ArUPDateF(2) = Me.DUPf3
        ArUPDateF(3) = Me.DUPf4
        ArUPDateF(4) = Me.DUPf5
        ArUPDateF(5) = Me.DUPf6
        ArUPDateF(6) = Me.DUPf7
        ArUPDateF(7) = Me.DUPf8
        ArUPDateF(8) = Me.DUPf9
        ArUPDateF(9) = Me.DUPf10


        ArUPDateT(0) = Me.DUPt1
        ArUPDateT(1) = Me.DUPt2
        ArUPDateT(2) = Me.DUPt3
        ArUPDateT(3) = Me.DUPt4
        ArUPDateT(4) = Me.DUPt5
        ArUPDateT(5) = Me.DUPt6
        ArUPDateT(6) = Me.DUPt7
        ArUPDateT(7) = Me.DUPt8
        ArUPDateT(8) = Me.DUPt9
        ArUPDateT(9) = Me.DUPt10
        


    End Sub
    Private Sub PutDecimalValidationOnTxts()
        Dim i As Integer
        For i = 0 To 9
            AddHandler ArAL(i).KeyPress, AddressOf NumericKeyPress
            AddHandler ArAL(i).Leave, AddressOf NumericOnLeave
            ArAL(i).Text = "0.00"


            AddHandler ArSI(i).KeyPress, AddressOf NumericKeyPress
            AddHandler ArSI(i).Leave, AddressOf NumericOnLeave
            ArSI(i).Text = "0.00"


            AddHandler ArUP(i).KeyPress, AddressOf NumericKeyPress
            AddHandler ArUP(i).Leave, AddressOf NumericOnLeave
            ArUP(i).Text = "0.00"

            ArALDateF(i).Value = DefFdate
            ArALDateT(i).Value = Deftdate
            ArSIDateF(i).Value = DefFdate
            ArSIDateT(i).Value = Deftdate
            ArUPDateF(i).Value = DefFdate
            ArUPDateT(i).Value = Deftdate


        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Exx As New Exception
        If Global1.Business.SearchForAnnualLeaveOfHeaderId(Header.Id) Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("There are already Annual Leave Transactions for this Payslip, Continue with Saving ?", MsgBoxStyle.YesNoCancel)
            If Ans <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        If ValidateMe() Then


            Try

                Dim Saved As Boolean = False
                Dim i As Integer = 0

                For i = 0 To 9
                    If Me.ArAL(i).Text <> 0 Then
                        Dim AL As New cPrTxEmployeeLeave
                        With AL
                            .Id = 0
                            .EmpCode = GLBEmpCode
                            .Status = "Approved"
                            .Type = "1"
                            .ReqDate = Now.Date
                            .ProcDate = Now.Date
                            .FromDate = Me.ArALDateF(i).Value.Date
                            .ToDate = Me.ArALDateT(i).Value.Date
                            .ProcBy = Global1.GLBUserId
                            .Units = ArAL(i).Text
                            .Action = AN_DecreaseCODE
                            .HdrId = Header.Id
                            If Not .Save() Then
                                Throw Exx
                            End If
                            Saved = True
                        End With

                    End If
                Next
                For i = 0 To 9
                    If Me.ArSI(i).Text <> 0 Then
                        Dim SI As New cPrTxEmployeeLeave
                        With SI
                            .Id = 0
                            .EmpCode = GLBEmpCode
                            .Status = "Approved"
                            .Type = "3"
                            .ReqDate = Now.Date
                            .ProcDate = Now.Date
                            .FromDate = Me.ArSIDateF(i).Value.Date
                            .ToDate = Me.ArSIDateT(i).Value.Date
                            .ProcBy = Global1.GLBUserId
                            .Units = ArSI(i).Text
                            .Action = AN_DecreaseCODE
                            .HdrId = Header.Id
                            If Not .Save() Then
                                Throw Exx
                            End If
                            Saved = True
                        End With

                    End If
                Next
                For i = 0 To 9
                    If Me.ArUP(i).Text <> 0 Then
                        Dim UP As New cPrTxEmployeeLeave
                        With UP
                            .Id = 0
                            .EmpCode = GLBEmpCode
                            .Status = "Approved"
                            .Type = "6"
                            .ReqDate = Now.Date
                            .ProcDate = Now.Date
                            .FromDate = Me.ArUPDateF(i).Value.Date
                            .ToDate = Me.ArUPDateT(i).Value.Date
                            .ProcBy = Global1.GLBUserId
                            .Units = ArUP(i).Text
                            .Action = AN_DecreaseCODE
                            .HdrId = Header.Id
                            If Not .Save() Then
                                Throw Exx
                            End If
                            Saved = True
                        End With

                    End If
                Next
                If Saved Then
                    MsgBox("Succesfull Save!", MsgBoxStyle.Information)
                End If
                Me.Close()
            Catch ex As Exception
                Show(ex)
                MsgBox("Failed to Save!", MsgBoxStyle.Information)
            End Try
        End If

    End Sub
    Private Function ValidateMe() As Boolean
        Dim F As Boolean = False
        Dim i As Integer = 0
        Dim TotalUnits As Double
        For i = 0 To 9
            If Me.ArAL(i).Text <> 0 Then
                TotalUnits = TotalUnits + ArAL(i).Text
            End If
            If Me.ArSI(i).Text <> 0 Then
                TotalUnits = TotalUnits + ArSI(i).Text
            End If
            If Me.ArUP(i).Text <> 0 Then
                TotalUnits = TotalUnits + ArUP(i).Text
            End If
        Next
        TotalUnits = RoundMe2(TotalUnits, 2)
        If TotalUnits = Diff Then
            F = True
        Else
            Dim Ans As MsgBoxResult
            Ans = MsgBox("Total Difference (" & Diff & ") is different than the Leave Units Entered (" & TotalUnits & "), Proceed ?", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                F = True
            End If
        End If
        Return F
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("With this Action any related Annual Leave Transactions with this Payslip - Payslip ID = " & Header.Id & " will be deleted, Proceed", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then
            If Global1.Business.SearchForAnnualLeaveOfHeaderId(Header.Id) Then
                If Global1.Business.DeleteAllAnnualLeaveOfHeaderID(Header.Id) Then
                    MsgBox("Sucessfull Deletion", MsgBoxStyle.Information)
                Else
                    MsgBox("Unsucessfull Deletion", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("There are no related Annual Leave Transactions with this Payslip - Payslip ID = " & Header.Id)
            End If

        End If

    End Sub
End Class