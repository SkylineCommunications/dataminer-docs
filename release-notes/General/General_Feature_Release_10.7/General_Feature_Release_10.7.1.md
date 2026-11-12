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

- [Document Intelligence: Assistant permission checks [ID 46944]](#document-intelligence-assistant-permission-checks-id-46944)

## Highlights

*No highlights have been selected yet.*

## New features

#### Security: New 'Intelligence Usage' user permission [ID 46765]

<!-- MR 10.7.0 - FR 10.7.1 -->

A new *Intelligence Usage* user permission has now been added. This permission will grant users access to all features related to DataMiner Intelligence.

> [!NOTE]
> The first time a system is upgraded to DataMiner version 10.7.0/10.7.1 or above, DataMiner will automatically grant this new permission to all existing groups with the *Admin Tools* permission.

#### Security: New 'Intelligence App' user permission [ID 46817]

<!-- MR 10.7.0 - FR 10.7.1 -->

A new *Intelligence App* user permission has now been added. This permission will grant users access to the Intelligence app.

> [!NOTE]
>
> - This permission is independent of the *Intelligence Usage* permission, which grants users access to all features related to DataMiner Intelligence.
> - The first time a system is upgraded to DataMiner version 10.7.0/10.7.1 or above, DataMiner will automatically grant this new permission to all existing groups with the *Admin Tools* permission.

## Changes

### Breaking changes

#### Document Intelligence: Assistant permission checks [ID 46944]

<!-- MR 10.7.0 - FR 10.7.1 -->

Each Document Intelligence request from SLNet now includes connection information so the Assistant can check the *Intelligence Usage* permission.

> [!IMPORTANT]
> Document Intelligence in DataMiner 10.6 is incompatible with Assistant versions that enforce these permission checks (i.e., Assistant 4.0.0 or newer).

### Enhancements

#### Load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM [ID 46134]

<!-- MR 10.7.0 - FR 10.7.1 -->

In preparation of service swarming, all load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM.

#### SLProtocol: Support for postPonePortInitialisation option removed [ID 46588]

<!-- MR 10.8.0 - FR 10.7.1 -->

Support for the [postPonePortInitialisation](xref:Protocol.Type-communicationOptions#postponeportinitialisation) communication option has been removed from SLProtocol.

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

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

This is especially useful when scripts are executed asynchronously using the `DEFER:TRUE` option, as clients can track when a script starts and finishes.

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

#### SLScripting can no longer run as a service [ID 46869]

<!-- MR 10.7.0 - FR 10.7.1 -->

From now on, SLScripting will no longer be able to run as a service. It will always run as a server instead.

#### MessageBroker: Large ChunkingMessageBroker replies will now use acknowledged chunks [ID 46882]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

From now on, large ChunkingMessageBroker replies will use acknowledged chunks to avoid NATS slow consumer exceptions.

#### DataMiner upgrade: Web-only upgrades to 10.7.x or later require at least 10.6.0 [ID 46910]

<!-- MR 10.8.0 - FR 10.7.1 -->

Web-only upgrade packages for version 10.7.x or later will now be blocked on DataMiner Agents running a server version older than 10.6.0. The error message will indicate this minimum version requirement.

For example, before installing a 10.7.x web-only upgrade on a DataMiner Agent running 10.5.0, you will first have to perform a full upgrade to 10.6.0 or later.

This validation does not affect full DataMiner upgrades.

#### Scheduler: Removed unnecessary DMAObjects dependency from SLNetTypes [ID 46914]

<!-- MR 10.8.0 - FR 10.7.1 -->

The `ScheduledTaskDetails` class, which is used only to migrate scheduled tasks from local storage to database storage, has been moved from SLNetTypes to SLNet.

As a result, SLNetTypes no longer depends on *Skyline.DataMiner.Core.DMAObjects.Config.dll*.

#### BrokerGateway: Increased timeout for applying manual configurations [ID 46949]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

The fixed timeout for the BrokerGateway `applymanualconfig` call has been increased from 5 minutes to 30 minutes.

#### Automation: Clearer error messages when script compilation fails [ID 46989]

<!-- MR 10.8.0 - FR 10.7.1 -->

When an automation script fails to compile, DataMiner will now report the `SL_AUTOMATION_SCRIPT_COMPILATION_FAILED` error, including the compiler diagnostics, when loading the script. Previously, the script would fail at runtime with a "No Assembly found for cookie" error and be retried 100 times.

The compilation error will be displayed when you execute the script in DataMiner Cube and returned when you execute it through code.

#### DataMiner upgrade: Removal of unused SLScripting DLL files [ID 47015]

<!-- MR 10.8.0 - FR 10.7.1 -->

DataMiner upgrades will now remove the following unused DLL files from `C:\Skyline DataMiner\Files\SLScripting\x86`:

- *Skyline.DataMiner.Core.DMAObjects.Config.dll*
- *Skyline.DataMiner.Core.StorageModule.dll*

These files are no longer required following changes to the dependencies of SLNetTypes. They will be removed during both legacy and orchestrator upgrades.

### Fixes

#### Deleted-service information events would no longer have the service impact of the deleted service [ID 46195]

<!-- MR 10.7.0 [CU0] - FR 10.7.1 -->

Up to now, when a service was deleted, the generated deleted-service information event would incorrectly no longer have the service impact of that deleted service.

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

#### StorageModule: Errors or missing data when retrying storage operations [ID 46815]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a StorageModule insert operation was retried after a NATS timeout, it could be executed twice. The retry would then fail with an error indicating that the file or database row already existed. Insert operations now use an idempotency key to prevent the same operation from being executed more than once.

During paged read operations, retries when fetching pages after the first page could cause data to be missed following a timeout. These requests will no longer be retried. If a read operation fails, an error will be returned instead.

#### Failover: Memory and CPU spikes on offline Agents when updating services or elements [ID 46875]

<!-- MR 10.7.0 - FR 10.7.1 -->

When services or elements were updated in a DataMiner cluster, offline Agents in a Failover setup would experience a memory and CPU spike in the StorageModule process for each update. The size of the spike depended on the number of services and elements in the cluster.

Both online and offline Agents will now keep their XML-based services in memory at all times. The service cache in the StorageModule backend will only be reinitialized during a Failover switch or in exceptional circumstances.

#### DataMiner upgrade: SLNet garbage collection settings could be overwritten [ID 46905]

<!-- MR 10.8.0 - FR 10.7.1 -->

During a DataMiner upgrade, the `<runtime>` section of *SLNet.exe.config* was replaced with the version from the upgrade package. This could overwrite the machine-specific `gcServer` and `GCHeapCount` settings.

#### Service & Resource Management: Canceled reservations could prevent resource updates [ID 46952]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Resources could not be updated when they were used by a canceled reservation. This could prevent changes to the resource mode, such as putting a resource into maintenance, as well as changes to its availability window or capacity.

Canceled reservations are now ignored when checking whether resource updates would cause reservations to enter quarantine.
