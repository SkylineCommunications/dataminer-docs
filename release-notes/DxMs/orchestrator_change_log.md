---
uid: orchestrator_change_log
---

# Orchestrator change log

#### 16 October 2025 - Enhancement - Orchestrator 1.8.0 - Improved service recovery after reboot

From now on, DataMiner services will automatically restart after a Windows reboot, ensuring essential services are recovered even if BrokerGateway or related components are not yet running.

In addition, the startup type of DataMiner Orchestrator is now set to "Automatic (Delayed Start)" by default to improve system stability during startup.

#### 1 July 2025 - Fix - Orchestrator 1.7.8 - Deploying the Orchestrator DxM from the Admin app removes the Orchestrator DxM

An issue introduced in Orchestrator 1.7.6 made it impossible to upgrade or downgrade the DxM from the [Admin app](https://admin.dataminer.services). Trying to do so would cause the DxM to be uninstalled, leaving the server in a state where none of the DxMs could be updated from the Admin app.

This issue is fixed in Orchestrator 1.7.8. However, to upgrade any servers running Orchestrator 1.7.6 or 1.7.7 to this version (or higher versions), you will need to install the [DataMiner Cloud Pack 3.3.3](https://community.dataminer.services/dataminer-cloud-pack/).

#### 24 June 2025 - Enhancement - Orchestrator 1.7.7 - Improved upgrade process

Improvements have been made to the startup and shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - Orchestrator 1.7.6 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 1 April 2025 - Enhancement - Orchestrator 1.7.5 - Dependencies updated [ID 42657]

Several dependencies have been updated.

#### 12 November 2024 - Fix - Orchestrator 1.7.4 - Installer caused Orchestrator startup issue [ID 41404]

A DLL issue in the installer of Orchestrator 1.7.2 caused the service to be unable to start, which could make it impossible to still update DxMs from the [Admin app](https://admin.dataminer.services).

To resolve this issue, the [DataMiner Cloud Pack 3.2.2](https://community.dataminer.services/dataminer-cloud-pack/) or higher can be used to install Orchestrator 1.7.4 or higher on each server.

#### 5 November 2024 - Fix - Orchestrator 1.7.2 - Fix memory leak [ID 41336]

A dependency used by Orchestrator could cause a memory leak. The dependencies have been updated to resolve this.

#### 30 October 2024 - Enhancement - Orchestrator 1.7.1 - Dependencies updated [ID 41284]

Several dependencies have been updated.

#### 8 August 2024 - Enhancement - Orchestrator 1.7.0 - Upgrade to .NET 8 [ID 40438]

DataMiner Orchestrator has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 25 July 2024 - Enhancement - Orchestrator 1.6.1 - Dependencies updated & event handling improved [ID 40309]

Several dependencies have been updated. In combination with CloudGateway 2.13.15, events rejected by dataminer.services will no longer be retried and will be discarded.

#### 30 April 2024 - Enhancement - Orchestrator 1.6.0 - Retries after failed DxM installation [ID 39519]

The Orchestrator will now retry the installation of a DxM when the installation was interrupted.  

#### 26 April 2024 - Fix - Orchestrator 1.5.9 - Inconsistent cloud endpoint detection failures [ID 39512]

An issue has been resolved that could make features like DxM and Catalog deployments, Remote Log Collection, and data offloads for proactive support inconsistently fail.

#### 13 March 2024 - Enhancement - Orchestrator 1.5.8 - Dependencies updated [ID 39047]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - Orchestrator 1.5.7 - Improved installer robustness [ID 38938]

The Orchestrator installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 26 February 2024 - Fix - Orchestrator 1.5.6 - Orchestrator installer runs indefinitely [ID 38895]

The installation of the Orchestrator on servers with the system language set to a language other than English, such as German, would result in the installer running indefinitely. This issue has been resolved.

#### 22 February 2024 - Enhancement - Orchestrator 1.5.5 - Improved DxM deployment robustness [ID 38853] [ID 38862] [ID 38875]

Robustness for DxM deployments has been improved by adding and improving retry mechanisms, improving the management of processes, and giving the service more time to shut down gracefully.

> [!TIP]
> To make use of all the enhancements, also install ArtifactDeployer 1.6.6.

#### 30 January 2024 - Enhancement - Orchestrator 1.5.4 - Improved DxM status reporting [ID 38553]

The Orchestrator DxM will now offload more information about the cloud endpoint.

#### 16 January 2024 - Enhancement - Orchestrator 1.5.3 - Improved DxM status reporting [ID 38449]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 20 December 2023 - New feature - Orchestrator 1.5.0 - DxM status reporter added [ID 38170]

The Orchestrator DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Enhancement - Orchestrator 1.4.1 [ID 37785]

Several dependencies have been updated.

#### 8 November 2023 - Enhancement - Orchestrator 1.4.1 - Improved logging [ID 37175]

Logging for the Orchestrator DxM has been improved. In several cases, the log level has been adjusted to improve visibility of important logs.

#### 11 August 2023 - Enhancement - Orchestrator 1.4.0 - Upgrade to .NET 6 and more server and DMA data offloaded to improve user experience [ID 37105] [ID 36819]

DataMiner Orchestrator has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

From now on, the DxM will also offload more data about the DMA and the server to dataminer.services to improve the user experience:

- DataMiner version and version history
- Installed dotnet runtimes
- System info such as the Windows version

#### 19 April 2023 - Enhancements - Orchestrator 1.3.3 - General improvements [ID 36031]

Changes have been implemented in DataMiner Orchestrator to improve its general stability.

#### 7 April 2023 - Fix - Orchestrator 1.3.2 - Orchestrator DxM uninstalled after attempt to update it on Window Server 2016 [ID 36106]

When the DataMiner Orchestrator DxM was updated via the Admin app on Window Server 2016, it could occur that the service was uninstalled but not updated.

#### 16 November 2022 - Enhancement - Orchestrator 1.2.6 - DMA name and ID synced to dataminer.services [ID 34670]

From now on, the DataMiner Orchestrator will sync the DMA name and ID to dataminer.services. This is for example used on the *Nodes* page of the Admin app so users can easily identify a DMA to update its DxMs.

This enhancement is included in Cloud Pack version 2.8.2.

#### 7 July 2022 - Fix - Orchestrator 1.2.5 - Not possible to deploy DxMs via Admin app [ID 33998]

In some cases, it could occur that the DataMiner Orchestrator got stuck while it was installing a DxM, and it became unable to handle updates. This made it impossible to deploy any more DxMs via the Admin app.

#### 7 June 2022 - Fix - Orchestrator 1.2.3 - Orchestrator DxM update incorrectly displayed as failed [ID 33685]

The Orchestrator DxM has been updated to version 1.2.3. When the Orchestrator DxM was updated via the Admin app, it could occur that this was displayed as a failed deployment even though it actually succeeded. This will now be prevented.
