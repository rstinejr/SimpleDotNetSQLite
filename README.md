# SimpleDotNetSQLite

This tiny project illustrates using .NET Core to access a [SQLite](http://sqlite.org/) database. 


Even though this is a .NET Core project, when I have a project that includes
a database, I like to create and update
table definitions using a [DDL](http://whatis.techtarget.com/definition/Data-Definition-Language-DDL) 
script and a database utility. The script is saved in source control - it is the schema definition.

The [native SQLite package for .NET Core](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite) uses
the Microsoft Entity Framework. That is 
overkill for what I had in mind, but a little research turned up
[sqlite-net](https://github.com/praeclarum/sqlite-net). This package appears to be 
popular, ligthweight, and it is distributed under the MIT license.

Although lightweight, ```sqlite-net``` supports retrieval to annotated classes, rather than 
exposing SQL. Part of the goal of this project is to demonstrate using sqlite-net 
to access pre-existing tables, and to explore the mappings between sqlite-net and .NET Core data types.

## Set Up Your Environment

This project assumes that .NET Core and SQLite are installed.

## Installing .NET Core

Instructions for downloading and installing .NET Core are at https://dot.net.

For Windows developers, the community version of an outstanding IDE, Visual Studio, may also be unloaded from that site.

## Installing SQLite

SQLite is serverless. "Installing" SQLite is actually more a case of deploying a shell command,
[sqlite3](https://linux.die.net/man/1/sqlite3), that creates
files and structures memory appropriately.

On RHEL, sqlite can be installed using ```yum```.  My initial development environment,
however, is Windows 10, so I followed the instructions
on [How to Install Sqlite3 on Windows 10](http://www.configserverfirewall.com/windows-10/install-sqlite3-on-windows-10/)

Download the sqlite-tools zip file from the [SQLite Download site](https://www.sqlite.org/download.html).  Note
that you will use the 32-bit tool on 64-bit Windows.


# Creating the Database

To create the tables defined in DdlForDemo.sql, enter

```
    sqlite3 demo.db < DdlForDemo.sql
```

The database file in the above case is ```demo.db```. It will be created if it does
not exist, and the DDL in DdlForDemo.sql is executed. If ```demo.db`` is already
present, the command will attempt to update the database with the DDL.

# Dropping the Database

SQLite is a serverless database. You can drop a database by simply deleting the file (in this case, demo.db).

When mapping classes to tables, sqlite-net enforces a naming convention of initial caps for fields; build error
CS1002 occurs if this is violated.

# Run the Demo

Install .NET Core 2.0 and sqlite3. Then,

1. git clone https://github.com/rstinejr/SimpleDotNetSQLite.git
2. cd SimpleDotNetSQL
3. sqlite3 demo.db < DdlForDemo.sql
4. cd AccessSQLite
5. dotnet restore
6. dotnet build
7. dotnet run

Expected output:

```
Open database ../demo.db
Inserted 1 rows to Parent
Wrote 3 rows to Child.

Select rows from table 'Child' where Parent_fk == 1:
Selected rows from table 'Child':
1 | 1 | Detail 1
2 | 1 | Detail 2
3 | 1 | Detail 3

Execute a join:
Result set from query:
1 | 1 | 1.234 | Detail 1
1 | 2 | 1.234 | Detail 2
1 | 3 | 1.234 | Detail 3

Demo is complete.

```

# Build Notes

I initially built this project on 64-bit Windows 10 with dotnet 2.0.
To avoid complaints about incompatibility with netcoreapp2.0, I had to use version 1.5.166-beta of sqlite-net.


I have also built and run this project on CentOS 7.4 and Linux Mint 17.2.


# Postscript: Installing sqlite-net

If you want to add *sqlite-net* to an existing .NET project, your project will need the NuGet package. 

One way to update your csproj file for this is to enter:


```
    dotnet add package sqlite-net-pcl
```

See [www.nuget.org](https://www.nuget.org/packages/sqlite-net-pcl).
