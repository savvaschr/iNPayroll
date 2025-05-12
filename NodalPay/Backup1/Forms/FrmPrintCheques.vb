Public Class FrmPrintCheques

    Dim MyDs As DataSet
    Dim Dt1 As DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If CheckDataSet(MyDs) Then
            MyDs.Tables(0).Rows.Clear()
        End If

        Dim col_Name As Integer = 0
        Dim col_Description As Integer = 1
        Dim col_Amount1 As Integer = 2
        Dim col_Amount2 As Integer = 3
        Dim col_Y1 As Integer = 4
        Dim col_Y2 As Integer = 5
        Dim col_Y3 As Integer = 6
        Dim col_Y4 As Integer = 7
        Dim col_M1 As Integer = 8
        Dim col_M2 As Integer = 9
        Dim col_D1 As Integer = 10
        Dim col_D2 As Integer = 11
        Dim col_Word As Integer = 12

        Dim S As String = Format(Date1.Value.Date, "yyyy/MM/dd")
        Dim Y1 As String = S.Substring(0, 1)
        Dim Y2 As String = S.Substring(1, 1)
        Dim Y3 As String = S.Substring(2, 1)
        Dim Y4 As String = S.Substring(3, 1)
        Dim M1 As String = S.Substring(5, 1)
        Dim M2 As String = S.Substring(6, 1)
        Dim D1 As String = S.Substring(8, 1)
        Dim D2 As String = S.Substring(9, 1)


        Dim Amount As Double = Me.txtAmount.Text

        Dim Ar() As String
        Dim Net As String
        Net = Format(Amount, "0.00")
        Ar = Net.Split(".")


        Dim Amount1 As String
        Amount1 = Global1.Business.NumToWords(CInt(Ar(0)))
        Amount1 = UCase(Amount1) & " EURO "

        Dim Amount2 As String
        Amount2 = Global1.Business.NumToWords(CInt(Ar(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Dim r As DataRow = Dt1.NewRow()
        r(col_Name) = Me.txtName.Text
        r(col_Description) = Me.txtDescription.Text
        r(col_Amount1) = Ar(0)
        r(col_Amount2) = Ar(1)
        r(col_Y1) = Y1
        r(col_Y2) = Y2
        r(col_Y3) = Y3
        r(col_Y4) = Y4
        r(col_M1) = M1
        r(col_M2) = M2
        r(col_D1) = D1
        r(col_D2) = D2
        r(col_Word) = Amount1 & Amount2

        Dt1.Rows.Add(r)

        'Utils.WriteSchemaWithXmlTextWriter(MyDs, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\Printc")
        Dim reporttouse As String = "PrintCheque1.rpt"

        Utils.ShowReport(reporttouse, MyDs, FrmReport, "", False, "", False, False, "", False)
    End Sub
   
    Private Sub FrmPrintCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitDataGrid()
        Me.txtAmount.Text = 0
        AddHandler txtAmount.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtAmount.Leave, AddressOf Utils.NumericOnLeave
    End Sub
    Private Sub InitDataGrid()
        InitDataTable()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)

    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("Name", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("Description", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("Amount1", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Amount2", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Y1", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("Y2", System.Type.GetType("System.String"))
        '6
        Dt1.Columns.Add("Y3", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("Y4", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("M1", System.Type.GetType("System.String"))
        '9
        Dt1.Columns.Add("M2", System.Type.GetType("System.String"))
        '10
        Dt1.Columns.Add("D1", System.Type.GetType("System.String"))
        '11
        Dt1.Columns.Add("D2", System.Type.GetType("System.String"))
        '12
        Dt1.Columns.Add("tAmount", System.Type.GetType("System.String"))

    End Sub

End Class