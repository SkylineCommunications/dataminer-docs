---
uid: STaaS
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

1. [Upgrade your DataMiner System](xref:Upgrading_a_DataMiner_Agent) to version 10.3.10 [CU1] or higher.

   > [!IMPORTANT]
   > We recommend always upgrading DataMiner to the latest available version to get the latest features and performance updates.

1. Make sure your DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Make sure you have at least **DataMiner CloudGateway 2.8.0** installed on the system. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

1. Contact your Skyline representative or <staas@dataminer.services> to register you system to use STaaS.

1. Wait until you receive confirmation that the registration is completed.

1. **Optionally**, contact your Skyline representative or <staas@dataminer.services> to migrate your existing data to STaaS.

1. On each DataMiner Agent in the cluster, in the `C:\Skyline DataMiner` folder, open *DB.xml* and edit it to look like this:

   ```xml
   <?xml version="1.0"?>
   <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
      <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
   </DataBases>
   ```

1. Restart DataMiner to begin using STaaS.

## Limitations

To **migrate existing data** to STaaS, the following limitations apply:

- If you migrate from a Cassandra database, logger tables cannot be migrated yet. Support for the migration of logger tables will be introduced in a future DataMiner version.
- Migration of an OpenSearch or Elasticsearch database that is defined in [DBConfiguration.xml](xref:DBConfiguration_xml) instead of [DB.xml](xref:DB_xml) (e.g. because a setup with multiple OpenSearch/Elasticsearch clusters is used) is not yet supported.
- Migration from a MySQL setup is not yet supported.

In addition, the following **other limitations** currently apply:

- [Jobs](xref:jobs), [Ticketing](xref:ticketing), and [API Deployment](xref:Overview_of_Soft_Launch_Options#apideployment) data are not supported.

- The following indexing engine functionality is not supported: Alarm Console search tab, search suggestions in the Alarm Console, aliases, and aggregation.

- Direct queries from DataMiner Cube to the database are not supported.

- The [SLReset tool](xref:Factory_reset_tool) is not supported.

- [Exporting trend data](xref:Exporting_elements_services_etc_to_a_dmimport_file) to a .dmimport file is not supported.

- Proxy and DMZ setups are currently not supported.

- The [autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement) tag on logger tables is not supported.

- DOM queries can be slower depending on the number of DOM records and the complexity of the query. This limitation will be removed in the near future.

## Troubleshooting

> [!NOTE]
> If you experience any issues during setup or while using Storage as a Service, and you cannot resolve these with the procedures below, contact <staas@dataminer.services>.

### Cloud connection lost

Under normal circumstances, CloudGateway refreshes the cloud session automatically. However, if **CloudGateway is down for longer than three days**, for example because the server is down, the cloud session will become invalid. This will cause DataMiner startup to fail.

When you encounter this issue, you will find entries similar to the examples below in the SLDBConnection.txt log file:

`2023/10/02 14:04:23.458|SLDBConnection|SLCloudStorage|INF|0|6|2023-10-02T14:04:23.442|FATAL|DataGateway.CloudStorage.CloudStorage|CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "The Service Principal of this DMS is expired (3/14/2023 8:09:51 AM +00:00) but should soon be refreshed automatically." }`

`2023/10/02 14:05:33.981|SLDBConnection|SLCloudStorage|INF|0|6|2023-10-02T14:05:33.980|FATAL|DataGateway.CloudStorage.CloudStorage|CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing GetCcaGatewayConfigRequest. ---> System.AggregateException: One or more errors occurred. ---> DataMinerMessageBroker.API.Exceptions.SubscriptionException: No responders are available for the request. ---> NATS.Client.NATSNoRespondersException: No responders are available for the request.`

To resolve this issue, use the following workaround:

1. [Open SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

1. [Connect to the DMA with SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool)

1. Select *Offline Tools* > *CcaGateway (offline)* > *Renew cloud session* and complete the renew process.

   > [!NOTE]
   > As the renewal of the Service Principal (SP) token is managed by a cloud service, it can take a few minutes before the renewal is fully synced.

1. Wait a few minutes and then restart the DMA.The issue should be resolved now.

> [!NOTE]
> If you have a DataMiner System consisting of multiple DMAs, it is sufficient to do this on one of the DMAs.

### API Deployment Manager failed to initialize

When the [APIDeployment](xref:Overview_of_Soft_Launch_Options#apideployment) option is still enabled in *SoftLaunchOptions.xml*, the following alarm will be shown in Cube:

```txt
APIDeploymentManager failed to initialize, retrying. Check SLAPIDeploymentManager.txt for additional information.
```

In the SLDBConnection.txt log file, the error will look like this:

```txt
2023/10/10 20:30:18.308|SLDBConnection|SLDataGateway.Repositories|INF|0|354|2023-10-10T20:30:18.302|ERROR|Repository.RepositoryStorageProvider.DeployerToken|Refreshing storage [failed]: SLDataGateway.API.Types.Exceptions.StorageTypeNotFoundException: No storage type found for DataType: DeployerToken
```

To resolve this issue, remove the [APIDeployment](xref:Overview_of_Soft_Launch_Options#apideployment) option from *SoftLaunchOptions.xml*.

### Connector-specific issues

Some connector versions may contain a bug that causes a lot of parameter sets to be saved to the database. In the interest of saving cost and reducing load, we therefore **recommend using the latest version** available for most connectors.

This issue is known to occur with the following connector versions:

- [Microsoft Platform](https://catalog.dataminer.services/result/driver/251): 1.1.2.x, 1.2.0.x, 1.2.1.1
