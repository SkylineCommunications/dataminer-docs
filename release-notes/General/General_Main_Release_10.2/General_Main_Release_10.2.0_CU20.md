---
uid: General_Main_Release_10.2.0_CU20
---

# General Main Release 10.2.0 CU20

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### NATSCustodian: Enhanced behavior when detecting unreachable NATS nodes [ID 37271]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

From now on, when *NATSCustodian* detects unreachable NATS nodes in the cluster, it will no longer generate any alarms, nor will it reset the NATS configuration. It will only add an entry to the *NATSCustodian.txt* log file for diagnostic purposes.

NATSCustodian will only reset the NATS configuration when it detects

- that NATS nodes have been added,
- that NATS nodes have been deleted, or
- when NATS is in an incorrect state.

#### Security enhancements [ID 37335]

<!-- RN 37335: 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of security enhancements have been made.

### Fixes

#### Failover: Data can get lost when the backup agent is the online agent during a Cassandra Cluster migration [ID 34018]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When the backup agent is the online agent while a Failover pair is being migrated to Cassandra Cluster, data generated during the migration can get lost.

From now on, when you start a Cassandra Cluster migration, a warning message will appear if, for any of the Failover pairs in the cluster, the backup agent is the online agent. This warning message will advise you to make sure that, for all Failover pairs in the cluster, the main agent is the online agent.

#### Not all Protocol.Params.Param.Interprete.Others tags would be read out [ID 36797]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would be read out, which could lead to unexpected behavior.

#### Dashboards app: 'Loading...' indicator would appear when trying to save a folder of which the name consists of spaces [ID 37046]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU7] - FR 10.3.10 -->

When, in the *Create folder* or *Create dashboard* window, you clicked inside the *Location* box, clicked "+" to add a new folder, entered a series of spaces, and then clicked the checkmark button, a "Loading..." indicator would appear at the top of the window but nothing would happen.

Also, from now on, it is no longer allowed to save a folder with a name containing leading spaces.

#### DataMiner backup: Number of backups to be kept would be interpreted incorrectly [ID 37143] [ID 37509]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When configuring a DataMiner backup, you can specify the number of backups that should be kept.

Up to now, this setting would incorrectly be interpreted as the total number of backups to be kept in the system. This would cause problems on systems where the number of backups specified was smaller than the number of DataMiner Agents in the DMS.

From now on, the number of backups you specify will be the number of backups that will be kept per DMA or Failover setup. For example, when you set the number of backups to be kept to 3 on a DMS with 5 DMAs or Failover setups, 3 backups will now be kept on every DMA or Failover setup.

> [!NOTE]
>
> - A DataMiner Agent will now store its backups in a subfolder of the folder set as backup location. The name of that subfolder will be identical to the DMA ID of the DataMiner Agent in question.
> - When you upgrade to this DataMiner version, an upgrade action will automatically divide the number of backups to be kept by the number of DataMiner Agents in the DMS if the number of backups to be kept is set to more than 3 and if there are at least two DMAs in the DMS. Note that this upgrade action will do nothing if, in the backup settings, you specified that all DMAs in the DMS have to store their backups on the same network path.

#### Inventory & Asset Management: Problem when synchronizing between the DMA and the database [ID 37177]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

The Asset Manager would add NullReference exceptions to the SLNet log file when trying to synchronize between the DMA and the database.

When a view or an element was deleted on the DMA before a synchronization was performed from the database to the DMA, the deleted items would not get recreated unless the DMA had been restarted before the synchronization, and when a mediation configuration file was adapted and reloaded, the view configuration would not be reloaded.

#### Dashboards app/Low-Code Apps: Seconds of multiple clock components would not be in sync [ID 37193]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.10 -->

When you enabled the *Show seconds* option of multiple clock components on the same dashboard or app panel, the seconds would incorrectly not all be in sync.

#### DataMiner Cube - Alarm Console : Problem when a correlation/incident alarm got cleared [ID 37231]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.

#### Problem when masking a DVE child element or a virtual function [ID 37240]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you masked a DVE child element or a virtual function, not all alarms of all parameters would be masked.

#### Service & Resource Management: Resources that were still in use could be deactivated [ID 37244]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a booking ends or when a booking is deleted, SLNet will try to deactivate any function DVEs that are no longer required.

In some cases, when function DVEs were being cleaned up while a resource swap occurred on another booking, DVEs required by that other booking would incorrectly also get deactivated.

#### SLLogCollector would not copy all memory dumps to the correct folder [ID 37255]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When SLLogCollector takes memory dumps, it stores them in a temporary folder before copying them to the correct location. In some cases, a parsing problem would cause some dumps to not get copied over to the correct location.

#### Dashboards app/Low-Code Apps: Stepper component would apply an incorrect theme color [ID 37263]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In some cases, the stepper component would not apply the correct theme color.

#### DataMiner Cube - Trend templates: Offload settings would be lost when you disabled to 'Allow Offload Database Configuration' option [ID 37268]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In a trend template, you can configure the data offload settings for a particular parameter by clicking the cogwheel, enabling the *Allow Offload Database Configuration* option and configuring the settings in two dedicated columns.

Up to now, when you disabled the *Allow Offload Database Configuration* option, the two dedicated columns would disappear and the offload settings would be lost. From now on, when you disable the *Allow Offload Database Configuration* option, the offload settings that were specified will be kept and will re-appear when you enable the *Allow Offload Database Configuration* option again.

Also, when you open a trend template in which offload settings have been specified, from now on, the two dedicated columns will be visible by default.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID 37278]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).

#### DataMiner Cube - Trending: Problem with Y axis labels on trend graphs showing data from string and non-string parameters [ID 37281]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When you opened a trend graph showing trend data of a parameter of type string, and you added another, non-string parameter to that same graph, the Y axis of the newly added parameter would not be rendered correctly. The labels would be placed too close to each other, making them unreadable.

#### Elements with multiple SSH connections would go into timeout after being restarted [ID 37294]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When an element with multiple SSH connections was restarted, in some cases, it would no longer be able to communicate with the SSH server. As a result, it would immediately go into timeout.

#### DataMiner backup: DBConfiguration.xml file would not be included in backups [ID 37296]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When you took a DataMiner backup either via Cube or via the Taskbar Utility, the *DBConfiguration.xml* file would incorrectly not be included in the backup.

#### SLAnalytics: Problem due to some features not starting up correctly [ID 37321]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in the SLAnalytics process due to some features not starting up correctly.

#### Protocols: Problem when using 'MultipleGetBulk' in combination with 'PartialSNMP' [ID 37336]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When a protocol was configured to use `MultipleGetBulk` in combination with `PartialSNMP` (e.g. `<OID options="partialSNMP:10;multipleGetBulk:10">`), and the device would return less table cells than the configured `MultipleGetBulk` value, certain fields would not get filled in.

#### DataMiner Cube: No breadcrumbs would be displayed when you opened a service card [ID 37384]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a service card, in some rare cases, no breadcrumbs would be displayed.

#### SLAnalytics: Problem when the SLNet connection got lost while resetting the data sources [ID 37402]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in SLAnalytics when the SLNet connection got lost while resetting the data sources.

#### DataMiner Cube: Parameter value with decimals would be displayed incorrectly in context menus [ID 37420]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Up to now, when you opened a context menu with a text box that contained a parameter value with decimals, and the default value of the parameter also contained decimals, the decimal point in the value in the text box would be displayed incorrectly. For example, 44.2 would incorrectly be displayed as 442.0.

The issue was due to Cube trying to parse the default value with the current culture in the Windows machine.

#### DataMiner Cube - Alarm Console: Tooltip of suggestion counter would incorrectly show 'suggestion' in capitals [ID 37454]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In the Alarm Console footer, you can find counters that display the number of alarms in the current tab per severity. When you hover over one of those counters, a tooltip appears with the text "[nr of alarms] [severity]" (e.g. 31 Major).

Up to now, when you hovered over the suggestions counter, the tooltip would incorrectly show the word "SUGGESTION" in capitals. From now on, it will be shown as "Suggestion" (with capital S).
