---
uid: General_Main_Release_10.2.0_CU1
---

# General Main Release 10.2.0 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner is now able to connect to Cassandra databases that require TLS 1.2 \[ID_31852\]

DataMiner is now able to connect to Cassandra databases that require TLS 1.2.

#### SLElement: Enhanced performance when resolving table relationships \[ID_32176\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving table relationships.

#### Alarms will now be assigned 3 GUIDs (for future use) \[ID_32192\]

Apart from an ID, a PreviousAlarmID and a RootAlarmID, each alarm will now also be assigned the following GUIDs for future use:

- AlarmGuid
- PreviousAlarmGuid
- RootAlarmGuid

#### DataMiner Cube: Enhanced performance when reloading protocols after a protocol update \[ID_32315\]

Due to a number of enhancements, overall performance has increased when reloading protocols after a protocol update.

#### Filtered subscriptions will now be processed similarly to non-filtered subscriptions \[ID_32399\]

Filtered subscriptions will now be processed similarly to non-filtered subscription, regardless of whether the element in question is hosted on the local DMA or a remote DMA.

#### DataMiner Cube - Users/Groups: Permissions needed to edit group membership \[ID_32456\]

When opening their user card, from now on, users will only be able to edit group membership if they have the following permissions:

- Administrator permission, or
- Limited administrator permission as well as “Edit all groups” or “Edit own groups” permission

> [!NOTE]
> Users only need to have the “Edit own groups” permission to be able to configure a group of which they are a member.

#### DataMiner backups will now by default also include SSL certificates and EPMConfig.xml files \[ID_32504\]

Full backups and configuration backups will now by default also include the EPMConfig.xml files and all certificates used by protocols for encrypted communication with devices.

#### Jobs app: Delete button will only be visible to users who have been granted permission to delete jobs \[ID_32507\]

From now on, the *Delete* button will only be visible to users who have been granted permission to delete jobs.

#### DataMiner Cube - Correlation: Using hidden elements when creating correlation rules \[ID_32510\]

When creating a correlation rule in the Correlation app, it is now possible to use a hidden element in both the *Alarm Filter* section and the *Rule Condition* section.

#### Enhanced performance when stopping SNMP elements \[ID_32523\]

Due to a number of enhancements, overall performance has increased when stopping SNMP elements.

#### Dashboards app - Parameter feed: 'Selected only' toggle button has been removed \[ID_32541\]

Up to now, a parameter feed had a *Selected only* toggle button that allowed you to show or hide items that were not selected. Now, this toggle button has been removed.

Also, when a dashboard is loaded with an initial selection (either configured or in the URL), the selected items will now always appear at the top of the list.

#### SNMP forwarding will now take into account alarm storms when resending alarms \[ID_32543\]

Up to now, when an SNMP Manager was configured to resend all active alarms every configured time interval, it would ignore any ongoing alarm storm. From now on, when there is an alarm storm, depending on whether the *Enable alarm storm protection by grouping alarms with the same parameter description* option is enabled, the following will happen:

- If the grouping option is enabled, only the alarms that are not associated with an element parameter in alarm storm will be resent.
- If the grouping option is not enabled, no alarms will be resent during the alarm storm.

> [!NOTE]
>
> - When you manually request all alarms to be resent, the logic described above will also apply.
> - When inform messages are used instead of traps and the receiving party does not return an acknowledgment, then the retry messages will still be sent, even when an alarm storm starts while those retry messages are being sent.

#### DataMiner Cube - Data Display: Row filter will now be shown when opening the alarm template, trend template or information template for a particular parameter table row \[ID_32555\]

When, in Data Display, you drill down to a specific row of a parameter table, you can open the alarm template, trend template or information template for that specific row. From now on, if a filter was configured for the table row in question, it will also be shown in the UI.

#### DataMiner Cube - Automation: SaveAutomationScriptXmlMessage will now be used when importing, saving and updating Automation scripts \[ID_32557\]

Up to now, when an Automation script was imported, the file would not be processed in the same way as when an Automation script was saved or updated. From now on, the same SaveAutomationScriptXmlMessage will be used when importing, saving and updating Automation scripts.

#### Protocols: Allow for different remote element sources in view table columns \[ID_32579\]

When setting up remote columns, up to now, all columns had to refer to the same parameter containing a list of remote elements (e.g. “view=:x:y:z”, where x is the ID of the parameter containing the remote element IDs). From now on, it is possible to have two sets of elements referenced by different columns within the same view table.

In the following example, parameters 201 and 301 each contain a list of remote elements, and both can be used within the same view table (in different ColumnOption tags).

```xml
<ColumnOption idx="3" pid="2004" type="retrieved" options=";view=:201:1000:3"/>
<ColumnOption idx="4" pid="2005" type="retrieved" options=";view=:301:1000:4"/>
```

#### Service & Resource Management: Updated exceptions thrown when the time range of a child ReservationInstance or child ReservationDefinition is invalid \[ID_32581\]

The following exception messages have been enhanced.

##### Exception thrown when the time range of a child ReservationInstance is invalid

This message now includes the ID, the name and the time range of both the parent and the child.

```txt
The TimeRange of the child is not within the boundaries of the parent ReservationInstance (Child: '{Child Name}' ({Child ID}) has range '{Child Range}' & Parent: '{Parent Name}' ({Parent ID}) has range '{Parent Range}')
```

##### Exception thrown when the time range of a child ReservationDefinition is invalid

This message now includes the ID, the name and the time range of both the parent and the child. For the child, the offset has now also been added.

```txt
The timing of the child is not within the boundaries of the parent ReservationDefinition (Child: '{Child Name}' ({Child ID}) has timing with duration '{Child Timing Duration}' and offset '{Child offset}' & Parent: '{Parent Name}' ({Parent ID}) has timing with duration '{Parent Timing Duration}')
```

#### Hanging threads in SLNet will now be logged in SLHangingCalls.txt \[ID_32582\]

Up to now, hanging threads in SLNet would be logged in the SLNet.txt file. From now on, these will be logged in the new SLHangingCalls.txt file instead (without the stack trace).

This file will by default be refreshed every 5 minutes.

#### Dashboards app: Specifying data input for an EPM feed in a URL using 'epm-selections' instead of 'cpes' \[ID_32594\]

Up to now, in a dashboard URL, it was possible to specify data input for an EPM feed by means of a “cpes” data key. This key has now been deprecated in favor of the new “epm-selections” key.

The new “epm-selections” data key consist of the following elements:

- DataMiner ID
- Element ID
- Field parameter ID
- Primary key

The following example shows a JSON object that contains an “epm-selections” data key, which can be passed to a dashboard using a URL parameter of type “data”:

```json
{
    "version": 1,
    "feed": {
        "epm-selections": ["111/222/333/index"]
    }
}
```

> [!NOTE]
> In order to maintain backward compatibility, data provided via a “cpes” object will automatically be converted when necessary.
> Only when any of the fields in the “cpes” object contain forward slashes will you need to use the new “epm-selections” object instead.

#### Enhanced performance when uploading DataMiner upgrade packages \[ID_32597\]

Due to a number of enhancements, overall performance has increased when uploading DataMiner upgrade packages.

#### DataMiner Cube - Spectrum analysis: Additional logging to help pinpoint monitor failures \[ID_32605\]

When, on a spectrum element card, you select *View buffer* in the *monitors* tab of the ribbon, the selection boxes should contain all available monitor buffers.

In DataMiner Cube, additional logging is now available to help pinpoint monitor execution failures by providing information about the monitor buffers that will be shown based on the backend buffer response.

#### DataMiner Cube - Alarm Console: Clearer summary alarm values in case of an alarm storm \[ID_32608\]

When the Alarm Console setting *Enable alarm storm protection by grouping alarms with the same parameter description* is enabled, during an alarm storm, alarms associated with the same parameter will be grouped under a summary alarm.

Up to now, the value of such a summary alarm would state “Parameter (X alarms)” with X being the number of alarm trees rather than the actual number of alarms.

From now on, the value of a summary alarm will instead state “Parameter (X alarm trees - Y alarms)”. This will allow users to see more clearly how many alarms there are left with the same parameter description and how many trees they represent.

#### DataMiner Cube: Information templates will only show the read parameter in case of a toggle button \[ID_32610\]

Up to now, for a write parameter configured as a toggle button, an information template would show two parameters: a read parameter and a write parameter. From now on, toggle buttons will be treated as regular parameters. In an information template, only the read parameter (of type discreet) will be shown.

#### Video thumbnails: New options for HTML5 video player & VLC player \[ID_32626\]

The HTML5 video player and the VLC player have a number of new options.

##### HTML5 video player

The HTML5 video player will now by default mute videos when played automatically.

##### VLC player

When playing videos using the VLC player, it is now possible to specify the volume in the URL. See the following example. The volume has to be specified as a percentage (0 to 100). Default: 0 (i.e. muted).

```txt
https://dma.local/VideoThumbnails/Video.htm?type=VLC&source=https://videoserver/video.mp4&volume=50
```

##### HTML5 video player & VLC player

Using the HTML video player or the VLC player, it is now possible to specify whether a video should be played in a loop. See the following example. Default: false

```txt
https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
```

#### Dashboards app: 'Write' filter removed from Data \> All available data \> Parameters \[ID_32643\]

When, after selecting a component in edit mode, you open the *Data* tab and go to the *All available data \> Parameters* section, you can select an element and then filter the list of parameters of that element by clicking a number of preset filters. The preset filter “Write”, which was used to filter out the parameters of type “write”, has now been removed.

#### Enhanced performance of the interprocess communication between SLDataGateway and SLAnalytics \[ID_32653\] \[ID_32709\]

Due to a number of enhancements, overall performance of the interprocess communication between SLDataGateway and SLAnalytics has increased.

#### Server processes will now use InvariantCulture \[ID_32665\] \[ID_32912\]

Up to now, server processes like SLNet used the default system locale. If this locale was a language other than English, all internal .NET Framework exception stack traces and log messages would be generated in that language, making it harder to interpret or analyze them. From now on, the server processes will now force their threads to use the CultureInvariant culture by default.

> [!NOTE]
> SLManagedAutomation and SLManagedScripting will continue to use the default system locale.

#### Backups will now by default also include the SLAnalytics configuration \[ID_32699\]

Full backups and configuration backups will now by default also include the SLAnalytics configuration.

#### DataMiner Cube - Automation: Specifying an offset value will now be optional in case of a Set action \[ID_32743\]

When, in an Automation script, you configured a Set action for which an offset value could be specified, up to now, it was mandatory to specify that offset value. From now on, specifying an offset value will be optional. Either select “with value offset” and enter a value, or select “without value offset”.

Default: “without value offset”

#### Size of SLMessageBroker.txt log file is now limited to 3MB \[ID_32863\]

The size of the SLMessageBroker.txt log file is now limited to 3MB.

#### NATS: Enhanced handling of serialization issues \[ID_32883\]

A number of enhancements have been made with regard to the handling of serialization issues.

### Fixes

#### Cassandra: Problem when reading DVEElementInfo rows that contained NULL values \[ID_32357\]

Up to now, DataMiner could throw an exception when reading a DVEElementInfo row that contained NULL values.

#### SNMP forwarding: Problem when deleting an SNMP manager and immediately creating an identical one \[ID_32406\]

When you deleted an SNMP manager of type SNMPv3 and then immediately created an identical one, in some rare cases, an exception of type “Float Invalid Operation” would be thrown.

#### Dashboards: No longer possible to switch between visualizations when a component did not require data \[ID_32413\]

When you hovered over a component that did not require data (e.g. text, clock, image, etc.), it would no longer be possible to select another visualization.

#### DataMiner Cube - Services app: Expand/collapse button in front of a service profile definition would disappear when you expanded or collapsed the service profile definition node \[ID_32439\]

When, in the Profiles tab of the Services app, you expanded or collapsed a service profile definition node in the tree on the left, the expand/collapse button in front of that service profile definition would incorrectly disappear. In other words, there was no way to reverse the expand/collapse action.

#### DataMiner Cube - Data Display: Not possible to open the alarm template or trend template of a parameter that was not trended \[ID_32449\]

When, in Data Display, you drill down to a parameter of an element, you can configure the alarm and trend templates for that specific parameter. When you tried to configure the alarm template or the trend template of a parameter that can be trended but wasn’t, up to now, it would incorrectly not be possible to open the alarm template or trend template of that specific parameter.

#### Web apps: Menu would not close after selecting the same option twice \[ID_32461\]

After selected the same menu option twice, the menu would not close until you clicked somewhere else on the page.

#### DataMiner Cube - Profiles app: Problem when trying to retrieve mediation snippets and service profiles on a system without ElasticSearch database \[ID_32488\] \[ID_32539\]

When you tried to open the Profiles app on a DataMiner System with a Service Manager license that did not have an ElasticSearch database, the app would fail to initialize when attempting to retrieve mediation snippets and service profiles. From now on, the presence of an ElasticSearch database will be checked before trying to retrieve mediation snippets and service profiles.

> [!NOTE]
> On systems without an ElasticSearch database, it is not possible to configure mediation snippets.

#### Stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements \[ID_32498\]

Up to now, in some cases, stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements.

#### Problem when trying to delete a protocol \[ID_32522\]

In some cases, an error could occur when you tried to delete a protocol.

#### DataMiner Cube - Visual Overview: Problem with initial page selection \[ID_32527\]

When you assign a Visio drawing to a view or a service, you can specify a default page. This initial page selection would no longer work.

Also, when the *How to show element card Data pages* setting was set to “Show in drop-down box”, initial page selection would no longer work.

#### Dashboards: Problem when sharing a dashboard created in an earlier version of the Dashboards app \[ID_32551\]

If you tried to share a dashboard that was created in an earlier version of the Dashboards app, in some cases, an error could occur.

#### Web services API: Problem with internal GQI calls when web sockets were disabled \[ID_32570\]

When web sockets were disabled on the DataMiner Agent, in some cases, internal GQI calls could throw exceptions.

#### SLProtocol would leak memory when using a 'change after response' trigger \[ID_32572\]

When using a “change after response” trigger, SLProtocol would leak memory on every incoming response. See the following example.

```xml
<Trigger id="2">
  <On id="1">parameter</On>
  <Time>change after response</Time>
  <Type>action</Type>
  <Content>
    <Id>2</Id>
  </Content>
</Trigger>
```

#### Elasticsearch: Problem when using a filter that checked whether a string was empty \[ID_32586\]

In some cases, Elasticsearch would return an incorrect number of records when a query contained a filter that checked whether a string was empty in combination with other filters.

#### Elasticsearch: Page would return empty when requesting the next page of naturally sorted data \[ID_32596\]

When the next page of naturally sorted data was requested from an Elasticsearch database, up to now, that page would return empty.

#### Dashboards app: Shared dashboards still showed 'Share' option \[ID_32618\]

When you clicked the “...” button in the top-right corner of a shared dashboard, the menu would incorrectly include a “Share” command.

As it is not possible to share a dashboard that has already been shared, this command will no longer be available when you open a shared dashboard.

#### SLNet would leak memory whenever a Cube session was closed or disconnected \[ID_32649\]

Whenever a Cube session was closed or disconnected, SLNet would leak memory.

#### Miscellaneous small fixes \[ID_32655\]

A number of miscellaneous, small fixes have been made.

#### Dashboards app - Parameter feed: Problem selecting the element again after clicking 'Clear all' \[ID_32661\]

When, in a parameter feed with a single element, you clicked the *Clear all* option to unselect all selected parameter, in some cases, it would no longer be possible to select the element again.

#### Migration to Cassandra cluster: Alarms and information events would not get migrated \[ID_32666\]

When migrating single Cassandra nodes to a Cassandra cluster, in some cases, the alarms and information events would incorrectly not get migrated, especially on systems with a large number of alarms and information events.

#### Serial protocols: Length check would incorrectly take into account the data before the header \[ID_32669\]

Up to now, when a payload with data before the header was received (e.g. aaaa\<header>payloadwithfixedlength), the data before the header would correctly be stripped off before forwarding the payload to the protocol, but the length check would incorrectly take that data into account.

#### SLNetClientTest: Problems with 'Agent Connections' window \[ID_32679\]

When, in the SLNetClientTest tool, you opened the *Agent Connections* window (by selecting *Diagnostics \> Connections \> View DMA Connections*),

- Agents could incorrectly display a “Disconnected” state while actually being connected.
- The “Calls From” column could incorrectly display “(not available)”.

#### DataMiner Cube - Profiles app: Problem when modifying a profile instance \[ID_32688\]

When a profile instance is modified, the existing instance is copied and the modifications are done on the properties of the newly created copy. However, up to now, the parameter entries of the profile instance would incorrectly not get copied. Instead, new parameter entries would be created. From now on, the parameter entries of the profile instance will be copied along.

#### DataMiner Cube - Alarm templates: Table conditions would no longer be saved correctly \[ID_32691\]

When, in an alarm template, you specified table conditions, in some cases, those conditions would no longer be saved correctly.

#### Dashboards: Missing sidebar when navigating to a dashboard URL for edit mode without having edit access \[ID_32706\]

When you navigate to a dashboard via a URL containing the edit=true parameter, and you do not have permission to edit that dashboard, the dashboard will not be opened in edit mode.

However, up to now, when you navigated to dashboard using a URL with an edit=true parameter and you did not have permission to edit it, although you were not in edit mode the side pane would incorrectly not appear.

#### DataMiner Cube - Asset Manager: UI could become unresponsive when the database configuration was being retrieved \[ID_32766\]

When, in DataMiner Cube, you opened the Asset Manager app, in some cases, the UI could become unresponsive when the database configuration was being retrieved.

#### SLDataGateway: Result set would incorrectly be kept in memory after retrieving alarms from the database \[ID_32788\]

When alarms had been retrieved from the database page by page, in some cases, those pages would be kept in memory indefinitely.
