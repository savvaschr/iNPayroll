Module FTP
    Function Transfer( _
        ByVal sRemoteHost As String, _
        ByVal sRemotePath As String, _
        ByVal sRemoteUser As String, _
        ByVal sRemotePassword As String, _
        ByVal iRemotePort As Integer, _
        ByVal localFilename As String) As Boolean

        Dim Success As Boolean = False
        Dim ff As clsFTP

        Try
            ff = New clsFTP(sRemoteHost, sRemotePath, sRemoteUser, sRemotePassword, iRemotePort)
            If (ff.Login() = True) Then
                'Change the directory on your FTP site.
                'If Not (ff.ChangeDirectory("MyOwnFolder") = True) Then
                '    Throw New Exception("FTP: Unable to change the directory to '" & myownfolder & "'")
                'End If
            Else
                Throw New Exception("FTP: Login failed")
            End If

            Dim sFile() As String
            sFile = localFilename.Split("\"c)

            Dim sFilename As String
            sFilename = sFile(UBound(sFile))

            If ff.FileExists(sFilename) Then
                If Global1.ShowMessages Then
                    MessageBox.Show("A file with the same name exists on the remote server.", "Tranfer File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ff.SetBinaryMode(True)
                ff.UploadFile(localFilename)

                ff.CloseConnection()
                Success = True
            End If

        Catch ex As Exception
            ShowException(ex)
        End Try

        Return Success
    End Function

    Private Sub TestFTP()

        'Create an instance of the FTP class that is created.
        Dim ff As clsFTP

        Try
            'Pass values to the constructor. These values can be overridden by setting 
            'the appropriate properties on the instance of the clsFTP class.
            'The third parameter is the user name. The FTP site is accessed with the user name.
            'If there is no specific user name, the user name can be anonymous.
            'The fourth parameter is the password. The FTP server is accessed with the password.
            'The fifth parameter is the port of the FTP server. The port of the FTP server is typically 21.

            ff = New clsFTP("10.0.0.100", "", "root", "root", 21)
            'ff = New clsFTP(StrIP, _
            '                "/Myfolder/", _
            '                "anonymous", _
            '                "", _
            '                21)


            'Try to log on to the FTP server.
            If (ff.Login() = True) Then
                'Change the directory on your FTP site.
                If (ff.ChangeDirectory("MyOwnFolder") = True) Then
                    'Successful changing the directory
                    Console.WriteLine("Changed the directory to the directory that was specified" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    Throw New Exception("FTP: Unable to change the directory")
                End If
                'Create a directory on your FTP site under the previous directory. 
                If (ff.CreateDirectory("FTPFOLDERNEW") = True) Then
                    'Successful creating the directory
                    Console.WriteLine("A new folder has been created" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    'Unsuccessful creating the directory
                    Console.WriteLine("A new folder has not been created" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                End If
                'Change the directory on your FTP site under the directory that is specified.
                If (ff.ChangeDirectory("FTPFOLDERNEW") = True) Then
                    'Successful changing the directory
                    Console.WriteLine("Changed the directory to the directory that was specified" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    'Unsuccessful changing the directory
                    Console.WriteLine("Unable to change the directory that was specified" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                End If

                ff.SetBinaryMode(True)

                'Upload a file from your local hard disk to the FTP site.
                ff.UploadFile("C:\Test\Example1.txt")
                ff.UploadFile("C:\Test\Example2.doc")
                ff.UploadFile("C:\Test\Example3.doc")

                'Download a file from the FTP site to your local hard disk.
                ff.DownloadFile("Example2.doc", "C:\Test\Example2.doc")

                ' Remove a file from the FTP site.
                If (ff.DeleteFile("Example1.txt") = True) Then
                    'Successful removing the file on the FTP site
                    Console.WriteLine("File has been removed from the FTP site" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    'Unsuccessful removing the file on the FTP site
                    Console.WriteLine("Unable to remove the file on the FTP site" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                End If

                'Rename a file on the FTP site.
                If (ff.RenameFile("Example3.doc", "Example3_new.doc")) Then
                    'Successful renaming the file on the FTP site
                    Console.WriteLine("File has been renamed" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    'Unsuccessful renaming the file on the FTP site
                    Console.WriteLine("File has not been renamed" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                End If
                'Change the directory to one directory before.
                If (ff.ChangeDirectory("..") = True) Then
                    'Successful changing the directory
                    Console.WriteLine("Changed the directory to one directory before" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                Else
                    'Unsuccessful changing the directory
                    Console.WriteLine("Unable to change the directory" + vbCrLf)
                    Console.WriteLine("Press 'ENTER'")
                    Console.ReadLine()
                End If
            End If
            'Create a new directory.
            If (ff.CreateDirectory("MyOwnFolderNew") = True) Then
                'Successful creating the directory
                Console.WriteLine("A new folder has been created" + vbCrLf)
                Console.WriteLine("Press 'ENTER'")
                Console.ReadLine()
            Else
                'Unsuccessful creating the directory
                Console.WriteLine("A new folder has not been created" + vbCrLf)
                Console.WriteLine("Press 'ENTER'")
                Console.ReadLine()
            End If
            'Remove the directory that is created on the FTP site.
            If (ff.RemoveDirectory("MyOwnFolderNew")) Then
                'Successful removing the directory on the FTP site
                Console.WriteLine("Directory has been removed" + vbCrLf)
                Console.WriteLine("Press 'ENTER'")
                Console.ReadLine()
            Else
                'Unsuccessful removing the directory on the FTP site
                Console.WriteLine("Unable to remove the directory" + vbCrLf)
                Console.WriteLine("Press 'ENTER'")
                Console.ReadLine()

            End If



        Catch ex As System.Exception
            'Display the error message. 
            Console.WriteLine("Specific Error=" & ex.Message + vbCrLf)
            Console.WriteLine("Press 'ENTER' to EXIT")
            Console.ReadLine()

        Finally
            'Always close the connection to make sure that there are not any not-in-use FTP connections.
            'Check if you are logged on to the FTP server and then close the connection.

            If ff.flag_bool = True Then
                ff.CloseConnection()
            End If

        End Try
    End Sub
    Function DownLoad( _
    ByVal sRemoteHost As String, _
    ByVal sRemotePath As String, _
    ByVal sRemoteUser As String, _
    ByVal sRemotePassword As String, _
    ByVal iRemotePort As Integer, _
    ByVal localFilename As String, _
    ByVal DeleteFile As Boolean) As Boolean

        Dim Success As Boolean = False
        Dim ff As clsFTP
        Dim sFile() As String
        Dim sFilename As String
        Try
            ff = New clsFTP(sRemoteHost, sRemotePath, sRemoteUser, sRemotePassword, iRemotePort)
            If Not (ff.Login() = True) Then
                Throw New Exception("FTP: Login failed")
            End If


            sFile = localFilename.Split("\"c)


            sFilename = sFile(UBound(sFile))

            If ff.FileExists(sFilename) Then
                ff.SetBinaryMode(True)
                ff.DownloadFile(sFilename, localFilename, True)
                If DeleteFile Then
                    ff.DeleteFile(sFilename)
                End If
                '   ff.DeleteFile(sFilename)
                ' ff.CloseConnection()
                Success = True
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

        Return Success
    End Function
    Function CheckIfFileExists( _
        ByVal sRemoteHost As String, _
        ByVal sRemotePath As String, _
        ByVal sRemoteUser As String, _
        ByVal sRemotePassword As String, _
        ByVal iRemotePort As Integer, _
        ByVal localFilename As String) As Boolean

        Dim FileExists As Boolean = False
        Dim ff As clsFTP

        Try
            ff = New clsFTP(sRemoteHost, sRemotePath, sRemoteUser, sRemotePassword, iRemotePort)
            If (ff.Login() = True) Then
                'Change the directory on your FTP site.
                'If Not (ff.ChangeDirectory("MyOwnFolder") = True) Then
                '    Throw New Exception("FTP: Unable to change the directory to '" & myownfolder & "'")
                'End If
            Else
                Throw New Exception("FTP: Login failed")
            End If

            Dim sFile() As String
            sFile = localFilename.Split("\"c)

            Dim sFilename As String
            sFilename = sFile(UBound(sFile))

            If ff.FileExists(sFilename) Then
                fileexists = True
            End If
        Catch ex As Exception

        End Try
        Return FileExists
    End Function
End Module


