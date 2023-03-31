---
uid: General_Feature_Release_10.2.8
---

# General Feature Release 10.2.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### DataMiner Object Model: Defining a script execution action that will execute an interactive Automation script \[ID_33513\]

It is now possible to define a script execution action that will execute an interactive Automation script.

Process:

1. A client requests the execution of a DOM action in which the execution of an interactive Automation script has been defined via the domHelper.DomInstances.ExecuteAction() method.

   To indicate that the Automation script is an interactive Automation script, the IsInteractive property of the ExecuteScriptDomActionDefinition must be set to true.

1. The domHelper.DomInstances.ExecuteAction() method replies immediately.

   - Its TraceData contains a DomActionInfo object in which type is set to DomActionInfo.Type.ScriptExecutionId.
   - The info object has an ExecutionId property that contains the execution ID of the script that was triggered by the DOM action.

1. The client sends a ScriptControlMessage of type Launch using the script ID that was returned and will then receive ScriptProgressEventMessages.

> [!NOTE]
> The connection used by the DomHelper sending the DOM action execution request should also be used to interact with the script.

#### New BPA test 'Verify Cloud DxM Version' \[ID_33956\]

This new BPA test checks if the minimum required version is installed for all DxMs in the system.

It is available from DataMiner 10.2.8 and 10.2.0 \[CU6\] onwards. You can run it in System Center (on the *Agents \> BPA* tab), and it also runs automatically when you upgrade to 10.2.0 \[CU6\]/10.2.8 or higher.

For more information, see [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version).

#### DataMiner upgrade: When VerifyClusterPorts prerequisite fails the user will now receive more information on why it failed \[ID_33979\]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 [CU0] -->

When, during a DataMiner upgrade, the VerifyClusterPorts prerequisite fails, you will now receive more information on why it failed. For example, the DMS.xml file could contain faulty IP addresses or NATS may have silently failed.

### DMS Cube

#### Visual Overview - Resource Manager component: Passing elements, services or views using the YAxisResources variable \[ID_33402\]

From now on, you can pass elements, services, or views to the YAxisResources session variable in order to show the corresponding resource bands.

##### Passing elements

You can pass elements by name or by ID as a string of comma-separated values.

In case an element is configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resource will be shown.

In the following example, three elements are passed: an element with the name "MyElement", the element to which the Visio drawing is linked, and the element with ID 123/456:

```txt
YAxisResources:Element=MyElement,[this element],123/456
```

The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

##### Passing services

You can pass services by name or by ID as a string of comma-separated values.

The resources of the bookings linked to the services will be shown.

In the following example, three services are passed: a service with the name “MyService”, the service to which the Visio drawing is linked, and the service with ID 123/456:

```txt
YAxisResources:Service=MyService,[this service],123/456
```

To also show resources for contributing bookings, in the ComponentOptions shape data field of the Resource Manager component, specify Recursive=True.

The resource band will be updated in real time, based on the linked booking. This means that when you add or remove resources in a booking, you will immediately see the effect on the timeline.

##### Passing views

You can pass views by name or by ID as a string of comma-separated values.

When you pass a view, for any elements in that view that are configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resources will be shown.

In the following example, three views are passed: a view with the name "MyView", the view to which the Visio drawing is linked, and the view with ID 123:

```txt
YAxisResources:View=MyView,[this view],123
```

To also show resources for elements in child views, in the ComponentOptions shape data field of the Resource Manager component, specify Recursive=True.

The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

#### Failover: Current Failover DMA status will now automatically be refreshed every minute \[ID_33426\]

In the *Failover Config* window as well as the *Status* dialog box, the current Failover DMA status will now automatically be refreshed every minute.

#### Visual Overview - Resource Manager component: Selecting multiple resource bands in the timeline \[ID_33536\]

In the timeline of an embedded Resource Manager component, it is now possible to select multiple resource bands.

To select more than one resource band, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive resource bands, click the first one and then click the last one while holding down the SHIFT key.

When you select more than one resource band, the SelectedResource session variable will contain the GUIDs of all selected resources, separated by commas.

#### Trending - Behavioral anomaly detection: Enhanced detection of change points of type 'flatline' \[ID_33559\]

Up to now, a change point of type “flatline” would be detected when the parameter value remained constant for more than 3 polling times. From now on, instead of counting polling times, a running estimate will be kept of how long the parameter typically remains constant.

If this estimate exceeds 1 hour, no change points of type “flatline” will be detected. Else, a change point of type “flatline” will be detected if the parameter value was not constant in the last hour but is constant again for more than 3 times the running estimate.

#### Visual Overview - Resource Manager component: Enhanced way of selecting a time range \[ID_33580\]

In the timeline, the context menu will no longer open automatically after selecting a time range by means of drag-and-drop. Instead, it will now only open when you right-click.

This change in behavior will now allow you to trigger a script by clicking an action button instead of selecting an option in the context menu of the timeline. In other words, you will now be able to proceed as follows:

1. Select a resource band.
2. Select a time range.
3. Click an action button.

The SelectedTimeRange variable will now be cleared when the time selection is cleared (i.e. when it is no longer visible/available). Up to now, this variable would only be cleared when the selection was changed.

#### System Center - Agents: BPA Details window now has a Copy button that copies the list of errors to the Windows clipboard \[ID_33638\]

When, in the *BPA* tab of the *Agents* section, you see a BPA test that returned errors during its last run, you can click “...” to open a *Details* window listing those errors.

At the bottom of this *Details* window, you can now find a *Copy* button that allows you to copy the list of errors to the Windows clipboard.

#### Visual Overview: \[this reservationID\] placeholder \[ID_33669\]

In shape data or shape text of shapes linked to a booking (e.g. dynamically generated shapes that represent bookings), you can now use a \[this reservationID\] placeholder to retrieve the GUID of the booking.

See the following examples:

`[Resource:[reservation:[this reservationID],ResourceID|NodeID=18|],Name]`

`[reservation:[this reservationID],Property=Monitoring]`

### DMS Automation

#### Added the option to skip the 'script started' information event \[ID_33666\]

When sending an ExecuteScriptMessage, you can now specify that no “Script started” information event should be generated when the script is executed. To do so, add the SKIP_STARTED_INFO_EVENT:TRUE option to the string array as shown in the following example.

```csharp
ExecuteScriptMessage esm = new ExecuteScriptMessage("Script")
{
    Options = new SA(new[]
    {
        "OPTIONS:0",
        "CHECKSETS:TRUE",
        "EXTENDED_ERROR_INFO",
        "SKIP_STARTED_INFO_EVENT:TRUE"
    })
};
engine.ExecuteScript(esm);
```

Also, the SubScriptOptions class has been extended with a SkipInitialInfoEvent property that can be used to pass the above-mentioned option to subscripts. See the following example.

```csharp
var options = engine.PrepareSubScript("SubScript");
options.Synchronous = true;
options.PerformChecks = false;
options.SkipStartedInfoEvent= true;
options.StartScript();
```

### DMS web apps

#### Dashboards app: Service Definition component now supports both types of process automation service definitions \[ID_33615\]

The Service Definition component now supports both types of process automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### GQI: Data source 'Get custom data' renamed to 'Get ad hoc data' \[ID_33795\]

The data source “Get custom data” has been renamed to “Get ad hoc data”.

#### Dashboards app - Visual Overview component: Loading bar at the top of the component instead of large loading message on top of the component \[ID_33829\]

When a Visual Overview component was loading, up to now, a large loading message was displayed on top of the component. From now on, when a Visual Overview component is loading, a loading bar will appear at the top of the component instead.

#### DataMiner Application Framework: Action editor window can now be closed by clicking the OK button \[ID_33853\]

The action editor window can now be closed by clicking the *OK* button.

### DMS tools

#### QA Device Simulator: Help link now directs users to the QA Device Simulator help pages on docs.dataminer.services [ID_33680]

In the UI of the QA Device Simulator, the help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

## Changes

### Enhancements

#### Security enhancements \[ID_33583\] \[ID_33684\]

A number of security enhancements have been made.

#### SLAnalytics: Enhanced accuracy of proactive cap detection \[ID_32591\]

Because of a number of enhancements, proactive cap detection accuracy has been increased.

#### DataMiner Cube - ListView component: No longer possible to filter on columns of type datetime \[ID_32900\]

In the ListView Component, from now on, it is no longer possible to filter on columns of type datetime.

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

#### NATS: Enhancements to the NATS configuration \[ID_33558\] \[ID_33931\]

A number of enhancements have been made to the NATS configuration:

- STAN clustering has been removed.

- New NATSForceManualConfig option to disable the automatic reset timer in NATSCustodian.

  Disabling the timer can be done in one of the following ways:

  - Set the SLNet option “NATSForceManualConfig” to true in the SLNetClientTest tool (default = false).
  - Set the SLNet.NATSForceManualConfig tag to true in MaintenanceSettings.xml.

> [!NOTE]
>
> - Changing this option in the SLNetClientTest tool can be done at run-time. The change will be applied immediately.
> - Forcing manual configuration will disable the automatic NATS configuration on the DataMiner System. It will then be up to the user to either manually configure a NATS cluster or manually call NatsCustodianResetNatsMessage when changes are made to the DMS.

- On DataMiner startup, NAS and NATS will now automatically be started if they are not running.

Also, the nats-streaming-server binary has been updated to v0.24.6. However, note that it will not be updated automatically via upgrade actions. It will only be installed during fresh NATS installations or when reinstalling NATS via SLEndpointTool_Console. The previous version (v0.22.0) and the new version (v0.24.6) version are compatible and are able to communicate with each other.

#### Service & Resource Management: A booking will now be set to 'interrupted' when whatever event related to that booking could not be executed \[ID_33576\]

Up to now, when DataMiner was unavailable when a booking was supposed to start or stop, its state was set to “interrupted” when DataMiner started up again.

This functionality has now been extended. A booking will now also be set to “interrupted” when whatever event related to that booking could not be executed.

#### DataMiner Cube - Alarm Console: 'Add to incident' menu option no longer available when right-clicking alarms that cannot be added to an incident \[ID_33591\]

From now on, the “Add to incident” menu option will no longer be available when you right-click an alarm that cannot be added to an incident:

- Active alarms with severity “normal” (i.e. clearable alarms that have not been cleared yet)
- Alarms with a source other “DataMiner System” (e.g. correlation alarms)
- Alarms associated with DataMiner itself
- Notices, errors, information events and suggestion events

#### DataMiner Upgrade: Additional action to delete legacy custom data templates \[ID_33628\]

In DataMiner main version 10.0.0 CU11 and feature version 10.1.1, new Elasticsearch templates for custom data indices were introduced to support adding new fields after index creation. An upgrade action has now been added to remove all legacy Elasticsearch templates from the system. During the first DataMiner startup after the upgrade, the templates will then be recreated.

#### Dashboards app: Enhanced 'loading' indication when state component linked to a GQI query receives an update \[ID_33640\]

Up to now, each time a state component linked to a GQI query received an update, a “loading” indication would be displayed over the entire component. From now on, when such a component receives an update, a more subtle loader bar will be displayed instead.

Also, when a query error occur, from now on, the actual error will be displayed instead of “No data”.

#### Business Intelligence: Enhancements made to the automatic SLA data clean-up mechanism \[ID_33663\]

A number of enhancements have been made to the automatic SLA data clean-up mechanism.

#### GQI: Enhanced performance when running a GQI query with a filter applied to it \[ID_33664\]

Because of a number of enhancements, overall performance has improved when running a GQI query with a filter applied to it.

#### DataMiner Cube - System Center: Enhancements made to Failover Configuration window \[ID_33747\]

In DataMiner Cube, the following enhancements have been made to the *Failover Configuration* window:

- In the *Advanced \> Virtual IP Addresses* tab, the columns are now wide enough to display the full IP address/mask.
- The *Advanced \> Heartbeats* tab now indicates which heartbeats are inverted.

#### Clearer error message will now appear when a DataMiner Agent cannot be reached \[ID_33752\]

When a DataMiner Agent could not be reached, in some cases, an “Attempt to use an unauthenticated connection” error would appear in the log files or on the UI. From now on, a clearer error message will appear instead.

#### DataMiner Application Framework: Splash screen of apps now shows 'Low-code apps' instead of 'Apps' \[ID_33798\]

When you start up a custom low-code application created using the DataMiner Application Framework, its splash screen will now show “Low-code apps” instead of “Apps”.

### Fixes

#### Problem with SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped \[ID_33437\]

In some cases, an error could occur in SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped.

#### Problems when migrating data from SQL to Cassandra \[ID_33524\]

In some cases, the following issues could occur when migrating data from SQL to Cassandra:

- Online migration would be executed, but would not get marked as completed in Cube.
- Offline migration would fail to launch.

Also, Cube will no longer throw “System.InvalidOperationException: Collection was modified” errors.

#### DataMiner Cube - Visual Overview: Session variables of Resource Manager component would incorrectly be set to NULL when cleared \[ID_33527\]

When the following session variables of an embedded Resource Manager component were cleared, up to now, they would incorrectly be set to NULL. From now on, they will be set to an empty value instead.

- ResourcesInSelectedReservation
- SelectedOccurrence
- SelectedPool
- SelectedReservation
- SelectedReservationDefinition
- SelectedResource
- SelectedSession
- TimerangeOfSelectedReservation

#### DataMiner Cube: Properties of exported elements would not be added to the CSV file in the correct order \[ID_33528\]

When you had exported elements to a CSV file, the element properties would not be added to the CSV file in the correct order.

#### DataMiner Cube - Resources app: Empty Occupancy tab \[ID_33540\]

The first time you clicked the *Occupancy* tab after opening the *Resources* app, in some rare cases, that tab would incorrectly be empty.

#### DataMiner Cube - Data Display: Problems with button and date/time picker sizing \[ID_33601\]

In some cases, the width of a button would not automatically be adapted to the text displayed on the button.

Also, in date/time picker controls, the buttons to pick or clear a date/time would not be displayed correctly.

#### GQI: Datetime values in retrieved booking information would incorrectly not be converted to UTC time \[ID_33607\]

When a GQI query retrieved booking information, the datetime values would incorrectly not be converted to UTC time.

#### DataMiner Cube - Annotations: Images would get removed when saving an annotation \[ID_33623\]

When you saved an annotation, in some cases, any images added to the annotation would incorrectly get removed.

#### DataMiner Cube - Trending: Creation, update and deletion of a trend pattern would not be communicated to the other DataMiner Agents in the DMS \[ID_33624\]

When you created, updated or deleted a tag, up to now, this would incorrectly not be communicated to the other DataMiner Agents in the DMS.

#### Web apps: Minor theme and color issues \[ID_33631\]

When you opened a side panel that used the Skyline Black theme, in some cases, the overlay would incorrectly use the (default) white theme.

Also, when you opened an app, the name of that app would incorrectly be displayed in green. From now on, the name of the app will be displayed in the color of the app.

#### Application framework: Update of page load event would not be applied \[ID_33632\]

When you edited a page load event, upon publishing the application that event would incorrectly still launch the former action instead of the new one.

#### DataMiner Cube - Data Display: Buttons inside a table would incorrectly be grayed out when scrolling \[ID_33641\]

When scrolling through a table of which the rows contained buttons, in some cases, those buttons would incorrectly be grayed out.

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed \[ID_33650\]

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### Monitoring app: Trend graph of table column parameter not displayed when table row index contained forward slash \[ID_33661\]

In the Monitoring app, the trend graph of a table column parameter would not be displayed when the table row index contained a forward slash.

#### Dashboards app: No longer possible to select a built-in theme as default theme \[ID_33665\]

In the Dashboards app, it would no longer be possible to select a built-in dashboard theme as default theme.

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

#### Run-time errors due to MessageBrokerReconnectThread problems in SLCloudBridge \[ID_33716\]

In some cases, run-time errors could occur due to MessageBrokerReconnectThread problems in the SLCloudBridge process.

#### DataMiner Cube - Spectrum Analysis: Problem with 'Next trace' button and slider after a spectrum recording had been paused \[ID_33718\]

When you had paused the replay of a spectrum recording, in some cases, the “next trace” button and the slider would not work correctly.

#### DataMiner Cube: SLAnalytics would start to consume an excessive amount of memory when you opened a card of an element with parameters that had only average trending enabled [ID_33741]

<!-- MR 10.3.0 - FR 10.2.8 -->
<!-- Not added to MR 10.3.0 -->

When you opened a card of an element with parameters that had only average trending enabled, in some cases, the SLAnalytics process would start to consume an excessive amount of memory.

#### Service & Resource Management: Changes to resource pools would incorrectly not be saved in the Resources.xml file \[ID_33743\]

On standalone DataMiner Agents, changes to resource pools would incorrectly not be saved in the Resources.xml file.

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

#### Problem when processing a history set with a timestamp referring to a moment far in the past \[ID_33774\]

When SLElement was processing a history set, an error could occur when the timestamp of that history set referred to a moment far in the past.

#### Failover: Problem with AlwaysBruteForceOffline option \[ID_33775\]

The following problems with the Failover option *AlwaysBruteForceOffline* have now been fixed:

- When configured via an UpdateFailoverConfigMessage in an Automation script, the option would not be applied in the DMS.xml file.
- When configured by manually updating the DMS.xml file, the option would be overwritten.
- When applied, the option would cause the DMA to restart without also restarting SLNet.

> [!NOTE]
> In DataMiner Cube, the *AlwaysBruteForceOffline* option can now be configured by enabling or disabling the *Auto restart agent when going offline* option in the *Advanced options* tab of the *Advanced Failover Configuration* window.

#### SLDataGateway: Problem when no NATS connection could be established at DataMiner startup \[ID_33779\]

At DataMiner startup, in some rare cases, an error could occur in the SLDataGateway process when no NATS connection could be established.

#### DataMiner Cube - System Center: Enforcing a client version would not work \[ID_33802\]

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions* and force users to always use a particular Cube version. In some cases, this would not work. The following error message would appear: “Error: file already exists but has incorrect size”.

#### Dashboards app: Options displayed in component headers would not be readable when a dark theme was applied \[ID_33805\]

When a dark theme was applied, options displayed in the header of certain dashboard components (e.g. “Export to CSV”) would not be readable.

#### Cassandra Cluster Migrator tool: Problem when migrating a large amount of data \[ID_33821\]

When the Cassandra Cluster Migrator tool was migrating a large amount of data, in some cases, an out of memory exception could be thrown.

#### Dashboards app - Table component: Previous selection would incorrectly not be cleared when hidden during a search \[ID_33828\]

In a table component, the previous selection would incorrectly not be cleared when it was hidden during a search. From now on, the hidden selected item will be cleared when a new selection is made.

#### Problem with SLDataGateway while a DataMiner Agent was being shut down \[ID_33839\]

When a DataMiner Agent was being shut down, in some cases, an error could occur in the SLDataGateway process.

#### SNMP: Former value of updated cell would incorrectly be returned the first time the table was polled after the update \[ID_33855\]

When a cell in a table with “pollingrate” enabled had been updated, the first time the table was polled after the update, the former value of that cell would incorrectly be returned.

#### DataMiner upgrade: VerifyNatsRunning prerequisite could fail due to SLCloudBridge.dll having been renamed \[ID_33875\]

<!-- MR 10.3.0 - FR 10.2.8 [CU0] -->
<!-- Also added to MR 10.2.0 [CU13] -->

During a DataMiner upgrade, the *VerifyNatsRunning* prerequisite could fail due to the *SLCloudBridge.dll* file having been renamed to *SLMessageBroker.dll* in DataMiner versions 10.2.0/10.1.5.

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

## Addendum CU1

### CU1 enhancements

#### Size of the WebSocket messages sent from SLPort to SLProtocol will now be limited to 1024 packets [ID_34049]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU1] -->

In order to prevent SLPort from running out of memory, from now on, the size of the WebSocket messages sent from SLPort to SLProtocol will be limited to 1024 packets.

## Addendum CU2

### CU2 Fixes

#### SLAnalytics RTEs after upgrading DMS with Cassandra Cluster \[ID_34180]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU2] -->

After a DMS with a Cassandra Cluster setup was upgraded to 10.2.8 (CU1), it could occur that the Alarm Console showed run-time errors related to the SLAnalytics process. This was caused by an upgrade action that was not triggered for such a setup.

#### Problem in SLElement when element was dynamically included in service multiple times with partially included parameter set [ID_34185]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU2] -->

When an element was dynamically included in a service multiple times with a partially included parameter set, a problem could occur in SLElement while parsing the information received from SLDataMiner.
