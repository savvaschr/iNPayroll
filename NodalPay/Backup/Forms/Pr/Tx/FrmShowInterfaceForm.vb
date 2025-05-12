Public Class FrmShowInterfaceForm
    Dim MyDs As DataSet
    Dim Dt1 As DataTable
    Dim MyDs_dc As DataSet
    Dim Dt1_dc As DataTable
    Public FileName As String
    Public NewInterface As Boolean
    Public DC As Boolean = False
    Private Sub FrmShowInterfaceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not DC Then
            DG1.Visible = True
            DG2.Visible = False
            InitDataTable()
            InitDataGrid()
            LoadFileIntoGrid()

        Else
            DG2.Visible = True
            DG1.Visible = False
            InitDataTable_DC()
            InitDataGrid_DC()
            LoadFileIntoGrid_DC()

        End If
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
            Dim MyDate As String
            Dim Total As Double = 0
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
                    myDate = Ar(9)
                Else
                    Accountcode = Ar(4)
                    Amount = Ar(7)
                    Description = Ar(6)
                    analysis = Ar(8)

                End If

                Debug.WriteLine(Accountcode & " " & Amount & " " & Description)
                Dim r As DataRow = Dt1.NewRow()
                r(0) = Counter
                r(1) = Accountcode
                r(2) = Description
                r(3) = Amount
                r(4) = analysis
                r(5) = MyDate

                Dt1.Rows.Add(r)

                Total = RoundMe2(Total + Amount, 2)

            Loop
            Dim r2 As DataRow = Dt1.NewRow()
            r2(0) = ""
            r2(1) = ""
            r2(2) = "Total Amount"
            r2(3) = Total
            r2(4) = ""
            r2(5) = ""

            Dt1.Rows.Add(r2)

            param_file.Close()
            param_file.Dispose()
            GC.Collect()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("LineNo", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("AccountNo", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("Description", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Amount", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Analysis", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("MyDate", System.Type.GetType("System.String"))
        
    End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer
        If Not DC Then
            If NewInterface Then
                HeaderStr.Add("Line")
                HeaderStr.Add("Account Code")
                HeaderStr.Add("Account Description")
                HeaderStr.Add("Amount")
                HeaderStr.Add("My Date")

                HeaderSize.Add(10)
                HeaderSize.Add(30)
                HeaderSize.Add(30)
                HeaderSize.Add(20)
                HeaderSize.Add(20)
            Else
                HeaderStr.Add("Line")
                HeaderStr.Add("Account Code")
                HeaderStr.Add("Account Description")
                HeaderStr.Add("Amount")

                HeaderSize.Add(10)
                HeaderSize.Add(30)
                HeaderSize.Add(30)
                HeaderSize.Add(20)
            End If
            Loader.LoadIntoExcel(MyDs, HeaderStr, HeaderSize)

        Else
            HeaderStr.Add("Line")
            HeaderStr.Add("Emp.Code")
            HeaderStr.Add("Amount")
            HeaderStr.Add("Debit")
            HeaderStr.Add("Credit")
            HeaderStr.Add("Date")

            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            Loader.LoadIntoExcel(MyDs_dc, HeaderStr, HeaderSize)

        End If


       
    End Sub
    Private Sub LoadFileIntoGrid_DC()

        Dim Line As String

        Try
            Dim Exx As New Exception
            Dim HeaderLine As String
            Dim param_file As IO.StreamReader
            param_file = IO.File.OpenText(FileName)
            Dim Ar() As String
            Dim Counter As String
            Dim EmployeeCode As String
            Dim Amount As String
            Dim Debit As String
            Dim Credit As String
            Dim MyDate As String
            Dim Total As Double

            Do While param_file.Peek <> -1
                Counter = Counter + 1
                System.Windows.Forms.Application.DoEvents()
                Line = param_file.ReadLine()
                Ar = Line.Split("|||")

                Counter = Ar(0)
                EmployeeCode = Ar(3)
                Amount = Ar(6)
                Debit = Ar(9)
                Credit = Ar(12)
                MyDate = Ar(15)

                Dim r As DataRow = Dt1_dc.NewRow()

                r(0) = Counter
                r(1) = EmployeeCode
                r(2) = Amount
                r(3) = Debit
                r(4) = Credit
                r(5) = MyDate

                Dt1_dc.Rows.Add(r)

                total = total + Amount

            Loop
            Dim r2 As DataRow = Dt1_dc.NewRow()
            r2(0) = ""
            r2(1) = "Total Amount"
            r2(2) = total
            r2(3) = ""
            r2(4) = ""
            r2(5) = ""

            Dt1_dc.Rows.Add(r2)

            param_file.Close()
            param_file.Dispose()
            GC.Collect()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub InitDataGrid_DC()
        MyDs_dc = New DataSet
        MyDs_dc.Tables.Add(Dt1_dc)
        DG2.DataSource = MyDs_dc.Tables(0)
    End Sub
    Private Sub InitDataTable_DC()
        Dt1_dc = New DataTable("Table1")
        '0
        Dt1_dc.Columns.Add("LineNo", System.Type.GetType("System.String"))
        '1
        Dt1_dc.Columns.Add("EmployeeCode", System.Type.GetType("System.String"))
        '2
        Dt1_dc.Columns.Add("Amount", System.Type.GetType("System.String"))
        '3
        Dt1_dc.Columns.Add("Debit", System.Type.GetType("System.String"))
        '4
        Dt1_dc.Columns.Add("Credit", System.Type.GetType("System.String"))
        '5
        Dt1_dc.Columns.Add("MyDate", System.Type.GetType("System.String"))

    End Sub

  
End Class