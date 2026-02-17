---
uid: artifactdeployer_change_log
---

# ArtifactDeployer change log

#### 28 August 2025 - Enhancement - ArtifactDeployer 1.8.7 - Dependencies updated

Several dependencies have been updated.

#### 27 August 2025 - Enhancement - ArtifactDeployer 1.8.6 - General improvements

General improvements have been made to the way ArtifactDeployer handles tasks, making the DxM more robust and also improving its shutdown procedure.

#### 24 June 2025 - Enhancement - ArtifactDeployer 1.8.5 - Improved upgrade process

Improvements have been made to the startup and shutdown of the DxM, which improves the upgrade process.

#### 17 June 2025 - Enhancement - ArtifactDeployer 1.8.4 - Improved upgrade process

Improvements have been made to the shutdown of the DxM, which improves the upgrade process.

#### 1 April 2025 - Enhancement - Dependencies updated [ID 42654]

Several dependencies have been updated.

#### 5 November 2024 - Fix - ArtifactDeployer 1.8.2 - Fix memory leak [ID 41335]

A NuGet dependency used by ArtifactDeployer could cause a memory leak. The dependencies have been updated to resolve this.

#### 30 October 2024 - Enhancement - ArtifactDeployer 1.8.1 - Dependencies updated [ID 41283]

Several dependencies have been updated.

#### 8 August 2024 - Enhancement - ArtifactDeployer 1.8.0 - Upgrade to .NET 8 [ID 40441]

DataMiner ArtifactDeployer has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 25 July 2024 - Enhancement - ArtifactDeployer 1.7.2 - Dependencies updated & event handling improved [ID 40308]

Several dependencies have been updated. In combination with CloudGateway 2.13.15, events rejected by dataminer.services will no longer be retried and will be discarded.

#### 30 May 2024 - Fix - ArtifactDeployer 1.7.1 - Missing Azure.Core.dll after upgrading to ArtifactDeployer 1.7.0 [ID 39783]

An issue has been resolved where a required `Azure.Core.dll` went missing after an upgrade to ArtifactDeployer 1.7.0. This did not happen with a clean installation of ArtifactDeployer 1.7.0.

#### 23 May 2024 - Enhancement - ArtifactDeployer 1.7.0 - Deployment event improvements [ID 39717]

An improvement has been implemented to the way Catalog and DxM deployment events are forwarded to dataminer.services. This will reduce the number of deployments that are incorrectly shown as failures on dataminer.services even though they actually succeeded.

#### 26 April 2024 - Fix - ArtifactDeployer 1.6.10 - Inconsistent cloud endpoint detection failures [ID 39513]

An issue has been resolved that could make features like DxM and Catalog deployments inconsistently fail.

#### 29 March 2024 - Enhancement - ArtifactDeployer 1.6.9 - Added the possibility to locally disable artifact deployments through the app settings [ID 39113]

It is now possible to locally disable artifact deployments through the *App settings* file of the ArtifactDeployer DxM.

To do so, set *DeployArtifactOptions:IsDisabled* to *true* in the app settings. On each server where DataMiner ArtifactDeployer is installed, navigate to `C:\Program Files\Skyline Communications\DataMiner ArtifactDeployer` and either create or modify *appsettings.custom.json* with the following configuration:

```json
{
   "DeployArtifactOptions": {
      "IsDisabled": true
   }
}
```

#### 13 March 2024 - Enhancement - ArtifactDeployer 1.6.8 - Dependencies updated [ID 39046]

Several dependencies have been updated.

#### 4 March 2024 - Enhancement - ArtifactDeployer 1.6.7 - Improved installer robustness [ID 38940]

The ArtifactDeployer installer has been updated to mitigate a Windows DLL redirection vulnerability and to improve its robustness.

#### 22 February 2024 - Enhancement - ArtifactDeployer 1.6.6 - Improved deployment robustness [ID 38852]

Robustness for Catalog and DxM deployments has been improved by adding and improving retry mechanisms.

> [!TIP]
> To make use of all the enhancements, also install Orchestrator 1.5.5.

#### 22 January 2024 - Enhancement - ArtifactDeployer 1.6.5 - Added DMA ID to deployment events [ID 38485]

In combination with CoreGateway 2.14.0 or higher, the ArtifactDeployer will be able to include the DMA ID in deployment events, visible on the *Deployments* page of a DMS in the [Admin app](https://admin.dataminer.services). In case of a failure, particularly in a cluster, this ID provides a direct link to the server whose logs you need to examine for further investigation.

#### 16 January 2024 - Enhancement - ArtifactDeployer 1.6.4 - Improved DxM status reporting [ID 38447]

The ArtifactDeployer DxM will now periodically send a health check to the cloud to indicate that the DxM is running using correct identifiers.

#### 16 January 2024 - Enhancement - ArtifactDeployer 1.6.3 - Added node ID to deployment events [ID 38421]

The ArtifactDeployer will include the node ID in deployment events, visible on the *Deployments* page of a DMS in the [Admin app](https://admin.dataminer.services). In case of a failure, particularly in a cluster, this ID provides a direct link to the server whose logs you need to examine for further investigation.

#### 20 December 2023 - New feature - ArtifactDeployer 1.6.0 - DxM status reporter added [ID 38172]

The ArtifactDeployer DxM will now periodically send a health check to the cloud to indicate that the DxM is running.

#### 8 November 2023 - Fix - ArtifactDeployer 1.5.2 - Issue where a timeout error was logged in ArtifactDeployer [ID 37784]

When Orchestrator 1.4.0 and/or ArtifactDeployer 1.5.1 or older were used, in some specific cases, the ArtifactDeployer DxM logged a timeout exception when the Orchestrator DxM encountered an error. This has now been resolved.

#### 8 November 2023 - Fix - ArtifactDeployer 1.5.2 - Deployment issues with ArtifactDeployer 1.5.1 in clusters [ID 37785]

When ArtifactDeployer 1.5.1 was used in a cluster, it could occur that deployments were displayed as pending or failed, and there were many events in the details overlay on admin.dataminer.services, while in fact the deployment had succeeded. This has now been resolved.

#### 2 November 2023 - Fix - ArtifactDeployer 1.5.1 - Issue when hosting server of DataMiner CloudGateway had more than one NIC [ID 37762]

When ArtifactDeployer 1.5.1 or earlier was used, it could occur that deployments failed when the CloudGateway module was installed on a server with more than one network interface (NIC). This has now been resolved.

Make sure to also install DataMiner CloudGateway 2.12.3 to make use of this fix.

#### 11 August 2023 - Enhancement - ArtifactDeployer 1.5.0 - Upgrade to .NET 6 [ID 37103]

DataMiner ArtifactDeployer has been upgraded to .NET 6, so that it no longer depends on .NET 5. **Make sure .NET 6 is installed** before you upgrade to this version.

#### 15 May 2023 - Enhancement - ArtifactDeployer 1.4.6 - Connection improvements [ID 36403]

A retry mechanism has been implemented to fetch the cloud endpoint. If after the retries, still no cloud endpoint can be received, the module will fall back to trying to access dataminer.services directly. If this is not possible, the module will log the failed actions.

#### 26 April 2023 - Enhancement - ArtifactDeployer 1.4.5 - ArtifactDeployer no longer requires direct internet access [ID 36284]

By using the cloud endpoint available since DataMiner CloudGateway 2.10.0 (included in the Cloud Pack 2.8.2), the DataMiner ArtifactDeployer can be installed on servers without internet access. As such, internet access is now no longer required for this DxM.

> [!NOTE]
> For this feature to work, traffic must be allowed via port 5100 on the internal network, and DataMiner CloudGateway 2.10.0 or higher must be installed.

#### 19 April 2023 - Enhancements - ArtifactDeployer 1.4.4 - General improvements [ID 36058]

Changes have been implemented in DataMiner ArtifactDeployer to improve its general stability.

#### 3 April 2023 - Enhancement - ArtifactDeployer 1.4.3 - Dependencies updated [ID 35990]

Several dependencies have been updated. This includes security-related improvements.

#### 16 December 2022 - Fix - ArtifactDeployer 1.4.2 - Problem with long-running deployments [ID 35174]

If a large package was deployed from the catalog, which took a relatively long time to deploy, it could occur that this did not work correctly.

This fix is included in Cloud Pack 2.8.3.

#### 28 November 2022 - Fix - ArtifactDeployer 1.4.1 - Proxy issue in DataMiner ArtifactDeployer 1.4.0 [ID 35013]

Because of an issue in the proxy configuration of DataMiner ArtifactDeployer 1.4.0, artifacts could not be deployed. This has been resolved in DataMiner ArtifactDeployer 1.4.1.

This enhancement is included in Cloud Pack version 2.8.2.

#### 18 July 2022 - New feature - ArtifactDeployer 1.4.0 - Proxy support [ID 33972]

Proxy support has been added for DataMiner ArtifactDeployer. When you configure this, all outgoing traffic towards the public internet will pass through the proxy server.

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

#### 27 May 2022 - ArtifactDeployer 1.3.0 - Enhancements to support CI/CD deployment [ID 33534]

This version contains enhancements to support the CI/CD deployment feature.
