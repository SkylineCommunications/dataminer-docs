---
uid: General_Main_Release_10.8.0_changes
description: "Changes in DataMiner General Main Release 10.8.0, including breaking changes, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.8.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Important changes

*No important changes have been selected yet.*

## Changes

### Enhancements

#### SLProtocol: Support for postPonePortInitialisation option removed [ID 46588]

<!-- MR 10.8.0 - FR 10.7.1 -->

Support for the [`postPonePortInitialisation`](xref:Protocol.Type-communicationOptions#postponeportinitialisation) communication option has been removed from SLProtocol.

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.8.0 - FR 10.7.1 -->

From now on, an upgrade action will automatically add a `Set-Cookie` header to `WebPages/web.config` on systems with SAML authentication enabled. This cookie configures web authentication to use redirects instead of an embedded iframe, ensuring compatibility with SAML providers that do not allow their sign-in pages to be displayed in an iframe.

The upgrade action will leave the configuration unchanged if SAML is disabled or the required cookie header is already configured. Existing custom headers, including `Set-Cookie` headers for other cookies, will be preserved.

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

#### DataMiner upgrade: Web-only upgrades to 10.7.x or later require at least 10.6.0 [ID 46910]

<!-- MR 10.8.0 - FR 10.7.1 -->

Web-only upgrade packages for version 10.7.x or later will now be blocked on DataMiner Agents running a server version older than 10.6.0. The error message will indicate this minimum version requirement.

For example, before installing a 10.7.x web-only upgrade on a DataMiner Agent running 10.5.0, you will first have to perform a full upgrade to 10.6.0 or later.

This validation does not affect full DataMiner upgrades.

#### Scheduler: Removed unnecessary DMAObjects dependency from SLNetTypes [ID 46914]

<!-- MR 10.8.0 - FR 10.7.1 -->

The `ScheduledTaskDetails` class, which is used only to migrate scheduled tasks from local storage to database storage, has been moved from SLNetTypes to SLNet.

As a result, SLNetTypes no longer depends on *Skyline.DataMiner.Core.DMAObjects.Config.dll*.

### Fixes

*No fixes have been added yet.*
