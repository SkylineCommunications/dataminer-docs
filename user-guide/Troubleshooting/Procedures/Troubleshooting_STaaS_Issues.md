---
uid: Troubleshooting_STaaS_Issues
---

# Troubleshooting STaaS Issues
This page provides solutions to common issues that you may encounter while using STaaS. It covers problems related to cloud connectivity, registration, token expiration, and service reachability. 
Each section provides a detailed explanation of the issue, the error messages you might see, and the steps to resolve it.

## Not Cloud Connected

If a system is not cloud connected and is trying to use STaaS, DataMiner won't be able to start. The following error message will be present in the SLCloudStorage.txt log file:

`CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "This DMS is not Cloud Registered." }`

To get your system Cloud Connected, please refer to this [page](xref:Connecting_your_DataMiner_System_to_the_cloud).

### Not registered to use STaaS

If a system is not registered to use STaaS. DataMiner won't be able to start. The following error message will be present in the SLCloudStorage.txt log file:

`CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing a EndpointInfoAsync. (Failed to EndpointInfoAsync. (404)) `

To properly register your system, contact your Skyline representative or <staas@dataminer.services>.

## CloudGateway down/Token expiration

Under normal circumstances, CloudGateway refreshes the cloud session automatically. However, if **CloudGateway is down for longer than three days**, for example because the server is down, the cloud session will become invalid. This will cause DataMiner startup to fail.

When you encounter this issue, you will find entries similar to the examples below in the SLCloudStorage.txt log file:

`CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "The Service Principal of this DMS is expired (3/14/2023 8:09:51 AM +00:00) but should soon be refreshed automatically." }`

`CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing GetCcaGatewayConfigRequest. ---> System.AggregateException: One or more errors occurred. ---> DataMinerMessageBroker.API.Exceptions.SubscriptionException: No responders are available for the request. ---> NATS.Client.NATSNoRespondersException: No responders are available for the request.`

To resolve this issue, use the following workaround:

1. [Open SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool) on the DMA.

1. Select *Offline Tools* > *CcaGateway (offline)* > *Renew cloud session* and complete the renew process.

   > [!NOTE]
   > As the renewal of the Service Principal (SP) token is managed by a cloud service, it can take a few minutes before the renewal is fully synced.

1. Wait a few minutes and then restart the DMA. The issue should be resolved now.

> [!NOTE]
> If you have a DataMiner System consisting of multiple DMAs, it is sufficient to do this on one of the DMAs.

## STaaS is unreachable 

If STaaS becomes unreachable for any reason, the following error message will appear in your alarm console:

![image](https://github.com/SkylineCommunications/dataminer-docs/assets/120723729/40acf88a-0d26-445b-b3cf-bc8c77102f34)

DataMiner will automatically initiate offload mode, ensuring that no data loss occurs. While this error is displayed in your alarm console, it is important **not** to restart the system or any elements. 
Typically, this issue resolves itself. If it persists, users are advised to contact support.

## API Deployment Manager failed to initialize

When the [APIDeployment](xref:Overview_of_Soft_Launch_Options#apideployment) option is still enabled in *SoftLaunchOptions.xml*, the following alarm will be shown in Cube:

```txt
APIDeploymentManager failed to initialize, retrying. Check SLAPIDeploymentManager.txt for additional information.
```

In the SLDBConnection.txt log file, the error will look like this:

```txt
2023/10/10 20:30:18.308|SLDBConnection|SLDataGateway.Repositories|INF|0|354|2023-10-10T20:30:18.302|ERROR|Repository.RepositoryStorageProvider.DeployerToken|Refreshing storage [failed]: SLDataGateway.API.Types.Exceptions.StorageTypeNotFoundException: No storage type found for DataType: DeployerToken
```

To resolve this issue, remove the [APIDeployment](xref:Overview_of_Soft_Launch_Options#apideployment) option from *SoftLaunchOptions.xml*.

## Connector-specific issues

Some connector versions may contain a bug that causes a lot of parameter sets to be saved to the database. In the interest of saving cost and reducing load, we therefore **recommend using the latest version** available for most connectors.

This issue is known to occur with the following connector versions:

- [Microsoft Platform](https://catalog.dataminer.services/result/driver/251): 1.1.2.x, 1.2.0.x, 1.2.1.1
