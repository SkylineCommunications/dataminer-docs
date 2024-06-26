---
uid: General_Feature_Release_10.4.9
---

# General Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.9](xref:Cube_Feature_Release_10.4.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.9](xref:Web_apps_Feature_Release_10.4.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### SLAnalytics: Alarms and suggestion events for virtual functions will now be generated on the parent element [ID_39707]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

When, in the scope of behavioral anomaly detection, proactive cap detection or pattern matching, SLAnalytics has to generate alarms or suggestion events for virtual functions, from now on, it will generate them on the parent element. However, it will continue to generate alarms and suggestion events for all other kinds of DVEs on the child element.

#### MessageBroker: Clients will now first attempt to connect via the local NATS node [ID_39727]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, when a client connects to the DataMiner System, an attempt will first be made to connect to the NATs bus via the local NATS node. Only when this attempt fails, will the client connect to the NATS bus via another node.

#### When stopping, native processes will only wait for 30 seconds to close the MessageBroker connection when necessary [ID_39863]

<!-- MR 10.5.0 - FR 10.4.9 -->

When a native process (e.g. SLDataMiner) is stopping, it will by default wait for 30 seconds before it closes the MessageBroker connection.

However, in some rare cases, there is no need to wait for 30 seconds. In those cases, the MessageBroker connection will be closed immediately.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of change points of type 'flatline' [ID_39898]

<!-- MR 10.5.0 - FR 10.4.9 -->

A number of enhancements have been made to the algorithm that detects change points of type "flatline".

When the trend data of a parameter appears to have frequent flatline periods, the chance of a flatline change point being detected and a suggestion event being created for it has now decreased.

Also, a parameter will need to have had at least one day of fluctuating trend data behavior before the flatline detection functionality will detect the start of a flatline period.

### Fixes

#### Problem with SLAnalytics while starting up [ID_39955]

<!-- MR 10.5.0 - FR 10.4.9 -->

In some rare cases, while starting up, SLAnalytics appeared to leak memory and could stop working.

#### SLNet - CloudEndpointManager: Problem at startup when NATS and NAS services were not installed [ID_39980]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

At startup, in some cases, the CloudEndpointManager in SLNet could throw an exception when the NATS and NAS services were not installed.

#### Service & Resource Management: Problem when a DMA did not respond during the midnight sync of the Resource Manager [ID_40021]

<!-- MR 10.5.0 - FR 10.4.9 -->

When a DMA did not respond during the midnight synchronization (e.g. because the Resource Manager had not been initialized on that DMA), up to now, a nullreference exception would be thrown directly after the error had been logged.
