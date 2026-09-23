---
metadata_version: 1
uid: AdvancedDataMinerDataPersistence
description: "Describe the DataMiner connector development topic DataMiner data persistence, including its purpose, behavior, implementation guidance, and relevant cons."
---

# DataMiner data persistence

This section provides information on the persistent storage in DataMiner and on how to make data persist.

In DataMiner, alarms, trend data and information events are automatically kept in the general or “local” database (either an RDBMS or a NoSQL database). Parameter values are not kept in the database by default, though there are a few exceptions.

In this section:

- <xref:AdvancedDataMinerDataPersistenceStandaloneParameters>
- <xref:AdvancedDataMinerDataPersistencePersistingTables>
- <xref:AdvancedDataMinerDataPersistenceRdbms>
- <xref:AdvancedDataMinerDataPersistenceNoSqlCassandra>
