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

- [Scheduler: Swarmed tasks could execute actions configured for another task [ID 46728]](#scheduler-swarmed-tasks-could-execute-actions-configured-for-another-task-id-46728)
- [GQI: GQI via SLHelper disabled by default [ID 46927]](#gqi-gqi-via-slhelper-disabled-by-default-id-46927)
- [Service & Resource Management: Support for legacy reservations removed [ID 46931]](#service--resource-management-support-for-legacy-reservations-removed-id-46931)
- [Document Intelligence: Assistant permission checks [ID 46944]](#document-intelligence-assistant-permission-checks-id-46944)
- [DataMiner upgrade: Prerequisite check for the end of SLHelper GQI support [ID 46957]](#dataminer-upgrade-prerequisite-check-for-the-end-of-slhelper-gqi-support-id-46957)
- [DataMiner upgrade: Prerequisite checks for End of Support and End of Life features [ID 46984]](#dataminer-upgrade-prerequisite-checks-for-end-of-support-and-end-of-life-features-id-46984)
- [DataMiner startup: MySQL requires an explicit End of Support override [ID 47000]](#dataminer-startup-mysql-requires-an-explicit-end-of-support-override-id-47000)
- [QActions: JScript and VBScript are no longer supported [ID 47010]](#qactions-jscript-and-vbscript-are-no-longer-supported-id-47010)
- [Security: Atlassian Crowd authentication is no longer supported by default [ID 47014]](#security-atlassian-crowd-authentication-is-no-longer-supported-by-default-id-47014)
- [Security: RADIUS authentication is no longer supported by default [ID 47018]](#security-radius-authentication-is-no-longer-supported-by-default-id-47018)
- [Connectors: dllName and DirectConnection are no longer supported by default [ID 47028]](#connectors-dllname-and-directconnection-are-no-longer-supported-by-default-id-47028)
- [Automation: Script Runner could load an incorrect assembly version [ID 47069]](#automation-script-runner-could-load-an-incorrect-assembly-version-id-47069)

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

#### Service & Resource Management: Support for legacy reservations removed [ID 46931]

<!-- MR 10.7.0 - FR 10.7.1 -->

Support for legacy Resource Manager reservations has been removed from the DataMiner server. From now on, use `ReservationInstance` objects instead of legacy reservations.

The related types remain available in SLNetTypes so existing projects can still compile. However, the following API members have been marked as obsolete:

- The create, read, update, and delete (CRUD) methods for all three features in `ResourceManagerHelper`.
- The error data related to these features in `ResourceManagerErrorData`.
- The messages for the CRUD operations.
- The `ResourceManagerConfigInfoMessage.ConfigInfoType.ForceCleanup` enum value, which was only used to clean up reservation-related files.

SLNet will now throw a `DataMinerException` for CRUD requests related to these features or for a `ForceCleanup` request.

For compatibility with older DataMiner server versions, the legacy reservation methods in `ResourceManagerHelper` will still send requests to SLNet.

See also: [Service & Resource Management: Legacy reservation support removed for DataMiner 10.6.0 and later [ID 46936]](xref:Cube_Feature_Release_10.7.1#service--resource-management-legacy-reservation-support-removed-for-dataminer-1060-and-later-id-46936)

#### Document Intelligence: Assistant permission checks [ID 46944]

<!-- MR 10.7.0 - FR 10.7.1 -->

Each Document Intelligence request from SLNet now includes connection information so the Assistant can check the *Intelligence Usage* permission.

> [!IMPORTANT]
> Document Intelligence in DataMiner 10.6 is incompatible with Assistant versions that enforce these permission checks (i.e., Assistant 4.0.0 or newer).

#### QActions: JScript and VBScript are no longer supported [ID 47010]

<!-- MR 10.8.0 - FR 10.7.1 -->

Support for JScript and VBScript in QActions has reached End of Life and has been removed. An element that uses a connector containing a QAction with JScript or VBScript encoding will now go into an error state.

The default `*.js` and `*.vbs` files in `C:\Skyline DataMiner\ProtocolScripts` are no longer included in upgrade packages and will be removed during an upgrade.

In addition, the SLSite COM component will be uninstalled during an upgrade.

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

#### GQI: GQI via SLHelper disabled by default [ID 46927]

<!-- MR 10.8.0 - FR 10.7.1 -->

GQI via SLHelper is now disabled by default in favor of the GQI DxM. Legacy GQI requests will return an error directing you to use the GQI DxM instead.

As a temporary fallback, you can re-enable GQI via SLHelper by adding the following option to the `SLNet` section of `C:\Skyline DataMiner\SoftLaunchOptions.xml` and restarting DataMiner:

```xml
<SLNet>
  <EndOfSupport.SLHelperGQI>true</EndOfSupport.SLHelperGQI>
</SLNet>
```

The legacy GQI implementation in SLHelper will be removed completely in a later version.

#### SLNet: Faster updates of large subscription sets [ID 46934]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

SLNet will now update large subscription sets more efficiently, particularly when replacing a subscription set with one that contains only a few added or removed subscriptions.

#### BrokerGateway: Increased timeout for applying manual configurations [ID 46949]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

The fixed timeout for the BrokerGateway `applymanualconfig` call has been increased from 5 minutes to 30 minutes.

#### DataMiner upgrade: Prerequisite check for the end of SLHelper GQI support [ID 46957]

<!-- MR 10.7.0 - FR 10.7.1 -->

A new upgrade prerequisite will check whether DataMiner Agents running a version older than 10.7.0 are ready for the end of support for GQI via SLHelper. It will check two independent requirements:

- The Web API must use the GQI DxM. If the effective `gqi:useDxM` setting is `false`, the upgrade will be blocked.
- There must be no GQI log activity within the last 30 days, unless the `EndOfSupport.SLHelperGQI` soft-launch option is enabled to temporarily allow continued use of GQI via SLHelper. Otherwise, the upgrade will be blocked.

The prerequisite will report detected issues and inspection errors together with corrective actions. Enabling the soft-launch option will not bypass the Web API requirement.

The check will be skipped on DataMiner Agents already running version 10.7.0 or higher.

#### DataMiner upgrade: Prerequisite checks for End of Support and End of Life features [ID 46984]

<!-- MR 10.7.0 - FR 10.7.1 -->

DataMiner upgrades to version 10.7.x will now check for features that have reached End of Support or End of Life.

##### End of Support features

If any of the following features is in use, the upgrade will be blocked unless its corresponding case-sensitive soft-launch option is set to `true` in *SoftLaunchOptions.xml*:

| Feature | Soft-launch option |
|---------|--------------------|
| MySQL as the main database | `EndOfSupport.MySQL` |
| Elasticsearch 6.8 or earlier | `EndOfSupport.Elastic` |
| Cassandra 3.x or earlier | `EndOfSupport.Cassandra3` |
| Atlassian Crowd authentication or user and group management | `EndOfSupport.Crowd` |
| RADIUS authentication | `EndOfSupport.RADIUS` |

##### End of Life features

The upgrade will be blocked if either of the following configurations is present:

- .NET Remoting explicitly enabled in *MaintenanceSettings.xml* for communication between DataMiner Agents or between DataMiner Cube and SLNet.
- A two-site redundant indexing cluster (EMCO).

These checks have no soft-launch override. Remove or migrate these configurations before upgrading.

#### Automation: Clearer error messages when script compilation fails [ID 46989]

<!-- MR 10.8.0 - FR 10.7.1 -->

When an automation script fails to compile, DataMiner will now report the `SL_AUTOMATION_SCRIPT_COMPILATION_FAILED` error, including the compiler diagnostics, when loading the script. Previously, the script would fail at runtime with a "No Assembly found for cookie" error and be retried 100 times.

The compilation error will be displayed when you execute the script in DataMiner Cube and returned when you execute it through code.

#### DataMiner startup: MySQL requires an explicit End of Support override [ID 47000]

<!-- MR 10.7.0 - FR 10.7.1 -->

From now on, a DataMiner Agent using MySQL as its main database will no longer start unless the `EndOfSupport.MySQL` soft-launch option is set to `true`. If the option is missing or not set to `true`, DataMiner will stop and log an error.

To temporarily continue using MySQL, add the following case-sensitive option to `C:\Skyline DataMiner\SoftLaunchOptions.xml` and restart DataMiner:

```xml
<EndOfSupport.MySQL>true</EndOfSupport.MySQL>
```

Consider migrating to Cassandra Cluster or Storage as a Service (STaaS) instead.

#### Security: Atlassian Crowd authentication is no longer supported by default [ID 47014]

<!-- MR 10.7.0 - FR 10.7.1 -->

From now on, Atlassian Crowd authentication is no longer supported by default. This includes authenticating users against a Crowd server and importing users and groups from a Crowd server.

If Crowd is configured as the external authentication method in *DataMiner.xml* (`<ExternalAuthentication type="CROWD">`) and the `EndOfSupport.Crowd` soft-launch option is not set to `true`, the DataMiner Agent will log the reason and stop during startup. Without this override, saving Crowd external authentication settings will also be rejected.

To temporarily continue using Atlassian Crowd, add the following case-sensitive option to `C:\Skyline DataMiner\SoftLaunchOptions.xml` on every DataMiner Agent that uses Crowd, and restart DataMiner:

```xml
<SLNet>
  <EndOfSupport.Crowd>true</EndOfSupport.Crowd>
</SLNet>
```

#### DataMiner upgrade: Removal of unused SLScripting DLL files [ID 47015]

<!-- MR 10.8.0 - FR 10.7.1 -->

DataMiner upgrades will now remove the following unused DLL files from `C:\Skyline DataMiner\Files\SLScripting\x86`:

- *Skyline.DataMiner.Core.DMAObjects.Config.dll*
- *Skyline.DataMiner.Core.StorageModule.dll*

These files are no longer required following changes to the dependencies of SLNetTypes. They will be removed during both legacy and orchestrator upgrades.

#### Security: RADIUS authentication is no longer supported by default [ID 47018]

<!-- MR 10.7.0 - FR 10.7.1 -->

From now on, RADIUS authentication is no longer supported by default. This includes authenticating users against a RADIUS server.

If RADIUS is configured as the external authentication method in *DataMiner.xml* (`<ExternalAuthentication type="RADIUS">`) and the `EndOfSupport.RADIUS` soft-launch option is not set to `true`, the DataMiner Agent will log the reason and stop during startup. Without this override, saving RADIUS external authentication settings will also be rejected.

To temporarily continue using RADIUS, add the following case-sensitive option to `C:\Skyline DataMiner\SoftLaunchOptions.xml` on every DataMiner Agent that uses RADIUS, and restart DataMiner:

```xml
<SLNet>
  <EndOfSupport.RADIUS>true</EndOfSupport.RADIUS>
</SLNet>
```

#### Connectors: dllName and DirectConnection are no longer supported by default [ID 47028]

<!-- MR 10.8.0 - FR 10.7.1 -->

The following connector features have reached End of Support and are now disabled by default:

- The `dllName` option in the `options` attribute of a QAction.
- Logger tables of type `DirectConnection`.

During a DataMiner upgrade, the new `VerifyEndOfSupportConnectors` prerequisite check will block the upgrade if it detects connector versions that use either feature, unless the corresponding soft-launch option is enabled.

Before upgrading, configure affected elements to use connector versions that no longer contain these features, and remove detected connector versions that are no longer in use.

If no compatible connector version is available, you can continue using an affected connector by activating the corresponding soft-launch option before upgrading:

- `EndOfSupport.DllName` for the `dllName` option.
- `EndOfSupport.DirectConnection` for logger tables of type `DirectConnection`.

After the upgrade, uploading and using a connector with either feature will cause its elements to fail to start unless the corresponding soft-launch option is enabled.

> [!NOTE]
> The prerequisite check also detects JScript and VBScript QActions. These have reached End of Life and have no soft-launch override. See also [QActions: JScript and VBScript are no longer supported [ID 47010]](#qactions-jscript-and-vbscript-are-no-longer-supported-id-47010).

#### API Gateway: Per-module rate limits and request timeouts [ID 47105]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

Modules registering with the API Gateway DxM can now specify their own rate limit and request inactivity timeout:

- `rateLimitPerMinute`: A positive value sets an independent requests-per-minute quota for the module, shared across its paths. Requests to that module will not consume the existing shared quota of 60 requests per minute or affect other modules' quotas.
- `requestTimeoutSeconds`: A positive value overrides the default 100-second request inactivity timeout for the module. This is not a limit on the total request duration.

If either setting is omitted, zero, or negative, the existing behavior for that setting will be retained. Re-registering a module updates or removes its overrides without affecting other modules.

#### Remaining legacy Annotations reference removed [ID 47122]

<!-- MR 10.7.0 - FR 10.7.1 -->

The following remaining reference to the legacy Annotations module, which has reached end of life, have been removed:

- ISAPI filtering no longer takes `/annotations/` into account.

### Fixes

#### Deleted-service information events would no longer have the service impact of the deleted service [ID 46195]

<!-- MR 10.7.0 [CU0] - FR 10.7.1 -->

Up to now, when a service was deleted, the generated deleted-service information event would incorrectly no longer have the service impact of that deleted service.

#### SLNet: Array index errors when retrieving alarm filter, trend filter, or redundancy group information [ID 46607]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

SLNet could throw an `IndexOutOfRangeException` when retrieving available alarm filter, trend filter, or redundancy group information if an SLXML query returned an array with unexpected dimensions.

SLNet will now retry failed redundancy group queries once after a short delay. Array index errors will also be logged in *SLNet.txt* with the variable name, the exact array index, and the complete query response array in compressed form to help diagnose the issue.

#### Scheduler: Swarmed tasks could execute actions configured for another task [ID 46728]

<!-- MR 10.7.0 - FR 10.7.1 -->

Previously, editing a scheduled task that had been swarmed could cause action IDs to be reused. As a result, multiple scheduled tasks could reference the same action, causing one task to execute actions configured for another task.

Newly assigned actions will now be stored in the database using their complete IDs (DataMiner ID + action ID), ensuring that each action is uniquely identified. The legacy action ID columns will continue to be updated for downgrade compatibility.

> [!CAUTION]
>
> - To correct scheduled tasks that were swarmed and edited in a version without this fix, recreate them in a version that includes the fix. Editing them again will not resolve the issue.
> - This fix is **not rolling compatible**. Upgrade all DataMiner Agents to a version that includes this fix. Until all Agents have been upgraded, avoid editing scheduled tasks swarmed across Agents running older versions, as this could cause action IDs to be reused.

#### Visual Overview in web apps: SLHelper could stop responding after a session startup failure [ID 46744]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

Previously, when Windows failed to create a window while SLHelper was starting a Cube session for a mobile visual overview, the automatic startup retry could leave the session in an invalid state. Cleaning up that session could then cause SLHelper to stop responding, blocking all mobile visual overview requests for all dashboards and users until SLHelper was restarted.

Each startup retry will now use a new, isolated environment, and a session will only be considered started once it is running. Cleaning up a failed or unresponsive session will no longer block SLHelper. If a session cannot be started after several attempts, only the mobile visual overview requesting that session will fail; other sessions will remain unaffected.

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

#### SLDataMiner could stop responding when recovering from an SLScripting process crash [ID 46849]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When an SLScripting process disappeared while elements were starting, SLDataMiner could stop responding because of a deadlock. Elements could no longer be started or stopped, and the DataMiner Agent had to be restarted.

From now on, elements that used the disappeared SLScripting process will be restarted without blocking other elements that are starting at the same time. Each process disappearance will only be recovered once.

While DataMiner is stopping, no SLScripting or SLProtocol processes will be recovered or started.

#### Failover: Memory and CPU spikes on offline Agents when updating services or elements [ID 46875]

<!-- MR 10.7.0 - FR 10.7.1 -->

When services or elements were updated in a DataMiner cluster, offline Agents in a Failover setup would experience a memory and CPU spike in the StorageModule process for each update. The size of the spike depended on the number of services and elements in the cluster.

Both online and offline Agents will now keep their XML-based services in memory at all times. The service cache in the StorageModule backend will only be reinitialized during a Failover switch or in exceptional circumstances.

#### DataMiner upgrade: SLNet garbage collection settings could be overwritten [ID 46905]

<!-- MR 10.7.0 - FR 10.7.1 -->

During a DataMiner upgrade, the `<runtime>` section of *SLNet.exe.config* was replaced with the version from the upgrade package. This could overwrite the machine-specific `gcServer` and `GCHeapCount` settings.

#### SLNet: Initial parameter event could be missing after updating a subscription set [ID 46913]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a parameter was removed from a subscription set and then added again, SLNet could fail to send the initial event for that parameter after the subscription update.

#### DataMiner upgrade: DxMs installed under a previous product name could be skipped [ID 46938]

<!-- MR 10.7.0 / 10.6.0 [CU10] - FR 10.7.1 -->

During a DataMiner upgrade, installed DxMs could fail to be recognized if their product name had changed. For example, an existing SiteManager installation could be skipped instead of being upgraded to EdgeManager.

The upgrade process now uses MSI upgrade codes to detect related products and recognize installations made under a previous product name.

#### Service & Resource Management: Canceled reservations could prevent resource updates [ID 46952]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Resources could not be updated when they were used by a canceled reservation. This could prevent changes to the resource mode, such as putting a resource into maintenance, as well as changes to its availability window or capacity.

Canceled reservations are now ignored when checking whether resource updates would cause reservations to enter quarantine.

#### Failover: Deleted service templates could reappear after switching back [ID 46990]

<!-- MR 10.7.0 - FR 10.7.1 -->
<!-- Not added to MR 10.7.0 - Introduced by RN 45370 -->

Previously, a deleted service template could reappear in SLNet after switching back to the original active Agent in a Failover setup. This could happen when the template existed on that Agent and was deleted after switching to the other Agent.

Deleted service templates will now remain absent after switching back.

#### User-Defined APIs: Endpoint startup could be blocked when NATS was unavailable [ID 46997]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

The UserDefinableApiEndpoint DxM could remain blocked during startup when the NATS service was unavailable. As a result, API callers would not receive a response explaining the connection failure.

The endpoint will now start while its NATS connections are being established. API triggers received before the message broker is initialized will return HTTP 503 with error code 1006 and the message "Service not ready yet, try again later."

Connection attempts will continue in the background. Once NATS is available and initialization succeeds, API triggers will be forwarded normally and cloud status reporting will resume.

#### SLNet: CCA initialization alarm could remain active after a successful retry [ID 47046]

<!-- MR 10.8.0 - FR 10.7.1 -->

When initialization of `CCAEndpointManager` failed, the initialization alarm could remain active even after a subsequent retry succeeded.

An initialization alarm will now only be generated if all initialization retries fail.

#### Automation: Script Runner could load an incorrect assembly version [ID 47069]

<!-- MR 10.7.0 - FR 10.7.1 -->

Previously, Script Runner searched the protocol scripts folders by default. An assembly in one of these folders could be loaded instead of the version explicitly referenced by a script.

From now on, Script Runner will no longer add `C:\Skyline DataMiner\ProtocolScripts` or `C:\Skyline DataMiner\ProtocolScripts\DllImport` as default assembly hint paths. Script-specific references will take priority, with `C:\Skyline DataMiner\Files` remaining the fallback.

> [!IMPORTANT]
> If a script executed by Script Runner needs a DLL from either protocol scripts folder, you must add an explicit reference to that DLL in the script. These folders will no longer be searched automatically.

#### DataMiner upgrade: CloudFeed DxM installed on Agents where it was not present [ID 47095]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Previously, a DataMiner upgrade would install the CloudFeed DxM even on DataMiner Agents where it was not installed or had previously been uninstalled.

From now on, the CloudFeed DxM will only be upgraded if it is already installed. It will be updated to the version included in the DataMiner upgrade package. This prevents unnecessary resource consumption on DataMiner Agents that do not need the CloudFeed DxM.

#### SLSNMPAgent: SNMP requests could fail after Failover or network changes [ID 47106]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

After a Failover switch, IP address recreation, or a network interface card (NIC) state change, SLSNMPAgent could fail to recreate its SNMP listener. As a result, the DataMiner Agent could stop responding to SNMP requests on the configured port.

The previous listener will now be released before its replacement binds to the configured SNMP port, preventing an internal UDP port conflict.
