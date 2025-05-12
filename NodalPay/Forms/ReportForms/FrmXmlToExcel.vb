Imports System.Xml
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmXmlToExcel
    Public FilePath As String
    ' Public FileName As String


    Private Sub FrmXmlToExcel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFile()
    End Sub

    Private Sub LoadFile()

        Dim Ar() As String
        Ar = FilePath.Split("\")
        Dim path As String = ""
        Dim i As Integer
        For i = 0 To Ar.Length - 1
            Dim Ar2() As String
            Ar2 = Ar(i).Split(".")
            If Ar2.Length > 1 Then
                Exit For
            End If
            path = path & Ar(i) & "\"

        Next

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Dim ds As New DataSet
        Dim xmlFile As XmlReader
        Dim j As Integer

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        xmlFile = XmlReader.Create(FilePath, New XmlReaderSettings())
        ds.ReadXml(xmlFile)
        DataGridView1.DataSource = ds.Tables(0)

        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 0 To ds.Tables(0).Columns.Count - 1
                xlWorkSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i).Item(j)
            Next
        Next

        xlWorkSheet.SaveAs(path & "Ir7xml2excel.xlsx")
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

  
    End Class
