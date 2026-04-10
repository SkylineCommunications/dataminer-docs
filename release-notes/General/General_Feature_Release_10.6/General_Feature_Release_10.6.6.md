---
uid: General_Feature_Release_10.6.6
---

# General Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.6](xref:Web_apps_Feature_Release_10.6.6).
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

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced performance when retrieving service state information [ID 44392]

<!-- MR 10.5.0 [CU15] - FR 10.6.6 -->

Because of a number of enhancements, performance has increased when retrieving service state information.

From now on, a `GetServiceStateMessage` will no longer be forwarded to the Agent hosting the service. Instead, the service state information will be retrieved from the local SLNet cache.

#### Connector synchronization enhancements [ID 44715]

<!-- MR 10.7.0 - FR 10.6.6 -->

A number of enhancements have been made with regard to the synchronization of connectors within a DataMiner System:

- The first time you upload a version of a new connector, it will automatically be set as production version. Up to now, when a connector version was automatically set as production version, this would trigger a synchronization of that production version. From now on, the new connector will be synchronized within the cluster, and when a DataMiner Agent detects that it is the first version, it will set it as the production version.

- Up to now, when a parent connector exported child connectors (as is the case with DVE connectors), these exported child connectors would be synchronized within the cluster when the parent connector was added or modified. From now on, only the parent connector will be synchronized, and each DataMiner Agent will then generate the child connectors.

- From now on, a protocol.xml file that is generated based on the active function.xml file will no longer be synchronized when the function is activated.

> [!NOTE]
> The midnight sync has not been altered.

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

#### Protocols: Indicating that smart-serial elements in server mode are allowed to be swarmed [ID 45173]

<!-- MR 10.7.0 - FR 10.6.6 -->

By default, elements with a smart-serial connection in server mode are not allowed to be swarmed. However, it is possible that, at startup, an element can send a message to the data source in order to indicate where data should be sent to. In that case, the fact that the smart-serial connection is in server mode will not be considered a valid reason to prevent the element from swarming.

As DataMiner is not able to automatically detect such exceptional cases, you can now indicate in the *protocol.xml* file of the element that it is allowed to be swarmed. See the following example:

```xml
<Swarming>
    <BypassChecks>
        <Check>smartSerialAsServer</Check>
    </BypassChecks>
</Swarming>
```

#### DataMiner upgrade: .NET Framework 4.8 will no longer be installed [ID 45196]

<!-- MR 10.7.0 - FR 10.6.6 -->

From now on, during a DataMiner upgrade, Microsoft .NET Framework 4.8 will no longer be installed.

On most machines running DataMiner, this will already be installed. If, for any reason, you need to install this package, it can be downloaded from [the official download page](https://dotnet.microsoft.com/en-us/download/dotnet-framework).

#### DataMiner upgrade: A number of default Visio stencils will no longer be included [ID 45202]

<!-- MR 10.7.0 - FR 10.6.6 -->

From now on, a DataMiner upgrade package will no longer contain the following Visio stencil files:

- AppearTV DC1000.vss
- AppearTV DC1100.vss
- AppearTV MC3000.vss
- AppearTV MC3100.vss
- AppearTV SC2000.vss
- AppearTV SC2100.vss
- BridgeTech.vss
- Nimbra300.vss
- Nimbra600.vss
- NimbraNodes.vss
- United States Maps (US units).vss
- World Maps (Metric).vss
- World Maps (US units).vss

Note that the following stencil files will still be deployed:

- Buttons.vssm
- Icons.vssx
- KPI.vssm
- SkylineNewDrawing.vsdx

> [!NOTE]
> The above-mentioned stencil files that are no longer included in DataMiner upgrade packages will not automatically be removed from existing systems.

#### SLLogCollector: Only BPA tests deployed by default will be rerun each time a log package is created [ID 45228]

<!-- MR 10.7.0 - FR 10.6.6 -->

Up to now, each time SLLogCollector created a log package, it would rerun all BPA tests deployed on the system. From now on, it will only rerun the BPA tests deployed by default.

> [!NOTE]
> Each time a log package is created, all BPA test results available on the system will still be included in that package. This means, that all results from non-default BPA tests will also be included, even when, from now on, these tests are no longer rerun when a package is created.

### Fixes

#### STaaS: Problem when retrieving data to be visualized in 'State timeline' components or element and parameter heatlines [ID 45043]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When, on systems using STaaS, the `GetReportTimelineDataMessage` was used to retrieve data to be visualized in *State timeline* components or element and parameter heatlines, in some cases, the data that was visualized would not be correct.

#### Dynamic units: A unit would incorrectly be assigned to date/time parameters [ID 45047]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When the dynamic units feature is enabled in, for example, DataMiner Cube, many numerical values are automatically converted into more readable formats with appropriate units. Up to now, the dynamic units feature would incorrectly also try to assign a unit to parameters of type date/time.

#### SLLogCollector: Problem when running BPA tests [ID 45053]

<!-- MR 10.7.0 - FR 10.6.6 -->

When the SLLogCollector tool was configured to execute all BPA tests available in the system when collecting log packages, up to now, in some cases, executing those BPA tests would fail and cause them to report a wide variety of exceptions.

From now on, when the SLLogCollector tool detects that it is not possible to execute the BPA tests, it will skip their execution and collect the results of their last successful run.

#### Alarm squashing: Alarm would incorrectly not show up in the Alarm Console when the element had been restarted and the AlarmsPerParameter limit was exceeded [ID 45063]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When, on a system with alarm squashing enabled, the `AlarmsPerParameter` limit in the `AlarmSettings` section of the *MaintenanceSettings.xml* file was exceeded, an alarm of which all alarms in the alarm tree were squashable would incorrectly not show up in the Alarm Console after the element associated with the alarm had been restarted.

#### SLWatchdog to incorrectly interpret processes being stopped during a DataMiner shutdown as a crash [ID 45115]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When DataMiner is shutting down, processes are expected to be stopped. However, up to now, the tracking in SLWatchdog would not be cleaned correctly, causing certain processes to still be monitored. When these processes eventually stopped, SLWatchdog would incorrectly interpret this as a crash, which would then trigger a number of crash detection features, such as notifying CDMR or attempting to perform a full restart.

#### SLAnalytics: Problem due to a large number of state icon events being added to the SLNet queue simultaneously [ID 45145]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, timeouts could occur due to a large number of state icon events being added to the SLNet queue simultaneously.

From now on, the number of state icon events sent by SLAnalytics instances will be reduced to a maximum of 10,000 events per minute. Also, they will be sent in batches of maximum 1000 events.

Additionally, state icon events, alarm focus events and RAD parameter aggregation events will now all have a smaller weight, meaning that more of them will be allowed in the queue.

#### Problem with connections to NATS servers of other DMAs during NATS migrations and NATS-related BPA test runs [ID 45175]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, during NATS migrations or NATS-related BPA test runs, establishing connections to NATS servers of other DataMiner Agents in the DMS would be slow due to reverse DNS lookups.

#### SLAnalytics: Problem due to incorrect internal state in Automatic Incident Tracking [ID 45220]

<!-- MR 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, SLAnalytics could stop working due to an incorrect internal state in Automatic Incident Tracking.
