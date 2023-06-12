---
uid: MySQL_database
---

# MySQL database

On legacy DataMiner Systems, typically a MySQL (or MSSQL) database is used as the general database. For the currently supported DataMiner versions, a Cassandra database is preferred instead. Though DataMiner can still be used with a MySQL or MSSQL database, [switching to Cassandra](xref:Migrating_the_general_database_to_Cassandra) is highly recommended as it leads to enhanced performance, and certain DataMiner features are only available if a Cassandra database is used.

> [!IMPORTANT]
> MSSQL is no longer supported as the general database as from DataMiner 10.3.0.

> [!NOTE]
> For more information on how to query a MySQL database, see [Querying an SQL database](xref:Querying_an_SQL_database) and [Querying a Cassandra database compared to MySQL](xref:Querying_Cassandra_vs_MySQL).