---
uid: Offload_database
---

# Offload database

If you set up your own offload or “central” database in your DataMiner System, that database will contain an offline copy of all (or some of) the data in the general DMA databases.

This offline database will then allow you, for instance, to produce all kinds of reports without interfering with the live DataMiner System. Even the most demanding database queries will not have any impact on the performance of your DMAs.

The following database types are supported for the offload database:

- MySQL

- MSSQL

- Oracle

> [!NOTE]
> From DataMiner 10.2.0/10.1.1 onwards, it is possible to offload data to a file in the local system cache folder instead of to an offload database. You can do so by going to System Center > *Database* > *Offload* and selecting *File* in the drop-down box at the top. Below this, you can then configure the data offloads (see [Configuring data offloads](xref:Configuring_data_offloads)) and set a maximum size for the combined offload files.
