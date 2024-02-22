---
uid: orchestrator_change_log
---

# Orchestrator change log

#### 22 February 2024 - Enhancement - Orchestrator 1.5.5 - Improved DxM deployment robustness [ID_38853] [ID_38862] [ID_38875]

Improved robustness for DxM deployments by adding and improving retry mechanisms, better managing of processes and giving the service more time to shutdown gracefully.

> [!TIP]
> To make use of all the enhancements, also install ArtifactDeployer 1.6.6.

#### 30 January 2024 - Enhancement - Orchestrator 1.5.4 - Improved DxM status reporting [ID_38553]

The Orchestrator DxM will now offload more information about the cloud endpoint.

#### 16 January 2024 - Enhancement - Orchestrator 1.5.3 - Improved DxM status reporting [ID_38449]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - New feature - Orchestrator 1.5.0 - DxM status reporter added [ID_38170]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - Orchestrator 1.4.1 [ID_37785]

Several dependencies have been updated.

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

#### 16 November 2022 - Enhancement - Orchestrator 1.2.6 - DMA name and ID synced to dataminer.services [ID_34670]

From now on, the DataMiner Orchestrator will sync the DMA name and ID to dataminer.services. This is for example used on the *Nodes* page of the Admin app so users can easily identify a DMA to update its DxMs.

This enhancement is included in Cloud Pack version 2.8.2.

#### 7 July 2022 - Fix - Orchestrator 1.2.5 - Not possible to deploy DxMs via Admin app [ID_33998]

In some cases, it could occur that the DataMiner Orchestrator got stuck while it was installing a DxM, and it became unable to handle updates. This made it impossible to deploy any more DxMs via the Admin app.

#### 7 June 2022 - Fix - Orchestrator 1.2.3 - Orchestrator DxM update incorrectly displayed as failed [ID_33685]

The Orchestrator DxM has been updated to version 1.2.3. When the Orchestrator DxM was updated via the Admin app, it could occur that this was displayed as a failed deployment even though it actually succeeded. This will now be prevented.
