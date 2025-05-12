Public Class FrmLoadJIRAFromExcel

    Dim Loading As Boolean = True
    Private Sub FrmLoadJIRAFromExcel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadComboTemplate()


    End Sub
    Private Sub LoadComboTemplate()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim Temp As New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
                    .Items.Add(Temp)
                Next
            End If
            .EndUpdate()
            Loading = False
            .SelectedIndex = 0
        End With

    End Sub
    
   

   
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFile.FileName <> "" Then
            CType(Me.Owner, FrmMain).GLBLoadingFromExcel_TemGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
           

            CType(Me.Owner, FrmMain).GLBProceedWithExcel_JIRA = True
            CType(Me.Owner, FrmMain).GLBLoadingFromExcel_JIRAExcelFileToOpen = OpenFile.FileName

            Me.Close()
        Else
            MsgBox("Please select valid File name to upload")
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        openfile.FileName = ""
        openfile.ShowDialog()
        Me.txtToFile.Text = openfile.FileName
    End Sub

    Private Sub ComboTempGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTempGroups.SelectedIndexChanged
        If Loading Then Exit Sub
        Dim TempGroup As String
        TempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
       

    End Sub
End Class
