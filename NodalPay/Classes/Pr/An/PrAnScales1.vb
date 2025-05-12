Public Class cPrAnScales1
    '
    Inherits cPrAnScales1DbTier
    '
    Private mSc1_Code As String
    Private mSc1_Description As String
    Public Property Sc1_Code() As String
        Get
            Return mSc1_Code
        End Get
        Set(ByVal Value As String)
            mSc1_Code = Value
        End Set
    End Property
    Public Property Sc1_Description() As String
        Get
            Return mSc1_Description
        End Get
        Set(ByVal Value As String)
            mSc1_Description = Value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal Dr As DataRow)
        If Not Dr Is Nothing Then
            LoadDataRow(Dr)
        End If
    End Sub
    Public Sub New(ByVal tSc1_Code As String)
        If tSc1_Code <> "" Then
            Init(tSc1_Code)
        End If
    End Sub
    Private Sub Init(ByVal tSc1_Code As String)
        Try
            Dim ds As DataSet
            ds = MyBase.GetByPK(tSc1_Code)
            If CheckDataSet(ds) Then
                LoadDataRow(ds.Tables(0).Rows(0))
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    Private Sub LoadDataRow(ByVal dr As DataRow)
        mSc1_Code = DbNullToString(dr.Item(0))
        mSc1_Description = DbNullToString(dr.Item(1))
    End Sub
    Public Shadows Function Delete(ByVal tSc1_Code As String) As Boolean
        Try
            Dim Counter As Integer
            Dim TableCount As Integer
            Dim RecordCount As Integer
            Dim TransStr As String = ""
            Dim ds As DataSet
            ds = MyBase.CheckDeleteRecords(tSc1_Code)
            If CheckDataSet(ds) Then
                For Counter = 0 To ds.Tables.Count - 1
                    TableCount = TableCount + 1
                    RecordCount = RecordCount + DbNullToInt(ds.Tables(Counter).Rows(0).Item(0))
                    TransStr = TransStr & vbCrLf & "Table " & TableCount & "  Records " & RecordCount
                Next Counter
                If RecordCount = 0 Then
                    Return MyBase.Delete(tSc1_Code)
                Else
                    MsgBox("Transactions Exist For This item - Can not Delete" & TransStr, MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Failed to confirm that no records exist for this item - Can not Delete")
                Return False
            End If
        Catch ex As System.Exception
        End Try
    End Function
    '
    Public Shadows Function Save() As Boolean
        Try
            Return MyBase.Save(Me)
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Overrides Function ToString() As String
        Return Me.Sc1_Code & " - " & Me.Sc1_Description
    End Function
End Class

