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

- DataMiner Object Models: Attachments can now be uploaded to a network share [ID 43114] [ID 43366]

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

#### DataMiner upgrade: New prerequisite check 'VerifyBrokerGatewayMigration' [ID 43526]

<!-- MR 10.6.0 - FR 10.5.10 -->

A new *VerifyBrokerGatewayMigration* prerequisite check has been added to prepare for the upcoming mandatory migration to BrokerGateway. However, this check is not yet relevant for users outside of Skyline Communications.

## Changes

### Enhancements

#### APIGateway: Kernel response buffering will now be enabled by default [ID 43346]

<!-- MR 10.6.0 - FR 10.5.10 -->

In the APIGateway settings, the `EnableKernelResponseBuffering` setting will now be enabled by default.

If you wish to disable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": false } }
   ```

#### 'Webpages\Public' folder now synced between DataMiner Agents [ID 43458]

<!-- MR 10.6.0 - FR 10.5.10 -->

The folder `C:\Skyline DataMiner\Webpages\Public\` will now be synced between DataMiner Agents in a cluster. As a consequence, files that are installed in this folder can now also be included in the companion files of a DataMiner app package.

#### SLNet-managed NATS solution: Credentials of the local agent will now be compared against the credentials of the primary NAS node [ID 43514]

<!-- MR 10.6.0 - FR 10.5.10 -->

In the *ResetNATSCheck* timer of the SLNet-managed NATS solution, the credentials of the local agent will now be compared against the credentials of the primary NAS node. If these do not match, the NATS configuration of the local agent will be reset, and the correct credentials of the primary node will be used instead.

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

#### Swarming: Problem when redundancy groups contained DVE child elements acting as primary or backup elements [ID 43286] [ID 43492]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When Swarming was enabled, in some rare cases, SLDMS and SLDataMiner could get into a deadlock when the system contained redundancy groups in which DVE child elements acted as primary or backup elements.

#### Slow handling of concurrent requests to retrieve or update bookings [ID 43450]

<!-- MR 10.6.0 - FR 10.5.10 -->

When a lot of concurrent requests had to be processed by the Repository API in the background, e.g. to retrieve or update bookings, this could cause thread starvation in SLDataGateway, causing these requests to be handled much more slowly than usual.

#### SLDataGateway: Problem when NULL values were written to indexed logger tables [ID 43456]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, a `NullReference` exception would be thrown in SLDataGateway when NULL values were written to indexed logger tables.

#### Swarming: Problem when trying to retrieve an element from the SLNet event cache while it was being swarmed [ID 43461]

<!-- MR 10.6.0 - FR 10.5.10 -->
<!-- Not added to MR 10.6.0 -->

In some rare cases, an error could occur when trying to retrieve an element from the SLNet event cache while it was being swarmed.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`

#### SLNet-managed NATS solution: Problem when multiple calls accessed the NATS credentials simultaneously [ID 43504]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when multiple NATSCustodian calls tried to retrieve the NATS credentials simultaneously, in some cases, those credentials could get corrupted.

#### Problem with gRPC connections [ID 43542]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a deadlock could occur in the `Grpc.Net.Client` library, causing active gRPC connections to get stuck.

#### DataMiner Connectivity Framework: ConnectivityChangedEvent would incorrectly be sent every second [ID 43547]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element with DCF connections had correlation rules configured, up to now, a `ConnectivityChangedEvent` would be sent every second, even when nothing had changed.

#### SLNet would interpret the messages incorrectly when matrix crosspoints were loaded or saved over a gRPC connection in DataMiner Cube [ID 43551]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in DataMiner Cube, matrix crosspoints were loaded or saved over a gRPC connection, in some cases, SLNet would interpret the messages incorrectly.
