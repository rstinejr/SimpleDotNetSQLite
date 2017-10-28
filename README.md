# SimpleDotNetSQLite
A tiny project that illustrates creating a SQLite database and accessing it with .NET Core

This project illustrates using .NET Core to access a [SQLite](http://sqlite.org/) database. 


Even though this is a .NET Core project, when I have a project that includes
a database, I like to create and update
table definitions using a [DDL](http://whatis.techtarget.com/definition/Data-Definition-Language-DDL) 
script and a database utility. The script is saved in source control - it is the schema definition.

The [native SQLite package for .NET Core](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite) uses the Microsoft Entity Framework. That is 
overkill for what I had in mind, but a little research turned up
[sqlite-net](https://github.com/praeclarum/sqlite-net). This package appears to be 
popular, ligthweight, and it is distributed under the MIT license.

Although lightweight, ```sqlite-net``` supports retrieval to annotated classes, rather than 
exposing SQL. Part of the goal of this project is to demonstrate using sqlite-net 
to access pre-existing tables, and to explore the mappings between sqlite-net and .NET Core data types.

## Set Up Your Environment

This package assumes that .NET Core, the SQLite and libraries, and the sqlite-net NuGet package are installed.

## Installing .NET Core

.NET Core may be downloaded from https://dot.net.

For Windows developers, the community version of an outstanding IDE, Visual Studio, may also be unloaded from that site.

## Installing SQLite

SQLite is serverless. "Installing" SQLite is actually more a case of deploying a shell command,
[sqlite3](https://linux.die.net/man/1/sqlite3), that can create
files and structure memory appropriately.

On RHEL, sqlite can be installed using ```yum```.  My initial development environment,
however, is Windows 10, so I followed the instructions
on [How to Install Sqlite3 on Windows 10)[http://www.configserverfirewall.com/windows-10/install-sqlite3-on-windows-10/]

Download the sqlite-tools zip file from the [SQLite Download site](https://www.sqlite.org/download.html).  Note that you will use the 32-bit tool on Windows 10: SQLite is not server based. The
tool will successfully format the SQLite data files even on a 64-bit machine.


To run the sqlite-net client, you will also need the native SQLite shared library installed. These are also available
from the SQLite Download Site.

## Installing sqlite-net

The .NET Core interface *sqlite-net* is a NuGet package. Instructions for installing it are
at [www.nuget.org](https://www.nuget.org/packages/sqlite-net-pcl). To install, e.g., version
1.4.118 from the command line,


```
    dotnet add package sqlite-net-pcl --version 1.4.118
```

# Creating the Database

To create the tables defined in DemoDB.sql, enter

```
    sqlite3 demo.db < DdlForDemo.sql
```

The database file in the above case is ```demo.db```. It will be created if it does
not exist, and the DDL in DdlForDemo.sql is executed. If ```demo.db`` is already
present, the command will attempt to update the database with the DDL.

# Dropping the Database

SQLite is a serverless database. You can drop a database by simply deleting the file (e.g., demo.db).

