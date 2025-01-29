---
uid: STaaS
description: With DataMiner Storage as a Service, you can connect your DataMiner System to a scalable, easy-to-use cloud-native storage platform.
keywords: cloud storage, storage in the cloud
---

# Storage as a Service (STaaS)

With DataMiner Storage as a Service, you can connect your DataMiner System to a scalable, easy-to-use **cloud-native storage platform**, without the effort of setting up and managing your own storage databases.

![STaaS](~/user-guide/images/STaaS.jpg)

Advantages of DataMiner Storage as a Service (STaaS) include:

- Fast, secure, and reliable storage

- Easy and flexible configuration

- Outstanding performance, scalability, and redundancy

- Cost-effectiveness

- Safe and secure data

> [!TIP]
> If you have any questions or need support with the STaaS feature, contact <staas@dataminer.services>.

## Setting up STaaS

For a self-hosted DataMiner System, follow the steps below to set up STaaS.

> [!NOTE]
>
> - This setup is not needed for [DataMiner as a Service (DaaS) systems](xref:Creating_a_DMS_in_the_cloud), as these automatically use STaaS.
> - If you want to add a DMA to an existing DMS that uses STaaS, refer to [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

1. [Upgrade your DataMiner System](xref:Upgrading_a_DataMiner_Agent) to DataMiner 10.4.0 [CU0]/10.4.1 or higher.

   > [!NOTE]
   > To be able to use non-indexed logger tables, upgrade to DataMiner 10.4.0 [CU5]/10.4.8 or higher. <!-- RN 40066 -->

   > [!IMPORTANT]
   > We recommend always upgrading DataMiner to the latest available version to get the latest features and performance updates.

1. Make sure your DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Make sure that all Agents in your DataMiner System have internet access and are able to reach the following endpoints, depending on the data location that will be used:

   - STaaS West Europe: 20.76.71.123
   - STaaS UK South: 20.162.131.128
   - STaaS Southeast Asia: 20.247.192.226

   > [!NOTE]
   > All communication for STaaS happens through HTTPS. The DataMiner System initiates all outbound connections.

1. Make sure you have at least **DataMiner CloudGateway 2.8.0** installed on the system. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

1. Register your system to use STaaS:

   1. Go to the [Admin app](https://admin.dataminer.services).

   1. In the sidebar on the left, go to *Organization* > *Overview*.
  
   1. In the *DataMiner Systems* section, click the system you want to register.
  
   1. At the top of the page, in the *Storage as a Service* box, click the button *Get Started with STaaS*.
  
   1. Fill in your preferred region and click *Initialize*.

   > [!IMPORTANT]
   > Only owners of a DataMiner System can register their system.

1. **Optionally**, [migrate your existing data to STaaS](#migrating-existing-data-to-staas).

   If you do so, wait until the migration has been completed and verified before continuing with this procedure.

1. On each DataMiner Agent in the cluster, in the `C:\Skyline DataMiner` folder, open *DB.xml* and edit it corresponding to your setup:

   - For setups **without proxy**, use the following configuration:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

   - For setups **with proxy** (this **requires DataMiner 10.4.5 or higher**<!-- RN 39221 -->), use the following configuration, filling in the fields as required:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
         <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage">
            <Proxy>
               <Address>[Enter Address Here]</Address>
               <Port>[Enter Port Here]</Port>
               <UserName>[Enter UserName Here]</UserName>
               <Password>[Enter Password Here]</Password>
            </Proxy>
         </DataBase>
      </DataBases>
      ```

      > [!NOTE]
      > If the proxy does not require authentication, you can leave the *UserName* and *Password* fields blank or remove them.

1. Restart DataMiner to begin using STaaS.

## Data location and redundancy

DataMiner STaaS relies on Azure Storage, which stores multiple copies of your data to make sure it is always available even in case outages or disasters occur. Different storage redundancy setups are possible. STaaS supports zone-redundant storage and geo-redundant storage. When you contact Skyline to register your system to use STaaS, you can include your preferences as to the region(s) where your data should be stored and the type of storage redundancy that should be used.

> [!NOTE]
> DataMiner STaaS's standard supported regions are West Europe (The Netherlands), UK South, North Central US, UAE North, Southeast Asia (Singapore), and Australia East. Choosing regions outside this standard list will incur additional charges.

- **Zone-redundant storage (ZRS)** copies your data synchronously across three Azure availability zones in one region. Each availability zone is a separate physical location with independent power, cooling, and networking. By **default**, DataMiner STaaS uses ZRS.

- **Geo-redundant storage (GRS)** copies your data synchronously three times within a single physical location in the primary region and then also copies your data asynchronously to a single physical location in the secondary region. Only specific regions can be combined in such a setup, e.g. if the primary region is Switzerland North, the secondary region can only be Switzerland West. For an overview of the supported regions, see [Azure paired regions](https://learn.microsoft.com/en-us/azure/reliability/cross-region-replication-azure#azure-paired-regions). GRS is **available upon request**, but will result in additional charges. If you wish to use DataMiner STaaS with GRS, contact <staas@dataminer.services>.

> [!TIP]
> For detailed information, see [Azure Storage redundancy on learn.microsoft.com](https://learn.microsoft.com/en-us/azure/storage/common/storage-redundancy)

## Data resilience and backups

To ensure data resilience for potential recovery scenarios, protecting against user errors and accidental changes, your data is backed up with a **granularity of 1 day**. Backups are stored for **30 days**.

- **Daily backups**: STaaS performs backups with a granularity of 1 day and maintains a 30-day rolling snapshot of your data.

- **Data restoration and support**: In the event a rollback is necessary, our support team will assist you. To submit a rollback request, contact the support team by sending an email to <staas@dataminer.services>. They will guide you through the necessary steps to ensure a successful data restoration.

## Data security and availability

With STaaS, the data for a specific DMS is isolated in a logical partition. You can only ever access the logical partition dedicated to your own DMS, and all partitions are strictly isolated from each other.

To access your data, you use a connection authenticated with a [Service Principal](https://learn.microsoft.com/en-us/entra/identity-platform/app-objects-and-service-principals?tabs=browser#service-principal-object). With this connection, you can only access the logical partition dedicated to a specific DMS, which means that all data of a DMS is strictly isolated.

The data is encrypted both at rest and in transit.

If [ZRS](#data-location-and-redundancy) is used, STaaS has an expected availability of 99.90%. With [GRS](#data-location-and-redundancy), it has an expected availability of 99.95%. For more information, please contact <sales@skyline.be>.

## TTL

It is not yet possible to configure time-to-live (TTL) values for STaaS. In the table below, you can find the default TTL values for each data type.

| Data type                | TTL          |
|--------------------------|:------------:|
| Real-time trending       | 7 days       |
| Average trending (short) | 3 months     |
| Average trending (medium)| 2 years      |
| Average trending (long)  | 10 years     |
| State changes            | 5 years      |
| Spectrum traces          | 1 year       |
| Alarm events             | 1 year       |

## Cost estimation

To request a cost estimation, follow the procedure below:

1. Follow the [setup procedure](#setting-up-staas) until you come to the step where you need to wait to receive confirmation of your registration.

1. Wait until you have received confirmation of your registration by email.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the DataMiner Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   > When you run the Automation script on a Failover pair, make sure the currently active Agent is the main Failover Agent (i.e. the first Agent in the Failover configuration). Otherwise, the Automation script will not function correctly.

1. Initialize the migration:

   1. Optionally, configure a proxy for the migration if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Init migration* to initialize the migration.

1. Start the migration:

   1. Make sure *Replication only* is selected.

   1. Select **all** data types.

      This way you will have the most accurate estimation of your system when running the script.

   1. Click *Start migration*.

1. Let the script run for 24 hours without restarting the DataMiner System (DMS).

1. After the 24-hour period, restart the DMS to stop the estimation process.

1. After this, at approximately 2 AM UTC, you will be able to view your cost estimation in the [Admin app](https://admin.dataminer.services), under *Overview* > *Usage* for the relevant organization.

   > [!NOTE]
   > You will only be able to see the *Usage* module if you are an Owner or Admin of the organization.

If you have any questions regarding this cost estimation, please contact <staas@dataminer.services>.

> [!IMPORTANT]
> Cost estimations can currently only be performed for the West Europe, UK South, and Southeast Asia regions.

> [!TIP]
> To optimize the cost efficiency of a STaaS solution, adhere to the best practices to prevent storing unnecessary data [with Automation scripts](xref:Automation_best_practices) or [with connectors](xref:Saving_parameters).

## Migrating existing data to STaaS

Before migrating your data over to STaaS, make sure you are aware of the [limitations](#limitations) for migration. Then follow the procedure below:

1. Follow the [setup procedure](#setting-up-staas) until you come to the step where you have received confirmation that the **registration is completed**.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the DataMiner Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   > When you run the Automation script on a Failover pair, make sure the currently active Agent is the main Failover Agent (i.e. the first Agent in the Failover configuration). Otherwise, the Automation script will not function correctly.

1. Initialize the migration:

   1. Optionally, configure a proxy for the migration if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Init migration* to initialize the migration.

1. Start the migration:

   - Make sure *Replication only* is **not** selected.

   - Select the desired storage types for migration.

     > [!NOTE]
     > For systems with a lot of real-time trending, we urge you to consider if you really need this data to be migrated. This data is typically only stored for 1 day, so when there is a lot of data, this gives an overhead on the rest of the types that need to be migrated, and this can cause the migration to take longer.

   - Click *Start migration* to start the migration.

   The script will initiate the migration process, but the migration itself will not be completed immediately.

1. To monitor the migration progress, run the *CloudStorageMigrationProgress* script.

   This will log the progress of the migration for each storage type as information events.

1. Keep an eye on the progress until the status for all storage types that were triggered shows **State=Completed**.

   This indicates that the migration has successfully finished.

> [!NOTE]
> In case of issues during or after the migration, revert the `DB.xml` file to its previous state and re-trigger the migration process. If you want to be certain no data inconsistencies are possible, contact [STaaS support](mailto:staas@dataminer.services).

## Deleting a system

When you [disconnect a system from dataminer.services](xref:Disconnecting_from_dataminer.services#permanently-disconnecting-from-dataminerservices) or [remove a DaaS system](xref:Removing_a_DaaS_system), all STaaS data for that specific system, including backups, will be removed 7 days after you take this action. Upon request, all STaaS data can be recovered within those 7 days.

## Limitations

To **migrate existing data** to STaaS, the following limitations apply:

- Migration is supported in 10.4.0 and the latest available 10.4.x feature release.

- Migration of a setup with multiple OpenSearch/Elasticsearch clusters is not yet supported.

- Migration from a MySQL setup is not yet supported.

- Migration using a proxy is supported from DataMiner 10.4.6 onwards<!-- RN 39313 -->.

- If you start the migration while an element with a logger table is stopped, the data of that element will not be migrated.

In addition, the following **other limitations** currently apply:

- [Jobs](xref:jobs), [Ticketing](xref:ticketing), and [API Deployment](xref:Overview_of_Soft_Launch_Options#apideployment) data are not supported.

- The following indexing engine functionality is not supported: Alarm Console search tab, search suggestions in the Alarm Console, aliases, and aggregation.

- Custom configuration of TTL values is not yet supported.

- Direct queries from DataMiner Cube to the database are not supported.

- The [SLReset tool](xref:Factory_reset_tool) is not supported.

- [Exporting trend data](xref:Exporting_elements_services_etc_to_a_dmimport_file) to a .dmimport file is not supported.

- DMZ setups are currently not supported.

- Adding a DataMiner Agent to a DMS using STaaS requires [additional manual configuration steps](xref:Adding_a_DMA_to_a_DMS_running_STaaS).

- Regarding logger tables:

  - The [autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement) tag is not supported.

  - [Indexed logger tables](xref:AdvancedLoggerTablesImplementation#indexed-logger-tables) can be created and read from the database, but advanced search queries with GQI are not supported.

  - [DirectConnection logger tables](xref:AdvancedLoggerTablesDefiningDirectConnectionTable) are not supported.

## Troubleshooting

For troubleshooting information related to STaaS, see [Troubleshooting – STaaS](xref:Troubleshooting_STaaS).

> [!NOTE]
> If you experience any issues during setup or while using Storage as a Service, and you cannot resolve these using the available troubleshooting information, contact <staas@dataminer.services>.
