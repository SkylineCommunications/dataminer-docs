---
uid: coregateway_change_log
---

# Core Gateway change log

#### 28 August 2025 - Fix - CoreGateway 2.14.14 - Race condition blocking Catalog deployments

A race condition has been resolved that could lead to the Catalog displaying the following error while there were actually no issues. 

`There are some issues preventing you to deploy.` 

`There are no (healthy) CoreGateways DxMs in the DataMiner System on the node with a running DMA.`

#### 17 June 2025 - Enhancement - CoreGateway 2.14.13 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Fix - CoreGateway 2.14.13 - Problem caused by rapid file changes [ID 42916]

​Rapid file changes in *DataMiner.xml* could cause a problem in CoreGateway, causing the DxM to restart.

#### 1 April 2025 - Enhancement - CoreGateway 2.14.12 - Dependencies updated [ID 42655]

Several dependencies have been updated.

#### 30 October 2024 - Enhancement - CoreGateway 2.14.11 - Dependencies updated [ID 41282]

Several dependencies have been updated.

#### 30 October 2024 - Enhancement - CoreGateway 2.14.11 - Timeouts increased for GQI GenIfOpenSessionRequest [ID 41066]

For GQI requests of type *GenIfOpenSessionRequest*, the timeout has been increased from 50 seconds to 15 minutes. This will give extensions like ad hoc data sources and custom operators more time to initialize.

#### 25 July 2024 - Enhancement - CoreGateway 2.14.10 - Dependencies updated [ID 40312]

Several dependencies have been updated.

#### 16 July 2024 - Fix - CoreGateway 2.14.9 - Replaced installer for CoreGateway 2.14.8

Because the certificate used to sign CoreGateway 2.14.8 has been revoked, a new installer has been generated. To avoid issues during the digital signature validation while running the installer, CoreGateway 2.14.8 is now unlisted.

#### 20 June 2024 - Fix - CoreGateway 2.14.8 - Problem when DMA switched between online and offline [ID 39928]

Because of a race condition, it could occur that CoreGateway kept handling requests when the local DMA went offline or would not handle requests when the local DMA went online. This issue has been resolved.

#### 30 May 2024 - Fix - CoreGateway 2.14.7 - Missing System.Net.Http.dll after upgrading to CoreGateway 2.14.0 – 2.14.6 [ID 39777]

An issue has been resolved where a required `System.Net.Http.dll` went missing after upgrading to a CoreGateway version from range 2.13.0 – 2.14.6. This did not happen with a clean installation of CoreGateway 2.14.0 – 2.14.6.

#### 13 March 2024 - Fix - CoreGateway 2.14.6 - Issues with dataminer.services features when DMA alias contained spaces [ID 39107]

Since CoreGateway 2.13.0 (and CloudGateway 2.11.0), dataminer.services features like Remote Access and Catalog deployments did not work correctly if the [DMA alias defined in DataMiner.xml](xref:Changing_the_name_of_a_DMA#configuring-an-alias-in-dataminerxml) contained one or more spaces. This issue has been resolved.

#### 13 March 2024 - Enhancement - CoreGateway 2.14.6 - Dependencies updated [ID 39055]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - CoreGateway 2.14.5 - Improved installer robustness [ID 38948]

The CoreGateway installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 30 January 2024 - Enhancement - CoreGateway 2.14.4 - Improved DxM status reporting [ID 38590]

The CoreGateway DxM will now offload more information about the status and configuration of the DMA.

#### 16 January 2024 - Fix - CoreGateway 2.13.4/2.14.3 - Timeout error when deploying protocol from Catalog [ID 38464]

In some rare cases, a timeout error could occur when a protocol was deployed from the Catalog. This issue has been resolved.

#### 16 January 2024 - Enhancement - CoreGateway 2.14.3 - Improved DxM status reporting [ID 38442]

The CoreGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - New feature - CoreGateway 2.14.0 - DxM status reporter added [ID 38200]

The CoreGateway DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - CoreGateway 2.13.3 - Dependencies updated [ID 37805]

Several dependencies have been updated.

#### 9 October 2023 - Fix - CoreGateway 2.13.2 - Resolved an issue that could occur after a DataMiner up- or downgrade [ID 37441]

When a local DataMiner Agent was up- or downgraded, it could occur that the CoreGateway DxM did not reinitialize its DataMiner dependencies. In that case, serialization issues could occur at runtime, for example when the DataMiner Teams bot was used. This issue has been resolved.

#### 21 September 2023 - New feature - CoreGateway 2.13.1 - Support new GQI queries [ID 37302]

Support has been added for the latest GQI queries introduced with DataAggregator 2.1.0 and DataMiner 10.3.9.

#### 21 September 2023 - Fix - CoreGateway 2.13.1 - Resolved memory leak [ID 37393]

A memory leak introduced in CoreGateway 2.13.0 has been resolved.

#### 19 April 2023 - Enhancements - CoreGateway 2.12.2 - General improvements [ID 35918]

Changes have been implemented in DataMiner CoreGateway to improve its general stability.

#### 7 April 2023 - Fix - CoreGateway 2.12.1 - Row by row option for GQI Join operator not correctly supported [ID 35740]

Up to now, DataMiner CoreGateway did not correctly support the *Row by row* option for the GQI *Join* operator. This could cause errors when a query using this option was exported to Data Aggregator.

#### 7 April 2023 - Fix - CoreGateway 2.12.1 - Long-running deployment fails [ID 36121]

When a user deployed a package on a DataMiner Agent using dataminer.services, and the deployment took more than 3 minutes, it could occur that this failed. In the Admin app, an exception like the following example could be displayed:

```txt
Exception encountered during installation: (Code: 0x800402EB) Skyline.DataMiner.Net.Exceptions.DataMinerSecurityException: No such remote connection (e839324188).
```

#### 10 January 2023 - Fix - DataMiner CoreGateway 2.12.0 - Problem with CoreGateway after server restart [ID 34961]

After a server restart, a startup race condition could cause issues in the CoreGateway, which could for example cause the DataMiner Teams bot to be unresponsive. The NATS Message Broker dependency has been updated to prevent this issue.

This fix is included in Cloud Pack 2.8.4.

#### 10 January 2023 - Enhancement - CoreGateway 2.12.0 - Support for new Data Aggregator DxM [ID 34903] [ID 35168] [ID 35217] [ID 35252]

To support the new [Data Aggregator DxM](xref:DataAggregator_change_log), CoreGateway has been adjusted to be able to handle requests from Data Aggregator.

This enhancement is included in Cloud Pack 2.8.4.

#### 15 September 2022 - Fix - CoreGateway 2.11.5 - Incorrect information event when connector was deployed via dataminer.services [ID 34325]

When a connector was deployed via dataminer.services, the corresponding information event incorrectly mentioned that this was done with the SLNetClientTest tool.

With CoreGateway 2.11.5 (included in Cloud Pack version 2.8.2), the information event will have the correct format `New Client Registered - <UserName> @ <ComputerName> with DataMiner Cloud Platform`.

#### 1 September 2022 - Fix - CoreGateway 2.11.4 - Login screen shown when not necessary while viewing share or using remote access [ID 34275]

When the DataMiner Cloud Pack was installed in a cluster with two or more DMAs, it could occur that users trying to view a shared dashboard or remotely access a DMS could be shown the login screen when this was not supposed to happen.

With CoreGateway 2.11.4 and CloudGateway 2.9.4 (included in Cloud Pack version 2.8.2), this issue is resolved.

The CoreGateway DxM must now be installed on the same DMA as CloudGateway to ensure that sharing and remote access will work correctly. For DMZ setups, the DMA that CloudGateway points to will need to have the CoreGateway DxM installed.

#### 1 September 2022 - Fix - CoreGateway 2.11.4 - CoreGateway of offline DMA tried to respond to requests from dataminer.services [ID 33973]

When a DMA was offline (e.g. stopped, upgrading, restarting, or offline in a Failover pair), it could occur that the DataMiner CoreGateway tried to respond to requests from dataminer.services, while this should not happen.

With CoreGateway 2.11.4 (included in Cloud Pack version 2.8.2), this will no longer occur.

#### 27 May 2022 - CoreGateway 2.8.0 - Enhancements to support CI/CD deployment [ID 33533]

This version contains enhancements to support the CI/CD deployment feature.
