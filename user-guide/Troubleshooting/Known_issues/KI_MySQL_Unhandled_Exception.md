---
uid: KI_MySQL_Unhandled_Exception
---

# Process crashes when trying to connect to MySQL database

## Affected versions

- DataMiner 10.3.0[CU14] and higher
- DataMiner 10.4.0[CU2] and higher
- DataMiner 10.4.5 and higher

## Cause

A bug in the MySQL.Data.dll version 8.0.33 and higher causes an unhandled exception to be thrown when the timeout is reached during the SSL/TLS-authentication.

## Fix

No fix at the time of writing

## Workaround

If SSL/TLS is not required to connect to the Database then you can add `sslmode=none` to the connectionString for the database you try to connect to.

Alternatively, you can increase the timeout to wait, by adding `connectiontimeout=<waittime>` to the connectionstring for that database. This method may still fail if for instance the packets are dropped.

See the following pages for help on how to configure the connectionstring for each type of database.

- [Local Database](xref:Configuring_MySQL_database_in_Cube)
- [Central Offload Database](xref:Setting_up_an_offload_database)
- [Named Databases](xref:Configuring_an_additional_database)
- Connectors: Please refer to the connector page on [Catalog](https://catalog.dataminer.services/) for more info

## Issue description

When trying to connect with an SQL database (version 5.6 and higher), the connection will attempt to use SSL encrypted traffic by default. A [bug in the MySQL connector](https://bugs.mysql.com/bug.php?id=115572) causes an unhandled exception that leads to process crashes with the following exception in the *ERRORLOG.TXT*

```txt
System.AggregateException: One or more errors occurred. ---> System.AggregateException: Authentication to host '<host>' failed. ---> System.IO.IOException: I/O error occurred.
   --- End of inner exception stack trace ---
   at MySql.Data.Common.Ssl.<StartSSLAsync>b__10_1()
```

Most commonly these crashes occur in SLDataGateway and SLScripting.
