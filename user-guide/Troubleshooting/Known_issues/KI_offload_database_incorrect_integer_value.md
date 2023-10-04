---
uid: KI_offload_database_incorrect_integer_value
---

# Offload Database Incorrect Integer Value

## Affected versions

Any version of DataMiner

## Cause

The option *STRICT_TRANS_TABLES* is enabled in MySQL (**sql_mode**). This is by design.

## Fix

Remove *STRICT_TRANS_TABLES* from **sql_mode** in the MySQL configuration.

## Description

Offload to the central database fails due to a configuration in the offload database (MySQL)

SLDatabase[SLDataMiner].txt shows error like:

```text
02-10 11:45:04.034|30|Start forwarding alarm records
02-10 11:45:04.772|30|Server Thread 4173 - Failure 1366='Incorrect integer value: '' for column 'iId' at row 1' for NonQuery 'LOAD DATA LOCAL INFILE 'C:\\Skyline DataMiner\\System Cache\\Offload\\dataavg\\2015_02_08_13_01_29.csv' REPLACE INTO TABLE dataavg FIELDS TERMINATED BY ' ' OPTIONALLY ENCLOSED by '"' ESCAPED BY '' LINES TERMINATED BY '
''
02-10 11:45:04.773|30|Failed forwarding data for 'dataavg' table: MySql.Data.MySqlClient.MySqlException (0x80004005): Incorrect integer value: '' for column 'iId' at row 1
   at Skyline.DataMiner.SLDatabase.SLDatabaseCOM.ForwardData(SLSql centralConnection, String data)
   at Skyline.DataMiner.SLDatabase.SLDatabaseCOM.ForwardData(SLSql centralConnection)
02-10 11:45:04.774|30|Done forwarding alarm records
```
