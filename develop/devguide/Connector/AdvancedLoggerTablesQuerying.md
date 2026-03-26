---
uid: AdvancedLoggerTablesQuerying
---

# Querying logger tables

Data from a logger table should not be retrieved using methods defined in the SLProtocol interface (e.g., GetParameterIndexByKey), as not all table data is loaded in the SLProtocol process. In case there is a need to query the logged data, then the database itself should be queried.

In case you perform database queries, make sure these queries can be executed on both the RDBMS and Cassandra database. Alternatively, provide separate queries for the RDBMS and Cassandra database and execute them depending on the database type that is in use.

> [!NOTE]
> To check which database is in use, you can use the GetLocalDatabaseType method defined in the SLProtocol interface. For more information, refer to [SLProtocol.GetLocalDatabaseType](xref:Skyline.DataMiner.Scripting.SLProtocol.GetLocalDatabaseType) method.

Alternatively, you can use the GetPartialTableMessage SLNet message to retrieve data from a logger table. In this case, DataMiner will translate the message into a query for the database used.
