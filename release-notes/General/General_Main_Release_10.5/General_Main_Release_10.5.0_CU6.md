---
uid: General_Main_Release_10.5.0_CU6
---

# General Main Release 10.5.0 CU6 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU6](xref:Cube_Main_Release_10.5.0_CU6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU6](xref:Web_apps_Main_Release_10.5.0_CU6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

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

#### Failover: Primary IP address could incorrectly be set to the IP address of the online agent [ID 43257]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, in a Failover setup using a shared hostname, in some cases, the primary IP address would incorrectly be set to the IP address of the online agent instead of the hostname. Moreover, if that primary IP address was set to an incorrect IP address, it would be impossible to remove the Failover pair from the DataMiner System.

Also, from now on, the primary IP address of the offline agent will be set to either the virtual IP address or the hostname of the Failover pair. Up to now, it would be set to the local IP address.

#### Start-up process of a DMA without Swarming enabled would fail abruptly if no db.xml file was present [ID 43274]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a DataMiner Agent that did not have Swarming enabled was started without a *db.xml* file present, up to now, the start-up process would fail abruptly because of an unhandled exception in SLNet. From now on, it will fail gracefully.
