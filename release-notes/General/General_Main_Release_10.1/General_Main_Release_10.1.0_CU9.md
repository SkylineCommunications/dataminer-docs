---
uid: General_Main_Release_10.1.0_CU9
---

# General Main Release 10.1.0 CU9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_31048\] \[ID_31122\]

A number of security enhancements have been made.

#### Restoring a DataMiner backup package will no longer be possible when the package was created on a system with a different DataMiner version \[ID_30921\]

From now on, it will no longer be possible to restore a DataMiner backup package on a system with a DataMiner version that is different from the one on which the backup was taken.

#### DataMiner upgrade: All agents in the DataMiner System must now meet the requirements before an upgrade of the entire DataMiner System can proceed \[ID_31002\]

When you start an upgrade of an entire DataMiner System, from now on, all agents in that DataMiner System will be checked to determine if they meet the requirements specified in the upgrade package. If one of the agents does not meet the requirements, the entire upgrade will be aborted.

> [!NOTE]
> This check is performed when you upload an upgrade package. When, in DataMiner Cube, you select *Upload only*, the uploaded upgrade package will be marked “Failed” when the requirements are not met.

#### SLLogCollector: Option 'Upload to Skyline' removed \[ID_31032\]

Up to now, when an internet connection was available on the DMA, the SLLogCollector tool provided an option to upload the collected information to Skyline via email. This “Upload to Skyline” option has now been removed.

#### DataMiner Cube - Data Display: Enhanced performance when opening an element with a tree control parameter \[ID_31099\]

Due to a number of enhancements, overall performance of DataMiner Cube has increased when opening an element with a tree control parameter.

#### DataMiner Cube - Visual Overview: Enhanced updating of resource, booking and service booking information \[ID_31153\]

A number of enhancements have been made with regard to updating resource, booking and service booking information in Visual Overview.

#### Minor enhancements to several DataMiner processes \[ID_31155\]

A number of minor enhancements have been made to a number of DataMiner processes (e.g. SLXml, SLWatchdog, SLDMS, SLASPConnection and SLNet).

#### NATS upgraded to version 2.2.6 + new NATS SLNet settings \[ID_30156\]

To improve support for previous enhancements, the NATS version used by DataMiner has been upgraded to version 2.2.6.

In addition, two new options are available to refine the NATS settings in *MaintenanceSettings.xml* (in the \<SLNet> element):

- *NATSLogFileCleanupMs*: Determines the time (in milliseconds) between NATS log file cleanup attempts. This timing will only be applied after the next cleanup attempt after the configuration change. For example, if the next cleanup attempt is in 15 minutes and you change this value, the next cleanup will still be in 15 minutes, but all subsequent cleanups will happen after 1-minute intervals. The default value of this setting is 900000 (15 minutes).

- *NATSLogFileAmountToKeep*: The number of log files to keep (default =10). This value only applies to the log files that do not have the .log extension.

For example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <NATSLogFileCleanupMs>60000</NATSLogFileCleanupMs>
    <NATSLogFileAmountToKeep>20</NATSLogFileAmountToKeep>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### UDP port 162 opened by default \[ID_31035\]

In the default firewall configuration, from now on, UDP port 162 will again be opened by default.

> [!NOTE]
> On systems that do not rely on SNMP traps, it is recommended to close this port.

#### Cassandra cluster: Unnecessary scheduled maintenance tasks will automatically be deleted \[ID_31180\]

When a Cassandra cluster is starting up, the following scheduled tasks will automatically be deleted in Windows Task Scheduler:

- DBGatewayMaintenance/SLDefaultCassandraCompaction

- DBGatewayMaintenance/SLCassandraDefaultRepair

#### DataMiner Cube - Update Center: Enhanced error handling \[ID_31191\]

A number of enhancements have been made with regard to error handling and the rendering of error messages in Update Center.

#### DataMiner Cube - Visual Overview: Chromium web browser engine now supports find and zoom functionality \[ID_31232\]

The Chromium web browser engine now support find and zoom functionalities.

Available shortcuts:

| Shortcut     | Alternative shortcut | Command       |
|--------------|----------------------|---------------|
| Ctrl-F       |                      | Find          |
| Ctrl-G       | F3                   | Find next     |
| Shift-Ctrl-G | Shift-F3             | Find previous |
| Escape       |                      | Cancel find   |
| Ctrl-Plus    | Ctrl-MouseScrollUp   | Zoom in       |
| Ctrl-Minus   | Ctrl-MouseScrollDown | Zoom out      |
| Ctrl-0       |                      | Reset zoom    |

#### BPA framework: Cluster BPAs can now execute code across the entire cluster \[ID_31266\]

Cluster BPAs can now call an InvokeCluster method to execute code across the entire cluster.

#### Standalone BPA Executor: UI enhancements \[ID_31303\]

In the *Run from DMA* tab, the *Delete* and *Save* commands have been removed from the right-click menu and replaced by the following buttons:

| Button             | Function                                |
|--------------------|-----------------------------------------|
| Delete             | Delete all selected tests.              |
| Save Tests Results | Save the results of all selected tests. |

> [!NOTE]
> The *Get Last Results* button will now only fetch the most recent results for any selected tests that are run on a schedule.

#### DataMiner Cube - Services app: Enhanced performance when saving all changes made to service definitions \[ID_31355\]

Due to a number of enhancements, overall performance has increased when clicking *Save all changes* to save all changes made to service definitions in the Services app.

### Fixes

#### DataMiner Cube - Visual Overview: No longer possible to display aggregated parameter values in shapes \[ID_30864\]

In Visual Overview, it was no longer possible to display aggregated parameter values in shapes by specifying either the DMA and element ID of an aggregation element or an \[AggregationRule:...\] placeholder in a shape data field of type Aggregation.

#### Failover: Resources.xml would constantly be updated during a Failover switch \[ID_31006\]

During a Failover switch, in some cases, the Resources.xml file would constantly be updated.

#### Problem with SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved \[ID_31030\]

In some cases, an error could occur in SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved.

#### Problem during DataMiner startup when retrieving alarms for multiple elements from an Elasticsearch database \[ID_31039\]

In some cases, the DataMiner startup process could become unresponsive and the CPU usage could rise to 100% when alarms for multiple elements were being retrieved simultaneously from an Elasticsearch database.

#### SLAnalytics: Problem during initialization \[ID_31044\]

When the SLAnalytics process was starting up, in some cases, an error could occur when one of its dependencies was not available. From now on, if an error were to occur during the initialization of the SLAnalytics process, the process will shut down gracefully.

#### DataMiner Cube - Correlation: Problem when discarding or moving a duplicated correlation rule or correlation analyzer \[ID_31058\]

When you duplicated a correlation rule or a correlation analyzer and then immediately discarded the duplicate or moved it to another folder, in some cases, the original rule or analyzer would incorrectly be deleted or moved.

#### Failover: Resources.xml would incorrectly not be synchronized on offline agent \[ID_31117\]

When a new Failover configuration was created, in some cases, the Resources.xml file would incorrectly not be synchronized on the offline agent.

#### DataMiner Cube - Trending: Alarm colors on the Y axis of a trend graph would be shown incorrectly when exceptions and numeric values were combined in the same severity \[ID_31124\]

In case of a numeric parameter with exceptions, an alarm template allows you to combine an exception value and a numeric threshold in one severity. Up to now, when an exception value and a numeric threshold were combined in one severity, in some cases, the alarm colors shown on the Y axis of a trend graph would not be correct.

#### SLProtocol would evaluate certain conditions incorrectly \[ID_31129\]

When a condition defined in a protocol contained an operator like +, -, \*, /, etc. at the right-hand side but no parentheses, the operation would be applied to the left-hand side, causing SLProtocol to evaluate the condition incorrectly.

In the following example, 20 would incorrectly be added to parameter 2002 instead of parameter 2001.

```xml
<Condition><![CDATA[id:2002 < id:2001 + 20]]></Condition>
```

#### Smart-serial & smart-IP protocols: Data could get lost when receiving large data packets \[ID_31132\]

Up to now, when a smart-serial or smart-IP protocol received large data packets, in some cases, it was possible for data to get lost.

#### Scheduler: Problem when a scheduled task was deleted from Windows Scheduler \[ID_31138\]

When a scheduled task had been deleted from Windows scheduler but was still present on the DataMiner Agent, in some cases, an error could be thrown. From now on, when that type of error is thrown after a manually executed task was deleted, the task in question will be recreated.

#### DataMiner Cube: View updates and element removals would incorrectly not trigger an update of the 'Below this view' list in a view card \[ID_31141\]

In some cases, view updates and element removals would incorrectly not trigger an update of the “Below this view” list in a view card.

> [!NOTE]
> This change will also enhance overall performance when starting Cube on a system with SRM enabled and breadcrumbs disabled.

#### Problem with SLNet after replicating a DELT element \[ID_31154\]

When an element had been migrated within a DataMiner System and then configured to get replicated from its new host agent, in some cases, an incorrect subscription could be created when the replication connection was created and subsequently destroyed during DataMiner startup, prior to the agent being aware of the correct location of the DELT element. As a result, on both the former host agent and the current host agent, the CPU usage of the SLNet process would rise significantly.

#### Service & Resource Management: DateTime values were formatted incorrectly \[ID_31160\]

Due to a deserializing/serializing issue, in some cases, datetime values could be formatted incorrectly.

#### Web Services API v1: GetInformationEvents method would return an empty array \[ID_31162\]

Up to now, in some cases, the following methods would return an empty array, even when a valid timespan had been specified.

- GetInformationEvents
- GetInformationEventsV2
- GetInformationEventsSorted
- GetInformationEventsSortedV2

#### DataMiner Cube - Automation: DateTime control incorrectly updated with the DateTimeKind property \[ID_31190\]

When, in an interactive Automation script, you had configured the DateTimeKind property of a DateTime control, in some cases, the control would incorrectly be updated with the DateTimeKind property instead of the actual datetime value.

#### DataMiner Cube - Router Control: 'park source' feature would incorrectly not work on matrices with IO table structures \[ID_31239\]

Up to now, the “park source” feature would incorrectly not work on matrices with IO table structures.

#### Memory leak in SLElement when stopping or deleting an element with a protocol of type 'virtual' \[ID_31252\]

In some cases, SLElement could leak memory when stopping or deleting elements with a protocol of type “virtual”.

#### Automation: Problem when calling Engine.CreateExtraDummy or Engine.FindElement from multiple threads or tasks within the same script \[ID_31253\]

In some cases, errors could occur in SLAutomation when Engine.CreateExtraDummy or Engine.FindElement were called from multiple threads or tasks within the same script.

#### DataMiner Cube - Visual Overview: Property values would not get updated correctly \[ID_31293\]

In Visual Overview, in some cases, property values would not get updated correctly.

#### Failover: Full synchronization incorrectly not run at setup \[ID_31296\]

When a Failover system was set up, in some cases, a full synchronization would incorrectly not be run.

#### DataMiner Cube - Spectrum analysis: 'Auto RBW Factor' and 'Auto VBW Factor' values stored incorrectly in spectrum preset \[ID_31299\]

In some cases, the “Auto RBW Factor” and “Auto VBW Factor” values would be stored in spectrum presets in an incorrect way. This would then lead to an incorrect auto RBW/VBW calculation.

#### DataMiner Cube - Visual Overview: Table connections would disappear at certain zoom levels \[ID_32336\]

When using dynamic positioning in combination with dynamic zooming, shape grouping and table connections, in some cases, the connection lines could disappear at certain zoom levels.

#### DataMiner Cube - Services app: Contents of 'Configure groups' window would be arranged incorrectly \[ID_31344\]

When you right-clicked a Service Definition diagram and selected *Configure groups*, the contents of the *Configure groups* window would be arranged incorrectly. For example, the *Add group* button would be positioned at an incorrect location.

#### Jobs app: Date values saved in UTC format would be parsed incorrectly \[ID_31345\]

In the Jobs app, in some cases, date values saved in UTC format would be parsed incorrectly.

#### Web apps: Setvar controls in visual overviews would no longer be rendered correctly \[ID_31351\]

In web apps (e.g. Monitoring), in some cases, SetVar controls in visual overviews would no longer be rendered correctly.

#### STARTTLS/SSL options for SMTP would not get applied when sending generic emails \[ID_31592\]

When generic emails were sent via the SLASPConnection process, some of the SMTP options related to the connection type (STARTTLS/SSL) would not get applied, potentially causing failures when trying to send emails.

> [!NOTE]
> Since DataMiner version 10.1.10, sending emails via the SLAutomation process would also fail when using STARTTLS or non-default SSL port configurations.
