---
uid: General_Feature_Release_10.5.9
---

# General Feature Release 10.5.9 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.9](xref:Cube_Feature_Release_10.5.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.9](xref:Web_apps_Feature_Release_10.5.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Automation scripts: New Interactivity tag [ID 42954]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, Automation scripts using the IAS Interactive Toolkit required a special comment or code snippet in order to be recognized as interactive. From now on, you will be able to define the interactive behavior of an Automation script by adding an `<Interactivity>` tag in the header of the script. See the following example.

```xml
<DMSScript xmlns="http://www.skyline.be/automation">
  ...  
  <Interactivity>Always</Interactivity>
  ...
  <Script>
    ...
  </Script>
</DMSScript>
```

Possible values:

| Value | Description |
|-------|-------------|
| Auto     | Like before, an attempt will be made to automatically detect the interactive behavior of the script. |
| Never    | The script will never show any UI element. |
| Optional | The script will be interactive when it needs to be. |
| Always   | The script will always be interactive. |

## Changes

### Enhancements

#### Failover: NATS cluster state will now be visible in DataMiner Cube's Failover Status window [ID 42250] [ID 43169]

<!-- MR 10.6.0 - FR 10.5.9 -->

In DataMiner Cube, the NATS cluster state will now be visible in the *Failover Status* window. This state will indicate whether NATS communication between main agent and backup agent is up and running and whether the *clusterEndpoints.json* file is synchronized between the two agents.

#### OpenSearch: auto_expand_replicas with minimum 0 and maximum 2 [ID 43179]

<!-- MR 10.6.0 - FR 10.5.9 -->

In OpenSearch, indexing will now use the `auto_expand_replicas` setting.

If the database consists of a single node at the time of index creation, an index will be made that has no replicas (minimum number of replicas is set to 0). If, at a later stage, nodes are then added to or removed from the cluster, replicas will automatically be assigned up to a maximum of 2 (maximum number of replicas is set to 2).

#### Swarming: An information event will be generated when an element was successfully swarmed [ID 43196]

<!-- MR 10.6.0 - FR 10.5.9 -->

From now on, an information event will be generated when an element was successfully swarmed.

Example:

`Swarmed from <DmaName> (<DmaId>) to <DmaName> (<DmaId>) by <UserName>`

> [!NOTE]
> When the source DMA is no longer available or unknown, the information event will be shortened to `Swarmed to <DmaName> (<DmaId>) by <UserName>`.

#### DxMs upgraded [ID 43205] [ID 43298]

<!-- RN 43205: MR 10.6.0 - FR 10.5.9 -->
<!-- RN 43298: MR 10.5.0 [CU6] - FR 10.5.9 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.5
- DataMiner CloudGateway 2.17.9
- DataMiner FieldControl 2.11.4
- DataMiner Orchestrator 1.7.8
- DataMiner SupportAssistant 1.7.5

<!-- RN 43205 -->As from now, the CloudGateway DxM will also be included in DataMiner upgrade packages. However, the DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, it will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### GQI DxM: Support for asynchronous SLNet messages within ad hoc data sources and custom operators [ID 43231]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When using the GQI DxM, ad hoc data sources and custom operators will now be able to send SLNet messages asynchronously using `connection.Async.Launch()`.

### Fixes

#### Problem when a connector had been modified on a system running multiple SLScripting processes [ID 42877]

<!-- MR 10.4.0 [CU18] - FR 10.5.9 -->

When, on a system running multiple SLScripting processes, a connector was modified, but its version was left untouched, in some cases, a number of SLScripting processes could incorrectly keep on using outdated QActions or helper libraries, resulting in exceptions like the following being thrown:

`System.ArgumentException: Object of type 'Skyline.DataMiner.Scripting.ConcreteSLProtocolExt' cannot be converted to type 'Skyline.DataMiner.Scripting.SLProtocolExt'`

#### Elements deleted during an element migration could incorrectly not be recovered when an action failed [ID 42976]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When some action would fail during one of the phases of an element migration, up to now, there would be no way to recover any elements that had already been deleted.

From now on, elements will only be deleted once all steps in the migration process have been completed successfully. Moreover, if a step in the process fails after an element has been deleted, it will now be possible to manually recover the deleted element.

#### Problem when stopping an element or performing a Failover switch when another action was being executed [ID 43089]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you stopped an element or performed a Failover switch when another action was being executed (e.g. a parameter set being performed by a QAction), in some cases, a deadlock could occur.

#### Service & Resource Management: Reservation ID of a service created from a service template would disappears when the template was re-applied [ID 43090]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a service created from a service template had a reservation ID defined, up to now, that reservation ID would incorrectly disappear when the service template was re-applied.

#### Service replication would not work when a gRPC connection was being used [ID 43133]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, service replication would not work when a gRPC connection was being used.

#### SLDMS and SLDataMiner could get into a deadlock when redundancy group properties were being updated [ID 43148]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, SLDMS and SLDataMiner could get into a deadlock when redundancy group properties were being updated.

#### DataMiner upgrade: Redirect tags in DMS.xml would incorrectly not be taken into account [ID 43172]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When `<Redirect via="..." />` tags were configured in the *DMS.xml* file, these would incorrectly not be taken into account when an SLNet instance retrieved upgrade progress messages from another SLNet instance.

Although the upgrade would succeed in the background, no information regarding the remote agents would be available in DataMiner Cube or the DataMiner TaskBar Utility during the upgrade, and notices saying that `http://<ip>:8004/UpgradeService` was unavailable would be added to the logs.

#### OpenSearch: Queries with a limit could cause scroll contexts to linger [ID 43191]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In OpenSearch, in some cases, queries with a limit could cause scroll contexts to linger. From now on, queries with a limit will be properly tracked and cleaned up.

#### BrokerGateway would not be able to retrieve local IP addresses at start-up [ID 43209]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

As BrokerGateway is started alongside the Microsoft Windows operating system, in some cases, it would not be able to retrieve the local IP addresses of the server.

To prevent being unaware of certain IP addresses, from now on, BrokerGateway will not only refresh its IP address cache every 5 minutes, it will also refresh that cache each time it detects a network adapter update.

#### AnnounceHostingAgentEvent instances could linger around in the cache after a remote agent had reconnected [ID 43230]

<!-- MR 10.6.0 - FR 10.5.9 -->
<!-- Not added to MR 10.6.0 -->

When a remote agent disconnected and later reconnected, in some cases, `AnnounceHostingAgentEvent` instances could linger around in the cache even though the event, element, service or redundancy group no longer existed on that remote agent.

#### Failover: Primary IP address could incorrectly be set to the IP address of the online agent [ID 43257]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, in a Failover setup using a shared hostname, in some cases, the primary IP address would incorrectly be set to the IP address of the online agent instead of the hostname. Moreover, if that primary IP address was set to an incorrect IP address, it would be impossible to remove the Failover pair from the DataMiner System.

Also, from now on, the primary IP address of the offline agent will be set to either the virtual IP address or the hostname of the Failover pair. Up to now, it would be set to the local IP address.

#### Start-up process of a DMA without Swarming enabled would fail abruptly if no db.xml file was present [ID 43274]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a DataMiner Agent that did not have Swarming enabled was started without a *db.xml* file present, up to now, the start-up process would fail abruptly because of an unhandled exception in SLNet. From now on, it will fail gracefully.

#### GQI DxM: Admin connection would incorrectly be allowed to expire [ID 43290]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

If the GQI DxM is used with an admin connection, its underlying persistent system connection is used to handle any requests or subscriptions towards SLNet.

Up to now, when the admin connection had been idle for at least 1 minute after being used, the underlying system connection would automatically close the admin connection, causing the GQI DxM to unsubscribe from NATS and close all sessions and extension workers.

From now on, the admin connection will no longer expire, and will no longer be automatically closed by the underlying system connection.
