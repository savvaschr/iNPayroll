Public Class cExcelLoader
    Private xl As Object
    Private wbs As Object
    Private wb As Object
    Private wss As Object
    Private ws As Object
    Private rng As Object
    Private xlFound As Boolean = False
    Private BlankArrayList As New ArrayList
    Private MaxColumns As Integer = 40
    Private mDefaultColumnWidth As Integer = 10
    Private mDateFormat As String = "dd/mm/yyyy"
    Private mWorksheetCount As Integer
    Private mPrintOrientation As String = "L"
    Private mPrintMaxPages As Integer = 100
    Private mWorksheetName As String = "InsoftData"
    Private mPrintFooter As String = "SC INSOFT LTD - iNPayroll " & CStr(System.DateTime.Today)
    Private mMaxRecords As Integer = 65000
    Public Property DefaultColumnWidth() As Integer
        Get
            Return mDefaultColumnWidth
        End Get
        Set(ByVal Value As Integer)
            mDefaultColumnWidth = Value
        End Set
    End Property
    Public Property MaxRecords() As Integer
        Get
            Return mMaxRecords
        End Get
        Set(ByVal Value As Integer)
            mMaxRecords = Value
        End Set
    End Property
    Public Property PrintMaxPages() As Integer
        Get
            Return mPrintMaxPages
        End Get
        Set(ByVal Value As Integer)
            mPrintMaxPages = Value
        End Set
    End Property
    Public Property WorkSheetCount() As Integer
        Get
            Return mWorksheetCount
        End Get
        Set(ByVal Value As Integer)
            mWorksheetCount = Value
        End Set
    End Property
    Public Property DateFormat() As String
        Get
            Return mDateFormat
        End Get
        Set(ByVal Value As String)
            mDateFormat = Value
        End Set
    End Property
    Public Property WorksheetName() As String
        Get
            Return mWorksheetName
        End Get
        Set(ByVal Value As String)
            mWorksheetName = Value
        End Set
    End Property

    Public Property PrintFooter() As String
        Get
            Return mPrintFooter
        End Get
        Set(ByVal Value As String)
            mPrintFooter = Value
        End Set
    End Property
    Public Property PrintOrientation() As String
        Get
            Return mPrintOrientation
        End Get
        Set(ByVal Value As String)
            If Value = "L" Or Value = "P" Then
                mPrintOrientation = Value
            Else
                MsgBox("Orientation must be set to 'L' or 'P'")
            End If
        End Set
    End Property
    Public Sub New()
        If StartExcel() Then
            xlFound = True
        Else
            MsgBox("Error : No Excel Application detected")
        End If
    End Sub
    Private Function StartExcel() As Boolean
        Try
            xl = CreateObject("Excel.Application")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub LoadIntoExcel(ByVal ds As DataSet, Optional ByVal HeaderStr As ArrayList = Nothing, Optional ByVal HeaderSize As ArrayList = Nothing)
        Dim dsArrayStr(,) As String
        Dim dsArrayNum(,) As Double
        Dim dsArrayDat(,) As Date
        Dim RCount As Integer
        Dim CCount As Integer
        Dim RCounter As Integer
        Dim CCounter As Integer
        Dim VBAType As String
        If xlFound = False Then Exit Sub
        If Not CheckDataSet(ds) Then
            MsgBox("Values not found - Dataset not validated : Excel Load aborted")
        Else
            Try
                RCount = ds.Tables(0).Rows.Count
                If RCount > mMaxRecords Then
                    RCount = mMaxRecords
                    Me.mPrintFooter = Me.mPrintFooter & " Max Records has been exceeded"
                    Me.mWorksheetName = Me.mWorksheetName & "_Max Records Exceeded"
                End If
                CCount = ds.Tables(0).Columns.Count
                If CCount > mMaxRecords Then
                    CCount = MaxColumns
                    Me.mPrintFooter = Me.mPrintFooter & " Max Columns has been exceeded"
                    Me.mWorksheetName = Me.mWorksheetName & "_Max Columns Exceeded"
                End If
                ReDim dsArrayStr(RCount, 0)
                ReDim dsArrayNum(RCount, 0)
                ReDim dsArrayDat(RCount, 0)
                wbs = xl.Workbooks
                wb = wbs.Add
                wss = wb.worksheets
                ws = wss.Add
                For CCounter = 0 To CCount - 1
                    VBAType = GetVBAType(ds.Tables(0).Columns(CCounter).DataType.ToString)
                    For RCounter = 0 To RCount - 1
                        Debug.WriteLine(RCounter)
                        Select Case LCase(VBAType)
                            Case Is = "str"
                                dsArrayStr(RCounter, 0) = DbNullToString(ds.Tables(0).Rows(RCounter).Item(CCounter).ToString)
                            Case Is = "num"
                                dsArrayNum(RCounter, 0) = DbNullToDouble(ds.Tables(0).Rows(RCounter).Item(CCounter))
                            Case Is = "dat"
                                dsArrayDat(RCounter, 0) = DbNullToDate(ds.Tables(0).Rows(RCounter).Item(CCounter))
                            Case Else
                                dsArrayStr(RCounter, 0) = DbNullToString(ds.Tables(0).Rows(RCounter).Item(CCounter).ToString)
                        End Select
                    Next RCounter
                    rng = ws.Range(GetExcelColumn(CCounter + 1) & "1")
                    rng.Font.Bold = True

                    If HeaderStr Is Nothing Then
                        rng.Value = ds.Tables(0).Columns(CCounter).ToString
                    Else
                        If CCounter < HeaderStr.Count Then
                            rng.Value = HeaderStr(CCounter).ToString
                        Else
                            rng.Value = ds.Tables(0).Columns(CCounter).ToString
                        End If
                    End If

                    If HeaderSize Is Nothing Then
                        rng.ColumnWidth = Me.mDefaultColumnWidth
                    Else
                        If CCounter < HeaderSize.Count Then
                            If CCounter < HeaderStr.Count Then
                                If Len(HeaderStr(CCounter)) > CInt(HeaderSize(CCounter)) Then
                                    rng.ColumnWidth = Len(HeaderStr(CCounter))
                                Else
                                    'rng.ColumnWidth = Me.mDefaultColumnWidth
                                    rng.ColumnWidth = CInt(HeaderSize(CCounter).ToString)
                                End If
                            Else
                                rng.ColumnWidth = CInt(HeaderSize(CCounter).ToString)
                            End If
                        Else
                            rng.ColumnWidth = Me.mDefaultColumnWidth
                        End If
                    End If
                    rng = ws.Range(GetExcelColumn(CCounter + 1) & "2")
                    rng = rng.Resize(RCount, 1)
                    Select Case LCase(VBAType)
                        Case Is = "str"
                            rng.Value = dsArrayStr
                        Case Is = "num"
                            rng.Value = dsArrayNum
                        Case Is = "dat"
                            rng.Value = dsArrayDat
                            rng.NumberFormat = Me.mDateFormat
                        Case Else
                            rng.Value = dsArrayStr
                    End Select
                Next CCounter
                ws.PageSetup.LeftFooter = mPrintFooter
                If mPrintOrientation = "P" Then
                    ws.PageSetup.Orientation = 1
                Else
                    ws.PageSetup.Orientation = 2
                End If
                ws.PageSetup.Zoom = False
                ws.PageSetup.FitToPagesWide = 1
                ws.PageSetup.FitToPagesTall = PrintMaxPages
                ws.PageSetup.PaperSize = 9
                ws.PageSetup.CenterHeader = "Page &P of &N"
                ws.PageSetup.PrintTitleRows = "$1:$1"
                ws.Name = mWorksheetName




                xl.Visible = True





            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("An error occurred loading data to Excel")
            End Try
        End If
    End Sub

    Private Function GetVBAType(ByVal dbType As String) As String
        Select Case LCase(dbType)
            Case Is = "system.string"
                Return "str"
            Case Is = "system.datetime"
                Return "dat"
            Case Is = "system.int32"
                Return "num"
            Case Is = "system.int16"
                Return "num"
            Case Is = "system.byte"
                Return "str"
            Case Is = "system.boolean"
                Return "str"
            Case Is = "system.smalldatetime"
                Return "dat"
            Case Is = "system...."
                Return ""
            Case Is = "system....."
                Return ""
            Case Is = "system.double"
                Return "num"
            Case Else
                Return "str"
        End Select
    End Function
    Private Function GetExcelColumn(ByVal ColNo As Integer) As String
        ' Function required because interlope does not support Intersect, Column Transformations .....

        Select Case ColNo
            Case Is = 1
                Return "A"
            Case Is = 2
                Return "B"
            Case Is = 3
                Return "C"
            Case Is = 4
                Return "D"
            Case Is = 5
                Return "E"
            Case Is = 6
                Return "F"
            Case Is = 7
                Return "G"
            Case Is = 8
                Return "H"
            Case Is = 9
                Return "I"
            Case Is = 10
                Return "J"
            Case Is = 11
                Return "K"
            Case Is = 12
                Return "L"
            Case Is = 13
                Return "M"
            Case Is = 14
                Return "N"
            Case Is = 15
                Return "O"
            Case Is = 16
                Return "P"
            Case Is = 17
                Return "Q"
            Case Is = 18
                Return "R"
            Case Is = 19
                Return "S"
            Case Is = 20
                Return "T"
            Case Is = 21
                Return "U"
            Case Is = 22
                Return "V"
            Case Is = 23
                Return "W"
            Case Is = 24
                Return "X"
            Case Is = 25
                Return "Y"
            Case Is = 26
                Return "Z"
            Case Is = 27
                Return "AA"
            Case Is = 28
                Return "AB"
            Case Is = 29
                Return "AC"
            Case Is = 30
                Return "AD"
            Case Is = 31
                Return "AE"
            Case Is = 32
                Return "AF"
            Case Is = 33
                Return "AG"
            Case Is = 34
                Return "AH"
            Case Is = 35
                Return "AI"
            Case Is = 36
                Return "AJ"
            Case Is = 37
                Return "AK"
            Case Is = 38
                Return "AL"
            Case Is = 39
                Return "AM"
            Case Is = 40
                Return "AN"
            Case Is = 41
                Return "AO"
            Case Is = 42
                Return "AP"
            Case Is = 43
                Return "AQ"
            Case Is = 44
                Return "AR"
            Case Is = 45
                Return "AS"
            Case Is = 46
                Return "AT"
            Case Is = 47
                Return "AU"
            Case Is = 48
                Return "AV"
            Case Is = 49
                Return "AW"
            Case Is = 50
                Return "AX"
            Case Is = 51
                Return "AY"
            Case Is = 52
                Return "AZ"
            Case Is = 53
                Return "BA"
            Case Is = 54
                Return "BB"
            Case Is = 55
                Return "BC"
            Case Is = 56
                Return "BD"
            Case Is = 57
                Return "BE"
            Case Is = 58
                Return "BF"
            Case Is = 59
                Return "BG"
            Case Is = 60
                Return "BH"
            Case Is = 61
                Return "BI"
            Case Is = 62
                Return "BJ"
            Case Is = 63
                Return "BK"
            Case Is = 64
                Return "BL"
            Case Is = 65
                Return "BM"
            Case Is = 66
                Return "BN"
            Case Is = 67
                Return "BO"
            Case Is = 68
                Return "BP"
            Case Is = 69
                Return "BQ"
            Case Is = 70
                Return "BR"
            Case Is = 71
                Return "BS"
            Case Is = 72
                Return "BT"
            Case Is = 73
                Return "BU"
            Case Is = 74
                Return "BV"
            Case Is = 75
                Return "BW"
            Case Is = 76
                Return "BX"
            Case Is = 77
                Return "BY"
            Case Is = 78
                Return "BZ"
            Case Is = 79
                Return "CA"
            Case Is = 80
                Return "CB"
            Case Is = 81
                Return "CC"
            Case Is = 82
                Return "CD"
            Case Is = 83
                Return "CE"
            Case Is = 84
                Return "CF"
            Case Is = 85
                Return "CG"
            Case Is = 86
                Return "CH"
            Case Is = 87
                Return "CI"
            Case Is = 88
                Return "CJ"
            Case Is = 89
                Return "CK"
            Case Is = 90
                Return "CL"
            Case Is = 91
                Return "CM"
            Case Is = 92
                Return "CN"
            Case Is = 93
                Return "CO"
            Case Is = 94
                Return "CP"
            Case Is = 95
                Return "CQ"
            Case Is = 96
                Return "CR"
            Case Is = 97
                Return "CS"
            Case Is = 98
                Return "CT"
            Case Is = 99
                Return "CU"
            Case Is = 100
                Return "CV"
            Case Is = 101
                Return "CW"
            Case Is = 102
                Return "CX"
            Case Is = 103
                Return "CY"
            Case Is = 104
                Return "CZ"
            Case Is = 105
                Return "DA"
            Case Is = 106
                Return "DB"
            Case Is = 107
                Return "DC"
            Case Is = 108
                Return "DD"
            Case Is = 109
                Return "DE"
            Case Is = 110
                Return "DF"
            Case Is = 111
                Return "DG"
            Case Is = 112
                Return "DH"
            Case Is = 113
                Return "DI"
            Case Is = 114
                Return "DJ"
            Case Is = 115
                Return "DK"
            Case Is = 116
                Return "DL"
            Case Is = 117
                Return "DM"
            Case Is = 118
                Return "DN"
            Case Is = 119
                Return "DO"
            Case Is = 120
                Return "DP"
            Case Is = 121
                Return "DQ"
            Case Is = 122
                Return "DR"
            Case Is = 123
                Return "DS"
            Case Is = 124
                Return "DT"
            Case Is = 125
                Return "DU"
            Case Is = 126
                Return "DV"
            Case Is = 127
                Return "DW"
            Case Is = 128
                Return "DX"
            Case Is = 129
                Return "DY"
            Case Is = 130
                Return "DZ"
            Case Is = 131
                Return "EA"
            Case Is = 132
                Return "EB"
            Case Is = 133
                Return "EC"
            Case Is = 134
                Return "ED"
            Case Is = 135
                Return "EE"
            Case Is = 136
                Return "EF"
            Case Is = 137
                Return "EG"
            Case Is = 138
                Return "EH"
            Case Is = 139
                Return "EI"
            Case Is = 140
                Return "EJ"
            Case Is = 141
                Return "EK"
            Case Is = 142
                Return "EL"
            Case Is = 143
                Return "EM"
            Case Is = 144


            Case Else
                Return "DZ"
        End Select
    End Function
End Class
