---
uid: General_Feature_Release_10.2.5
---

# General Feature Release 10.2.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### DataMiner Object Model: New event message for DomInstance status transitions \[ID_32418\]

With the introduction of the DomInstanceStatusChangedEventMessage, it is now possible to subscribe to DomInstance status transitions. This message contains the DomInstanceId, the FromState, the ToState and the Username (i.e. the name of the user who changed the status).

IModuleEvents are now filtered by IModuleEventSubscriptionFilter first, before any other filter is applied.

#### Elasticsearch: Casing will now be ignored when sorting fields of type string \[ID_32437\]

From now on, Elasticsearch will ignore casing when sorting fields of type string.

#### Running memory-intensive elements in separate SLProtocol and SLScripting instances \[ID_32742\] \[ID_32917\]

As some element protocols have QActions that require a large amount of memory to execute, they can cause SLScripting to run out of memory when they run together with other elements. From now on, elements that require a large amount of memory can be run in their own SLProtocol and SLScripting instance.

In *DataMiner.xml*, the \<ProcessOptions> element can now contain a \<SeparateProcesses> element listing all element protocols that have to be run in a separate SLProtocol and SLScripting instance. See the example below.

When a protocol is flagged to run in separate instances, every element using that protocol will be started in a new instance of SLProtocol and SLScripting. When the element is stopped, these instances are taken down again, and when the element restarts, new instances are created.

Example:

```xml
<DataMiner>
  ...
  <ProcessOptions protocolProcesses="3" scriptingProcesses="protocol">
    <SeparateProcesses>
      <Protocols>
        <Protocol>
          <Name>MyElementProtocol</Name>
        </Protocol>
      </Protocols>
    </SeparateProcesses>
  </ProcessOptions>
  ...
</DataMiner>
```

> [!NOTE]
>
> - It is recommended to stop the DataMiner Agent before changing its *DataMiner.xml* file. Besides, any changes made to the *DataMiner.xml* will only be applied when starting the DataMiner Agent..
> - Using the protocolProcesses option, you can specify how many SLProtocol processes will be launched to host the other elements in.
> - Currently, a separate SLScripting process must be launched for every SLProtocol process. This means that when at least one protocol name is specified in the SeparateProcesses tag, the configured or default behavior of the scriptingProcesses attribute will be overridden to “protocol”. Note that when the scriptingProcesses attribute is set to “\[Service\]”, the following system notice will be generated.
>
>   *\[n\] separate protocols have been configured in the DataMiner.xml, while SLScripting is configured as service, which is not a compatible setup. To run the elements of these protocols in a separate SLProtocol and SLScripting instance, please unregister SLScripting and remove the scriptingProcesses=\\"\[Service\]\\" tag from DataMiner.xml.*
>
> - *DataMiner.xml* files are not synchronized among the different Agents in a DataMiner System. If your DMS includes different Agents, then you will need to edit the *DataMiner.xml* file on each of the Agents.

#### DataMiner Object Model: FieldDescriptors of type DomInstanceValueFieldDescriptor can now be configured to allow multiple values \[ID_32904\]

From now on, FieldDescriptors of type DomInstanceValueFieldDescriptor can be configured to allow multiple values.

### DMS Security

#### SLSSH: Enhanced HMAC support \[ID_32786\]

DataMiner now supports the following HMAC algorithms when setting up a connection with an SSH server (in order of preference):

- HMAC-SHA2-512 (new)
- HMAC-SHA2-256
- HMAC-SHA1
- HMAC-MD5

### DMS Protocols

#### NT_UPDATE_DESCRIPTION_XML (127) now supports overriding parameter units \[ID_32891\]

Using NT_UPDATE_DESCRIPTION_XML (127), it is now possible to override parameter units.

#### New \<ProcessAutomation> element to pass parameter values to the Service Definition component of the Dashboards app \[ID_32910\]

The new \<ProcessAutomation> element allows you to pass parameter values to the Service Definition component of the Dashboards app.

See the example below. For every value you want to pass, you have to add a \<ProcessAutomationOption> element with the following attributes:

- name (i.e. the name assigned to the value)
- pid (i.e. the ID of the parameter containing the value to be passed)

Example:

```xml
<Protocol>
  ...
  <ProcessAutomation>
    <ProcessAutomationOptions>
      <ProcessAutomationOption name="Queue" pid="501" />
      ...
    <ProcessAutomationOptions>
  <ProcessAutomation>
  ...
</Protocol>
```

### DMS Cube

#### Visual Overview - Edit in Visio: New options 'Add theming' and 'Add pretty hover' \[ID_32660\]

When, in DataMiner Cube, you right-click a visual overview and select “Edit in Visio”, an advanced edit panel will appear. When no shape is selected, you can now click an ellipsis button (“...”) in the top-right corner of the panel. This will open a menu with the following options.

- Add theming: If you click this option, the following theme options will be added to the page-level “Options” data field:

  *#000000=ThemeForeground\|#FF0000=ThemeAccentColor\|#FFFFFF=ThemeBackground*

- Add pretty hover: If you click this option, the following option will be added to the page-level “Options” data field:

  *HoverType=Geometry*

> [!NOTE]
> If no page-level “Options” data field exists, one will be created.

#### Alarm Console - Automatic incident tracking: Manually add/remove alarms to/from alarm groups and rename alarm groups \[ID_32729\] \[ID_32819\] \[ID_32875\] \[ID_32914\] \[ID_32940\] \[ID_32957\] \[ID_33027\]

When, in the Alarm Console, you enable the “Automatic incident tracking” option, from now on, you will be able to manually add/remove alarms to/from alarm groups and to rename alarm groups.

- When you right-click an alarm that is not part of any alarm group, you will be able to click the “Add to incident” option. If you do so, a window will appear, asking you

  - to create a new incident (i.e. a new alarm group) and add the alarm to it, or
  - to add the alarm to an existing alarm group.

- When you right-click an alarm that is already part of an alarm group, you will be able to click the “Remove from incident” option. If you do so, the alarm will be removed from the alarm group of which it was a part.

- By default, automatically created alarm groups are named “View group:X” and manually created alarm groups are named “User defined group”. To rename an alarm group, click the pencil icon next to the name and enter a new name.

> [!NOTE]
> From the moment a user manually adds or removes an alarm to or from an alarm group or renames an alarm group, that group will no longer be updated automatically.

#### Trending - Behavioral anomaly detection: New type of change point 'flatline' \[ID_32839\] \[ID_32856\] \[ID_32950\]

The DataMiner Analytics software can detect a number of changes in the behavior of a trend, also known as “change points”. From now on, it will also be able to detect change points of type “flatline”. A flatline is detected when a fluctuating value suddenly remains constant.

A change point of type flatline will be labeled anomalous when no flatline change point of approximately the same length or longer was recently detected in the trend of the parameter in question. Whenever an anomalous flatline is detected, a “suggestion event” is generated. You can view these suggestion events by creating a suggestion event tab in the Alarm Console.

A new flatline trend icon will be used to indicate when a parameter has flatlined.

### DMS Reports & Dashboards

#### Dashboards app - GQI: Linking feeds to arguments of external data sources \[ID_32658\]

When you build a GQI query that uses an external data source, it is now possible to link feeds to arguments of that external source.

#### Dashboards - Data panel: Enhanced element selection \[ID_32769\]

A number of enhancements have been made to the *Elements* section of the Data panel.

Up to now, when you switched to edit mode, the first 10,000 elements would be loaded. From now on, the elements will be loaded in batches and a “Load more” button will allow you to load in the next batch.

Also, there is now an element search box as well as a number of element filter options:

- a view filter to only show elements in a particular view (and its subviews),
- a protocol filter to only show elements running a particular protocol,
- an *EPM managers* checkbox to only show EPM Manager elements, and
- a *Spectrum analyzers* checkbox to only show Spectrum elements.

#### Dashboards app: Live sharing no longer requires users to have permission to edit the dashboards they are sharing \[ID_32812\]

Up to now, when users wanted to share a dashboard, they also needed to have permission to edit the dashboard in question. From now on, users who want to share a dashboard will no longer need permission to edit that dashboard.

> [!NOTE]
> When you do not have *General \> Live sharing \> UI available* permission, you will not see anything related to live sharing. So, make sure to always use this permission in conjunction with the Share permission.

#### Dashboards app - Service definition component: Arrows will now automatically be drawn when a Process Automation definition was added \[ID_32960\]

When a Process Automation definition is added to the Service definition component, the component will now automatically draw the necessary arrows to indicate the connections between the different blocks/nodes in the diagram.

#### Dashboards app: Using the script output of an interactive Automation script as a feed \[ID_32977\]

When building a GQI query, you can now also use the script output of an interactive Automation script as a feed.

#### Dashboards app - Service definition component: Function shapes will now reflect the function type \[ID_32995\]

When a Process Automation definition is added to the Service definition component, the added function shapes will now reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent).

#### Dashboards app - Service definition component: Function nodes will now display the number of Process Automation tokens in queue or in progress \[ID_33025\]

When a Process Automation definition is added to the Service definition component, all function nodes will now display the number of tokens currently in queue or in progress.

The token counters will be updated every 10 seconds.

### DMS web apps

#### Application framework \[ID_33002\] \[ID_33040\]

The DataMiner application framework allows you to create custom low-code applications that interact with data from a DataMiner System or an external source.

These applications can be created on the root web page of a DataMiner System and can be organized into sections. To place an application in one or more specific sections, open the App.info.json file in the correct application folder (C:\\Skyline DataMiner\\applications\\APP_ID) and add the section names to the Sections array.

##### Pages and panels

Pages and panels are the basic building blocks of an application. On a page or a panel, or even between pages and panels, data can be fed between components to create dynamic visualizations. Pages and panels can also each have a header bar with different buttons that are used to execute actions via events. Each button can have a customized icon and label.

The application sidebar allows you to navigate between the different pages, which can each have a label and an icon. It is also possible to hide pages. That way they will not appear in the sidebar and will only be accessible via actions.

Panels are used to group data on a page. They can be displayed on the left side of a page, on the right side of a page or as a popup, and can be shown or hidden via actions that are executed when an event occurs. Panels can be reused on different pages.

##### Events and actions

In an application, you can configure actions that will be executed each time one of the following events occur:

- A new page is loaded.
- A (header bar) button is clicked.

At present, the following actions can be configured:

| Action                   | Description                                                                                                                                            |
|--------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| Launch a script          | Launch an Automation script with a specific configuration and a specific number of inputs (which can be linked to feeds like e.g. the Query Row feed). |
| Navigate to a URL        | Navigate to a specific URL (in a new tab).                                                                                                             |
| Open a page              | Open a (hidden) page in the same application.                                                                                                          |
| Open a panel             | Open a panel on the current page. Panels can appear on the left side of a page, on the right side of the page or as a popup.                       |
| Close a panel            | Close a panel that was open on the current page.                                                                                                       |
| Open an app              | Navigate to another application.                                                                                                                       |
| Execute component action | Execute a component action. E.g. select an item in a table, create a new instance, etc.                                                            |

By default, actions are executed asynchronously. However, it is also possible to configure chains of actions that should be executed synchronously, i.e. only when the preceding action was executed successfully.

Also, by combining different actions into one, you can create complex behavior. For example, open a page, open a panel and launch an Automation script that updates parameters displayed on that panel while it is being opened. This complex action can then be linked to e.g. a header bar button.

##### Versioning

The application framework includes a versioning system that allows different versions of the same application to exist simultaneously. These different versions can be accessed via the versions panel of the application, which also allows the versions to be edited.

When you create a new application, a first draft version of that application is created. That version can then be published, i.e. made accessible to end users. Each time the published version of an application is edited, a new draft version will be created. Draft versions are meant to be used as prototypes for testing purposes.

Per application, there can be up to 15 versions: 14 draft versions and one published version. When a 16th version is created, the oldest draft version will automatically be deleted. The published version will never be deleted. As there can be only one published version, whenever you publish a version, the previously published version will automatically be demoted to draft version.

##### Security

The application framework has two levels of security:

- on DataMiner level, user permissions control access to the application framework in general, and
- on application level, user permissions control access to specific applications.

Access to the application framework is controlled by the following user permissions that can be configured per user or user group:

- View applications
- Add new applications
- Edit applications
- Delete applications
- Publish applications

> [!NOTE]
> Users without “View applications” permission do not have access to the application framework. Even if they have been granted some of the other user permissions, they will not be able to perform any action whatsoever within the application framework.

Access to a specific application can be configured in the application itself. Per application, you can define a list of users with view and/or edit permission. By default, no restrictions will be applied, meaning that everyone will be allowed to view and edit the application.

### DMS Service & Resource Management

#### Retrieving bookings in a paged way and sorted by property \[ID_31982\]

It is now possible to retrieve bookings in a paged way and sorted by one of the following properties:

- CreatedAt
- CreatedBy
- Description
- LastModifiedAt
- LastModifiedBy

> [!NOTE]
> Depending on the configuration of the Elasticsearch database, DataMiner Agents running one of the following DataMiner versions may potentially not be able to sort by the above-mentioned properties.
>
> - v10.0.0 (CU10)
> - v10.1.0 (CU0)
> - v10.1.1 (CU0)

#### ResourceUsageInfoManager \[ID_32512\]

SLNet now includes a ResourceUsageInfoManager, which will keep track of the Resources being used by ReservationInstances. Each time a change is detected as to Resource usage, this manager will send out a ResourceUsageStatusEventMessage containing the DMA ID and a list of UpdatedResourceUsageStatuses.

A ResourceUsageStatus contains a ResourceId and a list of UsingReservationInstances. That list will contain a ReservationInstanceUsageDetails object for every ReservationInstance that is using the Resource. Currently, the object only contains a ReservationInstanceId property.

Normally, a ResourceUsageStatusEventMessage will be sent out the moment a Resource is being used in an ongoing reservation or when a ReservationInstance using that resource ends. When a Resource is no longer used in any reservation, an event will be sent out with a ResourceUsageStatus containing an empty list.

ResourceUsageStatus objects can be retrieved by means of a GetResourceUsageStatusList (FilterElement\<Resource> filter) call on the ResourceManagerHelper. This call will return all status objects for the resources that match the filter and that are currently being used by ongoing reservations.

#### ResourceManagerEventMessage: New LostInterestReservationInstances property \[ID_32801\]

When, for example, a table is populated with ReservationInstances using ResourceManagerEventMessages with a SubscriptionFilter, you can now use the LostInterestReservationInstances property to retrieve the IDs of the ReservationInstances that no longer match the current filter after an update.

> [!NOTE]
> This list will only contain ReservationInstances to which the user has access.
> To retrieve the IDs of the ReservationInstances to which the user no longer has access, you can call the GetHiddenReservationInstances method.

#### Functions.xml file: Assigning a function type to a function \[ID_32851\]

It is now possible to assign a function type to each function defined in a functions.xml file.

A function can be assigned one of the following types:

- UserTask
- ScriptTask
- ResourceTask
- Gateway
- NoneStartEvent
- TimeStartEvent
- EndEvent

Default function type: NULL

Example:

```xml
<Functions>
  <Function id="..." name="..." maxInstances="..." profile="...">
    ...
    <FunctionType>UserTask</FunctionType>
  </Function>
  ...
</Functions>
```

> [!NOTE]
> If you add a \<FunctionType> element inside a \<Function> element, it must be the last child element inside the \<Function> element.

### DMS Mobile Gateway

#### Additional logging after sending a 'send SMS' request to an SMSEagle device \[ID_32785\] \[ID_32911\]

When an HTTP request of type “send SMS” is sent to an SMSEagle device, the following information will now be logged in the SLGSMGateway log file:

- The response message and code (level “debug”).

    Example:

    ```txt
    Response of sending SMS 'This is a test' to '+324799789789' - Status: HTTP/1.1 200 OK (200) - Response data: OK; ID=25464
    ```

- The response itself as well as the error string retrieved from the HTTP engine used by SLGSMGateway (level “info”) when the response does not start with “OK;”.

    Example:

    ```txt
    Sending the SMS 'This is a test' to '+324799789789' may have failed. Received response: '' (HTTP/1.1 200 OK/200). Error info: 'Error : 12029. [ERROR_WINHTTP_CANNOT_CONNECT]'
    ```

## Changes

### Enhancements

#### Security enhancements \[ID_32849\] \[ID_32954\] \[ID_32992\] \[ID_33014\] \[ID_33052\]

A number of security enhancements have been made.

#### Analytics: Prefetching mechanism for trend icons \[ID_32300\] \[ID_32882\]

During the first few minutes that DataMiner Analytics is running, it is still calculating which trend icons should be displayed. Previously, during this initial period, the trend icons to be displayed were retrieved from the Cassandra database. However, because of changes to the database, this is no longer possible. For this reason, a prefetching mechanism has now been implemented, so that when a trend icon is requested, it is calculated based on prefetched trend data. As there are safeguards in place to ensure that not too many database requests are done at the same time, this does mean that not all trend icons may be displayed immediately.

#### Enhanced performance with regard to the processing of system performance indicators \[ID_32574\]

Because of a number of enhancements, overall performance has increased with regard to the processing of system performance indicators.

#### Dashboards app: Improved loading indicator for bar and pie chart with GQI data \[ID_32806\]

The loading indicator when GQI data are loaded for a bar or pie chart component has been improved to be more in line with the usual dashboard style. Instead of a spinner, now a loading bar is shown at the top of the component.

#### Dashboards app - GQI: Enhanced visualization of queries \[ID_32823\]

A number of enhancements have been made with regard to the visualization of GQI queries. For example, raw values (e.g. column IDs, GUIDs, etc.) will be translated to display values when possible.

#### Cassandra Cluster Migrator tool: Increased write timeout \[ID_32829\]

When it is migrating data, basically, the Cassandra Cluster Migrator tool reads a page of data from the original database (Cassandra or SQL) and then writes that page to the target database (Cassandra Cluster or Elasticsearch). The timeout for the write operations has now been increased from 2 minutes to 30 minutes.

#### Dashboards app - GQI: Queries must now all have a unique name \[ID_32836\]

From now on, when you create, update or import a GQI query, a unique query name will be mandatory. Up to now, query names were optional.

- When you create a new query, the system will suggest “New query” as default name. If that name already exists, then a counter will be added (e.g. “New query (1)”, “New query (2)”, etc.
- When you import a query that has no name, the system will suggest “Imported query” as default name. If that name already exists, then a counter will be added (e.g. “Imported query (1)”, “Imported query (2)”, etc.

#### DataMiner upgrade packages: Obsolete upgrade/downgrade actions removed \[ID_32861\]

Obsolete upgrade and downgrade actions for DataMiner versions older than DataMiner 9.6 have now been removed from the DataMiner upgrade packages

#### Dashboards app - GQI: Node placeholders now have a clearer name \[ID_32866\]

In the GQI query builder, the node placeholders now have a clearer name. For example, the name of the first node has been changed from “Filter” to “Select data source” and all subsequent nodes will now be named “Select operator”.

#### SLMessageBroker: Default connection timeout is now 10 minutes \[ID_32884\]

The Connect() and Publish() methods of SLMessageBroker now have a default connection timeout of 10 minutes.

Also, the interval at which another reconnect is attempted has been increased from 1 second to 10 seconds.

#### Web Services API: Enhanced handling of errors thrown when processing asynchronous requests \[ID_32933\]

A number of enhancements have been made with regard to the handling of errors thrown when processing asynchronous requests.

#### DataMiner upgrade packages: New prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents \[ID_32944\]

From now on, upgrade packages will perform a prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. This will prevent situations where a DataMiner System becomes non-functional after an upgrade that uses more or different ports.

Ports currently checked:

- 4222: NATS
- 6222: NATS (only checked when you are not upgrading a standalone agent, a standalone Failover pair or a two-node agent cluster)
- 9090: NAS

If this check fails, you will need to execute the VerifyClusterPorts.dmupgrade package ([download](https://community.dataminer.services/download/verifyclusterports-dmupgrade/)). VerifyClusterPorts.dmupgrade will run the same tests as the DataMiner upgrade package, but it will make sure that temporary listening ports are open for the required ports and a temporary local firewall rule is configured. This way, if a firewall or other configuration issue is causing the problem, this will become clear. If no failing ports are reported when you run this package, the regular upgrade package will use this stored result to continue with the upgrade.

#### Enhanced setup of serial connections with SSL/TLS enabled \[ID_32969\]

A number of enhancements have been made with regard to the setup of serial connections with SSL/TLS enabled.

### Fixes

#### Alarm templates: Miscellaneous fixes \[ID_32462\]

A number of issues have been fixed with regard to alarm templates.

- When you updated an alarm template that contained a table parameter with at least two filters, only the last of those filters was calculated.
- When, in an alarm template, you disabled the smart baselines for a table parameter with a filter and then re-enable it, the smart baselines for that table parameter would no longer be calculated.

Also, a number of enhancements have been made with regard to the calculation of smart baselines.

#### Cassandra Cluster Migrator tool would incorrectly not allow multiple IP addresses in the 'Cassandra IP(s)' field \[ID_32554\]

When configuring the Cassandra settings in the Cassandra Cluster Migrator tool, it would incorrectly not be possible to specify multiple IP addresses in the *Cassandra IP(s)* field.

#### SLAnalytics - Pattern matching: No 'suggestion event' type alarm would be triggered in case of DVE elements \[ID_32671\]

From DataMiner 10.0.13 onwards, you can activate alarm monitoring of trend patterns, so that a “suggestion event” type alarm is triggered whenever a specific pattern is detected. In case of dynamic virtual elements, in some cases, no “suggestion event” type alarm would be triggered.

#### SLAnalytics: Inaccurate short-term trend predictions \[ID_32731\]

If the DataMiner Agent uses a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, in some cases, short-term trend predictions could be inaccurate due to a longer seasonality being detected on a higher level.

#### Service & Resource Management: GetEligibleResources would ignore the time range passed to it \[ID_32763\]

Up to now, when GetEligibleResources was called, the eligible resources would incorrectly be calculated based on the time range of the ReservationInstance to be ignored. From now on, when the context passed to GetEligibleResources includes a time range, the time range of the ReservationInstance will be ignored.

#### DataMiner Cube: Problem when opening the Ticketing app \[ID_32775\]

Up to now, in some cases, the Cube UI could become unresponsive when you opened the Ticketing app.

#### DataMiner Cube - Visual Overview: SET command linked to a shape would not be executed when the page was displayed in a VdxPage window of type 'Popup' \[ID_32780\]

When a page that was displayed in a VdxPage window of type “Popup” contained a shape linked to a SET command, clicking that shape would incorrectly not execute the SET command.

#### DataMiner Cube - Resources app: No resources or resource pools would be loaded when opening the Resources app \[ID_32790\]

When you opened the Resources app, in some cases, no resources or resource pools would be loaded.

#### Dashboards app - GQI: GUIDs of DOM reference fields would be displayed incorrectly \[ID_32807\]

Up to now, the GUIDs of the following types of DOM reference fields would be displayed incorrectly:

- Reservations (i.e. bookings)
- Service definitions
- DOM instances
- Resources

#### MessageBroker: Timeout value would incorrectly be ignored when using RequestResponse(Async) [ID_32810]

<!-- MR 10.3.0 - FR 10.2.5 -->

When, in the MessageBroker, RequestResponse(Async) was used when NATS was not yet connected, the specified timeout value would incorrectly be ignored. The timeout value would only be applied to the actual NATS communication and not to the potential reconnection logic.

#### Dashboards app: Problem when sorting a table component populated by means of a GQI query \[ID_32814\]

When you sorted a table component populated by means of a GQI query, in some cases, the sorting would be incorrect.

#### Processes would not get registered correctly when a DataMiner upgrade included a reboot \[ID_32818\]

When a DataMiner upgrade included a reboot (either explicitly requested, or e.g. after installing Microsoft .NET 4.8), in some cases, services would not get registered correctly, especially when the new DataMiner version included services that did not previously exist.

#### Dashboards app: Problem when sharing a dashboard with a node edge component \[ID_32822\]

When viewing a shared dashboard with a node edge component that had its nodes configured to use either analytical or alarm colors, the node edge component could not be rendered.

#### Problem with SLDMS hosting agent cache \[ID_32827\]

In some rare cases, the SLDMS hosting agent cache could get corrupted. As a result, it would no longer contain the correct data when processing element updates.

#### Dashboards app: Query name reset when query is edited \[ID_32832\]

In some cases, when the content of a query in a dashboard was changed, it could occur that the name of the query was reset to a previous value.

#### Dashboards app: Display value that was used to refer to an unnamed query would incorrectly contain HTML tags \[ID_32833\]

When a query had not been assigned a name, up to now, the display value that was used to refer to that unnamed query would incorrectly contain HTML tags. From now on, the name “(query)” will be used to refer to an unnamed query.

#### Exception logged in SLNet.txt during startup \[ID_32835\]

Since DataMiner 10.2.0 \[CU0\] and DataMiner 10.2.2, the following exception could be generated in the SLNet.txt log file during DataMiner startup:

```txt
2022-03-09 12:34:38.962|5|Config.Init|Error reading MaintenanceSettings.xml: System.Exception: Re-entrant Facade.Initialize detected. Do not access Facade.Instance directly or indirectly from the Facade constructor. ---> System.Exception: at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
   at System.Environment.get_StackTrace()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
   at Skyline.DataMiner.Net.Config.get_Instance()
   at Skyline.DataMiner.Net.Facade..ctor()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.SLNetService.<OnStartInner>b__10_0()
   at System.Threading.Tasks.Task.Execute()
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)
   at System.Threading.Tasks.Task.ExecuteEntry(Boolean bPreventDoubleExecution)
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   --- End of inner exception stack trace ---
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
```

#### NAS: Incorrect default settings in nas.config file \[ID_32840\]

The default settings in the nas.config file would be incorrect.

#### SLNet would incorrectly log XmlSerializer exceptions \[ID_32859\]

Up to now, SLNet would incorrectly log the following exception each time it was thrown:

```txt
SLNet tried to load DataMinerInstallerCommunication.XmlSerializers
```

#### Dashboards app - GQI: Problem when exporting table data to CSV \[ID_32865\]

When you exported GQI data from a table component to a CSV file, up to now, only the currently loaded page would get exported. From now on, all data in the table will be exported.

> [!NOTE]
> While the export operation is progress, an “exporting to CSV” notification will be shown in the bottom-right corner of the screen.

#### Memory leak in SLElement \[ID_32885\]

In some cases, a problem with subscriptions on views with remote data would cause SLElement to leak memory, which could eventually lead to run-time errors in the parameter thread.

#### Filtered tables could incorrectly receive updates for rows that did not match the applied filter \[ID_32915\]

In some cases, a filtered table could incorrectly receive updates for rows that did not match the applied filter. On EPM setups, this would cause performance issues and run-time errors.

#### DataMiner Cube - Alarm Console: Focus icon would not be displayed when a new alarm was added to an alarm group \[ID_32931\]

When an alarm was added to an alarm group while that group was expanded, the focus icon would incorrectly not be displayed.

#### Web Services API: Problem when opening the soap.asmx page \[ID_32939\]

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Online SLA window would not get properly closed \[ID_32946\]

In some cases, an online SLA window would not get properly closed.

#### Dashboards app - GQI: Queries using different custom data sources from the same library would incorrectly be considered the same query when fetching results \[ID_32965\]

Up to now, queries using different custom data sources from the same library would incorrectly be considered the same query when fetching results.

#### Memory leak in SLSpiHost \[ID_32970\]

In some cases, the SLSpiHost process could leak memory.

#### DataMiner Cube - Alarm Console: Incident alarms were incorrectly shown twice \[ID_32981\]

When, upon opening DataMiner Cube, the Alarm Console had an active alarms tab page with “Automatic incident tracking” enabled, in some cases, the incident alarms would incorrectly be shown twice.

#### DataMiner Cube: No longer possible to move DVE elements to another view \[ID_32984\]

In some cases, it would incorrectly no longer be possible to move DVE elements to another view.

#### NATS issue could cause a DataMiner Agent to not start up correctly \[ID_33026\]

In some cases, a NATS issue could cause a DataMiner Agent to not start up correctly.

#### Dashboards app - GQI: Problem while creating or updating a query when users did not have permission to view objects retrieved by a data source \[ID_33029\]

When users were creating or modifying a GQI query, in some cases, an exception could be thrown when those users did not have permission to view objects retrieved by a data source.

#### Problem when starting up SLNet \[ID_33033\]

In some cases, the following error would be logged in SLNet.txt with XYZ being the word “AUTHORITY” in a language other than English:

```txt
Connection did not authenticate. Computer: COMPUTERNAME Application: SLDataGateway User: NT-XYZ\SYSTEM
```

The problem would occur on systems installed in a language other than English and was caused by code looking for the NT-AUTHORITY\\SYSTEM user, which on these systems, was named differently.

#### Problem with SLLog when a log file was closed \[ID_33191\]

In some cases, an error could occur in the SLLog process when a log file was closed.

## Addendum CU1

### CU1 fixes

#### Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled \[ID_33326\]

Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled.
