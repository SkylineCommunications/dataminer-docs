---
uid: General_Main_Release_10.4.0_CU12
---

# General Main Release 10.4.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU12](xref:Cube_Main_Release_10.4.0_CU12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU12](xref:Web_apps_Main_Release_10.4.0_CU12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLNet: Enhancements to prevent SLNet modules from forwarding requests back and forth between two DMAs [ID 41827]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

A number of enhancements have been made to prevent SLNet modules from forwarding requests back and forth between two DataMiner Agents.

#### SLAnalytics: New check to verify if the incident tracking leader is still a member of the current DMS [ID 41836]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

At DataMiner startup, from now on, SLAnalytics will check whether the DataMiner Agent configured as leader\* is still a member of a current DataMiner System.

Also, from now on, a new leader will be elected when the former leader has left the cluster.

*\* In DataMiner Cube, the leader can be configured in the *Leader DataMiner ID* box, which can be found in *System Center > System settings > Analytics config > Automatic incident tracking*.*

#### Smart baselines will now also get capped when the parameter only has either a low value or a high value [ID 41870]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner calculates a smart baseline value that lies outside the range specified in the protocol for the parameter in question, then the value is capped. However, up to now, this would only happen when the range had both a low value and a high value.

From now on, calculated smart baseline values will also get capped when the parameter in question only has either a low value or a high value.

#### SLLogCollector packages now also contain the ClusterEndpoints.json file [ID 41887]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLLogCollector packages now also include the *ClusterEndpoints.json* file.

#### SLPort: Enhanced performance and reduced memory and CPU usage [ID 41896]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLPort has increased. The process will now also use less memory and CPU.

#### SLNet: Enhanced performance when clearing the alarms cache [ID 41998]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLNet has increased when clearing the alarms cache.

#### SLProtocol: Reduced CPU usage when converting data from String to Double [ID 42049]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements made to SLProtocol, overall CPU usage has been reduced when converting data from String to Double.

#### Failover: Virtual IP address check will no longer execute an arp command to double-check whether an IP address is free [ID 42280]

<!-- MR 10.4.0 [CU12]/10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When the virtual IP address check concluded that the IP address was free after having executed the required number of ping commands, since DataMiner main release 10.3.0 [CU20]/10.4.0 [CU8] and feature release 10.4.11, it would double-check by executing an arp command.

From now on, it will no longer execute an arp command.

### Fixes

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41339]

<!-- MR 10.4.0 [CU12] - FR 10.5.2 -->

In some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When synchronizing users from an LDAP/ActiveDirectory domain, DataMiner would not correctly process the result.

#### Missing DATAMINER_NOTIFICATION_QUEUE thread [ID 41699]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner was restarted, an issue could occur, causing the DATAMINER_NOTIFICATION_QUEUE thread not to be registered in processes like SLDMS, SLElement or SLDataGateway. These missing threads could then lead to a number of symptoms like empty element data cards or not being able to swarm back elements.

#### Problem with incorrect virtual element states [ID 41705]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some rare cases, the element state of a DVE or Virtual Function element would end up incorrect in the SLNet cache, causing some caches to not be initialized correctly.

#### Service & Resource Management: Problem when a previously deleted booking was created again [ID 41718]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a previously deleted booking was created again with the same ID, up to now, that booking would incorrectly not be retrieved.

#### Startup routine of a DMA with an offline time-based license would temporarily halt before continuing [ID 41736]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, the startup routine of a DataMiner Agent with an offline time-based license would temporarily halt before continuing.

#### Uploading the same version of a DVE connector twice would incorrectly cause the production version of DVE child elements to be changed [ID 41798]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When the same version of a DVE connector was uploaded twice, the production version of all DVE child elements using another version of that connector as production version would incorrectly have their production version set to the newly uploaded version.

#### Protocols: Problem when deleting an element with a parameter that had a duplicate RawType tag configured [ID 41871]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When an element was deleted, a runtime error could occur in SLProtocol when a parameter had a duplicate `RawType` tag configured.

#### SNMP managers would incorrectly receive some or all active alarms at DMA startup [ID 41878]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a DataMiner Agent was started, in some cases, the configured SNMP managers would incorrectly receive some or all active alarms.

#### Alarms without focus value would not be correctly removed from alarm groups when the associated element was deleted, stopped or paused [ID 41950]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, alarm groups containing alarms without a focus value (e.g., notices or errors) would not be correctly removed from the group when the element associated with the alarm was deleted, stopped or paused.

#### Problem with SLDataMiner when creating a dmimport package [ID 41963]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, in some cases, SLDataMiner could stop working while creating a dmimport package.

A number of enhancements have now been made with regard to error handling during the creation of dmimport packages. From now on, when an issue occurs while a dmimport package is being created, an error message will be shown in the client (e.g., DataMiner Cube).

#### Problem with SLProtocol when using a condition to check whether a table is empty [ID 41968]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLProtocol could stop working when, in a protocol, a condition was used to check whether a table is empty.

#### BPA tests would fail to load the necessary DLL files [ID 42000]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, BPAs tests would fail to load the necessary DLL files.

#### No more logging would be added to SLWatchDog2.txt after a DataMiner upgrade [ID 42180]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

After a DataMiner upgrade, in some cases, no new entries would be added to the *SLWatchDog2.txt* log file anymore.
