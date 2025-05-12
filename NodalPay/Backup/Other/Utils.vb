'********************************************************
'************* Comment Out SHOW REPORT ******************
'********************************************************
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Text


Imports System.Security.Cryptography
Module Utils
    Private strDecimalSeparator As String = "." 'Left(Right(CStr(1200.23), 3), 1)
    Public Function ClearCharacters(ByVal S As String) As String
        S = UCase(S).Replace("A", "")
        S = UCase(S).Replace("B", "")
        S = UCase(S).Replace("C", "")
        S = UCase(S).Replace("D", "")
        S = UCase(S).Replace("E", "")
        S = UCase(S).Replace("F", "")
        S = UCase(S).Replace("G", "")
        S = UCase(S).Replace("H", "")
        S = UCase(S).Replace("I", "")
        S = UCase(S).Replace("J", "")
        S = UCase(S).Replace("K", "")
        S = UCase(S).Replace("L", "")
        S = UCase(S).Replace("M", "")
        S = UCase(S).Replace("N", "")
        S = UCase(S).Replace("O", "")
        S = UCase(S).Replace("P", "")
        S = UCase(S).Replace("Q", "")
        S = UCase(S).Replace("R", "")
        S = UCase(S).Replace("S", "")
        S = UCase(S).Replace("T", "")
        S = UCase(S).Replace("U", "")
        S = UCase(S).Replace("V", "")
        S = UCase(S).Replace("X", "")
        S = UCase(S).Replace("Y", "")
        S = UCase(S).Replace("W", "")
        S = UCase(S).Replace("Z", "")

        Return S
    End Function
    Public Function SimpleCrypt( _
       ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using 
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String, i As Integer
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = _
                Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function
    Public Function SavvasCrypt( _
       ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using 
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String, i As Integer
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = _
                Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function
    



    Public Function AddCommaToThousands(ByVal S As String) As String
        Dim RetVal As Double
        Dim RetValS As String
        If S = "" Then
            RetVal = 0
        Else
            If IsNumeric(S) Then
                RetVal = CDbl(S)
            Else
                RetVal = 0
            End If
        End If
        If RetVal >= 1000 Then
            RetValS = Format(RetVal, ("0,000.00"))
        Else
            RetValS = Format(RetVal, ("0.00"))
        End If

        Return RetValS
    End Function

    Public Sub EncryptPdf(ByVal sInFilePath As String, ByVal sOutFilePath As String, ByVal sPassword As String)

        Dim oPdfReader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(sInFilePath)
        Dim oPdfDoc As New iTextSharp.text.Document()
        Dim oPdfWriter As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))
        oPdfWriter.SetEncryption(iTextSharp.text.pdf.PdfWriter.STRENGTH40BITS, sPassword, sPassword, iTextSharp.text.pdf.PdfWriter.AllowCopy)
        oPdfDoc.Open()

        oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LEDGER.Rotate())

        Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
        Dim iNumberOfPages As Integer = oPdfReader.NumberOfPages
        Dim iPage As Integer = 0

        Do While (iPage < iNumberOfPages)
            iPage += 1
            oPdfDoc.SetPageSize(oPdfReader.GetPageSizeWithRotation(iPage))
            oPdfDoc.NewPage()

            Dim oPdfImportedPage As iTextSharp.text.pdf.PdfImportedPage = oPdfWriter.GetImportedPage(oPdfReader, iPage)
            Dim iRotation As Integer = oPdfReader.GetPageRotation(iPage)
            If (iRotation = 90) Or (iRotation = 270) Then
                oDirectContent.AddTemplate(oPdfImportedPage, 0, -1.0F, 1.0F, 0, 0, oPdfReader.GetPageSizeWithRotation(iPage).Height)
            Else
                oDirectContent.AddTemplate(oPdfImportedPage, 1.0F, 0, 0, 1.0F, 0, 0)
            End If
        Loop


        oPdfDoc.Close()
        oPdfDoc.Dispose()
        oPdfReader.Close()
        oPdfReader.Dispose()

        GC.Collect()
        GC.Collect()

    End Sub
    Public Function ChangeMaskedFields(ByVal T As MaskedTextBox) As Date
        Dim s As String
        Dim Ar() As String
        Dim dd As String
        Dim MM As String
        Dim yyyy As String
        Dim D As Date
        s = T.Text
        Ar = s.Split("/")
        dd = Ar(0)
        MM = Ar(1)
        yyyy = Ar(2)
        s = MM & "/" & dd & "/" & yyyy
        D = CDate(s)

        Return D
    End Function
    Public Function FindWorkingdays_FromDateToTheEndOfMonth(ByVal StartDate As Date)
        Dim CM As Integer = 0
        Dim NM As Integer = 0
        Dim i As Integer = 0
        Dim C As Integer = 0


        CM = StartDate.Month
        For i = 0 To 35
            If StartDate.DayOfWeek <> DayOfWeek.Saturday And StartDate.DayOfWeek <> DayOfWeek.Sunday Then
                C = C + 1
            End If
            StartDate = DateAdd(DateInterval.Day, 1, StartDate)
            NM = StartDate.Month
            If CM <> NM Then
                Exit For
            End If


        Next
        Return C
    End Function
    Public Function FindWorkingdays_FromDateToDate(ByVal StartDate As Date, ByVal EndDate As Date)
        Dim CM As Integer
        Dim NM As Integer
        Dim i As Integer
        Dim C As Integer


        CM = StartDate.Month
        For i = 0 To 35
            If StartDate.DayOfWeek <> DayOfWeek.Saturday And StartDate.DayOfWeek <> DayOfWeek.Sunday Then
                C = C + 1
            End If
            StartDate = DateAdd(DateInterval.Day, 1, StartDate)
            If StartDate = EndDate Then
                If StartDate.DayOfWeek <> DayOfWeek.Saturday And StartDate.DayOfWeek <> DayOfWeek.Sunday Then
                    C = C + 1
                End If
                Exit For
            End If
        Next
        Return C
    End Function

    'Public Sub ShowReport(ByVal ReportName As String, ByVal ds As DataSet, ByVal ParentForm As Form, ByVal ReportCaption As String, ByVal SendToPrinterDirectly As Boolean, Optional ByVal PrinterName As String = "", Optional ByVal Parent_AS_Owner As Boolean = False)
    '    Dim StrMsg As String = " ** Unable to Print ** "
    '    Dim Flag As Boolean = False
    '    Try
    '        Dim r As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        Dim FileName As String

    '        'All the reports are expected to be located in
    '        'in a subdir called \Reports within the
    '        'current working directory
    '        'FileName = Application.StartupPath & "\Reports\" & ReportName
    '        FileName = Application.StartupPath & "\Reports\" & ReportName
    '        'Filename = application.

    '        r.Load(FileName)
    '        Flag = True
    '        If PrinterName <> "" Then
    '            'Make sure the specified printer is valid
    '            'IsValidPrinter: Sets PrinterName to the default printer
    '            'if the specified printername is not a valid printer
    '            If IsValidPrinter(PrinterName) Then
    '                r.PrintOptions.PrinterName = PrinterName
    '            End If
    '        End If
    '        r.SetDataSource(ds)
    '        '  ShowTable(ds.Tables(0))
    '        '  ShowTable(ds.Tables(1))
    '        'ds.Dispose()


    '        If SendToPrinterDirectly Then
    '            r.PrintToPrinter(1, False, 0, 0)
    '        Else

    '            Dim CrystalForm As New FrmReport
    '            '' If Parent_AS_Owner Then
    '            ''Else
    '            ''   CrystalForm.MdiParent = ParentForm
    '            ''End If
    '            CrystalForm.Owner = ParentForm
    '            CrystalForm.Text = "Report: " & ReportCaption
    '            CrystalForm.CrystalReportViewer1.Text = ReportCaption
    '            CrystalForm.CrystalReportViewer1.ReportSource = r

    '            CrystalForm.ShowDialog()

    '            'CrystalForm.Top = ParentForm.Top

    '            ' CrystalForm.BringToFront()

    '        End If
    '    Catch err As Exception
    '        If Flag Then
    '            ShowException(err, StrMsg)
    '        Else
    '            ShowException(err)
    '        End If

    '    End Try
    'End Sub
    Public Sub ShowReport(ByVal ReportName As String, ByVal ds As DataSet, ByVal ParentForm As Form, ByVal ReportCaption As String, ByVal SendToPrinterDirectly As Boolean, Optional ByVal PrinterName As String = "", Optional ByVal Parent_AS_Owner As Boolean = False, Optional ByVal SendTofile As Boolean = False, Optional ByVal ExportFileName As String = "", Optional ByVal Landscape As Boolean = False, Optional ByVal TypeOfExport As Integer = 0)
        Dim StrMsg As String = " ** Unable to Print ** "
        Dim Flag As Boolean = False
        Try
            Dim r As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim FileName As String

            'All the reports are expected to be located in
            'in a subdir called \Reports within the
            'current working directory
            'FileName = Application.StartupPath & "\Reports\" & ReportName
            FileName = Application.StartupPath & "\Reports\" & ReportName
            'Filename = application.

            r.Load(FileName)
            If Landscape Then
                r.PrintOptions.PaperOrientation = PaperOrientation.Landscape
            End If

            Flag = True
            If PrinterName <> "" Then
                'Make sure the specified printer is valid
                'IsValidPrinter: Sets PrinterName to the default printer
                'if the specified printername is not a valid printer
                If IsValidPrinter(PrinterName) Then
                    r.PrintOptions.PrinterName = PrinterName
                Else
                    MsgBox("Printer " & PrinterName & " is not Valid", MsgBoxStyle.Information)

                End If
            End If
            r.SetDataSource(ds)

            '  ShowTable(ds.Tables(0))
            '  ShowTable(ds.Tables(1))
            'ds.Dispose()


            If SendToPrinterDirectly Then
                r.PrintToPrinter(1, False, 0, 0)
                r.Close()
                r.Dispose()
                GC.Collect()

            ElseIf SendTofile Then
                If TypeOfExport = 0 Then
                    r.ExportToDisk(ExportFormatType.PortableDocFormat, ExportFileName)
                    r.Close()
                    r.Dispose()
                    GC.Collect()
                    r.Dispose()
                    GC.Collect()
                ElseIf TypeOfExport = 1 Then
                    r.ExportToDisk(ExportFormatType.WordForWindows, ExportFileName)
                    r.Close()
                    r.Dispose()
                    GC.Collect()
                ElseIf TypeOfExport = 2 Then
                    r.ExportToDisk(ExportFormatType.Excel, ExportFileName)
                    r.Close()
                    r.Dispose()
                    GC.Collect()
                End If
                'r.ExportToDisk(ExportFormatType.WordForWindows, ExportFileName)
                'r.ExportToDisk(ExportFormatType.PortableDocFormat, ExportFileName)
                'r.ExportToDisk(ExportFormatType.RichText, ExportFileName & ".rtf")
                'r.ExportToDisk(ExportFormatType.Excel, ExportFileName & ".xls")
            Else


                Dim CrystalForm As New FrmReport
                '' If Parent_AS_Owner Then
                ''Else
                ''   CrystalForm.MdiParent = ParentForm
                ''End If
                CrystalForm.Owner = ParentForm
                CrystalForm.Text = "Report: " & ReportCaption
                CrystalForm.CrystalReportViewer1.Text = ReportCaption
                CrystalForm.CrystalReportViewer1.ReportSource = r


                CrystalForm.ShowDialog()
                r.Close()
                r.Dispose()
                GC.Collect()
                'CrystalForm.Top = ParentForm.Top

                ' CrystalForm.BringToFront()

            End If
        Catch err As Exception
            If Flag Then
                ShowException(err, StrMsg)
            Else
                ShowException(err)
            End If

        End Try
        GC.Collect()
    End Sub

#Region "ShowTables And DataSets"
    Public Function GetDateAndTime(ByVal Date1 As Date) As String
        Dim S As String
        S = Date1.Year & "-" & Date1.Month.ToString.PadLeft(2, "0") & "-" & Date1.Day.ToString.PadLeft(2, "0") & " " & Date1.Hour.ToString.PadLeft(2, "0") & ":" & Date1.Minute.ToString.PadLeft(2, "0")
        Return S
    End Function
    Public Function FixNumber(ByVal N As Double, ByVal L As Integer) As String
        Dim str As String
        If N >= 0 Then
            str = CStr(Format(N, "0.00")).Replace(".", "").PadLeft(L, "0")
        Else
            str = CStr(Format(Math.Abs(N), "0.00")).Replace(".", "").PadLeft(L - 1, "0")
            str = "-" & str
        End If
        Return str
    End Function
    Public Function FixInteger(ByVal N As Integer, ByVal L As Integer) As String
        Dim str As String
        If N >= 0 Then
            str = CStr(Math.Abs(N)).PadLeft(L, "0")
        Else
            str = CStr(Math.Abs(N)).PadLeft(L - 1, "0")
            str = "-" & str
        End If
        Return str
    End Function
    Public Sub ShowTable(ByVal t As DataTable)
        Dim i As Integer
        Dim s As String = ""

        For i = 0 To t.Columns.Count - 1
            s += "[" + t.Columns(i).ColumnName + ": " & t.Columns(i).DataType.ToString & "]"
        Next
        If s <> "" Then
            'Debug.WriteLine("Columns: " + s)
            s = ""
        End If


        For i = 0 To t.Constraints.Count - 1
            s += t.Constraints(i).ConstraintName
        Next
        If s <> "" Then
            '  Debug.WriteLine("Constraints: " + s)
            s = ""
        End If

        Dim j As Integer
        For i = 0 To t.Rows.Count - 1
            For j = 0 To t.Columns.Count - 1
                s &= t.Rows(i).Item(j).ToString & "|"
            Next
            '  Debug.WriteLine(s)
            s = ""
        Next i

    End Sub

    Public Sub ShowDataSet(ByVal ds As DataSet)
        Dim i As Integer

        If Not ds Is Nothing Then
            'Debug.WriteLine("DataSet Contains " & ds.Tables.Count.ToString & " tables.")
            For i = 0 To ds.Tables.Count - 1
                ShowTable(ds.Tables(i))
            Next
        Else
            'Debug.WriteLine("Dataset is NOTHING")
        End If
    End Sub

    Public Sub ShowArrayList(ByVal al As ArrayList)
        Dim i As Integer
        For i = 0 To al.Count
            'Debug.WriteLine(al.Item(i).ToString())
        Next
    End Sub
#End Region

#Region "NullTo<Type> Functions"


#End Region
#Region "StringToDateforDB"
    Public Function StrToDateForDB(ByVal str As String) As Date
        Dim DateArr() As String
        Dim strDate As String
        DateArr = str.Split("/")
        If CStr(DateArr(2)) < 1900 Then
            DateArr(2) = 1900
        End If
        strDate = DateArr(1) & "/" & DateArr(0) & "/" & DateArr(2)
        Return (CDate(strDate))

    End Function

#End Region
#Region "DBNull Functions"

    Public Function IsNULLDate(ByVal thisDate As Date) As Boolean
        Dim NULLDate As Date

        Return (NULLDate = thisDate)
    End Function

    Public Function DbNullToDate(ByVal o As Object) As Date
        If IsDBNull(o) Then
            Return Nothing
        Else
            Return CDate(o)
        End If
    End Function

    Public Function DbNullToDateTime(ByVal o As Object) As DateTime
        If IsDBNull(o) Then
            Return Nothing
        Else
            Return CDate(o)
        End If
    End Function

    Public Function DbNullToDouble(ByVal o As Object) As Double
        If IsDBNull(o) Then
            Return 0
        Else
            Return CDbl(o)
        End If
    End Function
    Public Function DbNullToDecimal(ByVal o As Object) As Decimal
        If IsDBNull(o) Then
            Return 0
        Else
            Return CDec(o)
        End If
    End Function

    Public Function DbNullToInt16(ByVal o As Object) As Int16
        If IsDBNull(o) Then
            Return 0
        Else
            Return CShort(o)
        End If
    End Function


    Public Function DbNullToInt(ByVal o As Object) As Integer
        If IsDBNull(o) Then
            Return 0
        Else
            Return CType(o, Integer)
        End If
    End Function
    Public Function DbNullToLong(ByVal o As Object) As Long
        If IsDBNull(o) Then
            Return 0
        Else
            Return CType(o, Long)
        End If
    End Function
    Public Function DbNullToString(ByVal o As Object, Optional ByVal TrimResult As Boolean = True) As String
        If IsDBNull(o) Then
            Return ""
        Else
            If TrimResult Then
                Return CStr(o).Trim
            Else
                Return CStr(o)
            End If
        End If
    End Function
    Public Function NullToString(ByVal o As Object, Optional ByVal TrimResult As Boolean = True) As String
        If IsNothing(o) Then
            Return ""
        Else
            If TrimResult Then
                Return CStr(o).Trim
            Else
                Return CStr(o)
            End If
        End If
    End Function

    Public Function DbNullToChar(ByVal o As Object) As Char
        If IsDBNull(o) Then
            Return " "c
        Else
            Return CChar(o)
        End If
    End Function

    Public Function DbNullToBool(ByVal o As Object, ByVal DefaultValue As Boolean) As Boolean
        If IsDBNull(o) Then
            Return DefaultValue
        Else
            If CStr(o) = "Y" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function NothingToEmpty(ByVal Str As String) As String
        If Str Is Nothing Then
            Str = ""
        End If
        Return Str
    End Function

    Public Function StringToNonZeroDouble(ByVal s As String) As Double
        Try
            Dim i As Double
            i = CType(s, Double)
            Return i
        Catch e As System.Exception
            Return 0
        End Try
    End Function

    Public Function StringToNonZeroInt(ByVal s As String) As Integer
        Try
            Dim i As Integer
            i = CType(s, Int32)
            Return i
        Catch e As System.Exception
            Return 0
        End Try
    End Function
    Public Function DbNullYesNoToTristate(ByVal o As Object) As TriState
        Try
            If IsDBNull(o) Then
                Return TriState.UseDefault
            Else
                If CStr(o) = "Y" Then
                    Return TriState.True
                Else
                    Return TriState.False
                End If
            End If
        Catch e As System.Exception
            Return TriState.UseDefault
        End Try
    End Function
    Public Function StringToDoublewith2lastdigitsDecimals(ByVal S As String) As Double
        Dim Final As String
        Dim FinalNo As Double
        If S Is Nothing Then
            FinalNo = 0
        Else
            If S.Substring(0, 1) = " " Or S.Substring(0, 1) = "+" Then
                Final = S.Substring(1, S.Length - 1)
                FinalNo = CDbl(Final) / 100
            ElseIf S.Substring(0, 1) = "-" Then
                Final = S.Substring(1, S.Length - 1)
                FinalNo = CDbl(Final) / 100
                FinalNo = -1 * FinalNo
            Else
                FinalNo = CDbl(S) / 100
            End If
        End If
        Return FinalNo

    End Function

    Public Function IntToNULL(ByVal thisINT As Integer) As String
        If thisINT = 0 Then
            Return "NULL"
        Else
            Return thisINT.ToString
        End If
    End Function

    Public Function StringToNULL(ByVal s As String) As String
        If s Is Nothing Then
            Return "NULL"
        ElseIf s.Trim = "" Then
            Return "NULL"
        ElseIf s.CompareTo(Nothing) = 0 Then
            Return "NULL"
        ElseIf s.CompareTo("") = 0 Then
            Return "NULL"
        Else
            Return enQuoteString(SingleQuotes(s))
        End If
    End Function

    Public Function CharToNULL(ByVal c As Char) As String
        Dim S As String
        S = CStr(c)

        If S.CompareTo("") = 0 Then
            Return "NULL"
        ElseIf S.CompareTo(Nothing) = 0 Then
            Return ("NULL")
        Else
            Return enQuoteString(SingleQuotes(c))
        End If
    End Function
    ' Private Sub LoadDataToExcel(ByVal DatagridView1 As DataGridView)
    '    Dim ds1 As DataSet
    '    ds1 = New DataSet
    '    Dim da1 As SqlDataAdapter
    '    Dim str1 As String
    '    Dim n, i, j, c, k As Integer
    '    Dim wapp As Excel.Application
    '    Dim wsheet As Excel.Worksheet
    '    Dim wbook As Excel.Workbook
    '    wapp = New Excel.Application
    '    wbook = wapp.Workbooks.Add()
    '    wsheet = wapp.Sheets(1)
    '    Dim adtable As DataTable = New DataTable
    '    str1 = "select * from materialsdetails"
    '    Dim show As DataTable = ds1.Tables.Add("show")




    '    n = adtable.Rows.Count
    '    c = adtable.Columns.Count
    '    i = 0
    '    While i <= n - 1
    '        If i = 0 Then
    '            For k = 0 To c - 1
    '                'k = 0    
    '                wsheet.Cells(1, k + 1).Value = DatagridView1.Columns(k).Name
    '            Next
    '        End If
    '        j = i + 1
    '        k = 0
    '        While k <= c - 1
    '            wsheet.Cells(j + 1, k + 1).Value = DatagridView1.Rows(j).Cells(k).Value
    '            '(k).Name.         
    '            k = k + 1
    '        End While
    '        i = i + 1
    '    End While
    '    wsheet.SaveAs("c:\'" & txt_xlsfilename.Text & " '")
    '    wapp.Workbooks.Close()
    'End Sub
#End Region

#Region "ListViewSorting"



#End Region

#Region "Numeric Validations"
    Friend Sub IntegerOnLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                myTextBox.Text = FormatNumber(myText, 0, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub

    Friend Sub IntegerKeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Does not allow DOT
        'Debug.WriteLine(Asc(e.KeyChar))
        Dim c As Integer = Asc(e.KeyChar)

        If Not ((c >= 48 And c <= 57) Or c = 8) Then
            e.Handled = True
        Else
            If c = 46 Then  'HANDLING THE "."
                If InStr(CType(Sender, TextBox).Text, ".", CompareMethod.Text) > 0 Then
                    e.Handled = True
                End If
            ElseIf c <> 8 Then

            End If
        End If
    End Sub

    Friend Sub NumericKeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Debug.WriteLine(Asc(e.KeyChar))
        Dim c As Integer = Asc(e.KeyChar)
        'Console.WriteLine("Sender=" & Sender.ToString)
        'Console.WriteLine("Text=" & CType(Sender, TextBox).Text)

        If Not ((c >= 48 And c <= 57) Or c = 8 Or c = 46) Then
            e.Handled = True
        Else
            If c = 46 Then  'HANDLING THE "."
                If InStr(CType(Sender, TextBox).Text, ".", CompareMethod.Text) > 0 Then
                    e.Handled = True
                End If
            ElseIf c <> 8 Then

            End If
        End If
    End Sub
    Friend Sub NumericKeyPressWithNegative(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Debug.WriteLine(Asc(e.KeyChar))
        Dim c As Integer = Asc(e.KeyChar)
        'Console.WriteLine("Sender=" & Sender.ToString)
        'Console.WriteLine("Text=" & CType(Sender, TextBox).Text)

        If Not ((c >= 48 And c <= 57) Or c = 8 Or c = 46 Or c = 45) Then
            e.Handled = True
        Else
            If c = 46 Then  'HANDLING THE "."
                If InStr(CType(Sender, TextBox).Text, ".", CompareMethod.Text) > 0 Then
                    e.Handled = True
                End If
            ElseIf c <> 8 Then

            End If
        End If
    End Sub

    Friend Sub NumericOnLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.00"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                'Debug.WriteLine("Rounding....")
                myTextBox.Text = FormatNumber(myText, 2, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub
    Friend Sub NumericOnLeaveWithNegative(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.00"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                'Debug.WriteLine("Rounding....")
                myTextBox.Text = FormatNumber(myText, 2, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub
    Friend Sub NumericOnLeaveWithEmpty(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = ""
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                'Debug.WriteLine("Rounding....")
                myTextBox.Text = FormatNumber(myText, 2, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub
    Friend Sub NumericOnLeavePercent(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.00"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                If myText < 0 Or myText > 100 Then
                    MsgBox("Only Values greater than 0 and less than 100")
                    myTextBox.Focus()
                Else
                    'Debug.WriteLine("Rounding....")
                    myTextBox.Text = FormatNumber(myText, 2, TriState.True, TriState.False, TriState.False)
                End If
            End If
        End If
    End Sub
    Friend Sub NumericOnLeaveRate(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.00"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                If myText < 0 Then
                    MsgBox("Only Values greater than 0")
                    myTextBox.Focus()
                Else
                    'Debug.WriteLine("Rounding....")
                    myTextBox.Text = FormatNumber(myText, 2, TriState.True, TriState.False, TriState.False)
                End If
            End If
        End If
    End Sub
    Friend Sub NumericOnLeave4Decimals(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.0000"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                'Debug.WriteLine("Rounding....")
                myTextBox.Text = FormatNumber(myText, 4, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub

    Friend Sub NumericOnLeave6Decimals(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myText As String
        Dim myTextBox As TextBox

        myTextBox = CType(sender, TextBox)
        myText = myTextBox.Text

        If Trim(myText) = "" Then
            myTextBox.Text = "0.000000"
        Else
            If Not IsNumeric(myText) Then
                MessageBox.Show("Invalid number")
                myTextBox.Focus()
            Else
                'Debug.WriteLine("Rounding....")
                myTextBox.Text = FormatNumber(myText, 6, TriState.True, TriState.False, TriState.False)
            End If
        End If
    End Sub
    Friend Sub NumericMinusKeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Debug.WriteLine(Asc(e.KeyChar))
        Dim c As Integer = Asc(e.KeyChar)
        'Console.WriteLine("Sender=" & Sender.ToString)
        'Console.WriteLine("Text=" & CType(Sender, TextBox).Text)

        If Not ((c >= 48 And c <= 57) Or c = 8 Or c = 46 Or c = 45) Then
            e.Handled = True
        Else
            If c = 46 Then  'HANDLING THE "."
                If InStr(CType(Sender, TextBox).Text, ".", CompareMethod.Text) > 0 Then
                    e.Handled = True
                End If
            ElseIf c <> 8 Then

            End If
        End If
    End Sub


#End Region

#Region "Command Line Arguments"
    Friend Function GetCommandLineArgs() As String()

        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)




        Dim i As Integer
        For i = 0 To args.Length - 1
            Console.WriteLine(args(i))
            If args(0) = "" Then
                args(0) = "/connection=iNsoft;NodPrNOD"
            End If
        Next

        Return args

    End Function



#End Region

#Region "Exception Handling"
    'Public Sub LogToFile(ByVal thisException As System.Exception, Optional ByVal MessageString As String = "")
    '    LogToFile(thisException.ToString, MessageString)
    'End Sub
    'Public Sub LogToFile(ByVal thisExceptionMessage As String, ByVal MessageString As String)

    '    Dim Filename As String
    '    Dim UserName As String
    '    Dim SessionId As Integer
    '    Dim StoreId As Integer
    '    Dim WorkStationId As Integer

    '    Try
    '        UserName = Global.UserName
    '    Catch ex As system.Exception

    '    End Try

    '    Try
    '        SessionId = Global.Business.Session.id
    '    Catch ex As system.Exception

    '    End Try

    '    Try
    '        StoreId = Global.Business.Store.id
    '    Catch ex As system.Exception

    '    End Try

    '    Try
    '        WorkStationId = Global.Business.Store.ThisWorkstation.WorkstationId
    '    Catch ex As system.Exception

    '    End Try


    '    Dim OutputFile As System.io.StreamWriter
    '    Try
    '        Filename = Application.StartupPath & "\POSErrors.Log"

    '        OutputFile = System.IO.File.AppendText(Filename)
    '        OutputFile.WriteLine()
    '        OutputFile.WriteLine()
    '        OutputFile.WriteLine("*************************************")
    '        OutputFile.Write(Format$(Now, "yyyy-MM-dd HH:mm:ss"))
    '        OutputFile.Write(vbTab)
    '        OutputFile.Write("User: " & UserName)
    '        OutputFile.Write(vbTab)
    '        OutputFile.Write("SessionId: " & SessionId)
    '        OutputFile.Write(vbTab)
    '        OutputFile.Write("StoreId: " & StoreId)
    '        OutputFile.Write(vbTab)
    '        OutputFile.Write("WorkStationId: " & WorkStationId)
    '        OutputFile.WriteLine()
    '        OutputFile.WriteLine("-> " & MessageString)
    '        OutputFile.WriteLine("Error: " & thisExceptionMessage)
    '    Catch E As Exception
    '    Finally
    '        Try
    '            OutputFile.Flush()
    '            OutputFile.Close()
    '        Catch ex As system.Exception
    '        End Try
    '    End Try

    '    Try
    '        Dim appLog As New System.Diagnostics.EventLog
    '        appLog.Source = "POS"

    '        appLog.WriteEntry(Now.Now.ToString + vbCrLf + _
    '        "UserName : " + UserName + vbCrLf + _
    '        "Session Id : " + SessionId.ToString + vbCrLf + _
    '        "Store Id : " + StoreId.ToString + vbCrLf + _
    '        "WorkStation Id : " + WorkStationId.ToString + vbCrLf + _
    '        "Error: " + MessageString + vbCrLf + _
    '        thisExceptionMessage, EventLogEntryType.Error)

    '    Catch err As Exception
    '        MsgBox(err.ToString, MsgBoxStyle.Exclamation, "Log error")
    '    End Try
    'End Sub

    'Public Sub ShowException(ByVal e As Exception)
    Public Sub ShowException(ByVal e As System.Exception, Optional ByVal StringMessage As String = "")
        ' LogToFile(e, StringMessage)

        Try
            MsgBox("Message: " + e.Message.ToString + ControlChars.Cr _
            + "Source: " + e.Source.ToString + ControlChars.Cr _
            + "BaseException: " + e.GetBaseException.ToString + ControlChars.Cr.ToString _
            + "ErrorType: " + e.GetType.ToString, MsgBoxStyle.Critical)

        Catch err As System.Exception
            MessageBox.Show(e.Message)
        End Try

    End Sub
#End Region

#Region "Populate Objects"
    Public Sub PopulateListView(ByRef lv As System.Windows.Forms.ListView, ByVal dt As DataTable, Optional ByVal FirstFieldIsKey As Boolean = False, Optional ByVal ShowFirstField As Boolean = True, Optional ByVal DateTimeAsDate As Boolean = False, Optional ByVal InactiveFieldsIndex As Integer = -1)
        Dim rows As Integer
        Dim cols As Integer
        Dim i As Integer
        Dim InactiveItem As Boolean = False


        Try
            Dim IsFieldNumeric(dt.Columns.Count - 1) As Boolean
            Dim IsFieldDateTime(dt.Columns.Count - 1) As Boolean


            For i = 0 To dt.Columns.Count - 1
                'Debug.WriteLine(dt.Columns(i).ColumnName & " " & dt.Columns(i).DataType.ToString)
                If dt.Columns(i).DataType.ToString = "System.Double" Then
                    IsFieldNumeric(i) = True
                Else
                    IsFieldNumeric(i) = False
                End If

                If DateTimeAsDate And dt.Columns(i).DataType.ToString = "System.DateTime" Then
                    IsFieldDateTime(i) = True
                Else
                    IsFieldDateTime(i) = False
                End If
            Next i


            lv.Items.Clear()
            lv.BeginUpdate()

            Dim FirstFieldIndex As Integer
            If ShowFirstField Then
                FirstFieldIndex = 0
            Else
                FirstFieldIndex = 1
            End If

            For rows = 0 To dt.Rows.Count - 1
                'add item
                If IsFieldNumeric(FirstFieldIndex) Then
                    lv.Items.Add(FormatNumber(dt.Rows(rows).Item(FirstFieldIndex).ToString, 2, TriState.True, TriState.False, TriState.True))
                ElseIf IsFieldDateTime(FirstFieldIndex) Then
                    lv.Items.Add(Format$(dt.Rows(rows).Item(FirstFieldIndex).ToString, "yyyy/MM/dd"))
                Else
                    lv.Items.Add(dt.Rows(rows).Item(FirstFieldIndex).ToString.Trim)
                End If

                'store the key in the tag
                If FirstFieldIsKey Then
                    lv.Items(rows).Tag = dt.Rows(rows).Item(0).ToString.Trim
                End If

                'add subitems
                For cols = FirstFieldIndex + 1 To dt.Columns.Count - 1
                    If cols <> InactiveFieldsIndex Then
                        If IsFieldNumeric(cols) Then
                            lv.Items(rows).SubItems.Add(FormatNumber(dt.Rows(rows).Item(cols).ToString, 2, TriState.True, TriState.False, TriState.True))
                        ElseIf IsFieldDateTime(cols) Then
                            lv.Items(rows).SubItems.Add(Format$(CDate(dt.Rows(rows).Item(cols).ToString), "yyyy/MM/dd"))
                        Else
                            lv.Items(rows).SubItems.Add(dt.Rows(rows).Item(cols).ToString.Trim)
                        End If
                    Else
                        'Inactive Item
                        If dt.Rows(rows).Item(cols).ToString = "N" Then
                            InactiveItem = True
                        End If
                    End If
                Next cols

                If InactiveItem Then
                    lv.Items(rows).BackColor = Color.LightGray

                    InactiveItem = False
                End If

            Next rows

            lv.EndUpdate()

        Catch e As System.Exception
            ShowException(e)
        End Try

        'ShowTable(dt)
    End Sub

    Public Sub PopulateListView(ByRef lv As System.Windows.Forms.ListView, ByVal ds As DataSet, Optional ByVal FirstFieldIsKey As Boolean = False, Optional ByVal ShowFirstField As Boolean = True, Optional ByVal DateTimeAsDate As Boolean = False, Optional ByVal InactiveFieldsIndex As Integer = -1)
        Dim rows As Integer
        Dim cols As Integer
        Dim i As Integer
        Dim InactiveItem As Boolean = False


        Dim dt As New DataTable
        Try
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)
                End If
            End If

            If dt Is Nothing Then
                lv.Items.Clear()
                Exit Sub
            End If

            Dim IsFieldNumeric(dt.Columns.Count - 1) As Boolean
            Dim IsFieldDateTime(dt.Columns.Count - 1) As Boolean


            For i = 0 To dt.Columns.Count - 1
                'Debug.WriteLine(dt.Columns(i).ColumnName & " " & dt.Columns(i).DataType.ToString)
                If dt.Columns(i).DataType.ToString = "System.Double" Then
                    IsFieldNumeric(i) = True
                Else
                    IsFieldNumeric(i) = False
                End If

                If DateTimeAsDate And dt.Columns(i).DataType.ToString = "System.DateTime" Then
                    IsFieldDateTime(i) = True
                Else
                    IsFieldDateTime(i) = False
                End If
            Next i


            lv.Items.Clear()
            lv.BeginUpdate()

            Dim FirstFieldIndex As Integer
            If ShowFirstField Then
                FirstFieldIndex = 0
            Else
                FirstFieldIndex = 1
            End If

            For rows = 0 To dt.Rows.Count - 1
                'add item
                If IsFieldNumeric(FirstFieldIndex) Then
                    lv.Items.Add(FormatNumber(dt.Rows(rows).Item(FirstFieldIndex).ToString, 2, TriState.True, TriState.False, TriState.True))
                ElseIf IsFieldDateTime(FirstFieldIndex) Then
                    lv.Items.Add(Format$(dt.Rows(rows).Item(FirstFieldIndex).ToString, "yyyy/MM/dd"))
                Else
                    lv.Items.Add(dt.Rows(rows).Item(FirstFieldIndex).ToString.Trim)
                End If

                'store the key in the tag
                If FirstFieldIsKey Then
                    lv.Items(rows).Tag = dt.Rows(rows).Item(0).ToString.Trim
                End If

                'add subitems
                For cols = FirstFieldIndex + 1 To dt.Columns.Count - 1
                    If cols <> InactiveFieldsIndex Then
                        If IsFieldNumeric(cols) Then
                            lv.Items(rows).SubItems.Add(FormatNumber(dt.Rows(rows).Item(cols).ToString, 2, TriState.True, TriState.False, TriState.True))
                        ElseIf IsFieldDateTime(cols) Then
                            lv.Items(rows).SubItems.Add(Format$(CDate(dt.Rows(rows).Item(cols).ToString), "yyyy/MM/dd"))
                        Else
                            lv.Items(rows).SubItems.Add(dt.Rows(rows).Item(cols).ToString.Trim)
                        End If
                    Else
                        'Inactive Item
                        If dt.Rows(rows).Item(cols).ToString = "N" Then
                            InactiveItem = True
                        End If
                    End If
                Next cols

                If InactiveItem Then
                    lv.Items(rows).BackColor = Color.LightGray

                    InactiveItem = False
                End If

            Next rows

            lv.EndUpdate()

        Catch e As System.Exception
            ShowException(e)
        End Try

        ShowTable(dt)
    End Sub

    Public Sub PopulateListBox(ByRef lb As System.Windows.Forms.ListBox, ByVal dt As DataTable)
        Try
            Dim i As Integer
            lb.BeginUpdate()
            lb.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                lb.Items.Add(dt.Rows(i).Item(0).ToString)
            Next
            lb.EndUpdate()
        Catch err As System.Exception
            ShowException(err)
        End Try
    End Sub

    Public Sub PopulateListBox(ByRef lb As System.Windows.Forms.ListBox, ByVal thisArray As Array)
        Try
            Dim i As Integer
            lb.BeginUpdate()
            lb.Items.Clear()

            For i = 0 To thisArray.GetUpperBound(0)
                lb.Items.Add(thisArray.GetValue(i))
            Next
            lb.EndUpdate()
        Catch err As System.Exception
            ShowException(err)
        End Try
    End Sub

    Public Sub LoadCombo(ByVal iL As IList, ByVal Combo As ComboBox)
        Dim i As Integer

        Combo.BeginUpdate()
        Combo.Items.Clear()

        For i = 0 To iL.Count - 1
            Combo.Items.Add(iL.Item(i))
        Next
        If Combo.Items.Count > 0 Then
            Combo.SelectedIndex = 0
        End If

        Combo.EndUpdate()
    End Sub

    Public Sub LoadCombo(ByVal thisArray As Array, ByVal Combo As ComboBox)
        Dim i As Integer
        'Dim m As AnalysisGroupMember
        Combo.BeginUpdate()
        Combo.Items.Clear()

        For i = 0 To thisArray.GetUpperBound(0)
            Combo.Items.Add(thisArray.GetValue(i))
            'm = CType(thisArray.GetValue(i), AnalysisGroupMember)
        Next
        If Combo.Items.Count > 0 Then
            Combo.SelectedIndex = 0
        End If

        Combo.EndUpdate()
    End Sub
    Public Sub WriteSchemaWithXmlTextWriter(ByVal thisDataSet As DataSet, ByVal FileName As String)
        Try
            Dim myFileStream As New System.IO.FileStream _
               (FileName & ".xsd", System.IO.FileMode.Create)
            Dim MyXmlTextWriter As New System.Xml.XmlTextWriter _
               (myFileStream, System.Text.Encoding.Unicode)
            thisDataSet.WriteXmlSchema(MyXmlTextWriter)
            MyXmlTextWriter.Close()

            'Dim myStreamWriter As New System.IO.StreamWriter(FileName, False, System.Text.UnicodeEncoding.Unicode)
            Dim myFileStreamXML As New System.IO.FileStream _
                (FileName & ".xml", System.IO.FileMode.Create)
            Dim MyXMLTextWriter2 As New System.Xml.XmlTextWriter _
               (myFileStreamXML, System.Text.Encoding.Unicode)
            thisDataSet.WriteXml(MyXMLTextWriter2)
            MyXMLTextWriter2.Close()

        Catch e As System.Exception
            ShowException(e)
        End Try

    End Sub

#End Region

#Region "Globalisation NOT USED"
    Friend Function DeGlobaliseNumber(ByVal Number As Double) As String
        Dim dbCultureInfo As New System.Globalization.CultureInfo("en-us")
        dbCultureInfo.NumberFormat.CurrencyDecimalSeparator = "."
        dbCultureInfo.NumberFormat.CurrencySymbol = ""
        dbCultureInfo.NumberFormat.CurrencyGroupSeparator = ""

        Return Number.ToString(dbCultureInfo)
    End Function

    Friend Function DeGlobaliseNumber(ByVal Number As Integer) As String
        Dim dbCultureInfo As New System.Globalization.CultureInfo("en-us")
        dbCultureInfo.NumberFormat.CurrencyDecimalSeparator = "."
        dbCultureInfo.NumberFormat.CurrencySymbol = ""
        dbCultureInfo.NumberFormat.CurrencyGroupSeparator = ""

        Return Number.ToString(dbCultureInfo)
    End Function

    Friend Function DeGlobaliseNumber(ByVal Number As Int16) As String
        Dim dbCultureInfo As New System.Globalization.CultureInfo("en-us")
        dbCultureInfo.NumberFormat.CurrencyDecimalSeparator = "."
        dbCultureInfo.NumberFormat.CurrencySymbol = ""
        dbCultureInfo.NumberFormat.CurrencyGroupSeparator = ""

        Return Number.ToString(dbCultureInfo)
    End Function
#End Region

#Region "File I/O"
    Function WriteToFile(ByVal Filename As String, ByVal ds As DataSet, Optional ByVal AppendIfFileExists As Boolean = False) As Boolean
        Dim myFile As System.IO.File
        Dim Success As Boolean = False
        Dim AppendMode As Boolean

        Dim dt As DataTable
        Dim k As Integer

        If ds Is Nothing Then Exit Function

        'Dim your Text Writer 
        Dim TW As System.IO.TextWriter
        Try
            If myFile.Exists(Filename) Then
                If AppendIfFileExists Then
                    AppendMode = True
                Else
                    'If MessageBox.Show("Do you want to overwrite the file " & Filename & " ?", "WriteToFile", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    myFile.Delete(Filename)
                    'Else
                    '    Return Success
                    'End If
                End If
            End If

            If AppendMode Then
                TW = System.IO.File.AppendText(Filename)
            Else
                'Create a Text file and load it into the TextWriter 
                TW = System.IO.File.CreateText(Filename)
            End If

            Try
                For k = 0 To ds.Tables.Count - 1
                    dt = ds.Tables(k)

                    Dim i As Integer
                    Dim j As Integer

                    If Not dt Is Nothing Then
                        'For i = 0 To dt.Columns.Count - 2
                        '    TW.Write(dt.Columns(i).ColumnName & ControlChars.Tab)
                        'Next
                        'TW.WriteLine(dt.Columns(i).ColumnName)

                        For i = 0 To dt.Rows.Count - 1
                            For j = 0 To dt.Columns.Count - 2
                                TW.Write(DbNullToString(dt.Rows(i).Item(j)) & ControlChars.Tab)
                            Next
                            TW.WriteLine(DbNullToString(dt.Rows(i).Item(j)))
                        Next
                        TW.Flush()
                    End If
                Next

            Catch err As System.Exception
                Throw err
            Finally
                TW.Close()
            End Try

            Success = True
        Catch e As System.Exception
            ShowException(e)
            Success = False
        End Try

        Return Success
    End Function

#End Region
#Region "Registry Functions"
    Private Const mRegistryKey As String = "SOFTWARE\NODAL LocalSoft\STOCK"
    Private Const mRegistryWorkstationLeaf As String = "WorkstationId"
    Private Const mRegistryStoreLeaf As String = "LocationId"



    Friend Function RegisterWorkstation(ByVal dbServerName As String, ByVal dbName As String, ByVal StoreId As Integer, ByVal WorkstationId As Integer) As Boolean
        Dim RegistryKey As String
        RegistryKey = mRegistryKey & "\" & dbServerName.Trim & "\" & dbName.Trim

        If DeleteLocalMachineKey(RegistryKey, mRegistryStoreLeaf) Then
            If DeleteLocalMachineKey(RegistryKey, mRegistryWorkstationLeaf) Then
                If CreateLocalMachineKey(RegistryKey, mRegistryStoreLeaf, StoreId.ToString) Then
                    If CreateLocalMachineKey(RegistryKey, mRegistryWorkstationLeaf, WorkstationId.ToString) Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False

    End Function


    Public Function ReadRegistryStoreId(ByVal dbServerName As String, ByVal dbName As String) As Object
        Return ReadLocalMachineKey(dbServerName, dbName, mRegistryStoreLeaf)
    End Function

    Public Function ReadRegistryWorkstationId(ByVal dbServerName As String, ByVal dbName As String) As Object
        Return ReadLocalMachineKey(dbServerName, dbName, mRegistryWorkstationLeaf)
    End Function

    Private Function ReadLocalMachineKey(ByVal dbServerName As String, ByVal dbName As String, ByVal LeafName As String) As Object
        Dim o As Object

        Dim pRegKey As Microsoft.Win32.RegistryKey

        Try
            Dim KeyString As String
            KeyString = mRegistryKey & "\" & dbServerName.Trim & "\" & dbName.Trim

            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            'Debug.WriteLine(pRegKey.ValueCount)
            o = pRegKey.GetValue(LeafName)
        Catch err As System.Exception
            o = CType("", String)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return o
    End Function

    'Private Function RegisterWorkstationOLD(ByVal w As cWorkstation) As Boolean
    '    If DeleteLocalMachineKey(mRegistryKey, mRegistryStoreLeaf) Then
    '        If DeleteLocalMachineKey(mRegistryKey, mRegistryWorkstationLeaf) Then
    '            If CreateLocalMachineKey(mRegistryKey, mRegistryStoreLeaf, w.id.ToString) Then
    '                If CreateLocalMachineKey(mRegistryKey, mRegistryWorkstationLeaf, w.id.ToString) Then
    '                    Return True
    '                End If
    '            End If
    '        End If
    '    End If
    '    Return False
    'End Function


    Friend Function GetWorkstationId(ByVal dbServerName As String, ByVal dbName As String, ByRef WorkstationId As Integer) As Integer
        Dim o As Object

        o = Registry.ReadRegistryWorkstationId(dbServerName, dbName)
        If CType(o, String) = "" Then
            Return 0
        Else
            Try
                WorkstationId = CType(o, Integer)
            Catch err As System.Exception
                Return 0
            End Try
        End If

        Return WorkstationId
    End Function


    Private Function ReadLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String) As Object
        Dim o As Object

        Dim pRegKey As Microsoft.Win32.RegistryKey

        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            'Debug.WriteLine(pRegKey.ValueCount)
            o = pRegKey.GetValue(LeafName)
        Catch err As System.Exception
            o = CType("", String)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return o
    End Function

    Private Function CreateLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String, ByVal LeafValue As String) As Boolean
        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim Success As Boolean = False
        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyString)
            pRegKey.SetValue(LeafName, LeafValue)
            Success = True
        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try
        Return Success
    End Function

    Private Function DeleteLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String) As Boolean

        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim Success As Boolean = False
        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString, True)

            If Not pRegKey Is Nothing Then
                pRegKey.DeleteValue(LeafName)
            End If
            Success = True
        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                If Not pRegKey Is Nothing Then
                    pRegKey.Close()
                End If
            Catch err2 As System.Exception
                'Ignore
            End Try
        End Try
        Return Success
    End Function
    Private Function RegistryEntryExists(ByVal KeyString As String, ByVal LeafName As String) As Boolean
        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim k() As String
        Dim i As Integer
        Dim EntryFound As Boolean = False

        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            k = pRegKey.GetValueNames
            For i = 0 To k.GetUpperBound(0) - 1
                If k(i) = LeafName Then
                    EntryFound = True
                    Exit For
                End If
            Next

        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                If Not pRegKey Is Nothing Then
                    pRegKey.Close()
                End If
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return EntryFound
    End Function
#End Region

    'Friend Sub ShowReport(ByVal ReportName As String, ByVal ds As DataSet, ByVal ParentForm As Form, ByVal ReportCaption As String, ByVal SendToPrinterDirectly As Boolean, Optional ByVal PrinterName As String = "", Optional ByVal Parent_AS_Owner As Boolean = False)
    '    Dim StrMsg As String = " ** Unable to Print ** "
    '    Dim Flag As Boolean = False
    '    Try
    '        Dim r As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        Dim FileName As String

    '        'All the reports are expected to be located in
    '        'in a subdir called \Reports within the
    '        'current working directory
    '        'FileName = Application.StartupPath & "\Reports\" & ReportName
    '        FileName = Application.StartupPath & "\Reports\" & ReportName
    '        'Filename = application.

    '        r.Load(FileName)
    '        Flag = True
    '        If PrinterName <> "" Then
    '            'Make sure the specified printer is valid
    '            'IsValidPrinter: Sets PrinterName to the default printer
    '            'if the specified printername is not a valid printer
    '            If IsValidPrinter(PrinterName) Then
    '                r.PrintOptions.PrinterName = PrinterName
    '            End If
    '        End If
    '        r.SetDataSource(ds)
    '        ds.Dispose()


    '        If SendToPrinterDirectly Then
    '            r.PrintToPrinter(1, False, 0, 0)
    '        Else

    '            Dim CrystalForm As New CrystalReportForm

    '            If Parent_AS_Owner Then
    '                CrystalForm.Owner = ParentForm
    '            Else
    '                CrystalForm.MdiParent = ParentForm
    '            End If

    '            CrystalForm.Text = "Report: " & ReportCaption
    '            CrystalForm.CrystalViewer.Text = ReportCaption
    '            CrystalForm.CrystalViewer.ReportSource = r

    '            CrystalForm.Show()

    '            'CrystalForm.Top = ParentForm.Top

    '            CrystalForm.BringToFront()

    '        End If
    '    Catch err As System.Exception
    '        If Flag Then
    '            ShowException(err, StrMsg)
    '        Else
    '            ShowException(err)
    '        End If

    '    End Try
    'End Sub

    Public Function DoubleQuotes(ByVal s As String) As String
        Return Trim(s.Replace(Chr(34), Chr(34) & Chr(34)))
    End Function

    Public Function SingleQuotes(ByVal s As String, Optional ByVal TrimResult As Boolean = True) As String
        If TrimResult Then
            Return Trim(s.Replace("'", "''"))
        Else
            Return s.Replace("'", "''")
        End If
    End Function

    Public Function enQuoteString(ByVal s As String, Optional ByVal QuoteString As String = "'", Optional ByVal TrimString As Boolean = True) As String
        If TrimString Then
            Return QuoteString & Trim(Replace(s, "'", " ")) & QuoteString
        Else
            Return QuoteString & Replace(s, "'", " ") & QuoteString
        End If

    End Function


    Public Sub GetControls(ByVal F As Control, ByRef cList As ArrayList)
        Dim i As Integer
        cList.Add(F)

        For i = 0 To F.Controls.Count - 1
            GetControls(F.Controls(i), cList)
        Next
    End Sub


    Public Function StringToASCII(ByVal s As String) As String
        Dim i As Integer
        Dim a As String = ""
        For i = 0 To s.Length - 1
            If s.Chars(i).IsLetterOrDigit(s.Chars(i)) Then
                a &= "[" & s.Chars(i) & "]"
            Else
                a &= "[.]"
            End If

            a &= Asc(s.Chars(i)).ToString & " "
        Next
        Return a
    End Function

    Public Function IsOwnedForm(ByVal OwningForm As Form, ByVal OwnedForm As Form) As Boolean
        Dim F As Form

        For Each F In OwningForm.OwnedForms
            If F.GetType Is OwnedForm.GetType Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Public Function IsMdiChildAlready(ByVal MDIContainer As Form, ByVal mdiChildForm As Form) As Form
        Dim mdiChild As Form

        For Each mdiChild In MDIContainer.MdiChildren
            If mdiChild.GetType Is mdiChildForm.GetType Then
                Return mdiChild
            End If
        Next

        Return Nothing
    End Function

    Public Function GetOwnedForm(ByVal OwningForm As Form, ByVal OwnedForm As Form) As Form
        Dim F As Form

        For Each F In OwningForm.OwnedForms
            If F.GetType Is OwnedForm.GetType Then
                Return F
            End If
        Next
    End Function

    Public Sub ResizeForm(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim S As Form
        Try
            S = CType(sender, Form)
        Catch err As System.Exception
            Exit Sub
        End Try

        If S.WindowState = FormWindowState.Minimized Then
            Dim F As Form
            For Each F In S.OwnedForms
                F.WindowState = FormWindowState.Minimized
            Next
        ElseIf S.WindowState = FormWindowState.Normal Then
            Dim F As Form
            For Each F In S.OwnedForms
                F.WindowState = FormWindowState.Normal
            Next
        End If
    End Sub


    Public Function RoundMe(ByVal dblValue As Double, ByVal lngPosition As Integer) As Double
        Dim lngDecimalPosition As Long
        'The following is programming language i
        '     ndependent
        lngDecimalPosition = InStr(1, dblValue.ToString, strDecimalSeparator)


        If Len(dblValue) - lngDecimalPosition > lngPosition Then
            'Adding or substracting 0.5 allows for rounding instead of truncating
            dblValue = (10 ^ lngPosition) * dblValue + CDbl(IIf(dblValue < 0, -0.5, 0.5))
            lngDecimalPosition = InStr(1, dblValue.ToString, strDecimalSeparator)
            If lngDecimalPosition <> 0 Then dblValue = CDbl(Left(CStr(dblValue), CInt(lngDecimalPosition - 1)))
            'if there is not decimal then there is n
            '     o need to strip it
            dblValue = dblValue / (10 ^ lngPosition)
        End If
        RoundMe = dblValue

    End Function
    Public Function RoundMe2(ByVal d As Double, ByVal decimals As Int16) As Double

        Dim Args() As String
        Dim dABS As Double
        Dim A As String
        'Dim OriginalNumber As Double = d

        dABS = Math.Abs(d)
        'If dABS < 10 ^ (decimals + 1) Then
        '    Return 0
        'End If
        A = dABS

        Args = A.ToString.Split("."c)
        'Debug.WriteLine("*" & CDbl(Math.Abs(d)).ToString)
        'Args = Split(".", CDbl(Math.Abs(d)).ToString)
        If Args.Length <> 1 Then
            dABS = CDbl(Args(0))
            Dim m As Integer

            Args(1) = Args(1).PadRight(decimals + 1, "0"c).Substring(0, decimals + 1)
            If Args(1).Length = decimals + 1 Then
                Dim Remainder As Integer

                m = CInt(Args(1))
                Remainder = m Mod 10
                If Remainder >= 5 Then
                    m += 10 - Remainder
                Else
                    m -= Remainder
                End If
            End If

            dABS += m / (10 ^ (decimals + 1))
        Else
            dABS = CDbl(Args(0))
        End If

        Dim RetValue As Double
        'Debug.WriteLine("RoundMe(" & OriginalNumber & ")=" & d)
        If d < 0 Then
            'Return -dABS
            RetValue = -dABS
        Else
            RetValue = dABS
        End If

        'If RetValue <> RoundMe(d, decimals) Then
        '    MsgBox(RetValue & "  " & RoundMe(d, decimals))
        'End If

        Return RetValue
    End Function
    Public Function RoundMeUp(ByVal D As Double) As Double
        'correction 07/02
        Dim Ar() As String
        Dim V As Double
        Dim S As String
        S = Format(D, "0.00")

        Ar = S.Split(".")
        Dim SS As String
        SS = Ar(1)
        Dim First As Integer
        First = SS.Substring(0, 1)

        If First >= 5 Then
            V = CDbl(Ar(0)) + 1
        Else
            V = CDbl(Ar(0))
        End If

        Return V

    End Function
    Public Function RoundMeMinutes(ByVal D As Double) As Double
        'correction 07/02
        Dim Ar() As String
        Dim V As Double
        Dim S As String
        S = Format(D, "0.00")

        Ar = S.Split(".")
        Dim SS As String
        SS = Ar(1)
        Dim First As Integer
        First = SS.Substring(0, 1)

        If First >= 3 Then
            V = CDbl(Ar(0)) + 1
        Else
            V = CDbl(Ar(0))
        End If

        Return V

    End Function


    Public Function RoundMe3(ByVal d As Double, ByVal decimals As Int16) As Double
        Dim Args() As String
        Dim dABS As Double
        'Dim OriginalNumber As Double = d

        dABS = Math.Abs(d)
        'If dABS < 10 ^ (decimals + 1) Then
        '    Return 0
        'End If

        Args = dABS.ToString.Split("."c)
        'Debug.WriteLine("*" & CDbl(Math.Abs(d)).ToString)
        'Args = Split(".", CDbl(Math.Abs(d)).ToString)
        If Args.Length <> 1 Then
            dABS = CDbl(Args(0))
            Dim m As Integer

            Args(1) = Args(1).PadRight(decimals + 1, "0"c).Substring(0, decimals + 1)
            If Args(1).Length = decimals + 1 Then
                Dim Remainder As Integer

                m = CInt(Args(1))
                Remainder = m Mod 10
                If Remainder >= 5 Then
                    m += 10 - Remainder
                Else
                    m -= Remainder
                End If
            End If

            dABS += m / (10 ^ (decimals + 1))
        Else
            dABS = CDbl(Args(0))
        End If

        Dim RetValue As Double
        'Debug.WriteLine("RoundMe(" & OriginalNumber & ")=" & d)
        If d < 0 Then
            'Return -dABS
            RetValue = -dABS
        Else
            RetValue = dABS
        End If
        Dim dec As String = "0"
        Dim i As Integer
        If decimals > 0 Then
            dec = "0."
            For i = 0 To decimals
                dec = dec & "0"
            Next
        End If
        If Math.Abs(d) < 0.0001 Then
            If Math.Abs(RetValue) > d Then
                RetValue = 0
            End If
        End If
        RetValue = Format(RetValue, dec)

        Return RetValue
    End Function
    Public Function SingleCharToBool(ByVal o As Object) As Boolean
        If IsNothing(o) Then
            Return False
        ElseIf CType(o, Char) <> "0" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function FixDate(ByVal DateValue As Date) As String
        Dim StrNewDate As String
        StrNewDate = Format(DateValue, "MM/dd/yyyy")
        Return StrNewDate
    End Function

    Public Function NullToInt(ByVal o As Object) As Integer
        Dim s As String
        s = CType(o, String)
        If s Is Nothing Then
            Return 0
        ElseIf s = "" Then
            Return 0
        Else
            Return CType(o, Integer)
        End If
    End Function
    Public Function NullToDbl(ByVal o As Object) As Integer
        Dim s As String
        s = CType(o, String)
        If s Is Nothing Then
            Return 0
        ElseIf s = "" Then
            Return 0
        Else
            Return CType(o, Double)
        End If
    End Function

    Public Function NullToShort(ByVal o As Object) As Short
        Dim s As String
        s = CType(o, String)
        If s Is Nothing Then
            Return 0
        ElseIf s = "" Then
            Return 0
        Else
            Return CType(o, Short)
        End If
    End Function
    Public Function ChangeDateFormat(ByVal S As String) As String
        Dim yyyy As String
        Dim mm As String
        Dim dd As String
        Dim Ar() As String
        Ar = S.Split("/")
        yyyy = Ar(2)
        dd = Ar(1).PadLeft(2, "0")
        mm = Ar(0).PadLeft(2, "0")
        S = yyyy & "-" & mm & "-" & dd
        Return S
    End Function
    Public Function ChangeDateFormatForSearching(ByVal S As String) As String
        'This is SQL CE
        Dim yyyy As String
        Dim mm As String
        Dim dd As String
        Dim Ar() As String
        Ar = S.Split("-")
        yyyy = Ar(0)
        mm = Ar(1).PadLeft(2, "0")
        dd = Ar(2).PadLeft(2, "0")
        S = yyyy & "-" & dd & "-" & mm
        Return S
    End Function
    Public Function ChangeDateFormatForSearch(ByVal S As String) As String
        'This is Normal SQL
        Dim yyyy As String
        Dim mm As String
        Dim dd As String
        Dim Ar() As String
        Ar = S.Split("-")
        yyyy = Ar(0)
        mm = Ar(1).PadLeft(2, "0")
        dd = Ar(2).PadLeft(2, "0")
        S = yyyy & "-" & mm & "-" & dd
        Return S
    End Function
    Public Function ChangeDateFormat_ddMMyyyy_to_yyyyMMdd(ByVal S As String) As String
        'This is SQL CE
        Dim yyyy As String
        Dim mm As String
        Dim dd As String
        Dim Ar() As String
        Ar = S.Split("/")
        yyyy = Ar(2)
        mm = Ar(0).PadLeft(2, "0")
        dd = Ar(1).PadLeft(2, "0")
        S = yyyy & "/" & mm & "/" & dd
        Return S
    End Function
    Public Function ChangeDateForSaving(ByVal Dt As Date) As String
        Return Format$(Dt, "yyyy-dd-MM")

    End Function
    Public Function ChangeDateTimeForSaving(ByVal Dt As Date) As String
        Return Format$(Dt, "yyyy-dd-MM hh:mm:ss")

    End Function


    Public Function Encrypt(ByVal password As String) As String
        Dim strmsg As String = String.Empty
        Dim encode As Byte() = New Byte(password.Length - 1) {}
        encode = Encoding.UTF8.GetBytes(password)
        strmsg = Convert.ToBase64String(encode)
        Return strmsg
    End Function

    Public Function Decrypt(ByVal encryptpwd As String) As String
        Dim decryptpwd As String = String.Empty
        Dim encodepwd As New UTF8Encoding()
        Dim Decode As Decoder = encodepwd.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(encryptpwd)
        Dim charCount As Integer = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        decryptpwd = New [String](decoded_char)
        Return decryptpwd
    End Function
End Module

Module Registry
#Region "Registry Functions"
    Private Const mRegistryKey As String = "SOFTWARE\NODAL LocalSoft\MiniSTOCK"
    Private Const mRegistryWorkstationLeaf As String = "WorkstationId"



    Friend Function RegisterWorkstation(ByVal dbServerName As String, ByVal dbName As String, ByVal WorkstationId As Integer) As Boolean
        Dim RegistryKey As String
        RegistryKey = mRegistryKey & "\" & dbServerName.Trim & "\" & dbName.Trim

        If DeleteLocalMachineKey(RegistryKey, mRegistryWorkstationLeaf) Then
            If CreateLocalMachineKey(RegistryKey, mRegistryWorkstationLeaf, WorkstationId.ToString) Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function ReadRegistryWorkstationId(ByVal dbServerName As String, ByVal dbName As String) As Object
        Return ReadLocalMachineKey(dbServerName, dbName, mRegistryWorkstationLeaf)
    End Function

    Private Function ReadLocalMachineKey(ByVal dbServerName As String, ByVal dbName As String, ByVal LeafName As String) As Object
        Dim o As Object

        Dim pRegKey As Microsoft.Win32.RegistryKey

        Try
            Dim KeyString As String
            KeyString = mRegistryKey & "\" & dbServerName.Trim & "\" & dbName.Trim

            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            'Debug.WriteLine(pRegKey.ValueCount)
            o = pRegKey.GetValue(LeafName)
        Catch err As System.Exception
            o = CType("", String)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return o
    End Function


    Friend Function GetWorkstationId(ByVal dbServerName As String, ByVal dbName As String, ByRef StoreId As Integer, ByRef WorkstationId As Integer) As Boolean
        Dim o As Object

        o = Registry.ReadRegistryWorkstationId(dbServerName, dbName)
        If CType(o, String) = "" Then
            Return False
        Else
            Try
                WorkstationId = CType(o, Integer)
            Catch err As System.Exception
                Return False
            End Try
        End If

        Return True
    End Function


    Private Function ReadLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String) As Object
        Dim o As Object

        Dim pRegKey As Microsoft.Win32.RegistryKey

        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            'Debug.WriteLine(pRegKey.ValueCount)
            o = pRegKey.GetValue(LeafName)
        Catch err As System.Exception
            o = CType("", String)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return o
    End Function

    Private Function CreateLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String, ByVal LeafValue As String) As Boolean
        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim Success As Boolean = False
        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyString)
            pRegKey.SetValue(LeafName, LeafValue)
            Success = True
        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                pRegKey.Close()
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try
        Return Success
    End Function

    Private Function DeleteLocalMachineKey(ByVal KeyString As String, ByVal LeafName As String) As Boolean

        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim Success As Boolean = False
        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString, True)

            If Not pRegKey Is Nothing Then
                pRegKey.DeleteValue(LeafName)
            End If
            Success = True
        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                If Not pRegKey Is Nothing Then
                    pRegKey.Close()
                End If
            Catch err2 As System.Exception
                'Ignore
            End Try
        End Try
        Return Success
    End Function
    Private Function RegistryEntryExists(ByVal KeyString As String, ByVal LeafName As String) As Boolean
        Dim pRegKey As Microsoft.Win32.RegistryKey
        Dim k() As String
        Dim i As Integer
        Dim EntryFound As Boolean = False

        Try
            pRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyString)
            k = pRegKey.GetValueNames
            For i = 0 To k.GetUpperBound(0) - 1
                If k(i) = LeafName Then
                    EntryFound = True
                    Exit For
                End If
            Next

        Catch err As System.Exception
            ShowException(err)
        Finally
            Try
                If Not pRegKey Is Nothing Then
                    pRegKey.Close()
                End If
            Catch err2 As System.Exception
                'ignore
            End Try
        End Try

        Return EntryFound
    End Function
#End Region
End Module


'Module FTP
'    Function Transfer( _
'        ByVal sRemoteHost As String, _
'        ByVal sRemotePath As String, _
'        ByVal sRemoteUser As String, _
'        ByVal sRemotePassword As String, _
'        ByVal iRemotePort As Integer, _
'        ByVal localFilename As String) As Boolean

'        Dim Success As Boolean = False
'        Dim ff As clsFTP

'        Try
'            ff = New clsFTP(sRemoteHost, sRemotePath, sRemoteUser, sRemotePassword, iRemotePort)
'            If (ff.Login() = True) Then
'                'Change the directory on your FTP site.
'                'If Not (ff.ChangeDirectory("MyOwnFolder") = True) Then
'                '    Throw New Exception("FTP: Unable to change the directory to '" & myownfolder & "'")
'                'End If
'            Else
'                Throw New Exception("FTP: Login failed")
'            End If

'            Dim sFile() As String
'            sFile = localFilename.Split("\"c)

'            Dim sFilename As String
'            sFilename = sFile(UBound(sFile))

'            If ff.FileExists(sFilename) Then
'                MessageBox.Show("A file with the same name exists on the remote server.", "Tranfer File", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Else
'                ff.SetBinaryMode(True)
'                ff.UploadFile(localFilename)
'                ff.CloseConnection()
'                Success = True
'            End If

'        Catch ex As system.Exception
'            ShowException(ex)
'        End Try

'        Return Success
'    End Function

'    Private Sub TestFTP()

'        'Create an instance of the FTP class that is created.
'        Dim ff As clsFTP

'        Try
'            'Pass values to the constructor. These values can be overridden by setting 
'            'the appropriate properties on the instance of the clsFTP class.
'            'The third parameter is the user name. The FTP site is accessed with the user name.
'            'If there is no specific user name, the user name can be anonymous.
'            'The fourth parameter is the password. The FTP server is accessed with the password.
'            'The fifth parameter is the port of the FTP server. The port of the FTP server is typically 21.

'            ff = New clsFTP("10.0.0.100", "", "root", "root", 21)
'            'ff = New clsFTP(StrIP, _
'            '                "/Myfolder/", _
'            '                "anonymous", _
'            '                "", _
'            '                21)


'            'Try to log on to the FTP server.
'            If (ff.Login() = True) Then
'                'Change the directory on your FTP site.
'                If (ff.ChangeDirectory("MyOwnFolder") = True) Then
'                    'Successful changing the directory
'                    Console.WriteLine("Changed the directory to the directory that was specified" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    Throw New Exception("FTP: Unable to change the directory")
'                End If
'                'Create a directory on your FTP site under the previous directory. 
'                If (ff.CreateDirectory("FTPFOLDERNEW") = True) Then
'                    'Successful creating the directory
'                    Console.WriteLine("A new folder has been created" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    'Unsuccessful creating the directory
'                    Console.WriteLine("A new folder has not been created" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                End If
'                'Change the directory on your FTP site under the directory that is specified.
'                If (ff.ChangeDirectory("FTPFOLDERNEW") = True) Then
'                    'Successful changing the directory
'                    Console.WriteLine("Changed the directory to the directory that was specified" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    'Unsuccessful changing the directory
'                    Console.WriteLine("Unable to change the directory that was specified" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                End If

'                ff.SetBinaryMode(True)

'                'Upload a file from your local hard disk to the FTP site.
'                ff.UploadFile("C:\Test\Example1.txt")
'                ff.UploadFile("C:\Test\Example2.doc")
'                ff.UploadFile("C:\Test\Example3.doc")

'                'Download a file from the FTP site to your local hard disk.
'                ff.DownloadFile("Example2.doc", "C:\Test\Example2.doc")

'                ' Remove a file from the FTP site.
'                If (ff.DeleteFile("Example1.txt") = True) Then
'                    'Successful removing the file on the FTP site
'                    Console.WriteLine("File has been removed from the FTP site" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    'Unsuccessful removing the file on the FTP site
'                    Console.WriteLine("Unable to remove the file on the FTP site" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                End If

'                'Rename a file on the FTP site.
'                If (ff.RenameFile("Example3.doc", "Example3_new.doc")) Then
'                    'Successful renaming the file on the FTP site
'                    Console.WriteLine("File has been renamed" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    'Unsuccessful renaming the file on the FTP site
'                    Console.WriteLine("File has not been renamed" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                End If
'                'Change the directory to one directory before.
'                If (ff.ChangeDirectory("..") = True) Then
'                    'Successful changing the directory
'                    Console.WriteLine("Changed the directory to one directory before" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                Else
'                    'Unsuccessful changing the directory
'                    Console.WriteLine("Unable to change the directory" + vbCrLf)
'                    Console.WriteLine("Press 'ENTER'")
'                    Console.ReadLine()
'                End If
'            End If
'            'Create a new directory.
'            If (ff.CreateDirectory("MyOwnFolderNew") = True) Then
'                'Successful creating the directory
'                Console.WriteLine("A new folder has been created" + vbCrLf)
'                Console.WriteLine("Press 'ENTER'")
'                Console.ReadLine()
'            Else
'                'Unsuccessful creating the directory
'                Console.WriteLine("A new folder has not been created" + vbCrLf)
'                Console.WriteLine("Press 'ENTER'")
'                Console.ReadLine()
'            End If
'            'Remove the directory that is created on the FTP site.
'            If (ff.RemoveDirectory("MyOwnFolderNew")) Then
'                'Successful removing the directory on the FTP site
'                Console.WriteLine("Directory has been removed" + vbCrLf)
'                Console.WriteLine("Press 'ENTER'")
'                Console.ReadLine()
'            Else
'                'Unsuccessful removing the directory on the FTP site
'                Console.WriteLine("Unable to remove the directory" + vbCrLf)
'                Console.WriteLine("Press 'ENTER'")
'                Console.ReadLine()

'            End If



'        Catch ex As System.Exception
'            'Display the error message. 
'            Console.WriteLine("Specific Error=" & ex.Message + vbCrLf)
'            Console.WriteLine("Press 'ENTER' to EXIT")
'            Console.ReadLine()

'        Finally
'            'Always close the connection to make sure that there are not any not-in-use FTP connections.
'            'Check if you are logged on to the FTP server and then close the connection.

'            If ff.flag_bool = True Then
'                ff.CloseConnection()
'            End If

'        End Try
'    End Sub
'End Module

Module PrinterUtils
#Region "Printer WINAPI32 Declarations"
    Private Structure DOCINFO
        Public pDocName As String
        Public pOutputFile As String
        Public pDatatype As String
    End Structure

    Private Const FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
    Private Const FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
    Private Const FORMAT_MESSAGE_FROM_STRING As Integer = &H400
    Private Const FORMAT_MESSAGE_FROM_HMODULE As Integer = &H800
    Private Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000
    Private Const FORMAT_MESSAGE_ARGUMENT_ARRAY As Integer = &H2000
    Private Const FORMAT_MESSAGE_MAX_WIDTH_MASK As Integer = &HFF

    Private Declare Function FormatMessage Lib "kernel32" Alias "FormatMessageA" (ByVal dwFlags As Integer, ByRef lpSource As Object, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As String, ByVal nSize As Integer, ByRef Arguments As Integer) As Integer
    Private Declare Function LocalFree Lib "Kernel.dll" Alias "LocalFree" (ByVal hMem As Integer) As Integer
    Private Declare Function GetLastError Lib "Kernel32.dll" () As Integer
    Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
    Private Declare Function EndDocPrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
    Private Declare Function EndPagePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
    Private Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, ByRef phPrinter As Integer, ByVal pDefault As Integer) As Integer
    Private Declare Function StartDocPrinter Lib "winspool.drv" Alias "StartDocPrinterA" (ByVal hPrinter As Integer, ByVal Level As Integer, ByRef pDocInfo As DOCINFO) As Integer
    Private Declare Function StartPagePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
    Private Declare Function WritePrinter Lib "winspool.drv" (ByVal hPrinter As Integer, ByVal pCommand As String, ByVal cdBuf As Integer, ByRef pcWritten As Integer) As Integer
    Private Declare Function Escape Lib "Gdi32" (ByVal hDC As Integer, ByVal ByValnEscape As Integer, ByVal ncount As Integer, ByVal indata As String, ByVal oudata As String) As Integer
    Private Declare Auto Function GetDefaultPrinter Lib "Winspool.drv" (ByVal pBuffer As String, ByRef bufferSize As Integer) As Integer
#End Region

    Private Function GetDefaultPrinterName() As String
        Dim buff As String = Space(250)
        Dim sz As Integer = buff.Length
        Dim i As Integer

        Try
            i = GetDefaultPrinter(buff, sz)
            If i <> 0 Then
                Return buff.Substring(0, sz - 1)
            Else
                buff = ""
            End If
        Catch e As System.Exception
        End Try

        Return buff
    End Function

    Public Function IsValidPrinter(ByRef PrinterName As String) As Boolean
        Dim lReturn As Integer
        Dim lhPrinter As Integer
        Dim Success As Boolean = False
        Dim thisPrinterName As String

        Try
            If PrinterName <> "" Then
                thisPrinterName = PrinterName
            Else
                thisPrinterName = GetDefaultPrinterName()
            End If

            lReturn = OpenPrinter(thisPrinterName, lhPrinter, 0)
            If lReturn <> 0 Then
                lReturn = ClosePrinter(lhPrinter)
                If lReturn <> 0 Then
                    Success = True
                End If
            End If

        Catch e As System.Exception

        End Try

        Return Success
    End Function
    Public Function CheckDataSet(ByVal ds As DataSet) As Boolean
        Dim flag As Boolean
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    flag = True
                End If
            End If
        End If
        Return flag
    End Function

    

  

   
    






End Module
