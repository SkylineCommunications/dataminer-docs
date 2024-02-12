---
uid: cloudgateway_change_log
---

# Cloud Gateway change log

#### 12 February 2024 - Fix - CloudGateway 2.13.5 - Stability degradation since CloudGateway 2.13.4 [ID_38730]

Since CloudGateway 2.13.4, a problem could occur in the CloudGateway service that temporarily made it stop responding. The service was able to recover from this problem automatically. This issue has been resolved.


#### 30 January 2024 - Enhancement - CloudGateway 2.13.4 - Improved DxM status reporting [ID_38543]

The CloudGateway DxM will now offload more information to help Skyline provide support. This includes proxy, DMZ, and network configuration information, as well as information on whether dataminer.services can be reached.


#### 16 January 2024 - Enhancement - CloudGateway 2.13.2 - Improved DxM status reporting [ID_38450]

The CloudGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.


#### 20 December 2023 - New feature - CloudGateway 2.13.0 - DxM status reporter added [ID_38022]

The CloudGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running.


#### 8 November 2023 - Enhancement - CloudGateway 2.12.4 - Dependencies updated [ID_37798] 

Several dependencies have been updated.


#### 2 November 2023 - Fix - CloudGateway 2.12.3 - Issue when hosting server had more than one NIC [ID_37761]

When CloudGateway was installed on a server with more than one network interface (NIC), it could occur that CloudGateway returned the wrong NIC address to other modules such as DataMiner SupportAssistant and DataMiner ArtifactDeployer, causing deployments and remote log collection to fail. This has now been resolved.

Make sure to also install DataMiner SupportAssistant 1.5.1 and DataMiner ArtifactDeployer 1.5.1 to make use of this fix.


#### 30 October 2023 - Fix - CloudGateway 2.12.2 - Resolved an issue that could occur when using multiple CloudGateway modules [ID_37686]

When multiple CloudGateway modules were installed in a cluster, it could occur that they were no longer able to sync with each other. As a result, the dataminer.services identity of the DMS was not synced properly, and only one CloudGateway instance was able to function correctly, causing stability issues in the dataminer.services connection and features such as sharing and remote access. This has now been resolved.


#### 30 October 2023 - Fix - CloudGateway 2.12.2 - Resolved an issue that could occur when starting the CloudGateway module [ID_37713]

When the CloudGateway module started, it could occur that it tried to set up the connection to dataminer.services before it was assigned a port by the server. This caused the module to function incorrectly, which in turn caused stability issues in the dataminer.services connection and features such as sharing and remote access. This has now been resolved.


#### 19 September 2023 - Enhancement - CloudGateway 2.12.1 - Added more checks in the ConnectionTester [ID_37219]

The ConnectionTester included with DataMiner CloudGateway has been upgraded with the following checks:

- Validation if NATS is working between DxMs, by discovering the DataMiner CloudGateway DxMs in the DMS.
- Validation if those discovered DataMiner Cloud Gateway nodes can be reached using their cloud endpoint, which by default requires TCP port 5100 to be open between the servers (firewall/internal network). This is a common misconfiguration causing issues with several cloud features like Catalog deployments, DxM updates, remote log collection, etc.


#### 22 August 2023 - Enhancement - CloudGateway 2.12.0 - Upgrade to .NET 6 [ID_37151]

DataMiner CloudGateway has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.


#### 7 June 2023 - Fix - CloudGateway 2.11.0 / CoreGateway 2.13.0 - Resolved connection issue [ID_36439] [ID_36453]

In case the DMA name no longer corresponded to the server name after a rename, when using cloud features like Remote Access or Sharing, you could encounter the error message "The DataMiner System has no active connections to the DataMiner Cloud Platform". This issue has now been resolved by using the DMA name instead of the server name.


#### 19 May 2023 - Fix - CloudGateway 2.10.12 - Resolved concurrency issue [ID_36432]

A concurrency issue was introduced in CloudGateway 2.10.8 that could cause the CloudGateway to fail to respond to certain requests, such as creating a share. This issue has now been resolved.


#### 15 May 2023 - Fix - CloudGateway 2.10.11 - Reconnect in case of a canceled connection [ID_36402]

In some rare cases, it could occur that when DataMiner CloudGateway encountered a canceled connection to the cloud, it did not renew the connection automatically unless the DxM was restarted manually. This issue has been resolved.


#### 5 May 2023 - Fix - CloudGateway 2.10.10 - Null reference exception breaking the cloud connection [ID_36346]

An issue was introduced in CloudGateway 2.10.8 that could cause the cloud connection to break. This issue has now been resolved. When the issue occurred, the CloudGateway log file periodically contained the following exception: 

```txt
Unable to connect to the TunnelService[SLCcaGatewayService.Services.TunnelService.TunnelConnection.Impl.TunnelConnection]
System.NullReferenceException: Object reference not set to an instance of an object.
```


#### 5 May 2023 - Enhancement -  CloudGateway 2.10.9 - ConnectionTester tool output improved [ID_36260]

The ConnectionTester tool, which is included in the CloudGateway installation, has been improved and will have clearer logging output that is easier to understand.


#### 26 April 2023 - Enhancement/fix -  CloudGateway 2.10.8 - General improvements [ID_36014] [ID_36259]

Changes have been implemented in DataMiner CloudGateway to make the service ignore requests when it is unable to access dataminer.services. This way, another CloudGateway service that does have access can pick them up and handle
 them successfully. This is most commonly needed when the CloudGateway is installed on a firewalled or offline server by accident. Previously, this could lead to seemingly random errors, for example when creating or renewing your cloud connection in Cube, or when creating or managing shares from the Dashboards app.

An issue has also been resolved where CloudGateway did not sync the DMA online state with dataminer.services, causing features like sharing or remote access to stop working until the CloudGateway or DMA was restarted or the secure cloud connection was dropped and reestablished.


#### 18 April 2023 - Fix - CloudGateway 2.10.7 - Remote Access Auto Login [ID_36191]

If DataMiner CloudGateway 2.10.6 was installed, users were not automatically logged in with their linked DataMiner account when they used the dataminer.services remote access URL to access DataMiner web apps. This issue has been resolved.


#### 17 April 2023 - Enhancements - CloudGateway 2.10.6 - General improvements [ID_35793] [ID_35812] [ID_35873] [ID_36136] [ID_36158] [ID_36167]

Changes have been implemented in DataMiner CloudGateway to improve its general stability and to prevent generating exception logs upon shutdown.


#### 16 February 2023 - Fix - CloudGateway 2.10.3 - Share not created in case of mismatch in local culture on hosting server [ID_35654]

Prior to CloudGateway version 2.10.3, a share could not be created if there was a mismatch in the local culture on the hosting server.


#### 12 January 2023 - Fix - CloudGateway 2.10.2 - CloudGateway not starting if DataMiner uses HTTP [ID_35362]

When DataMiner was configured to use HTTP, prior to version 2.10.2, CloudGateway could fail to start up, and it could throw the following exception:

```txt
Something went wrong while initializing WebApiEndpointService. A url in the (custom.)appsettings.json or maintenancesettings.xml is malformed or empty while a valid value was expected. See exception System.ArgumentNullException: Value cannot be null. (Parameter 'dataMinerWebApiHttpFormat')
```

This fix is included in Cloud Pack 2.8.5.


#### 22 December 2022 - Fix - CloudGateway 2.10.1 - Connection tester did not take proxy settings into account [ID_35227]

If proxy settings were configured in the *appsettings.proxy.json* file, previously these were not taken into account by the connection tester tool.

This fix is included in Cloud Pack 2.8.4.


#### 8 December 2022 - New feature - CloudGateway 2.10.0 / SupportAssistant 1.1.0 - Remote Log Collection [ID_34681] [ID_34875] [ID_34928] [ID_34934] [ID_34954] [ID_34992]

A new DataMiner Cloud Pack 2.8.2 has been released, which enables the [Remote Log Collection](xref:RemoteLogCollection) feature. The DataMiner Cloud Pack can be found on [DataMiner Dojo](https://community.dataminer.services/downloads/).

With remote log collection, the packages generated by the [Log Collector tool](xref:SLLogCollector) are automatically transferred to secure storage in the cloud. This gives the experts at Skyline Communications immediate access to these packages, so that they can collect DataMiner log and memory dump files independently, increasing efficiency of investigations.

> [!NOTE]
> To be able to make use of this new feature, you must make sure the internal network allows [HTTP(S) traffic via port TCP 5100](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms). This port is required fo
r the DataMiner CloudGateway extension from version 2.10.0 onwards (included in the Cloud Pack 2.8.2). It is used as a dataminer.services endpoint for other [DataMiner Extension Modules](xref:DataMinerExtensionModules#dataminer-
extension-modules-dxms). For more information about disabling this port or configuring another port for the dataminer.services endpoint, refer to [Customizing the dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).
