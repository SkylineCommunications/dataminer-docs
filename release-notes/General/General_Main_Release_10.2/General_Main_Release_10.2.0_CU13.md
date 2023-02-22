---
uid: General_Main_Release_10.2.0_CU13
---

# General Main Release 10.2.0 CU13 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when creating or editing services [ID_35366]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements made with regard to the communication between SLDataMiner and SLDMS, overall performance has increased when creating or editing services, especially in heavily loaded environments.

#### Enhanced SNMP trap distribution [ID_35480]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, stopped elements will no longer be taken into account when distributing SNMP traps. When a trap has to be sent to an element on another DataMiner Agent, it will no longer be sent when that element is stopped.

#### SLAnalytics - Automatic incident tracking: Focus value updates will no longer be taken into account when determining whether the maximum group event rate was exceeded [ID_35545]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, focus value updates will no longer be taken into account when determining whether the *Maximum group event rate* was exceeded.

#### Web Services API v1: Updated descriptions of GetAlarmHistory and GetAlarmDetails methods [ID_35651]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the following interface files, the descriptions of the *GetAlarmHistory* and *GetAlarmDetails* methods have been updated:

```txt
http://DmaNameOrIpAddress/API/v1/soap.asmx
http://DmaNameOrIpAddress/API/v1/json.asmx
```

New description of the *GetAlarmHistory* method:

> Get the alarm history for the specified alarm (optional full tree request). Use root alarm ID with requestFullTree for the details of a cleared non-root alarm.

New description of the *GetAlarmDetails* method:

> Get the alarm details for the specified alarm (use GetAlarmHistory for the details of a cleared non-root alarm).

#### SLLogCollector now also collects output of 'netstat -ano' command [ID_35674]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

SLLogCollector packages will now also include the following additional file:

| File | Contents |
|------|----------|
| Logs\Network Information\Netstat.exe -ano.txt | The output of an `netstat -ano` command. |

### Fixes

#### Memory leak in SLNet after closing a client connection that had been using a "SLDataGateway.API" subscription set [ID_35319]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client connection that had been using a "SLDataGateway.API" subscription set was closed, in some rare cases, the subscription object memory would incorrectly not get cleaned up.

#### Trending: Pattern matching tags could incorrectly be defined for discrete or string parameters [ID_35368]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

Pattern matching does not support discrete or string parameters. However, up to now, when viewing a trend graph that showed trend information for either a discrete or a string parameter, it would incorrectly be possible to define tags for pattern matching. From now on, this will no longer be possible.

#### Trending: Tag icon was displayed after you selected a section of a trend graph even though it was not possible to define tags [ID_35378] [ID_35383]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, when the pattern matching feature was not enabled in *System Center* > *System settings* > *analytics config*, the tag icon was displayed after you selected a section of a trend graph even though it was not actually possible to define tags.

From now on, Cube will check whether the pattern matching feature is enabled each time you open a trend graph.

#### Problem with SLElement when stopping an EPM element [ID_35439]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

When an EPM element was stopped, in some rare cases, an error could occur in SLElement.

#### SLAnalytics : Problem after a DVE parent element had been deleted [ID_35521]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, an error could occur in the SLAnalytics process after a DVE parent element had been deleted.

#### DataMiner Cube - Visual Overview: Problem with EnableFollowMode option of Resource Manager timeline [ID_35528]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you had specified the *EnableFollowMode* option in the *ComponentOptions* shape data field of a shape configured to display the Resource Manager timeline, in some cases, that option would incorrectly be disabled.

From now on, when you activate the follow mode by specifying the *EnableFollowMode* option, the timeline will move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

#### Dashboards app: Problem with width of PDF reports [ID_35531]

<!-- MR 10.2.0 [CU13] - FR 10.3.4 -->

When a PDF report was generated via Automation or Scheduler, in some cases, its width would be set incorrectly.

Also, in some cases, the left and right padding of PDF reports generated via Automation, Scheduler and the Dashboards app itself would be missing.

#### Failover: Profile Manager would incorrectly not be initialized on the agent that was brought online [ID_35534]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a failover was triggered, in some rare cases, the Profile Manager would incorrectly not be initialized on the agent that was brought online.

In the Alarm Console, an error would appear with the following message:

```txt
Unexpected exception while triggering failover for BaseProfileManager: Skyline.DataMiner.Net.ManagerStore.CrudFailedException: Exception of type 'Skyline.DataMiner.Net.ManagerStore.CrudFailedException' was thrown.
```

#### Problem when modifying the production version of a protocol with an SNMPv3 connection [ID_35538]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you modified the production version of a protocol with multiple connections, of which one was an SNMNv3 connection, in some cases, the element could lose its SNMPv3 port settings. As a result, the SLSNMPManager process would fail to initialize the SNMPv3 communication, and the following alarm would appear in the Alarm Console:

```txt
Error parsing SNMPv3 password for port: <port number> on element: <element name>
```

Also, an error could occur in SLDataMiner when you tried to re-enter the SNMPv3 port settings.

#### Low-code apps: Sidebar would incorrectly be displayed when there was only one visible page [ID_35544]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, whether the sidebar was displayed or not would incorrectly depend on the number of pages. From now on, it will depend on the number of visible pages. In other words, the sidebar will only be displayed when there are at least two visible pages.

#### SLAnalytics - Automatic incident tracking: Alarm groups could incorrectly be created without a focus value [ID_35551]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, alarm groups could incorrectly be created without a focus value.

#### Low-code apps: Clock components in a published low-code app would incorrectly only update when you moved the mouse [ID_35554]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Clock components in a published low-code app would incorrectly only update when you moved the mouse.

#### Problem with parameter update throttling when subscribing to column parameters [ID_35578]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client subscribed on a column parameter with a filter as index (e.g. *), the messages would be throttled incorrectly.

From now on, parameter update throttling can be disabled by setting the *MessageThrottlingThreshold* option to -1 in the *MaintenanceSettings.xml* file.

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>-1</MessageThrottlingThreshold>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### DataMiner Cube - Search box: Problem when loading templates after right-clicking an element and selecting 'Assign alarm template' or 'Assign trend template' [ID_35582]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the search box in the middle of the Cube header bar, you enter the name of an element and right-click the suggested element, a context menu will open identical to that which opens when you click an element in the Surveyor.

However, when, in that context menu, you then selected *Protocols & Templates > Assign alarm template* or *Protocols & Templates > Assign trend template*, the available templates would not get loaded.

#### DataMiner Cube: Problem when receiving a notification from SLAnalytics while in alarm storm mode [ID_35596]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

An error could occur in DataMiner Cube when it received a notification from SLAnalytics while in alarm storm mode.

Also, from now on, DataMiner Cube will no longer group incident alarms into summary alarms while in alarm storm mode.

#### When retrieving the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters [ID_35607]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client retrieved the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters.

#### A number of alarm-related issues have been fixed [ID_35611]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of alarm-related issues have been fixed:

- In some cases, the alarm that closed an alarm tree would incorrectly not contain the root GUID.
- If no comment was passed when an alarm was cleared, in some cases, the comment of the previous alarm would incorrectly not be added to the closing alarm.
- In some cases, an incorrect `Alarm didn't have the correct format.` error would be logged.

#### DataMiner Cube: Pattern edit menu would incorrectly open when you resized the selected area in a trend graph [ID_35627]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you resized the selected area in a trend graph by dragging either the left or right selection boundary, the pattern edit menu would incorrectly open, even when you were not allowed to create a pattern or when you had no intention of editing a pattern.

#### SLAnalytics - Automatic incident tracking: Problem with duplicate alarms [ID_35664]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, when the SLAnalytics process started, the entire focus data cache of the agent hosting the process was cleared and recreated, causing the automatic incident tracking feature to clear any incident associated with the alarms removed from the focus data cache. When the focus data was then regenerated later on, this could lead to a recreation of the same groups.

Also, when the SLAnalytics processes of different agents in the same cluster were restarted right before a full hour, it was possible to trigger the internal duplication of active alarms hosted on non-leader agents. This could, in turn, lead to an incorrect internal alarm state and incorrect incidents containing copies of the same alarm.

From now on, the focus data cache will no longer be cleared when SLAnalytics process starts up. Instead, only the focus data associated with the alarms that are no longer active will be removed from the cache.

#### DataMiner Cube - Alarm Console: Problem when a session variable was used in an alarm filter [ID_35681]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you applied a filter to an alarm tab, no alarms would be shown when you had used a session variable in the filter.

#### Dashboards app & Low-code apps - Node edge component: An incorrect tooltip would appear when hovering over a segment of an edge [ID_35696]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you hovered over a segment of an edge, in some cases, an incorrect tooltip would appear.
