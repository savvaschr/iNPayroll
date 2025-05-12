cd "C:\NodalWin"
del atestdb.bak
cd "C:\Program Files\Microsoft SQL Server\110\Tools\Binn"
SqlCmd -S DESKTOP-TS1J7BD -Q "Backup Database insoft To Disk='C:\nodalwin\atestdb.bak'"