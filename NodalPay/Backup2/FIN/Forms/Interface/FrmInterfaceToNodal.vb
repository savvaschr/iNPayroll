Imports System.IO
Public Class FrmInterfaceToNodal

#Region "Delarations"

    '  Private ServerName As String = "Nodalsoft"
    ' Private DatabaseName As String = "Nodal"
    Private FullFilePath As String = System.Windows.Forms.Application.LocalUserAppDataPath & "\Out.txt"
    Private CreatedLines As Integer
    Dim DsHistory As DataSet
#End Region

#Region "StartUp"
    

#End Region

   
    Private Sub FrmInterfaceToNodal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadGrid()
        FindIds()
    End Sub
    Private Sub LoadGriD()
        DsHistory = Global1.Business.GetInterfaceToNodalHistory
        DG1.DataSource = DsHistory.Tables(0)
    End Sub

    Private Sub FindIds()
        Me.txtIdTo.Text = CStr(GetMaxId())
        Me.txtIdFrom.Text = CStr(GetLastId())
    End Sub

    Private Sub ExtractLines(ByVal MyIdFrom As Integer, ByVal MyIdTo As Integer, ByVal IntFile As cAaSsInterfaceToNodal)
        Dim ds As DataSet
        Dim l As New ArrayList
        Dim writer As StreamWriter
        Dim RecordCounter As Integer
        ds = Global1.Business.GetAllFiTxAccountLinesFromID(MyIdFrom, MyIdTo)
        If CheckDataSet(ds) Then
            writer = File.CreateText(FullFilePath)
            l.Add("VERSION                         42001")
            For RecordCounter = 0 To ds.Tables(0).Rows.Count - 1
                System.Windows.Forms.Application.DoEvents()
                l.Add(OutputRowBuilder(ds.Tables(0).Rows(RecordCounter)))
            Next RecordCounter
            WriteLines(l, writer)
            writer.Close()
            With IntFile
                If .Id > 0 Then
                    .CreationTimes = .CreationTimes + 1
                    .UpdateDate = Now
                    .UpdatedBy = Global1.GLBUserId
                Else
                    .FromID = MyIdFrom
                    .ToID = MyIdTo
                    .CreationTimes = 1
                    .CreationDate = Now
                    .CreatedBy = Global1.GLBUserId
                    .UpdateDate = Now
                    .UpdatedBy = Global1.GLBUserId
                End If
                If Not .Save Then
                    MsgBox("Error with Saving Interface File Batch, Please Cpntact Nodal Localsoft!", MsgBoxStyle.Critical)
                End If
            End With
            Dim Str As String
            Str = "File is Succesfully Created!" & Chr(13) & "Extracted " & RecordCounter & " Records into " & FullFilePath
            MsgBox(Str, MsgBoxStyle.Information)
            FindIds()
            LoadGriD()
        End If
    End Sub
    Private Function OutputRowBuilder(ByVal dr As DataRow) As String
        Dim Str As String = ""
        Str = Str & PadRight(dr.Item(10).ToString, " ", 15)  ' example Field 1 Account 15 chars
        Str = Str & PadPeriod(dr.Item(9).ToString)
        Str = Str & SunDate(CDate(dr.Item(6)))
        Str = Str & "  L00            "
        Str = Str & PadSunAmount(CDbl(dr.Item(13)))
        Str = Str & CStr(dr.Item(12))
        Str = Str & " "
        Str = Str & CStr(dr.Item(1)).Substring(0, 5)
        Str = Str & "     "
        Str = Str & PadRight(CStr(dr.Item(4)), " ", 20).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(5)), " ", 30).Substring(0, 25)
        Str = Str & SunDate(CDate(dr.Item(38)))
        Str = Str & PadPeriod(SunDate(CDate(dr.Item(38))).Substring(0, 7))
        Str = Str & "00000000      000000000000000000000000                "
        Str = Str & CStr(dr.Item(14))
        Str = Str & "  "
        Str = Str & PadSunCurrRate(CDbl(dr.Item(16)))
        Str = Str & PadSunAmount(CDbl(dr.Item(15)))
        Str = Str & "              "
        Str = Str & PadRight(CStr(dr.Item(27)), " ", 20, True).Substring(0, 15)  ' T10 is T0 in Sun
        Str = Str & PadRight(CStr(dr.Item(18)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(19)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(20)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(21)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(22)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(23)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(24)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(25)), " ", 20, True).Substring(0, 15)
        Str = Str & PadRight(CStr(dr.Item(26)), " ", 20, True).Substring(0, 15)
        Return Str
    End Function
    Private Function PadSunAmount(ByVal Amt As Double) As String
        Dim Str As String
        Str = PadLeft(CStr(Amt * 1000), "0", 18)
        Return Str
    End Function
    Private Function PadSunCurrRate(ByVal Amt As Double) As String
        Dim Str As String
        Str = PadLeft(CStr(Amt * 1000000000), "0", 18)
        Return Str
    End Function
    Private Function SunDate(ByVal d As Date) As String
        Dim Str As String = ""
        Str = Str & CStr(Year(d))
        If Month(d) > 9 Then
            Str = Str & CStr(Month(d))
        Else
            Str = Str & "0" & CStr(Month(d))
        End If
        If DatePart(DateInterval.Day, d) > 9 Then
            Str = Str & CStr(DatePart(DateInterval.Day, d))
        Else
            Str = Str & "0" & CStr(DatePart(DateInterval.Day, d))
        End If
        Return Str
    End Function

    Private Function PadPeriod(ByVal OldPeriod As String) As String
        Return OldPeriod.Substring(0, 4) & "0" & OldPeriod.Substring(4, 2)
    End Function
    Private Function PadRight(ByVal Str As String, ByVal Pad As String, ByVal Length As Integer, Optional ByVal NoDollar As Boolean = False) As String
        If NoDollar = True And Str.Substring(0, 1) = "$" Then
            Return StrDup(Length, Pad)
        Else
            Return Str & StrDup(Length - Len(Str), Pad)
        End If
    End Function
    Private Function PadLeft(ByVal Str As String, ByVal Pad As String, ByVal Length As Integer) As String
        Return StrDup(Length - Len(Str), Pad) & Str
    End Function
    Private Sub btnExtract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        Cursor = Cursors.WaitCursor

        Dim IdFrom As Integer
        Dim IdTo As Integer

        Try
            Dim IntFile As New cAaSsInterfaceToNodal
            IdFrom = CInt(Me.txtIdFrom.Text)
            IdTo = CInt(Me.txtIdTo.Text)
            If IdFrom = IdTo Then
                MsgBox("There are no Transactions to Send", MsgBoxStyle.Information)
                Cursor = Cursors.Default
                Exit Sub
            End If
            Me.LblProgress.Visible = True
            ExtractLines(IdFrom, IdTo, IntFile)
        Catch ex As Exception
            MsgBox("Extract aborted ", MsgBoxStyle.Critical)
            Utils.ShowException(ex)
        End Try
        Cursor = Cursors.Default
        Me.LblProgress.Visible = False
    End Sub
    Private Function GetMaxId() As Long
        Dim MaxId As Long
        Try
            MaxId = Global1.Business.GetFiTxAccountLinesMaxId
        Catch ex As Exception
            MsgBox("Error finding Max Id ", MsgBoxStyle.Critical)
            Utils.ShowException(ex)
        End Try
        Return MaxId
    End Function
    Private Function GetLastId() As Integer
        Dim LastId As Integer = 0
        Try
            LastId = Global1.Business.GetFiTxAccountLinesLastIdSend
        Catch ex As Exception
            MsgBox("Error finding Last ID ", MsgBoxStyle.Critical)
            Utils.ShowException(ex)
        End Try
        Return LastId
    End Function
    Private Sub WriteLines(ByRef L As ArrayList, ByRef Writer As StreamWriter)
        Dim Acounter As Integer
        For Acounter = 0 To L.Count - 1
            CreatedLines = CreatedLines + 1
            If L(Acounter).ToString <> "" Then Writer.WriteLine(L(Acounter).ToString)
        Next Acounter
        L.Clear()
    End Sub

    Private Sub BtnRegenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegenerate.Click
        Cursor = Cursors.WaitCursor
        Me.LblProgress.Visible = True
        System.Windows.Forms.Application.DoEvents()
        If CheckDataSet(DsHistory) Then
            Dim id As Integer
            id = DbNullToInt(DsHistory.Tables(0).Rows(DG1.CurrentRow.Index).Item(0))
            Dim IntFile As New cAaSsInterfaceToNodal(id)
            If IntFile.Id > 0 Then
                Me.ExtractLines(IntFile.FromID, IntFile.ToID, IntFile)
            Else
                MsgBox("Cannot Regenerate Interface File", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("There is No History ofInterface File Generations", MsgBoxStyle.Critical)
        End If
        Cursor = Cursors.Default
        Me.LblProgress.Visible = False
    End Sub
End Class