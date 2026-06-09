Imports Microsoft.Office.Interop
Imports System.IO
Public Class FrmTest1

    Public Sub ConvertStockTakeToExcel_Interop(inputFile As String, outputFile As String)

        Dim xlApp As New Excel.Application
        Dim wb As Excel.Workbook = xlApp.Workbooks.Add()
        Dim ws As Excel.Worksheet = wb.Sheets(1)

        xlApp.Visible = False
        Dim i As Integer

        ' Header row
        Dim headers = {"CODE", "DESCRIPTION", "ALTERNATIVE-CODE", "GRP", "SUPP", "UOM",
                   "BIN", "STOCK-QTY", "COUNT", "DIFF", "COMMENTS"}

        For i = 0 To headers.Length - 1
            ws.Cells(1, i + 1).Value = headers(i)
            ws.Cells(1, i + 1).Font.Bold = True
        Next

        Dim lines As String() = File.ReadAllLines(inputFile)
        Dim row As Integer = 2

        For Each line As String In lines

            Dim t As String = line.Trim()

            ' Skip empty lines and separators
            If t.Length < 20 Then Continue For
            If t.StartsWith("---") Then Continue For
            If t.StartsWith("LANITIS") Then Continue For
            If t.StartsWith("CODE") Then Continue For
            If t.StartsWith("21") Then Continue For
            If t.StartsWith("PERIOD") Then Continue For
            If t.StartsWith("DATE") Then Continue For

            ' Valid data lines start with a numeric code
            If t.Length = 0 Then Continue For
            If Not Char.IsDigit(t(0)) Then Continue For

            ' Extract fixed-width fields
            Dim code = line.Substring(0, 14).Trim()
            Dim desc = line.Substring(14, 30).Trim()
            Dim altCode = line.Substring(44, 15).Trim()
            Dim grp = line.Substring(59, 4).Trim()
            Dim supp = line.Substring(63, 6).Trim()
            Dim uom = line.Substring(69, 4).Trim()
            Dim bin = line.Substring(73, 8).Trim()
            Dim stockQty = line.Substring(81, 12).Trim()
            Dim countVal = line.Substring(93, 10).Trim()
            Dim diffVal = line.Substring(103, 10).Trim()

            Dim comments As String = ""
            If line.Length > 113 Then comments = line.Substring(113).Trim()

            ' Write to Excel
            ws.Cells(row, 1).Value = code
            ws.Cells(row, 2).Value = desc
            ws.Cells(row, 3).Value = altCode
            ws.Cells(row, 4).Value = grp
            ws.Cells(row, 5).Value = supp
            ws.Cells(row, 6).Value = uom
            ws.Cells(row, 7).Value = bin
            ws.Cells(row, 8).Value = stockQty
            ws.Cells(row, 9).Value = countVal
            ws.Cells(row, 10).Value = diffVal
            ws.Cells(row, 11).Value = comments

            row += 1
        Next

        ' Auto-fit columns
        ws.Columns.AutoFit()

        ' Save Excel file
        wb.SaveAs(outputFile)
        wb.Close()
        xlApp.Quit()

        ' Release COM objects
        ReleaseComObject(ws)
        ReleaseComObject(wb)
        ReleaseComObject(xlApp)

    End Sub


    Private Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch
        Finally
            obj = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConvertStockTakeToExcel_Interop("C:\temp\LAX\stlist1.txt", "C:\temp\LAX\StockTake.xlsx")

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ConvertStockTakeToExcel_Interop_WithHeaders("C:\temp\LAX\stlist1.txt", "C:\temp\LAX\StockTake.xlsx")
    End Sub


    Public Sub ConvertStockTakeToExcel_Interop_WithHeaders(inputFile As String, outputFile As String)

        Dim xlApp As New Excel.Application
        Dim wb As Excel.Workbook = xlApp.Workbooks.Add()
        Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

        xlApp.Visible = False

        ' Πόσες γραμμές δεδομένων πριν ξαναγραφτεί το header
        Dim headerRepeatEvery As Integer = 40

        ' Header row template
        Dim headers As String() = {
            "CODE", "DESCRIPTION", "ALT-CODE", "GRP", "SUPP", "UOM",
            "BIN", "STOCK-QTY", "COUNT", "DIFF", "COMMENTS"
        }

        ' Πρώτο header στη γραμμή 1
        WriteHeader(ws, headers, 1)

        Dim lines As String() = File.ReadAllLines(inputFile)
        Dim row As Integer = 2
        Dim dataLinesCounter As Integer = 0

        For Each line As String In lines

            Dim t As String = line.Trim()

            ' Skip empty lines and separators
            If t.Length < 20 Then Continue For
            If t.StartsWith("---") Then Continue For
            If t.StartsWith("LANITIS") Then Continue For
            If t.StartsWith("CODE") Then Continue For
            If t.StartsWith("21") Then Continue For
            If t.StartsWith("PERIOD") Then Continue For
            If t.StartsWith("DATE") Then Continue For

            ' Valid data lines start with a numeric code
            If t.Length = 0 Then Continue For
            If Not Char.IsDigit(t(0)) Then Continue For

            ' Repeat header every X data lines
            If dataLinesCounter > 0 AndAlso dataLinesCounter Mod headerRepeatEvery = 0 Then
                row += 1
                WriteHeader(ws, headers, row)
                row += 1
            End If

            ' Extract fixed-width fields
            Dim code = line.Substring(0, 14).Trim()
            Dim desc = line.Substring(14, 30).Trim()
            Dim altCode = line.Substring(44, 15).Trim()
            Dim grp = line.Substring(59, 4).Trim()
            Dim supp = line.Substring(63, 6).Trim()
            Dim uom = line.Substring(69, 4).Trim()
            Dim bin = line.Substring(73, 8).Trim()
            Dim stockQty = line.Substring(81, 12).Trim()
            Dim countVal = line.Substring(93, 10).Trim()
            Dim diffVal = line.Substring(103, 10).Trim()

            Dim comments As String = ""
            If line.Length > 113 Then comments = line.Substring(113).Trim()

            ' Write to Excel
            ws.Cells(row, 1).Value = code
            ws.Cells(row, 2).Value = desc
            ws.Cells(row, 3).Value = altCode
            ws.Cells(row, 4).Value = grp
            ws.Cells(row, 5).Value = supp
            ws.Cells(row, 6).Value = uom
            ws.Cells(row, 7).Value = bin
            ws.Cells(row, 8).Value = stockQty
            ws.Cells(row, 9).Value = countVal
            ws.Cells(row, 10).Value = diffVal
            ws.Cells(row, 11).Value = comments

            row += 1
            dataLinesCounter += 1

        Next

        ' Auto-fit columns
        ws.Columns.AutoFit()

        ' Save Excel file
        wb.SaveAs(outputFile)
        wb.Close()
        xlApp.Quit()

        ' Release COM objects
        ReleaseComObject(ws)
        ReleaseComObject(wb)
        ReleaseComObject(xlApp)

    End Sub

    Private Sub WriteHeader(ws As Excel.Worksheet, headers As String(), startRow As Integer)
        For i As Integer = 0 To headers.Length - 1
            ws.Cells(startRow, i + 1).Value = headers(i)
            ws.Cells(startRow, i + 1).Font.Bold = True
        Next
    End Sub


End Class