---
uid: General_Main_Release_10.5.0_CU6
---

# General Main Release 10.5.0 CU6

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU6](xref:Cube_Main_Release_10.5.0_CU6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU6](xref:Web_apps_Main_Release_10.5.0_CU6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

<!-- Changes in build 16223 -->

### Enhancements

#### SLDataGateway will now check all Cassandra, OpenSearch and Elasticsearch certificates on a daily basis [ID 41793]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

SLDataGateway will now check all Cassandra, OpenSearch and Elasticsearch certificates on a daily basis.

- If a certificate is set to expire within 30 days, a notice alarm will be created.
- If a certificate is set to expire within 7 days, an error alarm will be created.

#### GQI: Enhanced performance when setting up GQI connections [ID 43251]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When executing GQI queries via SLHelper, overall performance has increased when setting up GQI connections.

#### SLAnalytics: Reduced memory usage because of enhanced management of parameters with constant values [ID 43266]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

Because of a number of enhancements, overall memory usage of SLAnalytics has been reduced, especially when managing parameters of which the values remain constant for a long time.

#### NT Notify types NT_SNMP_GET and NT_SNMP_RAW_GET now have infinite loop protection [ID 43273]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The NT Notify types NT_SNMP_GET (295) and NT_SNMP_RAW_GET (424) now have infinite loop protection.

When an infinite loop is detected, the following will be returned:

- When the `splitErrors` option is set to false, the error message `INFINITE LOOP` will be returned.
- When the `splitErrors` option is set to true, the values will be returned.

#### DxMs upgraded [ID 43298]

<!-- RN 43298: MR 10.5.0 [CU6] - FR 10.5.9 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.5
- DataMiner FieldControl 2.11.4
- DataMiner Orchestrator 1.7.8
- DataMiner SupportAssistant 1.7.5

For detailed information about the changes included in the above-mentioned versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### Automation: An error message will now appear when a script import operation fails [ID 43316]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in the *Automation* module, you imported an Automation script, up to now, you would not receive any feedback about whether or not the import operation had been successful. Only after checking the Cube logs would you be able to find out that an import operation had failed.

From now on, the following error message will appear whenever an exception is thrown while an Automation script is being imported:

`Something went wrong. Please check the Cube and Automation logging for more information.`

#### DataMiner upgrade: BPA tests 'Check Agent Presence Test In NATS' and 'Verify NATS is Running' replaced by 'Verify NATS Cluster' [ID 43359]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

The BPA tests *Check Agent Presence Test In NATS* (which was renamed to *Nats connections between the DataMiner Agents* in DataMiner versions 10.5.0/10.4.12) and *Verify NATS is Running* have now both been replaced by the *Verify NATS Cluster* test.

This means that, from now on, during a DataMiner upgrade, the *Verify NATS Cluster* test will be installed and any existing instances of the deprecated *Check Agent Presence Test In NATS* and *Verify NATS is Running* tests will be removed.

#### SLDataGateway: Enhanced caching of TTL overrides for the trend data of specific protocols or protocol versions [ID 43362]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

A number of enhancements have been made to the mechanism that is used to cache TTL overrides for the trend data of specific protocols or protocol versions in SLDataGateway, especially for Cassandra and Cassandra Cluster databases.

#### Video thumbnails: New fitMode parameter [ID 43388]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In URLs of video thumbnails, it is now possible to pass a *fitMode* parameter, which will indicate how the image should be displayed.

These are the possible values:

| fitMode | Description |
|---------|-------------|
| fill    | The image will completely cover the container. It may crop parts of the image, but it ensures no empty space. |
| fit     | The image will be fully visible inside the container while maintaining aspect ratio. There may be empty space if aspect ratios differ. |
| stretch | The image will stretch to exactly fill the container, ignoring aspect ratio. This may cause distortion. |
| center  | The image will retain its original size and will be aligned at the center. It may overflow or be cropped. |
| shrink  | The image will behave like *fill* or *center*, whichever results in a smaller image. It will only scale down if needed. |

Default value: fill

Example:

```txt
https://myDMA/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true&fitMode=center
```

#### Improved logging in case STaaS system is not registered [ID 43455]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

To allow easier troubleshooting, logging has now been improved in case a DataMiner System using STaaS is not correctly registered on dataminer.services.

### Fixes

#### SLManagedScripting: The same dependency would be loaded multiple times by different connectors [ID 42779]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, the same dependency would be loaded multiple times by different connectors. From now on, if multiple connectors attempt to load the same dependency at the same time, it will only be loaded once.

#### Problem when a connector had been modified on a system running multiple SLScripting processes [ID 42877]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, on a system running multiple SLScripting processes, a connector was modified, but its version was left untouched, in some cases, a number of SLScripting processes could incorrectly keep on using outdated QActions or helper libraries, resulting in exceptions like the following being thrown:

`System.ArgumentException: Object of type 'Skyline.DataMiner.Scripting.ConcreteSLProtocolExt' cannot be converted to type 'Skyline.DataMiner.Scripting.SLProtocolExt'`

#### Elements deleted during an element migration could incorrectly not be recovered when an action failed [ID 42976]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When some action would fail during one of the phases of an element migration, up to now, there would be no way to recover any elements that had already been deleted.

From now on, elements will only be deleted once all steps in the migration process have been completed successfully. Moreover, if a step in the process fails after an element has been deleted, it will now be possible to manually recover the deleted element.

#### Problem when restarting an element multiple times in rapid succession [ID 42996]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When an element was restarted multiple times in rapid succession, in some cases, an run-time error could occur in the parameter thread of SLElement.

#### Problem when stopping an element or performing a Failover switch when another action was being executed [ID 43089]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you stopped an element or performed a Failover switch when another action was being executed (e.g. a parameter set being performed by a QAction), in some cases, a deadlock could occur.

#### Service & Resource Management: Reservation ID of a service created from a service template would disappears when the template was re-applied [ID 43090]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a service created from a service template had a reservation ID defined, up to now, that reservation ID would incorrectly disappear when the service template was re-applied.

#### Incorrect license check could cause DaaS systems to shut down [ID 43100]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, when a DaaS system was not able to validate its license, after a certain amount of time it would shut down because of an incorrect license check.

#### Service replication would not work when a gRPC connection was being used [ID 43133]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, service replication would not work when a gRPC connection was being used.

#### Service & Resource Management: Booking could incorrectly be set to 'Confirmed' indefinitely [ID 43140]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a booking with status "Ongoing" or "Ended" had its timing or one of its properties updated, in some cases, its status could incorrectly remain set to "Confirmed" indefinitely. This behavior has now been fixed.

Also, from now on, the booking status will only be set to "Confirmed" in the following cases:

- When the start time of the new booking is in the future.
- When the prior reservation has ended, and the new end time is extended to a point in the future beyond the original end time.

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

#### SNMP elements could get stuck in slow poll mode [ID 43216]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, SNMP elements could get stuck in slow poll mode because they would fail to recover after connectivity was restored.

#### Failover: Primary IP address could incorrectly be set to the IP address of the online agent [ID 43257]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, in a Failover setup using a shared hostname, in some cases, the primary IP address would incorrectly be set to the IP address of the online agent instead of the hostname. Moreover, if that primary IP address was set to an incorrect IP address, it would be impossible to remove the Failover pair from the DataMiner System.

Also, from now on, the primary IP address of the offline agent will be set to either the virtual IP address or the hostname of the Failover pair. Up to now, it would be set to the local IP address.

#### Start-up process of a DMA without Swarming enabled would fail abruptly if no db.xml file was present [ID 43274]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a DataMiner Agent that did not have Swarming enabled was started without a *db.xml* file present, up to now, the start-up process would fail abruptly because of an unhandled exception in SLNet. From now on, it will fail gracefully.

#### SNMP managers could get stuck in 'not responding' ping mode [ID 43278]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a northbound SNMP manager configured to send inform messages exhausts all its retries, it enters ping mode. At this point, it generates a "not responding" timeout alarm, and sends a ping inform message to the endpoint to check whether it is up and running again.

Up to now, when an SNMP manager was in ping mode, it could, in some cases, stop sending further ping inform messages to the endpoint.

From now on, when the first ping inform message is unsuccessful, a new ping inform message will be scheduled. Additionally, the following entry will be logged at information log level 1 (in which %s will be replaced by the name of the SNMP manager):

```txt
Adding a ping message for SNMP Manager %s. Too long since last ping was sent. Retrying...
Logging has been adjusted to not spam if multiple SNMP Managers send to the same IP/Port:
Failed resolving authoritative context ID for SNMP Manager
```

#### BrokerGateway: GetConnectionDetails call would incorrectly not return any destinations [ID 43292]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When using the BrokerGateway-managed NATS solution, in some cases, the `GetConnectionDetails` call would incorrectly not return any destinations when an attempt was made to connect to NATS.

Also, up to now, when a `GetNatsConnection` call was made while no endpoints were specified in the *appsettings.runtime.json* file, the response would incorrectly contain `nats://<ip>:4222` instead of `<ip>:4222`.

#### Problem when deleting a DVE child element [ID 43302]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, a run-time error could be thrown when a DVE child element was deleted.

#### Problem when an error was thrown while setting up the Repository API connections between SLDataGateway and SLNet [ID 43314]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When an error was thrown while setting up the Repository API connections between SLDataGateway and SLNet, in some cases, threads in SLNet could get stuck indefinitely, causing certain DataMiner features (e.g. DOM, SRM, etc.) to not being able to progress beyond their initialization phase.

#### StorageModule DcM would fail to read an element XML file [ID 43350]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some rare cases, the StorageModule DcM would fail to read an element XML file because that file was being used by another process.

From now on, it will try up to three times to read an element XML file that is being used by another process.

#### Fields of type datetime would incorrectly not be empty when the DOM definition field did not have a default value defined [ID 43351]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When a DOM definition field does not have a default value defined, by default, no value should be displayed. However, up to now, when the default time zone had been changed in the *ClientSettings.json* file, fields of type datetime would incorrectly contain the value "01/01/1970 - DefaultTimezone".

From now on, if a DOM definition field does not have a default value defined, all fields of that type will be empty when displayed on a form.

#### Swarming: Synchronization issues caused by SLDMS accepting outdated notifications [ID 43373]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

In systems where swarming was enabled, it could occur that SLDMS accepted outdated notifications about element changes, which could lead to synchronization issues between different SLDMS instances, such as race conditions and missing information.

#### Failover: DMS call DMS_VERIFY_CLIENT_COOKIE would incorrectly be sent to the offline agent [ID 43397]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In a Failover setup using a shared hostname, the DMS call `DMS_VERIFY_CLIENT_COOKIE` would incorrectly be sent to the offline agent instead of the online agent.

From now on, whenever the offline agent receives a `DMS_VERIFY_CLIENT_COOKIE` call, it will forward it to the online agent.

#### SLDataMiner.txt log file entries could incorrectly contain a placeholder instead of the actual name of the function [ID 43398]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In the *SLDataMiner.txt* log file, log entries could incorrectly contain the `__FUNCTION__` placeholder instead of the actual name of the function in question.

#### Certain log files would have their maximum size incorrectly set to 0 [ID 43403]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some rare cases, certain log files could have their maximum size incorrectly set to 0, causing them to start a new file each time an entry was added.

From now on, by default, all log files will have their maximum size set to 10 MB.

#### SLNet memory leak caused by ClusterEndpoint.json sync [ID 43407]

<!-- MR 10.5.0 [CU4] (but also 10.5.0 [CU5] and 10.5.0 [CU6]) - FR 10.5.7 [CU1] (but also 10.5.8 [CU1] and 10.5.9) -->

In large DataMiner Systems, especially in clusters with Failover Agents, an issue could occur when the *ClusterEndpoints.json* files were being synchronized, causing the DataMiner Agents to keep on synchronizing those files indefinitely. This could lead to a serious memory leak in SLNet, causing DataMiner Agents to disconnect frequently.

#### SLAnalytics - Pattern matching: Problem when retrieving the streaming matches [ID 43419]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a linked pattern was created on elements hosted on different DataMiner Agents, in some cases, the `getPatternMatchMessage` would not return the correct number of streaming matches.

#### SLAnalytics - Automatic incident tracking: Problem due to an incorrect internal state [ID 43451]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, an incorrect internal state in the automatic incident tracking feature could cause the SLAnalytics process to stop working.

#### Memory issues caused by file offloads on a STaaS system [ID 43471]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 [CU0] -->

When a system using STaaS switched back from file storage to database storage after it had not been able to reach the database for some time, this could cause too much data to be pushed at the same time, causing memory issues on the DMA.
