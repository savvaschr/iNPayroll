cd "C:\NodalWin\DB"
del NodPrLax.bak
cd "C:\Program Files\Microsoft SQL Server\150\Tools\Binn"
SqlCmd -S FILESERVER -Q "Backup Database NodPrLax To Disk='C:\nodalwin\DB\NodPrLax.bak'"