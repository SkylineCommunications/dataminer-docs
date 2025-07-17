---
uid: KI_MySQL_Unhandled_Exception
---

# Process crashes when trying to connect to MySQL database

## Affected versions

- DataMiner 10.3.0 [CU14] and higher
- DataMiner 10.4.0 [CU2] and higher
- DataMiner 10.4.5 and higher

## Cause

An issue in the MySQL.Data.dll version 8.0.33 and higher causes an unhandled exception to be thrown when the timeout is reached during the SSL/TLS authentication.

## Fix

Install DataMiner 10.3.0 [CU18], 10.4.0 [CU6], or 10.4.9<!--RN 40200-->.

## Workaround

If SSL/TLS is not required to connect to the database, you can add `sslmode=none` to the connection string for the database you are trying to connect to.

Alternatively, you can increase the timeout by adding `connectiontimeout=<waittime>` to the connection string for the database. However, this method may still fail, for instance if the packets are dropped.

For information on how to configure the connection string for each type of database, refer to the following pages:

- [MySQL database used for DataMiner storage](xref:Configuring_MySQL_database_in_Cube) (legacy)
- [MySQL offload database](xref:Setting_up_an_offload_database)
- [Other MySQL databases](xref:Configuring_an_additional_database)

For information on how to configure the connection string for specific connectors, look up the connector information in the [Catalog](https://catalog.dataminer.services/).

## Issue description

When trying to connect with an SQL database (version 5.6 or higher), the connection will attempt to use SSL encrypted traffic by default. An [issue in the MySQL connector](https://bugs.mysql.com/bug.php?id=115572) causes an unhandled exception that leads to problems in DataMiner processes (usually SLDataGateway and/or SLScripting), with the following exception in the *ERRORLOG.TXT*:

```txt
System.AggregateException: One or more errors occurred. ---> System.AggregateException: Authentication to host '<host>' failed. ---> System.IO.IOException: I/O error occurred.
   --- End of inner exception stack trace ---
   at MySql.Data.Common.Ssl.<StartSSLAsync>b__10_1()
```
