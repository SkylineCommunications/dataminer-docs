---
uid: General_Feature_Release_10.0.13_changes
---

# General Feature Release 10.0.13 - Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Dashboards app: Right-clicking a component now only shows 'Copy embed URL' in edit mode \[ID_27629\]

Previously, when a dashboard component was right-clicked, this always showed the option *Copy embed URL*. However, as this option is not as useful for a dashboard operator as the default right-click menu, it will now only be displayed when the component is right-clicked in edit mode. Otherwise, the default right-click menu will be displayed.

#### DataMiner Cube - Services app: Enhanced retrieval of service information \[ID_27647\]

In the Services app, all SRM service information will now be retrieved page by page.

#### StandAloneBpaExecutor now supports asynchronous execution of BPA tests across a DMS \[ID_27652\]

The StandAloneBpaExecutor tool now supports asynchronous execution of one or more BPA tests across a DataMiner System.

#### BPA test metadata now indicates whether a test contains corrective actions \[ID_27704\]

The metadata of a BPA test now includes a HasCorrectiveActions property.

If a BPA test contains corrective actions, this property will be set to true.

#### Enhanced performance when processing alarm template actions \[ID_27706\]

Due to a number of enhancements, overall performance has increased when processing alarm template actions.

#### DataMiner Cube - Resources app: A popup message will now be displayed when trying to configure resources on a system with an SRM license but no Indexing Engine \[ID_27737\]

When, on a system with an SRM license but no Indexing Engine, you try to configure resources, from now on, DataMiner Cube will show a message, saying that this is not possible.

#### BPA test framework: New flag to indicate whether a test can be run against an offline agent in a Failover setup \[ID_27762\]

When you create a BPA test, you can now use the BpaFlags.CanRunOnOfflineAgents flag to indicate whether the test can be run against an offline agent in a Failover setup.

Default: False

#### Long running actions will now be canceled when a DataMiner upgrade finishes \[ID_27765\]

When a DataMiner upgrade finishes (successful or not), from now on, all remaining long running actions will be canceled.

#### Client applications now also get notified when cell alarm levels in the source data tables of direct views change due to updates that do not change the cell value \[ID_27785\]

From now on, client applications displaying direct views will also be notified when cell alarm levels in the source data tables change due to updates that do not change the cell value. (e.g. when a cell in a source table gets masked).

#### Live Sharing Service: Enhanced error handling \[ID_27791\]

A number of enhancements have been made to the overall error handling in the Live Sharing Service.

#### DataMiner Cube: Enhanced consistency of trend graph legends \[ID_27831\]

From now on, when multiple trend graphs show similar data, they will all have a similar legend.

#### DataMiner Cube: Virtual functions now in separate section in Protocols & Templates app + made unavailable for regular element creation \[ID_27832\]

Virtual functions are now displayed in a separate *Virtual Functions* section in the Protocols & Templates app. In addition, when you create an element, virtual functions are not listed among the protocols you can choose for the element.

#### DataMiner Cube: Enhanced performance when connecting to a DMA with a large amount of alarms \[ID_27837\]

Due to a number of enhancements, overall performance has increased when connecting to a DataMiner Agent with a large amount of alarms.

#### Interactive Automation scripts: No longer possible to clear the value of a selection box control \[ID_27845\]

Up to now, in an interactive Automation script, it was possible to clear the value of a selection box control by clicking an X button. From now on, this is no longer possible.

#### DataMiner Cube: Enhanced performance when logging in and logging out \[ID_27851\]

Due to a number of enhancements, overall performance has increased when logging in and logging out, especially on large systems.

#### Interactive Automation scripts: Multi-line text boxes will no longer expand when selected \[ID_27858\]

Up to now, a multi-line text box (i.e. a UIBlock of type TextBox with IsMultiline set to true) would by default have a height of 1 line and would expand when it was selected. From now on, its initial height will be fixed. It will no longer expand when selected.

#### Failover: More information will now be returned after synchronizing the two agents \[ID_27870\]

After synchronizing the two agents in a Failover setup, from now on, more detailed information about the synchronization process will be returned.

#### DataMiner Cube - Data Display: Background color of tree control table tabs has been adapted in order to enhance readability \[ID_27881\]

In the Skyline Black theme, the background color of tree control table tabs has been adapted in order to enhance readability.

#### SLPort now automatically resizes the socket buffer before receiving data from a socket \[ID_27891\]

From now on, the SLPort process will automatically resize the socket buffer before receiving data from a socket.

#### DataMiner Cube - Settings: No longer possible to set Connection type to 'Web services' \[ID_27904\]

Since Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, the only way for DataMiner Cube to connect to a DataMiner Agent is by using .NET Remoting. As a result, in the *Settings* window, it is no longer possible to set the *Computer \> Connection \> Connection type* setting to “Web services”.

#### Service & Resource Management: Deleting resources only allowed when all DMAs in the DMS are reachable \[ID_27921\]

From now on, you will only be allowed to delete resources when all agents in the DMS are reachable. This will prevent deleted resources from re-appearing when a DMA is started up again.

When you try to delete a resource, an error will now be returned in the following circumstances:

- When at least one agent is disconnected from the agent that hosts the resource you are trying to delete.
- When at least one agent is not in a running state.
- When there is at least one agent on which the ResourceManager module is not initialized.

#### DataMiner Jobs: new ResourceFieldDescriptor field \[ID_27922\]

A new *ResourceFieldDescriptor* field is now available for DataMiner jobs. This field requires a GUID value, which should be the GUID of a resource. It also has a *ResourcePoolIds* property which can be used to filter resources based on resource pools. This feature is intended to support the upcoming PLM app.

#### Performance enhancement: An element card page containing a direct view table will only show the alarm severity of that table when the page is opened \[ID_27928\]

When you open an element card, pages containing direct view tables will no longer show the alarm severity of those tables. Only when you open a page containing a direct view table will the alarm severity of that table be calculated and displayed.

#### DataMiner Jobs: New DefaultValue property of FieldDescriptor class \[ID_27934\]

The *FieldDescriptor* class for DataMiner jobs now has a new *DefaultValue* property, so that it is now possible to add a default field value to each FieldDescriptor. This feature is intended to support the upcoming PLM app.

#### DataMiner Cube: Enhanced performance when opening the Reports page of a view card \[ID_27937\]

Due to a number of enhancements, overall performance has increased when opening the Reports page of a view card, especially when that page shows a large amount of elements with heatlines (e.g. the root view).

#### Service & Resource Management: ResourcesNotMatchWithServiceDefinition check removed \[ID_27938\]

The ResourcesNotMatchWithServiceDefinition check has been removed.

As a result, an error will no longer be returned when saving a ServiceReservationInstance where the booked resources do not match the functions or virtual functions required by the ServiceDefinition.

#### Service & Resource Management: New VirtualFunctionID property added to NodeDefinition class \[ID_27953\]

A new *VirtualFunctionID* property is now available for *NodeDefinition* objects for service profiles.

When a service profile definition is created, DataMiner will check if the virtual function ID exists. If it does not exist, a new error reason *InvalidVirtualFunctionDefinitions* will be added in the trace data. The property *InvalidVirtualFunctionIDs* of the trace data will be filled in with the non-existing virtual function IDs. The property *ServiceProfileDefinition* of the trace data will allow you to identify which service profile definition has an error.

Note that this property can currently not yet be configured in DataMiner Cube.

#### Ticketing app: Enhanced 'Edit ticket field' window \[ID_27962\]

Due to a number of enhancements to the *Edit ticket field* window, especially the section that allows you to define the possible values, configuring a ticket state field has been made more intuitive.

#### DataMiner Cube - System Center: Refresh button in Logging section \[ID_27986\]

In the Logging section of System Center, you can now click Refresh to reload the log entries.

#### BPA test framework: Abstraction layer added to allow backward compatibility of BPA tests \[ID_27988\]

An abstraction layer has now been added to the BPA test framework. This will prevent older tests from being rendered incompatible when changes are made to the framework.

#### SLNet.exe.config: TcpWebServicePort key will now be ignored \[ID_27990\]

As Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, in the appSettings section of the SLNet.exe.config file, the TcpWebServicePort key will now be ignored.

#### BPA tests can now be assigned a maximum DataMiner version \[ID_27997\]

When creating a BPA test, it is now possible to indicate the most recent DataMiner version on which the test will work.

When a DataMiner Agent is upgraded to a version equal to or above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version equal to or above the one specified in the MaxVersion setting.

#### Dashboards app - Parameter feed: 'partial table' renamed to 'paged table' \[ID_28048\]

In the tool tip of the “Select all items” and “Select specific number of items” options, “partial table” has been renamed to “paged table”.

#### New icons added to Icons.xml file \[ID_28060\]

The following new icons have been added to the file Icons.xml, located in the folder C:\\Skyline DataMiner\\Protocols.

- Trash
- New item

### Fixes

#### Dashboards app: Navigation pane issue after refresh in edit mode \[ID_27339\]

If you exited edit mode in the Dashboards app after refreshing while edit mode was active, all folders in the navigation pane were collapsed and the current dashboard was no longer indicated as selected.

#### DataMiner Cube - Visual Overview: Unnecessary subscription on property when highlight condition was configured based on name \[ID_27409\]

When a highlight condition was configured on a Visual Overview shape based on the name of an element, service or view, an unnecessary property subscription was also made. This will no longer occur.

#### DataMiner Cube - Visual Overview: No log entry would get created when a Visio shape contained a reference to an element on a disconnected DMA \[ID_27527\]

No log entry would get created when a Visio shape displaying a chart contained a reference to an element located on a disconnected DataMiner Agent.

#### Failover: Problem with SLSNMPManager \[ID_27599\]

During a Failover switch, in some cases, an error could occur in SLSNMPManager.

#### Jobs app: Problem when no domains were configured \[ID_27635\]

When no domains had been configured, in some cases, the jobs list would incorrectly keep loading. Also, when you refreshed an empty jobs list, a “page not found” error would be displayed.

> [!NOTE]
> Up to now, when no domains were configured, a popup message would be displayed, asking you to create one. From now on, visual indication and a button will be displayed instead.

#### DataMiner Cube: When one client forcefully disconnected another client, the latter would incorrectly reconnect \[ID_27638\]\[ID_27671\]

When two different Cube clients were connected to the same DataMiner Agent, and one forcefully disconnected the other, up to now, that forceful disconnection would incorrectly be considered as abnormal, causing the disconnected client to immediately reconnect.

From now on, when one client forcefully disconnects another client, the disconnection will be treated as a forceful logout instead.

#### Problem with excessive memory usage of SLDataGateway and SLNet during DataMiner startup \[ID_27658\]

When a DataMiner Agent with a Cassandra database had experienced two days of high alarm activity, in some cases, SLDataGateway and SLNet would start to use excessive amounts of memory after DataMiner startup.

A number of enhancements have now been made to the way in which the alarm history is retrieved during a DataMiner startup.

#### Interactive Automation scripts: Problem when a text box had its wantOnChange setting set to true and its value set to an empty string \[ID_27666\]

When a text box in an interactive Automation script had its wantOnChange setting set to true and its value set to an empty string, in some cases, an exception could be thrown.

#### Mobile apps: Problem with time range quick pick buttons \[ID_27676\]

In the Dashboards app and other DataMiner mobile apps, it could occur that the quick pick buttons of a time range selector did not function correctly.

#### DataMiner Cube - Visual Overview: Problem when clicking a connection line drawn based on table data \[ID_27692\]

In some cases, an exception could be thrown when you clicked a connection line that was drawn based on table data.

#### DataMiner Cube: Problem when connecting to DMS with many alarms and many stopped/paused elements \[ID_27707\]

In some cases, DataMiner Cube could have difficulty connecting to a DMS with a large number alarms and a large number of stopped or paused elements.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_27708\]

When you select the *Line graph instead of block graph* option when exporting a trend graph to a CSV file, the timestamps of the average data points are put halfway between two points.

In some cases, when you exported a trend graph multiple times in a row using that line graph option, the timestamps would incorrectly keep shifting in the direction of the future.

#### When users logged in with domain administrator credentials, they would incorrectly log in with the local administrator account instead \[ID_27713\]

In some cases, when users logged in with domain administrator credentials, they would incorrectly log in with the local, built-in administrator account instead.

#### Problem with SLDataMiner when importing a CSV file created with a previous DataMiner version \[ID_27722\]

When you imported a CSV file that was created with a previous DataMiner version, in some cases, an error could occur in SLDataMiner.

#### Automatic incident tracking: Problem when removing the IDP location from elements with active alarms \[ID_27723\]

On a system using automatic incident tracking on which DataMiner Infrastructure Discovery Provisioning (IDP) was deployed, in some cases, when the IDP location of an element with active alarms was removed, that location would not be removed correctly. This would cause certain alarms to be grouped by an empty location.

> [!NOTE]
> From now on, IDP location grouping requires that the *Make this property available for alarm filtering* option is activated for the following element properties: IDP, Location Name, Location Building, Location Floor, Location Room, Location Aisle and Location Rack.

#### Service & Resource Management: Problem when rebinding a VirtualFunctionResource \[ID_27735\]

When a VirtualFunctionResource was unbound, in some cases, it would still be processing parameter sets from its bound element. This would cause the parameters of the unbound element to no longer be in an “uninitialized” state. Instead, they would incorrectly stay set to the last received value from the bound element.

#### Interactive Automation scripts: MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly \[ID_27736\]

In some cases, the MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly.

#### DataMiner Cube - Data Display: Trend icons would not be displayed until after a few minutes \[ID_27740\]

When you opened an element card, in some cases, trend icons in tables would not be displayed until after a few minutes.

#### DataMiner Cube - Protocols & Templates: An alarm template group would incorrectly not take into account the scheduling configured in the alarm templates in that group \[ID_27749\]

When an alarm template using scheduling was added to an alarm template group, in some cases, the alarm template group would not take into account the scheduling configured in that alarm template.

#### DataMiner - Router Control app: Newly selected input would be highlighted but not selected when the selected output was updated \[ID_27752\]

When, in the Router Control app, you had enabled the *Output first workflow* option, in some cases, when the selected output was updated by an external change, the newly selected input would be highlighted but incorrectly not selected.

Also, it will now be indicated more clearly that a highlighted IO button is selected.

#### Service & Resource Management: When a ReservationInstance was updated, the timeout scripts would incorrectly be executed instead of the expected event script \[ID_27757\]

When you updated an ongoing ReservationInstance, in some cases, all ongoing and future events (i.e. scripts) of that instance would incorrectly be canceled and the timeout scripts would be run on all DataMiner Agents instead.

#### DataMiner Cube: 'Show all alarm updates' option not working with alarm for migrated element \[ID_27761\]

If several alarm updates for an element that had been migrated from one DMA to another were combined in a consolidated alarm event, it could occur that the *Show all alarm updates* option on the corresponding alarm card did not work.

#### Problem when updating a DVE table while data exported via a virtual function was being retrieved \[ID_27768\]

In some cases, an error could occur when a DVE table was updated while data exported via a virtual function was being retrieved.

#### Dashboards app: Parameter state component would not get updated when selecting another element in the linked element feed \[ID_27771\]

When a parameter state component was linked to an element feed, in some cases, the parameter state component would not get updated when you selected another element in the element feed.

#### Alarms with a virtual function impact would not be regenerated when a virtual function was linked or unlinked via the generic linked table \[ID_27775\]

When a virtual function was linked or unlinked via the generic linker table, in some cases, alarms with a virtual function impact would not be regenerated.

#### DataMiner Cube: Problem when opening a ListView component containing bookings \[ID_27780\]

In some cases, a KeyNotFound exception could be thrown when you opened a ListView component that contained a list of bookings.

#### Memory leak when using the Chromium browser engine in a browser version of DataMiner Cube \[ID_27789\]

When running a browser version of DataMiner Cube in Microsoft Internet Explorer, in some cases, a memory leak could occur when using the Chromium browser engine to e.g. visualize web pages in Visual Overview.

#### Problem with SLDataMiner at startup when no NICs could be found \[ID_27799\]

In some cases, an error could occur in SLDataMiner at startup when no NICs could be found.

#### Alarm missing from service alarm table after enhanced service was renamed \[ID_27800\]

When an enhanced service was renamed while there was an alarm on multiple services, it could occur that this alarm was cleared from the alarm table of the enhanced service element.

#### DataMiner Cube - Service & Resource Management: Certain text boxes would not allow you to enter a zero character \[ID_27809\]

In certain text boxes, in some cases, it would not be possible to enter a zero character.

#### Jobs app: Empty drop-down boxes when creating/editing job \[ID_27810\]

When a job was created or edited in the Jobs app, it could occur that no items were displayed in drop-down boxes.

#### DataMiner Cube - Alarm Console: Problem when performing actions in rapid succession \[ID_27814\]

In the Alarm Console, in some cases, an exception could be thrown when certain actions were performed in rapid succession.

#### Problem with Protocol.Groups.Group.Content.Session@Next attribute \[ID_27820\]

In a Protocol.Groups.Group.Content.Session@Next attribute, you can specify the number of milliseconds DataMiner has to wait to execute the next session after receiving the response of the last executed session. In some cases, this setting would incorrectly be disregarded.

#### SLAnalytics: Problem when opening a trend graph on a system using pattern matching \[ID_27829\]

On a system using pattern matching, in some cases, an error could occur in SLAnalytics when you opened a trend graph.

#### Alarm masked for a limited period of time would not be unmasked if the alarm template was updated while the alarm was masked \[ID_27838\]

When an alarm associated with a column parameter was masked for a limited period of time, in some cases, it would not be unmasked when that period of time elapsed if an alarm template update affecting the column parameter had occurred while it was masked.

#### Dashboards app - Line chart component: Problems when retrieving trend data \[ID_27853\]

In some cases, a trend graph legend would show an error when a trend data request was interrupted, e.g. by scrolling to another page before the current page was fully loaded.

Also, when multiple trend requests were required, in some cases, those requests would be ignored when a trend data request was already in progress.

#### Service & Resource Management: When an unbound Virtual Function Resource was deleted, the replication connection was incorrectly not removed \[ID_27857\]

When an unbound Virtual Function Resource was deleted, in some cases, the replication connection would incorrectly not be removed.

#### DataMiner Cube - Profiles app: Service profiles could not be deleted when linked to a profile instance \[ID_27860\]

In some cases, it would not be possible to delete a service profile, especially when a profile instance had a link to it. In the profile instance editor, the service profile selection box now contains a “\<None>” entry. This will allow the link to the service profile instance to be severed.

Also, in some cases, the Profiles app would not load service profile objects.

#### Dashboards app - Line chart component: Trend graph incorrectly showed primary key instead of display key \[ID_27879\]

When a table parameter had a display key that was different from the primary key, up to now, the trend graph would incorrectly show the primary key. From now on, it will show the display key instead.

#### Problem with automatic URI detection \[ID_27884\]

In some cases, an exception could be thrown during automatic URI detection.

#### Problem when editing a protocol while a cluster synchronization was in progress \[ID_27890\]

In some rare cases, an error could occur when a protocol was edited while a cluster synchronization was in progress.

#### DataMiner Cube - Trending: Problem with trend groups containing invalid data \[ID_27892\]

In some cases, an exception could be thrown when a trend group contained invalid data.

#### Dashboards app - Pivot table component: Problem with conditions \[ID_27897\]

When a pivot table component had conditions configured, in some cases, those conditions would incorrectly only work in conjunction with table column parameters, not with single-value parameters.

Also, a selection box problem could occur when multiple conditions were configured in the “Configure indices” section.

#### Automation: Problem when retrieving information events from all DMAs \[ID_27903\]

When, in a DataMiner System with multiple agents, information events were retrieved by an Automation script, in some cases, not all information events would be retrieved.

#### Dashboards app - Time range component: Default range would be used even after being overwritten afterwards \[ID_27941\]

If the default values of a time range component had been set to a custom range, in some cases, those values would incorrectly still be used after being overwritten afterwards (e.g. by means of URL arguments or another feed).

#### DataMiner Cube - Bookings app: Memory leak when opening the Signal Path tab \[ID_27952\]

In some cases, DataMiner Cube could leak memory each time you opened the Signal Path tab when configuring a booking in the Bookings app.

#### DataMiner Cube - Services app: Profile Instances would not be loaded and the Profile Instance selection box would not contain any items \[ID_27989\]

When, in the Services app, you loaded a Service Profile Instance, in some rare cases, the Profile Instance would stay empty and the Profile Instance selection box would not contain any items.

#### Cube launcher tool: Problem when checking the host name \[ID_27992\]

When you configured a new DataMiner Agent, in some cases, an error could occur when the DNS name could not be resolved while checking the host name.

#### DataMiner Cube - Visual Overview: Problem with SurveyorSearchText variable \[ID_27996\]

In some cases, making a shape display or set the Surveyor search text using the Surveyor-SearchText session variable would no longer work.

#### DataMiner Cube - Visual Overview: Save button no longer working in embedded Service Manager component \[ID_28003\]

In an embedded Service Manager component, in some cases, the Save button would no longer work.

#### Service & Resource Management: Capacities property and Capabilities property of a Resource could incorrectly be set to null \[ID_28005\]

In some rare cases, the Capabilities property and the Capacities property of a Resource could incorrectly be set to null.

#### DataMiner Cube - Profiles app: Incorrect error message when Name text box is empty \[ID_28007\]

When the name of a profile definition or a profile instance was empty, in some cases, an incorrect error message would appear.

#### DataMiner Cube: Problem when the single, dynamically included element in a service was briefly excluded \[ID_28013\]

When a service contained a single, dynamically included element, in some cases, an exception could be thrown when the element was briefly excluded from the service.

#### Display values of rate alarms would have an unnecessary level of precision after an element restart on systems with a MySQL database \[ID_28028\]

On a system with a MySQL database, in some cases, display values of rate alarms would have an unnecessary level of precision after an element restart.

#### Value rate alarm not displayed correctly \[ID_28039\]

In some cases, it could occur that the value of a rate alarm was not displayed correctly. this could for instance occur after an element restart, after an element was masked, etc.

#### DataMiner Cube - Alarm Console: Error alarms could get stuck when a process had multiple threads with run-time errors \[ID_28113\]

In some cases, error alarms could get stuck in the Alarm Console when a process had multiple threads with run-time errors.

#### Problem in SLLog after stopping and reopening log file \[ID_28122\]

If a log file was stopped and then reopened shortly afterwards, a problem could occur in the SLLog process.

#### Problem when restarting an agent in a DataMiner System \[ID_28152\]

When an agent was restarted in a DataMiner System, certain SLNet threads could get stuck for a period of time when the connection was severed on other agents in the same DataMiner System.

## Addendum CU1

### CU1 fixes

#### SLWatchDog2.txt: Total number of processes of which at least one thread has a run-time error was incorrectly replaced by total number of threads with a run-time error \[ID_28360\]

Each time a run-time error occurs, an entry is added to the SLWatchDog2.txt log file, showing the total number of processes of which at least one thread has a run-time error.

However, in some cases, that log entry would incorrectly show the total number of threads with a run-time error instead.

#### Failover: Configuration issues \[ID_28378\]

In a Failover setup, in some cases, an error could occur when no ElasticSearch database was found.

Also, in some cases, configuration updates would be ignored after a Failover switch.
