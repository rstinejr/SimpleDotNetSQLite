# SimpleDotNetSQLite
A tiny project that illustrates creating a SQLite database and accessing it with .NET Core

This project illustrates using .NET Core to access a [SQLite](http://sqlite.org/) database. 

When I have a project that includes a database, I like to create and update
table definitions using a [DDL](http://whatis.techtarget.com/definition/Data-Definition-Language-DDL) 
script and a database utility. The script is saved in source control - it is the schema definition.

# Installing SQLite

On RHEL, sqlite can be installed using ```yum```.  My initial development environment,
however, is Windows 10, so I followed the instructions
on [How to Install Sqlite3 on Windows 10)[http://www.configserverfirewall.com/windows-10/install-sqlite3-on-windows-10/]

Download the sqlite-tools zip file from the [SQLite Download site](https://www.sqlite.org/download.html).  Note that you will use the 32-bit tool on Windows 10: SQLite is not server based. The
tool will successfully format the SQLite data files even on a 64-bit machine.

