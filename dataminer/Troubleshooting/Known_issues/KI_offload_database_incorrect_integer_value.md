---
uid: KI_offload_database_incorrect_integer_value
keywords: central database
---

# Offload to MySQL offload database fails

## Affected versions

Any version of DataMiner

## Cause

If a MySQL offload database is used, the default configuration is incorrect: The option *STRICT_TRANS_TABLES* is enabled (**sql_mode**).

When this option is enabled, an error is returned when there are missing values in data change statements such as INSERT or UPDATE. Any remaining rows from the statement are then ignored. If data offloads contain missing data (e.g., a data point that was not stored because of an error in an element), this will cause this error to be triggered.

## Fix

Remove *STRICT_TRANS_TABLES* from **sql_mode** in the MySQL configuration.

## Description

Offloads to a MySQL offload database fail.

`SLDatabase[SLDataMiner].txt` shows errors similar to the example below:

```text
02-10 11:45:04.034|30|Start forwarding alarm records
02-10 11:45:04.772|30|Server Thread 4173 - Failure 1366='Incorrect integer value: '' for column 'iId' at row 1' for NonQuery 'LOAD DATA LOCAL INFILE 'C:\\Skyline DataMiner\\System Cache\\Offload\\dataavg\\2015_02_08_13_01_29.csv' REPLACE INTO TABLE dataavg FIELDS TERMINATED BY ' ' OPTIONALLY ENCLOSED by '"' ESCAPED BY '' LINES TERMINATED BY '
''
02-10 11:45:04.773|30|Failed forwarding data for 'dataavg' table: MySql.Data.MySqlClient.MySqlException (0x80004005): Incorrect integer value: '' for column 'iId' at row 1
   at Skyline.DataMiner.SLDatabase.SLDatabaseCOM.ForwardData(SLSql centralConnection, String data)
   at Skyline.DataMiner.SLDatabase.SLDatabaseCOM.ForwardData(SLSql centralConnection)
02-10 11:45:04.774|30|Done forwarding alarm records
```
