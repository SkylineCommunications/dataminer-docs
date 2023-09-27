---
uid: SLNetClientTest_setting_TTL_database
---

# Setting the TTL for database records

The "time to live" or TTL of database records can be updated via the SLNetClientTest tool.

> [!NOTE]
> We recommend that you configure this in DataMiner Cube instead. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *TTL*.

1. Under *Sync Type*, select whether you want the TTL to be applied to the *DMA* only or to the entire *DMS*.

1. Select the tab corresponding to the type of record for which a TTL will be specified:

   - *DataType*: Allows you to specify a TTL for specific data types, e.g. *Alarm*, *TimeTrace*, etc.

   - *LoggerTable*: Allows you to specify a TTL for a logger table. The name of the table must be specified in the *Table* box.

   - *Trending*: Allows you to specify a different TTL for real-time ("*RT*"), 5-minute, 1-hour and 1-day trending records.

   - *Protocol*: Allows you to specify overrides for a protocol. The name of the protocol must be specified in the *Protocol* box.

1. Specify the TTL:

   - To customize the default TTL, add a value (in seconds) in the *DefaultTTL* box.

   - To override the TTL for records in the general or "local" database, add a value (in seconds) in the *LocalTTL* box.

   - To override the TTL for records in the indexing database, add a value (in seconds) in the *IndexingTTL* box.

   - If you do not want to edit a particular field, just leave it blank.

1. Click *Update*.

> [!NOTE]
> To find out what the currently used TTL values are, run the *GetTTLRequest* via the message builder.

> [!TIP]
> See also: [DBMaintenance.xml and DBMaintenanceDMS.xml](xref:DBMaintenance_xml_and_DBMaintenanceDMS_xml#dbmaintenancexml-and-dbmaintenancedmsxml)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
