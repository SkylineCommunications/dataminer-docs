---
uid: General_Feature_Release_10.7.1
description: "Release notes for General Feature Release 10.7.1, including prerequisites, new features, enhancements, and fixes planned for this preview release."
---

# General Feature Release 10.7.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.7.1](xref:Cube_Feature_Release_10.7.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.7.1](xref:Web_apps_Feature_Release_10.7.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

## Important changes

*No important changes have been selected yet.*

## Highlights

*No highlights have been selected yet.*

## New features

#### Security: New 'Intelligence Usage' user permission [ID 46765]

<!-- MR 10.8.0 - FR 10.7.1 -->

A new *Intelligence Usage* user permission has now been added. This permission will grant users access to all features related to DataMiner Intelligence.

> [!NOTE]
> The first time a system is upgraded to DataMiner version 10.8.0/10.7.1 or above, DataMiner will automatically grant this new permission to all existing groups with the *Admin Tools* permission.

#### Security: New 'Intelligence App' user permission [ID 46817]

<!-- MR 10.8.0 - FR 10.7.1 -->

A new *Intelligence App* user permission has now been added. This permission will grant users access to the Intelligence app.

> [!NOTE]
>
> - This permission is independent of the *Intelligence Usage* permission, which grants users access to all features related to DataMiner Intelligence.
> - The first time a system is upgraded to DataMiner version 10.8.0/10.7.1 or above, DataMiner will automatically grant this new permission to all existing groups with the *Admin Tools* permission.

## Changes

### Enhancements

#### Load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM [ID 46134]

<!-- MR 10.7.0 - FR 10.7.1 -->

In preparation of service swarming, all load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM.

#### SLProtocol: Support for postPonePortInitialisation option removed [ID 46588]

<!-- MR 10.8.0 - FR 10.7.1 -->

Support for the [`postPonePortInitialisation`](xref:Protocol.Type-communicationOptions#postponeportinitialisation) communication option has been removed from SLProtocol.

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.8.0 - FR 10.7.1 -->

From now on, an upgrade action will automatically add a `Set-Cookie` header to `WebPages/web.config` on systems with SAML authentication enabled. This cookie configures web authentication to use redirects instead of an embedded iframe, ensuring compatibility with SAML providers that do not allow their sign-in pages to be displayed in an iframe.

The upgrade action will leave the configuration unchanged if SAML is disabled or the required cookie header is already configured. Existing custom headers, including `Set-Cookie` headers for other cookies, will be preserved.

#### DataMiner upgrade: Improved performance of the ValidateConnectors prerequisite [ID 46743]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The `ValidateConnectors` upgrade prerequisite checks for installed connector versions that are incompatible with the target DataMiner version. Previously, it recursively scanned the entire `C:\Skyline DataMiner\Protocols` folder, which could slow down upgrade prerequisite checks on DataMiner Agents with many connectors or large connector version folders.

From now on, it will only scan folders for connectors on the incompatibility list, and only at the level where *protocol.xml* is expected. This makes the check faster and less sensitive to unrelated content in the *Protocols* folder.

The incompatible connector versions reported, the message shown, and the requirement to remove those versions before upgrading remain unchanged. No configuration is required.

#### Automation: Progress notifications for non-interactive scripts [ID 46778]

<!-- MR 10.8.0 - FR 10.7.1 -->

From now on, clients can add the `PROGRESS` execution option to an `ExecuteScriptMessage` to receive progress notifications for non-interactive automation scripts. This extends the progress tracking already available for interactive scripts.

This is especially useful when scripts are executed asynchronously using the `DEFER:TRUE` option, as clients can track when a script starts and finishes without waiting for execution to complete.

Before sending the `ExecuteScriptMessage`, the client must subscribe to `ScriptProgressEventMessage` events. Use the returned `ScriptID` and the DataMiner ID to identify events associated with that script execution.

For example:

```csharp
var executeMessage = new ExecuteScriptMessage("MyScript")
{
    DataMinerID = dmaId,
    Options = new SA(new[] { "DEFER:TRUE", "PROGRESS" })
};

var response = (ExecuteScriptResponseMessage)connection.HandleSingleResponseMessage(executeMessage);
var scriptId = response.ScriptID;
```

For scripts executed with `PROGRESS`, SLAutomation can send the following `ScriptProgressEventMessage` notifications:

- `Started`: The script has started executing.
- `Completed`: The script has finished executing. The notification includes the execution result.
- `RunStatus` or `DelayInfo`: Additional execution status information, for example, when the script is waiting for locked resources or an error occurs.
- `Progress`: Progress explicitly communicated by the script.

The existing behavior for interactive scripts remains unchanged. Scripts executed with the `INTERACTIVE` option can additionally receive the following notifications:

- `InteractiveUI`: The script is paused and requires input from the client.
- `Detached`: The client has detached from the script.
- `Hidden`: The client interface should be hidden.

#### DataMiner upgrade: Prerequisite check for Communication Gateway DxM version [ID 46798]

<!-- MR 10.8.0 - FR 10.7.1 -->

During a DataMiner upgrade, a new prerequisite check will verify the version of the installed Communication Gateway DxM. If the installed version is older than 5.3.5, the upgrade will be blocked.

If the installed Communication Gateway DxM version is older than 4.0.0, the check will also identify the following connectors that use an outdated version of the `Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol` NuGet package:

- Arista eOS Manager versions older than 1.0.0.5
- CISCO Nexus versions older than 3.0.7.3

To resolve these issues, upgrade Communication Gateway DxM to version 5.3.5 or higher. If any elements use a listed connector, configure them to use a connector version that uses version 6.0.0 or higher of the NuGet package. Remove listed connectors that are not in use.

The additional connector check only detects these known connectors. Make sure no other connectors in use depend on a version of the NuGet package older than 6.0.0.

#### DataMiner upgrade: Web-only upgrades to 10.7.x or later require at least 10.6.0 [ID 46910]

<!-- MR 10.8.0 - FR 10.7.1 -->

Web-only upgrade packages for version 10.7.x or later will now be blocked on DataMiner Agents running a server version older than 10.6.0. The error message will indicate this minimum version requirement.

For example, before installing a 10.7.x web-only upgrade on a DataMiner Agent running 10.5.0, you will first have to perform a full upgrade to 10.6.0 or later.

This validation does not affect full DataMiner upgrades.

### Fixes

#### Deleted-service information events would no longer have the service impact of the deleted service [ID 46195]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] / 10.7.0 [CU0] - FR 10.7.1 -->

Up to now, when a service was deleted, the generated deleted-service information event would incorrectly no longer have the service impact of that deleted service.

#### Service property updates through class libraries could create invalid duplicate system-managed properties [ID 46370]

<!-- MR 10.7.0 - FR 10.7.1 -->

When a class library incorrectly sent system-managed service properties as read-write, duplicate invalid properties could be created while preserving the original read-only properties, causing DataMiner to block the properties update.

From now on, a compatibility safeguard removes invalid read-write duplicates before restoring the correct read-only system-managed properties. Custom service properties remain unaffected.

#### SLNet: Array index errors when retrieving alarm filter, trend filter, or redundancy group information [ID 46607]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

SLNet could throw an `IndexOutOfRangeException` when retrieving available alarm filter, trend filter, or redundancy group information if an SLXML query returned an array with unexpected dimensions.

SLNet will now retry failed redundancy group queries once after a short delay. Array index errors will also be logged in *SLNet.txt* with the variable name, the exact array index, and the complete query response array in compressed form to help diagnose the issue.

#### STaaS: Incomplete state-change history after migrating from Cassandra [ID 46769]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

After migrating from Cassandra to STaaS, state-change history could be incomplete for parameters in index-only tables or tables with a display column when the parameter instance contained uppercase characters. This could affect dashboards and heatlines in DataMiner Cube.

This issue occurred when history was stored under both the original-case and lowercase instances. State-change retrieval now reads both instances and merges the results by timestamp, giving precedence to the lowercase instance when timestamps match.

#### DataMiner services could fail to load during DataMiner startup [ID 46773]

<!-- MR 10.7.0 - FR 10.7.1 -->
<!-- Not added to MR 10.7.0 - Introduced by RNs 46061 and 46134 -->

Since DataMiner Feature Release 10.6.10, in some cases, DataMiner services could fail to load during DataMiner startup.

#### Standalone BPA executor: BPA tests requiring SLNet could fail to run [ID 46809]

<!-- MR 10.5.0 [CU22]/10.6.0 [CU10] - FR 10.7.1 -->

The standalone BPA executor would throw a `NullReferenceException` when running a manually loaded BPA DLL file with the `RequireSLNet` flag, preventing the BPA test from executing.
