Public Class FrmShowInterfaceFormSoftOne
    Dim MyDs As DataSet
    Dim Dt1 As DataTable

    Public FileName As String
    Public NewInterface As Boolean
    Dim GLBSubsidiary As String = ""

    Private Sub FrmShowInterfaceFormSoftOne_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DG1.Visible = True

        InitDataTable()
        InitDataGrid()
        LoadFileIntoGrid()


    End Sub
    Private Sub LoadFileIntoGrid()

        Dim Line As String

        Try
            Dim Exx As New Exception
            Dim HeaderLine As String
            Dim param_file As IO.StreamReader
            param_file = IO.File.OpenText(FileName)
            Dim Ar() As String
            Dim Amount As String
            Dim Accountcode As String
            Dim Description As String
            Dim analysis As String
            Dim Counter As Integer
            Dim MyDate As String = ""
            Dim Total As Double = 0
            Dim Debit As Double = 0
            Dim Credit As Double = 0
            Dim comment As String = ""
            Dim analysis3 As String = ""
            Dim analysis4 As String = ""

            Do While param_file.Peek <> -1
                Counter = Counter + 1
                System.Windows.Forms.Application.DoEvents()
                Line = param_file.ReadLine()
                Ar = Line.Split("|||")
                If NewInterface Then
                    Accountcode = Ar(27)
                    Amount = Ar(51)
                    Description = Ar(60)
                    analysis = Ar(72)
                    MyDate = Ar(9)
                    comment = (Ar(36))
                    analysis3 = Ar(75)
                    analysis4 = Ar(78)

                Else
                    Accountcode = Ar(4)
                    Amount = Ar(7)
                    Description = Ar(6)
                    analysis = Ar(8)

                End If

                Debug.WriteLine(Accountcode & " " & Amount & " " & Description)
                Dim r As DataRow = Dt1.NewRow()
                r(0) = MyDate
                r(1) = "JD"
                r(2) = "INV " & GetMonthDate(MyDate)
                r(3) = Accountcode
                r(4) = Accountcode
                r(5) = comment
                r(6) = Amount
                r(7) = "0.00"
                r(8) = "T2"



                Dt1.Rows.Add(r)

                '  Total = RoundMe2(Total + Amount, 2)

            Loop
            'Dim r2 As DataRow = Dt1.NewRow()
            'r2(0) = ""
            'r2(1) = ""
            'r2(2) = "Total Amount"
            'r2(3) = Total
            'r2(4) = ""
            'r2(5) = ""

            'Dt1.Rows.Add(r2)

            param_file.Close()
            param_file.Dispose()
            GC.Collect()
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetMonthDate(ByVal Str As String)
        Dim ar() As String
        ar = Str.Split("-")
        Dim Year As String
        Dim Month As String
        Year = ar(2)
        Month = ar(1)
        Dim SS As String
        Select Case Month
            Case "01"
                SS = "JAN"
            Case "02"
                SS = "FEB"
            Case "03"
                SS = "MAR"
            Case "04"
                SS = "APR"
            Case "05"
                SS = "MAY"
            Case "06"
                SS = "JUN"
            Case "07"
                SS = "JUL"
            Case "08"
                SS = "AUG"
            Case "09"
                SS = "SEP"
            Case "10"
                SS = "OCT"
            Case "11"
                SS = "NOV"
            Case "12"
                SS = "DEC"

        End Select
        SS = SS & " " & Year
        Return SS

    End Function
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("Date", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("TransType", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("InvoiceNo", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("RefAccount", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("NomAccount", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("Description", System.Type.GetType("System.String"))
        '6
        Dt1.Columns.Add("NetAmount", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("TaxAmount", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("TaxCode", System.Type.GetType("System.String"))
        




    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer
        If NewInterface Then
            '0
            HeaderStr.Add("Date")
            '1
            HeaderStr.Add("TransType")
            '2
            HeaderStr.Add("InvoiceNo")
            '3
            HeaderStr.Add("RefAccount")
            '4
            HeaderStr.Add("NomAccount")
            '5
            HeaderStr.Add("Description")
            '6
            HeaderStr.Add("NetAmount")
            '7
            HeaderStr.Add("TaxAmount")
            '8
            HeaderStr.Add("TaxCode")

            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            

        End If
        Loader.LoadIntoExcel(MyDs, HeaderStr, HeaderSize)





    End Sub




End Class