---
uid: General_Feature_Release_10.1.7
---

# General Feature Release 10.1.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### EPM: Aliases for topology cells, chains and search chains can now be specified in EPMConfig.xml \[ID_29766\]\[ID_29841\]

In an EPM environment, it is now possible to override the names of topology cells, chains, and search chains specified in a protocol with aliases specified in a separate file.

In the C:\\Skyline DataMiner\\ folder, create an *EPMConfig.xml* file that contains a \<Topologies> and/or \<Chains> configuration identical to the one in the protocol, and specify the necessary aliases in override attributes. See the following example.

```xml
<Protocol>
  <Topologies>
    <Topology name="" override="CustomChainName">
      <Cell name="CM" override="Cable Modem"/>
      <Cell name="OLT" override="Hub"/>
      <Cell name="Street" override="CustomStreet"/>
    </Topology>
    ...
  </Topologies>
  <Chains>
    <Chain name="OLT (Limited)" override="Full OLT">
      <Field name="Network" override="Mesh"/>
    </Chain>
    ...
    <SearchChain name="search">
      <Tabs>
        <Tab name="STB" override="Box">
          <Field name="Customer ID" override="User ID"/>
        </Tab>
      </Tabs>
    </SearchChain>
    ...
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - If you want the aliases to be applied on every DMA in a DMS, then make sure every DMA contains a copy of the same *EPMConfig.xml* file.
> - When you update the *EPMConfig.xml* file on a particular DMA, then delete the \*.txf files on that DMA and restart DataMiner.
> - Currently, the *EPMConfig.xml* file is only read at DataMiner startup.

#### SLSpectrum: Refactoring of code used to play back spectrum recordings \[ID_29785\]

In SLSpectrum, the code used to play back spectrum recordings has been refactored.

Also, the SpectrumManagerHelper now allows to play, pause, slow-forward and fast-forward a recording. See the following table.

| Action       | Instruction                                                            |
|--------------|------------------------------------------------------------------------|
| Pause        | Helper.SetSpectrumRecordingSpeed(0.0)                                  |
| Play         | Helper.SetSpectrumRecordingSpeed(1.0)                                  |
| Slow-forward | Helper.SetSpectrumRecordingSpeed(0.5)<br> (any number between 0 and 1) |
| Fast-forward | Helper.SetSpectrumRecordingSpeed(2.0)<br> (any number greater than 1)  |

#### New spectrum recording playback controls \[ID_29807\]\[ID_29926\]

While a spectrum trace recording is playing, new controls are now available at the bottom of the display section:

- A slider control, which allows you to navigate to a specific point in the recording.
- Controls to go forward and backward in the recording, trace by trace.
- A pause/play toggle control.
- A fast forward button. The current playback speed is displayed next to this button. You can click the fast forward button again to increase the playback speed further.

While a recording is playing, these controls (with exception of the slider control) will fade away to show as much of the recording as possible. Moving the mouse pointer near the controls will display them again. The name, the start time and the end time of the recording are also displayed at the bottom of the display section, and fade away in the same way as the controls.

Because of these new controls, the *Manual* playback mode is now obsolete. You can therefore now only select the play modes *Play once* or *Loop*.

The following *SpectrumManagerHelper* methods have been implemented to support this:

- *SetSpectrumRecordingFrame (int frame)*: Sets the frame of the currently playing recording to the next available trace in the recording, starting from the given frame number.
- *SetSpectrumRecordingTime (TimeSpan time)*: Sets the currently playing recording to a specific point in time. The specified time span indicates the amount of time after the start of the recording where the playback should go.

### DMS Security

#### New functions user permissions \[ID_29659\] \[ID_30114\] \[ID_30122\]

Under *Modules* > *Functions*, you can now find the following user permissions:

- Read
- Add
- Edit
- Delete
- Configure
- Generate protocol

These permissions apply to the upload and delete function options in the Protocols and Templates app, as well as to the Functions app, which is currently only available in soft launch. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

When upgrading to DataMiner version 10.1.7, these six permissions will automatically be granted to all user groups that have been granted the *Modules \> Resources \> Configure functions* permission.

### DMS Cube

#### Visual Overview: New icon added to Icons stencils \[ID_29751\]

The following icon has been added to the Icons stencil:

- TX

#### Logging: New log file 'Resource Manager Storage' \[ID_29776\]

The Logging module now also allows you to access to SLResourceManagerStorage.txt log file.

#### EPM: Topology diagram will now display the topology cell name instead of the table name \[ID_29842\]

An EPM topology diagram will now display the topology cell name instead of the table name.

Also, table names can now be overridden in the information template. If names of column parameters contain the table name, it is advised to also override these names in order to avoid confusion.

#### Generating a report based on a dashboard: New 'Include CSV' option \[ID_29933\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app. When you click the *Configure* button, you will now notice a new “Include CSV” option. If you select this option, the email will not only include the report but also a zip file containing a CSV file for every Pivot table, GQI table and Line & area chart component in the dashboard.

### DMS Reports & Dashboards

#### Dashboards app: State component can now be used as GQI data feed by other components \[ID_29708\]

The State component can now be used as GQI data feed by other components.

In other words, components using a State component as a feed will now be able to ingest GQI data selected in that State component.

#### Dashboards app: New Progress bar component \[ID_29773\]

A new *Progress bar* component is now available among the state components in the Dashboards app. It can be used to display the value of an analog parameter as a progress bar.

In the *Layout* tab for this component you can select to hide or display various labels, such as the parameter name and value. You can also select whether the minimum and/or maximum value of the parameter should be displayed. Similar to other state components, you can also select a small or large design and, in case the component is used to display multiple parameters, you can select whether the parameters should be displayed in rows or columns.

In the *Settings* tab, you can specify a custom minimum and/or maximum value.

#### Dashboards app - GQI: Fetching query results page by page \[29801\]\[29858\]\[29898\]

GQI query results can now be fetched page by page.

Before executing a query, the system will send a GenIfOpenSessionRequest message to open a session. That request will return a session ID that then has to be passed along with a series of GenIfNextPageRequest messages to fetch the next pages. Finally, a GenIfCloseSessionRequest message will be sent to close the session.

> [!NOTE]
>
> - A new session must be opened for each query that has to be executed.
> - When a session is opened/used, a timestamp will be added/updated. This timestamp will be used to check whether a session has expired. Sessions can be kept alive by sending a GenIfSessionHeartbeatRequest message.

##### Overview of the request messages

- **GenIfOpenSessionRequest**: Opens a session.

  Properties:

  - Query
  - QueryOptions

- **GenIfNextPageRequest**: Fetches the next page.

  Properties:

  - SessionID (Guid)
  - PageSize (int)

- **GenIfCloseSessionRequest**: Closes a session.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfSessionHeartbeatRequest**: Prevents a session from expiring.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfGetOpenSessionsRequest**: Returns a response containing a list of all open sessions, together with the following properties:

  - SessionID (Guid)
  - CreationTime
  - LastUpdated

##### Variables

| Variable                                                                                   | Default value    |
|--------------------------------------------------------------------------------------------|------------------|
| Maximum concurrent sessions                                                                | 500              |
| Time before a session is expired (without receiving heartbeat/update for that session) | 5 minutes        |
| Internal check cycle if a session is expired                                               | Every 30 seconds |
| Minimum pageSize (rows)                                                                    | 1                |
| Maximum pageSize (rows)                                                                    | 2000             |

#### Dashboards app - GQI: Linking columns with values of type double or datetime to feeds in query filters \[ID_29902\]

In GQI query filters, from now on, columns containing values of type datetime or double can be linked to feeds. This will allows you to e.g. filter a bookings list by linking the *End* column to a time range feed.

### DMS Mobile apps

#### Dashboards/Monitoring: EPM components now fully aligned \[ID_29770\]

The EPM component of the Dashboards app and the Monitoring app are now fully aligned.

Also, the EPM component of the Dashboards app now allows using quick chains.

### DMS Service & Resource Management

#### Binding a VirtualFunctionResource using the primary key \[ID_29648\]

It is now also possible to bind a VirtualFunctionResource using the primary key of an EntryPointTable.

> [!NOTE]
> Binding two resources to the same row, one using the display key and one using the primary key, is not supported and will return a TargetAlreadyBound error.

#### Generating contributing functions for service definitions that use mediated virtual functions on one of more nodes \[ID_29752\]

It is now possible to generate contributing functions for service definitions that use a mediated virtual function on one or more nodes.

> [!NOTE]
>
> - For the replication to work, the profile parameter used to generate the parameter in the contributing protocol needs to contain a ProtocolParameterReference to the parameter in the protocol of the VirtualFunctionDefinition.
> - If a service definition node has both the VirtualFunctionID property (to use a mediated virtual function) and the FunctionID property (to use a protocol function) filled in, the VirtualFunctionID will be used during generation.
> - Only the profile definition of the VirtualFunctionDefinition’s VirtualNode will be taken into account when creating parameters.

#### SRM events can now be forwarded as ProtoBuf events on the NATS bus \[ID_29821\]

When an SRM object is created, updated or deleted, an event message is sent via the SLNet subscription system to notify everyone. The NATS forwarding logic also receives these event messages and will now publish a ProtoBuf event on the NATS bus each time it receives such a message.

##### Proto files

The ProtoBuf event messages are defined by ProtoBuf files, which can be obtained on request.

The events themselves are defined in the API protos, which import shared messages from the main shared folder.

##### Subscribing to the NATS event messages

To subscribe to one of the event messages you will need to compile the required proto files. In general, you need to compile the API proto of the event and the complete shared folder. For example, when you want to subscribe to the ReservationInstanceEvent, you need to compile the reservation_instance_api.proto file and everything in the general shared folder.

Alternatively, instead of compiling those files yourself, you can also add copies of those files to your project and include the Protobuf NuGet package. The package will then compile them for you.

When you have the compiled .cs file, you can subscribe to the messages as shown in the following C# code example.

```csharp
private void Run(Engine engine)
{
    // Create the message broker
    var broker = SLMessageBrokerFactorySingleton.Instance.Create();
    // Subscribe to the ReservationInstanceEvent
    var topic = "Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent";
    broker.Subscribe(topic).WithHandler(Handler);
}
private void Handler(object sender, HandlerEventArgs e)
{
    // Parse the message
    var message = ReservationInstanceEvent.Parser.ParseFrom(e.Data);
    // Do something with the event message...
}
```

##### Errors

When an SRM event is sent out, in some cases, it cannot be forwarded to NATS due to issues related to the SLMessageBroker. In that case, an error will be logged in the SLResourceManager.txt file, stating that an event could not be forwarded.

Note that no retries will occur and that no messages will be queued.

##### Supported events

- ResourceManagerEventMessage

    When a ResourceManagerEventMessage contains multiple types of objects, it will be split up into multiple proto events. When the ResourceManager sends out one ResourceManagerEvent containing e.g. 2 ReservationInstances and 3 Resources, the forwarder logic will publish one ReservationInstanceEvent (with the 2 objects) and one ResourceEvent (with the 3 objects).

##### ReservationInstance object

| Event message name       | Proto file                     | NATS Topic                                                                              |
|--------------------------|--------------------------------|-----------------------------------------------------------------------------------------|
| ReservationInstanceEvent | reservation_instance_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent |

##### Resource object

| Event message name | Proto file         | NATS Topic                                                        |
|--------------------|--------------------|-------------------------------------------------------------------|
| ResourceEvent      | resource_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.Resource.Api.v1.ResourceEvent |

#### Returning all available capacities when requesting the eligible resources \[ID_29939\]

When you request the eligible resources, it is now possible to calculate all remaining capacities on the resources instead of only the requested ones.

To enable this feature, set the CalculateAllCapacities flag of the EligibleResourceContext to true.

Example:

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        // We assume there is a resource named 'resourceWithCapacityTwoCapacities'
        var context = new EligibleResourceContext())
        {
            RequiredCapacities =
            {
                new MultiResourceCapacityUsage(firstCapacityId, 200.0m)
            },
            CalculateAllCapacities = true
        };
        var result = resourceManagerHelper.GetEligibleResources(context);
        var usageDetails = result.UsageDetails.FirstOrDefault(d => d.ResourceId == resourceWithCapacityTwoCapacities.GUID);
        var firstCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == firstCapacityId).CapacityLeft;
        // Without the 'CalculateAllCapacities' flag this would not be in the result
        var secondCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == secondCapacityId).CapacityLeft;
    }
}
```

## Changes

### Enhancements

#### Security enhancements \[ID_29724\]\[ID_29848\]\[ID_29883\]\[ID_29887\]\[ID_29889\]

A number of security enhancements have been made.

#### Trending: Trend values will now be rounded after being retrieved from the database \[ID_28840\] \[29758\]

Up to now, trend data values were rounded before being stored in the database. From now on, those values will only be rounded after being retrieved from the database, i.e. before being returned to the client.

#### Dashboards app: Enhanced overflow detection when generating PDF reports \[ID_28985\]

Due to a number of enhancements, overflow detection has improved when generating PDF reports.

#### DataMiner Cube - Trending: Trend legend enhancements \[ID_29477\]

A number of enhancements have been made to the trend legend:

- The trace and current values will now have tool tips. Hovering over one of those tool tips will reveal the full value, and when there is insufficient space the value will be ellipsed.
- Trace values will no longer have trailing zeros cut off when that precision is available, which will improve readability.
- The current values will have a thousand separator where necessary.

#### SLWatchdog: Notification enhancements \[ID_29697\]

A number of enhancements have been made with regard to notifications generated by the SLWatchDog process.

#### 'Number of backups to keep' setting will now also apply to the number of Elasticsearch backups \[ID_29702\]

In the *Backup* section of *System Center*, you can indicate the number of backups that have to be kept on disk. This setting will now also apply to the number of Elasticsearch backups.

> [!NOTE]
> Whether DataMiner will be able to delete older Elasticsearch backups stored on a network path will depend on the permissions granted to the account used to access that path.

#### Mobile Gateway: Enhanced performance when sending text messages \[ID_29729\]

Due to a number of enhancements, overall performance has increased when sending text messages.

#### DataMiner Cube - ListView component: Enhancements \[ID_29761\]

A number of enhancements have been made to the ListView component, especially with regard to list updates after rows were added, updated or removed.

#### DataMiner Cube: 'Not applicable' replaced by 'N/A' when displaying alarm statistics while the alarm storm protection mode is active \[ID_29771\]

When, in Visual Overview or the Surveyor, alarm statistics were displayed while the alarm storm protection mode was active, up to now, the number of alarms would be replaced by “Not applicable”. From now on, the number of alarms will be replaced by “N/A” instead of “Not applicable”.

#### Inter-DMA communication: Enhanced automatic HTTP port detection \[ID_29834\]

Up to now, when port 80 (HTTP) was unavailable between DataMiner Agents, connections between the DataMiner Agent modules on the different servers would only work after the ConnectTimeout setting had been increased. From now on, when auto-detecting the target port (via port 80 or 443) fails, the connection attempt will continue on default port 8004.

Also, a number of additional options were added to the connection string configuration (SLNetClientTest \> Advanced \> Edit Connection Strings):

- The “To” field can now contain wildcards (\* or ?). If there is no exact match, the settings of the record in question will then apply to all matching destinations. If more than one wildcard entry matches a destination, the behavior is undefined.
- The connection string can now be set to “auto://nodetect” in order to skip the auto-detection of the target SLNet port and automatically default to 8004. When port 80 is blocked between agents, the 15-second autodetection timeout will then be skipped.

#### Ongoing spectrum recording will now automatically be saved when the session is closed \[ID_29843\]

When a spectrum session is closed while a recording is in progress, from now on, the recording will automatically be saved to the user’s folder in C:\\Skyline DataMiner\\Users.

#### DataMiner Cube - Bookings app: Enhanced performance of the bookings timeline \[ID_29876\]

Due to a number of enhancements, overall performance of the bookings timeline has been increased.

#### LogCollector: Enhanced handling of long file paths \[ID_29910\]

When, during the creation of a dump file, SLLogCollector encountered a file of which the path was longer than 256 characters, up to now, an error would be thrown and the entire dump operation would fail. From now on, when SLLogCollector encounters a file of which the path was longer than 256 characters, it will exclude that file, and continue creating the dump file.

Also, when in the registry of a Windows 10 version 1607 or above the LongPathsEnabled option is set to 1 in Computer\\HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\FileSystem, SLLogCollector will now accept file paths that are longer than 256 characters.

#### Additional logging for actions in SRM modules \[ID_29924\]

Additional information will now be logged in the SLClient.txt log file for the following SRM modules:

- Functions (currently only available in soft launch)
- Profiles
- Services
- Resources
- Bookings

The following information will be logged

- The time when a module has been launched by a user.
- The time that is needed to load a module after it is launched, including the initialization, the fetching of data from the server, and the creation of module data.
- The duration of each server call, including the message, the interval, and the filter used in the request, if any. The following server calls are taken into account for this:

  - Resource helper: Retrieving a resource, resource pool, booking definition, or booking instance.
  - Service helper: Retrieving a service definition, service state, or information.
  - Function helper: Retrieving a virtual function, or protocol metadata.

#### SLManagedAutomation: Locking mechanism will now prevent exceptions from being thrown when reading or writing items in the dummies collection \[ID_29930\]

In an Automation script, every Engine object contains a collection of “dummies”. Each of these dummies represents an element and can be used to interact with that element. When an Automation script wants to interact with an element that is not yet available in the dummies collection, a new dummy is created.

Up to now, exceptions could be thrown when multiple threads were trying to read or write items in the dummies collection. Now, a locking mechanism has been added to prevent multiple threads from interfering with each other while accessing the dummies collection.

#### SLSNMPManager: Enhanced logging \[ID_29935\]

In order to determine the root causes of certain SNMP-related issues, the SLSNMPManager error logging has been enhanced.

This enhanced logging will especially be helpful when investigating the “Unable to set the destination IP” error.

#### SLElement: Enhanced memory usage when processing service impact data \[ID_29948\]

Due to a number of enhancements, overall memory usage of SLElement has increased, especially when processing service impact data.

Also, a small memory leak was fixed in elements contained within services.

#### New BPA tests added to default test set \[ID_30010\]

The following new BPA tests have been added to the default test set:

- Minimum Requirements Check
- Report Active RTE
- View Recursion

#### Enhanced performance when updating user information \[ID_30102\]

Due to a number of enhancements, overall performance has increased when updating user information, especially on systems with a large number of users.

### Fixes

#### Service & Resource Management: Problem when trying to retrieve a resource with status 'Maintenance' or 'Unavailable' \[ID_29511\]

Due to a serialization issue involving the AvailableTo and AvailableFrom properties of the GetResourceMessage, in some cases, it would not be possible to retrieve a resource with status “Maintenance” or “Unavailable”.

#### Dashboards app: Group component would incorrectly not show all included components \[ID_29630\]

In some cases, a Group component would incorrectly not show all included components. The components that were not shown had no height defined or an error had prevented the styling from being applied correctly.

#### Problem when using GetPropertyValueMessage to request properties from an element or service hosted on a DMA other than the one to which you were connected \[ID_29655\]

When GetPropertyValueMessage was used to request properties from an element or service that was hosted on a DataMiner Agent other than the one to which you were connected, in some cases, no response would be returned.

#### SLAnalytics - Alarm focus: Alarms would incorrectly be treated as unexpected when baseline values in an alarm template were updated automatically due to the use of smart baselines \[ID_29670\]

When a user makes a change to an alarm template, SLAnalytics will treat all alarms of the parameters for which a change was implemented in the alarm template as unexpected. However, in some cases, it would incorrectly act in a similar way when, in case of smart baselines, baseline values were updated automatically.

Also, in some cases, no action would be taken when, in case of smart baselines, alarm template settings of table parameters were changed.

#### Problem with Surveyor setting 'Collapse DVE elements beneath their main element' \[ID_29696\] \[29742\]

When the Surveyor setting “Collapse DVE elements beneath their main element” was enabled, newly created DVE children would incorrectly not appear beneath their DVE parent in the Surveyor. Only after a reconnect would they appear.

#### DataMiner Cube - Trending: Color icons missing from trend graph legend \[ID_29718\]

When you opened a trend group with several graphs, in some rare cases, color icons would be missing from the trend graph legend.

#### Interactive Automation scripts: Problem when entering double-digit numbers in input controls \[ID_29736\]

In some cases, due to a problem with the WantsOnChange functionality, it would not be possible to enter a double-digit number (e.g. a number of minutes) in an input control. The interactive Automation script would incorrectly already continue after you entered the first digit.

#### Manually clearing a clearable alarm on a single-value parameter would incorrectly set the alarm state of the parameter to 'undefined' instead of 'normal' \[ID_29745\]

When you manually cleared a clearable alarm on a single-value parameter, the alarm state of the parameter would incorrectly be set to “undefined” instead of “normal”.

#### DataMiner.xml: \<NetworkAdapters> tag not correctly applied when a network adapter did not have a current IP address assigned \[ID_29759\]

In the DataMiner.xml file, you can use the \<NetworkAdapters> tag to override the order of the network adapters on a DataMiner Agent.

Up to now, when one of the adapters had an IP address defined in the Windows Registry but had no current IP address assigned, in some cases, an incorrect order could get applied in DataMiner.

#### SLSpectrum would no longer properly clean up client connections \[ID_29769\]

In some cases, the SLSpectrum process would no longer properly clean up client connections. As a result, its overall performance would decrease each time a client had made a connection.

#### DataMiner Cube - Alarm templates: Problem with overlapping time frames when the end time of a schedule entry was set to midnight \[ID_29772\]

When configuring schedules in alarm templates, in some cases, entries could have overlapping time frames, especially when the end time of one of those entries was set to midnight.

#### DataMiner Cube - Visual Overview: Field and FieldID placeholders could not be used by a Visio file assigned to a view enhanced with EPM data \[ID_29790\]

When a view was enhanced with EPM data and had a Visio file assigned to it, in some cases, the Visio file assigned to that view would not be able to use the Field and FieldID placeholders.

#### Problem with SLDataMiner when importing domain users and user groups from an Azure Active Directory \[ID_29804\]

In some cases, an error would occur in SLDataMiner when an empty response was received after trying to import domain users and user groups from an Azure Active Directory.

#### DataMiner Cube: Problem when pressing the Back button during logon \[ID_29808\]

When you pressed the Back button while logging on, in some cases, an error could occur in the logon screen, forcing you to restart Cube.

#### Problem when an interactive Automaton script was detached on closure \[ID_29815\]

In some cases, when an interactive Automation script detached on closure, an exception could be thrown in SLAutomation. From now on, interactive Automation scripts will only detach when they are aborted by a user either closing the pop-up window or clicking the *Abort* button.

#### Monitoring app: Service child pop-up pages without parent page could not be opened \[ID_29816\]

When, for an element included in a service, only parameters from one of its pop-up pages were included and none of that pop-up page’s parent page, then that parent page would not be included in the service and there would be no way to access the pop-up page. From now on, in cases like this one, pop-up pages of service children will be added to the Monitoring app’s side panel after all other pages.

#### Legacy Reporter app: Problem when trying to display a trend graph for a table column parameter \[ID_29818\]

When the legacy Reporter app had to display a trend graph for a table column parameter, in some cases, a “no trend graph is available” message would incorrectly appear instead, especially when that table column parameter had both average and real-time trending enabled on certain rows.

#### DataMiner Cube: Problem with SLSpectrum when closing a spectrum element card \[ID_29824\]

In some cases, an error could occur in SLSpectrum when you closed a spectrum element card.

#### Not all references to child elements were removed from the original DMA after a DELT migration of main DVE elements \[ID_29831\]

After a DELT migration of main DVE elements from one DMA to another, in some cases, not all references to the child elements would be removed from the original DMA.

#### SLDataGateway: Problem when creating a job queue \[ID_29837\]

In some rare cases, SLDataGateway would throw a null reference exception when creating a job queue.

#### DataMiner Cube - Visual Overview: Problem when opening a visual overview that contained a filtered table \[ID_29846\]

In some cases, DataMiner could become unresponsive when you opened a visual overview that contained a filtered table.

#### Mobile apps: Selection box values would be ellipsed even when there was ample space to fully display them \[ID_29850\]

In the mobile apps (e.g. Jobs, Ticketing, etc.), in some cases, selection box values would be ellipsed even when there was ample space to fully display them.

#### SLAnalytics - Automatic incident tracking: IDP location updates would not be taken into account \[ID_29852\]

In some cases, an IDP location update for a particular element would not be taken into account. As a result, alarms active at the time of the update could be grouped incorrectly.

#### DataMiner Cube - Trending: 'Exclude gaps' option would not work when exporting average trend data \[ID_29870\]

When you exported average trend data to a CSV file with the *Exclude gaps* option enabled, the gaps would incorrectly not be excluded.

#### Masking monitored column parameters that were not in an alarm state would not cause them to get marked as being masked \[ID_29871\]

When you masked a monitored column parameter that was not in an alarm state, it would incorrectly not get marked as being masked.

#### Service & Resource Management: Start of bookings could incorrectly be delayed when multiple bookings started at the same time \[ID_29880\]

When multiple bookings started at the same time, and each of those bookings required function DVE elements to be enabled, in some cases, the start of the bookings would be delayed.

#### DataMiner Cube: Problem when opening the Services app \[ID_29884\]

In some cases, opening the Services app could take a long time due to a problem while loading the SRM icons.

#### Dashboards - Table component: Problem with scroll bars when using Firefox \[ID_29892\]

When using Mozilla Firefox, the table component would should scroll bars even in situations where it was not necessary.

Also, in some cases, columns would not resize correctly.

#### Problem when notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING (448) was used in a QAction that was triggered by an 'after startup' trigger \[ID_29893\]

When the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING (448) was used in a QAction that was triggered by an “after startup” trigger, in some rare cases, the bit rate tracking would not get enabled because SLSNMPManager was not yet aware of the element in question. Also, due to a code issue, a lock would incorrectly not get released, causing the following run-time error to occur in the ProtocolThread:

```txt
Thread problem in SLProtocol.exe: [Protocol Name/Protocol Version] Element Name - ProtocolThread
```

#### Dashboards app - GQI: Raw values would incorrectly be displayed when grouping row after performing an aggregation \[ID_29904\]

When rows were grouped after performing an aggregation, raw values would incorrectly be displayed instead of display values.

#### SLNetClientTest tool: GetAlarmDetailsFromDbMessage missing from message list \[ID_29905\]

In the *Build Message* tab of the SLNetClientTest tool, it would no longer be possible to select the GetAlarmDetailsFromDbMessage in the *Message Type* box.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Dashboards app - GQI: Problem when applying a filter to a query that used a 'Get parameters for element where' data source \[ID_29907\]

When a filter was applied to a query that used a “Get parameters for element where” data source, in some cases, the filter would incorrectly only get applied to the rows of one element. The rows of the other elements would all be returned, whether they matched the filter or not.

#### Dashboards app - PDF reports: Toggling the 'Include feeds' option would disable the 'Create' button \[ID_29920\]

When, in the PDF preview window, you toggled the *Include feeds* option multiple times in a row, in some cases, the *Create* button would get disabled.

#### Dashboards app - GQI: Edit pane could become unresponsive when importing a query from one dashboard into another \[ID_29922\]

When you imported a query from one dashboard into another dashboard, in some cases, the edit pane could become unresponsive due to a parsing error.

#### SLAnalytics: Memory spikes when requesting trend predictions \[ID_29925\]\[ID_29983\]

In some cases, large memory spikes would occur in the SLAnalytics process when requesting trend predictions for parameters with a small polling interval that did not receive regular (non-exception) parameter value updates in the real-time trend data history.

#### DataMiner Cube - Alarm Console: Problem with automatic removal of information events \[ID_29928\]

Due to a problem with the mechanism that automatically removes information events from the *Information events* tab page, in some cases, DataMiner Cube could become unresponsive when too many information events were being received.

#### Failover: Problem with SLNet during DataMiner startup \[ID_29950\]

On a Failover system, in some rare cases, an error could occur in SLNet during DataMiner startup, causing the following run-time error in SLDMS:

```txt
THREAD PROBLEM : SLDMS.exe - ConnectionThread [pid 99999 - thread 99999]
```

#### Problem when multiple threads simultaneously created the serializer when ReservationInstances had to be serialized \[ID_30013\]

In some rare cases, a ProtoBufSerializationException could be thrown when multiple threads simultaneously created the serializer when ReservationInstances had to be serialized using protocol buffer serialization.

#### DataMiner Cube - Bookings app: Memory leak in bookings list \[ID_30048\]

When an item was removed from the bookings list, it could occur that the item was not removed from memory.

#### DataMiner Cube - Services app: Profile parameters not displayed when clicking a node of a service definition \[ID_30059\]

When, in the Services app, you clicked a node of the service definition, in some cases, the profile parameters would not be displayed. Also, it would not be possible to select a profile instance for that node.

#### Problem when masking DVE elements containing table parameters \[ID_30084\]

When an element is masked, DataMiner will mask all parameters of that element. Table parameters will be masked as a whole, meaning that column parameters will not be masked individually. However, in case of DVE elements, a column parameter can be exported as a separate, standalone DVE parameter. So, here, a column parameter can be masked individually as the rest of the table is not part of the DVE element.

Up to now, when an entire table had been exported to a DVE element, and that DVE element was masked, then DataMiner would incorrectly mask the table as a whole as well as each column individually, leading to double masking.

From now on, when an entire table was exported to a DVE element, the column parameters will no longer be masked individually. The default table masking procedure will be applied.

#### MySQL and SQL Server databases: ExtraStatusId field was incorrectly added to the info table \[ID_30096\]

On MySQL and Microsoft SQL Server databases, since DataMiner version 10.1.6 the info table would incorrectly contain an *ExtraStatusId* field. As a result, on systems with a MySQL database (on which the STRICT option was set to true) or a Microsoft SQL Server database, it was no longer possible to store information events.

#### DataMiner Cube - Alarm Console: Problem when using the history slider \[ID_30097\]

On systems with a MySQL database, in some cases, a System.AggregateException would be thrown when using the history slider in DataMiner Cube.

#### Problem with SLNet during upgrade \[ID_30103\]

During a DataMiner upgrade, in some rare cases, a problem could occur in the cleanup connection thread of SLNet.

#### Resources and Services modules also loaded functions that were not active \[ID_30107\]

In the Resources and Services modules, it could occur that functions were loaded even though they were not marked as active, which could cause several functions with the same GUID to be loaded.

#### DataMiner Cube - Automation: No longer possible to attach an Automation script to a user session \[ID_30125\]

In some cases, it would no longer be possible to attach an Automation script to a user session.
