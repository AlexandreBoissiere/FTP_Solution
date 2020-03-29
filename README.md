# FTP_Solution
This repository gives you a ftp solution to create a ftp server/client in windows 10

To use this repository you have to :
- git clone the repository
- to copy the whole FTP_Server folder to the future ftp server
- to copy the whole FTP_Client folder to the future ftp client

Then execute the setup.exe file of each folder on the server (FTP_Server/Setup.exe) and on the clients (FTP_Client/Setup.exe)

After that, execute FTP_Server.exe on the server (the application use the port 5015, so verify if this port is available) and
FTP_Client.exe on the clients (the application use the port 5030, so verify if this port is available).

FTP_Client will ask you the server's IP Adress (you can get it by doing an ipconfig command in cmd.exe on the server) and then
choose a mode (write, read, append), give the filename of the file to use and filnally if you'va choosen write or append mode,
the application will ask you the text to write ot to append.
