---
uid: STaaS_features
description: STaaS takes care of data redundancy, data resilience, data security, and data availability out of the box.
reviewer: Alexander Verkest
---

# STaaS features

## Data location and redundancy

DataMiner STaaS relies on Azure Storage, which stores multiple copies of your data to make sure it is always available even in case outages or disasters occur. Different storage redundancy setups are possible. STaaS supports zone-redundant storage (ZRS) and geo-redundant storage (GRS).

When you use the installation wizard or [contact Skyline](mailto:support@dataminer.services) to register your system to use STaaS, you can include your preferences as to the region(s) where your data should be stored and the type of storage redundancy that should be used.

| Region           | Location             | Status                                                     | [Geo-Redundancy Pair](https://learn.microsoft.com/en-us/azure/reliability/cross-region-replication-azure#azure-paired-regions) for GRS ([on request](mailto:support@dataminer.services?Subject=GRS%20for%20STaaS)) |
|------------------|----------------------|------------------------------------------------------------|----------------------------------|
| West Europe      | The Netherlands      | Live                                                       | North Europe (Ireland)           |
| UK South         | London, UK           | Live                                                       | UK West (Cardiff)                |
| Central US       | Iowa, USA            | Live                                                       | East US 2 (Virginia)             |
| Southeast Asia   | Singapore            | Live                                                       | East Asia (Hong Kong SAR)        |
| UAE North        | Dubai, UAE           | [On request](mailto:support@dataminer.services?Subject=UAE%20North%20for%20STaaS) (no extra charge) | UAE Central (Abu Dhabi) |
| Australia East   | New South Wales, AUS | [On request](mailto:support@dataminer.services?Subject=Australia%20East%20for%20STaaS) (no extra charge) | Australia Southeast (Victoria) |
| Other Regions    | [See full list](https://learn.microsoft.com/en-us/azure/reliability/regions-list) | Supported [on request](mailto:support@dataminer.services?Subject=Other%20region%20for%20STaaS) (extra cost) | [See full list](https://learn.microsoft.com/en-us/azure/reliability/regions-list) |

- **Zone-redundant storage (ZRS)** copies your data synchronously across three Azure availability zones in one region. Each availability zone is a separate physical location with independent power, cooling, and networking. By **default**, DataMiner STaaS uses ZRS.

- **Geo-redundant storage (GRS)** copies your data synchronously three times within a single physical location in the primary region and then also copies your data asynchronously to a single physical location in the secondary region. Only specific regions can be combined in such a setup, e.g. if the primary region is Switzerland North, the secondary region can only be Switzerland West. For an overview of the supported regions, see [Azure paired regions](https://learn.microsoft.com/en-us/azure/reliability/cross-region-replication-azure#azure-paired-regions). GRS is **available upon request**, but will result in additional charges. If you wish to use DataMiner STaaS with GRS, contact <support@dataminer.services>.

> [!TIP]
> For detailed information, see [Azure Storage redundancy on learn.microsoft.com](https://learn.microsoft.com/en-us/azure/storage/common/storage-redundancy)

## Data resilience and backups

To ensure data resilience for potential recovery scenarios, protecting against user errors and accidental changes, your data is backed up with a **granularity of 1 day**. Backups are stored for **30 days**.

- **Daily backups**: STaaS performs backups with a granularity of 1 day and maintains a 30-day rolling snapshot of your data.

- **Data restoration and support**: In the event a rollback is necessary, our support team will assist you. To submit a rollback request, contact the support team by sending an email to <support@dataminer.services>. They will guide you through the necessary steps to ensure a successful data restoration.

> [!IMPORTANT]
> When you [disconnect a system from dataminer.services](xref:Disconnecting_from_dataminer.services#permanently-disconnecting-from-dataminerservices) or [remove a DaaS system](xref:Removing_a_DaaS_system), all STaaS data for that specific system, including backups, will be removed 7 days after you take this action. Upon request, all STaaS data can be recovered within those 7 days.

## Data security and availability

With STaaS, the data for a specific DMS is isolated in a logical partition. You can only ever access the logical partition dedicated to your own DMS, and all partitions are strictly isolated from each other.

To access your data, you use a connection authenticated with a [Service Principal](https://learn.microsoft.com/en-us/entra/identity-platform/app-objects-and-service-principals?tabs=browser#service-principal-object). With this connection, you can only access the logical partition dedicated to a specific DMS, which means that all data of a DMS is strictly isolated.

The data is encrypted both at rest and in transit.

If [ZRS](#data-location-and-redundancy) is used, STaaS has an expected availability of 99.90%. With [GRS](#data-location-and-redundancy), it has an expected availability of 99.95%. For more information, please contact <sales@skyline.be>.

## TTL

In the table below, you can find the default time-to-live (TTL) values for each data type.

| Data type                | TTL          |
|--------------------------|:------------:|
| Real-time trending       | 7 days       |
| Average trending (short – default 5 min.) | 3 months     |
| Average trending (medium – default 1 hour)| 2 years      |
| Average trending (long – default 2 hours)  | 10 years     |
| State changes            | 5 years      |
| Spectrum traces          | 1 year       |
| Alarm events             | 1 year       |

Custom configuration of TTL values can be requested via a [support ticket](xref:User_operations_support).

## Throttling

If your system is pushing too much load for a specific data type, that data type will be throttled. This could for example happen when you have an element that is continuously saving parameter updates.

From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!-- RN 42387 -->, when this happens, an alarm will be generated in Cube with information about the data type or types that are being throttled. For example:

![ThrottlingAlarmExample](~/dataminer/images/throttling_alarm_example.png)

If you encounter such an alarm, to ensure smooth operation of your DataMiner System, try to identify and resolve the root cause of this higher load. For assistance with this investigation, please contact <support@dataminer.services>.

## Limitations

To **migrate existing data** to STaaS, the following limitations apply:

- Migration is supported from DataMiner 10.4.0 [CU2]/10.4.5 onwards.<!-- RN 38884 -->

- Migration of a setup with multiple OpenSearch/Elasticsearch clusters is not yet supported.

- Direct migration from a MySQL setup is not supported. We recommend using .dmimport files (also known as "DELT export packages") to migrate your data, or [contacting support](xref:Contacting_tech_support) for assistance with the migration.

- Migration using a proxy is supported from DataMiner 10.4.6 onwards<!-- RN 39313 -->.

- If you start the migration while an element with a logger table is stopped, the data of that element will not be migrated.

In addition, the following **other limitations** currently apply:

- [Jobs](xref:jobs), [Ticketing](xref:ticketing), and [obsolete API Deployment](xref:Verify_No_Obsolete_API_Deployed) data are not supported.

- The following indexing engine functionality is not supported: Alarm Console search tab, search suggestions in the Alarm Console, aliases, and aggregation.

- Direct queries from DataMiner Cube to the database are not supported.

- The [SLReset tool](xref:Factory_reset_tool) is not supported.

- [Exporting trend data](xref:Exporting_elements_services_etc_to_a_dmimport_file) to a .dmimport file (also known as a "DELT export") is not supported.

- DMZ setups are currently not supported.

- Adding a DataMiner Agent to a DMS using STaaS requires [additional manual configuration steps](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

- Regarding logger tables:

  - The [autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement) tag is not supported.

  - [Indexed logger tables](xref:AdvancedLoggerTablesImplementation#indexed-logger-tables) can be created and read from the database, but search queries with GQI are not supported.

  - [DirectConnection logger tables](xref:AdvancedLoggerTablesDefiningDirectConnectionTable) are not supported.
