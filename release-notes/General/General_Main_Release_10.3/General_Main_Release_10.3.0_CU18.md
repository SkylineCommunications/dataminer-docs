---
uid: General_Main_Release_10.3.0_CU18
---

# General Main Release 10.3.0 CU18 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLAnalytics: Alarms and suggestion events for virtual functions will now be generated on the parent element [ID_39707]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the scope of behavioral anomaly detection, proactive cap detection or pattern matching, SLAnalytics has to generate alarms or suggestion events for virtual functions, from now on, it will generate them on the parent element. However, it will continue to generate alarms and suggestion events for all other kinds of DVEs on the child element.

#### NATS configuration can now be reset by calling an endpoint of SLEndpointTool.dll [ID_39871]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.8 -->

From now on, the NATS configuration can be reset by calling the following endpoint in e.g. an Automation script:

`SLEndpointTool.Config.NATSConfigManager.ResetNATSConfiguration()`

#### SLAnalytics - Alarm focus & Automatic incident tracking: Alarms generated for child DVE elements using a parameter ID from the main DVE element will now also be taken into account [ID_39988]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

From now on, alarms generated for child DVE elements using a parameter ID from the main DVE element can also get a focus value and, as a result, be grouped by Automatic incident tracking.

#### DataMiner upgrade: ResetConfig.txt will no longer be added to FilesToDelete.txt [ID_39994]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Every DataMiner upgrade package includes a *FilesToDelete.txt* file, which lists all files in the *C:\\Skyline DataMiner\\* folder that should be deleted during the upgrade procedure. From now on, the *ResetConfig.txt* file will no longer be added to that list of files to be deleted.

The *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* file is a file used by the factory reset tool *SLReset.exe* as a whitelist to determine which files to keep. The first time *SLReset.exe* is executed, the default whitelist is added to *ResetConfig.txt*. Afterwards, you can add files you want to keep to this whitelist, so that these are not removed when the tool is executed again. If you delete *ResetConfig.txt*, the default whitelist will be used again.

#### Service & Resource Management: Enhanced logging when booking objects are added to, updated in or deleted from the cache [ID_40043]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When booking objects are added to, updated in or deleted from the cache, from now on, the following properties of the booking in question will be logged:

- Booking status
- Booking resources
- Time when the booking was last modified

#### Factory reset tool will now use an absolute path to locate ResetConfig.txt [ID_40074]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the factory reset tool *SLReset.exe* always used the relative path `.\\` to locate the *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* file, assuming that it would always be executed from the *C:\\Skyline DataMiner\\Files* folder. As a result, when it was executed from another folder (e.g. from a terminal window opened on the Windows desktop), it would not be able to find the *ResetConfig.txt* file.

From now on, *SLReset.exe* will always use the absolute path *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* when locating *ResetConfig.txt*.

#### SLLogCollector: Enhanced CPU usage when 'Include memory dump' is selected [ID_40109]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, SLLogCollector will now use less CPU resources when you selected the *Include memory dump* option.

#### Failover: Online agent will be restarted at the end of the decommissioning process [ID_40161]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you decommission a Failover setup, from now on, the DataMiner Agent that was online when you started the decommission process will be restarted as soon as the decommission process has finished.

The DataMiner Agent that was offline when you started the decommission process will, as before, be reset by the factory reset tool *SLReset.exe*.

#### MySQL.data.dll downgraded to version 8.0.32 to prevent known MySQL issue [ID_40200]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In order to prevent the following known MySQL issue from occurring, the *Mysql.Data.dll* driver has been downgraded to version 8.0.32.

- [Bug #110789 - OpenAsync throws unhandled exception from thread pool](https://bugs.mysql.com/bug.php?id=110789)

### Fixes

#### Alarms generated for an element with a virtual function would incorrectly get exported to that virtual function [ID_39536]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When alarms were generated for an element with a virtual function, those alarms would incorrectly get exported to the virtual function.

#### SLDataGateway: Problem when retrieving data page by page [ID_39581]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When SLDataGateway retrieved data from the database page by page, in some cases, paging handlers that had already fetched all their data and had already been deleted would incorrectly be used, causing exceptions to be thrown.

#### Run-time error could occur in SLProtocol when a large SNMP table was being polled [ID_39756]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, when an SNMP table took a long time to be polled, a run-time error could occur in SLProtocol.

To avoid such run-time errors, from now on, when SLSNMPManager is polling an SNMP table, it will send a notification to SLProtocol every minute to indicate that SNMP data is being polled.

#### Failover switch would take significantly longer than usual due to blocking calls in the SLASPConnection process [ID_39769]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

On Failover systems with a Cassandra Cluster setup, a Failover switch would take significantly longer than usual due to blocking calls in the SLASPConnection process.

See also: [Failover switch taking a long time on systems with Cassandra Cluster setup](xref:KI_Failover_switch_Cassandra_Cluster)

#### Problem due to the protobuf-net framework in SLNetTypes being initialized on multiple threads [ID_39807]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

On heavily loaded systems, in some cases, the protobuf-net framework in SLNetTypes would simultaneously be initialized on multiple threads, causing the following exception to be thrown:

`Timeout while inspecting metadata; this may indicate a deadlock. This can often be avoided by preparing necessary serializers during application initialization, rather than allowing multiple threads to perform the initial metadata inspection; please also see the LockContended event`

#### Service & Resource Management: Problem when deleting a discrete value of a profile parameter [ID_39867]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When two capability parameters shared the same discrete value, and the value of one of those parameters was included in a resource, up to now, it would not be possible to delete that value for the parameter that was not used.

#### No longer possible to edit a service that had been migrated from one DMA to another within a DMS [ID_39893]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a service had been migrated from one DataMiner Agent to another within a DataMiner System, it would no longer be possible to edit that service. The messages would incorrectly be sent to the DataMiner Agent that hosted the service previously.

#### Failover: Problem when connecting to an offline agent with a DataMiner Cube that used external authentication [ID_39925]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you connected to an offline agent in a Failover setup with a DataMiner Cube that used external authentication, an `External authentication failed` error would appear. As a result, it would not be possible to force that offline agent to go online.

#### SLAnalytics: Issues fixed with regard to alarm template monitoring mechanism [ID_39948]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

A number of issues have been fixed with regard to the internal SLAnalytics alarm template monitoring mechanism.

#### SLNet - CloudEndpointManager: Problem at startup when NATS and NAS services were not installed [ID_39980]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

At startup, in some cases, the CloudEndpointManager in SLNet could throw an exception when the NATS and NAS services were not installed.

#### Service & Resource Management: Problem when a DMA did not respond during the midnight sync of the Resource Manager [ID_40021]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a DMA did not respond during the midnight synchronization (e.g. because the Resource Manager had not been initialized on that DMA), up to now, a nullreference exception would be thrown directly after the error had been logged.

#### Automation scripts could fail due to zero or negative sleep intervals being passed to Engine.Sleep [ID_40084]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, an Automation script could fail because a zero or negative sleep interval was passed to the `Engine.Sleep` method. From now on, any zero or negative sleep interval will be ignored.

#### SLProtocol would leak memory when performing an SNMP Set [ID_40112]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In the following cases, SLProtocol would leak memory:

- When performing an SNMP Set on a cell in a table.

- When performing an SNMP Set on a standalone parameter with part of the OID coming from a different standalone parameter. See the following example:

  `<OID type="complete" id="9901">1.3.6.1.4.1.14014.1.1.1.6.1.1.6.*</OID>`

#### Service & Resource Management: Booking events could be triggered multiple times when a database issue occurred while DataMiner was starting up [ID_40114]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a database issue occurred while DataMiner was starting up, in some cases, booking events could be triggered multiple times.

#### Problem with SLProtocol when elements with multiple connections were in slow poll mode [ID_40119]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In some cases, SLProtocol could stop working when elements with multiple connections were in slow poll mode.

#### Problem with SLProtocol when loading a connector with forbidden parameter IDs [ID_40127]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, SLProtocol would stop working when it loaded a connector containing parameters with IDs that exceeded the boundaries (see [Reserved parameter IDs](xref:ReservedIDsParameters)).

From now on, SLProtocol will no longer stop working when loading such a connector. However, if any parameters are found with IDs that exceed the boundaries, they will not be loaded.

#### Video thumbnail of type 'Generic Images' would not be reloaded [ID_40328]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When no proxy was used to show a video thumbnail of type *Generic Images*, in some cases, the specified image would incorrectly not be reloaded at the configured refresh rate.

Example:

```html
http://<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&refresh=5000&proxy=false
```

#### Certain processes could get restarted while DataMiner was being stopped [ID_40337]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In some rare cases, certain processes could get restarted while DataMiner was being stopped. This would then cause issue when DataMiner was restarted.
