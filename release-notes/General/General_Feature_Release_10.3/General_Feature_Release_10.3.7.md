---
uid: General_Feature_Release_10.3.7
---

# General Feature Release 10.3.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.7](xref:Cube_Feature_Release_10.3.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.7](xref:Web_apps_Feature_Release_10.3.7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

#### DataMiner installation/upgrade: Automatic installation of DataMiner Extension Modules [ID_36085] [ID_36513] [ID_36514]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you install or upgrade a DataMiner Agent, the following DataMiner Extension Modules (DxMs) will now automatically be installed (if not present yet):

- DataMiner ArtifactDeployer (version 1.4.6)
- DataMiner CoreGateway (version 2.12.2)
- DataMiner FieldControl (version 2.8.3)
- DataMiner Orchestrator (version 1.3.3)
- DataMiner SupportAssistant (version 1.3.3)

The BPA test *Firewall Configuration* has been altered to also check if TCP port 5100 is properly configured in the firewall. This port is required for communication with the cloud via the endpoint hosted in DataMiner CloudGateway.

In addition, the DataMiner installer will now also add a firewall rule allowing inbound TCP port 5100 communication.

> [!NOTE]
> For detailed information on the changes included in the different versions of these DxMs, refer to the [dataminer.services change log](xref:DCP_change_log).

#### Marker images can now also be generated dynamically in layers with sourceType set to objects [ID_36246]

<!-- MR 10.4.0 - FR 10.3.7 -->

Marker images can now also be generated dynamically in layers with `sourceType` set to "objects".

To generate a marker image dynamically, you can use placeholders in the `url` attribute of the *\<MarkerImage\>* tag.

## Changes

### Enhancements

#### Cassandra: gc_grace_seconds will now be set to 1 day by default and to 4 hours for records with TTL set [ID_34763]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

In Cassandra databases, the table property `gc_grace_seconds` will now be set to 1 day by default.

For tables containing data with TTL set, this property will be set to 4 hours.

#### Cassandra Cluster Migrator tool now supports TLS [ID_34852]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) is now able to establish TLS connections towards the databases.

#### Enhanced performance when retrieving resources [ID_36129]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when retrieving resources.

#### Failover: Obsolete CheckVIPs thread has been removed [ID_36253]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In Failover setups using virtual IP addresses, once every minute the CheckVIPs thread would check whether the online Agent holds the correct IP addresses. However, due to the many locks it claimed to verify the current state of the IP addresses, it would delay other actions being executed in the system.

This obsolete thread has now been removed.

#### Service & Resource Management: Enhanced logic to determine which function DVEs to deactivate [ID_36299]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when the function manager needed to deactivate function DVEs because the threshold was reached, it could do so for resources that were needed for bookings being started of which the status was not yet "ongoing".

From now on, function DVEs will no longer be deactivated when they are part of a booking that is either confirmed or ongoing with a start time (minus hysteresis) in the past and an end time in the future.

#### SLAnalytics - Automatic incident tracking: Relations based on alarm data will now also be taken into account [ID_36337]

<!-- MR 10.4.0 - FR 10.3.7 -->

Up to now, alarm grouping based on parameter relationship data would only take into account relations based on change points. From now on, relations based on alarm data will also be taken into account.

On systems running alarm grouping based on both parameter and alarm relationship data, the `C:\Skyline DataMiner\analytics\configuration.xml` will contain an `<item>` tag like the following. Note that `cpRelationThreshold` has been renamed to `relationThreshold` and that its value is set to 0.7 by default.

Example:

```xml
<Value type="skyline::dataminer::analytics::workers::configuration::RelationVisitorConfiguration">
   <enable>true</enable>
   <relationThreshold>0.7</relationThreshold>
</Value>
```

> [!CAUTION]
> Always be extremely careful when changing any of the settings configured in `C:\Skyline DataMiner\analytics\configuration.xml`, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### User-defined APIs: UserDefinableApiEndpoint DxM now targets Microsoft .NET 6.0 [ID_36338]

<!-- MR 10.4.0 - FR 10.3.7 -->
<!-- Not added to MR 10.4.0 -->

As Microsoft .NET 5 is being phased out, the *UserDefinableApiEndpoint* DxM will now use Microsoft .NET 6.0 instead.

Also, in the module's *appsettings.json* file, `NatsSubject` is now an optional setting.

#### DataMiner tasks in Windows Task Scheduler will now return 0 instead of error code 1 [ID_36393]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

The following scheduled tasks will now by default return 0 instead of error code 1.

- Skyline DataMiner Backup (DataMinerBackup.js)
- Skyline DataMiner Database Optimization (OptimizeDB.js)
- Skyline DataMiner LDAP Resync (ReloadLDAP.js)

#### SSH settings saved in parameters are now passed to SLPort together instead of separately [ID_36404]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you set up an SSH connection in a protocol, you can store the username, the password, the SSH options and the IP address in parameters using a `<Type options="">` element inside the `<Param>` element.

| Parameter          | Option                          |
|--------------------|---------------------------------|
| SSH username       | `<Type options="SSH USERNAME">` |
| SSH password       | `<Type options="SSH PWD">`      |
| SSH options        | `<Type options="SSH OPTIONS">`  |
| Dynamic IP address | `<Type options="DYNAMIC IP">`<br>Note: This value can also be used for other types of connections. |

Up to now, when an element with an SSH connection was started, these values would each be passed separately to SLPort. From now on, they will all be passed together to SLPort.

> [!NOTE]
> A separate set will be performed whenever one of the above-mentioned values is changed at runtime.

### Fixes

#### Service & Resource Management: Contributing resources of which the contributing booking had ended would not be marked available [ID_35757]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When updating an ongoing main booking that made use of a contributing resource of which the contributing booking had already ended, the ResourceManager would incorrectly mark the contributing resource as unavailable. As a result, the update would fail and the main booking would go into quarantine with reason "ContributingResourceNotAvailable".

Also, a *GetEligibleResources* call would not return the contributing resource.

#### Service & Resource Management: Enhanced performance when loading service profile instances [ID_35878]

<!-- MR 10.4.0 - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when loading service profile instances.

#### Business Intelligence: Secondary index of certain SLA logger tables would not be created correctly [ID_36245]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

The secondary index of certain SLA logger tables would not be created correctly. As a result, certain rows in those tables would not get cleaned up and exceptions like the following would be added to the *SLDBConnection.txt* log file:

```txt
SLDataGateway.Types.DBGatewayException: CassandraConnection ExecuteQuery - exception while executing query: SELECT "array_active_service_alarms_id","array_active_service_alarms_time" FROM ELEMENTDATA_7102_1334_750 WHERE "array_active_service_alarms_rootid" = '0/0'; - Cannot execute this query as it might involve data filtering and thus may have unpredictable performance. If you want to execute this query despite the performance unpredictability, use ALLOW FILTERING
```

When SLAs were stored in a Cassandra cluster, none of their rows would get cleaned up.

#### Service & Resource Management: Problem when updating a booking while actions were being performed [ID_36268]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a booking was updated while actions were being performed, in some cases, it could become corrupted.

For example, when a booking was rescheduled while it was being started, it could end up in an *Ongoing* status with a start time somewhere in the future.

#### Client connection would be dropped because an SLNet request handled by SLHelper took too long to process [ID_36296]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When it took SLHelper more than 15 minutes to process an SLNet request received from a client, a NATS exception was returned to the client. However, as this exception was not serialized, the client would not receive it, causing the client connection to get dropped.

From now on, NATS exceptions returned to a client following an SLHelper timeout will always be serialized.

#### Protocols: QAction syntax errors did not refer to the correct lines [ID_36301]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, before a QAction was compiled, three compiler directives were added to its source code. As a result, all compilation errors would refer to incorrect line numbers.

From now on, the compiler directives will no longer be added to the source code. Instead, they will be passed to the compiler directly.

#### SLNetClientTest: Problem when trying to set up a connection using gRPC [ID_36322]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When the *SLNetClientTest* tool tried to set up a connection using gRPC, a `MissingMethodException` exception could be thrown.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Exported DVE child protocols would no longer be set as production after re-uploading a main DVE protocol version used as production version [ID_36334]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you re-uploaded a main DVE protocol with the same version as the one that was being used as production version, the exported child protocols would incorrectly no longer be set as production.

#### Community credentials from the credential library would be ignored for SNMPv1 and SNMPv2 [ID_36353]

<!-- MR 10.4.0 - FR 10.3.7 -->

When, in element settings, community credentials from the credential library were used, those credentials would be ignored for SNMPv1 and SNMPv2. The get-community and set-community configured on the element would incorrectly be used instead.

#### SNMP tables using the 'subtable' option no longer received any data when a single-value filter was applied [ID_36370]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a single-value filter was applied to an SNMP table using the `subtable` option, in some cases, the table would no longer receive any data.

Due to a filtering problem, using a single filter like "1.1" would no longer poll instances like "1.1" and "1.1.2". This has now been fixed.

Also, it is now possible to use a "\*" wildcard in a filter. See the following examples:

- "1.2" will accept values like "1.2.1" and "1.2.2", but will reject "1.3.1" and "2.2".
- "1.*" will accept values like "1.1" and "1.2.3", but will reject "1" and "2.1.2".
- "*.1" will accept values like "2.1" and "2.1.2", but will reject "1.1" and "1.2.1".

#### Protocols: Setting the type of an advanced port to SNMPv3 would cause the advanced port settings to get lost [ID_36400]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, while editing an element using a (production) protocol with an advanced port of type SNMPv1 or SNMPv2, you set the type of the advanced port to SNMPv3, then the advanced port settings would get lost when the production version of the protocol was set to another version that also did not have SNMPv3 configured. Moreover, when you tried to correct the advanced port settings of the element, an error would occur in SLDataMiner as soon as you applied the changes.
