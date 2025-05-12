Public Class cPrMsEmployeePhotoDBTier
    Inherits cDataTier
    '
    Protected Function GetByPK(ByVal tCode As String) As DataSet
        Dim Str As String
        Str = " SELECT" &
                " Emp_Code," &
                " Emp_Image " &
            "  FROM PrMsEmployeePhoto" &
            "  WHERE Emp_Code = '" & tCode & "'"
        Return MyBase.GetData(Str)

    End Function
    Protected Function Save(ByVal _cPrMsEmployeePhoto As cPrMsEmployeePhoto, ByVal SavePhoto As Boolean) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        Dim Flag As Boolean = False
        With _cPrMsEmployeePhoto
            SpParams.Add(.Code)                                              '(0)
            SpNames.Add("Emp_Code")                                          '(0)


            If Not SavePhoto Then
                .MyPhoto = My.Resources.photo
            End If
            Dim ms As New System.IO.MemoryStream()
            Dim bmpImage As New Bitmap(.MyPhoto)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()

            SpParams.Add(data)                               '(1)
            SpNames.Add("Emp_Image")                             '(1)


        End With
        If Me.StoredProcedure("PrMsEmployeePhoto_Save_Update", SpParams, SpNames) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
