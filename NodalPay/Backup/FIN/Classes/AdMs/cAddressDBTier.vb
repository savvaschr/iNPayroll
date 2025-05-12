Public Class cAddressDBTier
    Inherits cDataTier
    Protected Function GetById(ByVal Id As Integer) As Dataset
        Dim Str As String
        Str = "Select Adr_Id," & _
        " Adr_AltCode," & _
        " Adr_Type," & _
        " Adr_Line1," & _
        " Adr_Line2," & _
        " Adr_Line3," & _
        " Adr_Line4," & _
        " Adr_ZipCode," & _
        " Adr_Telephone1," & _
        " Adr_Telephone2," & _
        " Adr_Fax," & _
        " Adr_Email," & _
        " Adr_Remark1," & _
        " Adr_Remark2," & _
        " Adr_POBox," & _
        " Adr_ContactPerson," & _
        " Adr_WebSite," & _
        " Adr_OrderEmail," & _
        " Are_Id" & _
        " From AdMsAddress " & _
        " Where Adr_Id=" & Id
        Return MyBase.GetData(Str)
    End Function
    Protected Function Save(ByRef _cAddress As cAddress) As Boolean
        Dim SpParams As New ArrayList
        Dim SpNames As New ArrayList
        With _cAddress
            SpNames.Add("Adr_Id")               '0
            SpNames.Add("Adr_AltCode")          '1
            SpNames.Add("Adr_Type")             '2
            SpNames.Add("Adr_Line1")            '3
            SpNames.Add("Adr_Line2")            '4
            SpNames.Add("Adr_Line3")            '5
            SpNames.Add("Adr_Line4")            '6
            SpNames.Add("Adr_ZipCode")          '7
            SpNames.Add("Adr_Telephone1")       '8
            SpNames.Add("Adr_Telephone2")       '9
            SpNames.Add("Adr_Fax")              '10
            SpNames.Add("Adr_Email")            '11
            SpNames.Add("Adr_Remark1")          '12
            SpNames.Add("Adr_Remark2")          '13
            SpNames.Add("Adr_POBox")            '14
            SpNames.Add("Adr_ContactPerson")    '15
            SpNames.Add("Adr_WebSite")          '16
            SpNames.Add("Adr_OrderEmail")       '17
            SpNames.Add("Are_Id")               '18
            SpNames.Add("NewId integer")        '19

            SpParams.Add(.Id)                   '0
            SpParams.Add(.AltCode)              '1
            SpParams.Add(.MyType)               '2
            SpParams.Add(.Line1)                '3
            SpParams.Add(.Line2)                '4
            SpParams.Add(.Line3)                '5
            SpParams.Add(.Line4)                '6
            SpParams.Add(.ZipCode)              '7
            SpParams.Add(.Telephone1)           '8
            SpParams.Add(.Telephone2)           '9
            SpParams.Add(.Fax)                  '10
            SpParams.Add(.Email)                '11
            SpParams.Add(.Remark1)              '12
            SpParams.Add(.Remark2)              '13
            SpParams.Add(.POBox)                '14
            SpParams.Add(.Contactperson)        '15
            SpParams.Add(.WebSite)              '16
            SpParams.Add(.OrderEmail)           '17
            SpParams.Add(.AreaId)               '18
            SpParams.Add(CInt(0))               '19

        End With

        If Me.StoredProcedure("AdMsAddress_Save", SpParams, SpNames, 19) Then
            If _cAddress.Id = 0 Then
                _cAddress.Id = DbNullToInt(SpParams(19))
            End If
            Return True
        Else
            Return False
        End If
    End Function
End Class
