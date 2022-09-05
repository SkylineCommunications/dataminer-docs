---
uid: General_Main_Release_10.2.0_CU5
---

# General Main Release 10.2.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_33684\]

A number of security enhancements have been made.

#### DataMiner Cube - ListView component: No longer possible to filter on columns of type datetime \[ID_32900\]

In the ListView Component, from now on, it is no longer possible to filter on columns of type datetime.

#### Failover: Current Failover DMA status will now automatically be refreshed every minute \[ID_33426\]

In the *Failover Config* window as well as the *Status* dialog box, the current Failover DMA status will now automatically be refreshed every minute.

#### Enhanced BPA error message \[ID_33393\]

Up to now, when a BPA test could not be executed on an offline Failover agent, it would return the following error message:

```txt
This BPA does not apply for this DataMiner Agent.
```

From now on, it will return the following error message instead:

```txt
This BPA does not apply for this DataMiner Agent: cannot run on Offline Failover Agent.
```

#### GQI queries: Enhanced performance when retrieving custom properties \[ID_33538\]

Because of a number of enhancements, overall GQI query performance has increased when retrieving custom properties for views, services and elements.

#### DataMiner Upgrade: Additional action to delete legacy custom data templates \[ID_33628\]

In DataMiner main version 10.0.0 CU11 and feature version 10.1.1, new Elasticsearch templates for custom data indices were introduced to support adding new fields after index creation. An upgrade action has now been added to remove all legacy Elasticsearch templates from the system. During the first DataMiner startup after the upgrade, the templates will then be recreated.

#### Business Intelligence: Enhancements made to the automatic SLA data clean-up mechanism \[ID_33663\]

A number of enhancements have been made to the automatic SLA data clean-up mechanism.

#### DataMiner Cube - System Center: Enhancements made to Failover Configuration window \[ID_33747\]

In DataMiner Cube, the following enhancements have been made to the *Failover Configuration* window:

- In the *Advanced \> Virtual IP Addresses* tab, the columns are now wide enough to display the full IP address/mask.
- The *Advanced \> Heartbeats* tab now indicates which heartbeats are inverted.

#### Clearer error message will now appear when a DataMiner Agent cannot be reached \[ID_33752\]

When a DataMiner Agent could not be reached, in some cases, an “Attempt to use an unauthenticated connection” error would appear in the log files or on the UI. From now on, a clearer error message will appear instead.

### Fixes

#### Problem with SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped \[ID_33437\]

In some cases, an error could occur in SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped.

#### Problems when migrating data from SQL to Cassandra \[ID_33524\]

In some cases, the following issues could occur when migrating data from SQL to Cassandra:

- Online migration would be executed, but would not get marked as completed in Cube.
- Offline migration would fail to launch.

Also, Cube will no longer throw “System.InvalidOperationException: Collection was modified” errors.

#### DataMiner Cube: Properties of exported elements would not be added to the CSV file in the correct order \[ID_33528\]

When you had exported elements to a CSV file, the element properties would not be added to the CSV file in the correct order.

#### Booking instance created before DMA restart not starting \[ID_33556\]

In some cases, it could occur that a booking instance did not start. More specifically, this happened if the booking instance was created with a start time in the future, and the hosting Agent of the instance was restarted before that start time. After the Agent restart, the booking instance was not immediately loaded into the cache of the hosting Agent. If the custom properties of the booking instance were then updated, but no other updates happened to the booking instance before its start time, it would not start.

#### DataMiner Cube - Data Display: Problems with button and date/time picker sizing \[ID_33601\]

In some cases, the width of a button would not automatically be adapted to the text displayed on the button.

Also, in date/time picker controls, the buttons to pick or clear a date/time would not be displayed correctly.

#### DataMiner Cube - Annotations: Images would get removed when saving an annotation \[ID_33623\]

When you saved an annotation, in some cases, any images added to the annotation would incorrectly get removed.

#### DataMiner Cube - Trending: Creation, update and deletion of a trend pattern would not be communicated to the other DataMiner Agents in the DMS \[ID_33624\]

When you created, updated or deleted a tag, up to now, this would incorrectly not be communicated to the other DataMiner Agents in the DMS.

#### Web apps: Minor theme and color issues \[ID_33631\]

When you opened a side panel that used the Skyline Black theme, in some cases, the overlay would incorrectly use the (default) white theme.

Also, when you opened an app, the name of that app would incorrectly be displayed in green. From now on, the name of the app will be displayed in the color of the app.

#### DataMiner Cube - Data Display: Buttons inside a table would incorrectly be grayed out when scrolling \[ID_33641\]

When scrolling through a table of which the rows contained buttons, in some cases, those buttons would incorrectly be grayed out.

#### DataMiner Cube - Visual Overview: Problem when dynamically generating booking shapes \[ID_33676\]

When, in Visual Overview, a shape had to be created automatically for each booking in a particular set of bookings, in some cases, a subscription error would prevent these shapes from being created.

#### Serializing/deserializing would not work when dictionary key contained spaces \[ID_33677\]

Up to now, serializing/deserializing would not work when creating a filter that contained spaces inside quotes (see the example below).

Example:

```txt
AlarmEventMessageExposers.PropertiesDict.DictStringField($"Booking Manager Element ID").Matches(".+")
```

#### Service & Resource Management: Problem when adding, updating or deleting a resource \[ID_33678\]

When you tried to add, update or delete a resource, a NullReferenceException could be thrown when the Resources.xml file was locked by another process.

#### DataMiner Cube - Spectrum Analysis: Problem with 'Next trace' button and slider after a spectrum recording had been paused \[ID_33718\]

When you had paused the replay of a spectrum recording, in some cases, the “next trace” button and the slider would not work correctly.

#### No alarm would be generated when an element that exported data failed to start \[ID_33744\]

When an error occurred during the startup of an element that exported data (e.g. a DVE or function element), in some cases, no alarm would be generated.

#### Web services API: High CPU usage when executing web methods \[ID_33746\]

In some rare cases, CPU usage would increase when executing web methods.

#### Web apps - Node edge graph: Node tooltips did not have the correct color \[ID_33757\]

In a node edge graph, in some cases, the node tooltips did not have the correct color.

#### SLWatchdog: Problem when generating the database report \[ID_33769\]

In some cases, an error could occur in SLWatchdog when generating the database report.

#### DataMiner Cube - Elements: Problem when selecting the Replicate checkbox before selecting a DMA \[ID_33773\]

When, while creating a new element on a DataMiner Agent in a DMS, you selected the *Replicate* checkbox without first selecting a DataMiner Agent, the *Replicate Element* settings would not be shown and the *Device Details* would remain unavailable.

From now on, the Replicate checkbox will be unavailable as long as no DataMiner has been selected.

#### Failover: Problem with AlwaysBruteForceOffline option \[ID_33775\]

The following problems with the Failover option *AlwaysBruteForceOffline* have now been fixed:

- When configured via an UpdateFailoverConfigMessage in an Automation script, the option would not be applied in the DMS.xml file.
- When configured by manually updating the DMS.xml file, the option would be overwritten.
- When applied, the option would cause the DMA to restart without also restarting SLNet.

> [!NOTE]
> In DataMiner Cube, the *AlwaysBruteForceOffline* option can now be configured by enabling or disabling the *Auto restart agent when going offline* option in the *Advanced options* tab of the *Advanced Failover Configuration* window.

#### DataMiner Cube - System Center: Enforcing a client version would not work \[ID_33802\]

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions* and force users to always use a particular Cube version. In some cases, this would not work. The following error message would appear: “Error: file already exists but has incorrect size”.

#### DataMiner Cube: User permission 'Manage client versions' was not positioned correctly in the user permission hierarchy \[ID_33845\]

The “Manage client versions” user permission was not positioned correctly in the user permission hierarchy and did not have a translatable description.

#### SNMP: Former value of updated cell would incorrectly be returned the first time the table was polled after the update \[ID_33855\]

When a cell in a table with “pollingrate” enabled had been updated, the first time the table was polled after the update, the former value of that cell would incorrectly be returned.

#### Protocols: Additional connections with a 'Type' defined would incorrectly be ignored \[ID_33941\]

Additional connections that had a “\<Type>” defined would incorrectly no longer be taken into account.

In the following example, the second connection would incorrectly be ignored.

```xml
<Connections>
  <Connection id="0" name="HTTP Connection">
    <Type>http</Type>
    ...
  </Connection>
  <Connection id="1" name="WebSocket Interface">
    <Type>http</Type>
    ...
```

> [!NOTE]
> Specifying a type with \`\<Type>\` for one connection and specifying a type with e.g. \`\<Http>\` for another connection is not supported.
