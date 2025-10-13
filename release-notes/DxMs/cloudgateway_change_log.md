---
uid: cloudgateway_change_log
---

# Cloud Gateway change log

#### 13 October 2025 - Security - CloudGateway 2.17.14 - Security Update

Fixes a security issue introcuded in 2.17.13. 

#### 08 September 2025 - Enhancement - CloudGateway 2.17.13 - Dependencies updated

Several dependencies have been updated.

#### 27 August 2025 - Enhancement - CloudGateway 2.17.12 - General improvements

General improvements have been made to the way CloudGateway handles tasks, making the DxM more robust and also improving its shutdown procedure.

#### 24 July 2025 - Fix - CloudGateway 2.17.11 - Incorrect connectivity warnings due to incomplete validation

An issue was introduced in CloudGateway 2.17.5 where the connection to dataminer.services was only validated by IP address, without falling back to DNS as expected. On systems where the firewall is configured to allow traffic based on DNS rather than IP, this could result in incorrect connectivity warnings in the Admin app. This issue has now been resolved.

#### 07 July 2025 - Fix - CloudGateway 2.17.10 - Unhandled exception while setting up connection could cause a DxM restart

When an exception was encountered while setting up the connection, this could cause the CloudGateway DxM to stop working correctly and then restart.

#### 30 June 2025 - Fix - CloudGateway 2.17.9 - Problem with dashboard sharing in proxy setups

In proxy setups, sharing a dashboard or trying to modify a shared dashboard could result in the following error message: `Sharing dashboard failed. Error trapped: Something went wrong while fetching the sharing URL.` This issue has now been resolved.

#### 24 June 2025 - Enhancement - CloudGateway 2.17.8 - Improved upgrade process

Improvements have been made to the startup and shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - CloudGateway 2.17.7 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - CloudGateway 2.17.7 - Endpoint added for future use

An endpoint has been added to the ConnectionTester tool, which will be required in the future.

#### 17 June 2025 - Fix - CloudGateway 2.17.7 - Problem when subscribing during NATS message broker reconnect

Initiating a subscription while the NATS message broker was reconnecting could cause the DxM to stop functioning correctly. This has been fixed.

#### 17 June 2025 - Enhancement - CloudGateway 2.17.7 - Dependencies updated

Several dependencies have been updated.

#### 17 June 2025 - Fix - CloudGateway 2.17.7 - Problem caused by rapid file changes [ID 42763]

​Rapid file changes in *DataMiner.xml* or *MaintenanceSettings.xml* could cause a problem in CloudGateway, causing the DxM to restart.

#### 4 April 2025 - Enhancement - CloudGateway 2.17.4 - Dependencies updated [ID 42682]

Several dependencies have been updated.

#### 4 April 2025 - Enhancement - CloudGateway 2.17.4 - Improved token refresh [ID 42627]

The tokens to authenticate towards dataminer.services no longer rely on NATS to refresh. This means the tokens will now continue to refresh even when NATS is unavailable.

#### 4 April 2025 - Fix - CloudGateway 2.17.4 - TCP port leak [ID 42458]

A TCP port leak could occur in the CloudGateway, especially when there was an issue with the connection to dataminer.services.

#### 4 April 2025 - Fix - CloudGateway 2.17.4 - Connection issue caused by hibernation mode [ID 42383]

​When the DataMiner CloudGateway DxM was run on a machine that goes into hibernation mode (e.g. a laptop or desktop computer), the process to create the connection to dataminer.services could get stuck as a side effect of the hibernation mode. To prevent this, this process will now time out after 30 seconds, and a new attempt will be made.

This does not affect machines that do not go into hibernation mode (e.g. servers).

#### 30 January 2025 - Fix - CloudGateway 2.17.2 - Reconnect banner continually showing when remote access is used [ID 42086]

With the Remote Access and Live Sharing performance and stability improvements released on the 27th of January (rolled back on the 29th of January), if CloudGateway version 2.16.0 - 2.17.1 was used, the reconnect banner showed up all the time while remote access was used. This issue has been fixed.

#### 29 January 2025 - Enhancement - CloudGateway 2.17.1 - Access tokens instantly refreshed when cloud session is manually renewed [ID 42081]

From now on, when the [cloud session is renewed](xref:Cloud_Connection_Issues#check-the-cloud-session) manually, other access tokens, for example used by STaaS, will be refreshed instantly. Previously, this could take up to 30 minutes.

#### 29 January 2025 - Enhancement - CloudGateway 2.17.1 - Offloading of local setting for Remote Access and Live Sharing [ID 42080]

Cloud Gateway will now offload [the local setting for Remote Access and Live Sharing](xref:Disabling_Remote_Access_and_Live_Sharing). This allows for better technical support and for dataminer.services to validate if everything is correctly configured to use the DataMiner Cube desktop app remotely via dataminer.services.

#### 29 January 2025 - Enhancement - CloudGateway 2.17.1 - Offloading of API Gateway health [ID 42080]

Cloud Gateway will now offload the health of the API Gateway. This allows for better technical support and for dataminer.services to validate if everything is correctly configured to use the DataMiner Cube desktop app remotely via dataminer.services.

#### 29 January 2025 - Enhancement - CloudGateway 2.17.1 - Offloading of error information if DMA state cannot be determined [ID 42080]

Cloud Gateway will now offload error information in case the running state of a DMA cannot be determined, for example when the SSL certificate for the web APIs is invalid. This allows for better technical support.

#### 29 January 2025 - Enhancement - CloudGateway 2.17.1 - Cloud connection performance and stability improvements [ID 41733]

From now on, the CloudGateway DxM will create multiple connections to dataminer.services instead of one, which is possible since the recent [Remote Access and Live Sharing performance and stability improvements](xref:dataminer_services_change_log_2025#27-january-2025---enhancement---remote-access-and-live-sharing-performance-and-stability-improvements-id-42043).

This enhancement improves **performance** because it allows a higher request throughput.

It also improves the **stability** of the connection to dataminer.services. Connections will be able to disconnect and reconnect without having any downtime for all Remote Access and Live Sharing features, as long as there is one or more connections still up. Connections are expected to disconnect (and reconnect) at a regular basis, for example when (rolling) upgrades are deployed on dataminer.services or when services are scaled down.

#### 10 December 2024 - Enhancement - CloudGateway 2.16.0 - Dependencies updated [ID 41681]

An important dependency has been updated that the dataminer.services connection uses to proxy most remote access requests.

#### 5 December 2024 - Enhancement - CloudGateway 2.15.0 - Improved handling and error logging of invalid certificates [ID 40746]

Improvements have been implemented to ensure that the configured HTTPS certificates for port 443 in IIS are verified and any problems with a certificate will be logged. If a certificate is valid but becomes invalid, CloudGateway will now correctly notice this within 2 minutes and make sure it is set to offline. CloudGateway will also recover automatically when the certificates are valid again so the connection with dataminer.services is restored.

#### 6 November 2024 - Enhancement - CloudGateway 2.14.5 - Dependencies updated [ID 41294]

Several dependencies have been updated.

#### 6 November 2024 - Enhancement - CloudGateway 2.14.5 - Token refresh logging improved [ID 40693]

The logging for the token refresh has been improved. Previously, it would log that a token refresh succeeded together with an exceeded expiry date, while it was not refreshed at all.

#### 27 August 2024 - Enhancement - CloudGateway 2.14.1 - Syncing improvements [ID 40527]

CloudGateway will no longer sync its cloud endpoint with other DxMs if it does not have internet access.

In addition, CloudGateway will now also sync the Web API/DMA state with dataminer.services at a regular interval of approximately one minute, even if it had already been synced after a detected change. This will ensure that the connection state remains in sync and is automatically healed, even for Failover systems, where a restart of CloudGateway used to sometimes be needed to get the connection synced and working again.

#### 8 August 2024 - Enhancement - CloudGateway 2.14.0 - Upgrade to .NET 8 [ID 40431]

DataMiner CloudGateway has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 25 July 2024 - Enhancement - CloudGateway 2.13.15 - Dependencies updated & event handling improved [ID 40279]

Several dependencies have been updated. Events sent by DxMs via the CloudGateway DxM that are rejected by dataminer.services will now be indicated so the senders know not to retry but to discard those events.

#### 16 July 2024 - Fix - CloudGateway 2.13.14 - Requests could get no response in an edge case leading to timeouts [ID 40208]

If an issue occurred while handling a remote access web API call, it could happen that no response was returned, which would lead to the call going into timeout. Now the CloudGateway DxM will try to return an internal server response immediately.

If a remote access web API call takes longer than 25 seconds, this will now also be mentioned in a warning log.

#### 16 July 2024 - Fix - CloudGateway 2.13.14 - Replaced installer for CloudGateway 2.13.13

Because the certificate used to sign CloudGateway 2.13.13 has been revoked, a new installer has been generated. To avoid issues during the digital signature validation while running the installer, CloudGateway 2.13.13 is now unlisted.

#### 10 July 2024 - Enhancement - CloudGateway 2.13.13 - Improvement for cloud token refresh [ID 40032]

The credentials used by CloudGateway are now refreshed daily, so that even when a system is temporarily disconnected from the internet or shut down, the token will remain valid, provided that this does not last longer than 6 days.

#### 4 July 2024 - Enhancement - CloudGateway 2.13.12 - Connection testing improvements [ID 40108]

The ConnectionTester tool included with CloudGateway and the at-runtime connection testing by CloudGateway have been improved.

#### 20 June 2024 - Enhancement - CloudGateway 2.13.11 - Remove log spam when the DMS identity token cannot be automatically refreshed [ID 39261]

From now on, if the refresh token for a dataminer.services DMS identity is expired or invalid, this will only be logged once instead of every 10 seconds.

#### 14 May 2024 - Fix - CloudGateway 2.13.10 - Excessive dataminer.services endpoints connection tester logging [ID 39631]

Up to now, the CloudGateway DxM added logging every minute when a dataminer.services endpoint could not be reached. This excessive logging will no longer occur.

#### 19 April 2024 - Enhancement - CloudGateway 2.13.9 - Offload data when installed on DMZ/proxy server [ID 39444]

The CloudGateway DxM has been extended with the capability to offload data when installed on a DMZ or proxy server.

#### 29 March 2024 - Enhancement - CloudGateway 2.13.8 - Added the possibility to locally disable Remote Access & Live Sharing through the app settings [ID 39113]

It is now possible to locally disable features like *Remote Access* and *Live Sharing* in the *App settings* file of the CloudGateway DxM.

To do so, set *RemoteAccessAndSharing:IsDisabled* to *true* in the app settings. On each server where DataMiner CloudGateway is installed, navigate to `C:\Program Files\Skyline Communications\DataMiner CloudGateway` and create or modify *appsettings.custom.json* with the following configuration:

```json
{
   "RemoteAccessAndSharing": {
      "IsDisabled": true
   }
}
```

#### 13 March 2024 - Fix - CloudGateway 2.13.7 - Issues with dataminer.services features when DMA alias contained spaces [ID 39106]

Since CloudGateway 2.11.0 (and CoreGateway 2.13.0), dataminer.services features like Remote Access and Catalog deployments did not work correctly if the [DMA alias defined in DataMiner.xml](xref:Changing_the_name_of_a_DMA#configuring-an-alias-in-dataminerxml) contained one or more spaces. This issue has been resolved.

#### 13 March 2024 - Enhancement - CloudGateway 2.13.7 - Dependencies updated [ID 39045]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - CloudGateway 2.13.6 - Improved installer robustness [ID 38907] [ID 38936]

The CloudGateway installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 12 February 2024 - Fix - CloudGateway 2.13.5 - Stability degradation since CloudGateway 2.13.4 [ID 38730]

Since CloudGateway 2.13.4, a problem could occur in the CloudGateway service that temporarily made it stop responding. The service was able to recover from this problem automatically. This issue has been resolved.

#### 30 January 2024 - Enhancement - CloudGateway 2.13.4 - Improved DxM status reporting [ID 38543]

The CloudGateway DxM will now offload more information to help Skyline provide support. This includes proxy, DMZ, and network configuration information, as well as information on whether dataminer.services can be reached.

#### 16 January 2024 - Enhancement - CloudGateway 2.13.2 - Improved DxM status reporting [ID 38450]

The CloudGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - New feature - CloudGateway 2.13.0 - DxM status reporter added [ID 38022]

The CloudGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - CloudGateway 2.12.4 - Dependencies updated [ID 37798]

Several dependencies have been updated.

#### 2 November 2023 - Fix - CloudGateway 2.12.3 - Issue when hosting server had more than one NIC [ID 37761]

When CloudGateway was installed on a server with more than one network interface (NIC), it could occur that CloudGateway returned the wrong NIC address to other modules such as DataMiner SupportAssistant and DataMiner ArtifactDeployer, causing deployments and remote log collection to fail. This has now been resolved.

Make sure to also install DataMiner SupportAssistant 1.5.1 and DataMiner ArtifactDeployer 1.5.1 to make use of this fix.

#### 30 October 2023 - Fix - CloudGateway 2.12.2 - Resolved an issue that could occur when using multiple CloudGateway modules [ID 37686]

When multiple CloudGateway modules were installed in a cluster, it could occur that they were no longer able to sync with each other. As a result, the dataminer.services identity of the DMS was not synced properly, and only one CloudGateway instance was able to function correctly, causing stability issues in the dataminer.services connection and features such as sharing and remote access. This has now been resolved.

#### 30 October 2023 - Fix - CloudGateway 2.12.2 - Resolved an issue that could occur when starting the CloudGateway module [ID 37713]

When the CloudGateway module started, it could occur that it tried to set up the connection to dataminer.services before it was assigned a port by the server. This caused the module to function incorrectly, which in turn caused stability issues in the dataminer.services connection and features such as sharing and remote access. This has now been resolved.

#### 19 September 2023 - Enhancement - CloudGateway 2.12.1 - Added more checks in the ConnectionTester [ID 37219]

The ConnectionTester included with DataMiner CloudGateway has been upgraded with the following checks:

- Validation if NATS is working between DxMs, by discovering the DataMiner CloudGateway DxMs in the DMS.
- Validation if those discovered DataMiner Cloud Gateway nodes can be reached using their cloud endpoint, which by default requires TCP port 5100 to be open between the servers (firewall/internal network). This is a common misconfiguration causing issues with several cloud features like Catalog deployments, DxM updates, remote log collection, etc.

#### 22 August 2023 - Enhancement - CloudGateway 2.12.0 - Upgrade to .NET 6 [ID 37151]

DataMiner CloudGateway has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

#### 7 June 2023 - Fix - CloudGateway 2.11.0 / CoreGateway 2.13.0 - Resolved connection issue [ID 36439] [ID 36453]

In case the DMA name no longer corresponded to the server name after a rename, when using cloud features like Remote Access or Sharing, you could encounter the error message "The DataMiner System has no active connections to the DataMiner Cloud Platform". This issue has now been resolved by using the DMA name instead of the server name.

#### 19 May 2023 - Fix - CloudGateway 2.10.12 - Resolved concurrency issue [ID 36432]

A concurrency issue was introduced in CloudGateway 2.10.8 that could cause the CloudGateway to fail to respond to certain requests, such as creating a share. This issue has now been resolved.

#### 15 May 2023 - Fix - CloudGateway 2.10.11 - Reconnect in case of a canceled connection [ID 36402]

In some rare cases, it could occur that when DataMiner CloudGateway encountered a canceled connection to the cloud, it did not renew the connection automatically unless the DxM was restarted manually. This issue has been resolved.

#### 5 May 2023 - Fix - CloudGateway 2.10.10 - Null reference exception breaking the cloud connection [ID 36346]

An issue was introduced in CloudGateway 2.10.8 that could cause the cloud connection to break. This issue has now been resolved. When the issue occurred, the CloudGateway log file periodically contained the following exception:

```txt
Unable to connect to the TunnelService[SLCcaGatewayService.Services.TunnelService.TunnelConnection.Impl.TunnelConnection]
System.NullReferenceException: Object reference not set to an instance of an object.
```

#### 5 May 2023 - Enhancement -  CloudGateway 2.10.9 - ConnectionTester tool output improved [ID 36260]

The ConnectionTester tool, which is included in the CloudGateway installation, has been improved and will have clearer logging output that is easier to understand.

#### 26 April 2023 - Enhancement/fix -  CloudGateway 2.10.8 - General improvements [ID 36014] [ID 36259]

Changes have been implemented in DataMiner CloudGateway to make the service ignore requests when it is unable to access dataminer.services. This way, another CloudGateway service that does have access can pick them up and handle them successfully. This is most commonly needed when the CloudGateway is installed on a firewalled or offline server by accident. Previously, this could lead to seemingly random errors, for example when creating or renewing your cloud connection in Cube, or when creating or managing shares from the Dashboards app.

An issue has also been resolved where CloudGateway did not sync the DMA online state with dataminer.services, causing features like sharing or remote access to stop working until the CloudGateway or DMA was restarted or the secure cloud connection was dropped and reestablished.

#### 18 April 2023 - Fix - CloudGateway 2.10.7 - Remote Access Auto Login [ID 36191]

If DataMiner CloudGateway 2.10.6 was installed, users were not automatically logged in with their linked DataMiner account when they used the dataminer.services remote access URL to access DataMiner web apps. This issue has been resolved.

#### 17 April 2023 - Enhancements - CloudGateway 2.10.6 - General improvements [ID 35793] [ID 35812] [ID 35873] [ID 36136] [ID 36158] [ID 36167]

Changes have been implemented in DataMiner CloudGateway to improve its general stability and to prevent generating exception logs upon shutdown.

#### 16 February 2023 - Fix - CloudGateway 2.10.3 - Share not created in case of mismatch in local culture on hosting server [ID 35654]

Prior to CloudGateway version 2.10.3, a share could not be created if there was a mismatch in the local culture on the hosting server.

#### 12 January 2023 - Fix - CloudGateway 2.10.2 - CloudGateway not starting if DataMiner uses HTTP [ID 35362]

When DataMiner was configured to use HTTP, prior to version 2.10.2, CloudGateway could fail to start up, and it could throw the following exception:

```txt
Something went wrong while initializing WebApiEndpointService. A url in the (custom.)appsettings.json or maintenancesettings.xml is malformed or empty while a valid value was expected. See exception System.ArgumentNullException: Value cannot be null. (Parameter 'dataMinerWebApiHttpFormat')
```

This fix is included in Cloud Pack 2.8.5.

#### 22 December 2022 - Fix - CloudGateway 2.10.1 - Connection tester did not take proxy settings into account [ID 35227]

If proxy settings were configured in the *appsettings.proxy.json* file, previously these were not taken into account by the connection tester tool.

This fix is included in Cloud Pack 2.8.4.

#### 8 December 2022 - New feature - CloudGateway 2.10.0 - Remote Log Collection [ID 34681] [ID 34875] [ID 34928] [ID 34934] [ID 34954] [ID 34992]

This feature also requires SupportAssistant 1.1.0 or higher.

A new DataMiner Cloud Pack 2.8.2 has been released, which enables the [Remote Log Collection](xref:RemoteLogCollection) feature. The DataMiner Cloud Pack can be found on [DataMiner Dojo](https://community.dataminer.services/downloads/).

With remote log collection, the packages generated by the [Log Collector tool](xref:SLLogCollector) are automatically transferred to secure storage in the cloud. This gives the experts at Skyline Communications immediate access to these packages, so that they can collect DataMiner log and memory dump files independently, increasing efficiency of investigations.

> [!NOTE]
> To be able to make use of this new feature, you must make sure the internal network allows [HTTP(S) traffic via port TCP 5100](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms). This port is required for the DataMiner CloudGateway extension from version 2.10.0 onwards (included in the Cloud Pack 2.8.2). It is used as a dataminer.services endpoint for other [DataMiner Extension Modules](xref:DataMinerExtensionModules#dataminer-extension-modules-dxms). For more information about disabling this port or configuring another port for the dataminer.services endpoint, refer to [Customizing the dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

#### 16 November 2022 - Enhancement - CloudGateway 2.9.6 - Proxy support for WebSocket connection testing [ID 34569]

The connection tester now supports testing WebSocket connections through the configured proxy.

This enhancement is included in Cloud Pack version 2.8.2.

#### 15 September 2022 - Fix - CloudGateway 2.9.5 - Problem in CloudGateway process if MaintenanceSettings.xml contained an invalid HTTPS endpoint [ID 34341]

If the HTTPS endpoint in the file *MaintenanceSettings.xml* was not configured correctly, a problem could occur in the CloudGateway process. This happened specifically when DataMiner upgrades caused the HTTPS URL to end with an encoded new line.

With CloudGateway 2.9.5 (included in Cloud Pack version 2.8.2), all endpoints from configuration files will be trimmed to prevent this, so that CloudGateway will no longer get this problem at runtime. However, note that CloudGateway may still fail to start up if an endpoint in a configuration file is invalid.

#### 1 September 2022 - New feature - CloudGateway 2.9.4 - Connection tester tool [ID 34187] [ID 34289] [ID 34293] [ID 34297]

The Cloud Gateway now comes with a new connection tester tool, *ConnectionTester.exe*. This tool can be used to validate the network setup and check if all features are available. It checks whether the network complies with the requirements for dataminer.services.

You can find the new tool in the folder `Program files\Skyline Communications\Dataminer CloudGateway\` on a DMA that has the Cloud Gateway installed. Run the executable as administrator. The connection tester will connect to port 443 to check whether requirements are met, and it will show the results in a console window.

This feature is included in Cloud Pack version 2.8.2.

#### 1 September 2022 - Fix - CloudGateway 2.9.4 - Login screen shown when not necessary while viewing share or using remote access [ID 34275]

When the DataMiner Cloud Pack was installed in a cluster with two or more DMAs, it could occur that users trying to view a shared dashboard or remotely access a DMS could be shown the login screen when this was not supposed to happen.

With CoreGateway 2.11.4 and CloudGateway 2.9.4 (included in Cloud Pack version 2.8.2), this issue is resolved.

The CoreGateway DxM must now be installed on the same DMA as CloudGateway to ensure that sharing and remote access will work correctly. For DMZ setups, the DMA that CloudGateway points to will need to have the CoreGateway DxM installed.

#### 18 July 2022 - New feature - CloudGateway 2.7.0 - Proxy support [ID 33961]

Proxy support has been added for DataMiner CloudGateway. When you configure this, all outgoing traffic towards the public internet will pass through the proxy server.

The proxy settings are configured in a single settings file that is reused for all DxMs. This *appsettings.proxy.json* file is located in the `C:\ProgramData\Skyline Communications\DxMs Shared\` folder on the DMA. It should have the following content:

```json
{
   "ProxyOptions": {
      "Enabled": true,
      "Address": "<address of the proxy server>"
   }
}
```

When you have configured the file, you will need to restart the CloudFeed, CloudGateway, and ArtifactDeployer services for the changes to take effect.

#### 18 July 2022 - New feature - CloudGateway 2.7.0 - DMZ support [ID 33903]

You can now connect a DMS to dataminer.services using a DMZ. This way the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

To create such a DMZ:

1. Configure the firewall of the DMZ:

    - Make sure it allows access to the endpoints mentioned in [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
    - Make sure the DMZ can communicate with the DMS through port 80, or through port 443 for a secure connection.
    - Make sure the DMZ can communicate through NATS though port 4222.

1. Install all DxMs that need internet access in the DMZ. At present, these are *CloudGateway*, *CloudFeed*, and *ArtifactDeployer*.

1. Add the *Orchestrator* to the DMZ, so that you can upgrade it later through dataminer.services.

1. On the DataMiner nodes, install the DxMs that need to connect with the DMA or do not require internet access. At present, these are *CoreGateway* and *FieldControl*.

    > [!NOTE]
    > For all DxMs, it is advised to have multiple instances running at the same time. This will create redundancy in case something goes wrong and allows for upgrades without any downtime.

1. In the `C:\Program Files\Skyline Communications\DataMiner CloudGateway`folder, create an override *appsettings.custom.json* with the following contents:

    ```json
    {
      "DmzOptions": {
        "IsHttpsEnabled": <true/false>,
        "Domain": <IIS>,
        "DataMinerAgentName":  <name of the dataminer agent the DMZ is connected to>
      }
    }
    ```

    - *IsHttpsEnabled*: Indicates whether the communication between the DMZ and the DMA is encrypted. This can only be the case if the IIS is configured to support TLS.
    - *Domain*: The domain name of your DataMiner System, configured through the IIS settings.
    - *DataMinerAgentName*: The name of the DataMiner Agent you are connecting to. This should be the same DMA as the one used for the domain setting.

1. On a DataMiner node, copy `C:\Skyline DataMiner\SLCloud.xml` and `C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds`, and paste these in the `C:\Skyline DataMiner\` folder of the DMZ. Make sure that the credentials entry in *SLCloud.xml* points to the credentials file you copied over.

1. Restart all DxMs in the DMZ so that they use the new settings.
