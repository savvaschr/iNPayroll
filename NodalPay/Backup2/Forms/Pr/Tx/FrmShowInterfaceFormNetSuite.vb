Public Class FrmShowInterfaceFormNetSuite


    Dim MyDs As DataSet
    Dim Dt1 As DataTable
 
    Public FileName As String
    Public NewInterface As Boolean
    Dim GLBSubsidiary As String = ""

    Private Sub FrmShowInterfaceFormNetSuite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DG1.Visible = True
        GLBSubsidiary = "57"
        Dim P As New cPrSsParameters("NetSuite", "Subsidiary")
        If P.Id <> 0 Then
            GLBSubsidiary = P.Value1

        End If




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
            Dim MyDate As String
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
                r(0) = Counter
                r(1) = MyDate
                r(2) = GetMonthDate(MyDate)
                r(3) = GLBSubsidiary
                r(4) = analysis
                r(5) = "EUR"
                r(6) = comment
                r(7) = Accountcode
                If Amount < 0 Then
                    Credit = RoundMe2(Amount * -1, 2)
                    Debit = 0
                Else
                    Credit = 0
                    Debit = Amount
                End If
                r(8) = Debit
                r(9) = Credit
                r(10) = "64"


                Dim Arr() As String
                Dim EmployeeCode As String
                Dim NetSuiteEmpCode As String = ""
                employeeCode = Ar(60)
                Arr = EmployeeCode.Split("-")
                If Arr(1) <> "" Then
                    Dim Emp As New cPrMsEmployees(Arr(1))
                    NetSuiteEmpCode = Emp.Emp_GLAnal4
                End If
                r(11) = NetSuiteEmpCode


                r(12) = analysis3
                r(13) = analysis4
                r(14) = comment


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
        Dt1.Columns.Add("EntryNo", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("Date", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("PostingPeriod", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Subsidiary", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Department", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("Currency", System.Type.GetType("System.String"))
        '6
        Dt1.Columns.Add("Memo", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("Account", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("Debit", System.Type.GetType("System.String"))
        '9
        Dt1.Columns.Add("Credit", System.Type.GetType("System.String"))
        '10
        Dt1.Columns.Add("Taxcode", System.Type.GetType("System.String"))
        '11
        Dt1.Columns.Add("Name", System.Type.GetType("System.String"))
        '12
        Dt1.Columns.Add("Class", System.Type.GetType("System.String"))
        '13
        Dt1.Columns.Add("BusinessUnit", System.Type.GetType("System.String"))
        '14
        Dt1.Columns.Add("Comments", System.Type.GetType("System.String"))
       



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        Dim i As Integer
        If NewInterface Then
            HeaderStr.Add("EntryNo")
            '1
            HeaderStr.Add("Date")
            '2
            HeaderStr.Add("PostingPeriod")
            '3
            HeaderStr.Add("Subsidiary")
            '4
            HeaderStr.Add("Department")
            '5
            HeaderStr.Add("Currency")
            '6
            HeaderStr.Add("Memo")
            '7
            HeaderStr.Add("Account")
            '8
            HeaderStr.Add("Debit")
            '9
            HeaderStr.Add("Credit")
            '10
            HeaderStr.Add("Taxcode")
            '11
            HeaderStr.Add("Name")
            '12
            HeaderStr.Add("Class")
            '13
            HeaderStr.Add("Business Unit")
            '14
            HeaderStr.Add("Comments")


            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
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