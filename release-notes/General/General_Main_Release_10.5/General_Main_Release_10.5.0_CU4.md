---
uid: General_Main_Release_10.5.0_CU4
---

# General Main Release 10.5.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU4](xref:Cube_Main_Release_10.5.0_CU4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU4](xref:Web_apps_Main_Release_10.5.0_CU4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### BrokerGateway will now reconfigure the NATS cluster before a DMA is added to or removed from the DMS [ID 42494]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

From now on, when BrokerGateway detects that a DataMiner Agent is about to be added to or removed from a DataMiner System, it will reconfigure the NATS cluster before the DataMiner Agent is actually added or removed.

Similarly, when BrokerGateway detects that a DataMiner Agent is about to be added to a Failover setup, it will reconfigure the NATS cluster before the DataMiner Agent is actually added.

> [!NOTE]
> When BrokerGateway fails to reconfigure the NATS cluster, the DataMiner Agent will not be added or removed.

#### GQI: 'Get object manager instances' data source now supports real-time updates [ID 42530]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

On systems using the GQI DxM, the *Get object manager instances* data source now supports real-time updates. For more information on real-time updates, see [Query updates](xref:Query_updates).

Note that with this change, a possible issue has also been resolved where calling the *IGQIUpdater.AddRow* method would result in a duplicate row with the same row key being added in case a row with the same row key already existed.

#### New connector installed as part of an application package will now automatically be set as production version [ID 42623]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

When a new connector is installed for the first time on a DMS as part of an application package, from now on, it will automatically be set as production version.

Also, when, in DataMiner Cube, the current production version of a connector was set as production again, up to now, the alarm and trend templates of that connector would incorrectly not be copied to the production version when you clicked *Yes* in the *Copy templates?* dialog box.

#### DataMiner upgrade: ModuleInstaller upgrade action timeout has been increased to 30 minutes [ID 42659]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, the ModuleInstaller upgrade action would time out after 15 minutes. As this action typically runs for more than 15 minutes, this would ofter cause a notice to be logged.

From now on, the ModuleInstaller upgrade action will only time out after 30 minutes.

#### Visual Overview in the web apps: Enhanced behavior in case of a failing visual overview request [ID 42677]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a request for a visual overview in a web app failed, up to now, that request would incorrectly not be removed, causing it to block all subsequent requests for a visual overview in a web app. From now on, when a request for a visual overview in a web app fails, it will be removed from the list of pending requests.

#### Enhanced processing of service deletions [ID 42754]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a service was migrated from one DMA to another within the same DMS, in some cases, the service would be deleted by the DMA that hosted the service originally instead of the DMA that was hosting the service when it was migrated. This could potentially lead to issues within the cluster.

From now on, the message ordering the deletion of a service will always be sent to the DMA that is hosting the service. That DMA will then forward the message to the other DMAs within the cluster.

#### Enhanced performance when upgrading BrokerGateway [ID 42812]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Because of a number of enhancements, overall performance has increased when upgrading BrokerGateway.

#### Failover: Enhanced performance when executing a Failover switch [ID 42842]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Because of a number of enhancements, overall performance has increased when executing a Failover switch.

#### Security Advisory BPA test: Enhancements [ID 42850] [ID 42914]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

A number of enhancements have been made to the *Security Advisory* BPA test.

For example, the BPA test is now able to run on the offline agent of a Failover setup.

Also, when the BPA test is run on a system with a local Cassandra or Elasticsearch database, a notice will now appear, saying that a local Cassandra/Indexing setup is no longer recommended.

#### BrokerGateway: Enhanced performance [ID 42900]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Because of a number of enhancements, overall BrokerGateway performance has increased, especially after adding or removing DMAs from the cluster.

#### BrokerGateway: Enhanced error handling [ID 42929]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

A number of enhancements have been made to BrokerGateway with regard to error handling, especially in case of connection problems.

#### Migrating to BrokerGateway no longer requires a DataMiner restart [ID 42930]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

From DataMiner 10.5.0 [CU2]/10.5.5 onwards, you can migrate from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) using the *NATSMigration* tool.

Up to now, changes made to the *MaintenanceSettings.xml* file during the migration required DataMiner to be restarted. As these changes will now be read at runtime, it will no longer be required to restart DataMiner when migrating.

#### GQI: Sort operator now supports real-time updates when GQI DxM is being used [ID 42941]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

When a GQI query that included a Sort operator was used in a component of which the *Update data* option was enabled, up to now, the Sort operator would incorrectly prevent updates through real-time events. As a result, the component would be updated through notification events instead.

From now on, on systems using the GQI DxM, a Sort operator will forward all real-time events, resulting in rows being added, updated and removed as soon as an update is received.

> [!IMPORTANT]
> Sorting will not be re-evaluated on update. As a result, if an update is received for a sorting column, the table will no longer be sorted correctly.

#### Failover: Enhanced performance when executing a Failover switch [ID 42983]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Because of a number of enhancements, overall performance has increased when executing a Failover switch.

### Fixes

#### SLNet could leak memory when the progress.log file was deleted after a DataMiner upgrade [ID 42040]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

In some cases, the SLNet process could leak memory when the *progress.log* file was deleted after a DataMiner upgrade had been performed.

#### Not all DCF interfaces would be listed in the Connectivity tab of an element's Properties window [ID 42591]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in e.g. DataMiner Cube, you opened the *Connectivity* tab in the *Properties* window of an element, in some rare cases, not all DCF interfaces would be listed.

#### LDAP users added as part of an LDAP user group would incorrectly appear as local users instead of domain users [ID 42743]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, LDAP users who had been added to DataMiner as part of an LDAP user group would incorrectly appear as local users instead of domain users.

#### Problem with SLNet caused by 'DefaultUpgradeOptions' element in MaintenanceSettings.xml file [ID 42746]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, in the *MaintenanceSettings.xml* file, the `<SLNet>` element contained a `<DefaultUpgradeOptions>` sub-element, up to now, SLNet would fail to start up correctly.

> [!NOTE]
> The above-mentioned `<DefaultUpgradeOptions>` element will be added to the *MaintenanceSettings.xml* file the first time you make any changes to the default upgrade options. To change these options in DataMiner Cube, go to *System Center > System Settings > Upgrade*.

#### Problem with SLNet and/or SLHelper when the NATS connection between them was unavailable [ID 42755]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When the NATS connection between SLNet and SLHelper was unavailable, in some cases, either of those processes could stop working.

#### Problem when deleting a newly created service that had failed to load [ID 42775]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a service was created, in some cases, loading that new service would fail, even though a *service.xml* file had correctly been added on disk.Moreover, deleting that service would also fail, making it impossible to create a new service with an identical name.

From now on, when a new service fails to load, additional logging will be added, and a backup *service.xml* file will be created in the `C:\Skyline DataMiner\Recycle Bin\` folder for debugging purposes.

Also, when the service that failed to load is deleted, an attempt will be made to delete the files and folders associated with that service in order to prevent any subsequent issues when creating a new service with an identical name.

#### Problem when the element.xml file of an SNMPv3 element that used a credential library did not contain a base-16 community string [ID 42805]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, a `GetElementMessage` call would throw an exception when the *element.xml* file of an SNMPv3 element that used a credential library did not contain a base-16 community string. From now on, it will return an empty string instead.

#### SLSNMPManager process responsible for SNMPv3 communication could disappear when it was not able to redirect a trap [ID 42888]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

By default, an SLSNMPManager process responsible for SNMPv3 communication will listen for any incoming traps, and will forward, for example, SNMPv2 traps to the SLSNMPManager process responsible for SNMPv2 communication.

Up to now, when an SLSNMPManager process responsible for SNMPv3 communication was not able to communicate with the SLSNMPManager process to which it had to redirect a trap, in some cases, the process could stop working and disappear.

#### Failover: Online agent would not clear local information about elements, services, and redundancy groups from its event cache when going offline [ID 42890]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When, during a Failover switch, the online agent went offline, up to now, it would incorrectly not clear local information about elements, services, and redundancy groups from its event cache.

#### Failover: ClusterEndpoints.json files would not get updated correctly on offline agents when a DMA was added to the cluster [ID 42923]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, when a DMA was added to a DMS that contains one or more Failover pairs, in some cases, the `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` files would not get updated correctly on the offline agents.

#### Incorrect attempts to delete child DVE elements upon start or restart of a main DVE element [ID 42924]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When a main DVE element was started or restarted, up to now, an attempt would incorrectly be made to delete child DVE elements that had already been deleted, causing unnecessary information events like "Deleting element-connections for source..." to be generated.

#### Automation: Associated TXF files would not be removed when an Automation script was deleted [ID 42943]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

When you create an Automation script, apart from an XML file containing the actual script, a number of TXF files will be created. These will contain cached query information to speed up XML querying. Up to now, when an Automation script was deleted, the associated TXF files would incorrectly not be removed.

#### Failover: Database status in 'Failover status' window would incorrectly always be displayed as OK on a system using STaaS [ID 42944]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

When, in e.g. DataMiner Cube, you opened the *Failover status* window when connected to a system using STaaS, up to now, the database status would always be displayed as OK, even when STaaS was degraded.

#### DataMiner upgrade: VerifyClusterPorts prerequisite check could fail when SLXML was still running [ID 42947]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, during a DataMiner upgrade, the *VerifyClusterPorts* prerequisite check could fail when SLXML was still running.

#### Changes to LDAP users or LDAP groups would incorrectly not get synchronized among the DMAs in the cluster [ID 42950]

<!-- MR 10.4.0 [CU16]/10.5.0 [CU4] - FR 10.5.7 -->

Up to now, changes to an LDAP user or an LDAP group would incorrectly not get synchronized among the DMAs in the cluster, not even after a midnight sync.

#### Failover: NATS communication error on online agent after a Failover switch [ID 42964]

<!-- MR 10.5.0 [CU4] - FR 10.5.7 -->

After a Failover switch, in some cases, the ClusterEndpointManager would fail to initialize on the agent that had gone online. In the *Failover Status* window, *NATS communication* would show an error state.

#### Redundancy groups: Alarm mentioning that all redundancy resources are in use would incorrectly not get cleared [ID 42970]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU4] - FR 10.5.8 -->

If a redundancy group has more primary elements than backup elements, at the moment when all backups are in use, an alarm with severity level "Notice" will appear in the Alarm Console mentioning that all redundancy resources are in use.

By default, that alarm is cleared as soon as one of the backup elements is available again. However, up to now, in some cases, the alarm would incorrectly not get cleared.

### Fixes in build 16239

#### SLNet memory leak caused by ClusterEndpoint.json sync [ID 43407]

<!-- MR 10.5.0 [CU4] (but also 10.5.0 [CU5] and 10.5.0 [CU6]) - FR 10.5.7 [CU1] (but also 10.5.8 [CU1] and 10.5.9) -->

In large DataMiner Systems, especially in clusters with Failover Agents, an issue could occur when the *ClusterEndpoints.json* files were being synchronized, causing the DataMiner Agents to keep on synchronizing those files indefinitely. This could lead to a serious memory leak in SLNet, causing DataMiner Agents to disconnect frequently.
