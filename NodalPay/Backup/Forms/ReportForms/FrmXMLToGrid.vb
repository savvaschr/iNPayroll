Imports Microsoft.Office.Interop.Excel
Public Class FrmXMLToGrid
    Public FilePath As String
    Public FileName As String

    Private Sub FrmXMLToGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Test()


    End Sub
    'Public Sub LoadFile()

    '    Dim i As Integer
    '    Try
    '        Dim fname As String = FilePath
    '        Dim fileContents = IO.File.ReadAllLines(fname).Tolist
    '        For i = fileContents.Count - 1 To 0 Step -1
    '            If fileContents(i).Contains("--------") Then
    '                fileContents.RemoveAt(i)
    '                i -= 1
    '            End If
    '        Next
    '        IO.File.WriteAllLines(fname, fileContents.ToArray)
    '        Dim sw = System.Diagnostics.Stopwatch.StartNew()
    '        Using stream As System.IO.FileStream = System.IO.File.OpenRead(fname)
    '            Using reader As New System.IO.StreamReader(stream)
    '                Dim line As String = reader.ReadLine()
    '                While (line IsNot Nothing)
    '                    Dim columns = line.Split("|")
    '                    line = reader.ReadLine()
    '                    Dim index = Me.DataGridView1.Rows.Add()
    '                    Me.DataGridView1.Rows(index).SetValues(columns)
    '                End While

    '            End Using
    '        End Using
    '        sw.Stop()
    '        DataGridView1.Refresh()
    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Public Sub test()
    '    FilePath = Replace(FilePath, ".DAT", ".txt")
    '    Dim connString As String = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" & FilePath & "" & ";Extended Properties=""Text;HDR=No;FMT=Delimited(|)"""

    '    Dim conn As New Odbc.OdbcConnection(connString)


    '    Dim da As New Odbc.OdbcDataAdapter("SELECT * FROM [" & FileName & "]", conn)

    '    Dim dt As New DataTable
    '    Dim ds2 As New DataSet

    '    da.Fill(dt)
    '    'source1.DataSource = dt
    '    DataGridView1.DataSource = dt

    'End Sub

    'Public Shared Function AddWorksheet(ByVal spreadsheet As SpreadsheetDocument, ByVal name As String) As Boolean
    '    Dim sheets As Sheets = spreadsheet.WorkbookPart.Workbook.GetFirstChild(Of Sheets)()
    '    Dim sheet As Sheet
    '    Dim worksheetPart As WorksheetPart

    '    ' Add the worksheetpart
    '    worksheetPart = spreadsheet.WorkbookPart.AddNewPart(Of WorksheetPart)()
    '    worksheetPart.Worksheet = New Worksheet(New SheetData())
    '    worksheetPart.Worksheet.Save()

    '    ' Add the sheet and make relation to workbook
    'sheet = New Sheet With {
    '   .Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
    '   .SheetId = (spreadsheet.WorkbookPart.Workbook.Sheets.Count() + 1),
    '   .Name = name}
    '    sheets.Append(sheet)
    '    spreadsheet.WorkbookPart.Workbook.Save()

    '    Return True
    'End Function
    Private Sub Test()
        Dim oExcel As Object
        Dim oBook As Object
        Dim oRow As Int16 = 0

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Read input .txt file line-by-line, Copy to Clipboard & Paste to Excel

        Using rdr As New System.IO.StreamReader(FilePath & FileName)
            Do While rdr.Peek() >= 0
                Dim InputLine As String = rdr.ReadLine
                oRow = oRow + 1
                System.Windows.Forms.Clipboard.SetDataObject(InputLine)
                oBook.Worksheets(1).Range("A" + oRow.ToString).Select()
                oBook.Worksheets(1).Paste()
            Loop
            rdr.Close()
        End Using

        oExcel.Visible = True
        'oExcel.SaveAs("C\Temp\test.xls")
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
    End Sub
End Class