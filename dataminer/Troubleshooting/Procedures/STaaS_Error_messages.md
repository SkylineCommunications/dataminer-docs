---
uid: STaaS_Error_messages
keywords: cloud storage, cloud errors
---

# STaaS error messages

## The DMS is not connected to dataminer.services

If a system is trying to use STaaS but is not connected to dataminer.services, DataMiner will not be able to start up.

The following error message will be present in the *SLCloudStorage.txt* log file:

```txt
CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "This DMS is not Cloud Registered." }
```

To connect your system to dataminer.services, refer to [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

### The DMS is not registered to use STaaS

If a system is trying to use STaaS while it is not registered to use STaaS, DataMiner will not be able to start up.

The following error message will be present in the *SLCloudStorage.txt* log file:

```txt
CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing a EndpointInfoAsync. (Failed to EndpointInfoAsync. (404))
```

To register your system, follow the procedure to [set up STaaS](xref:Setting_up_StaaS).

## CloudGateway is not running correctly

If a system is trying to use STaaS but the CloudGateway DxM is not running or not running correctly, DataMiner will not be able to start up.

The following error message will be present in the *SLCloudStorage.txt* log file:

```txt
CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing GetCcaGatewayConfigRequest. ---> System.AggregateException: One or more errors occurred. ---> DataMinerMessageBroker.API.Exceptions.SubscriptionException: No subscriber for the subject 'Skyline.Dataminer.Proto.CcaGatewayTypes.GetCcaGatewayConfigRequest' found. Check the process that should handle the request. ---> NATS.Client.NATSNoRespondersException: No responders are available for the request.
```

To resolve this issue, go to Task Manager and restart the *DataMiner CloudGateway* service.

## The session token has expired

Under normal circumstances, CloudGateway refreshes the cloud session automatically. However, if **CloudGateway is down for longer than six days**, for example because the server is down, the cloud session will become invalid. This will cause DataMiner startup to fail for systems using STaaS.

When you encounter this issue, you will find entries similar to the examples below in the *SLCloudStorage.txt* log file:

```txt
CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "The Service Principal of this DMS is expired (3/14/2023 8:09:51 AM +00:00) but should soon be refreshed automatically." }
```

```txt
CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing GetCcaGatewayConfigRequest. ---> System.AggregateException: One or more errors occurred. ---> DataMinerMessageBroker.API.Exceptions.SubscriptionException: No responders are available for the request. ---> NATS.Client.NATSNoRespondersException: No responders are available for the request.
```

To resolve this issue:

1. [Open SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool) on the DMA.

   > [!WARNING]
   > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

1. Select *Offline Tools* > *CcaGateway (offline)* > *Renew cloud session* and complete the renew process.

   > [!NOTE]
   > As the renewal of the Service Principal (SP) token is managed by a cloud service, it can take a few minutes before the renewal is fully synced.

1. Wait a few minutes and then restart the DMA.

   The issue should now be resolved.

> [!NOTE]
> If the DataMiner System consists of multiple DMAs, it is sufficient to do this on one of the DMAs.

## STaaS is unreachable

If STaaS is unreachable for some reason, the following error message will be shown in the Alarm Console:

![Error in Alarm Console](~/dataminer/images/STaaS_troubleshooting_Alarm_Console.png)

DataMiner will automatically initiate offload mode, ensuring that no data loss occurs. While this error is displayed in the Alarm Console, **do not restart** the system or any of its elements.

This issue typically resolves itself.

## The API Deployment Manager failed to initialize

If the obsolete *APIDeployment* [soft-launch option](xref:SoftLaunchOptions) is enabled in *SoftLaunchOptions.xml*, the following alarm will be shown in DataMiner Cube:

```txt
APIDeploymentManager failed to initialize, retrying. Check SLAPIDeploymentManager.txt for additional information.
```

In the *SLDBConnection.txt* log file, you will find this error:

```txt
2023/10/10 20:30:18.308|SLDBConnection|SLDataGateway.Repositories|INF|0|354|2023-10-10T20:30:18.302|ERROR|Repository.RepositoryStorageProvider.DeployerToken|Refreshing storage [failed]: SLDataGateway.API.Types.Exceptions.StorageTypeNotFoundException: No storage type found for DataType: DeployerToken
```

The *APIDeployment* option is obsolete and is **not supported** on systems using STaaS. To resolve this issue, remove the option from *SoftLaunchOptions.xml*.

## Connector-specific issues

Some connector versions may contain a bug that causes a lot of parameter sets to be saved to the database. In the interest of saving cost and reducing load, we therefore **recommend using the latest version** available for most connectors.

This issue is known to occur with the following connector versions:

- [Microsoft Platform](https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f): 1.1.2.x, 1.2.0.x, 1.2.1.1, and 6.0.0.1–6.0.0.7.

## DataMiner is unable to start up after registration

If you followed the procedure to [set up STaaS](xref:Setting_up_StaaS) and switched your *DB.xml* to use STaaS, but the same DMA was previously registered with another organization, DataMiner will not be able to start up.

In the *SLError.txt* log file, you will find this error:

```txt
SLCloudStorage.txt|SLDataGateway|DataGateway.CloudStorage|ERR|0|114|Failed to refresh DmsQueueToken because of exception SLCloudStorageConnection.Repositories.Exceptions.DmsQueueTokenRepositoryException: Failed to get SAS token ---> SLCloudStorageConnection.Repositories.Exceptions.EventHubSasTokenRepositoryException: Failed to get SAS token, response did not indicate success. Got code 500.
```

To resolve this issue:

1. Remove the file `C:\ProgramData\Skyline Communications\DxMs Shared\Data\NodeId.txt`.

1. Restart the DMA.
