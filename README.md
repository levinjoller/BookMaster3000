# BookMaster3000
It's a library management tool called Bookmaster3000. This software tool consists of
a catalog, which can be used by customers and the staff to find books in the library. Another part is used to
track the circulation (lending and returning books).
* Exercise project "Bookmaster3000" for the [ICT Swiss Championship 2020 Switzerland](https://www.ict-berufsbildung.ch/berufsbildung/ict-berufsmeisterschaften/schweizermeisterschaft/)

## Build with
* C# Windows Forms (WinForms) application
* MSSQL server express
* Entity Framework v6.2.0

## Installation
* Insert the database backup (./BookMaster3000/db/Backup_Bookmaster.sql) into your local MSSQL server.
* Fill the database with sample data. (Sorry, I had to shrink the backup, because it was over 100MB)

NOTE:\
If you have another MSSQL version than express, the connection string in the App.config file must be adjusted.

## Author
Levin Joller