---
uid: General_database
---

# General database

The general database is the main database used by a DataMiner Agent to store its data. By default, this is a Cassandra database. In legacy setups, a MySQL or MSSQL database can be used. In legacy systems, this database was also known as the "local database".

- For more information on how to configure this database in Cube, see [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

- For more information on the Cassandra database, including how to migrate from a legacy database to Cassandra, see [Cassandra database](xref:Cassandra_database).

> [!NOTE]
> It is not supported to have an external program do queries on the general database, regardless of the setup. Instead, the external program should retrieve the data from the offload database. See [Offload database](xref:Offload_database).

> [!TIP]
> See also:
>
> - [Securing the DataMiner databases](xref:Database_security)
> - [Cassandra – tips & tricks](https://community.dataminer.services/video/cassandra-tips-tricks/) on DataMiner Dojo
