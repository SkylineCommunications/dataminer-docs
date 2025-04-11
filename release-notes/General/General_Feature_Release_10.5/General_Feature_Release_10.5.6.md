---
uid: General_Feature_Release_10.5.6
---

# General Feature Release 10.5.6 – Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.6](xref:Cube_Feature_Release_10.5.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.6](xref:Web_apps_Feature_Release_10.5.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### New NotifyProtocol call NT_CLEAR_PARAMETER [ID 42368] [ID 42397]

<!-- RN 42397: MR 10.6.0 - FR 10.5.6 -->
<!-- RN 42368: MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

A new NotifyProtocol call *NT_CLEAR_PARAMETER* (474) can now be used to clear tables and single parameters. When used, it will also clear the parameter's display value and save any changes when the parameter is saved.

Internally, this new *NT_CLEAR_PARAMETER* call will now also be used by the existing SLProtocol function `ClearAllKeys()`. As a result, the latter will now be able to clear tables of which the RTDisplay setting was not set to true.

> [!NOTE]
>
> - *NT_CLEAR_PARAMETER* cannot be used to clear table columns.
> - This new NotifyProtocol method can be invoked from within a QAction by using the protocol.ClearParameter(<paramId>) function.
> - When using `ProtocolExt`, you can now use e.g. `protocol.getRequests.Clear()` to clear a table parameter named *getRequests*. Internally, this new `Clear()` function will then execute a `protocol.ClearAllKeys(<getRequests parameter ID>)` call.

## Changes

### Enhancements

#### SLAnalytics: Enhanced caching of DVE element information [ID 42555]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

A number of enhancements have been made with regard to the caching of DVE element information.

#### SLAnalytics - Relational anomaly detection: Upon deletion of a parameter group all open suggestion events associated with that group will be cleared [ID 42602]

<!-- MR 10.6.0 - FR 10.5.6 -->

When you delete a Relational Anomaly Detection (RAD) parameter group, from now on, all open suggestion events associated with that parameter group will automatically be cleared.

#### Cassandra Cluster: Enhanced performance when importing DELT packages [ID 42613]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

Because of a number of enhancements, overall performance has increased when importing DELT packages on systems with a database of type *Cassandra Cluster*, especially when those packages contain a large amount of trend data.

#### DxMs upgraded [ID 42688]

<!-- MR 10.6.0 - FR 10.5.6 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.3
- DataMiner CoreGateway 2.14.12
- DataMiner FieldControl 2.11.2
- DataMiner Orchestrator 1.7.5
- DataMiner SupportAssistant 1.7.3

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Problem with SLProtocol when a protocol version was overwritten while an element using that protocol version was starting up [ID 42344]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When a protocol version was overwritten while an element using that protocol version was starting up, in some cases, the SLProtocol process could stop working. Also, this could result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`

#### Problem when an element was swarmed immediately after being created or after having its state changed to Active, Stopped, Paused, etc. [ID 42381]

<!-- MR 10.6.0 - FR 10.5.6 -->
<!-- Not added to MR 10.6.0 -->

When an element was swarmed immediately after being created or after having its state changed to "Active", "Stopped", "Paused", etc., in some rare cases, SLNet modules could end up being confused about where the element was being hosted.

#### Problem with SLAutomation when a Notify method was called shortly after an Automation script had finished [ID 42465]

<!-- MR 10.6.0 - FR 10.5.6 -->

When a Notify method was called from a thread created within an Automation script shortly after that Automation script had finished, in some cases, the SLAutomation process could stop working.

#### Redundancy groups: Matrix parameter updates in a derived element would incorrectly not get applied in the source element (and vice versa) [ID 42598]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When, within a redundancy group, a matrix parameter in a derived element was updated, in some cases, that same matrix parameter would incorrectly not get updated in the source element (and vice versa).

#### Problem when starting an element with DCF connections towards a previously deleted element [ID 42632]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When an element that had DCF connections towards a previously deleted element was started, in some cases, an "unhandled exception" notice could appear in the Alarm Console. Also, as a result of the exception, the element's connection information would not be available in SLNet and DataMiner Cube, and no connection lines would be displayed for the connections in question.

#### SNMP forwarding: Inconsistent messages in alarm storm information events [ID 42642]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

SNMP managers generate an information event each time an alarm storm starts and ends.

Up to now, the word "SNMP manager" would not be spelled consistently in both messages. The information event announcing the start of an alarm storm would start with `Alarmstorm for SNMP Manager: ...`, while the information event announcing the end of an alarm storm would start with `Alarmstorm for SNMPManager: ...`

From now on, both information events will start with `Alarmstorm for SNMP Manager: ...`
