---
uid: orchestrator_change_log
---

# Orchestrator change log

#### 30 January 2024 - Enhancement - Orchestrator 1.5.4 - Improved DxM status reporting [ID_38553]

The Orchestrator DxM will now offload more information about the cloud endpoint.


#### 16 January 2024 - Enhancement - Orchestrator 1.5.3 - Improved DxM status reporting [ID_38449]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.


#### 20 December 2023 - New feature - Orchestrator 1.5.0 - DxM status reporter added [ID_38170]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - Orchestrator 1.4.1 - Improved logging [ID_37175]

Logging for the Orchestrator DxM has been improved. In several cases, the log level has been adjusted to improve visibility of important logs.


#### 11 August 2023 - Enhancement - Orchestrator 1.4.0 - Upgrade to .NET 6 and more server and DMA data offloaded to improve user experience [ID_37105] [ID_36819]

DataMiner Orchestrator has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

From now on, the DxM will also offload more data about the DMA and the server to dataminer.services to improve the user experience:

- DataMiner version and version history
- Installed dotnet runtimes
- System info such as the Windows version


#### 19 April 2023 - Enhancements - Orchestrator 1.3.3 - General improvements [ID_36031]

Changes have been implemented in DataMiner Orchestrator to improve its general stability.


#### 7 April 2023 - Fix - Orchestrator 1.3.2 - Orchestrator DxM uninstalled after attempt to update it on Window Server 2016 [ID_36106]

When the DataMiner Orchestrator DxM was updated via the Admin app on Window Server 2016, it could occur that the service was uninstalled but not updated.


#### 7 July 2022 - Fix - Orchestrator 1.2.5 - Not possible to deploy DxMs via Admin app [ID_33998]

In some cases, it could occur that the DataMiner Orchestrator got stuck while it was installing a DxM, and it became unable to handle updates. This made it impossible to deploy any more DxMs via the Admin app.
