---
uid: General_Feature_Release_10.4.1
---

# General Feature Release 10.4.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.1](xref:Cube_Feature_Release_10.4.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.1](xref:Web_apps_Feature_Release_10.4.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### BrokerGateway DxM will now be installed automatically during a DataMiner upgrade [ID_37714]

<!-- MR 10.5.0 - FR 10.4.1 -->

When a DataMiner Agent is upgraded to version 10.5.0/10.4.1 or above, the *BrokerGateway* DxM will automatically be installed in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway` folder.

This new DxM, which is currently still under development, is intended to manage all NATS configurations.

## Changes

### Enhancements

#### Deprecated NotifyDataMiner type 'NT_CONNECTIONS_TO_REMOVE' can no longer be used [ID_37595]

<!-- MR 10.5.0 - FR 10.4.1 -->

From now on, the deprecated NotifyDataMiner type *NT_CONNECTIONS_TO_REMOVE* can no longer be used.

#### SLAnalytics - Proactive cap detection: Enhanced detection of possible future alarm threshold breaches [ID_37681]

<!-- MR 10.5.0 - FR 10.4.1 -->

When an increasing or decreasing trend is detected on a highly aggregated level (i.e. a trend that persists for more than 24 hours), from now on, a proactive cap detection suggestion event will be generated when there is a probability that the trend change in question could lead to a breach of a critical alarm limit at some point in the future, even when the breach has not yet been confirmed by the full prediction model built on the historic trend data.

#### SLAnalytics - Behavioral anomaly detection: Flatline suggestion events will now automatically be cleared after a set amount of time [ID_37716]

<!-- MR 10.4.0 - FR 10.4.1 -->

Similar to other types of anomaly suggestion events, flatline suggestion events will now also be cleared automatically after a set amount of time.

> [!NOTE]
> Flatline alarms stay open until the flatline in question disappears or SLAnalytics is restarted.

#### SLAnalytics - Behavioral anomaly detection: Changes made to the anomaly configuration in an alarm template of a main DVE element will immediately be applied to all open anomaly alarm events [ID_37788]

<!-- MR 10.5.0 - FR 10.4.1 -->

When you change the anomaly configuration in an alarm template assigned to a main DVE element, from now on, the changes will immediately be applied to all open anomaly alarm events. The severity of the open alarm events will be changed to the new severity defined in the updated anomaly configuration.

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID_37589]

<!-- MR 10.5.0 - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### DELT: Trend data missing in DELT package after exporting tables with primary keys of type string [ID_37664]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When you exported tables of which the primary keys were of type string, the DELT export package would incorrectly not contain any trend data.

#### Problem with remote clients after restarting a DMA in a gRPC-only cluster [ID_37726]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When a DataMiner System was configured to use gRPC connections only (i.e. when *EnableDotNetRemoting* was set to false on all agents), in some cases, remote clients would not get properly registered with SLDataMiner after restarting a DataMiner Agent. This would cause remote requests to fail if they had to be handled by SLDataMiner on the DataMiner Agent that was restarted.

#### DELT package created on DataMiner v10.3.8 or newer could no longer be imported on DataMiner v10.3.7 or older [ID_37731]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you exported elements via a DELT package on a DMA running DataMiner version 10.3.8 or newer, it would no longer be possible to import that DELT package on a DMA running DataMiner version 10.3.7 or older.

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID_37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.
