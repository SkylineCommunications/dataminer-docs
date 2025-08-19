---
uid: General_Feature_Release_10.5.10
---

# General Feature Release 10.5.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.10](xref:Cube_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Object Models: Attachments can now be uploaded to a network share [ID 43114] [ID 43366]

<!-- MR 10.6.0 - FR 10.5.10 -->

In `ModuleSettings`, `DomManagerSettings` now contains a new `DomInstanceNetworkAttachmentSettings` class that allows you to save DOM instance attachments to a network share instead of to the *Documents* module.

The `DomInstanceNetworkAttachmentSettings` class contains the following properties:

- `NetworkSharePath` (string)

  The UNC path to the network share where the attachments should be saved.

  This path has to start with `\\` and cannot contain any characters that are illegal for a path (e.g. "<") or strings that allow directory traversal (e.g. "../").

  When the path is left empty, attachments are saved to the `C:\Skyline DataMiner\Documents` folder. This is the default behavior.

- `CredentialId` (GUID)

  The ID of the credentials in the credentials library that will be used to add the attachment to the network share.

  These credentials must be of type *Username and password credentials* and must be the credentials of a user that has read/write access to the path defined in `NetworkSharePath`. In case you have a Windows network share, you need to add the domain name (for a domain user) or hostname (for a local user) in front of the username (e.g. "MYPC\userName").

> [!NOTE]
>
> - When a DOM module is configured to save attachments to a network share, the system will validate whether the user creating/updating the `ModuleSettings` has permission to access the credentials. Once this is set up, any user that has permissions to create or update a `DomInstance` can save attachments to the network share under the configured user.
> - When a DOM module is configured to save attachments to a network share, no migration is done of existing attachments. They will continue to exist in the `C:\Skyline DataMiner\Documents` folder, but will no longer work. You can copy them over or move them to the network share; the folder structure is the same. Likewise, when removing the configuration to save attachments to a network share, no migration is done of attachments available on the previously configured network share.
> - By default, the size of the attachments is limited to 20 MB. See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml#documentsmaxsize).

#### gRPC now used by default for communication between DataMiner Agents [ID 43190] [ID 43260] [ID 43305] [ID 43331] [ID 43435] [ID 43506]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, .Net Remoting was used by default for communication between DataMiner Agents, though it was possible to set gRPC as the default instead (either by adding *Redirect* tags in DMS.xml or by disabling .NET Remoting in *MaintenanceSettings.xml*). Now gRPC will be the default instead, which means that the *EnableDotNetRemoting* setting in *MaintenanceSettings.xml* is now by default set to *false*.

When you upload an upgrade package that includes this change, the *VerifyGRPCConnection* prerequisite check will run to verify whether all DataMiner Agents in the cluster are ready to switch to using gRPC as the default communication type. This check will fail in case a possible configuration issue or connectivity issue is detected. For details, refer to [Upgrade fails because of VerifyGRPCConnection.dll prerequisite](xref:KI_Upgrade_fails_VerifyGRPCConnection_prerequisite).

We recommend uploading the package prior to the maintenance window for the upgrade, so you can already check beforehand whether all requirements for the upgrade are met and address any possible issues.

## Changes

### Enhancements

#### 'Webpages\Public' folder now synced between DataMiner Agents [ID 43458]

<!-- MR 10.6.0 - FR 10.5.10 -->

The folder `C:\Skyline DataMiner\Webpages\Public\` will now be synced between DataMiner Agents in a cluster. As a consequence, files that are installed in this folder can now also be included in the companion files of a DataMiner app package.

#### DxMs upgraded [ID 43557]

<!-- RN 43557: MR 10.6.0 - FR 10.5.10 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CloudGateway 2.17.11

The CloudGateway DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### Slow handling of concurrent requests to retrieve or update bookings [ID 43450]

<!-- MR 10.6.0 - FR 10.5.10 -->

When a lot of concurrent requests had to be processed by the Repository API in the background, e.g. to retrieve or update bookings, this could cause thread starvation in SLDataGateway, causing these requests to be handled much more slowly than usual.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`
